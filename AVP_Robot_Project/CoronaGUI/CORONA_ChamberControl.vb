Imports AVP_Robot_Project.ConstantAndEnum
Imports System.ComponentModel
Imports AVPLib.DataManagerment

Public Class CoronaChamberControl

#Region "Properties & Constant"
    Private m_NumberOfWafer As Integer = 8
    Private lstWafer As List(Of CoronaWafer) = New List(Of CoronaWafer)
    Private m_intCurrentPosition As Integer = 1
    Private m_CurrentPos As Point = Nothing
    Private m_lstWaferPosition As New List(Of Point)
    Private y(m_NumberOfWafer - 1) As Integer
    Private x(m_NumberOfWafer - 1) As Integer
    Const PADDING_SPACE_WHEN_TABLE_UP_DOWN As Integer = 20
    Public Event StatusChange(ByVal sender As Object, ByVal e As EventArgs)

    Public Property Shutter1Status() As BinaryStatusControl.DisplayStatus
        Get
            Return Shutter1.Status
        End Get
        Set(ByVal value As BinaryStatusControl.DisplayStatus)
            Shutter1.Status = value
        End Set
    End Property

    Public Property Shutter2Status() As BinaryStatusControl.DisplayStatus
        Get
            Return Shutter2.Status
        End Get
        Set(ByVal value As BinaryStatusControl.DisplayStatus)
            Shutter2.Status = value
        End Set
    End Property

    Public Property Shutter3Status() As BinaryStatusControl.DisplayStatus
        Get
            Return Shutter3.Status
        End Get
        Set(ByVal value As BinaryStatusControl.DisplayStatus)
            Shutter3.Status = value
        End Set
    End Property

    Public Property Shutter4Status() As BinaryStatusControl.DisplayStatus
        Get
            Return Shutter4.Status
        End Get
        Set(ByVal value As BinaryStatusControl.DisplayStatus)
            Shutter4.Status = value
        End Set
    End Property

    Public WriteOnly Property Shutter1Visible() As Boolean
        Set(ByVal value As Boolean)
            Shutter1.Visible = value
        End Set
    End Property
    Public WriteOnly Property Shutter2Visible() As Boolean
        Set(ByVal value As Boolean)
            Shutter2.Visible = value
        End Set
    End Property
    Public WriteOnly Property Shutter3Visible() As Boolean
        Set(ByVal value As Boolean)
            Shutter3.Visible = value
        End Set
    End Property
    Public WriteOnly Property Shutter4Visible() As Boolean
        Set(ByVal value As Boolean)
            Shutter4.Visible = value
        End Set
    End Property

    'this property is non browsable
    '<System.ComponentModel.Browsable(False), System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property NumberOfWafer() As Integer
        Get
            Return m_NumberOfWafer
        End Get
        Set(ByVal value As Integer)
            Dim isChange As Boolean = (m_NumberOfWafer <> value)
            m_NumberOfWafer = value
            If m_NumberOfWafer > 8 Or m_NumberOfWafer < 1 Then
                m_NumberOfWafer = 8 'set default
            End If
            CalculateWaferPosition()
            If (isChange) Then
                Me.Refresh()
            End If
        End Set
    End Property

    Public Property CurrentPosition() As Integer
        Get
            Return m_intCurrentPosition
        End Get
        Set(ByVal value As Integer)
            If value > m_NumberOfWafer Or value < 1 Then
                value = m_NumberOfWafer - 1
            End If
            m_intCurrentPosition = value
            Timer1.Enabled = True
        End Set
    End Property

    Public Property Slot1Status() As DisplayStatus
        Get
            Return Wafer1.Status
        End Get
        Set(ByVal value As DisplayStatus)
            Wafer1.Status = value
        End Set
    End Property

    Public Property Slot2Status() As DisplayStatus
        Get
            Return Wafer2.Status
        End Get
        Set(ByVal value As DisplayStatus)
            Wafer2.Status = value
        End Set
    End Property

    Public Property Slot3Status() As DisplayStatus
        Get
            Return Wafer3.Status
        End Get
        Set(ByVal value As DisplayStatus)
            Wafer3.Status = value
        End Set
    End Property

    Public Property Slot4Status() As DisplayStatus
        Get
            Return Wafer4.Status
        End Get
        Set(ByVal value As DisplayStatus)
            Wafer4.Status = value
        End Set
    End Property

    Public Property Slot5Status() As DisplayStatus
        Get
            Return Wafer5.Status
        End Get
        Set(ByVal value As DisplayStatus)
            Wafer5.Status = value
        End Set
    End Property

    Public Property Slot6Status() As DisplayStatus
        Get
            Return Wafer6.Status
        End Get
        Set(ByVal value As DisplayStatus)
            Wafer6.Status = value
        End Set
    End Property

    Public Property Slot7Status() As DisplayStatus
        Get
            Return Wafer7.Status
        End Get
        Set(ByVal value As DisplayStatus)
            Wafer7.Status = value
        End Set
    End Property

    Public Property Slot8Status() As DisplayStatus
        Get
            Return Wafer8.Status
        End Get
        Set(ByVal value As DisplayStatus)
            Wafer8.Status = value
        End Set
    End Property

    Public WriteOnly Property SlotxStatus(ByVal x As Byte) As DisplayStatus
        Set(ByVal value As DisplayStatus)
            Select Case x
                Case 1
                    Slot1Status() = value
                Case 2
                    Slot2Status() = value
                Case 3
                    Slot3Status() = value
                Case 4
                    Slot4Status() = value
                Case 5
                    Slot5Status() = value
                Case 6
                    Slot6Status() = value
                Case 7
                    Slot7Status() = value
                Case 8
                    Slot8Status() = value
            End Select
        End Set
    End Property

    Public WriteOnly Property SlotxWaferID(ByVal x As Byte) As String
        Set(ByVal value As String)
            Select Case x
                Case 1
                    Wafer1.NoneText = value
                    Wafer1.OnText = value
                    Wafer1.OffText = value
                    Wafer1.UnKnownText = value
                    Wafer1.ErrorText = value
                Case 2
                    Wafer2.NoneText = value
                    Wafer2.OnText = value
                    Wafer2.OffText = value
                    Wafer2.UnKnownText = value
                    Wafer2.ErrorText = value
                Case 3
                    Wafer3.NoneText = value
                    Wafer3.OnText = value
                    Wafer3.OffText = value
                    Wafer3.UnKnownText = value
                    Wafer3.ErrorText = value
                Case 4
                    Wafer4.NoneText = value
                    Wafer4.OnText = value
                    Wafer4.OffText = value
                    Wafer4.UnKnownText = value
                    Wafer4.ErrorText = value
                Case 5
                    Wafer5.NoneText = value
                    Wafer5.OnText = value
                    Wafer5.OffText = value
                    Wafer5.UnKnownText = value
                    Wafer5.ErrorText = value
                Case 6
                    Wafer6.NoneText = value
                    Wafer6.OnText = value
                    Wafer6.OffText = value
                    Wafer6.UnKnownText = value
                    Wafer6.ErrorText = value
                Case 7
                    Wafer7.NoneText = value
                    Wafer7.OnText = value
                    Wafer7.OffText = value
                    Wafer7.UnKnownText = value
                    Wafer7.ErrorText = value
                Case 8
                    Wafer8.NoneText = value
                    Wafer8.OnText = value
                    Wafer8.OffText = value
                    Wafer8.UnKnownText = value
                    Wafer8.ErrorText = value
            End Select
        End Set
    End Property


    'only call when table up/down,number of wafer changes
    Private Sub CalculateWaferPosition()
        Dim PosForEachWafer As Integer = 0
        Dim Wafer_Radix As Integer = 57
        For Each obj As CoronaWafer In lstWafer
            obj.Visible = False
        Next

        Select Case NumberOfWafer
            Case 1
                PosForEachWafer = 1
                y(0) = 154
                x(0) = 170
            Case 2
                PosForEachWafer = 100
                y(0) = 145
                y(1) = 145
                x(0) = 83
                x(1) = x(0) + Wafer_Radix + PosForEachWafer
            Case 3
                PosForEachWafer = 50
                y(0) = 155
                y(2) = 140
                y(1) = 155

                x(0) = 65
                x(2) = x(0) + Wafer_Radix + PosForEachWafer
                x(1) = x(2) + Wafer_Radix + PosForEachWafer

            Case 4
                PosForEachWafer = 50
                y(2) = 165
                y(1) = 165
                y(0) = 140
                y(3) = 140

                x(1) = 140
                x(2) = x(1) + Wafer_Radix + PosForEachWafer
                x(0) = 83 '140
                x(3) = x(0) + Wafer_Radix + PosForEachWafer

            Case 5
                PosForEachWafer = 43
                y(0) = 146
                y(4) = 140
                y(3) = 146
                y(2) = 165
                y(1) = 165

                x(0) = 74
                x(4) = x(0) + Wafer_Radix + PosForEachWafer
                x(3) = x(4) + Wafer_Radix + PosForEachWafer
                x(1) = 127
                x(2) = x(1) + Wafer_Radix + PosForEachWafer - 5

            Case 6
                PosForEachWafer = 10

                y(0) = 151
                y(3) = y(0) '165

                y(1) = 165
                y(2) = 165

                y(4) = 140
                y(5) = 140

                x(0) = 70
                x(5) = x(0) + Wafer_Radix + PosForEachWafer
                x(1) = x(5)

                x(4) = x(5) + Wafer_Radix + PosForEachWafer
                x(2) = x(4)

                x(3) = x(4) + Wafer_Radix + PosForEachWafer


            Case 7
                PosForEachWafer = 5
                y(0) = 151

                y(5) = 140
                y(6) = 140

                y(4) = 140

                y(1) = 165
                y(2) = 165
                y(3) = 165

                x(0) = 62
                x(1) = x(0) + Wafer_Radix + PosForEachWafer
                x(2) = x(1) + Wafer_Radix + PosForEachWafer
                x(3) = x(2) + Wafer_Radix + PosForEachWafer

                x(6) = x(0) + Wafer_Radix + PosForEachWafer + 3
                x(5) = x(6) + Wafer_Radix + PosForEachWafer
                x(4) = x(5) + Wafer_Radix + PosForEachWafer

            Case 8
                PosForEachWafer = 1
                y(0) = 151

                y(5) = 140
                y(6) = 140
                y(7) = 140

                y(4) = 151

                y(1) = 165
                y(2) = 165
                y(3) = 165

                x(0) = 52
                x(7) = x(0) + Wafer_Radix + PosForEachWafer
                x(6) = x(7) + Wafer_Radix + PosForEachWafer
                x(5) = x(6) + Wafer_Radix + PosForEachWafer

                x(4) = x(5) + Wafer_Radix + PosForEachWafer

                x(3) = x(5)
                x(2) = x(6)
                x(1) = x(7)
        End Select

        For i As Integer = 0 To NumberOfWafer - 1
            If Not IsTableHome Then
                lstWafer.Item(i).Location = New Point(x(i), y(i))
            Else
                lstWafer.Item(i).Location = New Point(x(i), y(i) + PADDING_SPACE_WHEN_TABLE_UP_DOWN)
            End If
            lstWafer.Item(i).Visible = True
        Next
        m_CurrentPos = New Point(x(0), y(0))
    End Sub

    Private m_IsTableHome As Boolean = False
    Public Property IsTableHome() As Boolean
        Get
            Return m_IsTableHome
        End Get
        Set(ByVal value As Boolean)
            If m_IsTableHome <> value Then
                m_IsTableHome = value
                If Not m_IsTableHome Then
                    If m_biasPlasmaOn Then
                        Me.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.Chamber_Table_Up_Plasma
                    Else
                        Me.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.Chamber_Table_Up
                    End If
                Else
                    If m_biasPlasmaOn Then
                        Me.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.Chamber_Table_Down_Plasma
                    Else
                        Me.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.Chamber_Table_Down
                    End If
                End If
                RaiseEvent StatusChange(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    Private m_biasPlasmaOn As Boolean = False
    Public Property BiasPlasmaOn() As Boolean
        Get
            Return m_biasPlasmaOn
        End Get
        Set(ByVal value As Boolean)
            If m_biasPlasmaOn <> value Then
                m_biasPlasmaOn = value
                If m_biasPlasmaOn Then
                    If Not m_IsTableHome Then
                        Me.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.Chamber_Table_Up_Plasma
                    Else
                        Me.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.Chamber_Table_Down_Plasma
                    End If
                Else
                    If Not m_IsTableHome Then
                        Me.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.Chamber_Table_Up
                    Else
                        Me.BackgroundImage = AVP_Robot_Project.My.Resources.Resources.Chamber_Table_Down
                    End If
                End If
                RaiseEvent StatusChange(Me, EventArgs.Empty)
            End If
        End Set
    End Property
#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2009-12-15</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            MyBase.CreateStatusTree()
            Dim sShutter1 As New SL_StatusValve(Shutter1)
            Dim sShutter2 As New SL_StatusValve(Shutter2)
            Dim sShutter3 As New SL_StatusValve(Shutter3)
            Dim sShutter4 As New SL_StatusValve(Shutter4)
            Dim sSlitValve As New SL_StatusValve(btnMesaValve)

            Dim sWafer1 As New StatusCoronaWafer(Wafer1)
            Dim sWafer2 As New StatusCoronaWafer(Wafer2)
            Dim sWafer3 As New StatusCoronaWafer(Wafer3)
            Dim sWafer4 As New StatusCoronaWafer(Wafer4)
            Dim sWafer5 As New StatusCoronaWafer(Wafer5)
            Dim sWafer6 As New StatusCoronaWafer(Wafer6)
            Dim sWafer7 As New StatusCoronaWafer(Wafer7)
            Dim sWafer8 As New StatusCoronaWafer(Wafer8)


            m_stoStatusObject.AddChild(sWafer1)
            m_stoStatusObject.AddChild(sWafer2)
            m_stoStatusObject.AddChild(sWafer3)
            m_stoStatusObject.AddChild(sWafer4)
            m_stoStatusObject.AddChild(sWafer5)
            m_stoStatusObject.AddChild(sWafer6)
            m_stoStatusObject.AddChild(sWafer7)
            m_stoStatusObject.AddChild(sWafer8)
            m_stoStatusObject.AddChild(sShutter1)
            m_stoStatusObject.AddChild(sShutter2)
            m_stoStatusObject.AddChild(sShutter3)
            m_stoStatusObject.AddChild(sShutter4)
            m_stoStatusObject.AddChild(sSlitValve)
            
            Shutter1.ParentStatusObj = m_stoStatusObject
            Shutter2.ParentStatusObj = m_stoStatusObject
            Shutter3.ParentStatusObj = m_stoStatusObject
            Shutter4.ParentStatusObj = m_stoStatusObject
            btnMesaValve.ParentStatusObj = m_stoStatusObject


        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub

    Protected Sub Timer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)

    End Sub

    Public Sub SetOnlineOfflineContainerBox(ByVal blnIsOnline As Boolean)
        
        Shutter1.Enabled = Not blnIsOnline
        Shutter2.Enabled = Not blnIsOnline
        Shutter3.Enabled = Not blnIsOnline
        Shutter4.Enabled = Not blnIsOnline
        btnMesaValve.Enabled = Not blnIsOnline
        Wafer1.Enabled = Not blnIsOnline
        Wafer2.Enabled = Not blnIsOnline
        Wafer3.Enabled = Not blnIsOnline
        Wafer4.Enabled = Not blnIsOnline
        Wafer5.Enabled = Not blnIsOnline
        Wafer6.Enabled = Not blnIsOnline
        Wafer7.Enabled = Not blnIsOnline
        Wafer8.Enabled = Not blnIsOnline
    End Sub

#End Region

#Region "Events – Buttons – Forms…"

    Private Sub txtWaterPump_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If String.IsNullOrEmpty(Me.Parent.Name) = False Then
                Dim objCoronaPanel As CoronaPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                objCoronaPanel.CryoPopUpPanel.StartPosition = FormStartPosition.CenterScreen
                objCoronaPanel.CryoPopUpPanel.ShowDialog(AVPRobotMain)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnCtxMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtxMenu.Click
        Try
            Dim CoronaParent As CoronaPanel = ContainerForm.ChamberPanel(Me.Parent.Name) ''must be Corona Panel
            If CoronaParent Is Nothing Then
                Exit Sub
            End If

            If CoronaParent IsNot Nothing Then
                CoronaParent.PopUpPanel.StartPosition = FormStartPosition.CenterScreen
                CoronaParent.PopUpPanel.ShowDialog(CoronaParent)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region
    Public Sub SetWaferUpDown()
        Try
            If AVPLib.System_Init_Indicator.IsMainFormInitialize Then
                For i As Integer = 0 To NumberOfWafer - 1
                    If IsTableHome Then 'up->down
                        lstWafer.Item(i).Location = New Point(lstWafer.Item(i).Location.X, lstWafer.Item(i).Location.Y + PADDING_SPACE_WHEN_TABLE_UP_DOWN)
                    Else
                        lstWafer.Item(i).Location = New Point(lstWafer.Item(i).Location.X, lstWafer.Item(i).Location.Y - PADDING_SPACE_WHEN_TABLE_UP_DOWN)
                    End If
                Next
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lstWafer.Add(Wafer1)
        lstWafer.Add(Wafer2)
        lstWafer.Add(Wafer3)
        lstWafer.Add(Wafer4)
        lstWafer.Add(Wafer5)
        lstWafer.Add(Wafer6)
        lstWafer.Add(Wafer7)
        lstWafer.Add(Wafer8)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim xyTemp As Point = Nothing
            If IsTableHome = True AndAlso lstWafer.Item(m_intCurrentPosition - 1).Location.X = m_CurrentPos.X _
            AndAlso lstWafer.Item(m_intCurrentPosition - 1).Location.Y = m_CurrentPos.Y + PADDING_SPACE_WHEN_TABLE_UP_DOWN Then
                Timer1.Enabled = False
                Exit Sub
            ElseIf (lstWafer.Item(m_intCurrentPosition - 1).Location.X = m_CurrentPos.X AndAlso _
                  lstWafer.Item(m_intCurrentPosition - 1).Location.Y = m_CurrentPos.Y) Then
                Timer1.Enabled = False
                Exit Sub
            End If

            xyTemp = New Point(x(m_NumberOfWafer - 1), y(m_NumberOfWafer - 1))
            For i As Integer = m_NumberOfWafer - 1 To 1 Step -1
                x(i) = x(i - 1)
                y(i) = y(i - 1)
                If i = 1 Then
                    x(0) = xyTemp.X
                    y(0) = xyTemp.Y
                    Exit For
                End If
            Next
            For i As Integer = 0 To NumberOfWafer - 1
                If Not IsTableHome Then
                    lstWafer.Item(i).Location = New Point(x(i), y(i))
                Else
                    lstWafer.Item(i).Location = New Point(x(i), y(i) + PADDING_SPACE_WHEN_TABLE_UP_DOWN)
                End If
            Next
            'Me.Refresh()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub



    Private Sub Wafer1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    Wafer1.Click, Wafer2.Click, Wafer3.Click, Wafer4.Click, Wafer5.Click, Wafer6.Click, Wafer7.Click, Wafer8.Click
        Dim chamberName As String = Me.Parent.Name

        Dim equipment As AVPLib.DataManagerment.Chamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(chamberName)
        If equipment IsNot Nothing Then
            Dim waferInfo As AVPLib.AVPWaferInfo = Nothing
            Dim slot As Byte = 0
            Select Case sender.Name.ToString
                Case "Wafer1"
                    waferInfo = equipment.GetWaferInfo(1)
                    slot = 1
                Case "Wafer2"
                    waferInfo = equipment.GetWaferInfo(2)
                    slot = 2
                Case "Wafer3"
                    waferInfo = equipment.GetWaferInfo(3)
                    slot = 3
                Case "Wafer4"
                    waferInfo = equipment.GetWaferInfo(4)
                    slot = 4
                Case "Wafer5"
                    waferInfo = equipment.GetWaferInfo(5)
                    slot = 5
                Case "Wafer6"
                    waferInfo = equipment.GetWaferInfo(6)
                    slot = 6
                Case "Wafer7"
                    waferInfo = equipment.GetWaferInfo(7)
                    slot = 7
                Case "Wafer8"
                    waferInfo = equipment.GetWaferInfo(8)
                    slot = 8
            End Select
            If waferInfo Is Nothing Then
                Exit Sub
            End If
            ' Create wafer dialog
            Dim updateWafer As WaferInfoDlg = New WaferInfoDlg(slot, waferInfo, True)
            'updateWafer.ShowDialog()
            If (updateWafer.ShowDialog() = DialogResult.OK) Then
                'update the wafer infomation for the chamber
                Dim ChamberIndex As String = chamberName.Replace(ConstantAndEnum.CHAMBER, "")
                If (ChamberIndex <> String.Empty) Then
                    ContainerForm.CassettesPanel.SetWaferInside(True, BinaryStatusControl.DisplayStatus.On, waferInfo, ChamberIndex, slot)
                End If
            End If
        End If
    End Sub
    ''' <author>
    '''    	<name>Dy Do </name>
    '''    	<date> 2015-04-22</date>
    ''' </author>
    ''' <summary>
    ''' Paint ForeLineValve GasLine
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub CoronaChamberControl_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Try
            Dim CoronaParent As CoronaPanel = ContainerForm.ChamberPanel(Me.Parent.Name) ''must be Corona Panel
            If CoronaParent Is Nothing Then
                Exit Sub
            End If
            CoronaParent.ValveForelineLine.Refresh()
            CoronaParent.TotalGas.Refresh()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-06-22 </date>
    ''' </author>
    ''' <summary>
    ''' Update plasma status to PMControl
    ''' </summary>
    ''' <value></value>
    Private m_isBiasPlasmaOn As Boolean = False
    Private Sub btnBiasPlasmaStatus_StatusChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBiasPlasmaStatus.StatusChange
        Try
            Dim plasmaOn As Boolean = (btnBiasPlasmaStatus.Status = SL_CustomButton.DisplayStatus.On)
            If m_isBiasPlasmaOn <> plasmaOn Then
                m_isBiasPlasmaOn = plasmaOn
                Dim objPMProcess As PMControl = Nothing
                Dim objPMCassette As PMControl = Nothing
                AVPRobotMain.GetPMControl(Me.Parent.Name, objPMProcess, objPMCassette)
                If objPMProcess IsNot Nothing AndAlso objPMCassette IsNot Nothing Then
                    objPMProcess.PlasmaIsOn = plasmaOn
                    objPMCassette.PlasmaIsOn = plasmaOn

                    objPMProcess.Repaint()
                    objPMCassette.Repaint()
                End If
                BiasPlasmaOn = plasmaOn
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
