Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Imports AVPControls

Public Class Sequence
#Region "Variable"
    Const COL_SELECTWF As String = "Show"
    Private CurrentIsNew As Boolean = False
    Private m_intclickedRow As Integer = -1
    Private m_wfSelectedFlow As AVPLib.DataManagerment.WaferFlow
    Private m_strCurrentSeqName As String = String.Empty
    Private m_currentSeqWaferFlow As AVPLib.DBWaferList
    Private m_blnIsModified As Boolean = False
    Private m_strMissingStation As String = String.Empty
    Private m_arrStationAvailable As List(Of String) = Nothing
    Private m_blnIsReadOnly As Boolean = False
    'for drawing
    Private m_intRectWidth As Integer = 320
    Private m_dtSequence As DataTable = Nothing
    Private m_intNoSlots As Integer = 12
    Private m_blnSecondLoad As Boolean = False
    Private m_strTitle As String = String.Empty
    Private m_blnShowInSequenceDialog As Boolean = False

    Dim RectWidth As Integer = 466
    Const RectHeight As Integer = 50
    Const RectSpace As Integer = 10
    Const RectLeft As Integer = 10
    Const RectTop As Integer = 5
    Const LineWidth As Integer = 20

    Public Event Reload_PPSequenceEvent As EventHandler

    Private m_StringFormat As StringFormat = Nothing
    Private m_SequenceNameGraphics As Graphics
#End Region

#Region "Properties"
    Public Property ShowInQuickSequenceDialog() As Boolean
        Get
            Return m_blnShowInSequenceDialog
        End Get
        Set(ByVal value As Boolean)
            m_blnShowInSequenceDialog = value
            If value Then
                Panel2.Visible = False
                Panel1.Visible = False
                labTitle.Visible = False
                Me.Width = 1280
                Me.dgvSequence.Width = 510
                Me.pnlShowWaferFlow.Width = 285
                picShowWaferFlow.Width = 230
                m_intRectWidth = 230
                btnSelectAll.Size = New Size(100, 60)
                btnClearSelected.Size = New Size(100, 60)
                btnUnSelectAll.Size = New Size(100, 60)

                btnSelectAll.Left = 1170
                btnClearSelected.Left = 1170
                btnUnSelectAll.Left = 1170

                btnClearSelected.Top -= 70
                btnSelectAll.Top -= 40
                btnUnSelectAll.Top -= 10
            End If
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' SetTitle
    ''' </summary>
    ''' <param name="Title"></param>
    ''' <remarks></remarks>
    Public Property Title() As String
        Get
            Return m_strTitle
        End Get
        Set(ByVal value As String)
            m_strTitle = value
            Me.labTitle.Text = value
            Me.labTitle.Tag = value
        End Set
    End Property

    Private Property IsModified() As Boolean
        Get
            Return m_blnIsModified
        End Get
        Set(ByVal value As Boolean)
            m_blnIsModified = value
            If m_blnIsModified Then
                Me.labTitle.Text = Me.labTitle.Tag & "*"
            Else
                Me.labTitle.Text = Me.labTitle.Tag
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Huy Nguyen </name>
    '''    	<date> 2015/07/22 </date>
    ''' </author>
    ''' <summary>
    ''' is form read only?
    ''' </summary>
    Public Property IsReadOnly() As Boolean
        Get
            Return m_blnIsReadOnly
        End Get
        Set(ByVal value As Boolean)
            m_blnIsReadOnly = value

            If m_blnIsReadOnly Then
                Me.InactiveForm()
            End If
        End Set
    End Property
#End Region

#Region "Event on Form"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Sequence_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Sequence_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            m_arrStationAvailable = ContainerData.GetStationAvailable()
            LoadForm(True)
            Me.ResetGridStyle()

            ' For calculating the size of Recipe Name textbox
            m_StringFormat = New StringFormat(StringFormatFlags.NoWrap)
            m_StringFormat.LineAlignment = StringAlignment.Center
            m_StringFormat.Alignment = StringAlignment.Near
            m_StringFormat.Trimming = StringTrimming.EllipsisCharacter
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' dgvSequence_CellClick
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvSequence_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSequence.CellClick
        AVPLib.Log.guiLogger.Info("Enter dgvSequence_CellClick")
        Try
            Dim i As Integer = 1
            Me.m_intclickedRow = e.RowIndex
            If e.RowIndex < 0 Then
                AVPLib.Log.guiLogger.Info("Leave dgvSequence_CellClick")
                Exit Sub
            End If
            If Me.dgvSequence.Columns(e.ColumnIndex).Name = WAFER_FLOW _
               AndAlso Not String.IsNullOrEmpty(Me.dgvSequence.Rows(e.RowIndex).Cells(WAFER_FLOW).Value) Then
                'picShowWaferFlow.Image = Nothing
                SelectWaferFlow(e)
            ElseIf Me.dgvSequence.Columns(e.ColumnIndex).Name = WAFER_FLOW _
               AndAlso String.IsNullOrEmpty(Me.dgvSequence.Rows(e.RowIndex).Cells(WAFER_FLOW).Value) Then
                SelectWaferFlow(e)
                ''if select Checkbox column to select and unselect
            ElseIf Me.dgvSequence.Columns(e.ColumnIndex).Name = SELECTED Then
                If Me.dgvSequence.Rows(e.RowIndex).Cells(SELECTED).Value = True Then
                    Me.dgvSequence.Rows(e.RowIndex).Cells(SELECTED).Value = False
                Else
                    Me.dgvSequence.Rows(e.RowIndex).Cells(SELECTED).Value = True
                End If
            ElseIf Me.dgvSequence.Columns(e.ColumnIndex).Name = COL_SELECTWF AndAlso _
                   Not String.IsNullOrEmpty(Me.dgvSequence.Rows(e.RowIndex).Cells(WAFER_FLOW).Value) Then

                Dim WfName As String = Me.dgvSequence.Rows(e.RowIndex).Cells(WAFER_FLOW).Value
                Dim WfFlow As AVPLib.DataManagerment.WaferFlow = AVPLib.ContainerData.GetWaferFlowbyName(WfName)
                If WfFlow IsNot Nothing Then
                    If WfFlow.CheckRecipeExist Then
                        ShowWaferFlowImageToGUI(WfFlow)
                        Me.dgvSequence.Columns(e.ColumnIndex).DefaultCellStyle.SelectionBackColor = Color.Red
                        Me.dgvSequence.Columns(0).DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke
                        Me.dgvSequence.Columns(WAFER_FLOW).DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke
                        Me.dgvSequence.Rows(e.RowIndex).Selected = True
                    Else
                        Utils.ShowAVPMessageBox(WfName & " - " & "Recipe is missing. Please check your WaferFlow", "Missing Recipe", _
                                                 MessageBoxIcon.Warning, MessageBoxButtons.OK)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                                  AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                                  "[Main Screen] " + "Missing recipe when click Sequence cell.")
                    End If
                End If
            ElseIf Me.dgvSequence.Columns(e.ColumnIndex).Name = COL_SELECTWF AndAlso _
                String.IsNullOrEmpty(Me.dgvSequence.Rows(e.RowIndex).Cells(WAFER_FLOW).Value) Then
                picShowWaferFlow.Image = Nothing
                '''Clear all control in picturebox
                ClearControlsInPicture()
            End If
            Me.dgvSequence.Refresh()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave dgvSequence_CellClick")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' Show Wafer Flow Dialog 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SelectWaferFlow(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            If AVPLib.ContainerData.Permission(PERMISSION_002) AndAlso Not AVPRobotMain.OnlineRemote AndAlso Not Me.IsReadOnly Then
                Dim arrWaferFlow As ArrayList = Nothing
                arrWaferFlow = AVPLib.ContainerData.GetAllWaferFlowName
                Dim waferDlg As New SelectWaferFlow(arrWaferFlow, False)
                waferDlg.ShowDialog()
                If waferDlg.DialogResult = Windows.Forms.DialogResult.OK Then
                    m_wfSelectedFlow = waferDlg.SelectedFlow
                    If m_wfSelectedFlow.CheckRecipeExist = False Then
                        Utils.ShowAVPMessageBox(m_wfSelectedFlow.WaferFlowName & " - " & "Recipe is missing. Please check your WaferFlow", _
                                                "Recipe Missing", MessageBoxIcon.Warning, MessageBoxButtons.OK)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                                      AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                                      "[Main Screen] " + "Missing recipe when select wafer flow.")
                        '#07/28/2011 
                        '#-	Sequence editor and Quick sequence editor.    User create a quick sequence but the wafer flow 
                        '# had an invalid or missing recipe, editor still let user continue to create and save.
                        '#Begin fix:
                        Exit Try
                        '#End if
                    End If
                    If Me.dgvSequence.Rows(e.RowIndex).Cells(SELECTED).Value = True _
                       AndAlso SelectedRow() > 1 Then 'if select some row
                        Me.CloneSelectedWaferFlow(m_wfSelectedFlow.WaferFlowName)
                    Else
                        Me.dgvSequence.Rows(e.RowIndex).Cells(WAFER_FLOW).Value = m_wfSelectedFlow.WaferFlowName
                        Me.dgvSequence.Rows(e.RowIndex).Cells(WAFER_FLOW).Selected = True
                        Dim WfFlow As AVPLib.DataManagerment.WaferFlow = AVPLib.ContainerData.GetWaferFlowbyName(m_wfSelectedFlow.WaferFlowName)
                        If WfFlow IsNot Nothing Then
                            ShowWaferFlowImageToGUI(WfFlow)
                        End If
                        Me.m_dtSequence.AcceptChanges()
                    End If
                    Me.IsModified = True
                End If

                waferDlg.Dispose()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' Read Information of WaferFlow to draw
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ShowWaferFlowImageToGUI(ByVal WfFlow As AVPLib.DataManagerment.WaferFlow)
        Try
            Dim intHeight As Integer = 0
            Dim bmpHeight As Integer = (WfFlow.StepList.Count) * (RectSpace + RectHeight) + RectHeight / 2
            Me.picShowWaferFlow.Height = bmpHeight

            Dim bmp As Image = New Bitmap(picShowWaferFlow.Width, bmpHeight)
            Dim g As Graphics = Graphics.FromImage(bmp)
            Dim maxCount As Integer = GetMaxCountLoop(WfFlow.LoopList)

            'clear all controls in picturebox
            ClearControlsInPicture()

            ' Draw all steps.
            Dim ListOfStep As New List(Of String)
            Dim ListOfStation As New List(Of String)
            For Each wfStep As AVPLib.DataManagerment.WaferflowStep In WfFlow.StepList
                ListOfStep.Add(wfStep.RecipeName)
                ListOfStation.Add(wfStep.StationList.Item(0))
            Next

            DrawWaferFlow(g, ListOfStep, ListOfStation, intHeight, maxCount)
            ListOfStep.Clear()
            ListOfStation.Clear()

            ' Draw connection loop lines.
            If WfFlow.LoopList IsNot Nothing AndAlso WfFlow.LoopList.Count > 0 Then
                Dim solidBrush As New SolidBrush(pnlShowWaferFlow.BackColor)
                Dim pnlRect As New Rectangle(0, 0, picShowWaferFlow.Width, picShowWaferFlow.Height)
                g.FillRectangle(solidBrush, pnlRect)

                Dim fontSize As Integer = 12
                Dim loopFont As Font = New Font("Tahoma", fontSize, FontStyle.Bold)
                For Each wfLoop As AVPLib.DataManagerment.WaferflowLoop In WfFlow.LoopList
                    Dim LoopStart As Integer = wfLoop.LoopStart
                    Dim LoopEnd As Integer = wfLoop.LoopEnd
                    Dim LoopCount As Integer = wfLoop.LoopCount

                    Dim yStart As Integer = RectTop + (RectHeight + RectSpace) * LoopStart
                    Dim yEnd As Integer = RectTop + (RectHeight + RectSpace) * LoopEnd

                    Dim dy As Integer
                    If LoopStart = LoopEnd Then
                        dy = Convert.ToInt32(RectHeight / 5.0F)
                        yStart += dy
                        yEnd += RectHeight - dy
                    Else
                        dy = Convert.ToInt32(RectHeight / 2.0F)
                        yStart += dy
                        yEnd += dy
                    End If

                    g.DrawLine(Pens.DarkBlue, RectLeft + RectWidth, yStart, RectLeft + RectWidth + LineWidth, yStart)
                    g.DrawLine(Pens.DarkBlue, RectLeft + RectWidth, yEnd, RectLeft + RectWidth + LineWidth, yEnd)
                    g.DrawLine(Pens.DarkBlue, RectLeft + RectWidth + LineWidth, yStart, RectLeft + RectWidth + LineWidth, yEnd)

                    Dim ype As Integer = Convert.ToInt32((yEnd - yStart) / 2.0F + yStart - fontSize)
                    g.DrawString(LoopCount.ToString(), loopFont, Brushes.Blue, RectLeft + RectWidth + LineWidth, ype)
                Next

                loopFont.Dispose()
                solidBrush.Dispose()
                pnlRect = Nothing
            End If

            Me.picShowWaferFlow.Image = bmp
            g.Dispose()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-08-29</date>
    ''' </author>
    ''' <summary>
    ''' pic_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pic_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim pic As PictureBox = DirectCast(sender, PictureBox)
            If Not String.IsNullOrEmpty(pic.Name) Then
                Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(pic.AccessibleDescription)
                Dim Title As String = pic.AccessibleDescription & "-" & pic.Tag
                Utils.ShowQuickViewRecipe(ChamberName, pic.Tag, Title, False, False)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' dgvSequence_DataSourceChanged: rest datagrid
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvSequence_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSequence.DataSourceChanged
        AVPLib.Log.guiLogger.Info("Enter dgvSequence_DataSourceChanged")
        Try
            Me.ResetGridStyle()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave dgvSequence_DataSourceChanged")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' dgvSequence_CellEndEdit
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvSequence_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSequence.CellEndEdit
        If Not dgvSequence.Rows(e.RowIndex).Cells(WAFER_FLOW).Value = AVPLib.ConstEnum.EMPTY_STR Then
            Me.IsModified = True
        End If
    End Sub
#End Region

#Region "Buttons Event"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' txtDescription_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged
        Me.IsModified = True
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' btnUnSelectAll_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnUnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnSelectAll.Click
        AVPLib.Log.guiLogger.Info("Enter btnUnSelectAll_Click")
        Try
            For i As Integer = 0 To Me.m_intNoSlots - 1
                If Me.dgvSequence.Rows(i).Cells(SELECTED).Value = True Then
                    Me.dgvSequence.Rows(i).Cells(SELECTED).Value = False
                End If
            Next
            Me.IsModified = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnUnSelectAll_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' btnSelectAll_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        AVPLib.Log.guiLogger.Info("Enter btnSelectAll_Click")
        Try
            For i As Integer = 0 To Me.m_intNoSlots - 1
                Me.dgvSequence.Rows(i).Cells(SELECTED).Value = True
            Next
            Me.IsModified = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnSelectAll_Click")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' btnNew_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        AVPLib.Log.guiLogger.Info("Enter btnNew_Click")
        Try
            If (Me.IsModified AndAlso AVPLib.ContainerData.Permission(PERMISSION_002)) Then
                'ask to save
                If Utils.ShowAVPMessageBox("Current Sequence was changed." & Chr(13) & "Do you want to save ?", "Save Sequence", MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK Then
                    btnSave_Click(sender, e)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                  AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                  "[Main Screen] " + "Confirm save change current Sequence when open a new Sequence.")
                End If
            End If

            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Sequence Editor] New Sequence")
            Me.LoadForm(True)
            Me.IsModified = False
            btnSave.Enabled = True
            btnSaveAs.Enabled = True
            btnDelete.Enabled = True
            Me.m_strCurrentSeqName = ""
            For i As Integer = 0 To Me.m_intNoSlots - 1
                dgvSequence.Rows(i).Cells(SELECTED).Value = False
                dgvSequence.Rows(i).Cells(WAFER_FLOW).Value = ""
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnNew_Click")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    '''    	<name> Dat Cao modify </name>
    '''    	<date> 20011-03-16</date>

    ''' </author>
    ''' <summary>
    ''' btnOpen_Click
    'do not save and delete when sequence is current in use
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        AVPLib.Log.guiLogger.Info("Enter btnOpen_Click")
        Try
            Dim SequenceDlg As New OpenSequence(False)
            Dim filename As String = String.Empty
            m_strMissingStation = String.Empty
            Dim strMissingRecipe As String = String.Empty

            If SequenceDlg.ShowDialog() = DialogResult.OK Then
                If (Me.IsModified AndAlso AVPLib.ContainerData.Permission(PERMISSION_002)) Then
                    'ask to save
                    If Utils.ShowAVPMessageBox("Current Sequence was changed." & Chr(13) & "Do you want to save ?", "Save Sequence", MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK Then
                        btnSave_Click(sender, e)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                      AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                      "[Main Screen] " + "Confirm save change current Sequence when open a new Sequence.")
                    End If
                End If

                filename = AVPLib.ContainerDAO.FPath_SequenceData & "\" & SequenceDlg.FileName

                'check permission
                If (AVPLib.ContainerData.Permission(PERMISSION_002) And Not AVPRobotMain.OnlineRemote) Then
                    'get file name and check sequence 
                    btnSave.Enabled = True
                    btnSaveAs.Enabled = True
                    btnDelete.Enabled = True
                Else
                    Me.btnDelete.Enabled = False
                    Me.btnNew.Enabled = False
                    Me.btnSave.Enabled = False
                    Me.btnSaveAs.Enabled = False
                End If
                

                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Sequence Editor] Open Sequence " + SequenceDlg.FileName)

                Dim wfSequence As AVPLib.DBWaferList = Nothing
                Dim strDescription As String = Nothing
                ' If can not open the flow
                If Not AVPLib.ContainerData.GetSequence(filename, wfSequence, strDescription) Then
                    Return
                End If
                txtDescription.Text = strDescription

                CleanGrid()
                Me.m_currentSeqWaferFlow = wfSequence
                Me.m_strCurrentSeqName = SequenceDlg.FileName.Replace(".xml", "")
                Me.Title = m_strCurrentSeqName
                Dim strWaferFlowMissing As String = String.Empty
                For Each item As AVPLib.DBWaferSlot In wfSequence.WaferList
                    Dim strShowWaferFlowName As String = item.WaferSequence.SeqName

                    If (item.Slot > m_intNoSlots) Then
                        Continue For
                    End If

                    Dim WaferFlow As AVPLib.DataManagerment.WaferFlow = AVPLib.ContainerData.GetWaferFlowbyName(item.WaferSequence.SeqName)
                    If WaferFlow Is Nothing Then
                        If Not String.IsNullOrEmpty(item.WaferSequence.SeqName) Then
                            If String.IsNullOrEmpty(strWaferFlowMissing) Then
                                strWaferFlowMissing = item.WaferSequence.SeqName
                            End If
                            strShowWaferFlowName = ""
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                          AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                          "[Main Screen] " + "WaferFlow " & item.WaferSequence.SeqName & " does not exist!")
                            'AVPLib.Log.guiLogger.Info("Leave btnOpen_Click")
                            'Exit Sub
                        Else
                            Continue For
                        End If
                    End If

                    If WaferFlow IsNot Nothing AndAlso WaferFlow.CheckRecipeExist() = False Then
                        strMissingRecipe &= WaferFlow.WaferFlowName & " - "
                    End If

                    Me.dgvSequence.Rows(m_intNoSlots - CInt(item.Slot)).Cells(WAFER_FLOW).Value = strShowWaferFlowName
                    Me.dgvSequence.Rows(m_intNoSlots - CInt(item.Slot)).Cells(SELECTED).Value = False
                Next
                ' is missing recipe or wafer flow 
                If String.IsNullOrEmpty(strMissingRecipe) = False Then
                    Utils.ShowAVPMessageBox(strMissingRecipe & "Recipe is missing. Please check your WaferFlow", _
                                                "Missing Recipe", MessageBoxIcon.Warning, MessageBoxButtons.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                         AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                         "[Main Screen] " + "Recipe is missing when open Sequence")
                ElseIf String.IsNullOrEmpty(strWaferFlowMissing) = False Then
                    Utils.ShowAVPMessageBox("WaferFlow " & strWaferFlowMissing & " does not exist!", _
                                        "Error", MessageBoxIcon.Information, MessageBoxButtons.OK)

                End If

                Me.IsModified = False
                Me.ResetGridStyle()
                '''''''''''''''''''alert to user
                If Not (m_strMissingStation = String.Empty) Then
                    m_strMissingStation = m_strMissingStation.Remove(m_strMissingStation.LastIndexOf(","))
                    Utils.ShowAVPMessageBox(m_strMissingStation & " does not exist", "Stations does not exist", MessageBoxIcon.Information, _
                        AVPMessageBox.AVPMessageBoxButton.OK)
                    m_strMissingStation = String.Empty '''clear the list
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                             AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                             "[Main Screen] " + m_strMissingStation & " does not exist when open Sequence")
                End If
            End If

            SequenceDlg.Dispose()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnOpen_Click")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' btnDelete_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        AVPLib.Log.guiLogger.Info("Enter btnDelete_Click")
        Try
            Dim frm As New OpenSequence(True)
            frm.Title = "Delete Job Sequence"
            frm.ShowDialog()
            If frm.DialogResult = DialogResult.OK And frm.FileNames.Count > 1 Then
                Dim dlg As DialogResult
                For Each sFileName As String In frm.FileNames
                    dlg = Utils.ShowAVPDeleteMultiMessageBox("Do you want to delete job sequence " & sFileName & "? ", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Question)
                    If dlg = DialogResult.Yes Then ''YesToAll
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Sequence Editor] Delete " & frm.FileNames.Count.ToString() & " Of Job File")
                        DeleteAllJobFile(frm.FileNames)
                        Exit For
                    ElseIf dlg = DialogResult.OK Then 'Yes
                        If IsSequenceInUseScheduler(sFileName, "Delete", "delete") Then
                            Exit Try
                        End If
                        Dim blnSuccess As Boolean = False
                        blnSuccess = AVPLib.ContainerData.DeleteWFSequence(sFileName & ".xml")
                        If sFileName = Me.m_strCurrentSeqName Then
                            Me.IsModified = False
                            Me.m_currentSeqWaferFlow = Nothing
                            m_strCurrentSeqName = String.Empty
                            CleanGrid()
                            Me.Title = "New Sequence"
                            txtDescription.Text = String.Empty
                        End If
                        'ElseIf dlg = DialogResult.No Then 'No -> do nothing
                    ElseIf dlg = DialogResult.Cancel Then
                        Exit For
                    End If
                Next
            ElseIf frm.DialogResult = DialogResult.OK Then
                Dim dlg As DialogResult = Utils.ShowAVPMessageBox("Do you want to delete job sequence " & frm.FileNames.Item(0).ToString() & "? ", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Question)
                If dlg = DialogResult.OK Then
                    If IsSequenceInUseScheduler(frm.FileNames.Item(0).ToString(), "Delete", "delete") Then
                        Exit Try
                    End If

                    Dim blnSuccess As Boolean = False
                    blnSuccess = AVPLib.ContainerData.DeleteWFSequence(frm.FileNames.Item(0).ToString() & ".xml")
                    If frm.FileNames.Item(0).ToString() = Me.m_strCurrentSeqName Then
                        Me.IsModified = False
                        Me.m_currentSeqWaferFlow = Nothing
                        m_strCurrentSeqName = String.Empty
                        CleanGrid()
                        Me.Title = "New Sequence"
                        txtDescription.Text = String.Empty
                    End If
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                        AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                        "[Main Screen]" + "Delete Job Sequence " & frm.FileNames.Item(0).ToString())
                End If
                End If

            If ContainerForm.Secs_GemPanel.rbnSequence.Checked Then
                RaiseEvent Reload_PPSequenceEvent(Nothing, Nothing)
            End If

            frm.Dispose()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnDelete_Click")
    End Sub
    Private Sub DeleteAllJobFile(ByVal listOfJobFile As List(Of String))
        Try
            For Each file As String In listOfJobFile
                If IsSequenceInUseScheduler(file, "Delete", "delete") Then
                    Exit For
                End If

                AVPLib.ContainerData.DeleteWFSequence(file & ".xml")
                If file = Me.m_strCurrentSeqName Then
                    Me.IsModified = False
                    Me.m_currentSeqWaferFlow = Nothing
                    m_strCurrentSeqName = String.Empty
                    CleanGrid()
                    Me.Title = "New Sequence"
                    txtDescription.Text = String.Empty
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' btnSave_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        AVPLib.Log.guiLogger.Info("Enter btnSave_Click")
        Try
            If IsEmptySequenceFlow() Then
                Utils.ShowAVPMessageBox(STR_SEQUENCE_EMPTY, "Error", MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                    AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                    "[Main Screen] " + "Save Sequence error : " & STR_SEQUENCE_EMPTY)
                Exit Sub
            End If

            Dim blnSuccess As Boolean = False
            If Me.IsModified Then

                StoreGUIToObj(m_currentSeqWaferFlow) 'store current sequence to m_currentSeqWaferFlow
                If Not (m_strCurrentSeqName = "") Then 'Update
                    If IsSequenceInUseScheduler(m_strCurrentSeqName, "Save", "modify") Then
                        Exit Try
                    End If

                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Sequence Editor] Updated existed Sequence with FileName=" + Me.labTitle.Text)
                    blnSuccess = AVPLib.ContainerData.UpdateWFSequence(m_currentSeqWaferFlow, m_strCurrentSeqName, Me.txtDescription.Text)
                    If blnSuccess Then
                        'Utils.ShowAVPMessageBox("Sequence Saved Successfully", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Information, MessageBoxButtons.OK)
                        Me.IsModified = False
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                  AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                  "[Main Screen] " + "Sequence Saved Successfully")
                        '#08/17/2011 
                        '#-Recipe/waferflow/sequence was modified during lot run but was not log in lot data log.
                        '#Begin fix.
                        Utils.AddLotDatalog("Sequence " & Me.labTitle.Text & " is modified")
                        '#End fix
                    Else
                        'Utils.ShowAVPMessageBox("Sequence Saved Unsuccessfully", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Error, MessageBoxButtons.OK)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                  AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                  "[Main Screen] " + "Sequence Saved Unsuccessfully")
                    End If

                Else 'New
                    Dim sDefault As String = "New Sequence"
                    Dim pad As New KeyPad
                    pad.IsCheckInvalidCharacter = True
                    If pad.DisplayKeypad(sDefault, "Saving New Sequence...", False) <> Windows.Forms.DialogResult.OK Then
                        Exit Sub
                    Else
                        If sDefault.Length = 0 Then
                            Utils.ShowAVPMessageBox("Enter Job Name", "Save", MessageBoxIcon.Error, MessageBoxButtons.OK)
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                 AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                 "[Main Screen] " + "Save sequence error without job name.")
                            Return
                        End If
                        sDefault = sDefault.Trim()
                        sDefault = (sDefault)

                        If AVPLib.ContainerData.ListSequenceName.Contains(sDefault) Then ''check existing file
                            Dim dlg As DialogResult = Utils.ShowAVPMessageBox("FileName Existed, Do you want to Overwrite", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Warning)
                            If dlg = DialogResult.OK Then
                                If IsSequenceInUseScheduler(sDefault, "Save", "modify") Then
                                    Exit Try
                                End If

                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                  AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                  "[Main Screen] " + "Save sequence with overwrite mode.")
                                blnSuccess = AVPLib.ContainerData.UpdateWFSequence(m_currentSeqWaferFlow, sDefault, Me.txtDescription.Text)
                                If blnSuccess Then
                                    'Utils.ShowAVPMessageBox("Sequence Saved Successfully", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Information, MessageBoxButtons.OK)
                                    '#04/27/2011 
                                    '#AVP.  Sequence editor.  Logs a wrong name when create a new sequence and save.  It show that it is saving “new sequen…..” --> see picture for more detail
                                    '#Begin fix
                                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Sequence Editor] Sequence was saved successfully. FileName=" + sDefault)
                                    '#End fix
                                    '#08/17/2011 
                                    '#-Recipe/waferflow/sequence was modified during lot run but was not log in lot data log.
                                    '#Begin fix.
                                    Utils.AddLotDatalog("Sequence " & Me.labTitle.Text & " is modified")
                                    '#End fix
                                    Me.IsModified = False
                                    Me.Title = sDefault
                                    m_strCurrentSeqName = sDefault
                                Else
                                    Utils.ShowAVPMessageBox("Sequence Saved Unsuccessfully", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Error, MessageBoxButtons.OK)
                                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Sequence Editor] Sequence was saved unsuccessfully. FileName=" + Me.labTitle.Text)
                                End If
                            End If
                        Else 'if not existing
                            blnSuccess = AVPLib.ContainerData.SaveWFSequence(m_currentSeqWaferFlow, sDefault, Me.txtDescription.Text)
                            If blnSuccess Then
                                'Utils.ShowAVPMessageBox("Sequence Saved Successfully", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Information, MessageBoxButtons.OK)
                                '#04/27/2011 
                                '#AVP.  Sequence editor.  Logs a wrong name when create a new sequence and save.  It show that it is saving “new sequen…..” --> see picture for more detail
                                '#Begin fix
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Sequence Editor] Sequence was saved successfully. FileName=" + sDefault)
                                '#End fix
                                Me.Title = sDefault
                                Me.IsModified = False
                                m_strCurrentSeqName = sDefault

                                If ContainerForm.Secs_GemPanel.rbnSequence.Checked Then
                                    RaiseEvent Reload_PPSequenceEvent(Nothing, Nothing)
                                End If
                            Else
                                Utils.ShowAVPMessageBox("Sequence Saved Unsuccessfully", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Error, MessageBoxButtons.OK)
                                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Sequence Editor] Sequence was saved unsuccessfully. FileName=" + Me.labTitle.Text)

                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnSave_Click")
    End Sub

    Private Function IsEmptySequenceFlow() As Boolean
        Try
            Dim dataTable As DataTable = CType(dgvSequence.DataSource, DataTable)
            For Each row As DataRow In dataTable.Rows
                If row("WaferFlow").ToString <> "" Then
                    Return False
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.guiLogger.Error(ex.ToString())
        End Try
        Return True
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
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
            If IsEmptySequenceFlow() Then
                Utils.ShowAVPMessageBox(STR_SEQUENCE_EMPTY, "Error", MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                    AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                    "[Main Screen] " + "Save As Sequence error : " & STR_SEQUENCE_EMPTY)
                Exit Sub
            End If

            Dim blnSuccess As Boolean = False
            Dim sDefault As String = Me.labTitle.Tag.ToString()
            Dim pad As New KeyPad
            pad.IsCheckInvalidCharacter = True
            If Me.IsModified Then
                StoreGUIToObj(m_currentSeqWaferFlow)
            End If
            If pad.DisplayKeypad(sDefault, "Saving Current Sequence As...", False) <> Windows.Forms.DialogResult.OK Then
                Exit Sub
            Else
                If sDefault.Length = 0 Then
                    Utils.ShowAVPMessageBox("Enter Job Name", "Save As", MessageBoxIcon.Error, MessageBoxButtons.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                 AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                 "[Main Screen] " + "Save As Sequence error without Job name")
                    Return
                End If
                sDefault = sDefault.Trim()
                sDefault = sDefault
                
                If AVPLib.ContainerData.ListSequenceName.Contains(sDefault) Then
                    Dim dlg As DialogResult = Utils.ShowAVPMessageBox("FileName Existed, Do you want to Overwrite", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Warning)
                    If dlg = DialogResult.OK Then
                        If IsSequenceInUseScheduler(sDefault, "Save as", "modify") Then
                            Exit Try
                        End If

                        '#08/17/2011 
                        '#-Recipe/waferflow/sequence was modified during lot run but was not log in lot data log.
                        '#Begin fix.
                        If IsModified Then
                            Utils.AddLotDatalog("Sequence " & Me.labTitle.Text & " is modified")
                        End If
                        '#End fix
                        Me.IsModified = False
                        blnSuccess = AVPLib.ContainerData.UpdateWFSequence(m_currentSeqWaferFlow, sDefault, Me.txtDescription.Text)
                        If Not blnSuccess Then
                            Utils.ShowAVPMessageBox("Sequence Saved Unsuccessfully", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Information, MessageBoxButtons.OK)
                        End If
                    End If
                Else
                    blnSuccess = AVPLib.ContainerData.SaveWFSequence(m_currentSeqWaferFlow, sDefault, Me.txtDescription.Text)
                    If Not blnSuccess Then
                        Utils.ShowAVPMessageBox("Sequence Saved Unsuccessfully", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Information, MessageBoxButtons.OK)
                    End If
                    Me.Title = sDefault
                    Me.IsModified = False
                    Me.m_strCurrentSeqName = sDefault

                    If ContainerForm.Secs_GemPanel.rbnSequence.Checked Then
                        RaiseEvent Reload_PPSequenceEvent(Nothing, Nothing)
                    End If
                End If
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Sequence Editor] Saved Sequence " + sDefault)
                End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnSaveAs_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' btnClearSelected_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClearSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSelected.Click
        AVPLib.Log.guiLogger.Info("Enter btnClearSelected_Click")
        Try
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Sequence Editor] Clear Seleceted slot")
            ClearSelectedRow()
            Me.IsModified = True
            Me.dgvSequence.Refresh()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnClearSelected_Click")
    End Sub

#End Region

#Region "Methods Support"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-29</date>
    ''' </author>
    ''' <summary>
    ''' Reload WaferFlow after swap button
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Friend Sub RefreshWaferFlow()
    '    AVPLib.Log.guiLogger.Info("Enter RefreshWaferFlow")
    '    Try
    '        If m_blnSecondLoad Then
    '            For i As Integer = 0 To m_intNoSlots - 1
    '                Dim WfName As String = Me.dgvSequence.Rows(i).Cells(WAFER_FLOW).Value
    '                Dim WfFlow As AVPLib.DataManagerment.WaferFlow = AVPLib.ContainerData.GetWaferFlowbyName(WfName)
    '                If WfFlow IsNot Nothing Then
    '                    ShowWaferFlowImageToGUI(WfFlow)
    '                ElseIf Not (String.IsNullOrEmpty(WfName)) Then
    '                    Utils.ShowAVPMessageBox("WaferFlow " & WfName & " does not exist, please check again!", "Sequence Error", MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
    '                    Me.dgvSequence.Rows(i).Cells(WAFER_FLOW).Value = ""
    '                    Me.picShowWaferFlow.Image = Nothing
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
    '                                                              AVPLib.ContainerData.LogSource.AVPMainScreen, _
    '                                                              "[Main Screen] " + "WaferFlow " & WfName & " does not exist")
    '                End If
    '            Next
    '        Else
    '            m_blnSecondLoad = True
    '        End If
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    AVPLib.Log.guiLogger.Info("Leave RefreshWaferFlow")
    'End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-29</date>
    ''' </author>
    ''' <summary>
    ''' SelectedRow: count the selected row in grid
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SelectedRow() As Integer
        AVPLib.Log.guiLogger.Info("Enter SelectedRow")
        Dim intSelectedRow As Integer = 1
        Try
            For i As Integer = 0 To Me.dgvSequence.Rows.Count - 1
                If Me.dgvSequence.Rows(i).Cells(SELECTED).Value = True Then
                    intSelectedRow += 1
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave SelectedRow")
        Return intSelectedRow
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' LoadForm
    ''' </summary>
    ''' <param name="isNew"></param>
    ''' <remarks></remarks>
    Private Sub LoadForm(ByVal isNew As Boolean)
        Try
            Me.dgvSequence.AllowUserToResizeRows = False
            Me.dgvSequence.AllowUserToDeleteRows = False
            Me.dgvSequence.AllowUserToResizeRows = False
            Me.txtDescription.Text = String.Empty
            Me.ClearControlsInPicture()
            Me.pnlShowWaferFlow.Refresh()
            Me.picWaferFlow.Refresh()
            Me.picShowWaferFlow.Refresh()
            Me.picShowWaferFlow.Image = Nothing
            If isNew Then
                Me.Title = "New Sequence"
            Else
                Me.Title = m_strCurrentSeqName
            End If
            Me.dgvSequence.Refresh()
            dgvSequence.Rows(dgvSequence.RowCount - 1).Cells(SLOT).Selected = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Create Column in DataGridView
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadFieldName()
        Try
            Me.m_dtSequence = New DataTable
            m_dtSequence.Columns.Add(SLOT)
            Dim typeBln As System.Type = System.Type.GetType("System.Boolean")
            m_dtSequence.Columns.Add(SELECTED, typeBln)
            m_dtSequence.Columns.Add(WAFER_FLOW)
            m_dtSequence.Columns.Add(COL_SELECTWF)

            '2013-01-03 Tin Pham added: use only for Load lock A
            m_intNoSlots = AVPLib.RobotConfigurationValues.LOADLOCKA_SLOTS
            '---------------------------------------------------

            'If (AVPLib.RobotConfigurationValues.LOADLOCKA_SLOTS > AVPLib.RobotConfigurationValues.LOADLOCKB_SLOTS) Then
            '    m_intNoSlots = AVPLib.RobotConfigurationValues.LOADLOCKA_SLOTS
            'Else
            '    m_intNoSlots = AVPLib.RobotConfigurationValues.LOADLOCKB_SLOTS
            'End If
            For i As Integer = m_intNoSlots To 1 Step -1
                Dim newrow As DataRow = m_dtSequence.NewRow
                newrow(SLOT) = i.ToString()
                newrow(SELECTED) = False
                newrow(WAFER_FLOW) = ""
                newrow(COL_SELECTWF) = ">>"
                m_dtSequence.Rows.Add(newrow)
            Next
            dgvSequence.AutoGenerateColumns = False
            Me.dgvSequence.DataSource = m_dtSequence

            Dim column As DataGridViewColumn = New DataGridViewTextBoxColumn()
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            column.SortMode = DataGridViewColumnSortMode.NotSortable
            If ShowInQuickSequenceDialog Then
                column.Width = 30
                column.HeaderText = String.Empty
            Else
                column.Width = 60
            End If
            column.DataPropertyName = SLOT
            column.Name = SLOT
            column.HeaderCell.Style.Font = New Font("Arial", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            dgvSequence.Columns.Add(column)

            column = New DataGridViewCheckBoxColumn()
            column.SortMode = DataGridViewColumnSortMode.NotSortable
            If ShowInQuickSequenceDialog Then
                column.Width = 30
                column.HeaderText = String.Empty
            Else
                column.Width = 80
            End If
            column.DataPropertyName = SELECTED
            column.Name = SELECTED
            column.HeaderCell.Style.Font = New Font("Arial", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            dgvSequence.Columns.Add(column)

            column = New DataGridViewTextBoxColumn()
            column.SortMode = DataGridViewColumnSortMode.NotSortable
            If ShowInQuickSequenceDialog Then
                column.Width = 300
            Else
                column.Width = 370
            End If

            column.DataPropertyName = WAFER_FLOW
            column.Name = WAFER_FLOW
            column.HeaderCell.Style.Font = New Font("Arial", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            dgvSequence.Columns.Add(column)

            column = New DataGridViewButtonColumn()
            column.SortMode = DataGridViewColumnSortMode.NotSortable
            If ShowInQuickSequenceDialog Then
                column.Width = 30
                column.HeaderText = String.Empty
            Else
                column.Width = 80
            End If

            column.DataPropertyName = COL_SELECTWF
            column.Name = COL_SELECTWF
            column.HeaderCell.Style.Font = New Font("Arial", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            dgvSequence.Columns.Add(column)

            Me.dgvSequence.Refresh()
            dgvSequence.Rows(dgvSequence.RowCount - 1).Cells(SLOT).Selected = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    '''' <author>
    ''''    	<name> Le Hieu Truc </name>
    ''''    	<date> 2009-07-23</date>
    '''' </author>
    '''' <summary>
    '''' CloneWaferFlow: Clone the WaferFlow with the Selected row in Grid
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    Private Sub CloneSelectedWaferFlow(ByVal strWaferFlowName As String)
        Try
            For i As Integer = 0 To m_intNoSlots - 1
                If (Me.dgvSequence.Rows(i).Cells(SELECTED).Value = True) Then
                    Me.dgvSequence.Rows(i).Cells(WAFER_FLOW).Value = strWaferFlowName
                End If
            Next
            Dim WfFlow As AVPLib.DataManagerment.WaferFlow = AVPLib.ContainerData.GetWaferFlowbyName(strWaferFlowName)
            If WfFlow IsNot Nothing Then
                ShowWaferFlowImageToGUI(WfFlow)
            End If
            Me.m_dtSequence.AcceptChanges()
            Me.dgvSequence.Refresh()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' ClearSelectedRow: clear the selected Row in the Grid 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ClearSelectedRow(Optional ByVal blnKeepSelected As Boolean = False)
        AVPLib.Log.guiLogger.Info("Enter ClearSelectedRow")
        Try
            Dim i As Integer = 0
            Dim blnStop As Boolean = True
            For i = 0 To m_intNoSlots - 1
                If Me.dgvSequence.Rows(i).Cells(SELECTED).Value = True Then
                    Me.dgvSequence.Rows(i).Cells(SELECTED).Value = False
                    Me.dgvSequence.Rows(i).Cells(WAFER_FLOW).Value = ""
                    If Me.dgvSequence.CurrentCell.RowIndex = i Then
                        Me.picShowWaferFlow.Image = Nothing
                    End If
                End If

            Next
            Me.dgvSequence.Refresh()
            Me.m_dtSequence.AcceptChanges()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ClearSelectedRow")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-09-01</date>
    ''' </author>
    ''' <summary>
    '''ResetGridStyle
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub ResetGridStyle()
        AVPLib.Log.guiLogger.Info("Enter ResetGridStyle")
        Try
            For i As Integer = 0 To Me.dgvSequence.Rows.Count - 1
                If Me.dgvSequence.Rows(i).Cells(WAFER_FLOW).Value = AVPLib.ConstEnum.EMPTY_STR Then
                    Me.dgvSequence.Rows(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
                    Me.dgvSequence.Rows(i).Height = GRID_HEIGHT_STYLE
                Else
                    Me.dgvSequence.Rows(i).DefaultCellStyle.BackColor = Color.White
                    Me.dgvSequence.Rows(i).Height = GRID_HEIGHT_DEFAULT
                End If
                Me.dgvSequence.AllowUserToResizeRows = False
            Next
            Me.dgvSequence.Refresh()
            ''scroll to bottom (slot 1)

            If Me.dgvSequence.RowCount > 0 Then
                Me.dgvSequence.FirstDisplayedScrollingRowIndex = Me.dgvSequence.RowCount - 1
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ResetGridStyle")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    '''Store the Grid to m_currentSeqWaferFlow
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StoreGUIToObj(ByRef currentSeqWaferFlow As AVPLib.DBWaferList)
        AVPLib.Log.guiLogger.Info("Enter StoreGUIToObj")
        Dim wfFlow As AVPLib.DataManagerment.WaferFlow = Nothing
        Dim arrWaferList As ArrayList = Nothing
        Try
            arrWaferList = New ArrayList
            Dim int_MaxLoadLockSlot As Integer = RobotConfigurationValues.LOADLOCKA_SLOTS
            
            For row As Integer = int_MaxLoadLockSlot - 1 To 0 Step -1
                    Dim WFSlot As New AVPLib.DBWaferSlot
                    Dim WFSequence As New AVPLib.DBWaferSeq
                    Dim arrSeqStepList As New ArrayList
                    Dim arrStepList As New List(Of String)

                If row < Me.dgvSequence.RowCount Then
                    WFSlot.Slot = Me.dgvSequence.Rows(row).Cells(SLOT).Value
                    If Not String.IsNullOrEmpty(Me.dgvSequence.Rows(row).Cells(WAFER_FLOW).Value) Then
                    WFSequence.SeqName = Me.dgvSequence.Rows(row).Cells(WAFER_FLOW).Value
                    Else
                        WFSequence.SeqName = ""
                    End If
                    WFSequence.SeqStepList = arrSeqStepList

                    '''''''''''''''''store the LoopInfo
                    wfFlow = AVPLib.ContainerData.GetWaferFlowbyName(Me.dgvSequence.Rows(row).Cells(WAFER_FLOW).Value)
                    If wfFlow IsNot Nothing Then
                        arrStepList = AVPLib.SequenceLib.ParseLoopToStep(wfFlow, wfFlow.StepList.Count)
                    End If
                    WFSequence.StepList = arrStepList
                    ''''''''''''''''''''''''''''''''''''''''''''''
                    WFSlot.WaferSequence = WFSequence
                    arrWaferList.Add(WFSlot)
                End If
            Next
            If arrWaferList.Count < int_MaxLoadLockSlot Then
                For i As Integer = arrWaferList.Count To int_MaxLoadLockSlot - 1
                    Dim WFSlot As New AVPLib.DBWaferSlot
                    Dim WFSequence As New AVPLib.DBWaferSeq
                    Dim arrSeqStepList As New ArrayList
                    Dim arrStepList As New List(Of String)

                    WFSlot.Slot = (i + 1).ToString()
                    WFSequence.SeqName = ""
                    WFSequence.SeqStepList = arrSeqStepList
                    WFSequence.StepList = arrStepList
                    WFSlot.WaferSequence = WFSequence
                    arrWaferList.Add(WFSlot)
                Next
            End If

            If arrWaferList.Count > 0 Then
                currentSeqWaferFlow = New AVPLib.DBWaferList
                currentSeqWaferFlow.WaferList = arrWaferList
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        wfFlow = Nothing
        arrWaferList = Nothing
        AVPLib.Log.guiLogger.Info("Enter StoreGUIToObj")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-24</date>
    ''' </author>
    ''' <summary>
    ''' CleanGrid: Clean all the Grid (clear the master row, remove child row)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CleanGrid()
        AVPLib.Log.guiLogger.Info("Enter CleanGrid")
        Try
            For i As Integer = m_intNoSlots - 1 To 0 Step -1
                Me.dgvSequence.Rows(i).Cells(WAFER_FLOW).Value = ""
                Me.dgvSequence.Rows(i).Cells(SELECTED).Value = False
            Next
            Me.dgvSequence.Refresh()
            Me.picShowWaferFlow.Image = Nothing
            Me.picWaferFlow.Image = Nothing
            Me.picShowWaferFlow.Size = New Size(379, 126)
            Me.pnlShowWaferFlow.Refresh()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CleanGrid")
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' First Load
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearForm()
        Try
            Me.txtDescription.Text = AVPLib.ConstEnum.EMPTY_STR
            Me.dgvSequence.DataSource = Nothing
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
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
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Active Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveForm()
        Try
            Me.btnDelete.Enabled = (CurrentIsNew = False)
            Me.btnNew.Enabled = True
            Me.btnOpen.Enabled = True
            Me.btnSave.Enabled = True
            Me.btnSaveAs.Enabled = True
            Me.btnClearSelected.Enabled = True
            Me.dgvSequence.Enabled = True
            Me.txtDescription.Enabled = True
            Me.btnUnSelectAll.Enabled = True
            Me.btnSelectAll.Enabled = True

            If Me.dgvSequence.DataSource IsNot Nothing Then
                For i As Integer = 0 To Me.dgvSequence.Rows.Count - 1
                    If Me.dgvSequence.Rows(i).Cells(SLOT).Value = AVPLib.ConstEnum.EMPTY_STR Then
                        Me.dgvSequence.Rows(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
                        Me.dgvSequence.Rows(i).Height = GRID_HEIGHT_STYLE
                    Else
                        Me.dgvSequence.Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                        Me.dgvSequence.Rows(i).Height = GRID_HEIGHT_STYLE
                    End If
                Next
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Inactive Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InactiveForm()
        Try

            Me.btnDelete.Enabled = False
            Me.btnNew.Enabled = False
            Me.btnOpen.Enabled = (AVPLib.ContainerData.UserLogin IsNot Nothing)
            Me.btnSave.Enabled = False
            Me.btnSaveAs.Enabled = False
            Me.btnClearSelected.Enabled = False
            Me.txtDescription.Enabled = False
            Me.btnUnSelectAll.Enabled = False
            Me.btnSelectAll.Enabled = False
            'End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Inactive Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DrawWaferFlow(ByVal pe As Graphics, ByVal listOfStep As List(Of String), ByVal ListOfStation As List(Of String), _
                              ByRef intTotalHeight As Integer, ByVal countLoop As Integer)
        Try
            Dim wfFont As New Font("Tahoma", 10, FontStyle.Bold)
            Dim StringLeft As Integer = 10
            Dim StringTop As Integer = 16

            RectWidth = GetWidthForImage(listOfStep.Count, countLoop)

            '2013-08-29 Tin Pham modified
            Dim newrect As New Rectangle(0, 0, RectWidth - 1, RectHeight - 1)
            Dim gradientBrush As New Drawing2D.LinearGradientBrush(newrect, Color.LightBlue, Color.White, Drawing2D.LinearGradientMode.Vertical)
            Dim childPicture As PictureBox
            For i As Integer = 0 To listOfStep.Count - 1
                Dim picY As Integer = RectTop + i * (RectHeight + RectSpace)
                childPicture = New PictureBox
                childPicture.Name = AVPLib.Utils.chamberID2ChamberName(ListOfStation.Item(i)) & "-" & listOfStep.Item(i)
                childPicture.Tag = listOfStep.Item(i)
                childPicture.AccessibleDescription = AVPLib.Utils.chamberID2ChamberName(ListOfStation.Item(i))
                childPicture.Location = New Point(RectLeft, picY)
                childPicture.Width = RectWidth
                childPicture.Height = RectHeight

                Dim bmp As Image = New Bitmap(RectWidth, RectHeight)
                Dim g As Graphics = Graphics.FromImage(bmp)
                g.FillRectangle(gradientBrush, newrect)
                g.DrawRectangle(Pens.Black, newrect)

                Dim chamberID As Short = 1
                Dim chamberType As String = String.Empty
                Dim stationName As String = String.Empty

                If (ListOfStation.Item(i) = RobotConfigurationValues.ANY_IBE_CHAMBER) Then
                    stationName = "AnyIBE"
                Else
                    stationName = AVPLib.Utils.chamberID2ChamberName(ListOfStation.Item(i))
                End If
                stationName = "[" & stationName & "] - " & listOfStep.Item(i)
                stationName = GetTextAfterMeasureString(childPicture, stationName)

                g.DrawString(stationName, wfFont, Brushes.Black, StringLeft, StringTop, StringFormat.GenericTypographic)
                childPicture.Image = bmp
                AddHandler childPicture.Click, AddressOf pic_Click
                picShowWaferFlow.Controls.Add(childPicture)
                g.Dispose()
            Next
            'end-------------------------------

            intTotalHeight = (listOfStep.Count) * (RectSpace + RectHeight) + RectHeight / 2 + RectTop

            wfFont.Dispose()
            gradientBrush.Dispose()
            newrect = Nothing
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2018-12-20 </date>
    ''' </author>
    ''' <summary>
    ''' Get Max Count Loop
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetMaxCountLoop(ByVal loopList) As Integer
        Dim maxCountLoop As Integer = 0

        Try
            For Each wfLoop As AVPLib.DataManagerment.WaferflowLoop In loopList
                If wfLoop.LoopCount > maxCountLoop Then
                    maxCountLoop = wfLoop.LoopCount
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return maxCountLoop
    End Function

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2018-12-20 </date>
    ''' </author>
    ''' <summary>
    ''' Get Width For Image
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetWidthForImage(ByVal countList As Integer, ByVal countLoop As Integer) As Integer
        Dim widthImage As Integer = 0
        Const lengScrollBar As Integer = 16
        Const numberView As Integer = 10     'number of WF can view without ScrollView 

        Try
            If countLoop > 999 Then
                widthImage = 410
            ElseIf countLoop > 99 Then
                widthImage = 420
            ElseIf countLoop > 9 Then
                widthImage = 430
            ElseIf countLoop > 0 Then
                widthImage = 440
            Else
                widthImage = 466
            End If

            If countList > numberView Then
                widthImage = widthImage - lengScrollBar
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return widthImage
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-07-29</date>
    ''' </author>
    ''' <summary>
    ''' GetTextAfterMeasureString
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetTextAfterMeasureString(ByVal objControl As Control, ByVal text As String) As String
        Dim strText As String = text

        Try
            ' Calculate the fitted string
            Dim strLotIDCharFitted As Integer
            Dim linesFitted As Integer
            Dim f As Font = objControl.Font
            Dim rect As Rectangle = objControl.ClientRectangle
            rect.Width = rect.Width - 84
            m_SequenceNameGraphics = objControl.CreateGraphics()
            m_SequenceNameGraphics.MeasureString(text, f, rect.Size, m_StringFormat, strLotIDCharFitted, linesFitted)

            ' Use "..." for long string
            If strLotIDCharFitted < text.Length Then
                strText = text.Substring(0, strLotIDCharFitted) & "..."
                ValueToolTip.SetToolTip(objControl, text)
            Else
                ValueToolTip.SetToolTip(objControl, "")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Finally
            If m_SequenceNameGraphics IsNot Nothing Then
                m_SequenceNameGraphics.Dispose()
            End If
        End Try

        Return strText
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-08-29</date>
    ''' </author>
    ''' <summary>
    ''' ClearControlsInPicture
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearControlsInPicture()
        Try
            For Each ctrl As PictureBox In picShowWaferFlow.Controls
                RemoveHandler ctrl.Click, AddressOf pic_Click
                ctrl.Dispose()
            Next
            picShowWaferFlow.Controls.Clear()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        LoadFieldName()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal blnShowInQuickSequenceDialog As Boolean, ByVal blnIsReadOnly As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ShowInQuickSequenceDialog = blnShowInQuickSequenceDialog
        Me.IsReadOnly = blnIsReadOnly
        LoadFieldName()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub txtDescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.Click
        Dim pad As New KeyPad
        Dim Value As String = txtDescription.Text
        If pad.DisplayKeypad(Value, "Please input the description", False) = DialogResult.OK Then
            txtDescription.Text = Value
        End If
    End Sub
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2010-03-10</date>
    ''' </author>
    ''' <summary>
    ''' Check Sequence is In Use
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>   
    Private Function CheckSequenceInUse(ByVal SeqName As String) As Boolean
        'string active sequence in loadlock A&B
        Dim sLLASegID As String = ContainerForm.ProcessPanel.lpcLoadLockA.SeqID

        If sLLASegID = SeqName And (Not (ContainerForm.ProcessPanel.lpcLoadLockA.btnStart.Text = START)) Then
            ''scheduler is running
            Return True
        End If
        '''else return false
        Return False
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-09-17 </date>
    ''' </author>
    ''' <summary>
    ''' IsSequenceInUseScheduler
    ''' </summary>
    ''' <param name=""></param>
    ''' <param name=""></param>
    ''' <remarks></remarks>
    Private Function IsSequenceInUseScheduler(ByVal sFileName As String, ByVal sTitleOfErrorMsg As String, ByVal sErrorMsg As String) As Boolean
        Dim blResult As Boolean = False
        Try
            blResult = CheckSequenceInUse(sFileName)
            If blResult Then
                Utils.ShowAVPMessageBox("This sequence in use. Can not " & sErrorMsg, sTitleOfErrorMsg, MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                      AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                      "[Main Screen] This sequence in use. Can not " & sErrorMsg)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blResult
    End Function

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

End Class
