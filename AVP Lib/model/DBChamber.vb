Public Class DBChamber
#Region "Class Constants & Variables"
    Private m_ChamberName As String ' ChamberX
    Private m_ChamberType As String ' IBE, DCPVD, RFPVD, Aligner
    Private m_ChamberDescription As String
    Private m_ListGroupParameters As ArrayList
    Private m_ListChamberSteps As ArrayList
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' ChamberName
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ChamberName() As String
        Get
            Return m_ChamberName
        End Get
        Set(ByVal value As String)
            m_ChamberName = value
        End Set
    End Property

    Public Property ChamberType() As String
        Get
            Return m_ChamberType
        End Get
        Set(ByVal value As String)
            m_ChamberType = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' ChamberDescription
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ChamberDescription() As String
        Get
            Return m_ChamberDescription
        End Get
        Set(ByVal value As String)
            m_ChamberDescription = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' List DBGroupParameter
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ListGroupParameters() As ArrayList
        Get
            Return m_ListGroupParameters
        End Get
        Set(ByVal value As ArrayList)
            m_ListGroupParameters = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' List DBChamberStep
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ListChamberSteps() As ArrayList
        Get
            If m_ListChamberSteps Is Nothing Then
                m_ListChamberSteps = New ArrayList()
            End If
            Return m_ListChamberSteps
        End Get
        Set(ByVal value As ArrayList)
            m_ListChamberSteps = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub

    Public Sub New(ByVal chamberType As String, ByVal ListGroupParameters As ArrayList)
        m_ChamberType = chamberType
        m_ChamberName = String.Empty
        m_ListGroupParameters = ListGroupParameters
        m_ListChamberSteps = Nothing
    End Sub

    Public Sub New(ByVal ChamberName As String, ByVal chamberType As String, ByVal ChamberDescription As String, ByVal ListGroupParameters As ArrayList, ByVal ListChamberSteps As ArrayList)
        Me.m_ChamberName = ChamberName
        Me.m_ChamberType = chamberType
        Me.m_ChamberDescription = ChamberDescription
        Me.m_ListGroupParameters = ListGroupParameters
        Me.m_ListChamberSteps = ListChamberSteps
    End Sub

    Public Function GetParameter(ByVal groupCode As String, ByVal paraName As String) As DBParameter
        For Each group As DBParameterGroup In m_ListGroupParameters
            If (groupCode = group.GroupCode) Then
                Return group.GetParameter(paraName)
            End If
        Next
        Return Nothing
    End Function
#End Region
End Class
