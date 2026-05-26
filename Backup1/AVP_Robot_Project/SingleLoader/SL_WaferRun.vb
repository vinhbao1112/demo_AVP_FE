Imports ZedGraph
Imports System.IO
Imports System.Text
Imports System.Xml
Imports AVPLib.ConstEnum
Imports AVPLib.ContainerDAO
Imports AVP_Robot_Project.ConstantAndEnum
Imports System
Imports System.Globalization
Imports AVPControls

Public Class SL_WaferRun
    Inherits WaferRun
    Protected m_marshaller_for_UpdateGrid As DelegateMarshaler
    
    Private Function MakeDatatable() As DataTable
        Dim dtResult As DataTable
        dtResult = New DataTable("WaferRunFileList")

        Dim dtCol As DataColumn = Nothing
        dtCol = New DataColumn(FILE_NAME)
        dtResult.Columns.Add(dtCol)

        dtCol = New DataColumn("INDEX")
        dtCol.DataType = System.Type.GetType("System.String")
        dtResult.Columns.Add(dtCol)
        Return dtResult
    End Function
    Private Sub BuildData4Datatable(ByRef dt As DataTable, ByVal strFolder As String, ByVal strShortDate As String)
        Dim WRData As WaferRunData = Nothing
        Dim arrFile As String() = Nothing
        arrFile = System.IO.Directory.GetFiles(strFolder, "*.csv")
        If arrFile IsNot Nothing AndAlso arrFile.Length > 0 Then
            For Each filename As String In arrFile
                If System.IO.File.Exists(filename) Then
                    Dim strFullPathFile As String = filename
                    filename = AVPLib.Utils.GetFileName(filename, True)
                    ''push files into data structure
                    'ABC 2010_09_24 01.csv
                    Dim arrFileName As String()
                    arrFileName = filename.Split(New String() {SPACE_STRING}, StringSplitOptions.RemoveEmptyEntries)
                    Dim strIndex As String = String.Empty
                    strIndex = arrFileName(arrFileName.Length - 1)
                    If Not m_hstWaferRunData.ContainsKey(filename) Then
                        WRData = New WaferRunData
                        WRData.PrefixFile = filename
                        WRData.CreatedTime = strIndex
                        ''this Wafer Run use only in Single Loader => use Chamber1 
                        ''if Wafer Run use in CX for IBE => this code is wrong
                        WRData.ListOfPM.Add(0, AVPLib.Utils.chamberID2ChamberName(Equipments.Chamber1.ToString()))
                        'push into hashtable
                        m_hstWaferRunData.Add(filename, WRData)
                        m_newWRDATA_Added = WRData
                    End If
                End If
            Next
            For Each item As String In m_hstWaferRunData.Keys
                If item.Contains(strShortDate) Then
                    'push into DataTable
                    WRData = m_hstWaferRunData.Item(item)
                    If WRData IsNot Nothing Then
                        Dim newRow As DataRow
                        newRow = m_dtWaferRunFile.NewRow
                        newRow(FILE_NAME) = WRData.PrefixFile
                        newRow("INDEX") = WRData.CreatedTime
                        m_dtWaferRunFile.Rows.Add(newRow)
                    End If
                End If
            Next
            If Me.InvokeRequired Then
                Invoke(New UpdateRunDataFilesGrid(AddressOf UpdateGUI), m_dtWaferRunFile)
            Else
                Me.dgvWFList.DataSource = m_dtWaferRunFile
                Me.dgvWFList.Columns(FILE_NAME).Width = 400
                Me.dgvWFList.Columns("INDEX").Visible = False
                Me.dgvWFList.Refresh()
                RefreshFilter()
            End If
        End If
    End Sub
    ''overload this sub for Invoke event from backend -> when finish Logging to file
    Public Overloads Sub GetAllWaferRunDataFile(ByVal val As Object)
        Try
            Dim strShortDate As String = Format(dtFilter.Value, "yyyy_MM_dd")
            Dim strFolder As String = AVPLib.ContainerDAO.FPath_RunDataOfWafer

            'clear data table
            If m_dtWaferRunFile IsNot Nothing Then
                m_dtWaferRunFile.Rows.Clear()
            End If

            'folder is nothing
            If Not System.IO.Directory.Exists(strFolder) Then
                RefreshFilter()
                Exit Sub
            End If

            'some else
            If m_dtWaferRunFile Is Nothing Then
                m_dtWaferRunFile = MakeDatatable()
            End If

            BuildData4Datatable(m_dtWaferRunFile, strFolder, strShortDate)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overrides Sub RefreshFilter()
        Try
            If m_dtWaferRunFile IsNot Nothing AndAlso m_dtWaferRunFile.Rows.Count > 0 Then
                dgvWFList.Sort(dgvWFList.Columns("INDEX"), ComponentModel.ListSortDirection.Descending)
                Dim curRowSelected As Integer = dgvWFList.SelectedCells(0).RowIndex
                '#07/30/2011 
                '#- AVP->Waferrun.  If user is view old wafer run and there is a new update on currently run,  user will lose 
                '# the current view because software default to the latest run update page.
                '#Begin fix:
                If m_IsUpdateWaferRunDetails Then
                    If curRowSelected >= 0 Then
                        RowSelectedChanged(curRowSelected)
                    End If
                Else
                    For Each dtRow As Windows.Forms.DataGridViewRow In dgvWFList.Rows
                        If dtRow.Cells("File Name").Value = m_KeyWRFileNameUseForUpdateWRDetails Then
                            dgvWFList.Rows(dtRow.Index).Selected = True
                            RowSelectedChanged(dtRow.Index)
                        End If
                    Next
                End If
                '#End fix.
            Else
                dgvWFList.DataSource = Nothing
                Me.tabWaferRun.TabPages.Clear()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overrides Sub OpenDataOn_SelectedTab(ByVal tabpageCtl As TabPage)
        Try
            Dim objSampledata As SL_SampleData = CType(tabpageCtl.Controls.Item(0), SL_SampleData)
            Dim strPrefixFile As String = tabWaferRun.SelectedTab.Tag
            If Not System.IO.File.Exists(strPrefixFile & ".csv") Then
                AVPLib.Log.avpLogger.Error("Can not Open File : " & strPrefixFile & ".csv")
            End If
            dgvWFList.Enabled = False
            If String.IsNullOrEmpty(objSampledata.DataFile) Then
                objSampledata.DataFile = strPrefixFile & ".csv"
                tabWaferRun.SelectedTab.Controls.Add(objSampledata)
                objSampledata.OpenWRDataFile(objSampledata.DataFile)
                AddHandler objSampledata.FinishLoadingDataFile, AddressOf FinishLoadingFile
            Else
                dgvWFList.Enabled = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''Do we need to create Tab Page? we have only one tab and must be only one
    Protected Overrides Sub CreateTabPages(ByVal ListOfPMRelevant As SortedDictionary(Of Integer, String), ByVal PrefixFile As String, ByVal strFolderName As String, Optional ByVal strWaferID As String = "")
        Try
            If tabWaferRun.TabPages.Count > 0 Then
                Dim tabPage As TabPage = tabWaferRun.TabPages.Item(0)
                If tabPage.Tag IsNot Nothing AndAlso tabPage.Tag.ToString().Contains(PrefixFile) Then ''-> update current tab
                    For Each pair As KeyValuePair(Of Integer, String) In ListOfPMRelevant
                        Dim blnCreateTab As Boolean = True
                        For Each tabitem As TabPage In tabWaferRun.TabPages
                            If tabitem.Text = pair.Value Then
                                blnCreateTab = False
                            End If
                        Next
                        If blnCreateTab Then
                            Dim newTabPage As New System.Windows.Forms.TabPage
                            newTabPage.Text = pair.Value
                            newTabPage.Tag = FPath_RunDataOfWafer & "\" & PrefixFile
                            tabWaferRun.Controls.Add(newTabPage)
                            Dim objSampledata As New SL_SampleData
                            newTabPage.Controls.Add(objSampledata)
                            objSampledata.Dock = DockStyle.Fill
                            objSampledata.Font = New Font("Times New Roman", 12, FontStyle.Regular)
                            tabWaferRun.SelectedTab = newTabPage ''select the newest
                        End If
                    Next
                    Exit Try
                End If
            End If
            Me.tabWaferRun.Controls.Clear()
            For Each pair As KeyValuePair(Of Integer, String) In ListOfPMRelevant ''-> create new tab
                Dim tabpage As New System.Windows.Forms.TabPage
                tabpage.Text = pair.Value
                tabpage.Tag = FPath_RunDataOfWafer & "\" & PrefixFile
                tabWaferRun.Controls.Add(tabpage)
                Dim objSampledata As New SL_SampleData
                tabpage.Controls.Add(objSampledata)
                objSampledata.Dock = DockStyle.Fill
                objSampledata.Font = New Font("Times New Roman", 12, FontStyle.Regular)
                Me.tabWaferRun.SelectedTab = tabpage ''select the newest
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        If tabWaferRun.TabPages.Count > 0 Then
            OpenDataOn_SelectedTab(tabWaferRun.SelectedTab)
        End If
    End Sub

    Public Sub FinishCollectingData(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            '#07/30/2011 
            '#- AVP->Waferrun.  If user is view old wafer run and there is a new update on currently run,  user will lose 
            '# the current view because software default to the latest run update page.
            '#Begin fix:
            If (dgvWFList.Rows.Count > 0) AndAlso (dgvWFList.SelectedRows(0) IsNot Nothing) Then
                m_IsUpdateWaferRunDetails = False
                m_KeyWRFileNameUseForUpdateWRDetails = dgvWFList.SelectedRows(0).Cells("File Name").Value
            End If
            '#End fix.
            m_marshaller_for_UpdateGrid.Invoke(Of Object)(New Threading.SendOrPostCallback(AddressOf GetAllWaferRunDataFile), Nothing)

            m_IsUpdateWaferRunDetails = True
            m_KeyWRFileNameUseForUpdateWRDetails = String.Empty
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub SL_WaferRun_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim strShortDate As String = Format(dtFilter.Value, "yyyy_MM_dd")
            m_hstWaferRunData = New Hashtable()

            GetAllWaferRunDataFile(Nothing)

            Dim defaultfile As String = String.Empty
            'set default file
            If (dgvWFList.RowCount > 0) Then
                defaultfile = dgvWFList.Item(FILE_NAME, 0).Value
            End If

            'load default file
            If Not String.IsNullOrEmpty(defaultfile) Then
                Dim objwaferRunData As WaferRunData = m_hstWaferRunData.Item(defaultfile)
                If objwaferRunData IsNot Nothing Then
                    'dgvWFList.Enabled = False
                    CreateTabPages(objwaferRunData.ListOfPM, defaultfile, strShortDate)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overrides Sub dtFilter_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFilter.ValueChanged
        Try
            GetAllWaferRunDataFile(Nothing)
            If dgvWFList.Rows.Count <= 0 Then
                tabWaferRun.TabPages.Clear()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        m_marshaller_for_UpdateGrid = DelegateMarshaler.Create()
        m_hstWaferRunData = New Hashtable()

    End Sub
End Class




