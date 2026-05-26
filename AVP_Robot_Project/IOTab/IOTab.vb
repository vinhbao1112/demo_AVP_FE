Imports AVPLib
Imports System.Text.RegularExpressions

Public Class IOTab
    Private Const DEVICE_STATUS_STR As String = "Device Status"
    Private Const ITEM_NAME_STR As String = "Item Name"
    Private Const VALUE_STR As String = "Value"
    Private Const RAW_VALUE_STR As String = "Raw Value"
    Private Const STR_PATTERN As String = "MacID([0-9]+)"
    Private Const STR_NAMEPATTERN As String = "MacID\d+.(.*)"
    Public Const STR_ACTIVE As String = " - ACTIVE"
    Public Const STR_INACTIVE As String = " - INACTIVE"

    Private m_bindingSource As BindingSource = Nothing
    Private m_dataTable As DataTable = Nothing
    Private m_ListAllDevice As Dictionary(Of String, PropertyObject) = Nothing

    Private m_Timer As System.Windows.Forms.Timer = New Timer()

    Private Sub CreateDataTable()
        Try
            m_dataTable = New DataTable()

            m_dataTable.Columns.Add(DEVICE_STATUS_STR)
            m_dataTable.Columns.Add(ITEM_NAME_STR)
            m_dataTable.Columns.Add(VALUE_STR)
            m_dataTable.Columns.Add(RAW_VALUE_STR)
            m_dataTable.DefaultView.Sort = DEVICE_STATUS_STR & " ASC, " & ITEM_NAME_STR & " ASC"
            Dim row As DataRow
            Dim itemValue As String = String.Empty
            Dim itemName As String = String.Empty
            Dim result As String()

            For Each item As KeyValuePair(Of String, PropertyObject) In m_ListAllDevice
                row = m_dataTable.NewRow()
                itemValue = item.Key.ToString()
                result = itemValue.Split(".")
                Dim match As Match = Regex.Match(result(0).ToString, STR_PATTERN)
                If match.Success Then
                    If (Driver.DriverManager.IsDeviceNetActive(Integer.Parse(match.Groups(1).ToString()))) Then
                        row(DEVICE_STATUS_STR) = result(0).ToString() + STR_ACTIVE
                    Else
                        row(DEVICE_STATUS_STR) = result(0).ToString() + STR_INACTIVE
                    End If
                End If

                match = Regex.Match(item.Key.ToString(), STR_NAMEPATTERN)
                If (match.Success) Then
                    itemName = match.Groups(1).ToString()
                Else
                    itemName = item.Key.ToString()
                End If

                row(ITEM_NAME_STR) = itemName

                If item.Value.GetValue() IsNot Nothing Then
                    'if CG then format value to 0.00E+00
                    itemValue = FormatCGValue(itemName, item.Value.GetValue().ToString())
                End If

                If Name.Contains("Alarm.AlarmStatus") Then
                    Dim objAlarm As AVPLib.DataManagerment.Alarm = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Alarm.ToString())
                    itemValue = FormatCGValue(itemName, objAlarm.AlarmStatusIOtab)
                End If

                row(VALUE_STR) = itemValue
                If (item.Value.RawValue = String.Empty) Then
                    row(RAW_VALUE_STR) = itemValue
                Else
                    row(RAW_VALUE_STR) = ParseValue(item.Value.RawValue)
                End If
                m_dataTable.Rows.Add(row)
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Tinh Le </name>
    '''    	<date> 2021-24-11</date>
    ''' </author>
    ''' <summary>
    ''' FormatCGValue
    ''' </summary>
    Private Function FormatCGValue(ByVal name As String, ByVal value As String) As String
        Dim result As String = String.Empty
        Dim canConvert As Boolean = False
        Try

            Select Case name
                Case AVPLib.ConstEnum.STR_CassettesModule_CG, AVPLib.ConstEnum.STR_CassettesModule_IonGauge, AVPLib.ConstEnum.STR_CassettesModule_TurboForelineCG, _
                    AVPLib.Driver.DriverConst.RoughPumpMachine1_CG, AVPLib.Driver.DriverConst.RoughPumpMachine2_CG, AVPLib.Driver.DriverConst.LoadLockA_CG, _
                    AVPLib.Driver.DriverConst.LoadLockA_IonGauge, AVPLib.Driver.DriverConst.LoadLockA_TurboForelineCG

                    Single.TryParse(value, canConvert)
                    If canConvert Then
                        result = Format(Convert.ToSingle(value), AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                    Else
                        result = value
                    End If
                Case Else
                    result = ParseValue(value)
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return result
    End Function
    Private Function ParseValue(ByVal value As String) As String
        Dim result As String = String.Empty

        Try

            Select Case value.ToUpper()
                Case "OPENED", "TRUE", "1", "ON"
                    result = "1"
                Case "CLOSED", "UNKNOWN", "FALSE", "0", "OFF"
                    result = "0"
                Case Else
                    Dim canConvert As Boolean = False
                    Single.TryParse(value, canConvert)

                    If canConvert Then
                        result = Convert.ToSingle(value)
                    Else
                        result = value
                    End If
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return result
    End Function

    Private Sub IOTab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CreateDataTable()
            m_bindingSource = New BindingSource()
            m_bindingSource.DataSource = m_dataTable
            dgvIOTab.DataSource = m_bindingSource

            Dim style As DataGridViewCellStyle = New DataGridViewCellStyle()
            style.Font = New Font("Tahoma", 16, FontStyle.Regular)
            dgvIOTab.Columns(0).HeaderCell.Style = style
            dgvIOTab.Columns(0).Width = 150
            dgvIOTab.Columns(1).HeaderCell.Style = style
            'dgvIOTab.Columns(1).Width = 785
            dgvIOTab.Columns(2).HeaderCell.Style = style
            dgvIOTab.Columns(2).Width = 150
            dgvIOTab.Columns(3).HeaderCell.Style = style
            dgvIOTab.Columns(3).Width = 150
            dgvIOTab.AutoGenerateColumns = False

            AddHandler m_Timer.Tick, AddressOf UpdateListAllDevices
            m_Timer.Interval = 1000
            m_Timer.Enabled = True

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New(ByVal ListAllDevice As Dictionary(Of String, PropertyObject))

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_ListAllDevice = ListAllDevice

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub UpdateListAllDevices(ByVal sender As Object, ByVal e As EventArgs)
        m_Timer.Enabled = False

        Try
            Dim itemvalue As String = String.Empty
            Dim datatableitemvalue As String = String.Empty
            Dim index As Integer = 0
            Dim result As String()
            Dim itemName As String = String.Empty

            For Each item As KeyValuePair(Of String, PropertyObject) In m_ListAllDevice
                If index >= m_dataTable.Rows.Count Then
                    Exit For
                End If
                Dim matchname As Match = Regex.Match(item.Key.ToString(), STR_NAMEPATTERN)
                If (matchname.Success) Then
                    itemName = matchname.Groups(1).ToString()
                Else
                    itemName = item.Key.ToString()
                End If

                If item.Value.GetValue() IsNot Nothing Then
                    'if CG then format value to 0.00E+00
                    itemvalue = FormatCGValue(itemName, item.Value.GetValue().ToString())
                End If

                If itemName.Contains("Alarm.AlarmStatus") Then
                    Dim objAlarm As AVPLib.DataManagerment.Alarm = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Alarm.ToString())
                    itemvalue = FormatCGValue(itemName, objAlarm.AlarmStatusIOtab)
                End If
                datatableitemvalue = m_dataTable.Rows(index)(VALUE_STR).ToString()

                If Not itemvalue.Equals(datatableitemvalue) Then
                    m_dataTable.Rows(index)(VALUE_STR) = itemvalue

                    If item.Value.RawValue = String.Empty Then
                        m_dataTable.Rows(index)(RAW_VALUE_STR) = itemvalue
                    Else
                        m_dataTable.Rows(index)(RAW_VALUE_STR) = ParseValue(item.Value.RawValue)
                    End If
                End If

                datatableitemvalue = m_dataTable.Rows(index)(DEVICE_STATUS_STR).ToString()
                result = datatableitemvalue.Split("-")
                Dim match As Match = Regex.Match(result(0).Trim().ToString(), STR_PATTERN)

                If match.Success Then
                    If (Driver.DriverManager.IsDeviceNetActive(Integer.Parse(match.Groups(1).ToString()))) Then
                        itemvalue = result(0).Trim().ToString() + STR_ACTIVE
                    Else
                        itemvalue = result(0).Trim().ToString() + STR_INACTIVE
                    End If

                    If Not itemvalue.Equals(datatableitemvalue) Then
                        m_dataTable.Rows(index)(DEVICE_STATUS_STR) = itemvalue
                    End If
                End If

                index += 1
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        m_Timer.Enabled = True
    End Sub

    Private Function IsTheSameCellValue(ByVal column As Integer, ByVal row As Integer) As Boolean
        Try

            If row + 1 < dgvIOTab.RowCount Then
                Dim cell1 As DataGridViewCell = dgvIOTab(column, row)
                Dim cell2 As DataGridViewCell = dgvIOTab(column, row + 1)

                If cell1.Value Is Nothing OrElse cell2.Value Is Nothing Then
                    Return False
                End If

                Return cell1.Value.ToString() = cell2.Value.ToString()
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return False
    End Function

    Private Sub dgvIOTab_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvIOTab.DataBindingComplete
        Try
            For i As Integer = 0 To dgvIOTab.Columns.Count - 1
                dgvIOTab.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            Dim firstRowSameData As Integer = 0
            Dim rowSpan As Integer = 1

            For rowIndex As Integer = 0 To dgvIOTab.RowCount - 1

                If IsTheSameCellValue(0, rowIndex) Then
                    rowSpan += 1
                Else

                    If rowSpan >= 1 Then

                        For i As Integer = firstRowSameData To firstRowSameData + rowSpan - 1
                            Dim pCell As AVPControls.VMergedCell = New AVPControls.VMergedCell()
                            pCell.AboveRow = firstRowSameData
                            pCell.BelowRow = firstRowSameData + rowSpan
                            Me.dgvIOTab.Rows(i).Cells(0) = pCell
                        Next
                    End If

                    firstRowSameData = rowIndex + 1
                    rowSpan = 1
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class