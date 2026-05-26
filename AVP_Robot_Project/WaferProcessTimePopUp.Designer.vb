<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WaferProcessTimePopUp
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
        Me.components = New System.ComponentModel.Container
        Me.pnlGraph = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmsSelection = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSelectAll = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuClearAll = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSelectEven = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSelectOdd = New System.Windows.Forms.ToolStripMenuItem
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.FormContainer.SuspendLayout()
        Me.pnlGraph.SuspendLayout()
        Me.cmsSelection.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormContainer
        '
        Me.FormContainer.Controls.Add(Me.pnlGraph)
        Me.FormContainer.Controls.Add(Me.Label5)
        Me.FormContainer.Controls.Add(Me.Label4)
        Me.FormContainer.Controls.Add(Me.Label3)
        Me.FormContainer.Controls.Add(Me.Label2)
        Me.FormContainer.Size = New System.Drawing.Size(670, 345)
        '
        'pnlGraph
        '
        Me.pnlGraph.BackColor = System.Drawing.Color.Transparent
        Me.pnlGraph.Controls.Add(Me.Label9)
        Me.pnlGraph.Controls.Add(Me.Label8)
        Me.pnlGraph.Controls.Add(Me.Label6)
        Me.pnlGraph.Controls.Add(Me.Label1)
        Me.pnlGraph.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGraph.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlGraph.Location = New System.Drawing.Point(8, 5)
        Me.pnlGraph.Name = "pnlGraph"
        Me.pnlGraph.Size = New System.Drawing.Size(654, 330)
        Me.pnlGraph.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(652, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(2, 326)
        Me.Label9.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(2, 328)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(652, 2)
        Me.Label8.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(652, 2)
        Me.Label6.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(2, 330)
        Me.Label1.TabIndex = 0
        '
        'cmsSelection
        '
        Me.cmsSelection.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSelectAll, Me.mnuClearAll, Me.mnuSelectEven, Me.mnuSelectOdd})
        Me.cmsSelection.Name = "cmsSelection"
        Me.cmsSelection.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsSelection.ShowImageMargin = False
        Me.cmsSelection.Size = New System.Drawing.Size(126, 92)
        '
        'mnuSelectAll
        '
        Me.mnuSelectAll.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuSelectAll.Name = "mnuSelectAll"
        Me.mnuSelectAll.Size = New System.Drawing.Size(125, 22)
        Me.mnuSelectAll.Text = "Select All"
        '
        'mnuClearAll
        '
        Me.mnuClearAll.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuClearAll.Name = "mnuClearAll"
        Me.mnuClearAll.Size = New System.Drawing.Size(125, 22)
        Me.mnuClearAll.Text = "Clear All"
        '
        'mnuSelectEven
        '
        Me.mnuSelectEven.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuSelectEven.Name = "mnuSelectEven"
        Me.mnuSelectEven.Size = New System.Drawing.Size(125, 22)
        Me.mnuSelectEven.Text = "Select Even"
        '
        'mnuSelectOdd
        '
        Me.mnuSelectOdd.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuSelectOdd.Name = "mnuSelectOdd"
        Me.mnuSelectOdd.Size = New System.Drawing.Size(125, 22)
        Me.mnuSelectOdd.Text = "Select Odd"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(670, 5)
        Me.Label2.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label3.Location = New System.Drawing.Point(0, 335)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(670, 10)
        Me.Label3.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Location = New System.Drawing.Point(0, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(8, 330)
        Me.Label4.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label5.Location = New System.Drawing.Point(662, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(8, 330)
        Me.Label5.TabIndex = 6
        '
        'WaferProcessTimePopUp
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(680, 390)
        Me.HeaderStatus = AVPControls.AVPDataLib.DisplayStatus.[On]
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WaferProcessTimePopUp"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title"
        Me.Controls.SetChildIndex(Me.FormContainer, 0)
        Me.FormContainer.ResumeLayout(False)
        Me.pnlGraph.ResumeLayout(False)
        Me.cmsSelection.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlGraph As System.Windows.Forms.Panel
    Friend WithEvents cmsSelection As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuClearAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSelectEven As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSelectOdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
