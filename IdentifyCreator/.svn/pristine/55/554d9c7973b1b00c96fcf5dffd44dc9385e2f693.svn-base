Public Class Form1

    Private Sub txtPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.Click, btnBrowse.Click
        If fbdlgDataOutput.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtPath.Text = fbdlgDataOutput.SelectedPath
        End If
    End Sub

    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        Dim strMacID = Utils.GetMacID()
        Dim strCPUId = Utils.GetCPUID()
        Dim strHardDrive = Utils.getUUID()
        If (Utils.ExportToInformationFile(strMacID, strCPUId, strHardDrive, txtPath.Text)) Then
            MessageBox.Show("Creating AVP.Information file is success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fbdlgDataOutput.SelectedPath = Application.StartupPath
        txtPath.Text = fbdlgDataOutput.SelectedPath
    End Sub
End Class
