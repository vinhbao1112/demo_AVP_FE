Imports AVPLib
Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum

Public Class DiagnosticDialog
#Region "Create manually Tab for Recover Pressure"
    Friend WithEvents tabPageRecoverPressurePM1 As System.Windows.Forms.TabPage
    Friend WithEvents tabPageRecoverPressurePM2 As System.Windows.Forms.TabPage
    Friend WithEvents tabPageRecoverPressurePM3 As System.Windows.Forms.TabPage
    Friend WithEvents tabPageRecoverPressureLLA As System.Windows.Forms.TabPage
    Friend WithEvents tabPageRecoverPressureTM As System.Windows.Forms.TabPage

    Friend WithEvents dgsRecoverPressureLLA As AVP_Robot_Project.DiagnosticScreen
    Friend WithEvents dgsRecoverPressureTM As AVP_Robot_Project.DiagnosticScreen
    Friend WithEvents dgsRecoverPressurePM1 As AVP_Robot_Project.DiagnosticScreen
    Friend WithEvents dgsRecoverPressurePM2 As AVP_Robot_Project.DiagnosticScreen
    Friend WithEvents dgsRecoverPressurePM3 As AVP_Robot_Project.DiagnosticScreen
    Private m_SelectedIndexTab As Integer = 0

    Protected Overrides Sub CreateStatusTree()
        Try
            m_stoStatusObject.Name = Me.Name

            m_stoStatusObject.AddChild(dgsPumpDownLLA.Status)
            m_stoStatusObject.AddChild(dgsRateOfRiseLLA.Status)
            m_stoStatusObject.AddChild(dgsRecoverPressureLLA.Status)

            If AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE Then
                m_stoStatusObject.AddChild(dgsPumpDownPM1.Status)
                m_stoStatusObject.AddChild(dgsRateOfRisePM1.Status)
                m_stoStatusObject.AddChild(dgsRecoverPressurePM1.Status)
            End If
            If AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE Then
                m_stoStatusObject.AddChild(dgsPumpDownPM2.Status)
                m_stoStatusObject.AddChild(dgsRateOfRisePM2.Status)
                m_stoStatusObject.AddChild(dgsRecoverPressurePM2.Status)
            End If
            If AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE Then
                m_stoStatusObject.AddChild(dgsPumpDownPM3.Status)
                m_stoStatusObject.AddChild(dgsRateOfRisePM3.Status)
                m_stoStatusObject.AddChild(dgsRecoverPressurePM3.Status)
            End If

            m_stoStatusObject.AddChild(dgsPumpDownTM.Status)
            m_stoStatusObject.AddChild(dgsRateOfRiseTM.Status)
            m_stoStatusObject.AddChild(dgsRecoverPressureTM.Status)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private Sub CreateRecoverPressureTab()
        ''TM
        Me.tabPageRecoverPressureTM = New System.Windows.Forms.TabPage
        tabDiag_TM.Controls.Add(tabPageRecoverPressureTM)

        Me.dgsRecoverPressureTM = New AVP_Robot_Project.DiagnosticScreen
        Me.dgsRecoverPressureTM.BackColor = System.Drawing.Color.DarkGray
        Me.dgsRecoverPressureTM.ChamberName = AVPLib.ConstEnum.Equipments.CassettesModule
        Me.dgsRecoverPressureTM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgsRecoverPressureTM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgsRecoverPressureTM.Litter_Value = 0
        Me.dgsRecoverPressureTM.Location = New System.Drawing.Point(3, 3)
        Me.dgsRecoverPressureTM.Name = "dgsRecoverPressureTM"
        Me.dgsRecoverPressureTM.Size = New System.Drawing.Size(243, 94)
        Me.dgsRecoverPressureTM.TabIndex = 0
        Me.dgsRecoverPressureTM.TitleOfGraph = "Recover Pressure run at"
        Me.dgsRecoverPressureTM.TypeOf_DiagnosticScreen = AVP_Robot_Project.DiagnosticScreen.DiagnosticType.Recover_Pressure
        Me.dgsRecoverPressureTM.X_Axis_Title = "Time (Secs)"
        Me.dgsRecoverPressureTM.Y_Axis_Title = "IG/CG_Pressure"
        Me.dgsRecoverPressureTM.txtDescription.Text = "IG/CG Pressure"

        tabPageRecoverPressureTM.Controls.Add(Me.dgsRecoverPressureTM)
        tabPageRecoverPressureTM.Location = New System.Drawing.Point(4, 23)
        tabPageRecoverPressureTM.Name = "dgsRecoverPressureTM"
        'tabPageRecoverPressureTM.Padding = New System.Windows.Forms.Padding(3)
        tabPageRecoverPressureTM.Size = New System.Drawing.Size(249, 100)
        tabPageRecoverPressureTM.TabIndex = 0
        tabPageRecoverPressureTM.Text = "Recover Pressure"
        tabPageRecoverPressureTM.UseVisualStyleBackColor = True

        ''LOADLOCK A
        Me.tabPageRecoverPressureLLA = New System.Windows.Forms.TabPage
        tabDiag_LLA.Controls.Add(tabPageRecoverPressureLLA)

        Me.dgsRecoverPressureLLA = New AVP_Robot_Project.DiagnosticScreen
        Me.dgsRecoverPressureLLA.BackColor = System.Drawing.Color.DarkGray
        Me.dgsRecoverPressureLLA.ChamberName = AVPLib.ConstEnum.Equipments.LoadLockA
        Me.dgsRecoverPressureLLA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgsRecoverPressureLLA.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgsRecoverPressureLLA.Litter_Value = 0
        Me.dgsRecoverPressureLLA.Location = New System.Drawing.Point(3, 3)
        Me.dgsRecoverPressureLLA.Name = "dgsRecoverPressureLLA"
        Me.dgsRecoverPressureLLA.Size = New System.Drawing.Size(243, 94)
        Me.dgsRecoverPressureLLA.TabIndex = 0
        Me.dgsRecoverPressureLLA.TitleOfGraph = "Recover Pressure run at"
        Me.dgsRecoverPressureLLA.TypeOf_DiagnosticScreen = AVP_Robot_Project.DiagnosticScreen.DiagnosticType.Recover_Pressure
        Me.dgsRecoverPressureLLA.X_Axis_Title = "Time (Secs)"
        Me.dgsRecoverPressureLLA.Y_Axis_Title = "IG/CG_Pressure"
        Me.dgsRecoverPressureLLA.txtDescription.Text = "IG/CG Pressure"

        tabPageRecoverPressureLLA.Controls.Add(Me.dgsRecoverPressureLLA)
        tabPageRecoverPressureLLA.Location = New System.Drawing.Point(4, 23)
        tabPageRecoverPressureLLA.Name = "tabDiagRecoverPressureLLA"
        ' tabPageRecoverPressureLLA.Padding = New System.Windows.Forms.Padding(3)
        tabPageRecoverPressureLLA.Size = New System.Drawing.Size(249, 100)
        tabPageRecoverPressureLLA.TabIndex = 0
        tabPageRecoverPressureLLA.Text = "Recover Pressure"
        tabPageRecoverPressureLLA.UseVisualStyleBackColor = True

        If RobotConfigurationValues.CHAMBER1_VISIBLE Then
            Me.tabPageRecoverPressurePM1 = New System.Windows.Forms.TabPage
            tabDiag_PM1.Controls.Add(tabPageRecoverPressurePM1)

            Me.dgsRecoverPressurePM1 = New AVP_Robot_Project.DiagnosticScreen
            Me.dgsRecoverPressurePM1.BackColor = System.Drawing.Color.DarkGray
            Me.dgsRecoverPressurePM1.ChamberName = AVPLib.ConstEnum.Equipments.Chamber1
            Me.dgsRecoverPressurePM1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgsRecoverPressurePM1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dgsRecoverPressurePM1.Litter_Value = 0
            Me.dgsRecoverPressurePM1.Location = New System.Drawing.Point(3, 3)
            Me.dgsRecoverPressurePM1.Name = "dgsRecoverPressurePM1"
            Me.dgsRecoverPressurePM1.Size = New System.Drawing.Size(243, 94)
            Me.dgsRecoverPressurePM1.TabIndex = 0
            Me.dgsRecoverPressurePM1.TitleOfGraph = "Recover Pressure run at"
            Me.dgsRecoverPressurePM1.TypeOf_DiagnosticScreen = AVP_Robot_Project.DiagnosticScreen.DiagnosticType.Recover_Pressure
            Me.dgsRecoverPressurePM1.X_Axis_Title = "Time (Secs)"
            Me.dgsRecoverPressurePM1.Y_Axis_Title = "IG/CG_Pressure"
            Me.dgsRecoverPressurePM1.txtDescription.Text = "IG/CG Pressure"

            tabPageRecoverPressurePM1.Controls.Add(Me.dgsRecoverPressurePM1)
            tabPageRecoverPressurePM1.Location = New System.Drawing.Point(4, 23)
            tabPageRecoverPressurePM1.Name = "tabPageRecoverPressurePM1"
            'tabPageRecoverPressurePM1.Padding = New System.Windows.Forms.Padding(3)
            tabPageRecoverPressurePM1.Size = New System.Drawing.Size(249, 100)
            tabPageRecoverPressurePM1.TabIndex = 0
            tabPageRecoverPressurePM1.Text = "Recover Pressure"
            tabPageRecoverPressurePM1.UseVisualStyleBackColor = True
        End If

        If RobotConfigurationValues.CHAMBER2_VISIBLE Then
            Me.tabPageRecoverPressurePM2 = New System.Windows.Forms.TabPage
            tabDiag_PM2.Controls.Add(tabPageRecoverPressurePM2)

            Me.dgsRecoverPressurePM2 = New AVP_Robot_Project.DiagnosticScreen
            Me.dgsRecoverPressurePM2.BackColor = System.Drawing.Color.DarkGray
            Me.dgsRecoverPressurePM2.ChamberName = AVPLib.ConstEnum.Equipments.Chamber2
            Me.dgsRecoverPressurePM2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgsRecoverPressurePM2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dgsRecoverPressurePM2.Litter_Value = 0
            Me.dgsRecoverPressurePM2.Location = New System.Drawing.Point(3, 3)
            Me.dgsRecoverPressurePM2.Name = "dgsRecoverPressurePM2"
            Me.dgsRecoverPressurePM2.Size = New System.Drawing.Size(243, 94)
            Me.dgsRecoverPressurePM2.TabIndex = 0
            Me.dgsRecoverPressurePM2.TitleOfGraph = "Recover Pressure run at"
            Me.dgsRecoverPressurePM2.TypeOf_DiagnosticScreen = AVP_Robot_Project.DiagnosticScreen.DiagnosticType.Recover_Pressure
            Me.dgsRecoverPressurePM2.X_Axis_Title = "Time (Secs)"
            Me.dgsRecoverPressurePM2.Y_Axis_Title = "IG/CG_Pressure"
            Me.dgsRecoverPressurePM2.txtDescription.Text = "IG/CG Pressure"

            tabPageRecoverPressurePM2.Controls.Add(Me.dgsRecoverPressurePM2)
            tabPageRecoverPressurePM2.Location = New System.Drawing.Point(4, 23)
            tabPageRecoverPressurePM2.Name = "tabPageRecoverPressurePM2"
            'tabPageRecoverPressurePM2.Padding = New System.Windows.Forms.Padding(3)
            tabPageRecoverPressurePM2.Size = New System.Drawing.Size(249, 100)
            tabPageRecoverPressurePM2.TabIndex = 0
            tabPageRecoverPressurePM2.Text = "Recover Pressure"
            tabPageRecoverPressurePM2.UseVisualStyleBackColor = True
        End If

        If RobotConfigurationValues.CHAMBER3_VISIBLE Then
            Me.tabPageRecoverPressurePM3 = New System.Windows.Forms.TabPage
            tabDiag_PM3.Controls.Add(tabPageRecoverPressurePM3)

            Me.dgsRecoverPressurePM3 = New AVP_Robot_Project.DiagnosticScreen
            Me.dgsRecoverPressurePM3.BackColor = System.Drawing.Color.DarkGray
            Me.dgsRecoverPressurePM3.ChamberName = AVPLib.ConstEnum.Equipments.Chamber3
            Me.dgsRecoverPressurePM3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgsRecoverPressurePM3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dgsRecoverPressurePM3.Litter_Value = 0
            Me.dgsRecoverPressurePM3.Location = New System.Drawing.Point(3, 3)
            Me.dgsRecoverPressurePM3.Name = "dgsRecoverPressurePM3"
            Me.dgsRecoverPressurePM3.Size = New System.Drawing.Size(243, 94)
            Me.dgsRecoverPressurePM3.TabIndex = 0
            Me.dgsRecoverPressurePM3.TitleOfGraph = "Recover Pressure run at"
            Me.dgsRecoverPressurePM3.TypeOf_DiagnosticScreen = AVP_Robot_Project.DiagnosticScreen.DiagnosticType.Recover_Pressure
            Me.dgsRecoverPressurePM3.X_Axis_Title = "Time (Secs)"
            Me.dgsRecoverPressurePM3.Y_Axis_Title = "IG/CG_Pressure"
            Me.dgsRecoverPressurePM3.txtDescription.Text = "IG/CG Pressure"

            tabPageRecoverPressurePM3.Controls.Add(Me.dgsRecoverPressurePM3)
            tabPageRecoverPressurePM3.Location = New System.Drawing.Point(4, 23)
            tabPageRecoverPressurePM3.Name = "tabPageRecoverPressurePM3"
            ' tabPageRecoverPressurePM3.Padding = New System.Windows.Forms.Padding(3)
            tabPageRecoverPressurePM3.Size = New System.Drawing.Size(249, 100)
            tabPageRecoverPressurePM3.TabIndex = 0
            tabPageRecoverPressurePM3.Text = "Recover Pressure"
            tabPageRecoverPressurePM3.UseVisualStyleBackColor = True
        End If
        Me.ResumeLayout()
    End Sub
#End Region
    
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Check permission of Diagnostic
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckPermission()
        Try
            If AVPLib.ContainerData.Permission(PERMISSION_001) Then
                Active_InActiveForm(True)
            Else
                Active_InActiveForm(False)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Check permission of Diagnostic
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Active_InActiveForm(ByVal blnStatus As Boolean)
        dgsPumpDownTM.Active = blnStatus
        dgsRateOfRiseTM.Active = blnStatus
        dgsRecoverPressureTM.Active = blnStatus

        dgsPumpDownLLA.Active = blnStatus
        dgsRateOfRiseLLA.Active = blnStatus
        dgsRecoverPressureLLA.Active = blnStatus

        If RobotConfigurationValues.CHAMBER1_VISIBLE Then
            dgsPumpDownPM1.Active = blnStatus
            dgsRateOfRisePM1.Active = blnStatus
            dgsRecoverPressurePM1.Active = blnStatus
        End If

        If RobotConfigurationValues.CHAMBER2_VISIBLE Then
            dgsPumpDownPM2.Active = blnStatus
            dgsRateOfRisePM2.Active = blnStatus
            dgsRecoverPressurePM2.Active = blnStatus
        End If

        If RobotConfigurationValues.CHAMBER3_VISIBLE Then
            dgsPumpDownPM3.Active = blnStatus
            dgsRateOfRisePM3.Active = blnStatus
            dgsRecoverPressurePM3.Active = blnStatus
        End If
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Set Tab Visible - Invisible
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DiagnosticDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Check Permission
        CheckPermission()
    End Sub

    Public Sub New()
        Const Y_AXIS_TITLE As String = "Pressure"

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        CreateRecoverPressureTab()
        ' Add any initialization after the InitializeComponent() call.
        Dim objConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(Equipments.Robot.ToString())
        tabDiag.Dock = DockStyle.Fill
        tabPageTM.Controls.Add(tabDiag_TM)
        tabDiag_TM.Dock = DockStyle.Fill
        dgsPumpDownTM.TitleOfGraph = "Pump Down Curve run at"
        dgsPumpDownTM.ChamberName = Equipments.CassettesModule
        dgsPumpDownTM.TypeOf_DiagnosticScreen = DiagnosticScreen.DiagnosticType.PumpDown_Curve
        dgsPumpDownTM.X_Axis_Title = "Time (Secs)"
        dgsPumpDownTM.Y_Axis_Title = Y_AXIS_TITLE
        dgsPumpDownTM.txtDescription.Text = "TM PDC"
        ''
        dgsRateOfRiseTM.TitleOfGraph = "Rate Of Rise run at"
        dgsRateOfRiseTM.ChamberName = Equipments.CassettesModule
        dgsRateOfRiseTM.TypeOf_DiagnosticScreen = DiagnosticScreen.DiagnosticType.Rate_Of_Rise
        dgsRateOfRiseTM.X_Axis_Title = "Time (Secs)"
        dgsRateOfRiseTM.Y_Axis_Title = Y_AXIS_TITLE
        dgsRateOfRiseTM.txtDescription.Text = "TM ROR"
        dgsRateOfRiseTM.Litter_Value = objConfig.Litter_Value

        objConfig = AVPLib.ContainerData.GetRobotConfig(Equipments.LoadLockA.ToString())
        tabPageLLA.Controls.Add(tabDiag_LLA)
        tabDiag_LLA.Dock = DockStyle.Fill
        dgsPumpDownLLA.TitleOfGraph = "Pump Down Curve run at"
        dgsPumpDownLLA.ChamberName = Equipments.LoadLockA
        dgsPumpDownLLA.TypeOf_DiagnosticScreen = DiagnosticScreen.DiagnosticType.PumpDown_Curve
        dgsPumpDownLLA.X_Axis_Title = "Time (Secs)"
        dgsPumpDownLLA.Y_Axis_Title = Y_AXIS_TITLE
        dgsPumpDownLLA.txtDescription.Text = "LLA PDC"
        ''
        dgsRateOfRiseLLA.TitleOfGraph = "Rate Of Rise run at"
        dgsRateOfRiseLLA.ChamberName = Equipments.LoadLockA
        dgsRateOfRiseLLA.TypeOf_DiagnosticScreen = DiagnosticScreen.DiagnosticType.Rate_Of_Rise
        dgsRateOfRiseLLA.X_Axis_Title = "Time (Secs)"
        dgsRateOfRiseLLA.Y_Axis_Title = Y_AXIS_TITLE
        dgsRateOfRiseLLA.txtDescription.Text = "LLA ROR"
        dgsRateOfRiseLLA.Litter_Value = objConfig.Litter_Value

        ''PM is not visible or (PM is VEECO_IBE) or (PM is not PVD) ==> remove tab
        If Not (RobotConfigurationValues.CHAMBER1_VISIBLE) OrElse
                (ContainerForm.Chamber1Panel.ChamberType = SystemModule.ModuleType.IBE AndAlso
                CType(ContainerForm.Chamber1Panel, IBEPanel).TypeOfIBE = IBEType.VEECO_IBE) Then
            tabDiag.Controls.Remove(tabPagePM1)
            tabDiag_PM1.Dispose()
        Else
            tabPagePM1.Controls.Add(tabDiag_PM1)
            tabDiag_PM1.Dock = DockStyle.Fill
            dgsPumpDownPM1.TitleOfGraph = "Pump Down Curve run at"
            dgsPumpDownPM1.ChamberName = Equipments.Chamber1
            dgsPumpDownPM1.TypeOf_DiagnosticScreen = DiagnosticScreen.DiagnosticType.PumpDown_Curve
            dgsPumpDownPM1.X_Axis_Title = "Time (Secs)"
            dgsPumpDownPM1.Y_Axis_Title = Y_AXIS_TITLE
            dgsPumpDownPM1.txtDescription.Text = "PM1 PDC"
            ''
            dgsRateOfRisePM1.TitleOfGraph = "Rate Of Rise run at"
            dgsRateOfRisePM1.ChamberName = Equipments.Chamber1
            dgsRateOfRisePM1.TypeOf_DiagnosticScreen = DiagnosticScreen.DiagnosticType.Rate_Of_Rise
            dgsRateOfRisePM1.X_Axis_Title = "Time (Secs)"
            dgsRateOfRisePM1.Y_Axis_Title = Y_AXIS_TITLE
            dgsRateOfRisePM1.txtDescription.Text = "PM1 ROR"
            dgsRateOfRisePM1.Litter_Value = ContainerForm.Chamber1Panel.ROR_Litter_Value
        End If
        ''PM is not visible or (PM is VEECO_IBE) or (PM is not PVD) ==> remove tab
        If Not (RobotConfigurationValues.CHAMBER2_VISIBLE) OrElse
                (ContainerForm.Chamber2Panel.ChamberType = SystemModule.ModuleType.IBE AndAlso
                CType(ContainerForm.Chamber2Panel, IBEPanel).TypeOfIBE = IBEType.VEECO_IBE) Then
            tabDiag.Controls.Remove(tabPagePM2)
            tabDiag_PM2.Dispose()
        Else
            tabPagePM2.Controls.Add(tabDiag_PM2)
            tabDiag_PM2.Dock = DockStyle.Fill
            dgsPumpDownPM2.TitleOfGraph = "Pump Down Curve run at"
            dgsPumpDownPM2.ChamberName = Equipments.Chamber2
            dgsPumpDownPM2.TypeOf_DiagnosticScreen = DiagnosticScreen.DiagnosticType.PumpDown_Curve
            dgsPumpDownPM2.X_Axis_Title = "Time (Secs)"
            dgsPumpDownPM2.Y_Axis_Title = Y_AXIS_TITLE
            dgsPumpDownPM2.txtDescription.Text = "PM2 PDC"
            ''
            dgsRateOfRisePM2.TitleOfGraph = "Rate Of Rise run at"
            dgsRateOfRisePM2.ChamberName = Equipments.Chamber2
            dgsRateOfRisePM2.TypeOf_DiagnosticScreen = DiagnosticScreen.DiagnosticType.Rate_Of_Rise
            dgsRateOfRisePM2.X_Axis_Title = "Time (Secs)"
            dgsRateOfRisePM2.Y_Axis_Title = Y_AXIS_TITLE
            dgsRateOfRisePM2.txtDescription.Text = "PM2 ROR"
            dgsRateOfRisePM2.Litter_Value = ContainerForm.Chamber2Panel.ROR_Litter_Value
        End If
        ''PM is not visible or (PM is VEECO_IBE) or (PM is not PVD) ==> remove tab
        If Not (RobotConfigurationValues.CHAMBER3_VISIBLE) OrElse
                (ContainerForm.Chamber3Panel.ChamberType = SystemModule.ModuleType.IBE AndAlso
                CType(ContainerForm.Chamber3Panel, IBEPanel).TypeOfIBE = IBEType.VEECO_IBE) Then
            tabDiag.Controls.Remove(tabPagePM3)
            tabDiag_PM3.Dispose()
        Else
            tabPagePM3.Controls.Add(tabDiag_PM3)
            tabDiag_PM3.Dock = DockStyle.Fill
            dgsPumpDownPM3.TitleOfGraph = "Pump Down Curve run at"
            dgsPumpDownPM3.ChamberName = Equipments.Chamber3
            dgsPumpDownPM3.TypeOf_DiagnosticScreen = DiagnosticScreen.DiagnosticType.PumpDown_Curve
            dgsPumpDownPM3.X_Axis_Title = "Time (Secs)"
            dgsPumpDownPM3.Y_Axis_Title = Y_AXIS_TITLE
            dgsPumpDownPM3.txtDescription.Text = "PM3 PDC"
            ''
            dgsRateOfRisePM3.TitleOfGraph = "Rate Of Rise run at"
            dgsRateOfRisePM3.ChamberName = Equipments.Chamber3
            dgsRateOfRisePM3.TypeOf_DiagnosticScreen = DiagnosticScreen.DiagnosticType.Rate_Of_Rise
            dgsRateOfRisePM3.X_Axis_Title = "Time (Secs)"
            dgsRateOfRisePM3.Y_Axis_Title = Y_AXIS_TITLE
            dgsRateOfRisePM3.txtDescription.Text = "PM3 ROR"
            dgsRateOfRisePM3.Litter_Value = ContainerForm.Chamber3Panel.ROR_Litter_Value
        End If
    End Sub

    Public Sub SendStop_ROR_PDC()
        If dgsPumpDownTM.IsPDC_ROR_Running Then
            dgsPumpDownTM.Send_Stop_When_App_Exit()
        End If
        If dgsRateOfRiseTM.IsPDC_ROR_Running Then
            dgsRateOfRiseTM.Send_Stop_When_App_Exit()
        End If

        If dgsPumpDownLLA.IsPDC_ROR_Running Then
            dgsPumpDownLLA.Send_Stop_When_App_Exit()
        End If
        If dgsRateOfRiseLLA.IsPDC_ROR_Running Then
            dgsRateOfRiseLLA.Send_Stop_When_App_Exit()
        End If

        If RobotConfigurationValues.CHAMBER1_VISIBLE Then
            If dgsPumpDownPM1.IsPDC_ROR_Running Then
                dgsPumpDownPM1.Send_Stop_When_App_Exit()
            End If
            If dgsRateOfRisePM1.IsPDC_ROR_Running Then
                dgsRateOfRisePM1.Send_Stop_When_App_Exit()
            End If
        End If
        If RobotConfigurationValues.CHAMBER2_VISIBLE Then
            If dgsPumpDownPM2.IsPDC_ROR_Running Then
                dgsPumpDownPM2.Send_Stop_When_App_Exit()
            End If
            If dgsRateOfRisePM2.IsPDC_ROR_Running Then
                dgsRateOfRisePM2.Send_Stop_When_App_Exit()
            End If
        End If
        If RobotConfigurationValues.CHAMBER3_VISIBLE Then
            If dgsPumpDownPM3.IsPDC_ROR_Running Then
                dgsPumpDownPM3.Send_Stop_When_App_Exit()
            End If
            If dgsRateOfRisePM3.IsPDC_ROR_Running Then
                dgsRateOfRisePM3.Send_Stop_When_App_Exit()
            End If
        End If
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2012-06-01</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub tabDiag_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
            tabDiag_TM.SelectedIndexChanged, tabDiag_PM3.SelectedIndexChanged, _
            tabDiag_PM2.SelectedIndexChanged, tabDiag_PM1.SelectedIndexChanged, tabDiag_LLA.SelectedIndexChanged
        Try
            Dim tabDiag As CustomTabControl = CType(sender, CustomTabControl)
            m_SelectedIndexTab = tabDiag.SelectedIndex
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2012-06-01</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub tabDiag_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabDiag.SelectedIndexChanged
        Try
            Dim tabPage As TabPage = tabDiag.SelectedTab
            If tabPage.Controls.Count = 1 Then
                Dim tabControl As CustomTabControl = CType(tabPage.Controls(0), CustomTabControl)
                tabControl.SelectedIndex = m_SelectedIndexTab
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
