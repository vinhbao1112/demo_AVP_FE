Namespace Driver
    'All communication on project
    Public Enum CommType
        Kepware = 0
        DeviceNet = 1
        Serial = 2
        RSTi_Serial = 3
    End Enum
    'All device exist on project
    Public Enum DeviceType
        MPumpCG
        IG
        CG
        TurboForeLine
        TurboForeLineValve
        RoughValve
        VentValve
        HivacValve
        IsolationValve
        Sensor
        PumpPackage
        Cryo
        Turbo
        Alarm
    End Enum

    Public Enum TurboModel
        Lebold350ix
        LeboldMAG
    End Enum

    Public Class DriverObject
#Region "Varialbe"
        Protected m_sDriverName As String
        Protected m_sEquipmentName As String
        Protected XPATH_KepServerTag As String = "/SystemConfiguration/KepServerTagsStatus/"
        Protected XPATH_KepServerReadbackTag = "/SystemConfiguration/KepServerTagsDef/Group/"
#End Region
#Region "Property"
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Name of Driver. ex: LoadLockB.LLSlowVent = ToolName.PropertyName
        ''' </summary>
        ''' <remarks></remarks>
        Public Property DriverName() As String
            Get
                Return m_sDriverName
            End Get
            Set(ByVal value As String)
                m_sDriverName = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' LoadLockA, LoadlockB, CassettesModule
        ''' </summary>
        ''' <remarks></remarks>
        Public Property EquipmentName() As String
            Get
                Return m_sEquipmentName
            End Get
            Set(ByVal value As String)
                m_sEquipmentName = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Tinh Le</name>
        '''    	<date> 2022-04-13</date>
        ''' </author>
        ''' <summary>
        ''' LoadLockA, LoadlockB, CassettesModule
        ''' </summary>
        ''' <remarks></remarks>
        Protected m_bTurboSetPointFrequency As Single = 936
        Public Property TurboSetPointFrequency() As Single
            Get
                Return m_bTurboSetPointFrequency
            End Get
            Set(ByVal value As Single)
                m_bTurboSetPointFrequency = value
            End Set
        End Property
#End Region
#Region "Public Function"
        Public Sub New(ByVal sDriverName As String)
            m_sDriverName = sDriverName
            Dim arrValue As String() = m_sDriverName.Split(".")
            m_sEquipmentName = IIf(arrValue.Length = 2, arrValue(0), "")
        End Sub

        Public Overridable Function Initialize() As Boolean
            Return True
        End Function

        Public Overridable Sub Dispose()

        End Sub


#End Region
    End Class
End Namespace

