Public Class DBParameterGroup
#Region "Class Constants & Variables"
    Private m_Id As Integer
    Private m_IsGroup As Boolean
    Private m_GroupCode As String
    Private m_GroupName As String
    Private m_Parameters As ArrayList
    Private m_Save_Not_Show As Boolean = False
#End Region

#Region "Properties"
    Public Property Save_Not_Show() As Boolean
        Get
            Return m_Save_Not_Show
        End Get
        Set(ByVal value As Boolean)
            m_Save_Not_Show = value
        End Set
    End Property
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
    ''' IsGroup
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsGroup() As Boolean
        Get
            Return m_IsGroup
        End Get
        Set(ByVal value As Boolean)
            m_IsGroup = value
        End Set
    End Property
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
    ''' GroupName
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GroupName() As String
        Get
            Return m_GroupName
        End Get
        Set(ByVal value As String)
            m_GroupName = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' List DBParameter
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Parameters() As ArrayList
        Get
            Return m_Parameters
        End Get
        Set(ByVal value As ArrayList)
            m_Parameters = value
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

    Public Sub New(ByVal Id As Integer, ByVal IsGroup As Boolean, ByVal GroupCode As String, ByVal GroupName As String, ByVal Parameters As ArrayList, ByVal SaveNotShow As Boolean)
        Me.m_Id = Id
        Me.m_IsGroup = IsGroup
        Me.m_GroupCode = GroupCode
        Me.m_GroupName = GroupName
        Me.m_Parameters = Parameters
        Me.m_Save_Not_Show = SaveNotShow
    End Sub

    Public Function GetParameter(ByVal paraName As String) As DBParameter
        For Each para As DBParameter In m_Parameters
            If (paraName = para.Name) Then
                Return para
            End If
        Next
        Return Nothing
    End Function

#End Region
End Class
