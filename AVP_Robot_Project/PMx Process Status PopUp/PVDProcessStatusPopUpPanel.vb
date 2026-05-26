Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Imports AVPControls

Public Class PVDProcessStatusPopUpPanel
    Private m_iClosingTime As Integer = 30
    Private m_StartTimeOpen As Long
    Private m_timer As System.Timers.Timer
    Private m_TimerClosingForm As System.Timers.Timer

#Region "Properties"

    Public Property PopUpTitle() As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = AVPLib.Utils.chamberID2ChamberName(value) & " Process Status"
        End Set
    End Property

#End Region

#Region "Private methods"
    Protected Overrides Function CheckPermission() As Boolean
        Try
            Return AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_001)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function

    Protected Overrides Sub CreateStatusTree()
        Try
            m_stoStatusObject.Name = Me.Name
            For Each ctrl As Control In tableContainer.Controls
                If ctrl.GetType().Name = "SL_Textbox" Then
                    Dim sTextbox As New StatusPopUpProcessTextBox(CType(ctrl, SL_Textbox))
                    m_stoStatusObject.AddChild(sTextbox)
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_timer = New System.Timers.Timer
        m_timer.Interval = 1000 '1second
        m_timer.Enabled = False
        m_timer.SynchronizingObject = Me
        AddHandler m_timer.Elapsed, AddressOf TimerClosingForm
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Events"
    Private Sub TimerClosingForm(ByVal source As Object, ByVal e As Timers.ElapsedEventArgs)
        m_iClosingTime -= 1
        If m_iClosingTime <= 0 Then
            m_timer.Interval = 100
            Me.Opacity -= 0.1
            If Me.Opacity <= 0 Then
                Me.DoClose()
            End If
        End If
    End Sub

    Private Sub PMProcessStatusPopUpPanel_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        m_timer.Enabled = False
        Me.Close()
    End Sub

    Protected Overrides Sub DoClose()
        m_timer.Enabled = False
        Me.Close()
    End Sub

    Private Sub PMProcessStatusPopUpPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_timer.Enabled = True
        Me.Opacity = 1
        m_iClosingTime = 30
        m_timer.Interval = 1000
    End Sub

    Private Sub lblTitle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HeaderDoubleClick
        Me.DoClose()
    End Sub
   
#End Region

    Private Sub PMProcessStatusPopUpPanel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus, Me.Leave
        Me.DoClose()
    End Sub

    Public Sub IsTarget_DC(ByVal value As Boolean)
        Try
            If value Then
                ''DC
                Me.tableContainer.Controls.Add(Me.lblTargetForwardPower, 0, 0)
                Me.tableContainer.Controls.Add(Me.txtTargetForwardPowerRB, 1, 0)
                Me.tableContainer.Controls.Add(Me.txtTargetForwardPowerSP, 2, 0)

                Me.tableContainer.Controls.Add(Me.lblVoltage, 0, 1)
                Me.tableContainer.Controls.Add(Me.txtVoltageRB, 1, 1)
                Me.tableContainer.Controls.Add(Me.txtVoltageSP, 2, 1)

                Me.tableContainer.Controls.Add(Me.lblCurrent, 0, 2)
                Me.tableContainer.Controls.Add(Me.txtCurrentRB, 1, 2)
                Me.tableContainer.Controls.Add(Me.txtCurrentSP, 2, 2)

                Me.tableContainer.Controls.Add(Me.lblPulse, 0, 3)
                Me.tableContainer.Controls.Add(Me.txtPulseRB, 1, 3)
                Me.tableContainer.Controls.Add(Me.txtPulseSP, 2, 3)

                Me.tableContainer.Controls.Add(Me.lblBiasForwardPower, 0, 4)
                Me.tableContainer.Controls.Add(Me.txtBiasForwardPowerRB, 1, 4)
                Me.tableContainer.Controls.Add(Me.txtBiasForwardPowerSP, 2, 4)

                Me.tableContainer.Controls.Add(Me.lblBiasReflectedPower, 0, 5)
                Me.tableContainer.Controls.Add(Me.txtBiasReflectedPowerRB, 1, 5)

                Me.tableContainer.Controls.Add(Me.lblMGInformation, 0, 6)
                Me.tableContainer.Controls.Add(Me.txtMGRB, 1, 6)

                Me.tableContainer.Controls.Add(Me.lblBAPressure, 0, 7)
                Me.tableContainer.Controls.Add(Me.txtBARB, 1, 7)

                Me.tableContainer.Controls.Add(Me.lblGas1, 0, 8)
                Me.tableContainer.Controls.Add(Me.txtGas1RB, 1, 8)
                Me.tableContainer.Controls.Add(Me.txtGas1SP, 2, 8)

                Me.tableContainer.Controls.Add(Me.lblGas2, 0, 9)
                Me.tableContainer.Controls.Add(Me.txtGas2RB, 1, 9)
                Me.tableContainer.Controls.Add(Me.txtGas2SP, 2, 9)

                Me.tableContainer.Controls.Add(Me.lblGas3, 0, 10)
                Me.tableContainer.Controls.Add(Me.txtGas3RB, 1, 10)
                Me.tableContainer.Controls.Add(Me.txtGas3SP, 2, 10)

                Me.tableContainer.Controls.Add(Me.lblGas4, 0, 11)
                Me.tableContainer.Controls.Add(Me.txtGas4RB, 1, 11)
                Me.tableContainer.Controls.Add(Me.txtGas4SP, 2, 11)

                Me.tableContainer.Controls.Add(Me.lblChuck, 0, 12)
                Me.tableContainer.Controls.Add(Me.txtChuckSP, 2, 12)
                Me.tableContainer.Controls.Add(Me.txtChuckRB, 1, 12)

                Me.tableContainer.Controls.Add(Me.lblMagnatron, 0, 13)
                Me.tableContainer.Controls.Add(Me.txtMagnatronRB, 1, 13)

                Me.tableContainer.Controls.Add(Me.lblClamp, 0, 14)
                Me.tableContainer.Controls.Add(Me.txtClampRB, 1, 14)
                Me.tableContainer.Height = 485
                Me.Height = 533
                Me.tableContainer.RowCount = 15
            Else
                ''RF
                Me.tableContainer.Controls.Add(Me.lblTargetForwardPower, 0, 0)
                Me.tableContainer.Controls.Add(Me.txtTargetForwardPowerRB, 1, 0)
                Me.tableContainer.Controls.Add(Me.txtTargetForwardPowerSP, 2, 0)

                Me.tableContainer.Controls.Add(Me.lblTargetReflectivePower, 0, 1)
                Me.tableContainer.Controls.Add(Me.txtTargetReflectivePowerRB, 1, 1)
                Me.tableContainer.Controls.Add(Me.txtTargetReflectivePowerSP, 2, 1)

                Me.tableContainer.Controls.Add(Me.lblTargetReflectiveVoltage, 0, 2)
                Me.tableContainer.Controls.Add(Me.txtTargetReflectiveVoltageRB, 1, 2)
                Me.tableContainer.Controls.Add(Me.txtTargetReflectiveVoltageSP, 2, 2)

                Me.tableContainer.Controls.Add(Me.lblBiasForwardPower, 0, 3)
                Me.tableContainer.Controls.Add(Me.txtBiasForwardPowerRB, 1, 3)
                Me.tableContainer.Controls.Add(Me.txtBiasForwardPowerSP, 2, 3)

                Me.tableContainer.Controls.Add(Me.lblBiasReflectedPower, 0, 4)
                Me.tableContainer.Controls.Add(Me.txtBiasReflectedPowerRB, 1, 4)

                Me.tableContainer.Controls.Add(Me.lblMGInformation, 0, 5)
                Me.tableContainer.Controls.Add(Me.txtMGRB, 1, 5)

                Me.tableContainer.Controls.Add(Me.lblBAPressure, 0, 6)
                Me.tableContainer.Controls.Add(Me.txtBARB, 1, 6)

                Me.tableContainer.Controls.Add(Me.lblGas1, 0, 7)
                Me.tableContainer.Controls.Add(Me.txtGas1RB, 1, 7)
                Me.tableContainer.Controls.Add(Me.txtGas1SP, 2, 7)

                Me.tableContainer.Controls.Add(Me.lblGas2, 0, 8)
                Me.tableContainer.Controls.Add(Me.txtGas2RB, 1, 8)
                Me.tableContainer.Controls.Add(Me.txtGas2SP, 2, 8)

                Me.tableContainer.Controls.Add(Me.lblGas3, 0, 9)
                Me.tableContainer.Controls.Add(Me.txtGas3RB, 1, 9)
                Me.tableContainer.Controls.Add(Me.txtGas3SP, 2, 9)

                Me.tableContainer.Controls.Add(Me.lblGas4, 0, 10)
                Me.tableContainer.Controls.Add(Me.txtGas4RB, 1, 10)
                Me.tableContainer.Controls.Add(Me.txtGas4SP, 2, 10)

                Me.tableContainer.Controls.Add(Me.lblChuck, 0, 11)
                Me.tableContainer.Controls.Add(Me.txtChuckSP, 2, 11)
                Me.tableContainer.Controls.Add(Me.txtChuckRB, 1, 11)

                Me.tableContainer.Controls.Add(Me.lblClamp, 0, 12)
                Me.tableContainer.Controls.Add(Me.txtClampRB, 1, 12)
                Me.tableContainer.Height = 418
                Me.Height = 469
                Me.tableContainer.RowCount = 13
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

End Class