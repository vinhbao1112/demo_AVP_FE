Imports System
Imports System.Collections
Imports System.IO
Imports System.Management
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Xml
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPControls
Imports AVPControls.AVPDataLib
Imports AVPControls.AVPGraphicsLib
Imports AVPLib
Imports AVPLib.ConstEnum
Imports AVPLib.DataManagerment.Equipment
Imports AVPLib.SystemModule
Imports HRecipeLibrary

Public Class Utils
    Public Shared intTimeUnProtectedTimeCountInProcessPanel As Integer = 0
    Public Shared intArmUpWaitingTimeCount As Integer = 0
    Public Shared intArmDownWaitingTimeCount As Integer = 0
    Public Shared intArmExtendWaitingTimeCount As Integer = 0
    Public Shared intArmRetractWaitingTimeCount As Integer = 0
    Public Shared intLogDataOutputTimeCount As Integer = 0
    Private Shared strSupportGem As String = String.Empty
    'Check that we have sent command turn off motor or not when do robot action manual time out.
    Private Shared blnValueIsWritenKepware As Boolean = False

    Public Shared intCleanUpTime As Integer = 90 'default 90 days
    Public Shared intMaxDateDataRunDelete As Double = 365 'default 365 days

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-23 </date>
    ''' </author>
    ''' <summary>
    ''' Convert value to DisplayStatus type
    ''' </summary>
    Public Shared Function ConvertToDisplayStatus(ByVal value As Object) As DisplayStatus
        Dim result As DisplayStatus = DisplayStatus.None
        Try
            Dim strValue As String = System.Convert.ToString(value)

            If [Enum].IsDefined(GetType(DisplayStatus), strValue) Then
                result = CType([Enum].Parse(GetType(DisplayStatus), strValue), DisplayStatus)
            Else
                strValue = strValue.ToLower()
                Select Case strValue
                    Case "on", "true", "open", "opened", CInt(DisplayStatus.On).ToString()
                        result = DisplayStatus.On
                    Case "off", "false", "close", "closed", CInt(DisplayStatus.Off).ToString()
                        result = DisplayStatus.Off
                    Case "unknown", "other", "unk", "unknow", "between", CInt(DisplayStatus.Unknow).ToString()
                        result = DisplayStatus.Unknow
                    Case "error", "err", CInt(DisplayStatus.Error).ToString()
                        result = DisplayStatus.Error
                End Select
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return result
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-07-31 </date>
    ''' </author>
    ''' <summary>
    ''' Convert value to Boolean
    ''' </summary>
    Public Shared Function TryParseToBoolean(ByVal value As Object, ByRef result As Boolean) As Boolean
        Dim isSuccess As Boolean = True
        Try
            If value Is Nothing Then
                Return False
            End If

            If Not Boolean.TryParse(value, result) Then
                Dim str As String = Convert.ToString(value).ToLower()
                Select Case str
                    Case Boolean.TrueString.ToLower(), STR_ON.ToLower(), "1"
                        result = True
                    Case Boolean.FalseString.ToLower(), STR_OFF.ToLower(), "0"
                        result = False
                    Case Else
                        Dim iValue As Integer
                        If Integer.TryParse(str, iValue) Then
                            Select Case iValue
                                Case 1
                                    result = True
                                Case 0
                                    result = False
                                Case Else
                                    isSuccess = False
                            End Select
                        Else
                            isSuccess = False
                        End If

                End Select
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            isSuccess = False
        End Try
        Return isSuccess
    End Function

#Region "Make Region Control"
    Public Shared Sub CreateControlRegion(ByVal control As Control, ByVal bitmap As Bitmap)
        Try
            ' Return if control and bitmap are null
            If control Is Nothing OrElse bitmap Is Nothing Then
                Return
            End If

            ' Set our control's size to be the same as the bitmap
            control.Width = bitmap.Width
            control.Height = bitmap.Height
            ' Set bitmap as the background image
            control.BackgroundImage = bitmap

            ' Calculate the graphics path based on the bitmap supplied
            Dim graphicsPath As Drawing2D.GraphicsPath = QuickCalculateGraphicsPath(bitmap, CByte(0))
            ' Apply new region
            control.Region = New Region(graphicsPath)

            graphicsPath.Dispose()
            graphicsPath = Nothing
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.Message)
        End Try

    End Sub

    ' Calculate the graphics path that representing the figure in the bitmap 
    ' excluding the transparent color which is the top left pixel.
    Private Shared Function CalculateControlGraphicsPath(ByVal bitmap As Bitmap) As Drawing2D.GraphicsPath
        ' Create GraphicsPath for our bitmap calculation
        Dim graphicsPath As New Drawing2D.GraphicsPath()

        ' Use the top left pixel as our transparent color
        Dim colorTransparent As Color = bitmap.GetPixel(0, 0)

        ' This is to store the column value where an opaque pixel is first found.
        ' This value will determine where we start scanning for trailing 
        ' opaque pixels.
        Dim colOpaquePixel As Integer = 0

        ' Go through all rows (Y axis)
        For row As Integer = 0 To bitmap.Height - 1
            ' Reset value
            colOpaquePixel = 0

            ' Go through all columns (X axis)
            For col As Integer = 0 To bitmap.Width - 1
                ' If this is an opaque pixel, mark it and search 
                ' for anymore trailing behind
                If bitmap.GetPixel(col, row) <> colorTransparent Then
                    ' Opaque pixel found, mark current position
                    colOpaquePixel = col

                    ' Create another variable to set the current pixel position
                    Dim colNext As Integer = col

                    ' Starting from current found opaque pixel, search for 
                    ' anymore opaque pixels trailing behind, until a transparent
                    ' pixel is found or minimum width is reached
                    For colNext = colOpaquePixel To bitmap.Width - 1
                        If bitmap.GetPixel(colNext, row) = colorTransparent Then
                            Exit For
                        End If
                    Next

                    ' Form a rectangle for line of opaque pixels found and 
                    ' add it to our graphics path
                    graphicsPath.AddRectangle(New Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1))

                    ' No need to scan the line of opaque pixels just found
                    col = colNext
                End If
            Next
        Next

        ' Return calculated graphics path
        Return graphicsPath
    End Function

#End Region

#Region "SignificantFigures"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-23</date>
    ''' </author>
    ''' <summary>
    ''' Significant Figures Label
    ''' </summary>
    ''' <param name="strNumber"></param>
    ''' <remarks></remarks>
    Public Shared Function SignificantFigures(ByVal strNumber As String) As String
        Try
            If strNumber.Length > 0 And IsNumeric(strNumber) Then
                Dim nNumber As Double = Double.Parse(strNumber)
                Dim blnIsNegative As Boolean = False
                If nNumber < 0 Then
                    blnIsNegative = True
                    nNumber = Math.Abs(nNumber)
                End If

                If (nNumber > 1 And nNumber < 100) Or (nNumber <= 1 And nNumber > 0.01) Then
                    If blnIsNegative Then
                        Return "-" & strNumber
                    End If
                    Return strNumber
                End If

                strNumber = Format(Double.Parse(nNumber), "0.0E+00")
                If blnIsNegative Then
                    strNumber = "-" & strNumber
                End If
                Return strNumber
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strNumber
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-23</date>
    ''' </author>
    ''' <summary>
    ''' Get Message Formation
    ''' </summary>
    ''' <param name="Number"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetMessageFormation(ByVal Number As Double) As String
        If Number > 1 Then
            Return GetMessageFormationPositive(Number)
        End If
        Return GetMessageFormationNegative(Number)
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-23</date>
    ''' </author>
    ''' <summary>
    ''' Get Message Formation Positive
    ''' </summary>
    ''' <param name="Number"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetMessageFormationPositive(ByVal Number As Double) As String
        'If Number < 100 Then
        '    Return Number.ToString()
        'End If
        'Dim nPower As Integer = 0
        'While Number > 10
        '    Number = Number / 10
        '    nPower += 1
        'End While
        'Dim sPower As String = IIf(nPower < 10, "00" + nPower.ToString(), IIf(nPower < 100, "0" + nPower.ToString(), nPower.ToString()))
        'Return Number.ToString() + "e+" + sPower
        Return Format(Double.Parse(Number), "0.0E+00")
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-23</date>
    ''' </author>
    ''' <summary>
    ''' Get Message Formation Negative
    ''' </summary>
    ''' <param name="Number"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMessageFormationNegative(ByVal Number As Double) As String
        Try
            'Dim blnIsABS As Boolean = False
            'If Number < 0 Then
            '    blnIsABS = True
            '    Number = Math.Abs(Number)
            'End If
            'If Number > 0.01 Or Number = 0 Then
            '    Return IIf(blnIsABS, 0 - Number, Number.ToString())
            'End If
            'Dim nPower As Integer = 0
            'While (Number < 1)
            '    Number = Number * 10
            '    nPower += 1
            'End While
            'Dim sPower As String = IIf(nPower < 10, "00" + nPower.ToString(), IIf(nPower < 100, "0" + nPower.ToString(), nPower.ToString()))
            'If blnIsABS Then
            '    Number = 0 - Number
            'End If
            'Return Number.ToString() + "e-" + sPower
            Return Format(Double.Parse(Number), "0.0E+00")
        Catch ex As Exception
            Dim a As String = ex.ToString()
        End Try
        Return "0"
    End Function
#End Region

    'Truc Le Add
    Public Shared Sub CreateStatusTree_4Panel(ByVal ctrl As Control, ByVal stoStatusObject As StatusObject, Optional ByVal isCreateStatusLabel As Boolean = False)
        Try
            'Select Case ctrl.ProductName
            '    Case "PQL"
            If ctrl.GetType().Name = "SL_CustomButton" Then
                If CType(ctrl, SL_CustomButton).TypeOfChamberSupport = TypeOfAVPChamber.PVD4 OrElse CType(ctrl, SL_CustomButton).TypeOfChamberSupport = TypeOfAVPChamber.PVD5T Then
                    Dim sButton As New StatusCoronaButton(CType(ctrl, SL_CustomButton))
                    stoStatusObject.AddChild(sButton)
                    CType(ctrl, SL_CustomButton).ParentStatusObj = stoStatusObject
                Else
                    'IBE,PVD
                End If

            ElseIf ctrl.GetType().Name = "SL_Textbox" Then
                If CType(ctrl, SL_Textbox).TypeOfChamberSupport = TypeOfAVPChamber.PVD4 OrElse CType(ctrl, SL_Textbox).TypeOfChamberSupport = TypeOfAVPChamber.PVD5T Then
                    Dim sTextBox As New StatusCoronaTextBox(CType(ctrl, SL_Textbox))
                    stoStatusObject.AddChild(sTextBox)
                    CType(ctrl, SL_Textbox).ParentStatusObj = stoStatusObject
                Else
                    'IBE,PVD
                End If

            ElseIf ctrl.GetType().Name = "ValveControl" Then
                If CType(ctrl, ValveControl).TypeOfChamberSupport = TypeOfAVPChamber.PVD4 OrElse CType(ctrl, ValveControl).TypeOfChamberSupport = TypeOfAVPChamber.PVD5T Then
                    Dim sValve As New StatusCoronaBinaryControl(CType(ctrl, ValveControl))
                    stoStatusObject.AddChild(sValve)
                    CType(ctrl, ValveControl).ParentStatusObj = stoStatusObject
                Else
                    Dim sValve As New StatusBinaryStatusControl(CType(ctrl, ValveControl))
                    stoStatusObject.AddChild(sValve)
                    CType(ctrl, ValveControl).ParentStatusObj = stoStatusObject
                End If


            ElseIf ctrl.GetType().Name = "ImageBinaryStatusControl" Then
                If CType(ctrl, ImageBinaryStatusControl).TypeOfChamberSupport = TypeOfAVPChamber.PVD4 OrElse CType(ctrl, ImageBinaryStatusControl).TypeOfChamberSupport = TypeOfAVPChamber.PVD5T Then
                    Dim sBinaryControl As New StatusCoronaBinaryControl(CType(ctrl, ImageBinaryStatusControl))
                    stoStatusObject.AddChild(sBinaryControl)
                Else
                    Dim sBinaryControl As New StatusBinaryStatusControl(CType(ctrl, ImageBinaryStatusControl))
                    stoStatusObject.AddChild(sBinaryControl)
                End If

            ElseIf isCreateStatusLabel AndAlso ctrl.GetType().Name = "Label" Then
                Dim slbStatusLabel As New StatusLabel(CType(ctrl, Label))
                stoStatusObject.AddChild(slbStatusLabel)

            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''fix bug check Invalid Character when user input LotID, Seq, Recipe, WaferFlow Name
    Public Shared Function Clean_Invalid_Input(ByVal strIn As String) As String
        ' Replace invalid characters with empty strings.
        If strIn.StartsWith(".") Then
            strIn = strIn.Replace(".", "")
        End If
        Dim illegalChars As Char() = "\/:*?""><|".ToCharArray()
        For Each ch As Char In illegalChars
            strIn = strIn.Replace(ch, "")
        Next
        Return strIn
    End Function

    Public Shared Function GetRunningSlot(ByVal strSequenceID As String) As List(Of String)
        Dim lstOfRunningSlot As New List(Of String)
        Try
            Dim wfSequence As AVPLib.DBWaferList = Nothing
            If Not AVPLib.ContainerData.GetSequence(AVPLib.ContainerDAO.FPath_SequenceData & "\" & AVPLib.Utils.GetFileName(strSequenceID, "xml"),
                               wfSequence, String.Empty) Then
                AVPLib.Log.avpLogger.Error("Failed to load Ctrl Job - " & AVPLib.ContainerDAO.FPath_SequenceData & "\" & AVPLib.Utils.GetFileName(strSequenceID, "xml"))
                Return Nothing
            End If

            For Each waferslot As DBWaferSlot In wfSequence.WaferList
                If Not String.IsNullOrEmpty(waferslot.WaferSequence.SeqName) Then
                    lstOfRunningSlot.Add(waferslot.Slot)
                End If
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return lstOfRunningSlot
    End Function

    Public Shared Function CheckWaferIncompleteInLoadLock(ByVal LoadLockName As String, ByVal sSequenceID As String) As Boolean
        Try
            If (sSequenceID <> String.Empty) Then
                Dim objElevator As AVPLib.DataManagerment.LLElevator = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
                Dim lstRunningSlot As List(Of String) = GetRunningSlot(sSequenceID)

                If lstRunningSlot Is Nothing Then
                    Return False
                End If

                If objElevator IsNot Nothing Then
                    For Each wafer As AVPWaferInfo In objElevator.ListOfWaferInfo
                        'Wafer is mapped and not complete
                        If wafer IsNot Nothing AndAlso Not (wafer.WaferStatus = enumWaferStatus.eWaferNone) Then
                            If lstRunningSlot.Contains(wafer.SlotID) AndAlso Not (wafer.WaferStatus = enumWaferStatus.eWaferComplete) Then
                                Return True
                            End If
                        End If
                    Next
                End If
            End If
            Return False
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function

    Public Shared Function IsAllowEnable(ByVal isOnline As Boolean) As Boolean
        'Permission
        Dim Res As Boolean = True
        Res = AVPLib.ContainerData.Permission(PERMISSION_001)
        If Res = False Then
            'Do not have permission
            Return Res
        End If
        'Online
        If isOnline = True Then
            'Do not have permission
            Return False
        End If
        'else
        Return Res
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2012-03-27</date>
    ''' </author>
    ''' <summary>
    ''' IsEndCurrentStepActive
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function IsEndCurrentStepActive(ByVal strChamber As String) As Boolean
        Dim bRes As Boolean = False
        Try
            Dim objChamber As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(strChamber)
            If objChamber.RunProcessStatus = enumProcessStatus.eStart Then
                bRes = True
            Else
                bRes = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return bRes
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2012-03-27</date>
    ''' </author>
    ''' <summary>
    ''' IsPauseResumeProcessActive
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function IsPauseResumeProcessActive(ByVal strChamber As String) As Boolean
        Dim bRes As Boolean = False
        Try
            Dim objChamber As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(strChamber)
            If objChamber.RunProcessStatus = enumProcessStatus.eStart OrElse
            objChamber.RunProcessStatus = enumProcessStatus.ePause OrElse
            objChamber.RunProcessStatus = enumProcessStatus.eContinue Then
                bRes = True
            Else
                bRes = False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return bRes
    End Function

    Public Shared Function Contvert_mA2A(ByVal strValue As String) As String
        'convert mA to A
        Dim strReturn As String = String.Empty
        Dim dblBeamCurrent As Double
        If Double.TryParse(strValue, dblBeamCurrent) Then
            dblBeamCurrent = dblBeamCurrent / 1000
            strReturn = dblBeamCurrent.ToString()
        End If
        Return strReturn
    End Function

    Public Shared Function IsSchedulerRunning() As Boolean
        Dim blnSchedulerIsRun As Boolean = False
        Try
            If Not (ContainerForm.ProcessPanel.lpcLoadLockA.btnStart.Text = "START") Then
                blnSchedulerIsRun = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return blnSchedulerIsRun
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2015-09-29 </date>
    ''' </author>
    ''' <summary>
    ''' check if wafer is pausing
    ''' </summary>
    Public Shared Function IsWaferPausing(ByVal waferID As String) As Boolean
        Dim result As Boolean = False

        Try
            If Not String.IsNullOrEmpty(waferID) Then
                Dim avpProcessJob As AVPLib.Business.AVPProcessJob = Nothing
                avpProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(waferID)

                If avpProcessJob IsNot Nothing AndAlso avpProcessJob.IsPaused() Then
                    Utils.ShowAVPMessageBox("Wafer " & waferID & " is paused. Can not transfer manual this wafer.", "Transfer Wafer", MessageBoxIcon.Error, MessageBoxButtons.OK)
                    result = True
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return result
    End Function

    Public Shared Function ConvertValue(ByVal identifier As String, ByVal value As String) As String
        AVPLib.Log.guiLogger.Info("Enter ConvertValue")

        If String.IsNullOrEmpty(identifier) Then
            Return value
        End If
        Dim retValue As String = value
        Try
            '#Fix log crash: 
            '# ERROR AVP_Robot_Project.Utils.ConvertValue - System.ArgumentOutOfRangeException: StartIndex cannot be less than zero.
            '# Parameter(Name) : startIndex()
            '# at System.String.InternalSubStringWithChecks(Int32 startIndex, Int32 length, Boolean fAlwaysCopy)
            '#at AVP_Robot_Project.Utils.ConvertValue(String identifier, String value)
            If Not identifier.Contains(".") Then
                AVPLib.Log.avpLogger.Error("Identifer: " & identifier)
                Exit Try
            End If
            '#End fix.

            Dim chamber As String = identifier.Replace(identifier.Substring(identifier.IndexOf(".")), "")

            If chamber = AVPLib.ConstEnum.Equipments.Chamber1.ToString() Or
               chamber = AVPLib.ConstEnum.Equipments.Chamber2.ToString() Or
               chamber = AVPLib.ConstEnum.Equipments.Chamber3.ToString() Then
                identifier = identifier.Substring(identifier.IndexOf("."))
                Dim sysmodule As AVPLib.SystemModule = AVPLib.ContainerData.GetRobotConfig(chamber)
                If sysmodule.Type = AVPLib.SystemModule.ModuleType.PVD Then
                    identifier = AVPLib.ConstEnum.PVD + identifier
                ElseIf sysmodule.Type = AVPLib.SystemModule.ModuleType.IBE Then
                    identifier = AVPLib.ConstEnum.STR_IBE + identifier
                ElseIf sysmodule.Type = AVPLib.SystemModule.ModuleType.PVD4 Then
                    identifier = AVPLib.ConstEnum.PVD4 + identifier
                ElseIf sysmodule.Type = AVPLib.SystemModule.ModuleType.PVD5T Then
                    identifier = AVPLib.ConstEnum.PVD5T + identifier
                End If
            End If

            Dim formulaAndOutputType As KeyValuePair(Of String, String) = MessageMapper.GetFormulaAndOutputType(identifier)
            If (String.IsNullOrEmpty(formulaAndOutputType.Key) And String.IsNullOrEmpty(formulaAndOutputType.Value)) Then
                Return value
            End If
            ' If we have a Formula.
            If (Not String.IsNullOrEmpty(formulaAndOutputType.Key)) Then
                Dim dblRet = 0.0
                dblRet = AVPLib.Expression.Evaluate(String.Format(formulaAndOutputType.Key, value), New Dictionary(Of String, Double)())
                If (Double.IsInfinity(dblRet) Or Double.IsNegativeInfinity(dblRet) Or Double.IsPositiveInfinity(dblRet) Or Double.IsNaN(dblRet)) Then
                Else
                    If (formulaAndOutputType.Value = "Scientific") Then
                        retValue = Format(Double.Parse(dblRet), "0.0E+00")
                    ElseIf (formulaAndOutputType.Value = "Integer") Then
                        retValue = Convert.ToInt32(dblRet).ToString()
                    ElseIf (formulaAndOutputType.Value = "Float") Then
                        retValue = Convert.ToSingle(dblRet).ToString()
                    ElseIf (formulaAndOutputType.Value = "Decimal") Then
                        If MessageMapper.ListOfDecimal_3_digits.Contains(identifier) Then
                            retValue = Format(Double.Parse(retValue), "0.###")
                        Else
                            retValue = Format(Double.Parse(retValue), "0.##")
                        End If
                    Else
                        retValue = dblRet.ToString()
                    End If
                End If
            Else
                If (formulaAndOutputType.Value = "Scientific") Then
                    retValue = Format(Double.Parse(retValue), "0.0E+00")
                ElseIf (formulaAndOutputType.Value = "Integer") Then
                    retValue = Convert.ToInt32(retValue).ToString()
                ElseIf (formulaAndOutputType.Value = "Float") Then
                    retValue = Convert.ToSingle(retValue).ToString()
                    'Change to hh:mm:ss format for all value have OutputType = Time.
                ElseIf (formulaAndOutputType.Value = "Time") Then
                    retValue = TimeSpan.FromSeconds(retValue).ToString()
                ElseIf (formulaAndOutputType.Value = "Decimal") Then
                    If MessageMapper.ListOfDecimal_3_digits.Contains(identifier) Then
                        retValue = Format(Double.Parse(retValue), "0.###")
                    ElseIf MessageMapper.ListOfDecimal_1_digits.Contains(identifier) Then
                        retValue = Format(Double.Parse(retValue), "0.#")
                    Else
                        '#04/07/2011 
                        '#0001516: [SL_Build 21_Apr 7,2011]Suppressor current RB is rounding to the near 10. 
                        '#If Veeco PM display 15, GUI show 20 and if less than 15, GUI show 10. See screen below 
                        '#Begin fix: value * 1000 before round.
                        If MessageMapper.ListOfDecimal_Convert_A_To_mA.Contains(identifier) Then
                            Dim tempValue As Double = 0
                            Double.TryParse(retValue, tempValue)
                            retValue = (tempValue * 1000).ToString()
                        End If
                        '#End fix

                        '#04/08/2011 
                        '#-	All source RB params should not round off.  Do not make any round off
                        '#Begin fix: No need make round off. Just round 4 decimal, that enough. 
                        retValue = Format(Double.Parse(retValue), "0.####")
                        '#End fix.
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ConvertValue")
        Return retValue
    End Function
    'Truc Le add
    'check Param for Recipe : show or hide in DataGrid and in TreeView
    Public Shared Function CheckParamRecipe_Visible(ByVal ParaName As String, ByVal paramGroupCode As String, ByVal ChamberName As String) As Boolean
        Try
            If AVPLib.ContainerData.All_PVD_Recipe_Templates IsNot Nothing Then
                Dim Show_Hide_Para As AVPLib.DBParameter = Nothing
                For Each stdDbChamber As DBChamber In AVPLib.ContainerData.All_PVD_Recipe_Templates.Values
                    If stdDbChamber.ChamberName = ChamberName Then
                        For Each paraGroup As DBParameterGroup In stdDbChamber.ListGroupParameters
                            If paraGroup.Save_Not_Show AndAlso ParaName.Contains(paraGroup.GroupCode) Then
                                Return False
                            End If
                            For Each para As DBParameter In paraGroup.Parameters
                                If ParaName.Contains(para.Name) AndAlso paramGroupCode = paraGroup.GroupCode Then
                                    Return Not (para.Save_Not_Show)
                                End If
                            Next
                        Next
                    End If
                Next
            End If
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2017-10-05</date>
    ''' <summary>
    ''' Check visible for rework editor.
    ''' </summary>
    Public Shared Function CheckParamRecipeReworkVisible(ByVal ParaName As String, ByVal paramGroupCode As String, ByVal ChamberName As String) As Boolean
        Try
            Dim chamberModule As SystemModule = DirectCast(AVPLib.ContainerData.GetRobotConfig(ChamberName), SystemModule)
            If chamberModule.Type = SystemModule.ModuleType.PVD4 OrElse chamberModule.Type = ModuleType.PVD5T Then
                If Not String.IsNullOrEmpty(paramGroupCode) Then
                    If paramGroupCode <> "Gasses" _
                    AndAlso paramGroupCode <> "ProcessControl" _
                    AndAlso paramGroupCode <> "RFTargetPower" _
                    AndAlso paramGroupCode <> "DCTargetPower" _
                    AndAlso paramGroupCode <> "StepDescription" Then
                        Return False
                    ElseIf paramGroupCode = "ProcessControl" Then
                        If ParaName <> "ProcessTimeSeconds" _
                        AndAlso ParaName <> "ProcessPressure" Then
                            Return False
                        End If
                    ElseIf paramGroupCode = "RFTargetPower" Then
                        If ParaName <> "TargetPower" Then
                            Return False
                        End If
                    ElseIf paramGroupCode = "DCTargetPower" Then
                        If ParaName <> "TargetPower" Then
                            Return False
                        End If
                    End If
                Else
                    If ParaName <> "Gasses" _
                    AndAlso ParaName <> "ProcessControl" _
                    AndAlso ParaName <> "RFTargetPower" _
                    AndAlso ParaName <> "DCTargetPower" _
                    AndAlso ParaName <> "StepDescription" Then
                        Return False
                    End If
                End If
            End If

            Return CheckParamRecipe_Visible(ParaName, paramGroupCode, ChamberName)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' checkRowExisted
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <param name="dr"></param>
    ''' <param name="fieldName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function checkRowExisted(ByVal dt As DataTable, ByVal dr As DataRow, ByVal fieldName As String) As Boolean
        Try
            For Each drCheck As DataRow In dt.Rows
                If drCheck(fieldName) = dr(fieldName) Then
                    Return True
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' FormatString
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FormatString(ByVal data As Integer) As String
        If data >= 1000 Then
            Return data.ToString("0,000")
        End If
        Return data.ToString()
    End Function

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' FormatString
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FormatString(ByVal data As Double) As String
        ' If data >= 1000 Then
        'Return data.ToString("#,###.##")
        ' End If
        ' Return data.ToString()
        Dim strData As String = CStr(data)
        Dim strRemain As String = String.Empty
        Dim intPos As Integer = 0
        If strData.IndexOf(".") > 0 Then 'if data is float value
            intPos = strData.IndexOf(".")
            strRemain = strData.Substring(intPos)
            strData = FormatString(CInt(strData.Substring(0, intPos)))
            Return strData & strRemain
        Else
            Return FormatString(CInt(strData))
        End If
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' RemoveSpecialChar
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RemoveSpecialChar(ByVal Name As String) As String
        Try
            Dim SpecialChars As String() = {"!", "@", "#", "$", "%", "^", "&", "*", "=", "'", ":", ";", "?", "/", "\", "~", "`"}
            For Each SpecialChar As String In SpecialChars
                Name = Name.Replace(SpecialChar, "")
            Next
            Return Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' ParseChar
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseChar(ByVal Name As String) As String
        Try
            Name = Name.Replace("lt", "<")
            Name = Name.Replace("gt", ">")
            Name = Name.Replace("eq", "=")
            Return Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get Format Number
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetBoolean(ByVal data As String) As Boolean
        Try
            If LCase(data) = "true" Or LCase(data) = "false" Then
                Return True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-25</date>
    ''' </author>
    ''' <summary>
    ''' Get Format Number
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetNumber(ByVal data As String) As Double
        Try
            Return CDbl(data)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return 0.0
    End Function

    Public Shared Sub CopyData2_GEMFolder()
        Try
            '''try to delete all xml file in GEMData Folder
            Dim arrFile As String() = System.IO.Directory.GetFiles(AVPLib.ContainerDAO.FPath_GEMData, "*.xml")
            Dim listOfSourceFile As New List(Of String)

            ''after delete -> try to copy
            For Each fi As String In arrFile
                Try
                    fi = AVPLib.Utils.GetFileName(fi, True)

                    listOfSourceFile.Add(UCase(fi)) ''upper case
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error("Can not rename file: " & fi & " - " & ex.ToString())
                    Continue For
                End Try
            Next

            ''Compare and Copy Recipe file to GEM Folder
            CompareAnd_CopyFileToGEMDATA(listOfSourceFile, AVPLib.ContainerDAO.FPath_ChamberRecipe & "\" & ConstantAndEnum.STR_ALIGNER,
                                         False, False, True, UCase(ConstantAndEnum.STR_ALIGNER))
            For i As Integer = 1 To 6
                CompareAnd_CopyFileToGEMDATA(listOfSourceFile, AVPLib.ContainerDAO.FPath_ChamberRecipe & "\" & (ConstantAndEnum.CHAMBER & i),
                                         False, False, True, ConstantAndEnum.CHAMBER & i)
            Next

            If (AVPLib.ContainerDAO.Enable_ANYIBE_Mode()) Then
                CompareAnd_CopyFileToGEMDATA(listOfSourceFile, AVPLib.ContainerDAO.FPath_ChamberRecipe & "\" & (RobotConfigurationValues.ANY_IBE_CHAMBER),
                                                         False, False, True, RobotConfigurationValues.ANY_IBE_CHAMBER)
            End If

            ''Copy WaferFlow file to GEM Folder
            CompareAnd_CopyFileToGEMDATA(listOfSourceFile, AVPLib.ContainerDAO.FPath_WaferFlow, False, True, False, String.Empty)
            ''Copy Sequence file to GEM Folder
            CompareAnd_CopyFileToGEMDATA(listOfSourceFile, AVPLib.ContainerDAO.FPath_SequenceData, True, False, False, String.Empty)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''for CX only
    Public Shared Sub CompareAnd_CopyFileToGEMDATA(ByVal ListSourceFile As List(Of String), ByVal XmlFolderPath As String,
                                                   ByVal blnIsSequence As Boolean, ByVal blnIsWaferFlow As Boolean,
                                                   ByVal blnIsRecipeType As Boolean, ByVal strChamberName As String)
        If System.IO.Directory.Exists(XmlFolderPath) = False Then
            Exit Sub
        End If
        Dim arrFile As String() = System.IO.Directory.GetFiles(XmlFolderPath, "*.xml")
        For Each fi As String In arrFile
            Try
                Dim fileName As String = AVPLib.Utils.GetFileName(fi, True)
                If blnIsRecipeType Then
                    fileName = "RECIPE." & AVPLib.Utils.chamberID2ChamberName(strChamberName) & "." & fileName
                ElseIf blnIsWaferFlow Then
                    fileName = "WAFERFLOW." & fileName
                ElseIf blnIsSequence Then
                    fileName = "SEQUENCE." & fileName
                End If
                If Not ListSourceFile.Contains(UCase(fileName)) Then ''upper case
                    System.IO.File.Copy(fi, AVPLib.ContainerDAO.FPath_GEMData & "\" & UCase(fileName) & ".xml")
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error("Can not copy file: " & fi & " - " & ex.ToString())
                Continue For
            End Try
        Next
    End Sub
    ''use for SL only
    Public Shared Sub CompareAnd_CopyFileToGEMDATA(ByVal ListSourceFile As List(Of String), ByVal XmlFolderPath As String)
        If System.IO.Directory.Exists(XmlFolderPath) = False Then
            Exit Sub
        End If
        Dim arrFile As String() = System.IO.Directory.GetFiles(XmlFolderPath, "*.xml")
        For Each fi As String In arrFile
            Try
                Dim fileName As String = AVPLib.Utils.GetFileName(fi, True)
                If Not ListSourceFile.Contains(fileName) Then ''don't upper case
                    System.IO.File.Copy(fi, AVPLib.ContainerDAO.FPath_GEMData & "\" & fileName & ".xml", True)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error("Can not copy file: " & fi & " - " & ex.ToString())
                Continue For
            End Try
        Next
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-10</date>
    ''' </author>
    ''' <summary>
    ''' Check Online LLA
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function checkOnlineLLA() As Boolean
        Try
            'DEBUG
            If AVPLib.RobotConfigurationValues.DEBUGMODE Then
                Return True
            End If

            Return (ContainerForm.CassettesPanel.PopUpPanel.btnLLAOnline.Status = SL_CustomButton.DisplayStatus.On)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-05-21</date>
    ''' </author>
    ''' <summary>
    ''' Check Online Transfer Module
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function checkOnlineTM() As Boolean
        Try
            'DEBUG
            If AVPLib.RobotConfigurationValues.DEBUGMODE Then
                Return True
            End If

            Return (ContainerForm.CassettesPanel.PopUpPanel.btnTMOnline.Status = SL_CustomButton.DisplayStatus.On)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function

    Public Shared Function IsChamberOnline(ByVal chamberName As String) As Boolean
        'DEBUG
        If AVPLib.RobotConfigurationValues.DEBUGMODE Then
            Return True
        End If
        If chamberName = AVPLib.ConstEnum.Equipments.Aligner.ToString() Then
            Return True
            Exit Function
        End If
        If ContainerForm.ChamberPanel(chamberName) IsNot Nothing Then
            Return ContainerForm.ChamberPanel(chamberName).IsOnline
        Else
            Return False
        End If

    End Function

    Private Shared Function IsOrphanWaferInCoronaChamber(ByVal chamberName As String) As Boolean
        Dim objChamber As DataManagerment.Equipment = DataManagerment.EquipmentManager.GetEquipment(chamberName)
        If objChamber Is Nothing Then
            Return False
        End If

        For i As Integer = 1 To objChamber.WaferCapacity()
            If CheckOrphanWafer(objChamber, i) Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Shared Function CheckOrphanWafer(ByVal objChamber As DataManagerment.Equipment, ByVal iIndex As Integer)
        If objChamber.GetWaferInfo(iIndex) Is Nothing Then
            Return False
        End If
        Dim strWaferId As String = objChamber.GetWaferInfo(iIndex).WaferID
        Dim avpProcessJob As Business.AVPProcessJob = Nothing
        avpProcessJob = Business.AVPCore.Instance().JobManager().GetProcessJob(strWaferId)
        If avpProcessJob IsNot Nothing AndAlso Not avpProcessJob.AVPParentControlJob.IsReturnFreeJob Then
            Return False
        End If
        Return True
    End Function

    Public Shared Function IsOrphanWaferInChamber(ByVal chamberName As String) As Boolean
        'DEBUG
        Dim objChamber As AVPLib.DataManagerment.Equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(chamberName)
        If objChamber Is Nothing Then
            Return False
        End If
        If objChamber.GetWaferInfo() Is Nothing Then
            Return False
        End If
        Dim strWaferId As String = objChamber.GetWaferInfo().WaferID
        Dim avpProcessJob As AVPLib.Business.AVPProcessJob = Nothing
        avpProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(strWaferId)
        If avpProcessJob IsNot Nothing AndAlso Not avpProcessJob.AVPParentControlJob.IsReturnFreeJob Then
            Return False
        End If
        Return True
    End Function

    ''' <author>
    '''    	<name>Truc Lee </name>
    '''    	<date> 2014-04-01</date>
    ''' </author>
    ''' <summary>
    ''' Get all Targetx from Sequence files
    ''' </summary>
    ''' <returns>list of Target of each Chamber</returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllTargetXBaseOnSequenceFiles(ByVal strSeqFile As String) As Hashtable
        Dim hstResult As New Hashtable
        Dim lstTarget As List(Of String)
        Try
            Dim sequenFileName As String = AVPLib.Utils.GetFileName(strSeqFile, "xml")
            Dim filepath As String = AVPLib.ContainerDAO.FPath_SequenceData + "\" + sequenFileName
            'check file is not existed
            If System.IO.File.Exists(filepath) = False Then
                Return Nothing
            End If

            'open sequence file
            Dim wfSequence As AVPLib.DBWaferList = Nothing
            Dim strDescription As String = Nothing
            ' If can not open the flow
            If Not AVPLib.ContainerData.GetSequence(filepath, wfSequence, strDescription) Then
                Return Nothing
            End If

            Dim objChamberController As AVPLib.Business.ChamberController = Nothing
            'open sequence-> each slot has Recipe and 
            For Each waferSlot As DBWaferSlot In wfSequence.WaferList
                For Each seqStep As DBSeqStep In waferSlot.WaferSequence.SeqStepList
                    If (seqStep.StationList.Count > 0) Then

                        Dim sRecipeName As String = seqStep.RecipeName
                        Dim sStationName As String = seqStep.StationList.Item(0)

                        If Not hstResult.ContainsKey(sStationName) Then
                            hstResult.Add(sStationName, New List(Of String))
                        End If

                        If sStationName = AVPLib.ConstEnum.Equipments.Aligner.ToString() Then
                            Continue For
                        End If

                        objChamberController = AVPLib.Business.ControllerManager.GetController(sStationName)
                        If objChamberController IsNot Nothing Then
                            'get all targetx base on Recipe
                            lstTarget = objChamberController.GetAllTargetBaseOnRecipe(sRecipeName, sStationName)

                            'check if Targetx is in Old list
                            If lstTarget IsNot Nothing AndAlso lstTarget.Count > 0 Then
                                'get old list of Target
                                Dim lstOldTarget As List(Of String) = hstResult.Item(sStationName)
                                'check contain
                                If lstOldTarget IsNot Nothing Then
                                    For Each strItem As String In lstTarget
                                        'if not -> add Targetx to list
                                        If lstOldTarget.Contains(strItem) = False Then
                                            lstOldTarget.Add(strItem)
                                        End If
                                    Next
                                End If
                            End If
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return hstResult
    End Function

    Public Shared Function CheckWaferOnLoadlockExistIn(ByVal EquipmentName As String, ByVal LoadLockName As String) As Boolean
        'DEBUG
        Dim objChamber As AVPLib.DataManagerment.Equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(EquipmentName)
        If objChamber Is Nothing Then
            Return False
        End If
        If objChamber.GetWaferInfo() Is Nothing Then
            Return False
        End If
        If (objChamber.GetWaferInfo().WaferID.Contains("B") And LoadLockName.Contains("A")) Then
            Return False
        ElseIf (objChamber.GetWaferInfo().WaferID.Contains("A") And LoadLockName.Contains("B")) Then
            Return False
        End If
        Return True
    End Function

    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-05-21</date>
    ''' </author>
    ''' <summary>
    ''' check chambers online or offline
    '''if have chambers offline => return list chambers's name
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>  

    Public Shared Function CheckChamberStationsNotExistAndNotOnline(ByVal ChamberStations As List(Of String),
                                                                    ByVal blCycleInATMMode As Boolean) As List(Of String)

        Dim ChamberNotOnline As List(Of String) = New List(Of String)
        If (ChamberStations Is Nothing) Or (ChamberStations.Count = 0) Then
            Return ChamberNotOnline
        End If
        For Each chamber As String In ChamberStations
            ' if this is the Aligner, assume that it's online
            If (chamber = AVPLib.ConstEnum.Equipments.Aligner.ToString()) Then
                Continue For
            End If

            If AVPLib.ContainerData.IsChamberVisible(chamber) = False Or (IsChamberOnline(chamber) = False AndAlso blCycleInATMMode = False) Then
                ChamberNotOnline.Add(chamber)
            End If
        Next
        Return ChamberNotOnline
    End Function
    ''' <author>
    '''    	<name> Truc Le' </name>
    '''    	<date> 2009-05-21</date>
    ''' </author>
    ''' <summary>
    ''' Get list IBE not online
    ''' used for ANYIBE
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>  

    Public Shared Function GetListIBENotOnline() As List(Of String)
        Dim ChamberNotOnline As List(Of String) = New List(Of String)
        Try
            Dim chamberName As String = String.Empty
            For index As Integer = 1 To AVPRobotMain.MaxChamber2Install
                chamberName = ConstEnum.Chamber + index.ToString

                If (AVPLib.ContainerData.IsChamberVisible(chamberName) AndAlso
                ContainerForm.ChamberPanel(chamberName).ChamberType = AVPLib.SystemModule.ModuleType.IBE AndAlso
                Not IsChamberOnline(chamberName)) Then
                    ChamberNotOnline.Add(chamberName)
                End If
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return ChamberNotOnline
    End Function

    Public Shared Function CheckChamberStationsExistWafer(ByVal ChamberStations As List(Of String)) As List(Of String)
        Dim ChamberExistWafer As List(Of String) = New List(Of String)
        If (ChamberStations Is Nothing) Or (ChamberStations.Count = 0) Then
            Return ChamberExistWafer
        End If
        For Each chamber As String In ChamberStations
            If chamber <> ConstEnum.Equipments.IBE.ToString() AndAlso Utils.IsOrphanWaferInCoronaChamber(chamber) Then
                ChamberExistWafer.Add(chamber)
            End If
        Next
        Return ChamberExistWafer
    End Function
    '''
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-11-28</date>
    ''' </author>
    ''' <summary>
    ''' check ANY IBE EXISTED and ONLINE
    '''ANY IBE ONLINE = ANY IBE EXISTED + ONLINE + NO WAFER ON IT
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CheckAnyIBEOnline() As Boolean
        Dim blResult As Boolean = False
        Dim chamberName As String = String.Empty
        For index As Integer = 1 To AVPRobotMain.MaxChamber2Install
            chamberName = ConstEnum.Chamber + index.ToString

            If (AVPLib.ContainerData.IsChamberVisible(chamberName) AndAlso
            ContainerForm.ChamberPanel(chamberName).ChamberType = AVPLib.SystemModule.ModuleType.IBE AndAlso
            IsChamberOnline(chamberName) AndAlso
            Not Utils.IsOrphanWaferInChamber(chamberName)) Then
                blResult = True
                GoTo ExitFunc
            End If
        Next
ExitFunc:
        Return blResult
    End Function

    Public Shared Function CheckStartScheduler_ReachFaultLimit(ByVal ChamberStations As List(Of String), ByVal hTargetUsedInChamber As Hashtable) As String
        Dim ListOf_PMReachFaultLmt As String = String.Empty
        Try
            For Each chamber As String In ChamberStations
                'don't check Aligner KWH
                If chamber = AVPLib.ConstEnum.Equipments.Aligner.ToString() Then
                    Continue For
                End If
                'Get current KWH
                Dim objConfigChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(chamber)
                If objConfigChamber IsNot Nothing AndAlso objConfigChamber.IsVisible AndAlso objConfigChamber.Type = SystemModule.ModuleType.PVD AndAlso
                (objConfigChamber.RFTargetPowerVisible OrElse objConfigChamber.DCTargetPowerVisible OrElse objConfigChamber.BiasPowerVisible) Then
                    Dim objpvdChamber As DataManagerment.PVDChamber = DataManagerment.EquipmentManager.GetEquipment(chamber)
                    Dim currentKWH As Double = 0
                    If objConfigChamber.DCTargetPowerVisible Then
                        currentKWH = objpvdChamber.DCTargetPowerSupply_KWH_Readback
                    ElseIf objConfigChamber.RFTargetPowerVisible Then
                        currentKWH = objpvdChamber.RFTargetPowerSupply_KWH_Readback
                    ElseIf objConfigChamber.BiasPowerVisible Then
                        currentKWH = objpvdChamber.BiasPowerKWHReadback
                    End If
                    If objpvdChamber.IsUseMaxLimit Then
                        If currentKWH >= Math.Abs(objConfigChamber.Alarm_KWH - objConfigChamber.Max_KWH_Source) Then
                            ListOf_PMReachFaultLmt += AVPLib.Utils.chamberID2ChamberName(chamber) + ", "
                        End If
                    ElseIf currentKWH >= objConfigChamber.Alarm_KWH Then
                        ListOf_PMReachFaultLmt += AVPLib.Utils.chamberID2ChamberName(chamber) + ", "
                    End If
                    ''IBE
                ElseIf objConfigChamber IsNot Nothing AndAlso objConfigChamber.IsVisible AndAlso objConfigChamber.Type = SystemModule.ModuleType.IBE Then
                    Dim objIBEChamber As DataManagerment.IBEChamber = DataManagerment.EquipmentManager.GetEquipment(chamber)
                    Dim currentSource As Double = objIBEChamber.SourceUsageTimeCurrent
                    If objIBEChamber.IsUseMaxLimit Then
                        If currentSource >= Math.Abs(objConfigChamber.SourceUsageTimeLimit - objConfigChamber.Max_KWH_Source) Then
                            ListOf_PMReachFaultLmt += AVPLib.Utils.chamberID2ChamberName(chamber) + ", "
                        End If
                    ElseIf currentSource >= objConfigChamber.SourceUsageTimeLimit Then
                        ListOf_PMReachFaultLmt += AVPLib.Utils.chamberID2ChamberName(chamber) + ", "
                    End If
                    ''PVD4
                ElseIf objConfigChamber IsNot Nothing AndAlso objConfigChamber.IsVisible AndAlso objConfigChamber.Type = SystemModule.ModuleType.PVD4 Then
                    Dim objPVD4Chamber As DataManagerment.CoronaChamber = DataManagerment.EquipmentManager.GetEquipment(chamber)
                    If objPVD4Chamber IsNot Nothing Then
                        If objPVD4Chamber.CheckingKWHOverAlarmLimit(hTargetUsedInChamber.Item(chamber)) Then
                            ListOf_PMReachFaultLmt += AVPLib.Utils.chamberID2ChamberName(chamber) + ", "
                        End If
                    Else
                        ListOf_PMReachFaultLmt += AVPLib.Utils.chamberID2ChamberName(chamber) + ", "
                    End If
                    ''PVD5T
                ElseIf objConfigChamber IsNot Nothing AndAlso objConfigChamber.IsVisible AndAlso objConfigChamber.Type = SystemModule.ModuleType.PVD5T Then
                    Dim objPVD5TChamber As DataManagerment.PVD5TChamber = DataManagerment.EquipmentManager.GetEquipment(chamber)
                    If objPVD5TChamber IsNot Nothing Then
                        If objPVD5TChamber.CheckingKWHOverAlarmLimit(hTargetUsedInChamber.Item(chamber)) Then
                            ListOf_PMReachFaultLmt += AVPLib.Utils.chamberID2ChamberName(chamber) + ", "
                        End If
                    Else
                        ListOf_PMReachFaultLmt += AVPLib.Utils.chamberID2ChamberName(chamber) + ", "
                    End If
                End If
            Next
            If Not String.IsNullOrEmpty(ListOf_PMReachFaultLmt) Then
                ListOf_PMReachFaultLmt = ListOf_PMReachFaultLmt.Remove(ListOf_PMReachFaultLmt.LastIndexOf(","), 2)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return ListOf_PMReachFaultLmt
    End Function

    Public Shared Function CheckStartScheduler_ReachWarningLimit(ByVal ChamberStations As List(Of String), ByVal hTargetUsedInChamber As Hashtable) As String
        Dim ListOf_PMReachWarningLmt As String = String.Empty
        Try
            Dim objPm As DataManagerment.Chamber = Nothing
            For Each chamber As String In ChamberStations
                'don't check Aligner KWH
                If chamber = AVPLib.ConstEnum.Equipments.Aligner.ToString() Then
                    Continue For
                End If
                'Get current KWH
                Dim objChamber As SystemModule = AVPLib.ContainerData.GetRobotConfig(chamber)
                If objChamber IsNot Nothing AndAlso objChamber.IsVisible AndAlso objChamber.Type = SystemModule.ModuleType.PVD AndAlso
                (objChamber.RFTargetPowerVisible OrElse objChamber.DCTargetPowerVisible OrElse objChamber.BiasPowerVisible) Then
                    Dim objpvdChamber As DataManagerment.PVDChamber = DataManagerment.EquipmentManager.GetEquipment(chamber)
                    Dim currentKWH As Double = 0
                    If objChamber.DCTargetPowerVisible Then
                        currentKWH = objpvdChamber.DCTargetPowerSupply_KWH_Readback
                    ElseIf objChamber.RFTargetPowerVisible Then
                        currentKWH = objpvdChamber.RFTargetPowerSupply_KWH_Readback
                    ElseIf objChamber.BiasPowerVisible Then
                        currentKWH = objpvdChamber.BiasPowerKWHReadback
                    End If
                    objPm = DataManagerment.EquipmentManager.GetEquipment(chamber)

                    If (objPm IsNot Nothing) AndAlso objPm.IsUseMaxLimit Then
                        Dim dblWarningKWH As Double = Math.Abs(objChamber.Warning_KWH - objChamber.Max_KWH_Source)
                        If currentKWH >= dblWarningKWH Then
                            ListOf_PMReachWarningLmt += AVPLib.Utils.chamberID2ChamberName(chamber) + ", "
                        End If
                    ElseIf currentKWH >= objChamber.Warning_KWH Then
                        ListOf_PMReachWarningLmt += AVPLib.Utils.chamberID2ChamberName(chamber) + ", "
                    End If
                    ''IBE
                ElseIf objChamber IsNot Nothing AndAlso objChamber.IsVisible AndAlso objChamber.Type = SystemModule.ModuleType.IBE Then
                    Dim objIBEChamber As DataManagerment.IBEChamber = DataManagerment.EquipmentManager.GetEquipment(chamber)
                    Dim currentSource As Double = objIBEChamber.SourceUsageTimeCurrent
                    objPm = DataManagerment.EquipmentManager.GetEquipment(chamber)

                    If (objPm IsNot Nothing) AndAlso objPm.IsUseMaxLimit Then
                        Dim dblSourceWarning As Double = Math.Abs(objChamber.SourceUsageTimeWarning - objChamber.Max_KWH_Source)
                        If currentSource >= dblSourceWarning Then
                            ListOf_PMReachWarningLmt += AVPLib.Utils.chamberID2ChamberName(chamber) + ", "
                        End If
                    ElseIf currentSource >= objChamber.SourceUsageTimeWarning Then
                        ListOf_PMReachWarningLmt += AVPLib.Utils.chamberID2ChamberName(chamber) + ", "
                    End If
                    ''PVD4
                ElseIf objChamber IsNot Nothing AndAlso objChamber.IsVisible AndAlso objChamber.Type = SystemModule.ModuleType.PVD4 Then
                    Dim objPVD4Chamber As DataManagerment.CoronaChamber = DataManagerment.EquipmentManager.GetEquipment(chamber)
                    If objPVD4Chamber IsNot Nothing Then
                        If objPVD4Chamber.CheckingKWHOverWarningLimit(hTargetUsedInChamber.Item(chamber)) Then
                            ListOf_PMReachWarningLmt += AVPLib.Utils.chamberID2ChamberName(chamber) + ", "
                        End If
                    Else
                        ListOf_PMReachWarningLmt += AVPLib.Utils.chamberID2ChamberName(chamber) + ", "
                    End If
                    ''PVD5T
                ElseIf objChamber IsNot Nothing AndAlso objChamber.IsVisible AndAlso objChamber.Type = SystemModule.ModuleType.PVD5T Then
                    Dim objPVD5TChamber As DataManagerment.PVD5TChamber = DataManagerment.EquipmentManager.GetEquipment(chamber)
                    If objPVD5TChamber IsNot Nothing Then
                        If objPVD5TChamber.CheckingKWHOverWarningLimit(hTargetUsedInChamber.Item(chamber)) Then
                            ListOf_PMReachWarningLmt += AVPLib.Utils.chamberID2ChamberName(chamber) + ", "
                        End If
                    Else
                        ListOf_PMReachWarningLmt += AVPLib.Utils.chamberID2ChamberName(chamber) + ", "
                    End If
                End If
            Next
            If Not String.IsNullOrEmpty(ListOf_PMReachWarningLmt) Then
                ListOf_PMReachWarningLmt = ListOf_PMReachWarningLmt.Remove(ListOf_PMReachWarningLmt.LastIndexOf(","), 2)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return ListOf_PMReachWarningLmt
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' CheckStartScheduler_ShieldsQuartz_ReachFaultLimit
    ''' </summary>
    Public Shared Function CheckStartScheduler_ShieldsQuartz_ReachFaultLimit(ByVal ChamberStations As List(Of String), ByVal hTargetUsedInChamber As Hashtable) As String
        Dim ListOf_PMReachFaultLmt As String = String.Empty
        Try
            For Each chamber As String In ChamberStations
                'don't check Aligner KWH
                If chamber = AVPLib.ConstEnum.Equipments.Aligner.ToString() Then
                    Continue For
                End If

                Dim objController As AVPLib.Business.ChamberController = AVPLib.Business.ControllerManager.GetController(chamber)
                If objController IsNot Nothing Then
                    ListOf_PMReachFaultLmt += objController.CheckingShieldsQuartzOverAlarmLimit(hTargetUsedInChamber.Item(chamber))
                End If
            Next
            If Not String.IsNullOrEmpty(ListOf_PMReachFaultLmt) Then
                ListOf_PMReachFaultLmt = ListOf_PMReachFaultLmt.Remove(ListOf_PMReachFaultLmt.LastIndexOf(","), 2)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return ListOf_PMReachFaultLmt
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' CheckStartScheduler_ShieldsQuartz_ReachWarningLimit
    ''' </summary>
    Public Shared Function CheckStartScheduler_ShieldsQuartz_ReachWarningLimit(ByVal ChamberStations As List(Of String), ByVal hTargetUsedInChamber As Hashtable) As String
        Dim ListOf_PMReachWarningLmt As String = String.Empty
        Try
            Dim objPm As DataManagerment.Chamber = Nothing
            For Each chamber As String In ChamberStations
                'don't check Aligner KWH
                If chamber = AVPLib.ConstEnum.Equipments.Aligner.ToString() Then
                    Continue For
                End If

                Dim objController As AVPLib.Business.ChamberController = AVPLib.Business.ControllerManager.GetController(chamber)
                If objController IsNot Nothing Then
                    ListOf_PMReachWarningLmt += objController.CheckingShieldsQuartzOverWarningLimit(hTargetUsedInChamber.Item(chamber))
                End If
            Next
            If Not String.IsNullOrEmpty(ListOf_PMReachWarningLmt) Then
                ListOf_PMReachWarningLmt = ListOf_PMReachWarningLmt.Remove(ListOf_PMReachWarningLmt.LastIndexOf(","), 2)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return ListOf_PMReachWarningLmt
    End Function

    Public Shared Function CheckLLHivac_Open(ByVal LLName As String) As Boolean
        If LLName = ConstEnum.Equipments.LoadLockA.ToString AndAlso RobotConfigurationValues.LLA_HIVAC_INSTALLED Then
            Dim objLoadLock As DataManagerment.LoadLock = AVPLib.DataManagerment.EquipmentManager.GetEquipment(LLName)
            Return (objLoadLock.HiVacValveStatus = DataManagerment.Equipment.WorkingStatuses.On)
        Else ' alway return true when is not install hivac valve
            Return True
        End If
    End Function

    Public Shared Function CheckLLIG_On(ByVal LLName As String) As Boolean
        Try
            Dim objLoadLock As DataManagerment.LoadLock = AVPLib.DataManagerment.EquipmentManager.GetEquipment(LLName)
            If objLoadLock.IsIGInstalled Then
                Return (objLoadLock.IGStatus = DataManagerment.Equipment.WorkingStatuses.On)
            Else
                Return True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return True
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-11-04</date>
    ''' </author>
    ''' <summary>
    ''' Check WaferID has paused job 
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function Check_WaferID_Has_PausedJob(ByVal waferID As String, Optional ByRef isPausedby_PMOffline_MesaClosed As Boolean = False) As Boolean
        Try
            Dim avpProcessJob As AVPLib.Business.AVPProcessJob = Nothing
            If AVPLib.Business.AVPCore.Instance().JobManager Is Nothing Then
                Return False
            End If
            avpProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(waferID)
            If avpProcessJob IsNot Nothing AndAlso avpProcessJob.IsPaused Then
                isPausedby_PMOffline_MesaClosed = avpProcessJob.JobPaused_By_PMOffline_CloseSplitValve OrElse avpProcessJob.ErrorWhenPlaceToStation
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function

    Public Shared Sub Lock_UnLockDiagnosticScreen(ByVal ListOfPM As List(Of String), ByVal LLName As String, ByVal blnIsLock As Boolean)
        If LLName = LOAD_LOCK_A Then
            ContainerForm.Diagnostic.dgsPumpDownLLA.Enable_Disable_Start(Not (blnIsLock), String.Empty)
            ContainerForm.Diagnostic.dgsPumpDownLLA.IsScheduler_Running = blnIsLock
            ContainerForm.Diagnostic.dgsRateOfRiseLLA.Enable_Disable_Start(Not (blnIsLock), String.Empty)
            ContainerForm.Diagnostic.dgsRateOfRiseLLA.IsScheduler_Running = blnIsLock
        End If
        ContainerForm.Diagnostic.dgsPumpDownTM.Enable_Disable_Start(Not (blnIsLock), LLName)
        ContainerForm.Diagnostic.dgsPumpDownTM.IsScheduler_Running = blnIsLock
        ContainerForm.Diagnostic.dgsRateOfRiseTM.Enable_Disable_Start(Not (blnIsLock), LLName)
        ContainerForm.Diagnostic.dgsRateOfRiseTM.IsScheduler_Running = blnIsLock
        ''
        If ListOfPM IsNot Nothing Then
            If ListOfPM.Contains(Equipments.Chamber1.ToString()) Then
                ContainerForm.Diagnostic.dgsPumpDownPM1.Enable_Disable_Start(Not (blnIsLock), LLName)
                ContainerForm.Diagnostic.dgsPumpDownPM1.IsScheduler_Running = blnIsLock
                ContainerForm.Diagnostic.dgsRateOfRisePM1.Enable_Disable_Start(Not (blnIsLock), LLName)
                ContainerForm.Diagnostic.dgsRateOfRisePM1.IsScheduler_Running = blnIsLock
            End If
            If ListOfPM.Contains(Equipments.Chamber2.ToString()) Then
                ContainerForm.Diagnostic.dgsPumpDownPM2.Enable_Disable_Start(Not (blnIsLock), LLName)
                ContainerForm.Diagnostic.dgsPumpDownPM2.IsScheduler_Running = blnIsLock
                ContainerForm.Diagnostic.dgsRateOfRisePM2.Enable_Disable_Start(Not (blnIsLock), LLName)
                ContainerForm.Diagnostic.dgsRateOfRisePM2.IsScheduler_Running = blnIsLock
            End If
            If ListOfPM.Contains(Equipments.Chamber3.ToString()) Then
                ContainerForm.Diagnostic.dgsPumpDownPM3.Enable_Disable_Start(Not (blnIsLock), LLName)
                ContainerForm.Diagnostic.dgsPumpDownPM3.IsScheduler_Running = blnIsLock
                ContainerForm.Diagnostic.dgsRateOfRisePM3.Enable_Disable_Start(Not (blnIsLock), LLName)
                ContainerForm.Diagnostic.dgsRateOfRisePM3.IsScheduler_Running = blnIsLock
            End If
        End If
    End Sub

    Public Shared Sub ChangeBiasPlasmaControlStatus(ByVal strPanelName As String, ByVal PlasmaOn As Boolean)
        Try
            Dim objProcessPM As PMControl = Nothing
            Dim objCassettePM As PMControl = Nothing
            AVPRobotMain.GetPMControl(strPanelName, objProcessPM, objCassettePM)
            If objProcessPM IsNot Nothing AndAlso objCassettePM IsNot Nothing Then
                If objProcessPM.PlasmaIsOn <> PlasmaOn Then
                    objProcessPM.PlasmaIsOn = PlasmaOn
                    objProcessPM.Repaint()
                End If

                If objCassettePM.PlasmaIsOn <> PlasmaOn Then
                    objCassettePM.PlasmaIsOn = PlasmaOn
                    objCassettePM.Repaint()
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-07-30 </date>
    ''' </author>
    ''' <summary>
    ''' Change target plasma status, source plasma status to PMControl
    ''' </summary>
    Public Shared Sub ChangeTargetPlasmaControlStatus(ByVal strPanelName As String, ByVal PlasmaOn As Boolean)
        Try
            Dim objProcessPM As PMControl = Nothing
            Dim objCassettePM As PMControl = Nothing
            AVPRobotMain.GetPMControl(strPanelName, objProcessPM, objCassettePM)
            If objProcessPM IsNot Nothing AndAlso objCassettePM IsNot Nothing Then
                If objProcessPM.SourceIsOn <> PlasmaOn Then
                    objProcessPM.SourceIsOn = PlasmaOn
                    objProcessPM.Repaint()
                End If

                If objCassettePM.SourceIsOn <> PlasmaOn Then
                    objCassettePM.SourceIsOn = PlasmaOn
                    objCassettePM.Repaint()
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-07-30 </date>
    ''' </author>
    ''' <summary>
    ''' Change Shutter status to PMControl
    ''' </summary>
    Public Shared Sub ChangeShutterControlStatus(ByVal chamberName As String, ByVal shutterStatus As DataManagerment.Equipment.WorkingStatuses)
        Try
            Dim objProcessPM As PMControl = Nothing
            Dim objCassettePM As PMControl = Nothing
            AVPRobotMain.GetPMControl(chamberName, objProcessPM, objCassettePM)
            If objProcessPM IsNot Nothing AndAlso objCassettePM IsNot Nothing Then
                If objProcessPM.ShutterStatus <> shutterStatus Then
                    objProcessPM.ShutterStatus = shutterStatus
                    objProcessPM.Repaint()
                End If
                If objCassettePM.ShutterStatus <> shutterStatus Then
                    objCassettePM.ShutterStatus = shutterStatus
                    objCassettePM.Repaint()
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-09-07</date>
    ''' </author>
    ''' <summary>
    ''' Check condition : if value of CG readback (IBE) < IBE_RoughPump_Max_Value then Rough Line valve On and otherwise
    ''' If value of CG readback (IBE) > IBE_RoughPump_Max_Value then rough line valve Off
    ''' </summary>
    ''' <param name=""></param>
    ''' <remarks></remarks>
    Public Shared Sub ChangeRoughLineValveControlStatus(ByVal strPanelName As String, ByVal Value As Double)
        Try
            If strPanelName = Equipments.Chamber1.ToString() Or strPanelName = Equipments.Chamber2.ToString() _
                Or strPanelName = Equipments.Chamber3.ToString() Then
                Dim panelObj As IBEPanel = ContainerForm.ChamberPanel(strPanelName)
                Select Case strPanelName
                    Case Equipments.Chamber1.ToString()
                        Dim RoughPumpMaxValue_Chamber1 As Double = AVPLib.ContainerData.GetPressureConfig("Chamber1_RoughPump_Max_Value")
                        If Value <= RoughPumpMaxValue_Chamber1 Then
                            GoTo ENDFUNC_STATUSON
                        Else
                            GoTo ENDFUNC_STATUSOFF
                        End If
                    Case Equipments.Chamber2.ToString()
                        Dim RoughPumpMaxValue_Chamber2 As Double = AVPLib.ContainerData.GetPressureConfig("Chamber2_RoughPump_Max_Value")
                        If Value <= RoughPumpMaxValue_Chamber2 Then
                            GoTo ENDFUNC_STATUSON
                        Else
                            GoTo ENDFUNC_STATUSOFF
                        End If
                    Case Equipments.Chamber3.ToString()
                        Dim RoughPumpMaxValue_Chamber3 As Double = AVPLib.ContainerData.GetPressureConfig("Chamber3_RoughPump_Max_Value")
                        If Value <= RoughPumpMaxValue_Chamber3 Then
                            GoTo ENDFUNC_STATUSON
                        Else
                            GoTo ENDFUNC_STATUSOFF
                        End If
                End Select
ENDFUNC_STATUSON:
                panelObj.RoughPump_Line.Status = BinaryStatusControl.DisplayStatus.On
                Return
ENDFUNC_STATUSOFF:
                panelObj.RoughPump_Line.Status = BinaryStatusControl.DisplayStatus.Off
                Return
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Truc Le </name>
    '''    	<date> 2011-03-17</date>
    ''' </author>
    ''' <summary>
    ''' Update IG/CG value on ProcessPanel,CassettePanel
    ''' </summary>
    ''' <param name=""></param>
    ''' <remarks></remarks>
    Public Shared Sub UpdateIGCGValue(ByVal IGCGValue As String, ByVal ChamberName As String)
        Try
            Select Case ChamberName
                Case Equipments.Chamber1.ToString()
                    ContainerForm.CassettesPanel.IgcgChamber1.IGCGValue = IGCGValue
                    ContainerForm.ProcessPanel.cbcChamber1.IGCGValue = IGCGValue
                    Dim objChamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(Equipments.Chamber1.ToString())
                    If objChamberConfig IsNot Nothing AndAlso objChamberConfig.Type = ModuleType.PVD5T Then
                        ContainerForm.CassettesPanel.TMCtl.lblPressure.Text = IGCGValue
                        ContainerForm.ProcessPanel.TMCtl.lblPressure.Text = IGCGValue
                    End If
                Case Equipments.Chamber2.ToString()
                    ContainerForm.CassettesPanel.IgcgChamber2.IGCGValue = IGCGValue
                    ContainerForm.ProcessPanel.cbcChamber2.IGCGValue = IGCGValue
                    Dim objChamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(Equipments.Chamber2.ToString())
                    If objChamberConfig IsNot Nothing AndAlso objChamberConfig.Type = ModuleType.PVD5T Then
                        ContainerForm.CassettesPanel.TMCtl.lblPressure.Text = IGCGValue
                        ContainerForm.ProcessPanel.TMCtl.lblPressure.Text = IGCGValue
                    End If
                Case Equipments.Chamber3.ToString()
                    Dim objChamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(Equipments.Chamber3.ToString())
                    If objChamberConfig IsNot Nothing AndAlso objChamberConfig.Type = ModuleType.PVD5T Then
                        ContainerForm.CassettesPanel.TMCtl.lblPressure.Text = IGCGValue
                        ContainerForm.ProcessPanel.TMCtl.lblPressure.Text = IGCGValue
                    End If
                    ContainerForm.CassettesPanel.IgcgChamber3.IGCGValue = IGCGValue
                    ContainerForm.ProcessPanel.cbcChamber3.IGCGValue = IGCGValue
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    '' <author>
    ''    	<name> Le Hieu Truc </name>
    ''    	<date> 2009-12-11 </date>
    '' </author>
    '' <summary>
    '' show customize AVP Messagebox
    '' </summary>
    '' <remarks></remarks>
    Friend Shared Function ShowAVPAbortMessageBox(ByVal strMessage As String,
                                             ByVal strTitle As String,
                                             ByVal avpMessageBoxIcon As MessageBoxIcon) As DialogResult
        Dim avpAbortMsgBox As AVPAbortBox = Nothing
        avpAbortMsgBox = New AVPAbortBox(strTitle, strMessage, avpMessageBoxIcon)
        avpAbortMsgBox.ShowDialog()
        Return avpAbortMsgBox.DialogResult
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' show customize AVP Messagebox, although default is YesNo, but logic is ok/cancle.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Function ShowAVPMessageBox(ByVal strMessage As String,
                                             ByVal strTitle As String,
                                             ByVal avpMessageBoxIcon As MessageBoxIcon,
                                             Optional ByVal mbutton As AVP_Robot_Project.AVPMessageBox.AVPMessageBoxButton = AVPMessageBox.AVPMessageBoxButton.YesNo,
                                             Optional ByVal isShowTopMost As Boolean = False) As DialogResult
        Dim avpMsgBox As AVPMessageBox = Nothing
        avpMsgBox = New AVPMessageBox(strTitle, strMessage, avpMessageBoxIcon, mbutton)
        avpMsgBox.TopMost = isShowTopMost
        avpMsgBox.ShowDialog()
        Return avpMsgBox.DialogResult
    End Function

    ''' <author>
    '''    	<name> Tri Do </name>
    '''    	<date> 2015-06-02 </date>
    ''' </author>
    ''' <summary>
    ''' show customize AVP Messagebox, although default is YesNo, but logic is ok/cancle.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Function ShowAVPMessageBoxWithCB(ByVal strMessage As String,
                                             ByVal strTitle As String,
                                             ByVal avpMessageBoxIcon As MessageBoxIcon,
                                             ByVal additionalText As String,
                                             ByRef isCheck As Boolean,
                                             Optional ByVal mbutton As AVP_Robot_Project.AVPMessageBox.AVPMessageBoxButton = AVPMessageBox.AVPMessageBoxButton.YesNo,
                                             Optional ByVal isShowTopMost As Boolean = False) As DialogResult
        Dim avpMsgBox As AVPMessageBox = Nothing
        avpMsgBox = New AVPMessageBox(strTitle, strMessage, avpMessageBoxIcon, mbutton)
        avpMsgBox.TopMost = isShowTopMost
        If Not String.IsNullOrEmpty(additionalText) Then
            avpMsgBox.UpdateCheckboxText(additionalText)
        End If
        avpMsgBox.ShowDialog()
        isCheck = avpMsgBox.CheckBoxChecked
        Return avpMsgBox.DialogResult
    End Function

    Friend Shared Function ShowAVPWarningBox(ByVal strMessage As String,
                                             ByVal strTitle As String,
                                             Optional ByVal isShowTopMost As Boolean = False) As DialogResult
        Dim avpMsgBox As AVPWarningBox = Nothing
        avpMsgBox = New AVPWarningBox(strTitle, strMessage)
        avpMsgBox.TopMost = isShowTopMost
        avpMsgBox.ShowDialog()
        Return avpMsgBox.DialogResult
    End Function

#Region "Show Core Message Box"
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-29 </date>
    ''' </author>
    ''' <summary>
    ''' Same as ShowAVPMessageBox but it is called from another thread.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Function ShowCoreAVPMessageBox(ByVal avpMsgBox As AVPMessageBox) As DialogResult
        avpMsgBox.Owner = Application.OpenForms(0) 'main form.
        avpMsgBox.Owner.Invoke(New ShowMessageBox(AddressOf ShowMsg), avpMsgBox)
        Return avpMsgBox.DialogResult
    End Function

    Public Delegate Sub ShowMessageBox(ByRef p_MsgBox As AVPMessageBox)

    Public Shared Sub ShowMsg(ByRef p_MsgBox As AVPMessageBox)
        p_MsgBox.ShowDialog()
    End Sub
#End Region

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' show customize AVP Messagebox
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Function ShowAVPMessageBoxWith_OpenCloseCancelConfirm(ByVal strMessage As String,
                                             ByVal strTitle As String,
                                             ByVal avpMessageBoxIcon As MessageBoxIcon) As DialogResult
        Dim avpMsgBox As AVPMessageBox = Nothing
        avpMsgBox = New AVPMessageBox(strTitle, strMessage, avpMessageBoxIcon, AVPMessageBox.AVPMessageBoxButton.OpenCloseCancel)
        avpMsgBox.ShowDialog()
        Return avpMsgBox.DialogResult
    End Function
    ''' <author>
    '''    	<name> Van Le </name>
    '''    	<date> 2012-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' show customize AVP Messagebox
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Function ShowAVPMessageBoxWith_OnOffCancelConfirm(ByVal strMessage As String,
                                             ByVal strTitle As String,
                                             ByVal avpMessageBoxIcon As MessageBoxIcon) As DialogResult
        Dim avpMsgBox As AVPMessageBox = Nothing
        avpMsgBox = New AVPMessageBox(strTitle, strMessage, avpMessageBoxIcon, AVPMessageBox.AVPMessageBoxButton.TurnOnTurnOffCancel)
        avpMsgBox.ShowDialog()
        Return avpMsgBox.DialogResult
    End Function

    Friend Shared Function ShowAVPMessageBoxWith_UpDownCancelConfirm(ByVal strMessage As String,
                                         ByVal strTitle As String,
                                         ByVal avpMessageBoxIcon As MessageBoxIcon) As DialogResult
        Dim avpMsgBox As AVPMessageBox = Nothing
        avpMsgBox = New AVPMessageBox(strTitle, strMessage, avpMessageBoxIcon, AVPMessageBox.AVPMessageBoxButton.UpDownCancel)
        avpMsgBox.ShowDialog()
        Return avpMsgBox.DialogResult
    End Function

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' show customize AVP Messagebox
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Function ShowAVPUseAlignerMessageBox(ByVal Source As String, ByVal Dest As String, ByVal Dest_is_Aligner As Boolean, ByVal Aligner_RecipeDefault As String) As DialogResult
        Dim avpMsgBox As AVPUseAlignerDialogBox = Nothing
        'Dat Cao fix default Aligner
        'avpMsgBox = New AVPUseAlignerDialogBox(Source, Dest, Dest_is_Aligner, Aligner_RecipeDefault)
        'remove default
        avpMsgBox = New AVPUseAlignerDialogBox(Source, Dest, Dest_is_Aligner)

        'when aligner is not free then disable aligner check box
        If (isAlignerInUse() AndAlso Not Source.Contains("Aligner")) Then
            avpMsgBox.chkUseAligner.Enabled = False
            avpMsgBox.chkUseAligner.Checked = False
        Else
            avpMsgBox.chkUseAligner.Enabled = True
            avpMsgBox.chkUseAligner.Checked = True
        End If

        avpMsgBox.ShowDialog()
        Return avpMsgBox.DialogResult
    End Function
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-04-18 </date>
    ''' </author>
    ''' <summary>
    ''' Aligner Status
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function isAlignerInUse() As Boolean

        If Not AVPLib.RobotConfigurationValues.ALINER_VISIBLE Then
            Return False
        End If

        Dim e As AVPLib.DataManagerment.Equipment = Nothing
        e = AVPLib.DataManagerment.EquipmentManager.GetEquipment("Aligner")
        If (e IsNot Nothing AndAlso e.GetWaferInfo() IsNot Nothing) Then
            Return True
        End If
        Return False
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' show customize AVP Messagebox
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Function ShowAVPDeleteMultiMessageBox(ByVal strMessage As String,
                                             ByVal strTitle As String,
                                             ByVal avpMessageBoxIcon As MessageBoxIcon) As DialogResult
        Dim avpMsgBox As AVPMessageBox = Nothing
        avpMsgBox = New AVPMessageBox(strTitle, strMessage, avpMessageBoxIcon, True)
        avpMsgBox.ShowDialog()
        Return avpMsgBox.DialogResult
    End Function

    Public Shared Sub Core_ShowMessageBox(ByVal messageText As String)
        Dim avpMsgBox As AVPMessageBox = Nothing
        avpMsgBox = New AVPMessageBox("AVP Info", messageText, MessageBoxIcon.Information, AVPMessageBox.AVPMessageBoxButton.OK)
        avpMsgBox.TopMost = True

        ThreadPool.QueueUserWorkItem(AddressOf Show_Core_MessageBox, avpMsgBox)
    End Sub

    Public Shared Sub Show_Core_MessageBox(ByVal msgBox As Object)
        Dim avpMsgBox As AVPMessageBox = CType(msgBox, AVPMessageBox)
        ShowCoreAVPMessageBox(avpMsgBox)
    End Sub

    Friend Shared Function ShowAVPMessageBoxWithYesNoConfirm(ByVal strMessage As String,
                                             ByVal strTitle As String,
                                             ByVal avpMessageBoxIcon As MessageBoxIcon) As DialogResult
        Dim avpMsgBox As AVPMessageBox = Nothing
        avpMsgBox = New AVPMessageBox(strTitle, strMessage, avpMessageBoxIcon, AVPMessageBox.AVPMessageBoxButton.YesNo)
        avpMsgBox.ShowDialog()
        Return avpMsgBox.DialogResult
    End Function

    Friend Shared Function ShowAVPMessageBoxWithTurnOnTurnOffCancelConfirm(ByVal strMessage As String,
                                            ByVal strTitle As String,
                                            ByVal avpMessageBoxIcon As MessageBoxIcon) As DialogResult
        Dim avpMsgBox As AVPMessageBox = Nothing
        avpMsgBox = New AVPMessageBox(strTitle, strMessage, avpMessageBoxIcon, AVPMessageBox.AVPMessageBoxButton.TurnOnTurnOffCancel)
        avpMsgBox.ShowDialog()
        Return avpMsgBox.DialogResult
    End Function

    Friend Shared Function ShowAVPMessageBoxWithOpenCloseCancelConfirm(ByVal strMessage As String,
                                             ByVal strTitle As String,
                                             ByVal avpMessageBoxIcon As MessageBoxIcon) As DialogResult
        Dim avpMsgBox As AVPMessageBox = Nothing
        avpMsgBox = New AVPMessageBox(strTitle, strMessage, avpMessageBoxIcon, AVPMessageBox.AVPMessageBoxButton.OpenCloseCancel)
        avpMsgBox.ShowDialog()
        Return avpMsgBox.DialogResult
    End Function

    Friend Shared Function ShowAVPMessageBoxWith_AutoManualCancelConfirm(ByVal strMessage As String,
                                         ByVal strTitle As String,
                                         ByVal avpMessageBoxIcon As MessageBoxIcon) As DialogResult
        Dim avpMsgBox As AVPMessageBox = Nothing
        avpMsgBox = New AVPMessageBox(strTitle, strMessage, avpMessageBoxIcon, AVPMessageBox.AVPMessageBoxButton.AutoManualCancel)
        avpMsgBox.ShowDialog()
        Return avpMsgBox.DialogResult
    End Function


    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2010-07-01 </date>
    ''' </author>
    ''' <summary>
    ''' Check Hivac Valve before Regen/Off/On Cryo
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Function CheckHivacValveOpen_BeforeCryo(ByVal panelName As String) As Boolean
        Dim blnRes As Boolean = False
        Try
            If panelName.Contains(Equipments.LLACryo.ToString()) Then
                If ContainerForm.CassettesPanel.HivacValveLLA.Status = BinaryStatusControl.DisplayStatus.On Then
                    panelName = ContainerForm.CassettesPanel.crcLLACryo.Text
                    blnRes = True
                    Exit Try
                Else
                    blnRes = False
                    Exit Try
                End If
            ElseIf panelName.Contains(Equipments.TMCryo.ToString()) Then
                If ContainerForm.CassettesPanel.TMCtl.HivacOpenButton.Status = ThirdStatusControl.DisplayStatus.On Then
                    panelName = ContainerForm.CassettesPanel.crcTMCryo.Text
                    blnRes = True
                    Exit Try
                Else
                    blnRes = False
                    Exit Try
                End If
            ElseIf panelName.Contains(Equipments.TMWaterPump.ToString()) Then
                If ContainerForm.CassettesPanel.TMCtl.HivacOpenButton.Status = ThirdStatusControl.DisplayStatus.On Then
                    panelName = ContainerForm.CassettesPanel.crcTMWaterPump.Text
                    blnRes = True
                    Exit Try
                Else
                    blnRes = False
                    Exit Try
                End If
            End If
            Dim chamberpnl As AVP_Robot_Project.ChamberPanel = ContainerForm.ChamberPanel(panelName)
            If chamberpnl Is Nothing Then
                blnRes = True
            End If
            If chamberpnl.ChamberType = AVPLib.SystemModule.ModuleType.PVD AndAlso
                CType(chamberpnl, PVDPanel).btnHivacValve.Status = DisplayStatus.On Then
                blnRes = True
            ElseIf chamberpnl.ChamberType = AVPLib.SystemModule.ModuleType.IBE AndAlso
                CType(chamberpnl, IBEPanel).SLContainerBox.ValveCryoHivac.Status = DisplayStatus.On Then
                blnRes = True
                'TODO: CORONA Here
            ElseIf chamberpnl.ChamberType = AVPLib.SystemModule.ModuleType.PVD4 AndAlso
                CType(chamberpnl, CoronaPanel).btnHivacValve.Status = DisplayStatus.On Then
                blnRes = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        If blnRes Then
            Utils.ShowAVPMessageBox("Hivac Valve is Opened", AVPLib.Utils.chamberID2ChamberName(panelName), MessageBoxIcon.Hand, MessageBoxButtons.OK)
        End If
        Return blnRes
    End Function

    Public Shared Sub AlignerCMDAction(ByVal blnActionSend As Boolean, ByVal blnManualAction As Boolean)
        ' In this case, we have to access directly to the controller
        Dim objAlignerController As Business.AlignerController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.Aligner.ToString()), Business.AlignerController)
        objAlignerController.ActionCMDSent = blnActionSend
        objAlignerController.IsManualAction = blnManualAction
    End Sub

    Public Shared Sub RobotCMDAction(ByVal blnActionSend As Boolean, ByVal blnManualAction As Boolean)
        ' In this case, we have to access directly to the controller
        Dim objRobotController As Business.RobotController = CType(Business.ControllerManager.GetController(ConstEnum.Equipments.Robot.ToString()), Business.RobotController)
        objRobotController.ActionCMDSent = blnActionSend
        objRobotController.IsManualAction = blnManualAction
    End Sub

#Region "Time Count"

    Public Shared Sub CountUnProtectedTimeInProcessModule(ByVal chamberName As String)
        Dim objIBEPanel As IBEPanel = ContainerForm.ChamberPanel(chamberName)
        If objIBEPanel Is Nothing Then
            Exit Sub
        End If
        If objIBEPanel.bUnProtectedClicked = True Then ''set when user click UnProtected button
            If objIBEPanel.intTimeUnProtectedTimeCountInProcessModule = 0 Then
                objIBEPanel.intTimeUnProtectedTimeCountInProcessModule = Environment.TickCount
            Else
                If Environment.TickCount - objIBEPanel.intTimeUnProtectedTimeCountInProcessModule > 10000 Then
                    objIBEPanel.bUnProtectedClicked = False
                    objIBEPanel.btnUnProtected.Status = SL_CustomButton.DisplayStatus.Off
                    'Send IBE command off
                    Dim ibeCtl As Business.ChamberController = Business.ControllerManager.GetController(chamberName)
                    Dim objIBEController As Business.IBEController = CType(ibeCtl.Myself, Business.IBEController)
                    objIBEController.DoMnuFixture("FixtureUnProtected", STR_OFF)
                End If
            End If
        Else
            objIBEPanel.intTimeUnProtectedTimeCountInProcessModule = 0
        End If
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-03-09</date>
    ''' </author>
    ''' <summary>
    ''' Count Source Usage Time
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub CountSourceUsageTime(ByVal ChamberID As String)
        Dim objIBE As DataManagerment.IBEChamber = DataManagerment.EquipmentManager.GetEquipment(ChamberID)
        Dim iCurrentTickCount As Integer = Environment.TickCount
        If objIBE.RFPower_readback = DataManagerment.Equipment.WorkingStatuses.On AndAlso objIBE.Ion_Beam_Readback = DataManagerment.Equipment.WorkingStatuses.On Then
            objIBE.SourceUsageTimeCurrent += ((iCurrentTickCount - objIBE.m_lLastTickCountCalculateSourceMinutes) / (60000.0F))
            Dim PropertyNames As ArrayList = New ArrayList()
            Dim ReplyValues As ArrayList = New ArrayList()
            ReplyValues.Add(objIBE.SourceUsageTimeCurrent)
            PropertyNames.Add("SourceUsageTimeCurrent")
            AVPLib.DataManagerment.EquipmentManager.ChangeStatus(ChamberID, PropertyNames, ReplyValues)
        End If
        objIBE.m_lLastTickCountCalculateSourceMinutes = iCurrentTickCount
    End Sub
#End Region

#Region "Generate Data Output File"
    Public Shared Sub WriteDataToCSVFile(ByVal strPath As String, ByVal dataRows As List(Of String))
        Dim streamWriter As IO.StreamWriter = New IO.StreamWriter(strPath, True)
        For Each row As String In dataRows
            streamWriter.WriteLine(row)
        Next
        streamWriter.Flush()
        streamWriter.Close()
        streamWriter.Dispose()
    End Sub

    ''' <author>
    '''     <name> Dung Pham </name>
    '''     <date> 2018-11-20 </date>
    ''' </author>
    ''' <summary>
    ''' Export To CSV File
    ''' </summary>
    Public Shared Sub ExportToCSVFile(ByVal xmlDoc As XmlDocument, ByVal strFileName As String)
        Try

            Dim selectedNode As XmlNode
            Dim csvStringBuilder As New StringBuilder(1000)

            selectedNode = xmlDoc.SelectSingleNode("//Description")
            csvStringBuilder.AppendFormat("Description,{0}{1}", selectedNode.InnerText, vbCrLf)

            selectedNode = xmlDoc.SelectSingleNode("//Start")
            csvStringBuilder.AppendFormat("Start,{0}{1}", selectedNode.InnerText, vbCrLf)

            selectedNode = xmlDoc.SelectSingleNode("//Result")
            csvStringBuilder.AppendFormat("Result,{0}{1}{2}{3}{4}", selectedNode.InnerText, vbCrLf, vbCrLf, "Time,Pressure", vbCrLf)

            selectedNode = xmlDoc.SelectSingleNode("//SampleList")

            For Each sampleNode As XmlNode In selectedNode.ChildNodes
                For Each itemNote As XmlNode In sampleNode.ChildNodes
                    If itemNote.Name.Contains("Time") Then
                        csvStringBuilder.AppendFormat("{0},", itemNote.InnerText)
                    Else
                        If itemNote.Name.Contains("Pressure") Then
                            csvStringBuilder.AppendFormat("{0}{1}", itemNote.InnerText, vbCrLf)
                        End If
                    End If
                Next
            Next

            Using writer As StreamWriter = New System.IO.StreamWriter(strFileName.Replace("xml", "csv"))
                writer.WriteLine(csvStringBuilder)
                writer.Flush()
            End Using

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Dung Pham </name>
    '''     <date> 2018-12-04 </date>
    ''' </author>
    ''' <summary>
    ''' File In Use.
    ''' </summary>
    Public Shared Function FileInUse(ByVal sFile As String) As Boolean
        Dim thisFileInUse As Boolean = False

        If System.IO.File.Exists(sFile) Then
            Try
                Using f As New IO.FileStream(sFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
                    ' thisFileInUse = False
                End Using
            Catch
                thisFileInUse = True
            End Try
        End If

        Return thisFileInUse
    End Function

    Public Shared Function GenerateDataOutputFileName() As String
        Dim strFileName = String.Empty
        Dim strSystemName As String = "SL"
        Dim strDate As String = DateTime.Now.ToString("yyyy_MM_dd")
        Return strFileName
    End Function

    Public Shared Function ConvertRotationModeToText(ByVal strMode As String) As String
        Dim strTextMode As String = String.Empty
        Try
            Dim iMode As Integer = 0
            Integer.TryParse(strMode, iMode)
            Select Case iMode
                Case 1
                    strTextMode = FixtureMode.Continuous.ToString()
                Case 2
                    strTextMode = FixtureMode.Home.ToString()
                Case 3
                    strTextMode = FixtureMode.Static.ToString()
                Case 4
                    strTextMode = FixtureMode.Sweep.ToString()
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strTextMode
    End Function

    Public Shared Function ConvertWorkingStatusToOpenCloseStatus(ByVal status As AVPLib.DataManagerment.Equipment.WorkingStatuses) As String
        Dim strResult As String = ConstantAndEnum.UNKNOWN
        Try
            Select Case status
                Case DataManagerment.Equipment.WorkingStatuses.On
                    strResult = ConstantAndEnum.OPENED
                Case DataManagerment.Equipment.WorkingStatuses.Off
                    strResult = ConstantAndEnum.CLOSED
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strResult
    End Function
#End Region

    Public Shared Sub ChangeWaferStatusColor(ByVal value As String, ByVal ChamberName As String)
        Try
            Dim objChamber As AVPLib.DataManagerment.Equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ChamberName)
            If objChamber Is Nothing Then
                Exit Sub
            End If

            For i As Integer = 1 To objChamber.WaferCapacity
                Select Case value
                    Case ConstEnum.enumWaferStatus.eWaferNew
                        If objChamber.GetWaferInfo(i) IsNot Nothing AndAlso Not (objChamber.GetWaferInfo(i).WaferStatus = enumWaferStatus.eWaferNew) Then
                            objChamber.GetWaferInfo(i).WaferStatus = enumWaferStatus.eWaferNew
                            'for change all GUI (PVD, Process, TM)
                            AVPLib.Business.ControllerManager.SetWaferInsideChamber_without_UpdateGEM(objChamber.Name, STR_ON, objChamber.GetWaferInfo(i), True, i)
                        End If
                    Case ConstEnum.enumWaferStatus.eWaferComplete
                        If objChamber.GetWaferInfo(i) IsNot Nothing AndAlso Not (objChamber.GetWaferInfo(i).WaferStatus = enumWaferStatus.eWaferComplete) Then
                            If CanUpdateWaferStatus(objChamber.GetWaferInfo(i).WaferID) Then
                                objChamber.GetWaferInfo(i).WaferStatus = enumWaferStatus.eWaferComplete
                                'for change all GUI (PVD, Process, TM)
                                AVPLib.Business.ControllerManager.SetWaferInsideChamber_without_UpdateGEM(objChamber.Name, STR_ON, objChamber.GetWaferInfo(i), True, i)
                            End If
                        End If
                    Case ConstEnum.enumWaferStatus.eWaferError
                        If objChamber.GetWaferInfo(i) IsNot Nothing AndAlso Not (objChamber.GetWaferInfo(i).WaferStatus = enumWaferStatus.eWaferError) Then
                            objChamber.GetWaferInfo(i).WaferStatus = enumWaferStatus.eWaferError
                            'for change all GUI (PVD, Process, TM)
                            AVPLib.Business.ControllerManager.SetWaferInsideChamber_without_UpdateGEM(objChamber.Name, STR_ON, objChamber.GetWaferInfo(i), True, i)
                        End If
                    Case ConstEnum.enumWaferStatus.eWaferExposed
                        If objChamber.GetWaferInfo(i) IsNot Nothing AndAlso Not (objChamber.GetWaferInfo(i).WaferStatus = enumWaferStatus.eWaferExposed) Then
                            objChamber.GetWaferInfo(i).WaferStatus = enumWaferStatus.eWaferExposed
                            'for change all GUI (PVD, Process, TM)
                            AVPLib.Business.ControllerManager.SetWaferInsideChamber_without_UpdateGEM(objChamber.Name, STR_ON, objChamber.GetWaferInfo(i), True, i)
                        End If

                    Case ConstEnum.enumWaferStatus.eWaferNone
                        'If objChamber.GetWaferInfo(i) IsNot Nothing Then
                        '    objChamber.SetWaferInfo(Nothing, i)
                        '    'for change all GUI (PVD, Process, TM)
                        '    AVPLib.Business.ControllerManager.SetWaferInsideChamber_without_UpdateGEM(objChamber.Name, STR_OFF, objChamber.GetWaferInfo(i), True, i)
                        'End If

                End Select
            Next
            objChamber.WaferStatus = Integer.Parse(value)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub



    Public Shared Function CanUpdateWaferStatus(ByVal WaferID As String) As Boolean
        If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
            Dim avpProcessJob As AVPLib.Business.AVPProcessJob = AVPLib.Business.AVPCore.Instance().JobManager().GetProcessJob(WaferID)
            If avpProcessJob Is Nothing OrElse avpProcessJob.IsAutoTransfer = False Then
                Return True
            End If
            Return avpProcessJob.isLastStep()
        End If
    End Function
    'Only for SL
    'Dat Cao
    Public Shared Function CheckRecipeExisted(ByVal strRecipename As String, Optional ByVal ChamberName As String = "") As Boolean
        Try
            'get list of recipe name on file
            'Dim Chamber As String = AVPLib.ConstEnum.Equipments.Chamber1.ToString()
            If ChamberName = "" Then
                ChamberName = AVPLib.ConstEnum.Equipments.Chamber1.ToString()
            End If
            Dim lstStrRecipe As ArrayList = AVPLib.ContainerData.ListChamber(ChamberName)
            '
            If (lstStrRecipe Is Nothing Or lstStrRecipe.Count = 0) Then
                Return False
            Else
                For Each Name As String In lstStrRecipe
                    If Name = strRecipename Then
                        Return True
                    End If
                Next
                Return False 'not found
            End If
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            Return False
        End Try
    End Function

    Public Shared Sub DeleteTempData(ByVal sPath As String)
        If Not IO.Directory.Exists(sPath) Then
            Exit Sub
        End If

        Try
            Dim myfolder As IO.DirectoryInfo = New IO.DirectoryInfo(sPath)
            Dim mySubfolders() As IO.DirectoryInfo = myfolder.GetDirectories()

            Dim strFiles As IO.FileInfo() = myfolder.GetFiles()

            'delete all files in the current folder
            For Each myItem As IO.FileInfo In strFiles
                myItem.Delete()
            Next

            'for each folder, do a recursive call to this sub routine
            For Each myItem As IO.DirectoryInfo In mySubfolders
                DeleteTempData(myItem.FullName)
            Next
            '      delete the starting folder
            myfolder.Delete()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''     <name> Tinh Le </name>
    '''     <date> 2022-12-09 </date>
    ''' </author>
    ''' <summary>
    ''' Check Other Cryo Is InRegen
    ''' </summary>
    Public Shared Function CheckOtherCryoIsInRegen(ByVal panelName As String) As String
        Dim strRet As String = String.Empty
        Dim strEquipmentName As String = String.Empty

        Try
            'Get Mechanical Pump of equiment
            If panelName.Contains(Equipments.LLACryo.ToString()) Then
                strEquipmentName = ConstEnum.Equipments.LoadLockA.ToString
            ElseIf panelName.Contains(Equipments.TMCryo.ToString()) Then
                strEquipmentName = ConstEnum.Equipments.CassettesModule.ToString
            End If

            Dim objRoughPump As DataManagerment.RoughPumpMachine = DataManagerment.EquipmentManager.GetRoughPumpMachine(strEquipmentName)
            If (objRoughPump IsNot Nothing) Then
                'is check LLA is regenning
                If (objRoughPump.IsUsed(ConstEnum.Equipments.LoadLockA.ToString)) Then
                    Dim objLLPumpPackageCtrl As Business.PumpPackageController = Business.ControllerManager.GetController(ConstEnum.Equipments.LLAPumpPackage.ToString())
                    If objLLPumpPackageCtrl IsNot Nothing Then
                        Dim objCryo As DataManagerment.Cryo = DataManagerment.EquipmentManager.GetEquipment(objLLPumpPackageCtrl.EquipmentName.ToString())
                        If (objCryo IsNot Nothing AndAlso RobotConfigurationValues.LLA_CRYO_VISIBLE) Then
                            If (Not AVPLib.ContainerData.GetOneMainCryoControllerInstalled()) AndAlso
                                    objCryo.RegenStatus = DataManagerment.Equipment.WorkingStatuses.On AndAlso objCryo.RoughPumpIsUseByCryo Then
                                strRet = "LLA Cryo is regenning."
                                Exit Try
                            End If
                        End If
                    End If
                End If

                'is check TM is regenning
                If (objRoughPump.IsUsed(ConstEnum.Equipments.CassettesModule.ToString)) Then
                    Dim objLLPumpPackageCtrl As Business.PumpPackageController = Business.ControllerManager.GetController(ConstEnum.Equipments.TMPumpPackage.ToString())
                    If objLLPumpPackageCtrl IsNot Nothing Then
                        Dim objCryo As DataManagerment.Cryo = DataManagerment.EquipmentManager.GetEquipment(objLLPumpPackageCtrl.EquipmentName.ToString())
                        If (objCryo IsNot Nothing AndAlso RobotConfigurationValues.TMCRYO_VISIBLE) Then
                            If (Not AVPLib.ContainerData.GetOneMainCryoControllerInstalled()) AndAlso
                                   objCryo.RegenStatus = DataManagerment.Equipment.WorkingStatuses.On AndAlso objCryo.RoughPumpIsUseByCryo Then
                                strRet = "TM Cryo is regenning."
                                Exit Try
                            End If
                        End If
                    End If
                End If

                If AVPLib.RobotConfigurationValues.SHARED_MP_WITH_PM Then
                    Dim intMaxOfPM As Integer = 3 'default for CX4
                    For i As Integer = 1 To intMaxOfPM
                        Dim strName As String = ConstEnum.Chamber & i.ToString()
                        Dim objChamber As DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(strName)

                        If objChamber Is Nothing OrElse Not objChamber.EquipmentType = ModuleType.PVD5T Then
                            Continue For
                        End If

                        Dim objPVD5TChamber As DataManagerment.PVD5TChamber = CType(objChamber, DataManagerment.PVD5TChamber)

                        If objRoughPump.IsUsed(strName) AndAlso
                            Not String.IsNullOrEmpty(objPVD5TChamber.CryoRoughPumpInUsed) Then

                            strRet = $"{AVPLib.Utils.chamberID2ChamberName(strName)} Cryo is regenning."
                        End If
                    Next
                End If

            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return strRet
    End Function
    Public Shared Function GenerateRegenStatusToRegenStatusText(ByVal strStatusText As String) As String
        Dim rs As String = String.Empty
        Select Case strStatusText
            Case "A", "\"
                rs = CRYO_REGEN_STATUS_TEXT.CRYOPUMP_OFF
            Case "B", "C", "E", "^", "]"
                rs = CRYO_REGEN_STATUS_TEXT.WARM_UP
            Case "D", "F", "G", "Q", "R"
                rs = CRYO_REGEN_STATUS_TEXT.PURGE_GAS_FAILURE
            Case "H", "S"
                rs = CRYO_REGEN_STATUS_TEXT.EXTENDED_PURGE_OR_REPURGE_CYCLE
            Case "I", "J", "K", "T", "a", "b", "j", "n"
                rs = CRYO_REGEN_STATUS_TEXT.ROUGH_TO_BASE
            Case "L"
                rs = CRYO_REGEN_STATUS_TEXT.RATE_OF_RISE
            Case "M", "N", "c", "d", "o"
                rs = CRYO_REGEN_STATUS_TEXT.COOLDOWN
            Case "P"
                rs = CRYO_REGEN_STATUS_TEXT.COMPLETE
            Case "U"
                rs = CRYO_REGEN_STATUS_TEXT.BEGIN_FAST_REGEN
            Case "V"
                rs = CRYO_REGEN_STATUS_TEXT.ABORTED
            Case "W"
                rs = CRYO_REGEN_STATUS_TEXT.DELAY_RESTART
            Case "X", "Y"
                rs = CRYO_REGEN_STATUS_TEXT.POWER_FAILURE
            Case "Z"
                rs = CRYO_REGEN_STATUS_TEXT.DELAY_START
            Case "O", "["
                rs = CRYO_REGEN_STATUS_TEXT.ZEROING_TC_GAUSE
            Case "f"
                rs = CRYO_REGEN_STATUS_TEXT.SHARE_REGEN_WAIT
            Case "e"
                rs = CRYO_REGEN_STATUS_TEXT.REPURGE
            Case "h"
                rs = CRYO_REGEN_STATUS_TEXT.PURGE_COORD_WAIT
            Case "i"
                rs = CRYO_REGEN_STATUS_TEXT.ROUGH_COORD_WAIT
            Case "k"
                rs = CRYO_REGEN_STATUS_TEXT.PURGE_GAS_FAIL
            Case "l", "m", "_", "r", "s", "t", "u", "v", "`"
                rs = CRYO_REGEN_STATUS_TEXT.WARMUP
        End Select

        Return rs
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-07-12 </date>
    ''' </author>
    ''' <summary>
    ''' Add Lot Datalog for the info that want to log to all LLA.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub AddLotDatalog(ByVal Info As String)
        Try
            If (AVPLib.Business.AVPCore.Instance() IsNot Nothing) Then

                Dim objLoadLockACtrl As AVPLib.Business.LoadLockController = Nothing
                Dim objCtrlJobA As AVPLib.Business.AVPControlJob = Nothing
                objLoadLockACtrl = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())

                If (objLoadLockACtrl IsNot Nothing AndAlso objLoadLockACtrl.CtrlJobId <> String.Empty) Then
                    objCtrlJobA = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockACtrl.CtrlJobId)
                    If (objCtrlJobA IsNot Nothing) Then
                        AVPLib.Business.AVPLotDatalog.AddLotDatalog(AVPLib.ConstEnum.LoadLockA_STR,
                        LogType.Info, Info, objCtrlJobA.IsAutoTransferJob)
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#Region "Check License"
    Public Shared Function ShowNetworkInterfaces() As List(Of String)
        Dim computerProperties As System.Net.NetworkInformation.IPGlobalProperties = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties()
        Dim nics As System.Net.NetworkInformation.NetworkInterface() = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
        Dim lstStringMacID As List(Of String) = New List(Of String)
        If nics Is Nothing OrElse nics.Length < 1 Then
            Return lstStringMacID
        End If

        'Console.WriteLine("  Number of interfaces .................... : {0}", nics.Length)
        For Each adapter As System.Net.NetworkInformation.NetworkInterface In nics
            'Dim speedA As Long = adapter.Speed
            Dim properties As System.Net.NetworkInformation.IPInterfaceProperties = adapter.GetIPProperties()

            Dim address As System.Net.NetworkInformation.PhysicalAddress = adapter.GetPhysicalAddress()
            Dim bytes As Byte() = address.GetAddressBytes()
            Dim strMacID As String = String.Empty
            For i As Integer = 0 To bytes.Length - 1

                strMacID = strMacID & bytes(i).ToString("X2")
                ' Insert a hyphen after each byte, unless we are at the end of the
                ' address.
                If i <> bytes.Length - 1 Then
                    strMacID = strMacID & "-"
                End If
            Next
            If Not String.IsNullOrEmpty(strMacID) Then
                lstStringMacID.Add(strMacID)
            End If
        Next
        Return lstStringMacID
    End Function

    Private Shared Sub Create_MarkedRegistry()
        Try
            Dim machine As String = "CX4"
            Dim strType As String = String.Empty
            strType = "12" & StrReverse(machine) & "02"
            Dim regKey As Microsoft.Win32.RegistryKey
            regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE", True)
            Dim strKey As String = "VAP " & strType & " Systems"
            regKey.CreateSubKey(strKey)
            regKey.Close()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Shared Sub Set_MarkedRegistry(ByVal strRunDate As String)
        Try
            Dim strType As String = String.Empty
            Dim machine As String = "CX4"
            strType = "12" & StrReverse(machine) & "02"
            Dim regKey As Microsoft.Win32.RegistryKey
            Dim strKey As String = "VAP " & strType & " Systems"
            regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\" & strKey, True)
            If regKey Is Nothing Then
                regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE", True)
                regKey.CreateSubKey(strKey)

                ' If regKey is nothing, have to re-open SubKey
                regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\" & strKey, True)
            End If
            regKey.SetValue("Config", strRunDate)
            regKey.Close()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Function Read_MarkedRegistry(ByRef strLastRunDate As String) As Boolean
        Dim haveKey As Boolean = True
        Try
            Dim machine As String = "CX4"
            Dim strType As String = String.Empty
            strType = "12" & StrReverse(machine) & "02"
            Dim strKey As String = "VAP " & strType & " Systems"
            Dim regKey As Microsoft.Win32.RegistryKey = Nothing
            regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\" & strKey, True)
            'if not created before -> create
            If regKey Is Nothing Then
                Create_MarkedRegistry()
                ' Set current date to registry key
                Set_MarkedRegistry(EncryptionHelper.Encrypt("#" + Date.Today.ToString("MM/dd/yyyy") + "#", "a10dve6p"))
                Return False
            End If

            Dim strName As String() = regKey.GetValueNames()
            Dim strValue As String = String.Empty

            For Each name As String In strName
                If name = "Config" Then
                    strValue = regKey.GetValue("Config")
                    Exit For
                End If
            Next

            If strValue = String.Empty Then
                Return True
            End If

            strLastRunDate = EncryptionHelper.Decrypt(strValue, "a10dve6p")
            regKey.Close()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return haveKey
    End Function

    Private Shared Function GetDateOnRegistry() As String
        Dim strLastRunDate As String = String.Empty
        Dim regKey As Microsoft.Win32.RegistryKey = Nothing
        Try
            Dim root As XmlDocument = BinarySerialize.Open_DatFileConfig(AVPLib.ContainerDAO.FPath_ConfigurationServer)
            Dim machine As String = "CX4"
            Dim strType As String = String.Empty
            If machine IsNot Nothing Then
                strType = "12" & StrReverse(machine) & "02"
            End If
            Dim strKey As String = "VAP " & strType & " Systems"
            regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\" & strKey, True)
            If regKey IsNot Nothing Then
                Dim strName As String() = regKey.GetValueNames()
                Dim strValue As String = String.Empty

                For Each name As String In strName
                    If name = "Config" Then
                        strValue = regKey.GetValue("Config")
                        Exit For
                    End If
                Next

                If strValue <> String.Empty Then
                    strLastRunDate = EncryptionHelper.Decrypt(strValue, "a10dve6p")
                End If

                regKey.Close()
            End If
        Catch ex As Exception
            If regKey IsNot Nothing Then
                regKey.Close()
            End If
            AVPLib.Log.avpLogger.Error("GetDateOnRegistry" & ex.ToString())
        End Try
        Return strLastRunDate
    End Function

    Private Shared Function IsCheckExistsFile(ByVal strNameFile As String) As String
        Dim fileName As String = String.Empty

        Try
            Dim lpath As String = System.IO.Directory.GetCurrentDirectory
            Dim lstFile As String() = System.IO.Directory.GetFiles(lpath, strNameFile)

            If lstFile IsNot Nothing AndAlso lstFile.Length > 0 Then
                fileName = lstFile(0)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return fileName
    End Function

    Public Shared Sub UpdateRegitryIfCan(ByVal strLastRunDate As String)
        Try
            Dim lastRunDate As Date = Date.Today()
            If strLastRunDate.Length > 0 Then
                Dim dateFormats() As String = {"MM/dd/yyyy", "#MM/dd/yyyy#"}
                Date.TryParseExact(strLastRunDate, dateFormats, Nothing, Globalization.DateTimeStyles.None, lastRunDate)
            End If

            ' If today is smaller then the last run date, do not update registry key
            If DateTime.Compare(lastRunDate, Date.Today) < 0 Then
                Set_MarkedRegistry(EncryptionHelper.Encrypt("#" + Date.Today.ToString("MM/dd/yyyy") + "#", "a10dve6p"))
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("UpdateRegitryIfCan" & ex.ToString())
        End Try
    End Sub

    Private Shared Function IsLicenseValid(ByRef strMessage As String) As Boolean
        Try
            Dim fileName As String = IsCheckExistsFile("ApplicationInfo")

            If String.IsNullOrEmpty(fileName) Then
                strMessage = "License file does not exist"
                Return False
            End If

            If System.IO.File.Exists(fileName) Then
                Dim lstFile As AVPLib.AVPDataLib.LicenseData = AVPLib.AVPDataLib.GetXmlData()
                If lstFile Is Nothing OrElse lstFile.Components.Count <= 0 Then
                    Return False
                End If

                Dim lstOfPM As List(Of String) = New List(Of String)

                For Each item As AVPLib.AVPDataLib.ItemData In lstFile.Components
                    If item.Name = "GEM" Then
                        strSupportGem = "GEM"
                    ElseIf item.Type = "PM" Then
                        lstOfPM.Add(item.Name + "-" + item.Value)
                    End If
                Next

                strMessage = IsModuleCorrect(lstFile.MachineName, lstOfPM.Count, lstOfPM)

                If String.IsNullOrEmpty(strMessage) Then
                    Return True
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("IsLicenseValid" & ex.ToString())
        End Try
        Return False
    End Function

    Private Shared Function IsComputerInfoValid(ByVal lstNewFormat As String) As String
        Dim strMessage = String.Empty
        Try
            '#DateExpired
            '#MacID#CPUID#HDDID#CXX#NumberOfChamber#ListOfChamber#GEM
            '6 items + 6 NO_of_PMs 

            Dim itemMacID As String = String.Empty
            Dim strCPUId As String = String.Empty
            Dim strHardDrive As String = String.Empty
            Dim strPMType As String = [String].Empty
            Dim iPMNumber As Integer = 0

            Dim lstOfPM As List(Of String) = New List(Of String)
            'Number Of Modules: 
            Dim strNumberOfModules As String = String.Empty
            'Index of line for Computer Info
            Dim iIndexOfComputerInfo As Integer = 5
            'Number of line NOT include Chamber line
            Dim iNumOfLineNotChamber As Integer = 6


            Dim bMacID As Boolean = False
            Dim bCPUId As Boolean = False
            Dim bHardDrive As Boolean = False

            If lstNewFormat.Contains("#") Then
                Dim lstListOfId As [String]() = lstNewFormat.Split("#")
                If lstListOfId.Length > 5 Then
                    itemMacID = lstListOfId(0)
                    strCPUId = lstListOfId(1)
                    strHardDrive = lstListOfId(2)
                    strPMType = lstListOfId(3)
                    strNumberOfModules = lstListOfId(4)
                    Integer.TryParse(strNumberOfModules, iPMNumber)
                    If iPMNumber > 0 AndAlso lstListOfId.Length = iPMNumber + iNumOfLineNotChamber Then
                        For i As Integer = 0 To iPMNumber - 1
                            lstOfPM.Add(lstListOfId(5 + i))
                        Next
                    End If
                    strSupportGem = lstListOfId(iPMNumber + iIndexOfComputerInfo)
                End If
            End If

            'Check MacID
            Dim lstMac As List(Of String) = ShowNetworkInterfaces()
            For Each itemMac As String In lstMac
                If itemMacID = itemMac Then
                    bMacID = True
                    Exit For
                End If
            Next

            'Check CPUID
            If Not String.IsNullOrEmpty(strCPUId) Then
                Dim lstCPUId As List(Of String) = GetCPUId()
                For Each itemCPUId As String In lstCPUId
                    If strCPUId = itemCPUId Then
                        bCPUId = True
                        Exit For
                    End If
                Next
            End If

            'Check UUID
            If Not String.IsNullOrEmpty(strHardDrive) Then
                Dim lstHardDrive As List(Of String) = GetUUID()
                For Each itemHardDrive As String In lstHardDrive
                    If strHardDrive = itemHardDrive Then
                        bHardDrive = True
                        Exit For
                    End If
                Next
            End If

            If (Not bMacID OrElse Not bCPUId OrElse Not bHardDrive) Then
                strMessage = "Computer Information is invalid. Can not start application."
                Return strMessage
            End If

            'Check PM Type
            If (String.IsNullOrEmpty(strPMType) = False OrElse lstOfPM.Count > 0) Then
                strMessage = IsModuleCorrect(strPMType, iPMNumber, lstOfPM)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("IsComputerInfoValid" & ex.ToString())
        End Try
        Return strMessage
    End Function

    '''' <author>
    ''''    	<name> Hoai Ly </name>
    ''''    	<date> 2015/05/05</date>
    '''' </author>
    '''' <summary>
    '''' Check Gem License
    '''' </summary>
    '''' <remarks></remarks>
    Public Shared Function CheckGemLicense() As Boolean
        Try
            If strSupportGem.Contains("GEM") Then
                Return True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("CheckGemLicense" & ex.ToString())
        End Try
        Return False
    End Function
    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2016-04-15</date>
    ''' </author>
    ''' <summary>
    ''' Write value of System changed in csv file
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function CheckChangeValue(ByVal StrMessage As String, ByVal OldValue As String, ByVal NewValue As String)
        Dim logSystemSetupMessage As String = StrMessage
        If OldValue <> NewValue Then
            logSystemSetupMessage = logSystemSetupMessage & "," & OldValue & "," & NewValue
            AVPLib.Log.settingParameterChangesLogger.Error(logSystemSetupMessage)
        End If
    End Function
    '''' <author>
    ''''    	<name> Dy Do </name>
    ''''    	<date> 2016-03-16</date>
    '''' </author>
    '''' <summary>
    '''' Show Quick View Recipe
    '''' </summary>
    '''' <remarks></remarks>
    Public Shared Function ShowQuickViewRecipe(ByVal Chamber As String, ByVal RecipeName As String, ByVal Title As String,
                                                ByVal isNewRecipe As Boolean, ByVal isFindRunningFolder As Boolean, Optional ByVal dt As DataTable = Nothing,
                                                Optional ByVal dictionaryColor As Dictionary(Of Integer, String) = Nothing) As Boolean
        Dim result As Boolean = True

        Try
            Dim errorMessage As String = String.Empty
            Dim path As String = String.Empty
            Dim pathRunning As String = String.Empty
            Dim templatepath As String = String.Empty
            Dim ChamberType As String = AVPLib.Utils.GetChamberType(Chamber)
            path = AVPLib.ContainerDAO.FPath_ChamberRecipe & "\" & Chamber & "\" & RecipeName & ".xml"
            templatepath = AVPLib.ContainerDAO.FPath_RecipeTemplate & ChamberType & ".xml"
            Dim Hrep As HRecipe = Nothing

            If (AVPLib.ContainerDAO.Enable_ANYIBE_Mode() And ChamberType = AVPLib.SystemModule.ModuleType.IBE.ToString()) OrElse
                Chamber = AVPLib.SystemModule.ModuleType.IBE.ToString() Then

                If Chamber = AVPLib.SystemModule.ModuleType.IBE.ToString() Then
                    ChamberType = Chamber
                End If

                Chamber = GetChamberNameOfAnyChamber(ChamberType, Hrep)

                path = AVPLib.ContainerDAO.FPath_ChamberRecipe & "\" & AVPLib.SystemModule.ModuleType.IBE.ToString() & "\" & RecipeName & ".xml"
            ElseIf isFindRunningFolder AndAlso ChamberType <> SystemModule.ModuleType.Aligner.ToString() Then

                Dim objLoadLockCtrl As AVPLib.Business.LoadLockController = AVPLib.Business.ControllerManager.GetController(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
                Dim objavpCtrlJob As AVPLib.Business.AVPControlJob = AVPLib.Business.AVPCore.Instance().JobManager().GetControlJob(objLoadLockCtrl.CtrlJobId)
                If objavpCtrlJob IsNot Nothing Then
                    pathRunning = AVPLib.ContainerDAO.FPath_TempData & "\" & ConstantAndEnum.LOAD_LOCK_A & "\Recipes" & "\" & Chamber & "\" & RecipeName & ".xml"
                    Title = Title & " (Running)"
                End If
            End If

            If Not isNewRecipe Then
                If isFindRunningFolder AndAlso pathRunning IsNot String.Empty Then
                    If Not System.IO.File.Exists(pathRunning) AndAlso Not System.IO.File.Exists(path) Then
                        errorMessage = String.Format(AVPLib.ContainerData.GetMessageText("EquipmentRecipeDoesNotExist"), RecipeName)
                    End If
                ElseIf Not System.IO.File.Exists(path) Then
                    errorMessage = String.Format(AVPLib.ContainerData.GetMessageText("EquipmentRecipeDoesNotExist"), RecipeName)
                End If
            End If

            If errorMessage Is String.Empty AndAlso Not System.IO.File.Exists(templatepath) Then
                errorMessage = String.Format(AVPLib.ContainerData.GetMessageText("EquipmentRecipeTemplateDoesNotExist"), RecipeName)
            End If

            If Not String.IsNullOrEmpty(errorMessage) Then
                AVPLib.Log.avpLogger.Error(errorMessage & " - Path: " & path)
                ShowAVPMessageBox(errorMessage, "Quick View Recipe", MessageBoxIcon.Error, MessageBoxButtons.OK)
                result = False
                Exit Try
            End If
            If Hrep Is Nothing Then
                Hrep = AVPLib.ContainerData.GetHRecipeToList(Chamber)
            End If

            Dim Qview As QuickViewRecipe = New QuickViewRecipe()
            Qview.Title = Title
            Qview.RecipeTemplatePathQuickView = templatepath
            Qview.RecipePathQuickView = path
            Qview.HRecipeQuickView = Hrep
            Qview.DataTableQuickView = dt
            Qview.DictionaryQuickView = dictionaryColor
            Qview.LoadDataGrid(templatepath, path, Hrep, dt, dictionaryColor)
            Qview.ShowDialog()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("Show Quick View Recipe " & ex.ToString())
            result = False
        End Try

        Return result
    End Function

    ''' <author>
    '''    	<name>Hai Tran</name>
    '''    	<date>2017-01-23</date>
    ''' </author>
    ''' <summary>
    ''' Show Select Recipe Step dialog.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function ShowSelectRecipeStepDialog(ByVal Chamber As String, ByRef selectedRecipe As String, ByRef selectedStep As Integer) As DialogResult
        Try
            Dim ChamberType As String = AVPLib.Utils.GetChamberType(Chamber)
            Dim templatepath As String = AVPLib.ContainerDAO.FPath_RecipeTemplate & ChamberType & ".xml"
            Dim recipeFolder As String = String.Empty
            Dim hRep As HRecipe = Nothing
            If (AVPLib.ContainerDAO.Enable_ANYIBE_Mode() AndAlso ChamberType = AVPLib.SystemModule.ModuleType.IBE.ToString()) _
                OrElse Chamber = AVPLib.SystemModule.ModuleType.IBE.ToString() Then
                If Chamber = AVPLib.SystemModule.ModuleType.IBE.ToString() Then
                    ChamberType = Chamber
                End If
                Chamber = GetChamberNameOfAnyChamber(ChamberType, hRep)

                recipeFolder = AVPLib.ContainerDAO.FPath_ChamberRecipe & "\" & AVPLib.SystemModule.ModuleType.IBE.ToString()
            Else
                recipeFolder = AVPLib.ContainerDAO.FPath_ChamberRecipe & "\" & Chamber
            End If

            If hRep Is Nothing Then
                hRep = AVPLib.ContainerData.GetHRecipeToList(Chamber)
            End If

            Dim recipeList As ArrayList = AVPLib.ContainerData.ListChamber(Chamber)
            Dim dialog As SelectRecipeStepDialog = New SelectRecipeStepDialog(recipeList, templatepath, recipeFolder, hRep)
            Dim result As DialogResult = dialog.ShowDialog()
            If result = DialogResult.OK Then
                selectedRecipe = dialog.SelectedRecipe
                selectedStep = dialog.SelectedStep
            End If
            Return result
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return DialogResult.Cancel
    End Function

    ''' <author>
    '''    	<name>Hai Tran</name>
    '''    	<date>2016-04-06</date>
    ''' </author>
    ''' <summary>
    ''' Get ChamberID of Any Chamber mode.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function GetChamberNameOfAnyChamber(ByVal chamberType As String, Optional ByRef hRecipe As HRecipe = Nothing) As String
        Dim chamberName As String = String.Empty

        Try

            If AVPLib.ContainerDAO.Enable_ANYIBE_Mode() AndAlso chamberType = AVPLib.RobotConfigurationValues.ANY_IBE_CHAMBER Then

                For i As Integer = 1 To RobotConfigurationValues.CHAMBERX_VISIBLE.Count
                    Dim strChamber As String = ConstEnum.Chamber & i.ToString()

                    If RobotConfigurationValues.CHAMBERX_VISIBLE(i - 1) = Boolean.TrueString AndAlso
                       RobotConfigurationValues.CHAMBERX_TYPE(i - 1) = SystemModule.ModuleType.IBE Then

                        hRecipe = AVPLib.ContainerData.GetHRecipeToList(strChamber)
                        If hRecipe IsNot Nothing Then
                            chamberName = strChamber
                            Exit For
                        End If
                    End If
                Next

            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return chamberName
    End Function

    Private Shared Function IsModuleCorrect(ByVal strType As String, ByVal iModuleNumber As Integer, ByVal lstOfPM As List(Of String)) As String
        Dim strMessage As String = "Tool configuration does not match with license. Can not start application."
        Try
            Dim root As XmlDocument = BinarySerialize.Open_DatFileConfig(AVPLib.ContainerDAO.FPath_ConfigurationServer)
            Dim chamber1 As XmlNode = root.SelectSingleNode("Servers/ChamberInstall/Chamber1")
            Dim chamber2 As XmlNode = root.SelectSingleNode("Servers/ChamberInstall/Chamber2")
            Dim chamber3 As XmlNode = root.SelectSingleNode("Servers/ChamberInstall/Chamber3")
            Dim iChamber As Integer = 0

            If strType.ToUpper() <> "CX4" Then
                Return strMessage
            End If

            If chamber1 IsNot Nothing Then
                Dim chamberInstall As String = BuildChamberWithType(chamber1, "PM1", iChamber)
                If Not String.IsNullOrEmpty(chamberInstall) AndAlso Not lstOfPM.Contains(chamberInstall) Then
                    Return strMessage
                End If
            End If

            If chamber2 IsNot Nothing Then
                Dim chamberInstall As String = BuildChamberWithType(chamber2, "PM2", iChamber)
                If Not String.IsNullOrEmpty(chamberInstall) AndAlso Not lstOfPM.Contains(chamberInstall) Then
                    Return strMessage
                End If
            End If

            If chamber3 IsNot Nothing Then
                Dim chamberInstall As String = BuildChamberWithType(chamber3, "PM3", iChamber)
                If Not String.IsNullOrEmpty(chamberInstall) AndAlso Not lstOfPM.Contains(chamberInstall) Then
                    Return strMessage
                End If
            End If

            If iChamber <> iModuleNumber Then
                Return strMessage
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("IsModuleCorrect" & ex.ToString())
            Return strMessage
        End Try
        Return String.Empty
    End Function

    Private Shared Function BuildChamberWithType(ByVal chamberNode As XmlNode, ByVal PMx As String, ByRef iNumber As Integer) As String
        Dim strRes As String = String.Empty
        Try
            If chamberNode IsNot Nothing Then
                Dim attInstall As XmlAttribute = chamberNode.Attributes("IsInstall")
                Dim attPM As XmlAttribute = chamberNode.Attributes("Type")
                Dim iNumberInstall As Integer = 0
                If attInstall IsNot Nothing AndAlso attPM IsNot Nothing Then
                    Integer.TryParse(attInstall.InnerText, iNumberInstall)
                    If attInstall.InnerText.ToUpper() = "TRUE" OrElse iNumberInstall <> 0 Then
                        strRes = PMx + "-" + attPM.InnerText
                        iNumber += 1
                    End If

                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("BuildChamberWithType" & ex.ToString())
        End Try
        Return strRes
    End Function

    Private Shared Function GetCPUId() As List(Of String)
        Dim CPUIDLst As List(Of String) = New List(Of String)
        Try
            Dim mbs As New ManagementObjectSearcher("Select ProcessorID From Win32_processor")
            Dim mbsList As ManagementObjectCollection = mbs.[Get]()
            For Each mo As ManagementObject In mbsList
                If mo IsNot Nothing AndAlso mo("ProcessorID") IsNot Nothing Then
                    CPUIDLst.Add(mo("ProcessorID").ToString().Trim())
                End If
            Next

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return CPUIDLst
    End Function

    Public Shared Function GetUUID() As List(Of String)
        Dim lstUUID As List(Of String) = New List(Of String)
        Try
            Dim mc As New ManagementClass("Win32_ComputerSystemProduct")
            Dim moc As ManagementObjectCollection = mc.GetInstances()

            For Each mo As ManagementObject In moc
                If mo IsNot Nothing AndAlso mo.Properties IsNot Nothing AndAlso mo.Properties("UUID") IsNot Nothing Then
                    lstUUID.Add(mo.Properties("UUID").Value.ToString())
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return lstUUID
    End Function

    Public Shared Function UserCanRunApplication() As Boolean
        Try
            Dim checkLicense As Boolean = False
            Dim message As String = "License is invalid." & vbCrLf & "Can not start application."

            checkLicense = IsLicenseValid(message)

            If checkLicense = False Then
                MsgBox(message, MsgBoxStyle.OkOnly + 48)
                Return False
            End If
        Catch ex As Exception
            MsgBox("An error occurred while system check license. Please contacts AVP for more details.", MsgBoxStyle.OkOnly)
            Return False
        End Try
        Return True
    End Function

    Public Shared Function Encrypt(ByVal strText As String, ByVal strEncrKey As String) As String
        'Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Dim IV As Byte() = New Byte(7) {240, 3, 45, 29, 0, 76, 173, 59}

        Try
            Dim bykey() As Byte = System.Text.Encoding.UTF8.GetBytes(Strings.Left(strEncrKey, 8))
            Dim InputByteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(strText)
            Dim des As New System.Security.Cryptography.DESCryptoServiceProvider
            Dim ms As New IO.MemoryStream
            Dim cs As New System.Security.Cryptography.CryptoStream(ms, des.CreateEncryptor(bykey, IV), System.Security.Cryptography.CryptoStreamMode.Write)
            cs.Write(InputByteArray, 0, InputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
#End Region

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-07-17 </date>
    ''' </author>
    ''' <summary>
    ''' Format message for log
    ''' </summary>
    Public Shared Function FormatLogMessage(ByVal messageSource As String, ByVal sender As Object) As String
        Dim sb As New System.Text.StringBuilder
        sb.AppendFormat("[{0}] ", messageSource)

        If sender IsNot Nothing Then
            If TypeOf sender Is SL_CustomButton OrElse
               TypeOf sender Is ButtonIGCGControl OrElse
               TypeOf sender Is Button Then

                sb.Append(GetLogName(sender))
                sb.Append(" Button Clicked")

            ElseIf TypeOf sender Is ComboBox Then
                Dim cbx As ComboBox = CType(sender, ComboBox)
                sb.Append(cbx.Text)
                If Not String.IsNullOrEmpty(cbx.AccessibleName) Then
                    sb.Append(" item of " & cbx.AccessibleName)
                End If
                sb.Append(" DropDownList Selected")

            ElseIf TypeOf sender Is String Then
                sb.Append(sender)

            Else
                'Support for other object here
            End If
        End If

        Return sb.ToString()
    End Function

#Region "Update min/max value"

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-07-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get Parameters In Function Update Min/Max Value To PM
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function GetParametersInFunctionUpdateMinMaxValueToPM(ByVal strKey As String, ByVal strMinValue As String,
                                                        ByVal strMaxValue As String) As List(Of String)

        Dim lstListParam As New List(Of String)
        Try
            Dim strRegExp As String = "^(Chamber[\d])\..*"
            Dim mtcMatch As Text.RegularExpressions.Match = Regex.Match(strKey, strRegExp)
            Dim strChamber As String = ConvertKeyNameToChamberName(strKey)
            If Not String.IsNullOrEmpty(strChamber) Then
                lstListParam.Add(strChamber)
                lstListParam.Add(strKey)
                lstListParam.Add(strMinValue)
                lstListParam.Add(strMaxValue)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return lstListParam
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-18 </date>
    ''' </author>
    ''' <summary>
    ''' Get chamber name from key.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function ConvertKeyNameToChamberName(ByVal strKey As String) As String
        Dim strChamber As String = String.Empty
        Try
            Dim strRegExp As String = "^(Chamber[\d])\..*"
            Dim mtcMatch As Text.RegularExpressions.Match = Regex.Match(strKey, strRegExp)

            If mtcMatch IsNot Nothing AndAlso mtcMatch.Groups.Count >= 1 Then
                strChamber = mtcMatch.Groups(1).Value
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return strChamber
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-18 </date>
    ''' </author>
    ''' <summary>
    ''' Use for changing min/max value at recipe screen and update these value to pm screen too.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub SynchronizeMinMaxValueToPMScreen(ByVal paramName As String, ByVal strChamber As String, ByVal strMinValue As String, ByVal strMaxValue As String, ByVal groupCode As String)
        Try
            Dim strType As String = String.Empty
            Dim strKey As String = String.Empty
            Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(strChamber)
            strType = serverConfig.Type
            If strType = PVD Then
                Dim objPVDPanel As PVDPanel = ContainerForm.ChamberPanel(strChamber)
                Dim txtTextBox As PVDTextbox
                Select Case paramName
                    Case "TargetPower"
                        If objPVDPanel.TargetPowerSupplyType = SystemModule.PowerSupplyType.DC Then
                            txtTextBox = CType(objPVDPanel, Chamber1DCPVDPanel).DCTargetPowerSupply.txtTargetPowerRight
                            txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                        ElseIf objPVDPanel.TargetPowerSupplyType = SystemModule.PowerSupplyType.RF Then
                            txtTextBox = CType(objPVDPanel, Chamber1RFPVDPanel).RFTargetPowerSupply.txtForwardPowerRight
                            txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                        End If
                    Case "BiasPower"
                        txtTextBox = objPVDPanel.BiasPowerSupply.txtForwardPowerRight
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "Gas1"
                        txtTextBox = objPVDPanel.GasController.txtGas1Right
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "Gas2"
                        txtTextBox = objPVDPanel.GasController.txtGas2Right
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "Gas3"
                        txtTextBox = objPVDPanel.GasController.txtGas3Right
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "Gas4"
                        txtTextBox = objPVDPanel.GasController.txtGas4Right
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "Gas5"
                        txtTextBox = objPVDPanel.GasController.txtGas5Right
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "MagCurrent"
                        txtTextBox = objPVDPanel.ParallelMagnet.txtCurrentRight
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                End Select

            ElseIf strType = IBEType.AVP_IBE.ToString() Or strType = IBEType.VEECO_IBE.ToString() Then
                Dim objIBEPanel As IBEPanel = ContainerForm.ChamberPanel(strChamber)
                Select Case paramName
                    Case "Incident_RF_Power"
                        objIBEPanel.txtRFPowerRight.UpdateMinMaxValue(objIBEPanel.txtRFPowerRight.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                    Case "Beam_Voltage"
                        objIBEPanel.txtBeamVoltageRight.UpdateMinMaxValue(objIBEPanel.txtBeamVoltageRight.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                    Case "Suppresser_Voltage"
                        objIBEPanel.txtSuppressorVoltageRight.UpdateMinMaxValue(objIBEPanel.txtSuppressorVoltageRight.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                    Case "Gas1", "Value_1"
                        objIBEPanel.txtGas1Right.UpdateMinMaxValue(objIBEPanel.txtGas1Right.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                        objIBEPanel.txtGas1Right_SourceTab.UpdateMinMaxValue(objIBEPanel.txtGas1Right_SourceTab.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                    Case "Gas2", "Value_2"
                        objIBEPanel.txtGas2Right.UpdateMinMaxValue(objIBEPanel.txtGas2Right.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                        objIBEPanel.txtGas2Right_SourceTab.UpdateMinMaxValue(objIBEPanel.txtGas2Right_SourceTab.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                    Case "Gas3", "Value_3"
                        objIBEPanel.txtGas3Right.UpdateMinMaxValue(objIBEPanel.txtGas3Right.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                    Case "PBN_FLOWRATE"
                        objIBEPanel.txtPBNGasRight.UpdateMinMaxValue(objIBEPanel.txtPBNGasRight.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                        objIBEPanel.txtPBNGasRight_SourceTab.UpdateMinMaxValue(objIBEPanel.txtPBNGasRight_SourceTab.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                    Case "FlowCool_Flowrate"
                        objIBEPanel.SLFixture.txtFlowCoolGasRight.UpdateMinMaxValue(objIBEPanel.SLFixture.txtFlowCoolGasRight.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                    Case "Fixture_Angle"
                        objIBEPanel.SLFixture.txtTiltAngleRight.UpdateMinMaxValue(objIBEPanel.SLFixture.txtTiltAngleRight.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                    Case "Beam_Current"
                        objIBEPanel.txtBeamCurrentRight.UpdateMinMaxValue(objIBEPanel.txtBeamCurrentRight.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                    Case "K", "K_Factor"
                        objIBEPanel.txtKFactorRight.UpdateMinMaxValue(objIBEPanel.txtKFactorRight.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                    Case "Sweep_Start_Angle"
                        objIBEPanel.SLFixture.txtRotationSweepRight.UpdateMinMaxValue(objIBEPanel.SLFixture.txtRotationSweepRight.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                    Case "Sweep_End_Angle"
                        objIBEPanel.SLFixture.txtRotationEnd.UpdateMinMaxValue(objIBEPanel.SLFixture.txtRotationEnd.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                    Case "Static_Angle"
                        objIBEPanel.SLFixture.txtRotationStaticRight.UpdateMinMaxValue(objIBEPanel.SLFixture.txtRotationStaticRight.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                    Case "Fixture_Rotation_Speed"
                        objIBEPanel.SLFixture.txtRotationContinuousRight.UpdateMinMaxValue(objIBEPanel.SLFixture.txtRotationContinuousRight.GetSource(),
                                                                                        strMinValue, strMaxValue, False)
                End Select

                '2013-01-02 Tin Pham added this code
            ElseIf strType = PVD4 Then
                Dim objCoronaPanel As CoronaPanel = ContainerForm.ChamberPanel(strChamber)
                Dim txtTextBox As SL_Textbox
                Select Case paramName
                    Case "TargetPower"
                        If objCoronaPanel.RFTargetPowerSupply.IsDCTargetPowerSupply Then
                            txtTextBox = objCoronaPanel.RFTargetPowerSupply.txtDCForwardPowerRight
                            txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                        Else
                            txtTextBox = objCoronaPanel.RFTargetPowerSupply.txtForwardPowerRight
                            txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                        End If
                    Case "BiasPower"
                        txtTextBox = objCoronaPanel.BiasPowerSupply.txtForwardPowerRight
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "Gas1"
                        txtTextBox = objCoronaPanel.GasController.txtGas1Right
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "Gas2"
                        txtTextBox = objCoronaPanel.GasController.txtGas2Right
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "Gas3"
                        txtTextBox = objCoronaPanel.GasController.txtGas3Right
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "Gas4"
                        txtTextBox = objCoronaPanel.GasController.txtGas4Right
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "Gas5"
                        txtTextBox = objCoronaPanel.GasController.txtGas5Right
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "TableHeight"
                        txtTextBox = objCoronaPanel.TableControl.txtTablePosRight
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                End Select

            ElseIf strType = PVD5T Then
                Dim objPVD5TPanel As PVD5TPanel = ContainerForm.ChamberPanel(strChamber)
                Dim txtTextBox As SL_Textbox
                Select Case paramName
                    Case "TargetPower"
                        If groupCode = "DCTargetPower" Then
                            txtTextBox = objPVD5TPanel.TabTargetPowerSupply.DCTargetPowerSupply.txtDCForwardPowerRight
                            txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                        Else
                            txtTextBox = objPVD5TPanel.TabTargetPowerSupply.RFTargetPowerSupply.txtForwardPowerRight
                            txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                        End If
                    Case "BiasPower"
                        txtTextBox = objPVD5TPanel.BiasPowerSupply.txtForwardPowerRight
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "Gas1"
                        txtTextBox = objPVD5TPanel.GasController.txtGas1Right
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "Gas2"
                        txtTextBox = objPVD5TPanel.GasController.txtGas2Right
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "Gas3"
                        txtTextBox = objPVD5TPanel.GasController.txtGas3Right
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "Gas4"
                        txtTextBox = objPVD5TPanel.GasController.txtGas4Right
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "Gas5"
                        txtTextBox = objPVD5TPanel.GasController.txtGas5Right
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                    Case "TableHeight"
                        txtTextBox = objPVD5TPanel.TableControl.txtTablePosRight
                        txtTextBox.UpdateMinMaxValue(txtTextBox.GetSource(), strMinValue, strMaxValue)
                End Select
                '-----------------------------------------
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-18 </date>
    ''' </author>
    ''' <summary>
    ''' Use for changing min/max value at PM screen and update these value to recipe screen too.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub SynchronizeMinMaxValueToRecipeScreen(ByVal strKey As String, ByVal strMinValue As String, ByVal strMaxValue As String)
        Try
            Dim strChamber As String = ConvertKeyNameToChamberName(strKey)
            Const PM_NAME_REMOVE_LENGTH As Integer = 9 ' remove "ChamberX." from key 
            strKey = strKey.Remove(0, PM_NAME_REMOVE_LENGTH)
            Dim dbMin As Double = Double.Parse(strMinValue)
            Dim dbMax As Double = Double.Parse(strMaxValue)
            Dim paramName As String = String.Empty
            Dim groupCode As String = String.Empty
            Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(strChamber)
            Dim strType As String = serverConfig.Type

            ''PVD RF, DC Power
            If PM_MIN_MAX_NAME_ITEM.PVD_RF_POWER_MAX_SP.Contains(strKey) Or PM_MIN_MAX_NAME_ITEM.PVD_DC_POWER_MAX_SP.Contains(strKey) Then
                paramName = "TargetPower"

                ''PVD Bias Power        
            ElseIf PM_MIN_MAX_NAME_ITEM.PVD_BIAS_POWER_MAX_SP.Contains(strKey) Then
                paramName = "BiasPower"
                ''PVD Gas1

            ElseIf PM_MIN_MAX_NAME_ITEM.PVD_GAS1_MAX_SP.Contains(strKey) Then
                paramName = "Gas1"

                ''PVD Gas2
            ElseIf PM_MIN_MAX_NAME_ITEM.PVD_GAS2_MAX_SP.Contains(strKey) Then
                paramName = "Gas2"

                ''PVD Gas3
            ElseIf PM_MIN_MAX_NAME_ITEM.PVD_GAS3_MAX_SP.Contains(strKey) Then
                paramName = "Gas3"

                ''PVD Gas4
            ElseIf PM_MIN_MAX_NAME_ITEM.PVD_GAS4_MAX_SP.Contains(strKey) Then
                paramName = "Gas4"

                ''PVD Gas5
            ElseIf PM_MIN_MAX_NAME_ITEM.PVD_GAS5_MAX_SP.Contains(strKey) Then
                paramName = "Gas5"

                ''PVD Parallel Magnet
            ElseIf PM_MIN_MAX_NAME_ITEM.PVD_PARALLEL_MAGNET_MAX_SP.Contains(strKey) Then
                paramName = "MagCurrent"

                ''IBE RF Power
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_RF_POWER_MAX_SP.Contains(strKey) Then
                paramName = "Incident_RF_Power"

                ''IBE Beam Voltage
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_BEAM_VOLTAGE_MAX_SP.Contains(strKey) Then
                paramName = "Beam_Voltage"

                ''IBE Suppressor Voltage
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_SUPPRESSOR_VOLTAGE_MAX_SP.Contains(strKey) Then
                paramName = "Suppresser_Voltage"

                ''IBE Gas 1
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_GAS1_MAX_SP.Contains(strKey) Then
                If strType = IBEType.AVP_IBE.ToString() Then
                    paramName = "Gas1"
                ElseIf strType = IBEType.VEECO_IBE.ToString() Then
                    paramName = "Value_1"
                End If
                If strKey.Contains("SourceTab") Then
                    AVPLib.ContainerData.SetRobotConfig(strChamber & "." & "IBE.txtGas1Right" + STRING_MIN, strMinValue)
                    AVPLib.ContainerData.SetRobotConfig(strChamber & "." & "IBE.txtGas1Right" + STRING_MAX, strMaxValue)
                Else
                    AVPLib.ContainerData.SetRobotConfig(strChamber & "." & "IBE.txtGas1Right_SourceTab" + STRING_MIN, strMinValue)
                    AVPLib.ContainerData.SetRobotConfig(strChamber & "." & "IBE.txtGas1Right_SourceTab" + STRING_MAX, strMaxValue)
                End If

                ''IBE Gas 2
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_GAS2_MAX_SP.Contains(strKey) Then
                If strType = IBEType.AVP_IBE.ToString() Then
                    paramName = "Gas2"
                ElseIf strType = IBEType.VEECO_IBE.ToString() Then
                    paramName = "Value_2"
                End If
                If strKey.Contains("SourceTab") Then
                    AVPLib.ContainerData.SetRobotConfig(strChamber & "." & "IBE.txtGas2Right" + STRING_MIN, strMinValue)
                    AVPLib.ContainerData.SetRobotConfig(strChamber & "." & "IBE.txtGas2Right" + STRING_MAX, strMaxValue)
                Else
                    AVPLib.ContainerData.SetRobotConfig(strChamber & "." & "IBE.txtGas2Right_SourceTab" + STRING_MIN, strMinValue)
                    AVPLib.ContainerData.SetRobotConfig(strChamber & "." & "IBE.txtGas2Right_SourceTab" + STRING_MAX, strMaxValue)
                End If

                ''IBE Gas 3
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_GAS3_MAX_SP.Contains(strKey) Then
                If strType = IBEType.AVP_IBE.ToString() Then
                    paramName = "Gas3"
                ElseIf strType = IBEType.VEECO_IBE.ToString() Then
                    paramName = "Value_3"
                End If

                ''IBE Gas 4
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_GAS4_MAX_SP.Contains(strKey) Then
                If strType = IBEType.AVP_IBE.ToString() Then
                    paramName = "Gas4"
                ElseIf strType = IBEType.VEECO_IBE.ToString() Then
                    paramName = "Value_4"
                End If

                ''IBE Gas 5
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_GAS5_MAX_SP.Contains(strKey) Then
                If strType = IBEType.AVP_IBE.ToString() Then
                    paramName = "Gas5"
                ElseIf strType = IBEType.VEECO_IBE.ToString() Then
                    paramName = "Value_5"
                End If

                ''IBE PBN Gas
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_PBN_GAS_MAX_SP.Contains(strKey) Then
                paramName = "PBN_FLOWRATE"
                If strKey.Contains("SourceTab") Then
                    AVPLib.ContainerData.SetRobotConfig(strChamber & "." & "IBE.txtPBNGasRight" + STRING_MIN, strMinValue)
                    AVPLib.ContainerData.SetRobotConfig(strChamber & "." & "IBE.txtPBNGasRight" + STRING_MAX, strMaxValue)
                Else
                    AVPLib.ContainerData.SetRobotConfig(strChamber & "." & "IBE.txtPBNGasRight_SourceTab" + STRING_MIN, strMinValue)
                    AVPLib.ContainerData.SetRobotConfig(strChamber & "." & "IBE.txtPBNGasRight_SourceTab" + STRING_MAX, strMaxValue)
                End If

                ''IBE Flowcool Gas
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_FLOWCOOL_GAS_MAX_SP.Contains(strKey) Then
                paramName = "FlowCool_Flowrate"

                ''IBE Tilt Angle
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_TILE_ANGLE_MAX_SP.Contains(strKey) Then
                paramName = "Fixture_Angle"

                ''IBE Beam Current
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_BEAM_CURRENT_SP.Contains(strKey) Then
                paramName = "Beam_Current"

                ''IBE K Factor
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_K_FACTOR_SP.Contains(strKey) Then
                paramName = "K_Factor"
                ''IBE Sweep Start
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_SWEEP_START_SP.Contains(strKey) Then
                paramName = "Sweep_Start_Angle"

                ''IBE Sweep End
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_SWEEP_END_SP.Contains(strKey) Then
                paramName = "Sweep_End_Angle"

                ''IBE Static Angle
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_STATIC_ANGLE_SP.Contains(strKey) Then
                paramName = "Static_Angle"

                ''IBE Rotation Speed
            ElseIf PM_MIN_MAX_NAME_ITEM.IBE_ROTATION_SPEED_SP.Contains(strKey) Then
                paramName = "Fixture_Rotation_Speed"

                '2013-01-02 Tin Pham added this code
            ElseIf PM_MIN_MAX_NAME_ITEM.CORONA_TARGET_POWER_MAX_SP.Contains(strKey) Then
                paramName = "TargetPower"
                groupCode = "RFTargetPower"
            ElseIf PM_MIN_MAX_NAME_ITEM.CORONA_TARGET_DC_POWER_MAX_SP.Contains(strKey) Then
                paramName = "TargetPower"
                groupCode = "DCTargetPower"
            ElseIf PM_MIN_MAX_NAME_ITEM.CORONA_BIAS_POWER_MAX_SP.Contains(strKey) Then
                paramName = "BiasPower"
                groupCode = "SubstratePower"
            ElseIf PM_MIN_MAX_NAME_ITEM.CORONA_GAS1_MAX_SP.Contains(strKey) Then
                paramName = "Gas1"
                groupCode = "Gasses"
            ElseIf PM_MIN_MAX_NAME_ITEM.CORONA_GAS2_MAX_SP.Contains(strKey) Then
                paramName = "Gas2"
                groupCode = "Gasses"
            ElseIf PM_MIN_MAX_NAME_ITEM.CORONA_GAS3_MAX_SP.Contains(strKey) Then
                paramName = "Gas3"
                groupCode = "Gasses"
            ElseIf PM_MIN_MAX_NAME_ITEM.CORONA_GAS4_MAX_SP.Contains(strKey) Then
                paramName = "Gas4"
                groupCode = "Gasses"
            ElseIf PM_MIN_MAX_NAME_ITEM.CORONA_GAS5_MAX_SP.Contains(strKey) Then
                paramName = "Gas5"
                groupCode = "Gasses"
            ElseIf PM_MIN_MAX_NAME_ITEM.CORONA_TABLE_POS_RIGHT_MIN.Contains(strKey) Then
                paramName = "TableHeight"
                groupCode = "MotionControl"
                '------------------------------------

            End If


            AVPLib.Utils.SaveMinMaxParameter(groupCode, paramName, strChamber, dbMin, dbMax)
            AVPLib.Utils.UpdateMinMaxRecipe(groupCode, paramName, dbMin, dbMax, strChamber)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region


    '''' <author>
    '''' <name> Huy Nguyen </name>
    '''' <date> 2015-09-01</date>
    '''' </author>
    '''' <summary>
    '''' Is Chamber Processing = 
    ''''  Error
    ''''  Processing
    ''''  Pause
    ''''  Continue
    '''' </summary>
    '''' <remarks></remarks>
    Public Shared Function IsProcessingAtChamber(ByVal ChamberID As String) As Boolean
        Dim blResult As Boolean = False
        Try
            Dim chamber As AVPLib.DataManagerment.Chamber = DataManagerment.EquipmentManager.GetEquipment(ChamberID)
            If (chamber IsNot Nothing AndAlso
            chamber.RunProcessStatus <> ConstEnum.enumProcessStatus.eStop) Then
                blResult = True
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            Return False
        End Try
        Return blResult
    End Function

#Region "Clean DataRun Files"

    '''' <author>
    ''''    	<name> Dung Pham </name>
    ''''    	<date> 2018-11-28</date>
    '''' </author>
    '''' <summary>
    '''' Delete Sub Folder In DataRun
    '''' </summary>
    '''' <remarks></remarks>
    Public Shared Sub DeleteSubFolderAfterDay(ByVal path As String)
        Try
            If Directory.Exists(path) Then
                Dim f As FileInfo = New FileInfo(path)
                Dim driverInfo As DriveInfo = New DriveInfo(f.Directory.Root.FullName)

                If driverInfo.DriveType = System.IO.DriveType.Fixed Then
                    'Delete all child Directories
                    Dim oDirectory As New IO.DirectoryInfo(path)
                    For Each oEntry As IO.DirectoryInfo In oDirectory.GetDirectories
                        'check format of folder
                        If Not System.Text.RegularExpressions.Regex.IsMatch(oEntry.Name,
                                ConstantAndEnum.PATTERN_DATE_UNDERLINED) Then Continue For

                        Dim strFormat As String = ConstantAndEnum.STR_FORMAT_DATE_UNDERLINED
                        Dim strDateNow As String = DateTime.Now.AddDays(-intMaxDateDataRunDelete).ToString(strFormat)

                        Dim dateFile As Date = Date.ParseExact(oEntry.Name, strFormat, Nothing)
                        Dim dateDelete As Date = Date.ParseExact(strDateNow, strFormat, Nothing)

                        If Date.Compare(dateFile, dateDelete) < 0 Then
                            IO.Directory.Delete(oEntry.FullName, True)
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

#Region "Clean Log Files"
    Public Shared Sub CleanLogFiles()
        Try
            Dim DataLogDir As New System.IO.DirectoryInfo(AVPLib.Utils.fileDataLog)
            Dim InternalLogDir As New System.IO.DirectoryInfo(AVPLib.Utils.fileInternalLog)

            Dim aryFi As IO.FileInfo() = InternalLogDir.GetFiles("*.*")
            Dim aryDataFi As IO.FileInfo() = DataLogDir.GetFiles("*.*")

            ''Clean Internal Log file first
            If aryFi Is Nothing Then
                Exit Try
            End If
            CleanUpFiles(aryFi)

            ''then Clean Log Alarm and Event
            If aryDataFi Is Nothing Then
                Exit Try
            End If
            CleanUpFiles(aryDataFi)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub CleanUpFiles(ByVal arrayOfFiles As System.IO.FileInfo())
        'Const MAX_DAYS_TO_DELETE As Integer = 30

        For Each fi As FileInfo In arrayOfFiles
            ''check creation Time < 30
            If fi.LastWriteTime < DateTime.Now.AddDays(-intCleanUpTime) Then
                Try
                    fi.Delete()
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error("Error Delete Log File with CreationTime: " & ex.ToString())
                    Continue For
                End Try

                'Else 'or extract filename to get date <30
                '    Dim arr As Array = fi.Name.Split(".")
                '    If arr IsNot Nothing AndAlso arr.Length > 0 Then
                '        Dim fileDate As Date
                '        If DateTime.TryParse(arr(0).ToString(), fileDate) AndAlso _
                '           fileDate < DateTime.Now.AddDays(-MAX_DAYS_TO_DELETE) Then
                '            Try
                '                fi.Delete()
                '            Catch ex As Exception
                '                AVPLib.Log.avpLogger.Error("Error Delete Log File with FileName: " & ex.ToString())
                '                Continue For
                '            End Try
                '        End If
                '    End If
            End If
        Next

    End Sub

#End Region

    Public Shared Function GetUserInput(ByVal TargetControl As System.Object, ByVal AllowDecimal As Boolean, Optional ByVal IsScientificFormat As Boolean = False) As MsgBoxResult
        Dim UserResponse As MsgBoxResult = MsgBoxResult.Cancel
        Try
            Dim needToCheckMaxMin As Boolean = True
            'If Me.tabPolling.Contains(TargetControl) Then
            '    needToCheckMaxMin = True
            'End If
            Dim Source As String = String.Empty
            Dim Min As Single = 0
            Dim Max As Single = 0

            Dim f As New NumPad()
            Dim Value As String = String.Empty
            If TypeOf (TargetControl) Is TextBox Then
                Value = CType(TargetControl, TextBox).Text
                Source = "SystemSetup" & "." & CType(TargetControl, TextBox).Name & "."
                Min = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MIN)
                Max = AVPLib.ContainerData.GetRobotConfig(Source + STRING_MAX)
            Else
                Exit Function
            End If

            UserResponse = f.GetUserInput(Value, -1, -1, Min, Max, "Please input the number", 0,
                                needToCheckMaxMin, AllowDecimal)
            If UserResponse = MsgBoxResult.Ok Then
                If TypeOf (TargetControl) Is TextBox Then
                    CType(TargetControl, TextBox).Text = IIf(IsScientificFormat, ConvertDoubleToScientificFormat(Value), Value)
                End If
            End If

            If f.IsMaxMinModified Then
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MIN, f.NewMin)
                AVPLib.ContainerData.SetRobotConfig(Source + STRING_MAX, f.NewMax)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return UserResponse
    End Function

    Public Shared Function ConvertDoubleToScientificFormat(ByVal Value As Double) As String
        Return Format(Double.Parse(Value), AVPLib.ConstEnum.SCIENTIFIC_FORMAT_DECIMAL)
    End Function

    Public Shared Function GetCurrentTargetSwitch(ByVal ChamberName As String) As Integer
        Try
            Dim objPMPanel As ChamberPanel = ContainerForm.ChamberPanel(ChamberName)
            If objPMPanel IsNot Nothing Then
                If objPMPanel.ChamberType = ModuleType.PVD5T Then
                    Dim objPVD5T As PVD5TPanel = CType(objPMPanel, PVD5TPanel)
                    With objPVD5T
                        If .TabTargetPowerSupply.RFTargetPowerSupply.btnTarget1Switch.Status = SL_CustomButton.DisplayStatus.On Then
                            Return 1
                        ElseIf .TabTargetPowerSupply.RFTargetPowerSupply.btnTarget2Switch.Status = SL_CustomButton.DisplayStatus.On Then
                            Return 2
                        ElseIf .TabTargetPowerSupply.RFTargetPowerSupply.btnTarget3Switch.Status = SL_CustomButton.DisplayStatus.On Then
                            Return 3
                        ElseIf .TabTargetPowerSupply.RFTargetPowerSupply.btnTarget4Switch.Status = SL_CustomButton.DisplayStatus.On Then
                            Return 4
                        ElseIf .TabTargetPowerSupply.RFTargetPowerSupply.btnTarget5Switch.Status = SL_CustomButton.DisplayStatus.On Then
                            Return 5
                        End If
                    End With
                Else
                    Dim objCoronaPanel As CoronaPanel = CType(objPMPanel, CoronaPanel)
                    With objCoronaPanel
                        If .RFTargetPowerSupply.btnTarget1Switch.Status = SL_CustomButton.DisplayStatus.On Then
                            Return 1
                        ElseIf .RFTargetPowerSupply.btnTarget2Switch.Status = SL_CustomButton.DisplayStatus.On Then
                            Return 2
                        ElseIf .RFTargetPowerSupply.btnTarget3Switch.Status = SL_CustomButton.DisplayStatus.On Then
                            Return 3
                        ElseIf .RFTargetPowerSupply.btnTarget4Switch.Status = SL_CustomButton.DisplayStatus.On Then
                            Return 4
                        End If
                    End With
                End If
            End If
            Return 1
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function

    ''' <author>
    '''     <name> Hoai Ly </name>
    '''     <date> 2015-06-03 </date>
    ''' </author>
    ''' <summary>
    ''' Get name for log from control
    ''' </summary>
    Public Shared Function GetLogName(ByVal sender As Object) As String
        Dim logName As String = String.Empty
        Try
            If TypeOf sender Is SL_Textbox Then
                Dim slTbx As SL_Textbox = CType(sender, SL_Textbox)
                logName = slTbx.LogSource

                If String.IsNullOrEmpty(logName) Then
                    If Not String.IsNullOrEmpty(slTbx.AccessibleName) Then
                        logName = slTbx.AccessibleName
                    Else
                        If Not String.IsNullOrEmpty(slTbx.AccessibleDescription) Then
                            logName = slTbx.AccessibleDescription
                        Else
                            If slTbx.Name.StartsWith("txt") Then
                                logName = slTbx.Name.Substring(3)
                            Else
                                logName = slTbx.Name
                            End If
                        End If
                    End If
                End If

            ElseIf TypeOf sender Is TextBox Then
                Dim tbx As TextBox = CType(sender, TextBox)
                logName = tbx.AccessibleDescription

                If String.IsNullOrEmpty(logName) Then
                    If tbx.Name.StartsWith("txt") OrElse tbx.Name.StartsWith("tbx") Then
                        logName = tbx.Name.Substring(3)
                    Else
                        logName = tbx.Name
                    End If
                End If

            ElseIf TypeOf sender Is CheckBox Then
                Dim cbx As CheckBox = CType(sender, CheckBox)
                logName = cbx.AccessibleDescription

                If String.IsNullOrEmpty(logName) Then
                    If (cbx.Name.StartsWith("cbx")) OrElse (cbx.Name.StartsWith("chk")) Then
                        logName = cbx.Name.Substring(3)
                    ElseIf cbx.Name.StartsWith("cb") Then
                        logName = cbx.Name.Substring(2)
                    Else
                        logName = cbx.Name
                    End If
                End If

            ElseIf TypeOf sender Is SL_CustomButton Then
                Dim btnSender As SL_CustomButton = CType(sender, SL_CustomButton)

                If String.IsNullOrEmpty(btnSender.LogSource) Then
                    If String.IsNullOrEmpty(btnSender.Text) Then
                        logName = btnSender.AccessibleName

                    ElseIf btnSender.Text.Equals(STR_ON, StringComparison.CurrentCultureIgnoreCase) _
                           OrElse btnSender.Text.Equals(STR_OFF, StringComparison.CurrentCultureIgnoreCase) _
                           OrElse btnSender.Text.Equals(STR_ON & "/" & STR_OFF, StringComparison.CurrentCultureIgnoreCase) _
                           OrElse btnSender.Text.Equals(STR_OFF & "/" & STR_ON, StringComparison.CurrentCultureIgnoreCase) Then
                        logName = btnSender.AccessibleName
                        If Not String.IsNullOrEmpty(logName) AndAlso Not logName.Contains(btnSender.Text) Then
                            logName = logName & " " & btnSender.Text
                        End If

                    Else
                        If String.IsNullOrEmpty(btnSender.EquipmentName) Then
                            logName = btnSender.Text
                        Else
                            logName = btnSender.EquipmentName & " " & btnSender.Text
                        End If

                    End If

                    If String.IsNullOrEmpty(logName) Then
                        logName = btnSender.Name.Replace("btn", "")
                    End If
                Else
                    logName = btnSender.LogSource

                    If String.IsNullOrEmpty(btnSender.Text) Then
                        logName += " " & btnSender.Status.ToString()
                    ElseIf (btnSender.Text = STR_ON OrElse btnSender.Text = STR_OFF) AndAlso (Not logName.Contains(STR_OFF) AndAlso Not logName.Contains(STR_ON)) Then
                        logName += " " & btnSender.Text

                    ElseIf (btnSender.OnText = btnSender.OffText) AndAlso Not logName.Contains(STR_OFF) AndAlso Not logName.Contains(STR_ON) _
                        AndAlso Not logName.Contains(btnSender.Status.ToString()) Then
                        logName += " " & btnSender.Status.ToString()

                    End If
                End If

            ElseIf TypeOf sender Is ButtonIGCGControl Then
                Dim btn As ButtonIGCGControl = CType(sender, ButtonIGCGControl)

                If (btn.Text = STR_ON) OrElse (btn.Text = STR_OFF) Then
                    If Not String.IsNullOrEmpty(btn.AccessibleName) Then
                        logName = String.Format("{0} {1}", btn.AccessibleName, btn.Text)
                    ElseIf Not String.IsNullOrEmpty(btn.AccessibleDescription) Then
                        logName = String.Format("{0} {1}", btn.AccessibleDescription, btn.Text)
                    Else
                        logName = btn.Text
                    End If
                Else
                    If Not (btn.Text.Contains(STR_ON) OrElse btn.Text.Contains(STR_OFF)) Then
                        logName = btn.Text
                    Else
                        If Not String.IsNullOrEmpty(btn.AccessibleDescription) Then
                            logName = String.Format("{0} {1}", btn.AccessibleDescription, btn.Status.ToString())
                        Else
                            logName = String.Format("{0} {1}", btn.Text, btn.Status.ToString())
                        End If
                    End If
                End If

            ElseIf TypeOf sender Is Button Then
                Dim btn As Button = CType(sender, Button)

                If (btn.Text = STR_ON) OrElse (btn.Text = STR_OFF) Then
                    If Not String.IsNullOrEmpty(btn.AccessibleName) Then
                        logName = String.Format("{0} {1}", btn.AccessibleName, btn.Text)
                    ElseIf Not String.IsNullOrEmpty(btn.AccessibleDescription) Then
                        logName = String.Format("{0} {1}", btn.AccessibleDescription, btn.Text)
                    Else
                        logName = btn.Text
                    End If
                Else
                    logName = btn.Text
                End If

            ElseIf TypeOf sender Is ComboBox Then
                Dim cmb As ComboBox = CType(sender, ComboBox)

                If Not String.IsNullOrEmpty(cmb.AccessibleName) Then
                    logName = cmb.AccessibleName
                ElseIf Not String.IsNullOrEmpty(cmb.AccessibleDescription) Then
                    logName = cmb.AccessibleDescription
                ElseIf cmb.Name.StartsWith("cmb") OrElse cmb.Name.StartsWith("cbx") Then
                    logName = cmb.Name.Substring(3)
                ElseIf cmb.Name.StartsWith("cb") Then
                    logName = cmb.Name.Substring(2)
                Else
                    logName = cmb.Name
                End If

            ElseIf TypeOf sender Is ValveControl Then
                Dim valveCtrl As ValveControl = CType(sender, ValveControl)

                If Not String.IsNullOrEmpty(valveCtrl.AccessibleName) Then
                    logName = valveCtrl.AccessibleName
                ElseIf Not String.IsNullOrEmpty(valveCtrl.AccessibleDescription) Then
                    logName = valveCtrl.AccessibleDescription
                Else
                    logName = valveCtrl.Name
                End If

            ElseIf TypeOf sender Is Control Then
                Dim ctrl As Control = CType(sender, Control)

                If Not String.IsNullOrEmpty(ctrl.AccessibleName) Then
                    logName = ctrl.AccessibleName
                ElseIf Not String.IsNullOrEmpty(ctrl.AccessibleDescription) Then
                    logName = ctrl.AccessibleDescription
                Else
                    logName = ctrl.Name
                End If

            Else
                logName = sender.ToString()

            End If
            logName = logName.Trim()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return logName
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-02 </date>
    ''' </author>
    ''' <summary>
    ''' Paint Border for panel
    ''' </summary>
    Public Shared Sub PaintBorder(ByVal sender As Control, ByVal e As System.Windows.Forms.PaintEventArgs, _
                            Optional ByVal top As Integer = 0)
        Try
            Dim x As Integer = 0
            Dim y As Integer = top
            Dim width As Integer = e.ClipRectangle.Width - 1
            Dim height As Integer = e.ClipRectangle.Height - y - 1
            Dim backColor As Color = Color.FromArgb(100, 145, 190)

            If sender IsNot Nothing Then
                width = sender.Width - 1
                height = sender.Height - y - 1
                If sender.BackColor <> Color.Transparent Then
                    backColor = sender.BackColor
                End If
            End If

            If width < 7 OrElse height < 7 Then
                Return
            End If

            If backColor = Color.White Then
                Dim pen1 As Pen = New Pen(Color.FromArgb(165, 165, 165))
                e.Graphics.DrawRectangle(pen1, x, y, width, height)

                Dim pen2 As Pen = New Pen(Color.FromArgb(185, 185, 185))
                e.Graphics.DrawRectangle(pen2, x + 1, y + 1, width - 2, height - 2)

                Dim pen3 As Pen = New Pen(Color.FromArgb(214, 214, 214))
                e.Graphics.DrawRectangle(pen3, x + 2, y + 2, width - 4, height - 4)

                Dim pen4 As Pen = New Pen(Color.FromArgb(238, 238, 238))
                e.Graphics.DrawRectangle(pen4, x + 3, y + 3, width - 6, height - 6)

                pen1.Dispose()
                pen2.Dispose()
                pen3.Dispose()
                pen4.Dispose()
            Else
                Dim pen1 As Pen = New Pen(Color.FromArgb(108, 126, 143))
                e.Graphics.DrawRectangle(pen1, x, y, width, height)

                Dim pen2 As Pen = New Pen(Color.FromArgb(113, 132, 150))
                e.Graphics.DrawRectangle(pen2, x + 1, y + 1, width - 2, height - 2)

                Dim pen3 As Pen = New Pen(Color.FromArgb(119, 138, 157))
                e.Graphics.DrawRectangle(pen3, x + 2, y + 2, width - 4, height - 4)

                Dim pen4 As Pen = New Pen(Color.FromArgb(83, 112, 142))
                e.Graphics.DrawRectangle(pen4, x + 3, y + 3, width - 6, height - 6)

                pen1.Dispose()
                pen2.Dispose()
                pen3.Dispose()
                pen4.Dispose()
            End If

            Dim brush As SolidBrush = New SolidBrush(backColor)
            e.Graphics.FillRectangle(brush, x + 4, y + 4, width - 7, height - 7)
            brush.Dispose()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-09 </date>
    ''' </author>
    ''' <summary>
    ''' Scale image
    ''' </summary>
    Public Overloads Shared Function ScaleImage(ByVal OldImage As Image, ByVal scaleNumber As Single) As System.Drawing.Image
        Try
            Dim NewHeight As Integer = CInt(OldImage.Height * scaleNumber)
            Dim NewWidth As Integer = CInt(OldImage.Width * scaleNumber)
            Return New Bitmap(OldImage, NewWidth, NewHeight)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            Return Nothing
        End Try
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-11 </date>
    ''' </author>
    ''' <summary>
    ''' Scale image
    ''' </summary>
    Public Overloads Shared Function ScaleImage(ByVal OldImage As Image, ByVal newWidth As Integer, Optional ByVal newHeight As Integer = -1) As System.Drawing.Image
        Try
            Dim width As Integer = newWidth
            Dim height As Integer = OldImage.Height
            If newHeight <> -1 Then
                height = newHeight
            End If

            Dim imgScale As New Bitmap(width, height)
            Using gr As Graphics = Graphics.FromImage(imgScale)
                gr.DrawImage(OldImage, 0, 0, width, height)
            End Using

            Return imgScale
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            Return Nothing
        End Try
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-09 </date>
    ''' </author>
    ''' <summary>
    ''' Rotate image
    ''' </summary>
    Public Shared Function RotateImageCenter(ByVal image As Image, ByVal angle As Single) As Bitmap
        Try
            If image Is Nothing Then
                Throw New ArgumentNullException("image")
            End If

            Dim NewImageWidth As Integer = 0
            Dim NewImageHeight As Integer = 0
            Dim temp As Integer = CInt(Math.Sqrt((image.Width) * (image.Width) + (image.Height) * (+image.Height)))
            NewImageWidth = temp
            NewImageHeight = temp

            Dim upperLeftDrawPoint As Point = New Point(0, 0)
            Dim imageCenterOffset As Point = New Point(NewImageWidth / 2, NewImageHeight / 2)

            'create a new empty bitmap to hold rotated image
            Dim rotatedBmp As New Bitmap(NewImageWidth, NewImageHeight)
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution)

            'make a graphics object from the empty bitmap
            Using g As Graphics = Graphics.FromImage(rotatedBmp)
                g.TranslateTransform(upperLeftDrawPoint.X + imageCenterOffset.X, upperLeftDrawPoint.Y + imageCenterOffset.Y)
                g.RotateTransform(angle)
                g.TranslateTransform((upperLeftDrawPoint.X + imageCenterOffset.X) * -1, (upperLeftDrawPoint.Y + imageCenterOffset.Y) * -1)
                g.DrawImage(image, New PointF((NewImageWidth - image.Width) / 2, (NewImageHeight - image.Height) / 2))
            End Using
            Return rotatedBmp
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Get Chamber name which container control (use for log)
    ''' </summary>
    Public Shared Function GetPMContainer(ByVal ctrl As Control) As String
        Try
            Dim parent As Control = ctrl
            Dim pm As String = String.Empty
            While parent IsNot Nothing AndAlso Not String.IsNullOrEmpty(parent.Name)
                pm = AVPLib.Utils.chamberID2ChamberName(parent.Name)
                If pm.StartsWith("PM") OrElse pm.StartsWith("Cassette") Then
                    Exit While
                End If
                parent = parent.Parent
            End While

            If pm.StartsWith("PM") Then
                Return pm
            End If

            If pm.StartsWith("Cassette") Then
                Return "TM Screen"
            End If

            Dim parentSto As StatusObject = Nothing

            If TypeOf ctrl Is SL_Textbox Then
                parentSto = CType(ctrl, SL_Textbox).ParentStatusObj

            ElseIf TypeOf ctrl Is SL_CustomButton Then
                parentSto = CType(ctrl, SL_CustomButton).ParentStatusObj

            End If

            While parentSto IsNot Nothing AndAlso Not String.IsNullOrEmpty(parentSto.Name)
                pm = AVPLib.Utils.chamberID2ChamberName(parentSto.Name)
                If pm.StartsWith("PM") OrElse pm.StartsWith("Cassette") Then
                    Exit While
                End If
                parentSto = parentSto.Parent
            End While

            If pm.StartsWith("PM") Then
                Return pm
            End If

            If pm.StartsWith("Cassette") Then
                Return "TM Screen"
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-19 </date>
    ''' </author>
    ''' <summary>
    ''' Log user action in GUI
    ''' </summary>
    Public Shared Sub LogUserEvent(ByVal sender As Object, Optional ByVal logSource As String = "", Optional ByVal subLogSource As String = "", Optional ByVal logName As String = "", Optional ByVal valueBefore As Object = Nothing, Optional ByVal valueAfter As Object = Nothing)
        Try
            If String.IsNullOrEmpty(logSource) AndAlso TypeOf sender Is Control Then
                logSource = GetPMContainer(CType(sender, Control))
            End If

            If Not String.IsNullOrEmpty(logSource) Then
                logSource = String.Format("[{0}] ", logSource)
            End If

            If Not String.IsNullOrEmpty(subLogSource) Then
                subLogSource = subLogSource + ": "
            End If

            Dim strChangeValue As String = "{0}{1}Changed {2} from {3} to {4}"
            Dim strSetValue As String = "{0}{1}Set {2} value to {3}"
            Dim strButtonclicked As String = "{0}{1}{2} button Clicked"
            Dim strClicked As String = "{0}{1}{2} {3}"
            Dim strMessageLog As String = "{0}{1}{2}"
            Dim strCheckdBox As String = "{0}{1}Checked on {2}"
            Dim strUncheckedBox As String = "{0}{1}Unchecked on {2}"
            Dim strSelectComboChanged As String = "{0}{1}Select {2} changed from {3} to {4}"
            Dim strSelectCombo As String = "{0}{1}Select item {2} of {3} list"
            Dim strOpenValve As String = "{0}{1}Open {2} valve"
            Dim strCloseValve As String = "{0}{1}Close {2} valve"

            Dim logMessage As String = String.Empty
            If TypeOf sender Is SL_Textbox OrElse _
               TypeOf sender Is TextBox Then

                Dim preText As String = ""
                Dim changedText As String = ""

                ' Get the text changed
                If TypeOf sender Is SL_Textbox Then
                    Dim ctrl As SL_Textbox = CType(sender, SL_Textbox)
                    changedText = ctrl.Text
                Else
                    Dim ctrl As TextBox = CType(sender, TextBox)
                    changedText = ctrl.Text
                End If

                If valueBefore IsNot Nothing And TypeOf valueBefore Is String Then
                    preText = CType(valueBefore, String)
                End If
                If valueAfter IsNot Nothing AndAlso TypeOf valueAfter Is String Then
                    changedText = CType(valueAfter, String)
                End If

                ' Only log when different value
                If Not changedText.Equals(preText) Then
                    If String.IsNullOrEmpty(logName) Then
                        logName = GetLogName(sender)
                    End If

                    If String.IsNullOrEmpty(preText) Then
                        logMessage = String.Format(strSetValue, logSource, subLogSource, logName, changedText)
                    Else
                        logMessage = String.Format(strChangeValue, logSource, subLogSource, logName, preText, changedText)
                    End If
                End If

            ElseIf TypeOf sender Is SL_CustomButton OrElse _
                   TypeOf sender Is Button OrElse _
                   TypeOf sender Is ButtonIGCGControl Then

                If String.IsNullOrEmpty(logName) Then
                    logName = GetLogName(sender)
                End If

                logMessage = String.Format(strButtonclicked, logSource, subLogSource, logName)

            ElseIf TypeOf sender Is SL_ValveControl Then
                Dim slValve As SL_ValveControl = CType(sender, SL_ValveControl)
                Dim action As String = ""
                If slValve.Status = DisplayStatus.Off Then
                    action = "Open"
                ElseIf slValve.Status = DisplayStatus.On Then
                    action = "Close"
                Else
                    action = "Open/Close"
                End If

                If String.IsNullOrEmpty(logName) Then
                    logName = GetLogName(sender)
                End If

                logMessage = String.Format(strClicked, logSource, subLogSource, action, logName)

            ElseIf TypeOf sender Is ValveControl Then
                Dim valve As ValveControl = CType(sender, ValveControl)

                Dim msg As String = strOpenValve
                If valve.Status = BinaryStatusControl.DisplayStatus.On Then
                    msg = strCloseValve
                End If

                If String.IsNullOrEmpty(logName) Then
                    logName = GetLogName(valve)
                End If

                If logName.ToLower().Contains("valve") Then
                    logName = logName.Replace("valve", "").Replace("Valve", "").Trim()
                End If

                logMessage = String.Format(msg, logSource, subLogSource, logName)

            ElseIf TypeOf sender Is CheckBox Then
                Dim cbx As CheckBox = CType(sender, CheckBox)

                Dim valueBeforeChange As Boolean = Not cbx.Checked
                Dim valueAfterChange As Boolean = cbx.Checked

                If valueBefore IsNot Nothing Then
                    valueBeforeChange = CType(valueBefore, Boolean)
                End If
                If valueAfter IsNot Nothing Then
                    valueAfterChange = CType(valueAfter, Boolean)
                End If

                ' Only log when value is different
                If valueBeforeChange <> valueAfterChange Then
                    If String.IsNullOrEmpty(logName) Then
                        logName = Utils.GetLogName(cbx)
                    End If

                    If cbx.Checked Then
                        logMessage = String.Format(strCheckdBox, logSource, subLogSource, logName)
                    Else
                        logMessage = String.Format(strUncheckedBox, logSource, subLogSource, logName)
                    End If
                End If

            ElseIf TypeOf sender Is ComboBox Then
                Dim cbx As ComboBox = CType(sender, ComboBox)

                Dim valueBeforeChange As String = ""
                Dim valueAfterChange As String = cbx.Text

                If valueBefore IsNot Nothing Then
                    valueBeforeChange = CType(valueBefore, String)
                End If
                If valueAfter IsNot Nothing Then
                    valueAfterChange = CType(valueAfter, String)
                End If

                ' Only log when value is different
                If valueBeforeChange <> valueAfterChange Then
                    If String.IsNullOrEmpty(logName) Then
                        logName = Utils.GetLogName(cbx)
                    End If

                    If String.IsNullOrEmpty(valueBefore) Then
                        logMessage = String.Format(strSelectCombo, logSource, subLogSource, valueAfterChange, logName)
                    Else
                        logMessage = String.Format(strSelectComboChanged, logSource, subLogSource, logName, valueBeforeChange, valueAfterChange)
                    End If
                End If

            ElseIf TypeOf sender Is String Then
                Dim message As String = CType(sender, String)
                If message.Contains("{0}") Then
                    If message.Contains("{1}") AndAlso message.Contains("{2}") Then
                        If Not String.IsNullOrEmpty(logName) AndAlso _
                           Not String.IsNullOrEmpty(valueBefore) AndAlso _
                           Not String.IsNullOrEmpty(valueAfter) Then
                            message = String.Format(message, logName, valueBefore.ToString(), valueAfter.ToString())
                        End If
                    End If
                End If

                logMessage = String.Format(strMessageLog, logSource, subLogSource, message)

            ElseIf sender Is Nothing AndAlso _
                    valueBefore IsNot Nothing AndAlso TypeOf valueBefore Is String AndAlso _
                    valueAfter IsNot Nothing AndAlso TypeOf valueAfter Is String AndAlso _
                    Not String.IsNullOrEmpty(logName) Then
                Dim valueBeforeChange As String = CType(valueBefore, String)
                Dim valueAfterChange As String = CType(valueAfter, String)

                If Not valueAfterChange.Equals(valueBeforeChange) Then
                    logMessage = String.Format(strChangeValue, logSource, subLogSource, logName, valueBefore, valueAfter)
                End If

            End If

            ' Log when message is not empty
            If Not String.IsNullOrEmpty(logMessage) Then
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                        AVPLib.ContainerData.LogSource.AVPMainScreen, logMessage)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-22 </date>
    ''' </author>
    ''' <summary>
    ''' Synchronized update TM Pressure between Cassette and Process screen
    ''' </summary>
    Public Shared Sub UpdateTMPressure()
        Try
            If System_Init_Indicator.IsMainFormInitialize Then
                Dim objTM As AVPLib.DataManagerment.CassettesModule = _
                    DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.CassettesModule.ToString())
                With objTM
                    If (.IG_Communication = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off) AndAlso _
                                   (.CG_Communication = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off) Then
                        ContainerForm.CassettesPanel.TMCtl.lblPressure.Text = "Error"
                        ContainerForm.ProcessPanel.TMCtl.lblPressure.Text = "Error"
                    ElseIf (.CG_Communication = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off) AndAlso _
                        (.IGStatus = DataManagerment.Equipment.WorkingStatuses.Off) Then
                        ContainerForm.CassettesPanel.TMCtl.lblPressure.Text = "Error"
                        ContainerForm.ProcessPanel.TMCtl.lblPressure.Text = "Error"
                    Else
                        Dim strNewPressure As String = Utils.ConvertDoubleToScientificFormat(.Pressure)
                        If strNewPressure <> ContainerForm.CassettesPanel.TMCtl.lblPressure.Text Then
                            ContainerForm.CassettesPanel.TMCtl.lblPressure.Text = strNewPressure
                            ContainerForm.ProcessPanel.TMCtl.lblPressure.Text = strNewPressure
                        End If
                    End If
                    If (.IG_Communication = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off) Then
                        ContainerForm.CassettesPanel.TMCGGaugesFrm.btnTurnIGOn.Status = SL_CustomButton.DisplayStatus.Off
                    End If
                End With
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-11-12 </date>
    ''' </author>
    ''' <summary>
    ''' Merge two images
    ''' </summary>
    Public Shared Sub SetConfigRobotStation(ByRef robotArm As RobotArmControl)
        Try
            If robotArm IsNot Nothing Then
                robotArm.SetStationType(RobotArmStations.LLA, AVPChamberTypes.LoadLock)
            End If

            robotArm.SetStationType(RobotArmStations.Aligner, AVPChamberTypes.Aligner)
            robotArm.AlignerAtStation = RobotArmStations.LLA

            If AVPLib.RobotConfigurationValues.CHAMBERX_VISIBLE IsNot Nothing Then
                For index As Integer = 0 To AVPLib.RobotConfigurationValues.CHAMBERX_VISIBLE.Count - 1
                    If AVPLib.RobotConfigurationValues.CHAMBERX_VISIBLE(index) Then
                        robotArm.SetStationType(index + 1, AVPChamberTypes.PVD4)
                    End If
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Dy Do </name>
    '''     <date> 2017-02-22 </date>
    ''' </author>
    ''' <summary>
    ''' Set location for PMControl in process and cassette screen.
    ''' </summary>
    Public Shared Sub SetLocationPM(ByVal pmCtrl As PMControl, Optional ByVal dx As Integer = 0, Optional ByVal dy As Integer = 0)
        Try
            If pmCtrl Is Nothing Then
                Return
            End If
            Select Case pmCtrl.PM_Type
                Case TypeOfAVPChamber.PVD4
                    SetLocationPMPVD4(pmCtrl, dx, dy)
                Case TypeOfAVPChamber.IBE
                    SetLocationPMIBE(pmCtrl, dx, dy)
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Dy Do </name>
    '''     <date> 2017-02-22 </date>
    ''' </author>
    ''' <summary>
    ''' Set location for PVD4 PM in process and cassette screen.
    ''' </summary>
    Private Shared Sub SetLocationPMPVD4(ByVal pmCtrl As PMControl, Optional ByVal dx As Integer = 0, Optional ByVal dy As Integer = 0)
        Dim location As Point
        Select Case pmCtrl.DockPosition
            Case PMControl.ChamberDockPositions.PM1
                location = New Point(352, 260)
            Case PMControl.ChamberDockPositions.PM2
                location = New Point(546, 66)
            Case PMControl.ChamberDockPositions.PM3
                location = New Point(740, 260)
        End Select

        location.X += dx
        location.Y += dy
        pmCtrl.Location = location
    End Sub

    ''' <author>
    '''    	<name> Tinh Le </name>
    '''    	<date> 2021-10-05 </date>
    ''' </author>
    ''' <summary>
    ''' Set location for Chamber IBE
    ''' </summary>
    Private Shared Sub SetLocationPMIBE(ByVal pmCtrl As PMControl, Optional ByVal dx As Integer = 0, Optional ByVal dy As Integer = 0)
        Try
            Dim location As Point
            Select Case pmCtrl.DockPosition
                Case PMControl.ChamberDockPositions.PM1
                    location = New Point(331, 239)
                Case PMControl.ChamberDockPositions.PM2
                    location = New Point(527, 45)
                Case PMControl.ChamberDockPositions.PM3
                    location = New Point(720, 241)
            End Select

            location.X += dx
            location.Y += dy
            pmCtrl.Location = location
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''     <name> Dung Pham </name>
    '''     <date> 2020-09-17 </date>
    ''' </author>
    ''' <summary>
    ''' Check path of folder or file has permmision accessiable.
    ''' </summary>
    Public Shared Function HasPermissionAccess(ByVal strPath As String, ByVal typePermission As System.Security.AccessControl.FileSystemRights) As Boolean
        Dim bResult As Boolean = True

        Try
            Dim collection As System.Security.AccessControl.AuthorizationRuleCollection = _
                System.IO.Directory.GetAccessControl(strPath).GetAccessRules(True, True, _
                                                    GetType(System.Security.Principal.NTAccount))

            For Each rule As System.Security.AccessControl.FileSystemAccessRule In collection

                If rule.AccessControlType = System.Security.AccessControl.AccessControlType.Deny AndAlso _
                    rule.FileSystemRights = typePermission Then
                    bResult = False
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return bResult
    End Function

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-11-17 </date>
    ''' </author>
    ''' <summary>
    ''' save config show rework file
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Sub SaveShowReworkFiles(ByVal isEnable As Boolean)
        Try
            ' path of device net config
            Dim xmldoc As System.Xml.XmlDocument = AVPLib.ContainerDAO.SystemConfigDoc
            Dim root As System.Xml.XmlNode = xmldoc.SelectSingleNode(ConstEnum.XPATH_SHOW_REWORK_FILES)
            If (root IsNot Nothing) Then
                root.InnerText = isEnable.ToString
                BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_SystemConfig, xmldoc)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

End Class
