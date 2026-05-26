Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Graphics
Imports AVP_Robot_Project.ConstantAndEnum
Public Class PressureGraph

#Region "Class Constants & Variables"
    Private Const DEFAULT_NUMBER_OF_SLOT = 12
    Private Const WAFER_RADIUS As Integer = 23
    Private Const NUM_OF_WAFER_PER_COL As Integer = 6
    Private Const SPACE_BTW_WAFER As Integer = 5
    Private m_WaferIDColor As Color = Color.White
    Private MyFont As New Font("Times New Roman", 10, FontStyle.Bold)

    Public Enum ElevatorPos
        [One] = 1
        [Two] = 2
        [Three] = 3
        [Four] = 4
        [Five] = 5
        [Six] = 6
        [Seven] = 7
        [Eight] = 8
        [Nine] = 9
        [Ten] = 10
        [Elevent] = 11
        [Twelve] = 12
        [Thirteen] = 13
        [Forteen] = 14
        [Fifteen] = 15
        [Sixteen] = 16
        [Seventeen] = 17
        [Eighteen] = 18
        [Nighteen] = 19
        [Twenty] = 20
        [TwentyOne] = 21
        [TwentyTwo] = 22
        [TwentyThree] = 23
        [TwentyFour] = 24
        [TwentyFive] = 25
    End Enum
    Public Enum LoadLock
        [LoadLockA] = 1
    End Enum
    Public Enum DisplayStyle
        [Left] = 0
        [Right] = 1
    End Enum

    Private m_intDisplayStyle As DisplayStyle
    Private m_intBarsNum As Integer
    Private m_arrBarStatus As AVPLib.ConstEnum.enumWaferStatus()
    Private m_arrPosition As New ArrayList
    Private m_intPosition As Integer
    Private m_strLoadLock As String = String.Empty
    Private m_WaferImage As Image
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the number of bars in the graph
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Integer), "12")> _
    Public Property BarsNum() As Integer
        Get
            Return m_intBarsNum
        End Get
        Set(ByVal value As Integer)
            SetNumOfSlots(value)
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Get or set status of a bar based on index
    ''' </summary>
    ''' <param name="Index"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Default Public Property Bars(ByVal Index As Integer) As AVPLib.ConstEnum.enumWaferStatus
        Get
            Try
                If ((Index >= 0) And (Index < m_intBarsNum)) Then
                    Return m_arrBarStatus(Index)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            Return AVPLib.ConstEnum.enumWaferStatus.eWaferNone
        End Get
        Set(ByVal value As AVPLib.ConstEnum.enumWaferStatus)
            Try
                If ((Index >= 0) And (Index < m_intBarsNum)) Then
                    m_arrBarStatus(Index) = value
                    Me.Refresh()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

        End Set
    End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Get or set status array of all bars
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property BarsStatus() As AVPLib.ConstEnum.enumWaferStatus()
        Get
            Return m_arrBarStatus
        End Get
        Set(ByVal value As AVPLib.ConstEnum.enumWaferStatus())
            Try
                If (value IsNot Nothing) Then
                    If m_intBarsNum <> value.Length Then
                        SetNumOfSlots(value.Length)
                    End If
                    m_arrBarStatus = value
                    Me.Refresh()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-06-01</date>
    ''' </author>
    ''' <summary>
    ''' Get or set Position slot of Elevator
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property ElevatorCurrentSlotStatus() As Integer
        Get
            Return m_intPosition
        End Get
        Set(ByVal value As Integer)
            Try
                m_intPosition = value
                Me.Refresh()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property CurentLoadLock() As String
        Get
            Return m_strLoadLock
        End Get
        Set(ByVal value As String)
            Try
                m_strLoadLock = value
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-01</date>
    ''' </author>    
    ''' <summary>
    ''' Get or set value to align all child controls inside this user control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AlignStyle() As DisplayStyle
        Get
            AlignStyle = m_intDisplayStyle
        End Get
        Set(ByVal value As DisplayStyle)
            Try
                m_intDisplayStyle = value
                Me.Refresh()
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
#End Region

#Region "Constructors & Dispose"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Initate pressure graph
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetNumOfSlots(DEFAULT_NUMBER_OF_SLOT)
    End Sub
#End Region

#Region "Public methods"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-12-15</date>
    ''' </author>
    ''' <summary>
    ''' clear all bars in pressure graph
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        AVPLib.Log.guiLogger.Info("Enter Clear")
        Try
            For i As Integer = 0 To (m_intBarsNum - 1)
                m_arrBarStatus(i) = AVPLib.ConstEnum.enumWaferStatus.eWaferNone
            Next i
            Me.Refresh()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave Clear")
    End Sub
    Public Function GetBarStatus(ByVal i As Integer) As AVPLib.ConstEnum.enumWaferStatus
        AVPLib.Log.guiLogger.Info("Enter GetBarStatus")
        Try
            Return m_arrBarStatus(i)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave GetBarStatus")
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-07-15 </date>
    ''' </author>
    ''' <summary>
    ''' Set bar status, reset BarsNum if the index is out of range
    ''' </summary>
    Public Sub SetBarStatus(ByVal index As Integer, ByVal value As AVPLib.ConstEnum.enumWaferStatus)
        Try
            If index >= m_intBarsNum Then
                BarsNum = index + 1
            End If
            m_arrBarStatus(index) = value
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-07-15 </date>
    ''' </author>
    ''' <summary>
    ''' Set number of slots, redim status array, and set width of control
    ''' </summary>
    Private Sub SetNumOfSlots(ByVal value As Integer)
        Try
            If m_intBarsNum <> value AndAlso value > 0 Then
                m_intBarsNum = value
                ReDim Preserve m_arrBarStatus(m_intBarsNum - 1)
                Me.Width = Math.Ceiling(m_intBarsNum / NUM_OF_WAFER_PER_COL) * (WAFER_RADIUS + SPACE_BTW_WAFER) + SPACE_BTW_WAFER + 1
                Me.Refresh()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-26</date>
    ''' </author>
    ''' <summary>
    ''' Handling control painting event to draw the graph on the screen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PressureGraph_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Try
            Dim x As Single = 0
            Dim y As Single = 0
            Dim INT_NUM As Integer = 0
            Dim int_TimeToDraw As Integer = 0
            Dim int_nextRow As Integer = 0
            Dim brText As SolidBrush
            Dim xPos As Single

            'GET CONFIG COLOR FOR WAFER STATUS
            For i As Integer = 0 To (m_intBarsNum - 1)
                If (i Mod NUM_OF_WAFER_PER_COL = 0) Then
                    int_nextRow = NUM_OF_WAFER_PER_COL - 1
                    x = SPACE_BTW_WAFER + (i / SPACE_BTW_WAFER) * (WAFER_RADIUS)
                    int_TimeToDraw += 1
                Else
                    int_nextRow -= 1
                End If
                y = SPACE_BTW_WAFER + int_nextRow * (WAFER_RADIUS + 2)
                'TEXT NUM
                INT_NUM = i + 1

                Select Case m_arrBarStatus(INT_NUM - 1)
                    Case AVPLib.ConstEnum.enumWaferStatus.eWaferExposed 'Invalid
                        m_WaferImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Partial
                        m_WaferIDColor = Color.Black
                    Case AVPLib.ConstEnum.enumWaferStatus.eWaferNone
                        m_WaferImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_BlackGraph
                        m_WaferIDColor = Color.White
                    Case AVPLib.ConstEnum.enumWaferStatus.eWaferError
                        m_WaferImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Error
                        m_WaferIDColor = Color.White
                    Case AVPLib.ConstEnum.enumWaferStatus.eWaferComplete
                        m_WaferImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Complete
                        m_WaferIDColor = Color.Black
                    Case AVPLib.ConstEnum.enumWaferStatus.eWaferNew
                        m_WaferImage = Global.AVP_Robot_Project.My.Resources.Resources.Wafer_Unprocess
                        m_WaferIDColor = Color.White
                End Select

                ''DRAW CIRCLE
                brText = New SolidBrush(m_WaferIDColor)
              
                e.Graphics.DrawImage(m_WaferImage, x, y, WAFER_RADIUS, WAFER_RADIUS)

                xPos = x + SPACE_BTW_WAFER + SPACE_BTW_WAFER / 2.0F
                If INT_NUM.ToString.Length > 1 Then ''IF TEXT IS 2 DIGIT 
                    xPos = x + SPACE_BTW_WAFER - 1
                End If
                e.Graphics.DrawString(INT_NUM.ToString(), MyFont, brText, xPos - 1, y + SPACE_BTW_WAFER - 1)

                'DRAW INDICATOR LED
                If (Me.CurentLoadLock = LoadLock.LoadLockA.ToString) Then 'load lock A
                    If INT_NUM = Me.ElevatorCurrentSlotStatus Then
                        e.Graphics.FillEllipse(Brushes.Yellow, x, y, 7, 7)
                        e.Graphics.DrawEllipse(Pens.Black, x, y, 7, 7)
                    End If
                End If
            Next i

            brText = Nothing
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

End Class

