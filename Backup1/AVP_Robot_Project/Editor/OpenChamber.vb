Public Class OpenChamber
#Region "Class Constants & Variables"
    Private m_FileName As String = String.Empty
    Private m_FileNames As List(Of String)
    Private m_Chamber As String
    Private m_blnDeleteMode As Boolean = False

#End Region

#Region "Property"
    Public Property DeleteMode() As Boolean
        Get
            Return m_blnDeleteMode
        End Get
        Set(ByVal value As Boolean)
            m_blnDeleteMode = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Title
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Title() As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Chamber
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Chamber() As String
        Get
            Return m_Chamber
        End Get
        Set(ByVal value As String)
            m_Chamber = value
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
    ''' OpenChamber_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OpenChamber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.m_listData = AVPLib.ContainerData.GetRecipe(Chamber).ListChamber
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
            If DeleteMode Then
                For Each item As String In lstItems.SelectedItems
                    Me.FileNames.Add(AVPLib.Utils.GetFileName(item, "xml"))
                Next
            Else
                Dim SequenceName As String = lstItems.SelectedItem.ToString()
                Me.FileName = AVPLib.Utils.GetFileName(SequenceName, "xml")
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnOK_Click")
    End Sub
#End Region

    Public Sub New(ByVal isDeleteMode As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        If isDeleteMode Then
            Me.lstItems.SelectionMode = SelectionMode.MultiExtended
            Me.FileNames = New List(Of String)
        Else
            Me.lstItems.SelectionMode = SelectionMode.One
        End If
        DeleteMode = isDeleteMode
        ' Add any initialization after the InitializeComponent() call.

    End Sub

End Class