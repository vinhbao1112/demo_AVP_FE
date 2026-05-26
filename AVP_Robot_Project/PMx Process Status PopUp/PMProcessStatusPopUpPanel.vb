Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Public Class PMProcessStatusPopUpPanel
    Private m_iClosingTime As Integer = 30
    Private m_StartTimeOpen As Long
    Private m_timer As System.Timers.Timer
    Private m_TimerClosingForm As System.Timers.Timer
    Private m_ANCinstall As Boolean = False

#Region "Properties"
    Public Property PMRotationMode() As String
        Get
            Return txtRotatonMode.Text
        End Get
        Set(ByVal value As String)
            txtRotatonMode.Text = value
        End Set
    End Property

    Public Property PopUpTitle() As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = AVPLib.Utils.chamberID2ChamberName(value) & " Process Status"
        End Set
    End Property
#End Region

#Region "Private methods"
    Protected Overrides Function CheckPermission() As Boolean
        Try
            Return AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_001)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function

    Protected Overrides Sub CreateStatusTree()
        Try
            m_stoStatusObject.Name = Me.Name
            For Each ctrl As Control In tableContainer.Controls
                If ctrl.GetType().Name = "SL_Textbox" Then
                    Dim sTextbox As New StatusPopUpProcessTextBox(CType(ctrl, SL_Textbox))
                    m_stoStatusObject.AddChild(sTextbox)
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_timer = New System.Timers.Timer
        m_timer.Interval = 1000 '1second
        m_timer.Enabled = False
        m_timer.SynchronizingObject = Me
        AddHandler m_timer.Elapsed, AddressOf TimerClosingForm
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Events"
    Private Sub TimerClosingForm(ByVal source As Object, ByVal e As Timers.ElapsedEventArgs)
        m_iClosingTime -= 1
        If m_iClosingTime <= 0 Then
            m_timer.Interval = 100
            Me.Opacity -= 0.1
            If Me.Opacity <= 0 Then
                m_timer.Enabled = False
                Me.Close()
            End If
        End If
    End Sub

    Private Sub PMProcessStatusPopUpPanel_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        m_timer.Enabled = False
        Me.Close()
    End Sub

    Private Sub PMProcessStatusPopUpPanel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            m_timer.Enabled = False
            Me.Close()
        End If
    End Sub

    Private Sub PMProcessStatusPopUpPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_timer.Enabled = True
        Me.Opacity = 1
        m_iClosingTime = 30
        m_timer.Interval = 1000
    End Sub

    Private Sub lblTitle_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HeaderDoubleClick
        m_timer.Enabled = False
        Me.Close()
    End Sub

#End Region

    Private Sub PMProcessStatusPopUpPanel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus, Me.Leave
        m_timer.Enabled = False
        Me.Close()
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-01-25</date>
    ''' </author>
    ''' <summary>
    ''' Action on close when click outside of the window.
    ''' </summary>
    Protected Overrides Sub DoClose()
        m_timer.Enabled = False
        Me.Close()
    End Sub

End Class


'Imports AVP_Robot_Project.ConstantAndEnum
'Imports AVPLib.ConstEnum
'Imports AVPLib
'Imports AVPControls

'Public Class PMProcessStatusPopUpPanel
'    Private m_iClosingTime As Integer = 30
'    Private m_StartTimeOpen As Long
'    Private m_timer As System.Timers.Timer
'    Private m_TimerClosingForm As System.Timers.Timer
'    Private m_ChamberType As AVPLib.SystemModule.ModuleType = AVPLib.SystemModule.ModuleType.PVD4
'    Private m_IsTarget_DC As Boolean = False

'#Region "Properties"
'    Public Property PMRotationMode() As String
'        Get
'            Return txtRotatonMode.Text
'        End Get
'        Set(ByVal value As String)
'            txtRotatonMode.Text = value
'        End Set
'    End Property

'    Public Property PopUpTitle() As String
'        Get
'            Return Me.Text
'        End Get
'        Set(ByVal value As String)
'            Me.Text = AVPLib.Utils.chamberID2ChamberName(value) & " Process Status"
'        End Set
'    End Property

'    Public Property ChamberType() As AVPLib.SystemModule.ModuleType
'        Get
'            Return m_ChamberType
'        End Get
'        Set(ByVal value As AVPLib.SystemModule.ModuleType)
'            m_ChamberType = value
'            UpdatePanel()
'        End Set
'    End Property

'    ''' <author>
'    '''    	<name> Hoai Ly </name>
'    '''    	<date> 2015-07-14</date>
'    ''' </author>
'    ''' <summary>
'    ''' Set is Target_DC install property
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public WriteOnly Property IsTarget_DC() As Boolean
'        Set(ByVal value As Boolean)
'            m_IsTarget_DC = value
'        End Set
'    End Property

'#End Region

'#Region "Private methods"
'    Protected Overrides Function CheckPermission() As Boolean
'        Try
'            Return AVPLib.ContainerData.Permission(AVPLib.ConstEnum.PERMISSION_001)
'        Catch ex As Exception
'            AVPLib.Log.avpLogger.Error(ex.ToString())
'        End Try
'    End Function

'    Protected Overrides Sub CreateStatusTree()
'        Try
'            m_stoStatusObject.Name = Me.Name
'            For Each ctrl As Control In tableContainer.Controls
'                If ctrl.GetType().Name = "SL_Textbox" Then
'                    Dim sTextbox As New StatusPopUpProcessTextBox(CType(ctrl, SL_Textbox))
'                    m_stoStatusObject.AddChild(sTextbox)
'                End If
'            Next
'            For Each ctrl As Control In tbCorona.Controls
'                If ctrl.GetType().Name = "SL_Textbox" Then
'                    Dim sTextbox As New StatusPopUpProcessTextBox(CType(ctrl, SL_Textbox))
'                    m_stoStatusObject.AddChild(sTextbox)
'                End If
'            Next
'        Catch ex As Exception
'            AVPLib.Log.avpLogger.Error(ex.ToString())
'        End Try
'    End Sub

'    Private Sub UpdatePanel()
'        Try
'            Select Case m_ChamberType
'                Case SystemModule.ModuleType.PVD4
'                    tableContainer.Visible = False
'                    tbCorona.Width = 298
'                    tbCorona.ColumnStyles(0).Width = 146
'                    tbCorona.ColumnStyles(1).Width = 65
'                    tbCorona.ColumnStyles(2).Width = 65
'                    Me.Size = New Size(308, 457)
'                    If m_IsTarget_DC Then
'                        Me.Label5.Text = "Target Current (A)"
'                    End If
'                Case Else
'                    tbCorona.Visible = False
'                    tableContainer.ColumnStyles(0).Width = 100
'                    tableContainer.ColumnStyles(1).Width = 65
'                    tableContainer.ColumnStyles(2).Width = 65
'                    Me.Size = New Size(285, 567)
'            End Select
'        Catch ex As Exception
'            AVPLib.Log.avpLogger.Error(ex.ToString())
'        End Try
'    End Sub
'#End Region

'    Public Sub New()

'        ' This call is required by the Windows Form Designer.
'        InitializeComponent()
'        m_timer = New System.Timers.Timer
'        m_timer.Interval = 1000 '1second
'        m_timer.Enabled = False
'        m_timer.SynchronizingObject = Me
'        AddHandler m_timer.Elapsed, AddressOf TimerClosingForm
'        ' Add any initialization after the InitializeComponent() call.
'    End Sub

'#Region "Events"
'    Private Sub TimerClosingForm(ByVal source As Object, ByVal e As Timers.ElapsedEventArgs)
'        m_iClosingTime -= 1
'        If m_iClosingTime <= 0 Then
'            m_timer.Interval = 100
'            Me.Opacity -= 0.1
'            If Me.Opacity <= 0 Then
'                Me.DoClose()
'            End If
'        End If
'    End Sub

'    Private Sub PMProcessStatusPopUpPanel_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
'        m_timer.Enabled = False
'        Me.Close()
'    End Sub

'    Private Sub PMProcessStatusPopUpPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
'        m_timer.Enabled = True
'        Me.Opacity = 1
'        m_iClosingTime = 30
'        m_timer.Interval = 1000
'    End Sub

'    Private Sub PMProcessStatusPopUpPanel_HeaderDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HeaderDoubleClick
'        Me.DoClose()
'    End Sub

'    Protected Overrides Sub DoClose()
'        m_timer.Enabled = False
'        Me.Close()
'    End Sub

'#End Region


'    Private Sub PMProcessStatusPopUpPanel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus, Me.Leave
'        Me.DoClose()
'    End Sub
'End Class
