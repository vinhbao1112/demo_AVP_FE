Public Class PropertyMessage
#Region "Class Constants & Variables"
    Private strPropertyName As String
    Private strType As String
    Private bIsValueAny As Boolean
    Private listValues As ArrayList
    Private strCode As String
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-012</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PropertyName() As String
        Get
            Return strPropertyName
        End Get
        Set(ByVal value As String)
            strPropertyName = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Type() As String
        Get
            Return strType
        End Get
        Set(ByVal value As String)
            strType = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Values() As ArrayList
        Get
            Return listValues
        End Get
        Set(ByVal value As ArrayList)
            listValues = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <summary>
    ''' Is value any
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsValueAny() As Boolean
        Get
            Return bIsValueAny
        End Get
        Set(ByVal value As Boolean)
            bIsValueAny = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <summary>
    ''' Code property message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Code() As String
        Get
            Return strCode
        End Get
        Set(ByVal value As String)
            strCode = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <param name="PropertyName"></param>
    ''' <param name="Type"></param>
    ''' <param name="Values"></param>
    ''' <param name="Code"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal PropertyName As String, ByVal Type As String, ByVal Values As ArrayList, ByVal IsValueAny As Boolean, ByVal Code As String)
        Me.strPropertyName = PropertyName
        Me.strType = Type
        Me.listValues = Values
        Me.bIsValueAny = IsValueAny
        Me.strCode = Code
    End Sub
#End Region
End Class
