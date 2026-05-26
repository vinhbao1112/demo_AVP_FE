Public Class DBGroup
#Region "Class Constants & Variables"
    Private m_Id As Integer
    Private m_Name As String
#End Region
    
#Region "Properties"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Id
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Id() As Integer
        Get
            Return m_Id
        End Get
        Set(ByVal value As Integer)
            m_Id = value
        End Set
    End Property
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
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <param name="Name"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Id As Integer, ByVal Name As String)
        Me.m_Id = Id
        Me.m_Name = Name
    End Sub
#End Region
End Class