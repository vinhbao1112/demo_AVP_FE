Imports AVPLib
Public Class AVPStateMachine

#Region "Variables and Property"
    Private m_strStateMachineName As String = String.Empty
    Private m_lstStateMachineData As List(Of AVPStateMachineData) = Nothing

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set State Machine Name
    ''' </summary>
    ''' <remarks></remarks>
    Public Property StateMachineName() As String
        Get
            Return m_strStateMachineName
        End Get
        Set(ByVal value As String)
            m_strStateMachineName = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set State Machine Data
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ListStateMachineData() As List(Of AVPStateMachineData)
        Get
            Return m_lstStateMachineData
        End Get
        Set(ByVal value As List(Of AVPStateMachineData))
            m_lstStateMachineData = value
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
    Public Sub New(ByVal pStateMachineName As String)
        m_strStateMachineName = pStateMachineName
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize()
        LoadStateMachine()
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadStateMachine()
        Try
            If m_strStateMachineName = ConstEnum.STATE_MACHINE_TYPE.ProcessJob.ToString() Then
                Me.ListStateMachineData = AVPLib.ContainerData.GetTransitionState(ContainerDAO.ProcessJobDoc)
            ElseIf m_strStateMachineName = ConstEnum.STATE_MACHINE_TYPE.ControlJob.ToString() Then
                Me.ListStateMachineData = AVPLib.ContainerData.GetTransitionState(ContainerDAO.ControlJobDoc)
            ElseIf m_strStateMachineName = ConstEnum.STATE_MACHINE_TYPE.Equipment.ToString() Then
                Me.ListStateMachineData = AVPLib.ContainerData.GetTransitionState(ContainerDAO.EquipmentTrackingDoc)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' change state Machine base on Trigger ID
    ''' </summary>
    ''' <remarks></remarks>
    Public Function CanChangeState(ByVal strSourceState As String, ByVal strDestState As String) As Boolean
        Dim blnRet As Boolean = False
        Try
            For Each stateMachineDT As AVPStateMachineData In ListStateMachineData
                If stateMachineDT.SourceState = strSourceState AndAlso stateMachineDT.DestState = strDestState Then
                    blnRet = True
                    Return blnRet
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blnRet
    End Function
#End Region

End Class
