Imports System.IO
Imports System.Text
Imports System.Xml
Imports AVPLib.ConstEnum
Imports AVPLib.ContainerDAO
Imports AVP_Robot_Project.ConstantAndEnum
Imports System
Imports System.Globalization

Public Class LotDatalog
    Public Sub CheckPermission()
        If AVPLib.ContainerData.Permission(PERMISSION_011) Then
            ActiveInActiveForm(True)
        Else
            ActiveInActiveForm(False)
        End If
    End Sub
    Private Sub ActiveInActiveForm(ByVal blnStatus As Boolean)
        Try
            dtFilter.Enabled = blnStatus
            tabLotDatalog.Enabled = blnStatus
            dgvLotList.Enabled = blnStatus
            btnApply.Enabled = blnStatus
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Protected Overrides Sub CreateStatusTree()
        Try
            m_stoStatusObject.Name = Me.Name
            Dim stbRefresh As New SL_LotDatalogStatus(btnRefresh)
            m_stoStatusObject.AddChild(stbRefresh)
            btnRefresh.ParentStatusObj = m_stoStatusObject
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private Sub dgvLotList_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLotList.CellClick
        Try
            Dim LotID As String = dgvLotList.Rows(e.RowIndex).Cells(1).Value.ToString()
            dtgLotDatalogInfo.DataSource = AVPLib.Business.AVPLotDatalog.GetLotDatalogInfo(LotID)
            SetLotDatalogTableWith()
            dtgLotDatalogInfo.Refresh()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private Sub LotDatalog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadAllData(DateTime.Now.ToString("yyyy.MM.dd"))
        SetLabelItemCount()
    End Sub
    Private Sub dtFilter_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFilter.ValueChanged
        Try
            If dtFilter.Value.ToString("yyyy.MM.dd") = Date.Today.ToString("yyyy.MM.dd") Then
                RefreshSelectedDate()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private Sub SetLotDatalogTableWith()
        If (dtgLotDatalogInfo.Rows.Count > 0) Then
            Dim totalLenght As Integer = dtgLotDatalogInfo.Width
            dtgLotDatalogInfo.Columns(0).Width = totalLenght / 8
            dtgLotDatalogInfo.Columns(1).Width = (totalLenght * 7) / 5
        End If
    End Sub
    'Private Sub btnRefresh_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    LoadAllData()
    'End Sub
    Private Sub LoadAllData()
        Try
            '0 = ID, 1 = LotName, 2 = StartDate
            Dim dt As DataTable = AVPLib.Business.AVPLotDatalog.GetLotDatalogName()
            dgvLotList.DataSource = dt
            If (dgvLotList.Columns.Count = 2) Then
                dgvLotList.Columns(0).Visible = True
                dgvLotList.Columns(1).Visible = False
                Dim ColumnWidth As Integer = dgvLotList.Width
                dgvLotList.Columns(0).Width = ColumnWidth

                Dim oldColumn As DataGridViewColumn = dgvLotList.Columns(1)
                dgvLotList.Sort(dgvLotList.Columns(1), System.ComponentModel.ListSortDirection.Descending)

                If (dgvLotList.Rows.Count > 0) Then
                    'load default for lot data log info at pos 1
                    Dim LotID As String = dgvLotList.Rows(0).Cells(1).Value.ToString()
                    dtgLotDatalogInfo.DataSource = AVPLib.Business.AVPLotDatalog.GetLotDatalogInfo(LotID)
                    SetLotDatalogTableWith()
                Else
                    dtgLotDatalogInfo.DataSource = Nothing
                End If
            Else
                dtgLotDatalogInfo.DataSource = Nothing
                dgvLotList.DataSource = Nothing
            End If
            dgvLotList.Refresh()
            SetLabelItemCount()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private Sub LoadAllData(ByVal byDay As String)
        Try
            '0 = ID, 1 = LotName, 2 = StartDate

            dgvLotList.DataSource = AVPLib.Business.AVPLotDatalog.GetLotDatalogName(byDay)
            If (dgvLotList.Columns.Count = 2) Then
                dgvLotList.Columns(0).Visible = True
                dgvLotList.Columns(1).Visible = False
                Dim ColumnWidth As Integer = dgvLotList.Width
                dgvLotList.Columns(0).Width = ColumnWidth

                Dim oldColumn As DataGridViewColumn = dgvLotList.Columns(1)
                dgvLotList.Sort(dgvLotList.Columns(1), System.ComponentModel.ListSortDirection.Descending)

                If (dgvLotList.Rows.Count > 0) Then
                    'load default for lot data log info at pos 1
                    Dim LotID As String = dgvLotList.Rows(0).Cells(1).Value.ToString()
                    dtgLotDatalogInfo.DataSource = AVPLib.Business.AVPLotDatalog.GetLotDatalogInfo(LotID)
                    SetLotDatalogTableWith()
                Else
                    dtgLotDatalogInfo.DataSource = Nothing
                End If
            Else
                dgvLotList.DataSource = Nothing
                dtgLotDatalogInfo.DataSource = Nothing
            End If
            dgvLotList.Refresh()
            dtgLotDatalogInfo.Refresh()
            SetLabelItemCount()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Public Sub RefreshData()
        Try
            If dtFilter.Value.ToString("yyyy.MM.dd") = Date.Today.ToString("yyyy.MM.dd") Then
                Dim strShortDate As String = Format(dtFilter.Value, "yyyy.MM.dd")
                LoadAllData(strShortDate)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    'Dat Cao *** 2012-23-03 ***0000567: [KhoiHa 21-03-2012] - Lot transcript. Alarm should be high light in red.
    Private Sub dtgLotDatalogInfo_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgLotDatalogInfo.CellFormatting
        Try
            If dtgLotDatalogInfo.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() = "Alarm" Then
                dtgLotDatalogInfo.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.DarkRed
                dtgLotDatalogInfo.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
            ElseIf dtgLotDatalogInfo.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() = "Warning" Then
                dtgLotDatalogInfo.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
                dtgLotDatalogInfo.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tu Nguyen </name>
    '''     <date> 2015-04-24 </date>
    ''' </author>
    ''' <summary>
    ''' Enable/Disable control while refresh data
    ''' </summary>
    Private Sub EnableControl(ByVal isEnabled As Boolean)
        Try
            btnApply.Enabled = isEnabled
            dtFilter.Enabled = isEnabled
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tu Nguyen </name>
    '''     <date> 2015-04-24 </date>
    ''' </author>
    ''' <summary>
    ''' Refresh data view
    ''' </summary>
    Private Sub RefreshSelectedDate()
        Try
            EnableControl(False)
            Dim strShortDate As String = Format(dtFilter.Value.ToString("yyyy.MM.dd"))
            LoadAllData(strShortDate)
            EnableControl(True)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Tu Nguyen </name>
    '''     <date> 2015-04-24 </date>
    ''' </author>
    ''' <summary>
    ''' Number of list item
    ''' </summary>
    Private Sub SetLabelItemCount()
        Try
            lblItemsCount.Text = dgvLotList.Rows.Count.ToString()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        RefreshSelectedDate()
    End Sub
End Class
