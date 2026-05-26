Imports AVPLib.ConstEnum
Imports System.Collections.Generic
Public Class CGFormula
    Private m_strFormula As String
    Private m_dblMin As Double
    Private m_dblMax As Double

    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009</date>
    ''' </author>
    ''' <summary>
    ''' Initialize terminal connection
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal strFormula As String)
        m_strFormula = strFormula
        m_dblMin = 0
        m_dblMax = 0
    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat  </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Name
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Fomula() As String
        Get
            Return m_strFormula
        End Get
        Set(ByVal value As String)
            m_strFormula = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Do Xuan Dat  </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Min
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Min() As Double
        Get
            Return m_dblMin
        End Get
        Set(ByVal value As Double)
            m_dblMin = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' DefaultValue
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Max() As Double
        Get
            Return m_dblMax
        End Get
        Set(ByVal value As Double)
            m_dblMax = value
        End Set
    End Property
End Class

Public Class PressureConfigurationLib
#Region "Functions"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-08</date>
    ''' </author>
    ''' <summary>
    ''' GetPressureConfig
    ''' </summary>
    ''' <param name="PressureDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPressureConfig(ByVal root As System.Xml.XmlNode) As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetPressureConfig")
        Dim map As New Hashtable()
        Try
            '    <Configure>
            '      <Key>CG_Formula</Key>
            '      <Formula>
            '        <segment min="0.375" max="2.842">-0.02585 + (0.03767*{0}) + (0.04563*({0}^2)) + (0.1151*({0}^3)) + (-0.04158*({0}^4)) + (0.008737*({0}^5))</segment>
            '        <segment min="2.842" max="4.945">(0.1031 + (-0.02322*{0}) + (0.07229*({0}^2))) / (1 + (-0.3986*{0}) + 0.07438*({0}^2) + (-0.006866*({0}^3)))</segment>
            '        <segment min="4.94" max="5.659">(100.624 + (-20.5623*{0}))/(1 + (-0.37679*{0}) + 0.0348656*({0}^2))</segment>
            '      </Formula>
            '    </Configure>
            Const CG_Formula1 As String = "-0.02585 + (0.03767*{0}) + (0.04563*({0}^2)) + (0.1151*({0}^3)) + (-0.04158*({0}^4)) + (0.008737*({0}^5))"
            Const CG_Formula2 As String = "(0.1031 + (-0.02322*{0}) + (0.07229*({0}^2))) / (1 + (-0.3986*{0}) + 0.07438*({0}^2) + (-0.006866*({0}^3)))"
            Const CG_Formula3 As String = "(100.624 + (-20.5623*{0}))/(1 + (-0.37679*{0}) + 0.0348656*({0}^2))"
            Const CG_Min1 As Double = 0.375
            Const CG_Min2 As Double = 2.842
            Const CG_Min3 As Double = 4.94
            Const CG_Max1 As Double = 2.842
            Const CG_Max2 As Double = 4.945
            Const CG_Max3 As Double = 5.659
            Const IG_Formula_Type1 As String = "10^({0} - 10)"
            Const IG_Formula_Type2 As String = "10^({0} - 11)"
            Const STR_TYPE1 As String = "TYPE1"
            Const STR_TYPE2 As String = "TYPE2"

            Dim segmentList As New List(Of CGFormula)
            Dim segment As New CGFormula(CG_Formula1)
            segment.Max = CG_Max1
            segment.Min = CG_Min1
            segmentList.Add(segment)

            segment = New CGFormula(CG_Formula2)
            segment.Max = CG_Max2
            segment.Min = CG_Min2
            segmentList.Add(segment)

            segment = New CGFormula(CG_Formula3)
            segment.Max = CG_Max3
            segment.Min = CG_Min3
            segmentList.Add(segment)

            map.Add(AVPLib.ConstEnum.CG_FORMULA, segmentList)

            ''Dim root As System.Xml.XmlNode = PressureDoc.FirstChild
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes

            For i As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(i)
                Dim nodeConfigList As System.Xml.XmlNodeList = node.ChildNodes
                Try
                    ' There is only 2 item in the note list
                    ' Key and Value or Key and Formula
                    Dim iItemNum As Integer = 2
                    If (nodeConfigList.Count = iItemNum) Then
                        Dim key As String = nodeConfigList.Item(0).InnerText
                        ' if this is not a IG FORMULAR
                        If (key <> AVPLib.ConstEnum.IG_FORMULA) Then ''or key <> AVPLib.ConstEnum.CG_FORMULA 
                            Dim value As Object = Nothing
                            If IsNumeric(nodeConfigList.Item(1).InnerText) Then
                                If CDbl(nodeConfigList.Item(1).InnerText) >= 0 Then
                                    value = CDbl(nodeConfigList.Item(1).InnerText)
                                Else
                                    AVPLib.Log.coreLogger.Error("Invalid Pressure Value with " + key + " -> Use default value:" + PRESSURE_DEFAULT_VAL.ToString())
                                    value = PRESSURE_DEFAULT_VAL
                                End If
                            Else
                                AVPLib.Log.coreLogger.Error("Invalid Pressure Value " + key + " -> Use default value:" + PRESSURE_DEFAULT_VAL.ToString())
                                value = PRESSURE_DEFAULT_VAL
                            End If
                            map.Add(key, value)
                            '            ElseIf (key = AVPLib.ConstEnum.CG_FORMULA) Then
                            '                'Dim segmentList As New List(Of CGFormula)
                            '                Dim formulaNode As System.Xml.XmlNode = nodeConfigList.Item(1)
                            '                For iSegment As Integer = 0 To formulaNode.ChildNodes.Count - 1

                            '                    Dim segmentNode As System.Xml.XmlNode = formulaNode.ChildNodes.Item(iSegment)
                            '                    'Dim segment As New CGFormula(segmentNode.InnerText)
                            '                    Dim blError As Boolean = False
                            '                    ' Get the Min attribute
                            '                    Dim attrMin As Xml.XmlAttribute = Nothing
                            '                    attrMin = segmentNode.Attributes.ItemOf(AVPLib.ConstEnum.MIN_STR)
                            '                    ' check if there is not MIN attribute
                            '                    If attrMin Is Nothing Then
                            '                        AVPLib.Log.coreLogger.Error("Invalid Min configuration" + segmentNode.OuterXml)
                            '                        blError = True
                            '                        segment.Min = 0
                            '                    Else
                            '                        ' check if it is not a valid value
                            '                        If Double.TryParse(attrMin.InnerText, segment.Min) = False Then
                            '                            blError = True
                            '                            AVPLib.Log.coreLogger.Error("Invalid min value. It should be a double value")
                            '                        End If
                            '                    End If

                            '                    'Get the Maxattribute
                            '                    Dim attrMax As Xml.XmlAttribute = Nothing
                            '                    attrMax = segmentNode.Attributes.ItemOf(AVPLib.ConstEnum.MAX_STR)
                            '                    ' check if there is not MAX attribute
                            '                    If attrMax Is Nothing Then
                            '                        blError = True
                            '                        AVPLib.Log.coreLogger.Error("Invalid Max configuration" + segmentNode.OuterXml)
                            '                        segment.Max = 0
                            '                    Else
                            '                        ' check if it is not a valid value
                            '                        If Double.TryParse(attrMax.InnerText, segment.Max) = False Then
                            '                            blError = True
                            '                            AVPLib.Log.coreLogger.Error("Invalid min value. It should be a double value")
                            '                        End If
                            '                    End If
                            '                    ' Check min and max constrains
                            '                    If segment.Min >= segment.Max Then
                            '                        blError = True
                            '                        AVPLib.Log.coreLogger.Error("Invalid min max value." + segmentNode.OuterXml)
                            '                    End If

                            '                    'if there is no error
                            '                    If Not blError Then
                            '                        segmentList.Add(segment)
                            '                    End If

                            '                Next
                            '                ' check if there is segment configuration
                            'If segmentList.Count > 0 Then
                            '    map.Add(key, segmentList)
                            'End If
                        ElseIf (key = AVPLib.ConstEnum.IG_FORMULA) Then
                            Dim formulaNode As System.Xml.XmlNode = nodeConfigList.Item(1)
                            If UCase(formulaNode.InnerText) = STR_TYPE1 Then
                                map.Add(key, IG_Formula_Type1)
                            ElseIf UCase(formulaNode.InnerText) = STR_TYPE2 Then
                                map.Add(key, IG_Formula_Type2)
                            Else ''Default Type1 if error
                                map.Add(key, IG_Formula_Type1)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    AVPLib.Log.coreLogger.Error(ex.Message)
                End Try
            Next
        Catch ex As Exception
                    AVPLib.Log.avpLogger.Error(ex.ToString())
                End Try
                AVPLib.Log.coreLogger.Info("Leave GetPressureConfig")
                Return map
    End Function

    Public Shared Function GetTransferPressureSetpointConfig(ByVal root As System.Xml.XmlNode) As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetTransferPressureSetpointConfig")
        Dim map As New Hashtable()
        Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
        Const ItemNum As Integer = 2
#If AVP_PLATFORM = "CX" Then
        If root.ChildNodes.Count < MaxTRANSFERSETPOINT_CONFIG Then
            ContainerData.Search_And_Append_System_Values("TransferPressureSetpoint", root)
        End If
#End If
        For i As Integer = 0 To nodeList.Count - 1
            Dim node As System.Xml.XmlNode = nodeList.Item(i)
            Dim nodeConfigList As System.Xml.XmlNodeList = node.ChildNodes
            Try
                ' Key and Value.
                If (nodeConfigList.Count = ItemNum) Then
                    Dim key As String = nodeConfigList.Item(0).InnerText
                    Dim val As Object = nodeConfigList.Item(1).InnerText.ToLower()
                    If (Not map.ContainsKey(key)) Then
                        map.Add(key, val)
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.coreLogger.Error(ex.Message)
            End Try
        Next
        AVPLib.Log.coreLogger.Info("Leave GetTransferPressureSetpointConfig")
        Return map
    End Function

    Public Shared Function GetLLElevatorConfig(ByVal root As System.Xml.XmlNode, ByVal ElevatorName As String) As Hashtable
        Dim map As New Hashtable()
        Try
            Dim nodeListEquipment As System.Xml.XmlNodeList = root.ChildNodes
            If nodeListEquipment.Count < ConstEnum.MaxELEVATOR_CONFIG Then
                ContainerData.Search_And_Append_System_Values("ElevatorConfig", root)
            End If
            For e As Integer = 0 To nodeListEquipment.Count - 1
                Dim nodeEquipment As System.Xml.XmlNode = nodeListEquipment.Item(e)
                If nodeEquipment.Name = ElevatorName Then
                    If nodeEquipment.ChildNodes.Count < MaxLLELEVATOR_CONFIG Then
                        ContainerData.Search_And_Append_System_Values("LLElevatorConfig", nodeEquipment)
                    End If
                    For i As Integer = 0 To nodeEquipment.ChildNodes.Count - 1
                        Dim Name As String = nodeEquipment.ChildNodes.Item(i).Attributes.ItemOf("Name").InnerText
                        Dim Code As String = nodeEquipment.ChildNodes.Item(i).Attributes.ItemOf("Value").InnerText
                        map.Add(Name, Code)
                    Next

                    Exit For
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return map
    End Function


    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-12-08</date>
    ''' </author>
    ''' <summary>
    ''' SavePressureConfig
    ''' </summary>
    ''' <param name="PressureDoc"></param>
    ''' <param name="TransferModuleMin"></param>
    ''' <param name="TransferModuleMax"></param>
    ''' <param name="LoadLockAMin"></param>
    ''' <param name="LoadLockAMax"></param>
    ''' <param name="LoadLockBMin"></param>
    ''' <param name="LoadLockBMax"></param>
    ''' <param name="IBEMaintenanceMin"></param>
    ''' <param name="IBEMaintenanceMax"></param>
    ''' <remarks></remarks>
    Public Shared Function SavePressureConfig(ByVal xmlDoc As System.Xml.XmlDocument, ByVal TransferModuleMin As Double, ByVal TransferModuleMax As Double, _
    ByVal LoadLockAMin As Double, ByVal LoadLockAMax As Double, ByVal IBEMaintenanceMin As Double, ByVal IBEMaintenanceMax As Double) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SavePressureConfig")
        Try
            Dim root As System.Xml.XmlNode = xmlDoc.SelectSingleNode(ConstEnum.XPATH_SYSTEMPRESSURE)
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            Dim nodeTransferModuleMin As System.Xml.XmlNode = nodeList.Item(0)
            nodeTransferModuleMin.ChildNodes.ItemOf(1).InnerText = TransferModuleMin.ToString()
            Dim nodeTransferModuleMax As System.Xml.XmlNode = nodeList.Item(1)
            nodeTransferModuleMax.ChildNodes.ItemOf(1).InnerText = TransferModuleMax.ToString()

            Dim nodeLoadLockAMin As System.Xml.XmlNode = nodeList.Item(2)
            nodeLoadLockAMin.ChildNodes.ItemOf(1).InnerText = LoadLockAMin.ToString()
            Dim nodeLoadLockAMax As System.Xml.XmlNode = nodeList.Item(3)
            nodeLoadLockAMax.ChildNodes.ItemOf(1).InnerText = LoadLockAMax.ToString()

            Dim nodeIBEMaintenanceMin As System.Xml.XmlNode = nodeList.Item(6)
            nodeIBEMaintenanceMin.ChildNodes.ItemOf(1).InnerText = IBEMaintenanceMin.ToString()
            Dim nodeIBEMaintenanceMax As System.Xml.XmlNode = nodeList.Item(7)
            nodeIBEMaintenanceMax.ChildNodes.ItemOf(1).InnerText = IBEMaintenanceMax.ToString()
            'xmlDoc.Save(ContainerDAO.FPath_SystemConfig)
            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, xmlDoc)
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SavePressureConfig")
        Return False
    End Function

    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-06-16</date>
    ''' </author>
    ''' <summary>
    ''' SavePressure
    ''' </summary>
    ''' <param name="PressureDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SavePressure(ByVal xmlDoc As System.Xml.XmlDocument, ByVal mapPressure As Hashtable) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SavePressure")

        Try
            Dim root As System.Xml.XmlNode = xmlDoc.SelectSingleNode(ConstEnum.XPATH_SYSTEMPRESSURE)
            Dim nodeListPressure As System.Xml.XmlNodeList = root.ChildNodes

            For e As Integer = 0 To nodeListPressure.Count - 1
                Try
                    Dim nodePressure As System.Xml.XmlNode = nodeListPressure.Item(e)
                    Dim Name As String = nodePressure.ChildNodes.Item(0).InnerText
                    If Name = CG_FORMULA Or Name = IG_FORMULA Then
                        Continue For
                    End If
                    Dim PressureValue As Double = mapPressure.Item(Name)
                    If PressureValue >= PRESSURE_DEFAULT_VAL Then
                        nodePressure.ChildNodes.Item(1).InnerText = PressureValue.ToString()
                    Else
                        nodePressure.ChildNodes.Item(1).InnerText = PRESSURE_DEFAULT_VAL
                    End If
                Catch ex As Exception
                    AVPLib.Log.coreLogger.Info("Error in insert data: " & ex.Message)
                End Try
            Next
            'xmlDoc.Save(ContainerDAO.FPath_SystemConfig)
            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, xmlDoc)
            AVPLib.Log.coreLogger.Info("Leave SavePressure")
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SavePressure")
        Return False
    End Function

    Public Shared Function SaveTransferPressureSetpoint(ByVal xmlDoc As System.Xml.XmlDocument, ByVal mapPressure As Hashtable) As Boolean
        AVPLib.Log.coreLogger.Info("Enter SaveTransferPressureSetpoint")

        Try
            Dim root As System.Xml.XmlNode = xmlDoc.SelectSingleNode(ConstEnum.XPATH_TRANSFER_PRESSURE_SET_POINT)
            Dim nodeListPressure As System.Xml.XmlNodeList = root.ChildNodes
            Const ItemNum As Integer = 2
            For index As Integer = 0 To nodeListPressure.Count - 1
                Try
                    Dim nodePressure As System.Xml.XmlNode = nodeListPressure.Item(index)
                    If (nodePressure.ChildNodes.Count = ItemNum) Then
                        Dim Name As String = nodePressure.ChildNodes.Item(0).InnerText
                        Dim PressureValue As Double = IIf(mapPressure.ContainsKey(Name), mapPressure.Item(Name), 0.1)
                        nodePressure.ChildNodes.Item(1).InnerText = PressureValue.ToString()
                    End If
                Catch ex As Exception
                    AVPLib.Log.coreLogger.Info("Error in insert data: " & ex.Message)
                End Try
            Next
            'xmlDoc.Save(ContainerDAO.FPath_SystemConfig)
            BinarySerialize.SaveTo_DatFileConfig(ContainerDAO.FPath_SystemConfig, xmlDoc)
            AVPLib.Log.coreLogger.Info("Leave SaveTransferPressureSetpoint")
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave SaveTransferPressureSetpoint")
        Return False
    End Function

#End Region
End Class
