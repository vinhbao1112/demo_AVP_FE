Public Class AVPUseAlignerDialogBox
    Private Shared ReadOnly NullWindow As IWin32Window = Nothing
    Private Shared m_recipeName As String = String.Empty
    Private Shared m_blnIsUsingAligner As Boolean = False
    Private Shared _result As DialogBoxResult = DialogBoxResult.Cancel
    Public Enum DialogBoxResult
        [Cancel] = 0
        [OK] = 1
    End Enum

    ''' <summary>
    ''' Gets or sets the dialog result for the AVP Messagebox form.
    ''' </summary>
    Public Shared Property RecipeName() As String
        Get
            Return m_recipeName
        End Get
        Set(ByVal value As String)
            m_recipeName = value
        End Set
    End Property

    Public Shared ReadOnly Property IsUsingAligner() As Boolean
        Get
            Return m_blnIsUsingAligner
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the dialog result for the AVP Messagebox form.
    ''' </summary>
    Public Shared Property Result() As DialogBoxResult
        Get
            Return _result
        End Get
        Set(ByVal value As DialogBoxResult)
            _result = value
        End Set
    End Property

    Private Shared Sub SetStartPosition(ByVal f As Form, ByVal o As IWin32Window)
        If o Is Nothing Then
            f.StartPosition = FormStartPosition.CenterScreen
        Else
            f.StartPosition = FormStartPosition.CenterParent
        End If
    End Sub

    Private Sub AVPMessageBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
            chkUseAligner.Checked = False
            chkUseAligner.Enabled = False
            cbRecipeList.Enabled = False
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        RecipeName = Me.cbRecipeList.SelectedItem
        m_blnIsUsingAligner = chkUseAligner.Checked
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Me_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        RecipeName = String.Empty
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByVal Source As String, ByVal Dest As String, ByVal Dest_Is_Aligner As Boolean, _
    Optional ByVal Aligner_RecipeDefault As String = "")
        InitializeComponent()

        Dim lstStrRecipe As ArrayList = AVPLib.ContainerData.ListChamber(AVPLib.ConstEnum.Equipments.Aligner.ToString())
        If lstStrRecipe IsNot Nothing AndAlso lstStrRecipe.Count > 0 Then
            For Each item As String In lstStrRecipe
                cbRecipeList.Items.Add(item)
            Next
        End If
        If Not String.IsNullOrEmpty(Aligner_RecipeDefault) Then
            cbRecipeList.SelectedItem = Aligner_RecipeDefault
        ElseIf (lstStrRecipe IsNot Nothing AndAlso lstStrRecipe.Count > 0) Then ' Dat Cao add Default when missing Default value
            'at here missing sort order of strAligner
            lstStrRecipe.Sort()
            cbRecipeList.SelectedItem = lstStrRecipe.Item(0).ToString()
        End If
        If Dest_Is_Aligner And AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
            chkUseAligner.Checked = True
        Else
            chkUseAligner.Checked = False
        End If
        Me.ImageIcon = DialogIcon.Question
        txtSource.Text = Source.Replace("Load Lock A", "LLA")
        txtDestination.Text = Dest.Replace("Load Lock A", "LLA")
    End Sub

    Private Sub chkUseAligner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseAligner.CheckedChanged
        Me.cbRecipeList.Enabled = chkUseAligner.Checked
        If chkUseAligner.Checked AndAlso Me.cbRecipeList.SelectedItem Is Nothing AndAlso AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
            btnOk.Enabled = False
        End If
    End Sub

    Private Sub cbRecipeList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRecipeList.SelectedIndexChanged
        If Me.cbRecipeList.SelectedItem IsNot Nothing Then
            btnOk.Enabled = True
        End If
    End Sub

    Private Sub cbRecipeList_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRecipeList.SelectedValueChanged

    End Sub
End Class
