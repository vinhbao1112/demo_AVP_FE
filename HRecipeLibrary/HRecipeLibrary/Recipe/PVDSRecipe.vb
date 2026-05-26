Public Class PVDSRecipe
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

            Dim pvdsConfigData As PVDSConfigurationData = CType(baseConfigData, PVDSConfigurationData)

            Select Case parameterName
                Case HConstants.PbnFlowrate
                    parameterDescription = String.Format(parameterDescription, pvdsConfigData.PBNGas_Installed_CalibrationFactorId)
                    saveNotShow = (pvdsConfigData.PBNGas_Installed_Name = String.Empty)
                    result = Not saveNotShow

                Case HConstants.FlowcoolFlowrate
                    parameterDescription = String.Format(parameterDescription, pvdsConfigData.FlowCool_Installed_CalibrationFactorId)
                    saveNotShow = (pvdsConfigData.FlowCool_Installed_CalibrationFactorId = String.Empty)
                    result = Not saveNotShow

                Case HConstants.KFactor
                    If pvdsConfigData.ANC_Installed Then
                        parameterDescription = HConstants.KFactorDescription
                    End If
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
    ''' check to visible/invisible parameter in recipe
    ''' </summary>
    Protected Overrides Function CheckingParameter(ByVal groupCode As String, ByVal parameterName As String, ByRef saveNotShow As Boolean, ByVal baseConfigData As BaseConfigurationData) As Boolean
        Dim result As Boolean = True

        Try
            If baseConfigData Is Nothing Then
                result = False
                Exit Try
            End If

            Dim pvdsConfigData As PVDSConfigurationData = CType(baseConfigData, PVDSConfigurationData)

            If Not pvdsConfigData.Cryo_Installed AndAlso parameterName = HConstants.OpenCryoGate Then
                saveNotShow = True
                result = False
                Exit Try
            End If

            If Not pvdsConfigData.DiverterGasValveInstalled AndAlso parameterName = HConstants.RIBE Then
                saveNotShow = True
                result = False
                Exit Try
            End If

            If Not pvdsConfigData.SupportTiltSweepMode Then
                If parameterName = HConstants.Fixture_Tilt Or parameterName = HConstants.Tilt_Sweep_Start_Angle Or
                   parameterName = HConstants.Tilt_Sweep_End_Angle Or parameterName = HConstants.Tilt_Sweep_Dwell_Time Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If
            End If

            If pvdsConfigData.BackTilt_Installed AndAlso False = pvdsConfigData.Shutter_Installed Then
                If parameterName = HConstants.UseElectroStaticShutter Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If
            End If

            If False = pvdsConfigData.Shutter_Installed Then
                If parameterName = HConstants.OpenEtchShutterAtStart Or parameterName = HConstants.OpenEtchShutterAtBeam Or
                                                                        parameterName = HConstants.CloseEtchShutterAtEnd Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If
            End If

            If Not pvdsConfigData.Target_Shutter_Installed Then
                If parameterName = HConstants.Open_Target_Shutter_At_Start _
                OrElse parameterName = HConstants.Open_Target_Shutter_At_Beam _
                OrElse parameterName = HConstants.Close_Target_Shutter_At_End Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If
            End If

            If Not pvdsConfigData.Fixture_Shutter Then
                If parameterName = HConstants.Open_Fixture_Shutter_At_Start _
                OrElse parameterName = HConstants.Open_Fixture_Shutter_At_Beam _
                OrElse parameterName = HConstants.Close_Fixture_Shutter_At_End Then
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
    '''    	<name> Dua Tran </name>
    '''    	<date> 2019-04-10 </date>
    ''' </author>
    ''' <summary>
    ''' CheckingGroupShowInUI
    ''' </summary>
    Protected Overrides Function CheckingGroupShowInUI(ByVal groupCode As String, ByRef groupSaveButNotShow As Boolean, ByVal value As String, ByVal baseConfigData As BaseConfigurationData) As String
        Dim groupShowInUI As String = value

        Try
            Dim pvdsConfigData As PVDSConfigurationData = CType(baseConfigData, PVDSConfigurationData)

            Select Case groupCode
                Case HConstants.TiltSweep
                    groupShowInUI = pvdsConfigData.SupportTiltSweepMode.ToString()
                    groupSaveButNotShow = Not pvdsConfigData.SupportTiltSweepMode

                Case HConstants.RFTargetPower
                    If pvdsConfigData.Target_Power_Supply_RF_Installed = False Then
                        groupShowInUI = IIf(pvdsConfigData.Target_Power_Supply_RF_Installed = False,
                                            pvdsConfigData.Target_Power_Supply_RF_Installed.ToString(),
                                            (Not pvdsConfigData.Target_Power_Supply_RF_Installed).ToString())
                        groupSaveButNotShow = Not pvdsConfigData.Target_Power_Supply_RF_Installed
                    End If

            End Select
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try

        Return groupShowInUI
    End Function

End Class
