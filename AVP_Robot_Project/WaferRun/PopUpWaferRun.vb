Imports System.IO
Imports AVPLib.ConstEnum

Public Class PopUpWaferRun

#Region "Const - Variable"
    Protected Const FILE_NAME As String = "File Name"
    Protected Const TIME_TOSORT As String = "Time"
    Protected Const AT_TIME As String = "At Time"
    Protected Const LOT_ID As String = "Lot ID"
    Const SLOT_ID As String = "Slot ID"
    Const LOADLOCK As String = "Load Lock"
    Private m_strCurrentPrefix_SelectedFile As String = String.Empty
    Private m_CurrentFolderPath As String = String.Empty
    Private m_ValueToCompare As String = String.Empty
    Private m_lstResult As SortedDictionary(Of String, List(Of DataValue)) 'key :Selected value, Value: List Of DataValue
    Private m_listOfAllTags As New List(Of String)
    Private m_dicStepData As New Dictionary(Of String, Dictionary(Of String, List(Of String)))

    Public Enum DialogBoxResult
        [Cancel] = 0
        [OK] = 1
    End Enum
    Private m_dtWaferRunFile As DataTable
    Protected m_hstWaferRunData As Hashtable = Nothing 'key -> prefix ; value -> waferRunData
#End Region

#Region "Property"
    Public Property WaferRunDataMap() As Hashtable
        Get
            If m_hstWaferRunData Is Nothing Then
                m_hstWaferRunData = New Hashtable
            End If
            Return m_hstWaferRunData
        End Get
        Set(ByVal value As Hashtable)
            m_hstWaferRunData = value
        End Set
    End Property

    ''Return List of Value for Draw Graph
    Public Property ValueMap() As SortedDictionary(Of String, List(Of DataValue))
        Get
            Return m_lstResult
        End Get
        Set(ByVal value As SortedDictionary(Of String, List(Of DataValue)))
            m_lstResult = value
        End Set
    End Property
#End Region

#Region "Load - New "
    Public Sub New(ByVal CurrentFolderPath As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_CurrentFolderPath = CurrentFolderPath
        ' Add any initialization after the InitializeComponent() call.
        lstValue.SelectionMode = SelectionMode.MultiSimple
        m_lstResult = New SortedDictionary(Of String, List(Of DataValue))

        If m_dtWaferRunFile Is Nothing Then
            m_dtWaferRunFile = New DataTable("WaferRunFileList")
            Dim dtCol As DataColumn = Nothing
            dtCol = New DataColumn(AT_TIME)
            m_dtWaferRunFile.Columns.Add(dtCol)
            dtCol = New DataColumn(LOT_ID)
            m_dtWaferRunFile.Columns.Add(dtCol)
            dtCol = New DataColumn(LOADLOCK)
            m_dtWaferRunFile.Columns.Add(dtCol)
            dtCol = New DataColumn(SLOT_ID)
            m_dtWaferRunFile.Columns.Add(dtCol)
            dtCol = New DataColumn(FILE_NAME)
            m_dtWaferRunFile.Columns.Add(dtCol)
            dtCol = New DataColumn(TIME_TOSORT)
            dtCol.DataType = System.Type.GetType("System.Double")
            m_dtWaferRunFile.Columns.Add(dtCol)
        End If
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-08-25</date>
    ''' </author>
    ''' <summary>
    '''Loading dialog
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PopUpWaferRun_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgvWFList.Sort(dgvWFList.Columns(TIME_TOSORT), System.ComponentModel.ListSortDirection.Descending)
        Me.dgvWFList.Columns(FILE_NAME).Visible = False
        Me.dgvWFList.Columns(TIME_TOSORT).Visible = False
        Me.dgvWFList.Columns(AT_TIME).Width = 100
        Me.dgvWFList.Columns(LOT_ID).Width = 140
        Me.dgvWFList.Columns(LOADLOCK).Width = 110
        Me.dgvWFList.Columns(SLOT_ID).Width = 80

        GetWRDATAFrom_CurrentDate()
    End Sub
#End Region

#Region "Function Support"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-Aug-30</date>
    ''' </author>
    ''' <summary>
    ''' Load all Data File to Storage
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GetAllDataFile_ToDataTable(ByVal strShortDate As String)
        Try
            m_dtWaferRunFile.Rows.Clear()
            Dim WRData As WaferRunData = Nothing
            Dim strFolder As String = AVPLib.ContainerDAO.FPath_RunDataOfWafer & "\" & strShortDate
            If Not System.IO.Directory.Exists(strFolder) Then
                Exit Sub
            End If
            Dim alFiles As ArrayList = New ArrayList()
            Dim exts() As String = {"*.xml", "*.csv"}
            For Each ext As String In exts
                alFiles.AddRange(Directory.GetFiles(strFolder, ext))
            Next
            If alFiles.Count <= 0 Then Exit Sub

            m_CurrentFolderPath = strFolder
            For Each filename As String In alFiles
                If System.IO.File.Exists(filename) Then
                    Dim dataRunSeparator As String = ConstantAndEnum.SPACE_STRING
                    If (filename.Contains(AVPLib.ConstEnum.DataRunFileNameSeparator)) Then
                        dataRunSeparator = AVPLib.ConstEnum.DataRunFileNameSeparator
                    End If

                    Dim strFullPathFile As String = filename
                    filename = AVPLib.Utils.GetFileName(filename, True)
                    ''push files into data structure
                    '2010_09_24_03_24_21 KAJSDFLDS_LLA_1     PM2_2.xml
                    '2010_09_24_01_48_45           LLA_12    PM2.xml
                    Dim arrFileName As String()
                    arrFileName = filename.Split(New String() {dataRunSeparator}, StringSplitOptions.RemoveEmptyEntries)
                    Dim strTime As String = String.Empty
                    Dim strPM As String = String.Empty
                    Dim strFileInfo As String = String.Empty
                    Dim strPrefix As String = String.Empty
                    Dim strRunNo As String = String.Empty
                    If arrFileName.Length >= 3 Then
                        Dim index As Integer = 1
                        If arrFileName.Length = 4 Then
                            index = 2
                            strRunNo = arrFileName(3)
                            filename = filename.Substring(0, filename.LastIndexOf(" "))
                        End If
                        strTime = arrFileName(0)
                        strPM = arrFileName(arrFileName.Length() - index)
                        strFileInfo = filename.Replace(strTime, "")
                        strFileInfo = strFileInfo.Replace(strPM, "")
                        strFileInfo = strFileInfo.Trim(dataRunSeparator)
                        strPrefix = strTime & dataRunSeparator & strFileInfo
                    End If
                    If Not WaferRunDataMap.ContainsKey(strPrefix) Then
                        WRData = New WaferRunData
                        WRData.PrefixFile = strPrefix
                        Dim arrFileInfo As String() = strFileInfo.Split(New String() {"_"}, StringSplitOptions.RemoveEmptyEntries)
                        If arrFileInfo.Length >= 2 Then
                            WRData.SlotID = arrFileInfo(arrFileInfo.Length - 1)
                            WRData.LLName = arrFileInfo(arrFileInfo.Length - 2)
                            WRData.LotID = WaferRun.GetLOTIDFromFileName(filename)
                            WRData.CreatedTime = strTime
                            WRData.RunNo = strRunNo
                        End If
                        If strPM.Contains("_") Then
                            Dim strIndex As String = strPM.Substring(strPM.LastIndexOf("_") + 1)
                            WRData.ListOfPM.Add(IIf(IsNumeric(strIndex), CInt(strIndex), 0), strPM)
                        Else
                            WRData.ListOfPM.Add(0, strPM)
                        End If
                        'push into hashtable
                        WaferRunDataMap.Add(strPrefix, WRData)
                    Else
                        WRData = WaferRunDataMap.Item(strPrefix)
                        Dim strIndex As String = strPM.Substring(strPM.LastIndexOf("_") + 1)
                        If Not (WRData.ListOfPM.ContainsValue(strPM)) Then
                            WRData.ListOfPM.Add(IIf(IsNumeric(strIndex), CInt(strIndex), 0), strPM)
                        End If
                    End If
                End If
            Next
            For Each item As String In WaferRunDataMap.Keys
                If item.Contains(strShortDate) Then
                    'push into DataTable
                    WRData = WaferRunDataMap.Item(item)
                    If WRData IsNot Nothing Then
                        Dim newRow As DataRow
                        newRow = m_dtWaferRunFile.NewRow
                        '#08/15/2011 
                        '#-Wafer run.   There are duplicate date in wafer run.  We can remove the date and leave only the time 
                        '# since date is already show on top.   LotID field can be longer since the date is remove.
                        '#Begin fix
                        Dim timetoSort As DateTime = DateTime.ParseExact(WRData.CreatedTime, "yyyy_MM_dd_HH_mm_ss", Nothing)
                        Dim timspan As TimeSpan = New TimeSpan(timetoSort.Hour, timetoSort.Minute, timetoSort.Second)
                        newRow(AT_TIME) = timetoSort.ToString("HH_mm_ss")
                        '#End fix
                        newRow(LOADLOCK) = WRData.LLName
                        newRow(LOT_ID) = WRData.LotID
                        newRow(SLOT_ID) = WRData.SlotID
                        newRow(FILE_NAME) = WRData.PrefixFile
                        newRow(TIME_TOSORT) = timspan.TotalSeconds
                        m_dtWaferRunFile.Rows.Add(newRow)
                    End If
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''Hoa Nguyen 
    Private Function GetSelectedValueToCompare(ByVal strPath As String, ByVal stepNo As String, ByVal ValueToCompare As String) As List(Of DataValue)
        Dim list As New List(Of DataValue)
        Try
            If strPath.EndsWith(STR_CSV_EXT) Then
                If m_dicStepData.ContainsKey(stepNo) AndAlso m_dicStepData(stepNo).ContainsKey(ValueToCompare) Then
                    Dim lstValue As New List(Of String)(m_dicStepData(stepNo)(ValueToCompare))
                    Dim lstTime As New List(Of String)(m_dicStepData(stepNo)("Time"))

                    Dim strPrevTime As String = String.Empty
                    Dim dtTime As Double = 0
                    For i As Integer = 0 To lstTime.Count - 1
                        Dim newData As New DataValue

                        If String.IsNullOrEmpty(strPrevTime) Then
                            dtTime = 0 'Start Time
                        Else
                            Dim dt1 As DateTime = SampleData.ParseDateTime(strPrevTime)
                            Dim dt2 As DateTime = SampleData.ParseDateTime(lstTime(i))
                            Dim span As TimeSpan = dt2 - dt1
                            dtTime = span.TotalSeconds
                        End If
                        strPrevTime = lstTime(i)
                        newData.Time = dtTime ''for draw graph
                        list.Add(newData)
                        list.Item(i).Value = lstValue.Item(i)
                    Next
                End If
                
            Else 'XML
                Dim xmlDocument As Xml.XmlDocument = New Xml.XmlDocument()
                xmlDocument.Load(strPath)
                If xmlDocument Is Nothing Then
                    Exit Try
                End If
                Dim xmlListNode As Xml.XmlNodeList = xmlDocument.SelectNodes("//Step[Number=" & stepNo & "]/SampleList/Sample/" & ValueToCompare)
                Dim xmlListTime As Xml.XmlNodeList = xmlDocument.SelectNodes("//Step[Number=" & stepNo & "]/SampleList/Sample/Time")
                Dim strPrevTime As String = String.Empty
                Dim dtTime As Double = 0
                For Each xmlNode As Xml.XmlNode In xmlListTime
                    Dim newData As New DataValue

                    If String.IsNullOrEmpty(strPrevTime) Then
                        dtTime = 0 'Start Time
                    Else
                        Dim dt1 As DateTime = SampleData.ParseDateTime(strPrevTime)
                        Dim dt2 As DateTime = SampleData.ParseDateTime(xmlNode.InnerText)
                        Dim span As TimeSpan = dt2 - dt1
                        dtTime = span.TotalSeconds
                    End If
                    strPrevTime = xmlNode.InnerText
                    newData.Time = dtTime ''for draw graph
                    list.Add(newData)
                Next

                For i As Integer = 0 To xmlListNode.Count - 1
                    list.Item(i).Value = xmlListNode.Item(i).InnerText
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return list
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-08-25</date>
    ''' </author>
    ''' <summary>
    '''Get All Attributes from Xml Sample Node
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GetAllAttributesFromNode(ByVal strPath As String, ByVal stepNo As String)
        Try
            If strPath.EndsWith(STR_CSV_EXT) Then
                If m_dicStepData.ContainsKey(stepNo) Then
                    Dim lstKeys As New List(Of String)(m_dicStepData(stepNo).Keys)
                    For Each str As String In lstKeys
                        If str = "Sample" OrElse str = "Time" OrElse Not IsNumeric(m_dicStepData(stepNo)(str).Item(0)) Then
                            Continue For
                        End If
                        lstValue.Items.Add(str)
                    Next
                End If
                
            Else 'XML
                Dim xmlDocument As Xml.XmlDocument = New Xml.XmlDocument()
                xmlDocument.Load(strPath)
                If xmlDocument Is Nothing Then
                    Exit Try
                End If
                Dim xmlListNode As Xml.XmlNode = xmlDocument.SelectSingleNode("//Step[Number=" & stepNo & "]")
                xmlListNode = xmlListNode.SelectSingleNode("SampleList")
                Dim strPrevTime As String = String.Empty
                Dim dtTime As Integer = 0
                For Each xmlNode As Xml.XmlNode In xmlListNode.FirstChild.ChildNodes
                    If xmlNode.Name = "Seq" OrElse xmlNode.Name = "Time" OrElse Not IsNumeric(xmlNode.InnerText) Then
                        Continue For
                    End If
                    lstValue.Items.Add(xmlNode.Name)
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-08-25</date>
    ''' </author>
    ''' <summary>
    '''Get All Step from Xml Node
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Function GetAllStepNode(ByVal strPath As String) As List(Of String)
        Dim list As New List(Of String)
        Try
            If strPath.EndsWith(STR_CSV_EXT) Then
                m_listOfAllTags = New List(Of String)
                m_dicStepData = New Dictionary(Of String, Dictionary(Of String, List(Of String)))
                Dim isValidFormat As Boolean = False

                Dim fs As FileStream = New FileStream(strPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Using csvReader As StreamReader = New StreamReader(fs)
                    Dim line As String = String.Empty
                    Dim stepNum As String = String.Empty
                    Do
                        line = csvReader.ReadLine()
                        If line Is Nothing Then Exit Do
                        Dim arrColumn As String() = line.Trim().Split(",")
                        If arrColumn.Length > 2 Then
                            If arrColumn(0).StartsWith("Step No") AndAlso arrColumn(1).StartsWith("Sample") Then
                                isValidFormat = True
                                For index As Integer = 1 To arrColumn.Length - 1
                                    m_listOfAllTags.Add(arrColumn(index))
                                Next
                            Else
                                If isValidFormat Then
                                    If Not m_dicStepData.ContainsKey(arrColumn(0)) Then
                                        m_dicStepData.Add(arrColumn(0), New Dictionary(Of String, List(Of String)))

                                        For Each column As String In m_listOfAllTags
                                            m_dicStepData(arrColumn(0)).Add(column, New List(Of String))
                                        Next
                                    End If

                                    For index As Integer = 1 To arrColumn.Length - 1
                                        m_dicStepData(arrColumn(0))(m_listOfAllTags(index - 1)).Add(arrColumn(index))
                                    Next
                                End If
                            End If
                        End If
                    Loop Until line Is Nothing
                End Using

                Dim lstKeys As New List(Of String)(m_dicStepData.Keys)
                For Each str As String In lstKeys
                    list.Add("Step-" & str.ToString())
                Next
            Else 'XML
                Dim xmlDocument As Xml.XmlDocument = New Xml.XmlDocument()
                xmlDocument.Load(strPath)
                If xmlDocument Is Nothing Then
                    Exit Try
                End If
                Dim xmlNode As Xml.XmlNode = xmlDocument.SelectSingleNode("/RunData/ChamberList/Chamber/StepList")
                For j As Integer = 1 To xmlNode.ChildNodes.Count
                    list.Add("Step-" & j.ToString())
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return list
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-08-25</date>
    ''' </author>
    ''' <summary>
    '''return PMx from selected Wafer Run 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub RowSelectedChanged(ByVal rowIndex As Integer)
        Try
            Dim strPrefixFile As String = String.Empty
            If Not (strPrefixFile = Me.dgvWFList.Item(FILE_NAME, rowIndex).Value) Then
                strPrefixFile = Me.dgvWFList.Item(FILE_NAME, rowIndex).Value
                m_strCurrentPrefix_SelectedFile = strPrefixFile
            End If

            If Not String.IsNullOrEmpty(strPrefixFile) Then
                Dim objWRData As WaferRunData = Me.WaferRunDataMap(strPrefixFile)
                lstPM.Items.Clear()
                If objWRData IsNot Nothing Then
                    For Each strPM As KeyValuePair(Of Integer, String) In objWRData.ListOfPM
                        lstPM.Items.Add(strPM.Value)
                    Next
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-08-25</date>
    ''' </author>
    ''' <summary>
    '''return PMx from selected Wafer Run 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GetWRDATAFrom_CurrentDate()
        Try
            GetAllDataFile_ToDataTable(Format(dtFilter.Value, "yyyy_MM_dd"))
            dgvWFList.DataSource = m_dtWaferRunFile
            dgvWFList.Sort(dgvWFList.Columns(TIME_TOSORT), System.ComponentModel.ListSortDirection.Descending)
            dgvWFList.Columns(FILE_NAME).Visible = False
            dgvWFList.Columns(TIME_TOSORT).Visible = False
            dgvWFList.Refresh()
            lstPM.Items.Clear()
            lstStep.Items.Clear()
            lstValue.Items.Clear()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Event Handler"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-08-25</date>
    ''' </author>
    ''' <summary>
    '''Select Value from Grid
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvWRL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWFList.CellClick
        Try
            If e.RowIndex >= 0 Then
                RowSelectedChanged(e.RowIndex)
                lstStep.Items.Clear()
                lstValue.Items.Clear()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-08-25</date>
    ''' </author>
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-08-25</date>
    ''' </author>
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lstPM_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstPM.SelectedValueChanged
        Try
            lstStep.Items.Clear()
            If Not String.IsNullOrEmpty(lstPM.SelectedItem) Then
                Dim strPath As String = GetWaferRunFilepath()

                Dim lst As List(Of String) = GetAllStepNode(strPath)
                For Each str As String In lst
                    lstStep.Items.Add(str)
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-08-25</date>
    ''' </author>
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lstStep_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstStep.SelectedValueChanged
        Try
            Dim strPath As String = GetWaferRunFilepath()

            Dim strStepNo As String = lstStep.SelectedItem.ToString().Replace("Step-", "")
            lstValue.Items.Clear()
            GetAllAttributesFromNode(strPath, strStepNo)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-08-25</date>
    ''' </author>
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If lstValue.SelectedItems.Count > 0 Then
                For Each item As String In lstValue.SelectedItems
                    Dim strPath As String = GetWaferRunFilepath()

                    Dim strStepNo As String = lstStep.SelectedItem.ToString().Replace("Step-", "")
                    Dim ListOfValue As List(Of DataValue) = GetSelectedValueToCompare(strPath, strStepNo, item)
                    Dim tagname As String = String.Empty
                    tagname = m_strCurrentPrefix_SelectedFile & AVPLib.ConstEnum.DataRunFileNameSeparator & lstPM.SelectedItem.ToString() & "_" & lstStep.SelectedItem.ToString() & "_" & item
                    If Not m_lstResult.ContainsKey(tagname) Then
                        m_lstResult.Add(tagname, ListOfValue)
                    End If
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Function GetWaferRunFilepath() As String
        Try
            Dim strPrefixFileName As String = m_CurrentFolderPath & "\" & m_strCurrentPrefix_SelectedFile & AVPLib.ConstEnum.DataRunFileNameSeparator & lstPM.SelectedItem.ToString()
            ' Try get for new format "~~~"
            Dim objWRData As WaferRunData = Me.WaferRunDataMap(m_strCurrentPrefix_SelectedFile)
            If Not String.IsNullOrEmpty(objWRData.RunNo) Then
                strPrefixFileName = strPrefixFileName & AVPLib.ConstEnum.DataRunFileNameSeparator & objWRData.RunNo
            End If

            Dim strPath As String = String.Empty
            If File.Exists(strPrefixFileName & STR_CSV_EXT) Then
                strPath = strPrefixFileName & STR_CSV_EXT
            ElseIf File.Exists(strPrefixFileName & STR_XML_EXT) Then
                strPath = strPrefixFileName & STR_XML_EXT
            End If
            Return strPath
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function

    Private Sub PopUpWaferRun_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub dtFilter_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFilter.ValueChanged
        Try
            GetWRDATAFrom_CurrentDate()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region


End Class