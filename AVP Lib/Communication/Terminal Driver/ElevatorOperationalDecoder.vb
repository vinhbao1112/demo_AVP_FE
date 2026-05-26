Imports System.Text.RegularExpressions

Namespace Communication.TerminalDriver
    Public Class ElevatorOperationalDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-19</date>
        ''' </author>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        ''' <summary>
        ''' Decode operational status
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            AVPLib.Log.terminalServerLogger.Info("MessageValue=" + MessageValue)

            Dim ListValues As New ArrayList()
            Dim strRegularExp = "^00,X,OS,BR([BR]),SL([0-9][0-9])(.),CP([YN]),WP([YN?]),ER([YN])$"
            Try
                Dim FoundMatch As Boolean = Regex.IsMatch(MessageValue, strRegularExp)
                If (FoundMatch) Then
                    Dim strGroup1Value As String = Regex.Match(MessageValue, strRegularExp).Groups(1).Value
                    If (strGroup1Value = "R") Then
                        ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)
                    Else
                        ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.BUSY)
                    End If

                    Dim strGroup2Value As String = Regex.Match(MessageValue, strRegularExp).Groups(2).Value
                    ListValues.Add(Integer.Parse(strGroup2Value))

                    Dim strGroup3Value As String = Regex.Match(MessageValue, strRegularExp).Groups(4).Value
                    If (strGroup3Value = "N") Then
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.On)
                    Else
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.Off)
                    End If
                    ' IsHwErrorReceived
                    Dim strGroup4Value As String = Regex.Match(MessageValue, strRegularExp).Groups(6).Value
                    If (strGroup4Value = "Y") Then
                        ListValues.Add(True)
                    Else
                        ListValues.Add(False)
                    End If
                Else
                    ListValues.Add(Nothing)
                    ' Just log the incorrect response message not alarm.
                    AVPLib.Log.terminalServerRobotLogger.Error("Incorrect response received " & MessageValue)
                    'ListValues.Add(Utils.GetMessageError("ErrElevatorOperationalStatus"))
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