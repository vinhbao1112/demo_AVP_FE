<Flags()> _
Public Enum DataStringFlags
    ' Fields
    ForceUnit = 1
    None = 0
    UseMaxBound = 2
    UseMinBound = 4
End Enum

Public Class DataString
    ' Constructor.
    Friend Sub New(ByVal uc As UnitConverter, ByVal unitSymbol As String)
        m_uc = uc
        m_flags = DataStringFlags.None
        m_unit = m_uc.GetUnitBySymbol(unitSymbol)
        If (m_unit Is Nothing) Then
            m_unit = Me.m_uc.GetUnitBySymbol("")
        End If
        m_value = 0
    End Sub

    ' Events
    Public Event OnUnitChanged As EventHandler
    Public Event OnValueChanged As EventHandler

    ' Methods
    Public Function GetValue(ByRef output As Double) As UnitResult
        Return m_uc.ConvertFromStandard(m_value, m_unit.Name, output)
    End Function

    Public Function GetValue(ByRef output As String) As UnitResult
        Dim num As Double = 0
        output = ""
        Dim result As UnitResult = m_uc.ConvertFromStandard(m_value, m_unit.Name, num)
        If (result = UnitResult.NoError) Then
            output = (num.ToString & " " & m_unit.DefaultSymbol)
        End If
        Return result
    End Function

    Public Function GetValueAs(ByVal unitSymbol As String, ByRef output As Double) As UnitResult
        Return m_uc.ConvertUnits(m_value, m_unit.Name, unitSymbol, output)
    End Function

    Public Function GetValueAs(ByVal unitSymbol As String, ByRef output As String) As UnitResult
        Dim num As Double = 0
        output = ""
        Dim result As UnitResult = m_uc.ConvertFromStandard(m_value, unitSymbol, num)
        If (result = UnitResult.NoError) Then
            Dim unitBySymbol As IUnitEntry = m_uc.GetUnitBySymbol(unitSymbol)
            output = (num.ToString & " " & unitBySymbol.DefaultSymbol)
        End If
        Return result
    End Function

    Public Function SetMaxBound(ByVal maxbound As Double, ByVal unitSymbol As String) As UnitResult
        If Not m_uc.CompatibleUnits(unitSymbol, m_unit.DefaultSymbol) Then
            Return UnitResult.UnitMismatch
        End If
        Return m_uc.ConvertToStandard(maxbound, unitSymbol, m_maxbound)
    End Function

    Public Function SetMinBound(ByVal minbound As Double, ByVal unitSymbol As String) As UnitResult
        If Not m_uc.CompatibleUnits(unitSymbol, m_unit.DefaultSymbol) Then
            Return UnitResult.UnitMismatch
        End If
        Return m_uc.ConvertToStandard(minbound, unitSymbol, m_minbound)
    End Function

    Public Function SetUnit(ByVal unitSymbol As String) As UnitResult
        Dim unitBySymbol As IUnitEntry = m_uc.GetUnitBySymbol(unitSymbol)
        If (unitBySymbol Is Nothing) Then
            Return UnitResult.BadUnit
        End If
        If (Not unitBySymbol Is m_unit) Then
            m_unit = unitBySymbol
            RaiseEvent OnUnitChanged(Me, EventArgs.Empty)
        End If
        Return UnitResult.NoError
    End Function

    Public Function SetValue(ByVal val As Double) As UnitResult
        Dim result As UnitResult = m_uc.ConvertToStandard(val, m_unit.Name, m_value)
        If (result = UnitResult.NoError) Then
            RaiseEvent OnValueChanged(Me, EventArgs.Empty)
        End If
        Return result
    End Function

    Public Function ValidateEntry(ByVal entry As String) As UnitResult
        Dim str As String = String.Empty
        Dim num As Double
        Dim result As UnitResult = m_uc.ParseUnitString(entry, num, str)
        If (result = UnitResult.NoError) Then
            If Not m_uc.CompatibleUnits(str, m_unit.DefaultSymbol) Then
                Return UnitResult.UnitMismatch
            End If
            Dim x As Double
            result = m_uc.ConvertToStandard(num, str, x)
            If (((m_flags And DataStringFlags.UseMaxBound) > DataStringFlags.None) AndAlso (x > m_maxbound)) Then
                Return UnitResult.ValueTooHigh
            End If
            If (((m_flags And DataStringFlags.UseMinBound) > DataStringFlags.None) AndAlso (x < m_minbound)) Then
                Return UnitResult.ValueTooLow
            End If
        End If
        Return result
    End Function


    Public Function SetValue(ByVal entry As String) As UnitResult
        Dim result As UnitResult = ValidateEntry(entry)
        If (result = UnitResult.NoError) Then
            Dim num As Double
            Dim str As String = String.Empty
            result = m_uc.ParseUnitString(entry, num, str)
            If ((m_flags And DataStringFlags.ForceUnit) > DataStringFlags.None) Then
                result = m_uc.ConvertUnits(num, str, m_unit.Name, num)
            Else
                result = SetUnit(str)
            End If
            result = SetValue(num)
        End If
        Return result
    End Function

    Public Overrides Function ToString() As String
        Dim str As String = String.Empty
        If (GetValue(str) <> UnitResult.NoError) Then
            Return "ERROR!"
        End If
        Return str
    End Function

    Public Shared Operator +(ByVal d1 As DataString, ByVal d2 As DataString) As DataString
        Dim result As New DataString(DirectCast(d1.Converter, UnitConverter), d1.Unit.DefaultSymbol)
        Dim x As Double = 0
        Dim y As Double = 0
        Dim z As Double = 0

        d1.GetValue(x)
        d1.Converter.ConvertToStandard(x, d1.Unit.DefaultSymbol, x)

        d2.GetValue(y)
        d2.Converter.ConvertToStandard(y, d2.Unit.DefaultSymbol, y)

        z = (x + y)

        d1.Converter.ConvertFromStandard(z, d1.Unit.DefaultSymbol, z)

        result.SetUnit(d1.Unit.DefaultSymbol)
        result.SetValue(z)
        Return result
    End Operator

    Public Shared Operator -(ByVal d1 As DataString, ByVal d2 As DataString) As DataString
        Dim result As New DataString(DirectCast(d1.Converter, UnitConverter), d1.Unit.DefaultSymbol)
        Dim x As Double = 0
        Dim y As Double = 0
        Dim z As Double = 0

        d1.GetValue(x)
        d1.Converter.ConvertToStandard(x, d1.Unit.DefaultSymbol, x)

        d2.GetValue(y)
        d2.Converter.ConvertToStandard(y, d2.Unit.DefaultSymbol, y)

        z = (x - y)

        d1.Converter.ConvertFromStandard(z, d1.Unit.DefaultSymbol, z)
        result.SetUnit(d1.Unit.DefaultSymbol)
        result.SetValue(z)
        Return result
    End Operator

    Public Shared Operator *(ByVal d1 As DataString, ByVal d2 As DataString) As DataString
        Dim result As New DataString(DirectCast(d1.Converter, UnitConverter), d1.Unit.DefaultSymbol)
        Dim x As Double = 0
        Dim y As Double = 0
        Dim z As Double = 0

        d1.GetValue(x)
        d1.Converter.ConvertToStandard(x, d1.Unit.DefaultSymbol, x)

        d2.GetValue(y)
        d2.Converter.ConvertToStandard(y, d2.Unit.DefaultSymbol, y)

        z = (x * y)

        d1.Converter.ConvertFromStandard(z, d1.Unit.DefaultSymbol, z)
        result.SetUnit(d1.Unit.DefaultSymbol)
        result.SetValue(z)
        Return result
    End Operator

    Public Shared Operator /(ByVal d1 As DataString, ByVal d2 As DataString) As DataString
        Dim result As New DataString(DirectCast(d1.Converter, UnitConverter), d1.Unit.DefaultSymbol)
        Dim x As Double = 0
        Dim y As Double = 0
        Dim z As Double = 0

        d1.GetValue(x)
        d1.Converter.ConvertToStandard(x, d1.Unit.DefaultSymbol, x)

        d2.GetValue(y)
        d2.Converter.ConvertToStandard(y, d2.Unit.DefaultSymbol, y)

        z = (x / y)

        d1.Converter.ConvertFromStandard(z, d1.Unit.DefaultSymbol, z)
        result.SetUnit(d1.Unit.DefaultSymbol)
        result.SetValue(z)
        Return result
    End Operator

    ' Properties
    Public ReadOnly Property Converter() As IUnitConverter
        Get
            Return m_uc
        End Get
    End Property

    Public Property Flags() As DataStringFlags
        Get
            Return m_flags
        End Get
        Set(ByVal value As DataStringFlags)
            Me.m_flags = value
        End Set
    End Property

    Public ReadOnly Property Unit() As IUnitEntry
        Get
            Return m_unit
        End Get
    End Property

    ' Fields
    Private m_flags As DataStringFlags
    Private m_maxbound As Double
    Private m_minbound As Double
    Private m_uc As UnitConverter
    Private m_unit As IUnitEntry
    Private m_value As Double
End Class


