Imports System.Text.RegularExpressions

Namespace Communication.TerminalDriver
    Public Class TSElevatorVersionDecoder
        Inherits TSDecoder

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Decode reply message from Elevator is a result of command R,VR
        ''' </summary>
        ''' <param name="MessageValue"></param>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            AVPLib.Log.terminalServerLogger.Info("MessageValue" + MessageValue)
            Const RESULT_ARRAY_LEN As Integer = 5
            Dim ListValues As New ArrayList
            'Response: ^00,X,VR,FR([A-F0-9]),RV([A-F0-9])$
            Try
                If MessageValue.IndexOf("X,VR") >= 0 Then
                    Dim strArray As String() = MessageValue.Split(New Char() {","c})
                    If strArray.Length <> RESULT_ARRAY_LEN Then
                        AVPLib.Log.terminalServerRobotLogger.Error("Failed, incorrect response for R,VR " & MessageValue)
                    Else

                        ' GET Firmwareversion
                        Dim Firmwareversion As String = strArray(RESULT_ARRAY_LEN - 2)
                        If Not String.IsNullOrEmpty(Firmwareversion) Then
                            Firmwareversion = Firmwareversion.Substring(2)
                        End If
                        ' get version
                        Dim version As String = strArray(RESULT_ARRAY_LEN - 1)
                        If Not String.IsNullOrEmpty(version) Then
                            version = version.Substring(2)
                        End If

                        '' m_firmwareRevision & " - " & m_version
                        Dim RevisionNoValues As String = Firmwareversion & " - " & version
                        ListValues.Add(RevisionNoValues)
                    End If
                Else
                    ' Just log the incorrect response message not alarm.
                    AVPLib.Log.terminalServerRobotLogger.Error("Incorrect response received " & MessageValue)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave Decode")
            Return ListValues
        End Function
    End Class
End Namespace
