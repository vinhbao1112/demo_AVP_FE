Public Class RIEFactory
    Inherits AbstractFactory

    Public Overrides Function CreateConfigurationData() As BaseConfigurationData
        Return New RIEConfigurationData()
    End Function

    Public Overrides Function CreateRecipe() As BaseRecipe
        Return New RIERecipe()
    End Function
End Class
