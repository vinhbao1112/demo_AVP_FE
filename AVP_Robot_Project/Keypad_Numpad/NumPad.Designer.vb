<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NumPad
    Inherits ClosePopUpFrm

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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PnlBorder = New System.Windows.Forms.Panel
        Me.NumPadLabel = New System.Windows.Forms.Label
        Me.gbError = New System.Windows.Forms.GroupBox
        Me.lbErr = New System.Windows.Forms.Label
        Me.txtNumVal = New System.Windows.Forms.Label
        Me.btn_9 = New System.Windows.Forms.Button
        Me.btn_8 = New System.Windows.Forms.Button
        Me.btn_7 = New System.Windows.Forms.Button
        Me.btn_6 = New System.Windows.Forms.Button
        Me.btn_5 = New System.Windows.Forms.Button
        Me.btn_4 = New System.Windows.Forms.Button
        Me.btn_3 = New System.Windows.Forms.Button
        Me.btn_2 = New System.Windows.Forms.Button
        Me.btn_1 = New System.Windows.Forms.Button
        Me.fraMinMax = New System.Windows.Forms.GroupBox
        Me.lblMin = New System.Windows.Forms.Label
        Me.lblMn = New System.Windows.Forms.Label
        Me.lblMax = New System.Windows.Forms.Label
        Me.lblMx = New System.Windows.Forms.Label
        Me.gbBtns = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btn_0 = New System.Windows.Forms.Button
        Me.btn_exp = New System.Windows.Forms.Button
        Me.btn_Neg = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnBkSpc = New System.Windows.Forms.Button
        Me.btn_dot = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.pnlHeader = New System.Windows.Forms.Panel
        Me.PnlBorder.SuspendLayout()
        Me.gbError.SuspendLayout()
        Me.fraMinMax.SuspendLayout()
        Me.gbBtns.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlBorder
        '
        Me.PnlBorder.BackColor = System.Drawing.Color.Transparent
        Me.PnlBorder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PnlBorder.Controls.Add(Me.pnlHeader)
        Me.PnlBorder.Controls.Add(Me.gbError)
        Me.PnlBorder.Controls.Add(Me.btn_9)
        Me.PnlBorder.Controls.Add(Me.btn_8)
        Me.PnlBorder.Controls.Add(Me.btn_7)
        Me.PnlBorder.Controls.Add(Me.btn_6)
        Me.PnlBorder.Controls.Add(Me.btn_5)
        Me.PnlBorder.Controls.Add(Me.btn_4)
        Me.PnlBorder.Controls.Add(Me.btn_3)
        Me.PnlBorder.Controls.Add(Me.btn_2)
        Me.PnlBorder.Controls.Add(Me.btn_1)
        Me.PnlBorder.Controls.Add(Me.fraMinMax)
        Me.PnlBorder.Controls.Add(Me.gbBtns)
        Me.PnlBorder.Location = New System.Drawing.Point(0, 0)
        Me.PnlBorder.Name = "PnlBorder"
        Me.PnlBorder.Size = New System.Drawing.Size(429, 506)
        Me.PnlBorder.TabIndex = 0
        Me.PnlBorder.Tag = "formPopUp"
        '
        'NumPadLabel
        '
        Me.NumPadLabel.BackColor = System.Drawing.Color.Transparent
        Me.NumPadLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumPadLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.NumPadLabel.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumPadLabel.ForeColor = System.Drawing.Color.White
        Me.NumPadLabel.Location = New System.Drawing.Point(0, 0)
        Me.NumPadLabel.Name = "NumPadLabel"
        Me.NumPadLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NumPadLabel.Size = New System.Drawing.Size(429, 64)
        Me.NumPadLabel.TabIndex = 70
        Me.NumPadLabel.Tag = "lstHeadings"
        Me.NumPadLabel.Text = "NumPad"
        Me.NumPadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gbError
        '
        Me.gbError.BackColor = System.Drawing.Color.Transparent
        Me.gbError.Controls.Add(Me.lbErr)
        Me.gbError.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbError.ForeColor = System.Drawing.Color.Black
        Me.gbError.Location = New System.Drawing.Point(11, 435)
        Me.gbError.Name = "gbError"
        Me.gbError.Size = New System.Drawing.Size(406, 51)
        Me.gbError.TabIndex = 69
        Me.gbError.TabStop = False
        Me.gbError.Text = "Input checking"
        '
        'lbErr
        '
        Me.lbErr.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbErr.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbErr.ForeColor = System.Drawing.Color.Red
        Me.lbErr.Location = New System.Drawing.Point(7, 15)
        Me.lbErr.Name = "lbErr"
        Me.lbErr.Size = New System.Drawing.Size(391, 31)
        Me.lbErr.TabIndex = 0
        Me.lbErr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumVal
        '
        Me.txtNumVal.BackColor = System.Drawing.Color.White
        Me.txtNumVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtNumVal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtNumVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumVal.Location = New System.Drawing.Point(12, 64)
        Me.txtNumVal.Name = "txtNumVal"
        Me.txtNumVal.Size = New System.Drawing.Size(406, 35)
        Me.txtNumVal.TabIndex = 1
        Me.txtNumVal.Tag = "labels"
        Me.txtNumVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_9
        '
        Me.btn_9.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_9.Location = New System.Drawing.Point(173, 307)
        Me.btn_9.Name = "btn_9"
        Me.btn_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_9.Size = New System.Drawing.Size(49, 41)
        Me.btn_9.TabIndex = 53
        Me.btn_9.TabStop = False
        Me.btn_9.Tag = ""
        Me.btn_9.Text = "9"
        Me.btn_9.UseVisualStyleBackColor = False
        '
        'btn_8
        '
        Me.btn_8.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_8.Location = New System.Drawing.Point(101, 307)
        Me.btn_8.Name = "btn_8"
        Me.btn_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_8.Size = New System.Drawing.Size(49, 41)
        Me.btn_8.TabIndex = 52
        Me.btn_8.TabStop = False
        Me.btn_8.Tag = ""
        Me.btn_8.Text = "8"
        Me.btn_8.UseVisualStyleBackColor = False
        '
        'btn_7
        '
        Me.btn_7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_7.Location = New System.Drawing.Point(29, 307)
        Me.btn_7.Name = "btn_7"
        Me.btn_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_7.Size = New System.Drawing.Size(49, 41)
        Me.btn_7.TabIndex = 51
        Me.btn_7.TabStop = False
        Me.btn_7.Tag = ""
        Me.btn_7.Text = "7"
        Me.btn_7.UseVisualStyleBackColor = False
        '
        'btn_6
        '
        Me.btn_6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_6.Location = New System.Drawing.Point(173, 248)
        Me.btn_6.Name = "btn_6"
        Me.btn_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_6.Size = New System.Drawing.Size(49, 41)
        Me.btn_6.TabIndex = 50
        Me.btn_6.TabStop = False
        Me.btn_6.Tag = ""
        Me.btn_6.Text = "6"
        Me.btn_6.UseVisualStyleBackColor = False
        '
        'btn_5
        '
        Me.btn_5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_5.Location = New System.Drawing.Point(101, 248)
        Me.btn_5.Name = "btn_5"
        Me.btn_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_5.Size = New System.Drawing.Size(49, 41)
        Me.btn_5.TabIndex = 49
        Me.btn_5.TabStop = False
        Me.btn_5.Tag = ""
        Me.btn_5.Text = "5"
        Me.btn_5.UseVisualStyleBackColor = False
        '
        'btn_4
        '
        Me.btn_4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_4.Location = New System.Drawing.Point(29, 248)
        Me.btn_4.Name = "btn_4"
        Me.btn_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_4.Size = New System.Drawing.Size(49, 41)
        Me.btn_4.TabIndex = 48
        Me.btn_4.TabStop = False
        Me.btn_4.Tag = ""
        Me.btn_4.Text = "4"
        Me.btn_4.UseVisualStyleBackColor = False
        '
        'btn_3
        '
        Me.btn_3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_3.Location = New System.Drawing.Point(173, 189)
        Me.btn_3.Name = "btn_3"
        Me.btn_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_3.Size = New System.Drawing.Size(49, 41)
        Me.btn_3.TabIndex = 47
        Me.btn_3.TabStop = False
        Me.btn_3.Tag = ""
        Me.btn_3.Text = "3"
        Me.btn_3.UseVisualStyleBackColor = False
        '
        'btn_2
        '
        Me.btn_2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_2.Location = New System.Drawing.Point(101, 189)
        Me.btn_2.Name = "btn_2"
        Me.btn_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_2.Size = New System.Drawing.Size(49, 41)
        Me.btn_2.TabIndex = 46
        Me.btn_2.TabStop = False
        Me.btn_2.Tag = ""
        Me.btn_2.Text = "2"
        Me.btn_2.UseVisualStyleBackColor = False
        '
        'btn_1
        '
        Me.btn_1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_1.Location = New System.Drawing.Point(29, 189)
        Me.btn_1.Name = "btn_1"
        Me.btn_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_1.Size = New System.Drawing.Size(49, 41)
        Me.btn_1.TabIndex = 45
        Me.btn_1.TabStop = False
        Me.btn_1.Tag = ""
        Me.btn_1.Text = "1"
        Me.btn_1.UseVisualStyleBackColor = False
        '
        'fraMinMax
        '
        Me.fraMinMax.BackColor = System.Drawing.Color.Transparent
        Me.fraMinMax.Controls.Add(Me.lblMin)
        Me.fraMinMax.Controls.Add(Me.lblMn)
        Me.fraMinMax.Controls.Add(Me.lblMax)
        Me.fraMinMax.Controls.Add(Me.lblMx)
        Me.fraMinMax.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraMinMax.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraMinMax.Location = New System.Drawing.Point(11, 112)
        Me.fraMinMax.Name = "fraMinMax"
        Me.fraMinMax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraMinMax.Size = New System.Drawing.Size(406, 49)
        Me.fraMinMax.TabIndex = 63
        Me.fraMinMax.TabStop = False
        Me.fraMinMax.Tag = "formPopUp"
        Me.fraMinMax.Text = "Valid Value Range"
        '
        'lblMin
        '
        Me.lblMin.BackColor = System.Drawing.Color.Gainsboro
        Me.lblMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMin.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMin.Location = New System.Drawing.Point(63, 16)
        Me.lblMin.Name = "lblMin"
        Me.lblMin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMin.Size = New System.Drawing.Size(105, 25)
        Me.lblMin.TabIndex = 24
        Me.lblMin.Tag = "formPopUp"
        Me.lblMin.Text = "Value"
        '
        'lblMn
        '
        Me.lblMn.BackColor = System.Drawing.Color.Transparent
        Me.lblMn.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMn.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMn.Location = New System.Drawing.Point(15, 20)
        Me.lblMn.Name = "lblMn"
        Me.lblMn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMn.Size = New System.Drawing.Size(41, 17)
        Me.lblMn.TabIndex = 23
        Me.lblMn.Tag = "formPopUp"
        Me.lblMn.Text = "Min :"
        '
        'lblMax
        '
        Me.lblMax.BackColor = System.Drawing.Color.Gainsboro
        Me.lblMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMax.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMax.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMax.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMax.Location = New System.Drawing.Point(279, 16)
        Me.lblMax.Name = "lblMax"
        Me.lblMax.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMax.Size = New System.Drawing.Size(112, 25)
        Me.lblMax.TabIndex = 25
        Me.lblMax.Tag = "formPopUp"
        Me.lblMax.Text = "Value"
        '
        'lblMx
        '
        Me.lblMx.BackColor = System.Drawing.Color.Transparent
        Me.lblMx.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMx.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMx.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMx.Location = New System.Drawing.Point(231, 20)
        Me.lblMx.Name = "lblMx"
        Me.lblMx.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMx.Size = New System.Drawing.Size(41, 17)
        Me.lblMx.TabIndex = 19
        Me.lblMx.Tag = "formPopUp"
        Me.lblMx.Text = "Max :"
        '
        'gbBtns
        '
        Me.gbBtns.BackColor = System.Drawing.Color.Transparent
        Me.gbBtns.Controls.Add(Me.btnCancel)
        Me.gbBtns.Controls.Add(Me.btn_0)
        Me.gbBtns.Controls.Add(Me.btn_exp)
        Me.gbBtns.Controls.Add(Me.btn_Neg)
        Me.gbBtns.Controls.Add(Me.btnClear)
        Me.gbBtns.Controls.Add(Me.btnBkSpc)
        Me.gbBtns.Controls.Add(Me.btn_dot)
        Me.gbBtns.Controls.Add(Me.btnOK)
        Me.gbBtns.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbBtns.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbBtns.Location = New System.Drawing.Point(11, 160)
        Me.gbBtns.Name = "gbBtns"
        Me.gbBtns.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.gbBtns.Size = New System.Drawing.Size(406, 269)
        Me.gbBtns.TabIndex = 67
        Me.gbBtns.TabStop = False
        Me.gbBtns.Tag = "formPopUp"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(299, 149)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCancel.Size = New System.Drawing.Size(89, 41)
        Me.btnCancel.TabIndex = 59
        Me.btnCancel.TabStop = False
        Me.btnCancel.Tag = ""
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btn_0
        '
        Me.btn_0.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_0.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_0.Location = New System.Drawing.Point(90, 206)
        Me.btn_0.Name = "btn_0"
        Me.btn_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_0.Size = New System.Drawing.Size(49, 41)
        Me.btn_0.TabIndex = 55
        Me.btn_0.TabStop = False
        Me.btn_0.Tag = ""
        Me.btn_0.Text = "0"
        Me.btn_0.UseVisualStyleBackColor = False
        '
        'btn_exp
        '
        Me.btn_exp.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_exp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_exp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_exp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_exp.Location = New System.Drawing.Point(228, 147)
        Me.btn_exp.Name = "btn_exp"
        Me.btn_exp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_exp.Size = New System.Drawing.Size(49, 41)
        Me.btn_exp.TabIndex = 66
        Me.btn_exp.TabStop = False
        Me.btn_exp.Tag = ""
        Me.btn_exp.Text = "Exp"
        Me.btn_exp.UseVisualStyleBackColor = False
        '
        'btn_Neg
        '
        Me.btn_Neg.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_Neg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Neg.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Neg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_Neg.Location = New System.Drawing.Point(227, 88)
        Me.btn_Neg.Name = "btn_Neg"
        Me.btn_Neg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_Neg.Size = New System.Drawing.Size(49, 41)
        Me.btn_Neg.TabIndex = 66
        Me.btn_Neg.TabStop = False
        Me.btn_Neg.Tag = ""
        Me.btn_Neg.Text = "-"
        Me.btn_Neg.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(299, 90)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(89, 41)
        Me.btnClear.TabIndex = 57
        Me.btnClear.TabStop = False
        Me.btnClear.Tag = ""
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnBkSpc
        '
        Me.btnBkSpc.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnBkSpc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBkSpc.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBkSpc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBkSpc.Location = New System.Drawing.Point(299, 31)
        Me.btnBkSpc.Name = "btnBkSpc"
        Me.btnBkSpc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBkSpc.Size = New System.Drawing.Size(89, 41)
        Me.btnBkSpc.TabIndex = 61
        Me.btnBkSpc.TabStop = False
        Me.btnBkSpc.Tag = ""
        Me.btnBkSpc.Text = "<<"
        Me.btnBkSpc.UseVisualStyleBackColor = False
        '
        'btn_dot
        '
        Me.btn_dot.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btn_dot.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_dot.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_dot.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_dot.Location = New System.Drawing.Point(227, 29)
        Me.btn_dot.Name = "btn_dot"
        Me.btn_dot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_dot.Size = New System.Drawing.Size(49, 41)
        Me.btn_dot.TabIndex = 54
        Me.btn_dot.TabStop = False
        Me.btn_dot.Tag = ""
        Me.btn_dot.Text = "."
        Me.btn_dot.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(299, 208)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOK.Size = New System.Drawing.Size(89, 41)
        Me.btnOK.TabIndex = 58
        Me.btnOK.TabStop = False
        Me.btnOK.Tag = ""
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackgroundImage = Global.AVP_Robot_Project.My.Resources.Resources.BgMsgBoxHeader
        Me.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlHeader.Controls.Add(Me.NumPadLabel)
        Me.pnlHeader.Controls.Add(Me.txtNumVal)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(429, 108)
        Me.pnlHeader.TabIndex = 71
        '
        'NumPad
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(430, 507)
        Me.Controls.Add(Me.PnlBorder)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "NumPad"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = ""
        Me.Text = "NumPad"
        Me.UseBorderStyle = True
        Me.PnlBorder.ResumeLayout(False)
        Me.gbError.ResumeLayout(False)
        Me.fraMinMax.ResumeLayout(False)
        Me.gbBtns.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents btn_0 As Button
    Public WithEvents btn_1 As Button
    Public WithEvents btn_2 As Button
    Public WithEvents btn_3 As Button
    Public WithEvents btn_4 As Button
    Public WithEvents btn_5 As Button
    Public WithEvents btn_6 As Button
    Public WithEvents btn_7 As Button
    Public WithEvents btn_8 As Button
    Public WithEvents btn_9 As Button
    Public WithEvents btn_dot As Button
    Friend WithEvents btn_Neg As Button
    Public WithEvents btnBkSpc As Button
    Public WithEvents btnCancel As Button
    Public WithEvents btnClear As Button
    Public WithEvents btnOK As Button
    Public WithEvents fraMinMax As GroupBox
    Public WithEvents gbBtns As GroupBox
    Public WithEvents lblMax As Label
    Public WithEvents lblMin As Label
    Public WithEvents lblMn As Label
    Public WithEvents lblMx As Label
    Friend WithEvents PnlBorder As Panel
    Public WithEvents ToolTip1 As ToolTip
    Friend WithEvents txtNumVal As Label

    ' Private properties
    Private MinMaxChk As Boolean
    Private baseX As Integer
    Private baseY As Integer
    Private ClearPreviousVals As Boolean
    Private Copy As Boolean
    Private dbl As Double
    Private dCurrValue As Double
    Private dMaxLimit As Double
    Private dMinLimit As Double
    Private doDrag As Boolean
    Private UserResponse As DialogResult
    Friend WithEvents btn_exp As System.Windows.Forms.Button
    Friend WithEvents gbError As System.Windows.Forms.GroupBox
    Friend WithEvents lbErr As System.Windows.Forms.Label
    Public WithEvents NumPadLabel As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel

End Class
