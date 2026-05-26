Public Class IBERecipe
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

            Dim ibeConfigData As IBEConfigurationData = CType(baseConfigData, IBEConfigurationData)

            Select Case parameterName
                Case HConstants.PbnFlowrate
                    parameterDescription = String.Format(parameterDescription, ibeConfigData.PBNGas_Installed_CalibrationFactorId)
                    saveNotShow = (ibeConfigData.PBNGas_Installed_Name = String.Empty)
                    result = Not saveNotShow

                Case HConstants.FlowcoolFlowrate
                    parameterDescription = String.Format(parameterDescription, ibeConfigData.FlowCool_Installed_CalibrationFactorId)
                    saveNotShow = (ibeConfigData.FlowCool_Installed_Name = String.Empty)
                    result = Not saveNotShow

                Case HConstants.KFactor
                    If ibeConfigData.ANC_Installed Then
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

            Dim ibeConfigData As IBEConfigurationData = CType(baseConfigData, IBEConfigurationData)

            If Not ibeConfigData.Cryo_Installed AndAlso parameterName = HConstants.OpenCryoGate Then
                saveNotShow = True
                result = False
                Exit Try
            End If

            If Not ibeConfigData.DiverterGasValveInstalled AndAlso parameterName = HConstants.RIBE Then
                saveNotShow = True
                result = False
                Exit Try
            End If

            If Not ibeConfigData.SupportTiltSweepMode Then
                If parameterName = HConstants.Fixture_Tilt Or parameterName = HConstants.Tilt_Sweep_Start_Angle Or _
                   parameterName = HConstants.Tilt_Sweep_End_Angle Or parameterName = HConstants.Tilt_Sweep_Dwell_Time Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If
            End If

            If ibeConfigData.BackTilt_Installed AndAlso False = ibeConfigData.Shutter_Installed Then
                If parameterName = HConstants.UseElectroStaticShutter Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If
            End If

            If False = ibeConfigData.Shutter_Installed Then
                If parameterName = HConstants.OpenEtchShutterAtStart Or parameterName = HConstants.OpenEtchShutterAtBeam Or _
                                                                        parameterName = HConstants.CloseEtchShutterAtEnd Then
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
            Dim ibeConfigData As IBEConfigurationData = CType(baseConfigData, IBEConfigurationData)

            Select Case groupCode
                Case HConstants.TiltSweep
                    groupShowInUI = ibeConfigData.SupportTiltSweepMode.ToString()
                    groupSaveButNotShow = Not ibeConfigData.SupportTiltSweepMode

            End Select
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try

        Return groupShowInUI
    End Function

End Class
