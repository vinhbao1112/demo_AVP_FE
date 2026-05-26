Public MustInherit Class AbstractFactory

    Public MustOverride Function CreateConfigurationData() As BaseConfigurationData
    Public MustOverride Function CreateRecipe() As BaseRecipe

End Class
