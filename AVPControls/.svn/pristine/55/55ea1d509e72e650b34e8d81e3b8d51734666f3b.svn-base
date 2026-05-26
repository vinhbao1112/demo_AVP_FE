Public Class WaferCheckBox
    Inherits System.Windows.Forms.CheckBox
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
			MyBase.Text = ""
            MyBase.Size = New System.Drawing.Size(15,14)
            Me.Cursor = Cursors.Hand
		Catch ex As Exception
            Logger.Error(ex.ToString())
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
                Logger.Error(ex.ToString())
            End Try
        End Set
    End Property
#End Region


End Class
