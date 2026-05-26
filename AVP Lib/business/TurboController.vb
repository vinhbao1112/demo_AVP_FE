Imports System.Threading
Imports AVPLib.DataManagerment
Imports AVPLib.DataManagerment.Equipment
Imports AVPLib.ConstEnum
Imports System.Timers
Imports AVPLib.Driver
Namespace Business
    Public Class TurboController
        Inherits PumpPackageController

        ''' <author>
        '''    	<name> Dung Nguyen </name>
        '''    	<date> 2011-12-01</date>
        ''' </author>
        ''' <summary>
        ''' DoTask
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <remarks></remarks>
        Public Overrides Sub DoTask(ByVal Message As String)
            AVPLib.Log.coreLogger.Info("Enter DoTask")
            Try
                Select Case Message
                    Case "Turbo.Start"
                        TurnOn()
                    Case "Turbo.Stop"
                        TurnOff()
                    Case Else
                        AVPLib.Log.avpLogger.ErrorFormat("Unknown message '{0}'", Message)
                End Select
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoTask")
        End Sub

        ''' <author>
        '''    	<name> Dung Nguyen </name>
        '''    	<date> 2011-12-01</date>
        ''' </author>
        ''' <summary>
        ''' Turn On Turbo
        ''' </summary>
        ''' <param name="Message"></param>
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
        '''    	<name> Dung Nguyen </name>
        '''    	<date> 2011-12-01</date>
        ''' </author>
        ''' <summary>
        ''' Turn Off Turbo
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
        '''    	<name> Dung Nguyen </name>
        '''    	<date> 2011-12-01</date>
        ''' </author>
        ''' <summary>
        ''' Check whether Turbo communication is ok
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function IsCommunicationOK() As Boolean
            Dim bIsCommunicating As Boolean = False
            Try
                Dim objTurbo As DataManagerment.Turbo = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                bIsCommunicating = objTurbo.IsTurboCommunicating
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bIsCommunicating
        End Function

        ''' <author>
        '''    	<name> Dung Nguyen </name>
        '''    	<date> 2011-12-01</date>
        ''' </author>
        ''' <summary>
        ''' Check whether Turbo is up to speed
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <remarks></remarks>
        Public Overrides Function IsPumpPackageOK(ByRef strErrorMsg As String) As Boolean
            Dim objTurbo As DataManagerment.Turbo = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
            Dim bResult As Boolean = True
            Try
                'Check turbo up to speed
                If Not objTurbo.TurboUptoSpeed Then
                    strErrorMsg = String.Format("{0}: Turbo is not up to speed", DisplayName)
                    bResult = False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return bResult
        End Function

        ''' <author>
        '''    	<name> Dung Nguyen </name>
        '''    	<date> 2011-12-01</date>
        ''' </author>
        ''' <summary>
        ''' Turn on/off turbo
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <remarks></remarks>
        Public Overrides Function StartPumpPackage(ByVal bStart As Boolean) As Boolean
            AVPLib.Log.coreLogger.Info("Enter StartPumpPackage")
            Dim bResult As Boolean = False
            Try
                If bStart Then
                    bResult = TurnOn()
                Else
                    bResult = TurnOff()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave StartPumpPackage")
            Return bResult
        End Function


        Public Overrides Function IsPumpPackageOff() As Boolean
            Try
                Dim objTurbo As DataManagerment.Turbo = DataManagerment.EquipmentManager.GetEquipment(Me.EquipmentName)
                If objTurbo IsNot Nothing Then
                    Return (objTurbo.TurboStatus = False AndAlso objTurbo.TurboUptoSpeed = False)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())

            End Try
            Return False
        End Function

        ''' <author>
        '''    	<name> Kiet Tran </name>
        '''    	<date> 2021-10-22</date>
        ''' </author>
        ''' <summary>
        ''' Turn on/off turbo
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <remarks></remarks>
        Public Function TurnOnOff(ByVal bStart As Boolean, ByVal forelineCGRelayStatus As WorkingStatuses) As Boolean
            AVPLib.Log.coreLogger.Info("Enter TurnOnOff")
            Dim bResult As Boolean = False
            Try
                If bStart Then
                    If forelineCGRelayStatus = WorkingStatuses.Off Then
                        Utils.ThrowAlarm("Can Not Turn On Turbo Due To Foreline CG Relay Was Not On")
                    Else
                        bResult = TurnOn()
                    End If
                Else
                    bResult = TurnOff()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOnOff")
            Return bResult
        End Function

    End Class
End Namespace

