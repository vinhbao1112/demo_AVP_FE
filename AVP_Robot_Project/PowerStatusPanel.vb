Imports AVPLib.ConstEnum
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.DataManagerment
Imports System.Text.RegularExpressions
Public Class PowerStatusPanel
#Region "Properties"
#End Region
#Region "Protected method"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-09-07</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbACPower As New StatusIGCGButton(btnACPower)
            Dim stbRFPower As New StatusIGCGButton(btnRFPower)
            Dim stbGrid As New StatusIGCGButton(btnGrid)
            Dim stbPBN As New StatusIGCGButton(btnPBNPower)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbACPower)
            m_stoStatusObject.AddChild(stbRFPower)
            m_stoStatusObject.AddChild(stbGrid)
            m_stoStatusObject.AddChild(stbPBN)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Events – Buttons – Forms…"
#End Region
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-09-09</date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub btnACPower_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnACPower.Click
        AVPLib.Log.guiLogger.Info("Enter btnACPower_Click")
        Dim strMessageText As String = String.Empty
        Dim strValue As String = String.Empty
        Try
            If (btnACPower.Status = BinaryStatusControl.DisplayStatus.On) Then
                strMessageText = AVPLib.ContainerData.GetMessageText("ACPowerOff")
                strValue = BinaryStatusControl.DisplayStatus.Off.ToString(STRING_G)
            Else
                strMessageText = AVPLib.ContainerData.GetMessageText("ACPowerOn")
                strValue = BinaryStatusControl.DisplayStatus.On.ToString(STRING_G)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Finally
            If (Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Question) = DialogResult.OK) Then
                Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)
                If Me.btnACPower.Status = ButtonIGCGControl.DisplayStatus.On Then
                    m_stoStatusObject.RequestStatus(Me.btnACPower.Name, STR_OFF)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Turn Off AC Power")
                Else
                    m_stoStatusObject.RequestStatus(Me.btnACPower.Name, STR_ON)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Turn On AC Power")
                End If
            End If
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnACPower_Click")
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-09-09</date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub btnRFPower_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRFPower.Click
        AVPLib.Log.guiLogger.Info("Enter btnRFPower_Click")
        Dim strMessageText As String = String.Empty
        Dim strValue As String = String.Empty
        Try
            If (btnRFPower.Status = BinaryStatusControl.DisplayStatus.On) Then
                strMessageText = AVPLib.ContainerData.GetMessageText("RFPowerOff")
                strValue = BinaryStatusControl.DisplayStatus.Off.ToString(STRING_G)
            Else
                strMessageText = AVPLib.ContainerData.GetMessageText("RFPowerOn")
                strValue = BinaryStatusControl.DisplayStatus.On.ToString(STRING_G)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Finally
            If (Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Question) = DialogResult.OK) Then
                Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)

                If Me.btnRFPower.Status = ButtonIGCGControl.DisplayStatus.On Then
                    m_stoStatusObject.RequestStatus(Me.btnRFPower.Name, STR_OFF)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Turn Off RF Power")
                Else
                    m_stoStatusObject.RequestStatus(Me.btnRFPower.Name, STR_ON)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Turn On RF Power")
                End If
            End If
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnRFPower_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-09-09</date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub btnGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrid.Click
        AVPLib.Log.guiLogger.Info("Enter btnGrid_Click")
        Dim strMessageText As String = String.Empty
        Dim strValue As String = String.Empty
        Try
            If (btnGrid.Status = BinaryStatusControl.DisplayStatus.On) Then
                strMessageText = AVPLib.ContainerData.GetMessageText("GridPowerOff")
                strValue = BinaryStatusControl.DisplayStatus.Off.ToString(STRING_G)
            Else
                strMessageText = AVPLib.ContainerData.GetMessageText("GridPowerOn")
                strValue = BinaryStatusControl.DisplayStatus.On.ToString(STRING_G)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Finally
            If (Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Question) = DialogResult.OK) Then
                If Me.btnGrid.Status = ButtonIGCGControl.DisplayStatus.On Then
                    m_stoStatusObject.RequestStatus(Me.btnGrid.Name, STR_OFF)
                Else
                    m_stoStatusObject.RequestStatus(Me.btnGrid.Name, STR_ON)
                End If

                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                  AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                  "[Main Screen] " + "Click on button Grid of Power.")
            End If
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnGrid_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-09-09</date>
    ''' </author>
    ''' <summary>
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub btnPBN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPBNPower.Click
        AVPLib.Log.guiLogger.Info("Enter btnPBN_Click")
        Dim strMessageText As String = String.Empty
        Dim strValue As String = String.Empty
        Try
            If (btnPBNPower.Status = BinaryStatusControl.DisplayStatus.On) Then
                strMessageText = AVPLib.ContainerData.GetMessageText("PBNPowerOff")
                strValue = BinaryStatusControl.DisplayStatus.Off.ToString(STRING_G)
            Else
                strMessageText = AVPLib.ContainerData.GetMessageText("PBNPowerOn")
                strValue = BinaryStatusControl.DisplayStatus.On.ToString(STRING_G)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Finally
            If (Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Question) = DialogResult.OK) Then
                Dim strChamberName = AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name)

                If Me.btnPBNPower.Status = ButtonIGCGControl.DisplayStatus.On Then
                    m_stoStatusObject.RequestStatus(Me.btnPBNPower.Name, STR_OFF)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Turn Off PBN")
                Else
                    m_stoStatusObject.RequestStatus(Me.btnPBNPower.Name, STR_ON)
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + strChamberName + "] Turn On PBN")
                End If
            End If
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnPBN_Click")
    End Sub
End Class
