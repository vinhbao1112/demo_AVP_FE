Imports System.Text.RegularExpressions

Namespace Communication.TerminalDriver
    Public Class CryoRegenHourDecoder
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
                If MessageValue.Contains("$A+") Then
                    MessageValue = MessageValue.Replace("$A+", "")
                    MessageValue = MessageValue.Substring(0, MessageValue.Length - 1)
                    ListValues.Add(MessageValue)
                Else
                    ListValues.Add(Nothing)
                    ' Just log the incorrect response message not alarm.
                    AVPLib.Log.terminalServerCryoLogger.Error("Incorrect response received " & MessageValue)
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
