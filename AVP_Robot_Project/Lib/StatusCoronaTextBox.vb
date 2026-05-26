Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Public Class StatusCoronaTextBox
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Protected m_txtTextBox As SL_Textbox
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the text box that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New()
    End Sub
    Public Property ManagedTextBox() As SL_Textbox
        Get
            Return m_txtTextBox
        End Get
        Set(ByVal value As SL_Textbox)
            m_txtTextBox = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with text box that will be managed by this object
    ''' </summary>
    ''' <param name="txtManagedTextBox"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal txtManagedTextBox As SL_Textbox)
        Try
            m_txtTextBox = txtManagedTextBox
            Me.Name = m_txtTextBox.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Dat Do </name>
    '''     <date> 2009-04-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object and update UI
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub UpdateGUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            With m_txtTextBox
                If .UseDigitNumber = DigitsNumber.One_Digit AndAlso IsNumeric(Value) Then
                    Value = Format(Double.Parse(Value), "0.#")
                ElseIf .UseDigitNumber = DigitsNumber.Two_Digits AndAlso IsNumeric(Value) Then
                    Value = Format(Double.Parse(Value), "0.##")
                ElseIf .UseDigitNumber = DigitsNumber.Three_Digits AndAlso IsNumeric(Value) Then
                    Value = Format(Double.Parse(Value), "0.###")
                    'ElseIf .UseDigitNumber = DigitsNumber.Four_Digits AndAlso IsNumeric(Value) Then
                    '    Value = Format(Double.Parse(Value), "0.####")
                ElseIf .UseDigitNumber = DigitsNumber.None_Digit AndAlso IsNumeric(Value) Then
                    Value = Format(Double.Parse(Value), "0.")
                    ''else normal case -> we don't format, use original
                ElseIf .UseScientificFormat AndAlso IsNumeric(Value) Then
                    Dim dblIg As Double = 0
                    Double.TryParse(Value, dblIg)
                    Value = Format(dblIg, AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                End If
                'If .UseScientificFormat Then
                '    Value = Format(Double.Parse(Value),
                '                IIf(.UseDigitNumber = DigitsNumber.Four_Digits,
                '                IGCG_INITVALUE, AVPLib.ConstEnum.SCIENTIFIC_FORMAT))
                'End If

                Dim objPanel As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)

                If .Name.Contains("txtKwhUsageTarget") Then
                    SendToSystemSetupScreen(Me.Parent.Name, Value)
                End If
                If .Name.Contains("txtShieldQuartTarget") Then
                    UpdateShieldQuart(Me.Parent.Name, Value)
                End If
                If .Name = "txtGotoSlot" OrElse .Name = "txtTablePos" OrElse .Name = "txtRotate" Then
                    ''PVD4
                    If objPanel.ChamberType = SystemModule.ModuleType.PVD4 Then
                        Dim objChamber As DataManagerment.CoronaChamber = DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Parent.Name)
                        If objChamber IsNot Nothing Then

                            If .Name = "txtGotoSlot" OrElse .Name = "txtRotate" Then
                                If Value.Contains("-1") AndAlso objChamber.Is_MotionInitalized = DataManagerment.Equipment.WorkingStatuses.On Then
                                    If objChamber.Substrate_Table_Rotate_Status = DataManagerment.Equipment.WorkingStatuses.On Then
                                        .Text = "Rotating"
                                    Else
                                        .Text = ConstantAndEnum.UNKNOWN
                                    End If
                                    Exit Sub
                                Else
                                    If objChamber.Is_MotionInitalized = DataManagerment.Equipment.WorkingStatuses.Off Then
                                        .Text = ConstantAndEnum.UNKNOWN
                                        Exit Sub
                                    End If
                                End If
                            End If

                            If objChamber.Is_MotionInitalized = DataManagerment.Equipment.WorkingStatuses.Off Then
                                .Text = ConstantAndEnum.UNKNOWN
                                Exit Sub
                            Else
                                ''Tran Cao Dua:5/18/2017: txtTablePos show Moving when Substrate table up down is moving. Bug: 0010911
                                If .Name = "txtTablePos" Then
                                    If Value.StartsWith(STR_ON) Then
                                        .Text = "Moving"
                                        Exit Sub
                                    ElseIf Value.StartsWith(STR_OFF) Then
                                        .Text = objChamber.Substrate_Table_Current_Position_Readback.ToString()
                                        Exit Sub
                                    Else
                                        If objChamber.Substrate_Table_Up_Down_Moving = DataManagerment.Equipment.WorkingStatuses.On Then
                                            .Text = "Moving"
                                            Exit Sub
                                        Else
                                            .Text = Value
                                            Exit Sub
                                        End If
                                    End If
                                End If
                            End If
                        End If
                        ''PVD5T
                    ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD5T Then ''PVD5T
                        Dim objChamber As DataManagerment.PVD5TChamber = DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Parent.Name)
                        If objChamber IsNot Nothing Then

                            If .Name = "txtGotoSlot" OrElse .Name = "txtRotate" Then
                                If Value.Contains("-1") AndAlso objChamber.Is_MotionInitalized = DataManagerment.Equipment.WorkingStatuses.On Then
                                    If objChamber.Substrate_Table_Rotate_Status = DataManagerment.Equipment.WorkingStatuses.On Then
                                        .Text = "Rotating"
                                    Else
                                        .Text = ConstantAndEnum.UNKNOWN
                                    End If
                                    Exit Sub
                                Else
                                    If objChamber.Is_MotionInitalized = DataManagerment.Equipment.WorkingStatuses.Off Then
                                        .Text = ConstantAndEnum.UNKNOWN
                                        Exit Sub
                                    End If
                                End If
                            End If

                            If objChamber.Is_MotionInitalized = DataManagerment.Equipment.WorkingStatuses.Off Then
                                .Text = ConstantAndEnum.UNKNOWN
                                Exit Sub
                            Else
                                ''Tran Cao Dua:5/18/2017: txtTablePos show Moving when Substrate table up down is moving. Bug: 0010911
                                If .Name = "txtTablePos" Then
                                    If Value.StartsWith(STR_ON) Then
                                        .Text = "Moving"
                                        Exit Sub
                                    ElseIf Value.StartsWith(STR_OFF) Then
                                        .Text = objChamber.Substrate_Table_Current_Position_Readback.ToString()
                                        Exit Sub
                                    Else
                                        If objChamber.Substrate_Table_Up_Down_Moving = DataManagerment.Equipment.WorkingStatuses.On Then
                                            .Text = "Moving"
                                            Exit Sub
                                        Else
                                            .Text = Value
                                            Exit Sub
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                ElseIf .Name = "txtGas1" _
                    OrElse .Name = "txtGas2" _
                    OrElse .Name = "txtGas3" _
                    OrElse .Name = "txtGas4" _
                    OrElse .Name = "txtGas5" Then
                    ''PVD4
                    If objPanel.ChamberType = SystemModule.ModuleType.PVD4 Then
                        Dim objPVD4Panel As CoronaPanel = CType(objPanel, CoronaPanel)
                        If objPVD4Panel IsNot Nothing Then
                            objPVD4Panel.GasController.UpdateGasMFCDeviceNetStatus()
                            Exit Sub
                        End If
                        ''PVD5T
                    ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD5T Then ''PVD5T
                        Dim objPVD5TPanel As PVD5TPanel = CType(objPanel, PVD5TPanel)
                        If objPVD5TPanel IsNot Nothing Then
                            objPVD5TPanel.GasController.UpdateGasMFCDeviceNetStatus()
                            Exit Sub
                        End If
                    End If
                End If
                .Text = Value

                If .Name = "txtIG" AndAlso Value = "0.0E+00" Then
                    .Text = "OFF"
                ElseIf (.Name = "txtIG" OrElse .Name = "txtCG" OrElse .Name = "txtRoughLineCG" OrElse .Name = "txtForelineCG" OrElse .Name = "txtPressure") Then
                    If Value = "-1.0E+00" Then
                        .Text = "Error"
                        .ForeColor = Color.Red
                    Else
                        .Text = Value
                        .ForeColor = Color.Lime
                    End If
                ElseIf m_txtTextBox.Name = "txtWaferID" Then
                    If Value.StartsWith(STR_OFF) Then
                        Value = "0"
                    ElseIf Value.StartsWith(STR_ON) Then
                        Dim objChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Parent.Name)
                        If objChamber IsNot Nothing Then
                            Value = objChamber.GetWaferInfo().WaferID
                        End If
                    End If
                    .Text = Value
                ElseIf .Name = "txtRampingPercent" Then
                    .Text = Double.Parse(Value).ToString("0.") + "%"
                ElseIf m_txtTextBox.Name = "txtProcessStep" Then
                    Dim objChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Parent.Name)
                    If objChamber IsNot Nothing Then
                        Dim intValue As Integer = 0
                        If IsNumeric(Value) Then
                            Integer.TryParse(Value, intValue)
                            Value = (intValue + 1).ToString()
                        End If
                        ''PVD4
                        If objPanel.ChamberType = SystemModule.ModuleType.PVD4 Then
                            Value = Value & CType(objChamber, AVPLib.DataManagerment.CoronaChamber).CurrentRecipeLoop & "/" & CType(objChamber, AVPLib.DataManagerment.CoronaChamber).Process_Total_Steps

                            ''PVD5T
                        ElseIf objPanel.ChamberType = SystemModule.ModuleType.PVD5T Then ''PVD5T
                            Value = Value & CType(objChamber, AVPLib.DataManagerment.PVD5TChamber).CurrentRecipeLoop & "/" & CType(objChamber, AVPLib.DataManagerment.PVD5TChamber).Process_Total_Steps

                        End If
                    End If
                    .Text = Value
                End If

                If Not .DisplayPressureFont Then
                    .ForeColor = Color.Black
                End If
                .Tag = Value
            End With
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-Apr-4</date>
    ''' </author>
    ''' <summary>
    '''Update SetupScreen base on KWH value
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SendToSystemSetupScreen(ByVal ScreenName As String, ByVal value As String)
        Try
            Select Case ScreenName
                Case Equipments.Chamber1.ToString()
                    If Me.Name = "txtKwhUsageTarget1" Then
                        ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T1_Usage = value
                    ElseIf Me.Name = "txtKwhUsageTarget2" Then
                        ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T2_Usage = value
                    ElseIf Me.Name = "txtKwhUsageTarget3" Then
                        ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T3_Usage = value
                    ElseIf Me.Name = "txtKwhUsageTarget4" Then
                        ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T4_Usage = value
                    ElseIf Me.Name = "txtKwhUsageTarget5" Then
                        ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T5_Usage = value
                    End If
                Case Equipments.Chamber2.ToString()
                    If Me.Name = "txtKwhUsageTarget1" Then
                        ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T1_Usage = value
                    ElseIf Me.Name = "txtKwhUsageTarget2" Then
                        ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T2_Usage = value
                    ElseIf Me.Name = "txtKwhUsageTarget3" Then
                        ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T3_Usage = value
                    ElseIf Me.Name = "txtKwhUsageTarget4" Then
                        ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T4_Usage = value
                    ElseIf Me.Name = "txtKwhUsageTarget5" Then
                        ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T5_Usage = value
                    End If
                Case Equipments.Chamber3.ToString()
                    If Me.Name = "txtKwhUsageTarget1" Then
                        ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T1_Usage = value
                    ElseIf Me.Name = "txtKwhUsageTarget2" Then
                        ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T2_Usage = value
                    ElseIf Me.Name = "txtKwhUsageTarget3" Then
                        ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T3_Usage = value
                    ElseIf Me.Name = "txtKwhUsageTarget4" Then
                        ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T4_Usage = value
                    ElseIf Me.Name = "txtKwhUsageTarget5" Then
                        ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T5_Usage = value
                    End If
                
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub UpdateShieldQuart(ByVal ScreenName As String, ByVal value As String)
        Try
            Select Case ScreenName
                Case Equipments.Chamber1.ToString()
                    If Me.Name = "txtShieldQuartTarget1" Then
                        ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T1_ShieldsQuartz = value
                    ElseIf Me.Name = "txtShieldQuartTarget2" Then
                        ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T2_ShieldsQuartz = value
                    ElseIf Me.Name = "txtShieldQuartTarget3" Then
                        ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T3_ShieldsQuartz = value
                    ElseIf Me.Name = "txtShieldQuartTarget4" Then
                        ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T4_ShieldsQuartz = value
                    ElseIf Me.Name = "txtShieldQuartTarget5" Then
                        ContainerForm.SystemSetup.PM1TargetPSConfigPopUpPanel.TargetPSConfig.T5_ShieldsQuartz = value
                    End If
                Case Equipments.Chamber2.ToString()
                    If Me.Name = "txtShieldQuartTarget1" Then
                        ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T1_ShieldsQuartz = value
                    ElseIf Me.Name = "txtShieldQuartTarget2" Then
                        ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T2_ShieldsQuartz = value
                    ElseIf Me.Name = "txtShieldQuartTarget3" Then
                        ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T3_ShieldsQuartz = value
                    ElseIf Me.Name = "txtShieldQuartTarget4" Then
                        ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T4_ShieldsQuartz = value
                    ElseIf Me.Name = "txtShieldQuartTarget5" Then
                        ContainerForm.SystemSetup.PM2TargetPSConfigPopUpPanel.TargetPSConfig.T5_ShieldsQuartz = value
                    End If
                Case Equipments.Chamber3.ToString()
                    If Me.Name = "txtShieldQuartTarget1" Then
                        ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T1_ShieldsQuartz = value
                    ElseIf Me.Name = "txtShieldQuartTarget2" Then
                        ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T2_ShieldsQuartz = value
                    ElseIf Me.Name = "txtShieldQuartTarget3" Then
                        ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T3_ShieldsQuartz = value
                    ElseIf Me.Name = "txtShieldQuartTarget4" Then
                        ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T4_ShieldsQuartz = value
                    ElseIf Me.Name = "txtShieldQuartTarget5" Then
                        ContainerForm.SystemSetup.PM3TargetPSConfigPopUpPanel.TargetPSConfig.T5_ShieldsQuartz = value
                    End If
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        'AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        'AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateGUI), Value)
        'AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
#End Region
End Class
