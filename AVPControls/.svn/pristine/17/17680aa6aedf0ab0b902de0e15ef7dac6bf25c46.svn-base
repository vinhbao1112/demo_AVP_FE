Imports AVPControls.AVPDataLib

''' <author>Hai Tran</author>
''' <date>2018-02-22</date>
''' <summary>
''' Select slot map.
''' </summary>
''' <remarks></remarks>
Public Class SelectSlotPanelControl

#Region "Fields"
    Private Const BOTTOMMAGRIN As Integer = 5
    Private Const BANK_WIDTH As Integer = 262
    Private Const WAFER_RADIUS As Integer = 60
    Private Const SPACE_BTW_WAFER As Integer = 15
    Private Const NUM_OF_WAFER_PER_COL As Integer = 4

    Private m_slotStatuses As WaferStatuses()
    Private m_waferControls As SlotMapWaferControl()
    Private m_checkBoxes As WaferCheckBox()
    Private m_isRaiseCheckedChanged As Boolean = True

#End Region

#Region "Events"
    Public Delegate Sub SlotCheckedChangedHandler(ByVal slot As Integer, ByVal checked As Boolean)

    ''' <author>Hai Tran</author>
    ''' <date>2018-03-22</date>
    ''' <summary>
    ''' Occurs when checked changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event CheckedChanged As SlotCheckedChangedHandler

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2018-02-22</date>
    ''' <summary>
    ''' Gets or sets wafer status at slot.
    ''' </summary>
    ''' <param name="slot"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SlotStatuses(ByVal slot As Integer) As WaferStatuses
        Get
            If slot >= 1 AndAlso slot <= m_slotStatuses.Length Then
                Return m_slotStatuses(slot - 1)
            End If
            Return WaferStatuses.NONE
        End Get
        Set(ByVal value As WaferStatuses)
            If slot >= 1 AndAlso slot <= m_slotStatuses.Length Then
                If m_slotStatuses(slot - 1) <> value Then
                    m_slotStatuses(slot - 1) = value
                    m_waferControls(slot - 1).WaferStatus = value
                End If
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-02-22</date>
    ''' <summary>
    ''' Gets or sets checked status at slot.
    ''' </summary>
    ''' <param name="slot"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CheckedStatus(ByVal slot As Integer) As Boolean
        Get
            If slot >= 1 AndAlso slot <= m_checkBoxes.Length Then
                Return m_checkBoxes(slot - 1).Checked
            End If
            Return False
        End Get
        Set(ByVal value As Boolean)
            If slot >= 1 AndAlso slot <= m_checkBoxes.Length Then
                m_isRaiseCheckedChanged = False
                m_checkBoxes(slot - 1).Checked = value
                m_isRaiseCheckedChanged = True
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2018-02-22</date>
    ''' <summary>
    ''' Gets number of slots.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Numslots() As Integer
        Get
            If m_slotStatuses IsNot Nothing Then
                Return m_slotStatuses.Length
            End If
            Return 0
        End Get
    End Property

#End Region


#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2018-02-22</date>
    ''' <summary>
    ''' Update slot status.
    ''' </summary>
    ''' <param name="slotStatuses"></param>
    ''' <remarks></remarks>
    Public Sub UpdateSlotStatus(ByVal slotStatuses As WaferStatuses())
        Try
            If slotStatuses IsNot Nothing Then
                m_slotStatuses = slotStatuses

                If m_waferControls IsNot Nothing Then
                    Array.Clear(m_waferControls, 0, m_waferControls.Length)
                End If

                ReDim Preserve m_waferControls(m_slotStatuses.Length - 1)

                If m_checkBoxes IsNot Nothing Then
                    For i As Integer = 0 To m_checkBoxes.Length - 1
                        RemoveHandler m_checkBoxes(i).CheckedChanged, AddressOf CheckBox_CheckedChanged
                    Next
                    Array.Clear(m_checkBoxes, 0, m_checkBoxes.Length)
                End If

                ReDim Preserve m_checkBoxes(m_slotStatuses.Length - 1)

                InitializeSlotMap()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-02-22</date>
    ''' <summary>
    ''' Initialize slot map on GUI.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitializeSlotMap()
        Try
            If (m_slotStatuses IsNot Nothing) Then
                Const LEFT_PADDING As Integer = 15
                Const BETWEEN_WAFER_PADDING As Integer = 40
                Const BETWEEN_WAFER_CHK_PADDING As Integer = 20

                Dim x As Integer = 0
                Dim y As Integer = 0
                Dim drawCount As Integer = 0
                Dim nextRowNumber As Integer = 0
                Dim slotNumber As Integer = 0
                Dim columnCount As Integer = CInt(Math.Floor(m_slotStatuses.Length / NUM_OF_WAFER_PER_COL))

                For i As Integer = 0 To (m_slotStatuses.Length - 1)
                    If i Mod NUM_OF_WAFER_PER_COL = 0 Then
                        nextRowNumber = NUM_OF_WAFER_PER_COL - 1
                        x = CInt(LEFT_PADDING + (i / NUM_OF_WAFER_PER_COL) * (WAFER_RADIUS + BETWEEN_WAFER_PADDING))
                        drawCount += 1
                    Else
                        nextRowNumber -= 1
                    End If

                    y = nextRowNumber * (WAFER_RADIUS + 5) + 5

                    ' Slot number
                    slotNumber = i + 1

                    Dim wcWafer As New SlotMapWaferControl()
                    wcWafer.BackColor = pnlGraph.BackColor
                    wcWafer.Text = slotNumber.ToString()
                    wcWafer.Size = New System.Drawing.Size(WAFER_RADIUS, WAFER_RADIUS)
                    wcWafer.WaferStatus = m_slotStatuses(slotNumber - 1)
                    wcWafer.Cursor = Cursors.Hand
                    wcWafer.Enabled = (m_slotStatuses(slotNumber - 1) <> WaferStatuses.NONE)
                    wcWafer.Location = New Point(x + BETWEEN_WAFER_CHK_PADDING, y)
                    wcWafer.ResumeUpdateView()

                    AddHandler wcWafer.Click, AddressOf WaferControl_Click
                    m_waferControls(slotNumber - 1) = wcWafer

                    Dim chkBar As New WaferCheckBox()
                    chkBar.ID = slotNumber
                    chkBar.Enabled = (m_slotStatuses(slotNumber - 1) <> WaferStatuses.NONE)
                    chkBar.Location = New Point(x, y + BETWEEN_WAFER_CHK_PADDING)

                    AddHandler chkBar.CheckedChanged, AddressOf CheckBox_CheckedChanged
                    m_checkBoxes(slotNumber - 1) = chkBar
                Next i

                pnlGraph.Controls.Clear()

                pnlGraph.Controls.AddRange(m_waferControls)
                pnlGraph.Controls.AddRange(m_checkBoxes)
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-02-22</date>
    ''' <summary>
    ''' Handles wafer click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub WaferControl_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim waferControl As SlotMapWaferControl = CType(sender, SlotMapWaferControl)
            Dim slotIndex As Integer = 0

            For Each item As SlotMapWaferControl In m_waferControls
                If item Is waferControl Then
                    Exit For
                Else
                    slotIndex += 1
                End If
            Next

            Dim chkWaferCheckBox As WaferCheckBox = CType(m_checkBoxes(slotIndex), WaferCheckBox)
            chkWaferCheckBox.Checked = Not chkWaferCheckBox.Checked
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-02-22</date>
    ''' <summary>
    ''' Handles checked changed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Not m_isRaiseCheckedChanged Then
                Return
            End If

            Dim checkBoxControl As CheckBox = CType(sender, CheckBox)
            Dim slot As Integer

            For i As Integer = 0 To m_checkBoxes.Length - 1
                If ReferenceEquals(m_checkBoxes(i), checkBoxControl) Then
                    slot = i + 1
                    Exit For
                End If
            Next

            RaiseEvent CheckedChanged(slot, checkBoxControl.Checked)
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

#End Region

End Class
