Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib
Imports AVPControls

Public Class SelectWaferForm

#Region "Class Constants & Variables"
    Private Const BOTTOMMAGRIN As Integer = 5
    Private Const BANK_WIDTH As Integer = 262
    Const WAFER_RADIUS As Integer = 60
    Private Const SPACE_BTW_WAFER As Integer = 15
    Private Const NUM_OF_WAFER_PER_COL As Integer = 6
    Public Enum SelectWaferDialogResult
        [Invalid] = -1
        [SourceForMove] = 1
        [DestinationForMove] = 2
    End Enum

    Private m_arrBarStatus As AVPLib.ConstEnum.enumWaferStatus()
    Private m_arrWaferControl As WaferControl()
    Private m_arrWaferCheckBox As WaferCheckBox()
    'Private m_arrWaferNumLabel As WaferControl()
    Private m_enmSelectWaferResult As SelectWaferDialogResult
    Private m_intCurrentSelectedWafer As Integer
    Private m_LockName As String
    Private m_SemiautoTransferWaferPanel As SemiautoTranferWaferControl
    
#End Region

#Region "properties"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-13</date>
    ''' </author>
    ''' <summary>
    ''' Get or set Lock Name
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SemiautoTransferWaferPanel() As SemiautoTranferWaferControl
        Get
            Return m_SemiautoTransferWaferPanel
        End Get
        Set(ByVal value As SemiautoTranferWaferControl)
            m_SemiautoTransferWaferPanel = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-13</date>
    ''' </author>
    ''' <summary>
    ''' Get or set Lock Name
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property stoStatusObject() As StatusObject
        Get
            Return m_stoStatusObject
        End Get
        Set(ByVal value As StatusObject)
            m_stoStatusObject = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2009-01-13</date>
    ''' </author>
    ''' <summary>
    ''' Get or set Lock Name
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LockName() As String
        Get
            Return m_LockName
        End Get
        Set(ByVal value As String)
            m_LockName = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Get or set status array of all wafers
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BarsStatus() As AVPLib.ConstEnum.enumWaferStatus()
        Get
            Return m_arrBarStatus
        End Get
        Set(ByVal value As AVPLib.ConstEnum.enumWaferStatus())
            Try
                If (value IsNot Nothing) Then
                    m_arrBarStatus = value
                    Me.AddBars()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Get result of execution dialog
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property WaferDialogResult() As SelectWaferDialogResult
        Get
            Return m_enmSelectWaferResult
        End Get
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Get current selected wafer index
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectedWaferIndex() As Integer
        Get
            Return m_intCurrentSelectedWafer
        End Get
    End Property
#End Region

#Region "Construct and destruct"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Contructor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_enmSelectWaferResult = SelectWaferDialogResult.Invalid
        m_intCurrentSelectedWafer = -1
        Me.AddDragDropEvent(pnlGraph)
    End Sub
#End Region

#Region "Private method"

  
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Add label, check box to create graph of wafer
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddBars()
        Try
            If (m_arrBarStatus IsNot Nothing) Then
                Const LEFT_PADDING As Integer = 15
                Const BETWEEN_WAFER_PADDING As Integer = 40
                Const BETWEEN_WAFER_CHK_PADDING As Integer = 20
                Dim x As Integer = 0
                Dim y As Integer = 0
                Dim int_TimeToDraw As Integer = 0
                Dim arr As String() = Nothing
                ReDim Preserve m_arrWaferControl(m_arrBarStatus.Length - 1)
                ReDim Preserve m_arrWaferCheckBox(m_arrBarStatus.Length - 1)
                Dim ColorBrush As Color
                Dim brsBrush As SolidBrush = New SolidBrush(ColorBrush)
                Dim offset As Integer = 0
                Dim int_nextRow As Integer = 0
                Dim INT_NUM As Integer = 0
                Dim int_TOTALCOL As Integer = Math.Floor(m_arrBarStatus.Length / NUM_OF_WAFER_PER_COL)
                For i As Integer = 0 To (m_arrBarStatus.Length - 1)
                    Dim chkBar As New WaferCheckBox()
                    Dim wcWafer As New WaferControl()

                    If i Mod NUM_OF_WAFER_PER_COL = 0 Then
                        int_nextRow = NUM_OF_WAFER_PER_COL - 1
                        x = LEFT_PADDING + (i / NUM_OF_WAFER_PER_COL) * (WAFER_RADIUS + BETWEEN_WAFER_PADDING)
                        int_TimeToDraw += 1
                    Else
                        int_nextRow -= 1
                    End If
                    y = int_nextRow * (WAFER_RADIUS + 5) + 5
                    ' TEXT position
                    INT_NUM = i + 1

                    Dim strColor As String = String.Empty
                    wcWafer.BackColor = pnlGraph.BackColor
                    wcWafer.Text = INT_NUM
                    wcWafer.Size = New System.Drawing.Size(WAFER_RADIUS, WAFER_RADIUS)
                    wcWafer.SlotStatus = m_arrBarStatus(INT_NUM - 1)

                    AddHandler wcWafer.Click, AddressOf Label_Click
                    chkBar.ID = INT_NUM
                    AddHandler chkBar.Click, AddressOf CheckBox_Click

                    wcWafer.Location = New Point(x + BETWEEN_WAFER_CHK_PADDING, y)
                    chkBar.Location = New Point(x, y + BETWEEN_WAFER_CHK_PADDING)

                    m_arrWaferCheckBox(INT_NUM - 1) = chkBar
                    m_arrWaferControl(INT_NUM - 1) = wcWafer

                Next i
                pnlGraph.Controls.AddRange(m_arrWaferControl)
                pnlGraph.Controls.AddRange(m_arrWaferCheckBox)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Enable and disable group button
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetVisible(ByVal blnCreateWafer As Boolean, ByVal blnDeletewafer As Boolean, _
       ByVal blnSrcForMove As Boolean, ByVal blnDstForMove As Boolean)
        Try
            Dim hasSelfAlign As Boolean = IIf(RobotConfigurationValues.ALINER_VISIBLE, _
                                      ContainerForm.CassettesPanel.saSelfAligner.btnSelfAligner.Enabled, True)
            Me.btnCreateWafer.Enabled = blnCreateWafer
            Me.btnDeleteWafer.Enabled = blnDeletewafer
            Me.btnSrcForMove.Enabled = (blnSrcForMove AndAlso hasSelfAlign)
            Me.btnDstForMove.Enabled = (blnDstForMove AndAlso hasSelfAlign)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle state of all check boxs changed
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckStateChanged()
        Try
            Dim intCheckIndex As Integer = -1
            Dim intCheckCount As Integer = 0
            For i As Integer = 0 To (m_arrWaferCheckBox.Length - 1)
                If (m_arrWaferCheckBox(i).Checked = True) Then
                    intCheckCount += 1
                    intCheckIndex = i
                End If
            Next
            Select Case intCheckCount
                Case 0
                    Me.SetVisible(False, False, False, False)
                Case 1
                    If (m_arrBarStatus(intCheckIndex) = AVPLib.ConstEnum.enumWaferStatus.eWaferNone) Then
                        Me.SetVisible(True, False, False, True)
                    Else
                        Me.SetVisible(False, True, True, False)
                    End If
                Case Else
                    If (intCheckCount > 0) Then
                        Me.SetVisible(True, True, False, False)
                    End If
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Handle form load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SelectWaferForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cbcStatus.Items.Add(AVP_Robot_Project.WaferInfoDlg.WaferStatus.COMPLETE.ToString())
            cbcStatus.Items.Add(AVP_Robot_Project.WaferInfoDlg.WaferStatus.ERROR.ToString())
            cbcStatus.Items.Add(AVP_Robot_Project.WaferInfoDlg.WaferStatus.PARTIAL.ToString())
            cbcStatus.Items.Add(AVP_Robot_Project.WaferInfoDlg.WaferStatus.UNPROCESS.ToString())

            Me.SetVisible(False, False, False, False)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on wafer label box
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter Label_Click")
        Try
            Dim lblWaferLabelBox As WaferControl
            Dim i As Integer = 0
            lblWaferLabelBox = CType(sender, WaferControl)
            For Each item As WaferControl In m_arrWaferControl
                If item Is lblWaferLabelBox Then
                    Exit For
                Else
                    i += 1
                End If
            Next
            Dim chkWaferCheckBox As WaferCheckBox
            chkWaferCheckBox = CType(m_arrWaferCheckBox(i), WaferCheckBox)
            chkWaferCheckBox.Checked = Not chkWaferCheckBox.Checked
            CheckStateChanged()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Label_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on check box
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CheckBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter CheckBox_Click")
        Try
            CheckStateChanged()
            Dim chkWaferCheckBox As WaferCheckBox
            chkWaferCheckBox = CType(sender, WaferCheckBox)
            Dim strSource As String = "SelectWaferForm.CheckBox"
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CheckBox_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>     
    ''' <summary>
    ''' Handle click on button Select
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelection.Click
        AVPLib.Log.guiLogger.Info("Enter btnSelection_Click")
        Try
            Dim pos As New System.Drawing.Point(btnSelection.Location)
            pos.Y += btnSelection.Height
            pos = Me.PointToScreen(pos)
            cmsSelection.Show(pos)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnSelection_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on button close
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        AVPLib.Log.guiLogger.Info("Enter btnClose_Click")
        Try
            Me.Close()
            Dim strSource As String = "SelectWaferForm.Close"
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnClose_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on menu item Select All
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectAll.Click
        AVPLib.Log.guiLogger.Info("Enter mnuSelectAll_Click")
        Try
            For i As Integer = 0 To (m_arrWaferCheckBox.Length - 1)
                m_arrWaferCheckBox(i).Checked = True
            Next
            CheckStateChanged()
            Dim strSource As String = "SelectWaferForm.SelectAll"
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Select all wafer")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuSelectAll_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on menu item Clear all
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClearAll.Click
        AVPLib.Log.guiLogger.Info("Enter mnuClearAll_Click")
        Try
            For i As Integer = 0 To (m_arrWaferCheckBox.Length - 1)
                m_arrWaferCheckBox(i).Checked = False
            Next
            CheckStateChanged()
            Dim strSource As String = "SelectWaferForm.ClearAll"
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Clear all selected wafer")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuClearAll_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on menu item Select even
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuSelectEven_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectEven.Click
        AVPLib.Log.guiLogger.Info("Enter mnuSelectEven_Click")
        Try
            For i As Integer = 0 To (m_arrWaferCheckBox.Length - 1)
                If ((CInt(m_arrWaferCheckBox(i).ID) Mod 2) = 0) Then
                    m_arrWaferCheckBox(i).Checked = True
                Else
                    m_arrWaferCheckBox(i).Checked = False
                End If
            Next
            CheckStateChanged()
            Dim strSource As String = "SelectWaferForm.SelectEven"
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Select even wafer")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuSelectEven_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click event on menu item Select odd
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuSelectOdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectOdd.Click
        AVPLib.Log.guiLogger.Info("Enter mnuSelectOdd_Click")
        Try
            For i As Integer = 0 To (m_arrWaferCheckBox.Length - 1)
                If ((CInt(m_arrWaferCheckBox(i).ID) Mod 2) <> 0) Then
                    m_arrWaferCheckBox(i).Checked = True
                Else
                    m_arrWaferCheckBox(i).Checked = False
                End If
            Next
            CheckStateChanged()
            Dim strSource As String = "SelectWaferForm.SelectOdd"
            AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Select Odd wafer")
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave mnuSelectOdd_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on button create wafer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCreateWafer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateWafer.Click
        AVPLib.Log.guiLogger.Info("Enter btnCreateWafer_Click")
        Try
            Dim ListOfWaferInChamber As List(Of String) = CheckWaferInChamber()
            For i As Integer = 0 To (m_arrWaferCheckBox.Length - 1)
                Dim blnCreateWafer As Boolean = CheckWafer(i + 1, ListOfWaferInChamber)
                If (m_arrWaferCheckBox(i).Checked) And blnCreateWafer = False Then
                    If SemiautoTransferWaferPanel.txtDestination.Text.IndexOf("Slot " + (i + 1).ToString()) > -1 Then
                        SemiautoTransferWaferPanel.txtDestination.Clear()
                    End If
                    m_stoStatusObject.RequestStatus("CreateWafer", (i + 1).ToString())
                    m_arrWaferControl(i).SlotStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferNew
                    Dim strSource As String = "SelectWaferForm.CreateWafer"
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                                       AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                                       "[LoadLock " & Me.LockName & "] Create wafer at slot #" + (i + 1).ToString())

                End If
            Next
            If cbcStatus.SelectedItem IsNot Nothing Then
                ChangeWaferStatus()
            End If
            Me.Close()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnCreateWafer_Click")
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Check Wafer ID 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Function CheckWafer(ByVal i As Integer, ByVal listWaferInChamber As List(Of String)) As Boolean
        Try
            For Each WaferID As String In listWaferInChamber
                If WaferID.Contains(Me.LockName) Then
                    Dim id As Integer = CInt(WaferID.Replace(Me.LockName, ""))
                    If id = i Then
                        Return True
                    End If
                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return False
    End Function
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Check Wafer Available in Chamber -> return a list of Wafer ID
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Function CheckWaferInChamber() As List(Of String)
        ''Check Wafer in All Chamber
        Dim ListOfWaferInChamber As New List(Of String)
        Try
            Dim eqmEquiment As AVPLib.DataManagerment.Equipment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber1.ToString())
            If eqmEquiment IsNot Nothing Then
                For i As Int16 = 1 To eqmEquiment.NumberOfWafer
                    If eqmEquiment.GetWaferInfo(i) IsNot Nothing Then
                        ListOfWaferInChamber.Add(eqmEquiment.GetWaferInfo(i).WaferID)
                    End If
                Next
            End If

            eqmEquiment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber2.ToString())
            If eqmEquiment IsNot Nothing Then
                For i As Int16 = 1 To eqmEquiment.NumberOfWafer
                    If eqmEquiment.GetWaferInfo(i) IsNot Nothing Then
                        ListOfWaferInChamber.Add(eqmEquiment.GetWaferInfo(i).WaferID)
                    End If
                Next
            End If

            eqmEquiment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Chamber3.ToString())
            If eqmEquiment IsNot Nothing Then
                For i As Int16 = 1 To eqmEquiment.NumberOfWafer
                    If eqmEquiment.GetWaferInfo(i) IsNot Nothing Then
                        ListOfWaferInChamber.Add(eqmEquiment.GetWaferInfo(i).WaferID)
                    End If
                Next
            End If

            If Not String.IsNullOrEmpty(ContainerForm.CassettesPanel.TMAlignerControl.usrWaferInfo.txtWaferID.Text) Then
                ListOfWaferInChamber.Add(ContainerForm.CassettesPanel.TMAlignerControl.usrWaferInfo.txtWaferID.Text)
            End If
            'Use BackEnd Check Wafer Exist
            eqmEquiment = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.Robot.ToString())
            If eqmEquiment.GetWaferInfo() IsNot Nothing Then
                ListOfWaferInChamber.Add(eqmEquiment.GetWaferInfo().WaferID)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return ListOfWaferInChamber
    End Function
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on button delete wafer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDeleteWafer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteWafer.Click
        AVPLib.Log.guiLogger.Info("Enter btnDeleteWafer_Click")
        Try
            For i As Integer = 0 To (m_arrWaferCheckBox.Length - 1)
                If (m_arrWaferCheckBox(i).Checked) Then
                    If SemiautoTransferWaferPanel.txtSource.Text.IndexOf("Slot " + (i + 1).ToString()) > -1 Then
                        SemiautoTransferWaferPanel.txtSource.Clear()
                    End If
                    m_stoStatusObject.RequestStatus("DeleteWafer", (i + 1).ToString())

                    ''Trigger Event MaterialStatusStateChanged by Dat Cao
                    If (m_arrWaferControl(i).SlotStatus <> AVPLib.ConstEnum.enumWaferStatus.eWaferNone) Then
                        'trigger event 
                        Dim strLL As String = ConstEnum.LoadLockA_STR
                        UpdataAndTriggerEventInLoadlock(strLL, AVPLib.ConstEnum.enumWaferStatus.eWaferNone, m_arrBarStatus(i), i + 1)
                    End If

                    m_arrWaferControl(i).SlotStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferNone

                    Dim strSource As String = "SelectWaferForm.DeleteWafer"
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[LoadLock " & Me.LockName & "] Delete wafer at slot #" + (i + 1).ToString())
                End If
            Next
            Me.Close()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnDeleteWafer_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on button source for move
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSrcForMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSrcForMove.Click
        AVPLib.Log.guiLogger.Info("Enter btnSrcForMove_Click")
        Try
            For i As Integer = 0 To (m_arrWaferCheckBox.Length - 1)
                If (m_arrWaferCheckBox(i).Checked = True) Then
                    m_intCurrentSelectedWafer = CInt(m_arrWaferCheckBox(i).ID)
                    Dim strSource As String = "SelectWaferForm.SrcForMove"
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, ConstantAndEnum.TM_SCREEN & " - Select source for move. Slot #" + (i + 1).ToString())
                    Exit For
                End If
            Next
            m_enmSelectWaferResult = SelectWaferDialogResult.SourceForMove
            Me.Close()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnSrcForMove_Click")
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click on button destination for move
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDstForMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDstForMove.Click
        AVPLib.Log.guiLogger.Info("Enter btnDstForMove_Click")
        Try
            For i As Integer = 0 To (m_arrWaferCheckBox.Length - 1)
                If (m_arrWaferCheckBox(i).Checked = True) Then
                    m_intCurrentSelectedWafer = CInt(m_arrWaferCheckBox(i).ID)
                    Dim strSource As String = "SelectWaferForm.DstForMove"
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "Select destination for move. Slot #" + (i + 1).ToString())
                    Exit For
                End If
            Next
            m_enmSelectWaferResult = SelectWaferDialogResult.DestinationForMove
            Me.Close()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnDstForMove_Click")
    End Sub

    Private Sub cbcStatus_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbcStatus.SelectedValueChanged
        AVPLib.Log.guiLogger.Info("Enter cbcStatus_SelectedValueChanged")
        ChangeWaferStatus()
        AVPLib.Log.guiLogger.Info("Leave cbcStatus_SelectedValueChanged")
    End Sub

    Private Sub ChangeWaferStatus()
        Try
            Dim strLL As String = ConstEnum.LoadLockA_STR

            For i As Integer = 0 To (m_arrWaferCheckBox.Length - 1)

                If (m_arrWaferCheckBox(i).Checked = True) And _
                   Not (m_arrWaferControl(i).SlotStatus = ConstEnum.enumWaferStatus.eWaferNone) Then

                    If cbcStatus.SelectedItem.ToString() = AVP_Robot_Project.WaferInfoDlg.WaferStatus.COMPLETE.ToString() Then
                        m_stoStatusObject.RequestStatus("ChangeWaferStatus", _
                                     (i).ToString() & "#" & AVPLib.ConstEnum.enumWaferStatus.eWaferComplete.ToString())

                        'Trigger Event MaterialStatusStateChanged by Dat Cao
                        If (m_arrBarStatus(i) <> AVPLib.ConstEnum.enumWaferStatus.eWaferComplete) Then
                            UpdataAndTriggerEventInLoadlock(strLL, AVPLib.ConstEnum.enumWaferStatus.eWaferComplete, m_arrBarStatus(i), i + 1)
                        End If

                        m_arrBarStatus(i) = AVPLib.ConstEnum.enumWaferStatus.eWaferComplete
                        m_arrWaferControl(i).SlotStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferComplete
                        m_arrWaferControl(i).Refresh()

                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen _
                                                          , "Change Wafer Status. Slot #" & Me.LockName & (i + 1).ToString() & _
                                                          " to " & AVP_Robot_Project.WaferInfoDlg.WaferStatus.COMPLETE.ToString())

                    ElseIf cbcStatus.SelectedItem.ToString() = AVP_Robot_Project.WaferInfoDlg.WaferStatus.PARTIAL.ToString() Then
                        m_stoStatusObject.RequestStatus("ChangeWaferStatus", _
                                     (i).ToString() & "#" & AVPLib.ConstEnum.enumWaferStatus.eWaferExposed.ToString())

                        'Trigger Event MaterialStatusStateChanged by Dat Cao
                        If (m_arrBarStatus(i) <> AVPLib.ConstEnum.enumWaferStatus.eWaferExposed) Then
                            UpdataAndTriggerEventInLoadlock(strLL, AVPLib.ConstEnum.enumWaferStatus.eWaferExposed, m_arrBarStatus(i), i + 1)
                        End If

                        m_arrBarStatus(i) = AVPLib.ConstEnum.enumWaferStatus.eWaferExposed
                        m_arrWaferControl(i).SlotStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferExposed
                        m_arrWaferControl(i).Refresh()
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen _
                                                           , "Change Wafer Status. Slot #" & Me.LockName & (i + 1).ToString() & _
                                                           " to " & AVP_Robot_Project.WaferInfoDlg.WaferStatus.PARTIAL.ToString())

                    ElseIf cbcStatus.SelectedItem.ToString() = AVP_Robot_Project.WaferInfoDlg.WaferStatus.UNPROCESS.ToString() Then
                        m_stoStatusObject.RequestStatus("ChangeWaferStatus", _
                                     (i).ToString() & "#" & AVPLib.ConstEnum.enumWaferStatus.eWaferNew.ToString())

                        'Trigger Event MaterialStatusStateChanged by Dat Cao
                        If (m_arrBarStatus(i) <> AVPLib.ConstEnum.enumWaferStatus.eWaferNew) Then
                            UpdataAndTriggerEventInLoadlock(strLL, AVPLib.ConstEnum.enumWaferStatus.eWaferNew, m_arrBarStatus(i), i + 1)
                        End If

                        m_arrBarStatus(i) = AVPLib.ConstEnum.enumWaferStatus.eWaferNew
                        m_arrWaferControl(i).SlotStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferNew
                        m_arrWaferControl(i).Refresh()
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen _
                                                          , "Change Wafer Status. Slot #" & Me.LockName & (i + 1).ToString() & _
                                                           " to " & AVP_Robot_Project.WaferInfoDlg.WaferStatus.UNPROCESS.ToString())

                    ElseIf cbcStatus.SelectedItem.ToString() = AVP_Robot_Project.WaferInfoDlg.WaferStatus.ERROR.ToString() Then
                        m_stoStatusObject.RequestStatus("ChangeWaferStatus", _
                                     (i).ToString() & "#" & AVPLib.ConstEnum.enumWaferStatus.eWaferError.ToString())

                        'Trigger Event MaterialStatusStateChanged by Dat Cao
                        If (m_arrBarStatus(i) <> AVPLib.ConstEnum.enumWaferStatus.eWaferError) Then
                            UpdataAndTriggerEventInLoadlock(strLL, AVPLib.ConstEnum.enumWaferStatus.eWaferError, m_arrBarStatus(i), i + 1)
                        End If

                        m_arrBarStatus(i) = AVPLib.ConstEnum.enumWaferStatus.eWaferError
                        m_arrWaferControl(i).SlotStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferError
                        m_arrWaferControl(i).Refresh()
                        AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen _
                                                           , "Change Wafer Status. Slot #" & Me.LockName & (i + 1).ToString() & _
                                                          " to " & AVP_Robot_Project.WaferInfoDlg.WaferStatus.ERROR.ToString())
                    End If


                End If
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    Private Sub UpdataAndTriggerEventInLoadlock(ByVal LLName As String, _
                                        ByVal CurrentWaferStatus As AVPLib.ConstEnum.enumWaferStatus, _
                                        ByVal PriviousWaferStatus As AVPLib.ConstEnum.enumWaferStatus, ByVal Pos As Integer)

        AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(LLName, EMSERVICELib.VarType.SV, _
"MaterialStatusState" & Pos.ToString(), VALUELib.ValueType.U1, CurrentWaferStatus)

        AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(LLName, EMSERVICELib.VarType.SV, _
        "PreviousMaterialStatusState" & Pos.ToString(), VALUELib.ValueType.U1, PriviousWaferStatus)

        'trigger event 
        Business.AVPSecsGemLib.TriggerEvent(LLName, "MaterialStatusStateChanged" & Pos.ToString())
    End Sub

#End Region

End Class