Public Class PVDFactory
    Inherits AbstractFactory

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Create object configuration data of PVD
    ''' </summary>
    Public Overrides Function CreateConfigurationData() As BaseConfigurationData
        Return New PVDConfigurationData()
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Create object recipe of PVD
    ''' </summary>
    Public Overrides Function CreateRecipe() As BaseRecipe
        Return New PVDRecipe()
    End Function
End Class
