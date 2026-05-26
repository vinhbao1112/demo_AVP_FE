Imports log4net

<Assembly: log4net.Config.XmlConfigurator(Watch:=False)> 
Public Class Logger
    Shared _log As ILog


    Public Shared Function StaticInitialize() As Boolean
        _log = LogManager.GetLogger(HConstants.RecipeLogger)

        Return True
    End Function

    Public Shared Property LogHandler() As ILog
        Get
            Return _log
        End Get
        Set(ByVal value As ILog)
            _log = value
        End Set
    End Property

    Public Shared Sub Debug(ByVal message As String)
        If _log IsNot Nothing Then
            _log.Debug(message)
        End If
    End Sub

    Public Shared Sub Info(ByVal message As String)
        If _log IsNot Nothing Then
            _log.Info(message)
        End If
    End Sub

    Public Shared Sub [Error](ByVal message As String)
        If _log IsNot Nothing Then
            _log.[Error](message)
        End If
    End Sub

    Public Shared Sub ErrorFormat(ByVal message As String, ByVal ParamArray args As Object())
        If _log IsNot Nothing Then
            _log.ErrorFormat(message, args)
        End If
    End Sub

    Public Shared Sub Warn(ByVal message As String)
        If _log IsNot Nothing Then
            _log.Warn(message)
        End If
    End Sub

    Public Shared Sub Uninitialize()
        LogManager.Shutdown()
    End Sub
End Class
