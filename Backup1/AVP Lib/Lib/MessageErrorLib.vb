Public Class MessageErrorLib
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-12</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' GetMessageConfig
    ''' </summary>
    ''' <param name="MessageDoc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMessageConfig(ByVal root As System.Xml.XmlNode) As Hashtable
        AVPLib.Log.coreLogger.Info("Enter GetMessageConfig")
        Dim map As New Hashtable()
        Try
            'Dim root As System.Xml.XmlNode = MessageDoc.FirstChild
            Dim nodeListEquipment As System.Xml.XmlNodeList = root.ChildNodes

            For e As Integer = 0 To nodeListEquipment.Count - 1
                Try
                    Dim nodeEquipment As System.Xml.XmlNode = nodeListEquipment.Item(e)
                    Dim Name As String = nodeEquipment.Attributes.ItemOf("Name").Value
                    Dim Code As String = nodeEquipment.Attributes.ItemOf("Code").Value
                    map.Add(Name, Code)
                Catch ex As Exception

                End Try
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetMessageConfig")
        Return map
    End Function

End Class
