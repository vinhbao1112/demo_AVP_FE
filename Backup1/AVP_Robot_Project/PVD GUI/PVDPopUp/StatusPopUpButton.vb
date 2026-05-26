Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment
Imports AVPLib

Public Class StatusPVD_PopUpButton
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_bigcgButton As SL_CustomButton
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
    Public Property ManagedIgCgButton() As SL_CustomButton
        Get
            Return m_bigcgButton
        End Get
        Set(ByVal value As SL_CustomButton)
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
    Public Sub New(ByVal bigcgButton As SL_CustomButton)
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
            If Value = UCase(ConstantAndEnum.STRING_ONLINE) AndAlso Me.Name = "btnOnline" Then
                Value = STR_ON
            ElseIf (Value = UCase(ConstantAndEnum.STRING_OFFLINE) OrElse _
                     Value = UCase(Equipment.ControlStatuses.MAINTENANCE.ToString())) _
                     AndAlso Me.Name = "btnOnline" Then
                ''''set directly -> don't compare with old status
                m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Off
                Exit Try
            End If
           
            If Value = STR_ON Or Value = STR_OFF Or Value = SL_CustomButton.DisplayStatus.Error.ToString() Or Value = SL_CustomButton.DisplayStatus.Unknow.ToString() Then
                If m_bigcgButton.Status <> [Enum].Parse(GetType(SL_CustomButton.DisplayStatus), Value, True) Then
                    m_bigcgButton.Status = [Enum].Parse(GetType(SL_CustomButton.DisplayStatus), Value, True)
                End If
            ElseIf Me.Name = "btnAutoRegenOn" AndAlso Value = Equipment.WorkingStatuses.Other.ToString() Then
                m_bigcgButton.Status = SL_CustomButton.DisplayStatus.Off
            Else
                AVPLib.Log.avpLogger.Debug("Unhandle message value: " & Value & " from " & Me.Name)
            End If
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

