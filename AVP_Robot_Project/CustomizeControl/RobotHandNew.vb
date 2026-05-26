Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Imports AVPLib.ConstEnum
Imports System.Math
Imports System.ComponentModel

Public Class RobotHandNew
    Private m_pmPos As PMPosition = PMPosition.Original
    Private m_status As ArmStatus = ArmStatus.Retract
    Private m_pmInscreen As Support_Screen = Support_Screen.ProcessScreen
    Private m_supportCX As Support_CX = Support_CX.Support_CX4
    Private m_WaferOnHand As Boolean = False
    Private m_waferID As String
    Private m_waferStatus As enumWaferStatus = enumWaferStatus.eWaferNone
    Private m_waferImage As Image = AVP_Robot_Project.My.Resources.Resources.Wafer_Unprocess
    Private m_scaleNumber As Single = 1
    Private m_centerlocation As Point = Nothing
    Private m_currentRobotImage As Image = Nothing
    Private m_angle As Single = 0

    Private m_hasDataChanged As Boolean = True
    Private m_needCreateRegion As Boolean = True
    Private m_drawLocker As New Object

#Region "Properties"
    <DefaultValue(GetType(Support_CX), "Support_CX4")> _
    Public Property CX_Supported() As Support_CX
        Get
            Return m_supportCX
        End Get
        Set(ByVal value As Support_CX)
            If m_supportCX <> value Then
                m_supportCX = value
                m_hasDataChanged = True
                m_needCreateRegion = True
                SetPosition()
            End If
        End Set
    End Property

    <DefaultValue(GetType(PMPosition), "Original")> _
    Public Property PM_Position() As PMPosition
        Get
            Return m_pmPos
        End Get
        Set(ByVal value As PMPosition)
            If m_pmPos <> value Then
                m_pmPos = value
                m_hasDataChanged = True
                m_needCreateRegion = True
                GetAngle()
                SetPosition()
            End If
        End Set
    End Property

    <DefaultValue(GetType(Support_Screen), "ProcessScreen")> _
    Public Property PM_IN_SCREEN() As Support_Screen
        Get
            Return m_pmInscreen
        End Get
        Set(ByVal value As Support_Screen)
            If m_pmInscreen <> value Then
                m_pmInscreen = value
            End If
        End Set
    End Property

    <DefaultValue(GetType(ArmStatus), "Retract")> _
    Public Property Status() As ArmStatus
        Get
            Return m_status
        End Get
        Set(ByVal value As ArmStatus)
            If m_status <> value Then
                m_status = value
                m_hasDataChanged = True
                m_needCreateRegion = True
            End If
        End Set
    End Property

    Public ReadOnly Property RobotArmImage() As Bitmap
        Get
            If m_status = ArmStatus.Extend Then
                Return New Bitmap(AVP_Robot_Project.My.Resources.Resources.CX4Robot_Extract)
            ElseIf Me.Status = ArmStatus.Extend_Aligner Then
                Return New Bitmap(AVP_Robot_Project.My.Resources.Resources.CX4Robot_ExtractAtAligner)
            ElseIf Me.Status = ArmStatus.Extend_Pick Then
                Return New Bitmap(AVP_Robot_Project.My.Resources.Resources.CX4Robot_Extract_Pick)
            ElseIf Me.Status = ArmStatus.Extend_Alinger_Pick Then
                Return New Bitmap(AVP_Robot_Project.My.Resources.Resources.CX4Robot_ExtractAtAligner_Pick)
            End If
            Return New Bitmap(AVP_Robot_Project.My.Resources.Resources.CX4Robot)
        End Get
    End Property

    Public Property CenterLocation() As Point
        Get
            Return New Point(Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        End Get
        Set(ByVal value As Point)
            Me.Location = New Point(value.X - Me.Width / 2, value.Y - Me.Height / 2)
            m_centerlocation = value
            m_hasDataChanged = True
        End Set
    End Property

    Public Property CenterPivotLocation() As Point
        Get
            Return New Point(Me.Location.X + Me.Width / 2, Me.Location.Y + Me.Height / 2)
        End Get
        Set(ByVal value As Point)
            Me.Location = New Point(value.X - Me.Width / 2, value.Y - Me.Height / 2)
            m_hasDataChanged = True
        End Set
    End Property

    <DefaultValue(GetType(String), "")> _
    Public Property WaferID() As String
        Get
            Return m_waferID
        End Get
        Set(ByVal value As String)
            If m_waferID <> value Then
                m_waferID = value
                m_hasDataChanged = True
            End If
        End Set
    End Property

    <DefaultValue(GetType(enumWaferStatus), "eWaferNone")> _
    Public Property WaferStatus() As enumWaferStatus
        Get
            Return m_waferStatus
        End Get
        Set(ByVal value As enumWaferStatus)
            If m_waferStatus <> value Then
                m_waferStatus = value
                If (value = enumWaferStatus.eWaferNew) Then
                    Me.m_waferImage = AVP_Robot_Project.My.Resources.Resources.Wafer_Unprocess
                ElseIf (value = enumWaferStatus.eWaferError) Then
                    Me.m_waferImage = AVP_Robot_Project.My.Resources.Resources.Wafer_Error
                ElseIf (value = enumWaferStatus.eWaferComplete) Then
                    Me.m_waferImage = AVP_Robot_Project.My.Resources.Resources.Wafer_Complete
                ElseIf (value = enumWaferStatus.eWaferExposed) Then
                    Me.m_waferImage = AVP_Robot_Project.My.Resources.Resources.Wafer_Partial
                End If
                m_hasDataChanged = True
                m_needCreateRegion = True
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property WaferOnHand() As Boolean
        Get
            Return m_WaferOnHand
        End Get
        Set(ByVal value As Boolean)
            If m_WaferOnHand <> value Then
                m_WaferOnHand = value
                m_hasDataChanged = True
                m_needCreateRegion = True
            End If
        End Set
    End Property

    Public ReadOnly Property PivotWaferOnArm() As PointF
        Get
            Return GetPivotWafer()
        End Get
    End Property

#End Region

#Region "Subs & Functions"
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.DoubleBuffered = True

    End Sub

    ''' <author>
    '''    	<name> Nguyen Thanh Nam</name>
    '''    	<date> 2015-5-15</date>
    ''' </author>
    ''' <summary>    
    ''' Draw Robothand follow Properties
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetPosition()
        SyncLock m_drawLocker
            Try
                If m_hasDataChanged Then
                    'Draw Robothand 
                    m_currentRobotImage = RotateImage(RobotArmImage, m_angle, HEIGHT_PIVOT)

                    m_currentRobotImage = ScaleImage(m_currentRobotImage, m_scaleNumber)
                    Me.Width = m_currentRobotImage.Width
                    Me.Height = m_currentRobotImage.Height

                    'Draw Wafer
                    If m_WaferOnHand AndAlso m_waferStatus <> enumWaferStatus.eWaferNone Then
                        If m_currentRobotImage IsNot Nothing Then
                            m_currentRobotImage = DrawWafer(m_currentRobotImage)
                        End If

                        Dim x As Integer = CInt(Me.PivotWaferOnArm.X)
                        Dim y As Integer = CInt(Me.PivotWaferOnArm.Y)
                        WaferControl.Location = New Point(x - WaferControl.Width / 2, y - WaferControl.Height / 2)
                    End If

                    If m_needCreateRegion Then
                        Utils.CreateControlRegion(Me, m_currentRobotImage)
                        m_needCreateRegion = False
                    Else
                        Me.BackgroundImage = m_currentRobotImage
                    End If

                    m_hasDataChanged = False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End SyncLock
    End Sub

    ''' <author>
    '''    	<name> Nguyen Thanh Nam</name>
    '''    	<date> 2015-5-15</date>
    ''' </author>
    ''' <summary>    
    ''' Rotate Robothand and wafer around pivot
    ''' </summary>
    ''' <remarks></remarks>
    Private Function RotateImage(ByVal image As Image, ByVal angle As Single, ByVal heightPivot As Integer) As Bitmap
        Try
            If image Is Nothing Then
                Throw New ArgumentNullException("image")
            End If
            Dim x As Integer = AVP_Robot_Project.My.Resources.Resources.CX4Robot_Extract.Width
            Dim y As Integer = AVP_Robot_Project.My.Resources.Resources.CX4Robot_Extract.Height - heightPivot + m_waferImage.Height / 2
            Dim temp1 As Single = CSng(2 * (Math.Sqrt((x / 2.0F) * (x / 2.0F) + (y) * (y))))
            Dim returnBitmap As New Bitmap(CInt(temp1), CInt(temp1))
            returnBitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution)

            'Move image to pivot of image is bitmap center 
            Using g1 As Graphics = Graphics.FromImage(returnBitmap)
                g1.DrawImage(image, New PointF((temp1) / 2.0F - image.Width / 2.0F, (temp1) / 2.0F - heightPivot))
            End Using
            image = returnBitmap
            '
            'Rotate image around center 
            '
            Dim NewImageWidth As Integer = 0
            Dim NewImageHeight As Integer = 0
            Dim temp As Integer = image.Height
            NewImageWidth = temp
            NewImageHeight = temp

            Dim upperLeftDrawPoint As Point = New Point(0, 0)
            Dim imageCenterOffset As PointF = New PointF(temp1 / 2.0F, temp1 / 2.0F)

            'create a new empty bitmap to hold rotated image
            Dim rotatedBmp As New Bitmap(NewImageWidth, NewImageHeight)
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution)

            'make a graphics object from the empty bitmap
            Using g As Graphics = Graphics.FromImage(rotatedBmp)
                g.TranslateTransform(upperLeftDrawPoint.X + imageCenterOffset.X, upperLeftDrawPoint.Y + imageCenterOffset.Y)
                g.RotateTransform(angle)
                g.TranslateTransform((upperLeftDrawPoint.X + imageCenterOffset.X) * -1, (upperLeftDrawPoint.Y + imageCenterOffset.Y) * -1)
                g.DrawImage(image, New PointF(0, 0))

            End Using
            Return rotatedBmp
            
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Nguyen Thanh Nam</name>
    '''    	<date> 2015-5-15</date>
    ''' </author>
    ''' <summary>  
    '''Scale image follow scaleNumber
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ScaleImage(ByVal OldImage As Image, ByVal scaleNumber As Single) As System.Drawing.Image
        Try
            Dim NewHeight As Integer = CInt(OldImage.Height * scaleNumber)
            Dim NewWidth As Integer = CInt(OldImage.Width * scaleNumber)
            Return New Bitmap(OldImage, NewWidth, NewHeight)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            Return Nothing
        End Try
    End Function

    ''' <author>
    '''    	<name> Nguyen Thanh Nam</name>
    '''    	<date> 2015-5-15</date>
    ''' </author>
    ''' <summary>    
    '''Merge Robothand image and wafer image image
    ''' </summary>
    ''' <remarks></remarks>
    Function MergeImages(ByVal WaferImg As Image, ByVal RobotHandImg As Image) As Bitmap
        Dim MergedImage As Bitmap = Nothing
        Try
            Dim d, h As Integer
            'Get distance from pivot of Robothand to center of Wafer on Robothand
            If Status = ArmStatus.Retract Then
                d = ConstEnum.HEIGHT_PIVOT_WAFER_ON_ARM_RETRACT - HEIGHT_PIVOT
            ElseIf Status = ArmStatus.Extend Then
                d = HEIGHT_PIVOT_WAFER_ON_ARM_EXTEND - HEIGHT_PIVOT
            Else
                d = HEIGHT_PIVOT_WAFER_ON_ARM_EXTEND_ALIGNER - HEIGHT_PIVOT
            End If

            Dim imgWidth As Integer = IIf(RobotHandImg.Width > WaferImg.Width, RobotHandImg.Width, WaferImg.Width)
            'create new bitmap 
            h = RobotHandImg.Height + WaferImg.Height / 2
            MergedImage = New Bitmap(imgWidth, h)
            MergedImage.SetResolution(RobotHandImg.HorizontalResolution, RobotHandImg.VerticalResolution)

            'drawing tool
            Dim gr As Graphics = Graphics.FromImage(MergedImage)
            
            'draw hand
            gr.DrawImage(RobotHandImg, 0, 0)
            'draw wafer
            gr.DrawImage(WaferImg, CInt(MergedImage.Width / 2 - WaferImg.Width / 2), d)

            gr.Dispose()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return MergedImage
    End Function

    ''' <author>
    '''    	<name> Nguyen Thanh Nam</name>
    '''    	<date> 2015-5-15</date>
    ''' </author>
    ''' <summary>    
    '''Draw ID wafer into wafer on Robothand
    ''' </summary>
    ''' <remarks></remarks>
    Function DrawWafer(ByVal RobotHandImg As Image) As Bitmap
        Dim MergedImage As Bitmap = Nothing
        Try

            MergedImage = New Bitmap(RobotHandImg.Width, RobotHandImg.Width)
            MergedImage.SetResolution(RobotHandImg.HorizontalResolution, RobotHandImg.VerticalResolution)

            'drawing tool
            Dim gr As Graphics = Graphics.FromImage(MergedImage)

            'draw hand
            gr.DrawImage(RobotHandImg, 0, 0)
            'draw wafer id
            Dim x As Single = Me.PivotWaferOnArm.X
            Dim y As Single = Me.PivotWaferOnArm.Y
            'draw wafer
            gr.DrawImage(m_waferImage, CSng(x) - CSng(m_waferImage.Width / 2), CSng(y) - CSng(m_waferImage.Height / 2))
            Dim strF As StringFormat = New StringFormat()
            strF.Alignment = StringAlignment.Center
            If WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferComplete Or WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferExposed Then
                gr.DrawString(Me.WaferID, New Font("Times New Roman", 10, FontStyle.Bold), Brushes.Black, x, y - 7, strF)
            Else
                gr.DrawString(Me.WaferID, New Font("Times New Roman", 10, FontStyle.Bold), Brushes.White, x, y - 7, strF)
            End If

            gr.Dispose()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return MergedImage
    End Function

    ''' <author>
    '''    	<name> Nguyen Thanh Nam</name>
    '''    	<date> 2015-5-20</date>
    ''' </author>
    ''' <summary>    
    '''Get pivot of wafer on Robothand
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetPivotWafer() As PointF
        Dim pResult As PointF = New PointF(0, 0)
        Try
            Dim d, x, y, x1, y1, d1 As Single
            'Get distance from pivot of Robothand to center of Wafer on Robothand
            If Status = ArmStatus.Retract Then
                d = ConstEnum.HEIGHT_PIVOT_WAFER_ON_ARM_RETRACT - HEIGHT_PIVOT
            ElseIf Status = ArmStatus.Extend Then
                d = HEIGHT_PIVOT_WAFER_ON_ARM_EXTEND - HEIGHT_PIVOT
            Else
                d = HEIGHT_PIVOT_WAFER_ON_ARM_EXTEND_ALIGNER - HEIGHT_PIVOT
            End If
            d = d * m_scaleNumber

            Dim key As String = Me.CX_Supported.ToString() & "_" & Me.PM_Position.ToString()
            Dim angle As Single = Math.Abs(m_angle)
            While (angle - 90 >= 0)
                angle -= 90
            End While
            y = Math.Cos(Math.PI * (angle / 180)) * d
            x = Math.Sqrt(d * d - y * y)
            If 0 <= m_angle And m_angle < 90 Then
                x1 = y
                y1 = -x

            ElseIf m_angle >= 90 And m_angle < 180 Then
                x1 = -x
                y1 = -y

            ElseIf 0 >= m_angle And m_angle > -90 Then
                x1 = y
                y1 = x

            ElseIf m_angle <= -90 Then
                x1 = -x
                y1 = y

            ElseIf m_angle >= 180 And m_angle < 270 Then
                x1 = -y
                y1 = x

            ElseIf m_angle >= 270 Then
                x1 = x
                y1 = y

            End If
            pResult = New PointF(Me.Width / 2 + y1, Me.Height / 2 + x1)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return pResult
    End Function

    ''' <author>
    '''    	<name> Nguyen Thanh Nam</name>
    '''    	<date> 2015-5-27</date>
    ''' </author>
    ''' <summary>    
    '''Event click on wafer
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Wafer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles WaferControl.Click
        Dim strID As String = String.Empty
        Dim robot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
        ''check it is robot first, then check robot has wafer or not (AndAlso different than And)
        If robot IsNot Nothing AndAlso robot.GetWaferInfo() IsNot Nothing AndAlso Me.Parent.Name = "ProcessPanel" Then
            strID = robot.GetWaferInfo().WaferID
            Dim blResumed As Boolean = False
            ProcessPanel.ClickedPosition = CLICKEDROBOT
            Dim avpProcessJob As AVPLib.Business.AVPProcessJob = Nothing
            avpProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(strID)
            Dim bShowReturnNow As Boolean = False
            If avpProcessJob IsNot Nothing Then
                blResumed = avpProcessJob.IsPaused() ''PJ is paused
                bShowReturnNow = avpProcessJob.IsJobOver()
            Else
                If (Utils.isAlignerInUse()) Then
                    If (AVPLib.RobotConfigurationValues.ALIGNER_AT_STATION = AVPLib.RobotConfigurationValues.LLA_STATION_NO AndAlso _
                    robot.GetWaferInfo().WaferID.ToString().Contains("A")) Then
                        bShowReturnNow = False
                    Else
                        bShowReturnNow = True
                    End If
                Else
                    bShowReturnNow = True
                End If
            End If
            ShowContextMenuClickOnAlignerAndRobot(sender, blResumed, bShowReturnNow)
        ElseIf robot IsNot Nothing AndAlso robot.GetWaferInfo() IsNot Nothing AndAlso Me.Parent.Name = CASSETTESPANEL_STR Then
            Dim pos As New System.Drawing.Point(WaferControl.Location)
            pos = Me.PointToScreen(pos)
            ContainerForm.CassettesPanel.mnuCreateWafer.Enabled = False
            ContainerForm.CassettesPanel.mnuDeleteWafer.Enabled = True
            ContainerForm.CassettesPanel.mnuDstForMove.Enabled = False
            ContainerForm.CassettesPanel.mnuSrcForMove.Enabled = True
            ContainerForm.CassettesPanel.mnuUpdateWaferInfoToolStripMenuItem.Enabled = True
            CassettesPanel.ClickedInChamber = CLICKEDROBOT
            pos.Y += WaferControl.Height
            ContainerForm.CassettesPanel.cmsChamber.Show(pos)
        End If
    End Sub

    ''' <author>
    '''    	<name> Nguyen Thanh Nam</name>
    '''    	<date> 2015-5-27</date>
    ''' </author>
    ''' <summary>    
    '''Show menu when click on wafer
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ShowContextMenuClickOnAlignerAndRobot(ByVal sender As Object, ByVal blshowResume As Boolean, ByVal blShowReturnNow As Boolean)
        Try
            Dim cpcTemp As AVPWafer
            cpcTemp = CType(sender, AVPWafer)
            Dim pos As New System.Drawing.Point(cpcTemp.Location)
            pos = Me.PointToScreen(pos)
            ContainerForm.ProcessPanel.mnuResume.Enabled = blshowResume
            ContainerForm.ProcessPanel.mnuReturn.Enabled = blshowResume
            ContainerForm.ProcessPanel.mnuReturnNow.Enabled = blShowReturnNow And (Not ContainerForm.ProcessPanel.IsButtonClearAllWaferClicked)
            pos.Y += cpcTemp.Height
            ContainerForm.ProcessPanel.cmsChamber.Show(pos)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

    Private Sub RobotHandNew_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetPosition()
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-07-27 </date>
    ''' </author>
    ''' <summary>    
    ''' Get rotation angle of robot arm
    ''' </summary>
    Private Sub GetAngle()
        Select Case m_pmPos
            Case PMPosition.Original
                m_angle = 0
            Case PMPosition.LLA
                m_angle = 0
            Case PMPosition.PM1
                m_angle = 90
            Case PMPosition.PM2
                m_angle = 180
            Case PMPosition.PM3
                m_angle = -90
        End Select
    End Sub
End Class
