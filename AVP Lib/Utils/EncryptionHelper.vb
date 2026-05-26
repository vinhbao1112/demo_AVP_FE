Imports System.Security.Cryptography
Imports System.Text

    Public Class EncryptionHelper
    Private Const cryptoKey As String = "cryptoKey"

    ' The Initialization Vector for the DES encryption routine
    

    ''' <summary>
    ''' Encrypts provided string parameter
    ''' </summary>
    Public Shared Function Encrypt(ByVal s As String) As String
        Dim IV As Byte() = New Byte(7) {240, 3, 45, 29, 0, 76, _
                    173, 59}
        If s Is Nothing OrElse s.Length = 0 Then
            Return String.Empty
        End If

        Dim result As String = String.Empty

        Try
            Dim buffer As Byte() = Encoding.ASCII.GetBytes(s)

            Dim des As New TripleDESCryptoServiceProvider()

            Dim MD5 As New MD5CryptoServiceProvider()

            des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey))

            des.IV = IV
            result = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length))
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return result
    End Function

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-09-23</date>
    ''' </author>
    ''' <summary>
    '''  Decrypt
    ''' </summary>
    Public Shared Function Decrypt(ByVal strText As String, ByVal sDecrKey As String) As String
        Dim IV As Byte() = New Byte(7) {240, 3, 45, 29, 0, 76, _
                    173, 59}
        Dim inputByteArray(strText.Length) As Byte
        Try
            Dim byKey() As Byte = System.Text.Encoding.UTF8.GetBytes(Left(sDecrKey, 8))
            Dim des As New DESCryptoServiceProvider
            inputByteArray = Convert.FromBase64String(strText)
            Dim ms As New IO.MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Now.ToString() 'If exp occurs, return value always changes. So, hard to hack.
    End Function

    Public Shared Function Encrypt(ByVal strText As String, ByVal strEncrKey As String) As String
        '# No log enter here because this function is use to check license. 
        '# Log has not initialized at this time.
        Try
            Dim IV As Byte() = New Byte(7) {240, 3, 45, 29, 0, 76, _
                    173, 59}
            Dim bykey() As Byte = System.Text.Encoding.UTF8.GetBytes(Left(strEncrKey, 8))
            Dim InputByteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(strText)
            Dim des As New DESCryptoServiceProvider
            Dim ms As New IO.MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(bykey, IV), CryptoStreamMode.Write)
            cs.Write(InputByteArray, 0, InputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return strText
    End Function
End Class