Public Class PVD6PFactory
    Inherits AbstractFactory

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Create object configuration data of PVD6P
    ''' </summary>
    Public Overrides Function CreateConfigurationData() As BaseConfigurationData
        Return New PVD6PConfigurationData()
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Create object recipe of PVD6P
    ''' </summary>
    Public Overrides Function CreateRecipe() As BaseRecipe
        Return New PVD6PRecipe()
    End Function
End Class
