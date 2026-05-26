Public Class ValueMessage
#Region "Class Constants & Variables"
    Private strResult As String
    Private strValue As String
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <summary>
    ''' Get current result
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Result() As String
        Get
            Return strResult
        End Get
        Set(ByVal value As String)
            strResult = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <summary>
    ''' Get current value message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Value() As String
        Get
            Return strValue
        End Get
        Set(ByVal value As String)
            strValue = value
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
    ''' <param name="Result"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Result As String, ByVal Value As String)
        Me.strResult = Result
        Me.strValue = Value
    End Sub
#End Region
End Class
