Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Public Class BACenterControl
#Region "Properties & Constant"

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
            Dim stbCG1 As New StatusTextBox(Me.txtCG1)
            Dim stbCG2 As New StatusTextBox(Me.txtCG2)
            Dim stbIG As New StatusTextBox(Me.txtIG)

            Dim sibTurboWater As New StatusIGCGButton(Me.bigcgIG)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbCG1)
            m_stoStatusObject.AddChild(stbCG2)
            m_stoStatusObject.AddChild(stbIG)

            m_stoStatusObject.AddChild(sibTurboWater)
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
    Private Sub BACenterControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
#End Region

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-10-13 </date>
    ''' </author>
    ''' <summary>
    ''' Handling Click TextBox CG2
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtCG2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCG2.Click
        AVPLib.Log.guiLogger.Info("Enter txtCG2_Click")
        Try
            Dim TextBox As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
            Dim Source As String = "BACenterControl" + "." + TextBox.Name
            Dim frm As New NumPad
            Dim Min As Single = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MIN)
            Dim Max As Single = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MAX)
            Dim Title As String = AVPLib.ContainerData.GetMessageText(Source)
            Dim value As String = TextBox.Text
            Dim InputRes As MsgBoxResult = frm.GetUserInput(value, -1, -1, Min, Max, Title)

            If frm.IsMaxMinModified Then
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MIN, frm.NewMin)
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MAX, frm.NewMax)
            End If

            If InputRes = MsgBoxResult.Ok Then
                TextBox.Text = value

                Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Set CG Set Point to " + value)

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
        AVPLib.Log.guiLogger.Info("Leave txtCG2_Click")
    End Sub

    Private Sub bigcgIG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bigcgIG.Click
        AVPLib.Log.guiLogger.Info("Enter bigcgIG_Click")
        Dim strMessageText As String = String.Empty
        Dim strValue As String = String.Empty
        Dim Message As String = Me.Name + Me.bigcgIG.Name
        Try
            If (Me.bigcgIG.Status = BinaryStatusControl.DisplayStatus.On) Then
                strMessageText = AVPLib.ContainerData.GetMessageText(Message + AVP_Robot_Project.ConstantAndEnum.STRING_CLOSE)
                strValue = BinaryStatusControl.DisplayStatus.Off.ToString(STRING_G)
            Else
                strMessageText = AVPLib.ContainerData.GetMessageText(Message + AVP_Robot_Project.ConstantAndEnum.STRING_OPEN)
                strValue = BinaryStatusControl.DisplayStatus.On.ToString(STRING_G)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Finally
            If (Utils.ShowAVPMessageBox(strMessageText, "Valve", MessageBoxIcon.Question) = DialogResult.OK) Then
                Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)

                If Me.bigcgIG.Status = ButtonIGCGControl.DisplayStatus.On Then
                    m_stoStatusObject.RequestStatus(Me.bigcgIG.Name, STR_OFF)
                    'Me.bigcgIG.Status = ButtonIGCGControl.DisplayStatus.Off
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Turn off IG")
                Else
                    m_stoStatusObject.RequestStatus(Me.bigcgIG.Name, STR_ON)
                    ' Me.bigcgIG.Status = ButtonIGCGControl.DisplayStatus.On
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Turn on IG")
                End If
            End If
        End Try
        AVPLib.Log.guiLogger.Info("Leave bigcgIG_Click")
    End Sub
End Class
