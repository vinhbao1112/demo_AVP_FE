Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports AVP_Robot_Project.ConstantAndEnum
Public Class SL_CryoControl
#Region "Class Constants & Variables"
    Public Enum DisplayStyle
        [Left] = 0
        [Right] = 1
    End Enum

    Private m_intDisplayStyle As DisplayStyle
    Private m_blnButtonVisible As Boolean
    Private Const STRING_OFF As String = "Off"
    Private Const STRING_ON As String = "On"
#End Region

#Region "Public Properties"
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
            Dim stbT1 As New SL_StatusTextBox(txtT1)
            Dim stbT2 As New SL_StatusTextBox(txtT2)
            Dim scbRegen As New StatusIGCGButton(Me.btnRegen)
            Dim scbCommunication As New StatusIGCGButton(Me.Header)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbT1)
            m_stoStatusObject.AddChild(stbT2)
            m_stoStatusObject.AddChild(scbRegen)
            m_stoStatusObject.AddChild(scbCommunication)

            txtT1.ParentStatusObj = m_stoStatusObject
            txtT2.ParentStatusObj = m_stoStatusObject

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
    Private Sub txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        If CType(sender, SL_CustomButton).Status = SL_CustomButton.DisplayStatus.On Then
            strLogMessage = "Abort Cryo Regen"
        Else
            strLogMessage = "Start Cryo Regen"
        End If
        PVDSupport.CommonButtonClick(strLogMessage, sender, Me.Parent, m_stoStatusObject)
    End Sub

    Private Sub txtT1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtT1.Click, txtT2.Click, Me.Click
        If String.IsNullOrEmpty(Me.Parent.Name) = False Then
            Dim objIBEPanel As IBEPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
            objIBEPanel.CryoPopUpPanel.ShowDialog(AVPRobotMain)
        End If
    End Sub
End Class
