Imports System.Text.RegularExpressions
Namespace Communication.TerminalDriver
    Public Class TSElevatorErrorDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Decode TSElevatorAliveDecoder
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")

            Dim ListValues As New ArrayList
            Dim strRegularExp = "^00,X,ER,(.*)$"
            Try
                Dim FoundMatch As Boolean = Regex.IsMatch(MessageValue, strRegularExp)
                If (FoundMatch) Then
                    Dim strValue As String = Regex.Match(MessageValue, strRegularExp).Groups(1).Value
                    If (strValue = "OK") Then
                        ListValues.Add(True)
                        ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)
                    Else
                        ListValues.Add(True)
                        ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.ERROR)
                        Dim arrErrorCodes() As String = strValue.Split(",")
                        For Each strErrorCode As String In arrErrorCodes
                            ListValues.Add(Utils.GetMessageError("Elevator." & strErrorCode))
                        Next
                    End If
                Else
                    ListValues.Add(True)
                    ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)
                    ' Just log the incorrect response message not alarm.
                    AVPLib.Log.terminalServerRobotLogger.Error("Incorrect response received " & MessageValue)
                    'ListValues.Add(Utils.GetMessageError("ErrElevator"))
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
