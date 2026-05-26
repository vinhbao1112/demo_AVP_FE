Imports System.Data.OleDb
Namespace Business
    Public Class AVPLotDatalog
        Private Shared m_LLALotDatalogName As String = String.Empty
        Private Shared m_LLALotDataPath As String = String.Empty
        Private Shared m_LLATotalAlarm As Integer = 0

        Public Shared Function LLALotDatalogStart(ByVal sLotName As String) As Boolean
            Dim sTime As String = DateTime.Now.ToString("HH.mm.ss")
            m_LLALotDatalogName = sTime & "_" & sLotName
            m_LLALotDataPath = AddLotName(ConstEnum.LoadLockA_STR)
            m_LLATotalAlarm = 0
        End Function

        Public Shared ReadOnly Property LLALogDatalogName()
            Get
                Return m_LLALotDatalogName
            End Get
        End Property

        Public Shared ReadOnly Property LLALotDataPath()
            Get
                Return m_LLALotDataPath
            End Get
        End Property

        Public Shared ReadOnly Property LLATotalAlarm()
            Get
                Return m_LLATotalAlarm
            End Get
        End Property

        Public Shared Function CreateTableInfo(ByVal FileName As String) As Boolean

            'Define the connectors
            Dim oConn As OleDbConnection
            Dim oComm As OleDbCommand
            Dim oConnect, oQuery As String

            'Define connection string
            oConnect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FileName & ";User ID=Admin;Password="

            'Define the query string the creates the table
            oQuery = "CREATE TABLE dtLotDatalogInfo ( ID Counter," & _
            "LotID TEXT(50) NOT NULL," & _
            "LogType TEXT(50) NOT NULL," & _
            "LogInfo TEXT(255) NOT NULL," & _
            "PRIMARY KEY(ID) )"

            ' Instantiate the connectors
            oConn = New OleDbConnection(oConnect)
            oComm = New OleDbCommand(oQuery, oConn)

            'Try connecting and crate the table
            Try

                'Open the connection
                oConn.Open()

                'Perform the Non-Query
                oComm.ExecuteNonQuery()

                'Close the connection
                oConn.Close()

            Catch ex As OleDb.OleDbException
            Catch ex As Exception

                'Show error message and return failure
                MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                Return False

            Finally

                'Dispose the connector objects
                If Not (oConn Is Nothing) Then
                    oConn.Dispose()
                    oConn = Nothing
                End If
                If Not (oComm Is Nothing) Then
                    oComm.Dispose()
                    oComm = Nothing
                End If

            End Try

            'Return success
            Return True

        End Function

        Public Shared Function CreateTableName(ByVal FileName As String) As Boolean

            'Define the connectors
            Dim oConn As OleDbConnection
            Dim oComm As OleDbCommand
            Dim oConnect, oQuery As String

            'Define connection string
            oConnect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FileName & ";User ID=Admin;Password="

            'Define the query string the creates the table
            oQuery = "CREATE TABLE dtLotDatalogName ( ID Counter," & _
            "LotName TEXT(255) NOT NULL," & _
            "DayStart TEXT(255) NOT NULL," & _
            "PRIMARY KEY(ID) )"

            ' Instantiate the connectors
            oConn = New OleDbConnection(oConnect)
            oComm = New OleDbCommand(oQuery, oConn)

            'Try connecting and crate the table
            Try

                'Open the connection
                oConn.Open()

                'Perform the Non-Query
                oComm.ExecuteNonQuery()

                'Close the connection
                oConn.Close()

            Catch ex As OleDb.OleDbException
            Catch ex As Exception

                'Show error message and return failure
                MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                Return False

            Finally

                'Dispose the connector objects
                If Not (oConn Is Nothing) Then
                    oConn.Dispose()
                    oConn = Nothing
                End If
                If Not (oComm Is Nothing) Then
                    oComm.Dispose()
                    oComm = Nothing
                End If

            End Try

            'Return success
            Return True

        End Function
        'return datalob path
        Private Shared Function AddLotName(ByVal ToolName As String) As String
            Dim strDay As String = DateTime.Now.ToString("yyyy.MM.dd")
            Dim sDataPath As String = ContainerDAO.FPath_LotDatalog & "\" & strDay
            Try
                'create folder
                If (Not System.IO.Directory.Exists(sDataPath)) Then
                    System.IO.Directory.CreateDirectory(sDataPath)
                End If

                'create database file
                If (ToolName = ConstEnum.LoadLockA_STR) Then
                    If (Not System.IO.Directory.Exists(sDataPath & "\" & m_LLALotDatalogName & ".mdb")) Then
                        sDataPath = sDataPath & "\" & m_LLALotDatalogName & ".mdb"
                        System.IO.File.Copy(ContainerDAO.FPath_LotDatalog & "\" & "dbLotDatalog.mdb", sDataPath, True)
                    End If
                End If
                Return sDataPath
            Catch ex As Exception
                AVPLib.Log.avpLogger.Debug(ex.Message)
                Return String.Empty
            End Try
        End Function
        'Private Shared Function AddLotName(ByVal ToolName As String, ByVal sDayStart As String) As String
        '    Dim dbPath As String = ContainerDAO.FPath_LotDatalog & "\dbLotDatalog.mdb"
        '    Dim cn As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath & ";")
        '    Try
        '        cn.Open()
        '        Dim strQuery As String = String.Empty
        '        If (ToolName = ConstEnum.LoadLockA_STR) Then
        '            strQuery = "insert into dtLotDatalogName(LotName,DayStart) values('" & m_LLALotDatalogName & "','" & sDayStart & "')"
        '        ElseIf (ToolName = ConstEnum.LoadLockB_STR) Then
        '            strQuery = "insert into dtLotDatalogName(LotName,DayStart) values('" & m_LLBLotDatalogName & "','" & sDayStart & "')"
        '        Else
        '            cn.Close()
        '            Return String.Empty
        '        End If

        '        Dim cmd As OleDbCommand = New OleDbCommand(strQuery, cn)
        '        Dim icount As Integer = cmd.ExecuteNonQuery

        '        Dim strResult As String = String.Empty
        '        If (icount > 0) Then
        '            Dim OleDbCommand2 As OleDbCommand
        '            If (ToolName = ConstEnum.LoadLockB_STR) Then
        '                OleDbCommand2 = New OleDbCommand("SELECT ID FROM dtLotDatalogName WHERE LotName='" & m_LLBLotDatalogName & "'", cn)
        '            Else
        '                OleDbCommand2 = New OleDbCommand("SELECT ID FROM dtLotDatalogName WHERE LotName='" & m_LLALotDatalogName & "'", cn)
        '            End If
        '            Dim myOleDbDataReader As OleDbDataReader = OleDbCommand2.ExecuteReader()
        '            myOleDbDataReader.Read()
        '            strResult = myOleDbDataReader.Item(0).ToString()
        '            myOleDbDataReader.Close()
        '        End If

        '        cn.Close()
        '        Return strResult
        '    Catch ex As Exception
        '        cn.Close()
        '        AVPLib.Log.avpLogger.Debug(ex.Message)
        '        Return String.Empty
        '    End Try
        'End Function

        Public Shared Sub AddLotDatalog(ByVal ToolName As String, ByVal logtype As LogType, ByVal info As String, ByVal isAutotransfer As Boolean)
            If (isAutotransfer = False) Then
                Exit Sub
            End If

            Dim dbPath As String = String.Empty
            If (ToolName = ConstEnum.LoadLockA_STR) Then
                dbPath = m_LLALotDataPath
                If logtype = AVPLib.LogType.Alarm Then
                    m_LLATotalAlarm += 1
                End If
            End If

            Dim cn As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath & ";")
            info = "[" & DateTime.Now.ToString("yyyy.MM.dd_HH.mm.ss") & "] " & info
            Try
                cn.Open()
                Dim strQuery As String = String.Empty
                If (ToolName = ConstEnum.LoadLockA_STR) Then
                    strQuery = "insert into dtLotDatalogInfo(LogType,LogInfo) values('" & logtype.ToString() & "','" & info & "')"
                Else
                    cn.Close()
                    Exit Sub
                End If

                Dim cmd As OleDbCommand = New OleDbCommand(strQuery, cn)
                Dim icount As Integer = cmd.ExecuteNonQuery
                cn.Close()

            Catch ex As Exception
                cn.Close()
                AVPLib.Log.avpLogger.Debug(ex.Message)
            End Try
        End Sub
        '''
        '''RETURN LIST OF LOT DATALOG NAME 
        'Public Shared Function GetLotDatalogName(Optional ByVal sDayStart As String = "") As DataTable
        '    Try
        '        Dim dbPath As String = ContainerDAO.FPath_LotDatalog & "\dbLotDatalog.mdb"
        '        Dim Connection As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath & ";")
        '        Connection.Open()
        '        Dim sSQLQuery As String
        '        If (sDayStart = String.Empty) Then
        '            sSQLQuery = "SELECT * FROM dtLotDatalogName ORDER BY ID DESC"
        '        Else
        '            sSQLQuery = "SELECT * FROM dtLotDatalogName WHERE DayStart='" & sDayStart & "' ORDER BY ID DESC"
        '        End If

        '        Dim da As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sSQLQuery, Connection)
        '        Dim dt As New DataTable()
        '        da.Fill(dt)
        '        Connection.Close()
        '        Return dt
        '    Catch
        '        Return Nothing
        '    End Try
        'End Function

        '''
        '''RETURN LIST OF LOT DATALOG NAME 
        Public Shared Function GetLotDatalogName(Optional ByVal sDayStart As String = "") As DataTable
            Try
                Dim table As DataTable = CreateLotdataNameTable()
                If (sDayStart = String.Empty) Then
                    Dim Root As New System.IO.DirectoryInfo(ContainerDAO.FPath_LotDatalog)
                    Dim Dirs As System.IO.DirectoryInfo() = Root.GetDirectories("*.*")

                    For Each Dir As System.IO.DirectoryInfo In Dirs
                        Dim aryFi As IO.FileInfo() = Dir.GetFiles("*.mdb")
                        Dim fi As IO.FileInfo

                        For Each fi In aryFi
                            Dim Row As DataRow = table.NewRow()
                            Row.Item("LotName") = fi.Name.Replace(".mdb", "")
                            Row.Item("LotDataPath") = fi.FullName
                            table.Rows.Add(Row)
                        Next
                    Next


                Else
                    If (System.IO.Directory.Exists(ContainerDAO.FPath_LotDatalog & "\" & sDayStart)) Then
                        Dim Dir As New IO.DirectoryInfo(ContainerDAO.FPath_LotDatalog & "\" & sDayStart)

                        Dim aryFI As IO.FileInfo() = Dir.GetFiles("*.mdb")
                        Dim fi As IO.FileInfo

                        For Each fi In aryFI
                            Dim Row As DataRow = table.NewRow()
                            Row.Item("LotName") = fi.Name.Replace(".mdb", "")
                            Row.Item("LotDataPath") = fi.FullName
                            table.Rows.Add(Row)
                        Next
                    End If
                End If
                Return table
            Catch
                Return Nothing
            End Try
        End Function
        '''
        '''RETURN LIST OF LOT DATALOG NAME 
        Public Shared Function GetLotDatalogInfo(ByVal DataPath As String) As DataTable
            Try
                Dim dbPath As String = DataPath
                Dim Connection As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath & ";")
                Connection.Open()

                Dim sSQLQuery As String = "SELECT LogType,LogInfo FROM dtLotDatalogInfo ORDER BY ID"
                Dim da As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sSQLQuery, Connection)
                Dim dt As New DataTable()
                da.Fill(dt)
                Connection.Close()
                Return dt
            Catch
                Return Nothing
            End Try
        End Function
        '''
        '''DELETE OLD DATALOG 
        Public Shared Function DeleteOlderData(ByVal day As String) As Boolean
            Try
                Dim dbPath As String = ContainerDAO.FPath_LotDatalog & "\dbLotDatalog.mdb"
                Dim Connection As OleDbConnection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath & ";")
                Connection.Open()

                Dim sSQLQuery As String = "DELETE *  FROM dtLotDatalogName WHERE  DayStart <'" & day & "'"
                Dim da As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sSQLQuery, Connection)

                sSQLQuery = "DELETE FROM dtLotDatalogInfo WHERE NOT EXISTS( SELECT * FROM dtLotDatalogName " & _
                "WHERE dtLotDatalogInfo.LotID = dtLotDatalogName.ID)"
                Dim da2 As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter(sSQLQuery, Connection)

                Connection.Close()
                Return True
            Catch
                Return False
            End Try
        End Function

        Private Shared Function CreateLotdataNameTable() As DataTable
            Dim Table As DataTable = New DataTable("LotDatalogName")
            Try
                Dim Name As DataColumn = New DataColumn("LotName")
                Name.DataType = System.Type.GetType("System.String")
                Table.Columns.Add(Name)


                Dim LotDataPath As DataColumn = New DataColumn("LotDataPath")
                LotDataPath.DataType = System.Type.GetType("System.String")
                Table.Columns.Add(LotDataPath)
                Return Table
            Catch
                Table = Nothing
                Return Table
            End Try
        End Function
    End Class
End Namespace