Public Class SL_IGCGControl
    Public Event PressureCG_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event SwitchIGFilament_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event SwitchIGFilament_EnableChange(ByVal sender As Object, ByVal e As System.EventArgs)

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
            
            Dim stbIGStatus As New StatusIBE_IGCGTextBox(txtIG)
            Dim stbCGStatus As New StatusIBE_IGCGTextBox(txtCG)
            Dim stbEnableFilament As New StatusIBE_IGCGTextBox(txtEnableIGFilament)

            Dim stbSwitchIGFilament As New StatusIBE_IGCGTextBox(txtSwitchIGFilament)

            m_stoStatusObject.Name = Me.Name
          
            m_stoStatusObject.AddChild(stbIGStatus)
            m_stoStatusObject.AddChild(stbCGStatus)
            m_stoStatusObject.AddChild(stbSwitchIGFilament)
            m_stoStatusObject.AddChild(stbEnableFilament)

            'Add parent for textbox
            txtIG.ParentStatusObj = m_stoStatusObject
            txtCG.ParentStatusObj = m_stoStatusObject
            txtSwitchIGFilament.ParentStatusObj = m_stoStatusObject
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

    Private Sub txtIG_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIG.TextChanged
        RaiseEvent PressureCG_StatusChange(sender, e)
    End Sub

    Private Sub txtSwitchIGFilament_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSwitchIGFilament.TextChanged
        RaiseEvent SwitchIGFilament_StatusChange(sender, e)
    End Sub

    Private Sub txtEnableIGFilament_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEnableIGFilament.TextChanged
        RaiseEvent SwitchIGFilament_EnableChange(sender, e)
    End Sub
End Class
