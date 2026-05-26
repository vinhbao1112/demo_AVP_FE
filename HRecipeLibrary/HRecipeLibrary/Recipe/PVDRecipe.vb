Public Class PVDRecipe
    Inherits GeneralRecipe

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Change description of recipe base on configuration data of PVD
    ''' </summary>
    Protected Overrides Function ChangeDescription(ByVal groupCode As String, ByVal parameterName As String, ByRef parameterDescription As String, ByRef saveNotShow As Boolean, ByVal baseConfigData As BaseConfigurationData) As Boolean
        Dim result As Boolean = True

        Try
            If baseConfigData Is Nothing Then
                result = False
                Exit Try
            End If

            result = MyBase.ChangeDescription(groupCode, parameterName, parameterDescription, saveNotShow, baseConfigData)

            Dim pvdConfigData As PVDConfigurationData = CType(baseConfigData, PVDConfigurationData)
            Dim isBacksideGas As Boolean = (pvdConfigData.FlowCool_Installed AndAlso pvdConfigData.FlowCool_Installed_BackSideFlowCoolHe = parameterName)

            Select Case parameterName
                Case HConstants.Gas1
                    If isBacksideGas Then
                        parameterDescription = parameterDescription.Replace(HConstants.DescriptionGas1, HConstants.Backside)
                    End If

                Case HConstants.Gas2
                    If isBacksideGas Then
                        parameterDescription = parameterDescription.Replace(HConstants.DescriptionGas2, HConstants.Backside)
                    End If

                Case HConstants.Gas3
                    If isBacksideGas Then
                        parameterDescription = parameterDescription.Replace(HConstants.DescriptionGas3, HConstants.Backside)
                    End If

                Case HConstants.Gas4
                    If isBacksideGas Then
                        parameterDescription = parameterDescription.Replace(HConstants.DescriptionGas4, HConstants.Backside)
                    End If

                Case HConstants.Gas5
                    If isBacksideGas Then
                        parameterDescription = parameterDescription.Replace(HConstants.DescriptionGas5, HConstants.Backside)
                    End If

                Case HConstants.ChuckHeight
                    If pvdConfigData.Chuck_Position_TSD_Ref Then
                        parameterDescription = HConstants.ChuckHeightDescription
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

            Dim pvdConfigData As PVDConfigurationData = CType(baseConfigData, PVDConfigurationData)

            'DC/RF Power Supply
            If pvdConfigData.Target_Power_Supply_DC_Installed Then
                If Not pvdConfigData.IsPulseDCTargetPowerSupply(pvdConfigData.Target_Power_Supply_DC_Installed_WhichModel) Then
                    'check Ps Model to set Pulse Mode
                    If (parameterName = HConstants.Pulse OrElse parameterName = HConstants.PulseFrequency OrElse parameterName = HConstants.PulseWidth) Then
                        saveNotShow = True
                        result = False
                        Exit Try
                    End If
                End If

                'hide RF Param
                If (parameterName = HConstants.TargetC1 OrElse parameterName = HConstants.TargetC2 OrElse parameterName = HConstants.TargetMatchingMode) Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

            ElseIf pvdConfigData.Target_Power_Supply_RF_Installed Then 'this is RF Chamber -> hide DC param
                If (parameterName = HConstants.Pulse OrElse parameterName = HConstants.PulseFrequency OrElse parameterName = HConstants.PulseWidth) Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                'remove param that is belong to RF/DC but sometime it is invisible
            ElseIf (Not pvdConfigData.Target_Power_Supply_DC_Installed) AndAlso (Not pvdConfigData.Target_Power_Supply_RF_Installed) Then
                If (parameterName = HConstants.TargetC1 OrElse parameterName = HConstants.TargetC2 OrElse parameterName = HConstants.TargetMatchingMode) OrElse _
                   (parameterName = HConstants.Pulse OrElse parameterName = HConstants.PulseFrequency OrElse parameterName = HConstants.PulseWidth) OrElse _
                   (parameterName = HConstants.RampTime) OrElse parameterName = HConstants.TargetPower Then

                    'this is Etch Chamber -> so hide those RF, DC param
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

            End If

            'check for Bias not installed -> hide all Bias Param
            If (Not pvdConfigData.Bias_Power_Supply_Installed) AndAlso _
               (parameterName = HConstants.BiasPower OrElse parameterName = HConstants.BiasVoltage OrElse parameterName = HConstants.BiasC1 OrElse _
                parameterName = HConstants.BiasC2 OrElse parameterName = HConstants.BiasMatchingMode OrElse parameterName = HConstants.BiasC1C2FromRecipe OrElse _
                parameterName = HConstants.BiasControl) Then

                saveNotShow = True
                result = False
                Exit Try

            ElseIf (Not pvdConfigData.Shutter_Installed) AndAlso parameterName = HConstants.OpenShutter Then
                saveNotShow = True
                result = False
                Exit Try

            ElseIf pvdConfigData.Parallel_Magnet_Installed = False AndAlso _
                  (parameterName = HConstants.MagnetState OrElse parameterName = HConstants.MagCurrent OrElse _
                   parameterName = HConstants.MagFrequency OrElse parameterName = HConstants.MagnetDutyCycle) Then

                saveNotShow = True
                result = False
                Exit Try

            ElseIf (Not pvdConfigData.Heater_Installed) AndAlso _
                   (parameterName = HConstants.HeaterState OrElse parameterName = HConstants.HeaterZone1 OrElse _
                    parameterName = HConstants.HeaterZone2 OrElse parameterName = HConstants.HeaterOffAtStepEnd) Then

                saveNotShow = True
                result = False
                Exit Try


            ElseIf (Not pvdConfigData.Chiller_Installed) AndAlso parameterName = HConstants.ChillerTemperature Then
                saveNotShow = True
                result = False
                Exit Try

            End If

        Catch ex As Exception
            Logger.Error(ex.ToString())
            result = False
        End Try

        Return result
    End Function
End Class
