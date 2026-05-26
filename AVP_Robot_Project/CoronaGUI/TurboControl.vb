Imports AVPLib
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports AVP_Robot_Project.ConstantAndEnum
Public Class TurboControl
#Region "Class Constants & Variables"
    
    Private Const STRING_OFF As String = "Off"
    Private Const STRING_ON As String = "On"
    
    Private m_blnIsOnline As Boolean = False
#End Region

#Region "Public Properties"

    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            'btnHome.Enabled = Not m_blnIsOnline
            btnTurbo.Enabled = Not m_blnIsOnline
            btnForeline.Enabled = Not m_blnIsOnline
        End Set
    End Property

    Public Property Title() As String
        Get
            Return lblHeader.Text
        End Get
        Set(ByVal value As String)
            lblHeader.Text = value
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
        '  m_blnButtonVisible = btnOn.Visible
        ' m_intDisplayStyle = DisplayStyle.Left
        Me.Header.OffImage = Global.AVP_Robot_Project.My.Resources.Resources.HeaderPanel_Red
    End Sub
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            MyBase.CreateStatusTree()
            m_stoStatusObject.RemoveChild(btnComStatus.Name)
            m_stoStatusObject.RemoveChild(btnRelay.Name)
            m_stoStatusObject.RemoveChild(lblPressure.Name)
            m_stoStatusObject.RemoveChild(btnTurbo.Name)
            m_stoStatusObject.RemoveChild(btnForeline.Name)

            Dim sbtComStatus As New StatusIGCGButton(btnComStatus)
            Dim sbcCGRelay As New StatusTurboRelayIndicator(btnRelay)
            Dim stsTurboPressure As New StatusPressureLabel(lblPressure)
            Dim scbTurbo As New StatusCustomizeButton(btnTurbo)
            Dim scbForeline As New StatusCustomizeButton(btnForeline)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(sbtComStatus)
            m_stoStatusObject.AddChild(sbcCGRelay)
            m_stoStatusObject.AddChild(stsTurboPressure)
            m_stoStatusObject.AddChild(scbTurbo)
            m_stoStatusObject.AddChild(scbForeline)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Private Methods"

#End Region

#Region "Events – Buttons – Forms…"
    Private Sub TM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not (AVPLib.System_Init_Indicator.IsMainFormInitialize) Then
                Exit Sub
            End If
            Dim TM As AVPLib.DataManagerment.CassettesModule = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.CassettesModule.ToString())


            ' Me.btnHome.Visible = False
            'Me.HivacOpenButton.Top = HivacCloseButton.Top
            'Me.HivacCloseButton.Top = 62
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
        Utils.PaintBorder(sender, e)
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-24 </date>
    ''' </author>
    ''' <summary>
    ''' Active/Inactive controls in form
    ''' </summary>
    Public Sub ActiveForm(ByVal isEnabled As Boolean)
        btnComStatus.Enabled = isEnabled
        btnRelay.Enabled = isEnabled
        btnTurbo.Enabled = isEnabled
        btnForeline.Enabled = isEnabled
        pnlHeader.Enabled = isEnabled
    End Sub
#End Region

    Private Sub lblPressure_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPressure.TextChanged
        Try
            lblPressure.ForeColor = IIf(lblPressure.Text = ConstEnum.STR_ERROR, Color.Red, Color.Lime)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
