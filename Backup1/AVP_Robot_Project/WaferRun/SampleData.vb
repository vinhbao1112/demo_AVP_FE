Imports ZedGraph
Imports System.IO
Imports System.Text
Imports System.Xml
Imports AVPLib.ConstEnum
Imports AVPLib.ContainerDAO
Imports AVPLib
Imports AVP_Robot_Project.ConstantAndEnum
Imports System
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class SampleData
    Protected Const GRAPH_VIEW As String = "Graph View"
    Protected Const STEP_VIEW As String = "Step View"
    Protected Const COL_START As String = "Start"
    Protected Const COL_REALSTEP As String = "Real Step"
    Protected Const COL_TOTAL_SECONDS_STEP As String = "Total Seconds"
    Protected Const COL_STEPNO As String = "StepNo"
    Protected Const MAX_COLOR As Integer = 255
    Protected Const XPATH_CHAMBER As String = "/RunData/ChamberList/Chamber"
    Protected Const XPATH_STEPLIST As String = "/RunData/ChamberList/Chamber/StepList"
    Const TIMES_COLUMNS As String = "Time"
    Const SAMPLE_COLUMNS As String = "Sample"
    Const WAFERID As String = "WaferID"
    Const RECIPE_NAME As String = "RecipeName"
    Const STEP_NO As String = "Step No"
    Const START_TIME As String = "Start Time"
    Const START_TIME_STEP As String = "Start Time Step"
    Const TOTAL_SECONDS_STEP As String = "Total Seconds Step"
    Const TOTAL_SECONDS_RECIPE As String = "Total Seconds Recipe"
    Const NUMBER_COLUMN_OF_STEPNO_ROW_OLDFORMAT As Integer = 2

    Const OLD_DATE_TIME_FORMAT As String = "yyyy_MM_dd_HH_mm_ss_fff"
    Const NEW_DATE_TIME_FORMAT As String = "MM/dd/yyyy HH:mm:ss.fff"
    Const DATARUN_FOLDER As String = "DataRun"
    Const ENDPOINT_FOLDER As String = "EndPointData"

    Private m_rndObj As New Random 'get random color
    Private m_blnClickNotShowGraph As Boolean = False 'flag to set image button up or down
    Protected m_hstStepData As Hashtable = Nothing 'store stepNo as key, SampleList as data
    Private m_strYAxisTitle As String
    Private m_strXAxisTitle As String
    Private m_strTitleOfGraph As String
    Protected OpenFile_worker As ComponentModel.BackgroundWorker = Nothing 'worker for Open File
    Protected Delegate Sub ChangeProgressBarHandler(ByVal percentage As Integer)
    Private m_strdataFile As String = Nothing '
    Private m_strCompareFile As String = Nothing '

    Private m_hstCompareStepData As Hashtable = Nothing 'store stepNo as key, SampleList as data
    Protected m_hstCompareStepInfo As Hashtable = Nothing 'store stepNo as key, step information as data

    Protected m_hstStepInfo As Hashtable = Nothing 'store stepNo as key, step information as data

    Private m_strSelectedStep As String = String.Empty
    Public Event FinishLoadingDataFile As EventHandler

    Public PMColList As Hashtable

    Protected m_dtWaferRunSample As DataTable = Nothing 'store Wafer Run Sample 
    Protected m_dtWaferRunStep As DataTable = Nothing 'store waferRun Step
    Protected m_xmlDoc As XmlDocument = Nothing
    Private m_strChamberName As String = String.Empty
    Private m_lstAllColumns As List(Of String) = Nothing
    Private m_strPrefixFile As String = String.Empty
    Private m_RecipeInfo As RecipeInfo = Nothing
    Private m_arrHidenFiles As String() = Nothing

    Private m_NumOfThread As Integer = 0
    Private m_lockObj As New Object
#Region "Property"
    Public Property PrefixFile() As String
        Get
            Return m_strPrefixFile
        End Get
        Set(ByVal value As String)
            m_strPrefixFile = value
        End Set
    End Property

    Public Property DataFile() As String
        Get
            Return m_strdataFile
        End Get
        Set(ByVal value As String)
            m_strdataFile = value
        End Set
    End Property

    Public Property CompareDataFile() As String
        Get
            Return m_strCompareFile
        End Get
        Set(ByVal value As String)
            m_strCompareFile = value
        End Set
    End Property

    Private m_finishLoad As Boolean = False
    Public Property FinishLoad() As Boolean
        Get
            Return m_finishLoad
        End Get
        Set(ByVal value As Boolean)
            m_finishLoad = value
        End Set
    End Property

    Private m_RecipeName As String = String.Empty
    Public Property RealRecipeName() As String
        Get
            Return m_RecipeName
        End Get
        Set(ByVal value As String)
            m_RecipeName = value
        End Set
    End Property

  Public Property X_Axis_Title() As String
        Get
            Return m_strXAxisTitle
        End Get
        Set(ByVal value As String)
            m_strXAxisTitle = value
            Me.zgraphFromFile.GraphPane.XAxis.Title.Text = m_strXAxisTitle
        End Set
    End Property

    Public Property TitleOfGraph() As String
        Get
            Return m_strTitleOfGraph
        End Get
        Set(ByVal value As String)
            m_strTitleOfGraph = value
            Me.zgraphFromFile.GraphPane.Title.Text = m_strTitleOfGraph
        End Set
    End Property
#End Region

#Region "Event"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''TreeView After Check 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClearSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSelected.Click
        If btnClearSelected.Text = "Clear Selected" Then
            Me.RemoveAllSelectedNodeFromGraph()
        ElseIf btnClearSelected.Text = "Compared" Then
            DoCompareFile()
        End If
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''TreeView After Check 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tvStepList_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) _
    Handles tvStepList.AfterCheck
        Try
            If e.Node.Checked = True And e.Node.Parent IsNot Nothing Then
                Dim strStepNo As String = e.Node.Parent.Text
                Dim dicSampleData As Dictionary(Of String, List(Of DataValue)) = m_hstStepData(strStepNo)
                ShowGraphDataFromStepNo(e.Node.Text, dicSampleData)
                Me.zgraphFromFile.Refresh()
            ElseIf e.Node.Checked = False And e.Node.Parent IsNot Nothing Then
                Me.RemoveSelectedNodeFromGraph(e.Node.Text)
                Me.zgraphFromFile.Refresh()
            End If
            Me.zgraphFromFile.GraphPane.XAxis.Title.Text = "X Axis(Seconds)"
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''TreeView After Check 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvStep_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
                 Handles dgvStep.CellClick
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                '2013-06-06 Tin Pham: support cancel data
                If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                    Exit Try
                End If
                '
                pnlLoadingStatus.Visible = False
                dgvData.DataSource = Nothing
                dgvData.Columns.Clear()
                If dgvStep.RowCount <= 0 Then
                    Exit Sub
                End If
                m_strSelectedStep = dgvStep.Item(COL_STEPNO, e.RowIndex).Value
                If String.IsNullOrEmpty(m_strSelectedStep) Then
                    Exit Sub
                End If
                Dim dicSampleData As Dictionary(Of String, List(Of DataValue)) = m_hstStepData(m_strSelectedStep)
                ShowWaferSampleDataToGrid(dicSampleData, False, m_dtWaferRunSample)
                'If Not String.IsNullOrEmpty(m_strCompareFile) Then
                '    Dim dtCompareValue As New DataTable
                '    m_strSelectedStep = dgvStep.Item(COL_STEPNO, e.RowIndex).Value
                '    dicSampleData = m_hstCompareStepData(m_strSelectedStep)
                '    ShowWaferSampleDataToGrid(dicSampleData, True, dtCompareValue)
                '    'MergeDataTable(dtCompareValue)
                'End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Open File"
    Public Sub OpenWRDataFile(ByVal FullPath_filename As String)
        If OpenFile_worker.IsBusy Then
            OpenFile_worker.CancelAsync()
        End If
        m_strdataFile = FullPath_filename
        m_finishLoad = False
        Me.pnlLoadingStatus.Visible = True
        If Not OpenFile_worker.IsBusy Then
            OpenFile_worker.RunWorkerAsync()
        End If
    End Sub
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-06-03</date>
    ''' </author>
    ''' <summary>
    ''' CancelDataFile
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CancelDataFile()
        If OpenFile_worker IsNot Nothing Then
            OpenFile_worker.CancelAsync()
        End If
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''TreeView After Check 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OnProgressChanged(ByVal sender As Object, ByVal e As ComponentModel.ProgressChangedEventArgs)
        Try
            ChangeProgressBar(e.ProgressPercentage)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''TreeView After Check 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Try
            If e.Cancelled Then
                Return
            End If
            'After Worker read file XML to Hashtable
            If m_strdataFile IsNot Nothing AndAlso m_strdataFile.EndsWith(STR_CSV_EXT) Then
                ShowInfoToGUI()
            Else
                ShowXMLInfoToGUI()
            End If

            If (m_hstStepData IsNot Nothing) Then
                ShowWaferRunStepToGrid(m_hstStepData, False)
                m_finishLoad = True
                m_blnClickNotShowGraph = True
                btnShowGraph_Click(sender, Nothing)
                Dim CellEvent As New DataGridViewCellEventArgs(0, 0) 'load as default view
                dgvStep_CellClick(sender, CellEvent)
                btnClearSelected.Enabled = True
                RaiseEvent FinishLoadingDataFile(sender, Nothing)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub ExportDataFile_Complete(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Try
            SyncLock m_lockObj
                If m_NumOfThread > 0 Then
                    m_NumOfThread -= 1
                End If
            End SyncLock
            If m_NumOfThread = 0 AndAlso btnExpAll.Enabled = False Then
                Utils.ShowAVPMessageBox("Exporting data is successful.", "Exporting data", MessageBoxIcon.Information, _
                                            AVPMessageBox.AVPMessageBoxButton.OK)
                btnExpAll.Enabled = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''TreeView After Check 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OnWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        If Me.OpenFile_worker.CancellationPending Or String.IsNullOrEmpty(m_strdataFile) Then
            e.Cancel = True
            Return
        End If
        ' Do not access the form's BackgroundWorker reference directly.
        ' Instead, use the reference provided by the sender parameter.
        ' Dim bw As ComponentModel.BackgroundWorker = CType(sender, ComponentModel.BackgroundWorker)
        LoadDataFile(m_strdataFile, m_hstStepData, m_hstStepInfo, True) 'get xmldoc for show GU
        If Me.OpenFile_worker.CancellationPending Then
            e.Cancel = True
        End If
    End Sub

    Private Sub OnExportDataFile(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim listOfArg As List(Of String) = e.Argument
        If listOfArg Is Nothing OrElse listOfArg.Count < 2 Then
            Exit Sub
        End If
        ExportAllParametersInFile(listOfArg.Item(0), listOfArg.Item(1))
        'LoadDataFile_For_Export(listOfArg.Item(0), listOfArg.Item(1)) 'get xmldoc for show GU
    End Sub


#End Region

#Region "Compare File"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''Open Compare file -> call worker to load file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DoCompareFile()
        Try
            Dim dlgOpenFile As New OpenFileDialog()
            dlgOpenFile.ShowReadOnly = True
            dlgOpenFile.Filter = "XML (*.xml;)|*.XML;|All files (*.*)|*.*"

            If dlgOpenFile.ShowDialog() = DialogResult.OK Then
                'm_strCompareFile = dlgOpenFile.FileName
                ''if the same file 
                'If m_strCompareFile = m_strdataFile Then
                '    Exit Sub
                'End If
                'Dim fileName As String = AVPLib.Utils.GetFileName(m_strCompareFile, True)
                'Dim arrFileInfo As String() = fileName.Split(SPACE_STR)
                'If arrFileInfo.Length >= 3 Then
                '    arrFileInfo(2) = arrFileInfo(2).Substring(0, arrFileInfo(2).IndexOf("_")) 'get chamber name
                '    'if not the same Chamber
                '    If Not arrFileInfo(2) = btnChamber1.Text Then
                '        Utils.ShowAVPMessageBox("Can not compare different Chamber", "Compare Fail", MessageBoxIcon.Warning)
                '        Exit Sub
                '    End If
                '    Dim xmldoc As New XmlDocument
                '    xmldoc.Load(m_strCompareFile)
                '    Dim ChamberNode As XmlNode = xmldoc.SelectSingleNode(XPATH_CHAMBER)
                '    Dim childNode As XmlNode = ChamberNode.FirstChild.SelectNodes("RecipeName").Item(0)
                '    'if not the same RecipeName
                '    If childNode IsNot Nothing AndAlso lblRecipe.Text = childNode.InnerText Then
                '        Utils.ShowAVPMessageBox("Can not compare different Recipe", "Compare Fail", MessageBoxIcon.Warning)
                '        Exit Sub
                '    End If
                '    'if worker not busy
                '    If Not CompareFile_worker.IsBusy Then
                '        btnClearSelected.Enabled = False
                '        CompareFile_worker.RunWorkerAsync()
                '    End If
                'End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private Sub OnProgressCompareChanged(ByVal sender As Object, ByVal e As ComponentModel.ProgressChangedEventArgs)
        Try
            Invoke(New ChangeProgressBarHandler(AddressOf ChangeProgressBar), e.ProgressPercentage)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''TreeView After Check 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Worker_RunCompareWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Try
            'If (m_hstCompareStepData IsNot Nothing) Then
            '    ShowWaferRunStepToGrid(m_hstCompareStepData, True)
            '    Dim dtCompareValue As New DataTable
            '    m_strSelectedStep = dgvStep.Item(COL_STEPNO, 0).Value
            '    Dim dicSampleData As Dictionary(Of String, List(Of DataValue)) = m_hstCompareStepData(m_strSelectedStep)
            '    ShowWaferSampleDataToGrid(dicSampleData, True, dtCompareValue)
            '    MergeDataTable(dtCompareValue)
            '    btnClearSelected.Enabled = True
            'End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    '' <author>
    ''    	<name> Le Hieu Truc </name>
    ''    	<date> 2010-Apr-4</date>
    '' </author>
    '' <summary>
    ''Merging Data Table
    '' </summary>
    '' <param name="sender"></param>
    '' <param name="e"></param>
    '' <remarks></remarks>
    Private Sub MergeDataTable(ByVal dtCompareValue As DataTable)
        Try
            'If m_dtWaferRunSample IsNot Nothing AndAlso dtCompareValue IsNot Nothing Then
            '    Dim dtMerge As New DataTable("MergeCompareAndCurrent")
            '    dgvData.DataSource = Nothing
            '    ''create column
            '    For i As Integer = 0 To m_dtWaferRunSample.Columns.Count - 1
            '        Dim newCol As DataColumn = Nothing
            '        newCol = New DataColumn(m_dtWaferRunSample.Columns(i).ColumnName)
            '        dtMerge.Columns.Add(newCol)
            '        newCol = New DataColumn(dtCompareValue.Columns(i).ColumnName & " ")
            '        dtMerge.Columns.Add(newCol)
            '    Next
            '    ''insert data
            '    Dim intTotalRow As Integer = 0
            '    Dim intRemainRow As Integer = 0
            '    If m_dtWaferRunSample.Rows.Count >= dtCompareValue.Rows.Count Then
            '        intTotalRow = dtCompareValue.Rows.Count
            '        intRemainRow = m_dtWaferRunSample.Rows.Count - dtCompareValue.Rows.Count
            '    ElseIf m_dtWaferRunSample.Rows.Count <= dtCompareValue.Rows.Count Then
            '        intTotalRow = m_dtWaferRunSample.Rows.Count
            '        intRemainRow = dtCompareValue.Rows.Count - m_dtWaferRunSample.Rows.Count
            '    End If
            '    For j As Integer = 0 To intTotalRow - 1
            '        Dim colIndex As Integer = 0
            '        Dim newRow As DataRow = dtMerge.NewRow
            '        For k As Integer = 0 To m_dtWaferRunSample.Columns.Count - 1
            '            newRow(colIndex) = m_dtWaferRunSample.Rows(j)(k)
            '            newRow(colIndex + 1) = dtCompareValue.Rows(j)(k)
            '            colIndex += 2
            '        Next
            '        dtMerge.Rows.Add(newRow)
            '        dtMerge.AcceptChanges()
            '    Next
            '    ''if 2 datatable has different size
            '    If intRemainRow > 0 Then
            '        Utils.ShowAVPMessageBox("The compare sample file is less or longer than the current file: " & intRemainRow.ToString() & " record", "Compare File", MessageBoxIcon.Warning)
            '        For j As Integer = 0 To intRemainRow - 1
            '            Dim colIndex As Integer = 0
            '            Dim newRow As DataRow = dtMerge.NewRow
            '            If m_dtWaferRunSample.Rows.Count > dtCompareValue.Rows.Count Then
            '                For k As Integer = 0 To m_dtWaferRunSample.Columns.Count - 1
            '                    newRow(colIndex) = m_dtWaferRunSample.Rows(j)(k)
            '                    newRow(colIndex + 1) = "miss"
            '                    colIndex += 2
            '                Next
            '            ElseIf m_dtWaferRunSample.Rows.Count < dtCompareValue.Rows.Count Then
            '                For k As Integer = 0 To m_dtWaferRunSample.Columns.Count - 1
            '                    newRow(colIndex) = "miss"
            '                    newRow(colIndex + 1) = dtCompareValue.Rows(j)(k)
            '                    colIndex += 2
            '                Next
            '            End If
            '            dtMerge.Rows.Add(newRow)
            '            dtMerge.AcceptChanges()
            '        Next
            '    End If
            '    dgvData.DataSource = dtMerge
            '    ''set style for dataGrid
            '    For k As Integer = 0 To dgvData.Columns.Count - 1
            '        dgvData.Columns(k + 1).DefaultCellStyle.ForeColor = System.Drawing.Color.DarkRed
            '        dgvData.Columns(k + 1).HeaderCell.Style.ForeColor = Color.DarkRed
            '        k += 1
            '    Next
            '    dgvData.Refresh()
            'End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''TreeView After Check 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChangeProgressBar(ByVal percentage As Integer)
        If percentage >= 100 Then
            Me.psgBar.Value = 0 'reset
        Else
            Me.psgBar.Value = percentage
        End If
    End Sub

#Region "Draw Graph"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''Button Show Graph Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnShowGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowGraph.Click
        '2013-06-06 Tin Pham: support cancel data
        If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
            Exit Sub
        End If
        '
        If m_blnClickNotShowGraph = False Then '->Show Graph
            m_blnClickNotShowGraph = True
            Me.graphContainer.BringToFront()
            Me.pnlDataSample.Visible = False
            Me.graphContainer.Visible = True
            Me.graphContainer.Dock = DockStyle.Fill
            btnShowGraph.Image = Global.AVP_Robot_Project.My.Resources.uparrowmain
            btnShowGraph.Text = GRAPH_VIEW
            Me.btnClearSelected.Text = "Clear Selected"
            Me.btnClearSelected.Visible = True
            Me.Panel5.Width = Me.btnShowGraph.Width + Me.btnClearSelected.Width + 10
            Me.Panel3.Width = Me.Panel5.Left - 5

        Else '->Show Data Grid
            m_blnClickNotShowGraph = False
            Me.pnlDataSample.BringToFront()
            Me.graphContainer.Visible = False
            Me.pnlDataSample.Visible = True
            btnShowGraph.Image = Global.AVP_Robot_Project.My.Resources.downarrowmain
            btnShowGraph.Text = STEP_VIEW
            Me.btnClearSelected.Text = "Compared"
            Me.btnClearSelected.Visible = False
            Me.Panel5.Width = Me.btnShowGraph.Width + 10
            Me.Panel3.Width = Me.Panel5.Left - 5
        End If

        Me.lblRecipe.Width = Me.Panel3.Width - Me.lblRecipe.Left
        Me.lblWaferID.Width = Me.Panel3.Width - Me.lblWaferID.Left
        SetRecipeText(RealRecipeName)
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''Show Graph from Tree node
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub ShowGraphDataFromStepNo(ByVal NodeKey As String, ByVal dicData As Dictionary(Of String, List(Of DataValue)))
        Try
            If dicData Is Nothing OrElse dicData.Count <= 0 Then
                Exit Sub
            End If
            Dim listDataValue As List(Of DataValue) = Nothing
            Dim myCurve As LineItem
            If dicData.ContainsKey(NodeKey) Then
                listDataValue = CType(dicData.Item(NodeKey), List(Of DataValue))
                Dim list As New PointPairList
                myCurve = Me.zgraphFromFile.GraphPane.AddCurve(NodeKey, list, _
                                                  Color.FromArgb(m_rndObj.Next(0, MAX_COLOR), m_rndObj.Next(0, MAX_COLOR), _
                                                  m_rndObj.Next(0, MAX_COLOR)), SymbolType.Diamond)
                If listDataValue.Count > 0 Then
                    Dim dInitValue As Double = listDataValue(0).Time
                    For Each data As DataValue In listDataValue
                        Dim ip As ZedGraph.IPointListEdit = zgraphFromFile.GraphPane.CurveList(NodeKey).Points
                        Dim x As Double, y As Double
                        x += CDbl(data.Time)
                        'End
                        y = data.Value
                        x = Math.Round(x, 3)
                        'y = Math.Round(y, 3)
                        ip.Add(New PointPair(x, y, "X= " & x.ToString() & "; Y=" & data.Value))
                    Next
                        zgraphFromFile.AxisChange()
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''Remove all checked node 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RemoveAllSelectedNodeFromGraph()
        Try
            If zgraphFromFile.GraphPane.CurveList.Count > 0 Then
                Dim CheckedNode As TreeNode = Nothing

                For Each parentNode As TreeNode In tvStepList.Nodes
                    For Each CheckedNode In parentNode.Nodes ''get the child node
                        If CheckedNode IsNot Nothing AndAlso CheckedNode.Checked = True Then
                            Me.RemoveSelectedNodeFromGraph(CheckedNode.Text, False)
                            CheckedNode.Checked = False
                        End If
                    Next
                Next
                ''remove done -> refresh graph
                '#03/31/2011 
                '#Datarun graph.   Need to set scale to default when user click on �clear all selected.�  
                '#The reason is that if we are zoom in @ 0 scale and user clear all selected and click 
                '#on one of the params that has very high number say 200, the graph show that everything
                '# is zero since it�s stuck @ 0 scale.
                '#Begin fix:
                If zgraphFromFile.GraphPane.CurveList.Count > 0 Then
                    zgraphFromFile.GraphPane.CurveList.Clear()
                End If
            End If

            zgraphFromFile.ZoomOutAll(zgraphFromFile.GraphPane)
            zgraphFromFile.RestoreScale(zgraphFromFile.GraphPane)
            Me.zgraphFromFile.Refresh()
            Me.tvStepList.Refresh()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''Remove checked node
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RemoveSelectedNodeFromGraph(ByVal NodeKey As String, Optional ByVal isRefresh As Boolean = True)
        Try
            Dim myCurve As LineItem = New LineItem(NodeKey)
            For Each lineItm As LineItem In zgraphFromFile.GraphPane.CurveList
                If lineItm.Label.Text = NodeKey Then
                    Me.zgraphFromFile.GraphPane.CurveList(NodeKey).Clear()
                    Me.zgraphFromFile.GraphPane.CurveList.Remove(lineItm)

                    'add this to reduce time refresh page when clear all clicked
                    'because refresh page will be perform after clear all item 
                    If (isRefresh) Then
                        zgraphFromFile.ZoomOutAll(zgraphFromFile.GraphPane)
                        zgraphFromFile.RestoreScale(zgraphFromFile.GraphPane)
                        Me.zgraphFromFile.Refresh()
                    End If

                    Exit Sub
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''Generate Tree Node from hastable and dictionary
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ShowGraphDataToTreeView(ByVal dtStep As DataTable)
        Try
            tvStepList.Nodes.Clear()
            Dim strStep As String = String.Empty
            For Each StepRow As DataRow In dtStep.Rows
                '2013-06-06 Tin Pham: support cancel data
                If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                    Exit Try
                End If
                '
                strStep = StepRow(COL_STEPNO).ToString()
                Dim hstStepData As Hashtable = m_hstStepData 'm_hstChamberData(m_strClickOnChamber)
                Dim dicSampleData As Dictionary(Of String, List(Of DataValue)) = hstStepData(strStep)
                Dim ListSample As System.Collections.IEnumerator = Nothing
                If dicSampleData Is Nothing Then
                    Exit Sub
                End If
                ListSample = dicSampleData.Keys().GetEnumerator()
                If ListSample Is Nothing Then
                    Exit Sub
                End If

                Dim ParenNode As New TreeNode
                ParenNode.Text = strStep

                Dim dtSample As New DataTable("DataWaferRun")
                While (ListSample.MoveNext)
                    '2013-06-06 Tin Pham: support cancel data
                    If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                        Exit Try
                    End If
                    '
                    Dim SampleNode As String = ListSample.Current.ToString()
                    If dicSampleData.Item(SampleNode) IsNot Nothing Or Not SampleNode = TIMES_COLUMNS Then
                        ''check value type is Numeric
                        Dim listOfData As List(Of DataValue) = dicSampleData.Item(SampleNode)
                        If listOfData.Count > 0 Then
                            Dim dtValue As DataValue = listOfData.Item(0)
                            If IsNumeric(dtValue.Value) Then
                                'draw value to treeview
                                ParenNode.Nodes.Add(SampleNode)
                            End If
                        End If
                    End If
                End While
                tvStepList.Nodes.Add(ParenNode)
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    ''' Show data to Grid Step (on top right)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub ShowWaferRunStepToGrid(ByVal hstStepData As Hashtable, ByVal blnIsCompareFile As Boolean)
        Try
            If blnIsCompareFile Then
               
            Else
                If hstStepData IsNot Nothing Then
                    dgvStep.EnableHeadersVisualStyles = True
                    dgvStep.Visible = False

                    Dim ListKeys As System.Collections.IEnumerator = hstStepData.Keys().GetEnumerator()
                    m_dtWaferRunStep = New DataTable("WaferRunStep")
                    m_dtWaferRunStep.Columns.Add(COL_STEPNO, GetType([String]))
                    m_dtWaferRunStep.Columns.Add(COL_TOTAL_SECONDS_STEP, GetType([String]))
                    m_dtWaferRunStep.Columns.Add(COL_START, GetType([String]))
                    m_dtWaferRunStep.Columns.Add(COL_REALSTEP, GetType(Integer))

                    While (ListKeys.MoveNext)
                        '2013-06-06 Tin Pham: support cancel data
                        If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                            Exit Try
                        End If
                        '
                        Dim objStepInfo As StepInfo = CType(m_hstStepInfo(ListKeys.Current.ToString()), StepInfo)
                        Dim dtRow As DataRow = m_dtWaferRunStep.NewRow
                        dtRow(COL_STEPNO) = ListKeys.Current.ToString()
                        dtRow(COL_TOTAL_SECONDS_STEP) = objStepInfo.TotalSeconds
                        Dim DisplayTime As DateTime = ParseDateTime(objStepInfo.StartInfo)
                        dtRow(COL_START) = DisplayTime.ToString(NEW_DATE_TIME_FORMAT)
                        Dim strStep As String = ListKeys.Current.ToString()
                        If strStep.Contains("Step-") Then
                            strStep = strStep.Replace("Step-", "")
                            dtRow(COL_REALSTEP) = CInt(strStep)
                        End If
                        m_dtWaferRunStep.Rows.Add(dtRow)
                    End While

                    'Dat Cao Fix: sort m_dtwaferRunStep ---------------------
                    Dim dataview As DataView = m_dtWaferRunStep.DefaultView
                    dataview.Sort = COL_START & " ASC"
                    m_dtWaferRunStep = dataview.ToTable
                    '''------------------------------------------------------
                    Me.dgvStep.DataSource = m_dtWaferRunStep
                    Me.dgvStep.Columns(COL_REALSTEP).Visible = False
                    dgvStep.Visible = True
                    ShowGraphDataToTreeView(m_dtWaferRunStep)
                End If

                If Not String.IsNullOrEmpty(m_strdataFile) Then
                    Dim pattern As String = "(.*)\\" & DATARUN_FOLDER & "\\(\d+_\d+_\d+)\\(.*)\.\w+"
                    Dim m As Match = Regex.Match(m_strdataFile, pattern)
                    If m.Success Then
                        Dim strPath As String = m.Groups(1).Value
                        Dim strDate As String = m.Groups(2).Value
                        Dim strFileName As String = m.Groups(3).Value

                        If Directory.Exists(strPath & "\\" & ENDPOINT_FOLDER & "\\" & strDate) Then
                            Dim arrFiles As String() = Directory.GetFiles(strPath & "\\" & ENDPOINT_FOLDER & "\\" & strDate, strFileName & "*.csv")
                            If arrFiles.Length > 0 Then
                                m_arrHidenFiles = arrFiles
                                btnHidenData.Visible = True
                                btnExportHidenData.Visible = True
                                pnlButton.Height = 51
                            Else
                                m_arrHidenFiles = Nothing
                                btnHidenData.Visible = False
                                btnExportHidenData.Visible = False
                            End If
                        Else
                            m_arrHidenFiles = Nothing
                            btnHidenData.Visible = False
                            btnExportHidenData.Visible = False
                        End If
                    Else
                        m_arrHidenFiles = Nothing
                        btnHidenData.Visible = False
                        btnExportHidenData.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    ''' Show Data to Grid (on bottom right)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub ShowWaferSampleDataToGrid(ByVal dicSampleData As Dictionary(Of String, List(Of DataValue)), ByVal blnIsCompareData As Boolean, ByRef WaferRunSampleDataTable As DataTable)
        'data is store in vertical 
        'we get data to show in grid in horizontal
        Dim indexOfList As Int64 = 0
        Dim intMaxSizeOfRow As Int64 = 0
        Dim i As Integer = 0
        Try
            Dim strKey As String = String.Empty
            'Console.WriteLine("Start ShowWaferSampleDataToGrid: " & Now)
            If m_hstStepData IsNot Nothing Then
                Dim ListKeys As System.Collections.IEnumerator = dicSampleData.Keys().GetEnumerator()
                If blnIsCompareData Then
                    WaferRunSampleDataTable = New DataTable("WaferRunCompare")
                Else
                    WaferRunSampleDataTable = New DataTable("WaferRunSample")
                End If

                Dim dtCol As DataColumn = Nothing
                While ListKeys.MoveNext ''create column
                    '2013-06-06 Tin Pham: support cancel data
                    If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                        Exit Try
                    End If
                    '
                    If Not WaferRunSampleDataTable.Columns.Contains(ListKeys.Current.ToString()) Then
                        ''find max row will be adding below
                        If intMaxSizeOfRow < CType(dicSampleData.Item(ListKeys.Current.ToString()), List(Of DataValue)).Count Then
                            intMaxSizeOfRow = CType(dicSampleData.Item(ListKeys.Current.ToString()), List(Of DataValue)).Count
                        End If
                        dtCol = New DataColumn(ListKeys.Current.ToString(), GetType([String]))
                        WaferRunSampleDataTable.Columns.Add(dtCol)
                        If String.IsNullOrEmpty(strKey) Then
                            strKey = ListKeys.Current.ToString() 'for get size of List Data
                        End If
                    End If
                End While
                'start updating Row
                ListKeys.Reset()
                If String.IsNullOrEmpty(strKey) Then
                    Me.dgvStep.DataSource = Nothing
                    Me.dgvData.DataSource = Nothing
                    Exit Sub
                End If
                Dim ListOfDataValue As List(Of DataValue) = dicSampleData.Item(strKey)
                '
                For indexOfList = 0 To intMaxSizeOfRow - 1
                    '2013-06-06 Tin Pham: support cancel data
                    If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                        Exit Try
                    End If
                    '
                    Dim dtRow As DataRow = WaferRunSampleDataTable.NewRow
                    'Update Row
                    While ListKeys.MoveNext
                        '2013-06-06 Tin Pham: support cancel data
                        If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                            Exit Try
                        End If
                        '
                        ListOfDataValue = dicSampleData(ListKeys.Current.ToString())

                        If ListOfDataValue Is Nothing Then
                            dtRow(ListKeys.Current.ToString()) = ListKeys.Current.ToString()
                        ElseIf indexOfList < ListOfDataValue.Count AndAlso ListOfDataValue(indexOfList) IsNot Nothing Then
                            If String.IsNullOrEmpty(CType(ListOfDataValue(indexOfList), DataValue).DisplayTime) Then
                                dtRow(ListKeys.Current.ToString()) = CType(ListOfDataValue(indexOfList), DataValue).Value
                            Else
                                Dim strDisplayTime As String = CType(ListOfDataValue(indexOfList), DataValue).DisplayTime
                                Dim DisplayTime As DateTime = ParseDateTime(strDisplayTime)
                                dtRow(ListKeys.Current.ToString()) = DisplayTime.ToString(NEW_DATE_TIME_FORMAT)
                            End If
                        Else
                            dtRow(ListKeys.Current.ToString()) = String.Empty
                        End If
                    End While
                    ListKeys.Reset()
                    WaferRunSampleDataTable.Rows.Add(dtRow)
                Next
                If Not blnIsCompareData Then
                    Me.dgvData.DataSource = WaferRunSampleDataTable
                    If Me.dgvData.Columns.Count > 0 Then
#If AVP_PLATFORM = "CX" Then
                        ' pnlColList.Controls.Clear()
                        AddHiddenColumnCheckBox()
#End If
                        Me.dgvData.Columns("Time").Frozen = True

                        '#04/20/2011 
                        '#Datarun.  Expand row to accommodate long param name such as Ion_Gauge_Pressure.
                        '#Begin fix
                        For Each column As DataGridViewColumn In dgvData.Columns
                            '2013-06-06 Tin Pham: support cancel data
                            If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                                Exit Try
                            End If
                            '
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells 'Or DataGridViewAutoSizeColumnMode.ColumnHeader
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        Next
                        'Me.dgvData.Columns(0).Width = 40 'seq column
                        'Me.dgvData.Columns(1).Width = 150 'Time column
                        '#End fix.
                    End If
                End If
            End If
            'Console.WriteLine("End ShowWaferSampleDataToGrid: " & Now)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub AddHiddenColumnCheckBox()
        Try
            Dim chamber As String = Me.Parent.Text
            Dim i As Integer = chamber.IndexOf("_")
            If i > 0 Then
                chamber = chamber.Remove(i)
            End If

            For Each column As DataGridViewColumn In dgvData.Columns
                '2013-06-06 Tin Pham: support cancel data
                If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                    Exit Try
                End If
                '
                If AVPLib.ContainerData.HidenColumnInDataRun IsNot Nothing Then
                    Dim listColumn As List(Of String) = AVPLib.ContainerData.HidenColumnInDataRun(chamber)
                    If listColumn IsNot Nothing Then
                        If listColumn.Contains(column.Name) Then
                            dgvData.Columns(column.Name).Visible = False
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    ''' Load Data File to Storage
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub LoadDataFile(ByVal strFile As String, ByRef hstStepData As Hashtable, ByRef hstStepInfo As Hashtable, ByVal blnGetXMLInfo As Boolean)
        Try
            If (String.IsNullOrEmpty(strFile)) Then
                Exit Sub
            End If
            Dim dicSampleData As Dictionary(Of String, List(Of DataValue))

            If strFile.EndsWith(STR_CSV_EXT) Then
                Dim stepNoColumnIndex As Integer = 0
                Dim sampleColumnIndex As Integer = 1
                Dim timeColumnIndex As Integer = 2

                Dim listOfAllTags As New List(Of String)
                Dim dicSampleTime As New Dictionary(Of String, List(Of String))
                Dim dicStepInfo As New Dictionary(Of String, StepInfo)
                Dim dicStepData As New Dictionary(Of String, Dictionary(Of String, List(Of String)))
                m_RecipeInfo = New RecipeInfo()

                Dim fs As FileStream = New FileStream(strFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Dim isNewFormat As Boolean = True

                Using csvReader As StreamReader = New StreamReader(fs)
                    Dim line As String = String.Empty
                    Dim stepNum As String = String.Empty

                    Do

                        If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                            Exit Try
                        End If
                        line = csvReader.ReadLine()

                        If line Is Nothing Then Exit Do

                        Dim arrColumn As String() = line.Trim().Split(",")

                        If arrColumn.Length > 1 Then

                            If arrColumn(0).StartsWith(WAFERID) Then
                                m_RecipeInfo.WaferID = arrColumn(1)

                            ElseIf arrColumn(0).StartsWith(RECIPE_NAME) Then
                                m_RecipeInfo.RecipeName = arrColumn(1)

                            ElseIf arrColumn(0).StartsWith(START_TIME_STEP) AndAlso isNewFormat Then
                                Dim strStep As String = arrColumn(0).Substring(START_TIME_STEP.Length + 1, arrColumn(0).Length - START_TIME_STEP.Length - 1)

                                If dicStepInfo.ContainsKey(strStep) Then
                                    dicStepInfo(strStep).StartInfo = arrColumn(1)
                                End If

                            ElseIf arrColumn(0).StartsWith(START_TIME) AndAlso Not isNewFormat Then
                                If Not dicStepInfo.ContainsKey(stepNum) Then
                                    dicStepInfo.Add(stepNum, New StepInfo())
                                End If
                                dicStepInfo(stepNum).StartInfo = arrColumn(1)

                            ElseIf arrColumn(0).StartsWith(TOTAL_SECONDS_STEP) Then
                                Dim strStep As String = arrColumn(0).Substring(TOTAL_SECONDS_STEP.Length + 1, arrColumn(0).Length - TOTAL_SECONDS_STEP.Length - 1)

                                If dicStepInfo.ContainsKey(strStep) Then
                                    dicStepInfo(strStep).TotalSeconds = arrColumn(1)
                                End If

                            ElseIf arrColumn(0).StartsWith(TOTAL_SECONDS_RECIPE) Then
                                m_RecipeInfo.TotalSeconds = arrColumn(1)

                            ElseIf arrColumn(0).StartsWith(STEP_NO) Then

                                'Detect old csv format
                                If arrColumn.Length <= NUMBER_COLUMN_OF_STEPNO_ROW_OLDFORMAT Then
                                    isNewFormat = False
                                    timeColumnIndex = 1
                                    stepNoColumnIndex = -1
                                    sampleColumnIndex = 0
                                    stepNum = arrColumn(1)

                                    If Not dicSampleTime.ContainsKey(stepNum) Then
                                        dicSampleTime.Add(stepNum, New List(Of String))
                                    End If

                                    If Not dicStepData.ContainsKey(stepNum) Then
                                        dicStepData.Add(stepNum, New Dictionary(Of String, List(Of String)))
                                    End If

                                    If Not dicStepData.ContainsKey(stepNum) Then
                                        dicStepData.Add(stepNum, New Dictionary(Of String, List(Of String)))
                                    End If
                                Else
                                    For index As Integer = 0 To arrColumn.Length - 1

                                        If index = stepNoColumnIndex AndAlso arrColumn(index) = STEP_NO OrElse _
                                            index = timeColumnIndex AndAlso arrColumn(index) = TIMES_COLUMNS Then '1: index of time column
                                            Continue For
                                        End If
                                        listOfAllTags.Add(arrColumn(index))
                                    Next
                                    m_lstAllColumns = listOfAllTags '"1.1" in case recipe loop
                                End If

                                'For old csv format
                            ElseIf arrColumn(0).StartsWith(SAMPLE_COLUMNS) AndAlso Not isNewFormat Then
                                For index As Integer = 0 To arrColumn.Length - 1
                                    If stepNum = "1" Then ' Only get tags at the first step
                                        If index = 1 AndAlso arrColumn(index) = TIMES_COLUMNS Then '1: index of time column
                                            Continue For
                                        End If
                                        listOfAllTags.Add(arrColumn(index))
                                    End If

                                    If dicStepData.ContainsKey(stepNum) AndAlso Not dicStepData(stepNum).ContainsKey(arrColumn(index)) Then
                                        dicStepData(stepNum).Add(arrColumn(index), New List(Of String))
                                    End If
                                Next
                                If stepNum = "1" Then m_lstAllColumns = listOfAllTags

                            ElseIf arrColumn.Length > 2 Then

                                For index As Integer = 0 To arrColumn.Length - 1

                                    If index <> stepNoColumnIndex AndAlso index <> timeColumnIndex Then

                                        ' Get other column
                                        Dim itemp As Integer = 1

                                        If index > 1 Then
                                            itemp = index - 2
                                        ElseIf index = sampleColumnIndex Then
                                            itemp = index - 1
                                        End If

                                        If Not isNewFormat Then
                                            itemp += 1
                                        End If

                                        If dicStepData.ContainsKey(stepNum) AndAlso itemp < listOfAllTags.Count AndAlso dicStepData(stepNum).ContainsKey(listOfAllTags(itemp)) Then
                                            dicStepData(stepNum)(listOfAllTags(itemp)).Add(arrColumn(index))
                                        End If

                                    ElseIf index = timeColumnIndex Then

                                        ' Get time column
                                        If dicSampleTime.ContainsKey(stepNum) Then
                                            dicSampleTime(stepNum).Add(arrColumn(index))
                                        End If

                                    ElseIf index = stepNoColumnIndex AndAlso isNewFormat Then

                                        'Get Step number
                                        If stepNum <> arrColumn(stepNoColumnIndex) Then
                                            stepNum = arrColumn(stepNoColumnIndex)

                                            If Not dicSampleTime.ContainsKey(stepNum) Then
                                                dicSampleTime.Add(stepNum, New List(Of String))
                                            End If

                                            If Not dicStepInfo.ContainsKey(stepNum) Then
                                                dicStepInfo.Add(stepNum, New StepInfo())
                                            End If

                                            If Not dicStepData.ContainsKey(stepNum) Then
                                                dicStepData.Add(stepNum, New Dictionary(Of String, List(Of String)))
                                            End If

                                            For Each tag As String In listOfAllTags
                                                If Not dicStepData(stepNum).ContainsKey(tag) Then
                                                    dicStepData(stepNum).Add(tag, New List(Of String))
                                                End If
                                            Next
                                        End If
                                    End If
                                Next

                                If isNewFormat AndAlso arrColumn.Length < listOfAllTags.Count Then
                                    For index As Integer = arrColumn.Length - 2 To listOfAllTags.Count - 1
                                        If dicStepData.ContainsKey(stepNum) AndAlso dicStepData(stepNum).ContainsKey(listOfAllTags(index)) Then
                                            dicStepData(stepNum)(listOfAllTags(index)).Add("")
                                        End If
                                    Next
                                End If
                            End If
                        End If
                    Loop Until line Is Nothing
                End Using

                hstStepData = New Hashtable
                hstStepInfo = New Hashtable
                For Each stepNum As String In dicStepInfo.Keys
                    dicSampleData = New Dictionary(Of String, List(Of DataValue))
                    Dim dtTime As Double = 0
                    Dim strPrevTime As String = String.Empty
                    Dim ListOfSampleTime As New List(Of DataValue)
                    For Each strTimeVal As String In dicSampleTime(stepNum)
                        If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                            Exit Try
                        End If

                        If String.IsNullOrEmpty(strPrevTime) Then
                            dtTime = 0 'Start Time
                        Else
                            Dim dt1 As DateTime = ParseDateTime(strPrevTime)
                            Dim dt2 As DateTime = ParseDateTime(strTimeVal)
                            Dim span As TimeSpan = dt2 - dt1
                            dtTime = span.TotalSeconds
                            dtTime = Math.Round(dtTime, 3)
                        End If
                        strPrevTime = strTimeVal

                        Dim Value As New DataValue
                        Value.Value = dtTime.ToString() '->don't draw this value 
                        Value.Time = dtTime ''for draw graph
                        Value.DisplayTime = strTimeVal

                        ListOfSampleTime.Add(Value)
                    Next
                    dicSampleData.Add(TIMES_COLUMNS, ListOfSampleTime)

                    For Each sTagName As String In listOfAllTags
                        If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                            Exit Try
                        End If
                        '
                        Dim lstDataValue As List(Of String) = dicStepData(stepNum)(sTagName)
                        Dim ListOfSampleData As New List(Of DataValue)
                        Dim ix As Integer = 0
                        'If lstDataValue.Count <> ListOfSampleTime.Count Then
                        '    Continue For
                        'End If

                        For Each strDataVal As String In lstDataValue
                            If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                                Exit Try
                            End If
                            '
                            Dim Value As New DataValue
                            Value.Value = strDataVal
                            Value.Time = ListOfSampleTime.Item(ix).Time

                            ListOfSampleData.Add(Value)
                            ix += 1
                        Next
                        If Not dicSampleData.ContainsKey(sTagName) Then
                            dicSampleData.Add(sTagName, ListOfSampleData)
                        End If
                    Next

                    Dim StepNo As String = "Step-" & stepNum
                    If Not hstStepData.ContainsKey(StepNo) Then
                        hstStepData.Add(StepNo, dicSampleData)
                    End If
                    If Not (hstStepInfo.ContainsKey(StepNo)) Then
                        hstStepInfo.Add(StepNo, dicStepInfo(stepNum))
                    End If
                Next

            Else ' XML
                Dim xmlDoc As XmlDocument = New XmlDocument
                AVPLib.Utils.LoadFileXML(xmlDoc, strFile)

                If blnGetXMLInfo Then
                    m_xmlDoc = xmlDoc
                End If
                'only one chamber 
                Dim ChamberNode As XmlNode = xmlDoc.SelectSingleNode(XPATH_CHAMBER) ''Jump to <Chamber>
                Dim listOfAllTags As List(Of String) = GetAllSampleTag(ChamberNode)
                ''get all tag of sample , eg: RF_Target_Power_SP, RF_Target_Power_RB....
                ''get 1 time only
                If listOfAllTags Is Nothing OrElse listOfAllTags.Count < 0 Then
                    Exit Sub
                End If
                m_lstAllColumns = listOfAllTags
                ''get each column and Build Hashtable
                hstStepData = New Hashtable
                hstStepInfo = New Hashtable

                Dim StepListNode As XmlNodeList = ChamberNode.SelectNodes("StepList").Item(0).ChildNodes

                'report progress of backgroundworkder
                Dim intPro As Integer = 0 'progress of backgroundworker
                Dim stepPro As Integer = 100 / StepListNode.Count
                Dim i As Integer = 0 'number of node will be read

                For Each StepNode As XmlNode In StepListNode ''jump to each <Step>
                    '2013-06-03 Tin Pham: support cancel data
                    If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                        Exit Try
                    End If
                    '
                    Dim objStepInfo As StepInfo = New StepInfo()
                    Dim StepNum As String = StepNode.SelectNodes("Number").Item(0).InnerText
                    Dim StepNo As String = "Step-" & StepNode.SelectNodes("Number").Item(0).InnerText
                    'Store step information
                    If Not String.IsNullOrEmpty(StepNode.SelectNodes("Start").Item(0).InnerText) Then
                        objStepInfo.StartInfo = (StepNode.SelectNodes("Start").Item(0).InnerText)
                    End If
                    Dim xmlNode As XmlNode = ChamberNode.SelectSingleNode(XPATH_CHAMBER & "/StepList/Step[Number=" & StepNum & "]/SampleList/TotalSeconds")
                    objStepInfo.TotalSeconds = xmlNode.InnerText.ToString()

                    ''Get Time Columns Value at step x
                    dicSampleData = BuildTimeColumns(xmlDoc, StepNum)
                    ''Get Others Columns Value at step x
                    BuildOthersColumns(xmlDoc, StepNum, listOfAllTags, dicSampleData)

                    i += 1
                    intPro = stepPro * i
                    OpenFile_worker.ReportProgress(intPro)

                    If Not hstStepData.ContainsKey(StepNo) Then
                        hstStepData.Add(StepNo, dicSampleData)
                    End If
                    If Not (hstStepInfo.ContainsKey(StepNo)) Then
                        hstStepInfo.Add(StepNo, objStepInfo)
                    End If
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overridable Sub LoadDataFile_For_Export(ByVal strFileToRead As String, ByVal strFolderName As String)
        Try
            If File.Exists(strFileToRead & STR_CSV_EXT) Then
                strFileToRead = strFileToRead & STR_CSV_EXT
                Dim strFileNameCSV As String = AVPLib.Utils.GetFileName(strFileToRead, True)
                strFileNameCSV = ChangeFileName(strFileNameCSV)
                File.Copy(strFileToRead, strFolderName & "\" & strFileNameCSV & STR_CSV_EXT)
                Exit Sub
            End If

            Dim dataRunSeparator As String = SPACE_STRING
            If (strFileToRead.Contains(AVPLib.ConstEnum.DataRunFileNameSeparator)) Then
                dataRunSeparator = AVPLib.ConstEnum.DataRunFileNameSeparator
            End If

            strFileToRead = strFileToRead & STR_XML_EXT

            If strFileToRead.Contains("Aligner") Then
                LoadAligner_For_Export(strFileToRead, strFolderName)
                Exit Sub
            End If

            Dim xmlDoc As XmlDocument = Nothing
            Dim dicSampleData As Dictionary(Of String, List(Of DataValue))

            If (String.IsNullOrEmpty(strFileToRead)) Then
                Exit Sub
            End If
            xmlDoc = New XmlDocument
            AVPLib.Utils.LoadFileXML(xmlDoc, strFileToRead)

            'only one chamber 
            Dim ChamberNode As XmlNode = xmlDoc.SelectSingleNode(XPATH_CHAMBER) ''Jump to <Chamber>
            Dim listOfAllTags As List(Of String) = GetAllSampleTag(ChamberNode)
            ''get all tag of sample , eg: RF_Target_Power_SP, RF_Target_Power_RB....
            ''get 1 time only
            If listOfAllTags Is Nothing OrElse listOfAllTags.Count < 0 Then
                Exit Sub
            End If
            m_lstAllColumns = listOfAllTags
            ''get each column and Build Hashtable
            Dim hstStepData As New Hashtable
            Dim hstStepInfo As New Hashtable

            Dim StepListNode As XmlNodeList = ChamberNode.SelectNodes("StepList").Item(0).ChildNodes

            'report progress of backgroundworkder
            Dim intPro As Integer = 0 'progress of backgroundworker
            Dim stepPro As Integer = 100 / StepListNode.Count
            Dim i As Integer = 0 'number of node will be read

            For Each StepNode As XmlNode In StepListNode ''jump to each <Step>
                Dim strFileNameCSV As String = AVPLib.Utils.GetFileName(strFileToRead, True)
                Dim objStepInfo As StepInfo = New StepInfo()
                Dim StepNum As String = StepNode.SelectNodes("Number").Item(0).InnerText
                Dim StepNo As String = "Step-" & StepNode.SelectNodes("Number").Item(0).InnerText
                Dim filename As String = strFileNameCSV
                'Store step information
                If Not String.IsNullOrEmpty(StepNode.SelectNodes("Start").Item(0).InnerText) Then
                    objStepInfo.StartInfo = (StepNode.SelectNodes("Start").Item(0).InnerText)
                End If
                Dim xmlNode As XmlNode = ChamberNode.SelectSingleNode(XPATH_CHAMBER & "/StepList/Step[Number=" & StepNum & "]/SampleList/TotalSeconds")
                objStepInfo.TotalSeconds = xmlNode.InnerText.ToString()

                ''Get Time Columns Value at step x
                dicSampleData = BuildTimeColumns(xmlDoc, StepNum)
                ''Get Others Columns Value at step x
                BuildOthersColumns(xmlDoc, StepNum, listOfAllTags, dicSampleData)
                strFileNameCSV = ChangeFileName(strFileNameCSV)
                strFileNameCSV = strFolderName & "\" & strFileNameCSV & dataRunSeparator & StepNo & ".csv"
                '2012_01_05_14_24_09 TestDataRun_LLA_1 PM3_1.xm

                Dim objWrite As StreamWriter = New StreamWriter(strFileNameCSV, False)
                Dim ListKeys As System.Collections.IEnumerator = dicSampleData.Keys().GetEnumerator()
                Dim rowline As String = String.Empty
                Dim key As String = String.Empty

                Dim arrName As String()
                Dim lotID As String = String.Empty
                Dim slotID As String()

                'get info description
                arrName = filename.Split(New String() {dataRunSeparator}, StringSplitOptions.RemoveEmptyEntries)
                If arrName.Length > 2 Then
                    lotID = arrName(1)
                    slotID = lotID.Split(New String() {"_"}, StringSplitOptions.RemoveEmptyEntries)
                    If slotID.Length > 1 Then
                        rowline = rowline + "LotID" + "," + slotID(0) + ","
                        objWrite.WriteLine(rowline)
                        rowline = String.Empty
                        rowline = rowline + "Slot" + "," + slotID(slotID.Length - 1) + ","
                        objWrite.WriteLine(rowline)
                        rowline = String.Empty
                    End If
                    If arrName(2).Length > 3 Then
                        arrName(2) = arrName(2).Substring(0, 3)
                    End If
                    'If arrName(2).Contains("_") Then
                    '    Dim chamName As String() = arrName(2).Split(New String() {"_"}, StringSplitOptions.RemoveEmptyEntries)
                    '    arrName(2) = chamName(0)
                    'End If
                    rowline = rowline + "Chamber" + "," + arrName(2) + ","
                    objWrite.WriteLine(rowline)
                    rowline = String.Empty
                End If
                If xmlDoc IsNot Nothing Then
                    'Dim xml_ChamberNode As XmlNode = m_xmlDoc.SelectSingleNode(XPATH_CHAMBER)
                    Dim childnode As XmlNode = ChamberNode.SelectNodes("RecipeName").Item(0)
                    If childnode IsNot Nothing Then
                        Dim recipeName As String = childnode.InnerText.ToString()
                        rowline = rowline + "RecipeName" + "," + recipeName + ","
                        objWrite.WriteLine(rowline)
                        rowline = String.Empty
                    End If
                End If

                rowline = rowline + "Step" + "," + StepNode.SelectNodes("Number").Item(0).InnerText + ","
                objWrite.WriteLine(rowline)
                rowline = String.Empty
                objWrite.WriteLine(rowline)

                rowline = String.Empty
                While ListKeys.MoveNext ''create column
                    If String.IsNullOrEmpty(key) Then
                        key = ListKeys.Current.ToString()
                    End If
                    rowline &= ListKeys.Current.ToString() & ","
                End While

                Dim MaxRow As Integer = CType(dicSampleData.Item(key), List(Of DataValue)).Count
                objWrite.WriteLine(rowline)
                ListKeys.Reset()

                ListKeys = dicSampleData.Values().GetEnumerator()
                rowline = String.Empty
                For intRow As Integer = 0 To MaxRow - 1
                    rowline = String.Empty
                    While ListKeys.MoveNext
                        Dim LstOfData As List(Of DataValue) = ListKeys.Current

                        'change to time
                        If Not String.IsNullOrEmpty(CType(LstOfData(intRow), DataValue).DisplayTime) Then
                            Dim strDisplayTime As String = CType(LstOfData(intRow), DataValue).DisplayTime
                            Dim DisplayTime As DateTime = ParseDateTime(strDisplayTime)
                            LstOfData.Item(intRow).Value = DisplayTime.ToString(NEW_DATE_TIME_FORMAT)
                        End If

                        rowline = rowline & LstOfData.Item(intRow).Value & ","
                    End While
                    ListKeys.Reset()
                    objWrite.WriteLine(rowline)
                Next
                objWrite.Close()

            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overridable Sub ExportAllParametersInFile(ByVal strFileToRead As String, ByVal strFolderName As String)
        Try
            Dim strFileNameCSV As String = String.Empty

            If File.Exists(strFileToRead & STR_CSV_EXT) Then
                strFileToRead = strFileToRead & STR_CSV_EXT
                strFileNameCSV = AVPLib.Utils.GetFileName(strFileToRead, True)
                strFileNameCSV = ChangeFileName(strFileNameCSV)
                File.Copy(strFileToRead, strFolderName & "\" & strFileNameCSV & STR_CSV_EXT)
                Exit Sub
            End If

            strFileToRead = strFileToRead & STR_XML_EXT

            If strFileToRead.Contains("Aligner") Then
                LoadAligner_For_Export(strFileToRead, strFolderName)
                Exit Sub
            End If

            Dim xmlDoc As XmlDocument = Nothing
            Dim dicSampleData As Dictionary(Of String, List(Of DataValue))

            If (String.IsNullOrEmpty(strFileToRead)) Or File.Exists(strFileToRead) = False Then
                Exit Sub
            End If

            strFileNameCSV = AVPLib.Utils.GetFileName(strFileToRead, True)
            xmlDoc = New XmlDocument
            AVPLib.Utils.LoadFileXML(xmlDoc, strFileToRead)

            'only one chamber 
            Dim ChamberNode As XmlNode = xmlDoc.SelectSingleNode(XPATH_CHAMBER) ''Jump to <Chamber>
            Dim listOfAllTags As List(Of String) = GetAllSampleTag(ChamberNode)
            ''get all tag of sample , eg: RF_Target_Power_SP, RF_Target_Power_RB....
            ''get 1 time only
            If listOfAllTags Is Nothing OrElse listOfAllTags.Count < 0 Then
                Exit Sub
            End If
            m_lstAllColumns = listOfAllTags
            ''get each column and Build Hashtable
            Dim hstStepData As New Hashtable
            Dim hstStepInfo As New Hashtable

            Dim StepListNode As XmlNodeList = ChamberNode.SelectNodes("StepList").Item(0).ChildNodes

            'report progress of backgroundworkder
            Dim intPro As Integer = 0 'progress of backgroundworker
            Dim stepPro As Integer = 100 / StepListNode.Count
            Dim i As Integer = 0 'number of node will be read

            Dim filename As String = strFileNameCSV
            strFileNameCSV = ChangeFileName(strFileNameCSV)
            strFileNameCSV = strFolderName & "\" & strFileNameCSV & STR_CSV_EXT
            Dim objWrite As StreamWriter = New StreamWriter(strFileNameCSV, False)

            'get info description
            Dim arrName As String()
            Dim lotID As String = String.Empty
            Dim slotID As String()
            Dim rowline As String = String.Empty
            Dim key As String = String.Empty

            Dim dataRunSeparator As String = SPACE_STRING
            If (filename.Contains(AVPLib.ConstEnum.DataRunFileNameSeparator)) Then
                dataRunSeparator = AVPLib.ConstEnum.DataRunFileNameSeparator
            End If

            arrName = filename.Split(New String() {dataRunSeparator}, StringSplitOptions.RemoveEmptyEntries)
            If arrName.Length > 2 Then
                lotID = arrName(1)
                slotID = lotID.Split(New String() {"_"}, StringSplitOptions.RemoveEmptyEntries)
                If slotID.Length > 1 Then
                    rowline = rowline + "LotID" + "," + slotID(0) + ","
                    objWrite.WriteLine(rowline)
                    rowline = String.Empty
                    rowline = rowline + "Slot" + "," + slotID(slotID.Length - 1) + ","
                    objWrite.WriteLine(rowline)
                    rowline = String.Empty
                End If
                If arrName(2).Length > 3 Then
                    arrName(2) = arrName(2).Substring(0, 3)
                End If
                'If arrName(2).Contains("_") Then
                '    Dim chamName As String() = arrName(2).Split(New String() {"_"}, StringSplitOptions.RemoveEmptyEntries)
                '    arrName(2) = chamName(0)
                'End If
                rowline = rowline + "Chamber" + "," + arrName(2) + ","
                objWrite.WriteLine(rowline)
                rowline = String.Empty
            End If

            If xmlDoc IsNot Nothing Then
                'Dim xml_ChamberNode As XmlNode = m_xmlDoc.SelectSingleNode(XPATH_CHAMBER)
                Dim childnode As XmlNode = ChamberNode.SelectNodes("RecipeName").Item(0)
                If childnode IsNot Nothing Then
                    Dim recipeName As String = childnode.InnerText.ToString()
                    rowline = rowline + "RecipeName" + "," + recipeName + ","
                    objWrite.WriteLine(rowline)
                    rowline = String.Empty
                End If
            End If

            For Each StepNode As XmlNode In StepListNode ''jump to each <Step>
                Dim objStepInfo As StepInfo = New StepInfo()
                Dim StepNum As String = StepNode.SelectNodes("Number").Item(0).InnerText
                Dim StepNo As String = "Step-" & StepNode.SelectNodes("Number").Item(0).InnerText
                'Store step information
                If Not String.IsNullOrEmpty(StepNode.SelectNodes("Start").Item(0).InnerText) Then
                    objStepInfo.StartInfo = (StepNode.SelectNodes("Start").Item(0).InnerText)
                End If
                Dim xmlNode As XmlNode = ChamberNode.SelectSingleNode(XPATH_CHAMBER & "/StepList/Step[Number='" & StepNum & "']/SampleList/TotalSeconds")
                objStepInfo.TotalSeconds = xmlNode.InnerText.ToString()

                ''Get Time Columns Value at step x
                dicSampleData = BuildTimeColumns(xmlDoc, StepNum)
                ''Get Others Columns Value at step x
                BuildOthersColumns(xmlDoc, StepNum, listOfAllTags, dicSampleData)

                '2012_01_05_14_24_09 TestDataRun_LLA_1 PM3_1.xm

                Dim ListKeys As System.Collections.IEnumerator = dicSampleData.Keys().GetEnumerator()


                rowline = rowline + "Step" + "," + StepNode.SelectNodes("Number").Item(0).InnerText + ","
                objWrite.WriteLine(rowline)
                rowline = String.Empty
                objWrite.WriteLine(rowline)

                rowline = String.Empty
                While ListKeys.MoveNext ''create column
                    If String.IsNullOrEmpty(key) Then
                        key = ListKeys.Current.ToString()
                    End If
                    rowline &= ListKeys.Current.ToString() & ","
                End While

                Dim MaxRow As Integer = CType(dicSampleData.Item(key), List(Of DataValue)).Count
                objWrite.WriteLine(rowline)
                ListKeys.Reset()

                ListKeys = dicSampleData.Values().GetEnumerator()
                rowline = String.Empty
                For intRow As Integer = 0 To MaxRow - 1
                    rowline = String.Empty
                    While ListKeys.MoveNext
                        Dim LstOfData As List(Of DataValue) = ListKeys.Current

                        'change to time
                        If Not String.IsNullOrEmpty(CType(LstOfData(intRow), DataValue).DisplayTime) Then
                            Dim strDisplayTime As String = CType(LstOfData(intRow), DataValue).DisplayTime
                            Dim DisplayTime As DateTime = ParseDateTime(strDisplayTime)
                            LstOfData.Item(intRow).Value = DisplayTime.ToString(NEW_DATE_TIME_FORMAT)
                        End If

                        rowline = rowline & LstOfData.Item(intRow).Value & ","
                    End While
                    ListKeys.Reset()
                    objWrite.WriteLine(rowline)
                Next

                rowline = String.Empty
                objWrite.WriteLine(rowline)
            Next

            objWrite.Close()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overridable Sub LoadAligner_For_Export(ByVal strDataRunFullFileName As String, ByVal strFolderName As String)
        Try

            Dim xmlDoc As XmlDocument = New XmlDocument
            AVPLib.Utils.LoadFileXML(xmlDoc, strDataRunFullFileName)

            Dim strFileNameCSV As String = String.Empty
            Dim dtTime As Integer = 0
            Dim filename As String = strFileNameCSV
            Dim rowline As String = String.Empty

            strFileNameCSV = AVPLib.Utils.GetFileName(strDataRunFullFileName, True)
            filename = strFileNameCSV
            strFileNameCSV = ChangeFileName(filename)
            strFileNameCSV = strFolderName & "\" & strFileNameCSV & ".csv"

            '2012_01_05_14_24_09 TestDataRun_LLA_1 x_Aligner.xm

            Dim objWrite As StreamWriter = New StreamWriter(strFileNameCSV, False)

            Dim root As System.Xml.XmlNode = xmlDoc.SelectSingleNode("/RunData/ChamberList/Chamber/StepList/Step/SampleList/Sample")
            rowline &= "Recipe Name" & ","
            ''checking file
            If root Is Nothing Then
                AVPLib.Log.avpLogger.Error("Can not load file Aligner DataRun: " & strDataRunFullFileName)
                Exit Try
            End If
            ''create columns
            Dim maxColumn = root.ChildNodes.Count - 1
            For j As Integer = 1 To root.ChildNodes.Count - 1
                rowline &= root.ChildNodes.Item(j).Name.ToString & ","
            Next
            objWrite.WriteLine(rowline)
            rowline = String.Empty

            For index As Integer = 0 To maxColumn
                If index = 0 Then
                    Dim recipeNode As Xml.XmlNode = xmlDoc.SelectSingleNode("/RunData/ChamberList/Chamber/RecipeName")
                    If recipeNode IsNot Nothing Then
                        rowline &= recipeNode.InnerText & ","
                    End If
                Else
                    rowline &= root.ChildNodes.Item(index).InnerText & ","
                End If
            Next
            objWrite.WriteLine(rowline)
            objWrite.Close()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Function ChangeFileName(ByVal sourceFile As String) As String
        Dim tarFile As String = String.Empty
        Try
            Dim dataRunSeparator As String = SPACE_STRING
            If (sourceFile.Contains(AVPLib.ConstEnum.DataRunFileNameSeparator)) Then
                dataRunSeparator = AVPLib.ConstEnum.DataRunFileNameSeparator
            End If

            Dim arrName As String()
            arrName = sourceFile.Split(New String() {dataRunSeparator}, StringSplitOptions.RemoveEmptyEntries)
            For i As Integer = 0 To arrName.Length - 1
                If i = arrName.Length - 1 Then
                    Dim strReverse As String() = arrName(i).Split(New String() {"_"}, StringSplitOptions.RemoveEmptyEntries)
                    If strReverse.Length = 2 Then
                        tarFile &= strReverse(1) & "_" & strReverse(0)
                    Else
                        '' no reverse
                        tarFile = sourceFile
                        Exit For
                    End If
                Else
                    tarFile &= arrName(i) & dataRunSeparator
                End If
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return tarFile
    End Function

    Private Function GetAllSampleTag(ByVal chamberNode As XmlNode) As List(Of String)
        Dim lstTags As New List(Of String)
        Try
            Dim xmlNode As XmlNode = chamberNode.SelectNodes("StepList").Item(0).ChildNodes.Item(0)
            If xmlNode IsNot Nothing Then ''jump to Sample List
                xmlNode = xmlNode.SelectNodes("SampleList").Item(0).ChildNodes.Item(0)
            End If
            For Each xNode As XmlNode In xmlNode.ChildNodes
                If xNode.Name <> TIMES_COLUMNS Then
                    lstTags.Add(xNode.Name)
                End If
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return lstTags
    End Function

    Private Function GetAllValuesOfSampleTag(ByVal xmlDoc As XmlDocument, ByVal StepNo As String, ByVal strSampleTag As String) As List(Of String)
        Dim lstResult As New List(Of String)
        Try
            Dim xmlTagListNode As Xml.XmlNodeList = xmlDoc.SelectNodes("//Step[Number=" & StepNo & "]/SampleList/Sample/" & strSampleTag)
            If xmlTagListNode Is Nothing Then
                Exit Try
            End If
            For Each xmlNode As Xml.XmlNode In xmlTagListNode
                '2013-06-03 Tin Pham: support cancel data
                If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                    Exit Try
                End If
                '
                lstResult.Add(xmlNode.InnerText)
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return lstResult
    End Function

    Private Function BuildTimeColumns(ByVal xmlDoc As XmlDocument, ByVal StepNo As String) As Dictionary(Of String, List(Of DataValue))
        Dim dicSampleData As New Dictionary(Of String, List(Of DataValue))
        Try
            Dim lstTimeValue As List(Of String) = GetAllValuesOfSampleTag(xmlDoc, StepNo, TIMES_COLUMNS)
            Dim strPrevTime As String = String.Empty
            Dim dtTime As Double = 0

            Dim ListOfSampleData As New List(Of DataValue)
            For Each strTimeVal As String In lstTimeValue
                '2013-06-06 Tin Pham: support cancel data
                If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                    Exit Try
                End If
                '
                If String.IsNullOrEmpty(strPrevTime) Then
                    dtTime = 0 'Start Time
                Else
                    Dim dt1 As DateTime = ParseDateTime(strPrevTime)
                    Dim dt2 As DateTime = ParseDateTime(strTimeVal)
                    Dim span As TimeSpan = dt2 - dt1
                    dtTime = span.TotalSeconds
                    dtTime = Math.Round(dtTime, 3)
                End If
                strPrevTime = strTimeVal

                Dim Value As New DataValue
                Value.Value = dtTime.ToString() '->don't draw this value 
                Value.Time = dtTime ''for draw graph
                Value.DisplayTime = strTimeVal

                ListOfSampleData.Add(Value)
            Next
            dicSampleData.Add(TIMES_COLUMNS, ListOfSampleData)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return dicSampleData
    End Function

    Private Sub BuildOthersColumns(ByVal xmlDoc As XmlDocument, ByVal StepNo As String, _
                                        ByVal ListOfAllTagSample As List(Of String), ByRef dicSampleData As Dictionary(Of String, List(Of DataValue)))


        Try
            Dim listOfTimeData As List(Of DataValue) = dicSampleData(TIMES_COLUMNS)

            For Each sTagName As String In ListOfAllTagSample
                '2013-06-03 Tin Pham: support cancel data
                If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                    Exit Try
                End If
                '                
                Dim lstDataValue As List(Of String) = GetAllValuesOfSampleTag(xmlDoc, StepNo, sTagName)
                Dim ListOfSampleData As New List(Of DataValue)
                Dim i As Integer = 0
                If lstDataValue.Count <> listOfTimeData.Count Then
                    Continue For
                End If

                For Each strDataVal As String In lstDataValue
                    '2013-06-03 Tin Pham: support cancel data
                    If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                        Exit Try
                    End If
                    '
                    Dim Value As New DataValue
                    Value.Value = strDataVal
                    Value.Time = listOfTimeData.Item(i).Time

                    ListOfSampleData.Add(Value)
                    i += 1
                Next
                dicSampleData.Add(sTagName, ListOfSampleData)
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''Show XML Information to GUI
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub ShowXMLInfoToGUI()
        Try
            If m_xmlDoc IsNot Nothing Then
                '2013-06-06 Tin Pham: support cancel data
                If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                    Exit Try
                End If
                '
                If Not String.IsNullOrEmpty(m_strChamberName) Then
                    'Me.gpbWaferRun.Text = m_strLotID & SPACE_STR & m_strSlotId
                    'Me.btnChamber1.Tag = m_strChamberName
                End If
                Dim ChamberNode As XmlNode = m_xmlDoc.SelectSingleNode(XPATH_CHAMBER)
                Dim childnode As XmlNode = ChamberNode.SelectNodes("RecipeName").Item(0)
                If childnode IsNot Nothing Then
                    SetRecipeText(childnode.InnerText)
                    Me.RealRecipeName = childnode.InnerText
                End If

                childnode = ChamberNode.SelectNodes("WaferID").Item(0)
                If childnode IsNot Nothing Then
                    Me.lblWaferID.Text = childnode.InnerText
                End If

                childnode = m_xmlDoc.SelectSingleNode("/RunData/TotalSeconds")
                If childnode IsNot Nothing Then
                    Me.lblTotalTime.Text = childnode.InnerText & "s"
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub ShowInfoToGUI()
        Try
            If OpenFile_worker IsNot Nothing AndAlso OpenFile_worker.CancellationPending Then
                Exit Try
            End If

            If m_RecipeInfo IsNot Nothing Then
                SetRecipeText(m_RecipeInfo.RecipeName)
                Me.RealRecipeName = m_RecipeInfo.RecipeName
                Me.lblWaferID.Text = m_RecipeInfo.WaferID
                Me.lblTotalTime.Text = m_RecipeInfo.TotalSeconds
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.dgvStep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvStep.Height = 200
        m_hstStepInfo = New Hashtable
        Dim myCurve As LineItem
        Dim list As New PointPairList
        myCurve = Me.zgraphFromFile.GraphPane.AddCurve(m_strYAxisTitle, list, Color.Red, SymbolType.Diamond)
        ' Fill the symbols with white
        myCurve.Symbol.Fill = New Fill(Color.White)
        Me.zgraphFromFile.GraphPane.YAxis.Title.Text = ""
        zgraphFromFile.GraphPane.XAxis.Title.Text = "X Axis(Second)"
        zgraphFromFile.IsShowPointValues = True
       
        '
        Me.pnlDataSample.BringToFront()
        Me.pnlDataSample.Dock = DockStyle.Fill
        Me.graphContainer.Visible = False
        Me.graphContainer.Dock = DockStyle.Fill

        OpenFile_worker = New ComponentModel.BackgroundWorker()
        OpenFile_worker.WorkerReportsProgress = True
        OpenFile_worker.WorkerSupportsCancellation = True
        AddHandler OpenFile_worker.DoWork, New ComponentModel.DoWorkEventHandler(AddressOf OnWork)
        AddHandler OpenFile_worker.ProgressChanged, New ComponentModel.ProgressChangedEventHandler(AddressOf OnProgressChanged)
        AddHandler OpenFile_worker.RunWorkerCompleted, New ComponentModel.RunWorkerCompletedEventHandler(AddressOf Worker_RunWorkerCompleted)

    End Sub
 
    Public Sub UnInitialize()
        Try
            RemoveHandler OpenFile_worker.DoWork, AddressOf OnWork
            RemoveHandler OpenFile_worker.ProgressChanged, AddressOf OnProgressChanged
            RemoveHandler OpenFile_worker.RunWorkerCompleted, AddressOf Worker_RunWorkerCompleted
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Function zgraphFromFile_PointValueEvent(ByVal sender As ZedGraph.ZedGraphControl, ByVal pane As ZedGraph.GraphPane, ByVal curve As ZedGraph.CurveItem, ByVal iPt As Integer) As String Handles zgraphFromFile.PointValueEvent
        Dim pt As PointPair = curve(iPt)
        Return "X= " & pt.X.ToString & "; Y=" & pt.Y.ToString()
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub WriteDataFile(ByRef sfilename As String, ByVal filename As String)
        Try
            Dim cellValue As String = ""
            Dim itemValue As String = ""
            Dim rowLine As String = ""
            Dim arrName As String()
            Dim lotID As String = ""
            Dim slotID As String()
            Dim chamber As String = ""
            Dim ordstep As String()
            
            Dim objWrite As StreamWriter = New StreamWriter(sfilename, False)
            If objWrite Is Nothing Then
                Exit Sub
            End If

            Dim dataRunSeparator As String = SPACE_STRING
            If (filename.Contains(AVPLib.ConstEnum.DataRunFileNameSeparator)) Then
                dataRunSeparator = AVPLib.ConstEnum.DataRunFileNameSeparator
            End If

            arrName = filename.Split(New String() {dataRunSeparator}, StringSplitOptions.RemoveEmptyEntries)
            If arrName.Length > 2 Then
                lotID = arrName(1)
                slotID = lotID.Split(New String() {"_"}, StringSplitOptions.RemoveEmptyEntries)
                If slotID.Length > 1 Then
                    rowLine = rowLine + "LotID" + "," + slotID(0) + ","
                    objWrite.WriteLine(rowLine)
                    rowLine = ""
                    rowLine = rowLine + "Slot" + "," + slotID(slotID.Length - 1) + ","
                    objWrite.WriteLine(rowLine)
                    rowLine = ""
                End If
                If arrName(2).Length > 3 Then
                    arrName(2) = arrName(2).Substring(0, 3)
                End If
                'If arrName(2).Contains("_") Then
                '    Dim chamName As String() = arrName(2).Split(New String() {"_"}, StringSplitOptions.RemoveEmptyEntries)
                '    arrName(2) = chamName(0)
                'End If
                rowLine = rowLine + "Chamber" + "," + arrName(2) + ","
                objWrite.WriteLine(rowLine)
                rowLine = ""
            End If
           

            If m_strdataFile IsNot Nothing AndAlso m_strdataFile.EndsWith(STR_CSV_EXT) Then
                If m_RecipeInfo IsNot Nothing Then
                    rowLine = rowLine + "RecipeName" + "," + m_RecipeInfo.RecipeName + ","
                    objWrite.WriteLine(rowLine)
                    rowLine = ""
                End If
            Else ' XML
                If m_xmlDoc IsNot Nothing Then
                    Dim ChamberNode As XmlNode = m_xmlDoc.SelectSingleNode(XPATH_CHAMBER)
                    Dim childnode As XmlNode = ChamberNode.SelectNodes("RecipeName").Item(0)
                    If childnode IsNot Nothing Then
                        Dim recipeName As String = childnode.InnerText.ToString()
                        rowLine = rowLine + "RecipeName" + "," + recipeName + ","
                        objWrite.WriteLine(rowLine)
                        rowLine = ""
                    End If
                End If
            End If

            ordstep = m_strSelectedStep.Split(New String() {"-"}, StringSplitOptions.RemoveEmptyEntries)
            rowLine = rowLine + "Step" + "," + ordstep(1) + ","
            objWrite.WriteLine(rowLine)
            rowLine = ""
            objWrite.WriteLine(rowLine)

            For Each col As DataGridViewColumn In dgvData.Columns
                itemValue = col.Name
                rowLine = rowLine + itemValue + ","
            Next
            objWrite.WriteLine(rowLine)
            rowLine = ""
            For i As Integer = 0 To Me.dgvData.Rows.Count - 1
                For j As Integer = 0 To Me.dgvData.Columns.Count - 1
                    If dgvData.Item(j, i).Value IsNot Nothing Then
                        cellValue = Me.dgvData.Item(j, i).Value
                    Else
                        cellValue = ""
                    End If
                    rowLine = rowLine + cellValue + ","
                Next
                objWrite.WriteLine(rowLine)
                rowLine = ""
            Next
            objWrite.Close()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    Private Sub GetAllPMFiles(ByVal sFolderName As String)
        Dim fName As String = Nothing
        Dim strSeletedStep As String = Nothing
        Dim bgWorkerExportFile As ComponentModel.BackgroundWorker = Nothing
        Dim filename As String = String.Empty
        Dim arg As List(Of String) = Nothing
        Try
            btnExpAll.Enabled = False
            For Each tb As TabPage In ContainerForm.WaferRun.tabWaferRun.TabPages
                Dim dataRunSeparator As String = SPACE_STRING
                If (Me.PrefixFile.Contains(AVPLib.ConstEnum.DataRunFileNameSeparator)) Then
                    dataRunSeparator = AVPLib.ConstEnum.DataRunFileNameSeparator
                End If

                filename = Me.PrefixFile & dataRunSeparator & tb.Name
                bgWorkerExportFile = New ComponentModel.BackgroundWorker()
                m_NumOfThread += 1
                AddHandler bgWorkerExportFile.DoWork, New ComponentModel.DoWorkEventHandler(AddressOf OnExportDataFile)
                AddHandler bgWorkerExportFile.RunWorkerCompleted, New ComponentModel.RunWorkerCompletedEventHandler(AddressOf ExportDataFile_Complete)

                arg = New List(Of String)
                arg.Add(filename)
                arg.Add(sFolderName)
                bgWorkerExportFile.RunWorkerAsync(arg)
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            Dim myStream As Stream = Nothing
            Dim fName As String = Nothing

            fName = AVPLib.Utils.GetFileName(m_strdataFile, True)
            fName = fName + " " + m_strSelectedStep
            Dim SaveFileDlg As New SaveFileDialog()
            SaveFileDlg.Filter = "csv files (*.csv)|*.csv"
            SaveFileDlg.FilterIndex = 1
            SaveFileDlg.RestoreDirectory = True
            SaveFileDlg.FileName = fName
            SaveFileDlg.DefaultExt = ".csv"

            If SaveFileDlg.ShowDialog = DialogResult.OK Then
                btnExport.Enabled = False
                'myStream = SaveFileDlg.OpenFile()
                'WriteDataFile(SaveFileDlg.FileName)
                WriteDataFile(SaveFileDlg.FileName, fName)
                'myStream.Close()
                btnExport.Enabled = True

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnAddMore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMore.Click
        Try
            Dim folderpath As String = DataFile.Substring(0, DataFile.LastIndexOf("\") + 1)
            ''Show list of current wafer run
            Dim WaferRunPopUp As New PopUpWaferRun(folderpath)
            WaferRunPopUp.dgvWFList.DataSource = ContainerForm.WaferRun.dgvWFList.DataSource
            WaferRunPopUp.dtFilter.Value = ContainerForm.WaferRun.dtFilter.Value
            WaferRunPopUp.ShowInTaskbar = False
            WaferRunPopUp.StartPosition = FormStartPosition.CenterScreen
            'WaferRunPopUp.TopMost = True
            If WaferRunPopUp.ShowDialog = DialogResult.OK Then
                For Each item As KeyValuePair(Of String, List(Of DataValue)) In WaferRunPopUp.ValueMap
                    Dim NodeKey As String = item.Key
                    Dim listDatavalue = item.Value
                    Dim list As New PointPairList
                    Dim myCurve As LineItem
                    If Me.zgraphFromFile.GraphPane.CurveList.Item(NodeKey) Is Nothing Then
                        myCurve = Me.zgraphFromFile.GraphPane.AddCurve(NodeKey, list, _
                                                                              Color.FromArgb(255, 255, _
                                                                              m_rndObj.Next(0, MAX_COLOR), m_rndObj.Next(0, MAX_COLOR)), SymbolType.Circle)
                        Dim x As Double = 0
                        Dim y As Double
                        For Each data As DataValue In listDatavalue
                            Dim ip As ZedGraph.IPointListEdit = zgraphFromFile.GraphPane.CurveList(NodeKey).Points
                            x += CDbl(data.Time)
                            y = data.Value
                            x = Math.Round(x, 3)
                            'y = Math.Round(y, 3)
                            ip.Add(New PointPair(x, y, "X= " & x.ToString() & "; Y=" & data.Value))
                        Next
                        zgraphFromFile.AxisChange()
                    Else
                        Utils.ShowAVPMessageBox("This item: " & NodeKey & Chr(13) & " has already been selected", "Wafer Run", MessageBoxIcon.Information, AVPMessageBox.AVPMessageBoxButton.OK)
                    End If
                Next
               
                zgraphFromFile.Refresh()
            End If
            
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnHiddenCol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHiddenCol.Click
        Dim chamber As String = Me.Parent.Text
        Dim i As Integer = chamber.IndexOf("_")
        If i > 0 Then
            chamber = chamber.Remove(i)
        End If
        Dim lstAllCol As List(Of String) = m_lstAllColumns
        If lstAllCol.Contains(TIMES_COLUMNS) = False Then
            lstAllCol.Add(TIMES_COLUMNS)
        End If
        Dim frmPopUp As New PopUpHidenColumns(lstAllCol, chamber)
        frmPopUp.ShowInTaskbar = False
        frmPopUp.StartPosition = FormStartPosition.CenterScreen
        frmPopUp.TopMost = True
        If frmPopUp.ShowDialog = DialogResult.OK Then
            For Each col As DataGridViewColumn In dgvData.Columns
                If frmPopUp.ListOfHidenColumns IsNot Nothing AndAlso frmPopUp.ListOfHidenColumns.Contains(col.Name) Then
                    col.Visible = False
                Else
                    col.Visible = True
                End If
            Next
        End If

    End Sub
    ''' <author>
    '''    	<name> Van Le </name>
    '''    	<date> 2012-Jan-5</date>
    ''' </author>
    ''' <summary>
    '''Export all data
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExpAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpAll.Click
        Dim browerFolder As New FolderBrowserDialog
        If browerFolder.ShowDialog() = DialogResult.OK Then
            GetAllPMFiles(browerFolder.SelectedPath)
        End If
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-08-25 </date>
    ''' </author>
    ''' <summary>
    ''' Set the specificed text to label Recipe, set tooltip if not enough space
    ''' </summary>
    Private Sub SetRecipeText(ByVal text As String)
        Dim isFitted As Boolean
        Me.lblRecipe.Text = AVPControls.AVPGraphicsLib.GetFittedText(text, lblRecipe, isFitted)
        If Not isFitted Then
            Me.rRecipeToolTip.SetToolTip(lblRecipe, text)
        End If
    End Sub

    Private Sub SampleData_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Utils.PaintBorder(sender, e)
    End Sub

    ''' <author>
    '''     <name> Hoai Ly </name>
    '''     <date> 2016-4-06 </date>
    ''' </author>
    ''' <summary>
    ''' Parse String to DateTime
    ''' </summary>
    Public Shared Function ParseDateTime(ByVal strDateTime As String) As DateTime
        Dim dateTime As DateTime = Date.Now
        Try
            If strDateTime.Contains("_") Then
                dateTime = Date.ParseExact(strDateTime, OLD_DATE_TIME_FORMAT, Nothing)
            Else
                dateTime = Date.ParseExact(strDateTime, NEW_DATE_TIME_FORMAT, Nothing)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return dateTime
    End Function

    '''    	<name> Tinh Le </name>
    '''    	<date> 2022-Apr-8</date>
    ''' </author>
    ''' <summary>
    ''' Export Hiden Data 
    ''' </summary>
    Private Sub btnExportHidenData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportHidenData.Click
        Try
            If m_arrHidenFiles IsNot Nothing AndAlso m_arrHidenFiles.Length > 0 Then
                Dim saveStream As Stream
                Dim saveFileDialog As New SaveFileDialog()

                saveFileDialog.InitialDirectory = "C:\"
                saveFileDialog.Filter = "csv file (*.csv)|"
                saveFileDialog.FilterIndex = 1
                saveFileDialog.RestoreDirectory = True
                saveFileDialog.OverwritePrompt = True
                saveFileDialog.CheckPathExists = True
                saveFileDialog.DefaultExt = "csv"

                If saveFileDialog.ShowDialog() = DialogResult.OK Then
                    saveStream = saveFileDialog.OpenFile()
                    If saveStream IsNot Nothing Then
                        Using csvStream As StreamWriter = New StreamWriter(saveStream)
                            For i As Int16 = 0 To m_arrHidenFiles.Length - 1
                                Using readStream As StreamReader = New StreamReader(m_arrHidenFiles(i))
                                    Dim strContent As String = readStream.ReadToEnd()
                                    If Not String.IsNullOrEmpty(strContent) Then
                                        If i > 0 Then
                                            csvStream.WriteLine("") ' Write new line to separate each step file
                                        End If
                                        csvStream.Write(strContent)
                                    End If
                                End Using
                            Next
                        End Using

                        saveStream.Close()

                        Utils.ShowAVPMessageBox("Hiden Data Is Exported Successfully.", "Export Hiden Data", MessageBoxIcon.Information, _
                                            AVPMessageBox.AVPMessageBoxButton.OK)
                    End If
                End If
            Else
                Utils.ShowAVPMessageBox("No File To Export.", "Export Hiden Data", MessageBoxIcon.Information, _
                                            AVPMessageBox.AVPMessageBoxButton.OK)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    '''    	<name> Tinh Le </name>
    '''    	<date> 2022-Apr-8</date>
    ''' </author>
    ''' <summary>
    ''' show Hiden Data 
    ''' </summary>
    Private Sub btnHidenData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHidenData.Click
        Try
            If m_arrHidenFiles IsNot Nothing AndAlso m_arrHidenFiles.Length > 0 AndAlso Not String.IsNullOrEmpty(lblWaferID.Text) Then
                Dim iAdditionalSize As Int16 = 200
                Dim hidenData As HidenData = New HidenData()
                hidenData.AddSteps(m_arrHidenFiles, lblWaferID.Text)
                hidenData.Size = New Size(Me.Size.Width + iAdditionalSize, Me.Size.Height + iAdditionalSize)
                hidenData.StartPosition = FormStartPosition.CenterParent
                hidenData.ShowDialog(AVPRobotMain)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class

Public Class StepInfo
    Private m_strStartInfo As String = String.Empty
    Private m_strTotalSeconds As String = String.Empty

#Region "Property"
    Public Property StartInfo() As String
        Get
            Return m_strStartInfo
        End Get
        Set(ByVal value As String)
            m_strStartInfo = value
        End Set
    End Property

    Public Property TotalSeconds() As String
        Get
            Return m_strTotalSeconds
        End Get
        Set(ByVal value As String)
            m_strTotalSeconds = value
        End Set
    End Property
#End Region
End Class

Public Class RecipeInfo
    Private m_strWaferID As String = String.Empty
    Private m_strRecipeName As String = String.Empty
    Private m_strTotalSeconds As String = String.Empty

#Region "Property"
    Public Property WaferID() As String
        Get
            Return m_strWaferID
        End Get
        Set(ByVal value As String)
            m_strWaferID = value
        End Set
    End Property

    Public Property RecipeName() As String
        Get
            Return m_strRecipeName
        End Get
        Set(ByVal value As String)
            m_strRecipeName = value
        End Set
    End Property

    Public Property TotalSeconds() As String
        Get
            Return m_strTotalSeconds
        End Get
        Set(ByVal value As String)
            m_strTotalSeconds = value
        End Set
    End Property
#End Region
End Class
