Public NotInheritable Class SplashScreen
    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).

    Public ReadOnly Property BarStatus() As ProgressBar
        Get
            Return pBar1
        End Get
    End Property

    Public Property CopyrightText() As String
        Get
            Return Copyright.Text
        End Get
        Set(ByVal value As String)
            Copyright.Text = value
        End Set
    End Property

    Public Property VersionText() As String
        Get
            Return Version.Text
        End Get
        Set(ByVal value As String)
            Version.Text = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Format the version information using the text set into the Version control at design time as the
        ' formatting string.  This allows for effective localization if desired.
        ' Build and revision information could be included by using the following code and changing the 
        ' Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        ' String.Format() in Help for more information.
        '
        ' Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        ' Load Assemply version
        If Not My.Application.Info.Copyright.Contains("AVP") Then
            Me.BackgroundImage = My.Resources.Resources.CTC_Splash_Screen
            Copyright.Top += 3
            Version.Top += 3
            pBar1.Top += 3
        End If

        Dim AVPVersion As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly

        SetVersion(AVPVersion)

        'Copyright info
        Copyright.Text = My.Application.Info.Copyright

        pBar1.Visible = True
        ' Set Minimum to 1 to represent the first file being copied.
        pBar1.Minimum = 1
        ' Set Maximum to the total number of files to copy.
        pBar1.Maximum = 100
        ' Set the initial value of the ProgressBar.
        pBar1.Value = 1
        ' Set the Step property to a value of 1 to represent each file being copied.
        pBar1.Step = 10

    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-15</date>
    ''' </author>
    ''' <summary>
    ''' Set version text.
    ''' </summary>
    ''' <param name="asm"></param>
    ''' <remarks></remarks>
    Public Sub SetVersion(ByVal asm As System.Reflection.Assembly)
        Version.Text = String.Format("Ver. {0}.{1}.{2}.{3}", asm.GetName.Version.Major, asm.GetName.Version.Minor, asm.GetName.Version.Build, asm.GetName.Version.Revision)
    End Sub
End Class
