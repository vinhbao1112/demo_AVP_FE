Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.Utils
Public Class PVDRunRecipe
#Region "Properties"
    Private m_RecipeName As String
    Private m_Chamber As String
    Private m_blnReal_Device_Enable As Boolean = False
    Private m_sf As StringFormat = Nothing
    Private m_RecipeNameGraphics As Graphics
    Private m_blnSupportSingleLoader As Boolean = False
    Private m_blnIsOnline As Boolean = False
    Public IsWaitResumeProcess As Boolean = False

    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            txtProcessRecipe.Enabled = IsAllowEnable(m_blnIsOnline)
            btnAbort.Enabled = IsAllowEnable(m_blnIsOnline) And IsEndCurrentStepActive()
            btnPause.Enabled = IsAllowEnable(m_blnIsOnline) And IsPauseResumeProcessActive()
            btnStart.Enabled = IsAllowEnable(m_blnIsOnline)
            If m_blnReal_Device_Enable Then
                If m_blnIsOnline Then
                    btnPauseRealDevice.Enabled = False
                Else
                    If IsWaitResumeProcess AndAlso AVPLib.ContainerData.Permission(PERMISSION_001) Then
                        btnPauseRealDevice.Enabled = True And IsPauseResumeProcessActive()
                    End If
                End If
            End If
        End Set
    End Property
#End Region


#Region "Protected method"
    Public Property Support_Single_Loader() As Boolean
        Get
            Return m_blnSupportSingleLoader
        End Get
        Set(ByVal value As Boolean)
            m_blnSupportSingleLoader = value
        End Set
    End Property

    Public Property Real_Device_Enable() As Boolean
        Get
            Return m_blnReal_Device_Enable
        End Get
        Set(ByVal value As Boolean)
            m_blnReal_Device_Enable = value
            If m_blnReal_Device_Enable Then
                btnPause.Visible = False
                btnPauseRealDevice.Visible = True
                btnPauseRealDevice.Enabled = False
                btnPauseRealDevice.Left = btnPause.Left
            Else
                btnPause.Visible = True
                btnPauseRealDevice.Visible = False
            End If
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Property of Chamber
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RecipeName() As String
        Get
            Return m_RecipeName
        End Get
        Set(ByVal value As String)
            m_RecipeName = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Property of Chamber
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Chamber() As String
        Get
            Return m_Chamber
        End Get
        Set(ByVal value As String)
            m_Chamber = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim sbcStart As New StatusIGCGButton(Me.btnStart)
            Dim sbcPause As New StatusIGCGButton(Me.btnPause)
            Dim sbcStatus As New StatusIGCGButton(Me.Header)
            Dim sbcAbort As New StatusIGCGButton(Me.btnAbort)
            Dim sbcProcessRecipe As New StatusTextBox(Me.txtProcessRecipe)
            m_stoStatusObject.Name = Me.Name

            m_stoStatusObject.AddChild(sbcStart)
            m_stoStatusObject.AddChild(sbcPause)
            m_stoStatusObject.AddChild(sbcStatus)
            m_stoStatusObject.AddChild(sbcAbort)
            m_stoStatusObject.AddChild(sbcProcessRecipe)
            ' For calculating the size of Recipe Name textbox
            m_sf = New StringFormat(StringFormatFlags.NoWrap)
            m_sf.LineAlignment = StringAlignment.Center
            m_sf.Alignment = StringAlignment.Near
            m_sf.Trimming = StringTrimming.EllipsisCharacter
            m_RecipeNameGraphics = txtProcessRecipe.CreateGraphics()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region


#Region "Events � Buttons � Forms�"

    Private Sub UpdateRecipeNameText()
        ' Calculate the fitted string
        Dim strLotIDCharFitted As Integer
        Dim linesFitted As Integer
        Dim f As Font = Me.txtProcessRecipe.Font
        Dim rect As Rectangle = txtProcessRecipe.ClientRectangle
        m_RecipeNameGraphics.MeasureString(txtProcessRecipe.Text, f, rect.Size, m_sf, strLotIDCharFitted, linesFitted)

        ' Use "..." for long string
        If strLotIDCharFitted < txtProcessRecipe.Text.Length Then
            txtProcessRecipe.Text = txtProcessRecipe.Text.Substring(0, strLotIDCharFitted) & "..."
            ValueToolTip.SetToolTip(txtProcessRecipe, Me.RecipeName)
        Else
            ValueToolTip.SetToolTip(txtProcessRecipe, Me.RecipeName)
        End If
    End Sub


    Private Sub txtProcessRecipe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcessRecipe.Click
        AVPLib.Log.guiLogger.Info("Enter txtRecipe_Click")
        Try
            If (EnableProcessRecipeText()) Then
                Dim frm As SelectRecipe = New SelectRecipe()
                frm.StationName = Me.Parent.Name
                frm.ShowDialog()
                If frm.DialogResult = DialogResult.OK Then
                    Me.Chamber = frm.StationName
                    Me.RecipeName = frm.SelectedRecipe
                    Me.txtProcessRecipe.Text = frm.SelectedRecipe '
                    Me.UpdateRecipeNameText() ' "..." for long string
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + AVPLib.Utils.chamberID2ChamberName(frm.StationName) + "]Select recipe " + Me.RecipeName)
                End If
                frm.Dispose()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txtRecipe_Click")
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        AVPLib.Log.guiLogger.Info("Enter btnStart_Click")
        '#05/24/2011 
        '# Recipe start button should not be enable when recipe is blank.  When user click start, it post an error.
        '#Begin fix: show popup if recipe name is blank.
        If String.IsNullOrEmpty(Me.txtProcessRecipe.Text) AndAlso Me.btnStart.Text = "Start" Then
            Utils.ShowAVPMessageBox("There is not recipe name. Recipe can not start.", "Run Recipe", MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
            Exit Sub
        End If
        'check recipe exist. When load/unload wafer, we will update recipe name again
        If Utils.CheckRecipeExisted(Me.txtProcessRecipe.Text, Me.Chamber) Then
            Me.RecipeName = Me.txtProcessRecipe.Text
        End If
        Try
            Dim objPanel As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
            Dim strMessageText As String = String.Empty
            If objPanel.ChamberType = AVPLib.SystemModule.ModuleType.IBE Then
                strMessageText = AVPLib.ContainerData.GetMessageText(STR_IBE + "." + btnStart.Name + "." + btnStart.Text)
            ElseIf objPanel.ChamberType = AVPLib.SystemModule.ModuleType.PVD Then
                strMessageText = AVPLib.ContainerData.GetMessageText(PVD + "." + btnStart.Name + "." + btnStart.Text)
            ElseIf objPanel.ChamberType = AVPLib.SystemModule.ModuleType.PVD4 Then
                strMessageText = AVPLib.ContainerData.GetMessageText(PVD4 + "." + btnStart.Name + "." + btnStart.Text)
            ElseIf objPanel.ChamberType = AVPLib.SystemModule.ModuleType.PVD5T Then
                strMessageText = AVPLib.ContainerData.GetMessageText(PVD5T + "." + btnStart.Name + "." + btnStart.Text)
            End If

            Dim chamberObj As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
            If chamberObj IsNot Nothing AndAlso chamberObj.IsConnect = False Then
                Utils.ShowAVPMessageBox("This PM is disconnected", Me.Name, MessageBoxIcon.Information, AVPMessageBox.AVPMessageBoxButton.OK)
                Exit Sub
            End If

            If Me.btnStart.Text = "Stop" Then
                If Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Information) = DialogResult.OK Then
                    If Me.btnPause.Text = "Resume" Then btnPause.Text = "Pause"
                    m_stoStatusObject.RequestStatus(Me.btnPause.Name, "Stop")
                    Me.btnStart.Text = "Stopping"
                    Me.btnPause.Enabled = False
                    Me.btnAbort.Enabled = False
                    Me.btnStart.Enabled = False
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                        "[" & AVPLib.Utils.chamberID2ChamberName(objPanel.Name) & " Screen] Stop Run Recipe")
                End If
            ElseIf Me.btnStart.Text = "Start" And Not String.IsNullOrEmpty(Me.RecipeName) Then
                Dim IsPMIsoValveClose As Boolean = AVPLib.Utils.IsChamberSlitValveClose(Me.Parent.Name)
                Dim IsWaferInside As Boolean = False
                Dim IsWaferCompleted As Boolean = False
                If objPanel.ChamberType = AVPLib.SystemModule.ModuleType.PVD Then
                    IsWaferInside = CType(objPanel, PVDPanel).ChuckControl.bicWaferInside.Visible()
                    If (IsWaferInside AndAlso CType(objPanel, IBEPanel).SLContainerBox.RotationFixture.WaferStatus = enumWaferStatus.eWaferComplete) Then
                        IsWaferCompleted = True
                    End If
                ElseIf objPanel.ChamberType = AVPLib.SystemModule.ModuleType.IBE Then
                    IsWaferInside = CType(objPanel, IBEPanel).SLContainerBox.RotationFixture.WaferStatus <> enumWaferStatus.eWaferNone
                    If (IsWaferInside AndAlso CType(objPanel, IBEPanel).SLContainerBox.RotationFixture.WaferStatus = enumWaferStatus.eWaferComplete) Then
                        IsWaferCompleted = True
                    End If
                ElseIf objPanel.ChamberType = AVPLib.SystemModule.ModuleType.PVD4 Then
                    IsWaferInside = CType(objPanel, CoronaPanel).IsHaveWaferInside(IsWaferCompleted)
                ElseIf objPanel.ChamberType = AVPLib.SystemModule.ModuleType.PVD5T Then
                    IsWaferInside = CType(objPanel, PVD5TPanel).IsHaveWaferInside(IsWaferCompleted)
                End If

                If (IsWaferCompleted) Then
                    strMessageText = AVPLib.ContainerData.GetMessageText(PVD + "." + btnStart.Name + "." + btnStart.Text + "." + "WaferCompleted")
                    Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Stop, AVPMessageBox.AVPMessageBoxButton.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                       "[" & AVPLib.Utils.chamberID2ChamberName(objPanel.Name) & " Screen] Can not Run Recipe - Wafer is completed")
                    Exit Sub
                End If

                If IsWaferInside AndAlso IsPMIsoValveClose Then
                    If Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Information) = DialogResult.OK Then
                        ' Send WaferID
                        m_stoStatusObject.RequestStatus(SendProcessWaferIDCmdMessage, String.Empty)
                        ' Send start processing.
                        m_stoStatusObject.RequestStatus(Me.btnPause.Name, Me.RecipeName + "(" + AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name) + ")")
                        Me.btnStart.Text = "Starting"
                        Me.btnPause.Enabled = False
                        Me.btnAbort.Enabled = False
                        Me.btnStart.Enabled = False
                        Dim ReplyValues As ArrayList = New ArrayList()
                        Dim strReplyValue As String = Me.RecipeName
                        ReplyValues.Add(strReplyValue)

                        Dim PropertyNames As ArrayList = New ArrayList()
                        PropertyNames.Add("Recipe")
                        AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.Parent.Name, PropertyNames, ReplyValues)

                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                       "[" & AVPLib.Utils.chamberID2ChamberName(objPanel.Name) & " Screen] Start Run Recipe: " & RecipeName)
                    End If
                ElseIf (Not IsPMIsoValveClose) Then
                    Utils.ShowAVPMessageBox("Slit Valve is not close", Me.Name, MessageBoxIcon.Stop, AVPMessageBox.AVPMessageBoxButton.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                       "[" & AVPLib.Utils.chamberID2ChamberName(objPanel.Name) & " Screen] Can not Run Recipe - Slit Valve is not close")
                Else
                    strMessageText = AVPLib.ContainerData.GetMessageText(PVD + "." + btnStart.Name + "." + btnStart.Text + "." + "NoWafer")
                    Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Stop, AVPMessageBox.AVPMessageBoxButton.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                       "[" & AVPLib.Utils.chamberID2ChamberName(objPanel.Name) & " Screen] Can not Run Recipe - No Wafer to run")
                End If
            ElseIf Me.btnStart.Text = "Starting" Or btnStart.Text = "Stopping" Then
                strMessageText = AVPLib.ContainerData.GetMessageText("PM.Processing")
                Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Information, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                       "[" & AVPLib.Utils.chamberID2ChamberName(objPanel.Name) & " Screen] User tried to click when Processing Recipe")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnStart_Click")
    End Sub

    Private Sub btnPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPause.Click
        AVPLib.Log.guiLogger.Info("Enter btnPause_Click")
        Try
            If Support_Single_Loader Then
                ''action code for Single Loader here
                Exit Sub
            End If
            ''
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(PVD + "." + btnPause.Name + "." + btnPause.Text)
            Dim chamberpnl As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
            If Me.btnPause.Text = "Resume" Then
                Dim objChamber As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Name)
                If objChamber IsNot Nothing AndAlso objChamber.IsSchedulerRunningInPM Then
                    strMessageText = "Scheduler is pausing. Please make online and resume in scheduler."
                    Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
                    Exit Sub
                End If
                If Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Information) = DialogResult.OK Then
                    Me.btnPause.Text = "Resuming"
                    Me.btnPause.Enabled = False
                    Me.btnAbort.Enabled = False
                    Me.btnStart.Enabled = False
                    m_stoStatusObject.RequestStatus(Me.btnPause.Name, "Resume")
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                      "[" & AVPLib.Utils.chamberID2ChamberName(chamberpnl.Name) & " Screen] Resume Run Recipe")
                End If
            ElseIf Me.btnPause.Text = "Pause" And Me.btnStart.Text = "Stop" Then
                If Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Information) = DialogResult.OK Then
                    Me.btnPause.Text = "Pausing"
                    Me.btnPause.Enabled = False
                    Me.btnAbort.Enabled = False
                    Me.btnStart.Enabled = False
                    m_stoStatusObject.RequestStatus(Me.btnPause.Name, "Pause")
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                      "[" & AVPLib.Utils.chamberID2ChamberName(chamberpnl.Name) & " Screen] Pause Run Recipe")
                End If
            ElseIf Me.btnPause.Text = "Pausing" Or btnPause.Text = "Resuming" Then
                strMessageText = AVPLib.ContainerData.GetMessageText(PVD + "." + "Processing")
                Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Information, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                      "[" & AVPLib.Utils.chamberID2ChamberName(chamberpnl.Name) & " Screen] User tried to Pause and Resume when Processing Recipe")
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnPause_Click")
    End Sub

    Private Sub btnAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbort.Click
        AVPLib.Log.guiLogger.Info("Enter btnPause_Click")
        Try
            If Support_Single_Loader Then
                ''action code for Single Loader here
                Exit Sub
            End If
            ''
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(PVD + "." + btnAbort.Name)
            ''recipe is running
            Dim chamberpnl As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
            If Me.btnPause.Text = "Pause" AndAlso btnStart.Text = "Stop" Then
                If Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Information) = DialogResult.OK Then
                    m_stoStatusObject.RequestStatus(Me.btnAbort.Name, "Abort")
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                      "[" & AVPLib.Utils.chamberID2ChamberName(chamberpnl.Name) & " Screen] Abort Run Recipe")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnPause_Click")
    End Sub
#End Region

    Protected Overrides Sub Finalize()
        If m_RecipeNameGraphics IsNot Nothing Then
            m_RecipeNameGraphics.Dispose()
        End If
        MyBase.Finalize()
    End Sub

    Private Sub txtProcessRecipe_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcessRecipe.MouseHover
        ValueToolTip.Active = False
        ValueToolTip.Active = True
    End Sub

    Private Sub btnPauseRealDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPauseRealDevice.Click
        btnPause_Click(btnPause, e)
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2012-03-27</date>
    ''' </author>
    ''' <summary>
    ''' IsEndCurrentStepActive
    ''' </summary>
    ''' <remarks></remarks>
    Public Function IsEndCurrentStepActive()
        If Me.btnPause.Text = "Pause" AndAlso btnStart.Text = "Stop" Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2012-03-27</date>
    ''' </author>
    ''' <summary>
    ''' IsPauseResumeProcessActive
    ''' </summary>
    ''' <remarks></remarks>
    Public Function IsPauseResumeProcessActive()
        If btnStart.Text = "Stop" Then
            Return True
        Else
            Return False
        End If
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2012-05-16</date>
    ''' </author>
    ''' <summary>
    ''' Enable process recipe text when button start = enable and button start text = start
    ''' </summary>
    ''' <remarks></remarks>
    Public Function EnableProcessRecipeText()
        Return (btnStart.Enabled = True AndAlso btnStart.Text = "Start")
    End Function
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-12-15</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name=""></param>
    ''' <param name=""></param>
    ''' <remarks></remarks>
    Private Sub btnQuickView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuickView.Click
        Try
            If String.IsNullOrEmpty(Me.txtProcessRecipe.Text) AndAlso Me.btnStart.Text = "Start" Then
                Utils.ShowAVPMessageBox("There is not recipe name. Recipe can not view.", "Quick View Recipe", MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
                Exit Sub
            End If
            'check recipe exist
            If Me.Chamber Is Nothing Then
                Me.Chamber = Me.Parent.Name
            End If
            'If Utils.CheckRecipeExisted(Me.txtProcessRecipe.Text, Me.Chamber) Then
            '    Me.RecipeName = Me.txtProcessRecipe.Text
            'End If
            If String.IsNullOrEmpty(Me.RecipeName) Then
                Dim chamber As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Chamber)
                If chamber IsNot Nothing Then
                    Me.RecipeName = chamber.Recipe
                End If
            End If

            Dim strPM As String = AVPLib.Utils.chamberID2ChamberName(Me.Chamber)
            Dim Title As String = strPM & "-" & Me.RecipeName
            If Not String.IsNullOrEmpty(Me.RecipeName) And Not String.IsNullOrEmpty(strPM) Then
                Utils.ShowQuickViewRecipe(Me.Chamber, Me.RecipeName, Title, False, True)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtProcessRecipe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcessRecipe.TextChanged
        UpdateRecipeNameText()
    End Sub
End Class
