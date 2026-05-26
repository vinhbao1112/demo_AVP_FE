Imports avplib.DeviceNet
Namespace Driver
    Public Class DeviceNetRoughValveDriver
        Inherits DeviceNetValveDriver
        '''' <summary>
        '''' Init Rough valve Component
        '''' </summary>
        '''' <returns></returns>
        'Public Function Intialize() As Boolean
        '    AVPLib.Log.avpLogger.Info("Enter DeviceNetRoughValveDriver.Intialize")
        '    Dim blResult As Boolean = False
        '    Try

        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Info(ex.Message)
        '    End Try
        '    AVPLib.Log.avpLogger.Info("Leave DeviceNetRoughValveDriver.Intialize")
        '    Return blResult
        'End Function

        Public Sub New(ByVal sDriverName As String, ByVal MacID As String, ByVal solenoidBitIndex As String)
            MyBase.new(sDriverName)
            m_SolenoidBitIndex = solenoidBitIndex
            MyBase.objSolenoidDriver = DNSScanner.objSolenoidBlock(Convert.ToInt32(MacID))
        End Sub

        'get all value, status send to AVP
        Public Overrides Sub Poll()
            Try
                Dim PreState As Boolean = CurrentState
                CurrentState = m_SolenoidDriver.GetState(1 << m_SolenoidBitIndex)
                If (PreState <> CurrentState) Then
                    'Current state = True = ON
                    If (CurrentState) Then
                        DriverUtility.UpdateRoughValveStatus(Me.DriverName, Me.EquipmentName, DataManagerment.Equipment.WorkingStatuses.On)
                    Else 'Current state = False = OFF
                        DriverUtility.UpdateRoughValveStatus(Me.DriverName, Me.EquipmentName, DataManagerment.Equipment.WorkingStatuses.Off)
                    End If
                    PreState = CurrentState
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
        End Sub
    End Class
End Namespace
