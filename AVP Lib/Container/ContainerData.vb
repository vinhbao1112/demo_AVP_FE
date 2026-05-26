Imports AVPLib.Business
Imports AVPLib.SequenceLib
Imports AVPLib.ConstEnum
Imports System.Xml

Public Class ContainerData

    Public Class LogSource
        Public Shared Robot As String = "Robot"
        Public Shared LoadLockA As String = "LLA"
        Public Shared Aligner As String = "Aligner"
        Public Shared LLACryo As String = "LLA Cryo"
        Public Shared TMCryo As String = "TM Cryo"
        Public Shared TMWaterPump As String = "TM WaterPump"
        Public Shared AVPMainScreen As String = "GUI"
        Public Shared KepServer As String = "Kep Server"
        Public Shared AVPFrontEnd As String = "AVP Front End"
        Public Shared AVPBackEnd As String = "AVP Back End"
        Public Shared DeviceNet As String = "DeviceNet"
    End Class

#Region "Class Constants & Variables"
    Public Shared TypeUser As String = "User"
    Public Shared TypeWarning As String = "Warning"
    Public Shared TypeAlarm As String = "Alarm"
    Public Shared TypeEvent As String = "Event"
    Public Shared TypeMessage As String = "Message"

    Private Shared m_AlarmMsgs As AlarmMsgItems = New AlarmMsgItems

    Private Shared m_UserLogin As DBUser
    Private Shared m_UserMap As Hashtable 'Key Username, value User Object
    Private Shared m_ListUser As ArrayList 'List String Username
    Private Shared m_ListGroup As ArrayList 'List DBGroup

    Private Shared m_ChamberMap As Hashtable 'Key ChamberName, Value Chamber Object.

    Private Shared m_ListSequenceName As ArrayList

    Private Shared m_ListOfViewRecipe As Dictionary(Of String, HRecipeLibrary.HRecipe)

    Private Shared m_DataTable_Log As DataTable

    Private Shared m_ComboItemMap As Hashtable 'Key , Value.

    Private Shared m_MessageGuiBusinessMap As Hashtable 'Key , Value.

    Private Shared m_MessageConfig As Hashtable

    Private Shared m_ValueMessageConfig As Hashtable

    Private Shared m_ErrorMessageConfig As Hashtable

    Private Shared m_PollingConfig As Hashtable

    Private Shared m_TimeoutConfig As Hashtable

    Private Shared m_IBEMaintenanceMap As Hashtable
    Friend Shared m_IBEMaintenanceCodeMap As Hashtable

    Private Shared m_PVDMaintenanceMap As Hashtable
    Friend Shared m_PVDMaintenanceCodeMap As Hashtable

    Private Shared m_DeviceNetAppMaintenanceMap As Hashtable
    Friend Shared m_DeviceNetAppMaintenanceCodeMap As Hashtable

    Private Shared m_CoronaMaintenanceMap As Hashtable    'Corona
    Friend Shared m_CoronaMaintenanceCodeMap As Hashtable 'Corona

    Private Shared m_PVD5TMaintenanceMap As Hashtable    'Corona
    Friend Shared m_PVD5TMaintenanceCodeMap As Hashtable 'Corona

    Private Shared m_InitConfig As Hashtable

    Private Shared m_RobotConfigMap As Hashtable 'Key , Value.
    Private Shared m_RobotPressureConfigMap As Hashtable 'Key , Value.
    Private Shared m_TransferPressureSetpointMap As Hashtable 'Key , Value.
    Private Shared m_LLAElevatorConfigMap As Hashtable 'Key , Value.
    Private Shared m_PumdownConfigMapLL As Hashtable 'Key , Value.
    Private Shared m_PumdownConfigMapTM As Hashtable  'Key , Value.
    Private Shared m_VentConfigMapLL As Hashtable  'Key , Value.
    Private Shared m_VentConfigMapTM As Hashtable  'Key , Value.
    Private Shared m_MessageTextMap As Hashtable 'Key , Value.
    Private Shared m_CGConfigMap As Hashtable  'Key , Value.
    Private Shared m_MessageTextDoc As System.Xml.XmlDocument

    Private Shared m_hstPVDRecipeTemplates As Dictionary(Of String, DBChamber) 'key=ChamberType.ChamberName, dbChamber
    Private Shared m_hstHidenColumnInDataRun As Hashtable
    Public Shared m_dicSystemRestore As Dictionary(Of String, Object)
#End Region

#Region "Get Data"
#Region "User-Group"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Property of UserMap
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property UserMap() As Hashtable
        Get
            If m_UserMap Is Nothing Then
                m_UserMap = New Hashtable()
            End If
            Return m_UserMap
        End Get
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Property of User
    ''' </summary>
    ''' <param name="username"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function User(ByVal username As String) As DBUser
        For Each Item As DictionaryEntry In UserMap
            If String.Compare(Item.Key, username, True) = 0 Then ' InCase-Sensitive
                Return Item.Value
            End If
        Next
        Dim m_User As DBUser = ContainerDAO.GetUser(username)
        UserMap.Add(username, m_User)
        Return m_User
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Property of UserLogin
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property UserLogin() As DBUser
        Get
            Return m_UserLogin
        End Get
        Set(ByVal value As DBUser)
            m_UserLogin = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Property of AlarmMsgs
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property AlarmMsgs() As AlarmMsgItems
        Get
            Return m_AlarmMsgs
        End Get
        Set(ByVal value As AlarmMsgItems)
            m_AlarmMsgs = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Property of ListUser
    ''' </summary>
    ''' <returns>List String username</returns>
    ''' <remarks></remarks>
    Public Shared Function ListUser() As ArrayList
        If m_ListUser Is Nothing Then
            m_ListUser = ContainerDAO.GetListUser()
        End If
        Return m_ListUser
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Property of ListGroup
    ''' </summary>
    ''' <returns>List DBGroup</returns>
    ''' <remarks></remarks>
    Public Shared Function ListGroup() As ArrayList
        If m_ListGroup Is Nothing Then
            m_ListGroup = ContainerDAO.GetListGroup()
        End If
        Return m_ListGroup
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Property of Group
    ''' </summary>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Group(ByVal Id As Integer) As DBGroup
        Return ContainerDAO.GetGroup(Id)
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Property of Permission
    ''' </summary>
    ''' <param name="PermissionCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Permission(ByVal PermissionCode As String) As Boolean
        If UserLogin Is Nothing Then
            Return False
        End If
        '#03/14/2011 
        '#0001404: [Sl_Build 14_Mar 11, 2011]Can execute on process screen without log in? 
        '#Begin fix:
        'All of users have permission Process screen, Wafer Run Datalog, Data log
        If PermissionCode = PERMISSION_010 OrElse PermissionCode = PERMISSION_011 OrElse PermissionCode = PERMISSION_012 Then
            Return True
        End If
        '#End fix

        Dim listPermission As ArrayList = UserLogin.ListPermission
        For Each Permit As DBUserPermission In listPermission
            If (Permit.Code = PermissionCode) Then
                Return Permit.Permit
            End If
        Next

        Return (UserLogin.Username = "Admin")
    End Function
#End Region

#Region "Chamber"
    Public Shared Property HidenColumnInDataRun() As Hashtable
        Get
            If m_hstHidenColumnInDataRun Is Nothing Then
                m_hstHidenColumnInDataRun = New Hashtable
            End If
            Return m_hstHidenColumnInDataRun
        End Get
        Set(ByVal value As Hashtable)
            m_hstHidenColumnInDataRun = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Support get Chamber Object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property ChamberMap() As Hashtable
        Get
            If m_ChamberMap Is Nothing Then
                m_ChamberMap = New Hashtable()
            End If
            Return m_ChamberMap
        End Get
    End Property

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2016-03-11</date>
    ''' </author>
    ''' <summary>
    ''' List Of HRecipe
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Shared Sub AddHRecipeToList(ByVal key As String, ByVal hrep As HRecipeLibrary.HRecipe)
        Try
            If m_ListOfViewRecipe Is Nothing Then
                m_ListOfViewRecipe = New Dictionary(Of String, HRecipeLibrary.HRecipe)
            End If
            If m_ListOfViewRecipe.ContainsKey(key) Then
                Return
            Else
                m_ListOfViewRecipe.Add(key, hrep)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Function GetHRecipeToList(ByVal key As String) As HRecipeLibrary.HRecipe
        Dim Href As HRecipeLibrary.HRecipe = Nothing
        Try
            If m_ListOfViewRecipe.ContainsKey(key) Then
                Href = m_ListOfViewRecipe.Item(key)
            End If
            Return Href
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Href
    End Function

#Region "Config"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-06-03</date>
    ''' </author>
    ''' <summary>
    ''' Get ToolID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ToolID() As String
        Return ContainerDAO.GetToolID()
    End Function
 
   Public Shared Function SoundOnDuringAlarm() As Boolean
        Return ContainerDAO.GetSoundOnDuringAlarm()
    End Function

    Public Shared Function SupportRequestDataChanged() As Boolean
        Return ContainerDAO.SupportRequestDataChanged()
    End Function

    Public Shared Function SupportManualDefineGEMWaferID() As Boolean
        Return ContainerDAO.SupportManualDefineGEMWaferID()
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2017-02-08</date>
    ''' <summary>
    ''' CheckWaferSlideOut config value.
    ''' </summary>
    Public Shared Function CheckWaferSlideOut() As Boolean
        Return ContainerDAO.CheckWaferSlideOut()
    End Function

    Public Shared Function System_Wait_For_CheckSensor() As Integer
        Return ContainerDAO.GetSystemWaitForCheckSensor()
    End Function

    Public Shared Function AllowCheckingECCLimit() As Boolean
        Return ContainerDAO.AllowCheckingECCLimit()
    End Function

    Public Shared Function ECC_M_Limit() As Integer
        Return ContainerDAO.ECC_M_Limit()
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-06-03</date>
    ''' </author>
    ''' <summary>
    ''' Get ToolID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SystemIDLE_Time() As Double
        Return ContainerDAO.GetSystemIDLE_Time
    End Function

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-12-03</date>
    ''' </author>
    ''' <summary>
    ''' Auto Logout Option
    ''' </summary>
    Public Shared Function AutoLogoutOption() As Integer
        Return ContainerDAO.GetAutoLogoutOption
    End Function

    Public Shared Function AutoExportDataLogToCSV() As Boolean
        Return ContainerDAO.AutoExportDataLogToCSV
    End Function

    Public Shared Function SystemCleanUpTime() As Double
        Return ContainerDAO.GetSystemCleanUpTime
    End Function

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2018-11-28</date>
    ''' </author>
    ''' <summary>
    ''' System Clean Up DataRun Time
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SystemCleanUpDataRunTime() As Double
        Return ContainerDAO.GetSystemCleanUpDataRunTime()
    End Function

    ''' <author>
    '''    	<name> Kiet Tran </name>
    '''    	<date> 2018-12-20</date>
    ''' </author>
    ''' <summary>
    ''' Get Reset Robot Interlock Command
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetResetRobotInterlockCommand() As Boolean
        Return ContainerDAO.GetResetRobotInterlockCommand()
    End Function
    ''' <author>
    '''    	<name> Tinh Le</name>
    '''    	<date> 2023-14-02</date>
    ''' </author>
    ''' <summary>
    ''' Get One Main Cryo Controller Installed
    ''' </summary>
    Public Shared Function GetOneMainCryoControllerInstalled() As Boolean
        Return ContainerDAO.GetOneMainCryoControllerInstalled()
    End Function
    Public Shared Function ListChamber(ByVal ChamberGroup As String) As ArrayList
        For Each Recipe As DBRecipe In ListRecipe()
            '''if ANYIBE -> return list recipe of IBE chamber
            If (Utils.IsIBEChamber_ANYIBE(Recipe.ChamberName) AndAlso ChamberGroup = ConstEnum.Equipments.IBE.ToString) Then
                Return Recipe.ListChamber
            ElseIf (Recipe.ChamberName = ChamberGroup) Then
                Return Recipe.ListChamber
            End If
        Next
        Return Nothing
    End Function

    Public Shared Function ListChamberUseAnyChamber(ByVal ChamberGroup As SystemModule.ModuleType) As ArrayList
        Dim arr As ArrayList = ListRecipe(True)
        Dim arrRes As ArrayList = New ArrayList()
        Dim chamberConfig As AVPLib.SystemModule = Nothing
        For Each Recipe As DBRecipe In arr
            If AVPLib.ContainerData.IsChamberVisible(Recipe.ChamberName, chamberConfig) Then ' Get the configuration
                If chamberConfig IsNot Nothing AndAlso chamberConfig.Type = ChamberGroup Then
                    arrRes.AddRange(Recipe.ListChamber)
                End If
            End If
        Next
        Return arrRes
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' List DBRecipe and Support Get Recipe Object
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ListRecipe() As ArrayList
        Return ContainerDAO.GetListRecipe()
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Get Recipe
    ''' </summary>
    ''' <param name="ChamberName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetRecipe(ByVal ChamberName As String) As DBRecipe
        Dim arrRecipe As ArrayList = ListRecipe()
        For Each Recipe As DBRecipe In arrRecipe
            If Recipe.ChamberName = ChamberName Then
                Return Recipe
            End If
        Next
        Return Nothing
    End Function
#End Region

    Public Shared ReadOnly Property All_PVD_Recipe_Templates() As Dictionary(Of String, DBChamber)
        Get
            Return m_hstPVDRecipeTemplates
        End Get
    End Property
#Region "Data"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Get DBChamber
    ''' </summary>
    ''' <param name="ChamberName"></param>
    ''' <param name="ChamberNameActive"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Chamber(ByVal ChamberName As String, ByVal ChamberNameActive As String) As DBChamber
        Return ContainerDAO.GetChamber(ChamberName, ChamberNameActive)
    End Function

    Public Shared Function GetDBChamber(ByVal ChamberType As String, ByVal ParameterListNodeList As System.Xml.XmlNodeList, _
                                        ByVal chamberName As String) As DBChamber
        Dim objChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(chamberName)
        If objChamber Is Nothing Then
            Return Nothing
        End If
        Dim ListOfGroupParameter As ArrayList = _
                                      ChamberLib.GetListGroupParameters(ParameterListNodeList, _
                                                                        objChamber.DCTargetPowerVisible, objChamber)
        Return New DBChamber(ChamberType, ListOfGroupParameter)
    End Function

    Public Shared Function GetAllDBChambers() As Dictionary(Of String, DBChamber)
        Dim stdListOfDBChamber As New Dictionary(Of String, DBChamber)()

        Try
            Dim chamberModule As SystemModule = Nothing
            Dim intMaxOfPM As Integer = 3 'default for CX4

            For idx As Integer = 1 To intMaxOfPM
                chamberModule = Nothing
                Dim ChamberName As String = ConstEnum.Chamber & idx
                If (IsChamberVisible(ChamberName, chamberModule)) Then
                    Dim ChamberParameterDoc As System.Xml.XmlDocument = ContainerDAO.ChamberDocMap.Item(ChamberName & "." & chamberModule.Type.ToString())
                    Dim ListOfGroupParameter As ArrayList = ChamberLib.GetListGroupParameters(ChamberParameterDoc, chamberModule.DCTargetPowerVisible, chamberModule)
                    Dim dbChamber As New DBChamber(chamberModule.Type.ToString(), ListOfGroupParameter)
                    dbChamber.ChamberName = ChamberName
                    dbChamber.ChamberDescription = chamberModule.Name
                    stdListOfDBChamber.Add(chamberModule.Type.ToString() & "." & ChamberName, dbChamber)
                End If
            Next idx

            chamberModule = Nothing
            '#04/14/2011 
            '#Remove.  We don�t have aligner Recipe Editor. -> see picture in the document file
            '#Begin fix: rem following code.

            If (IsChamberVisible(AVPLib.ConstEnum.Equipments.Aligner.ToString(), chamberModule)) Then
                Dim ChamberParameterDoc As System.Xml.XmlDocument = ContainerDAO.ChamberDocMap.Item(chamberModule.Type.ToString())
                Dim ListOfGroupParameter As ArrayList = ChamberLib.GetListGroupParameters(ChamberParameterDoc, chamberModule.DCTargetPowerVisible, chamberModule)
                Dim dbChamber As New DBChamber(chamberModule.Type.ToString(), ListOfGroupParameter)
                dbChamber.ChamberName = AVPLib.ConstEnum.Equipments.Aligner.ToString()
                dbChamber.ChamberDescription = chamberModule.Name
                stdListOfDBChamber.Add(chamberModule.Type.ToString() & "." & AVPLib.ConstEnum.Equipments.Aligner.ToString(), dbChamber)
            End If

            '#End fix.
            m_hstPVDRecipeTemplates = stdListOfDBChamber
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return stdListOfDBChamber
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Get ChamberEmpty
    ''' </summary>
    ''' <param name="ChamberName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ChamberEmpty(ByVal ChamberName As String) As DBChamber
        If ChamberMap.Contains(ChamberName) Then
            Return ChamberMap.Item(ChamberName)
        End If
        Dim chamberRecipe As DBChamber = ContainerDAO.GetChamberEmpty(ChamberName)
        ChamberMap.Add(ChamberName, chamberRecipe)
        Return chamberRecipe
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' Get DataTable Chamber
    ''' </summary>
    ''' <param name="ChamberName"></param>
    ''' <param name="isEmpty"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ChamberDB(ByVal ChamberName As String, ByVal isEmpty As Boolean) As DataTable
        Try
            Dim chamberRecipe As DBChamber = ChamberEmpty(ChamberName)
            If isEmpty = False Then
                Dim ChamberNameActive As String = ContainerData.GetRecipe(ChamberName).ChamberNameActive
                chamberRecipe = Chamber(ChamberName, ChamberNameActive)
            End If
            Return ChamberDB(chamberRecipe, ChamberPVDType(ChamberName))
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-10</date>
    ''' </author>
    ''' <summary>
    ''' GetChamberDescription
    ''' </summary>
    ''' <param name="ChamberName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetChamberDescription(ByVal ChamberName As String) As String
        Try
            Dim ChamberNameActive As String = GetRecipe(ChamberName).ChamberNameActive
            Return Chamber(ChamberName, ChamberNameActive).ChamberDescription
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return ""
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-10</date>
    ''' </author>
    ''' <summary>
    ''' Get DataTable Chamber
    ''' </summary>
    ''' <param name="ChamberName"></param>
    ''' <param name="ChamberNameActive"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ChamberDB(ByVal ChamberName As String, ByVal ChamberNameActive As String, ByVal isEmpty As Boolean) As DataTable
        Try
            Dim m_Chamber As DBChamber = ChamberEmpty(ChamberName)
            If isEmpty = False Then
                m_Chamber = Chamber(ChamberName, ChamberNameActive)
            End If

            Return ChamberDB(m_Chamber, (ContainerData.ChamberPVDType(ChamberName)))
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-10</date>
    ''' </author>
    ''' <summary>
    ''' Get DataTable Chamber
    ''' </summary>
    ''' <param name="chamberRecipe"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ChamberDB(ByVal chamberRecipe As DBChamber, ByVal PMPVDType As PVDType) As DataTable
        Return Utils.ChamberDB(chamberRecipe, PMPVDType)
    End Function
#End Region

#Region "Sequence"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-24</date>
    ''' </author>
    ''' <summary>
    ''' Get List SequenceSlot
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetSequence(ByVal fPath As String, _
        ByRef WfList As DBWaferList, _
        ByRef strDescription As String) As Boolean

        strDescription = String.Empty
        WfList = New DBWaferList

        AVPLib.Log.guiLogger.Info("Enter GetWaferList") ''read tag <ControlJob>
        Dim blRes As Boolean = True
        Try
            Dim SequenceWFDoc As Xml.XmlDocument = AVPLib.ContainerDAO.OpenWFSequenceFile(fPath)
            Dim SequenceNode As System.Xml.XmlNode = SequenceWFDoc.SelectSingleNode(ConstEnum.XPATH_SEQUENCE)

            If SequenceNode Is Nothing Then
                Return False
                Exit Function
            End If

            Dim WaferNodeList As System.Xml.XmlNodeList = SequenceNode.ChildNodes
            strDescription = GetWFDescription(WaferNodeList)
            WfList.WaferList = GetWFList(WaferNodeList)
            blRes = True
        Catch ex As Exception
            blRes = False
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave GetWaferList")
        Return blRes
    End Function

    Public Shared Function CreateSequenceByWaferFlow(ByVal WaferFlowName As String, ByRef CurrentWaferList As DBWaferList, ByVal arrSlotsStatus As Integer()) As Boolean
        Dim blRes As Boolean = True
        Try
            Dim WfFlow As AVPLib.DataManagerment.WaferFlow = AVPLib.ContainerData.GetWaferFlowbyName(WaferFlowName)
            If WfFlow Is Nothing Then
                AVPLib.Log.avpLogger.Error("Can not get WaferFlow with Name: " & WaferFlowName)
                Exit Function
            End If
            CurrentWaferList = New DBWaferList
            For iIndex As Integer = 0 To arrSlotsStatus.Length() - 1
                If arrSlotsStatus(iIndex) = SlotStatuses.Available Then
                    Dim WaferSlot As New DBWaferSlot
                    WaferSlot.Slot = iIndex + 1

                    Dim wfseq As New DBWaferSeq
                    wfseq.SeqName = "AutoWaferFromLL"
                    For i As Integer = 0 To WfFlow.StepList.Count - 1
                        Dim SeqStep As New DBSeqStep
                        SeqStep.RecipeName = CType(WfFlow.StepList.Item(i), AVPLib.DataManagerment.WaferflowStep).RecipeName
                        SeqStep.SeqNumber = CType(WfFlow.StepList.Item(i), AVPLib.DataManagerment.WaferflowStep).Number + 1
                        SeqStep.StationList = CType(WfFlow.StepList.Item(i), AVPLib.DataManagerment.WaferflowStep).StationList
                        SeqStep.DestSlot = ""
                        wfseq.SeqStepList.Add(SeqStep)
                    Next
                    Dim sStepList As String() = Split(GenStep(ParseLoopToStep(WfFlow, wfseq.SeqStepList.Count)), ",")
                    For i As Integer = 0 To sStepList.Length - 1
                        wfseq.StepList.Add(sStepList(i))
                    Next
                    WaferSlot.WaferSequence = wfseq
                    CurrentWaferList.WaferList.Add(WaferSlot)

                End If
            Next
        Catch ex As Exception
            blRes = False
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blRes
    End Function

    ''' <author>
    '''    	<name> DoXuanDat </name>
    '''    	<date> 2009-07-24</date>
    ''' </author>
    ''' <summary>
    ''' GetWFList: read tag <Description> in file sequence
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetWFDescription(ByVal waferlist As Xml.XmlNodeList) As String
        AVPLib.Log.guiLogger.Info("Enter GetWFDescription") ''read tag <WaferList>
        Dim strRes As String = String.Empty
        Try
            If waferlist.Count > 0 Then
                For i As Integer = 0 To waferlist.Count - 1
                    Dim node As XmlNode = waferlist.Item(i)
                    'get the description tag
                    If node.Name = SEQ_DESCRIPTION_TAG Then
                        strRes = node.InnerXml
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave GetWFDescription")
        Return strRes
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-24</date>
    ''' </author>
    ''' <summary>
    ''' GetWFList: read tag <WaferList> in file sequence
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetWFList(ByVal waferlist As Xml.XmlNodeList) As ArrayList
        AVPLib.Log.guiLogger.Info("Enter GetWFList") ''<WaferList>
        Dim arrWaferList As New ArrayList
        Try
            If waferlist.Count = 0 Then
                arrWaferList = Nothing
            Else
                waferlist = waferlist.Item(0).ChildNodes ''<Wafer>
                For i As Integer = 0 To waferlist.Count - 1
                    Dim WaferSlot As New DBWaferSlot
                    WaferSlot.Slot = waferlist.Item(i).ChildNodes.Item(0).InnerText
                    WaferSlot.WaferSequence = GetWaferFlow(waferlist.Item(i).ChildNodes.Item(1)) ''<WaferSeq>
                    arrWaferList.Add(WaferSlot)
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave GetWFList")
        Return arrWaferList
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-24</date>
    ''' </author>
    ''' <summary>
    ''' read tag <WaferSeq>: in file Sequence
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetWaferSeq(ByVal SeqStepList As Xml.XmlNode) As DBWaferSeq
        AVPLib.Log.guiLogger.Info("Enter GetWaferSeq") ''read tag <WaferSeq>
        Dim wfseq As New DBWaferSeq
        Try
            wfseq.SeqName = SeqStepList.ChildNodes.Item(0).InnerText ''read tag <Name>
            wfseq.SeqStepList = GetSeqStepList(SeqStepList.ChildNodes.Item(1)) ''read tag <SeqStepList>
            wfseq.StepList = GetAllStepInWFSeq(SeqStepList.ChildNodes.Item(2)) ''read tag <StepList>
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave GetWaferSeq")
        Return wfseq
    End Function

    Private Shared Function GetAllStepInWFSeq(ByVal wflow As DataManagerment.WaferFlow) As List(Of String)
        AVPLib.Log.guiLogger.Info("Enter GetStepInWFSeq")
        Dim arrWfSeq As New List(Of String)
        Try
            Return ParseLoopToStep(wflow, wflow.StepList.Count)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave GetStepInWFSeq")
        Return arrWfSeq
    End Function

    Private Shared Function GetSeqStepList(ByVal wflow As DataManagerment.WaferFlow) As ArrayList
        AVPLib.Log.guiLogger.Info("Enter GetSeqStepList") '''<SeqStepList>
        Dim arrWfSeq As ArrayList = Nothing ''Each <SeqStep>
        Try
            If (wflow.StepList.Count > 0) Then
                arrWfSeq = New ArrayList()
                Dim intSeqNo As Integer = 1
                For Each item As AVPLib.DataManagerment.WaferflowStep In wflow.StepList
                    Dim SeqStep As New DBSeqStep
                    SeqStep.SeqNumber = intSeqNo
                    SeqStep.RecipeName = item.RecipeName
                    ''<StationList>
                    SeqStep.StationList = item.StationList
                    arrWfSeq.Add(SeqStep)
                    intSeqNo += 1
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave GetSeqStepList")
        Return arrWfSeq
    End Function

    Private Shared Function GetWaferFlow(ByVal waferFlowNameNode As Xml.XmlNode) As DBWaferSeq
        AVPLib.Log.guiLogger.Info("Enter GetWaferFlow")
        Dim wfseq As New DBWaferSeq
        Try
            wfseq.SeqName = waferFlowNameNode.InnerText
            ' Load wafer flow into memory.
            Dim wflow As DataManagerment.WaferFlow = GetWaferFlowbyName(wfseq.SeqName)
            If (wflow IsNot Nothing) Then
                wfseq.SeqStepList = GetSeqStepList(wflow) ''<SeqStepList>
                wfseq.StepList = GetAllStepInWFSeq(wflow) ''<StepList>
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave GetWaferFlow")
        Return wfseq
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-24</date>
    ''' </author>
    ''' <summary>
    ''' Get GetAllStepInWFSeq: Get all Step in node <StepList>
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetAllStepInWFSeq(ByVal StepList As Xml.XmlNode) As List(Of String)
        AVPLib.Log.guiLogger.Info("Enter GetStepInWFSeq")
        Dim arrWfSeq As New List(Of String)
        Try
            Dim arrStep() As String = Split(StepList.InnerText, ",")
            For Each item As String In arrStep
                arrWfSeq.Add(item) '
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave GetStepInWFSeq")
        Return arrWfSeq
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-24</date>
    ''' </author>
    ''' <summary>
    ''' read tag <SeqStepList>: in file Sequence
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetSeqStepList(ByVal SeqStepList As Xml.XmlNode) As ArrayList
        AVPLib.Log.guiLogger.Info("Enter GetSeqStepList") '''<SeqStepList>
        Dim arrWfSeq As New ArrayList ''read each <SeqStep>
        Try
            Dim SeqStepNodeList As XmlNodeList = SeqStepList.ChildNodes
            If SeqStepNodeList.Count > 0 Then
                For i As Integer = 0 To SeqStepNodeList.Count - 1
                    Dim SeqStep As New DBSeqStep
                    SeqStep.SeqNumber = SeqStepNodeList.Item(i).ChildNodes.Item(0).InnerText
                    SeqStep.RecipeName = SeqStepNodeList.Item(i).ChildNodes.Item(1).InnerText
                    Dim arrStation As New ArrayList ''<StationList>
                    Dim stationnode As XmlNode = SeqStepNodeList.Item(i).ChildNodes.Item(2)
                    arrStation.Add(stationnode.ChildNodes.Item(0).InnerText)
                    SeqStep.StationList = arrStation
                    SeqStep.DestSlot = "" '
                    arrWfSeq.Add(SeqStep)
                Next
            Else
                arrWfSeq = Nothing
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave GetSeqStepList")
        Return arrWfSeq
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' List Sequence Name
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ListSequenceName() As ArrayList
        Try
            'If m_ListSequenceName Is Nothing Then
            m_ListSequenceName = ContainerDAO.GetListSequenceName()
            ' End If
            Return m_ListSequenceName
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return Nothing
    End Function

#End Region

#End Region
#End Region

#Region "Properties"

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <summary>
    ''' Get current message config
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub LoadConfigurationData()
        Build_System_Restore_Dictionary()
        MessageConfigStart()
        ValueMessageConfigStart()
        LoadConfigurationFiles()
        IBEMaintenanceMap()
        PVDMaintenanceMap()
        CoronaMaintenanceMap()
        PVD5TMaintenanceMap()

        PumpdownConfigStart()
        PumpdownConfigStartTM()
        VentConfigStart()
        VentConfigStartTM()
        CGConfigStart()
        LoadConfigMailStart()

        If RobotConfigurationValues.DEVICENETAPP_VISIBLE = True Then
            DeviceNetAppMaintenanceMap()
        End If
    End Sub

    Public Shared Sub Build_System_Restore_Dictionary()
        m_dicSystemRestore = ContainerDAO.GetDictionarySystemRestore()
    End Sub

    Public Shared Function GetObj_From_System_Restore_Dictionary(ByVal Key As String) As Object
        If m_dicSystemRestore Is Nothing Then
            Return Nothing
        End If
        If m_dicSystemRestore.ContainsKey(Key) Then
            Return m_dicSystemRestore.Item(Key)
        ElseIf Key.Contains("TransferSetPoint") Then
            Return m_dicSystemRestore.Item("ChamberTransferSetPoint")
        End If
        Return Nothing
    End Function

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-12-03</date>
    ''' </author>
    ''' <summary>
    ''' Get current IBE Maintenance config
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub IBEMaintenanceMap()
        m_IBEMaintenanceCodeMap = New Hashtable
        m_IBEMaintenanceMap = New Hashtable
        ContainerDAO.GetIBEMaintenance(m_IBEMaintenanceMap, m_IBEMaintenanceCodeMap)
    End Sub

    Public Shared Sub PVDMaintenanceMap()
        m_PVDMaintenanceCodeMap = New Hashtable
        m_PVDMaintenanceMap = ContainerDAO.GetPVDMaintenance(True) '''if set to true, we will initialize m_IBEMaintanceCodeMap
    End Sub

    Public Shared Sub DeviceNetAppMaintenanceMap()
        m_DeviceNetAppMaintenanceMap = New Hashtable
        m_DeviceNetAppMaintenanceCodeMap = New Hashtable
        ContainerDAO.GetDeviceNetAppMaintenance(m_DeviceNetAppMaintenanceMap, m_DeviceNetAppMaintenanceCodeMap)
    End Sub

    ''' <author>
    '''    	<name>Dat Cao</name>
    '''    	<date> 2012-12-14</date>
    ''' </author>
    ''' <summary>
    ''' Get current CORONA - Corona Maintenance config
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub CoronaMaintenanceMap()
        ' new code
        m_CoronaMaintenanceCodeMap = New Hashtable
        m_CoronaMaintenanceMap = New Hashtable
        ContainerDAO.GetCoronaMaintenance(m_CoronaMaintenanceMap, m_CoronaMaintenanceCodeMap)
    End Sub
    Public Shared Sub PVD5TMaintenanceMap()
        ' new code
        m_PVD5TMaintenanceCodeMap = New Hashtable
        m_PVD5TMaintenanceMap = New Hashtable
        ContainerDAO.GetPVD5TMaintenance(m_PVD5TMaintenanceMap, m_PVD5TMaintenanceCodeMap)
    End Sub
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <summary>
    ''' Get current message config
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub MessageConfigStart()
        m_MessageConfig = ContainerDAO.GetMessageConfig()
    End Sub

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' ValueMessageConfig
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub ValueMessageConfigStart()
        m_ValueMessageConfig = ContainerDAO.GetValueMessageConfig()
    End Sub

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' ErrorMessageConfigStart
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub ErrorMessageConfigStart()
        m_ErrorMessageConfig = ContainerDAO.GetErrorMessageConfig()
    End Sub

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-20</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get message code ContainerData
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub PollingConfigStart()
        m_PollingConfig = ContainerDAO.GetPollingConfig()
    End Sub

    ''' <author>
    '''    	<name>Ngo Cao Dinh</name>
    '''    	<date> 2008-11-27</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Initialize timeout for all equipments
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub TimeoutStart()
        m_TimeoutConfig = ContainerDAO.GetTimeoutConfig()
    End Sub
    ''' <author>
    '''    	<name>Do Xuan Dat</name>
    '''    	<date> 2009-06-30</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Load configuration files
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub LoadConfigurationFiles()
        ' Load the configuration file
        ContainerDAO.LoadSystemConfigDoc()
        ContainerDAO.LoadDriverConfigDoc()
        ContainerDAO.LoadRoughPumpConfig()

        ContainerDAO.LoadSlowRoughInstalled()
        ContainerDAO.LoadSlowVentInstalled()
        ContainerDAO.Number_Light_Alarm()
        ContainerDAO.Number_Active_Light()

        ContainerDAO.PasswordExitDevicenetApp()

        'load the state machine file
        ContainerDAO.LoadControlJob()
        ContainerDAO.LoadEquipmentTracking()
        ContainerDAO.LoadProcessJob()

        ContainerDAO.LoadRevisionDriverConfigDoc()
        'Build the timeout Map
        TimeoutStart()

        'Build the polling Map
        PollingConfigStart()
        ' build the robot map
        RobotConfigStart_CX()
        'Build the pressure config map
        PressureConfigStart()

        'Build the LLElevator config map
        LLElevatorConfigStart()

        ' Build the transfer pressure setpoint map
        TransferPressureSetpointConfigStart()

        ' Build the initialize command map
        InitConfigStart()

        ' Build the error message command map
        ErrorMessageConfigStart()

        ' Build the user message map
        MessageTextStart()

        ' Build the vent pumpdown configuration map
        ConfigureVentPumpdown()

        'Build the chamber configuration map
        ChamberConfigStart()

    End Sub
    ''' <author>
    '''    	<name>Ngo Cao Dinh</name>
    '''    	<date> 2008-11-27</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Initialize timeout for all equipments
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub InitConfigStart()
        m_InitConfig = ContainerDAO.GetInitConfig()
    End Sub

    Public Shared Sub LoadPMConfig()
        Dim root As System.Xml.XmlNode = Nothing
        ''Load Min/Max foreach PM
        Try
            For i As Integer = 0 To RobotConfigurationValues.CHAMBERX_VISIBLE.Count - 1
                If RobotConfigurationValues.CHAMBERX_VISIBLE(i) = Boolean.TrueString Then
                    Select Case RobotConfigurationValues.CHAMBERX_TYPE(i)
                        '' PVD2R4
                        Case SystemModule.ModuleType.PVD5T
                            root = ContainerDAO.PVD5TSystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_ROBOT & "/" & ConstEnum.Chamber & (i + 1).ToString())
                            ContainerDAO.GetPMRobotConfig(m_RobotConfigMap, root)
                    End Select
                End If
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name>Dat Cao</name>
    '''    	<date> 2011-10-21</date>
    ''' </author>
    ''' <summary>
    ''' GetMessageConfig
    ''' </summary>
    ''' <param name="ConfigurationServerDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Private Shared Sub Install_CX_Style()
    '    Try
    '        '#If AVP_CX_STYLE = "CX5" Then
    '        '            RobotConfigurationValues.INSTALLED_CX4 = False
    '        '            RobotConfigurationValues.INSTALLED_CX5 = True
    '        '#ElseIf AVP_CX_STYLE = "CX4" Then
    '        '            RobotConfigurationValues.INSTALLED_CX4 = True
    '        '            RobotConfigurationValues.INSTALLED_CX5 = False
    '        '#End If
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    'End Sub
    ''' <author>
    '''    	<name>Ngo Cao Dinh</name>
    '''    	<date> 2008-11-27</date>
    ''' </author>
    ''' <summary>
    ''' Initialize timeout for all Robot Config
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub RobotConfigStart_CX()
        Try

            Dim strRunDataFolderConfig As String = ContainerDAO.GetRunDataFolderConfig
            If Not String.IsNullOrEmpty(strRunDataFolderConfig) Then
                ContainerDAO.FPath_RunDataOfWafer = strRunDataFolderConfig
            End If
            AVPLib.Log.schedulerLogger.Debug("Data Run Folder is: " & ContainerDAO.FPath_RunDataOfWafer)
            '
            m_hstHidenColumnInDataRun = New Hashtable()
            m_RobotConfigMap = ContainerDAO.GetRobotConfig()
            Dim chamberModule As SystemModule = Nothing
            ' avoid searching too many times
            IsChamberVisible(AVPLib.ConstEnum.Equipments.LoadLockA.ToString(), chamberModule)

            If chamberModule IsNot Nothing Then
                RobotConfigurationValues.LLA_STATION_NO = chamberModule.StationLocation
            End If

            Dim blnVisible As Boolean = IsChamberVisible(AVPLib.ConstEnum.Equipments.Chamber1.ToString(), chamberModule)
            RobotConfigurationValues.CHAMBER1_VISIBLE = blnVisible
            If blnVisible Then
                RobotConfigurationValues.PM1_STATION_NO = chamberModule.StationLocation
                RobotConfigurationValues.CHAMBER1_TYPE = chamberModule.Type
                RobotConfigurationValues.CHAMBER1_NAME = CType(AVPLib.ContainerData.GetRobotConfig(AVPLib.ConstEnum.Equipments.Chamber1.ToString()), SystemModule).Name
                m_hstHidenColumnInDataRun.Add(ConstEnum.PM1, New List(Of String))
            End If

            blnVisible = IsChamberVisible(AVPLib.ConstEnum.Equipments.Chamber2.ToString(), chamberModule)
            RobotConfigurationValues.CHAMBER2_VISIBLE = blnVisible
            If blnVisible Then
                RobotConfigurationValues.PM2_STATION_NO = chamberModule.StationLocation
                RobotConfigurationValues.CHAMBER2_TYPE = chamberModule.Type
                RobotConfigurationValues.CHAMBER2_NAME = CType(AVPLib.ContainerData.GetRobotConfig(AVPLib.ConstEnum.Equipments.Chamber2.ToString()), SystemModule).Name
                m_hstHidenColumnInDataRun.Add(ConstEnum.PM2, New List(Of String))
            End If

            blnVisible = IsChamberVisible(AVPLib.ConstEnum.Equipments.Chamber3.ToString(), chamberModule)
            RobotConfigurationValues.CHAMBER3_VISIBLE = blnVisible
            If blnVisible Then
                RobotConfigurationValues.PM3_STATION_NO = chamberModule.StationLocation
                RobotConfigurationValues.CHAMBER3_TYPE = chamberModule.Type
                RobotConfigurationValues.CHAMBER3_NAME = CType(AVPLib.ContainerData.GetRobotConfig(AVPLib.ConstEnum.Equipments.Chamber3.ToString()), SystemModule).Name
                m_hstHidenColumnInDataRun.Add(ConstEnum.PM3, New List(Of String))
            End If

            IsChamberVisible(AVPLib.ConstEnum.Equipments.Aligner.ToString(), chamberModule)
            RobotConfigurationValues.ALIGNER_STATION_NO = chamberModule.StationLocation
            RobotConfigurationValues.ALIGNER_DELTA_PICK_STATION_NO = GetRobotConfig(DELTA_PICK_STATION)

            IsChamberVisible(AVPLib.ConstEnum.Equipments.Robot.ToString(), chamberModule)
            RobotConfigurationValues.ROBOT_STATION_NO = chamberModule.StationLocation

            RobotConfigurationValues.CHECKSENSOR_BEFOREPICK = AVPLib.ContainerData.GetRobotConfig("CheckSensorBeforePick")
            RobotConfigurationValues.SYSTEM_WAIT_FOR_CHECK_SENSOR_IN_SECONDS = AVPLib.ContainerData.System_Wait_For_CheckSensor

            RobotConfigurationValues.LOG_LOW_LEVEL_MESSAGES = AVPLib.ContainerData.GetRobotConfig("LogLowLevelMessages")

            LLElevatorConfigurationValues.LLELEVATOR_TIMEOUT = AVPLib.ContainerData.GetTimeout(LLELEVATOR_TIMEOUT)

            RobotConfigurationValues.CHAMBERX_VISIBLE = New List(Of String)
            RobotConfigurationValues.CHAMBERX_VISIBLE.Add(RobotConfigurationValues.CHAMBER1_VISIBLE.ToString()) '0
            RobotConfigurationValues.CHAMBERX_VISIBLE.Add(RobotConfigurationValues.CHAMBER2_VISIBLE.ToString()) '1
            RobotConfigurationValues.CHAMBERX_VISIBLE.Add(RobotConfigurationValues.CHAMBER3_VISIBLE.ToString()) '2

            RobotConfigurationValues.CHAMBERX_TYPE = New List(Of String)
            RobotConfigurationValues.CHAMBERX_TYPE.Add(RobotConfigurationValues.CHAMBER1_TYPE) '0
            RobotConfigurationValues.CHAMBERX_TYPE.Add(RobotConfigurationValues.CHAMBER2_TYPE) '1
            RobotConfigurationValues.CHAMBERX_TYPE.Add(RobotConfigurationValues.CHAMBER3_TYPE) '2

            RobotConfiguration.GetDegasWaitTimeConfig(AVPLib.ContainerDAO.GetDegasWaitTime())
            AVPLib.ContainerData.GetCryoRegenHour()
            RobotConfigurationValues.AUTO_EXPORT_DATALOG_TOCSV = AutoExportDataLogToCSV()
            RobotConfigurationValues.SUPPORT_REQUEST_ALL_DATA_CHANGED = ContainerData.SupportRequestDataChanged
            RobotConfigurationValues.SUPPORT_MANUAL_DEFINE_GEM_WAFERID = ContainerData.SupportManualDefineGEMWaferID
            RobotConfigurationValues.ALLOW_CHECKING_ECC_LIMIT = ContainerData.AllowCheckingECCLimit()
            RobotConfigurationValues.ECC_M_LIMIT = ContainerData.ECC_M_Limit()
            RobotConfigurationValues.CHECK_WAFER_SLIDE_OUT = ContainerData.CheckWaferSlideOut()

            Dim runNo As Integer = AVPLib.ContainerDAO.GetRunNo()
            If ConstEnum.NUM_1000 <= runNo AndAlso runNo <= ConstEnum.NUM_9999 Then
                RobotConfigurationValues.RUN_SCHEDULER_NO = runNo
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    Public Shared Sub RobotConfigStart_SL()
        Try
            Dim strRunDataFolderConfig As String = ContainerDAO.GetRunDataFolderConfig
            If Not String.IsNullOrEmpty(strRunDataFolderConfig) Then
                ContainerDAO.FPath_RunDataOfWafer = strRunDataFolderConfig
            End If
            AVPLib.Log.schedulerLogger.Debug("Data Run Folder is: " & ContainerDAO.FPath_RunDataOfWafer)
            '
            m_RobotConfigMap = ContainerDAO.GetRobotConfig()

            Dim chamberModule As SystemModule = Nothing
            Dim blnVisible As Boolean = IsChamberVisible(AVPLib.ConstEnum.Equipments.Chamber1.ToString(), chamberModule)
            RobotConfigurationValues.CHAMBER1_VISIBLE = blnVisible
            If blnVisible Then
                RobotConfigurationValues.CHAMBER1_TYPE = chamberModule.Type
                RobotConfigurationValues.CHAMBER1_NAME = CType(AVPLib.ContainerData.GetRobotConfig(AVPLib.ConstEnum.Equipments.Chamber1.ToString()), SystemModule).Name
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    ''' <author>
    '''    	<name>Do Xuan Dat</name>
    '''    	<date> 2009-09-04</date>
    ''' </author>
    ''' <summary>
    ''' Initial variables
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub ChamberConfigStart()
        Try
            Dim ChambersConfigMap As Hashtable 'Key , Value.
            ChambersConfigMap = ContainerDAO.GetChambersConfig()
            ConfigurationValues.DEVICE_STATUS_CLOSED = GetChambersConfig(ChambersConfigMap, STR_IBE_DEVICE_STATUS_CLOSED)
            ConfigurationValues.DEVICE_STATUS_OPEN = GetChambersConfig(ChambersConfigMap, STR_IBE_DEVICE_STATUS_OPEN)
            RobotConfigurationValues.DELAY_ROBOT_ANIMATION = CInt(ContainerDAO.GetRobot_Animation_Config())
            RobotConfigurationValues.DELAY_TIME_KEEPALIVE = CInt(ContainerDAO.GetDelay_Time_KeepAlive())
            RobotConfigurationValues.CONNECTION_TIMEOUT = CInt(ContainerDAO.GetConnectionTimeOut())
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-12-08</date>
    ''' </author>
    ''' <summary>
    ''' PressureConfigStart
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub PressureConfigStart()
        m_RobotPressureConfigMap = ContainerDAO.GetPressureConfig()
    End Sub

    Public Shared Sub LLElevatorConfigStart()
        m_LLAElevatorConfigMap = ContainerDAO.GetLLElevatorConfig(ConstEnum.Equipments.LLAElevator.ToString())
        Dim LLANumberOfSlot As Integer = 12 'default

        If m_LLAElevatorConfigMap.ContainsKey(NUMBER_OF_SLOT) Then
            LLANumberOfSlot = CType(m_LLAElevatorConfigMap.Item(NUMBER_OF_SLOT), Integer)
        End If
        RobotConfigurationValues.SLOT_NUM_LLA = LLANumberOfSlot
        RobotConfigurationValues.LOADLOCKA_SLOTS = LLANumberOfSlot
    End Sub

    Public Shared Function GetLLElevatorConfig(ByVal configItem As String) As String
        AVPLib.Log.coreLogger.Info("Enter GetLLElevatorConfig")
        Try
            Dim strResult As String = String.Empty
            SyncLock m_LLAElevatorConfigMap.SyncRoot
                If m_LLAElevatorConfigMap.ContainsKey(configItem) Then
                    If (m_LLAElevatorConfigMap.Item(configItem) IsNot Nothing) Then
                        strResult = m_LLAElevatorConfigMap.Item(configItem).ToString()
                    End If
                End If
            End SyncLock
            AVPLib.Log.coreLogger.Info("Leave GetLLElevatorConfig")
            Return strResult
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetLLElevatorConfig")
        Return -1
    End Function


    Public Shared Sub TransferPressureSetpointConfigStart()
        m_TransferPressureSetpointMap = ContainerDAO.GetTransferPressureSetpointConfig()
    End Sub

    Public Shared Sub PumpdownConfigStart()
        m_PumdownConfigMapLL = ContainerDAO.GetPumpdownConfigLL()
    End Sub

    Public Shared Sub PumpdownConfigStartTM()
        m_PumdownConfigMapTM = ContainerDAO.GetPumpdownConfigTM()
    End Sub

    Public Shared Sub VentConfigStart()
        m_VentConfigMapLL = ContainerDAO.GetVentConfigLL()
    End Sub

    Public Shared Sub VentConfigStartTM()
        m_VentConfigMapTM = ContainerDAO.GetVentConfigTM()
    End Sub
    Public Shared Sub CGConfigStart()
        m_CGConfigMap = ContainerDAO.GetCGConfig()
    End Sub

    Private Shared Sub ConfigureVentPumpdown()
        VentPumdownLib.GetConfig(ContainerDAO.SystemConfigDoc)
    End Sub

    Public Shared Sub LoadConfigMailStart()
        ContainerDAO.LoadConfigMail()
    End Sub

    Public Shared Sub SaveConfigMail()
        ContainerDAO.SaveConfigMail()
    End Sub

    Private Shared Sub MessageTextStart()
        Try
            If (m_MessageTextMap Is Nothing) Then
                ' The XPath to the polling session
                Dim root As System.Xml.XmlNode = ContainerDAO.SystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_USERMESSAGETEXTS)

                m_MessageTextMap = GetMessageText(root)

                Dim blnAddedPVD5TMessageText As Boolean = False
                For i As Byte = 0 To RobotConfigurationValues.CHAMBERX_TYPE.Count - 1
                    If RobotConfigurationValues.CHAMBERX_TYPE(i) = SystemModule.ModuleType.PVD5T AndAlso Not blnAddedPVD5TMessageText Then
                        root = ContainerDAO.PVD5TSystemConfigDoc.SelectSingleNode(ConstEnum.XPATH_USERMESSAGETEXTS)
                        AddMessageText(root)
                        blnAddedPVD5TMessageText = True
                    End If
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub AddMessageText(ByVal root As System.Xml.XmlNode)
        Try
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For i As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(i)
                If Not (node.NodeType = XmlNodeType.Comment) Then
                    Dim nodeConfigList As System.Xml.XmlNodeList = node.ChildNodes
                    Try
                        Dim key As String = nodeConfigList.Item(0).InnerText
                        Dim value As String = nodeConfigList.Item(1).InnerText
                        m_MessageTextMap.Add(key, value)
                    Catch ex As Exception
                        AVPLib.Log.avpLogger.Error(ex.ToString())
                    End Try
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Function WaferFlow"

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' AddWaferFlow: Add waferflow to file 
    ''' </summary>
    ''' <param name="WfFlow">A WaferFlow</param>
    ''' <remarks></remarks>   
    Public Shared Function SaveWaferFlow(ByVal WfFlow As AVPLib.DataManagerment.WaferFlow, ByVal blnCheckExistName As Boolean) As Boolean
        AVPLib.Log.coreLogger.Info("Enter DeleteWaferFlow")
        Dim blnSuccess As Boolean = False
        Dim WaferFlowDoc As System.Xml.XmlDocument = New Xml.XmlDocument() 'AVPLib.ContainerDAO.WaferFlowDoc
        Dim i As Integer = 0
        Try
            'Dim roots As System.Xml.XmlNode = WaferFlowDoc.CreateElement("WaferFlows")

            '''append new waferflow
            Dim waferNode As XmlNode = WaferFlowDoc.CreateElement("WaferFlow")
            'Dim deleteNode As XmlNode = SelectedWaferNodes(WaferFlowDoc, WfFlow.WaferFlowName)
            'If (deleteNode IsNot Nothing) Then
            ' root.RemoveChild(deleteNode)
            ' End If
            WaferFlowDoc.AppendChild(waferNode)

            Dim WfNameNode As XmlNode = WaferFlowDoc.CreateElement("Name")
            WfNameNode.InnerText = WfFlow.WaferFlowName.ToString()
            waferNode.AppendChild(WfNameNode)
            '''''''''''''''''''''''''''''''''''''''''''''
            Dim wfDesNode As XmlNode = WaferFlowDoc.CreateElement("Description")
            wfDesNode.InnerText = WfFlow.Description.ToString()
            waferNode.AppendChild(wfDesNode)
            '' initialize tag <StepList></StepList> before insert Step 
            Dim wfStepListNode As XmlNode = WaferFlowDoc.CreateElement("StepList")
            wfStepListNode.InnerText = ""
            waferNode.AppendChild(wfStepListNode)
            '' initialize tag <LoopList> </LoopList> before insert Loop 
            Dim wfLoopListNode As XmlNode = WaferFlowDoc.CreateElement("LoopList")
            wfLoopListNode.InnerText = ""
            waferNode.AppendChild(wfLoopListNode)

            'root.AppendChild(waferNode)
            '
            WaferFlowDoc.Save(ContainerDAO.FPath_WaferFlow & WfFlow.WaferFlowName & ".xml")
            'BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_WaferFlow & WfFlow.WaferFlowName & ".xml", WaferFlowDoc)

            'add step step info
            ' check if has some step info
            If WfFlow.StepList.Count > 0 Then
                SaveStep(WfFlow, WaferFlowDoc)
            End If

            'add loop
            ' check if has some loop info
            If WfFlow.LoopList.Count > 0 Then
                SaveLoop(WfFlow, WaferFlowDoc)
            End If
            ''save to GEM DATA Folder
            If (Utils.Create_GEMDATA_Folder) Then
                WaferFlowDoc.Save(ContainerDAO.FPath_GEMData_WaferFlow & WfFlow.WaferFlowName & ".xml")
            End If
            blnSuccess = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave DeleteWaferFlow")
        Return blnSuccess
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' DeleteLoopNode: Delete Loop Node in WaferFlow Node 
    ''' </summary>
    ''' <param name="LoopNo">Index of Loop</param>
    ''' <param name="wfFlowName">WaferFlow Name</param>
    ''' <remarks></remarks>   
    Public Shared Function DeleteLoopNode(ByVal LoopNo As String, ByVal wfFlowName As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter DeleteStepNode")
        Dim blnSuccess As Boolean = False
        Dim WaferFlowDoc As System.Xml.XmlDocument = BinarySerialize.Open_DatFileConfig(ContainerDAO.FPath_WaferFlow & wfFlowName & ".xml")
        Try
            Dim root As System.Xml.XmlNode = WaferFlowDoc.SelectSingleNode(ConstEnum.XPATH_WAFERFLOW)
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            Dim wafernode As XmlNode = SelectedLoopNodes(WaferFlowDoc)
            ''read all step
            Dim loopListNode As XmlNode = wafernode.ChildNodes.Item(3) ''<LoopList> tag
            For i As Integer = 0 To loopListNode.ChildNodes.Count - 1
                ''read each step
                Dim node As System.Xml.XmlNode = loopListNode.ChildNodes.Item(i) ''<Loop>
                If node.FirstChild.InnerText = LoopNo Then
                    loopListNode.RemoveChild(node)
                    blnSuccess = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Finally
            If blnSuccess Then
                ContainerDAO.SaveSystemWaferFlow(WaferFlowDoc)
            End If
        End Try
        AVPLib.Log.coreLogger.Info("Leave DeleteStepNode")
        Return blnSuccess
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' DeleteStepNode: Delete Step Node in WaferFlow Node 
    ''' </summary>
    ''' <param name="stepNo">Index of Step</param>
    ''' <param name="wfFlowName">WaferFlow Name</param>
    ''' <remarks></remarks>  
    Public Shared Function DeleteStepNode(ByVal stepNo As String, ByVal wfFlowName As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter DeleteStepNode")
        Dim blnSuccess As Boolean = False
        Dim WaferFlowDoc As System.Xml.XmlDocument = BinarySerialize.Open_DatFileConfig(ContainerDAO.FPath_WaferFlow & wfFlowName & ".xml")
        Try
            Dim root As System.Xml.XmlNode = WaferFlowDoc.SelectSingleNode(ConstEnum.XPATH_WAFERFLOW)
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            Dim wafernode As XmlNode = SelectedStepNodes(WaferFlowDoc)
            ''read all step
            Dim stepListNode As XmlNode = wafernode.ChildNodes.Item(2) ''<StepList> tag
            For i As Integer = 0 To stepListNode.ChildNodes.Count - 1
                ''read each step
                Dim node As System.Xml.XmlNode = stepListNode.ChildNodes.Item(i) ''<step>
                If node.FirstChild IsNot Nothing Then
                    If node.FirstChild.InnerText = stepNo Then
                        stepListNode.RemoveChild(node)
                        blnSuccess = True
                        Exit For
                    End If
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Finally
            If blnSuccess Then
                ContainerDAO.SaveSystemWaferFlow(WaferFlowDoc)
            End If

        End Try
        AVPLib.Log.coreLogger.Info("Leave DeleteStepNode")
        Return blnSuccess
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' DeleteWaferFlow: Delete waferflow from file 
    ''' </summary>
    ''' <param name="WaferFlowDoc">SystemWaferFlow.xml</param>
    ''' <remarks></remarks>   
    Public Shared Function DeleteWaferFlow(ByVal WaferName As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter DeleteWaferFlow")
        Dim blnSuccess As Boolean = True
        Try
            If System.IO.File.Exists(ContainerDAO.FPath_WaferFlow & WaferName & ".xml") Then
                Utils.DeleteFile(ContainerDAO.FPath_WaferFlow & WaferName & ".xml")
            End If
            If System.IO.File.Exists(ContainerDAO.FPath_GEMData_WaferFlow & WaferName & ".xml") Then
                Utils.DeleteFile(ContainerDAO.FPath_GEMData_WaferFlow & WaferName & ".xml")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave DeleteWaferFlow")
        Return blnSuccess
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' GetWaferFlow: get all waferflow name from file and store in arraylist
    ''' </summary>
    ''' <param name="WaferFlowDoc">SystemWaferFlow.xml</param>
    ''' <remarks></remarks>   
    Public Shared Function GetAllWaferFlowName() As ArrayList
        AVPLib.Log.coreLogger.Info("Enter GetAllWaferFlowName")
        Dim arrWfFlow As New ArrayList
        Try
            Dim strPath As String = ContainerDAO.FPath_WaferFlow
            If IO.Directory.Exists(strPath) Then
                Dim Files As String() = System.IO.Directory.GetFiles(strPath, "*.xml")
                For Each File As String In Files
                    If Utils.CanToAddFile(File) Then
                        arrWfFlow.Add(Utils.GetFileName(File, True))
                    End If
                Next
                AVPLib.Log.coreLogger.Info("Leave GetAllWaferFlowName")
                Return arrWfFlow
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetAllWaferFlowName")
        Return arrWfFlow
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-04-25</date>
    ''' </author>
    ''' <summary>
    ''' GetWaferFlow: get waferflow name from file and return waferflow with that name
    '''THIS FUNCTION ONLY USED FOR RUNNING DATA
    ''' </summary>
    Public Shared Function GetWaferFlowbyName(ByVal FlowName As String, Optional ByVal loadLockName As String = "") As AVPLib.DataManagerment.WaferFlow
        AVPLib.Log.coreLogger.Info("Enter GetWaferFlowbyName")
        Dim wfName As AVPLib.DataManagerment.WaferFlow = Nothing
        Try
            If String.IsNullOrEmpty(FlowName) Then
                Return Nothing
            End If

            Dim waferPath As String = ContainerDAO.FPath_WaferFlow & FlowName & ".xml"
            Dim WaferFlowDoc As System.Xml.XmlDocument = BinarySerialize.Open_DatFileConfig(waferPath) ' AVPLib.ContainerDAO.WaferFlowDoc
            If WaferFlowDoc Is Nothing Then
                Return Nothing
            End If
            Dim root As System.Xml.XmlNode = WaferFlowDoc.SelectSingleNode(ConstEnum.XPATH_WAFERFLOW)
            If root Is Nothing Then 'Or root.ChildNodes.Count = 0 Then '''there is something error
                Return Nothing
            End If
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            Dim arrStep As New ArrayList
            Dim arrLoop As New ArrayList
            wfName = New DataManagerment.WaferFlow

            wfName.WaferFlowName = FlowName
            'wfName.Description = nodeList.Item(1).InnerText

            arrStep = GetStepList(nodeList.Item(2)) ''<steplist>
            arrLoop = GetLoopList(nodeList.Item(3)) ''<looplist>

            wfName.StepList = arrStep
            wfName.LoopList = arrLoop
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetWaferFlowbyName")
        Return wfName
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' AddLoop: Add Loop to WaferFlow
    ''' </summary>
    ''' <remarks></remarks>   
    Private Shared Function SaveLoop(ByVal WfFlow As AVPLib.DataManagerment.WaferFlow, ByVal WfDoc As XmlDocument) As Boolean
        AVPLib.Log.coreLogger.Info("Enter AddLoop")
        'add more Loop and update each Loop
        Dim blnSuccess As Boolean = False
        Try
            ''select node include wafername 
            Dim WaferNode As XmlNode = SelectedLoopNodes(WfDoc)

            For Each loopItem As DataManagerment.WaferflowLoop In WfFlow.LoopList
                Dim LoopNode As XmlNode = WfDoc.CreateElement("Loop")
                ''create attribute <No>
                Dim LoopNo As System.Xml.XmlNode = WfDoc.CreateElement("No")
                LoopNo.InnerText = loopItem.LoopNo.ToString()

                LoopNode.AppendChild(LoopNo)
                ''create attribute <Start>
                Dim LoopStart As System.Xml.XmlNode = WfDoc.CreateElement("Start")
                LoopStart.InnerText = loopItem.LoopStart.ToString()

                LoopNode.AppendChild(LoopStart)
                ''create attribute <End>
                Dim LoopEnd As System.Xml.XmlNode = WfDoc.CreateElement("End")
                LoopEnd.InnerText = loopItem.LoopEnd.ToString()
                LoopNode.AppendChild(LoopEnd)
                ''create attribute <Count>
                Dim LoopCount As System.Xml.XmlNode = WfDoc.CreateElement("Count")
                LoopCount.InnerText = loopItem.LoopCount.ToString()
                LoopNode.AppendChild(LoopCount)
                WaferNode.AppendChild(LoopNode)
            Next

            blnSuccess = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Finally
            If blnSuccess Then
                'WfDoc.Save(ContainerDAO.FPath_WaferFlow)
                BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_WaferFlow & WfFlow.WaferFlowName & ".xml", WfDoc)
            End If
        End Try
        AVPLib.Log.coreLogger.Info("Leave AddLoop")
        Return blnSuccess
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' AddStep: Add Step to WaferFlow
    ''' </summary>
    ''' <remarks></remarks>   
    Private Shared Function SaveStep(ByVal WfFlow As AVPLib.DataManagerment.WaferFlow, ByVal WfDoc As XmlDocument) As Boolean
        AVPLib.Log.coreLogger.Info("Enter AddStep")
        Dim blnSuccess As Boolean = False
        ''select node include wafername 
        Dim StepListNode As System.Xml.XmlNode = SelectedStepNodes(WfDoc)
        'StepListNode.RemoveAll()

        Try
            For Each Stepitem As DataManagerment.WaferflowStep In WfFlow.StepList

                Dim StepNode As System.Xml.XmlNode = WfDoc.CreateElement("Step")
                Dim StepNo As System.Xml.XmlNode = WfDoc.CreateElement("Number")
                StepNo.InnerText = Stepitem.Number.ToString()
                StepNode.AppendChild(StepNo)
                ''StationList
                Dim StepStationList As System.Xml.XmlNode = WfDoc.CreateElement("StationList")
                '<StationId>
                Dim StepStation As System.Xml.XmlNode = WfDoc.CreateElement("StationId")
                StepStation.InnerText = Stepitem.StationList.Item(0).ToString()
                StepStationList.AppendChild(StepStation)
                ''</StationId>
                StepNode.AppendChild(StepStationList)

                Dim StepRecipe As System.Xml.XmlNode = WfDoc.CreateElement("RecipeName")
                StepRecipe.InnerText = Stepitem.RecipeName.ToString()
                StepNode.AppendChild(StepRecipe)

                StepListNode.AppendChild(StepNode)
            Next

            blnSuccess = True

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Finally
            If blnSuccess Then
                'WfDoc.Save(ContainerDAO.FPath_WaferFlow)
                BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_WaferFlow & WfFlow.WaferFlowName & ".xml", WfDoc)
            End If
        End Try
        AVPLib.Log.coreLogger.Info("Leave AddStep")
        Return blnSuccess
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' SelectedWaferNodes: read xdoc and return WaferFlow Node contains nodename
    ''' </summary>
    ''' <param name="xdoc">document SystemWaferFlow.xml</param>
    ''' <param name="nodename">Wafer Node Name</param>
    ''' <remarks></remarks>   
    Public Shared Function SelectedLoopNodes(ByVal xdoc As XmlDocument) As XmlNode
        AVPLib.Log.coreLogger.Info("Enter SelectedWaferNodes")
        Dim node As XmlNode = Nothing
        Try
            node = xdoc.SelectSingleNode("WaferFlow/LoopList")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SelectedWaferNodes")
        Return node
    End Function

    Public Shared Function SelectedStepNodes(ByVal xdoc As XmlDocument) As XmlNode
        AVPLib.Log.coreLogger.Info("Enter SelectedWaferNodes")
        Dim node As XmlNode = Nothing
        Try
            node = xdoc.SelectSingleNode("WaferFlow/StepList")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SelectedWaferNodes")
        Return node
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' GetLoopList: return a list of step from tag <StepList> in WaferDoc
    ''' </summary>
    ''' <param name="StepListNode">a Steplist node <StepList></StepList> in SystemWaferFlow.xml</param>
    ''' <remarks></remarks>   
    Public Shared Function GetLoopList(ByVal LoopListNode As System.Xml.XmlNode) As ArrayList
        AVPLib.Log.coreLogger.Info("Enter GetLoopList")
        Dim arrLooplist As New ArrayList
        Dim loopnode As System.Xml.XmlNode = LoopListNode ''tag <LoopList>
        Dim loopnodelist As Xml.XmlNodeList = loopnode.ChildNodes ''read each tag <Loop>
        Dim loopitem As DataManagerment.WaferflowLoop = Nothing
        ''read all loop
        For j As Integer = 0 To loopnodelist.Count - 1
            Try
                ''get each loop item
                Dim lnode As System.Xml.XmlNode = loopnodelist.Item(j)
                Dim lnodelist As Xml.XmlNodeList = lnode.ChildNodes
                loopitem = New DataManagerment.WaferflowLoop
                loopitem.LoopNo = CStr(lnodelist.Item(0).InnerText)
                loopitem.LoopStart = CStr(lnodelist.Item(1).InnerText)
                loopitem.LoopEnd = CStr(lnodelist.Item(2).InnerText)
                loopitem.LoopCount = CInt(lnodelist.Item(3).InnerText)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error("Error add LoopList: " & ex.ToString())
            Finally
                arrLooplist.Add(loopitem)
            End Try
        Next j
        AVPLib.Log.coreLogger.Info("Leave GetLoopList")
        Return arrLooplist
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-09</date>
    ''' </author>
    ''' <summary>
    ''' GetStepList: return a list of step from tag <StepList> in WaferDoc
    ''' </summary>
    ''' <param name="StepListNode">a Steplist node <StepList></StepList> in SystemWaferFlow.xml</param>
    ''' <remarks></remarks>   
    Public Shared Function GetStepList(ByVal StepListNode As System.Xml.XmlNode) As ArrayList
        AVPLib.Log.coreLogger.Info("Enter GetStepList")
        Dim arrSteplist As New ArrayList
        Dim stepnode As System.Xml.XmlNode = StepListNode ''tag <StepList>
        Dim stepnodelist As Xml.XmlNodeList = stepnode.ChildNodes ''get child node
        Dim stepitem As DataManagerment.WaferflowStep = Nothing
        ''read all step 
        For j As Integer = 0 To stepnodelist.Count - 1
            Try
                Dim snode As System.Xml.XmlNode = stepnodelist.Item(j)
                Dim snodelist As System.Xml.XmlNodeList = snode.ChildNodes
                '''get each step
                stepitem = New DataManagerment.WaferflowStep
                stepitem.Number = CInt(snodelist.Item(0).InnerText)

                Dim slnode As System.Xml.XmlNode = snodelist.Item(1)
                Dim slnodelist As System.Xml.XmlNodeList = slnode.ChildNodes
                Dim arrStationList As New ArrayList
                ''get StationList
                For k As Integer = 0 To slnodelist.Count - 1
                    arrStationList.Add(slnodelist.Item(k).InnerText)
                Next
                stepitem.StationList = arrStationList
                stepitem.RecipeName = (snodelist.Item(2).InnerText)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error("Error add StepList: " & ex.ToString())
            Finally
                arrSteplist.Add(stepitem)
            End Try
        Next j
        AVPLib.Log.coreLogger.Info("Leave GetStepList")
        Return arrSteplist
    End Function

#End Region

#Region "Function Message"

    Public Shared Function GetMessageText(ByVal root As System.Xml.XmlNode) As Hashtable
        Dim map As New Hashtable()
        Try
            'Dim root As System.Xml.XmlNode = MessageTextDoc.FirstChild
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For i As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(i)
                If Not (node.NodeType = XmlNodeType.Comment) Then
                    Dim nodeConfigList As System.Xml.XmlNodeList = node.ChildNodes
                    Try
                        Dim key As String = nodeConfigList.Item(0).InnerText
                        Dim value As String = nodeConfigList.Item(1).InnerText
                        map.Add(key, value)
                    Catch ex As Exception
                        AVPLib.Log.avpLogger.Error(ex.ToString())
                    End Try
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return map
    End Function

    ''' <author>
    '''    	<name>Tran Ngoc Khiet</name>
    '''    	<date> 2008-12-03</date>
    ''' </author>
    ''' <summary>
    ''' Get GetMessageText form xml file
    ''' </summary>
    ''' <param name="commandData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMessageText(ByVal Key As String) As String
        Try
            If (m_MessageTextMap IsNot Nothing) Then
                Return CType(m_MessageTextMap.Item(Key), String)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return ""
    End Function

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-12-03</date>
    ''' </author>
    ''' <summary>
    ''' Get IBE Maintenance
    ''' </summary>
    ''' <param name="commandData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMaintenanceCmd(ByVal codeMap As Hashtable, _
                                             ByVal commandData As String, _
                                             ByVal IsAVPCommandFormat As Boolean) As DBCommand
        Try
            Dim objResult As Object = Nothing
            If IsAVPCommandFormat Then
                objResult = codeMap.Item(commandData.Substring(0, commandData.IndexOf(SEPARATOR_CMD_DATA)))
            Else
                objResult = codeMap.Item(commandData.Substring(0, commandData.LastIndexOf(",")))
            End If

            If objResult Is Nothing Then
                objResult = codeMap.Item(commandData)
            End If
            Return objResult
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString() & " commandData=" & commandData)
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''    	<name>Nguyen Tien Dat</name>
    '''    	<date> 2009-02-20</date>
    ''' </author>
    ''' <summary>
    ''' Get CommandCode when CommandName provided.
    ''' </summary>
    ''' <param name="CommandName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetIBECmdCode(ByVal commandName As String) As String
        Try
            Dim IBECommandItem As DBCommand = m_IBEMaintenanceMap.Item(commandName)
            If IBECommandItem IsNot Nothing Then
                Return IBECommandItem.CommandCode
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function

    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-20</date>
    ''' </author>
    ''' <summary>
    ''' Get CommandCode when CommandName provided.
    ''' </summary>
    ''' <param name="CommandName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>   
    Public Shared Function GetPVDCmdCode(ByVal commandName As String) As String
        Try
            Dim PVDCommandItem As DBCommand = m_PVDMaintenanceMap.Item(commandName)
            If PVDCommandItem IsNot Nothing Then
                Return PVDCommandItem.CommandCode
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function

    Public Shared Function GetDeviceNetAppCmdCode(ByVal commandName As String) As String
        Try
            Dim DeviceNetAppCommandItem As DBCommand = m_DeviceNetAppMaintenanceMap.Item(commandName)
            If DeviceNetAppCommandItem IsNot Nothing Then
                Return DeviceNetAppCommandItem.CommandCode
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function

    ''' <author>
    '''    	<name>Dat Cao</name>
    '''    	<date> 2012-12-14</date>
    ''' </author>
    ''' <summary>
    ''' Get CommandCode when CommandName provided.
    ''' </summary>
    ''' <param name="CommandName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>   
    Public Shared Function GetCoronaCmdCode(ByVal commandName As String) As String
        Try
            Dim CoronaCommandItem As DBCommand = m_CoronaMaintenanceMap.Item(commandName)
            If CoronaCommandItem IsNot Nothing Then
                Return CoronaCommandItem.CommandCode
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function
    Public Shared Function GetPVD5TCmdCode(ByVal commandName As String) As String
        Try
            Dim PMCommandItem As DBCommand = m_PVD5TMaintenanceMap.Item(commandName)
            If PMCommandItem IsNot Nothing Then
                Return PMCommandItem.CommandCode
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function
    ''' <author>
    '''    	<name>Nguyen Tien Dat</name>
    '''    	<date> 2009-02-20</date>
    ''' </author>
    ''' <summary>
    ''' Get CommandCode when CommandName provided.
    ''' </summary>
    ''' <param name="CommandName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetIBEDecoder(ByVal commandName As String) As String
        Try
            Dim IBECommandItem As DBCommand = m_IBEMaintenanceMap.Item(commandName)
            If IBECommandItem IsNot Nothing Then
                Return IBECommandItem.DecoderName
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function

    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-12-20</date>
    ''' </author>
    ''' <summary>
    ''' Get CommandCode when CommandName provided.
    ''' </summary>
    ''' <param name="CommandName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPVDDecoder(ByVal commandName As String) As String
        Try
            Dim PVDCommandItem As DBCommand = m_PVDMaintenanceMap.Item(commandName)
            If PVDCommandItem IsNot Nothing Then
                Return PVDCommandItem.DecoderName
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function
    ''' <author>
    '''    	<name>Dat Cao</name>
    '''    	<date> 2012-12-14</date>
    ''' </author>
    ''' <summary>
    ''' Get CommandCode when CommandName provided.
    ''' </summary>
    ''' <param name="CommandName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCoronaDecoder(ByVal commandName As String) As String
        Try
            Dim CoronaCommandItem As DBCommand = m_CoronaMaintenanceMap.Item(commandName)
            If CoronaCommandItem IsNot Nothing Then
                Return CoronaCommandItem.DecoderName
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function
    ''' <author>
    '''    	<name>Ngo Cao Dinh</name>
    '''    	<date> 2008-12-06</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get elevator initialization configuration
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property GetInitConfig(ByVal Name As String) As ArrayList
        Get
            Return m_InitConfig.Item(Name)
        End Get
    End Property

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get message code ContainerData
    ''' </summary>
    ''' <param name="MessageName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMessageCode(ByVal MessageName As String) As String
        Try
            Return m_MessageConfig.Item(MessageName)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return Nothing
    End Function

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
    Public Shared Function GetMessageValue(ByVal MessageName As String) As String
        Try
            Dim sMessageName As String = m_ValueMessageConfig.Item(MessageName)
            If sMessageName Is Nothing Then
                sMessageName = MessageName
            End If
            Return sMessageName
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return Nothing
    End Function

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' GetMessageError
    ''' </summary>
    ''' <param name="MessageName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMessageError(ByVal MessageName As String) As String
        Try
            Dim sMessageName As String = Nothing
            If MessageName.IndexOf("Robot._ERR") > -1 Then
                Dim posMessageName As Integer = MessageName.IndexOf("Robot._ERR")
                Dim NumMessageName As Integer = Integer.Parse(MessageName.Substring(posMessageName + "Robot._ERR".Length + 1))
                MessageName = "Robot._ERR " + NumMessageName.ToString()
                sMessageName = m_ErrorMessageConfig.Item(MessageName)
            Else
                sMessageName = m_ErrorMessageConfig.Item(MessageName)
            End If

            If sMessageName Is Nothing Then
                sMessageName = m_ErrorMessageConfig.Item("ErrReply") + MessageName
            End If
            Return sMessageName
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return Nothing
    End Function

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' CheckMessageError
    ''' </summary>
    ''' <param name="MessageName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckMessageError(ByVal MessageName As String) As ArrayList
        AVPLib.Log.dataManagementLogger.Info("Enter CheckMessageError")
        Try
            Dim sMessageName As ArrayList = New ArrayList()
            Dim ROBOT_ERR_MSG As String = "Robot._ERR"
            Dim ALIGNER_ERR_MSG As String = "Aligner._ERR"

            If MessageName.IndexOf(ROBOT_ERR_MSG) > -1 Then
                Dim posMessageName As Integer = MessageName.IndexOf(ROBOT_ERR_MSG)
                Dim NumMessageName As Integer = Integer.Parse(MessageName.Substring(posMessageName + ROBOT_ERR_MSG.Length + 1))
                MessageName = ROBOT_ERR_MSG + " " + NumMessageName.ToString()
                If m_ErrorMessageConfig.ContainsKey(MessageName) Then
                    sMessageName.Add(m_ErrorMessageConfig.Item(MessageName))
                Else
                    sMessageName.Add("_ERR" + " " + NumMessageName.ToString() + " - " + "Message Undefined.")
                End If
            ElseIf MessageName.IndexOf(ALIGNER_ERR_MSG) > -1 Then
                Dim posMessageName As Integer = MessageName.IndexOf(ALIGNER_ERR_MSG)
                Dim NumMessageName As Integer = Integer.Parse(MessageName.Substring(posMessageName + ALIGNER_ERR_MSG.Length + 1))
                MessageName = ALIGNER_ERR_MSG + " " + NumMessageName.ToString()
                ''''check if Err is defined
                If (m_ErrorMessageConfig.Item(MessageName) IsNot Nothing) Then
                sMessageName.Add(m_ErrorMessageConfig.Item(MessageName))
                Else
                    Return Nothing
                End If
            ElseIf MessageName.IndexOf("Elevator") > -1 And MessageName.IndexOf("ER") > -1 Then
                Dim Messages As String() = MessageName.Split(".")
                Dim EquipmentName As String = Messages(0)
                Dim Message As String = Messages(1)
                Dim arrPropertyNames As New ArrayList()
                Dim decoder As Communication.TerminalDriver.TSDecoder = Activator.CreateInstance(Type.GetType("AVPLib.Communication.TerminalDriver." + "TSElevatorErrorDecoder"))
                sMessageName = decoder.Decode(Message)
                If sMessageName.Count >= 3 Then
                    sMessageName.RemoveRange(0, 2) ' Only return error codes.
                End If
            End If
            Return sMessageName
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.dataManagementLogger.Info("Leave CheckMessageError")
        Return Nothing
    End Function

    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-14</date>
    ''' </author>
    ''' <summary>
    ''' GetKepServer
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetKepServer() As ArrayList
        Return ContainerDAO.GetKepServer()
    End Function

    ''' <author>
    '''    	<name>Vo Tan Dat</name>
    '''    	<date> 2010-05-17</date>
    ''' </author>
    ''' <summary>
    ''' Set Kepserver Description
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SetKepServerTagDescription(ByVal Group As String, _
                                                      ByVal Tag_ID As String, _
                                                      ByVal Tag_Des As String, _
                                                      ByVal NeedSave As Boolean) As Boolean
        Return ContainerDAO.SetKepServerTagDescription(Group, Tag_ID, Tag_Des, NeedSave)
    End Function

    Public Shared Function GetConfigurableKepServer(ByRef actions As Hashtable, ByRef statuses As Hashtable) As Boolean
        Return ContainerDAO.GetConfigurableKepServer(actions, statuses)
    End Function
#End Region

#Region "Configuration"
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2009-07-06</date>
    ''' </author>
    ''' <summary>
    ''' Check if we configure to use Delta Pick or not.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function PVDRoughPumpPressure() As Double
        AVPLib.Log.coreLogger.Info("Enter PVDRoughPumpPressure")
        ' Read this value from configuration file
        Try
            Dim objRoughPumpPressure As Object = (AVPLib.ContainerData.GetRobotConfig(ConstEnum.ROUGH_PUMP_CG))
            If (objRoughPumpPressure = "") Or Not IsNumeric(objRoughPumpPressure) Then
                AVPLib.Log.coreLogger.Info("Leave PVDRoughPumpPressure")
                Return MIN_DEFAULT_VALUE
            End If

            Return CDbl(objRoughPumpPressure)
            AVPLib.Log.coreLogger.Info("Leave PVDRoughPumpPressure")

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave PVDRoughPumpPressure")
        Return MIN_DEFAULT_VALUE
    End Function
    ''' <author>
    '''    	<name>Ngo Cao Dinh</name>
    '''    	<date> 2008-11-27</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get timeout configuration
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetTimeout(ByVal Name As String) As Integer
        Try
            Return m_TimeoutConfig.Item(Name)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return Nothing
    End Function

    Public Shared Function GetCryoRegenHour() As Boolean
        Try
            Return ContainerDAO.GetCryoRegenHourLimit
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-20</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get message code ContainerData
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPolling(ByVal Name As String) As Polling
        AVPLib.Log.coreLogger.Info("Enter GetPolling")
        Try
            Dim result As Polling
            SyncLock m_PollingConfig.SyncRoot
                result = CType(m_PollingConfig.Item(Name), Polling)
            End SyncLock
            Return result
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetPolling")
        Return Nothing
    End Function
    ''' <author>
    '''    	<name>Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-125</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get Pressure form xml file
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPressure(ByVal Name As String) As Double
        AVPLib.Log.coreLogger.Info("Enter GetPressure")
        Try
            Dim result As Double
            SyncLock m_RobotPressureConfigMap.SyncRoot
                result = CType(m_RobotPressureConfigMap.Item(Name), Double)
            End SyncLock
            Return result
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetPressure")
        Return Nothing
    End Function
    ''' <author>
    '''    	<name>Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-125</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get Pump down form xml file
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPumpdownLL(ByVal Name As String) As Double
        AVPLib.Log.coreLogger.Info("Enter GetPumpdownLL")
        Try
            Dim result As Double
            SyncLock m_PumdownConfigMapLL.SyncRoot
                result = CType(m_PumdownConfigMapLL.Item(Name), Double)
            End SyncLock
            AVPLib.Log.coreLogger.Info("Leave GetPumpdownLL")
            Return result
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetPumpdownLL")
        Return Nothing
    End Function
    ''' <author>
    '''    	<name>Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-125</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get Pump down form xml file
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPumpdownTM(ByVal Name As String) As Double
        AVPLib.Log.coreLogger.Info("Enter GetPumpdownTM")
        Try
            Dim result As Double
            SyncLock m_PumdownConfigMapTM.SyncRoot
                result = CType(m_PumdownConfigMapTM.Item(Name), Double)
            End SyncLock
            AVPLib.Log.coreLogger.Info("Leave GetPumpdownTM")
            Return result
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetPumpdownTM")
        Return Nothing
    End Function
    ''' <author>
    '''    	<name>Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-16</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get GetVentLL
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetVentLL(ByVal Name As String) As Double
        AVPLib.Log.coreLogger.Info("Enter GetVentLL")
        Try
            Dim result As Double
            SyncLock m_VentConfigMapLL.SyncRoot
                result = CType(m_VentConfigMapLL.Item(Name), Double)
            End SyncLock
            AVPLib.Log.coreLogger.Info("Leave GetVentLL")
            Return result
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetVentLL")
        Return Nothing
    End Function
    ''' <author>
    '''    	<name>Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-16</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get GetVentTM
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetVentTM(ByVal Name As String) As Double
        AVPLib.Log.coreLogger.Info("Enter GetVentTM")
        Dim result As Double = 0.0
        Try
            SyncLock m_VentConfigMapTM.SyncRoot
                result = CType(m_VentConfigMapTM.Item(Name), Double)
            End SyncLock
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Enter GetVentTM")
        Return result
    End Function
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-12-10</date>
    ''' </author>
    ''' <summary>
    ''' SaveTimeout
    ''' </summary>
    ''' <param name="ListPolling"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Shared Function SavePolling(ByVal ListPolling As ArrayList) As Boolean
    '    AVPLib.Log.coreLogger.Info("Enter SavePolling")
    '    Try
    '        Dim Success As Boolean
    '        SyncLock m_PollingConfig.SyncRoot
    '            m_PollingConfig.Clear()
    '            For Each Polling As Polling In ListPolling
    '                m_PollingConfig.Add(Polling.Name, Polling)
    '            Next

    '            Success = ContainerDAO.SavePollingConfig(m_PollingConfig)
    '        End SyncLock
    '        If Success Then
    '            Dim ctrRobot As RobotController = CType(ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), RobotController)
    '            ctrRobot.LinkTestInterval = GetPolling(ConstEnum.Equipments.Robot.ToString()).Interval

    '            Dim ctrLLAElevator As LLElevatorController = CType(CType(ControllerManager.GetController(ConstEnum.Equipments.LoadLockA.ToString()), LoadLockController).ChildController.Item("LLElevator"), LLElevatorController)
    '            ctrLLAElevator.PullingInterval = GetPolling(ConstEnum.Equipments.LLAElevator.ToString()).Interval

    '            Dim ctrLLBElevator As LLElevatorController = CType(CType(ControllerManager.GetController(ConstEnum.Equipments.LoadLockB.ToString()), LoadLockController).ChildController.Item("LLElevator"), LLElevatorController)
    '            ctrLLBElevator.PullingInterval = GetPolling(ConstEnum.Equipments.LLBElevator.ToString()).Interval

    '            Dim ctrLLBCryo As LLCryoController = CType(CType(ControllerManager.GetController(ConstEnum.Equipments.LoadLockB.ToString()), LoadLockController).ChildController.Item("LLCryo"), LLCryoController)
    '            ctrLLBCryo.PullingInterval = GetPolling(ConstEnum.Equipments.LLACryo.ToString()).Interval

    '            Dim ctrLLACryo As LLCryoController = CType(CType(ControllerManager.GetController(ConstEnum.Equipments.LoadLockA.ToString()), LoadLockController).ChildController.Item("LLCryo"), LLCryoController)
    '            ctrLLACryo.PullingInterval = GetPolling(ConstEnum.Equipments.LLBCryo.ToString()).Interval

    '            Dim ctrCryo As TMCryoController = CType(CType(ControllerManager.GetController(ConstEnum.Equipments.CassettesModule.ToString()), TMController).ChildController.Item(ConstEnum.Equipments.TMCryo.ToString()), TMCryoController)
    '            ctrCryo.PullingInterval = GetPolling(ConstEnum.Equipments.TMCryo.ToString()).Interval
    '            Return True
    '        End If
    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    '    AVPLib.Log.coreLogger.Info("Leave SavePolling")
    '    Return False
    'End Function

    ''' <author>
    '''    	<name>Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-16</date>
    ''' </author>
    ''' <summary>
    ''' SavePressure
    ''' </summary>
    ''' <param name="ListPressure"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SavePressure(ByVal ListPressure As Hashtable) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SavePressure")
        Try
            Dim Success As Boolean
            SyncLock m_RobotPressureConfigMap.SyncRoot
                Dim tempMap As Hashtable = m_RobotPressureConfigMap.Clone()
                ' for each and set each item
                For Each de As DictionaryEntry In ListPressure
                    tempMap.Item(de.Key) = de.Value
                Next
                Success = ContainerDAO.SavePressureConfig(tempMap)
                If Success Then
                    m_RobotPressureConfigMap.Clear()
                    m_RobotPressureConfigMap = tempMap
                    Return True
                End If
            End SyncLock
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SavePressure")
        Return False
    End Function

    Public Shared Function SaveTransferPressureSetpoint(ByVal ListPressure As Hashtable) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SaveTransferPressureSetpoint")
        Try
            Dim Success As Boolean = False
            SyncLock m_TransferPressureSetpointMap.SyncRoot
                Dim tempMap As Hashtable = m_TransferPressureSetpointMap.Clone()
                ' for each and set each item
                For Each de As DictionaryEntry In ListPressure
                    tempMap.Item(de.Key) = de.Value
                Next
                Success = ContainerDAO.SaveTransferPressureSetpointConfig(tempMap)
                If Success Then
                    m_TransferPressureSetpointMap.Clear()
                    m_TransferPressureSetpointMap = tempMap
                    Return True
                End If
            End SyncLock
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveTransferPressureSetpoint")
        Return False
    End Function

    Public Shared Function SaveCryoRegenHourLimit() As Boolean
        Try
            Return ContainerDAO.SaveCryoRegenHourLimit()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function

    Public Shared Function SaveLLElevatorConfig(ByVal LLElevatorConfig As Hashtable, ByVal LLElevatorName As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SaveLLElevatorConfig")
        Try
            Dim Success As Boolean = False
            If (ConstEnum.Equipments.LLAElevator.ToString() = LLElevatorName) AndAlso m_LLAElevatorConfigMap IsNot Nothing Then
                SyncLock m_LLAElevatorConfigMap.SyncRoot
                    Dim tempMap As Hashtable = m_LLAElevatorConfigMap.Clone()
                    ' for each and set each item
                    For Each de As DictionaryEntry In LLElevatorConfig
                        tempMap.Item(de.Key) = de.Value
                    Next
                    Success = ContainerDAO.SaveLLElevatorConfig(LLElevatorConfig, LLElevatorName)
                    If Success Then
                        m_LLAElevatorConfigMap.Clear()
                        m_LLAElevatorConfigMap = tempMap
                        Return True
                    End If
                End SyncLock
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveLLElevatorConfig")
        Return False
    End Function

    Public Shared Function SaveSystemWaitForCheckSensor(ByVal waitTime As Integer) As Boolean
        Try
            Return ContainerDAO.SetSystemWaitForCheckSensor(waitTime)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    '''    	<name>Do Nguyen Dy</name>
    '''    	<date> 2015-01-7</date>
    ''' </author>
    ''' <summary>
    ''' SaveSystemIDLE_Time ( Save Auto LogOut TimeOut )
    ''' </summary>
    Public Shared Function SaveSystemIDLE_Time(ByVal waitTime As Integer) As Boolean
        Try
            Return ContainerDAO.SetSystemIDLE_Time(waitTime)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    '''    	<name>Tin Pham</name>
    '''    	<date> 2017-10-05 </date>
    ''' </author>
    ''' <summary>
    ''' SetConfigFilament
    ''' </summary>
    Public Shared Function SetConfigFilament(ByVal name As String, ByVal numFilament As Integer) As Boolean
        Try
            Return ContainerDAO.SetConfigFilament(name, numFilament)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    '''    	<name>Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-16</date>
    ''' </author>
    ''' <summary>
    ''' SavePumpDown
    ''' </summary>
    ''' <param name="ListPolling"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SavePumpDown(ByVal ListPumpdown As Hashtable, ByVal NameEquipment As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SavePumpDown")
        Try '
            Dim Success As Boolean
            If NameEquipment = LLPUMPDOWN_CONFIG Then
                SyncLock m_PumdownConfigMapLL.SyncRoot
                    Dim tempMap As Hashtable = m_PumdownConfigMapLL.Clone()
                    ' for each and set each item
                    For Each de As DictionaryEntry In ListPumpdown
                        tempMap.Item(de.Key) = de.Value
                    Next
                    Success = ContainerDAO.SavePumpdownConfigLL(tempMap)
                    If Success Then
                        m_PumdownConfigMapLL.Clear()
                        m_PumdownConfigMapLL = tempMap
                        Return True
                    End If
                End SyncLock
            ElseIf NameEquipment = TMPUMPDOWN_CONFIG Then
                SyncLock m_PumdownConfigMapTM.SyncRoot
                    Dim tempMap As Hashtable = m_PumdownConfigMapTM.Clone()
                    ' for each and set each item
                    For Each de As DictionaryEntry In ListPumpdown
                        tempMap.Item(de.Key) = de.Value
                    Next
                    Success = ContainerDAO.SavePumpdownConfigTM(tempMap)
                    If Success Then
                        m_PumdownConfigMapTM.Clear()
                        m_PumdownConfigMapTM = tempMap
                        Return True
                    End If
                End SyncLock
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SavePumpDown")
        Return False
    End Function
    '''    	<name>Tran Ngoc Khiet</name>
    '''    	<date> 2009-06-16</date>
    ''' </author>
    ''' <summary>
    ''' SaveVent
    ''' </summary>
    ''' <param name="ListPolling"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveVent(ByVal ListPumpdown As Hashtable, ByVal NameEquipment As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SaveVent")
        Try '
            Dim Success As Boolean
            If NameEquipment = LLVENT_CONFIG Then
                SyncLock m_VentConfigMapLL.SyncRoot
                    Dim tempMap As Hashtable = m_VentConfigMapLL.Clone()
                    ' for each and set each item
                    For Each de As DictionaryEntry In ListPumpdown
                        tempMap.Item(de.Key) = de.Value
                    Next
                    Success = ContainerDAO.SaveVentLL(tempMap)
                    If Success Then
                        m_VentConfigMapLL.Clear()
                        m_VentConfigMapLL = tempMap
                        Return True
                    End If
                End SyncLock
            ElseIf NameEquipment = TMVENT_CONFIG Then
                SyncLock m_VentConfigMapTM.SyncRoot
                    Dim tempMap As Hashtable = m_VentConfigMapTM.Clone()
                    ' for each and set each item
                    For Each de As DictionaryEntry In ListPumpdown
                        tempMap.Item(de.Key) = de.Value
                    Next
                    Success = ContainerDAO.SaveVentTM(tempMap)
                    If Success Then
                        m_VentConfigMapTM.Clear()
                        m_VentConfigMapTM = tempMap
                        Return True
                    End If
                End SyncLock
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveVent")
        Return False
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-10</date>
    ''' </author>
    ''' <summary>
    ''' Property of Robot Config
    ''' </summary>
    ''' <param name="Key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetRobotConfig(ByVal Key As String) As Object
        AVPLib.Log.coreLogger.Info("Enter GetRobotConfig")
        Try
            Return m_RobotConfigMap.Item(Key)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetRobotConfig")
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Vo Tan Dat </name>
    '''    	<date> 2010-09-10</date>
    ''' </author>
    ''' <summary>
    ''' Set config
    ''' </summary>
    ''' <param name="Key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub SetRobotConfig(ByVal Key As String, ByVal Value As Object)
        AVPLib.Log.coreLogger.Info("Enter SetRobotConfig")
        Try
            m_RobotConfigMap.Item(Key) = Value
            ContainerDAO.SetRobotConfig(Key, Value)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SetRobotConfig")
    End Sub

    Public Shared Function GetTransferPressureSetpointConfig(ByVal Key As String) As Object
        AVPLib.Log.coreLogger.Info("Enter GetTransferPressureSetpointConfig")
        Try
            Return m_TransferPressureSetpointMap.Item(Key)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetTransferPressureSetpointConfig")
        Return Nothing
    End Function

    Public Shared Sub Append_System_XMLNode(ByVal ListOfMissingNode As List(Of String), ByRef nodexml As XmlNode)
        Try
            For Each NodeName As String In ListOfMissingNode
                Dim newXmlNode As Xml.XmlNode = ContainerDAO.SystemConfigDoc.CreateNode(XmlNodeType.Element, NodeName, Nothing)
                newXmlNode.InnerText = ""
                nodexml.AppendChild(newXmlNode)
                BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, ContainerDAO.SystemConfigDoc)
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub Search_And_Append_System_Values(ByVal NodeName As String, ByRef nodeXml As XmlNode)
        Dim ListOfMissingItemToConfig As New List(Of String)
        Select Case NodeName
            Case "ElevatorConfig"
                ListOfMissingItemToConfig.Add(ConstEnum.Equipments.LLAElevator.ToString())

                For Each childnode As XmlNode In nodeXml.ChildNodes
                    If childnode.Name = ConstEnum.Equipments.LLAElevator.ToString() Then
                        ListOfMissingItemToConfig.Remove(ConstEnum.Equipments.LLAElevator.ToString())
                    End If
                Next
                If ListOfMissingItemToConfig.Count > 0 Then
                    Append_System_XMLNode(ListOfMissingItemToConfig, nodeXml)
                End If

            Case "LLElevatorConfig" ''NumberOfSlot...TravelLength...
                ListOfMissingItemToConfig.Add(ConstEnum.NUMBER_OF_SLOT)
                ListOfMissingItemToConfig.Add(ConstEnum.TRAVEL_LENGTH)
                ListOfMissingItemToConfig.Add(ConstEnum.PITCH)
                ListOfMissingItemToConfig.Add(ConstEnum.BASE_OFFSET)
                ListOfMissingItemToConfig.Add(ConstEnum.FIND_BIAS)
                For i As Integer = 0 To nodeXml.ChildNodes.Count - 1
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.NUMBER_OF_SLOT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.TRAVEL_LENGTH, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.PITCH, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.BASE_OFFSET, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.FIND_BIAS, nodeXml, i)
                Next
                If ListOfMissingItemToConfig.Count > 0 Then
                    AppendName_Value_Attribute(ListOfMissingItemToConfig, nodeXml)
                End If
                ListOfMissingItemToConfig = Nothing

            Case "Elevator_VC_Config"
                ListOfMissingItemToConfig.Add("LLAElevator_VC2")
                ListOfMissingItemToConfig.Add("LLAElevator_VC4")
                ListOfMissingItemToConfig.Add("LLAElevator_VC6")
                For Each childnode As XmlNode In nodeXml.ChildNodes
                    If childnode.Name = "LLAElevator_VC2" Then
                        ListOfMissingItemToConfig.Remove("LLAElevator_VC2")
                    End If
                    If childnode.Name = "LLAElevator_VC4" Then
                        ListOfMissingItemToConfig.Remove("LLAElevator_VC4")
                    End If
                    If childnode.Name = "LLAElevator_VC6" Then
                        ListOfMissingItemToConfig.Remove("LLAElevator_VC6")
                    End If
                Next
                If ListOfMissingItemToConfig.Count > 0 Then
                    Append_System_XMLNode(ListOfMissingItemToConfig, nodeXml)
                End If

            Case "LLElevator_VC" ''SCFNS_Value,....
                ListOfMissingItemToConfig.Add(ConstEnum.SCFNS_VALUE)
                ListOfMissingItemToConfig.Add(ConstEnum.SCFLM_VALUE)
                ListOfMissingItemToConfig.Add(ConstEnum.SCFCT_VALUE)
                ListOfMissingItemToConfig.Add(ConstEnum.SCFPT_VALUE)
                ListOfMissingItemToConfig.Add(ConstEnum.SFB_VALUE)
                For i As Integer = 0 To nodeXml.ChildNodes.Count - 1
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.SCFNS_VALUE, nodeXml, i, False, True)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.SCFCT_VALUE, nodeXml, i, False, True)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.SCFLM_VALUE, nodeXml, i, False, True)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.SCFPT_VALUE, nodeXml, i, False, True)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.SFB_VALUE, nodeXml, i, False, True)
                Next
                If ListOfMissingItemToConfig.Count > 0 Then
                    AppendLLElevator_VCConfig(ListOfMissingItemToConfig, nodeXml)
                End If
                ListOfMissingItemToConfig = Nothing

            Case "VentPumpdownConfig"
                ListOfMissingItemToConfig.Add(ConstEnum.LLVENT_CONFIG)
                ListOfMissingItemToConfig.Add(ConstEnum.LLPUMPDOWN_CONFIG)
                ListOfMissingItemToConfig.Add(ConstEnum.TMVENT_CONFIG)
                ListOfMissingItemToConfig.Add(ConstEnum.TMPUMPDOWN_CONFIG)
                For Each childnode As XmlNode In nodeXml.ChildNodes
                    If childnode.Name = ConstEnum.LLVENT_CONFIG Then
                        ListOfMissingItemToConfig.Remove(ConstEnum.LLVENT_CONFIG)
                    End If
                    If childnode.Name = ConstEnum.LLPUMPDOWN_CONFIG Then
                        ListOfMissingItemToConfig.Remove(ConstEnum.LLPUMPDOWN_CONFIG)
                    End If
                    If childnode.Name = ConstEnum.TMVENT_CONFIG Then
                        ListOfMissingItemToConfig.Remove(ConstEnum.TMVENT_CONFIG)
                    End If
                    If childnode.Name = ConstEnum.TMPUMPDOWN_CONFIG Then
                        ListOfMissingItemToConfig.Remove(ConstEnum.TMPUMPDOWN_CONFIG)
                    End If
                Next
                If ListOfMissingItemToConfig.Count > 0 Then
                    Append_System_XMLNode(ListOfMissingItemToConfig, nodeXml)
                End If

            Case ConstEnum.LLVENT_CONFIG
                ListOfMissingItemToConfig.Add(LLMESAVALVEOPENCLOSETIMEOUT)
                ListOfMissingItemToConfig.Add(IGONOFFTIMEOUT)
                ListOfMissingItemToConfig.Add(LLHIVACOPENCLOSETIMEOUT)
                ListOfMissingItemToConfig.Add(LLASLOWVENTTIMEOUT)
                ListOfMissingItemToConfig.Add(LLASLOWVENTPRESSURE)
                ListOfMissingItemToConfig.Add(LLAFASTVENTTIMEOUT)
                ListOfMissingItemToConfig.Add(LLAVENTPRESSURE)
                ListOfMissingItemToConfig.Add(LLVENTVALVEOPENCLOSETIMEOUT)
                ListOfMissingItemToConfig.Add(LLVENT_DELAY_TIME)
                For i As Integer = 0 To nodeXml.ChildNodes.Count - 1
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLMESAVALVEOPENCLOSETIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.IGONOFFTIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLHIVACOPENCLOSETIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLASLOWVENTTIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLASLOWVENTPRESSURE, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLAFASTVENTTIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLAVENTPRESSURE, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLVENTVALVEOPENCLOSETIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLVENT_DELAY_TIME, nodeXml, i)
                Next
                If ListOfMissingItemToConfig.Count > 0 Then
                    AppendName_Value_Attribute(ListOfMissingItemToConfig, nodeXml, UCase(ConstEnum.LLVENT_CONFIG) & "_")
                End If
                ListOfMissingItemToConfig = Nothing

            Case ConstEnum.LLPUMPDOWN_CONFIG
                ListOfMissingItemToConfig.Add(LLMESAVALVEOPENCLOSETIMEOUT)
                ListOfMissingItemToConfig.Add(IGONOFFTIMEOUT)
                ListOfMissingItemToConfig.Add(LLHIVACOPENCLOSETIMEOUT)
                ListOfMissingItemToConfig.Add(TMMECHANICALPUMPONPRESSURE)
                ListOfMissingItemToConfig.Add(LLASLOWROUGHPRESSURE)
                ListOfMissingItemToConfig.Add(LLASLOWROUGHPRESSURETIMEOUT)
                ListOfMissingItemToConfig.Add(LLAFASTROUGHPRESSURE)
                ListOfMissingItemToConfig.Add(LLAFASTROUGHPRESSURETIMEOUT)
                ListOfMissingItemToConfig.Add(LLACRYOCOLDTEMP)
                ListOfMissingItemToConfig.Add(IGONDELAY)
                ListOfMissingItemToConfig.Add(LLROUGHVALVEOPENCLOSETIMEOUT)
                ListOfMissingItemToConfig.Add(LLPUMPDOWN_DELAY_TIME)
                For i As Integer = 0 To nodeXml.ChildNodes.Count - 1
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLMESAVALVEOPENCLOSETIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.IGONOFFTIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLHIVACOPENCLOSETIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.TMMECHANICALPUMPONPRESSURE, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLASLOWROUGHPRESSURE, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLASLOWROUGHPRESSURETIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLAFASTROUGHPRESSURE, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLAFASTROUGHPRESSURETIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLACRYOCOLDTEMP, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.IGONDELAY, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLROUGHVALVEOPENCLOSETIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, ConstEnum.LLPUMPDOWN_DELAY_TIME, nodeXml, i)
                Next
                If ListOfMissingItemToConfig.Count > 0 Then
                    AppendName_Value_Attribute(ListOfMissingItemToConfig, nodeXml, UCase(ConstEnum.LLPUMPDOWN_CONFIG) & "_")
                End If
                ListOfMissingItemToConfig = Nothing

            Case ConstEnum.TMVENT_CONFIG
                ListOfMissingItemToConfig.Add(TMMESAVALVESOPENCLOSETIMEOUT)
                ListOfMissingItemToConfig.Add(IGONOFFWAITTIME)
                ListOfMissingItemToConfig.Add(TMHIVACOPENCLOSETIMEOUT)
                ListOfMissingItemToConfig.Add(TMVENTPRESSURE)
                ListOfMissingItemToConfig.Add(TMVENTTIMEOUT)
                ListOfMissingItemToConfig.Add(TMVENTVALVEOPENCLOSETIMEOUT)
                ListOfMissingItemToConfig.Add(TMVENT_DELAY_TIME)
                For i As Integer = 0 To nodeXml.ChildNodes.Count - 1
                    RemoveStringInList(ListOfMissingItemToConfig, TMMESAVALVESOPENCLOSETIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, IGONOFFWAITTIME, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, TMHIVACOPENCLOSETIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, TMVENTPRESSURE, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, TMVENTTIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, TMVENTVALVEOPENCLOSETIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, TMVENT_DELAY_TIME, nodeXml, i)
                Next
                If ListOfMissingItemToConfig.Count > 0 Then
                    AppendName_Value_Attribute(ListOfMissingItemToConfig, nodeXml, UCase(ConstEnum.TMVENT_CONFIG) & "_")
                End If
                ListOfMissingItemToConfig = Nothing

            Case ConstEnum.TMPUMPDOWN_CONFIG
                ListOfMissingItemToConfig.Add(TMMESAVALVESOPENCLOSETIMEOUT)
                ListOfMissingItemToConfig.Add(IGONOFFTIMEOUT)
                ListOfMissingItemToConfig.Add(TMHIVACOPENCLOSETIMEOUT)
                ListOfMissingItemToConfig.Add(TMMECHANICALPUMPONPRESSURE)
                ListOfMissingItemToConfig.Add(TMROUGHPRESSURE)
                ListOfMissingItemToConfig.Add(TMROUGHTIMEOUT)
                ListOfMissingItemToConfig.Add(TMCRYOCOLDTEMP)
                ListOfMissingItemToConfig.Add(IGONDELAY)
                ListOfMissingItemToConfig.Add(TMPUMDOWN_DELAY_TIME)
                For i As Integer = 0 To nodeXml.ChildNodes.Count - 1
                    RemoveStringInList(ListOfMissingItemToConfig, TMMESAVALVESOPENCLOSETIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, IGONOFFTIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, TMHIVACOPENCLOSETIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, TMMECHANICALPUMPONPRESSURE, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, TMROUGHPRESSURE, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, TMROUGHTIMEOUT, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, TMCRYOCOLDTEMP, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, IGONDELAY, nodeXml, i)
                    RemoveStringInList(ListOfMissingItemToConfig, TMPUMDOWN_DELAY_TIME, nodeXml, i)
                Next
                If ListOfMissingItemToConfig.Count > 0 Then
                    AppendName_Value_Attribute(ListOfMissingItemToConfig, nodeXml, UCase(ConstEnum.TMPUMPDOWN_CONFIG) & "_")
                End If
                ListOfMissingItemToConfig = Nothing

            Case "TransferPressureSetpoint" ''
                ListOfMissingItemToConfig.Add(CASSETTESMODULETRANSFERSETPOINT)
                ListOfMissingItemToConfig.Add(LOADLOCKATRANSFERSETPOINT)
                ListOfMissingItemToConfig.Add(CHAMBER1TRANSFERSETPOINT)
                ListOfMissingItemToConfig.Add(CHAMBER2TRANSFERSETPOINT)
                ListOfMissingItemToConfig.Add(CHAMBER3TRANSFERSETPOINT)
                ListOfMissingItemToConfig.Add(PRESSUREDIFFERENTIALPERCENT)
                For i As Integer = 0 To nodeXml.ChildNodes.Count - 1
                    RemoveStringInList(ListOfMissingItemToConfig, CASSETTESMODULETRANSFERSETPOINT, nodeXml, i, True)
                    RemoveStringInList(ListOfMissingItemToConfig, LOADLOCKATRANSFERSETPOINT, nodeXml, i, True)
                    RemoveStringInList(ListOfMissingItemToConfig, CHAMBER1TRANSFERSETPOINT, nodeXml, i, True)
                    RemoveStringInList(ListOfMissingItemToConfig, CHAMBER2TRANSFERSETPOINT, nodeXml, i, True)
                    RemoveStringInList(ListOfMissingItemToConfig, CHAMBER3TRANSFERSETPOINT, nodeXml, i, True)
                    RemoveStringInList(ListOfMissingItemToConfig, PRESSUREDIFFERENTIALPERCENT, nodeXml, i, True)
                Next
                If ListOfMissingItemToConfig.Count > 0 Then
                    AppendXMLNode(ListOfMissingItemToConfig, "Configure", "Key", nodeXml)
                End If
                ListOfMissingItemToConfig = Nothing
        End Select
    End Sub

    Public Shared Sub RemoveStringInList(ByRef ListOfMissingNode As List(Of String), ByVal ValueForRemove As String, ByVal Nodexml As XmlNode, _
                                         ByVal indexofItemXML As Integer, Optional ByVal blnSearchInnerText As Boolean = False, _
    Optional ByVal blnSearchForAttributeName As Boolean = False)
        AVPLib.Log.coreLogger.Info("Enter RemoveStringInList")
        Try
            If blnSearchInnerText Then
                If Nodexml.ChildNodes.Item(indexofItemXML).FirstChild.InnerText = ValueForRemove Then
                    ListOfMissingNode.Remove(ValueForRemove)
                End If
                Exit Sub
            End If
            If blnSearchForAttributeName Then
                If Nodexml.ChildNodes.Item(indexofItemXML).Attributes.Item(0).Name = ValueForRemove Then
                    ListOfMissingNode.Remove(ValueForRemove)
                End If
            Else
                If Nodexml.ChildNodes.Item(indexofItemXML).Attributes.Item(0).Value = ValueForRemove Then
                    ListOfMissingNode.Remove(ValueForRemove)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave RemoveStringInList")
    End Sub

    Public Shared Sub AppendName_Value_Attribute(ByVal ListOfValue As List(Of String), ByVal xmlParentNode As XmlNode, Optional ByVal ValueForAppend_To_GetValue As String = "")
        AVPLib.Log.coreLogger.Info("Enter AppendName_Value_Attribute")
        Try
            For Each NodeValue As String In ListOfValue
                Dim newXmlNode As Xml.XmlNode = ContainerDAO.SystemConfigDoc.CreateNode(XmlNodeType.Element, "Item", Nothing)
                Dim newAtt As Xml.XmlAttribute = ContainerDAO.SystemConfigDoc.CreateAttribute("Name")
                newAtt.Value = NodeValue
                newXmlNode.Attributes.Append(newAtt)
                newAtt = ContainerDAO.SystemConfigDoc.CreateAttribute("Value")
                newAtt.Value = GetObj_From_System_Restore_Dictionary(ValueForAppend_To_GetValue & NodeValue).ToString()
                newXmlNode.Attributes.Append(newAtt)
                xmlParentNode.AppendChild(newXmlNode)
                BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, ContainerDAO.SystemConfigDoc)
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave AppendName_Value_Attribute")
    End Sub
    ''This function add Xml Node if file System Config missing tag
    ''ChildNodeName= Key or Name
    ''NodeName=Configure or SubSystem
    ''ListOfValue=Chamber2TransferSetPoint, or...ROR Litter..
    ''xmlParentNode=SubSystemList, TransferPressureSetpoint
    Public Shared Sub AppendXMLNode(ByVal ListofValue As List(Of String), ByVal NodeName As String, ByVal ChildNodeName As String, ByVal xmlParentNode As XmlNode)
        AVPLib.Log.coreLogger.Info("Enter AppendXMLNode")
        Try
            For Each NodeValue As String In ListofValue
                Dim newXmlNode As Xml.XmlNode = ContainerDAO.SystemConfigDoc.CreateNode(XmlNodeType.Element, NodeName, Nothing)
                Dim NameNode As Xml.XmlNode = ContainerDAO.SystemConfigDoc.CreateNode(XmlNodeType.Element, ChildNodeName, Nothing)
                NameNode.InnerText = NodeValue
                Dim ValueNode As Xml.XmlNode = ContainerDAO.SystemConfigDoc.CreateNode(XmlNodeType.Element, "Value", Nothing)
                ValueNode.InnerText = GetObj_From_System_Restore_Dictionary(NodeValue).ToString()
                newXmlNode.AppendChild(NameNode)
                newXmlNode.AppendChild(ValueNode)
                xmlParentNode.AppendChild(newXmlNode)
                BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, ContainerDAO.SystemConfigDoc)
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Enter AppendXMLNode")
    End Sub

    Public Shared Sub AppendLLElevator_VCConfig(ByVal ListOfValue As List(Of String), ByVal xmlParentNode As XmlNode)
        AVPLib.Log.coreLogger.Info("Enter AppendLLElevator_VCConfig")
        Try
            For Each NodeValue As String In ListOfValue
                Dim newXmlNode As Xml.XmlNode = ContainerDAO.SystemConfigDoc.CreateNode(XmlNodeType.Element, "Property", Nothing)
                Dim newAtt As Xml.XmlAttribute = ContainerDAO.SystemConfigDoc.CreateAttribute(NodeValue)
                newAtt.Value = GetObj_From_System_Restore_Dictionary(NodeValue).ToString()
                newXmlNode.Attributes.Append(newAtt)
                xmlParentNode.AppendChild(newXmlNode)
                BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, ContainerDAO.SystemConfigDoc)
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave AppendLLElevator_VCConfig")
    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-09-04</date>
    ''' </author>
    ''' <summary>
    ''' Property of chambers Config
    ''' </summary>
    ''' <param name="Key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetChambersConfig(ByVal ChambersConfigMap As Hashtable, ByVal Key As String) As Object
        AVPLib.Log.coreLogger.Info("Enter GetChambersConfig")
        Try
            Return ChambersConfigMap.Item(Key)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetChambersConfig")
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> xxx </name>
    '''    	<date> 2009-07-29</date>
    ''' </author>
    ''' <summary>
    ''' Check if whether ChamberX is shown on GUI.
    ''' </summary>
    ''' <param name="chamberName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsChamberVisible(ByVal chamberName As String, _
                   Optional ByRef ChamberModule As SystemModule = Nothing) As Boolean
        AVPLib.Log.coreLogger.Info("Enter IsChamberVisible")
        Dim objVal As Object = GetRobotConfig(chamberName)
        Dim bRet As Boolean = False
        If (objVal Is Nothing) Then
            Return False
        End If
        ChamberModule = CType(objVal, SystemModule)
        If CType(objVal, SystemModule).IsVisible Then
            bRet = True
        End If
        AVPLib.Log.coreLogger.Info("Leave IsChamberVisible")
        Return bRet
    End Function
    ''' <author>
    '''    	<name> xxx </name>
    '''    	<date> 2009-07-29</date>
    ''' </author>
    ''' <summary>
    ''' Check if whether chamberX is DCPVD
    ''' </summary>
    ''' <param name="chamberName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ChamberPVDType(ByVal chamberName As String) As PVDType
        AVPLib.Log.coreLogger.Info("Enter IsChamberDCPVD")
        Dim objVal As Object = GetRobotConfig(chamberName)
        If objVal Is Nothing Then
            Return False
        End If
        Dim ChamberModule As SystemModule = CType(objVal, SystemModule)
        If ChamberModule.DCTargetPowerVisible Then
            Return PVDType.DCPVD
        ElseIf ChamberModule.RFTargetPowerVisible Then
            Return PVDType.RFPVD
        Else
            Return PVDType.UNKNOWN
        End If
        AVPLib.Log.coreLogger.Info("Leave IsChamberDCPVD")
    End Function

    ''' <author>
    '''    	<name> xxx </name>
    '''    	<date> 2009-07-29</date>
    ''' </author>
    ''' <summary>
    ''' Get Station No for a station(from SystemConfig.xml).
    ''' </summary>
    ''' <param name="stationName"></param>
    ''' <param name="nLocation"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetStationLocation(ByVal stationName As String, ByRef nLocation As Integer) As Boolean
        AVPLib.Log.coreLogger.Info("Enter GetStationLocation")
        Dim objVal As SystemModule = CType(GetRobotConfig(stationName), SystemModule)
        If (objVal Is Nothing) Then
            AVPLib.Log.coreLogger.Info("Leave GetStationLocation")
            Return False
        End If
        If (objVal.StationLocation >= 0) Then
            nLocation = objVal.StationLocation
            AVPLib.Log.coreLogger.Info("Leave GetStationLocation")
            Return True
        End If
        AVPLib.Log.coreLogger.Info("Leave GetStationLocation")
        Return False
    End Function

    ''' <author>
    '''    	<name> xxx </name>
    '''    	<date> 2009-07-29</date>
    ''' </author>
    ''' <summary>
    ''' Get Transfer Set Point Pressure for a station(from SystemConfig.xml).
    ''' </summary>
    ''' <param name="strEquipment"></param>
    ''' <param name="defVal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetTransferSetPointPressureForStation(ByVal strEquipment As String, ByVal defVal As Single) As Single
        AVPLib.Log.coreLogger.Info("Enter GetTransferSetPointPressureForStation")
        Dim strKey As String = strEquipment & ConstEnum.TRANSFER_SET_POINT
        Return GetFloatFromValueInTransferPressureSetpointConfig(strKey, defVal)
        AVPLib.Log.coreLogger.Info("Leave GetTransferSetPointPressureForStation")
    End Function

    Public Shared Function GetFloatFromValueInTransferPressureSetpointConfig(ByVal strKey As String, ByVal defVal As Single) As Single
        AVPLib.Log.coreLogger.Info("Enter GetFloatFromValueInTransferPressureSetpointConfig")
        Dim objVal As Object = GetTransferPressureSetpointConfig(strKey)
        If (objVal Is Nothing) Then
            AVPLib.Log.coreLogger.Debug("Couldn't get the value for the key " & strKey & " from SystemConfig.xml")
            Return defVal
        End If
        Dim retVal As Single = defVal
        If Single.TryParse(objVal.ToString(), retVal) Then
            AVPLib.Log.coreLogger.Info("Leave GetFloatFromValueInTransferPressureSetpointConfig")
            Return retVal
        End If
        AVPLib.Log.coreLogger.Info("Leave GetFloatFromValueInTransferPressureSetpointConfig")
        Return defVal
    End Function

    ''' <author>
    '''    	<name> xxx </name>
    '''    	<date> 2009-07-29</date>
    ''' </author>
    ''' <summary>
    ''' A helper function, return a float from a string value.
    ''' </summary>
    ''' <param name="strKey"></param>
    ''' <param name="defVal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFloatFromValueInSystemConfig(ByVal strKey As String, ByVal defVal As Single) As Single
        AVPLib.Log.coreLogger.Info("Enter GetFloatFromValueInSystemConfig")
        Dim objVal As Object = GetRobotConfig(strKey)
        If (objVal Is Nothing) Then
            AVPLib.Log.coreLogger.Debug("Couldn't get the value for the key " & strKey & " from SystemConfig.xml")
            Return defVal
        End If
        Dim retVal As Single = defVal
        If Single.TryParse(objVal.ToString(), retVal) Then
            AVPLib.Log.coreLogger.Info("Leave GetFloatFromValueInSystemConfig")
            Return retVal
        End If
        AVPLib.Log.coreLogger.Info("Leave GetFloatFromValueInSystemConfig")
        Return defVal
    End Function

    ''' <author>
    '''    	<name> xxx </name>
    '''    	<date> 2009-07-29</date>
    ''' </author>
    ''' <summary>
    ''' A helper function, return a Integer from a string value.
    ''' </summary>
    ''' <param name="strKey"></param>
    ''' <param name="defVal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetIntegerFromKeyValueInRobotConfig(ByVal strKey As String, ByVal defVal As Integer) As Integer
        AVPLib.Log.coreLogger.Info("Enter GetIntegerFromKeyValueInRobotConfig")
        Dim objVal As Object = GetRobotConfig(strKey)
        If (objVal Is Nothing) Then
            AVPLib.Log.coreLogger.Debug("Couldn't get the value for the key " & strKey & " from SystemConfig.xml")
            Return defVal
        End If
        Dim retVal As Integer = defVal
        If Integer.TryParse(objVal.ToString(), retVal) Then
            AVPLib.Log.coreLogger.Info("Leave GetIntegerFromKeyValueInRobotConfig")
            Return retVal
        End If
        AVPLib.Log.coreLogger.Info("Leave GetIntegerFromKeyValueInRobotConfig")
        Return defVal
    End Function

    ''' <author>
    '''    	<name> xxx.xxx </name>
    '''    	<date> 2009-23-06</date>
    ''' </author>
    ''' <summary>
    ''' Get Station No for Pick and Place activiy of Aligner
    ''' </summary>
    ''' <param name="Key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAlignerStationLocation(ByRef iPlaceStation As Integer, ByRef iPickStation As Integer) As Boolean
        AVPLib.Log.coreLogger.Info("Enter GetAlignerStationLocation")
        Dim blRet As Boolean = True

        Try
            Dim objPickStation As Object = GetRobotConfig(DELTA_PICK_STATION)
            Dim objPickNeeded As Object = GetRobotConfig(DELTA_PICK_NEEDED)

            iPlaceStation = GetIntegerFromKeyValueInRobotConfig(Equipments.Aligner.ToString(), _
            ConstEnum.DEFAULT_STATION_NO_FOR_ALIGNER)
            iPickStation = iPlaceStation

            ' If DeltaPick configuration is not existed, just exit here.
            If (objPickStation Is Nothing Or objPickNeeded Is Nothing) Then
                blRet = False
                GoTo ENDFUNC
            End If

            Dim iDeltaPickNeeded As Integer = 0
            Dim iDeltaPickStationNo As Integer = iPickStation
            ' Parse the delta pick needed
            If Not Integer.TryParse(objPickNeeded.ToString(), iDeltaPickNeeded) Then
                blRet = False
                GoTo ENDFUNC
            End If

            ' Parse the station
            If Not Integer.TryParse(objPickStation.ToString(), iDeltaPickStationNo) Then
                blRet = False
                GoTo ENDFUNC
            End If

            If (iDeltaPickNeeded > 0) Then
                iPickStation = iDeltaPickStationNo
            End If
        Catch ex As Exception
            blRet = False
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
ENDFUNC:
        AVPLib.Log.coreLogger.Info("Leave GetAlignerStationLocation")
        Return blRet
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-08</date>
    ''' </author>
    ''' <summary>
    ''' GetPressureConfig
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPressureConfig(ByVal Key As String) As Double
        AVPLib.Log.coreLogger.Info("Enter GetPressureConfig")
        Try
            ' If this key can convert to double
            If Key <> ConstEnum.CG_FORMULA And Key <> ConstEnum.IG_FORMULA Then
                Return CType(m_RobotPressureConfigMap.Item(Key), Double)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetPressureConfig")
        Return 0
    End Function
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009 </date>
    ''' </author>
    ''' <summary>
    ''' Get CG Formulars for many segments
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCGFormulaList() As List(Of CGFormula)
        Try
            Return CType(m_RobotPressureConfigMap.Item(ConstEnum.CG_FORMULA), List(Of CGFormula))
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return Nothing
    End Function

    ''' <author>
    '''    	<name>Tinh Le</name>
    '''    	<date> 2018-11-29</date>
    ''' </author>
    ''' <summary>
    ''' Get CG Config form xml file
    ''' </summary>
    Public Shared Function GetCGConfig(ByVal Name As String) As Double
        AVPLib.Log.coreLogger.Info("Enter GetCGConfig")
        Try
            Dim result As Double
            SyncLock m_CGConfigMap.SyncRoot
                result = CType(m_CGConfigMap.Item(Name), Double)
            End SyncLock
            AVPLib.Log.coreLogger.Info("Leave GetCGConfig")
            Return result
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetCGConfig")
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009 </date>
    ''' </author>
    ''' <summary>
    ''' convert CG from Voltage to Torr
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function convertCGValue(ByVal dblValue As Double) As Double
        AVPLib.Log.coreLogger.Info("Enter convertCGValue")
        ' Return value
        Dim dblRet = dblValue
        Try
            Dim cgSegmentList As List(Of CGFormula) = GetCGFormulaList()
            If cgSegmentList IsNot Nothing Then
                'Find the suitable formula
                Dim strRawFormula = String.Empty
                'Get Min value
                Dim mMinest As Double = cgSegmentList(0).Min
                For Each segment As CGFormula In cgSegmentList
                    If (mMinest > segment.Min) Then
                        mMinest = segment.Min
                    End If
                Next
                'Check less than MinValue
                If (dblValue < mMinest) Then
                    dblValue = mMinest
                End If
                'Get Max value
                Dim mMaxest As Double = cgSegmentList(0).Max
                For Each segment As CGFormula In cgSegmentList
                    If (mMaxest < segment.Max) Then
                        mMaxest = segment.Max
                    End If
                Next
                'Check great than MaxValue
                If (dblValue > mMaxest) Then
                    dblValue = mMaxest
                End If

                For Each segment As CGFormula In cgSegmentList
                    'If this is a suitable fomula
                    If dblValue >= segment.Min And dblValue <= segment.Max Then
                        strRawFormula = segment.Fomula
                        Exit For
                    End If
                Next
                ' check if the formula is not empty
                If strRawFormula <> String.Empty Then
                    Dim strFormatedFormula = String.Format(strRawFormula, dblValue.ToString())
                    Try
                        dblRet = AVPLib.Expression.Evaluate(strFormatedFormula, New Dictionary(Of String, Double)())
                    Catch ex As Exception
                        AVPLib.Log.avpLogger.Error("There is something wrong in your formula. Please check again")
                    End Try
                End If
            Else
                AVPLib.Log.avpLogger.Error("Can not retrieve the formula to calculate the CG")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave convertCGValue")
        Return dblRet
    End Function
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009 </date>
    ''' </author>
    ''' <summary>
    ''' Get IG Formulas
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetIGFormula() As String
        AVPLib.Log.coreLogger.Info("Enter GetIGFormula")
        Try
            Return CType(m_RobotPressureConfigMap.Item(ConstEnum.IG_FORMULA), String)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetIGFormula")
        Return String.Empty
    End Function
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009 </date>
    ''' </author>
    ''' <summary>
    ''' convert IG from Voltage to Torr
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function convertIGValue(ByVal dblValue As Double) As Double
        AVPLib.Log.coreLogger.Info("Enter convertIGValue")
        ' Return value
        Dim dblRet = dblValue
        Try
            Dim strRawFormula As String = GetIGFormula()
            If strRawFormula <> String.Empty Then
                Dim strFormatedFormula = String.Format(strRawFormula, dblValue.ToString())
                Try
                    dblRet = AVPLib.Expression.Evaluate(strFormatedFormula, New Dictionary(Of String, Double)())
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error("There is something wrong in your formula. Please check again")
                End Try
            Else
                AVPLib.Log.avpLogger.Error("Can not retrieve the formula to calculate the IG")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave convertIGValue")
        Return dblRet
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-08</date>
    ''' </author>
    ''' <summary>
    ''' SavePressureConfig
    ''' </summary>
    ''' <param name="TransferModuleMin"></param>
    ''' <param name="TransferModuleMax"></param>
    ''' <param name="LoadLockAMin"></param>
    ''' <param name="LoadLockAMax"></param>
    ''' <param name="LoadLockBMin"></param>
    ''' <param name="LoadLockBMax"></param>
    ''' <param name="IBEMaintenanceMin"></param>
    ''' <param name="IBEMaintenanceMax"></param>
    ''' <remarks></remarks>
    Public Shared Function SavePressureConfig(ByVal TransferModuleMin As Double, ByVal TransferModuleMax As Double, _
    ByVal LoadLockAMin As Double, ByVal LoadLockAMax As Double, ByVal IBEMaintenanceMin As Double, ByVal IBEMaintenanceMax As Double) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SavePressureConfig")
        Try
            Dim Success As Boolean = ContainerDAO.SavePressureConfig(TransferModuleMin, TransferModuleMax, LoadLockAMin, LoadLockAMax, IBEMaintenanceMin, IBEMaintenanceMax)
            If Success Then
                PressureConfigStart()
                Return True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SavePressureConfig")
        Return False
    End Function
#End Region
#Region "Life Time Wafer"
    Private Shared m_intLifeTimeWafer As Integer = 0
    Public Shared Property LifeTimeWafer() As Integer
        Get
            Return m_intLifeTimeWafer
        End Get
        Set(ByVal value As Integer)
            m_intLifeTimeWafer = value
            ''store in TM Obj for SECSGEM
            Dim Eq As AVPLib.DataManagerment.CassettesModule = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.CassettesModule.ToString())
            If Eq IsNot Nothing Then
                Eq.LifeTimeWafer = value
            End If
        End Set
    End Property
#End Region

#Region "Action Insert - Update - Delete"
#Region "User - Group"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Check user Existed
    ''' </summary>
    ''' <param name="username"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckUserExist(ByVal username As String) As Boolean
        Try
            For Each name As String In ListUser()
                If String.Compare(name, username, True) = 0 Then
                    Return True
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return False
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' SaveUser from UserSetupLib.SaveUser
    ''' </summary>
    ''' <param name="user"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveUser(ByVal user As DBUser) As DBUser
        Try
            ContainerDAO.SaveUser(user)
            For Each Item As DictionaryEntry In m_UserMap
                If String.Compare(Item.Key, user.Username, True) = 0 Then ' InCase-Sensitive
                    m_UserMap.Remove(Item.Key)
                    Exit For
                End If
            Next

            m_UserMap.Add(user.Username, user)
            m_ListUser.Add(user.Username)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return user
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' UpdateUser from UserSetupLib.UpdateUser
    ''' </summary>
    ''' <param name="user"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UpdateUser(ByVal user As DBUser) As DBUser
        Try
            ContainerDAO.UpdateUser(user)
            For Each Item As DictionaryEntry In m_UserMap
                If String.Compare(Item.Key, user.Username, True) = 0 Then ' InCase-Sensitive
                    m_UserMap.Remove(Item.Key)
                    Exit For
                End If
            Next
            m_UserMap.Add(user.Username, user)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return user
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Delete User and Get Another User.
    ''' </summary>
    ''' <param name="user"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DeleteUser(ByVal user As DBUser) As DBUser
        Try
            For Each Item As DictionaryEntry In m_UserMap
                If String.Compare(Item.Key, user.Username, True) = 0 Then ' InCase-Sensitive
                    m_UserMap.Remove(Item.Key)
                    Exit For
                End If
            Next

            'For Each lstItem As String In ListUser()
            '    If String.Compare(lstItem, user.Username, True) = 0 Then
            '        ListUser.Remove(lstItem)
            '    End If
            'Next
            For i As Integer = ListUser.Count - 1 To 0 Step -1
                If String.Compare(ListUser.Item(i), user.Username, True) = 0 Then
                    ListUser.Remove(ListUser.Item(i))
                End If
            Next

            ContainerDAO.DeleteUser(user)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return user
    End Function
#End Region

#Region "Chamber"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-10</date>
    ''' </author>
    ''' <summary>
    ''' SaveChamber
    ''' </summary>
    ''' <param name="Chamber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveChamber(ByVal Chamber As DBChamber, ByVal RecipeName As String) As DBChamber
        Try
            Dim FileName As String = Utils.GetFileName(RecipeName, "xml")
            Dim m_Chamber As DBChamber = ContainerDAO.SaveChamber(Chamber, FileName)

            If ChamberMap.Contains(Chamber.ChamberName + "." + FileName) Then
                ChamberMap.Remove(Chamber.ChamberName + "." + FileName)
            End If

            ChamberMap.Add(Chamber.ChamberName + "." + FileName, m_Chamber)

            Dim dbRecipe As DBRecipe = ContainerData.GetRecipe(Chamber.ChamberName)

            If dbRecipe IsNot Nothing AndAlso dbRecipe.ListChamber.Contains(RecipeName) = False Then
                dbRecipe.ListChamber.Add(RecipeName)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Chamber
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-10</date>
    ''' </author>
    ''' <summary>
    ''' Update Chamber
    ''' </summary>
    ''' <param name="Chamber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UpdateChamber(ByVal Chamber As DBChamber) As DBChamber
        Try
            Dim ChamberNameActive As String = Utils.GetFileName(ContainerData.GetRecipe(Chamber.ChamberName).ChamberNameActive, True)
            SaveChamber(Chamber, ChamberNameActive)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Chamber
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Delete Chamber
    ''' </summary>
    ''' <param name="Chamber"></param>
    ''' <param name="ChamberName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DeleteChamber(ByVal Chamber As String, ByVal ChamberName As String) As String
        Try
            ContainerDAO.DeleteChamber(Chamber, ChamberName)
            ''Also Delete file in GEM DATA
            If System.IO.File.Exists(ContainerDAO.FPath_GEMData_Recipe & Utils.chamberID2ChamberName(Chamber) & "." & ChamberName) Then
                Utils.DeleteFile(ContainerDAO.FPath_GEMData_Recipe & Utils.chamberID2ChamberName(Chamber) & "." & ChamberName)
            End If
            Dim Name As String = Utils.GetFileName(ChamberName, True)
            ContainerData.GetRecipe(Chamber).ListChamber.Remove(Utils.GetFileName(ChamberName, True))
            If ContainerData.GetRecipe(Chamber).ListChamber.Count = 0 Then
                Return ""
            End If
            Return Utils.GetFileName(ContainerData.GetRecipe(Chamber).ListChamber.Item(0), "xml")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return ""
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Update Chamber
    ''' </summary>
    ''' <param name="Chamber"></param>
    ''' <param name="ChamberName"></param>
    ''' <remarks></remarks>
    Public Shared Sub UpdateChamber(ByVal Chamber As String, ByVal recipeName As String)
        Try
            ContainerData.GetRecipe(Chamber).ChamberNameActive = recipeName
            ContainerDAO.UpdateChamber(Chamber, recipeName)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Sequence"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-09-01</date>
    ''' </author>
    ''' <summary>
    ''' UpdateWFSequence: Update WF Sequence to FullFileName (filename include .xml)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UpdateWFSequence(ByVal currentDBSeq As AVPLib.DBWaferList, ByVal SequenceName As String, ByVal Description As String) As Boolean
        Dim blnSuccess As Boolean = False
        Try
            If DeleteWFSequence(SequenceName & ".xml") Then
                blnSuccess = SaveWFSequence(currentDBSeq, SequenceName, Description)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blnSuccess
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-09-01</date>
    ''' </author>
    ''' <summary>
    ''' DeleteWFSequence: Delete WF Sequence file
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DeleteWFSequence(ByVal FullFileName As String) As Boolean
        Dim blnSuccess As Boolean = False
        Try
            ContainerDAO.DeleteSequence(FullFileName)
            ''Update GEM DATA
            Utils.DeleteFile(ContainerDAO.FPath_GEMData_Sequence & FullFileName)
            Dim Name As String = FullFileName.Replace(".xml", "")
            If m_ListSequenceName IsNot Nothing AndAlso ContainerData.m_ListSequenceName.Contains(Name) Then
                ContainerData.m_ListSequenceName.Remove(Name)
            End If
            blnSuccess = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blnSuccess
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-09-01</date>
    ''' </author>
    ''' <summary>
    ''' Get DBSequence
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SaveWFSequence(ByVal currentDBSeq As AVPLib.DBWaferList, ByVal SequenceName As String, ByVal Description As String) As Boolean
        AVPLib.Log.guiLogger.Info("Enter SaveWFSequence")
        Dim blnsuccess As Boolean = False
        Try
            Dim FileName As String = ContainerDAO.FPath_SequenceData & "\" & SequenceName & ".xml"
            blnsuccess = ContainerDAO.SaveWFSequence(currentDBSeq, FileName, Description)
            ContainerData.ListSequenceName.Add(SequenceName)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave SaveWFSequence")
        Return blnsuccess
    End Function

    '''    	<name>Tinh Le</name>
    '''    	<date> 2018-11-23</date>
    ''' </author>
    ''' <summary>
    ''' saveCGConfig
    ''' </summary>
    Public Shared Function SaveCGConfig(ByVal ListCGConfig As Hashtable, ByVal NamEquipment As String) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SaveVent")
        Try
            Dim Success As Boolean
            SyncLock m_CGConfigMap.SyncRoot
                Dim tempMap As Hashtable = m_CGConfigMap.Clone()
                'for each and set each item
                For Each item As DictionaryEntry In ListCGConfig
                    tempMap.Item(item.Key) = item.Value
                Next
                Success = ContainerDAO.SaveCGConfig(tempMap)
                If Success Then
                    m_CGConfigMap.Clear()
                    m_CGConfigMap = tempMap
                    Return True
                End If
            End SyncLock
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveVent")
        Return False
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Delete Sequence
    ''' </summary>
    ''' <param name="FileName"></param>
    ''' <remarks></remarks>
    Public Shared Function DeleteSequence(ByVal FileName As String) As String
        Try
            ContainerDAO.DeleteSequence(FileName)
            Dim Name As String = Utils.GetFileName(FileName, True)
            ContainerData.ListSequenceName.Remove(Name)
            If ContainerData.ListSequenceName.Count = 0 Then
                Return ""
            End If
            Return Utils.GetFileName(ContainerData.ListSequenceName.Item(0), "xml")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return ""
    End Function
#End Region
#End Region

#Region "Log Error and Alarm"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' Log Alarm Event
    ''' </summary>
    ''' <param name="Type"></param>
    ''' <param name="Source"></param>
    ''' <param name="Description"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function LogAlarmEvent(ByVal Type As String, ByVal Source As String, ByVal Description As String, Optional ByVal GemAlarmName As String = "") As Integer
        Try
            Dim LogUser As String = "Default"
            If UserLogin IsNot Nothing Then
                LogUser = UserLogin.Username
            End If
            Return ContainerDAO.LogAlarmEvent(LogUser, Type, Source, Description, GemAlarmName)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' Property of DataTable_Log
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DataTable_Log(ByRef LoadDataGrid_Worker As ComponentModel.BackgroundWorker, ByVal filter As String) As DataTable
        Try
            Return ContainerDAO.LoadLogAlarmEvent(LoadDataGrid_Worker, filter)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
#End Region

#Region "Store GUI"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-14</date>
    ''' </author>
    ''' <summary>
    ''' Get Store Gui
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetStoreGui() As DBStoreGui
        Try
            Return ContainerDAO.GetStoreGui()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-14</date>
    ''' </author>
    ''' <summary>
    ''' Save Store Gui
    ''' </summary>
    ''' <param name="StoreGui"></param>
    ''' <remarks></remarks>
    Public Shared Sub SaveStoreGui(ByVal StoreGui As DBStoreGui)
        Try
            ContainerDAO.SaveStoreGui(StoreGui)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub SaveLifeTimeWafer()
        Try
            ContainerDAO.SaveLifeTimeWafer()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub SaveWaferCountForEQ(ByVal EQName As String, ByVal WaferCount As Integer)
        Try
            ContainerDAO.SaveWaferCountForEQ(EQName, WaferCount)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2012-02-27</date>
    ''' </author>
    ''' <summary>
    ''' read from file and increase value by 1
    ''' </summary>
    ''' <param name="StoreGui"></param>
    ''' <remarks></remarks>
    Public Shared Sub IncreaseTotalWaferCount()
        Try
            ContainerDAO.IncreaseTotalWaferCount()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "State Machine"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get Transition State 
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Function GetTransitionState(ByVal ProcessJobDoc As XmlDocument) As List(Of AVPStateMachineData)
        Dim ListOfTransition As New List(Of AVPStateMachineData)
        Try
            Dim root As System.Xml.XmlNode = ProcessJobDoc.FirstChild
            Dim nodeListTransition As System.Xml.XmlNodeList = root.ChildNodes

            For i As Integer = 0 To nodeListTransition.Count - 1
                Try
                    Dim nodeTransition As System.Xml.XmlNode = nodeListTransition.Item(i)
                    If nodeTransition.Name.Contains("Transition") Then
                        Dim transState As New AVPStateMachineData
                        transState.TxtNo = nodeTransition.Attributes.ItemOf("txNo").Value
                        transState.SourceState = nodeTransition.Attributes.ItemOf("src").Value
                        transState.DestState = nodeTransition.Attributes.ItemOf("dst").Value
                        If nodeTransition.Attributes.ItemOf("triggerid") IsNot Nothing Then
                            transState.TriggerID = nodeTransition.Attributes.ItemOf("triggerid").Value
                        Else
                            transState.TriggerID = String.Empty
                        End If
                        ListOfTransition.Add(transState)
                    End If
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return ListOfTransition
    End Function

#End Region
End Class