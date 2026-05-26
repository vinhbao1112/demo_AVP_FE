Imports System.Text
Imports System.Xml

Public Class StoredConfigData
    Public Const STORE_ITEMS_TAG_NAME As String = "StoredConfigs"
    Public Const ITEM_TAG_NAME As String = "Item"
    Public Const ITEM_SAVED_DATE_NAME As String = "SavedOn"
    Public Const ITEM_VERSION_NAME As String = "Version"
    Public Const VALUE_SEPARATOR As String = ":"
    Public Const ITEM_SEPARATOR As String = ";"
    Public Const STORED_QUEUE_COUNT As Integer = 10
    Public Const MESSAGE_CONFIRM_STORE As String = "Would you like to store current {0} params?"
    Public Const MESSAGE_STORE_SUCCESSFULLY As String = "Store {0} params successfully!"
    Public Const MESSAGE_STORE_UNSUCCESSFULLY As String = "Store {0} params unsuccessfully."

    Public SavedOn As String = String.Empty
    Public Version As String = String.Empty
    Public Data As New Dictionary(Of String, String)

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-27</date>
    ''' </author>
    ''' <summary>
    ''' Export data to a string that present a XML node.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ToXmlString() As String
        Return ExportToXmlString(Me)
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-27</date>
    ''' </author>
    ''' <summary>
    ''' Imports data from specified node.
    ''' </summary>
    ''' <param name="node"></param>
    ''' <remarks></remarks>
    Public Sub Import(ByVal node As XmlNode)
        ImportFromXMLNode(node, Me)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-27</date>
    ''' </author>
    ''' <summary>
    ''' Export data to a string that present a XML node.
    ''' </summary>
    ''' <param name="configItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ExportToXmlString(ByVal configItem As StoredConfigData) As String
        If configItem Is Nothing Then
            Return String.Empty
        End If

        Try
            Dim sb As New StringBuilder
            sb.AppendFormat("<{0} {1}=""{2}"" {3}=""{4}"">", ITEM_TAG_NAME, ITEM_SAVED_DATE_NAME, configItem.SavedOn, ITEM_VERSION_NAME, configItem.Version)
            Dim isFirstAdd As Boolean = True
            For Each key As String In configItem.Data.Keys
                If Not isFirstAdd Then
                    sb.Append(ITEM_SEPARATOR)
                Else
                    isFirstAdd = False
                End If
                sb.AppendFormat("{0}{1}{2}", key, VALUE_SEPARATOR, configItem.Data(key))
            Next
            sb.AppendFormat("</{0}>", ITEM_TAG_NAME)
            Return sb.ToString()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return String.Empty
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-27</date>
    ''' </author>
    ''' <summary>
    ''' Export list of data to a string that present a XML node.
    ''' </summary>
    ''' <param name="listItems"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function ExportToXmlString(ByVal listItems As List(Of StoredConfigData), ByVal name As String) As String
        Dim sb As New StringBuilder
        Try
            sb.AppendFormat("<{0} Name=""{1}"">", STORE_ITEMS_TAG_NAME, name)
            For Each item As StoredConfigData In listItems
                sb.Append(item.ToXmlString())
            Next
            sb.AppendFormat("</{0}>", STORE_ITEMS_TAG_NAME)
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return sb.ToString()
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-27</date>
    ''' </author>
    ''' <summary>
    ''' Imports data from specified node.
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Shared Sub ImportFromXMLNode(ByVal node As XmlNode, ByRef result As StoredConfigData)
        If result Is Nothing Then
            result = New StoredConfigData()
        End If
        Try
            If node.Name = ITEM_TAG_NAME Then
                If node.Attributes(ITEM_SAVED_DATE_NAME) IsNot Nothing Then
                    result.SavedOn = node.Attributes(ITEM_SAVED_DATE_NAME).Value
                End If

                If node.Attributes(ITEM_VERSION_NAME) IsNot Nothing Then
                    result.Version = node.Attributes(ITEM_VERSION_NAME).Value
                End If

                result.Data.Clear()
                Dim innerText As String = node.InnerText
                innerText = innerText.Trim()
                If Not String.IsNullOrEmpty(innerText) Then
                    Dim itemSeparator() As String = {ITEM_SEPARATOR}
                    Dim valueSeparator() As String = {VALUE_SEPARATOR}
                    Dim items As String() = innerText.Split(itemSeparator, StringSplitOptions.RemoveEmptyEntries)
                    If items IsNot Nothing AndAlso items.Length > 0 Then
                        For index As Integer = 0 To items.Length - 1
                            Dim item As String = items(index)
                            If Not String.IsNullOrEmpty(item) Then
                                Dim values() As String = item.Split(valueSeparator, StringSplitOptions.RemoveEmptyEntries)
                                If values.Length = 2 Then
                                    result.Data.Add(values(0), values(1))
                                End If
                                values = Nothing

                            End If
                            item = Nothing

                        Next
                        items = Nothing
                    End If

                    itemSeparator = Nothing
                    valueSeparator = Nothing
                End If
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-27</date>
    ''' </author>
    ''' <summary>
    ''' Imports data from specified node.
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Shared Sub ImportFromXMLNode(ByVal node As XmlNode, ByRef result As List(Of StoredConfigData))
        If result Is Nothing Then
            result = New List(Of StoredConfigData)
        End If

        Try
            result.Clear()
            If node.Name = STORE_ITEMS_TAG_NAME Then
                For Each node In node.ChildNodes
                    Dim item As New StoredConfigData
                    ImportFromXMLNode(node, item)
                    result.Add(item)
                Next
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub
End Class
