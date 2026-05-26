
Public Class UnitEventArgs
    Inherits EventArgs
    ' Methods
    Public Sub New(ByVal message As String)
        Me.m_Message = message
        Me.m_DetailMessage = ""
    End Sub

    Public Sub New(ByVal message As String, ByVal detailmessage As String)
        Me.m_Message = message
        Me.m_DetailMessage = detailmessage
    End Sub

    ' Properties
    Public ReadOnly Property DetailMessage() As String
        Get
            Return Me.m_DetailMessage
        End Get
    End Property

    Public ReadOnly Property Message() As String
        Get
            Return Me.m_Message
        End Get
    End Property

    ' Fields
    Private m_DetailMessage As String
    Private m_Message As String
End Class

Public Interface IUnitConverter
    ' Events
    Event OnError As EventHandler(Of UnitEventArgs)
    ' Methods
    Function CompatibleUnits(ByVal unitSymbol1 As String, ByVal unitSymbol2 As String) As Boolean
    Function ConvertFromStandard(ByVal val As Double, ByVal unitto As String, ByRef output As Double) As UnitResult
    Function ConvertToStandard(ByVal val As Double, ByVal unitfrom As String, ByRef output As Double) As UnitResult
    Function ConvertUnits(ByVal val As Double, ByVal unitfrom As String, ByVal unitto As String, ByRef output As Double) As UnitResult
    Function CreateDataString() As DataString
    Function CreateDataString(ByVal unitSymbol As String) As DataString
    Function GetUnitByName(ByVal unitName As String) As IUnitEntry
    Function GetUnitBySymbol(ByVal unitSymbol As String) As IUnitEntry
    Sub InitTables()
    Function LoadUnitsFile(ByVal filePath As String) As UnitResult
    Function ParseUnitString(ByVal input As String, ByRef val As Double, ByRef unit As String) As UnitResult
End Interface
