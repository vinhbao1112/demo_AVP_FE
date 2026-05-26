Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Public Class StatusButtonProcessStart
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_btnButton As Button
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the text box that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedButton() As Button
        Get
            Return m_btnButton
        End Get
        Set(ByVal value As Button)
            m_btnButton = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with text box that will be managed by this object
    ''' </summary>
    ''' <param name="btnButton"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal btnButton As Button)
        Try
            m_btnButton = btnButton
            Me.Name = btnButton.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Dat Do </name>
    '''     <date> 2009-04-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object and update UI
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            Dim lpcLoadLock As LockProcessControl = ContainerForm.ProcessPanel.lpcLoadLockA

            If Value = AVPLib.ConstEnum.MAPPING_FAIL OrElse Value = AVPLib.ConstEnum.MAPPING_SUCCESS Then
                'm_btnButton.Enabled = 
                lpcLoadLock.Enable_Disable_StartButton()
                Exit Sub
            End If
            If Value = PAUSE Or Value = REZUME Then
                'do nothing
                If m_btnButton.Text = "Starting" Then
                    Me.m_btnButton.Text = [STOP]
                    If lpcLoadLock.CheckingPermission Then
                        Me.m_btnButton.Enabled = lpcLoadLock.CheckCondition_Enable_StartButton()
                    End If
                    SchedulerIsRunning(True)
                End If

                If Not lpcLoadLock.btnAbort.Text = "Aborting" Then
                    If lpcLoadLock.CheckingPermission Then
                        lpcLoadLock.btnAbort.Enabled = True
                    End If

                    ''Update Gem Obj
                    If (Value <> REZUME) Then
                        AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.EXECUTING, ConstantAndEnum.LOAD_LOCK_A)
                    End If

                End If

                If Value = REZUME Then ''for resume
                    ProcessResumePJobs()
                End If

            ElseIf Value = START Then
                ' Scheduler is finished.
                SchedulerIsRunning(False)
                m_btnButton.Text = Value
                
                'Raise Event Process Incomplete to Gem
                Dim blnNeedToTriggerEventInComplete As Boolean = False
                blnNeedToTriggerEventInComplete = Utils.CheckWaferIncompleteInLoadLock(LOAD_LOCK_A, lpcLoadLock.SeqID)
                If blnNeedToTriggerEventInComplete Then
                    AVPLib.Business.AVPSecsGemLib.TriggerEvent(LOAD_LOCK_A, "ProcessingInCompleted")
                    AVPLib.Business.AVPSecsGemLib.MySecsGemObj.IsProcessReallyCompleted = False
                Else
                    AVPLib.Business.AVPSecsGemLib.MySecsGemObj.IsProcessReallyCompleted = True
                End If
                '''''''''''
                Utils.Lock_UnLockDiagnosticScreen(lpcLoadLock.ChamberInUse, LOAD_LOCK_A, False)
                lpcLoadLock.btnAbort.Text = "ABORT"
                lpcLoadLock.btnAbort.Enabled = False
                lpcLoadLock.EnableForm(True)

                '#04/26/2011 
                '#When scheduler complete, LL state should be complete instead of IDLE.
                '#Begin fix:
                If lpcLoadLock.m_blnStopSequenceByClickAbort Then
                    lpcLoadLock.lblFinishProcess.Text = SCHEDULER & "IDLE...  "
                Else
                    If Not lpcLoadLock.lblFinishProcess.Text.Contains(IDLE) Then
                        lpcLoadLock.lblFinishProcess.Text = SCHEDULER & "Completed...  "

                        If Not lpcLoadLock.m_blnStopSequenceByClickStop Then
                            lpcLoadLock.SendMailWhenSchedulerStatusChange(STR_COMPLETED)
                        End If
                    End If
                End If
                '#End fix
                Dim folderPath As String = AVPLib.ContainerDAO.FPath_TempData & "\" & ConstantAndEnum.LOAD_LOCK_A
                Utils.DeleteTempData(folderPath)

                If Parent.Name = ConstantAndEnum.LOADLOCKA Then
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.chkDisableChekingSensor.Enabled = True
                    ContainerForm.SystemSetup.cbAutoVentWhenProcessCompleted.Enabled = True
                End If

                ''Update Gem Obj
                AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, ConstantAndEnum.LOAD_LOCK_A)
            ElseIf Value = SEMI_TRANSFER_FINISH Then
                If m_btnButton.Text = START Then
                    If lpcLoadLock.btnAbort.Text = "ABORT" Then ' Semi Auto Transfer finished.
                        Dim objJobmanager As AVPLib.Business.AVPJobManager = Nothing
                        objJobmanager = AVPLib.Business.AVPCore.Instance().JobManager()
                        If (objJobmanager IsNot Nothing AndAlso _
                        objJobmanager.isAllJobInLoadLockFinished(ConstantAndEnum.LOAD_LOCK_A.ToString())) Then
                            lpcLoadLock.EnableForm(True)
                            Exit Sub
                        End If
                    End If
                End If
            End If
            If Not (Value = REZUME) Then
                HideQuestionMark()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub SchedulerIsRunning(ByVal blnIsRunning As Boolean)
        If Me.Parent.Name = ConstantAndEnum.LOADLOCKA Then
            ContainerForm.ProcessPanel.lpcLoadLockA.txtSeqID.Enabled = Not (blnIsRunning)
            ContainerForm.ProcessPanel.lpcLoadLockA.txtLotID.Enabled = Not (blnIsRunning)
        End If
    End Sub

    '[Khoi Ha, 03-05-2013]
    'LL autovent after process completed.   After process complete and before autovent sequence takes place,  
    'there is a 5s windows where “Start”/”Load”/”Unload” button is available for user to click on.   
    'This might cause some problems if user click on load/start while system is trying to autovent.
    Private Function VentOrUnloadIsRunning(ByVal sLoadlockName As String) As Boolean
        Dim blResult As Boolean = False

        Dim objLoadlockController As AVPLib.Business.LoadLockController = AVPLib.Business.ControllerManager.GetController(sLoadlockName)
        If (objLoadlockController IsNot Nothing AndAlso _
        (objLoadlockController.IsUnloadSegRunning() OrElse objLoadlockController.IsVentSeqRunning)) Then
            blResult = True
        End If

        Return blResult
    End Function
    Private Sub HideQuestionMark()
        Try
            Dim objQuestionMark As QuestionMarkControl = Nothing
            If Me.Parent.Name = ConstantAndEnum.LOADLOCKA Then
                objQuestionMark = ContainerForm.ProcessPanel.LLALeg.LLQuestionMark
            End If
            If ContainerForm.ProcessPanel.LLALeg.QuestionMark_Visible Then
                ContainerForm.ProcessPanel.LLALeg.QuestionMark_Visible = False
                objQuestionMark.Enabled = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private Sub ProcessResumePJobs()
        Try
            Dim waferInfo As AVPLib.AVPWaferInfo = Nothing
            Dim objLLElevator As AVPLib.DataManagerment.LLElevator = Nothing
            Dim objQuestionMark As QuestionMarkControl = Nothing
            Dim objLoadLockCtrl As AVPLib.Business.LoadLockController = Nothing
            If Me.Parent.Name = ConstantAndEnum.LOADLOCKA Then
                objLoadLockCtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
                objLLElevator = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLAElevator.ToString())
                objQuestionMark = ContainerForm.ProcessPanel.LLALeg.LLQuestionMark
            End If
            Dim objavpCtrlJob As AVPLib.Business.AVPControlJob = Nothing
            objavpCtrlJob = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockCtrl.CtrlJobId)
            If (objavpCtrlJob IsNot Nothing) Then
                Dim isShowQM As Boolean
                Dim listOfPausedJobIds As List(Of String) = objavpCtrlJob.GetPausedProcessJobs()
                For Each jobId As String In listOfPausedJobIds
                    waferInfo = objLLElevator.GetWaferInfo_ByJobId(jobId)
                    If waferInfo IsNot Nothing Then
                        If Not ContainerForm.ProcessPanel.LLALeg.QuestionMark_Visible Then
                            objQuestionMark.PausedJobID = jobId
                            ContainerForm.ProcessPanel.LLALeg.QuestionMark_Visible = True
                            objQuestionMark.Enabled = True
                            objQuestionMark.BringToFront()
                            isShowQM = True
                            Exit For
                            'Else
                            ' objQuestionMark.Visible = False
                        End If

                    End If
                Next
                If Not isShowQM Then
                    ContainerForm.ProcessPanel.LLALeg.QuestionMark_Visible = False
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
   
#End Region

End Class
