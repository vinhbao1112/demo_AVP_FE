Partial Public Class DBUser
#Region "Class Constants & Variables"
    Private m_Username As String
    Private m_Password As String
    Private m_Group As DBGroup
    Private m_Disable As Boolean
    Private m_ListPermission As ArrayList
    Private m_ListOfDbChambers As Dictionary(Of String, DBChamber)
Private m_strPMxNeed_2UpdatePrivilege As String = String.Empty
#End Region

#Region "Properties"
    Public Property PMxNeed_ToUpdatePrivilege() As String
        Get
            Return m_strPMxNeed_2UpdatePrivilege
        End Get
        Set(ByVal value As String)
            m_strPMxNeed_2UpdatePrivilege = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Username
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Username() As String
        Get
            Return m_Username
        End Get
        Set(ByVal value As String)
            Me.m_Username = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Password
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Password() As String
        Get
            Return m_Password
        End Get
        Set(ByVal value As String)
            Me.m_Password = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Group
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Group() As DBGroup
        Get
            Return m_Group
        End Get
        Set(ByVal value As DBGroup)
            Me.m_Group = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Disable
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Disable() As Boolean
        Get
            Return m_Disable
        End Get
        Set(ByVal value As Boolean)
            Me.m_Disable = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' ListPermission
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ListPermission() As ArrayList
        Get
            Return m_ListPermission
        End Get
        Set(ByVal value As ArrayList)
            Me.m_ListPermission = value
        End Set
    End Property

    Public Property ListOfDBChamber() As Dictionary(Of String, DBChamber)
        Get
            Return m_ListOfDbChambers
        End Get
        Set(ByVal value As Dictionary(Of String, DBChamber))
            m_ListOfDbChambers = value
        End Set
    End Property

#End Region

#Region "Construtor and Destructor"
    Public Sub New()

    End Sub

    Public Sub New(ByVal Username As String, ByVal Password As String, ByVal Group As DBGroup, ByVal Disable As Boolean, ByVal ListPermission As ArrayList, ByVal listOfDbRecChamber As Dictionary(Of String, DBChamber), ByVal strPMxNeed_ToUpdatePrivilege As String)
        Me.m_Username = Username
        Me.m_Password = Password
        Me.m_Group = Group
        Me.m_Disable = Disable
        Me.m_ListPermission = ListPermission
        Me.m_ListOfDbChambers = listOfDbRecChamber
        Me.m_strPMxNeed_2UpdatePrivilege = strPMxNeed_ToUpdatePrivilege
    End Sub
#End Region
End Class

Public Class DBDefaultAccessList
    Private m_strParameterName As String = String.Empty
    Private m_lstName As List(Of String) = Nothing
    Public Property ParamName() As String
        Get
            Return m_strParameterName
        End Get
        Set(ByVal value As String)
            m_strParameterName = value
        End Set
    End Property
    Public Property ListOfUser() As List(Of String)
        Get
            Return m_lstName
        End Get
        Set(ByVal value As List(Of String))
            m_lstName = value
        End Set
    End Property
    Public Sub New()
        m_lstName = New List(Of String)
    End Sub
End Class