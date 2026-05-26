
''' <author>Hai Tran</author>
''' <date>2017-10-05</date>
''' <summary>
''' Header cell with check box.
''' </summary>
Public Class DataGridViewCheckBoxHeaderCell
    Inherits DataGridViewColumnHeaderCell

#Region "Fields"

    Private _checked As Boolean = True

#End Region

#Region "Events"

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Occurs when checked state is changing.
    ''' </summary>
    Public Event CheckChanging As EventHandler(Of CheckChangingEventArgs)

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Occurs when checked state is changed.
    ''' </summary>
    Public Event CheckChanged As EventHandler(Of CheckChangedEventArgs)

#End Region

#Region "Constructors"

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Header cell with check box.
    ''' </summary>
    Public Sub New()
    End Sub

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Gets or sets checked state.
    ''' </summary>
    Public Property Checked() As Boolean
        Get
            Return _checked
        End Get
        Set(ByVal value As Boolean)
            If _checked <> value Then
                Dim checkChangingArg As New CheckChangingEventArgs(_checked, Me.ColumnIndex)
                RaiseEvent CheckChanging(Me, checkChangingArg)

                If Not checkChangingArg.IsHandled Then
                    _checked = value

                    If DataGridView IsNot Nothing Then
                        Me.DataGridView.InvalidateCell(Me)
                    End If

                    Dim checkChangedArg As New CheckChangedEventArgs(_checked, Me.ColumnIndex)
                    RaiseEvent CheckChanged(Me, checkChangedArg)
                End If
            End If
        End Set
    End Property

#End Region

#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Paint check box.
    ''' </summary>
    Protected Overrides Sub Paint(ByVal graphics As System.Drawing.Graphics, ByVal clipBounds As System.Drawing.Rectangle, ByVal cellBounds As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal dataGridViewElementState As DataGridViewElementStates, ByVal value As Object, _
    ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)

        MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, _
         formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)

        Dim s As Size = CheckBoxRenderer.GetGlyphSize(graphics, System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal)
        Dim checkBoxLocation As New Point()
        checkBoxLocation.X = cellBounds.Location.X + 10
        checkBoxLocation.Y = cellBounds.Location.Y + (cellBounds.Height / 2) - (s.Height / 2)

        Dim cbState As VisualStyles.CheckBoxState
        If Checked Then
            cbState = VisualStyles.CheckBoxState.CheckedNormal
        Else
            cbState = VisualStyles.CheckBoxState.UncheckedNormal
        End If

        CheckBoxRenderer.DrawCheckBox(graphics, checkBoxLocation, cbState)
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Handles mouse click.
    ''' </summary>
    Protected Overrides Sub OnMouseClick(ByVal e As DataGridViewCellMouseEventArgs)
        MyBase.OnMouseClick(e)

        If e.Button = MouseButtons.Left Then
            Checked = Not Checked
        End If
    End Sub

#End Region

End Class
