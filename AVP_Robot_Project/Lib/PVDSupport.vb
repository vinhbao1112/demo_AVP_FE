Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPControls

Public Class PVDSupport
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2010-04-08 </date>
    ''' </author>
    ''' <summary>
    ''' Read Message Text
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Sub ReadMessageText(ByVal sender As Object, _
                                      ByVal objMasterPanel As Object, _
                                      ByRef strMessageText As String)
        strMessageText = String.Empty

        Dim button As ButtonIGCGControl = CType(sender, ButtonIGCGControl)
        Try
            If button.Name = "btnRegen" And (button.Status = DisplayStatus.Unknow) Then ''only for PVD
                strMessageText = AVPLib.ContainerData.GetMessageText(PVD + "." + button.Name + "." + STRING_CLOSE)
            ElseIf (button.Status = DisplayStatus.Unknow And button.Name = "btnHivacValve") Then
                strMessageText = AVPLib.ContainerData.GetMessageText(PVD + "." + button.Name + "." + "Unknown")
            ElseIf (button.Status = DisplayStatus.Unknow And button.Name = "btnShutter") Then
                strMessageText = AVPLib.ContainerData.GetMessageText(PVD + "." + button.Name + "." + "Unknown")
            ElseIf (button.Status = BinaryStatusControl.DisplayStatus.On) Or (button.Status = DisplayStatus.Unknow) Then
                strMessageText = AVPLib.ContainerData.GetMessageText(PVD + "." + button.Name + "." + STRING_OPEN)
            ElseIf (button.Status = BinaryStatusControl.DisplayStatus.Off) Then
                strMessageText = AVPLib.ContainerData.GetMessageText(PVD + "." + button.Name + "." + STRING_CLOSE)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' handles all button on PVD Panel
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Sub CommonButtonClick(ByVal strLogMessage As String, ByVal sender As Object, _
                            ByVal objMasterPanel As Object, ByVal stoStatusObject As StatusObject)

        AVPLib.Log.guiLogger.Info("Enter Button_Click")

        Dim strMessageText As String = String.Empty
        Dim strValue As String = String.Empty
        Dim button As ButtonIGCGControl = CType(sender, ButtonIGCGControl)
        Dim strChamberName As String = String.Empty

        Try
            ReadMessageText(sender, objMasterPanel, strMessageText)
            strChamberName = AVPLib.Utils.chamberID2ChamberName(CType(objMasterPanel, ChamberPanel).Name)

            If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Information) = DialogResult.OK Then
                Utils.LogUserEvent(strLogMessage, strChamberName)

                If button.Name = "btnRegen" And button.Status = DisplayStatus.Unknow Then ''special case
                    stoStatusObject.RequestStatus(button.Name, STR_ON)

                ElseIf button.Name = "btnHivacValve" And button.Status = DisplayStatus.Unknow Then
                    If Utils.ShowAVPMessageBox("Are you sure you want to Open Hivac Valve? ", strChamberName, MessageBoxIcon.Warning, MessageBoxButtons.YesNo) = DialogResult.OK Then
                        stoStatusObject.RequestStatus(button.Name, STR_OFF)

                    End If

                ElseIf button.Status = DisplayStatus.Off Then
                    stoStatusObject.RequestStatus(button.Name, STR_ON)

                Else
                    stoStatusObject.RequestStatus(button.Name, STR_OFF)

                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Button_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' handles all Textbox on PVD Panel
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Sub TextboxClick(ByVal sender As Object, ByVal e As System.EventArgs, _
                          ByVal objMasterPanel As Object, ByVal stoStatusObject As StatusObject)
        AVPLib.Log.guiLogger.Info("Enter TextboxClick")
        Try
            Dim TextBox As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)

            Dim Source As String = CType(objMasterPanel, ChamberPanel).Name & "." & PVD + "." + stoStatusObject.Name + "." + TextBox.Name
            Dim Min As Double = Double.Parse(AVPLib.ContainerData.GetRobotConfig(Source + STRING_MIN))
            Dim Max As Double = Double.Parse(AVPLib.ContainerData.GetRobotConfig(Source + STRING_MAX))
            Dim Title As String = AVPLib.ContainerData.GetMessageText(PVD + "." + TextBox.Name)
            Dim Value As String = TextBox.Text

            Dim frm As New NumPad()
            Dim InputRes As MsgBoxResult = Nothing
            If TextBox.Name = "txtPressure_Percent" Then
                frm = New NumPad(True)
                InputRes = frm.GetUserInput(Value, -1, -1, Min, Max, Title, 0, True, False)
            Else
                frm = New NumPad
                InputRes = frm.GetUserInput(Value, -1, -1, Min, Max, Title)
            End If

            If frm.IsMaxMinModified Then
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MIN, frm.NewMin)
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MAX, frm.NewMax)
                '#07/07/2011 
                '#-	AVP keypad.  All min/max will be read from PVD/IBE configuguration.  
                '# To name a few Recipe gas/chuckheigh/fixture tilt angle/PS min/max.   
                '# If any param that does not have min/max, we will have to add it's min/max.
                '#Begin fix: read min/max value in child node of "FromIBEConfig" or "FromPVDConfig"
                If TypeOf (TextBox) Is PVDTextbox Then
                    Dim tempTextBox As PVDTextbox = CType(sender, PVDTextbox)
                    If tempTextBox.UseBackGroundWorkerToUpdateMinMax Then
                        Utils.SynchronizeMinMaxValueToRecipeScreen(Source, frm.NewMin.ToString(), frm.NewMax.ToString())
                        tempTextBox.UpdateMinMaxValueToPM(Source, frm.NewMin, frm.NewMax)
                    End If
                End If
                '#End fix.

            End If

            If InputRes = MsgBoxResult.Ok Then
                TextBox.Text = Value

                'Not good as this
                Dim strTxtBoxName As String = String.Empty
                strTxtBoxName = Replace(TextBox.Name, "txt", "")
                strTxtBoxName = Replace(strTxtBoxName, "Right", "")
                Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(CType(objMasterPanel, ChamberPanel).Name)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "-" + TextBox.Parent.Text + "] " + "Set " + strTxtBoxName + " to Set Point " + Value)

                'do not send request status for preset
                If Not TextBox.Name = "txtPresetsRight" Then
                    stoStatusObject.RequestStatus(TextBox.Name, TextBox.Text)
                    '#04/29/2011 
                    '#AVP/PVD(DC ps).   Turn on magnatron when user enter a SP > 0.  Turn off magnatron when user enter SP = 0.
                    '#Begin fix:
                    If TextBox.Name = "txtTargetPowerRight" Then 'DC power supply
                        Dim chamberControl As Chamber1DCPVDPanel = CType(objMasterPanel, Chamber1DCPVDPanel)
                        Dim strValue As String = String.Empty
                        Dim dblTargetPower As Double = -1
                        Double.TryParse(TextBox.Text, dblTargetPower)
                        If dblTargetPower > 0 Then
                            strValue = STR_ON
                        ElseIf dblTargetPower = 0 Then
                            strValue = STR_OFF
                        End If
                        If Not String.IsNullOrEmpty(strValue) Then
                            stoStatusObject.RequestStatus(chamberControl.DCTargetPowerSupply.btnRotationStart.Name, strValue)
                        End If
                    End If
                    'End if
                End If
                Try
                    'change to scientific format
                    Dim strRetValue As String = TextBox.Text
                    If TextBox.Name = "txtCG2" Then
                        strRetValue = Format(Double.Parse(TextBox.Text), AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                    End If
                    TextBox.Text = strRetValue
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave TextboxClick")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' handles all Valve Click on PVD Panel
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Sub ValveClick(ByVal sender As Object, ByVal e As System.EventArgs, _
                          ByVal objMasterPanel As Object, ByVal stoStatusObject As StatusObject)
        AVPLib.Log.guiLogger.Info("Enter ValveControl_Click")
        Try
            Dim chamberPVDPanel As PVDPanel = CType(objMasterPanel, PVDPanel)
            Dim strMessageText As String = String.Empty
            Dim strValue As String = String.Empty
            Dim ValveControl As AVP_Robot_Project.ValveControl = CType(sender, AVP_Robot_Project.ValveControl)

            Dim Message As String = ValveControl.Name
            Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(CType(objMasterPanel, ChamberPanel).Name)
            If (ValveControl.Status = BinaryStatusControl.DisplayStatus.On) Then
                strMessageText = AVPLib.ContainerData.GetMessageText(PVD + "." + Message + "." + STRING_OPEN)
                strValue = BinaryStatusControl.DisplayStatus.Off.ToString(STRING_G)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Close Valve " + ValveControl.AccessibleName)
            ElseIf (ValveControl.Status = BinaryStatusControl.DisplayStatus.Off) Then
                strMessageText = AVPLib.ContainerData.GetMessageText(PVD + "." + Message + "." + STRING_CLOSE)
                strValue = BinaryStatusControl.DisplayStatus.On.ToString(STRING_G)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Open Valve " + ValveControl.AccessibleName)
            End If

            ''''''''''''''''''''''''''
            Dim strSpecialKey As String = String.Empty
            If Message.Contains("Supply") Then
                strSpecialKey = "Supply Valve"
            ElseIf Message.Contains("ShutOff") Then
                strSpecialKey = "ShutOff Valve"
            End If
            If strSpecialKey IsNot String.Empty Then
                Select Case CInt(Message.Substring(Message.Length - 1, 1))
                    Case 1
                        strMessageText = strMessageText.Replace(Message, chamberPVDPanel.GasLine1Name & " " & strSpecialKey)
                    Case 2
                        strMessageText = strMessageText.Replace(Message, chamberPVDPanel.GasLine2Name & " " & strSpecialKey)
                    Case 3
                        strMessageText = strMessageText.Replace(Message, chamberPVDPanel.GasLine3Name & " " & strSpecialKey)
                    Case 4
                        strMessageText = strMessageText.Replace(Message, chamberPVDPanel.GasLine4Name & " " & strSpecialKey)
                    Case 5
                        strMessageText = strMessageText.Replace(Message, chamberPVDPanel.GasLine5Name & " " & strSpecialKey)
                End Select
            End If
            If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Question) = DialogResult.OK Then
                If ValveControl.Name = VENT_VALVE Then
                    Dim IsPMIsoValveClose As Boolean = AVPLib.Utils.IsChamberSlitValveClose(chamberPVDPanel.Name)
                    If IsPMIsoValveClose = False Then
                        Utils.ShowAVPMessageBox("Slit Valve is not close", strChamberName, MessageBoxIcon.Stop)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                           "[" & strChamberName & " Screen] Can not open Vent Valve - Slit Valve is not close")
                        Exit Try
                    End If
                End If
                stoStatusObject.RequestStatus(ValveControl.Name, strValue)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                   "[Main Screen] " + "Click on Valve button in PVD panel.")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ValveControl_Click")
    End Sub
End Class
