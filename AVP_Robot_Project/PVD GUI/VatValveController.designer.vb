<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VatValveController
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPressure = New System.Windows.Forms.TextBox
        Me.txtTeach = New System.Windows.Forms.TextBox
        Me.btnTeach = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnAutoZero = New AVP_Robot_Project.ButtonIGCGControl
        Me.btnSizeAdjust = New AVP_Robot_Project.ButtonIGCGControl
        Me.txtPressure_Percent = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Header
        '
        Me.Header.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderRed
        Me.Header.FlatAppearance.BorderSize = 0
        Me.Header.ForeColor = System.Drawing.Color.Black
        Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderBlue
        Me.Header.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderGreen
        Me.Header.Size = New System.Drawing.Size(280, 27)
        Me.Header.Status = AVP_Robot_Project.DisplayStatus.[On]
        Me.Header.Text = "Vat Valve Controller"
        Me.Header.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BgHeaderYellow
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 19)
        Me.Label2.TabIndex = 8
        Me.Label2.Tag = "Pressure "
        Me.Label2.Text = "Pressure (mT)"
        '
        'txtPressure
        '
        Me.txtPressure.BackColor = System.Drawing.SystemColors.Window
        Me.txtPressure.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPressure.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPressure.Location = New System.Drawing.Point(119, 38)
        Me.txtPressure.Name = "txtPressure"
        Me.txtPressure.ReadOnly = True
        Me.txtPressure.Size = New System.Drawing.Size(145, 24)
        Me.txtPressure.TabIndex = 13
        '
        'txtTeach
        '
        Me.txtTeach.BackColor = System.Drawing.SystemColors.Window
        Me.txtTeach.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtTeach.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTeach.Location = New System.Drawing.Point(190, 38)
        Me.txtTeach.Name = "txtTeach"
        Me.txtTeach.ReadOnly = True
        Me.txtTeach.Size = New System.Drawing.Size(10, 26)
        Me.txtTeach.TabIndex = 13
        Me.txtTeach.Visible = False
        '
        'btnTeach
        '
        Me.btnTeach.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTeach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTeach.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnTeach.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnTeach.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTeach.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTeach.FlatAppearance.BorderSize = 0
        Me.btnTeach.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTeach.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTeach.ForeColor = System.Drawing.Color.Black
        Me.btnTeach.Location = New System.Drawing.Point(8, 102)
        Me.btnTeach.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnTeach.Name = "btnTeach"
        Me.btnTeach.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnTeach.OffText = "Teach"
        Me.btnTeach.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnTeach.OnText = "Teach"
        Me.btnTeach.Size = New System.Drawing.Size(58, 27)
        Me.btnTeach.TabIndex = 20
        Me.btnTeach.Text = "Teach"
        Me.btnTeach.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnTeach.UseVisualStyleBackColor = True
        '
        'btnAutoZero
        '
        Me.btnAutoZero.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAutoZero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAutoZero.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnAutoZero.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnAutoZero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAutoZero.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnAutoZero.FlatAppearance.BorderSize = 0
        Me.btnAutoZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutoZero.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutoZero.ForeColor = System.Drawing.Color.Black
        Me.btnAutoZero.Location = New System.Drawing.Point(70, 102)
        Me.btnAutoZero.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnAutoZero.Name = "btnAutoZero"
        Me.btnAutoZero.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnAutoZero.OffText = "Auto Zero"
        Me.btnAutoZero.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnAutoZero.OnText = "Auto Zero"
        Me.btnAutoZero.Size = New System.Drawing.Size(95, 27)
        Me.btnAutoZero.TabIndex = 20
        Me.btnAutoZero.Text = "Auto Zero"
        Me.btnAutoZero.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnAutoZero.UseVisualStyleBackColor = True
        '
        'btnSizeAdjust
        '
        Me.btnSizeAdjust.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnSizeAdjust.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSizeAdjust.ColorText_ErrorStatus = System.Drawing.Color.Black
        Me.btnSizeAdjust.ColorText_OffStatus = System.Drawing.Color.Black
        Me.btnSizeAdjust.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSizeAdjust.ErrorImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnSizeAdjust.FlatAppearance.BorderSize = 0
        Me.btnSizeAdjust.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSizeAdjust.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSizeAdjust.ForeColor = System.Drawing.Color.Black
        Me.btnSizeAdjust.Location = New System.Drawing.Point(169, 102)
        Me.btnSizeAdjust.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnSizeAdjust.Name = "btnSizeAdjust"
        Me.btnSizeAdjust.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonWhite
        Me.btnSizeAdjust.OffText = "Size Adjust"
        Me.btnSizeAdjust.OnImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonGreen
        Me.btnSizeAdjust.OnText = "Size Adjust"
        Me.btnSizeAdjust.Size = New System.Drawing.Size(97, 27)
        Me.btnSizeAdjust.TabIndex = 20
        Me.btnSizeAdjust.Text = "Size Adjust"
        Me.btnSizeAdjust.UnknownImage = Global.AVP_Robot_Project.My.Resources.Resources.BtnButtonRed
        Me.btnSizeAdjust.UseVisualStyleBackColor = True
        '
        'txtPressure_Percent
        '
        Me.txtPressure_Percent.BackColor = System.Drawing.SystemColors.Window
        Me.txtPressure_Percent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtPressure_Percent.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.txtPressure_Percent.Location = New System.Drawing.Point(119, 70)
        Me.txtPressure_Percent.Name = "txtPressure_Percent"
        Me.txtPressure_Percent.ReadOnly = True
        Me.txtPressure_Percent.Size = New System.Drawing.Size(145, 24)
        Me.txtPressure_Percent.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 19)
        Me.Label1.TabIndex = 8
        Me.Label1.Tag = "Pressure "
        Me.Label1.Text = "Position (%)"
        '
        'VatValveController
        '
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnSizeAdjust)
        Me.Controls.Add(Me.btnAutoZero)
        Me.Controls.Add(Me.btnTeach)
        Me.Controls.Add(Me.txtPressure_Percent)
        Me.Controls.Add(Me.txtPressure)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTeach)
        Me.DoubleBuffered = True
        Me.HeaderStatus = AVP_Robot_Project.DisplayStatus.[On]
        Me.HeaderTextColor = System.Drawing.Color.Black
        Me.Name = "VatValveController"
        Me.Size = New System.Drawing.Size(280, 137)
        Me.Text = "Vat Valve Controller"
        Me.UseBorderStyle = True
        Me.Controls.SetChildIndex(Me.Header, 0)
        Me.Controls.SetChildIndex(Me.txtTeach, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtPressure, 0)
        Me.Controls.SetChildIndex(Me.txtPressure_Percent, 0)
        Me.Controls.SetChildIndex(Me.btnTeach, 0)
        Me.Controls.SetChildIndex(Me.btnAutoZero, 0)
        Me.Controls.SetChildIndex(Me.btnSizeAdjust, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPressure As System.Windows.Forms.TextBox
    Friend WithEvents txtTeach As System.Windows.Forms.TextBox
    Friend WithEvents btnTeach As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnAutoZero As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents btnSizeAdjust As AVP_Robot_Project.ButtonIGCGControl
    Friend WithEvents txtPressure_Percent As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
