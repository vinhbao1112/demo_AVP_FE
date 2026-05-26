Public Class PVDAConfigurationData
    Inherits GeneralConfigurationData

#Region "properties"

    ''' <author>
    '''    	<name> Nguyen Dinh Minh Thi </name>
    '''    	<date> 2016-10-31 </date>
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

#End Region

#Region "support function"

    ''' <author>
    '''    	<name> Nguyen Dinh Minh Thi </name>
    '''    	<date> 2016-10-31 </date>
    ''' </author>
    ''' <summary>
    ''' check if PVD Target Power Supply is installed
    ''' </summary>
    Public Overrides Function IsPVDDCTargetPowerSupplyInstalled() As Boolean
        Return Target_Power_Supply_DC_Installed
    End Function


    ''' <author>
    '''    	<name> Tran Cao Dua </name>
    '''    	<date> 2019-12-16 </date>
    ''' </author>
    ''' <summary>
    ''' PhaseAngleVisible
    ''' </summary>
    Private m_bPhase_Shifter_Angle_Installed As Boolean = False
    Public Property Phase_Shifter_Angle_Installed() As Boolean
        Get
            Return m_bPhase_Shifter_Angle_Installed
        End Get
        Set(ByVal value As Boolean)
            m_bPhase_Shifter_Angle_Installed = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoai Ly </name>
    '''    	<date> 2023-03-03 </date>
    ''' </author>
    ''' <summary>
    ''' PhaseAngleOnly
    ''' </summary>
    Private m_bPhase_Shifter_Angle_Installed_WhichModel As String = String.Empty
    Public Property Phase_Shifter_Angle_Installed_WhichModel() As String
        Get
            Return m_bPhase_Shifter_Angle_Installed_WhichModel
        End Get
        Set(ByVal value As String)
            m_bPhase_Shifter_Angle_Installed_WhichModel = value
        End Set
    End Property

#End Region

End Class
