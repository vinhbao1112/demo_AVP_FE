
Public Class AVPStateMachineManager
#Region "Variable and property"
    Private m_lstStateMachine As List(Of AVPStateMachine)
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set List of State Machine
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ListOfStateMachine() As List(Of AVPStateMachine)
        Get
            Return m_lstStateMachine
        End Get
        Set(ByVal value As List(Of AVPStateMachine))
            m_lstStateMachine = value
        End Set
    End Property
#End Region

#Region "Sub and Function"
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-11-02</date>
    ''' </author>
    ''' <summary>
    ''' Initialize processing order
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize()
        AVPLib.Log.coreLogger.Info("Enter Initialize")
        Try
            Dim stateMachinePJ As AVPStateMachine = New AVPStateMachine(ConstEnum.STATE_MACHINE_TYPE.ProcessJob.ToString())
            stateMachinePJ.Initialize()
            m_lstStateMachine.Add(stateMachinePJ)

            Dim stateMachineCJ As AVPStateMachine = New AVPStateMachine(ConstEnum.STATE_MACHINE_TYPE.ControlJob.ToString())
            stateMachineCJ.Initialize()
            m_lstStateMachine.Add(stateMachineCJ)

            Dim stateMachineEQP As AVPStateMachine = New AVPStateMachine(ConstEnum.STATE_MACHINE_TYPE.Equipment.ToString())
            stateMachineEQP.Initialize()
            m_lstStateMachine.Add(stateMachineEQP)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave Initialize")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set List of State Machine
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        m_lstStateMachine = New List(Of AVPStateMachine)
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set List of State Machine
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal pListOfStateMachine As List(Of AVPStateMachine))
        m_lstStateMachine = pListOfStateMachine
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' return StateMachine belong to StateMachineName
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetStateMachine(ByVal p_strName As String) As AVPStateMachine
        Dim retStateMachine As AVPStateMachine = Nothing
        Try
            For Each stateMachine As AVPStateMachine In ListOfStateMachine
                If stateMachine.StateMachineName = p_strName Then
                    retStateMachine = stateMachine
                    Exit For
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return retStateMachine
    End Function
#End Region

End Class
