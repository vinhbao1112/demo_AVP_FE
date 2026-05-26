Imports System.ComponentModel

Public Class SL_Info
#Region "Properties"
    Public Event PressureCG_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event Connect_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    Private m_displayPressure As Boolean
    <DefaultValue(False)> _
    Public Property DisplayPressure() As Boolean
        Get
            Return m_displayPressure
        End Get
        Set(ByVal value As Boolean)
            If m_displayPressure = value Then
                Return
            End If

            m_displayPressure = value
            txtInformation.DisplayPressureFont = m_displayPressure

        End Set
    End Property

#End Region

#Region "Protected method"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19</date>
    ''' </author>
    ''' <summary>
    ''' Create status tree to manage status of all objects inside
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim stbInformation As New SL_StatusTextBox(Me.txtInformation)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbInformation)
            txtInformation.ParentStatusObj = m_stoStatusObject
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-19 </date>
    ''' </author>
    ''' <summary>
    ''' Handling control loading event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CGControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtInformation.Width = Me.Width - 12
    End Sub
#End Region

#Region "Public methods"
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-22-23</date>
    ''' </author>
    ''' <summary>
    ''' Set default status to show on GUI when PM disconnect.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDefaultStatus()
        txtInformation.Text = String.Empty
    End Sub
#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Header.ColorText_ErrorStatus = Color.White
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub txtInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInformation.Click
        RaiseEvent PressureCG_Click(sender, e)
    End Sub

    Private Sub Header_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Header.Click
        RaiseEvent Connect_Click(sender, e)
    End Sub
End Class

