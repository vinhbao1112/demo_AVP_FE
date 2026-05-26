Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Imports AVPLib

Public Class TurboStatusButton
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_btnButton As SL_CustomButton
    Private m_strIsTurboOn As String = "False"
    Private m_strUptoSpeedRelaySwitch As String = "False"
    Private m_strRampingPercent As String = String.Empty
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
    Public Property ManagedButton() As SL_CustomButton
        Get
            Return m_btnButton
        End Get
        Set(ByVal value As SL_CustomButton)
            m_btnButton = value
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
    ''' <param name="btnButton"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal btnButton As SL_CustomButton)
        Try
            m_btnButton = btnButton
            Me.Name = btnButton.Name
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
            Dim bIsTurboOn As Boolean = CBool(m_strIsTurboOn)
            Dim bIsUptoSpeedRelaySwitch As Boolean = CBool(m_strUptoSpeedRelaySwitch)
            If bIsTurboOn AndAlso bIsUptoSpeedRelaySwitch Then
                m_btnButton.Status = SL_CustomButton.DisplayStatus.On
            ElseIf Not bIsTurboOn AndAlso Not bIsUptoSpeedRelaySwitch Then
                m_btnButton.Status = SL_CustomButton.DisplayStatus.Off
            Else
                m_btnButton.Status = SL_CustomButton.DisplayStatus.Unknow
                
                If (m_strRampingPercent = String.Empty) OrElse Me.Name = "btnTurboLLA" OrElse Me.Name = "btnTurboTM" Then
                    m_btnButton.Text = "Ramp"
                Else
                    m_btnButton.Text = m_strRampingPercent
                End If
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
        If Identification.Contains("TurboStatus.") Then
            m_strIsTurboOn = Value
        ElseIf Identification.Contains("TurboUptoSpeed.") Then
            m_strUptoSpeedRelaySwitch = Value
        ElseIf Identification.Contains("RampingPercent.") Then
            m_strRampingPercent = String.Format("{0:0%}", Convert.ToDouble(Value) / 100)
        End If

        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub

#End Region

End Class
