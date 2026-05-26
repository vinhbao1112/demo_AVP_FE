<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVDCGControl
    Inherits AVP_Robot_Project.PVDStatusBoard

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
        Me.txtInfor = New AVP_Robot_Project.SL_Textbox
        Me.SuspendLayout()
        '
        'txtInfor
        '
        Me.txtInfor.AccessibleName = "CG"
        Me.txtInfor.AutoSendKeyTabWhenFinishInput = False
        Me.txtInfor.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtInfor.Clickable = True
        Me.txtInfor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtInfor.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtInfor.GasName = ""
        Me.txtInfor.IsNumericTextbox = False
        Me.txtInfor.IsReadBack = True
        Me.txtInfor.IsTurboPumpTextbox = False
        Me.txtInfor.Location = New System.Drawing.Point(4, 27)
        Me.txtInfor.Name = "txtInfor"
        Me.txtInfor.ReadOnly = True
        Me.txtInfor.ShowUnitFormat = False
        Me.txtInfor.Size = New System.Drawing.Size(74, 24)
        Me.txtInfor.TabIndex = 7
        Me.txtInfor.UnitTypeUsed = ""
        Me.txtInfor.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtInfor.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtInfor.UseScientificFormat = True
        '
        'PVDCGControl
        '
        Me.Controls.Add(Me.txtInfor)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HeaderHeight = 25
        Me.Name = "PVDCGControl"
        Me.Size = New System.Drawing.Size(82, 54)
        Me.Text = "CG"
        Me.Controls.SetChildIndex(Me.txtInfor, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtInfor As SL_Textbox

End Class
