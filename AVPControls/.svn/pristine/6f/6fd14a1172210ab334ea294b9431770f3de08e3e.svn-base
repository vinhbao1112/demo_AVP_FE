Public Class RelayControl
    Inherits AVPStatusControlBase

    Protected Overrides ReadOnly Property DefaultSize() As System.Drawing.Size
        Get
            Return New Size(11, 11)
        End Get
    End Property

    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        If Me.Status = AVPControls.AVPDataLib.DisplayStatus.On Then
            Return My.Resources.Resources.BgRelayOn
        Else
            Return My.Resources.Resources.BgRelayOff
        End If
    End Function

    Public Sub New()
        Me.IsTransparent = True
        Me.IsInitialized = True
        Me.AlphaValueForRegion = 0
        Me.ResumeUpdateView()
    End Sub
End Class
