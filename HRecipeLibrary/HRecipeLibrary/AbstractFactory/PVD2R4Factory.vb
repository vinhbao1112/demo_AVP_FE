Public Class PVD2R4Factory
    Inherits AbstractFactory

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Create object configuration data of PVD2R4
    ''' </summary>
    Public Overrides Function CreateConfigurationData() As BaseConfigurationData
        Return New PVD2R4ConfigurationData()
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Create object recipe of PVD2R4
    ''' </summary>
    Public Overrides Function CreateRecipe() As BaseRecipe
        Return New PVD2R4Recipe()
    End Function
End Class
