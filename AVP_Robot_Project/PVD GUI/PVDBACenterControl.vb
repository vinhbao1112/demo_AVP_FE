Imports AVP_Robot_Project.ConstantAndEnum
Public Class PVDBACenterControl
    Public Event PressureCG_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Private m_blnIsOnline As Boolean = False
#Region "Properties & Constant"
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            txtCG2.Enabled = Not m_blnIsOnline
            bigcgIG.Enabled = Not m_blnIsOnline
        End Set
    End Property
#End Region
#Region "Protected method"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-15</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbIG As New StatusPVD_IGCGTextBox(Me.txtIG)
            Dim stbBA As New StatusTextBox(Me.txtBA)
            Dim stbCG1 As New StatusPVD_IGCGTextBox(Me.txtCG1)
            Dim stbCG2 As New StatusPVD_IGCGTextBox(Me.txtCG2)
            Dim sibIG As New StatusIGCGButton(Me.bigcgIG)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbIG)
            m_stoStatusObject.AddChild(stbBA)
            m_stoStatusObject.AddChild(stbCG1)
            m_stoStatusObject.AddChild(stbCG2)
            m_stoStatusObject.AddChild(sibIG)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
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
        Me.txtCG2.Text = String.Empty
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Handling Click TextBox CG2
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtCG2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCG2.Click
        PVDSupport.TextboxClick(sender, e, Me.Parent, m_stoStatusObject)
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Handling Click TextBox CG2
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bigcgIG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bigcgIG.Click
        Dim strLogMessage As String = String.Empty

        If CType(sender, ButtonIGCGControl).Status = DisplayStatus.On Then
            strLogMessage = "Turn off IG"
        Else
            strLogMessage = "Turn On IG"
        End If
        PVDSupport.CommonButtonClick(strLogMessage, sender, Me.Parent, m_stoStatusObject)
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Handling status IG of PVD
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bigcgIG_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles bigcgIG.StatusChange
        If Me.Parent Is Nothing Then
            Exit Sub
        End If
        Dim chamberName As String = Me.Parent.Name
        If bigcgIG.Status = DisplayStatus.On Then
            Utils.UpdateIGCGValue(txtIG.Text, chamberName)
        ElseIf bigcgIG.Status = DisplayStatus.Off Then
            Utils.UpdateIGCGValue(txtCG1.Text, chamberName)
        End If
    End Sub

    Private Sub txtCG1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCG1.Click
        If Not IsOnline Then
            RaiseEvent PressureCG_Click(sender, e)
        End If
    End Sub
#End Region

End Class
