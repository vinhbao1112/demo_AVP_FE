Imports System.ComponentModel
Imports AVPControls.AVPDataLib
Public Class IBDVeeCoTargetControl

#Region "Fields"
    Private m_targetText As String = String.Empty
#End Region

#Region "Properties"
    <DefaultValue("")> _
    Public Property TargetText() As String
        Get
            Return m_targetText
        End Get
        Set(ByVal value As String)
            If m_targetText <> value Then
                m_targetText = value
                UpdateView()
            End If
        End Set
    End Property
#End Region

#Region "Methods"

    ''' <author>Dy Do</author>
    ''' <date>2019-06-14</date>
    ''' <summary>
    ''' Returns image of control.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap

        Dim targetImage As Bitmap = My.Resources.IBDVeeCo_6Targets
        Try
            Using g As Graphics = Graphics.FromImage(targetImage)
                ' Draw chuck text.
                Dim f As New Font("Times New Roman", 11, FontStyle.Bold, GraphicsUnit.Point)
                If Not String.IsNullOrEmpty(TargetText) Then
                    g.DrawString(TargetText, f, Brushes.Black, 23, 22)
                End If
                f.Dispose()

            End Using
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return targetImage
    End Function

#End Region
  
End Class
