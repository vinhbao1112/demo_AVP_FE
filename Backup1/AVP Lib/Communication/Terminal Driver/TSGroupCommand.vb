Namespace Communication.TerminalDriver
    Public Class TSGroupCommand
        Inherits TSCommand

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
        ''' Run TSGroupCommand
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <param name="TimeOut"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function Run(ByVal Message As String, ByVal TimeOut As String) As TSCommand
            AVPLib.Log.terminalServerLogger.Info("Enter Run")

            Try
                Return Me
            Catch ex As Exception
                Throw ex
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave Run")
        End Function
#End Region
    End Class

End Namespace
