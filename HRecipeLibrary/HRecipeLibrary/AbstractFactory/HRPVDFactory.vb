Public Class HRPVDFactory
    Inherits AbstractFactory

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Create object configuration data of HRPVD
    ''' </summary>
    Public Overrides Function CreateConfigurationData() As BaseConfigurationData
        Return New HRPVDConfigurationData()
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Create object recipe of HRPVD
    ''' </summary>
    Public Overrides Function CreateRecipe() As BaseRecipe
        Return New HRPVDRecipe()
    End Function
End Class
