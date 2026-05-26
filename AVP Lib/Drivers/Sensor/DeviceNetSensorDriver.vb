Namespace Driver
    Public Class DeviceNetSensorDriver
        Inherits DriverObject
        Implements ISensorDriver

        Private m_MacID As String
        Public Property MacID() As String
            Get
                Return m_MacID
            End Get
            Set(ByVal value As String)
                m_MacID = value
            End Set
        End Property

        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
        End Sub

        Public Sub New(ByVal sDriverName As String, ByVal sMacID As String)
            MyBase.new(sDriverName)
            m_MacID = sMacID
        End Sub
        Public ReadOnly Property SensorStatus() As DataManagerment.Equipment.WorkingStatuses Implements ISensorDriver.SensorStatus
            Get

            End Get
        End Property
        
    End Class
End Namespace
