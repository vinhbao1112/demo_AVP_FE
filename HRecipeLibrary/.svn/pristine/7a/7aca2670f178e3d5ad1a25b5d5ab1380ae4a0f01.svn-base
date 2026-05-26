Public Class IBDRecipe
    Inherits BaseRecipe

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Change description of recipe base on configuration data of IBD
    ''' </summary>
    Protected Overrides Function ChangeDescription(ByVal groupCode As String, ByVal parameterName As String, ByRef parameterDescription As String, ByRef saveNotShow As Boolean, ByVal baseConfigData As BaseConfigurationData) As Boolean
        Dim result As Boolean = True

        Try
            If baseConfigData Is Nothing Then
                result = False
                Exit Try
            End If

            Dim ibdConfigData As IBDConfigurationData = CType(baseConfigData, IBDConfigurationData)

            Select Case parameterName
                Case HConstants.Gas1
                    Select Case groupCode
                        Case HConstants.DepositionGasses, HConstants.DepositionGasParameters
                            parameterDescription = String.Format(parameterDescription, ibdConfigData.DepGas1MFCEnable_CalibrationFactorId)
                            saveNotShow = (ibdConfigData.DepGas1MFCEnable_HasShutOffValve = False And ibdConfigData.DepGas1MFCEnable_HasSupplyValve = False)
                            result = Not saveNotShow

                        Case HConstants.EtchGasses, HConstants.EtchGasParameters
                            parameterDescription = String.Format(parameterDescription, ibdConfigData.EtchGas1MFCEnable_CalibrationFactorId)
                            saveNotShow = (ibdConfigData.EtchGas1MFCEnable_HasShutOffValve = False And ibdConfigData.EtchGas1MFCEnable_HasSupplyValve = False)
                            result = Not saveNotShow
                    End Select

                Case HConstants.Gas2
                    Select Case groupCode
                        Case HConstants.DepositionGasses, HConstants.DepositionGasParameters
                            parameterDescription = String.Format(parameterDescription, ibdConfigData.DepGas2MFCEnable_CalibrationFactorId)
                            saveNotShow = (ibdConfigData.DepGas2MFCEnable_HasShutOffValve = False And ibdConfigData.DepGas2MFCEnable_HasSupplyValve = False)
                            result = Not saveNotShow

                        Case HConstants.EtchGasses, HConstants.EtchGasParameters
                            parameterDescription = String.Format(parameterDescription, ibdConfigData.EtchGas2MFCEnable_CalibrationFactorId)
                            saveNotShow = (ibdConfigData.EtchGas2MFCEnable_HasShutOffValve = False And ibdConfigData.EtchGas2MFCEnable_HasSupplyValve = False)
                            result = Not saveNotShow
                    End Select

                Case HConstants.Gas3
                    Select Case groupCode
                        Case HConstants.DepositionGasses, HConstants.DepositionGasParameters
                            parameterDescription = String.Format(parameterDescription, ibdConfigData.DepGas3MFCEnable_CalibrationFactorId)
                            saveNotShow = (ibdConfigData.DepGas3MFCEnable_HasShutOffValve = False And ibdConfigData.DepGas3MFCEnable_HasSupplyValve = False)
                            result = Not saveNotShow

                        Case HConstants.EtchGasses, HConstants.EtchGasParameters
                            parameterDescription = String.Format(parameterDescription, ibdConfigData.EtchGas3MFCEnable_CalibrationFactorId)
                            saveNotShow = (ibdConfigData.EtchGas3MFCEnable_HasShutOffValve = False And ibdConfigData.EtchGas3MFCEnable_HasSupplyValve = False)
                            result = Not saveNotShow
                    End Select

                Case HConstants.Gas4
                    Select Case groupCode
                        Case HConstants.DepositionGasses, HConstants.DepositionGasParameters
                            parameterDescription = String.Format(parameterDescription, ibdConfigData.DepGas4MFCEnable_CalibrationFactorId)
                            saveNotShow = (ibdConfigData.DepGas4MFCEnable_HasShutOffValve = False And ibdConfigData.DepGas4MFCEnable_HasSupplyValve = False)
                            result = Not saveNotShow

                        Case HConstants.EtchGasses, HConstants.EtchGasParameters
                            parameterDescription = String.Format(parameterDescription, ibdConfigData.EtchGas4MFCEnable_CalibrationFactorId)
                            saveNotShow = (ibdConfigData.EtchGas4MFCEnable_HasShutOffValve = False And ibdConfigData.EtchGas4MFCEnable_HasSupplyValve = False)
                            result = Not saveNotShow
                    End Select

                Case HConstants.Gas5
                    Select Case groupCode
                        Case HConstants.DepositionGasses, HConstants.DepositionGasParameters
                            parameterDescription = String.Format(parameterDescription, ibdConfigData.DepGas5MFCEnable_CalibrationFactorId)
                            saveNotShow = (ibdConfigData.DepGas5MFCEnable_HasShutOffValve = False And ibdConfigData.DepGas5MFCEnable_HasSupplyValve = False)
                            result = Not saveNotShow

                        Case HConstants.EtchGasses, HConstants.EtchGasParameters
                            parameterDescription = String.Format(parameterDescription, ibdConfigData.EtchGas5MFCEnable_CalibrationFactorId)
                            saveNotShow = (ibdConfigData.EtchGas5MFCEnable_HasShutOffValve = False And ibdConfigData.EtchGas5MFCEnable_HasSupplyValve = False)
                            result = Not saveNotShow

                    End Select
                Case HConstants.PbnGas
                    Select Case groupCode
                        Case HConstants.DepositionBeamParams
                            parameterDescription = String.Format(parameterDescription, ibdConfigData.DepPBNGas_Installed_CalibrationFactorId)
                            saveNotShow = (ibdConfigData.DepPBNGas_Installed_Name = String.Empty)
                            result = Not saveNotShow

                        Case HConstants.EtchBeamParams
                            parameterDescription = String.Format(parameterDescription, ibdConfigData.EtchPBNGas_Installed_CalibrationFactorId)
                            saveNotShow = (ibdConfigData.EtchPBNGas_Installed_Name = String.Empty)
                            result = Not saveNotShow
                    End Select
                Case HConstants.TargetSide, HConstants.Target_Side
                    Dim indexTarget As Integer = 0
                    If ibdConfigData.Target1_Installed Then
                        indexTarget += 1
                    End If
                    If ibdConfigData.Target2_Installed Then
                        indexTarget += 1
                    End If
                    If ibdConfigData.Target3_Installed Then
                        indexTarget += 1
                    End If
                    If ibdConfigData.Target4_Installed Then
                        indexTarget += 1
                    End If
                    If ibdConfigData.Target5_Installed Then
                        indexTarget += 1
                    End If
                    If ibdConfigData.Target6_Installed Then
                        indexTarget += 1
                    End If
                    If ibdConfigData.Target7_Installed Then
                        indexTarget += 1
                    End If
                    If ibdConfigData.Target8_Installed Then
                        indexTarget += 1
                    End If

                    parameterDescription = String.Format("Target Side (1-{0})", indexTarget.ToString())
                    result = Not saveNotShow
                Case HConstants.FlowcoolFlowrate
                    parameterDescription = String.Format(parameterDescription, ibdConfigData.FlowCool_Installed_CalibrationFactorId)
                    saveNotShow = (ibdConfigData.FlowCool_Installed_Name = String.Empty)
                    result = Not saveNotShow

                Case HConstants.PbnFlowrate
                    Select Case groupCode
                        Case HConstants.DepositionBeamParams, HConstants.DepBeamParameters
                            parameterDescription = String.Format(parameterDescription, ibdConfigData.DepPBNGas_Installed_CalibrationFactorId)
                            saveNotShow = (ibdConfigData.DepPBNGas_Installed_Name = String.Empty)
                            result = Not saveNotShow

                        Case HConstants.EtchBeamParams, HConstants.EtchBeamParameters
                            parameterDescription = String.Format(parameterDescription, ibdConfigData.EtchPBNGas_Installed_CalibrationFactorId)
                            saveNotShow = (ibdConfigData.EtchPBNGas_Installed_Name = String.Empty)
                            result = Not saveNotShow
                    End Select

            End Select
        Catch ex As Exception
            Logger.Error(ex.ToString())
            result = False
        End Try

        Return result
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' check to visible/invisible group parameter in recipe
    ''' </summary>
    Protected Overrides Function CheckingGroupShowInUI(ByVal groupCode As String, ByRef groupSaveButNotShow As Boolean, ByVal value As String, ByVal baseConfigData As BaseConfigurationData) As String
        Dim groupShowInUI As String = value

        Try
            Dim ibdConfigData As IBDConfigurationData = CType(baseConfigData, IBDConfigurationData)

            Select Case groupCode
                Case HConstants.EtchBeamParams, HConstants.EtchGasses
                    groupShowInUI = ibdConfigData.Etch_RF_Power_Supply_Installed.ToString()
                    groupSaveButNotShow = Not ibdConfigData.Etch_RF_Power_Supply_Installed
                Case HConstants.DepositionBeamParams, HConstants.DepositionGasses
                    groupShowInUI = ibdConfigData.Dep_RF_Power_Supply_Installed.ToString()
                    groupSaveButNotShow = Not ibdConfigData.Dep_RF_Power_Supply_Installed
                Case HConstants.HotChuck, HConstants.SourceMagnet, HConstants.SourceElectroMagnet, HConstants.RThetaShaper, HConstants.MagneticChuck
                    groupSaveButNotShow = True
                Case HConstants.TiltSweep
                    groupSaveButNotShow = Not ibdConfigData.SupportTiltSweepMode
                Case HConstants.RecipeComment
                    groupShowInUI = Boolean.FalseString.ToString()
                    groupSaveButNotShow = True

            End Select
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try

        Return groupShowInUI
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' check to visible/invisible parameter in recipe
    ''' </summary>
    Protected Overrides Function CheckingParameter(ByVal groupCode As String, ByVal parameterName As String, ByRef saveNotShow As Boolean, ByVal baseConfigData As BaseConfigurationData) As Boolean
        Dim result As Boolean = True

        Try
            If baseConfigData Is Nothing Then
                result = False
                Exit Try
            End If

            Dim ibdConfigData As IBDConfigurationData = CType(baseConfigData, IBDConfigurationData)

            If Not ibdConfigData.FixtureShutter_Installed Then
                If parameterName = HConstants.OpenFixtureShutterAtStart _
                OrElse parameterName = HConstants.OpenFixtureShutterAtBeam _
                OrElse parameterName = HConstants.CloseFixtureShutterAtEnd _
                OrElse parameterName = HConstants.Open_Fixture_Shutter_At_Start _
                OrElse parameterName = HConstants.Open_Fixture_Shutter_At_Beam _
                OrElse parameterName = HConstants.Close_Fixture_Shutter_At_End _
                OrElse parameterName = HConstants.Open_Target_Shutter_At_Start _
                OrElse parameterName = HConstants.Open_Target_Shutter_At_Beam _
                OrElse parameterName = HConstants.Close_Target_Shutter_At_End _
                OrElse parameterName = HConstants.Open_Etch_Shutter_At_Start _
                OrElse parameterName = HConstants.Open_Etch_Shutter_At_Beam _
                OrElse parameterName = HConstants.Close_Etch_Shutter_At_End _
                OrElse parameterName = HConstants.DLC_OpenEtchShutterAtStart _
                OrElse parameterName = HConstants.DLC_OpenEtchShutterAtBeam _
                OrElse parameterName = HConstants.DLC_CloseEtchShutterAtEnd Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If
            End If

            If Not ibdConfigData.DepoShutter_Installed Then
                If parameterName = HConstants.OpenDepoShutterAtStart _
                OrElse parameterName = HConstants.OpenDepoShutterAtBeam _
                OrElse parameterName = HConstants.CloseDepoShutterAtEnd _
                OrElse parameterName = HConstants.Open_Depo_Shutter_At_Start _
                OrElse parameterName = HConstants.Open_Depo_Shutter_At_Beam _
                OrElse parameterName = HConstants.Close_Depo_Shutter_At_End Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If
            End If

            If Not ibdConfigData.TargetShutter_Installed Then
                If parameterName = HConstants.OpenTargetShutterAtStart _
                OrElse parameterName = HConstants.OpenTargetShutterAtBeam _
                OrElse parameterName = HConstants.CloseTargetShutterAtEnd Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If
            End If

            If Not ibdConfigData.Cryo1_Installed Then
                If parameterName = HConstants.OpenCryo1GateValve Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If
            End If

            If Not ibdConfigData.Cryo2_Installed Then
                If parameterName = HConstants.OpenCryo2GateValve Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If
            End If

            If Not ibdConfigData.Fast_Tilt_Installed OrElse Not ibdConfigData.SupportTiltSweepMode Then
                If parameterName = HConstants.Fixture_Tilt OrElse _
                   parameterName = HConstants.Tilt_Sweep_Start_Angle OrElse _
                   parameterName = HConstants.Tilt_Sweep_End_Angle OrElse _
                   parameterName = HConstants.Tilt_Sweep_Dwell_Time Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If
            End If

            If parameterName = HConstants.RecipeComments Then
                saveNotShow = True
                result = False
                Exit Try
            End If


            ''Support VIBD.
            If ibdConfigData.ChamberType = "VIBD" Then

                If parameterName = HConstants.UseRGA AndAlso Not ibdConfigData.RGAInstalled Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.WaitForGEMStepTime Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.UseTEC Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.TECTargetVoltage Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.OpenTurboGate Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.UseTurboThrottlePosition Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.TurboPositionSetpoint Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.UseCryoThrottlePosition Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.CryoPositionSetpoint Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.OpenCryo2Gate Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.UseCryo2ThrottlePosition Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.Cryo2PositionSetpoint Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.Process_Ends_By Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.Endpoint_Script_Name Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.UseEtchRateCorrection Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.Etch_Rate_Correction_Power_Group Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.Ion_Charge Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.Target_Angle Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.Use_PBN2_Gas_Channel Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.Min_Etch_Time_Sec Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If parameterName = HConstants.Sweep_Delay_Time Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

            End If

        Catch ex As Exception
            Logger.Error(ex.ToString())
            result = False
        End Try

        Return result
    End Function

    ''' <author>
    '''    	<name> Nguyen Dinh Minh Thi </name>
    '''    	<date> 2016-10-26 </date>
    ''' </author>
    ''' <summary>
    ''' check to list of display item in recipe
    ''' </summary>
    Protected Overrides Function CheckingListOfDisplayItem(ByVal GroupCode As String, ByVal parameterName As String, ByRef name As String, ByRef value As String, ByVal baseConfigData As BaseConfigurationData) As Boolean
        Dim result As Boolean = True

        Try
            If baseConfigData Is Nothing Then
                result = False
                Exit Try
            End If

            Dim ibdConfigData As IBDConfigurationData = CType(baseConfigData, IBDConfigurationData)

            If (GroupCode = HConstants.ProcessControl OrElse GroupCode = HConstants.Control) And _
                (parameterName = HConstants.TargetSide OrElse parameterName = HConstants.Target_Side) Then
                If (name = HConstants.Number1 And (Not ibdConfigData.Target1_Installed)) Or _
                   (name = HConstants.Number2 And (Not ibdConfigData.Target2_Installed)) Or _
                   (name = HConstants.Number3 And (Not ibdConfigData.Target3_Installed)) Or _
                   (name = HConstants.Number4 And (Not ibdConfigData.Target4_Installed)) Or _
                   (name = HConstants.Number5 And (Not ibdConfigData.Target5_Installed)) Or _
                   (name = HConstants.Number6 And (Not ibdConfigData.Target6_Installed)) Or _
                   (name = HConstants.Number7 And (Not ibdConfigData.Target7_Installed)) Or _
                   (name = HConstants.Number8 And (Not ibdConfigData.Target8_Installed)) Then
                    value = String.Empty

                Else
                    If name = HConstants.Number0 Then
                        name = name & " (Don't move)"
                    ElseIf name = HConstants.Number1 Then
                        If (ibdConfigData.Target_Material <> String.Empty) Then
                            name = name & " (" & ibdConfigData.Target_Material & ")"
                        End If
                    ElseIf name = HConstants.Number2 Then
                        If (ibdConfigData.Target_Material1 <> String.Empty) Then
                            name = name & " (" & ibdConfigData.Target_Material1 & ")"
                        End If
                    ElseIf name = HConstants.Number3 Then
                        If (ibdConfigData.Target_Material2 <> String.Empty) Then
                            name = name & " (" & ibdConfigData.Target_Material2 & ")"
                        End If
                    ElseIf name = HConstants.Number4 Then
                        If (ibdConfigData.Target_Material3 <> String.Empty) Then
                            name = name & " (" & ibdConfigData.Target_Material3 & ")"
                        End If
                    ElseIf name = HConstants.Number5 Then
                        If (ibdConfigData.Target_Material4 <> String.Empty) Then
                            name = name & " (" & ibdConfigData.Target_Material4 & ")"
                        End If
                    ElseIf name = HConstants.Number6 Then
                        If (ibdConfigData.Target_Material5 <> String.Empty) Then
                            name = name & " (" & ibdConfigData.Target_Material5 & ")"
                        End If
                    ElseIf name = HConstants.Number7 Then
                        If (ibdConfigData.Target_Material6 <> String.Empty) Then
                            name = name & " (" & ibdConfigData.Target_Material6 & ")"
                        End If
                    ElseIf name = HConstants.Number8 Then
                        If (ibdConfigData.Target_Material7 <> String.Empty) Then
                            name = name & " (" & ibdConfigData.Target_Material7 & ")"
                        End If
                    End If

                End If
            End If

        Catch ex As Exception
            Logger.Error(ex.ToString())
            result = False
        End Try

        Return result
    End Function

End Class
