Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPControls

Public Class SerenPopUp
    Public Enum PowerSupplyType
        BiasPowerSupply
        RFTargetPowerSupply
    End Enum
    Private m_blnIsCoilPowerSupply As Boolean = True
    Private m_lstSpecialType_PowerSupply As List(Of String) = Nothing
    Private m_strParentName As String = String.Empty
    Private m_ParentPower As PVDStatusBoard = Nothing
    Public Event TextboxClick(ByVal sender As Object, ByVal e As EventArgs)
    Public Event AutoButtonClick(ByVal sender As Object, ByVal e As EventArgs)
    Private m_strChamberName As String = String.Empty
#Region "Properties"
    Public Property ChamberName() As String
        Get
            Return m_strChamberName
        End Get
        Set(ByVal value As String)
            m_strChamberName = value
            If IsBiasPowerSupply Then
                Me.Text = "Bias Power Supply"
                txtForwardPowerRight.SourceOfMessageBox = value & ".PVD4.BiasPowerSupply"
                txtC1Right.SourceOfMessageBox = value & ".PVD4.BiasPowerSupply"
                txtC2Right.SourceOfMessageBox = value & ".PVD4.BiasPowerSupply"
            Else
                Me.Text = "Target Power Supply"
                txtForwardPowerRight.SourceOfMessageBox = value & ".PVD4.TargetPowerSupply"
                txtC1Right.SourceOfMessageBox = value & ".PVD4.TargetPowerSupply"
                txtC2Right.SourceOfMessageBox = value & ".PVD4.TargetPowerSupply"
            End If
        End Set
    End Property

    Public Overrides Property IsOnline() As Boolean
        Get
            Return MyBase.IsOnline
        End Get
        Set(ByVal value As Boolean)
            MyBase.IsOnline = value
            txtForwardPowerRight.Enabled = (Not MyBase.IsOnline)
            txtC1Right.Enabled = Not MyBase.IsOnline
            txtC2Right.Enabled = Not MyBase.IsOnline
            btnAuto.Enabled = Not MyBase.IsOnline
        End Set
    End Property

    Private m_blnIsBiasPowerSupply As Boolean = True
    Public Property IsBiasPowerSupply() As Boolean
        Get
            Return m_blnIsBiasPowerSupply
        End Get
        Set(ByVal value As Boolean)
            m_blnIsBiasPowerSupply = value
        End Set
    End Property

    Public Property ParentName() As String
        Get
            Return m_strParentName
        End Get
        Set(ByVal value As String)
            m_strParentName = value
        End Set
    End Property

#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbForwardPower As New StatusTextBox(Me.txtForwardPower)
            Dim stbForwardPowerRight As New StatusTextBox(Me.txtForwardPowerRight)
            Dim stbReflectedPower As New StatusTextBox(Me.txtReflectedPower)
            Dim stbVoltage As New StatusTextBox(Me.txtVoltage)
            Dim stbMag As New StatusTextBox(Me.txtMag)
            Dim stbPhase As New StatusTextBox(Me.txtPhase)
            Dim stbP2P As New StatusTextBox(Me.txtPeak2Peak)
            Dim stbDCBias As New StatusTextBox(Me.txtDCBias)
            Dim stbC1 As New StatusTextBox(Me.txtC1)
            Dim stbC1Right As New StatusTextBox(Me.txtC1Right)
            Dim stbC2 As New StatusTextBox(Me.txtC2)
            Dim stbC2Right As New StatusTextBox(Me.txtC2Right)
            Dim stbMatch As New StatusTextBox(Me.txtMatch)
            Dim sbcAuto As New StatusCoronaButton(Me.btnAuto)
            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbDCBias)
            m_stoStatusObject.AddChild(stbP2P)
            m_stoStatusObject.AddChild(sbcAuto)
            m_stoStatusObject.AddChild(stbForwardPower)
            m_stoStatusObject.AddChild(stbForwardPowerRight)
            m_stoStatusObject.AddChild(stbReflectedPower)
            m_stoStatusObject.AddChild(stbVoltage)
            m_stoStatusObject.AddChild(stbC1)
            m_stoStatusObject.AddChild(stbC1Right)
            m_stoStatusObject.AddChild(stbC2)
            m_stoStatusObject.AddChild(stbC2Right)
            m_stoStatusObject.AddChild(stbMatch)
            m_stoStatusObject.AddChild(stbMag)
            m_stoStatusObject.AddChild(stbPhase)
            txtC2Right.ParentStatusObj = m_stoStatusObject
            txtC1Right.ParentStatusObj = m_stoStatusObject
            txtForwardPowerRight.ParentStatusObj = m_stoStatusObject
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    Private Sub txtTargetPowerRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtForwardPowerRight.Click, _
                                                                  txtC1Right.Click, txtC2Right.Click, txtErrorMessageTemp.Click
        Try
            RaiseEvent TextboxClick(sender, e)
            Dim TextBox As System.Windows.Forms.TextBox = CType(sender, System.Windows.Forms.TextBox)
            Dim ctrol As Control() = m_ParentPower.Controls.Find(TextBox.Name.ToString(), True)
            If ctrol IsNot Nothing AndAlso ctrol.Length = 1 Then
                Dim textbox1 As System.Windows.Forms.TextBox = CType(ctrol(0), System.Windows.Forms.TextBox)
                textbox1.Text = TextBox.Text
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    Private Sub btnAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuto.Click
        Try
            RaiseEvent AutoButtonClick(sender, e)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub StartProcessing() ''reset editbox to empty
        Me.txtForwardPowerRight.Text = String.Empty
        Me.txtC1Right.Text = String.Empty
        Me.txtC2Right.Text = String.Empty
    End Sub

    Private Sub txtMatch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtMatch.Text = "Auto" Then
            Me.txtC2Right.Enabled = False
            Me.txtC1Right.Enabled = False
        Else
            Me.txtC2Right.Enabled = True
            Me.txtC1Right.Enabled = True
        End If
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_lstSpecialType_PowerSupply = New List(Of String)
    End Sub

    Public Sub New(ByVal Parent As PVDStatusBoard)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        m_ParentPower = Parent
        ' Add any initialization after the InitializeComponent() call.
        m_lstSpecialType_PowerSupply = New List(Of String)


    End Sub

#End Region

End Class