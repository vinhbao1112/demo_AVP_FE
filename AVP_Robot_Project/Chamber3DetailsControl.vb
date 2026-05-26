Imports System.ComponentModel
Imports System.ComponentModel.Design
Public Class Chamber3DetailsControl
#Region "Properties"
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
            Dim stbGas1Argon As New StatusTextBox(txtGas1Argon)
            Dim stbGas2O2 As New StatusTextBox(txtGas2O2)
            Dim stbDepPressure As New StatusPressureTextBox(txtDepPressure)
            Dim stbTargetPower As New StatusTextBox(txtTargetPower)
            Dim stbSourcePower As New StatusTextBox(txtSourcePower)
            Dim stbRatationSpeed As New StatusTextBox(txtRatationSpeed)
            Dim stbTiltAngle As New StatusTextBox(txtTiltAngle)
            Dim stbProcessStep As New StatusTextBox(txtProcessStep)
            Dim stbStepTime As New StatusTextBox(txtStepTime)
            Dim stbStatus As New StatusTextBox(txtStatus)
            Dim sclOnlineChamber3Details As New StatusIGCGButton(Me.Header)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbRecipe)
            m_stoStatusObject.AddChild(stbGas1Argon)
            m_stoStatusObject.AddChild(stbGas2O2)
            m_stoStatusObject.AddChild(stbDepPressure)
            m_stoStatusObject.AddChild(stbTargetPower)
            m_stoStatusObject.AddChild(stbSourcePower)
            m_stoStatusObject.AddChild(stbRatationSpeed)
            m_stoStatusObject.AddChild(stbTiltAngle)
            m_stoStatusObject.AddChild(stbProcessStep)
            m_stoStatusObject.AddChild(stbStepTime)
            m_stoStatusObject.AddChild(stbStatus)
            m_stoStatusObject.AddChild(sclOnlineChamber3Details)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Events – Buttons – Forms…"
#End Region
End Class
