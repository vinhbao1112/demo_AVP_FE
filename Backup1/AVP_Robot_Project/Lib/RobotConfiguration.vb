Public Class RobotConfiguration
#Region "Functions"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-08</date>
    ''' </author>
    ''' <summary>
    ''' GetComboItems
    ''' </summary>
    ''' <param name="ComboItemsDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetComboItems(ByVal ComboItemsDoc As System.Xml.XmlDocument) As Hashtable
        AVPLib.Log.guiLogger.Info("Enter GetComboItems")
        Try
            Dim map As New Hashtable()
            Dim root As System.Xml.XmlNode = ComboItemsDoc.FirstChild
            Dim nodeList As System.Xml.XmlNodeList = root.ChildNodes
            For i As Integer = 0 To nodeList.Count - 1
                Dim node As System.Xml.XmlNode = nodeList.Item(i)
                Dim key As String = node.Name
                Dim nodeConfigList As System.Xml.XmlNodeList = node.ChildNodes
                Dim ListItem As New ArrayList()
                For item As Integer = 0 To nodeConfigList.Count - 1
                    Dim itemNode As System.Xml.XmlNode = nodeConfigList.Item(item)

                    If AVPLib.RobotConfigurationValues.ALINER_VISIBLE = False AndAlso itemNode.InnerText = "ALIGNER" Then
                        Continue For
                    End If
                    ListItem.Add(itemNode.InnerText)
                Next
                map.Add(key, ListItem)
            Next
            AVPLib.Log.guiLogger.Info("Leave GetComboItems")
            Return map
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            AVPLib.Log.guiLogger.Info("Leave GetComboItems")
        End Try
        Return Nothing
    End Function
#End Region
End Class
