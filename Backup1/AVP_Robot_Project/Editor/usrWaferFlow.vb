Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.DataManagerment
Imports AVPLib
Imports AVPControls

Public Class usrWaferFlow
#Region "variable"

    Private Shared m_currentSelectedStep As usrEquipmentName
    Private m_iCurrentSelectedEquipmentID As Integer

    ' each time open or save
    Private m_wfcurrentWfFlow As AVPLib.DataManagerment.WaferFlow = Nothing

    ' is used to ID the loop. Each loop have an unique ID
    Private m_intLoopCount As Integer = 0

    ' This is used to check the changes from user
    Private m_blnIsModifiedFlag As Boolean = False

    ' Contain all loop information
    Private m_waferflowLoopInfo As New WaferFlowLoopInfo()

    ' increase each time we add a control
    Private m_intControlID As Integer = 0

    Private m_currentSelectedStart As usrEquipmentName = Nothing
    '
    Private m_strTitle As String = String.Empty

    Public Event Reload_PPWFEvent As EventHandler
#End Region

#Region "Property"

    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Title
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Title() As String
        Get
            Return m_strTitle
        End Get
        Set(ByVal value As String)
            m_strTitle = value
            labTitle.Text = value
            labTitle.Tag = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-06-15</date>
    ''' </author>
    ''' <summary>
    ''' Property of Selected Equipment ID
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Property CurrentEquipmentID() As Integer
        Get
            Return m_iCurrentSelectedEquipmentID
        End Get
        Set(ByVal value As Integer)
            m_iCurrentSelectedEquipmentID = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-06-15</date>
    ''' </author>
    ''' <summary>
    ''' Property of CurrentPosition
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Property IsModifiedFlag() As Boolean
        Get
            Return m_blnIsModifiedFlag
        End Get
        Set(ByVal value As Boolean)
            m_blnIsModifiedFlag = value
            If m_blnIsModifiedFlag Then
                Me.labTitle.Text = labTitle.Tag.ToString() & "*"
            Else
                Me.labTitle.Text = labTitle.Tag.ToString()
            End If
        End Set
    End Property
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-06-15</date>
    ''' </author>
    ''' <summary>
    ''' Property of CurrentPosition
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>   
    Public Property SelectedStep() As usrEquipmentName
        Get
            Return m_currentSelectedStep
        End Get
        Set(ByVal value As usrEquipmentName)
            m_currentSelectedStep = value
        End Set
    End Property

#End Region

#Region "Sub and function"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-13</date>
    ''' </author>
    ''' <summary>
    ''' Reload Recipe if Recipe does not exist
    ''' </summary>
    ''' <param name="wfFlowName">WaferFlow Name</param>
    ''' <remarks></remarks>   
    Public Sub ReloadRecipeName()
        CleanRecipeDontExist(Me.pnlEquipmentLeft, True)
        CleanRecipeDontExist(Me.pnlEquipmentRight, True)
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-13</date>
    ''' </author>
    ''' <summary>
    ''' Check and show messagebox if recipe does not exist
    ''' </summary>
    ''' <param name="wfFlowName">WaferFlow Name</param>
    ''' <remarks></remarks>   
    Private Sub CleanRecipeDontExist(ByVal panel As Windows.Forms.Panel, ByVal blnShowMessageBox As Boolean)
        Try
            For Each ctlControl As usrEquipmentName In panel.Controls
                Dim chamber As String = ctlControl.lblEquipment.Text
                Dim lstStrRecipe As ArrayList = AVPLib.ContainerData.ListChamber(AVPLib.Utils.chamberName2ChamberID(chamber))

                Dim isHaveRecipe As Boolean = False
                Dim strRecipeName As String = ctlControl.WaferFlowName

                If (chamber = "Any" & RobotConfigurationValues.ANY_IBE_CHAMBER) Then
                    chamber = RobotConfigurationValues.ANY_IBE_CHAMBER
                End If

                'If Not String.IsNullOrEmpty(strRecipeName) Then
                '    strRecipeName = strRecipeName.Substring(strRecipeName.IndexOf("_") + 1)
                'End If
                If Not String.IsNullOrEmpty(ctlControl.WaferFlowName) Then
                    If lstStrRecipe IsNot Nothing OrElse lstStrRecipe.Count > 0 Then
                        For Each recipeName As String In lstStrRecipe
                            If recipeName.ToUpper = ctlControl.WaferFlowName.ToUpper Then
                                isHaveRecipe = True
                                Exit For
                            End If
                        Next
                    End If

                    If Not isHaveRecipe Then
                        ctlControl.WaferFlowName = ""

                        If blnShowMessageBox Then
                            Utils.ShowAVPMessageBox("Recipe " & ctlControl.WaferFlowName & _
                                                    " does not exist, please check again!", "Recipe Error", _
                                                    MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                               AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                               "[Main Screen] " + "Recipe " & ctlControl.WaferFlowName & " does not exist")

                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-13</date>
    ''' </author>
    ''' <summary>
    ''' Save or Save as or Update WaferFlow
    ''' </summary>
    ''' <param name="wfFlowName">WaferFlow Name</param>
    ''' <remarks></remarks>   
    Private Sub SavingWaferFlow(ByVal wfFlowName As String, ByVal blnCheckExistName As Boolean)
        AVPLib.Log.guiLogger.Info("Open SavingWaferFlow")
        Dim blnSuccess As Boolean = False
        ''we check wafername is exist or not
        Me.m_wfcurrentWfFlow = Me.StoreGuiInToWaferFlow(wfFlowName)

        blnSuccess = AVPLib.ContainerData.SaveWaferFlow(m_wfcurrentWfFlow, blnCheckExistName)

        If blnSuccess Then
            'Utils.ShowAVPMessageBox("Save successfully", "Save", MessageBoxIcon.Information, MessageBoxButtons.OK)
            Title = m_wfcurrentWfFlow.WaferFlowName
            '#004/27/2011 
            '#AVP. Wafer flow editor. Logs does not show what flow is being save. --> see picture for more detail
            '#Begin fix
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                             AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                             "[Main Screen] " + "Save WaferFlow  " & wfFlowName & " successfully")
            '#End fix.
            If ContainerForm.Secs_GemPanel.rbnWaferFlow.Checked Then
                RaiseEvent Reload_PPWFEvent(Nothing, Nothing)
            End If
        Else
            Utils.ShowAVPMessageBox("Error in saving Wafer", "Save", MessageBoxIcon.Error, MessageBoxButtons.OK)
            Me.m_wfcurrentWfFlow = Nothing
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                  AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                  "[Main Screen] " + "Error in saving WaferFlow")

        End If
        AVPLib.Log.guiLogger.Info("Leave SavingWaferFlow")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' Check Existing of WaferFlow
    ''' </summary>
    ''' <param name="map">contain WaferFlow</param>
    ''' <remarks></remarks>   
    Private Function CheckExistWaferFlow(ByVal WfFlowName As String) As Boolean
        AVPLib.Log.guiLogger.Info("Enter CheckExistWaferFlow")
        Dim bSuccess As Boolean = False
        Dim arrWaferFlow As ArrayList = Nothing
        arrWaferFlow = AVPLib.ContainerData.GetAllWaferFlowName
        If arrWaferFlow.Contains(WfFlowName) Then
            bSuccess = True
        End If
        AVPLib.Log.guiLogger.Info("Leave CheckExistWaferFlow")
        Return bSuccess
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' Show Wafer In Gui
    ''' </summary>
    ''' <param name="map">contain WaferFlow</param>
    ''' <remarks></remarks>   
    Private Function StoreGuiInToWaferFlow(ByVal WfFlowName As String, Optional ByVal Description As String = "") As AVPLib.DataManagerment.WaferFlow
        AVPLib.Log.guiLogger.Info("Enter StoreGuiInToWaferFlow")
        Dim wfflow As New AVPLib.DataManagerment.WaferFlow
        Dim loopItem As New AVPLib.DataManagerment.WaferflowLoop
        Dim arlStepList As New ArrayList
        Dim arlLoopList As New ArrayList
        Try
            wfflow.WaferFlowName = WfFlowName
            wfflow.Description = Description
            'wfflow.Description
            For i As Integer = 0 To Me.pnlEquipmentRight.Controls.Count - 1
                Dim stepItem As New AVPLib.DataManagerment.WaferflowStep
                Dim arlStation As New ArrayList
                Dim ctlChamber As usrEquipmentName = FindByIndex(i)
                stepItem.RecipeName = ctlChamber.WaferFlowName
                Dim stationname As String = (ctlChamber.Header).Replace(" ", "")
                arlStation.Add(stationname)
                stepItem.StationList = arlStation
                stepItem.Number = i
                arlStepList.Add(stepItem)
            Next

            wfflow.StepList = arlStepList
            For Each item As AVPLib.DataManagerment.WaferflowLoop In Me.m_waferflowLoopInfo.LoopList
                arlLoopList.Add(item)
            Next
            wfflow.LoopList = arlLoopList
            wfflow.Description = txtDescription.Text
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave StoreGuiInToWaferFlow")
        Return wfflow
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' Show Wafer In Gui
    ''' </summary>
    ''' <param name="map">contain WaferFlow</param>
    ''' <remarks></remarks>   
    Private Sub ShowWaferInGui(ByVal WfFlow As AVPLib.DataManagerment.WaferFlow)
        AVPLib.Log.guiLogger.Info("Enter ShowWaferInGui")
        Try
            Title = WfFlow.WaferFlowName
            Me.txtDescription.Text = WfFlow.Description

            Dim arrStep As ArrayList = WfFlow.StepList

            'wfflow.StepList 
            Me.pnlEquipmentRight.Controls.Clear()
            For i As Integer = 0 To arrStep.Count - 1
                Dim stepElement As AVPLib.DataManagerment.WaferflowStep = arrStep.Item(i)
                'stepElement.StepName
                'stepelement.Number 
                Dim arrStation As ArrayList = stepElement.StationList
                If arrStation IsNot Nothing Then
                    For j As Integer = 0 To arrStation.Count - 1
                        Dim station As String = arrStation.Item(j)
                        ''clone station
                        station = station.Substring(station.LastIndexOf(".") + 1)
                        Select Case station
                            Case Equipments.IBE.ToString()
                                CopyFromUserControl(UsrEquipmentNameAnyIBE, stepElement.RecipeName)
                            Case Equipments.PVD.ToString()
                                CopyFromUserControl(UsrEquipmentNameAnyPVD, stepElement.RecipeName)
                            Case Equipments.Aligner.ToString()
                                If AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
                                    CopyFromUserControl(usrEquipmentNameAligner, stepElement.RecipeName)
                                End If
                            Case Equipments.Chamber1.ToString()
                                CopyFromUserControl(UsrEquipmentNameChamber1, stepElement.RecipeName)
                            Case Equipments.Chamber2.ToString()
                                CopyFromUserControl(UsrEquipmentNameChamber2, stepElement.RecipeName)
                            Case Equipments.Chamber3.ToString()
                                CopyFromUserControl(UsrEquipmentNameChamber3, stepElement.RecipeName)
                        End Select
                    Next
                End If
            Next
            'WfFlow.LoopList
            Dim arrLoop As ArrayList = WfFlow.LoopList

            ''we clear all loop before add new
            Me.m_waferflowLoopInfo.LoopList.Clear()

            For Each item As WaferflowLoop In arrLoop
                Me.m_waferflowLoopInfo.LoopList.Add(item)
            Next
            Me.Refresh()
            Me.Validate()

            'Refresh the pannel
            pnlEquipmentRight.Refresh()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ShowWaferInGui")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' CopyFromUserControl
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>   
    Public Sub CopyFromUserControl(ByVal usrEquipmentName As usrEquipmentName, _
                                   Optional ByVal RecipeName As String = "")
        AVPLib.Log.guiLogger.Info("Enter CopyFromUserControl")
        Try
            Dim usrEquipment As New usrEquipmentName(Me)
            usrEquipment.Width = 400
            usrEquipment.lblEquipment.Text = usrEquipmentName.Header
            If (usrEquipmentName.Header = RobotConfigurationValues.ANY_IBE_CHAMBER) Then
                usrEquipment.lblEquipment.Text = "Any" & AVPLib.Utils.chamberID2ChamberName(usrEquipment.lblEquipment.Text)
            Else
                usrEquipment.lblEquipment.Text = AVPLib.Utils.chamberID2ChamberName(usrEquipment.lblEquipment.Text)
            End If

            usrEquipment.Name = usrEquipment.Name & usrEquipmentName.Header & CStr(m_intControlID)
            m_intControlID += 1

            '''Truc modified, to use optional parameter-------------------
            If RecipeName = "" Then
                usrEquipment.WaferFlowName = usrEquipmentName.WaferFlowName
            Else
                usrEquipment.WaferFlowName = RecipeName
            End If
            '''Truc modified-----------------
            usrEquipment.Header = usrEquipmentName.Header
            If (SelectedStep IsNot Nothing) Then
                SelectedStep.EquipmentLostFocus()
                'update index 
                For Each ctlChamber As usrEquipmentName In Me.pnlEquipmentRight.Controls
                    If (ctlChamber.Index > SelectedStep.Index) Then
                        ctlChamber.Index += 1
                    End If
                Next
                'update loop information
                For Each loopInfo As WaferflowLoop In m_waferflowLoopInfo.LoopList
                    If loopInfo.LoopStart > SelectedStep.Index Then
                        loopInfo.LoopStart += 1
                    End If
                    If loopInfo.LoopEnd > SelectedStep.Index Then
                        loopInfo.LoopEnd += 1
                    End If
                Next
                ' insert to the list
                usrEquipment.Index = SelectedStep.Index + 1
            Else
                'add to the end
                'Update the index information, count from 0
                usrEquipment.Index = Me.pnlEquipmentRight.Controls.Count
            End If

            'Add to control
            Me.pnlEquipmentRight.Controls.Add(usrEquipment)

            Dim iHeigh As Integer = usrEquipment.Bounds.Height
            'set  space
            Dim iYlocation As Integer = 0
            If SelectedStep Is Nothing Then
                iYlocation = (iHeigh + SPACE) * (Me.pnlEquipmentRight.Controls.Count - 1)
                iYlocation += pnlEquipmentRight.AutoScrollPosition.Y + SPACE
            Else
                iYlocation = (iHeigh + SPACE) + SelectedStep.Location.Y
            End If

            'set coodition of control in panel
            usrEquipment.Location = New System.Drawing.Point(SPACE, iYlocation)

            usrEquipment.BorderStyle = Windows.Forms.BorderStyle.FixedSingle

            '
            If (SelectedStep IsNot Nothing) Then
                usrEquipment.usrEquipmentName_Click(Nothing, Nothing)
            End If

            RefreshPanel()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CopyFromUserControl")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' Add usrcontrol equipment
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Public Sub AddUsrEquipment(ByVal panel As Panel, ByVal usrEquipmentName As usrEquipmentName)
        AVPLib.Log.guiLogger.Info("Enter CopyFromUserControl")
        Try
            Dim iCount As Integer = panel.Controls.Count
            usrEquipmentName.WaferFlowForm = Me

            'Update the index information, count from 0
            usrEquipmentName.Index = panel.Controls.Count

            'Add to control
            panel.Controls.Add(usrEquipmentName)

            Dim iHeigh As Integer = usrEquipmentName.Bounds.Height
            'set  space
            usrEquipmentName.Width = 370
            Dim iYlocation As Integer = SPACE + (iHeigh + SPACE + 20) * iCount
            'set coodition of control in panel

            usrEquipmentName.Location = New System.Drawing.Point(SPACE, iYlocation)
            usrEquipmentName.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CopyFromUserControl")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' Children
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Public Sub enableStartButton(ByVal enable As Boolean)
        btnStart.Enabled = enable
    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-08-03</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckPermission()
        AVPLib.Log.guiLogger.Info("Enter CheckPermission")
        Try
            If AVPLib.ContainerData.Permission(PERMISSION_002) AndAlso Not AVPRobotMain.OnlineRemote Then
                ActiveForm()
            Else
                InactiveForm()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CheckPermission")
    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-8-3</date>
    ''' </author>
    ''' <summary>
    ''' Active Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveForm()
        Try
            Me.btnNew.Enabled = True
            Me.btnOpen.Enabled = True
            Me.btnDelete.Enabled = True
            Me.btnSave.Enabled = True
            Me.btnSaveAs.Enabled = True
            Me.btnAdd.Enabled = True
            Me.btnRemove.Enabled = True
            Me.btnRemoveAll.Enabled = True
            Me.btnUp.Enabled = True
            Me.btnDown.Enabled = True
            Me.btnEnd.Enabled = True
            Me.btnStart.Enabled = True
            Me.txtRepeatCount.Enabled = True
            Me.btnCancel.Enabled = True
            Me.usrEquipmentNameAligner.Enabled = True
            Me.UsrEquipmentNameChamber3.Enabled = True
            Me.UsrEquipmentNameChamber2.Enabled = True
            Me.UsrEquipmentNameChamber1.Enabled = True
            Me.pnlEquipmentRight.Enabled = True
            Me.txtDescription.Enabled = True

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-8-3</date>
    ''' </author>
    ''' <summary>
    ''' Active Form
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub InactiveForm()
        Try
            '#05/16/2011 
            '#Fix bug: AVP.  Flow editor.  Add/remove/removeall/start/end/delete/repeat buttons is accessible when user 
            '# does not have priviledge to edit flow .    Need to disable all buttons when user does not have access (except for open button)
            '#Begin fix: rem code.

            'If (AVPLib.ContainerData.UserLogin IsNot Nothing) Then
            '    Me.btnNew.Enabled = False
            '    'Me.btnOpen.Enabled = False
            '    Me.btnDelete.Enabled = False
            '    Me.btnSave.Enabled = False
            '    Me.btnSaveAs.Enabled = False

            '    Me.btnAdd.Enabled = True
            '    Me.btnRemove.Enabled = True
            '    Me.btnRemoveAll.Enabled = True
            '    Me.btnUp.Enabled = True
            '    Me.btnDown.Enabled = True
            '    Me.btnEnd.Enabled = True
            '    Me.btnStart.Enabled = True
            '    Me.txtRepeatCount.Enabled = True
            '    Me.btnCancel.Enabled = True
            '    Me.usrEquipmentNameAligner.Enabled = True
            '    Me.UsrEquipmentNameChamber3.Enabled = True
            '    Me.UsrEquipmentNameChamber2.Enabled = True
            '    Me.UsrEquipmentNameChamber1.Enabled = True
            '    Me.pnlEquipmentRight.Enabled = True
            '    Me.txtDescription.Enabled = True
            'Else

            '#End fix
            Me.btnNew.Enabled = False
            Me.btnOpen.Enabled = (AVPLib.ContainerData.UserLogin IsNot Nothing)
            Me.btnDelete.Enabled = False
            Me.btnSave.Enabled = False
            Me.btnSaveAs.Enabled = False

            Me.btnAdd.Enabled = False
            Me.btnRemove.Enabled = False
            Me.btnRemoveAll.Enabled = False
            Me.btnUp.Enabled = False
            Me.btnDown.Enabled = False
            Me.btnEnd.Enabled = False
            Me.btnStart.Enabled = False
            Me.txtRepeatCount.Enabled = False
            Me.btnCancel.Enabled = False
            Me.usrEquipmentNameAligner.Enabled = False
            Me.UsrEquipmentNameChamber3.Enabled = False
            Me.UsrEquipmentNameChamber2.Enabled = False
            Me.UsrEquipmentNameChamber1.Enabled = False
            Me.pnlEquipmentRight.Enabled = False
            Me.txtDescription.Enabled = False
            ' End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Painting Control"
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' pnlEquipmentRight_Paint
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub pnlEquipmentRight_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlEquipmentRight.Paint
        AVPLib.Log.guiLogger.Info("Enter pnlEquipmentRight_Paint")
        Try
            'draw lince for start
            If m_currentSelectedStart IsNot Nothing Then
                DrawStart(e.Graphics)
            End If
            'draw line for loop
            DrawLoop(e.Graphics)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave pnlEquipmentRight_Paint")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' Draw line when start button is clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub DrawStart(ByVal e As Graphics)
        If m_currentSelectedStart IsNot Nothing Then
            Dim drawFont As New Font("Arial", 12)
            Dim drawBrush As New SolidBrush(Color.Blue)
            Dim myPen As New Drawing.Pen(Color.Blue, 1)
            Dim xStart As Integer = m_currentSelectedStart.Location.X + m_currentSelectedStep.Bounds.Width
            Dim yStart As Integer = m_currentSelectedStart.Location.Y + m_currentSelectedStep.Bounds.Height / 2
            e.DrawLine(myPen, xStart, yStart, xStart + PARAGRAPH, yStart)
        End If
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' Draw Loop
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub DrawLoop(ByVal e As Graphics)
        'set pen
        Dim drawFont As New Font("Arial", 12)
        Dim drawBrush As New SolidBrush(Color.Blue)
        Dim myPen As New Drawing.Pen(Color.Blue, 1)
        'Get Width and height
        Dim mEquiment As usrEquipmentName = New usrEquipmentName()
        mEquiment.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        'draw loop
        For i As Integer = 0 To m_waferflowLoopInfo.LoopList.Count - 1
            If m_currentSelectedStep IsNot Nothing Then
                ' if the selected item is in a loop then bold the link
                If m_currentSelectedStep.Index <= m_waferflowLoopInfo.LoopList(i).LoopEnd And _
                   m_currentSelectedStep.Index >= m_waferflowLoopInfo.LoopList(i).LoopStart Then
                    myPen.Width = 2
                End If
            End If

            'Draw line start
            Dim xStart As Integer = WIDTH_EQP + SPACE
            Dim yStart As Integer = m_waferflowLoopInfo.LoopList(i).LoopStart * (HEIGHT_EQP + SPACE) + HEIGHT_EQP / 2

            ' convert to the relative position
            yStart += pnlEquipmentRight.AutoScrollPosition.Y + SPACE
            e.DrawLine(myPen, xStart, yStart, xStart + PARAGRAPH, yStart)

            'Draw line End
            Dim xEnd As Integer = WIDTH_EQP + SPACE
            Dim yEnd As Integer = m_waferflowLoopInfo.LoopList(i).LoopEnd * (HEIGHT_EQP + SPACE) + HEIGHT_EQP / 2

            'convert to the relative position
            yEnd += pnlEquipmentRight.AutoScrollPosition.Y + SPACE

            e.DrawLine(myPen, xEnd, yEnd, xEnd + PARAGRAPH, yEnd)
            'Draw Heigh of loop
            e.DrawLine(myPen, xStart + PARAGRAPH, yStart, xStart + PARAGRAPH, yEnd)
            'Draw string
            e.DrawString(m_waferflowLoopInfo.LoopList(i).LoopCount.ToString(), drawFont, drawBrush, xEnd + PARAGRAPH, (yStart + yEnd) / 2 - SPACE)
            myPen.Width = 1
        Next
    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-08-06</date>
    ''' </author>
    ''' <summary>
    ''' User click the scrool bar, we should redraw the loop infomation
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnlEquipmentRight_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles pnlEquipmentRight.Scroll
        Refresh()
    End Sub
#End Region

#Region "Event"
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-06-15</date>
    ''' </author>
    ''' <summary>
    ''' Textbox keyPress event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtRepeatCount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRepeatCount.KeyPress
        If (txtRepeatCount.Text = String.Empty And e.KeyChar = "0"c) Then
            e.Handled = True
        ElseIf (Char.IsNumber(e.KeyChar) Or e.KeyChar = "") Then ' back spase
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-06-15</date>
    ''' </author>
    ''' <summary>
    ''' usrWaferFlow_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub usrWaferFlow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AVPLib.Log.guiLogger.Info("Enter usrWaferFlow_Load")
        Try

            If AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
                usrEquipmentNameAligner.lblEquipment.Text = usrEquipmentNameAligner.Header
                AddUsrEquipment(pnlEquipmentLeft, usrEquipmentNameAligner)
            End If
            If AVPLib.ContainerDAO.Enable_ANYIBE_Mode Then
                UsrEquipmentNameAnyIBE.lblEquipment.Text = "Any" & UsrEquipmentNameAnyIBE.Header
                AddUsrEquipment(pnlEquipmentLeft, UsrEquipmentNameAnyIBE)
            End If

            'USED FOR ENABLE/DISABLE ANYPVD 
            'UsrEquipmentNameAnyPVD.lblEquipment.Text = UsrEquipmentNameAnyPVD.Header
            'UsrEquipmentNameAnyPVD.LoadAllRecipe = True
            'AddUsrEquipment(pnlEquipmentLeft, UsrEquipmentNameAnyPVD)

            If (AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE) Then
                UsrEquipmentNameChamber1.lblEquipment.Text = AVPLib.RobotConfigurationValues.CHAMBER1_NAME
                AddUsrEquipment(pnlEquipmentLeft, UsrEquipmentNameChamber1)
            End If
            If (AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE) Then
                UsrEquipmentNameChamber2.lblEquipment.Text = AVPLib.RobotConfigurationValues.CHAMBER2_NAME
                AddUsrEquipment(pnlEquipmentLeft, UsrEquipmentNameChamber2)
            End If
            If (AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE) Then
                UsrEquipmentNameChamber3.lblEquipment.Text = AVPLib.RobotConfigurationValues.CHAMBER3_NAME
                AddUsrEquipment(pnlEquipmentLeft, UsrEquipmentNameChamber3)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave usrWaferFlow_Load")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-06-15</date>
    ''' </author>
    ''' <summary>
    ''' UsrEquipmentNameAligner_Click, to colour the line that is chose
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub UsrEquipmentName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles usrEquipmentNameAligner.Click, _
                                      UsrEquipmentNameChamber1.Click, _
        UsrEquipmentNameChamber2.Click, _
        UsrEquipmentNameChamber3.Click

        Dim usrcontrol As UserControl = CType(sender, UserControl)
        AVPLib.Log.guiLogger.Info("Enter UsrEquipmentNameAligner_Click")
        Try
            'Aigner
            If usrcontrol.Name.Contains(Equipments.IBE.ToString()) = True Then
                CurrentEquipmentID = Equipments.IBE
            ElseIf usrcontrol.Name.Contains(Equipments.PVD.ToString()) = True Then
                CurrentEquipmentID = Equipments.PVD
            ElseIf usrcontrol.Name.Contains(Equipments.Aligner.ToString()) = True Then
                CurrentEquipmentID = Equipments.Aligner
                'Chamber 1
            ElseIf usrcontrol.Name.Contains(Equipments.Chamber1.ToString()) = True Then
                CurrentEquipmentID = Equipments.Chamber1
                'Chamber 2
            ElseIf usrcontrol.Name.Contains(Equipments.Chamber2.ToString()) = True Then
                CurrentEquipmentID = Equipments.Chamber2
                'Chamber 3
            ElseIf usrcontrol.Name.Contains(Equipments.Chamber3.ToString()) = True Then
                CurrentEquipmentID = Equipments.Chamber3
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave UsrEquipmentNameAligner_Click")
    End Sub

    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-06-15</date>
    ''' </author>
    ''' <summary>
    ''' btnAdd_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        AVPLib.Log.guiLogger.Info("Enter btnAdd_Click")
        Try
            Dim iCount As Integer = pnlEquipmentRight.Controls.Count
            'add to pnlRightEquipmentName
            'Add to list index : paint_event depend index list
            'Add to Panel
            Select Case CurrentEquipmentID
                Case Equipments.IBE
                    CopyFromUserControl(UsrEquipmentNameAnyIBE)
                Case Equipments.PVD
                    CopyFromUserControl(UsrEquipmentNameAnyPVD)
                Case Equipments.Aligner
                    CopyFromUserControl(usrEquipmentNameAligner)
                Case Equipments.Chamber1
                    CopyFromUserControl(UsrEquipmentNameChamber1)
                Case Equipments.Chamber2
                    CopyFromUserControl(UsrEquipmentNameChamber2)
                Case Equipments.Chamber3
                    CopyFromUserControl(UsrEquipmentNameChamber3)
            End Select
            Me.IsModifiedFlag = True

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnAdd_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' Open WaferFlow
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>   
    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        AVPLib.Log.guiLogger.Info("Leave btnOpen_Click")
        Try
            Dim arrWaferFlow As ArrayList = Nothing
            arrWaferFlow = AVPLib.ContainerData.GetAllWaferFlowName
            ''open dialog for WaferFlow
            Dim waferDlg As New SelectWaferFlow(arrWaferFlow, False)
            waferDlg.ShowDialog()
            If waferDlg.DialogResult = Windows.Forms.DialogResult.OK Then
                If (IsModifiedFlag AndAlso AVPLib.ContainerData.Permission(PERMISSION_002)) Then
                    If Utils.ShowAVPMessageBox("Current Wafer Flow was changed." & Chr(13) & "Do you want to save ?", "Save Wafer Flow", MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK Then
                        btnSave_Click(sender, e)
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                 AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                 "[Main Screen] " + "Confirm save Current Wafer Flow when open new Wafer Flow")

                    End If
                End If
                m_wfcurrentWfFlow = waferDlg.SelectedFlow
                m_currentSelectedStart = Nothing
                m_currentSelectedStep = Nothing
                ShowWaferInGui(m_wfcurrentWfFlow)
                ReloadRecipeName()

                If (AVPLib.ContainerData.Permission(PERMISSION_002) AndAlso Not AVPRobotMain.OnlineRemote) Then
                    btnSave.Enabled = True
                    btnSaveAs.Enabled = True
                    btnDelete.Enabled = True
                Else
                    Me.btnNew.Enabled = False
                    Me.btnDelete.Enabled = False
                    Me.btnSave.Enabled = False
                    Me.btnSaveAs.Enabled = False
                End If
            End If
            Me.IsModifiedFlag = False

            waferDlg.Dispose()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnOpen_Click")
    End Sub

    ''' <author>
    '''    	<name> Is valid steps </name>
    '''    	<date> 2009-08-07</date>
    ''' </author>
    ''' <summary>
    ''' Check if the steps is not valid, all of them should have recipe
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>   
    Private Function IsValidWaferFlow() As String
        Try
            If (pnlEquipmentRight.Controls.Count = 0) Then
                Return STR_WAFERFLOW_NOFLOW
            End If

            ' Check if the recipe in steps empty
            For Each ctlChamber As usrEquipmentName In Me.pnlEquipmentRight.Controls
                If ctlChamber.WaferFlowName = String.Empty Then
                    Return STR_RECIPE_EMPTY_WARNING
                End If
            Next

            ' Check for Duplicate steps 
            For Each ctlChamber As usrEquipmentName In Me.pnlEquipmentRight.Controls
                Dim preStep As usrEquipmentName = FindByIndex(ctlChamber.Index - 1)

                If (preStep IsNot Nothing) Then
                    If preStep.Header = ctlChamber.Header Then
                        Return STR_DUPLICATE_STEP_WARNING
                    End If
                End If

                Dim nextStep As usrEquipmentName = FindByIndex(ctlChamber.Index + 1)
                If (nextStep IsNot Nothing) Then
                    If nextStep.Header = ctlChamber.Header Then
                        Return STR_DUPLICATE_STEP_WARNING
                    End If
                End If
            Next

        Catch ex As Exception
            AVPLib.Log.guiLogger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function


    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' Save WaferFlow
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>   
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        AVPLib.Log.guiLogger.Info("Leave btnOpen_Click")
        Try
            ' Pre-condition
            ' Check to see if any step not select the recipe
            Dim strErrMsg = IsValidWaferFlow()
            If (strErrMsg <> String.Empty) Then
                Utils.ShowAVPMessageBox(strErrMsg, "Error", MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                      AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                      "[Main Screen] " + "Save WaferFlow error : " & strErrMsg)
                Return
            End If

            If Me.m_wfcurrentWfFlow Is Nothing Then
                Dim wfFlowName As String = String.Empty
                Dim strMessage As String = "Save your WaferFlow as..."
                Dim sTitle As String = "Save..."
                Dim sDefault As String = "WFFlow"
                Dim pad As New KeyPad
                pad.IsCheckInvalidCharacter = True
                If pad.DisplayKeypad(sDefault, strMessage, False) <> DialogResult.OK Then
                    Exit Sub
                End If

                wfFlowName = sDefault.Trim()
                wfFlowName = wfFlowName

                If Not CheckExistWaferFlow(wfFlowName) Then
                    If Not (wfFlowName = String.Empty) Then
                        SavingWaferFlow(wfFlowName, True)
                        Me.Title = wfFlowName
                    End If

                Else
                    Dim dlg As DialogResult = Utils.ShowAVPMessageBox("This file is exist. Do you want update this file?", "Warning", MessageBoxIcon.Question)
                    If dlg = DialogResult.OK Then
                        If IsWaferFlowInUseScheduler(wfFlowName, "Save", "modify") Then
                            Exit Try
                        End If

                        SavingWaferFlow(wfFlowName, True)
                        Me.Title = wfFlowName
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                        AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                        "[Main Screen] " + "Save WaferFlow with override mode.")
                        '#08/17/2011 
                        '#-Recipe/waferflow/sequence was modified during lot run but was not log in lot data log.
                        '#Begin fix.
                        If IsModifiedFlag Then
                            Utils.AddLotDatalog("Wafer Flow " & wfFlowName & " is modified")
                        End If
                        '#End fix
                    Else
                        Exit Sub
                    End If
                    End If
            Else
                If IsWaferFlowInUseScheduler(m_wfcurrentWfFlow.WaferFlowName, "Save", "modify") Then
                    Exit Try
                End If

                SavingWaferFlow(m_wfcurrentWfFlow.WaferFlowName, False)
                Me.Title = m_wfcurrentWfFlow.WaferFlowName
                '#08/17/2011 
                '#-Recipe/waferflow/sequence was modified during lot run but was not log in lot data log.
                '#Begin fix.
                If IsModifiedFlag Then
                    Utils.AddLotDatalog("Wafer Flow " & m_wfcurrentWfFlow.WaferFlowName & " is modified")
                End If
                '#End fix
                End If
                Me.IsModifiedFlag = False

        Catch ex As Exception
            AVPLib.Log.guiLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnOpen_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' Save as WaferFlow
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>   
    Private Sub btnSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAs.Click
        AVPLib.Log.guiLogger.Info("Enter btnSaveAs_Click")
        Try
            ' Pre-condition
            ' Check to see if any step not select the recipe
            Dim strErrMsg = IsValidWaferFlow()
            If (strErrMsg <> String.Empty) Then
                Utils.ShowAVPMessageBox(strErrMsg, "Error", MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                    AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                    "[Main Screen] " + "Save as WaferFlow error : " & strErrMsg)
                Return
            End If

            Dim wfFlowName As String = String.Empty
            Dim strMessage As String = "Save your WaferFlow as..."
            Dim sTitle As String = "Save as..."
            Dim sDefault As String = labTitle.Tag
            Dim pad As New KeyPad
            pad.IsCheckInvalidCharacter = True
            If pad.DisplayKeypad(sDefault, strMessage, False) <> DialogResult.OK Then
                Exit Sub
            End If
            wfFlowName = sDefault.Trim()
            wfFlowName = wfFlowName

            If Not (wfFlowName = String.Empty) Then
                If Not CheckExistWaferFlow(wfFlowName) Then
                    SavingWaferFlow(wfFlowName, True)
                    Title = wfFlowName
                Else
                    Dim dlg As DialogResult = Utils.ShowAVPMessageBox("This file is exist. Do you want update this file?", "Warning", MessageBoxIcon.Question)
                    If dlg = DialogResult.OK Then
                        If IsWaferFlowInUseScheduler(wfFlowName, "Save as", "modify") Then
                            Exit Try
                        End If

                        SavingWaferFlow(wfFlowName, True)
                        Title = wfFlowName
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                     AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                     "[Main Screen] " + "Save as WaferFlow with override mode.")
                        '#08/17/2011 
                        '#-Recipe/waferflow/sequence was modified during lot run but was not log in lot data log.
                        '#Begin fix.
                        Utils.AddLotDatalog("Wafer Flow " & m_wfcurrentWfFlow.WaferFlowName & " is modified")
                        '#End fix.
                    Else
                        Exit Sub
                    End If
                End If
            End If

            Me.IsModifiedFlag = False
        Catch ex As Exception
            AVPLib.Log.guiLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnSaveAs_Click")
    End Sub
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2010-03-10</date>
    ''' </author>
    ''' <summary>
    ''' Check Wafer Flow is In Use
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>   
    Private Function CheckWaferFlowInSequence(ByVal sWaferFlow As String, ByVal sSequence As String) As Boolean
        Dim sequenFileName As String = AVPLib.Utils.GetFileName(sSequence, "xml")
        Dim filepath As String = AVPLib.ContainerDAO.FPath_SequenceData + "\" + sequenFileName
        If System.IO.File.Exists(filepath) = False Then
            Return False
        End If

        Dim wfSequence As AVPLib.DBWaferList = Nothing
        Dim strDescription As String = Nothing
        ' If can not open the flow
        If Not AVPLib.ContainerData.GetSequence(filepath, wfSequence, strDescription) Then
            Return False
        End If

        For Each waferSlot As DBWaferSlot In wfSequence.WaferList
            If waferSlot.WaferSequence.SeqName = sWaferFlow Then
                Return True
            End If
        Next
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2010-03-10</date>
    ''' </author>
    ''' <summary>
    ''' Check Wafer Flow is In Use
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>   
    Private Function CheckWaferFlowInUse(ByVal WaferFlowName As String) As Boolean
        ''' get list of wafer flow 
        ''' return true if wafer flow name is in waferflow list
        'string active sequence in loadlock A&B
        Dim sLLASegID As String = ContainerForm.ProcessPanel.lpcLoadLockA.SeqID

        'loadlock A & loadlock B is not start -> delete ok
        If ContainerForm.ProcessPanel.lpcLoadLockA.btnStart.Text = START Then
            ''scheduler is running
            Return False
        End If

        If Not (ContainerForm.ProcessPanel.lpcLoadLockA.btnStart.Text = START) Then
            'loadlock A is starting 
            'get sequence name in loadlockA
            'read warfer flow on it

            'get loadlock A
            Dim blResult As Boolean
            blResult = CheckWaferFlowInSequence(WaferFlowName, ContainerForm.ProcessPanel.lpcLoadLockA.SeqID)
            If blResult = True Then
                Return True
            End If
        End If

       
        '''else return false
        Return False
    End Function
    'Check Wafer is existed in list seqquence
    Private Function CheckWaferInListSeq(ByVal WaferFlows As String, ByRef Sequence As String) As Boolean
        Dim listSeq As String() = System.IO.Directory.GetFiles(AVPLib.ContainerDAO.FPath_SequenceData)
        For i As Integer = 0 To listSeq.Length - 1
            Dim currentSeq As String = AVPLib.Utils.GetFileName(listSeq(i), True)
            If CheckWaferFlowInSequence(WaferFlows, currentSeq) Then
                Sequence = currentSeq
                Return True
            End If
        Next

        Return False
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' Delete WaferFlow
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>   
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        AVPLib.Log.guiLogger.Info("Enter btnDelete_Click")
        Try

            Dim arrWaferFlow As ArrayList = Nothing
            arrWaferFlow = AVPLib.ContainerData.GetAllWaferFlowName
            ''open dialog for WaferFlow
            Dim waferDlg As New SelectWaferFlow(arrWaferFlow, True)
            waferDlg.ShowDialog()
            If waferDlg.DialogResult = Windows.Forms.DialogResult.OK And waferDlg.ListSelectedFlow.Count = 1 Then
                Dim item As AVPLib.DataManagerment.WaferFlow = waferDlg.ListSelectedFlow.Item(0)
                If item Is Nothing Then
                    Return
                End If
                If Utils.ShowAVPMessageBox("Do you want to delete WaferFlow " & item.WaferFlowName & " ?", "Delete WaferFlow ", MessageBoxIcon.Question) = DialogResult.OK Then
                    ''' dat.cao check wafer flow status
                    If IsWaferFlowInUseScheduler(item.WaferFlowName, "Delete", "delete") Then
                        Exit Try
                    End If
                    '"Customer request.  Recipe/wafer flow/sequence.   
                    'Recipe is at the lowest level and sequence is at the highest level.  
                    'Recipe deletion, we need to check to see if any wafer flow is using this recipe.  
                    ' Wafer flow deletion, we need to check to see if any "
                    'Begin fix
                    Dim Sequence As String = String.Empty
                    If CheckWaferInListSeq(item.WaferFlowName, Sequence) Then
                        Dim dlgcheck As DialogResult = Utils.ShowAVPMessageBox("Waferflow '" + item.WaferFlowName + "' is present in sequence " + Sequence + vbCrLf + " Do you want to continue ?", "Delete WaferFlow", MessageBoxIcon.Exclamation)
                        If dlgcheck = DialogResult.Cancel Then
                            Exit Try
                        End If
                    End If
                    'End
                    AVPLib.ContainerData.DeleteWaferFlow(item.WaferFlowName)
                    If (m_wfcurrentWfFlow IsNot Nothing AndAlso _
                       (item.WaferFlowName = m_wfcurrentWfFlow.WaferFlowName)) Then
                        m_wfcurrentWfFlow = Nothing
                        m_currentSelectedStart = Nothing
                        Title = NEW_WAFER_FLOW
                        txtDescription.Text = String.Empty
                        m_waferflowLoopInfo.LoopList.Clear()
                        pnlEquipmentRight.Controls.Clear()
                        pnlEquipmentRight.Refresh()
                        RefreshPanel()
                        Me.IsModifiedFlag = False
                    End If
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                   "[Main Screen] " + "Delete WaferFlow " & item.WaferFlowName)
                End If
                'Current version, not support to delete multi items in dialog box
                'so not checking invalid waferflow for this case
            ElseIf waferDlg.DialogResult = Windows.Forms.DialogResult.OK Then
                For Each item As AVPLib.DataManagerment.WaferFlow In waferDlg.ListSelectedFlow
                    Dim dlg As DialogResult = Utils.ShowAVPDeleteMultiMessageBox("Do you want to delete WaferFlows " & item.WaferFlowName & "?", "Delete WaferFlow", MessageBoxIcon.Question)
                    If dlg = DialogResult.Yes Then ''YesToAll
                        DeleteMulti(waferDlg)
                        Exit For
                    ElseIf dlg = DialogResult.OK Then ''Yes
                        If IsWaferFlowInUseScheduler(item.WaferFlowName, "Delete", "delete") Then
                            Exit Try
                        End If
                        '"Customer request.  Recipe/wafer flow/sequence.   
                        'Recipe is at the lowest level and sequence is at the highest level.  
                        'Recipe deletion, we need to check to see if any wafer flow is using this recipe.  
                        ' Wafer flow deletion, we need to check to see if any "
                        'Begin fix
                        Dim Sequence As String = String.Empty
                        If CheckWaferInListSeq(item.WaferFlowName, Sequence) Then
                            Dim dlgcheck As DialogResult = Utils.ShowAVPMessageBox("Waferflow '" + item.WaferFlowName + "' is present in sequence " + Sequence + vbCrLf + " Do you want to continue ?", "Delete WaferFlow", MessageBoxIcon.Exclamation)
                            If dlgcheck = DialogResult.Cancel Then
                                Exit Try
                            End If
                        End If
                        'End fix
                        AVPLib.ContainerData.DeleteWaferFlow(item.WaferFlowName)
                        If (m_wfcurrentWfFlow IsNot Nothing AndAlso _
                           (item.WaferFlowName = m_wfcurrentWfFlow.WaferFlowName)) Then
                            m_wfcurrentWfFlow = Nothing
                            m_currentSelectedStart = Nothing
                            Title = NEW_WAFER_FLOW
                            txtDescription.Text = String.Empty
                            m_waferflowLoopInfo.LoopList.Clear()
                            pnlEquipmentRight.Controls.Clear()
                            pnlEquipmentRight.Refresh()
                            RefreshPanel()
                            Me.IsModifiedFlag = False
                        End If
                    ElseIf dlg = DialogResult.Cancel Then 'cancel
                        Exit For
                    End If
                Next
            End If

            If ContainerForm.Secs_GemPanel.rbnWaferFlow.Checked Then
                RaiseEvent Reload_PPWFEvent(Nothing, Nothing)
            End If

            waferDlg.Dispose()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnDelete_Click")
    End Sub
    Private Sub DeleteMulti(ByVal WfDlg As SelectWaferFlow)
        Try
            For Each item As AVPLib.DataManagerment.WaferFlow In WfDlg.ListSelectedFlow
                If IsWaferFlowInUseScheduler(item.WaferFlowName, "Delete", "delete") Then
                    Exit For
                End If

                AVPLib.ContainerData.DeleteWaferFlow(item.WaferFlowName)
                If (m_wfcurrentWfFlow IsNot Nothing AndAlso _
                   (item.WaferFlowName = m_wfcurrentWfFlow.WaferFlowName)) Then
                    m_wfcurrentWfFlow = Nothing
                    m_currentSelectedStart = Nothing
                    Title = NEW_WAFER_FLOW
                    txtDescription.Text = String.Empty
                    m_waferflowLoopInfo.LoopList.Clear()
                    pnlEquipmentRight.Controls.Clear()
                    pnlEquipmentRight.Refresh()
                    RefreshPanel()
                    Me.IsModifiedFlag = False
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' btnRemove_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        AVPLib.Log.guiLogger.Info("Enter btnRemove_Click")
        Dim loopinfo As AVPLib.DataManagerment.WaferflowLoop = New AVPLib.DataManagerment.WaferflowLoop
        Dim iCount As Integer = Me.pnlEquipmentRight.Controls.Count
        Try
            ' If the current selected step was not selected
            If m_currentSelectedStep Is Nothing Then
                Return
            End If

            'remove in Loop
            If m_waferflowLoopInfo.isStartEndofLoop(m_currentSelectedStep.Index) = True Then
                m_waferflowLoopInfo.RemoveLoopInfo(m_currentSelectedStep.Index)
            End If

            'remove in panel
            RemoveControl(m_currentSelectedStep)
            RefreshPanel()
            pnlEquipmentRight.Refresh()
            m_currentSelectedStep = Nothing
            Me.IsModifiedFlag = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnRemove_Click")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-23-07</date>
    ''' </author>
    ''' <summary>
    '''Remove by Name
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Sub RemoveControl(ByVal control As usrEquipmentName)
        AVPLib.Log.coreLogger.Info("Enter RemoveByName")
        Try
            'remove
            If control IsNot Nothing Then
                pnlEquipmentRight.Controls.Remove(control)
                'update index 
                For Each ctlChamber As usrEquipmentName In Me.pnlEquipmentRight.Controls
                    If (ctlChamber.Index > control.Index) Then
                        ctlChamber.Index -= 1
                    End If
                Next
                'update loop information
                ' update loop information
                For Each loopInfo As WaferflowLoop In m_waferflowLoopInfo.LoopList
                    If loopInfo.LoopStart >= control.Index Then
                        loopInfo.LoopStart -= 1
                    End If
                    If loopInfo.LoopEnd >= control.Index Then
                        loopInfo.LoopEnd -= 1
                    End If
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave RemoveByName")
    End Sub

    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' btnRemove_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub btnRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click
        AVPLib.Log.guiLogger.Info("Enter btnRemoveAll_Click")
        Try
            m_currentSelectedStart = Nothing
            m_waferflowLoopInfo.LoopList.Clear()
            Me.pnlEquipmentRight.Controls.Clear()
            pnlEquipmentRight.Refresh()
            btnStart.Enabled = True
            btnEnd.Enabled = True
            Me.IsModifiedFlag = True

            m_currentSelectedStep = Nothing
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnRemoveAll_Click")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' btnStart_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        AVPLib.Log.guiLogger.Info("Enter btnStart_Click")
        Me.IsModifiedFlag = True
        Try

            ' If the current selected step was not selected
            If m_currentSelectedStep Is Nothing Then
                Return
            End If

            'Get index
            m_currentSelectedStart = m_currentSelectedStep
            'exists in the loop
            If m_waferflowLoopInfo.FindLoopByIndex(m_currentSelectedStart.Index) IsNot Nothing Then
                m_currentSelectedStart = Nothing
            End If
            pnlEquipmentRight.Refresh()
            m_currentSelectedStep.Focus()
            btnStart.Enabled = True
            btnEnd.Enabled = True
            btnCancel.Text = STR_CANCEL
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnStart_Click")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' btnCancel_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub btnCancelDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        AVPLib.Log.guiLogger.Info("Enter btnCancel_Click")
        Try
            If btnCancel.Text = STR_DELETE Then

                ' If the current selected step is selected
                If m_currentSelectedStep IsNot Nothing Then
                    'Delete was clicked
                    m_waferflowLoopInfo.RemoveLoopInfo(m_currentSelectedStep.Index)
                    m_currentSelectedStart = Nothing
                End If

            Else
                btnCancel.Text = STR_DELETE
                'Cancel was clicked
                m_currentSelectedStart = Nothing
            End If


            pnlEquipmentRight.Refresh()
            Me.IsModifiedFlag = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnCancel_Click")
    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-08-05</date>
    ''' </author>
    ''' <summary>
    ''' Refresh, to redraw the controls in the pannel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub RefreshPanel()
        Try
            For i As Integer = 0 To pnlEquipmentRight.Controls.Count - 1
                'get usercontrol [i]
                Dim mUrs As usrEquipmentName = pnlEquipmentRight.Controls.Item(i)
                'New Y
                'set location of usercontrol
                Dim iY As Integer = mUrs.Index * (mUrs.Bounds.Height + SPACE)
                iY += pnlEquipmentRight.AutoScrollPosition.Y + SPACE
                mUrs.Location = New Point(mUrs.Location.X, iY)
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' btnNew_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        AVPLib.Log.guiLogger.Info("Enter btnNew_Click")
        Try
            Dim strMessageText As String = String.Empty
            If Me.IsModifiedFlag = True Then
                strMessageText = AVPLib.ContainerData.GetMessageText("Wafer_Flow_New")
                If Utils.ShowAVPMessageBox("Current Wafer Flow was changed." & Chr(13) & "Do you want to save ?", "Save Wafer Flow", MessageBoxIcon.Question, MessageBoxButtons.YesNo) = DialogResult.OK Then
                    btnSaveAs_Click(sender, e)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                    AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                    "[Main Screen] " + "Confirm save current WaferFlow when create new WaferFlow.")
                End If
                btnStart.Enabled = False
                btnEnd.Enabled = False
            End If

            btnSave.Enabled = True
            btnSaveAs.Enabled = True
            btnDelete.Enabled = True

            m_wfcurrentWfFlow = Nothing
            m_currentSelectedStart = Nothing
            m_currentSelectedStep = Nothing
            Title = NEW_WAFER_FLOW
            txtDescription.Text = String.Empty
            m_waferflowLoopInfo.LoopList.Clear()
            pnlEquipmentRight.Controls.Clear()
            pnlEquipmentRight.Refresh()
            Me.IsModifiedFlag = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnNew_Click")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' btnNew_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub btnEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnd.Click
        AVPLib.Log.guiLogger.Info("Enter btnEnd_Click")
        Me.IsModifiedFlag = True
        Try
            ' If the current selected step was not selected
            If m_currentSelectedStep Is Nothing Then
                Return
            End If

            'Get index
            Dim iIndexClick As Integer = m_currentSelectedStep.Index

            'exists in the loop
            If m_waferflowLoopInfo.FindLoopByIndex(iIndexClick) IsNot Nothing Then
                ' do not process this case if user select the end that belong to a loop
                Exit Sub
            End If

            If m_currentSelectedStart IsNot Nothing Then

                ' If the start and the end is in the same step
                If iIndexClick = m_currentSelectedStart.Index Then
                    Return
                End If

                Dim loopinfo As AVPLib.DataManagerment.WaferflowLoop = New AVPLib.DataManagerment.WaferflowLoop

                'get start and end index
                loopinfo.LoopStart = m_currentSelectedStart.Index
                loopinfo.LoopEnd = m_currentSelectedStep.Index
                loopinfo.LoopCount = 1
                If txtRepeatCount.Text.Length > 0 Then
                    loopinfo.LoopCount = CInt(txtRepeatCount.Text)
                End If

                loopinfo.LoopNo = m_intLoopCount
                m_intLoopCount += 1

                'Just to make sure the start is always smaller than End
                If loopinfo.LoopStart > loopinfo.LoopEnd Then
                    Dim iTemp As Integer = loopinfo.LoopEnd
                    loopinfo.LoopEnd = loopinfo.LoopStart
                    loopinfo.LoopStart = iTemp
                End If

                ' reset the start value
                m_currentSelectedStart = Nothing

                'add to loop
                m_waferflowLoopInfo.Add(loopinfo)

                pnlEquipmentRight.Refresh()
                btnStart.Enabled = True
                btnCancel.Enabled = True
                txtRepeatCount.Enabled = True
                m_currentSelectedStep.Focus()
                btnCancel.Text = STR_DELETE
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnEnd_Click")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' not permit user input value = 0,1,01,00 in textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub txtRepeatCount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRepeatCount.LostFocus
        If txtRepeatCount.Text = String.Empty OrElse CInt(txtRepeatCount.Text) <= 1 Then
            txtRepeatCount.Text = 2
        End If
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' txtRepeatCount_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub txtRepeatCount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRepeatCount.TextChanged
        AVPLib.Log.guiLogger.Info("Enter txtRepeatCount_TextChanged")
        Try
            If m_currentSelectedStep IsNot Nothing Then
                Dim Item As WaferflowLoop = m_waferflowLoopInfo.FindLoopByIndex(m_currentSelectedStep.Index)
                If (Item IsNot Nothing And txtRepeatCount.Text <> String.Empty) Then
                    Item.LoopCount = CInt(txtRepeatCount.Text)
                End If
                Me.pnlEquipmentRight.Refresh()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txtRepeatCount_TextChanged")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-23-07</date>
    ''' </author>
    ''' <summary>
    '''Find By Index
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindByIndex(ByVal pIndexID As Integer) As usrEquipmentName
        AVPLib.Log.coreLogger.Info("Enter FindByIndex")
        Try
            For Each ctlChamber As usrEquipmentName In Me.pnlEquipmentRight.Controls
                If (ctlChamber.Index = pIndexID) Then
                    Return ctlChamber
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave FindByIndex")
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-23-07</date>
    ''' </author>
    ''' <summary>
    '''Up Index
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UpIndex(ByVal pIndexID As Integer) As Boolean
        AVPLib.Log.coreLogger.Info("Enter UpIndex")
        Dim mPreItem As usrEquipmentName = FindByIndex(pIndexID - 1)
        Dim CurrentItem As usrEquipmentName = FindByIndex(pIndexID)
        Swap(mPreItem, CurrentItem)
        AVPLib.Log.guiLogger.Info("Leave UpIndex")
        Return True
    End Function
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-23-07</date>
    ''' </author>
    ''' <summary>
    '''Down Index
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DownIndex(ByVal pIndexID As Integer) As Boolean
        AVPLib.Log.coreLogger.Info("Enter DownIndex")
        Dim mDownItem As usrEquipmentName = FindByIndex(pIndexID + 1)
        Dim CurrentItem As usrEquipmentName = FindByIndex(pIndexID)
        Swap(mDownItem, CurrentItem)
        AVPLib.Log.guiLogger.Info("Leave DownIndex")
    End Function
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-23-07</date>
    ''' </author>
    ''' <summary>
    '''Swap
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub Swap(ByVal Preitem As usrEquipmentName, ByVal currentItem As usrEquipmentName)
        AVPLib.Log.coreLogger.Info("Enter Swap")
        If Preitem Is Nothing Or currentItem Is Nothing Then
            Return
        End If
        Dim itmpIndex As String = Preitem.Index
        Preitem.Index = currentItem.Index
        currentItem.Index = itmpIndex

        AVPLib.Log.guiLogger.Info("Leave Swap")
    End Sub

    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' btnUp_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        'get current position
        AVPLib.Log.guiLogger.Info("Enter btnUp_Click")
        Dim iCount As Integer = Me.pnlEquipmentRight.Controls.Count
        Dim iIndex As Integer = 0
        Try
            ' If the current selected step was not selected
            If m_currentSelectedStep Is Nothing Then
                Return
            End If

            'Swap Index
            UpIndex(m_currentSelectedStep.Index)
            'add to Loop
            'clear the start index
            m_currentSelectedStart = Nothing

            pnlEquipmentRight.Refresh()
            RefreshPanel()
            m_currentSelectedStep.Focus()
            Me.IsModifiedFlag = True

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnUp_Click")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' btnDown_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        'get current position
        AVPLib.Log.guiLogger.Info("Enter btnDown_Click")
        Dim iCount As Integer = Me.pnlEquipmentRight.Controls.Count
        Dim iIndex As Integer = 0
        Try
            ' If the current selected step was not selected
            If m_currentSelectedStep Is Nothing Then
                Return
            End If

            DownIndex(m_currentSelectedStep.Index)

            'clear the start index
            m_currentSelectedStart = Nothing

            pnlEquipmentRight.Refresh()
            RefreshPanel()
            m_currentSelectedStep.Focus()
            Me.IsModifiedFlag = True

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnDown_Click")
    End Sub
#End Region

    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-08-07</date>
    ''' </author>
    ''' <summary>
    ''' Mouse up click, will find the clicked control to high light the selected control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub pnlEquipmentRight_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlEquipmentRight.MouseUp
        Try
            Const X_INSIDE_CONTROL As Integer = 50
            Dim clickedStep As usrEquipmentName = Nothing
            ' check to get the righ control
            clickedStep = pnlEquipmentRight.GetChildAtPoint(New Point(X_INSIDE_CONTROL, e.Y))
            If (clickedStep Is Nothing) Then
                ' user might click into a space
                'then we try to find in the -SPACE position
                clickedStep = pnlEquipmentRight.GetChildAtPoint(New Point(X_INSIDE_CONTROL, e.Y - SPACE))
                ' then we try to find in the +SPACE position
                If (clickedStep Is Nothing) Then
                    clickedStep = pnlEquipmentRight.GetChildAtPoint(New Point(X_INSIDE_CONTROL, e.Y + SPACE))
                End If
            End If

            If (clickedStep IsNot Nothing) Then
                clickedStep.Focus()
                clickedStep.usrEquipmentName_Click(clickedStep, Nothing)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-08-10</date>
    ''' </author>
    ''' <summary>
    ''' Change the description
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub txtDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.TextChanged
        Me.IsModifiedFlag = True
    End Sub

    Private Sub txtDescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescription.Click
        Dim pad As New KeyPad
        Dim Value As String = txtDescription.Text
        If pad.DisplayKeypad(Value, "Please input the description", False) = DialogResult.OK Then
            txtDescription.Text = Value
        End If
    End Sub

    Private Sub txtRepeatCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRepeatCount.Click
        Dim frm As New NumPad()
        Dim Value As String = txtRepeatCount.Text
        If frm.GetUserInput(Value, -1, -1, 1, 1000, "Please input the repeat count", 0, True, False) = MsgBoxResult.Ok Then
            txtRepeatCount.Text = Value
        End If
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-09-17 </date>
    ''' </author>
    ''' <summary>
    ''' IsWaferFlowInUseScheduler
    ''' </summary>
    ''' <param name=""></param>
    ''' <param name=""></param>
    ''' <remarks></remarks>
    Private Function IsWaferFlowInUseScheduler(ByVal sFileName As String, ByVal sTitleOfErrorMsg As String, ByVal sErrorMsg As String) As Boolean
        Dim blResult As Boolean = False
        Try
            blResult = CheckWaferFlowInUse(sFileName)
            If blResult Then
                Utils.ShowAVPMessageBox("This waferflow in use. Can not " & sErrorMsg, sTitleOfErrorMsg, MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                      AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                      "[Main Screen] This waferflow in use. Can not " & sErrorMsg)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blResult
    End Function

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-11-19</date>
    ''' </author>
    ''' <summary>
    ''' save config show reworkFiles
    ''' </summary>
    Private Sub cbxShowReworkFiles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxShowReworkFiles.CheckedChanged
        Try
            Utils.SaveShowReworkFiles(cbxShowReworkFiles.Checked)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-11-19</date>
    ''' </author>
    ''' <summary>
    ''' refresh data
    ''' </summary>
    Public Function RefreshData() As Boolean
        Try
            If AVPLib.ContainerDAO.EnableReworkFeature() Then
                cbxShowReworkFiles.Checked = AVPLib.ContainerDAO.ReadShowReworkFiles()
            Else
                cbxShowReworkFiles.Visible = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function
End Class






