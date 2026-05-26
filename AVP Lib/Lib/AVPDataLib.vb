Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Reflection
Imports System.Linq
Imports System.Xml
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System
Imports System.Collections.Generic
Imports System.Text

Public Class AVPDataLib

    Private Shared ReadOnly AppSecretKey As Byte() = New Byte() {
            &H1A, &H2B, &H3C, &H4D, &H5E, &H6F, &H7A, &H8B,
            &H9C, &HD, &H1E, &H2F, &H3A, &H4B, &H5C, &H6D,
            &H7E, &H8F, &H9A, &HB, &H1C, &H2D, &H3E, &H4F,
            &H5A, &H6B, &H7C, &H8D, &H9E, &HF, &H1A, &H2B
    }

    Private Const DllName As String = "AVPDataLib.dll"

    Public Class ItemData
        Private _name As String
        Private _type As String
        Private _value As String

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Public Property Type() As String
            Get
                Return _type
            End Get
            Set(ByVal value As String)
                _type = value
            End Set
        End Property

        Public Property Value() As String
            Get
                Return _value
            End Get
            Set(ByVal value As String)
                _value = value
            End Set
        End Property
    End Class

    Public Class LicenseData
        Private _id As String
        Private _issueDate As String
        Private _expiryDate As String
        Private _licenseeName As String
        Private _machineName As String
        Private _components As List(Of ItemData)
        Private _machineInfo As List(Of ItemData)
        Private _checksums As List(Of ItemData)
        Private _issuePayload As String
        Private _buildVersion As String
        Private _signature As String

        Public Property Id() As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property

        Public Property IssueDate() As String
            Get
                Return _issueDate
            End Get
            Set(ByVal value As String)
                _issueDate = value
            End Set
        End Property

        Public Property ExpiryDate() As String
            Get
                Return _expiryDate
            End Get
            Set(ByVal value As String)
                _expiryDate = value
            End Set
        End Property

        Public Property IssuePayload() As String
            Get
                Return _issuePayload
            End Get
            Set(ByVal value As String)
                _issuePayload = value
            End Set
        End Property

        Public Property BuildVersion() As String
            Get
                Return _buildVersion
            End Get
            Set(ByVal value As String)
                _buildVersion = value
            End Set
        End Property

        Public Property LicenseeName() As String
            Get
                Return _licenseeName
            End Get
            Set(ByVal value As String)
                _licenseeName = value
            End Set
        End Property

        Public Property MachineName() As String
            Get
                Return _machineName
            End Get
            Set(ByVal value As String)
                _machineName = value
            End Set
        End Property

        Public Property Components() As List(Of ItemData)
            Get
                Return _components
            End Get
            Set(ByVal value As List(Of ItemData))
                _components = value
            End Set
        End Property

        Public Property MachineInfo() As List(Of ItemData)
            Get
                Return _machineInfo
            End Get
            Set(ByVal value As List(Of ItemData))
                _machineInfo = value
            End Set
        End Property

        Public Property Checksums() As List(Of ItemData)
            Get
                Return _checksums
            End Get
            Set(ByVal value As List(Of ItemData))
                _checksums = value
            End Set
        End Property

        Public Property Signature() As String
            Get
                Return _signature
            End Get
            Set(ByVal value As String)
                _signature = value
            End Set
        End Property

        Public Sub New()
            _components = New List(Of ItemData)()
            _machineInfo = New List(Of ItemData)()
            _checksums = New List(Of ItemData)()
        End Sub

        Public Function ToXml() As String
            Return AVPDataLib.LicenseDataToXml(Me)
        End Function
    End Class

    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="ProcessChallenge")>
    Private Shared Function ProcessChallengeNative(challenge As String) As IntPtr
    End Function

    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="LicenseDataToXml")>
    Private Shared Function LicenseDataToXmlNative(ByVal licenseData As IntPtr) As IntPtr

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="LicenseDataFromXml")>
    Private Shared Function LicenseDataFromXmlNative(ByVal xmlContent As String) As IntPtr

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="GetChecksum")>
    Private Shared Function GetChecksumNative(ByVal filePath As String) As IntPtr

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="GetChecksumXml")>
    Private Shared Function GetChecksumXmlNative(ByVal filePath As String) As IntPtr

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="GetChecksumBinary")>
    Private Shared Function GetChecksumBinaryNative(ByVal filePath As String) As IntPtr

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="Encrypt")>
    Private Shared Function EncryptNative(ByVal plaintext As String) As IntPtr

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="Decrypt")>
    Private Shared Function DecryptNative(ByVal ciphertext As String) As IntPtr

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="Base64Encode")>
    Private Shared Function Base64EncodeNative(ByVal data As String) As IntPtr

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="Base64Decode")>
    Private Shared Function Base64DecodeNative(ByVal data As String) As IntPtr

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="FreeString")>
    Private Shared Sub FreeString(ByVal str As IntPtr)

    End Sub
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="FreeLicenseData")>
    Private Shared Sub FreeLicenseDataNative(ByVal ptr As IntPtr)

    End Sub
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="GetCPUID")>
    Private Shared Function GetCPUIDNative() As IntPtr

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="GetMACAddress")>
    Private Shared Function GetMACAddressNative() As IntPtr

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="GetHardDriveSerial")>
    Private Shared Function GetHardDriveSerialNative() As IntPtr

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="GetMotherboardUUID")>
    Private Shared Function GetMotherboardUUIDNative() As IntPtr

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="Verify")>
    Public Shared Function Verify() As Integer

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="VerifyPath")>
    Public Shared Function VerifyPath() As Integer

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="CreateSignature")>
    Private Shared Function CreateSignature(ByVal data As String, ByVal privateKey As String, <Out()> ByRef errorCode As Integer) As IntPtr

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="VerifySignature")>
    Public Shared Function VerifySignature(ByVal data As String, ByVal signature As String, ByVal publicKey As String, <Out()> ByRef errorCode As Integer) As Boolean

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="GetXmlData")>
    Private Shared Function GetXmlDataNative() As IntPtr

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="GetXmlDataPath")>
    Private Shared Function GetXmlDataPathNative(ByVal fileName As String) As IntPtr

    End Function
    <DllImport(DllName, CallingConvention:=CallingConvention.StdCall, EntryPoint:="SetAppName")>
    Public Shared Sub SetAppName(ByVal data As String, Optional ByVal key As String = "")

    End Sub


    Public Shared Function Base64Decode(ByVal data As String) As String
        Return PtrToStringAndFree(Base64DecodeNative(data))
    End Function

    ''' <summary>
    ''' Verifies the loaded AVPDataLib.dll is authentic via challenge-response HMAC.
    ''' Call once at app startup.
    ''' </summary>
    Public Shared Function IsSecureDllLoaded() As Boolean
        Try
            Dim challengeBytes(31) As Byte
            ' 1. Generate a random challenge
            Using rng As New System.Security.Cryptography.RNGCryptoServiceProvider()
                rng.GetBytes(challengeBytes)
            End Using
            Dim challenge As String = Convert.ToBase64String(challengeBytes)

            ' 2. Send challenge to the native DLL and get a response
            ' NOTE: PtrToStringAndFree and ProcessChallengeNative are assumed external methods
            Dim dllResponse As String = PtrToStringAndFree(ProcessChallengeNative(challenge))
            If String.IsNullOrEmpty(dllResponse) Then
                Return False
            End If

            ' 3. Calculate the expected response using HMAC-SHA256
            Dim expected As String
            ' NOTE: AppSecretKey is assumed to be a defined Byte array (the HMAC key)
            Using hmac As New System.Security.Cryptography.HMACSHA256(AppSecretKey)
                Dim hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(challenge))
                expected = Convert.ToBase64String(hash)
            End Using

            ' 4. Compare the DLL's response with the expected response
            Return dllResponse = expected

        Catch
            Return False
        End Try
    End Function

    Public Shared Function LicenseDataToXml(ByVal licenseData As LicenseData) As String
        If licenseData Is Nothing Then Return Nothing

        Dim nativeLicenseData As New NativeLicenseData
        Dim nativePtr As IntPtr = IntPtr.Zero

        Try
            nativeLicenseData.Id = Marshal.StringToHGlobalAnsi(licenseData.Id)
            nativeLicenseData.IssueDate = Marshal.StringToHGlobalAnsi(licenseData.IssueDate)
            nativeLicenseData.ExpiryDate = Marshal.StringToHGlobalAnsi(licenseData.ExpiryDate)
            nativeLicenseData.LicenseeName = Marshal.StringToHGlobalAnsi(licenseData.LicenseeName)
            nativeLicenseData.MachineName = Marshal.StringToHGlobalAnsi(licenseData.MachineName)
            nativeLicenseData.IssuePayload = Marshal.StringToHGlobalAnsi(licenseData.IssuePayload)
            nativeLicenseData.BuildVersion = Marshal.StringToHGlobalAnsi(licenseData.BuildVersion)
            nativeLicenseData.Signature = Marshal.StringToHGlobalAnsi(licenseData.Signature)

            Dim compCount As Integer
            nativeLicenseData.Components = ListItemDataToNative(licenseData.Components, compCount)
            nativeLicenseData.ComponentsCount = compCount

            Dim machCount As Integer
            nativeLicenseData.MachineInfo = ListItemDataToNative(licenseData.MachineInfo, machCount)
            nativeLicenseData.MachineInfoCount = machCount

            Dim chkCount As Integer
            nativeLicenseData.Checksums = ListItemDataToNative(licenseData.Checksums, chkCount)
            nativeLicenseData.ChecksumsCount = chkCount

            nativePtr = Marshal.AllocHGlobal(Marshal.SizeOf(GetType(NativeLicenseData)))
            Marshal.StructureToPtr(nativeLicenseData, nativePtr, False)
            Return PtrToStringAndFree(LicenseDataToXmlNative(nativePtr))
        Finally
            If nativeLicenseData.Id <> IntPtr.Zero Then Marshal.FreeHGlobal(nativeLicenseData.Id)
            If nativeLicenseData.IssueDate <> IntPtr.Zero Then Marshal.FreeHGlobal(nativeLicenseData.IssueDate)
            If nativeLicenseData.ExpiryDate <> IntPtr.Zero Then Marshal.FreeHGlobal(nativeLicenseData.ExpiryDate)
            If nativeLicenseData.LicenseeName <> IntPtr.Zero Then Marshal.FreeHGlobal(nativeLicenseData.LicenseeName)
            If nativeLicenseData.MachineName <> IntPtr.Zero Then Marshal.FreeHGlobal(nativeLicenseData.MachineName)
            If nativeLicenseData.IssuePayload <> IntPtr.Zero Then Marshal.FreeHGlobal(nativeLicenseData.IssuePayload)
            If nativeLicenseData.BuildVersion <> IntPtr.Zero Then Marshal.FreeHGlobal(nativeLicenseData.BuildVersion)
            If nativeLicenseData.Signature <> IntPtr.Zero Then Marshal.FreeHGlobal(nativeLicenseData.Signature)

            FreeNativeItemDataArray(nativeLicenseData.Components, nativeLicenseData.ComponentsCount)
            FreeNativeItemDataArray(nativeLicenseData.MachineInfo, nativeLicenseData.MachineInfoCount)
            FreeNativeItemDataArray(nativeLicenseData.Checksums, nativeLicenseData.ChecksumsCount)

            If nativePtr <> IntPtr.Zero Then Marshal.FreeHGlobal(nativePtr)
        End Try
    End Function

    Public Shared Function LicenseDataFromXml(ByVal xmlContent As String) As LicenseData
        Dim nativePtr As IntPtr = LicenseDataFromXmlNative(xmlContent)
        If nativePtr = IntPtr.Zero Then Return Nothing

        Try
            Dim nativeLicenseData As NativeLicenseData = CType(Marshal.PtrToStructure(nativePtr, GetType(NativeLicenseData)), NativeLicenseData)
            Dim licenseData As New LicenseData
            licenseData.Id = PtrToString(nativeLicenseData.Id)
            licenseData.IssueDate = PtrToString(nativeLicenseData.IssueDate)
            licenseData.ExpiryDate = PtrToString(nativeLicenseData.ExpiryDate)
            licenseData.LicenseeName = PtrToString(nativeLicenseData.LicenseeName)
            licenseData.MachineName = PtrToString(nativeLicenseData.MachineName)
            licenseData.IssuePayload = PtrToString(nativeLicenseData.IssuePayload)
            licenseData.BuildVersion = PtrToString(nativeLicenseData.BuildVersion)
            licenseData.Signature = PtrToString(nativeLicenseData.Signature)
            licenseData.Components = ConvertItemDataArray(nativeLicenseData.Components, nativeLicenseData.ComponentsCount)
            licenseData.MachineInfo = ConvertItemDataArray(nativeLicenseData.MachineInfo, nativeLicenseData.MachineInfoCount)
            licenseData.Checksums = ConvertItemDataArray(nativeLicenseData.Checksums, nativeLicenseData.ChecksumsCount)

            Return licenseData
        Finally
            If nativePtr <> IntPtr.Zero Then
                FreeLicenseDataNative(nativePtr)
            End If
        End Try
    End Function

    Public Shared Function GetXmlData(Optional ByVal fileName As String = Nothing) As LicenseData
        Dim nativePtr As IntPtr
        If String.IsNullOrEmpty(fileName) Then
            nativePtr = GetXmlDataNative()
        Else
            nativePtr = GetXmlDataPathNative(fileName)
        End If

        If nativePtr = IntPtr.Zero Then Return Nothing

        Try
            Dim nativeLicenseData As NativeLicenseData = CType(Marshal.PtrToStructure(nativePtr, GetType(NativeLicenseData)), NativeLicenseData)
            Dim licenseData As New LicenseData
            licenseData.Id = PtrToString(nativeLicenseData.Id)
            licenseData.IssueDate = PtrToString(nativeLicenseData.IssueDate)
            licenseData.ExpiryDate = PtrToString(nativeLicenseData.ExpiryDate)
            licenseData.LicenseeName = PtrToString(nativeLicenseData.LicenseeName)
            licenseData.MachineName = PtrToString(nativeLicenseData.MachineName)
            licenseData.IssuePayload = PtrToString(nativeLicenseData.IssuePayload)
            licenseData.BuildVersion = PtrToString(nativeLicenseData.BuildVersion)
            licenseData.Signature = PtrToString(nativeLicenseData.Signature)
            licenseData.Components = ConvertItemDataArray(nativeLicenseData.Components, nativeLicenseData.ComponentsCount)
            licenseData.MachineInfo = ConvertItemDataArray(nativeLicenseData.MachineInfo, nativeLicenseData.MachineInfoCount)
            licenseData.Checksums = ConvertItemDataArray(nativeLicenseData.Checksums, nativeLicenseData.ChecksumsCount)

            Return licenseData
        Finally
            If nativePtr <> IntPtr.Zero Then
                FreeLicenseDataNative(nativePtr)
            End If
        End Try
    End Function

    Private Shared Function PtrToStringAndFree(ByVal ptr As IntPtr) As String
        If ptr = IntPtr.Zero Then Return Nothing
        Try
            Return Marshal.PtrToStringAnsi(ptr)
        Finally
            FreeString(ptr)
        End Try
    End Function

    Private Shared Function PtrToString(ByVal ptr As IntPtr) As String
        If ptr = IntPtr.Zero Then Return Nothing
        Return Marshal.PtrToStringAnsi(ptr)
    End Function

    Private Shared Function ConvertItemDataArray(ByVal arrayPtr As IntPtr, ByVal count As Integer) As List(Of ItemData)
        If arrayPtr = IntPtr.Zero OrElse count = 0 Then Return New List(Of ItemData)()
        Dim result = New List(Of ItemData)(count)
        Dim structSize As Integer = Marshal.SizeOf(GetType(NativeItemData))

        For i As Integer = 0 To count - 1
            Dim elementPtr As IntPtr = New IntPtr(arrayPtr.ToInt64() + i * structSize)
            Dim nativeItem As NativeItemData = CType(Marshal.PtrToStructure(elementPtr, GetType(NativeItemData)), NativeItemData)
            Dim item As New ItemData
            item.Name = PtrToString(nativeItem.Name)
            item.Type = PtrToString(nativeItem.Type)
            item.Value = PtrToString(nativeItem.Value)

            result.Add(item)
        Next

        Return result
    End Function

    Private Shared Function ListItemDataToNative(ByVal list As List(Of ItemData), ByRef count As Integer) As IntPtr
        count = 0
        If list Is Nothing OrElse list.Count = 0 Then Return IntPtr.Zero

        Dim listCount As Integer = list.Count
        Dim structSize As Integer = Marshal.SizeOf(GetType(NativeItemData))
        Dim arrayPtr As IntPtr = Marshal.AllocHGlobal(listCount * structSize)

        ' Zero-initialize memory to prevent garbage pointers
        Dim zeroBytes(listCount * structSize - 1) As Byte
        Marshal.Copy(zeroBytes, 0, arrayPtr, zeroBytes.Length)

        Try
            For i As Integer = 0 To listCount - 1
                Dim nativeItem As New NativeItemData
                nativeItem.Name = Marshal.StringToHGlobalAnsi(list(i).Name)
                nativeItem.Type = Marshal.StringToHGlobalAnsi(list(i).Type)
                nativeItem.Value = Marshal.StringToHGlobalAnsi(list(i).Value)

                Dim elementPtr As IntPtr = New IntPtr(arrayPtr.ToInt64() + i * structSize)
                Marshal.StructureToPtr(nativeItem, elementPtr, False)
            Next
            count = listCount
            Return arrayPtr
        Catch ex As Exception
            FreeNativeItemDataArray(arrayPtr, listCount)
            Throw
        End Try
    End Function

    Private Shared Sub FreeNativeItemDataArray(ByVal arrayPtr As IntPtr, ByVal count As Integer)
        If arrayPtr = IntPtr.Zero OrElse count = 0 Then Return

        Dim structSize As Integer = Marshal.SizeOf(GetType(NativeItemData))
        For i As Integer = 0 To count - 1
            Dim elementPtr As IntPtr = New IntPtr(arrayPtr.ToInt64() + i * structSize)
            Dim nativeItem As NativeItemData = CType(Marshal.PtrToStructure(elementPtr, GetType(NativeItemData)), NativeItemData)
            If nativeItem.Name <> IntPtr.Zero Then Marshal.FreeHGlobal(nativeItem.Name)
            If nativeItem.Type <> IntPtr.Zero Then Marshal.FreeHGlobal(nativeItem.Type)
            If nativeItem.Value <> IntPtr.Zero Then Marshal.FreeHGlobal(nativeItem.Value)
        Next
        Marshal.FreeHGlobal(arrayPtr)
    End Sub

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
    Private Structure NativeItemData
        Public Name As IntPtr
        Public Type As IntPtr
        Public Value As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
    Private Structure NativeLicenseData
        Public Id As IntPtr
        Public IssueDate As IntPtr
        Public ExpiryDate As IntPtr
        Public LicenseeName As IntPtr
        Public MachineName As IntPtr
        Public Components As IntPtr
        Public ComponentsCount As Integer
        Public MachineInfo As IntPtr
        Public MachineInfoCount As Integer
        Public Checksums As IntPtr
        Public ChecksumsCount As Integer
        Public IssuePayload As IntPtr
        Public BuildVersion As IntPtr
        Public Signature As IntPtr
    End Structure
End Class