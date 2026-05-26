Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Imports AVPLib

Public Class StatusCustomizeButton
    Inherits AVPControls.StatusObject

    Protected m_handlerButton As SL_CustomButton

#Region "Properties"
    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-25 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set the button that will be manage by this object
    ''' </summary>
    Public Property HandlerButton() As SL_CustomButton
        Get
            Return m_handlerButton
        End Get
        Set(ByVal value As SL_CustomButton)
            m_handlerButton = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-25 </date>
    ''' </author>
    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New(ByVal handlerButton As SL_CustomButton)
        Try
            m_handlerButton = handlerButton
            Me.Name = m_handlerButton.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-25 </date>
    ''' </author>
    ''' <summary>
    ''' Update display
    ''' </summary>
    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            Select Case Value
                Case STR_ON, Boolean.TrueString
                    m_handlerButton.Status = SL_CustomButton.DisplayStatus.On

                Case STR_OFF, Boolean.FalseString
                    m_handlerButton.Status = SL_CustomButton.DisplayStatus.Off

                Case UNKNOWN
                    m_handlerButton.Status = SL_CustomButton.DisplayStatus.Unknow

                Case STR_ERROR
                    m_handlerButton.Status = SL_CustomButton.DisplayStatus.Error
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''     <date> 2015-06-25 </date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub

#End Region

End Class
