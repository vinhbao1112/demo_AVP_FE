
Public Class AVPStateMachineData

#Region "Variables and Property"
    Private m_iTxtNo As Integer = 0
    Private m_strSourceState As String = String.Empty
    Private m_strDestState As String = String.Empty
    Private m_strTriggerID As String = String.Empty
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set TxtNo
    ''' </summary>
    ''' <remarks></remarks>
    Public Property TxtNo() As Integer
        Get
            Return m_iTxtNo
        End Get
        Set(ByVal value As Integer)
            m_iTxtNo = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set SourceState
    ''' </summary>
    ''' <remarks></remarks>
    Public Property SourceState() As String
        Get
            Return m_strSourceState
        End Get
        Set(ByVal value As String)
            m_strSourceState = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Destination State
    ''' </summary>
    ''' <remarks></remarks>
    Public Property DestState() As String
        Get
            Return m_strDestState
        End Get
        Set(ByVal value As String)
            m_strDestState = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set TriggerID
    ''' </summary>
    ''' <remarks></remarks>
    Public Property TriggerID() As String
        Get
            Return m_strTriggerID
        End Get
        Set(ByVal value As String)
            m_strTriggerID = value
        End Set
    End Property
#End Region

#Region "Sub and Function"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set List of State Machine
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(Optional ByVal pTXTNo As Integer = 0, Optional ByVal pSourceState As String = "", _
             Optional ByVal pDestState As String = "", Optional ByVal pTriggerID As String = "")
        Try
            m_iTxtNo = pTXTNo
            m_strDestState = pDestState
            m_strSourceState = pSourceState
            m_strTriggerID = pTriggerID
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
End Class

