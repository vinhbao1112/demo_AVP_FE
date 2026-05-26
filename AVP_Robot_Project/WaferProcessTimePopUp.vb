Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib

Public Class WaferProcessTimePopUp

#Region "Class Constants & Variables"
    Private Const BOTTOMMAGRIN As Integer = 5
    Private Const BANK_WIDTH As Integer = 262
    Const WAFER_RADIUS As Integer = 40
    Private Const SPACE_BTW_WAFER As Integer = 15
    Private Const NUM_OF_WAFER_PER_COL As Integer = 6

    Private m_arrWaferControl As Label()
    Private m_arrWaferLabel As Label()
    Private m_arrUnitLabel As Label()
    Private m_arrBoderVerticalLable1 As Label()
    Private m_arrBoderVerticalLable2 As Label()
    Private m_arrBoderVerticalLable3 As Label()
    Private m_arrBoderHorizontalLable1 As Label()
    Private m_arrBoderHorizontalLable2 As Label()

    Private m_LoadLockID As String

    Private mouseOffset As Point = New Point(0, 0)
    Private isDragDrop As Boolean = False

    Private m_iClosingTime As Integer = 30
    Private m_timer As System.Timers.Timer
    Private m_TextGraphics As Graphics
    Private m_sf As StringFormat = Nothing
#End Region

#Region "properties"
    ''' <author>
    '''    	<name> Truc Le </name>
    '''    	<date> 2009-01-13</date>
    ''' </author>
    ''' <summary>
    ''' Get or set Lock Name
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LoadLockID() As String
        Get
            Return m_LoadLockID
        End Get
        Set(ByVal value As String)
            m_LoadLockID = value
            If value = ConstEnum.Equipments.LoadLockA.ToString() Then
                Me.Text = "LLA - Wafer Processed Time (Secs)"
            End If
            AddWaferProcessTime()
        End Set
    End Property

#End Region

#Region "Construct and destruct"
    ''' <author>
    '''    	<name> Truc Le </name>
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
        m_timer = New System.Timers.Timer
        m_timer.Interval = 1000 '1second
        m_timer.Enabled = False
        m_timer.SynchronizingObject = Me
        AddHandler m_timer.Elapsed, AddressOf TimerClosingForm

        m_sf = New StringFormat(StringFormatFlags.NoWrap)
        m_sf.LineAlignment = StringAlignment.Center
        m_sf.Alignment = StringAlignment.Near
        m_sf.Trimming = StringTrimming.EllipsisCharacter

    End Sub
#End Region

#Region "Private method"


    ''' <author>
    '''    	<name> Truc Le </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Add label, check box to create graph of wafer
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub AddWaferProcessTime()
        Try
            Dim objLoadLockElevator As AVPLib.DataManagerment.LLElevator = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())
            
            If objLoadLockElevator IsNot Nothing Then
                Const BETWEEN_WAFER_PADDING As Integer = 60
                Const BETWEEN_WAFER_CHK_PADDING As Integer = 10
                Const LABEL_WIDTH As Integer = 60
                Dim x As Integer = 0
                Dim y As Integer = 0
                Dim int_TimeToDraw As Integer = 0
                Dim arr As String() = Nothing

                ReDim Preserve m_arrWaferControl(objLoadLockElevator.ListOfWaferInfo.Length - 1)
                ReDim Preserve m_arrWaferLabel(objLoadLockElevator.ListOfWaferInfo.Length - 1)
                ReDim Preserve m_arrUnitLabel(objLoadLockElevator.ListOfWaferInfo.Length - 1)
                ReDim Preserve m_arrBoderVerticalLable1(objLoadLockElevator.ListOfWaferInfo.Length - 1)
                ReDim Preserve m_arrBoderVerticalLable2(objLoadLockElevator.ListOfWaferInfo.Length - 1)
                ReDim Preserve m_arrBoderVerticalLable3(objLoadLockElevator.ListOfWaferInfo.Length - 1)
                ReDim Preserve m_arrBoderHorizontalLable1(objLoadLockElevator.ListOfWaferInfo.Length - 1)
                ReDim Preserve m_arrBoderHorizontalLable2(objLoadLockElevator.ListOfWaferInfo.Length - 1)

                Dim ColorBrush As Color
                Dim brsBrush As SolidBrush = New SolidBrush(ColorBrush)
                Dim offset As Integer = 0
                Dim int_nextRow As Integer = 0
                Dim INT_NUM As Integer = 0
                Dim int_TOTALCOL As Integer = Math.Floor(objLoadLockElevator.ListOfWaferInfo.Length / NUM_OF_WAFER_PER_COL)
                Dim numColumn As Integer = 0

                If objLoadLockElevator.ListOfWaferInfo.Length Mod 6 = 0 Then
                    numColumn = objLoadLockElevator.ListOfWaferInfo.Length / 6
                Else
                    numColumn = (objLoadLockElevator.ListOfWaferInfo.Length / 6) + 1
                End If
                Me.Size = New Size(numColumn * 225, 390)
                For i As Integer = 0 To (objLoadLockElevator.ListOfWaferInfo.Length - 1)
                    Dim lblTotalProcessTime As New Label()
                    Dim lblWafer As New Label()
                    Dim lblBoderVertical1 As New Label()
                    Dim lblBoderVertical2 As New Label()
                    Dim lblBoderVertical3 As New Label()
                    Dim lblBoderHorizontal1 As New Label()
                    Dim lblBoderHorizontal2 As New Label()
                    Dim strWaferID As String = String.Empty
                    Dim strDefineWaferID As String = String.Empty

                    If i Mod NUM_OF_WAFER_PER_COL = 0 Then
                        int_nextRow = NUM_OF_WAFER_PER_COL - 1
                        x = (i / NUM_OF_WAFER_PER_COL) * (BETWEEN_WAFER_PADDING * 2 + 100)
                        int_TimeToDraw += 1
                    Else
                        int_nextRow -= 1
                    End If
                    y = int_nextRow * (WAFER_RADIUS + 15) + 15
                    ' TEXT position
                    INT_NUM = i + 1

                    strWaferID = Me.m_LoadLockID.Replace(ConstEnum.LoadLock, "") & IIf(INT_NUM.ToString().Length = 1, "0" & INT_NUM, INT_NUM)
                    If objLoadLockElevator.MappingGEMWaferID.Count > 0 Then
                        Dim gemWaferID As String = objLoadLockElevator.MappingGEMWaferID.Item(strWaferID)
                        If Not String.IsNullOrEmpty(gemWaferID) AndAlso strWaferID <> gemWaferID Then
                            strDefineWaferID = String.Format("{0}({1})", strWaferID, gemWaferID)
                        End If
                    End If
                    With lblWafer
                        .Text = IIf(String.IsNullOrEmpty(strDefineWaferID), strWaferID, strDefineWaferID)
                        .Tag = strWaferID
                        .Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        .AutoSize = False
                        .Width = LABEL_WIDTH + 50
                        .Visible = True
                        .BorderStyle = BorderStyle.None
                        .ForeColor = Color.Black
                        .TextAlign = ContentAlignment.MiddleCenter
                    End With
                    updateTextLength(lblWafer)

                    With lblTotalProcessTime
                        .Text = ""
                        .Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        .AutoSize = False
                        .Width = LABEL_WIDTH + 20
                        .Visible = True
                        .BackColor = Color.FromArgb(224, 221, 212)
                        .BorderStyle = BorderStyle.None
                        .TextAlign = ContentAlignment.MiddleCenter
                    End With

                    With lblBoderVertical1
                        .Text = ""
                        .AutoSize = False
                        .Visible = True
                        .Width = 1
                        .Height = lblWafer.Height
                        .BackColor = Color.White
                        .ForeColor = Color.White
                    End With

                    With lblBoderVertical2
                        .Text = ""
                        .AutoSize = False
                        .Visible = True
                        .Width = 1
                        .Height = lblWafer.Height
                        .BackColor = Color.White
                        .ForeColor = Color.White
                    End With

                    With lblBoderVertical3
                        .Text = ""
                        .AutoSize = False
                        .Visible = True
                        .Width = 1
                        .Height = lblWafer.Height
                        .BackColor = Color.White
                        .ForeColor = Color.White
                    End With

                    With lblBoderHorizontal1
                        .Text = ""
                        .AutoSize = False
                        .Visible = True
                        .Width = lblWafer.Width + lblTotalProcessTime.Width - 1
                        .Height = 1
                        .BackColor = Color.White
                        .ForeColor = Color.White
                    End With

                    With lblBoderHorizontal2
                        .Text = ""
                        .AutoSize = False
                        .Visible = True
                        .Width = lblWafer.Width + lblTotalProcessTime.Width - 1
                        .Height = 1
                        .BackColor = Color.White
                        .ForeColor = Color.White
                    End With

                    With objLoadLockElevator
                        If .ListOfWaferInfo(INT_NUM - 1) IsNot Nothing AndAlso .ListOfWaferInfo(INT_NUM - 1).WaferStatus <> ConstEnum.enumWaferStatus.eWaferNone Then
                            lblTotalProcessTime.Text = .ListOfWaferInfo(INT_NUM - 1).WaferProcessTime.ToString("0.0")
                        Else
                            Dim ListOfWafersAndChamber As Hashtable = AVPLib.Utils.GetWaferIDAndChambers()
                            If ListOfWafersAndChamber.ContainsKey(lblWafer.Tag) Then
                                Dim objEq As AVPLib.DataManagerment.Equipment = ListOfWafersAndChamber.Item(lblWafer.Tag)
                                If objEq IsNot Nothing Then
                                    Dim iChamberSlotID As Integer = objEq.GetWaferSlotIndex(lblWafer.Tag)
                                    lblTotalProcessTime.Text = objEq.GetWaferInfo(iChamberSlotID).WaferProcessTime.ToString("0.0")
                                End If
                            End If
                        End If
                    End With

                    lblWafer.Location = New Point(x + BETWEEN_WAFER_CHK_PADDING, y)
                    lblTotalProcessTime.Location = New Point(lblWafer.Location.X + lblWafer.Width - 1, y)
                    lblBoderVertical1.Location = New Point(lblWafer.Location.X, y)
                    lblBoderVertical2.Location = New Point(lblBoderVertical1.Location.X + lblWafer.Width, y)
                    lblBoderVertical3.Location = New Point(lblBoderVertical2.Location.X + lblTotalProcessTime.Width - 2, y)
                    lblBoderHorizontal1.Location = New Point(lblWafer.Location.X, y)
                    lblBoderHorizontal2.Location = New Point(lblWafer.Location.X, y + lblWafer.Height)

                    m_arrWaferLabel(INT_NUM - 1) = lblTotalProcessTime
                    m_arrWaferControl(INT_NUM - 1) = lblWafer
                    m_arrBoderVerticalLable1(INT_NUM - 1) = lblBoderVertical1
                    m_arrBoderVerticalLable2(INT_NUM - 1) = lblBoderVertical2
                    m_arrBoderVerticalLable3(INT_NUM - 1) = lblBoderVertical3
                    m_arrBoderHorizontalLable1(INT_NUM - 1) = lblBoderHorizontal1
                    m_arrBoderHorizontalLable2(INT_NUM - 1) = lblBoderHorizontal2

                Next i

                pnlGraph.Controls.AddRange(m_arrBoderVerticalLable1)
                pnlGraph.Controls.AddRange(m_arrBoderVerticalLable2)
                pnlGraph.Controls.AddRange(m_arrBoderVerticalLable3)
                pnlGraph.Controls.AddRange(m_arrBoderHorizontalLable1)
                pnlGraph.Controls.AddRange(m_arrBoderHorizontalLable2)
                pnlGraph.Controls.AddRange(m_arrWaferControl)
                pnlGraph.Controls.AddRange(m_arrWaferLabel)
                pnlGraph.Controls.AddRange(m_arrUnitLabel)
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-12-04 </date>
    ''' </author>
    ''' <summary>
    ''' update wafer process time in real time
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateWaferProcessTime()
        Try
            Dim objLoadLockElevator As AVPLib.DataManagerment.LLElevator = AVPLib.DataManagerment.EquipmentManager.GetEquipment(ConstEnum.Equipments.LLAElevator.ToString())

            If objLoadLockElevator IsNot Nothing Then
                For i As Integer = 0 To (m_arrWaferLabel.Length - 1)
                    With objLoadLockElevator
                        If .ListOfWaferInfo(i) IsNot Nothing AndAlso .ListOfWaferInfo(i).WaferStatus <> ConstEnum.enumWaferStatus.eWaferNone Then
                            m_arrWaferLabel(i).Text = .ListOfWaferInfo(i).WaferProcessTime.ToString("0.0")
                        Else
                            Dim ListOfWafersAndChamber As Hashtable = AVPLib.Utils.GetWaferIDAndChambers()
                            If ListOfWafersAndChamber.ContainsKey(m_arrWaferControl(i).Tag) Then
                                Dim objEq As AVPLib.DataManagerment.Equipment = ListOfWafersAndChamber.Item(m_arrWaferControl(i).Tag)
                                If objEq IsNot Nothing Then
                                    Dim iChamberSlotID As Integer = objEq.GetWaferSlotIndex(m_arrWaferControl(i).Tag)
                                    m_arrWaferLabel(i).Text = objEq.GetWaferInfo(iChamberSlotID).WaferProcessTime.ToString("0.0")
                                End If
                            End If
                        End If
                    End With
                Next i
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub updateTextLength(ByVal label As Label)
        Try
            ' Calculate the fitted string
            Dim strLotIDCharFitted As Integer
            Dim linesFitted As Integer
            Dim f As Font = label.Font
            Dim rect As Rectangle = label.ClientRectangle
            m_TextGraphics = label.CreateGraphics()
            m_TextGraphics.MeasureString(label.Text, f, rect.Size, m_sf, strLotIDCharFitted, linesFitted)

            ' Use "..." for long string
            If strLotIDCharFitted < label.Text.Length Then
                label.Text = label.Text.Substring(0, strLotIDCharFitted) & "..."
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        Finally
            If m_TextGraphics IsNot Nothing Then
                m_TextGraphics.Dispose()
            End If
        End Try
    End Sub

#End Region

#Region "Events – Buttons – Forms…"


#End Region

#Region "Event"
    Private Sub TimerClosingForm(ByVal source As Object, ByVal e As Timers.ElapsedEventArgs)
        m_iClosingTime -= 1
        If (m_iClosingTime Mod 1 = 0) Then
            UpdateWaferProcessTime()
        End If
        If m_iClosingTime <= 0 Then
            m_timer.Interval = 100
            Me.Opacity -= 0.1
            If Me.Opacity <= 0 Then
                m_timer.Enabled = False
                Me.Close()
            End If
        End If
    End Sub

    Private Sub WaferProcessTimePopUp_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        m_timer.Enabled = False
        Me.Close()
    End Sub

    Private Sub WaferProcessTimePopUp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        m_timer.Enabled = False
        Me.Close()
    End Sub

    Private Sub WaferProcessTimePopUp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_timer.Enabled = True
        Me.Opacity = 1
        m_iClosingTime = 30
        m_timer.Interval = 1000
    End Sub

    Private Sub lblTitle_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.HeaderDoubleClick
        m_timer.Enabled = False
        Me.Close()
    End Sub

#End Region

End Class