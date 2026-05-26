Imports AVPLib.Business
Imports AVPLib.DataManagerment

Namespace Driver
    Public Class DeviceNetAppDriver
        Inherits DriverObject
        Implements IDeviceStatus

        Protected m_objDnetAppController As DeviceNetAppController = Nothing
        Protected m_objDnetAppEquipment As DeviceNetApp = Nothing
        Protected m_strComName As String = String.Empty
        Protected m_sMacID As UShort = 0

        Public WriteOnly Property DnetAppController() As DeviceNetAppController
            Set(ByVal value As DeviceNetAppController)
                m_objDnetAppController = value
            End Set
        End Property

        Public WriteOnly Property DnetAppEquipment() As DeviceNetApp
            Set(ByVal value As DeviceNetApp)
                m_objDnetAppEquipment = value
            End Set
        End Property

        ''' <summary>
        ''' Constructor
        ''' </summary>
        ''' <param name="p_objMaster"></param>
        Public Sub New(ByVal sDeviceName As String)
            MyBase.new(sDeviceName)
            m_objDnetAppController = Business.ControllerManager.GetController(ConstEnum.Equipments.DeviceNetApp.ToString())
            m_objDnetAppEquipment = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.DeviceNetApp.ToString())
        End Sub

        ''' <summary>
        ''' Check if the current device is OK or not
        ''' </summary>
        ''' <returns></returns>
        Public Function IsDeviceActive() As Boolean Implements IDeviceStatus.IsDeviceActive
            If m_objDnetAppEquipment IsNot Nothing Then
                If m_objDnetAppEquipment.DeviceNetBus <> Equipment.WorkingStatuses.On Then
                    Return False
                End If
                Dim pInfo As System.Reflection.PropertyInfo = m_objDnetAppEquipment.GetType().GetProperty(m_strComName)
                Dim propValue As Object = pInfo.GetValue(m_objDnetAppEquipment, Reflection.BindingFlags.GetProperty, Nothing, Nothing, Nothing)
                Return CType(propValue, DataManagerment.Equipment.WorkingStatuses) = Equipment.WorkingStatuses.On
            End If
            Return False
        End Function

        Public Function SendCommandToDeviceNetApp(ByVal sCommand As String) As Boolean
            If m_objDnetAppController IsNot Nothing Then
                Return m_objDnetAppController.SendCommandToDeviceNetApp(sCommand)
            End If
            Return False
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        Public Overrides Sub Dispose()
            MyBase.Dispose()
        End Sub

    End Class
End Namespace