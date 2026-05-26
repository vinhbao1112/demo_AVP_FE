Imports AVPControls.AVPDataLib

''' <author>Hai Tran</author>
''' <date>2018-03-22</date>
''' <summary>
''' Select slot form.
''' </summary>
''' <remarks></remarks>
Public Class SelectSlotWaferDialog

#Region "Fields"

    Private m_multipleSelection As Boolean
    Private m_selectedSlot As Integer = 0
    Private m_selectedSlots As New List(Of Integer)

#End Region

#Region "Constructors"

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-22</date>
    ''' <summary>
    ''' Initialize form for selecting slot.
    ''' </summary>
    ''' <param name="slotStatuses"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal slotStatuses As WaferStatuses())

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SlotPanelControl.UpdateSlotStatus(slotStatuses)

        UpdateEnabledOKButton()
    End Sub

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-22</date>
    ''' <summary>
    ''' Enables/Disables multiple selection.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MultipleSelection() As Boolean
        Get
            Return m_multipleSelection
        End Get
        Set(ByVal value As Boolean)
            m_multipleSelection = value
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-22</date>
    ''' <summary>
    ''' Gets selected slot.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedSlot() As Integer
        Get
            Return m_selectedSlot
        End Get
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-22</date>
    ''' <summary>
    ''' Gets list selected slot when multiple selection is enabled.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedSlots() As Integer()
        Get
            Return m_selectedSlots.ToArray()
        End Get
    End Property

#End Region

#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2018-02-22</date>
    ''' <summary>
    ''' Handles OK button click.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-02-22</date>
    ''' <summary>
    ''' Handles cancel button click.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            m_selectedSlot = 0
            m_selectedSlots.Clear()
            DoClose()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-02-22</date>
    ''' <summary>
    ''' Handles slot checked changed.
    ''' </summary>
    Private Sub SlotPanelControl_CheckedChanged(ByVal slot As Integer, ByVal checked As Boolean) Handles SlotPanelControl.CheckedChanged
        Try
            If m_multipleSelection Then
                If checked Then
                    m_selectedSlot = slot
                End If
            Else
                If checked Then
                    For i As Integer = 1 To SlotPanelControl.Numslots
                        If i <> slot Then
                            SlotPanelControl.CheckedStatus(i) = False
                        End If
                    Next

                    m_selectedSlot = slot
                Else
                    m_selectedSlot = 0
                End If
            End If

            If checked Then
                If Not m_selectedSlots.Contains(slot) Then
                    m_selectedSlots.Add(slot)
                End If
            Else
                m_selectedSlots.Remove(slot)
            End If

            UpdateEnabledOKButton()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-02-22</date>
    ''' <summary>
    ''' Update enabled OK button.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateEnabledOKButton()
        Try
            Dim isEnabled As Boolean = False

            For i As Integer = 1 To SlotPanelControl.Numslots
                If SlotPanelControl.CheckedStatus(i) Then
                    isEnabled = True
                    Exit For
                End If
            Next

            btnOK.Enabled = isEnabled
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

#End Region

#Region "Shared Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2018-02-22</date>
    ''' <summary>
    ''' Show dialog to select a slot.
    ''' </summary>
    ''' <param name="slotStatuses"></param>
    ''' <param name="title"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ShowSelectSlot(ByVal slotStatuses As WaferStatuses(), Optional ByVal title As String = "") As Integer
        Dim selectedSlot As Integer = 0
        Try
            Dim dialog As New SelectSlotWaferDialog(slotStatuses)
            If Not String.IsNullOrEmpty(title) Then
                dialog.Text = title
            End If

            If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                selectedSlot = dialog.SelectedSlot
            End If
            dialog.Dispose()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return selectedSlot
    End Function

#End Region

End Class