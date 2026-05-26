Namespace Driver
    Public Class RSTiObject
        Inherits DriverObject
#Region "variables"
        Protected m_sPropertyName As String = String.Empty
        Protected m_sDeviceNetType As Driver.DeviceType = DeviceType.IsolationValve
        Protected m_sMacID As String = String.Empty
        Protected m_sModelID As String = String.Empty
        Protected m_sSlotID As String = String.Empty
        Protected m_sChannelID As String = String.Empty
        Protected m_sMaxRawValue As Double = 1
        Protected m_sMinRawValue As Double = 0
        Protected m_sType As String = String.Empty
        Protected m_sMinScale As Double = 0
        Protected m_sMaxScale As Double = 1
        Protected m_iBytePosition As Integer = 0
        Protected m_iBitPosition As Integer = 0
#End Region

#Region "Methods"
        Public Sub New(ByVal sDriverName As String)
            MyBase.New(sDriverName)
            m_sPropertyName = m_sDriverName
        End Sub
#End Region

#Region "Properties"
        ' <Driver Name="CassettesModule.SensorLLAStatus" 
        Public Property PropertyName() As String
            Get
                Return m_sPropertyName
            End Get
            Set(ByVal value As String)
                m_sPropertyName = value
            End Set
        End Property

        'DeviceType="Sensor"
        Public Property DeviceNetType() As Driver.DeviceType
            Get
                Return m_sDeviceNetType
            End Get
            Set(ByVal value As Driver.DeviceType)
                m_sDeviceNetType = value
            End Set
        End Property

        ' <BlockDevice MacID="19">
        Public Property MacID() As String
            Get
                Return m_sMacID
            End Get
            Set(ByVal value As String)
                m_sMacID = value
            End Set
        End Property

        'ModelID=ST-2328,....
        Public Property ModelID() As String
            Get
                Return m_sModelID
            End Get
            Set(ByVal value As String)
                m_sModelID = value
            End Set
        End Property

        'SlotID=1,2,3...
        Public Property SlotID() As String
            Get
                Return m_sSlotID
            End Get
            Set(ByVal value As String)
                m_sSlotID = value
            End Set
        End Property

        'ChannelID=1,2,3,4....
        Public Property ChannelID() As String
            Get
                Return m_sChannelID
            End Get
            Set(ByVal value As String)
                m_sChannelID = value
            End Set
        End Property

        'MaxRawValue=1000
        Public Property MaxRawValue() As Double
            Get
                Return m_sMaxRawValue
            End Get
            Set(ByVal value As Double)
                m_sMaxRawValue = value
            End Set
        End Property

        'MinRawValue=0
        Public Property MinRawValue() As Double
            Get
                Return m_sMinRawValue
            End Get
            Set(ByVal value As Double)
                m_sMinRawValue = value
            End Set
        End Property

        'Type=DO,DI,AO,AI
        Public Property Type() As String
            Get
                Return m_sType
            End Get
            Set(ByVal value As String)
                m_sType = value
            End Set
        End Property

        'MinScale=0
        Public Property MinScale() As Double
            Get
                Return m_sMinScale
            End Get
            Set(ByVal value As Double)
                m_sMinScale = value
            End Set
        End Property

        'MaxScale=100
        Public Property MaxScale() As Double
            Get
                Return m_sMaxScale
            End Get
            Set(ByVal value As Double)
                m_sMaxScale = value
            End Set
        End Property

        Public Property BytePosition() As Integer
            Get
                Return m_iBytePosition
            End Get
            Set(ByVal value As Integer)
                m_iBytePosition = value
            End Set
        End Property

        Public Property BitPosition() As Integer
            Get
                Return m_iBitPosition
            End Get
            Set(ByVal value As Integer)
                m_iBitPosition = value
            End Set
        End Property
#End Region
    End Class
End Namespace
