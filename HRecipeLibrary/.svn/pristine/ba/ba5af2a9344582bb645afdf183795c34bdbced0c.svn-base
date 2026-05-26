Public Class RIERecipe
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

            Dim pmConfigData As RIEConfigurationData = CType(baseConfigData, RIEConfigurationData)

            Select Case groupCode
                Case HConstants.GroupBackSide
                    If Not pmConfigData.BacksideHEViaMFC Then
                        If parameterName = HConstants.Backside Then
                            saveNotShow = True
                            result = False
                            Exit Try
                        End If
                    Else
                        If parameterName = HConstants.BackSidePressure Then
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
End Class
