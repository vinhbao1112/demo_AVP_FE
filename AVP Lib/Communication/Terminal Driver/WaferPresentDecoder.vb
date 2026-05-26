Namespace Communication.TerminalDriver
    Public Class WaferPresentDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo  Cao Dinh</Name>
        '''   	<Date> 2008-11-15</Date>
        '''		<Description>fix bugs</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Decode CassettePresentDecoder
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList

            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            Dim ListValues As New ArrayList

            Try
                Dim strRightChar As String = MessageValue.Substring(MessageValue.Length - 1)
                Select Case strRightChar
                    Case "Y"
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.On)
                    Case "N"
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.Off)
                    Case "?"
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.Unknown)
                    Case Else
                        ListValues.Add(Nothing)
                        ' Just log the incorrect response message not alarm.
                        AVPLib.Log.terminalServerRobotLogger.Error("Incorrect response received " & MessageValue)
                        ' ListValues.Add(Utils.GetMessageError("ErrRequestCasPresent"))
                End Select
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave Decode")
            Return ListValues
        End Function
#End Region
    End Class
End Namespace


