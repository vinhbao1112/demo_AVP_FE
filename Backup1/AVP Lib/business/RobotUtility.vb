Imports AVPLib.Communication.TerminalDriver
Namespace Business
    Public Class RobotUtility
#Region "Public method"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-27</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Initialize robot equipment
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function Initialize(ByVal Name As String, ByRef GoHome As Boolean, ByRef GoToFirstStation As Boolean) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Initialize")
            Try
                GoHome = False
                GoToFirstStation = False
                Const kHomeAllCmd As String = "HOME ALL"
                Const kGoToFirstStationCmd As String = "GOTO N 1"
                Dim blnResult As Boolean = True
                Dim ListRobotCmds As ArrayList = ContainerData.GetInitConfig(ConstEnum.Equipments.Robot.ToString())
                For Each RobotCmd As String In ListRobotCmds
                    If blnResult Then
                        Dim strMessage As String = Name + "." + RobotCmd
                        If RobotCmd = kHomeAllCmd Then ''if robot go home, timeout =60s
                            blnResult = TransactionManager.Run(strMessage, True, SYSTEM_CONFIG_TIMEOUT_VALUES.ROBOT_GOHOME_TIMEOUT)
                            GoHome = blnResult
                        Else
                            blnResult = TransactionManager.Run(strMessage)
                        End If

                        If blnResult Then
                            If (RobotCmd = kGoToFirstStationCmd) Then
                                GoToFirstStation = True
                            End If
                        End If
                    Else
                        Exit For
                    End If
                Next
                AVPLib.Log.coreLogger.Info("Leave Initialize")
                Return blnResult
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Initialize")
        End Function

        Public Shared Function ResendInitParam(ByVal Name As String)
            AVPLib.Log.coreLogger.Info("Enter Initialize")
            Try
                Dim blnResult As Boolean = True
                Dim ListRobotCmds As ArrayList = ContainerData.GetInitConfig(ConstEnum.Equipments.Robot.ToString())
                Const kHomeAllCmd As String = "HOME ALL"
                Const kGoToFirstStationCmd As String = "GOTO N 1"

                For Each RobotCmd As String In ListRobotCmds
                    If (String.Equals(RobotCmd, kHomeAllCmd) = False And String.Equals(RobotCmd, kGoToFirstStationCmd) = False) Then
                        If blnResult Then
                            Dim strMessage As String = Name + "." + RobotCmd

                            blnResult = TransactionManager.Run(strMessage)

                        Else
                            Exit For
                        End If
                    End If

                Next
                AVPLib.Log.coreLogger.Info("Leave Initialize")
                Return blnResult
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Initialize")
            Return False
        End Function
        ''' <author>
        '''    	<name> Tien Dat, Nguyen </name>
        '''    	<date> 2009-07-06</date>
        ''' </author>
        ''' <summary>
        ''' Execute a command in a Robot Transaction.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function ExecuteCommand(ByVal Name As String, ByVal command As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter ExecuteCommand")
            Try
                Dim strMessage As String = Name & "." & command
                Return TransactionManager.Run(strMessage, True, LLElevatorConfigurationValues.LLELEVATOR_TIMEOUT)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ExecuteCommand")
            Return False
        End Function

        Public Shared Function GetStationLocation(ByVal agentName As String) As String
            Return AVPLib.ContainerData.GetRobotConfig(agentName)
        End Function

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-27</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Pick wafer to station
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function PickWaferFromStation(ByVal Name As String, ByVal Station As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter PickWaferFromStation")
            Try
                Dim strMessage As String = Name + "." + "PICK " + Station
                AVPLib.Log.coreLogger.Info("Leave PickWaferFromStation")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave PickWaferFromStation")
        End Function

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-04</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-27</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Place wafer to station
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function PlaceWaferToStation(ByVal Name As String, ByVal Station As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter PlaceWaferToStation")
            Try
                Dim strMessage As String = Name + "." + "PLACE " + Station
                AVPLib.Log.coreLogger.Info("Leave PlaceWaferToStation")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave PlaceWaferToStation")
        End Function
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-14</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Check communication is alive
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function CheckComunicationAlive(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckComunicationAlive")
            Try
                'Do not send pulling command when re-connect
                Dim objRobotController As RobotController = ControllerManager.GetController(Name)
                If objRobotController.IsDoingReConnect Then
                    Return True
                End If

                Dim strMessage As String = Name + "." + "HLLO"
                AVPLib.Log.coreLogger.Info("Leave CheckComunicationAlive")
                Return TransactionManager.Run(strMessage, True)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckComunicationAlive")
        End Function

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-14</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Check communication is alive
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function GetRetractedStatus(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetRetractedStatus")
            Try
                Dim strMessage As String = Name + "." + "RQ POS ABS ALL"
                AVPLib.Log.coreLogger.Info("Leave GetRetractedStatus")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetRetractedStatus")
        End Function
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2011-01-21</date>
        ''' </author>
        ''' <summary>
        ''' Check Real Position Robot.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function GetRobotPositionStatus(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GetRobotPositionStatus")
            Try
                'Do not send pulling command when re-connect
                Dim objRobotController As RobotController = ControllerManager.GetController(Name)
                If objRobotController.IsDoingReConnect Then
                    Return True
                End If

                Dim strMessage As String = Name + "." + "RQ POS STN ALL"
                AVPLib.Log.coreLogger.Info("Leave GetRobotPositionStatus")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GetRobotPositionStatus")
        End Function
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-27</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Home
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function Home(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Home")
            Try
                Dim strMessage As String = Name + "." + "HOME ALL"
                AVPLib.Log.coreLogger.Info("Leave Home")

                'DATCAO CHANGE HERE
                'IF ROBOT GO HOME, TIMEOUT = 60s
                Dim blnResult As Boolean = TransactionManager.Run(strMessage, True, SYSTEM_CONFIG_TIMEOUT_VALUES.ROBOT_GOHOME_TIMEOUT)
                ''this code for request:-AVP Robot 7.2.  Did not send “SET LOAD A OFF” to robot when user click on home button.
                If RobotConfigurationValues.ROBOT_VERSION_CONFIG <= AVPLib.ConstEnum.ROBOT_VERSION_7_1 Then ''check sensor by software
                    Return blnResult
                Else
                    strMessage = Name + "." + "SET LOAD A OFF"
                    'blnResult = TransactionManager.Run(strMessage)
                    TransactionManager.Run(strMessage)
                End If
                Return blnResult
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Home")
            Return False
        End Function

        Public Shared Function TurnOnWaferSensorChecking(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter TurnOnWaferSensorChecking")
            Try
                Dim strMessage As String = Name + "." + "SET INTLCK WAF_SEN Y"

                ''this code for request:-AVP Robot 7.2.  send command to robot: SET INTLCK WAF_SEN Y.
                If RobotConfigurationValues.ROBOT_VERSION_CONFIG <= AVPLib.ConstEnum.ROBOT_VERSION_7_1 OrElse _
                   Not ContainerData.GetResetRobotInterlockCommand() Then ''check sensor by software
                    AVPLib.Log.coreLogger.Info("Leave TurnOnWaferSensorChecking")
                    Return True
                Else
                    AVPLib.Log.coreLogger.Info("Leave TurnOnWaferSensorChecking")
                    Return TransactionManager.Run(strMessage)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOnWaferSensorChecking")
            Return False
        End Function

        Public Shared Function TurnOffWaferSensorChecking(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter TurnOffWaferSensorChecking")
            Try
                Dim strMessage As String = Name + "." + "SET INTLCK WAF_SEN N"

                ''this code for request:-AVP Robot 7.2.  send command to robot: SET INTLCK WAF_SEN N.
                If RobotConfigurationValues.ROBOT_VERSION_CONFIG <= AVPLib.ConstEnum.ROBOT_VERSION_7_1 OrElse _
                   Not ContainerData.GetResetRobotInterlockCommand() Then ''check sensor by software
                    AVPLib.Log.coreLogger.Info("Leave TurnOffWaferSensorChecking")
                    Return True
                Else
                    AVPLib.Log.coreLogger.Info("Leave TurnOffWaferSensorChecking")
                    Return TransactionManager.Run(strMessage)
                End If

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave TurnOffWaferSensorChecking")
            Return False
        End Function


        Public Shared Function GoToFirstStation(ByVal robotName As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GoToFirstStation")
            Try
                Dim strMessage As String = robotName + "." + "GOTO N 1"
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GoToFirstStation")
            Return False
        End Function

        Public Shared Function GoToNStation(ByVal robotName As String, ByVal N_Station As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter GoToFirstStation")
            Try
                Dim strMessage As String = robotName + "." + "GOTO N " + N_Station
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave GoToFirstStation")
            Return False
        End Function

        Public Shared Function DeleteRobotWafer(ByVal robotName As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter DeleteRobotWafer")
            Try
                Dim strMessage As String = robotName + "." + "SET LOAD A OFF"
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DeleteRobotWafer")
            Return False
        End Function

        Public Shared Function CreateRobotWafer(ByVal robotName As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CreateRobotWafer")
            Try
                Dim strMessage As String = robotName + "." + "SET LOAD A ON"
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CreateRobotWafer")
            Return False
        End Function


        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-12-05</Date>
        '''		<Description>Implementation</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Do Serial Command RobotController
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
        '''    	<name> Le Hieu Truc</name>
        '''    	<date> 2009-10-08</date>
        ''' </author>
        ''' <summary>
        ''' Check Robot Retract
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function IsRobotRetract() As Boolean
            AVPLib.Log.coreLogger.Info("Enter IsRobotRetract")
            Dim ctlRobot As Business.RobotController = CType(AVPLib.Business.ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), AVPLib.Business.RobotController)
            Dim Robot As DataManagerment.Robot = DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

            If ctlRobot.GetRetractedStatus() Then
                Return Robot.IsRetracted
            Else
                Return False
            End If

            AVPLib.Log.coreLogger.Info("Leave IsRobotRetract")
        End Function

        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Arm up (base on command Goto Station with Offset)
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function ArmUp(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter ArmUp")
            Dim strMessage As String = Equipment + "." + "GOTO Z UP"
            Return TransactionManager.Run(strMessage)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                      AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                      "Move arm up")
            AVPLib.Log.coreLogger.Info("Leave ArmUp")
        End Function
        ''' <author>
        '''    	<name> Truc Le</name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Arm Down (base on command Goto Station with Offset)
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function ArmDown(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter ArmDown")
            Dim strMessage As String = Equipment + "." + "GOTO Z DN"
            Return TransactionManager.Run(strMessage)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                      AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                      "Move arm down")
            AVPLib.Log.coreLogger.Info("Leave ArmDown")
        End Function

        ''' <author>
        '''    	<name> Truc Le </name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Arm Extend ((base on command Goto Station with Offset)
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function ArmExtend(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter ArmExtend")
            Dim strErrMsg As String = String.Empty
            Dim strMessage As String = Equipment + "." + "GOTO R EX"
            Return TransactionManager.Run(strMessage)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                     AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                     "Move arm extend")
            AVPLib.Log.coreLogger.Info("Leave ArmExtend")
            Return strErrMsg
        End Function
        ''' <author>
        '''    	<name> Truc Le</name>
        '''    	<date> 2008-12-11</date>
        ''' </author>
        ''' <summary>
        ''' Arm up
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function ArmRetract(ByVal Equipment As String) As String
            AVPLib.Log.coreLogger.Info("Enter ArmRetract")
            Dim strErrMsg As String = String.Empty
            Dim strMessage As String = Equipment + "." + "GOTO R RE"
            Return TransactionManager.Run(strMessage)
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                     AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                     "Move arm retract")
            AVPLib.Log.coreLogger.Info("Leave ArmRetract")
            Return strErrMsg
        End Function

        ''' <author>
        '''    	<name> Tinh Le</name>
        '''    	<date> 2020-11-10</date>
        ''' </author>
        ''' <summary>
        ''' Arm Station VEL ACC 
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function ArmStationVELACC(ByVal Equipment As String, ByVal cmd As String) As String
            AVPLib.Log.coreLogger.Info("Enter ArmStationVELACC")
            Dim strErrMsg As String = String.Empty
            Try
                Dim strMessage As String = Equipment + "." + cmd
                Return TransactionManager.Run(strMessage)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                                         AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                                         "Robot config")
                AVPLib.Log.coreLogger.Info("Leave ArmStationVELACC")
            Catch ex As Exception

            End Try
            Return strErrMsg
        End Function
#End Region
    End Class
End Namespace

