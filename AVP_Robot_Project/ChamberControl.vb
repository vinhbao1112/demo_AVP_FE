Imports System.ComponentModel
Imports System.ComponentModel.Design
Public Class ChamberControl
#Region "Properties"
    Public Property IGCGValue() As String
        Get
            Return txtIG.Text
        End Get
        Set(ByVal value As String)
            txtIG.Text = value
        End Set
    End Property
#End Region
#Region "Protected method"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbRecipe As New StatusTextBox(txtRecipe)
            Dim stbElapsedTime As New StatusTextBox(txtStepNumber)
            Dim stbStepTime As New StatusTextBox(txtStepTime)
            Dim stbProcPressure As New StatusPressureTextBox(txtProcPressure)
            Dim stbStatus As New StatusTextBox(txtStatus)
            Dim sclOnlineChambers As New StatusIGCGButton(Me.Header)
            Dim stbIG As New StatusTextBox(txtIG)
            Dim stbCG As New StatusTextBox(txtCG)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbIG)
            m_stoStatusObject.AddChild(stbCG)
            m_stoStatusObject.AddChild(stbRecipe)
            m_stoStatusObject.AddChild(stbElapsedTime)
            m_stoStatusObject.AddChild(stbStepTime)
            m_stoStatusObject.AddChild(stbProcPressure)
            m_stoStatusObject.AddChild(stbStatus)
            m_stoStatusObject.AddChild(sclOnlineChambers)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Handling control loading event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChamberControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
#End Region
    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-08-27</date>
    ''' </author>
    ''' <summary>
    ''' DisableForm
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EnableDisableForm(ByVal enable As Boolean)
        Try
            Me.Header.Enabled = enable
            Me.Label3.Enabled = enable
            Me.txtRecipe.Enabled = enable
            Me.Label4.Enabled = enable
            Me.txtStepNumber.Enabled = enable
            Me.Label5.Enabled = enable
            Me.txtStepTime.Enabled = enable
            Me.Label2.Enabled = enable
            Me.Label7.Enabled = enable
            Me.txtStatus.Enabled = enable
            Me.Label6.Enabled = enable
            Me.Cursor = IIf(enable, Cursors.Hand, Cursors.Default)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-02-03</date>
    ''' </author>
    ''' <summary>
    ''' txtEtchPressure_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtProcPressure_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcPressure.TextChanged
        AVPLib.Log.guiLogger.Info("Enter txtProcPressure_TextChanged")
        Try
            'Dim text As TextBox = CType(sender, TextBox)
            'text.Text = Utils.SignificantFigures(text.Text)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txtProcPressure_TextChanged")
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        txtStatus.Text = AVPLib.ConstEnum.EnumChamberState.UNKNOWN.ToString()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ChamberControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Header.Click
        Dim strChamberID As String = AVPLib.Utils.chamberName2ChamberID(Me.Tag)
        If String.IsNullOrEmpty(strChamberID) Then
            Exit Sub
        End If
        Dim frmPopUpStatusPanel As Object = Nothing
        Select Case strChamberID
            Case AVPLib.ConstEnum.Equipments.Chamber1.ToString()
                frmPopUpStatusPanel = ContainerForm.ProcessPanel.PM1_PopUpStatusPanel
            Case AVPLib.ConstEnum.Equipments.Chamber2.ToString()
                frmPopUpStatusPanel = ContainerForm.ProcessPanel.PM2_PopUpStatusPanel
            Case AVPLib.ConstEnum.Equipments.Chamber3.ToString()
                frmPopUpStatusPanel = ContainerForm.ProcessPanel.PM3_PopUpStatusPanel
        End Select
        Dim xPos As Integer = System.Windows.Forms.Control.MousePosition.X
        If xPos + frmPopUpStatusPanel.Width > AVPRobotMain.Width Then
            xPos = AVPRobotMain.Width - frmPopUpStatusPanel.Width
        End If
        'Dim chamberConfig As AVPLib.SystemModule = AVPLib.ContainerData.GetRobotConfig(strChamberID)
        'If Not chamberConfig.Type = AVPLib.SystemModule.ModuleType.PVD Then
        '    frmPopUpStatusPanel.ChamberType = chamberConfig.Type
        'End If
        Dim yPos As Integer = System.Windows.Forms.Control.MousePosition.Y
        If yPos + frmPopUpStatusPanel.Height > AVPRobotMain.Height Then
            yPos = AVPRobotMain.Height - frmPopUpStatusPanel.Height
        End If
        frmPopUpStatusPanel.Location = New Point(xPos, yPos) 'System.Windows.Forms.Control.MousePosition.Y)
        frmPopUpStatusPanel.ShowDialog()

    End Sub
End Class
