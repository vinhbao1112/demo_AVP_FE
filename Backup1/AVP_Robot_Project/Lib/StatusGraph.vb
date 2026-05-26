Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Public Class StatusGraph
    Inherits AVPControls.StatusObject
#Region "Class Constants & Variables"
    Private m_psgGraph As PressureGraph
    Private m_intPosElevatorLLA As Integer
    Private m_blnCreateGraphLLA As Boolean = False

#End Region


#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the graph that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedGraph() As PressureGraph
        Get
            Return m_psgGraph
        End Get
        Set(ByVal value As PressureGraph)
            m_psgGraph = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with graph that will be managed by this object
    ''' </summary>
    ''' <param name="psgGraph"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal psgGraph As PressureGraph)
        Try
            m_psgGraph = psgGraph
            Me.Name = m_psgGraph.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Public Methods"
    Private Class SlotStatusInfo
        Public SlotIndex As Int32
        Public Status As AVPLib.ConstEnum.enumWaferStatus
        Public ElevatorInLL As String = String.Empty

        Public Sub New(ByVal slotIdx As Int32, ByVal slotStatus As AVPLib.ConstEnum.enumWaferStatus)
            SlotIndex = slotIdx
            Status = slotStatus
        End Sub
        Public Sub New(ByVal slotIdx As Int32, ByVal slotStatus As AVPLib.ConstEnum.enumWaferStatus, ByVal Loadlock As PressureGraph.LoadLock)
            SlotIndex = slotIdx
            Status = slotStatus
            ElevatorInLL = Loadlock.ToString()
        End Sub
    End Class

    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        AVPLib.Log.guiLogger.Info("Enter UpdateUI")
        Try
            Dim slotStusInfo As SlotStatusInfo = CType(arg, SlotStatusInfo)
            ''generate WaferID 
            If slotStusInfo.ElevatorInLL.Contains(AVPLib.ConstEnum.LoadLockA_STR) Then
                ''if slot of Elevator change, value for ElevatorPos is 1 or 2
                m_psgGraph.ElevatorCurrentSlotStatus = slotStusInfo.Status

                ' Update Home button
                ContainerForm.CassettesPanel.lccLoadLockA.IsCassetteHome = (slotStusInfo.SlotIndex = 0)
            Else
                If Me.Parent.Name = AVP_Robot_Project.ConstantAndEnum.LOCKCASSETTEA Or _
                Me.Parent.Name = AVP_Robot_Project.ConstantAndEnum.LOADLOCKA Then
                    m_psgGraph.CurentLoadLock = AVP_Robot_Project.ConstantAndEnum.LOAD_LOCK_A
                End If

                m_psgGraph.SetBarStatus(slotStusInfo.SlotIndex, slotStusInfo.Status)

                m_psgGraph.Refresh()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Exit UpdateUI")
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        Try
            If Identification.Contains(LoadLockA_STR) Then
                If (Identification.Contains(LoadLockA_STR) And Not (m_intPosElevatorLLA = CInt(Value))) Then '''position of Elevator of LLA is change
                    m_intPosElevatorLLA = CInt(Value)
                    ChangeStatusElevator(Identification, Value) 'change status of elevator
                End If
            Else
                Dim SlotAndStatus() As String = Value.Split(New String() {" "}, StringSplitOptions.RemoveEmptyEntries)
                If SlotAndStatus.Length >= 2 Then
                    Dim sBarIndex As String = SlotAndStatus(0)
                    Dim strStatus As String = SlotAndStatus(1)
                    Dim intBarIndex = CType(sBarIndex, Integer)
                    intBarIndex -= 1
                    Dim enmStatus As AVPLib.ConstEnum.enumWaferStatus = [Enum].Parse(GetType(AVPLib.ConstEnum.enumWaferStatus), strStatus)
                    ' Marshall call to GUI thread.
                    m_marshaller.Invoke(Of SlotStatusInfo)(New Threading.SendOrPostCallback(AddressOf UpdateUI), New SlotStatusInfo(intBarIndex, enmStatus))
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''     <date> 2009-06-11</date>
    ''' </author>
    ''' <summary>
    ''' This procedure change status of Elevator when position is change
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Private Sub ChangeStatusElevator(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        Try
            Dim sBarIndex As String
            Dim intBarIndex As Integer = 0
            Dim ElevatorLoadLock As PressureGraph.LoadLock
            sBarIndex = Identification.Substring(0, Identification.IndexOf("."))
            If Identification.Contains(LoadLockA_STR) Then ''if load lock A
                ElevatorLoadLock = CType([Enum].Parse(GetType(PressureGraph.LoadLock), sBarIndex.Substring(Identification.IndexOf(LoadLockA_STR))), PressureGraph.LoadLock)
                intBarIndex = CType(Value, Integer)
            End If
            Dim enmStatus As AVPLib.ConstEnum.enumWaferStatus = CType([Enum].Parse(GetType(PressureGraph.ElevatorPos), Value), PressureGraph.ElevatorPos)
            ' Marshall call to GUI thread.
            m_marshaller.Invoke(Of SlotStatusInfo)(New Threading.SendOrPostCallback(AddressOf UpdateUI), New SlotStatusInfo(intBarIndex, enmStatus, ElevatorLoadLock))
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
    ''' <author>
    '''     	<name> Ngo Cao Dinh </name>
    '''     	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to request status of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub RequestStatus(ByVal Identification As String, ByVal Value As String)

    End Sub

#End Region

End Class
