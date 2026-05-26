
''' <author>Hai Tran</author>
''' <date>2017-10-05</date>
''' <summary>
''' Event args for CheckChanged event.
''' </summary>
Public Class CheckChangedEventArgs
    Inherits EventArgs

#Region "Fields"

    Private _checked As Boolean
    Private _columnIndex As Integer

#End Region

#Region "Constructor"

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Constructs args.
    ''' </summary>
    Public Sub New(ByVal checked As Boolean, ByVal columnIndex As Integer)
        _checked = checked
        _columnIndex = columnIndex
    End Sub

#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Gets current checked state.
    ''' </summary>
    Public ReadOnly Property Checked() As Boolean
        Get
            Return _checked
        End Get
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Gets column index that occurred event.
    ''' </summary>
    Public ReadOnly Property ColumnIndex() As Integer
        Get
            Return _columnIndex
        End Get
    End Property

#End Region

End Class
