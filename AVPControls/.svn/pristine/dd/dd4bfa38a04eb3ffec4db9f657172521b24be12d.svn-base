Imports System.ComponentModel
Imports AVPControls.AVPDataLib
Imports AVPControls.AVPGraphicsLib

Public Class AVPForm

#Region "Fields"
    Private Const WM_NCACTIVATE As Integer = &H86

    Private m_showButton As Boolean = True
    Private m_showTitle As Boolean = True
    Private m_showIcon As Boolean
    Private m_imageIcon As Bitmap
    Private m_borderStyle As AVPBorderStyles = AVPBorderStyles.AVP3D
    Private m_titleStatus As DisplayStatus = DisplayStatus.None
    Private m_allowAutoClose As Boolean
    Private m_useFittedTitle As Boolean = True
    Private m_dragOverEdge As Boolean = True
    Private m_isCloseByLostFocus As Boolean = False

    ' Drag-drop variables
    Private m_isDragging As Boolean
    Private m_mouseOffSet As Point = New Point(0, 0)
    Private m_allowDragDrop As Boolean = True
    Private m_dragOpacity As Double = 0.5
    Private m_cursor As Cursor = Me.Cursor

    Public Event HeaderDoubleClick As EventHandler

    Private Delegate Sub UpdateGUIDelegate()

#End Region

#Region "Properties"
    Protected Overrides ReadOnly Property DefaultMinimumSize() As System.Drawing.Size
        Get
            Return New Size(80, 80)
        End Get
    End Property

    Protected Overrides ReadOnly Property DefaultSize() As System.Drawing.Size
        Get
            Return New Size(500, 309)
        End Get
    End Property

    <DefaultValue(GetType(Boolean), "True"), Category("AVP Style")> _
    Public Property ShowTitle() As Boolean
        Get
            Return m_showTitle
        End Get
        Set(ByVal value As Boolean)
            If m_showTitle <> value Then
                m_showTitle = value
                Me.pnlFormTitle.Visible = m_showTitle
                UpdateBorderVisibility()
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True"), Category("AVP Style")> _
    Public Property ShowButton() As Boolean
        Get
            Return m_showButton
        End Get
        Set(ByVal value As Boolean)
            If m_showButton <> value Then
                m_showButton = value
                Me.pnlButtons.Visible = m_showButton
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False"), Category("AVP Style")> _
    Public Shadows Property ShowIcon() As Boolean
        Get
            Return m_showIcon
        End Get
        Set(ByVal value As Boolean)
            If m_showIcon <> value Then
                m_showIcon = value
            End If
            Me.pnlIcon.Visible = m_showIcon
        End Set
    End Property

    <DefaultValue(GetType(Bitmap), "Nothing"), Category("AVP Style")> _
    Public Property ImageIcon() As Bitmap
        Get
            Return m_imageIcon
        End Get
        Set(ByVal value As Bitmap)
            m_imageIcon = value
            Me.pnlIcon.BackgroundImage = m_imageIcon
        End Set
    End Property

    <DefaultValue(GetType(AVPBorderStyles), "AVP3D"), Category("AVP Style")> _
    Public Property AVPBorderStyle() As AVPBorderStyles
        Get
            Return m_borderStyle
        End Get
        Set(ByVal value As AVPBorderStyles)
            If m_borderStyle <> value Then
                m_borderStyle = value
                UpdateBorderVisibility()
                Me.Refresh()
            End If
        End Set
    End Property

    <DefaultValue(GetType(DisplayStatus), "None"), Category("AVP Style")> _
    Public Property HeaderStatus() As DisplayStatus
        Get
            Return m_titleStatus
        End Get
        Set(ByVal value As DisplayStatus)
            If m_titleStatus <> value Then
                m_titleStatus = value
                Me.UpdateStatus()
            End If
        End Set
    End Property

    <DefaultValue(GetType(Integer), "40"), Category("AVP Style")> _
    Public Property HeaderHeight() As Integer
        Get
            Return Me.pnlFormTitle.Height
        End Get
        Set(ByVal value As Integer)
            If Me.pnlFormTitle.Height <> value Then
                Me.pnlFormTitle.Height = value
            End If
        End Set
    End Property

    <Browsable(True)> _
    <EditorBrowsable(EditorBrowsableState.Always)> _
    <DefaultValue(GetType(ContentAlignment), "MiddleCenter"), Category("AVP Style")> _
    Public Property HeaderTextAlign() As ContentAlignment
        Get
            Return Me.lblTitleText.TextAlign
        End Get
        Set(ByVal value As ContentAlignment)
            Me.lblTitleText.TextAlign = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False"), Category("AVP Behavior")> _
    Public Property AllowAutoClose() As Boolean
        Get
            Return m_allowAutoClose
        End Get
        Set(ByVal value As Boolean)
            m_allowAutoClose = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True"), Category("AVP Behavior")> _
    Public Property AllowDragDrop() As Boolean
        Get
            Return m_allowDragDrop
        End Get
        Set(ByVal value As Boolean)
            m_allowDragDrop = value
        End Set
    End Property

    <Browsable(True)> _
    <EditorBrowsable(EditorBrowsableState.Always)> _
    <DefaultValue(0.5R)> _
    <TypeConverter(GetType(OpacityConverter))> _
    <Category("AVP Style")> _
    Public Property DragOpacity() As Double
        Get
            Return m_dragOpacity
        End Get
        Set(ByVal value As Double)
            m_dragOpacity = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True")> _
    Protected Property UseFittedTitle() As Boolean
        Get
            Return m_useFittedTitle
        End Get
        Set(ByVal value As Boolean)
            m_useFittedTitle = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True")> _
    Protected Property DragOverEdge() As Boolean
        Get
            Return m_dragOverEdge
        End Get
        Set(ByVal value As Boolean)
            m_dragOverEdge = value
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False)> _
    Public Property IsClosedByLostFocus() As Boolean
        Get
            Return m_isCloseByLostFocus
        End Get
        Private Set(ByVal value As Boolean)
            m_isCloseByLostFocus = value
        End Set
    End Property

    ''' <author>
    '''     <name> Dua Tran </name>
    '''     <date> 2019-05-28 </date>
    ''' </author>
    ''' <summary>
    ''' Override for support modified params
    ''' </summary>
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams

            ' For double buffering
            If EnableFormLevelDoubleBuffering Then
                Dim OSVer As Version = System.Environment.OSVersion.Version()
                If OSVer.Major > 5 Then
                    cp.ExStyle = cp.ExStyle Or &H2000000
                End If
                OSVer = Nothing
            End If

            Return cp
        End Get
    End Property

    ''' <author>
    '''     <name> Dua Tran </name>
    '''     <date> 2019-05-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set a value indicating whether this control and its childs enable double buffering.
    ''' </summary>
    Private m_enableFormLevelDoubleBuffering As Boolean
    <DefaultValue(GetType(Boolean), "False"), Category("AVP Behavior"), Description("Get or set a value indicating whether this control and its childs enable double buffering.")> _
    Public Property EnableFormLevelDoubleBuffering() As Boolean
        Get
            Return m_enableFormLevelDoubleBuffering
        End Get
        Set(ByVal value As Boolean)
            If m_enableFormLevelDoubleBuffering <> value Then
                m_enableFormLevelDoubleBuffering = value
            End If
        End Set
    End Property

#End Region

#Region "Methods"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-09</date>
    ''' </author>
    ''' <summary>
    ''' Overrides for process windows message.
    ''' </summary>
    ''' <param name="m"></param>
    ''' <remarks></remarks>
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        ' Listen for operating system messages
        Select Case m.Msg
            ' Close on inactive and mouse click outside of window.
            Case WM_NCACTIVATE
                If Not Me.DesignMode AndAlso Me.AllowAutoClose Then
                    If m.WParam.ToInt32 = 0 Then
                        If Not Me.RectangleToScreen(Me.ClientRectangle).Contains(Windows.Forms.Cursor.Position) Then
                            IsClosedByLostFocus = True
                            Me.DoClose()
                        End If
                    End If
                End If

        End Select

        MyBase.WndProc(m)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-09</date>
    ''' </author>
    ''' <summary>
    ''' Update title status.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateStatus()
        Try
            Dim tempImg As Image = Me.pnlFormTitle.BackgroundImage

            pnlFormTitle.SuspendLayout()

            ' Set color
            Select Case m_titleStatus
                Case DisplayStatus.Off
                    Me.pnlFormTitle.BackColor = STATUS_OFF_COLOR
                    Me.lblTitleText.ForeColor = TEXT_OFF_COLOR
                Case DisplayStatus.On
                    Me.pnlFormTitle.BackColor = STATUS_ON_COLOR
                    Me.lblTitleText.ForeColor = TEXT_ON_COLOR
                Case DisplayStatus.Unknow
                    Me.pnlFormTitle.BackColor = STATUS_UNKNOWN_COLOR
                    Me.lblTitleText.ForeColor = TEXT_UNKNOWN_COLOR
                Case DisplayStatus.Error
                    Me.pnlFormTitle.BackColor = STATUS_ERROR_COLOR
                    Me.lblTitleText.ForeColor = TEXT_ERROR_COLOR
                Case Else
                    Me.pnlFormTitle.BackColor = Color.Transparent
                    Me.pnlFormTitle.AVPBorderStyle = AVPBorderStyles.None
                    Me.pnlFormTitle.BackgroundImage = My.Resources.Resources.BgMsgBoxHeader
                    Me.lblTitleText.ForeColor = TEXT_NONE_COLOR
            End Select

            ' Set background
            If m_titleStatus <> DisplayStatus.None Then
                Me.pnlFormTitle.BackgroundImage = Nothing
                Me.pnlFormTitle.AVPBorderStyle = AVPBorderStyles.AVP3D
            End If

            pnlFormTitle.ResumeLayout(True)

            If tempImg IsNot Nothing Then
                tempImg.Dispose()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Drag-Drop Methods"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-09 </date>
    ''' </author>
    ''' <summary>
    ''' Event for drag-drop
    ''' </summary>
    Protected Sub Obj_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If m_allowDragDrop AndAlso e.Button = Windows.Forms.MouseButtons.Left Then
            m_mouseOffSet = New Point(e.Location.X, e.Location.Y)
            m_isDragging = True
            m_cursor = DirectCast(sender, Control).Cursor
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-09 </date>
    ''' </author>
    ''' <summary>
    ''' Event for drag-drop
    ''' </summary>
    Protected Sub Obj_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If m_allowDragDrop Then
            If m_isDragging AndAlso e.Button = Windows.Forms.MouseButtons.Left Then
                Dim point As Point = Me.Location
                Dim left As Integer = point.X + (e.Location.X - m_mouseOffSet.X)
                Dim top As Integer = point.Y + (e.Location.Y - m_mouseOffSet.Y)

                ' Do not allow drag form outside of screen
                If Not Me.m_dragOverEdge Then
                    Dim resetMouseOffset As Boolean
                    Dim resetTopOffset As Boolean

                    If left < 0 Then
                        left = 0
                        resetMouseOffset = True
                    Else
                        Dim limit As Integer = Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Me.Width
                        If left > limit Then
                            left = limit
                            resetMouseOffset = True
                        End If
                    End If

                    If top < 0 Then
                        top = 0
                        resetTopOffset = True
                    Else
                        Dim topLimit As Integer = Windows.Forms.Screen.PrimaryScreen.Bounds.Height - Me.Height
                        If top > topLimit Then
                            top = topLimit
                            resetTopOffset = True
                        End If
                    End If

                    If resetMouseOffset Then
                        m_mouseOffSet.X = e.X
                    End If

                    If resetTopOffset Then
                        m_mouseOffSet.Y = e.Y
                    End If
                End If

                Me.Location = New Point(left, top)
                Me.Opacity = m_dragOpacity
                DirectCast(sender, Control).Cursor = Cursors.SizeAll
            End If
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-09 </date>
    ''' </author>
    ''' <summary>
    ''' Event for drag-drop
    ''' </summary>
    Protected Sub Obj_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If m_allowDragDrop Then
            If m_isDragging AndAlso e.Button = Windows.Forms.MouseButtons.Left Then
                m_isDragging = False
                Me.Opacity = 1
                DirectCast(sender, Control).Cursor = m_cursor
            End If
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-09 </date>
    ''' </author>
    ''' <summary>
    ''' Add drag-drop events for specified control.
    ''' </summary>
    Protected Sub AddDragDropEvent(ByVal obj As Control)
        If obj Is Nothing Then
            Return
        End If

        ' Remove mouse event for old object
        RemoveHandler obj.MouseDown, AddressOf Obj_MouseDown
        RemoveHandler obj.MouseUp, AddressOf Obj_MouseUp
        RemoveHandler obj.MouseMove, AddressOf Obj_MouseMove

        ' Add mouse event for new object 
        AddHandler obj.MouseDown, AddressOf Obj_MouseDown
        AddHandler obj.MouseUp, AddressOf Obj_MouseUp
        AddHandler obj.MouseMove, AddressOf Obj_MouseMove
    End Sub
#End Region

#Region "Constructor"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DoubleBuffered = True
        Me.ControlBox = False

        ' Add event drag-drop for control.
        Me.AddDragDropEvent(Me.lblTitleText)
        Me.AddDragDropEvent(Me.pnlIcon)
        Me.AddDragDropEvent(Me.pnlButtons)

    End Sub
#End Region

#Region "Events"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-09 </date>
    ''' </author>
    ''' <summary>
    ''' Event for close button.
    ''' </summary>
    Private Sub btnCloseForm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCloseForm.Click
        Me.DoClose()
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-11-19 </date>
    ''' </author>
    ''' <summary>
    ''' Actions on close button click.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub DoClose()
        Me.Close()
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-11-23 </date>
    ''' </author>
    ''' <summary>
    ''' Handle double click event of header text.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lblTitleText_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTitleText.DoubleClick
        RaiseEvent HeaderDoubleClick(sender, e)
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-09 </date>
    ''' </author>
    ''' <summary>
    ''' Event for label title button.
    ''' </summary>
    Private Sub lblTitle_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTitleText.SizeChanged
        If Me.InvokeRequired Then
            Dim updateGui As New UpdateGUIDelegate(AddressOf UpdateTitleText)
            Me.BeginInvoke(updateGui)
        Else
            UpdateTitleText()
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-23 </date>
    ''' </author>
    ''' <summary>
    ''' On load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IsClosedByLostFocus = False
        Me.pnlIcon.Visible = m_showIcon
        Me.pnlButtons.Visible = m_showButton
        Me.pnlFormTitle.Visible = m_showTitle
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-23 </date>
    ''' </author>
    ''' <summary>
    ''' Paint border
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPForm_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If m_borderStyle = AVPBorderStyles.AVP3D Then
            AVPGraphicsLib.DrawBorder3D(e.Graphics, Me.Width, Me.Height)
        ElseIf m_borderStyle = AVPBorderStyles.AVP3DDown Then
            If Me.BackColor = Color.Black Then
                AVPGraphicsLib.DrawBorder3DDown(e.Graphics, Me.Width, Me.Height, Color.White)
            Else
                AVPGraphicsLib.DrawBorder3DDown(e.Graphics, Me.Width, Me.Height, Color.Black)
            End If
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-23 </date>
    ''' </author>
    ''' <summary>
    ''' Set text to fit with control width
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AVPForm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        If Me.InvokeRequired Then
            Dim updateGui As New UpdateGUIDelegate(AddressOf UpdateTitleText)
            Me.BeginInvoke(updateGui)
        Else
            UpdateTitleText()
        End If
    End Sub

    ''' <author>
    '''      <name>Hai Tran</name>
    '''      <date>2016-01-25</date>
    ''' </author>
    ''' <summary>
    ''' Update title of the form.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateTitleText()
        If Me.m_useFittedTitle Then
            Me.lblTitleText.Text = AVPGraphicsLib.GetFittedText(Me.Text, Me.lblTitleText)
        Else
            Me.lblTitleText.Text = Me.Text
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Change size of label to fit with panel.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnlTitle_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlTitle.Resize
        If Me.InvokeRequired Then
            Dim updateGui As New UpdateGUIDelegate(AddressOf UpdateTitleSize)
            Me.BeginInvoke(updateGui)
        Else
            UpdateTitleSize()
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2016-01-25 </date>
    ''' </author>
    ''' <summary>
    ''' Change size of label to fit with panel.
    ''' </summary>
    Private Sub UpdateTitleSize()
        Me.lblTitleText.Size = pnlTitle.Size
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-11-20 </date>
    ''' </author>
    ''' <summary>
    ''' Change size of close button to fit with panel.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pnlFormTitle_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlFormTitle.SizeChanged
        If Me.InvokeRequired Then
            Dim updateGui As New UpdateGUIDelegate(AddressOf UpdateButtonSize)
            Me.BeginInvoke(updateGui)
        Else
            UpdateButtonSize()
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2016-01-25 </date>
    ''' </author>
    ''' <summary>
    ''' Change size of close button to fit with panel.
    ''' </summary>
    Private Sub UpdateButtonSize()
        Dim size As Integer = pnlFormTitle.Height
        If size > 40 Then
            size = 40
        End If
        Me.pnlButtons.Width = size
        Me.btnCloseForm.Size = Me.pnlButtons.Size
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-11-23 </date>
    ''' </author>
    ''' <summary>
    ''' Change background image layout of close button by its height.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCloseForm_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseForm.SizeChanged
        If Me.InvokeRequired Then
            Dim updateGui As New UpdateGUIDelegate(AddressOf UpdateCloseButtonLayout)
            Me.BeginInvoke(updateGui)
        Else
            UpdateCloseButtonLayout()
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2016-01-25 </date>
    ''' </author>
    ''' <summary>
    ''' Change background image layout of close button by its height.
    ''' </summary>
    Private Sub UpdateCloseButtonLayout()
        If btnCloseForm.Height <= 30 Then
            btnCloseForm.BackgroundImageLayout = ImageLayout.Zoom
        Else
            btnCloseForm.BackgroundImageLayout = ImageLayout.Center
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2016-01-25 </date>
    ''' </author>
    ''' <summary>
    ''' Change border padding visibility.
    ''' </summary>
    Private Sub UpdateBorderVisibility()
        Try
            Dim borderPaddingVisible As Boolean = (Me.ShowTitle OrElse Me.AVPBorderStyle <> AVPBorderStyles.None)
            Me.BorderBottomEdge.Visible = borderPaddingVisible
            Me.BorderLeftEdge.Visible = borderPaddingVisible
            Me.BorderRightEdge.Visible = borderPaddingVisible
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

#End Region

End Class