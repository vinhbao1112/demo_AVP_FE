Public Class CORONA_VatValveController
    Private m_blnIsOnline As Boolean = False

    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            txtPressure.Enabled = Not (m_blnIsOnline)
            txtPressure_Percent.Enabled = Not (m_blnIsOnline)
            txtTeach.Enabled = Not (m_blnIsOnline)
            btnAutoZero.Enabled = Not (m_blnIsOnline)
            btnSizeAdjust.Enabled = Not (m_blnIsOnline)
            btnTeach.Enabled = Not (m_blnIsOnline)
        End Set
    End Property

    Private Sub txtPressure_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPressure.TextChanged
        Try
            If Not txtPressure.Text = String.Empty AndAlso Single.Parse(txtPressure.Text) > 0.0F Then
                txtPressure_Percent.Text = String.Empty
            ElseIf Not txtPressure.Text = String.Empty AndAlso Single.Parse(txtPressure.Text) = 0.0F Then
                txtPressure.Text = String.Empty
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.Message)
        End Try

    End Sub

    Private Sub txtPressure_Percent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPressure_Percent.TextChanged
        Try
            If Not txtPressure_Percent.Text = String.Empty AndAlso Single.Parse(txtPressure_Percent.Text) > 0.0F Then
                txtPressure.Text = String.Empty
            ElseIf Not txtPressure_Percent.Text = String.Empty AndAlso Single.Parse(txtPressure_Percent.Text) = 0.0F Then
                txtPressure_Percent.Text = String.Empty
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.Message)
        End Try
    End Sub

End Class
