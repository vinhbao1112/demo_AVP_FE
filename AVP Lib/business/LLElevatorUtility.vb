Imports AVPLib.Communication.TerminalDriver
Namespace Business
    Public Class LLElevatorUtility
#Region "Public methods"
        Public Shared Function GetLLElevator(ByVal Name As String) As DataManagerment.LLElevator
            Return AVPLib.DataManagerment.EquipmentManager.GetEquipment(Name)
        End Function
        Public Shared Function ConfigureCassette(ByVal Name As String, ByVal cmd As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter ConfigureCassette")
            AVPLib.Log.coreLogger.Debug("Name=" + Name)
            Dim blnResult As Boolean = True
            Dim strMessage As String = String.Empty

            strMessage = Name + "." + cmd
            blnResult = TransactionManager.Run(strMessage)
            Threading.Thread.Sleep(2000)

            If blnResult Then
                ' send error request
                blnResult = LLElevatorUtility.CheckOnline(Name)
            End If
            AVPLib.Log.coreLogger.Info("Leave ConfigureCassette")
            Return blnResult
        End Function

        Public Shared Function ConfigureCassetteNumberOfSlot(ByVal Name As String, ByVal numberOfSlot As Integer) As Boolean
            Dim tb As Server = DataManagerment.ConfigurationManager.ConfigItemList.Item(Name)
            Dim strAppendText As String = String.Empty
            If (tb.Version <> "VC2") Then
                strAppendText = ","
            End If
            Dim cmd As String = GetLLElevator(Name).kNumberOfSlotsCmd & strAppendText & numberOfSlot.ToString()
            Return ConfigureCassette(Name, cmd)
        End Function

        Public Shared Function ConfigureCassettePitch(ByVal Name As String, ByVal pitch As Integer) As Boolean
            Dim tb As Server = DataManagerment.ConfigurationManager.ConfigItemList.Item(Name)
            Dim strAppendText As String = String.Empty
            If (tb.Version <> "VC2") Then
                strAppendText = ","
            End If
            Dim cmd As String = GetLLElevator(Name).kPitchCmd & strAppendText & pitch.ToString()
            Return ConfigureCassette(Name, cmd)
        End Function

        Public Shared Function ConfigureCassetteBaseOffset(ByVal Name As String, ByVal baseOffset As Integer) As Boolean
            Dim tb As Server = DataManagerment.ConfigurationManager.ConfigItemList.Item(Name)
            Dim strAppendText As String = String.Empty
            If (tb.Version <> "VC2") Then
                strAppendText = ","
            End If
            Dim cmd As String = GetLLElevator(Name).kBaseOffsetCmd & strAppendText & baseOffset.ToString()
            Return ConfigureCassette(Name, cmd)
        End Function

        Public Shared Function ConfigureCassetteTravelLength(ByVal Name As String, ByVal travelLength As Integer) As Boolean
            Dim tb As Server = DataManagerment.ConfigurationManager.ConfigItemList.Item(Name)
            Dim strAppendText As String = String.Empty
            If (tb.Version <> "VC2") Then
                strAppendText = ","
            End If
            Dim cmd As String = GetLLElevator(Name).kTravelLengthCmd & strAppendText & travelLength.ToString()
            Return ConfigureCassette(Name, cmd)
        End Function

        Public Shared Function ConfigureCassetteFindBias(ByVal Name As String, ByVal findBias As Integer) As Boolean
            Dim tb As Server = DataManagerment.ConfigurationManager.ConfigItemList.Item(Name)
            Dim strAppendText As String = String.Empty
            If (tb.Version <> "VC2") Then
                strAppendText = ","
            End If
            Dim cmd As String = GetLLElevator(Name).kFindBiasCmd & strAppendText & findBias.ToString()
            Return ConfigureCassette(Name, cmd)
        End Function
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-06</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Initialize elevator equipment
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function Initialize(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Initialize")
            AVPLib.Log.coreLogger.Debug("Name=" + Name)
            Try
                Dim blnResult As Boolean = True
                Dim ListElevator As ArrayList
                Dim strAppendText As String = ","
                Const maxSendEchoOff As Integer = 3
                'get connection 
                Dim tb As Server = DataManagerment.ConfigurationManager.ConfigItemList.Item(Name)
                'if Name = loadlock then add version to name to get Init config
                If Name = "LLAElevator" Then
                    ListElevator = ContainerData.GetInitConfig(Name & "_" & tb.Version.ToString())
                    If (tb.Version = "VC2") Then
                        strAppendText = String.Empty
                    End If
                Else
                    ListElevator = ContainerData.GetInitConfig(Name)
                End If

                For Each cmd As String In ListElevator
                    If blnResult Then
                        Dim strMessage As String = String.Empty
                        Dim objLLElvator As DataManagerment.LLElevator = GetLLElevator(Name)
                        With objLLElvator
                            If cmd.Contains(.kNumberOfSlotsCmd) Then
                                Dim idx As Integer = cmd.IndexOf(.kNumberOfSlotsCmd)
                                strMessage = Name & "." & cmd.Substring(0, idx + .kNumberOfSlotsCmd.Length) & strAppendText & ContainerData.GetLLElevatorConfig(ConstEnum.NUMBER_OF_SLOT)
                            ElseIf cmd.Contains(.kPitchCmd) Then
                                Dim idx As Integer = cmd.IndexOf(.kPitchCmd)
                                strMessage = Name & "." & cmd.Substring(0, idx + .kPitchCmd.Length) & strAppendText & ContainerData.GetLLElevatorConfig(ConstEnum.PITCH)
                            ElseIf cmd.Contains(.kBaseOffsetCmd) Then
                                Dim idx As Integer = cmd.IndexOf(.kBaseOffsetCmd)
                                strMessage = Name & "." & cmd.Substring(0, idx + .kBaseOffsetCmd.Length) & strAppendText & ContainerData.GetLLElevatorConfig(ConstEnum.BASE_OFFSET)
                            ElseIf cmd.Contains(.kTravelLengthCmd) Then
                                Dim idx As Integer = cmd.IndexOf(.kTravelLengthCmd)
                                strMessage = Name & "." & cmd.Substring(0, idx + .kTravelLengthCmd.Length) & strAppendText & ContainerData.GetLLElevatorConfig(ConstEnum.TRAVEL_LENGTH)
                            ElseIf cmd.Contains(.kFindBiasCmd) Then
                                Dim idx As Integer = cmd.IndexOf(.kFindBiasCmd)
                                strMessage = Name & "." & cmd.Substring(0, idx + .kFindBiasCmd.Length) & strAppendText & ContainerData.GetLLElevatorConfig(ConstEnum.FIND_BIAS)
                            ElseIf cmd.Contains(.kWaferThicknessType) Then
                                ' Add �S,SPS,MODE,THK� or �S,SPS,MODE,NOR� depending on configuration params call 
                                '�Wafer_Thickness_Type=Thick� �Wafer_Thickness_Type=Normal�.
                                Dim strCMD As String = ContainerData.GetLLElevatorConfig(ConstEnum.WAFER_THICKNESS_TYPE)
                                If strCMD.ToUpper() = "THICK" Then
                                    strCMD = "THK"
                                ElseIf strCMD.ToUpper() = "SMART" Then
                                    strCMD = "SMA"
                                Else 'default
                                    strCMD = "NOR"
                                End If
                                strMessage = Name & "." & cmd & strAppendText & strCMD
                            ElseIf cmd.Contains(.kEchoOffCmd) Then
                                '0008730: [TamHuynh - 11/19/2015] Send ECHO Off command to Elevator 3 times when initialize and re-initialize
                                For i As Integer = 1 To maxSendEchoOff - 1
                                    strMessage = Name + "." + cmd
                                    TransactionManager.Run(strMessage)
                                    Threading.Thread.Sleep(2000)
                                Next
                            Else
                                strMessage = Name + "." + cmd
                            End If
                        End With
                        blnResult = TransactionManager.Run(strMessage)
                        Threading.Thread.Sleep(2000)

                        If blnResult Then
                            ' send error request
                            blnResult = LLElevatorUtility.CheckOnline(Name)
                            If Not blnResult Then
                                Exit For
                            End If
                        End If
                    Else
                        Exit For
                    End If
                Next

                'Set Wafer Slide Out Detection
                If RobotConfigurationValues.CHECK_WAFER_SLIDE_OUT AndAlso _
                (Name = "LLAElevator" Or Name = "LLBElevator") AndAlso tb.Version = "VC2" Then
                    EnableWaferSlideOutDetection(Name)
                End If

                AVPLib.Log.coreLogger.Info("Leave Initialize")
                Return blnResult
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Initialize")
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2016-03-10 </date>
        ''' </author>
        ''' <summary>
        ''' RunTransaction
        ''' </summary>
        Public Shared Function RunTransaction(ByVal strMessage As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter RunTransaction")
            Try
                If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                    Return TransactionManager.Run(strMessage)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RunTransaction")
        End Function

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-04</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Check online
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CheckOnline(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckOnline")
            Try
                'Do not send pulling command when re-connect
                If CheckDoingReConnect(Name) Then
                    Return True
                End If

                Dim strMessage As String = Name + "." + "00,R,ER"
                AVPLib.Log.coreLogger.Info("Leave CheckOnline")
                Return TransactionManager.Run(strMessage, True, LLElevatorConfigurationValues.LLELEVATOR_TIMEOUT)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckOnline")
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-06</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Check door clamp status
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CheckDoorClampStatus(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckDoorClampStatus")
            Try
                Dim strMessage As String = Name + "." + "00,R,CS"
                AVPLib.Log.coreLogger.Info("Leave CheckDoorClampStatus")
                Return TransactionManager.Run(strMessage, True, LLElevatorConfigurationValues.LLELEVATOR_TIMEOUT)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckDoorClampStatus")
        End Function
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-04</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Check Cassette present
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CheckCassettePresent(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckCassettePresent")
            Try
                'Do not send pulling command when re-connect
                If CheckDoingReConnect(Name) Then
                    Return True
                End If

                Dim strMessage As String = Name + "." + "00,R,W2"
                AVPLib.Log.coreLogger.Info("Leave CheckCassettePresent")
                Return TransactionManager.Run(strMessage, True, LLElevatorConfigurationValues.LLELEVATOR_TIMEOUT)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckCassettePresent")
        End Function

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-04</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Check online
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CheckOperationStatus(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckOperationStatus")
            Try
                'Do not send pulling command when re-connect
                If CheckDoingReConnect(Name) Then
                    Return True
                End If

                Dim strMessage As String = Name + "." + "00,R,OS"
                AVPLib.Log.coreLogger.Info("Leave CheckOperationStatus")
                Return TransactionManager.Run(strMessage, True, LLElevatorConfigurationValues.LLELEVATOR_TIMEOUT)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckOperationStatus")
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2016-03-25 </date>
        ''' </author>
        ''' <summary>
        ''' CheckWaferSlideOut
        ''' </summary>
        Public Shared Function CheckWaferSlideOut(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckWaferSlideOut")
            Try
                Dim strMessage As String = Name + "." + "00,R,SO"
                AVPLib.Log.coreLogger.Info("Leave CheckWaferSlideOut")
                Return TransactionManager.Run(strMessage, True, LLElevatorConfigurationValues.LLELEVATOR_TIMEOUT)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckWaferSlideOut")
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2016-03-25 </date>
        ''' </author>
        ''' <summary>
        ''' EnableWaferSlideOutDetection
        ''' </summary>
        Public Shared Function EnableWaferSlideOutDetection(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter EnableWaferSlideOutDetection")
            Try
                Dim strMessage As String = Name + "." + "00,S,WSY"
                AVPLib.Log.coreLogger.Info("Leave EnableWaferSlideOutDetection")
                Return TransactionManager.Run(strMessage, True, LLElevatorConfigurationValues.LLELEVATOR_TIMEOUT)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave EnableWaferSlideOutDetection")
        End Function

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-04</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Go to slot
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="Slot"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GotoSlot(ByVal Name As String, ByVal Slot As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GotoSlot")
            Try
                Dim strMessage As String = Name + "." + "00,A,GO," + Slot
                AVPLib.Log.coreLogger.Info("Leave GotoSlot")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GotoSlot")
        End Function

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-29</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Home
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function Home(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Home")
            Try
                Dim strMessage As String = Name + "." + "00,A,HM"
                AVPLib.Log.coreLogger.Info("Leave Home")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Home")
        End Function

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-29</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Map
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function Map(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Map")
            Try
                Dim strMessage As String = Name + "." + "00,A,MP"
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[LogLoad]- Map " & strMessage)
                AVPLib.Log.coreLogger.Info("Leave Map")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Map")
        End Function

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-29</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Map
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function RequestMappedInfo(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter RequestMappedInfo")
            Try
                Dim strMessage As String = Name + "." + "00,R,MI"
                AVPLib.Log.coreLogger.Info("Leave RequestMappedInfo")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RequestMappedInfo")
        End Function

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-29</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Open
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function Open(ByVal Name As String, Optional ByVal IsCheckSafety As Boolean = False, Optional ByRef strErrorMsg As String = "") As Boolean
            AVPLib.Log.coreLogger.Info("Enter Open")
            Try
                If (IsCheckSafety) Then
                    'Check loadlock Rough Opened
                    Dim LLName As String = ConstEnum.Equipments.LoadLockA.ToString
                    Dim objLoadlock As DataManagerment.LoadLock = DataManagerment.EquipmentManager.GetEquipment(LLName)
                    If (objLoadlock IsNot Nothing) Then
                        If (RobotConfigurationValues.LL_SLOW_ROUGH_INSTALLED AndAlso objLoadlock.SlowRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                            strErrorMsg = LLName & " Slow Rough valve is opened."
                            Exit Try
                        End If

                        If (objLoadlock.FastRoughValveStatus = DataManagerment.Equipment.WorkingStatuses.On) Then
                            strErrorMsg = LLName & " Fast Rough valve is opened."
                            Exit Try
                        End If
                    End If
                End If

                Dim strMessage As String = Name + "." + "00,A,DO"
                AVPLib.Log.coreLogger.Info("Leave Open")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Open")
        End Function

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-29</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Open
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function Close(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Close")
            Try
                Dim strMessage As String = Name + "." + "00,A,DC"
                AVPLib.Log.coreLogger.Info("Leave Close")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Close")
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-08-28</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Go to slot and check wafer at slot slotID
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function GoCheck(ByVal Name As String, ByVal slotID As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GoCheck")
            Try
                Dim strMessage As String = Name + "." + "00,A,GC," & slotID
                AVPLib.Log.coreLogger.Info("Leave GoCheck")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GoCheck")
            Return False
        End Function
        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2012-08-28</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Go to slot and check wafer at slot slotID
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function CheckWaferPresent(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckWaferPresent")
            Try
                Dim strMessage As String = Name + "." + "00,R,WP"
                AVPLib.Log.coreLogger.Info("Leave CheckWaferPresent")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckWaferPresent")
            Return False
        End Function
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-29</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Reset
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function Reset(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Reset")
            Try
                Dim strMessage As String = Name + "." + "00,S,ER"
                AVPLib.Log.coreLogger.Info("Leave Reset")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Reset")
        End Function
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-12-04</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Do Serial Command
        ''' </summary>
        ''' <param name="Command"></param>
        ''' <remarks></remarks>
        Public Shared Function DoSerialCommand(ByVal Command As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DoSerialCommand")
            Try
                AVPLib.Log.coreLogger.Info("Leave DoSerialCommand")
                Return TransactionManager.Run(Command)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoSerialCommand")
        End Function
        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2009-06-11</date>
        ''' </author>
        ''' <summary>
        ''' Return string of Wafer in LL, to update SECS/GEM
        ''' </summary>
        ''' <param name="LoadLockEquipment"></param>
        ''' <remarks></remarks>
        Public Shared Function GenerateWaferMappingInfo(ByVal listWaferInfo As AVPWaferInfo(), ByVal MapGEMWaferID As Dictionary(Of String, String), ByVal strWaferIDPrefix As String) As String
            AVPLib.Log.coreLogger.Info("Enter GenerateWaferMappingInfo")
            Dim result As String = "<WaferMap>"
            Try
                For i As Integer = 0 To listWaferInfo.Length - 1
                    result &= "<Wafer><SlotNumber>" & (i + 1).ToString()
                    If (listWaferInfo(i) Is Nothing) Then
                        result &= "</SlotNumber><WaferID>"
                        result &= "</WaferID>"
                        result &= "<OccupancyState>"
                        result &= "Unoccupied"
                    Else

                        Dim GEMID As String = strWaferIDPrefix & Format(i + 1, "00")
                        If MapGEMWaferID.ContainsKey(GEMID) Then
                            GEMID = MapGEMWaferID.Item(GEMID)
                        End If
                        If String.IsNullOrEmpty(GEMID) Then
                            GEMID = strWaferIDPrefix & Format(i + 1, "00")
                        End If
                        ''convert AVP Wafer ID to GEM ID
                        result &= "</SlotNumber><WaferID>" & GEMID
                        result &= "</WaferID><OccupancyState>"
                        result &= "Occupied"
                    End If
                    result &= "</OccupancyState> </Wafer>"
                Next
                result &= "</WaferMap>"
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return result
            AVPLib.Log.coreLogger.Info("Leave GenerateWaferMappingInfo")
        End Function

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2015-06-10</date>
        ''' </author>
        ''' <summary>
        ''' CheckDoingReConnect
        ''' </summary>
        ''' <param p_strName = "LLAElevator" or "LLBElevator"></param>
        ''' <remarks></remarks>
        Public Shared Function CheckDoingReConnect(ByVal p_strName As String) As Boolean
            Try
                Dim strLLName As String = ConstEnum.Equipments.LoadLockA.ToString
                Dim ctrLoadLock As LoadLockController = CType(ControllerManager.GetController(strLLName), LoadLockController)
                If ctrLoadLock IsNot Nothing Then
                    Dim objLLElevatorController As LLElevatorController = CType(ctrLoadLock.ChildController.Item("LLElevator"), LLElevatorController)

                    If objLLElevatorController IsNot Nothing AndAlso objLLElevatorController.IsDoingReConnect Then
                        Return True
                    End If
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return False
        End Function


#End Region
    End Class
End Namespace

