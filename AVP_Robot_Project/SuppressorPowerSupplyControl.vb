Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPControls

Public Class SuppressorPowerSupplyControl
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
        Dim stbVoltage1 As New StatusTextBox(Me.txtVoltage1)
        Dim stbVoltage2 As New StatusTextBox(Me.txtVoltageRight)

        Dim stbCurrent As New StatusTextBox(Me.txtCurrent)
        Dim stbCurrentRight As New StatusTextBox(Me.txtCurrentRight)

        m_stoStatusObject.Name = Me.Name
        m_stoStatusObject.AddChild(stbVoltage1)
        m_stoStatusObject.AddChild(stbVoltage2)
        m_stoStatusObject.AddChild(stbCurrent)
        m_stoStatusObject.AddChild(stbCurrentRight)
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
    Private Sub SuppressorPowerSupplyControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
            Dim Source As String = "SuppressorPowerSupplyControl" + "." + TextBox.Name
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

                'Not good as this
                Dim strTextBoxName As String = String.Empty
                strTextBoxName = Replace(TextBox.Name, "txt", "")
                strTextBoxName = Replace(strTextBoxName, "Right", "")
                Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)

                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeEvent, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Set " + strTextBoxName + " to Set Point " + +Value)
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
    Private Sub btnBeam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeam.Click
        AVPLib.Log.guiLogger.Info("Enter btnBeam_Click")
        Try
            'CType(Me.Parent, Chamber1Panel).spsBeamPowerSupply.Visible = True
            'CType(Me.Parent, Chamber1Panel).spsSuppressorPowerSupply.Visible = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnBeam_Click")
    End Sub
#End Region
End Class
