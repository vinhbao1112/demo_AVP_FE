Namespace Driver
    Public Class KepwareMPumpCGDriver
        Inherits DriverObject
        Implements ICGDriver

        Private m_GroupName As String = "TM.TMC"
        Public Property KepwareGroup() As String
            Get
                Return m_GroupName
            End Get
            Set(ByVal value As String)
                m_GroupName = value
            End Set
        End Property

        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
            XPATH_KepServerTag = XPATH_KepServerTag & Me.DriverName
            XPATH_KepServerReadbackTag = XPATH_KepServerReadbackTag & Me.DriverName
            DriverUtility.ReadKepwareConfig(XPATH_KepServerTag)
            DriverUtility.RegisterKepwareReadback(m_GroupName, XPATH_KepServerReadbackTag)
        End Sub

        Public ReadOnly Property CGPressure() As Single Implements ICGDriver.CGPressure
            Get

            End Get
        End Property
        Public ReadOnly Property CGRelay() As DataManagerment.Equipment.WorkingStatuses Implements ICGDriver.CGRelay
            Get

            End Get
        End Property
        Public Function SetValue(ByVal strCmd As String) As Boolean Implements ICGDriver.SetValue

        End Function
    End Class
End Namespace