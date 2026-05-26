Imports System
Imports System.Globalization
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPControls

Public Class AlarmAndEvent
    Public Const WARNING As String = "Warning"

#Region "Members"
    Const STATUS_TEXT As String = "Please wait while loading...."
    Const DefaultPeriodOfTime As Integer = 0
    Private LoadDataGrid_Worker As ComponentModel.BackgroundWorker = Nothing
    Private m_dt As DataTable = Nothing
    Private m_strSelectedAlarmText As String = String.Empty
    Private m_Filter_Type As Filter_Type = Filter_Type.All
    Protected m_marshaller As DelegateMarshaler
    Private Delegate Sub UpdateDataToGrid(ByVal dtObj As Object)

    Public Enum Filter_Type
        All
        Warning
        User
        Alarm
        Message
    End Enum
#End Region

#Region "Load Form"

    Private Sub AlarmAndEvent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            m_marshaller = DelegateMarshaler.Create()
            LoadDataGrid_Worker = New ComponentModel.BackgroundWorker()
            LoadDataGrid_Worker.WorkerReportsProgress = True
            LoadDataGrid_Worker.WorkerSupportsCancellation = True

            AddHandler LoadDataGrid_Worker.DoWork, New ComponentModel.DoWorkEventHandler(AddressOf OnWork)
            AddHandler LoadDataGrid_Worker.RunWorkerCompleted, _
                       New ComponentModel.RunWorkerCompletedEventHandler(AddressOf Worker_RunWorkerCompleted)
            cmbType.Items.Add(Filter_Type.All.ToString)
            cmbType.Items.Add(Filter_Type.Warning.ToString)
            cmbType.Items.Add(Filter_Type.User.ToString)
            cmbType.Items.Add(Filter_Type.Alarm.ToString)
            cmbType.Items.Add(Filter_Type.Message.ToString)
            cmbType.ValueMember = "Name"
            cmbType.DisplayMember = "Name"
            cmbType.SelectedItem = Filter_Type.All.ToString()
            LoadUser()
            CheckPermission()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-12-03</date>
    ''' </author>
    ''' <summary>
    ''' Load User by get user from list user.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LoadUser()
        Try
            Dim listUser As ArrayList = AVPLib.ContainerData.ListUser
            cmbUsername.Items.Clear()
            cmbUsername.Items.Add("All")
            For Each Username As String In listUser
                Dim User As AVPLib.DBUser = AVPLib.ContainerData.User(Username)
                If User.Disable = False Then       'Do not show users that disable.
                    cmbUsername.Items.Add(Username)
                End If
            Next
            cmbUsername.Items.Add("Default")
            cmbUsername.SelectedIndex = 0
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-06</date>
    ''' </author>
    ''' <summary>
    ''' Filter_ValueChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FilterType_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        Try
            ApplyDataFilter(Me.cmbType.SelectedItem.ToString(), String.Empty)
            dgvUserLog.Refresh()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    '#Hoa Nguyen 12/03/2011
    'Remove this function. It is called too many times when add remove handler are un-synchonize.
    'Private Sub FilterUsername_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'Try
    '    ApplyDataFilter(Me.cmbType.SelectedItem.ToString(), String.Empty)
    '    dgvUserLog.Refresh()
    'Catch ex As Exception
    '    AVPLib.Log.avpLogger.Error(ex.ToString())
    'End Try
    'End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-03-12</date>
    ''' </author>
    ''' <summary>
    ''' cmbUsername_SelectedIndexChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbUsername_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUsername.SelectedIndexChanged
        Try
            ApplyDataFilter(Me.cmbType.SelectedItem.ToString(), String.Empty)
            dgvUserLog.Refresh()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    'Private Sub DateTime_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If Me.cmbUsername.SelectedItem IsNot Nothing Then
    '            Enable_DisableControl(False)
    '            GetDataSource("All", "All")
    '        End If
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    'End Sub
#End Region

#Region "Worker Load Data"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-06</date>
    ''' </author>
    ''' <summary>
    ''' Filter
    ''' </summary>
    ''' <param name="type"></param>
    ''' <param name="username"></param>
    ''' <remarks></remarks>
    Private Sub GetDataSource(ByVal type As String, ByVal username As String)
        Try
            If LoadDataGrid_Worker.IsBusy Then
                LoadDataGrid_Worker.CancelAsync()
            End If
            Dim filter As String = String.Empty '"Source <> 'Aligner' and "
            filter &= "LogTime >= #" + Me.dtFrom.Value.ToString("MM/dd/yyyy") + " 12:00:00 AM#" + " and LogTime <= #" + Me.dtTo.Value.ToString("MM/dd/yyyy") + " 11:59:59 PM#"
            If type.Length > 0 And type <> "All" Then
                If filter.Length > 0 Then
                    filter = filter + " and Type='" + type + "'"
                Else
                    filter = filter + " Type='" + type + "'"
                End If
            End If
            If username.Length > 0 And username <> "All" Then
                If filter.Length > 0 Then
                    filter = filter + " and LogUser='" + username + "'"
                Else
                    filter = filter + " LogUser='" + username + "'"
                End If
            End If
            Dim sSort As String = " order by LogTime DESC"
            lblStatus.Text = STATUS_TEXT
            If Not LoadDataGrid_Worker.IsBusy Then
                LoadDataGrid_Worker.RunWorkerAsync(filter & sSort)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub OnWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        If Me.LoadDataGrid_Worker.CancellationPending AndAlso Not (String.IsNullOrEmpty(e.Argument.ToString())) Then
            e.Cancel = True
            Return
        End If
        ' Do not access the form's BackgroundWorker reference directly.
        ' Instead, use the reference provided by the sender parameter.
        m_dt = AVPLib.ContainerData.DataTable_Log(LoadDataGrid_Worker, e.Argument.ToString())
        If Me.LoadDataGrid_Worker.CancellationPending Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Try
            If e.Cancelled Then
                Enable_DisableControl(True)
                Return
            End If
            If m_dt IsNot Nothing Then
                m_marshaller.Invoke(Of DataTable)(New Threading.SendOrPostCallback(AddressOf UpdateDataGrid), m_dt)
                'Clear memory after update datagrid.
                GC.Collect()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub UpdateDataGrid(ByVal stateObj As Object)
        Try
            If m_dt IsNot Nothing Then
                FilterDataTableByDescription()
                labRow.Text = "(" + Utils.FormatString(m_dt.Rows.Count) + ")"
                'LoadUser(m_dt)
                'LoadUser()
                dgvUserLog.DataSource = m_dt
                'ApplyDataFilter(m_Filter_Type.ToString(), m_strSelectedAlarmText)
                'm_strSelectedAlarmText = String.Empty
                'm_Filter_Type = Filter_Type.All
                dgvUserLog.Refresh()
                lblStatus.Text = String.Empty
            End If
            'Enable_DisableControl(True)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Enable_DisableControl(True)
    End Sub
#End Region

#Region "Support Functions"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-06</date>
    ''' </author>
    ''' <summary>
    ''' Load AlarmAndEvent
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadAlarmAndEvent(ByVal strSelectedAlarmText As String, ByVal strFilterType As Filter_Type)
        Try
            If String.IsNullOrEmpty(strSelectedAlarmText) AndAlso cmbType.SelectedItem.ToString() = "Alarm" Then
                Exit Sub
            End If
            LoadField()
            RefreshData()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-06</date>
    ''' </author>
    ''' <summary>
    ''' LoadGrid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadGrid()
        Try
            LoadField()
            ' Get by time.
            GetDataSource(String.Empty, String.Empty)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-06</date>
    ''' </author>
    ''' <summary>
    ''' Load Filter
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadUser(ByVal dtLog As DataTable)
        Try
            Dim dtUsername As DataTable = New DataTable()
            dtUsername.Columns.Add("Name")
            Dim dtUsernameFirst As DataRow = dtUsername.NewRow()
            dtUsernameFirst("Name") = "All"
            dtUsername.Rows.Add(dtUsernameFirst)
            For Each dr As DataRow In dtLog.Rows
                Dim drUsername As DataRow = dtUsername.NewRow()
                drUsername("Name") = dr("LogUser")
                If Utils.checkRowExisted(dtUsername, drUsername, "Name") = False Then
                    dtUsername.Rows.Add(drUsername)
                End If
            Next
            Me.cmbUsername.ValueMember = "Name"
            Me.cmbUsername.DisplayMember = "Name"
            Me.cmbUsername.DataSource = dtUsername
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-06</date>
    ''' </author>
    ''' <summary>
    ''' LoadField
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadField()
        Me.gcDescription.DataPropertyName = "Description"
        Me.gcSource.DataPropertyName = "Source"
        Me.gcTimestamp.DataPropertyName = "LogTime"
        Me.gcType.DataPropertyName = "Type"
        Me.gcUsername.DataPropertyName = "LogUser"

        Me.gcDescription.HeaderCell.Style.Font = New Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gcSource.HeaderCell.Style.Font = New Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gcTimestamp.HeaderCell.Style.Font = New Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gcType.HeaderCell.Style.Font = New Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gcUsername.HeaderCell.Style.Font = New Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    End Sub

    Private Sub ApplyDataFilter(ByVal strType As String, ByVal SelectedAlarm As String)
        If Me.cmbUsername.SelectedItem IsNot Nothing Then
            Dim type As String = strType
            Dim username As String = Me.cmbUsername.SelectedItem.ToString()
            Dim strFilter As String = String.Empty
            Dim dtView As New DataView(m_dt)

            cmbType.SelectedItem = strType

            If type = Filter_Type.All.ToString() And Not username = Filter_Type.All.ToString() Then
                strFilter = "LogUser='" & username & "'"
            ElseIf username = Filter_Type.All.ToString() And Not type = Filter_Type.All.ToString() Then
                strFilter = "Type='" & type & "'"
            ElseIf username = Filter_Type.All.ToString() And type = Filter_Type.All.ToString() Then
                strFilter = String.Empty
            Else
                strFilter = "Type='" & type & "'" & " and LogUser='" & username & "'"
            End If

            If Not String.IsNullOrEmpty(strFilter) Then
                dtView.RowFilter = strFilter
                dtView.RowStateFilter = DataViewRowState.CurrentRows
                dgvUserLog.DataSource = dtView
                If Not String.IsNullOrEmpty(SelectedAlarm) Then
                    Dim max_Row As Integer = dgvUserLog.Rows.Count
                    For i As Integer = 0 To max_Row - 1
                        dgvUserLog.Rows(i).Cells(0).Selected = False
                        If dgvUserLog.Rows(i).Cells("gcDescription").Value = SelectedAlarm Then
                            dgvUserLog.Rows(i).Cells(0).Selected = True
                            Exit For
                        End If
                    Next
                End If
            Else
                dgvUserLog.DataSource = m_dt
            End If
        End If
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-11-11</date>
    ''' </author>
    ''' <summary>
    ''' btnRefresh_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Try
            RefreshData()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-06</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckPermission()
        Try
            '#03/07/2011 
            '#[Sl_Build 12_Feb 16, 2011]User account should be similar to avp/pvd request
            '#Begin fix:
            If AVPLib.ContainerData.Permission(PERMISSION_012) Then
                ActiveForm()
            Else
                InactiveForm()
            End If
            '#End fix.
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-06</date>
    ''' </author>
    ''' <summary>
    ''' Active Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveForm()
        Try
            Me.dgvUserLog.Enabled = True
            Me.dtFrom.Enabled = True
            Me.dtTo.Enabled = True
            Me.cmbType.Enabled = True
            Me.cmbUsername.Enabled = True
            Me.btnRefresh.Enabled = True
            Me.btnExportCSV.Enabled = True
            Me.txtFilterDescription.Enabled = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-06</date>
    ''' </author>
    ''' <summary>
    ''' Inactive Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InactiveForm()
        Try
            Me.dgvUserLog.Enabled = False
            Me.dtFrom.Enabled = False
            Me.dtTo.Enabled = False
            Me.cmbType.Enabled = False
            Me.cmbUsername.Enabled = False
            Me.btnRefresh.Enabled = False
            Me.btnExportCSV.Enabled = False
            Me.txtFilterDescription.Enabled = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name>Truc Le </name>
    '''    	<date> 2008-09-06</date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub dgvUserLog_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvUserLog.CellFormatting
        Try
            If dgvUserLog.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() = "Alarm" Then
                dgvUserLog.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.DarkRed
                dgvUserLog.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
            ElseIf dgvUserLog.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() = WARNING Then
                dgvUserLog.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                dgvUserLog.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub Enable_DisableControl(ByVal blnEnable As Boolean)
        dtFrom.Enabled = blnEnable
        dtTo.Enabled = blnEnable
        cmbType.Enabled = blnEnable
        cmbUsername.Enabled = blnEnable
        btnRefresh.Enabled = blnEnable
        btnExportCSV.Enabled = blnEnable
        Me.txtFilterDescription.Enabled = blnEnable
        'If blnEnable Then
        '    ' AddHandler cmbUsername.SelectedIndexChanged, AddressOf FilterUsername_ValueChanged
        '    AddHandler dtFrom.ValueChanged, AddressOf DateTime_ValueChanged
        '    AddHandler dtTo.ValueChanged, AddressOf DateTime_ValueChanged
        'Else
        '    ' RemoveHandler cmbType.SelectedIndexChanged, AddressOf FilterUsername_ValueChanged
        '    RemoveHandler dtFrom.ValueChanged, AddressOf DateTime_ValueChanged
        '    RemoveHandler dtTo.ValueChanged, AddressOf DateTime_ValueChanged
        'End If
    End Sub

    '''<author>
    '''<name> Tu Nguyen </name>
    '''<date> 2015-04-24 </date>
    '''</author>
    '''<summary>
    '''select data with select filter
    '''</summary>
    Private Sub RefreshData()
        Try
            Dim type As String = cmbType.SelectedItem.ToString()
            Dim username As String = cmbUsername.SelectedItem.ToString()
            GetDataSource(type, username)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-06-30 </date>
    ''' </author>
    ''' <summary>
    ''' filter datagridview alarm and event
    ''' </summary>
    Private Sub FilterDataSourceByDescription()
        Try
            Dim strFilter As String = txtFilterDescription.Text.ToLower().Trim()
            Dim count As Integer = dgvUserLog.RowCount
            Dim isFirst As Boolean = False

            For i As Integer = 0 To dgvUserLog.RowCount - 1
                Dim cm As CurrencyManager = CType(BindingContext(dgvUserLog.DataSource), CurrencyManager)
                Me.dgvUserLog.CurrentCell = Nothing
                cm.SuspendBinding()

                Dim isVisible As Boolean = (dgvUserLog.Rows(i).Cells(4).Value.ToString().ToLower().Contains(strFilter))

                If Not isFirst AndAlso isVisible Then
                    isFirst = True
                    dgvUserLog.Rows(i).Selected = True
                End If
                dgvUserLog.Rows(i).Visible = isVisible

                If Not isVisible Then
                    count = count - 1
                End If
            Next

            labRow.Text = "(" + count.ToString() + ")"

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-06-30 </date>
    ''' </author>
    ''' <summary>
    ''' filter datatable affer button refresh click
    ''' </summary>
    Private Sub FilterDataTableByDescription()
        Try
            Dim strFilter As String = txtFilterDescription.Text.ToLower().Trim()

            If String.IsNullOrEmpty(strFilter) Then
                Exit Sub
            End If

            Dim dtTemp As DataTable = m_dt.Copy()
            Dim countDelete As Integer = 0
            For i As Integer = 0 To dtTemp.Rows.Count - 1
                Dim rowindex As Integer = i - countDelete

                If rowindex < m_dt.Rows.Count AndAlso Not m_dt.Rows(rowindex)(4).ToString().ToLower().Contains(strFilter) Then
                    m_dt.Rows.Remove(m_dt.Rows(rowindex))
                    countDelete = countDelete + 1
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-07-01 </date>
    ''' </author>
    ''' <summary>
    ''' txtFilterDescription_Click
    ''' </summary>
    Private Sub txtFilterDescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilterDescription.Click
        Try
            Dim pad As New KeyPad
            pad.IsCheckInvalidCharacter = True
            Dim Value As String = txtFilterDescription.Text.Trim()
            If pad.DisplayKeypad(Value, "Please enter search", False) = Windows.Forms.DialogResult.OK Then
                txtFilterDescription.Text = Value.Trim()
                FilterDataSourceByDescription()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2012-11-23</date>
    ''' </author>
    ''' <summary>
    ''' btnExportCSV_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExportCSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportCSV.Click
        Try
            Dim dlgSaveDialog As SaveFileDialog = New SaveFileDialog()
            'dlgSaveDialog.InitialDirectory = "C:\"
            dlgSaveDialog.Filter = "CSV File|*.csv"
            dlgSaveDialog.OverwritePrompt = True
            If dlgSaveDialog.ShowDialog = DialogResult.OK Then
                Dim fName = dlgSaveDialog.FileName
                If System.IO.File.Exists(dlgSaveDialog.FileName) Then
                    System.IO.File.Delete(dlgSaveDialog.FileName)
                End If
                Dim cellvalue As String = String.Empty

                Dim rowLine As String = ""
                Dim objWriter As New System.IO.StreamWriter(fName, True)
                rowLine = "UserName,Type,TimeStamp,Source,Description"
                objWriter.WriteLine(rowLine)
                rowLine = ""
                For j As Int32 = 0 To (dgvUserLog.Rows.Count - 2)
                    If dgvUserLog.Rows(j).Visible = True Then
                        For i As Int32 = 0 To (dgvUserLog.Columns.Count - 1)
                            dgvUserLog.CurrentCell = dgvUserLog.Rows(j).Cells(i)
                            If Not TypeOf dgvUserLog.CurrentRow.Cells.Item(i).Value Is DBNull Then
                                cellvalue = dgvUserLog.Item(i, j).Value
                            Else
                                cellvalue = ""
                            End If
                            rowLine = rowLine + cellvalue + ","
                        Next
                        objWriter.WriteLine(rowLine)
                        rowLine = ""
                    End If
                Next
                objWriter.Close()
                Utils.ShowAVPMessageBox("Exporting CSV is successful", "Export CSV File", MessageBoxIcon.Information, AVPMessageBox.AVPMessageBoxButton.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                            AVPLib.ContainerData.LogSource.AVPMainScreen, _
                            "[DataLog]: Export DataLog to CSV file:" & fName)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Finally
            FileClose(1)
        End Try
    End Sub
End Class
