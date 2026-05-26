Imports System.Collections.Generic
Imports AVPLib

Public Class MessageMapper
    Public Shared ListOfDecimal_3_digits As New List(Of String)
    Public Shared ListOfDecimal_1_digits As New List(Of String)
    Public Shared ListOfDecimal_Convert_A_To_mA As New List(Of String)

    Private Shared m_MsgNameDoc As System.Xml.XmlDocument
    Private Shared m_SystemMsgName As Hashtable = Nothing
    Private Shared m_MsgValueDoc As System.Xml.XmlDocument
    Private Shared m_SystemMsgValue As Hashtable = Nothing
    Private Shared m_GuiElementWithFormulaAndOutputTypeMap As Hashtable

    '   <MessageName>
    '       <Name>SetIGOfTransferModuleInProcessScreenTo</Name>
    '       <Code>ProcessPanel.IgcgTransferModule.txtIG</Code>
    '       <Formula>10^({0}-10)</Formula>
    '       <OutputType>Scientific</OutputType>
    '   </MessageName>
    Public Shared Sub InitGuiElementWithFormulaAndOutputTypeMap(ByVal messageNameDoc As Xml.XmlDocument)
        AVPLib.Log.guiLogger.Info("Enter InitGuiElementWithFormulaAndOutputTypeMap")
        m_GuiElementWithFormulaAndOutputTypeMap = New Hashtable()
        Try
            Dim root As System.Xml.XmlNode = messageNameDoc.FirstChild
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For Each node As Xml.XmlNode In nodeList
                Dim nodeMsgList As System.Xml.XmlNodeList = node.ChildNodes
                If (nodeMsgList IsNot Nothing) Then
                    If (nodeMsgList.Count >= 3) Then
                        Dim code As String = String.Empty
                        Dim formula As String = String.Empty
                        Dim outputType As String = String.Empty
                        For Each childNode As Xml.XmlNode In nodeMsgList
                            If childNode.Name = "Code" Then
                                code = childNode.InnerText
                                'ElseIf childNode.Name = "Formula" Then

                            ElseIf childNode.Name = "OutputType" Then
                                outputType = childNode.InnerText
                            End If
                            formula = Nothing
                        Next
                        If (Not String.IsNullOrEmpty(code)) And (Not String.IsNullOrEmpty(outputType)) Then
                            If (Not m_GuiElementWithFormulaAndOutputTypeMap.ContainsKey(code)) Then
                                m_GuiElementWithFormulaAndOutputTypeMap.Add(code, New KeyValuePair(Of String, String)(formula, outputType))
                            Else
                                AVPLib.Log.avpLogger.Error("Duplicate Code:" & code.ToString)
                            End If
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave InitGuiElementWithFormulaAndOutputTypeMap")
    End Sub

    Public Shared Function GetFormulaAndOutputType(ByVal guiElement As String) As KeyValuePair(Of String, String)
        Return m_GuiElementWithFormulaAndOutputTypeMap.Item(guiElement)
    End Function

    'consist of Message Name and Message Value
    'put it to each hast table
    Private Shared Sub BuildSystemMsgMap(ByVal MsgDoc As System.Xml.XmlDocument, ByRef outData As Hashtable)
        Try

            If (outData Is Nothing) Then
                outData = New Hashtable
            ElseIf (outData.Count > 0) Then
                outData.Clear()
            End If

            If (MsgDoc IsNot Nothing) Then
                Dim root As System.Xml.XmlNode = MsgDoc.FirstChild
                Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
                For Each node As Xml.XmlNode In nodeList
                    Dim nodeMsgList As System.Xml.XmlNodeList = node.ChildNodes
                    If (nodeMsgList IsNot Nothing) Then
                        If (nodeMsgList.Count >= 2) Then
                            If Not outData.ContainsKey(nodeMsgList.Item(0).InnerText) Then
                                outData.Add(nodeMsgList.Item(0).InnerText, nodeMsgList.Item(1).InnerText)
                            End If
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    '''<Author>
    '''   	<Name> Trang Ta </Name>
    '''   	<Date> 2008-09-06 </Date>
    '''</Author>
    '''<summary>
    ''' this is function: init MessageMapper, load XML file
    '''</summary>
    ''' <remarks></remarks>
    Public Shared Sub Initiate()
        Try
            m_MsgNameDoc = New System.Xml.XmlDocument()
            ListOfDecimal_3_digits.Add("PVD.DCTargetPowerSupply.txtKWH")
            ListOfDecimal_3_digits.Add("PVD.RFTargetPowerSupply.txtKWH")
            InitList1Decimals()
            '#04/07/2011 
            '#0001516: [SL_Build 21_Apr 7,2011]Suppressor current RB is rounding to the near 10. 
            '#If Veeco PM display 15, GUI show 20 and if less than 15, GUI show 10. See screen below 
            '#Begin fix: value * 1000 before round.
            Dim MaxChamberOfCX5 As Integer = 3
            ListOfDecimal_Convert_A_To_mA.Add("IBE.txtBeamCurrent")
            ListOfDecimal_Convert_A_To_mA.Add("IBE.txtBeamCurrentRight")
            ListOfDecimal_Convert_A_To_mA.Add("IBE.txtSuppressorCurrent")
            ListOfDecimal_Convert_A_To_mA.Add("IBE.txtPBNBody")
            ListOfDecimal_Convert_A_To_mA.Add("SL_ProcessPanel.txtPBNBody")
            ListOfDecimal_Convert_A_To_mA.Add("SL_ProcessPanel.txtBeamCurrent")
            ListOfDecimal_Convert_A_To_mA.Add("SL_ProcessPanel.txtSuppressorCurrent")
            '#End fix.
            Try
                'm_MsgNameDoc.Load(AVPLib.ContainerDAO.FPath_MessageName)
                m_MsgNameDoc = AVPLib.BinarySerialize.Open_DatFileConfig(AVPLib.ContainerDAO.FPath_MessageName)
                If m_MsgNameDoc Is Nothing Then
                    m_MsgNameDoc = New System.Xml.XmlDocument()
                    m_MsgNameDoc.LoadXml(AVPLib.XMLResources.MessageName.XMLText)
                    'm_MsgNameDoc.Save(AVPLib.ContainerDAO.FPath_MessageName)
                    BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_MessageName, m_MsgNameDoc)
                End If
            Catch ex As Exception 'try to load the local file
                m_MsgNameDoc.LoadXml(AVPLib.XMLResources.MessageName.XMLText)
                'm_MsgNameDoc.Save(AVPLib.ContainerDAO.FPath_MessageName)
                BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_MessageName, m_MsgNameDoc)
            End Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            m_MsgValueDoc = New System.Xml.XmlDocument()
            Try
                'm_MsgValueDoc.Load(AVPLib.ContainerDAO.FPath_MessageValue)
                m_MsgValueDoc = AVPLib.BinarySerialize.Open_DatFileConfig(AVPLib.ContainerDAO.FPath_MessageValue)
                If m_MsgValueDoc Is Nothing Then
                    m_MsgValueDoc = New System.Xml.XmlDocument()
                    m_MsgValueDoc.LoadXml(AVPLib.XMLResources.MessageValue.XMLText)
                    'm_MsgNameDoc.Save(AVPLib.ContainerDAO.FPath_MessageName)
                    BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_MessageValue, m_MsgValueDoc)
                End If
            Catch ex As Exception
                m_MsgValueDoc.LoadXml(AVPLib.XMLResources.MessageValue.XMLText)
                'm_MsgValueDoc.Save(AVPLib.ContainerDAO.FPath_MessageValue)
                BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_MessageValue, m_MsgValueDoc)

            End Try

            'put xml data to hast table
            BuildSystemMsgMap(m_MsgNameDoc, m_SystemMsgName)
            BuildSystemMsgMap(m_MsgValueDoc, m_SystemMsgValue)

            InitGuiElementWithFormulaAndOutputTypeMap(m_MsgNameDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    Private Shared Function GetNameCode(ByVal Name As String) As String
        AVPLib.Log.guiLogger.Info("Enter GetNameCode")
        Try
            If (m_SystemMsgName IsNot Nothing AndAlso m_SystemMsgName.ContainsKey(Name)) Then
                Return (m_SystemMsgName.Item(Name).ToString)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave GetNameCode")
        Return String.Empty
    End Function

    Private Shared Function GetValueCode(ByVal Name As String) As String
        AVPLib.Log.guiLogger.Info("Enter GetValueCode")
        Try
            If (m_SystemMsgValue IsNot Nothing AndAlso m_SystemMsgValue.ContainsKey(Name)) Then
                Return (m_SystemMsgValue.Item(Name).ToString)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave GetValueCode")
        Return String.Empty
    End Function

    Public Shared Function GetGuiElement(ByVal actionCode As String) As String
        If m_MsgNameDoc IsNot Nothing Then
            Return GetNameCode(actionCode)
        Else
            Return String.Empty
        End If

    End Function
    Public Shared Function GetColorValue(ByVal ColorValue As String) As String
        If m_MsgNameDoc IsNot Nothing Then
            Return GetValueCode(ColorValue)
        Else
            Return String.Empty
        End If
    End Function

    '''<Author>
    '''   	<Name> Trang Ta </Name>
    '''   	<Date> 2008-09-06 </Date>
    '''</Author>
    '''<summary>
    ''' this is function: parse input messages from MessageName.xml,MessageValue.xml
    '''</summary>
    ''' <param name="strInputMessage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Parse(ByVal strInputMessage As String) As String
        AVPLib.Log.guiLogger.Info("Enter Parse")
        AVPLib.Log.guiLogger.Debug("strInputMessage=" + strInputMessage)
        Try
            Dim strMsgName As String
            Dim strMsgValue As String
            Dim strMsgNameCode As String
            Dim strMsgValueCode As String
            strMsgName = strInputMessage.Substring(0, strInputMessage.IndexOf(" "))
            strMsgValue = strInputMessage.Substring(strInputMessage.IndexOf(" ") + 1, strInputMessage.Length - strMsgName.Length - 1)
            strMsgNameCode = Trim(GetNameCode(strMsgName)) ''jump to MessageName
            strMsgValueCode = Trim(GetValueCode(strMsgValue)) ''jump to MessageValue
            If strMsgValueCode <> Nothing Then
                AVPLib.Log.guiLogger.Debug("outputMessage=" + strMsgNameCode + " " + strMsgValueCode)
                AVPLib.Log.guiLogger.Info("Leave Parse")
                Return strMsgNameCode & " " & strMsgValueCode
            Else
                AVPLib.Log.guiLogger.Debug("outputMessage=" + strMsgNameCode & " " & strMsgValue)
                AVPLib.Log.guiLogger.Info("Leave Parse")
                Return strMsgNameCode & " " & strMsgValue
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Parse")
        Return ""
    End Function


    Private Shared Sub InitList1Decimals()
        ListOfDecimal_1_digits.Add("PVD.ChuckControl.txtPos1")
        ListOfDecimal_1_digits.Add("PVD.GasController.txtGas1")
        ListOfDecimal_1_digits.Add("PVD.GasController.txtGas2")
        ListOfDecimal_1_digits.Add("PVD.GasController.txtGas3")
        ListOfDecimal_1_digits.Add("PVD.GasController.txtGas4")
        ListOfDecimal_1_digits.Add("PVD.GasController.txtGas5")
    End Sub
End Class
