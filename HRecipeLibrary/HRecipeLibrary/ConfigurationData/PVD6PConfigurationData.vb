Public Class PVD6PConfigurationData
    Inherits GeneralConfigurationData

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set DC Target Power Supply 1
    ''' </summary>
    Private _targetPowerSupply1DCInstalled As Boolean = False
    Public Property Target_Power_Supply1_DC_Installed() As Boolean
        Get
            Return _targetPowerSupply1DCInstalled
        End Get
        Set(ByVal value As Boolean)
            _targetPowerSupply1DCInstalled = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set DC Target Power Supply 2
    ''' </summary>
    Private _targetPowerSupply2DCInstalled As Boolean = False
    Public Property Target_Power_Supply2_DC_Installed() As Boolean
        Get
            Return _targetPowerSupply2DCInstalled
        End Get
        Set(ByVal value As Boolean)
            _targetPowerSupply2DCInstalled = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set DC Target Power Supply 3
    ''' </summary>
    Private _targetPowerSupply3DCInstalled As Boolean = False
    Public Property Target_Power_Supply3_DC_Installed() As Boolean
        Get
            Return _targetPowerSupply3DCInstalled
        End Get
        Set(ByVal value As Boolean)
            _targetPowerSupply3DCInstalled = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set DC Target Power Model 1
    ''' </summary>
    Private _targetPowerSupply1DCInstalledWhichModel As String = String.Empty
    Public Property Target_Power_Supply1_DC_Installed_WhichModel() As String
        Get
            Return _targetPowerSupply1DCInstalledWhichModel
        End Get
        Set(ByVal value As String)
            _targetPowerSupply1DCInstalledWhichModel = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set DC Target Power Model 2
    ''' </summary>
    Private _targetPowerSupply2DCInstalledWhichModel As String = String.Empty
    Public Property Target_Power_Supply2_DC_Installed_WhichModel() As String
        Get
            Return _targetPowerSupply2DCInstalledWhichModel
        End Get
        Set(ByVal value As String)
            _targetPowerSupply2DCInstalledWhichModel = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set DC Target Power Model 3
    ''' </summary>
    Private _targetPowerSupply3DCInstalledWhichModel As String = String.Empty
    Public Property Target_Power_Supply3_DC_Installed_WhichModel() As String
        Get
            Return _targetPowerSupply3DCInstalledWhichModel
        End Get
        Set(ByVal value As String)
            _targetPowerSupply3DCInstalledWhichModel = value
        End Set
    End Property

End Class
