Public Class CORONA_MagnatronController

    Private m_blnIsOnline As Boolean = False
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            btnMag1RotationStart.Enabled = Not (m_blnIsOnline)
            btnMag2RotationStart.Enabled = Not (m_blnIsOnline)
            btnMag3RotationStart.Enabled = Not (m_blnIsOnline)
            btnMag4RotationStart.Enabled = Not (m_blnIsOnline)
        End Set
    End Property

End Class
