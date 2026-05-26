Imports System.Timers
Imports AVPLib.Communication.TerminalDriver

Namespace Driver
    Public Class SerialCryoDriver
        Inherits DriverObject
        Implements IPumpPackageDriver

#Region "Class Constants & Variables"
        'Const POLLING_INTERVAL As Integer = 500  '0.5 seconds

        Private m_tmrPollingTimer As Timer
        Dim m_bHasStopRequest As Boolean = False
        Private m_blnGetCryo_P_Value As Boolean = False
        Private m_iTimesSend As Integer = 0

        Const MAX_CRYO_PARAM As Integer = 5
#End Region

#Region "Constructors & Dispose"
        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Turn off Turbo
        ''' </summary>
        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
            m_tmrPollingTimer = New Timer
            AddHandler m_tmrPollingTimer.Elapsed, AddressOf Polling
            m_tmrPollingTimer.Interval = ConstEnum.CRYO_POLLING_INTERVAL
            m_tmrPollingTimer.Enabled = True
        End Sub
#End Region

#Region "IPumpackageInterface"
        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Start Fast Regen
        ''' </summary>
        Public Function StartFastRegen() As Boolean Implements IPumpPackageDriver.StartFastRegen
            AVPLib.Log.coreLogger.Info("Enter StartRegen")
            Dim bResult As Boolean = False
            Try
                Dim strMessage As String = Me.EquipmentName + "." + "$N22"
                bResult = TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StartRegen")
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Start Regen
        ''' </summary>
        Public Function StartRegen() As Boolean Implements IPumpPackageDriver.StartRegen
            AVPLib.Log.coreLogger.Info("Enter StartRegen")
            Dim bResult As Boolean = False
            Try
                Dim strMessage As String = Me.EquipmentName + "." + "$N1n"
                bResult = TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StartRegen")
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Stop Regen
        ''' </summary>
        Public Function StopRegen() As Boolean Implements IPumpPackageDriver.StopRegen
            AVPLib.Log.coreLogger.Info("Enter StopRegen")
            Dim bResult As Boolean = False
            Try
                Dim strMessage As String = Me.EquipmentName + "." + "$N0o"
                bResult = TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StopRegen")
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Turn off Cryo Pump
        ''' </summary>
        Public Function TurnOff() As Boolean Implements IPumpPackageDriver.TurnOff
            AVPLib.Log.coreLogger.Info("Enter TurnOff")
            Dim bResult As Boolean = False
            Try
                Dim strMessage As String = Me.EquipmentName + "." + "$A0`"
                bResult = TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOff")
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Turn on Cryo Pump
        ''' </summary>
        Public Function TurnOn() As Boolean Implements IPumpPackageDriver.TurnOn
            AVPLib.Log.coreLogger.Info("Enter TurnOn")
            Dim bResult As Boolean = False
            Try
                Dim strMessage As String = Me.EquipmentName + "." + "$A1c"
                bResult = TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOn")
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Turn on Cryo Pump
        ''' </summary>
        Public Function CryoSetPumpRestartDelay(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetPumpRestartDelay
            AVPLib.Log.coreLogger.Info("Enter RequestPumpRestartDelay")
            Try
                Dim cs As New CheckSum
                Dim strMessage As String = "P0" & AppendValueInParam(strVal)
                'generateChecksum
                strMessage = cs.AppendCheckSum(strMessage)
                strMessage = Me.EquipmentName & "." & "$" & strMessage
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            m_blnGetCryo_P_Value = False
            AVPLib.Log.coreLogger.Info("Leave RequestPumpRestartDelay")
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Set Extended Purge Time
        ''' </summary>
        Public Function CryoSetExtendedPurgeTime(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetExtendedPurgeTime
            AVPLib.Log.coreLogger.Info("Enter RequestExtendedPurgeTime")
            Try
                Dim cs As New CheckSum
                Dim strMessage As String = "P1" & AppendValueInParam(strVal)
                'generateChecksum
                strMessage = cs.AppendCheckSum(strMessage)
                strMessage = Me.EquipmentName & "." & "$" & strMessage
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            m_blnGetCryo_P_Value = False
            AVPLib.Log.coreLogger.Info("Leave RequestExtendedPurgeTime")
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Set Repurge Cycles
        ''' </summary>
        Public Function CryoSetRepurgeCycles(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetRepurgeCycles
            AVPLib.Log.coreLogger.Info("Enter RequestRepurgeCycles")
            Try
                Dim cs As New CheckSum
                Dim strMessage As String = "P2" & AppendValueInParam(strVal)
                'generateChecksum
                strMessage = cs.AppendCheckSum(strMessage)
                strMessage = Me.EquipmentName & "." & "$" & strMessage
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            m_blnGetCryo_P_Value = False
            AVPLib.Log.coreLogger.Info("Leave RequestRepurgeCycles")
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Rough To Pressure
        ''' </summary>
        Public Function CryoSetRoughToPressure(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetRoughToPressure
            AVPLib.Log.coreLogger.Info("Enter RequestRoughToPressure")
            Try
                Dim cs As New CheckSum
                Dim strMessage As String = "P3" & AppendValueInParam(strVal)
                'generateChecksum
                strMessage = cs.AppendCheckSum(strMessage)
                strMessage = Me.EquipmentName & "." & "$" & strMessage
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            m_blnGetCryo_P_Value = False
            AVPLib.Log.coreLogger.Info("Leave RequestRoughToPressure")
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Set Rate Of Rise
        ''' </summary>
        Public Function CryoSetRateOfRise(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetRateOfRise
            AVPLib.Log.coreLogger.Info("Enter RequestRateOfRise")
            Try
                Dim cs As New CheckSum
                Dim strMessage As String = "P4" & AppendValueInParam(strVal)
                'generateChecksum
                strMessage = cs.AppendCheckSum(strMessage)
                strMessage = Me.EquipmentName & "." & "$" & strMessage
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            m_blnGetCryo_P_Value = False
            AVPLib.Log.coreLogger.Info("Leave RequestRateOfRise")
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Set Start Up Temperature
        ''' </summary>
        Public Function CryoSetStartUpTemp(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetStartUpTemp
            AVPLib.Log.coreLogger.Info("Enter RequestStartUpTemp")
            Try
                Dim cs As New CheckSum
                Dim strMessage As String = "P6" & AppendValueInParam(strVal)
                'generateChecksum
                strMessage = cs.AppendCheckSum(strMessage)
                strMessage = Me.EquipmentName & "." & "$" & strMessage
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            m_blnGetCryo_P_Value = False
            AVPLib.Log.coreLogger.Info("Leave RequestStartUpTemp")
        End Function

#End Region


#Region "Properties"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        '''<Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-03</Date>
        '''		<Description> Fix bugs </Description>
        ''' </Modifier>
        '''</Modifiers>        
        ''' <summary>
        ''' Timer LLCryoController
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PullingInterval() As Integer
            Get
                Return m_tmrPollingTimer.Interval
            End Get
            Set(ByVal value As Integer)
                Dim blnIsStart = m_tmrPollingTimer.Enabled
                m_tmrPollingTimer.Enabled = False
                m_tmrPollingTimer.Interval = value
                If (blnIsStart) Then
                    m_tmrPollingTimer.Enabled = True
                End If
            End Set
        End Property

        Public Property HasStopRequest() As Boolean
            Get
                Return m_bHasStopRequest
            End Get
            Set(ByVal value As Boolean)
                m_bHasStopRequest = value
            End Set
        End Property
#End Region



#Region "Public method"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        '''  Polling Cryo Data
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Polling(ByVal source As Object, ByVal e As ElapsedEventArgs)
            AVPLib.Log.coreLogger.Info("Enter Pulling")
            Dim EquipmentName As String = Me.EquipmentName
            Try
                m_tmrPollingTimer.Enabled = False

                GetFirstStageTemperature(EquipmentName)
                System.Threading.Thread.Sleep(ConstEnum.CRYO_POLLING_SLEEP_TIME)

                GetSecondStageTemperature(EquipmentName)
                System.Threading.Thread.Sleep(ConstEnum.CRYO_POLLING_SLEEP_TIME)

                GetRegenStatus(EquipmentName)
                System.Threading.Thread.Sleep(ConstEnum.CRYO_POLLING_SLEEP_TIME)

                GetLifeTimeHour(EquipmentName)
                System.Threading.Thread.Sleep(ConstEnum.CRYO_POLLING_SLEEP_TIME)

                GetRegenHour(EquipmentName)
                System.Threading.Thread.Sleep(ConstEnum.CRYO_POLLING_SLEEP_TIME)

                GetPumpStatus(EquipmentName)
                System.Threading.Thread.Sleep(ConstEnum.CRYO_POLLING_SLEEP_TIME)

                GetPullingStatus(EquipmentName)

                Dim MAX_TRY_TO_SEND As Integer = 10
                ''try to send when send false
                If m_blnGetCryo_P_Value = False Then
                    If m_iTimesSend < MAX_TRY_TO_SEND Then
                        System.Threading.Thread.Sleep(ConstEnum.CRYO_POLLING_SLEEP_TIME)
                        m_blnGetCryo_P_Value = StartGetCryoRegenParam()
                        m_iTimesSend += 1
                    End If
                    If m_blnGetCryo_P_Value Then
                        m_iTimesSend = 0
                    End If
                End If

                If Not HasStopRequest Then
                    m_tmrPollingTimer.Enabled = True
                End If

            Catch ex As Exception
                Throw ex
            End Try
            AVPLib.Log.coreLogger.Info("Leave Pulling")
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-14-03</date>
        ''' </author>
        ''' <summary>
        '''  Pulling LLCryoController
        ''' </summary>
        ''' <remarks></remarks>
        Private Function StartGetCryoRegenParam() As Boolean
            Dim blnResult As Boolean = False
            Try
                blnResult = AVPLib.Business.TMCryoUtility.GetExtendedPurgeTime(EquipmentName)
                System.Threading.Thread.Sleep(ConstEnum.CRYO_POLLING_SLEEP_TIME)
                blnResult = blnResult And AVPLib.Business.TMCryoUtility.GetPumpRestartDelay(EquipmentName)
                System.Threading.Thread.Sleep(ConstEnum.CRYO_POLLING_SLEEP_TIME)
                blnResult = blnResult And AVPLib.Business.TMCryoUtility.GetRateOfRise(EquipmentName)
                System.Threading.Thread.Sleep(ConstEnum.CRYO_POLLING_SLEEP_TIME)
                blnResult = blnResult And AVPLib.Business.TMCryoUtility.GetRoughToPressure(EquipmentName)
                System.Threading.Thread.Sleep(ConstEnum.CRYO_POLLING_SLEEP_TIME)
                blnResult = blnResult And AVPLib.Business.TMCryoUtility.GetRepurgeCycles(EquipmentName)
                System.Threading.Thread.Sleep(ConstEnum.CRYO_POLLING_SLEEP_TIME)
                blnResult = blnResult And AVPLib.Business.TMCryoUtility.GetStartUpTemp(EquipmentName)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return blnResult
        End Function
        Public Overrides Sub Dispose()
            'turn on stop request
            m_bHasStopRequest = True

            'stop timer
            If (m_tmrPollingTimer IsNot Nothing) Then
                m_tmrPollingTimer.Enabled = False
                'remove handler
                RemoveHandler m_tmrPollingTimer.Elapsed, AddressOf Polling
            End If
        End Sub
#End Region

#Region "Private Methods"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Get first stage temperature
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Public Function GetFirstStageTemperature(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetFirstStageTemperature")
            Try
                Dim strMessage As String = Name + "." + "$J;"
                AVPLib.Log.coreLogger.Info("Leave TurnPumpOn")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetFirstStageTemperature")
        End Function
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Get second stage temperature
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Public Function GetSecondStageTemperature(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetSecondStageTemperature")
            Try
                Dim strMessage As String = Name + "." + "$K:"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetSecondStageTemperature")
        End Function
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Get Regen status
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Public Function GetPumpStatus(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetPumpStatus")
            Try
                Dim strMessage As String = Name + "." + "$A?2"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetPumpStatus")
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Get Regen Hour
        ''' </summary>
        Public Sub GetRegenHour(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter GetRegenHour")
            Try
                Dim strMessage As String = Name + "." + "$aP"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetRegenHour")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Get Life Time Hour
        ''' </summary>
        Public Sub GetLifeTimeHour(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter GetLifeTimeHour")
            Try
                Dim strMessage As String = Name + "." + "$Y?J"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetLifeTimeHour")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' $S16 command is used for clear cryo error
        ''' </summary>
        Public Sub GetPullingStatus(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter GetPullingStatus")
            Try
                Dim strMessage As String = Name + "." + "$S16"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetPullingStatus")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Get Regen status
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Public Function GetRegenStatus(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetRegenStatus")
            Try
                Dim strMessage As String = Name + "." + "$O>"
                TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetRegenStatus")
        End Function

        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Build a 5 char length string for the value
        ''' </summary>
        Private Function AppendValueInParam(ByVal value As String) As String
            Try
                For i As Integer = 1 To MAX_CRYO_PARAM - value.Length
                    value = "0" & value
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return value
        End Function
#End Region

    End Class
End Namespace
