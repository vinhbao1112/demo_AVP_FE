Imports System.Text

Namespace Driver
    Friend Class DNSGP275ConvectionGauge
        Inherits DeviceNetCGDriver

        Public Sub New(ByVal sDeviceName As String, ByVal MacID As UInt16)
            MyBase.New(sDeviceName, MacID, DeviceNetIGCGType.GP275)
            m_arrPressVal = New Byte(3) {}
        End Sub

        ''' <summary>
        ''' Init Ion Gauge Component
        ''' </summary>
        ''' <param name="CardHandle"></param>
        ''' <param name="DeviceId"></param>
        ''' <returns></returns>
        Public Overrides Function Initialize() As Boolean
            Return RegisterEquipment(m_hCardHandle, 5, 0, 64)
        End Function

        ''' <summary>
        ''' Get the pressure from the real device
        ''' </summary>
        Public Overrides Sub Poll()
            Try
                Me.GetDeviceStatus()
                If m_DeviceStatus IsNot Nothing Then
                    UpdateDeviceCommunication()
                    If Me.ReadData() Then
                        If m_DeviceConfig.Input1Size = 5 Then

                            Dim old_pressure As Single = m_fPressure

                            m_arrPressVal(0) = m_arrBuffer(1)
                            m_arrPressVal(1) = m_arrBuffer(2)
                            m_arrPressVal(2) = m_arrBuffer(3)
                            m_arrPressVal(3) = m_arrBuffer(4)

                            m_fPressure = BitConverter.ToSingle(m_arrPressVal, 0)

                            If m_fPressure < 0.001F Then
                                m_fPressure = 0.001F
                            End If


                            If (old_pressure <> m_fPressure) Then
                                DriverUtility.UpdateCGPressure(EquipmentName, m_fPressure)
                                AVPLib.Log.avpLogger.Debug(EquipmentName & ": " & m_fPressure)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
        End Sub
    End Class
End Namespace
