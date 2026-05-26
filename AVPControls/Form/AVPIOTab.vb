Imports System


Public Class AVPIOTab
    Private Const DEVICE_STATUS_STR As String = "Device Status"
    Private Const ITEM_NAME_STR As String = "Item Name"
    Private Const VALUE_STR As String = "Value"
    Private Const RAW_VALUE_STR As String = "Raw Value"
    Private Const STR_PATTERN As String = "MacID([0-9]+)"
    Private Const STR_NAMEPATTERN As String = "MacID\\d+.(.*)"
    Public Const STR_ACTIVE As String = " - ACTIVE"
    Public Const STR_INACTIVE As String = " - INACTIVE"

    Private bs As BindingSource = Nothing
    Private dt As DataTable = Nothing


    Private Sub CreateDataTable()
        Try
            dt = New DataTable()
            dt.Columns.Add(DEVICE_STATUS_STR)
            dt.Columns.Add(ITEM_NAME_STR)
            dt.Columns.Add(VALUE_STR)
            dt.Columns.Add(RAW_VALUE_STR)


        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub AVPIOTab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CreateDataTable()
            bs = New BindingSource()
            bs.DataSource = dt
            GridViewIO.DataSource = bs
            'Dim style As DataGridViewCellStyle = New DataGridViewCellStyle()
            'style.Font = New Font("Tahoma", 16, FontStyle.Bold)
            'GridViewIO.Columns[0].HeaderCell.Style = style
            'GridViewIO.Columns[0].Width = 150
            'GridViewIO.Columns[0].Width = 150
            'GridViewIO.Columns[1].HeaderCell.Style = style
            'GridViewIO.Columns[2].HeaderCell.Style = style
            'GridViewIO.Columns[2].Width = 150
            'GridViewIO.Columns[3].HeaderCell.Style = style
            'GridViewIO.Columns[3].Width = 150
            GridViewIO.AutoGenerateColumns = False

        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class