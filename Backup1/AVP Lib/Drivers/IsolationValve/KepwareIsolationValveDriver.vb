Namespace Driver
    Public Class KepwareIsolationValveDriver
        Inherits DriverObject
        Implements IValveDriver

        Private m_GroupName As String = "TM.TMC"
        Public Property KepwareGroup() As String
            Get
                Return m_GroupName
            End Get
            Set(ByVal value As String)
                m_GroupName = value
            End Set
        End Property

        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
            XPATH_KepServerTag = XPATH_KepServerTag & Me.DriverName
            XPATH_KepServerReadbackTag = XPATH_KepServerReadbackTag & Me.DriverName
            DriverUtility.ReadKepwareConfig(XPATH_KepServerTag)
            DriverUtility.RegisterKepwareReadback(m_GroupName, XPATH_KepServerReadbackTag)
        End Sub
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Open Kepware Isolation Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function OpenIsolationValve() As Boolean Implements IValveDriver.Open
            AVPLib.Log.avpLogger.Info("Enter KepwareIsolationValveDriver.OpenIsolationValve")
            Dim blReuslt As String = False
            Try
                If (AVPLib.Utils.WriteCommandKepServer(Me.DriverName, True) = String.Empty) Then
                    blReuslt = True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Enter KepwareIsolationValveDriver.OpenIsolationValve")
            Return blReuslt
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2011-11-11</date>
        ''' </author>
        ''' <summary>
        ''' Close Kepware Isolation Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function CloseIsolationValve() As Boolean Implements IValveDriver.Close
            AVPLib.Log.avpLogger.Info("Enter KepwareIsolationValveDriver.OpenIsolationValve")
            Dim blReuslt As String = False
            Try
                If (AVPLib.Utils.WriteCommandKepServer(Me.DriverName, False) = String.Empty) Then
                    blReuslt = True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Enter KepwareIsolationValveDriver.OpenIsolationValve")
            Return blReuslt
        End Function
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2014-05-21</date>
        ''' </author>
        ''' <summary>
        ''' Unknown Kepware Isolation Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Function UnknownIsolationValve() As Boolean Implements IValveDriver.Unknown
            AVPLib.Log.avpLogger.Info("Enter KepwareIsolationValveDriver.UnknownIsolationValve")
            Dim blReuslt As String = False
            Try
                If (AVPLib.Utils.WriteCommandKepServer(Me.DriverName, "Unknown") = String.Empty) Then
                    blReuslt = True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Enter KepwareIsolationValveDriver.UnknownIsolationValve")
            Return blReuslt
        End Function
    End Class
End Namespace

