Public Class Server
#Region "Class Constants & Variables"
    Private strName As String
    Private strEthernetIP As String
    Private strPort As String
    Private m_blnIsInstall As Boolean = False
    Private m_blnIsManualDoorElevator As Boolean = False
    Private m_strConfigFolder As String = String.Empty
    Private m_strRecipeFolder As String = String.Empty
    Private m_strType As String
    Private m_Version As String

    Private m_strRateOfRiseFolder As String = String.Empty
    Private m_strRateOfRiseFilename As String = String.Empty
    Private m_strPumpdownCurveFolder As String = String.Empty
    Private m_strPumpdownCurveFilename As String = String.Empty
    Private m_strDataRunFolder As String = String.Empty
    Private m_strDataRunFilename As String = String.Empty
    Private m_strDataRunOutputFolder As String = String.Empty

#End Region

#Region "Properties"
    ''' <author>
    '''    	<name>Dat Cao</name>
    '''    	<date> 2011-04-05</date>
    ''' </author>
    ''' <summary>
    ''' add version for Loadlock ex: vce4 vc2,vc4,vc6...
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Version() As String
        Get
            Return m_Version
        End Get
        Set(ByVal value As String)
            m_strType = value
        End Set
    End Property
    Public Property Type() As String
        Get
            Return m_strType
        End Get
        Set(ByVal value As String)
            m_strType = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2008-11-012</date>
    ''' </author>
    ''' <summary>
    ''' Name property message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ConfigFolder() As String
        Get
            Return m_strConfigFolder
        End Get
        Set(ByVal value As String)
            m_strConfigFolder = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2008-11-012</date>
    ''' </author>
    ''' <summary>
    ''' Name property message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RecipeFolder() As String
        Get
            Return m_strRecipeFolder
        End Get
        Set(ByVal value As String)
            m_strRecipeFolder = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Nguyen Tan Dung</name>
    '''    	<date> 2010-12-29</date>
    ''' </author>
    ''' <summary>
    ''' Name property message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataRunFolder() As String
        Get
            Return m_strDataRunFolder
        End Get
        Set(ByVal value As String)
            m_strDataRunFolder = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Nguyen Tan Dung</name>
    '''    	<date> 2010-12-29</date>
    ''' </author>
    ''' <summary>
    ''' Name property message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataRunFilename() As String
        Get
            Return m_strDataRunFilename
        End Get
        Set(ByVal value As String)
            m_strDataRunFilename = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Hoa Nguyen</name>
    '''    	<date> 2010-03-24</date>
    ''' </author>
    ''' <summary>
    ''' Path of Data Run Output folder.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataRunOutputFolder() As String
        Get
            Return m_strDataRunOutputFolder
        End Get
        Set(ByVal value As String)
            m_strDataRunOutputFolder = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Nguyen Tan Dung</name>
    '''    	<date> 2010-12-29</date>
    ''' </author>
    ''' <summary>
    ''' Name property message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RateOfRiseFolder() As String
        Get
            Return m_strRateOfRiseFolder
        End Get
        Set(ByVal value As String)
            m_strRateOfRiseFolder = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Hoa Nguyen</name>
    '''    	<date> 2011-11-28</date>
    ''' </author>
    ''' <summary>
    ''' Name property message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PumpdownCurveFolder() As String
        Get
            Return m_strPumpdownCurveFolder
        End Get
        Set(ByVal value As String)
            m_strPumpdownCurveFolder = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Nguyen Tan Dung</name>
    '''    	<date> 2010-12-29</date>
    ''' </author>
    ''' <summary>
    ''' Name property message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RateOfRiseFilename() As String
        Get
            Return m_strRateOfRiseFilename
        End Get
        Set(ByVal value As String)
            m_strRateOfRiseFilename = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Hoa Nguyen</name>
    '''    	<date> 2011-11-28</date>
    ''' </author>
    ''' <summary>
    ''' Name property message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PumpdownCurveFilename() As String
        Get
            Return m_strPumpdownCurveFilename
        End Get
        Set(ByVal value As String)
            m_strPumpdownCurveFilename = value
        End Set
    End Property

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-012</date>
    ''' </author>
    ''' <summary>
    ''' Name property message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsInstalled() As Boolean
        Get
            Return m_blnIsInstall
        End Get
        Set(ByVal value As Boolean)
            m_blnIsInstall = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Do Xuan Dat</name>
    '''    	<date> 2010-03-22</date>
    ''' </author>
    ''' <summary>
    ''' Name property message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsManualDoorElevator() As Boolean
        Get
            Return m_blnIsManualDoorElevator
        End Get
        Set(ByVal value As Boolean)
            m_blnIsManualDoorElevator = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-012</date>
    ''' </author>
    ''' <summary>
    ''' Name property message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name() As String
        Get
            Return strName
        End Get
        Set(ByVal value As String)
            strName = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <summary>
    ''' EthernetIP property message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EthernetIP() As String
        Get
            Return strEthernetIP
        End Get
        Set(ByVal value As String)
            strEthernetIP = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <summary>
    ''' Port property message
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Port() As String
        Get
            Return strPort
        End Get
        Set(ByVal value As String)
            strPort = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <param name="EthernetIP"></param>
    ''' <param name="Port"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Name As String, ByVal EthernetIP As String, ByVal Port As String, ByVal blnIsInstall As Boolean, _
                    ByVal blnIsManualDoorElevator As Boolean, ByVal ConfigFolder As String, ByVal RecipeFolder As String, _
                    Optional ByVal TypeOfPM As String = "", Optional ByVal sVersion As String = "")
        Me.strName = Name
        Me.strEthernetIP = EthernetIP
        Me.strPort = Port
        Me.m_strConfigFolder = ConfigFolder
        Me.m_strRecipeFolder = RecipeFolder
        Me.m_blnIsInstall = blnIsInstall
        Me.Type = TypeOfPM
        Me.m_Version = sVersion
        Me.m_blnIsManualDoorElevator = blnIsManualDoorElevator
    End Sub
#End Region
End Class
