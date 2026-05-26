Public Class ToolID
    Private m_TextColor As Color = Color.Wheat
    Private m_toolID As String = String.Empty
    Public Property ToolID() As String
        Get
            Return m_toolID
        End Get
        Set(ByVal value As String)
            m_toolID = value
            Me.Label1.Text = m_toolID
        End Set
    End Property
    Public Property TextColor() As Color
        Get
            Return m_TextColor
        End Get
        Set(ByVal value As Color)
            m_TextColor = value
            Me.Label1.ForeColor = m_TextColor
        End Set
    End Property
End Class
