Imports System.Drawing
Imports System.Windows.Forms

Public Class RecipeDataGridView
    Inherits System.Windows.Forms.DataGridView

    Private m_gridViewFont As New Font("Times New Roman", 8, FontStyle.Bold)
    Private m_RecipeSteps As Int16 = 0
    Private m_currentRecipe As DBRecipe

    ''' <author>Hai Tran</author>
    ''' <date>2017-01-23</date>
    ''' <summary>
    ''' Gets current view recipe.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CurrentRecipe() As DBRecipe
        Get
            Return m_currentRecipe
        End Get
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2016-02-02 </date>
    ''' </author>
    ''' <summary>
    ''' Clear data on grid.
    ''' </summary>
    Private Sub ClearGrid()
        Me.Columns.Clear()
        Me.DataSource = Nothing
    End Sub

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-01-23 </date>
    ''' </author>
    ''' <summary>
    ''' Set Title
    ''' </summary>
    Public ReadOnly Property RecipeSteps() As Int16
        Get
            Return m_RecipeSteps
        End Get
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2016-02-02 </date>
    ''' </author>
    ''' <summary>
    ''' Load data grid view.
    ''' </summary>>
    Public Sub LoadDataGrid(ByVal recipeTemplatePath As String, ByVal recipePath As String, ByVal hRecipe As HRecipe, Optional ByVal objectDataTable As DataTable = Nothing)
        Try
            ClearGrid()

            If (String.IsNullOrEmpty(recipeTemplatePath)) OrElse (String.IsNullOrEmpty(recipePath)) OrElse (hRecipe Is Nothing) Then
                Return
            End If

            Dim selectedRecipe As DBRecipe = Nothing

            If objectDataTable Is Nothing Then
                selectedRecipe = hRecipe.CreateDBRecipe(recipeTemplatePath, recipePath)
                ChamberLib.ConvertToRealValue(selectedRecipe, True)
                objectDataTable = ChamberLib.CreateDataTableRecipe(selectedRecipe)
            Else
                selectedRecipe = hRecipe.CreateDBRecipe(recipeTemplatePath)
            End If
            m_currentRecipe = selectedRecipe
            If selectedRecipe IsNot Nothing Then
                m_RecipeSteps = selectedRecipe.ListOfRecipeSteps.Count
            Else
                m_RecipeSteps = 0
            End If

            For i As Integer = 0 To objectDataTable.Columns.Count - 1
                Dim dc As DataColumn = objectDataTable.Columns.Item(i)
                Dim Column As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()

                Column.HeaderText = dc.Caption
                Column.Name = dc.ColumnName
                Column.DataPropertyName = dc.ColumnName
                Column.SortMode = DataGridViewColumnSortMode.NotSortable

                If i = 0 Then
                    Column.Width = 220
                    Column.ReadOnly = True
                Else
                    Column.Width = 64
                End If

                Me.Columns.Add(Column)
                If ChamberLib.IsHiddenColumn(dc.ColumnName) Then
                    Column.Visible = False
                End If
            Next

            If Me.Columns.Count > 0 Then ''Freezing first column
                Me.Columns(0).Frozen = True
            End If

            Me.DataSource = objectDataTable

            Me.AllowUserToResizeRows = False
            Me.Font = m_gridViewFont
        Catch ex As Exception
            Logger.Error(ex.Message)
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2016-02-02 </date>
    ''' </author>
    ''' <summary>
    ''' Initialize data grid view
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle

        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()

        Me.AllowUserToAddRows = False
        Me.AllowUserToDeleteRows = False
        Me.AllowUserToResizeColumns = False
        Me.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.BackgroundColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.ColumnHeadersHeight = 30
        Me.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Columns.Clear()
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DefaultCellStyle = DataGridViewCellStyle3
        Me.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EnableHeadersVisualStyles = False
        Me.Location = New System.Drawing.Point(0, 0)
        Me.ReadOnly = True
        Me.RowHeadersVisible = False
        Me.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.RowTemplate.Height = 16
        Me.Size = New System.Drawing.Size(1000, 1000)
        Me.TabIndex = 0
        
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-02-02</date>
    ''' </author>
    ''' <summary>
    ''' Paint data grid view cell
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RecipeDataGridView_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles Me.CellPainting
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 _
                    AndAlso Me.Item(HConstants.ColumnBelongToGroup, e.RowIndex).Value.ToString.Length = 0 Then
                Dim nWidth As Integer = 0
                Dim gridBrush As New SolidBrush(Me.GridColor)
                Dim backColorBrush As New SolidBrush(SystemColors.Control)
                Dim separatorBrush As New SolidBrush(SystemColors.ControlDark)
                Dim separatorPen As New Pen(separatorBrush)
                Dim textFont As New Font("Arial", 10, FontStyle.Regular)

                e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                '' Draw the separator for rows
                e.Graphics.DrawLine(separatorPen, _
                              e.CellBounds.Left, e.CellBounds.Bottom - 1, _
                              e.CellBounds.Right, e.CellBounds.Bottom - 1)

                '' Draw the text
                Dim strText As String = "          " & Me.Item(0, e.RowIndex).Value.ToString()
                Dim rectDest As RectangleF = RectangleF.Empty
                Dim sf As New StringFormat()
                sf.Alignment = StringAlignment.Near
                sf.LineAlignment = StringAlignment.Center
                sf.Trimming = StringTrimming.EllipsisCharacter
                rectDest = New RectangleF(0, e.CellBounds.Top, nWidth, e.CellBounds.Height)

                e.Graphics.DrawString(strText, textFont, Brushes.DarkBlue, rectDest, sf)
                e.Handled = True

                sf.Dispose()
                gridBrush.Dispose()
                backColorBrush.Dispose()
                separatorPen.Dispose()
                separatorBrush.Dispose()
                textFont.Dispose()
            End If

        Catch ex As Exception
            Trace.WriteLine(ex.ToString())
        End Try
    End Sub

    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()

    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2019-07-31</date>
    ''' <summary>
    ''' Handles for resuming binding when data source changed.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnDataSourceChanged(ByVal e As System.EventArgs)
        MyBase.OnDataSourceChanged(e)
        Try
            If Me.DataSource IsNot Nothing Then
                Dim cm As CurrencyManager = CType(BindingContext(Me.DataSource), CurrencyManager)
                cm.ResumeBinding()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2019-07-31</date>
    ''' <summary>
    ''' Suspend binding after data binding completed.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnDataBindingComplete(ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs)
        MyBase.OnDataBindingComplete(e)
        Try
            If Me.DataSource IsNot Nothing Then
                Dim cm As CurrencyManager = CType(BindingContext(Me.DataSource), CurrencyManager)
                cm.SuspendBinding()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

End Class
