Public Class PVDSConfigurationData
    Inherits GeneralConfigurationData

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Pbn Gas Name
    ''' </summary>
    Private _pbnGasInstalledName As String = String.Empty
    Public Property PBNGas_Installed_Name() As String
        Get
            Return _pbnGasInstalledName
        End Get
        Set(ByVal value As String)
            _pbnGasInstalledName = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Pbn Gas Type
    ''' </summary>
    Private _pbnGasInstalledCalibrationFactorId As String = String.Empty
    Public Property PBNGas_Installed_CalibrationFactorId() As String
        Get
            Return _pbnGasInstalledCalibrationFactorId
        End Get
        Set(ByVal value As String)
            _pbnGasInstalledCalibrationFactorId = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Nguyen Dinh Minh Thi </name>
    '''    	<date> 2017-01-23 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set ANC Installed
    ''' </summary>
    Private _ancInstalled As Boolean = False
    Public Property ANC_Installed() As Boolean
        Get
            Return _ancInstalled
        End Get
        Set(ByVal value As Boolean)
            _ancInstalled = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-04-04 </date>
    ''' </author>
    ''' <summary>
    ''' Support Filt Sweep Mode
    ''' </summary>
    Private _bSupportTiltSweepMode As Boolean = False
    Public Property SupportTiltSweepMode() As Boolean
        Get
            Return _bSupportTiltSweepMode
        End Get
        Set(ByVal value As Boolean)
            _bSupportTiltSweepMode = value
        End Set
    End Property


    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-05-24 </date>
    ''' </author>
    ''' <summary>
    ''' Support Filt Sweep Mode
    ''' </summary>
    Private _blBackTilt_Installed As Boolean = False
    Public Property BackTilt_Installed() As Boolean
        Get
            Return _blBackTilt_Installed
        End Get
        Set(ByVal value As Boolean)
            _blBackTilt_Installed = value
        End Set
    End Property


    ''' <author>
    '''    	<name> Dy Do</name>
    '''    	<date> 2019-03-11 </date>
    ''' </author>
    ''' <summary>
    ''' Support Diverter Gas Valve Installed
    ''' </summary>
    Private _diverterGasValveInstalled As Boolean = False
    Public Property DiverterGasValveInstalled() As Boolean
        Get
            Return _diverterGasValveInstalled
        End Get
        Set(ByVal value As Boolean)
            _diverterGasValveInstalled = value
        End Set
    End Property

End Class
