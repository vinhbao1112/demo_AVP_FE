Namespace Driver
    Public Class SolenoidDriver
        Inherits DeviceNetDriver
        ''' <summary>
        ''' Byte array containing the bit array readback
        ''' </summary>
        Private m_arrReadBitData() As Byte = Nothing

        ''' <summary>
        ''' Convert to Unsigned Int the read back data
        ''' </summary>
        Private m_uReadBackBitData As UInt16 = 0

        ''' <summary>
        ''' Unsigned Int value of write data
        ''' </summary>
        Private m_uWriteBitData As UInt16 = 0

        ''' <summary>
        ''' Previous readback data
        ''' </summary>
        Private m_uReadBackBitDataPrev As UInt16 = 0

        ''' <summary>
        ''' Byte array containing the bit array set point
        ''' </summary>
        Private m_arrWriteBitData() As Byte = Nothing

        ''' <summary>
        ''' Indicate the first time polling
        ''' </summary>
        Private m_bFirstRead As Boolean = True

        Public Sub New(ByVal sDeviceName As String)
            MyBase.New(sDeviceName)
            ' 2 X 8 bit = 16 bits = 16 I/O valves
            m_arrReadBitData = New Byte(1) {}
            m_arrWriteBitData = New Byte(1) {}
        End Sub

        ''' <summary>
        ''' Init the Solenoid Block devices Component
        ''' </summary>
        ''' <param name="CardHandle"></param>
        ''' <param name="DeviceId"></param>
        ''' <returns></returns>
        Public Overrides Function Initialize() As Boolean
            Return RegisterEquipment(m_hCardHandle, 2, 2, 0)
        End Function

        ''' <summary>
        ''' Read the bit array and store to array and unsigned in value
        ''' </summary>
        Public Sub Read()
            If Me.ReadData() Then
                If m_DeviceConfig.Input1Size = 2 Then
                    ' Store the previous
                    m_uReadBackBitDataPrev = m_uReadBackBitData

                    ' Read data
                    m_arrReadBitData(0) = m_arrBuffer(0)
                    m_arrReadBitData(1) = m_arrBuffer(1)

                    ' Convert
                    m_uReadBackBitData = BitConverter.ToUInt16(m_arrReadBitData, 0)

                    If m_bFirstRead Then
                        m_uReadBackBitDataPrev = m_uReadBackBitData
                        m_uWriteBitData = m_uReadBackBitData
                        Dim arrVal() As Byte = BitConverter.GetBytes(m_uWriteBitData)
                        m_arrWriteBitData(0) = arrVal(0)
                        m_arrWriteBitData(1) = arrVal(1)
                        m_bFirstRead = False
                    Else
                        If Changed() Then
                            ' Do something
                        End If
                    End If
                End If
            End If
        End Sub

        ''' <summary>
        ''' Write the bit array to device
        ''' </summary>
        Public Sub Write()
            If m_objDnetController.IsDeviceActive(m_DeviceStatus.StatusCode) Then
                m_arrBuffer = New Byte(1) {}
                m_arrBuffer(0) = m_arrWriteBitData(0)
                m_arrBuffer(1) = m_arrWriteBitData(1)
                WriteData()
            End If
        End Sub

        ''' <summary>
        ''' Check if data of solenoid block is changed
        ''' </summary>
        ''' <returns></returns>
        Private Function Changed() As Boolean
            'UpdateStatus()
            Return ((m_uReadBackBitDataPrev Xor m_uReadBackBitData) <> 0)
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="uBitMask"></param>
        ''' <returns></returns>
        Public Function GetState(ByVal uBitMask As UInt16) As Boolean
            Return ((m_uReadBackBitData And uBitMask) <> 0)
        End Function

        ''' <summary>
        ''' Get all value of bit array
        ''' </summary>
        ''' <returns></returns>
        Public Function getWholeValue() As UInt16
            Return m_uReadBackBitData
        End Function

        ''' <summary>
        ''' Turn On or Open the device
        ''' </summary>
        ''' <param name="uBitMask"></param>
        Public Function [On](ByVal uBitMask As UInt16) As Boolean
            AVPLib.Log.avpLogger.Info("Enter SolenoidDriver.[On]")
            Dim blResult As Boolean = False
            Try
                m_uWriteBitData = CUShort(m_uWriteBitData Or uBitMask)
                Dim arrVal() As Byte = BitConverter.GetBytes(m_uWriteBitData)
                m_arrWriteBitData(0) = arrVal(0)
                m_arrWriteBitData(1) = arrVal(1)
                SyncData()
                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave SolenoidDriver.[On]")
            Return blResult
        End Function

        ''' <summary>
        ''' Turn Off or Close the device
        ''' </summary>
        ''' <param name="uBitMask"></param>
        Public Function [Off](ByVal uBitMask As UInt16) As Boolean
            AVPLib.Log.avpLogger.Info("Enter SolenoidDriver.[Off]")
            Dim blResult As Boolean = False
            Try
                m_uWriteBitData = CUShort(m_uWriteBitData And ((Not uBitMask)))
                Dim arrVal() As Byte = BitConverter.GetBytes(m_uWriteBitData)
                m_arrWriteBitData(0) = arrVal(0)
                m_arrWriteBitData(1) = arrVal(1)
                SyncData()
                blResult = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave SolenoidDriver.[Off]")
            Return blResult
        End Function

        ''' <summary>
        ''' Read & write data
        ''' </summary>
        Public Sub SyncData()
            GetDeviceStatus()
            Read()
            Write()
        End Sub

        ''' <summary>
        ''' Reset all IO of Solenoid Block
        ''' </summary>
        ''' <returns></returns>
        Public Function ResetAllIO() As Boolean
            ' Reset all IO
            m_uWriteBitData = 0
            m_arrWriteBitData(0) = 0
            m_arrWriteBitData(1) = 0

            ' Write to device
            Write()

            Return True
        End Function
    End Class
End Namespace

