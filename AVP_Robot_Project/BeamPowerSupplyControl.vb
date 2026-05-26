Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Public Class BeamPowerSupplyControl
#Region "Properties"
#End Region
#Region "Protected method"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbCurrent As New StatusTextBox(Me.txtCurrent)
            Dim stbVoltage1 As New StatusTextBox(Me.txtVoltage1)

            Dim stbCurrentRight As New StatusTextBox(Me.txtCurrentRight)
            Dim stbVoltage2 As New StatusTextBox(Me.txtVoltageRight)
            Dim stbAutoBeam As New StatusIGCGButton(Me.btnAutoBeam)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbCurrent)
            m_stoStatusObject.AddChild(stbVoltage1)
            m_stoStatusObject.AddChild(stbCurrentRight)
            m_stoStatusObject.AddChild(stbVoltage2)
            m_stoStatusObject.AddChild(stbAutoBeam)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19 </date>
    ''' </author>
    ''' <summary>
    ''' Handling control loading event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BeamPowerSupplyControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19 </date>
    ''' </author>
    ''' <summary>
    ''' Handling Click TextBox Right
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVoltageRight.Click, txtCurrentRight.Click
        AVPLib.Log.guiLogger.Info("Enter txtRight_Click")
        Try
            Dim TextBox As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
            Dim Source As String = "BeamPowerSupplyControl" + "." + TextBox.Name
            Dim frm As New NumPad()
            Dim Min As Single = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MIN)
            Dim Max As Single = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MAX)
            Dim Title As String = AVPLib.ContainerData.GetMessageText(Source)
            Dim Value As String = Replace(TextBox.Text, ",", "")
            Dim InputRes As MsgBoxResult = frm.GetUserInput(Value, -1, -1, Min, Max, Title)

            If frm.IsMaxMinModified Then
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MIN, frm.NewMin)
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MAX, frm.NewMax)
            End If

            If InputRes = MsgBoxResult.Ok Then
                TextBox.Text = Value

                Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)

                If TextBox.Name = "txtVoltageRight" Then
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "-Beam PS] Change Voltage to " + Value)
                ElseIf TextBox.Name = "txtCurrentRight" Then
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "-Beam PS] Change Current to " + Value)
                End If

                m_stoStatusObject.RequestStatus(TextBox.Name, TextBox.Text)
                Try
                    'change to scientific format
                    Dim strRetValue As String = Format(Double.Parse(TextBox.Text), AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                    TextBox.Text = strRetValue
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txtRight_Click")
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19 </date>
    ''' </author>
    ''' <summary>
    ''' Handling Click btnSuppressor
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSuppressor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuppressor.Click
        AVPLib.Log.guiLogger.Info("Enter btnSuppressor_Click")
        Try
            'CType(Me.Parent, Chamber1Panel).spsBeamPowerSupply.Visible = False
            ' CType(Me.Parent, Chamber1Panel).spsSuppressorPowerSupply.Visible = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnSuppressor_Click")
    End Sub
#End Region
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-09-16 </date>
    ''' </author>
    ''' <summary>
    ''' btnAutoBeam_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub btnAutoBeam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoBeam.Click
        AVPLib.Log.guiLogger.Info("Enter btnAutoBeam_Click")
        Dim strMessageText As String = String.Empty
        Dim strValue As String = String.Empty
        Try

            If (btnAutoBeam.Status = BinaryStatusControl.DisplayStatus.On) Then
                strMessageText = AVPLib.ContainerData.GetMessageText("BeamPowerSupplyAutoBeamDisable")
                strValue = BinaryStatusControl.DisplayStatus.Off.ToString(STRING_G)
            Else
                strMessageText = AVPLib.ContainerData.GetMessageText("BeamPowerSupplyAutoBeamEnable")
                strValue = BinaryStatusControl.DisplayStatus.On.ToString(STRING_G)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Finally
            If (Utils.ShowAVPMessageBox(strMessageText, "BeamPowerSupply", MessageBoxIcon.Question) = DialogResult.OK) Then
                Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
                If btnAutoBeam.Status = ButtonIGCGControl.DisplayStatus.On Then
                    m_stoStatusObject.RequestStatus(btnAutoBeam.Name, STR_OFF)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "-Beam PS] Disable Auto Beam")
                Else
                    m_stoStatusObject.RequestStatus(btnAutoBeam.Name, STR_ON)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "-Beam PS] Enable Auto Beam")
                End If
            End If
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnAutoBeam_Click")
    End Sub
End Class
