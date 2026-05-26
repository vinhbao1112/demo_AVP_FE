Public Class DBParameterValue
#Region "Class Constants & Variables"
    Private m_Name As String
    Private m_Value As String
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Name
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal value As String)
            m_Name = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Value
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Value() As String
        Get
            Return m_Value
        End Get
        Set(ByVal value As String)
            m_Value = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub
    Public Sub New(ByVal Name As String, ByVal Value As String)
        Me.m_Name = Name
        Me.m_Value = Value
    End Sub
#End Region
End Class
