Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum
Public Class StatusRobot
    Inherits AVPControls.StatusObject
#Region "Class Constants & Variables"
	Private m_rbtRobot As Robot
#End Region

#Region "Properties"
	''' <author>
	'''    	<name> Ngo Cao Dinh </name>
	'''    	<date> 2008-09-19</date>
	''' </author>
	''' <summary>
	''' Get or set the robot that will be managed by this object
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property ManagedRobot() As Robot
		Get
			Return m_rbtRobot
		End Get
		Set(ByVal value As Robot)
			m_rbtRobot = value
		End Set
	End Property
#End Region

#Region "Construtor and Destructor"
	''' <author>
	'''    	<name> Ngo Cao Dinh </name>
	'''    	<date> 2008-09-19</date>
	''' </author>
	''' <summary>
	''' Initalize with robot that will be managed by this object
	''' </summary>
	''' <param name="rbtRobot"></param>
	''' <remarks></remarks>
    Public Sub New(ByVal rbtRobot As Robot)
        Try
            m_rbtRobot = rbtRobot
            Me.Name = m_rbtRobot.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Public Methods"

    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim strValue As String = CType(arg, String)

            Dim valueArr() As String = Split(strValue, " ")
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

            '''we have 2 robot: 1 in AVPLib, 1 in AVPProject
            '''in AVPLib: we control Delta Pick, WaferInside, Communicate...
            '''in AVPProject: we control Image of Robot Hand...
            '''if user click Delete or Create Wafer in Robot Arm-> it will send ON/OFF to change status Image of Robot Hand
            '''we only change image, we don't change the position of Robot
            'Dat Cao
            '[Khoi Ha 05-02-2013]Ext/Re/Up/Down should be in yellow state  when robot is not communicating.
            Dim rRobot As AVPLib.DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
            If rRobot Is Nothing Then
                Exit Sub
            End If

            m_rbtRobot.RotateTo(rRobot.CurrentPosition)

            If (rRobot.IsCommunicating) Then
                If (rRobot.ExternRetractStatus = AVPLib.ConstEnum.RobotEXREStatus.UNKNOWN) Then
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.btnEXStatus.Status = DisplayStatus.Unknow
                    ContainerForm.CassettesPanel.atwAutoTransferWafer.btnREStatus.Status = DisplayStatus.Unknow
                Else
                    If (rRobot.IsRetracted AndAlso rRobot.IsReallyRetracted) Then
                        'retracted
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnEXStatus.Status = DisplayStatus.Off
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnREStatus.Status = DisplayStatus.On
                        m_rbtRobot.Hands.ArmStatus = AVPControls.AVPDataLib.ArmStatuses.Retract
                    ElseIf (rRobot.IsRetracted And Not rRobot.IsReallyRetracted) Then
                        'unknown
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnEXStatus.Status = DisplayStatus.Unknow
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnREStatus.Status = DisplayStatus.Unknow
                    Else
                        'extend
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnEXStatus.Status = DisplayStatus.On
                        ContainerForm.CassettesPanel.atwAutoTransferWafer.btnREStatus.Status = DisplayStatus.Off
                        m_rbtRobot.Hands.ArmStatus = AVPControls.AVPDataLib.ArmStatuses.Extend
                    End If
                End If

            Else
                'unknown
                ContainerForm.CassettesPanel.atwAutoTransferWafer.btnEXStatus.Status = DisplayStatus.Unknow
                ContainerForm.CassettesPanel.atwAutoTransferWafer.btnREStatus.Status = DisplayStatus.Unknow
            End If

            Dim isShowQM As Boolean
            If rRobot.GetWaferInfo() IsNot Nothing Then
                m_rbtRobot.WaferStatus = rRobot.GetWaferInfo().WaferStatus
                m_rbtRobot.WaferID = rRobot.GetWaferInfo().WaferID
                isShowQM = Utils.Check_WaferID_Has_PausedJob(rRobot.GetWaferInfo().WaferID)
            Else
                m_rbtRobot.WaferStatus = Nothing
                m_rbtRobot.WaferID = String.Empty
            End If

            If m_rbtRobot.Hands.InScreen = AVPControls.AVPDataLib.AVPScreens.ProcessScreen Then
                m_rbtRobot.Hands.ShowQuestionMarkOnWafer = isShowQM
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub ConvertFrom_RealPos_WithWafer(ByVal rRobot As AVPLib.DataManagerment.Robot)
        Try
            Select Case rRobot.CurrentPosition 'Retract Position with Wafer
                Case AVPLib.ConstEnum.Positions.LoadLockA
                    m_rbtRobot.RotateTo(AVPLib.ConstEnum.Positions.Arm_At_LLA_Wafer)
                Case AVPLib.ConstEnum.Positions.Chamber1
                    m_rbtRobot.RotateTo(AVPLib.ConstEnum.Positions.Arm_At_Chamber1_Wafer)
                Case AVPLib.ConstEnum.Positions.Chamber2
                    m_rbtRobot.RotateTo(AVPLib.ConstEnum.Positions.Arm_At_Chamber2_Wafer)
                Case AVPLib.ConstEnum.Positions.Chamber3
                    m_rbtRobot.RotateTo(AVPLib.ConstEnum.Positions.Arm_At_Chamber3_Wafer)
                       'Extract Position with Wafer
                Case AVPLib.ConstEnum.Positions.Arm_At_LLA_Extract
                    m_rbtRobot.RotateTo(AVPLib.ConstEnum.Positions.Arm_At_LLA_Wafer_Extract)
                 Case AVPLib.ConstEnum.Positions.Arm_At_Chamber1_Extract
                    m_rbtRobot.RotateTo(AVPLib.ConstEnum.Positions.Arm_At_Chamber1_Wafer_Extract)
                Case AVPLib.ConstEnum.Positions.Arm_At_Chamber2_Extract
                    m_rbtRobot.RotateTo(AVPLib.ConstEnum.Positions.Arm_At_Chamber2_Wafer_Extract)
                Case AVPLib.ConstEnum.Positions.Arm_At_Chamber3_Extract
                    m_rbtRobot.RotateTo(AVPLib.ConstEnum.Positions.Arm_At_Chamber3_Wafer_Extract)
                Case AVPLib.ConstEnum.Positions.Original
                    m_rbtRobot.RotateTo(AVPLib.ConstEnum.Positions.Robot_Wafer)
                Case AVPLib.ConstEnum.Positions.Robot_Wafer
                    m_rbtRobot.RotateTo(AVPLib.ConstEnum.Positions.Robot_Wafer)
                Case AVPLib.ConstEnum.Positions.Aligner_Extract, Positions.Aligner_Extract_DeltaPick
                    m_rbtRobot.RotateTo(AVPLib.ConstEnum.Positions.Arm_At_Aligner_Wafer_Extract)
                Case Positions.Arm_At_Aligner_Retract, Positions.Arm_At_Aligner_Retract_DeltaPick
                    m_rbtRobot.RotateTo(AVPLib.ConstEnum.Positions.Arm_At_Aligner_Retract_with_Wafer)
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-19</date>
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
    '''     	<date> 2008-09-19</date>
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
