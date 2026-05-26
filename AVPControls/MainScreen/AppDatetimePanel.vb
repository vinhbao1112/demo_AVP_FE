Imports System.ComponentModel

''' <author>
'''     <name>Hai Tran</name>
'''     <date>2015-10-01</date>
''' </author>
''' <summary>
''' Datetime panel.
''' </summary>
''' <remarks></remarks>
Public Class AppDatetimePanel
    Public Event DateChanged As EventHandler

    Public Property [Date]() As String
        Get
            Return labDate.Text
        End Get
        Set(ByVal value As String)
            If labDate.Text <> value Then
                labDate.Text = value
                RaiseEvent DateChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property Time() As String
        Get
            Return labHour.Text
        End Get
        Set(ByVal value As String)
            labHour.Text = value
        End Set
    End Property

#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <summary>
    ''' Update GUI on background size changed.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub OnBackgroundSizeChanged()
        Try
            Dim margin As Integer
            Dim space As Integer
            Select Case BackgroundSize
                Case PanelBackgroundSizes.Size1
                    margin = 3
                    space = 3
                Case Else
                    margin = 12
                    space = 5
            End Select

            Dim textWidth As Integer = CInt((Me.Width - (margin * 2 + 1) - space) / 2)

            labDate.Width = textWidth
            labHour.Width = textWidth

            labDate.Left = margin + 1
            labHour.Left = margin + textWidth + space

        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

#End Region

End Class
