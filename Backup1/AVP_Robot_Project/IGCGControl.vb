Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Imports AVPLib.ConstEnum
Public Delegate Sub ButtonIGEventHandler(ByVal sender As System.Object, ByVal e As System.EventArgs)
Public Class IGCGControl

#Region "Class Constants & Variables"
    Private m_strMessage As String
    Public Event ButtonIGClick As ButtonIGEventHandler
    Private Const STRING_OFF As String = "Off"
    Private Const STRING_ON As String = "On"
#End Region

#Region "Properties"
    Public Property IGCGValue() As String
        Get
            Return txtIG.Text
        End Get
        Set(ByVal value As String)
            txtIG.Text = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Get or set visible header of this control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property HeaderVisible() As Boolean
        Get
            HeaderVisible = MyBase.HeaderVisible
        End Get
        Set(ByVal value As Boolean)
            Try
                If (value <> MyBase.HeaderVisible) Then
                    If (value) Then
                        For Each ctrl As Control In Me.Controls
                            'If (ctrl.Name <> lblHeader.Name) Then
                            'ctrl.Location = New System.Drawing.Point(ctrl.Location.X, ctrl.Location.Y + lblHeader.Height)
                            'End If
                        Next ctrl
                        'Me.Height += lblHeader.Height
                    Else
                        For Each ctrl As Control In Me.Controls
                            'If (ctrl.Name <> lblHeader.Name) Then
                            'ctrl.Location = New System.Drawing.Point(ctrl.Location.X, ctrl.Location.Y - lblHeader.Height)
                            ' End If
                        Next ctrl
                        ' Me.Height -= lblHeader.Height
                    End If
                    MyBase.HeaderVisible = value
                    ' Me.Refresh()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' set or get message will be shown by click on IG button
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property Message() As String
        Get
            Return m_strMessage
        End Get
        Set(ByVal value As String)
            Try
                m_strMessage = value
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
#End Region

#Region "Constructors & Dispose"

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Initiate IGCG control
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.Header.Dock = DockStyle.Left
        Me.Header.Width = 60
        ' Add any initialization after the InitializeComponent() call.
        If Me.DesignMode Then
            'lblHeader.Visible = False
        End If
        Me.Header.OffImage = Me.Header.ErrorImage
    End Sub
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbIG As New IGCGStatusTextBox(txtIG)
            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbIG)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Events – Buttons – Forms…"
   
    '''' <author>
    ''''    	<name> Ngo Cao Dinh </name>
    ''''    	<date> 2008-09-16</date>
    '''' </author>
    '''' <summary>
    '''' Handle click event on bigcgIG button
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub bigcgIG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    AVPLib.Log.guiLogger.Info("Enter bigcgIG_Click")
    '    Try
    '        Dim sValue As String = "Click IG button"
    '        Dim sTitle As String = String.Empty
    '        Dim strRet As String = String.Empty
    '        If Me.Name.Contains(TM_STR) Then
    '            sTitle = TM_STR
    '        ElseIf Me.Name.Contains(LLA_STR) Then
    '            sTitle = LLA_STR
    '        ElseIf Me.Name.Contains(LLB_STR) Then
    '            sTitle = LLB_STR
    '        End If
    '        Dim transferModule As DataManagerment.CassettesModule = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
    '        Dim loadlockA As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockA.ToString())
    '        Dim loadlockB As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LoadLockB.ToString())
    '        If (m_strMessage Is Nothing) Then
    '            m_stoStatusObject.RequestStatus(bigcgIG.Name, sValue)
    '        Else
    '            Dim strMessage = ""
    '            If (bigcgIG.Status = DisplayStatus.On) Then
    '                strMessage = m_strMessage + "'" + STRING_OFF + "'"
    '                sValue = STRING_OFF
    '            Else
    '                strMessage = m_strMessage + "'" + STRING_ON + "'"
    '                sValue = STRING_ON
    '            End If

    '            If (Utils.ShowAVPMessageBox(strMessage, sTitle, MessageBoxIcon.Question) = DialogResult.OK) Then
    '                '''if button is off -->check condition
    '                If bigcgIG.Status = DisplayStatus.Off Then
    '                    Select Case sTitle
    '                        Case TM_STR
    '                            strRet = transferModule.checkCondition2OpenTMIG
    '                        Case LLA_STR
    '                            strRet = loadlockA.CheckCondition2OpenLLIG()
    '                        Case LLB_STR
    '                            strRet = loadlockB.CheckCondition2OpenLLIG()
    '                    End Select
    '                End If

    '                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
    '                                                  AVPLib.ContainerData.LogSource.AVPMainScreen, _
    '                                                  "[Main Screen] " + "Click on IGCG button.")
    '                '''''''''''''if IG is On or strRet has no message error
    '                If strRet = String.Empty Then
    '                    m_stoStatusObject.RequestStatus(bigcgIG.Name, sValue)
    '                Else ''if has error -> raise it
    '                    'MessageBox.Show(strRet, UCase(Me.Name), MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Utils.ShowAVPMessageBox(strRet, UCase(Me.Name), MessageBoxIcon.Warning, MessageBoxButtons.OK)
    '                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
    '                                                  AVPLib.ContainerData.LogSource.AVPMainScreen, _
    '                                                  "[Main Screen] " + "Error when click on IGCG button.")
    '                End If


    '            End If
    '        End If
    '        RaiseEvent ButtonIGClick(sender, e)
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    AVPLib.Log.guiLogger.Info("Leave bigcgIG_Click")
    'End Sub

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2015-05-29</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on Header button
    ''' </summary>
    Private Sub Header_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Header.Click
        Try
            Dim chamberName As String = String.Empty
            If Me.Header.Text.Contains(AVPLib.ConstEnum.PM1) AndAlso _
                    ContainerForm.CassettesPanel.IgcgChamber1.HeaderStatus = DisplayStatus.Off Then
                chamberName = AVPLib.Utils.chamberName2ChamberID(Me.Header.Text)
            ElseIf Me.Header.Text.Contains(AVPLib.ConstEnum.PM2) AndAlso _
                    ContainerForm.CassettesPanel.IgcgChamber2.HeaderStatus = DisplayStatus.Off Then
                chamberName = AVPLib.Utils.chamberName2ChamberID(Me.Header.Text)
            ElseIf Me.Header.Text.Contains(AVPLib.ConstEnum.PM3) AndAlso _
                    ContainerForm.CassettesPanel.IgcgChamber3.HeaderStatus = DisplayStatus.Off Then
                chamberName = AVPLib.Utils.chamberName2ChamberID(Me.Header.Text)
            End If

            If String.IsNullOrEmpty(chamberName) Then
                Exit Sub
            End If

            If (Utils.ShowAVPMessageBox("Do you want to connect to " & Me.Header.Text & " ?", Me.Header.Text & " Reconnect", _
                                                MessageBoxIcon.Question) = DialogResult.OK) Then
                ContainerForm.ChamberPanel(chamberName).btnReConnect_Click(sender, e)
                Utils.LogUserEvent(sender, AVPLib.Utils.chamberID2ChamberName(chamberName))
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("Header_Click_1" & ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-24 </date>
    ''' </author>
    ''' <summary>
    ''' Active/Inactive controls in form
    ''' </summary>
    Public Sub ActiveForm(ByVal isEnabled As Boolean)
        Try
            Me.Header.Enabled = isEnabled
            Me.Cursor = IIf(isEnabled, Cursors.Hand, Cursors.Default)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-07-31 </date>
    ''' </author>
    ''' <summary>
    ''' Show Cursor
    ''' </summary>
    Private Sub Header_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Header.StatusChange
        If Me.Header.Status = DisplayStatus.On Then
            Me.Header.Cursor = Cursors.Default
        End If
    End Sub
End Class
