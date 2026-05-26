Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Imports AVPLib.ConstEnum
Public Class ContainerForm
#Region "Class Constants & Variables"
    Private Shared m_HandleForm As ArrayList
    Private Shared m_UserSetup As UserSetup
    Private Shared m_SystemSetup As SystemSetup
    Private Shared m_AlarmAndEvent As AlarmAndEvent
    Private Shared m_WaferRun As WaferRun
    Private Shared m_SLWaferRun As WaferRun
    Private Shared m_AlarmStatisticCtrl As AlarmStatisticControl
    Private Shared m_LotDatalog As LotDatalog
    Private Shared m_RecipeEditor As RecipeEditor
    Private Shared m_Sequence As Sequence
    Private Shared m_usrWaferFlow As usrWaferFlow
    Private Shared m_usrEquipmentWaferFlow As usrEquipmentName
    Private Shared m_ProcessPanel As ProcessPanel
    Private Shared m_SLPopUpPanel As SL_PopUpPanel
    
    Private Shared m_SLUserSetup As SL_UserSetup
    Private Shared m_CassettesPanel As CassettesPanel
    Private Shared m_Chamber1Panel As ChamberPanel = Nothing
    Private Shared m_Chamber2Panel As ChamberPanel = Nothing
    Private Shared m_Chamber3Panel As ChamberPanel = Nothing

    Private Shared m_Aligner As usrAligner
    Private Shared m_PanelCurrent As UserControl = Nothing
    Private Shared m_TroubleShootPanel As TroubleShootPanel
    Private Shared m_dlgDiagnostic As DiagnosticDialog

    Private Shared m_blnChamber1Visible As Boolean = False
    Private Shared m_blnChamber2Visible As Boolean = False
    Private Shared m_blnChamber3Visible As Boolean = False

    Private Shared m_SecsGemPanel As SecsGemPanel = Nothing
    Private Shared m_CycleATM As CycleATMScreen
#End Region

#Region "Properties"
#If AVP_PLATFORM = "CX" Then
    ' Private Shared m_Chamber1DetailsControl As Chamber1DetailsControl
    '  Private Shared m_Chamber3DetailsControl As Chamber3DetailsControl

    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-05-26</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of Chamber1DetailsControl
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Shared ReadOnly Property Chamber1Details() As Chamber1DetailsControl
    '    Get
    '        If m_Chamber1DetailsControl Is Nothing Then
    '            m_Chamber1DetailsControl = New Chamber1DetailsControl()
    '            m_Chamber1DetailsControl.Name = "Chamber1DetailsControl"
    '            m_Chamber1DetailsControl.Dock = DockStyle.Fill
    '        End If
    '        Return m_Chamber1DetailsControl
    '    End Get
    'End Property
    '''' <author>
    ''''    	<name> Tran Ngoc Khiet </name>
    ''''    	<date> 2009-05-26</date>
    '''' </author>
    '''' <summary>
    '''' Get an instance of Chamber3DetailsControl
    '''' </summary>
    '''' <value></value>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Shared ReadOnly Property Chamber3Details() As Chamber3DetailsControl
    '    Get
    '        If m_Chamber3DetailsControl Is Nothing Then
    '            m_Chamber3DetailsControl = New Chamber3DetailsControl()
    '            m_Chamber3DetailsControl.Name = "Chamber3DetailsControl"
    '            m_Chamber3DetailsControl.Dock = DockStyle.Fill
    '        End If
    '        Return m_Chamber3DetailsControl
    '    End Get
    'End Property
#End If
    Public Shared ReadOnly Property PanelCurrent() As UserControl
        Get
            Return m_PanelCurrent
        End Get
    End Property

    Public Shared Property Chamber1Visible() As Boolean
        Get
            Return m_blnChamber1Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamber1Visible = value
        End Set
    End Property
    Public Shared Property Chamber2Visible() As Boolean
        Get
            Return m_blnChamber2Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamber2Visible = value
        End Set
    End Property
    Public Shared Property Chamber3Visible() As Boolean
        Get
            Return m_blnChamber3Visible
        End Get
        Set(ByVal value As Boolean)
            m_blnChamber3Visible = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance System Setup
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property Secs_GemPanel() As SecsGemPanel
        Get
            If m_SecsGemPanel Is Nothing Then
                m_SecsGemPanel = New SecsGemPanel()
                m_SecsGemPanel.Dock = DockStyle.Fill
            End If
            Return m_SecsGemPanel
        End Get
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance System Setup
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property Diagnostic() As DiagnosticDialog
        Get
            If m_dlgDiagnostic Is Nothing Then
                m_dlgDiagnostic = New DiagnosticDialog()
                m_dlgDiagnostic.Dock = DockStyle.Fill
            End If
            Return m_dlgDiagnostic
        End Get
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-02-10</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance System Setup
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property TroubleShootPanel() As TroubleShootPanel
        Get
            If m_TroubleShootPanel Is Nothing Then
                m_TroubleShootPanel = New TroubleShootPanel()
                m_TroubleShootPanel.Dock = DockStyle.Fill
            End If
            Return m_TroubleShootPanel
        End Get
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-12-08</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance System Setup
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property SystemSetup() As SystemSetup
        Get
            If m_SystemSetup Is Nothing Then
                m_SystemSetup = New SystemSetup()
                m_SystemSetup.Dock = DockStyle.Fill
            End If
            Return m_SystemSetup
        End Get
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' get Property of UserSetup
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property UserSetup() As UserSetup
        Get
            If m_UserSetup Is Nothing Then
                m_UserSetup = New UserSetup()
                m_UserSetup.Dock = DockStyle.Fill
            End If
            Return m_UserSetup
        End Get
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' get Property of AlarmAndEvent
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property AlarmAndEvent() As AlarmAndEvent
        Get
            If m_AlarmAndEvent Is Nothing Then
                m_AlarmAndEvent = New AlarmAndEvent()
                m_AlarmAndEvent.Dock = DockStyle.Fill
            End If
            Return m_AlarmAndEvent
        End Get
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' get Property of AlarmAndEvent
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property WaferRun() As WaferRun
        Get
            If m_WaferRun Is Nothing Then
                m_WaferRun = New WaferRun()
                m_WaferRun.Dock = DockStyle.Fill
            End If
            Return m_WaferRun
        End Get
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' get Property of AlarmAndEvent
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property AlarmStatisticCtrl() As AlarmStatisticControl
        Get
            If m_AlarmStatisticCtrl Is Nothing Then
                m_AlarmStatisticCtrl = New AlarmStatisticControl()
                m_AlarmStatisticCtrl.Dock = DockStyle.Fill
            End If
            Return m_AlarmStatisticCtrl
        End Get
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' get Property of AlarmAndEvent
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property Lotdatalog() As LotDatalog
        Get
            If m_LotDatalog Is Nothing Then
                m_LotDatalog = New LotDatalog()
                m_LotDatalog.Dock = DockStyle.Fill
            End If
            Return m_LotDatalog
        End Get
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' get Property of AlarmAndEvent
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property SL_WaferRun() As WaferRun
        Get
            If m_SLWaferRun Is Nothing Then
                m_SLWaferRun = New SL_WaferRun()
                m_SLWaferRun.Dock = DockStyle.Fill
            End If
            Return m_SLWaferRun
        End Get
    End Property

    '''<Author>
    '''   	<Name> Cao Anh Kiet </Name>
    '''</Author>
    ''' <summary>
    ''' get Property of Chamber of Recipe Editor
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property RecipeEditor() As RecipeEditor
        Get
            If m_RecipeEditor Is Nothing Then
                m_RecipeEditor = New RecipeEditor()
                m_RecipeEditor.Dock = DockStyle.Fill
            End If
            Return m_RecipeEditor
        End Get
    End Property

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' get Property of Sequence Editor
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property Sequence() As Sequence
        Get
            If m_Sequence Is Nothing Then
                m_Sequence = New Sequence()
                m_Sequence.Dock = DockStyle.Fill
            End If
            Return m_Sequence
        End Get
    End Property
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-06</date>
    ''' </author>
    ''' <summary>
    ''' get Property of Wafer Flow Editor
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property WaferFlow() As usrWaferFlow
        Get
            If m_usrWaferFlow Is Nothing Then
                m_usrWaferFlow = New usrWaferFlow()
                m_usrWaferFlow.Dock = DockStyle.Fill
            End If
            Return m_usrWaferFlow
        End Get
    End Property
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-06</date>
    ''' </author>
    ''' <summary>
    ''' get Property of Equipment's name Wafer Flow Editor
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property EquipmentWaferFlow() As usrEquipmentName
        Get
            If m_usrEquipmentWaferFlow Is Nothing Then
                m_usrEquipmentWaferFlow = New usrEquipmentName()
                m_usrEquipmentWaferFlow.Dock = DockStyle.Fill
            End If
            Return m_usrEquipmentWaferFlow
        End Get
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Property of ArrayList Handle form
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property ArrayHandleForm() As ArrayList
        Get
            If m_HandleForm Is Nothing Then
                m_HandleForm = New ArrayList()
            End If
            Return m_HandleForm
        End Get
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Handle form to back form
    ''' </summary>
    ''' <param name="userControl"></param>
    ''' <remarks></remarks>
    Public Shared Sub HandleForm(ByVal userControl As UserControl)
        Try
            If m_PanelCurrent Is Nothing Then
                m_PanelCurrent = userControl
                ArrayHandleForm.Add(userControl)
            ElseIf m_PanelCurrent.Name <> userControl.Name Then
                m_PanelCurrent = userControl
                ArrayHandleForm.Add(userControl)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Back Form
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function BackForm() As UserControl
        Try
            Dim ucShowing As UserControl = ArrayHandleForm(m_HandleForm.Count - 1)
            ArrayHandleForm.Remove(ucShowing) 'Remove UCShowing
            Dim ucBack As UserControl = ArrayHandleForm.Item(ArrayHandleForm.Count - 1)
            m_PanelCurrent = ucBack
            Return ucBack
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of ProcessPanel
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property ProcessPanel() As ProcessPanel
        Get
            If m_ProcessPanel Is Nothing Then
#If AVP_PLATFORM = "CX" Then
                m_ProcessPanel = New ProcessPanel()
                m_ProcessPanel.Dock = DockStyle.Fill
#End If
            End If
            Return m_ProcessPanel
        End Get
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-27</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of CassettesPanel
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property CassettesPanel() As CassettesPanel
        Get
            If m_CassettesPanel Is Nothing Then
#If AVP_PLATFORM = "CX" Then
                m_CassettesPanel = New CassettesPanel()
                m_CassettesPanel.Dock = DockStyle.Fill
#End If
            End If
            Return m_CassettesPanel
        End Get
    End Property
    Public Shared ReadOnly Property Chamber1Panel() As ChamberPanel
        Get
            If m_Chamber1Panel IsNot Nothing Then
                Return m_Chamber1Panel
            End If
            Return Nothing
        End Get
    End Property
    Public Shared ReadOnly Property Chamber2Panel() As ChamberPanel
        Get
            If m_Chamber2Panel IsNot Nothing Then
                Return m_Chamber2Panel
            End If
            Return Nothing
        End Get
    End Property
    Public Shared ReadOnly Property Chamber3Panel() As ChamberPanel
        Get
            If m_Chamber3Panel IsNot Nothing Then
                Return m_Chamber3Panel
            End If
            Return Nothing
        End Get
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2009-12-29</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of each ChamberPanel
    ''' </summary>
    '''parammeter: objChamber: ChamberPanel
    '''            ChamberName: Chamber1, Chamber2...
    '''            ChamberType: DCPVD, RFPVD or IBE
    '''Return : ChamberPanel
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>    
    Public Shared Function GetChamberPanel(ByVal objChamber As ChamberPanel, ByVal ChamberName As Object, ByVal Chamber As AVPLib.SystemModule) As ChamberPanel
        Try
            Dim strTitle As String = CType(AVPLib.ContainerData.GetRobotConfig(CStr(ChamberName)), AVPLib.SystemModule).Name
            Select Case Chamber.Type
                ''IBE
                Case AVPLib.SystemModule.ModuleType.IBE
                    If objChamber Is Nothing Then
                        objChamber = New IBEPanel(ChamberName, Chamber.IBE_Type, Chamber.CryoVisible, Chamber.WaterPumpVisible, Chamber.IGFilamentVisible) 'Chamber1Panel()
                        objChamber.ChamberType = AVPLib.SystemModule.ModuleType.IBE
                    End If
                    ''PVD
                Case AVPLib.SystemModule.ModuleType.PVD
                    If objChamber Is Nothing AndAlso Chamber.DCTargetPowerVisible Then
                        objChamber = New Chamber1DCPVDPanel(ChamberName)
                        objChamber.ChamberType = AVPLib.SystemModule.ModuleType.PVD
                    ElseIf objChamber Is Nothing AndAlso Chamber.RFTargetPowerVisible Then
                        objChamber = New Chamber1RFPVDPanel(ChamberName)
                        objChamber.ChamberType = AVPLib.SystemModule.ModuleType.PVD
                    ElseIf objChamber Is Nothing Then
                        objChamber = New PVDPanel(ChamberName)
                        objChamber.ChamberType = AVPLib.SystemModule.ModuleType.PVD
                    End If
                    ''PVD4
                Case AVPLib.SystemModule.ModuleType.PVD4
                    If objChamber Is Nothing Then
                        objChamber = New CoronaPanel(ChamberName, Chamber.Type, Chamber.CryoVisible, Chamber.WaterPumpVisible) 'Chamber1Panel()
                        objChamber.ChamberType = AVPLib.SystemModule.ModuleType.PVD4
                    End If
                    ''PVD5T
                Case SystemModule.ModuleType.PVD5T
                    If objChamber Is Nothing Then
                        objChamber = New PVD5TPanel(ChamberName, Chamber.Type, Chamber.CryoVisible, Chamber.WaterPumpVisible) 'Chamber1Panel()
                        objChamber.ChamberType = AVPLib.SystemModule.ModuleType.PVD5T
                    End If
            End Select
            objChamber.Dock = DockStyle.Fill
            Select Case ChamberName
                Case AVPLib.ConstEnum.Equipments.Chamber1.ToString()
                    m_Chamber1Panel = objChamber
                Case AVPLib.ConstEnum.Equipments.Chamber2.ToString()
                    m_Chamber2Panel = objChamber
                Case AVPLib.ConstEnum.Equipments.Chamber3.ToString()
                    m_Chamber3Panel = objChamber
            End Select

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return objChamber
    End Function
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-09-09</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of ChamberPanel
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property ChamberPanel(ByVal strPannelName As String) As ChamberPanel
        Get
            Select Case strPannelName
                Case Equipments.Chamber1.ToString()
                    Return m_Chamber1Panel
                Case Equipments.Chamber2.ToString()
                    Return m_Chamber2Panel
                Case Equipments.Chamber3.ToString()
                    Return m_Chamber3Panel
            End Select
            Return Nothing
        End Get
    End Property
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-09-09</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of IGCGControl
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property IGCGControlChamber(ByVal strPanelName As String, ByVal strChamberName As String) As IGCGControl
        Get
            Select Case strPanelName
                Case CASSETTESPANEL_STR
                    Dim CassettesPanel As CassettesPanel = ContainerForm.CassettesPanel()
                    Select Case strChamberName
                        Case IGCGCHAMBER1_STR
                            Return CassettesPanel.IgcgChamber1
                        Case IGCGCHAMBER2_STR
                            Return CassettesPanel.IgcgChamber2
                        Case IGCGCHAMBER3_STR
                            Return CassettesPanel.IgcgChamber3
#If AVP_CX_STYLE = "CX4" Then
                            AVPLib.Log.avpLogger.Error("Missing IGCG Comtrol Chamber For CX4")

#End If

                    End Select
            End Select
            Return Nothing
        End Get
    End Property
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-09-09</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of ChamberControl base on IGCG Control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property GetChamberControl(ByVal strPanelName As String) As ChamberControl
        Get
            Select Case strPanelName
                Case IGCGCHAMBER1_STR
                    Return ProcessPanel.cbcChamber1
                Case IGCGCHAMBER2_STR
                    Return ProcessPanel.cbcChamber2
                Case IGCGCHAMBER3_STR
                    Return (ProcessPanel.cbcChamber3)
            End Select
            Return Nothing
        End Get
    End Property

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-10-05</date>
    ''' </author>
    ''' <summary>
    ''' Get an instance of CycelATM
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property CycleATM() As CycleATMScreen
        Get
            If m_CycleATM Is Nothing Then
                m_CycleATM = New CycleATMScreen()
                m_CycleATM.Dock = DockStyle.Fill
            End If
            Return m_CycleATM
        End Get
    End Property

#End Region
End Class