Public Class ListAllUsers
#Region "Members"
    Public Group As String = ""

    Private m_listAllUserNames As ArrayList
    Private m_parentLogin As Login
    Dim m_strSelectedTextListView As String = String.Empty

#End Region

    Public Sub New(ByVal parentLogin As Login)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Add for get user when choose the selected user
        m_parentLogin = parentLogin

    End Sub

#Region "Event"

    Private Sub ListAllUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ' Relocation and resize for form
            Me.Opacity = 1
            'Me.Location = New Point(260, 20)
            Me.Width = 800
            Me.Height = 830

            ' Create size for list view when users is over 20 members
            Dim userWidth As Integer = CInt((Me.lstViewAllUsers1.Width - 1) / 2)

            ' Relocation and resize for button OK and CLOSE
            btnOK.Location = New Point(Me.Width / 2 - Me.btnOK.Width - 50, 10)
            btnClose.Location = New Point(Me.Width / 2 + 50, 10)

            ' Make sure grid view is empty before load
            Me.lstViewAllUsers1.Rows.Clear()
            Me.lstViewAllUsers1.Columns.Clear()

            ' Get all current user
            m_listAllUserNames = AVPLib.ContainerData.ListUser

            ' Count user
            Dim countUser As Integer = 0
            Dim countIndex As Integer = 0

            ' Sort before use
            m_listAllUserNames.Sort()

            ' Invisible header, no need now
            Me.lstViewAllUsers1.ColumnHeadersVisible = False

            ' Use for store user name for first column
            Dim m_firstColumnUserName As ArrayList = New ArrayList()

            For Each Username As String In m_listAllUserNames
                Dim User As AVPLib.DBUser = AVPLib.ContainerData.User(Username)

                ' Store list user name for first column
                m_firstColumnUserName.Add(Username)

                countUser += 1
                If countUser <= 20 Then
                    If countUser = 1 Then
                        Me.lstViewAllUsers1.ColumnCount = 1
                        Me.lstViewAllUsers1.Columns(0).Width = Me.lstViewAllUsers1.Width - 2
                    End If

                    Me.lstViewAllUsers1.Rows.Add(Username)
                Else
                    If countUser = 21 Then
                        Me.lstViewAllUsers1.ColumnCount = 2
                        Me.lstViewAllUsers1.Columns(0).Width = userWidth
                        Me.lstViewAllUsers1.Columns(1).Width = userWidth
                    End If

                    ' Create enty for 2 columns
                    Dim row As String() = New String() {m_firstColumnUserName(countIndex), Username}

                    ' Remove entry for first column then re-add with second column
                    Me.lstViewAllUsers1.Rows.RemoveAt(countIndex)
                    Me.lstViewAllUsers1.Rows.Insert(countIndex, row)

                    countIndex += 1
                End If
            Next

            ' Add empty column if list user is less then 20, advoid blank pop-up
            If countUser <= 20 Then
                For value As Integer = countUser To 19
                    Me.lstViewAllUsers1.Rows.Add("")
                Next
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub ListAllUsers_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        Me.DoClose()
    End Sub

    Private Sub lstViewAllUsers_ColumnWidthChanging(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs)
        e.Cancel = True
        e.NewWidth = lstViewAllUsers1.Columns(e.ColumnIndex).Width
    End Sub

    Private Sub AVPPopUpFrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DoClose()
            Return
        End If
        If e.KeyCode = Keys.Enter Then
            FillSelectedItemsToUserNameLogin()
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            FillSelectedItemsToUserNameLogin()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click, Me.HeaderDoubleClick
        Me.DoClose()
    End Sub

#End Region

#Region "Private method"

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-01-25 </date>
    ''' </author>
    ''' <summary>
    ''' BackColorBaseOnPrivilege
    ''' </summary>
    ''' <remarks></remarks>
    Private Function BackColorBaseOnPrivilege(ByVal privilegeID As Integer) As Color
        Dim backColor As Color = Color.DarkGray

        Try
            If privilegeID = 1 Then
                backColor = Color.Wheat
            ElseIf privilegeID = 2 Then
                backColor = Color.Linen
            ElseIf privilegeID = 3 Then
                backColor = Color.LightCyan
            ElseIf privilegeID = 4 Then
                backColor = Color.Honeydew
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return backColor
    End Function

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-01-25 </date>
    ''' </author>
    ''' <summary>
    ''' AddItemToListView
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddItemToListView(ByVal userName As String, ByVal groupId As Integer, ByVal groupName As String)
        Try
            Dim sorting As String = String.Empty
            If Not String.IsNullOrEmpty(groupName) Then
                sorting = groupName.Substring(0, 1) & userName
            End If
            Dim item As ListViewItem = New ListViewItem(sorting)
            item.BackColor = BackColorBaseOnPrivilege(groupId)
            item.SubItems.Add(userName)
            item.SubItems.Add(groupName)
            'lstViewAllUsers1.Items.Add(item)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-01-27 </date>
    ''' </author>
    ''' <summary>
    ''' FillSelectedItemsToUserNameLogin
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FillSelectedItemsToUserNameLogin()
        Try
            For Each cell As DataGridViewCell In Me.lstViewAllUsers1.SelectedCells
                m_parentLogin.cmbUsername.Text = cell.Value.ToString()
            Next
            ' Close dialog
            Me.Close()
            btnOK.Enabled = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-06-04 </date>
    ''' </author>
    ''' <summary>
    ''' FillSelectedItemsToUserNameLogin
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub lstViewAllUsers1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles lstViewAllUsers1.CellClick
        If lstViewAllUsers1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "" Then
            btnOK.Enabled = False
        Else
            FillSelectedItemsToUserNameLogin()
        End If
    End Sub

#End Region
End Class