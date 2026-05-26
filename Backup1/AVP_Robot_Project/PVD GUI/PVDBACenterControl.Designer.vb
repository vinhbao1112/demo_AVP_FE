<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PVDBACenterControl
    Inherits AVP_Robot_Project.StatusBoard

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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtIG = New AVP_Robot_Project.SL_Textbox
        Me.txtCG1 = New AVP_Robot_Project.SL_Textbox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCG2 = New AVP_Robot_Project.SL_Textbox
        Me.bigcgIG = New AVP_Robot_Project.ButtonIGCGControl
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBA = New AVP_Robot_Project.SL_Textbox
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 19)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "IG"
        '
        'txtIG
        '
        Me.txtIG.AccessibleName = "IG Pressure"
        Me.txtIG.AutoSendKeyTabWhenFinishInput = False
        Me.txtIG.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIG.Clickable = True
        Me.txtIG.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtIG.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtIG.GasName = ""
        Me.txtIG.IsNumericTextbox = False
        Me.txtIG.IsReadBack = True
        Me.txtIG.IsTurboPumpTextbox = False
        Me.txtIG.Location = New System.Drawing.Point(6, 27)
        Me.txtIG.Name = "txtIG"
        Me.txtIG.ReadOnly = True
        Me.txtIG.ShowUnitFormat = False
        Me.txtIG.Size = New System.Drawing.Size(75, 24)
        Me.txtIG.TabIndex = 21
        Me.txtIG.Text = "OFF"
        Me.txtIG.UnitTypeUsed = ""
        Me.txtIG.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtIG.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtIG.UseScientificFormat = True
        '
        'txtCG1
        '
        Me.txtCG1.AccessibleName = "CG"
        Me.txtCG1.AutoSendKeyTabWhenFinishInput = False
        Me.txtCG1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCG1.Clickable = True
        Me.txtCG1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCG1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCG1.GasName = ""
        Me.txtCG1.IsNumericTextbox = False
        Me.txtCG1.IsReadBack = True
        Me.txtCG1.IsTurboPumpTextbox = False
        Me.txtCG1.Location = New System.Drawing.Point(6, 117)
        Me.txtCG1.Name = "txtCG1"
        Me.txtCG1.ReadOnly = True
        Me.txtCG1.ShowUnitFormat = False
        Me.txtCG1.Size = New System.Drawing.Size(75, 24)
        Me.txtCG1.TabIndex = 25
        Me.txtCG1.UnitTypeUsed = ""
        Me.txtCG1.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtCG1.UseClickEventInForm = True
        Me.txtCG1.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtCG1.UseScientificFormat = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 19)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "CG (Torr)"
        '
        'txtCG2
        '
        Me.txtCG2.AutoSendKeyTabWhenFinishInput = False
        Me.txtCG2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCG2.Clickable = True
        Me.txtCG2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCG2.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtCG2.GasName = ""
        Me.txtCG2.IsNumericTextbox = False
        Me.txtCG2.IsReadBack = True
        Me.txtCG2.IsTurboPumpTextbox = False
        Me.txtCG2.Location = New System.Drawing.Point(6, 143)
        Me.txtCG2.Name = "txtCG2"
        Me.txtCG2.ReadOnly = True
        Me.txtCG2.ShowUnitFormat = False
        Me.txtCG2.Size = New System.Drawing.Size(75, 24)
        Me.txtCG2.TabIndex = 26
        Me.txtCG2.UnitTypeUsed = ""
        Me.txtCG2.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtCG2.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtCG2.UseScientificFormat = True
        Me.txtCG2.Visible = False
        '
        'bigcgIG
        '
        Me.bigcgIG.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.bigcgIG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bigcgIG.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.bigcgIG.ColorText_OffStatus = System.Drawing.Color.Black
        Me.bigcgIG.ColorText_OnStatus = System.Drawing.Color.Black
        Me.bigcgIG.ColorText_UnknowStatus = System.Drawing.Color.Black
        Me.bigcgIG.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bigcgIG.ErrorImage = Nothing
        Me.bigcgIG.ErrorText = ""
        Me.bigcgIG.FlatAppearance.BorderSize = 0
        Me.bigcgIG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bigcgIG.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bigcgIG.ForeColor = System.Drawing.Color.Black
        Me.bigcgIG.Location = New System.Drawing.Point(35, 6)
        Me.bigcgIG.Name = "bigcgIG"
        Me.bigcgIG.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.Rec_BlueButton
        Me.bigcgIG.OffText = ""
        Me.bigcgIG.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.Button_IG_On
        Me.bigcgIG.OnText = ""
        Me.bigcgIG.Size = New System.Drawing.Size(47, 20)
        Me.bigcgIG.Status = AVP_Robot_Project.DisplayStatus.Off
        Me.bigcgIG.StyleOfButton = ButtonStyle.Horizontal
        Me.bigcgIG.TabIndex = 27
        Me.bigcgIG.UnknownImage = Nothing
        Me.bigcgIG.UnKnownText = ""
        Me.bigcgIG.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 19)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "BA (mT)"
        '
        'txtBA
        '
        Me.txtBA.AccessibleName = "BA"
        Me.txtBA.AutoSendKeyTabWhenFinishInput = False
        Me.txtBA.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBA.Clickable = True
        Me.txtBA.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBA.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtBA.GasName = ""
        Me.txtBA.IsNumericTextbox = False
        Me.txtBA.IsReadBack = True
        Me.txtBA.IsTurboPumpTextbox = False
        Me.txtBA.Location = New System.Drawing.Point(6, 72)
        Me.txtBA.Name = "txtBA"
        Me.txtBA.ReadOnly = True
        Me.txtBA.ShowUnitFormat = False
        Me.txtBA.Size = New System.Drawing.Size(75, 24)
        Me.txtBA.TabIndex = 25
        Me.txtBA.UnitTypeUsed = ""
        Me.txtBA.UseBackGroundWorkerToUpdateMinMax = False
        Me.txtBA.UseDigitNumber = AVP_Robot_Project.DigitsNumber.Normal
        Me.txtBA.UseScientificFormat = True
        '
        'PVDBACenterControl
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.bigcgIG)
        Me.Controls.Add(Me.txtCG2)
        Me.Controls.Add(Me.txtBA)
        Me.Controls.Add(Me.txtCG1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtIG)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.DoubleBuffered = True
        Me.HeaderVisible = False
        Me.Name = "PVDBACenterControl"
        Me.Size = New System.Drawing.Size(89, 150)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblHeader, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtIG, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtCG1, 0)
        Me.Controls.SetChildIndex(Me.txtBA, 0)
        Me.Controls.SetChildIndex(Me.txtCG2, 0)
        Me.Controls.SetChildIndex(Me.bigcgIG, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIG As SL_Textbox
    Friend WithEvents txtCG1 As SL_Textbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCG2 As SL_Textbox
    Friend WithEvents bigcgIG As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBA As SL_Textbox

End Class
