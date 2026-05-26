Namespace Communication.TerminalDriver
    Public Class TSNoReplyCommand
        Inherits TSCommand

#Region "Class Constants & Variables"
        Private m_IsInTransaction As Boolean
#End Region

#Region "Properties"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-12</date>
        ''' </author>
        ''' <summary>
        ''' Is command in transaction
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsInTransaction() As Boolean
            Get
                Return m_IsInTransaction
            End Get
            Set(ByVal value As Boolean)
                m_IsInTransaction = value
            End Set
        End Property
#End Region

#Region "Public method"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Nguyen Bao Trieu</Name>
        '''   	<Date>2008-11-06</Date>
        '''		<Description></Description>
        ''' </Modifier>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-13</Date>
        '''		<Description>Fix bugs</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Run TSNoReplyCommand
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <param name="TimeOut"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function Run(ByVal Message As String, ByVal TimeOut As String) As TSCommand
            AVPLib.Log.terminalServerLogger.Debug("Enter Run")

            Try
                Connection.SendMessage(Me.Code)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Debug("Leave Run")
            Return Me
        End Function
#End Region
    End Class

End Namespace
