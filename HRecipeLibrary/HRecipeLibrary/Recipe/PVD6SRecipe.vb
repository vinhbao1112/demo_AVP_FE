Public Class PVD6SRecipe
    Inherits GeneralRecipe

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2021-01-13 </date>
    ''' </author>
    ''' <summary>
    ''' Change description of recipe base on configuration data of PVD6S
    ''' </summary>
    Protected Overrides Function ChangeDescription(ByVal groupCode As String, ByVal parameterName As String, ByRef parameterDescription As String, ByRef saveNotShow As Boolean, ByVal baseConfigData As BaseConfigurationData) As Boolean
        Dim result As Boolean = True

        Try
            If baseConfigData Is Nothing Then
                result = False
                Exit Try
            End If

            Dim pvd6sConfigData As PVD6SConfigurationData = CType(baseConfigData, PVD6SConfigurationData)

            Select Case parameterName
                Case HConstants.TargetSelection
                    If pvd6sConfigData.NumberOfTarget = "4" Then
                        parameterDescription = "Target Selection (1-4)"
                    End If
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
    ''' check to visible/invisible parameter in recipe
    ''' </summary>
    Protected Overrides Function CheckingParameter(ByVal groupCode As String, ByVal parameterName As String, ByRef saveNotShow As Boolean, ByVal baseConfigData As BaseConfigurationData) As Boolean
        Dim result As Boolean = True

        Try
            If baseConfigData Is Nothing Then
                result = False
                Exit Try
            End If

            Dim pvd6sConfigData As PVD6SConfigurationData = CType(baseConfigData, PVD6SConfigurationData)

            'Check DC is installed?                
            Select Case groupCode
                Case HConstants.TargetControl
                    If pvd6sConfigData.Target_Power_Supply_DC_Installed = False Then
                        If parameterName = HConstants.TargetPulseMode OrElse parameterName = HConstants.TargetPulseFrequency OrElse parameterName = HConstants.TargetPulseWidth Then
                            saveNotShow = True
                            result = False
                            Exit Try
                        End If
                    Else
                        If Not pvd6sConfigData.IsPulseDCTargetPowerSupply(pvd6sConfigData.Target_Power_Supply_DC_Installed_WhichModel) Then
                            'check Ps Model to set Pulse Mode
                            If parameterName = HConstants.TargetPulseMode OrElse parameterName = HConstants.TargetPulseFrequency OrElse parameterName = HConstants.TargetPulseWidth Then
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


    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-06-23 </date>
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

            Dim PVD6SConfigData As PVD6SConfigurationData = CType(baseConfigData, PVD6SConfigurationData)

            If GroupCode = HConstants.TargetControl AndAlso parameterName = HConstants.TargetSelection Then
                If (name = HConstants.Number1 And (Not PVD6SConfigData.Target1_Installed)) Or _
                   (name = HConstants.Number2 And (Not PVD6SConfigData.Target2_Installed)) Or _
                   (name = HConstants.Number3 And (Not PVD6SConfigData.Target3_Installed)) Or _
                   (name = HConstants.Number4 And (Not PVD6SConfigData.Target4_Installed)) Or _
                   (name = HConstants.Number5 And (Not PVD6SConfigData.Target5_Installed)) Or _
                   (name = HConstants.Number6 And (Not PVD6SConfigData.Target6_Installed)) Then
                    value = String.Empty

                Else
                    If name = HConstants.Number0 Then
                        name = name & " (Don't move)"
                    ElseIf name = HConstants.T1 Then
                        If (PVD6SConfigData.Target_Material <> String.Empty) Then
                            name = name & " (" & PVD6SConfigData.Target_Material & ")"
                        End If
                    ElseIf name = HConstants.T2 Then
                        If (PVD6SConfigData.Target_Material1 <> String.Empty) Then
                            name = name & " (" & PVD6SConfigData.Target_Material1 & ")"
                        End If
                    ElseIf name = HConstants.T3 Then
                        If (PVD6SConfigData.Target_Material2 <> String.Empty) Then
                            name = name & " (" & PVD6SConfigData.Target_Material2 & ")"
                        End If
                    ElseIf name = HConstants.T4 Then
                        If (PVD6SConfigData.Target_Material3 <> String.Empty) Then
                            name = name & " (" & PVD6SConfigData.Target_Material3 & ")"
                        End If
                    ElseIf name = HConstants.T5 Then
                        If (PVD6SConfigData.Target_Material4 <> String.Empty) Then
                            name = name & " (" & PVD6SConfigData.Target_Material4 & ")"
                        End If
                    ElseIf name = HConstants.T6 Then
                        If (PVD6SConfigData.Target_Material5 <> String.Empty) Then
                            name = name & " (" & PVD6SConfigData.Target_Material5 & ")"
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
