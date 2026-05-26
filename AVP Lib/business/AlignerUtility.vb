Imports AVPLib.Communication.TerminalDriver
Imports AVPLib.ConstEnum
Namespace Business
    Public Class AlignerUtility
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
        ''' Initialize Aligner
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function Initialize(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Initialize")
            Try
                Dim blnResult As Boolean = True

                Dim ListAligner As ArrayList = ContainerData.GetInitConfig("Aligner")

                For Each Aligner As String In ListAligner
                    If blnResult Then
                        Dim strMessage As String = Name + "." + Aligner
                        If strMessage.Contains("LDCCDPOS") Then

                            Dim iValue As Integer = RobotConfigurationValues.ALIGNER_SENSOR_POSITION_AT_DEGREE * 10
                            strMessage = String.Format(strMessage, iValue)

                        ElseIf strMessage.Contains("SLWF") Then

                            strMessage = String.Format(strMessage, RobotConfigurationValues.WAFER_SIZE, _
                                                            RobotConfigurationValues.ACTIVE_CCD, RobotConfigurationValues.WAFER_TYPE)

                        End If

                        blnResult = TransactionManager.Run(strMessage)
                    Else
                        Exit For
                    End If
                Next
                Return blnResult
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Initialize")
        End Function

        Public Shared Function ReInitialize(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter ReInitialize")
            Try
                Dim blnResult As Boolean = True

                Dim ListAligner As ArrayList = ContainerData.GetInitConfig("Aligner")

                For Each Aligner As String In ListAligner
                    If String.Equals(Aligner, "HOME") = False Then
                        If blnResult Then
                            Dim strMessage As String = Name + "." + Aligner
                            If strMessage.Contains("LDCCDPOS") Then

                                Dim iValue As Integer = RobotConfigurationValues.ALIGNER_SENSOR_POSITION_AT_DEGREE * 10
                                strMessage = String.Format(strMessage, iValue)

                            ElseIf strMessage.Contains("SLWF") Then

                                strMessage = String.Format(strMessage, RobotConfigurationValues.WAFER_SIZE, _
                                                            RobotConfigurationValues.ACTIVE_CCD, RobotConfigurationValues.WAFER_TYPE)

                            End If
                            blnResult = TransactionManager.Run(strMessage)
                        Else
                            Exit For
                        End If
                    End If

                Next
                Return blnResult
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ReInitialize")
        End Function
        ''' <author>
        '''    	<name> Tien Dat, Nguyen </name>
        '''    	<date> 2009-07-06</date>
        ''' </author>
        ''' <summary>
        ''' Execute a command in a Aligner Transaction.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function ExecuteCommand(ByVal Name As String, ByVal command As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter ExecuteCommand")
            Try
                Dim strMessage As String = Name & "." & command
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ExecuteCommand")
            Return False
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
        Public Shared Function Align(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Align")
            Try
                Dim strMessage As String = Name + "." + "ALGN"
                AVPLib.Log.coreLogger.Info("Leave Align")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave Align")
        End Function
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-07-15</date>
        ''' </author>
        '''   <Modifiers>
        ''' <Modifier>
        '''   	<Name>ScanOperations</Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Home
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function Scan(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter ScanOperations")
            Try
                Dim strMessage As String = Name + "." + "SCAN"
                AVPLib.Log.coreLogger.Info("Leave ScanOperations")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave ScanOperations")
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
                Dim strMessage As String = Name + "." + "HOME"
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
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
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
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2008-11-14</date>
        ''' </author>
        ''' <summary>
        ''' Check communication is alive
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Function CheckComunicationAlive(ByVal Name As String) As Boolean
            AVPLib.Log.coreLogger.Info("Enter CheckComunicationAlive")
            Try
                'Do not send pulling command when re-connect
                Dim objAlignerController As AlignerController = ControllerManager.GetController(ConstEnum.Equipments.Aligner.ToString())
                If objAlignerController IsNot Nothing AndAlso objAlignerController.IsDoingReConnect Then
                    Return True
                End If

                Dim strMessage As String = Name + "." + AVPLib.ConstEnum.ALIGNER_COMMAND_COMUNICTION_ALIVE
                AVPLib.Log.coreLogger.Info("Leave CheckComunicationAlive")
                Return TransactionManager.Run(strMessage)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CheckComunicationAlive")
        End Function

        Public Shared Sub GenerateAlignerDataRun(ByVal strRunDataFileName As String, ByVal strRecipeName As String, ByVal strStartingTime As String, _
        ByVal strGemWaferID As String, ByVal blnNoData As Boolean)
            Try
                '''generate datarun csv file
                If RobotConfigurationValues.RUN_DATA_FILE_FORMAT.Equals("CSV") Then
                    GenerateAlignerDataRunInCSVFormat(strRunDataFileName, strRecipeName, strStartingTime, strGemWaferID, blnNoData)
                    Exit Sub
                End If

                Dim objAligner As DataManagerment.Aligner = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                Dim objRobot As DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                If Not String.IsNullOrEmpty(strRunDataFileName) AndAlso (objAligner IsNot Nothing) Then

                    Dim xmlString As String = String.Empty
                    xmlString = "<RunData><ChamberList><Chamber><RecipeName>"
                    xmlString &= Utils.GetFileName(strRecipeName, True) & "</RecipeName>"
                    xmlString &= "<WaferID>" & strGemWaferID & "</WaferID>"
                    xmlString &= "<StepList><Step><Number>1</Number>"
                    xmlString &= "<Start>" & "" ''day
                    xmlString &= "</Start><SampleList><Sample><Seq>1</Seq>"

                    If blnNoData Then
                        xmlString &= "<RSLTEccentricityAngleDeg></RSLTEccentricityAngleDeg>"
                        xmlString &= "<RSLTMaxEccentricityMils></RSLTMaxEccentricityMils>"
                        xmlString &= "<Delta_R></Delta_R>"
                        xmlString &= "<Delta_T></Delta_T>"
                        xmlString &= "<RSLTAngularLocationDeg></RSLTAngularLocationDeg>"
                        xmlString &= "<RSLTReScanNeed></RSLTReScanNeed>"
                    Else
                        xmlString &= "<RSLTEccentricityAngleDeg>" & objAligner.RSLTEccentricityAngleDeg.ToString() & "</RSLTEccentricityAngleDeg>"
                        xmlString &= "<RSLTMaxEccentricityMils>" & objAligner.RSLTMaxEccentricityMils.ToString() & "</RSLTMaxEccentricityMils>"

                        'Delta R = ABS(Station 9 R - Station 8 R)
                        Dim deltaR As Double = Math.Abs(objRobot.ReqAlStn_R - objAligner.Wafer_Rstation)
                        xmlString &= "<Delta_R>" & String.Format("{0:0.0000}", deltaR) & "</Delta_R>"

                        ' Delta T = ABS(Station 9 T - Station 8 T)
                        Dim deltaT As Double = Math.Abs(objRobot.ReqAlStn_Traw - objAligner.Wafer_Tstation)
                        xmlString &= "<Delta_T>" & String.Format("{0:0.0000}", deltaT) & "</Delta_T>"

                        '''''''''''
                        xmlString &= "<RSLTAngularLocationDeg>" & objAligner.RSLTAngularLocationDeg.ToString() & "</RSLTAngularLocationDeg>"
                        xmlString &= "<RSLTReScanNeed>" & objAligner.RSLTReScanNeed.ToString() & "</RSLTReScanNeed>"
                    End If

                    xmlString &= "</Sample></SampleList></Step></StepList></Chamber></ChamberList>"
                    xmlString &= "<TotalSeconds>0.0</TotalSeconds></RunData>"

                    Dim SwFromProjTrueUTF8 As New System.IO.StreamWriter(AVPLib.ContainerDAO.FPath_RunDataOfWafer & "\" & strRunDataFileName & ".xml", False, System.Text.Encoding.ASCII)
                    SwFromProjTrueUTF8.WriteLine(xmlString)
                    SwFromProjTrueUTF8.Flush()
                    SwFromProjTrueUTF8.Close()

                    '''notify to GUI to get new Aligner DataRun File
                    Dim arrPropertyNames As New ArrayList()
                    arrPropertyNames.Add("ProcessControl_GetRunDataFileName")
                    Dim arrValues As New ArrayList()
                    arrValues.Add(STR_OFF)
                    AVPLib.DataManagerment.EquipmentManager.ChangeStatus(objAligner.Name, arrPropertyNames, arrValues)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

        ''' <author>
        '''    	<name> Huy Nguyen </name>
        '''    	<date> 2015-08-26</date>
        ''' </author>
        ''' <summary>
        ''' generate aligner datarun in csv file
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub GenerateAlignerDataRunInCSVFormat(ByVal strRunDataFileName As String, ByVal strRecipeName As String, ByVal strStartingTime As String, _
        ByVal strGemWaferID As String, ByVal blnNoData As Boolean)
            Try
                Dim objAligner As DataManagerment.Aligner = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Aligner.ToString())
                Dim objRobot As DataManagerment.Robot = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                If Not String.IsNullOrEmpty(strRunDataFileName) AndAlso (objAligner IsNot Nothing) Then

                    Dim csvString As String = String.Empty
                    csvString = "WaferID," & strGemWaferID & vbCrLf
                    csvString &= "RecipeName," & Utils.GetFileName(strRecipeName, True) & vbCrLf & vbCrLf
                    csvString &= "Step No,Sample,Time,RSLTEccentricityAngleDeg,RSLTMaxEccentricityMils,Delta_R,Delta_T,RSLTAngularLocationDeg,RSLTReScanNeed" & vbCrLf

                    If blnNoData Then
                        csvString &= "1,1," & strStartingTime & ",,,,,," & vbCrLf

                    Else
                        csvString &= "1,1," & strStartingTime & "," & objAligner.RSLTEccentricityAngleDeg.ToString() & "," & objAligner.RSLTMaxEccentricityMils.ToString() & ","

                        'Delta R = ABS(Station 9 R - Station 8 R)
                        Dim deltaR As Double = Math.Abs(objRobot.ReqAlStn_R - objAligner.Wafer_Rstation)
                        csvString &= String.Format("{0:0.0000}", deltaR) & ","

                        ' Delta T = ABS(Station 9 T - Station 8 T)
                        Dim deltaT As Double = Math.Abs(objRobot.ReqAlStn_Traw - objAligner.Wafer_Tstation)
                        csvString &= String.Format("{0:0.0000}", deltaT) & ","

                        '''''''''''
                        csvString &= objAligner.RSLTAngularLocationDeg.ToString() & ","
                        csvString &= objAligner.RSLTReScanNeed.ToString() & vbCrLf
                    End If

                    csvString &= "TotalSeconds,0.0" & vbCrLf

                    Dim SwFromProjTrueUTF8 As New System.IO.StreamWriter(AVPLib.ContainerDAO.FPath_RunDataOfWafer & "\" & strRunDataFileName & ".csv", False)
                    SwFromProjTrueUTF8.WriteLine(csvString)
                    SwFromProjTrueUTF8.Flush()
                    SwFromProjTrueUTF8.Close()

                    '''notify to GUI to get new Aligner DataRun File
                    Dim arrPropertyNames As New ArrayList()
                    arrPropertyNames.Add("ProcessControl_GetRunDataFileName")
                    Dim arrValues As New ArrayList()
                    arrValues.Add(STR_OFF)
                    AVPLib.DataManagerment.EquipmentManager.ChangeStatus(objAligner.Name, arrPropertyNames, arrValues)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub
#End Region
    End Class
End Namespace

