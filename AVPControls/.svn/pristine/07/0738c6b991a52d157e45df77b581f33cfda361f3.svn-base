Imports System.ComponentModel

''' <author>
'''     <name>Hai Tran</name>
'''     <date>2015-11-20</date>
''' </author>
''' <summary>
''' Select waferflow, recipe.
''' </summary>
''' <remarks></remarks>
Public Class SelectDialog
    Protected m_selectedValue As String = String.Empty
    Protected m_selectedValues As List(Of String)
    Protected m_listData As ArrayList
    Protected m_defaultSelectedValue As String
    Protected m_IsResultFilterMultiValue As Boolean = True

#Region "Properties"
    Protected Overrides ReadOnly Property DefaultSize() As System.Drawing.Size
        Get
            Return New Size(500, 555)
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property DefaultSelectedValue() As String
        Get
            Return m_defaultSelectedValue
        End Get
        Set(ByVal value As String)
            m_defaultSelectedValue = value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property SelectedValue() As String
        Get
            Return m_selectedValue
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property SelectValues() As List(Of String)
        Get
            Return m_selectedValues
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property ListData() As ArrayList
        Get
            Return m_listData
        End Get
        Set(ByVal value As ArrayList)
            m_listData = value
            UpdateList()
        End Set
    End Property

    <DefaultValue(True), Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property EnableFilter() As Boolean
        Get
            Return txtFilter.Visible
        End Get
        Set(ByVal value As Boolean)
            txtFilter.Visible = value
            If value Then
                pnlTop.Height = 32
            Else
                pnlTop.Height = 10
            End If
        End Set
    End Property
    <DefaultValue(True), Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property IsResultFilterMultiValue() As Boolean
        Get
            Return m_IsResultFilterMultiValue
        End Get
        Set(ByVal value As Boolean)
            m_IsResultFilterMultiValue = value
        End Set
    End Property
#End Region

#Region "Methods"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-20</date>
    ''' </author>
    ''' <summary>
    ''' Update list box by specified data.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Overloads Sub UpdateList(ByVal listData As ArrayList)
        Try
            Me.lstItems.SuspendLayout()

            Me.lstItems.Items.Clear()

            ' Add data to listbox.
            If listData IsNot Nothing Then
                For Each item As Object In listData
                    Me.lstItems.Items.Add(item.ToString())
                Next
            End If

            ' Enable/Disable OK button.
            If Me.lstItems.Items.Count > 0 Then
                Me.lstItems.SelectedIndex = 0
                Me.btnOK.Enabled = True
            Else
                Me.btnOK.Enabled = False
            End If

            Me.lstItems.ResumeLayout(True)
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-20</date>
    ''' </author>
    ''' <summary>
    ''' Update list box by current data.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Overloads Sub UpdateList()
        ' Sort data before add to list box.
        If Me.m_listData IsNot Nothing Then
            Me.m_listData.Sort()
        End If

        ' Update list box.
        Me.UpdateList(Me.m_listData)

        ' Set default selected value.
        If Not String.IsNullOrEmpty(Me.m_defaultSelectedValue) Then
            If Me.lstItems.Items.Count > 0 AndAlso Me.lstItems.Items.Contains(Me.m_defaultSelectedValue) Then
                Me.lstItems.SelectedItem = Me.m_defaultSelectedValue
            End If
        End If

    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-20</date>
    ''' </author>
    ''' <summary>
    ''' Set dialog result and close form.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub DoClose()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
#End Region

#Region "Events"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-20</date>
    ''' </author>
    ''' <summary>
    ''' Handle Close button click event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DoClose()
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-20</date>
    ''' </author>
    ''' <summary>
    ''' Handle OK button click event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            If Me.lstItems.SelectedItem IsNot Nothing Then
                Me.m_selectedValue = Me.lstItems.SelectedItem.ToString()
            Else
                Me.m_selectedValue = String.Empty
            End If

            If Me.lstItems.SelectedItems IsNot Nothing Then
                If Me.m_selectedValues Is Nothing Then
                    Me.m_selectedValues = New List(Of String)
                Else
                    Me.m_selectedValues.Clear()
                End If
                For Each item As Object In Me.lstItems.SelectedItems
                    Me.m_selectedValues.Add(item.ToString())
                Next
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-20</date>
    ''' </author>
    ''' <summary>
    ''' Handle filter text changed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        Try
            Dim tmpList As ArrayList = AVPUtils.GetFilter(Me.txtFilter.Text, Me.m_listData, IsResultFilterMultiValue)
            Me.UpdateList(tmpList)
            tmpList.Clear()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-20</date>
    ''' </author>
    ''' <summary>
    ''' Handle key down event.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SelectDialog_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If Not Me.txtFilter.Focused AndAlso Char.IsLetterOrDigit(Convert.ToChar(e.KeyValue)) Then
                Me.txtFilter.Focus()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-20</date>
    ''' </author>
    ''' <summary>
    ''' Update list box when load.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SelectDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.UpdateList()
    End Sub

    ''' <author>
    '''     <name>Dua Tran</name>
    '''     <date>2017-01-19</date>
    ''' </author>
    ''' <summary>
    ''' Click txtFilter.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.Click
        Try
            Dim pad As New KeyPad
            pad.IsEnableTextChange = True
            pad.StartPosition = FormStartPosition.Manual
            pad.Location = New Point(CInt((Screen.PrimaryScreen.Bounds.Width - pad.Width) / 2), Screen.PrimaryScreen.Bounds.Height - pad.Height - 90)
            pad.DisplayKeypad(txtFilter, "Enter Your Filter")
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2017-01-19</date>
    ''' </author>
    ''' <summary>
    ''' Action on form is shown.
    ''' </summary>
    Private Sub SelectDialog_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        txtFilter.Focus()
    End Sub

#End Region

End Class