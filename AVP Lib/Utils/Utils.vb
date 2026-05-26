Imports AVPLib.DataManagerment
Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.Text
Imports System.Collections
Imports AVPLib.ConstEnum
Imports System.Threading
Imports System.Collections.Generic

''' <author>
'''    	<name> Do Xuan Dat </name>
'''    	<date> 2011-03-09</date>
''' </author>
''' <summary>
''' This class is used to check the file exist.
''' If the file does not exist on the network, it will take a very long time.
''' we will give it a very short time before exit.
''' make sure that do not have many thread call this at the same time
''' </summary>
''' <remarks></remarks>
Public Class FileExistsHelper
    Public Shared Function FileExists( _
        ByVal file As String, _
        ByVal timeOut As Integer) As Boolean
        SyncLock m_LockObj

            m_File = file
            m_Exists = False
            m_Thread = New System.Threading.Thread(AddressOf CallFileExists)
            m_Thread.Start()
            m_Thread.Join(timeOut)
            m_Thread.Abort()
        End SyncLock

        Return m_Exists
    End Function

    Private Shared Sub CallFileExists()
        m_Exists = System.IO.File.Exists(m_File)
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-07-12 </date>
    ''' </author>
    ''' <summary>
    ''' Check folder Exists.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function FolderExists( _
       ByVal folder As String, _
       ByVal timeOut As Integer) As Boolean
        SyncLock m_LockObj

            m_File = folder
            m_Exists = False
            m_Thread = New System.Threading.Thread(AddressOf CallFolderExists)
            m_Thread.Start()
            m_Thread.Join(timeOut)
            m_Thread.Abort()
        End SyncLock

        Return m_Exists
    End Function

    Private Shared Sub CallFolderExists()
        m_Exists = System.IO.Directory.Exists(m_File)
    End Sub

    Private Shared m_Thread As System.Threading.Thread
    Private Shared m_File As String = String.Empty
    Private Shared m_Exists As Boolean = False
    Private Shared m_LockObj As New Object

End Class

Public Class Utils
    Private Shared m_lstRunningPM As New List(Of String)

    Public Shared Sub SendSplitValveStatus_ToPM(ByVal strChamberName As String, ByVal splitValveStatus As Equipment.WorkingStatuses)
        Try
            Dim objChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(strChamberName)
            If objChamber IsNot Nothing AndAlso objChamber.ConnectionStatus = Equipment.WorkingStatuses.On Then
                Dim PMController As Business.ChamberController = Business.ControllerManager.GetController(strChamberName)
                Dim strStatusSlitValve As String = ConfigurationValues.DEVICE_STATUS_STOPPED 'unknow

                If splitValveStatus = Equipment.WorkingStatuses.On Then
                    strStatusSlitValve = ConfigurationValues.DEVICE_STATUS_OPEN
                ElseIf splitValveStatus = Equipment.WorkingStatuses.Off Then
                    strStatusSlitValve = ConfigurationValues.DEVICE_STATUS_CLOSED
                End If

                PMController.SetIsoValveStatus(strStatusSlitValve)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Tinh Le</author>
    ''' <date>2023-04-01</date>
    ''' <summary>
    ''' Gets electric value from string.
    ''' </summary>
    Public Shared Function GetElectricValue(ByVal text As String, ByRef value As Double) As Boolean
        Try
            Dim pattern As String = "([-+]?\d+\.?\d*)\S*"

            Dim m As Match = Regex.Match(text, pattern)
            If m.Success Then
                If Double.TryParse(m.Groups(1).Value, value) Then
                    Return True
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function
    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-12-28 </date>
    ''' </author>
    ''' <summary>
    ''' GetChamberSlitValveStatus
    ''' </summary>
    Public Shared Function GetChamberSlitValveStatus(ByVal srcChamberName As String) As Equipment.WorkingStatuses
        Dim TM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)

        If (srcChamberName = Equipments.Chamber1.ToString()) Then
            Return TM.SplitValve2Status
        ElseIf (srcChamberName = Equipments.Chamber2.ToString()) Then
            Return TM.SplitValve3Status
        ElseIf (srcChamberName = Equipments.Chamber3.ToString()) Then
            Return TM.SplitValve4Status
        End If

        Return Equipment.WorkingStatuses.Unknown
    End Function

    ''Truc Le: replace first occurence of string in text 
    Public Shared Function ReplaceFirstOccurence(ByVal text As String, ByVal str_search As String, ByVal str_replace As String) As String
        Dim pos As Integer = text.IndexOf(str_search)
        Try
            If pos < 0 Then
                Return text
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return text.Substring(0, pos) & str_replace & text.Substring(pos + str_search.Length)
    End Function

    Public Shared Function GetWaferIdsFromChambers(ByVal IsCheckLLA As Boolean) As List(Of String)
        Dim listOfWaferIds As New List(Of String)()

        Dim objChamber1 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
        If objChamber1 IsNot Nothing Then
            For index As Integer = 1 To objChamber1.WaferCapacity
                If objChamber1.GetWaferInfo(index) IsNot Nothing Then
                    listOfWaferIds.Add(objChamber1.GetWaferInfo(index).WaferID)
                End If
            Next
        End If

        Dim objChamber2 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString())
        If objChamber2 IsNot Nothing Then
            For index As Integer = 1 To objChamber2.WaferCapacity
                If objChamber2.GetWaferInfo(index) IsNot Nothing Then
                    listOfWaferIds.Add(objChamber2.GetWaferInfo(index).WaferID)
                End If
            Next
        End If

        Dim objChamber3 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString())
        If objChamber3 IsNot Nothing Then
            For index As Integer = 1 To objChamber3.WaferCapacity
                If objChamber3.GetWaferInfo(index) IsNot Nothing Then
                    listOfWaferIds.Add(objChamber3.GetWaferInfo(index).WaferID)
                End If
            Next
        End If

        Dim objAligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
        If objAligner IsNot Nothing Then
            If objAligner.GetWaferInfo() IsNot Nothing Then
                listOfWaferIds.Add(objAligner.GetWaferInfo().WaferID)
            End If
        End If

        Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
        If objRobot IsNot Nothing Then
            If objRobot.GetWaferInfo() IsNot Nothing Then
                listOfWaferIds.Add(objRobot.GetWaferInfo().WaferID)
            End If
        End If
        ''check Wafer in LL
        Dim objLoadLock As DataManagerment.LLElevator = Nothing
        objLoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())

        If objLoadLock IsNot Nothing Then
            With objLoadLock
                If .ListOfWaferInfo.Length > 0 Then
                    For Each wafer As AVPWaferInfo In .ListOfWaferInfo
                        If wafer IsNot Nothing Then
                            listOfWaferIds.Add(wafer.WaferID)
                        End If
                    Next
                End If
            End With
        End If

        Return listOfWaferIds
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-06-25 </date>
    ''' </author>
    ''' <summary>
    ''' GetWaferIDAndChambers
    ''' </summary>
    Public Shared Function GetWaferIDAndChambers() As Hashtable
        Dim listOfWaferIds As New Hashtable

        Try
            Dim objChamber1 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
            If objChamber1 IsNot Nothing Then
                For index As Integer = 1 To objChamber1.WaferCapacity()
                    If objChamber1.GetWaferInfo(index) IsNot Nothing Then
                        listOfWaferIds.Add(objChamber1.GetWaferInfo(index).WaferID, objChamber1)
                    End If
                Next
            End If

            Dim objChamber2 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString())
            If objChamber2 IsNot Nothing Then
                For index As Integer = 1 To objChamber2.WaferCapacity()
                    If objChamber2.GetWaferInfo(index) IsNot Nothing Then
                        listOfWaferIds.Add(objChamber2.GetWaferInfo(index).WaferID, objChamber2)
                    End If
                Next
            End If

            Dim objChamber3 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString())
            If objChamber3 IsNot Nothing Then
                For index As Integer = 1 To objChamber3.WaferCapacity()
                    If objChamber3.GetWaferInfo(index) IsNot Nothing Then
                        listOfWaferIds.Add(objChamber3.GetWaferInfo(index).WaferID, objChamber3)
                    End If
                Next
            End If

            Dim objAligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
            If objAligner IsNot Nothing Then
                If objAligner.GetWaferInfo() IsNot Nothing Then
                    listOfWaferIds.Add(objAligner.GetWaferInfo().WaferID, objAligner)
                End If
            End If

            Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
            If objRobot IsNot Nothing Then
                If objRobot.GetWaferInfo() IsNot Nothing Then
                    listOfWaferIds.Add(objRobot.GetWaferInfo().WaferID, objRobot)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return listOfWaferIds
    End Function

    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-11-04</date>
    ''' </author>
    ''' <summary>
    ''' Gemerate the Wafer ID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GenerateWaferID(ByVal p_islot As Integer, ByVal p_strEquipmentID As String) As String

        Dim strSlotID As String = Format(p_islot, "00")
        Dim strWaferID As String = strSlotID

        If p_strEquipmentID = ConstEnum.Equipments.LoadLockA.ToString() Or p_strEquipmentID = ConstEnum.Equipments.LLAElevator.ToString() Then
            strWaferID = "A" & strSlotID
        End If
        Return strWaferID
    End Function

    Public Shared Function GetGEMWaferID(ByVal AVPWaferID As String) As String
        Dim result As String = String.Empty
        Try

            Dim objLLElevator As LLElevator = Nothing
            If AVPWaferID.Contains("A") Then
                objLLElevator = EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
            End If
            If objLLElevator Is Nothing Then
                Return result
            End If
            If objLLElevator.MappingGEMWaferID.ContainsKey(AVPWaferID) Then
                result = objLLElevator.MappingGEMWaferID.Item(AVPWaferID)
            End If

            If String.IsNullOrEmpty(result) Then
                result = AVPWaferID
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return result
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2016-06-17 </date>
    ''' </author>
    ''' <summary>
    ''' Gets LotID of LoadLock which contains the wafer.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetLotIDFromWafer(ByVal waferID As String)
        Dim lotID As String = String.Empty
        Try
            If Not String.IsNullOrEmpty(waferID) Then
                Dim objLL As LoadLock = Nothing
                If waferID.StartsWith("A") Then
                    objLL = DataManagerment.EquipmentManager.GetEquipment("LoadLockA")
                ElseIf waferID.StartsWith("B") Then
                    objLL = DataManagerment.EquipmentManager.GetEquipment("LoadLockB")
                End If
                If objLL IsNot Nothing Then
                    lotID = objLL.LotID
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return lotID
    End Function


    Public Shared Sub Applied_Host_WaferID()
        Try
            Dim MaxChamberCXX5 As Integer = 3
            'Dim MaxChamberCXX6 As Integer = 4
            'Dim MaxChamberCXX7 As Integer = 5
            'Dim MaxChamberCXX8 As Integer = 6
            Dim eq As DataManagerment.Equipment = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
            Dim strWaferID As String = String.Empty
            ''Update WaferID for TM
            If eq IsNot Nothing AndAlso eq.GetWaferInfo() IsNot Nothing Then
                strWaferID = GetGEMWaferID(eq.GetWaferInfo().WaferID)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "WaferOnArm", VALUELib.ValueType.A, strWaferID)
            End If

            ''Update WaferID for each Chamber
            Dim i As Integer = MaxChamberCXX5
            'If RobotConfigurationValues.INSTALLED_CX8 Then
            '    i = MaxChamberCXX8
            'ElseIf RobotConfigurationValues.INSTALLED_CX7 Then
            '    i = MaxChamberCXX7
            'End If
            While (i > 0)
                eq = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Chamber & i.ToString())
                If eq IsNot Nothing AndAlso eq.GetWaferInfo() IsNot Nothing Then
                    strWaferID = GetGEMWaferID(eq.GetWaferInfo().WaferID)
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.Chamber & i.ToString(), EMSERVICELib.VarType.SV, "ProcessWaferID", VALUELib.ValueType.A, strWaferID)
                End If
                i -= 1
            End While
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub ResetWaferInOutLL(ByVal LoadLockName As String)
        Try
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(LoadLockName, EMSERVICELib.VarType.SV, "LastWaferIn", VALUELib.ValueType.A, String.Empty)
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(LoadLockName, EMSERVICELib.VarType.SV, "LastWaferOut", VALUELib.ValueType.A, String.Empty)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub ResetRelatedRecipeInfo()
        Try
            'Reset Aligner Recipe
            Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "Aligner.Recipe", VALUELib.ValueType.A, String.Empty)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#Region "Class Constants & Variables"
    Private Shared fileDataOriginal As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\AlarmEvent.mdb"
    Public Shared fileDataLog As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\Archived\LogAlarmAndEvent"
    Public Shared fileInternalLog As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\Archived\LogError"
    Public Shared fileLotDataLog As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "DataFiles\LotDatalog"
#End Region

#Region "Create Database"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' getDatabase
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getDatabase() As String
        Dim dt As DateTime = DateTime.Today
        Dim filePath As String = fileDataLog + "\" + dt.ToString("MM_dd_yyyy") + ".mdb"
        Try
            If System.IO.File.Exists(filePath) Then
                Return filePath
            Else
                Utils.CreateDirectory(Utils.fileDataLog & "\")
            End If

            'Dim count As Integer = System.IO.Directory.GetFiles(fileDataLog, "*.mdb").Length
            'If count >= AVPLib.ConstEnum.NUM_DAY_DELETE_OLD_FILE_LOG_ERROR Then
            '    removeFileAccessOldLeast()
            'End If

            ''#05/18/2011 
            ''#Delete log error file after 1 week.
            ''#Begin fix
            'Dim lstFiles = System.IO.Directory.GetFiles(fileInternalLog, "*.*")
            'For Each fileItem As String In lstFiles
            '    Dim fileCreateDate As DateTime = IO.File.GetCreationTime(fileItem)
            '    Dim TimeSpan As TimeSpan = dt - fileCreateDate
            '    If TimeSpan.Days > AVPLib.ConstEnum.NUM_DAY_DELETE_OLD_FILE_LOG_ERROR Then
            '        System.IO.File.Delete(fileItem)
            '    End If
            'Next
#If AVP_PLATFORM = "CX" Then
            '#'#08/16/2011 
            '#Delete log wafer run after 1 week.
            '#Begin fix
            Dim lstDictionaryLogDataLot = System.IO.Directory.GetDirectories(fileLotDataLog)
            For Each folderItem As String In lstDictionaryLogDataLot
                If Not folderItem.Contains(".svn") Then
                    Dim dicCreateDate As DateTime = IO.Directory.GetCreationTime(folderItem)
                    Dim TimeSpan As TimeSpan = dt - dicCreateDate
                    If TimeSpan.Days > AVPLib.ConstEnum.NUM_DAY_DELETE_OLD_FILE_LOG_DATA_LOT Then
                        System.IO.Directory.Delete(folderItem, True)
                    End If
                End If
            Next
            '#End fix
#End If

            System.IO.File.Copy(fileDataOriginal, filePath)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return filePath
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' getListDatabase
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getListDatabase() As String()
        Try
            Dim ListstrDatabase As String() = System.IO.Directory.GetFiles(fileDataLog, "*.mdb")
            Dim ListDatabase As New ArrayList()
            For Each Database As String In ListstrDatabase
                ListDatabase.Add(Database)
            Next

            ListDatabase.Sort(New ReverserDateString())
            Return ListDatabase.ToArray(GetType(String))
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' removeFileAccessOldLeast
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub removeFileAccessOldLeast()
        Try
            Dim Files As String() = Utils.getListDatabase()
            '  Dim iLeng As Integer = 0
            For i As Integer = AVPLib.ConstEnum.NUM_DAY_DELETE_OLD_FILE_LOG_ERROR - 1 To Files.Length - 1
                System.IO.File.Delete(Files(i))
                ' index += 1
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Chamber"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-06</date>
    ''' </author>
    ''' <summary>
    ''' Check All Sensor are Off
    ''' </summary>
    ''' <param name="m_DBChamber"></param>
    ''' <param name="ChamberName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckAllSensorOff() As Boolean
        Try

            If RobotConfigurationValues.ROBOT_SENSOR_INSTALLED = False Or (RobotConfigurationValues.ROBOT_SENSOR_INSTALLED And RobotConfigurationValues.DISABLE_SENSOR_CHECKING) Then
                Return True
            End If

            Dim blnResult As Boolean = False
            Dim objChamber1 As DataManagerment.Chamber = CType(DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString()), DataManagerment.Chamber)
            Dim objChamber2 As DataManagerment.Chamber = CType(DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString()), DataManagerment.Chamber)
            Dim objChamber3 As DataManagerment.Chamber = CType(DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString()), DataManagerment.Chamber)
            Dim objLoadLockA As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())
            Dim TransferModuleObj As DataManagerment.CassettesModule = Nothing

            TransferModuleObj = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
            ' Check Condition.
            Dim IsLLASensorOff As Boolean = True
            Dim IsPM1SensorOff As Boolean = True
            Dim IsPM2SensorOff As Boolean = True
            Dim IsPM3SensorOff As Boolean = True

            'when LLA is not installed -> we just care sensor for Aligner
            If objLoadLockA Is Nothing Then
                ''if Aligner at LLA Station
                If RobotConfigurationValues.ALIGNER_AT_STATION = RobotConfigurationValues.LLA_STATION_NO Then
                    IsLLASensorOff = (TransferModuleObj.SensorLLAStatus = DataManagerment.Equipment.WorkingStatuses.Off)
                Else ''IF NOT -> RETURN TRUE: SENSOR IS OFF
                    IsLLASensorOff = True
                End If
            End If

            IsPM1SensorOff = _
               IIf(objChamber1 Is Nothing, True, TransferModuleObj.SensorPM1Status = DataManagerment.Equipment.WorkingStatuses.Off)
            IsPM2SensorOff = _
               IIf(objChamber2 Is Nothing, True, TransferModuleObj.SensorPM2Status = DataManagerment.Equipment.WorkingStatuses.Off)
            IsPM3SensorOff = _
                IIf(objChamber3 Is Nothing, True, TransferModuleObj.SensorPM3Status = DataManagerment.Equipment.WorkingStatuses.Off)

            If IsPM1SensorOff And IsPM2SensorOff And IsPM3SensorOff And IsLLASensorOff Then
                blnResult = True
            End If
            Return blnResult
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Chamber
    ''' </summary>
    ''' <param name="m_DBChamber"></param>
    ''' <param name="ChamberName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Chamber(ByVal m_DBChamber As DataTable, ByVal ChamberName As String) As DBChamber
        Try
            Dim ChamberNameActive As String = ContainerData.GetRecipe(ChamberName).ChamberNameActive
            Dim DBChamber As DBChamber = ContainerData.Chamber(ChamberName, ChamberNameActive)

            Dim recipeChamber As DBChamber = New DBChamber()
            recipeChamber.ChamberName = ChamberName
            recipeChamber.ChamberType = DBChamber.ChamberType
            recipeChamber.ListGroupParameters = DBChamber.ListGroupParameters
            recipeChamber.ListChamberSteps = ListChamberSteps(m_DBChamber)
            Return recipeChamber
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' ListChamberSteps
    ''' </summary>
    ''' <param name="m_DBChamber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function ListChamberSteps(ByVal dtRecipeChamber As DataTable) As ArrayList
        Try
            Dim ListChamberStep As New ArrayList()

            Dim StepNo As Integer = dtRecipeChamber.Columns.Count - Total_Columns
            For s As Integer = 0 To StepNo - 1
                Dim ChamberStep As New DBChamberStep()
                ChamberStep.SeqNo = s + 1
                Dim ListGroupParameterValue As New ArrayList()
                Dim GroupParameterValue As DBGroupParameterValue = Nothing
                Dim ListParameterValue As ArrayList = Nothing
                For Each dr As DataRow In dtRecipeChamber.Rows
                    Dim ParameterName As String = dr("ParameterName").ToString()
                    Dim DefaultValue As String = dr("DefaultValue").ToString()
                    Dim StepValue As String = dr("Step" + (s + 1).ToString()).ToString()
                    If StepValue.Length = 0 And DefaultValue.Length = 0 AndAlso dr("BelongToGroup").ToString().Length = 0 Then 'Group
                        If GroupParameterValue IsNot Nothing Then
                            GroupParameterValue.ListParameterValues = ListParameterValue
                            ListGroupParameterValue.Add(GroupParameterValue)
                        End If
                        GroupParameterValue = New DBGroupParameterValue()
                        GroupParameterValue.GroupCode = ParameterName
                        ListParameterValue = New ArrayList()
                    Else 'value
                        If ListParameterValue Is Nothing Then 'No Group
                            GroupParameterValue = New DBGroupParameterValue()
                            GroupParameterValue.GroupCode = ""
                            ListParameterValue = New ArrayList()
                        End If
                        ListParameterValue.Add(New DBParameterValue(ParameterName, StepValue))
                    End If
                Next
                GroupParameterValue.ListParameterValues = ListParameterValue
                ListGroupParameterValue.Add(GroupParameterValue) 'Add Last Group

                ChamberStep.ListGroupParameterValues = ListGroupParameterValue
                ListChamberStep.Add(ChamberStep)
            Next
            Return ListChamberStep
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    '#02/25/2011
    '#'Change from 7 to 8 (Add more one column Unit show to show unit of value.)(Tin Pham add more one column ParameterCalculate)
    Const Total_Columns As Integer = 9
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get DataTable of ChamberDB
    ''' </summary>
    ''' <param name="m_Chamber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ChamberDB(ByVal chamberRecipe As DBChamber, ByVal ChberPVDType As PVDType) As DataTable
        Try
            '''should be modified here
            Dim dt As New DataTable()
            Dim drPulse As DataRow = Nothing ''hold Pulse Row to reorder
            Dim drPulseFrequency As DataRow = Nothing ''hold Pulse Row to reorder
            Dim drPulseDuty As DataRow = Nothing ''hold Pulse Row to reorder
            Dim drMagnetron As DataRow = Nothing ''hold MagnatronState Row to reorder
            'Dim drRampTime As DataRow = Nothing ''hold Pulse Row to reorder
            'Begin Add Columns
            Utils.AddDataColumns(dt, "Parameters", GetType(String), "Parameters")
            Utils.AddDataColumns(dt, "ParameterName", GetType(String), "ParameterName")
            Utils.AddDataColumns(dt, "ParameterMax", GetType(Double), "ParameterMax")
            Utils.AddDataColumns(dt, "ParameterMin", GetType(Double), "ParameterMin")
            Utils.AddDataColumns(dt, "DefaultValue", GetType(String), "DefaultValue")
            Utils.AddDataColumns(dt, "BelongToGroup", GetType(String), "BelongToGroup")
            Utils.AddDataColumns(dt, "Unit", GetType(String), "Unit")
            Utils.AddDataColumns(dt, "UnitShow", GetType(String), "UnitShow")
            Utils.AddDataColumns(dt, "ParameterCalculate", GetType(String), "ParameterCalculate")

            Dim ListChamberSteps As ArrayList = chamberRecipe.ListChamberSteps
            If ListChamberSteps.Count > 0 Then
                ListChamberSteps.Sort(New ReverserDBChamberStep())

                For i As Integer = 1 To ListChamberSteps.Count
                    Utils.AddDataColumns(dt, "Step" + i.ToString(), GetType(String), "Step-" + i.ToString())
                Next
            Else
                Utils.AddDataColumns(dt, "Step1", GetType(String), "Step-1")
            End If
            'End Add Columns

            'Begin Add Data
            Dim ListGroupParameters As ArrayList = chamberRecipe.ListGroupParameters

            For Each ParameterGroup As DBParameterGroup In ListGroupParameters
                Dim drGroup As DataRow = Nothing
                If ParameterGroup.IsGroup Then
                    drGroup = dt.NewRow()
                    drGroup("Parameters") = ParameterGroup.GroupName
                    drGroup("ParameterName") = ParameterGroup.GroupCode
                    drGroup("DefaultValue") = String.Empty
                    drGroup("BelongToGroup") = String.Empty
                    drGroup("Unit") = String.Empty
                    drGroup("UnitShow") = String.Empty
                    drGroup("ParameterCalculate") = String.Empty
                    dt.Rows.Add(drGroup)
                End If

                Dim ListParameter As ArrayList = ParameterGroup.Parameters
                ListParameter.Sort(New ReverserDBParameter())

                For Each Parameter As DBParameter In ListParameter
                    If Parameter.ShowUI Then
                        Dim drDetail As DataRow = dt.NewRow()
                        drDetail("Parameters") = Utils.GetParameterName(Parameter.Description)
                        drDetail("ParameterName") = Parameter.Name
                        drDetail("ParameterMax") = Parameter.Max
                        drDetail("ParameterMin") = Parameter.Min
                        drDetail("DefaultValue") = Parameter.DefaultValue
                        drDetail("BelongToGroup") = IIf(drGroup Is Nothing, String.Empty, ParameterGroup.GroupCode)
                        drDetail("Unit") = Parameter.Unit
                        drDetail("UnitShow") = Parameter.UnitShow
                        drDetail("ParameterCalculate") = String.Empty
                        Dim Index As Integer = 1
                        If ListChamberSteps.Count > 0 Then
                            For Each ChamberStep As DBChamberStep In ListChamberSteps
                                Dim Value As String = GetValue(ChamberStep, ParameterGroup.GroupCode, Parameter.Name)
                                If String.IsNullOrEmpty(Value) Then
                                    drDetail("Step" + Index.ToString()) = Parameter.DefaultValue
                                Else
                                    drDetail("Step" + Index.ToString()) = Value
                                End If
                                Index += 1
                            Next
                        Else
                            drDetail("Step" + Index.ToString()) = Parameter.DefaultValue
                        End If
                        If ChberPVDType = PVDType.DCPVD Then
                            If (Parameter.Name = "Pulse") Then
                                drPulse = drDetail
                            ElseIf (Parameter.Name = "PulseFrequency") Then
                                drPulseFrequency = drDetail
                            ElseIf (Parameter.Name = "PulseWidth") Then
                                drPulseDuty = drDetail
                                '    ElseIf (Parameter.Name = "RampTime") Then
                                '        drRampTime = drDetail
                            Else
                                dt.Rows.Add(drDetail)
                            End If
                        Else
                            dt.Rows.Add(drDetail)
                        End If

                    End If
                Next
            Next
            'End Add Data
            If ChberPVDType = PVDType.DCPVD Then ''reorder
                Dim index As Integer = 0
                For Each row As DataRow In dt.Rows
                    If row("ParameterName").ToString().Contains("TargetPower") Then
                        If drPulse IsNot Nothing Then
                            index += 1
                            dt.Rows.InsertAt(drPulse, index)
                        End If
                        If drPulseFrequency IsNot Nothing Then
                            index += 1
                            dt.Rows.InsertAt(drPulseFrequency, index)
                        End If
                        If drPulseDuty IsNot Nothing Then
                            index += 1
                            dt.Rows.InsertAt(drPulseDuty, index)
                        End If
                        Exit For
                    Else
                        index += 1
                    End If
                Next
            End If

            Return dt
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get Value that support Get step value exactly 
    ''' </summary>
    ''' <param name="ChamberStep"></param>
    ''' <param name="ParameterName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetValue(ByVal ChamberStep As DBChamberStep, ByVal GroupCode As String, ByVal ParameterName As String) As String
        Try
            For Each GroupParameterValue As DBGroupParameterValue In ChamberStep.ListGroupParameterValues
                For Each ParameterValue As DBParameterValue In GroupParameterValue.ListParameterValues
                    If ParameterValue.Name = ParameterName AndAlso GroupParameterValue.GroupCode = GroupCode Then
                        Return ParameterValue.Value
                    End If
                Next
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return ""
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' IsHiddenColumn
    ''' </summary>
    ''' <param name="ColumnName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsHiddenColumn(ByVal ColumnName As String) As Boolean
        Try
            Dim Columns As String() = {"ParameterName", "ParameterMax", "ParameterMin", "DefaultValue", "BelongToGroup", "Unit", "UnitShow", "ParameterCalculate"}
            For Each Column As String In Columns
                If ColumnName = Column Then
                    Return True
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return False
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' AddDataColumns
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="ColumnName"></param>
    ''' <param name="ColumnType"></param>
    ''' <param name="ColumnCaption"></param>
    ''' <remarks></remarks>
    Public Shared Sub AddDataColumns(ByVal dt As DataTable, ByVal ColumnName As String, ByVal ColumnType As Type, ByVal ColumnCaption As String)
        Try
            If dt.Columns(ColumnName) Is Nothing Then
                Dim Columns As DataColumn = New DataColumn(ColumnName, ColumnType)
                Columns.Caption = ColumnCaption
                dt.Columns.Add(Columns)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' GetParameterName
    ''' </summary>
    ''' <param name="ParameterName"></param>
    ''' <param name="ParameterUnit"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetParameterName(ByVal ParameterName As String) As String
        Try
            'If ParameterUnit.Length = 0 Then
            '    Return ParameterName
            'End If
            Return ParameterName '+ "(" + ParameterUnit + ")"
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return ""
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get List Values
    ''' </summary>
    ''' <param name="ChamberName"></param>
    ''' <param name="ParameterName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetListOfDisplayItem(ByVal ChamberName As String, ByVal ParameterName As String) As List(Of KeyValuePair(Of String, String))
        Try

            Dim ChamberNameActive As String = ContainerData.GetRecipe(ChamberName).ChamberNameActive
            Dim m_Chamber As DBChamber = ContainerData.Chamber(ChamberName, ChamberNameActive)

            Dim ListGroupParameters As ArrayList = m_Chamber.ListGroupParameters
            For Each ParameterGroup As DBParameterGroup In ListGroupParameters
                Dim ListParameter As ArrayList = ParameterGroup.Parameters
                For Each Parameter As DBParameter In ListParameter
                    Dim GetParameterName = Utils.GetParameterName(Parameter.Description)
                    If GetParameterName = ParameterName Then
                        Return Parameter.DisplayItems
                    End If
                Next
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-07-11</date>
    ''' </author>
    ''' <summary>
    ''' Get List Of SeqNo
    ''' </summary>
    ''' <param name="ChamberName"></param>
    ''' <param name="ParameterName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetListOfSeqNoDisable(ByVal ChamberName As String, ByVal GroupCode As String, _
                                                ByVal ParameterName As String, ByRef SeqNo As Integer, _
                                                ByRef ListOfSeqNoCalculate As Hashtable) As Hashtable
        Try

            Dim ChamberNameActive As String = ContainerData.GetRecipe(ChamberName).ChamberNameActive
            Dim m_Chamber As DBChamber = ContainerData.Chamber(ChamberName, ChamberNameActive)

            Dim ListGroupParameters As ArrayList = m_Chamber.ListGroupParameters
            For Each ParameterGroup As DBParameterGroup In ListGroupParameters
                Dim ListParameter As ArrayList = ParameterGroup.Parameters
                For Each Parameter As DBParameter In ListParameter
                    Dim GetParameterName = Utils.GetParameterName(Parameter.Name)
                    If ParameterGroup.GroupCode = GroupCode And GetParameterName = ParameterName Then
                        SeqNo = Parameter.SeqNo
                        ListOfSeqNoCalculate = Parameter.SeqNoCalculate
                        Return Parameter.SeqNoDisable
                    End If
                Next
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-06-29</date>
    ''' </author>
    ''' <summary>
    ''' Get Parameter from group and SeqNo
    ''' </summary>
    ''' <param name="ChamberName"></param>
    ''' <param name="ParameterName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetParameterFromGroupAndSeqNo(ByVal ChamberName As String, ByVal GroupCode As String, _
                                                 ByRef SeqNo As String) As String
        Try

            Dim ChamberNameActive As String = ContainerData.GetRecipe(ChamberName).ChamberNameActive
            Dim m_Chamber As DBChamber = ContainerData.Chamber(ChamberName, ChamberNameActive)

            Dim ListGroupParameters As ArrayList = m_Chamber.ListGroupParameters
            For Each ParameterGroup As DBParameterGroup In ListGroupParameters
                Dim ListParameter As ArrayList = ParameterGroup.Parameters
                For Each Parameter As DBParameter In ListParameter
                    Dim GetParameterName = Utils.GetParameterName(Parameter.Name)
                    If ParameterGroup.GroupCode = GroupCode And Parameter.SeqNo.ToString() = SeqNo Then
                        Return GetParameterName
                    End If
                Next
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-25</date>
    ''' </author>
    ''' <summary>
    ''' GetNumberFromStep
    ''' </summary>
    ''' <param name="StepName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetNumberFromStep(ByVal StepName As String) As Integer
        Try
            If StepName.StartsWith("Step") Then
                Dim Number As String = StepName.Replace("Step", "")
                Return Integer.Parse(Number)
            Else
                Return 0
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return 0
    End Function

#Region "Class Support Sort"
    Public Class ReverserDBParameter
        Implements IComparer

        ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-08-25</date>
        ''' </author>
        ''' <summary>
        ''' Compare
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Try
                Dim Parameter1 As DBParameter = CType(x, DBParameter)
                Dim Parameter2 As DBParameter = CType(y, DBParameter)
                Return Parameter1.SeqNo < Parameter2.SeqNo
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

        End Function 'IComparer.Compare

    End Class 'ReverserDBParameter

    Public Class ReverserDBChamberStep
        Implements IComparer

        ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-08-25</date>
        ''' </author>
        ''' <summary>
        ''' Compare
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Try
                Dim ChamberStep1 As DBChamberStep = CType(x, DBChamberStep)
                Dim ChamberStep2 As DBChamberStep = CType(y, DBChamberStep)
                Return ChamberStep1.SeqNo < ChamberStep2.SeqNo
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Function 'IComparer.Compare

    End Class 'myReverserClass

    Public Class ReverserDateString
        Implements IComparer

        ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-10-25</date>
        ''' </author>
        ''' <summary>
        ''' Compare
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Try
                Dim strDate1 As String = CType(x, String)
                Dim strDate2 As String = CType(y, String)
                Dim pos1 As Int32 = strDate1.LastIndexOf("\")
                Dim pos2 As Int32 = strDate2.LastIndexOf("\")
                strDate1 = strDate1.Replace(".mdb", "")
                strDate2 = strDate2.Replace(".mdb", "")
                strDate1 = strDate1.Substring(pos1 + "\".Length)
                strDate2 = strDate2.Substring(pos2 + "\".Length)

                Dim dtDate1 As Date = DateTime.ParseExact(strDate1, "MM_dd_yyyy", Nothing)
                Dim dtDate2 As Date = DateTime.ParseExact(strDate2, "MM_dd_yyyy", Nothing)

                Return Date.Compare(dtDate2, dtDate1)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Function 'IComparer.Compare

    End Class 'myReverserClass
#End Region
#End Region

#Region "Create Log File"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' getLogFile
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getLogFile() As String
        Dim dt As DateTime = DateTime.Today
        Dim filePath As String = fileInternalLog + "\" + dt.ToString("MM_dd_yyyy") + ".txt"
        Try
            If System.IO.File.Exists(filePath) Then
                Return filePath
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return filePath
    End Function
#End Region

#Region "Other"
    'Public Shared Sub TrigerGemEvent_for_WaferStatus(ByVal chamberName As String, ByVal data As String)
    '    Try
    '        Dim eq As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(chamberName)
    '        Dim waferID As String = String.Empty
    '        If eq IsNot Nothing Then
    '            '
    '            If eq.GetWaferInfo() IsNot Nothing Then
    '                If (eq.GetWaferInfo().WaferStatus = ConstEnum.enumWaferStatus.eWaferNew And data = IBEConfigurationValues.DEVICE_STATUS_OPEN) OrElse _
    '            (eq.GetWaferInfo().WaferStatus = ConstEnum.enumWaferStatus.eWaferExposed And data = IBEConfigurationValues.DEVICE_STATUS_STOPPED) OrElse _
    '            (eq.GetWaferInfo().WaferStatus = ConstEnum.enumWaferStatus.eWaferComplete And data = IBEConfigurationValues.DEVICE_STATUS_ABORT) OrElse _
    '            (eq.GetWaferInfo().WaferStatus = ConstEnum.enumWaferStatus.eWaferError And data = IBEConfigurationValues.DEVICE_STATUS_NONE) Then
    '                    Exit Sub
    '                End If

    '                waferID = eq.GetWaferInfo().WaferID
    '                Dim waferSlot As Integer = 0
    '                If (waferID.Contains("A")) Then
    '                    waferSlot = Convert.ToInt32(waferID.Replace("A", ""))
    '                    Business.AVPSecsGemLib.TriggerEvent(AVPLib.ConstEnum.LoadLockA_STR, "MaterialStatusStateChanged" & waferSlot)
    '                ElseIf (waferID.Contains("B")) Then
    '                    waferSlot = Convert.ToInt32(waferID.Replace("B", ""))
    '                    Business.AVPSecsGemLib.TriggerEvent(AVPLib.ConstEnum.LoadLockB_STR, "MaterialStatusStateChanged" & waferSlot)
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try

    'End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-18</date>
    ''' </author>
    ''' <summary>
    ''' Get Slot Support Sime auto
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetSlot(ByVal arrRoute As String()) As Integer
        Dim Slot As Integer = 13
        Try
            For Each Route As String In arrRoute
                If (Route.IndexOf("Slot") > -1) Then
                    Dim strSlot As String = Route.Substring(Route.IndexOf("Slot") + "Slot".Length, 1) ' get 0-9
                    Slot = Integer.Parse(strSlot)
                    Try
                        strSlot = Route.Substring(Route.IndexOf("Slot") + "Slot".Length, 2)
                        Slot = Integer.Parse(strSlot)
                    Catch ex As Exception
                        AVPLib.Log.avpLogger.Error(ex.ToString())
                    End Try
                End If
            Next
        Catch ex As Exception
        End Try

        Return Slot
    End Function

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2016-02-01</date>
    ''' </author>
    ''' <summary>
    ''' Get Recipe Version
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetRecipeVersion(ByVal strChamber As String) As String

        Dim objChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(strChamber)
        Dim ChamberName As String = strChamber
        Dim ChamberType As String = objChamber.Type.ToString()
        Dim PathFrom As String = AVPLib.ContainerDAO.FPath_RecipeTemplate & ChamberType & ".xml"
        Dim strVersion As String = String.Empty
        Try
            If System.IO.File.Exists(PathFrom) = False Then
                Return strVersion
            End If
            Dim RecipeXmlDoc As New System.Xml.XmlDocument()
            RecipeXmlDoc.Load(PathFrom)
            Dim xnList As XmlNodeList = RecipeXmlDoc.SelectNodes("/RecipeDef/ParameterList/Parameter")
            If xnList IsNot Nothing Then
                strVersion = xnList(1)("Name").InnerText
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strVersion
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' checkRowExisted
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="dr"></param>
    ''' <param name="fieldName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function checkRowExisted(ByVal dt As DataTable, ByVal dr As DataRow, ByVal fieldName As String) As Boolean
        Try
            For Each drCheck As DataRow In dt.Rows
                If drCheck(fieldName) = dr(fieldName) Then
                    Return True
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' FormatString
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FormatString(ByVal data As Integer) As String
        If data >= 1000 Then
            Return data.ToString("0,000")
        End If
        Return data.ToString()
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' FormatString
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FormatString(ByVal data As Double) As String
        If data >= 1000 Then
            Return data.ToString("0,000")
        End If
        Return data.ToString()
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get Filename from filepath
    ''' </summary>
    ''' <param name="file"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFileName(ByVal file As String, ByVal removeTag As Boolean) As String
        Try
            Dim FileName As String = file
            Dim pos1 As Integer = file.LastIndexOf("\")
            If pos1 <> -1 Then
                FileName = file.Substring(pos1 + "\".Length)
            End If

            If removeTag Then
                Dim pos2 As Integer = FileName.LastIndexOf(".")
                FileName = FileName.Substring(0, pos2)
            End If

            Return FileName
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return ""
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-08-29 </date>
    ''' </author>
    ''' <summary>
    ''' LoadFileXML
    ''' </summary>
    Public Shared Function LoadFileXML(ByVal xmlDoc As XmlDocument, ByVal pathFile As String) As Boolean
        Dim result As Boolean = False
        Dim xmlFile As IO.FileStream = Nothing
        Try
            xmlFile = New IO.FileStream(pathFile, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite)
            xmlDoc.Load(xmlFile)
            result = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Finally
            Try
                If xmlFile IsNot Nothing Then
                    xmlFile.Dispose()
                End If
            Catch
                ' Do not need to log to prevent crash code
            End Try
        End Try

        Return result
    End Function

    Public Shared Function GetAllFiles_byPrefix(ByVal Prefix_File As String) As List(Of String)
        Dim ListOfFiles As New List(Of String)
        Try
            Dim arrFile As String() = Nothing
            Dim strFolder As String = AVPLib.ContainerDAO.FPath_RunDataOfWafer
            arrFile = System.IO.Directory.GetFiles(strFolder, "*.xml")
            For Each filename As String In arrFile
                If filename.Contains(Prefix_File) Then
                    ListOfFiles.Add(filename)
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return ListOfFiles
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get FileName
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <param name="Tag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFileName(ByVal Name As String, ByVal Tag As String) As String
        Try
            Dim FileName As String = Name + "." + Tag

            Return FileName
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return ""
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get Format Number
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetNumber(ByVal data As String) As Integer
        Try
            Return Integer.Parse(data)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return 0
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Delete Sequence
    ''' </summary>
    ''' <param name="FilePath"></param>
    ''' <remarks></remarks>
    Public Shared Sub DeleteFile(ByVal FilePath As String)
        Try
            System.IO.File.Delete(FilePath)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub FinishDataLogging(ByVal chamberName As String)
        Dim arrPropertyNames As New ArrayList()
        Dim arrValues As New ArrayList()

        arrPropertyNames.Add("WaferRun_Status")
        arrValues.Add(STR_OFF)
        EquipmentManager.ChangeStatus(chamberName, arrPropertyNames, arrValues)
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' CopyFile
    ''' </summary>
    ''' <param name="FilePathFrom"></param>
    ''' <param name="FilePathTo"></param>
    ''' <remarks></remarks>
    Public Shared Function CopyFile(ByVal FilePathFrom As String, ByVal FilePathTo As String) As Boolean
        Try
            If (CreateDirectory(FilePathTo)) Then
                System.IO.File.Copy(FilePathFrom, FilePathTo, True)
                Return True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    Public Shared Function Create_GEMDATA_Folder() As Boolean
        Try
            Dim gemFolder As String = ContainerDAO.FPath_GEMData.Replace("DataFiles\GEMData\", "DataFiles\GEMData")
            If Not System.IO.Directory.Exists(gemFolder) Then
                System.IO.Directory.CreateDirectory(gemFolder)
            End If
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            Return False
        End Try
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' CreateDirectory
    ''' </summary>
    ''' <param name="FilePath"></param>
    ''' <remarks></remarks>
    Public Shared Function CreateDirectory(ByVal FilePath As String) As Boolean
        Try
            Dim pos As Integer = FilePath.LastIndexOf("\")
            If pos <> -1 Then
                Dim Directory As String = FilePath.Substring(0, pos)
                If System.IO.Directory.Exists(Directory) = False Then
                    System.IO.Directory.CreateDirectory(Directory)
                End If
            End If
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            Return False
        End Try
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-01</date>
    ''' </author>
    ''' <summary>
    ''' GetMessageError
    ''' </summary>
    ''' <param name="ErrorCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMessageError(ByVal ErrorCode As String) As String
        Return ContainerData.GetMessageError(ErrorCode)
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-01</date>
    ''' </author>
    ''' <summary>
    ''' ParseMessageElevatorCommunicationAlive
    ''' </summary>
    ''' <param name="MessageValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseMessageElevatorCommunicationAlive(ByVal MessageValue As String) As String
        Try
            Dim Pos As Integer = MessageValue.LastIndexOf(",")
            Return MessageValue.Substring(Pos + ",".Length)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return ""
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-01</date>
    ''' </author>
    ''' <summary>
    ''' ParseHexan
    ''' </summary>
    ''' <param name="MessageValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseHexan(ByVal MessageValue As String) As String
        Dim Hexan As String = ""
        Try
            Dim MessageValues As String() = MessageValue.Split(",")
            For i As Integer = 3 To MessageValues.Length - 1
                Dim number As Integer = Convert.ToInt32(MessageValues(i), 16)
                Dim binary As String = Convert.ToString(number, 2)
                Hexan = Hexan + AddStringToHexan(binary)
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Hexan
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-01</date>
    ''' </author>
    ''' <summary>
    ''' AddStringToHexan
    ''' </summary>
    ''' <param name="binary"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function AddStringToHexan(ByVal binary As String) As String
        Try
            For j As Integer = binary.Length To 3
                binary = "0" + binary
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return binary
    End Function

    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2012-08-02</date>
    ''' </author>
    ''' <summary>
    ''' system running with 2 red and green light
    ''' 0001224: [ Khoi Ha - 07/31/2012] Customer. Rework stack light. This will require physical pulsing of RO lights.
    '''� Red = Alarm
    '''� Green solid = Running
    '''� Green flashing = Idle/complete.
    '''� Yellow = reserved/not used for now.
    ''' </summary>
    ''' <param name="binary"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Sub TurnOffSystem_Light_RedGreenMode(ByVal blnTurnOff As Boolean, Optional ByVal strPMx As String = "")
        Try

            If blnTurnOff Then
                If m_lstRunningPM.Count > 0 Then
                    ''remove PM from list
                    m_lstRunningPM.Remove(strPMx)
                End If
                Dim jobmanager As AVPLib.Business.AVPJobManager = AVPLib.Business.AVPCore.Instance().JobManager()
                If (jobmanager Is Nothing OrElse jobmanager.isAllJobFinished()) AndAlso (m_lstRunningPM.Count = 0) Then
                    TurnRunning_GreenLight2Off_RGMode(True) ''Green Off
                    'TurnIdle_YellowLight2Off(False) ''Yellow On Not Use
                End If
            Else
                TurnRunning_GreenLight2Off_RGMode(False) 'Green On
                'TurnIdle_YellowLight2Off(True) 'Yellow Off Not Use

                If Not String.IsNullOrEmpty(strPMx) AndAlso Not m_lstRunningPM.Contains(strPMx) Then
                    m_lstRunningPM.Add(strPMx)
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private Shared Sub TurnOffSystem_Light_RedYellowGreenOrBlueMode(ByVal blnTurnOff As Boolean, Optional ByVal strPMx As String = "")
        Try

            If blnTurnOff Then
                If m_lstRunningPM.Count > 0 Then
                    ''remove PM from list
                    m_lstRunningPM.Remove(strPMx)
                Else
                    Dim jobmanager As AVPLib.Business.AVPJobManager = AVPLib.Business.AVPCore.Instance().JobManager()
                    If (jobmanager Is Nothing OrElse jobmanager.isAllJobFinished()) Then
                        TurnRunning_GreenLightOnOff(True) ''Green Off
                        TurnIdle_YellowLightOnOff(False) ''Yellow On
                    End If
                End If

            Else
                TurnRunning_GreenLightOnOff(False) 'Green On
                TurnIdle_YellowLightOnOff(True) 'Yellow Off

                If Not String.IsNullOrEmpty(strPMx) AndAlso Not m_lstRunningPM.Contains(strPMx) Then
                    m_lstRunningPM.Add(strPMx)
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Public Shared Sub TurnOffSystem_Light(ByVal blnTurnOff As Boolean, Optional ByVal strPMx As String = "")
        If RobotConfigurationValues.NUMBER_ACTIVE_LIGHT = TWOLIGHTALARM Then
            TurnOffSystem_Light_RedGreenMode(blnTurnOff, strPMx)
        ElseIf RobotConfigurationValues.NUMBER_ACTIVE_LIGHT > TWOLIGHTALARM Then
            TurnOffSystem_Light_RedYellowGreenOrBlueMode(blnTurnOff, strPMx)
        End If
    End Sub

    Public Shared Sub TurnIdle_YellowLightOnOff(ByVal blnTurnOff As Boolean)
        Dim objAlarm As AVPLib.DataManagerment.Alarm = AVPLib.DataManagerment.EquipmentManager.GetEquipment("Alarm")
        Dim objRSTiDriver As Driver.AdapterDriver = Nothing
        Dim strMessage As String = String.Empty
        Dim status As AVPLib.DataManagerment.Equipment.WorkingStatuses = AVPLib.DataManagerment.Equipment.WorkingStatuses.On
        Try
            If objAlarm.NumberActiveLight = FOURLIGHTALARM Then
                strMessage = "Alarm.BlueStatus"
                status = objAlarm.BlueStatus
            Else
                strMessage = "Alarm.OrangeStatus"
                status = objAlarm.OrangeStatus
            End If
            objRSTiDriver = Driver.DriverManager.GetDriver(strMessage)
            If blnTurnOff Then
                If status = AVPLib.DataManagerment.Equipment.WorkingStatuses.On Then
                    'AVPLib.Utils.WriteCommandKepServer("Alarm.OrangeStatus", False)
                    If (objRSTiDriver IsNot Nothing) Then
                        If (Not objRSTiDriver.TurnBitOff(strMessage)) Then
                            AVPLib.Log.avpLogger.Error("Turn Off Yellow Light Failed.")
                        End If
                    End If
                End If
            Else
                If status = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off Then
                    'AVPLib.Utils.WriteCommandKepServer("Alarm.OrangeStatus", True)
                    If (objRSTiDriver IsNot Nothing) Then
                        If (Not objRSTiDriver.TurnBitOn(strMessage)) Then
                            AVPLib.Log.avpLogger.Error("Turn On Yellow Light Failed.")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub TurnRunning_GreenLightOnOff(ByVal blnTurnOff As Boolean)
        Dim objAlarm As AVPLib.DataManagerment.Alarm = AVPLib.DataManagerment.EquipmentManager.GetEquipment("Alarm")
        Dim objRSTiDriver As Driver.AdapterDriver = Nothing
        Dim strMessage As String = String.Empty
        Try
            strMessage = "Alarm.GreenStatus"
            objRSTiDriver = Driver.DriverManager.GetDriver(strMessage)

            If blnTurnOff Then
                If objAlarm.GreenStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.On Then
                    'AVPLib.Utils.WriteCommandKepServer("Alarm.GreenStatus", False)
                    If (objRSTiDriver IsNot Nothing) Then
                        If (Not objRSTiDriver.TurnBitOff(strMessage)) Then
                            AVPLib.Log.avpLogger.Error("Turn Off Green Light Failed.")
                        End If
                    End If
                End If
            Else
                If objAlarm.GreenStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off Then
                    'AVPLib.Utils.WriteCommandKepServer("Alarm.GreenStatus", True)
                    If (objRSTiDriver IsNot Nothing) Then
                        If (Not objRSTiDriver.TurnBitOn(strMessage)) Then
                            AVPLib.Log.avpLogger.Error("Turn On Green Light Failed.")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Huy Nguyen </name>
    '''    	<date> 2015-06-23</date>
    ''' </author>
    ''' <summary>
    ''' Turn on green light in system running with 2 red and green light
    ''' </summary>
    ''' <param name="binary"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub TurnRunning_GreenLightOn()
        Dim objRSTiDriver As Driver.AdapterDriver = Nothing
        Dim strMessage As String = String.Empty
        Try
            strMessage = "Alarm.GreenStatus"
            objRSTiDriver = Driver.DriverManager.GetDriver(strMessage)

            If (objRSTiDriver IsNot Nothing) Then
                If (Not objRSTiDriver.TurnBitOn(strMessage)) Then
                    AVPLib.Log.avpLogger.Error("Turn On Green Light Failed.")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2012-08-02</date>
    ''' </author>
    ''' <summary>
    ''' system running with 2 red and green light
    ''' 0001224: [ Khoi Ha - 07/31/2012] Customer. Rework stack light. This will require physical pulsing of RO lights.
    '''� Red = Alarm
    '''� Green solid = Running
    '''� Green flashing = Idle/complete.
    '''� Yellow = reserved/not used for now.
    ''' </summary>
    ''' <param name="binary"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub TurnRunning_GreenLight2Off_RGMode(ByVal blnTurnOff As Boolean, Optional ByVal isSystemRunning As Boolean = True)
        Try
            Dim objAlarm As AVPLib.DataManagerment.Alarm = AVPLib.DataManagerment.EquipmentManager.GetEquipment("Alarm")
            'Running = stop flashing => blnTurnOff = false
            'Stoped = start flashing => blnTurnOff = true
            If (objAlarm IsNot Nothing) Then
                If blnTurnOff Then
                    objAlarm.StartIdleTimer()
                Else
                    objAlarm.StopIdleTimer(isSystemRunning)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub TurnAlarm_RedLightOnOff(ByVal blnTurnOff As Boolean, Optional ByVal isInit As Boolean = False, Optional ByVal IsMainFormClosing As Boolean = False, Optional ByVal isWarning As Boolean = False)
        Dim objAlarm As AVPLib.DataManagerment.Alarm = AVPLib.DataManagerment.EquipmentManager.GetEquipment("Alarm")
        Dim objRSTiDriver As Driver.AdapterDriver = Nothing
        Dim strMessage As String = String.Empty
        Try
            If objAlarm.NumberActiveLight = FOURLIGHTALARM AndAlso isWarning Then
                Turn_Warning_Alarm_OnOff(blnTurnOff, isInit, IsMainFormClosing)
                Exit Try
            End If

            strMessage = "Alarm.RedStatus"
            objRSTiDriver = Driver.DriverManager.GetDriver(strMessage)

            If blnTurnOff Then
                If objAlarm.RedStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.On OrElse isInit Then
                    'AVPLib.Utils.WriteCommandKepServer("Alarm.RedStatus", False)
                    If (objRSTiDriver IsNot Nothing) Then
                        If (Not objRSTiDriver.TurnBitOff(strMessage)) Then
                            AVPLib.Log.avpLogger.Error("Turn Off Red Light Failed.")
                        End If
                    End If
                    '0007338: [KhoiHa- 05/12/2015][CXX-STT]Confirm "Software did not turn off Alarm Sound" is a software bug.
                    If ContainerData.SoundOnDuringAlarm Then
                        strMessage = "Alarm.AlarmStatus"
                        objRSTiDriver = Driver.DriverManager.GetDriver(strMessage)
                        If (objRSTiDriver IsNot Nothing) Then
                            If (Not objRSTiDriver.TurnBitOff(strMessage)) Then
                                AVPLib.Log.avpLogger.Error("Turn Off Alarm Status Failed.")
                            End If
                        End If
                    End If
                End If
            Else
                If (Not IsMainFormClosing) Then
                    If objAlarm.RedStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off OrElse isInit Then
                        'AVPLib.Utils.WriteCommandKepServer("Alarm.RedStatus", True)
                        If (objRSTiDriver IsNot Nothing) Then
                            If (Not objRSTiDriver.TurnBitOn(strMessage)) Then
                                AVPLib.Log.avpLogger.Error("Turn On Red Light Failed.")
                            End If
                        End If
                        If ContainerData.SoundOnDuringAlarm Then
                            'AVPLib.Utils.WriteCommandKepServer("Alarm.AlarmStatus", True)
                            strMessage = "Alarm.AlarmStatus"
                            objRSTiDriver = Driver.DriverManager.GetDriver(strMessage)
                            If (objRSTiDriver IsNot Nothing) Then
                                If (Not objRSTiDriver.TurnBitOn(strMessage)) Then
                                    AVPLib.Log.avpLogger.Error("Turn On Alarm Status Failed.")
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Huy Nguyen </name>
    '''    	<date> 2015-05-26 </date>
    ''' </author>
    ''' <summary>
    ''' Turn warning alarm on off
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub Turn_Warning_Alarm_OnOff(ByVal blnTurnOff As Boolean, Optional ByVal isInit As Boolean = False, _
                                        Optional ByVal IsMainFormClosing As Boolean = False)
        Dim objAlarm As AVPLib.DataManagerment.Alarm = AVPLib.DataManagerment.EquipmentManager.GetEquipment("Alarm")
        Dim objRSTiDriver As Driver.AdapterDriver = Nothing
        Dim strMessage As String = String.Empty
        Try
            strMessage = "Alarm.OrangeStatus"
            objRSTiDriver = Driver.DriverManager.GetDriver(strMessage)

            If blnTurnOff Then
                If objAlarm.OrangeStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.On OrElse isInit Then
                    If (objRSTiDriver IsNot Nothing) Then
                        If (Not objRSTiDriver.TurnBitOff(strMessage)) Then
                            AVPLib.Log.avpLogger.Error("Turn Off Warning Light Failed.")
                        End If
                    End If

                    '0007338: [KhoiHa- 05/12/2015][CXX-STT]Confirm "Software did not turn off Alarm Sound" is a software bug.
                    If ContainerData.SoundOnDuringAlarm Then
                        strMessage = "Alarm.AlarmStatus"
                        objRSTiDriver = Driver.DriverManager.GetDriver(strMessage)
                        If (objRSTiDriver IsNot Nothing) Then
                            If (Not objRSTiDriver.TurnBitOff(strMessage)) Then
                                AVPLib.Log.avpLogger.Error("Turn Off Alarm Status Failed.")
                            End If
                        End If
                    End If
                End If
            Else
                If (Not IsMainFormClosing) Then
                    If objAlarm.OrangeStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off OrElse isInit Then
                        If (objRSTiDriver IsNot Nothing) Then
                            If (Not objRSTiDriver.TurnBitOn(strMessage)) Then
                                AVPLib.Log.avpLogger.Error("Turn On Red Light Failed.")
                            End If
                        End If
                        If ContainerData.SoundOnDuringAlarm Then
                            'AVPLib.Utils.WriteCommandKepServer("Alarm.AlarmStatus", True)
                            strMessage = "Alarm.AlarmStatus"
                            objRSTiDriver = Driver.DriverManager.GetDriver(strMessage)
                            If (objRSTiDriver IsNot Nothing) Then
                                If (Not objRSTiDriver.TurnBitOn(strMessage)) Then
                                    AVPLib.Log.avpLogger.Error("Turn On Alarm Status Failed.")
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-11</date>
    ''' </author>
    ''' <summary>
    ''' WriteCommandKepServer
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WriteCommandKepServer(ByVal Message As String, ByVal Value As Object) As String
        Dim strErrMsg As String = String.Empty
        Try
            strErrMsg = String.Format(ContainerData.GetMessageText("KepserverError"), Message)
            Dim Connection As Communication.KEPServerConnection = CType(Communication.ConnectionManager.GetConnection(ConstEnum.Equipments.KepServer.ToString()), Communication.KEPServerConnection)
            If (Connection IsNot Nothing) AndAlso (Connection.CurrentState = Communication.Connection.States.Connected) Then
                strErrMsg = Connection.WriteItem(Message, Value)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strErrMsg
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-01</date>
    ''' </author>
    ''' <summary>
    ''' WriteCommandKepServer
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SendCommandPMServer(ByVal chamberName As String, _
                                               ByVal Message As String, _
                                               Optional ByVal blLog As Boolean = True) As Boolean
        Try
            Dim conn As Communication.PMServerConnection = CType(Communication.ConnectionManager.GetConnection(chamberName), Communication.PMServerConnection)
            If (conn IsNot Nothing) AndAlso conn.CurrentState = Communication.Connection.States.Connected Then
                If (blLog = True) Then
                    Return conn.SendMessageWithLog(Message)
                Else
                    Return conn.SendMessageWithoutLog(Message)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function
    Public Shared Function ConvertEQName_ToShortName(ByVal EquipName As String)
        Select Case EquipName
            Case Equipments.LoadLockA.ToString()
                Return "LLA"
            Case Equipments.CassettesModule.ToString()
                Return "TM"
            Case Else
                If EquipName.StartsWith(ConstEnum.Chamber) Then
                    Return Utils.chamberID2ChamberName(EquipName)
                End If
        End Select
        Return EquipName
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-05</date>
    ''' </author>
    ''' <summary>
    ''' ThrowAlarm
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <remarks></remarks>
    Public Shared Sub ThrowAlarm(ByVal Message As String)
        Try
            Dim ReplyValues As ArrayList = New ArrayList()
            ReplyValues.Add(Message)

            Dim PropertyNames As ArrayList = New ArrayList()
            PropertyNames.Add("AlarmStatus")

            AVPLib.DataManagerment.EquipmentManager.ChangeStatus("Alarm", PropertyNames, ReplyValues)

            '0007459: [KhoiHa- 05/21/2015][CXX-STT]Send email when system got alarm
            Dim position As Integer = -1
            Dim strMessage As String = Message

            position = Message.IndexOf(ConstEnum.GemAlarmSeperatorString)
            If position <> -1 Then
                strMessage = strMessage.Substring(0, position - 1)
            End If

            AVPLib.SendEmail.Instance.Send(strMessage, ConstEnum.TriggerType.ALARM)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    'Public Shared Sub ThrowAlarm(ByVal strMessage As String, Optional ByVal strGemAlarmName As String = "")
    Public Shared Sub ThrowAlarm(ByVal strMessage As String, ByVal strGemAlarmName As String)
        ThrowAlarm(strMessage + ConstEnum.GemAlarmSeperatorString + strGemAlarmName)
    End Sub

    Public Shared Sub Create_Core_MessageBox(ByVal MessageText As String)
        Dim sMessage As String = MessageText.ToString()
        Try
            Dim ReplyValues As ArrayList = New ArrayList()
            ReplyValues.Add(MessageText)

            Dim PropertyNames As ArrayList = New ArrayList()
            PropertyNames.Add("CoreMessageBox")

            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstEnum.Equipments.CassettesModule.ToString(), PropertyNames, ReplyValues)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub ManualTransferStatus(ByVal MessageText As String)
        Try
            Dim ReplyValues As ArrayList = New ArrayList()
            ReplyValues.Add(MessageText)

            Dim PropertyNames As ArrayList = New ArrayList()
            PropertyNames.Add("ManualTransferStatus")

            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstEnum.Equipments.CassettesModule.ToString(), PropertyNames, ReplyValues)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-8-18</date>
    ''' </author>
    ''' <summary>
    ''' ThrowAlarm
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <remarks></remarks>
    Public Shared Sub ShowStatusMessage(ByVal Message As String, Optional ByVal strSequenceName As String = "")
        Try
            If strSequenceName <> "" Then
                Message = strSequenceName & " - " & Message
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeMessage, AVPLib.ContainerData.LogSource.AVPMainScreen, Message)
            End If

            Dim ReplyValues As ArrayList = New ArrayList()
            Message = Now.ToString("[HH:mm:ss] ") & Message
            ReplyValues.Add(Message)

            Dim PropertyNames As ArrayList = New ArrayList()
            PropertyNames.Add("StatusMessage")

            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstEnum.Equipments.CassettesModule.ToString(), PropertyNames, ReplyValues)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub ShowFlashingText(ByVal FlashingText As String, ByVal blnInCassetteScreen As Boolean)
        Try
            Dim ReplyValues As ArrayList = New ArrayList()
            ReplyValues.Add(FlashingText)

            Dim PropertyNames As ArrayList = New ArrayList()
            If blnInCassetteScreen Then
                PropertyNames.Add("FlashingTextInCassetteScreen")
            Else
                PropertyNames.Add("FlashingTextInProcessScreen")
            End If
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstEnum.Equipments.CassettesModule.ToString(), PropertyNames, ReplyValues)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-8-18</date>
    ''' </author>
    ''' <summary>
    ''' Status only = ON or OFF
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <remarks></remarks>
    Public Shared Sub EnableDisableClearAllWaferButton(ByVal Status As String)
        Try
            Dim arrPropertyNames As New ArrayList()
            Dim arrPropertyValues As New ArrayList()

            arrPropertyNames.Add("ClearAllWaferStatus")
            arrPropertyValues.Add(Status)

            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstEnum.Equipments.CassettesModule.ToString(), _
            arrPropertyNames, arrPropertyValues)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-08-19 </date>
    ''' </author>
    ''' <summary>
    ''' RaiseEnableDisableButtonToGUI
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub RaiseEnableDisableButtonToGUI(ByVal equipmentName As String, ByVal propertyName As String, ByVal isEnable As Boolean)
        AVPLib.Log.coreLogger.Info("Enter RaiseEnableDisableButtonToGUI")
        Try
            Dim ReplyValues As ArrayList = New ArrayList()
            ReplyValues.Add(isEnable)
            Dim PropertyNames As ArrayList = New ArrayList()
            PropertyNames.Add(propertyName)

            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(equipmentName, PropertyNames, ReplyValues)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave RaiseEnableDisableButtonToGUI")
    End Sub

#End Region

#Region "Using Test"
    'FileName = Test
    Public Shared FPath_Test As String = AppDomain.CurrentDomain.SetupInformation.ApplicationBase
    Public Shared Lock As New Object
    Public Shared RoughLock As New Object
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-12-05</date>
    ''' </author>
    ''' <summary>
    ''' Log
    ''' </summary>
    ''' <param name="content"></param>
    ''' <remarks></remarks>
    Public Shared Sub Log(ByVal content As String)
        Try
            SyncLock Lock
                ConnectionFileLog.WriteLine(content)
                ConnectionFileLog.Flush()
            End SyncLock
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Shared m_StreamWriter As System.IO.StreamWriter
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-12-05</date>
    ''' </author>
    ''' <summary>
    ''' ConnectionFileLog
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property ConnectionFileLog() As System.IO.StreamWriter
        Get
            Try
                If (m_StreamWriter Is Nothing) Then
                    m_StreamWriter = New System.IO.StreamWriter(fileInternalLog + "\Test.txt", True, System.Text.Encoding.ASCII)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return m_StreamWriter
        End Get
    End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-12-05</date>
    ''' </author>
    ''' <summary>
    ''' ParseValue
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseValue(ByVal Message As String) As String
        Return Message.Substring(Message.IndexOf(" ") + 1)
        'Dim arrSubString As String() = Message.Split(" ")
        'If (arrSubString.Length > 1) Then
        '    Return arrSubString(1)
        'Else
        '    Return Nothing
        'End If
    End Function
#End Region

#Region "Log Message and check Pulling"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-09</date>
    ''' </author>
    ''' <summary>
    ''' Log Message Check Pulling Cryo include LLACryo, LLBCryo, TMCryo
    ''' </summary>
    ''' <param name="Type"></param>
    ''' <param name="Source"></param>
    ''' <param name="Message"></param>
    ''' <remarks></remarks>
    Public Shared Sub LogMessageCheckPullingCryo(ByVal Type As String, ByVal Source As String, ByVal Message As String)
        Try
            Dim Component As String = String.Empty
            Dim isLog As Boolean = True
            Dim arrPullingMessages As String() = {"$J;", "$K:", "$A?2", "$O>", "$S16"} 'FirstStageTemperature, SecondStageTemperature, PumpStatus, RegenStatus
            For Each PullingMessage As String In arrPullingMessages
                If Message.IndexOf(PullingMessage) > -1 Then 'Is Pulling
                    If (Message.IndexOf("LLACryo") > -1) Then
                        Component = ContainerData.LogSource.LLACryo
                        If Not (AVPLib.ContainerData.GetPolling("LLACryo").IsLog) Then
                            isLog = False
                        End If
                    ElseIf (Message.IndexOf("TMCryo") > -1) Then
                        Component = ContainerData.LogSource.TMCryo
                        If Not (AVPLib.ContainerData.GetPolling("TMCryo").IsLog) Then
                            isLog = False
                        End If
                    ElseIf (Message.IndexOf("TMWaterPump") > -1) Then
                        Component = ContainerData.LogSource.TMWaterPump
                        If Not (AVPLib.ContainerData.GetPolling("TMWaterPump").IsLog) Then
                            isLog = False
                        End If
                    End If
                End If
            Next
            If (AVPLib.ContainerData.TypeAlarm = Type) Then
                AVPLib.Log.terminalServerCryoLogger.Error(Source & "-" & Message)
            Else
                If (isLog) Then
                    AVPLib.Log.terminalServerCryoLogger.Info(Source & "-" & Message)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-09</date>
    ''' </author>
    ''' <summary>
    ''' Log Message Check Pulling LLElevator include LLAElevator
    ''' </summary>
    ''' <param name="Type"></param>
    ''' <param name="Source"></param>
    ''' <param name="Message"></param>
    ''' <remarks></remarks>
    Public Shared Sub LogMessageCheckPullingLLElevator(ByVal Type As String, ByVal Source As String, ByVal Message As String)
        Try
            Dim Component As String = String.Empty
            Dim isLog As Boolean = True
            Dim arrPullingMessages As String() = {"00,R,ER", "00,R,W2", "00,R,CS", "00,R,OS"} 'Online, CassettePresent, DoorClampStatus, OperationStatus
            For Each PullingMessage As String In arrPullingMessages
                If Message.IndexOf(PullingMessage) > -1 Then 'Is Pulling
                    If (Message.IndexOf("LLAElevator") > -1) Then
                        If Not (AVPLib.ContainerData.GetPolling("LLAElevator").IsLog) Then
                            isLog = False
                        End If
                    End If
                End If
            Next

            If (Message.IndexOf("LLAElevator") > -1) Then
                Component = AVPLib.ContainerData.LogSource.LoadLockA
            End If

            If (AVPLib.ContainerData.TypeAlarm = Type) Then
                AVPLib.Log.terminalServerRobotLogger.Error(Source & "-" & Message)
            Else
                If (isLog) Then
                    AVPLib.Log.terminalServerRobotLogger.Info(Source & "-" & Message)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-09</date>
    ''' </author>
    ''' <summary>
    ''' Log Message Check Pulling Robot
    ''' </summary>
    ''' <param name="Type"></param>
    ''' <param name="Source"></param>
    ''' <param name="Message"></param>
    ''' <remarks></remarks>
    Public Shared Sub LogMessageCheckPullingRobot(ByVal Type As String, ByVal Source As String, ByVal Message As String)
        Try
            Dim isLog As Boolean = True
            Dim arrPullingMessages As String() = {"HLLO"} 'ComunicationAlive
            For Each PullingMessage As String In arrPullingMessages
                If Message.IndexOf(PullingMessage) > -1 Then 'Is Pulling
                    If ((Not AVPLib.ContainerData.GetPolling("Robot").IsLog)) Then
                        isLog = False
                    End If
                End If
            Next
            If (AVPLib.ContainerData.TypeAlarm = Type) Then
                AVPLib.Log.terminalServerRobotLogger.Error(Source & "-" & Message)
            Else
                If (isLog) Then
                    AVPLib.Log.terminalServerRobotLogger.Info(Source & "-" & Message)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "IBE Maintanenance"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-01</date>
    ''' </author>
    ''' <summary>
    ''' Decoder IBE Maintenance: convert commandWithData to a real data, otherwise return string
    ''' </summary>
    ''' <param name="dbIBEMaintenance"></param>
    ''' <param name="commandWithData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DecoderIBEMaintenance(ByVal dbIBEMaintenance As DBCommand, ByVal commandWithData As String, ByVal isUseAVPCommandCode As Boolean) As Object
        Dim strSeparator As String = IIf(isUseAVPCommandCode, ":", ",")
        Dim commandData As String = commandWithData.Replace(dbIBEMaintenance.CommandCode & strSeparator, "")
        If commandData = dbIBEMaintenance.CommandCode Then
            commandData = commandData.Replace(commandData.Substring(0, commandData.LastIndexOf(strSeparator)), "")
            commandData = commandData.Replace(strSeparator, "")
        End If

        Try
            If dbIBEMaintenance.DecoderName = "DEVICE_STATUS" Then
                Select Case dbIBEMaintenance.CommandName
                    Case "FIXTURE_TILT_HOME", "FIXTURE_ROTATION_HOME", "FIXTURE_TILT_ERROR", "FIXTURE_ROTATION_ERROR"
                        If commandData = ConfigurationValues.DEVICE_STATUS_OPEN Then
                            Return DEVICE_STATUS.STATUS_ACTIVE
                        Else
                            Return DEVICE_STATUS.STATUS_INACTIVE
                        End If
                        'Case "FIXTURE_TILT_MOVING", "FIXTURE_ROTATION_MOVING" ' Not support now.
                End Select
            ElseIf dbIBEMaintenance.DecoderName = "WorkingStatuses" Then
                If commandData = ConfigurationValues.DEVICE_STATUS_OPEN Then ''01
                    Return DataManagerment.Equipment.WorkingStatuses.On
                ElseIf commandData = ConfigurationValues.DEVICE_STATUS_CLOSED Then ''00
                    Return DataManagerment.Equipment.WorkingStatuses.Off
                    '#03/31/2011 
                    '#Our software shows turbo status as �green� or good when turbo has errored out and is totally shut down.
                    '#Begin fix: set error for 2 case: -1 and -01
                ElseIf commandData = ConfigurationValues.DEVICE_STATUS_ERROR OrElse commandData = ConfigurationValues.DEVICE_STATUS_ERROR_DIF_TYPE Then ''-01
                    Return DataManagerment.Equipment.WorkingStatuses.Unknown
                    '#End fix.
                ElseIf commandData.ToLower() = ConfigurationValues.DEVICE_SIGNAL_OPEN Then ''true
                    'For DeviceNetApp command
                    Return DataManagerment.Equipment.WorkingStatuses.On
                ElseIf commandData.ToLower() = ConfigurationValues.DEVICE_SIGNAL_CLOSED Then ''false
                    'For DeviceNetApp command
                    Return DataManagerment.Equipment.WorkingStatuses.Off
                ElseIf commandData = ConfigurationValues.DEVICE_STATUS_NONE Then ''05
                    Return DataManagerment.Equipment.WorkingStatuses.None
                Else
                    Select Case dbIBEMaintenance.CommandName
                        Case "TURBO_PUMP_POWER"
                            '#03/01/2011 
                            '#0001000: [SL_RFE_KhoiHa_Jan 05,2011][Functionality]- Turbo show on status when not up to speed. 
                            '#Begin fix:
                            If commandData = ConfigurationValues.TURBO_PUMP_POWER_ON Then
                                Return DataManagerment.Equipment.WorkingStatuses.Other
                            End If
                            '#End fix
                        Case "CRYO_REGEN" ''we assume 3 group: Start ->01; Stop & abort: 02,03; Error & None: 04,00
                            If commandData = ConfigurationValues.DEVICE_STATUS_ABORT Or
                               commandData = ConfigurationValues.DEVICE_STATUS_STOPPED Then '03 & 02
                                Return DataManagerment.Equipment.WorkingStatuses.Other
                            ElseIf commandData = ConfigurationValues.DEVICE_STATUS_OTHER Then '04
                                Return DataManagerment.Equipment.WorkingStatuses.Off
                            End If
                    End Select
                    Return DataManagerment.Equipment.WorkingStatuses.Other
                End If
            ElseIf dbIBEMaintenance.DecoderName = "Double" Then
                If String.IsNullOrEmpty(commandData) Then
                    Return -1
                End If
                Return CDbl(commandData)
            ElseIf dbIBEMaintenance.DecoderName = "Integer" Then
                If String.IsNullOrEmpty(commandData) Then
                    Return -1
                End If
                Return CInt(commandData)
            ElseIf dbIBEMaintenance.DecoderName = "Single" Then
                If String.IsNullOrEmpty(commandData) Then
                    Return -1
                End If
                Return CSng(commandData)
            Else
                Return commandData
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

#End Region

#Region "Start Scheduler Condition"
    Public Shared Function IsLLSlitValveOpen(ByVal loadLockName As String) As Boolean
        Dim objTransferModule As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
        If (loadLockName = Equipments.LoadLockA.ToString()) Then
            Return (objTransferModule.SplitValve1Status = Equipment.WorkingStatuses.On)
        End If
        Return False
    End Function

    ''' <author>
    '''     <name> Duc Dang </name>
    '''     <date> 2025-05-08 </date>
    ''' </author>
    ''' <summary>
    ''' Checks whether Hivac is installed on the LoadLock.
    ''' Returns False if Hivac is not installed.
    ''' </summary>
    Public Shared Function CheckLLHivacNotPresent() As Boolean
        Dim ObjectLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())
        If (Not ObjectLoadLock.IsHivacInstalled) Then
            Return False
        End If
        Return True
    End Function

    ''' <author>
    '''     <name> Duc Dang </name>
    '''     <date> 2025-05-08 </date>
    ''' </author>
    ''' <summary>
    ''' Checks whether Hivac is installed on the TM.
    ''' Returns False if TM Hivac is not configured.
    ''' </summary>
    Public Shared Function CheckTMHivacNotPresent() As Boolean
        If (Not RobotConfigurationValues.TM_HIVAC_INSTALLED) Then
            Return False
        End If
        Return True
    End Function

    Public Shared Function IsLLSlitValveClose(ByVal loadLockName As String) As Boolean
        Dim objTransferModule As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
        If (loadLockName = Equipments.LoadLockA.ToString()) Then
            If RobotConfigurationValues.LLA_HIVAC_INSTALLED = False Then 'Rough Only
                Return True
            Else
                Return (objTransferModule.SplitValve1Status = Equipment.WorkingStatuses.Off)
            End If
        End If
        Return False
    End Function

    Public Shared Function IsChamberSlitValveOpen(ByVal srcChamberName As String) As Boolean
        Dim TM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)

        If (srcChamberName = Equipments.Chamber1.ToString()) Then
            Return (Equipment.WorkingStatuses.On = TM.SplitValve2Status)
        ElseIf (srcChamberName = Equipments.Chamber2.ToString()) Then
            Return (Equipment.WorkingStatuses.On = TM.SplitValve3Status)
        ElseIf (srcChamberName = Equipments.Chamber3.ToString()) Then
            Return (Equipment.WorkingStatuses.On = TM.SplitValve4Status)
        End If
        Return False
    End Function

    Public Shared Function IsChamberSlitValveClose(ByVal srcChamberName As String) As Boolean
        Dim TM As DataManagerment.CassettesModule = CType(EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString()), DataManagerment.CassettesModule)
        If (srcChamberName = Equipments.Chamber1.ToString()) Then
            Return (Equipment.WorkingStatuses.Off = TM.SplitValve2Status)
        ElseIf (srcChamberName = Equipments.Chamber2.ToString()) Then
            Return (Equipment.WorkingStatuses.Off = TM.SplitValve3Status)
        ElseIf (srcChamberName = Equipments.Chamber3.ToString()) Then
            Return (Equipment.WorkingStatuses.Off = TM.SplitValve4Status)
        End If
        Return False
    End Function

    Public Shared Function CheckAllSplitValvesClosed() As Boolean
        Dim objChamber1 As DataManagerment.Chamber = CType(DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString()), DataManagerment.Chamber)
        Dim objChamber2 As DataManagerment.Chamber = CType(DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString()), DataManagerment.Chamber)
        Dim objChamber3 As DataManagerment.Chamber = CType(DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString()), DataManagerment.Chamber)

        Dim objRobot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
        Dim objTransferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
        Dim IsSplitValveLLAClose As Boolean = True
        Dim IsSplitValvePM1Close As Boolean = True
        Dim IsSplitValvePM2Close As Boolean = True
        Dim IsSplitValvePM3Close As Boolean = True

        IsSplitValvePM1Close = IIf(objChamber1 Is Nothing, True, objTransferModule.SplitValve2Status = DataManagerment.Equipment.WorkingStatuses.Off)
        IsSplitValvePM2Close = IIf(objChamber2 Is Nothing, True, objTransferModule.SplitValve3Status = DataManagerment.Equipment.WorkingStatuses.Off)
        IsSplitValvePM3Close = IIf(objChamber3 Is Nothing, True, objTransferModule.SplitValve4Status = DataManagerment.Equipment.WorkingStatuses.Off)

        If RobotConfigurationValues.LLA_HIVAC_INSTALLED = False Then
            'Rough Only
            IsSplitValveLLAClose = True
        Else
            IsSplitValveLLAClose = (objTransferModule.SplitValve1Status = DataManagerment.Equipment.WorkingStatuses.Off)
        End If

        If IsSplitValveLLAClose And IsSplitValvePM1Close And IsSplitValvePM2Close And IsSplitValvePM3Close Then
            ' It's Ok.
            Return True
        Else
            Return False
        End If
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2013-05-07</date>
    ''' </author>
    ''' <summary>
    ''' NOTE:   CAREFULL USING THIS FUNCTION
    '''         CONDITION WITH MULTI PARAM ARRAY
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function WaitOnCondition(ByVal condition As CheckMultiCondition, ByVal waitTimeInMilliseconds As Integer, ByVal abortedEvent As Threading.ManualResetEvent, ByVal ParamArray conditionArg() As Object) As Boolean
        Dim span As Int64 = waitTimeInMilliseconds
        Dim start As Int64 = Environment.TickCount
        While (Environment.TickCount - start <= span)
            If (abortedEvent IsNot Nothing) Then
                If abortedEvent.WaitOne(0, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            End If
            ' Check Condition.
            If condition(conditionArg) Then
                Return True
            End If
            If (abortedEvent IsNot Nothing) Then
                If abortedEvent.WaitOne(100, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            Else
                Thread.Sleep(100)
            End If
        End While
        Return False
    End Function
    Public Shared Function WaitOnCondition(ByVal condition As CheckCondition, ByVal waitTimeInMilliseconds As Integer, ByVal abortedEvent As Threading.ManualResetEvent) As Boolean
        Dim span As Int64 = waitTimeInMilliseconds
        Dim start As Int64 = Environment.TickCount
        While (Utils.GetTickCountDelta(start) <= span)
            If (abortedEvent IsNot Nothing) Then
                If abortedEvent.WaitOne(0, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            End If
            ' Check Condition.
            If condition() Then
                Return True
            End If
            If (abortedEvent IsNot Nothing) Then
                If abortedEvent.WaitOne(100, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            Else
                Thread.Sleep(100)
            End If
        End While
        Return False
    End Function
    Public Shared Function WaitOnCondition(ByVal condition As CheckCondition, ByVal waitTimeInMilliseconds As Integer, ByVal aborted1Event As Threading.ManualResetEvent, ByVal aborted2Event As Threading.ManualResetEvent) As Boolean
        Dim span As Int64 = waitTimeInMilliseconds
        Dim start As Int64 = Environment.TickCount
        While (Environment.TickCount - start <= span)
            If (aborted1Event IsNot Nothing) Then
                If aborted1Event.WaitOne(0, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            End If
            If (aborted2Event IsNot Nothing) Then
                If aborted2Event.WaitOne(0, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            End If
            ' Check Condition.
            If condition() Then
                Return True
            End If

            If (aborted1Event IsNot Nothing) Then
                If aborted1Event.WaitOne(0, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            End If

            If (aborted2Event IsNot Nothing) Then
                If aborted2Event.WaitOne(100, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            Else
                Thread.Sleep(100)
            End If
        End While
        Return False
    End Function

    'Wait for condition stable
    Public Shared Function WaitOnStableCondition(ByVal condition As CheckMultiCondition, ByVal waitTimeInMilliseconds As Integer, ByVal waitStableTimeInMilliseconds As Integer, ByVal abortedEvent As Threading.ManualResetEvent, ByVal ParamArray conditionArg() As Object) As Boolean
        Dim span As Int64 = waitTimeInMilliseconds
        Dim start As Int64 = Environment.TickCount
        Dim startStable As Int64 = Environment.TickCount
        While (Environment.TickCount - start <= span)
            If (abortedEvent IsNot Nothing) Then
                If abortedEvent.WaitOne(0, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            End If
            ' Check Condition.
            If condition(conditionArg) Then
                If (Environment.TickCount - startStable >= waitStableTimeInMilliseconds) Then
                    Return True
                End If
            Else
                startStable = Environment.TickCount 'reset
            End If

            If (abortedEvent IsNot Nothing) Then
                If abortedEvent.WaitOne(100, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            Else
                Thread.Sleep(100)
            End If
        End While
        Return False
    End Function

    Public Shared Function Wait(ByVal waitTimeInMilliseconds As Integer, ByVal abortedEvent As Threading.ManualResetEvent) As Boolean
        Dim span As Int64 = waitTimeInMilliseconds
        Dim start As Int64 = Environment.TickCount
        While (Environment.TickCount - start <= span)

            If (abortedEvent IsNot Nothing) Then
                If abortedEvent.WaitOne(0, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            End If

            If (abortedEvent IsNot Nothing) Then
                If abortedEvent.WaitOne(100, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            Else
                Thread.Sleep(100)
            End If
        End While
        Return False
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2012-07-06</date>
    ''' </author>
    ''' <summary>
    '''  ONLY USED FOR CHECK CG/IG DISCONNECTED 
    ''' </summary>
    Public Shared Function WaitOnCondition(ByVal conditionTrue As CheckCondition, ByVal conditionFalse As CheckCondition, ByVal waitTimeInMilliseconds As Integer, ByVal abortedEvent As Threading.ManualResetEvent) As Boolean
        Dim span As Int64 = waitTimeInMilliseconds
        Dim start As Int64 = Environment.TickCount
        While (Environment.TickCount - start <= span)
            If (abortedEvent IsNot Nothing) Then
                If abortedEvent.WaitOne(0, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            End If

            'check CG disconnected first
            If conditionFalse() Then
                Return False
            End If

            ' Check Condition.
            If conditionTrue() Then
                Return True
            End If

            If (abortedEvent IsNot Nothing) Then
                If abortedEvent.WaitOne(100, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            Else
                Thread.Sleep(100)
            End If
        End While
        Return False
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-10-31</date>
    ''' </author>
    ''' <summary>
    '''  Wait on 2 condition. 
    ''' </summary>
    Public Shared Function WaitOn2Condition(ByVal conditionTrue As CheckCondition, ByVal conditionFalse As CheckCondition, ByVal waitTimeInMilliseconds As Integer, ByVal abortedEvent As Threading.ManualResetEvent) As Boolean
        Dim span As Int64 = waitTimeInMilliseconds
        Dim start As Int64 = Environment.TickCount
        While (Environment.TickCount - start <= span)
            If (abortedEvent IsNot Nothing) Then
                If abortedEvent.WaitOne(0, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            End If

            ' Check Condition.
            If conditionTrue() Then
                Return True
            End If

            If conditionFalse() Then
                Return False
            End If

            If (abortedEvent IsNot Nothing) Then
                If abortedEvent.WaitOne(100, False) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return False
                End If
            Else
                Thread.Sleep(100)
            End If
        End While
        Return False
    End Function
#End Region
#Region "Update SecsGem Wafer Status"
    Public Shared Sub UpdateSECSGEM_Variables(ByVal iSlot As Integer, ByVal Waferinfo As AVPLib.AVPWaferInfo, ByVal previousWaferInfo As AVPLib.AVPWaferInfo)
        ' Update SECS/GEM variables by Truc Le
        ' Var Name: MaterialStatusState1->25
        Dim strLL As String = String.Empty ''\IIf(Me.Name = ConstEnum.Equipments.LLAElevator.ToString(), ConstEnum.Equipments.LoadLockA.ToString(), ConstEnum.Equipments.LoadLockB.ToString())
        Dim strVarName As String = "MaterialStatusState" & iSlot.ToString()
        Dim strPreVarName As String = "PreviousMaterialStatusState" & iSlot.ToString()

        If Waferinfo Is Nothing Then
            AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLL, EMSERVICELib.VarType.SV, strVarName, VALUELib.ValueType.U1, 0)
            'business.AVPSecsGemLib.MySecsGemObj.TriggerEvent (
        Else
            AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLL, EMSERVICELib.VarType.SV, strVarName, VALUELib.ValueType.U1, Waferinfo.WaferStatus)
        End If

        If previousWaferInfo Is Nothing Then
            AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLL, EMSERVICELib.VarType.SV, strPreVarName, VALUELib.ValueType.U1, 0)
        Else
            AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLL, EMSERVICELib.VarType.SV, strPreVarName, VALUELib.ValueType.U1, previousWaferInfo.WaferStatus)
        End If
    End Sub
#End Region

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-07-17</date>
    ''' </author>
    ''' <summary>
    '''  Append Sequence Running Status Text
    ''' </summary>
    Public Shared Sub SequenceRunningStatusText(ByVal sEquipmentName As String, ByVal strSequenceName As String, ByVal sValue As String)
        Try
            UpdateSequenceRunningStatusText(sEquipmentName, strSequenceName, STR_SEQ_RUNNING_STATUS_PROPERTYNAME, sValue)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub UpdateSequenceRunningStatusText(ByVal sEquipmentName As String, ByVal sSequenceName As String,
                        ByVal sPropertyName As String,
                        ByVal sValue As String)
        AVPLib.Log.avpLogger.Debug("Enter SavingWaferInfo")
        Try
            Dim arrPropertyNames As New ArrayList()
            Dim arrPropertyValues As New ArrayList()

            arrPropertyNames.Add(sPropertyName)
            arrPropertyValues.Add(sEquipmentName & ": " & sSequenceName & "_" & sValue)
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(sEquipmentName, arrPropertyNames, arrPropertyValues)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.avpLogger.Debug("Leave SavingWaferInfo")
    End Sub

    Public Overloads Shared Sub SavingWaferInfo(ByVal StationName As String, ByVal SlotID As String, ByVal WaferInfo As AVPWaferInfo)
        AVPLib.Log.coreLogger.Info("Enter SavingWaferInfo")
        Try
            Dim WFUpdDB As New AVPLib.WaferUpdateDB
            WFUpdDB.StoreGuiDoc = ContainerDAO.StoreGuiDoc
            WFUpdDB.SourceID = StationName
            WFUpdDB.SrcSlotID = SlotID
            WFUpdDB.WFInfo = WaferInfo
            AVPLib.StoreGuiLib.SavingWaferInfo(WFUpdDB)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SavingWaferInfo")
    End Sub

    Public Overloads Shared Sub SavingWaferInfo(ByVal SourceStation As String, ByVal SrcSlotID As String, ByVal DestStation As String,
                                                ByVal DestSlotID As String, ByVal WaferInfo As AVPWaferInfo)
        AVPLib.Log.coreLogger.Info("Enter SavingWaferInfo With Source - Destination")
        Try
            Dim WFUpdDB As New AVPLib.WaferUpdateDB
            WFUpdDB.StoreGuiDoc = ContainerDAO.StoreGuiDoc
            WFUpdDB.SourceID = SourceStation
            WFUpdDB.SrcSlotID = SrcSlotID

            WFUpdDB.DestinationID = DestStation
            WFUpdDB.DstSlotID = DestSlotID
            WFUpdDB.WFInfo = WaferInfo
            AVPLib.StoreGuiLib.SavingWaferInfo(WFUpdDB)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SavingWaferInfo With Source - Destination")
    End Sub
    ''' <author>
    '''    	<name> Nguyen Tien Dat </name>
    '''    	<date> 2009-05-05</date>
    ''' </author>
    ''' <summary>
    ''' Convert a list of strings into a string for displaying.
    ''' </summary>
    ''' <param name="listOfItems"></param>
    Public Shared Function ArrayToString(ByVal listOfItems As String()) As String
        Dim strRet As String = String.Empty
        For Each item As String In listOfItems
            strRet &= " " & item
        Next
        Return strRet
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-04-12</date>
    ''' </author>
    ''' <summary>
    ''' GetNumberTarget
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function GetNumberTarget(ByVal TargetControl As Object) As Integer
        Dim iResult As Integer = 1
        Try
            Dim NameTextBoxTarget As String = CType(TargetControl, Windows.Forms.TextBox).Name
            If NameTextBoxTarget.Contains("T1") Then
                iResult = 1
            ElseIf NameTextBoxTarget.Contains("T2") Then
                iResult = 2
            ElseIf NameTextBoxTarget.Contains("T3") Then
                iResult = 3
            ElseIf NameTextBoxTarget.Contains("T4") Then
                iResult = 4
            ElseIf NameTextBoxTarget.Contains("T5") Then
                iResult = 5
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return iResult
    End Function

    Public Shared Sub SaveTarXMaterial(ByVal TargetControl As Object, ByVal TarMaterialValue As String, ByVal ChamberID As String)
        AVPLib.Log.coreLogger.Info("Enter SavePresetValue")
        Try '/SystemConfiguration/Robot
            Dim root As System.Xml.XmlNode = ContainerDAO.SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ROBOT)
            Dim objChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(ChamberID)
            Dim numberTarget As Integer = GetNumberTarget(TargetControl) - 1
            Dim target As String = IIf(numberTarget = 0, String.Empty, numberTarget.ToString())
            For Each ChamberNode As Xml.XmlNode In root.ChildNodes
                If ChamberNode.Name = "Configure" Then
                    Exit For
                End If
                Dim strChamberID As String = ChamberNode.SelectSingleNode("Description").InnerText
                If (strChamberID = objChamber.Name) Then ''it is chamber config
                    Dim SystemConfigNode As Xml.XmlNode = ChamberNode.LastChild
                    Dim nodeConfigList As System.Xml.XmlNodeList = SystemConfigNode.ChildNodes
                    For Each SystemNode As Xml.XmlNode In nodeConfigList
                        If SystemNode.FirstChild.InnerText = (PM_TAG_CONFIG.Target_Material.ToString() & target) Then
                            SystemNode.LastChild.InnerText = TarMaterialValue
                            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, ContainerDAO.SystemConfigDoc)
                            Exit Sub
                        End If
                    Next
                End If
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SavePresetValue")
    End Sub

    Public Shared Sub SavePMAlarmLimitX(ByVal TargetControl As Object, ByVal VAlue As String, ByVal ChamberID As String)
        AVPLib.Log.coreLogger.Info("Enter SaveTargetKWHAlarmLimit")
        Try '/SystemConfiguration/Robot
            Dim root As System.Xml.XmlNode = ContainerDAO.SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ROBOT)
            Dim objChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(ChamberID)
            Dim numberTarget As Integer = GetNumberTarget(TargetControl) - 1
            Dim target As String = IIf(numberTarget = 0, String.Empty, numberTarget.ToString())
            For Each ChamberNode As Xml.XmlNode In root.ChildNodes
                If ChamberNode.Name = "Configure" Then
                    Exit For
                End If
                Dim strChamberID As String = ChamberNode.SelectSingleNode("Description").InnerText
                If (strChamberID = objChamber.Name) Then ''it is chamber config
                    Dim SystemConfigNode As Xml.XmlNode = ChamberNode.LastChild
                    Dim nodeConfigList As System.Xml.XmlNodeList = SystemConfigNode.ChildNodes
                    For Each SystemNode As Xml.XmlNode In nodeConfigList
                        If objChamber.Type = SystemModule.ModuleType.PVD OrElse
                           objChamber.Type = SystemModule.ModuleType.PVD4 OrElse
                           objChamber.Type = SystemModule.ModuleType.PVD5T Then
                            If SystemNode.FirstChild.InnerText = (PM_TAG_CONFIG.TargetKWHAlarmLimit.ToString() & target) Then
                                SystemNode.LastChild.InnerText = VAlue
                                BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, ContainerDAO.SystemConfigDoc)
                                Exit Sub
                            End If
                        ElseIf objChamber.Type = SystemModule.ModuleType.IBE Then
                            If SystemNode.FirstChild.InnerText = PM_TAG_CONFIG.SourceUsageLimit.ToString() Then
                                SystemNode.LastChild.InnerText = VAlue
                                BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, ContainerDAO.SystemConfigDoc)
                                Exit Sub
                            End If
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveTargetKWHAlarmLimit")
    End Sub

    Public Shared Sub SavePMWarningLimitX(ByVal TargetControl As Object, ByVal VAlue As String, ByVal ChamberID As String)
        AVPLib.Log.coreLogger.Info("Enter SaveTargetKWHWarningLimit")
        Try '/SystemConfiguration/Robot
            Dim root As System.Xml.XmlNode = ContainerDAO.SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ROBOT)
            Dim objChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(ChamberID)
            Dim numberTarget As Integer = GetNumberTarget(TargetControl) - 1
            Dim target As String = IIf(numberTarget = 0, String.Empty, numberTarget.ToString())
            For Each ChamberNode As Xml.XmlNode In root.ChildNodes
                If ChamberNode.Name = "Configure" Then
                    Exit For
                End If
                Dim strChamberID As String = ChamberNode.SelectSingleNode("Description").InnerText
                If (strChamberID = objChamber.Name) Then ''it is chamber config
                    Dim SystemConfigNode As Xml.XmlNode = ChamberNode.LastChild
                    Dim nodeConfigList As System.Xml.XmlNodeList = SystemConfigNode.ChildNodes
                    For Each SystemNode As Xml.XmlNode In nodeConfigList
                        If objChamber.Type = SystemModule.ModuleType.PVD OrElse
                           objChamber.Type = SystemModule.ModuleType.PVD4 OrElse
                           objChamber.Type = SystemModule.ModuleType.PVD5T Then
                            If SystemNode.FirstChild.InnerText = (PM_TAG_CONFIG.TargetKWHWarningLimit.ToString() & target) Then
                                SystemNode.LastChild.InnerText = VAlue
                                BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, ContainerDAO.SystemConfigDoc)
                                Exit Sub
                            End If
                        ElseIf objChamber.Type = SystemModule.ModuleType.IBE Then
                            If SystemNode.FirstChild.InnerText = PM_TAG_CONFIG.SourceUsageWarning.ToString() Then
                                SystemNode.LastChild.InnerText = VAlue
                                BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, ContainerDAO.SystemConfigDoc)
                                Exit Sub
                            End If
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveTargetKWHWarningLimit")
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-03-09</date>
    ''' </author>
    ''' <summary>
    ''' Save Source Usage into System Config
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveSourceUsage(ByVal strValue As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter Save Source Usage")
        Try
            Dim root As System.Xml.XmlNode = AVPLib.ContainerDAO.SystemConfigDoc.SelectSingleNode(XPATH_SUBSYSTEM_LIST_CONFIG)
            For Each xmlnode As Xml.XmlNode In root.ChildNodes
                If xmlnode.FirstChild.InnerText = "SourceUsage" Then
                    xmlnode.ChildNodes(1).InnerText = strValue
                    ' SystemConfigDoc.Save(FPath_SystemConfig)
                    BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, AVPLib.ContainerDAO.SystemConfigDoc)
                    AVPLib.Log.coreLogger.Info("Leave Save Source Usage")
                    Return True
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave Save Source Usage")
        Return False
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-03-09</date>
    ''' </author>
    ''' <summary>
    ''' Save Source Usage Warning into System Config
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveSourceUsageWarning(ByVal strValue As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter Save Source Usage Warning")
        Try
            Dim root As System.Xml.XmlNode = AVPLib.ContainerDAO.SystemConfigDoc.SelectSingleNode(XPATH_SUBSYSTEM_LIST_CONFIG)
            For Each xmlnode As Xml.XmlNode In root.ChildNodes
                If xmlnode.FirstChild.InnerText = "SourceUsageWarning" Then
                    xmlnode.ChildNodes(1).InnerText = strValue
                    ' SystemConfigDoc.Save(FPath_SystemConfig)
                    BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, AVPLib.ContainerDAO.SystemConfigDoc)
                    AVPLib.Log.coreLogger.Info("Leave Save Source Usage Warning")
                    Return True
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave Save Source Usage Warning")
        Return False
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-03-09</date>
    ''' </author>
    ''' <summary>
    ''' Save Source Usage Limit into System Config
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveSourceUsageLimit(ByVal strValue As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter Save Source Usage Warning")
        Try
            Dim root As System.Xml.XmlNode = AVPLib.ContainerDAO.SystemConfigDoc.SelectSingleNode(XPATH_SUBSYSTEM_LIST_CONFIG)
            For Each xmlnode As Xml.XmlNode In root.ChildNodes
                If xmlnode.FirstChild.InnerText = "SourceUsageLimit" Then
                    xmlnode.ChildNodes(1).InnerText = strValue
                    ' SystemConfigDoc.Save(FPath_SystemConfig)
                    BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, AVPLib.ContainerDAO.SystemConfigDoc)
                    AVPLib.Log.coreLogger.Info("Leave Save Source Usage Limit")
                    Return True
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave Save Source Usage Limit")
        Return False
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-03-09</date>
    ''' </author>
    ''' <summary>
    ''' Save Source Usage Limit into System Config
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveMax_KWH_SourceUsageX(ByVal TargetControl As Object, ByVal strValue As String, ByVal strChamberName As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SaveMax_KWH_SourceUsage")
        Try
            Dim root As System.Xml.XmlNode = ContainerDAO.SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ROBOT)
            Dim objChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(strChamberName)
            Dim numberTarget As Integer = GetNumberTarget(TargetControl) - 1
            Dim target As String = IIf(numberTarget = 0, String.Empty, numberTarget.ToString())
            For Each ChamberNode As Xml.XmlNode In root.ChildNodes
                If ChamberNode.Name = "Configure" Then
                    Exit For
                End If
                Dim strChamberID As String = ChamberNode.SelectSingleNode("Description").InnerText
                If (strChamberID = objChamber.Name) Then ''it is chamber config
                    Dim SystemConfigNode As Xml.XmlNode = ChamberNode.LastChild
                    Dim nodeConfigList As System.Xml.XmlNodeList = SystemConfigNode.ChildNodes
                    For Each SystemNode As Xml.XmlNode In nodeConfigList
                        If SystemNode.FirstChild.InnerText = (PM_TAG_CONFIG.Max_KWH_SourceUsage.ToString() & target) Then
                            SystemNode.LastChild.InnerText = strValue
                            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, ContainerDAO.SystemConfigDoc)
                            Exit Function
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveMax_KWH_SourceUsage")
        Return False
    End Function

    ''' <author>
    '''    	<name> Truc Le </name>
    '''    	<date> 2011-03-09</date>
    ''' </author>
    ''' <summary>
    ''' Save Source Usage Limit into System Config
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveEtchRate(ByVal strValue As String, ByVal strChamberName As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SaveEtchRate")
        Try
            Dim root As System.Xml.XmlNode = ContainerDAO.SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ROBOT)
            Dim objChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(strChamberName)
            For Each ChamberNode As Xml.XmlNode In root.ChildNodes
                If ChamberNode.Name = "Configure" Then
                    Exit For
                End If
                Dim strChamberID As String = ChamberNode.SelectSingleNode("Description").InnerText
                If (strChamberID = objChamber.Name) Then ''it is chamber config
                    Dim SystemConfigNode As Xml.XmlNode = ChamberNode.LastChild
                    Dim nodeConfigList As System.Xml.XmlNodeList = SystemConfigNode.ChildNodes
                    For Each SystemNode As Xml.XmlNode In nodeConfigList
                        If SystemNode.FirstChild.InnerText = PM_TAG_CONFIG.Etch_Rate.ToString() Then
                            SystemNode.LastChild.InnerText = strValue
                            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, ContainerDAO.SystemConfigDoc)
                            Return True
                            Exit Function
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveEtchRate")
        Return False
    End Function

    ''' <author>
    '''    	<name> Huy Nguyen </name>
    '''    	<date> 2011-12-03</date>
    ''' </author>
    ''' <summary>
    ''' Save grid info
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveGridInfo(ByVal strValue As String, ByVal strChamberName As String, ByVal strGridType As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SaveGridInfo")
        Try
            Dim root As System.Xml.XmlNode = ContainerDAO.SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ROBOT)
            Dim objChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(strChamberName)
            For Each ChamberNode As Xml.XmlNode In root.ChildNodes
                If ChamberNode.Name = "Configure" Then
                    Exit For
                End If
                Dim strChamberID As String = ChamberNode.SelectSingleNode("Description").InnerText
                If (strChamberID = objChamber.Name) Then ''it is chamber config
                    Dim SystemConfigNode As Xml.XmlNode = ChamberNode.LastChild
                    Dim nodeConfigList As System.Xml.XmlNodeList = SystemConfigNode.ChildNodes
                    For Each SystemNode As Xml.XmlNode In nodeConfigList
                        If SystemNode.FirstChild.InnerText = strGridType Then
                            SystemNode.LastChild.InnerText = strValue
                            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, ContainerDAO.SystemConfigDoc)
                            Return True
                            Exit Function
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveGridInfo")
        Return False
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-03-24</date>
    ''' </author>
    ''' <summary>
    ''' Save Data Run Output Folder
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveDataRunOutputFolder(ByVal strValue As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter Save Data RunOutput Folder")
        Try
            Dim root As System.Xml.XmlNode = AVPLib.ContainerDAO.ConfigurationServerDoc.SelectSingleNode("/Servers/Chamber1")
            Dim xmlAtt As XmlAttribute = root.Attributes.ItemOf(ConstEnum.DATA_RUN_OUTPUT_FOLDER)
            xmlAtt.Value = strValue
            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_ConfigurationServer, AVPLib.ContainerDAO.ConfigurationServerDoc)
            AVPLib.Log.coreLogger.Info("Leave Save Data RunOutput Folder")
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave Save Data RunOutput Folder")
        Return False
    End Function
    ''' <author>
    '''    	<name> Tinh Le </name>
    '''    	<date> 2024-24-01</date>
    ''' </author>
    ''' <summary>
    ''' Save version number to Config
    ''' </summary>
    Public Shared Sub SaveToRevisionConfigFile(ByVal strValue As String, ByVal strConfig As String)
        Dim xmldocParam As System.Xml.XmlDocument = New System.Xml.XmlDocument()
        Dim strRevisionConfig As String = "RevisionConfig"

        Try
            If Not System.IO.File.Exists(ContainerDAO.FPath_RevisionConfig) Then
                Dim rootElement As XmlElement = xmldocParam.CreateElement(strRevisionConfig)
                xmldocParam.AppendChild(rootElement)
                xmldocParam.Save(ContainerDAO.FPath_RevisionConfig)
            End If

            If System.IO.File.Exists(ContainerDAO.FPath_RevisionConfig) Then
                Dim xmldoc As System.Xml.XmlDocument = AVPLib.ContainerDAO.RevisionConfigDoc
                Dim root As System.Xml.XmlNode = xmldoc.SelectSingleNode(String.Format("/RevisionConfig/SerialNumber[@Name = '{0}']", strConfig))

                If root IsNot Nothing Then
                    root.InnerText = strValue
                    BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_RevisionConfig, xmldoc)
                Else
                    Dim newElement As XmlElement = xmldoc.CreateElement("SerialNumber")
                    newElement.SetAttribute("Name", strConfig)
                    newElement.InnerText = strValue

                    Dim revisionConfigRoot As XmlElement = xmldoc.SelectSingleNode("/RevisionConfig")
                    revisionConfigRoot.AppendChild(newElement)

                    BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_RevisionConfig, xmldoc)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Public Shared Function SaveSystemDataRun(ByVal strValue As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter Save System Data Run")
        Try
            Dim root As System.Xml.XmlNode = AVPLib.ContainerDAO.SystemConfigDoc.SelectSingleNode(XPATH_SYSTEM_DATE_RUN)
            root.InnerText = strValue
            ' SystemConfigDoc.Save(FPath_SystemConfig)
            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, AVPLib.ContainerDAO.SystemConfigDoc)
            AVPLib.Log.coreLogger.Info("Leave Save System Data Run")
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave Save System Data Run")
        Return False
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-04-12</date>
    ''' </author>
    ''' <summary>
    ''' Save Use Lot System ID into System Config
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveUseLotSystemID(ByVal strValue As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter Save Use Lot System ID")
        Try
            Dim root As System.Xml.XmlNode = AVPLib.ContainerDAO.SystemConfigDoc.SelectSingleNode(XPATH_SUBSYSTEM_LIST_CONFIG)
            For Each xmlnode As Xml.XmlNode In root.ChildNodes
                If xmlnode.FirstChild.InnerText = "UseLotSystemID" Then
                    xmlnode.ChildNodes(1).InnerText = strValue
                    ' SystemConfigDoc.Save(FPath_SystemConfig)
                    BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, AVPLib.ContainerDAO.SystemConfigDoc)
                    AVPLib.Log.coreLogger.Info("Leave Save Use Lot System ID")
                    Return True
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave Save Use Lot System ID")
        Return False
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-04-12</date>
    ''' </author>
    ''' <summary>
    ''' Save Use Use System Warm Up into System Config
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveUseSystemWarmUp(ByVal strValue As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter Save Use System Warm Up")
        Try
            Dim root As System.Xml.XmlNode = AVPLib.ContainerDAO.SystemConfigDoc.SelectSingleNode(XPATH_SUBSYSTEM_LIST_CONFIG)
            For Each xmlnode As Xml.XmlNode In root.ChildNodes
                If xmlnode.FirstChild.InnerText = "UseSystemWarmUp" Then
                    xmlnode.ChildNodes(1).InnerText = strValue
                    ' SystemConfigDoc.Save(FPath_SystemConfig)
                    BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, AVPLib.ContainerDAO.SystemConfigDoc)
                    AVPLib.Log.coreLogger.Info("Leave Save Use System Warm Up")
                    Return True
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave Save Use System Warm Up")
        Return False
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-06-08</date>
    ''' </author>
    ''' <summary>
    ''' Save Logging Interval into System Config
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveLoggingInterval(ByVal strValue As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter Save Logging Interval")
        Try
            Dim root As System.Xml.XmlNode = AVPLib.ContainerDAO.SystemConfigDoc.SelectSingleNode(XPATH_SUBSYSTEM_LIST_CONFIG)
            For Each xmlnode As Xml.XmlNode In root.ChildNodes
                If xmlnode.FirstChild.InnerText = "LoggingInterval" Then
                    xmlnode.ChildNodes(1).InnerText = strValue
                    ' SystemConfigDoc.Save(FPath_SystemConfig)
                    BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, AVPLib.ContainerDAO.SystemConfigDoc)
                    AVPLib.Log.coreLogger.Info("Leave Save Logging Interval")
                    Return True
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave Save Logging Interval")
        Return False
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-02-05 </date>
    ''' </author>
    ''' <summary>
    ''' SavePresetValue
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub SavePresetValue(ByVal Chamber As SystemModule, ByVal presetTable As SystemModule.PresetTable,
                        ByVal subSystemName As String, ByRef hstTargetPresetValue As Hashtable, ByRef hstBiasPresetValue As Hashtable)
        AVPLib.Log.coreLogger.Info("Enter SavePresetValue")
        Try '/SystemConfiguration/Robot
            Dim root As System.Xml.XmlNode = ContainerDAO.SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ROBOT)

            For Each ChamberNode As Xml.XmlNode In root.ChildNodes
                If ChamberNode.Name = "Configure" Then
                    Exit For
                End If
                Dim chamberName As String = ChamberNode.SelectSingleNode("Description").InnerText
                Dim nodeConfigList As System.Xml.XmlNodeList = ChamberNode.ChildNodes
                If (chamberName = Chamber.Name) Then ''it is chamber config
                    For Each node As Xml.XmlNode In nodeConfigList
                        SaveToNode(subSystemName, ChamberNode.LastChild, presetTable, subSystemName, hstTargetPresetValue, hstBiasPresetValue)
                    Next
                End If
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SavePresetValue")
    End Sub

    '' <summary>
    '' Save LastExecution to SystemConfig.xml file
    '' </summary>
    '' <remarks></remarks>
    Public Shared Function SaveLastExecution(ByVal strChamberName As String, ByVal strData As String) As Boolean
        AVPLib.Log.coreLogger.Info("Leave SaveLastExecution")
        Try
            Dim root As System.Xml.XmlNode = ContainerDAO.SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ROBOT)
            Dim objChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(strChamberName)
            objChamber.LastExecution = strData

            For Each ChamberNode As Xml.XmlNode In root.ChildNodes
                If ChamberNode.Name = "Configure" Then
                    Exit For
                End If
                Dim strChamberID As String = ChamberNode.SelectSingleNode("Description").InnerText

                If (strChamberID = objChamber.Name) Then ''it is chamber config
                    Dim SystemConfigNode As Xml.XmlNode = ChamberNode.LastChild

                    For Each SystemNode As Xml.XmlNode In SystemConfigNode.ChildNodes
                        If SystemNode.FirstChild.InnerText = PM_TAG_CONFIG.LastExecution.ToString() Then
                            SystemNode.LastChild.InnerText = strData
                            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, ContainerDAO.SystemConfigDoc)
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            Return False
        End Try
        AVPLib.Log.coreLogger.Info("Leave Save Source Usage Limit")
        Return True
    End Function

    '' <summary>
    '' Save IdleThreshold to SystemConfig.xml file
    '' </summary>
    '' <remarks></remarks>
    Public Shared Function SaveIdleThreshold(ByVal strData As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SaveIdleThreshold")
        Try
            Dim root As System.Xml.XmlNode = AVPLib.ContainerDAO.SystemConfigDoc.SelectSingleNode(XPATH_SUBSYSTEM_LIST_CONFIG)
            For Each xmlnode As Xml.XmlNode In root.ChildNodes
                If xmlnode.FirstChild.InnerText = "IdleThreshold" Then
                    xmlnode.ChildNodes(1).InnerText = strData
                    ' SystemConfigDoc.Save(FPath_SystemConfig)
                    BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, AVPLib.ContainerDAO.SystemConfigDoc)
                    AVPLib.Log.coreLogger.Info("Leave SaveIdleThreshold")
                    Return True
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveIdleThreshold")
    End Function

    '' <summary>
    '' Save WarmUpRecipe to SystemConfig.xml file
    '' </summary>
    '' <remarks></remarks>
    Public Shared Function SaveWarmUpRecipe(ByVal strData As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SaveIdleThreshold")
        Try
            Dim root As System.Xml.XmlNode = AVPLib.ContainerDAO.SystemConfigDoc.SelectSingleNode(XPATH_SUBSYSTEM_LIST_CONFIG)
            For Each xmlnode As Xml.XmlNode In root.ChildNodes
                If xmlnode.FirstChild.InnerText = "WarmUpRecipe" Then
                    xmlnode.ChildNodes(1).InnerText = strData
                    ' SystemConfigDoc.Save(FPath_SystemConfig)
                    BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, AVPLib.ContainerDAO.SystemConfigDoc)
                    AVPLib.Log.coreLogger.Info("Leave SaveIdleThreshold")
                    Return True
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveIdleThreshold")
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-10-06</date>
    ''' </author>
    ''' <summary>
    ''' Save AdminAutologOff time into System Config
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveAdminAutologOff(ByVal strValue As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SaveAdminAutologOff")
        Try
            Dim root As System.Xml.XmlNode = AVPLib.ContainerDAO.SystemConfigDoc.SelectSingleNode(XPATH_ADMIN_AUTOLOG_OFF_TIME)
            If root IsNot Nothing Then
                root.InnerText = strValue
                ' SystemConfigDoc.Save(FPath_SystemConfig)
                BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, AVPLib.ContainerDAO.SystemConfigDoc)
                AVPLib.Log.coreLogger.Info("Leave SaveAdminAutologOff")
                Return True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave Save Logging Interval")
        Return False
    End Function
    '' <author>
    ''    	<name> Dat Cao </name>
    ''    	<date> 2011-03-22 </date>
    '' </author>
    '' <summary>
    '' SavePresetValue
    '' </summary>
    '' <remarks></remarks>
    Public Shared Sub SaveIBESourceValue(ByVal Chamber As SystemModule, ByVal hstSourceValue As Hashtable)
        AVPLib.Log.coreLogger.Info("Enter SavePresetValue")
        Try '/SystemConfiguration/Robot
            Dim root As System.Xml.XmlNode = ContainerDAO.SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ROBOT)

            For Each ChamberNode As Xml.XmlNode In root.ChildNodes
                If ChamberNode.Name = "Configure" Then
                    Exit For
                End If
                Dim chamberName As String = ChamberNode.SelectSingleNode("Description").InnerText
                Dim nodeConfigList As System.Xml.XmlNodeList = ChamberNode.ChildNodes
                If (chamberName = Chamber.Name) Then ''it is chamber config
                    SaveToNode(IBE_SOURCE_STR, ChamberNode.LastChild, hstSourceValue)
                End If
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SavePresetValue")
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-02-05 </date>
    ''' </author>
    ''' <summary>
    ''' SavePresetValue
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub SaveToNode(ByVal subsystemName As String, ByVal SubSystemNode As Xml.XmlNode,
                   ByRef presetTable As SystemModule.PresetTable, ByVal Name As String,
                   ByRef hstTargetPresetValue As Hashtable, ByRef hstBiasPresetValue As Hashtable)
        AVPLib.Log.coreLogger.Info("Enter SaveToNode")
        Try '''store to hastable new value
            If subsystemName.Contains(TARGET_POWER_SUPPLY_STR) Then
                subsystemName = TARGET_POWER_SUPPLY_STR
                hstTargetPresetValue.Item(presetTable.ID) = presetTable
            Else
                hstBiasPresetValue.Item(presetTable.ID) = presetTable
            End If
            For Each subnode As Xml.XmlNode In SubSystemNode.ChildNodes
                If subnode.FirstChild.InnerText = subsystemName Then
                    For Each presetNode As Xml.XmlNode In subnode.LastChild.ChildNodes
                        If presetNode.Attributes(PRESET_ID_STR).Value = presetTable.ID Then
                            presetNode.Attributes(PRESET_C1_STR).Value = (presetTable.C1)
                            presetNode.Attributes(PRESET_C2_STR).Value = (presetTable.C2)
                            'ContainerDAO.SystemConfigDoc.Save(ContainerDAO.FPath_SystemConfig)
                            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, ContainerDAO.SystemConfigDoc)
                            Exit Sub
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveToNode")
    End Sub
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2009-02-05 </date>
    ''' </author>
    ''' <summary>
    ''' Save IBE Source File  to Arraylist
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub SaveToNode(ByVal subsystemName As String, ByVal SubSystemNode As Xml.XmlNode,
                   ByVal hstSourceValue As Hashtable)
        AVPLib.Log.coreLogger.Info("Enter SaveToNode")
        Try '''store to hastable new value
            For Each subnode As Xml.XmlNode In SubSystemNode.ChildNodes
                If subnode.FirstChild.InnerText = subsystemName Then
                    For Each SourceNode As Xml.XmlNode In subnode.LastChild.ChildNodes
                        Dim SourceName As String = SourceNode.Attributes(0).Value
                        SourceNode.Attributes(1).Value = hstSourceValue.Item(SourceName)
                    Next
                    BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, ContainerDAO.SystemConfigDoc)
                    Exit Sub
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveToNode")
    End Sub
    ''' <author>
    '''    	<name> Nguyen Tien Dat </name>
    '''    	<date> 2009-05-05</date>
    ''' </author>
    ''' <summary>
    ''' Convert a list of strings into a string for displaying.
    ''' </summary>
    ''' <param name="listOfItems"></param>
    Public Shared Function ArrayToString(ByVal listOfItems As List(Of String)) As String
        Dim strRet As String = String.Empty
        For Each item As String In listOfItems
            strRet &= " " & item
        Next
        Return strRet
    End Function
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-09-20</date>
    ''' </author>
    ''' <summary>
    ''' Convert a chamber ID to a chamber name (chamber ID can be "Chamber 1", "Chamber1", .....)
    ''' The chamber name will be return
    ''' </summary>
    ''' <param name="listOfItems"></param>
    Public Shared Function chamberID2ChamberName(ByVal strChamberID As String) As String

        Dim strStationName As String = (strChamberID).Replace(" ", "")
        Dim strRet As String = strChamberID
        Try
            'strStationname is "Chamber 1" or "Chamber 2" ...
            If strStationName = AVPLib.ConstEnum.Equipments.Chamber1.ToString() Then
                strRet = AVPLib.RobotConfigurationValues.CHAMBER1_NAME
            ElseIf strStationName = AVPLib.ConstEnum.Equipments.Chamber2.ToString() Then
                strRet = AVPLib.RobotConfigurationValues.CHAMBER2_NAME
            ElseIf strStationName = AVPLib.ConstEnum.Equipments.Chamber3.ToString() Then
                strRet = AVPLib.RobotConfigurationValues.CHAMBER3_NAME
            ElseIf strStationName = AVPLib.ConstEnum.Equipments.CassettesModule.ToString() Then
                strRet = AVPLib.RobotConfigurationValues.CASSETTEDMODULE_NAME
            ElseIf strStationName = AVPLib.ConstEnum.Equipments.IBE.ToString() Then
                strRet = AVPLib.RobotConfigurationValues.ANY_IBE_CHAMBER
            ElseIf strStationName = AVPLib.ConstEnum.Equipments.PVD.ToString() Then
                strRet = AVPLib.RobotConfigurationValues.ANY_PVD_CHAMBER
            ElseIf strStationName = AVPLib.ConstEnum.Equipments.LoadLockA.ToString() Then
                strRet = AVPLib.ConstEnum.LLA_STR
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strRet
    End Function
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-09-20</date>
    ''' </author>
    ''' <summary>
    ''' Convert a chamber ID to a chamber name (chamber NAME can be "Chamber xxxx", "xxxx", .....)
    ''' The chamber name will be return
    ''' </summary>
    ''' <param name="listOfItems"></param>
    Public Shared Function chamberName2ChamberID(ByVal strChamberName As String) As String
        Try
            'strStationname is "Chamber 1" or "Chamber 2" ...
            If strChamberName = AVPLib.RobotConfigurationValues.CHAMBER1_NAME Then
                Return AVPLib.ConstEnum.Equipments.Chamber1.ToString()
            ElseIf strChamberName = AVPLib.RobotConfigurationValues.CHAMBER2_NAME Then
                Return AVPLib.ConstEnum.Equipments.Chamber2.ToString()
            ElseIf strChamberName = AVPLib.RobotConfigurationValues.CHAMBER3_NAME Then
                Return AVPLib.ConstEnum.Equipments.Chamber3.ToString()
            ElseIf strChamberName = AVPLib.RobotConfigurationValues.ANY_IBE_CHAMBER Then
                Return AVPLib.ConstEnum.Equipments.IBE.ToString()
            ElseIf strChamberName = AVPLib.RobotConfigurationValues.ANY_PVD_CHAMBER Then
                Return AVPLib.ConstEnum.Equipments.PVD.ToString()
            ElseIf strChamberName = AVPLib.RobotConfigurationValues.CASSETTEDMODULE_NAME Then
                Return AVPLib.ConstEnum.Equipments.CassettesModule.ToString()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strChamberName
    End Function

    Public Shared Sub SetPMStatus(ByVal strStatus As String, ByVal equipName As String)
        AVPLib.Log.coreLogger.Info("Enter SetPMStatus")
        Try
            Dim ReplyValues As ArrayList = New ArrayList()
            ReplyValues.Add(strStatus)

            Dim PropertyNames As ArrayList = New ArrayList()
            PropertyNames.Add("ProcessMonitor_Status_Readback")
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(equipName, PropertyNames, ReplyValues)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SetPMStatus")
    End Sub

    Public Shared Sub SetPM_IncreaseWaferCount(ByVal equipName As String, Optional ByVal iFactor As Integer = 1)
        AVPLib.Log.coreLogger.Info("Enter setPM_IncreaseWaferCount")
        Try
            Dim ReplyValues As ArrayList = New ArrayList()
            ReplyValues.Add(iFactor)

            Dim PropertyNames As ArrayList = New ArrayList()
            PropertyNames.Add("PM_WaferCount")
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(equipName, PropertyNames, ReplyValues)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave setPM_IncreaseWaferCount")
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-13</date>
    ''' </author>
    ''' <summary>
    ''' Set Wafer Inside
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SetWaferInside(ByVal Path As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SetWaferInside")
        Try
            AVPLib.Log.coreLogger.Info("Leave SetWaferInside")
            Return False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SetWaferInside")
        Return False
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Store File 
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function StoreFile(ByRef xmldoc As Xml.XmlDocument, ByVal fileName As String, ByVal strTypeOfFile As String, ByVal strDescription As String) As XmlNode
        AVPLib.Log.coreLogger.Info("Enter StoreFile")
        Try
            If Not System.IO.File.Exists(fileName) Then ''if file did not exist
                CreateDirectory(fileName) ''if PM folder did not create
                Insert_To_MasterFile(fileName)

                xmldoc = New Xml.XmlDocument

                Dim RootNode As System.Xml.XmlNode = xmldoc.CreateElement(strTypeOfFile)
                xmldoc.AppendChild(RootNode)
                Dim DescNode As System.Xml.XmlNode = xmldoc.CreateElement("Description")
                DescNode.InnerText = strDescription
                RootNode.AppendChild(DescNode)
                Dim StartNode As System.Xml.XmlNode = xmldoc.CreateElement("Start")
                StartNode.InnerText = Now.ToString("MM/dd/yy HH:mm:ss")
                RootNode.AppendChild(StartNode)
                Dim ResultNode As System.Xml.XmlNode = xmldoc.CreateElement("Result")
                ResultNode.InnerText = "0"
                RootNode.AppendChild(ResultNode)
                Dim SampleNode As Xml.XmlNode = xmldoc.CreateElement("SampleList")
                SampleNode.InnerText = ""
                RootNode.AppendChild(SampleNode)

                Dim writer As XmlTextWriter = New XmlTextWriter(fileName, Nothing)
                writer.Formatting = Formatting.Indented
                xmldoc.Save(writer)
                AVPLib.Log.guiLogger.Info("Leave StoreFile")
                Return SampleNode
            Else
                Dim SampleNode As System.Xml.XmlNode = xmldoc.SelectSingleNode("/" & strTypeOfFile & "/SampleList")
                AVPLib.Log.avpLogger.Info("Leave StoreFile")
                Return SampleNode
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
        AVPLib.Log.coreLogger.Info("Leave StoreFile")
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Store File 
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub Insert_To_MasterFile(ByVal filename As String)
        AVPLib.Log.coreLogger.Info("Enter Insert_To_MasterFile")
        Try
            Dim xmlMasterDoc As New XmlDocument
            Dim strFilePath As String = filename.Substring(0, filename.LastIndexOf("\"))
            Dim strFile As String = filename.Substring(filename.LastIndexOf("\") + 1)
            Dim Files As String() = System.IO.Directory.GetFiles(strFilePath, "*.xml")
            ''if Folder is empty or Master file did not create
            If Files.Length = 0 Or System.IO.File.Exists(strFilePath + MASTER_FILE) = False Then
                Dim rootNode As XmlNode = xmlMasterDoc.CreateElement("ListOfFiles")
                xmlMasterDoc.AppendChild(rootNode)
                Dim fileNode As XmlNode = xmlMasterDoc.CreateElement("Files")
                fileNode.InnerText = strFile
                rootNode.AppendChild(fileNode)

                ''if master file exist
            ElseIf (System.IO.File.Exists(strFilePath + MASTER_FILE)) Then
                xmlMasterDoc.Load(strFilePath + MASTER_FILE)
                Dim rootNode As XmlNode = xmlMasterDoc.FirstChild
                ''if master file has 50 file -> it remove the first
                If rootNode.ChildNodes.Count >= 50 Then
                    DeleteFile(strFilePath & "\" & rootNode.FirstChild.InnerText)
                    rootNode.RemoveChild(rootNode.FirstChild)
                End If

                Dim fileNode As XmlNode = xmlMasterDoc.CreateElement("Files")
                fileNode.InnerText = strFile
                rootNode.AppendChild(fileNode)
            Else
                AVPLib.Log.avpLogger.Error("Can not insert Master File to folder: " & strFilePath)
                Exit Sub
            End If

            xmlMasterDoc.Save(strFilePath + MASTER_FILE)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave Insert_To_MasterFile")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Get All GraphFiles from DataFiles\GraphFiles
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function GetAllGraphFiles(ByVal strFolderName As String) As ArrayList
        AVPLib.Log.coreLogger.Info("Enter GetAllGraphFiles")
        Try
            'IF FOLDER AND MASTER FILE IS EXIST
            If System.IO.Directory.Exists(strFolderName) And System.IO.File.Exists(strFolderName + MASTER_FILE) Then
                Dim xmlMasterDoc As New XmlDocument
                xmlMasterDoc.Load(strFolderName + MASTER_FILE)

                Dim ListOfFile As New ArrayList()

                For Each node As XmlNode In xmlMasterDoc.FirstChild.ChildNodes
                    ListOfFile.Add(node.InnerText)
                Next
                AVPLib.Log.coreLogger.Info("Leave GetAllGraphFiles")
                Return ListOfFile
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetAllGraphFiles")
        Return Nothing
    End Function

    ''' <author>
    '''    	<name>Hoa Nguyen</name>
    '''    	<date> 2011-05-11</date>
    ''' </author>
    ''' <summary>
    ''' Check source log is a equipment or not.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function CheckSourceLogIsAEquipment(ByVal strSource As String) As Boolean
        For Each strEquipment As String In System.Enum.GetNames(GetType(AVPLib.ConstEnum.Equipments))
            If strSource = strEquipment Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' Check if system is need to warm up
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function IsRecipeOK(ByVal strRecipeName As String) As Boolean
        Dim objIBE As DataManagerment.IBEChamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
        Dim chamberName As String = AVPLib.ConstEnum.Equipments.Chamber1.ToString()
        Dim RecipePathFrom As String = AVPLib.ContainerDAO.FPath_ChamberRecipe + "\" + chamberName + "\" + AVPLib.Utils.GetFileName(strRecipeName, "prc")
        If Not System.IO.File.Exists(RecipePathFrom) Then ''if file did not exist
            Return False
        End If
        Return True
    End Function
    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2016-03-16</date>
    ''' </author>
    ''' <summary>
    ''' Convert a chamber name to a chamber type (IBE,PVD, .....)
    ''' The chamber type will be return
    ''' </summary>
    ''' <param name="listOfItems"></param>
    Public Shared Function GetChamberType(ByVal strChamberName As String) As String
        Try
            'strStationname is "Chamber 1" or "Chamber 2" ...
            Dim objChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(strChamberName)
            If objChamber IsNot Nothing Then
                Return objChamber.Type.ToString()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function
    ''' <author>
    '''    	<name>Hoa Nguyen</name>
    '''    	<date> 2011-08-10</date>
    ''' </author>
    ''' <summary>
    ''' Convert WorkingStatus Value For Update GEM. All status that are different from on/off will convert to unknown.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function ConvertWorkingStatusValueForUpdateGEM(ByVal value As DataManagerment.Equipment.WorkingStatuses) _
                    As DataManagerment.Equipment.WorkingStatuses

        If value <> DataManagerment.Equipment.WorkingStatuses.On AndAlso value <> DataManagerment.Equipment.WorkingStatuses.Off Then
            value = DataManagerment.Equipment.WorkingStatuses.Unknown
        End If

        Return value
    End Function

    ''' <author>
    '''    	<name>Hoa Nguyen</name>
    '''    	<date> 2011-08-10</date>
    ''' </author>
    ''' <summary>
    ''' Update min/max recipe for all recipe of this chamber (DBChamber) when min/max recipe is changed. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub UpdateMinMaxRecipe(ByVal GroupCode As String, ByVal ParamName As String, ByVal NewMin As Double, ByVal NewMax As Double, ByVal strChamber As String)
        Try
            For Each key As String In ContainerData.ChamberMap.Keys
                If key.Contains(strChamber) Then
                    For Each dbparam As AVPLib.DBParameterGroup In ContainerData.ChamberMap(key).ListGroupParameters
                        If String.IsNullOrEmpty(GroupCode) Then
                            GroupCode = dbparam.GroupCode
                        End If
                        For Each param As AVPLib.DBParameter In dbparam.Parameters
                            If param.Name = ParamName And dbparam.GroupCode = GroupCode Then
                                param.Min = NewMin
                                param.Max = NewMax
                                Exit For
                            End If
                        Next
                    Next
                End If
            Next
            ContainerDAO.RefreshChamberDocMap(False)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name>Hoa Nguyen</name>
    '''    	<date> 2011-08-10</date>
    ''' </author>
    ''' <summary>
    ''' Save min/max recipe to file. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub SaveMinMaxParameter(ByVal groupCode As String, ByVal paramName As String, ByVal strChamber As String, ByVal Min As Single, ByVal Max As Single)
        Try
            Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(strChamber)
            Dim chamberModule As SystemModule = Nothing
            AVPLib.ContainerData.IsChamberVisible(ChamberName, chamberModule)
            Dim FilePath As String = String.Empty
            FilePath = AVPLib.ContainerDAO.FPath_ChamberConfig & "\Chambers" & "\" &
                ChamberName & "\" & ChamberName & "_" & chamberModule.Type.ToString() & ".xml"

            Dim XmlDoc As Xml.XmlDocument = New Xml.XmlDocument()
            XmlDoc.Load(FilePath)
            Dim xPathMin As String
            Dim xPathMax As String

            If chamberModule.Type = SystemModule.ModuleType.PVD4 OrElse chamberModule.Type = SystemModule.ModuleType.PVD5T Then
                xPathMin = String.Format("/RecipeDef/ParameterList[@Group='{0}']/Parameter[Name = '{1}']/Min", groupCode, paramName)
                xPathMax = String.Format("/RecipeDef/ParameterList[@Group='{0}']/Parameter[Name = '{1}']/Max", groupCode, paramName)
            Else
                xPathMin = String.Format("/RecipeDef/ParameterList/Parameter[Name = '{0}']/Min", paramName)
                xPathMax = String.Format("/RecipeDef/ParameterList/Parameter[Name = '{0}']/Max", paramName)
            End If

            Dim nodeMin As Xml.XmlNode = XmlDoc.SelectSingleNode(xPathMin)
            Dim nodeMax As Xml.XmlNode = XmlDoc.SelectSingleNode(xPathMax)
            If (nodeMin IsNot Nothing) And (nodeMax IsNot Nothing) Then
                nodeMin.InnerText = Min.ToString()
                nodeMax.InnerText = Max.ToString()
                ' Save
                XmlDoc.Save(FilePath)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name>Hoa Nguyen</name>
    '''    	<date> 2011-08-10</date>
    ''' </author>
    ''' <summary>
    ''' IsAlarmFromIBE. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function IsAlarmFromIBE(ByVal strAlarmContent As String) As Boolean
        Dim bRes As Boolean = False
        Try
            Dim spaceFirstIdx = strAlarmContent.IndexOf(" "c)
            Dim spaceSecondIdx = strAlarmContent.IndexOf(" "c, spaceFirstIdx + 1)
            Dim strAlarmID As String = strAlarmContent.Substring(0, spaceFirstIdx + 1)
            Dim strAlarmLevel As String = strAlarmContent.Substring(spaceFirstIdx + 1, spaceSecondIdx - (spaceFirstIdx + 1))
            Dim nAlarmLevel As Int32 = 0
            Int32.TryParse(strAlarmLevel, nAlarmLevel)
            If nAlarmLevel > 0 Then
                bRes = False
            Else
                bRes = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return bRes
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-07-09</date>
    ''' </author>
    ''' <summary>
    ''' CreateFilterListBox
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub CreateFilterListBox(ByVal strFilter As String, ByRef listBox As Windows.Forms.ListBox, ByVal listFileNameFilter As ArrayList)
        AVPLib.Log.coreLogger.Info("Enter CreateFilterListBox")
        Try
            listBox.Items.Clear()
            For Each item As String In listFileNameFilter
                If item.ToLower().Contains(strFilter.ToLower()) Then
                    listBox.Items.Add(item)
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave CreateFilterListBox")
    End Sub

    Public Shared Function GemEquip2GemId(ByVal strEquipmentName As String) As String
        Dim strGemId As String = String.Empty
        Select Case strEquipmentName
            Case "LLA", Equipments.LoadLockA.ToString, Equipments.LLAElevator.ToString, Equipments.LLACryo.ToString
                strGemId = "LLA"
            Case "TM", Equipments.CassettesModule.ToString, Equipments.Robot.ToString,
                    Equipments.Aligner.ToString, Equipments.TMCryo.ToString, Equipments.TMWaterPump.ToString
                strGemId = "TM"
            Case "PM1", Equipments.Chamber1.ToString
                strGemId = "PM1"
            Case "PM2", Equipments.Chamber2.ToString
                strGemId = "PM2"
            Case "PM3", Equipments.Chamber3.ToString
                strGemId = "PM3"

            Case Else
                strGemId = String.Empty
        End Select
        Return strGemId
    End Function


    Public Shared Function GemGetAlarmName(ByVal strModuleId As String, Optional ByVal strSubAlarmName As String = ConstEnum.GEM_ALARM_SUB_COMMON_ALARM) As String
        Dim strGemModuleId = GemEquip2GemId(strModuleId)
        If String.IsNullOrEmpty(strGemModuleId) Then
            Return AVPLib.ConstEnum.GEM_ALARM_SYSTEM
        End If
        Return (strGemModuleId & "." & strSubAlarmName)
    End Function

    ''' <author>
    '''    	<name>Dat Cao</name>
    '''    	<date> 2012-02-15</date>
    ''' </author>
    ''' <summary>
    ''' Input: pumpage name as LLAPumpPackage,LLBPumpPackage,TMPumpPackage
    ''' Output: LoadlockA,LoadlockB,TM
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function GetModuleName4Gem(ByVal PackageName As String) As String
        Dim strResult As String = String.Empty
        Try

            Select Case PackageName
                Case ConstEnum.Equipments.LLAPumpPackage.ToString
                    strResult = ConstEnum.Equipments.LoadLockA.ToString()
                Case ConstEnum.Equipments.TMPumpPackage.ToString
                    strResult = ConstEnum.TM_STR
                Case Else
                    strResult = String.Empty
            End Select

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return strResult
    End Function

    ''' <author>
    '''    	<name>Huy Nguyen</name>
    '''    	<date> 2015-06-30</date>
    ''' </author>
    ''' <summary>
    ''' Input: pumpage name as LLAPumpPackage,TMPumpPackage
    ''' Output: LoadlockA,CassettesModule
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function GetEquipmentOfPumpPackage(ByVal PackageName As String) As String
        Dim strResult As String = String.Empty
        Try

            Select Case PackageName
                Case ConstEnum.Equipments.LLAPumpPackage.ToString
                    strResult = ConstEnum.Equipments.LoadLockA.ToString()
                Case ConstEnum.Equipments.TMPumpPackage.ToString
                    strResult = ConstEnum.Equipments.CassettesModule.ToString()
                Case Else
                    strResult = String.Empty
            End Select

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return strResult
    End Function

    ''' <author>
    '''    	<name>Dat Cao</name>
    '''    	<date> 2012-02-23</date>
    ''' </author>
    ''' <summary>
    ''' Input: station name
    ''' ENABLE_ANYIBE_MODE = true and IBE CHAMBER
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function IsIBEChamber_ANYIBE(ByVal StationName As String) As Boolean
        Dim strResult As Boolean = False
        Try
            Dim chamberConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(StationName)
            If (AVPLib.ContainerDAO.Enable_ANYIBE_Mode AndAlso
            chamberConfig IsNot Nothing AndAlso chamberConfig.Type = ConstEnum.IBEType.AVP_IBE.ToString()) Then
                Return True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return strResult
    End Function

    Public Shared Function GetTickCountDelta(ByVal iStartTime As Int64) As Int64
        Dim iDelta As Int64 = 0
        Try
            Dim iNow As Int64 = Environment.TickCount

            If (iStartTime > iNow) Then
                iDelta = (Integer.MaxValue - iStartTime) + (iNow - Integer.MinValue)
            Else
                iDelta = iNow - iStartTime
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return iDelta
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Save config to System Config with path <c>ConstEnum.XPATH_SUBSYSTEM_LIST_CONFIG</c> of <c>chamberName</c>
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function SaveConfigItem(ByVal strTag As String, ByVal strValue As String, ByVal chamberName As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SaveConfigItem:" & strTag)
        Try
            Dim root As System.Xml.XmlNodeList = AVPLib.ContainerDAO.SystemConfigDoc.SelectNodes(XPATH_SUBSYSTEM_LIST_CONFIG)
            For Each subSystemListNode As Xml.XmlNode In root
                If subSystemListNode.ParentNode.FirstChild.InnerText = chamberName Then
                    For Each subSystemNode As XmlNode In subSystemListNode.ChildNodes
                        If subSystemNode.FirstChild.InnerText = strTag Then
                            subSystemNode.SelectSingleNode("Value").InnerText = strValue
                            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, AVPLib.ContainerDAO.SystemConfigDoc)
                            AVPLib.Log.coreLogger.Info("Leave SaveConfigItem:" & strTag)
                            Return True
                        End If
                    Next
                End If
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveConfigItem:" & strTag)
        Return False
    End Function
    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-06-30 </date>
    ''' </author>
    ''' <summary>
    ''' Check Casset Presaent
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function IsExistWaferInCassette(ByVal m_objElevator As DataManagerment.LLElevator) As Boolean
        Try
            If m_objElevator IsNot Nothing Then
                With m_objElevator
                    For i As Integer = 0 To (.ListOfWaferInfo.Length - 1)
                        If .ListOfWaferInfo(i) IsNot Nothing AndAlso .ListOfWaferInfo(i).WaferStatus <> ConstEnum.enumWaferStatus.eWaferNone Then
                            Return True
                        End If
                    Next
                End With
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return False
    End Function

    ''' <author>
    '''    	<name>Dua Tran</name>
    '''    	<date> 2017-06-29</date>
    ''' </author>
    ''' <summary>
    ''' Get row index .
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function GetRowIndex(ByVal seqNo As String, ByVal m_lastOpenRecipe As String, ByVal RowIndexCall As Integer, ByVal seqNoCall As Integer, ByVal dt As DataTable) As Integer
        Dim idexRow As Integer = 0
        Try
            If seqNo.Contains(":") Then
                Dim strInfomationSeq As Array = seqNo.Split(":")
                Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(m_lastOpenRecipe)
                Dim strGroup As String = strInfomationSeq(0).ToString()
                Dim strParameter As String = AVPLib.Utils.GetParameterFromGroupAndSeqNo(ChamberName, strGroup, strInfomationSeq(1).ToString())
                For rowIndex As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(rowIndex)("BelongToGroup") = strGroup AndAlso dt.Rows(rowIndex)("ParameterName") = strParameter Then
                        idexRow = rowIndex
                        Exit For
                    End If

                Next
            Else
                idexRow = RowIndexCall - seqNoCall + Integer.Parse(seqNo)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return idexRow
    End Function

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2018-01-31</date>
    ''' </author>
    ''' <summary>
    ''' Is Able Open Files In Editor
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsAbleOpenFilesInEditor(ByVal sFileName As String, ByVal bIsRecipe As Boolean,
                                              ByVal bIsWaferFlow As Boolean, ByVal bIsSequence As Boolean,
                                              Optional ByVal sChamberName As String = "") As Boolean
        Try
            Dim blResult As Boolean = False

            sFileName = IIf(sFileName.Contains(".xml"), sFileName, sFileName & ".xml")

            Dim strFilePath As String = String.Empty
            Dim strGEMPath As String = String.Empty
            If bIsRecipe Then
                strFilePath = ContainerDAO.FPath_ChamberRecipe & "\" & sChamberName & "\" & sFileName
#If AVP_PLATFORM = "CX" Then
                strGEMPath = ContainerDAO.FPath_GEMData_Recipe & Utils.chamberID2ChamberName(sChamberName) & "." & sFileName
#ElseIf AVP_PLATFORM = "SL" Then
                strGEMPath = ContainerDAO.FPath_GEMData & sFileName
#End If
            ElseIf bIsWaferFlow Then
                strFilePath = ContainerDAO.FPath_WaferFlow & sFileName
                strGEMPath = ContainerDAO.FPath_GEMData_WaferFlow & sFileName
            ElseIf bIsSequence Then
                strFilePath = ContainerDAO.FPath_SequenceData & "\" & sFileName
                strGEMPath = ContainerDAO.FPath_GEMData_Sequence & sFileName
            End If

            blResult = IsAbleOpenFile(strFilePath, strGEMPath)
            Return blResult
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2018-01-31</date>
    ''' </author>
    ''' <summary>
    ''' Is Able Open File
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsAbleOpenFile(ByVal strRecipePath As String, ByVal strGEMRecipePath As String) As Boolean
        Dim blResult As Boolean = False
        Dim RecipeStream As IO.FileStream = Nothing
        Dim GEMRecipeStream As IO.FileStream = Nothing
        Try
            'check crash
            RecipeStream = IO.File.Open(strRecipePath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)

            ' Return true If (strRecipePath exists and is not readOnly) AND
            '                   (strGEMRecipePath (exists and is not readOnly) OR doesn't exist)
            If IO.File.Exists(strRecipePath) Then

                Dim objRecipeInfo As IO.FileInfo = New IO.FileInfo(strRecipePath)
                If objRecipeInfo IsNot Nothing AndAlso Not objRecipeInfo.IsReadOnly Then

                    If IO.File.Exists(strGEMRecipePath) Then
                        GEMRecipeStream = IO.File.Open(strGEMRecipePath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)

                        Dim objGEMRecipeInfo As IO.FileInfo = New IO.FileInfo(strGEMRecipePath)
                        If objGEMRecipeInfo IsNot Nothing AndAlso Not objGEMRecipeInfo.IsReadOnly Then
                            blResult = True
                        End If

                    Else
                        blResult = True
                    End If

                End If
            End If

        Catch
            RecipeStream = Nothing
            If (GEMRecipeStream IsNot Nothing) Then
                GEMRecipeStream = Nothing
            End If
            Return False
        Finally
            If (RecipeStream IsNot Nothing) Then
                RecipeStream.Close()
            End If
            If (GEMRecipeStream IsNot Nothing) Then
                GEMRecipeStream.Close()
            End If
        End Try
        Return blResult
    End Function

    ''' <author>Duc Pham</author>
    ''' <date>2018-11-01</date>
    ''' <summary>
    ''' Updata material state and trigger event.
    ''' </summary>
    Public Shared Sub UpdataMaterialStateAndTriggerEvent(ByVal LLName As String,
                                                ByVal currentWaferStatus As AVPLib.ConstEnum.enumWaferStatus,
                                                ByVal previousWaferStatus As AVPLib.ConstEnum.enumWaferStatus,
                                                ByVal slot As Integer)
        Try

            AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(LLName, EMSERVICELib.VarType.SV,
                "MaterialStatusState" & slot.ToString(), VALUELib.ValueType.U1, currentWaferStatus)

            AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(LLName, EMSERVICELib.VarType.SV,
                "PreviousMaterialStatusState" & slot.ToString(), VALUELib.ValueType.U1, previousWaferStatus)

            If currentWaferStatus <> previousWaferStatus Then
                Business.AVPSecsGemLib.TriggerEvent(LLName, "MaterialStatusStateChanged" & slot.ToString())
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Dung Pham </name>
    '''     <date> 2020-03-31 </date>
    ''' </author>
    ''' <summary>
    ''' ChangeStatusForFor2Channel
    ''' </summary>
    Public Shared Sub ChangeStatusForFor2Channel(ByVal name As String, ByVal propertyName As String, ByVal value As AVPLib.DataManagerment.Equipment.WorkingStatuses)
        Try
            Dim PropertyNames As ArrayList = New ArrayList()
            PropertyNames.Add(propertyName)

            Dim ReplyValues As ArrayList = New ArrayList()
            ReplyValues.Add(value)

            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(name, PropertyNames, ReplyValues)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Dung Pham </name>
    '''     <date> 2020-11-17 </date>
    ''' </author>
    ''' <summary>
    ''' check file can to add independent property ReadShowHiddenFiles
    ''' </summary>
    Public Shared Function CanToAddFile(ByVal fileName As String) As Boolean
        Dim bResult As Boolean = False

        Try
            If Not ContainerDAO.EnableReworkFeature() OrElse ContainerDAO.ReadShowReworkFiles() Then
                bResult = True
            Else
                If Not System.Text.RegularExpressions.Regex.IsMatch(fileName, "(RW_).*(.xml)") Then
                    bResult = True
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return bResult
    End Function

    ''' <summary>
    ''' Check if system is need to warm up
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function GetRecipeWarmUp(ByVal strEquipmentName As String) As String
        Dim strResult As String = String.Empty
        Dim chamberModule As SystemModule = AVPLib.ContainerData.GetRobotConfig(strEquipmentName)

        If chamberModule IsNot Nothing Then
            strResult = chamberModule.WarmUpRecipe
        End If

        Return strResult
    End Function

    Public Shared Function CheckRateOfRaiseIsRunning(ByVal strEquipment As String, ByVal strSequence As String) As Boolean
        Try
            Dim equipment As AVPLib.DataManagerment.Equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(strEquipment)
            If equipment IsNot Nothing And equipment.RateOfRise_Status = DataManagerment.Equipment.WorkingStatuses.On Then
                ThrowAlarm(String.Format("{0}: Can not start {1} due to ROR is running", AVPLib.Utils.chamberID2ChamberName(strEquipment), Replace(Replace(strSequence, "[", ""), "]", "")))
                Return False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return True
    End Function

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2026-03-03</date>
    ''' </author>
    ''' <summary>
    ''' Check Robot ok to open/close slit valve of chamber
    ''' </summary>
    ''' <param name="strChamber"></param>
    ''' <param name="strChamberName"></param>
    ''' <param name="isOpen"></param>
    ''' <returns></returns>
    Public Shared Function IsRobotStationOKToOpenCloseSlitValve(strChamber As String, strChamberName As String, isOpen As Boolean) As String
        Dim strErrorMsg = String.Empty
        Try
            Dim objRobot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
            If (objRobot.IsCommunicating) Then
                Dim checkRobotRetract As Boolean = objRobot.IsRetracted AndAlso objRobot.IsReallyRetracted
                If checkRobotRetract = False Then
                    If (objRobot.CurrentPosition = Positions.Original OrElse
                        objRobot.CurrentPosition = Positions.Unknown) Then
                        strErrorMsg = String.Format(AVPLib.ContainerData.GetMessageText("RobotWasNotRetract"), strChamberName)
                    ElseIf IsRobotAtStation(strChamber) Then
                        strErrorMsg = "Cannot " & IIf(isOpen, Open, Close) & " Slit valve because the robot station is in " & strChamberName
                    End If
                ElseIf IsRobotAtStation(strChamber) Then
                    strErrorMsg = "Cannot " & IIf(isOpen, Open, Close) & " Slit valve because the robot station is in " & strChamberName
                End If
            Else
                strErrorMsg = String.Format(AVPLib.ContainerData.GetMessageText("EquipmentDisconnect"), objRobot.Name)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strErrorMsg
    End Function

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2026-03-03</date>
    ''' </author>
    ''' <summary>
    ''' Check Robot is at station or not
    ''' </summary>
    ''' <param name="chamberName"></param>
    ''' <returns></returns>
    Private Shared Function IsRobotAtStation(ByVal chamberName As String) As Boolean
        Dim blResult As Boolean = False
        Try
            Dim objRobot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
            If (objRobot Is Nothing) Then
                Return True
            End If

            Select Case chamberName
                Case ConstEnum.Equipments.Chamber1.ToString()
                    If (objRobot.CurrentPosition = ConstEnum.Positions.Chamber1 OrElse
                    objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber1_Extract OrElse
                    objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber1_Wafer_Extract OrElse
                    objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber1_Wafer) Then

                        blResult = True
                    End If
                Case ConstEnum.Equipments.Chamber2.ToString()
                    If (objRobot.CurrentPosition = ConstEnum.Positions.Chamber2 OrElse
                    objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber2_Extract OrElse
                    objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber2_Wafer_Extract OrElse
                    objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber2_Wafer) Then

                        blResult = True
                    End If
                Case ConstEnum.Equipments.Chamber3.ToString()
                    If (objRobot.CurrentPosition = ConstEnum.Positions.Chamber3 OrElse
                    objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber3_Extract OrElse
                    objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber3_Wafer_Extract OrElse
                    objRobot.CurrentPosition = ConstEnum.Positions.Arm_At_Chamber3_Wafer) Then

                        blResult = True
                    End If
                Case Else

            End Select

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blResult
    End Function

#Region "Pumpdown with share rough pump"

    ''' <author>
    '''    	<name>Tin Pham</name>
    '''    	<date> 2016-08-10 </date>
    ''' </author>
    ''' <summary>
    ''' Close All Other Rough Valve if they shared rough pump
    ''' </summary>
    Public Shared Function CloseAllOtherRoughValve(ByVal equipmentName As String, ByRef strErrMsg As String,
                                                   ByVal strStatusMsg As String,
                                                   ByVal abortedEvent As Threading.ManualResetEvent,
                                                   Optional ByRef isHasCloseLLARoughValve As Boolean = False,
                                                   Optional ByRef isHasCloseTMRoughValve As Boolean = False) As Boolean

        AVPLib.Log.seqLogger.Info("Enter CloseAllOtherRoughValve")
        Dim result As Boolean = True

        Try
            If abortedEvent.WaitOne(0, True) Then
                Utils.ShowStatusMessage(strStatusMsg)
                result = False
                GoTo ExitFunction
            End If

            Dim objLoadLockCtrl As AVPLib.Business.LoadLockController = Nothing
            Dim objTMCtrl As AVPLib.Business.TMController = Nothing
            Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(equipmentName)

            If (roughpumpMachine IsNot Nothing) Then
                ' Close TM Rough Valve
                If (equipmentName <> ConstEnum.Equipments.CassettesModule.ToString) AndAlso
                   roughpumpMachine.IsUsed(ConstEnum.Equipments.CassettesModule.ToString) Then

                    objTMCtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.CassettesModule.ToString())

                    If objTMCtrl IsNot Nothing AndAlso objTMCtrl.IsTMRoughValveOpenCond() Then
                        If Not objTMCtrl.StepCloseTMRoughValve(strErrMsg, False, strStatusMsg, abortedEvent) Then
                            result = False
                            GoTo ExitFunction
                        End If
                        isHasCloseTMRoughValve = True
                    End If

                End If

                ' Close LLA Rough Valve
                If (equipmentName <> ConstEnum.Equipments.LoadLockA.ToString) AndAlso
                   roughpumpMachine.IsUsed(ConstEnum.Equipments.LoadLockA.ToString) Then

                    objLoadLockCtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())

                    If objLoadLockCtrl IsNot Nothing Then
                        If Not objLoadLockCtrl.Close_LLx_Rough_Valve(strStatusMsg, strErrMsg, False, abortedEvent, isHasCloseLLARoughValve) Then
                            result = False
                            GoTo ExitFunction
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

ExitFunction:
        AVPLib.Log.seqLogger.Info("Leave CloseAllOtherRoughValve")
        Return result
    End Function

    ''' <author>
    '''    	<name>Tin Pham</name>
    '''    	<date> 2016-08-10 </date>
    ''' </author>
    ''' <summary>
    ''' Open All Other Rough Valve if they shared rough pump and also close their at previous step
    ''' </summary>
    Public Shared Function OpenAllOtherRoughValve(ByVal equipmentName As String, ByRef strErrMsg As String,
                                                   ByVal strStatusMsg As String,
                                                   ByVal abortedEvent As Threading.ManualResetEvent,
                                                   ByVal isHasCloseLLARoughValve As Boolean,
                                                   ByVal isHasCloseTMRoughValve As Boolean) As Boolean

        AVPLib.Log.seqLogger.Info("Enter OpenAllOtherRoughValve")
        Dim result As Boolean = True

        Try
            If abortedEvent.WaitOne(0, True) Then
                Utils.ShowStatusMessage(strStatusMsg)
                result = False
                GoTo ExitFunction
            End If

            Dim objLoadLockCtrl As AVPLib.Business.LoadLockController = Nothing
            Dim objTMCtrl As AVPLib.Business.TMController = Nothing
            Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(equipmentName)

            If (roughpumpMachine IsNot Nothing) Then
                ' Open TM Rough Valve
                If isHasCloseTMRoughValve AndAlso
                   (equipmentName <> ConstEnum.Equipments.CassettesModule.ToString) AndAlso
                   roughpumpMachine.IsUsed(ConstEnum.Equipments.CassettesModule.ToString) Then

                    objTMCtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.CassettesModule.ToString())

                    If objTMCtrl IsNot Nothing AndAlso objTMCtrl.IsTMRoughValveCloseCond() AndAlso Not objTMCtrl.IsTMVentValveOpenCond() Then
                        If Not AVPLib.Business.TMCryoUtility.OpenRoughValveNoWait(AVPLib.ConstEnum.Equipments.CassettesModule.ToString()) Then
                            result = False
                            GoTo ExitFunction
                        End If
                    End If

                End If

                ' Open LLA Fast Rough Valve
                If isHasCloseLLARoughValve AndAlso
                   (equipmentName <> ConstEnum.Equipments.LoadLockA.ToString) AndAlso
                   roughpumpMachine.IsUsed(ConstEnum.Equipments.LoadLockA.ToString) Then

                    objLoadLockCtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())

                    If objLoadLockCtrl IsNot Nothing AndAlso objLoadLockCtrl.IsLLFastRoughValveCloseCond() AndAlso
                                                            Not objLoadLockCtrl.IsLLFastVentValveOpenCond() AndAlso
                                                            (IIf(RobotConfigurationValues.LL_SLOW_VENT_INSTALLED,
                                                            Not objLoadLockCtrl.IsLLSoftVentValveOpenCond(), True)) Then

                        If Not AVPLib.Business.LLCryoUtility.OpenLLFastRoughNoWait(AVPLib.ConstEnum.Equipments.LoadLockA.ToString()) Then
                            result = False
                            GoTo ExitFunction
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

ExitFunction:
        AVPLib.Log.seqLogger.Info("Leave OpenAllOtherRoughValve")
        Return result
    End Function

    ''' <author>
    '''    	<name>Tin Pham</name>
    '''    	<date> 2016-08-10 </date>
    ''' </author>
    ''' <summary>
    ''' Close All Other Foreline Valve if they shared rough pump
    ''' </summary>
    Public Shared Function CloseAllOtherForelineRoughValve(ByVal equipmentName As String, ByRef strErrMsg As String,
                                                           ByVal strStatusMsg As String,
                                                           ByVal abortedEvent As Threading.ManualResetEvent,
                                                           Optional ByRef isHasCloseLLAForelineValve As Boolean = False,
                                                           Optional ByRef isHasCloseTMForelineValve As Boolean = False) As Boolean

        AVPLib.Log.seqLogger.Info("Enter CloseAllOtherForelineRoughValve")
        Dim result As Boolean = True

        Try
            If abortedEvent.WaitOne(0, True) Then
                Utils.ShowStatusMessage(strStatusMsg)
                result = False
                GoTo ExitFunction
            End If

            Dim objLoadLockCtrl As AVPLib.Business.LoadLockController = Nothing
            Dim objTMCtrl As AVPLib.Business.TMController = Nothing
            Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(equipmentName)

            If (roughpumpMachine IsNot Nothing) Then
                ' Close TM Foreline Valve
                If RobotConfigurationValues.TMTURBO_VISIBLE AndAlso
                  (equipmentName <> ConstEnum.Equipments.CassettesModule.ToString) AndAlso
                   roughpumpMachine.IsUsed(ConstEnum.Equipments.CassettesModule.ToString) Then

                    objTMCtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.CassettesModule.ToString())

                    If objTMCtrl IsNot Nothing AndAlso objTMCtrl.IsTMTurboForelineValveOpenCond() Then
                        If Not objTMCtrl.StepCloseTMTurboForeline(strErrMsg, strStatusMsg, abortedEvent) Then
                            result = False
                            GoTo ExitFunction
                        End If
                        isHasCloseTMForelineValve = True
                    End If

                End If

                ' Close LLA Foreline Valve
                If RobotConfigurationValues.LLA_TURBO_VISIBLE AndAlso
                  (equipmentName <> ConstEnum.Equipments.LoadLockA.ToString) AndAlso
                   roughpumpMachine.IsUsed(ConstEnum.Equipments.LoadLockA.ToString) Then

                    objLoadLockCtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())

                    If objLoadLockCtrl IsNot Nothing AndAlso objLoadLockCtrl.IsLLTurboForelineValveOpenCond() Then
                        If Not objLoadLockCtrl.StepCloseLLTurboForelineValve(strErrMsg, strStatusMsg, abortedEvent) Then
                            result = False
                            GoTo ExitFunction
                        End If
                        isHasCloseLLAForelineValve = True
                    End If
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

ExitFunction:
        AVPLib.Log.seqLogger.Info("Leave CloseAllOtherForelineRoughValve")
        Return result
    End Function

    ''' <author>
    '''    	<name>Tin Pham</name>
    '''    	<date> 2016-08-10 </date>
    ''' </author>
    ''' <summary>
    ''' Open All Other Foreline Valve if they shared rough pump and also close their at previous step
    ''' </summary>
    Public Shared Function OpenAllOtherForelineValve(ByVal equipmentName As String, ByRef strErrMsg As String,
                                                   ByVal strStatusMsg As String,
                                                   ByVal abortedEvent As Threading.ManualResetEvent,
                                                   ByVal isHasCloseLLAForelineValve As Boolean,
                                                   ByVal isHasCloseTMForelineValve As Boolean) As Boolean

        AVPLib.Log.seqLogger.Info("Enter OpenAllOtherForelineValve")
        Dim result As Boolean = True

        Try
            If abortedEvent.WaitOne(0, True) Then
                Utils.ShowStatusMessage(strStatusMsg)
                result = False
                GoTo ExitFunction
            End If

            Dim objLoadLockCtrl As AVPLib.Business.LoadLockController = Nothing
            Dim objTMCtrl As AVPLib.Business.TMController = Nothing
            Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(equipmentName)

            If (roughpumpMachine IsNot Nothing) Then
                ' Open TM Foreline Valve
                If RobotConfigurationValues.TMTURBO_VISIBLE AndAlso isHasCloseTMForelineValve AndAlso
                   (equipmentName <> ConstEnum.Equipments.CassettesModule.ToString) Then

                    If Not OpenTMForelineValve(strErrMsg, strStatusMsg, abortedEvent) Then
                        If Not String.IsNullOrEmpty(strErrMsg) Then
                            result = False
                            GoTo ExitFunction
                        End If
                    End If
                End If

                ' Open LLA Foreline Valve
                If RobotConfigurationValues.LLA_TURBO_VISIBLE AndAlso
                   isHasCloseLLAForelineValve AndAlso
                   (equipmentName <> ConstEnum.Equipments.LoadLockA.ToString) AndAlso
                   roughpumpMachine.IsUsed(ConstEnum.Equipments.LoadLockA.ToString) Then

                    objLoadLockCtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())

                    If objLoadLockCtrl IsNot Nothing AndAlso objLoadLockCtrl.IsLLTurboForelineValveCloseCond() AndAlso objLoadLockCtrl.IsTurboOnCond() Then
                        'wait(5s)
                        If abortedEvent.WaitOne(5000, True) Then
                            Utils.ShowStatusMessage(strStatusMsg)
                            result = False
                            GoTo ExitFunction
                        End If

                        strErrMsg = AVPLib.Business.LLCryoUtility.OpenLLTurboForeLineValveNoWait(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
                        If Not String.IsNullOrEmpty(strErrMsg) Then
                            result = False
                            GoTo ExitFunction
                        End If
                    End If

                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

ExitFunction:
        AVPLib.Log.seqLogger.Info("Leave OpenAllOtherForelineValve")
        Return result
    End Function

    ''' <author>
    '''    	<name>Tinh Le</name>
    '''    	<date> 2023-11-07 </date>
    ''' </author>
    ''' <summary>
    ''' Open TM Foreline Valve
    ''' </summary>
    Public Shared Function OpenTMForelineValve(ByRef strErrMsg As String, ByVal strStatusMsg As String,
                                                   ByVal abortedEvent As Threading.ManualResetEvent) As Boolean

        AVPLib.Log.seqLogger.Info("Enter OpenAllOtherForelineValve")
        Dim result As Boolean = True

        Try
            If abortedEvent.WaitOne(0, True) Then
                Utils.ShowStatusMessage(strStatusMsg)
                result = False
                GoTo ExitFunction
            End If

            Dim objLoadLockCtrl As AVPLib.Business.LoadLockController = Nothing
            Dim objTMCtrl As AVPLib.Business.TMController = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.CassettesModule.ToString())
            Dim roughpumpMachine As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(ConstEnum.Equipments.CassettesModule.ToString)

            If (roughpumpMachine IsNot Nothing) Then
                ' Open TM Foreline Valve
                If RobotConfigurationValues.TMTURBO_VISIBLE AndAlso roughpumpMachine.IsUsed(ConstEnum.Equipments.CassettesModule.ToString) Then
                    If objTMCtrl IsNot Nothing AndAlso objTMCtrl.IsTMTurboForelineValveCloseCond() AndAlso objTMCtrl.IsTurboOnCond() AndAlso objTMCtrl.IsTMMechanicalPumpOn() Then
                        'wait(2s)
                        If abortedEvent.WaitOne(2000, True) Then
                            Utils.ShowStatusMessage(strStatusMsg)
                            result = False
                            GoTo ExitFunction
                        End If

                        strErrMsg = AVPLib.Business.TMCryoUtility.OpenTMTurboForeLineValveNoWait(AVPLib.ConstEnum.Equipments.CassettesModule.ToString())
                        If Not String.IsNullOrEmpty(strErrMsg) Then
                            result = False
                            GoTo ExitFunction
                        End If
                    End If

                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

ExitFunction:
        AVPLib.Log.seqLogger.Info("Leave OpenAllOtherForelineValve")
        Return result
    End Function
#End Region

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2023-13-12</date>
    ''' </author>
    ''' <summary>
    ''' NeedMechenicalPumpWaitAfterTurnOn
    ''' </summary>
    Public Shared Function NeedMechenicalPumpWaitAfterTurnOn(ByVal strEquipmentName As String, ByVal iWaitTimeInSeconds As Integer) As Boolean
        Try
            Dim objMechanicalPump As RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(strEquipmentName)
            If (objMechanicalPump IsNot Nothing AndAlso objMechanicalPump.RoughPumpStatusOnTickCount > 0) Then
                Dim mechanicalPumOnTimeSpan As Integer = Utils.GetTickCountDelta(objMechanicalPump.RoughPumpStatusOnTickCount) / 1000
                If mechanicalPumOnTimeSpan > iWaitTimeInSeconds Then
                    Return False
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return True
    End Function

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2026-05-05</date>
    ''' </author>
    ''' <summary>
    ''' WaitForRoughtPMClose
    ''' </summary>
    Public Shared Function WaitForRoughtPMClose(ByVal EQName4UserReading As String,
                                                ByVal strSequenceName As String,
                                                ByVal abortedEvent As Threading.ManualResetEvent,
                                                ByVal waitTimeout As Int64,
                                                ByRef strErrMsg As String,
                                                ByVal objRoughPumpMachine As RoughPumpMachine) As Boolean
        AVPLib.Log.coreLogger.Debug("Enter WaitForRoughtPMClose")
        Dim span As Int64 = waitTimeout * 1000
        Dim start As Int64 = Environment.TickCount
        Dim blResult As Boolean = False
        Try
            Dim intMaxOfPM As Integer = 3 'default for CX4
            Dim objChamber As DataManagerment.Chamber = Nothing
            For i As Integer = 1 To intMaxOfPM
                Dim objModule As SystemModule = Nothing
                Dim strName As String = ConstEnum.Chamber & i.ToString()
                If objRoughPumpMachine.IsUsed(strName) Then
                    objChamber = DataManagerment.EquipmentManager.GetEquipment(strName)
                End If
            Next

            If objChamber Is Nothing Then
                AVPLib.Log.avpLogger.Error("Cannot find chamber which use rough pump machine: " & objRoughPumpMachine.Name)
                Return False
            End If

            Utils.ShowStatusMessage(String.Format("{0}: Waiting for Rough Valve {1} Close. Timeout {2}s.", EQName4UserReading,
                                                  Utils.ConvertEQName_ToShortName(objChamber.Name), waitTimeout.ToString()), strSequenceName)
            While (Environment.TickCount - start <= span)

                If abortedEvent.WaitOne(0, False) Then
                    AVPLib.Log.coreLogger.Debug("Abored requested.")
                    blResult = False
                    GoTo ExitFunction
                End If

                SyncLock RoughLock
                    If objChamber Is Nothing OrElse objChamber.RoughValveStatus = Equipment.WorkingStatuses.Off Then
                        blResult = True
                        GoTo ExitFunction
                    End If

                End SyncLock

                If abortedEvent.WaitOne(200, False) Then
                    AVPLib.Log.coreLogger.Debug("Abored requested.")
                    blResult = False
                End If
            End While

            If blResult = False Then
                strErrMsg = String.Format(EQName4UserReading & ": Rough Valve of {0} is not close", Utils.ConvertEQName_ToShortName(objChamber.Name))
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.Message)
        End Try
ExitFunction:
        AVPLib.Log.coreLogger.Debug("Leave WaitForRoughtPMClose")
        Return blResult
    End Function

End Class

