Imports AVPLib.ConstEnum
Imports AVPLib
Imports AVP_Robot_Project.ConstantAndEnum
Public Class CycleATMPanel

#Region "Private Methods"
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartATM.Click
        Try
            Dim strLLName As String = "LLA"
            Dim avpMsgBox As AVPMessageBox = Nothing
            Dim strLL As String = ConstantAndEnum.LOAD_LOCK_A

            Select Case Me.btnStartATM.Text
                Case START
                    avpMsgBox = New AVPMessageBox("Start Cycle ATM", "Would you like to start Cycle ATM in " + strLLName, MessageBoxIcon.Question)
                    avpMsgBox.ShowDialog()
                    If avpMsgBox.DialogResult <> DialogResult.OK Then
                        Exit Try
                    End If

                    Dim objavpCtrlJob As AVPLib.Business.AVPControlJob = Nothing
                    Dim objLoadLockCtrl As AVPLib.Business.LoadLockController = Nothing
                    Dim objLoadLock As AVPLib.DataManagerment.LoadLock = Nothing

                    ''Check LLA process is running
                    If Me.rbCycleLLA.Visible = True Then
                        If Me.rbCycleLLA.Checked Then
                            objLoadLock = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
                        End If

                        objLoadLockCtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
                        objavpCtrlJob = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockCtrl.CtrlJobId)
                        If objavpCtrlJob IsNot Nothing Then
                            Utils.ShowAVPMessageBox("Process is running", "Start", MessageBoxIcon.Error, MessageBoxButtons.OK)
                            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                                  AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                                  "[Main Screen] " + "Error in start Cycle ATM")
                            Exit Try
                        End If
                    End If

                    ''Save wafer flow
                    If SavingWaferFlow() = False Then
                        Exit Try
                    End If

                    ''Save seqence
                    If SaveSequence() = False Then
                        Exit Try
                    End If

                    ''Copy recipe file
                    If CopyAllReciesToRecipeChamber() = False Then
                        Exit Try
                    End If

                    Dim checkSequenceResult As AVPLib.ConstEnum.CustomRemoteCommandResult
                    Dim checkValidSequence As Boolean = AVPLib.SequenceLib.CheckInvalidSequence(SEQUENCE_CYCLEATM, strLL, checkSequenceResult)
                    If Not checkValidSequence Then
                        If checkSequenceResult = CustomRemoteCommandResult.SEQUENCE_IS_NOT_EXISTED Then
                            Utils.ShowAVPMessageBox("Sequence Sequence_CycleATM is no longer exist.", "Start Cycle ATM", MessageBoxIcon.Error, MessageBoxButtons.OK)
                            Exit Try
                        End If
                    End If

                    objLoadLock.IsCycleInATM_Mode = True
                    objLoadLock.IsWithoutMotion = rbCycleWithoutMotion.Checked

                    ''Update SequenceID and LotID
                    Dim LotID As String = "LotID_CycleATM_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")
                    Dim strValue As String = LotID + "," + SEQUENCE_CYCLEATM
                    objLoadLock.LotID = LotID
                    objLoadLock.SequenceID = SEQUENCE_CYCLEATM

                    m_stoStatusObject.RequestStatus(btnStartATM.Name + "_" + strLLName, strValue)

                Case "ABORT"
                    avpMsgBox = New AVPMessageBox("Abort Cycle ATM", "Would you like to Abort Cycle ATM", MessageBoxIcon.Question)
                    avpMsgBox.ShowDialog()
                    If avpMsgBox.DialogResult <> DialogResult.OK Then
                        Exit Try
                    End If
                    m_stoStatusObject.RequestStatus(btnStartATM.Name + "_" + strLLName, "Click Abort")

            End Select

        Catch ex As Exception

        End Try
    End Sub

    '' <author>
    ''    	<name> Dua Tran </name>
    ''    	<date> 2017-10-06</date>
    '' </author>
    '' <summary>
    '' Save WaferFlow
    '' </summary>  
    Private Function SavingWaferFlow() As Boolean
        AVPLib.Log.guiLogger.Info("Enter SavingWaferFlow")
        Dim blnSuccess As Boolean = False
        Try
            Dim wfflow As New AVPLib.DataManagerment.WaferFlow
            If Me.StoreGuiInToWaferFlow(wfflow) = False Then
                Exit Try
            End If

            If Not CheckExistWaferFlow(WAFER_CYCLEATM) Then
                blnSuccess = AVPLib.ContainerData.SaveWaferFlow(wfflow, True)
            Else

                If (AVPLib.Utils.IsAbleOpenFilesInEditor(WAFER_CYCLEATM, False, True, False)) Then
                    blnSuccess = AVPLib.ContainerData.SaveWaferFlow(wfflow, True)
                End If
            End If

            If blnSuccess Then
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                                 AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                                 "[Main Screen] " + "Save WaferFlow  " & WAFER_CYCLEATM & " successfully")
            Else
                Utils.ShowAVPMessageBox("Error in saving wafer flow", "Save", MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                      AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                      "[Main Screen] " + "Error in saving WaferFlow")
            End If

        Catch ex As Exception
            AVPLib.Log.guiLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave SavingWaferFlow")
        Return blnSuccess
    End Function

    '' <author>
    ''    	<name>Dua Tran</name>
    ''    	<date> 2017-10-06</date>
    '' </author>
    '' <summary>
    '' Show Wafer In Gui
    '' </summary>
    '' <param name="map">contain WaferFlow</param>
    '' <remarks></remarks>   
    Private Function StoreGuiInToWaferFlow(ByRef wfflow As AVPLib.DataManagerment.WaferFlow) As Boolean
        AVPLib.Log.guiLogger.Info("Enter StoreGuiInToWaferFlow")
        Dim bResult As Boolean = False

        Try


            Dim index As Integer = -1
            Dim loopItem As New AVPLib.DataManagerment.WaferflowLoop
            Dim arlStepList As New ArrayList
            Dim arlLoopList As New ArrayList
            Dim recipeName As String = String.Empty
            Dim chamberName As String = String.Empty
            Dim recipeAliger As String = String.Empty
            Dim blnAligner As Boolean = False

            If Me.cbAlignerRecipe.Items.Count > 0 AndAlso Me.cbAlignerRecipe.SelectedIndex > -1 Then
                blnAligner = True
                recipeAliger = Me.cbAlignerRecipe.SelectedItem.ToString()
            End If

            'cbxPM1
            If Me.cbxPM1.Visible AndAlso Me.cbxPM1.Checked Then
                'Aligner
                If blnAligner Then
                    index = index + 1
                    arlStepList.Add(StepList(index, recipeAliger, STR_ALGINER))
                End If
                'Chamber
                index = index + 1
                GetRecipeChamber(Me.cbxPM1.Tag.ToString(), recipeName, chamberName)
                arlStepList.Add(StepList(index, recipeName, chamberName))
            End If

            'cbxPM2
            If Me.cbxPM2.Visible AndAlso Me.cbxPM2.Checked Then
                'Aligner
                If blnAligner Then
                    index = index + 1
                    arlStepList.Add(StepList(index, recipeAliger, STR_ALGINER))
                End If
                'Chamber
                index = index + 1
                GetRecipeChamber(Me.cbxPM2.Tag.ToString(), recipeName, chamberName)
                arlStepList.Add(StepList(index, recipeName, chamberName))
            End If

            'cbxPM3
            If Me.cbxPM3.Visible AndAlso Me.cbxPM3.Checked Then
                'Aligner
                If blnAligner Then
                    index = index + 1
                    arlStepList.Add(StepList(index, recipeAliger, STR_ALGINER))
                End If
                'Chamber
                index = index + 1
                GetRecipeChamber(Me.cbxPM3.Tag.ToString(), recipeName, chamberName)
                arlStepList.Add(StepList(index, recipeName, chamberName))
            End If

            'cbxPM4
            If Me.cbxPM4.Visible AndAlso Me.cbxPM4.Checked Then
                'Aligner
                If blnAligner Then
                    index = index + 1
                    arlStepList.Add(StepList(index, recipeAliger, STR_ALGINER))
                End If
                'Chamber
                index = index + 1
                GetRecipeChamber(Me.cbxPM4.Tag.ToString(), recipeName, chamberName)
                arlStepList.Add(StepList(index, recipeName, chamberName))
            End If

            'cbxPM5
            If Me.cbxPM5.Visible AndAlso Me.cbxPM5.Checked Then
                'Aligner
                If blnAligner Then
                    index = index + 1
                    arlStepList.Add(StepList(index, recipeAliger, STR_ALGINER))
                End If
                'Chamber
                index = index + 1
                GetRecipeChamber(Me.cbxPM1.Tag.ToString(), recipeName, chamberName)
                arlStepList.Add(StepList(index, recipeName, chamberName))
            End If

            'cbxPM6
            If Me.cbxPM6.Visible AndAlso Me.cbxPM6.Checked Then
                'Aligner
                If blnAligner Then
                    index = index + 1
                    arlStepList.Add(StepList(index, recipeAliger, STR_ALGINER))
                End If
                'Chamber
                index = index + 1
                GetRecipeChamber(Me.cbxPM6.Tag.ToString(), recipeName, chamberName)
                arlStepList.Add(StepList(index, recipeName, chamberName))
            End If

            If index = 0 Then
                Utils.ShowAVPMessageBox(STR_WAFERFLOW_NOFLOW, "Error", MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                      AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                      "[Main Screen] " + "Save WaferFlow error : " & STR_WAFERFLOW_NOFLOW)
            ElseIf Me.cbAlignerRecipe.SelectedIndex = -1 Then
                Utils.ShowAVPMessageBox(STR_NO_SELECT_ALIGNER, "Error", MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                      AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                      "[Main Screen] " + "Save WaferFlow error : " & STR_NO_SELECT_ALIGNER)
            Else
                wfflow.StepList = arlStepList
                wfflow.LoopList = arlLoopList
                wfflow.WaferFlowName = WAFER_CYCLEATM
                wfflow.Description = WAFER_CYCLEATM
                bResult = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave StoreGuiInToWaferFlow")
        Return bResult
    End Function

    '' <author>
    ''    	<name>Dua Tran</name>
    ''    	<date> 2017-10-06</date>
    '' </author>
    '' <summary>
    '' Get step list
    '' </summary>
    '' <param/>
    Private Function StepList(ByVal indexStep As Integer, ByVal recipeName As String, ByVal arlStationName As String) As AVPLib.DataManagerment.WaferflowStep
        Dim stepItem As New AVPLib.DataManagerment.WaferflowStep
        Dim arlStation As New ArrayList
        Try
            arlStation.Add(arlStationName)
            stepItem.StationList = arlStation
            stepItem.Number = indexStep
            stepItem.RecipeName = recipeName

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return stepItem
    End Function

    '' <author>
    ''    	<name>Dua Tran</name>
    ''    	<date> 2017-10-06</date>
    '' </author>
    '' <summary>
    '' Get recipe chamber
    '' </summary>
    '' <param/>
    Private Sub GetRecipeChamber(ByVal tag As String, ByRef recipeName As String, ByRef chamberName As String)
        Try
            recipeName = tag.Substring(Me.cbxPM1.Tag.ToString().IndexOf(".") + 1)
            chamberName = tag.Substring(0, Me.cbxPM1.Tag.ToString().IndexOf("."))
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-10-11</date>
    ''' </author>
    ''' <summary>
    ''' Check Existing of WaferFlow
    ''' </summary>
    ''' <param name="map">contain WaferFlow</param>
    ''' <remarks></remarks>   
    Private Function CheckExistWaferFlow(ByVal WfFlowName As String) As Boolean
        AVPLib.Log.guiLogger.Info("Enter CheckExistWaferFlow")
        Dim bSuccess As Boolean = False
        Try
            Dim arrWaferFlow As ArrayList = Nothing
            arrWaferFlow = AVPLib.ContainerData.GetAllWaferFlowName
            If arrWaferFlow.Contains(WfFlowName) Then
                bSuccess = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CheckExistWaferFlow")
        Return bSuccess
    End Function

    '' <author>
    ''    	<name> Dua Tran </name>
    ''    	<date> 2017-10-06</date>
    '' </author>
    '' <summary>
    '' Save WaferFlow
    '' </summary> 
    Private Function SaveSequence() As Boolean
        AVPLib.Log.guiLogger.Info("Enter SaveSequence")
        Dim bResult As Boolean = False
        Try
            Dim lstwaferInfor As New ArrayList
            Dim LoadLockElevator As DataManagerment.LLElevator

            If Me.rbCycleLLA.Visible AndAlso Me.rbCycleLLA.Checked Then
                LoadLockElevator = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
            Else
                Utils.ShowAVPMessageBox(STR_NO_SELECT_LOADLOCK, "Error", MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                      AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                      "[Main Screen] Create Sequence_CycleATM failed. No select load lock ")
                Exit Try
            End If

            If LoadLockElevator IsNot Nothing Then
                Dim arrWaferOfLoadLock As AVPLib.AVPWaferInfo() = LoadLockElevator.ListOfWaferInfo()
                For i As Integer = 0 To arrWaferOfLoadLock.Length - 1
                    Dim waferInfo As AVPWaferInfo = arrWaferOfLoadLock(i)
                    If waferInfo IsNot Nothing AndAlso waferInfo.WaferStatus <> enumWaferStatus.eWaferComplete Then
                        lstwaferInfor.Add(waferInfo.SlotID.ToString())
                    End If
                Next
            End If

            If lstwaferInfor.Count = 0 Then
                Utils.ShowAVPMessageBox(STR_NO_WAFER, "Error", MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                      AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                      "[Main Screen] Create Sequence_CycleATM failed. No has wafer in Loadlock ")
                Exit Try
            Else
                Dim currentSeqWaferFlow As AVPLib.DBWaferList
                Dim arrWaferList As New ArrayList

                For i As Integer = 0 To lstwaferInfor.Count - 1
                    Dim WFSlot As New AVPLib.DBWaferSlot
                    Dim WFSequence As New AVPLib.DBWaferSeq
                    Dim arrSeqStepList As New ArrayList
                    Dim arrStepList As New List(Of String)

                    WFSlot.Slot = lstwaferInfor(i).ToString()
                    WFSequence.SeqName = WAFER_CYCLEATM
                    WFSequence.SeqStepList = arrSeqStepList
                    WFSequence.StepList = arrStepList
                    WFSlot.WaferSequence = WFSequence
                    arrWaferList.Add(WFSlot)
                Next

                currentSeqWaferFlow = New AVPLib.DBWaferList
                currentSeqWaferFlow.WaferList = arrWaferList

                If AVPLib.ContainerData.ListSequenceName.Contains(SEQUENCE_CYCLEATM) Then
                    If (AVPLib.Utils.IsAbleOpenFilesInEditor(SEQUENCE_CYCLEATM, False, False, True)) Then
                        bResult = AVPLib.ContainerData.UpdateWFSequence(currentSeqWaferFlow, SEQUENCE_CYCLEATM, SEQUENCE_CYCLEATM)
                    End If
                Else
                    bResult = AVPLib.ContainerData.SaveWFSequence(currentSeqWaferFlow, SEQUENCE_CYCLEATM, SEQUENCE_CYCLEATM)
                End If

            End If

        Catch ex As Exception
            AVPLib.Log.guiLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave SaveSequence")
        Return bResult
    End Function

    '' <author>
    ''    	<name> Dua Tran </name>
    ''    	<date> 2017-10-06</date>
    '' </author>
    '' <summary>
    '' Copy all recies to recipe chamber
    '' </summary> 
    Private Function CopyAllReciesToRecipeChamber() As Boolean
        AVPLib.Log.guiLogger.Info("Enter CopyAllReciesToRecipeChamber")
        Dim bResult As Boolean = True
        Try
            If RobotConfigurationValues.CHAMBER1_VISIBLE Then
                bResult = bResult And CopyRecipe(ConstEnum.Equipments.Chamber1.ToString(), RobotConfigurationValues.CHAMBER1_TYPE)
            End If
            If RobotConfigurationValues.CHAMBER2_VISIBLE Then
                bResult = bResult And CopyRecipe(ConstEnum.Equipments.Chamber2.ToString(), RobotConfigurationValues.CHAMBER2_TYPE)
            End If
            If RobotConfigurationValues.CHAMBER3_VISIBLE Then
                bResult = bResult And CopyRecipe(ConstEnum.Equipments.Chamber3.ToString(), RobotConfigurationValues.CHAMBER3_TYPE)
            End If
        Catch ex As Exception
            AVPLib.Log.guiLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CopyRecie")
        Return bResult
    End Function

    '' <author>
    ''    	<name> Dua Tran </name>
    ''    	<date> 2017-10-06</date>
    '' </author>
    '' <summary>
    '' CopyRecipe
    '' </summary> 
    Private Function CopyRecipe(ByVal chamber As String, ByVal type As SystemModule.ModuleType) As Boolean
        AVPLib.Log.guiLogger.Info("CopyRecipe")
        Dim bResult As Boolean = False
        Try
            Dim desFileName As String = String.Empty
            Dim sourceFileName As String = String.Empty
            Dim recipeName As String = type.ToString()
            Select Case type
                Case SystemModule.ModuleType.PVD4
                    recipeName = PVD4_CYLEATM
                    sourceFileName = STR_CYCELATM_RECEPE_FILE_PATH + "\" + PVD4_CYLEATM + STR_XML_EXT
                    desFileName = STR_DATA_FILES + "\" + STR_RECIPES + "\" + chamber + "\" + PVD4_CYLEATM + STR_XML_EXT
            End Select

            ''Check recipe filesource is exists
            If Not System.IO.File.Exists(sourceFileName) Then
                Utils.ShowAVPMessageBox(recipeName + " is not exists", "Start", MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                      AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                      "[Main Screen] " + "Error in Start Cycle ATM")
                Exit Try
            End If

            System.IO.File.Copy(sourceFileName, desFileName, True)
            bResult = True
        Catch ex As Exception
            AVPLib.Log.guiLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CopyRecie")
        Return bResult
    End Function

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-10-05</date>
    ''' </author>
    ''' <summary>
    ''' LabelComboBox
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetTextComboBox(ByVal chamberStyle As SystemModule.ModuleType, ByVal PMIndex As Int16, ByRef tag As String) As String
        Try
            Select Case chamberStyle
                Case SystemModule.ModuleType.IBE
                    tag = AVPLib.ConstEnum.Chamber + PMIndex.ToString() + "." + IBE_CYCLEATM
                    Return STR_PM + PMIndex.ToString() + " (" + STR_IBE + ")"
                Case SystemModule.ModuleType.PVD
                    tag = AVPLib.ConstEnum.Chamber + PMIndex.ToString() + "." + PVD_CYLEATM
                    Return STR_PM + PMIndex.ToString() + " (" + STR_PVD + ")"
                Case SystemModule.ModuleType.PVD4
                    tag = AVPLib.ConstEnum.Chamber + PMIndex.ToString() + "." + PVD4_CYLEATM
                    Return STR_PM + PMIndex.ToString() + " (" + STR_PVD4 + ")"
            End Select

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-10-05</date>
    ''' </author>
    ''' <summary>
    ''' Visiable ComboBox
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub VisiableCheckBoxChamber(ByVal PM As Int16, ByVal chamberStyle As SystemModule.ModuleType, ByVal index As Int16)
        Try
            Select Case PM
                Case 1
                    Me.cbxPM1.Visible = True
                    Me.cbxPM1.Checked = False
                    Me.cbxPM1.Text = GetTextComboBox(chamberStyle, index, Me.cbxPM1.Tag)
                Case 2
                    Me.cbxPM2.Visible = True
                    Me.cbxPM2.Checked = False
                    Me.cbxPM2.Text = GetTextComboBox(chamberStyle, index, Me.cbxPM2.Tag)
                Case 3
                    Me.cbxPM3.Visible = True
                    Me.cbxPM3.Checked = False
                    Me.cbxPM3.Text = GetTextComboBox(chamberStyle, index, Me.cbxPM3.Tag)
                Case 4
                    Me.cbxPM4.Visible = True
                    Me.cbxPM4.Checked = False
                    Me.cbxPM4.Text = GetTextComboBox(chamberStyle, index, Me.cbxPM4.Tag)
                Case 5
                    Me.cbxPM5.Visible = True
                    Me.cbxPM5.Checked = False
                    Me.cbxPM5.Text = GetTextComboBox(chamberStyle, index, Me.cbxPM5.Tag)
                Case 6
                    Me.cbxPM6.Visible = True
                    Me.cbxPM6.Checked = False
                    Me.cbxPM6.Text = GetTextComboBox(chamberStyle, index, Me.cbxPM6.Tag)
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-10-05</date>
    ''' </author>
    ''' <summary>
    ''' Get lis aligner
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetListAligner()
        Try
            Dim m_listData As ArrayList = AVPLib.ContainerData.ListChamber(AVPLib.ConstEnum.Equipments.Aligner.ToString())
            If m_listData.Count > 0 Then
                Dim item As String
                For Each item In m_listData
                    Me.cbAlignerRecipe.Items.Add(item)
                Next
                Me.cbAlignerRecipe.SelectedIndex = 0
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-10-05</date>
    ''' </author>
    ''' <summary>
    ''' Load gui from robot configuration
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadGuiFromRobotConfiguration()
        Try
            Dim MaxPM As Int16 = 0
            If RobotConfigurationValues.CHAMBER1_VISIBLE Then
                MaxPM = MaxPM + 1
                VisiableCheckBoxChamber(MaxPM, RobotConfigurationValues.CHAMBER1_TYPE, 1)
            End If
            If RobotConfigurationValues.CHAMBER2_VISIBLE Then
                MaxPM = MaxPM + 1
                VisiableCheckBoxChamber(MaxPM, RobotConfigurationValues.CHAMBER2_TYPE, 2)
            End If
            If RobotConfigurationValues.CHAMBER3_VISIBLE Then
                MaxPM = MaxPM + 1
                VisiableCheckBoxChamber(MaxPM, RobotConfigurationValues.CHAMBER3_TYPE, 3)
            End If

            GetListAligner()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name>Dua Tran </name>
    '''    	<date> 2017-10-11</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim m_btnStartATM As New StatusButtonProcessStartATM(Me.btnStartATM)
            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(m_btnStartATM)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
End Class
