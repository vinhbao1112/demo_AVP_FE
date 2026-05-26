Public Class AppLogoPanel
    Private m_frmCompanyInfoFrm As AVPComapnyPopupForm

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            If My.Application.Info.Copyright.Contains("AVP") Then
                picAVP.Image = My.Resources.AVPLogoNew
                AddHandler picAVP.Click, AddressOf picAVP_Click
                picAVP.Cursor = Cursors.Hand
            Else
                picAVP.Image = My.Resources.CTCLogo
                picAVP.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub picAVP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            m_frmCompanyInfoFrm = New AVPComapnyPopupForm()
            m_frmCompanyInfoFrm.Show()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub
End Class
