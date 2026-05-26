Public Class DataRecipe

    Private m_DataVisible As Boolean = True
    Private m_Data As String = String.Empty

    Public Property DataVisible() As Boolean
        Get
            Return m_DataVisible
        End Get
        Set(ByVal value As Boolean)
            m_DataVisible = value
        End Set
    End Property

    Public Property Data() As String
        Get
            Return m_Data
        End Get
        Set(ByVal value As String)
            m_Data = value
        End Set
    End Property
End Class
