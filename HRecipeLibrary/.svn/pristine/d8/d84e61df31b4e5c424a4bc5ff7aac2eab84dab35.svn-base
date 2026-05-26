Public Class PVD4Recipe
    Inherits GeneralRecipe

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Change description of recipe base on configuration data of IBE
    ''' </summary>
    Protected Overrides Function ChangeDescription(ByVal groupCode As String, ByVal parameterName As String, ByRef parameterDescription As String, ByRef saveNotShow As Boolean, ByVal baseConfigData As BaseConfigurationData) As Boolean
        Dim result As Boolean = True

        Try
            If baseConfigData Is Nothing Then
                result = False
                Exit Try
            End If

            result = MyBase.ChangeDescription(groupCode, parameterName, parameterDescription, saveNotShow, baseConfigData)

            Dim pvd4ConfigData As PVD4ConfigurationData = CType(baseConfigData, PVD4ConfigurationData)

            Select Case parameterName
                Case HConstants.StaticPostion
                    parameterDescription = String.Format(parameterDescription, pvd4ConfigData.NumberOfSlot)
                Case HConstants.TargetPulseWidth
                    If pvd4ConfigData.Target_Power_Supply_DC_Installed_WhichModel = HConstants.AePulseDC Then
                        parameterDescription = HConstants.TargetPulseWidthDescription
                    End If
                Case HConstants.TableHeight
                    If pvd4ConfigData.Chuck_Position_TSD_Ref Then
                        parameterDescription = HConstants.TableHeightWithTSDMode
                    End If
                Case HConstants.CCRGas1
                    parameterDescription = String.Format(parameterDescription, pvd4ConfigData.Gas1CCREnable_CalibrationFactorId)
                    saveNotShow = (pvd4ConfigData.Gas1CCREnable_HasShutOffValve = False And pvd4ConfigData.Gas1CCREnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.CCRGas2
                    parameterDescription = String.Format(parameterDescription, pvd4ConfigData.Gas2CCREnable_CalibrationFactorId)
                    saveNotShow = (pvd4ConfigData.Gas2CCREnable_HasShutOffValve = False And pvd4ConfigData.Gas2CCREnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.CCRGas3
                    parameterDescription = String.Format(parameterDescription, pvd4ConfigData.Gas3CCREnable_CalibrationFactorId)
                    saveNotShow = (pvd4ConfigData.Gas3CCREnable_HasShutOffValve = False And pvd4ConfigData.Gas3CCREnable_HasSupplyValve = False)
                    result = Not saveNotShow

                Case HConstants.CCRGas4
                    parameterDescription = String.Format(parameterDescription, pvd4ConfigData.Gas4CCREnable_CalibrationFactorId)
                    saveNotShow = (pvd4ConfigData.Gas4CCREnable_HasShutOffValve = False And pvd4ConfigData.Gas4CCREnable_HasSupplyValve = False)
                    result = Not saveNotShow
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
            Dim pvd4ConfigData As PVD4ConfigurationData = CType(baseConfigData, PVD4ConfigurationData)

            Select Case groupCode
                Case HConstants.RFTargetPower
                    If pvd4ConfigData.Target_Power_Supply_RF_Installed = False OrElse pvd4ConfigData.Target_Power_Supply_DC_Installed = True Then
                        groupShowInUI = IIf(pvd4ConfigData.Target_Power_Supply_RF_Installed = False, _
                                            pvd4ConfigData.Target_Power_Supply_RF_Installed.ToString(), _
                                            (Not pvd4ConfigData.Target_Power_Supply_RF_Installed).ToString())
                        groupSaveButNotShow = Not pvd4ConfigData.Target_Power_Supply_RF_Installed
                    End If

                Case HConstants.DCTargetPower
                    If pvd4ConfigData.Target_Power_Supply_DC_Installed = False AndAlso pvd4ConfigData.Target_Power_Supply_RF_Installed = True Then
                        groupShowInUI = pvd4ConfigData.Target_Power_Supply_DC_Installed.ToString()
                        groupSaveButNotShow = Not pvd4ConfigData.Target_Power_Supply_DC_Installed
                    End If

                Case HConstants.FilMetricControl
                    If pvd4ConfigData.FilMetricDevice_Installed = False Then
                        groupShowInUI = False
                        groupSaveButNotShow = True
                    End If
                Case HConstants.CCRSourcePower_Group
                    If Not (pvd4ConfigData.CCR_Source_Matchbox_Unit_RF_Installed AndAlso pvd4ConfigData.Bias_Power_Supply_Installed) Then
                        groupShowInUI = pvd4ConfigData.CCR_Source_Matchbox_Unit_RF_Installed
                        groupSaveButNotShow = Not pvd4ConfigData.CCR_Source_Matchbox_Unit_RF_Installed
                    End If
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

            Dim pvd4ConfigData As PVD4ConfigurationData = CType(baseConfigData, PVD4ConfigurationData)

            Select Case groupCode
                Case HConstants.DCTargetPower
                    If Not pvd4ConfigData.IsPulseDCTargetPowerSupply(pvd4ConfigData.Target_Power_Supply_DC_Installed_WhichModel) Then
                        If (parameterName = HConstants.TargetPulseFrequency OrElse parameterName = HConstants.TargetPulseWidth) Then
                            saveNotShow = True
                            result = False
                            Exit Try
                        End If
                    End If

                Case HConstants.Gasses
                    If pvd4ConfigData.Injection_Valve_Installed Then
                        If (parameterName = HConstants.UseGasDistribution OrElse parameterName = HConstants.UseSecondaryGasOnly) OrElse _
                       (pvd4ConfigData.SupportMainSecondDistributionValves = False AndAlso (parameterName = HConstants.UseMainDist Or parameterName = HConstants.UseSeconDist)) Then
                            saveNotShow = True
                            result = False
                            Exit Try
                        End If
                    Else
                        If (parameterName = HConstants.UseMainDist OrElse parameterName = HConstants.UseSeconDist) Then
                            saveNotShow = True
                            result = False
                            Exit Try
                        End If
                    End If
                   
                Case HConstants.CCRSourcePower_Group
                    'check for CCR not installed -> hide all CCR Param
                    If (Not pvd4ConfigData.CCR_Source_Matchbox_Unit_RF_Installed) Then
                        If (parameterName = HConstants.CCRPower OrElse parameterName = HConstants.CCRMotor1 OrElse parameterName = HConstants.CCRMotor2 OrElse parameterName = HConstants.CCRMotor3 _
                        OrElse parameterName = HConstants.CCRGas1 OrElse parameterName = HConstants.CCRGas2 OrElse parameterName = HConstants.CCRGas3 OrElse parameterName = HConstants.CCRGas4 _
                        OrElse parameterName = HConstants.CCRSourceMode OrElse parameterName = HConstants.CCRShutterOpen) Then
                            saveNotShow = True
                            result = False
                            Exit Try
                        End If
                    Else
                        If pvd4ConfigData.Gas1CCREnable_HasShutOffValve = False And pvd4ConfigData.Gas1CCREnable_HasSupplyValve = False And parameterName = HConstants.CCRGas1 Then
                            saveNotShow = True
                            result = False
                            Exit Try
                        ElseIf pvd4ConfigData.Gas2CCREnable_HasShutOffValve = False And pvd4ConfigData.Gas2CCREnable_HasSupplyValve = False And parameterName = HConstants.CCRGas2 Then
                            saveNotShow = True
                            result = False
                            Exit Try
                        ElseIf pvd4ConfigData.Gas3CCREnable_HasShutOffValve = False And pvd4ConfigData.Gas3CCREnable_HasSupplyValve = False And parameterName = HConstants.CCRGas3 Then
                            saveNotShow = True
                            result = False
                            Exit Try
                        ElseIf pvd4ConfigData.Gas4CCREnable_HasShutOffValve = False And pvd4ConfigData.Gas4CCREnable_HasSupplyValve = False And parameterName = HConstants.CCRGas4 Then
                            saveNotShow = True
                            result = False
                            Exit Try
                        End If
                    End If
            End Select

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

            Dim pmConfigData As PVD4ConfigurationData = CType(baseConfigData, PVD4ConfigurationData)

            If (GroupCode = HConstants.RFTargetPower OrElse GroupCode = HConstants.DCTargetPower) And (parameterName = HConstants.TargetSelection) Then
                If (Not pmConfigData.Target1_Installed) AndAlso (Not pmConfigData.Target2_Installed) AndAlso _
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