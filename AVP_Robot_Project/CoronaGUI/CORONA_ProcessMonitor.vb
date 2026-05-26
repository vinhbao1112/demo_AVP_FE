Public Class CORONA_ProcessMonitor

    Private m_blnIsOnline As Boolean = False
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-10-05</date>
    ''' <summary>
    ''' Set tooltip for recipe name when text longer than textbox width.
    ''' </summary>
    Private Sub txtRecipe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecipe.TextChanged
        Try
            Dim toolTipText As String = String.Empty
            Dim sizeText As SizeF = TextRenderer.MeasureText(txtRecipe.Text, txtRecipe.Font)
            If txtRecipe.Width < sizeText.Width Then
                toolTipText = txtRecipe.Text
            End If
            screenToolTip.SetToolTip(txtRecipe, toolTipText)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

End Class
