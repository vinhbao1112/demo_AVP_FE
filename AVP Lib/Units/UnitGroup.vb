Imports System.Collections.Generic

Friend Class UnitGroup
    ' Methods
    Public Function AddUnit(ByVal unit As UnitEntry) As UnitResult
        m_Units.Item(unit.Name) = unit
        Return UnitResult.NoError
    End Function

    Public Function IsInGroup(ByVal unitName As String) As Boolean
        Dim unit As IUnitEntry = Nothing
        If m_Units.TryGetValue(unitName, unit) Then
            Return True
        Else
            Return False
        End If
    End Function

    ' Properties
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal value As String)
            m_Name = value
        End Set
    End Property

    ' Fields
    Private m_Name As String
    Private m_Units As Dictionary(Of String, UnitEntry) = New Dictionary(Of String, UnitEntry)
End Class
