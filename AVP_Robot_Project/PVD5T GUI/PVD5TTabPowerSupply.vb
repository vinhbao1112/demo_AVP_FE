Imports AVPLib
Imports AVPLib.Business
Imports AVPLib.XMLResources

Public Class PVD5TTabPowerSupply
#Region "Constructors & Dispose"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.AutoScaleMode = AutoScaleMode.None
        DCTargetPowerSupply.PSType = "DCTarget"
        Dim tabIndex As Integer = Me.TabTargetPowerSupply.TabPages.IndexOf(tabRF)
        TabTargetPowerSupply.SetTabCommunicationStatus(tabIndex, RFTargetPowerSupply.HeaderStatus)
    End Sub

    Public Event TargetSwitched(targetSelectedIndex As PVD4TargetControl.TargetIndexs)

    Private Const TAB_RF As String = "01"
    Private Const TAB_DC As String = "02"

    Private Sub TargetPowerSupply_TargetSwitched(ByVal targetSelectedIndex As AVP_Robot_Project.PVD4TargetControl.TargetIndexs) Handles RFTargetPowerSupply.TargetSwitched, DCTargetPowerSupply.TargetSwitched
        Try
            RaiseEvent TargetSwitched(targetSelectedIndex)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub RFTargetHeaderStatus_Change(ByVal sender As Object, ByVal e As EventArgs) Handles RFTargetPowerSupply.HeaderStatusChange
        Try
            Dim tabIndex As Integer = Me.TabTargetPowerSupply.TabPages.IndexOf(tabRF)
            TabTargetPowerSupply.SetTabCommunicationStatus(tabIndex, RFTargetPowerSupply.Header.Status)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub DCTargetHeaderStatus_Change(ByVal sender As Object, ByVal e As EventArgs) Handles DCTargetPowerSupply.HeaderStatusChange
        Try
            Dim tabIndex As Integer = Me.TabTargetPowerSupply.TabPages.IndexOf(tabDC)
            TabTargetPowerSupply.SetTabCommunicationStatus(tabIndex, DCTargetPowerSupply.Header.Status)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Friend Sub HideTab(tab As String)
        TabTargetPowerSupply.HideTab(tab)
    End Sub

    Friend Sub SetupTarget(targetVisible As Boolean, target2Visible As Boolean, target3Visible As Boolean, target4Visible As Boolean, target5Visible As Boolean)
        SetupTarget(targetVisible, target2Visible, target3Visible, target4Visible, target5Visible, RFTargetPowerSupply)
        SetupTarget(targetVisible, target2Visible, target3Visible, target4Visible, target5Visible, DCTargetPowerSupply)
    End Sub

    Friend Sub SetupTarget(targetVisible As Boolean, target2Visible As Boolean, target3Visible As Boolean,
                           target4Visible As Boolean, target5Visible As Boolean, targetPowerSupply As PVD5TBiasPowerSupply)
        targetPowerSupply.Target1Install = targetVisible
        targetPowerSupply.Target2Install = target2Visible
        targetPowerSupply.Target3Install = target3Visible
        targetPowerSupply.Target4Install = target4Visible
        targetPowerSupply.Target5Install = target5Visible
        targetPowerSupply.ArrangTarget()
    End Sub

    Friend Sub SetupSourceMessageBox(name As String)
        SetupSourceMessageBox(name, RFTargetPowerSupply)
        SetupSourceMessageBox(name, DCTargetPowerSupply)
    End Sub

    Friend Sub SetupSourceMessageBox(name As String, targetPowerSupply As PVD5TBiasPowerSupply)
        Dim typeOfChamberSupport As String = targetPowerSupply.txtForwardPowerRight.TypeOfChamberSupport.ToString()
        targetPowerSupply.txtForwardPowerRight.SourceOfMessageBox = name & "." & typeOfChamberSupport & ".TargetPowerSupply"
        targetPowerSupply.txtC1Right.SourceOfMessageBox = name & "." & typeOfChamberSupport & ".TargetPowerSupply"
        targetPowerSupply.txtC2Right.SourceOfMessageBox = name & "." & typeOfChamberSupport & ".TargetPowerSupply"
        targetPowerSupply.txtDCForwardPowerRight.SourceOfMessageBox = name & "." & typeOfChamberSupport & ".TargetPowerSupply"
        targetPowerSupply.txtPulseFrequencyRight.SourceOfMessageBox = name & "." & typeOfChamberSupport & ".TargetPowerSupply"
        targetPowerSupply.txtPulseWidthRight.SourceOfMessageBox = name & "." & typeOfChamberSupport & ".TargetPowerSupply"
        targetPowerSupply.txtRampTimeRight.SourceOfMessageBox = name & "." & typeOfChamberSupport & ".TargetPowerSupply"
        targetPowerSupply.ChamberName = name
    End Sub

    Friend Sub TurnOnOffTargetxSwitch(nIndex As Object, coronaTarget As PVD5TTargetControl, targetPowerSupply As PVD5TBiasPowerSupply)
        Dim sbOff As SL_CustomButton.DisplayStatus = SL_CustomButton.DisplayStatus.Off
        Dim sbOn As SL_CustomButton.DisplayStatus = SL_CustomButton.DisplayStatus.On

        ' Turn off all target switches off first (avoid repetition)
        targetPowerSupply.btnTarget1Switch.Status = sbOff
        targetPowerSupply.btnTarget2Switch.Status = sbOff
        targetPowerSupply.btnTarget3Switch.Status = sbOff
        targetPowerSupply.btnTarget4Switch.Status = sbOff
        targetPowerSupply.btnTarget5Switch.Status = sbOff

        Dim magRotating As Boolean = False
        Select Case nIndex
            Case 1
                targetPowerSupply.btnTarget1Switch.Status = sbOn
                magRotating = (targetPowerSupply.btnMag1RotationStart.Status = sbOn)
            Case 2
                targetPowerSupply.btnTarget2Switch.Status = sbOn
                magRotating = (targetPowerSupply.btnMag2RotationStart.Status = sbOn)
            Case 3
                targetPowerSupply.btnTarget3Switch.Status = sbOn
                magRotating = (targetPowerSupply.btnMag3RotationStart.Status = sbOn)
            Case 4
                targetPowerSupply.btnTarget4Switch.Status = sbOn
                magRotating = (targetPowerSupply.btnMag4RotationStart.Status = sbOn)
            Case 5
                targetPowerSupply.btnTarget5Switch.Status = sbOn
                magRotating = (targetPowerSupply.btnMag5RotationStart.Status = sbOn)
            Case 0
                ' No target selected: ensure corona target is off
                coronaTarget.TargetStatus = DisplayStatus.Off
                Exit Sub
            Case Else
                AVPLib.Log.avpLogger.Error("Error in TurnOnOffTargetxSwitch - invalid index: " & If(nIndex Is Nothing, "Nothing", nIndex.ToString()))
                coronaTarget.TargetStatus = DisplayStatus.Off
                Exit Sub
        End Select
        targetPowerSupply.txtMagnatron.Text = If(magRotating, ConstantAndEnum.STR_ROTATING, String.Empty)
    End Sub

    Friend Sub UpdateTargetMode(value As String)
        If value = TAB_RF Then
            TabTargetPowerSupply.SelectedTab = tabRF
        ElseIf value = TAB_DC Then
            TabTargetPowerSupply.SelectedTab = tabDC
        End If
    End Sub
#End Region
End Class
