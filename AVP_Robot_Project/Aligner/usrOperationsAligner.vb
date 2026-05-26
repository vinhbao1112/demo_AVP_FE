Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.DataManagerment
Imports AVPLib.Business

Public Class usrOperationsAligner
    Private m_blnIsOnline As Boolean = False
#Region "Properties"
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            btnAlign.Enabled = Not m_blnIsOnline
            btnHome.Enabled = Not m_blnIsOnline
            btnScan.Enabled = Not m_blnIsOnline
            cboAlignAngle.Enabled = Not m_blnIsOnline
        End Set
    End Property
#End Region
#Region "Protected method"
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-14</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim m_btnAlign As New StatusButton(btnAlign)
            Dim m_btnScan As New StatusButton(btnScan)
            Dim m_btnHome As New StatusButton(btnHome)
            Dim sclToolLED As New StatusIGCGButton(btnToolLED)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(New StatusAlignerControl(Me, "OperationStatus"))
            m_stoStatusObject.AddChild(m_btnAlign)
            m_stoStatusObject.AddChild(m_btnScan)
            m_stoStatusObject.AddChild(m_btnHome)
            m_stoStatusObject.AddChild(sclToolLED)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
#Region "Private methods"
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' btnAlign_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub btnAlign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlign.Click
        AVPLib.Log.guiLogger.Info("Enter mnuAlign_Click")
        Dim strMessageText As String = String.Empty
        Try
            strMessageText = AVPLib.ContainerData.GetMessageText("AlignMenuRobotCassettes")
            If (Utils.ShowAVPMessageBox(strMessageText, ALIGN, MessageBoxIcon.Question) = DialogResult.OK) Then
                'clear info
                ContainerForm.CassettesPanel.TMAlignerControl.ClearInfo()
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner, _
                "[Aligner Screen]" & "Wafer Align Click")
                m_stoStatusObject.RequestStatus(btnAlign.Name, cboAlignAngle.SelectedItem.ToString())
                Utils.AlignerCMDAction(False, True)
                Me.Enabled = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuAlign_Click")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' btnHome_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        AVPLib.Log.guiLogger.Info("Enter btnHome_Click")
        Dim strMessageText As String = String.Empty
        Try
            strMessageText = AVPLib.ContainerData.GetMessageText("HomeMenuRobotCassettes")
            If (Utils.ShowAVPMessageBox(strMessageText, ALIGN, MessageBoxIcon.Question) = DialogResult.OK) Then
                'clear info
                ContainerForm.CassettesPanel.TMAlignerControl.ClearInfo()
                m_stoStatusObject.RequestStatus(btnHome.Name, "Click")
                Utils.AlignerCMDAction(False, True)
                Me.Enabled = False
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                         "[Aligner Screen]" & " Aligner Home Click")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnHome_Click")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-07</date>
    ''' </author>
    ''' <summary>
    ''' btnScan_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click
        AVPLib.Log.guiLogger.Info("Enter btnScan_Click")
        Dim strMessageText As String = String.Empty
        Try
            strMessageText = AVPLib.ContainerData.GetMessageText("ScanOperationsAligner")
            If (Utils.ShowAVPMessageBox(strMessageText, ALIGN, MessageBoxIcon.Question) = DialogResult.OK) Then
                'clear info
                ContainerForm.CassettesPanel.TMAlignerControl.ClearInfo()
                m_stoStatusObject.RequestStatus(btnScan.Name, "Click")
                Utils.AlignerCMDAction(False, True)
                Me.Enabled = False
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                         "[Aligner Screen]" & " Aligner Scan Click")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnScan_Click")
    End Sub

    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-04-19</date>
    ''' </author>
    ''' <summary>
    ''' Enable action
    ''' </summary>
    ''' <remarks></remarks>
    'Public Sub Enable_Disable_Action(ByVal blnEnable As Boolean)
    '    btnScan.Enabled = blnEnable
    '    btnHome.Enabled = blnEnable
    '    btnAlign.Enabled = blnEnable
    'End Sub
#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.cboAlignAngle.SelectedIndex = 1
    End Sub
End Class
