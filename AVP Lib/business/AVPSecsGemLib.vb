Imports AVPLib.DataManagerment
Imports System.Threading
Imports AVPSecsGemLib
Imports System.ServiceProcess

Namespace Business
    Public Class AVPSecsGemLib
        Private Shared m_MySecsGem As AVPSecsGem

#Region "Init-Dispose"
        Private Shared Sub StopEMService()
            Dim service As ServiceController = New ServiceController("EMService")
            If Not (service.Status.Equals(ServiceControllerStatus.Stopped)) Then
                service.Stop()
            End If
        End Sub

        Public Shared Sub Initialize()
            Try
                StopEMService()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            m_MySecsGem = New AVPSecsGem
        End Sub

        Public Shared ReadOnly Property MySecsGemObj() As AVPSecsGem
            Get
                Return m_MySecsGem
            End Get
        End Property

        Public Shared Sub Dispose()
            If m_MySecsGem IsNot Nothing Then
                m_MySecsGem.Shutdown()
            End If
        End Sub

#End Region

#Region "Action from GUI"
        Public Shared Sub DoOnline()
            If m_MySecsGem IsNot Nothing Then
                m_MySecsGem.GEMStateControlStateOnline(AVPGemControlState.ONLINE)
            End If
        End Sub

        Public Shared Sub DoOffline()
            If m_MySecsGem IsNot Nothing Then
                m_MySecsGem.GEMStateControlStateOnline(AVPGemControlState.OFFLINE)
            End If
        End Sub

        Public Shared Sub DoEnableCommunication()
            If m_MySecsGem IsNot Nothing Then
                m_MySecsGem.GEMStateCommunicationStateEnable(AVPGEMCommState.COMM_ENABLE)
            End If
        End Sub

        Public Shared Sub DoDisableCommunication()
            If m_MySecsGem IsNot Nothing Then
                m_MySecsGem.GEMStateCommunicationStateEnable(AVPGEMCommState.COMM_DISABLE)
            End If
        End Sub

        Public Shared Sub DoControlRemote()
            If m_MySecsGem IsNot Nothing Then
                m_MySecsGem.GEMStateControlStateRemote(AVPGemControlStateRemote.REMOTE)
            End If
        End Sub

        Public Shared Sub DoControlLocal()
            If m_MySecsGem IsNot Nothing Then
                m_MySecsGem.GEMStateControlStateRemote(AVPGemControlStateRemote.LOCAL)
            End If
        End Sub

        Public Shared Sub SendTerminalMessage(ByVal message As String)
            If m_MySecsGem IsNot Nothing Then
                m_MySecsGem.SendTerminalMessage(message)
            End If
        End Sub
        Public Shared Sub SendTerminalAcknowledge()
            If m_MySecsGem IsNot Nothing Then
                m_MySecsGem.SendTerminalAcknowledge()
            End If
        End Sub
#End Region

#Region "Update Variable - Alarm - Event"
        Public Shared Sub UpdateSECSGEM_Variable(ByVal sChamberName As String, ByVal varType As EMSERVICELib.VarType, ByVal sName As String, ByVal valueType As VALUELib.ValueType, ByVal sNewValue As String)
            If MySecsGemObj IsNot Nothing Then
                m_MySecsGem.UpdateVariable(sChamberName, varType, sName, valueType, sNewValue)
            End If
        End Sub

        Public Shared Sub SECSGEM_AlarmSET(ByVal sChamberName As String, ByVal sName As String, ByVal sText As String)
            If MySecsGemObj IsNot Nothing Then
                MySecsGemObj().AlarmSET(sChamberName, sName, sText)
            End If
        End Sub

        Public Shared Sub SECSGEM_AlarmCLEAR(ByVal sChamberName As String, ByVal sName As String)
            If MySecsGemObj IsNot Nothing Then
                MySecsGemObj().AlarmCLEAR(sChamberName, sName)
            End If
        End Sub

        Public Shared Sub SECSGEM_CommonAlarmCLEAR(ByVal sName As String)
            If MySecsGemObj IsNot Nothing Then
                MySecsGemObj().CommonAlarmCLEAR(sName)
            End If
        End Sub

        Public Shared Sub SECSGEM_CommonAlarmSet(ByVal sName As String, ByVal sText As String)
            If MySecsGemObj IsNot Nothing Then
                MySecsGemObj().CommonAlarmSET(sName, sText)
            End If
        End Sub

        Public Shared Sub SECSGEM_AlarmClearAll()
#If AVP_PLATFORM = "CX" Then
            If MySecsGemObj IsNot Nothing Then
                MySecsGemObj().AlarmClearAll()
            End If
#End If
        End Sub

        Public Shared Sub UpdateSECSGEM_Events()

        End Sub

        Public Shared Sub TriggerEvent(ByVal ChamberName As String, ByVal EventName As String)
            If MySecsGemObj IsNot Nothing Then
                MySecsGemObj().TriggerEvent(ChamberName, EventName)
            End If
        End Sub

        Public Shared Sub TriggerEventSystem(ByVal EventName As String)
            If MySecsGemObj IsNot Nothing Then
                MySecsGemObj().TriggerEventSystem(EventName)
            End If
        End Sub
        
        Public Shared Sub PPRequest(ByVal sFileName As String)
            If MySecsGemObj IsNot Nothing Then
                MySecsGemObj().PPRequest(sFileName)
            End If
        End Sub

#End Region
    End Class
End Namespace
