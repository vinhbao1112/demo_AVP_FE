Friend Class UnitEntry
    Implements IUnitEntry
    ' Properties
    Public Property Adder() As Double Implements IUnitEntry.Adder
        Get
            Return Me.m_Adder
        End Get
        Set(ByVal value As Double)
            Me.m_Adder = value
        End Set
    End Property

    Public Property DefaultSymbol() As String Implements IUnitEntry.DefaultSymbol
        Get
            Return Me.m_DefaultSymbol
        End Get
        Set(ByVal value As String)
            Me.m_DefaultSymbol = value
        End Set
    End Property

    Public Property Multiplier() As Double Implements IUnitEntry.Multiplier
        Get
            Return Me.m_Multiplier
        End Get
        Set(ByVal value As Double)
            Me.m_Multiplier = value
        End Set
    End Property

    Public Property Name() As String Implements IUnitEntry.Name
        Get
            Return Me.m_Name
        End Get
        Set(ByVal value As String)
            Me.m_Name = value
        End Set
    End Property

    Public Property PreAdder() As Double Implements IUnitEntry.PreAdder
        Get
            Return Me.m_PreAdder
        End Get
        Set(ByVal value As Double)
            Me.m_PreAdder = value
        End Set
    End Property

    ' Fields
    Private m_Adder As Double = 0
    Private m_DefaultSymbol As String = ""
    Private m_Multiplier As Double = 0
    Private m_Name As String = ""
    Private m_PreAdder As Double = 0
End Class

