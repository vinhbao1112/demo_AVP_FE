Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Imports AVPControls

Public Class CreateSequenceDialog
    Private m_LLName As String = ConstantAndEnum.LOADLOCKA
    Private m_ctrlSequence As Sequence
    Private m_intNoSlots As Integer = 12
    Private m_blnIsReadOnly As Boolean = False

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_ctrlSequence = New Sequence(True, IsReadOnly)
        m_ctrlSequence.Name = "QuickSequenceDialog"
        m_ctrlSequence.Dock = DockStyle.Fill
        pnlSequence.Controls.Add(m_ctrlSequence)

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strSequenceName As String, ByVal slotNumber As Integer, ByVal blnIsReadOnly As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        IsReadOnly = blnIsReadOnly
        m_intNoSlots = slotNumber
        m_ctrlSequence = New Sequence(True, IsReadOnly)
        m_ctrlSequence.Name = "QuickSequenceDialog"
        m_ctrlSequence.Dock = DockStyle.Fill
        pnlSequence.Controls.Add(m_ctrlSequence)

        OpenSeguence(strSequenceName)
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 13-05-2011</date>
    ''' </author>
    ''' <summary>
    ''' Load sequence in background
    ''' if error -> clear all datatable 
    ''' all thing is empty
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OpenSeguence(ByVal segName As String)
        Try
            Dim filename As String = segName
            filename = AVPLib.ContainerDAO.FPath_SequenceData & "\" & filename & ".xml"
            Dim wfSequence As AVPLib.DBWaferList = Nothing
            Dim strDescription As String = String.Empty
            ' If can not open the flow
            If Not AVPLib.ContainerData.GetSequence(filename, wfSequence, strDescription) Then
                Exit Sub
            End If

            For Each item As AVPLib.DBWaferSlot In wfSequence.WaferList

                If (item.Slot > m_intNoSlots) Then
                    Continue For
                End If

                Dim WaferFlow As AVPLib.DataManagerment.WaferFlow = AVPLib.ContainerData.GetWaferFlowbyName(item.WaferSequence.SeqName)
                If WaferFlow Is Nothing Then
                    If Not String.IsNullOrEmpty(item.WaferSequence.SeqName) Then
                        clearSequence()
                        Exit Sub
                    Else
                        Continue For
                    End If
                End If
                If WaferFlow.CheckRecipeExist() = False Then
                    clearSequence()
                    Exit Sub
                End If
                Me.m_ctrlSequence.dgvSequence.Rows(m_intNoSlots - CInt(item.Slot)).Cells(WAFER_FLOW).Value = item.WaferSequence.SeqName
                Me.m_ctrlSequence.dgvSequence.Rows(m_intNoSlots - CInt(item.Slot)).Cells(SELECTED).Value = False
            Next
            txtSequenceName.Text = segName
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 13-05-2011</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' Clear data table when load Error
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub clearSequence()
        Try
            If (m_ctrlSequence IsNot Nothing) Then
                For i As Integer = m_intNoSlots - 1 To 0 Step -1
                    Me.m_ctrlSequence.dgvSequence.Rows(i).Cells(WAFER_FLOW).Value = ""
                    Me.m_ctrlSequence.dgvSequence.Rows(i).Cells(SELECTED).Value = False
                Next
                Me.m_ctrlSequence.dgvSequence.Refresh()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Huy Nguyen </name>
    '''    	<date> 2015/07/22 </date>
    ''' </author>
    ''' <summary>
    ''' is form read only?
    ''' </summary>
    Public Property IsReadOnly() As Boolean
        Get
            Return m_blnIsReadOnly
        End Get
        Set(ByVal value As Boolean)
            m_blnIsReadOnly = value

            If m_blnIsReadOnly Then
                txtSequenceName.Enabled = False
                btnOK.Enabled = False
                Me.Text = "Quick View Sequence For "
            End If
        End Set
    End Property

    Public Property LLName() As String
        Get
            Return m_LLName
        End Get
        Set(ByVal value As String)
            If value = ConstantAndEnum.LOADLOCKA Then
                m_LLName = value
                Me.Text &= LLA_STR
            End If
        End Set
    End Property

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            ''AVP is Online Remote -> SEC/GEM mode -> don't do anything
            If AVPRobotMain.OnlineRemote Then
                Me.Close()
                Exit Try
            End If
            '''''
        Dim blnSuccess As Boolean = False
        If String.IsNullOrEmpty(txtSequenceName.Text) Then
            Utils.ShowAVPMessageBox("Please type your sequence name", "Create Sequence", MessageBoxIcon.Information, MessageBoxButtons.OK)
            Exit Sub
        End If
        Dim strSeqName As String = txtSequenceName.Text.Trim()
        Dim currentSeqWaferFlow As New AVPLib.DBWaferList
        m_ctrlSequence.StoreGUIToObj(currentSeqWaferFlow) ''push data from GUI to DBWaferList

        If AVPLib.ContainerData.ListSequenceName.Contains(strSeqName) Then ''check existing file
            Dim dlg As DialogResult = Utils.ShowAVPMessageBox("FileName Existed, Do you want to Overwrite", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Warning)
            If dlg = Windows.Forms.DialogResult.OK Then
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                  AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                  "[Main Screen] " + "Save sequence with overwrite mode.")
                blnSuccess = AVPLib.ContainerData.UpdateWFSequence(currentSeqWaferFlow, strSeqName, "Created from Quick Job Sequence Dialog")
                If blnSuccess Then
                    'Utils.ShowAVPMessageBox("Sequence Saved Successfully", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Information, MessageBoxButtons.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Sequence Editor] Sequence was saved successfully. FileName=" + txtSequenceName.Text)
                Else
                    Utils.ShowAVPMessageBox("Sequence Saved Unsuccessfully", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Error, MessageBoxButtons.OK)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Sequence Editor] Sequence was saved unsuccessfully. FileName=" + txtSequenceName.Text)
                End If
            End If
        Else 'if not existing
            blnSuccess = AVPLib.ContainerData.SaveWFSequence(currentSeqWaferFlow, strSeqName, "Created from Quick Job Sequence Dialog")
            If blnSuccess Then
                'Utils.ShowAVPMessageBox("Sequence Saved Successfully", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Information, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Sequence Editor] Sequence was saved successfully. FileName=" + txtSequenceName.Text)
            Else
                Utils.ShowAVPMessageBox("Sequence Saved Unsuccessfully", ConstantAndEnum.SEQUENCE, MessageBoxIcon.Error, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[Sequence Editor] Sequence was saved unsuccessfully. FileName=" + txtSequenceName.Text)
            End If
        End If
        If blnSuccess Then
            If LLName = ConstantAndEnum.LOADLOCKA Then
                ContainerForm.ProcessPanel.lpcLoadLockA.SeqID = strSeqName ''for internal use 
                    ContainerForm.ProcessPanel.lpcLoadLockA.txtSeqID.Text = strSeqName ''for display for user
                    ContainerForm.ProcessPanel.lpcLoadLockA.txtSeqID_MeasureString()
            End If
        End If
        Me.Close()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtSequenceName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSequenceName.Click
        Dim pad As New KeyPad
        If pad.DisplayKeypad(txtSequenceName.Text, "Saving New Sequence...", False) <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If
    End Sub
End Class