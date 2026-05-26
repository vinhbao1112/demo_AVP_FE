Imports System.Windows.Forms
Imports System.Text.RegularExpressions

Public Class WaferInfoDlg
    Public Shared m_WaferIDlistLLA As List(Of String) = Nothing
    Private m_waferInfo As AVPLib.AVPWaferInfo = Nothing
    Private m_listOfWaferInfo As List(Of AVPLib.AVPWaferInfo)
    Private m_PMSlot As Int16 = 1
    Private m_PMTotalWafer As Int16 = 1
    Private m_WaferStatus As WaferStatus = WaferStatus.UNPROCESS
    Private m_isCoronaSetWafer As Boolean = False
    Private mouseOffset As Point = New Point(0, 0)
    Private isDragDrop As Boolean = False

    Public Sub New(Optional ByVal waferinfo As AVPLib.AVPWaferInfo = Nothing, Optional ByVal IsUsedByPM As Boolean = False, Optional ByVal isOnline As Boolean = False)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Initialize(waferinfo, IsUsedByPM, isOnline)
    End Sub
    Public Sub New(ByVal SlotID As Integer, ByVal waferinfo As AVPLib.AVPWaferInfo, ByVal IsUsedByPM As Boolean, Optional ByVal isOnline As Boolean = False)
        InitializeComponent()
        PMSlot = SlotID
        Initialize(waferinfo, IsUsedByPM, isOnline)
    End Sub
    Private Sub Initialize(Optional ByVal waferinfo As AVPLib.AVPWaferInfo = Nothing, Optional ByVal IsUsedByPM As Boolean = False, Optional ByVal isOnline As Boolean = False)
        m_waferInfo = waferinfo
        If AVPLib.ContainerData.IsChamberVisible(AVPLib.ConstEnum.Equipments.LoadLockA.ToString()) Then
            Me.cbcLoadLock.Items.Add(AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
            Me.cbcLoadLock.SelectedItem = AVPLib.ConstEnum.Equipments.LoadLockA.ToString()
        End If
        If waferinfo IsNot Nothing Then
            If waferinfo.WaferID.Contains("A") Then
                Me.cbcLoadLock.SelectedItem = AVPLib.ConstEnum.Equipments.LoadLockA.ToString()
            End If
            Me.cbcSlot.Items.Add(PMSlot.ToString())
            Me.cbcSlot.SelectedItem = PMSlot.ToString()
        End If
        Me.Height = 392
        '''
        If IsUsedByPM Then
            Me.cbcLoadLock.Enabled = False
            Me.cbcWaferID.Enabled = False
        End If

        ' If PM is ONLINE, disable control
        If isOnline Then
            Me.cbcLoadLock.Enabled = False
            Me.cbcWaferID.Enabled = False
            Me.OK_Button.Enabled = False
            Me.cbcStatus.Enabled = False
        End If
    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 11 - 2009</date>
    ''' </author>
    ''' <summary>
    ''' Wafer ID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WaferInfo() As AVPLib.AVPWaferInfo
        Get
            Return m_waferInfo
        End Get
        Set(ByVal value As AVPLib.AVPWaferInfo)
            m_waferInfo = value
        End Set
    End Property

    Public Property PMSlot() As Int16
        Get
            Return m_PMSlot
        End Get
        Set(ByVal value As Int16)
            m_PMSlot = value
        End Set
    End Property

    Public Property PMTotalWafer() As Int16
        Get
            Return m_PMTotalWafer
        End Get
        Set(ByVal value As Int16)
            m_PMTotalWafer = value
        End Set
    End Property

    Public WriteOnly Property PMWaferStatus() As WaferStatus
        Set(ByVal value As WaferStatus)
            m_WaferStatus = value
            m_isCoronaSetWafer = True
        End Set
    End Property

    Private Function GetSlotID(ByVal waferId As String) As Integer
        Dim iSlotID As Integer = 0
        Dim strRegex As String = "[AB](\d+)"
        If (Regex.IsMatch(waferId, strRegex)) Then
            Dim mtcMatch As Match = Regex.Match(waferId, strRegex)
            iSlotID = CInt(mtcMatch.Groups(1).Value)
        End If
        AVPLib.Log.schedulerLogger.Info("Leave getSlotID")
        Return iSlotID
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Dim iSlotID As Integer = 0 'Unknown slot No
        If m_waferInfo IsNot Nothing Then
            iSlotID = m_waferInfo.SlotID
        End If

        Dim strWaferID As String = cbcWaferID.Text
        Dim strWaferStatus As String = cbcStatus.Text
        Dim waferStatus As AVPLib.ConstEnum.enumWaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferNew

        Try
            waferStatus = [Enum].Parse(GetType(WaferStatus), strWaferStatus, False)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        If m_waferInfo Is Nothing Then
            Integer.TryParse(cbcSlot.Text, iSlotID)
            m_waferInfo = New AVPLib.AVPWaferInfo(strWaferID, iSlotID, waferStatus)
        Else
            m_waferInfo.SlotID = iSlotID
            m_waferInfo.WaferID = strWaferID
            m_waferInfo.WaferStatus = waferStatus
        End If

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub WaferInfoDlg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Public Enum WaferStatus
        UNPROCESS = 1
        [PARTIAL] = 2
        COMPLETE = 3
        [ERROR] = 4
    End Enum

    Private Sub WaferInfoDlg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ' Create wafer information
            ' Initialize the wafer status variable
            cbcStatus.Items.Add(WaferStatus.COMPLETE.ToString())
            cbcStatus.Items.Add(WaferStatus.ERROR.ToString())
            cbcStatus.Items.Add(WaferStatus.PARTIAL.ToString())
            cbcStatus.Items.Add(WaferStatus.UNPROCESS.ToString())
            If m_isCoronaSetWafer Then
                cbcStatus.Text = m_WaferStatus.ToString()
                cbcStatus.Enabled = False
            End If
            'Build the static map
            If m_WaferIDlistLLA Is Nothing Then
                m_WaferIDlistLLA = New List(Of String)
                For i As Integer = 0 To AVPLib.RobotConfigurationValues.SLOT_NUM_LLA - 1
                    Dim strLLAwaferID As String = AVPLib.Utils.GenerateWaferID(i + 1, AVPLib.ConstEnum.Equipments.LoadLockA.ToString())
                    m_WaferIDlistLLA.Add(strLLAwaferID)
                Next
                loadData()
            End If
            ' List of alocated wafer id
            Dim lstAllocatedWaferID As List(Of String) = New List(Of String)

            m_listOfWaferInfo = AVPLib.DataManagerment.EquipmentManager.GetAllWaferInfor()
            For Each Item As AVPLib.AVPWaferInfo In m_listOfWaferInfo
                If Item IsNot Nothing Then
                    lstAllocatedWaferID.Add(Item.WaferID)
                End If
            Next

            ' Initialize the wafer ID available
            For Each strWaferID As String In m_WaferIDlistLLA
                If (Not lstAllocatedWaferID.Contains(strWaferID) AndAlso Not cbcWaferID.Items.Contains(strWaferID)) Then
                    cbcWaferID.Items.Add(strWaferID)
                End If
            Next

            'Initialize PM wafer slot
            If m_PMTotalWafer > 1 Then
                For i As Int16 = 1 To m_PMTotalWafer
                    cbcSlot.Items.Add(i)
                Next
                cbcSlot.SelectedItem = PMSlot
            Else
                cbcSlot.Enabled = False
            End If
            If m_waferInfo IsNot Nothing Then 'Case: update wafer.
                cbcLoadLock_SelectedIndexChanged(cbcLoadLock, e)
            End If

            If m_waferInfo IsNot Nothing Then
                ' Update wafer information for an existing wafer
                cbcWaferID.Text = m_waferInfo.WaferID
                'Add the current wafer ID
                cbcWaferID.Items.Add(m_waferInfo.WaferID)
                Me.cbcWaferID.SelectedItem = m_waferInfo.WaferID
                cbcStatus.Text = IIf(m_waferInfo.WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferComplete, WaferStatus.COMPLETE.ToString(), _
                    IIf(m_waferInfo.WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferError, WaferStatus.ERROR.ToString(), _
                    IIf(m_waferInfo.WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferExposed, WaferStatus.PARTIAL.ToString(), _
                    IIf(m_waferInfo.WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferNew, WaferStatus.UNPROCESS.ToString(), ""))))
                lblWaferStatus.Text = IIf(m_waferInfo.WaferProcessInfo = "", "No Process Scheduled!", m_waferInfo.WaferProcessInfo)
            End If
        Catch ex As Exception
            AVPLib.Log.guiLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub cbcLoadLock_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcLoadLock.SelectedIndexChanged
        Try
            loadData()
        Catch ex As Exception
            AVPLib.Log.guiLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub loadData()
        Try
            Dim strSelectedLoadLock As String = cbcLoadLock.SelectedItem.ToString()

            Dim WaferIDlist As List(Of String) = Nothing
            If strSelectedLoadLock = AVPLib.ConstEnum.Equipments.LoadLockA.ToString() Then
                WaferIDlist = m_WaferIDlistLLA
            End If

            If WaferIDlist IsNot Nothing Then
                ' List of alocated wafer id
                Dim lstwaferInfor As List(Of AVPLib.AVPWaferInfo) = Nothing
                Dim lstAllocatedWaferID As List(Of String) = New List(Of String)

                'Clear the waferID list
                cbcWaferID.Items.Clear()

                lstwaferInfor = AVPLib.DataManagerment.EquipmentManager.GetAllWaferInfor()
                For Each Item As AVPLib.AVPWaferInfo In lstwaferInfor
                    If Item IsNot Nothing Then
                        lstAllocatedWaferID.Add(Item.WaferID)
                    End If
                Next

                ' Initialize the wafer ID available
                For Each strWaferID As String In WaferIDlist
                    If (Not lstAllocatedWaferID.Contains(strWaferID)) Then
                        cbcWaferID.Items.Add(strWaferID)
                    End If
                Next
            End If

            If IsDataAvailable() Then
                OK_Button.Enabled = True
            Else
                OK_Button.Enabled = False
            End If
        Catch ex As Exception
            AVPLib.Log.guiLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub cbcWaferID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcWaferID.SelectedIndexChanged
        If IsDataAvailable() Then
            OK_Button.Enabled = True
        Else
            OK_Button.Enabled = False
        End If
    End Sub

    Private Sub cbcStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcStatus.SelectedIndexChanged
        If IsDataAvailable() Then
            OK_Button.Enabled = True
        Else
            OK_Button.Enabled = False
        End If
    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-11-09</date>
    ''' </author>
    ''' <summary>
    ''' GetUser
    ''' </summary>
    ''' <param name=""></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsDataAvailable() As Boolean
        If cbcStatus.Text = String.Empty Then
            Return False
        End If
        If cbcWaferID.Text = String.Empty Then
            Return False
        End If
#If AVP_PLATFORM = "CX" Then
        If cbcLoadLock.Text = String.Empty Then
            Return False
        End If
#End If
        Return True
    End Function


    Private Sub cbcLoadLock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbcLoadLock.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else

        End If
    End Sub

    Private Sub cbcWaferID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbcWaferID.KeyDown
        Me.cbcLoadLock_KeyDown(sender, e)
    End Sub

    Private Sub cbcStatus_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbcStatus.KeyDown
        Me.cbcLoadLock_KeyDown(sender, e)
    End Sub

    Private Sub cbcSlot_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcSlot.SelectedIndexChanged
        m_PMSlot = cbcSlot.SelectedItem
        If IsDataAvailable() Then
            OK_Button.Enabled = True
        Else
            OK_Button.Enabled = False
        End If
    End Sub
End Class
