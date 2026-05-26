Public Class MaintenanceLib
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-12-03</date>
    ''' </author>
    ''' <summary>
    ''' Get Configuration Server
    ''' </summary>
    ''' <param name="IBEMaintenanceDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetConfigurationServer(ByVal xmlDoc As System.Xml.XmlDocument, _
                                                  ByVal codeMap As Hashtable, _
                                                  Optional ByVal IsLoadConfigCode As Boolean = False) As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetConfigurationServer")
        Dim map As New Hashtable()
        Try
            Dim root As System.Xml.XmlNode = xmlDoc.FirstChild
            Dim nodeListServerGroup As System.Xml.XmlNodeList = root.ChildNodes

            For e As Integer = 0 To nodeListServerGroup.Count - 1
                Dim nodeServerGroup As System.Xml.XmlNode = nodeListServerGroup.Item(e)
                If nodeServerGroup.Attributes IsNot Nothing Then
                    Dim commandNameAttr As Xml.XmlAttribute = nodeServerGroup.Attributes.ItemOf("CommandName")
                    If (commandNameAttr IsNot Nothing) Then
                        Dim commandName As String = commandNameAttr.Value
                        If Not String.IsNullOrEmpty(commandName) Then
                            Dim commandCode As String = String.Empty
                            Dim propertyName As String = String.Empty
                            Dim decoder As String = String.Empty
                            Dim commandCodeAttr As Xml.XmlAttribute = nodeServerGroup.Attributes.ItemOf("CommandCode")
                            Dim propertyNameAttr As Xml.XmlAttribute = nodeServerGroup.Attributes.ItemOf("PropertyName")
                            Dim decoderAttr As Xml.XmlAttribute = nodeServerGroup.Attributes.ItemOf("Decoder")
                            If commandCodeAttr IsNot Nothing Then
                                commandCode = commandCodeAttr.Value
                            End If
                            If propertyNameAttr IsNot Nothing Then
                                propertyName = propertyNameAttr.Value
                            End If
                            If decoderAttr IsNot Nothing Then
                                decoder = decoderAttr.Value
                            End If
                            map.Add(commandName, New DBCommand(commandName, commandCode, propertyName, decoder))
                            If IsLoadConfigCode Then
                                codeMap.Add(commandCode, New DBCommand(commandName, commandCode, propertyName, decoder))
                            End If
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetConfigurationServer")
        Return map
    End Function
End Class
