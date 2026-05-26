Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports AVP_Robot_Project.ConstantAndEnum
Public Class PVD5TCryoControl
#Region "Class Constants & Variables"
    Public Enum DisplayStyle
        [Left] = 0
        [Right] = 1
    End Enum

    Public Enum PVDCryoStyle
        [Vertical] = 0
        [Horizontal] = 1
    End Enum

    Private m_intDisplayStyle As DisplayStyle
    Private m_intCryoStyle As PVDCryoStyle
    Private m_blnButtonVisible As Boolean
    Private Const STRING_OFF As String = "Off"
    Private Const STRING_ON As String = "On"
    ' Private m_blnIsOnline As Boolean = False
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

    Public Property CryoStyle() As PVDCryoStyle
        Get
            Return m_intCryoStyle
        End Get
        Set(ByVal value As PVDCryoStyle)
            Try
                m_intCryoStyle = value
                If (value = PVDCryoStyle.Vertical) Then
                    Me.BackgroundImage = My.Resources.PVD_Cryo1_Panel
                    Me.Size = New Size(125, 126)
                    btnRegen.Size = New Size(97, 27)
                    txtT2.Size = New Size(68, 24)
                    txtT1.Size = New Size(68, 24)
                    btnCryoCommucation.Size = New Size(97, 23)

                    btnCryoCommucation.Location = New Point(13, 21)
                    Label2.Location = New Point(9, 47)
                    Label3.Location = New Point(9, 75)
                    txtT1.Location = New Point(42, 45)
                    txtT2.Location = New Point(42, 71)
                    btnRegen.Location = New Point(13, 97)
                Else

                    Me.BackgroundImage = My.Resources.PVD_Cryo_Panel
                    Me.Size = New Size(120, 125)
                    btnRegen.Size = New Size(58, 27)
                    txtT2.Size = New Size(58, 24)
                    txtT1.Size = New Size(58, 24)
                    btnCryoCommucation.Size = New Size(78, 23)
                    btnRegen.Location = New Point(44, 90)
                    btnCryoCommucation.Location = New Point(24, 12)
                    Label2.Location = New Point(20, 42)
                    txtT2.Location = New Point(44, 64)
                    Label3.Location = New Point(20, 67)
                    txtT1.Location = New Point(44, 37)
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
        Header.Cursor = Cursors.Hand
        ' Add any initialization after the InitializeComponent() call.
        m_intDisplayStyle = DisplayStyle.Left
        AddHandler Header.Click, AddressOf Header_Click
        txtT1.Cursor = Cursors.Hand
        txtT2.Cursor = Cursors.Hand
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
            Dim scbCommunication As New StatusIGCGButton(Me.Header)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbT1)
            m_stoStatusObject.AddChild(stbT2)
            m_stoStatusObject.AddChild(scbCommunication)
            
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Friend Overrides Sub Header_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click, txtT1.Click, txtT2.Click, Label3.Click, Label2.Click, btnRegen.Click, btnCryoCommucation.Click
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                If Me.Parent IsNot Nothing Then
                    Dim objPVD5TPanel As PVD5TPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                    objPVD5TPanel.CryoPopUpPanel.StartPosition = FormStartPosition.CenterScreen
                    objPVD5TPanel.CryoPopUpPanel.ShowDialog(AVPRobotMain)
                End If
            End If
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
    '''    	<name> Dy Do </name>
    '''    	<date> 2016-22-06</date>
    ''' </author>
    ''' <summary>
    ''' show cryo communication
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PVD5TCryoControl_HeaderStatusChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.HeaderStatusChanged
        Try
            btnCryoCommucation.Status = Header.Status
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
