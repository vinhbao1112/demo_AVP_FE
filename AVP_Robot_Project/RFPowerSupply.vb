Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports AVP_Robot_Project.ConstantAndEnum
Public Class RFPowerSupply
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
            Dim stbForwardPower1 As New StatusTextBox(Me.txtForwardPower1)
            Dim stbReflectedPower As New StatusTextBox(Me.txtReflectedPower)
            Dim stbReflectedPowerRight As New StatusTextBox(Me.txtReflectedPowerRight)

            Dim stbForwardPower2 As New StatusTextBox(Me.txtForwardPowerRight)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbForwardPower1)
            m_stoStatusObject.AddChild(stbReflectedPower)
            m_stoStatusObject.AddChild(stbReflectedPowerRight)

            m_stoStatusObject.AddChild(stbForwardPower2)
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
    Private Sub RFPowerSupply_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtReflectedPowerRight.Visible = False
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
    Private Sub txtForwardPower2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtForwardPowerRight.Click, txtReflectedPowerRight.Click
        AVPLib.Log.guiLogger.Info("Enter txtForwardPower2_Click")
        Try
            Dim TextBox As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
            Dim Source As String = "RFPowerSupply" + "." + TextBox.Name
            Dim frm As New NumPad()
            Dim Min As Single = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MIN)
            Dim Max As Single = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MAX)
            Dim Title As String = AVPLib.ContainerData.GetMessageText(Source)
            Dim Value As String = Replace(TextBox.Text, ",", String.Empty)

            Dim InputRes As MsgBoxResult = frm.GetUserInput(Value, -1, -1, Min, Max, Title)

            If frm.IsMaxMinModified Then
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MIN, frm.NewMin)
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MAX, frm.NewMax)
            End If

            If InputRes = MsgBoxResult.Ok Then
                TextBox.Text = Value

                Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Set Forward Power To Set Point " + Value)
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
        AVPLib.Log.guiLogger.Info("Leave txtForwardPower2_Click")
    End Sub
#End Region
End Class
