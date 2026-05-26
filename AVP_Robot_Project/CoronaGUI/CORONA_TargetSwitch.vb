Public Class CORONA_TargetSwitch
    Private m_blnIsOnline As Boolean = False
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            btnTarget1Switch.Clickable = Not (m_blnIsOnline)
            btnTarget2Switch.Clickable = Not (m_blnIsOnline)
            btnTarget3Switch.Clickable = Not (m_blnIsOnline)
            btnTarget4Switch.Clickable = Not (m_blnIsOnline)
        End Set
    End Property
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
            m_stoStatusObject.Name = Me.Name
  
            Dim sbc1Status As New StatusCoronaTargetSwitch(Me.btnTarget1Switch)
            Dim sbc2Status As New StatusCoronaTargetSwitch(Me.btnTarget2Switch)
            Dim sbc3Status As New StatusCoronaTargetSwitch(Me.btnTarget3Switch)
            Dim sbc4Status As New StatusCoronaTargetSwitch(Me.btnTarget4Switch)
            m_stoStatusObject.AddChild(sbc1Status)
            m_stoStatusObject.AddChild(sbc2Status)
            m_stoStatusObject.AddChild(sbc3Status)
            m_stoStatusObject.AddChild(sbc4Status)
            btnTarget1Switch.ParentStatusObj = m_stoStatusObject
            btnTarget2Switch.ParentStatusObj = m_stoStatusObject
            btnTarget3Switch.ParentStatusObj = m_stoStatusObject
            btnTarget4Switch.ParentStatusObj = m_stoStatusObject
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Function ActiveTarget() As Integer
        If btnTarget1Switch.Status = SL_CustomButton.DisplayStatus.On Then
            Return 1
        ElseIf btnTarget2Switch.Status = SL_CustomButton.DisplayStatus.On Then
            Return 2
        ElseIf btnTarget3Switch.Status = SL_CustomButton.DisplayStatus.On Then
            Return 3
        ElseIf btnTarget4Switch.Status = SL_CustomButton.DisplayStatus.On Then
            Return 4
        End If
    End Function

End Class
