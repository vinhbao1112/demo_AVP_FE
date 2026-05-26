Public Class FootStatusControl
#Region "Constructor & Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Create defaulf valve
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.LoadDefaultValvePicture()
    End Sub
#End Region

#Region "Private Methods"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Load valve picture
    ''' </summary>
    ''' <remarks></remarks>
	Private Sub LoadDefaultValvePicture()
		Try
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FootStatusControl))
			MyBase.OnImage = CType(resources.GetObject("FootGreen"), Image)
			MyBase.OffImage = CType(resources.GetObject("FootRed"), Image)
		Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
		End Try
	End Sub
#End Region
End Class
