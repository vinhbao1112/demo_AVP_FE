Imports System.Text.RegularExpressions

Namespace Communication.TerminalDriver
    Public Class CryoPCommandsDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-15</date>
        ''' </author>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        ''' <summary>
        ''' Decode Cryo pump status
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")

            Dim ListValues As New ArrayList()
            Try
                If MessageValue.Contains("$A") Then
                    MessageValue = MessageValue.Replace("$A", "")
                    If MessageValue.Length < 2 Then
                        AVPLib.Log.terminalServerCryoLogger.Error("Incorrect response received " & MessageValue)
                        ListValues.Add(Nothing)
                    Else
                        MessageValue = MessageValue.Substring(1, MessageValue.Length - 2)
                        ListValues.Add(MessageValue)
                    End If
                Else
                    ListValues.Add(Nothing)
                    ' Just log the incorrect response message not alarm.
                    AVPLib.Log.terminalServerCryoLogger.Error("Cryo has error when received: " & MessageValue)
                    'ListValues.Add(Utils.GetMessageError("ErrRequestPumpStatus"))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave Decode")
            Return ListValues
        End Function
#End Region
    End Class
End Namespace
