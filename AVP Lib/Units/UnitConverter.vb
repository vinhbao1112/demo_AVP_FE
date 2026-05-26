Imports System.IO
Imports System.Xml
Imports System.Collections.Generic

Public Class UnitFileException
    Inherits Exception
    ' Methods
    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal detail As String)
        MyBase.New(message)
        Me.m_Detail = detail
    End Sub

    ' Properties
    Public ReadOnly Property Detail() As String
        Get
            Return Me.m_Detail
        End Get
    End Property

    ' Fields
    Private m_Detail As String
End Class

Friend Class UnitConverter
    Implements IUnitConverter

    ' Methods
#Region "Implementing the interface IUnitConverter"
    ' Events
    Public Event OnError As EventHandler(Of UnitEventArgs) Implements IUnitConverter.OnError

    Public Sub InitTables() Implements IUnitConverter.InitTables
        m_SymbolTable.Clear()
        m_UnitGroups.Clear()
        m_Units.Clear()
        Dim unit As New UnitEntry
        unit.DefaultSymbol = ""
        unit.Name = "No Unit"
        m_Units.Item(unit.Name) = unit
        m_SymbolTable.Item("") = unit
        CreateNewGroup("BuiltIn")
        m_UnitGroups.Item("BuiltIn").AddUnit(unit)
    End Sub

    Public Function LoadUnitsFile(ByVal filePath As String) As UnitResult Implements IUnitConverter.LoadUnitsFile
        Dim strError As String = ""
        If Not File.Exists(filePath) Then
            Return UnitResult.FileNotFound
        End If
        Try
            m_UnitsFile.Load(filePath)
        Catch exception As XmlException
            strError = "Error parsing '{0}' at line {1}, position {2}."
            Throw New UnitFileException(String.Format(strError, filePath, exception.LineNumber, exception.LinePosition), exception.Message)
        End Try
        ' Reinitialise the data tables.
        InitTables()

        m_CurUnitFileName = ""
        m_CurUnitsFileVersion = 0

        'Get a reference to a list of the XML data
        Dim elementsByTagName As XmlNodeList = m_UnitsFile.GetElementsByTagName("*")
        If (elementsByTagName.Count = 0) Then
            strError = "Error parsing units file '{0}' - file contains no data."
            Throw New UnitFileException(String.Format(strError, filePath))
        End If
        ' Get the root node.
        Dim node As XmlNode = elementsByTagName.ItemOf(0)
        ' Does the file not start with a "UnitFile" node? We have problems.
        If (node.Name.ToLower <> "unitfile") Then
            strError = "Error parsing units file '{0}' - the file appears corrupt or incomplete."
            Throw New UnitFileException(String.Format(strError, filePath))
        End If
        ' Store off the name of the units file if there is one.
        If (Not node.Attributes.ItemOf("name") Is Nothing) Then
            m_CurUnitFileName = node.Attributes.ItemOf("name").Value
        Else
            ' Units file has no internal name set on it.
            SendUnitFileWarning("file has no internal units name - using default.", filePath, Nothing)
            m_CurUnitFileName = "Units"
        End If
        ' Check units file version.
        If (Not node.Attributes.ItemOf("version") Is Nothing) Then
            Try
                m_CurUnitsFileVersion = Convert.ToDouble(node.Attributes.ItemOf("version").Value)
            Catch
                m_CurUnitsFileVersion = 0
            End Try
            If (m_CurUnitsFileVersion = 0) Then
                ' File version is 0.0, probably failed to convert to a double.
                strError = "Error parsing '{0}' - file has no valid version number."
                Throw New UnitFileException(String.Format(strError, filePath))
            End If
            If (m_CurUnitsFileVersion > UNITFILE_VERSION) Then
                ' File version is greater than the maximum we support.
                strError = "Error parsing '{0}' - file version indicates it is made for a newer version of the unit conversion library."
                Throw New UnitFileException(String.Format(strError, filePath))
            End If
        Else
            ' No version information was found at all.
            strError = "Error parsing '{0}' - file has no version number specified."
            Throw New UnitFileException(String.Format(strError, filePath))
        End If
        ' Parse all the unit groups and add them.
        Dim num As Integer = 0
        For num = 0 To node.ChildNodes.Count - 1
            Dim groupnode As XmlNode = node.ChildNodes.ItemOf(num)
            ' Ignore comments.
            If (groupnode.Name.ToLower <> "#comment") Then
                If (groupnode.Name.ToLower <> "unitgroup") Then
                    SendUnitFileWarning("bad tag found while parsing groups (tag was '{0}'), tag ignored.", filePath, New Object() {groupnode.Name})
                Else
                    ParseGroupXMLNode(filePath, groupnode)
                End If
            End If
        Next num
        ' We were successful.
        Return UnitResult.NoError
    End Function

    Public Function ParseUnitString(ByVal input As String, ByRef val As Double, ByRef unit As String) As UnitResult Implements IUnitConverter.ParseUnitString
        val = 0
        unit = ""
        If (Not String.IsNullOrEmpty(input)) Then
            Dim index As Integer = 0
            Dim str As String = ""
            Dim unitSymbol As String = ""
            ' Look for the first letter or punctuation character.
            Do While (index < input.Length)
                If Char.IsLetter(input, index) Then
                    Exit Do
                End If
                index += 1
            Loop
            str = input.Substring(0, index).Trim()
            unitSymbol = input.Substring(index).Trim()
            If (String.IsNullOrEmpty(str)) Then
                str = "0"
            End If
            Try
                val = Convert.ToDouble(str)
            Catch
                Return UnitResult.BadValue
            End Try
            If (GetUnitBySymbol(unitSymbol) Is Nothing) Then
                Return UnitResult.BadUnit
            End If
            unit = unitSymbol
        End If
        Return UnitResult.NoError
    End Function

    Public Function GetUnitBySymbol(ByVal unitSymbol As String) As IUnitEntry Implements IUnitConverter.GetUnitBySymbol
        Dim unit As IUnitEntry = Nothing
        Dim unitSymbolInLowerCase As String = unitSymbol.ToLower()
        If (m_Units.TryGetValue(unitSymbolInLowerCase, unit)) Then
            Return unit
        Else
            If (m_SymbolTable.TryGetValue(unitSymbol, unit)) Then
                Return unit
            End If
        End If
        Return Nothing
    End Function

    Public Function GetUnitByName(ByVal unitName As String) As IUnitEntry Implements IUnitConverter.GetUnitByName
        unitName = unitName.ToLower()
        Dim unit As IUnitEntry = Nothing
        If (m_Units.TryGetValue(unitName, unit)) Then
            Return unit
        End If
        Return Nothing
    End Function

    Public Function CreateDataString() As DataString Implements IUnitConverter.CreateDataString
        Return New DataString(Me, "")
    End Function

    Public Function CreateDataString(ByVal unitSymbol As String) As DataString Implements IUnitConverter.CreateDataString
        Return New DataString(Me, unitSymbol)
    End Function

    Public Function ConvertUnits(ByVal val As Double, ByVal unitfrom As String, ByVal unitto As String, ByRef output As Double) As UnitResult Implements IUnitConverter.ConvertUnits
        Dim num As Double = val
        output = FAILSAFE_VALUE
        Dim unit_from As IUnitEntry = GetUnitBySymbol(unitfrom)
        Dim unit_to As IUnitEntry = GetUnitBySymbol(unitto)
        If ((unit_from Is Nothing) OrElse (unit_to Is Nothing)) Then
            Return UnitResult.BadUnit
        End If
        If Not CompatibleUnits(unit_from.Name, unit_to.Name) Then
            Return UnitResult.UnitMismatch
        End If
        Dim result As UnitResult = ConvertToStandard(num, unit_from.Name, num)
        If (result <> UnitResult.NoError) Then
            Return result
        End If
        result = ConvertFromStandard(num, unit_to.Name, num)
        If (result <> UnitResult.NoError) Then
            Return result
        End If
        output = num
        Return UnitResult.NoError
    End Function

    Public Function ConvertToStandard(ByVal val As Double, ByVal unitfrom As String, ByRef output As Double) As UnitResult Implements IUnitConverter.ConvertToStandard
        Dim num As Double = val
        output = FAILSAFE_VALUE
        Dim unitBySymbol As IUnitEntry = GetUnitBySymbol(unitfrom)
        If (unitBySymbol Is Nothing) Then
            Return UnitResult.BadUnit
        End If
        Try
            num = (num + unitBySymbol.PreAdder)
            If (unitBySymbol.Multiplier > 0) Then
                num = (num * unitBySymbol.Multiplier)
            End If
            num = (num + unitBySymbol.Adder)
            output = num
        Catch
            Return UnitResult.BadValue
        End Try
        Return UnitResult.NoError
    End Function

    Public Function ConvertFromStandard(ByVal val As Double, ByVal unitTo As String, ByRef output As Double) As UnitResult Implements IUnitConverter.ConvertFromStandard
        Dim num As Double = val
        output = FAILSAFE_VALUE
        Dim unitBySymbol As IUnitEntry = GetUnitBySymbol(unitTo)
        If (unitBySymbol Is Nothing) Then
            Return UnitResult.BadUnit
        End If
        Try
            num = (num - unitBySymbol.PreAdder)
            If (unitBySymbol.Multiplier > 0) Then
                num = (num * Math.Pow(unitBySymbol.Multiplier, -1))
            End If
            num = (num - unitBySymbol.Adder)
            output = num
        Catch
            Return UnitResult.BadValue
        End Try
        Return UnitResult.NoError
    End Function

    Public Function CompatibleUnits(ByVal unitSymbol1 As String, ByVal unitSymbol2 As String) As Boolean Implements IUnitConverter.CompatibleUnits
        Dim unitBySymbol1 As IUnitEntry = Me.GetUnitBySymbol(unitSymbol1)
        Dim unitBySymbol2 As IUnitEntry = Me.GetUnitBySymbol(unitSymbol2)
        Return (((Not unitBySymbol1 Is Nothing) AndAlso (Not unitBySymbol2 Is Nothing)) AndAlso (GetUnitGroup(unitBySymbol1.Name) Is GetUnitGroup(unitBySymbol2.Name)))
    End Function
#End Region

#Region "Constructor and Finalizer if any."
    Public Sub New()
        m_SymbolTable = New Dictionary(Of String, UnitEntry)()
        m_Units = New Dictionary(Of String, UnitEntry)()
        m_UnitGroups = New Dictionary(Of String, UnitGroup)()
        m_UnitsFile = New XmlDocument()
        m_CurUnitsFileVersion = 0
        m_CurUnitFileName = ""
        ' Initialize tables.
        InitTables()
    End Sub
#End Region

#Region "Helper functions"

    Private Function GetUnitFromSymbolTable(ByVal unitSymbol As String) As IUnitEntry
        Dim unit As IUnitEntry = Nothing
        If (m_SymbolTable.TryGetValue(unitSymbol, unit)) Then
            Return unit
        End If
        Return Nothing
    End Function

    Private Function AddUnitToGroup(ByVal unitName As String, ByVal groupName As String) As UnitResult

        unitName = unitName.ToLower()
        groupName = groupName.ToLower()

        Dim unit As UnitEntry = Nothing
        If Not m_Units.TryGetValue(unitName, unit) Then
            Return UnitResult.UnitNotFound
        End If

        Dim group As UnitGroup = Nothing
        If Not m_UnitGroups.TryGetValue(groupName, group) Then
            Return UnitResult.GroupNotFound
        End If
        Return group.AddUnit(unit)
    End Function

    Private Function CreateNewGroup(ByVal groupName As String) As UnitResult
        Dim group As New UnitGroup()
        group.Name = groupName.ToLower()
        m_UnitGroups.Item(groupName) = group
        Return UnitResult.NoError
    End Function

    Private Function GetUnitGroup(ByVal unitName As String) As UnitGroup
        unitName = unitName.ToLower()
        Dim unit As IUnitEntry = Nothing
        ' Does the unit even exist?
        If m_Units.TryGetValue(unitName, unit) Then
            Dim group As UnitGroup
            ' Iterate through every group.
            For Each group In m_UnitGroups.Values
                If group.IsInGroup(unitName) Then
                    Return group
                End If
            Next
        End If
        Return Nothing
    End Function

    Private Function ParseGroupXMLNode(ByVal filePath As String, ByVal groupnode As XmlNode) As UnitResult
        Dim num As Integer = 0
        ' Check the group has a name.
        If (groupnode.Attributes.ItemOf("name") Is Nothing) Then
            SendUnitFileWarning("found a group with no name, ignoring group.", filePath, Nothing)
            Return UnitResult.GenericError
        End If
        ' Create the group.
        If (CreateNewGroup(groupnode.Attributes.ItemOf("name").Value) <> UnitResult.NoError) Then
            ' Make sure the group was created.
            SendUnitFileWarning("failed to create group entry, skipping group.", filePath, Nothing)
            Return UnitResult.GenericError
        End If
        ' Get a reference to the group we just created.
        Dim group As UnitGroup = m_UnitGroups.Item(groupnode.Attributes.ItemOf("name").Value)
        For num = 0 To groupnode.ChildNodes.Count - 1
            Dim unitnode As XmlNode = groupnode.ChildNodes.ItemOf(num)
            If (unitnode.Name.ToLower <> "#comment") Then
                If (unitnode.Name.ToLower <> "unit") Then
                    SendUnitFileWarning("bad tag found while parsing units of group '{0}' (tag was '{1}'), tag ignored.", filePath, New Object() {group.Name, unitnode.Name})
                Else
                    Dim result As UnitResult = ParseUnitXMLNode(filePath, group, unitnode)
                End If
            End If
        Next num
        Return UnitResult.NoError
    End Function

    Private Function ParseNumberString(ByVal input As String, ByRef val As Double) As UnitResult
        ' Default value
        val = 0.0
        ' Split the numbers on the ^ operator
        Dim numbers As String()
        numbers = input.Split(New Char() {"^"})
        If (numbers.Length = 1) Then
            ' Only one value, so there was no ^ operator present
            ' so just return the one number.
            Try
                val = Convert.ToDouble(numbers(0))
            Catch
                Return UnitResult.BadValue
            End Try
        ElseIf (numbers.Length >= 2) Then ' There is a ^ operator, so try to use it.
            Try
                val = Convert.ToDouble(numbers(0))
                val = Math.Pow(val, Convert.ToDouble(numbers(1)))
            Catch
                Return UnitResult.BadValue
            End Try
        End If

        Return UnitResult.NoError
    End Function

    Private Function ParseUnitXMLNode(ByVal filePath As String, ByVal group As UnitGroup, ByVal unitnode As XmlNode) As UnitResult
        Dim num As Integer = 0
        Dim entry As New UnitEntry()
        ' Make sure the unit has a name
        If (unitnode.Attributes.ItemOf("name") Is Nothing) Then
            SendUnitFileWarning("found a unit in group '{0}' with no name, ignored.", filePath, New Object() {group.Name})
            Return UnitResult.GenericError
        End If
        ' Store off the name
        entry.Name = unitnode.Attributes.ItemOf("name").Value
        entry.DefaultSymbol = entry.Name.ToLower
        ' Dont allow duplicate units
        If (Not GetUnitByName(entry.Name) Is Nothing) Then
            SendUnitFileWarning("duplicate unit with name '{0}' was found and ignored.", filePath, New Object() {entry.Name})
            Return UnitResult.UnitExists
        End If
        ' Get every unit property
        For num = 0 To unitnode.ChildNodes.Count - 1
            Dim node As XmlNode = unitnode.ChildNodes.ItemOf(num)
            If (node.Name.ToLower <> "#comment") Then
                Try
                    If (node.Name.ToLower = "multiply") Then
                        Dim x As Double
                        If (ParseNumberString(node.InnerText, x) <> UnitResult.NoError) Then
                            Throw New Exception("Failed to parse " & node.InnerText & " to Double.")
                        End If
                        entry.Multiplier = x
                    ElseIf (node.Name.ToLower = "add") Then
                        entry.Adder = Convert.ToDouble(node.InnerText)
                    ElseIf (node.Name.ToLower = "preadd") Then
                        entry.PreAdder = Convert.ToDouble(node.InnerText)
                    End If
                Catch
                    SendUnitFileWarning("unit '{0}' has invalid '{1}' value. Unit skipped.", filePath, New Object() {entry.Name, node.Name})
                    Return UnitResult.GenericError
                End Try
                ' Parse the symbol properties
                If (node.Name.ToLower = "symbol") Then
                    If Not String.IsNullOrEmpty(node.InnerText) Then
                        If (Not GetUnitFromSymbolTable(node.InnerText) Is Nothing) Then
                            SendUnitFileWarning("while parsing unit '{0}' - a duplicate symbol was found and ignored ({1}).", filePath, New Object() {entry.Name, node.InnerText})
                        Else
                            m_SymbolTable.Item(node.InnerText) = entry
                            If (Not node.Attributes.ItemOf("default") Is Nothing) Then
                                entry.DefaultSymbol = node.InnerText
                            End If
                        End If
                    Else
                        SendUnitFileWarning("unit '{0}' has an invalid symbol specified, symbol skipped.", filePath, New Object() {entry.Name})
                    End If
                End If
            End If
        Next num
        m_Units.Item(entry.Name.ToLower()) = entry
        Return AddUnitToGroup(entry.Name, group.Name)
    End Function

    Private Sub SendUnitFileWarning(ByVal message As String, ByVal filePath As String, ByVal args As Object())
        Dim format As String = (("Error in units file '" & filePath & "' - ") & message)
        If (Not args Is Nothing) Then
            format = String.Format(format, args)
        End If
        RaiseEvent OnError(Me, New UnitEventArgs(format))
    End Sub

#End Region

    ' Fields
    Private m_CurUnitFileName As String
    Private m_CurUnitsFileVersion As Double

    Private m_SymbolTable As Dictionary(Of String, UnitEntry)
    Private m_UnitGroups As Dictionary(Of String, UnitGroup)
    Private m_Units As Dictionary(Of String, UnitEntry)

    Private m_UnitsFile As XmlDocument

    Public Const FAILSAFE_VALUE As Double = Double.NaN
    Public Const UNITFILE_VERSION As Double = 1
End Class