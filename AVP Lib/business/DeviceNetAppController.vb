Imports System.Timers
Imports AVPLib.DataManagerment
Imports System.Xml

Namespace Business
    Public Class DeviceNetAppController
        Inherits ControllerObject
#Region "Class Constants & Variables"
        Private m_tmrPullingTimer As Timer

        ' Start tick count for sending request command
        Private Shared m_lLastTckCntRequestCommand As Int64 = Environment.TickCount
        Private Shared m_bIsSendXML As Boolean = True
        Private m_ExitDeviceNetApp As Boolean = False
#End Region

#Region "Properties"
        Public Property PullingInterval() As Integer
            Get
                Return m_tmrPullingTimer.Interval
            End Get
            Set(ByVal value As Integer)
                Dim blnIsStart = m_tmrPullingTimer.Enabled
                m_tmrPullingTimer.Enabled = False
                m_tmrPullingTimer.Interval = value
                If (blnIsStart) Then
                    m_tmrPullingTimer.Enabled = True
                End If
            End Set
        End Property

        Public Property IsSendXML() As Boolean
            Get
                Return m_bIsSendXML
            End Get
            Set(ByVal value As Boolean)
                m_bIsSendXML = value
            End Set
        End Property

        Public Property ExitDeviceNetApp() As Boolean
            Get
                Return m_ExitDeviceNetApp
            End Get
            Set(ByVal value As Boolean)
                m_ExitDeviceNetApp = value
            End Set
        End Property
#End Region

#Region "Constructors & Dispose"
        Public Sub New()
            m_tmrPullingTimer = New Timer
            AddHandler m_tmrPullingTimer.Elapsed, AddressOf Pulling
            m_tmrPullingTimer.Interval = 2000
            m_tmrPullingTimer.Enabled = True
        End Sub

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2011-12-13 </date>
        ''' </author>
        ''' <summary>
        ''' Dispose Aligner Object
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Dispose()
            AVPLib.Log.coreLogger.Info("Enter Dispose")
            Try
                If m_ExitDeviceNetApp Then
                    SendCommandToDeviceNetApp("0,0,0,0,ExitApp,")
                End If
                m_tmrPullingTimer.Enabled = False
                RemoveHandler m_tmrPullingTimer.Elapsed, AddressOf Pulling
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Dispose")
        End Sub
#End Region

#Region "Public method"
        Public Overrides Sub DoTask(ByVal Message As String)
            AVPLib.Log.coreLogger.Info("Enter DoTask")
            Try
                Select Case Message
                    ' Add new task here
                End Select
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoTask")
        End Sub
        Public Sub Pulling(ByVal source As Object, ByVal e As ElapsedEventArgs)
            AVPLib.Log.coreLogger.Info("Enter Pulling")
            Try
                m_tmrPullingTimer.Enabled = False

                ' Send XML String to DeviceNetApp
                If RobotConfigurationValues.DEVICENETAPP_VISIBLE Then

                    If IsSendXML AndAlso AVPLib.Driver.DriverManager.xmlIO IsNot Nothing AndAlso _
                            Not String.IsNullOrEmpty(AVPLib.Driver.DriverManager.xmlIO.OuterXml) Then
                        If SendXMLStringToDeviceNetApp(AVPLib.Driver.DriverManager.xmlIO.OuterXml) Then
                            'If tick count is over 10 seconds, send request command if first time.
                            If Utils.GetTickCountDelta(m_lLastTckCntRequestCommand) > 1000 Then
                                'Send request command
                                If SendRequestAllData() Then
                                    'Store the last time saving
                                    m_lLastTckCntRequestCommand = Environment.TickCount

                                    'Update flag
                                    IsSendXML = False
                                End If
                            End If
                        End If
                    End If
                End If

                m_tmrPullingTimer.Enabled = True
            Catch ex As Exception
                Throw ex
            End Try
            AVPLib.Log.coreLogger.Info("Leave Pulling")
        End Sub
#End Region

#Region "Private methods"
        Public Function SendRequestAllData() As Boolean
            AVPLib.Log.coreLogger.Info("Enter SendRequestAllData")

            Dim sAVPRequestData As String = "0,0,0,0,RequestData,0"

            Return Utils.SendCommandPMServer(Me.EquipmentName, sAVPRequestData)

            AVPLib.Log.coreLogger.Info("Enter SendRequestAllData")
        End Function

        Public Function SendXMLStringToDeviceNetApp(ByVal sXML As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SendXMLStringToDeviceNetApp")

            Dim sAVPXMLCommand As String = "0,0,0,0,InitConfig," + sXML

            Return Utils.SendCommandPMServer(Me.EquipmentName, sAVPXMLCommand)

            AVPLib.Log.coreLogger.Info("Enter SendXMLStringToDeviceNetApp")
        End Function

        Public Function SendCommandToDeviceNetApp(ByVal sCommand As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SendCommandToDeviceNetApp")

            Return Utils.SendCommandPMServer(Me.EquipmentName, sCommand)

            AVPLib.Log.coreLogger.Info("Enter SendCommandToDeviceNetApp")
        End Function
#End Region
    End Class
End Namespace