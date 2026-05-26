Imports AVPLib
Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum
Imports System.Text.RegularExpressions

Public Class SelfAlignerControl

    Private m_HasSlot As Boolean = False
    Private m_blnIsOnline As Boolean = False
    Private m_IsStartSelfAlign As Boolean = False

#Region "Properties"
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            cboListStation.Enabled = Not m_blnIsOnline
            cboRecipeAligner.Enabled = Not m_blnIsOnline
            cboListSlot.Enabled = (Not m_blnIsOnline AndAlso m_HasSlot)
            Enable_Disable_AllButton(Not m_blnIsOnline)
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-08-19 </date>
    ''' </author>
    Public Property IsStartSelfAlign() As Boolean
        Get
            Return m_IsStartSelfAlign
        End Get
        Set(ByVal value As Boolean)
            m_IsStartSelfAlign = value
        End Set
    End Property
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-05-20 </date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            m_stoStatusObject.Name = Me.Name

            Dim stSelfAligner As New StatusButtonSelfAligner(btnSelfAligner)
            Dim stbRTBefore As New StatusTextBox(txtRTBefore)
            Dim stbRTAfter As New StatusTextBox(txtRTAfter)

            m_stoStatusObject.AddChild(stSelfAligner)
            m_stoStatusObject.AddChild(stbRTBefore)
            m_stoStatusObject.AddChild(stbRTAfter)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Private methods"

    Private Sub btnSelfAligner_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelfAligner.Click
        AVPLib.Log.guiLogger.Info("Enter btnSelfAligner_Click")
        Dim strMessageText As String = String.Empty
        Try
            Dim chamberName As String = AVPLib.Utils.chamberName2ChamberID(cboListStation.SelectedItem.ToString().Replace(" ", ""))
            Dim objLLElevator As AVPLib.DataManagerment.LLElevator = Nothing
            Dim objLLController As AVPLib.Business.LoadLockController = Nothing
            Dim IsSchedulerRunning As Boolean = False
            Dim objJobmanager As AVPLib.Business.AVPJobManager = AVPLib.Business.AVPCore.Instance().JobManager()

            objLLController = AVPLib.Business.ControllerManager.GetController(LoadLockA_STR)
            If (objJobmanager IsNot Nothing) Then
                IsSchedulerRunning = Not objJobmanager.isAllJobInLoadLockFinished(ConstantAndEnum.LOAD_LOCK_A.ToString())
                If IsSchedulerRunning Then
                    Utils.ShowAVPMessageBox("Schuduler is running. Can not start self align! ", "Self Align", MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
                    Return
                End If

                IsSchedulerRunning = Not objJobmanager.isAllJobFinished()
                If IsSchedulerRunning Then
                    Utils.ShowAVPMessageBox("Tranfer wafer is running. Can not start self align!", "Self Align", MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
                    Return
                End If
            End If

            If chamberName = ConstEnum.LLA_STR Then
                chamberName = Equipments.LoadLockA.ToString() & "," & cboListSlot.SelectedItem.ToString()
                objLLElevator = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Equipments.LLAElevator.ToString())
                If objLLElevator IsNot Nothing Then
                    If objLLElevator.SlotStatus(cboListSlot.SelectedIndex) <> ConstEnum.SlotStatuses.Available Then
                        Utils.ShowAVPMessageBox(cboListStation.SelectedItem.ToString().Replace(" ", "") & _
                                                " has not a wafer at " & cboListSlot.SelectedItem.ToString(), "Self Align", _
                                                MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
                        Return
                    End If
                End If

            ElseIf chamberName = Equipments.Aligner.ToString().ToUpper() Then
                chamberName = Equipments.Aligner.ToString()
                Dim eqmEquiment As DataManagerment.Equipment = DataManagerment.EquipmentManager.GetEquipment(chamberName)
                If eqmEquiment IsNot Nothing Then
                    If eqmEquiment.WaferInside <> DataManagerment.Equipment.WorkingStatuses.On Then
                        Utils.ShowAVPMessageBox(cboListStation.SelectedItem.ToString().Replace(" ", "") & _
                                                " has not a wafer", "Self Align", _
                                                MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
                        Return
                    End If
                End If

            Else
                Dim objChamber As DataManagerment.Equipment = DataManagerment.EquipmentManager.GetEquipment(chamberName)
                If objChamber IsNot Nothing Then
                    Dim currentSlotID As Integer = 1
                    Dim chamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(chamberName)
                    If chamberConfig.Type = AVPLib.SystemModule.ModuleType.PVD4 Then
                        Dim objCoronaChamber As DataManagerment.CoronaChamber = DataManagerment.EquipmentManager.GetEquipment(chamberName)
                        currentSlotID = objCoronaChamber.Substrate_Current_Station
                    End If
                    If objChamber.GetWaferInfo(currentSlotID) Is Nothing Then
                        Utils.ShowAVPMessageBox(cboListStation.SelectedItem.ToString().Replace(" ", "") & _
                                                " has not a wafer at slot " & currentSlotID.ToString(), "Self Align", _
                                                MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
                        Return
                    Else
                        chamberName = chamberName & ",Slot" & currentSlotID
                    End If
                End If
            End If

            ''Check recipe aligner.
            If Not System.IO.File.Exists(AVPLib.ContainerDAO.FPath_ChamberRecipe + "\" + Equipments.Aligner.ToString() + "\" + cboRecipeAligner.SelectedItem.ToString() + STR_XML_EXT) Then
                Utils.ShowAVPMessageBox("Recipe Aligner: " + cboRecipeAligner.SelectedItem.ToString() + " is not exists.", "Recipe Aligner", _
                                               MessageBoxIcon.Warning, AVPMessageBox.AVPMessageBoxButton.OK)
                Return

            End If

            strMessageText = String.Format(AVPLib.ContainerData.GetMessageText("GotoChamberSelfAligner"), cboListStation.SelectedItem.ToString())
            If Utils.ShowAVPMessageBox(strMessageText, "Self Align", MessageBoxIcon.Question) = DialogResult.OK Then
                Dim strValue As String = AVPLib.ConstEnum.SELFALIGNER & "," & chamberName & _
                                         "," & Equipments.Aligner.ToString() & "," & AVPLib.ConstEnum.USEALIGNER_TRUE & "," & _
                                         cboRecipeAligner.SelectedItem.ToString()
                m_stoStatusObject.RequestStatus(btnSelfAligner.Name, strValue)
                IsStartSelfAlign = True
                Enable_Disable_AllButton(False)
                ClearRTInformation()

                Utils.LogUserEvent(sender, "TM Screen", "Self Align")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnSelfAligner_Click")
    End Sub

    ''' <author>
    '''    	<name>Dua Tran</name>
    '''    	<date> 2017-10-13 </date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SelfAlignerControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If cboRecipeAligner.Items.Count > 0 Then
            cboRecipeAligner.SelectedIndex = 0
        End If
    End Sub

#End Region

    Private Sub cboListStation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboListStation.SelectedIndexChanged
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                cboListSlot.Items.Clear()
                If cboListStation.SelectedItem.ToString() = ConstEnum.LLA_STR Then
                    cboListSlot.Enabled = True
                    m_HasSlot = True
                    For i As Integer = 0 To AVPLib.RobotConfigurationValues.LOADLOCKA_SLOTS - 1
                        cboListSlot.Items.Add(ConstantAndEnum.SLOT & (i + 1).ToString())
                    Next
                Else
                    cboListSlot.Enabled = False
                    m_HasSlot = False
                End If

                If cboListSlot.Items.Count > 0 Then
                    cboListSlot.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-05-20 </date>
    ''' </author>
    ''' <summary>
    ''' Enable_Disable_AllButton
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Enable_Disable_AllButton(ByVal blnEnable As Boolean)
        btnSelfAligner.Enabled = blnEnable And (Not IsStartSelfAlign) And (Not m_blnIsOnline)
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-05-20 </date>
    ''' </author>
    ''' <summary>
    ''' ClearRTInformation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearRTInformation()
        txtRTBefore.Text = String.Empty
        txtRTAfter.Text = String.Empty
    End Sub

End Class