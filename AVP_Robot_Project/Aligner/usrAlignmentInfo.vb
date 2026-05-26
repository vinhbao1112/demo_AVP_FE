Imports AVP_Robot_Project.ConstantAndEnum
Imports System.ComponentModel
Imports System.ComponentModel.Design
Public Class usrAlignmentInfo
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
            Dim stbEccentricityAngle As New StatusTextBox(txtEccentricityAngle)
            Dim stbEccentricityMagnitude As New StatusTextBox(txtEccentricityMagnitude)
            Dim stbDeltaR As New StatusTextBox(txtDeltaR)
            Dim stbDataT As New StatusTextBox(txtDeltaT)
            Dim stbFiducialAngle As New StatusTextBox(txtFiducialAngle)
            Dim stbRescanNeeded As New StatusTextBox(txtRescanNeeded)
            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbEccentricityAngle)
            m_stoStatusObject.AddChild(stbEccentricityMagnitude)
            m_stoStatusObject.AddChild(stbDeltaR)
            m_stoStatusObject.AddChild(stbDataT)
            m_stoStatusObject.AddChild(stbFiducialAngle)
            m_stoStatusObject.AddChild(stbRescanNeeded)
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
        txtRescanNeeded.Text = ""
    End Sub
#End Region

End Class
