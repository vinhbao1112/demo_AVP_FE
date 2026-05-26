Public Class DBUserPermission
#Region "Class Constants & Variables"
    Private m_Name As String
    Private m_Code As String
    Private m_Permit As Boolean
    Private m_ParentPerm As String
#End Region

#Region "Properties"
  ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-06-23</date>
    ''' </author>
    ''' <summary>
    ''' Name
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParentPermission() As String
        Get
            Return m_ParentPerm
        End Get
        Set(ByVal value As String)
            m_ParentPerm = value
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
            Me.m_Name = value
        End Set
    End Property
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
    ''' Permit
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Permit() As Boolean
        Get
            Return m_Permit
        End Get
        Set(ByVal value As Boolean)
            Me.m_Permit = value
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
    ''' <param name="Name"></param>
    ''' <param name="Permit"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Code As String, ByVal Name As String, ByVal Permit As Boolean, ByVal Parent As String)
        Me.m_Code = Code
        Me.m_Name = Name
        Me.m_Permit = Permit
        Me.m_ParentPerm = Parent
    End Sub
#End Region
End Class
