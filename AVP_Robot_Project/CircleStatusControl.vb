Public Class CircleStatusControl
    Private m_blnPMVisible As Boolean = True
#Region "property"
    Public Property PMVisible() As Boolean
        Get
            Return m_blnPMVisible
        End Get
        Set(ByVal value As Boolean)
            m_blnPMVisible = value
        End Set
    End Property
#End Region
#Region "Protected Methods"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Paint circle to screen
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            If MyBase.Status = DisplayStatus.On Then
                e.Graphics.DrawImage(My.Resources.Resources.Sensor_On, New PointF(0.0F, 0.0F))
            Else
                e.Graphics.DrawImage(My.Resources.Resources.Sensor_Off, New PointF(0.0F, 0.0F))
            End If
            If PMVisible = False Then
                '  myBrush = New SolidBrush(Color.Gray)
                '-->this change caused by Mr Khoi, Make all wafer sensors active when PM is not installed.
                e.Graphics.DrawImage(My.Resources.Resources.Sensor_Off, New PointF(0.0F, 0.0F))
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
End Class