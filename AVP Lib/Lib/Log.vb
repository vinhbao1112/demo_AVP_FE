Imports log4net
Imports System.Globalization

' Configure log4net using the .config file
<Assembly: log4net.Config.XmlConfigurator(Watch:=False)> 
<Assembly: log4net.Config.Repository()> 
' This will cause log4net to look for a configuration file
' called simulator.exe.config in the application base
' directory (i.e. the directory containing simuator.exe)
' The config file will be watched for changes if Watch:=True.
Public Enum LogType
    [Debug] = 0
    [Info] = 1
    [Alarm] = 2 'LOT Transcript.    “Warning” should be change to “Alarm”.
    [Warning] = 3
End Enum
Public Class Log
#Region "Logger Constant"
    Private Const LOGGER_AVP As String = "AVP"
    Private Const LOGGER_KEPSERVER As String = "AVP.KepServer"
    Private Const LOGGER_TERMINALSERVR As String = "AVP.TerminalServer"
    Private Const LOGGER_GUI As String = "AVP.GUI"
    Private Const LOGGER_PMX As String = "AVP.PMx"
    Private Const LOGGER_CORE As String = "AVP.Core"
    Private Const LOGGER_DATAMANAGEMENT As String = "AVP.DataManagerment"
    ' log message from Robot, Aligner, Elevator
    Private Const LOGGER_ROBOT As String = "AVP.TerminalServer.Robot"
    ' log message from CRYO
    Private Const LOGGER_CRYO As String = "AVP.TerminalServer.Cryo"
    ' log message from chamber
    Private Const LOGGER_CHAMBER As String = "AVP.TerminalServer.Chamber"

    ' log message from chamber
    Private Const LOGGER_SCHEDULER As String = "AVP.Scheduler"
    Private Const LOGGER_LLALOTDATALOG As String = "AVP.LLA.LOTDATA"

    'log message from sequence
    Private Const LOGGER_SEQUENCE As String = "AVP.Sequence"
    Private Const LOGGER_PARAMETER_CHANGE_FROM_SETTING As String = "AVP.Setting.ParameterChanges"

    ' Logger name is AVP
    Public Shared avpLogger As ILog = Nothing

    ' Logger name is PMx
    Public Shared pmLogger As ILog = Nothing

    ' Logger name is AVP.KepServer
    Public Shared kepServerLogger As ILog = Nothing

    ' Logger name is AVP.TerminalServer
    Public Shared terminalServerLogger As ILog = Nothing

    ' Logger name is AVP.GUI
    Public Shared guiLogger As ILog = Nothing

    ' Logger name is AVP.Scheduler
    Public Shared coreLogger As ILog = Nothing

    ' Logger name is AVP.DataManagerment
    Public Shared dataManagementLogger As ILog = Nothing

    ' Logger name is AVP.TerminalServer.Robot
    Public Shared terminalServerRobotLogger As ILog = Nothing

    ' Logger name is AVP.TerminalServer.Cryo
    Public Shared terminalServerCryoLogger As ILog = Nothing

    ' Logger name is AVP.TerminalServer.Chamber
    Public Shared terminalServerChamberLogger As ILog = Nothing

    ' Logger name is AVP.Scheduler
    Public Shared schedulerLogger As ILog = Nothing
    'Public Shared LLALotdatalog As ILog = Nothing
    'Public Shared LLBLotdatalog As ILog = Nothing

    ' Logger name is AVP.Sequences
    Public Shared seqLogger As ILog = Nothing
    ' Logger name is AVP.ParameterChanges
    Public Shared settingParameterChangesLogger As ILog = Nothing
#End Region

    Private Shared m_objLock As Object = New Object
    Private Shared m_objReadDataLock As Object = New Object
#Region "Functions"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-28</date>
    ''' </author>
    ''' <summary>
    ''' LogAlarmEvent
    ''' </summary>
    ''' <param name="conn"></param>
    ''' <param name="LogUser"></param>
    ''' <param name="Type"></param>
    ''' <param name="Source"></param>
    ''' <param name="Description"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LogAlarmEvent(ByVal conn As System.Data.OleDb.OleDbConnection, ByVal LogUser As String, ByVal Type As String, ByVal Source As String, ByVal Description As String) As Integer
        AVPLib.Log.coreLogger.Info("Enter LogAlarmEvent")
        Dim nResult As Integer = -1

        If (conn Is Nothing) Then
            AVPLib.Log.coreLogger.Info("Leave LogAlarmEvent")
            Return nResult
        End If
        SyncLock m_objLock
            Try
                If (conn.State = System.Data.ConnectionState.Closed) Then
                    conn.Open()
                End If
                Dim sSQLQuery As String = "INSERT INTO LogAlarmEvent (Type, LogUser, LogTime, Source, Description) VALUES(?, ?, ?, ?, ?)"
                Dim cmd As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand(sSQLQuery, conn)

                Dim strTimeNow As String = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt")

                If RobotConfigurationValues.AUTO_EXPORT_DATALOG_TOCSV Then
                    Dim objWrite As System.IO.StreamWriter = Nothing
                    Try
                        Dim strFileNameCSV As String = conn.DataSource.Replace(".mdb", ".csv")
                        If Not System.IO.File.Exists(strFileNameCSV) Then
                            objWrite = New System.IO.StreamWriter(strFileNameCSV, False)
                        Else
                            objWrite = System.IO.File.AppendText(strFileNameCSV)
                        End If

                        If System.IO.File.Exists(strFileNameCSV) Then
                            objWrite.WriteLine(Type & "," _
                                             & LogUser & "," _
                                             & strTimeNow & "," _
                                             & Source & "," _
                                             & Description)
                        Else
                            AVPLib.Log.avpLogger.Error(strFileNameCSV & " doesn't exist")
                        End If
                        objWrite.Close()
                    Catch ex As Exception
                        AVPLib.Log.avpLogger.Error("Create CSV Failed: " & ex.ToString())
                    Finally
                        objWrite = Nothing
                    End Try
                End If

                cmd.Parameters.Add("Type", System.Data.OleDb.OleDbType.VarChar).Value = Type
                cmd.Parameters.Add("LogUser", System.Data.OleDb.OleDbType.VarChar).Value = LogUser
                cmd.Parameters.Add("LogTime", System.Data.OleDb.OleDbType.VarChar).Value = strTimeNow
                cmd.Parameters.Add("Source", System.Data.OleDb.OleDbType.VarChar).Value = Source
                cmd.Parameters.Add("Description", System.Data.OleDb.OleDbType.VarChar).Value = Description
                If (conn.State = ConnectionState.Open) Then
                    nResult = cmd.ExecuteNonQuery()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End SyncLock

        Return nResult

    End Function
    '''<author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' LoadLogAlarmEvent
    ''' </summary>
    ''' <param name="ListConnection"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LoadLogAlarmEvent(ByRef LoadDataGrid_Worker As ComponentModel.BackgroundWorker, ByVal ListConnection As ArrayList, ByVal filter As String) As DataTable
        AVPLib.Log.coreLogger.Info("Enter LoadLogAlarmEvent")
        Dim dtOrginal As New DataTable()
        Try
            For Each Connection As System.Data.OleDb.OleDbConnection In ListConnection
                '2013-06-03 Tin Pham: support cancel data
                If LoadDataGrid_Worker IsNot Nothing AndAlso LoadDataGrid_Worker.CancellationPending Then
                    Exit Try
                End If
                '
                Dim dtCopy As DataTable = LoadLogAlarmEvent(Connection, filter)
                If dtCopy IsNot Nothing Then
                    dtOrginal.Merge(dtCopy, True)
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave LoadLogAlarmEvent")
        Return dtOrginal
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' LoadLogAlarmEvent
    ''' </summary>
    ''' <param name="Connection"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function LoadLogAlarmEvent(ByVal Connection As System.Data.OleDb.OleDbConnection, ByVal filter As String) As DataTable
        AVPLib.Log.coreLogger.Info("Enter LoadLogAlarmEvent")
        Try
            SyncLock m_objReadDataLock
            If Connection.State = System.Data.ConnectionState.Closed Then
                Connection.Open()
            End If
            Dim sSQLQuery As String = "SELECT Type, LogUser, LogTime, Source, Description FROM LogAlarmEvent"
            Dim where As String = " where " + filter
            sSQLQuery = sSQLQuery + where

            Dim da As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sSQLQuery, Connection)
            Dim dt As New DataTable()
            da.Fill(dt)
                Connection.Close()
            AVPLib.Log.coreLogger.Info("Leave LoadLogAlarmEvent")
            Return dt
            End SyncLock

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())

        Finally
            If (Connection IsNot Nothing) Then
                Connection.Close()
            End If
        End Try
        AVPLib.Log.coreLogger.Info("Leave LoadLogAlarmEvent")
        Return Nothing
    End Function
#End Region
#Region "Logger"
    ''' <author>
    '''    	<name> Dat Do Xuan </name>
    '''    	<date> 2009-3-17</date>
    ''' </author>
    ''' <summary>
    ''' init logger variables
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub initialize()
        Try
            ' Logger name is AVP
            avpLogger = LogManager.GetLogger(LOGGER_AVP)
            ' example to use this logger from other module
            'AVPLib.Log.avpLogger.Info("Enter functionx")
            'AVPLib.Log.avpLogger.DebugFormat("wafer count={0}", count)
            'AVPLib.Log.avpLogger.Info("Enter functionx")
            'AVPLib.Log.avpLogger.InfoFormat("wafer count={0}", count)
            'AVPLib.Log.avpLogger.Warn("Enter functionx")
            'AVPLib.Log.avpLogger.WarnFormat("wafer count={0}", count)
            'AVPLib.Log.avpLogger.Error("Enter functionx")
            'AVPLib.Log.avpLogger.ErrorFormat("wafer count={0}", count)
            'AVPLib.Log.avpLogger.Fatal("Enter functionx")
            'AVPLib.Log.avpLogger.FatalFormat("wafer count={0}", count)

            ' Logger name is AVP
            pmLogger = LogManager.GetLogger(LOGGER_PMX)
            ' example to use this logger from other module
            'AVPLib.Log.pmLogger.Info("Enter functionx")
            'AVPLib.Log.pmLogger.DebugFormat("wafer count={0}", count)
            'AVPLib.Log.pmLogger.Info("Enter functionx")
            'AVPLib.Log.pmLogger.InfoFormat("wafer count={0}", count)
            'AVPLib.Log.pmLogger.Warn("Enter functionx")
            'AVPLib.Log.pmLogger.WarnFormat("wafer count={0}", count)
            'AVPLib.Log.pmLogger.Error("Enter functionx")
            'AVPLib.Log.pmLogger.ErrorFormat("wafer count={0}", count)
            'AVPLib.Log.pmLogger.Fatal("Enter functionx")
            'AVPLib.Log.pmLogger.FatalFormat("wafer count={0}", count)

            ' Logger name is AVP.KepServer
            kepServerLogger = LogManager.GetLogger(LOGGER_KEPSERVER)
            ' example to use this logger from other module
            'AVPLib.Log.kepServerLogger.Info("Enter functionx")
            'AVPLib.Log.kepServerLogger.DebugFormat("wafer count={0}", count)
            'AVPLib.Log.kepServerLogger.Info("Enter functionx")
            'AVPLib.Log.kepServerLogger.InfoFormat("wafer count={0}", count)
            'AVPLib.Log.kepServerLogger.Warn("Enter functionx")
            'AVPLib.Log.kepServerLogger.WarnFormat("wafer count={0}", count)
            'AVPLib.Log.kepServerLogger.Error("Enter functionx")
            'AVPLib.Log.kepServerLogger.ErrorFormat("wafer count={0}", count)
            'AVPLib.Log.kepServerLogger.Fatal("Enter functionx")
            'AVPLib.Log.kepServerLogger.FatalFormat("wafer count={0}", count)

            ' Logger name is AVP.TerminalServer
            terminalServerLogger = LogManager.GetLogger(LOGGER_TERMINALSERVR)
            ' example to use this logger from other module
            'AVPLib.Log.kepServerLogger.Info("Enter functionx")
            'AVPLib.Log.kepServerLogger.DebugFormat("wafer count={0}", count)
            'AVPLib.Log.kepServerLogger.Info("Enter functionx")
            'AVPLib.Log.kepServerLogger.InfoFormat("wafer count={0}", count)
            'AVPLib.Log.kepServerLogger.Warn("Enter functionx")
            'AVPLib.Log.kepServerLogger.WarnFormat("wafer count={0}", count)
            'AVPLib.Log.kepServerLogger.Error("Enter functionx")
            'AVPLib.Log.kepServerLogger.ErrorFormat("wafer count={0}", count)
            'AVPLib.Log.kepServerLogger.Fatal("Enter functionx")
            'AVPLib.Log.kepServerLogger.FatalFormat("wafer count={0}", count)

            ' Logger name is AVP.GUI
            guiLogger = LogManager.GetLogger(LOGGER_GUI)
            ' example to use this logger from other module
            'AVPLib.Log.guiLogger.Info("Enter functionx")
            'AVPLib.Log.guiLogger.DebugFormat("wafer count={0}", count)
            'AVPLib.Log.guiLogger.Info("Enter functionx")
            'AVPLib.Log.guiLogger.InfoFormat("wafer count={0}", count)
            'AVPLib.Log.guiLogger.Warn("Enter functionx")
            'AVPLib.Log.guiLogger.WarnFormat("wafer count={0}", count)
            'AVPLib.Log.guiLogger.Error("Enter functionx")
            'AVPLib.Log.guiLogger.ErrorFormat("wafer count={0}", count)
            'AVPLib.Log.guiLogger.Fatal("Enter functionx")
            'AVPLib.Log.guiLogger.FatalFormat("wafer count={0}", count)

            ' Logger name is AVP.Scheduler
            coreLogger = LogManager.GetLogger(LOGGER_CORE)
            ' example to use this logger from other module
            'AVPLib.Log.schedulerLogger.Info("Enter functionx")
            'AVPLib.Log.schedulerLogger.DebugFormat("wafer count={0}", count)
            'AVPLib.Log.schedulerLogger.Info("Enter functionx")
            'AVPLib.Log.schedulerLogger.InfoFormat("wafer count={0}", count)
            'AVPLib.Log.schedulerLogger.Debug("Enter functionx")
            'AVPLib.Log.schedulerLogger.DebugFormat("wafer count={0}", count)
            'AVPLib.Log.schedulerLogger.Error("Enter functionx")
            'AVPLib.Log.schedulerLogger.ErrorFormat("wafer count={0}", count)
            'AVPLib.Log.schedulerLogger.Fatal("Enter functionx")
            'AVPLib.Log.schedulerLogger.FatalFormat("wafer count={0}", count)

            ' Logger name is AVP.DataManagerment
            dataManagementLogger = LogManager.GetLogger(LOGGER_DATAMANAGEMENT)
            ' example to use this logger from other module
            'AVPLib.Log.dataManagementLogger.Info("Enter functionx")
            'AVPLib.Log.dataManagementLogger.DebugFormat("wafer count={0}", count)
            'AVPLib.Log.dataManagementLogger.Info("Enter functionx")
            'AVPLib.Log.dataManagementLogger.InfoFormat("wafer count={0}", count)
            'AVPLib.Log.dataManagementLogger.Warn("Enter functionx")
            'AVPLib.Log.dataManagementLogger.WarnFormat("wafer count={0}", count)
            'AVPLib.Log.dataManagementLogger.Error("Enter functionx")
            'AVPLib.Log.dataManagementLogger.ErrorFormat("wafer count={0}", count)
            'AVPLib.Log.dataManagementLogger.Fatal("Enter functionx")
            'AVPLib.Log.dataManagementLogger.FatalFormat("wafer count={0}", count)

            ' Logger name is AVP.TerminalServer.Robot
            terminalServerRobotLogger = LogManager.GetLogger(LOGGER_ROBOT)
            ' example to use this logger from other module
            'AVPLib.Log.terminalServerRobotLogger.Info("Enter functionx")
            'AVPLib.Log.terminalServerRobotLogger.DebugFormat("wafer count={0}", count)
            'AVPLib.Log.terminalServerRobotLogger.Info("Enter functionx")
            'AVPLib.Log.terminalServerRobotLogger.InfoFormat("wafer count={0}", count)
            'AVPLib.Log.terminalServerRobotLogger.Warn("Enter functionx")
            'AVPLib.Log.terminalServerRobotLogger.WarnFormat("wafer count={0}", count)
            'AVPLib.Log.terminalServerRobotLogger.Error("Enter functionx")
            'AVPLib.Log.terminalServerRobotLogger.ErrorFormat("wafer count={0}", count)
            'AVPLib.Log.terminalServerRobotLogger.Fatal("Enter functionx")
            'AVPLib.Log.terminalServerRobotLogger.FatalFormat("wafer count={0}", count)

            ' Logger name is AVP.TerminalServer.Cryo
            terminalServerCryoLogger = LogManager.GetLogger(LOGGER_CRYO)
            ' example to use this logger from other module
            'AVPLib.Log.teminalServerCryoLogger.Info("Enter functionx")
            'AVPLib.Log.teminalServerCryoLogger.DebugFormat("wafer count={0}", count)
            'AVPLib.Log.teminalServerCryoLogger.Info("Enter functionx")
            'AVPLib.Log.teminalServerCryoLogger.InfoFormat("wafer count={0}", count)
            'AVPLib.Log.teminalServerCryoLogger.Warn("Enter functionx")
            'AVPLib.Log.teminalServerCryoLogger.WarnFormat("wafer count={0}", count)
            'AVPLib.Log.teminalServerCryoLogger.Error("Enter functionx")
            'AVPLib.Log.teminalServerCryoLogger.ErrorFormat("wafer count={0}", count)
            'AVPLib.Log.teminalServerCryoLogger.Fatal("Enter functionx")
            'AVPLib.Log.teminalServerCryoLogger.FatalFormat("wafer count={0}", count)

            ' Logger name is AVP.TerminalServer.Chamber
            terminalServerChamberLogger = LogManager.GetLogger(LOGGER_CHAMBER)
            ' example to use this logger from other module
            'AVPLib.Log.teminalServerChamberLogger.Info("Enter functionx")
            'AVPLib.Log.teminalServerChamberLogger.DebugFormat("wafer count={0}", count)
            'AVPLib.Log.teminalServerChamberLogger.Info("Enter functionx")
            'AVPLib.Log.teminalServerChamberLogger.InfoFormat("wafer count={0}", count)
            'AVPLib.Log.teminalServerChamberLogger.Warn("Enter functionx")
            'AVPLib.Log.teminalServerChamberLogger.WarnFormat("wafer count={0}", count)
            'AVPLib.Log.teminalServerChamberLogger.Error("Enter functionx")
            'AVPLib.Log.teminalServerChamberLogger.ErrorFormat("wafer count={0}", count)
            'AVPLib.Log.teminalServerChamberLogger.Fatal("Enter functionx")
            'AVPLib.Log.teminalServerChamberLogger.FatalFormat("wafer count={0}", count)

            ' Logger name is AVP.TerminalServer.Chamber
            schedulerLogger = LogManager.GetLogger(LOGGER_SCHEDULER)
            ' example to use this logger from other module
            'AVPLib.Log.schedulerLogger.Info("Enter functionx")
            'AVPLib.Log.schedulerLogger.DebugFormat("wafer count={0}", count)
            'AVPLib.Log.schedulerLogger.Info("Enter functionx")
            'AVPLib.Log.schedulerLogger.InfoFormat("wafer count={0}", count)
            'AVPLib.Log.schedulerLogger.Debug("Enter functionx")
            'AVPLib.Log.schedulerLogger.DebugFormat("wafer count={0}", count)
            'AVPLib.Log.schedulerLogger.Error("Enter functionx")
            'AVPLib.Log.schedulerLogger.ErrorFormat("wafer count={0}", count)
            'AVPLib.Log.schedulerLogger.Fatal("Enter functionx")
            'AVPLib.Log.schedulerLogger.FatalFormat("wafer count={0}", count)

            ' Logger name is AVP.sequence
            seqLogger = LogManager.GetLogger(LOGGER_SEQUENCE)
            ' example to use this logger from other module
            'AVPLib.Log.seqLogger.Info("Enter functionx")
            'AVPLib.Log.seqLogger.DebugFormat("wafer count={0}", count)
            'AVPLib.Log.seqLogger.Info("Enter functionx")
            'AVPLib.Log.seqLogger.InfoFormat("wafer count={0}", count)
            'AVPLib.Log.seqLogger.Warn("Enter functionx")
            'AVPLib.Log.seqLogger.WarnFormat("wafer count={0}", count)
            'AVPLib.Log.seqLogger.Error("Enter functionx")
            'AVPLib.Log.seqLogger.ErrorFormat("wafer count={0}", count)
            'AVPLib.Log.seqLogger.Fatal("Enter functionx")
            'AVPLib.Log.seqLogger.FatalFormat("wafer count={0}", count)
            'REM NOT DELETE IT
            'If (System.IO.File.Exists(ContainerDAO.FPath_LotDatalog & "\(null).txt")) Then
            '    System.IO.File.Delete(ContainerDAO.FPath_LotDatalog & "\(null).txt")
            'End If
            settingParameterChangesLogger = LogManager.GetLogger(LOGGER_PARAMETER_CHANGE_FROM_SETTING)
        Catch ex As Exception
            ' need to debug if the system crash in the logger side
        End Try
    End Sub
    'REM NOT DELETE IT
    'Public Shared Sub LLALotDatalogStart(ByVal sLotName As String)
    '    Dim newFileName As String = DateTime.Now.ToString("yyyy.MM.dd_HH.mm.ss") & "_" & sLotName
    '    log4net.GlobalContext.Properties("LLALogFileName") = newFileName
    '    LLALotdatalog = LogManager.GetLogger(LOGGER_LLALOTDATALOG)
    '    Dim repo As log4net.Repository.ILoggerRepository = LogManager.GetRepository()
    '    For Each appender As log4net.Appender.IAppender In repo.GetAppenders
    '        If (appender.Name.CompareTo("LLALotAppender") = 0) Then
    '            Dim newAppender As log4net.Appender.RollingFileAppender = appender
    '            newAppender.File = "DataFiles\LotDatalog\" & newFileName & ".txt"
    '            newAppender.ActivateOptions()
    '        End If
    '    Next
    'End Sub
    'Public Shared Sub LLBLotDatalogStart(ByVal sLotName As String)
    '    Dim newFileName As String = DateTime.Now.ToString("yyyy.MM.dd_HH.mm.ss") & "_" & sLotName
    '    log4net.GlobalContext.Properties("LLBLogFileName") = newFileName
    '    LLBLotdatalog = LogManager.GetLogger(LOGGER_LLBLOTDATALOG)
    '    Dim repo As log4net.Repository.ILoggerRepository = LogManager.GetRepository()
    '    For Each appender As log4net.Appender.IAppender In repo.GetAppenders

    '        If (appender.Name.CompareTo("LLBLotAppender") = 0) Then
    '            Dim newAppender As log4net.Appender.RollingFileAppender = appender
    '            newAppender.File = "DataFiles\LotDatalog\" & newFileName & ".txt"
    '            newAppender.ActivateOptions()
    '        End If
    '    Next
    'End Sub
    'Public Shared Sub CleanUpEmptyFile()
    '    Try
    '        Dim di As New IO.DirectoryInfo(ContainerDAO.FPath_LotDatalog)
    '        Dim aryFi As IO.FileInfo() = di.GetFiles("*.txt")

    '        For Each Fi As IO.FileInfo In aryFi
    '            If (Fi.Length = 0) Then
    '                System.IO.File.Delete(Fi.FullName)
    '            End If
    '        Next

    '    Catch
    '    End Try
    'End Sub
    'Public Shared Sub AddLotDatalog(ByVal sToolName As String, ByVal logtype As LogType, ByVal info As String, ByVal isAutotransfer As Boolean)
    '    If (isAutotransfer = False) Then
    '        Exit Sub
    '    End If

    '    Select Case logtype
    '        Case logtype.Info
    '            If (sToolName = ConstEnum.LoadLockA_STR) Then
    '                AVPLib.Log.LLALotdatalog.Info(info)
    '            Else
    '                AVPLib.Log.LLBLotdatalog.Info(info)
    '            End If
    '            Exit Sub
    '        Case logtype.Debug
    '            If (sToolName = ConstEnum.LoadLockA_STR) Then
    '                AVPLib.Log.LLALotdatalog.Debug(info)
    '            Else
    '                AVPLib.Log.LLBLotdatalog.Debug(info)
    '            End If
    '            Exit Sub
    '        Case logtype.Error
    '            If (sToolName = ConstEnum.LoadLockA_STR) Then
    '                AVPLib.Log.LLALotdatalog.Error(info)
    '            Else
    '                AVPLib.Log.LLBLotdatalog.Error(info)
    '            End If
    '            Exit Sub
    '        Case logtype.Warning
    '            If (sToolName = ConstEnum.LoadLockA_STR) Then
    '                AVPLib.Log.LLALotdatalog.Warn(info)
    '            Else
    '                AVPLib.Log.LLBLotdatalog.Warn(info)
    '            End If
    '            Exit Sub
    '        Case Else
    '            Exit Sub
    '    End Select
    'End Sub
    ''' <author>
    '''    	<name> Dat Do Xuan </name>
    '''    	<date> 2009-3-17</date>
    ''' </author>
    ''' <summary>
    ''' init logger variables
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub shutdown()
        Try
            LogManager.Shutdown()
        Catch ex As Exception
            ' need to debug if the system crash in the logger side
        End Try
    End Sub
#End Region
End Class
