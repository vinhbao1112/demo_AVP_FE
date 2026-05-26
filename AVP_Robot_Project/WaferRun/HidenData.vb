Imports System.Text.RegularExpressions
Imports System.IO

Public Class HidenData

    Private Const COL_STEPNO As String = "StepNo"

    Private m_dtHidenInfo As DataTable = Nothing
    Private m_dtHidenData As DataTable = Nothing
    Private m_dtHidenStep As DataTable = Nothing

    Private m_dicHidenStepData As Dictionary(Of String, HidenDataTable)
    Private m_arrFiles As String() = Nothing

    Private mouseOffset As Point = New Point(0, 0)
    Private isDragDrop As Boolean = False

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.dgvStep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvStep.Height = 120
    End Sub

    Public Sub AddSteps(ByVal arrName As String(), ByVal strWaferID As String)
        Try
            If m_dicHidenStepData Is Nothing Then
                m_dicHidenStepData = New Dictionary(Of String, HidenDataTable)
            End If

            m_arrFiles = arrName
            lblWaferID.Text = strWaferID

            m_dtHidenStep = New DataTable("HidenStep")
            m_dtHidenStep.Columns.Add(COL_STEPNO)

            For Each str As String In arrName
                Dim match As Match = Regex.Match(str, ".*_(Step\d+)\.\w+$")
                If match.Success Then
                    m_dicHidenStepData.Add(match.Groups(1).Value, Nothing)
                    m_dtHidenStep.Rows.Add(match.Groups(1).Value)
                End If
            Next

            dgvStep.DataSource = m_dtHidenStep

            If m_dtHidenStep.Rows.Count > 0 Then
                Dim CellEvent As New DataGridViewCellEventArgs(0, 0) 'load as default view
                dgvStep_CellClick(Me, CellEvent)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub dgvStep_CellClick(ByVal sender As System.Object, ByVal e As DataGridViewCellEventArgs) Handles dgvStep.CellClick
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                dgvData.DataSource = Nothing
                dgvData.Columns.Clear()
                dgvInfo.DataSource = Nothing
                dgvInfo.Columns.Clear()
                If dgvStep.RowCount <= 0 Then
                    Exit Sub
                End If

                Dim strSelectedStep As String = dgvStep.Item(COL_STEPNO, e.RowIndex).Value
                If Not String.IsNullOrEmpty(strSelectedStep) Then
                    ShowHidenDataToGrid(strSelectedStep)
                End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub ShowHidenDataToGrid(ByVal strSelectedStep As String)
        Try
            If m_dicHidenStepData IsNot Nothing Then

                Dim tableHeader As String = String.Empty
                Dim hidenData As HidenDataTable = Nothing
                If m_dicHidenStepData(strSelectedStep) Is Nothing Then
                    If m_arrFiles IsNot Nothing AndAlso m_arrFiles.Length > 0 Then

                        Dim lstHidenInfo As New List(Of String())
                        Dim lstHidenData As New List(Of String())
                        hidenData = New HidenDataTable()
                        Dim fileName As String = String.Empty
                        For Each file As String In m_arrFiles
                            Dim match As Match = Regex.Match(file, ".*_" & strSelectedStep & "\.\w+$")
                            If match.Success Then
                                fileName = file
                                Exit For
                            End If
                        Next

                        Dim fs As FileStream = New FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                        Using reader As StreamReader = New StreamReader(fs)
                            Dim inTable As Boolean = False
                            Dim line As String = String.Empty
                            Dim iColumnHeader As Int16 = 0
                            Dim strHidenInfo As String
                            Do
                                line = reader.ReadLine()
                                If line Is Nothing Then Exit Do
                                If line.StartsWith("""Time"",""ms""") Then
                                    inTable = True
                                    tableHeader = line.Replace("""", "")
                                    hidenData.ColumnName = tableHeader
                                    iColumnHeader = tableHeader.Trim().Split(",").Length

                                ElseIf inTable AndAlso iColumnHeader > 0 Then
                                    Dim arrColumn As String() = line.Trim().Split(",")
                                    If arrColumn.Length = iColumnHeader Then
                                        lstHidenData.Add(arrColumn)
                                    End If

                                Else
                                    strHidenInfo = line.Replace("""", "")
                                    Dim arrColumn As String() = strHidenInfo.Trim().Split(",")
                                    lstHidenInfo.Add(arrColumn)
                                End If
                            Loop Until line Is Nothing
                        End Using
                        hidenData.HidenData = lstHidenData
                        hidenData.HidenInfo = lstHidenInfo
                        m_dicHidenStepData(strSelectedStep) = hidenData

                    End If
                End If

                m_dtHidenData = New DataTable("HidenData" & strSelectedStep)
                If hidenData Is Nothing Then
                    hidenData = m_dicHidenStepData(strSelectedStep)
                End If

                m_dtHidenInfo = New DataTable("HidenInfo" & strSelectedStep)
                Dim lstInfo As List(Of String()) = hidenData.HidenInfo
                For i As Int16 = 0 To lstInfo.Count - 1
                    Dim iCurColumnCount As Int16 = m_dtHidenInfo.Columns.Count
                    If iCurColumnCount < lstInfo(i).Length Then
                        For j As Int16 = 0 To lstInfo(i).Length - iCurColumnCount - 1
                            If j > -1 AndAlso Not String.IsNullOrEmpty(lstInfo(i)(iCurColumnCount + j)) Then
                                m_dtHidenInfo.Columns.Add()
                            End If
                        Next
                    End If
                    Dim dtRow As DataRow = m_dtHidenInfo.NewRow
                    For j As Int16 = 0 To lstInfo(i).Length - 1
                        If Not String.IsNullOrEmpty(lstInfo(i)(j)) Then
                            dtRow(j) = lstInfo(i)(j).Trim()
                        End If
                    Next
                    m_dtHidenInfo.Rows.Add(dtRow)
                Next

                If String.IsNullOrEmpty(tableHeader) Then
                    tableHeader = hidenData.ColumnName
                End If

                Dim arrHeader As String() = tableHeader.Split(",")
                Dim arrLength As Int16 = arrHeader.Length - 1
                For i As Int16 = 0 To arrLength
                    If Not String.IsNullOrEmpty(arrHeader(i)) Then
                        m_dtHidenData.Columns.Add(arrHeader(i))
                    End If
                Next

                Dim lstData As List(Of String()) = hidenData.HidenData
                For i As Int16 = 0 To lstData.Count - 1
                    Dim dtRow As DataRow = m_dtHidenData.NewRow
                    Dim arrData As String() = lstData(i)
                    For j As Int16 = 0 To arrLength
                        If Not String.IsNullOrEmpty(arrData(j)) Then
                            dtRow(j) = arrData(j).Trim()
                        End If
                    Next
                    m_dtHidenData.Rows.Add(dtRow)
                Next

                dgvInfo.DataSource = m_dtHidenInfo
                dgvInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
                dgvInfo.AutoResizeColumns()
                dgvInfo.ColumnHeadersVisible = False

                dgvData.DataSource = m_dtHidenData
                For Each column As DataGridViewColumn In dgvData.Columns
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#Region "Event"
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub HidenData_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub lblHeader_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlHeader.MouseDown, lblWaferID.MouseDown, Label5.MouseDown
        mouseOffset = New Point(e.Location.X, e.Location.Y)
        isDragDrop = True
    End Sub

    Private Sub lblHeader_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlHeader.MouseMove, lblWaferID.MouseMove, Label5.MouseMove
        If isDragDrop Then
            Dim point As Point = Me.Location
            Me.Location = New Point(point.X + (e.Location.X - mouseOffset.X), point.Y + (e.Location.Y - mouseOffset.Y))
            Me.Opacity = 0.5
        End If
    End Sub

    Private Sub lblHeader_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlHeader.MouseUp, lblWaferID.MouseUp, Label5.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso isDragDrop Then
            isDragDrop = False
            Me.Opacity = 1
        End If
    End Sub
#End Region

    Friend Class HidenDataTable
        Private m_strColumnName As String = String.Empty
        Private m_lstHidenData As List(Of String())
        Private m_lstHidenInfo As List(Of String())

        Public Property ColumnName() As String
            Get
                Return m_strColumnName
            End Get
            Set(ByVal value As String)
                m_strColumnName = value
            End Set
        End Property

        Public Property HidenData() As List(Of String())
            Get
                Return m_lstHidenData
            End Get
            Set(ByVal value As List(Of String()))
                m_lstHidenData = value
            End Set
        End Property

        Public Property HidenInfo() As List(Of String())
            Get
                Return m_lstHidenInfo
            End Get
            Set(ByVal value As List(Of String()))
                m_lstHidenInfo = value
            End Set
        End Property
    End Class
End Class