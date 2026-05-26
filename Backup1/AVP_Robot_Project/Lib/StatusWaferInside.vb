Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPControls

Public Class StatusWaferInside
    Inherits AVPControls.StatusObject
#Region "Class Constants & Variables"
    Private m_ticWaferInside As AVPWaferControl
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
    Public Property ManagedWaferControl() As AVPWaferControl
        Get
            Return m_ticWaferInside
        End Get
        Set(ByVal value As AVPWaferControl)
            m_ticWaferInside = value
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
    Public Sub New(ByVal ticWaferInside As AVPWaferControl)
        m_ticWaferInside = ticWaferInside
        Me.Name = ticWaferInside.Name

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
            Dim SlotID As Integer = 1

            Const iOnOffIndex As Integer = 0
            Const iSlotID As Integer = 1
            Const iWaferIDIndex As Integer = 2
            Const iWaferStatusIndex As Integer = 3
            Const iFieldOnOffWaferIDWaferStatus As Integer = 4
            Const iFieldOnOffWaferID As Integer = 3
            Const iFieldOnOff As Integer = 2

            If valueArr.Length = iFieldOnOffWaferIDWaferStatus Then
                'Value include both wafer id and on off status
                strOnOff = valueArr(iOnOffIndex)
                Integer.TryParse(valueArr(iSlotID), SlotID)
                strWaferID = valueArr(iWaferIDIndex)
                strWaferStatus = valueArr(iWaferStatusIndex)

            ElseIf valueArr.Length = iFieldOnOffWaferID Then
                'Value include both wafer id and on off status
                strOnOff = valueArr(iOnOffIndex)
                Integer.TryParse(valueArr(iSlotID), SlotID)
                strWaferID = valueArr(iWaferIDIndex)

            ElseIf valueArr.Length = iFieldOnOff Then
                'Value include both on off status
                strOnOff = valueArr(iOnOffIndex)
                Integer.TryParse(valueArr(iSlotID), SlotID)
            End If

            Select Case strOnOff
                Case "On"
                    If strWaferStatus = String.Empty Then
                        Exit Sub
                    End If

                    Dim waferStatus As AVPLib.ConstEnum.enumWaferStatus = _
                        [Enum].Parse(GetType(AVPLib.ConstEnum.enumWaferStatus), strWaferStatus, True)

                    Dim isShowQM As Boolean

                    Dim isWaferError As Boolean = (waferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferError)
                    Dim isProcessJobExist As Boolean = False
                    If AVPLib.Business.AVPCore.Instance().JobManager IsNot Nothing Then
                        isProcessJobExist = (AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(strWaferID) IsNot Nothing)
                    End If

                    Dim isJobPaused As Boolean = Utils.Check_WaferID_Has_PausedJob(strWaferID)

                    If (isJobPaused OrElse (isWaferError AndAlso isProcessJobExist)) Then
                        isShowQM = True
                    End If

                    If (Not waferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferComplete) Then
                        WaferInChamber_On(Me.Name, strWaferID, strWaferStatus, SlotID, isShowQM)
                    Else
                        If (Utils.CanUpdateWaferStatus(strWaferID)) Then
                            WaferInChamber_On(Me.Name, strWaferID, strWaferStatus, SlotID)
                        End If
                    End If
                Case "Off"

                    WaferInChamber_Off(Me.Name, SlotID)

            End Select
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
    Public Sub WaferInChamber_On(ByVal strWaferInsideChamber As String, ByVal strWaferID As String, ByVal strwaferStatus As String, Optional ByVal SlotID As Integer = 0, Optional ByVal isShowQM As Boolean = False)
        Dim waferStatus As AVPLib.ConstEnum.enumWaferStatus = _
                         [Enum].Parse(GetType(AVPLib.ConstEnum.enumWaferStatus), strwaferStatus, True)
        Select Case Me.Parent.Name
            Case ContainerForm.CassettesPanel.CX_PM1.Name
                If ContainerForm.Chamber1Panel.ChamberType = AVPLib.SystemModule.ModuleType.PVD Then
                    CType(ContainerForm.Chamber1Panel, PVDPanel).ChuckControl.bicWaferInside.Visible = True
                    Select Case waferStatus
                        Case AVPLib.ConstEnum.enumWaferStatus.eWaferComplete
                            CType(ContainerForm.Chamber1Panel, PVDPanel).ChuckControl.bicWaferInside.Status = DisplayStatus.Off
                        Case AVPLib.ConstEnum.enumWaferStatus.eWaferError
                            CType(ContainerForm.Chamber1Panel, PVDPanel).ChuckControl.bicWaferInside.Status = DisplayStatus.Error
                        Case AVPLib.ConstEnum.enumWaferStatus.eWaferNew
                            CType(ContainerForm.Chamber1Panel, PVDPanel).ChuckControl.bicWaferInside.Status = DisplayStatus.On
                        Case AVPLib.ConstEnum.enumWaferStatus.eWaferExposed
                            CType(ContainerForm.Chamber1Panel, PVDPanel).ChuckControl.bicWaferInside.Status = DisplayStatus.Unknow
                    End Select
                ElseIf ContainerForm.Chamber1Panel.ChamberType = AVPLib.SystemModule.ModuleType.IBE Then
                    CType(ContainerForm.Chamber1Panel, IBEPanel).SLContainerBox.RotationFixture.WaferID = strWaferID
                    CType(ContainerForm.Chamber1Panel, IBEPanel).SLContainerBox.RotationFixture.WaferStatus = waferStatus

                ElseIf ContainerForm.Chamber1Panel.ChamberType = AVPLib.SystemModule.ModuleType.PVD4 Then
                    CType(ContainerForm.Chamber1Panel, CoronaPanel).CoronaChamber.SlotxWaferID(SlotID) = strWaferID
                    CType(ContainerForm.Chamber1Panel, CoronaPanel).CoronaChamber.SlotxStatus(SlotID) = waferStatus

                ElseIf ContainerForm.Chamber1Panel.ChamberType = AVPLib.SystemModule.ModuleType.PVD5T Then
                    CType(ContainerForm.Chamber1Panel, PVD5TPanel).CoronaChamber.SlotxWaferID(SlotID) = strWaferID
                    CType(ContainerForm.Chamber1Panel, PVD5TPanel).CoronaChamber.SlotxStatus(SlotID) = waferStatus

                End If
                ContainerForm.ProcessPanel.CX_PM1.SetWaferInfo(SlotID, waferStatus, strWaferID, isShowQM)
                ContainerForm.CassettesPanel.CX_PM1.SetWaferInfo(SlotID, waferStatus, strWaferID)
                
            Case ContainerForm.CassettesPanel.CX_PM2.Name
                If ContainerForm.Chamber2Panel.ChamberType = AVPLib.SystemModule.ModuleType.PVD Then
                    CType(ContainerForm.Chamber2Panel, PVDPanel).ChuckControl.bicWaferInside.Visible = True
                    Select Case waferStatus
                        Case AVPLib.ConstEnum.enumWaferStatus.eWaferComplete
                            CType(ContainerForm.Chamber2Panel, PVDPanel).ChuckControl.bicWaferInside.Status = DisplayStatus.Off
                        Case AVPLib.ConstEnum.enumWaferStatus.eWaferError
                            CType(ContainerForm.Chamber2Panel, PVDPanel).ChuckControl.bicWaferInside.Status = DisplayStatus.Error
                        Case AVPLib.ConstEnum.enumWaferStatus.eWaferNew
                            CType(ContainerForm.Chamber2Panel, PVDPanel).ChuckControl.bicWaferInside.Status = DisplayStatus.On
                        Case AVPLib.ConstEnum.enumWaferStatus.eWaferExposed
                            CType(ContainerForm.Chamber2Panel, PVDPanel).ChuckControl.bicWaferInside.Status = DisplayStatus.Unknow
                    End Select
                ElseIf ContainerForm.Chamber2Panel.ChamberType = AVPLib.SystemModule.ModuleType.IBE Then
                    CType(ContainerForm.Chamber2Panel, IBEPanel).SLContainerBox.RotationFixture.WaferID = strWaferID
                    CType(ContainerForm.Chamber2Panel, IBEPanel).SLContainerBox.RotationFixture.WaferStatus = waferStatus

                ElseIf ContainerForm.Chamber2Panel.ChamberType = AVPLib.SystemModule.ModuleType.PVD4 Then
                    CType(ContainerForm.Chamber2Panel, CoronaPanel).CoronaChamber.SlotxWaferID(SlotID) = strWaferID
                    CType(ContainerForm.Chamber2Panel, CoronaPanel).CoronaChamber.SlotxStatus(SlotID) = waferStatus

                ElseIf ContainerForm.Chamber2Panel.ChamberType = AVPLib.SystemModule.ModuleType.PVD5T Then
                    CType(ContainerForm.Chamber2Panel, PVD5TPanel).CoronaChamber.SlotxWaferID(SlotID) = strWaferID
                    CType(ContainerForm.Chamber2Panel, PVD5TPanel).CoronaChamber.SlotxStatus(SlotID) = waferStatus

                End If
                ContainerForm.ProcessPanel.CX_PM2.SetWaferInfo(SlotID, waferStatus, strWaferID, isShowQM)
                ContainerForm.CassettesPanel.CX_PM2.SetWaferInfo(SlotID, waferStatus, strWaferID)
                
            Case ContainerForm.CassettesPanel.CX_PM3.Name
                If ContainerForm.Chamber3Panel.ChamberType = AVPLib.SystemModule.ModuleType.PVD Then
                    CType(ContainerForm.Chamber3Panel, PVDPanel).ChuckControl.bicWaferInside.Visible = True
                    Select Case waferStatus
                        Case AVPLib.ConstEnum.enumWaferStatus.eWaferComplete
                            CType(ContainerForm.Chamber3Panel, PVDPanel).ChuckControl.bicWaferInside.Status = DisplayStatus.Off
                        Case AVPLib.ConstEnum.enumWaferStatus.eWaferError
                            CType(ContainerForm.Chamber3Panel, PVDPanel).ChuckControl.bicWaferInside.Status = DisplayStatus.Error
                        Case AVPLib.ConstEnum.enumWaferStatus.eWaferNew
                            CType(ContainerForm.Chamber3Panel, PVDPanel).ChuckControl.bicWaferInside.Status = DisplayStatus.On
                        Case AVPLib.ConstEnum.enumWaferStatus.eWaferExposed
                            CType(ContainerForm.Chamber3Panel, PVDPanel).ChuckControl.bicWaferInside.Status = DisplayStatus.Unknow
                    End Select
                ElseIf ContainerForm.Chamber3Panel.ChamberType = AVPLib.SystemModule.ModuleType.IBE Then
                    CType(ContainerForm.Chamber3Panel, IBEPanel).SLContainerBox.RotationFixture.WaferID = strWaferID
                    CType(ContainerForm.Chamber3Panel, IBEPanel).SLContainerBox.RotationFixture.WaferStatus = waferStatus

                ElseIf ContainerForm.Chamber3Panel.ChamberType = AVPLib.SystemModule.ModuleType.PVD4 Then
                    CType(ContainerForm.Chamber3Panel, CoronaPanel).CoronaChamber.SlotxWaferID(SlotID) = strWaferID
                    CType(ContainerForm.Chamber3Panel, CoronaPanel).CoronaChamber.SlotxStatus(SlotID) = waferStatus

                ElseIf ContainerForm.Chamber3Panel.ChamberType = AVPLib.SystemModule.ModuleType.PVD5T Then
                    CType(ContainerForm.Chamber3Panel, PVD5TPanel).CoronaChamber.SlotxWaferID(SlotID) = strWaferID
                    CType(ContainerForm.Chamber3Panel, PVD5TPanel).CoronaChamber.SlotxStatus(SlotID) = waferStatus

                End If
                ContainerForm.ProcessPanel.CX_PM3.SetWaferInfo(SlotID, waferStatus, strWaferID, isShowQM)
                ContainerForm.CassettesPanel.CX_PM3.SetWaferInfo(SlotID, waferStatus, strWaferID)
                
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
    Public Sub WaferInChamber_Off(ByVal strWaferInsideChamber As String, Optional ByVal SlotID As Integer = 0)
        Select Case Me.Parent.Name
            Case ContainerForm.CassettesPanel.CX_PM1.Name
                ContainerForm.ProcessPanel.CX_PM1.SetWaferInfo(SlotID, AVPLib.ConstEnum.enumWaferStatus.eWaferNone)
                ContainerForm.CassettesPanel.CX_PM1.SetWaferInfo(SlotID, AVPLib.ConstEnum.enumWaferStatus.eWaferNone)

                If ContainerForm.Chamber1Panel.ChamberType = AVPLib.SystemModule.ModuleType.IBE Then
                    CType(ContainerForm.Chamber1Panel, IBEPanel).SLContainerBox.RotationFixture.WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferNone
                ElseIf ContainerForm.Chamber1Panel.ChamberType = AVPLib.SystemModule.ModuleType.PVD4 Then
                    CType(ContainerForm.Chamber1Panel, CoronaPanel).CoronaChamber.SlotxStatus(SlotID) = AVPLib.ConstEnum.enumWaferStatus.eWaferNone
                ElseIf ContainerForm.Chamber1Panel.ChamberType = AVPLib.SystemModule.ModuleType.PVD5T Then
                    CType(ContainerForm.Chamber1Panel, PVD5TPanel).CoronaChamber.SlotxStatus(SlotID) = AVPLib.ConstEnum.enumWaferStatus.eWaferNone
                End If
            Case ContainerForm.CassettesPanel.CX_PM2.Name
                ContainerForm.ProcessPanel.CX_PM2.SetWaferInfo(SlotID, AVPLib.ConstEnum.enumWaferStatus.eWaferNone)
                ContainerForm.CassettesPanel.CX_PM2.SetWaferInfo(SlotID, AVPLib.ConstEnum.enumWaferStatus.eWaferNone)

                If ContainerForm.Chamber2Panel.ChamberType = AVPLib.SystemModule.ModuleType.IBE Then
                    CType(ContainerForm.Chamber2Panel, IBEPanel).SLContainerBox.RotationFixture.WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferNone
                ElseIf ContainerForm.Chamber2Panel.ChamberType = AVPLib.SystemModule.ModuleType.PVD4 Then
                    CType(ContainerForm.Chamber2Panel, CoronaPanel).CoronaChamber.SlotxStatus(SlotID) = AVPLib.ConstEnum.enumWaferStatus.eWaferNone
                ElseIf ContainerForm.Chamber2Panel.ChamberType = AVPLib.SystemModule.ModuleType.PVD5T Then
                    CType(ContainerForm.Chamber2Panel, PVD5TPanel).CoronaChamber.SlotxStatus(SlotID) = AVPLib.ConstEnum.enumWaferStatus.eWaferNone
                End If
            Case ContainerForm.CassettesPanel.CX_PM3.Name
                ContainerForm.ProcessPanel.CX_PM3.SetWaferInfo(SlotID, AVPLib.ConstEnum.enumWaferStatus.eWaferNone)
                ContainerForm.CassettesPanel.CX_PM3.SetWaferInfo(SlotID, AVPLib.ConstEnum.enumWaferStatus.eWaferNone)

                If ContainerForm.Chamber3Panel.ChamberType = AVPLib.SystemModule.ModuleType.IBE Then
                    CType(ContainerForm.Chamber3Panel, IBEPanel).SLContainerBox.RotationFixture.WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferNone
                ElseIf ContainerForm.Chamber3Panel.ChamberType = AVPLib.SystemModule.ModuleType.PVD4 Then
                    CType(ContainerForm.Chamber3Panel, CoronaPanel).CoronaChamber.SlotxStatus(SlotID) = AVPLib.ConstEnum.enumWaferStatus.eWaferNone
                ElseIf ContainerForm.Chamber3Panel.ChamberType = AVPLib.SystemModule.ModuleType.PVD5T Then
                    CType(ContainerForm.Chamber3Panel, PVD5TPanel).CoronaChamber.SlotxStatus(SlotID) = AVPLib.ConstEnum.enumWaferStatus.eWaferNone
                End If
        End Select

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
