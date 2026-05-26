Public Class DBGroupParameterValue
#Region "Class Constants & Variables"
    Private m_GroupCode As String
    Private m_ListParameterValues As ArrayList
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' GroupCode
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GroupCode() As String
        Get
            Return m_GroupCode
        End Get
        Set(ByVal value As String)
            m_GroupCode = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' List DBParameterValue
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ListParameterValues() As ArrayList
        Get
            Return m_ListParameterValues
        End Get
        Set(ByVal value As ArrayList)
            m_ListParameterValues = value
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
    Public Sub New(ByVal GroupCode As String, ByVal ListParameterValues As ArrayList)
        Me.m_GroupCode = GroupCode
        Me.m_ListParameterValues = ListParameterValues
    End Sub
#End Region
End Class
