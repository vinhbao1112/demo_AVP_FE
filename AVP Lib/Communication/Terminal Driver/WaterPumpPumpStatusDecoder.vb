Imports System.Text.RegularExpressions

Namespace Communication.TerminalDriver
    Public Class WaterPumpPumpStatusDecoder
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
                MessageValue = MessageValue.Substring(1, MessageValue.Length - 2)
                Dim strRegularExp As String = "^A([0-1])$"
                Dim FoundMatch As Boolean = Regex.IsMatch(MessageValue, strRegularExp)
                If (FoundMatch) Then
                    Dim Value As String = Regex.Match(MessageValue, strRegularExp).Groups(1).Value
                    If (Value = 1) Then
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.On)
                    Else
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.Off)
                    End If
                    ListValues.Add(True) '''' it is communicating flag
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
