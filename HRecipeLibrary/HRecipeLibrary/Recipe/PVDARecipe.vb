Public Class PVDARecipe
    Inherits GeneralRecipe

    ''' <author>
    '''    	<name> Nguyen Dinh Minh Thi </name>
    '''    	<date> 2016-10-31 </date>
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

            Dim PVDAConfigData As PVDAConfigurationData = CType(baseConfigData, PVDAConfigurationData)

            'DC/RF Power Supply
            If PVDAConfigData.Target_Power_Supply_DC_Installed Then
                If Not PVDAConfigData.IsPulseDCTargetPowerSupply(PVDAConfigData.Target_Power_Supply_DC_Installed_WhichModel) Then
                    'check Ps Model to set Pulse Mode
                    If (parameterName = HConstants.Pulse OrElse parameterName = HConstants.PulseFrequency OrElse parameterName = HConstants.PulseWidth) Then
                        saveNotShow = True
                        result = False
                        Exit Try
                    End If
                End If

                'hide RF Param
                If (parameterName = HConstants.TargetC1 OrElse parameterName = HConstants.TargetC2) Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

            ElseIf PVDAConfigData.Target_Power_Supply_RF_Installed Then 'this is RF Chamber -> hide DC param
                If (parameterName = HConstants.Pulse OrElse parameterName = HConstants.PulseFrequency OrElse parameterName = HConstants.PulseWidth) Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                'remove param that is belong to RF/DC but sometime it is invisible
            ElseIf (Not PVDAConfigData.Target_Power_Supply_DC_Installed) AndAlso (Not PVDAConfigData.Target_Power_Supply_RF_Installed) Then
                If (parameterName = HConstants.TargetC1 OrElse parameterName = HConstants.TargetC2) OrElse _
                   (parameterName = HConstants.Pulse OrElse parameterName = HConstants.PulseFrequency OrElse parameterName = HConstants.PulseWidth) OrElse _
                   (parameterName = HConstants.RampTime) OrElse parameterName = HConstants.TargetPower Then

                    'this is Etch Chamber -> so hide those RF, DC param
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

            End If

            'check for Bias not installed -> hide all Bias Param
            If (Not PVDAConfigData.Bias_Power_Supply_Installed) AndAlso _
               (parameterName = HConstants.BiasPower OrElse parameterName = HConstants.BiasVoltage OrElse parameterName = HConstants.BiasC1 OrElse _
                parameterName = HConstants.BiasC2 OrElse parameterName = HConstants.BiasControl) Then

                saveNotShow = True
                result = False
                Exit Try

            ElseIf (Not PVDAConfigData.Shutter_Installed) AndAlso parameterName = HConstants.OpenShutter Then
                saveNotShow = True
                result = False
                Exit Try

            ElseIf PVDAConfigData.Parallel_Magnet_Installed = False AndAlso _
                  (parameterName = HConstants.MagnetState OrElse parameterName = HConstants.MagCurrent OrElse _
                   parameterName = HConstants.MagFrequency OrElse parameterName = HConstants.MagnetDutyCycle) Then

                saveNotShow = True
                result = False
                Exit Try
            ElseIf (Not PVDAConfigData.Phase_Shifter_Angle_Installed) AndAlso (parameterName = HConstants.PhaseShifterAngle OrElse parameterName = HConstants.PhaseTargetAngle) Then
                saveNotShow = True
                result = False
                Exit Try
            ElseIf PVDAConfigData.Phase_Shifter_Angle_Installed AndAlso PVDAConfigData.Phase_Shifter_Angle_Installed_WhichModel = HConstants.Phase_Shifter_Only AndAlso parameterName = HConstants.PhaseTargetAngle Then
                saveNotShow = True
                result = False
                Exit Try
            ElseIf PVDAConfigData.RGA_Gas_Installed = False AndAlso parameterName = HConstants.UseRGASystem Then
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
