Namespace Communication.TerminalDriver
    Public Class TSSingleReplyCommand
        Inherits TSCommand
#Region "Class Constants & Variables"
        Private m_strReplyValue As String
        Private m_StrDecoderName As String
        Private m_StrEquipmentProperty As String
        Private m_IsInTransaction As Boolean
#End Region

#Region "Properties"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current reply value
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ReplyValue() As String
            Get
                Return m_strReplyValue
            End Get
            Set(ByVal value As String)
                m_strReplyValue = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Get current string decoder name
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property DecoderName() As String
            Get
                Return m_StrDecoderName
            End Get
            Set(ByVal value As String)
                m_StrDecoderName = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Get string equipment property
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property EquipmentProperty() As String
            Get
                Return m_StrEquipmentProperty
            End Get
            Set(ByVal value As String)
                m_StrEquipmentProperty = value
            End Set
        End Property

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
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-13</Date>
        '''		<Description>Fix bugs</Description>
        ''' </Modifier>
        '''</Modifiers>        
        ''' <summary>
        ''' Run TSSingleReplyCommand
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
                    Me.ReplyValue = Connection.ReceiveMessage(TimeOut, strEquipmentName + "." + Me.Code)
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
