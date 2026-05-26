Imports AVPLib.DataManagerment
Imports System.Threading
Imports AVPSecsGemLib
Imports AVPLib
Imports AVPLib.Business.AVPSecsGemLib
Imports EMSERVICELib
Imports AVPControls

Public Class PopUp_TerminalMessage

    Private Sub txtMessageToHost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMessageToHost.Click
        If AVPLib.ContainerData.UserLogin Is Nothing Then
            Exit Sub
        End If
        Dim pad As New KeyPad
        Dim Value As String = String.Empty
        pad.TopMost = True
        If pad.DisplayKeypad(Value, "Message To Host", False) = Windows.Forms.DialogResult.OK Then
            SecsGem_EventHandler.SendTerminalMessage(Value)
            txtMessageFromHost.Text &= "->: " & Value & Environment.NewLine
            txtMessageFromHost.SelectionStart = txtMessageFromHost.TextLength
            txtMessageFromHost.ScrollToCaret()
            '
            With ContainerForm.Secs_GemPanel
                .txtMessageFromHost.Text &= "->: " & Value & Environment.NewLine
                .txtMessageFromHost.SelectionStart = txtMessageFromHost.TextLength
                .txtMessageFromHost.ScrollToCaret()
            End With


        End If
    End Sub

    Protected Overrides Sub DoClose()
        Me.Hide()
        '0004813: [KhoiHa - 03/25/2014][GEM] Missing S6F1 traces!
        ' Enable all forms
        EnableFormsAfterClosing()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.Text = "SECS/GEM Terminal Message"
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub PopUp_TerminalMessage_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub

    '''' <author>
    ''''    	<name> Vy Nguyen </name>
    ''''    	<date> 03-28-2014 </date>
    '''' </author>
    '''' <summary>
    '''' Only Used for AVP Secs Gem, 
    '''' <remarks></remarks>
    Private Sub EnableFormsAfterClosing()
        ' Enabled all forms
        ' SECS/GEM
        ContainerForm.Secs_GemPanel.CheckPermission()

        ' Main button
        AVPRobotMain.btnProcess.Enabled = True
        AVPRobotMain.btnEditor.Enabled = True
        AVPRobotMain.btnMaintenance.Enabled = True
        AVPRobotMain.btnSetup.Enabled = True
        AVPRobotMain.btnDataLog.Enabled = True

        'Process Panel
        With ContainerForm.ProcessPanel
            .Enabled = True
            .RobotHand.Enabled = True
            .Refresh()
        End With

        ' Alarm
        AVPRobotMain.aplAlarm.Enabled = True

        ' PM Connection status
        AVPRobotMain.pnlPMConnection.Enabled = True

        ' Login/Host Status
        AVPRobotMain.AVPLoginPanel.Enabled = True
        AVPRobotMain.AVPCommunicationPanel.Enabled = True

        ' All tabs in maintenace
        AVPRobotMain.tabMain.Enabled = True
        AVPRobotMain.tabMain.Refresh()
        AVPRobotMain.tabSetup.Enabled = True
        AVPRobotMain.tabDataLog.Enabled = True
        AVPRobotMain.tabEditor.Enabled = True
    End Sub
End Class