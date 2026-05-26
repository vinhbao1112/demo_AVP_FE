Namespace Communication.TerminalDriver
    Public Class TSRobotAliveDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-15</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="MessageValue"></param>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            AVPLib.Log.terminalServerLogger.Info("MessageValue" + MessageValue)

            Dim ListValues As New ArrayList()
            Try
                If MessageValue = "_RDY" Then
                    ListValues.Add(True)
                    ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)
                Else
                    ListValues.Add(True)
                    If (MessageValue.IndexOf(ConstEnum.ROBOT_ERR_MSG) > -1) Then
                        ' Error
                        ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.ERROR)
                        ' Just log the incorrect response|error message not alarm.
                        AVPLib.Log.terminalServerRobotLogger.Error("Incorrect response received " & MessageValue)
                        'ListValues.Add(Utils.GetMessageError(MessageValue))
                    Else
                        ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)
                    End If
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

