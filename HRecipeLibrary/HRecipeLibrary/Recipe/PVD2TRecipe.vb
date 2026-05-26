Public Class PVD2TRecipe
    Inherits GeneralRecipe
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
            Dim ibdConfigData As PVD2TConfigurationData = CType(baseConfigData, PVD2TConfigurationData)

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

            Dim ibdConfigData As PVD2TConfigurationData = CType(baseConfigData, PVD2TConfigurationData)

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

            If Not ibdConfigData.Target_Power_Supply_RF_Installed Then
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
                If parameterName = HConstants.Fixture_Tilt OrElse
                   parameterName = HConstants.Tilt_Sweep_Start_Angle OrElse
                   parameterName = HConstants.Tilt_Sweep_End_Angle OrElse
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
    '''    	<name> Tinh Le </name>
    '''    	<date> 2023-11-12 </date>
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

            Dim pmConfigData As PVD2TConfigurationData = CType(baseConfigData, PVD2TConfigurationData)

            If GroupCode = HConstants.RFTargetPower AndAlso parameterName = HConstants.TargetSelection Then
                If (Not pmConfigData.Target1_Installed) AndAlso (Not pmConfigData.Target2_Installed) AndAlso
                    (Not pmConfigData.Target3_Installed) AndAlso (Not pmConfigData.Target4_Installed) Then
                    value = String.Empty

                Else
                    If name = HConstants.T1 Then
                        If (pmConfigData.Target_Material <> String.Empty) Then
                            name = name & " (" & pmConfigData.Target_Material & ")"
                        End If
                    ElseIf name = HConstants.T2 Then
                        If (pmConfigData.Target_Material1 <> String.Empty) Then
                            name = name & " (" & pmConfigData.Target_Material1 & ")"
                        End If
                    ElseIf name = HConstants.T3 Then
                        If (pmConfigData.Target_Material2 <> String.Empty) Then
                            name = name & " (" & pmConfigData.Target_Material2 & ")"
                        End If
                    ElseIf name = HConstants.T4 Then
                        If (pmConfigData.Target_Material3 <> String.Empty) Then
                            name = name & " (" & pmConfigData.Target_Material3 & ")"
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
