Imports AVP_Robot_Project.ConstantAndEnum
Public Class usrWaferInfo
#Region "Protected method"
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-27</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbRecipe As New StatusTextBox(txtRecipe)
            Dim stbWaferID As New StatusTextBox(txtWaferID)
            Dim stbAlignAngle As New StatusTextBox(txtAlignAngle)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbRecipe)
            m_stoStatusObject.AddChild(stbWaferID)
            m_stoStatusObject.AddChild(stbAlignAngle)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub ClearInfo()
        txtRecipe.Text = String.Empty
        txtAlignAngle.Text = String.Empty
    End Sub
#End Region

    Private Sub txtWaferID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWaferID.TextChanged
        If AVPLib.System_Init_Indicator.IsMainFormInitialize = False Then
            Exit Sub
        End If

        If (txtWaferID.Text = "") Then 'Aligner is Empry
            'keep aligner info--> do nothing
        Else
            'clear old wafer info
            ClearInfo()
            ContainerForm.CassettesPanel.TMAlignerControl.ClearInfo()
            'ContainerForm.Aligner.usrOperations.Enable_Disable_Action(True)
        End If
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-01-29</date>
    ''' </author>
    ''' <summary>
    ''' Update align angle to cassette & process screens.
    ''' </summary>
    Private Sub txtAlignAngle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAlignAngle.TextChanged
        If AVPLib.System_Init_Indicator.IsMainFormInitialize = False Then
            Exit Sub
        End If

        Try
            If String.IsNullOrEmpty(txtAlignAngle.Text) Then
                ContainerForm.CassettesPanel.lblAlignAngle.Visible = False
                ContainerForm.ProcessPanel.lblAlignAngle.Visible = False
            Else
                Const ALIGN_ANGLE As String = "Align = {0}"
                ContainerForm.CassettesPanel.lblAlignAngle.Text = String.Format(ALIGN_ANGLE, txtAlignAngle.Text)
                ContainerForm.CassettesPanel.lblAlignAngle.Visible = True

                ContainerForm.ProcessPanel.lblAlignAngle.Text = String.Format(ALIGN_ANGLE, txtAlignAngle.Text)
                ContainerForm.ProcessPanel.lblAlignAngle.Visible = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
End Class
