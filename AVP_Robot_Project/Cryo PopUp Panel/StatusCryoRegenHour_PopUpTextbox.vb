Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib

Public Class StatusCryoRegenHour_PopUpTextbox
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_txtTextBox As SL_Textbox
    Private m_blnPostAlarm As Boolean = False
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
            Dim dblValue As Double = 0

            If Double.TryParse(arg.ToString(), dblValue) Then
                ''System needs to post alarm "Cryo pump hour is over 720 hours.  Need regen." if cryo hour is over 720 hrs.
                If (dblValue > AVPLib.RobotConfigurationValues.CRYO_REGEN_HOURS_LIMIT) AndAlso m_blnPostAlarm = False Then
                    Dim strPMName As String = String.Empty
                    If m_txtTextBox.Tag = CASSETTESPANEL_STR Then
                        strPMName = ConstEnum.TM_STR
                    ElseIf m_txtTextBox.Tag = LOAD_LOCK_A Then
                        strPMName = ConstEnum.LLA_STR
                    Else
                        strPMName = AVPLib.Utils.chamberID2ChamberName(m_txtTextBox.Tag)
                    End If

                    AVPLib.Utils.ThrowAlarm(strPMName & " - Cryo pump hour is over " & _
                                            AVPLib.RobotConfigurationValues.CRYO_REGEN_HOURS_LIMIT.ToString() & " hours.  Need regen.", AVPLib.Utils.GemGetAlarmName(strPMName))
                    m_blnPostAlarm = True

                ElseIf (dblValue <= 720) Then
                    ''reset 
                    m_blnPostAlarm = False
                End If

                m_txtTextBox.Text = dblValue.ToString()
            End If

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

