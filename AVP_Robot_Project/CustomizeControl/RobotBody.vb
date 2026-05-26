Public Class RobotBody
    Private bmp As Bitmap = New Bitmap(AVP_Robot_Project.My.Resources.Resources.CX4)
    Private m_supportCX As PMControl.Support_CX = PMControl.Support_CX.Support_CX4
    Private m_pmInscreen As PMControl.Support_Screen = PMControl.Support_Screen.ProcessScreen
    Private m_intAligner_At_Station As Integer = 1
#Region "Property"
    Public Property LLAInstalled() As Boolean
        Get
            Return SensorLLA.PMVisible
        End Get
        Set(ByVal value As Boolean)
            If AVPLib.RobotConfigurationValues.ROBOT_SENSOR_INSTALLED = False Then
                value = False
            End If
            If AVPLib.RobotConfigurationValues.ALIGNER_AT_STATION = AVPLib.RobotConfigurationValues.LLA_STATION_NO Then
                SensorLLA.PMVisible = True
            Else
                SensorLLA.PMVisible = value
            End If
        End Set
    End Property

    Public Property PM1Installed() As Boolean
        Get
            Return SensorPM1.PMVisible
        End Get
        Set(ByVal value As Boolean)
            If AVPLib.RobotConfigurationValues.ROBOT_SENSOR_INSTALLED = False Then
                value = False
            End If
            SensorPM1.PMVisible = value
        End Set
    End Property

    Public Property PM2Installed() As Boolean
        Get
            Return SensorPM2.PMVisible
        End Get
        Set(ByVal value As Boolean)
            If AVPLib.RobotConfigurationValues.ROBOT_SENSOR_INSTALLED = False Then
                value = False
            End If
            SensorPM2.PMVisible = value
        End Set
    End Property

    Public Property PM3Installed() As Boolean
        Get
            Return SensorPM3.PMVisible
        End Get
        Set(ByVal value As Boolean)
            If AVPLib.RobotConfigurationValues.ROBOT_SENSOR_INSTALLED = False Then
                value = False
            End If
            SensorPM3.PMVisible = value
        End Set
    End Property


    Public Property CX_Supported() As PMControl.Support_CX
        Get
            Return m_supportCX
        End Get
        Set(ByVal value As PMControl.Support_CX)
            m_supportCX = value
            ChangeImage()
        End Set
    End Property

    Public Property PM_IN_SCREEN() As PMControl.Support_Screen
        Get
            Return m_pmInscreen
        End Get
        Set(ByVal value As PMControl.Support_Screen)
            m_pmInscreen = value
            ChangeImage()
        End Set
    End Property

    Public ReadOnly Property SensorPM1_Position() As Point
        Get
            Return SensorPM1.Location
        End Get
    End Property

    Public ReadOnly Property SensorPM2_Position() As Point
        Get
            Return SensorPM2.Location
        End Get
    End Property

    Public ReadOnly Property SensorPM3_Position() As Point
        Get
            Return SensorPM3.Location
        End Get
    End Property

    Public ReadOnly Property SensorLLA_Position() As Point
        Get
            Return SensorLLA.Location
        End Get
    End Property

    Public Property Aligner_At_Station() As Integer
        Get
            Return m_intAligner_At_Station
        End Get
        Set(ByVal value As Integer)
            m_intAligner_At_Station = value
        End Set
    End Property

#End Region

#Region "Support Method"
    Public Sub ChangeImage()
        If AVPLib.RobotConfigurationValues.ALIGNER_AT_STATION = 1 Then ''load lock A
#If AVP_CX_STYLE = "CX5" Then
            If PM_IN_SCREEN = PMControl.Support_Screen.ProcessScreen Then
                bmp = AVP_Robot_Project.My.Resources.CX5_Resources.CX5_Robot_body_Left_Aligner
                If Not AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
                    bmp = AVP_Robot_Project.My.Resources.CX5_Resources.CX5_Robot_body
                End If
            ElseIf PM_IN_SCREEN = PMControl.Support_Screen.TM Then
                bmp = AVP_Robot_Project.My.Resources.CX5_Resources.CX5_Robot_body_Left_Aligner
                If Not AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
                    bmp = AVP_Robot_Project.My.Resources.CX5_Resources.CX5_Robot_body
                End If
            End If

#ElseIf AVP_CX_STYLE = "CX4" Then
            bmp = AVP_Robot_Project.My.Resources.Resources.CX4
            If Not AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
                bmp = AVP_Robot_Project.My.Resources.CX4_WithoutAligner
            End If
#End If
        ElseIf AVPLib.RobotConfigurationValues.ALIGNER_AT_STATION = 10 Then ''load lock B
#If AVP_CX_STYLE = "CX5" Then
            'If PM_IN_SCREEN = PMControl.Support_Screen.ProcessScreen Then
            '    bmp = AVP_Robot_Project.My.Resources.CX5_Resources.CX5_Robot_body_Right_Aligner
            '    If Not AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
            '        bmp = AVP_Robot_Project.My.Resources.CX5_Resources.CX5_Robot_body
            '    End If
            'ElseIf PM_IN_SCREEN = PMControl.Support_Screen.TM Then
            '    bmp = AVP_Robot_Project.My.Resources.CX5_Resources.CX5_Robot_body_Right_Aligner
            '    If Not AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
            '        bmp = AVP_Robot_Project.My.Resources.CX5_Resources.CX5_Robot_body
            '    End If
            'End If
            'If PM_IN_SCREEN = PMControl.Support_Screen.ProcessScreen Then
            '    bmp = AVP_Robot_Project.My.Resources.CX4_Resources.CX4_ProcessScreen_Robot_With_Aligner
            '    If Not AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
            '        bmp = AVP_Robot_Project.My.Resources.CX4_Resources.CX4_ProcessScreen_Robot
            '    End If
            'ElseIf PM_IN_SCREEN = PMControl.Support_Screen.TM Then
            '    bmp = AVP_Robot_Project.My.Resources.CX4_Resources.CX4_TM_Robot_WIth_Aligner
            '    If Not AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
            '        bmp = AVP_Robot_Project.My.Resources.CX4_Resources.CX4_TM_Robot
            '    End If
            'End If
#End If

        End If
        Utils.CreateControlRegion(Me, bmp)
        Me.Refresh()
    End Sub

    Protected Overrides Sub CreateStatusTree()
        Try
            If DesignMode Then
                Exit Sub
            End If
            Dim sbcCircleStatus1 As New StatusBinaryStatusControl(SensorLLA)
            Dim sbcCircleStatus3 As New StatusBinaryStatusControl(SensorPM1)
            Dim sbcCircleStatus4 As New StatusBinaryStatusControl(SensorPM2)
            Dim sbcCircleStatus5 As New StatusBinaryStatusControl(SensorPM3)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(sbcCircleStatus1)
            m_stoStatusObject.AddChild(sbcCircleStatus3)
            m_stoStatusObject.AddChild(sbcCircleStatus4)
            m_stoStatusObject.AddChild(sbcCircleStatus5)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.Cursor = Cursors.Hand
        ' Add any initialization after the InitializeComponent() call.

        If AVPLib.RobotConfigurationValues.ROBOT_SENSOR_INSTALLED = False Then
            SensorLLA.Visible = False
            SensorPM1.Visible = False
            SensorPM2.Visible = False
            SensorPM3.Visible = False
        End If


    End Sub

    Private Sub RobotBody_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click, SensorLLA.Click, SensorPM1.Click, SensorPM2.Click, SensorPM3.Click
        If PM_IN_SCREEN = PMControl.Support_Screen.ProcessScreen Then
            AVPRobotMain.GotoScreen(AVPRobotMain.SystemScreens.TMScreen)
        End If
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-08 </date>
    ''' </author>
    ''' <summary>
    ''' Locate sensor
    ''' </summary>
    Private Sub ArrangeSensor(ByVal cx As PMControl.Support_CX)
        If cx = PMControl.Support_CX.Support_CX4 Then
            SensorPM1.Location = New Point(22, 79)
            SensorPM2.Location = New Point(79, 22)
            SensorPM3.Location = New Point(137, 79)
            SensorLLA.Location = New Point(79, 137)
        End If
    End Sub
End Class
