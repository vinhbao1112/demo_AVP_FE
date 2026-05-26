Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum
Public Class CycleTransferWaferControl
    Const CYCLE_WAFER As String = "Cycle Wafer"
    Public IsRobotGoToStation As Boolean = False
    Public IsRobotChangeStatus As Boolean = False
    Private m_blnIsOnline As Boolean = False
    Private m_blIsLLAShowPopup As Boolean = True
#Region "Properties"
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            chkInCycleModeA.Enabled = Not m_blnIsOnline
            cbLLAStopCycleAt.Enabled = Not m_blnIsOnline
            txtLLAMaxCycleCount.Enabled = Not m_blnIsOnline
        End Set
    End Property
    Public Property IsLLAShowPopup() As Boolean
        Get
            Return m_blIsLLAShowPopup
        End Get
        Set(ByVal value As Boolean)
            m_blIsLLAShowPopup = value
        End Set
    End Property
#End Region
#Region "Protected method"
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
            m_stoStatusObject.AddChild(New StatusCheckbox(Me.chkInCycleModeA))
            m_stoStatusObject.AddChild(New StatusCheckbox(Me.chkRunWithRecipeA))
            m_stoStatusObject.AddChild(New StatusCheckbox(Me.cbLLAStopCycleAt))
            m_stoStatusObject.AddChild(New SL_StatusTextBox(txtLLAMaxCycleCount))
            txtLLAMaxCycleCount.ParentStatusObj = m_stoStatusObject
            txtLLAMaxCycleCount.Clickable = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Private methods"
    Private Sub chkInCycleModeA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInCycleModeA.CheckedChanged
        Dim strMessageLL As String = AVPLib.ContainerData.GetMessageText("TurnCycleWaferModeOnLoadLock")
        Dim IsTurnOn As Boolean = chkInCycleModeA.Checked Or cbLLAStopCycleAt.Checked
        If AVPRobotMain.OnlineRemote = False Then
            If (ContainerForm.ProcessPanel.lpcLoadLockA.IsInCycleMode <> IsTurnOn) Then
                Utils.ShowAVPMessageBox(String.Format(strMessageLL, _
                                                        IIf(IsTurnOn, "ON", "OFF")), _
                                                        CYCLE_WAFER & " " & LLA_STR, _
                                                        MessageBoxIcon.Exclamation, _
                                                        MessageBoxButtons.OK)
            End If
        End If

        If (chkInCycleModeA.Checked) Then
            cbLLAStopCycleAt.Checked = False
            cbLLAStopCycleAt.Enabled = False
            txtLLAMaxCycleCount.Clickable = False
            txtLLAMaxCycleCount.Text = 0
        Else
            cbLLAStopCycleAt.Enabled = True And (Not m_blnIsOnline)
            txtLLAMaxCycleCount.Clickable = True And (Not m_blnIsOnline)
        End If

        Dim strValue As String = (IsTurnOn).ToString
        m_stoStatusObject.RequestStatus(chkInCycleModeA.Name, strValue)
        m_stoStatusObject.RequestStatus(txtLLAMaxCycleCount.Name, txtLLAMaxCycleCount.Text)

        strValue = chkRunWithRecipeA.Checked.ToString()
        m_stoStatusObject.RequestStatus(chkRunWithRecipeA.Name, strValue)
        If ContainerForm.ProcessPanel.lpcLoadLockA.Header.Status = DisplayStatus.Off Then
            ContainerForm.ProcessPanel.lpcLoadLockA.Header.ForeColor = IIf(IsTurnOn, Color.Red, Color.White)
        ElseIf ContainerForm.ProcessPanel.lpcLoadLockA.Header.Status = DisplayStatus.On Then
            ContainerForm.ProcessPanel.lpcLoadLockA.Header.ForeColor = IIf(IsTurnOn, Color.Red, Color.Black)
        End If
        ContainerForm.ProcessPanel.lpcLoadLockA.IsInCycleMode = IsTurnOn

        Utils.LogUserEvent(sender, "TM Screen", "Cycle")
        
    End Sub

#End Region


    Private Sub cbLLAStopCycleAt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLLAStopCycleAt.CheckedChanged
        Dim strMessageLL As String = AVPLib.ContainerData.GetMessageText("TurnCycleWaferModeOnLoadLock")
        Dim IsTurnOn As Boolean = chkInCycleModeA.Checked Or cbLLAStopCycleAt.Checked

        If (cbLLAStopCycleAt.Checked) Then

            If (txtLLAMaxCycleCount.Text = "0") Then
                txtLLAMaxCycleCount.ShowPad()
            End If

            'check text again
            If Not cbLLAStopCycleAt.Checked Then
                Exit Sub
            End If
            Dim currentCycleCount As Integer = CInt(txtLLAMaxCycleCount.Text)
            Dim reCheck As Boolean = CheckNewLLAMaxCycleCount(IsTurnOn, currentCycleCount)

            If Not reCheck Then
                cbLLAStopCycleAt.Checked = False
                txtLLAMaxCycleCount.Clickable = True And (Not m_blnIsOnline)
                txtLLAMaxCycleCount.Text = "0"
                Exit Sub
            Else
                txtLLAMaxCycleCount.Clickable = True And (Not m_blnIsOnline)
                chkInCycleModeA.Checked = False
                chkInCycleModeA.Enabled = False
            End If
        Else
            chkInCycleModeA.Enabled = True And (Not m_blnIsOnline)
            txtLLAMaxCycleCount.Clickable = True And (Not m_blnIsOnline)
        End If

        If AVPRobotMain.OnlineRemote = False AndAlso IsLLAShowPopup = True Then
            If (ContainerForm.ProcessPanel.lpcLoadLockA.IsInCycleMode <> IsTurnOn) Then
                Utils.ShowAVPMessageBox(String.Format(strMessageLL, _
                                                        IIf(IsTurnOn, "ON", "OFF")), _
                                                        CYCLE_WAFER & " " & LLA_STR, _
                                                        MessageBoxIcon.Exclamation, _
                                                        MessageBoxButtons.OK)
            End If
        End If

        If (Not IsLLAShowPopup) Then
            IsLLAShowPopup = True
        End If

        Dim strValue As String = (IsTurnOn).ToString
        m_stoStatusObject.RequestStatus(chkInCycleModeA.Name, strValue)

        Dim strMaxCycleCount As String = "0"
        If (cbLLAStopCycleAt.Checked) Then
            strMaxCycleCount = txtLLAMaxCycleCount.Text
        End If

        m_stoStatusObject.RequestStatus(txtLLAMaxCycleCount.Name, strMaxCycleCount)

        strValue = chkRunWithRecipeA.Checked.ToString()
        m_stoStatusObject.RequestStatus(chkRunWithRecipeA.Name, strValue)
        If ContainerForm.ProcessPanel.lpcLoadLockA.Header.Status = DisplayStatus.Off Then
            ContainerForm.ProcessPanel.lpcLoadLockA.Header.ForeColor = IIf(IsTurnOn, Color.Red, Color.White)
        ElseIf ContainerForm.ProcessPanel.lpcLoadLockA.Header.Status = DisplayStatus.On Then
            ContainerForm.ProcessPanel.lpcLoadLockA.Header.ForeColor = IIf(IsTurnOn, Color.Red, Color.Black)
        End If
        ContainerForm.ProcessPanel.lpcLoadLockA.IsInCycleMode = IsTurnOn

        Utils.LogUserEvent(sender, "TM Screen", "Cycle")
    End Sub


    Private Sub txtLLAMaxCycleCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLLAMaxCycleCount.TextChanged
        Try
            If Not AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                Exit Sub
            End If

            If cbLLAStopCycleAt.Checked = True Then
                Dim currentCycleCount As Integer = CInt(txtLLAMaxCycleCount.Text)

                If currentCycleCount = 0 Then
                    cbLLAStopCycleAt.Checked = False
                    txtLLAMaxCycleCount.Clickable = True And (Not m_blnIsOnline)
                    Exit Sub
                End If

                Dim reCheck As Boolean = CheckNewLLAMaxCycleCount(True, currentCycleCount)

                If Not reCheck Then
                    txtLLAMaxCycleCount.Text = "0"
                Else
                    cbLLAStopCycleAt.Checked = True
                    chkInCycleModeA.Checked = False
                    chkInCycleModeA.Enabled = False
                    CheckCycleCount(sender, AVPLib.ConstEnum.Equipments.LoadLockA.ToString)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Huy Nguyen </name>
    '''    	<date> 2015-08-19</date>
    ''' </author>
    ''' <summary>
    ''' Check new cycle count in LLA is must:
    ''' - is greater than number of slot in chamber
    ''' - is multiple of number of slot
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CheckNewLLAMaxCycleCount(ByVal IsTurnOn As Boolean, ByVal currentCycleCount As Integer) As Boolean
        Dim result As Boolean = True
        Dim ExclamCycleWaferWrong = AVPLib.ContainerData.GetMessageText("ExclamCycleWaferWrong")
        Dim ExclamCycleWaferNotMultipleNumberOfLot = AVPLib.ContainerData.GetMessageText("ExclamCycleWaferNotMultipleNumberOfLot")
        Dim NoOfChambers As Integer = 3
        Dim numberOfSlot As Integer = 8

        Try
            For i As Integer = 1 To NoOfChambers
                Dim chamberName As String = AVPLib.ConstEnum.Chamber & i.ToString()
                Dim objSystemModule As AVPLib.SystemModule = Nothing

                If AVPLib.ContainerData.IsChamberVisible(chamberName, objSystemModule) Then
                    numberOfSlot = Math.Min(numberOfSlot, objSystemModule.MaxNumberOfSlot)
                End If
            Next

            If (currentCycleCount = 0) Then
                Utils.ShowAVPMessageBox(String.Format(ExclamCycleWaferWrong, _
                                                        IIf(IsTurnOn, "ON", "OFF")), _
                                                        CYCLE_WAFER & " " & LLA_STR, _
                                                        MessageBoxIcon.Exclamation, _
                                                        MessageBoxButtons.OK)
                result = False
            ElseIf (currentCycleCount Mod numberOfSlot) <> 0 Then
                Utils.ShowAVPMessageBox(String.Format(ExclamCycleWaferNotMultipleNumberOfLot, numberOfSlot), _
                                                        CYCLE_WAFER & " " & LLA_STR, _
                                                        MessageBoxIcon.Exclamation, _
                                                        MessageBoxButtons.OK)
                result = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return result
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-05-20</date>
    ''' </author>
    ''' <summary>
    ''' CheckCycleCount
    ''' </summary>
    Private Sub CheckCycleCount(ByVal sender As System.Object, ByVal loadlock As String)
        Try
            Dim objLoadLockCtrl As AVPLib.Business.LoadLockController = Nothing
            objLoadLockCtrl = AVPLib.Business.ControllerManager.GetController(loadlock)
            '
            If (objLoadLockCtrl IsNot Nothing AndAlso objLoadLockCtrl.CtrlJobId <> String.Empty) Then
                Dim objCtrlJob As AVPLib.Business.AVPControlJob = _
                         AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockCtrl.CtrlJobId)
                Dim textLLMaxCycleCount As TextBox = CType(sender, TextBox)
                If objCtrlJob IsNot Nothing AndAlso objCtrlJob.CycleCount >= textLLMaxCycleCount.Text Then
                    textLLMaxCycleCount.Text = objCtrlJob.MaxCycleCount
                    Utils.ShowAVPMessageBox("Please input value greater than " & objCtrlJob.CycleCount.ToString(), CYCLE_WAFER & " " & loadlock, MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub CheckBox_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInCycleModeA.EnabledChanged, cbLLAStopCycleAt.EnabledChanged
        If Not chkInCycleModeA.Checked AndAlso Not cbLLAStopCycleAt.Checked Then
            Return
        End If

        If Not m_blnIsOnline AndAlso Not sender.Checked Then
            sender.Enabled = False
        End If
    End Sub
End Class
