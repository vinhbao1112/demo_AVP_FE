Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class PVDStatusBoard
    Protected mouseOffset As Point = New Point(0, 0)
    Protected isDragDrop As Boolean = False

    Protected m_stHeaderStatus As ButtonIGCGControl.DisplayStatus
    Protected m_intHeaderHeight As Integer = 27
    Protected m_intHeaderWidth As Integer = 60
    Protected m_Style As StyleOfBoard = StyleOfBoard.Horizontal
    'Public Event HeaderClickEvent(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event HeaderStatusChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Protected m_blnIsOnline As Boolean = False

    Protected m_useBorderStyle As Boolean = False

    Public Event HeaderClicked As EventHandler

    Public Enum StyleOfBoard
        Horizontal
        Vertical
        Vertical_Right
    End Enum
#Region "Public Properties"
    Public Property HeaderText() As String
        Get
            Return Me.Header.Text
        End Get
        Set(ByVal value As String)
            Me.Header.Text = value
            If Not String.IsNullOrEmpty(value) Then
                Me.Text = String.Empty
            End If
        End Set
    End Property

    <DefaultValue(GetType(StyleOfBoard), "Horizontal")> _
    Public Property HeaderStyle() As StyleOfBoard
        Get
            Return m_Style
        End Get
        Set(ByVal value As StyleOfBoard)
            m_Style = value
            If m_Style = StyleOfBoard.Horizontal Then
                Header.Dock = DockStyle.Top
            ElseIf m_Style = StyleOfBoard.Vertical_Right Then
                Header.Dock = DockStyle.Right
            Else
                Header.Dock = DockStyle.Left
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Get or set text of this control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DefaultValue(GetType(Integer), "27")> _
    Public Property HeaderHeight() As Integer
        Get
            Return m_intHeaderHeight
        End Get
        Set(ByVal value As Integer)
            m_intHeaderHeight = value
            If Me.HeaderStyle = StyleOfBoard.Horizontal Then
                Me.Header.Height = m_intHeaderHeight
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Get or set text of this control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DefaultValue(GetType(Integer), "60")> _
    Public Property Headerwidth() As Integer
        Get
            Return m_intHeaderWidth
        End Get
        Set(ByVal value As Integer)
            m_intHeaderWidth = value
            If Me.HeaderStyle = StyleOfBoard.Vertical Then
                Me.Header.Width = m_intHeaderWidth
            End If
        End Set
    End Property


    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Get or set text of this control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Overrides Property Text() As String
        Get
            Return Header.Text
        End Get
        Set(ByVal value As String)
            Header.Text = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-05-13 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set the font of Header
    ''' </summary>
    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
    Category("Appearance"), DefaultValue(GetType(Font), "Arial, 17px, style=Bold")> _
    Public Property HeaderFont() As Font
        Get
            Return Header.Font
        End Get
        Set(ByVal value As Font)
            Header.Font = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Get or set Font of this control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Property Font() As Font
        Get
            Font = MyBase.Font
        End Get
        Set(ByVal value As Font)
            Try
                MyBase.Font = value
                'Header.Font = MyBase.Font
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Get or set Font of this control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HeaderTextColor() As Color
        Get
            Return Header.ForeColor
        End Get
        Set(ByVal value As Color)
            Try
                Header.ForeColor = value
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try

        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Get or set header backcolor of this control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HeaderStatus() As DisplayStatus
        Get
            Return m_stHeaderStatus
        End Get
        Set(ByVal value As DisplayStatus)
            Try
                m_stHeaderStatus = value
                Me.Header.Status = m_stHeaderStatus
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Get or set visible header of this control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property HeaderVisible() As Boolean
        Get
            HeaderVisible = Header.Visible
        End Get
        Set(ByVal value As Boolean)
            Try
                Header.Visible = value
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-05-05 </date>
    ''' </author>
    ''' <summary>
    ''' Get or set the value indicate the panel use border
    ''' </summary>
    <DefaultValue(GetType(Boolean), "False")> _
    Public Overridable Property UseBorderStyle() As Boolean
        Get
            Return m_useBorderStyle
        End Get
        Set(ByVal value As Boolean)
            m_useBorderStyle = value
        End Set
    End Property

#End Region
#Region "Protected method"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            m_stoStatusObject.Name = Me.Name
            For Each ctrl As Control In Me.Controls

                If ctrl.GetType().Name = "Panel" Then
                    For Each ctrlChild As Control In ctrl.Controls
                        Utils.CreateStatusTree_4Panel(ctrlChild, m_stoStatusObject)
                    Next
                End If
                Utils.CreateStatusTree_4Panel(ctrl, m_stoStatusObject)
            Next
            Dim sbcStatus As New StatusIGCGButton(Me.Header)
            m_stoStatusObject.AddChild(sbcStatus)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

    Friend Overridable Sub Header_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Header.Click
        RaiseEvent HeaderClicked(Me, EventArgs.Empty)
    End Sub

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-05-05 </date>
    ''' </author>
    ''' <summary>
    ''' Paint Event
    ''' </summary>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        If UseBorderStyle Then
            Dim y As Integer = 0
            If HeaderVisible Then
                y = HeaderHeight
            End If

            Utils.PaintBorder(Me, e, y)
        End If
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Raise the HeaderStatusChange event.
    ''' </summary>
    Private Sub Header_StatusChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles Header.StatusChange
        RaiseEvent HeaderStatusChanged(sender, e)
    End Sub
End Class
