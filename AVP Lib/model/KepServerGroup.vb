Public Class KepServerGroup
#Region "Class Constants & Variables"
    Private strGroupName As String
    Private bIsActive As Boolean
    Private iDeadBand As Integer
    Private iUpdateRate As Integer
    Private m_ListItems As ArrayList
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-14</date>
    ''' </author>
    ''' <summary>
    ''' GroupName
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GroupName() As String
        Get
            Return strGroupName
        End Get
        Set(ByVal value As String)
            strGroupName = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-14</date>
    ''' </author>
    ''' <summary>
    ''' IsActive
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsActive() As Boolean
        Get
            Return bIsActive
        End Get
        Set(ByVal value As Boolean)
            bIsActive = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-14</date>
    ''' </author>
    ''' <summary>
    ''' DeadBand
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DeadBand() As Integer
        Get
            Return iDeadBand
        End Get
        Set(ByVal value As Integer)
            iDeadBand = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-14</date>
    ''' </author>
    ''' <summary>
    ''' UpdateRate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UpdateRate() As Integer
        Get
            Return iUpdateRate
        End Get
        Set(ByVal value As Integer)
            iUpdateRate = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-14</date>
    ''' </author>
    ''' <summary>
    ''' ListItems
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ListItems() As ArrayList
        Get
            Return m_ListItems
        End Get
        Set(ByVal value As ArrayList)
            m_ListItems = value
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
    ''' <param name="GroupName"></param>
    ''' <param name="ListItems"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal GroupName As String, ByVal IsActive As Boolean, ByVal DeadBand As Integer, ByVal UpdateRate As Integer, ByVal ListItems As ArrayList)
        Me.strGroupName = GroupName
        Me.bIsActive = IsActive
        Me.iDeadBand = DeadBand
        Me.iUpdateRate = UpdateRate
        Me.m_ListItems = ListItems
    End Sub
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-11-21</date>
    ''' </author>
    ''' <summary>
    ''' Add Action Hash
    ''' </summary>
    ''' <remarks></remarks>
    Public Function AddItem(ByVal DisplayGroup As String, ByVal PropertyName As String, _
                                ByVal KepServerName As String, ByVal DataType As String, _
                                ByVal Desc As String) As KepServerItem
        AVPLib.Log.avpLogger.Info("Enter AddKepserItem")
        Dim objResult As KepServerItem = Nothing
        Try
            If (m_ListItems Is Nothing) Then
                m_ListItems = New ArrayList
            End If
            objResult = New KepServerItem(DisplayGroup, PropertyName, KepServerName, DataType, Desc)
            m_ListItems.Add(objResult)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Info(ex.Message)
        End Try
        AVPLib.Log.avpLogger.Info("Leave AddKepserItem")
        Return objResult
    End Function
#End Region
End Class

