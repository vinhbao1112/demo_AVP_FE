Imports AVP_Robot_Project.ConstantAndEnum
Public Class PVDMagnatron
    Private m_blnIsOnline As Boolean = False
#Region "Properties"
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            btnRotationStart.Enabled = Not m_blnIsOnline
        End Set
    End Property
#End Region
#Region "Protected method"
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
            Dim sbcRotating As New StatusIGCGButton(Me.bicRotating)
            Dim sbcRotationStart As New StatusIGCGButton(Me.btnRotationStart)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(sbcRotating)
            m_stoStatusObject.AddChild(sbcRotationStart)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Rough Valve
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub btnRotationStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotationStart.Click
        Dim strLogMessage As String = String.Empty
        If CType(sender, ButtonIGCGControl).Status = DisplayStatus.On Then
            strLogMessage = "Stop Magnetron Station"
        Else
            strLogMessage = "Start Magnetron Rotation"
        End If
        PVDSupport.CommonButtonClick(strLogMessage, sender, Me.Parent, m_stoStatusObject)
    End Sub
#End Region

   
End Class
