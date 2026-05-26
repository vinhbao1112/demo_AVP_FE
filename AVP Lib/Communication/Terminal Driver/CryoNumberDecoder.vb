Namespace Communication.TerminalDriver
    Public Class CryoNumberDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifier>
        '''   	<Name>Nguyen Bao Trieu</Name>
        '''   	<Date>2008-11-07</Date>
        '''		<Description></Description>
        ''' </Modifier>
        ''' <summary>
        ''' Decode CryoNumberDecoder
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            Dim ListValues As New ArrayList()

            Try
                Dim cs As New CheckSum()
                Dim value As Double = 0
                If cs.Check(MessageValue) Then
                    If MessageValue.Length > 3 And MessageValue(1) = "A" And Double.TryParse(MessageValue.Substring(2, MessageValue.Length - 3), value) Then
                        ListValues.Add(value)
                    Else
                        ListValues.Add(0)
                        ' Just log the incorrect response message not alarm.
                        AVPLib.Log.terminalServerCryoLogger.Error("Incorrect response received " & MessageValue)
                        'ListValues.Add(Utils.GetMessageError("ErrInvalidResponseFormat"))
                    End If
                Else
                    ListValues.Add(0)
                    ListValues.Add(Utils.GetMessageError("ErrChecksumFailed"))
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

