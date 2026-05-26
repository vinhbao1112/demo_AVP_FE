Public Class DBCommand
#Region "Class Constants & Variables"
    Private m_PropertyName As String
    Private m_CommandName As String
    Private m_CommandCode As String
    Private m_DecoderName As String
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-03</date>
    ''' </author>
    ''' <summary>
    ''' ChamberName
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PropertyName() As String
        Get
            Return m_PropertyName
        End Get
        Set(ByVal value As String)
            m_PropertyName = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-03</date>
    ''' </author>
    ''' <summary>
    ''' ChamberDescription
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CommandName() As String
        Get
            Return m_CommandName
        End Get
        Set(ByVal value As String)
            m_CommandName = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Nguyen Tien Dat </name>
    '''    	<date> 2009-20-02</date>
    ''' </author>
    ''' <summary>
    ''' Command Code
    ''' </summary>
    Public Property CommandCode() As String
        Get
            Return m_CommandCode
        End Get
        Set(ByVal value As String)
            m_CommandCode = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-03</date>
    ''' </author>
    ''' <summary>
    ''' ChamberDescription
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DecoderName() As String
        Get
            Return m_DecoderName
        End Get
        Set(ByVal value As String)
            m_DecoderName = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-03</date>
    ''' </author>
    ''' <summary>
    ''' Contructor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal commandName As String, ByVal commandCode As String, ByVal propertyName As String, ByVal decoderName As String)
        m_CommandName = commandName
        m_CommandCode = commandCode
        m_PropertyName = propertyName
        m_DecoderName = decoderName
    End Sub
#End Region
End Class
