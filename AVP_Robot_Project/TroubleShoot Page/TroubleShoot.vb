Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports AVP_Robot_Project
Imports AVPLib
Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPControls

Public Class TroubleShootPanel
    Private m_dtKepTagTable As DataTable
    Private m_arrListKepServerTag As ArrayList = Nothing
    Private m_kepserver As Communication.KEPServerConnection
    Private m_selectedGroup As String = String.Empty
    Private m_blnIsEditable As Boolean = False
    Const ITEM_ID_STR As String = "Item ID"
    Const DATA_TYPE_STR As String = "Data Type"
    Const VALUE_STR As String = "Value"
    Const DESC_STR As String = "Description"
    Const KEPSERVER_TAG_TABLE As String = "KepTagTable"
    Protected m_marshaller As DelegateMarshaler
#Region "Event and function"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Check permission of Diagnostic
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckPermission()
        Try
            If AVPLib.ContainerData.Permission(PERMISSION_001) Then
                Active_InActiveForm(True)
            Else
                Active_InActiveForm(False)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Check permission of Diagnostic
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Active_InActiveForm(ByVal blnStatus As Boolean)
        Dim objCassettesPanel As CassettesPanel = ContainerForm.CassettesPanel
        If objCassettesPanel.ISTM_ONLINE Then
            m_blnIsEditable = False
            Exit Sub
        End If
        m_blnIsEditable = blnStatus
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Init DataTable
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CreateChartData() As DataTable
        AVPLib.Log.guiLogger.Info("Enter CreateChartData")
        Try
            m_dtKepTagTable = New DataTable(KEPSERVER_TAG_TABLE)
            ' Add columns to the table.
            m_dtKepTagTable.Columns.Add(DESC_STR, GetType([String]))
            m_dtKepTagTable.Columns.Add(DATA_TYPE_STR, GetType([String]))
            m_dtKepTagTable.Columns.Add(VALUE_STR, GetType([String]))
            m_dtKepTagTable.Columns.Add(ITEM_ID_STR, GetType([String]))
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CreateChartData")
        Return m_dtKepTagTable
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Reload DataGrid to update new value from KepServer
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub IOScreen_Reload(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter IOScreen_Reload")
        m_marshaller.Invoke(Of Object)(New Threading.SendOrPostCallback(AddressOf UpdateUI), sender)
        AVPLib.Log.guiLogger.Info("Leave IOScreen_Reload")
    End Sub

    Private Sub UpdateUI(ByVal objKepItem As Object)
        AVPLib.Log.guiLogger.Info("Enter UpdateUI")
        Try
            If m_dtKepTagTable Is Nothing OrElse m_dtKepTagTable.Rows.Count = 0 Then
                Exit Sub
            End If
            Dim strTagUpdate As String = objKepItem.ToString()
            Dim strTag As String = strTagUpdate.Substring(0, strTagUpdate.IndexOf("#"))
            Dim strValue As String = strTagUpdate.Substring(strTagUpdate.IndexOf("#") + 1)
            For Each dgvRow As DataGridViewRow In dgvKepServerValue.Rows
                If dgvRow.Cells(ITEM_ID_STR).Value = strTag Then
                    dgvRow.Cells(VALUE_STR).Value = strValue
                    If IsNumeric(strValue) AndAlso dgvRow.Cells(ITEM_ID_STR).Value.ToString().Contains("MP275") Or dgvRow.Cells(ITEM_ID_STR).Value.Contains("GP275") Then
                        dgvRow.Cells(VALUE_STR).Value = Format(AVPLib.ContainerData.convertCGValue(CDbl(strValue)), "0.0E+00") '
                    ElseIf IsNumeric(strValue) AndAlso dgvRow.Cells(ITEM_ID_STR).Value.Contains("Ion") Then
                        dgvRow.Cells(VALUE_STR).Value = Format(AVPLib.ContainerData.convertIGValue(CDbl(strValue)), "0.0E+00") '
                    End If
                    Exit For
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave UpdateUI")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Load DataGrid 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub IOScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AVPLib.Log.guiLogger.Info("Enter IOScreen_Load")
        Try
            m_kepserver = CType(Communication.ConnectionManager.GetConnection(Equipments.KepServer.ToString()), _
            Communication.KEPServerConnection)

            m_dtKepTagTable = CreateChartData()
            Me.dgvKepServerValue.DataSource = m_dtKepTagTable
            Me.dgvKepServerValue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvKepServerValue.Columns(DATA_TYPE_STR).Width = 80
            dgvKepServerValue.Columns(VALUE_STR).Width = 100
            dgvKepServerValue.Columns(ITEM_ID_STR).Width = 350
            m_arrListKepServerTag = m_kepserver.GetGroupItem()
            Dim ParenNode As New TreeNode
            ParenNode.Text = "Kep Server Tag"
            Dim listOfDisplayGroup As New List(Of String)
            For Each groupItem As AVPLib.KepServerGroup In m_arrListKepServerTag
                For Each kepItem As AVPLib.KepServerItem In groupItem.ListItems
                    If Not listOfDisplayGroup.Contains(kepItem.DisplayGroup) AndAlso kepItem.DisplayGroup <> "TM.TMC" Then
                        listOfDisplayGroup.Add(kepItem.DisplayGroup)
                        ParenNode.Nodes.Add(kepItem.DisplayGroup)
                    End If
                Next
            Next
            tvKepServerTag.Nodes.Add(ParenNode)
            ParenNode.Expand()

            If ParenNode.FirstNode IsNot Nothing Then
                m_selectedGroup = ParenNode.FirstNode.Text
                LoadGroupName(ParenNode.FirstNode.Text)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Exit IOScreen_Load")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Tree View node click
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadGroupName(ByVal GroupName As String)
        AVPLib.Log.guiLogger.Info("Enter LoadGroupName")
        Dim obj As AVPLib.KepServerItem = Nothing
        Try
            If m_kepserver Is Nothing Then
                AVPLib.Log.guiLogger.Error("Can not load KepServer Tag")
                Exit Sub
            End If
            m_dtKepTagTable.Clear()

            ' Fetch data
            For Each item As AVPLib.KepServerGroup In m_arrListKepServerTag
                For Each obj In item.ListItems
                    If obj.DisplayGroup = GroupName Then
                        Dim tagValue As String = m_kepserver.LoadKepSeverValue(obj.KepServerName, item.GroupName)
                        If Not String.IsNullOrEmpty(tagValue) Then
                            With obj.KepServerName
                                If (.Contains("GP275") Or .Contains("MP275")) AndAlso Not (obj.DataType = "Boolean") Then
                                    tagValue = Format(AVPLib.ContainerData.convertCGValue(CDbl(tagValue)), "0.0E+00")
                                ElseIf .Contains("Ion") AndAlso Not (obj.DataType = "Boolean") Then
                                    tagValue = Format(AVPLib.ContainerData.convertIGValue(CDbl(tagValue)), "0.0E+00")
                                End If
                            End With
                            m_dtKepTagTable.Rows.Add(obj.Description, obj.DataType, tagValue, obj.KepServerName) ' Desc, DataType, Value, TagID
                        End If
                    End If
                Next
                Exit For
            Next
            Me.dgvKepServerValue.DataSource = m_dtKepTagTable
            Me.dgvKepServerValue.Columns(0).SortMode = DataGridViewColumnSortMode.Automatic
            ' Update header font
            For Each col As DataGridViewColumn In dgvKepServerValue.Columns
                col.HeaderCell.Style.Font = New Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Next
            Me.dgvKepServerValue.Sort(Me.dgvKepServerValue.Columns(0), ListSortDirection.Ascending)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave LoadGroupName")
    End Sub   
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Menu Item Click==>not use 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EditItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter EditItemToolStripMenuItem_Click")
        Try
            Dim arrRowSelect As New ArrayList
            Dim dtWriteItem As New DataTable
            dtWriteItem.Columns.Add(DESC_STR, GetType([String]))
            dtWriteItem.Columns.Add(DATA_TYPE_STR, GetType([String]))
            dtWriteItem.Columns.Add(VALUE_STR, GetType([String]))
            dtWriteItem.Columns.Add(ITEM_ID_STR, GetType([String]))

            For i As Integer = 0 To dgvKepServerValue.SelectedCells.Count - 1
                If Not arrRowSelect.Contains(dgvKepServerValue.SelectedCells(i).RowIndex) Then
                    arrRowSelect.Add(dgvKepServerValue.SelectedCells(i).RowIndex)
                    dtWriteItem.Rows.Add(dgvKepServerValue.Item(0, dgvKepServerValue.SelectedCells(i).RowIndex).Value, _
                                         dgvKepServerValue.Item(1, dgvKepServerValue.SelectedCells(i).RowIndex).Value, _
                                         dgvKepServerValue.Item(2, dgvKepServerValue.SelectedCells(i).RowIndex).Value, _
                                         dgvKepServerValue.Item(3, dgvKepServerValue.SelectedCells(i).RowIndex).Value)

                End If
            Next
            Dim dlgWriteItem As New WriteItemDlg(m_kepserver)
            dlgWriteItem.dgvWriteItem.DataSource = dtWriteItem
            dlgWriteItem.GroupName = m_selectedGroup
            AddHandler dlgWriteItem.UpdateDesc, AddressOf UpdateDescHandler
            AddHandler dlgWriteItem.UpdateTagValue, AddressOf UpdateTagValueHandler
            dlgWriteItem.ShowDialog()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Exit EditItemToolStripMenuItem_Click")
    End Sub
#End Region

    ''' <author>
    '''    	<name> Vo Tan Dat </name>
    '''    	<date> 2010-04-28</date>
    ''' </author>
    ''' <summary>
    ''' Handle right click
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub dgvKepServerValue_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvKepServerValue.MouseDown                
        Try
            Dim hti As DataGridView.HitTestInfo = dgvKepServerValue.HitTest(e.X, e.Y)
            If hti.Type = DataGridViewHitTestType.Cell Then
                If Not Me.dgvKepServerValue.Rows(hti.RowIndex).Selected Then
                    Me.dgvKepServerValue.ClearSelection()
                    Me.dgvKepServerValue.Rows(hti.RowIndex).Selected = True
                End If
                ''                Me.ctxEditItem.Cursor = Cursors.Hand
                ''              Me.ctxEditItem.Show(dgvKepServerValue, e.X + 5, e.Y + 5)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Vo Tan Dat </name>
    '''    	<date> 2010-04-28</date>
    ''' </author>
    ''' <summary>
    ''' Check if current is readonly group
    ''' </summary>
    ''' <remarks></remarks>
    Private Function IsSelectingReadOnlyGroup() As Boolean
        If Not (m_blnIsEditable) Then
            Return True
        End If
        If m_selectedGroup = "TM.TMC.RO" Then
            Return False
        Else
            Return True
        End If
    End Function


    ''' <author>
    '''    	<name> Vo Tan Dat </name>
    '''    	<date> 2010-04-28</date>
    ''' </author>
    ''' <summary>
    ''' Handle enter key
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub dgvKepServerValue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvKepServerValue.KeyDown
        If e.KeyCode = Keys.Enter Then
            EditItemToolStripMenuItem_Click(sender, e)
            e.Handled = True
        End If
    End Sub

    ''' <author>
    '''    	<name> Vo Tan Dat </name>
    '''    	<date> 2010-04-28</date>
    ''' </author>
    ''' <summary>
    ''' Handle Cell click
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub dgvKepServerValue_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvKepServerValue.CellClick
        If e.RowIndex = -1 Or m_blnIsEditable = False Then
            Exit Sub
        End If
        EditItemToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub UpdateDescHandler(ByVal Tag_ID As String, ByVal Desc As String)
        For Each row As DataGridViewRow In dgvKepServerValue.Rows
            If row.Cells(ITEM_ID_STR).Value.ToString() = Tag_ID Then
                ' Update the GUI
                row.Cells(DESC_STR).Value = Desc
                ' Update the data
                For Each kepGroup As AVPLib.KepServerGroup In m_arrListKepServerTag
                    For Each kepItem As AVPLib.KepServerItem In kepGroup.ListItems
                        If kepItem.KepServerName = Tag_ID Then
                            kepItem.Description = Desc
                            ' Exit from tag list
                            Exit For
                        End If
                    Next
                Next
                ' Exit from Loop
                Exit For
            End If
        Next
        Me.dgvKepServerValue.Sort(Me.dgvKepServerValue.Columns(0), ListSortDirection.Ascending)
    End Sub
 ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-04-28</date>
    ''' </author>
    ''' <summary>
    ''' Handle Cell click
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateTagValueHandler(ByVal Tag_ID As String, ByVal NewValue As String)
        For Each row As DataGridViewRow In dgvKepServerValue.Rows
            If row.Cells(ITEM_ID_STR).Value.ToString() = Tag_ID Then
                ' Update the GUI
                row.Cells(VALUE_STR).Value = NewValue
                ' Exit from Loop
                Exit For
            End If
        Next
    End Sub

    Private Sub dgvKepServerValue_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvKepServerValue.CellFormatting
        If e.RowIndex <> -1 Then
            ' description can always be edited
            If e.ColumnIndex = 0 Then
                e.CellStyle.ForeColor = Color.Black
            Else
                If (Not IsSelectingReadOnlyGroup()) And (e.ColumnIndex = 2) Then ' Can edit and column is Value
                    e.CellStyle.ForeColor = Color.Black
                Else
                    e.CellStyle.ForeColor = Color.Gray ' read only cell
                End If
            End If
        End If
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Tree View node click
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub tvKepServerTag_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvKepServerTag.AfterSelect
        AVPLib.Log.guiLogger.Info("Enter tvKepServerTag_AfterSelect")
        Try
            m_selectedGroup = e.Node.Text
            LoadGroupName(m_selectedGroup)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Exit tvKepServerTag_AfterSelect")
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_marshaller = DelegateMarshaler.Create()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub SetOnlineOfflineForm(ByVal blnIsOnline As Boolean)
        Active_InActiveForm(Not blnIsOnline)
    End Sub
End Class
   