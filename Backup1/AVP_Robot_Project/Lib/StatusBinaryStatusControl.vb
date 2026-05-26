Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Imports AVP_Robot_Project.ConstantAndEnum
Public Class StatusBinaryStatusControl
    Inherits AVPControls.StatusObject
#Region "Class Constants & Variables"
    Private m_bscBinaryStatusControl As BinaryStatusControl
#End Region

    ' This event raised when its status changes.
    Public Event StatusChangedEvent As AVPLib.DataManagerment.Equipment.StatusChangedEventHandler

#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the binary status control that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedBinaryStatusControl() As BinaryStatusControl
        Get
            Return m_bscBinaryStatusControl
        End Get
        Set(ByVal value As BinaryStatusControl)
            m_bscBinaryStatusControl = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with binary status control that will be managed by this object
    ''' </summary>
    ''' <param name="bscBinaryStatusControl"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal bscBinaryStatusControl As BinaryStatusControl)
        Try
            m_bscBinaryStatusControl = bscBinaryStatusControl
            Me.Name = m_bscBinaryStatusControl.Name
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
    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            If (Value = "Other") Or (Value = "Unknown") Then ' Invalid value.
                Return
            End If
           If Me.Name = "RoughPump" AndAlso IsNumeric(Value) Then
                Dim sRoughPump As String = "_RoughPump_Max_Value"
                If CDbl(Value) <= AVPLib.ContainerData.GetPressureConfig(Me.Parent.Name & sRoughPump) Then
                    If m_bscBinaryStatusControl.Status <> BinaryStatusControl.DisplayStatus.On Then
                        m_bscBinaryStatusControl.Status = BinaryStatusControl.DisplayStatus.On
                    End If
                Else
                    If m_bscBinaryStatusControl.Status <> BinaryStatusControl.DisplayStatus.Off Then
                        m_bscBinaryStatusControl.Status = BinaryStatusControl.DisplayStatus.Off
                    End If
                End If
                '#06/21/2011 
                '#-	Change MP pressure to similar to picture on the right.
                '#Begin fix
                Dim objPVDPanel As PVDPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                objPVDPanel.RoughPump.TextValue = objPVDPanel.CGInformation.txtInfor.Text
                objPVDPanel.RoughPump.Refresh()
                'End fix.

                '--->this code compare value with PVD.RoughPump Value in Config File
                'If (CDbl(AVPLib.ContainerData.PVDRoughPumpPressure) < CDbl(Value)) Then
                '    m_bscBinaryStatusControl.Status = BinaryStatusControl.DisplayStatus.On
                'ElseIf (CDbl(AVPLib.ContainerData.PVDRoughPumpPressure) >= CDbl(Value)) Then
                '    m_bscBinaryStatusControl.Status = BinaryStatusControl.DisplayStatus.Off
                'End If
                Exit Sub
            ElseIf Me.Name = "RoughPumpControl" Then
                Dim transferModule As AVPLib.DataManagerment.CassettesModule = _
                            AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.CassettesModule.ToString())
                Dim objRoughPump1 As AVPLib.DataManagerment.RoughPumpMachine = _
                            AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.RoughPumpMachine1.ToString)
                If IsNumeric(Value) AndAlso objRoughPump1 IsNot Nothing Then
                    '[Khoi Ha request]: Cannot turn TM and LL's mechanical pump RO off if mechanical pump RO = True and MP pressure is 760 Torr. 
                    'We should change state so that RO = True = Green and RO = False = Grey
                    If transferModule.RoughPump1Status = Equipment.WorkingStatuses.On Then
                        'If CDbl(Value) <= AVPLib.ContainerData.GetPressureConfig("RoughPump_Max_Value") AndAlso _
                        '            transferModule.RoughPump1Status = Equipment.WorkingStatuses.On Then
                        m_bscBinaryStatusControl.Status = BinaryStatusControl.DisplayStatus.On
                    Else
                        m_bscBinaryStatusControl.Status = BinaryStatusControl.DisplayStatus.Off
                    End If
                    ContainerForm.CassettesPanel.RoughPumpControl.TextValue = Value
                ElseIf objRoughPump1 IsNot Nothing Then
                    If (Value = AVPLib.ConstEnum.STR_ERROR) Then
                        ContainerForm.CassettesPanel.RoughPumpControl.TextValue = Value
                    End If
                    '[Khoi Ha request]: Cannot turn TM and LL's mechanical pump RO off if mechanical pump RO = True and MP pressure is 760 Torr. 
                    'We should change state so that RO = True = Green and RO = False = Grey
                    If (Value.ToString = AVPLib.ConstEnum.STR_ON) Then ' AndAlso _
                        'objRoughPump1.CG <= AVPLib.ContainerData.GetPressureConfig("RoughPump_Max_Value") Then
                        m_bscBinaryStatusControl.Status = BinaryStatusControl.DisplayStatus.On
                    Else
                        m_bscBinaryStatusControl.Status = BinaryStatusControl.DisplayStatus.Off
                    End If
                End If
                ContainerForm.CassettesPanel.RoughPumpControl.Refresh()
                Exit Sub
            ElseIf Me.Name = "RoughPumpControl2" Then
                Dim transferModule As AVPLib.DataManagerment.CassettesModule = _
                                AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.CassettesModule.ToString())
                Dim objRoughPump2 As AVPLib.DataManagerment.RoughPumpMachine = _
                            AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.RoughPumpMachine2.ToString)
                If IsNumeric(Value) AndAlso objRoughPump2 IsNot Nothing Then
                    '[Khoi Ha request]: Cannot turn TM and LL's mechanical pump RO off if mechanical pump RO = True and MP pressure is 760 Torr. 
                    'We should change state so that RO = True = Green and RO = False = Grey
                    If transferModule.RoughPump2Status = Equipment.WorkingStatuses.On Then
                        'If CDbl(Value) <= AVPLib.ContainerData.GetPressureConfig("RoughPump_Max_Value") AndAlso _
                        '        transferModule.RoughPump2Status = Equipment.WorkingStatuses.On Then
                        m_bscBinaryStatusControl.Status = BinaryStatusControl.DisplayStatus.On
                    Else
                        m_bscBinaryStatusControl.Status = BinaryStatusControl.DisplayStatus.Off
                    End If
                    ContainerForm.CassettesPanel.RoughPumpControl2.TextValue = Value
                ElseIf objRoughPump2 IsNot Nothing Then

                    If (Value = AVPLib.ConstEnum.STR_ERROR) Then
                        ContainerForm.CassettesPanel.RoughPumpControl2.TextValue = Value
                    End If
                    '[Khoi Ha request]: Cannot turn TM and LL's mechanical pump RO off if mechanical pump RO = True and MP pressure is 760 Torr. 
                    'We should change state so that RO = True = Green and RO = False = Grey
                    If (Value.ToString = AVPLib.ConstEnum.STR_ON) Then ' AndAlso _
                        'objRoughPump2.CG <= AVPLib.ContainerData.GetPressureConfig("RoughPump_Max_Value") Then
                        m_bscBinaryStatusControl.Status = BinaryStatusControl.DisplayStatus.On
                    Else
                        m_bscBinaryStatusControl.Status = BinaryStatusControl.DisplayStatus.Off
                    End If
                End If
                ContainerForm.CassettesPanel.RoughPumpControl2.Refresh()
                Exit Sub
            End If
            Dim enmStatus As BinaryStatusControl.DisplayStatus = CType([Enum].Parse(GetType(BinaryStatusControl.DisplayStatus), Value), BinaryStatusControl.DisplayStatus)
            If enmStatus <> m_bscBinaryStatusControl.Status Then
                m_bscBinaryStatusControl.Status = enmStatus
            End If
            If Me.Name = "awcAligner" Then
                If Value = "On" Then
                    ContainerForm.ProcessPanel.TransparentImageAligner.Visible = True
                ElseIf Value = "Off" Then
                    ContainerForm.ProcessPanel.TransparentImageAligner.Visible = False
                    ContainerForm.CassettesPanel.awcAligner.Visible = False
                    ContainerForm.CassettesPanel.awcAligner.Visible = True
                End If
            End If
            'Case: FlowCool He Valve in SL
            Dim objIBEPanel As IBEPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)

            If objIBEPanel IsNot Nothing AndAlso Me.Name = "ValveShutoffFlowCoolGas" Then
                Dim SupplyCanOpen As Boolean = _
                objIBEPanel.SLFixture.ValveShutoffFlowCoolGas.Status = BinaryStatusControl.DisplayStatus.On And Value = STR_ON
                objIBEPanel.SLStatusPanel.btnFlowcoolGas.Status = IIf(SupplyCanOpen, SL_CustomButton.DisplayStatus.On, SL_CustomButton.DisplayStatus.Off)
                objIBEPanel.ValveFlowCoolReturn.Status = objIBEPanel.SLFixture.ValveShutoffFlowCoolGas.Status
                ' Update SECS/GEM variables by Hoa Nguyen
                ' Var Name: PMx.FlowCoolGasOnStatus
                AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Parent.Parent.Name, EMSERVICELib.VarType.SV, _
                            "FlowCoolGasOnStatus", VALUELib.ValueType.U1, objIBEPanel.SLStatusPanel.btnFlowcoolGas.Status)
            ElseIf objIBEPanel IsNot Nothing AndAlso Me.Name = "ValveSupplyFlowCoolGas" Then
                Dim ShutOffCanOpen As Boolean = _
                 objIBEPanel.SLFixture.ValveSupplyFlowCoolGas.Status = BinaryStatusControl.DisplayStatus.On And Value = STR_ON
                objIBEPanel.SLStatusPanel.btnFlowcoolGas.Status = IIf(ShutOffCanOpen, SL_CustomButton.DisplayStatus.On, SL_CustomButton.DisplayStatus.Off)
                ' Update SECS/GEM variables by Hoa Nguyen
                ' Var Name: PMx.FlowCoolGasOnStatus
                AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(Me.Parent.Parent.Name, EMSERVICELib.VarType.SV, _
                            "FlowCoolGasOnStatus", VALUELib.ValueType.U1, objIBEPanel.SLStatusPanel.btnFlowcoolGas.Status)
            End If

            ' Raise changed status event.
            Dim statusChangedEvent As StatusChangedEventArgs = New StatusChangedEventArgs()
            statusChangedEvent.Message = Value
            RaiseEvent StatusChangedEvent(m_bscBinaryStatusControl, statusChangedEvent)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-05</date>
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
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
    ''' <author>
    '''     	<name> Ngo Cao Dinh </name>
    '''     	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to request status of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub RequestStatus(ByVal Identification As String, ByVal Value As String)

    End Sub

#End Region

End Class
