Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class RotateControl
    Private bitmap As Bitmap = New Bitmap(AVP_Robot_Project.My.Resources.Resources.Fixture)
    Private bitmapWafer As Bitmap = New Bitmap(AVP_Robot_Project.My.Resources.Resources.SL_Wafer_Blue)
    Private m_fAngle As Single = 90

#Region "Properties"
    Public Property Image() As Bitmap
        Get
            Return bitmap
        End Get
        Set(ByVal value As Bitmap)
            If value IsNot Nothing Then
                bitmap = New Bitmap(value)
            End If
            Me.PictureBox1.Image = bitmap
        End Set
    End Property

    Public Property Angle() As Single
        Get
            Return m_fAngle
        End Get
        Set(ByVal value As Single)
            If m_fAngle <> value Then
                m_fAngle = value
                If IsNumeric(value) Then
                    Me.PictureBox1.Image = Me.Rotate(MergeImages(bitmap, bitmapWafer), value)
                End If
            End If
        End Set
    End Property

    Private m_ibePanelType As AVPLib.ConstEnum.IBEType = AVPLib.ConstEnum.IBEType.AVP_IBE
    Public Property IBEPanelType() As AVPLib.ConstEnum.IBEType
        Get
            Return m_ibePanelType
        End Get
        Set(ByVal value As AVPLib.ConstEnum.IBEType)
            m_ibePanelType = value
        End Set
    End Property

    Private m_WaferID As String = String.Empty
    Public Property WaferID() As String
        Get
            Return m_WaferID
        End Get
        Set(ByVal value As String)
            m_WaferID = value
        End Set
    End Property

    Private m_WaferStatus As AVPLib.ConstEnum.enumWaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferNew
    Public Property WaferStatus() As AVPLib.ConstEnum.enumWaferStatus
        Get
            Return m_WaferStatus
        End Get
        Set(ByVal value As AVPLib.ConstEnum.enumWaferStatus)
            If m_WaferStatus <> value Then
                m_WaferStatus = value
                If value = AVPLib.ConstEnum.enumWaferStatus.eWaferNew Then
                    Me.bitmapWafer = AVP_Robot_Project.My.Resources.Resources.SL_Wafer_Blue
                ElseIf value = AVPLib.ConstEnum.enumWaferStatus.eWaferExposed Then
                    Me.bitmapWafer = AVP_Robot_Project.My.Resources.Resources.SL_Wafer_Yellow
                ElseIf value = AVPLib.ConstEnum.enumWaferStatus.eWaferError Then
                    Me.bitmapWafer = AVP_Robot_Project.My.Resources.Resources.SL_Wafer_Red
                ElseIf value = AVPLib.ConstEnum.enumWaferStatus.eWaferComplete Then
                    Me.bitmapWafer = AVP_Robot_Project.My.Resources.Resources.SL_Wafer_Green
                Else
                    Me.bitmapWafer = Nothing
                End If
                Me.PictureBox1.Image = Me.Rotate(MergeImages(bitmap, bitmapWafer), Angle)
                Me.Refresh()
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-09</date>
    ''' </author>
    ''' <summary>
    ''' CreateParams overrides property of base class to support transparent
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 32
            Return cp
        End Get
    End Property
#End Region

    'image input have width and height % 2 = 0
    Private Function Rotate(ByVal image As Bitmap, ByVal angle As Single) As Bitmap
        If IBEPanelType = AVPLib.ConstEnum.IBEType.VEECO_IBE Then
                    angle = 90 - angle
                End If
        Return RotateImage(image, New PointF(CType((image.Width / 2), Single), CType((image.Height / 2), Single)), angle)
    End Function

    Public Function MergeImages(ByVal Pic1 As Image, ByVal pic2 As Image) As Bitmap
        Dim MergedImage As Bitmap
        Dim bmp As New Bitmap(Pic1.Width, Pic1.Height)
        Dim gr As Graphics = Graphics.FromImage(bmp)
        gr.DrawImage(Pic1, 0, 0)
        'If DesignMode = False Then
        If WaferStatus <> AVPLib.ConstEnum.enumWaferStatus.eWaferNone Then
            gr.DrawImage(pic2, 12, 33, 79, 40)
            If WaferStatus <> AVPLib.ConstEnum.enumWaferStatus.eWaferExposed Then
                gr.DrawString(Me.WaferID, New Font("Times New Roman", 12, FontStyle.Bold), Brushes.White, 32, 42)
            Else
                gr.DrawString(Me.WaferID, New Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 32, 42)
            End If
        End If
            'End If
            MergedImage = bmp
            gr.Dispose()
            Return MergedImage
    End Function

    Private Function RotateImage(ByVal image As Image, ByVal offset As PointF, ByVal angle As Single) As Bitmap
        If image Is Nothing Then
            Throw New ArgumentNullException("image")
        End If
        Dim temp As Integer = CInt(Math.Sqrt(image.Width * image.Width + image.Height * image.Height))

        'create a new empty bitmap to hold rotated image
        Dim rotatedBmp As New Bitmap(temp, temp)
        rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution)

        'make a graphics object from the empty bitmap
        Dim g As Graphics = Graphics.FromImage(rotatedBmp)

        'Put the rotation point in the center of the image
        g.TranslateTransform(temp / 2, temp / 2)

        'rotate the image
        g.RotateTransform(angle)

        'move the image back
        g.TranslateTransform(-offset.X, -offset.Y)

        'draw passed in image onto graphics object
        g.DrawImage(image, New PointF(0, 0))
        Return rotatedBmp
    End Function

    'Private Sub txtAngle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAngle.TextChanged
    '    If String.IsNullOrEmpty(txtAngle.Text) = False AndAlso IsNumeric(txtAngle.Text) Then
    '        bitmap = Me.Rotate(New System.Drawing.Bitmap(bitmap), CInt(txtAngle.Text))
    '    End If
    'End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub RotateControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IBEPanelType = AVPLib.ConstEnum.IBEType.VEECO_IBE Then
        m_fAngle = 90
        Else
        m_fAngle = 0
        End If
        If DesignMode = False Then
        Me.PictureBox1.Image = Me.Rotate(MergeImages(bitmap, bitmapWafer), Angle)
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim chamberName As String = Me.Parent.Parent.Name

        Dim equipment As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(chamberName)
        If equipment IsNot Nothing Then
            Dim waferInfo As AVPLib.AVPWaferInfo = equipment.GetWaferInfo()
            ' Create wafer dialog
            Dim updateWafer As WaferInfoDlg = New WaferInfoDlg(waferInfo, True)
            updateWafer.ShowDialog()
            'update the wafer infomation for the chamber
            Dim ChamberIndex As String = chamberName.Replace("Chamber", "")
            If (ChamberIndex <> String.Empty) Then
                ContainerForm.CassettesPanel.SetWaferInside(AVPLib.ConstEnum.STR_UPDATE_WAFER, BinaryStatusControl.DisplayStatus.On, waferInfo, ChamberIndex)
            End If
        End If
    End Sub
End Class
