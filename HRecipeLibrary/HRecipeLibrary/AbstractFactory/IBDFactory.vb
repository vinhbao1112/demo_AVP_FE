Public Class IBDFactory
    Inherits AbstractFactory

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Create object configuration data of IBD
    ''' </summary>
    Public Overrides Function CreateConfigurationData() As BaseConfigurationData
        Return New IBDConfigurationData()
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Create object recipe of IBD
    ''' </summary>
    Public Overrides Function CreateRecipe() As BaseRecipe
        Return New IBDRecipe()
    End Function
End Class
