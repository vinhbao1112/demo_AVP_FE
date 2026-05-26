Imports AVPLib
Imports AVPLib.ConstEnum
Imports AVPControls

''' <author>Hai Tran</author>
''' <date>2017-10-05</date>
''' <summary>
''' Step recipe editor.
''' </summary>
Public Class ReworkSequenceEditor

#Region "Fields"

    Private Const RectWidth As Integer = 316
    Private Const RectHeight As Integer = 50
    Private Const RectSpace As Integer = 10
    Private Const Total_Columns As Integer = 9
    Private Const strCellTitle As String = "processstartpressure"

    Private _oldSequenceName As String
    Private _lastOpenRecipePM As String
    Private _hstOfParamValue As Hashtable
    Private _hstDisplayParam As New Hashtable
    Private _curTotalStep As Int16 = 1
    Private _columnIndex As Integer = 0
    Private _rowIndex As Integer = 0
    Private _suffixName As String = String.Empty
    Private _isModified As Boolean
    Private _recipeName As String
    Private _waferFlowName As String
    Private _waferFlow As AVPLib.DataManagerment.WaferFlow
    Private _selectedStepIndex As Integer = -1
    Private _sequenceObject As DBWaferList
    Private _selectedRecipeStepColumnIndex As Integer = -1
    Private _waferFlowNames As List(Of String)
    Private m_MouseClicked As MouseClicked

#End Region

#Region "Constructor"

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Step recipe editor.
    ''' </summary>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' Do not allow form to be closed when click outside.
        AllowAutoClose = False

        cbxUseAligner.Visible = AVPLib.RobotConfigurationValues.ALINER_VISIBLE
        cbAlignRecipes.Visible = AVPLib.RobotConfigurationValues.ALINER_VISIBLE
        Dim alignRecipes As ArrayList = AVPLib.ContainerData.GetRecipe(Equipments.Aligner.ToString()).ListChamber
        cbAlignRecipes.DataSource = alignRecipes

        _waferFlow = Nothing
        _waferFlowName = String.Empty
        _recipeName = String.Empty

        picShowWaferFlow.HorizontalScroll.Enabled = False

    End Sub

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Gets or sets old sequence name.
    ''' </summary>
    Public Property OldSequenceName() As String
        Get
            Return _oldSequenceName
        End Get
        Set(ByVal value As String)
            _oldSequenceName = value
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Gets new sequence name.
    ''' </summary>
    Public ReadOnly Property NewSequenceName() As String
        Get
            Return GetReworkName(_oldSequenceName)
        End Get
    End Property

#End Region

#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Load wafer flow.
    ''' </summary>
    Private Sub ReworkSequenceEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            _waferFlowNames = GetWFName(OldSequenceName)
            cbWaferFlows.DataSource = _waferFlowNames

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Load wafer flow.
    ''' </summary>
    Private Sub LoadWaferFlow(ByVal wfName As String)
        Try
            Dim wfFlow As AVPLib.DataManagerment.WaferFlow = AVPLib.ContainerData.GetWaferFlowbyName(wfName)
            If wfFlow Is Nothing Then
                Utils.ShowAVPMessageBox("Wafer flow """ & wfName & """ does not exist.", Text, MessageBoxIcon.Error, MessageBoxButtons.OK)
                Return
            End If

            _waferFlowName = wfName
            _waferFlow = wfFlow
            _isModified = False
            picShowWaferFlow.Controls.Clear()
            dgvRecipe.Columns.Clear()
            SelectAlignerRecipe()

            Dim intHeight As Integer = 0
            Dim bmpHeight As Integer = (wfFlow.StepList.Count) * (RectSpace + RectHeight) + RectHeight / 2

            'Dim bmp As Image = New Bitmap(RectWidth + 50, bmpHeight)
            'Dim g As Graphics = Graphics.FromImage(bmp)
            Dim intLoopEnd As Integer = 0

            Dim ListOfStep As New List(Of String)
            Dim ListOfStation As New List(Of String)

            'don't have Loop
            If wfFlow.LoopList.Count <= 0 Then
                For Each wfStep As AVPLib.DataManagerment.WaferflowStep In wfFlow.StepList
                    ListOfStep.Add(wfStep.RecipeName)
                    ListOfStation.Add(wfStep.StationList.Item(0))
                    intLoopEnd += 1
                Next
                DrawWaferFlow(ListOfStep, ListOfStation, intHeight)
            ElseIf wfFlow.LoopList.Count < wfFlow.StepList.Count Then
                'if waferflow has step before loop
                Dim wfLoop As AVPLib.DataManagerment.WaferflowLoop = wfFlow.LoopList.Item(0)
                If wfFlow.StepList.Item(wfLoop.LoopStart) IsNot wfFlow.StepList.Item(0) Then
                    For i As Integer = 0 To wfLoop.LoopStart - 1
                        Dim wfstep As AVPLib.DataManagerment.WaferflowStep = wfFlow.StepList.Item(i)
                        ListOfStep.Add(wfstep.RecipeName)
                        ListOfStation.Add(wfstep.StationList.Item(0))
                    Next
                    DrawWaferFlow(ListOfStep, ListOfStation, intHeight)
                    intHeight -= 20
                End If
            End If

            For Each wfLoop As AVPLib.DataManagerment.WaferflowLoop In wfFlow.LoopList
                Dim LoopStart As Integer = wfLoop.LoopStart
                Dim LoopEnd As Integer = wfLoop.LoopEnd
                Dim LoopCount As Integer = wfLoop.LoopCount

                ListOfStep.Clear()
                ListOfStation.Clear()
                For loopCountIndex As Integer = 0 To wfLoop.LoopCount - 1
                    For j As Integer = LoopStart To LoopEnd
                        ListOfStep.Add(CType(wfFlow.StepList.Item(j), AVPLib.DataManagerment.WaferflowStep).RecipeName)
                        ListOfStation.Add(CType(wfFlow.StepList.Item(j), AVPLib.DataManagerment.WaferflowStep).StationList.Item(0))
                    Next 'draw loop with step
                Next
                DrawWaferFlow(ListOfStep, ListOfStation, intHeight, LoopCount)
                intHeight -= 25
                intLoopEnd = LoopEnd
            Next
            'if waferflow has more step
            If intLoopEnd < wfFlow.StepList.Count - 1 Then
                ListOfStep.Clear()
                ListOfStation.Clear()
                For k As Integer = intLoopEnd + 1 To wfFlow.StepList.Count - 1
                    ListOfStep.Add(CType(wfFlow.StepList.Item(k), AVPLib.DataManagerment.WaferflowStep).RecipeName)
                    ListOfStation.Add(CType(wfFlow.StepList.Item(k), AVPLib.DataManagerment.WaferflowStep).StationList.Item(0))
                Next
                DrawWaferFlow(ListOfStep, ListOfStation, intHeight)
            End If

            'Me.picShowWaferFlow.Image = bmp
            'Me.picShowWaferFlow.Size = New Size(picShowWaferFlow.Width, intHeight + RectHeight)
            'g.Dispose()
            If picShowWaferFlow.VerticalScroll.Visible Then
                For Each controlItem As Control In picShowWaferFlow.Controls
                    controlItem.Width = controlItem.Width - SystemInformation.VerticalScrollBarWidth - 3
                Next
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-11</date>
    ''' <summary>
    ''' Gets wafer flow name from sequence.
    ''' </summary>
    Private Function GetWFName(ByVal segName As String) As List(Of String)
        Dim names As New List(Of String)
        Try
            Dim filename As String = AVPLib.ContainerDAO.FPath_SequenceData & "\" & segName & ".xml"
            Dim strDescription As String = String.Empty

            If Not AVPLib.ContainerData.GetSequence(filename, _sequenceObject, strDescription) Then
                Exit Try
            End If

            For Each item As AVPLib.DBWaferSlot In _sequenceObject.WaferList
                If Not String.IsNullOrEmpty(item.WaferSequence.SeqName) AndAlso Not names.Contains(item.WaferSequence.SeqName) Then
                    names.Add(item.WaferSequence.SeqName)
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return names
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Draw wafer flow to GUI.
    ''' </summary>
    Private Sub DrawWaferFlow(ByVal listOfStep As List(Of String), ByVal ListOfStation As List(Of String), _
                                  ByRef intTotalHeight As Integer, Optional ByVal strStepLoop As String = "")
        Try
            Dim rectLeft As Integer = 0
            Dim lineWidth As Integer = 20
            Dim y As Integer = intTotalHeight
            Dim nodeWidth As Integer = picShowWaferFlow.Width

            For i As Integer = 0 To listOfStep.Count - 1
                Dim chamberName As String = AVPLib.Utils.chamberID2ChamberName(ListOfStation.Item(i))
                Dim recipeName As String = listOfStep.Item(i)

                Dim displayName As String = "[" & chamberName & "] - " & recipeName
                If (ListOfStation.Item(i) = AVPLib.RobotConfigurationValues.ANY_IBE_CHAMBER) Then
                    displayName = "[AnyIBE] - " & recipeName
                End If

                Dim node As New WaferFlowNodeControl()
                node.Name = chamberName & "-" & recipeName
                node.NodeText = displayName
                node.Tag = recipeName
                node.AccessibleDescription = chamberName
                node.Location = New Point(rectLeft, y + i * (RectHeight + RectSpace))
                node.Width = nodeWidth

                If chamberName <> AVPLib.ConstEnum.Equipments.Aligner.ToString() Then
                    AddHandler node.Click, AddressOf Item_Click
                    node.Cursor = Cursors.Hand
                Else
                    node.BackColor = Color.LightGray
                End If

                picShowWaferFlow.Controls.Add(node)
            Next

            intTotalHeight = (listOfStep.Count) * (RectSpace + RectHeight) + RectHeight / 2 + y
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Click event for wafer flow item.
    ''' </summary>
    Private Sub Item_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim node As WaferFlowNodeControl = DirectCast(sender, WaferFlowNodeControl)
            If node.IsSelected Then
                Return
            End If

            If _isModified OrElse IsRecipeStepListModified() Then
                Dim dialogResult As DialogResult = Utils.ShowAVPMessageBox("Recipe """ & _recipeName & """ is modified. Would you like to cancel modifications?", _
                    Text, MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.YesNo)
                If dialogResult = Windows.Forms.DialogResult.Cancel Then
                    Return
                End If
            End If

            _isModified = False
            node.IsSelected = True
            _selectedStepIndex = picShowWaferFlow.Controls.IndexOf(node)

            For Each item As Control In picShowWaferFlow.Controls
                Dim nodeItem As WaferFlowNodeControl = DirectCast(item, WaferFlowNodeControl)
                If nodeItem IsNot Nothing AndAlso Not ReferenceEquals(nodeItem, node) Then
                    nodeItem.IsSelected = False
                End If
            Next

            _recipeName = node.Tag
            lblNewRecipeName.Text = node.Tag

            LoadDataGrid(_recipeName, node.AccessibleDescription)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Cancel button.
    ''' </summary>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        DoClose()
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Clear grid.
    ''' </summary>
    Private Sub ClearGrid()
        Me.dgvRecipe.Columns.Clear()
        Me.dgvRecipe.DataSource = Nothing
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Load recipe to grid.
    ''' </summary>
    Public Sub LoadDataGrid(ByVal recipeName As String, Optional ByVal strChamberName As String = "")
        Try
            ClearGrid()
            If String.IsNullOrEmpty(_lastOpenRecipePM) Then
                _lastOpenRecipePM = AVPLib.Utils.chamberName2ChamberID(strChamberName)
            End If
            Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(_lastOpenRecipePM)
            Dim chamberModule As AVPLib.SystemModule = Nothing
            AVPLib.ContainerData.IsChamberVisible(ChamberName, chamberModule)

            Dim recipe As AVPLib.DBRecipe = AVPLib.ContainerData.GetRecipe(ChamberName)
            If recipe Is Nothing Then
                Return
            End If

            Dim recipePrivilege As AVPLib.DBChamber = Nothing
            If (AVPLib.ContainerData.UserLogin IsNot Nothing) Then
                recipePrivilege = AVPLib.ContainerData.UserLogin.ListOfDBChamber(chamberModule.Type.ToString() & "." & ChamberName)
            End If

            Dim selectedRecipe As AVPLib.DBChamber = AVPLib.ContainerData.Chamber(ChamberName, AVPLib.Utils.GetFileName(recipeName, "xml"))

            _hstOfParamValue = ListOfParamComboBox(selectedRecipe)
            selectedRecipe = ConvertToRealValue(selectedRecipe, True)

            selectedRecipe.ChamberType = chamberModule.Type.ToString()

            Dim dt As DataTable = AVPLib.ContainerData.ChamberDB(selectedRecipe, AVPLib.ContainerData.ChamberPVDType(ChamberName))

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
                    Me._curTotalStep = 0
                Else
                    Column.Width = 135
                    Me._curTotalStep += 1
                    Column.HeaderCell = New DataGridViewCheckBoxHeaderCell()
                End If
                Me.dgvRecipe.Columns.Add(Column)
                If AVPLib.Utils.IsHiddenColumn(dc.ColumnName) Then
                    Column.Visible = False
                    Me._curTotalStep -= 1
                End If
            Next

            If Me.dgvRecipe.Columns.Count > 0 Then ''Freezing first column
                Me.dgvRecipe.Columns(0).Frozen = True
            End If

            Me.dgvRecipe.DataSource = dt

            For i As Integer = 0 To dgvRecipe.Columns.Count - 1
                If dgvRecipe.Columns.Item(i).Visible AndAlso TypeOf dgvRecipe.Columns.Item(i).HeaderCell Is DataGridViewCheckBoxHeaderCell Then
                    Dim headerCell As DataGridViewCheckBoxHeaderCell = DirectCast(dgvRecipe.Columns.Item(i).HeaderCell, DataGridViewCheckBoxHeaderCell)

                    AddHandler headerCell.CheckChanged, AddressOf HeaderCheckBox_CheckChanged
                End If
            Next

            Const kDefaultValue As String = "DefaultValue"
            Const kParameterName As String = "ParameterName"
            Const kBelongToGroup As String = "BelongToGroup"

            Dim dictionaryRowDisable As New Dictionary(Of Integer, ArrayList)
            Dim dictionaryRowCalculate As New Dictionary(Of String, String)
            Dim seqNo As Integer = 0
            Dim nRow As Integer = 0
            Dim nRowVisible As Integer = 0
            Dim arrRowDisable As New ArrayList
            Dim objCurrencyManager As CurrencyManager = Nothing

            If dgvRecipe.DataSource IsNot Nothing Then
                objCurrencyManager = CType(BindingContext(dgvRecipe.DataSource), CurrencyManager)
                objCurrencyManager.SuspendBinding()
            End If

            For Each drMerge As DataRow In dt.Rows
                If drMerge(kDefaultValue).ToString().Length = 0 AndAlso drMerge("BelongToGroup").ToString().Length = 0 Then ' This is a Group row.
                    Dim nColumnView As Integer = Me.dgvRecipe.Columns.GetColumnCount(DataGridViewElementStates.Visible)
                    Dim nColumn As Integer = 1
                    For Each Column As DataGridViewTextBoxColumn In Me.dgvRecipe.Columns
                        If Column.Visible = True Then
                            Me.dgvRecipe.Rows(nRow).ReadOnly = True
                            Me.dgvRecipe.Rows(nRow).Cells(Column.Name) = New HMergedCell()
                            Dim pCell As HMergedCell = DirectCast(Me.dgvRecipe.Rows(nRow).Cells(Column.Name), HMergedCell)
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
                        For Each Column As DataGridViewTextBoxColumn In Me.dgvRecipe.Columns
                            If Column.Visible = True AndAlso nColumn >= 1 Then
                                'Disable
                                Dim str As String = listOfSeqNoDisable.Item(Me.dgvRecipe.Rows(nRow).Cells(nColumn).Value)
                                If str IsNot Nothing Then
                                    Dim arr As Array = str.Split(STR_COMMA)
                                    For i As Integer = 0 To arr.Length - 1
                                        Dim rowDisable As Integer = AVPLib.Utils.GetRowIndex(arr(i), _lastOpenRecipePM, nRow, seqNo, dt)
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
                                    Dim strCal As String = listOfSeqNoCalculate.Item(Me.dgvRecipe.Rows(nRow).Cells(nColumn).Value)
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
                    If Me.dgvRecipe.Rows(nRow).Cells(0).Value.ToString().ToLower().Replace("_", "").Replace(" ", "").Contains(strCellTitle) Then
                        For iCol As Int32 = Total_Columns To Me.dgvRecipe.Rows(nRow).Cells.Count - 1
                            Me.dgvRecipe.Rows(nRow).Cells(iCol).Value = Me.FormatNumber(Me.dgvRecipe.Rows(nRow).Cells(iCol).Value)
                        Next
                    End If

                    If (recipePrivilege IsNot Nothing) Then
                        Dim recParameter As AVPLib.DBParameter = recipePrivilege.GetParameter(GroupCode, ParameterName)
                        If (recParameter IsNot Nothing) Then
                            ' Applying Recipe Privilege.
                            If (Not recParameter.ReadWrite) Then
                                Me.dgvRecipe.Rows(nRow).ReadOnly = True
                            End If
                        End If
                    End If
                End If

                'apply recipe param show or not show
                Dim blnIsVisible As Boolean = Utils.CheckParamRecipeReworkVisible(dgvRecipe.Rows(nRow).Cells(1).Value.ToString(), dgvRecipe.Rows(nRow).Cells(5).Value.ToString(), ChamberName)
                dgvRecipe.Rows(nRow).Visible = blnIsVisible

                If blnIsVisible Then
                    If (nRowVisible Mod 2) = 0 Then
                        Me.dgvRecipe.Rows(nRow).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Window)
                    Else
                        Me.dgvRecipe.Rows(nRow).DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255)
                    End If
                    nRowVisible += 1

                    If dgvRecipe.Rows(nRow).Cells(1).Value.ToString() = "StepDescription" AndAlso dgvRecipe.Rows(nRow).Cells(5).Value.ToString() = "StepDescription" Then
                        dgvRecipe.Rows(nRow).ReadOnly = True
                    End If
                End If

                nRow += 1
            Next

            If objCurrencyManager IsNot Nothing AndAlso objCurrencyManager.IsBindingSuspended Then
                objCurrencyManager.ResumeBinding()
            End If

            Me.dgvRecipe.AllowUserToResizeRows = False
            arrRowDisable.Clear()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Handles header check box.
    ''' </summary>
    Private Sub HeaderCheckBox_CheckChanged(ByVal sender As Object, ByVal e As CheckChangedEventArgs)
        Try
            Dim column As DataGridViewColumn = dgvRecipe.Columns.Item(e.ColumnIndex)
            If e.Checked Then
                Dim nextColumn As DataGridViewColumn = Nothing
                If e.ColumnIndex < dgvRecipe.Columns.Count - 1 Then
                    nextColumn = dgvRecipe.Columns.Item(e.ColumnIndex + 1)
                End If
                If nextColumn IsNot Nothing AndAlso nextColumn.Visible Then
                    If TypeOf nextColumn.HeaderCell Is DataGridViewCheckBoxHeaderCell Then
                        Dim headerCell As DataGridViewCheckBoxHeaderCell = DirectCast(nextColumn.HeaderCell, DataGridViewCheckBoxHeaderCell)
                        If Not headerCell.Checked Then
                            headerCell.Checked = True
                        End If
                    End If
                End If
            Else
                Dim previousColumn As DataGridViewColumn = Nothing
                If e.ColumnIndex > 0 Then
                    previousColumn = dgvRecipe.Columns.Item(e.ColumnIndex - 1)
                End If
                If previousColumn IsNot Nothing AndAlso previousColumn.Visible Then
                    If TypeOf previousColumn.HeaderCell Is DataGridViewCheckBoxHeaderCell Then
                        Dim headerCell As DataGridViewCheckBoxHeaderCell = DirectCast(previousColumn.HeaderCell, DataGridViewCheckBoxHeaderCell)
                        If headerCell.Checked Then
                            headerCell.Checked = False
                        End If
                    End If
                End If
            End If

            For Each row As DataGridViewRow In dgvRecipe.Rows
                If e.Checked Then
                    If row.Cells(e.ColumnIndex).Tag <> ConstEnum.STR_DISABLE Then
                        row.Cells(e.ColumnIndex).Style = Nothing
                    End If
                Else
                    row.Cells(e.ColumnIndex).Style.BackColor = Color.DarkGray
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Format sciencific number
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

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Set cell to disable
    ''' </summary>
    Private Sub SetDisableCell(ByVal indexRowList As ArrayList, ByVal dictionaryRowDisable As Dictionary(Of Integer, ArrayList), ByVal dictionaryRowCalculate As Dictionary(Of String, String))
        Try
            Dim nRow As Integer
            For i As Integer = 0 To indexRowList.Count - 1
                nRow = indexRowList(i)
                If dictionaryRowDisable IsNot Nothing AndAlso dictionaryRowDisable.Count > 0 AndAlso dictionaryRowDisable.ContainsKey(nRow) Then
                    Dim arrList As ArrayList = dictionaryRowDisable.Item(nRow)
                    For Each iColumn As Integer In arrList
                        'Disable
                        Me.dgvRecipe.Rows(nRow).Cells(iColumn).Style.BackColor = Color.DarkGray
                        Me.dgvRecipe.Rows(nRow).Cells(iColumn).Tag = ConstEnum.STR_DISABLE
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
                                        formula = formula.Replace(oldValue, Me.dgvRecipe.Rows(arrFormulaRow(k)).Cells(iColumn).Value)
                                    End If
                                Next
                                'in the case: divide 0, we just try...catch
                                Try
                                    If formula = "String.Empty" Then
                                        Me.dgvRecipe.Rows(nRow).Cells(iColumn).Value = String.Empty
                                    Else
                                        Dim valueAfterCalculate As Integer = AVPLib.Expression.Evaluate(formula, New Dictionary(Of String, Double)())
                                        If Me.dgvRecipe.Rows(nRow).Cells(iColumn).Value <> valueAfterCalculate Then
                                            Me.dgvRecipe.Rows(nRow).Cells(iColumn).Value = valueAfterCalculate
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

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Update value on hidden column.
    ''' </summary>
    Private Sub UpdateValueHideColumn(ByVal indexRowCal As Integer, ByVal rowDisable As Integer)
        Dim rowHideCal As String = Me.dgvRecipe.Rows(indexRowCal).Cells("ParameterCalculate").Value
        If Not rowHideCal.Contains(rowDisable.ToString) Then
            If String.IsNullOrEmpty(rowHideCal) Then
                rowHideCal = rowDisable
            Else
                rowHideCal = rowHideCal & STR_COMMA & rowDisable
            End If
            Me.dgvRecipe.Rows(indexRowCal).Cells("ParameterCalculate").Value = rowHideCal
        End If
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Convert value.
    ''' </summary>
    Private Function ConvertToRealValue(ByVal selectedRecipe As AVPLib.DBChamber, ByVal blnLoadFromFile As Boolean) As AVPLib.DBChamber
        Try
            For Each item As AVPLib.DBChamberStep In selectedRecipe.ListChamberSteps
                For Each param As AVPLib.DBGroupParameterValue In item.ListGroupParameterValues
                    For Each paramval As AVPLib.DBParameterValue In param.ListParameterValues
                        '2014-03-17 Tin Pham: key = PVD.PowerDown, PVD6S.PowerDown, ...
                        Dim keyParamvalName As String = selectedRecipe.ChamberType & "." & paramval.Name
                        If _hstDisplayParam.Contains(keyParamvalName) And Not blnLoadFromFile Then
                            Dim realVal As KeyValuePair(Of String, String) = Nothing
                            For Each realVal In _hstDisplayParam(keyParamvalName)
                                If realVal.Key = paramval.Value Then
                                    paramval.Value = realVal.Value
                                End If
                            Next
                        ElseIf _hstDisplayParam.Contains(keyParamvalName) Then
                            Dim realVal As KeyValuePair(Of String, String) = Nothing
                            For Each realVal In _hstDisplayParam(keyParamvalName)
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

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Gets list parameters.
    ''' </summary>
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
                        If Not (_hstDisplayParam.Contains(keyParamName)) Then
                            _hstDisplayParam.Add(keyParamName, param.DisplayItems)
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

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Handles datagrid mouse down.
    ''' </summary>
    Private Sub RecipeGrid_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvRecipe.MouseDown
        AVPLib.Log.guiLogger.Info("Enter RecipeGrid_MouseDown")
        Try
            _columnIndex = dgvRecipe.HitTest(e.X, e.Y).ColumnIndex
            _rowIndex = dgvRecipe.HitTest(e.X, e.Y).RowIndex

            If (_columnIndex > (Total_Columns - 1)) And (_rowIndex >= 0) AndAlso Me.dgvRecipe.Rows(_rowIndex).ReadOnly = False Then
                'SetButtonEnableDisable(True)
                Dim dt As DataTable = CType(Me.dgvRecipe.DataSource, DataTable)
                Dim dr As DataRow = dt.Rows(_rowIndex)
                Dim ParameterName As String = dr("Parameters").ToString()
                Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(_lastOpenRecipePM)
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

                    If _rowIndex >= 0 And _rowIndex <= (dt.Rows.Count - 1) Then
                        '2013-07-12 Tin Pham: can't click on cell is disable
                        If Me.dgvRecipe.Rows(_rowIndex).Cells(_columnIndex).Tag = ConstEnum.STR_DISABLE Then
                            Exit Try
                        End If
                        '---------------------------------------------------
                        Me.dgvRecipe.Item(_columnIndex, _rowIndex).Selected = True
                        Me.dgvRecipe.Item(_columnIndex, _rowIndex).ReadOnly = True
                        ctxMenu.Show(dgvRecipe, New Point(e.X, e.Y))
                    End If
                Else 'displayitems is nothing
                    If (Me.dgvRecipe.Rows(_rowIndex).Cells("Unit").Value.ToString().Contains("String")) AndAlso Me.dgvRecipe.Rows(_rowIndex).ReadOnly = False Then
                        '2013-07-12 Tin Pham: can't click on cell is disable
                        If Me.dgvRecipe.Rows(_rowIndex).Cells(_columnIndex).Tag = ConstEnum.STR_DISABLE Then
                            Exit Try
                        End If
                        '---------------------------------------------------
                        Dim frm As New KeyPad
                        dt = CType(Me.dgvRecipe.DataSource, DataTable)
                        dr = dt.Rows(_rowIndex)

                        Dim value As String = Me.dgvRecipe.Rows(_rowIndex).Cells(_columnIndex).Value

                        If frm.DisplayKeypad(value, "Enter your text", False) = DialogResult.OK Then
                            SetGridStyle(value, _rowIndex, _columnIndex)
                            If Me.dgvRecipe.Rows(_rowIndex).Cells(_columnIndex).Value <> value Then
                                _isModified = True
                            End If
                            Me.dgvRecipe.Rows(_rowIndex).Cells(_columnIndex).Value = value
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave RecipeGrid_MouseDown")
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Handles datagrid cell click.
    ''' </summary>
    Private Sub RecipeGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRecipe.CellClick
        AVPLib.Log.guiLogger.Info("Enter txtCG2_Click")
        Try
            If e.ColumnIndex > 0 And e.RowIndex >= 0 AndAlso _
                (Me.dgvRecipe.Rows(e.RowIndex).Cells("Unit").Value.ToString().Contains("Number")) AndAlso Me.dgvRecipe.Rows(e.RowIndex).ReadOnly = False Then
                '2013-07-12 Tin Pham: can't click on cell is disable
                If Me.dgvRecipe.Rows(e.RowIndex).Cells(e.ColumnIndex).Tag = ConstEnum.STR_DISABLE Then
                    Exit Try
                End If

                If TypeOf dgvRecipe.Columns(e.ColumnIndex).HeaderCell Is DataGridViewCheckBoxHeaderCell Then
                    Dim headerCell As DataGridViewCheckBoxHeaderCell = CType(dgvRecipe.Columns(e.ColumnIndex).HeaderCell, DataGridViewCheckBoxHeaderCell)
                    If Not headerCell.Checked Then
                        Exit Try
                    End If
                End If

                '---------------------------------------------------
                Dim frm As New NumPad
                Dim dt As DataTable = CType(Me.dgvRecipe.DataSource, DataTable)
                Dim dr As DataRow = dt.Rows(e.RowIndex)

                Dim Min As Double = CDbl(dr("ParameterMin"))
                Dim Max As Double = CDbl(dr("ParameterMax"))

                '#23/08/2011 
                '#- Get min/max from db chamber to can show min/max rightly when datagrid is not updated.
                '#Begin fix.
                GetMinMaxFromDBChamber(dr("ParameterName"), dr("BelongToGroup"), Min, Max)
                '#End fix

                Dim value As String = Me.dgvRecipe.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                'Dim strUnit As String = Me.dgvRecipe.Rows(e.RowIndex).Cells(0).Value.ToString().Replace(Me.dgvRecipe.Rows(e.RowIndex).Cells(1).Value.ToString(), "")
                Dim strUnit As String = Me.dgvRecipe.Rows(e.RowIndex).Cells(0).Value.ToString()

                Dim InputRes As MsgBoxResult = frm.GetUserInput(value, -1, -1, Min, Max, "Enter your value - " & strUnit)

                ' Save Max & Min
                If frm.IsMaxMinModified Then
                    Me.SaveMinMaxParameter(dr("BelongToGroup"), dr("ParameterName"), frm.NewMin, frm.NewMax)
                    dr("ParameterMin") = frm.NewMin
                    dr("ParameterMax") = frm.NewMax
                    AVPLib.Utils.UpdateMinMaxRecipe(dgvRecipe.Rows(e.RowIndex).Cells(5).Value.ToString(), dgvRecipe.Rows(e.RowIndex).Cells(1).Value.ToString(), frm.NewMin, frm.NewMax, _lastOpenRecipePM)
                    Utils.SynchronizeMinMaxValueToPMScreen(dr("ParameterName"), _lastOpenRecipePM, frm.NewMin.ToString(), frm.NewMax.ToString(), dr("BelongToGroup"))
                End If

                If InputRes = MsgBoxResult.Ok Then
                    SetGridStyle(value, e.RowIndex, e.ColumnIndex)
                    Dim sValue As String = value
                    ' 2015-06-25: Hoai Ly update pressure format
                    If Me.dgvRecipe.Rows(e.RowIndex).Cells(0).Value.ToString().ToLower().Replace("_", "").Replace(" ", "").Contains(strCellTitle) Then
                        sValue = FormatNumber(value)
                    End If
                    If sValue <> Me.dgvRecipe.Rows(e.RowIndex).Cells(e.ColumnIndex).Value Then
                        _isModified = True
                    End If

                    Me.dgvRecipe.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = sValue

                    ''0008267: [KhoiHa - 08/28/2015]When user input power or voltage > 0, sub. Ground should be switch to no by default
                    'Dim dbValue As Double = 0
                    'Double.TryParse(value, dbValue)
                    'If dr("ParameterName") = "BiasPower" AndAlso dbValue > 0 Then
                    '    Me.dgvRecipe.Rows(e.RowIndex + 2).Cells(e.ColumnIndex).Value = "No"
                    'End If

                    'If dr("ParameterName") = "BiasVoltage" AndAlso dbValue > 0 Then
                    '    Me.dgvRecipe.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value = "No"
                    'End If

                    '2013-07-19 Tin Pham Modified
                    Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(_lastOpenRecipePM)
                    Dim seqNo As Integer = 0
                    Dim strCal As String = Me.dgvRecipe.Rows(e.RowIndex).Cells("ParameterCalculate").Value
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
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txtCG2_Click")
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-25</date>
    ''' <summary>
    ''' Handles context menu click.
    ''' </summary>
    Private Sub ctxMenu_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ctxMenu.ItemClicked
        AVPLib.Log.guiLogger.Info("Enter CMenuCmbClick")
        Try
            Dim dt As DataTable = CType(Me.dgvRecipe.DataSource, DataTable)

            '2013-07-19 Tin Pham modified: disable cell, calculate for cell
            If dt.Rows(_rowIndex)(_columnIndex) <> e.ClickedItem.Text Then
                EnableDisableAndCalculateForCell(dt, e.ClickedItem.Text)
            End If
            'End -----------------------------------------------------------------------------------------------

            SetGridStyle(e.ClickedItem.Text, _rowIndex, _columnIndex)
            dt.Rows(_rowIndex)(_columnIndex) = e.ClickedItem.Text
            _isModified = True
            Me.dgvRecipe.Refresh()

            m_MouseClicked = MouseClicked.DataRowClicked
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CMenuCmbClick")
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-25</date>
    ''' <summary>
    ''' Enable/Disable parameters.
    ''' </summary>
    Private Sub EnableDisableAndCalculateForCell(ByVal dt As DataTable, ByVal keyRow As String)
        Try
            Const kParameterName As String = "ParameterName"
            Const kBelongToGroup As String = "BelongToGroup"
            Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(_lastOpenRecipePM)
            Dim seqNo As Integer = 0
            Dim GroupCode As String = dt.Rows(_rowIndex)(kBelongToGroup)
            Dim listOfSeqNoCalculate As New Hashtable
            Dim listOfSeqNoDisable As Hashtable = AVPLib.Utils.GetListOfSeqNoDisable(ChamberName, GroupCode, dt.Rows(_rowIndex)(kParameterName), seqNo, listOfSeqNoCalculate)
            If listOfSeqNoDisable IsNot Nothing AndAlso listOfSeqNoDisable.Count > 0 Then
                'enable previous cell
                Dim strListOfSeqNoDisable As String = listOfSeqNoDisable.Item(dt.Rows(_rowIndex)(_columnIndex))
                EnableDisableCell(strListOfSeqNoDisable, seqNo, Color.White, "")
                'disable current cell
                strListOfSeqNoDisable = listOfSeqNoDisable.Item(keyRow)
                EnableDisableCell(strListOfSeqNoDisable, seqNo, Color.DarkGray, STR_DISABLE)
                'calculate
                If listOfSeqNoCalculate IsNot Nothing AndAlso listOfSeqNoCalculate.Count > 0 Then
                    Dim formulaRow As String = listOfSeqNoCalculate.Item(keyRow)
                    CalculateCell(formulaRow, seqNo, _rowIndex)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-25</date>
    ''' <summary>
    ''' Enable/Disable cell.
    ''' </summary>
    Private Sub EnableDisableCell(ByVal strListOfSeqNoDisable As String, ByVal seqNo As Integer, _
                                      ByVal color As Color, ByVal strDisable As String)
        Try
            Dim arr As Array
            Dim idexRow As Integer = 0
            Dim dt As DataTable = CType(Me.dgvRecipe.DataSource, DataTable)
            If strListOfSeqNoDisable IsNot Nothing Then
                arr = strListOfSeqNoDisable.Split(STR_COMMA)
                For i As Integer = 0 To arr.Length - 1
                    Dim strSeq As String = arr(i).ToString()
                    If strSeq.Contains(":") Then
                        Dim strInfomationSeq As Array = strSeq.Split(":")
                        Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(_lastOpenRecipePM)
                        Dim strGroup As String = strInfomationSeq(0).ToString()
                        Dim strParameter As String = AVPLib.Utils.GetParameterFromGroupAndSeqNo(ChamberName, strGroup, strInfomationSeq(1).ToString())
                        For rowIndex As Integer = 0 To dt.Rows.Count - 1
                            If dt.Rows(rowIndex)("BelongToGroup") = strGroup AndAlso dt.Rows(rowIndex)("ParameterName") = strParameter Then
                                idexRow = rowIndex
                                Exit For
                            End If

                        Next
                    Else
                        idexRow = _rowIndex - seqNo + arr(i)
                    End If

                    If strDisable = "" Then
                        color = Me.dgvRecipe.Rows(idexRow).Cells("ParameterName").Style.BackColor
                        If Me.dgvRecipe.Rows(idexRow).Cells(_columnIndex).Value = String.Empty Then
                            Me.dgvRecipe.Rows(idexRow).Cells(_columnIndex).Value = dt.Rows(idexRow)("DefaultValue").ToString
                        End If
                    End If
                    Me.dgvRecipe.Rows(idexRow).Cells(_columnIndex).Style.BackColor = color
                    Me.dgvRecipe.Rows(idexRow).Cells(_columnIndex).Tag = strDisable
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Calculate cell value.
    ''' </summary>
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
                            formula = formula.Replace(oldValue, Me.dgvRecipe.Rows(idexRowCal).Cells(_columnIndex).Value)
                        End If
                    Next
                    'in the case: divide 0, we just try...catch
                    Try
                        Dim valueAfterCalculate As Integer = AVPLib.Expression.Evaluate(formula, New Dictionary(Of String, Double)())
                        Me.dgvRecipe.Rows(idexRow).Cells(_columnIndex).Value = valueAfterCalculate
                    Catch ex As Exception
                        AVPLib.Log.avpLogger.Error(ex.ToString())
                    End Try
                End If
            Next
        End If
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Gets min/max of parameter.
    ''' </summary>
    Private Function GetMinMaxFromDBChamber(ByVal parameterName As String, ByVal groupCode As String, ByRef min As Double, ByRef max As Double) As Boolean
        Dim result As Boolean = False

        Try
            Dim recipe As AVPLib.DBRecipe = AVPLib.ContainerData.GetRecipe(_lastOpenRecipePM)
            Dim recipeChamber As DBChamber = AVPLib.ContainerData.Chamber(_lastOpenRecipePM, recipe.ChamberNameActive)
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
            If min < 0 Then
                min = Math.Ceiling(min)
            Else
                min = Math.Round(min, MidpointRounding.AwayFromZero)
            End If

            If max < 0 Then
                max = Math.Ceiling(max)
            Else
                max = Math.Round(max, MidpointRounding.AwayFromZero)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return result
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Save min/max of parameter
    ''' </summary>
    Private Sub SaveMinMaxParameter(ByVal groupCode As String, ByVal paramName As String, ByVal Min As Single, ByVal Max As Single)
        AVPLib.Log.guiLogger.Info("Enter SaveMinMaxParameter")
        Try
            Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(_lastOpenRecipePM)
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

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Handles datagrid cell begin edit.
    ''' </summary>
    Private Sub RecipeGrid_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvRecipe.CellBeginEdit
        Dim columnName As String = dgvRecipe.Columns(e.ColumnIndex).HeaderText
        If columnName.StartsWith("Step") Then
            e.Cancel = True
        End If
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Handles datagrid cell enter.
    ''' </summary>
    Private Sub RecipeGrid_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRecipe.CellEnter
        Try
            Dim selected As Integer = Me.dgvRecipe.CurrentCell.RowIndex
            Dim dt As DataTable = CType(Me.dgvRecipe.DataSource, DataTable)
            Dim dr As DataRow = dt.Rows(selected)
            Dim ParameterName As String = dr("Parameters").ToString()
            Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(_lastOpenRecipePM)
            Dim DisplayItems As List(Of KeyValuePair(Of String, String)) = AVPLib.Utils.GetListOfDisplayItem(ChamberName, ParameterName)
            If DisplayItems IsNot Nothing Then
                Me.dgvRecipe.CurrentCell.ReadOnly = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-06</date>
    ''' <summary>
    ''' Returns a value indicating whether the recipe step is modified.
    ''' </summary>
    Private Function IsRecipeStepListModified() As Boolean
        Try
            If String.IsNullOrEmpty(_recipeName) Then
                Exit Try
            End If

            For Each column As DataGridViewColumn In dgvRecipe.Columns
                If column.Visible AndAlso TypeOf column.HeaderCell Is DataGridViewCheckBoxHeaderCell Then
                    Dim headerCell As DataGridViewCheckBoxHeaderCell = DirectCast(column.HeaderCell, DataGridViewCheckBoxHeaderCell)
                    If Not headerCell.Checked Then
                        Return True
                    End If
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-06</date>
    ''' <summary>
    ''' Returns a value indicates number of selected recipe step.
    ''' </summary>
    Private Function RecipeStepListModifiedCount() As Integer
        Dim count As Integer = 0
        Try
            If String.IsNullOrEmpty(_recipeName) Then
                Exit Try
            End If

            For Each column As DataGridViewColumn In dgvRecipe.Columns
                If column.Visible AndAlso TypeOf column.HeaderCell Is DataGridViewCheckBoxHeaderCell Then
                    Dim headerCell As DataGridViewCheckBoxHeaderCell = DirectCast(column.HeaderCell, DataGridViewCheckBoxHeaderCell)
                    If headerCell.Checked Then
                        count += 1
                    End If
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return count
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-06</date>
    ''' <summary>
    ''' OK action.
    ''' </summary>
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If picShowWaferFlow.Controls.Count = 0 Then
                Utils.ShowAVPMessageBox("Sequence does not have any wafer flow.", Text, MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                Exit Try
            End If

            If String.IsNullOrEmpty(_waferFlowName) Then
                Utils.ShowAVPMessageBox("Wafer flow is not selected.", Text, MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                Exit Try
            End If

            If _selectedStepIndex = -1 Then
                Utils.ShowAVPMessageBox("Please select a wafer flow step.", Text, MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                Exit Try
            End If

            If RecipeStepListModifiedCount() = 0 Then
                Utils.ShowAVPMessageBox("Recipe does not have any step.", Text, MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                Exit Try
            End If

            ' if find step have total gas flow is not total gas flow limit
            Dim totalGasFlowLimit As Double = AVPLib.ContainerDAO.TotalGasFlowLimit()
            Dim index As Integer = IIf(totalGasFlowLimit > 0, FindIndexGasBreakPoint(totalGasFlowLimit), -1)

            If index <> -1 Then
                Utils.ShowAVPMessageBox("Total Gas Flow Is Not " & totalGasFlowLimit.ToString() & " sccm", Text, MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                Exit Try
            End If

            If Not SaveRecipe() Then
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   "[Rework] Failed to save rework recipe: " & GetReworkName(_recipeName))

                Utils.ShowAVPMessageBox("Failed to save recipe """ & GetReworkName(_recipeName) & """.", Text, MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                Exit Try
            Else
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   "[Rework] Created rework recipe: " & GetReworkName(_recipeName))
            End If

            If Not SaveWaferFlow() Then
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   "[Rework] Failed to save rework wafer flow: " & GetReworkName(_waferFlowName))
                Utils.ShowAVPMessageBox("Failed to save wafer flow """ & GetReworkName(_waferFlowName) & """.", Text, MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                Exit Try
            Else
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   "[Rework] Created rework wafer flow: " & GetReworkName(_waferFlowName))
            End If

            If Not SaveSequence() Then
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   "[Rework] Failed to save rework sequence: " & NewSequenceName)
                Utils.ShowAVPMessageBox("Failed to save sequence """ & NewSequenceName & """.", Text, MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                Exit Try
            Else
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                   "[Rework] Created rework sequence: " & NewSequenceName)
            End If

            DialogResult = Windows.Forms.DialogResult.OK
            DoClose()
            ResetGridStyle()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author> Dung Pham </author>
    ''' <date> 2021-07-20 </date>
    ''' <summary>
    ''' when user save Rework recipe if total gas is not 100
    ''' return index gas to show message warning
    ''' </summary>
    Private Function FindIndexGasBreakPoint(ByVal limit As Double) As Integer

        Try
            Const GROUP_GAS_INDEX As Integer = 2

            Dim dt As DataTable = CType(Me.dgvRecipe.DataSource, DataTable)
            Dim chamberDB As AVPLib.DBChamber = AVPLib.Utils.Chamber(dt, AVPLib.Utils.chamberName2ChamberID(_lastOpenRecipePM))

            For Each chamberStep As AVPLib.DBChamberStep In chamberDB.ListChamberSteps
                If (chamberStep.ListGroupParameterValues.Count > GROUP_GAS_INDEX) Then

                    Dim totalGas As Double = 0
                    ' get all values of group gasses control
                    Dim values As ArrayList = chamberStep.ListGroupParameterValues(GROUP_GAS_INDEX).ListParameterValues

                    For gasIndex As Integer = 0 To 4
                        If values.Count > gasIndex AndAlso values(gasIndex) IsNot Nothing Then
                            totalGas += values(gasIndex).Value
                        End If
                    Next

                    If totalGas <> limit Then
                        Return chamberStep.SeqNo
                    End If
                End If
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return -1
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-06</date>
    ''' <summary>
    ''' Save recipe to new name.
    ''' </summary>
    Private Function SaveRecipe() As Boolean
        Try
            Dim recipeName As String = GetReworkName(_recipeName)
            Dim dt As DataTable = CType(Me.dgvRecipe.DataSource, DataTable)
            Dim chamberDB As AVPLib.DBChamber = AVPLib.Utils.Chamber(dt, AVPLib.Utils.chamberName2ChamberID(_lastOpenRecipePM))
            chamberDB.ChamberDescription = recipeName
            chamberDB = ConvertToRealValue(chamberDB, False)

            For i As Integer = 0 To dgvRecipe.Columns.Count - 1
                If dgvRecipe.Columns(i).Visible AndAlso TypeOf dgvRecipe.Columns(i).HeaderCell Is DataGridViewCheckBoxHeaderCell Then
                    Dim headerCell As DataGridViewCheckBoxHeaderCell = CType(dgvRecipe.Columns(i).HeaderCell, DataGridViewCheckBoxHeaderCell)
                    If Not headerCell.Checked Then
                        chamberDB.ListChamberSteps.RemoveAt(0)
                    Else
                        Exit For
                    End If
                End If
            Next

            Dim seqNo As Integer = 1
            For Each item As AVPLib.DBChamberStep In chamberDB.ListChamberSteps
                item.SeqNo = seqNo
                seqNo += 1
            Next

            Dim fileName As String = AVPLib.Utils.GetFileName(recipeName, "xml")
            AVPLib.ContainerData.SaveChamber(chamberDB, recipeName)
            AVPLib.ContainerData.UpdateChamber(chamberDB.ChamberName, fileName)
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-06</date>
    ''' <summary>
    ''' Save new wafer flow.
    ''' </summary>
    Private Function SaveWaferFlow() As Boolean
        Dim wfflow As New AVPLib.DataManagerment.WaferFlow
        Dim arlStepList As New ArrayList
        Dim WfFlowName As String = GetReworkName(_waferFlowName)
        Try
            wfflow.WaferFlowName = WfFlowName
            wfflow.Description = WfFlowName

            Dim stepIndex As Integer = 0
            If cbxUseAligner.Visible AndAlso cbxUseAligner.Checked Then
                Dim arlStation As New ArrayList
                arlStation.Add("Aligner")

                Dim stepItem As New AVPLib.DataManagerment.WaferflowStep
                stepItem.RecipeName = cbAlignRecipes.SelectedItem
                stepItem.StationList = arlStation
                stepItem.Number = stepIndex

                arlStepList.Add(stepItem)
                stepIndex += 1
            End If

            For i As Integer = _selectedStepIndex To Me.picShowWaferFlow.Controls.Count - 1
                Dim nodeStep As WaferFlowNodeControl = picShowWaferFlow.Controls(i)

                Dim arlStation As New ArrayList
                arlStation.Add(AVPLib.Utils.chamberName2ChamberID(nodeStep.AccessibleDescription))

                Dim recipeName As String = nodeStep.Tag
                If nodeStep.IsSelected Then
                    recipeName = GetReworkName(_recipeName)
                End If

                Dim stepItem As New AVPLib.DataManagerment.WaferflowStep
                stepItem.RecipeName = recipeName
                stepItem.StationList = arlStation
                stepItem.Number = stepIndex

                arlStepList.Add(stepItem)
                stepIndex += 1
            Next

            wfflow.StepList = arlStepList
            wfflow.LoopList = New ArrayList
            wfflow.Description = WfFlowName

            Return AVPLib.ContainerData.SaveWaferFlow(wfflow, False)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-06</date>
    ''' <summary>
    ''' Save new sequence.
    ''' </summary>
    Private Function SaveSequence() As Boolean
        Try
            Dim wfNewName As String = GetReworkName(_waferFlowName)
            For Each sequenceItem As DBWaferSlot In _sequenceObject.WaferList
                If Not String.IsNullOrEmpty(sequenceItem.WaferSequence.SeqName) Then
                    If sequenceItem.WaferSequence.SeqName = _waferFlowName Then
                        sequenceItem.WaferSequence.SeqName = wfNewName
                    Else
                        sequenceItem.WaferSequence.SeqName = String.Empty
                    End If
                End If
            Next

            Return AVPLib.ContainerData.UpdateWFSequence(_sequenceObject, NewSequenceName, NewSequenceName)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-11</date>
    ''' <summary>
    ''' Handles wafer flow selection changes.
    ''' </summary>
    Private Sub cbWaferFlows_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbWaferFlows.SelectedIndexChanged
        Try
            If cbWaferFlows.SelectedIndex >= 0 Then
                Dim selectedWFName As String = cbWaferFlows.SelectedItem
                If selectedWFName <> _waferFlowName Then
                    If String.IsNullOrEmpty(_waferFlowName) Then
                        LoadWaferFlow(selectedWFName)
                    Else
                        If _isModified OrElse IsRecipeStepListModified() Then
                            If Utils.ShowAVPMessageBox("Current wafer flow is modified. Would you like to switch to the wafer flow """ & selectedWFName & """?", Text, MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OKCancel) = Windows.Forms.DialogResult.OK Then
                                LoadWaferFlow(selectedWFName)
                            Else
                                cbWaferFlows.SelectedItem = _waferFlowName
                            End If
                        Else
                            LoadWaferFlow(selectedWFName)
                        End If
                    End If
                End If
            Else
                picShowWaferFlow.Controls.Clear()
                dgvRecipe.Columns.Clear()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-19</date>
    ''' <summary>
    ''' Select aligner recipe.
    ''' </summary>
    Private Sub SelectAlignerRecipe()
        Try
            If _sequenceObject IsNot Nothing Then
                Dim alignerRecipe As String = String.Empty

                For Each item As AVPLib.DBWaferSlot In _sequenceObject.WaferList
                    If String.IsNullOrEmpty(_waferFlowName) OrElse item.WaferSequence.SeqName = _waferFlowName Then
                        For Each sequenceStep As DBSeqStep In item.WaferSequence.SeqStepList
                            If sequenceStep.StationName = Equipments.Aligner.ToString() Then
                                alignerRecipe = sequenceStep.RecipeName
                                Exit For
                            End If
                        Next

                        If Not String.IsNullOrEmpty(alignerRecipe) Then
                            Exit For
                        End If
                    End If
                Next

                If Not String.IsNullOrEmpty(alignerRecipe) Then
                    cbAlignRecipes.SelectedItem = alignerRecipe
                    cbxUseAligner.Checked = True
                Else
                    cbxUseAligner.Checked = False
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-20</date>
    ''' <summary>
    ''' Format rework name.
    ''' </summary>
    Private Function GetReworkName(ByVal originalName As String)
        If String.IsNullOrEmpty(_suffixName) Then
            _suffixName = DateTime.Now.ToString("MMddyy_HHmm")
        End If
        Return String.Format("RW_{0}_{1}", originalName, _suffixName)
    End Function

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2021-07-22 </date>
    ''' </author>
    ''' <summary>
    ''' Reset Grid Color and tool-tip 
    ''' </summary>
    Private Sub ResetGridStyle()
        Try
            For Each row As DataGridViewRow In dgvRecipe.Rows
                For cellindex As Integer = 0 To row.Cells.Count - 1
                    row.Cells(cellindex).Style.ForeColor = Color.Black
                    row.Cells(cellindex).ToolTipText = ""
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
    Private Sub SetGridStyle(ByVal value As String, ByVal rowIndex As Integer, ByVal columnIndex As Integer)
        Try
            Const OldValueStr As String = "Old Value: "
            Dim currentValue As String = Me.dgvRecipe.Rows(rowIndex).Cells(columnIndex).Value.ToString
            If value <> currentValue Then
                If Me.dgvRecipe.Rows(rowIndex).Cells(columnIndex).ToolTipText = "" Then
                    Me.dgvRecipe.Rows(rowIndex).Cells(columnIndex).Style.ForeColor = Color.Red
                    Me.dgvRecipe.Rows(rowIndex).Cells(columnIndex).ToolTipText = OldValueStr & currentValue
                Else
                    If OldValueStr & value = Me.dgvRecipe.Rows(rowIndex).Cells(columnIndex).ToolTipText Then
                        Me.dgvRecipe.Rows(rowIndex).Cells(columnIndex).ToolTipText = ""
                        Me.dgvRecipe.Rows(rowIndex).Cells(columnIndex).Style.ForeColor = Color.Black
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

End Class

