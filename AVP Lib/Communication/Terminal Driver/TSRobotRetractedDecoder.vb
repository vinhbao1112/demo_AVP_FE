Imports System.Text.RegularExpressions
Namespace Communication.TerminalDriver
    Public Class TSRobotRetractedDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Ngo  Cao Dinh </name>
        '''    	<date> 2008-12-15 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Decode retracted status
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            AVPLib.Log.terminalServerLogger.Info("MessageValue=" + MessageValue)

            Dim ListValues As New ArrayList
            Dim strRegularExp = "^POS (EX|ABS)\s+(\d+)\s+(\d+)\s+(\d+)$"
            'POS STN -- 00 0000 --
            'POS ABS X Y Z
            Try
                Dim FoundMatch As Boolean = Regex.IsMatch(MessageValue, strRegularExp)
                If (FoundMatch) Then
                    Dim intValue As Int32 = Regex.Match(MessageValue, strRegularExp).Groups(2).Value
                    Dim intRetracted_Lower_Bound As Int32 = AVPLib.ContainerData.GetRobotConfig("Robot_Retracted_Lower_Bound")
                    Dim intRetracted_Upper_Bound As Int32 = AVPLib.ContainerData.GetRobotConfig("Robot_Retracted_Upper_Bound")
                    If (intRetracted_Lower_Bound <= intValue And intRetracted_Upper_Bound >= intValue) Then
                        ListValues.Add(True)
                    Else
                        ListValues.Add(False)
                    End If
                Else
                    'If it not a valid message, then report error
                    'If (Not Regex.IsMatch(MessageValue, ConstEnum.LL_VALID_REQ_STATION_MSG_REGEXP)) Then
                        ListValues.Add(Nothing)
                        ' Just log the incorrect response message.
                        AVPLib.Log.terminalServerRobotLogger.Error("Incorrect response received " & MessageValue)
                        ' Not alarm.
                        'ListValues.Add(Utils.GetMessageError("ErrRequestRetractedStatus"))
                    '    Else ' HOME Position.
                    '    ListValues.Add(True)
                    'End If
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