Public Class Polling
    Private strName As String
    Private intInterval As Integer
    Private blnIsLog As Boolean

#Region "Properties"
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-12-10</date>
    ''' </author>
    ''' <summary>
    ''' Name
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name() As String
        Get
            Return strName
        End Get
        Set(ByVal value As String)
            strName = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-12-10</date>
    ''' </author>
    ''' <summary>
    ''' Timeout
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Interval() As Integer
        Get
            Return intInterval
        End Get
        Set(ByVal value As Integer)
            intInterval = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-12-10</date>
    ''' </author>
    ''' <summary>
    ''' IsLog
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsLog() As Boolean
        Get
            Return blnIsLog
        End Get
        Set(ByVal value As Boolean)
            blnIsLog = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-12-10</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <param name="Interval"></param>
    ''' <param name="IsLog"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Name As String, ByVal Interval As Integer, ByVal IsLog As Boolean)
        Me.strName = Name
        Me.intInterval = Interval
        Me.blnIsLog = IsLog
    End Sub
#End Region
End Class
