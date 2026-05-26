Imports AVPLib
Public Class ExitFrm
    Public Delegate Sub CommunicationState(ByVal state As String)

    Private Sub ExitFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tmrMonitor.Enabled = False
        Threading.ThreadPool.QueueUserWorkItem(AddressOf AVPUnInit, Me)
    End Sub

    Private Sub AVPUnInit(ByVal state As Object)
        Dim objFrm As ExitFrm = state
        Try
            Dim m_objDnetAppController As AVPLib.Business.DeviceNetAppController = AVPLib.Business.ControllerManager.GetController(ConstEnum.Equipments.DeviceNetApp.ToString())
            'if CXX is device net system -> run clean up sequence....
            If (RobotConfigurationValues.DEVICENET_INSTALLED AndAlso Not AVPLib.RobotConfigurationValues.DEVICENETAPP_VISIBLE) OrElse _
                  (RobotConfigurationValues.DEVICENETAPP_VISIBLE AndAlso m_objDnetAppController.ExitDeviceNetApp) Then
                objFrm.SetText("Start clean up sequence...")
                objFrm.SetText("Clear All Alarm Message.")
                MessageManager.ClearAllAlarms(True) 'remove all 

                AVPLib.Business.AVPCore.Instance().CleanUpBeforeExit(AddressOf SetText)
                objFrm.SetText("<Finish>")
            Else
                objFrm.SetText("Start closing application....please wait")
                System.Threading.Thread.Sleep(3000)
                objFrm.SetText("<Finish>")
            End If
           
        Catch ex As Exception
            objFrm.SetText("<Finish>")
        End Try
    End Sub

    Private Sub SetText(ByVal strStatus As String)
        If txtOutput.InvokeRequired Then
            Me.Invoke(New CommunicationState(AddressOf SetText), strStatus)
        Else
            If strStatus = "<Finish>" Then
                tmrMonitor.Interval = 100
                tmrMonitor.Enabled = True
            Else
                txtOutput.AppendText(strStatus)
                txtOutput.AppendText(vbCrLf)
            End If
        End If
    End Sub

    Private Sub ExitFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.Alt) And (e.KeyValue = Keys.F4) Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtOutput_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOutput.KeyDown
        If (e.Alt) And (e.KeyValue = Keys.F4) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tmrMonitor_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMonitor.Tick
        tmrMonitor.Enabled = False
        SetText("Shutting down core components...")
        AVPLib.Business.AVPCore.Instance().UnInitialize() ' Must init first
        SetText("Shutting down all controllers...")
        AVPLib.Business.ControllerManager.Dispose()
        AVPLib.Communication.TerminalDriver.TSCommandManager.Dispose()
        AVPLib.Communication.TerminalDriver.TransactionManager.Dispose()
        SetText("Shutting down all connections...")
        AVPLib.Communication.ConnectionManager.Dispose()
        SetText("Done")
        Me.Close()
    End Sub
End Class