Public Class DBRecipe
#Region "Class Constants & Variables"
    Private m_ChamberName As String
    Private m_ChamberNameActive As String
    Private m_ListChamber As ArrayList 'get list chamber names from chamber1, chamber3 detail.
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' ChamberName
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ChamberName() As String
        Get
            Return m_ChamberName
        End Get
        Set(ByVal value As String)
            m_ChamberName = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' ChamberNameActive
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ChamberNameActive() As String
        Get
            Return m_ChamberNameActive
        End Get
        Set(ByVal value As String)
            m_ChamberNameActive = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Get list chamber names from chamber1, chamber3 detail.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ListChamber() As ArrayList
        Get
            Return m_ListChamber
        End Get
        Set(ByVal value As ArrayList)
            m_ListChamber = value
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
    Public Sub New(ByVal ChamberName As String, ByVal ChamberNameActive As String, ByVal ListChamber As ArrayList)
        Me.m_ChamberName = ChamberName
        Me.m_ChamberNameActive = ChamberNameActive
        Me.m_ListChamber = ListChamber
    End Sub
#End Region
End Class
