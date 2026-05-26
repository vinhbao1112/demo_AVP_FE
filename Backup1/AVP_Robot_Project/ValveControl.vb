Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum

Public Class ValveControl
    Protected m_bUseClickedEventInForm As Boolean = True
    Public m_bUsingScientificFormat As Boolean = True
    Private m_strUnit As String = String.Empty
    Private m_TypeOfChamberSupport As TypeOfAVPChamber = TypeOfAVPChamber.IBE
    Private m_IsCheckSafetyBeforeClick As Boolean = False
    Private m_SafetyValveType As SafetyInterlockValve = SafetyInterlockValve.None
    Private m_IsCheckSafetyIsolationValveBeforeClick As Boolean = False
    Enum SafetyInterlockValve
        VentValve
        RoughValve
        ForelineValve
        FlowCool
        None
    End Enum


#Region "Constructor & Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' Create defaulf valve
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.LoadDefaultValvePicture()
    End Sub
    Public Event TextChange(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Overrides Property TextValue() As String
        Get
            Return m_strText
        End Get
        Set(ByVal value As String)
            If m_strText <> value Then
                m_strText = value
                RaiseEvent TextChange(Me, Nothing)
            End If
        End Set
    End Property
#End Region

#Region "Properties"
    Public Property IsCheckSafetyBeforeClick() As Boolean
        Get
            Return m_IsCheckSafetyBeforeClick
        End Get
        Set(ByVal value As Boolean)
            m_IsCheckSafetyBeforeClick = value
        End Set
    End Property

    Public Property IsCheckSafetyIsolationValveBeforeClick() As Boolean
        Get
            Return m_IsCheckSafetyIsolationValveBeforeClick
        End Get
        Set(ByVal value As Boolean)
            m_IsCheckSafetyIsolationValveBeforeClick = value
        End Set
    End Property

    Public Property SafetyValveType() As SafetyInterlockValve
        Get
            Return m_SafetyValveType
        End Get
        Set(ByVal value As SafetyInterlockValve)
            m_SafetyValveType = value
        End Set
    End Property

    Public Property UseClickedEventInForm() As Boolean
        Get
            Return m_bUseClickedEventInForm
        End Get
        Set(ByVal value As Boolean)
            m_bUseClickedEventInForm = value
        End Set
    End Property

    Public Property UsingScientificFormat() As Boolean
        Get
            Return m_bUsingScientificFormat
        End Get
        Set(ByVal value As Boolean)
            m_bUsingScientificFormat = value
        End Set
    End Property

    Public Property Unit() As String
        Get
            Return m_strUnit
        End Get
        Set(ByVal value As String)
            m_strUnit = value
        End Set
    End Property
#End Region

#Region "Private Methods"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-29</date>
    ''' </author>
    ''' <summary>
    ''' Load valve picture
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadDefaultValvePicture()
        Try
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ValveControl))
            MyBase.OnImage = CType(resources.GetObject("GreenValve"), Image)
            MyBase.OffImage = CType(resources.GetObject("RedValve"), Image)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub ValveControl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Try
            If UseClickedEventInForm = True Then
                Exit Sub
            End If

            If IsCheckSafetyBeforeClick Then
                If Not CheckSafetyValveBeforeClick(Me.Status) Then
                    Exit Sub
                End If
            End If

            Dim Source As String = String.Empty
            Dim strMessageText As String = String.Empty
            Source = TypeOfChamberSupport.ToString() & "." & Me.Name & "." & Me.Status.ToString()
            strMessageText = AVPLib.ContainerData.GetMessageText(Source)

            If strMessageText Is Nothing Then
                Source = TypeOfChamberSupport.ToString() & ".ValveClick." & Me.Status.ToString()
                strMessageText = AVPLib.ContainerData.GetMessageText(Source)
            End If

            ''this will return : Would you like to Open/Close...{0}?
            If Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD4 OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD5T Then
                strMessageText = String.Format(strMessageText, AccessibleDescription)
            Else
                strMessageText = String.Format(strMessageText, AccessibleName)
            End If
            Dim strChamber As String = String.Empty
            If Me.Parent IsNot Nothing Then
                strChamber = AVPLib.Utils.chamberID2ChamberName(ParentStatusObj.Name)
                If String.IsNullOrEmpty(strChamber) OrElse Not ParentStatusObj.Name.StartsWith(AVPLib.ConstEnum.Chamber) Then
                    strChamber = AVPLib.Utils.chamberID2ChamberName(ParentStatusObj.Parent.Name)
                End If
                If ParentStatusObj.Parent.Name IsNot Nothing AndAlso (String.IsNullOrEmpty(strChamber) OrElse Not ParentStatusObj.Parent.Name.StartsWith(AVPLib.ConstEnum.Chamber)) Then
                    strChamber = AVPLib.Utils.chamberID2ChamberName(ParentStatusObj.Parent.Parent.Name)
                End If
            End If

            If Utils.ShowAVPMessageBoxWithYesNoConfirm(strMessageText, strChamber, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                Utils.LogUserEvent(Me)

                'Send to Back End
                If Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD4 OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD5T Then
                    ParentStatusObj.RequestStatus(IIf(Me.AccessibleName <> String.Empty, Me.AccessibleName, Me.Name), IIf(Me.Status = DisplayStatus.On, STR_OFF, STR_ON))
                Else
                    ParentStatusObj.RequestStatus(Name, IIf(Me.Status = DisplayStatus.On, STR_OFF, STR_ON))
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    'show popup and return 
    'ValveStatus=off ->check (user want to open Valve)
    Private Function CheckSafetyValveBeforeClick(ByVal ValveStatus As DisplayStatus) As Boolean
        Try
            Dim objPanel As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
            Dim objChamber As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Name)
            If objPanel Is Nothing OrElse objChamber Is Nothing Then
                Return False
            End If
            
            If objPanel.IsProtectedMode OrElse ValveStatus = DisplayStatus.On Then
                Return True
            End If
            Dim objTransferModule As AVPLib.DataManagerment.CassettesModule = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.CassettesModule.ToString()) 'for CX
            Dim strCheckResult As String = String.Empty
            If m_IsCheckSafetyIsolationValveBeforeClick Then
                strCheckResult = objTransferModule.Check_PMx_IsolationValve(Me.Parent.Name, True)
            End If
            'check Isolation Valve
            If Not String.IsNullOrEmpty(strCheckResult) Then
                Utils.ShowAVPMessageBox(strCheckResult, STR_AVP, MessageBoxIcon.Exclamation, AVPMessageBox.AVPMessageBoxButton.OK)
                Return False
            End If
           
            Select Case SafetyValveType
                Case SafetyInterlockValve.FlowCool
                    'Check Clamp Up/Down
                    Dim strErrMessage = "Can Not Open " & Me.AccessibleName & ". "
                    If Not objChamber.ClampStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.On Then
                        strCheckResult = strErrMessage & AVPLib.ContainerData.GetMessageText("FIXTURE_CLAMP_IS_NOT_UP")
                        Utils.ShowAVPMessageBox(strCheckResult, Me.Name, MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                        Return False
                    ElseIf Not objChamber.WaferInside = AVPLib.DataManagerment.Equipment.WorkingStatuses.On Then
                        strCheckResult = strErrMessage & String.Format(AVPLib.ContainerData.GetMessageText( _
                             "NO_WAFER_IN_PM"), AVPLib.Utils.chamberID2ChamberName(objChamber.Name))
                        Utils.ShowAVPMessageBox(strCheckResult, Me.Name, MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                        Return False
            End If
                Case SafetyInterlockValve.RoughValve
                    'check Vent
                        If objChamber.VentValveStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.On Then
                            strCheckResult = AVPLib.ContainerData.GetMessageText("VentValveIsNotClosed")
                            Utils.ShowAVPMessageBox(strCheckResult, Me.Name, MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                            Return False
                        End If
                    'check share Rough Pump
                    If TypeOfChamberSupport = TypeOfAVPChamber.PVD OrElse _
                       TypeOfChamberSupport = TypeOfAVPChamber.PVDA OrElse _
                       TypeOfChamberSupport = TypeOfAVPChamber.PVD2R4 Then
                        Dim strResult = String.Empty
                        'if Rough Pump1 is in used
                        If Not (objTransferModule.RoughPumpMachine1InUse = String.Empty) Then
                            Dim strPMName As String = AVPLib.Utils.chamberID2ChamberName(objTransferModule.RoughPumpMachine1InUse)
                            strResult = STR_ROUGH_PUMP_IN_USE & strPMName
                            Utils.ShowAVPMessageBox(strResult, strPMName, MessageBoxIcon.Warning, MessageBoxButtons.OK)
                            Exit Function
                        End If
                        'if Rough Pump2 is in used
                        If Not (objTransferModule.RoughPumpMachine2InUse = String.Empty) Then
                            Dim strPMName As String = AVPLib.Utils.chamberID2ChamberName(objTransferModule.RoughPumpMachine2InUse)
                            strResult = STR_ROUGH_PUMP_IN_USE & strPMName
                            Utils.ShowAVPMessageBox(strResult, strPMName, MessageBoxIcon.Warning, MessageBoxButtons.OK)
                            Exit Function
                        End If
                    End If

                Case SafetyInterlockValve.VentValve
                    'Check Rough 
                    If objChamber.RoughValveStatus = BinaryStatusControl.DisplayStatus.On Then
                        strCheckResult = AVPLib.ContainerData.GetMessageText("RoughValveIsNotClosed")
                        Utils.ShowAVPMessageBox(strCheckResult, Me.Name, MessageBoxIcon.Exclamation, MessageBoxButtons.OK)
                        Return False
                    End If
            End Select
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function
#End Region
End Class
