Imports AVPLib
Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum
Imports System.Text.RegularExpressions

Public Class AlignerControl
#Region "Protected method"
    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2018-12-18</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbEccentricityAngle As New StatusTextBox(txtEccentricityAngle)
            Dim stbEccentricityMagnitude As New StatusTextBox(txtEccentricityMagnitude)
            Dim stbDeltaR As New StatusTextBox(txtDeltaR)
            Dim stbDataT As New StatusTextBox(txtDeltaT)
            Dim stbFiducialAngle As New StatusTextBox(txtFiducialAngle)
            Dim sclToolLED As New StatusIGCGButton(btnToolLED)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbEccentricityAngle)
            m_stoStatusObject.AddChild(stbEccentricityMagnitude)
            m_stoStatusObject.AddChild(stbDeltaR)
            m_stoStatusObject.AddChild(stbDataT)
            m_stoStatusObject.AddChild(stbFiducialAngle)
            m_stoStatusObject.AddChild(usrOperations.Status)
            m_stoStatusObject.AddChild(sclToolLED)
            m_stoStatusObject.AddChild(usrWaferInfo.Status)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub ClearInfo()
        txtEccentricityAngle.Text = ""
        txtEccentricityMagnitude.Text = ""
        txtDeltaR.Text = ""
        txtDeltaT.Text = ""
        txtFiducialAngle.Text = ""
    End Sub
#End Region
#Region "Private methods"
    ''' <author>
    '''    	<name>Dy Do </name>
    '''    	<date> 2018-12-18</date>
    ''' </author>
    ''' <summary>
    ''' txtEccentricityMagnitude_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub txtEccentricityMagnitude_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEccentricityMagnitude.TextChanged
        Try
            If txtEccentricityMagnitude.Text <> String.Empty Then
                With ContainerForm.CassettesPanel.lblAlignerEECM
                    .Visible = True
                    .Text = "Ecc. M = " & txtEccentricityMagnitude.Text
                End With
                With ContainerForm.ProcessPanel.lblAlignerEECM
                    .Visible = True
                    .Text = "Ecc. M = " & txtEccentricityMagnitude.Text
                End With
            Else
                ContainerForm.CassettesPanel.lblAlignerEECM.Visible = False
                ContainerForm.ProcessPanel.lblAlignerEECM.Visible = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name>Dy Do </name>
    '''    	<date> 2018-12-18</date>
    ''' </author>
    ''' <summary>
    ''' txtEccentricityAngle_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks> 
    Private Sub txtEccentricityAngle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEccentricityAngle.TextChanged
        Try
            If txtEccentricityAngle.Text <> String.Empty Then
                With ContainerForm.CassettesPanel.lblAlignerEECA
                    .Visible = True
                    .Text = "Ecc. A = " & txtEccentricityAngle.Text
                End With
                With ContainerForm.ProcessPanel.lblAlignerEECA
                    .Visible = True
                    .Text = "Ecc. A = " & txtEccentricityAngle.Text
                End With
            Else
                ContainerForm.CassettesPanel.lblAlignerEECA.Visible = False
                ContainerForm.ProcessPanel.lblAlignerEECA.Visible = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

End Class

