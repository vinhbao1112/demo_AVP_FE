Imports System.Text.RegularExpressions
Namespace Communication.TerminalDriver
    Public Class TSCommand
#Region "Class Constants & Variables"
        Private m_StrCode As String
        Private m_htbChildCommand As Hashtable
        Private m_Connection As Connection
        Private m_Parent As TSCommand
#End Region

#Region "Properties"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Get current TSCommand strCode
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Code() As String
            Get
                Return m_StrCode
            End Get
            Set(ByVal value As String)
                m_StrCode = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Get current TsCommand ChildCommand
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ChildCommand() As Hashtable
            Get
                Return m_htbChildCommand
            End Get
            Set(ByVal value As Hashtable)
                m_htbChildCommand = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Get current TsCommand Connection
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Connection() As Connection
            Get
                Return m_Connection
            End Get
            Set(ByVal value As Connection)
                m_Connection = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Get current TsCommand Parent
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Parent() As TSCommand
            Get
                Return m_Parent
            End Get
            Set(ByVal value As TSCommand)
                m_Parent = value
            End Set
        End Property
#End Region

#Region "Constructors & Dispose"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-01</Date>
        '''		<Description> new child command list</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Initialize terminal server command
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            m_htbChildCommand = New Hashtable()
        End Sub
#End Region

#Region "Public method"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-07</Date>
        '''		<Description>Parse and run command</Description>
        ''' </Modifier>
        ''' <summary>
        ''' Run TsCommand
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <param name="TimeOut"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function Run(ByVal Message As String, ByVal TimeOut As String) As TSCommand
            AVPLib.Log.terminalServerLogger.Debug("Enter Run")

            Dim tscResult As TSCommand = Nothing
            Try
                If (Not String.IsNullOrEmpty(Message)) Then
                    AVPLib.Log.terminalServerLogger.Debug("Message=" + Message)

                    Dim intPos As Integer = Message.IndexOf(".")
                    Dim strKey As String
                    If (intPos > 0) Then
                        strKey = Message.Substring(0, intPos)
                        Message = Message.Substring(intPos + 1)
                    Else
                        strKey = Message
                        Message = ""
                    End If
                    If (ChildCommand.ContainsKey(strKey)) Then
                        Dim tscCommand As TSCommand = CType(ChildCommand.Item(strKey), TSCommand)
                        tscResult = tscCommand.Run(Message, TimeOut)
                    Else
                        ' if can not find the right command
                        ' Try to create a terminal server command 
                        ' the same as sending serial command
                        Select Case Me.Code
                            Case ConstEnum.Equipments.Robot.ToString()
                                ' if this is the command that will send to Robot
                                Dim tssCommand As New TSSingleReplyCommand
                                tssCommand.ReplyValue = ""
                                TSCommandManager.AddRequiredInformation(tssCommand, strKey, Me.Code)
                                tssCommand.Run(strKey, TimeOut)
                                tssCommand.DecoderName = "TSReadyErrorDecoder"
                                tssCommand.EquipmentProperty = "OperationStatus"
                                tscResult = tssCommand
                            Case ConstEnum.Equipments.Aligner.ToString()
                                ' if this is the command that will send to Aligner
                                Dim tssCommand As New TSSingleReplyCommand
                                tssCommand.ReplyValue = ""
                                TSCommandManager.AddRequiredInformation(tssCommand, strKey, Me.Code)
                                tssCommand.Run(strKey, TimeOut)
                                tssCommand.DecoderName = "TSAlignerReadyDecoder"
                                tssCommand.EquipmentProperty = "OperationStatus"
                                tscResult = tssCommand
                            Case ConstEnum.Equipments.LLAElevator.ToString()
                                ' if this is the command that will send to Elevator
                                Dim strRegularExp = "^[0-9][0-9],[R,r],.*$"
                                Dim FoundMatch As Boolean = Regex.IsMatch(strKey, strRegularExp)
                                If (FoundMatch) Then
                                    ' If this is a request coommand --> have respose
                                    Dim tssCommand As New TSSingleReplyCommand
                                    TSCommandManager.AddRequiredInformation(tssCommand, strKey, Me.Code)
                                    tssCommand.Run(Code, TimeOut)
                                    tssCommand.EquipmentProperty = "OperationStatus"
                                    tscResult = tssCommand
                                Else
                                    ' If this is not a request coommand --> No respose
                                    Dim tscCommand As New TSNoReplyCommand
                                    TSCommandManager.AddRequiredInformation(tscCommand, strKey, Me.Code)
                                    tscCommand.Run(strKey, TimeOut)
                                    tscResult = tscCommand
                                End If
                            Case ConstEnum.Equipments.TMPumpPackage.ToString(), ConstEnum.Equipments.LLAPumpPackage.ToString()
                                Dim tssCommand As New TSSingleReplyCommand
                                TSCommandManager.AddRequiredInformation(tssCommand, strKey, Me.Code)
                                tssCommand.Run(Code, TimeOut)
                                tscResult = tssCommand
                        End Select
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Debug("Leave Run")
            Return tscResult
        End Function
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Add a child command
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub AddChildCommand(ByVal ChildCommand As TSCommand)
            AVPLib.Log.terminalServerLogger.Info("Enter AddChildCommand")
            m_htbChildCommand.Add(ChildCommand.Code, ChildCommand)
            AVPLib.Log.terminalServerLogger.Info("Leave AddChildCommand")
        End Sub
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name> Ngo Cao Dinh</Name>
        '''   	<Date> 2008-11-13 </Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Get a equipment name
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetEquipmentName() As String
            Dim Result As String = ""
            Try
                If (Parent IsNot Nothing) Then
                    Result = Parent.GetEquipmentName()
                Else
                    Result = m_StrCode
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return Result
        End Function
#End Region

    End Class
End Namespace


