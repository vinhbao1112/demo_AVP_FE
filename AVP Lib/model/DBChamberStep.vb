Public Class DBChamberStep
#Region "Class Constants & Variables"
    Private m_SeqNo As Integer
    Private m_ListGroupParameterValues As ArrayList
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
    ''' List DBGroupParameterValue
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ListGroupParameterValues() As ArrayList
        Get
            Return m_ListGroupParameterValues
        End Get
        Set(ByVal value As ArrayList)
            m_ListGroupParameterValues = value
        End Set
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
    Public Sub New(ByVal SeqNo As Integer, ByVal ListGroupParameterValues As ArrayList)
        Me.m_SeqNo = SeqNo
        Me.m_ListGroupParameterValues = ListGroupParameterValues
    End Sub
#End Region
End Class
