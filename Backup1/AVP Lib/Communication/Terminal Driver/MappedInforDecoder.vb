Imports System.Text.RegularExpressions

Namespace Communication.TerminalDriver
    Public Class MappedInforDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name>Ngo Cao Dinh</Name>
        '''   	<Date>2008-11-28</Date>
        '''		<Description> Fix bug</Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Decode MappedInforDecoder
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            AVPLib.Log.terminalServerLogger.Info("MessageValue=" + MessageValue)

            Dim ListValues As New ArrayList()
            Dim strRegularExp = "^00,X,MI,([A-F0-9]),([A-F0-9]),([A-F0-9]),([A-F0-9]),([A-F0-9]),([A-F0-9]),([A-F0-9]),([A-F0-9]),([A-F0-9]),([A-F0-9])$"
            Try
                Dim FoundMatch As Boolean = Regex.IsMatch(MessageValue, strRegularExp)
                If (FoundMatch) Then
                    Dim mtcMatch As Match = Regex.Match(MessageValue, strRegularExp)
                    Dim strBinary As String = ""
                    Dim strValue As String
                    Dim intValue As Integer
                    For i As Integer = 1 To mtcMatch.Groups.Count - 1
                        strValue = mtcMatch.Groups(i).Value
                        intValue = Convert.ToInt32(strValue, 16)
                        strBinary = Me.PaddingZero(Convert.ToString(intValue, 2)) + strBinary
                    Next
                    Dim intSlotNum As Integer = 12
                    If (EquipmentName = ConstEnum.Equipments.LLAElevator.ToString()) Then
                        intSlotNum = RobotConfigurationValues.SLOT_NUM_LLA
                    End If
                    Dim arrSlotStatus(intSlotNum - 1) As Integer
                    Dim intLastIndex = strBinary.Length - 1
                    For i As Integer = 0 To intSlotNum - 1
                        arrSlotStatus(i) = Convert.ToInt32(strBinary.Substring(intLastIndex - i, 1))
                    Next
                    ListValues.Add(arrSlotStatus)
                Else
                    ListValues.Add(Nothing)
                    ' Just log the incorrect response message not alarm.
                    AVPLib.Log.terminalServerRobotLogger.Error("Incorrect response received " & MessageValue)
                    'ListValues.Add(Utils.GetMessageError("ErrMappedInfor"))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.terminalServerLogger.Info("Leave Decode")
            Return ListValues
        End Function
#End Region

#Region "Private method"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-28</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Padding zero char to head of string
        ''' </summary>
        ''' <remarks></remarks>
        Private Function PaddingZero(ByVal strBinary As String) As String
            Dim result As String = strBinary
            Try
                For i As Integer = strBinary.Length To 3
                    result = "0" + result
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            Return result
        End Function
#End Region
    End Class

End Namespace
