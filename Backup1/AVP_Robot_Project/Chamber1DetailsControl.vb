Imports System.ComponentModel
Imports System.ComponentModel.Design
Public Class Chamber1DetailsControl
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
            Dim stbElapsedTime As New StatusTextBox(txtStepNumber)
            Dim stbSEtchPower As New StatusTextBox(txtDepPower)
            Dim stbCheckHeigh As New StatusPressureTextBox(txtCheckHeigh)
            Dim stbEtchPressure As New StatusTextBox(txtProcPressure)
            Dim stbStepTime As New StatusTextBox(txtStepTime)
            Dim stbStatus As New StatusTextBox(txtStatus)
            Dim sclOnlineChamber1Details As New StatusIGCGButton(Me.Header)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbRecipe)
            m_stoStatusObject.AddChild(stbElapsedTime)
            m_stoStatusObject.AddChild(stbSEtchPower)
            m_stoStatusObject.AddChild(stbCheckHeigh)
            m_stoStatusObject.AddChild(stbEtchPressure)
            m_stoStatusObject.AddChild(stbStepTime)
            m_stoStatusObject.AddChild(stbStatus)
            m_stoStatusObject.AddChild(sclOnlineChamber1Details)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

    '#Region "Events – Buttons – Forms…"
    '    ''' <author>
    '    '''    	<name> Ngo Cao Dinh </name>
    '    '''    	<date> 2008-08-25</date>
    '    ''' </author>
    '    ''' <summary>
    '    ''' Handling control loading event
    '    ''' </summary>
    '    ''' <param name="sender"></param>
    '    ''' <param name="e"></param>
    '    ''' <remarks></remarks>
    '    Private Sub ChamberControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    End Sub
    '#End Region
   
End Class
