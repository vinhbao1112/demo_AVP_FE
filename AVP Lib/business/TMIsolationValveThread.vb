Imports System.Threading
Namespace Business
    Public Class TMIsolationValveThread
        Inherits SuspendableThread

#Region "Constants & Variables"
        Private Const OpenCloseSplitValveTimeOutInMilliSeconds As Integer = 10000
        Private m_strSplitValveName As String = String.Empty
        Private m_IsOpen As Boolean = False
        Private m_TMController As TMController = Nothing
#End Region

#Region "Properties"
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-05-21</date>
        ''' </author>
        ''' <summary>
        ''' SlitValveName
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SplitValveName() As String
            Get
                Return m_strSplitValveName
            End Get
            Set(ByVal value As String)
                m_strSplitValveName = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-05-21</date>
        ''' </author>
        ''' <summary>
        ''' IsOpen
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsOpen() As Boolean
            Get
                Return m_IsOpen
            End Get
            Set(ByVal value As Boolean)
                m_IsOpen = value
            End Set
        End Property
#End Region

#Region "Contructor"

        Public Sub New(ByVal TMCtr As TMController)
            m_TMController = TMCtr
        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-05-21</date>
        ''' </author>
        ''' <summary>
        ''' OnDoWork
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ' Run when calling Start Method
        Protected Overrides Sub OnDoWork()
            Try
                Dim strErrorMsg As String = String.Empty
                Dim strChamberName = ChamberUtility.GetChamberName(m_strSplitValveName)

                Dim isWaitOK As Boolean = False
                If (m_strSplitValveName.Contains("LL")) Then
                    If IsOpen Then
                        isWaitOK = WaitOnCondition(AddressOf Utils.IsLLSlitValveOpen, strChamberName, OpenCloseSplitValveTimeOutInMilliSeconds)
                    Else
                        isWaitOK = WaitOnCondition(AddressOf Utils.IsLLSlitValveClose, strChamberName, OpenCloseSplitValveTimeOutInMilliSeconds)
                    End If
                Else
                    If IsOpen Then
                        isWaitOK = WaitOnCondition(AddressOf Utils.IsChamberSlitValveOpen, strChamberName, OpenCloseSplitValveTimeOutInMilliSeconds)
                    Else
                        isWaitOK = WaitOnCondition(AddressOf Utils.IsChamberSlitValveClose, strChamberName, OpenCloseSplitValveTimeOutInMilliSeconds)
                    End If
                End If

                If Not isWaitOK Then
                    strErrorMsg = ChamberUtility.UnknownSlitValve(m_TMController.EquipmentName, m_strSplitValveName)
                End If

                If strErrorMsg <> String.Empty Then
                    m_TMController.ThrowAlarm(strErrorMsg)
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Error: " + ex.Message)
            End Try
        End Sub
#End Region

#Region "Public method"
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-05-21</date>
        ''' </author>
        ''' <summary>
        ''' WaitOnCondition
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function WaitOnCondition(ByVal condition As CheckConditionOneParam, ByVal oneParam As String, ByVal waitTimeInMilliseconds As Integer) As Boolean
            Dim span As Int64 = waitTimeInMilliseconds
            Dim start As Int64 = Environment.TickCount
            While (Utils.GetTickCountDelta(start) <= span)
                If HasTerminateRequest() Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return True
                End If
                ' Check Condition.
                If condition(oneParam) Then
                    Return True
                End If
                If SleepButAlertabletoTerminateRequest(100) Then
                    AVPLib.Log.coreLogger.Debug("Aborted requested.")
                    Return True
                End If
            End While
            Return False
        End Function
#End Region

    End Class
End Namespace

