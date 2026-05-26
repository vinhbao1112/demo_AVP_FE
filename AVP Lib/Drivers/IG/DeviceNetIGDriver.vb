'''BASE DEVICE NET IG DRIVER
'''THIS CLASS HOLD SOME INFO OF IG
'''     + PRESSURE
'''     + STATUS OF DEVICE NET SCANNER
'''     + STATUS OF IG
'''     + TYPE OF IG (DEFAULT IS GP354)
''' PERFORM SOME ACTION AS
'''     + TURN IG ON/OFF
''' ALL IMPLEMENT ON CHILD OBJECT
Imports avplib.DeviceNet
Public Enum DeviceNetIGCGType
    GP354
    GP275
    GP355
End Enum
Namespace Driver
    Public Class DeviceNetIGDriver
        Inherits DeviceNetDriver
        Implements IIGDriver

        Protected m_arrPressVal() As Byte = Nothing
        Protected m_fPressure As Single = 0
        Protected m_Communication As Boolean = False
        Protected m_bIsOn As Boolean = False
        Protected m_deviceNetIGType As DeviceNetIGCGType
        Protected m_IsUpdateCommunicationError As Boolean = False

        Protected m_arrFirmwareVersion() As Byte = Nothing
        Protected m_IsRevisionNoValuesVersion As Boolean = False
        ''' <summary>
        ''' Get the IG Pressure from the real device
        ''' </summary>
        Public Overrides Sub Poll()
            Try
                If m_DeviceStatus IsNot Nothing Then
                    ' Get the pressure value
                    ReadValue()
                    If m_bIsOn Then
                        DriverUtility.UpdateIGStatus(Me.EquipmentName, DataManagerment.Equipment.WorkingStatuses.On)
                        DriverUtility.UpdateIGPressure(Me.EquipmentName, m_fPressure)
                    Else
                        m_fPressure = 0.0F
                        DriverUtility.UpdateIGPressure(Me.EquipmentName, m_fPressure)
                        DriverUtility.UpdateIGStatus(Me.EquipmentName, DataManagerment.Equipment.WorkingStatuses.Off)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
        End Sub

        ''' <summary>
        ''' GP 354 or GP275
        ''' </summary>
        Public Property DNIGType() As DeviceNetIGCGType
            Get
                Return m_deviceNetIGType
            End Get
            Set(ByVal value As DeviceNetIGCGType)
                m_deviceNetIGType = value
            End Set
        End Property

        ''' <summary>
        ''' Read Pressure Value
        ''' </summary>
        Public Overridable Sub ReadValue()
            ' will be implemented in subclass
        End Sub

        ''' <summary>
        ''' CG Pressure
        ''' </summary>
        Public ReadOnly Property Pressure() As Single Implements IIGDriver.IGPressure
            Get
                Return m_fPressure
            End Get
        End Property

        Protected m_FirmwareVersionVal As String = String.Empty
        Public Property FirmwareVersionVal() As String
            Get
                Return m_FirmwareVersionVal
            End Get
            Set(ByVal value As String)
                m_FirmwareVersionVal = value
            End Set
        End Property

        Protected m_SoftwareVersionVal As String = String.Empty
        Public Property SoftwareVersionVal() As String
            Get
                Return m_SoftwareVersionVal
            End Get
            Set(ByVal value As String)
                m_SoftwareVersionVal = value
                RevisionNoValues = m_FirmwareVersionVal & " - " & m_SoftwareVersionVal

            End Set
        End Property
        Private m_RevisionNoValues As String
        Public Property RevisionNoValues() As String
            Get
                Return m_RevisionNoValues
            End Get
            Set(ByVal value As String)
                If m_RevisionNoValues <> value Then
                    m_RevisionNoValues = value
                    DriverUtility.UpdateRevisionNoValues(Me.EquipmentName, m_RevisionNoValues)
                End If
            End Set
        End Property
        Public Sub UpdateDeviceCommunication()
            Dim old_comm As Boolean = m_Communication
            m_Communication = IsDeviceActive()
            If (old_comm <> m_Communication Or Not m_IsUpdateCommunicationError) Then
                If (m_Communication) Then
                    DriverUtility.UpdateIGCommunication(EquipmentName, AVPLib.DataManagerment.Equipment.WorkingStatuses.On)
                Else
                    DriverUtility.UpdateIGCommunication(EquipmentName, AVPLib.DataManagerment.Equipment.WorkingStatuses.Off)
                    m_fPressure = 0.0
                    m_bIsOn = False
                End If
                m_IsUpdateCommunicationError = True
            End If
        End Sub
        ''' <summary>
        ''' Is On
        ''' </summary>
        Public ReadOnly Property IsOn() As Boolean
            Get
                Return m_bIsOn
            End Get
        End Property

        ''' <summary>
        ''' Switch IG Filament 1
        ''' </summary>
        Public Overridable Function SwitchIGFilament1() As Boolean Implements IIGDriver.SwitchIGFilament1
            ' Will be implemented in sub-class
        End Function

        ''' <summary>
        ''' Switch IG Filament 2
        ''' </summary>
        Public Overridable Function SwitchIGFilament2() As Boolean Implements IIGDriver.SwitchIGFilament2
            ' Will be implemented in sub-class
        End Function

        ''' <summary>
        ''' Turn Filament On/Off
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overridable Sub TurnIGOnOff(ByVal bOn As Boolean)
            ' Will be implemented in sub-class
        End Sub

        ''' <summary>
        ''' Turn IG On
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overridable Function TurnOnIG() As Boolean Implements IIGDriver.TurnOnIG
            ' Will be implemented in sub-class
        End Function
        ''' <summary>
        ''' Turn IG On
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overridable Function TurnOffIG() As Boolean Implements IIGDriver.TurnOffIG
            ' Will be implemented in sub-class
        End Function
        ''' <summary>
        ''' Turn IG On
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overridable Function TurnOnIGDegas() As Boolean Implements IIGDriver.TurnOnIGDegas
            ' Will be implemented in sub-class
        End Function
        ''' <summary>
        ''' Turn IG On
        ''' </summary>
        ''' <param name="bOn"></param>
        Public Overridable Function TurnOffIGDegas() As Boolean Implements IIGDriver.TurnOffIGDegas
            ' Will be implemented in sub-class
        End Function
        ''' <summary>
        ''' Clean Up
        ''' </summary>
        Public Sub CleanUp()
            m_bIsDisposing = True
        End Sub

        ''' <summary>
        ''' New object IG device net
        ''' default IG device net type is GP 354
        ''' </summary>
        Public Sub New(ByVal sDriverName As String, _
                    ByVal iMacID As UShort, _
                    Optional ByVal eDeviceNetIGType As DeviceNetIGCGType = DeviceNetIGCGType.GP354)
            MyBase.new(sDriverName)
            m_DeviceConfig.MacId = iMacID
            m_deviceNetIGType = eDeviceNetIGType
        End Sub

        Public Sub New(ByVal sDriverName As String)
            MyBase.new(sDriverName)
        End Sub
    End Class
End Namespace
