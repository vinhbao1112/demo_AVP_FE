Public Class WaferLabelBox
    Inherits System.Windows.Forms.Label

#Region "Class Constants & Variables"
    Private m_intID As Integer
#End Region

#Region "Constructors & Dispose"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Initate this control
    ''' </summary>
    ''' <remarks></remarks>
	Public Sub New()
		Try
			MyBase.BackColor = System.Drawing.Color.DarkGray
			MyBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			MyBase.Text = ""
		Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Get or set ID of wafer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ID() As Integer
        Get
            Return m_intID
        End Get
        Set(ByVal value As Integer)
            Try
                m_intID = value
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
#End Region

End Class
