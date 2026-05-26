Imports System.ComponentModel
Imports AVPControls.AVPDataLib
Imports AVPControls.AVPGraphicsLib

Public Class SlitValveControl
    Inherits AVPStatusControlBase

    Private m_dockPosition As AVPDockPositions = AVPDockPositions.Undefined
    Private m_inScreen As AVPScreens = AVPScreens.ProcessScreen

    Protected m_strOnText As String = String.Empty
    Protected m_strOffText As String = String.Empty
    Protected m_strUnknownText As String = String.Empty
    Protected m_strErrorText As String = String.Empty


#Region "Properties"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicates the control is in which screen of AVP.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(AVPScreens), "ProcessScreen"), Category("AVP Properties"), Description("Get or set a value indicates the control is in which screen of AVP.")> _
    Public Overrides Property InScreen() As AVPScreens
        Get
            Return m_inScreen
        End Get
        Set(ByVal value As AVPScreens)
            If m_inScreen <> value Then
                m_inScreen = value
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicates the dock position of slit value control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(AVPDockPositions), "Undefined"), Description("Get or set a value indicates the dock position of slit value control.")> _
    Public Property DockPosition() As AVPDockPositions
        Get
            Return m_dockPosition
        End Get
        Set(ByVal value As AVPDockPositions)
            If (m_dockPosition <> value) Then
                m_dockPosition = value
                Me.SetRotationAngle()
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-11-23</date>
    ''' </author>
    ''' <summary>
    ''' Set of get Text base On Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), "")> _
    Public Property ErrorText() As String
        Get
            Return m_strErrorText
        End Get
        Set(ByVal value As String)
            If m_strErrorText = value Then
                Return
            End If
            m_strErrorText = value
            If Me.Status = DisplayStatus.Error Then
                Me.UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-11-23</date>
    ''' </author>
    ''' <summary>
    ''' Set of get Text base On Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), "")> _
    Public Property UnKnownText() As String
        Get
            Return m_strUnknownText
        End Get
        Set(ByVal value As String)
            If m_strUnknownText = value Then
                Return
            End If
            m_strUnknownText = value
            If Me.Status = DisplayStatus.Unknow Then
                Me.UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-11-23</date>
    ''' </author>
    ''' <summary>
    ''' Set of get Text base On Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), "")> _
    Public Property OffText() As String
        Get
            Return m_strOffText
        End Get
        Set(ByVal value As String)
            If m_strOffText = value Then
                Return
            End If
            m_strOffText = value
            If Me.Status = DisplayStatus.Off Then
                Me.UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-11-23</date>
    ''' </author>
    ''' <summary>
    ''' Set of get Text base On Status
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), "")> _
    Public Property OnText() As String
        Get
            Return m_strOnText
        End Get
        Set(ByVal value As String)
            If m_strOnText = value Then
                Return
            End If
            m_strOnText = value
            If Me.Status = DisplayStatus.On Then
                Me.UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name>Hai Tran</name>
    '''    	<date>2016-01-14</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates the text which drawing in hivac control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(""), Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            If MyBase.Text = value Then
                Return
            End If

            MyBase.Text = value
            UpdateView()
        End Set
    End Property
#End Region

#Region "Methods"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Overrides for drawing image of slit valve.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Dim img As Bitmap = Nothing
        Try
            If AVPStyle = AVPStyles.PodSystem Then
                Select Case Me.Status
                    Case DisplayStatus.Off
                        img = My.Resources.Resources.POD_HivacValve_Closed
                    Case DisplayStatus.On
                        img = My.Resources.Resources.POD_HivacValve_Open
                    Case Else
                        img = My.Resources.Resources.POD_HivacValve_Unknown
                End Select
            ElseIf AVPStyle = AVPStyles.Inline Then
                img = GetInlineSlitValve()

                ' Get drawing text.
                Dim textValue As String = Me.GetDrawingText()
                If Not String.IsNullOrEmpty(textValue) Then
                    Dim textBrush As SolidBrush

                    ' Get drawing values.
                    Select Case Me.Status
                        Case DisplayStatus.Off
                            textBrush = New SolidBrush(Color.White)
                        Case DisplayStatus.On
                            textBrush = New SolidBrush(Color.Black)
                        Case Else
                            textBrush = New SolidBrush(Color.Black)
                    End Select

                    ' Drawing text.
                    Using g As Graphics = Graphics.FromImage(img)
                        ' Draw background.

                        Dim sizeText As SizeF = g.MeasureString(textValue, Me.Font)
                        Dim x As Single
                        Dim y As Single

                        x = (img.Width - sizeText.Width) / 2
                        y = (img.Height - sizeText.Height) / 2

                        ' Draw text.
                        g.DrawString(textValue, Me.Font, textBrush, x, y)

                    End Using

                    textBrush.Dispose()
                End If
            Else
                Select Case Me.Status
                    Case DisplayStatus.Off
                        img = My.Resources.Resources.SlitValve_Close
                    Case DisplayStatus.On
                        img = My.Resources.Resources.SlitValve_Open
                    Case Else
                        img = My.Resources.Resources.SlitValve_Unknown
                End Select

                If DockPosition = AVPDockPositions.HivacLLA _
                    OrElse DockPosition = AVPDockPositions.HivacLLB _
                    OrElse DockPosition = AVPDockPositions.HivacTM Then
                    Dim scaleWidthImg As Bitmap = New Bitmap(img, CInt(47 / ScalingFactor), img.Height)
                    img.Dispose()
                    img = scaleWidthImg
                End If
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return img
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2018-04-12</date>
    ''' <summary>
    ''' Returns image of Inline's slitvalve.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetInlineSlitValve() As Bitmap
        Dim img As Bitmap = Nothing

        If DockPosition = AVPDockPositions.LLA Then
            Select Case Me.Status
                Case DisplayStatus.None
                    img = My.Resources.Resources.InlineLeftSlitValve_None
                Case DisplayStatus.Off
                    img = My.Resources.Resources.InlineLeftSlitValve_Closed
                Case DisplayStatus.On
                    img = My.Resources.Resources.InlineLeftSlitValve_Opened
                Case Else
                    img = My.Resources.Resources.InlineLeftSlitValve_Unknown
            End Select
        ElseIf DockPosition = AVPDockPositions.LLB Then
            Select Case Me.Status
                Case DisplayStatus.None
                    img = My.Resources.Resources.InlineRightSlitValve_None
                Case DisplayStatus.Off
                    img = My.Resources.Resources.InlineRightSlitValve_Closed
                Case DisplayStatus.On
                    img = My.Resources.Resources.InlineRightSlitValve_Opened
                Case Else
                    img = My.Resources.Resources.InlineRightSlitValve_Unknown
            End Select
        ElseIf DockPosition = AVPDockPositions.HivacInlinePM Then
            Select Case Me.Status
                Case DisplayStatus.Off
                    img = My.Resources.Resources.SlitValve_Close
                Case DisplayStatus.On
                    img = My.Resources.Resources.SlitValve_Open
                Case Else
                    img = My.Resources.Resources.SlitValve_Unknown
            End Select
            Dim scaleWidthImg As Bitmap = New Bitmap(img, 72, 16)
            img.Dispose()
            img = scaleWidthImg
        ElseIf DockPosition = AVPDockPositions.HivacLoader Then
            Dim scaleWidthImg As Bitmap = New Bitmap(img, CInt(68 / ScalingFactor), CInt(18 / ScalingFactor))
            img.Dispose()
            img = scaleWidthImg
        Else
            Select Case Me.Status
                Case DisplayStatus.None
                    img = My.Resources.Resources.InlineSlitValve_None
                Case DisplayStatus.Off
                    img = My.Resources.Resources.InlineSlitValve_Closed
                Case DisplayStatus.On
                    img = My.Resources.Resources.InlineSlitValve_Opened
                Case Else
                    img = My.Resources.Resources.InlineSlitValve_Unknown
            End Select
        End If

        Return img
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Set rotation angle of slit valve.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetRotationAngle()
        Dim angle As Single = 0

        If Me.AVPStyle = AVPStyles.CX6 OrElse Me.AVPStyle = AVPStyles.CX7 OrElse Me.AVPStyle = AVPStyles.CX8 Then
            Select Case Me.m_dockPosition
                Case AVPDockPositions.LLA
                    angle = 29
                Case AVPDockPositions.LLB
                    angle = -29
                Case AVPDockPositions.HivacLLA
                    angle = -61
                Case AVPDockPositions.HivacLLB
                    angle = 61
                Case Else
                    If Me.AVPStyle = AVPStyles.CX8 Then
                        Select Case Me.m_dockPosition
                            Case AVPDockPositions.PM1
                                angle = 74
                            Case AVPDockPositions.PM2
                                angle = 116
                            Case AVPDockPositions.PM3
                                angle = 158
                            Case AVPDockPositions.PM4
                                angle = -159
                            Case AVPDockPositions.PM5
                                angle = -117
                            Case AVPDockPositions.PM6
                                angle = -74
                        End Select
                    ElseIf Me.AVPStyle = AVPStyles.CX7 Then
                        Select Case Me.m_dockPosition
                            Case AVPDockPositions.PM1
                                angle = 90
                            Case AVPDockPositions.PM2
                                angle = 135
                            Case AVPDockPositions.PM3
                                angle = 180
                            Case AVPDockPositions.PM4
                                angle = -135
                            Case AVPDockPositions.PM5
                                angle = -90
                        End Select
                    ElseIf Me.AVPStyle = AVPStyles.CX6 Then
                        Select Case Me.m_dockPosition
                            Case AVPDockPositions.PM1
                                angle = 90
                            Case AVPDockPositions.PM2
                                angle = 150
                            Case AVPDockPositions.PM3
                                angle = 30
                            Case AVPDockPositions.PM4
                                angle = -90
                        End Select
                    End If
            End Select
        ElseIf Me.AVPStyle = AVPStyles.CX5 OrElse Me.AVPStyle = AVPStyles.CX4 Then
            Select Case Me.m_dockPosition
                Case AVPDockPositions.PM1
                    angle = -90
                Case AVPDockPositions.PM2
                    angle = 0
                Case AVPDockPositions.PM3
                    angle = 90
                Case Else
                    If Me.AVPStyle = AVPStyles.CX5 Then
                        Select Case Me.m_dockPosition
                            Case AVPDockPositions.LLA
                                angle = 30
                            Case AVPDockPositions.LLB
                                angle = -30
                            Case AVPDockPositions.HivacLLA
                                angle = -61
                            Case AVPDockPositions.HivacLLB
                                angle = 61
                            Case AVPDockPositions.HivacTM
                                angle = 45
                        End Select
                    Else
                        Select Case Me.m_dockPosition
                            Case AVPDockPositions.LLA
                                angle = 0
                            Case AVPDockPositions.LLB
                                angle = 0
                            Case AVPDockPositions.HivacLLA
                                angle = 90
                            Case AVPDockPositions.HivacLLB
                                angle = 90
                            Case AVPDockPositions.HivacTM
                                angle = 135
                        End Select
                    End If
            End Select
        ElseIf Me.AVPStyle = AVPStyles.ML Then
            Select Case Me.m_dockPosition
                Case AVPDockPositions.HivacLoader
                    angle = 90
                Case Else
                    angle = 0
            End Select
        End If

        Me.RotationAngle = angle
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Set scale factor of slit valve.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetScaleFactor()
        Select Case Me.AVPStyle
            Case AVPStyles.CX4, AVPStyles.CX5
                Me.ScalingFactor = 0.71F
            Case AVPStyles.CX6, AVPStyles.CX7, AVPStyles.CX8
                Me.ScalingFactor = 0.535F
            Case AVPStyles.SL, AVPStyles.ML
                Me.ScalingFactor = 0.9F
        End Select
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2016-01-14 </date>
    ''' </author>
    ''' <summary>
    ''' Gets text for drawing in control.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Function GetDrawingText() As String
        Try
            Dim value As String = String.Empty
            Select Case Me.Status
                Case DisplayStatus.Off
                    value = Me.OffText
                Case DisplayStatus.On
                    value = Me.OnText
                Case DisplayStatus.Unknow
                    value = Me.UnKnownText
                Case DisplayStatus.Error
                    value = Me.ErrorText
            End Select
            If String.IsNullOrEmpty(value) Then
                value = Me.Text
            End If
            Return value
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function
#End Region

#Region "Events"
    Public Sub New()
        Me.DoubleBuffered = True
        Me.ScaleMode = AVPControlStyleModes.ControlOwner
        Me.RotationMode = AVPControlStyleModes.ControlOwner
        Me.IsInitialized = True
        Me.ResumeUpdateView()
    End Sub

    Protected Overrides Sub OnAVPStyleChanged(ByVal e As System.EventArgs)
        Me.SetScaleFactor()
        Me.SetRotationAngle()
        MyBase.OnAVPStyleChanged(e)
    End Sub

#End Region

End Class