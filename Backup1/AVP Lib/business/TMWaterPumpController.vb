Imports System.Timers
Imports AVPLib.DataManagerment
Imports AVPLib.Communication.TerminalDriver

Namespace Business
    Public Class WaterPumpController
        Inherits ControllerObject
#Region "Class Constants & Variables"
        Private m_tmrPullingTimer As Timer
#End Region

#Region "Properties"
        Public Property PullingInterval() As Integer
            Get
                Return m_tmrPullingTimer.Interval
            End Get
            Set(ByVal value As Integer)
                Dim blnIsStart = m_tmrPullingTimer.Enabled
                m_tmrPullingTimer.Enabled = False
                m_tmrPullingTimer.Interval = value
                If (blnIsStart) Then
                    m_tmrPullingTimer.Enabled = True
                End If
            End Set
        End Property
#End Region

#Region "Constructors & Dispose"
        Public Sub New()
            m_tmrPullingTimer = New Timer
            AddHandler m_tmrPullingTimer.Elapsed, AddressOf Pulling
            m_tmrPullingTimer.Interval = 2000
            m_tmrPullingTimer.Enabled = True
        End Sub
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2011-12-13 </date>
        ''' </author>
        ''' <summary>
        ''' Dispose Aligner Object
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Dispose()
            AVPLib.Log.coreLogger.Info("Enter Dispose")
            Try
                m_tmrPullingTimer.Enabled = False
                RemoveHandler m_tmrPullingTimer.Elapsed, AddressOf Pulling
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Dispose")
        End Sub
#End Region

#Region "Public method"

        Public Overrides Sub ReconnectHandle(ByVal obj As Object, ByVal e As ReconnectEventArgs)
            'Re-Init if need
        End Sub
        Public Overrides Sub DoTask(ByVal Message As String)
            AVPLib.Log.coreLogger.Info("Enter DoTask")
            Try
                Select Case Message
                    Case "WaterPump.StartFastRegen"
                        WaterPumpUtility.StartFastRegen(Me.EquipmentName)
                    Case "WaterPump.StartRegen"
                        WaterPumpUtility.StartRegen(Me.EquipmentName)
                    Case "WaterPump.StopRegen"
                        WaterPumpUtility.StopRegen(Me.EquipmentName)
                    Case "WaterPump.TurnPumpOff"
                        WaterPumpUtility.TurnPumpOff(Me.EquipmentName)
                    Case "WaterPump.TurnPumpOn"
                        WaterPumpUtility.TurnPumpOn(Me.EquipmentName)
                End Select
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoTask")
        End Sub
        Public Sub Pulling(ByVal source As Object, ByVal e As ElapsedEventArgs)
            AVPLib.Log.coreLogger.Info("Enter Pulling")
            Try
                m_tmrPullingTimer.Enabled = False
                WaterPumpUtility.GetFirstStageTemperature(EquipmentName)
                WaterPumpUtility.GetSecondStageTemperature(EquipmentName)
                WaterPumpUtility.GetRegenStatus(EquipmentName)
                WaterPumpUtility.GetPumpStatus(EquipmentName)
                WaterPumpUtility.GetPullingStatus(EquipmentName)
                m_tmrPullingTimer.Enabled = True
            Catch ex As Exception
                Throw ex
            End Try
            AVPLib.Log.coreLogger.Info("Leave Pulling")
        End Sub
#End Region

#Region "Private methods"
        Public Function IsTMWaterPumpOn() As Boolean
            Dim objTMWaterPump As DataManagerment.WaterPump = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (Equipment.WorkingStatuses.On = objTMWaterPump.WaterPumpOn)
        End Function

        Public Function IsTMWaterPumpTLessThanTConfig() As Boolean
            Dim objTMWaterPump As DataManagerment.WaterPump = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Return (objTMWaterPump.T1 < AVPLib.ConstEnum.TM_WATER_PUMP_T_CONFIG)
        End Function
#End Region
    End Class
End Namespace