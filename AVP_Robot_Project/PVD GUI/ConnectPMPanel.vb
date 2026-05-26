Imports AVP_Robot_Project.ConstantAndEnum
Imports AVP_Robot_Project.PVDSupport
Imports AVPLib
Imports AVPLib.ConstEnum

Public Class ConnectPMPanel
#Region "Properties"
    Private m_blnPM1Visible As Boolean = False
    Private m_blnPM2Visible As Boolean = False
    Private m_blnPM3Visible As Boolean = False

    Public Property PM1Visible() As Boolean
        Get
            Return m_blnPM1Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnPM1Visible = value
            lblPM1.Visible = m_blnPM1Visible
            btnConnectPM1.Visible = m_blnPM1Visible
            ArrangePosition()
        End Set
    End Property

    Public Property PM2Visible() As Boolean
        Get
            Return m_blnPM2Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnPM2Visible = value
            lblPM2.Visible = m_blnPM2Visible
            btnConnectPM2.Visible = m_blnPM2Visible
            ArrangePosition()
        End Set
    End Property

    Public Property PM3Visible() As Boolean
        Get
            Return m_blnPM3Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnPM3Visible = value
            lblPM3.Visible = m_blnPM3Visible
            btnConnectPM3.Visible = m_blnPM3Visible
            ArrangePosition()
        End Set
    End Property
    
#End Region

#Region "Protected method"
#End Region

#Region "Events – Buttons – Forms…"
    Private Sub Connect(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
       Me.Click, PMFlowLayoutPnl.Click, btnConnectPM1.Click, btnConnectPM2.Click, btnConnectPM3.Click, _
        lblPM1.Click, lblPM2.Click, lblPM3.Click

        Dim strchamber As String = String.Empty
        If PM1Visible AndAlso btnConnectPM1.Status = DisplayStatus.Off Then
            strchamber &= IIf(String.IsNullOrEmpty(strchamber), _
                             AVPLib.Utils.chamberID2ChamberName(Equipments.Chamber1.ToString()), _
                             "," & AVPLib.Utils.chamberID2ChamberName(AVPLib.ConstEnum.Equipments.Chamber1.ToString()))
        End If
        If PM2Visible AndAlso btnConnectPM2.Status = DisplayStatus.Off Then
            strchamber &= IIf(String.IsNullOrEmpty(strchamber), _
                             AVPLib.Utils.chamberID2ChamberName(Equipments.Chamber2.ToString()), _
                             "," & AVPLib.Utils.chamberID2ChamberName(Equipments.Chamber2.ToString()))
        End If
        If PM3Visible AndAlso btnConnectPM3.Status = DisplayStatus.Off Then
            strchamber &= IIf(String.IsNullOrEmpty(strchamber), _
                             AVPLib.Utils.chamberID2ChamberName(Equipments.Chamber3.ToString()), _
                             "," & AVPLib.Utils.chamberID2ChamberName(Equipments.Chamber3.ToString()))
        End If
        If String.IsNullOrEmpty(strchamber) Then
            Exit Sub
        End If
        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                              AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                              "[Main Screen] " + "Connect all PM")
        If (Utils.ShowAVPMessageBox("Do you want to connect to " & strchamber & " ?", "PM Reconnect", _
                                    MessageBoxIcon.Question) = DialogResult.OK) Then
            If PM1Visible Then
                ContainerForm.Chamber1Panel.btnReConnect_Click(sender, e)
            End If
            If PM2Visible Then
                ContainerForm.Chamber2Panel.btnReConnect_Click(sender, e)
            End If
            If PM3Visible Then
                ContainerForm.Chamber3Panel.btnReConnect_Click(sender, e)
            End If

            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                              AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                              "[Main Screen] " + "Connect all PM")
        End If
    End Sub
#End Region

#Region "Function"

#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-02 </date>
    ''' </author>
    ''' <summary>
    ''' Arrange position PM
    ''' </summary>
    Private Sub ArrangePosition()
        Dim distance As Integer = 9
        Dim startPoint As Point = New Point(3, 1)
        Dim count As Integer = 0

        If m_blnPM1Visible Then
            btnConnectPM1.Location = startPoint
            startPoint.X += btnConnectPM1.Width + 3
            lblPM1.Location = startPoint
            startPoint.X += lblPM1.Width + distance
            count += 1
        End If

        If m_blnPM2Visible Then
            btnConnectPM2.Location = startPoint
            startPoint.X += btnConnectPM2.Width + 3
            lblPM2.Location = startPoint
            startPoint.X += lblPM2.Width + distance
            count += 1
        End If

        If m_blnPM3Visible Then
            btnConnectPM3.Location = startPoint
            startPoint.X += btnConnectPM3.Width + 3
            lblPM3.Location = startPoint
            startPoint.X += lblPM3.Width + distance
            count += 1

            If count = 3 Then
                startPoint = New Point(3, 17)
            End If
        End If
    End Sub
End Class
