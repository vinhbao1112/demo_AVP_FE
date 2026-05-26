Imports AVPLib.DataManagerment

Public Class CORONA_TableControl

    Private m_blnIsOnline As Boolean = False
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            btnHOME.Enabled = Not (m_blnIsOnline)
            CheckMotion()
        End Set
    End Property

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-04-05</date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private m_blnIsWaferInstalled As Boolean = False
    Public Property IsWaferLiftInstalled() As Boolean
        Get
            Return m_blnIsWaferInstalled
        End Get
        Set(ByVal value As Boolean)
            m_blnIsWaferInstalled = value
            If False = m_blnIsWaferInstalled Then
                btnLiftUp.Visible = False
                btnLiftDown.Visible = False
                btnHOME.Size = New Size(177, 41)
                btnHOME.Location = New Point(27, 41)
                lblAllAxisHome.Location = New Point(36, 89)
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2018-12-28</date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private m_SupportTSDMode As Boolean = False
    Public Property SupportTSDMode() As Boolean
        Get
            Return m_SupportTSDMode
        End Get
        Set(ByVal value As Boolean)
            m_SupportTSDMode = value
            If m_SupportTSDMode Then
                txtTablePosRight.Size = New System.Drawing.Size(83, 24)
                txtTablePosRight.UseBackGroundWorkerToUpdateMinMax = True
                lblTSD.Visible = True
            Else
                lblTSD.Visible = False
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2019-01-08</date>
    ''' </author>
    ''' <summary>
    ''' Gets or Sets TargetToHomeDistance
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private m_TargetToHomeDistance As Double = 0
    Public Property TargetToHomeDistance() As Double
        Get
            Return m_TargetToHomeDistance
        End Get
        Set(ByVal value As Double)
            m_TargetToHomeDistance = value          
        End Set
    End Property

    Public Sub CheckMotion()
        btnHomeTable.Enabled = Not (btnHOME.Status = SL_CustomButton.DisplayStatus.Unknow) And Not (m_blnIsOnline)
        btnRotate.Enabled = Not (btnHOME.Status = SL_CustomButton.DisplayStatus.Unknow) And Not (m_blnIsOnline)
        cbxGoTo.Enabled = Not (btnHOME.Status = SL_CustomButton.DisplayStatus.Unknow) And Not (m_blnIsOnline)
        txtRotateRight.Enabled = Not (btnHOME.Status = SL_CustomButton.DisplayStatus.Unknow) And Not (m_blnIsOnline)
        btnLiftUp.Enabled = Not (btnHOME.Status = SL_CustomButton.DisplayStatus.Unknow) And Not (m_blnIsOnline)
        btnLiftDown.Enabled = Not (btnHOME.Status = SL_CustomButton.DisplayStatus.Unknow) And Not (m_blnIsOnline)
        txtTablePosRight.Enabled = Not (btnHOME.Status = SL_CustomButton.DisplayStatus.Unknow) And Not (m_blnIsOnline)
    End Sub

    Public WriteOnly Property NumberOfWafer() As Int16
        Set(ByVal value As Int16)
            Dim numberSlot As Byte = value
            Dim i As Byte = 1
            Dim Wafer_Station As String = "Slot "
            cbxGoTo.Items.Add(Wafer_Station & i.ToString() & "(Home)")
            For i = 2 To numberSlot
                cbxGoTo.Items.Add(Wafer_Station & i.ToString())
            Next
            cbxGoTo.SelectedIndex = 0
        End Set
    End Property

    'Private Sub txtGotoSlot_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGotoSlot.TextChanged
    '    Try
    '        If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
    '            cbxGoTo.SelectedIndex = Convert.ToInt32(txtGotoSlot.Text) - 1
    '        End If
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    'End Sub

    Private Sub btnRotate_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotate.StatusChange
        If DesignMode Then
            Exit Sub
        End If
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If btnRotate.Status = SL_CustomButton.DisplayStatus.On Then
                    btnRotate.Text = "Stop Rotating"
                Else
                    btnRotate.Text = "Rotate Cont."
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnLiftUp_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiftUp.StatusChange
        If DesignMode Then
            Exit Sub
        End If
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                Dim objCoronaPanel As CoronaPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                If objCoronaPanel IsNot Nothing Then
                    If btnLiftUp.Status = SL_CustomButton.DisplayStatus.On Then
                        btnLiftDown.Status = SL_CustomButton.DisplayStatus.Off
                        'objCoronaPanel.CoronaChamber.IsTableUp = True
                    ElseIf btnLiftUp.Status = SL_CustomButton.DisplayStatus.Off Then
                        btnLiftDown.Status = SL_CustomButton.DisplayStatus.On
                        'objCoronaPanel.CoronaChamber.IsTableUp = False
                    ElseIf btnLiftUp.Status = SL_CustomButton.DisplayStatus.Unknow Then
                        btnLiftDown.Status = SL_CustomButton.DisplayStatus.Unknow
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtGotoSlot_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGotoSlot.TextChanged
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If Not txtGotoSlot.Text.Contains("Slot") AndAlso Not txtGotoSlot.Text.Contains(ConstantAndEnum.UNKNOWN) _
                   AndAlso Not txtGotoSlot.Text.Contains("Rotating") Then
                    txtGotoSlot.Text = "Slot " & txtGotoSlot.Text
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtTablePos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTablePos.TextChanged
        Try
            Dim pos As Single
            If txtTablePos.Text <> String.Empty AndAlso Not txtTablePos.Text.Contains("mm") AndAlso Not txtTablePos.Text.Contains(ConstantAndEnum.UNKNOWN) _
               AndAlso Not txtTablePos.Text.Contains("Moving") AndAlso Single.TryParse(txtTablePos.Text, pos) Then
                If (Not SupportTSDMode AndAlso pos = 0) Or (SupportTSDMode AndAlso pos = TargetToHomeDistance) Then
                    txtTablePos.Text = txtTablePos.Text & " mm (Home)"
                Else
                    txtTablePos.Text = txtTablePos.Text & " mm"
                End If
                If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                    Dim objPanel As CoronaPanel = ContainerForm.ChamberPanel(Me.Parent.Name)

                    If objPanel IsNot Nothing Then
                        objPanel.CoronaChamber.TableCurrentPosition = AdjustPositionTable(pos)
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2019-01-08</date>
    ''' </author>
    ''' <summary>
    ''' Adjust Position Table
    ''' </summary> 
    Private Function AdjustPositionTable(ByVal positionTable As Single) As Single
        Dim position As Single = positionTable

        Try
            If SupportTSDMode AndAlso TargetToHomeDistance <> 0 Then
                'TargetToHomeDistance - position -> raw value
                'ConstantAndEnum.TABLE_MAX_HEIGHT / TargetToHomeDistance -> ratio between table max height and Home
                position = (TargetToHomeDistance - position) * (ConstantAndEnum.TABLE_MAX_HEIGHT / TargetToHomeDistance)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return position
    End Function

    Private Sub txtRotate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRotate.TextChanged
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                Dim objCoronaPanel As CoronaPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                Dim objCoronaChamber As AVPLib.DataManagerment.CoronaChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(objCoronaPanel.Name)
                If objCoronaChamber IsNot Nothing AndAlso Not txtRotate.Text.Contains(ConstantAndEnum.UNKNOWN) Then
                    If objCoronaChamber.Substrate_Table_Rotate_Home = Equipment.WorkingStatuses.On Then
                        txtRotate.Text = "Home"
                    Else
                        If txtRotate.Text <> String.Empty AndAlso Not txtRotate.Text.Contains("rpm") Then
                            txtRotate.Text = txtRotate.Text & " rpm"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnHOME_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHOME.StatusChange
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                Dim objCoronaChamber As AVPLib.DataManagerment.CoronaChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Name)
                If objCoronaChamber IsNot Nothing Then
                    If objCoronaChamber.Initialized_Motion = Equipment.WorkingStatuses.On Then
                        lblAllAxisHome.Visible = True
                    Else
                        lblAllAxisHome.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnHomeTable_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHomeTable.StatusChange
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                Dim objCoronaPanel As CoronaPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                Dim objCoronaChamber As AVPLib.DataManagerment.CoronaChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(objCoronaPanel.Name)
                If objCoronaChamber IsNot Nothing Then

                    If objCoronaChamber.Substrate_Table_Lift_Home = Equipment.WorkingStatuses.On Then
                        If Not objCoronaPanel.CoronaChamber.IsTableHome Then
                            objCoronaPanel.CoronaChamber.IsTableHome = True

                        End If
                    ElseIf objCoronaChamber.Substrate_Table_Lift_Home <> Equipment.WorkingStatuses.On Then
                        If objCoronaPanel.CoronaChamber.IsTableHome Then
                            objCoronaPanel.CoronaChamber.IsTableHome = False
                            
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub cbxGoTo_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxGoTo.DropDownClosed
        Try
            Dim chamberName As String = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
            Dim Source As String = AVPLib.ConstEnum.PVD4 & "." & cbxGoTo.Parent.Name & "." & cbxGoTo.Name
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)
            strMessageText = String.Format(strMessageText, cbxGoTo.Text)
            If cbxGoTo.Text = String.Empty Then
                Utils.ShowAVPMessageBox(strMessageText, chamberName, MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
            End If

            If Utils.ShowAVPMessageBox(strMessageText, chamberName, MessageBoxIcon.Information, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then
                Utils.LogUserEvent(sender)
                Dim SlotNumber As Byte = cbxGoTo.FindStringExact(cbxGoTo.Text)
                m_stoStatusObject.RequestStatus(cbxGoTo.AccessibleName, (SlotNumber + 1).ToString)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-01 </date>
    ''' </author>
    ''' <summary>
    ''' Update table rotate position
    ''' </summary>
    Private Sub txtSubstrateTableRotatePosition_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubstrateTableRotatePosition.TextChanged
        Try
            Dim pos As Single
            If Single.TryParse(txtSubstrateTableRotatePosition.Text, pos) Then
                Dim objPMCassette As PMControl = Nothing
                Dim objPMProcess As PMControl = Nothing
                AVPRobotMain.GetPMControl(Me.Parent.Name, objPMProcess, objPMCassette)
                If objPMCassette IsNot Nothing AndAlso objPMProcess IsNot Nothing Then
                    objPMCassette.CurrentEncoderCount = pos
                    objPMProcess.CurrentEncoderCount = pos

                    Dim objCoronaPanel As CoronaPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                    If objCoronaPanel IsNot Nothing Then
                        objCoronaPanel.CoronaChamber.CurrentSlot = objPMCassette.CurrentPosition
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-01 </date>
    ''' </author>
    ''' <summary>
    ''' Update number of unit per revolution
    ''' </summary>
    Private Sub txtNumberOfUnitPerRevolution_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumberOfUnitPerRevolution.TextChanged
        Try
            Dim total As Single
            If Single.TryParse(txtNumberOfUnitPerRevolution.Text, total) Then
                Dim objPMCassette As PMControl = Nothing
                Dim objPMProcess As PMControl = Nothing
                AVPRobotMain.GetPMControl(Me.Parent.Name, objPMProcess, objPMCassette)
                If objPMCassette IsNot Nothing AndAlso objPMProcess IsNot Nothing Then
                    objPMCassette.TotalEncoderCount = total
                    objPMProcess.TotalEncoderCount = total

                    Dim objCoronaPanel As CoronaPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                    If objCoronaPanel IsNot Nothing Then
                        objCoronaPanel.CoronaChamber.CurrentSlot = objPMCassette.CurrentPosition
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
