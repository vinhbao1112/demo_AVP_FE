Imports AVP_Robot_Project.ConstantAndEnum
Public Class SemiautoTranferWaferControl
    Private m_isDest_Aligner As Boolean = False

#Region "Protected method"
    Public Property Dest_Is_Aligner() As Boolean
        Get
            Return m_isDest_Aligner
        End Get
        Set(ByVal value As Boolean)
            m_isDest_Aligner = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbStatus As New StatusTextBox(txtStatus)
            Dim stbRecipe As New StatusTextBox(txtRecipe)
            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbStatus)
            m_stoStatusObject.AddChild(stbRecipe)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events � Buttons � Forms�"
    Private Sub Arrange_Control_Run_With_AlignerRecipe(ByVal blnRunWithRecipe As Boolean)
        chkUseAligner.Checked = blnRunWithRecipe
        If blnRunWithRecipe Then
            btnClear.Top = 120
            btnStart.Top = 120
            chkUseAligner.Visible = True
            txtRecipe.Visible = True
            lblRecipe.Visible = True
        Else
            btnClear.Top = txtRecipe.Top + 10
            btnStart.Top = txtRecipe.Top + 10
            chkUseAligner.Visible = False
            txtRecipe.Visible = False
            lblRecipe.Visible = False
        End If
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle event that user click on Start
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub btnStart_Click()
        AVPLib.Log.guiLogger.Info("Enter btnStart_Click")
        Dim strMessageText As String = String.Empty
        Try
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Main Screen] Start Semi Auto Transfer")
            Me.txtStatus.Clear()
            Dim strSrc As String = String.Empty
            If (txtSource.Text.Contains(",")) Then
                Dim arrSourceParam As String() = txtSource.Text.Split(",")
                If (arrSourceParam.Length = 2) Then
                    strSrc = AVPLib.Utils.chamberName2ChamberID(arrSourceParam(0)) & "," & arrSourceParam(1)
                End If
            Else
                strSrc = AVPLib.Utils.chamberName2ChamberID(txtSource.Text)
            End If
            strSrc = strSrc.Replace(" ", "") ' Remove blank space.

            Dim strDest As String = String.Empty
            If (txtDestination.Text.Contains(",")) Then
                Dim arrDesParam As String() = txtDestination.Text.Split(",")
                If (arrDesParam.Length = 2) Then
                    strDest = AVPLib.Utils.chamberName2ChamberID(arrDesParam(0)) & "," & arrDesParam(1)
                End If
            Else
                strDest = AVPLib.Utils.chamberName2ChamberID(txtDestination.Text)
            End If
            strDest = strDest.Replace(" ", "") ' Remove blank space.

            'dat cao
            'check aligner is current in use
            If (strSrc.Contains(ConstantAndEnum.ALIGN.ToString())) Then
                'do nothing
            Else
                If (Utils.isAlignerInUse()) Then
                    'if source is LOADLOCK 
                    If (strSrc.Contains(ConstantAndEnum.LOAD_LOCK_A.ToString()) AndAlso _
                    AVPLib.RobotConfigurationValues.ALIGNER_AT_STATION = AVPLib.RobotConfigurationValues.LLA_STATION_NO) Then
                        Utils.ShowAVPMessageBox("Can not move, Had wafer at Aligner", "Transfer Wafer", MessageBoxIcon.Error, MessageBoxButtons.OK)
                        txtSource.Text = String.Empty
                        txtDestination.Text = String.Empty
                        Exit Sub
                    ElseIf (strDest.Contains(ConstantAndEnum.LOAD_LOCK_A.ToString()) AndAlso _
                    AVPLib.RobotConfigurationValues.ALIGNER_AT_STATION = AVPLib.RobotConfigurationValues.LLA_STATION_NO) Then
                        Utils.ShowAVPMessageBox("Can not move, Had wafer at Aligner", "Transfer Wafer", MessageBoxIcon.Error, MessageBoxButtons.OK)
                        txtSource.Text = String.Empty
                        txtDestination.Text = String.Empty
                        Exit Sub
                    End If
                End If
            End If

            'KHOI HA 22-04-2013
            'Load/Unload button should be disable when user tranfer wafer from Llx to Pmx.   Sometime load/unload button is still available
            If (strSrc.Contains(ConstantAndEnum.LOAD_LOCK_A.ToString) OrElse strDest.Contains(ConstantAndEnum.LOAD_LOCK_A.ToString)) Then
                If ContainerForm.ProcessPanel.lpcLoadLockA.btnStart.Text = "START" Then
                    ContainerForm.ProcessPanel.lpcLoadLockA.btnStart.Enabled = False
                    ContainerForm.ProcessPanel.lpcLoadLockA.btnLoad.Enabled = False
                    ContainerForm.ProcessPanel.lpcLoadLockA.btnUnload.Enabled = False
                End If
            End If

            Dim strValue As String = _
                  strSrc + "," + _
                  strDest + "," + _
                  AVPLib.ConstEnum.USEALIGNER + chkUseAligner.Checked.ToString() + _
                  IIf(chkUseAligner.Checked, "," + txtRecipe.Text, String.Empty)
            m_stoStatusObject.RequestStatus(btnStart.Name, strValue)
            'AVPLib.Utils.ShowStatusMessage("Start Transfer Wafer from:" & txtSource.Text & " to: " & txtDestination.Text)
            Me.btnStart.Enabled = False
            Me.btnClear.Enabled = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnStart_Click")
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        AVPLib.Log.guiLogger.Info("Enter btnClear_Click")
        Dim strMessageText As String = String.Empty
        Try
            Me.txtDestination.Text = String.Empty
            Me.txtSource.Text = String.Empty
            Me.txtStatus.Text = String.Empty
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnClear_Click")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-22</date>
    ''' </author>
    ''' <summary>
    ''' txtStatus_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtStatus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStatus.TextChanged
        AVPLib.Log.guiLogger.Info("Enter txtStatus_TextChanged")
        Try
            'If (txtStatus.Text IsNot String.Empty) Then
            Me.btnStart.Enabled = True
            Me.btnClear.Enabled = True
            If Me.txtStatus.Text.Length > 0 Then
                Me.txtDestination.Clear()
                Me.txtSource.Clear()
                'Utils.ShowAVPMessageBox(txtStatus.Text, "Transfer Wafer", MessageBoxIcon.Information, MessageBoxButtons.OK)
                'txtStatus.Text = String.Empty
            End If
            'End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txtStatus_TextChanged")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-07-24</date>
    ''' </author>
    ''' <summary>
    ''' txtRecipe_Click
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub txtRecipe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecipe.Click
        AVPLib.Log.guiLogger.Info("Enter txtRecipe_Click")
        Try
            Dim frm As SelectRecipe = New SelectRecipe()
            frm.SelectedRecipe = Nothing
            frm.StationName = AVPLib.ConstEnum.Equipments.Aligner.ToString()
            frm.ShowDialog()
            If frm.DialogResult = DialogResult.OK Then
                Me.txtRecipe.Text = frm.SelectedRecipe
            End If
            frm.Dispose()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txtRecipe_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-07-24</date>
    ''' </author>
    ''' <summary>
    ''' chkUseAligner_CheckedChanged
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub chkUseAligner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseAligner.CheckedChanged
        AVPLib.Log.guiLogger.Info("Enter chkUseAligner_CheckedChanged")
        If Me.chkUseAligner.Checked Then
            Arrange_Control_Run_With_AlignerRecipe(True)
            If String.IsNullOrEmpty(txtRecipe.Text) Then
                Dim frm As SelectRecipe = New SelectRecipe()
                frm.SelectedRecipe = Nothing
                frm.StationName = AVPLib.ConstEnum.Equipments.Aligner.ToString()
                frm.ShowDialog()
                If frm.DialogResult = DialogResult.OK Then
                    txtRecipe.Text = frm.SelectedRecipe
                End If
                frm.Dispose()
            End If
        Else
            Arrange_Control_Run_With_AlignerRecipe(False)
        End If
        AVPLib.Log.guiLogger.Info("Leave chkUseAligner_CheckedChanged")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-07-24</date>
    ''' </author>
    ''' <summary>
    ''' SemiautoTranferWaferControl_Load
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub SemiautoTranferWaferControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Arrange_Control_Run_With_AlignerRecipe(False)
    End Sub
#End Region


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub txtSource_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSource.TextChanged
        'If String.IsNullOrEmpty(txtSource.Text) AndAlso String.IsNullOrEmpty(txtDestination.Text) Then
        '    ContainerForm.CassettesPanel.btnCancelMove.Enabled = False
        '    'ContainerForm.CassettesPanel.btnCancelMove.Status = SL_CustomButton.DisplayStatus.Off
        'End If
        If (Not String.IsNullOrEmpty(txtSource.Text)) Or (Not String.IsNullOrEmpty(txtDestination.Text)) Then
            ContainerForm.CassettesPanel.btnCancelMove.Enabled = True
            'ContainerForm.CassettesPanel.btnCancelMove.Status = SL_CustomButton.DisplayStatus.On
        End If
    End Sub

    Private Sub txtDestination_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDestination.TextChanged
        'If String.IsNullOrEmpty(txtSource.Text) AndAlso String.IsNullOrEmpty(txtDestination.Text) Then
        '    ContainerForm.CassettesPanel.btnCancelMove.Enabled = False
        '    'ContainerForm.CassettesPanel.btnCancelMove.Status = SL_CustomButton.DisplayStatus.Off
        'End If
        If (Not String.IsNullOrEmpty(txtSource.Text)) Or (Not String.IsNullOrEmpty(txtDestination.Text)) Then
            ContainerForm.CassettesPanel.btnCancelMove.Enabled = True
            'ContainerForm.CassettesPanel.btnCancelMove.Status = SL_CustomButton.DisplayStatus.On
        End If
    End Sub
End Class
