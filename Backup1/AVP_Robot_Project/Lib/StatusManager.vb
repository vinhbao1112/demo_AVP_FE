Imports System.Collections.Generic
Imports AVP_Robot_Project.ConstantAndEnum
Public Class StatusManager
    Inherits AVPControls.StatusObject

#Region "Public Methods"
    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overloadeds to change satus of an object based on Message
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Sub ChangeStatus(ByVal Message As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Message=" + Message)
        Try
            If (Message.Length > 0) Then
                Dim sIdentification As String
                sIdentification = Message.Substring(0, Message.IndexOf(" "))
                Dim sValue = Message.Substring(Message.IndexOf(" ") + 1, Message.Length - sIdentification.Length - 1)
                If (Not String.IsNullOrEmpty(sValue)) And IsNumeric(sValue) Then ''check value is not 'off' and empty
                    sValue = Utils.ConvertValue(sIdentification, sValue)
                End If
                Me.ChangeStatus(sIdentification, sValue)

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
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
        Try
            If m_htbChildStatusObjects.Count > 0 Then
                MyBase.ChangeStatus(Identification + ".End", Value)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overloads to request satus of an object
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Sub RequestStatus(ByVal strMessage As String)
        Try
            MessageManager.AddRequestMessage(strMessage)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to request status of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub RequestStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter RequestStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        Try
            Dim strMessage As String = Identification + " " + Value
            Me.RequestStatus(strMessage)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave RequestStatus")
    End Sub
#End Region
End Class
