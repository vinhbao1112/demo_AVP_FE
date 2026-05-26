Public Class PVD6PRecipe
    Inherits GeneralRecipe

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

            Dim pvd6pConfigData As PVD6PConfigurationData = CType(baseConfigData, PVD6PConfigurationData)

            'Check DC is installed?                
            Select Case groupCode
                Case HConstants.Target1_Target2
                    If pvd6pConfigData.Target_Power_Supply1_DC_Installed = False Then
                        If parameterName = HConstants.TargetPulseFrequency OrElse parameterName = HConstants.TargetPulseWidth Then
                            saveNotShow = True
                            result = False
                            Exit Try
                        End If
                    Else
                        If Not pvd6pConfigData.IsPulseDCTargetPowerSupply(pvd6pConfigData.Target_Power_Supply1_DC_Installed_WhichModel) Then
                            'check Ps Model to set Pulse Mode
                            If parameterName = HConstants.TargetPulseFrequency OrElse parameterName = HConstants.TargetPulseWidth Then
                                saveNotShow = True
                                result = False
                                Exit Try
                            End If
                        End If
                    End If

                Case HConstants.Target3_Target4
                    If pvd6pConfigData.Target_Power_Supply2_DC_Installed = False Then
                        If parameterName = HConstants.TargetPulseFrequency OrElse parameterName = HConstants.TargetPulseWidth Then
                            saveNotShow = True
                            result = False
                            Exit Try
                        End If
                    Else
                        If Not pvd6pConfigData.IsPulseDCTargetPowerSupply(pvd6pConfigData.Target_Power_Supply2_DC_Installed_WhichModel) Then
                            'check Ps Model to set Pulse Mode
                            If parameterName = HConstants.TargetPulseFrequency OrElse parameterName = HConstants.TargetPulseWidth Then
                                saveNotShow = True
                                result = False
                                Exit Try
                            End If
                        End If
                    End If

                Case HConstants.Target5_Target6
                    If pvd6pConfigData.Target_Power_Supply3_DC_Installed = False Then
                        If parameterName = HConstants.TargetPulseFrequency OrElse parameterName = HConstants.TargetPulseWidth Then
                            saveNotShow = True
                            result = False
                            Exit Try
                        End If
                    Else
                        If Not pvd6pConfigData.IsPulseDCTargetPowerSupply(pvd6pConfigData.Target_Power_Supply3_DC_Installed_WhichModel) Then
                            'check Ps Model to set Pulse Mode
                            If parameterName = HConstants.TargetPulseFrequency OrElse parameterName = HConstants.TargetPulseWidth Then
                                saveNotShow = True
                                result = False
                                Exit Try
                            End If
                        End If
                    End If
            End Select

        Catch ex As Exception
            Logger.Error(ex.ToString())
            result = False
        End Try

        Return result
    End Function
End Class
