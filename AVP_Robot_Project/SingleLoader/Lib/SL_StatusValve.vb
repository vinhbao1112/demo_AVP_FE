Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Imports AVPLib

Public Class SL_StatusValve
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_bigcgButton As SL_ValveControl
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-04</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the IgCgButton that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedIgCgButton() As SL_ValveControl
        Get
            Return m_bigcgButton
        End Get
        Set(ByVal value As SL_ValveControl)
            m_bigcgButton = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-04</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with button igcg control that will be managed by this object
    ''' </summary>
    ''' <param name="bigcgButton"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal bigcgButton As SL_ValveControl)
        Try
            m_bigcgButton = bigcgButton
            Me.Name = m_bigcgButton.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Public Methods"
    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            If Value = STRING_ONLINE Then
                Value = STR_ON
            End If
            If Value = STRING_OFFLINE Then
                Value = STR_OFF
            End If
            Select Case Value
                Case STR_ON
                    If m_bigcgButton.Status <> SL_CustomButton.DisplayStatus.On Then
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.On
                    End If
                Case STR_OFF
                    If m_bigcgButton.Status <> SL_CustomButton.DisplayStatus.Off Then
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Off
                    End If
                Case STR_ERROR
                    If m_bigcgButton.Status <> SL_CustomButton.DisplayStatus.Error Then
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Error
                    End If
                Case SL_CustomButton.DisplayStatus.None.ToString()
                    If m_bigcgButton.Status <> SL_CustomButton.DisplayStatus.None Then
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.None
                    End If
                Case UNKNOWN
                Case STR_OTHER
                    If m_bigcgButton.Status <> SL_CustomButton.DisplayStatus.Unknow Then
                        m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Unknow
                    End If
            End Select
            If Me.Name.Contains("SourcePlasma") Then
                ChangeSourcePlasma(Me.Parent.Parent.Name, IIf(m_bigcgButton.Status = SL_ValveControl.DisplayStatus.On, True, False))
            ElseIf Me.Name.Contains("Shutter") Then
                Dim panelObj As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Parent.Name)
                If panelObj IsNot Nothing AndAlso (panelObj.ChamberType = SystemModule.ModuleType.IBE) Then
                    ChangeShutterStatus(Me.Parent.Parent.Name)
                    Dim objData As IBEChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Parent.Name)
                    CType(panelObj, IBEPanel).SLContainerBox.RotationFixture.IsPositiveDirection = (objData.ShutterDirection = "P")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub ChangeSourcePlasma(ByVal chamberName As String, ByVal blnPlasma_ON_OFF As Boolean)
        Dim objIBE As IBEPanel = ContainerForm.ChamberPanel(chamberName)
        If objIBE Is Nothing Then
            Exit Sub
        End If
        Utils.ChangeTargetPlasmaControlStatus(chamberName, blnPlasma_ON_OFF)
    End Sub

    Private Sub ChangeShutterStatus(ByVal ChamberName As String)
        Dim objIBE As IBEPanel = ContainerForm.ChamberPanel(ChamberName)
        If objIBE Is Nothing Then
            Exit Sub
        End If
        Dim shutterStatus As DataManagerment.Equipment.WorkingStatuses
        Select Case objIBE.SLContainerBox.Shutter.Status
            Case SL_ValveControl.DisplayStatus.On
                shutterStatus = Equipment.WorkingStatuses.On
            Case SL_ValveControl.DisplayStatus.Off
                shutterStatus = Equipment.WorkingStatuses.Off
            Case Else
                shutterStatus = Equipment.WorkingStatuses.Unknown
        End Select
        Utils.ChangeShutterControlStatus(ChamberName, shutterStatus)
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-04</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub

#End Region
End Class
