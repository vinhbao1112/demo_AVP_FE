Imports System.Timers
Imports AVPLib.Driver
Imports AVPLib.Communication.TerminalDriver

Namespace Business
    Public Class CryoController
        Inherits PumpPackageController

#Region "Class Constants & Variables"
        Private m_tmrPullingTimer As Timer
        Dim m_fCryoT1Min As Single = 0
        Dim m_fCryoT1Max As Single = 100
        Dim m_fCryoT2Min As Single = 0
        Dim m_fCryoT2Max As Single = 100

#End Region

#Region "Properties"
        Public Property T1Min() As Single
            Get
                Return m_fCryoT1Min
            End Get
            Set(ByVal value As Single)
                m_fCryoT1Min = value
            End Set
        End Property

        Public Property T1Max() As Single
            Get
                Return m_fCryoT1Max
            End Get
            Set(ByVal value As Single)
                m_fCryoT1Max = value
            End Set
        End Property

        Public Property T2Min() As Single
            Get
                Return m_fCryoT2Min
            End Get
            Set(ByVal value As Single)
                m_fCryoT2Min = value
            End Set
        End Property

        Public Property T2Max() As Single
            Get
                Return m_fCryoT2Max
            End Get
            Set(ByVal value As Single)
                m_fCryoT2Max = value
            End Set
        End Property
#End Region

#Region "Public method"

        Public Overrides Sub ReconnectHandle(ByVal obj As Object, ByVal e As ReconnectEventArgs)
            'Re-Init if need
        End Sub
        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22 </date>
        ''' </author>
        ''' <summary>
        ''' Do task
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub DoTask(ByVal Message As String)
            AVPLib.Log.coreLogger.Info("Enter DoTask")
            Try
                If Message.StartsWith("Cryo.PumpRestartDelay") Then
                    Dim Value As String = Message.Replace("Cryo.PumpRestartDelay", "").Trim()
                    CryoSetPumpRestartDelay(Value)
                    Exit Try
                ElseIf Message.StartsWith("Cryo.ExtendedPurgeTime") Then
                    Dim Value As String = Message.Replace("Cryo.ExtendedPurgeTime", "").Trim()
                    CryoSetExtendedPurgeTime(Value)
                    Exit Try
                ElseIf Message.StartsWith("Cryo.RepurgeCycles") Then
                    Dim Value As String = Message.Replace("Cryo.RepurgeCycles", "").Trim()
                    CryoSetRepurgeCycles(Value)
                    Exit Try
                ElseIf Message.StartsWith("Cryo.RoughToPressure") Then
                    Dim Value As String = Message.Replace("Cryo.RoughToPressure", "").Trim()
                    CryoSetRoughToPressure(Value)
                    Exit Try
                ElseIf Message.StartsWith("Cryo.RateOfRise") Then
                    Dim Value As String = Message.Replace("Cryo.RateOfRise", "").Trim()
                    CryoSetRateOfRise(Value)
                    Exit Try
                ElseIf Message.StartsWith("Cryo.StartUpTemp") Then
                    Dim Value As String = Message.Replace("Cryo.StartUpTemp", "").Trim()
                    CryoSetStartUpTemp(Value)
                    Exit Try
                End If

                Select Case Message
                    Case "Cryo.StartFastRegen"
                        StartFastRegen()
                    Case "Cryo.StartRegen"
                        StartRegen()
                    Case "Cryo.StopRegen"
                        StopRegen()
                    Case "Cryo.TurnPumpOff"
                        TurnOff()
                    Case "Cryo.TurnPumpOn"
                        TurnOn()
                End Select
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoTask")
        End Sub


        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22 </date>
        ''' </author>
        ''' <summary>
        ''' Start regen Cryo
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StartRegen() As Boolean
            Dim bResult As Boolean = False
            Try
                Dim objPumpPackageDrv As IPumpPackageDriver = Nothing
                objPumpPackageDrv = DriverManager.GetDriver(Me.EquipmentName)
                bResult = objPumpPackageDrv.StartRegen()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bResult
        End Function


        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22 </date>
        ''' </author>
        ''' <summary>
        ''' Start fast regen Cryo
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StartFastRegen() As Boolean
            Dim bResult As Boolean = False
            Try
                Dim objPumpPackageDrv As IPumpPackageDriver = Nothing
                objPumpPackageDrv = DriverManager.GetDriver(Me.EquipmentName)
                bResult = objPumpPackageDrv.StartFastRegen()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bResult
        End Function


        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22 </date>
        ''' </author>
        ''' <summary>
        ''' Stop regen Cryo
        ''' </summary>
        ''' <remarks></remarks>
        Public Function StopRegen() As Boolean
            Dim bResult As Boolean = False
            Try
                Dim objPumpPackageDrv As IPumpPackageDriver = Nothing
                objPumpPackageDrv = DriverManager.GetDriver(Me.EquipmentName)
                bResult = objPumpPackageDrv.StopRegen()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22 </date>
        ''' </author>
        ''' <summary>
        ''' Turn on Cryo
        ''' </summary>
        ''' <remarks></remarks>
        Public Function TurnOn() As Boolean
            Dim bResult As Boolean = False
            Try
                Dim objPumpPackageDrv As IPumpPackageDriver = Nothing
                objPumpPackageDrv = DriverManager.GetDriver(Me.EquipmentName)
                bResult = objPumpPackageDrv.TurnOn()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22 </date>
        ''' </author>
        ''' <summary>
        ''' Turn off Cryo
        ''' </summary>
        ''' <remarks></remarks>
        Public Function TurnOff() As Boolean
            Dim bResult As Boolean = False
            Try
                Dim objPumpPackageDrv As IPumpPackageDriver = Nothing
                objPumpPackageDrv = DriverManager.GetDriver(Me.EquipmentName)
                bResult = objPumpPackageDrv.TurnOff()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22 </date>
        ''' </author>
        ''' <summary>
        ''' Set Extended Purge Time
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CryoSetExtendedPurgeTime(ByVal strVal As String) As Boolean
            Dim bResult As Boolean = False
            Try
                Dim objPumpPackageDrv As IPumpPackageDriver = Nothing
                objPumpPackageDrv = DriverManager.GetDriver(Me.EquipmentName)
                bResult = objPumpPackageDrv.CryoSetExtendedPurgeTime(strVal)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22 </date>
        ''' </author>
        ''' <summary>
        ''' Pump Restart Delay
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CryoSetPumpRestartDelay(ByVal strVal As String) As Boolean
            Dim bResult As Boolean = False
            Try
                Dim objPumpPackageDrv As IPumpPackageDriver = Nothing
                objPumpPackageDrv = DriverManager.GetDriver(Me.EquipmentName)
                bResult = objPumpPackageDrv.CryoSetPumpRestartDelay(strVal)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22 </date>
        ''' </author>
        ''' <summary>
        ''' Set Repurge Cycles
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CryoSetRepurgeCycles(ByVal strVal As String) As Boolean
            Dim bResult As Boolean = False
            Try
                Dim objPumpPackageDrv As IPumpPackageDriver = Nothing
                objPumpPackageDrv = DriverManager.GetDriver(Me.EquipmentName)
                bResult = objPumpPackageDrv.CryoSetRepurgeCycles(strVal)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22 </date>
        ''' </author>
        ''' <summary>
        ''' Rough To Pressure
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CryoSetRoughToPressure(ByVal strVal As String) As Boolean
            Dim bResult As Boolean = False
            Try
                Dim objPumpPackageDrv As IPumpPackageDriver = Nothing
                objPumpPackageDrv = DriverManager.GetDriver(Me.EquipmentName)
                bResult = objPumpPackageDrv.CryoSetRoughToPressure(strVal)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22 </date>
        ''' </author>
        ''' <summary>
        ''' Rate Of Rise
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CryoSetRateOfRise(ByVal strVal As String) As Boolean
            Dim bResult As Boolean = False
            Try
                Dim objPumpPackageDrv As IPumpPackageDriver = Nothing
                objPumpPackageDrv = DriverManager.GetDriver(Me.EquipmentName)
                bResult = objPumpPackageDrv.CryoSetRateOfRise(strVal)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22 </date>
        ''' </author>
        ''' <summary>
        ''' Start Up Temp
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CryoSetStartUpTemp(ByVal strVal As String) As Boolean
            Dim bResult As Boolean = False
            Try
                Dim objPumpPackageDrv As IPumpPackageDriver = Nothing
                objPumpPackageDrv = DriverManager.GetDriver(Me.EquipmentName)
                bResult = objPumpPackageDrv.CryoSetStartUpTemp(strVal)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bResult
        End Function

#End Region

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22 </date>
        ''' </author>
        ''' <summary>
        ''' Check whether Cryo communication is OK
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function IsCommunicationOK() As Boolean
            Dim bIsCommunicating As Boolean = False
            Try
                Dim objCryo As DataManagerment.Cryo = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                bIsCommunicating = objCryo.IsCommunicating
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bIsCommunicating
        End Function

        ''' <author>
        '''    	<name> Nguyen Tan Dung </name>
        '''    	<date> 2011-12-22 </date>
        ''' </author>
        ''' <summary>
        ''' Check whether Cryo status is OK
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function IsPumpPackageOK(ByRef strErrorMsg As String) As Boolean
            Dim objCryo As DataManagerment.Cryo = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Dim bResult As Boolean = True
            Try
                If objCryo.T1 < m_fCryoT1Min OrElse objCryo.T1 > m_fCryoT1Max Then
                    ' Cryo T1 is not in range
                    strErrorMsg = String.Format("{0}: Cryo T1 is not in range [{1} - {2}]", DisplayName, m_fCryoT1Min, m_fCryoT1Max)
                    bResult = False
                ElseIf objCryo.T2 < m_fCryoT2Min OrElse objCryo.T2 > m_fCryoT2Max Then
                    ' Cryo T2 is not in range
                    strErrorMsg = String.Format("{0}: Cryo T2 is not in range [{1} - {2}]", DisplayName, m_fCryoT2Min, m_fCryoT2Max)
                    bResult = False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bResult
        End Function

        Public Overrides Function IsPumpPackageOff() As Boolean
            Try
                Dim objCryo As DataManagerment.Cryo = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                If objCryo IsNot Nothing Then
                    Return objCryo.CryoOn = DataManagerment.Equipment.WorkingStatuses.Off
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())

            End Try
            Return False
        End Function

    End Class
End Namespace

