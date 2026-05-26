<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListAllUsers
    Inherits AVPControls.AVPPopupForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnOK = New AVPControls.AVPButton
        Me.btnClose = New AVPControls.AVPButton
        Me.lstViewAllUsers1 = New System.Windows.Forms.DataGridView
        Me.pnlCenter = New System.Windows.Forms.Panel
        Me.FormContainer.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.lstViewAllUsers1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCenter.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.pnlCenter)
        Me.FormContainer.Controls.Add(Me.Panel1)
        Me.FormContainer.Location = New System.Drawing.Point(5, 50)
        Me.FormContainer.Size = New System.Drawing.Size(790, 775)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btnOK)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 705)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(790, 70)
        Me.Panel1.TabIndex = 8
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Image = Global.AVP_Robot_Project.My.Resources.Resources.apply
        Me.btnOK.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnOK.Location = New System.Drawing.Point(478, 10)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnOK.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnOK.Size = New System.Drawing.Size(120, 44)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = Global.AVP_Robot_Project.My.Resources.Resources.cancel
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnClose.Location = New System.Drawing.Point(634, 10)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.NormalBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnClose.PressedBackground = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhiteDown
        Me.btnClose.Size = New System.Drawing.Size(120, 44)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "  Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lstViewAllUsers1
        '
        Me.lstViewAllUsers1.AllowUserToAddRows = False
        Me.lstViewAllUsers1.AllowUserToDeleteRows = False
        Me.lstViewAllUsers1.AllowUserToResizeColumns = False
        Me.lstViewAllUsers1.AllowUserToResizeRows = False
        Me.lstViewAllUsers1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.lstViewAllUsers1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstViewAllUsers1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.lstViewAllUsers1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lstViewAllUsers1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstViewAllUsers1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.lstViewAllUsers1.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.lstViewAllUsers1.Location = New System.Drawing.Point(0, 0)
        Me.lstViewAllUsers1.MultiSelect = False
        Me.lstViewAllUsers1.Name = "lstViewAllUsers1"
        Me.lstViewAllUsers1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstViewAllUsers1.RowHeadersVisible = False
        Me.lstViewAllUsers1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.lstViewAllUsers1.RowTemplate.Height = 35
        Me.lstViewAllUsers1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.lstViewAllUsers1.Size = New System.Drawing.Size(790, 705)
        Me.lstViewAllUsers1.TabIndex = 1
        '
        'pnlCenter
        '
        Me.pnlCenter.Controls.Add(Me.lstViewAllUsers1)
        Me.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCenter.Location = New System.Drawing.Point(0, 0)
        Me.pnlCenter.Name = "pnlCenter"
        Me.pnlCenter.Size = New System.Drawing.Size(790, 705)
        Me.pnlCenter.TabIndex = 12
        '
        'ListAllUsers
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 830)
        Me.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderHeight = 50
        Me.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListAllUsers"
        Me.ShowButton = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "List All Users"
        Me.FormContainer.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.lstViewAllUsers1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCenter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnOK As AVPControls.AVPButton
    Friend WithEvents btnClose As AVPControls.AVPButton
    Friend WithEvents lstViewAllUsers1 As System.Windows.Forms.DataGridView
    Friend WithEvents pnlCenter As System.Windows.Forms.Panel
End Class
