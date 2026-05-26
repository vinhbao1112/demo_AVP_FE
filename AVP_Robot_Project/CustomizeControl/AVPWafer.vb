Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Imports AVPLib.ConstEnum
Public Class AVPWafer
    Inherits System.Windows.Forms.UserControl

    Private m_waferBlue As Bitmap = New Bitmap(AVP_Robot_Project.My.Resources.Resources.Wafer_Unprocess)
    Private m_waferGreen As Bitmap = New Bitmap(AVP_Robot_Project.My.Resources.Resources.Wafer_Complete)
    Private m_waferYellow As Bitmap = New Bitmap(AVP_Robot_Project.My.Resources.Resources.Wafer_Partial)
    Private m_waferRed As Bitmap = New Bitmap(AVP_Robot_Project.My.Resources.Resources.Wafer_Error)
    Private m_strWaferID As String = String.Empty
    Private m_Status As enumWaferStatus = enumWaferStatus.eWaferNew
    Private m_Scale As Single = 1

    Public Property WaferID() As String
        Get
            Return m_strWaferID
        End Get
        Set(ByVal value As String)
            m_strWaferID = value
        End Set
    End Property
    public Property Status() As enumWaferStatus
        Get
            Return m_Status
        End Get
        Set(ByVal value As enumWaferStatus)
            m_Status = value
        End Set
    End Property

    Public Property ScaleNumber() As Single
        Get
            Return m_Scale
        End Get
        Set(ByVal value As Single)
            m_Scale = value
        End Set
    End Property

    Public ReadOnly Property WaferImage() As Bitmap
        Get
            If (m_Status = enumWaferStatus.eWaferNew) Then
                Return AVP_Robot_Project.My.Resources.Resources.Wafer_Unprocess
            End If
            If (m_Status = enumWaferStatus.eWaferError) Then
                Return AVP_Robot_Project.My.Resources.Resources.Wafer_Error
            End If
            If (m_Status = enumWaferStatus.eWaferComplete) Then
                Return AVP_Robot_Project.My.Resources.Resources.Wafer_Complete
            End If
            If (m_Status = enumWaferStatus.eWaferExposed) Then
                Return AVP_Robot_Project.My.Resources.Resources.Wafer_Partial
            End If
            Return Nothing
        End Get
    End Property

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Dim graphicsPath As New Drawing2D.GraphicsPath()
        graphicsPath.AddEllipse(0, 0, WaferImage.Width, WaferImage.Height)
        Me.Region = New Region(graphicsPath)
    End Sub

  
End Class
