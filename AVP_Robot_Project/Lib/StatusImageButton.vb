Imports System.Windows.Forms
Public Class StatusImageButton
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_btnButton As Button
    Private m_imageToolOnline As System.Drawing.Image
    Private m_imageToolOffline As System.Drawing.Image
#End Region


#Region "Properties"
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-03-13</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the button that will be managed by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedBButton() As Button
        Get
            Return m_btnButton
        End Get
        Set(ByVal value As Button)
            m_btnButton = value
        End Set
    End Property
   
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-03-13</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the image
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageToolOnline() As Image
        Get
            Return m_imageToolOnline
        End Get
        Set(ByVal value As Image)
            m_imageToolOnline = value
        End Set
    End Property

    Public Property ImageToolOffline() As Image
        Get
            Return m_imageToolOffline
        End Get
        Set(ByVal value As Image)
            m_imageToolOffline = value
        End Set
    End Property

#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-03-13</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with button that will be managed by this object
    ''' </summary>
    ''' <param name="btnButton"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal btnButton As Button)
        Try
            m_btnButton = btnButton
            Me.Name = m_btnButton.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Public Methods"
    Private Delegate Sub UpdateStatus(ByVal sender As Object, ByVal bOnline As Boolean)

    Private Sub UpdateGUI(ByVal sender As Object, ByVal bOnline As Boolean)
        If (bOnline) Then
            m_btnButton.Image = m_imageToolOnline
            m_btnButton.Update()
        Else
            m_btnButton.Image = m_imageToolOffline
            m_btnButton.Update()
        End If
    End Sub

    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''     <date> 2009-03-13</date>
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
        Try
            Select Case Value
                Case "ONLINE"
                    If (m_imageToolOnline IsNot Nothing) Then

                        m_btnButton.BeginInvoke(New UpdateStatus(AddressOf UpdateGUI), New Object() {m_btnButton, True})
                        'm_btnButton.Image = m_imageToolOnline
                        'm_btnButton.Update()
                    End If
                Case "OFFLINE"
                    If (m_imageToolOffline IsNot Nothing) Then
                        m_btnButton.BeginInvoke(New UpdateStatus(AddressOf UpdateGUI), New Object() {m_btnButton, False})
                        'm_btnButton.Image = m_imageToolOffline
                        'm_btnButton.Update()
                    End If
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
    ''' <author>
    '''     	<name> Tran Ngoc Khiet </name>
    '''     	<date> 2009-03-13</date>
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
