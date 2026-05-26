Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum

Public Class SL_StatusRobot
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

            m_rbtRobot.WaferID = strWaferID

            '''we have 2 robot: 1 in AVPLib, 1 in AVPProject
            '''in AVPLib: we control Delta Pick, WaferInside, Communicate...
            '''in AVPProject: we control Image of Robot Hand...
            '''if user click Delete or Create Wafer in Robot Arm-> it will send ON/OFF to change status Image of Robot Hand
            '''we only change image, we don't change the position of Robot
            If strOnOff = STR_OFF Then
                ' ContainerForm.SLProcessPanel.SLRobotHand.Refresh()
            ElseIf strOnOff = STR_ON Then
            End If

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
