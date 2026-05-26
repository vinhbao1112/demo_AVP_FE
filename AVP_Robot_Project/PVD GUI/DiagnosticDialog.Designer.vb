<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DiagnosticDialog
    Inherits AVP_Robot_Project.PVDStatusPanel

    'UserControl overrides dispose to clean up the component list.
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
        Me.TabPage13 = New System.Windows.Forms.TabPage
        Me.TabPage14 = New System.Windows.Forms.TabPage
        Me.TabPage15 = New System.Windows.Forms.TabPage
        Me.TabPage16 = New System.Windows.Forms.TabPage
        Me.tabDiag = New System.Windows.Forms.CustomTabControl
        Me.tabPageLLA = New System.Windows.Forms.TabPage
        Me.tabPageTM = New System.Windows.Forms.TabPage
        Me.tabPagePM1 = New System.Windows.Forms.TabPage
        Me.tabPagePM2 = New System.Windows.Forms.TabPage
        Me.tabPagePM3 = New System.Windows.Forms.TabPage
        Me.tabDiag_LLA = New System.Windows.Forms.CustomTabControl
        Me.tabDiag_LLA_PDC = New System.Windows.Forms.TabPage
        Me.dgsPumpDownLLA = New AVP_Robot_Project.DiagnosticScreen
        Me.tabDiag_LLA_ROR = New System.Windows.Forms.TabPage
        Me.dgsRateOfRiseLLA = New AVP_Robot_Project.DiagnosticScreen
        Me.tabDiag_TM = New System.Windows.Forms.CustomTabControl
        Me.TabPage7 = New System.Windows.Forms.TabPage
        Me.dgsPumpDownTM = New AVP_Robot_Project.DiagnosticScreen
        Me.TabPage8 = New System.Windows.Forms.TabPage
        Me.dgsRateOfRiseTM = New AVP_Robot_Project.DiagnosticScreen
        Me.tabDiag_PM1 = New System.Windows.Forms.CustomTabControl
        Me.TabPage9 = New System.Windows.Forms.TabPage
        Me.dgsPumpDownPM1 = New AVP_Robot_Project.DiagnosticScreen
        Me.TabPage10 = New System.Windows.Forms.TabPage
        Me.dgsRateOfRisePM1 = New AVP_Robot_Project.DiagnosticScreen
        Me.tabDiag_PM2 = New System.Windows.Forms.CustomTabControl
        Me.TabPage11 = New System.Windows.Forms.TabPage
        Me.dgsPumpDownPM2 = New AVP_Robot_Project.DiagnosticScreen
        Me.TabPage12 = New System.Windows.Forms.TabPage
        Me.dgsRateOfRisePM2 = New AVP_Robot_Project.DiagnosticScreen
        Me.tabDiag_PM3 = New System.Windows.Forms.CustomTabControl
        Me.TabPage17 = New System.Windows.Forms.TabPage
        Me.dgsPumpDownPM3 = New AVP_Robot_Project.DiagnosticScreen
        Me.TabPage18 = New System.Windows.Forms.TabPage
        Me.dgsRateOfRisePM3 = New AVP_Robot_Project.DiagnosticScreen
        Me.TabPage22 = New System.Windows.Forms.TabPage
        Me.TabPage23 = New System.Windows.Forms.TabPage
        Me.TabPage24 = New System.Windows.Forms.TabPage
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.tabDiag.SuspendLayout()
        Me.tabDiag_LLA.SuspendLayout()
        Me.tabDiag_LLA_PDC.SuspendLayout()
        Me.tabDiag_LLA_ROR.SuspendLayout()
        Me.tabDiag_TM.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.tabDiag_PM1.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        Me.TabPage10.SuspendLayout()
        Me.tabDiag_PM2.SuspendLayout()
        Me.TabPage11.SuspendLayout()
        Me.TabPage12.SuspendLayout()
        Me.tabDiag_PM3.SuspendLayout()
        Me.TabPage17.SuspendLayout()
        Me.TabPage18.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage13
        '
        Me.TabPage13.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage13.Location = New System.Drawing.Point(4, 36)
        Me.TabPage13.Name = "TabPage13"
        Me.TabPage13.Size = New System.Drawing.Size(490, 107)
        Me.TabPage13.TabIndex = 0
        Me.TabPage13.Text = "Pump Down Curves"
        Me.TabPage13.UseVisualStyleBackColor = True
        '
        'TabPage14
        '
        Me.TabPage14.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage14.Location = New System.Drawing.Point(4, 36)
        Me.TabPage14.Name = "TabPage14"
        Me.TabPage14.Size = New System.Drawing.Size(490, 214)
        Me.TabPage14.TabIndex = 1
        Me.TabPage14.Text = "Rate Of Rise"
        Me.TabPage14.UseVisualStyleBackColor = True
        '
        'TabPage15
        '
        Me.TabPage15.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage15.Location = New System.Drawing.Point(4, 36)
        Me.TabPage15.Name = "TabPage15"
        Me.TabPage15.Size = New System.Drawing.Size(490, 107)
        Me.TabPage15.TabIndex = 0
        Me.TabPage15.Text = "Pump Down Curves"
        Me.TabPage15.UseVisualStyleBackColor = True
        '
        'TabPage16
        '
        Me.TabPage16.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage16.Location = New System.Drawing.Point(4, 36)
        Me.TabPage16.Name = "TabPage16"
        Me.TabPage16.Size = New System.Drawing.Size(490, 107)
        Me.TabPage16.TabIndex = 1
        Me.TabPage16.Text = "Rate Of Rise"
        Me.TabPage16.UseVisualStyleBackColor = True
        '
        'tabDiag
        '
        Me.tabDiag.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.tabDiag.Controls.Add(Me.tabPageLLA)
        Me.tabDiag.Controls.Add(Me.tabPageTM)
        Me.tabDiag.Controls.Add(Me.tabPagePM1)
        Me.tabDiag.Controls.Add(Me.tabPagePM2)
        Me.tabDiag.Controls.Add(Me.tabPagePM3)
        Me.tabDiag.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tabDiag.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabDiag.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabDiag.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.tabDiag.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabDiag.DisplayStyleProvider.FocusTrack = False
        Me.tabDiag.DisplayStyleProvider.HotTrack = True
        Me.tabDiag.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabDiag.DisplayStyleProvider.Opacity = 1.0!
        Me.tabDiag.DisplayStyleProvider.Overlap = 0
        Me.tabDiag.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabDiag.DisplayStyleProvider.Radius = 10
        Me.tabDiag.DisplayStyleProvider.ShowTabCloser = False
        Me.tabDiag.DisplayStyleProvider.TabItemIndent = 50
        Me.tabDiag.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDiag.HotTrack = True
        Me.tabDiag.Location = New System.Drawing.Point(551, 153)
        Me.tabDiag.Multiline = True
        Me.tabDiag.Name = "tabDiag"
        Me.tabDiag.SelectedIndex = 0
        Me.tabDiag.Size = New System.Drawing.Size(482, 629)
        Me.tabDiag.TabIndex = 162
        '
        'tabPageLLA
        '
        Me.tabPageLLA.BackColor = System.Drawing.SystemColors.ControlText
        Me.tabPageLLA.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabPageLLA.Location = New System.Drawing.Point(38, 0)
        Me.tabPageLLA.Name = "tabPageLLA"
        Me.tabPageLLA.Size = New System.Drawing.Size(444, 629)
        Me.tabPageLLA.TabIndex = 0
        Me.tabPageLLA.Text = "LLA"
        Me.tabPageLLA.UseVisualStyleBackColor = True
        '
        'tabPageTM
        '
        Me.tabPageTM.BackColor = System.Drawing.SystemColors.ControlText
        Me.tabPageTM.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabPageTM.Location = New System.Drawing.Point(38, 0)
        Me.tabPageTM.Name = "tabPageTM"
        Me.tabPageTM.Size = New System.Drawing.Size(444, 629)
        Me.tabPageTM.TabIndex = 2
        Me.tabPageTM.Text = "TM"
        Me.tabPageTM.UseVisualStyleBackColor = True
        '
        'tabPagePM1
        '
        Me.tabPagePM1.BackColor = System.Drawing.SystemColors.ControlText
        Me.tabPagePM1.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabPagePM1.Location = New System.Drawing.Point(38, 0)
        Me.tabPagePM1.Name = "tabPagePM1"
        Me.tabPagePM1.Size = New System.Drawing.Size(444, 629)
        Me.tabPagePM1.TabIndex = 3
        Me.tabPagePM1.Text = "PM1"
        Me.tabPagePM1.UseVisualStyleBackColor = True
        '
        'tabPagePM2
        '
        Me.tabPagePM2.BackColor = System.Drawing.SystemColors.ControlText
        Me.tabPagePM2.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabPagePM2.Location = New System.Drawing.Point(38, 0)
        Me.tabPagePM2.Name = "tabPagePM2"
        Me.tabPagePM2.Size = New System.Drawing.Size(444, 629)
        Me.tabPagePM2.TabIndex = 4
        Me.tabPagePM2.Text = "PM2"
        Me.tabPagePM2.UseVisualStyleBackColor = True
        '
        'tabPagePM3
        '
        Me.tabPagePM3.BackColor = System.Drawing.SystemColors.ControlText
        Me.tabPagePM3.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabPagePM3.Location = New System.Drawing.Point(38, 0)
        Me.tabPagePM3.Name = "tabPagePM3"
        Me.tabPagePM3.Size = New System.Drawing.Size(444, 629)
        Me.tabPagePM3.TabIndex = 5
        Me.tabPagePM3.Text = "PM3"
        Me.tabPagePM3.UseVisualStyleBackColor = True
        '
        'tabDiag_LLA
        '
        Me.tabDiag_LLA.Controls.Add(Me.tabDiag_LLA_PDC)
        Me.tabDiag_LLA.Controls.Add(Me.tabDiag_LLA_ROR)
        Me.tabDiag_LLA.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabDiag_LLA.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabDiag_LLA.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.tabDiag_LLA.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabDiag_LLA.DisplayStyleProvider.FocusTrack = False
        Me.tabDiag_LLA.DisplayStyleProvider.HotTrack = True
        Me.tabDiag_LLA.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabDiag_LLA.DisplayStyleProvider.Opacity = 1.0!
        Me.tabDiag_LLA.DisplayStyleProvider.Overlap = 0
        Me.tabDiag_LLA.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabDiag_LLA.DisplayStyleProvider.Radius = 10
        Me.tabDiag_LLA.DisplayStyleProvider.ShowTabCloser = False
        Me.tabDiag_LLA.HotTrack = True
        Me.tabDiag_LLA.Location = New System.Drawing.Point(0, 3)
        Me.tabDiag_LLA.Name = "tabDiag_LLA"
        Me.tabDiag_LLA.SelectedIndex = 0
        Me.tabDiag_LLA.Size = New System.Drawing.Size(364, 152)
        Me.tabDiag_LLA.TabIndex = 0
        '
        'tabDiag_LLA_PDC
        '
        Me.tabDiag_LLA_PDC.Controls.Add(Me.dgsPumpDownLLA)
        Me.tabDiag_LLA_PDC.Location = New System.Drawing.Point(0, 23)
        Me.tabDiag_LLA_PDC.Name = "tabDiag_LLA_PDC"
        Me.tabDiag_LLA_PDC.Size = New System.Drawing.Size(364, 129)
        Me.tabDiag_LLA_PDC.TabIndex = 0
        Me.tabDiag_LLA_PDC.Text = "Pump Down Curves"
        Me.tabDiag_LLA_PDC.UseVisualStyleBackColor = True
        '
        'dgsPumpDownLLA
        '
        Me.dgsPumpDownLLA.BackColor = System.Drawing.Color.DarkGray
        Me.dgsPumpDownLLA.ChamberName = AVPLib.ConstEnum.Equipments.LoadLockA
        Me.dgsPumpDownLLA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgsPumpDownLLA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgsPumpDownLLA.Litter_Value = 0
        Me.dgsPumpDownLLA.Location = New System.Drawing.Point(0, 0)
        Me.dgsPumpDownLLA.Name = "dgsPumpDownLLA"
        Me.dgsPumpDownLLA.Size = New System.Drawing.Size(364, 129)
        Me.dgsPumpDownLLA.TabIndex = 0
        Me.dgsPumpDownLLA.TitleOfGraph = "Pump Down Curve run at"
        Me.dgsPumpDownLLA.TypeOf_DiagnosticScreen = AVP_Robot_Project.DiagnosticScreen.DiagnosticType.PumpDown_Curve
        Me.dgsPumpDownLLA.X_Axis_Title = "Time (Secs)"
        Me.dgsPumpDownLLA.Y_Axis_Title = "Pressure"
        '
        'tabDiag_LLA_ROR
        '
        Me.tabDiag_LLA_ROR.Controls.Add(Me.dgsRateOfRiseLLA)
        Me.tabDiag_LLA_ROR.Location = New System.Drawing.Point(0, 23)
        Me.tabDiag_LLA_ROR.Name = "tabDiag_LLA_ROR"
        Me.tabDiag_LLA_ROR.Size = New System.Drawing.Size(364, 129)
        Me.tabDiag_LLA_ROR.TabIndex = 1
        Me.tabDiag_LLA_ROR.Text = "Rate Of Rise"
        Me.tabDiag_LLA_ROR.UseVisualStyleBackColor = True
        '
        'dgsRateOfRiseLLA
        '
        Me.dgsRateOfRiseLLA.BackColor = System.Drawing.Color.DarkGray
        Me.dgsRateOfRiseLLA.ChamberName = AVPLib.ConstEnum.Equipments.LoadLockA
        Me.dgsRateOfRiseLLA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgsRateOfRiseLLA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgsRateOfRiseLLA.Litter_Value = 0
        Me.dgsRateOfRiseLLA.Location = New System.Drawing.Point(0, 0)
        Me.dgsRateOfRiseLLA.Name = "dgsRateOfRiseLLA"
        Me.dgsRateOfRiseLLA.Size = New System.Drawing.Size(364, 129)
        Me.dgsRateOfRiseLLA.TabIndex = 0
        Me.dgsRateOfRiseLLA.TitleOfGraph = "Rate Of Rise run at"
        Me.dgsRateOfRiseLLA.TypeOf_DiagnosticScreen = AVP_Robot_Project.DiagnosticScreen.DiagnosticType.Rate_Of_Rise
        Me.dgsRateOfRiseLLA.X_Axis_Title = "Time (Secs)"
        Me.dgsRateOfRiseLLA.Y_Axis_Title = "Pressure"
        '
        'tabDiag_TM
        '
        Me.tabDiag_TM.Controls.Add(Me.TabPage7)
        Me.tabDiag_TM.Controls.Add(Me.TabPage8)
        Me.tabDiag_TM.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabDiag_TM.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabDiag_TM.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.tabDiag_TM.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabDiag_TM.DisplayStyleProvider.FocusTrack = False
        Me.tabDiag_TM.DisplayStyleProvider.HotTrack = True
        Me.tabDiag_TM.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabDiag_TM.DisplayStyleProvider.Opacity = 1.0!
        Me.tabDiag_TM.DisplayStyleProvider.Overlap = 0
        Me.tabDiag_TM.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabDiag_TM.DisplayStyleProvider.Radius = 10
        Me.tabDiag_TM.DisplayStyleProvider.ShowTabCloser = False
        Me.tabDiag_TM.HotTrack = True
        Me.tabDiag_TM.Location = New System.Drawing.Point(662, 24)
        Me.tabDiag_TM.Name = "tabDiag_TM"
        Me.tabDiag_TM.SelectedIndex = 0
        Me.tabDiag_TM.Size = New System.Drawing.Size(257, 120)
        Me.tabDiag_TM.TabIndex = 1
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.dgsPumpDownTM)
        Me.TabPage7.Location = New System.Drawing.Point(0, 23)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(257, 97)
        Me.TabPage7.TabIndex = 0
        Me.TabPage7.Text = "Pump Down Curves"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'dgsPumpDownTM
        '
        Me.dgsPumpDownTM.BackColor = System.Drawing.Color.DarkGray
        Me.dgsPumpDownTM.ChamberName = AVPLib.ConstEnum.Equipments.CassettesModule
        Me.dgsPumpDownTM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgsPumpDownTM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgsPumpDownTM.Litter_Value = 0
        Me.dgsPumpDownTM.Location = New System.Drawing.Point(0, 0)
        Me.dgsPumpDownTM.Name = "dgsPumpDownTM"
        Me.dgsPumpDownTM.Size = New System.Drawing.Size(257, 97)
        Me.dgsPumpDownTM.TabIndex = 0
        Me.dgsPumpDownTM.TitleOfGraph = Nothing
        Me.dgsPumpDownTM.TypeOf_DiagnosticScreen = AVP_Robot_Project.DiagnosticScreen.DiagnosticType.PumpDown_Curve
        Me.dgsPumpDownTM.X_Axis_Title = Nothing
        Me.dgsPumpDownTM.Y_Axis_Title = Nothing
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.dgsRateOfRiseTM)
        Me.TabPage8.Location = New System.Drawing.Point(0, 23)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(257, 97)
        Me.TabPage8.TabIndex = 1
        Me.TabPage8.Text = "Rate Of Rise"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'dgsRateOfRiseTM
        '
        Me.dgsRateOfRiseTM.BackColor = System.Drawing.Color.DarkGray
        Me.dgsRateOfRiseTM.ChamberName = AVPLib.ConstEnum.Equipments.CassettesModule
        Me.dgsRateOfRiseTM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgsRateOfRiseTM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgsRateOfRiseTM.Litter_Value = 0
        Me.dgsRateOfRiseTM.Location = New System.Drawing.Point(0, 0)
        Me.dgsRateOfRiseTM.Name = "dgsRateOfRiseTM"
        Me.dgsRateOfRiseTM.Size = New System.Drawing.Size(257, 97)
        Me.dgsRateOfRiseTM.TabIndex = 0
        Me.dgsRateOfRiseTM.TitleOfGraph = Nothing
        Me.dgsRateOfRiseTM.TypeOf_DiagnosticScreen = AVP_Robot_Project.DiagnosticScreen.DiagnosticType.Rate_Of_Rise
        Me.dgsRateOfRiseTM.X_Axis_Title = Nothing
        Me.dgsRateOfRiseTM.Y_Axis_Title = Nothing
        '
        'tabDiag_PM1
        '
        Me.tabDiag_PM1.Controls.Add(Me.TabPage9)
        Me.tabDiag_PM1.Controls.Add(Me.TabPage10)
        Me.tabDiag_PM1.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabDiag_PM1.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabDiag_PM1.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.tabDiag_PM1.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabDiag_PM1.DisplayStyleProvider.FocusTrack = False
        Me.tabDiag_PM1.DisplayStyleProvider.HotTrack = True
        Me.tabDiag_PM1.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabDiag_PM1.DisplayStyleProvider.Opacity = 1.0!
        Me.tabDiag_PM1.DisplayStyleProvider.Overlap = 0
        Me.tabDiag_PM1.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabDiag_PM1.DisplayStyleProvider.Radius = 10
        Me.tabDiag_PM1.DisplayStyleProvider.ShowTabCloser = False
        Me.tabDiag_PM1.HotTrack = True
        Me.tabDiag_PM1.Location = New System.Drawing.Point(10, 161)
        Me.tabDiag_PM1.Name = "tabDiag_PM1"
        Me.tabDiag_PM1.SelectedIndex = 0
        Me.tabDiag_PM1.Size = New System.Drawing.Size(190, 119)
        Me.tabDiag_PM1.TabIndex = 1
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.dgsPumpDownPM1)
        Me.TabPage9.Location = New System.Drawing.Point(0, 23)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Size = New System.Drawing.Size(190, 96)
        Me.TabPage9.TabIndex = 0
        Me.TabPage9.Text = "Pump Down Curves"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'dgsPumpDownPM1
        '
        Me.dgsPumpDownPM1.BackColor = System.Drawing.Color.DarkGray
        Me.dgsPumpDownPM1.ChamberName = AVPLib.ConstEnum.Equipments.Chamber1
        Me.dgsPumpDownPM1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgsPumpDownPM1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgsPumpDownPM1.Litter_Value = 0
        Me.dgsPumpDownPM1.Location = New System.Drawing.Point(0, 0)
        Me.dgsPumpDownPM1.Name = "dgsPumpDownPM1"
        Me.dgsPumpDownPM1.Size = New System.Drawing.Size(190, 96)
        Me.dgsPumpDownPM1.TabIndex = 0
        Me.dgsPumpDownPM1.TitleOfGraph = Nothing
        Me.dgsPumpDownPM1.TypeOf_DiagnosticScreen = AVP_Robot_Project.DiagnosticScreen.DiagnosticType.PumpDown_Curve
        Me.dgsPumpDownPM1.X_Axis_Title = Nothing
        Me.dgsPumpDownPM1.Y_Axis_Title = Nothing
        '
        'TabPage10
        '
        Me.TabPage10.Controls.Add(Me.dgsRateOfRisePM1)
        Me.TabPage10.Location = New System.Drawing.Point(0, 23)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Size = New System.Drawing.Size(190, 96)
        Me.TabPage10.TabIndex = 1
        Me.TabPage10.Text = "Rate Of Rise"
        Me.TabPage10.UseVisualStyleBackColor = True
        '
        'dgsRateOfRisePM1
        '
        Me.dgsRateOfRisePM1.BackColor = System.Drawing.Color.DarkGray
        Me.dgsRateOfRisePM1.ChamberName = AVPLib.ConstEnum.Equipments.Chamber1
        Me.dgsRateOfRisePM1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgsRateOfRisePM1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgsRateOfRisePM1.Litter_Value = 0
        Me.dgsRateOfRisePM1.Location = New System.Drawing.Point(0, 0)
        Me.dgsRateOfRisePM1.Name = "dgsRateOfRisePM1"
        Me.dgsRateOfRisePM1.Size = New System.Drawing.Size(190, 96)
        Me.dgsRateOfRisePM1.TabIndex = 0
        Me.dgsRateOfRisePM1.TitleOfGraph = Nothing
        Me.dgsRateOfRisePM1.TypeOf_DiagnosticScreen = AVP_Robot_Project.DiagnosticScreen.DiagnosticType.Rate_Of_Rise
        Me.dgsRateOfRisePM1.X_Axis_Title = Nothing
        Me.dgsRateOfRisePM1.Y_Axis_Title = Nothing
        '
        'tabDiag_PM2
        '
        Me.tabDiag_PM2.Controls.Add(Me.TabPage11)
        Me.tabDiag_PM2.Controls.Add(Me.TabPage12)
        Me.tabDiag_PM2.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabDiag_PM2.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabDiag_PM2.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.tabDiag_PM2.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabDiag_PM2.DisplayStyleProvider.FocusTrack = False
        Me.tabDiag_PM2.DisplayStyleProvider.HotTrack = True
        Me.tabDiag_PM2.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabDiag_PM2.DisplayStyleProvider.Opacity = 1.0!
        Me.tabDiag_PM2.DisplayStyleProvider.Overlap = 0
        Me.tabDiag_PM2.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabDiag_PM2.DisplayStyleProvider.Radius = 10
        Me.tabDiag_PM2.DisplayStyleProvider.ShowTabCloser = False
        Me.tabDiag_PM2.HotTrack = True
        Me.tabDiag_PM2.Location = New System.Drawing.Point(30, 622)
        Me.tabDiag_PM2.Name = "tabDiag_PM2"
        Me.tabDiag_PM2.SelectedIndex = 0
        Me.tabDiag_PM2.Size = New System.Drawing.Size(445, 163)
        Me.tabDiag_PM2.TabIndex = 1
        '
        'TabPage11
        '
        Me.TabPage11.Controls.Add(Me.dgsPumpDownPM2)
        Me.TabPage11.Location = New System.Drawing.Point(0, 23)
        Me.TabPage11.Name = "TabPage11"
        Me.TabPage11.Size = New System.Drawing.Size(445, 140)
        Me.TabPage11.TabIndex = 0
        Me.TabPage11.Text = "Pump Down Curves"
        Me.TabPage11.UseVisualStyleBackColor = True
        '
        'dgsPumpDownPM2
        '
        Me.dgsPumpDownPM2.BackColor = System.Drawing.Color.DarkGray
        Me.dgsPumpDownPM2.ChamberName = AVPLib.ConstEnum.Equipments.Chamber2
        Me.dgsPumpDownPM2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgsPumpDownPM2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgsPumpDownPM2.Litter_Value = 0
        Me.dgsPumpDownPM2.Location = New System.Drawing.Point(0, 0)
        Me.dgsPumpDownPM2.Name = "dgsPumpDownPM2"
        Me.dgsPumpDownPM2.Size = New System.Drawing.Size(445, 140)
        Me.dgsPumpDownPM2.TabIndex = 0
        Me.dgsPumpDownPM2.TitleOfGraph = Nothing
        Me.dgsPumpDownPM2.TypeOf_DiagnosticScreen = AVP_Robot_Project.DiagnosticScreen.DiagnosticType.PumpDown_Curve
        Me.dgsPumpDownPM2.X_Axis_Title = "Time (Secs)"
        Me.dgsPumpDownPM2.Y_Axis_Title = Nothing
        '
        'TabPage12
        '
        Me.TabPage12.Controls.Add(Me.dgsRateOfRisePM2)
        Me.TabPage12.Location = New System.Drawing.Point(0, 23)
        Me.TabPage12.Name = "TabPage12"
        Me.TabPage12.Size = New System.Drawing.Size(445, 140)
        Me.TabPage12.TabIndex = 1
        Me.TabPage12.Text = "Rate Of Rise"
        Me.TabPage12.UseVisualStyleBackColor = True
        '
        'dgsRateOfRisePM2
        '
        Me.dgsRateOfRisePM2.BackColor = System.Drawing.Color.DarkGray
        Me.dgsRateOfRisePM2.ChamberName = AVPLib.ConstEnum.Equipments.Chamber1
        Me.dgsRateOfRisePM2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgsRateOfRisePM2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgsRateOfRisePM2.Litter_Value = 0
        Me.dgsRateOfRisePM2.Location = New System.Drawing.Point(0, 0)
        Me.dgsRateOfRisePM2.Name = "dgsRateOfRisePM2"
        Me.dgsRateOfRisePM2.Size = New System.Drawing.Size(445, 140)
        Me.dgsRateOfRisePM2.TabIndex = 0
        Me.dgsRateOfRisePM2.TitleOfGraph = Nothing
        Me.dgsRateOfRisePM2.TypeOf_DiagnosticScreen = AVP_Robot_Project.DiagnosticScreen.DiagnosticType.Rate_Of_Rise
        Me.dgsRateOfRisePM2.X_Axis_Title = Nothing
        Me.dgsRateOfRisePM2.Y_Axis_Title = Nothing
        '
        'tabDiag_PM3
        '
        Me.tabDiag_PM3.Controls.Add(Me.TabPage17)
        Me.tabDiag_PM3.Controls.Add(Me.TabPage18)
        Me.tabDiag_PM3.DisplayStyle = System.Windows.Forms.TabStyle.Rounded
        '
        '
        '
        Me.tabDiag_PM3.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.tabDiag_PM3.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.tabDiag_PM3.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray
        Me.tabDiag_PM3.DisplayStyleProvider.FocusTrack = False
        Me.tabDiag_PM3.DisplayStyleProvider.HotTrack = True
        Me.tabDiag_PM3.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tabDiag_PM3.DisplayStyleProvider.Opacity = 1.0!
        Me.tabDiag_PM3.DisplayStyleProvider.Overlap = 0
        Me.tabDiag_PM3.DisplayStyleProvider.Padding = New System.Drawing.Point(6, 3)
        Me.tabDiag_PM3.DisplayStyleProvider.Radius = 10
        Me.tabDiag_PM3.DisplayStyleProvider.ShowTabCloser = False
        Me.tabDiag_PM3.HotTrack = True
        Me.tabDiag_PM3.Location = New System.Drawing.Point(3, 485)
        Me.tabDiag_PM3.Name = "tabDiag_PM3"
        Me.tabDiag_PM3.SelectedIndex = 0
        Me.tabDiag_PM3.Size = New System.Drawing.Size(476, 131)
        Me.tabDiag_PM3.TabIndex = 1
        '
        'TabPage17
        '
        Me.TabPage17.Controls.Add(Me.dgsPumpDownPM3)
        Me.TabPage17.Location = New System.Drawing.Point(0, 23)
        Me.TabPage17.Name = "TabPage17"
        Me.TabPage17.Size = New System.Drawing.Size(476, 108)
        Me.TabPage17.TabIndex = 0
        Me.TabPage17.Text = "Pump Down Curves"
        Me.TabPage17.UseVisualStyleBackColor = True
        '
        'dgsPumpDownPM3
        '
        Me.dgsPumpDownPM3.BackColor = System.Drawing.Color.DarkGray
        Me.dgsPumpDownPM3.ChamberName = AVPLib.ConstEnum.Equipments.Chamber3
        Me.dgsPumpDownPM3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgsPumpDownPM3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgsPumpDownPM3.Litter_Value = 0
        Me.dgsPumpDownPM3.Location = New System.Drawing.Point(0, 0)
        Me.dgsPumpDownPM3.Name = "dgsPumpDownPM3"
        Me.dgsPumpDownPM3.Size = New System.Drawing.Size(476, 108)
        Me.dgsPumpDownPM3.TabIndex = 0
        Me.dgsPumpDownPM3.TitleOfGraph = Nothing
        Me.dgsPumpDownPM3.TypeOf_DiagnosticScreen = AVP_Robot_Project.DiagnosticScreen.DiagnosticType.PumpDown_Curve
        Me.dgsPumpDownPM3.X_Axis_Title = Nothing
        Me.dgsPumpDownPM3.Y_Axis_Title = Nothing
        '
        'TabPage18
        '
        Me.TabPage18.Controls.Add(Me.dgsRateOfRisePM3)
        Me.TabPage18.Location = New System.Drawing.Point(0, 23)
        Me.TabPage18.Name = "TabPage18"
        Me.TabPage18.Size = New System.Drawing.Size(476, 108)
        Me.TabPage18.TabIndex = 1
        Me.TabPage18.Text = "Rate Of Rise"
        Me.TabPage18.UseVisualStyleBackColor = True
        '
        'dgsRateOfRisePM3
        '
        Me.dgsRateOfRisePM3.BackColor = System.Drawing.Color.DarkGray
        Me.dgsRateOfRisePM3.ChamberName = AVPLib.ConstEnum.Equipments.Chamber3
        Me.dgsRateOfRisePM3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgsRateOfRisePM3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgsRateOfRisePM3.Litter_Value = 0
        Me.dgsRateOfRisePM3.Location = New System.Drawing.Point(0, 0)
        Me.dgsRateOfRisePM3.Name = "dgsRateOfRisePM3"
        Me.dgsRateOfRisePM3.Size = New System.Drawing.Size(476, 108)
        Me.dgsRateOfRisePM3.TabIndex = 0
        Me.dgsRateOfRisePM3.TitleOfGraph = Nothing
        Me.dgsRateOfRisePM3.TypeOf_DiagnosticScreen = AVP_Robot_Project.DiagnosticScreen.DiagnosticType.Rate_Of_Rise
        Me.dgsRateOfRisePM3.X_Axis_Title = Nothing
        Me.dgsRateOfRisePM3.Y_Axis_Title = Nothing
        '
        'TabPage22
        '
        Me.TabPage22.Location = New System.Drawing.Point(0, 0)
        Me.TabPage22.Name = "TabPage22"
        Me.TabPage22.Size = New System.Drawing.Size(200, 100)
        Me.TabPage22.TabIndex = 0
        '
        'TabPage23
        '
        Me.TabPage23.Location = New System.Drawing.Point(0, 0)
        Me.TabPage23.Name = "TabPage23"
        Me.TabPage23.Size = New System.Drawing.Size(200, 100)
        Me.TabPage23.TabIndex = 0
        '
        'TabPage24
        '
        Me.TabPage24.Location = New System.Drawing.Point(0, 0)
        Me.TabPage24.Name = "TabPage24"
        Me.TabPage24.Size = New System.Drawing.Size(200, 100)
        Me.TabPage24.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(0, 0)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(200, 100)
        Me.TabPage1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(0, 0)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(200, 100)
        Me.TabPage2.TabIndex = 0
        '
        'DiagnosticDialog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.tabDiag_PM2)
        Me.Controls.Add(Me.tabDiag_PM3)
        Me.Controls.Add(Me.tabDiag_PM1)
        Me.Controls.Add(Me.tabDiag_TM)
        Me.Controls.Add(Me.tabDiag_LLA)
        Me.Controls.Add(Me.tabDiag)
        Me.Name = "DiagnosticDialog"
        Me.Size = New System.Drawing.Size(1085, 794)
        Me.tabDiag.ResumeLayout(False)
        Me.tabDiag_LLA.ResumeLayout(False)
        Me.tabDiag_LLA_PDC.ResumeLayout(False)
        Me.tabDiag_LLA_ROR.ResumeLayout(False)
        Me.tabDiag_TM.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage8.ResumeLayout(False)
        Me.tabDiag_PM1.ResumeLayout(False)
        Me.TabPage9.ResumeLayout(False)
        Me.TabPage10.ResumeLayout(False)
        Me.tabDiag_PM2.ResumeLayout(False)
        Me.TabPage11.ResumeLayout(False)
        Me.TabPage12.ResumeLayout(False)
        Me.tabDiag_PM3.ResumeLayout(False)
        Me.TabPage17.ResumeLayout(False)
        Me.TabPage18.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPage13 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage14 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage15 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage16 As System.Windows.Forms.TabPage
    Friend WithEvents tabDiag As System.Windows.Forms.CustomTabControl
    Friend WithEvents tabPageLLA As System.Windows.Forms.TabPage
    Friend WithEvents tabDiag_LLA As System.Windows.Forms.CustomTabControl
    Friend WithEvents tabDiag_LLA_PDC As System.Windows.Forms.TabPage
    Friend WithEvents tabDiag_LLA_ROR As System.Windows.Forms.TabPage
    Friend WithEvents tabPageTM As System.Windows.Forms.TabPage
    Friend WithEvents tabPagePM1 As System.Windows.Forms.TabPage
    Friend WithEvents tabPagePM2 As System.Windows.Forms.TabPage
    Friend WithEvents tabPagePM3 As System.Windows.Forms.TabPage
    Friend WithEvents dgsPumpDownLLA As AVP_Robot_Project.DiagnosticScreen
    Friend WithEvents dgsRateOfRiseLLA As AVP_Robot_Project.DiagnosticScreen
    Friend WithEvents tabDiag_TM As System.Windows.Forms.CustomTabControl
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents dgsPumpDownTM As AVP_Robot_Project.DiagnosticScreen
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents dgsRateOfRiseTM As AVP_Robot_Project.DiagnosticScreen
    Friend WithEvents tabDiag_PM1 As System.Windows.Forms.CustomTabControl
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents dgsPumpDownPM1 As AVP_Robot_Project.DiagnosticScreen
    Friend WithEvents TabPage10 As System.Windows.Forms.TabPage
    Friend WithEvents dgsRateOfRisePM1 As AVP_Robot_Project.DiagnosticScreen
    Friend WithEvents tabDiag_PM2 As System.Windows.Forms.CustomTabControl
    Friend WithEvents TabPage11 As System.Windows.Forms.TabPage
    Friend WithEvents dgsPumpDownPM2 As AVP_Robot_Project.DiagnosticScreen
    Friend WithEvents TabPage12 As System.Windows.Forms.TabPage
    Friend WithEvents dgsRateOfRisePM2 As AVP_Robot_Project.DiagnosticScreen
    Friend WithEvents tabDiag_PM3 As System.Windows.Forms.CustomTabControl
    Friend WithEvents TabPage17 As System.Windows.Forms.TabPage
    Friend WithEvents dgsPumpDownPM3 As AVP_Robot_Project.DiagnosticScreen
    Friend WithEvents TabPage18 As System.Windows.Forms.TabPage
    Friend WithEvents dgsRateOfRisePM3 As AVP_Robot_Project.DiagnosticScreen
    Friend WithEvents TabPage22 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage23 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage24 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage

End Class
