Imports System.Text.RegularExpressions
Namespace Communication.TerminalDriver
    Public Class CryoRegenStatusDecoder
        Inherits TSDecoder
#Region "Public method"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-15</date>
        ''' </author>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        ''' <summary>
        ''' Decode Cryo regen status
        ''' </summary>
        ''' <remarks></remarks>
        Public Overrides Function Decode(ByVal MessageValue As String) As ArrayList
            AVPLib.Log.terminalServerLogger.Info("Enter Decode")
            AVPLib.Log.terminalServerLogger.Info("MessageValue=" + MessageValue)

            Dim ListValues As New ArrayList()
            Try
                MessageValue = MessageValue.Substring(1, MessageValue.Length - 2)
                Dim strRegularExp = "^A([A\\BCE^\]DFGQRHSIJKTabjnLMNcdoPUVWXYZO\[fehiklm_rstuv`])$"

                Dim FoundMatch As Boolean = Regex.IsMatch(MessageValue, strRegularExp)
                If (FoundMatch) Then
                    Dim strValue As String = Regex.Match(MessageValue, strRegularExp).Groups(1).Value
                    Select Case strValue
                        Case "P" ' Regeneration complete
                            ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.Off)
                            ListValues.Add(strValue)
                        Case "V" ' Regeneration aborted
                            ' TODO: 0001554: Logic when user press the button Gegen is not correct 
                            ' send the Abort value to update GUI
                            ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.Abort)
                            ListValues.Add(strValue)
                        Case "D", "F", "G", "Q", "R"
                            ListValues.Add(Nothing)
                            ListValues.Add(strValue)
                            ListValues.Add(Utils.GetMessageError("ErrPurgeGas"))
                        Case "X", "Y"
                            ListValues.Add(Nothing)
                            ListValues.Add(strValue)
                            ListValues.Add(Utils.GetMessageError("ErrPower"))
                        Case Else
                            ' Don't care we just assume that the regen is running 
                            ListValues.Add(AVPLib.DataManagerment.Equipment.WorkingStatuses.On)
                            ListValues.Add(strValue)
                    End Select
                Else
                    ListValues.Add(Nothing)
                    ' Just log the incorrect response message not alarm.
                    AVPLib.Log.terminalServerCryoLogger.Error("Incorrect response received " & MessageValue)
                    'ListValues.Add(Utils.GetMessageError("ErrRequestRegen"))
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

            AVPLib.Log.terminalServerLogger.Info("Leave Decode")
            Return ListValues
        End Function
#End Region
    End Class
End Namespace