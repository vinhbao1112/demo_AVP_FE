Public Class SL_FixturePro

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
            Dim stbRotating As New SL_StatusTextBox(Me.txtRotating)
            Dim stbTiltAngle As New SL_StatusTextBox(Me.txtTiltAngle)
            Dim stbClampped As New SL_StatusTextBox(Me.txtClampped)
            Dim stbMotionInitialized As New SL_StatusButton(btnMotionInitialized)
            Dim stbFlowcoolGas As New SL_StatusButton(btnFlowcoolGas)
            Dim stbProcessGas As New SL_StatusButton(btnProcessGas)
            Dim stbIonBeam As New SL_StatusButton(btnIonBeam)
            Dim stbNeutralizer As New SL_StatusButton(btnNeutralizer)
            Dim sbtRotatingStatus As New SL_StatusButton(btnRotating)
            Dim stbStepTime As New SL_StatusTextBox(Me.txtStepTime)
            Dim stbElapsedTime As New SL_StatusTextBox(Me.txtElapsedTime)
            Dim stbRemainingTime As New SL_StatusTextBox(Me.txtRemainingTime)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbRotating)
            m_stoStatusObject.AddChild(stbTiltAngle)
            m_stoStatusObject.AddChild(stbClampped)
            m_stoStatusObject.AddChild(stbMotionInitialized)
            m_stoStatusObject.AddChild(stbFlowcoolGas)
            m_stoStatusObject.AddChild(stbProcessGas)
            m_stoStatusObject.AddChild(stbIonBeam)
            m_stoStatusObject.AddChild(stbNeutralizer)
            m_stoStatusObject.AddChild(sbtRotatingStatus)
            m_stoStatusObject.AddChild(stbStepTime)
            m_stoStatusObject.AddChild(stbElapsedTime)
            m_stoStatusObject.AddChild(stbRemainingTime)

            txtRotating.ParentStatusObj = m_stoStatusObject
            txtTiltAngle.ParentStatusObj = m_stoStatusObject
            txtClampped.ParentStatusObj = m_stoStatusObject
            btnFlowcoolGas.ParentStatusObj = m_stoStatusObject
            btnIonBeam.ParentStatusObj = m_stoStatusObject
            btnMotionInitialized.ParentStatusObj = m_stoStatusObject
            btnNeutralizer.ParentStatusObj = m_stoStatusObject
            btnProcessGas.ParentStatusObj = m_stoStatusObject
            btnRotating.ParentStatusObj = m_stoStatusObject
            txtStepTime.ParentStatusObj = m_stoStatusObject
            txtRemainingTime.ParentStatusObj = m_stoStatusObject
            txtElapsedTime.ParentStatusObj = m_stoStatusObject
            ''m_stoStatusObject.AddChild () 'add all textbox and button in this panel
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.HeaderVisible = True
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-22-23</date>
    ''' </author>
    ''' <summary>
    ''' Set default status to show on GUI when PM disconnect.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaultStatus()
        'All textbox
        txtTiltAngle.Text = String.Empty
        txtClampped.Text = String.Empty
        txtStepTime.Text = String.Empty
        txtElapsedTime.Text = String.Empty
        txtRemainingTime.Text = String.Empty

        btnMotionInitialized.Status = SL_CustomButton.DisplayStatus.Off
        btnFlowcoolGas.Status = SL_CustomButton.DisplayStatus.Off
        btnIonBeam.Status = SL_CustomButton.DisplayStatus.Off
        btnNeutralizer.Status = SL_CustomButton.DisplayStatus.Off
        btnProcessGas.Status = SL_CustomButton.DisplayStatus.Off
        btnRotating.Status = SL_CustomButton.DisplayStatus.Off
    End Sub

End Class
