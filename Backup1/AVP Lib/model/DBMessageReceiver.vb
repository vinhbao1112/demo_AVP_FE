Public Class DBMessageReceiver
#Region "Class Constants & Variables"
    Private m_Code As String
    Private m_Value As String
    Private m_Sent As Boolean
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Code
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Code() As String
        Get
            Return m_Code
        End Get
        Set(ByVal value As String)
            Me.m_Code = value
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
            Me.m_Value = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Sent
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Sent() As Boolean
        Get
            Return m_Sent
        End Get
        Set(ByVal value As Boolean)
            Me.m_Sent = value
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
    ''' <param name="Code"></param>
    ''' <param name="Value"></param>
    ''' <param name="Sent"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Code As String, ByVal Value As String, ByVal Sent As Boolean)
        Me.m_Code = Code
        Me.m_Value = Value
        Me.m_Sent = Sent
    End Sub
#End Region
End Class
