Public Class ContainerData
#Region "Class Constants & Variables"
    Private Shared m_ComboItemMap As Hashtable 'Key , Value.

    Private Shared m_MessageGuiBusinessMap As Hashtable 'Key , Value.
#End Region

#Region "Robot Config"

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-10</date>
    ''' </author>
    ''' <summary>
    ''' Get ComboItem
    ''' </summary>
    ''' <param name="Key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetComboItem(ByVal Key As String) As ArrayList
        Try
            If m_ComboItemMap Is Nothing Then
                m_ComboItemMap = ContainerDAO.GetComboItem()
            End If

            Return CType(m_ComboItemMap.Item(Key), ArrayList)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
#End Region

#Region "Message Gui Business"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-09-01</date>
    ''' </author>
    ''' <summary>
    '''IsStationAvailable: check Station is Available
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsStationAvailable(ByVal StationName As String) As Boolean
        AVPLib.Log.guiLogger.Info("Enter IsStationAvailable")
        Dim blnRet As Boolean = False
        Dim ListOfStation As List(Of String) = Nothing
        Try
            ListOfStation = GetStationAvailable()
            For Each item As String In ListOfStation
                If item = StationName Then
                    blnRet = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave IsStationAvailable")
        Return blnRet
    End Function
 
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-09-01</date>
    ''' </author>
    ''' <summary>
    ''' GetStationAvailable: Get all station available
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetStationAvailable() As List(Of String)
        AVPLib.Log.guiLogger.Info("Enter GetStationAvailable")
        Dim ListOfStation As List(Of String) = New List(Of String)
        Try
            If (AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE) Then ' If chamber 1 is visible
                ListOfStation.Add(AVPLib.RobotConfigurationValues.CHAMBER1_NAME)
            End If
            If (AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE) Then ' If chamber 2 is visible
                ListOfStation.Add(AVPLib.RobotConfigurationValues.CHAMBER2_NAME)
            End If
            If (AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE)  Then ' If chamber 3 is invisible
                ListOfStation.Add(AVPLib.RobotConfigurationValues.CHAMBER3_NAME)
            End If

            If (AVPLib.RobotConfigurationValues.ALINER_VISIBLE) Then
                ListOfStation.Add(AVPLib.ConstEnum.Equipments.Aligner.ToString())
            End If
            If (AVPLib.ContainerDAO.Enable_ANYIBE_Mode) Then
                ListOfStation.Add(AVPLib.RobotConfigurationValues.ANY_IBE_CHAMBER)
                ListOfStation.Add(AVPLib.RobotConfigurationValues.ANY_PVD_CHAMBER)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave GetStationAvailable")
        Return ListOfStation
    End Function
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' MessageGuiBusiness
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Property MessageGuiBusiness() As Hashtable
        Get
            If m_MessageGuiBusinessMap Is Nothing Then
                m_MessageGuiBusinessMap = ContainerDAO.MessageGuiBusiness()
            End If
            Return m_MessageGuiBusinessMap
        End Get
        Set(ByVal value As Hashtable)
            m_MessageGuiBusinessMap = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' GetMessageValue
    ''' </summary>
    ''' <param name="MessageName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMessageGuiBusiness(ByVal MessageName As String) As String
        Try
            Dim sMessageName As String = MessageGuiBusiness.Item(MessageName)
            If sMessageName Is Nothing Then
                Dim messageParts As String() = MessageName.Split(New String() {" "}, StringSplitOptions.RemoveEmptyEntries)
                If (messageParts IsNot Nothing) And (messageParts.Length >= 2) Then
                    Dim ctrlNameAndAction As String = MessageGuiBusiness.Item(messageParts(0))
                    If String.IsNullOrEmpty(ctrlNameAndAction) Then
                        sMessageName = MessageName
                    Else
                        sMessageName = ctrlNameAndAction + MessageName.Replace(messageParts(0), "")
                    End If
                ElseIf (messageParts IsNot Nothing) And (messageParts.Length = 1) Then
                    Dim ctrlNameAndAction As String = MessageGuiBusiness.Item(messageParts(0))
                    If String.IsNullOrEmpty(ctrlNameAndAction) Then
                        sMessageName = MessageName
                    Else
                        sMessageName = ctrlNameAndAction
                    End If
                Else
                    sMessageName = MessageName
                End If
            End If
            Return sMessageName
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return Nothing
    End Function
#End Region
End Class
