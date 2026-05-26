Imports System.Text.RegularExpressions

Namespace Communication.TerminalDriver
    Public Class TSClampStatusDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Ngo  Cao Dinh </name>
        '''    	<date> 2008-12-06 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Decode door clamp status
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            AVPLib.Log.terminalServerLogger.Info("MessageValue" + MessageValue)

            Dim ListValues As New ArrayList
            Dim strRegularExp = "^00,X,CS([CU])$"
            Try
                Dim FoundMatch As Boolean = Regex.IsMatch(MessageValue, strRegularExp)
                If (FoundMatch) Then
                    Dim strValue As String = Regex.Match(MessageValue, strRegularExp).Groups(1).Value
                    If (strValue = "C") Then
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.On)
                    Else
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.Off)
                    End If
                Else
                    ListValues.Add(Nothing)
                    ' Just log the incorrect response message not alarm.
                    AVPLib.Log.terminalServerRobotLogger.Error("Incorrect response received " & MessageValue)
                    'ListValues.Add(Utils.GetMessageError("ErrRequestCasPresent"))
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