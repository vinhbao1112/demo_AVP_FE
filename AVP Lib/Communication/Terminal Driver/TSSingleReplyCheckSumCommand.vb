Namespace Communication.TerminalDriver
    Public Class TSSingleReplyCheckSumCommand
        Inherits TSSingleReplyCommand
#Region "Class Constants & Variables"
        Private m_blnIsSuccessInCheckSum As Boolean
#End Region

#Region "Properties"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsSuccessInCheckSum() As Boolean
            Get
                Return m_blnIsSuccessInCheckSum
            End Get
            Set(ByVal value As Boolean)
                m_blnIsSuccessInCheckSum = value
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
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-13</Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Run TSSingleReplyCheckSumCommand
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <param name="TimeOut"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function Run(ByVal Message As String, ByVal TimeOut As String) As TSCommand
            AVPLib.Log.terminalServerLogger.Debug("Enter Run")

            Try
                If (Connection.SendMessage(Me.Code)) Then
                    Dim strEquipmentName As String = Me.GetEquipmentName()
                    Me.ReplyValue = Connection.ReceiveMessage(TimeOut, strEquipmentName + "" + Me.Code)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Debug("Leave Run")
            Return Me
        End Function
#End Region

    End Class
End Namespace

