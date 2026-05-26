Imports avplib.DeviceNet
Namespace Driver
    Public Class DeviceNetHivacDriver
        Inherits DeviceNetValveDriver
        '''' <summary>
        '''' Init Hivac valve Component
        '''' </summary>
        '''' <returns></returns>
        'Public Function Intialize() As Boolean
        '    AVPLib.Log.avpLogger.Info("Enter DeviceNetHivacDriver.Intialize")
        '    Dim blResult As Boolean = False
        '    Try

        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Info(ex.Message)
        '    End Try
        '    AVPLib.Log.avpLogger.Info("Leave DeviceNetHivacDriver.Intialize")
        '    Return blResult
        'End Function

        Public Sub New(ByVal sDriverName As String, ByVal MacID As String, ByVal solenoidBitIndex As String)
            MyBase.new(sDriverName)
            m_SolenoidBitIndex = solenoidBitIndex
            MyBase.objSolenoidDriver = DNSScanner.objSolenoidBlock(Convert.ToInt32(MacID))
        End Sub

        'get all value, status send to AVP
        'update by kepware so not implement here
        Public Overrides Sub Poll()
            'If (m_SolenoidDriver.GetState(1 << m_SolenoidBitIndex)) Then
            '    DriverUtility.UpdateHivacValveStatus(Me.ToolName, DataManagerment.Equipment.WorkingStatuses.On)
            'End If
        End Sub
    End Class
End Namespace
