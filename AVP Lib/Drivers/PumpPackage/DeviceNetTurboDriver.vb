Imports AVPLib.DataManagerment
Namespace Driver
    Public Class DeviceNetTurboDriver
        Inherits DriverObject
        Implements IPumpPackageDriver

#Region "Variables"
        Private m_bTurboStatus As Boolean = False
#End Region

#Region "Constructors & Dispose"
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-02-13 </date>
        ''' </author>
        ''' <summary>
        ''' Contrucctor
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
            Me.EquipmentName = sDriverName
            UpdateStatus("IsTurboCommunicating", True)
        End Sub
#End Region

#Region "IPumpackageInterface"
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-02-13 </date>
        ''' </author>
        ''' <summary>
        ''' Turn off Turbo
        ''' </summary>
        Public Function TurnOff() As Boolean Implements IPumpPackageDriver.TurnOff
            AVPLib.Log.coreLogger.Info("Enter TurnOff")
            Dim bResult As Boolean = False
            Try
                AVPLib.Log.avpLogger.Debug("Enter DeviceNetTurboDriver.TurnOff")

                Dim strMessage As String = String.Empty
                Dim objRSTiDriver As AdapterDriver = Nothing

                strMessage = Me.DriverName & ".TurboStatus"
                objRSTiDriver = DriverManager.GetDriver(strMessage)

                If (objRSTiDriver IsNot Nothing) Then
                    bResult = objRSTiDriver.TurnBitOff(strMessage)
                End If

                AVPLib.Log.avpLogger.Debug("Leave DeviceNetTurboDriver.TurnOff")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOff")
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-02-13 </date>
        ''' </author>
        ''' <summary>
        ''' Turn on Turbo
        ''' </summary>
        Public Function TurnOn() As Boolean Implements IPumpPackageDriver.TurnOn
            AVPLib.Log.coreLogger.Info("Enter TurnOn")
            Dim bResult As Boolean = False
            Try
                AVPLib.Log.avpLogger.Debug("Enter DeviceNetTurboDriver.TurnOn")

                Dim strMessage As String = String.Empty
                Dim objRSTiDriver As AdapterDriver = Nothing

                strMessage = Me.DriverName & ".TurboStatus"
                objRSTiDriver = DriverManager.GetDriver(strMessage)

                If (objRSTiDriver IsNot Nothing) Then
                    bResult = objRSTiDriver.TurnBitOn(strMessage)
                End If

                AVPLib.Log.avpLogger.Debug("Leave DeviceNetTurboDriver.TurnOn")
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOn")
            Return bResult
        End Function
#End Region

#Region "Cryo functions - Not implement in Turbo driver"
        Public Function CryoSetExtendedPurgeTime(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetExtendedPurgeTime
            AVPLib.Log.coreLogger.Error("CryoSetExtendedPurgeTime does not suppport by Turbo")
            Return False
        End Function

        Public Function CryoSetPumpRestartDelay(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetPumpRestartDelay
            AVPLib.Log.coreLogger.Error("CryoSetPumpRestartDelay does not suppport by Turbo")
            Return False
        End Function

        Public Function CryoSetRateOfRise(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetRateOfRise
            AVPLib.Log.coreLogger.Error("CryoSetRateOfRise does not suppport by Turbo")
            Return False
        End Function

        Public Function CryoSetRepurgeCycles(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetRepurgeCycles
            AVPLib.Log.coreLogger.Error("CryoSetRepurgeCycles does not suppport by Turbo")
            Return False
        End Function

        Public Function CryoSetRoughToPressure(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetRoughToPressure
            AVPLib.Log.coreLogger.Error("CryoSetRoughToPressure does not suppport by Turbo")
            Return False
        End Function

        Public Function CryoSetStartUpTemp(ByVal strVal As String) As Boolean Implements IPumpPackageDriver.CryoSetStartUpTemp
            AVPLib.Log.coreLogger.Error("CryoSetStartUpTemp does not suppport by Turbo")
            Return False
        End Function

        Public Function StartFastRegen() As Boolean Implements IPumpPackageDriver.StartFastRegen
            AVPLib.Log.coreLogger.Error("StartFastRegen does not suppport by Turbo")
            Return False
        End Function

        Public Function StartRegen() As Boolean Implements IPumpPackageDriver.StartRegen
            AVPLib.Log.coreLogger.Error("StartRegen does not suppport by Turbo")
            Return False
        End Function

        Public Function StopRegen() As Boolean Implements IPumpPackageDriver.StopRegen
            AVPLib.Log.coreLogger.Error("StopRegen does not suppport by Turbo")
            Return False
        End Function
#End Region

        Private Sub UpdateStatus(ByVal PropertyName As String, ByVal ReplyValue As Object)
            Dim arrPropertyNames As New ArrayList()
            Dim arrDecodedValues As New ArrayList()
            arrPropertyNames.Add(PropertyName)
            arrDecodedValues.Add(ReplyValue)
            EquipmentManager.ChangeStatus(EquipmentName, arrPropertyNames, arrDecodedValues)
        End Sub

    End Class
End Namespace
