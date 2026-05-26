Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment

Public Class StatusLabel
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_lblLabel As Label
#End Region


#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the label that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedLabel() As Label
        Get
            Return m_lblLabel
        End Get
        Set(ByVal value As Label)
            m_lblLabel = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with label that will be managed by this object
    ''' </summary>
    ''' <param name="lblManagedLabel"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal lblManagedLabel As Label)
        Try
            m_lblLabel = lblManagedLabel
            Me.Name = m_lblLabel.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Dat Do </name>
    '''     <date> 2009-04-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object and update UI
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            If Me.Name = "lblRoughPumpInUse" Or Me.Name = "lblRoughPumpInUse_2" Then
                If Not String.IsNullOrEmpty(Value) Then
                    Dim strEquipment As String = Value
                    Dim txtCryo As String = String.Empty
                    Dim strRegex As String = "(\w+)\s(\w+)"

                    If Regex.IsMatch(Value, strRegex) Then
                        Dim mtcMatch As Match = Regex.Match(Value, strRegex)
                        strEquipment = mtcMatch.Groups(1).Value
                        txtCryo = " " & mtcMatch.Groups(2).Value
                    End If
                    Dim EQName As String = AVPLib.Utils.ConvertEQName_ToShortName(strEquipment)
                    m_lblLabel.Text = STR_ROUGH_PUMP_IN_USE & EQName & txtCryo
                    m_lblLabel.Tag = strEquipment
                Else
                    m_lblLabel.Text = String.Empty
                    m_lblLabel.Tag = Nothing
                End If

                If AVPLib.RobotConfigurationValues.SHARED_MP_WITH_PM Then
                    Dim intMaxOfPM As Integer = 3 'default for CX4
                    Dim objRoughPump As RoughPumpMachine =
                        CType(EquipmentManager.GetRoughPumpMachine(Equipments.CassettesModule.ToString()), RoughPumpMachine)
                    If objRoughPump Is Nothing Then
                        AVPLib.Log.avpLogger.Error("Can't get RoughPumpMachine")
                        Return
                    End If

                    For i As Integer = 1 To intMaxOfPM
                        Dim objModule As SystemModule = Nothing
                        Dim strName As String = ConstEnum.Chamber & i.ToString()
                        Dim objPanel As ChamberPanel = ContainerForm.ChamberPanel(strName)

                        If objRoughPump.IsUsed(strName) AndAlso objPanel IsNot Nothing AndAlso
                            objPanel.ChamberType = SystemModule.ModuleType.PVD5T Then

                            Dim objPVD5TPanel As PVD5TPanel = CType(objPanel, PVD5TPanel)
                            If objPVD5TPanel IsNot Nothing Then
                                objPVD5TPanel.lblRoughPumpInUse.Text = m_lblLabel.Text
                            End If
                        End If
                    Next
                End If
            ElseIf Me.Name = "lblAlignerEECA" Then
                m_lblLabel.Text = "Ecc A. = " & Value
                m_lblLabel.Visible = True
            ElseIf Me.Name = "lblAlignerEECM" Then
                m_lblLabel.Text = "Ecc M. = " & Value
                m_lblLabel.Visible = True
            ElseIf Me.Name = "lblCoreMessageBoxText" Then
                Utils.Core_ShowMessageBox(Value)
            ElseIf Me.Name = "lblCurrentPurgeCycle" Then
                If String.IsNullOrEmpty(Value) Then
                    m_lblLabel.Text = Value
                    m_lblLabel.Tag = Value
                Else
                    m_lblLabel.Text = CURRENT_PURGE_CYCLE & Value
                    m_lblLabel.Tag = CURRENT_PURGE_CYCLE & Value
                End If
            ElseIf Me.Name = "lblLoadLockADoor" Then
                Select Case Value
                    Case AVPLib.ConstEnum.STR_ON
                        m_lblLabel.Visible = True
                    Case AVPLib.ConstEnum.STR_OFF
                        m_lblLabel.Visible = False
                End Select
            ElseIf Me.Name = "txtRampingPercent" OrElse Me.Name = "lblturboRampingPercent" OrElse Me.Name = "lblTMturboRampingPercent" Then
                If Value = "Error" Then
                    m_lblLabel.Text = Value
                    m_lblLabel.ForeColor = Color.Red
                Else
                    m_lblLabel.Text = Format(Double.Parse(Value), "0.#") & "%"
                    m_lblLabel.ForeColor = Color.Yellow
                End If
            Else
                m_lblLabel.Text = Value
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-11</date>
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
    ''' <author>
    '''     	<name> Ngo Cao Dinh </name>
    '''     	<date> 2008-09-11</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to request status of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub RequestStatus(ByVal Identification As String, ByVal Value As String)

    End Sub

#End Region

End Class
