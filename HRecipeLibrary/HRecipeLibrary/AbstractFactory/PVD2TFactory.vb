Public Class PVD2TFactory
    Inherits AbstractFactory

    ''' <author>
    '''    	<name> Nguyen Dinh Minh Thi </name>
    '''    	<date> 2016-10-31 </date>
    ''' </author>
    ''' <summary>
    ''' Create object configuration data of PVD
    ''' </summary>
    Public Overrides Function CreateConfigurationData() As BaseConfigurationData
        Return New PVD2TConfigurationData()
    End Function

    ''' <author>
    '''    	<name> Nguyen Dinh Minh Thi </name>
    '''    	<date> 2016-10-31 </date>
    ''' </author>
    ''' <summary>
    ''' Create object recipe of PVD
    ''' </summary>
    Public Overrides Function CreateRecipe() As BaseRecipe
        Return New PVD2TRecipe()
    End Function
End Class
