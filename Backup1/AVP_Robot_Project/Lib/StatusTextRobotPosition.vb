Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib

Public Class StatusTextRobotPosition
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
            Const STATION As String = "Station "
            Select Case Value
                Case ConstEnum.Positions.Arm_At_Chamber1_Extract.ToString(), ConstEnum.Positions.Chamber1.ToString()
                    Value = STATION & RobotConfigurationValues.PM1_STATION_NO

                Case ConstEnum.Positions.Arm_At_Chamber2_Extract.ToString(), ConstEnum.Positions.Chamber2.ToString()
                    Value = STATION & RobotConfigurationValues.PM2_STATION_NO

                Case ConstEnum.Positions.Arm_At_Chamber3_Extract.ToString(), ConstEnum.Positions.Chamber3.ToString()
                    Value = STATION & RobotConfigurationValues.PM3_STATION_NO

                Case ConstEnum.Positions.Aligner_Extract.ToString(), ConstEnum.Positions.Arm_At_Aligner_Retract.ToString()
                    Value = STATION & RobotConfigurationValues.ALIGNER_STATION_NO

                Case ConstEnum.Positions.Aligner_Extract_DeltaPick.ToString(), ConstEnum.Positions.Arm_At_Aligner_Retract_DeltaPick.ToString()
                    Value = STATION & RobotConfigurationValues.ALIGNER_DELTA_PICK_STATION_NO

                Case ConstEnum.Positions.LoadLockA.ToString(), ConstEnum.Positions.Arm_At_LLA_Extract.ToString()
                    Value = STATION & RobotConfigurationValues.LLA_STATION_NO
            End Select
            m_txtTextBox.Text = Value
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
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateGUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
#End Region
End Class
