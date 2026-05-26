Imports HRecipeLibrary
Imports System.ComponentModel

Public Class SelectRecipeStepDialog

#Region "Contructors"

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2017-01-23 </date>
    ''' </author>
    ''' <summary>
    ''' Create new dialog.
    ''' </summary>>
    Public Sub New(ByVal recipeList As ArrayList, ByVal recipeTemplatePath As String, ByVal recipeFolderPath As String, ByVal hRecipe As HRecipe)
        InitializeComponent()

        Try
            m_recipeTemplatePath = recipeTemplatePath
            m_recipeFolderPath = recipeFolderPath
            m_hRecipe = hRecipe
            m_listRecipe = recipeList
            UpdateList(m_listRecipe)
        Catch ex As Exception
            Logger.Error(ex.Message)
        End Try
    End Sub

#End Region

#Region "Fields"
    Private m_selectedStep As Integer = -1
    Private m_selectedRecipe As String = String.Empty
    Private m_listRecipe As ArrayList
    Private m_hRecipe As HRecipe
    Private m_recipeTemplatePath As String
    Private m_recipeFolderPath As String

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2017-01-23</date>
    ''' <summary>
    ''' Gets selected step.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property SelectedStep() As Integer
        Get
            Return m_selectedStep
        End Get
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2017-01-23</date>
    ''' <summary>
    ''' Gets selected recipe.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property SelectedRecipe() As String
        Get
            Return m_selectedRecipe
        End Get
    End Property

#End Region

#Region "Public Methods"

#End Region

#Region "Private Methods"

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2017-01-23</date>
    ''' </author>
    ''' <summary>
    ''' Set dialog result and close form.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub DoClose()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-01-23</date>
    ''' <summary>
    ''' Update filter.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        Try
            Dim tmpList As ArrayList = AVPUtils.GetFilter(Me.txtFilter.Text, Me.m_listRecipe, True)
            Me.UpdateList(tmpList)
            tmpList.Clear()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-01-23</date>
    ''' <summary>
    ''' Update list box by specified data.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateList(ByVal listData As ArrayList)
        Try
            Me.lstItems.SuspendLayout()

            Me.lstItems.Items.Clear()

            ' Add data to listbox.
            If listData IsNot Nothing Then
                For Each item As Object In listData
                    Me.lstItems.Items.Add(item.ToString())
                Next
            End If

            ' Enable/Disable OK button.
            If Me.lstItems.Items.Count > 0 Then
                Me.lstItems.SelectedIndex = 0
                Me.btnOK.Enabled = True
            Else
                Me.btnOK.Enabled = False
            End If

            Me.lstItems.ResumeLayout(True)
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-01-23</date>
    ''' <summary>
    ''' Update data grid.
    ''' </summary>
    ''' <param name="recipePath"></param>
    ''' <remarks></remarks>
    Private Sub UpdateSelectedRecipe(ByVal recipePath As String)
        Try
            Me.dgvChamber.LoadDataGrid(m_recipeTemplatePath, recipePath, m_hRecipe)

            cbxStep.Items.Clear()
            If dgvChamber.DataSource IsNot Nothing Then
                Dim dtRecipe As DBRecipe = dgvChamber.CurrentRecipe
                If dtRecipe IsNot Nothing Then
                    For col As Integer = 1 To dtRecipe.ListOfRecipeSteps.Count
                        cbxStep.Items.Add(col)
                    Next
                End If
            End If
            cbxStep.SelectedIndex = 0

            UpdateEnableSelect()
        Catch ex As Exception
            Logger.Error(ex.Message)
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-01-23</date>
    ''' <summary>
    ''' Shows keypad to input filter.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.Click
        Try
            Dim pad As New KeyPad
            pad.IsEnableTextChange = True
            pad.StartPosition = FormStartPosition.Manual
            pad.Location = New Point(CInt((Screen.PrimaryScreen.Bounds.Width - pad.Width) / 2), Screen.PrimaryScreen.Bounds.Height - pad.Height - 90)
            pad.DisplayKeypad(txtFilter, "Enter Your Filter")
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-01-23</date>
    ''' <summary>
    ''' Cancel button action.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        DoClose()
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-01-23</date>
    ''' <summary>
    ''' Update recipe view.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lstItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstItems.SelectedIndexChanged
        Try
            If lstItems.SelectedItem IsNot Nothing Then
                Dim selectedRecipeName As String = lstItems.SelectedItem.ToString()

                Dim recipePath As String = m_recipeFolderPath & "\" & selectedRecipeName & ".xml"
                UpdateSelectedRecipe(recipePath)
            Else
                dgvChamber.DataSource = Nothing
                cbxStep.Items.Clear()
            End If
            UpdateEnableSelect()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-01-23</date>
    ''' <summary>
    ''' Update result
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            m_selectedRecipe = lstItems.SelectedItem.ToString()
            m_selectedStep = Integer.Parse(cbxStep.Text)
            DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-01-23</date>
    ''' <summary>
    ''' Update enable OK button.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateEnableSelect()
        Try
            Dim isEnabled As Boolean = True
            If lstItems.Items.Count > 0 Then
                Dim stepValue As Integer
                If Integer.TryParse(cbxStep.Text, stepValue) Then
                    If Not cbxStep.Items.Contains(stepValue) Then
                        isEnabled = False
                    End If
                Else
                    isEnabled = False
                End If
            Else
                isEnabled = False
            End If
            btnOK.Enabled = isEnabled
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-01-23</date>
    ''' <summary>
    ''' Update enable when text changed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cbxStep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxStep.TextChanged
        UpdateEnableSelect()
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2017-11-09 </date>
    ''' </author>
    ''' <summary>
    ''' Recipe param show or not show when quick view is shown
    ''' </summary>
    Private Sub SelectRecipeStepDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'apply recipe param show or not show
        For index As Integer = 0 To Me.dgvChamber.Rows.Count - 1
            Dim isVisible As Boolean = ChamberLib.CheckParameterRecipeVisible(dgvChamber.CurrentRecipe, Me.dgvChamber.Rows(index).Cells(HConstants.ColumnBelongToGroup).Value.ToString(), Me.dgvChamber.Rows(index).Cells(HConstants.ColumnParameterName).Value.ToString())
            Me.dgvChamber.Rows(index).Visible = isVisible
        Next
    End Sub

#End Region
    
End Class