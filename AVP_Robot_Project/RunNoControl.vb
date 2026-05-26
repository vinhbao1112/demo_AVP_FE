Public Class RunNoControl

    Private Sub RunNoControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If AVPLib.ConstEnum.NUM_1000 <= AVPLib.RobotConfigurationValues.RUN_SCHEDULER_NO AndAlso AVPLib.RobotConfigurationValues.RUN_SCHEDULER_NO <= AVPLib.ConstEnum.NUM_9999 Then
            txtRunNo.Text = AVPLib.RobotConfigurationValues.RUN_SCHEDULER_NO
        End If
    End Sub
End Class
