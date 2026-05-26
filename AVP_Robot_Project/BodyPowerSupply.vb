Imports AVP_Robot_Project.ConstantAndEnum
Public Class BodyPowerSupply
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
            Dim stbDischargrCurrent As New StatusTextBox(Me.txtDischargeCurrent)
            Dim stbBodyCurrent As New StatusTextBox(Me.txtBodyCurrent)

            Dim stbKFactor As New StatusTextBox(Me.txtKFactor)
            Dim stbKFactorRight As New StatusTextBox(Me.txtKFactorRight)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbDischargrCurrent)
            m_stoStatusObject.AddChild(stbBodyCurrent)

            m_stoStatusObject.AddChild(stbKFactor)
            m_stoStatusObject.AddChild(stbKFactorRight)
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
    Private Sub DischargePowerSupply_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-09-01 </date>
    ''' </author>
    ''' <summary>
    ''' Handling Click TextBox Right
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtKFactorRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKFactorRight.Click
        AVPLib.Log.guiLogger.Info("Enter txtRight_Click")
        Try
            Dim TextBox As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
            Dim Source As String = "BodyPowerSupply" + "." + TextBox.Name
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
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "-Body PS] Change K Factor to " + Value)

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
