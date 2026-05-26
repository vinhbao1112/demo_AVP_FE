Public Class DBRecipe

#Region "Class Constants & Variables"
    Private _chamberType As String ' IBE, DCPVD, RFPVD
    Private _recipeDCPVD As Boolean = False
    Private _description As String
    Private _listOfRecipeTemplateGroupParameters As ArrayList
    Private _listOfRecipeSteps As ArrayList
#End Region

#Region "Properties"

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' ChamberType
    ''' </summary>
    Public Property ChamberType() As String
        Get
            Return _chamberType
        End Get
        Set(ByVal value As String)
            _chamberType = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Recipe DC PVD
    ''' </summary>
    Public Property RecipeDCPVD() As Boolean
        Get
            Return _recipeDCPVD
        End Get
        Set(ByVal value As Boolean)
            _recipeDCPVD = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Description
    ''' </summary>
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' List of DBRecipeTemplateGroupParameters
    ''' </summary>
    Public Property ListOfRecipeTemplateGroupParameters() As ArrayList
        Get
            Return _listOfRecipeTemplateGroupParameters
        End Get
        Set(ByVal value As ArrayList)
            _listOfRecipeTemplateGroupParameters = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' List of DBRecipeStep
    ''' </summary>
    Public Property ListOfRecipeSteps() As ArrayList
        Get
            If _listOfRecipeSteps Is Nothing Then
                _listOfRecipeSteps = New ArrayList()
            End If
            Return _listOfRecipeSteps
        End Get
        Set(ByVal value As ArrayList)
            _listOfRecipeSteps = value
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
    Public Sub New(ByVal chamberType As String, ByVal listOfRecipeTemplateGroupParameters As ArrayList)
        _chamberType = chamberType
        _listOfRecipeTemplateGroupParameters = listOfRecipeTemplateGroupParameters
        _listOfRecipeSteps = Nothing
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    Public Sub New(ByVal chamberType As String, ByVal recipeDCPVD As Boolean, ByVal description As String, ByVal listOfRecipeTemplateGroupParameters As ArrayList, ByVal listOfRecipeSteps As ArrayList)
        Me._chamberType = chamberType
        Me._recipeDCPVD = recipeDCPVD
        Me._description = description
        Me._listOfRecipeTemplateGroupParameters = listOfRecipeTemplateGroupParameters
        Me._listOfRecipeSteps = listOfRecipeSteps
    End Sub

#End Region

#Region "Support Fuction"

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get parameter of recipe template
    ''' </summary>
    Public Function GetParameterOfRecipeTemplate(ByVal groupCode As String, ByVal parameterName As String) As DBRecipeTemplateParameter
        For Each group As DBRecipeTemplateGroupParameters In _listOfRecipeTemplateGroupParameters
            If (groupCode = group.GroupCode) Then
                Return group.GetParameterOfRecipeTemplate(parameterName)
            End If
        Next
        Return Nothing
    End Function

#End Region

End Class
