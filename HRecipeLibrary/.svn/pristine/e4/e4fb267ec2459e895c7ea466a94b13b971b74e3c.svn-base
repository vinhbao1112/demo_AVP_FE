Public Class PVDConfigurationData
    Inherits GeneralConfigurationData

#Region "properties"

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Chuck Position TSD Ref
    ''' </summary>
    Private _chuckPositionTSDRef As Boolean = False
    Public Property Chuck_Position_TSD_Ref() As Boolean
        Get
            Return _chuckPositionTSDRef
        End Get
        Set(ByVal value As Boolean)
            _chuckPositionTSDRef = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Parallel Visible
    ''' </summary>
    Private _parallelMagnetInstalled As Boolean = False
    Public Property Parallel_Magnet_Installed() As Boolean
        Get
            Return _parallelMagnetInstalled
        End Get
        Set(ByVal value As Boolean)
            _parallelMagnetInstalled = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Flowcool Visible
    ''' </summary>
    Private _flowCoolInstalled As Boolean = False
    Public Property FlowCool_Installed() As Boolean
        Get
            Return _flowCoolInstalled
        End Get
        Set(ByVal value As Boolean)
            _flowCoolInstalled = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set BackSideFlowCoolHe Visible
    ''' </summary>
    Private _flowCoolInstalledBackSideFlowCoolHe As String = String.Empty
    Public Property FlowCool_Installed_BackSideFlowCoolHe() As String
        Get
            Return _flowCoolInstalledBackSideFlowCoolHe
        End Get
        Set(ByVal value As String)
            _flowCoolInstalledBackSideFlowCoolHe = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-08-31 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Chiller_Installed Visible
    ''' </summary>
    Private _chillerInstalled As Boolean = False
    Public Property Chiller_Installed() As Boolean
        Get
            Return _chillerInstalled
        End Get
        Set(ByVal value As Boolean)
            _chillerInstalled = value
        End Set
    End Property

#End Region

#Region "support function"

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' check if PVD Target Power Supply is installed
    ''' </summary>
    Public Overrides Function IsPVDDCTargetPowerSupplyInstalled() As Boolean
        Return Target_Power_Supply_DC_Installed
    End Function

#End Region

End Class
