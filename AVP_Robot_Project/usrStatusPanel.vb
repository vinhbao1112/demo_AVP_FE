Public Class usrStatusPanel
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
            Dim stbMotionInitialized As New StatusIGCGButton(btnMotionInitialized)
            Dim stbFlowcoolGas As New StatusIGCGButton(btnFlowcoolGas)
            Dim stbProcessGas As New StatusIGCGButton(btnProcessGas)
            Dim stbIonBeam As New StatusIGCGButton(btnIonBeam)
            Dim stbNeutralizer As New StatusIGCGButton(btnNeutralizer)
            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbMotionInitialized)
            m_stoStatusObject.AddChild(stbFlowcoolGas)
            m_stoStatusObject.AddChild(stbProcessGas)
            m_stoStatusObject.AddChild(stbIonBeam)
            m_stoStatusObject.AddChild(stbNeutralizer)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Events – Buttons – Forms…"
#End Region

End Class
