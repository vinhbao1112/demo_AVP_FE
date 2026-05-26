Public Class PVD2TCryoControl

#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2025-06-24</date>
    ''' <summary>
    ''' Returns image of control.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Return My.Resources.Resources.PVD2T_Chamber_TopCryo
    End Function

#End Region

End Class
