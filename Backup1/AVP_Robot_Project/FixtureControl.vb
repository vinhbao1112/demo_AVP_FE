Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPControls

Public Class FixtureControl
    Private Const CONTROLCONTINUOUS As String = "ftcFixtureControlContinuous"
    Private Const CONTROLSTATIC As String = "ftcFixtureControlStatic"
    Private Const CONTROLSWEEP As String = "ftcFixtureControlSweep"

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
        Dim stbRotation1 As New StatusTextBox(Me.txtRotation1)
        'Dim stbRotationMode As New StatusTextBox(Me.txtRotationMode)
        Dim stbTiltAngle1 As New StatusTextBox(Me.txtTiltAngle1)

        Dim stbRotation2 As New StatusTextBox(Me.txtRotationRight)
        Dim stbRotation3 As New StatusTextBox(Me.txtRotationLastRight)
        Dim stbTiltAngle2 As New StatusTextBox(Me.txtTiltAngleRight)

        Dim svoSmallCircleControlError As New StatusFourStatusControl(sccFixtureError)
        Dim svoSmallCricleControlTiltAngle As New StatusFourStatusControl(SmallCricleControlTiltAngle)
        Dim svoSmallCricleControlTiltRotation As New StatusFourStatusControl(SmallCricleControlTiltRotation)

        m_stoStatusObject.Name = Me.Name
        m_stoStatusObject.AddChild(stbRotation1)
        'm_stoStatusObject.AddChild(stbRotationMode)
        m_stoStatusObject.AddChild(stbTiltAngle1)

        m_stoStatusObject.AddChild(stbRotation2)
        m_stoStatusObject.AddChild(stbRotation3)
        m_stoStatusObject.AddChild(stbTiltAngle2)

        m_stoStatusObject.AddChild(svoSmallCricleControlTiltAngle)
        m_stoStatusObject.AddChild(svoSmallCricleControlTiltRotation)
        m_stoStatusObject.AddChild(svoSmallCircleControlError)
        Me.txtRotationMode.Text = GetMode(Me.Name)
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-20</date>
    ''' </author>
    ''' <summary>
    ''' Get Mode
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMode(ByVal Name As String) As String
        Try
            If Name = CONTROLCONTINUOUS Then
                Return "Continuous"
            End If
            If Name = CONTROLSTATIC Then
                Return "Static"
            End If
            If Name = CONTROLSWEEP Then
                Return "Sweep"
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return ""
    End Function
#End Region

#Region "Events – Buttons – Forms…"

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
    Private Sub txtRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTiltAngleRight.Click, txtRotationRight.Click, txtRotationLastRight.Click
        AVPLib.Log.guiLogger.Info("Enter txtRight_Click")
        Try
            Dim TextBox As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
            Dim Source As String = "FixtureControl" + "." + TextBox.Name
            Dim frm As New NumPad()
            Dim Min As Single = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MIN)
            Dim Max As Single = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MAX)
            Dim strLogMessage As String = String.Empty

            Dim Title As String
            If Name = CONTROLCONTINUOUS Then
                Title = (String.Format(AVPLib.ContainerData.GetMessageText(Source), "RPM"))
            ElseIf Name = CONTROLSTATIC Then
                Title = (String.Format(AVPLib.ContainerData.GetMessageText(Source), "Angle"))
            Else
                Title = (String.Format(AVPLib.ContainerData.GetMessageText(Source), "Start"))
            End If
            Dim Value As String = Replace(TextBox.Text, ",", "")
            Dim InputRes As MsgBoxResult = frm.GetUserInput(Value, -1, -1, Min, Max, Title)

            If frm.IsMaxMinModified Then
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MIN, frm.NewMin)
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MAX, frm.NewMax)
            End If

            If InputRes = MsgBoxResult.Ok Then
                TextBox.Text = Value

                Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "-Fixture] Change Fixture Value to " + Value)
                m_stoStatusObject.RequestStatus(TextBox.Name, TextBox.Text)
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
    ''' btnMode_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMode.Click
        AVPLib.Log.guiLogger.Info("Enter btnMode_Click")
        Try
            Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
            If Name = CONTROLCONTINUOUS Then
                'CType(Me.Parent, Chamber1Panel).ftcFixtureControlSweep.Visible = False
                'CType(Me.Parent, Chamber1Panel).ftcFixtureControlContinuous.Visible = False
                'CType(Me.Parent, Chamber1Panel).ftcFixtureControlStatic.lblRotationRPM.Text = "Rotation Angle"
                'CType(Me.Parent, Chamber1Panel).ftcFixtureControlStatic.Visible = True
                ' m_stoStatusObject.RequestStatus(Me.txtRotationMode.Name, AVPLib.IBEConfigurationValues.DEVICE_STATIC)
                'AVP_Robot_Project.Chamber1Panel.m_Current_Status_Fixture = AVPLib.IBEConfigurationValues.DEVICE_STATIC
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "-Fixture] Change Fixture mode to STATIC")
            End If

            If Name = CONTROLSTATIC Then
                'CType(Me.Parent, Chamber1Panel).ftcFixtureControlStatic.Visible = False
                'CType(Me.Parent, Chamber1Panel).ftcFixtureControlContinuous.Visible = False
                'CType(Me.Parent, Chamber1Panel).ftcFixtureControlSweep.lblRotationRPM.Text = "Rotation Start"
                'CType(Me.Parent, Chamber1Panel).ftcFixtureControlSweep.lblRotationEnd.Visible = True
                'CType(Me.Parent, Chamber1Panel).ftcFixtureControlSweep.Visible = True
                'CType(Me.Parent, Chamber1Panel).ftcFixtureControlSweep.txtRotationLastRight.Visible = True
                ' m_stoStatusObject.RequestStatus(Me.txtRotationMode.Name, AVPLib.IBEConfigurationValues.DEVICE_SWEEP)
                'AVP_Robot_Project.Chamber1Panel.m_Current_Status_Fixture = AVPLib.IBEConfigurationValues.DEVICE_SWEEP
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "-Fixture] Change Fixture mode to SWEEP")
            End If
            If Name = CONTROLSWEEP Then
                'CType(Me.Parent, Chamber1Panel).ftcFixtureControlStatic.Visible = False
                'CType(Me.Parent, Chamber1Panel).ftcFixtureControlSweep.Visible = False
                'CType(Me.Parent, Chamber1Panel).ftcFixtureControlContinuous.Visible = True
                'AVP_Robot_Project.Chamber1Panel.m_Current_Status_Fixture = AVPLib.IBEConfigurationValues.DEVICE_CONTINUOUS
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "-Fixture] Change Fixture mode to CONTINUOUS")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnMode_Click")
    End Sub
#End Region

End Class
