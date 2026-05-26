Namespace Communication.TerminalDriver
    Public Class TSSerialCommandDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <modifiers>
        ''' <modifier>
        '''   	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-02</date>
        ''' </modifier>
        ''' </modifiers>
        ''' <summary>
        ''' Serial decoder
        ''' </summary>
        ''' <param name="MessageValue"></param>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")

            Dim ListValues As New ArrayList()
            Try
                If MessageValue = "_RDY" Then
                    ListValues.Add(AVPLib.DataManagerment.Equipment.OperationStatuses.READY)
                    ListValues.Add(MessageValue)
                Else
                    ListValues.Add(MessageValue)
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