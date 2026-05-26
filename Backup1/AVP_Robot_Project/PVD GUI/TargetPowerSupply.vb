Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Public Class TargetPowerSupply
    Private m_blnIsOnline As Boolean = False
    Private m_blnMagnatronInstalled As Boolean = False
#Region "Properties"
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            txtTargetCurrentRight.Enabled = Not m_blnIsOnline
            txtTargetPowerRight.Enabled = Not m_blnIsOnline
            txtTargetVoltageRight.Enabled = Not m_blnIsOnline
            txtRampTimeRight.Enabled = Not m_blnIsOnline
            bicDCPulse.Enabled = Not m_blnIsOnline
            btnRotationStart.Enabled = Not m_blnIsOnline
        End Set
    End Property
    Public Property MagnatronInstalled() As Boolean
        Get
            Return m_blnMagnatronInstalled
        End Get
        Set(ByVal value As Boolean)
            m_blnMagnatronInstalled = value
            lblMagnatron.Visible = value
            txtMagnatronStatus.Visible = value
            btnRotationStart.Visible = value
            If value = False Then
                lblDCPulse.Top = lblMagnatron.Top
                txtTargetDCPulse.Top = txtMagnatronStatus.Top
                bicDCPulse.Top = btnRotationStart.Top
            End If
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
            Dim stbTargetPower As New StatusTextBox(Me.txtTargetPower)
            Dim stbTargetPowerRight As New StatusTextBox(Me.txtTargetPowerRight)

            Dim stbTargetVoltage As New StatusTextBox(Me.txtTargetVoltage)
            Dim stbTargetVoltageRight As New StatusTextBox(Me.txtTargetVoltageRight)

            Dim stbRampTime As New StatusTextBox(Me.txtRampTime)
            Dim stbRampTimeRight As New StatusTextBox(Me.txtRampTimeRight)

            Dim stbTargetCurrent As New StatusTextBox(Me.txtTargetCurrent)
            Dim stbKWH As New StatusTextBox(Me.txtKWH)
            Dim stbTargetCurrentRight As New StatusTextBox(Me.txtTargetCurrentRight)

            Dim stbTargetDCPulse As New StatusTextBox(Me.txtTargetDCPulse)
            Dim stbTargetDCPulseStatus As New StatusIGCGButton(Me.bicDCPulse)
            Dim sbcRotating As New StatusIGCGButton(Me.bicRotating)
            Dim sbcRotationStart As New StatusIGCGButton(Me.btnRotationStart)
            Dim sbcStatus As New StatusIGCGButton(Me.Header)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(sbcRotating)
            m_stoStatusObject.AddChild(sbcRotationStart)
            m_stoStatusObject.AddChild(stbTargetPower)
            m_stoStatusObject.AddChild(stbTargetPowerRight)
            m_stoStatusObject.AddChild(stbTargetVoltage)
            m_stoStatusObject.AddChild(stbTargetVoltageRight)
            m_stoStatusObject.AddChild(stbTargetCurrent)
            m_stoStatusObject.AddChild(stbTargetCurrentRight)
            m_stoStatusObject.AddChild(stbRampTime)
            m_stoStatusObject.AddChild(stbRampTimeRight)
            m_stoStatusObject.AddChild(stbTargetDCPulse)
            m_stoStatusObject.AddChild(stbTargetDCPulseStatus)
            m_stoStatusObject.AddChild(sbcStatus)
            m_stoStatusObject.AddChild(stbKWH)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    Private Sub txtTargetPowerRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTargetPowerRight.Click, _
                                 txtTargetVoltageRight.Click, txtTargetCurrentRight.Click, txtRampTimeRight.Click
        PVDSupport.TextboxClick(sender, e, Me.Parent, m_stoStatusObject)
    End Sub
#End Region


    Private Sub bicDCPulse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bicDCPulse.Click
        PVDSupport.CommonButtonClick("Target PS Pulse", sender, Me.Parent, m_stoStatusObject)
    End Sub
  ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub StartProcessing() ''reset editbox to empty
        Me.txtTargetCurrentRight.Text = String.Empty
        Me.txtTargetPowerRight.Text = String.Empty
        Me.txtTargetVoltageRight.Text = String.Empty
       
    End Sub

    Private Sub btnRotationStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotationStart.Click
        Dim strLogMessage As String = String.Empty
        If CType(sender, ButtonIGCGControl).Status = DisplayStatus.On Then
            strLogMessage = "Stop Magnetron Station"
        Else
            strLogMessage = "Start Magnetron Rotation"
        End If
        PVDSupport.CommonButtonClick(strLogMessage, sender, Me.Parent, m_stoStatusObject)
    End Sub

    Private Sub bicRotating_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bicRotating.StatusChange
        Try
            If bicRotating.Status = DisplayStatus.On Then
                Me.txtMagnatronStatus.Text = "Rotating"
            Else
                Me.txtMagnatronStatus.Text = String.Empty
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
