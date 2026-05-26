Imports System.ComponentModel

Public Class TurboControl

#Region "Fields"

    Private _hasWaterPump As Boolean = False


#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2019-11-07</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether Water Pump is installed.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(False)> _
    Public Property HasWaterPump() As Boolean
        Get
            Return _hasWaterPump
        End Get
        Set(ByVal value As Boolean)
            If _hasWaterPump <> value Then
                _hasWaterPump = value

                UpdateView()
            End If
        End Set
    End Property

#End Region

#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2019-11-07</date>
    ''' <summary>
    ''' Generate turbo image.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Try
            Dim img As Bitmap = Nothing

            If Me.ChamberType = AVPControls.AVPDataLib.AVPChamberTypes.PVDA_SA Then
                If HasWaterPump Then
                    img = My.Resources.PVDA_Turbo_With_WaterPump
                Else
                    img = My.Resources.PVDA_Turbo
                End If
            End If

            Return img
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

#End Region

End Class
