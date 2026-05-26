Public Class DBStoreGui
#Region "Class Constants & Variables"

    Private m_WaferChamber1 As AVPLib.AVPWaferInfo
    Private m_WaferChamber2 As AVPLib.AVPWaferInfo
    Private m_WaferChamber3 As AVPLib.AVPWaferInfo

    Private m_WaferAligner As AVPLib.AVPWaferInfo
    Private m_WaferRobot As AVPLib.AVPWaferInfo
    Private m_WaferLoader As AVPLib.AVPWaferInfo

    Private m_HaveInsideWaferChamber1 As Boolean
    Private m_HaveInsideWaferChamber2 As Boolean
    Private m_HaveInsideWaferChamber3 As Boolean

    Private m_HaveInsideWaferAligner As Boolean
    Private m_strLastUsedAlignerRecipe As String
    Private m_HaveInsideWaferRobot As Boolean
    Private m_HaveInsideWaferLoader As Boolean
    Private m_WaferTotalOfLoadLockA As Integer
    Private m_TotalWaferCount As Integer
    Private m_CycleWafersInLoadLockA As Boolean
    Private m_RunWithRecipeInLoadLockA As Boolean
    Private m_LoadLockAWaferInfo As AVPLib.AVPWaferInfo() 'Default = 12
    Private m_Chamber1WaferInfo As AVPLib.AVPWaferInfo() 'Default = 12
    Private m_Chamber2WaferInfo As AVPLib.AVPWaferInfo() 'Default = 12
    Private m_Chamber3WaferInfo As AVPLib.AVPWaferInfo() 'Default = 12
    Private m_strLotID_LLA As String
    Private m_strSequenceID_LLA As String
    Private m_WaferTotalOfLoader As Integer
    Private m_blnUseOperationID As Boolean = False
    Private m_blnUseTIP As Boolean = False
    Private m_blnUsePalletID As Boolean = False
    Private m_blnUseLotID As Boolean = False
    Private m_blnUseProductName As Boolean = False

    Private m_intWaferCountOfChamber1 As Integer
    Private m_intWaferCountOfChamber2 As Integer
    Private m_intWaferCountOfChamber3 As Integer
    Private m_intLifeTimeWafer As Integer

    Private m_blnUseAbsoluteKWH As Boolean = False

    Private m_chamber1StoreData As Dictionary(Of String, String)
    Private m_chamber2StoreData As Dictionary(Of String, String)
    Private m_chamber3StoreData As Dictionary(Of String, String)
#End Region

#Region "Properties"
    Public Property WaferCountOfChamber1() As Integer
        Get
            Return m_intWaferCountOfChamber1
        End Get
        Set(ByVal value As Integer)
            m_intWaferCountOfChamber1 = value
        End Set
    End Property

    Public Property WaferCountOfChamber2() As Integer
        Get
            Return m_intWaferCountOfChamber2
        End Get
        Set(ByVal value As Integer)
            m_intWaferCountOfChamber2 = value
        End Set
    End Property

    Public Property WaferCountOfChamber3() As Integer
        Get
            Return m_intWaferCountOfChamber3
        End Get
        Set(ByVal value As Integer)
            m_intWaferCountOfChamber3 = value
        End Set
    End Property

    
 
    Public Property LotID_LLA() As String
        Get
            Return m_strLotID_LLA
        End Get
        Set(ByVal value As String)
            m_strLotID_LLA = value
        End Set
    End Property

    Public Property SequenceID_LLA() As String
        Get
            Return m_strSequenceID_LLA
        End Get
        Set(ByVal value As String)
            m_strSequenceID_LLA = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-14</date>
    ''' </author>
    ''' <summary>
    ''' WaferChamber1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WaferChamber1() As AVPLib.AVPWaferInfo
        Get
            Return m_WaferChamber1
        End Get
        Set(ByVal value As AVPLib.AVPWaferInfo)
            m_WaferChamber1 = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-14</date>
    ''' </author>
    ''' <summary>
    ''' HaveInsideWaferChamber1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HaveInsideWaferChamber1() As Boolean
        Get
            Return m_HaveInsideWaferChamber1
        End Get
        Set(ByVal value As Boolean)
            m_HaveInsideWaferChamber1 = value
        End Set
    End Property

    Public Property WaferChamber2() As AVPLib.AVPWaferInfo
        Get
            Return m_WaferChamber2
        End Get
        Set(ByVal value As AVPLib.AVPWaferInfo)
            m_WaferChamber2 = value
        End Set
    End Property

    Public Property HaveInsideWaferChamber2() As Boolean
        Get
            Return m_HaveInsideWaferChamber2
        End Get
        Set(ByVal value As Boolean)
            m_HaveInsideWaferChamber2 = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-14</date>
    ''' </author>
    ''' <summary>
    ''' WaferChamber3
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WaferChamber3() As AVPLib.AVPWaferInfo
        Get
            Return m_WaferChamber3
        End Get
        Set(ByVal value As AVPLib.AVPWaferInfo)
            m_WaferChamber3 = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-14</date>
    ''' </author>
    ''' <summary>
    ''' HaveInsideWaferChamber3
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HaveInsideWaferChamber3() As Boolean
        Get
            Return m_HaveInsideWaferChamber3
        End Get
        Set(ByVal value As Boolean)
            m_HaveInsideWaferChamber3 = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-14</date>
    ''' </author>
    ''' <summary>
    ''' HaveInsideWaferAligner
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HaveInsideWaferAligner() As Boolean
        Get
            Return m_HaveInsideWaferAligner
        End Get
        Set(ByVal value As Boolean)
            m_HaveInsideWaferAligner = value
        End Set
    End Property

    Public Property LastUsedAlignerRecipe() As String
        Get
            Return m_strLastUsedAlignerRecipe
        End Get
        Set(ByVal value As String)
            m_strLastUsedAlignerRecipe = value
        End Set
    End Property

    Public Property WaferAtAligner() As AVPLib.AVPWaferInfo
        Get
            Return m_WaferAligner
        End Get
        Set(ByVal value As AVPLib.AVPWaferInfo)
            m_WaferAligner = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-14</date>
    ''' </author>
    ''' <summary>
    ''' HaveInsideWaferAligner
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HaveInsideWaferRobot() As Boolean
        Get
            Return m_HaveInsideWaferRobot
        End Get
        Set(ByVal value As Boolean)
            m_HaveInsideWaferRobot = value
        End Set
    End Property

    Public Property HaveInsideWaferLoader() As Boolean
        Get
            Return m_HaveInsideWaferLoader
        End Get
        Set(ByVal value As Boolean)
            m_HaveInsideWaferLoader = value
        End Set
    End Property

    Public Property WaferAtRobot() As AVPLib.AVPWaferInfo
        Get
            Return m_WaferRobot
        End Get
        Set(ByVal value As AVPLib.AVPWaferInfo)
            m_WaferRobot = value
        End Set
    End Property

    Public Property WaferAtLoader() As AVPLib.AVPWaferInfo
        Get
            Return m_WaferLoader
        End Get
        Set(ByVal value As AVPLib.AVPWaferInfo)
            m_WaferLoader = value
        End Set
    End Property


    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-14</date>
    ''' </author>
    ''' <summary>
    ''' WaferTotal Of LoadLockA
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WaferTotalOfLoadLockA() As Integer
        Get
            Return m_WaferTotalOfLoadLockA
        End Get
        Set(ByVal value As Integer)
            m_WaferTotalOfLoadLockA = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2012-02-27</date>
    ''' </author>
    ''' <summary>
    ''' Total wafer count
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TotalWaferCount() As Integer
        Get
            Return m_TotalWaferCount
        End Get
        Set(ByVal value As Integer)
            m_TotalWaferCount = value
        End Set
    End Property

    Public Property Chamber1WaferInfo() As AVPLib.AVPWaferInfo()
        Get
            Return m_Chamber1WaferInfo
        End Get
        Set(ByVal value As AVPLib.AVPWaferInfo())
            m_Chamber1WaferInfo = value
        End Set
    End Property

    Public Property Chamber2WaferInfo() As AVPLib.AVPWaferInfo()
        Get
            Return m_Chamber2WaferInfo
        End Get
        Set(ByVal value As AVPLib.AVPWaferInfo())
            m_Chamber2WaferInfo = value
        End Set
    End Property

    Public Property Chamber3WaferInfo() As AVPLib.AVPWaferInfo()
        Get
            Return m_Chamber3WaferInfo
        End Get
        Set(ByVal value As AVPLib.AVPWaferInfo())
            m_Chamber3WaferInfo = value
        End Set
    End Property


    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-14</date>
    ''' </author>
    ''' <summary>
    ''' Wafer Of LoadLockA
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LoadLockAWaferInfo() As AVPLib.AVPWaferInfo()
        Get
            Return m_LoadLockAWaferInfo
        End Get
        Set(ByVal value As AVPLib.AVPWaferInfo())
            m_LoadLockAWaferInfo = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-01-26</date>
    ''' </author>
    ''' <summary>
    ''' WaferTotal Of Loader (Single Loader)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WaferTotalOfLoader() As Integer
        Get
            Return m_WaferTotalOfLoader
        End Get
        Set(ByVal value As Integer)
            m_WaferTotalOfLoader = value
        End Set
    End Property

 Public Property UseOperationID() As Boolean
        Get
            Return m_blnUseOperationID
        End Get
        Set(ByVal value As Boolean)
            m_blnUseOperationID = value
        End Set
    End Property

    Public Property UseTIP() As Boolean
        Get
            Return m_blnUseTIP
        End Get
        Set(ByVal value As Boolean)
            m_blnUseTIP = value
        End Set
    End Property

    Public Property UsePalletID() As Boolean
        Get
            Return m_blnUsePalletID
        End Get
        Set(ByVal value As Boolean)
            m_blnUsePalletID = value
        End Set
    End Property

    Public Property UseLotID() As Boolean
        Get
            Return m_blnUseLotID
        End Get
        Set(ByVal value As Boolean)
            m_blnUseLotID = value
        End Set
    End Property

    Public Property UseProductName() As Boolean
        Get
            Return m_blnUseProductName
        End Get
        Set(ByVal value As Boolean)
            m_blnUseProductName = value
        End Set
    End Property


    Public Property LifeTimeWafer() As Integer
        Get
            Return m_intLifeTimeWafer
        End Get
        Set(ByVal value As Integer)
            m_intLifeTimeWafer = value
        End Set
    End Property

    Public Property UseAbsoluteKWH() As Boolean
        Get
            Return m_blnUseAbsoluteKWH
        End Get
        Set(ByVal value As Boolean)
            m_blnUseAbsoluteKWH = value
        End Set
    End Property

    Public ReadOnly Property Chamber1StoreData() As Dictionary(Of String, String)
        Get
            If m_chamber1StoreData Is Nothing Then
                m_chamber1StoreData = New Dictionary(Of String, String)
            End If
            Return m_chamber1StoreData
        End Get
    End Property

    Public ReadOnly Property Chamber2StoreData() As Dictionary(Of String, String)
        Get
            If m_chamber2StoreData Is Nothing Then
                m_chamber2StoreData = New Dictionary(Of String, String)
            End If
            Return m_chamber2StoreData
        End Get
    End Property

    Public ReadOnly Property Chamber3StoreData() As Dictionary(Of String, String)
        Get
            If m_chamber3StoreData Is Nothing Then
                m_chamber3StoreData = New Dictionary(Of String, String)
            End If
            Return m_chamber3StoreData
        End Get
    End Property
#End Region

#Region "Properties robot config"

    ''' <author>
    '''    	<name> Tinh Le </name>
    '''    	<date> 2020-11-10</date>
    ''' </author>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private m_HACCRobot As String
    Public Property HaveConfigHACC() As String
        Get
            Return m_HACCRobot
        End Get
        Set(ByVal value As String)
            m_HACCRobot = value
        End Set
    End Property

    Private m_RobotPACC As String
    Public Property HaveConfigPACC() As String
        Get
            Return m_RobotPACC
        End Get
        Set(ByVal value As String)
            m_RobotPACC = value
        End Set
    End Property

    Private m_WACCRobot As String
    Public Property HaveConfigWACC() As String
        Get
            Return m_WACCRobot
        End Get
        Set(ByVal value As String)
            m_WACCRobot = value
        End Set
    End Property

    Private m_HVELRobot As String
    Public Property HaveConfigHVEL() As String
        Get
            Return m_HVELRobot
        End Get
        Set(ByVal value As String)
            m_HVELRobot = value
        End Set
    End Property

    Private m_PVELRobot As String
    Public Property HaveConfigPVEL() As String
        Get
            Return m_PVELRobot
        End Get
        Set(ByVal value As String)
            m_PVELRobot = value
        End Set
    End Property

    Private m_WVELRobot As String
    Public Property HaveConfigWVEL() As String
        Get
            Return m_WVELRobot
        End Get
        Set(ByVal value As String)
            m_WVELRobot = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tinh Le </name>
    '''    	<date> 2020-22-04</date>
    ''' </author>
    ''' <summary>
    ''' R_HACC
    ''' </summary>
    Private m_R_HACC As String
    Public Property R_HACC() As String
        Get
            Return m_R_HACC
        End Get
        Set(ByVal value As String)
            m_R_HACC = value
        End Set
    End Property
    ''T_HACC
    Private m_T_HACC As String
    Public Property T_HACC() As String
        Get
            Return m_T_HACC
        End Get
        Set(ByVal value As String)
            m_T_HACC = value
        End Set
    End Property
    ''Z_HACC
    Private m_Z_HACC As String
    Public Property Z_HACC() As String
        Get
            Return m_Z_HACC
        End Get
        Set(ByVal value As String)
            m_Z_HACC = value
        End Set
    End Property
    ''m_R_PACC
    Private m_R_PACC As String
    Public Property R_PACC() As String
        Get
            Return m_R_PACC
        End Get
        Set(ByVal value As String)
            m_R_PACC = value
        End Set
    End Property
    ''T_PACC
    Private m_T_PACC As String
    Public Property T_PACC() As String
        Get
            Return m_T_PACC
        End Get
        Set(ByVal value As String)
            m_T_PACC = value
        End Set
    End Property

    ''Z_PACC
    Private m_Z_PACC As String
    Public Property Z_PACC() As String
        Get
            Return m_Z_PACC
        End Get
        Set(ByVal value As String)
            m_Z_PACC = value
        End Set
    End Property

    ''m_R_WACC
    Private m_R_WACC As String
    Public Property R_WACC() As String
        Get
            Return m_R_WACC
        End Get
        Set(ByVal value As String)
            m_R_WACC = value
        End Set
    End Property

    ''m_T_WACC
    Private m_T_WACC As String
    Public Property T_WACC() As String
        Get
            Return m_T_WACC
        End Get
        Set(ByVal value As String)
            m_T_WACC = value
        End Set
    End Property

    ''Z_WACC
    Private m_Z_WACC As String
    Public Property Z_WACC() As String
        Get
            Return m_Z_WACC
        End Get
        Set(ByVal value As String)
            m_Z_WACC = value
        End Set
    End Property

    ''R_HVEL
    Private m_R_HVEL As String
    Public Property R_HVEL() As String
        Get
            Return m_R_HVEL
        End Get
        Set(ByVal value As String)
            m_R_HVEL = value
        End Set
    End Property

    ''m_T_HVEL
    Private m_T_HVEL As String
    Public Property T_HVEL() As String
        Get
            Return m_T_HVEL
        End Get
        Set(ByVal value As String)
            m_T_HVEL = value
        End Set
    End Property

    ''m_Z_HVEL
    Private m_Z_HVEL As String
    Public Property Z_HVEL() As String
        Get
            Return m_Z_HVEL
        End Get
        Set(ByVal value As String)
            m_Z_HVEL = value
        End Set
    End Property

    ''R_PVEL
    Private m_R_PVEL As String
    Public Property R_PVEL() As String
        Get
            Return m_R_PVEL
        End Get
        Set(ByVal value As String)
            m_R_PVEL = value
        End Set
    End Property

    ''m_T_PVEL
    Private m_T_PVEL As String
    Public Property T_PVEL() As String
        Get
            Return m_T_PVEL
        End Get
        Set(ByVal value As String)
            m_T_PVEL = value
        End Set
    End Property

    ''m_Z_PVEL
    Private m_Z_PVEL As String
    Public Property Z_PVEL() As String
        Get
            Return m_Z_PVEL
        End Get
        Set(ByVal value As String)
            m_Z_PVEL = value
        End Set
    End Property

    ''R_WVEL
    Private m_R_WVEL As String
    Public Property R_WVEL() As String
        Get
            Return m_R_WVEL
        End Get
        Set(ByVal value As String)
            m_R_WVEL = value
        End Set
    End Property

    ''m_T_WVEL
    Private m_T_WVEL As String
    Public Property T_WVEL() As String
        Get
            Return m_T_WVEL
        End Get
        Set(ByVal value As String)
            m_T_WVEL = value
        End Set
    End Property

    ''m_Z_WVEL
    Private m_Z_WVEL As String
    Public Property Z_WVEL() As String
        Get
            Return m_Z_WVEL
        End Get
        Set(ByVal value As String)
            m_Z_WVEL = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-14</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ReDim Preserve m_LoadLockAWaferInfo(RobotConfigurationValues.SLOT_NUM_LLA - 1)
    End Sub
#End Region
End Class
