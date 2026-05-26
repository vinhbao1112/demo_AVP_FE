Imports System.Threading
Imports System.Text.RegularExpressions
Namespace Business
    Public Class ControllerManager
#Region "Class Constants & Variables"
        Private Shared m_htbChildController As Hashtable
        Private Shared m_MessagesLock As New Object
        Private Shared m_SemiCommand As String
#End Region

#Region "Properties"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Getc current ChildControllerf
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property ChildController() As Hashtable
            Get
                Return m_htbChildController
            End Get
            Set(ByVal value As Hashtable)
                m_htbChildController = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' GetController
        ''' </summary>
        ''' <param name="Equipment"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetController(ByVal Equipment As String) As ControllerObject
            Try
                AVPLib.Log.coreLogger.Info("Enter GetController")
                AVPLib.Log.coreLogger.Info("Leave GetController")
                If m_htbChildController IsNot Nothing Then
                    Return m_htbChildController.Item(Equipment)
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.ToString())
                Return Nothing
            End Try
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' GetController
        ''' </summary>
        ''' <param name="Equipment"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetLLController(ByVal EquipmentName As String) As ControllerObject
            Try
                AVPLib.Log.coreLogger.Info("Enter GetController")
                Dim Equipment As String = ConstEnum.Equipments.LLAElevator.ToString()
                If EquipmentName = ConstEnum.Equipments.LLAElevator.ToString() Then
                    Equipment = ConstEnum.Equipments.LoadLockA.ToString()
                End If
                AVPLib.Log.coreLogger.Info("Leave GetController")
                Return m_htbChildController.Item(Equipment)
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.ToString())
                Return Nothing
            End Try
        End Function
#End Region

#Region "Public methods"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Do task ControllerManager
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <remarks></remarks>
        Public Shared Sub DoTask(ByVal Message As String)
            AVPLib.Log.coreLogger.Info("Enter DoTask")

            AVPLib.Log.coreLogger.Warn("Parameter: Message = " & Message)

            Try
                If (Not String.IsNullOrEmpty(Message)) Then
                    Dim intPos As Integer = Message.IndexOf(".")
                    If (intPos > 0) Then
                        Dim strEquipementName As String = Message.Substring(0, intPos)
                        strEquipementName = Message.Substring(0, intPos)
                        Dim objValue As Object
                        SyncLock m_MessagesLock
                            objValue = m_htbChildController.Item(strEquipementName)
                        End SyncLock
                        If (objValue IsNot Nothing) Then
                            Dim ctlController As ControllerObject = CType(objValue, ControllerObject)
                            Message = Message.Substring(intPos + 1)
                            ctlController.DoTask(Message)
                        Else
                            intPos = Message.IndexOf(" ")
                            If (intPos > 0) Then
                                Dim strSource As String = Message.Substring(0, intPos)
                                Dim strFullCommand As String = Message.Substring(intPos + 1)
                                If (strSource.CompareTo("CassettesPanel.sccSerialCommand.btnSend") = 0) Then
                                    DoSerialCommand(strFullCommand)
                                ElseIf (strSource.CompareTo("CassettesPanel.stwSemiautoTransferWafer.btnStart") = 0) OrElse _
                                       (strSource.CompareTo("CassettesPanel.saSelfAligner.btnSelfAligner") = 0) Then
                                    SemiAutoTransfer(strFullCommand)
                                ElseIf strSource.CompareTo("ProcessPanel.CJReturn") = 0 Then
                                    SemiAutoTransferForCJReturn(strFullCommand)
                                ElseIf strSource.CompareTo("ProcessPanel.CJClearFreeJob") = 0 Then
                                    SemiAutoTransfer(strFullCommand, True)
                                ElseIf (strSource.CompareTo("ProcessPanel.lpcLoadLockA.btnStart") = 0) Then
                                    SyncLock m_MessagesLock
                                        objValue = m_htbChildController.Item(ConstEnum.Equipments.LoadLockA.ToString())
                                    End SyncLock
                                    Dim ctlController As ControllerObject = CType(objValue, ControllerObject)

                                    ctlController.DoTask(Message)
                                ElseIf strSource.CompareTo("ProcessPanel.lpcLoadLockA.txtTotal") = 0 Then
                                    Dim ctrLLA As LoadLockController = CType(GetController(ConstEnum.Equipments.LoadLockA.ToString()), LoadLockController)
                                    ctrLLA.ResetWaferCount()
                                ElseIf strSource.CompareTo("ProcessPanel.PJMarkForReturn") = 0 Then
                                    ProcessPanelPJMarkForReturn(strFullCommand)
                                ElseIf strSource.CompareTo("ProcessPanel.PJResume") = 0 Then
                                    ProcessPanelPJResume(strFullCommand)
                                ElseIf (strSource.CompareTo("CassettesPanel.lccLoadLockA.CreateWafer") = 0) Then
                                    Dim iSlot As Integer = Integer.Parse(strFullCommand)
                                    Dim waferinfo As AVPWaferInfo = New AVPWaferInfo( _
                                        Utils.GenerateWaferID(iSlot, ConstEnum.Equipments.LoadLockA.ToString()), _
                                        iSlot, ConstEnum.enumWaferStatus.eWaferNew)

                                    Dim LLAElevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
                                    LLAElevator.SetStatusGraph(iSlot, waferinfo)
                                    Utils.SavingWaferInfo(ConstEnum.Equipments.LoadLockA.ToString(), iSlot, waferinfo)
                                    ''Change status of Wafer
                                ElseIf (strSource.CompareTo("CassettesPanel.lccLoadLockA.ChangeWaferStatus") = 0) Then
                                    Dim LLAElevator As DataManagerment.LLElevator = _
                                         DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
                                    Dim iSlot As Integer = Integer.Parse(strFullCommand.Substring(0, strFullCommand.IndexOf("#")))
                                    Dim waferinfo As AVPWaferInfo = LLAElevator.ListOfWaferInfo(iSlot)
                                    If waferinfo Is Nothing Then
                                        AVPLib.Log.avpLogger.Error("Change status Wafer failed: " & strFullCommand)
                                        Exit Try
                                    End If
                                    Dim wfStatus As String = strFullCommand.Substring(strFullCommand.IndexOf("#") + 1)
                                    waferinfo.WaferStatus = [Enum].Parse(GetType(AVPLib.ConstEnum.enumWaferStatus), wfStatus, True)
                                    LLAElevator.SetStatusGraph(iSlot + 1, waferinfo)
                                    Utils.SavingWaferInfo(ConstEnum.Equipments.LoadLockA.ToString(), iSlot + 1, waferinfo)
                                    ''End Change Wafer status
                                ElseIf (strSource.CompareTo("CassettesPanel.lccLoadLockA.DeleteWafer") = 0) Then
                                    Dim Slot As Integer = Integer.Parse(strFullCommand)
                                    Dim LLAElevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
                                    LLAElevator.SetStatusGraph(Slot, Nothing)
                                    Utils.SavingWaferInfo(ConstEnum.Equipments.LoadLockA.ToString(), Slot, Nothing)
                                ElseIf (strSource.CompareTo("ProcessPanel.lpcLoadLockA.CheckOnlineLLA") = 0) Then
                                    Utils.ThrowAlarm("SystemOnlineLLAError", Utils.GemGetAlarmName(ConstEnum.Equipments.LoadLockA.ToString))
                                ElseIf strSource.CompareTo("ProcessPanel.lpcLoadLockA.CheckOnlineTM") = 0 Then
                                    Utils.ThrowAlarm("SystemOnlineTMError", Utils.GemGetAlarmName(ConstEnum.Equipments.CassettesModule.ToString))
                                ElseIf (strSource.CompareTo("CassettesPanel.WaferInsideChamber1") = 0) Then
                                    Dim cb As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
                                    Dim iSlot As Integer = 1
                                    Integer.TryParse(strFullCommand.Split(" ")(1), iSlot)
                                    Dim strValue As String = strFullCommand.Replace(iSlot.ToString, "").Trim()
                                    SetWaferInsideChamber(ConstEnum.Equipments.Chamber1.ToString(), strValue, cb.GetWaferInfo(iSlot), True, iSlot)

                                ElseIf (strSource.CompareTo("CassettesPanel.WaferInsideChamber2") = 0) Then
                                    Dim cb As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString())
                                    Dim iSlot As Integer = 1
                                    Integer.TryParse(strFullCommand.Split(" ")(1), iSlot)
                                    Dim strValue As String = strFullCommand.Replace(iSlot.ToString, "").Trim()
                                    SetWaferInsideChamber(ConstEnum.Equipments.Chamber2.ToString(), strValue, cb.GetWaferInfo(iSlot), True, iSlot)

                                ElseIf (strSource.CompareTo("CassettesPanel.WaferInsideChamber3") = 0) Then
                                    Dim cb As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString())
                                    Dim iSlot As Integer = 1
                                    Integer.TryParse(strFullCommand.Split(" ")(1), iSlot)
                                    Dim strValue As String = strFullCommand.Replace(iSlot.ToString, "").Trim()
                                    SetWaferInsideChamber(ConstEnum.Equipments.Chamber3.ToString(), strValue, cb.GetWaferInfo(iSlot), True, iSlot)
                                ElseIf (strSource.CompareTo("CassettesPanel.WaferInsideAligner") = 0) Then
                                    Dim Aligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                                    SetWaferInsideAligner(strFullCommand, Aligner.GetWaferInfo(), True)
                                ElseIf (strSource.CompareTo("CassettesPanel.WaferInsideRobot") = 0) Then
                                    Dim robot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                                    SetWaferInsideRobot(strFullCommand, robot.GetWaferInfo(), True)
                                    Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
                                    ctrRobot.SendCMDDelete_Create_Wafer(robot.GetWaferInfo() Is Nothing) '''if robot WaferInfo is nothing ---> delete Wafer
                                ElseIf strSource.CompareTo("CassettesPanel.ctwcCycleWafer.chkInCycleModeA") = 0 Then
                                    Dim val As Boolean = False
                                    Boolean.TryParse(strFullCommand, val)
                                    Dim objLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())
                                    objLoadLock.InCycleMode_RunWithRecipe = val

                                    If (val) Then
                                        SetCyclingUntilWafer(objLoadLock, 0)
                                    End If

                                ElseIf strSource.CompareTo("CassettesPanel.ctwcCycleWafer.txtLLAMaxCycleCount") = 0 Then
                                    Dim val As Int32 = strFullCommand
                                    Dim objLoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())

                                    If objLoadLock IsNot Nothing Then
                                        SetCyclingUntilWafer(objLoadLock, val)
                                    End If

                                Else
                                    AVPLib.Log.avpLogger.Error("Unknown command: " & strFullCommand)
                                End If
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoTask")
        End Sub
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2011-08-22</date>
        ''' </author>
        ''' <summary>
        '''  Set Cycling Until Wafer
        ''' </summary>
        Private Shared Sub SetCyclingUntilWafer(ByVal objLL As DataManagerment.LoadLock, ByVal maxCycleCount As Int32)
            Try
                With objLL
                    .MaxCycleCount = maxCycleCount
                    'set Complete Cycle Wafer - if job already start -> still show cycling xx/xxxx
                    Dim objLoadLockCtrl As AVPLib.Business.LoadLockController = Nothing
                    objLoadLockCtrl = AVPLib.Business.ControllerManager.GetController(.Name)
                    '
                    If (objLoadLockCtrl IsNot Nothing AndAlso objLoadLockCtrl.CtrlJobId <> String.Empty) Then
                        Dim objCtrlJob As Business.AVPControlJob = _
                                  Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockCtrl.CtrlJobId)
                        If objCtrlJob IsNot Nothing Then
                            objCtrlJob.MaxCycleCount = maxCycleCount
                            objCtrlJob.CompletedCycleWafer()
                        End If
                    End If
                End With

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-12</date>
        ''' </author>
        ''' <summary>
        ''' ProcessPanel PJ Resume
        ''' </summary>
        ''' <param name="ChamberName"></param>
        ''' <param name="Value"></param>
        ''' <remarks></remarks>
        Public Shared Sub ProcessPanelPJMarkForReturn(ByVal strWaferID As String)

            AVPLib.Log.coreLogger.Info("Enter ProcessPanelPJResume")
            Try
                AVPLib.Utils.ShowFlashingText("Mark For Return is running....", False)
                AVPLib.Business.AVPCore.Instance().JobManager().PJCommand(strWaferID, ConstEnum.PJ_CMDS.PJ_CMD_MARK_FOR_RETURN)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ProcessPanelPJResume")
        End Sub

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-11-12</date>
        ''' </author>
        ''' <summary>
        ''' ProcessPanel PJ Resume
        ''' </summary>
        ''' <param name="ChamberName"></param>
        ''' <param name="Value"></param>
        ''' <remarks></remarks>
        Public Shared Sub ProcessPanelPJResume(ByVal strWaferID As String)

            AVPLib.Log.coreLogger.Info("Enter ProcessPanelPJResume")
            Try
                AVPLib.Business.AVPCore.Instance().JobManager().PJCommand(strWaferID, ConstEnum.PJ_CMDS.PJ_CMD_RESUME)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ProcessPanelPJResume")
        End Sub


        Public Shared Sub SetWaferInsideSrc_Dst(ByVal Source As String, ByVal Destination As String, _
                                                ByVal Waferinfo As AVPWaferInfo, _
                                                Optional ByVal SourceSlotID As Integer = 1, _
                                                Optional ByVal DesSlotID As Integer = 1)
            'Don't save 
            SetWaferInsideStation(Source, "Off", Nothing, False, SourceSlotID)
            SetWaferInsideStation(Destination, "On", Waferinfo, False, DesSlotID)
            ''Open and save 1 time
            Dim strRegExp As String = "^(LoadLock[AB]),Slot(\d+)"
            Dim mtcMatch As Match = Nothing
            If (Source.IndexOf(AVPProcessJob.LoadLockID) >= 0) Then
                mtcMatch = Regex.Match(Source, strRegExp)
                Dim LoadLockName As String = mtcMatch.Groups(1).Value
                Dim Slot As String = mtcMatch.Groups(2).Value
                Utils.SavingWaferInfo(LoadLockName, Slot, Destination, Slot, Waferinfo)
            ElseIf (Destination.IndexOf(AVPProcessJob.LoadLockID) >= 0) Then
                mtcMatch = Regex.Match(Destination, strRegExp)
                Dim LoadLockName As String = mtcMatch.Groups(1).Value
                Dim Slot As String = mtcMatch.Groups(2).Value
                Utils.SavingWaferInfo(Source, Slot, LoadLockName, Slot, Waferinfo)
            Else
                Utils.SavingWaferInfo(Source, Waferinfo.SlotID.ToString, Destination, DesSlotID, Waferinfo)
                Exit Sub
            End If
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2009-01-13</date>
        ''' </author>
        ''' <summary>
        ''' Set Wafer Inside Chamber
        ''' </summary>
        ''' <param name="ChamberName"></param>
        ''' <param name="Value"></param>
        ''' <remarks></remarks>
        Public Shared Sub SetWaferInsideChamber(ByVal ChamberName As String, _
                                                ByVal Value As String, _
                                                ByVal waferInfo As AVPWaferInfo, ByVal blnSaveXML As Boolean, Optional ByVal iSlot As Int16 = 1)

            AVPLib.Log.coreLogger.Info("Enter SetWaferInsideChamber")
            Try
                Dim strReplyValue As String = Value
                SetWaferInsideChamber_without_UpdateGEM(ChamberName, Value, waferInfo, blnSaveXML, iSlot)
                Dim chamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(ChamberName)
                ''send command to PM
                If chamberConfig.Type <> AVPLib.SystemModule.ModuleType.PVD4 AndAlso chamberConfig.Type <> AVPLib.SystemModule.ModuleType.PVD5T Then
                    Dim PMController As ChamberController = ControllerManager.GetController(ChamberName)
                    If PMController IsNot Nothing Then
                        If waferInfo Is Nothing Then
                            PMController.DoSetWaferStatus("00")
                        Else
                            PMController.DoSetWaferStatus(String.Format("{0:00}", CType(waferInfo.WaferStatus, Integer)))
                        End If

                    End If
                End If

                ''Update GEM
                If waferInfo IsNot Nothing Then
                    Dim strProcessingState As String = Utils.chamberID2ChamberName(ChamberName)
                    strProcessingState = "ARRIVED_IN_" & strProcessingState
                    waferInfo.WaferProcessingStatus = _
                                   [Enum].Parse(GetType(AVPLib.ConstEnum.WaferProcessingState), strProcessingState, True)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetWaferInsideChamber")
        End Sub

        Public Shared Sub SetWaferInsideChamber_without_UpdateGEM(ByVal ChamberName As String, _
                                                       ByVal Value As String, _
                                                       ByVal waferInfo As AVPWaferInfo, ByVal blnSaveXML As Boolean, Optional ByVal iSlot As Int16 = 1)

            AVPLib.Log.coreLogger.Info("Enter SetWaferInsideChamber_without_UpdateGEM")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()
                Dim strReplyValue As String = Value
                If waferInfo IsNot Nothing Then
                    strReplyValue = strReplyValue + " " + iSlot.ToString + " " + waferInfo.WaferID + " " + waferInfo.WaferStatus.ToString()
                Else
                    strReplyValue = strReplyValue + " " + iSlot.ToString
                End If
                ReplyValues.Add(strReplyValue)
                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("WaferInside")
                If blnSaveXML Then
                    AVPLib.Utils.SavingWaferInfo(ChamberName, strReplyValue.Split(" ")(1), waferInfo)
                End If
                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ChamberName, PropertyNames, ReplyValues)

                Dim chamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(ChamberName)
                If chamberConfig.Type = SystemModule.ModuleType.PVD5T Then
                    If Value = ConstEnum.STR_OFF Then
                        PVD5TUtility.SetWaferDeleteToPVD5T(ChamberName, iSlot.ToString())
                    Else
                        If waferInfo IsNot Nothing Then
                            PVD5TUtility.SetWaferSlotToPVD5T(ChamberName, iSlot.ToString())
                        End If
                    End If
                Else
                    If Value = ConstEnum.STR_OFF Then
                        CoronaUtility.SetWaferDeleteToCorona(ChamberName, iSlot.ToString())
                    Else
                        If waferInfo IsNot Nothing Then
                            CoronaUtility.SetWaferSlotToCorona(ChamberName, iSlot.ToString())
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetWaferInsideChamber_without_UpdateGEM")
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2009-01-13</date>
        ''' </author>
        ''' <summary>
        ''' SetWaferInsideAligner
        ''' </summary>
        ''' <param name="Value"></param>
        ''' <remarks></remarks>
        Public Shared Sub SetWaferInsideAligner(ByVal Value As String, _
                                                ByVal waferInfo As AVPWaferInfo, ByVal blnSaveXML As Boolean)
            AVPLib.Log.coreLogger.Info("Enter SetWaferInsideAligner")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()
                Dim strReplyValue As String = Value

                ReplyValues.Add(strReplyValue)

                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("WaferInsideAligner")

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus("Aligner", PropertyNames, ReplyValues)

                If blnSaveXML Then
                    AVPLib.Utils.SavingWaferInfo("Aligner", String.Empty, waferInfo)
                End If
                If Value = ConstEnum.STR_ON AndAlso waferInfo IsNot Nothing Then
                    waferInfo.WaferProcessingStatus = ConstEnum.WaferProcessingState.NOT_ALIGNED
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetWaferInsideAligner")
        End Sub

        Public Shared Sub SetWaferInsideRobot(ByVal Value As String, _
                                              ByVal waferInfo As AVPWaferInfo, ByVal blnSaveXML As Boolean)
            AVPLib.Log.coreLogger.Info("Enter SetWaferInsideRobot")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()
                Dim strReplyValue As String = Value
                If waferInfo IsNot Nothing Then
                    strReplyValue = strReplyValue + " " + waferInfo.WaferID + " " + waferInfo.WaferStatus.ToString()
                    waferInfo.WaferProcessingStatus = ConstEnum.WaferProcessingState.TRANSFERING_BETWEEN_MODULES
                End If
                ReplyValues.Add(strReplyValue)

                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("WaferInsideRobot")

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ConstEnum.Equipments.Robot.ToString(), PropertyNames, ReplyValues)
                If blnSaveXML Then
                    AVPLib.Utils.SavingWaferInfo(ConstEnum.Equipments.Robot.ToString(), String.Empty, waferInfo)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetWaferInsideRobot")
        End Sub

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 14 May 2009</date>
        ''' </author>
        ''' <Modifiers>
        ''' <summary>
        ''' Set wafer inside a station to On or Off (has wafer or do not has wafer)
        ''' A station can be a chamber, Loadlock, Aligner, Robot, Aligner
        ''' </summary>
        ''' <remarks></remarks>

        Public Shared Sub SetWaferInsideStation(ByVal strStationName As String, _
                                                ByVal strOnOff As String, _
                                                ByVal waferInfo As AVPWaferInfo, ByVal blnSaveXMl As Boolean, Optional ByVal iSlot As Int16 = 1)
            AVPLib.Log.coreLogger.Info("Enter SetWaferInsideStation")
            Try
                If (strStationName.IndexOf(AVPProcessJob.ChamberID) >= 0) Then
                    ' Set the wafer information in the chamber
                    SetWaferInsideChamber(strStationName, strOnOff, waferInfo, blnSaveXMl, iSlot)
                ElseIf (strStationName.IndexOf(AVPProcessJob.LoadLockID) >= 0) Then

                    Dim strRegExp As String = "^(LoadLock[AB]),Slot(\d+)"
                    Dim mtcMatch As Match = Regex.Match(strStationName, strRegExp)
                    Dim LoadLockName As String = mtcMatch.Groups(1).Value
                    Dim Slot As String = mtcMatch.Groups(2).Value

                    Dim LoadLock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(LoadLockName)
                    ' Update the LL wafer information
                    If strOnOff = "On" Then
                        LoadLock.Elevator.SetStatusGraph(Integer.Parse(Slot), waferInfo)
                    ElseIf strOnOff = "Off" Then
                        LoadLock.Elevator.SetStatusGraph(Integer.Parse(Slot), Nothing)
                    End If
                    If blnSaveXMl Then
                        AVPLib.Utils.SavingWaferInfo(LoadLock.Name, Slot, waferInfo)
                    End If

                ElseIf (strStationName.IndexOf(AVPProcessJob.AlignerID) >= 0) Then
                    'Update the wafer information in Aligner
                    SetWaferInsideAligner(strOnOff, waferInfo, blnSaveXMl)

                ElseIf (strStationName.IndexOf(AVPProcessJob.RobotArmID) >= 0) Then
                    'update the wafer information in the Robot
                    SetWaferInsideRobot(strOnOff, waferInfo, blnSaveXMl)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetWaferInsideStation")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Initialize ControllerManager
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub Initialize()
            AVPLib.Log.coreLogger.Info("Enter Initialize")
            Try
                m_htbChildController = New Hashtable()
                CreateControllerTree()
#If AVP_CX_STYLE = "CX5" Then
                AVPLib.Driver.DriverManager.Initialize("CX5")
#ElseIf AVP_CX_STYLE = "CX4" Then
                AVPLib.Driver.DriverManager.Initialize("CX4")
#End If
                '2012-08-01 Turn off TM/LLx IG during startup.   
                'This will turn off all IG if software crash or unexpected shut down of computer.
                ControllerInitialize()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Initialize")
        End Sub

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-08-01</date>
        ''' </author>
        ''' <Modifier>
        '''</Modifier>
        ''' <summary>
        ''' call Loadlock and TM controller Init here because 
        ''' must call driver initialize first
        ''' driver manager must be init before all controller created
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Sub ControllerInitialize()
            Dim objLoadlockAController As LoadLockController = ControllerManager.GetController(ConstEnum.Equipments.LoadLockA.ToString)
            objLoadlockAController.Initialize()

            Dim objTMController As TMController = ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString)
            objTMController.Initialize()

        End Sub
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh </Name>
        '''   	<Date> 2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Release all resource
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub Dispose()
            AVPLib.Log.coreLogger.Info("Enter Dispose")
            Try
                Dim LLA As LoadLockController = CType(m_htbChildController.Item(ConstEnum.Equipments.LoadLockA.ToString), LoadLockController)
                If (LLA IsNot Nothing) Then
                    LLA.Dispose()
                End If
                Dim TMTransfer As TMController = CType(m_htbChildController.Item(ConstEnum.Equipments.CassettesModule.ToString), TMController)
                If (TMTransfer IsNot Nothing) Then
                    TMTransfer.Dispose()
                End If

                Dim RobotControllerObj As RobotController = CType(m_htbChildController.Item(ConstEnum.Equipments.Robot.ToString), RobotController)
                If (RobotControllerObj IsNot Nothing) Then
                    RobotControllerObj.Dispose()
                End If

                Dim AlignerControllerObj As AlignerController = CType(m_htbChildController.Item(ConstEnum.Equipments.Aligner.ToString), AlignerController)
                If (AlignerControllerObj IsNot Nothing) Then
                    AlignerControllerObj.Dispose()
                End If

                Dim WaterPumpControllerObj As WaterPumpController = CType(m_htbChildController.Item(ConstEnum.Equipments.TMWaterPump.ToString), WaterPumpController)
                If (WaterPumpControllerObj IsNot Nothing) Then
                    WaterPumpControllerObj.Dispose()
                End If

                Dim NoOfChambers As Integer = 3 'default for CX4
            

                Dim strChamber As String = ConstEnum.Chamber
                For i As Integer = 1 To NoOfChambers
                    strChamber = ConstEnum.Chamber & i.ToString()
                    Dim PMController As ChamberController = ControllerManager.GetController(strChamber)
                    If (PMController IsNot Nothing) Then
                        PMController.Myself.Dispose()
                    End If
                Next

                ' DeviceNetApp
                Dim DeviceNetAppControllerObj As DeviceNetAppController = CType(m_htbChildController.Item(ConstEnum.Equipments.DeviceNetApp.ToString), DeviceNetAppController)
                If (DeviceNetAppControllerObj IsNot Nothing) Then
                    DeviceNetAppControllerObj.Dispose()
                End If

                SaveStoreGui()
                m_htbChildController.Clear()
                AVPLib.Driver.DriverManager.Dispose()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Dispose")
        End Sub

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2009-01-14</date>
        ''' </author>
        ''' <summary>
        ''' Save Store Gui
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub SaveStoreGui()
            AVPLib.Log.coreLogger.Info("Enter SaveStoreGui")
            Try
                Dim StoreGui As DBStoreGui = New DBStoreGui()
                Dim objChamber1 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber1.ToString())
                Dim objChamber2 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber2.ToString())
                Dim objChamber3 As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Chamber3.ToString())
                Dim objAligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                Dim Robot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())


                If objChamber1 Is Nothing Then
                    StoreGui.WaferChamber1 = Nothing
                    StoreGui.Chamber1WaferInfo = Nothing
                    StoreGui.HaveInsideWaferChamber1 = False
                Else
                    StoreGui.WaferChamber1 = objChamber1.GetWaferInfo()
                    Dim ChamberModule As AVPLib.SystemModule = _
                                                                       AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER1_NAME))
                    Dim arrWaferOfChamber As AVPLib.AVPWaferInfo() = New AVPLib.AVPWaferInfo(ChamberModule.MaxNumberOfSlot - 1) {}

                    For idx As Integer = 0 To ChamberModule.MaxNumberOfSlot - 1
                        arrWaferOfChamber(idx) = objChamber1.GetWaferInfo(idx + 1)
                    Next
                    StoreGui.Chamber1WaferInfo = arrWaferOfChamber
                    StoreGui.HaveInsideWaferChamber1 = IIf((objChamber1.WaferInside = DataManagerment.Equipment.WorkingStatuses.On), True, False)
                    StoreGui.WaferCountOfChamber1 = objChamber1.PM_WaferCount
                    StoreGui.UseAbsoluteKWH = Not (objChamber1.IsUseMaxLimit)
                End If

                If objChamber2 Is Nothing Then
                    StoreGui.WaferChamber2 = Nothing
                    StoreGui.HaveInsideWaferChamber2 = False
                    StoreGui.Chamber2WaferInfo = Nothing
                Else
                    StoreGui.WaferChamber2 = objChamber2.GetWaferInfo()
                    Dim ChamberModule As AVPLib.SystemModule = _
                                                                       AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER2_NAME))
                    Dim arrWaferOfChamber As AVPLib.AVPWaferInfo() = New AVPLib.AVPWaferInfo(ChamberModule.MaxNumberOfSlot - 1) {}
                    For idx As Integer = 0 To ChamberModule.MaxNumberOfSlot - 1
                        arrWaferOfChamber(idx) = objChamber2.GetWaferInfo(idx + 1)
                    Next
                    StoreGui.Chamber2WaferInfo = arrWaferOfChamber
                    StoreGui.HaveInsideWaferChamber2 = IIf((objChamber2.WaferInside = DataManagerment.Equipment.WorkingStatuses.On), True, False)
                    StoreGui.WaferCountOfChamber2 = objChamber2.PM_WaferCount
                    StoreGui.UseAbsoluteKWH = Not (objChamber2.IsUseMaxLimit)
                End If

                If objChamber3 Is Nothing Then
                    StoreGui.WaferChamber3 = Nothing
                    StoreGui.HaveInsideWaferChamber3 = False
                    StoreGui.Chamber3WaferInfo = Nothing
                Else
                    StoreGui.WaferChamber3 = objChamber3.GetWaferInfo()
                    Dim ChamberModule As AVPLib.SystemModule = _
                                                                       AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER3_NAME))
                    Dim arrWaferOfChamber As AVPLib.AVPWaferInfo() = New AVPLib.AVPWaferInfo(ChamberModule.MaxNumberOfSlot - 1) {}
                    For idx As Integer = 0 To ChamberModule.MaxNumberOfSlot - 1
                        arrWaferOfChamber(idx) = objChamber3.GetWaferInfo(idx + 1)
                    Next
                    StoreGui.Chamber3WaferInfo = arrWaferOfChamber
                    StoreGui.HaveInsideWaferChamber3 = IIf((objChamber3.WaferInside = DataManagerment.Equipment.WorkingStatuses.On), True, False)
                    StoreGui.WaferCountOfChamber3 = objChamber3.PM_WaferCount
                    StoreGui.UseAbsoluteKWH = Not (objChamber3.IsUseMaxLimit)
                End If

                If objAligner Is Nothing Then
                    StoreGui.HaveInsideWaferAligner = False
                    StoreGui.LastUsedAlignerRecipe = Nothing
                    StoreGui.WaferAtAligner = Nothing
                Else
                    StoreGui.HaveInsideWaferAligner = IIf((objAligner.WaferInside = DataManagerment.Equipment.WorkingStatuses.On), True, False)
                    StoreGui.LastUsedAlignerRecipe = objAligner.RecipeNameWaferInfo
                    StoreGui.WaferAtAligner = objAligner.GetWaferInfo()
                End If

                If Robot Is Nothing Then
                    StoreGui.HaveInsideWaferRobot = False
                    StoreGui.WaferAtRobot = Nothing
                Else
                    StoreGui.HaveInsideWaferRobot = IIf((Robot.WaferInside = DataManagerment.Equipment.WorkingStatuses.On), True, False)
                    StoreGui.WaferAtRobot = Robot.GetWaferInfo()

                    'CONFIG ROBOT
                    StoreGui.HaveConfigHACC = IIf(Robot.R_HACC <> String.Empty AndAlso Robot.T_HACC <> String.Empty AndAlso Robot.Z_HACC <> String.Empty, Boolean.TrueString, Boolean.FalseString)
                    StoreGui.HaveConfigPACC = IIf(Robot.R_PACC <> String.Empty AndAlso Robot.T_PACC <> String.Empty AndAlso Robot.Z_PACC <> String.Empty, Boolean.TrueString, Boolean.FalseString)
                    StoreGui.HaveConfigWACC = IIf(Robot.R_WACC <> String.Empty AndAlso Robot.T_WACC <> String.Empty AndAlso Robot.Z_WACC <> String.Empty, Boolean.TrueString, Boolean.FalseString)
                    StoreGui.HaveConfigHVEL = IIf(Robot.R_HVEL <> String.Empty AndAlso Robot.T_HVEL <> String.Empty AndAlso Robot.Z_HVEL <> String.Empty, Boolean.TrueString, Boolean.FalseString)
                    StoreGui.HaveConfigPVEL = IIf(Robot.R_PVEL <> String.Empty AndAlso Robot.T_PVEL <> String.Empty AndAlso Robot.Z_PVEL <> String.Empty, Boolean.TrueString, Boolean.FalseString)
                    StoreGui.HaveConfigWVEL = IIf(Robot.R_WVEL <> String.Empty AndAlso Robot.T_WVEL <> String.Empty AndAlso Robot.Z_WVEL <> String.Empty, Boolean.TrueString, Boolean.FalseString)
                    StoreGui.R_HACC = Robot.R_HACC
                    StoreGui.R_PACC = Robot.R_PACC
                    StoreGui.R_WACC = Robot.R_WACC

                    StoreGui.T_HACC = Robot.T_HACC
                    StoreGui.T_PACC = Robot.T_PACC
                    StoreGui.T_WACC = Robot.T_WACC

                    StoreGui.Z_HACC = Robot.Z_HACC
                    StoreGui.Z_PACC = Robot.Z_PACC
                    StoreGui.Z_WACC = Robot.Z_WACC

                    StoreGui.R_HVEL = Robot.R_HVEL
                    StoreGui.R_PVEL = Robot.R_PVEL
                    StoreGui.R_WVEL = Robot.R_WVEL

                    StoreGui.T_HVEL = Robot.T_HVEL
                    StoreGui.T_PVEL = Robot.T_PVEL
                    StoreGui.T_WVEL = Robot.T_WVEL

                    StoreGui.Z_HVEL = Robot.Z_HVEL
                    StoreGui.Z_PVEL = Robot.Z_PVEL
                    StoreGui.Z_WVEL = Robot.Z_WVEL
                End If

                Dim objLoadLockA As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())

                If objLoadLockA Is Nothing Then
                    StoreGui.WaferTotalOfLoadLockA = 0
                    StoreGui.LotID_LLA = Nothing
                    StoreGui.SequenceID_LLA = Nothing
                Else
                    StoreGui.WaferTotalOfLoadLockA = objLoadLockA.WaferCount
                    StoreGui.LotID_LLA = objLoadLockA.LotID
                    StoreGui.SequenceID_LLA = objLoadLockA.SequenceID
                End If

                Dim LoadLockAElevator As DataManagerment.LLElevator = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())

                If LoadLockAElevator Is Nothing Then
                    StoreGui.LoadLockAWaferInfo = Nothing
                Else
                    StoreGui.LoadLockAWaferInfo = LoadLockAElevator.ListOfWaferInfo
                End If

                StoreGui.LifeTimeWafer = AVPLib.ContainerData.LifeTimeWafer

                ContainerData.SaveStoreGui(StoreGui)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SaveStoreGui")
        End Sub
        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2011-01-14</date>
        ''' </author>
        ''' <summary>
        ''' Save Source Usage
        ''' </summary>
        ''' <remarks></remarks>
        ''Public Shared Sub SaveSourceUsage(ByVal value As String)
        '    If value = String.Empty Then
        '        value = "0"
        '    End If
        '    'ContainerDAO.SaveSourceUsage(value)
        'End Sub
#End Region

#Region "Private shared methods"

        Private Shared Sub CreateChamberController(ByVal chamberName As String, ByVal htbChildControllers As Hashtable, _
                                                   ByVal chamberType As ChamberController.ControllerType)
            'If (ContainerData.IsChamberVisible(chamberName)) Then
            'DatDo: Currently, we still using chamber controller to open slit valve
            'We have to create this instance event we do not use it
            'Will look for a nother way to avoid loading un-use object
            If chamberType = ChamberController.ControllerType.PVDController OrElse
                chamberType = ChamberController.ControllerType.IBEController OrElse
                chamberType = ChamberController.ControllerType.PVD5TController OrElse
                chamberType = ChamberController.ControllerType.CORONAController Then
                Dim ctlChamber As New ChamberController(chamberType.ToString(), chamberName)
                ctlChamber.EquipmentName = chamberName
                htbChildControllers.Add(chamberName, ctlChamber)
            Else
                AVPLib.Log.avpLogger.Error("We can't create chamberName: " & chamberName.ToString())
            End If
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Create controller tree ControllerManager
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Sub CreateControllerTree()
            AVPLib.Log.coreLogger.Info("Enter CreateControllerTree")
            Try
                Dim strChamber As String = ConstEnum.Chamber
                Dim systemModule As SystemModule = Nothing
                Dim NoOfChambers As Integer = 3
               
                For i As Integer = 1 To NoOfChambers
                    strChamber = ConstEnum.Chamber & i.ToString()
                    'if Chamber is visible -> create Chamber Controller
                    Dim blnInstall As Boolean = AVPLib.ContainerData.IsChamberVisible(strChamber, systemModule)
                    If blnInstall AndAlso systemModule.Type = AVPLib.SystemModule.ModuleType.IBE Then
                        CreateChamberController(strChamber, m_htbChildController, ChamberController.ControllerType.IBEController)
                    ElseIf blnInstall AndAlso systemModule.Type = AVPLib.SystemModule.ModuleType.PVD Then
                        CreateChamberController(strChamber, m_htbChildController, ChamberController.ControllerType.PVDController)
                    ElseIf blnInstall AndAlso systemModule.Type = AVPLib.SystemModule.ModuleType.PVD4 Then
                        CreateChamberController(strChamber, m_htbChildController, ChamberController.ControllerType.CORONAController)
                    ElseIf blnInstall AndAlso systemModule.Type = AVPLib.SystemModule.ModuleType.PVD5T Then
                        CreateChamberController(strChamber, m_htbChildController, ChamberController.ControllerType.PVD5TController)
                    End If
                Next

                Dim strLoadLockA As String = ConstEnum.Equipments.LoadLockA.ToString()
                Dim strAligner As String = ConstEnum.Equipments.Aligner.ToString()
                Dim strRobot As String = ConstEnum.Equipments.Robot.ToString()
                Dim strTransferModule As String = ConstEnum.Equipments.CassettesModule.ToString()
                Dim strTMPumpPackage As String = ConstEnum.Equipments.TMPumpPackage.ToString()

                Dim strLLAPumpPackage As String = ConstEnum.Equipments.LLAPumpPackage.ToString()
                Dim strLLAElevator As String = ConstEnum.Equipments.LLAElevator.ToString()

                Dim ctlLLAElevator As LLElevatorController = Nothing

                'Create Transfer Module controller
                Dim ctlTM As New TMController()
                ctlTM.EquipmentName = strTransferModule

                'TM PumpPackage
                If RobotConfigurationValues.TMCRYO_VISIBLE Then
                    Dim ctlTMPumpPackage As New CryoController()
                    ctlTMPumpPackage.EquipmentName = strTMPumpPackage
                    ctlTMPumpPackage.DisplayName = ConstEnum.Equipments.TMCryo.ToString()
                    ctlTMPumpPackage.T1Min = VentPumdownLib.LLTMPumpPackage.TMCryoT1Min
                    ctlTMPumpPackage.T1Max = VentPumdownLib.LLTMPumpPackage.TMCryoT1Max
                    ctlTMPumpPackage.T2Min = VentPumdownLib.LLTMPumpPackage.TMCryoT2Min
                    ctlTMPumpPackage.T2Max = VentPumdownLib.LLTMPumpPackage.TMCryoT2Max
                    AddHandler AVPLib.Communication.TerminalDriver.TransactionManager.ReconnectStatus, AddressOf ctlTMPumpPackage.ReconnectHandle
                    ctlTM.ChildController.Add(strTMPumpPackage, ctlTMPumpPackage)
                    m_htbChildController.Add(strTMPumpPackage, ctlTMPumpPackage)
                ElseIf RobotConfigurationValues.TMTURBO_VISIBLE Then
                    Dim ctlTMPumpPackage As New TurboController()
                    ctlTMPumpPackage.EquipmentName = strTMPumpPackage
                    ctlTMPumpPackage.DisplayName = ConstEnum.Equipments.TMTurbo.ToString()
                    ctlTM.ChildController.Add(strTMPumpPackage, ctlTMPumpPackage)
                    m_htbChildController.Add(strTMPumpPackage, ctlTMPumpPackage)
                End If

                'Create Transfer Module controller for TM waterPump 
                If RobotConfigurationValues.TMWATERPUM_VISIBLE Then
                    Dim strTMWaterPump As String = ConstEnum.Equipments.TMWaterPump.ToString()
                    Dim ctlTMWaterPump As New WaterPumpController()
                    ctlTMWaterPump.EquipmentName = strTMWaterPump
                    ctlTMWaterPump.PullingInterval = ContainerData.GetPolling(strTMWaterPump).Interval
                    ctlTM.EquipmentName = strTransferModule
                    AddHandler AVPLib.Communication.TerminalDriver.TransactionManager.ReconnectStatus, AddressOf ctlTMWaterPump.ReconnectHandle
                    ctlTM.ChildController.Add(strTMWaterPump, ctlTMWaterPump)
                    m_htbChildController.Add(strTMWaterPump, ctlTMWaterPump)
                End If
                'Create Load Lock A controller
                Dim ctlLoadLockA As New LoadLockController(strLoadLockA)

                ctlLLAElevator = New LLElevatorController()
                ctlLLAElevator.EquipmentName = strLLAElevator

                ctlLLAElevator.PullingInterval = ContainerData.GetPolling(strLLAElevator).Interval
                AddHandler AVPLib.Communication.TerminalDriver.TransactionManager.ReconnectStatus, AddressOf ctlLLAElevator.ReconnectHandle
                ctlLoadLockA.ChildController.Add("LLElevator", ctlLLAElevator)

                'LLA PumpPackage
                If RobotConfigurationValues.LLA_CRYO_VISIBLE Then
                    Dim ctlLLAPumpPackage As New CryoController()
                    ctlLLAPumpPackage.EquipmentName = strLLAPumpPackage
                    ctlLLAPumpPackage.DisplayName = ConstEnum.Equipments.LLACryo.ToString()
                    ctlLLAPumpPackage.T1Min = VentPumdownLib.LLTMPumpPackage.LLACryoT1Min
                    ctlLLAPumpPackage.T1Max = VentPumdownLib.LLTMPumpPackage.LLACryoT1Max
                    ctlLLAPumpPackage.T2Min = VentPumdownLib.LLTMPumpPackage.LLACryoT2Min
                    ctlLLAPumpPackage.T2Max = VentPumdownLib.LLTMPumpPackage.LLACryoT2Max
                    AddHandler AVPLib.Communication.TerminalDriver.TransactionManager.ReconnectStatus, AddressOf ctlLLAPumpPackage.ReconnectHandle
                    ctlLoadLockA.ChildController.Add(strLLAPumpPackage, ctlLLAPumpPackage)
                    m_htbChildController.Add(strLLAPumpPackage, ctlLLAPumpPackage)
                ElseIf RobotConfigurationValues.LLA_TURBO_VISIBLE Then
                    Dim ctlLLAPumpPackage As New TurboController()
                    ctlLLAPumpPackage.EquipmentName = strLLAPumpPackage
                    ctlLLAPumpPackage.DisplayName = ConstEnum.Equipments.LLATurbo.ToString()
                    ctlLoadLockA.ChildController.Add(strLLAPumpPackage, ctlLLAPumpPackage)
                    m_htbChildController.Add(strLLAPumpPackage, ctlLLAPumpPackage)
                End If

                m_htbChildController.Add(strLoadLockA, ctlLoadLockA)
                ctlLLAElevator.InitializeProc()

                'Create Aligner controller
                If (RobotConfigurationValues.ALINER_VISIBLE) Then
                    Dim ctlAligner As New AlignerController()
                    ctlAligner.EquipmentName = strAligner
                    ctlAligner.LinkTestInterval = ContainerData.GetPolling(strAligner).Interval
                    AddHandler AVPLib.Communication.TerminalDriver.TransactionManager.ReconnectStatus, AddressOf ctlAligner.ReconnectHandle
                    m_htbChildController.Add(strAligner, ctlAligner)
                    ctlAligner.Initialize()
                End If


                'Create Robot controller
                Dim ctlRobot As New RobotController()
                ctlRobot.EquipmentName = strRobot
                ctlRobot.LinkTestInterval = ContainerData.GetPolling(strRobot).Interval
                AddHandler AVPLib.Communication.TerminalDriver.TransactionManager.ReconnectStatus, AddressOf ctlRobot.ReconnectHandle

                m_htbChildController.Add(strTransferModule, ctlTM)
                m_htbChildController.Add(strRobot, ctlRobot)

                ctlRobot.InitializeProc()

              
                'Create DeviceNetApp Controller 
                If RobotConfigurationValues.DEVICENETAPP_VISIBLE Then
                    Dim strDeviceNetApp As String = ConstEnum.Equipments.DeviceNetApp.ToString()
                    Dim ctlDeviceNetApp As New DeviceNetAppController()
                    ctlDeviceNetApp.EquipmentName = strDeviceNetApp
                    'ctlDeviceNetApp.PullingInterval = ContainerData.GetPolling(strDeviceNetApp).Interval
                    m_htbChildController.Add(strDeviceNetApp, ctlDeviceNetApp)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CreateControllerTree")
        End Sub

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-08</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name> </Name>
        '''   	<Date> </Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Send serial command
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Function DoSerialCommand(ByVal FullCommand As String) As Boolean
            Dim result As Boolean = True
            AVPLib.Log.coreLogger.Info("Enter DoSerialCommand")
            Try
                Dim intPos As Integer = FullCommand.IndexOf(".")
                Dim strEquipment As String = FullCommand.Substring(0, intPos)
                Dim strCommand As String = FullCommand.Substring(intPos)
                Dim objController As Object = Nothing
                Select Case strEquipment
                    Case "ROBOT"
                        strEquipment = ConstEnum.Equipments.Robot.ToString()
                        strCommand = strEquipment + ".Serial" + strCommand
                    Case "LLA"
                        strEquipment = ConstEnum.Equipments.LoadLockA.ToString()
                        strCommand = ConstEnum.Equipments.LLAElevator.ToString() + ".Serial" + strCommand
                    Case "ALIGNER"
                        strEquipment = ConstEnum.Equipments.Aligner.ToString()
                        strCommand = strEquipment + ".Serial" + strCommand
                End Select
                SyncLock m_MessagesLock
                    objController = m_htbChildController.Item(strEquipment)
                End SyncLock
                If (objController IsNot Nothing) Then
                    Dim ctlController As ControllerObject = CType(objController, ControllerObject)
                    ctlController.DoSerialCommand(strCommand)
                Else
                    result = False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoSerialCommand")
            Return result
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-08</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name> </Name>
        '''   	<Date> </Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Semi auto transfer
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Sub SemiAutoTransfer(ByVal strFullCommand As String, Optional ByVal isReturnFreeJob As Boolean = False)
            AVPLib.Log.coreLogger.Info("Enter SemiAutoTransfer")
            Try
                AVPLib.Log.coreLogger.Info("Enter Start")
                Try
                    Dim partsOfCmd As String() = strFullCommand.Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)
                    Const kUseAligner As String = "UseAlignerTrue"
                    If strFullCommand.Contains(kUseAligner) Then
                        Dim objAligner As DataManagerment.Aligner = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                        objAligner.RecipeNameWaferInfo = partsOfCmd(partsOfCmd.Length - 1)
                    End If
                    'Create the control Job
                    Dim strCtrlJobId As String = _
                    AVPLib.Business.AVPCore.Instance().JobManager().CreateControlJobForSemiTransfer(strFullCommand, isReturnFreeJob)

                    If isReturnFreeJob Then
                        AVPLib.Utils.ShowFlashingText("Return All Wafers is running...", False)
                    End If
                    'Start the processing
                    AVPLib.Business.AVPCore.Instance().JobManager().CJCommand(strCtrlJobId, ConstEnum.CJ_CMDS.CJ_CMD_START)
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
                AVPLib.Log.coreLogger.Info("Leave Start")

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SemiAutoTransfer")
        End Sub

        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2021-11-16 </date>
        ''' </author>
        ''' <summary>
        ''' 0015828: [KhoiHa - 11/05/2019] 20. Add some text indicating wafer is returning from process view screen.
        ''' just only use show flashing text
        ''' </summary>
        Private Shared Sub SemiAutoTransferForCJReturn(ByVal strFullCommand As String)
            AVPLib.Log.coreLogger.Info("Enter SemiAutoTransferForCJReturn")
            Try
                Try
                    AVPLib.Utils.ShowFlashingText("Return Wafer is running...", False)
                    SemiAutoTransfer(strFullCommand)
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SemiAutoTransferForCJReturn")
        End Sub
#End Region
    End Class
End Namespace