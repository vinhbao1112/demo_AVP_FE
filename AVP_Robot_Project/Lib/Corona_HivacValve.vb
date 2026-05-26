Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Imports AVPLib

Public Class Corona_HivacValve
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
            With m_bigcgButton
                Select Case Value
                    Case STR_ON
                        If .Status <> SL_CustomButton.DisplayStatus.On Then
                            .Status = DisplayStatus.On
                            '.TextValue = ConstEnum.Open
                            .Refresh()
                        End If
                        Exit Try
                    Case STR_OFF
                        If .Status <> SL_CustomButton.DisplayStatus.Off Then
                            .Status = DisplayStatus.Off
                            '.TextValue = ConstantAndEnum.CLOSED
                            .Refresh()
                        End If
                        Exit Try
                    Case STR_ERROR
                        If .Status <> SL_CustomButton.DisplayStatus.Error Then
                            .Status = DisplayStatus.Error
                            '.TextValue = String.Empty
                            .Refresh()
                        End If
                        Exit Try
                    Case UNKNOWN
                    Case STR_OTHER
                        .Status = DisplayStatus.Unknow
                End Select

                Using objChamber As CoronaChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(Me.Parent.Name)
                    If .Status = DisplayStatus.Unknow Then
                        If objChamber.Vat_Valve_Percentage_Readback = 0 OrElse objChamber.Vat_Valve_Percentage_Readback = 100 Then
                            .UnKnownText = String.Empty
                            .Refresh()
                        ElseIf .UnKnownText <> objChamber.Vat_Valve_Percentage_Readback.ToString() & "%" Then
                            .UnKnownText = objChamber.Vat_Valve_Percentage_Readback.ToString() & "%"
                            .Refresh()
                        End If

                    End If
                End Using
            End With
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
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
