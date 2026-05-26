Public Class CORONA_Pressure

    Public Event PressureCG_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event StatusIGChanged(ByVal status As Boolean)

    Private m_blnIsOnline As Boolean = False
    Private m_blnEnableButtonIGOnOff As Boolean = True
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            btnIGStatus.Enabled = Not (m_blnIsOnline) And m_blnEnableButtonIGOnOff
            txtPressure.Cursor = IIf(m_blnIsOnline, Cursors.Default, Cursors.Hand)
        End Set
    End Property

    Protected Overrides Sub CreateStatusTree()
        Try
            MyBase.CreateStatusTree()
            m_stoStatusObject.RemoveChild(txtPressure.Name)
            m_stoStatusObject.RemoveChild(txtCGPressure.Name)
            m_stoStatusObject.RemoveChild(txtIGPressure.Name)
            Dim stbPressureStatus As New StatuscoronaPressure(txtPressure)
            Dim stbCGPressureStatus As New StatuscoronaPressure(txtCGPressure)
            Dim stbIGPressureStatus As New StatuscoronaPressure(txtIGPressure)
            m_stoStatusObject.AddChild(stbPressureStatus)
            m_stoStatusObject.AddChild(stbCGPressureStatus)
            m_stoStatusObject.AddChild(stbIGPressureStatus)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub txtIGPressure_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIGPressure.TextChanged, txtCGPressure.TextChanged
        Try
            UpdatePressure()
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                Utils.UpdateIGCGValue(txtPressure.Text, Me.Parent.Name)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Public Sub UpdatePressure()
        Try
            Dim value As String = String.Empty
            value = IIf(btnIGStatus.Status = DisplayStatus.On, txtIGPressure.Text, txtCGPressure.Text)
            txtPressure.Text = value
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private Sub txtPressure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPressure.Click
        If Not IsOnline Then
            RaiseEvent PressureCG_Click(sender, e)
        End If
    End Sub

    ''' <author>Dua Tran</author>
    ''' <date>2018-04-11</date>
    ''' <summary>
    ''' EnableButtonIGOnOff
    ''' </summary>
    Public Sub EnableButtonIGOnOff(ByVal isEnable As Boolean)
        m_blnEnableButtonIGOnOff = isEnable
        btnIGStatus.Enabled = Not (m_blnIsOnline) And m_blnEnableButtonIGOnOff
    End Sub

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-07-03</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.txtPressure.Cursor = Cursors.Hand
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btnIGStatus_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIGStatus.StatusChange
        UpdatePressure()
        If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
            txtPressure.Text = IIf(btnIGStatus.Status = SL_CustomButton.DisplayStatus.On, txtIGPressure.Text, txtCGPressure.Text)
            Utils.UpdateIGCGValue(txtPressure.Text, Me.Parent.Name)
            RaiseEvent StatusIGChanged(IIf(btnIGStatus.Status = SL_CustomButton.DisplayStatus.On, True, False))
        End If
    End Sub
End Class
