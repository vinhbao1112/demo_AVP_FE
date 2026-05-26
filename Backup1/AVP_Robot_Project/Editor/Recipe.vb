Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Imports AVPLib.ConstEnum
Imports AVPControls

Public Enum MouseClicked
    [NewFileClicked] = 0
    [OpenFileClicked] = 1
    [DeleteFileClicked] = 2
    [SaveFileClicked] = 3
    [SaveAsFileClicked] = 4
    [DataColumnClicked] = 5
    [DataRowClicked] = 6
    [InsertStepClicked] = 7
    [CopyStepClicked] = 8
    [DeleteStepClicked] = 9
    [AddStepClicked] = 10
    [PasteStepClicked] = 11
    [InsertCopyStepClicked] = 12
    [AddCopyStepClicked] = 13
    [FormClicked] = 14
    [None] = 15
End Enum
Public Class RecipeEditor
    Private Loading As Boolean = False
    Private CurrentIsNew As Boolean = False
    Private Loaded As Integer = 0
    Private m_strTitle As String = String.Empty
    '#02/25/2011
    '#'Change from 7 to 8 (Add more one column Unit show to show unit of value.)(Tin Pham add more one column ParameterCalculate)
    Private Const Total_Columns As Integer = 9

    Private m_hstDisplayParam As Hashtable
    Private m_hstOfParamValue As Hashtable
    Private m_lastOpenRecipe As String = String.Empty
    Private m_blnIsModified As Boolean = False
    Private m_MouseClicked As MouseClicked
    Private Const strCellTitle As String = "processstartpressure"
    Private Const strTableHeightWithTSDModeTitle As String = "Table Height (mm - TSD)"

    Protected m_curTotalStep As Int16 = 1 '//Current Total Step
    Public Event Reload_PPRecipeEvent As EventHandler
    Private Const KEY_CHAMBER_TYPE As String = "#KeyChamberType#"
    Public Const STR_START As String = "START"
    Public Const STR_END As String = "END"
    Public Const STR_SELF_LOOP As String = "SELF LOOP"
    Private oldToolTip(,) As String
    Private oldToolTipText(,) As String
    Private dictionaryColor As New Dictionary(Of Integer, String)

    Private m_iColumnSelected = 0
#Region "Properties"
    Private Property IsModified() As Boolean
        Get
            Return m_blnIsModified
        End Get
        Set(ByVal value As Boolean)
            m_blnIsModified = value
            If m_blnIsModified Then
                Me.LabTitle.Text = Me.LabTitle.Tag & "*"
            Else
                Me.LabTitle.Text = Me.LabTitle.Tag
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2020-03-19</date>
    ''' </author>
    ''' <summary>
    ''' Get LastOpenRecipe
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property LastOpenRecipe() As String
        Get
            Return m_lastOpenRecipe
        End Get
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Set Title
    ''' </summary>
    ''' <param name="Title"></param>
    ''' <remarks></remarks>
    Public Property Title() As String
        Get
            Return m_strTitle
        End Get
        Set(ByVal value As String)
            m_strTitle = value
            Me.LabTitle.Text = m_strTitle
            Me.LabTitle.Tag = m_strTitle
        End Set
    End Property
#End Region

#Region "Load Form"

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Chamber_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Chamber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            m_hstDisplayParam = New Hashtable
            ClearForm()
            RefreshData()
            LoadCmbRecipe()
            m_MouseClicked = MouseClicked.FormClicked
            SetButtonStatus(m_MouseClicked)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' loadCmbRecipe
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadCmbRecipe()
        Try
            Dim ListRecipe As ArrayList = AVPLib.ContainerData.ListRecipe
            Dim indexBtnVisible As Integer = 0
            Dim BtnFirstLeft As Integer = 10

            Dim isANYIBEMode As Boolean = AVPLib.ContainerDAO.Enable_ANYIBE_Mode
            Dim hasAddAnyIBE As Boolean = False

            Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(ConstEnum.Equipments.Chamber1.ToString)
            If ContainerForm.Chamber1Visible = True AndAlso _
            (hasAddAnyIBE = False AndAlso isANYIBEMode = True AndAlso _
            serverConfig.Type = ConstEnum.IBEType.AVP_IBE.ToString()) Then
                hasAddAnyIBE = True
                tabPM1Recipe.Text = RobotConfigurationValues.ANY_IBE_CHAMBER
            ElseIf (ContainerForm.Chamber1Visible = False) Then
                tabEditorRecipe.Controls.Remove(tabPM1Recipe)
            End If

            serverConfig = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(ConstEnum.Equipments.Chamber2.ToString)
            If ContainerForm.Chamber2Visible = True AndAlso _
            (hasAddAnyIBE = False AndAlso isANYIBEMode = True AndAlso _
            serverConfig.Type = ConstEnum.IBEType.AVP_IBE.ToString()) Then
                hasAddAnyIBE = True
                tabPM2Recipe.Text = RobotConfigurationValues.ANY_IBE_CHAMBER
            ElseIf ContainerForm.Chamber2Visible = False OrElse _
            (serverConfig.Type = ConstEnum.IBEType.AVP_IBE.ToString() AndAlso hasAddAnyIBE = True) Then
                tabEditorRecipe.Controls.Remove(tabPM2Recipe)
            End If

            serverConfig = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(ConstEnum.Equipments.Chamber3.ToString)
            If ContainerForm.Chamber3Visible = True AndAlso _
            (hasAddAnyIBE = False AndAlso isANYIBEMode = True AndAlso _
            serverConfig.Type = ConstEnum.IBEType.AVP_IBE.ToString()) Then
                hasAddAnyIBE = True
                tabPM3Recipe.Text = RobotConfigurationValues.ANY_IBE_CHAMBER
            ElseIf ContainerForm.Chamber3Visible = False OrElse _
            (serverConfig.Type = ConstEnum.IBEType.AVP_IBE.ToString() AndAlso hasAddAnyIBE = True) Then
                tabEditorRecipe.Controls.Remove(tabPM3Recipe)
            End If

            If Not AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
                tabEditorRecipe.Controls.Remove(tabAlignerRecipe)
                m_lastOpenRecipe = tabEditorRecipe.TabPages(0).Tag.ToString()
                tabEditorRecipe.TabPages(0).Controls.Add(dgvChamber)
            Else
                m_lastOpenRecipe = ConstEnum.Equipments.Aligner.ToString()
                Me.tabAlignerRecipe.Controls.Add(dgvChamber)

                Dim HRecipeConfig As New HRecipeLibrary.HRecipe(SystemModule.ModuleType.Aligner.ToString, New Hashtable())
                AVPLib.ContainerData.AddHRecipeToList(SystemModule.ModuleType.Aligner.ToString, HRecipeConfig)

            End If


            Me.tabEditorRecipe.Dock = DockStyle.Fill
            dgvChamber.Dock = DockStyle.Fill
            LoadDataGrid(False, Nothing, m_lastOpenRecipe)
            If (AVPLib.ContainerDAO.Enable_ANYIBE_Mode) Then
                '''Dat Cao ' 23/02/2012 add IBE Recipe Folder if not exited
                Dim ANYIBE_CHAMBER_PATH = AVPLib.ContainerDAO.FPath_ChamberRecipe & "\" & RobotConfigurationValues.ANY_IBE_CHAMBER
                If (Not System.IO.Directory.Exists(ANYIBE_CHAMBER_PATH)) Then
                    System.IO.Directory.CreateDirectory(ANYIBE_CHAMBER_PATH)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name>Le Hieu Truc </name>
    '''    	<date> 2010-05-04</date>
    ''' </author>
    ''' <summary>
    ''' Get List of Param to Show on GUI (all display value)
    ''' </summary>
    ''' <param name="isNew"></param>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Function ListOfParamComboBox(ByVal selectedRecipe As AVPLib.DBChamber) As Hashtable
        Dim HstParamBoolean As New Hashtable
        Try
            For Each item As AVPLib.DBParameterGroup In selectedRecipe.ListGroupParameters
                For Each param As AVPLib.DBParameter In item.Parameters
                    If param.DisplayItems IsNot Nothing AndAlso param.DisplayItems.Count > 0 Then
                        Dim listOfItem As New List(Of String)
                        For Each kvp As KeyValuePair(Of String, String) In param.DisplayItems
                            listOfItem.Add(kvp.Key)
                        Next
                        '2014-03-17 Tin Pham: key = PVD.PowerDown, PVD6S.PowerDown, ...
                        Dim keyParamName As String = selectedRecipe.ChamberType & "." & param.Name
                        If Not (m_hstDisplayParam.Contains(keyParamName)) Then
                            m_hstDisplayParam.Add(keyParamName, param.DisplayItems)
                        Else
                            If param.Name = "TargetSelection" AndAlso (item.GroupCode = "RFTargetPower" OrElse item.GroupCode = "DCTargetPower") Then
                                m_hstDisplayParam.Item(keyParamName) = param.DisplayItems
                            End If
                        End If
                        If Not (HstParamBoolean.Contains(param.Name)) Then
                            HstParamBoolean.Add(param.Name, listOfItem)
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return HstParamBoolean
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' LoadDataGrid
    ''' </summary>
    ''' <param name="isNew"></param>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Public Sub LoadDataGrid(ByVal isNew As Boolean, ByVal dt As DataTable, Optional ByVal strChamberName As String = "")
        Loading = True
        Try
            Loaded += 1
            ClearGrid()
            If String.IsNullOrEmpty(strChamberName) AndAlso String.IsNullOrEmpty(m_lastOpenRecipe) Then
                m_lastOpenRecipe = Equipments.Aligner.ToString() ''load as default
            ElseIf String.IsNullOrEmpty(m_lastOpenRecipe) Then
                m_lastOpenRecipe = strChamberName
            End If
            Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(m_lastOpenRecipe)
            Dim chamberModule As AVPLib.SystemModule = Nothing
            AVPLib.ContainerData.IsChamberVisible(ChamberName, chamberModule)

            Dim recipe As AVPLib.DBRecipe = AVPLib.ContainerData.GetRecipe(ChamberName)
            If recipe Is Nothing Then
                Return
            End If

            Dim activeRecipeName As String = recipe.ChamberNameActive
            Dim recipePrivilege As AVPLib.DBChamber = Nothing
            If (AVPLib.ContainerData.UserLogin IsNot Nothing) Then
                recipePrivilege = AVPLib.ContainerData.UserLogin.ListOfDBChamber(chamberModule.Type.ToString() & "." & ChamberName)
            End If
            Dim selectedRecipe As AVPLib.DBChamber = Nothing
            If dt Is Nothing Then
                If isNew = False Then
                    selectedRecipe = AVPLib.ContainerData.Chamber(ChamberName, activeRecipeName)

                    m_hstOfParamValue = ListOfParamComboBox(selectedRecipe)
                    isNew = (selectedRecipe.ListChamberSteps.Count = 0)
                    selectedRecipe = ConvertToRealValue(selectedRecipe, True)
                Else
                    selectedRecipe = AVPLib.ContainerData.ChamberEmpty(ChamberName)
                    m_hstOfParamValue = ListOfParamComboBox(selectedRecipe)
                End If
                selectedRecipe.ChamberType = chamberModule.Type.ToString()
                dt = AVPLib.ContainerData.ChamberDB(selectedRecipe, AVPLib.ContainerData.ChamberPVDType(ChamberName))

            End If

            If isNew Then
                Me.Title = "New Recipe"
            Else
                Me.Title = AVPLib.Utils.GetFileName(AVPLib.ContainerData.GetRecipe(ChamberName).ChamberNameActive, True)
            End If
            Me.btnDelete.Enabled = (AVPLib.ContainerData.Permission(PERMISSION_002) And Not AVPRobotMain.OnlineRemote)
            CurrentIsNew = isNew

            Me.txtDescription.Text = AVPLib.ContainerData.GetChamberDescription(ChamberName)

            For i As Integer = 0 To dt.Columns.Count - 1
                Dim dc As DataColumn = dt.Columns.Item(i)
                Dim Column As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
                Column.HeaderText = dc.Caption
                Column.Name = dc.ColumnName
                Column.DataPropertyName = dc.ColumnName
                Column.SortMode = DataGridViewColumnSortMode.NotSortable
                If i = 0 Then
                    Column.Width = 300
                    Column.ReadOnly = True
                    Me.m_curTotalStep = 0
                Else
                    Column.Width = 135
                    Me.m_curTotalStep += 1
                End If
                Me.dgvChamber.Columns.Add(Column)
                If AVPLib.Utils.IsHiddenColumn(dc.ColumnName) Then
                    Column.Visible = False
                    Me.m_curTotalStep -= 1
                End If
            Next
            Me.lblTotalStep.Text = lblTotalStep.Tag.ToString() & m_curTotalStep
            If Me.dgvChamber.Columns.Count > 0 Then ''Freezing first column
                Me.dgvChamber.Columns(0).Frozen = True
            End If

            Me.dgvChamber.DataSource = dt

            Const kDefaultValue As String = "DefaultValue"
            Const kParameterName As String = "ParameterName"
            Const kBelongToGroup As String = "BelongToGroup"

            Dim dictionaryRowDisable As New Dictionary(Of Integer, ArrayList)
            Dim dictionaryRowCalculate As New Dictionary(Of String, String)
            Dim seqNo As Integer = 0
            Dim nRow As Integer = 0
            Dim nRowVisible As Integer = 0
            Dim arrRowDisable As New ArrayList
            For Each drMerge As DataRow In dt.Rows
                If drMerge(kDefaultValue).ToString().Length = 0 AndAlso drMerge("BelongToGroup").ToString().Length = 0 Then ' This is a Group row.
                    Dim nColumnView As Integer = Me.dgvChamber.Columns.GetColumnCount(DataGridViewElementStates.Visible)
                    Dim nColumn As Integer = 1
                    For Each Column As DataGridViewTextBoxColumn In Me.dgvChamber.Columns
                        If Column.Visible = True Then
                            Me.dgvChamber.Rows(nRow).ReadOnly = True
                            Me.dgvChamber.Rows(nRow).Cells(Column.Name) = New HMergedCell()
                            Dim pCell As HMergedCell = DirectCast(Me.dgvChamber.Rows(nRow).Cells(Column.Name), HMergedCell)
                            pCell.LeftColumn = 0
                            pCell.RightColumn = nColumnView
                            nColumn += 1
                        End If
                    Next
                Else
                    Dim indexCellDisable As New ArrayList()
                    ' This is a Parameter row.
                    Dim ParameterName As String = drMerge(kParameterName).ToString()
                    ' 2013-07-15 Tin Pham: disable cells
                    Dim GroupCode As String = drMerge(kBelongToGroup).ToString()
                    Dim listOfSeqNoCalculate As New Hashtable
                    Dim listOfSeqNoDisable As Hashtable = AVPLib.Utils.GetListOfSeqNoDisable(ChamberName, GroupCode, ParameterName, seqNo, listOfSeqNoCalculate)
                    If listOfSeqNoDisable IsNot Nothing AndAlso listOfSeqNoDisable.Count > 0 Then
                        Dim nColumn As Integer = 0
                        For Each Column As DataGridViewTextBoxColumn In Me.dgvChamber.Columns
                            If Column.Visible = True AndAlso nColumn >= 1 Then
                                'Disable
                                Dim str As String = listOfSeqNoDisable.Item(Me.dgvChamber.Rows(nRow).Cells(nColumn).Value)
                                If str IsNot Nothing Then
                                    Dim arr As Array = str.Split(STR_COMMA)
                                    For i As Integer = 0 To arr.Length - 1
                                        Dim rowDisable As Integer = AVPLib.Utils.GetRowIndex(arr(i), m_lastOpenRecipe, nRow, seqNo, dt)
                                        If rowDisable < nRow Then
                                            indexCellDisable.Add(rowDisable)
                                        End If
                                        Dim arrList As New ArrayList
                                        If dictionaryRowDisable IsNot Nothing AndAlso dictionaryRowDisable.Count > 0 AndAlso dictionaryRowDisable.ContainsKey(rowDisable) Then
                                            arrList = dictionaryRowDisable.Item(rowDisable)
                                            If Not arrList.Contains(nColumn) Then
                                                arrList.Add(nColumn)
                                                dictionaryRowDisable.Item(rowDisable) = arrList
                                            End If
                                        Else
                                            arrList.Add(nColumn)
                                            dictionaryRowDisable.Add(rowDisable, arrList)
                                        End If

                                        If (rowDisable < nRow) AndAlso (Not arrRowDisable.Contains(rowDisable)) Then
                                            arrRowDisable.Add(rowDisable)
                                        End If
                                    Next
                                End If
                                'Calculate
                                If listOfSeqNoCalculate IsNot Nothing AndAlso listOfSeqNoCalculate.Count > 0 Then
                                    Dim strCal As String = listOfSeqNoCalculate.Item(Me.dgvChamber.Rows(nRow).Cells(nColumn).Value)
                                    If strCal IsNot Nothing Then
                                            Dim arrCal As Array = strCal.Split(STR_SEMICOLON)
                                            For i As Integer = 0 To arrCal.Length - 1
                                                Dim position As Integer = arrCal(i).ToString.IndexOf(STR_EQUAL)
                                                Dim rowTemp As Integer = Integer.Parse(arrCal(i).ToString.Substring(0, position))
                                                Dim rowCal As Integer = nRow - seqNo + rowTemp
                                                Dim formulaTemp As String = arrCal(i).ToString.Substring(position + 1)
                                                If formulaTemp IsNot Nothing Then
                                                    Dim arrFormula As Array = formulaTemp.Split(STR_COMMA)
                                                    Dim formula As String = arrFormula(0)
                                                    For j As Integer = 0 To arrFormula.Length - 1
                                                        If j > 0 Then
                                                            Dim rowFormula As Integer = nRow - seqNo + arrFormula(j)
                                                            UpdateValueHideColumn(rowFormula, nRow)
                                                            formula = formula & STR_COMMA & rowFormula
                                                        End If
                                                    Next
                                                    Dim keyCalIncludeRowColumn As String = rowCal.ToString & STR_COMMA & nColumn.ToString
                                                    Dim arrList As New ArrayList
                                                    If dictionaryRowCalculate IsNot Nothing AndAlso Not dictionaryRowCalculate.ContainsKey(keyCalIncludeRowColumn) Then
                                                        dictionaryRowCalculate.Add(keyCalIncludeRowColumn, formula)
                                                    End If
                                                End If
                                            Next
                                        End If
                                    End If
                                End If
                            nColumn += 1
                        Next
                    End If
                    indexCellDisable.Add(nRow)
                    SetDisableCell(indexCellDisable, dictionaryRowDisable, dictionaryRowCalculate)
                    'end-----------------------------------------------------------------------------

                    ' 2015-06-25: Hoai Ly update pressure format
                    If Me.dgvChamber.Rows(nRow).Cells(0).Value.ToString().ToLower().Replace("_", "").Replace(" ", "").Contains(strCellTitle) Then
                        For iCol As Int32 = Total_Columns To Me.dgvChamber.Rows(nRow).Cells.Count - 1
                            Me.dgvChamber.Rows(nRow).Cells(iCol).Value = Me.FormatNumber(Me.dgvChamber.Rows(nRow).Cells(iCol).Value)
                        Next
                    End If

                    If Me.dgvChamber.Rows(nRow).Cells(0).Value.ToString().Contains("Table Height (mm)") Then
                        If chamberModule.ChuckPositionTSDRef Then
                            Me.dgvChamber.Rows(nRow).Cells(0).Value = strTableHeightWithTSDModeTitle
                        End If
                    End If

                    If (recipePrivilege IsNot Nothing) Then
                        Dim recParameter As AVPLib.DBParameter = recipePrivilege.GetParameter(GroupCode, ParameterName)
                        If (recParameter IsNot Nothing) Then
                            ' Applying Recipe Privilege.
                            If (Not recParameter.ReadWrite) Then
                                Me.dgvChamber.Rows(nRow).ReadOnly = True
                            End If
                        End If
                    End If
                End If

                'apply recipe param show or not show
                Dim blnIsVisible As Boolean = Utils.CheckParamRecipe_Visible(dgvChamber.Rows(nRow).Cells(1).Value.ToString(), dgvChamber.Rows(nRow).Cells(5).Value.ToString(), ChamberName)
                Me.dgvChamber.Rows(nRow).Visible = blnIsVisible

                If blnIsVisible Then
                    If (nRowVisible Mod 2) = 0 Then
                        Me.dgvChamber.Rows(nRow).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Window)
                    Else
                        Me.dgvChamber.Rows(nRow).DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255)
                    End If
                    nRowVisible += 1
                End If

                'reupdate all data is visible for copy step
                If stepCopyed.Count > 0 AndAlso chamberModule IsNot Nothing AndAlso chamberModule.Type.ToString() = stepCopyed.Item(KEY_CHAMBER_TYPE) Then
                    Dim dataRecipe As DataRecipe
                    Dim key As String = String.Empty

                    key = CreateKeyFromDataRow(drMerge)
                    dataRecipe = stepCopyed.Item(key)
                    dataRecipe.DataVisible = blnIsVisible
                    stepCopyed.Item(key) = dataRecipe
                End If

                nRow += 1
            Next

            Me.dgvChamber.AllowUserToResizeRows = False
            arrRowDisable.Clear()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Loading = False
    End Sub

    ''' <author>
    '''    	<name> Buu Tran </name>
    '''    	<date> 2013-03-11</date>
    ''' </author>
    ''' <summary>
    ''' Check Target Default Is Install
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CheckTargetDefaultIsInstall(ByVal strTargetDefault As String, ByVal chamberModule As AVPLib.SystemModule) As Boolean
        Try
            If chamberModule IsNot Nothing Then
                Select Case strTargetDefault
                    Case "T1"
                        Return chamberModule.TargetVisible
                    Case "T2"
                        Return chamberModule.Target2Visible
                    Case "T3"
                        Return chamberModule.Target3Visible
                    Case "T4"
                        Return chamberModule.Target4Visible
                End Select
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return True
    End Function

    ''' <author>
    '''    	<name> Buu Tran </name>
    '''    	<date> 2013-03-11</date>
    ''' </author>
    ''' <summary>
    ''' Choose Target If Target Default Is Not Install
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ChooseTargetIfTargetDefaultIsNotInstall(ByVal chamberModule As AVPLib.SystemModule) As String
        If chamberModule.Target4Visible Then
            Return "T4"
        ElseIf chamberModule.Target3Visible Then
            Return "T3"
        ElseIf chamberModule.Target2Visible Then
            Return "T2"
        ElseIf chamberModule.TargetVisible Then
            Return "T1"
        End If
        Return "None"
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' ClearGird
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearGrid()
        Me.dgvChamber.Columns.Clear()
        Me.dgvChamber.DataSource = Nothing
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' dgvChamber_CellValueChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvChamber_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvChamber.CellValueChanged
        Try
            If (e.ColumnIndex <= (Total_Columns - 1)) Or Loading Or RowIndex <= 0 Then
                Return
            End If
            Dim selected As Integer = e.RowIndex
            Dim Value As String = Me.dgvChamber.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
            Dim valid As Boolean = CheckValid(selected, Value)
            If valid = False Then
                Dim dt As DataTable = CType(Me.dgvChamber.DataSource, DataTable)
                Dim dr As DataRow = dt.Rows(selected)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                         AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                         "[Main Screen] " + "Error when change value in recipe.")

                Dim Min As Double = CDbl(dr("ParameterMin"))
                Dim Max As Double = CDbl(dr("ParameterMax"))
                GetMinMaxFromDBChamber(dr("ParameterName"), dr("BelongToGroup"), Min, Max)

                If LCase(dr("DefaultValue").ToString()).Contains("true") Or LCase(dr("DefaultValue").ToString()).Contains("false") Then
                    Utils.ShowAVPMessageBox("Invalid input value, please input True or False", "Recipe", MessageBoxIcon.Warning, MessageBoxButtons.OK)

                    Me.dgvChamber.CurrentCell.Value = dr("DefaultValue").ToString()
                ElseIf Min = Max Then
                    Utils.ShowAVPMessageBox("Invalid input value, please input a valid number", "Recipe", MessageBoxIcon.Warning, MessageBoxButtons.OK)

                    Me.dgvChamber.CurrentCell.Value = dr("DefaultValue").ToString()
                Else
                    Me.dgvChamber.CurrentCell.Value = Min.ToString()
                    Dim MessageError As String = AVPLib.ContainerData.GetMessageText("ErrorMessageRecipe")
                    MessageError = Utils.ParseChar(MessageError)
                    MessageError = String.Format(MessageError, Min.ToString(), Value, Max.ToString())
                    Utils.ShowAVPMessageBox(MessageError, "Recipe", MessageBoxIcon.Error, MessageBoxButtons.OK)
                End If
            Else
                IsModified = True
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' dgvChamber_CellEnter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvChamber_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvChamber.CellEnter
        Try
            Dim selected As Integer = Me.dgvChamber.CurrentCell.RowIndex
            Dim dt As DataTable = CType(Me.dgvChamber.DataSource, DataTable)
            Dim dr As DataRow = dt.Rows(selected)
            Dim ParameterName As String = dr("Parameters").ToString()
            Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(m_lastOpenRecipe)
            Dim DisplayItems As List(Of KeyValuePair(Of String, String)) = AVPLib.Utils.GetListOfDisplayItem(ChamberName, ParameterName)
            If DisplayItems IsNot Nothing Then
                Me.dgvChamber.CurrentCell.ReadOnly = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Buttons Event"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' New Chamber
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        AVPLib.Log.guiLogger.Info("Enter btnNew_Click")
        Try

            If (m_blnIsModified AndAlso AVPLib.ContainerData.Permission(PERMISSION_002)) Then
                If Utils.ShowAVPMessageBox("Current Recipe was changed." & Chr(13) & "Do you want to save ?", "Save Recipe", MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK Then
                    btnSave_Click(sender, e)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                           AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                           "[Main Screen] " + "Change current recipe")
                Else
                    m_blnIsModified = False
                End If
            End If

            LoadDataGrid(True, Nothing)
            IsModified = False
            btnSave.Enabled = True
            btnSaveAs.Enabled = True
            btnDelete.Enabled = True
            CurrentIsNew = True
            'datcao check condition when button New is clicked
            m_MouseClicked = MouseClicked.NewFileClicked
            SetButtonStatus(m_MouseClicked)
            ResetGridStyle()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnNew_Click")
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Open Chamber
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        AVPLib.Log.guiLogger.Info("Enter btnOpen_Click")
        Try
            Dim Chamber As String = AVPLib.Utils.chamberName2ChamberID(m_lastOpenRecipe)
            Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(Chamber)
            Dim frm As New OpenChamber(False)
            frm.Chamber = Chamber
            frm.Title = "Open Recipe"
            frm.ShowDialog()
            If frm.DialogResult = DialogResult.OK Then
                'ask save change when have modify recipe/waferflow/seq permission
                If (m_blnIsModified AndAlso AVPLib.ContainerData.Permission(PERMISSION_002)) Then
                    If Utils.ShowAVPMessageBox("Current Recipe was changed." & Chr(13) & "Do you want to save ?", "Save Recipe", MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK Then
                        btnSave_Click(sender, e)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                               AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                               "[Main Screen] " + "Change current recipe")
                    Else
                        m_blnIsModified = False
                    End If
                End If

                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Recipe Editor] Open Recipe with " + AVPLib.Utils.chamberID2ChamberName(Chamber) + " FileName=" + frm.FileName)
                AVPLib.ContainerData.UpdateChamber(Chamber, frm.FileName) '
                Me.LoadDataGrid(False, Nothing)

                'Dat Cao add Here
                'when open a recipe file, check recipe is in use? yes -> do not delete or modifler this file
                btnSave.Enabled = True And Not AVPRobotMain.OnlineRemote
                btnSaveAs.Enabled = True And Not AVPRobotMain.OnlineRemote
                btnDelete.Enabled = True And Not AVPRobotMain.OnlineRemote

                m_MouseClicked = MouseClicked.OpenFileClicked
                SetButtonStatus(m_MouseClicked)
                ResetGridStyle()

            End If

            frm.Dispose()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnOpen_Click")
    End Sub

    'Check Recipe in all waferflow
    Private Function CheckRecipeInWaferflow(ByVal Recipe As String, ByRef WaferFlow As String) As Boolean
        Try
            Dim waferflowList As String() = System.IO.Directory.GetFiles(AVPLib.ContainerDAO.FPath_WaferFlow)
            For i As Integer = 0 To waferflowList.Length - 1
                Dim waferFileName As String = AVPLib.Utils.GetFileName(waferflowList(i), True)
                Dim currentWaferFlow As AVPLib.DataManagerment.WaferFlow = AVPLib.ContainerData.GetWaferFlowbyName(waferFileName)
                Dim arrStep As ArrayList = currentWaferFlow.StepList
                For j As Integer = 0 To arrStep.Count - 1
                    Dim stepElement As AVPLib.DataManagerment.WaferflowStep = arrStep.Item(j)
                    If stepElement.RecipeName = Recipe Then
                        WaferFlow = currentWaferFlow.WaferFlowName
                        Return True
                    End If
                Next
            Next
        Catch ex As Exception

        End Try


        Return False
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    '''     <name> Dat Cao modify </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Delete Chamber
    ''' when delete chamber, check chamber is in use
    ''' in this function have two option as below:
    ''' frm.FileNames.Count > 1: delete multi file
    ''' frm.FileNames.Count = 1: delete only a file 
    ''' i'm only handle function with suport checking only a file 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        AVPLib.Log.guiLogger.Info("Enter btnDelete_Click")
        Try
            Dim Chamber As String = AVPLib.Utils.chamberName2ChamberID(m_lastOpenRecipe)
            Dim frm As New OpenChamber(True)
            frm.Title = "Delete Recipe"
            frm.Chamber = Chamber
            frm.ShowDialog()
            If frm.DialogResult = DialogResult.OK And frm.FileNames.Count > 1 Then
                Dim strFiles As String = String.Empty
                Dim dlg As DialogResult
                For Each sFiles As String In frm.FileNames
                    'strFiles += AVPLib.Utils.GetFileName(sFiles, True) + "; "
                    dlg = Utils.ShowAVPDeleteMultiMessageBox("Do you want to delete recipe  '" + sFiles + "'", "Recipe - " + AVPLib.Utils.chamberID2ChamberName(Chamber), MessageBoxIcon.Exclamation)
                    If dlg = DialogResult.Yes Then ''YesToAll
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Recipe Editor] Delete Multi Recipe: " & frm.FileNames.Count)
                        DeleteAllRecipe(frm.FileNames, Chamber)
                        Exit For
                    ElseIf dlg = DialogResult.OK Then 'Yes

                        '"Customer request.  Recipe/wafer flow/sequence.   
                        'Recipe is at the lowest level and sequence is at the highest level.  
                        'Recipe deletion, we need to check to see if any wafer flow is using this recipe.  
                        ' Wafer flow deletion, we need to check to see if any "
                        'Begin
                        Dim WaferFlow As String = String.Empty
                        Dim tmp As Array = sFiles.Split(".")
                        Dim Recipe As String = tmp(0).ToString
                        If CheckRecipeInWaferflow(Recipe, WaferFlow) Then
                            Dim dlgcheck As DialogResult = Utils.ShowAVPMessageBox("Recipe '" + frm.FileNames.Item(0) + "' is present in waferflow " + WaferFlow + vbCrLf + " Do you want to delete it ?", "Recipe - " + AVPLib.Utils.chamberID2ChamberName(Chamber), MessageBoxIcon.Exclamation)
                            If dlgcheck = DialogResult.Cancel Then
                                Exit Try
                            End If
                        End If
                        'End
                        Dim FileName As String = AVPLib.ContainerData.DeleteChamber(Chamber, sFiles)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Recipe Editor] Delete Recipe: " & FileName)
                        If AVPLib.ContainerData.GetRecipe(Chamber).ChamberNameActive = sFiles Then
                            AVPLib.ContainerData.UpdateChamber(Chamber, FileName)
                            Me.LoadDataGrid(FileName.Length = 0, Nothing)
                            ResetGridStyle()
                        End If
                        ''if dlg=No -> do nothing
                    ElseIf dlg = DialogResult.Cancel Then 'Cancel
                        Exit For
                    End If
                Next
            ElseIf frm.DialogResult = DialogResult.OK Then
                Dim dlg As DialogResult = Utils.ShowAVPMessageBox("Do you want to delete recipe  '" + frm.FileNames.Item(0) + "'", "Recipe - " + AVPLib.Utils.chamberID2ChamberName(Chamber), MessageBoxIcon.Exclamation)
                If dlg = DialogResult.OK Then

                    '"Customer request.  Recipe/wafer flow/sequence.   
                    'Recipe is at the lowest level and sequence is at the highest level.  
                    'Recipe deletion, we need to check to see if any wafer flow is using this recipe.  
                    ' Wafer flow deletion, we need to check to see if any "
                    'Begin fix
                    Dim WaferFlow As String = String.Empty
                    Dim tmp As Array = frm.FileNames.Item(0).Split(".")
                    Dim Recipe As String = tmp(0).ToString
                    If CheckRecipeInWaferflow(Recipe, WaferFlow) Then
                        Dim dlgcheck As DialogResult = Utils.ShowAVPMessageBox("Recipe '" + frm.FileNames.Item(0) + "' is present in waferflow " + WaferFlow + vbCrLf + " Do you want to continue ?", "Recipe - " + AVPLib.Utils.chamberID2ChamberName(Chamber), MessageBoxIcon.Exclamation)
                        If dlgcheck = DialogResult.Cancel Then
                            Exit Try
                        End If
                    End If
                    'End fix
                    Dim FileName As String = AVPLib.ContainerData.DeleteChamber(Chamber, frm.FileNames.Item(0).ToString())
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Recipe Editor] Delete Recipe: " & FileName)
                    If AVPLib.ContainerData.GetRecipe(Chamber).ChamberNameActive = frm.FileNames.Item(0).ToString() Then
                        AVPLib.ContainerData.UpdateChamber(Chamber, FileName)
                        Me.LoadDataGrid(FileName.Length = 0, Nothing)
                        ResetGridStyle()
                    End If
                End If
            End If

            'when load successful then
            'datcao check condition when button New is deleted
            m_MouseClicked = MouseClicked.DeleteFileClicked
            SetButtonStatus(m_MouseClicked)

            If ContainerForm.Secs_GemPanel.rbnRecipe.Checked Then
                RaiseEvent Reload_PPRecipeEvent(Nothing, Nothing)
            End If

            frm.Dispose()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnDelete_Click")
    End Sub
    Private Sub DeleteAllRecipe(ByVal ListOfFile As List(Of String), ByVal chamber As String)
        Try
            For Each sfiles As String In ListOfFile
                Dim FileName As String = AVPLib.ContainerData.DeleteChamber(chamber, sfiles)
                If AVPLib.ContainerData.GetRecipe(chamber).ChamberNameActive = sfiles Then
                    AVPLib.ContainerData.UpdateChamber(chamber, FileName)
                    Me.LoadDataGrid(FileName.Length = 0, Nothing)
                    ResetGridStyle()
                End If
            Next

            'when load successful then
            'datcao check condition when button New is deleted
            m_MouseClicked = MouseClicked.DeleteFileClicked
            SetButtonStatus(m_MouseClicked)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    '''    	<name> Dat Cao modifier </name>
    '''    	<date> 20011-03-16</date>
    ''' </author>
    ''' <summary>
    ''' btnSave_Click
    ''' do not save recipe is current in use
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        AVPLib.Log.guiLogger.Info("Enter btnSave_Click")
        Try
            Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(m_lastOpenRecipe)
            Dim ChamberNameActive As String = AVPLib.ContainerData.GetRecipe(ChamberName).ChamberNameActive

            If CurrentIsNew = False Then 'Update
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Recipe Editor] Save existed at " + AVPLib.Utils.chamberID2ChamberName(ChamberName) + " with FileName=" + ChamberNameActive)
                Dim dt As DataTable = CType(Me.dgvChamber.DataSource, DataTable)
                Dim Chamber As AVPLib.DBChamber = AVPLib.Utils.Chamber(dt, ChamberName)
                Chamber.ChamberDescription = Me.txtDescription.Text
                Chamber = ConvertToRealValue(Chamber, False)
                '#08/17/2011 
                '#-Recipe/waferflow/sequence was modified during lot run but was not log in lot data log.
                '#Begin fix.
                If IsModified Then
                    Utils.AddLotDatalog("Recipe " & ChamberNameActive & " is modified")
                End If
                '#End fix

                If Not ValidateLoopRecipe(dt, AVPLib.Utils.GetFileName(AVPLib.ContainerData.GetRecipe(Chamber.ChamberName).ChamberNameActive, True), _
                                          "Save", "loop recipe") Then
                    Exit Try
                End If

                IsModified = False
                AVPLib.ContainerData.UpdateChamber(Chamber)
                Utils.ShowAVPMessageBox("Recipe Saved Successfully", "Recipe", MessageBoxIcon.Information, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                              AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                              "[Main Screen] " + "Update recipe.")
            Else 'Insert
                Dim frm As New KeyPad()
                frm.IsCheckInvalidCharacter = True
                Dim Value As String = ""
                If frm.DisplayKeypad(Value, "Save", False) = DialogResult.OK Then
                    If Value.Length = 0 Then
                        Utils.ShowAVPMessageBox("Enter Recipe Name", "Save", MessageBoxIcon.Error, MessageBoxButtons.OK)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                              AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                              "[Main Screen] " + "Save recipe error because of missing recipe name.")
                        AVPLib.Log.guiLogger.Info("Leave btnSave_Click")
                        Return
                    End If

                    Value = Value.Trim()
                    Dim dt As DataTable = CType(Me.dgvChamber.DataSource, DataTable)
                    Dim Chamber As AVPLib.DBChamber = AVPLib.Utils.Chamber(dt, ChamberName)
                    Chamber.ChamberDescription = Me.txtDescription.Text
                    Chamber = ConvertToRealValue(Chamber, False)

                    If Not ValidateLoopRecipe(dt, Value, "Save", "loop recipe") Then
                        Exit Try
                    End If

                    Dim FileName As String = AVPLib.Utils.GetFileName(Value, "xml")

                    Dim ListChamber As ArrayList = AVPLib.ContainerData.GetRecipe(Chamber.ChamberName).ListChamber

                    If ListChamber.Contains(Value) = True Then
                        Dim dlg As DialogResult = Utils.ShowAVPMessageBox("FileName Existed, Do you want to Overwrite", "Chamber", MessageBoxIcon.Warning)
                        If dlg = DialogResult.OK Then

                            AVPLib.ContainerData.SaveChamber(Chamber, Value)
                            AVPLib.ContainerData.UpdateChamber(Chamber.ChamberName, AVPLib.Utils.GetFileName(Value, "xml"))
                            '#08/17/2011 
                            '#-Recipe/waferflow/sequence was modified during lot run but was not log in lot data log.
                            '#Begin fix.
                            If IsModified Then
                                Utils.AddLotDatalog("Recipe " & ChamberNameActive & " is modified")
                            End If
                            '#End fix
                            Utils.ShowAVPMessageBox("Recipe Saved Successfully", "Recipe", MessageBoxIcon.Information, MessageBoxButtons.OK)
                            Me.LoadDataGrid(False, Nothing)
                        End If
                    Else
                        AVPLib.ContainerData.SaveChamber(Chamber, Value)
                        AVPLib.ContainerData.UpdateChamber(Chamber.ChamberName, AVPLib.Utils.GetFileName(Value, "xml"))
                        Utils.ShowAVPMessageBox("Recipe Saved Successfully", "Recipe", MessageBoxIcon.Information, MessageBoxButtons.OK)
                        Me.LoadDataGrid(False, Nothing)

                        If ContainerForm.Secs_GemPanel.rbnRecipe.Checked Then
                            RaiseEvent Reload_PPRecipeEvent(Nothing, Nothing)
                        End If
                    End If
                    IsModified = False
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Recipe Editor] Recipe " + Value + " was saved")

                End If
            End If

            'when load successful then
            'datcao check condition when button New is deleted
            m_MouseClicked = MouseClicked.SaveFileClicked
            SetButtonStatus(m_MouseClicked)
            IsModified = False
            ResetGridStyle()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnSave_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-05-04</date>
    ''' </author>
    ''' <summary>
    ''' Convert Value from GUI to Real value (eg: On/Off to True/False) before saving to file/ showing to GUI
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Function ConvertToRealValue(ByVal selectedRecipe As AVPLib.DBChamber, ByVal blnLoadFromFile As Boolean) As AVPLib.DBChamber
        Try
            For Each item As AVPLib.DBChamberStep In selectedRecipe.ListChamberSteps
                For Each param As AVPLib.DBGroupParameterValue In item.ListGroupParameterValues
                    For Each paramval As AVPLib.DBParameterValue In param.ListParameterValues
                        '2014-03-17 Tin Pham: key = PVD.PowerDown, PVD6S.PowerDown, ...
                        Dim keyParamvalName As String = selectedRecipe.ChamberType & "." & paramval.Name
                        If m_hstDisplayParam.Contains(keyParamvalName) And Not blnLoadFromFile Then
                            Dim realVal As KeyValuePair(Of String, String) = Nothing
                            For Each realVal In m_hstDisplayParam(keyParamvalName)
                                If realVal.Key = paramval.Value Then
                                    paramval.Value = realVal.Value
                                End If
                            Next
                        ElseIf m_hstDisplayParam.Contains(keyParamvalName) Then
                            Dim realVal As KeyValuePair(Of String, String) = Nothing
                            For Each realVal In m_hstDisplayParam(keyParamvalName)
                                If realVal.Value = paramval.Value Then
                                    paramval.Value = realVal.Key
                                End If
                            Next
                        End If
                    Next
                Next
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return selectedRecipe
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' btnSaveAs_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAs.Click
        AVPLib.Log.guiLogger.Info("Enter btnSaveAs_Click")
        Try
            Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(m_lastOpenRecipe)
            Dim ChamberNameActive As String = AVPLib.ContainerData.GetRecipe(ChamberName).ChamberNameActive

            Dim frm As New KeyPad()
            frm.IsCheckInvalidCharacter = True
            Dim Value As String = AVPLib.Utils.GetFileName(Me.LabTitle.Tag, False)
            If frm.DisplayKeypad(Value, "Save", False) = DialogResult.OK Then
                If Value.Length = 0 Then
                    Utils.ShowAVPMessageBox("Enter Recipe Name", "Save As", MessageBoxIcon.Error, MessageBoxButtons.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                             AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                             "[Main Screen] " + "Save as recipe error with missing recipe name.")
                    AVPLib.Log.guiLogger.Info("Leave btnSaveAs_Click")
                    Return
                End If
                Value = Value.Trim()
                Dim dt As DataTable = CType(Me.dgvChamber.DataSource, DataTable)
                Dim Chamber As AVPLib.DBChamber = AVPLib.Utils.Chamber(dt, ChamberName)
                Chamber.ChamberDescription = Me.txtDescription.Text
                Chamber = ConvertToRealValue(Chamber, False)

                If Not ValidateLoopRecipe(dt, Value, "Save", "loop recipe") Then
                    Exit Try
                End If

                Dim FileName As String = AVPLib.Utils.GetFileName(Value, "xml")

                Dim ListChamber As ArrayList = AVPLib.ContainerData.GetRecipe(Chamber.ChamberName).ListChamber
                If ListChamber.Contains(Value) = True Then
                    Dim dlg As DialogResult = Utils.ShowAVPMessageBox("FileName Existed, Do you want to Overwrite", "Chamber", MessageBoxIcon.Warning)
                    If dlg = DialogResult.OK Then

                        AVPLib.ContainerData.SaveChamber(Chamber, Value)
                        AVPLib.ContainerData.UpdateChamber(Chamber.ChamberName, AVPLib.Utils.GetFileName(Value, "xml"))
                        '#08/17/2011 
                        '#-Recipe/waferflow/sequence was modified during lot run but was not log in lot data log.
                        '#Begin fix.
                        Utils.AddLotDatalog("Recipe " & ChamberNameActive & " is modified")
                        '#End fix
                        Utils.ShowAVPMessageBox("Recipe Saved Successfully", "Recipe", MessageBoxIcon.Information, MessageBoxButtons.OK)
                        Me.LoadDataGrid(False, Nothing)
                        IsModified = False
                    End If
                Else
                    AVPLib.ContainerData.SaveChamber(Chamber, Value)
                    AVPLib.ContainerData.UpdateChamber(Chamber.ChamberName, AVPLib.Utils.GetFileName(Value, "xml"))
                    Utils.ShowAVPMessageBox("Recipe Saved Successfully", "Recipe", MessageBoxIcon.Information, MessageBoxButtons.OK)
                    Me.LoadDataGrid(False, Nothing)
                    IsModified = False

                    If ContainerForm.Secs_GemPanel.rbnRecipe.Checked Then
                        RaiseEvent Reload_PPRecipeEvent(Nothing, Nothing)
                    End If
                End If
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Recipe Editor] Recipe " + Value + " was saved")

            End If

            'when load successful then
            'datcao check condition when button SaveAs is Clicked
            m_MouseClicked = MouseClicked.SaveAsFileClicked
            SetButtonStatus(m_MouseClicked)
            ResetGridStyle()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnSaveAs_Click")
    End Sub
#End Region

#Region "Function Support"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Check Validate
    ''' </summary>
    ''' <param name="RowNum"></param>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckValid(ByVal RowNum As Integer, ByVal Value As String) As Boolean
        AVPLib.Log.guiLogger.Info("Enter CheckValid")
        Try
            Dim dt As DataTable = CType(Me.dgvChamber.DataSource, DataTable)
            Dim dr As DataRow = dt.Rows(RowNum)
            If dr.Item("Unit").ToString().Contains("Boolean") Then
                Return True
                'ElseIf dr.Item("Parameters").ToString().Contains("String") Then
                '    Return True
            ElseIf dr.Item("Unit").ToString().Contains("String") Then
                Return True
            ElseIf (dr("ParameterMax").ToString().Length = 0) AndAlso (dr("ParameterMin").ToString().Length = 0) Then
                'no condition
                Return True
            Else
                Dim ParameterMax As Double = Utils.GetNumber(dr("ParameterMax").ToString())
                Dim ParameterMin As Double = Utils.GetNumber(dr("ParameterMin").ToString())

                GetMinMaxFromDBChamber(dr("ParameterName"), dr("BelongToGroup"), ParameterMin, ParameterMax)

                If (ParameterMax < ParameterMin) Then
                    AVPLib.Log.coreLogger.Error("Min is greater than Max in " + _
                    dr.ItemArray(1).ToString() + _
                    " in " + _
                   m_lastOpenRecipe + ".xml file")
                End If
                If ParameterMax = ParameterMin And IsNumeric(Value) Then
                    AVPLib.Log.guiLogger.Info("Leave CheckValid")
                    Return True
                Else
                    Dim nValue As Double = Double.Parse(Value)
                    AVPLib.Log.guiLogger.Info("Leave CheckValid")
                    Return (nValue <= ParameterMax And nValue >= ParameterMin)
                End If
            End If
        Catch ex As Exception
        End Try
        AVPLib.Log.guiLogger.Info("Leave CheckValid")
        Return False
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Delete Step
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteStep()
        AVPLib.Log.guiLogger.Info("Enter DeleteStep")
        Try

            '#02/25/2011
            '# Don't allow to delete step when recipe have one step.
            Dim dt As DataTable = CType(Me.dgvChamber.DataSource, DataTable)
            If dt.Columns.Count <= Total_Columns + 1 Then
                Exit Try
            End If

            Dim ColumnNameDeleted As String = dt.Columns(ColumnIndex).ColumnName
            dt.Columns.Remove(dt.Columns(ColumnIndex))
            'Begin Add Columns
            Dim ColumDeleted As Integer = AVPLib.Utils.GetNumberFromStep(ColumnNameDeleted)
            For Each dc As DataColumn In dt.Columns
                Dim Column As Integer = AVPLib.Utils.GetNumberFromStep(dc.ColumnName)
                If Column > ColumDeleted Then
                    dc.ColumnName = "Step" + (Column - 1).ToString()
                    dc.Caption = "Step-" + (Column - 1).ToString()
                End If
            Next
            'End Add Columns
            Me.LoadDataGrid(CurrentIsNew, dt)
            DeleteToolTip(ColumnIndex)
            IsModified = True
            ' After deleted successfully, should update Column index to count - 1 (last)
            If dt.Columns.Count = ColumnIndex Then
                ColumnIndex = dt.Columns.Count - 1
            End If
            m_iColumnSelected = ColumnIndex
            If dt.Columns(dt.Columns.Count - 1).ColumnName.StartsWith("Step") Then
                ColumnIndex = dt.Columns.Count - 1
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave DeleteStep")
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' 1. Add Columns
    '''   1.1: Add Columns at last column
    ''' 2. Add Rows
    '''   case don't copy get default value, case copy get value copyed
    ''' </summary>
    ''' <param name="isCopy"></param>
    ''' <remarks></remarks>
    Private Sub AddStep(ByVal isCopy As Boolean)
        AVPLib.Log.guiLogger.Info("Enter AddStep")
        Try
            Dim chamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(m_lastOpenRecipe)
            If isCopy AndAlso stepCopyed.Count > 0 AndAlso _
               chamberConfig IsNot Nothing AndAlso _
               chamberConfig.Type.ToString() <> stepCopyed.Item(KEY_CHAMBER_TYPE) Then
                Return
            End If

            Dim StepNo As Integer = Me.dgvChamber.Columns.GetColumnCount(DataGridViewElementStates.Visible)
            Dim dt As DataTable = CType(Me.dgvChamber.DataSource, DataTable)
            AVPLib.Utils.AddDataColumns(dt, "Step" + StepNo.ToString(), GetType(String), "Step-" + StepNo.ToString())

            Dim key As String = String.Empty
            Dim dataRecipe As DataRecipe = New DataRecipe

            For Each dr As DataRow In dt.Rows
                If isCopy AndAlso stepCopyed.Count > 0 Then
                    key = CreateKeyFromDataRow(dr)
                    dataRecipe = stepCopyed.Item(key)

                    If dataRecipe.DataVisible Then
                        dr("Step" + StepNo.ToString()) = dataRecipe.Data
                    Else
                        dr("Step" + StepNo.ToString()) = dr("DefaultValue")
                    End If
                Else
                    dr("Step" + StepNo.ToString()) = dr("DefaultValue")
                End If
            Next

            Me.LoadDataGrid(CurrentIsNew, dt)
            GetOldToolTip(oldToolTip.GetLength(1), False)

            IsModified = True
            ' After Added successfully, should update Column index to count - 1 (last)
            If dt.Columns(dt.Columns.Count - 1).ColumnName.StartsWith("Step") Then
                ColumnIndex = dt.Columns.Count - 1
            End If
            m_iColumnSelected = ColumnIndex
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave AddStep")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-23</date>
    ''' </author>
    ''' <summary>
    ''' PasteStep
    '''   case don't copy get default value, case copy get value copyed
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PasteStep()
        Try
            Dim dt As DataTable = CType(Me.dgvChamber.DataSource, DataTable)
            Dim dataRecipe As DataRecipe = New DataRecipe
            Dim key As String = String.Empty

            If Not String.IsNullOrEmpty(m_lastOpenRecipe) Then
                Dim chamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(m_lastOpenRecipe)
                If chamberConfig IsNot Nothing AndAlso stepCopyed.Count > 0 AndAlso chamberConfig.Type.ToString() = stepCopyed.Item(KEY_CHAMBER_TYPE) Then
                    For Each dr As DataRow In dt.Rows
                        key = CreateKeyFromDataRow(dr)

                        dataRecipe = stepCopyed.Item(key)
                        If dataRecipe.DataVisible Then
                            dr(ColumnIndex) = dataRecipe.Data
                        End If
                    Next

                    m_iColumnSelected = ColumnIndex
                    Me.LoadDataGrid(CurrentIsNew, dt)
                    GetOldToolTip(ColumnIndex, True)
                    IsModified = True
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' InsertStep
    ''' 1. Add Columns
    '''   1.1: Add Columns Lower ColumnIndex (Add with same existed columns)
    '''   1.2: Add Columns Equal ColumnIndex (Add new column)
    '''   1.3: Add Columns Higher ColumnIndex (Add with columns that existed columns add one)
    ''' 2. Add Rows
    '''   2.1: Add Row that Columns Lower ColumnIndex (Add Rows same existed Rows)
    '''   2.2: Add Columns Equal ColumnIndex (case don't copy get default value, case copy get value copyed)
    '''   2.3: Add Row that Columns Higher ColumnIndex (Add Rows same existed Rows)
    ''' </summary>
    ''' <param name="isCopy"></param>
    ''' <remarks></remarks>
    Private Sub InsertStep(ByVal isCopy As Boolean)
        AVPLib.Log.guiLogger.Info("Enter InsertStep")
        Try
            Dim chamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(m_lastOpenRecipe)
            If isCopy AndAlso stepCopyed.Count > 0 AndAlso _
               chamberConfig IsNot Nothing AndAlso _
               chamberConfig.Type.ToString() <> stepCopyed.Item(KEY_CHAMBER_TYPE) Then
                Return
            End If

            Dim dt As DataTable = CType(Me.dgvChamber.DataSource, DataTable)
            Dim dtInsert As New DataTable()
            '#03/15/2011 
            '#Recipe editor.  Insert copied step without copy step.  See below.
            '#Begin fix
            If ColumnIndex = 0 Then
                ColumnIndex = dt.Columns.Count - 1 ' set column index is last column. 
            End If
            '#End fix

            'Begin Add Columns
            Dim index As Integer = 0
            For Each dc As DataColumn In dt.Columns
                Dim StepNo As Integer = index - (Total_Columns - 1)
                If index < ColumnIndex Then
                    AVPLib.Utils.AddDataColumns(dtInsert, dc.ColumnName, GetType(String), dc.Caption)
                ElseIf index >= ColumnIndex Then
                    If index = ColumnIndex Then
                        AVPLib.Utils.AddDataColumns(dtInsert, "Step" + StepNo.ToString(), GetType(String), "Step-" + StepNo.ToString())
                    End If
                    AVPLib.Utils.AddDataColumns(dtInsert, "Step" + (StepNo + 1).ToString(), GetType(String), "Step-" + (StepNo + 1).ToString())
                End If
                index += 1
            Next
            'End Add Columns
            'Begin Add Rows
            Dim key As String = String.Empty
            Dim dataRecipe As DataRecipe = New DataRecipe
            For Each dr As DataRow In dt.Rows
                Dim drInsert As DataRow = dtInsert.NewRow()

                For i As Integer = 0 To dr.ItemArray.Length - 1
                    If i < ColumnIndex Then
                        drInsert(i) = dr(i)
                    ElseIf i >= ColumnIndex Then
                        If i = ColumnIndex Then
                            If isCopy AndAlso stepCopyed.Count > 0 Then
                                key = CreateKeyFromDataRow(dr)
                                dataRecipe = stepCopyed.Item(key)

                                If dataRecipe.DataVisible Then
                                    drInsert(i) = dataRecipe.Data
                                Else
                                    drInsert(i) = dr("DefaultValue")
                                End If
                            Else
                                drInsert(i) = dr("DefaultValue")
                            End If
                        End If
                        drInsert(i + 1) = dr(i)
                    End If
                Next
                dtInsert.Rows.Add(drInsert)
            Next
            'End Add Rows

            Me.LoadDataGrid(CurrentIsNew, dtInsert)
            GetOldToolTip(ColumnIndex, False)
            IsModified = True
            ' After Inserted successfully, should update Column index to count - 1 (last)
            m_iColumnSelected = ColumnIndex
            If dt.Columns(dt.Columns.Count - 1).ColumnName.StartsWith("Step") Then
                ColumnIndex = dt.Columns.Count - 1
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave InsertStep")
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' stepCopyed
    ''' </summary>
    ''' <remarks></remarks>
    Dim stepCopyed As New Hashtable()

    ''' <summary>
    ''' Copy Step
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CopyStep()
        Try
            stepCopyed.Clear()
            Dim dt As DataTable = CType(Me.dgvChamber.DataSource, DataTable)
            Dim dataRecipe As DataRecipe
            Dim key As String = String.Empty

            If Not String.IsNullOrEmpty(m_lastOpenRecipe) Then
                Dim chamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(m_lastOpenRecipe)
                If chamberConfig IsNot Nothing Then
                    stepCopyed.Add(KEY_CHAMBER_TYPE, chamberConfig.Type.ToString())
                End If
            End If

            For Each dr As DataRow In dt.Rows
                key = CreateKeyFromDataRow(dr)

                dataRecipe = New DataRecipe
                dataRecipe.Data = dr(ColumnIndex).ToString()

                If Not stepCopyed.ContainsKey(key) Then
                    stepCopyed.Add(key, dataRecipe)
                End If
            Next

            btnDeleteStep.Enabled = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' CreateKeyFromDataRow
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CreateKeyFromDataRow(ByVal dataRow As DataRow) As String
        Dim key As String = String.Empty

        Try

            If dataRow("DefaultValue").ToString().Length = 0 AndAlso dataRow("BelongToGroup").ToString().Length = 0 Then
                key = dataRow("ParameterName").ToString()
            Else
                key = dataRow("BelongToGroup").ToString() & "." & dataRow("ParameterName").ToString()
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return key
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' First Load
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearForm()
        Try
            Me.txtDescription.Text = ""
            Me.dgvChamber.DataSource = Nothing
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckPermission()
        Try
            If AVPLib.ContainerData.Permission(PERMISSION_002) AndAlso Not AVPRobotMain.OnlineRemote Then
                ActiveForm()
            Else
                InactiveForm()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Active Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveForm()
        Try
            btnInsertStep.Enabled = False
            btnAddStep.Enabled = True And Not IsAlignerEditorOpen() 'Do not let user create more than one step in aligner recipe
            btnDeleteStep.Enabled = False
            btnCopyStep.Enabled = False
            btnPasteStep.Enabled = False
            btnInsertCopiedStep.Enabled = False
            btnAddCopiedStep.Enabled = False
            btnQuickView.Enabled = True
            Me.btnDelete.Enabled = True
            Me.btnNew.Enabled = True
            Me.btnOpen.Enabled = True
            Me.btnSave.Enabled = True
            Me.btnSaveAs.Enabled = True
            Me.dgvChamber.ReadOnly = False
            Me.txtDescription.Enabled = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Inactive Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InactiveForm()
        Try
            btnInsertStep.Enabled = False
            btnAddStep.Enabled = False
            btnDeleteStep.Enabled = False
            btnCopyStep.Enabled = False
            btnPasteStep.Enabled = False
            btnInsertCopiedStep.Enabled = False
            btnAddCopiedStep.Enabled = False
            btnQuickView.Enabled = False
            Me.btnDelete.Enabled = False
            Me.btnNew.Enabled = False
            Me.btnOpen.Enabled = (AVPLib.ContainerData.UserLogin IsNot Nothing)
            Me.btnSave.Enabled = False
            Me.btnSaveAs.Enabled = False
            Me.dgvChamber.ReadOnly = True
            Me.txtDescription.Enabled = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "ContextMenu"
    Dim ColumnIndex As Integer = 0
    Dim RowIndex As Integer = 0

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Mouse Down Right Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvChamber_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvChamber.MouseDown
        AVPLib.Log.guiLogger.Info("Enter dgvChamber_MouseDown")
        Try
            ' Do not show context menu when selected tab is Aligner
            If IsAlignerEditorOpen() Then
                Me.ctxMenu.Items.Clear()
                Exit Try
            End If

            ColumnIndex = dgvChamber.HitTest(e.X, e.Y).ColumnIndex
            RowIndex = dgvChamber.HitTest(e.X, e.Y).RowIndex
            If e.Button = Windows.Forms.MouseButtons.Right And ColumnIndex > 0 Then
                Me.ctxMenu.Items.Clear()
                If (AVPLib.ContainerData.Permission(PERMISSION_002)) And Not AVPRobotMain.OnlineRemote Then 'Do not let user create more than one step in aligner recipe
                    Me.ctxMenu.Items.Add("Insert Step")
                    Me.ctxMenu.Items.Add("Add Step")
                    Me.ctxMenu.Items.Add("Delete Step")
                    Me.ctxMenu.Items.Add("Copy Step")
                    Me.ctxMenu.Items.Add("Paste Step")
                    Me.ctxMenu.Items.Add("Insert Copied Step")
                    Me.ctxMenu.Items.Add("Add Copied Step")
                    Me.ctxMenu.Show(dgvChamber, New Point(e.X, e.Y))
                End If

                'handle and test 
                'm_MouseClicked = MouseClicked.SaveFileClicked
                'SetButtonStatus(m_MouseClicked)

            ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
                If ColumnIndex <= 0 Then ' click out side form
                    m_MouseClicked = MouseClicked.FormClicked
                    SetButtonStatus(m_MouseClicked)
                Else
                    Dim RowIndex As Integer = dgvChamber.HitTest(e.X, e.Y).RowIndex
                    If (ColumnIndex > (Total_Columns - 1)) And (RowIndex >= 0) AndAlso Me.dgvChamber.Rows(RowIndex).ReadOnly = False Then
                        'SetButtonEnableDisable(True)
                        Dim dt As DataTable = CType(Me.dgvChamber.DataSource, DataTable)
                        Dim dr As DataRow = dt.Rows(RowIndex)
                        Dim ParameterName As String = dr("Parameters").ToString()
                        Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(m_lastOpenRecipe)
                        Dim displayItems As List(Of KeyValuePair(Of String, String)) = AVPLib.Utils.GetListOfDisplayItem(ChamberName, ParameterName)
                        If displayItems IsNot Nothing Then
                            ctxMenu.Items.Clear()
                            Dim Parameter As String = dr("ParameterName").ToString()
                            For Each item As KeyValuePair(Of String, String) In displayItems 'Show Data in Combox to Choose
                                If Parameter.Contains("TargetSelection") Then
                                    Dim objSystemModule As SystemModule = Nothing

                                    Dim itemValue As String = String.Empty
                                    If item.Value.StartsWith("T") Then
                                        itemValue = item.Value.Substring(1)
                                    Else
                                        itemValue = item.Value
                                    End If

                                    If AVPLib.ContainerData.IsChamberVisible(ChamberName, objSystemModule) _
                                    AndAlso (objSystemModule.Type = SystemModule.ModuleType.PVD4 OrElse objSystemModule.Type = SystemModule.ModuleType.PVD5T) Then
                                        Dim propInfo As System.Reflection.PropertyInfo = objSystemModule.GetType().GetProperty("Target" & IIf(itemValue = "1", "", itemValue) & "Visible")
                                        Dim targetVisible As Boolean = True
                                        If propInfo IsNot Nothing Then
                                            targetVisible = CType(propInfo.GetValue(objSystemModule, Nothing), Boolean)
                                        End If
                                        ' Do not add to menu if target is not installed.
                                        If Not targetVisible Then
                                            Continue For
                                        End If
                                    End If
                                End If
                                ctxMenu.Items.Add(item.Key) ',AddressOf CMenuCmbClick)
                            Next
                            If RowIndex >= 0 And RowIndex <= (dt.Rows.Count - 1) Then
                                '2013-07-12 Tin Pham: can't click on cell is disable
                                If Me.dgvChamber.Rows(RowIndex).Cells(ColumnIndex).Tag = ConstEnum.STR_DISABLE Then
                                    Exit Try
                                End If
                                '---------------------------------------------------
                                Me.dgvChamber.Item(ColumnIndex, RowIndex).Selected = True
                                Me.dgvChamber.Item(ColumnIndex, RowIndex).ReadOnly = True
                                ctxMenu.Show(dgvChamber, New Point(e.X, e.Y))
                            End If
                        Else 'displayitems is nothing
                            If (Me.dgvChamber.Rows(RowIndex).Cells("Unit").Value.ToString().Contains("String")) AndAlso Me.dgvChamber.Rows(RowIndex).ReadOnly = False Then
                                '2013-07-12 Tin Pham: can't click on cell is disable
                                If Me.dgvChamber.Rows(RowIndex).Cells(ColumnIndex).Tag = ConstEnum.STR_DISABLE Then
                                    Exit Try
                                End If
                                '---------------------------------------------------
                                Dim frm As New KeyPad
                                dt = CType(Me.dgvChamber.DataSource, DataTable)
                                dr = dt.Rows(RowIndex)

                                Dim value As String = Me.dgvChamber.Rows(RowIndex).Cells(ColumnIndex).Value

                                If frm.DisplayKeypad(value, "Enter your text", False) = DialogResult.OK Then
                                    SetGridStyle(value, RowIndex, ColumnIndex)
                                    Me.dgvChamber.Rows(RowIndex).Cells(ColumnIndex).Value = value
                                End If

                            End If
                        End If
                    End If
                End If
            ElseIf (e.Button = Windows.Forms.MouseButtons.Right) And ColumnIndex <= 0 Then
                Me.ctxMenu.Items.Clear()
                If (AVPLib.ContainerData.Permission(PERMISSION_002)) And Not AVPRobotMain.OnlineRemote Then 'Do not let user create more than one step in aligner recipe
                    Me.ctxMenu.Items.Add("Add Step")
                    Me.ctxMenu.Show(dgvChamber, New Point(e.X, e.Y))
                    m_MouseClicked = MouseClicked.FormClicked
                    SetButtonStatus(m_MouseClicked)
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave dgvChamber_MouseDown")
    End Sub

    Private Sub SetButtonStatus(ByVal mouseclicked As MouseClicked)
        Try
            If (AVPLib.ContainerData.Permission(PERMISSION_002) And Not AVPRobotMain.OnlineRemote) Then
                If Not IsAlignerEditorOpen() Then 'Do not let user create more than one step in aligner recipe
                    Select Case mouseclicked
                        Case mouseclicked.NewFileClicked, mouseclicked.DeleteFileClicked, mouseclicked.OpenFileClicked
                            btnInsertStep.Enabled = False
                            btnAddStep.Enabled = True
                            btnDeleteStep.Enabled = False
                            btnCopyStep.Enabled = False
                            btnInsertCopiedStep.Enabled = False
                            btnPasteStep.Enabled = False
                            'copied then paste enable
                            If (Not stepCopyed Is Nothing AndAlso stepCopyed.Count = 0) Then
                                btnAddCopiedStep.Enabled = False
                            Else
                                btnAddCopiedStep.Enabled = True
                            End If
                        Case mouseclicked.SaveFileClicked, mouseclicked.SaveAsFileClicked
                            'no change action
                        Case mouseclicked.FormClicked
                            btnInsertStep.Enabled = False
                            btnAddStep.Enabled = True
                            btnDeleteStep.Enabled = False
                            btnCopyStep.Enabled = False
                            btnInsertCopiedStep.Enabled = False
                            btnPasteStep.Enabled = False
                            'copied then paste enable
                            If (Not stepCopyed Is Nothing AndAlso stepCopyed.Count = 0) Then
                                btnAddCopiedStep.Enabled = False
                            Else
                                btnAddCopiedStep.Enabled = True
                            End If
                        Case mouseclicked.DataRowClicked, mouseclicked.DataColumnClicked
                            btnInsertStep.Enabled = True
                            btnAddStep.Enabled = True
                            btnDeleteStep.Enabled = True
                            btnCopyStep.Enabled = True
                            'copied then paste enable
                            If (Not stepCopyed Is Nothing AndAlso stepCopyed.Count = 0) Then
                                btnPasteStep.Enabled = False
                                btnInsertCopiedStep.Enabled = False
                                btnAddCopiedStep.Enabled = False
                            Else
                                btnPasteStep.Enabled = True
                                btnInsertCopiedStep.Enabled = True
                                btnAddCopiedStep.Enabled = True
                            End If
                        Case mouseclicked.CopyStepClicked
                            btnInsertStep.Enabled = True
                            btnAddStep.Enabled = True
                            btnDeleteStep.Enabled = True
                            btnCopyStep.Enabled = True

                            'copied then paste enable
                            If (Not stepCopyed Is Nothing AndAlso stepCopyed.Count = 0) Then
                                btnPasteStep.Enabled = False
                                btnInsertCopiedStep.Enabled = False
                                btnAddCopiedStep.Enabled = False
                            Else
                                btnPasteStep.Enabled = True
                                btnInsertCopiedStep.Enabled = True
                                btnAddCopiedStep.Enabled = True
                            End If
                        Case mouseclicked.AddStepClicked, mouseclicked.InsertStepClicked, _
                            mouseclicked.AddCopyStepClicked, mouseclicked.InsertCopyStepClicked, _
                            mouseclicked.DeleteStepClicked, mouseclicked.PasteStepClicked
                            btnInsertStep.Enabled = False
                            btnAddStep.Enabled = True
                            btnDeleteStep.Enabled = False
                            btnCopyStep.Enabled = False
                            btnInsertCopiedStep.Enabled = False
                            btnPasteStep.Enabled = False
                            'copied then paste enable
                            If (Not stepCopyed Is Nothing AndAlso stepCopyed.Count = 0) Then
                                btnAddCopiedStep.Enabled = False
                            Else
                                btnAddCopiedStep.Enabled = True
                            End If
                    End Select
                Else 'Do not let user create more than one step in aligner recipe
                    btnInsertStep.Enabled = False
                    btnAddStep.Enabled = False
                    btnDeleteStep.Enabled = False
                    btnCopyStep.Enabled = False
                    btnInsertCopiedStep.Enabled = False
                    btnPasteStep.Enabled = False
                    btnAddCopiedStep.Enabled = False
                End If
            Else
                InactiveForm()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Context Menu Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CMenuClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsertStep.Click, btnAddStep.Click, _
btnAddCopiedStep.Click, btnDeleteStep.Click, btnCopyStep.Click, btnPasteStep.Click, btnInsertCopiedStep.Click
        AVPLib.Log.guiLogger.Info("Enter CMenuClick")
        Try
            If Not IsAlignerEditorOpen() Then 'Do not let user create more than one step in aligner recipe
                SetOldToolTip()
                Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(m_lastOpenRecipe)
                Dim ChamberNameActive As String = AVPLib.ContainerData.GetRecipe(ChamberName).ChamberNameActive
                Dim strCommandText As String = String.Empty
                If sender.GetType.Name = "Button" Then
                    strCommandText = CType(sender, Button).Text.Trim()
                Else 'command from context menu
                    strCommandText = CType(e, System.Windows.Forms.ToolStripItemClickedEventArgs).ClickedItem.Text
                End If
                If strCommandText = "Insert Step" Then
                    Me.InsertStep(False)
                    m_MouseClicked = MouseClicked.InsertStepClicked
                    SetButtonStatus(m_MouseClicked)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Recipe Editor] Insert Step." + " at " + AVPLib.Utils.chamberID2ChamberName(ChamberName) + "-" + ChamberNameActive)
                ElseIf strCommandText = "Add Step" Then
                    Me.AddStep(False)
                    m_MouseClicked = MouseClicked.AddStepClicked
                    SetButtonStatus(m_MouseClicked)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Recipe Editor] Add Step." + " at " + AVPLib.Utils.chamberID2ChamberName(ChamberName) + "-" + ChamberNameActive)
                ElseIf strCommandText = "Delete Step" Then
                    Me.DeleteStep()
                    m_MouseClicked = MouseClicked.DeleteStepClicked
                    SetButtonStatus(m_MouseClicked)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Recipe Editor] Delete Step." + " at " + AVPLib.Utils.chamberID2ChamberName(ChamberName) + "-" + ChamberNameActive)
                ElseIf strCommandText = "Copy Step" Then
                    Me.CopyStep()
                    m_MouseClicked = MouseClicked.CopyStepClicked
                    SetButtonStatus(m_MouseClicked)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Recipe Editor] Copy Step." + " at " + AVPLib.Utils.chamberID2ChamberName(ChamberName) + "-" + ChamberNameActive)
                ElseIf strCommandText = "Paste Step" Then
                    Me.PasteStep()
                    m_MouseClicked = MouseClicked.PasteStepClicked
                    SetButtonStatus(m_MouseClicked)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Recipe Editor] Paste Step." + " at " + AVPLib.Utils.chamberID2ChamberName(ChamberName) + "-" + ChamberNameActive)
                ElseIf strCommandText = "Insert Copied Step" Then
                    Me.InsertStep(True)
                    m_MouseClicked = MouseClicked.InsertCopyStepClicked
                    SetButtonStatus(m_MouseClicked)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Recipe Editor] Insert copied Step." + " at " + AVPLib.Utils.chamberID2ChamberName(ChamberName) + "-" + ChamberNameActive)
                ElseIf strCommandText = "Add Copied Step" Then
                    Me.AddStep(True)
                    m_MouseClicked = MouseClicked.AddCopyStepClicked
                    SetButtonStatus(m_MouseClicked)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Recipe Editor] Add copied Step." + " at " + AVPLib.Utils.chamberID2ChamberName(ChamberName) + "-" + ChamberNameActive)
                End If
                If (strCommandText <> "Copy Step") _
                        AndAlso (m_iColumnSelected <= dgvChamber.Columns.Count) AndAlso (m_iColumnSelected >= 0) Then
                    Me.dgvChamber.Item(m_iColumnSelected, 0).Selected = True
                End If

            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CMenuClick")
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' CMenuCmbClick
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ctxMenu_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ctxMenu.ItemClicked
        AVPLib.Log.guiLogger.Info("Enter CMenuCmbClick")
        Try
            'Dim MenuItem As MenuItem = CType(sender, MenuItem)
            If e.ClickedItem.Text = "Insert Step" Or e.ClickedItem.Text = "Add Step" _
            Or e.ClickedItem.Text = "Delete Step" Or e.ClickedItem.Text = "Copy Step" _
            Or e.ClickedItem.Text = "Paste Step" Or e.ClickedItem.Text = "Insert Copied Step" _
            Or e.ClickedItem.Text = "Add Copied Step" Then
                CMenuClick(sender, e)
                Exit Sub
            End If
            Dim dt As DataTable = CType(Me.dgvChamber.DataSource, DataTable)

            '2013-07-19 Tin Pham modified: disable cell, calculate for cell
            If dt.Rows(RowIndex)(ColumnIndex) <> e.ClickedItem.Text Then
                EnableDisableAndCalculateForCell(dt, e.ClickedItem.Text)
            End If
            'End -----------------------------------------------------------------------------------------------

            SetGridStyle(e.ClickedItem.Text, RowIndex, ColumnIndex)
            dt.Rows(RowIndex)(ColumnIndex) = e.ClickedItem.Text
            IsModified = True
            Me.dgvChamber.Refresh()

            m_MouseClicked = MouseClicked.DataRowClicked
            SetButtonStatus(m_MouseClicked)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CMenuCmbClick")
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-07-19</date>
    ''' </author>
    ''' <summary>
    ''' DisableAndCalculateForCell
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="keyRow"></param>
    ''' <remarks></remarks>
    Private Sub EnableDisableAndCalculateForCell(ByVal dt As DataTable, ByVal keyRow As String)
        Try
            Const kParameterName As String = "ParameterName"
            Const kBelongToGroup As String = "BelongToGroup"
            Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(m_lastOpenRecipe)
            Dim seqNo As Integer = 0
            Dim GroupCode As String = dt.Rows(RowIndex)(kBelongToGroup)
            Dim listOfSeqNoCalculate As New Hashtable
            Dim listOfSeqNoDisable As Hashtable = AVPLib.Utils.GetListOfSeqNoDisable(ChamberName, GroupCode, dt.Rows(RowIndex)(kParameterName), seqNo, listOfSeqNoCalculate)
            If listOfSeqNoDisable IsNot Nothing AndAlso listOfSeqNoDisable.Count > 0 Then
                'enable previous cell
                Dim strListOfSeqNoDisable As String = listOfSeqNoDisable.Item(dt.Rows(RowIndex)(ColumnIndex))
                EnableDisableCell(strListOfSeqNoDisable, seqNo, Color.White, "")
                'disable current cell
                strListOfSeqNoDisable = listOfSeqNoDisable.Item(keyRow)
                EnableDisableCell(strListOfSeqNoDisable, seqNo, Color.DarkGray, STR_DISABLE)
                'calculate
                If listOfSeqNoCalculate IsNot Nothing AndAlso listOfSeqNoCalculate.Count > 0 Then
                    Dim formulaRow As String = listOfSeqNoCalculate.Item(keyRow)
                    CalculateCell(formulaRow, seqNo, RowIndex)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-07-19</date>
    ''' </author>
    ''' <summary>
    ''' DisableCell
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="seqNo"></param>
    ''' <param name="color"></param>
    ''' <param name="strDisable"></param>
    ''' <remarks></remarks>
    Private Sub EnableDisableCell(ByVal strListOfSeqNoDisable As String, ByVal seqNo As Integer, _
                                  ByVal color As Color, ByVal strDisable As String)
        Try
            Dim arr As Array
            Dim idexRow As Integer = 0
            Dim dt As DataTable = CType(Me.dgvChamber.DataSource, DataTable)
            If strListOfSeqNoDisable IsNot Nothing Then
                arr = strListOfSeqNoDisable.Split(STR_COMMA)
                For i As Integer = 0 To arr.Length - 1
                    Dim strSeq As String = arr(i).ToString()
                    If strSeq.Contains(":") Then
                        Dim strInfomationSeq As Array = strSeq.Split(":")
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
                        idexRow = RowIndex - seqNo + arr(i)
                    End If

                    If strDisable = "" Then
                        color = Me.dgvChamber.Rows(idexRow).Cells("ParameterName").Style.BackColor
                        If Me.dgvChamber.Rows(idexRow).Cells(ColumnIndex).Value = String.Empty Then
                            Me.dgvChamber.Rows(idexRow).Cells(ColumnIndex).Value = dt.Rows(idexRow)("DefaultValue").ToString
                        End If
                    End If
                    Me.dgvChamber.Rows(idexRow).Cells(ColumnIndex).Style.BackColor = color
                    Me.dgvChamber.Rows(idexRow).Cells(ColumnIndex).Tag = strDisable
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-07-19</date>
    ''' </author>
    ''' <summary>
    ''' CalculateCell
    ''' </summary>
    ''' <param name="strFormula"></param>
    ''' <param name="seqNo"></param>
    ''' <remarks></remarks>
    Private Sub CalculateCell(ByVal strFormula As String, ByVal seqNo As Integer, ByVal index As Integer)
        If strFormula IsNot Nothing Then
            Dim arrCal As Array = strFormula.Split(STR_SEMICOLON)
            For i As Integer = 0 To arrCal.Length - 1
                Dim position As Integer = arrCal(i).ToString.IndexOf(STR_EQUAL)
                Dim rowTemp As Integer = Integer.Parse(arrCal(i).ToString.Substring(0, position))
                Dim idexRow As Integer = index - seqNo + rowTemp
                Dim formulaTemp As String = arrCal(i).ToString.Substring(position + 1)
                If formulaTemp IsNot Nothing Then
                    Dim arrFormulaRow As Array = formulaTemp.Split(STR_COMMA)
                    Dim formula As String = arrFormulaRow(0)
                    For k As Integer = 0 To arrFormulaRow.Length - 1
                        If k > 0 Then
                            Dim idexRowCal As Integer = index - seqNo + arrFormulaRow(k)
                            UpdateValueHideColumn(idexRowCal, index)
                            Dim oldValue As String = STR_OPEN_ANGLE_BRACKETS & (k - 1).ToString & STR_CLOSE_ANGLE_BRACKETS
                            formula = formula.Replace(oldValue, Me.dgvChamber.Rows(idexRowCal).Cells(ColumnIndex).Value)
                        End If
                    Next
                    'in the case: divide 0, we just try...catch
                    Try
                        Dim valueAfterCalculate As Integer = AVPLib.Expression.Evaluate(formula, New Dictionary(Of String, Double)())
                        Me.dgvChamber.Rows(idexRow).Cells(ColumnIndex).Value = valueAfterCalculate
                    Catch ex As Exception
                        AVPLib.Log.avpLogger.Error(ex.ToString())
                    End Try
                End If
            Next
        End If
    End Sub
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-07-19</date>
    ''' </author>
    ''' <summary>
    ''' UpdateValueHideColumn
    ''' </summary>
    ''' <param name="indexRowCal"></param>
    ''' <param name="rowDisable"></param>
    ''' <remarks></remarks>
    Private Sub UpdateValueHideColumn(ByVal indexRowCal As Integer, ByVal rowDisable As Integer)
        Dim rowHideCal As String = Me.dgvChamber.Rows(indexRowCal).Cells("ParameterCalculate").Value
        If Not rowHideCal.Contains(rowDisable.ToString) Then
            If String.IsNullOrEmpty(rowHideCal) Then
                rowHideCal = rowDisable
            Else
                rowHideCal = rowHideCal & STR_COMMA & rowDisable
            End If
            Me.dgvChamber.Rows(indexRowCal).Cells("ParameterCalculate").Value = rowHideCal
        End If
    End Sub

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2019-04-18</date>
    ''' </author>
    ''' <summary>
    ''' ValidateLoopRecipe
    ''' </summary>
    Private Function ValidateLoopRecipe(ByVal dt As DataTable, ByVal sFileName As String, ByVal sTitleOfErrorMsg As String, ByVal sFileType As String) As Boolean
        Dim blResult As Boolean = False
        Try
            If Not LoopValidate(dt) Then
                Utils.ShowAVPMessageBox("Error in " & sFileType, sTitleOfErrorMsg, MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                      AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                      "[Main Screen] " + "Error in " & sTitleOfErrorMsg & " " & sFileType)
            Else
                blResult = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blResult
    End Function

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2019-04-18</date>
    ''' </author>
    ''' <summary>
    ''' LoopValidate
    ''' </summary>
    Private Function LoopValidate(ByVal dt As DataTable) As Boolean
        Try
            Const kParameterName As String = "ParameterName"
            Dim StartIndex As Integer = 0
            Dim EndIndex As Integer = 0
            Dim SelfLoopIndex As Integer = 0
            Dim StartCount As Integer = 0
            Dim EndCount As Integer = 0
            Dim nRow As Integer = 0
            For Each drMerge As DataRow In dt.Rows
                If drMerge(kParameterName).ToString() = "LoopMode" Then
                    Dim nColumn As Integer = 0
                    For Each Column As DataGridViewTextBoxColumn In Me.dgvChamber.Columns
                        If Column.Visible = True And nColumn >= 1 Then
                            Dim cellText As String = Me.dgvChamber.Rows(nRow).Cells(nColumn).Value
                            Select Case cellText.ToUpper
                                Case STR_SELF_LOOP.ToUpper
                                    SelfLoopIndex = nColumn
                                Case STR_START.ToUpper
                                    StartCount += 1
                                    If StartIndex > 0 And nColumn > StartIndex And (StartCount - EndCount) > 1 Then
                                        Return False
                                    End If
                                    StartIndex = nColumn
                                Case STR_END.ToUpper
                                    EndCount += 1
                                    If (StartCount = 0) Or (EndIndex > 0 And nColumn > EndIndex And EndCount > StartCount) Then
                                        Return False
                                    End If
                                    EndIndex = nColumn
                            End Select
                            If SelfLoopIndex > 0 And SelfLoopIndex > StartIndex And SelfLoopIndex < EndIndex Then
                                Return False
                            End If
                        End If
                        nColumn += 1
                    Next
                    If StartCount <> EndCount Then
                        Return False
                    End If

                ElseIf drMerge(kParameterName).ToString() = "LoopCount" Then
                    If EndIndex > 0 Then
                        Dim cellEnd As Integer = Convert.ToInt32(Me.dgvChamber.Rows(nRow).Cells(EndIndex).Value)
                        If cellEnd <= 0 Then
                            Return False
                        End If
                    End If

                    If SelfLoopIndex > 0 Then
                        Dim cellSelfLoop As Integer = Convert.ToInt32(Me.dgvChamber.Rows(nRow).Cells(SelfLoopIndex).Value)
                        If cellSelfLoop <= 0 Then
                            Return False
                        End If
                    End If

                    Exit Try
                End If
                nRow += 1
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            Return False
        End Try
        Return True
    End Function
#End Region

    Private Sub txtDescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.Click
        Dim pad As New KeyPad
        Dim Value As String = txtDescription.Text
        If pad.DisplayKeypad(Value, "Please input the description", False) = DialogResult.OK Then
            txtDescription.Text = Value
        End If
    End Sub

    Private Sub dgvChamber_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvChamber.CellClick
        AVPLib.Log.guiLogger.Info("Enter txtCG2_Click")
        Try
            If e.ColumnIndex > 0 And e.RowIndex >= 0 AndAlso _
                (Me.dgvChamber.Rows(e.RowIndex).Cells("Unit").Value.ToString().Contains("Number")) AndAlso Me.dgvChamber.Rows(e.RowIndex).ReadOnly = False Then
                '2013-07-12 Tin Pham: can't click on cell is disable
                If Me.dgvChamber.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag = ConstEnum.STR_DISABLE Then
                    Exit Try
                End If
                '---------------------------------------------------
                Dim frm As New NumPad
                Dim dt As DataTable = CType(Me.dgvChamber.DataSource, DataTable)
                Dim dr As DataRow = dt.Rows(e.RowIndex)

                Dim Min As Double = CDbl(dr("ParameterMin"))
                Dim Max As Double = CDbl(dr("ParameterMax"))

                '#23/08/2011 
                '#- Get min/max from db chamber to can show min/max rightly when datagrid is not updated.
                '#Begin fix.
                GetMinMaxFromDBChamber(dr("ParameterName"), dr("BelongToGroup"), Min, Max)
                '#End fix

                Dim value As String = Me.dgvChamber.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                'Dim strUnit As String = Me.dgvChamber.Rows(e.RowIndex).Cells(0).Value.ToString().Replace(Me.dgvChamber.Rows(e.RowIndex).Cells(1).Value.ToString(), "")
                Dim strUnit As String = Me.dgvChamber.Rows(e.RowIndex).Cells(0).Value.ToString()

                Dim InputRes As MsgBoxResult = frm.GetUserInput(value, -1, -1, Min, Max, "Enter your value - " & strUnit)

                ' Save Max & Min
                If frm.IsMaxMinModified Then
                    Me.SaveMinMaxParameter(dr("BelongToGroup"), dr("ParameterName"), frm.NewMin, frm.NewMax)
                    dr("ParameterMin") = frm.NewMin
                    dr("ParameterMax") = frm.NewMax
                    AVPLib.Utils.UpdateMinMaxRecipe(dgvChamber.Rows(e.RowIndex).Cells(5).Value.ToString(), dgvChamber.Rows(e.RowIndex).Cells(1).Value.ToString(), frm.NewMin, frm.NewMax, m_lastOpenRecipe)
                    Utils.SynchronizeMinMaxValueToPMScreen(dr("ParameterName"), m_lastOpenRecipe, frm.NewMin.ToString(), frm.NewMax.ToString(), dr("BelongToGroup"))
                End If

                If InputRes = MsgBoxResult.Ok Then
                    SetGridStyle(value, e.RowIndex, e.ColumnIndex)

                    ' 2015-06-25: Hoai Ly update pressure format
                    If Me.dgvChamber.Rows(e.RowIndex).Cells(0).Value.ToString().ToLower().Replace("_", "").Replace(" ", "").Contains(strCellTitle) Then
                        Me.dgvChamber.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = FormatNumber(value)
                    Else
                        Me.dgvChamber.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = value
                    End If

                    ''0008267: [KhoiHa - 08/28/2015]When user input power or voltage > 0, sub. Ground should be switch to no by default
                    'Dim dbValue As Double = 0
                    'Double.TryParse(value, dbValue)
                    'If dr("ParameterName") = "BiasPower" AndAlso dbValue > 0 Then
                    '    Me.dgvChamber.Rows(e.RowIndex + 2).Cells(e.ColumnIndex).Value = "No"
                    'End If

                    'If dr("ParameterName") = "BiasVoltage" AndAlso dbValue > 0 Then
                    '    Me.dgvChamber.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value = "No"
                    'End If

                    '2013-07-19 Tin Pham Modified
                    Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(m_lastOpenRecipe)
                    Dim seqNo As Integer = 0
                    Dim strCal As String = Me.dgvChamber.Rows(e.RowIndex).Cells("ParameterCalculate").Value
                    If strCal IsNot Nothing AndAlso Not String.IsNullOrEmpty(strCal) Then
                        Dim arrCal As Array = strCal.Split(STR_COMMA)
                        For i As Integer = 0 To arrCal.Length - 1
                            Dim GroupCode As String = dt.Rows(arrCal(i))("BelongToGroup")
                            Dim listOfSeqNoCalculate As New Hashtable
                            AVPLib.Utils.GetListOfSeqNoDisable(ChamberName, GroupCode, dt.Rows(arrCal(i))("ParameterName"), seqNo, listOfSeqNoCalculate)
                            'calculate
                            If listOfSeqNoCalculate IsNot Nothing AndAlso listOfSeqNoCalculate.Count > 0 Then
                                Dim formulaRow As String = listOfSeqNoCalculate.Item(dt.Rows(arrCal(i))(e.ColumnIndex))
                                CalculateCell(formulaRow, seqNo, arrCal(i))
                            End If
                        Next
                    End If
                    'End--------------------------------
                    MoveToNextEditableCell()
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txtCG2_Click")
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-05-24</date>
    ''' <summary>
    ''' Move focus to next editable cell.
    ''' </summary>
    Private Function MoveToNextEditableCell() As Boolean
        Try
            If dgvChamber.CurrentCell IsNot Nothing Then
                Dim rowIndex As Integer = dgvChamber.CurrentCell.RowIndex
                Dim columnIndex As Integer = dgvChamber.CurrentCell.ColumnIndex

                rowIndex += 1
                While rowIndex < dgvChamber.Rows.Count _
                    AndAlso (Not dgvChamber.Rows(rowIndex).Cells(columnIndex).Visible _
                            OrElse dgvChamber.Rows(rowIndex).Cells(columnIndex).Tag = STR_DISABLE _
                            OrElse TypeOf dgvChamber.Rows(rowIndex).Cells(columnIndex) Is HMergedCell)
                    rowIndex += 1
                End While

                If rowIndex < dgvChamber.Rows.Count Then
                    dgvChamber.CurrentCell = dgvChamber.Rows(rowIndex).Cells(columnIndex)
                    Return True
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>
    '''     <name> Tin Pham </name>
    '''     <date> 2015-10-09 </date>
    ''' </author>
    ''' <summary>
    ''' Get min/max from db chamber to can show min/max rightly
    ''' </summary>
    Private Function GetMinMaxFromDBChamber(ByVal parameterName As String, ByVal groupCode As String, ByRef min As Double, ByRef max As Double) As Boolean
        Dim result As Boolean = False

        Try
            Dim recipe As AVPLib.DBRecipe = AVPLib.ContainerData.GetRecipe(m_lastOpenRecipe)
            Dim recipeChamber As DBChamber = AVPLib.ContainerData.Chamber(m_lastOpenRecipe, recipe.ChamberNameActive)
            For Each dbparam As AVPLib.DBParameterGroup In recipeChamber.ListGroupParameters
                For Each param As AVPLib.DBParameter In dbparam.Parameters
                    If param.Name = parameterName And dbparam.GroupCode = groupCode Then
                        min = param.Min
                        max = param.Max
                        result = True
                        GoTo RoundMinMax
                    End If
                Next
            Next

RoundMinMax:
            'If min < 0 Then
            '    min = 0
            'Else
            '    min = Math.Round(min, MidpointRounding.AwayFromZero)
            'End If

            'If max < 0 Then
            '    max = 0
            'Else
            '    max = Math.Round(max, MidpointRounding.AwayFromZero)
            'End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return result
    End Function

    ''' <author>
    '''     <name> Hoai Ly </name>
    '''     <date> 2015-06-25 </date>
    ''' </author>
    ''' <summary>
    ''' Format double number to 0.00E+00
    ''' </summary>
    Private Function FormatNumber(ByVal value As String) As String
        Try
            Dim fRes As Double = 0.0
            If Double.TryParse(value, fRes) Then
                If fRes <> 0 Then
                    Return fRes.ToString("0.00E+00")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return value
    End Function

    Private Sub SaveMinMaxParameter(ByVal groupCode As String, ByVal paramName As String, ByVal Min As Single, ByVal Max As Single)
        AVPLib.Log.guiLogger.Info("Enter SaveMinMaxParameter")
        Try
            Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(m_lastOpenRecipe)
            Dim chamberModule As SystemModule = AVPLib.ContainerData.GetRobotConfig(ChamberName)
            Dim FilePath As String = AVPLib.ContainerDAO.FPath_ChamberConfig & "\Chambers" & "\"
            If chamberModule Is Nothing Then
                AVPLib.Log.avpLogger.Error("SaveMinMaxParameter Failed: ChamberModule is Nothing")
                Exit Try
            End If
            If chamberModule.Type = SystemModule.ModuleType.Aligner Then
                FilePath = FilePath & ChamberName & "\" & ChamberName & ".xml"
            Else
                FilePath = FilePath & ChamberName & "\" & ChamberName & "_" & chamberModule.Type.ToString() & ".xml"
            End If
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
        AVPLib.Log.guiLogger.Info("Leave SaveMinMaxParameter")
    End Sub

    Private Sub dgvChamber_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvChamber.ColumnHeaderMouseClick
        AVPLib.Log.guiLogger.Info("Enter dgvChamber_ColumnHeaderMouseClick")
        Try
            For i As Integer = 0 To dgvChamber.Columns.Count - 1
                dgvChamber.Columns(i).HeaderCell.Style.BackColor = Color.Empty
                m_MouseClicked = MouseClicked.FormClicked
                SetButtonStatus(m_MouseClicked)
            Next i
            If dgvChamber.Columns(e.ColumnIndex).HeaderCell.Value.ToString.StartsWith("Step") Then
                dgvChamber.Columns(e.ColumnIndex).HeaderCell.Style.BackColor = Color.Orange
                m_MouseClicked = MouseClicked.DataColumnClicked
                SetButtonStatus(m_MouseClicked)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave dgvChamber_ColumnHeaderMouseClick")
    End Sub

    Private Sub dgvChamber_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvChamber.CellBeginEdit
        Dim columnName As String = dgvChamber.Columns(e.ColumnIndex).HeaderText
        If columnName.StartsWith("Step") Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tabEditorRecipe_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
                                                      tabEditorRecipe.SelectedIndexChanged
        Try
            Loading = True
            If tabEditorRecipe.SelectedTab Is tabAlignerRecipe Then 'aligner tab click 
                m_lastOpenRecipe = ConstEnum.Equipments.Aligner.ToString()
                AddDataGrid_ToSelectedTab(tabAlignerRecipe)
                LoadDataGrid(False, Nothing, m_lastOpenRecipe)

            ElseIf tabEditorRecipe.SelectedTab Is tabPM1Recipe Then
                m_lastOpenRecipe = ConstEnum.Equipments.Chamber1.ToString()
                AddDataGrid_ToSelectedTab(tabPM1Recipe)
                LoadDataGrid(False, Nothing, m_lastOpenRecipe)

            ElseIf tabEditorRecipe.SelectedTab Is tabPM2Recipe Then
                m_lastOpenRecipe = ConstEnum.Equipments.Chamber2.ToString()
                AddDataGrid_ToSelectedTab(tabPM2Recipe)
                LoadDataGrid(False, Nothing, m_lastOpenRecipe)

            ElseIf tabEditorRecipe.SelectedTab Is tabPM3Recipe Then
                m_lastOpenRecipe = ConstEnum.Equipments.Chamber3.ToString()
                AddDataGrid_ToSelectedTab(tabPM3Recipe)
                LoadDataGrid(False, Nothing, m_lastOpenRecipe)
            End If
            Loading = False
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                               AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                               "[Recipe Editor] Select Recipe of " + AVPLib.Utils.chamberID2ChamberName(m_lastOpenRecipe))
            'change tab 
            m_MouseClicked = MouseClicked.FormClicked
            SetButtonStatus(m_MouseClicked)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    Public Sub AddDataGrid_ToSelectedTab(ByVal TabContainer As TabPage)
        Try
            If TabContainer.Controls.Contains(dgvChamber) = False Then
                If tabPM1Recipe.Controls.Contains(dgvChamber) Then
                    tabPM1Recipe.Controls.Remove(dgvChamber)
                End If
                If tabPM2Recipe.Controls.Contains(dgvChamber) Then
                    tabPM2Recipe.Controls.Remove(dgvChamber)
                End If
                If tabPM3Recipe.Controls.Contains(dgvChamber) Then
                    tabPM3Recipe.Controls.Remove(dgvChamber)
                End If
                If tabAlignerRecipe.Controls.Contains(dgvChamber) Then
                    tabAlignerRecipe.Controls.Remove(dgvChamber)
                End If
                TabContainer.Controls.Add(dgvChamber)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    '#07/07/2011 
    '#-	AVP.  Recipe editor.  PMx tab does not retain new recipe that does not save. If user create a new recipe in PM1 
    '# but does not save and switch to PM2 then goes back to PM1,  PM1 does not retain new recipe 
    '# but instead default to last know recipe that was 
    Private Sub tabEditorRecipe_Deselected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles tabEditorRecipe.Deselected
        If IsModified Then
            Dim chamberName = AVPLib.Utils.chamberID2ChamberName(m_lastOpenRecipe)
            If Utils.ShowAVPMessageBox(chamberName & " recipe is modified. Would you like to save?", "Save confirm", MessageBoxIcon.Question, AVPMessageBox.AVPMessageBoxButton.YesNo) = DialogResult.OK Then
                btnSave_Click(Nothing, Nothing)
            End If
            IsModified = False
        End If
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-15</date>
    ''' </author>
    ''' <summary>
    ''' Check editor is opening aligner.
    ''' </summary>
    ''' <param name="Title"></param>
    ''' <remarks></remarks>
    Private Function IsAlignerEditorOpen() As Boolean
        If m_lastOpenRecipe = Equipments.Aligner.ToString() Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-05-20</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name=""></param>
    ''' <param name=""></param>
    ''' <remarks></remarks>
    Private Sub btnQuickView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuickView.Click
        Try
            Dim dt As DataTable = CType(Me.dgvChamber.DataSource, DataTable)
            Dim recipeName As String = Me.Title.Trim()
            Dim Title As String = tabEditorRecipe.SelectedTab.Text & "-" & recipeName
            Dim chamberId As String = AVPLib.Utils.chamberName2ChamberID(tabEditorRecipe.SelectedTab.Text.Trim)
            Utils.ShowQuickViewRecipe(chamberId, recipeName, Title, CurrentIsNew, False, dt, dictionaryColor)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub


    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-06-29</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name=""></param>
    ''' <param name=""></param>
    ''' <remarks></remarks>
    Private Sub SetDisableCell(ByVal indexRowList As ArrayList, ByVal dictionaryRowDisable As Dictionary(Of Integer, ArrayList), ByVal dictionaryRowCalculate As Dictionary(Of String, String))
        Try
            Dim nRow As Integer
            For i As Integer = 0 To indexRowList.Count - 1
                nRow = indexRowList(i)
                If dictionaryRowDisable IsNot Nothing AndAlso dictionaryRowDisable.Count > 0 AndAlso dictionaryRowDisable.ContainsKey(nRow) Then
                    Dim arrList As ArrayList = dictionaryRowDisable.Item(nRow)
                    For Each iColumn As Integer In arrList
                        'Disable
                        Me.dgvChamber.Rows(nRow).Cells(iColumn).Style.BackColor = Color.DarkGray
                        Me.dgvChamber.Rows(nRow).Cells(iColumn).Tag = ConstEnum.STR_DISABLE
                        'Calculate
                        Dim keyCal As String = nRow.ToString & STR_COMMA & iColumn.ToString
                        If dictionaryRowCalculate IsNot Nothing AndAlso dictionaryRowCalculate.Count > 0 AndAlso dictionaryRowCalculate.ContainsKey(keyCal) Then
                            Dim formulaRow As String = dictionaryRowCalculate.Item(keyCal)
                            If formulaRow IsNot Nothing Then
                                Dim arrFormulaRow As Array = formulaRow.Split(STR_COMMA)
                                Dim formula As String = arrFormulaRow(0)
                                For k As Integer = 0 To arrFormulaRow.Length - 1
                                    If k > 0 Then
                                        Dim oldValue As String = STR_OPEN_ANGLE_BRACKETS & (k - 1).ToString & STR_CLOSE_ANGLE_BRACKETS
                                        formula = formula.Replace(oldValue, Me.dgvChamber.Rows(arrFormulaRow(k)).Cells(iColumn).Value)
                                    End If
                                Next
                                'in the case: divide 0, we just try...catch
                                Try
                                    If formula = "String.Empty" Then
                                        Me.dgvChamber.Rows(nRow).Cells(iColumn).Value = String.Empty
                                    Else
                                        Dim valueAfterCalculate As Integer = AVPLib.Expression.Evaluate(formula, New Dictionary(Of String, Double)())
                                        If Me.dgvChamber.Rows(nRow).Cells(iColumn).Value <> valueAfterCalculate Then
                                            Me.dgvChamber.Rows(nRow).Cells(iColumn).Value = valueAfterCalculate
                                        End If
                                    End If
                                Catch ex As Exception
                                    AVPLib.Log.avpLogger.Error(ex.ToString())
                                End Try
                            End If
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-11-19</date>
    ''' </author>
    ''' <summary>
    ''' save config show reworkFiles
    ''' </summary>
    Private Sub cbxShowReworkFiles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxShowReworkFiles.CheckedChanged
        Try
            Utils.SaveShowReworkFiles(cbxShowReworkFiles.Checked)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-11-19</date>
    ''' </author>
    ''' <summary>
    ''' refresh data
    ''' </summary>
    Public Function RefreshData() As Boolean
        Try
            If AVPLib.ContainerDAO.EnableReworkFeature() Then
                cbxShowReworkFiles.Checked = AVPLib.ContainerDAO.ReadShowReworkFiles()
            Else
                cbxShowReworkFiles.Visible = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2021-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Clear all items in dictionary color
    ''' </summary>
    Private Sub ClearDictionaryColor()
        Try
            If dictionaryColor IsNot Nothing Then
                dictionaryColor.Clear()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2021-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Set items to dictionary color
    ''' </summary>
    Private Sub SetDictionaryColor(ByVal rowIndex As Integer, ByVal columnIndex As Integer)
        Try
            If dictionaryColor IsNot Nothing Then
                If dictionaryColor.ContainsKey(rowIndex) Then
                    Dim value As String = dictionaryColor(rowIndex)
                    If Not value.Contains(columnIndex.ToString()) Then
                        dictionaryColor(rowIndex) = value & "," & columnIndex.ToString()
                    End If
                Else
                    dictionaryColor(rowIndex) = columnIndex
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2021-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' UnSet items to dictionary color
    ''' </summary>
    Private Sub UnSetDictionaryColor(ByVal rowIndex As Integer, ByVal columnIndex As Integer)
        Try
            If dictionaryColor IsNot Nothing AndAlso dictionaryColor.ContainsKey(rowIndex) Then
                dictionaryColor(rowIndex) = dictionaryColor(rowIndex).Replace("," & columnIndex.ToString(), "")
                dictionaryColor(rowIndex) = dictionaryColor(rowIndex).Replace(columnIndex.ToString(), "")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2021-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Reset Grid Color and tool-tip 
    ''' </summary>
    Private Sub ResetGridStyle()
        Try
            For Each row As DataGridViewRow In dgvChamber.Rows
                For cellindex As Integer = 0 To row.Cells.Count - 1
                    row.Cells(cellindex).Style.ForeColor = Color.Black
                    row.Cells(cellindex).ToolTipText = ""

                Next
            Next

            ClearDictionaryColor()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2021-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Set Grid Color and tool-tip 
    ''' </summary>
    Private Sub SetGridStyle(ByVal value As String, ByVal rowIndex As Integer, ByVal columnIndex As Integer)
        Try
            Const OldValueStr As String = "Old Value: "
            Dim currentValue As String = Me.dgvChamber.Rows(rowIndex).Cells(columnIndex).Value.ToString
            If value <> currentValue Then
                If Me.dgvChamber.Rows(rowIndex).Cells(columnIndex).ToolTipText = "" Then
                    Me.dgvChamber.Rows(rowIndex).Cells(columnIndex).Style.ForeColor = Color.Red
                    Me.dgvChamber.Rows(rowIndex).Cells(columnIndex).ToolTipText = OldValueStr & currentValue

                    SetDictionaryColor(rowIndex, columnIndex)
                Else
                    If OldValueStr & value = Me.dgvChamber.Rows(rowIndex).Cells(columnIndex).ToolTipText Then
                        Me.dgvChamber.Rows(rowIndex).Cells(columnIndex).ToolTipText = ""
                        Me.dgvChamber.Rows(rowIndex).Cells(columnIndex).Style.ForeColor = Color.Black

                        UnSetDictionaryColor(rowIndex, columnIndex)
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2021-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Set Grid Color and tool-tip 
    ''' </summary>
    Private Sub SetOldToolTip()
        Try
            ReDim oldToolTip(dgvChamber.Rows.Count - 1, dgvChamber.Columns.Count - 1)
            ReDim oldToolTipText(dgvChamber.Rows.Count - 1, dgvChamber.Columns.Count - 1)
            For RowIndex As Integer = 0 To dgvChamber.Rows.Count - 1
                For ColumnIndex As Integer = 0 To dgvChamber.Columns.Count - 1
                    oldToolTip(RowIndex, ColumnIndex) = dgvChamber.Rows(RowIndex).Cells(ColumnIndex).Value.ToString
                    If dgvChamber.Rows(RowIndex).Cells(ColumnIndex).ToolTipText <> Nothing Then
                        oldToolTipText(RowIndex, ColumnIndex) = dgvChamber.Rows(RowIndex).Cells(ColumnIndex).ToolTipText
                    Else
                        oldToolTipText(RowIndex, ColumnIndex) = "Old Value: " + dgvChamber.Rows(RowIndex).Cells(ColumnIndex).ToolTipText
                    End If
                Next
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2021-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Set Grid Color and tool-tip 
    ''' </summary>
    Private Sub GetOldToolTip(ByVal ColumnIndex As Integer, ByVal past As Boolean)
        Try
            If past Then
                For RowIndextool As Integer = 0 To dgvChamber.Rows.Count - 1
                    For ColumnIndextool As Integer = 0 To dgvChamber.Columns.Count - 1
                        If oldToolTipText(RowIndextool, ColumnIndextool) <> "Old Value: " Then
                            If "Old Value: " + dgvChamber.Rows(RowIndextool).Cells(ColumnIndextool).Value.ToString <> oldToolTipText(RowIndextool, ColumnIndextool) Then
                                dgvChamber.Rows(RowIndextool).Cells(ColumnIndextool).ToolTipText = oldToolTipText(RowIndextool, ColumnIndextool)
                                dgvChamber.Rows(RowIndextool).Cells(ColumnIndextool).Style.ForeColor = Color.Red

                                SetDictionaryColor(RowIndextool, ColumnIndextool)
                            Else
                                dgvChamber.Rows(RowIndextool).Cells(ColumnIndextool).ToolTipText = Nothing
                                dgvChamber.Rows(RowIndextool).Cells(ColumnIndextool).Style.ForeColor = Color.Black

                                UnSetDictionaryColor(RowIndextool, ColumnIndextool)
                            End If
                        Else
                            If oldToolTip(RowIndextool, ColumnIndextool) <> dgvChamber.Rows(RowIndextool).Cells(ColumnIndextool).Value.ToString Then
                                dgvChamber.Rows(RowIndextool).Cells(ColumnIndextool).ToolTipText = "Old Value: " + oldToolTip(RowIndextool, ColumnIndextool)
                                dgvChamber.Rows(RowIndextool).Cells(ColumnIndextool).Style.ForeColor = Color.Red

                                SetDictionaryColor(RowIndextool, ColumnIndextool)
                            Else
                                dgvChamber.Rows(RowIndextool).Cells(ColumnIndextool).ToolTipText = Nothing
                                dgvChamber.Rows(RowIndextool).Cells(ColumnIndextool).Style.ForeColor = Color.Black

                                UnSetDictionaryColor(RowIndextool, ColumnIndextool)
                            End If
                        End If
                    Next
                Next
            Else
                Dim tooltipInsert(oldToolTip.GetLength(0) - 1, oldToolTip.GetLength(1)) As String
                Dim tooltiptextInsert(oldToolTip.GetLength(0) - 1, oldToolTip.GetLength(1)) As String
                For ColumnIndextool As Integer = 0 To oldToolTip.GetLength(1)
                    For RowIndextool As Integer = 0 To oldToolTip.GetLength(0) - 1
                        If ColumnIndextool < ColumnIndex Then
                            tooltipInsert(RowIndextool, ColumnIndextool) = oldToolTip(RowIndextool, ColumnIndextool)
                            tooltiptextInsert(RowIndextool, ColumnIndextool) = oldToolTipText(RowIndextool, ColumnIndextool)
                        ElseIf ColumnIndextool = ColumnIndex Then
                            tooltipInsert(RowIndextool, ColumnIndextool) = Nothing
                            tooltiptextInsert(RowIndextool, ColumnIndextool) = "Old Value: "
                        Else
                            tooltipInsert(RowIndextool, ColumnIndextool) = oldToolTip(RowIndextool, ColumnIndextool - 1)
                            tooltiptextInsert(RowIndextool, ColumnIndextool) = oldToolTipText(RowIndextool, ColumnIndextool - 1)
                        End If

                    Next
                Next

                ReDim oldToolTip(tooltipInsert.GetLength(0) - 1, tooltipInsert.GetLength(1) - 1)
                ReDim oldToolTipText(tooltipInsert.GetLength(0) - 1, tooltipInsert.GetLength(1) - 1)
                oldToolTip = tooltipInsert
                oldToolTipText = tooltiptextInsert
                'Set old tooltiptext for dgvChamber
                For RowIndextool As Integer = 0 To dgvChamber.Rows.Count - 1
                    For ColumnIndextool As Integer = 0 To dgvChamber.Columns.Count - 1

                        If oldToolTipText(RowIndextool, ColumnIndextool) <> "Old Value: " Then
                            dgvChamber.Rows(RowIndextool).Cells(ColumnIndextool).ToolTipText = oldToolTipText(RowIndextool, ColumnIndextool)
                            dgvChamber.Rows(RowIndextool).Cells(ColumnIndextool).Style.ForeColor = Color.Red

                            SetDictionaryColor(RowIndextool, ColumnIndextool)
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub DeleteToolTip(ByVal ColumnIndex As Integer)
        Try
            Dim tooltiptextInsert(oldToolTip.GetLength(0) - 1, oldToolTip.GetLength(1) - 2) As String
            For ColumnIndextool As Integer = 0 To oldToolTip.GetLength(1) - 2
                For RowIndextool As Integer = 0 To oldToolTip.GetLength(0) - 1
                    If ColumnIndextool < ColumnIndex Then
                        tooltiptextInsert(RowIndextool, ColumnIndextool) = oldToolTipText(RowIndextool, ColumnIndextool)
                    Else
                        tooltiptextInsert(RowIndextool, ColumnIndextool) = oldToolTipText(RowIndextool, ColumnIndextool + 1)
                    End If

                Next
            Next

            ClearDictionaryColor()

            ReDim oldToolTipText(tooltiptextInsert.GetLength(0) - 1, tooltiptextInsert.GetLength(1) - 1)
            oldToolTipText = tooltiptextInsert
            'Set old tooltiptext for dgvChamber
            For RowIndextool As Integer = 0 To dgvChamber.Rows.Count - 1
                For ColumnIndextool As Integer = 0 To dgvChamber.Columns.Count - 1
                    If oldToolTipText(RowIndextool, ColumnIndextool) <> "Old Value: " Then
                        dgvChamber.Rows(RowIndextool).Cells(ColumnIndextool).ToolTipText = oldToolTipText(RowIndextool, ColumnIndextool)
                        dgvChamber.Rows(RowIndextool).Cells(ColumnIndextool).Style.ForeColor = Color.Red

                        SetDictionaryColor(RowIndextool, ColumnIndextool)
                    End If
                Next
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
