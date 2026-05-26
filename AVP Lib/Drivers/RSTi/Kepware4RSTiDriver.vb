Imports RSTiApdater
Namespace Driver
    Public Class Kepware4RSTiDriver
        Inherits DriverObject
        Implements IDeviceAdapter

        Private m_GroupName As String = "TM.TMC"

#Region "New"
        Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
        End Sub
#End Region

#Region "Properties"
        Public Property KepwareGroup() As String
            Get
                Return m_GroupName
            End Get
            Set(ByVal value As String)
                m_GroupName = value
            End Set
        End Property
#End Region

#Region "Implementations"
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2013-12-23</date>
        ''' </author>
        ''' <summary>
        '''  Add Channnel Tag Kepware
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub AddChannelRSTi(ByVal objRSTi As RSTiObject) Implements IDeviceAdapter.AddChannelRSTi
            AVPLib.Log.avpLogger.Info("Enter AddChannelRSTi")
            Try
                'do not implement here
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave AddChannelRSTi")
        End Sub
        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2013-12-27 </date>
        ''' </author>
        ''' <summary>
        ''' Add Adapter Info RSTI
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub AddAdapterInfoRSTi(ByVal objRSTiAdapterInfo As RSTIAdapterInfo, ByVal objPumpPackageList As Hashtable) Implements IDeviceAdapter.AddAdapterInfoRSTi
            AVPLib.Log.avpLogger.Info("Enter AddAdapterInfoRSTi")
            Try
                'do not implement here
            Catch ex As Exception
                AVPLib.Log.avpLogger.Info(ex.Message)
            End Try
            AVPLib.Log.avpLogger.Info("Leave AddAdapterInfoRSTi")
        End Sub

        Public Function SetValue(ByVal value As Double, ByVal sDriverName As String) As Boolean Implements IDeviceAdapter.SetValue
            'Return Utils.WriteCommandKepServer(DriverName, True)
        End Function

        Public Function TurnBitOff(ByVal strDriverName As String) As Boolean Implements IDeviceAdapter.TurnBitOff
            Return (Utils.WriteCommandKepServer(strDriverName, False) = String.Empty)
        End Function

        Public Function TurnBitOn(ByVal strDriverName As String) As Boolean Implements IDeviceAdapter.TurnBitOn
            Return (Utils.WriteCommandKepServer(strDriverName, True) = String.Empty)
        End Function
#End Region



    End Class
End Namespace
