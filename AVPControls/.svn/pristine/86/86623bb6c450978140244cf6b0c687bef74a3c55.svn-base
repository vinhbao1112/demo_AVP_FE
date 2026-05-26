Public Class WaferFlowNodeControl

#Region "Fields"

    Private _isSelected As Boolean

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Gets or sets node label text
    ''' </summary>
    Public Property NodeText() As String
        Get
            Return lblName.Text
        End Get
        Set(ByVal value As String)
            lblName.Text = value
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether the node is selected.
    ''' </summary>
    Public Property IsSelected() As Boolean
        Get
            Return _isSelected
        End Get
        Set(ByVal value As Boolean)
            If _isSelected <> value Then
                _isSelected = value

                UpdateSelected()
            End If
        End Set
    End Property

#End Region

#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Forward click event.
    ''' </summary>
    Private Sub lblName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblName.Click
        MyBase.OnClick(e)
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Update selection state.
    ''' </summary>
    Private Sub UpdateSelected()
        If IsSelected Then
            Me.BackColor = Color.FromArgb(255, 92, 183, 255)
        Else
            Me.BackColor = SystemColors.Control
        End If
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Forward cursor.
    ''' </summary>
    Private Sub WaferFlowNodeControl_CursorChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.CursorChanged
        lblName.Cursor = Me.Cursor
    End Sub

#End Region

End Class
