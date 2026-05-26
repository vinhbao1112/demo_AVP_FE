Imports AVPLib.DataManagerment

Public Class PVD5T_TableControl

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
                btnHOME.Size = New Size(120, 80)
                'lblAllAxisHome.Visible = True
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
                txtTablePosRight.Size = New System.Drawing.Size(65, 24)
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
        cbxShutterSP.Enabled = Not (btnHOME.Status = SL_CustomButton.DisplayStatus.Unknow) And Not (m_blnIsOnline)
        btnShutterHome.Enabled = Not (btnHOME.Status = SL_CustomButton.DisplayStatus.Unknow) And Not (m_blnIsOnline)
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
    Protected Overrides Sub CreateStatusTree()
        Try
            For Each ctrl As Control In Me.Controls
                With m_stoStatusObject
                    If ctrl.GetType().Name = "SL_CustomButton" Then
                        Dim statusbtn As New StatusCoronaButton(CType(ctrl, SL_CustomButton))
                        .AddChild(statusbtn)
                        CType(ctrl, SL_CustomButton).ParentStatusObj = m_stoStatusObject
                    ElseIf ctrl.GetType().Name = "SL_Textbox" Then
                        Dim statusText As New StatusCoronaTextBox(CType(ctrl, SL_Textbox))
                        .AddChild(statusText)
                        CType(ctrl, SL_Textbox).ParentStatusObj = m_stoStatusObject
                    ElseIf ctrl.GetType().Name = "GroupBox" Then
                        Dim Group_Box As GroupBox = CType(ctrl, GroupBox)
                        For Each childCtrl As Control In Group_Box.Controls
                            If childCtrl.GetType().Name = "SL_Textbox" Then
                                Dim statusText As New StatusCoronaTextBox(CType(childCtrl, SL_Textbox))
                                .AddChild(statusText)
                                CType(childCtrl, SL_Textbox).ParentStatusObj = m_stoStatusObject
                            ElseIf childCtrl.GetType().Name = "SL_CustomButton" Then
                                Dim statusbtn As New StatusCoronaButton(CType(childCtrl, SL_CustomButton))
                                .AddChild(statusbtn)
                                CType(childCtrl, SL_CustomButton).ParentStatusObj = m_stoStatusObject
                            End If
                        Next
                    End If
                End With
            Next
            Dim sbcRotateStatus As New StatusCoronaButton(Me.btnRotate)
            Dim sbcGotoSlot As New StatusCoronaTextBox(Me.txtGotoSlot)
            Dim sbctxtRotate As New StatusCoronaTextBox(Me.txtRotate)
            Dim sbctxtTablePos As New StatusCoronaTextBox(Me.txtTablePos)
            Dim sbctxtShutterRB As New StatusCoronaTextBox(Me.txtShutterRB)
            Dim sbctxtSubstrateTableRotatePosition As New StatusCoronaTextBox(Me.txtSubstrateTableRotatePosition)
            Dim sbctxtNumberOfUnitPerRevolution As New StatusCoronaTextBox(Me.txtNumberOfUnitPerRevolution)
            Dim sbcHome As New StatusCoronaButton(Me.btnHOME)
            Dim sbcHomeTable As New StatusCoronaButton(Me.btnHomeTable)
            Dim sbcLiftUp As New StatusCoronaButton(Me.btnLiftUp)
            Dim sbcLiftDown As New StatusCoronaButton(Me.btnLiftDown)
            Dim sbcShutterHome As New StatusCoronaButton(Me.btnShutterHome)
            Dim sbcShutterSP As New StatusCoronaTextBox(Me.txtShutterCurrentSP)
            'Dim sbcGoTo As New StatusCoronaTextBox(Me.cbxGoTo)

            m_stoStatusObject.AddChild(sbcRotateStatus)
            m_stoStatusObject.AddChild(sbcGotoSlot)
            m_stoStatusObject.AddChild(sbctxtRotate)
            m_stoStatusObject.AddChild(sbctxtTablePos)
            m_stoStatusObject.AddChild(sbctxtShutterRB)
            m_stoStatusObject.AddChild(sbctxtSubstrateTableRotatePosition)
            m_stoStatusObject.AddChild(sbctxtNumberOfUnitPerRevolution)
            m_stoStatusObject.AddChild(sbcHome)
            m_stoStatusObject.AddChild(sbcHomeTable)
            m_stoStatusObject.AddChild(sbcLiftUp)
            m_stoStatusObject.AddChild(sbcLiftDown)
            m_stoStatusObject.AddChild(sbcShutterHome)
            m_stoStatusObject.AddChild(sbcShutterSP)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    'Private Sub txtGotoSlot_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGotoSlot.TextChanged
    '    Try
    '        If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
    '            cbxGoTo.SelectedIndex = Convert.ToInt32(txtGotoSlot.Text) - 1
    '        End If
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    'End Sub

    Private Sub btnRotate_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotate.StatusChange, btnShutterHome.StatusChange
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
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnLiftUp_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiftUp.StatusChange
        If DesignMode Then
            Exit Sub
        End If
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                Dim objPVD5TPanel As PVD5TPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                If objPVD5TPanel IsNot Nothing Then
                    If btnLiftUp.Status = SL_CustomButton.DisplayStatus.On Then
                        btnLiftDown.Status = SL_CustomButton.DisplayStatus.Off
                        'objPVD5TPanel.CoronaChamber.IsTableUp = True
                    ElseIf btnLiftUp.Status = SL_CustomButton.DisplayStatus.Off Then
                        btnLiftDown.Status = SL_CustomButton.DisplayStatus.On
                        'objPVD5TPanel.CoronaChamber.IsTableUp = False
                    ElseIf btnLiftUp.Status = SL_CustomButton.DisplayStatus.Unknow Then
                        btnLiftDown.Status = SL_CustomButton.DisplayStatus.Unknow
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtGotoSlot_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGotoSlot.TextChanged, txtShutterRB.TextChanged
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
                    Dim objPanel As PVD5TPanel = ContainerForm.ChamberPanel(Me.Parent.Name)

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
                Dim objPVD5TPanel As PVD5TPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                Dim objChamber As AVPLib.DataManagerment.PVD5TChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(objPVD5TPanel.Name)
                If objChamber IsNot Nothing AndAlso Not txtRotate.Text.Contains(ConstantAndEnum.UNKNOWN) Then
                    If objChamber.Substrate_Table_Rotate_Home = Equipment.WorkingStatuses.On Then
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
                Dim objChamber As AVPLib.DataManagerment.PVD5TChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Name)
                If objChamber IsNot Nothing Then
                    'If objChamber.Initialized_Motion = Equipment.WorkingStatuses.On Then
                    '    lblAllAxisHome.Visible = True
                    'Else
                    '    lblAllAxisHome.Visible = False
                    'End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnHomeTable_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHomeTable.StatusChange
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                Dim objPVD5TPanel As PVD5TPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                Dim objChamber As AVPLib.DataManagerment.PVD5TChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(objPVD5TPanel.Name)
                If objChamber IsNot Nothing Then

                    If objChamber.Substrate_Table_Lift_Home = Equipment.WorkingStatuses.On Then
                        If Not objPVD5TPanel.CoronaChamber.IsTableHome Then
                            objPVD5TPanel.CoronaChamber.IsTableHome = True

                        End If
                    ElseIf objChamber.Substrate_Table_Lift_Home <> Equipment.WorkingStatuses.On Then
                        If objPVD5TPanel.CoronaChamber.IsTableHome Then
                            objPVD5TPanel.CoronaChamber.IsTableHome = False

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
            Dim Source As String = AVPLib.ConstEnum.PVD5T & "." & cbxGoTo.Parent.Parent.Name & "." & cbxGoTo.Name
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
    Private Sub cbxShutterSP_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxShutterSP.DropDownClosed
        Try
            Dim chamberName As String = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
            Dim Source As String = AVPLib.ConstEnum.PVD5T & "." & cbxShutterSP.Parent.Parent.Name & "." & cbxShutterSP.Name
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)
            strMessageText = String.Format(strMessageText, cbxShutterSP.Text)
            If cbxGoTo.Text = String.Empty Then
                Utils.ShowAVPMessageBox(strMessageText, chamberName, MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
            End If

            If Utils.ShowAVPMessageBox(strMessageText, chamberName, MessageBoxIcon.Information, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.OK Then
                Utils.LogUserEvent(sender)
                Dim SlotNumber As Byte = cbxShutterSP.FindStringExact(cbxShutterSP.Text)
                m_stoStatusObject.RequestStatus(cbxShutterSP.AccessibleName, (SlotNumber + 1).ToString)
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

                    Dim objPVD5TPanel As PVD5TPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                    If objPVD5TPanel IsNot Nothing Then
                        objPVD5TPanel.CoronaChamber.CurrentSlot = objPMCassette.CurrentPosition
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

                    Dim objPVD5TPanel As PVD5TPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                    If objPVD5TPanel IsNot Nothing Then
                        objPVD5TPanel.CoronaChamber.CurrentSlot = objPMCassette.CurrentPosition
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnRotate_Click(sender As Object, e As EventArgs) Handles btnRotate.Click
        Try
            Dim strChamberName As String = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
            Dim Source As String = sender.TypeOfChamberSupport.ToString() & "." & sender.Name & "." & sender.Status.ToString
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)

            If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Information) = DialogResult.OK Then
                Dim strLogMessage As String = String.Empty
                Dim strSourceLogMessage As String = String.Empty
                strSourceLogMessage = "[" + strChamberName + "-" + Me.Text + "]"

                m_stoStatusObject.RequestStatus(sender.AccessibleName, sender.ValueToBeSend)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                   strSourceLogMessage + " " + strLogMessage)

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private Sub ButtonHome_Click(sender As Object, e As EventArgs) Handles btnShutterHome.Click, btnHomeTable.Click
        Try
            Dim strChamberName As String = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
            Dim Source As String = sender.TypeOfChamberSupport.ToString() & "." & sender.Name
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(Source)

            If Utils.ShowAVPMessageBox(strMessageText, strChamberName, MessageBoxIcon.Information) = DialogResult.OK Then
                Dim strLogMessage As String = String.Empty
                Dim strSourceLogMessage As String = String.Empty
                strSourceLogMessage = "[" + strChamberName + "-" + Me.Text + "]"

                m_stoStatusObject.RequestStatus(sender.AccessibleName, sender.ValueToBeSend)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen,
                                                   strSourceLogMessage + " " + strLogMessage)

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtShutterCurrentSP_TextChanged(sender As Object, e As EventArgs) Handles txtShutterCurrentSP.TextChanged
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                Dim index As Integer = cbxShutterSP.FindStringExact(txtShutterCurrentSP.Text)
                If index >= 0 Then
                    cbxShutterSP.SelectedIndex = index
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
