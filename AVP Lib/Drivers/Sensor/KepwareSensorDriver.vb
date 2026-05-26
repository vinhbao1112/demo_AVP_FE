Namespace Driver
    Public Class KepwareSensorDriver
        Inherits DriverObject
        Implements IValveDriver

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
        Public Function OpenSensor() As Boolean Implements IValveDriver.Open
            AVPLib.Log.avpLogger.Debug("Enter KepwareRoughValveDriver.OpenRoughValve")
            Dim ErrorMessage As String = String.Empty
            Try
                ErrorMessage = Utils.WriteCommandKepServer(Me.DriverName, True)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Debug("Leave KepwareRoughValveDriver.OpenRoughValve")
            Return IIf(ErrorMessage = String.Empty, True, False)
        End Function
        Public Function CloseSensor() As Boolean Implements IValveDriver.Close
            AVPLib.Log.avpLogger.Debug("Enter KepwareRoughValveDriver.CloseRoughValve")
            Dim ErrorMessage As String = String.Empty
            Try
                ErrorMessage = Utils.WriteCommandKepServer(Me.DriverName, False)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Debug("Leave KepwareRoughValveDriver.CloseRoughValve")
            Return IIf(ErrorMessage = String.Empty, True, False)
        End Function
        Public Function UnknownSensor() As Boolean Implements IValveDriver.Unknown
            Return True
        End Function
    End Class
End Namespace
