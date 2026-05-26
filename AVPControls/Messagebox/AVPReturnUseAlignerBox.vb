Public Class AVPReturnUseAlignerBox

#Region "Fields"

#End Region

#Region "Constructors"

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-06</date>
    ''' <summary>
    ''' Create new message box.
    ''' </summary>
    ''' <param name="strTitle"></param>
    ''' <param name="strMessage"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal strTitle As String, ByVal strMessage As String, Optional ByVal isAlignerVisible As Boolean = True)
        InitializeComponent()

        lblContent.Text = strMessage.Replace("\n", Environment.NewLine)
        Me.Text = strTitle
        Me.ImageIcon = DialogIcon.Question

        If Not isAlignerVisible Then
            cbAdditionalInfo.Enabled = False
            cbxAlignerRecipes.Enabled = False
        End If
    End Sub

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-06</date>
    ''' <summary>
    ''' Gets or sets recipes source.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RecipesSource() As Object
        Get
            Return cbxAlignerRecipes.DataSource
        End Get
        Set(ByVal value As Object)
            cbxAlignerRecipes.DataSource = value
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-06</date>
    ''' <summary>
    ''' Gets or sets selected recipe.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SelectedAlignerRecipe() As String
        Get
            If cbxAlignerRecipes.SelectedItem Is Nothing Then
                Return Nothing
            End If
            Return DirectCast(cbxAlignerRecipes.SelectedItem, String)
        End Get
        Set(ByVal value As String)
            cbxAlignerRecipes.SelectedItem = value
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-06</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether the use aligner check box is visible.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UseAlignerVisible() As Boolean
        Get
            Return cbAdditionalInfo.Visible
        End Get
        Set(ByVal value As Boolean)
            cbAdditionalInfo.Visible = value
            cbxAlignerRecipes.Visible = value
            If value Then
                lblContent.Dock = DockStyle.Top
                lblContent.Height = cbxAlignerRecipes.Top
            Else
                lblContent.Dock = DockStyle.Fill
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-06</date>
    ''' <summary>
    ''' Gets a value indicating the use aligner check box is checked.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UseAlignerChecked() As Boolean
        Get
            Return cbAdditionalInfo.Checked
        End Get
        Set(ByVal value As Boolean)
            cbAdditionalInfo.Checked = value
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-06</date>
    ''' <summary>
    ''' Gets selected aligner recipe.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UseAlignerRecipe() As String
        Get
            If cbxAlignerRecipes.SelectedItem Is Nothing Then
                Return Nothing
            End If
            Return DirectCast(cbxAlignerRecipes.SelectedItem, String)
        End Get
        Set(ByVal value As String)
            cbxAlignerRecipes.SelectedItem = value
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-07</date>
    ''' <summary>
    ''' Set a value indicating whether the mechanical aligner is installed.
    ''' </summary>
    Public WriteOnly Property IsMechanicalAligner() As Boolean
        Set(ByVal value As Boolean)
            If value Then
                cbAdditionalInfo.Text = "Use Mechanical Aligner"
                cbxAlignerRecipes.Visible = False
            Else
                cbAdditionalInfo.Text = "Use Aligner"
                cbxAlignerRecipes.Visible = True
            End If
        End Set
    End Property

#End Region

#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-06</date>
    ''' <summary>
    ''' Handles No button click.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-06</date>
    ''' <summary>
    ''' Handles Yes button click.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

#End Region

End Class