Imports System.ComponentModel
Imports AVPControls.AVPDataLib

Public Class InlineChamber

#Region "Fields"
    Const T1TextDefault As String = ""
    Const T2TextDefault As String = ""
    Const T1MaterialTextDefault As String = ""
    Const T2MaterialTextDefault As String = ""
    Const S1TextDefault As String = ""
    Const S2TextDefault As String = ""
    Const MotorTextDefault As String = ""
    Const LoadLockLabel As String = "LOADLOCK"
    Const ChamberBorderWidth As Integer = 7
    Const TopHeight As Integer = 28
    Const BottomHeight As Integer = 28
    Const SensorToBorderSpace As Integer = 3
    Const TargetToEdgeSpace As Integer = 21
    Const TargetHeight As Integer = 25
    Const SensorWidth As Integer = 9
    Const SensorToTextSpace As Integer = 2

    Shared ChamberTextFont As New Font("Times New Roman", 12, FontStyle.Bold, GraphicsUnit.Pixel)

    Private m_T1Installed As Boolean = True
    Private m_T2Installed As Boolean = True
    Private m_T1Text As String = T1TextDefault
    Private m_T1MaterialText As String = T1MaterialTextDefault
    Private m_T2Text As String = T2TextDefault
    Private m_T2MaterialText As String = T2MaterialTextDefault
    Private m_isT1PlasmaOn As Boolean
    Private m_isT2PlasmaOn As Boolean
    Private m_s1Text As String = S1TextDefault
    Private m_s2Text As String = S2TextDefault
    Private m_isSensor1On As Boolean
    Private m_isSensor2On As Boolean
    Private m_motorText As String = MotorTextDefault
    Private m_motorStatus As MotorStatuses = MotorStatuses.Off
    Private m_isLastChamber As Boolean
    Private m_chamberWidth As Integer

#End Region

#Region "Events"

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        NumberOfTargets = 2
        IsInitialized = True
    End Sub

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-12</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether the T1 is installed.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(True), Category(InlinePropertyCategoryName)> _
    Public Property T1Installed() As Boolean
        Get
            Return m_T1Installed
        End Get
        Set(ByVal value As Boolean)
            If m_T1Installed <> value Then
                m_T1Installed = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-12</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether the T2 is installed.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(True), Category(InlinePropertyCategoryName)> _
    Public Property T2Installed() As Boolean
        Get
            Return m_T2Installed
        End Get
        Set(ByVal value As Boolean)
            If m_T2Installed <> value Then
                m_T2Installed = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-11</date>
    ''' <summary>
    ''' Gets or sets T1 text.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(T1TextDefault), Category(InlinePropertyCategoryName)> _
    Public Property T1Text() As String
        Get
            Return m_T1Text
        End Get
        Set(ByVal value As String)
            If m_T1Text <> value Then
                m_T1Text = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-11</date>
    ''' <summary>
    ''' Gets or sets T2 text.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(T2TextDefault), Category(InlinePropertyCategoryName)> _
    Public Property T2Text() As String
        Get
            Return m_T2Text
        End Get
        Set(ByVal value As String)
            If m_T2Text <> value Then
                m_T2Text = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-11</date>
    ''' <summary>
    ''' Gets or sets T1 material text.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(T1MaterialTextDefault), Category(InlinePropertyCategoryName)> _
    Public Property T1MaterialText() As String
        Get
            Return m_T1MaterialText
        End Get
        Set(ByVal value As String)
            If m_T1MaterialText <> value Then
                m_T1MaterialText = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-11</date>
    ''' <summary>
    ''' Gets or sets T2 material text.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(T2MaterialTextDefault), Category(InlinePropertyCategoryName)> _
    Public Property T2MaterialText() As String
        Get
            Return m_T2MaterialText
        End Get
        Set(ByVal value As String)
            If m_T2MaterialText <> value Then
                m_T2MaterialText = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-12</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether T1 plasma is on.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(False), Category(InlinePropertyCategoryName)> _
    Public Property IsT1PlasmaOn() As Boolean
        Get
            Return m_isT1PlasmaOn
        End Get
        Set(ByVal value As Boolean)
            If m_isT1PlasmaOn <> value Then
                m_isT1PlasmaOn = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-12</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether T2 plasma is on.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(False), Category(InlinePropertyCategoryName)> _
    Public Property IsT2PlasmaOn() As Boolean
        Get
            Return m_isT2PlasmaOn
        End Get
        Set(ByVal value As Boolean)
            If m_isT2PlasmaOn <> value Then
                m_isT2PlasmaOn = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-12</date>
    ''' <summary>
    ''' Gets or sets sensor 1 text.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(S1TextDefault), Category(InlinePropertyCategoryName)> _
    Public Property S1Text() As String
        Get
            Return m_s1Text
        End Get
        Set(ByVal value As String)
            If m_s1Text <> value Then
                m_s1Text = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-12</date>
    ''' <summary>
    ''' Gets or sets sensor 2 text.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(S2TextDefault), Category(InlinePropertyCategoryName)> _
    Public Property S2Text() As String
        Get
            Return m_s2Text
        End Get
        Set(ByVal value As String)
            If m_s2Text <> value Then
                m_s2Text = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-12</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether the sensor 1 is on.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(False), Category(InlinePropertyCategoryName)> _
    Public Property IsSensor1On() As Boolean
        Get
            Return m_isSensor1On
        End Get
        Set(ByVal value As Boolean)
            If m_isSensor1On <> value Then
                m_isSensor1On = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-12</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether the sensor 2 is on.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(False), Category(InlinePropertyCategoryName)> _
    Public Property IsSensor2On() As Boolean
        Get
            Return m_isSensor2On
        End Get
        Set(ByVal value As Boolean)
            If m_isSensor2On <> value Then
                m_isSensor2On = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-12</date>
    ''' <summary>
    ''' Gets or sets motor text.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(MotorTextDefault), Category(InlinePropertyCategoryName)> _
    Public Property MotorText() As String
        Get
            Return m_motorText
        End Get
        Set(ByVal value As String)
            If m_motorText <> value Then
                m_motorText = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-12</date>
    ''' <summary>
    ''' Gets or sets motor status.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(MotorStatuses), "Off"), Category(InlinePropertyCategoryName)> _
    Public Property MotorStatus() As MotorStatuses
        Get
            Return m_motorStatus
        End Get
        Set(ByVal value As MotorStatuses)
            If m_motorStatus <> value Then
                m_motorStatus = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-12</date>
    ''' <summary>
    ''' Gets a value indicating whether the motor is on.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsMotorOn() As Boolean
        Get
            Return m_motorStatus <> MotorStatuses.Off
        End Get
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-12</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether the chamber is the last one.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(False), Category(InlinePropertyCategoryName)> _
    Public Property IsLastChamber() As Boolean
        Get
            Return m_isLastChamber
        End Get
        Set(ByVal value As Boolean)
            If m_isLastChamber <> value Then
                m_isLastChamber = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-06-11</date>
    ''' <summary>
    ''' Gets sensor 1 position.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Sensor1Position() As Integer
        Get
            Return ChamberBorderWidth + SensorToBorderSpace + CInt(SensorWidth / 2.0)
        End Get
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-06-11</date>
    ''' <summary>
    ''' Gets sensor 2 position.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Sensor2Position() As Integer
        Get
            Return m_chamberWidth - ChamberBorderWidth - SensorToBorderSpace - CInt(SensorWidth / 2.0)
        End Get
    End Property

#End Region

#Region "Public Methods"

#End Region

#Region "Internal Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-12</date>
    ''' <summary>
    ''' Generate image of control.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Dim imgChamber As Bitmap = My.Resources.Resources.Inline_Chamber_Empty
        Try
            Using g As Graphics = Graphics.FromImage(imgChamber)
                g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

                m_chamberWidth = imgChamber.Width
                Dim chamberHeight As Integer = imgChamber.Height

                If IsLastChamber Then
                    Dim closedDoorImage As Bitmap = My.Resources.Resources.Inline_Chamber_ClosedDoor
                    g.DrawImage(closedDoorImage, 0, 0)
                    closedDoorImage.Dispose()
                End If

                ' Draw target or label.
                If ChamberType = AVPChamberTypes.LoadLock Then
                    Dim titleTextSize As SizeF = g.MeasureString(LoadLockLabel, ChamberTextFont)
                    Dim titleX As Integer = CInt((m_chamberWidth - titleTextSize.Width) / 2)
                    Dim titleY As Integer = CInt(((TopHeight - ChamberBorderWidth) - titleTextSize.Height) / 2) + ChamberBorderWidth
                    g.DrawString(LoadLockLabel, ChamberTextFont, Brushes.Black, titleX, titleY)
                Else
                    If T1Installed Then
                        Dim target1Image As Bitmap = GetTargetImage(IsT1PlasmaOn, T1MaterialText)
                        g.DrawImage(target1Image, TargetToEdgeSpace, ChamberBorderWidth - 1)
                        target1Image.Dispose()
                    End If

                    If T2Installed Then
                        Dim target2Image As Bitmap = GetTargetImage(IsT2PlasmaOn, T2MaterialText)
                        g.DrawImage(target2Image, m_chamberWidth - TargetToEdgeSpace - target2Image.Width, ChamberBorderWidth - 1)
                        target2Image.Dispose()
                    End If
                End If

                ' Draw sensors.
                Dim sensorY As Integer = chamberHeight - BottomHeight + CInt((BottomHeight - ChamberBorderWidth - SensorWidth) / 2)

                Dim sensor1Image As Bitmap = GetSensorImage(IsSensor1On)
                g.DrawImage(sensor1Image, ChamberBorderWidth + SensorToBorderSpace, sensorY)
                sensor1Image.Dispose()

                If Not String.IsNullOrEmpty(S1Text) Then
                    Dim s1TextSize As SizeF = g.MeasureString(S1Text, ChamberTextFont)
                    Dim s1TextY As Integer = chamberHeight - BottomHeight + CInt((BottomHeight - ChamberBorderWidth - s1TextSize.Height) / 2)
                    g.DrawString(S1Text, ChamberTextFont, Brushes.Black, ChamberBorderWidth + SensorToBorderSpace + SensorWidth + SensorToTextSpace, s1TextY)
                End If

                Dim sensor2Image As Bitmap = GetSensorImage(IsSensor2On)
                g.DrawImage(sensor2Image, m_chamberWidth - ChamberBorderWidth - SensorToBorderSpace - SensorWidth, sensorY)
                sensor2Image.Dispose()

                If Not String.IsNullOrEmpty(S2Text) Then
                    Dim s2TextSize As SizeF = g.MeasureString(S2Text, ChamberTextFont)
                    Dim s2TextY As Integer = chamberHeight - BottomHeight + CInt((BottomHeight - ChamberBorderWidth - s2TextSize.Height) / 2)
                    g.DrawString(S2Text, ChamberTextFont, Brushes.Black, m_chamberWidth - ChamberBorderWidth - SensorToBorderSpace - SensorWidth - SensorToTextSpace - s2TextSize.Width, s2TextY)
                End If

                ' Draw motor.
                If Not String.IsNullOrEmpty(MotorText) Then
                    Dim motorTextSize As SizeF = g.MeasureString(MotorText, ChamberTextFont)
                    Dim motorTextX As Integer = CInt((m_chamberWidth - motorTextSize.Width) / 2)
                    Dim motorTextY As Integer = chamberHeight - BottomHeight + CInt((BottomHeight - ChamberBorderWidth - motorTextSize.Height) / 2)

                    g.DrawString(MotorText, ChamberTextFont, Brushes.Black, motorTextX, motorTextY)
                End If

                If IsMotorOn Then
                    Dim motorStatusImage As Bitmap = My.Resources.Resources.Inline_MotorOnRightArrow

                    If MotorStatus = MotorStatuses.Reverse Then
                        motorStatusImage.RotateFlip(RotateFlipType.RotateNoneFlipX)
                    End If
                    g.DrawImage(motorStatusImage, 0, 0)

                    motorStatusImage.Dispose()
                End If
            End Using
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return imgChamber
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-12</date>
    ''' <summary>
    ''' Generate target image.
    ''' </summary>
    ''' <param name="isPlamaOn"></param>
    ''' <param name="materialText"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetTargetImage(ByVal isPlamaOn As Boolean, ByVal materialText As String) As Bitmap
        Dim imgTargetImage As Bitmap = Nothing
        Try
            If isPlamaOn Then
                imgTargetImage = My.Resources.Resources.Inline_Target_Plasma
            Else
                imgTargetImage = My.Resources.Resources.Inline_Target
            End If

            If Not String.IsNullOrEmpty(materialText) Then
                Using g As Graphics = Graphics.FromImage(imgTargetImage)
                    Dim targetWidth As Integer = imgTargetImage.Width
                    Dim targetTextSize As SizeF = g.MeasureString(materialText, ChamberTextFont)
                    g.DrawString(materialText, ChamberTextFont, Brushes.Black, CInt((targetWidth - targetTextSize.Width) / 2), CInt((TargetHeight - targetTextSize.Height) / 2))
                End Using
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return imgTargetImage
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-12</date>
    ''' <summary>
    ''' Gets sensor image.
    ''' </summary>
    ''' <param name="isSensorOn"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSensorImage(ByVal isSensorOn As Boolean) As Bitmap
        Dim imgSensor As Bitmap = Nothing
        Try
            Dim img As Bitmap = Nothing
            If isSensorOn Then
                img = My.Resources.Resources.LEDGreen
            Else
                img = My.Resources.Resources.LEDGrey
            End If

            imgSensor = New Bitmap(img, SensorWidth, SensorWidth)

            img.Dispose()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return imgSensor
    End Function

#End Region

End Class
