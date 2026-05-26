Public Class HRPVDRecipe
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
            Dim hrpvdConfigData As HRPVDConfigurationData = CType(baseConfigData, HRPVDConfigurationData)

            Select Case groupCode
                Case HConstants.VatControl
                    groupShowInUI = hrpvdConfigData.Vat_Valve_Installed.ToString()
                    groupSaveButNotShow = Not hrpvdConfigData.Vat_Valve_Installed

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

            Dim hrpvdConfigData As HRPVDConfigurationData = CType(baseConfigData, HRPVDConfigurationData)

            'Check Target RF, DC is installed?
            If Not hrpvdConfigData.Target_Power_Supply_DC_Installed Then
                If parameterName = HConstants.TargetDCPower Then
                    saveNotShow = True
                    result = False
                    Exit Try
                End If
            End If

            If Not hrpvdConfigData.Target_Power_Supply_RF_Installed Then
                If parameterName = HConstants.TargetRFPower Then
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
End Class
