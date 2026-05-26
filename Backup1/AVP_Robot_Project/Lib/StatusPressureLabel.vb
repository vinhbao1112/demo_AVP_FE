Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Public Class StatusPressureLabel
    Inherits StatusLabel

    Public Sub New(ByVal lblManagedLabel As Label)
        MyBase.New(lblManagedLabel)
    End Sub

    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        Dim ll As AVPLib.DataManagerment.LoadLock = Nothing
        If (Me.Parent.Name.IndexOf("lccLoadLockA") > -1) Or (Me.Parent.Name.IndexOf("lpcLoadLockA") > -1) Then
            ll = EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
            'CG_COMM = OFF
            If (ll.CG_Communication = Equipment.WorkingStatuses.Off) Then
                If (AVPLib.RobotConfigurationValues.LLA_HIVAC_INSTALLED) Then
                    If ((ll.IG_Communication = Equipment.WorkingStatuses.Off) OrElse _
                    (ll.IGStatus = Equipment.WorkingStatuses.Off)) Then
                        Value = "Error"
                    Else
                        Value = Utils.ConvertValue(CASSETTESPANEL_STR & "." & "IGCGLL", ll.IG.ToString())
                    End If
                Else
                    Value = "Error"
                End If
            Else 'CG_COMM = ON
                If (AVPLib.RobotConfigurationValues.LLA_HIVAC_INSTALLED) Then
                    'IG ON
                    If (ll.IG_Communication = Equipment.WorkingStatuses.On) Then
                        If (ll.IGStatus = Equipment.WorkingStatuses.On) Then
                            Value = Utils.ConvertValue(CASSETTESPANEL_STR & "." & "IGCGLL", ll.IG.ToString())
                        Else
                            Value = Utils.ConvertValue(CASSETTESPANEL_STR & "." & "IGCGLL", ll.CG.ToString())
                        End If
                    Else 'IG OFF
                        Value = Utils.ConvertValue(CASSETTESPANEL_STR & "." & "IGCGLL", ll.CG.ToString())
                    End If
                Else
                    Value = Utils.ConvertValue(CASSETTESPANEL_STR & "." & "IGCGLL", ll.CG.ToString())
                End If
            End If
            If ll.IG_Communication = Equipment.WorkingStatuses.Off Then
                ContainerForm.CassettesPanel.LLACGGaugesFrm.btnTurnIGOn.Status = SL_CustomButton.DisplayStatus.Off
            End If
        Else
            If IsNumeric(Value) Then
                Value = Format(Double.Parse(Value), AVPLib.ConstEnum.SCIENTIFIC_FORMAT_DECIMAL)
            End If
        End If
        MyBase.ChangeStatus(Identification, Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub

End Class
