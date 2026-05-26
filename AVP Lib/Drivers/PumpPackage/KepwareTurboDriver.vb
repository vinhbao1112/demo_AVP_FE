Imports AVPLib.DataManagerment
Namespace Driver
    Public Class KepwareTurboDriver
        Inherits DriverObject
        Implements IPumpPackageDriver

        Private m_GroupName As String = "TM.TMC"
#Region "Constructors & Dispose"
        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-05-30</date>
        ''' </author>
        ''' <summary>
        ''' Contrucctor
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
            Me.EquipmentName = sDriverName
            XPATH_KepServerTag = XPATH_KepServerTag & Me.DriverName
            XPATH_KepServerReadbackTag = XPATH_KepServerReadbackTag & Me.DriverName
            DriverUtility.ReadKepwareConfig(XPATH_KepServerTag)
            DriverUtility.RegisterKepwareReadback(m_GroupName, XPATH_KepServerReadbackTag)
            UpdateStatus("IsTurboCommunicating", True)
        End Sub
#End Region

#Region "IPumpackageInterface"
        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2012-03-12</date>
        ''' </author>
        ''' <summary>
        ''' Turn off Turbo
        ''' </summary>
        Public Function TurnOff() As Boolean Implements IPumpPackageDriver.TurnOff
            AVPLib.Log.coreLogger.Info("Enter TurnOff")
            Dim bResult As Boolean = False
            Try
                AVPLib.Log.avpLogger.Debug("Enter KepwarePumpPackageDriver.TurnOff")
                Dim ErrorMessage As String = String.Empty
                Try
                    ErrorMessage = Utils.WriteCommandKepServer(Me.DriverName & ".TurboStatus", False)
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.Message)
                End Try
                AVPLib.Log.avpLogger.Debug("Leave KepwarePumpPackageDriver.TurnOff")
                Return IIf(ErrorMessage = String.Empty, True, False)

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
        ''' Turn on Turbo
        ''' </summary>
        Public Function TurnOn() As Boolean Implements IPumpPackageDriver.TurnOn
            AVPLib.Log.coreLogger.Info("Enter TurnOn")
            Dim bResult As Boolean = False
            Try
                AVPLib.Log.avpLogger.Debug("Enter KepwarePumpPackageDriver.TurnOn")
                Dim ErrorMessage As String = String.Empty
                Try
                    ErrorMessage = Utils.WriteCommandKepServer(Me.DriverName & ".TurboStatus", True)
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.Message)
                End Try
                AVPLib.Log.avpLogger.Debug("Leave KepwarePumpPackageDriver.TurnOn")
                Return IIf(ErrorMessage = String.Empty, True, False)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOn")
            Return bResult
        End Function

#Region "Cryo functions - Not implement in Turbo driver"
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
#End Region

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
