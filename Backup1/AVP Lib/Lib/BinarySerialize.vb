Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml
Imports AVPLib.ConstEnum

Public Class BinarySerialize
    Public Shared SERIALIZE_MODE As Boolean = False

    Public Shared Function Open_DatFileConfig(ByVal filename As String) As XmlDocument
        Dim fs As IO.FileStream = Nothing
        If SERIALIZE_MODE = False Then
            filename = filename.Replace(".dat", ".xml")
            Dim xmldoc As New XmlDocument
            If FileExistsHelper.FileExists(filename, 5000) Then
                xmldoc.Load(filename)
                Return xmldoc
            End If
        Else
            If FileExistsHelper.FileExists(filename, 5000) Then
                Dim xmldoc As New XmlDocument
                fs = New IO.FileStream(filename, IO.FileMode.Open, IO.FileAccess.Read)
                Dim BinFormat As New BinaryFormatter
                Dim XMLContent As Object = BinFormat.Deserialize(fs)
                fs.Close()
                xmldoc.LoadXml(CStr(XMLContent))
                Return xmldoc
            End If

        End If
        Return Nothing
    End Function
    Public Shared Sub SaveTo_DatFileConfig(ByVal filename As String, ByVal xmlDoc As XmlDocument)
        Try
            If SERIALIZE_MODE = False Then
                filename = filename.Replace(".dat", ".xml")
                xmlDoc.Save(filename)
            Else
                Dim fs As New IO.FileStream(filename, IO.FileMode.Create)
                Dim bf As New BinaryFormatter
                bf.Serialize(fs, xmlDoc.InnerXml)
                fs.Close()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Shared Sub SaveTo_DatFilePMConfig(ByVal filename As String, ByVal xmlDoc As XmlDocument)
        Try
            If SERIALIZE_MODE = False Then
                xmlDoc.Save(filename)
            Else
                Dim fs As New IO.FileStream(filename, IO.FileMode.Create)
                Dim bf As New BinaryFormatter
                bf.Serialize(fs, xmlDoc.InnerXml)
                fs.Close()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
