Imports System.IO
Imports System.Text
Imports log4net.Core
Imports log4net.Layout
Imports log4net.Util
Imports log4net.Appender

Public Class HeaderOnceAppender
    Inherits RollingFileAppender

    Protected Overrides Sub WriteHeader()
        If LockingModel.AcquireLock().Length = 0 Then
            MyBase.WriteHeader()
        End If
    End Sub
End Class
