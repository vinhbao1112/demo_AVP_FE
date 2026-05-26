Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports AVP_Robot_Project.ConstantAndEnum
Public Class PVDCryoControl
#Region "Class Constants & Variables"
    Public Enum DisplayStyle
        [Left] = 0
        [Right] = 1
    End Enum

    Private m_intDisplayStyle As DisplayStyle
    Private m_blnButtonVisible As Boolean
    Private Const STRING_OFF As String = "Off"
    Private Const STRING_ON As String = "On"
    Private m_blnIsOnline As Boolean = False
#End Region

#Region "Public Properties"
    ''' <author>
    '''    	<name> Hoa Nguyen</name>
    '''    	<date> 2011-05-19</date>
    ''' </author>    
    ''' <summary>
    ''' Get or set value to online/offline
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            btnRegen.Enabled = Not m_blnIsOnline
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>    
    ''' <summary>
    ''' Get or set value to align all child controls inside this user control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AlignStyle() As DisplayStyle
        Get
            AlignStyle = m_intDisplayStyle
        End Get
        Set(ByVal value As DisplayStyle)
            Try
                If (value <> m_intDisplayStyle) Then
                    m_intDisplayStyle = value
                    ' Me.PositionControls()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-28</date>
    ''' </author>    
    ''' <summary>
    ''' Get or set value to align all child controls inside this user control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ButtonVisible() As Boolean
        Get
            Return m_blnButtonVisible
        End Get
        Set(ByVal value As Boolean)
            Try
                If (value <> m_blnButtonVisible) Then
                    m_blnButtonVisible = value
                    'Me.PositionControls()
                    'btnOn.Visible = m_blnButtonVisible
                    'btnRegen.Visible = m_blnButtonVisible
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
#End Region

#Region "Constructor & Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Initiate cryo control
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_intDisplayStyle = DisplayStyle.Left
    End Sub
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-15</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbT1 As New StatusTextBox(txtT1)
            Dim stbT2 As New StatusTextBox(txtT2)
            Dim scbRegen As New StatusIGCGButton(Me.btnRegen)
            Dim scbCommunication As New StatusIGCGButton(Me.Header)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbT1)
            m_stoStatusObject.AddChild(stbT2)
            m_stoStatusObject.AddChild(scbRegen)
            m_stoStatusObject.AddChild(scbCommunication)
            
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region



    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' txt_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT2.TextChanged, txtT1.TextChanged
        AVPLib.Log.guiLogger.Info("Enter txt_TextChanged")
        Try
            Dim text As TextBox = CType(sender, TextBox)
            If Not text.Text.Contains("K") Then
                text.Text = Utils.SignificantFigures(text.Text)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txt_TextChanged")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-07-02</date>
    ''' </author>
    ''' <summary>
    ''' btnRegen_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRegen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles btnRegen.Click
        Dim strLogMessage As String = String.Empty
        If Utils.CheckHivacValveOpen_BeforeCryo(Me.Parent.Name) Then
            Exit Sub
        End If
        If CType(sender, ButtonIGCGControl).Status = DisplayStatus.On Then
            strLogMessage = "Abort Cryo Regen"
        Else
            strLogMessage = "Start Cryo Regen"
        End If
        PVDSupport.CommonButtonClick(strLogMessage, sender, Me.Parent, m_stoStatusObject)
    End Sub

    Private Sub PVDCryoControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click, txtT1.Click, txtT2.Click
        Try
            If String.IsNullOrEmpty(Me.Parent.Name) = False Then
                Dim objPVDPanel As PVDPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                objPVDPanel.CryoPopUpPanel.StartPosition = FormStartPosition.CenterScreen
                objPVDPanel.CryoPopUpPanel.ShowDialog(AVPRobotMain)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
