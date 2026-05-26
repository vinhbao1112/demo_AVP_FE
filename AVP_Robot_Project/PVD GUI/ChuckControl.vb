Imports AVP_Robot_Project.ConstantAndEnum
Public Class ChuckControl

#Region "Properties & Constant"
    Private m_firtLoad As Boolean = False
    Private m_stShutterStatus As BinaryStatusControl.DisplayStatus
    Public Property ShutterStatus() As BinaryStatusControl.DisplayStatus
        Get
            Return m_stShutterStatus
        End Get
        Set(ByVal value As BinaryStatusControl.DisplayStatus)
            m_stShutterStatus = value
            imbstMainChuck.Status = m_stShutterStatus
            If m_stShutterStatus = BinaryStatusControl.DisplayStatus.Off Then
                Me.btnShutter.Visible = False
                Me.btnShutter.Enabled = False
            Else
                Me.btnShutter.Visible = True
                Me.btnShutter.Enabled = True
            End If
        End Set
    End Property
    Private m_blnClampInstall As Boolean = False
    Public Property ClampInstall() As Boolean
        Get
            Return m_blnClampInstall
        End Get
        Set(ByVal value As Boolean)
            m_blnClampInstall = value
            If m_blnClampInstall Then
                ' m_blnIsClampOn = False
                Me.btnClamp.Visible = True
                Me.imbstMainChuck.TextValue = UNCLAMP
                Me.imbstMainChuck.TextLocation = New Point(75, 160)
            Else
                Me.imbstMainChuck.TextValue = String.Empty
                Me.btnClamp.Visible = False
                Me.imbstMainChuck.Refresh()
            End If
        End Set
    End Property

#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2009-12-15</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbPos1 As New StatusTextBox(Me.txtPos1)
            Dim stbPos2 As New StatusTextBox(Me.txtPos2)
            Dim sbcShutter As New StatusIGCGButton(Me.btnShutter)
            Dim sbcWaferInside As New StatusIGCGButton(Me.bicWaferInside)

            Dim sbcValveTar As New StatusIGCGButton(Me.ValveTar)
            Dim sbcSlitVal As New StatusIGCGButton(Me.ValveSlit)
            Dim sbcClampStatus As New StatusIGCGButton(Me.btnClamp)
            Dim sbcPlasmaStatus As New StatusIGCGButton(Me.bicPlasmaOn)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbPos1)
            m_stoStatusObject.AddChild(stbPos2)
            m_stoStatusObject.AddChild(sbcShutter)
            m_stoStatusObject.AddChild(sbcWaferInside)

            m_stoStatusObject.AddChild(sbcValveTar)
            m_stoStatusObject.AddChild(sbcSlitVal)
            m_stoStatusObject.AddChild(sbcClampStatus)
            m_stoStatusObject.AddChild(sbcPlasmaStatus)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
  ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub StartProcessing() ''reset editbox to empty
        Me.txtPos2.Text = String.Empty
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtPos1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                               Handles txtPos2.Click
        Dim strChamberName As String = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
        Dim blnSplitValveClosed As Boolean = True
        Select Case Parent.Name
#If AVP_CX_STYLE = "CX5" Then
            Case AVPLib.ConstEnum.Equipments.Chamber1.ToString()
                If ContainerForm.CassettesPanel.MesaValvePM1.Status <>  BinaryStatusControl.DisplayStatus.Off Then
                    blnSplitValveClosed = False
                End If
            Case AVPLib.ConstEnum.Equipments.Chamber2.ToString()
                If ContainerForm.CassettesPanel.MesaValvePM2.Status <>  BinaryStatusControl.DisplayStatus.Off Then
                    blnSplitValveClosed = False
                End If
            Case AVPLib.ConstEnum.Equipments.Chamber3.ToString()
                If ContainerForm.CassettesPanel.MesaValvePM3.Status <>  BinaryStatusControl.DisplayStatus.Off Then
                    blnSplitValveClosed = False
                End If
#ElseIf AVP_CX_STYLE = "CX4" Then
            'AVPLib.Log.avpLogger.Error("Missing Missing Control CHUCK For CX4")  
#Else
            'Case AVPLib.ConstEnum.Equipments.Chamber4.ToString()
            '    If ContainerForm.CassettesPanel.MesaValvePM4.Status <> BinaryStatusControl.DisplayStatus.Off Then
            '        blnSplitValveClosed = False
            '    End If
            'Case AVPLib.ConstEnum.Equipments.Chamber5.ToString()
            '    If ContainerForm.CassettesPanel.MesaValvePM5.Status <> BinaryStatusControl.DisplayStatus.Off Then 
            '        blnSplitValveClosed = False
            '    End If
#End If
        End Select
        If blnSplitValveClosed = False Then
            Utils.ShowAVPMessageBox("Slit Valve of " & strChamberName & " is not closed", strChamberName, _
                                    MessageBoxIcon.Information, MessageBoxButtons.OK)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                              AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                              "[Main Screen] " + "Slit Valve of " & strChamberName & " is not closed")
            Exit Sub
        End If
        PVDSupport.TextboxClick(sender, e, Me.Parent, m_stoStatusObject)
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnShutter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                       Handles btnShutter.Click
        AVPLib.Log.guiLogger.Info("Enter btnShutter_Click")
        Dim strMessageText As String = String.Empty
        Dim strValue As String = String.Empty
        Dim button As ButtonIGCGControl = CType(sender, ButtonIGCGControl)
        Dim strChamberName As String = String.Empty
        Dim strLogMessage As String = String.Empty
        Dim dlgRes As DialogResult
        Try
            If CType(sender, ButtonIGCGControl).Status = DisplayStatus.On Then
                strLogMessage = "Close Shutter"
            ElseIf CType(sender, ButtonIGCGControl).Status = DisplayStatus.Off Then
                strLogMessage = "Open Shutter"
            End If
            PVDSupport.ReadMessageText(sender, Me, strMessageText)
            strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)

            Dim strSourceLogMessage As String = String.Empty

            strSourceLogMessage = "[" + strChamberName + "]"

            If button.Status = DisplayStatus.Unknow Then
                dlgRes = Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Information, AVPMessageBox.AVPMessageBoxButton.OpenCloseCancel) ' MessageBoxButtons.YesNoCancel)
                If dlgRes = DialogResult.Cancel Then
                    Exit Try
                ElseIf dlgRes = DialogResult.OK Then ''Open
                    GoTo SendOpenShutterCmd
                ElseIf dlgRes = DialogResult.No Then 'Close
                    GoTo SendCloseShutterCmd
                End If
            ElseIf button.Status = DisplayStatus.Off Then
                If Utils.ShowAVPMessageBox("Are you sure you want to Open Shutter? ", strChamberName, _
                                            MessageBoxIcon.Warning, MessageBoxButtons.YesNo) = DialogResult.OK Then
                    GoTo SendOpenShutterCmd
                End If
                Exit Try
            ElseIf button.Status = DisplayStatus.On Then
                If Utils.ShowAVPMessageBox("Are you sure you want to Close Shutter? ", strChamberName, _
                                            MessageBoxIcon.Warning, MessageBoxButtons.YesNo) = DialogResult.OK Then
                    GoTo SendCloseShutterCmd
                End If
                Exit Try
            End If

SendCloseShutterCmd:
            m_stoStatusObject.RequestStatus(button.Name, AVPLib.ConstEnum.STR_OFF)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                               AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                               strSourceLogMessage + " " + strLogMessage)
            Exit Try

SendOpenShutterCmd:
            m_stoStatusObject.RequestStatus(button.Name, AVPLib.ConstEnum.STR_ON)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                               AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                               strSourceLogMessage + " " + strLogMessage)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnShutter_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAutoZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        PVDSupport.CommonButtonClick("Auto Zero", sender, Me.Parent, m_stoStatusObject)
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClamp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClamp.Click
        Dim strClamp As String = String.Empty
        If btnClamp.Status = DisplayStatus.On Then
            strClamp = UNCLAMP
        ElseIf btnClamp.Status = DisplayStatus.Off Then
            strClamp = CLAMP
        End If
        PVDSupport.CommonButtonClick(strClamp, sender, Me.Parent, m_stoStatusObject)
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClamp_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClamp.StatusChange, btnClamp.TextChanged
        If Not (ClampInstall) Then
            Exit Sub
        End If
        If btnClamp.Status = DisplayStatus.On Then
            Me.imbstMainChuck.TextValue = CLAMP
            Me.imbstMainChuck.TextLocation = New Point(85, 160)
        Else
            Me.imbstMainChuck.TextValue = UNCLAMP
            Me.imbstMainChuck.TextLocation = New Point(75, 160)
        End If
        Me.imbstMainChuck.Refresh()
    End Sub

    Private Sub bicPlasmaOn_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles bicPlasmaOn.StatusChange
        Try
            'If Not (m_firtLoad) Then
            '   m_firtLoad = True
            '  Exit Sub
            'End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
  
End Class
