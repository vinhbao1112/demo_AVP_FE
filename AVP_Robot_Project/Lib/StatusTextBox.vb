Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Public Class StatusTextBox
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_txtTextBox As TextBox
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
    Public Property ManagedTextBox() As TextBox
        Get
            Return m_txtTextBox
        End Get
        Set(ByVal value As TextBox)
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
    Public Sub New(ByVal txtManagedTextBox As TextBox)
        Try
            m_txtTextBox = txtManagedTextBox
            Me.Name = m_txtTextBox.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Public Methods"
    Private Sub IncreaseWaferCount()
        Dim objChamber As AVPLib.DataManagerment.Chamber = Nothing
        Select Case Me.Parent.Name
            Case Equipments.Chamber1.ToString()
                objChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Equipments.Chamber1.ToString())
                ContainerForm.SystemSetup.txtWaferCountPM1.Text = IIf(objChamber Is Nothing, 0, objChamber.PM_WaferCount)
            Case Equipments.Chamber2.ToString()
                objChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Equipments.Chamber2.ToString())
                ContainerForm.SystemSetup.txtWaferCountPM2.Text = IIf(objChamber Is Nothing, 0, objChamber.PM_WaferCount)
            Case Equipments.Chamber3.ToString()
                objChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Equipments.Chamber3.ToString())
                ContainerForm.SystemSetup.txtWaferCountPM3.Text = IIf(objChamber Is Nothing, 0, objChamber.PM_WaferCount)
        End Select
    End Sub

    Private Sub UpdateStepNumber(ByVal value As String)
        Try
            Dim objChamber As DataManagerment.Chamber = Nothing
            Dim chamberName As String = Me.Parent.Name.Replace("cbc", String.Empty)
            objChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(chamberName)
            Dim chamberConfig As AVPLib.SystemModule = AVPLib.ContainerData.GetRobotConfig(chamberName)

            If objChamber IsNot Nothing Then
                If chamberConfig.Type = SystemModule.ModuleType.IBE Then
                    '#05/04/2011 
                    '#Screen: Step number at IBE wrong. But Maintenance Screen is right!
                    '#Begin fix
                    Dim intValue As Integer = 0
                    If IsNumeric(value) Then
                        Integer.TryParse(value, intValue)
                        value = (intValue + 1).ToString()
                    End If
                    '#End fix.
                    value = value & "/" & CType(objChamber, AVPLib.DataManagerment.IBEChamber).ProcessMonitor_TotalStep
                ElseIf chamberConfig.Type = SystemModule.ModuleType.PVD4 Then
                    Dim intValue As Integer = 0
                    If IsNumeric(value) Then
                        Integer.TryParse(value, intValue)
                        value = (intValue + 1).ToString()
                    End If
                    '#End fix.
                    value = value & CType(objChamber, AVPLib.DataManagerment.CoronaChamber).CurrentRecipeLoop & "/" & CType(objChamber, AVPLib.DataManagerment.CoronaChamber).Process_Total_Steps

                ElseIf chamberConfig.Type = SystemModule.ModuleType.PVD5T Then
                    Dim intValue As Integer = 0
                    If IsNumeric(value) Then
                        Integer.TryParse(value, intValue)
                        value = (intValue + 1).ToString()
                    End If
                    '#End fix.
                    value = value & CType(objChamber, AVPLib.DataManagerment.PVD5TChamber).CurrentRecipeLoop & "/" & CType(objChamber, AVPLib.DataManagerment.PVD5TChamber).Process_Total_Steps
                End If
                m_txtTextBox.Text = value
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub UpdateShieldQuart()
        Dim objChamber As AVPLib.DataManagerment.Chamber = Nothing
        Dim ShieldQuart_Val As String = String.Empty
        Select Case Me.Parent.Name
            Case Equipments.Chamber1.ToString()
                objChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Equipments.Chamber1.ToString())
                If (objChamber IsNot Nothing AndAlso objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD) Then
                    ShieldQuart_Val = objChamber.Shields_Quart_KWH.ToString("0.###")
                ElseIf (objChamber IsNot Nothing AndAlso objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.IBE) Then
                    ShieldQuart_Val = objChamber.Shields_Quart_KWH.ToString("0.#")
                ElseIf (objChamber IsNot Nothing AndAlso objChamber.EquipmentType = SystemModule.ModuleType.PVD4) Then
                    ContainerForm.SystemSetup.txtShieldPM1.Text = ConstantAndEnum.STR_CLICK_FOR_DETAIL
                    Exit Select
                ElseIf (objChamber IsNot Nothing AndAlso objChamber.EquipmentType = SystemModule.ModuleType.PVD5T) Then
                    ContainerForm.SystemSetup.txtShieldPM1.Text = ConstantAndEnum.STR_CLICK_FOR_DETAIL
                    Exit Select
                ElseIf (objChamber Is Nothing) Then
                    ShieldQuart_Val = "0"
                End If
                ContainerForm.SystemSetup.txtShieldPM1.Text = ShieldQuart_Val
            Case Equipments.Chamber2.ToString()
                objChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Equipments.Chamber2.ToString())
                If (objChamber IsNot Nothing AndAlso objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD) Then
                    ShieldQuart_Val = objChamber.Shields_Quart_KWH.ToString("0.###")
                ElseIf (objChamber IsNot Nothing AndAlso objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.IBE) Then
                    ShieldQuart_Val = objChamber.Shields_Quart_KWH.ToString("0.#")
                ElseIf (objChamber IsNot Nothing AndAlso objChamber.EquipmentType = SystemModule.ModuleType.PVD4) Then
                    ContainerForm.SystemSetup.txtShieldsPM2.Text = ConstantAndEnum.STR_CLICK_FOR_DETAIL
                    Exit Select
                ElseIf (objChamber IsNot Nothing AndAlso objChamber.EquipmentType = SystemModule.ModuleType.PVD5T) Then
                    ContainerForm.SystemSetup.txtShieldsPM2.Text = ConstantAndEnum.STR_CLICK_FOR_DETAIL
                    Exit Select
                ElseIf (objChamber Is Nothing) Then
                    ShieldQuart_Val = "0"
                End If
                ContainerForm.SystemSetup.txtShieldsPM2.Text = ShieldQuart_Val
            Case Equipments.Chamber3.ToString()
                objChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Equipments.Chamber3.ToString())
                If (objChamber IsNot Nothing AndAlso objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.PVD) Then
                    ShieldQuart_Val = objChamber.Shields_Quart_KWH.ToString("0.###")
                ElseIf (objChamber IsNot Nothing AndAlso objChamber.EquipmentType = AVPLib.SystemModule.ModuleType.IBE) Then
                    ShieldQuart_Val = objChamber.Shields_Quart_KWH.ToString("0.#")
                ElseIf (objChamber IsNot Nothing AndAlso objChamber.EquipmentType = SystemModule.ModuleType.PVD4) Then
                    ContainerForm.SystemSetup.txtShieldsPM3.Text = ConstantAndEnum.STR_CLICK_FOR_DETAIL
                    Exit Select
                ElseIf (objChamber IsNot Nothing AndAlso objChamber.EquipmentType = SystemModule.ModuleType.PVD5T) Then
                    ContainerForm.SystemSetup.txtShieldsPM3.Text = ConstantAndEnum.STR_CLICK_FOR_DETAIL
                    Exit Select
                ElseIf (objChamber Is Nothing) Then
                    ShieldQuart_Val = "0"
                End If
                ContainerForm.SystemSetup.txtShieldsPM3.Text = ShieldQuart_Val
        End Select
    End Sub
    ''' <author>
    '''    	<name> Dat Do </name>
    '''     <date> 2009-04-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object and update UI
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Private Sub UpdateGUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            If m_txtTextBox.Name = TXTT1 Or m_txtTextBox.Name = TXTT2 Or m_txtTextBox.Name = "txtT" Then
                Value = Value & " K"
            End If
            
            Select Case Me.Name
                Case "txtPMWaferCount"
                    IncreaseWaferCount()
                Case "txtShieldQuart"
                    UpdateShieldQuart()
                Case "txtProcessStep"
                    Dim panelObj As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
                    If panelObj.ChamberType = AVPLib.SystemModule.ModuleType.IBE Then
                        'Dim totalstep As String = CType(panelObj, Chamber1Panel).prmProcessMonitor.txtTotalStep.Text
                        'If totalstep = String.Empty Then
                        '    Value = Value
                        'Else
                        '    Value = Value & "/" & totalstep
                        'End If
                    End If
                Case "txtStepNumber"
                    UpdateStepNumber(Value)
                    Exit Sub
                Case "txtIG"
                    Dim panelObj As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
                    'Chamber Screen
                    'if IG Status of PVD is not On-> don't update anything
                    If panelObj IsNot Nothing AndAlso _
                      (panelObj.ChamberType = SystemModule.ModuleType.PVD) Then
                        If Not CType(panelObj, PVDPanel).Baratron.bigcgIG.Status = DisplayStatus.On Then
                            Exit Sub
                        End If

                    End If
                    'Cassette and Process Screen
                    ''update for IBE screen -> IG value > base pressure -> turn IG button On
                    If Value <> STR_ON And UCase(Value) <> UCase(STR_OFF) And Value <> "" AndAlso IsNumeric(Value) Then
                        ''also raise on ProcessScreen and CassetteScreen
                        ' Utils.ChangeButtonIG(Me.Parent.Name, CDbl(Value), Me.Parent.Parent.Name)
                    ElseIf UCase(Value) = UCase(STR_ON) Then
                        Exit Sub
                    End If
                    ''normal case, just update value 
                    ' Value = ChangeValueOnIG(Value)
                Case "txtCG"
                    ' Utils.UpdateValueOnIG(Me.Parent.Name, Value, Me.Parent.Parent.Name)
                Case "txtWaferID"
                    Dim panelObj As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
                    If Me.Parent.Name = AVP_Robot_Project.ContainerForm.CassettesPanel.TMAlignerControl.usrWaferInfo.Name Then
                        Dim cb As AVPLib.DataManagerment.Aligner = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Aligner.ToString())
                        If cb.GetWaferInfo() Is Nothing Then
                            Value = String.Empty
                        Else
                            Value = cb.GetWaferInfo().WaferID
                        End If

                        ''Dat Cao add 
                        ''if Aligner is Empty then Clear all info of usrAligner panel
                        ''use this code is very flexible and not clear
                        'If (Value = "") Then 'Aligner is Empry
                        '    ContainerForm.Aligner.usrWaferInfo.ClearInfo()
                        '    ContainerForm.Aligner.usrAlignmentInfo.ClearInfo()
                        '    ContainerForm.Aligner.usrOperations.Enable_Disable_Action(False)
                        'Else
                        '    ContainerForm.Aligner.usrOperations.Enable_Disable_Action(True)
                        'End If
                    End If
                    If Value.StartsWith(STR_ON) Then
                        Value = Trim(Value.Replace(STR_ON, ""))
                        If Value.EndsWith(AVPLib.ConstEnum.enumWaferStatus.eWaferComplete.ToString()) Then
                            Value = Value.Replace(enumWaferStatus.eWaferComplete.ToString(), String.Empty)
                        ElseIf Value.EndsWith(AVPLib.ConstEnum.enumWaferStatus.eWaferError.ToString()) Then
                            Value = Value.Replace(enumWaferStatus.eWaferError.ToString(), String.Empty)
                        ElseIf Value.EndsWith(AVPLib.ConstEnum.enumWaferStatus.eWaferExposed.ToString()) Then
                            Value = Value.Replace(enumWaferStatus.eWaferExposed.ToString(), String.Empty)
                        ElseIf Value.EndsWith(AVPLib.ConstEnum.enumWaferStatus.eWaferNew.ToString()) Then
                            Value = Value.Replace(enumWaferStatus.eWaferNew.ToString(), String.Empty)
                        End If
                    ElseIf Value.StartsWith(STR_OFF) Then
                        Value = "0"
                        'if Wafer is nothing -> Wafer image should be invisible
                        If panelObj IsNot Nothing AndAlso _
                         (panelObj.ChamberType = SystemModule.ModuleType.PVD) Then
                            CType(panelObj, PVDPanel).ChuckControl.bicWaferInside.Visible = False
                        End If
                    End If
                Case "txtMatch"
                    If Value = STR_ON Then
                        Value = "Auto"
                    ElseIf Value = STR_OFF Then
                        Value = "Manual"
                    End If
                Case "txtTargetDCPulse"
                    If Value = STR_ON Then
                        Value = "Pulse"
                    ElseIf Value = STR_OFF Then
                        Value = "Normal"
                    End If
                Case "txtTotal"
#If AVP_PLATFORM = "CX" Then
                    If Me.Parent.Name = "lpcLoadLockA" Then
                        ContainerForm.ProcessPanel.lpcLoadLockA.txtTotal.Text = CInt(Value)
                    End If
                    ContainerForm.SystemSetup.txtLifeTimeWafer.Text = AVPLib.ContainerData.LifeTimeWafer.ToString()

                    'ContainerForm.ProcessPanel.wccWaferCount.txtTotal.Text = _
                    '                                               CInt(ContainerForm.ProcessPanel.lpcLoadLockA.txtTotal.Text) _
                    '                                               + CInt(ContainerForm.ProcessPanel.lpcLoadLockB.txtTotal.Text)
                    ContainerForm.ProcessPanel.wccWaferCount.txtTotal.Text = AVPLib.ContainerDAO.TotalWaferCount()
                    ''set to TM Obj to update SECSGEM
                    Dim Eq As AVPLib.DataManagerment.CassettesModule = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.CassettesModule.ToString())
                    If Eq IsNot Nothing Then
                        Eq.WaferCount = CInt(ContainerForm.ProcessPanel.wccWaferCount.txtTotal.Text)
                    End If

#End If
                Case "txtLotID"
                    If Parent.Name = ConstantAndEnum.LOADLOCKA Then
                        ContainerForm.ProcessPanel.lpcLoadLockA.LotID = Value
                    End If
                Case "txtSeqID"
                    If Parent.Name = ConstantAndEnum.LOADLOCKA Then
                        ContainerForm.ProcessPanel.lpcLoadLockA.SeqID = Value
                    End If
                Case "txtResponse" ' Dat Cao Add '$' to serial command -> on message receive 
                    Dim arrResult As String() = Value.Split("#")
                    Dim messageResult As String = String.Empty
                    Dim i As Integer
                    For i = 0 To arrResult.Length - 1
                        messageResult &= arrResult(i) & Environment.NewLine
                    Next
                    m_txtTextBox.Text = messageResult
                    Return
                Case "txtTurboIGLLA"
                    If IsNumeric(Value) Then
                        m_txtTextBox.Text = Format(Double.Parse(Value), AVPLib.ConstEnum.SCIENTIFIC_FORMAT_DECIMAL)
                        Return
                    Else
                        m_txtTextBox.Text = Value
                    End If
                    Return
                Case "txtTurboIGTM"
                    If IsNumeric(Value) Then
                        m_txtTextBox.Text = Format(Double.Parse(Value), AVPLib.ConstEnum.SCIENTIFIC_FORMAT_DECIMAL)
                    Else
                        m_txtTextBox.Text = Value
                    End If
                    Return
                Case "txtRoughLineLLA"
                    If IsNumeric(Value) Then
                        m_txtTextBox.Text = Format(Double.Parse(Value), AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                    Else
                        m_txtTextBox.Text = Value
                    End If
                    Return
                Case "txtRoughLineTM"
                    If IsNumeric(Value) Then
                        m_txtTextBox.Text = Format(Double.Parse(Value), AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                    Else
                        m_txtTextBox.Text = Value
                    End If
                    Return
                Case "txtProcessRecipe"
                    If (Not IsChamberRunning()) Then
                        Exit Sub
                    ElseIf Value = m_txtTextBox.Text Then
                        Dim panelObj As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
                        If panelObj IsNot Nothing Then
                            panelObj.RunRecipe.RecipeName = Value
                        End If
                        Exit Sub
                    End If
                Case "txtProcPressure"
                    Value = Format(Double.Parse(Value), "0.#")
                Case "txtTargetMode"
                    Dim panelObj As PVD5TPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                    If panelObj IsNot Nothing Then
                        panelObj.TabTargetPowerSupply.UpdateTargetMode(Value)
                    End If
            End Select

            m_txtTextBox.Text = Value
            m_txtTextBox.Tag = Value
            If Me.Parent.Name = "cgcRLCG" Then
                Utils.ChangeRoughLineValveControlStatus(Me.Parent.Parent.Name, CDbl(Value))
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    
    Private Function IsChamberRunning() As Boolean
        Dim blResult As Boolean = False
        Dim chamberName As String = Me.Parent.Parent.Name
        Dim chamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(chamberName)
        If (chamber IsNot Nothing) Then
            blResult = (chamber.RunProcessStatus = enumProcessStatus.eStart)
        End If
        Return blResult
    End Function

    'Private Function ChangeValueOnIG(ByVal value As String) As String
    '    Select Case Me.Parent.Parent.Name
    '        ''if value in Textbox change->check IG button Status 
    '        ''if status is off -->value of textbox will be set to off
    '        Case "Chamber1", "Chamber2", "Chamber3", "Chamber4", "Chamber5"
    '            Select Case Me.Parent.Name
    '                Case "BaCenterControl"
    '                    Dim igValue As Double = 0.0
    '                    Double.TryParse(value, igValue)
    '                    If (igValue > 0) Then
    '                        ' Todo: Turn IG button Green here. STATUS_ACTIVE
    '                    Else
    '                        ' Todo: Turn IG button Gray here. STATUS_INACTIVE
    '                        value = UCase(STR_OFF)
    '                    End If
    '            End Select
    '            ''in ProcessPanel Panel
    '        Case "ProcessPanel"
    '            Select Case Me.Parent.Name
    '                Case "cbcChamber1" 'get status button from CassettesPanel to display value
    '                    If ContainerForm.CassettesPanel.IgcgChamber1.bigcgIG.Status = DisplayStatus.Off _
    '                    AndAlso Not String.IsNullOrEmpty(ContainerForm.CassettesPanel.IgcgChamber1.txtCG.Text) Then
    '                        value = ContainerForm.ProcessPanel.cbcChamber1.txtCG.Text
    '                    ElseIf ContainerForm.CassettesPanel.IgcgChamber1.bigcgIG.Status = DisplayStatus.Off Then
    '                        value = UCase(STR_OFF)
    '                    End If
    '                Case "cbcChamber2"
    '                    If ContainerForm.CassettesPanel.IgcgChamber2.bigcgIG.Status = DisplayStatus.Off _
    '                    AndAlso Not String.IsNullOrEmpty(ContainerForm.CassettesPanel.IgcgChamber2.txtCG.Text) Then
    '                        value = ContainerForm.ProcessPanel.cbcChamber2.txtCG.Text
    '                    ElseIf ContainerForm.CassettesPanel.IgcgChamber2.bigcgIG.Status = DisplayStatus.Off Then
    '                        value = UCase(STR_OFF)
    '                    End If
    '                Case "cbcChamber3"
    '                    If ContainerForm.CassettesPanel.IgcgChamber3.bigcgIG.Status = DisplayStatus.Off _
    '                   AndAlso Not String.IsNullOrEmpty(ContainerForm.CassettesPanel.IgcgChamber3.txtCG.Text) Then
    '                        value = ContainerForm.ProcessPanel.cbcChamber3.txtCG.Text
    '                    ElseIf ContainerForm.CassettesPanel.IgcgChamber3.bigcgIG.Status = DisplayStatus.Off Then
    '                        value = UCase(STR_OFF)
    '                    End If
    '                Case "cbcChamber4"
    '                    If ContainerForm.CassettesPanel.IgcgChamber4.bigcgIG.Status = DisplayStatus.Off _
    '                    AndAlso Not String.IsNullOrEmpty(ContainerForm.CassettesPanel.IgcgChamber4.txtCG.Text) Then
    '                        value = ContainerForm.ProcessPanel.cbcChamber4.txtCG.Text
    '                    ElseIf ContainerForm.CassettesPanel.IgcgChamber4.bigcgIG.Status = DisplayStatus.Off Then
    '                        value = UCase(STR_OFF)
    '                    End If
    '                Case "cbcChamber5"
    '                    If ContainerForm.CassettesPanel.IgcgChamber5.bigcgIG.Status = DisplayStatus.Off _
    '                   AndAlso Not String.IsNullOrEmpty(ContainerForm.CassettesPanel.IgcgChamber5.txtCG.Text) Then
    '                        value = ContainerForm.ProcessPanel.cbcChamber5.txtCG.Text
    '                    ElseIf ContainerForm.CassettesPanel.IgcgChamber5.bigcgIG.Status = DisplayStatus.Off Then
    '                        value = UCase(STR_OFF)
    '                    End If
    '            End Select
    '        Case "CassettesPanel"
    '            Select Case Me.Parent.Name
    '                Case IGCGCHAMBER1_STR
    '                    If ContainerForm.CassettesPanel.IgcgChamber1.bigcgIG.Status = DisplayStatus.Off _
    '                      AndAlso Not String.IsNullOrEmpty(ContainerForm.CassettesPanel.IgcgChamber1.txtCG.Text) Then
    '                        value = ContainerForm.CassettesPanel.IgcgChamber1.txtCG.Text
    '                    ElseIf ContainerForm.CassettesPanel.IgcgChamber1.bigcgIG.Status = DisplayStatus.Off Then
    '                        value = UCase(STR_OFF)
    '                    End If
    '                Case IGCGCHAMBER2_STR
    '                    If ContainerForm.CassettesPanel.IgcgChamber2.bigcgIG.Status = DisplayStatus.Off _
    '                     AndAlso Not String.IsNullOrEmpty(ContainerForm.CassettesPanel.IgcgChamber2.txtCG.Text) Then
    '                        value = ContainerForm.CassettesPanel.IgcgChamber2.txtCG.Text
    '                    ElseIf ContainerForm.CassettesPanel.IgcgChamber2.bigcgIG.Status = DisplayStatus.Off Then
    '                        value = UCase(STR_OFF)
    '                    End If
    '                Case IGCGCHAMBER3_STR
    '                    If ContainerForm.CassettesPanel.IgcgChamber3.bigcgIG.Status = DisplayStatus.Off _
    '                        AndAlso Not String.IsNullOrEmpty(ContainerForm.CassettesPanel.IgcgChamber3.txtCG.Text) Then
    '                        value = ContainerForm.CassettesPanel.IgcgChamber3.txtCG.Text
    '                    ElseIf ContainerForm.CassettesPanel.IgcgChamber3.bigcgIG.Status = DisplayStatus.Off Then
    '                        value = UCase(STR_OFF)
    '                    End If
    '                Case IGCGCHAMBER4_STR
    '                    If ContainerForm.CassettesPanel.IgcgChamber4.bigcgIG.Status = DisplayStatus.Off _
    '                      AndAlso Not String.IsNullOrEmpty(ContainerForm.CassettesPanel.IgcgChamber4.txtCG.Text) Then
    '                        value = ContainerForm.CassettesPanel.IgcgChamber4.txtCG.Text
    '                    ElseIf ContainerForm.CassettesPanel.IgcgChamber4.bigcgIG.Status = DisplayStatus.Off Then
    '                        value = UCase(STR_OFF)
    '                    End If
    '                Case IGCGCHAMBER5_STR
    '                    If ContainerForm.CassettesPanel.IgcgChamber5.bigcgIG.Status = DisplayStatus.Off _
    '                    AndAlso Not String.IsNullOrEmpty(ContainerForm.CassettesPanel.IgcgChamber5.txtCG.Text) Then
    '                        value = ContainerForm.CassettesPanel.IgcgChamber5.txtCG.Text
    '                    ElseIf ContainerForm.CassettesPanel.IgcgChamber5.bigcgIG.Status = DisplayStatus.Off Then
    '                        value = UCase(STR_OFF)
    '                    End If
    '                Case "TMCtl"
    '                    If ContainerForm.CassettesPanel.TMCtl.bigcgIG.Status = DisplayStatus.Off _
    '                    AndAlso Not String.IsNullOrEmpty(ContainerForm.CassettesPanel.TMCtl.txtCG.Text) Then
    '                        ContainerForm.CassettesPanel.TMCtl.txtIG.Text = ContainerForm.CassettesPanel.TMCtl.txtCG.Text
    '                    ElseIf ContainerForm.CassettesPanel.TMCtl.bigcgIG.Status = DisplayStatus.Off Then
    '                        value = UCase(STR_OFF)
    '                    End If
    '            End Select
    '    End Select
    '    Return value
    'End Function

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
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateGUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
#End Region

End Class
