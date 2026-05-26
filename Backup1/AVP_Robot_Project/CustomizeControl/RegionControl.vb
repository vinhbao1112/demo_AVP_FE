Public Class RegionControl
    Private bitmap As Bitmap = Nothing

#Region "Properties"
    Public Property Image() As Bitmap
        Get
            Return bitmap
        End Get
        Set(ByVal value As Bitmap)

            If (bitmap IsNot Nothing) Then
                bitmap.Dispose()
            End If

            bitmap = value

            Me.Refresh()
            If bitmap IsNot Nothing Then
                Utils.CreateControlRegion(Me, bitmap)
            End If
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-09</date>
    ''' </author>
    ''' <summary>
    ''' CreateParams overrides property of base class to support transparent
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 32
            Return cp
        End Get
    End Property
#End Region

#Region "Constructor And Destructor"
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Utils.CreateControlRegion(Me, bitmap)
        'Me.Cursor = Cursors.Hand
        ' Add any initialization after the InitializeComponent() call.
    End Sub
#End Region
End Class
