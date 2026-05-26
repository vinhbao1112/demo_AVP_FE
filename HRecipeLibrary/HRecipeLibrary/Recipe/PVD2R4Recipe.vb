Public Class PVD2R4Recipe
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

            Dim pvd2r4ConfigData As PVD2R4ConfigurationData = CType(baseConfigData, PVD2R4ConfigurationData)

            If (Not pvd2r4ConfigData.Target_Power_Supply_DC_Installed) AndAlso pvd2r4ConfigData.Target_Power_Supply_RF_Installed Then
                If (parameterName = HConstants.TargetPulseFrequency OrElse parameterName = HConstants.TargetPulseWidth OrElse parameterName = HConstants.TargetMagnatronSpeed) Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If
            Else
                If (parameterName = HConstants.TargetMatchMode OrElse parameterName = HConstants.TargetMatchC1 OrElse parameterName = HConstants.TargetMatchC2) Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If

                If Not pvd2r4ConfigData.IsPulseDCTargetPowerSupply(pvd2r4ConfigData.Target_Power_Supply_DC_Installed_WhichModel) Then
                    If (parameterName = HConstants.TargetPulseFrequency OrElse parameterName = HConstants.TargetPulseWidth) Then
                        saveNotShow = True
                        result = False
                        Exit Try
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
