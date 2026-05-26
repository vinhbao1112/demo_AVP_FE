Imports System.Collections.Generic
Imports System.Text
Imports log4net

<Assembly: log4net.Config.XmlConfigurator(Watch:=False)> 
Public Class Logger
    Shared _log As ILog


    Public Shared Function StaticInitialize() As [Boolean]
        _log = LogManager.GetLogger("AVPControls")

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

    Public Shared Sub Debug(ByVal strMsg As String)
        If _log IsNot Nothing Then
            _log.Debug(strMsg)
        End If
    End Sub

    Public Shared Sub Info(ByVal strMsg As String)
        If _log IsNot Nothing Then
            _log.Info(strMsg)
        End If
    End Sub

    Public Shared Sub [Error](ByVal strMsg As String)
        If _log IsNot Nothing Then
            _log.[Error](strMsg)
        End If
    End Sub

    Public Shared Sub ErrorFormat(ByVal strMsg As String, ByVal ParamArray args As Object())
        If _log IsNot Nothing Then
            _log.ErrorFormat(strMsg, args)
        End If
    End Sub

    Public Shared Sub Warn(ByVal strMsg As String)
        If _log IsNot Nothing Then
            _log.Warn(strMsg)
        End If
    End Sub

    Public Shared Sub Uninitialize()
        LogManager.Shutdown()
    End Sub
End Class
