Public Class PopUpHidenColumns
#Region "Variable and Property"
    Private m_chamberName As String = String.Empty
    Private m_lstHidenCol As List(Of String)

    Public ReadOnly Property ListOfHidenColumns() As List(Of String)
        Get
            Return m_lstHidenCol
        End Get
    End Property

#End Region

#Region "Sub and Event"
    Public Sub New(ByVal listOfColumns As List(Of String), ByVal strChamber As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Try
            lstShowColumns.ColumnWidth = 250
            For Each strcol As String In listOfColumns
                lstShowColumns.Items.Add(strcol)
            Next
            m_chamberName = strChamber
            Dim listHidenColumn As List(Of String) = AVPLib.ContainerData.HidenColumnInDataRun(m_chamberName)
            If listHidenColumn Is Nothing Then
                Exit Sub
            End If
            For Each strHidenCol As String In listHidenColumn
                lstShowColumns.Items.Remove(strHidenCol)
                lstHideColumns.Items.Add(strHidenCol)
            Next
            lstHideColumns.Sorted = True
            lstShowColumns.Sorted = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overrides Sub DoClose()
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            Dim listHidenColumn As List(Of String) = AVPLib.ContainerData.HidenColumnInDataRun(m_chamberName)
            If listHidenColumn Is Nothing Then
                Me.Close()
            End If

            listHidenColumn.Clear()
            For Each item As Object In lstHideColumns.Items
                listHidenColumn.Add(item.ToString)
            Next

            m_lstHidenCol = listHidenColumn
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            For Each item As Object In lstShowColumns.SelectedItems
                lstHideColumns.Items.Add(item)
            Next
            lstHideColumns.Sorted = True
            While (lstShowColumns.SelectedItems.Count > 0)
                lstShowColumns.Items.Remove(lstShowColumns.SelectedItems.Item(0))
            End While
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            For Each item As Object In lstHideColumns.SelectedItems
                lstShowColumns.Items.Add(item)
            Next
            lstShowColumns.Sorted = True
            While (lstHideColumns.SelectedItems.Count > 0)
                lstHideColumns.Items.Remove(lstHideColumns.SelectedItems.Item(0))
            End While
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnAddAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAll.Click
        Try
            For Each item As Object In lstShowColumns.Items
                lstHideColumns.Items.Add(item)
            Next
            lstHideColumns.Sorted = True
            lstShowColumns.Items.Clear()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click
        Try
            For Each item As Object In lstHideColumns.Items
                lstShowColumns.Items.Add(item)
            Next
            lstShowColumns.Sorted = True
            lstHideColumns.Items.Clear()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
   
   
End Class