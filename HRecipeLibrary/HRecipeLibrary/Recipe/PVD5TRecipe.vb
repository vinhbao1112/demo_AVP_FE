Public Class PVD5TRecipe
    Inherits PVD4Recipe

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2025-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' check to visible/invisible group parameter in recipe
    ''' </summary>
    Protected Overrides Function CheckingGroupShowInUI(ByVal groupCode As String, ByRef groupSaveButNotShow As Boolean, ByVal value As String, ByVal baseConfigData As BaseConfigurationData) As String
        Dim groupShowInUI As String = value

        Try
            Dim pvd5TConfigData As PVD5TConfigurationData = CType(baseConfigData, PVD5TConfigurationData)

            Select Case groupCode
                Case HConstants.RFTargetPower
                    If pvd5TConfigData.Target_Power_Supply_RF_Installed = False Then
                        groupShowInUI = pvd5TConfigData.Target_Power_Supply_RF_Installed.ToString()
                        groupSaveButNotShow = Not pvd5TConfigData.Target_Power_Supply_RF_Installed
                    End If

                Case HConstants.DCTargetPower
                    If pvd5TConfigData.Target_Power_Supply_DC_Installed = False Then
                        groupShowInUI = pvd5TConfigData.Target_Power_Supply_DC_Installed.ToString()
                        groupSaveButNotShow = Not pvd5TConfigData.Target_Power_Supply_DC_Installed
                    End If

                Case HConstants.FilMetricControl
                    If pvd5TConfigData.FilMetricDevice_Installed = False Then
                        groupShowInUI = False
                        groupSaveButNotShow = True
                    End If
                Case HConstants.CCRSourcePower_Group
                    If Not (pvd5TConfigData.CCR_Source_Matchbox_Unit_RF_Installed AndAlso pvd5TConfigData.Bias_Power_Supply_Installed) Then
                        groupShowInUI = pvd5TConfigData.CCR_Source_Matchbox_Unit_RF_Installed
                        groupSaveButNotShow = Not pvd5TConfigData.CCR_Source_Matchbox_Unit_RF_Installed
                    End If
            End Select
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try

        Return groupShowInUI
    End Function
End Class