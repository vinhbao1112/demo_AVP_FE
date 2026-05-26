Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPControls

Public Class StatusWaferAlignerControl
    Inherits AVPControls.StatusObject
#Region "Class Constants & Variables"
    Private m_bscBinaryStatusControl As AVPAlignerControl
#End Region

    ' This event raised when its status changes.
    Public Event StatusChangedEvent As AVPLib.DataManagerment.Equipment.StatusChangedEventHandler

#Region "Properties"
    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-11-16 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set the binary status control that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedBinaryStatusControl() As AVPAlignerControl
        Get
            Return m_bscBinaryStatusControl
        End Get
        Set(ByVal value As AVPAlignerControl)
            m_bscBinaryStatusControl = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-11-16 </date>
    ''' </author>
    ''' <summary>
    ''' Initalize with binary status control that will be managed by this object
    ''' </summary>
    ''' <param name="bscBinaryStatusControl"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal bscBinaryStatusControl As AVPAlignerControl)
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
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-11-16 </date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object and update UI
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub UpdateUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            If (Value = "Other") Or (Value = "Unknown") Then ' Invalid value.
                Return
            End If
            'new format of value = On A01 Completed
            Dim enmStatus As DisplayStatus = DisplayStatus.Off
            If Value.StartsWith(STR_ON) Then
                Value = STR_ON
            ElseIf Value.StartsWith(STR_OFF) Then
                Value = STR_OFF
            Else
                AVPLib.Log.avpLogger.Error("Error with: " & Me.Name & " - value:" & arg.ToString())
                Exit Sub
            End If
            '''
            enmStatus = CType([Enum].Parse(GetType(DisplayStatus), Value), DisplayStatus)
            If enmStatus <> m_bscBinaryStatusControl.Status Then
                m_bscBinaryStatusControl.Status = enmStatus
            End If

            If enmStatus = DisplayStatus.On Then
                Dim isShowQM As Boolean
                Dim cb As AVPLib.DataManagerment.Aligner = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Aligner.ToString())
                If cb IsNot Nothing Then
                    Dim waferInfo As AVPLib.AVPWaferInfo = cb.GetWaferInfo
                    If waferInfo IsNot Nothing AndAlso Utils.Check_WaferID_Has_PausedJob(waferInfo.WaferID) AndAlso Not (Me.Parent.Name = CASSETTESPANEL_STR) Then
                        isShowQM = True
                    End If
                    m_bscBinaryStatusControl.SetWaferInfo(waferInfo.WaferID, waferInfo.WaferStatus, isShowQM)
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("Error with: " & Me.Name & " - value:" & arg.ToString() & " - " & ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-11-16 </date>
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
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-11-16 </date>
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
