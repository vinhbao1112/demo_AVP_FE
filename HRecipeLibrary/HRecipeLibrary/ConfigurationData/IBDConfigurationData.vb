Public Class IBDConfigurationData
    Inherits BaseConfigurationData

#Region "Dep"

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Gas1 Type
    ''' </summary>
    Private _depGas1MFCEnableCalibrationFactorId As String = String.Empty
    Public Property DepGas1MFCEnable_CalibrationFactorId() As String
        Get
            Return _depGas1MFCEnableCalibrationFactorId
        End Get
        Set(ByVal value As String)
            _depGas1MFCEnableCalibrationFactorId = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Gas1 Shutoff Present
    ''' </summary>
    Private _depGas1MFCEnableHasShutOffValve As Boolean = False
    Public Property DepGas1MFCEnable_HasShutOffValve() As Boolean
        Get
            Return _depGas1MFCEnableHasShutOffValve
        End Get
        Set(ByVal value As Boolean)
            _depGas1MFCEnableHasShutOffValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Gas1 Supply Present
    ''' </summary>
    Private _depGas1MFCEnableHasSupplyValve As Boolean = False
    Public Property DepGas1MFCEnable_HasSupplyValve() As Boolean
        Get
            Return _depGas1MFCEnableHasSupplyValve
        End Get
        Set(ByVal value As Boolean)
            _depGas1MFCEnableHasSupplyValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Gas2 Type
    ''' </summary>
    Private _depGas2MFCEnableCalibrationFactorId As String = String.Empty
    Public Property DepGas2MFCEnable_CalibrationFactorId() As String
        Get
            Return _depGas2MFCEnableCalibrationFactorId
        End Get
        Set(ByVal value As String)
            _depGas2MFCEnableCalibrationFactorId = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Gas2 Shutoff Present
    ''' </summary>
    Private _depGas2MFCEnableHasShutOffValve As Boolean = False
    Public Property DepGas2MFCEnable_HasShutOffValve() As Boolean
        Get
            Return _depGas2MFCEnableHasShutOffValve
        End Get
        Set(ByVal value As Boolean)
            _depGas2MFCEnableHasShutOffValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Gas2 Supply Present
    ''' </summary>
    Private _depGas2MFCEnableHasSupplyValve As Boolean = False
    Public Property DepGas2MFCEnable_HasSupplyValve() As Boolean
        Get
            Return _depGas2MFCEnableHasSupplyValve
        End Get
        Set(ByVal value As Boolean)
            _depGas2MFCEnableHasSupplyValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Gas3 Type
    ''' </summary>
    Private _depGas3MFCEnableCalibrationFactorId As String = String.Empty
    Public Property DepGas3MFCEnable_CalibrationFactorId() As String
        Get
            Return _depGas3MFCEnableCalibrationFactorId
        End Get
        Set(ByVal value As String)
            _depGas3MFCEnableCalibrationFactorId = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Gas3 Shutoff Present
    ''' </summary>
    Private _depGas3MFCEnableHasShutOffValve As Boolean = False
    Public Property DepGas3MFCEnable_HasShutOffValve() As Boolean
        Get
            Return _depGas3MFCEnableHasShutOffValve
        End Get
        Set(ByVal value As Boolean)
            _depGas3MFCEnableHasShutOffValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Gas3 Supply Present
    ''' </summary>
    Private _depGas3MFCEnableHasSupplyValve As Boolean = False
    Public Property DepGas3MFCEnable_HasSupplyValve() As Boolean
        Get
            Return _depGas3MFCEnableHasSupplyValve
        End Get
        Set(ByVal value As Boolean)
            _depGas3MFCEnableHasSupplyValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Gas4 Type
    ''' </summary>
    Private _depGas4MFCEnableCalibrationFactorId As String = String.Empty
    Public Property DepGas4MFCEnable_CalibrationFactorId() As String
        Get
            Return _depGas4MFCEnableCalibrationFactorId
        End Get
        Set(ByVal value As String)
            _depGas4MFCEnableCalibrationFactorId = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Gas4 Shutoff Present
    ''' </summary>
    Private _depGas4MFCEnableHasShutOffValve As Boolean = False
    Public Property DepGas4MFCEnable_HasShutOffValve() As Boolean
        Get
            Return _depGas4MFCEnableHasShutOffValve
        End Get
        Set(ByVal value As Boolean)
            _depGas4MFCEnableHasShutOffValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Gas4 Supply Present
    ''' </summary>
    Private _depGas4MFCEnableHasSupplyValve As Boolean = False
    Public Property DepGas4MFCEnable_HasSupplyValve() As Boolean
        Get
            Return _depGas4MFCEnableHasSupplyValve
        End Get
        Set(ByVal value As Boolean)
            _depGas4MFCEnableHasSupplyValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Gas5 Type
    ''' </summary>
    Private _depGas5MFCEnableCalibrationFactorId As String = String.Empty
    Public Property DepGas5MFCEnable_CalibrationFactorId() As String
        Get
            Return _depGas5MFCEnableCalibrationFactorId
        End Get
        Set(ByVal value As String)
            _depGas5MFCEnableCalibrationFactorId = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Gas5 Shutoff Present
    ''' </summary>
    Private _depGas5MFCEnableHasShutOffValve As Boolean = False
    Public Property DepGas5MFCEnable_HasShutOffValve() As Boolean
        Get
            Return _depGas5MFCEnableHasShutOffValve
        End Get
        Set(ByVal value As Boolean)
            _depGas5MFCEnableHasShutOffValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Gas5 Supply Present
    ''' </summary>
    Private _depGas5MFCEnableHasSupplyValve As Boolean = False
    Public Property DepGas5MFCEnable_HasSupplyValve() As Boolean
        Get
            Return _depGas5MFCEnableHasSupplyValve
        End Get
        Set(ByVal value As Boolean)
            _depGas5MFCEnableHasSupplyValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Pbn Gas Name
    ''' </summary>
    Private _depPBNGasInstalledName As String = String.Empty
    Public Property DepPBNGas_Installed_Name() As String
        Get
            Return _depPBNGasInstalledName
        End Get
        Set(ByVal value As String)
            _depPBNGasInstalledName = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep Pbn Gas Type
    ''' </summary>
    Private _depPBNGasInstalledCalibrationFactorId As String = String.Empty
    Public Property DepPBNGas_Installed_CalibrationFactorId() As String
        Get
            Return _depPBNGasInstalledCalibrationFactorId
        End Get
        Set(ByVal value As String)
            _depPBNGasInstalledCalibrationFactorId = value
        End Set
    End Property


    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2017-05-04 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Dep RF Power Supply
    ''' </summary>
    Private _depRFPowerSupplyInstalled As Boolean = False
    Public Property Dep_RF_Power_Supply_Installed() As Boolean
        Get
            Return _depRFPowerSupplyInstalled
        End Get
        Set(ByVal value As Boolean)
            _depRFPowerSupplyInstalled = value
        End Set
    End Property
#End Region

#Region "Etch"

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Gas1 Type
    ''' </summary>
    Private _etchGas1MFCEnableCalibrationFactorId As String = String.Empty
    Public Property EtchGas1MFCEnable_CalibrationFactorId() As String
        Get
            Return _etchGas1MFCEnableCalibrationFactorId
        End Get
        Set(ByVal value As String)
            _etchGas1MFCEnableCalibrationFactorId = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Gas1 Shutoff Present
    ''' </summary>
    Private _etchGas1MFCEnableHasShutOffValve As Boolean = False
    Public Property EtchGas1MFCEnable_HasShutOffValve() As Boolean
        Get
            Return _etchGas1MFCEnableHasShutOffValve
        End Get
        Set(ByVal value As Boolean)
            _etchGas1MFCEnableHasShutOffValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Gas1 Supply Present
    ''' </summary>
    Private _etchGas1MFCEnableHasSupplyValve As Boolean = False
    Public Property EtchGas1MFCEnable_HasSupplyValve() As Boolean
        Get
            Return _etchGas1MFCEnableHasSupplyValve
        End Get
        Set(ByVal value As Boolean)
            _etchGas1MFCEnableHasSupplyValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Gas2 Type
    ''' </summary>
    Private _etchGas2MFCEnableCalibrationFactorId As String = String.Empty
    Public Property EtchGas2MFCEnable_CalibrationFactorId() As String
        Get
            Return _etchGas2MFCEnableCalibrationFactorId
        End Get
        Set(ByVal value As String)
            _etchGas2MFCEnableCalibrationFactorId = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Gas2 Shutoff Present
    ''' </summary>
    Private _etchGas2MFCEnableHasShutOffValve As Boolean = False
    Public Property EtchGas2MFCEnable_HasShutOffValve() As Boolean
        Get
            Return _etchGas2MFCEnableHasShutOffValve
        End Get
        Set(ByVal value As Boolean)
            _etchGas2MFCEnableHasShutOffValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Gas2 Supply Present
    ''' </summary>
    Private _etchGas2MFCEnableHasSupplyValve As Boolean = False
    Public Property EtchGas2MFCEnable_HasSupplyValve() As Boolean
        Get
            Return _etchGas2MFCEnableHasSupplyValve
        End Get
        Set(ByVal value As Boolean)
            _etchGas2MFCEnableHasSupplyValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Gas3 Type
    ''' </summary>
    Private _etchGas3MFCEnableCalibrationFactorId As String = String.Empty
    Public Property EtchGas3MFCEnable_CalibrationFactorId() As String
        Get
            Return _etchGas3MFCEnableCalibrationFactorId
        End Get
        Set(ByVal value As String)
            _etchGas3MFCEnableCalibrationFactorId = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Gas3 Shutoff Present
    ''' </summary>
    Private _etchGas3MFCEnableHasShutOffValve As Boolean = False
    Public Property EtchGas3MFCEnable_HasShutOffValve() As Boolean
        Get
            Return _etchGas3MFCEnableHasShutOffValve
        End Get
        Set(ByVal value As Boolean)
            _etchGas3MFCEnableHasShutOffValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Gas3 Supply Present
    ''' </summary>
    Private _etchGas3MFCEnableHasSupplyValve As Boolean = False
    Public Property EtchGas3MFCEnable_HasSupplyValve() As Boolean
        Get
            Return _etchGas3MFCEnableHasSupplyValve
        End Get
        Set(ByVal value As Boolean)
            _etchGas3MFCEnableHasSupplyValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Gas4 Type
    ''' </summary>
    Private _etchGas4MFCEnableCalibrationFactorId As String = String.Empty
    Public Property EtchGas4MFCEnable_CalibrationFactorId() As String
        Get
            Return _etchGas4MFCEnableCalibrationFactorId
        End Get
        Set(ByVal value As String)
            _etchGas4MFCEnableCalibrationFactorId = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Gas4 Shutoff Present
    ''' </summary>
    Private _etchGas4MFCEnableHasShutOffValve As Boolean = False
    Public Property EtchGas4MFCEnable_HasShutOffValve() As Boolean
        Get
            Return _etchGas4MFCEnableHasShutOffValve
        End Get
        Set(ByVal value As Boolean)
            _etchGas4MFCEnableHasShutOffValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Gas4 Supply Present
    ''' </summary>
    Private _etchGas4MFCEnableHasSupplyValve As Boolean = False
    Public Property EtchGas4MFCEnable_HasSupplyValve() As Boolean
        Get
            Return _etchGas4MFCEnableHasSupplyValve
        End Get
        Set(ByVal value As Boolean)
            _etchGas4MFCEnableHasSupplyValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Gas5 Type
    ''' </summary>
    Private _etchGas5MFCEnableCalibrationFactorId As String = String.Empty
    Public Property EtchGas5MFCEnable_CalibrationFactorId() As String
        Get
            Return _etchGas5MFCEnableCalibrationFactorId
        End Get
        Set(ByVal value As String)
            _etchGas5MFCEnableCalibrationFactorId = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Gas5 Shutoff Present
    ''' </summary>
    Private _etchGas5MFCEnableHasShutOffValve As Boolean = False
    Public Property EtchGas5MFCEnable_HasShutOffValve() As Boolean
        Get
            Return _etchGas5MFCEnableHasShutOffValve
        End Get
        Set(ByVal value As Boolean)
            _etchGas5MFCEnableHasShutOffValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Gas5 Supply Present
    ''' </summary>
    Private _etchGas5MFCEnableHasSupplyValve As Boolean = False
    Public Property EtchGas5MFCEnable_HasSupplyValve() As Boolean
        Get
            Return _etchGas5MFCEnableHasSupplyValve
        End Get
        Set(ByVal value As Boolean)
            _etchGas5MFCEnableHasSupplyValve = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Pbn Gas Name
    ''' </summary>
    Private _etchPBNGasInstalledName As String = String.Empty
    Public Property EtchPBNGas_Installed_Name() As String
        Get
            Return _etchPBNGasInstalledName
        End Get
        Set(ByVal value As String)
            _etchPBNGasInstalledName = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch Pbn Gas Type
    ''' </summary>
    Private _etchPBNGasInstalledCalibrationFactorId As String = String.Empty
    Public Property EtchPBNGas_Installed_CalibrationFactorId() As String
        Get
            Return _etchPBNGasInstalledCalibrationFactorId
        End Get
        Set(ByVal value As String)
            _etchPBNGasInstalledCalibrationFactorId = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Etch RF Power Supply
    ''' </summary>
    Private _etchRFPowerSupplyInstalled As Boolean = False
    Public Property Etch_RF_Power_Supply_Installed() As Boolean
        Get
            Return _etchRFPowerSupplyInstalled
        End Get
        Set(ByVal value As Boolean)
            _etchRFPowerSupplyInstalled = value
        End Set
    End Property

#End Region

    ''' <author>
    '''    	<name> Nguyen Dinh Minh Thi </name>
    '''    	<date> 2016-10-06 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set shutter of fixture
    ''' </summary>
    Private _fixtureShutterInstalled As Boolean = False
    Public Property FixtureShutter_Installed() As Boolean
        Get
            Return _fixtureShutterInstalled
        End Get
        Set(ByVal value As Boolean)
            _fixtureShutterInstalled = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Nguyen Dinh Minh Thi </name>
    '''    	<date> 2016-10-06 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set shutter of Depo
    ''' </summary>
    Private _depoShutterInstalled As Boolean = False
    Public Property DepoShutter_Installed() As Boolean
        Get
            Return _depoShutterInstalled
        End Get
        Set(ByVal value As Boolean)
            _depoShutterInstalled = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set shutter of target
    ''' </summary>
    Private _targetShutterInstalled As Boolean = False
    Public Property TargetShutter_Installed() As Boolean
        Get
            Return _targetShutterInstalled
        End Get
        Set(ByVal value As Boolean)
            _targetShutterInstalled = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Cryo1 Installed
    ''' </summary>
    Private _cryo1Installed As Boolean = False
    Public Property Cryo1_Installed() As Boolean
        Get
            Return _cryo1Installed
        End Get
        Set(ByVal value As Boolean)
            _cryo1Installed = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Cryo2 Installed
    ''' </summary>
    Private _cryo2Installed As Boolean = False
    Public Property Cryo2_Installed() As Boolean
        Get
            Return _cryo2Installed
        End Get
        Set(ByVal value As Boolean)
            _cryo2Installed = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2019-05-27 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Flowcool Gas Name
    ''' </summary>
    Private _flowCoolInstalledName As String = String.Empty
    Public Property FlowCool_Installed_Name() As String
        Get
            Return _flowCoolInstalledName
        End Get
        Set(ByVal value As String)
            _flowCoolInstalledName = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2019-05-27 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Flowcool Gas Type
    ''' </summary>
    Private _flowCoolInstalledCalibrationFactorId As String = String.Empty
    Public Property FlowCool_Installed_CalibrationFactorId() As String
        Get
            Return _flowCoolInstalledCalibrationFactorId
        End Get
        Set(ByVal value As String)
            _flowCoolInstalledCalibrationFactorId = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2019-05-27 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Flowcool Gas Type
    ''' </summary>
    Private _blnRGAInstalled As Boolean = False
    Public Property RGAInstalled() As Boolean
        Get
            Return _blnRGAInstalled
        End Get
        Set(ByVal value As Boolean)
            _blnRGAInstalled = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2019-06-26 </date>
    ''' </author>
    ''' <summary>
    ''' Support Tilt Sweep Mode
    ''' </summary>
    Private _blnSupportTiltSweepMode As Boolean = False
    Public Property SupportTiltSweepMode() As Boolean
        Get
            Return _blnSupportTiltSweepMode
        End Get
        Set(ByVal value As Boolean)
            _blnSupportTiltSweepMode = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2019-06-26 </date>
    ''' </author>
    ''' <summary>
    ''' Fast Tilt Installed
    ''' </summary>
    Private _blnFast_Tilt_Installed As Boolean = False
    Public Property Fast_Tilt_Installed() As Boolean
        Get
            Return _blnFast_Tilt_Installed
        End Get
        Set(ByVal value As Boolean)
            _blnFast_Tilt_Installed = value
        End Set
    End Property

End Class
