Public Class PVD4Factory
    Inherits AbstractFactory

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Create object configuration data of PVD4
    ''' </summary>
    Public Overrides Function CreateConfigurationData() As BaseConfigurationData
        Return New PVD4ConfigurationData()
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Create object recipe of PVD4
    ''' </summary>
    Public Overrides Function CreateRecipe() As BaseRecipe
        Return New PVD4Recipe()
    End Function
End Class
