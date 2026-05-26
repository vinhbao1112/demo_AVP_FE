Public Class LLConfigPanel
    ' LoadLock config name
    Public Const STR_NUMBER_OF_SLOTS As String = "NumberOfSlots"
    Public Const STR_TRAVEL_LENGTH As String = "TravelLength"
    Public Const STR_PITCH As String = "Pitch"
    Public Const STR_BASE_OFFSET As String = "BaseOffset"
    Public Const STR_FIND_BIAS As String = "FindBias"

    Protected Overrides ReadOnly Property DefaultSize() As System.Drawing.Size
        Get
            Return New Size(250, 207)
        End Get
    End Property

    Public Overrides Sub SetData(ByVal configItem As StoredConfigData)
        Try
            If configItem Is Nothing Then
                Return
            End If
            Me.NumberOfSlots.Text = configItem.Data(STR_NUMBER_OF_SLOTS)
            Me.TravelLength.Text = configItem.Data(STR_TRAVEL_LENGTH)
            Me.Pitch.Text = configItem.Data(STR_PITCH)
            Me.BaseOffset.Text = configItem.Data(STR_BASE_OFFSET)
            Me.FindBias.Text = configItem.Data(STR_FIND_BIAS)
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

End Class
