Imports AVP_Robot_Project.ConstantAndEnum
Imports AVP_Robot_Project.PVDSupport
Imports AVPLib
Imports AVPLib.ConstEnum

Public Class RobotArmStatusPanel
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim sbcEXStatus As New StatusIGCGButton(btnEXStatus)
            Dim sbcREStatus As New StatusIGCGButton(btnREStatus)
            Dim sbcUPStatus As New StatusIGCGButton(btnUPStatus)
            Dim sbcDNStatus As New StatusIGCGButton(btnDNStatus)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(sbcEXStatus)
            m_stoStatusObject.AddChild(sbcREStatus)
            m_stoStatusObject.AddChild(sbcDNStatus)
            m_stoStatusObject.AddChild(sbcUPStatus)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class

