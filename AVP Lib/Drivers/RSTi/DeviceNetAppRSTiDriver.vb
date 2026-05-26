Namespace Driver
    Public Class DeviceNetAppRSTiDriver
        Inherits DeviceNetAppDriver
        Implements IDeviceAdapter

        Private m_hstChannelRSTi As Hashtable = Nothing

        'Driver name as key, RSTiObject as value
        Public ReadOnly Property ListOfChannelRSTi() As Hashtable
            Get
                Return m_hstChannelRSTi
            End Get
        End Property

        ''' <summary>
        ''' New object RSTi
        ''' </summary>
        Public Sub New(ByVal sDriverName As String, _
                    ByVal iMacID As UShort)
            MyBase.new(sDriverName)
            m_sMacID = iMacID
            m_strComName = "RSTiCom"
            m_hstChannelRSTi = New Hashtable
        End Sub

        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
        End Sub

        Public Function SetValue(ByVal value As Double, ByVal sDriverName As String) As Boolean Implements IDeviceAdapter.SetValue
            Dim sCommandCode As String = ContainerData.GetDeviceNetAppCmdCode(sDriverName)
            sCommandCode = sCommandCode & "," & value

            Return SendCommandToDeviceNetApp(sCommandCode)
        End Function

        Public Function TurnBitOff(ByVal strDriverName As String) As Boolean Implements IDeviceAdapter.TurnBitOff
            Dim sCommandCode As String = ContainerData.GetDeviceNetAppCmdCode(strDriverName)
            sCommandCode = sCommandCode & ",False"

            Return SendCommandToDeviceNetApp(sCommandCode)
        End Function

        Public Function TurnBitOn(ByVal strDriverName As String) As Boolean Implements IDeviceAdapter.TurnBitOn
            Dim sCommandCode As String = ContainerData.GetDeviceNetAppCmdCode(strDriverName)
            sCommandCode = sCommandCode & ",True"

            Return SendCommandToDeviceNetApp(sCommandCode)
        End Function

        Public Sub AddAdapterInfoRSTi(ByVal objRSTiAdapterInfo As RSTiApdater.RSTIAdapterInfo, ByVal objPumpPackageList As Hashtable) Implements IDeviceAdapter.AddAdapterInfoRSTi

        End Sub

        Public Sub AddChannelRSTi(ByVal objRSTi As RSTiObject) Implements IDeviceAdapter.AddChannelRSTi
            AVPLib.Log.avpLogger.Info("Enter AddChannelRSTi")
            Try
                If Not m_hstChannelRSTi.Contains(objRSTi.DriverName) Then
                    m_hstChannelRSTi.Add(objRSTi.DriverName, objRSTi)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave AddChannelRSTi")
        End Sub
    End Class
End Namespace