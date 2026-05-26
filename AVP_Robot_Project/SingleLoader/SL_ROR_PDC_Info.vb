Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Public Class SL_ROR_PDC_Info
    Private m_Type As DiagnosticType
    Private m_IsStartProcess As Boolean = False
    'Private mouseOffset As Point = New Point(0, 0)
    'Private isDragDrop As Boolean = False

#Region "Properties"

    Public Property TypeOf_DiagnosticScreen() As DiagnosticType
        Get
            Return m_Type
        End Get
        Set(ByVal value As DiagnosticType)
            m_Type = value
            If m_Type = DiagnosticType.PumpDown_Curve Then
                txtSampleTime.Text = "1"
                txtTotalTime.Text = "5"
                txtSampleTime.SourceOfMessageBox = STR_IBE & ".PDC"
                txtTotalTime.SourceOfMessageBox = STR_IBE & ".PDC"
            Else
                txtSampleTime.Text = "5"
                txtTotalTime.Text = "5"
                txtSampleTime.SourceOfMessageBox = STR_IBE & ".ROR"
                txtTotalTime.SourceOfMessageBox = STR_IBE & ".ROR"
            End If
        End Set
    End Property

    Public Property IsStartProcess() As Boolean
        Get
            Return m_IsStartProcess
        End Get
        Set(ByVal value As Boolean)
            m_IsStartProcess = value
        End Set
    End Property

#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal sequenceType As DiagnosticType)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        TypeOf_DiagnosticScreen = sequenceType
    End Sub

#Region "Event"
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.IsStartProcess = False
        Me.Close()
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        m_IsStartProcess = True
        Dim objIBE As AVPLib.DataManagerment.IBEChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Equipments.Chamber1.ToString())
        If objIBE IsNot Nothing Then
            If Me.m_Type = DiagnosticType.Rate_Of_Rise Then
                objIBE.RateOfRise_Interval = txtSampleTime.Text.Trim()
                objIBE.RateOfRise_Sample = txtTotalTime.Text.Trim()
            Else
                objIBE.PumpDown_Curve_Interval = txtSampleTime.Text.Trim()
                objIBE.PumpDown_Curve_Sample = txtTotalTime.Text.Trim()
            End If
        End If
        Me.Close()
    End Sub

    '#04/15/2011 
    '#All PVD/IBE/TM Pop up menu must be movable to other location while active.
    '#Begin fix:
    'Private Sub lblTitle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    mouseOffset = New Point(e.Location.X, e.Location.Y)
    '    isDragDrop = True
    'End Sub

    'Private Sub lblTitle_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If isDragDrop Then
    '        Dim point As Point = Me.Location
    '        Me.Location = New Point(point.X + (e.Location.X - mouseOffset.X), point.Y + (e.Location.Y - mouseOffset.Y))
    '        Me.Opacity = 0.5
    '    End If
    'End Sub

    'Private Sub lblTitle_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If e.Button = Windows.Forms.MouseButtons.Left AndAlso isDragDrop Then
    '        isDragDrop = False
    '        Me.Opacity = 1
    '    End If
    'End Sub
    '#End fix.
#End Region
End Class
