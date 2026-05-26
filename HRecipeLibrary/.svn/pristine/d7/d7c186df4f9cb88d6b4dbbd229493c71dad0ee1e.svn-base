Public Class DBRecipeTemplateParameter

#Region "Class Constants & Variables"
    Private _seqNo As Integer
    Private _name As String
    Private _description As String
    Private _min As Double
    Private _max As Double
    Private _defaultValue As String
    Private _unit As String
    Private _showUI As Boolean
    Private _displayItems As List(Of KeyValuePair(Of String, String))
    Private _readOnly As Boolean
    Private _readWrite As Boolean
    Private _unitShow As String
    Private _saveNotShow As Boolean = False
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' SeqNo
    ''' </summary>
    Public Property SeqNo() As Integer
        Get
            Return _seqNo
        End Get
        Set(ByVal value As Integer)
            _seqNo = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Name
    ''' </summary>
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
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
    ''' Min
    ''' </summary>
    Public Property Min() As Double
        Get
            Return _min
        End Get
        Set(ByVal value As Double)
            _min = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' DefaultValue
    ''' </summary>
    Public Property Max() As Double
        Get
            Return _max
        End Get
        Set(ByVal value As Double)
            _max = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' DefaultValue
    ''' </summary>
    Public Property DefaultValue() As String
        Get
            Return _defaultValue
        End Get
        Set(ByVal value As String)
            _defaultValue = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' Unit
    ''' </summary>
    Public Property Unit() As String
        Get
            Return _unit
        End Get
        Set(ByVal value As String)
            _unit = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' UnitShow: show unit of value.
    ''' </summary>
    Public Property UnitShow() As String
        Get
            Return _unitShow
        End Get
        Set(ByVal value As String)
            _unitShow = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' ShowUI
    ''' </summary>
    Public Property ShowUI() As Boolean
        Get
            Return _showUI
        End Get
        Set(ByVal value As Boolean)
            _showUI = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' DisplayItems
    ''' </summary>
    Public ReadOnly Property DisplayItems() As List(Of KeyValuePair(Of String, String))
        Get
            Return _displayItems
        End Get
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' ViewOnly
    ''' </summary>
    Public Property ViewOnly() As Boolean
        Get
            Return _readOnly
        End Get
        Set(ByVal value As Boolean)
            _readOnly = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-08 </date>
    ''' </author>
    ''' <summary>
    ''' ReadWrite
    ''' </summary>
    Public Property ReadWrite() As Boolean
        Get
            Return _readWrite
        End Get
        Set(ByVal value As Boolean)
            _readWrite = value
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
    Public Sub New(ByVal seqNo As Integer, ByVal name As String, ByVal description As String, _
                   ByVal min As Double, ByVal max As Double, ByVal defaultValue As String, _
                   ByVal unit As String, ByVal unitShow As String, ByVal showUI As Boolean, _
                   ByVal displayItems As List(Of KeyValuePair(Of String, String)))
        Me._seqNo = seqNo
        Me._name = name
        Me._description = description
        Me._min = min
        Me._max = max
        Me._defaultValue = defaultValue
        Me._unit = unit
        Me._unitShow = unitShow
        Me._showUI = showUI
        Me._displayItems = displayItems
        ' Default View Only.
        Me._readOnly = True
        Me._readWrite = False
    End Sub

#End Region

End Class
