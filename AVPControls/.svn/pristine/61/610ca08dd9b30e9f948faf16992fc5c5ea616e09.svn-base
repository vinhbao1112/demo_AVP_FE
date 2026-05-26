
Public Class FullVersionPopupForm

#Region "Fields"

    Private m_toolID As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If Not My.Application.Info.Copyright.Contains("AVP") Then
            PictureBox1.Image = My.Resources.CTCLogoWithoutBg
        End If
    End Sub

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2017-05-24</date>
    ''' <summary>
    ''' Gets or sets ToolID.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ToolID() As String
        Get
            Return m_toolID
        End Get
        Set(ByVal value As String)
            m_toolID = value
        End Set
    End Property

#End Region

#Region "Methods"

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-04-13 </date>
    ''' </author>
    ''' <summary>
    ''' Show Popupform.
    ''' </summary>
    Private Sub FullVersionPopupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim AVPVersion As System.Reflection.Assembly = System.Reflection.Assembly.GetEntryAssembly
            Label1.Text = String.Format("Version {0}.{1}.{2}.{3}", AVPVersion.GetName.Version.Major, AVPVersion.GetName.Version.Minor, AVPVersion.GetName.Version.Build, AVPVersion.GetName.Version.Revision)
            lbVersion.Text = ToolID
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

#End Region

End Class