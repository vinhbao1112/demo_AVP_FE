Public Class NumberCircleStatusControl
#Region "Class Constants & Variables"
    Private m_intNumber As Integer
#End Region

#Region "Public Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' Set or get the number will be display inside the circle
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Number() As Integer
        Get
            Return m_intNumber
        End Get
        Set(ByVal value As Integer)
            m_intNumber = value
        End Set
    End Property
#End Region

#Region "Costructor and destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' Initiate Number circle status control
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_intNumber = 1
    End Sub
#End Region

#Region "Protected Methods"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' Paint circle and number to screen
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
	Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
		Try
			If (MyBase.Status = DisplayStatus.Off) Then
				e.Graphics.FillEllipse(Brushes.DarkGray, 0, 0, Me.Width - 1, Me.Height - 1)
            ElseIf (MyBase.Status = DisplayStatus.On) Then
                Dim x, y As Integer
                x = (Me.Width / 2) - ((Font.Size + 2) / 2)
                y = (Me.Height / 2) - ((Font.Size + 2) / 2)
                e.Graphics.FillEllipse(Brushes.Cyan, 0, 0, Me.Width - 1, Me.Height - 1)
                e.Graphics.DrawString(m_intNumber.ToString, Me.Font, Brushes.Black, x, y)
			End If
			e.Graphics.DrawEllipse(Pens.Black, 0, 0, Me.Width - 1, Me.Height - 1)
		Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
		End Try
	End Sub
#End Region

End Class
