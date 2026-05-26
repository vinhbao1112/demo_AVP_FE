Imports System.Threading
Imports AVPLib.ConstEnum
Public Class StoreGuiLib
    Public Const WAFER_ID As String = "WaferID"
    Public Const WAFER_STATUS As String = "WaferStatus"
    Public Const OPERATOR_ID As String = "OperatorID"
    Public Const TIP As String = "TIP"
    Public Const PALLET_ID As String = "PalletID"
    Public Const LOT_ID As String = "LotID"
    Public Const PRODUCT_NAME As String = "ProductName"

#Region "Saving Wafer"
    Public Overloads Shared Sub SavingWaferInfo(ByVal WFDB As WaferUpdateDB)
        System.Threading.ThreadPool.QueueUserWorkItem(AddressOf UpdateWaferInfo, WFDB)
    End Sub
#End Region

#Region "Functions"
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-11-09</date>
    ''' </author>
    ''' <summary>
    ''' GetUser
    ''' </summary>
    ''' <param name="StoreGuiDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetWaferInfo(ByVal childNode As Xml.XmlNode) As AVPWaferInfo
        AVPLib.Log.coreLogger.Info("Enter GetWaferInfo")
        Dim bHaveInsideWafer As Boolean = False
        Dim waferInfo As AVPWaferInfo = Nothing

        If (Not String.IsNullOrEmpty(childNode.InnerText)) And Boolean.TryParse(childNode.InnerText, bHaveInsideWafer) Then
            If (bHaveInsideWafer) Then
                Dim strWaferID As String = childNode.Attributes.ItemOf(WAFER_ID).InnerText
                Dim iSlotID As Integer = 0 'fake value
                Dim waferStatus As ConstEnum.enumWaferStatus = ConstEnum.enumWaferStatus.eWaferNew
                Try
                    Dim strWaferStatus As String = childNode.Attributes.ItemOf(WAFER_STATUS).InnerText.ToString()
                    If String.IsNullOrEmpty(strWaferStatus) Then
                        waferStatus = ConstEnum.enumWaferStatus.eWaferNone
                    Else
                        waferStatus = [Enum].Parse(GetType(ConstEnum.enumWaferStatus), strWaferStatus, False)
                    End If
                Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try

                waferInfo = New AVPWaferInfo(strWaferID, iSlotID, waferStatus)
            End If
        Else
            AVPLib.Log.avpLogger.Error("Invalid node " & childNode.Name & " found")
        End If
        AVPLib.Log.coreLogger.Info("Enter GetWaferInfo")
        Return waferInfo
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-06-14</date>
    ''' </author>
    ''' <summary>
    ''' Get Lot Sytem ID Info
    ''' </summary>
    Public Shared Sub GetLotSytemIDInfo(ByVal node As Xml.XmlNode, ByRef StoreGui As DBStoreGui)
        Try
            AVPLib.Log.coreLogger.Info("Enter GetLotSytemIDInfo")
            For Each childNode As Xml.XmlNode In node.ChildNodes
                Select Case childNode.Name
                    Case OPERATOR_ID
                        Boolean.TryParse(childNode.InnerText.ToString(), StoreGui.UseOperationID)
                    Case TIP
                        Boolean.TryParse(childNode.InnerText.ToString(), StoreGui.UseTIP)
                    Case PALLET_ID
                        Boolean.TryParse(childNode.InnerText.ToString(), StoreGui.UsePalletID)
                    Case LOT_ID
                        Boolean.TryParse(childNode.InnerText.ToString(), StoreGui.UseLotID)
                    Case PRODUCT_NAME
                        Boolean.TryParse(childNode.InnerText.ToString(), StoreGui.UseProductName)
                End Select
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetLotSytemIDInfo")
    End Sub


    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-14</date>
    ''' </author>
    ''' <summary>
    ''' GetUser
    ''' </summary>
    ''' <param name="StoreGuiDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetStoreGui(ByVal StoreGuiDoc As System.Xml.XmlDocument) As DBStoreGui
        AVPLib.Log.coreLogger.Info("Enter GetStoreGui")
        Try
            Dim StoreGui As New DBStoreGui
            Dim root As System.Xml.XmlNode = StoreGuiDoc.FirstChild
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            Dim nWaferChamber As Integer = 0
            Dim nTotalWafer As Integer = 0
            Dim nLifeTimeWafer As Integer = 0

            For Each childNode As Xml.XmlNode In nodeList
                If (childNode.Name = ConstEnum.HaveInsideWaferChamber1) Then
                    If AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE Then
                        StoreGui.WaferChamber1 = GetWaferInfo(childNode)
                        StoreGui.HaveInsideWaferChamber1 = False

                        If StoreGui.WaferChamber1 IsNot Nothing Then
                            StoreGui.HaveInsideWaferChamber1 = True
                        End If
                    Else
                        StoreGui.HaveInsideWaferChamber1 = False
                    End If

                ElseIf (childNode.Name = ConstEnum.HaveInsideWaferChamber2) Then
                    If AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE Then
                        StoreGui.WaferChamber2 = GetWaferInfo(childNode)
                        StoreGui.HaveInsideWaferChamber2 = False

                        If StoreGui.WaferChamber2 IsNot Nothing Then
                            StoreGui.HaveInsideWaferChamber2 = True
                        End If
                    Else
                        StoreGui.HaveInsideWaferChamber2 = False
                    End If

                ElseIf (childNode.Name = ConstEnum.HaveInsideWaferChamber3) Then
                    If AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE Then
                        StoreGui.WaferChamber3 = GetWaferInfo(childNode)
                        StoreGui.HaveInsideWaferChamber3 = False

                        If StoreGui.WaferChamber3 IsNot Nothing Then
                            StoreGui.HaveInsideWaferChamber3 = True
                        End If
                    Else
                        StoreGui.HaveInsideWaferChamber3 = False
                    End If
                ElseIf (childNode.Name = ConstEnum.HaveInsideWaferAligner) Then
                    StoreGui.WaferAtAligner = GetWaferInfo(childNode)
                    StoreGui.HaveInsideWaferAligner = False

                    If StoreGui.WaferAtAligner IsNot Nothing Then
                        StoreGui.HaveInsideWaferAligner = True
                    End If
                ElseIf (childNode.Name = ConstEnum.LastUsedAlignerRecipe) Then
                    StoreGui.LastUsedAlignerRecipe = childNode.InnerText

                ElseIf (childNode.Name = ConstEnum.HaveInsideWaferLoader) Then
                    StoreGui.WaferAtLoader = GetWaferInfo(childNode)
                    StoreGui.HaveInsideWaferLoader = False
                    If StoreGui.WaferAtLoader IsNot Nothing Then
                        StoreGui.HaveInsideWaferLoader = True
                    End If
                    'hacc
                ElseIf (childNode.Name = ConstEnum.HaveConfigHACC) Then
                    GetRobotConfigSetting(childNode, StoreGui)
                    StoreGui.HaveConfigHACC = childNode.InnerText

                    ' pacc
                ElseIf (childNode.Name = ConstEnum.HaveConfigPACC) Then
                    GetRobotConfigSetting(childNode, StoreGui)
                    StoreGui.HaveConfigPACC = childNode.InnerText

                    ' Wacc
                ElseIf (childNode.Name = ConstEnum.HaveConfigWACC) Then
                    GetRobotConfigSetting(childNode, StoreGui)
                    StoreGui.HaveConfigWACC = childNode.InnerText

                    'HVEL
                ElseIf (childNode.Name = ConstEnum.HaveConfigHVEL) Then
                    GetRobotConfigSetting(childNode, StoreGui)
                    StoreGui.HaveConfigHVEL = childNode.InnerText

                    'pvel
                ElseIf (childNode.Name = ConstEnum.HaveConfigPVEL) Then
                    GetRobotConfigSetting(childNode, StoreGui)
                    StoreGui.HaveConfigPVEL = childNode.InnerText

                    'wvel
                ElseIf (childNode.Name = ConstEnum.HaveConfigWVEL) Then
                    GetRobotConfigSetting(childNode, StoreGui)
                    StoreGui.HaveConfigWVEL = childNode.InnerText

                ElseIf (childNode.Name = ConstEnum.WaferTotalOfLoader) Then
                    nTotalWafer = 0
                    If (Not String.IsNullOrEmpty(childNode.InnerText)) And Int32.TryParse(childNode.InnerText, nTotalWafer) Then
                        StoreGui.WaferTotalOfLoader = nTotalWafer
                    Else
                        AVPLib.Log.avpLogger.Error("Invalid node " & childNode.Name & " found")
                    End If

                ElseIf (childNode.Name = ConstEnum.UseLotSystemIDInfo) Then
                    GetLotSytemIDInfo(childNode, StoreGui)
                ElseIf (childNode.Name = ConstEnum.HaveInsideWaferRobot) Then
                    StoreGui.WaferAtRobot = GetWaferInfo(childNode)
                    StoreGui.HaveInsideWaferRobot = False

                    If StoreGui.WaferAtRobot IsNot Nothing Then
                        StoreGui.HaveInsideWaferRobot = True
                    End If
                ElseIf (childNode.Name = ConstEnum.TotalWaferCount) Then
                    nTotalWafer = 0
                    If (Not String.IsNullOrEmpty(childNode.InnerText)) And Int32.TryParse(childNode.InnerText, nTotalWafer) Then
                        StoreGui.TotalWaferCount = nTotalWafer
                    Else
                        AVPLib.Log.avpLogger.Error("Invalid node " & childNode.Name & " found")
                    End If
                ElseIf (childNode.Name = ConstEnum.WaferTotalOfLoadLockA) Then
                    nTotalWafer = 0
                    If (Not String.IsNullOrEmpty(childNode.InnerText)) And Int32.TryParse(childNode.InnerText, nTotalWafer) Then
                        StoreGui.WaferTotalOfLoadLockA = nTotalWafer
                    Else
                        AVPLib.Log.avpLogger.Error("Invalid node " & childNode.Name & " found")
                    End If

                ElseIf (childNode.Name = ConstEnum.LifeTimeWafer) Then
                    nLifeTimeWafer = 0
                    If (Not String.IsNullOrEmpty(childNode.InnerText)) And Int32.TryParse(childNode.InnerText, nLifeTimeWafer) Then
                        StoreGui.LifeTimeWafer = nLifeTimeWafer
                    Else
                        AVPLib.Log.avpLogger.Error("Invalid node " & childNode.Name & " found")
                    End If

                ElseIf (childNode.Name = ConstEnum.LotIDOfLoadLockA) Then
                    If (Not String.IsNullOrEmpty(childNode.InnerText)) Then
                        StoreGui.LotID_LLA = childNode.InnerText
                        '#Fix bug: Log error invalid node when init. - ID of LoadLockA allow empty. 
                        'Else
                        '    AVPLib.Log.avpLogger.Error("Invalid node " & childNode.Name & " found")
                    End If
                ElseIf (childNode.Name = ConstEnum.SequenceIDOfLoadLockA) Then
                    If (Not String.IsNullOrEmpty(childNode.InnerText)) Then
                        StoreGui.SequenceID_LLA = childNode.InnerText
                        '#Fix bug: Log error invalid node when init. - Sequence of LoadLockA allow empty
                        'Else
                        '    AVPLib.Log.avpLogger.Error("Invalid node " & childNode.Name & " found")
                    End If
                    ''get wafer Count
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE AndAlso (childNode.Name = "WaferCountOfChamber1") Then
                    If Not (Integer.TryParse(childNode.InnerText, StoreGui.WaferCountOfChamber1)) Then
                        StoreGui.WaferCountOfChamber1 = 0
                        AVPLib.Log.avpLogger.Error("Invalid node " & childNode.Name & " found")
                    End If
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE AndAlso (childNode.Name = "WaferCountOfChamber2") Then
                    If Not (Integer.TryParse(childNode.InnerText, StoreGui.WaferCountOfChamber2)) Then
                        StoreGui.WaferCountOfChamber2 = 0
                        AVPLib.Log.avpLogger.Error("Invalid node " & childNode.Name & " found")
                    End If
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE AndAlso (childNode.Name = "WaferCountOfChamber3") Then
                    If Not (Integer.TryParse(childNode.InnerText, StoreGui.WaferCountOfChamber3)) Then
                        StoreGui.WaferCountOfChamber3 = 0
                        AVPLib.Log.avpLogger.Error("Invalid node " & childNode.Name & " found")
                    End If
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE AndAlso (childNode.Name = ConstEnum.WaferOfChamber1) Then
                    Dim nodeWaferOfLoadLockAList As System.Xml.XmlNodeList = childNode.ChildNodes


                    Dim ChamberModule As AVPLib.SystemModule = _
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER1_NAME))
                    Dim arrWaferOfChamber As AVPLib.AVPWaferInfo() = New AVPLib.AVPWaferInfo(ChamberModule.MaxNumberOfSlot - 1) {}
                    For slotID As Integer = 0 To ChamberModule.MaxNumberOfSlot - 1
                        Dim slotNode As Xml.XmlNode = nodeWaferOfLoadLockAList.Item(slotID)
                        If (slotNode IsNot Nothing) Then
                            arrWaferOfChamber(slotID) = GetWaferInfo(slotNode)
                            If arrWaferOfChamber(slotID) IsNot Nothing Then
                                arrWaferOfChamber(slotID).SlotID = slotID + 1
                            End If
                        Else
                            arrWaferOfChamber(slotID) = Nothing
                        End If
                    Next
                    StoreGui.Chamber1WaferInfo = arrWaferOfChamber

                ElseIf AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE AndAlso (childNode.Name = ConstEnum.WaferOfChamber2) Then
                    Dim nodeWaferOfLoadLockAList As System.Xml.XmlNodeList = childNode.ChildNodes

                    Dim ChamberModule As AVPLib.SystemModule = _
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER2_NAME))
                    Dim arrWaferOfChamber As AVPLib.AVPWaferInfo() = New AVPLib.AVPWaferInfo(ChamberModule.MaxNumberOfSlot - 1) {}
                    For slotID As Integer = 0 To ChamberModule.MaxNumberOfSlot - 1
                        Dim slotNode As Xml.XmlNode = nodeWaferOfLoadLockAList.Item(slotID)
                        If (slotNode IsNot Nothing) Then
                            arrWaferOfChamber(slotID) = GetWaferInfo(slotNode)
                            If arrWaferOfChamber(slotID) IsNot Nothing Then
                                arrWaferOfChamber(slotID).SlotID = slotID + 1
                            End If
                        Else
                            arrWaferOfChamber(slotID) = Nothing
                        End If
                    Next
                    StoreGui.Chamber2WaferInfo = arrWaferOfChamber
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE AndAlso (childNode.Name = ConstEnum.WaferOfChamber3) Then
                    Dim nodeWaferOfLoadLockAList As System.Xml.XmlNodeList = childNode.ChildNodes

                    Dim ChamberModule As AVPLib.SystemModule = _
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER3_NAME))
                    Dim arrWaferOfChamber As AVPLib.AVPWaferInfo() = New AVPLib.AVPWaferInfo(ChamberModule.MaxNumberOfSlot - 1) {}
                    For slotID As Integer = 0 To ChamberModule.MaxNumberOfSlot - 1
                        Dim slotNode As Xml.XmlNode = nodeWaferOfLoadLockAList.Item(slotID)
                        If (slotNode IsNot Nothing) Then
                            arrWaferOfChamber(slotID) = GetWaferInfo(slotNode)
                            If arrWaferOfChamber(slotID) IsNot Nothing Then
                                arrWaferOfChamber(slotID).SlotID = slotID + 1
                            End If
                        Else
                            arrWaferOfChamber(slotID) = Nothing
                        End If
                    Next
                    StoreGui.Chamber3WaferInfo = arrWaferOfChamber
                ElseIf childNode.Name = ConstEnum.WaferOfLoadLockA Then
                    Dim nodeWaferOfLoadLockAList As System.Xml.XmlNodeList = childNode.ChildNodes
                    Dim arrWaferOfLoadLockA As AVPLib.AVPWaferInfo() = New AVPLib.AVPWaferInfo(RobotConfigurationValues.SLOT_NUM_LLA - 1) {}
                    For slotID As Integer = 0 To RobotConfigurationValues.SLOT_NUM_LLA - 1
                        Dim slotNode As Xml.XmlNode = nodeWaferOfLoadLockAList.Item(slotID)
                        If (slotNode IsNot Nothing) Then
                            arrWaferOfLoadLockA(slotID) = GetWaferInfo(slotNode)
                            If arrWaferOfLoadLockA(slotID) IsNot Nothing Then
                                arrWaferOfLoadLockA(slotID).SlotID = slotID + 1
                            End If
                        Else
                            arrWaferOfLoadLockA(slotID) = Nothing
                        End If

                    Next
                    StoreGui.LoadLockAWaferInfo = arrWaferOfLoadLockA

                ElseIf (childNode.Name = "UseAbsoluteKWH") Then
                    If Not (Boolean.TryParse(childNode.InnerText, StoreGui.UseAbsoluteKWH)) Then
                        StoreGui.UseAbsoluteKWH = True
                        AVPLib.Log.avpLogger.Error("Invalid node " & childNode.Name & " found")
                    End If
                Else
                    AVPLib.Log.avpLogger.Error("Unknown node " & childNode.Name & " found")
                End If
            Next
#If AVP_PLATFORM = "CX" Then
            ''read Store gui for all hiden column in DataRun 
            'push in Hastable
            'storegui.HstHideColumn_In_DataRun.Add(.....)
            For Each childNode As Xml.XmlNode In nodeList

                If ContainerData.HidenColumnInDataRun.ContainsKey(childNode.Name) Then
                    Dim ListCol As List(Of String) = ContainerData.HidenColumnInDataRun.Item(childNode.Name)
                    For attNode As Integer = 0 To childNode.Attributes.Count - 1
                        If Not ListCol.Contains(childNode.Attributes(attNode).Value) Then
                            ListCol.Add(childNode.Attributes(attNode).Value)
                        End If
                    Next
                End If
            Next
            GetChamberStoreData(StoreGuiDoc, StoreGui)
#End If
            Return StoreGui

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetStoreGui")
        Return Nothing
    End Function

    ''' <name> Tinh Le </name>
    ''' <date>2021-10-12</date>
    ''' <summary>
    ''' Gets chamber store data.
    ''' </summary>
    Private Shared Sub GetChamberStoreData(ByVal StoreGuiDoc As System.Xml.XmlDocument, ByRef StoreGui As DBStoreGui)
        Try
            ' Chamber 1
            Dim chamber1Node As Xml.XmlNode = StoreGuiDoc.FirstChild.SelectSingleNode("Chamber1")
            If chamber1Node IsNot Nothing Then
                For Each node As Xml.XmlNode In chamber1Node.ChildNodes
                    StoreGui.Chamber1StoreData(node.Name) = node.InnerText
                Next
            End If

            ' Chamber 2
            Dim chamber2Node As Xml.XmlNode = StoreGuiDoc.FirstChild.SelectSingleNode("Chamber2")
            If chamber2Node IsNot Nothing Then
                For Each node As Xml.XmlNode In chamber2Node.ChildNodes
                    StoreGui.Chamber2StoreData(node.Name) = node.InnerText
                Next
            End If

            ' Chamber 3
            Dim chamber3Node As Xml.XmlNode = StoreGuiDoc.FirstChild.SelectSingleNode("Chamber3")
            If chamber3Node IsNot Nothing Then
                For Each node As Xml.XmlNode In chamber3Node.ChildNodes
                    StoreGui.Chamber3StoreData(node.Name) = node.InnerText
                Next
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Tinh Le </name>
    '''    	<date> 2020-04-23</date>
    ''' </author>
    ''' <summary>
    ''' Get Robot Config Setting
    ''' </summary>
    Public Shared Sub GetRobotConfigSetting(ByVal childNode As Xml.XmlNode, ByVal StoreGui As DBStoreGui)
        Try
            AVPLib.Log.coreLogger.Info("Enter GetRobotConfig")
            Select Case childNode.Name
                Case HaveConfigHACC
                    StoreGui.R_HACC = childNode.Attributes.ItemOf(R_HACC).InnerText
                    StoreGui.T_HACC = childNode.Attributes.ItemOf(T_HACC).InnerText
                    StoreGui.Z_HACC = childNode.Attributes.ItemOf(Z_HACC).InnerText
                    'PACC
                Case HaveConfigPACC
                    StoreGui.R_PACC = childNode.Attributes.ItemOf(R_PACC).InnerText
                    StoreGui.T_PACC = childNode.Attributes.ItemOf(T_PACC).InnerText
                    StoreGui.Z_PACC = childNode.Attributes.ItemOf(Z_PACC).InnerText
                    'WACC
                Case HaveConfigWACC
                    StoreGui.R_WACC = childNode.Attributes.ItemOf(R_WACC).InnerText
                    StoreGui.T_WACC = childNode.Attributes.ItemOf(T_WACC).InnerText
                    StoreGui.Z_WACC = childNode.Attributes.ItemOf(Z_WACC).InnerText
                    'HVEL
                Case HaveConfigHVEL
                    StoreGui.R_HVEL = childNode.Attributes.ItemOf(R_HVEL).InnerText
                    StoreGui.T_HVEL = childNode.Attributes.ItemOf(T_HVEL).InnerText
                    StoreGui.Z_HVEL = childNode.Attributes.ItemOf(Z_HVEL).InnerText
                    'PVEL
                Case HaveConfigPVEL
                    StoreGui.R_PVEL = childNode.Attributes.ItemOf(R_PVEL).InnerText
                    StoreGui.T_PVEL = childNode.Attributes.ItemOf(T_PVEL).InnerText
                    StoreGui.Z_PVEL = childNode.Attributes.ItemOf(Z_PVEL).InnerText
                    'WVEL
                Case HaveConfigWVEL
                    StoreGui.R_WVEL = childNode.Attributes.ItemOf(R_WVEL).InnerText
                    StoreGui.T_WVEL = childNode.Attributes.ItemOf(T_WVEL).InnerText
                    StoreGui.Z_WVEL = childNode.Attributes.ItemOf(Z_WVEL).InnerText
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetRobotConfig")
    End Sub

    ''' <author>
    '''    	<name> Tinh Le </name>
    '''    	<date> 2020-11-10</date>
    ''' </author>
    ''' <summary>
    ''' Save Store Gui Attribute WVEL
    ''' </summary>
    Public Shared Sub SaveStoreGuiAttributeRobot(ByRef childNode As Xml.XmlNode, ByVal storeGui As DBStoreGui)
        AVPLib.Log.coreLogger.Info("Enter SaveStoreGuiAttributeRobot")
        If childNode IsNot Nothing Then
            Select Case childNode.Name
                Case HaveConfigHACC
                    ''->write to attribute
                    childNode.Attributes.ItemOf(ConstEnum.R_HACC).InnerText = storeGui.R_HACC
                    childNode.Attributes.ItemOf(ConstEnum.T_HACC).InnerText = storeGui.T_HACC
                    childNode.Attributes.ItemOf(ConstEnum.Z_HACC).InnerText = storeGui.Z_HACC
                    childNode.InnerText = storeGui.HaveConfigHACC
                    'pacc
                Case HaveConfigPACC
                    ''->write to attribute
                    childNode.Attributes.ItemOf(ConstEnum.R_PACC).InnerText = storeGui.R_PACC
                    childNode.Attributes.ItemOf(ConstEnum.T_PACC).InnerText = storeGui.T_PACC
                    childNode.Attributes.ItemOf(ConstEnum.Z_PACC).InnerText = storeGui.Z_PACC
                    childNode.InnerText = storeGui.HaveConfigPACC
                    'wacc
                Case HaveConfigWACC
                    ''->write to attribute
                    childNode.Attributes.ItemOf(ConstEnum.R_WACC).InnerText = storeGui.R_WACC
                    childNode.Attributes.ItemOf(ConstEnum.T_WACC).InnerText = storeGui.T_WACC
                    childNode.Attributes.ItemOf(ConstEnum.Z_WACC).InnerText = storeGui.Z_WACC
                    childNode.InnerText = storeGui.HaveConfigWACC
                    'hvel
                Case HaveConfigHVEL
                    ''->write to attribute
                    childNode.Attributes.ItemOf(ConstEnum.R_HVEL).InnerText = storeGui.R_HVEL
                    childNode.Attributes.ItemOf(ConstEnum.T_HVEL).InnerText = storeGui.T_HVEL
                    childNode.Attributes.ItemOf(ConstEnum.Z_HVEL).InnerText = storeGui.Z_HVEL
                    childNode.InnerText = storeGui.HaveConfigHVEL
                    'pvel
                Case HaveConfigPVEL
                    ''->write to attribute
                    childNode.Attributes.ItemOf(ConstEnum.R_PVEL).InnerText = storeGui.R_PVEL
                    childNode.Attributes.ItemOf(ConstEnum.T_PVEL).InnerText = storeGui.T_PVEL
                    childNode.Attributes.ItemOf(ConstEnum.Z_PVEL).InnerText = storeGui.Z_PVEL
                    childNode.InnerText = storeGui.HaveConfigPVEL
                    'wvel
                Case HaveConfigWVEL
                    ''->write to attribute
                    childNode.Attributes.ItemOf(ConstEnum.R_WVEL).InnerText = storeGui.R_WVEL
                    childNode.Attributes.ItemOf(ConstEnum.T_WVEL).InnerText = storeGui.T_WVEL
                    childNode.Attributes.ItemOf(ConstEnum.Z_WVEL).InnerText = storeGui.Z_WVEL
                    childNode.InnerText = storeGui.HaveConfigWVEL
            End Select
        End If
        AVPLib.Log.coreLogger.Info("Leave SaveStoreGuiAttributeRobot")
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-14</date>
    ''' </author>
    ''' <summary>
    ''' SaveUser
    ''' </summary>
    ''' <param name="StoreGuiDoc"></param>
    ''' <param name="StoreGui"></param>
    ''' <remarks></remarks>
    Public Shared Sub SaveStoreGuiAttribute(ByRef childNode As Xml.XmlNode, ByVal waferInfo As AVPWaferInfo)
        AVPLib.Log.coreLogger.Info("Enter SaveStoreGuiAttribute")
        If childNode IsNot Nothing Then
            If (waferInfo IsNot Nothing) Then
                ''->write to attribute
                childNode.Attributes.ItemOf(WAFER_ID).InnerText = waferInfo.WaferID
                childNode.Attributes.ItemOf(WAFER_STATUS).InnerText = waferInfo.WaferStatus
                childNode.InnerText = Boolean.TrueString
            Else
                ''->write to attribute
                childNode.Attributes.ItemOf(WAFER_ID).InnerText = String.Empty
                childNode.Attributes.ItemOf(WAFER_STATUS).InnerText = String.Empty
                childNode.InnerText = Boolean.FalseString
            End If
        End If
        AVPLib.Log.coreLogger.Info("Leave SaveStoreGuiAttribute")
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 201-06-14</date>
    ''' </author>
    ''' <summary>
    ''' SaveStoreGuiUseLotSystemIDInfo
    ''' </summary>
    Public Shared Sub SaveStoreGuiUseLotSystemIDInfo(ByRef node As Xml.XmlNode, ByVal StoreGui As DBStoreGui)
        Try
            AVPLib.Log.coreLogger.Info("Enter SaveStoreGuiUseLotSystemIDInfo")
            For Each childNode As Xml.XmlNode In node.ChildNodes
                Select Case childNode.Name
                    Case OPERATOR_ID
                        childNode.InnerText = IIf(StoreGui.UseOperationID = True, Boolean.TrueString, Boolean.FalseString)
                    Case TIP
                        childNode.InnerText = IIf(StoreGui.UseTIP = True, Boolean.TrueString, Boolean.FalseString)
                    Case PALLET_ID
                        childNode.InnerText = IIf(StoreGui.UsePalletID = True, Boolean.TrueString, Boolean.FalseString)
                    Case LOT_ID
                        childNode.InnerText = IIf(StoreGui.UseLotID = True, Boolean.TrueString, Boolean.FalseString)
                    Case PRODUCT_NAME
                        childNode.InnerText = IIf(StoreGui.UseProductName = True, Boolean.TrueString, Boolean.FalseString)
                End Select
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveStoreGuiUseLotSystemIDInfo")
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-04-27</date>
    ''' </author>
    ''' <summary>
    ''' Save LifeTime Wafer
    ''' </summary>
    ''' <param name="StoreGuiDoc"></param>
    ''' <param name="StoreGui"></param>
    ''' <remarks></remarks>
    Public Shared Sub SaveLifeTimeWafer(ByVal StoreGuiDoc As System.Xml.XmlDocument)
        AVPLib.Log.coreLogger.Info("Enter SaveLifeTimeWafer")
        Dim root As System.Xml.XmlNode = StoreGuiDoc.FirstChild
        Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
        For Each childNode As Xml.XmlNode In nodeList
            If (childNode.Name = ConstEnum.LifeTimeWafer) Then
                childNode.InnerText = ContainerData.LifeTimeWafer.ToString()
                Exit For
            End If
        Next
        StoreGuiDoc.Save(ContainerDAO.FPath_StoreGui)
        AVPLib.Log.coreLogger.Info("Leave SaveLifeTimeWafer")
    End Sub
    ''Save WaferCount of EQ(LoadLock, PMx) to StoreGui
    Public Shared Sub SaveWaferCountForEQ(ByVal StoreGuiDoc As System.Xml.XmlDocument, ByVal EQName As String, ByVal WaferCount As Integer)
        AVPLib.Log.coreLogger.Info("Enter SaveWaferCountForEQ")
        Dim root As System.Xml.XmlNode = Nothing

        If EQName.Contains(ConstEnum.LoadLock) Then
            root = StoreGuiDoc.SelectSingleNode("/StoreGui/WaferTotalOf" & EQName)
        ElseIf EQName.Contains(ConstEnum.TM_STR) Then
            root = StoreGuiDoc.SelectSingleNode("/StoreGui/TotalWaferCount")
        Else
            root = StoreGuiDoc.SelectSingleNode("/StoreGui/WaferCountOf" & EQName)
        End If

        If root IsNot Nothing Then
            root.InnerText = WaferCount
            StoreGuiDoc.Save(ContainerDAO.FPath_StoreGui)
        End If
        AVPLib.Log.coreLogger.Info("Leave SaveWaferCountForEQ")
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2017-10-27 </date>
    ''' </author>
    ''' <summary>
    ''' SaveRunNo
    ''' </summary>
    Public Shared Sub SaveRunNo(ByVal StoreGuiDoc As System.Xml.XmlDocument, ByVal runNo As Integer)
        AVPLib.Log.coreLogger.Info("Enter SaveRunNo")
        Dim root As System.Xml.XmlNode = StoreGuiDoc.SelectSingleNode("/StoreGui/RunNo")

        If root IsNot Nothing Then
            root.InnerText = runNo
            StoreGuiDoc.Save(ContainerDAO.FPath_StoreGui)
        End If
        AVPLib.Log.coreLogger.Info("Leave SaveRunNo")
    End Sub

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-14</date>
    ''' </author>
    ''' <summary>
    ''' SaveUser
    ''' </summary>
    ''' <param name="StoreGuiDoc"></param>
    ''' <param name="StoreGui"></param>
    ''' <remarks></remarks>
    Public Shared Sub SaveStoreGui(ByVal StoreGuiDoc As System.Xml.XmlDocument, ByVal StoreGui As DBStoreGui)
        AVPLib.Log.coreLogger.Info("Enter SaveStoreGui")
        Try
            Dim root As System.Xml.XmlNode = StoreGuiDoc.FirstChild
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For Each childNode As Xml.XmlNode In nodeList
                If (childNode.Name = ConstEnum.HaveInsideWaferChamber1) Then
                    childNode.InnerText = StoreGui.HaveInsideWaferChamber1.ToString()
                    SaveStoreGuiAttribute(childNode, StoreGui.WaferChamber1)
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE AndAlso (childNode.Name = ConstEnum.WaferOfChamber1) Then
                    Dim nodeWaferOfChamberList As System.Xml.XmlNodeList = childNode.ChildNodes
                    Dim ChamberModule As AVPLib.SystemModule = _
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER1_NAME))
                    For idx As Integer = 0 To ChamberModule.MaxNumberOfSlot - 1
                        Dim slotNode As Xml.XmlNode = nodeWaferOfChamberList.Item(idx)
                        If (slotNode IsNot Nothing) Then
                            SaveStoreGuiAttribute(slotNode, StoreGui.Chamber1WaferInfo(idx))
                            If StoreGui.Chamber1WaferInfo(idx) Is Nothing Then
                                slotNode.InnerText = False
                            Else
                                slotNode.InnerText = True
                            End If
                        Else
                            AVPLib.Log.avpLogger.Error("No child node found at index " & idx & " of " & childNode.Name)
                        End If
                    Next
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE AndAlso (childNode.Name = ConstEnum.WaferOfChamber2) Then
                    Dim nodeWaferOfChamberList As System.Xml.XmlNodeList = childNode.ChildNodes
                    Dim ChamberModule As AVPLib.SystemModule = _
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER2_NAME))
                    For idx As Integer = 0 To ChamberModule.MaxNumberOfSlot - 1
                        Dim slotNode As Xml.XmlNode = nodeWaferOfChamberList.Item(idx)
                        If (slotNode IsNot Nothing) Then
                            SaveStoreGuiAttribute(slotNode, StoreGui.Chamber2WaferInfo(idx))
                            If StoreGui.Chamber2WaferInfo(idx) Is Nothing Then
                                slotNode.InnerText = False
                            Else
                                slotNode.InnerText = True
                            End If
                        Else
                            AVPLib.Log.avpLogger.Error("No child node found at index " & idx & " of " & childNode.Name)
                        End If
                    Next
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE AndAlso (childNode.Name = ConstEnum.WaferOfChamber3) Then
                    Dim nodeWaferOfChamberList As System.Xml.XmlNodeList = childNode.ChildNodes
                    Dim ChamberModule As AVPLib.SystemModule = _
                                                   AVPLib.ContainerData.GetRobotConfig(AVPLib.Utils.chamberName2ChamberID(RobotConfigurationValues.CHAMBER3_NAME))
                    For idx As Integer = 0 To ChamberModule.MaxNumberOfSlot - 1
                        Dim slotNode As Xml.XmlNode = nodeWaferOfChamberList.Item(idx)
                        If (slotNode IsNot Nothing) Then
                            SaveStoreGuiAttribute(slotNode, StoreGui.Chamber3WaferInfo(idx))
                            If StoreGui.Chamber3WaferInfo(idx) Is Nothing Then
                                slotNode.InnerText = False
                            Else
                                slotNode.InnerText = True
                            End If
                        Else
                            AVPLib.Log.avpLogger.Error("No child node found at index " & idx & " of " & childNode.Name)
                        End If
                    Next
                ElseIf (childNode.Name = ConstEnum.HaveInsideWaferChamber2) Then
                    childNode.InnerText = StoreGui.HaveInsideWaferChamber2
                    SaveStoreGuiAttribute(childNode, StoreGui.WaferChamber2)
                ElseIf (childNode.Name = ConstEnum.HaveInsideWaferChamber3) Then
                    childNode.InnerText = StoreGui.HaveInsideWaferChamber3
                    SaveStoreGuiAttribute(childNode, StoreGui.WaferChamber3)
                ElseIf (childNode.Name = ConstEnum.HaveInsideWaferAligner) Then
                    childNode.InnerText = StoreGui.HaveInsideWaferAligner
                    SaveStoreGuiAttribute(childNode, StoreGui.WaferAtAligner)
                ElseIf (childNode.Name = ConstEnum.LastUsedAlignerRecipe) Then
                    childNode.InnerText = StoreGui.LastUsedAlignerRecipe
                ElseIf (childNode.Name = ConstEnum.HaveInsideWaferLoader) Then
                    childNode.InnerText = StoreGui.HaveInsideWaferLoader
                    SaveStoreGuiAttribute(childNode, StoreGui.WaferAtLoader)
                ElseIf (childNode.Name = ConstEnum.HaveInsideWaferRobot) Then
                    childNode.InnerText = StoreGui.HaveInsideWaferRobot
                    SaveStoreGuiAttribute(childNode, StoreGui.WaferAtRobot)

                    'save config HACC
                ElseIf (childNode.Name = ConstEnum.HaveConfigHACC) Then
                    SaveStoreGuiAttributeRobot(childNode, StoreGui)
                    'save config PACC
                ElseIf (childNode.Name = ConstEnum.HaveConfigPACC) Then
                    SaveStoreGuiAttributeRobot(childNode, StoreGui)
                    'save config WACC
                ElseIf (childNode.Name = ConstEnum.HaveConfigWACC) Then
                    SaveStoreGuiAttributeRobot(childNode, StoreGui)
                    'save config HVEL
                ElseIf (childNode.Name = ConstEnum.HaveConfigHVEL) Then
                    SaveStoreGuiAttributeRobot(childNode, StoreGui)
                    'save config PVEL
                ElseIf (childNode.Name = ConstEnum.HaveConfigPVEL) Then
                    SaveStoreGuiAttributeRobot(childNode, StoreGui)
                    'save config WVEL
                ElseIf (childNode.Name = ConstEnum.HaveConfigWVEL) Then
                    childNode.InnerText = StoreGui.HaveConfigWVEL
                    SaveStoreGuiAttributeRobot(childNode, StoreGui)
                ElseIf (childNode.Name = ConstEnum.WaferTotalOfLoadLockA) Then
                    childNode.InnerText = StoreGui.WaferTotalOfLoadLockA
                ElseIf (childNode.Name = ConstEnum.LotIDOfLoadLockA) Then
                    childNode.InnerText = StoreGui.LotID_LLA
                ElseIf (childNode.Name = ConstEnum.SequenceIDOfLoadLockA) Then
                    childNode.InnerText = StoreGui.SequenceID_LLA
                    'Save LifeTime Wafer.
                ElseIf (childNode.Name = ConstEnum.LifeTimeWafer) Then
                    childNode.InnerText = StoreGui.LifeTimeWafer
                ElseIf (childNode.Name = "UseAbsoluteKWH") Then
                    childNode.InnerText = StoreGui.UseAbsoluteKWH

                    'Save Wafer count
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER1_VISIBLE AndAlso childNode.Name = "WaferCountOfChamber1" Then
                    childNode.InnerText = StoreGui.WaferCountOfChamber1
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER2_VISIBLE AndAlso childNode.Name = "WaferCountOfChamber2" Then
                    childNode.InnerText = StoreGui.WaferCountOfChamber2
                ElseIf AVPLib.RobotConfigurationValues.CHAMBER3_VISIBLE AndAlso childNode.Name = "WaferCountOfChamber3" Then
                    childNode.InnerText = StoreGui.WaferCountOfChamber3
                ElseIf childNode.Name = ConstEnum.WaferOfLoadLockA Then
                    Dim nodeWaferOfLoadLockAList As System.Xml.XmlNodeList = childNode.ChildNodes
                    For idx As Integer = 0 To RobotConfigurationValues.SLOT_NUM_LLA - 1
                        Dim slotNode As Xml.XmlNode = nodeWaferOfLoadLockAList.Item(idx)
                        If (slotNode IsNot Nothing) Then
                            SaveStoreGuiAttribute(slotNode, StoreGui.LoadLockAWaferInfo(idx))
                            If StoreGui.LoadLockAWaferInfo(idx) Is Nothing Then
                                slotNode.InnerText = False
                            Else
                                slotNode.InnerText = True
                            End If
                        Else
                            AVPLib.Log.avpLogger.Error("No child node found at index " & idx & " of " & childNode.Name)
                        End If
                    Next
                End If
            Next

            StoreGuiDoc.Save(ContainerDAO.FPath_StoreGui)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveStoreGui")
    End Sub

    Private Shared SerializationLock As New Object

    Public Shared Sub UpdateWaferInfo(ByVal WaferDB As Object)
        AVPLib.Log.coreLogger.Info("Enter UpdateWaferInfo")
        Try
            Dim WFUpdateDB As WaferUpdateDB = CType(WaferDB, WaferUpdateDB)
            If WFUpdateDB Is Nothing Then
                Exit Sub
            End If
            SyncLock SerializationLock
                'Start Update
                Dim root As System.Xml.XmlNode = WFUpdateDB.StoreGuiDoc.FirstChild
                Dim UpdateNode As Xml.XmlNode = Nothing
                'Source must be Exist,if source and destination have exist -> set Off set On
                If Not String.IsNullOrEmpty(WFUpdateDB.SourceID) AndAlso _
                   Not String.IsNullOrEmpty(WFUpdateDB.DestinationID) Then
                    SelectNodeToUpdate(WFUpdateDB.SourceID, WFUpdateDB.SrcSlotID, UpdateNode, root)
                    SaveStoreGuiAttribute(UpdateNode, Nothing)

                    SelectNodeToUpdate(WFUpdateDB.DestinationID, WFUpdateDB.DstSlotID, UpdateNode, root)
                    SaveStoreGuiAttribute(UpdateNode, WFUpdateDB.WFInfo)
                ElseIf Not String.IsNullOrEmpty(WFUpdateDB.SourceID) Then 'if only source exist -> just set
                    SelectNodeToUpdate(WFUpdateDB.SourceID, WFUpdateDB.SrcSlotID, UpdateNode, root)
                    SaveStoreGuiAttribute(UpdateNode, WFUpdateDB.WFInfo)
                End If
                'BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_StoreGui, StoreGuiDoc)
                WFUpdateDB.StoreGuiDoc.Save(ContainerDAO.FPath_StoreGui)

            End SyncLock
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave UpdateWaferInfo")
    End Sub

    Private Shared Sub SelectNodeToUpdate(ByVal StationName As String, ByVal StationId As String, _
                                          ByRef UpdateNode As Xml.XmlNode, ByVal root As Xml.XmlNode)
        Try
            Dim ChamberConfig As SystemModule = AVPLib.ContainerData.GetRobotConfig(StationName)
            Select Case StationName
                'chamber 1
                Case AVPLib.ConstEnum.Equipments.Chamber1.ToString()

                    If ChamberConfig.Type = AVPLib.SystemModule.ModuleType.PVD4 OrElse ChamberConfig.Type = AVPLib.SystemModule.ModuleType.PVD5T Then
                        UpdateNode = root.SelectSingleNode(ConstEnum.WaferOfChamber1 & "/Slot" & Int16.Parse(StationId).ToString)
                    Else
                        UpdateNode = root.SelectSingleNode(ConstEnum.HaveInsideWaferChamber1)
                    End If
                    'chamber 2
                Case AVPLib.ConstEnum.Equipments.Chamber2.ToString()

                    If ChamberConfig.Type = AVPLib.SystemModule.ModuleType.PVD4 OrElse ChamberConfig.Type = AVPLib.SystemModule.ModuleType.PVD5T Then
                        UpdateNode = root.SelectSingleNode(ConstEnum.WaferOfChamber2 & "/Slot" & Int16.Parse(StationId).ToString)
                    Else
                        UpdateNode = root.SelectSingleNode(ConstEnum.HaveInsideWaferChamber2)
                    End If
                    'chamber 3
                Case AVPLib.ConstEnum.Equipments.Chamber3.ToString()

                    If ChamberConfig.Type = AVPLib.SystemModule.ModuleType.PVD4 OrElse ChamberConfig.Type = AVPLib.SystemModule.ModuleType.PVD5T Then
                        UpdateNode = root.SelectSingleNode(ConstEnum.WaferOfChamber3 & "/Slot" & Int16.Parse(StationId).ToString)
                    Else
                        UpdateNode = root.SelectSingleNode(ConstEnum.HaveInsideWaferChamber3)
                    End If
                    'robot
                Case AVPLib.ConstEnum.Equipments.Robot.ToString()
                    UpdateNode = root.SelectSingleNode(ConstEnum.HaveInsideWaferRobot)
                    'aligner
                Case AVPLib.ConstEnum.Equipments.Aligner.ToString()
                    UpdateNode = root.SelectSingleNode(ConstEnum.HaveInsideWaferAligner)
                    'Case AVPLib.ConstEnum.Equipments.Aligner2.ToString()
                    '    UpdateNode = root.SelectSingleNode(ConstEnum.HaveInsideWaferAligner2)
                    'Case AVPLib.ConstEnum.Equipments.LoadLockB.ToString()
                    '    UpdateNode = root.SelectSingleNode(ConstEnum.WaferOfLoadLockB)
                    '    UpdateNode = UpdateNode.SelectSingleNode("Slot" & StationId)
                    'Load lock A
                Case AVPLib.ConstEnum.Equipments.LoadLockA.ToString()
                    UpdateNode = root.SelectSingleNode(ConstEnum.WaferOfLoadLockA)
                    UpdateNode = UpdateNode.SelectSingleNode("Slot" & Int16.Parse(StationId).ToString)
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("StationName:" & ex.ToString())
        End Try
        
    End Sub
#End Region
End Class

Public Class WaferUpdateDB
    Private m_StoreGuiDoc As System.Xml.XmlDocument
    Private m_WFInfo As AVPLib.AVPWaferInfo
    Private m_SrcStationID As String
    Private m_SrcSlotID As String
    Private m_DestinationID As String
    Private m_DstSlotID As String

    Public Property StoreGuiDoc() As Xml.XmlDocument
        Get
            Return m_StoreGuiDoc
        End Get
        Set(ByVal value As Xml.XmlDocument)
            m_StoreGuiDoc = value
        End Set
    End Property

    Public Property WFInfo() As AVPWaferInfo
        Get
            Return m_WFInfo
        End Get
        Set(ByVal value As AVPWaferInfo)
            m_WFInfo = value
        End Set
    End Property

    Public Property SourceID() As String
        Get
            Return m_SrcStationID
        End Get
        Set(ByVal value As String)
            m_SrcStationID = value
        End Set
    End Property

    Public Property SrcSlotID() As String
        Get
            Return m_SrcSlotID
        End Get
        Set(ByVal value As String)
            m_SrcSlotID = value
        End Set
    End Property

    Public Property DestinationID() As String
        Get
            Return m_DestinationID
        End Get
        Set(ByVal value As String)
            m_DestinationID = value
        End Set
    End Property

    Public Property DstSlotID() As String
        Get
            Return m_DstSlotID
        End Get
        Set(ByVal value As String)
            m_DstSlotID = value
        End Set
    End Property
End Class
