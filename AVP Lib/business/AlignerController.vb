Imports AVPLib.DataManagerment
Imports AVPLib.ConstEnum
Imports AVPLib.Communication.TerminalDriver
Imports System.Threading
Namespace Business
    Public Class AlignerController
        Inherits ControllerObject

        Private m_tmrLinkTest As System.Timers.Timer
        Private Const POST_POSITION_COEFFICENT As Integer = 10
        Private m_IsRequestRevition As Boolean = True


        Public Property LinkTestInterval() As Integer
            Get
                Return m_tmrLinkTest.Interval
            End Get
            Set(ByVal value As Integer)
                Dim blnIsStart = m_tmrLinkTest.Enabled
                m_tmrLinkTest.Enabled = False
                m_tmrLinkTest.Interval = value
                If (blnIsStart) Then
                    m_tmrLinkTest.Enabled = True
                End If
            End Set
        End Property

#Region "Public method"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-10-13 </date>
        ''' </author>
        ''' <summary>
        ''' Inititialize Aligner
        ''' </summary>
        ''' <remarks></remarks>
       Public Sub New()
            m_tmrLinkTest = New System.Timers.Timer
            AddHandler m_tmrLinkTest.Elapsed, AddressOf SendLinkTest
            m_tmrLinkTest.Interval = 2000
        End Sub

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2011-12-13 </date>
        ''' </author>
        ''' <summary>
        ''' Dispose Aligner Object
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Sub Dispose()
            AVPLib.Log.coreLogger.Info("Enter Dispose")
            Try
                m_tmrLinkTest.Enabled = False
                RemoveHandler m_tmrLinkTest.Elapsed, AddressOf SendLinkTest
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Dispose")
        End Sub

        Public Sub InitializeProc()
            ThreadPool.QueueUserWorkItem(AddressOf ReInitialize, Nothing)
        End Sub

        Private Sub ReInitialize(ByVal state As Object)
            ReInitialize()
        End Sub

        Public Sub ReInitialize()
            AVPLib.Log.coreLogger.Info("Enter Initialize")
            Try
                DeltaPickMaxRetry = ContainerData.GetIntegerFromKeyValueInRobotConfig(ConstEnum.DELTA_PICK_MAX_RETRY, 3)
                AlignerCDDPosition = ContainerData.GetIntegerFromKeyValueInRobotConfig(ConstEnum.ALIGNER_CDD_POSITION, 900)

                If (Not AlignerUtility.ReInitialize(EquipmentName)) Then
                    Dim arrPropertyNames As New ArrayList()
                    arrPropertyNames.Add("OperationStatus")
                    arrPropertyNames.Add("ErrorMessage")
                    Dim arrValues As New ArrayList()
                    arrValues.Add(Equipment.OperationStatuses.ERROR)
                    arrValues.Add(Utils.GetMessageError("ErrInit"))
                    EquipmentManager.ChangeStatus(EquipmentName, arrPropertyNames, arrValues)
                End If
                ' Always does.
                IsDoingReConnect = False
                m_tmrLinkTest.Enabled = True 'Start pulling
                m_IsRequestRevition = True
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Initialize")
        End Sub

        Public Overrides Sub ReconnectHandle(ByVal obj As Object, ByVal e As ReconnectEventArgs)
            If m_strEquipmentName = e.EquipName Then
                'Re-Init if need
                IsDoingReConnect = True
                m_tmrLinkTest.Enabled = False 'Start pulling
                InitializeProc()
            End If
        End Sub

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-05 </date>
        ''' </author>
        ''' <summary>
        ''' Inititialize Robot
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Initialize()
            AVPLib.Log.coreLogger.Info("Enter Initialize")
            Try
                DeltaPickMaxRetry = ContainerData.GetIntegerFromKeyValueInRobotConfig(ConstEnum.DELTA_PICK_MAX_RETRY, 3)
                AlignerCDDPosition = ContainerData.GetIntegerFromKeyValueInRobotConfig(ConstEnum.ALIGNER_CDD_POSITION, 900)
                If (Not AlignerUtility.Initialize(EquipmentName)) Then
                    Dim arrPropertyNames As New ArrayList()
                    arrPropertyNames.Add("OperationStatus")
                    arrPropertyNames.Add("ErrorMessage")
                    Dim arrValues As New ArrayList()
                    arrValues.Add(Equipment.OperationStatuses.ERROR)
                    arrValues.Add(Utils.GetMessageError("ErrInit"))
                    EquipmentManager.ChangeStatus(EquipmentName, arrPropertyNames, arrValues)
                End If
                
                ' Always does.
                m_tmrLinkTest.Enabled = True 'Start pulling
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Initialize")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-14</Date>
        '''		<Description>implement</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Do tasks of robot
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <remarks></remarks>
        Public Overrides Sub DoTask(ByVal Message As String)
            AVPLib.Log.coreLogger.Info("Enter DoTask")
            Try
                Dim arrCmd As Array = Message.Split(" ")
                Dim CmdParam As Object = Nothing
                If arrCmd.Length > 1 Then
                    CmdParam = arrCmd(1)
                    Message = arrCmd(0)
                End If
                Select Case Message
                    Case "Home"
                        AlignerUtility.Home(EquipmentName)
                    Case "Align"
                        ''as Khoi request 11 July 2012
                        If SetPostPosition(CmdParam.ToString()) Then
                            'Send Align Command
                            AlignerUtility.Align(EquipmentName)
                        End If
                    Case "Scan"
                        Me.Scan()
                End Select
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            ActionCMDSent = True
            AVPLib.Log.coreLogger.Info("Leave DoTask")
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Do Serial Command AlignerController
        ''' </summary>
        ''' <param name="Command"></param>
        ''' <remarks></remarks>
        Public Overrides Sub DoSerialCommand(ByVal Command As String)
            AVPLib.Log.coreLogger.Info("Enter DoSerialCommand")
            Try
                AlignerUtility.DoSerialCommand(Command)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave DoSerialCommand")
        End Sub

        ''' <author>
        '''    	<name> Tien Dat, Nguyen </name>
        '''    	<date> 2009-07-06</date>
        ''' </author>
        ''' <summary>
        ''' Set Post Position.
        ''' </summary>
        ''' <remarks></remarks>
        Private Function SetPostPosition(ByVal pos As Single) As Boolean
            AVPLib.Log.coreLogger.Info("Enter SetPostPosition")
            Dim strCommand As String = "LDPS 1 " + ((pos * POST_POSITION_COEFFICENT)).ToString()
            ' Should check Equipment.OperationStatuses.ERROR
            AVPLib.Log.coreLogger.Info("Leave SetPostPosition")
            Return AlignerUtility.ExecuteCommand(EquipmentName, strCommand)
        End Function

        '--------------------Standard Sample Aligner Recipe ---------------------------------
        '<Recipe>
        '    <StepList>
        '        <Step>
        '            <SeqNo>1</SeqNo>
        '            <StepName>0 Degree</StepName>
        '            <StepDescription>Align</StepDescription>
        '            <Angle>0</Angle>
        '        </Step>
        '    </StepList>
        '</Recipe>---------------------------------------------------------------------------
        ''' <author>
        '''    	<name> Tien Dat, Nguyen </name>
        '''    	<date> 2009-07-06</date>
        ''' </author>
        ''' <summary>
        ''' Run a recipe.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function RunRecipe(ByVal recipePath As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter RunRecipe")
            Dim objAligner As DataManagerment.Aligner = EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
            ''TrucLe modified here
            Dim recipeName As String = Utils.GetFileName(recipePath, True)
            If String.IsNullOrEmpty(recipeName) Then 'We should do as before, just send ALIGN command.
                ''''Dat V turn off this code -
                'If Not AlignerUtility.Align(EquipmentName) Then
                '    Utils.ThrowAlarm("Failed To align wafer.")
                '    AVPLib.Log.coreLogger.Info("Leave RunRecipe")
                '    Return False
                'End If
                AVPLib.Log.coreLogger.Info("Leave RunRecipe")
                Return True
            End If
            If Not System.IO.File.Exists(recipePath) Then
                Utils.ThrowAlarm(String.Format("Run Recipe On Aligner: Recipe File {0 } Not Found.", recipePath))
                AVPLib.Log.coreLogger.Info("Leave RunRecipe")
                Return False
            End If
            Dim recipe As AlignerRecipe = New AlignerRecipe(recipePath)
            If (Not recipe.IsValid) Then
                Utils.ThrowAlarm(String.Format("Run Recipe On Aligner: Invalid Data In Recipe File {0}.", recipePath))
                AVPLib.Log.coreLogger.Info("Leave RunRecipe")
                Return False
            End If
            If (recipe.NumberOfSteps = 0) Then
                Utils.ThrowAlarm(String.Format("Run Recipe On Aligner: No Steps Found In Recipe File {0}.", recipePath))
                AVPLib.Log.coreLogger.Info("Leave RunRecipe")
                Return False
            End If
            Dim pos As Single = recipe.GetSingleFromString(recipe.GetStepValue(1, "Angle"), 0)
            objAligner.WaferAlignAngle = pos
            AVPLib.Log.schedulerLogger.Debug("ALIGNER: Set Post Position - POS=" & pos)
            If Not Me.SetPostPosition(pos) Then
                ' Failed to make LDPS for Aligner.
                Utils.ThrowAlarm(String.Format("Run Recipe On Aligner: Couldn't Set Pos {0} Position.", pos))
                AVPLib.Log.coreLogger.Info("Leave RunRecipe")
                Return False
            End If
            AVPLib.Log.schedulerLogger.Debug("ALIGNER: executing ALIGN.")
            If Not AlignerUtility.Align(EquipmentName) Then
                Utils.ThrowAlarm("Run Recipe On Aligner: Failed To align wafer.")
                AVPLib.Log.coreLogger.Info("Leave RunRecipe")
                Return False
            End If
            Try
                'Get recipe Name
                objAligner.RecipeNameWaferInfo = AVPLib.Utils.GetFileName(recipePath, True)
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error("Couldn't send Recipe name onto GUI layer, error: " & ex.Message)
            End Try
            AVPLib.Log.coreLogger.Info("Leave RunRecipe")
            Return True
        End Function

        ''' <author>
        '''    	<name> Tien Dat, Nguyen </name>
        '''    	<date> 2009-07-06</date>
        ''' </author>
        ''' <summary>
        ''' Scan.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function Scan() As Boolean
            AVPLib.Log.coreLogger.Info("Enter Scan")
            Dim objAligner As DataManagerment.Aligner = EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
            Dim strCommand As String = "SCAN"
            AVPLib.Log.schedulerLogger.Debug("ALIGNER: executing SCAN.")
            If Not AlignerUtility.ExecuteCommand(EquipmentName, strCommand) Then
                ' Failed to make SCAN for Aligner.
                AVPLib.Log.coreLogger.Info("Leave Scan")
                Return False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' This command - RSLT will be run under Aligner Transaction
            ' And those below properties will be set. 
            ' The result of this command is array of six (five) elements.
            ' RSLTAngularLocation = resultArray[1]
            ' RSLTEccentricityAngle = resultArray[2]
            ' RSLTMaxEccentricity = resultArray[3]
            ' RSLTAvgCCD = resultArray[4]
            ' RSLTReScanNeed = (resultArray(5).ToString = "N"? False : True) 
            ' If (resultArray.Length = 7) Then
            '   RSLTTypeCode =  resultArray[6]
            ' End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            strCommand = "RSLT"
            AVPLib.Log.schedulerLogger.Debug("ALIGNER: executing RSLT.")
            If Not AlignerUtility.ExecuteCommand(EquipmentName, strCommand) Then
                ' Failed to make RSLT for Aligner.
                AVPLib.Log.coreLogger.Info("Leave Scan")
                Return False
            End If
            AVPLib.Log.coreLogger.Info("Leave Scan")
            Return True
        End Function

        ''' <author>
        '''    	<name> Tien Dat, Nguyen </name>
        '''    	<date> 2009-07-06</date>
        ''' </author>
        ''' <summary>
        ''' Check if we configure to use Delta Pick or not.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function IsDeltaPickNeeded() As Boolean
            AVPLib.Log.coreLogger.Info("Enter IsDeltaPickNeeded")
            ' Read this value from configuration file
            Try
                Dim objPickNeeded As Object = AVPLib.ContainerData.GetRobotConfig(ConstEnum.DELTA_PICK_NEEDED)
                If (objPickNeeded Is Nothing) Then
                    AVPLib.Log.coreLogger.Info("Leave IsDeltaPickNeeded")
                    Return False
                End If
                Dim bRet As Boolean = False
                bRet = IIf(objPickNeeded.ToString() = "1", True, False)
                AVPLib.Log.coreLogger.Info("Leave IsDeltaPickNeeded")
                Return bRet

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave IsDeltaPickNeeded")
            Return False
        End Function

        ' This value should read from configuration file.
        Public Shared DeltaPickMaxRetry As Integer = 3

        ' This value should read from configuration file.
        Public Shared AlignerCDDPosition As Single = 900

        ''' <author>
        '''    	<name> Tien Dat, Nguyen </name>
        '''    	<date> 2009-07-06</date>
        ''' </author>
        ''' <summary>
        ''' Make Aligner Calculation.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function MakeAlignerCalculation() As Boolean
            Try
                Dim objAligner As DataManagerment.Aligner = EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                Dim objRobot As DataManagerment.Robot = EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

                Dim ECC_Traw As Double = objAligner.RSLTEccentricityAngle
                Dim ECC_Rraw As Double = objAligner.RSLTMaxEccentricity

                'ECC_Traw = (ECC_Traw - 900 +3600) MOD 3600.  The number 900 need to be configure and it is call the "AlignerCDDPosition".
                ECC_Traw = (((ECC_Traw - AlignerCDDPosition + 3600) Mod 3600))
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, ECC_Traw = (ECC_Traw - AlignerCDDPosition + 3600) MOD 3600 orgVal=" & objAligner.RSLTEccentricityAngle.ToString() & ", newVal=" & ECC_Traw.ToString())
                'ECC_Tflange = Math.PI - (ECC_Traw / 10.0F) * (Math.PI / 180.0F)
                Dim ECC_Tflange As Double = (Math.PI - ((ECC_Traw / 10.0F) * (Math.PI / 180.0F)))
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, ECC_Tflange = Math.PI - (ECC_Traw / 10.0F) * (Math.PI / 180.0F)=" & ECC_Tflange.ToString())
                'ECC_R = (ECC_Rraw / 10.0F) * 25.4F
                Dim ECC_R As Double = ((ECC_Rraw / 10.0F) * 25.4F)
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, ECC_R = (ECC_Rraw / 10.0F) * 25.4F=" & ECC_R.ToString())

                Dim AlStn_Traw As Double = objRobot.ReqAlStn_Traw
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, AlStn_Traw = objRobot.ReqAlStn_Traw=" & AlStn_Traw.ToString())
                Dim AlStn_R As Double = objRobot.ReqAlStn_R
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, AlStn_R = objRobot.ReqAlStn_R" & AlStn_R.ToString())

                'AlStn_Tabsolute = 2 * Math.PI - (AlStn_Traw / 1000.0F) * Math.PI / 180.0F
                Dim AlStn_Tabsolute As Double = (2 * Math.PI - (((AlStn_Traw / 1000.0F) * Math.PI) / 180.0F))
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, AlStn_Tabsolute = 2 * Math.PI - (AlStn_Traw / 1000.0F) * Math.PI / 180.0F=" & AlStn_Tabsolute.ToString())

                'ECC_Tabsolute = ECC_Tflange - Math.PI / 2 + AlStn_Tabsolute
                Dim ECC_Tabsolute As Double = ((ECC_Tflange - Math.PI / 2) + AlStn_Tabsolute)
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, ECC_Tabsolute = ECC_Tflange - Math.PI / 2 + AlStn_Tabsolute=" & ECC_Tabsolute.ToString())
                'ECC_X = ECC_R * Math.Cos(ECC_Tabsolute)
                Dim ECC_X As Double = (ECC_R * Math.Cos(ECC_Tabsolute))
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, ECC_X = ECC_R * Math.Cos(ECC_Tabsolute)=" & ECC_X.ToString())

                'ECC_Y = ECC_R * Math.Sin(ECC_Tabsolute)
                Dim ECC_Y As Double = (ECC_R * Math.Sin(ECC_Tabsolute))
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, ECC_Y = ECC_R * Math.Sin(ECC_Tabsolute)=" & ECC_Y.ToString())

                'AlStn_X = AlStn_R * Math.Cos(AlStn_Tabsolute)
                Dim AlStn_X As Double = (AlStn_R * Math.Cos(AlStn_Tabsolute))
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, AlStn_X = AlStn_R * Math.Cos(AlStn_Tabsolute)=" & AlStn_X.ToString())

                'AlStn_Y = AlStn_R * Math.Sin(AlStn_Tabsolute)
                Dim AlStn_Y As Double = (AlStn_R * Math.Sin(AlStn_Tabsolute))
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, AlStn_Y = AlStn_R * Math.Sin(AlStn_Tabsolute)=" & AlStn_Y.ToString())

                'Wafer_X = AlStn_X + ECC_X
                Dim Wafer_X As Double = (AlStn_X + ECC_X)
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, Wafer_X = AlStn_X + ECC_X=" & Wafer_X.ToString())

                'Wafer_Y = AlStn_Y + ECC_Y
                Dim Wafer_Y As Double = (AlStn_Y + ECC_Y)
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, AlStn_Y = AlStn_R * Math.Sin(AlStn_Tabsolute)=" & Wafer_Y.ToString())

                'Wafer_R = Math.Sqrt(Wafer_X * Wafer_X + Wafer_Y * Wafer_Y)
                Dim Wafer_R As Double = Math.Sqrt(((Wafer_X * Wafer_X) + (Wafer_Y * Wafer_Y)))
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, Wafer_R = Math.Sqrt(Wafer_X * Wafer_X + Wafer_Y * Wafer_Y)=" & Wafer_R.ToString())

                'Wafer_Ttentative = Math.Atan(Wafer_Y / Wafer_X)
                'Dim Wafer_Ttentative As Double = Math.Atan((Wafer_Y / Wafer_X))
                Dim Wafer_Ttentative As Double = Math.Atan2(Wafer_Y, Wafer_X)
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, Wafer_Ttentative = Math.Atan2(Wafer_Y / Wafer_X)=" & Wafer_Ttentative.ToString())

                'Wafer_Rstation = Wafer_R
                objAligner.Wafer_Rstation = Wafer_R
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, objAligner.Wafer_Rstation = Wafer_R = " & Wafer_R.ToString())
                'Wafer_Tstation = -1 * (Wafer_Ttentative * 180 / Math.PI) * 1000.0F
                Dim Wafer_Tstation As Double = CDbl(((-1 * ((Wafer_Ttentative * 180) / Math.PI)) * 1000.0F))
                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, Wafer_Tstation = -1 * (Wafer_Ttentative * 180 / Math.PI) * 1000.0F=" & Wafer_Tstation.ToString())

                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, objAligner.Wafer_Tstation = (WAFER_TSTATION + 360000) MOD 360000")
                objAligner.Wafer_Tstation = (Wafer_Tstation + 360000) Mod 360000

                AVPLib.Log.schedulerLogger.Debug("DELTAPICK, objAligner.Wafer_Tstation = " & objAligner.Wafer_Tstation)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            
            Return True
        End Function

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2015-05-07 </date>
        ''' </author>
        ''' <summary>
        ''' Make SelfAlign Calculation
        ''' </summary>
        ''' <remarks></remarks>
        Public Function MakeSelfAlignCalculation() As Boolean
            Try
                Dim objAligner As DataManagerment.Aligner = EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                Dim objRobot As DataManagerment.Robot = EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())

                Dim ECC_Traw As Double = objAligner.RSLTEccentricityAngle
                Dim ECC_Rraw As Double = objAligner.RSLTMaxEccentricity

                'ECC_Traw = (ECC_Traw - 900 +3600) MOD 3600.  The number 900 need to be configure and it is call the "AlignerCDDPosition".
                ECC_Traw = (((ECC_Traw - AlignerCDDPosition + 3600) Mod 3600))
                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, ECC_Traw = (ECC_Traw - AlignerCDDPosition + 3600) MOD 3600 orgVal=" & objAligner.RSLTEccentricityAngle.ToString() & ", newVal=" & ECC_Traw.ToString())
                'ECC_Tflange = Math.PI - (ECC_Traw / 10.0F) * (Math.PI / 180.0F)
                Dim ECC_Tflange As Double = (Math.PI - ((ECC_Traw / 10.0F) * (Math.PI / 180.0F)))
                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, ECC_Tflange = Math.PI - (ECC_Traw / 10.0F) * (Math.PI / 180.0F)=" & ECC_Tflange.ToString())
                'ECC_R = (ECC_Rraw / 10.0F) * 25.4F
                Dim ECC_R As Double = ((ECC_Rraw / 10.0F) * 25.4F)
                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, ECC_R = (ECC_Rraw / 10.0F) * 25.4F=" & ECC_R.ToString())

                Dim AlStn_Traw As Double = objRobot.ReqAlStn_Traw
                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, AlStn_Traw = objRobot.ReqAlStn_Traw=" & AlStn_Traw.ToString())
                Dim AlStn_R As Double = objRobot.ReqAlStn_R
                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, AlStn_R = objRobot.ReqAlStn_R" & AlStn_R.ToString())

                'AlStn_Tabsolute = 2 * Math.PI - (AlStn_Traw / 1000.0F) * Math.PI / 180.0F
                Dim AlStn_Tabsolute As Double = (2 * Math.PI - (((AlStn_Traw / 1000.0F) * Math.PI) / 180.0F))
                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, AlStn_Tabsolute = 2 * Math.PI - (AlStn_Traw / 1000.0F) * Math.PI / 180.0F=" & AlStn_Tabsolute.ToString())

                'ECC_Tabsolute = ECC_Tflange - Math.PI / 2 + AlStn_Tabsolute
                Dim ECC_Tabsolute As Double = ((ECC_Tflange - Math.PI / 2) + AlStn_Tabsolute)
                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, ECC_Tabsolute = ECC_Tflange - Math.PI / 2 + AlStn_Tabsolute=" & ECC_Tabsolute.ToString())
                'ECC_X = ECC_R * Math.Cos(ECC_Tabsolute)
                Dim ECC_X As Double = (ECC_R * Math.Cos(ECC_Tabsolute))
                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, ECC_X = ECC_R * Math.Cos(ECC_Tabsolute)=" & ECC_X.ToString())

                'ECC_Y = ECC_R * Math.Sin(ECC_Tabsolute)
                Dim ECC_Y As Double = (ECC_R * Math.Sin(ECC_Tabsolute))
                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, ECC_Y = ECC_R * Math.Sin(ECC_Tabsolute)=" & ECC_Y.ToString())

                'AlStn_X = AlStn_R * Math.Cos(AlStn_Tabsolute)
                Dim AlStn_X As Double = (AlStn_R * Math.Cos(AlStn_Tabsolute))
                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, AlStn_X = AlStn_R * Math.Cos(AlStn_Tabsolute)=" & AlStn_X.ToString())

                'AlStn_Y = AlStn_R * Math.Sin(AlStn_Tabsolute)
                Dim AlStn_Y As Double = (AlStn_R * Math.Sin(AlStn_Tabsolute))
                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, AlStn_Y = AlStn_R * Math.Sin(AlStn_Tabsolute)=" & AlStn_Y.ToString())

                'Wafer_X = AlStn_X + ECC_X
                Dim Wafer_X As Double = (AlStn_X + ECC_X)
                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, Wafer_X = AlStn_X + ECC_X=" & Wafer_X.ToString())

                'Wafer_Y = AlStn_Y + ECC_Y
                Dim Wafer_Y As Double = (AlStn_Y + ECC_Y)
                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, AlStn_Y = AlStn_R * Math.Sin(AlStn_Tabsolute)=" & Wafer_Y.ToString())

                'Wafer_R = Math.Sqrt(Wafer_X * Wafer_X + Wafer_Y * Wafer_Y)
                Dim Wafer_R As Double = Math.Sqrt(((Wafer_X * Wafer_X) + (Wafer_Y * Wafer_Y)))
                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, Wafer_R = Math.Sqrt(Wafer_X * Wafer_X + Wafer_Y * Wafer_Y)=" & Wafer_R.ToString())

                'Wafer_Ttentative = Math.Atan(Wafer_Y / Wafer_X)
                'Dim Wafer_Ttentative As Double = Math.Atan((Wafer_Y / Wafer_X))
                Dim Wafer_Ttentative As Double = Math.Atan2(Wafer_Y, Wafer_X)
                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, Wafer_Ttentative = Math.Atan2(Wafer_Y / Wafer_X)=" & Wafer_Ttentative.ToString())

                'Wafer_Rstation = Wafer_R
                objAligner.Wafer_Rstation = Wafer_R
                'Wafer_Rstation = Wafer_R
                objAligner.SelfAlign_Wafer_Rstation = Wafer_R

                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, objAligner.Wafer_Rstation = Wafer_R = " & Wafer_R.ToString())
                'Wafer_Tstation = -1 * (Wafer_Ttentative * 180 / Math.PI) * 1000.0F
                Dim Wafer_Tstation As Double = CDbl(((-1 * ((Wafer_Ttentative * 180) / Math.PI)) * 1000.0F))
                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, Wafer_Tstation = -1 * (Wafer_Ttentative * 180 / Math.PI) * 1000.0F=" & Wafer_Tstation.ToString())

                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, objAligner.Wafer_Tstation = (WAFER_TSTATION + 360000) MOD 360000")
                objAligner.Wafer_Tstation = (Wafer_Tstation + 360000) Mod 360000
                objAligner.SelfAlign_Wafer_Tstation = (Wafer_Tstation + 360000) Mod 360000

                AVPLib.Log.schedulerLogger.Debug("SELFALIGN, objAligner.Wafer_Tstation = " & objAligner.Wafer_Tstation)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return True
        End Function

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-10-13</date>
        ''' </author>
        ''' <summary>
        '''  Link test
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SendLinkTest(ByVal source As Object, ByVal e As Timers.ElapsedEventArgs)
            AVPLib.Log.coreLogger.Info("Enter SendLinkTest")
            Try
                m_tmrLinkTest.Enabled = False
                AlignerUtility.CheckComunicationAlive(EquipmentName)
                m_tmrLinkTest.Enabled = True
                If m_IsRequestRevition Then
                    Dim aligner As AVPLib.DataManagerment.Aligner = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Aligner.ToString())
                    If aligner IsNot Nothing Then
                        AVPLib.Utils.SaveToRevisionConfigFile(aligner.RevisionNoValues, AVPLib.ConstEnum.Equipments.Aligner.ToString())
                    End If
                    m_IsRequestRevition = False
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave SendLinkTest")
        End Sub
#End Region
    End Class
End Namespace

