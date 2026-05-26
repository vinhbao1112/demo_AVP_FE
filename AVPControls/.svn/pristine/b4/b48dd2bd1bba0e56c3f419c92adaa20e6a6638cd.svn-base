Public Class Utils
    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-05-08 </date>
    ''' </author>
    ''' <summary>
    ''' Paint Border for panel
    ''' </summary>
    Public Shared Sub PaintBorder(ByVal sender As Control, ByVal e As System.Windows.Forms.PaintEventArgs, _
                            Optional ByVal top As Integer = 0)
        Try
            Dim x As Integer = 0
            Dim y As Integer = top
            Dim width As Integer = e.ClipRectangle.Width - 1
            Dim height As Integer = e.ClipRectangle.Height - y - 1
            Dim backColor As Color = Color.FromArgb(100, 145, 190)

            If sender IsNot Nothing Then
                width = sender.Width - 1
                height = sender.Height - y - 1
                If sender.BackColor <> Color.Transparent Then
                    backColor = sender.BackColor
                End If
            End If

            If width < 7 OrElse height < 7 Then
                Return
            End If

            If backColor = Color.White Then
                Dim pen1 As Pen = New Pen(Color.FromArgb(165, 165, 165))
                e.Graphics.DrawRectangle(pen1, x, y, width, height)

                Dim pen2 As Pen = New Pen(Color.FromArgb(185, 185, 185))
                e.Graphics.DrawRectangle(pen2, x + 1, y + 1, width - 2, height - 2)

                Dim pen3 As Pen = New Pen(Color.FromArgb(214, 214, 214))
                e.Graphics.DrawRectangle(pen3, x + 2, y + 2, width - 4, height - 4)

                Dim pen4 As Pen = New Pen(Color.FromArgb(238, 238, 238))
                e.Graphics.DrawRectangle(pen4, x + 3, y + 3, width - 6, height - 6)

                pen1.Dispose()
                pen2.Dispose()
                pen3.Dispose()
                pen4.Dispose()
            Else
                Dim pen1 As Pen = New Pen(Color.FromArgb(108, 126, 143))
                e.Graphics.DrawRectangle(pen1, x, y, width, height)

                Dim pen2 As Pen = New Pen(Color.FromArgb(113, 132, 150))
                e.Graphics.DrawRectangle(pen2, x + 1, y + 1, width - 2, height - 2)

                Dim pen3 As Pen = New Pen(Color.FromArgb(119, 138, 157))
                e.Graphics.DrawRectangle(pen3, x + 2, y + 2, width - 4, height - 4)

                Dim pen4 As Pen = New Pen(Color.FromArgb(83, 112, 142))
                e.Graphics.DrawRectangle(pen4, x + 3, y + 3, width - 6, height - 6)

                pen1.Dispose()
                pen2.Dispose()
                pen3.Dispose()
                pen4.Dispose()
            End If

            Dim brush As SolidBrush = New SolidBrush(backColor)
            e.Graphics.FillRectangle(brush, x + 4, y + 4, width - 7, height - 7)
            brush.Dispose()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''fix bug check Invalid Character when user input LotID, Seq, Recipe, WaferFlow Name
    Public Shared Function Clean_Invalid_Input(ByVal strIn As String) As String
        ' Replace invalid characters with empty strings.
        If strIn.StartsWith(".") Then
            strIn = strIn.Replace(".", "")
        End If
        Dim illegalChars As Char() = "\/:*?""><|".ToCharArray()
        For Each ch As Char In illegalChars
            strIn = strIn.Replace(ch, "")
        Next
        Return strIn
    End Function
End Class
