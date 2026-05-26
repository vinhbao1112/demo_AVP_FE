Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Imports AVPLib.ConstEnum
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class ViewRecipeDetail
    Private m_strTitle As String = String.Empty
    Private m_hstDisplayParam As New Hashtable
    Private m_hstOfParamValue As Hashtable

#Region "Properties"
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-09-03 </date>
    ''' </author>
    ''' <summary>
    ''' Set Title
    ''' </summary>
    ''' <param name="Title"></param>
    ''' <remarks></remarks>
    Public Property Title() As String
        Get
            Return m_strTitle
        End Get
        Set(ByVal value As String)
            m_strTitle = value
            Me.Text = m_strTitle
        End Set
    End Property
#End Region

#Region "Load Form"
    Private Sub ViewRecipeDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.dgvChamber.TabIndex = 0
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-09-03 </date>
    ''' </author>
    ''' <summary>
    ''' LoadDataGrid
    ''' </summary>
    ''' <param name="isNew"></param>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Public Sub LoadDataGrid(ByVal PMx As String, ByVal recipeName As String, ByVal dt As DataTable)
        Try
            ClearGrid()

            If (String.IsNullOrEmpty(PMx)) Or (String.IsNullOrEmpty(recipeName)) Then
                Return
            End If
            Me.Title = PMx & " - " & recipeName
            If Not recipeName.Contains(STR_XML_EXT) Then
                recipeName = recipeName & STR_XML_EXT
            End If
            Dim ChamberName As String = AVPLib.Utils.chamberName2ChamberID(PMx)
            Dim chamberModule As AVPLib.SystemModule = Nothing
            AVPLib.ContainerData.IsChamberVisible(ChamberName, chamberModule)

            Dim selectedRecipe As AVPLib.DBChamber = Nothing
            If dt Is Nothing Then
                selectedRecipe = AVPLib.ContainerData.Chamber(ChamberName, recipeName)
                m_hstOfParamValue = ListOfParamComboBox(selectedRecipe)
                selectedRecipe = ConvertToRealValue(selectedRecipe, True)
                selectedRecipe.ChamberType = chamberModule.Type.ToString()
                dt = AVPLib.ContainerData.ChamberDB(selectedRecipe, AVPLib.ContainerData.ChamberPVDType(ChamberName))
            End If

            For i As Integer = 0 To dt.Columns.Count - 1
                Dim dc As DataColumn = dt.Columns.Item(i)
                Dim Column As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
                Column.HeaderText = dc.Caption
                Column.Name = dc.ColumnName
                Column.DataPropertyName = dc.ColumnName
                Column.SortMode = DataGridViewColumnSortMode.NotSortable
                If i = 0 Then
                    Column.Width = 220
                    Column.ReadOnly = True
                Else
                    Column.Width = 107
                End If
                Me.dgvChamber.Columns.Add(Column)
                If AVPLib.Utils.IsHiddenColumn(dc.ColumnName) Then
                    Column.Visible = False
                End If
            Next

            If Me.dgvChamber.Columns.Count > 0 Then ''Freezing first column
                Me.dgvChamber.Columns(0).Frozen = True
            End If

            Me.dgvChamber.DataSource = dt
            Dim lstOfRowInvisible As New List(Of Int16)
            'apply recipe param show or not show
            For i As Integer = 0 To dgvChamber.Rows.Count - 1
                If (chamberModule.Type = SystemModule.ModuleType.PVD) OrElse
                (chamberModule.Type = SystemModule.ModuleType.PVD4) OrElse
                (chamberModule.Type = SystemModule.ModuleType.PVD5T) OrElse
                (chamberModule.Type = SystemModule.ModuleType.IBE) Then
                    Dim blnIsVisible As Boolean = Utils.CheckParamRecipe_Visible(dgvChamber.Rows(i).Cells(1).Value.ToString(), dgvChamber.Rows(i).Cells(5).Value.ToString(), ChamberName)
                    'Me.dgvChamber.Rows(i).Visible = blnIsVisible
                    If Not blnIsVisible Then
                        lstOfRowInvisible.Add(i)
                    End If
                End If
            Next
            For i As Integer = lstOfRowInvisible.Count - 1 To 0 Step -1
                dgvChamber.Rows.RemoveAt(lstOfRowInvisible.Item(i))
            Next
            Me.dgvChamber.AllowUserToResizeRows = False
            Me.dgvChamber.Font = New Font("Times New Roman", 8, FontStyle.Bold)
            Me.Width = 1270
            Me.Height = (Me.dgvChamber.Rows(0).Height * dgvChamber.Rows.Count) + 120
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-09-03 </date>
    ''' </author>
    ''' <summary>
    ''' ClearGird
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearGrid()
        Me.dgvChamber.Columns.Clear()
        Me.dgvChamber.DataSource = Nothing
    End Sub

    ''' <author>
    '''    	<name>Le Hieu Truc </name>
    '''    	<date> 2010-05-04</date>
    ''' </author>
    ''' <summary>
    ''' Get List of Param to Show on GUI (all display value)
    ''' </summary>
    ''' <param name="isNew"></param>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Private Function ListOfParamComboBox(ByVal selectedRecipe As AVPLib.DBChamber) As Hashtable
        Dim HstParamBoolean As New Hashtable
        Try
            For Each item As AVPLib.DBParameterGroup In selectedRecipe.ListGroupParameters
                For Each param As AVPLib.DBParameter In item.Parameters
                    If param.DisplayItems IsNot Nothing AndAlso param.DisplayItems.Count > 0 Then
                        Dim listOfItem As New List(Of String)
                        For Each kvp As KeyValuePair(Of String, String) In param.DisplayItems
                            listOfItem.Add(kvp.Key)
                        Next
                        '2014-03-17 Tin Pham: key = PVD.PowerDown, PVD6S.PowerDown, ...
                        Dim keyParamName As String = selectedRecipe.ChamberType & "." & param.Name
                        If Not (m_hstDisplayParam.Contains(keyParamName)) Then
                            m_hstDisplayParam.Add(keyParamName, param.DisplayItems)
                        End If
                        If Not (HstParamBoolean.Contains(param.Name)) Then
                            HstParamBoolean.Add(param.Name, listOfItem)
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return HstParamBoolean
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-05-04</date>
    ''' </author>
    ''' <summary>
    ''' Convert Value from GUI to Real value (eg: On/Off to True/False) before saving to file/ showing to GUI
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Function ConvertToRealValue(ByVal selectedRecipe As AVPLib.DBChamber, ByVal blnLoadFromFile As Boolean) As AVPLib.DBChamber
        Try
            For Each item As AVPLib.DBChamberStep In selectedRecipe.ListChamberSteps
                For Each param As AVPLib.DBGroupParameterValue In item.ListGroupParameterValues
                    For Each paramval As AVPLib.DBParameterValue In param.ListParameterValues
                        '2014-03-17 Tin Pham: key = PVD.PowerDown, PVD6S.PowerDown, ...
                        Dim keyParamvalName As String = selectedRecipe.ChamberType & "." & paramval.Name
                        If m_hstDisplayParam.Contains(keyParamvalName) And Not blnLoadFromFile Then
                            Dim realVal As KeyValuePair(Of String, String) = Nothing
                            For Each realVal In m_hstDisplayParam(keyParamvalName)
                                If realVal.Key = paramval.Value Then
                                    paramval.Value = realVal.Value
                                End If
                            Next
                        ElseIf m_hstDisplayParam.Contains(keyParamvalName) Then
                            Dim realVal As KeyValuePair(Of String, String) = Nothing
                            For Each realVal In m_hstDisplayParam(keyParamvalName)
                                If realVal.Value = paramval.Value Then
                                    paramval.Value = realVal.Key
                                End If
                            Next
                        End If
                    Next
                Next
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return selectedRecipe
    End Function
#End Region

#Region "Cell Paint"
    Private Sub dgvChamber_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvChamber.CellPainting
        Try
            Dim nColumnIndex As Int16 = Me.dgvChamber.Columns.GetColumnCount(DataGridViewElementStates.Visible)
            Dim nRowIndex As Int16 = e.RowIndex
            Dim i As Integer = 0
            Dim nWidth As Integer = 0
            Dim nWidthLeft As Integer = 0
            Dim strText As String = String.Empty
            Dim pen As New Pen(Brushes.Black)
            Dim dt As DataTable = Me.dgvChamber.DataSource

            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso _
            dgvChamber.Item("BelongToGroup", e.RowIndex).Value.ToString.Length = 0 Then
                Using gridBrush As Brush = New SolidBrush(Me.dgvChamber.GridColor), backColorBrush As Brush = New SolidBrush(SystemColors.Control)
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)
                    '' Draw the separator for rows
                    e.Graphics.DrawLine(New Pen(New SolidBrush(SystemColors.ControlDark)), _
                                  e.CellBounds.Left, e.CellBounds.Bottom - 1, _
                                  e.CellBounds.Right, e.CellBounds.Bottom - 1)
                    strText = "          " & dgvChamber.Item(0, nRowIndex).Value.ToString()
                    '' Draw the text
                    Dim rectDest As RectangleF = RectangleF.Empty
                    Dim sf As New StringFormat()
                    sf.Alignment = StringAlignment.Near
                    sf.LineAlignment = StringAlignment.Center
                    sf.Trimming = StringTrimming.EllipsisCharacter
                    rectDest = New RectangleF(0, e.CellBounds.Top, nWidth, e.CellBounds.Height)
                    e.Graphics.DrawString(strText, New Font("Arial", 10, FontStyle.Regular), Brushes.DarkBlue, rectDest, sf)
                    e.Handled = True
                End Using
            End If

        Catch ex As Exception
            Trace.WriteLine(ex.ToString())
        End Try
    End Sub
#End Region

End Class