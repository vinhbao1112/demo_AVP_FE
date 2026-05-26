Public Class DBRecipeGroupParameters

#Region "Class Constants & Variables"
    Private _groupCode As String
    Private _listOfParameters As ArrayList
#End Region

#Region "Properties"
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
    ''' List of DBRecipeParameter
    ''' </summary>
    Public Property ListOfParameters() As ArrayList
        Get
            Return _listOfParameters
        End Get
        Set(ByVal value As ArrayList)
            _listOfParameters = value
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
    Public Sub New(ByVal groupCode As String, ByVal listOfParameters As ArrayList)
        Me._groupCode = groupCode
        Me._listOfParameters = listOfParameters
    End Sub
#End Region

End Class
