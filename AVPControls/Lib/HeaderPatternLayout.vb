Imports log4net.Layout
Imports log4net.Util
Imports log4net.Appender
Imports log4net

Public Class HeaderPatternLayout
    Inherits PatternLayout

    Public Overrides Property Header() As String
        Get
            Return MyBase.Header
        End Get
        Set(ByVal value As String)
            MyBase.Header = value & System.Reflection.Assembly.GetEntryAssembly.GetName.Version.ToString() & Environment.NewLine
        End Set
    End Property
End Class
