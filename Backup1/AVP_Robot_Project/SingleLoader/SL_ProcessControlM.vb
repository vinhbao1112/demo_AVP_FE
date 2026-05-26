Public Class SL_ProcessControlM
    Protected Overrides Sub CreateStatusTree()
        Try
            m_stoStatusObject.Name = Me.Name
            ''m_stoStatusObject.AddChild () 'add all textbox and button in this panel
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
