Imports System.Management
Imports System.Net.NetworkInformation
Imports System.IO
Imports System.Security.Cryptography

Public Class Utils
    Private Shared ReadOnly IV As Byte() = New Byte(7) {240, 3, 45, 29, 0, 76, 173, 59}
    Private Shared Function ShowNetworkInterfaces() As List(Of String)
        Dim computerProperties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim lstStringMacID As List(Of String) = New List(Of String)
        'Console.WriteLine("Interface information for {0}.{1}     ", computerProperties.HostName, computerProperties.DomainName)
        If nics Is Nothing OrElse nics.Length < 1 Then
            'Console.WriteLine("  No network interfaces found.")
            Return lstStringMacID
        End If

        'Console.WriteLine("  Number of interfaces .................... : {0}", nics.Length)
        For Each adapter As NetworkInterface In nics
            Dim speedA As Long = adapter.Speed
            Dim properties As IPInterfaceProperties = adapter.GetIPProperties()

            Dim address As PhysicalAddress = adapter.GetPhysicalAddress()
            Dim bytes As Byte() = address.GetAddressBytes()
            Dim strMacID As String = String.Empty
            For i As Integer = 0 To bytes.Length - 1
                ' Display the physical address in hexadecimal.
                strMacID = strMacID & bytes(i).ToString("X2")
                ' Insert a hyphen after each byte, unless we are at the end of the
                ' address.
                If i <> bytes.Length - 1 Then
                    strMacID = strMacID & "-"
                End If
            Next
            If Not String.IsNullOrEmpty(strMacID) Then
                lstStringMacID.Add(strMacID)
            End If
        Next
        Return lstStringMacID
    End Function

    Public Shared Function GetMacID()
        Dim strMacID As String = String.Empty
        Try
            Dim MACIDLst As List(Of String) = Nothing
            MACIDLst = Utils.ShowNetworkInterfaces()
            If (MACIDLst.Count > 0) Then
                strMacID = MACIDLst.Item(0).Trim()
            End If
        Catch ex As Exception

        End Try
        Return strMacID
    End Function


    Public Shared Function GetCPUID() As String
        Dim cpuid As [String] = ""
        Try
            Dim mbs As New ManagementObjectSearcher("Select ProcessorID From Win32_processor")
            Dim mbsList As ManagementObjectCollection = mbs.[Get]()
            Dim CPUIDLst As List(Of String) = New List(Of String)
            For Each mo As ManagementObject In mbsList
                If mo IsNot Nothing AndAlso mo("ProcessorID") IsNot Nothing Then
                    CPUIDLst.Add(mo("ProcessorID").ToString().Trim())
                End If
            Next

            If CPUIDLst.Count > 0 Then
                cpuid = CPUIDLst(0)
            End If

            Return cpuid
        Catch generatedExceptionName As Exception
            Return cpuid
        End Try
    End Function

    Public Shared Function GetMotherBoardID() As String
        Dim motherboardid As [String] = ""
        Try
            'Dim mbs As New ManagementObjectSearcher("Select * From Win32_BaseBoard")
            Dim mbs As New ManagementObjectSearcher("Select * From Win32_BIOS")
            Dim mbsList As ManagementObjectCollection = mbs.[Get]()

            For Each mo As ManagementObject In mbsList
                motherboardid = mo("SerialNumber").ToString()
            Next
            Dim strMotherBoardID As String = String.Empty

            Return motherboardid
        Catch generatedExceptionName As Exception
            Return motherboardid
        End Try
    End Function
    Public Shared Function GetHardDriverSerialNumber() As String
        Dim HardDriverID As [String] = ""
        Try
            Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")
            Dim HardDriveLst As List(Of String) = New List(Of String)

            Dim i As Integer = 0
            For Each wmi_HD As ManagementObject In searcher.[Get]()
                ' get the hardware serial no.
                If wmi_HD IsNot Nothing And wmi_HD("SerialNumber") IsNot Nothing Then
                    HardDriveLst.Add(wmi_HD("SerialNumber").ToString().Trim())
                End If
            Next
            If (HardDriveLst.Count > 0) Then
                HardDriverID = HardDriveLst(0)
            End If
            Return HardDriverID
        Catch ex As Exception
            Return HardDriverID
        End Try
    End Function

    Public Shared Function getUUID() As String
        Dim uuid__1 As String = String.Empty
        Dim lstUUID As List(Of String) = New List(Of String)

        Dim mc As New ManagementClass("Win32_ComputerSystemProduct")
        Dim moc As ManagementObjectCollection = mc.GetInstances()

        For Each mo As ManagementObject In moc
            If mo IsNot Nothing AndAlso mo.Properties IsNot Nothing AndAlso mo.Properties("UUID") IsNot Nothing Then
                lstUUID.Add(mo.Properties("UUID").Value.ToString())
            End If
        Next
        If lstUUID.Count > 0 Then
            uuid__1 = lstUUID(0)
        End If
        Return uuid__1
    End Function

    '/ <summary>
    '/ Returns MAC Address from first Network Card in Computer
    '/ </summary>
    '/ <returns>MAC Address in string format</returns>
    'Private Sub GetMacID()
    '    Dim j As Integer = 1

    '    Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
    '    Dim t As Integer = nics.Length

    '    Dim address As PhysicalAddress = nics(j).GetPhysicalAddress()

    '    Dim bytes As Byte() = address.GetAddressBytes()
    '    Dim strS As String = String.Empty
    '    For i As Integer = 0 To bytes.Length - 1
    '        strS = strS & bytes(i).ToString("X2")
    '        txtEncrypt.Text = txtEncrypt.Text & EncryptionHelper.Encrypt(bytes(i).ToString("X2"))
    '        If i <> bytes.Length - 1 Then
    '            strS = strS & "-"
    '            txtEncrypt.Text = txtEncrypt.Text & "-"
    '        End If
    '    Next

    '    txtAddress.Text = strS


    'End Sub


    'Public Shared Function GetMacID()
    '    Dim mc As New ManagementClass("Win32_NetworkAdapterConfiguration")
    '    Dim moc As ManagementObjectCollection = mc.GetInstances()

    '    Dim MACAddress As String = [String].Empty

    '    For Each mo As ManagementObject In moc
    '        If MACAddress = [String].Empty Then
    '            ' only return MAC Address from first card
    '            If CBool(mo("IPEnabled")) = True Then
    '                MACAddress = mo("MacAddress").ToString()
    '            End If
    '        End If
    '        mo.Dispose()
    '    Next
    '    MsgBox(MACAddress)
    '    MACAddress = MACAddress.Replace(":", "")
    '    ' Then youc an set anything to MACAddress
    '    MsgBox(MACAddress)
    'End Function
    Public Shared Function Encrypt(ByVal strText As String, ByVal strEncrKey As String) As String
        'Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        'Dim initVector As String = "@1B2c3D4e5F6g7H8"

        'Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Try
            Dim bykey() As Byte = System.Text.Encoding.UTF8.GetBytes(Left(strEncrKey, 8))
            Dim InputByteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(strText)
            Dim des As New DESCryptoServiceProvider
            Dim ms As New IO.MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(bykey, IV), CryptoStreamMode.Write)
            cs.Write(InputByteArray, 0, InputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Shared Function ExportToInformationFile(ByVal strMACID As String, ByVal strCPUID As String, ByVal strHardDriveID As String, ByVal strPath As String) As Boolean
        Try
            If strPath.Trim() = "" Then
                strPath = System.Environment.CurrentDirectory()
            End If
            Dim strLicense As String = strMACID + "#" + strCPUID + "#" + strHardDriveID
            Dim sf As StreamWriter = New StreamWriter(strPath & "\AVP.Information", False)
            Dim s As String = "#Information for AVP"
            sf.WriteLine(s)
            sf.Write(sf.NewLine)
            sf.WriteLine("[INFORMATION]")
            sf.WriteLine(Encrypt(strLicense, "info1234"))
            sf.Close()
            sf.Dispose()
        Catch ex As Exception
            MessageBox.Show("Could not generate license file.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return True
    End Function
End Class
