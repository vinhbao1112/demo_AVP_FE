Namespace Driver
    Public Class DeviceNetValveDriver
        Inherits DriverObject
        Implements IValveDriver
        Implements IDeviceStatus

        'False = Off
        'True = On
        'Keep the same with GetState() Function
        'Used for Update status when changed
        Protected m_CrurrentState As Boolean = False
        Public Property CurrentState() As Boolean
            Get
                Return m_CrurrentState
            End Get
            Set(ByVal value As Boolean)
                m_CrurrentState = value
            End Set
        End Property
        'solenoid instance
        Protected m_SolenoidDriver As SolenoidDriver
        Public Property objSolenoidDriver()
            Get
                Return m_SolenoidDriver
            End Get
            Set(ByVal value)
                m_SolenoidDriver = value
            End Set
        End Property

        'bit pos
        Protected m_SolenoidBitIndex As UInt16
        Public Property solenoidBitIndex() As UInt16
            Get
                Return m_SolenoidBitIndex
            End Get
            Set(ByVal value As UInt16)
                m_SolenoidBitIndex = value
            End Set
        End Property


        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
        End Sub

        'get all value, status send to AVP
        Public Overridable Sub Poll()

        End Sub

        Public Overridable Function Close() As Boolean Implements IValveDriver.Close
            AVPLib.Log.avpLogger.Info("Enter DeviceNetValveDriver.Close")
            Dim blResult As Boolean = False
            Try
                If (m_SolenoidDriver IsNot Nothing) Then
                    blResult = m_SolenoidDriver.Off(1 << m_SolenoidBitIndex)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave DeviceNetValveDriver.Close")
            Return blResult
        End Function

        Public Overridable Function Open() As Boolean Implements IValveDriver.Open
            AVPLib.Log.avpLogger.Info("Enter DeviceNetValveDriver.Open")
            Dim blResult As Boolean = False
            Try
                blResult = m_SolenoidDriver.On(1 << m_SolenoidBitIndex)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave DeviceNetValveDriver.Open")
            Return blResult
        End Function

        Public Overridable Function Unknown() As Boolean Implements IValveDriver.Unknown
            Return True
        End Function

        Public Function IsDeviceActive() As Boolean Implements IDeviceStatus.IsDeviceActive
            Return objSolenoidDriver.IsDeviceActive()
        End Function
    End Class
End Namespace
