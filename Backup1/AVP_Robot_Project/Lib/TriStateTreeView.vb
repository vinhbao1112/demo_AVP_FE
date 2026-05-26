
' Summary:
'     Specifies the visual state of a check box that is drawn with visual styles.
Public Enum CheckBoxState
    ' Summary:
    '     The check box is unchecked.
    UncheckedNormal = 1
    '
    ' Summary:
    '     The check box is unchecked and hot.
    UncheckedHot = 2
    '
    ' Summary:
    '     The check box is unchecked and pressed.
    UncheckedPressed = 3
    '
    ' Summary:
    '     The check box is unchecked and disabled.
    UncheckedDisabled = 4
    '
    ' Summary:
    '     The check box is checked.
    CheckedNormal = 5
    '
    ' Summary:
    '     The check box is checked and hot.
    CheckedHot = 6
    '
    ' Summary:
    '     The check box is checked and pressed.
    CheckedPressed = 7
    '
    ' Summary:
    '     The check box is checked and disabled.
    CheckedDisabled = 8
    '
    ' Summary:
    '     The check box is three-state.
    MixedNormal = 9
    '
    ' Summary:
    '     The check box is three-state and hot.
    MixedHot = 10
    '
    ' Summary:
    '     The check box is three-state and pressed.
    MixedPressed = 11
    '
    ' Summary:
    '     The check box is three-state and disabled.
    MixedDisabled = 12
End Enum

''' <summary>
''' Provides a tree view
''' control supporting
''' tri-state checkboxes.
''' </summary>
Public Class TriStateTreeView
    Inherits TreeView

    ' ~~~ fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    Private m_ilStateImages As ImageList
    Private m_bUseTriState As Boolean
    Private m_bCheckBoxesVisible As Boolean
    Private m_blEditable As Boolean
    Private m_blMouseRelease As Boolean
    ' ~~~ constructor ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    ''' <summary>
    ''' Creates a new instance
    ''' of this control.
    ''' </summary>
    Public Sub New()
        MyBase.New()
        Dim cbsState As CheckBoxState
        Dim gfxCheckBox As Graphics
        Dim bmpCheckBox As Bitmap

        m_ilStateImages = New ImageList()
        ' first we create our state image
        cbsState = CheckBoxState.UncheckedNormal
        ' list and pre-init check state.
        For i As Integer = 0 To 2
            ' let's iterate each tri-state
            bmpCheckBox = New Bitmap(12, 12)
            ' creating a new checkbox bitmap
            gfxCheckBox = Graphics.FromImage(bmpCheckBox)
            ' and getting graphics object from
            Select Case i
                ' it...
                Case 0
                    cbsState = CheckBoxState.UncheckedNormal
                    Exit Select
                Case 1
                    cbsState = CheckBoxState.CheckedNormal
                    Exit Select
                Case 2
                    cbsState = CheckBoxState.MixedNormal
                    Exit Select
            End Select
            CheckBoxRenderer.DrawCheckBox(gfxCheckBox, New Point(-1, -1), cbsState)
            ' ...rendering the checkbox and...
            gfxCheckBox.Save()
            m_ilStateImages.Images.Add(bmpCheckBox)
            ' ...adding to sate image list.
            m_bUseTriState = True
        Next
    End Sub

    ' ~~~ properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    ''' <summary>
    ''' Gets or sets to display
    ''' checkboxes in the tree
    ''' view.
    ''' </summary>
    Public Shadows Property CheckBoxes() As Boolean
        Get
            Return m_bCheckBoxesVisible
        End Get
        Set(ByVal value As Boolean)
            m_bCheckBoxesVisible = value
            MyBase.CheckBoxes = m_bCheckBoxesVisible
            Me.StateImageList = IIf(m_bCheckBoxesVisible, m_ilStateImages, Nothing)
        End Set
    End Property

    Public Shadows Property StateImageList() As ImageList
        Get
            Return MyBase.StateImageList
        End Get
        Set(ByVal value As ImageList)
            MyBase.StateImageList = value
        End Set
    End Property

    Public Property Editable() As Boolean
        Get
            Return m_blEditable
        End Get
        Set(ByVal value As Boolean)
            m_blEditable = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets to support
    ''' tri-state in the checkboxes
    ''' or not.
    ''' </summary>

    Public Property CheckBoxesTriState() As Boolean
        Get
            Return m_bUseTriState
        End Get
        Set(ByVal value As Boolean)
            m_bUseTriState = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Check all nodes to True or False
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    'Public Sub Check_Or_UnCheckedAll(ByVal blnChecked As Boolean)
    '    Dim stNodes As Stack(Of TreeNode)
    '    Dim tnStacked As TreeNode

    '    MyBase.Refresh()

    '    If Not CheckBoxes Then
    '        Exit Sub
    '        ' nothing to do here if
    '    End If
    '    ' checkboxes are hidden.
    '    MyBase.CheckBoxes = blnChecked
    '    ' hide normal checkboxes...
    '    stNodes = New Stack(Of TreeNode)(Me.Nodes.Count)
    '    ' create a new stack and
    '    For Each tnCurrent As TreeNode In Me.Nodes
    '        ' push each root node.
    '        stNodes.Push(tnCurrent)
    '    Next

    '    While stNodes.Count > 0
    '        ' let's pop node from stack,
    '        tnStacked = stNodes.Pop()
    '        ' set correct state image
    '        ' index if not already done
    '        tnStacked.StateImageIndex = 0
    '        tnStacked.Checked = blnChecked
    '        ' and push each child to stack
    '        For i As Integer = 0 To tnStacked.Nodes.Count - 1
    '            ' too until there are no
    '            stNodes.Push(tnStacked.Nodes(i))
    '            ' nodes left on stack.
    '        Next
    '    End While
    'End Sub
    ''' <summary>
    ''' Refreshes this
    ''' control.
    ''' </summary>
    Public Overloads Overrides Sub Refresh()
        Dim stNodes As Stack(Of TreeNode)
        Dim tnStacked As TreeNode

        MyBase.Refresh()

        If Not CheckBoxes Then
            Exit Sub
            ' nothing to do here if
        End If
        ' checkboxes are hidden.
        MyBase.CheckBoxes = False
        ' hide normal checkboxes...
        stNodes = New Stack(Of TreeNode)(Me.Nodes.Count)
        ' create a new stack and
        For Each tnCurrent As TreeNode In Me.Nodes
            ' push each root node.
            stNodes.Push(tnCurrent)
        Next

        While stNodes.Count > 0
            ' let's pop node from stack,
            tnStacked = stNodes.Pop()
            ' set correct state image
            If tnStacked.StateImageIndex = -1 Then
                ' index if not already done
                tnStacked.StateImageIndex = IIf(tnStacked.Checked, 1, 0)
            End If
            ' and push each child to stack
            For i As Integer = 0 To tnStacked.Nodes.Count - 1
                ' too until there are no
                stNodes.Push(tnStacked.Nodes(i))
                ' nodes left on stack.
            Next
        End While
    End Sub

    Protected Overloads Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
        MyBase.OnLayout(levent)

        Refresh()
    End Sub

    Protected Overloads Overrides Sub OnAfterExpand(ByVal e As TreeViewEventArgs)
        MyBase.OnAfterExpand(e)

        For Each tnCurrent As TreeNode In e.Node.Nodes
            ' set tree state image
            tnCurrent.StateImageIndex = IIf(tnCurrent.Checked, 1, 0)
            ' to each child node...
        Next
    End Sub
    Protected Overloads Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)

        MyBase.OnKeyDown(e)

        If (e.KeyCode = Keys.Space) Then
            If SelectedNode IsNot Nothing Then
                CheckNode(SelectedNode)
            End If
        End If

    End Sub

    Protected Sub CheckNode(ByVal selectedNode As System.Windows.Forms.TreeNode)

        'If this is a readonly tree
        If (Not Editable) Then
            Return
        End If

        Dim stNodes As Stack(Of TreeNode)
        Dim tnBuffer As TreeNode
        Dim bMixedState As Boolean

        Dim iIndex As Integer

        tnBuffer = selectedNode
        ' buffer clicked node and
        tnBuffer.Checked = Not tnBuffer.Checked
        ' flip its check state.
        stNodes = New Stack(Of TreeNode)(tnBuffer.Nodes.Count)
        ' create a new stack and
        stNodes.Push(tnBuffer)
        ' push buffered node first.
        Do
            ' let's pop node from stack,
            tnBuffer = stNodes.Pop()
            ' inherit buffered node's
            tnBuffer.Checked = selectedNode.Checked
            ' check state and push
            For i As Integer = 0 To tnBuffer.Nodes.Count - 1
                ' each child on the stack
                stNodes.Push(tnBuffer.Nodes(i))
                ' until there is no node
            Next
        Loop While stNodes.Count > 0
        ' left.
        bMixedState = False
        tnBuffer = selectedNode
        ' re-buffer clicked node.
        While tnBuffer.Parent IsNot Nothing
            ' while we get a parent we
            For Each tnChild As TreeNode In tnBuffer.Parent.Nodes
                ' determine mixed check states
                bMixedState = bMixedState Or (tnChild.Checked <> tnBuffer.Checked)
            Next
            ' and convert current check
            iIndex = CInt(Convert.ToUInt32(tnBuffer.Checked))
            ' state to state image index.
            tnBuffer.Parent.Checked = bMixedState OrElse (iIndex > 0)
            ' set parent's check state and
            If bMixedState Then
                ' state image in dependency
                tnBuffer.Parent.StateImageIndex = IIf(CheckBoxesTriState, 2, 1)

            Else
                ' of mixed state.
                tnBuffer.Parent.StateImageIndex = iIndex
            End If
            ' finally buffer parent and
            tnBuffer = tnBuffer.Parent
            ' loop here.
        End While
    End Sub

    Protected Overloads Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        m_blMouseRelease = True
    End Sub

    Protected Overloads Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        m_blMouseRelease = True
    End Sub

    Protected Overloads Overrides Sub OnNodeMouseClick(ByVal e As TreeNodeMouseClickEventArgs)
        MyBase.OnNodeMouseClick(e)
        Dim iSpacing As Integer
        iSpacing = IIf(ImageList Is Nothing, 0, 18)
        Dim iBoundLeft As Integer = 0
        Dim iBoundRight As Integer = 0
        Dim osVer As String = System.Environment.OSVersion.Version.ToString()
        If osVer.StartsWith("5") Then
            ''Window XP
            iBoundLeft = iSpacing
            iBoundRight = iSpacing

        Else
            'Window 7 or higher
            iBoundLeft = iSpacing + 57
            iBoundRight = iSpacing + 44

        End If
        '''Get location of mouse, if mouse click is "+" or "-" symbol is expand or collapse
        If e.X > e.Node.Bounds.Left - (iBoundLeft) AndAlso e.X < e.Node.Bounds.Left - (iBoundRight) Then

            If e.Node.Nodes.Count > 0 AndAlso m_blMouseRelease Then

                If e.Node.IsExpanded Then
                    e.Node.Collapse()
                    m_blMouseRelease = False
                Else
                    e.Node.Expand()
                    m_blMouseRelease = False
                End If

                Exit Sub
            End If
        End If
        ' if user clicked area
        ' *not* used by the state
        If e.X > e.Node.Bounds.Left - iSpacing OrElse e.X < e.Node.Bounds.Left - (iSpacing + 16) Then
            ' image we can leave here.
            Exit Sub
        End If
        CheckNode(e.Node)
    End Sub
End Class