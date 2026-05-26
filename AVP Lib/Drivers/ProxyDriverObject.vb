Namespace Driver
    Public Class ProxyDriverObject
        Implements IDeviceStatus

#Region "Varialbe"
        Protected m_sDriverName As String
        Protected m_CommType As CommType
        Protected m_DeviceType As DeviceType
        Protected m_proxyObj As DriverObject
#End Region
#Region "Property"
        Public Property DriverName() As String
            Get
                Return m_sDriverName
            End Get
            Set(ByVal value As String)
                m_sDriverName = value
            End Set
        End Property
        Public Property eCommunicationType() As CommType
            Get
                Return m_CommType
            End Get
            Set(ByVal value As CommType)
                m_CommType = value
            End Set
        End Property
        Public Property eDeviceType() As DeviceType
            Get
                Return m_DeviceType
            End Get
            Set(ByVal value As DeviceType)
                m_DeviceType = value
            End Set
        End Property
        Public Property proxyObject() As DriverObject
            Get
                Return m_proxyObj
            End Get
            Set(ByVal value As DriverObject)
                m_proxyObj = value
            End Set
        End Property
#End Region
        Public Sub New(ByVal sDriverName As String, _
                        ByVal eCommunicationType As CommType, _
                        ByVal eDeviceType As CommType)
            m_sDriverName = sDriverName
            m_CommType = eCommunicationType
            m_DeviceType = eDeviceType
        End Sub

        Public Overridable Sub Dispose()

        End Sub

        Public Function IsDeviceActive() As Boolean Implements IDeviceStatus.IsDeviceActive
            Return CType(m_proxyObj, IDeviceStatus).IsDeviceActive()
        End Function
    End Class
End Namespace

