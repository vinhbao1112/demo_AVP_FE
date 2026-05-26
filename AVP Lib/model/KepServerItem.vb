Public Class KepServerItem
#Region "Class Constants & Variables"
    Private m_strPropertyName As String
    Private m_strDisplayGroup As String
    Private m_strKepServerName As String
    Private m_strDataType As String
    Private m_strDesc As String
    Private m_objOPCItem As OPCAutomation.OPCItem = Nothing
    Private m_iIndex As Integer = -1
#End Region

#Region "Properties"
    Public Property DisplayGroup() As String
        Get
            Return m_strDisplayGroup
        End Get
        Set(ByVal value As String)
            m_strDisplayGroup = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-14</date>
    ''' </author>
    ''' <summary>
    ''' PropertyName property
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PropertyName() As String
        Get
            Return m_strPropertyName
        End Get
        Set(ByVal value As String)
            m_strPropertyName = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-14</date>
    ''' </author>
    ''' <summary>
    ''' EthernetIP property message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Property KepServerName() As String
        Get
            Return m_strKepServerName
        End Get
        Set(ByVal value As String)
            m_strKepServerName = value
        End Set
    End Property

    Public Property MyOPCItem() As OPCAutomation.OPCItem
        Get
            Return m_objOPCItem
        End Get
        Set(ByVal value As OPCAutomation.OPCItem)
            m_objOPCItem = value
        End Set
    End Property

    Public Property MyIndex() As Integer
        Get
            Return m_iIndex
        End Get
        Set(ByVal value As Integer)
            m_iIndex = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' EthernetIP property message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataType() As String
        Get
            Return m_strDataType
        End Get
        Set(ByVal value As String)
            m_strDataType = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Gui
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Description() As String
        Get
            Return m_strDesc
        End Get
        Set(ByVal value As String)
            m_strDesc = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-14</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <param name="PropertyName"></param>
    ''' <param name="KepServerName"></param>
    ''' <param name="Address"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal strDisplayGroup As String, ByVal strPropertyName As String, ByVal strKepServerName As String, ByVal strDataType As String, ByVal strDesc As String)
        m_strDisplayGroup = strDisplayGroup
        m_strPropertyName = strPropertyName
        m_strKepServerName = strKepServerName
        m_strDataType = strDataType
        m_strDesc = strDesc
    End Sub
#End Region
End Class