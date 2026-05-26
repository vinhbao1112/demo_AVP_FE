Namespace My

    ' The following events are availble for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        ' Delegate used to marshal back to the main UI thread
        Private Delegate Sub SafeApplicationThreadException(ByVal sender As Object, ByVal e As Threading.ThreadExceptionEventArgs)

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            ' Configure AppDomain
            Dim currentDomain As AppDomain = AppDomain.CurrentDomain
            AddHandler currentDomain.UnhandledException, AddressOf AppDomain_UnhandledException
            'AddHandler Application.ThreadException, AddressOf Application_ThreadException
        End Sub

        Private Sub DisplayCustomErrorLogic(ByVal sourceException As Exception)
            ' Hide the current form
            Me.MainForm.Hide()
            ' Display the message
            MsgBox(sourceException.Message.ToString)
            ' Exit the application (you don't have to though)
            ' Application.Exit()
        End Sub

        Private Sub Application_ThreadException(ByVal sender As Object, ByVal e As Threading.ThreadExceptionEventArgs)
            ' Pass to the safe exception handler
            SafeApplication_ThreadException(sender, e)
        End Sub

        Private Sub SafeApplication_ThreadException(ByVal sender As Object, ByVal e As Threading.ThreadExceptionEventArgs)
            ' Are we running on the correct thread?
            If Me.MainForm.InvokeRequired Then
                ' Invoke back to the main thread
                Me.MainForm.Invoke(New SafeApplicationThreadException(AddressOf SafeApplication_ThreadException), New Object() {sender, e})
            Else
                ' Custom handling logic
                DisplayCustomErrorLogic(e.Exception)
            End If
        End Sub

        Private Sub AppDomain_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
            ' Custom handling logic
            DisplayCustomErrorLogic(DirectCast(e.ExceptionObject, Exception))
        End Sub

        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            e.BringToForeground = True
        End Sub
    End Class
End Namespace