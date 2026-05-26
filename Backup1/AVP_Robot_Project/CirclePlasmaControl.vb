Imports avplib
Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum
Public Class CirclePlasmaControl
    Private m_strWaferID As String = String.Empty
    Private m_stWaferStatus As enumWaferStatus = enumWaferStatus.eWaferNone
    Private imgWafer As Image = My.Resources.Resources.Wafer_None
    'Private imgPlasmaOn As Image = Global.AVP_Robot_Project.My.Resources.Resources.CirclePink
    'Private imgPlasmaOff As Image = Global.AVP_Robot_Project.My.Resources.Resources.CircleBlank
    'Private imgQuestionMark As Image = Global.AVP_Robot_Project.My.Resources.Resources.Question_Mark
    'Private imgQuestionMarkWhite As Image = Global.AVP_Robot_Project.My.Resources.Resources.Question_Mark_White
    Private m_blnResumedWafer As Boolean = False
    Private m_BrushColor As Brush = Brushes.Wheat
    Private m_blnPlasmaOn As Boolean = False
    Private m_blnIsPlasmaChange As Boolean = False
    Private m_size As Size = New Size(50, 50)
    Private m_PositionID As Int16 = 0
    Private m_PMSlotNumber As Int16 = 1
    Private m_bShowSlotNumber As Boolean = False
    Private m_pShowSlotPosition As Point = New Point(1, 25)
    Private m_previewClipRectangle As Rectangle

#Region "Constructor & Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-21</date>
    ''' </author>
    ''' <summary>
    ''' Initialize default value for this control
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-11-23 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set WaferID
    ''' </summary>
    ''' <remarks></remarks>
    Public Property WaferID() As String
        Get
            Return m_strWaferID
        End Get
        Set(ByVal value As String)
            If m_strWaferID <> value Then
                m_strWaferID = value
                If m_strWaferID = "" Then
                    Me.imgWafer = My.Resources.Resources.Wafer_None
                End If
                Me.Refresh()
            End If
        End Set
    End Property
    Public Property SizeControl() As Size
        Get
            Return m_size
        End Get
        Set(ByVal value As Size)
            m_size = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date>2009-11-23 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set WaferStatus
    ''' </summary>
    ''' <remarks></remarks>
    Public Property WaferStatus() As enumWaferStatus
        Get
            Return m_stWaferStatus
        End Get
        Set(ByVal value As enumWaferStatus)
            If Not (m_stWaferStatus = value) Then
                m_stWaferStatus = value

                Me.Refresh()
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-11-23 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Plasma Status
    ''' </summary>
    ''' <remarks></remarks>
    Public Property PlasmaOn() As Boolean
        Get
            Return m_blnPlasmaOn
        End Get
        Set(ByVal value As Boolean)
            If Not m_blnPlasmaOn = value Then
                m_blnPlasmaOn = value
                m_blnIsPlasmaChange = True
            Else
                m_blnIsPlasmaChange = False
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-11-23 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Plasma Status
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ShowSlotNumber() As Boolean
        Get
            Return m_bShowSlotNumber
        End Get
        Set(ByVal value As Boolean)
            m_bShowSlotNumber = value
        End Set
    End Property

    Public Property ShowSlotPosition() As Point
        Get
            Return m_pShowSlotPosition
        End Get
        Set(ByVal value As Point)
            m_pShowSlotPosition = value
        End Set
    End Property
    Public Property ResumedWafer() As Boolean
        Get
            Return m_blnResumedWafer
        End Get
        Set(ByVal value As Boolean)
            m_blnResumedWafer = value
        End Set
    End Property

    Public Property PMSlotNumber() As Int16
        Get
            Return m_PMSlotNumber
        End Get
        Set(ByVal value As Int16)
            m_PMSlotNumber = value
        End Set
    End Property

    Public Property PositionID() As Int16
        Get
            Return m_PositionID
        End Get
        Set(ByVal value As Int16)
            m_PositionID = value
        End Set
    End Property
#End Region

#Region "Private Methods"
    
#End Region
 ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-11-03</date>
    ''' </author>
    ''' <summary>
    ''' Paint Wafer and ID on chamber
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            Dim g As Graphics = e.Graphics
            'g.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            'g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            'g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighSpeed
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            'g.CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality

            g.InterpolationMode = Drawing2D.InterpolationMode.Bicubic
            If Not DesignMode Then
                SetWaferID(g)
            End If

            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If Not e.ClipRectangle.IsEmpty AndAlso m_previewClipRectangle <> e.ClipRectangle AndAlso _
                e.ClipRectangle <> Me.ClientRectangle AndAlso Me.WaferStatus = enumWaferStatus.eWaferError Then
                    Me.Refresh()
                End If
            End If
            m_previewClipRectangle = e.ClipRectangle
        Catch ex As Exception
            ' AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-11-17 </date>
    ''' </author>
    ''' <summary>
    ''' Set WaferID when place successful
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetWaferID(ByVal g As Graphics, Optional ByVal x As Single = 0, Optional ByVal y As Single = 0)
        Try
            Dim Chamber As AVPLib.DataManagerment.Chamber = Nothing
            Select Case Me.Parent.Name
                Case "CX_PM1"
                    Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
                Case "CX_PM2"
                    Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber2.ToString())
                Case "CX_PM3"
                    Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber3.ToString())
            End Select

            If Chamber IsNot Nothing Then
                If Chamber.GetWaferInfo(m_PMSlotNumber) IsNot Nothing Then
                    Me.m_strWaferID = Chamber.GetWaferInfo(m_PMSlotNumber).WaferID
                    Me.m_stWaferStatus = Chamber.GetWaferInfo(m_PMSlotNumber).WaferStatus
                ElseIf Chamber.GetWaferInfo(m_PMSlotNumber) Is Nothing Then
                    Me.m_strWaferID = ""

                    If Not (Me.m_stWaferStatus = enumWaferStatus.eWaferNone) Then
                        Me.m_stWaferStatus = enumWaferStatus.eWaferNone

                        If Me.Parent IsNot Nothing Then
                            Dim wfcontrol As PMControl = CType(Me.Parent, PMControl)
                            wfcontrol.ForceRepaint()
                        End If
                    End If
                End If

                If m_stWaferStatus = ConstEnum.enumWaferStatus.eWaferComplete Then
                    Me.imgWafer = My.Resources.Resources.Wafer_Complete
                    m_BrushColor = Brushes.Black
                ElseIf m_stWaferStatus = ConstEnum.enumWaferStatus.eWaferNew Then
                    Me.imgWafer = My.Resources.Resources.Wafer_Unprocess
                    m_BrushColor = Brushes.White
                ElseIf m_stWaferStatus = ConstEnum.enumWaferStatus.eWaferExposed Then
                    Me.imgWafer = My.Resources.Resources.Wafer_Partial
                    m_BrushColor = Brushes.Black
                ElseIf m_stWaferStatus = ConstEnum.enumWaferStatus.eWaferError Then
                    m_BrushColor = Brushes.White
                    Me.imgWafer = My.Resources.Resources.Wafer_Error
                Else
                    Me.imgWafer = My.Resources.Resources.Wafer_None
                    Me.m_strWaferID = ""
                End If

                Dim fontID As Font = New Font("Times New Roman", 10, FontStyle.Bold)
                Dim size As SizeF = g.MeasureString(Me.WaferID, fontID, Me.imgWafer.Size)
                Dim pos As New Point(x + (Me.imgWafer.Width - size.Width) / 2.0F, y + (Me.imgWafer.Height - size.Height) / 2.0F)

                g.DrawImage(Me.imgWafer, x, y, Me.imgWafer.Width, Me.imgWafer.Height)

                ''section draw question mark on Wafer in Process Screen
                Dim isIDDrawed As Boolean = False
                Dim avpProcessJob As AVPLib.Business.AVPProcessJob = Nothing
                If AVPLib.Business.AVPCore.Instance().JobManager IsNot Nothing Then
                    avpProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(WaferID)
                    If avpProcessJob IsNot Nothing AndAlso Not WaferStatus = enumWaferStatus.eWaferNone Then
                        If Me.Parent.Parent.Name = ConstantAndEnum.PROCESSPANEL_STR Then
                            If WaferStatus = enumWaferStatus.eWaferError Then
                                Me.imgWafer = My.Resources.Resources.Wafer_Error_QM
                                g.DrawImage(Me.imgWafer, x, y, Me.imgWafer.Width, Me.imgWafer.Height)
                                g.DrawString(Me.WaferID, fontID, Me.m_BrushColor, pos.X, pos.Y + 5)
                                isIDDrawed = True
                            End If
                        End If
                    End If
                End If

                If Not isIDDrawed Then
                    g.DrawString(Me.WaferID, fontID, Me.m_BrushColor, pos)
                End If

                fontID.Dispose()
                size = Nothing
                pos = Nothing
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
   
    Private Sub CirclePlasmaControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Refresh()
    End Sub
End Class
