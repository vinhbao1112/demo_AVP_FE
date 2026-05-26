Public Class StatusSlitValveControl
    Inherits AVPControls.StatusObject
    Private m_objHandler As SlitValve

    Public Property HandledObject()
        Get
            Return m_objHandler
        End Get
        Set(ByVal value)
            m_objHandler = value
        End Set
    End Property

    Public Sub New(ByVal handler As SlitValve)
        Try
            m_objHandler = handler
            Me.Name = m_objHandler.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim status As SlitValve.SlitValveDisplayStatus = SlitValve.ParseStatus(arg)

            If (m_objHandler.DockPosition = SlitValve.SlitValvePositions.PM1 _
                    AndAlso Not AVPLib.ContainerData.IsChamberVisible(AVPLib.ConstEnum.Equipments.Chamber1.ToString())) _
                OrElse (m_objHandler.DockPosition = SlitValve.SlitValvePositions.PM2 _
                    AndAlso Not AVPLib.ContainerData.IsChamberVisible(AVPLib.ConstEnum.Equipments.Chamber2.ToString())) _
                OrElse (m_objHandler.DockPosition = SlitValve.SlitValvePositions.PM3 _
                    AndAlso Not AVPLib.ContainerData.IsChamberVisible(AVPLib.ConstEnum.Equipments.Chamber3.ToString())) _
                OrElse (m_objHandler.DockPosition = SlitValve.SlitValvePositions.LLA _
                    AndAlso Not AVPLib.ContainerData.IsChamberVisible(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())) Then
                status = SlitValve.SlitValveDisplayStatus.Off
            End If

            If m_objHandler.DockPosition = SlitValve.SlitValvePositions.HivacLLA Then
                ContainerForm.ProcessPanel.lpcLoadLockA.Enable_Disable_StartButton()
            End If

            m_objHandler.Status = status

            If m_objHandler.InScreen = AVPLib.ConstEnum.Support_Screen.TM AndAlso m_objHandler.IsPMSlitValve Then
                Dim chamberObj As ChamberPanel = ContainerForm.ChamberPanel(AVPLib.ConstEnum.Chamber & m_objHandler.PositionIndex.ToString())
                If chamberObj IsNot Nothing Then
                    chamberObj.SlitValveStatus = status
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub

    Public Overrides Sub RequestStatus(ByVal Identification As String, ByVal Value As String)

    End Sub
End Class
