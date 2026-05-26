Imports system.Text
Namespace Communication.TerminalDriver
    Public Class CryoPollingDecoder
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
                Dim strMessageData As String = GetReplyMessageData(MessageValue)
                If Not String.IsNullOrEmpty(strMessageData) Then
                    strMessageData = strMessageData.Substring(0, 1)
                    Dim BitMap As Byte = Encoding.ASCII.GetBytes(strMessageData)(0)
                    If (BitMap And 1) = 1 Then
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.On)
                    Else
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.Off)
                    End If
                    If (BitMap And 2) = 2 Then
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.On)
                    Else
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.Off)
                    End If
                    If (BitMap And 4) = 4 Then
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.On)
                    Else
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.Off)
                    End If
                    If (BitMap And 8) = 8 Then
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.On)
                    Else
                        ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.Off)
                    End If
                Else
                    ListValues.Add(Nothing)
                    ' Just log the incorrect response message not alarm.
                    AVPLib.Log.terminalServerCryoLogger.Error("Incorrect response received " & MessageValue)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.terminalServerLogger.Info("Leave Decode")
            Return ListValues
        End Function

        Private Function GetReplyMessageData(ByVal strRawReplyMessage As String) As String
            Try
                If (strRawReplyMessage.Length > 3) And (strRawReplyMessage.StartsWith("$A")) Then
                    Return strRawReplyMessage.Substring(2, strRawReplyMessage.Length - 3)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return String.Empty
        End Function

#End Region
    End Class
End Namespace

