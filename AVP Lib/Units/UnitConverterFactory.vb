Public Class UnitConverterFactory
    Public Shared Function Create() As IUnitConverter
        Return New UnitConverter()
    End Function
End Class
