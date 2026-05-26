Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Public Class StatusCoronaBinaryControl
    Inherits AVPControls.StatusObject
#Region "Class Constants & Variables"
    Private m_bscBinaryStatusControl As BinaryStatusControl
#End Region

    ' This event raised when its status changes.
    Public Event StatusChangedEvent As AVPLib.DataManagerment.Equipment.StatusChangedEventHandler

#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the binary status control that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedBinaryStatusControl() As BinaryStatusControl
        Get
            Return m_bscBinaryStatusControl
        End Get
        Set(ByVal value As BinaryStatusControl)
            m_bscBinaryStatusControl = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with binary status control that will be managed by this object
    ''' </summary>
    ''' <param name="bscBinaryStatusControl"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal bscBinaryStatusControl As BinaryStatusControl)
        Try
            m_bscBinaryStatusControl = bscBinaryStatusControl
            Me.Name = m_bscBinaryStatusControl.Name
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
            If (Value = "Other") Then ' Invalid value.
                Return
            End If
            If Me.Name = "MechanicalPump" AndAlso IsNumeric(Value) Then
                Dim objPanel As ChamberPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                If objPanel.chamberType = AVPLib.SystemModule.ModuleType.PVD5T Then
                    Dim objPVD5TPanel As PVD5TPanel = CType(objPanel, PVD5TPanel)
                    If Value = "-1.0E+00" Then
                        objPVD5TPanel.txtMPPressure.Text = "Error"
                        objPVD5TPanel.txtMPPressure.ForeColor = Color.Red
                    Else
                        Dim dblIg As Double = 0
                        Double.TryParse(Value, dblIg)
                        objPVD5TPanel.txtMPPressure.Text = Format(dblIg, AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                        objPVD5TPanel.txtMPPressure.ForeColor = Color.Lime
                    End If
                Else
                    Dim objcoronaPanel As CoronaPanel = CType(objPanel, CoronaPanel)
                    If Value = "-1.0E+00" Then
                        objcoronaPanel.txtMPPressure.Text = "Error"
                        objcoronaPanel.txtMPPressure.ForeColor = Color.Red
                    Else
                        objcoronaPanel.txtMPPressure.Text = Value
                        objcoronaPanel.txtMPPressure.ForeColor = Color.Lime
                    End If
                End If

                Exit Sub
            ElseIf Me.Name = "RoughPumpControl" AndAlso IsNumeric(Value) Then
                'If CDbl(Value) <= AVPLib.ContainerData.GetPressureConfig("RoughPump_Max_Value") Then
                '    m_bscBinaryStatusControl.Status = BinaryStatusControl.DisplayStatus.On
                'Else
                '    m_bscBinaryStatusControl.Status = BinaryStatusControl.DisplayStatus.Off
                'End If
                ContainerForm.CassettesPanel.RoughPumpControl.TextValue = Value
                Exit Sub
            End If
            Dim enmStatus As BinaryStatusControl.DisplayStatus = CType([Enum].Parse(GetType(BinaryStatusControl.DisplayStatus), Value), BinaryStatusControl.DisplayStatus)
            If enmStatus <> m_bscBinaryStatusControl.Status Then
                m_bscBinaryStatusControl.Status = enmStatus
            End If

            ' Raise changed status event.
            Dim statusChangedEvent As StatusChangedEventArgs = New StatusChangedEventArgs()
            statusChangedEvent.Message = Value
            RaiseEvent StatusChangedEvent(m_bscBinaryStatusControl, statusChangedEvent)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-05</date>
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
    '''     	<date> 2008-09-05</date>
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
