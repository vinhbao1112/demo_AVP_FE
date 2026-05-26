Imports AVPLib.DataManagerment
Imports AVPLib.DataManagerment.Equipment
Imports AVPLib.ConstEnum
Imports System.Timers
Imports AVPLib.Driver
Namespace Business
    Public Class MechanicalPumpUtility
#Region "Public methods"
        Public Shared Function GetCommunicationStatus(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter IsCommunicationStatus")
            Dim bResult As Boolean = False
            Try
                Dim objMPumpDrv As MPumpCGDriver = Nothing
                objMPumpDrv = DriverManager.GetDriver(Name)
                If objMPumpDrv IsNot Nothing Then
                    bResult = IIf(objMPumpDrv.CGRelay = WorkingStatuses.On, True, False)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave IsCommunicationStatus")
            Return bResult
        End Function
        Public Shared Function SetReleaseControl(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SetReleaseControl")
            Dim bResult As Boolean = False
            Try
                Dim objMPumpDrv As MPumpCGDriver = Nothing
                objMPumpDrv = DriverManager.GetDriver(Name)
                Dim strCmd As String = "!C0"
                bResult = objMPumpDrv.SetValue(strCmd)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetReleaseControl")
            Return bResult
        End Function
        Public Shared Function TurnPumpOff(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter TurnPumpOff")
            Dim bResult As Boolean = False
            Try

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnPumpOff")
            Return bResult
        End Function
        Public Shared Function TurnPumpOn(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter TurnPumpOn")
            Dim bResult As Boolean = False
            Try
                Dim iWaittime As Int32 = 2000
                ' send take control
                SetTakeControl(Name)
                Threading.Thread.Sleep(iWaittime)
                SetTakeControl(Name)
                Threading.Thread.Sleep(iWaittime)

                ' turn on mechanical pump
                bResult = SetPumpOn(Name)
                Threading.Thread.Sleep(iWaittime)
                bResult = bResult AndAlso SetPumpOn(Name)
                Threading.Thread.Sleep(iWaittime)

                ' release control
                SetReleaseControl(Name)
                Threading.Thread.Sleep(iWaittime)
                SetReleaseControl(Name)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnPumpOn")
            Return bResult
        End Function
        Public Shared Function SetTakeControl(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SetTakeControl")
            Dim bResult As Boolean = False
            Try
                Dim objMPumpDrv As MPumpCGDriver = Nothing
                objMPumpDrv = DriverManager.GetDriver(Name)
                Dim strCmd As String = "!C1"
                bResult = objMPumpDrv.SetValue(strCmd)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetTakeControl")
            Return bResult
        End Function
        Public Shared Function SetPumpOn(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SetPumpOn")
            Dim bResult As Boolean = False
            Try
                Dim objMPumpDrv As MPumpCGDriver = Nothing
                objMPumpDrv = DriverManager.GetDriver(Name)

                Dim strCmd As String = "!P1"
                bResult = objMPumpDrv.SetValue(strCmd)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SetPumpOn")
            Return bResult
        End Function
#End Region
    End Class
End Namespace

