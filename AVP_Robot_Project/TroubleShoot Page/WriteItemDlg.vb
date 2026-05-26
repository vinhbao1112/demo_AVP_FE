Imports AVPLib
Imports AVPControls

Public Class WriteItemDlg
    Private m_kepserver As Communication.KEPServerConnection    
    Const ITEM_DES_COLUMN As Integer = 0
    Const ITEM_DATATYPE_COLUMN As Integer = 1
    Const ITEM_VALUE_COLUMN As Integer = 2
    Const ITEM_ID_COLUMN As Integer = 3
    Dim ColumnIndex As Integer = 0
    Dim RowIndex As Integer = 0
    ' Using to store the selected group
    Public GroupName As String = String.Empty

    ' Event to update the grid of child window
    Public Event UpdateDesc(ByVal Tag_ID As String, ByVal Desc As String)
    Public Event UpdateTagValue(ByVal Tag_ID As String, ByVal TagValue As String)
    ' Check if des is edit
    Private m_blIsDesEdited As Boolean = False

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Button Cancel Click
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' button Ok click
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            btnApply_Click(sender, e)
            Me.Close()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' button Apply click
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        Dim NeedSave As Boolean = False
        Try
            For i As Integer = 0 To Me.dgvWriteItem.Rows.Count - 1
                Dim item As System.Windows.Forms.DataGridViewRow = Me.dgvWriteItem.Rows(i)
                m_kepserver.SendMessage(item.Cells(ITEM_ID_COLUMN).Value.ToString(), item.Cells(ITEM_VALUE_COLUMN).Value.ToString())
                'update value
                RaiseEvent UpdateTagValue(item.Cells(ITEM_ID_COLUMN).Value.ToString(), item.Cells(ITEM_VALUE_COLUMN).Value.ToString())
                If m_blIsDesEdited Then
                    If (i = Me.dgvWriteItem.Rows.Count - 1) Then
                        NeedSave = True
                    End If
                    AVPLib.ContainerData.SetKepServerTagDescription(GroupName, _
                                                                    item.Cells(ITEM_ID_COLUMN).Value.ToString(), _
                                                                    item.Cells(ITEM_DES_COLUMN).Value.ToString(), NeedSave)
                    RaiseEvent UpdateDesc(item.Cells(ITEM_ID_COLUMN).Value.ToString(), item.Cells(ITEM_DES_COLUMN).Value.ToString())                    
                End If
            Next
            m_blIsDesEdited = False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    '''
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal KepserverConnection As Communication.KEPServerConnection)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_kepserver = KepserverConnection
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvWriteItem.CellBeginEdit
        If (e.ColumnIndex = ITEM_DATATYPE_COLUMN) Or _
           (e.ColumnIndex = ITEM_ID_COLUMN) Or _
           ((e.ColumnIndex = ITEM_VALUE_COLUMN) And (GroupName <> "TM.TMC.RO")) Then
            dgvWriteItem.CancelEdit()
            e.Cancel = True
        End If
    End Sub

    Private Sub WriteItemDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgvWriteItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvWriteItem.Columns(ITEM_DATATYPE_COLUMN).Width = 100
        dgvWriteItem.Columns(ITEM_VALUE_COLUMN).Width = 80
        dgvWriteItem.Columns(ITEM_ID_COLUMN).Width = 260
    End Sub

    Private Sub dgvWriteItem_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWriteItem.CellClick
        ' For input number
        If e.ColumnIndex = ITEM_VALUE_COLUMN AndAlso e.RowIndex <> -1 Then

            ' Do nothing if readonly
            If (GroupName <> "TM.TMC.RO") Then
                Exit Sub
            End If

            Dim Value As String = String.Empty
            If Not IsDBNull(dgvWriteItem(e.ColumnIndex, e.RowIndex).Value) Then
                Value = dgvWriteItem(e.ColumnIndex, e.RowIndex).Value
            End If

            Dim pad As New NumPad()
            If not(dgvWriteItem(ITEM_DATATYPE_COLUMN, e.RowIndex).Value = "Boolean" )Then
                If pad.GetUserInput(Value, -1, -1, 0, 1000, "Please input number", 0, False, True) = MsgBoxResult.Ok Then
                    dgvWriteItem(e.ColumnIndex, e.RowIndex).Value = Value
                    dgvWriteItem.EndEdit()
                End If
            End If
        ElseIf e.ColumnIndex = ITEM_DES_COLUMN AndAlso e.RowIndex <> -1 Then ' Description column
            Dim Value As String = String.Empty
            If Not IsDBNull(dgvWriteItem(e.ColumnIndex, e.RowIndex).Value) Then
                Value = dgvWriteItem(e.ColumnIndex, e.RowIndex).Value
            End If
            Dim pad As New KeyPad()
            If pad.DisplayKeypad(Value, "Please input the description", False) = MsgBoxResult.Ok Then
                dgvWriteItem(e.ColumnIndex, e.RowIndex).Value = Value
                dgvWriteItem.EndEdit()
                m_blIsDesEdited = True
            End If
        End If

    End Sub

    Private Sub dgvWriteItem_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvWriteItem.CellFormatting
        If e.RowIndex <> -1 Then
            ' description can always be edited
            If e.ColumnIndex = 0 Then
                e.CellStyle.ForeColor = Color.Black
            Else
                If (GroupName = "TM.TMC.RO") And (e.ColumnIndex = 2) Then ' Can edit and column is Value
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
    '''
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub dgvWriteItem_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvWriteItem.MouseDown
        AVPLib.Log.guiLogger.Info("Enter dgvWriteItem_MouseDown")
        Try
            If (GroupName <> "TM.TMC.RO") Then
                Exit Sub
            End If
            ColumnIndex = dgvWriteItem.HitTest(e.X, e.Y).ColumnIndex
            RowIndex = dgvWriteItem.HitTest(e.X, e.Y).RowIndex
            If (RowIndex >= 0) AndAlso (ColumnIndex >= 0) Then
                If e.Button = Windows.Forms.MouseButtons.Left AndAlso _
               dgvWriteItem(ITEM_DATATYPE_COLUMN, RowIndex).Value = "Boolean" AndAlso ColumnIndex = ITEM_VALUE_COLUMN Then
                    Me.ctxMenu.Cursor = Cursors.Hand
                    Me.ctxMenu.Show(dgvWriteItem, e.X, e.Y)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Enter dgvWriteItem_MouseDown")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    '''
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub mnuFalse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFalse.Click, mnuTrue.Click
     Try
        If sender Is mnuFalse Then
            dgvWriteItem(ColumnIndex, RowIndex).Value = Boolean.FalseString
        ElseIf sender Is mnuTrue Then
            dgvWriteItem(ColumnIndex, RowIndex).Value = Boolean.TrueString
        End If
        dgvWriteItem.EndEdit()
      Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class