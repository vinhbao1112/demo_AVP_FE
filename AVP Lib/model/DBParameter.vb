Public Class DBParameter
#Region "Class Constants & Variables"
    Private m_SeqNo As Integer
    Private m_Name As String
    Private m_Description As String
    Private m_Min As Double
    Private m_Max As Double
    Private m_DefaultValue As String
    Private m_Unit As String
    Private m_ShowUI As Boolean
    Private m_DisplayItems As List(Of KeyValuePair(Of String, String))
    '2013-07-17 Tin Pham modified
    Private m_SeqNoDisable As Hashtable
    Private m_SeqNoCalculate As Hashtable
    '----------------------------
    Private m_blReadOnly As Boolean
    Private m_blReadWrite As Boolean
    Private m_UnitShow As String
    Private m_Save_Not_Show As Boolean = False

#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' SeqNo
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SeqNo() As Integer
        Get
            Return m_SeqNo
        End Get
        Set(ByVal value As Integer)
            m_SeqNo = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Name
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal value As String)
            m_Name = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Description
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Description() As String
        Get
            Return m_Description
        End Get
        Set(ByVal value As String)
            m_Description = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Min() As Double
        Get
            Return m_Min
        End Get
        Set(ByVal value As Double)
            m_Min = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' DefaultValue
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Max() As Double
        Get
            Return m_Max
        End Get
        Set(ByVal value As Double)
            m_Max = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' DefaultValue
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DefaultValue() As String
        Get
            Return m_DefaultValue
        End Get
        Set(ByVal value As String)
            m_DefaultValue = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Unit
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Unit() As String
        Get
            Return m_Unit
        End Get
        Set(ByVal value As String)
            m_Unit = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-02-25</date>
    ''' </author>
    ''' <summary>
    ''' UnitShow: show unit of value.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property UnitShow() As String
        Get
            Return m_UnitShow
        End Get
        Set(ByVal value As String)
            m_UnitShow = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' ShowUI
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ShowUI() As Boolean
        Get
            Return m_ShowUI
        End Get
        Set(ByVal value As Boolean)
            m_ShowUI = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Values
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DisplayItems() As List(Of KeyValuePair(Of String, String))
        Get
            Return m_DisplayItems
        End Get
    End Property
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-07-11</date>
    ''' </author>
    ''' <summary>
    ''' SeqNoDisable
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SeqNoDisable() As Hashtable
        Get
            Return m_SeqNoDisable
        End Get
    End Property
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-07-17</date>
    ''' </author>
    ''' <summary>
    ''' SeqNoCalculate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SeqNoCalculate() As Hashtable
        Get
            Return m_SeqNoCalculate
        End Get
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
    Public Sub New(ByVal SeqNo As Integer, ByVal Name As String, ByVal Description As String, _
                   ByVal Min As Double, ByVal Max As Double, ByVal DefaultValue As String, _
                   ByVal Unit As String, ByVal UnitShow As String, ByVal ShowUI As Boolean, _
                   ByVal displayItems As List(Of KeyValuePair(Of String, String)), _
                   ByVal seqNoDisable As Hashtable, ByVal seqNoCalculate As Hashtable)
        Me.m_SeqNo = SeqNo
        Me.m_Name = Name
        Me.m_Description = Description
        Me.m_Min = Min
        Me.m_Max = Max
        Me.m_DefaultValue = DefaultValue
        Me.m_Unit = Unit
        Me.m_UnitShow = UnitShow
        Me.m_ShowUI = ShowUI
        Me.m_DisplayItems = displayItems
        Me.m_SeqNoDisable = seqNoDisable
        Me.m_SeqNoCalculate = seqNoCalculate
        ' Default View Only.
        Me.m_blReadOnly = True
        Me.m_blReadWrite = False
    End Sub
#End Region

    Public Property ViewOnly() As Boolean
        Get
            Return m_blReadOnly
        End Get
        Set(ByVal value As Boolean)
            m_blReadOnly = value
        End Set
    End Property

    Public Property ReadWrite() As Boolean
        Get
            Return m_blReadWrite
        End Get
        Set(ByVal value As Boolean)
            m_blReadWrite = value
        End Set
    End Property

    Public Property Save_Not_Show() As Boolean
        Get
            Return m_Save_Not_Show
        End Get
        Set(ByVal value As Boolean)
            m_Save_Not_Show = value
        End Set
    End Property
End Class
