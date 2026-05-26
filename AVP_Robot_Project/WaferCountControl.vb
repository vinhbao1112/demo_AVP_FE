Imports AVP_Robot_Project
Imports AVP_Robot_Project.ConstantAndEnum
Public Class WaferCountControl
#Region "Protected method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-04</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbTotal As New StatusTextBox(txtTotal)
            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbTotal)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-24</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on total text box
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotal.Click
        AVPLib.Log.guiLogger.Info("Enter txtTotal_Click")
        Try
            If AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_006) = False Then
                Exit Sub
            End If
            Dim strMessageText As String
            strMessageText = AVPLib.ContainerData.GetMessageText("ResetWaferCounter")
            If (Utils.ShowAVPMessageBox(strMessageText, "Reset Wafer Count", MessageBoxIcon.Question) = DialogResult.OK) Then
                Utils.LogUserEvent("Clicked to reset Wafer Count", "Main Screen")
                'Dat Cao add control reset wafer count here
                'i think in the future, we need bring this code to CassetesPanelUtility.vb 
                'in above file handle all action of CassetesPanel
                'this file only call function
                txtTotal.Text = "0"
                AVPLib.ContainerDAO.SaveWaferCountForEQ(AVPLib.ConstEnum.TM_STR, 0)
                '#If AVP_PLATFORM = "CX" Then
                '                If (ContainerForm.ProcessPanel.lpcLoadLockA IsNot Nothing) Then
                '                    ContainerForm.ProcessPanel.lpcLoadLockA.txtTotal.Text = "0"
                '                    ContainerForm.ProcessPanel.lpcLoadLockA.ResetWaferCount()
                '                End If
                '                If (ContainerForm.ProcessPanel.lpcLoadLockB IsNot Nothing) Then
                '                    ContainerForm.ProcessPanel.lpcLoadLockB.txtTotal.Text = "0"
                '                    ContainerForm.ProcessPanel.lpcLoadLockB.ResetWaferCount()
                '                End If
                '#End If
                m_stoStatusObject.RequestStatus(txtTotal.Name, "reset")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txtTotal_Click")
    End Sub
#End Region

End Class
