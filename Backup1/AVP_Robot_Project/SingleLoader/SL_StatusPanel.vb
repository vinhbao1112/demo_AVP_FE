Public Class SL_StatusPanel
#Region "Properties"
#End Region
#Region "Protected method"
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-09-07</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbMotionInitialized As New SL_StatusButton(btnMotionInitialized)
            Dim stbFlowcoolGas As New SL_StatusButton(btnFlowcoolGas)
            Dim stbProcessGas As New SL_StatusButton(btnProcessGas)
            Dim stbIonBeam As New SL_StatusButton(btnIonBeam)
            Dim stbNeutralizer As New SL_StatusButton(btnNeutralizer)

            Dim stbStepTime As New SL_StatusTextBox(Me.txtStepTime)
            Dim stbElapsedTime As New SL_StatusTextBox(Me.txtElapsedTime)
            Dim stbRemainingTime As New SL_StatusTextBox(Me.txtRemainingTime)
            Dim stbStatus As New SL_StatusTextBox(Me.txtStatus)
            Dim stbEPDRecipe As New SL_StatusTextBox(Me.txtEPDRecipe)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbMotionInitialized)
            m_stoStatusObject.AddChild(stbFlowcoolGas)
            m_stoStatusObject.AddChild(stbProcessGas)
            m_stoStatusObject.AddChild(stbIonBeam)
            m_stoStatusObject.AddChild(stbNeutralizer)
            m_stoStatusObject.AddChild(stbStepTime)
            m_stoStatusObject.AddChild(stbElapsedTime)
            m_stoStatusObject.AddChild(stbRemainingTime)
            m_stoStatusObject.AddChild(stbStatus)
            m_stoStatusObject.AddChild(stbEPDRecipe)

            txtStepTime.ParentStatusObj = m_stoStatusObject
            txtRemainingTime.ParentStatusObj = m_stoStatusObject
            txtElapsedTime.ParentStatusObj = m_stoStatusObject
            txtStatus.ParentStatusObj = m_stoStatusObject
            txtEPDRecipe.ParentStatusObj = m_stoStatusObject

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
#Region "Events – Buttons – Forms…"
#End Region
#Region "Public methods"
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
        txtStepTime.Text = String.Empty
        txtElapsedTime.Text = String.Empty
        txtRemainingTime.Text = String.Empty

        btnMotionInitialized.Status = SL_CustomButton.DisplayStatus.Off
        btnFlowcoolGas.Status = SL_CustomButton.DisplayStatus.Off
        btnIonBeam.Status = SL_CustomButton.DisplayStatus.Off
        btnNeutralizer.Status = SL_CustomButton.DisplayStatus.Off
        btnProcessGas.Status = SL_CustomButton.DisplayStatus.Off
    End Sub
#End Region

    Private Sub btnMotionInitialized_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMotionInitialized.StatusChange
        If DesignMode Or AVPLib.System_Init_Indicator.IsMainFormInitialize = False Then
            Exit Sub
        End If
        Try
            Select Case Me.Parent.Name
                Case AVPLib.ConstEnum.Equipments.Chamber1.ToString()
                    If btnMotionInitialized.Status = SL_CustomButton.DisplayStatus.Unknow Then
                        ContainerForm.ProcessPanel.lblPM1MotionInitialize.Visible = True
                        ContainerForm.CassettesPanel.lblPM1MotionInitialize.Visible = True
                    Else
                        ContainerForm.ProcessPanel.lblPM1MotionInitialize.Visible = False
                        ContainerForm.CassettesPanel.lblPM1MotionInitialize.Visible = False
                    End If

                Case AVPLib.ConstEnum.Equipments.Chamber2.ToString()
                    If btnMotionInitialized.Status = SL_CustomButton.DisplayStatus.Unknow Then
                        ContainerForm.ProcessPanel.lblPM2MotionInitialize.Visible = True
                        ContainerForm.CassettesPanel.lblPM2MotionInitialize.Visible = True
                    Else
                        ContainerForm.ProcessPanel.lblPM2MotionInitialize.Visible = False
                        ContainerForm.CassettesPanel.lblPM2MotionInitialize.Visible = False
                    End If

                Case AVPLib.ConstEnum.Equipments.Chamber3.ToString()
                    If btnMotionInitialized.Status = SL_CustomButton.DisplayStatus.Unknow Then
                        ContainerForm.ProcessPanel.lblPM3MotionInitialize.Visible = True
                        ContainerForm.CassettesPanel.lblPM3MotionInitialize.Visible = True
                    Else
                        ContainerForm.ProcessPanel.lblPM3MotionInitialize.Visible = False
                        ContainerForm.CassettesPanel.lblPM3MotionInitialize.Visible = False
                    End If
            End Select

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2016-10-05</date>
    ''' <summary>
    ''' Set tooltip for recipe name when text longer than textbox width.
    ''' </summary>
    Private Sub txtEPDRecipe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEPDRecipe.TextChanged
        Try
            Dim toolTipText As String = String.Empty
            Dim sizeText As SizeF = TextRenderer.MeasureText(txtEPDRecipe.Text, txtEPDRecipe.Font)
            If txtEPDRecipe.Width < sizeText.Width Then
                toolTipText = txtEPDRecipe.Text
            End If
            screenToolTip.SetToolTip(txtEPDRecipe, toolTipText)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

End Class
