Public Class ProcessRecipeControl

#Region "Properties"
    Private m_RecipeName As String
    Private m_Chamber As String
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19 </date>
    ''' </author>
    ''' <summary>
    ''' Property of Chamber
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RecipeName() As String
        Get
            Return m_RecipeName
        End Get
        Set(ByVal value As String)
            m_RecipeName = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19 </date>
    ''' </author>
    ''' <summary>
    ''' Property of Chamber
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Chamber() As String
        Get
            Return m_Chamber
        End Get
        Set(ByVal value As String)
            m_Chamber = value
        End Set
    End Property
#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19 </date>
    ''' </author>
    ''' <summary>
    ''' Handling Recipe Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtRecipe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecipe.Click
        AVPLib.Log.guiLogger.Info("Enter txtRecipe_Click")
        Try
            Dim frm As SelectRecipe = New SelectRecipe()
            frm.StationName = Chamber
            frm.ShowDialog()
            If frm.DialogResult = DialogResult.OK Then
                Me.Chamber = frm.StationName
                Me.RecipeName = frm.SelectedRecipe
                Me.txtRecipe.Text = frm.SelectedRecipe + "(" + AVPLib.Utils.chamberID2ChamberName(frm.StationName) + ")"                
            End If
            ' m_stoStatusObject.RequestStatus(Me.txtRecipe.Name, Me.txtRecipe.Text)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txtRecipe_Click")
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19 </date>
    ''' </author>
    ''' <summary>
    ''' Handling Start Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        AVPLib.Log.guiLogger.Info("Enter btnStart_Click")
        Try
            If Me.btnStart.Text = "Stop" Then
                Me.btnStart.Text = "Start"
                If Me.btnPause.Text = "Resume" Then btnPause.Text = "Pause"
                m_stoStatusObject.RequestStatus(Me.btnStart.Name, "Stop")
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "Manually Stop Recipe " + Me.txtRecipe.Text)
            ElseIf Me.btnStart.Text = "Start" And Me.txtRecipe.Text.Length > 0 Then
                Me.btnStart.Text = "Stop"
                m_stoStatusObject.RequestStatus(Me.btnStart.Name, txtRecipe.Text)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "Manually Start Recipe " + Me.txtRecipe.Text)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnStart_Click")
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19 </date>
    ''' </author>
    ''' <summary>
    ''' Handling control loading event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ProcessRecipeControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Protected Overrides Sub CreateStatusTree()
        Try
         
            Dim btnStart As New StatusButtonRecipeStartStop(Me.btnStart, Me.btnPause)
            Dim btnPause As New StatusButton(Me.btnPause)
        
            m_stoStatusObject.Name = Me.Name
            
            m_stoStatusObject.AddChild(btnStart)
            m_stoStatusObject.AddChild(btnPause)
            
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

    Private Sub btnPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPause.Click
        AVPLib.Log.guiLogger.Info("Enter btnPause_Click")
        Try
            If Me.btnPause.Text = "Resume" Then
                Me.btnPause.Text = "Pause"
                m_stoStatusObject.RequestStatus(Me.btnPause.Name, "Resume")
            ElseIf Me.btnPause.Text = "Pause" Then
                Me.btnPause.Text = "Resume"
                m_stoStatusObject.RequestStatus(Me.btnPause.Name, "Pause")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnPause_Click")
    End Sub
End Class
