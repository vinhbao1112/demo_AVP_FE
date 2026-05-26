Public Class CORONA_HeaterControl
    Private m_blnIsOnline As Boolean = False
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            btnHeaterZone1Status.Enabled = Not (m_blnIsOnline)
            btnHeaterZone2Status.Enabled = Not (m_blnIsOnline)
            txtHeaterZone1SP.Enabled = Not (m_blnIsOnline)
            txtHeaterZone2SP.Enabled = Not (m_blnIsOnline)
        End Set
    End Property
End Class
