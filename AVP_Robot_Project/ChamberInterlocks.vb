Public Class ChamberInterlocks
#Region "Properties"
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim sibChamberPress As New StatusIGCGButton(bicChamberPress)
            Dim sibFixtureWater As New StatusIGCGButton(bicFixtureWater)
            Dim sibForeline As New StatusIGCGButton(bicForeline)
            Dim sibMagnetWater As New StatusIGCGButton(bicAirPressure)
            Dim sibSourceWater As New StatusIGCGButton(bicSourceWater)
            Dim sibTarget As New StatusIGCGButton(bicPanelInterlock)
            Dim sibTurboWater As New StatusIGCGButton(bicTurboWater)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(sibChamberPress)
            m_stoStatusObject.AddChild(sibFixtureWater)
            m_stoStatusObject.AddChild(sibForeline)
            m_stoStatusObject.AddChild(sibMagnetWater)
            m_stoStatusObject.AddChild(sibSourceWater)
            m_stoStatusObject.AddChild(sibTarget)
            m_stoStatusObject.AddChild(sibTurboWater)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
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
    Private Sub ChamberInterlocks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
#End Region

End Class
