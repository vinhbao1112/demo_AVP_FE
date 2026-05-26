Imports AVP_Robot_Project.ConstantAndEnum
Public Class GasControllerControl
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
            Dim stbArgon1 As New StatusTextBox(Me.txtArgon1)
            Dim stbFlowCoolHe1 As New StatusTextBox(Me.txtFlowCoolHe1)
            Dim stbPBN1 As New StatusTextBox(Me.txtPBN1)

            Dim stbArgon2 As New StatusTextBox(Me.txtArgonRight)
            Dim stbFlowCoolHe2 As New StatusTextBox(Me.txtFlowCoolHeRight)
            Dim stbPBN2 As New StatusTextBox(Me.txtPBNRight)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbArgon1)
            m_stoStatusObject.AddChild(stbFlowCoolHe1)
            m_stoStatusObject.AddChild(stbPBN1)

            m_stoStatusObject.AddChild(stbArgon2)
            m_stoStatusObject.AddChild(stbFlowCoolHe2)
            m_stoStatusObject.AddChild(stbPBN2)
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
    Private Sub GasControllerControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19 </date>
    ''' </author>
    ''' <summary>
    ''' Handling Click Textbox Right
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPBNRight.Click, txtFlowCoolHeRight.Click, txtArgonRight.Click
        AVPLib.Log.guiLogger.Info("Enter txtRight_Click")
        Try
            Dim TextBox As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
            Dim Source As String = "GasControllerControl" + "." + TextBox.Name
            Dim frm As New NumPad()
            Dim Min As Single = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MIN)
            Dim Max As Single = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MAX)
            Dim Title As String = AVPLib.ContainerData.GetMessageText(Source)
            Dim Value As String = Replace(TextBox.Text, ",", "")            
            Dim strLogMessage As String = String.Empty

            Dim InputRes As MsgBoxResult = frm.GetUserInput(Value, -1, -1, Min, Max, Title)

            If frm.IsMaxMinModified Then
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MIN, frm.NewMin)
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MAX, frm.NewMax)
            End If

            If InputRes = MsgBoxResult.Ok Then
                TextBox.Text = Value

                'Not good as this
                Dim strGasName As String = String.Empty
                strGasName = Replace(TextBox.Name, "txt", "")
                strGasName = Replace(strGasName, "Right", "")

                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "Set Gas(" + strGasName + ") to Set Point " + Value)
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
#End Region
End Class
