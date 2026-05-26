Public Class OpenSequence
    Private m_FileName As String
    Private m_FileNames As List(Of String)
    Private m_blnDeleteMode As Boolean = False
    Private m_strTitle As String = String.Empty

#Region "Property"
    '''' <author>
    ''''    	<name> Le Hieu Truc</name>
    ''''    	<date> 2008-09-14</date>
    '''' </author>
    '''' <summary>
    '''' Title
    '''' </summary>
    '''' <value></value>
    '''' <returns></returns>
    '''' <remarks></remarks>
    Public Property Title() As String
        Get
            Return m_strTitle
        End Get
        Set(ByVal value As String)
            m_strTitle = value
            Me.Text = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' FileName
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileName() As String
        Get
            Return m_FileName
        End Get
        Set(ByVal value As String)
            m_FileName = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc</name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' FileName
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileNames() As List(Of String)
        Get
            Return m_FileNames
        End Get
        Set(ByVal value As List(Of String))
            m_FileNames = value
        End Set
    End Property
#End Region

#Region "Load Form"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' OpenSequence_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OpenSequence_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.m_listData = AVPLib.ContainerData.ListSequenceName
            Me.UpdateList()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#End Region

#Region "Buttons Event"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' btnOK_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter btnOK_Click")
        Try
            If m_blnDeleteMode Then
                For Each item As String In lstItems.SelectedItems
                    Me.FileNames.Add(item)
                Next
            Else
                Dim SequenceName As String = lstItems.SelectedItem.ToString()
                Me.FileName = SequenceName & ".xml" 'AVPLib.Utils.GetFileName(SequenceName, "xml")
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnOK_Click")
    End Sub

#End Region

    Public Sub New(ByVal blnIsDeleteMode As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_blnDeleteMode = blnIsDeleteMode
        If m_blnDeleteMode Then
            Me.lstItems.SelectionMode = SelectionMode.MultiExtended
            Me.FileNames = New List(Of String)
        Else
            Me.lstItems.SelectionMode = SelectionMode.One
        End If
        ' Add any initialization after the InitializeComponent() call.
        Me.m_listData = AVPLib.ContainerData.ListSequenceName
    End Sub

End Class