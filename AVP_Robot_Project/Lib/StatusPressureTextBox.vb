Public Class StatusPressureTextBox
    Inherits StatusTextBox

    Public Sub New(ByVal txtManagedTextBox As TextBox)
        MyBase.New(txtManagedTextBox)
    End Sub

    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            If (Me.Parent.Name.IndexOf("cbcChamber1") > -1) Then
                If (Value.IndexOf("IG") > -1) Then
                    Value = ContainerForm.ProcessPanel.cbcChamber1.txtIG.Text
                ElseIf (Value.IndexOf("CG") > -1) Then
                    Value = ContainerForm.ProcessPanel.cbcChamber1.txtCG.Text
                End If
            ElseIf (Me.Parent.Name.IndexOf("cbcChamber2") > -1) Then
                If (Value.IndexOf("IG") > -1) Then
                    Value = ContainerForm.ProcessPanel.cbcChamber2.txtIG.Text
                ElseIf (Value.IndexOf("CG") > -1) Then
                    Value = ContainerForm.ProcessPanel.cbcChamber2.txtCG.Text
                End If

            ElseIf (Me.Parent.Name.IndexOf("cbcChamber3") > -1) Then
                If (Value.IndexOf("IG") > -1) Then
                    Value = ContainerForm.ProcessPanel.cbcChamber3.txtIG.Text
                ElseIf (Value.IndexOf("CG") > -1) Then
                    Value = ContainerForm.ProcessPanel.cbcChamber3.txtCG.Text
                End If
            ElseIf Me.Name = "txtProcPressure" Then
                Value = Utils.SignificantFigures(Value)
            End If
            MyBase.ChangeStatus(Me.GetIdentification(), Value)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub

End Class
