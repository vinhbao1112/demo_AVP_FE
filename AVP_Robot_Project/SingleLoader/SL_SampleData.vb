Imports ZedGraph
Imports System.IO
Imports System.Text
Imports System.Xml
Imports AVPLib.ConstEnum
Imports AVPLib.ContainerDAO
Imports AVP_Robot_Project.ConstantAndEnum
Imports System
Imports System.Globalization
Imports System.Collections.Generic

Public Class SL_SampleData
    Inherits SampleData

    Private m_strWaferID As String = String.Empty
    Private m_strRecipeName As String = String.Empty

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
    Public Function ReadCSV(ByVal path As String) As List(Of String())
        Dim lstRow As New List(Of String())
        Dim fStream As FileStream = New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
        Dim sr As StreamReader = New System.IO.StreamReader(fStream)
        Dim placeholder As Integer = 0
        Do While sr.Peek <> -1 ' Is -1 when no data exists on the next line of the CSV file
            Dim charSeparators() As Char = {","c}
            Dim row As String() = sr.ReadLine.ToString.Split(charSeparators)
            lstRow.Add(row)
        Loop
        Return lstRow
    End Function
    ''this parent sub: convert xml data (Vertical data  --> we need to convert Horizontal Data to show to GUI)
    ''but this child sub convert Horizontal Data to Vertical Data, then convert to Horizontal ===> CSV Data is Horizontal Data
    Protected Overrides Sub LoadDataFile(ByVal strFile As String, ByRef hstStepData As Hashtable, ByRef hstStepInfo As Hashtable, ByVal blnGetXMLInfo As Boolean)
        Try
            If (String.IsNullOrEmpty(strFile)) Then
                m_strWaferID = String.Empty
                m_strRecipeName = String.Empty
                Exit Sub
            End If

            Const BEGIN_ROW As Integer = 6
            Const BEGIN_ROW_NEWVERSION As Integer = 7 'Add field RecipeName at line 5th
            Const RECIPE_NAME_LINE_INDEX As Integer = 4
            Const STR_RECIPE_NAME As String = "Recipe Name"
            Const STR_WAFERID As String = "S01"
            Dim intBeginRow As Integer = BEGIN_ROW

            hstStepData = New Hashtable
            hstStepInfo = New Hashtable

            Dim lstRow As List(Of String()) = ReadCSV(strFile)
            '#06/16/2011 
            '#-	CSV.  Need to add step name.
            '#Begin fix
            If lstRow(RECIPE_NAME_LINE_INDEX)(0) = STR_RECIPE_NAME Then
                intBeginRow = BEGIN_ROW_NEWVERSION
                Try
                    m_strRecipeName = lstRow(RECIPE_NAME_LINE_INDEX)(1)
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
            End If
            '#End fix.

            Dim row As String() = lstRow(intBeginRow)
            Dim dicSampleData As New Dictionary(Of String, List(Of DataValue))
            For i As Integer = 0 To row.Length - 1 '' for each column
                Dim ListOfSampleData As New List(Of DataValue) 'Create new list
                Dim preStep As String = String.Empty ', lstRow(BEGIN_ROW + 1)(1))
                If lstRow.Count > intBeginRow + 1 Then
                    preStep = lstRow(intBeginRow + 1)(1)
                End If
                'If hstStepData.Count > 0 Then

                'End If
                Dim j As Integer = 0
                dicSampleData = New Dictionary(Of String, List(Of DataValue))
                For j = intBeginRow + 1 To lstRow.Count - 1
                    If String.IsNullOrEmpty(lstRow(j)(1)) AndAlso j + 1 < lstRow.Count Then
                        preStep = lstRow(j + 1)(1)
                        Continue For
                    End If
                    Dim Value As New DataValue
                    Value.Value = lstRow(j)(i).ToString()
                    Dim timetoSort As DateTime = DateTime.ParseExact(lstRow(j)(0), "yyyy_MM_dd_HH_mm_ss", Nothing)
                    Dim timspan As TimeSpan = New TimeSpan(timetoSort.Hour, timetoSort.Minute, timetoSort.Second)
                    Value.Time = timspan.TotalSeconds ''for draw graph
                    If lstRow(j)(1) = preStep OrElse j = intBeginRow + 1 Then
                        ListOfSampleData.Add(Value)
                    Else
                        If hstStepData.ContainsKey(preStep) Then
                            dicSampleData = hstStepData(preStep)
                            dicSampleData.Add(row(i), ListOfSampleData)
                        Else
                            dicSampleData.Add(row(i), ListOfSampleData)
                            hstStepData.Add(preStep, dicSampleData)
                            hstStepInfo.Add(preStep, String.Empty)
                        End If

                        preStep = lstRow(j)(1)
                        dicSampleData = New Dictionary(Of String, List(Of DataValue))
                        ListOfSampleData = New List(Of DataValue)
                        ListOfSampleData.Add(Value)
                    End If
                Next
                preStep = lstRow(j - 1)(1)
                dicSampleData.Add(row(i), ListOfSampleData)
                If hstStepData.ContainsKey(preStep) Then
                    dicSampleData = hstStepData(preStep)
                    dicSampleData.Add(row(i), ListOfSampleData)
                Else
                    hstStepData.Add(preStep, dicSampleData)
                    hstStepInfo.Add(preStep, String.Empty)
                End If
            Next

            m_strWaferID = STR_WAFERID
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overloads Sub ShowWaferSampleDataToGrid(ByVal value As Object)
        MyBase.ShowWaferSampleDataToGrid(value, True, m_dtWaferRunSample)
        For Each column As DataGridViewColumn In dgvData.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells Or DataGridViewAutoSizeColumnMode.ColumnHeader
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
        Me.dgvData.Columns(0).Width = 200 'Time column
        Me.dgvData.Columns(1).Width = 70 'Step column
    End Sub

    Protected Overrides Sub ShowWaferRunStepToGrid(ByVal hstStepData As Hashtable, ByVal blnIsCompareFile As Boolean)
        Try
            If blnIsCompareFile Then
                dgvStep.EnableHeadersVisualStyles = False
                If m_dtWaferRunStep IsNot Nothing AndAlso hstStepData IsNot Nothing Then
                    Dim ListKeys As System.Collections.IEnumerator = hstStepData.Keys().GetEnumerator()
                    'if data table doesn't have compare column ->create
                    If m_dtWaferRunStep.Columns.Contains(COL_START + SPACE_STR) = False Then
                        m_dtWaferRunStep.Columns.Add(COL_STEPNO + SPACE_STR, GetType([String]))
                        m_dtWaferRunStep.Columns.Add(COL_START + SPACE_STR, GetType([String]))
                    End If
                    Dim intRowWillBeAdd As Integer = 0
                    While (ListKeys.MoveNext)
                        Dim StepInfo As String = m_hstCompareStepInfo(ListKeys.Current.ToString())
                        Dim dtRow As DataRow = m_dtWaferRunStep.Rows(intRowWillBeAdd)
                        dtRow(COL_STEPNO + SPACE_STR) = ListKeys.Current.ToString()
                        dtRow(COL_START + SPACE_STR) = StepInfo
                        intRowWillBeAdd += 1
                        m_dtWaferRunStep.AcceptChanges()
                    End While
                    Me.dgvStep.DataSource = m_dtWaferRunStep
                    ''set style for dataGrid
                    dgvStep.Columns(COL_STEPNO + SPACE_STR).HeaderCell.Style.ForeColor = Color.DarkRed
                    dgvStep.Columns(COL_START + SPACE_STR).HeaderCell.Style.ForeColor = Color.DarkRed
                    dgvStep.Columns(COL_STEPNO + SPACE_STR).DefaultCellStyle.ForeColor = System.Drawing.Color.DarkRed
                    dgvStep.Columns(COL_START + SPACE_STR).DefaultCellStyle.ForeColor = System.Drawing.Color.DarkRed
                End If
            Else
                If hstStepData IsNot Nothing Then
                    dgvStep.EnableHeadersVisualStyles = True
                    ' dgvStep.Columns(0).Width = DataGridViewAutoSizeColumnMode.ColumnHeader
                    Dim ListKeys As System.Collections.IEnumerator = hstStepData.Keys().GetEnumerator()
                    m_dtWaferRunStep = New DataTable("WaferRunStep")
                    m_dtWaferRunStep.Columns.Add(COL_STEPNO, GetType([String]))
                    m_dtWaferRunStep.Columns.Add(COL_START, GetType([String]))
                    While (ListKeys.MoveNext)
                        Dim StepInfo As String = m_hstStepInfo(ListKeys.Current.ToString())
                        Dim dtRow As DataRow = m_dtWaferRunStep.NewRow
                        dtRow(COL_STEPNO) = ListKeys.Current.ToString()
                        dtRow(COL_START) = StepInfo
                        m_dtWaferRunStep.Rows.Add(dtRow)
                        m_dtWaferRunStep.AcceptChanges()
                    End While

                    ''Sort data table again
                    Dim dtView As DataView = New DataView(m_dtWaferRunStep)
                    dtView.Sort = COL_STEPNO & " ASC"
                    m_dtWaferRunStep = New DataTable
                    m_dtWaferRunStep = dtView.Table.Clone()
                    For Each drview As DataRowView In dtView
                        m_dtWaferRunStep.ImportRow(drview.Row)
                    Next
                    m_dtWaferRunStep.AcceptChanges()
                    Me.dgvStep.DataSource = m_dtWaferRunStep
                    ShowGraphDataToTreeView(m_dtWaferRunStep)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-Dec-22</date>
    ''' </author>
    ''' <summary>
    '''Show XML Information to GUI
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub ShowXMLInfoToGUI()
        MyBase.ShowXMLInfoToGUI()
        lblRecipe.Text = m_strRecipeName
        lblWaferID.Text = m_strWaferID
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' pnlColList.Dispose()
        pnlButton.Dispose()
        btnExport.Dispose()
        btnExpAll.Dispose()
        ' Add any initialization after the InitializeComponent() call.
        Panel1.Dispose()
    End Sub
End Class
