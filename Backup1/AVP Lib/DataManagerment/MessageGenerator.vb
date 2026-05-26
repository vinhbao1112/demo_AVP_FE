Namespace DataManagerment
    Public Class MessageGenerator
#Region "Public method"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Create a message
        ''' </summary>
        ''' <param name="EquipmentName"></param>
        ''' <param name="PropertyName"></param>
        ''' <param name="Value"></param>
        ''' <remarks></remarks>
        Public Shared Function CreateMessage(ByVal EquipmentName As String, ByVal PropertyName As String, ByVal Value As Object) As ArrayList
            AVPLib.Log.coreLogger.Info("Enter CreateMessage")
            AVPLib.Log.coreLogger.Debug("EquipmentName=" + EquipmentName)
            AVPLib.Log.coreLogger.Debug("PropertyName=" + PropertyName)
            Dim ListCode As ArrayList = New ArrayList()
            Try
                Dim MessageName As String = PropertyName
                If EquipmentName.Length > 0 Then
                    MessageName = EquipmentName + "." + PropertyName
                    If EquipmentName = ConstEnum.Equipments.Chamber1.ToString() Or _
                       EquipmentName = ConstEnum.Equipments.Chamber2.ToString() Or _
                       EquipmentName = ConstEnum.Equipments.Chamber3.ToString() Then
                        Dim chamberModule As AVPLib.SystemModule = Nothing
                        If AVPLib.ContainerData.IsChamberVisible(EquipmentName, chamberModule) AndAlso chamberModule.Type = SystemModule.ModuleType.IBE Then
                            MessageName = chamberModule.Type.ToString() + "." + PropertyName
                        ElseIf AVPLib.ContainerData.IsChamberVisible(EquipmentName, chamberModule) AndAlso chamberModule.Type = SystemModule.ModuleType.PVD Then
                            MessageName = ConstEnum.PVD + "." + PropertyName
                        ElseIf AVPLib.ContainerData.IsChamberVisible(EquipmentName, chamberModule) AndAlso chamberModule.Type = SystemModule.ModuleType.PVD4 Then
                            MessageName = ConstEnum.PVD4 + "." + PropertyName
                        ElseIf AVPLib.ContainerData.IsChamberVisible(EquipmentName, chamberModule) AndAlso chamberModule.Type = SystemModule.ModuleType.PVD5T Then
                            MessageName = ConstEnum.PVD5T + "." + PropertyName
                        End If
                    End If
                End If

                Dim Code As String = ContainerData.GetMessageCode(MessageName)
                If String.IsNullOrEmpty(Code) Then
                    Return ListCode
                End If

                'Using with old IBE/PVD
                If Code.Contains("WaferID") Or Code.Contains("Recipe") Or _
                Code.Contains("StepNumber") Or Code.Contains("StepTime") Or Code.Contains("ProcessPressure") Then
                    If Code.Contains("ChamberIn") Then
                        Code = Code.Replace("ChamberIn", EquipmentName & "In")
                    End If
                    If Code.Contains("ChamberDetail") AndAlso _
                       (EquipmentName = ConstEnum.Equipments.Chamber1.ToString() Or EquipmentName = ConstEnum.Equipments.Chamber3.ToString()) Then
                        Code = Code.Replace("ChamberDetail", EquipmentName & "Detail")
                    End If
                ElseIf PropertyName.Contains("ProcessMonitor_Status_Readback") Then
                    If Code.Contains("ChamberIn") Then
                        Code = Code.Replace("ChamberIn", EquipmentName & "In")
                    End If
                    If Code.Contains("ChamberDetail") AndAlso _
                                           (EquipmentName = ConstEnum.Equipments.Chamber1.ToString() Or EquipmentName = ConstEnum.Equipments.Chamber3.ToString()) Then
                        Code = Code.Replace("ChamberDetail", EquipmentName & "Detail")
                    End If
                End If
                If Code.Contains("IGOfIBEIn") Or Code.Contains("CGOfIBEIn") Or Code.Contains("WaferInsideIBEIn") Then
                    Code = Code.Replace("IBEIn", EquipmentName & "In")
                ElseIf Code.Contains("IGOfPVDIn") Or Code.Contains("CGOfPVDIn") Then
                    Code = Code.Replace("PVDIn", EquipmentName & "In")
                End If

                'Corona
                If Code.Contains("_OfChamber_") Then
                    Code = Code.Replace("_OfChamber_", "_Of" & EquipmentName & "_")
                End If

                Dim arrCode As String() = Code.Split(",")
                Dim TempValue As Object = Value
                If (PropertyName = "SlotStatus") Then
                    Value = "###"
                End If
                For i As Integer = 0 To arrCode.Length - 1
                    Dim fullMsg As String = ContainerData.GetMessageValue(arrCode(i) + " " + Value.ToString())
                    ListCode.Add(fullMsg)
                    AVPLib.Log.coreLogger.Debug("MessageVale=" + fullMsg)
                Next
                If (PropertyName = "SlotStatus") Then
                    Dim RetListCode As ArrayList = New ArrayList()
                    Dim intSlotStatus() As Integer = CType(TempValue, Integer())
                    Dim sValue1 As String = CType(ListCode(0), String) ' For Process Panel.
                    Dim sValue2 As String = CType(ListCode(1), String) ' For Cassette Panel.
                    Dim strSlotState As String = ""
                    For idx As Integer = 0 To intSlotStatus.Length() - 1
                        Select Case intSlotStatus(idx)
                            Case ConstEnum.SlotStatuses.Empty
                                strSlotState = ConstEnum.enumWaferStatus.eWaferNone.ToString()
                            Case ConstEnum.SlotStatuses.Available
                                strSlotState = ConstEnum.enumWaferStatus.eWaferNew.ToString()
                        End Select
                        Dim slotN As Integer = idx + 1
                        Dim argument As String = slotN & " " & strSlotState
                        RetListCode.Add(sValue1.Replace("###", argument))
                        RetListCode.Add(sValue2.Replace("###", argument))
                    Next
                    Return RetListCode
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CreateMessage")
            Return ListCode
        End Function
        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-13</date>
        ''' </author>
        ''' <summary>
        ''' Create a message IBE
        ''' </summary>
        ''' <param name="EquipmentName"></param>
        ''' <param name="PropertyName"></param>
        ''' <param name="Value"></param>
        ''' <remarks></remarks>
        Public Shared Function CreateMessageIBE(ByVal EquipmentName As String, ByVal PropertyName As String, ByVal Value As Object) As ArrayList
            AVPLib.Log.coreLogger.Info("Enter CreateMessageIBE")
            Dim ListCode As ArrayList = New ArrayList()
            Try
                Dim MessageName As String = PropertyName
                If EquipmentName.Length > 0 Then
                    MessageName = EquipmentName + "." + PropertyName
                End If

                Dim Code As String = ContainerData.GetMessageCode(MessageName)
                If String.IsNullOrEmpty(Code) Then
                    Return ListCode
                End If
                Dim arrCode As String() = Code.Split(",")

                For i As Integer = 0 To arrCode.Length - 1
                    Dim MessageVale As String = ContainerData.GetMessageValue(arrCode(i) + " " + Value.ToString())
                    ListCode.Add(MessageVale)
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave CreateMessageIBE")
            Return ListCode
        End Function
#End Region
    End Class
End Namespace

