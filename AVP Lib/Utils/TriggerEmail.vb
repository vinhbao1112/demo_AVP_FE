Public Class TriggerEmail

    Private m_Name As String = String.Empty
    Private m_IsAlarm As Boolean = False
    Private m_IsPressure As Boolean = False
    Private m_IsScheduler As Boolean = False
    Private m_PressureInterval As Integer = 0
    Private m_PressureCount As Integer = 0

    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal value As String)
            m_Name = value
        End Set
    End Property

    Public Property IsAlarm() As Boolean
        Get
            Return m_IsAlarm
        End Get
        Set(ByVal value As Boolean)
            m_IsAlarm = value
        End Set
    End Property

    Public Property IsPressure() As Boolean
        Get
            Return m_IsPressure
        End Get
        Set(ByVal value As Boolean)
            m_IsPressure = value
        End Set
    End Property

    Public Property IsScheduler() As Boolean
        Get
            Return m_IsScheduler
        End Get
        Set(ByVal value As Boolean)
            m_IsScheduler = value
        End Set
    End Property

    Public Property PressureInterval() As Integer
        Get
            Return m_PressureInterval
        End Get
        Set(ByVal value As Integer)
            m_PressureInterval = value
        End Set
    End Property

    Public Property PressureCount() As Integer
        Get
            Return m_PressureCount
        End Get
        Set(ByVal value As Integer)
            m_PressureCount = value
        End Set
    End Property
End Class
