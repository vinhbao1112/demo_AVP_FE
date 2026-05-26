Public Class Connection
#Region "Class Constants & Variables"
    Private Shared m_ConectionAccess As System.Data.OleDb.OleDbConnection
    Private Shared m_LastDayAccessLog As String
    Private Shared m_StreamWriter As System.IO.StreamWriter
    Private Shared m_LastDayFileLog As String
    Private Shared m_ListConnectionAccess As ArrayList
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' make ConnectionAccess
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property ConnectionAccess() As System.Data.OleDb.OleDbConnection
        Get
            Try

                Dim bCreateNew As Boolean = (m_LastDayAccessLog Is Nothing)
                If (Not bCreateNew) Then
                    Dim lastCurrentDate As Date = Convert.ToDateTime(m_LastDayAccessLog)
                    Dim span As TimeSpan = DateTime.Now - lastCurrentDate
                    If (span.Days >= 1) Then
                        bCreateNew = True
                    End If
                End If
                If (bCreateNew) Then
                    If (m_ConectionAccess IsNot Nothing) Then
                        m_ConectionAccess.Close()
                        m_ConectionAccess = Nothing
                    End If
                    m_LastDayAccessLog = DateTime.Today.ToString("MM/dd/yyyy")
                    Dim sDatabase As String = Utils.getDatabase()
                    Dim sUsername As String = ""
                    Dim sPwd As String = ""
                    Dim connStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sDatabase + ";User Id=" + sUsername + ";Password=" + sPwd + ";"
                    m_ConectionAccess = New System.Data.OleDb.OleDbConnection(connStr)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return m_ConectionAccess
        End Get
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Get List Connection of Access
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property ConnectionListAccess() As ArrayList
        Get
            Dim ListAccess As ArrayList = New ArrayList
            Try
                Dim listFiles As String() = Utils.getListDatabase()
                Dim isLoad As Boolean = m_ListConnectionAccess Is Nothing
                If isLoad = False Then
                    isLoad = FindDiff_ConnectionFile(listFiles, m_ListConnectionAccess)
                End If

                If isLoad Then
                    For Each file As String In listFiles
                        Dim sDatabase As String = file
                        Dim sUsername As String = ""
                        Dim sPwd As String = ""
                        Dim connStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sDatabase + ";User Id=" + sUsername + ";Password=" + sPwd + ";"
                        ListAccess.Add(New System.Data.OleDb.OleDbConnection(connStr))
                    Next
                    m_ListConnectionAccess = ListAccess
                Else
                    ListAccess = m_ListConnectionAccess
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return ListAccess
        End Get
    End Property

    'return true: if new file is not exist in ListAccess
    Private Shared Function FindDiff_ConnectionFile(ByVal ListFiles As String(), ByVal ListAccess As ArrayList) As Boolean
        If ListFiles.Length <> ListAccess.Count Then
            Return True
        End If
        For i As Integer = 0 To ListAccess.Count - 1
            If Array.IndexOf(ListFiles, CType(ListAccess.Item(i), System.Data.OleDb.OleDbConnection).DataSource) < 0 Then
                Return True
            End If
        Next
        Return False
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' ConnectionFileLog
    ''' 1. Everyday create new file.
    ''' 2. In case, Existed File insert into existed file.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property ConnectionFileLog() As System.IO.StreamWriter
        Get
            Try
                If (m_LastDayFileLog Is Nothing Or m_LastDayFileLog <> DateTime.Today.ToString("MM/dd/yyyy")) Then
                    m_LastDayFileLog = DateTime.Today.ToString("MM/dd/yyyy")
                    m_StreamWriter = Nothing
                    m_StreamWriter = New System.IO.StreamWriter(Utils.getLogFile(), True, System.Text.Encoding.UTF8)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return m_StreamWriter
        End Get
    End Property
#End Region
End Class
