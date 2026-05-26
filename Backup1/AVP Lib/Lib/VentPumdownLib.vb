Imports AVPLib.ConstEnum
Public Class VentPumdownLib

    Public Enum EnumVentPumdownConfig
        LoaderConfig
        LLVentConfig
        LLPumpdownConfig
        TMVentConfig
        TMPumpdownConfig
        CGConfig
    End Enum

    Public Enum EnumLoaderConfig
        ArmUpDownTimeOut
        ArmExtendRetractTimeOut
        RobotUpDownMotorWaitTime
        RobotExtenRetractMotorWaitTime
        IsolationValveOpenCloseTimeOut
        RoughValveOpenCloseTimeOut
        VentValveOpenCloseTimeOut
        RoughTimeOut
        VentTimeOut
        IBEFixtureMotionInitializeTimeOut
        VentTimeAfterCGReachATM
        RoughTimeAfterCGReachCrossOverPressure
    End Enum

    Public Class LoaderConfig
        Public Shared ArmUpDownTimeOut As Int32 = 15000
        Public Shared ArmExtendRetractTimeOut As Int32 = 15000
        Public Shared RobotUpDownMotorWaitTime As Int32 = 2000
        Public Shared RobotExtenRetractMotorWaitTime As Int32 = 2000
        Public Shared IsolationValveOpenCloseTimeOut As Int32 = 10000
        Public Shared RoughValveOpenCloseTimeOut As Int32 = 10000
        Public Shared VentValveOpenCloseTimeOut As Int32 = 10000
        Public Shared RoughTimeOut As Int32 = 180000
        Public Shared VentTimeOut As Int32 = 180000
        Public Shared IBEFixtureMotionInitializeTimeOut As Int32 = 30000
        Public Shared VentTimeAfterCGReachATM As Int32 = 10000
        Public Shared RoughTimeAfterCGReachCrossOverPressure As Int32 = 10000
    End Class

    Public Enum EnumLLVentConfig
        LLMesaValveOpenCloseTimeOut
        IGOnOffTimeOut
        LLHivacOpenCloseTimeOut
        LLVentValveOpenCloseTimeOut
        LLASlowVentTimeOut
        LLASlowVentPressure
        LLAFastVentTimeOut
        LLAVentPressure
        LLVent_Delay_Time
    End Enum

    Public Class LLVentConfig
        Public Shared LLMesaValveOpenCloseTimeOut As Int32 = 10
        Public Shared IGOnOffTimeOut As Int32 = 10
        Public Shared LLSleep2s As Int32 = 2000
        Public Shared LLHivacOpenCloseTimeout As Int32 = 10
        Public Shared LLVentValveOpenCloseTimeout As Int32 = 10
        Public Shared LLASlowVentTimeout As Int32 = 180
        Public Shared LLASlowVentPressure As Double = 150
        Public Shared LLAFastVentTimeout As Int32 = 300
        Public Shared LLAVentPressure As Double = 760
        Public Shared LLVent_Delay_Time As Int32 = 10
    End Class

    Public Enum EnumLLPumpdownConfig
        LLMesaValveOpenCloseTimeOut
        IGOnOffTimeOut
        LLHivacOpenCloseTimeOut
        TMMechanicalPumpOnPressure
        LLASlowRoughPressure
        LLASlowRoughPressureTimeOut
        LLAFastRoughPressure
        LLAFastRoughPressureTimeOut
        LLACryoColdTemp
        IGOnDelay
        LLRoughValveOpenCloseTimeOut
        LLPumpDown_Delay_Time
        LLMakeRoughLineInUseTimeOut
    End Enum

    Public Class LLPumpdownConfig
        Public Shared LLMesaValveOpenCloseTimeOut As Int32 = 10
        Public Shared IGOnOffTimeOut As Int32 = 10
        Public Shared LLHivacOpenCloseTimeOut As Int32 = 10
        Public Shared TMMechanicalPumpOnPressure As Double = 0.1
        Public Shared LLASlowRoughPressure As Double = 350
        Public Shared LLMappingPressure As Double = 200 ' new request from mr khoi ha, 18-07-2012
        Public Shared LLASlowRoughPressureTimeOut = 600
        Public Shared LLAFastRoughPressure As Double = 0.15
        Public Shared LLAFastRoughPressureTimeOut As Int32 = 1500
        Public Shared LLACryoColdTemp As Double = 20
        Public Shared LLRoughValveOpenCloseTimeOut As Int32 = 10
        Public Shared LLVentValveOpenCloseTimeOut As Int32 = 10
        Public Shared IGOnDelay As Int32 = 10
        'Khoi Ha 21-03-2013 Auto pump down Llx/TM/PM.   Continue to rough 30s instead of 10s.
        Public Shared LLPumpDown_Delay_Time As Int32 = 30
        Public Shared LLOpenCloseForlineTimeOut As Int32 = 10
        Public Shared LLPumpPackageTimeOut As Int32 = 1200
        Public Shared LLPumpDown_Wait_After_Close_LL_TM_Valves As Int32 = 5000
        Public Shared LLPumpDown_Wait_After_Open_Hivac As Int32 = 15000
        Public Shared LLPumpDown_Wait_After_Open_TM_TurboForeline As Int32 = 15000
        Public Shared LLPumpDown_Wait_Other_PumpDown As Int32 = 600000
        Public Shared LLMakeRoughLineInUseTimeOut As Int64 = 600
        Public Shared LLTurnOffTurboTimeOut As Int64 = 30
        Public Shared LLPumpDownComplete As Int64 = 1800000 '30m
        Public Shared LLVentComplete As Int64 = 1800000 '30m
        Public Shared LLRoughPumpStable As Int64 = 5000 '5s
        Public Shared RoughPumpPMTimeOut As Int64 = 60 '60s
    End Class

    Public Enum EnumTMVentConfig
        TMMesaValvesOpenCloseTimeOut
        IGOnOffTimeOut
        TMHivacOpenCloseTimeOut
        TMVentPressure
        TMVentTimeOut
        TMVentValveOpenCloseTimeOut
        TMVent_Delay_Time
    End Enum

    Public Class TMVentConfig
        Public Shared TMMesaValvesOpenCloseTimeOut As Int32 = 10
        Public Shared IGOnOffTimeOut As Int32 = 10
        Public Shared TMHivacOpenCloseTimeOut As Int32 = 10
        Public Shared TMVentPressure As Double = 760
        Public Shared TMVentTimeOut As Int32 = 300
        Public Shared TMVentValveOpenCloseTimeOut As Int32 = 10
        Public Shared TMVent_Delay_Time As Int32 = 10
        Public Shared TMDelay2s As Int32 = 2000

    End Class

    Public Enum EnumTMPumpdownConfig
        TMMesaValvesOpenCloseTimeOut
        IGOnOffTimeOut
        TMHivacOpenCloseTimeOut
        TMMechanicalPumpOnPressure
        TMRoughPressure
        TMRoughTimeOut
        TMCryoColdTemp
        IGOnDelay
        TMRoughValveOpenCloseTimeOut
        TMPumdown_Delay_Time
        TMMakeRoughLineInUseTimeOut
    End Enum
    Public Enum EnumCGConfig
        TMCGTripPoint
        LLACGTripPoint
        MPCGTripPoint
        LLATurboCGTripPoint
        TMTurboCGTripPoint
    End Enum
    Public Class TMPumpdownConfig
        Public Shared TMMesaValvesOpenCloseTimeOut As Int32 = 10
        Public Shared IGOnOffTimeOut As Int32 = 10
        Public Shared TMSleep2s As Int32 = 2000
        Public Shared TMHivacOpenCloseTimeOut As Int32 = 10
        Public Shared TMMechanicalPumpOnPressure As Double = 0.1
        Public Shared TMRoughPressure As Double = 0.15
        Public Shared TMRoughTimeOut As Int32 = 1200
        Public Shared TMCryoColdTemp As Double = 15
        Public Shared IGOnDelay As Int32 = 10
        Public Shared TMRoughValveOpenCloseTimeOut As Int32 = 10
        'Khoi Ha 21-03-2013 Auto pump down Llx/TM/PM.   Continue to rough 30s instead of 10s.
        Public Shared TMPumdown_Delay_Time As Int32 = 30
        Public Shared TMPumpDown_Wait_After_Open_Hivac As Int32 = 15000
        Public Shared TMPumpDown_Wait_After_Open_Or_Close_Foreline As Int32 = 5000
        Public Shared TMTurnOnTurboTimeOut As Int32 = 900
        Public Shared TMTurboForelineOpenCloseTimeOut As Int32 = 10
        Public Shared TMMakeRoughLineInUseTimeOut As Int64 = 600
        Public Shared TMTurnOffTurboTimeOut As Int64 = 30
        Public Shared TMPumpDownComplete As Int64 = 1800000 '30m
    End Class
    Public Class CGConfig
        Public Shared TMCGTripPoint As Single = 0.5
        Public Shared LLACGTripPoint As Single = 0.5
        Public Shared MPCGTripPoint As Single = 0.5
        Public Shared LLATurboCGTripPoint As Single = 0.5
        Public Shared TMTurboCGTripPoint As Single = 0.5
    End Class
    Public Class LLTMPumpPackage
        Public Shared TMCryoT1Min As Int32 = Int32.Parse(ContainerData.GetPressureConfig(TMCryo_T1Min))
        Public Shared TMCryoT1Max As Int32 = Int32.Parse(ContainerData.GetPressureConfig(TMCryo_T1Max))
        Public Shared TMCryoT2Min As Int32 = Int32.Parse(ContainerData.GetPressureConfig(TMCryo_T2Min))
        Public Shared TMCryoT2Max As Int32 = Int32.Parse(ContainerData.GetPressureConfig(TMCryo_T2Max))

        Public Shared LLACryoT1Min As Int32 = Int32.Parse(ContainerData.GetPressureConfig(LLACryo_T1Min))
        Public Shared LLACryoT1Max As Int32 = Int32.Parse(ContainerData.GetPressureConfig(LLACryo_T1Max))
        Public Shared LLACryoT2Min As Int32 = Int32.Parse(ContainerData.GetPressureConfig(LLACryo_T2Min))
        Public Shared LLACryoT2Max As Int32 = Int32.Parse(ContainerData.GetPressureConfig(LLACryo_T2Max))
    End Class

    Public Shared Sub GetConfig(ByVal ventPumpdownDoc As System.Xml.XmlDocument)
        AVPLib.Log.coreLogger.Info("Enter GetConfig")
        Try
            Dim root As System.Xml.XmlNode = ventPumpdownDoc.SelectSingleNode(ConstEnum.XPATH_VENTPUMPDOWNCONFIG)
            Dim configNodes As System.Xml.XmlNodeList = root.ChildNodes
            For Each configNode As Xml.XmlNode In configNodes
                If (configNode.Name = EnumVentPumdownConfig.LLVentConfig.ToString()) Then
                    InitLLVentConfig(configNode)
                ElseIf (configNode.Name = EnumVentPumdownConfig.LLPumpdownConfig.ToString()) Then
                    InitLLPumpdownConfig(configNode)
                ElseIf (configNode.Name = EnumVentPumdownConfig.TMVentConfig.ToString()) Then
                    InitTMVentConfig(configNode)
                ElseIf (configNode.Name = EnumVentPumdownConfig.TMPumpdownConfig.ToString()) Then
                    InitTMPumpdownConfig(configNode)
                ElseIf (configNode.Name = EnumVentPumdownConfig.CGConfig.ToString()) Then
                    InitCGonfig(configNode)
                    'ElseIf (configNode.Name = EnumVentPumdownConfig.LoaderConfig.ToString()) Then
                    '    InitLoaderConfig(configNode)
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetConfig")
    End Sub

    Private Const c_Name As String = "Name"
    Private Const c_Value As String = "Value"

    Private Shared Sub InitLoaderConfig(ByVal llVentConfigNode As Xml.XmlNode)
        AVPLib.Log.coreLogger.Info("Enter LoaderConfig")
        For Each configItem As Xml.XmlNode In llVentConfigNode.ChildNodes
            Dim attName As Xml.XmlAttribute = configItem.Attributes.ItemOf(c_Name)
            Dim attVal As Xml.XmlAttribute = configItem.Attributes.ItemOf(c_Value)
            If (attName IsNot Nothing) And (attVal IsNot Nothing) Then
                If (attName.Value = EnumLoaderConfig.ArmUpDownTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LoaderConfig.ArmUpDownTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLoaderConfig.ArmExtendRetractTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LoaderConfig.ArmExtendRetractTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLoaderConfig.RobotUpDownMotorWaitTime.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LoaderConfig.RobotUpDownMotorWaitTime = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLoaderConfig.RobotExtenRetractMotorWaitTime.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LoaderConfig.RobotExtenRetractMotorWaitTime = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLoaderConfig.IsolationValveOpenCloseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LoaderConfig.IsolationValveOpenCloseTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLoaderConfig.RoughValveOpenCloseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LoaderConfig.RoughValveOpenCloseTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLoaderConfig.VentValveOpenCloseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LoaderConfig.VentValveOpenCloseTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLoaderConfig.RoughTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LoaderConfig.RoughTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLoaderConfig.VentTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LoaderConfig.VentTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLoaderConfig.IBEFixtureMotionInitializeTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LoaderConfig.IBEFixtureMotionInitializeTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLoaderConfig.VentTimeAfterCGReachATM.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LoaderConfig.VentTimeAfterCGReachATM = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLoaderConfig.RoughTimeAfterCGReachCrossOverPressure.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LoaderConfig.RoughTimeAfterCGReachCrossOverPressure = val
                        End If
                    End If
                End If
            End If
        Next
        AVPLib.Log.coreLogger.Info("Leave LoaderConfig")
    End Sub

    Private Shared Sub InitLLVentConfig(ByVal llVentConfigNode As Xml.XmlNode)
        AVPLib.Log.coreLogger.Info("Enter InitLLVentConfig")
        For Each configItem As Xml.XmlNode In llVentConfigNode.ChildNodes
            Dim attName As Xml.XmlAttribute = configItem.Attributes.ItemOf(c_Name)
            Dim attVal As Xml.XmlAttribute = configItem.Attributes.ItemOf(c_Value)
            If (attName IsNot Nothing) And (attVal IsNot Nothing) Then
                If (attName.Value = EnumLLVentConfig.IGOnOffTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLVentConfig.IGOnOffTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLVentConfig.LLAVentPressure.ToString()) Then
                    Dim val As Double
                    If (Double.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLVentConfig.LLAVentPressure = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLVentConfig.LLAFastVentTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLVentConfig.LLAFastVentTimeout = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLVentConfig.LLASlowVentPressure.ToString()) Then
                    Dim val As Double
                    If (Double.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLVentConfig.LLASlowVentPressure = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLVentConfig.LLASlowVentTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLVentConfig.LLASlowVentTimeout = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLVentConfig.LLHivacOpenCloseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLVentConfig.LLHivacOpenCloseTimeout = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLVentConfig.LLMesaValveOpenCloseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLVentConfig.LLMesaValveOpenCloseTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLVentConfig.LLVentValveOpenCloseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLVentConfig.LLVentValveOpenCloseTimeout = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLVentConfig.LLVent_Delay_Time.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLVentConfig.LLVent_Delay_Time = val
                        End If
                    End If
                End If
            End If
          

        Next
        AVPLib.Log.coreLogger.Info("Leave InitLLVentConfig")
    End Sub

    Private Shared Sub InitLLPumpdownConfig(ByVal llPumpdownConfigNode As Xml.XmlNode)
        AVPLib.Log.coreLogger.Info("Enter InitLLPumpdownConfig")
        For Each configItem As Xml.XmlNode In llPumpdownConfigNode.ChildNodes
            Dim attName As Xml.XmlAttribute = configItem.Attributes.ItemOf(c_Name)
            Dim attVal As Xml.XmlAttribute = configItem.Attributes.ItemOf(c_Value)
            If (attName IsNot Nothing) And (attVal IsNot Nothing) Then
                If (attName.Value = EnumLLPumpdownConfig.IGOnOffTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLPumpdownConfig.IGOnOffTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLPumpdownConfig.LLAFastRoughPressure.ToString()) Then
                    Dim val As Double
                    If (Double.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLPumpdownConfig.LLAFastRoughPressure = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLPumpdownConfig.LLAFastRoughPressureTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLPumpdownConfig.LLAFastRoughPressureTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLPumpdownConfig.LLASlowRoughPressure.ToString()) Then
                    Dim val As Double
                    If (Double.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLPumpdownConfig.LLASlowRoughPressure = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLPumpdownConfig.LLASlowRoughPressureTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLPumpdownConfig.LLASlowRoughPressureTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLPumpdownConfig.LLHivacOpenCloseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLPumpdownConfig.LLHivacOpenCloseTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLPumpdownConfig.LLMesaValveOpenCloseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLPumpdownConfig.LLMesaValveOpenCloseTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLPumpdownConfig.TMMechanicalPumpOnPressure.ToString()) Then
                    Dim val As Double
                    If (Double.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLPumpdownConfig.TMMechanicalPumpOnPressure = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLPumpdownConfig.LLACryoColdTemp.ToString()) Then
                    Dim val As Double
                    If (Double.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLPumpdownConfig.LLACryoColdTemp = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLPumpdownConfig.LLRoughValveOpenCloseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLPumpdownConfig.LLRoughValveOpenCloseTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLPumpdownConfig.IGOnDelay.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLPumpdownConfig.IGOnDelay = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLPumpdownConfig.LLPumpDown_Delay_Time.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLPumpdownConfig.LLPumpDown_Delay_Time = val
                        End If
                    End If
                ElseIf (attName.Value = EnumLLPumpdownConfig.LLMakeRoughLineInUseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            LLPumpdownConfig.LLMakeRoughLineInUseTimeOut = val
                        End If
                    End If
                End If

            End If
        Next
        AVPLib.Log.coreLogger.Info("Leave InitLLPumpdownConfig")
    End Sub

    Private Shared Sub InitTMVentConfig(ByVal tmVentConfigNode As Xml.XmlNode)
        AVPLib.Log.coreLogger.Info("Enter InitTMVentConfig")
        For Each configItem As Xml.XmlNode In tmVentConfigNode.ChildNodes
            Dim attName As Xml.XmlAttribute = configItem.Attributes.ItemOf(c_Name)
            Dim attVal As Xml.XmlAttribute = configItem.Attributes.ItemOf(c_Value)
            If (attName IsNot Nothing) And (attVal IsNot Nothing) Then
                If (attName.Value = EnumTMVentConfig.IGOnOffTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMVentConfig.IGOnOffTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumTMVentConfig.TMVentPressure.ToString()) Then
                    Dim val As Double
                    If (Double.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMVentConfig.TMVentPressure = val
                        End If
                    End If
                ElseIf (attName.Value = EnumTMVentConfig.TMVentTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMVentConfig.TMVentTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumTMVentConfig.TMHivacOpenCloseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMVentConfig.TMHivacOpenCloseTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumTMVentConfig.TMMesaValvesOpenCloseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMVentConfig.TMMesaValvesOpenCloseTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumTMVentConfig.TMVentValveOpenCloseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMVentConfig.TMVentValveOpenCloseTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumTMVentConfig.TMVent_Delay_Time.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMVentConfig.TMVent_Delay_Time = val
                        End If
                    End If
                End If
            End If
        Next
        AVPLib.Log.coreLogger.Info("Leave InitTMVentConfig")
    End Sub

    Private Shared Sub InitTMPumpdownConfig(ByVal tmPumpdownConfigNode As Xml.XmlNode)
        AVPLib.Log.coreLogger.Info("Enter InitTMPumpdownConfig")
        For Each configItem As Xml.XmlNode In tmPumpdownConfigNode.ChildNodes
            Dim attName As Xml.XmlAttribute = configItem.Attributes.ItemOf(c_Name)
            Dim attVal As Xml.XmlAttribute = configItem.Attributes.ItemOf(c_Value)
            If (attName IsNot Nothing) And (attVal IsNot Nothing) Then
                If (attName.Value = EnumTMPumpdownConfig.IGOnOffTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMPumpdownConfig.IGOnOffTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumTMPumpdownConfig.TMRoughPressure.ToString()) Then
                    Dim val As Double
                    If (Double.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMPumpdownConfig.TMRoughPressure = val
                        End If
                    End If
                ElseIf (attName.Value = EnumTMPumpdownConfig.TMRoughTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMPumpdownConfig.TMRoughTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumTMPumpdownConfig.TMHivacOpenCloseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMPumpdownConfig.TMHivacOpenCloseTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumTMPumpdownConfig.TMMechanicalPumpOnPressure.ToString()) Then
                    Dim val As Double
                    If (Double.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMPumpdownConfig.TMMechanicalPumpOnPressure = val
                        End If
                    End If
                ElseIf (attName.Value = EnumTMPumpdownConfig.TMCryoColdTemp.ToString()) Then
                    Dim val As Double
                    If (Double.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMPumpdownConfig.TMCryoColdTemp = val
                        End If
                    End If
                ElseIf (attName.Value = EnumTMPumpdownConfig.TMMesaValvesOpenCloseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMPumpdownConfig.TMMesaValvesOpenCloseTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumTMPumpdownConfig.TMRoughValveOpenCloseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMPumpdownConfig.TMRoughValveOpenCloseTimeOut = val
                        End If
                    End If
                ElseIf (attName.Value = EnumTMPumpdownConfig.TMPumdown_Delay_Time.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMPumpdownConfig.TMPumdown_Delay_Time = val
                        End If
                    End If
                ElseIf (attName.Value = EnumTMPumpdownConfig.TMMakeRoughLineInUseTimeOut.ToString()) Then
                    Dim val As Int32
                    If (Int32.TryParse(attVal.Value, val)) Then
                        If (val >= 0) Then
                            TMPumpdownConfig.TMMakeRoughLineInUseTimeOut = val
                        End If
                    End If
                End If
            End If
        Next
        AVPLib.Log.coreLogger.Info("Leave InitTMPumpdownConfig")
    End Sub

    ''' <author>
    '''    	<name>Tinh Le</name>
    '''    	<date> 2009-29-11</date>
    ''' </author>
    ''' <summary>
    ''' InitCGonfig
    ''' </summary>
    Private Shared Sub InitCGonfig(ByVal cgConfigNode As Xml.XmlNode)
        AVPLib.Log.coreLogger.Info("Enter InitTMPumpdownConfig")
        Try
            For Each configItem As Xml.XmlNode In cgConfigNode.ChildNodes
                Dim attName As Xml.XmlAttribute = configItem.Attributes.ItemOf(c_Name)
                Dim attVal As Xml.XmlAttribute = configItem.Attributes.ItemOf(c_Value)
                If (attName IsNot Nothing) And (attVal IsNot Nothing) Then
                    If (attName.Value = EnumCGConfig.TMCGTripPoint.ToString()) Then
                        Dim val As Single
                        If (Single.TryParse(attVal.Value, val)) Then
                            If (val >= 0) Then
                                CGConfig.TMCGTripPoint = val
                            End If
                        End If
                    ElseIf (attName.Value = EnumCGConfig.LLACGTripPoint.ToString()) Then
                        Dim val As Single
                        If (Single.TryParse(attVal.Value, val)) Then
                            If (val >= 0) Then
                                CGConfig.LLACGTripPoint = val
                            End If
                        End If
                    ElseIf (attName.Value = EnumCGConfig.MPCGTripPoint.ToString()) Then
                        Dim val As Single
                        If (Single.TryParse(attVal.Value, val)) Then
                            If (val >= 0) Then
                                CGConfig.MPCGTripPoint = val
                            End If
                        End If
                    ElseIf (attName.Value = EnumCGConfig.LLATurboCGTripPoint.ToString()) Then
                        Dim val As Single
                        If (Single.TryParse(attVal.Value, val)) Then
                            If (val >= 0) Then
                                CGConfig.LLATurboCGTripPoint = val
                            End If
                        End If
                    ElseIf (attName.Value = EnumCGConfig.TMTurboCGTripPoint.ToString()) Then
                        Dim val As Single
                        If (Single.TryParse(attVal.Value, val)) Then
                            If (val >= 0) Then
                                CGConfig.TMTurboCGTripPoint = val
                            End If
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave InitTMPumpdownConfig")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-06-16</date>
    ''' </author>
    ''' <summary>
    ''' SavePumpdown
    ''' </summary>
    ''' <param name="PressureDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SavePumpdown(ByVal PumpdownDoc As System.Xml.XmlDocument, ByVal mapPumpdown As Hashtable, ByVal PumpdownConfig As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SavePumpdown")
        Try
            Dim root As System.Xml.XmlNode = PumpdownDoc.SelectSingleNode(ConstEnum.XPATH_VENTPUMPDOWNCONFIG)
            Dim nodeListPumpdown As System.Xml.XmlNodeList = root.ChildNodes

            For e As Integer = 0 To nodeListPumpdown.Count - 1
                Try
                    Dim nodePumpdown As System.Xml.XmlNode = nodeListPumpdown.Item(e)
                    Dim Name As String = String.Empty
                    If nodePumpdown.Name = PumpdownConfig Then
                        For i As Integer = 0 To nodePumpdown.ChildNodes.Count - 1
                            Name = nodePumpdown.ChildNodes.Item(i).Attributes.ItemOf("Name").InnerText
                            Dim pumpdown As Double = mapPumpdown.Item(Name)
                            If pumpdown >= PUMPDOWN_DEFAULT_VAL Then
                                nodePumpdown.ChildNodes.Item(i).Attributes.ItemOf("Value").Value = pumpdown
                            Else
                                nodePumpdown.ChildNodes.Item(i).Attributes.ItemOf("Value").Value = PUMPDOWN_DEFAULT_VAL
                            End If
                        Next
                    End If
                Catch ex As Exception
                    AVPLib.Log.coreLogger.Info("Error in insert data: " & ex.Message)
                End Try
            Next
            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, PumpdownDoc)
            ' update the values
            If PumpdownConfig = TMPUMPDOWN_CONFIG Then
                For Each keyvalue As DictionaryEntry In mapPumpdown
                    If keyvalue.Key = "TMMechanicalPumpOnPressure" Then
                        TMPumpdownConfig.TMMechanicalPumpOnPressure = keyvalue.Value
                    End If
                    If keyvalue.Key = "TMRoughPressure" Then
                        TMPumpdownConfig.TMRoughPressure = keyvalue.Value
                    End If
                    If keyvalue.Key = "TMCryoColdTemp" Then
                        TMPumpdownConfig.TMCryoColdTemp = keyvalue.Value
                    End If
                    If keyvalue.Key = "IGOnDelay" Then
                        TMPumpdownConfig.IGOnDelay = keyvalue.Value
                    End If

                    If keyvalue.Key = ConstEnum.TM_MESA_VALVE_OPEN_CLOSE_TIMEOUT Then
                        TMPumpdownConfig.TMMesaValvesOpenCloseTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.IG_ON_OFF_TIMEOUT Then
                        TMPumpdownConfig.IGOnOffTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.TM_HIVAC_OPEN_CLOSE_TIMEOUT Then
                        TMPumpdownConfig.TMHivacOpenCloseTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.TM_ROUGH_TIMEOUT Then
                        TMPumpdownConfig.TMRoughTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.TM_PUMPDOWN_DELAY_TIME Then
                        TMPumpdownConfig.TMPumdown_Delay_Time = keyvalue.Value
                    End If
                Next
            ElseIf PumpdownConfig = LLPUMPDOWN_CONFIG Then
                For Each keyvalue As DictionaryEntry In mapPumpdown
                    If keyvalue.Key = "TMMechanicalPumpOnPressure" Then
                        LLPumpdownConfig.TMMechanicalPumpOnPressure = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.LLA_CG_ON_SLOW_ROUGH_VALVE_OPEN Then
                        LLPumpdownConfig.LLASlowRoughPressure = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.LLA_CG_ON_FAST_ROUGH_VALVE_OPEN Then
                        LLPumpdownConfig.LLAFastRoughPressure = keyvalue.Value
                    End If
                    If keyvalue.Key = "LLACryoColdTemp" Then
                        LLPumpdownConfig.LLACryoColdTemp = keyvalue.Value
                    End If

                    If keyvalue.Key = ConstEnum.LL_MESA_VALVE_OPEN_CLOSE_TIMEOUT Then
                        LLPumpdownConfig.LLMesaValveOpenCloseTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.IG_ON_OFF_TIMEOUT Then
                        LLPumpdownConfig.IGOnOffTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.LL_HIVAC_OPEN_CLOSE_TIMEOUT Then
                        LLPumpdownConfig.LLHivacOpenCloseTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.LLA_SLOW_ROUGH_PRESSURE_TIMEOUT Then
                        LLPumpdownConfig.LLASlowRoughPressureTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.LLA_FAST_ROUGH_PRESSURE_TIMEOUT Then
                        LLPumpdownConfig.LLAFastRoughPressureTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.IG_ON_DELAY Then
                        LLPumpdownConfig.IGOnDelay = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.LL_ROUGH_VALVE_OPEN_CLOSE_TIMEOUT Then
                        LLPumpdownConfig.LLRoughValveOpenCloseTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.LL_PUMPDOWN_DELAY_TIME Then
                        LLPumpdownConfig.LLPumpDown_Delay_Time = keyvalue.Value
                    End If
                Next
            ElseIf PumpdownConfig = LLVENT_CONFIG Then
                For Each keyvalue As DictionaryEntry In mapPumpdown
                    If keyvalue.Key = ConstEnum.LLA_CG_ON_SLOW_VENT_VALVE_OPEN Then
                        LLVentConfig.LLASlowVentPressure = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.LLA_CG_ON_FAST_VENT_VALVE_OPEN Then
                        LLVentConfig.LLAVentPressure = keyvalue.Value
                    End If

                    If keyvalue.Key = ConstEnum.LL_MESA_VALVE_OPEN_CLOSE_TIMEOUT Then
                        LLVentConfig.LLMesaValveOpenCloseTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.IG_ON_OFF_TIMEOUT Then
                        LLVentConfig.IGOnOffTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.LL_HIVAC_OPEN_CLOSE_TIMEOUT Then
                        LLVentConfig.LLHivacOpenCloseTimeout = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.LLA_SLOW_VENT_TIMEOUT Then
                        LLVentConfig.LLASlowVentTimeout = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.LLA_FAST_VENT_TIMEOUT Then
                        LLVentConfig.LLAFastVentTimeout = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.LL_VENT_VALVE_OPEN_CLOSE_TIMEOUT Then
                        LLVentConfig.LLVentValveOpenCloseTimeout = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.LL_VENT_DELAY_TIME Then
                        LLVentConfig.LLVent_Delay_Time = keyvalue.Value
                    End If
                Next
            ElseIf PumpdownConfig = TMVENT_CONFIG Then
                For Each keyvalue As DictionaryEntry In mapPumpdown
                    If keyvalue.Key = "TMVentPressure" Then
                        TMVentConfig.TMVentPressure = keyvalue.Value
                    End If

                    If keyvalue.Key = ConstEnum.TM_MESA_VALVE_OPEN_CLOSE_TIMEOUT Then
                        TMVentConfig.TMMesaValvesOpenCloseTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.IG_ON_OFF_TIMEOUT Then
                        TMVentConfig.IGOnOffTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.TM_HIVAC_OPEN_CLOSE_TIMEOUT Then
                        TMVentConfig.TMHivacOpenCloseTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.TM_VENT_TIMEOUT Then
                        TMVentConfig.TMVentTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.TM_VENT_VALVE_OPEN_CLOSE_TIMEOUT Then
                        TMVentConfig.TMVentValveOpenCloseTimeOut = keyvalue.Value
                    End If
                    If keyvalue.Key = ConstEnum.TM_VENT_DELAY_TIME Then
                        TMVentConfig.TMVent_Delay_Time = keyvalue.Value
                    End If
                Next
            End If
            AVPLib.Log.coreLogger.Info("Leave SavePumpdown")
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SavePumpdown")
        Return False
    End Function
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-06-16</date>
    ''' </author>
    ''' <summary>
    ''' GetVentPumpdownConfig
    ''' </summary>
    ''' <param name="PressureDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetVentPumpdownConfig(ByVal root As System.Xml.XmlNode, ByVal VentPumpdownConfig As String) As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetVentPumpdownConfig")
        Dim map As New Hashtable()
        Try
            Dim nodeListEquipment As System.Xml.XmlNodeList = root.ChildNodes
            If nodeListEquipment.Count < ConstEnum.MaxVENT_PUMPDOWN_CONFIG Then
                ContainerData.Search_And_Append_System_Values("VentPumpdownConfig", root)
            End If
            For e As Integer = 0 To nodeListEquipment.Count - 1
                Dim nodeEquipment As System.Xml.XmlNode = nodeListEquipment.Item(e)
                If nodeEquipment.Name = VentPumpdownConfig Then
                    Select Case VentPumpdownConfig
                        Case LLPUMPDOWN_CONFIG
                            If nodeEquipment.ChildNodes.Count < MaxLLPUMPDOWN_CONFIG Then
                                ContainerData.Search_And_Append_System_Values(LLPUMPDOWN_CONFIG, nodeEquipment)
                            End If
                        Case TMPUMPDOWN_CONFIG
                            If nodeEquipment.ChildNodes.Count < MaxTMPUMPDOWN_CONFIG Then
                                ContainerData.Search_And_Append_System_Values(TMPUMPDOWN_CONFIG, nodeEquipment)
                            End If
                        Case LLVENT_CONFIG
                            If nodeEquipment.ChildNodes.Count < MaxLLVENT_CONFIG Then
                                ContainerData.Search_And_Append_System_Values(LLVENT_CONFIG, nodeEquipment)
                            End If
                        Case TMVENT_CONFIG
                            If nodeEquipment.ChildNodes.Count < MaxTMVENT_CONFIG Then
                                ContainerData.Search_And_Append_System_Values(TMVENT_CONFIG, nodeEquipment)
                            End If
                        Case CG_CONFIG
                            If nodeEquipment.ChildNodes.Count < MaxCG_CONFIG Then
                                ContainerData.Search_And_Append_System_Values(CG_CONFIG, nodeEquipment)
                            End If
                    End Select
                    For i As Integer = 0 To nodeEquipment.ChildNodes.Count - 1
                        Dim Name As String = nodeEquipment.ChildNodes.Item(i).Attributes.ItemOf("Name").InnerText
                        Dim Code As String = nodeEquipment.ChildNodes.Item(i).Attributes.ItemOf("Value").InnerText
                        map.Add(Name, Code)
                    Next
                End If
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetVentPumpdownConfig")
        Return map
    End Function
End Class
