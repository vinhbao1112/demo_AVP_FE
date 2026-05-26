Imports System.Xml
Imports System.Text.RegularExpressions

Namespace Communication.TerminalDriver
    Public Class TSCommandManager

#Region "Class Constants & Variables"
        Private Shared m_htbCommands As Hashtable
        Private Shared m_MessagesLock As New Object
#End Region

#Region "Properties"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-11</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Get all child commands that manage by this class
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared ReadOnly Property ChildCommand() As Hashtable
            Get
                Return m_htbCommands
            End Get
        End Property
#End Region

#Region "Public static methods"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-07</Date>
        '''		<Description>Run a command</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Run TSCommandManager
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <param name="TimeOut"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function Run(ByVal Message As String, ByVal TimeOut As String) As TSCommand
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
                        If (Message.IndexOf("Serial") >= 0) Then 'Serial command
                            intPos = Message.IndexOf(".")
                            Message = Message.Substring(intPos + 1)
                            tscResult = RunSerialCommand(strKey, Message, TimeOut)
                        Else ' Defined command
                            Dim objValue As Object
                            SyncLock m_MessagesLock
                                objValue = m_htbCommands.Item(strKey)
                            End SyncLock
                            If (objValue IsNot Nothing) Then
                                Dim tscCommand As TSCommand = CType(objValue, TSCommand)
                                tscResult = tscCommand.Run(Message, TimeOut)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Debug("Leave Run")
            Return tscResult
        End Function
        ''' <author>
        '''    	<name>Ngo Cao Dinh</name>
        '''    	<date> 2008-11-11</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Initial command tree
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub Initialize()
            Try
                m_htbCommands = New Hashtable()
                CreateCommandTree()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
        ''' <author>
        '''    	<name>Ngo Cao Dinh</name>
        '''    	<date> 2008-11-11</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Dispose command tree to release memory resource
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub Dispose()
            Try
                If m_htbCommands IsNot Nothing Then
                    m_htbCommands.Clear()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

#End Region

#Region "Private static methods"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-30 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Run serial command
        ''' </summary>
        ''' <param name="Equipment"></param>
        ''' <param name="Code"></param>
        ''' <param name="TimeOut"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Shared Function RunSerialCommand(ByVal Equipment As String, ByVal Code As String, ByVal TimeOut As String) As TSCommand
            AVPLib.Log.terminalServerLogger.Info("Enter RunSerialCommand")
            AVPLib.Log.terminalServerLogger.Info("Equipment=" + Equipment)
            AVPLib.Log.terminalServerLogger.Info("Code=" + Code)

            Dim tscResult As TSCommand = Nothing
            Try
                Select Case Equipment
                    Case "Robot", "Aligner"
                        Dim tssCommand As New TSSingleReplyCommand
                        tssCommand.ReplyValue = ""
                        AddRequiredInformation(tssCommand, Code, Equipment)
                        tssCommand.Run(Code, TimeOut)
                        tssCommand.DecoderName = "TSSerialCommandDecoder"
                        If (tssCommand.ReplyValue.CompareTo("_RDY") = 0) Then
                            tssCommand.EquipmentProperty = "OperationStatus,ResponseMessage"
                        Else
                            tssCommand.EquipmentProperty = "ResponseMessage"
                        End If
                        tscResult = tssCommand
                    Case "LLAElevator"
                        Dim strRegularExp = "^[0-9][0-9],[R,r],.*$"
                        Dim FoundMatch As Boolean = Regex.IsMatch(Code, strRegularExp)
                        If (FoundMatch) Then
                            Dim tssCommand As New TSSingleReplyCommand
                            AddRequiredInformation(tssCommand, Code, Equipment)
                            tssCommand.Run(Code, TimeOut)
                            tssCommand.DecoderName = "TSSerialCommandDecoder"
                            tssCommand.EquipmentProperty = "ResponseMessage"
                            tscResult = tssCommand
                        Else
                            Dim tscCommand As New TSNoReplyCommand
                            AddRequiredInformation(tscCommand, Code, Equipment)
                            tscCommand.Run(Code, TimeOut)
                            tscResult = tscCommand
                        End If
                End Select
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave RunSerialCommand")
            Return tscResult
        End Function
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-30 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Run serial command
        ''' </summary>
        ''' <param name="Command"></param>
        ''' <param name="Code"></param>
        ''' <param name="Equipment"></param>
        ''' <remarks></remarks>
        Public Shared Sub AddRequiredInformation(ByVal Command As TSCommand, ByVal Code As String, ByVal Equipment As String)
            AVPLib.Log.terminalServerLogger.Info("Enter AddRequiredInformation")

            Try
                If (Command IsNot Nothing) Then
                    Command.Code = Code
                    Command.Connection = ConnectionManager.GetConnection(Equipment)
                    SyncLock m_MessagesLock
                        Command.Parent = m_htbCommands.Item(Equipment)
                    End SyncLock
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave AddRequiredInformation")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-11</Date>
        '''		<Description>Create command tree by loading xml file</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Create command tree
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Sub CreateCommandTree()
            AVPLib.Log.terminalServerLogger.Info("Enter CreateCommandTree")
            Try
                Dim strRobotName As String = ConstEnum.Equipments.Robot.ToString()
                m_htbCommands.Add(strRobotName, CreateRobotCommandTree(strRobotName))

                Dim strAlignerName As String = ConstEnum.Equipments.Aligner.ToString()
                m_htbCommands.Add(strAlignerName, CreateAlignerCommandTree(strAlignerName))

                If RobotConfigurationValues.TMCRYO_VISIBLE = True Then
                    Dim strTMCryo As String = ConstEnum.Equipments.TMPumpPackage.ToString()
                    m_htbCommands.Add(strTMCryo, CreateCryoCommandTree(strTMCryo))
                ElseIf RobotConfigurationValues.TMTURBO_VISIBLE = True Then
                    Dim strTMTurbo As String = ConstEnum.Equipments.TMPumpPackage.ToString()
                    m_htbCommands.Add(strTMTurbo, CreateTurboCommandTree(strTMTurbo))
                End If


                If RobotConfigurationValues.TMWATERPUM_VISIBLE = True Then
                    Dim strTMWaterPump As String = ConstEnum.Equipments.TMWaterPump.ToString()
                    m_htbCommands.Add(strTMWaterPump, CreateWaterPumpsCommandTree(strTMWaterPump))
                End If

                Dim strLLAElevator As String = ConstEnum.Equipments.LLAElevator.ToString()
                m_htbCommands.Add(strLLAElevator, CreateElevatorCommandTree(strLLAElevator))

                If RobotConfigurationValues.LLA_CRYO_VISIBLE = True Then
                    Dim strLLACryo As String = ConstEnum.Equipments.LLAPumpPackage.ToString()
                    m_htbCommands.Add(strLLACryo, CreateCryoCommandTree(strLLACryo))
                ElseIf RobotConfigurationValues.LLA_TURBO_VISIBLE = True Then
                    Dim strLLATurbo As String = ConstEnum.Equipments.LLAPumpPackage.ToString()
                    m_htbCommands.Add(strLLATurbo, CreateTurboCommandTree(strLLATurbo))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.terminalServerLogger.Info("Leave CreateCommandTree")
        End Sub

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-11 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Create commmand tree for robot
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Private Shared Function CreateRobotCommandTree(ByVal Name As String) As TSCommand
            AVPLib.Log.terminalServerLogger.Info("Enter CreateRobotCommandTree")

            Dim RobotCommands As New TSCommand()
            RobotCommands.Code = Name
            RobotCommands.Connection = ConnectionManager.GetConnection(Name)
            Try
                AddCommandToDevice(ConstEnum.Equipments.Robot.ToString(), RobotCommands)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave CreateRobotCommandTree")
            Return RobotCommands
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-12 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Create commmand tree for Elevator
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Private Shared Function CreateElevatorCommandTree(ByVal Name As String) As TSCommand
            AVPLib.Log.terminalServerLogger.Info("Enter CreateElevatorCommandTree")

            Dim ElevatorCommands As New TSCommand()
            ElevatorCommands.Code = Name
            ElevatorCommands.Connection = ConnectionManager.GetConnection(Name)
            Try
                AddCommandToDevice("Elevator", ElevatorCommands)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave CreateElevatorCommandTree")
            Return ElevatorCommands
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-12 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Create commmand tree for Cyo
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Private Shared Function CreateCryoCommandTree(ByVal Name As String) As TSCommand
            AVPLib.Log.terminalServerLogger.Info("Enter CreateCryoCommandTree")

            Dim CryoCommands As New TSCommand()
            CryoCommands.Code = Name
            CryoCommands.Connection = ConnectionManager.GetConnection(Name)
            Try
                AddCommandToDevice("Cryo", CryoCommands)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave CreateCryoCommandTree")
            Return CryoCommands
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-12 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Create commmand tree for Cyo
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Private Shared Function CreateTurboCommandTree(ByVal Name As String) As TSCommand
            AVPLib.Log.terminalServerLogger.Info("Enter CreateTurboCommandTree")

            Dim TurboCommands As New TSCommand()
            TurboCommands.Code = Name
            TurboCommands.Connection = ConnectionManager.GetConnection(Name)
            Try
                AddCommandToDevice("Turbo", TurboCommands)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave CreateTurboCommandTree")
            Return TurboCommands
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-12 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Create commmand tree for Cyo
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Private Shared Function CreateWaterPumpsCommandTree(ByVal Name As String) As TSCommand
            AVPLib.Log.terminalServerLogger.Info("Enter CreateCryoCommandTree")

            Dim CryoCommands As New TSCommand()
            CryoCommands.Code = Name
            CryoCommands.Connection = ConnectionManager.GetConnection(Name)
            Try
                AddCommandToDevice("WaterPump", CryoCommands)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave CreateCryoCommandTree")
            Return CryoCommands
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-12 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Create commmand tree for Aligner
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Private Shared Function CreateAlignerCommandTree(ByVal Name As String) As TSCommand
            AVPLib.Log.terminalServerLogger.Info("Enter CreateAlignerCommandTree")

            Dim AlignerCommands As New TSCommand()
            AlignerCommands.Code = Name
            AlignerCommands.Connection = ConnectionManager.GetConnection(Name)
            Try
                AddCommandToDevice("Aligner", AlignerCommands)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave CreateAlignerCommandTree")
            Return AlignerCommands
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-11 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Create child commands for devices
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Sub AddCommandToDevice(ByVal DeviceName As String, ByVal DeviceCommands As TSCommand)
            AVPLib.Log.terminalServerLogger.Info("Enter AddCommandToDevice")

            Try
                Dim CommandsDoc As System.Xml.XmlDocument = ContainerDAO.ProcessCommandDoc
                Dim Root As XmlNode = CommandsDoc.DocumentElement
                Dim strXPath As String = "Device[@name='" + DeviceName + "']"
                Dim DeviceNode As XmlNode = Root.SelectSingleNode(strXPath)

                If (DeviceNode IsNot Nothing AndAlso DeviceNode.ChildNodes IsNot Nothing) Then
                    Dim NodeCommandList As System.Xml.XmlNodeList = DeviceNode.ChildNodes
                    Dim NodeCommand As System.Xml.XmlNode
                    If (NodeCommandList IsNot Nothing) Then
                        For i As Integer = 0 To NodeCommandList.Count - 1
                            NodeCommand = NodeCommandList.Item(i)
                            If NodeCommand.Name = "Command" Then
                                AddCommand(NodeCommand, DeviceCommands)
                            Else
                                AddGroupCommand(NodeCommand, DeviceCommands)
                            End If
                        Next
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave AddCommandToDevice")
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-11-06</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-11</Date>
        '''		<Description>Fix bugs</Description>
        ''' </Modifier>
        '''</Modifiers>         
        ''' <summary>
        ''' Add Group Command
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Sub AddGroupCommand(ByVal nodeGroupCommand As System.Xml.XmlNode, ByVal Command As TSCommand)
            AVPLib.Log.terminalServerLogger.Info("Enter AddGroupCommand")

            Try
                Dim strCodeGroup As String = nodeGroupCommand.Attributes.ItemOf("Code").InnerText
                Dim GroupCommand As New TSGroupCommand()
                GroupCommand.Code = strCodeGroup
                GroupCommand.Connection = Command.Connection
                GroupCommand.Parent = Command
                Dim nodeCommandList As System.Xml.XmlNodeList = nodeGroupCommand.ChildNodes
                For i As Integer = 0 To nodeCommandList.Count - 1
                    Dim nodeCommand As System.Xml.XmlNode = nodeCommandList.Item(i)
                    AddCommand(nodeCommand, GroupCommand)
                Next
                Command.ChildCommand.Add(strCodeGroup, GroupCommand)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave AddGroupCommand")
        End Sub
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-11-06</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-11</Date>
        '''		<Description>Fix bugs</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' AddCommand
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Sub AddCommand(ByVal nodeCommand As System.Xml.XmlNode, ByVal Command As TSCommand)
            AVPLib.Log.terminalServerLogger.Info("Enter AddCommand")

            Try
                Dim nodeCommandReply As System.Xml.XmlNodeList = nodeCommand.ChildNodes
                Dim SubCommand As TSCommand
                Select Case nodeCommandReply.Count
                    Case 1
                        If (GetCheckSumAttribute(nodeCommandReply(0))) Then
                            SubCommand = CreateSingleReplyCheckSumCommand(nodeCommand)
                        Else
                            SubCommand = CreateSingleReplyCommand(nodeCommand)
                        End If
                    Case Else
                        SubCommand = CreateNoReplyCommand(nodeCommand)
                End Select

                Dim strCode As String = nodeCommand.Attributes.ItemOf("Code").InnerText
                SubCommand.Connection = Command.Connection
                SubCommand.Code = strCode
                SubCommand.Parent = Command
                Command.ChildCommand.Add(strCode, SubCommand)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave AddCommand")
        End Sub
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-12 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Create an instance of NoReplyCommand from a xml command node
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Function CreateNoReplyCommand(ByVal nodeCommand As System.Xml.XmlNode) As TSCommand
            AVPLib.Log.terminalServerLogger.Info("Enter CreateNoReplyCommand")

            Dim Result As New TSNoReplyCommand()
            Try
                Result.IsInTransaction = GetTransactionAttribute(nodeCommand)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave CreateNoReplyCommand")
            Return Result
        End Function
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-12 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Create an instance of SingleReplyCommand from a xml command node
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Function CreateSingleReplyCommand(ByVal nodeCommand As System.Xml.XmlNode) As TSCommand
            AVPLib.Log.terminalServerLogger.Info("Enter CreateSingleReplyCommand")

            Dim Result As New TSSingleReplyCommand()
            Try
                Result.IsInTransaction = GetTransactionAttribute(nodeCommand)

                Dim ReplyNodeList As System.Xml.XmlNodeList = nodeCommand.ChildNodes
                Result.EquipmentProperty = ReplyNodeList(0).Attributes.ItemOf("Property").InnerText
                Result.DecoderName = ReplyNodeList(0).Attributes.ItemOf("DecoderName").InnerText
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave CreateSingleReplyCommand")
            Return Result
        End Function
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-12 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Create an instance of SingleReplyCheckSumCommand from a xml command node
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Function CreateSingleReplyCheckSumCommand(ByVal nodeCommand As System.Xml.XmlNode) As TSCommand
            AVPLib.Log.terminalServerLogger.Info("Enter CreateSingleReplyCheckSumCommand")

            Dim Result As New TSSingleReplyCheckSumCommand()
            Try
                Result.IsInTransaction = GetTransactionAttribute(nodeCommand)

                Dim ReplyNodeList As System.Xml.XmlNodeList = nodeCommand.ChildNodes
                Result.EquipmentProperty = ReplyNodeList(0).Attributes.ItemOf("Property").InnerText
                Result.DecoderName = ReplyNodeList(0).Attributes.ItemOf("DecoderName").InnerText
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave CreateSingleReplyCheckSumCommand")
            Return Result
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-12 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Get In Transaction attribute value of a command node
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Function GetTransactionAttribute(ByVal nodeCommand As System.Xml.XmlNode) As Boolean
            AVPLib.Log.terminalServerLogger.Info("Enter GetTransactionAttribute")

            Dim Result As Boolean = False
            Try
                Dim TransAttributeNode As XmlAttribute = nodeCommand.Attributes.ItemOf("IsFullTransation")
                If (TransAttributeNode IsNot Nothing) Then
                    If (TransAttributeNode.InnerText = "True") Then
                        Result = True
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave GetTransactionAttribute")
            Return Result
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-12 </date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Get In Transaction attribute value of a command node
        ''' </summary>
        ''' <remarks></remarks>
        Private Shared Function GetCheckSumAttribute(ByVal ReplyCommand As System.Xml.XmlNode) As Boolean
            AVPLib.Log.terminalServerLogger.Info("Enter GetCheckSumAttribute")

            Dim Result As Boolean = False
            Try
                Dim CheckSumAttributeNode As XmlAttribute = ReplyCommand.Attributes.ItemOf("IsCheckSum")
                If (CheckSumAttributeNode IsNot Nothing) Then
                    If (CheckSumAttributeNode.InnerText = "True") Then
                        Result = True
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave GetCheckSumAttribute")
            Return Result
        End Function
#End Region
    End Class

End Namespace
