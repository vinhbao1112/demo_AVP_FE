Public Class DBRecipeTemplateGroupParameters

#Region "Class Constants & Variables"
    Private _id As Integer
    Private _isGroup As Boolean
    Private _groupCode As String
    Private _groupName As String
    Private _listOfParameters As ArrayList
    Private _saveNotShow As Boolean = False
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Id
    ''' </summary>
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' IsGroup
    ''' </summary>
    Public Property IsGroup() As Boolean
        Get
            Return _isGroup
        End Get
        Set(ByVal value As Boolean)
            _isGroup = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' GroupCode
    ''' </summary>
    Public Property GroupCode() As String
        Get
            Return _groupCode
        End Get
        Set(ByVal value As String)
            _groupCode = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' GroupName
    ''' </summary>
    Public Property GroupName() As String
        Get
            Return _groupName
        End Get
        Set(ByVal value As String)
            _groupName = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' List of DBRecipeTemplateParameter
    ''' </summary>
    Public Property ListOfParameters() As ArrayList
        Get
            Return _listOfParameters
        End Get
        Set(ByVal value As ArrayList)
            _listOfParameters = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Save_Not_Show
    ''' </summary>
    Public Property SaveNotShow() As Boolean
        Get
            Return _saveNotShow
        End Get
        Set(ByVal value As Boolean)
            _saveNotShow = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    Public Sub New()

    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    Public Sub New(ByVal id As Integer, ByVal isGroup As Boolean, ByVal groupCode As String, ByVal groupName As String, ByVal listOfParameters As ArrayList, ByVal saveNotShow As Boolean)
        Me._id = id
        Me._isGroup = isGroup
        Me._groupCode = groupCode
        Me._groupName = groupName
        Me._listOfParameters = listOfParameters
        Me._saveNotShow = saveNotShow
    End Sub

#End Region

#Region "Construtor and Destructor"

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get parameter of recipe template
    ''' </summary>
    Public Function GetParameterOfRecipeTemplate(ByVal parameterName As String) As DBRecipeTemplateParameter
        For Each parameter As DBRecipeTemplateParameter In Me._listOfParameters
            If (parameterName = parameter.Name) Then
                Return parameter
            End If
        Next
        Return Nothing
    End Function

#End Region

End Class
