Imports HRecipeLibrary

Public Class QuickViewRecipe
    Private objectDataTable As DataTable = Nothing
    Private dictionaryColor As Dictionary(Of Integer, String) = Nothing

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2016-02-03 </date>
    ''' </author>
    ''' <summary>
    ''' Set Title
    ''' </summary>
    Public Property Title() As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property
    Private m_recipeTemplatePath As String = String.Empty
    Public Property RecipeTemplatePathQuickView() As String
        Get
            Return m_recipeTemplatePath
        End Get
        Set(ByVal value As String)
            m_recipeTemplatePath = value
        End Set
    End Property

    Private m_recipePath As String = String.Empty
    Public Property RecipePathQuickView() As String
        Get
            Return m_recipePath
        End Get
        Set(ByVal value As String)
            m_recipePath = value
        End Set
    End Property
    Private m_hRecipe As HRecipe = Nothing
    Public Property HRecipeQuickView() As HRecipe
        Get
            Return m_hRecipe
        End Get
        Set(ByVal value As HRecipe)
            m_hRecipe = value
        End Set
    End Property
    Private m_dataTable As DataTable = Nothing
    Public Property DataTableQuickView() As DataTable
        Get
            Return m_dataTable
        End Get
        Set(ByVal value As DataTable)
            m_dataTable = value
        End Set
    End Property
    Private m_Dictionary As Dictionary(Of Integer, String) = Nothing
    Public Property DictionaryQuickView() As Dictionary(Of Integer, String)
        Get
            Return m_Dictionary
        End Get
        Set(ByVal value As Dictionary(Of Integer, String))
            m_Dictionary = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2016-02-03 </date>
    ''' </author>
    ''' <summary>
    ''' LoadDataGrid
    ''' </summary>>
    Public Sub LoadDataGrid(ByVal recipeTemplatePath As String, ByVal recipePath As String, ByVal hRecipe As HRecipe, Optional ByVal dataTable As DataTable = Nothing, Optional ByVal dictionary As Dictionary(Of Integer, String) = Nothing)
        Try
            If dataTable IsNot Nothing Then
                objectDataTable = dataTable.Copy()
            End If

            dictionaryColor = dictionary

            Me.dgvChamber.LoadDataGrid(recipeTemplatePath, recipePath, hRecipe, objectDataTable)

            If objectDataTable Is Nothing Then
                objectDataTable = CType(Me.dgvChamber.DataSource, DataTable)
            End If

            Dim rowHeight As Integer = 30

            If Me.dgvChamber.Rows.Count > 0 Then
                rowHeight = Me.dgvChamber.Rows(0).Height
            End If
            Me.Height = (rowHeight * dgvChamber.Rows.Count) + 120

        Catch ex As Exception
            Logger.Error(ex.Message)
        End Try
    End Sub

    Public Sub ZoomGrid(ByVal zoom As String)
        Dim newHeight As Integer = 0
        Dim newSize As Integer = 0
        If (zoom = "OUT") Then
            newSize = -2
        Else
            newSize = 2
        End If

        Dim dataTable As DataTable = DataTableQuickView
        If dataTable IsNot Nothing Then
            objectDataTable = dataTable.Copy()
        End If

        dictionaryColor = DictionaryQuickView

        Me.dgvChamber.RowTemplate.DefaultCellStyle.Font = New Font(Me.dgvChamber.RowTemplate.DefaultCellStyle.Font.Name, Me.dgvChamber.RowTemplate.DefaultCellStyle.Font.Size + newSize, Me.dgvChamber.RowTemplate.DefaultCellStyle.Font.Style)
        Me.dgvChamber.LoadDataGrid(RecipeTemplatePathQuickView, RecipePathQuickView, HRecipeQuickView, objectDataTable)

        If objectDataTable Is Nothing Then
            objectDataTable = CType(Me.dgvChamber.DataSource, DataTable)
        End If

        Dim rowHeight As Integer = CInt(Me.dgvChamber.RowTemplate.Height)

        If Me.dgvChamber.Rows.Count > 0 Then
            rowHeight = Me.dgvChamber.Rows(0).Height
        End If
        Me.Height = (rowHeight * dgvChamber.Rows.Count) + 120

        'apply recipe param show or not show
        ShownRecipeParam()
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-05-20 </date>
    ''' </author>
    ''' <summary>
    ''' Cleanup memory
    ''' </summary>
    Private Sub QuickViewRecipe_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If objectDataTable IsNot Nothing Then
                objectDataTable.Dispose()
            End If
        Catch ex As Exception
            Logger.Error(ex.Message)
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2017-11-09 </date>
    ''' </author>
    ''' <summary>
    ''' Change cell forecolor when quick view is shown
    ''' </summary>
    Private Sub QuickViewRecipe_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ShownRecipeParam()
    End Sub
    ''' <author>
    '''    	<name> Tinh Le </name>
    '''    	<date> 2022-30-05 </date>
    ''' </author>
    ''' <summary>
    ''' Change Zoom size when quick view is shown
    ''' </summary>
    Private Sub btnZoomInSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomInSize.Click
        If Me.dgvChamber.RowTemplate.DefaultCellStyle.Font.Size < 24 Then
            ZoomGrid("IN")
        Else
            MessageBox.Show("Maximum zoom limit", "Zoom In", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnZoomOutSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomOutSize.Click
        If Me.dgvChamber.RowTemplate.DefaultCellStyle.Font.Size > 8 Then
            ZoomGrid("OUT")
        Else
            MessageBox.Show("Minimum zoom limit", "Zoom Out", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ShownRecipeParam()
        Try
            'apply recipe param show or not show
            For index As Integer = 0 To Me.dgvChamber.Rows.Count - 1
                Dim isVisible As Boolean = ChamberLib.CheckParameterRecipeVisible(dgvChamber.CurrentRecipe, Me.dgvChamber.Rows(index).Cells(HConstants.ColumnBelongToGroup).Value.ToString(), Me.dgvChamber.Rows(index).Cells(HConstants.ColumnParameterName).Value.ToString())

                If index = 0 Then
                    Dim cm As CurrencyManager = CType(BindingContext(dgvChamber.DataSource), CurrencyManager)
                    Me.dgvChamber.CurrentCell = Nothing
                    cm.SuspendBinding()
                    Me.dgvChamber.Rows(index).Visible = isVisible
                    cm.ResumeBinding()
                Else
                    Me.dgvChamber.Rows(index).Visible = isVisible
                End If
            Next

            If dictionaryColor IsNot Nothing Then
                For Each pair As KeyValuePair(Of Integer, String) In dictionaryColor
                    Dim valueArray As String() = pair.Value.Split(New String() {","}, StringSplitOptions.RemoveEmptyEntries)

                    For index As Integer = 0 To valueArray.Length - 1
                        Dim columnIndex As Integer = 0
                        If Integer.TryParse(valueArray(index), columnIndex) Then
                            Me.dgvChamber.Rows(pair.Key).Cells(columnIndex).Style.ForeColor = Color.Red
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            Logger.Error(ex.Message)
        End Try
    End Sub
End Class