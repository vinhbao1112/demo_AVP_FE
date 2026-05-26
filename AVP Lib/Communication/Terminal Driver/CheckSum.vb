Namespace Communication.TerminalDriver
    Public Class CheckSum
#Region "Public method"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Nguyen Bao Trieu</Name>
        '''   	<Date>2008-11-08</Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Check sum
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Check(ByVal Message As String) As Boolean
            AVPLib.Log.terminalServerLogger.Info("Enter Check")
            Try
                Dim strMessage As String
                strMessage = Message.Substring(1, Message.Length - 2)
                Dim intDecimal As Integer = 0
                Dim intByte As Byte
                If strMessage.Length > 14 Then

                    AVPLib.Log.terminalServerLogger.Info("Leave Check")
                    Return False
                Else
                    For i As Integer = 0 To strMessage.Length - 1
                        intDecimal += Convert.ToInt32(strMessage(i))
                    Next
                    intByte = Convert.ToByte(intDecimal Mod 256)
                    intByte = intByte Xor (intByte >> 6)
                    intByte = intByte And 63
                    intByte = intByte + 48
                End If
                If (Convert.ToInt32(intByte) = Convert.ToInt32(Message(Message.Length - 1))) Then

                    AVPLib.Log.terminalServerLogger.Info("Leave Check")
                    Return True
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave Check")
            Return False
        End Function

        Public Function AppendCheckSum(ByVal Message As String) As String
            AVPLib.Log.terminalServerLogger.Info("Enter AppendCheckSum")
            Dim strMessage As String = Message '.Substring(1, Message.Length - 1)
            Try
                Dim intDecimal As Integer = 0
                Dim intByte As Byte
                If strMessage.Length > 14 Then
                    AVPLib.Log.terminalServerLogger.Info("Leave AppendCheckSum")
                    Return False
                Else
                    For i As Integer = 0 To strMessage.Length - 1
                        intDecimal += Convert.ToInt32(strMessage(i))
                    Next
                    intByte = Convert.ToByte(intDecimal Mod 256)
                    intByte = intByte Xor (intByte >> 6)
                    intByte = intByte And 63
                    intByte = intByte + 48
                End If
                strMessage = Message & Convert.ToChar(intByte)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.terminalServerLogger.Info("Leave AppendCheckSum")
            Return strMessage
        End Function
#End Region
    End Class
End Namespace

