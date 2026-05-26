Imports System.Windows.Forms

Public Class StatusButton
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_btnButton As Button
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
    Public Property ManagedButton() As Button
        Get
            Return m_btnButton
        End Get
        Set(ByVal value As Button)
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
    Public Sub New(ByVal btnButton As Button)
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
            Dim Value As String = CType(arg, String)
            m_btnButton.Tag = Value

            Dim lpcLoadLock As LockProcessControl = ContainerForm.ProcessPanel.lpcLoadLockA

            If lpcLoadLock.CheckingPermission Then
                m_btnButton.Enabled = True
            End If

            If m_btnButton.Name = "btnAbort" Then
                m_btnButton.Text = UCase(AVPLib.ConstEnum.Abort) 'ABORT
                lpcLoadLock.EnableForm(True)
                ''Update Gem Obj
                AVPLib.Business.AVPSecsGemLib.MySecsGemObj.UpdateProcessState(AVPSecsGemLib.AVPProcessState.IDLE, ConstantAndEnum.LOAD_LOCK_A)

            ElseIf m_btnButton.Name = "btnLoad" Then
                m_btnButton.Text = "LOAD"
                If (Value <> AVPLib.ConstEnum.STR_ON) Then
                    lpcLoadLock.EnableForm(True)
                    lpcLoadLock.FinishLoad()
                End If

            ElseIf m_btnButton.Name = "btnUnload" Then
                If (Value <> AVPLib.ConstEnum.STR_ON) Then
                    m_btnButton.Text = "UNLOAD"
                    lpcLoadLock.EnableForm(True)
                    lpcLoadLock.FinishUnLoad()
                Else ''Unload is running- user didn't click this button ->this button was still disable
                    If AVPLib.ContainerDAO.AutoVentWhenProcessingConpleted() Then
                        m_btnButton.Text = UCase(AVPLib.ConstEnum.Abort) 'ABORT
                        If lpcLoadLock.CheckingPermission Then
                            m_btnButton.Enabled = True
                        End If
                        lpcLoadLock.btnLoad.Enabled = False
                        lpcLoadLock.btnStart.Enabled = False
                    End If
                End If

            ElseIf m_btnButton.Name = "btnUpdateManualTransfer" Then
                If Value = AVPLib.ConstEnum.STR_ON Then
                    lpcLoadLock.btnStart.Enabled = False
                    lpcLoadLock.btnLoad.Enabled = False
                    lpcLoadLock.btnUnload.Enabled = False
                Else
                    lpcLoadLock.EnableForm(True)
                End If

            ElseIf Me.Name = "btnSystemSetupTestingSetup" Then
                ContainerForm.SystemSetup.IsStartTestingSetup = False
                ContainerForm.SystemSetup.EnableDisableButton(True)
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
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
#End Region

End Class
