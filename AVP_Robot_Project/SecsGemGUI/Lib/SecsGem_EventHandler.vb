Imports AVPLib.DataManagerment
Imports System.Threading
Imports AVPSecsGemLib
Imports AVPLib
Imports AVPLib.Business.AVPSecsGemLib
Imports EMSERVICELib

Public Class SecsGem_EventHandler
    Public Shared Sub Enable_Disable_SecsGemCommunication(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter Enable_Disable_SecsGemCommunication")
        If AVPLib.ContainerData.UserLogin Is Nothing Then
            Exit Sub
        End If
        Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
        Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(button.Name & ".Click")
        Dim strChamberName As String = String.Empty
        Try
            If Utils.ShowAVPMessageBox(strMessageText, "GEM Control", MessageBoxIcon.Information) = DialogResult.OK Then
                If sender Is ContainerForm.Secs_GemPanel.btnEnable Then
                    AVPLib.Business.AVPSecsGemLib.DoEnableCommunication()
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                       "Click button Enable GEM Communication")
                ElseIf sender Is ContainerForm.Secs_GemPanel.btnDisable Then
                    AVPLib.Business.AVPSecsGemLib.DoDisableCommunication()
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                           "Click button Disable GEM Communication")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Enable_Disable_SecsGemCommunication")
    End Sub

    Public Shared Sub UpLoad_Download_PP(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter UpLoad_Download_PP")
        If AVPLib.ContainerData.UserLogin Is Nothing Then
            Exit Sub
        End If
        Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
        Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(button.Name & ".Click")
        Dim strChamberName As String = String.Empty
        Try
            If Utils.ShowAVPMessageBox(strMessageText, "GEM Control", MessageBoxIcon.Information) = DialogResult.OK Then
                With ContainerForm.Secs_GemPanel
                    If sender Is ContainerForm.Secs_GemPanel.btnUploadProcess Then
                        If .lstPP.SelectedItem.ToString() <> String.Empty Then
                            Dim fileDetail As System.IO.FileInfo
                            fileDetail = My.Computer.FileSystem.GetFileInfo(AVPLib.ContainerDAO.FPath_GEMData & .lstPP.SelectedItem.ToString() & ".xml")
                            MySecsGemObj.PPLoadInquire(.lstPP.SelectedItem.ToString(), fileDetail.Length)
                            .btnUploadProcess.Enabled = False
                            .m_isUpload_Processing = True
                            .UploadDownloadTimer.Enabled = True
                        Else
                            Utils.ShowAVPMessageBox("Please Select Process Program File", "GEM Control", MessageBoxIcon.Exclamation, AVPMessageBox.AVPMessageBoxButton.OK)
                        End If
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                           "Click button UpLoad Process Program to Host")

                    ElseIf sender Is ContainerForm.Secs_GemPanel.btnDownloadProcess Then
                        If .txtPPDownload.Text <> String.Empty Then
                            Dim pos1 As Integer = .txtPPDownload.Text.IndexOf(".")
                            If (pos1 <= 0) Then
                                Utils.ShowAVPMessageBox("File Name is incorrect", _
                                "GEM Control", MessageBoxIcon.Exclamation, AVPMessageBox.AVPMessageBoxButton.OK)
                            Else
                                Dim part1 As String = .txtPPDownload.Text.Substring(0, pos1 + 1)
                                Dim part2 As String = .txtPPDownload.Text.Replace(part1, "")
                                If (part1.ToUpper = SecsGemPanel.EXT_RECIPE_FILE) Then
                                    Dim pos2 As Integer = part2.IndexOf(".")
                                    If (pos1 <= 0) Then
                                        Utils.ShowAVPMessageBox("File Name is incorrect", _
                                        "GEM Control", MessageBoxIcon.Exclamation, AVPMessageBox.AVPMessageBoxButton.OK)
                                    Else
                                        Dim part21 As String = part2.Substring(0, pos2 + 1)
                                        Dim part22 As String = part2.Replace(part21, "")
                                        If (part21.ToUpper.Contains("PM") OrElse (AVPLib.ContainerDAO.Enable_ANYIBE_Mode AndAlso part21.Contains("IBE"))) Then
                                            MySecsGemObj.PPRequest(part1.ToUpper() & part21.ToUpper() & part22)
                                            .btnDownloadProcess.Enabled = False
                                            .m_isDownload_Processing = True
                                            .UploadDownloadTimer.Enabled = True
                                        Else
                                            Utils.ShowAVPMessageBox("File Name is incorrect", _
                                            "GEM Control", MessageBoxIcon.Exclamation, AVPMessageBox.AVPMessageBoxButton.OK)
                                        End If
                                    End If
                                ElseIf (part1.ToUpper = SecsGemPanel.EXT_WAFERFLOW_FILE) OrElse _
                                (part1.ToUpper = SecsGemPanel.EXT_SEQUENCE_FILE) Then
                                    MySecsGemObj.PPRequest(part1.ToUpper() & part2)
                                    .btnDownloadProcess.Enabled = False
                                    .m_isDownload_Processing = True
                                    .UploadDownloadTimer.Enabled = True
                                Else
                                    Utils.ShowAVPMessageBox("File Name is incorrect", _
                                    "GEM Control", MessageBoxIcon.Exclamation, AVPMessageBox.AVPMessageBoxButton.OK)
                                End If
                            End If
                        Else
                            Utils.ShowAVPMessageBox("Please Enter Process Program File", "GEM Control", MessageBoxIcon.Exclamation, AVPMessageBox.AVPMessageBoxButton.OK)
                        End If
                    End If
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                               "Click button Download Process Program from Host")
                End With
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave UpLoad_Download_PP")
    End Sub

    Public Shared Sub Offline_SecsGem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter Online_Offline_SecsGem")
        If AVPLib.ContainerData.UserLogin Is Nothing Then
            Exit Sub
        End If
        Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
        Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(button.Name & ".Click")
        Dim strChamberName As String = String.Empty
        Try
            If Utils.ShowAVPMessageBox(strMessageText, "GEM Control", MessageBoxIcon.Information) = DialogResult.OK Then
                AVPLib.Business.AVPSecsGemLib.DoOffline()
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                       "Click button Offline in Gem Control")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Online_Offline_SecsGem")
    End Sub

    Public Shared Sub Online_Remote_Local_SecsGem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter Online_Remote_Local_SecsGem")
        If AVPLib.ContainerData.UserLogin Is Nothing Then
            Exit Sub
        End If
        Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
        Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(button.Name & ".Click")
        Dim strChamberName As String = String.Empty
        Try
            If Utils.ShowAVPMessageBox(strMessageText, "GEM Control", MessageBoxIcon.Information) = DialogResult.OK Then
                AVPLib.Business.AVPSecsGemLib.DoOnline()
                If sender Is ContainerForm.Secs_GemPanel.btnGoOnlineRemote Then
                    AVPLib.Business.AVPSecsGemLib.DoControlRemote()
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                       "Click button Online Remote in Gem Control")
                ElseIf sender Is ContainerForm.Secs_GemPanel.btnGoOnlineLocal Then
                    AVPLib.Business.AVPSecsGemLib.DoControlLocal()
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                           "Click button Online Local in Gem Control")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Online_Remote_Local_SecsGem")
    End Sub

    Public Shared Sub Ack_Send_SecsGem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            AVPLib.Business.AVPSecsGemLib.DoControlLocal()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#Region "Terminal Message"
    Public Shared Sub ClearTerminalMessage(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If AVPLib.ContainerData.UserLogin Is Nothing Then
            Exit Sub
        End If
        Dim button As SL_CustomButton = CType(sender, SL_CustomButton)
        Dim strMessageText As String = AVPLib.ContainerData.GetMessageText("btnClearTerminalMessage.Click")
        Dim strChamberName As String = String.Empty
        Try
            If Utils.ShowAVPMessageBox(strMessageText, "Terminal Messages", MessageBoxIcon.Information) = DialogResult.OK Then
                If sender Is ContainerForm.Secs_GemPanel.btnClearfromHost Then
                    ContainerForm.Secs_GemPanel.txtMessageFromHost.Text = String.Empty
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                       "Click button Clear Message from Host in Terminal Messages")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub SendTerminalMessage(ByVal message As String)
        Try
            AVPLib.Business.AVPSecsGemLib.SendTerminalMessage(message)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub SendTerminalAcknowledge()
        Try
            AVPLib.Business.AVPSecsGemLib.SendTerminalAcknowledge()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
End Class
