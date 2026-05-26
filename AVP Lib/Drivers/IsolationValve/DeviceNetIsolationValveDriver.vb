Imports avplib.DeviceNet
Namespace Driver
    Public Class DeviceNetIsolationValveDriver
        Inherits DeviceNetValveDriver
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Default bit m_SolenoidBitIndex control OPEN/CLOSE valve
        ''' isolation valve used 2 bits  to control open and close
        ''' so must override Open and close function on base class
        ''' </summary>
        ''' <remarks></remarks>
        Protected m_SolenoidCloseBitIndex As UInt16
        Public Property solenoidCloseBitIndex() As UInt16
            Get
                Return m_SolenoidCloseBitIndex
            End Get
            Set(ByVal value As UInt16)
                m_SolenoidCloseBitIndex = value
            End Set
        End Property
        '''' <summary>
        '''' Init Turbo fore line valve Component
        '''' </summary>
        '''' <returns></returns>
        'Public Function Intialize() As Boolean
        '    AVPLib.Log.avpLogger.Info("Enter DeviceNetIsolationValveDriver.Intialize")
        '    Dim blResult As Boolean = False
        '    Try

        '    Catch ex As Exception
        '        AVPLib.Log.avpLogger.Info(ex.Message)
        '    End Try
        '    AVPLib.Log.avpLogger.Info("Leave DeviceNetIsolationValveDriver.Intialize")
        '    Return blResult
        'End Function

        Public Sub New(ByVal sDriverName As String, ByVal MacID As String, ByVal sOpenBitIndex As String, ByVal sCloseBitIndex As String)
            MyBase.new(sDriverName)
            m_SolenoidBitIndex = sOpenBitIndex
            m_SolenoidCloseBitIndex = sCloseBitIndex
            MyBase.objSolenoidDriver = DNSScanner.objSolenoidBlock(Convert.ToInt32(MacID))
        End Sub
        'get all value, status send to AVP
        'update by kepware -> not implement
        Public Overrides Sub Poll()
            'open
            If (m_SolenoidDriver.GetState(1 << m_SolenoidBitIndex) And _
            Not m_SolenoidDriver.GetState(1 << m_SolenoidCloseBitIndex)) Then

                'close
            ElseIf (Not m_SolenoidDriver.GetState(1 << m_SolenoidBitIndex) And _
                m_SolenoidDriver.GetState(1 << m_SolenoidCloseBitIndex)) Then
            Else
                'unknown
                '  DriverUtility.UpdateHivacValveStatus(Me.ToolName, DataManagerment.Equipment.WorkingStatuses.On)
            End If
        End Sub

        Public Overrides Function Close() As Boolean
            AVPLib.Log.avpLogger.Info("Enter DeviceNetValveDriver.Close")
            Dim blResult As Boolean = False
            Try
                If (m_SolenoidDriver IsNot Nothing) Then
                    blResult = m_SolenoidDriver.On(1 << m_SolenoidCloseBitIndex) And m_SolenoidDriver.Off(1 << m_SolenoidBitIndex)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave DeviceNetValveDriver.Close")
            Return blResult
        End Function

        Public Overrides Function Open() As Boolean
            AVPLib.Log.avpLogger.Info("Enter DeviceNetValveDriver.Open")
            Dim blResult As Boolean = False
            Try
                blResult = m_SolenoidDriver.Off(1 << m_SolenoidCloseBitIndex) And m_SolenoidDriver.On(1 << m_SolenoidBitIndex)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave DeviceNetValveDriver.Open")
            Return blResult
        End Function

        Public Overrides Function Unknown() As Boolean
            AVPLib.Log.avpLogger.Info("Enter DeviceNetValveDriver.Unknown")
            Dim blResult As Boolean = False
            Try
                If (m_SolenoidDriver IsNot Nothing) Then
                    blResult = m_SolenoidDriver.Off(1 << m_SolenoidCloseBitIndex) And m_SolenoidDriver.Off(1 << m_SolenoidBitIndex)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
                blResult = False
            End Try
            AVPLib.Log.avpLogger.Info("Leave DeviceNetValveDriver.Unknown")
            Return blResult
        End Function
    End Class
End Namespace
