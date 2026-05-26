Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Public Class SL_StatusWaferInside
    Inherits AVPControls.StatusObject
#Region "Class Constants & Variables"
    Private m_bscPlasma As BinaryStatusControl
    Private m_ticWaferInside As CirclePlasmaControl
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-23</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the wafer control that will be managed by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedWaferControl() As CirclePlasmaControl
        Get
            Return m_ticWaferInside
        End Get
        Set(ByVal value As CirclePlasmaControl)
            m_ticWaferInside = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-23</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the plasma control that will be managed by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedPlasmaControl() As BinaryStatusControl
        Get
            Return m_bscPlasma
        End Get
        Set(ByVal value As BinaryStatusControl)
            m_bscPlasma = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-23</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with wafer inside control and plasma control that will be managed by this object
    ''' </summary>
    ''' <param name="ticWaferInside"></param>
    ''' <param name="bscPlasma"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal ticWaferInside As CirclePlasmaControl)
        m_ticWaferInside = ticWaferInside
        Me.Name = ticWaferInside.Name
        If m_bscPlasma Is Nothing Then
            m_bscPlasma = New BinaryStatusControl
        End If
        m_bscPlasma.Status = ticWaferInside.Status

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
            'The value format is: {On WAFERID waferStatus}
            'The value format is: {Off WAFERID WaferStatus}
            Dim Value As String = CType(arg, String)
            Dim valueArr() As String = Split(Value, " ")
            Dim strOnOff As String = String.Empty
            Dim strWaferID As String = String.Empty
            Dim strWaferStatus As String = String.Empty

            Const iOnOffIndex As Integer = 0
            Const iWaferIDIndex As Integer = 1
            Const iWaferStatusIndex As Integer = 2
            Const iFieldOnOffWaferIDWaferStatus As Integer = 3
            Const iFieldOnOffWaferID As Integer = 2
            Const iFieldOnOff As Integer = 1

            If valueArr.Length = iFieldOnOffWaferIDWaferStatus Then
                'Value include both wafer id and on off status
                strOnOff = valueArr(iOnOffIndex)
                strWaferID = valueArr(iWaferIDIndex)
                strWaferStatus = valueArr(iWaferStatusIndex)

            ElseIf valueArr.Length = iFieldOnOffWaferID Then
                'Value include both wafer id and on off status
                strOnOff = valueArr(iOnOffIndex)
                strWaferID = valueArr(iWaferIDIndex)

            ElseIf valueArr.Length = iFieldOnOff Then
                'Value include both on off status
                strOnOff = valueArr(iOnOffIndex)
            End If

            If (m_bscPlasma.Visible) Then
                Select Case strOnOff
                    Case "On"
                        m_bscPlasma.Status = BinaryStatusControl.DisplayStatus.On
                        WaferInChamber_On(Me.Name, strWaferID, strWaferStatus)
                    Case "Off"
                        m_bscPlasma.Status = BinaryStatusControl.DisplayStatus.Off
                        WaferInChamber_Off(Me.Name)
                    Case AVPLib.ConstEnum.enumWaferStatus.eWaferComplete
                        m_bscPlasma.Status = BinaryStatusControl.DisplayStatus.On
                        
                    Case AVPLib.ConstEnum.enumWaferStatus.eWaferError
                        m_bscPlasma.Status = BinaryStatusControl.DisplayStatus.On
                    Case AVPLib.ConstEnum.enumWaferStatus.eWaferExposed
                        m_bscPlasma.Status = BinaryStatusControl.DisplayStatus.On
                    Case AVPLib.ConstEnum.enumWaferStatus.eWaferNew
                        m_bscPlasma.Status = BinaryStatusControl.DisplayStatus.On
                    Case Else
                        m_bscPlasma.Refresh()
                End Select
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Khiet Tran </name>
    '''     <date> 2009-10-30</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on wafer insite chamber when wafer is ON
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Public Sub WaferInChamber_On(ByVal strWaferInsideChamber As String, ByVal strWaferID As String, ByVal strwaferStatus As String)
        Dim waferStatus As AVPLib.ConstEnum.enumWaferStatus = _
                         [Enum].Parse(GetType(AVPLib.ConstEnum.enumWaferStatus), strwaferStatus, True)
        Dim chamberObj As AVPLib.DataManagerment.Chamber = Nothing
        chamberObj = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Equipments.Chamber1.ToString())
        chamberObj.GetWaferInfo().WaferStatus = waferStatus
        'only in SL 
        Dim objIBEPanel As IBEPanel = ContainerForm.ChamberPanel(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
        objIBEPanel.SLContainerBox.RotationFixture.WaferID = strWaferID

        'Update Secs/Gem variables
        AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.ConstEnum.Equipments.Chamber1.ToString(), EMSERVICELib.VarType.SV, "WaferID", VALUELib.ValueType.A, strWaferID)
        'ContainerForm.SLProcessPanel.PMControl.WFControl.Refresh()
        Select Case waferStatus
            Case AVPLib.ConstEnum.enumWaferStatus.eWaferComplete
                objIBEPanel.SLContainerBox.RotationFixture.WaferStatus = enumWaferStatus.eWaferComplete
            Case AVPLib.ConstEnum.enumWaferStatus.eWaferError
                objIBEPanel.SLContainerBox.RotationFixture.WaferStatus = enumWaferStatus.eWaferError
            Case AVPLib.ConstEnum.enumWaferStatus.eWaferExposed
                objIBEPanel.SLContainerBox.RotationFixture.WaferStatus = enumWaferStatus.eWaferExposed
            Case AVPLib.ConstEnum.enumWaferStatus.eWaferNew
                objIBEPanel.SLContainerBox.RotationFixture.WaferStatus = enumWaferStatus.eWaferNew
        End Select
    End Sub
    ''' <author>
    '''    	<name> Khiet Tran </name>
    '''     <date> 2009-10-30</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on wafer insite chamber when wafer is OFF
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Public Sub WaferInChamber_Off(ByVal strWaferInsideChamber As String)
        Dim objIBEPanel As IBEPanel = ContainerForm.ChamberPanel(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
        Try
            'only in IBE
            If objIBEPanel Is Nothing Then
                Exit Sub
            End If
            objIBEPanel.SLContainerBox.RotationFixture.WaferStatus = enumWaferStatus.eWaferNone
            'Update Secs/Gem variables
            AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(AVPLib.ConstEnum.Equipments.Chamber1.ToString(), EMSERVICELib.VarType.SV, "WaferID", VALUELib.ValueType.A, String.Empty)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-23</date>
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
