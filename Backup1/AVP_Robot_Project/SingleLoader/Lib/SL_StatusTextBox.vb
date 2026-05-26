Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Public Class SL_StatusTextBox
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_txtTextBox As SL_Textbox
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
    Private Sub UpdateGUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            Dim strValue As String = String.Empty
            '#03/09/2011 
            '#Revert from revision 3084 to 3077 to can run for SL
            '#Begin fix
            Dim objIBEPanel As IBEPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
            'try to get Chamber Panel (some obj has GrandParent)
            If objIBEPanel Is Nothing Then
                objIBEPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
            End If
            '#End fix.
            If m_txtTextBox.UseDigitNumber = DigitsNumber.One_Digit AndAlso IsNumeric(Value) Then
                Value = Format(Double.Parse(Value), "0.0")
            ElseIf m_txtTextBox.UseDigitNumber = DigitsNumber.Two_Digits AndAlso IsNumeric(Value) Then
                Value = Format(Double.Parse(Value), "0.0#")
            ElseIf m_txtTextBox.UseDigitNumber = DigitsNumber.Three_Digits AndAlso IsNumeric(Value) Then
                Value = Format(Double.Parse(Value), "0.0##")
            ElseIf m_txtTextBox.UseDigitNumber = DigitsNumber.None_Digit AndAlso IsNumeric(Value) Then
                Value = Format(Double.Parse(Value), "0.")
                ''else normal case -> we don't format, use original
            End If

            If objIBEPanel Is Nothing Then
                Exit Try
            End If

            If m_txtTextBox.Parent.Name = "SLProcessControl" Then
                'Case: Process Control in Process Panel for Run, Stop, Abort button

                If Value = STR_ON Then
                    m_txtTextBox.BackColor = Color.SpringGreen
                ElseIf Value = STR_OFF Then
                    m_txtTextBox.BackColor = Color.Black
                Else
                    AVPLib.Log.avpLogger.Error("Update value to Textbox wrong: " & m_txtTextBox.Name & " value: " & Value)
                End If
                Exit Sub

            ElseIf (m_txtTextBox.Name = objIBEPanel.SLIGCGControl.txtIG.Name OrElse _
                   m_txtTextBox.Name = objIBEPanel.SLIGCGControl.txtCG.Name) AndAlso _
                   Not String.IsNullOrEmpty(objIBEPanel.SLIGCGControl.txtIG.Text) Then
                ''Fire IG/CG value to Pressure Textbox in IBE Panel
                Dim dblIg As Double = Double.Parse(objIBEPanel.SLIGCGControl.txtIG.Text)
            ElseIf m_txtTextBox.Name = objIBEPanel.txtProcessStep.Name Or _
                    m_txtTextBox.Name = "txtStepNumber" Or _
                    m_txtTextBox.Name = "txtStepTime" Or _
                    m_txtTextBox.Name = objIBEPanel.SLStatusPanel.txtStepTime.Name Then
                'Case: Process step
                Dim totalStep As String = objIBEPanel.txtTotalStep.Text
                Dim iTempValue As Integer = 0
                'Change process step to int format
                Int32.TryParse(totalStep.Trim, iTempValue)
                totalStep = iTempValue.ToString()
                If Not String.IsNullOrEmpty(totalStep) AndAlso totalStep <> "0" Then
                    Int32.TryParse(Value.Trim, iTempValue)
                    Value = (iTempValue + 1).ToString() & "/" & totalStep
                Else
                    Value = String.Empty
                End If
            ElseIf m_txtTextBox.Name = "txtMG" And objIBEPanel.PM_DeviceNet = True Then
                Dim objIBE As DataManagerment.IBEChamber = DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Name)
                If objIBE IsNot Nothing AndAlso objIBE.CGCMG_Communicating = DataManagerment.Equipment.WorkingStatuses.Off Then
                    objIBEPanel.txtMG.Text = ConstEnum.STR_ERROR
                    objIBEPanel.txtMG.ForeColor = Color.Red
                Else
                    objIBEPanel.txtMG.Text = Value
                    objIBEPanel.txtMG.ForeColor = Color.Black
                End If
                Exit Sub
            ElseIf m_txtTextBox.Name = "txtRoughlineCG" And objIBEPanel.PM_DeviceNet = True Then
                Dim objIBE As DataManagerment.IBEChamber = DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Name)
                If objIBE IsNot Nothing AndAlso objIBE.MP_Communicating = DataManagerment.Equipment.WorkingStatuses.Off Then
                    objIBEPanel.txtMPPressure.Text = ConstEnum.STR_ERROR
                    objIBEPanel.txtMPPressure.ForeColor = Color.Red
                Else
                    objIBEPanel.txtMPPressure.Text = Value
                    objIBEPanel.txtMPPressure.ForeColor = Color.Lime
                End If
                Exit Sub

            ElseIf m_txtTextBox.Name = "txtForelineCG" And objIBEPanel.PM_DeviceNet = True Then
                Dim objIBE As DataManagerment.IBEChamber = DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Name)
                If objIBE IsNot Nothing AndAlso objIBE.TurboForeline_Communicating = DataManagerment.Equipment.WorkingStatuses.Off Then
                    objIBEPanel.txtForelineCG.Text = ConstEnum.STR_ERROR
                    objIBEPanel.txtForelineCG.ForeColor = Color.Red
                Else
                    objIBEPanel.txtForelineCG.Text = Value
                    objIBEPanel.txtForelineCG.ForeColor = Color.Lime
                End If
                Exit Sub

            ElseIf (m_txtTextBox.Name = objIBEPanel.SLFixture.txtTiltAngleLeft.Name OrElse _
                     m_txtTextBox.Name = "txtTiltAngle") Then

                ' Update tilt angle to fixture control.
                Dim tiltAngle As Single
                Double.TryParse(Value, tiltAngle)
                objIBEPanel.SLContainerBox.RotationFixture.RotationAngle = tiltAngle

                If objIBEPanel.SLFixture.stTiltError.Status = FourStatusControl.DisplayStatus.Home Then
                    m_txtTextBox.Text = tiltAngle.ToString("0.#") & " (Err)"
                    m_txtTextBox.ForeColor = Color.Red
                    Exit Sub
                Else
                    m_txtTextBox.ForeColor = Color.Black
                End If

                'Support rotation fixture realtime for AVP_IBE
                If objIBEPanel.TypeOfIBE = AllChamberType.AVP_IBE Then
                    objIBEPanel.SLFixture.IsWaitingForMovingComplete = True
                End If

                If objIBEPanel.SLFixture.stTiltMoving.Status = FourStatusControl.DisplayStatus.Home Then
                    m_txtTextBox.Text = "Mov"
                    objIBEPanel.SLFixture.IsWaitingForMovingComplete = True
                    Exit Sub
                End If
                '#06/16/2011 
                '#-	Animate fixture angle after �mov� is complete.  Currently fixture is still moving but animation already show @ angle
                '#Begin fix
                If IsNumeric(Value) AndAlso (objIBEPanel.SLFixture.IsWaitingForMovingComplete OrElse objIBEPanel.SLFixture.FixtureAngleAtLoadState) Then
                    objIBEPanel.SLFixture.IsWaitingForMovingComplete = False
                    objIBEPanel.SLFixture.FixtureAngleAtLoadState = False
                End If
                '#End fix.
            ElseIf m_txtTextBox.Name = "txtSourceUsage" OrElse m_txtTextBox.Name = "txtSourceMinutes" OrElse _
                 m_txtTextBox.Parent.Name = "SL_SourceUsage" Then
                m_txtTextBox.Text = Math.Round(CDbl(arg), 1).ToString("0.0")
                If m_txtTextBox.Name = "txtSourceMinutes" Then
                    Send_SourceMinutes_ToSetUp_Screeen(objIBEPanel.Name, m_txtTextBox.Text)
                End If
                Exit Sub
                '#05/24/2011 
                '#-	IBE.   When galil power is cycle and we restart IBE,  IBE show that tilt angle is zero because galil default 
                '#all position to zero when power is cycle.    We only show tilt angle zero when tilt home sensor is made.  
                '#If not, we show tilt angle RB as �Err� instead of zero
                '#Begin fix
            ElseIf m_txtTextBox.Name = "txtTiltAngleRight" Then
               If objIBEPanel.SLFixture.stTiltError.Status = FourStatusControl.DisplayStatus.Home Then
                    m_txtTextBox.Text = String.Empty
                    Exit Sub
                End If
                '#End fix.
            ElseIf (m_txtTextBox.Name = objIBEPanel.SLFixture.txtRotationContinuousLeft.Name OrElse _
                 m_txtTextBox.Name = objIBEPanel.SLFixture.txtRotationStaticLeft.Name OrElse _
                 m_txtTextBox.Name = objIBEPanel.SLFixture.txtRotationSweepAngleReadback.Name) Then

                strValue = Value
                If objIBEPanel.SLFixture.stRotationError.Status = FourStatusControl.DisplayStatus.Home OrElse _
                   strValue = AVPLib.ConstEnum.FAKE_TILT_ANGLE_ERROR_VALUE Then
                    m_txtTextBox.Text = "Err"
                    m_txtTextBox.ForeColor = Color.Red
                    Exit Sub
                Else
                    'only Need to mod 360 for txtRotationStaticLeft,txtRotationSweepAngleReadback
                    'txtRotationContinuousLeft currently run max is about 20, therefore it will not be affect
                    Value = Format(Double.Parse(Value) Mod 360, "0.0")
                    m_txtTextBox.ForeColor = Color.Black
                End If

            ElseIf m_txtTextBox.Name = "txtWaferID" Then
                If Value.StartsWith(STR_OFF) Then
                    Value = String.Empty
                ElseIf Value.StartsWith(STR_ON) Then
                    Dim objChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Parent.Name)
                    If objChamber IsNot Nothing Then
                        Value = objChamber.WaferInfo.WaferID
                    End If
                End If
            ElseIf m_txtTextBox.Name = "txtRegenStatus" Then
                Value = Utils.GenerateRegenStatusToRegenStatusText(Value)

                '#09/02/2012
                '#Fix bug: K-Factor readback does not show.
            ElseIf m_txtTextBox.Name = "txtKFactorRight" Then
                Dim objIBE As DataManagerment.IBEChamber = DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Name)
                If Not objIBE.IsProcessRunning Then
                    Exit Try
                End If
                '#End fix
            ElseIf m_txtTextBox.Name = "txtTiltMode" Then
                If Value = "3" Then
                    m_txtTextBox.Text = "Static"
                ElseIf Value = "4" Then
                    m_txtTextBox.Text = "Sweep"
                End If
                Exit Sub
            End If
            m_txtTextBox.Text = Value
            m_txtTextBox.Tag = Value
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub Send_SourceMinutes_ToSetUp_Screeen(ByVal ChamberName As String, ByVal value As String)
        Select Case ChamberName
            Case Equipments.Chamber1.ToString()
                ContainerForm.SystemSetup.txtUsageKWH_PM1.Text = value
            Case Equipments.Chamber2.ToString()
                ContainerForm.SystemSetup.txtUsageKWH_PM2.Text = value
            Case Equipments.Chamber3.ToString()
                ContainerForm.SystemSetup.txtUsageKWH_PM3.Text = value
        End Select
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
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateGUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
#End Region
End Class
