Imports ZedGraph
Imports System.IO
Imports System.Text
Imports System.Xml
Imports AVPLib.ConstEnum
Imports AVPLib.ContainerDAO
Imports AVP_Robot_Project.ConstantAndEnum
Imports System
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class WaferRun
    'Only one Chamber in ChamberList
#Region "Const and variables"
    Const TOTAL_COLUMN_OF_ALIGNER_DATARUN As Integer = 6
    Const INDEX_OF_RECIPE_NAME_COLUMN As Integer = 0
    Const INDEX_OF_ECC_ANGLE_COLUMN As Integer = 1
    Const INDEX_OF_ECC_MAG_COLUMN As Integer = 2
    Const INDEX_OF_DELTA_R_COLUMN As Integer = 3
    Const INDEX_OF_DELTA_T_COLUMN As Integer = 4
    Const INDEX_OF_FIDUCIAL_ANGLE_COLUMN As Integer = 5
    Const INDEX_OF_RESCAN_COLUMN As Integer = 6

    Protected Const AT_TIME As String = "At Time"
    Const LOADLOCK As String = "LL"
    Protected Const LOT_ID As String = "Lot ID"
    Protected Const FILE_NAME As String = "File Name"
    Const SLOT_ID As String = "Slot ID"
    Protected Const TIME_TOSORT As String = "Time"
    Protected Const RUN_NO As String = "Run No."

    Protected m_strLotID As String = String.Empty
    Private m_strSlotId As String = String.Empty
    Protected m_newWRDATA_Added As WaferRunData = Nothing 'store newest Wafer Run

    Protected m_dtWaferRunFile As DataTable = Nothing
    Protected m_hstWaferRunData As Hashtable = Nothing 'key -> prefix ; value -> waferRunData

    Protected Delegate Sub UpdateRunDataFilesGrid(ByVal obj As Object)

    'Variables for no update WR details when finish logging.
    Protected m_IsUpdateWaferRunDetails As Boolean = True
    Protected m_KeyWRFileNameUseForUpdateWRDetails As String = String.Empty
    Private m_PreviousPrefixFile As String = String.Empty
#End Region

    Public ReadOnly Property WaferRunDataMap() As Hashtable
        Get
            Return m_hstWaferRunData
        End Get
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckPermission()
        '#03/07/2011 
        '#[Sl_Build 12_Feb 16, 2011]User account should be similar to avp/pvd request
        '#Begin fix:
        If AVPLib.ContainerData.Permission(PERMISSION_011) Then
            ActiveInActiveForm(True)
        Else
            ActiveInActiveForm(False)
        End If
        '#End fix.
    End Sub

    Private Sub ActiveInActiveForm(ByVal blnStatus As Boolean)
        Try
            dtFilter.Enabled = blnStatus
            btnApply.Enabled = blnStatus
            tabWaferRun.Enabled = blnStatus
            dgvWFList.Enabled = blnStatus
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            m_stoStatusObject.Name = Me.Name
            Dim stbRefresh As New StatusIGCGButton(btnRefresh)
            m_stoStatusObject.AddChild(stbRefresh)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#Region "Show Wafer Run to Grid"
     ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''Update DataGridView 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub UpdateGUI(ByVal obj As Object)
        Try
            Dim dtWaferRunFile As DataTable = CType(obj, DataTable)
            dgvWFList.Sort(dgvWFList.Columns(TIME_TOSORT), ComponentModel.ListSortDirection.Descending)
            Me.dgvWFList.DataSource = dtWaferRunFile
            Me.dgvWFList.Columns(FILE_NAME).Visible = False
            Me.dgvWFList.Columns(TIME_TOSORT).Visible = False
            Me.dgvWFList.Refresh()
            RefreshFilter()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overridable Sub RefreshFilter()
        Try
            If m_dtWaferRunFile IsNot Nothing AndAlso m_dtWaferRunFile.Rows.Count > 0 Then
                dgvWFList.Sort(dgvWFList.Columns(TIME_TOSORT), ComponentModel.ListSortDirection.Descending)
                Dim curRowSelected As Integer = dgvWFList.SelectedCells(0).RowIndex
                'For Each wrRow As DataGridViewRow In dgvWFList.Rows
                '    If m_newWRDATA_Added IsNot Nothing AndAlso (wrRow.Cells(AT_TIME).Value = Me.m_newWRDATA_Added.CreatedTime And _
                '                                                wrRow.Cells(LOT_ID).Value = Me.m_newWRDATA_Added.LotID And _
                '                                                wrRow.Cells(SLOT_ID).Value = Me.m_newWRDATA_Added.SlotID And _
                '                                                wrRow.Cells(LOADLOCK).Value = Me.m_newWRDATA_Added.LLName) Then
                '        curRowSelected = wrRow.Index
                '        dgvWFList.Rows.Item(curRowSelected).Selected = True
                '        Exit For
                '    ElseIf m_newWRDATA_Added Is Nothing Then
                '        Exit For
                '    End If
                'Next

                If m_IsUpdateWaferRunDetails Then
                    If curRowSelected >= 0 Then
                        RowSelectedChanged(curRowSelected)
                    End If
                Else
                    For Each dtRow As Windows.Forms.DataGridViewRow In dgvWFList.Rows
                        If dtRow.Cells(FILE_NAME).Value = m_KeyWRFileNameUseForUpdateWRDetails Then
                            dgvWFList.Rows(dtRow.Index).Selected = True
                            RowSelectedChanged(dtRow.Index)
                        End If
                    Next
                End If

            Else
                dgvWFList.DataSource = Nothing
                Me.tabWaferRun.TabPages.Clear()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2011-07-30</date>
    ''' </author>
    ''' <summary>
    ''' Support no update WR details when finish logging.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub RefreshWaferRunListCallWhenComplete()
        Try
            If (dgvWFList.Rows.Count > 0) AndAlso (dgvWFList.SelectedRows(0) IsNot Nothing) Then
                m_IsUpdateWaferRunDetails = False
                m_KeyWRFileNameUseForUpdateWRDetails = dgvWFList.SelectedRows(0).Cells(FILE_NAME).Value
            End If

            GetAllWaferRunDataFile()
            m_IsUpdateWaferRunDetails = True
            m_KeyWRFileNameUseForUpdateWRDetails = String.Empty
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    ''' Load all Data File to Storage
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Overridable Sub GetAllWaferRunDataFile()
        Try
            Dim strShortDate As String = Format(dtFilter.Value, "yyyy_MM_dd")
            Dim strFolder As String = AVPLib.ContainerDAO.FPath_RunDataOfWafer & "\" & strShortDate
            If m_dtWaferRunFile IsNot Nothing Then
                m_dtWaferRunFile.Rows.Clear()
            End If
            If Not System.IO.Directory.Exists(strFolder) Then
                RefreshFilter()
                Exit Sub
            End If
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
                If AVPLib.ContainerDAO.EnableRunNo Then
                    dtCol = New DataColumn(RUN_NO)
                    m_dtWaferRunFile.Columns.Add(dtCol)
                End If
            End If
            Dim WRData As WaferRunData = Nothing
            m_hstWaferRunData.Clear()

            Dim alFiles As List(Of String) = New List(Of String)()
            Dim exts() As String = {"*.xml", "*.csv"}
            For Each ext As String In exts
                alFiles.AddRange(Directory.GetFiles(strFolder, ext))
            Next

            If alFiles.Count > 0 Then
                Const PMDataRunFilenamePattern As String = ".\SPM\d_\d."

                Dim sortedDataRunFilenames As New List(Of String)()
                For Each filename As String In alFiles
                    If Regex.IsMatch(filename, PMDataRunFilenamePattern) Then
                        sortedDataRunFilenames.Insert(0, filename)
                    Else
                        sortedDataRunFilenames.Add(filename)
                    End If
                Next

                For filenameIndex As Integer = sortedDataRunFilenames.Count - 1 To 0 Step -1
                    Dim filename As String = sortedDataRunFilenames(filenameIndex)

                    If System.IO.File.Exists(filename) Then
                        Dim dataRunSeparator As String = SPACE_STRING
                        If (filename.Contains(AVPLib.ConstEnum.DataRunFileNameSeparator)) Then
                            dataRunSeparator = AVPLib.ConstEnum.DataRunFileNameSeparator
                        End If

                        Dim strFullPathFile As String = filename
                        filename = AVPLib.Utils.GetFileName(filename, True)
                        ''push files into data structure
                        '2010_09_24_03_24_21 KAJSDFLDS_LLA_1-2-3 PM2_2.xml
                        '2010_09_24_03_24_21 KAJSDFLDS_LLA_1     PM2_2.xml
                        '2010_09_24_01_48_45           LLA_12    PM2.xml
                        Dim arrFileName As String()
                        arrFileName = filename.Split(New String() {dataRunSeparator}, StringSplitOptions.RemoveEmptyEntries)
                        Dim strTime As String = String.Empty
                        Dim strPM As String = String.Empty
                        Dim strFileInfo As String = String.Empty
                        Dim strPrefix As String = String.Empty
                        Dim strListWafer As String = String.Empty ''1-2-3 or 1 or 1-2
                        Dim arrWaferID As String() = Nothing
                        Dim strLLSlotAndPM As String = String.Empty
                        Dim strRunNo As String = String.Empty
                        If arrFileName.Length >= 3 Then
                            Dim index As Integer = 1
                            If arrFileName.Length = 4 Then
                                index = 2
                                strRunNo = arrFileName(3)
                                filename = filename.Substring(0, filename.LastIndexOf(dataRunSeparator))
                            End If
                            strTime = arrFileName(0)
                            strPM = arrFileName(arrFileName.Length() - index)
                            strLLSlotAndPM = arrFileName(arrFileName.Length() - (index + 1)) & dataRunSeparator & arrFileName(arrFileName.Length() - index)
                            strFileInfo = filename.Replace(strTime, "")
                            strFileInfo = strFileInfo.Replace(strPM, "")
                            strFileInfo = strFileInfo.Trim(dataRunSeparator)
                            Dim arrWafer As String() = strFileInfo.Split(New String() {"_"}, StringSplitOptions.RemoveEmptyEntries)
                            If arrWafer.Length > 1 Then
                                strFileInfo = arrWafer(0)
                                For i As Int16 = 1 To arrWafer.Length - 2
                                    strFileInfo = strFileInfo & "_" & arrWafer(i)
                                Next
                                strListWafer = arrWafer(arrWafer.Length - 1)
                                arrWaferID = arrWafer(arrWafer.Length - 1).Split(New String() {"-"}, StringSplitOptions.RemoveEmptyEntries)
                            End If
                            'If arrWafer.Length = 2 Then
                            '    strFileInfo = arrWafer(0)
                            '    strListWafer = arrWafer(1)
                            '    arrWaferID = arrWafer(1).Split(New String() {"-"}, StringSplitOptions.RemoveEmptyEntries)
                            'ElseIf arrWafer.Length = 3 Then
                            '    strFileInfo = arrWafer(0) & "_" & arrWafer(1)
                            '    strListWafer = arrWafer(2)
                            '    arrWaferID = arrWafer(2).Split(New String() {"-"}, StringSplitOptions.RemoveEmptyEntries)
                            'ElseIf arrWafer.Length = 4 Then
                            '    strFileInfo = arrWafer(0) & "_" & arrWafer(1) & "_" & arrWafer(2)
                            '    strListWafer = arrWafer(3)
                            '    arrWaferID = arrWafer(3).Split(New String() {"-"}, StringSplitOptions.RemoveEmptyEntries)
                            'End If
                            strPrefix = strTime & dataRunSeparator & strFileInfo ''it must be: 2010_09_24_03_24_21 KAJSDFLDS_LLA
                        End If
                        If arrWaferID Is Nothing OrElse arrWaferID.Length = 0 Then
                            AVPLib.Log.avpLogger.Error("Error File Name: " & filename)
                            Exit Sub
                        End If
                        Dim strListOfPrefix As String = strPrefix & "_" & strListWafer
                        For Each strWaferID As String In arrWaferID
                            'check if  2010_09_24_03_24_21 KAJSDFLDS_LLA_1 exists or not
                            Dim prefix As String = strPrefix
                            prefix = strPrefix & "_" & strWaferID

                            ' case list waferid is 1,2,3,4,... then waferID first add more #
                            If arrWaferID.Length > 1 And strWaferID = arrWaferID(0) Then
                                prefix = prefix & "#"
                            End If

                            'If PM Wafer Run file => add to all list associated with aliger
                            If filename.Contains("PM") Then
                                Dim bAdded As Boolean = False
                                For Each item As String In m_hstWaferRunData.Keys
                                    If item.Contains(strPrefix) Then
                                        WRData = m_hstWaferRunData.Item(item)
                                        Dim strIndex As String = strPM.Substring(strPM.LastIndexOf("_") + 1)
                                        If Not (WRData.ListOfPM.ContainsValue(strLLSlotAndPM)) Then
                                            Dim iIndex As Integer = 0
                                            If IsNumeric(strIndex) Then
                                                iIndex = CInt(strIndex)
                                            End If
                                            WRData.ListOfPM.Add(iIndex, strLLSlotAndPM)
                                            WRData.ListOfPrefixFile.Add(iIndex, strListOfPrefix)
                                            m_newWRDATA_Added = WRData
                                            bAdded = True
                                        End If
                                    End If
                                Next

                                If Not bAdded Then
                                    GoTo ADD_TO_DATA
                                End If
                            ElseIf Not m_hstWaferRunData.ContainsKey(prefix) Then
ADD_TO_DATA:
                                WRData = New WaferRunData
                                WRData.PrefixFile = prefix
                                Dim arrFileInfo As String() = strFileInfo.Split(New String() {"_"}, StringSplitOptions.RemoveEmptyEntries)
                                If arrFileInfo.Length >= 1 Then
                                    WRData.SlotID = strWaferID
                                    WRData.LLName = arrFileInfo(arrFileInfo.Length - 1)
                                    WRData.LotID = GetLOTIDFromFileName(filename)
                                    WRData.CreatedTime = strTime
                                    WRData.RunNo = strRunNo
                                End If
                                If strPM.Contains("_") Then
                                    Dim strIndex As String = strPM.Substring(strPM.LastIndexOf("_") + 1)
                                    Dim iIndex As Integer = 0
                                    If IsNumeric(strIndex) Then
                                        iIndex = CInt(strIndex)
                                    End If
                                    WRData.ListOfPM.Add(iIndex, strLLSlotAndPM)
                                    WRData.ListOfPrefixFile.Add(iIndex, strListOfPrefix)
                                Else
                                    WRData.ListOfPM.Add(0, strLLSlotAndPM)
                                    WRData.ListOfPrefixFile.Add(0, strListOfPrefix)
                                End If
                                'push into hashtable
                                If (Not m_hstWaferRunData.ContainsKey(prefix)) Then
                                    m_hstWaferRunData.Add(prefix, WRData)
                                    m_newWRDATA_Added = WRData
                                End If
                            Else 'exists -> add to hashtable
                                WRData = m_hstWaferRunData.Item(prefix)
                                Dim strIndex As String = strPM.Substring(strPM.LastIndexOf("_") + 1)
                                If Not (WRData.ListOfPM.ContainsValue(strLLSlotAndPM)) Then
                                    Dim iIndex As Integer = 0
                                    If IsNumeric(strIndex) Then
                                        iIndex = CInt(strIndex)
                                    End If
                                    WRData.ListOfPM.Add(iIndex, strLLSlotAndPM)
                                    WRData.ListOfPrefixFile.Add(iIndex, strListOfPrefix)
                                    m_newWRDATA_Added = WRData
                                End If
                            End If
                        Next
                    End If
                Next
                For Each item As String In m_hstWaferRunData.Keys
                    'push into DataTable
                    WRData = m_hstWaferRunData.Item(item)
                    If WRData IsNot Nothing Then
                        Dim timetoSort As DateTime
                        If DateTime.TryParseExact(WRData.CreatedTime, "yyyy_MM_dd_HH_mm_ss", Nothing, DateTimeStyles.None, timetoSort) Then
                            Dim newRow As DataRow
                            newRow = m_dtWaferRunFile.NewRow
                            '#08/15/2011 
                            '#-Wafer run.   There are duplicate date in wafer run.  We can remove the date and leave only the time 
                            '# since date is already show on top.   LotID field can be longer since the date is remove.
                            '#Begin fix
                            Dim timspan As TimeSpan = New TimeSpan(timetoSort.Hour, timetoSort.Minute, timetoSort.Second)
                            newRow(AT_TIME) = timetoSort.ToString("HH_mm_ss")
                            '#End fix
                            newRow(LOADLOCK) = WRData.LLName
                            newRow(LOT_ID) = WRData.LotID
                            newRow(SLOT_ID) = WRData.SlotID

                            If AVPLib.ContainerDAO.EnableRunNo Then
                                newRow(RUN_NO) = WRData.RunNo
                            End If

                            newRow(FILE_NAME) = WRData.PrefixFile
                            newRow(TIME_TOSORT) = timspan.TotalSeconds + WRData.SlotID ' If same time, sort in Slot ID
                            m_dtWaferRunFile.Rows.Add(newRow)
                        End If
                    End If
                Next

                If Me.InvokeRequired Then
                    Invoke(New UpdateRunDataFilesGrid(AddressOf UpdateGUI), m_dtWaferRunFile)
                Else
                    Me.dgvWFList.DataSource = m_dtWaferRunFile
                    Me.dgvWFList.Columns(FILE_NAME).Visible = False
                    Me.dgvWFList.Columns(TIME_TOSORT).Visible = False
                    Me.dgvWFList.Columns(AT_TIME).Width = 80
                    Me.dgvWFList.Columns(LOT_ID).Width = 195
                    Me.dgvWFList.Columns(LOADLOCK).Width = 60
                    Me.dgvWFList.Columns(SLOT_ID).Width = 50

                    If AVPLib.ContainerDAO.EnableRunNo Then
                        Me.dgvWFList.Columns(RUN_NO).AutoSizeMode() = DataGridViewAutoSizeColumnMode.Fill
                    Else
                        Me.SplitContainer1.Size = New Size(1270, 652)
                        Me.SplitContainer1.SplitterDistance = 420
                        Me.dgvWFList.Size = New Size(420, 616)
                        Me.btnApply.Size = New Size(83, 32)
                        Me.btnApply.Location = New Point(337, 2)
                        Me.dtFilter.Size = New Size(127, 29)
                        Me.dtFilter.Location = New Point(210, 3)
                        Me.Label1.Size = New Size(420, 36)
                        Me.dgvWFList.Columns(SLOT_ID).AutoSizeMode() = DataGridViewAutoSizeColumnMode.Fill
                    End If
                    Me.dgvWFList.Refresh()
                    RefreshFilter()
                End If

                sortedDataRunFilenames.Clear()
            End If

            alFiles.Clear()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-05-29</date>
    ''' <summary>
    ''' Get LotID from filename.
    ''' </summary>
    Public Shared Function GetLOTIDFromFileName(ByVal fileName As String) As String
        Try
            Const FileNamePattern As String = "^(?<dateTime>[0-9_\-]*)\s(?<lotInfo>.*)\s(?<pmInfo>[a-zA-Z0-9_\-]*)$"
            Const LotInfoPattern As String = "^((?<lotId>.*)_)?(?<loadLock>[a-zA-Z]*)_(?<slots>[0-9\-]*)$"

            fileName = fileName.Replace(AVPLib.ConstEnum.DataRunFileNameSeparator, SPACE_STRING)
            Dim fileNameMatch As Match = Regex.Match(fileName, FileNamePattern)
            If fileNameMatch.Success Then
                Dim lotInfo As String = fileNameMatch.Groups("lotInfo").Value
                Dim lotInfoMatch As Match = Regex.Match(lotInfo, LotInfoPattern)
                If lotInfoMatch.Success Then
                    Dim lotId As String = lotInfoMatch.Groups("lotId").Value
                    If Not String.IsNullOrEmpty(lotId) Then
                        Return lotId
                    Else
                        Return lotInfoMatch.Groups("loadLock").Value
                    End If
                Else
                    ' Returns whole lot info if parse failed.
                    Return lotInfo
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function

  
#End Region
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub WaferRun_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim strShortDate As String = Format(dtFilter.Value, "yyyy_MM_dd")
            GetAllWaferRunDataFile()

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
                    Dim strWaferID As String = String.Empty
#If AVP_PLATFORM = "CX" Then
                    strWaferID = IIf(objwaferRunData.LLName = AVPLib.ConstEnum.LLA_STR, "A", "B")
                    strWaferID &= objwaferRunData.SlotID
#End If
                    CreateTabPages(objwaferRunData.ListOfPM, defaultfile, strShortDate, strWaferID)
                End If
            End If
            SetLabelItemCount()
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
    Private Sub TabSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabWaferRun.SelectedIndexChanged
        Try
            If tabWaferRun.SelectedTab Is Nothing Then
                Exit Sub
            End If
            OpenDataOn_SelectedTab(tabWaferRun.SelectedTab)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overridable Sub OpenDataOn_SelectedTab(ByVal tabpageCtl As TabPage)
        Try
            If tabpageCtl.Text.Contains(AVPLib.ConstEnum.Equipments.Aligner.ToString()) Then
                '0008975: [TamHuynh - 01/20/2016] Wafer Run List is disabled when user select wafers run empty (Wafer run only has "Aligner")
                dgvWFList.Enabled = True
                Exit Try
            End If
            Dim dataRunSeparator As String = AVPLib.ConstEnum.DataRunFileNameSeparator
            If tabWaferRun.SelectedTab.Tag.ToString().Contains(AVPLib.ConstEnum.DataRunFileNameSeparator) Then
                dataRunSeparator = AVPLib.ConstEnum.DataRunFileNameSeparator
            End If

            Dim objSampledata As SampleData = CType(tabpageCtl.Controls.Item(0), SampleData)
            Dim strPrefixFile As String = tabWaferRun.SelectedTab.Tag & dataRunSeparator & tabWaferRun.SelectedTab.Name
            Dim strFileName As String = String.Empty

            If System.IO.File.Exists(strPrefixFile & STR_CSV_EXT) Then
                strFileName = strPrefixFile & STR_CSV_EXT
            ElseIf System.IO.File.Exists(strPrefixFile & STR_XML_EXT) Then
                strFileName = strPrefixFile & STR_XML_EXT
            Else
                AVPLib.Log.avpLogger.Error("Can not Open File : " & strPrefixFile & " in both csv or xml format")
            End If
            dgvWFList.Enabled = False

            If strFileName.EndsWith(STR_XML_EXT) Then
                Dim xmlDoc As XmlDocument = Nothing
                Try
                    xmlDoc = New XmlDocument
                    AVPLib.Utils.LoadFileXML(xmlDoc, strFileName)
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                    Utils.ShowAVPMessageBox("Error in loading datarun file: " & AVPLib.Utils.GetFileName(strFileName, True), "Error Loading file", MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                    xmlDoc = Nothing
                    Exit Try
                End Try
                xmlDoc = Nothing
            End If

            If String.IsNullOrEmpty(objSampledata.DataFile) Then
                objSampledata.DataFile = strFileName
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

    Protected Sub FinishLoadingFile(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dgvWFList.Enabled = True
    End Sub

    Protected Overridable Sub CreateTabPages(ByVal ListOfPMRelevant As SortedDictionary(Of Integer, String), ByVal PrefixFile As String, ByVal strFolderName As String, Optional ByVal strWaferID As String = "")
        Try
            ' [KhoiHa 02/14/2014] While user is view wafer run and there is some update on wafer run list, 
            ' it appear that user view got switch and user have to re-click on the wafer run again to view.
            If m_PreviousPrefixFile = PrefixFile Then
                Exit Sub
            End If
            m_PreviousPrefixFile = PrefixFile
            'End ----------------------------------------------------------------------------------------

            If tabWaferRun.TabPages.Count > 0 Then
                Dim tabPage As TabPage = tabWaferRun.TabPages.Item(0)
                If tabPage.Tag IsNot Nothing AndAlso tabPage.Tag.ToString().Contains(PrefixFile) Then ''-> update current tab
                    For Each pair As KeyValuePair(Of Integer, String) In ListOfPMRelevant
                        Dim blnCreateTab As Boolean = True
                        For Each tabitem As TabPage In tabWaferRun.TabPages
                            Dim strNameArr As String() = pair.Value.Split(" ")
                            Dim strName As String = pair.Value
                            If strNameArr.Length > 1 Then
                                strName = strNameArr(strNameArr.Length - 1)
                            End If
                            If tabitem.Name = strName Then
                                blnCreateTab = False
                            End If
                        Next
                        If blnCreateTab Then
                            CreateTabPage(pair, strFolderName, PrefixFile)
                        End If
                    Next
                    'Me.tabWaferRun.SelectedTab = IIf(Me.tabWaferRun.TabCount > 0, Me.tabWaferRun.TabPages(0), Nothing)
                    Exit Try
                End If
            End If

            '2013-06-03 Tin Pham: Support cancel BackgroupWorker before go to new SampleData
            If tabWaferRun.TabPages IsNot Nothing AndAlso tabWaferRun.TabPages.Count > 0 Then
                For Each tab As TabPage In tabWaferRun.TabPages
                    If Not tab.Text.Contains(AVPLib.ConstEnum.Equipments.Aligner.ToString()) AndAlso _
                       tab.Controls.Count > 0 Then
                        Dim objSampledata As SampleData = CType(tab.Controls.Item(0), SampleData)
                        objSampledata.CancelDataFile()
                        objSampledata.UnInitialize()
                    End If
                Next
            End If
            'End--------------------------------------------------------------------------

            '#03/19/2012
            '# - CVC25.  AVP crashed when user look at datarun logs.   Not sure what user did,  maybe clicking on different
            ' datarun too fast?   Please look at errorlogs on 3-16-2012 around 3:00PM.   
            'Should have a catch to prevent software from crashing. 
            '# Begin fix: Must dispose controls first and clear after that intead of clear them. User objects still exist 
            ' on memory after clear, so when there are over 10000 objects, crash occur.

            ' IMPORTANT CODE => OUT OF MEMORY IF MISSING [Dat Vo]
            For i As Integer = Me.tabWaferRun.Controls.Count - 1 To 0 Step -1 'Dispose object
                Me.tabWaferRun.Controls(i).Dispose()
            Next

            Me.tabWaferRun.Controls.Clear()
            '#End fix.

            For Each pair As KeyValuePair(Of Integer, String) In ListOfPMRelevant ''-> create new tab
                CreateTabPage(pair, strFolderName, PrefixFile)
            Next

            'Me.tabWaferRun.SelectedTab = IIf(Me.tabWaferRun.TabCount > 0, Me.tabWaferRun.TabPages(0), Nothing)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        If tabWaferRun.TabPages.Count > 0 Then
            OpenDataOn_SelectedTab(tabWaferRun.SelectedTab)
        End If
    End Sub

    Private Sub CreateTabPage(ByVal pair As KeyValuePair(Of Integer, String), ByVal strFolderName As String, ByVal PrefixFile As String)
        Try
            Dim tabpage As New System.Windows.Forms.TabPage
            Dim dataRunSeparator As String = AVPLib.ConstEnum.DataRunFileNameSeparator
            Dim objWaferRunData As WaferRunData = m_hstWaferRunData.Item(PrefixFile)
            If (pair.Value <> String.Empty) Then
                Dim PMName As String = (pair.Value.Split(New String() {dataRunSeparator}, StringSplitOptions.RemoveEmptyEntries)(1)).Split("_")(0)

                Dim PMNameWithRunNo As String = pair.Value.Split(New String() {dataRunSeparator}, StringSplitOptions.RemoveEmptyEntries)(1)
                If Not String.IsNullOrEmpty(objWaferRunData.RunNo) Then
                    PMNameWithRunNo = PMNameWithRunNo & AVPLib.ConstEnum.DataRunFileNameSeparator & objWaferRunData.RunNo
                End If
                tabpage.Text = PMName
                tabpage.Name = PMNameWithRunNo
                tabpage.Tag = FPath_RunDataOfWafer & "\" & strFolderName & "\" & objWaferRunData.ListOfPrefixFile.Item(pair.Key)
                tabWaferRun.Controls.Add(tabpage)
                If tabpage.Text.Contains(AVPLib.ConstEnum.Equipments.Aligner.ToString()) Then
                    If tabpage.Tag.Contains(AVPLib.ConstEnum.DataRunFileNameSeparator) Then
                        dataRunSeparator = AVPLib.ConstEnum.DataRunFileNameSeparator
                    End If
                    GetAlignerInfo(tabpage.Tag & dataRunSeparator & PMNameWithRunNo, tabpage)
                Else ''contain PMx
                    Dim objSampledata As New SampleData
                    tabpage.Controls.Add(objSampledata)
                    objSampledata.PrefixFile = tabpage.Tag
                    objSampledata.Dock = DockStyle.Fill
                    objSampledata.Font = New Font("Times New Roman", 12, FontStyle.Regular)
                End If
                Me.tabWaferRun.SelectedTab = tabpage ''select the newest
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Huy Nguyen </name>
    '''    	<date> 2015-08-26</date>
    ''' </author>
    ''' <summary>
    ''' get aligner info to show in datarun
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetAlignerInfo(ByVal fileName As String, ByVal tabPage As System.Windows.Forms.TabPage)
        Try
            Dim fileNameCSV As String = fileName & STR_CSV_EXT

            If System.IO.File.Exists(fileNameCSV) Then
                AddAlignerInfoInCSVFormat(fileNameCSV, tabPage)
            Else
                Dim fileNameXML As String = fileName & STR_XML_EXT
                AddAlignerInfo(fileNameXML, tabPage)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Huy Nguyen </name>
    '''    	<date> 2015-08-26</date>
    ''' </author>
    ''' <summary>
    ''' get aligner datarun info from csv file to show datarun
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddAlignerInfoInCSVFormat(ByVal strDataRunFullFileName As String, ByVal tabPage As System.Windows.Forms.TabPage)
        Try
            Dim dgData As New DataGridView()
            Dim dt As New DataTable
            Dim fs As FileStream = New FileStream(strDataRunFullFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)

            Using csvReader As StreamReader = New StreamReader(fs)
                Dim line As String = String.Empty
                Dim arrayValue(TOTAL_COLUMN_OF_ALIGNER_DATARUN) As String
                Dim dicStepColumnInfo As New Dictionary(Of Integer, String)

                Do
                    line = csvReader.ReadLine()
                    If line Is Nothing Then Exit Do
                    Dim arrColumn As String() = line.Trim().Split(",")

                    If arrColumn.Length > 1 Then
                        Dim strName As String = arrColumn(0)

                        If strName.Contains("RecipeName") Then
                            arrayValue(INDEX_OF_RECIPE_NAME_COLUMN) = arrColumn(1)
                        ElseIf strName.Contains("Step No") Then

                            For index As Integer = 0 To arrColumn.Length - 1
                                dicStepColumnInfo.Add(index, arrColumn(index))
                            Next
                        ElseIf arrColumn.Length > 2 Then
                            For index As Integer = 0 To arrColumn.Length - 1
                                Dim columnName As String = dicStepColumnInfo.Item(index)

                                If columnName.Contains("RSLTEccentricityAngleDeg") Then
                                    arrayValue(INDEX_OF_ECC_ANGLE_COLUMN) = arrColumn(index)
                                ElseIf columnName.Contains("RSLTMaxEccentricityMils") Then
                                    arrayValue(INDEX_OF_ECC_MAG_COLUMN) = arrColumn(index)
                                ElseIf columnName.Contains("Delta_R") Then
                                    arrayValue(INDEX_OF_DELTA_R_COLUMN) = arrColumn(index)
                                ElseIf columnName.Contains("Delta_T") Then
                                    arrayValue(INDEX_OF_DELTA_T_COLUMN) = arrColumn(index)
                                ElseIf columnName.Contains("RSLTAngularLocationDeg") Then
                                    arrayValue(INDEX_OF_FIDUCIAL_ANGLE_COLUMN) = arrColumn(index)
                                ElseIf columnName.Contains("RSLTReScanNeed") Then
                                    arrayValue(INDEX_OF_RESCAN_COLUMN) = arrColumn(index)
                                End If
                            Next
                        End If
                    End If
                Loop Until line Is Nothing

                dt.Columns.Add("Recipe")
                dt.Columns.Add("Ecc_Angle")
                dt.Columns.Add("Ecc_Mag")
                dt.Columns.Add("Delta_R")
                dt.Columns.Add("Delta_T")
                dt.Columns.Add("Fiducial_Angle")
                dt.Columns.Add("Rescan")
                ''append data to row
                Dim dr As DataRow = dt.NewRow()
                For i As Integer = 0 To dt.Columns.Count - 1
                    dr(i) = arrayValue(i)
                Next

                dt.Rows.Add(dr)
            End Using

            ''show in Grid
            dgData.DataSource = dt
            tabPage.Controls.Add(dgData)
            dgData.Dock = DockStyle.Fill
            ''choose style mode
            dgData.Font = New Font("Times New Roman", 12, FontStyle.Regular)
            dgData.AllowUserToAddRows = False
            dgData.AllowUserToDeleteRows = False
            dgData.AllowUserToResizeRows = False
            dgData.AllowUserToResizeColumns = False
            dgData.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgData.ColumnHeadersHeight = 30
            dgData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgData.EditMode = DataGridViewEditMode.EditProgrammatically
            dgData.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub AddAlignerInfo(ByVal strDataRunFullFileName As String, ByVal tabPage As System.Windows.Forms.TabPage)
        Try
            Dim dgData As New DataGridView()
            Dim dt As New DataTable
            Dim xmlDoc As XmlDocument = New XmlDocument
            AVPLib.Utils.LoadFileXML(xmlDoc, strDataRunFullFileName)
            Dim root As System.Xml.XmlNode = xmlDoc.SelectSingleNode("/RunData/ChamberList/Chamber/StepList/Step/SampleList/Sample")
            dt.Columns.Add("Recipe")
            ''checking file
            If root Is Nothing Then
                AVPLib.Log.avpLogger.Error("Can not load file Aligner DataRun: " & strDataRunFullFileName)
                Exit Try
            End If
            ''create columns
            'For j As Integer = 1 To root.ChildNodes.Count - 1
            '    dt.Columns.Add(root.ChildNodes.Item(j).Name)
            'Next
            dt.Columns.Add("Ecc_Angle")
            dt.Columns.Add("Ecc_Mag")
            dt.Columns.Add("Delta_R")
            dt.Columns.Add("Delta_T")
            dt.Columns.Add("Fiducial_Angle")
            dt.Columns.Add("Rescan")
            ''append data to row
            Dim dr As DataRow = dt.NewRow()
            For i As Integer = 0 To dt.Columns.Count - 1
                If i = 0 Then
                    Dim recipeNode As Xml.XmlNode = xmlDoc.SelectSingleNode("/RunData/ChamberList/Chamber/RecipeName")
                    If recipeNode IsNot Nothing Then
                        dr(i) = recipeNode.InnerText
                    End If
                Else
                    dr(i) = root.ChildNodes.Item(i).InnerText
                End If
            Next

            ''show in Grid
            dt.Rows.Add(dr)
            dgData.DataSource = dt
            tabPage.Controls.Add(dgData)
            dgData.Dock = DockStyle.Fill
            ''choose style mode
            dgData.Font = New Font("Times New Roman", 12, FontStyle.Regular)
            dgData.AllowUserToAddRows = False
            dgData.AllowUserToDeleteRows = False
            dgData.AllowUserToResizeRows = False
            dgData.AllowUserToResizeColumns = False
            dgData.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgData.ColumnHeadersHeight = 30
            dgData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dgData.EditMode = DataGridViewEditMode.EditProgrammatically
            dgData.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
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
    Protected Sub dgvWFList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWFList.CellClick, dgvWFList.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                RowSelectedChanged(e.RowIndex)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overridable Sub RowSelectedChanged(ByVal rowIndex As Integer)
        Try
            Dim strPrefixFile As String = String.Empty
            If Not (strPrefixFile = Me.dgvWFList.Item(FILE_NAME, rowIndex).Value) Then
                strPrefixFile = Me.dgvWFList.Item(FILE_NAME, rowIndex).Value
            End If

            If Not String.IsNullOrEmpty(strPrefixFile) Then
                Dim objWRData As WaferRunData = m_hstWaferRunData.Item(strPrefixFile)
                If objWRData IsNot Nothing Then
                    Dim strWaferID As String = String.Empty
#If AVP_PLATFORM = "CX" Then
                    strWaferID = IIf(objWRData.LLName = AVPLib.ConstEnum.LLA_STR, "A", "B")
                    Dim islotID As Integer = 0
                    Integer.TryParse(objWRData.SlotID, islotID)
                    strWaferID = strWaferID & Format(islotID, "00")
#End If
                    CreateTabPages(objWRData.ListOfPM, objWRData.PrefixFile, Format(dtFilter.Value, "yyyy_MM_dd"), strWaferID)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overridable Sub dtFilter_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFilter.ValueChanged
        Try
            If dtFilter.Value.ToString("yyyy.MM.dd") = Date.Today.ToString("yyyy.MM.dd") Then
                RefreshSelectedDate()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tu Nguyen </name>
    '''     <date> 2015-04-24 </date>
    ''' </author>
    ''' <summary>
    ''' Refresh data view with filter
    ''' </summary>
    Private Sub RefreshSelectedDate()
        Try
            'EnableControl(False)
            GetAllWaferRunDataFile()
            If dgvWFList.Rows.Count <= 0 Then
                tabWaferRun.TabPages.Clear()
            End If
            'EnableControl(True)
            SetLabelItemCount()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tu Nguyen </name>
    '''     <date> 2015-04-24 </date>
    ''' </author>
    ''' <summary>
    ''' Enable/Disable control while refresh data
    ''' </summary>
    Private Sub EnableControl(ByVal isEnabled As Boolean)
        Try
            btnApply.Enabled = isEnabled
            dtFilter.Enabled = isEnabled
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tu Nguyen </name>
    '''     <date> 2015-04-24 </date>
    ''' </author>
    ''' <summary>
    ''' Refresh data view use for public
    ''' </summary>
    Public Sub RefreshData()
        Try
            If dtFilter.Value.ToString("yyyy.MM.dd") = Date.Today.ToString("yyyy.MM.dd") Then
                RefreshSelectedDate()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tu Nguyen </name>
    '''     <date> 2015-04-24 </date>
    ''' </author>
    ''' <summary>
    ''' Number of list item
    ''' </summary>
    Private Sub SetLabelItemCount()
        Try
            lblItemsCount.Text = dgvWFList.Rows.Count.ToString()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        RefreshSelectedDate()
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_hstWaferRunData = New Hashtable()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class

Public Class DataValue
    Private m_dblTime As Double
    Private m_strValue As String = String.Empty
    Private m_strDisplayTime As String = String.Empty
    Public Property Time() As Double
        Get
            Return m_dblTime
        End Get
        Set(ByVal value As Double)
            m_dblTime = value
        End Set
    End Property
    Public Property Value() As String
        Get
            Return m_strValue
        End Get
        Set(ByVal value As String)
            m_strValue = value
        End Set
    End Property
    Public Property DisplayTime() As String
        Get
            Return m_strDisplayTime
        End Get
        Set(ByVal value As String)
            m_strDisplayTime = value
        End Set
    End Property
End Class

Public Class WaferRunData
    Private m_strPrefixFile As String = String.Empty
    Private m_strLLName As String = String.Empty
    Private m_strSlotID As String = String.Empty
    Private m_strLotID As String = String.Empty
    Private m_ListOfPM As New SortedDictionary(Of Integer, String)
    Private m_ListOfPrefixFile As New SortedDictionary(Of Integer, String)
    Private m_strTime As String = String.Empty
    Private m_strRunNo As String = String.Empty

    Public Property CreatedTime() As String
        Get
            Return m_strTime
        End Get
        Set(ByVal value As String)
            m_strTime = value
        End Set
    End Property
    Public Property PrefixFile() As String
        Get
            Return m_strPrefixFile
        End Get
        Set(ByVal value As String)
            m_strPrefixFile = value
        End Set
    End Property

    Public Property LLName() As String
        Get
            Return m_strLLName
        End Get
        Set(ByVal value As String)
            m_strLLName = value
        End Set
    End Property

    Public Property SlotID() As String
        Get
            Return m_strSlotID
        End Get
        Set(ByVal value As String)
            m_strSlotID = value
        End Set
    End Property

    Public Property LotID() As String
        Get
            Return m_strLotID
        End Get
        Set(ByVal value As String)
            m_strLotID = value
        End Set
    End Property

    Public Property ListOfPM() As SortedDictionary(Of Integer, String)
        Get
            Return m_ListOfPM
        End Get
        Set(ByVal value As SortedDictionary(Of Integer, String))
            m_ListOfPM = value
        End Set
    End Property

    Public Property ListOfPrefixFile() As SortedDictionary(Of Integer, String)
        Get
            Return m_ListOfPrefixFile
        End Get
        Set(ByVal value As SortedDictionary(Of Integer, String))
            m_ListOfPrefixFile = value
        End Set
    End Property

    Public Property RunNo() As String
        Get
            Return m_strRunNo
        End Get
        Set(ByVal value As String)
            m_strRunNo = value
        End Set
    End Property

End Class




