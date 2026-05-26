Imports System.ComponentModel

Public Class ClosePopUpFrm
    Private m_isDragging As Boolean = False
    Private m_mouseOffSet As Point = New Point(0, 0)
    Private m_allowDragDrop As Boolean = False
    Private m_opacity As Single = 0.5
    Private m_dragableControl As Control = Nothing
    Private m_cursor As Cursor = Me.Cursor
    Private m_allowAutoClose As Boolean = True
    Private m_useBorderStyle As Boolean = False

#Region "Properties"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-02 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set the value indicate form is used user border style
    ''' </summary>
    <Category("Appearance"), DefaultValue(GetType(Boolean), "False")> _
    Public Property UseBorderStyle() As Boolean
        Get
            Return m_useBorderStyle
        End Get
        Set(ByVal value As Boolean)
            m_useBorderStyle = value
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-02 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set value indicate user can drap drop form
    ''' </summary>
    <DefaultValue(GetType(Boolean), "False")> _
    Public Property AllowDragDrop() As Boolean
        Get
            Return m_allowDragDrop
        End Get
        Set(ByVal value As Boolean)
            m_allowDragDrop = value
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-02 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set value indicate window can auto close when inactive
    ''' </summary>
    <DefaultValue(GetType(Boolean), "True")> _
    Public Property AllowAutoClose() As Boolean
        Get
            Return m_allowAutoClose
        End Get
        Set(ByVal value As Boolean)
            m_allowAutoClose = value
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-02 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set value indicate opacity of form when drag
    ''' </summary>
    <DefaultValue(GetType(Single), "0.5")> _
    Public Property DragOpacity() As Single
        Get
            Return m_opacity
        End Get
        Set(ByVal value As Single)
            m_opacity = value
        End Set
    End Property

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-02 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set object which hold event for drag-drop
    ''' </summary>
    Public Property DragDropHandlerObject() As Control
        Get
            Return m_dragableControl
        End Get
        Set(ByVal value As Control)
            If m_dragableControl IsNot Nothing Then
                ' Remove mouse event for old object
                RemoveHandler m_dragableControl.MouseDown, AddressOf Obj_MouseDown
                RemoveHandler m_dragableControl.MouseUp, AddressOf Obj_MouseUp
                RemoveHandler m_dragableControl.MouseMove, AddressOf Obj_MouseMove
            End If

            m_dragableControl = value
            If m_dragableControl IsNot Nothing Then
                m_cursor = m_dragableControl.Cursor
                ' Add mouse event for new object 
                AddHandler m_dragableControl.MouseDown, AddressOf Obj_MouseDown
                AddHandler m_dragableControl.MouseUp, AddressOf Obj_MouseUp
                AddHandler m_dragableControl.MouseMove, AddressOf Obj_MouseMove
            End If
        End Set
    End Property
#End Region

#Region "Methods"
    'comment this code if want to view designer of Form Child
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)
        If DesignMode = False Then
            Const WM_NCACTIVATE As Int16 = &H86

            If m.Msg = WM_NCACTIVATE Then
                If m.WParam.ToInt32 = 0 Then '1: active ; 0: inactive
                    If Not Me.RectangleToScreen(Me.ClientRectangle).Contains(Windows.Forms.Cursor.Position) Then
                        If m_allowAutoClose Then
                            Me.Close()
                        End If
                    End If
                End If
            End If
        End If
    End Sub
#End Region

#Region "Drag-Drop Functions"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-02 </date>
    ''' </author>
    ''' <summary>
    ''' Event for drag-drop
    ''' </summary>
    Private Sub Obj_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If AllowDragDrop AndAlso e.Button = Windows.Forms.MouseButtons.Left Then
            m_mouseOffSet = New Point(e.Location.X, e.Location.Y)
            m_isDragging = True
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-02 </date>
    ''' </author>
    ''' <summary>
    ''' Event for drag-drop
    ''' </summary>
    Private Sub Obj_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If AllowDragDrop Then
            If m_isDragging AndAlso e.Button = Windows.Forms.MouseButtons.Left Then
                Dim point As Point = Me.Location
                Me.Location = New Point(point.X + (e.Location.X - m_mouseOffSet.X), point.Y + (e.Location.Y - m_mouseOffSet.Y))
                Me.Opacity = m_opacity
                CType(sender, Control).Cursor = Cursors.SizeAll
            End If
        End If
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-04-02 </date>
    ''' </author>
    ''' <summary>
    ''' Event for drag-drop
    ''' </summary>
    Private Sub Obj_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If AllowDragDrop Then
            If m_isDragging AndAlso e.Button = Windows.Forms.MouseButtons.Left Then
                m_isDragging = False
                Me.Opacity = 1
                CType(sender, Control).Cursor = m_cursor
            End If
        End If
    End Sub
#End Region

#Region "Border-Paint Function"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-06-02 </date>
    ''' </author>
    ''' <summary>
    ''' Override paint event for paint form border
    ''' </summary>
    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaintBackground(e)
        If UseBorderStyle Then
            Utils.PaintBorder(Me, e)
        End If
    End Sub
#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        If m_dragableControl IsNot Nothing Then
            AddHandler m_dragableControl.MouseDown, AddressOf Obj_MouseDown
            AddHandler m_dragableControl.MouseUp, AddressOf Obj_MouseUp
            AddHandler m_dragableControl.MouseMove, AddressOf Obj_MouseMove
        End If
    End Sub
End Class