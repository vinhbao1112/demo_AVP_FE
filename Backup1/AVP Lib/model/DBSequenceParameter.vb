Public Class DBSequenceParameter
#Region "Class Constants & Variables"
    Private m_SeqNo As Integer
    Private m_SequenceName As String
    Private m_RecipeList As ArrayList 'List String Chamber(Chamber1, Chamber3...)
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
            Me.m_SeqNo = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' SequenceName
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SequenceName() As String
        Get
            Return m_SequenceName
        End Get
        Set(ByVal value As String)
            Me.m_SequenceName = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' RecipeList
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RecipeList() As ArrayList
        Get
            Return m_RecipeList
        End Get
        Set(ByVal value As ArrayList)
            Me.m_RecipeList = value
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
    Public Sub New(ByVal SeqNo As Integer, ByVal SequenceName As String, ByVal RecipeList As ArrayList)
        Me.m_SeqNo = SeqNo
        Me.m_SequenceName = SequenceName
        Me.m_RecipeList = RecipeList
    End Sub
#End Region
End Class
