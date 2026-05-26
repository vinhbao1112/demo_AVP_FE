Namespace DataManagerment
    Public Class WaterPump
        Inherits Equipment
#Region "Class Constants & Variables"
        Private m_blnIsCommunicating As Boolean
        Private m_dblT1 As Double
        Private m_blnWaterPumpON As WorkingStatuses
        Private m_blnWaterPumpRoughON As WorkingStatuses
        Private m_blnWaterPumpPurgeON As WorkingStatuses
        Private m_blnWaterPumpTCON As WorkingStatuses
        Private m_enmPumpStatus As WorkingStatuses
        Private m_enmPullingStatus As WorkingStatuses
        Private m_enmRegenStatus As WorkingStatuses
#End Region

#Region "Property"
        Public Property WaterPumpOn() As WorkingStatuses
            Get
                Return m_blnWaterPumpON
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnWaterPumpON = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: WaterPump.OnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "WaterPump.OnOff", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Public Property WaterPumpRoughOn() As WorkingStatuses
            Get
                Return m_blnWaterPumpRoughON
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnWaterPumpRoughON = value
            End Set
        End Property

        Public Property WaterPumpPurgeOn() As WorkingStatuses
            Get
                Return m_blnWaterPumpPurgeON
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnWaterPumpPurgeON = value
            End Set
        End Property

        Public Property WaterPumpTCOn() As WorkingStatuses
            Get
                Return m_blnWaterPumpTCON
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnWaterPumpTCON = value
            End Set
        End Property

        Public Property IsCommunicating() As Boolean
            Get
                Return m_blnIsCommunicating
            End Get
            Set(ByVal value As Boolean)
                m_blnIsCommunicating = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: WaterPump.CommunicationStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "WaterPump.CommunicationStatus", VALUELib.ValueType.U1, IIf(value, 1, 0))
            End Set
        End Property

        Public Property T1() As Double
            Get
                Return m_dblT1
            End Get
            Set(ByVal value As Double)
                m_dblT1 = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: WaterPump.Temperature
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "WaterPump.Temperature", VALUELib.ValueType.F4, value.ToString())
            End Set
        End Property
        Public Property PumpStatus() As WorkingStatuses
            Get
                Return m_enmPumpStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmPumpStatus = value
            End Set
        End Property

        Public Property PullingStatus() As WorkingStatuses
            Get
                Return m_enmPullingStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmPullingStatus = value
            End Set
        End Property

        Public Property RegenStatus() As WorkingStatuses
            Get
                Return m_enmRegenStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmRegenStatus = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: WaterPump.RegenOnOff
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "WaterPump.RegenOnOff", _
                            VALUELib.ValueType.U1, Utils.ConvertWorkingStatusValueForUpdateGEM(value))
            End Set
        End Property
#End Region

#Region "Public method"
        Public Overrides Sub ChangeStatus(ByVal PropertyNames As System.Collections.ArrayList, ByVal ReplyValues As System.Collections.ArrayList)
            AVPLib.Log.coreLogger.Info("Enter ChangeStatus")
            MyBase.ChangeStatus(PropertyNames, ReplyValues)
            AVPLib.Log.coreLogger.Info("Leave ChangeStatus")
        End Sub

#End Region

    End Class
End Namespace

