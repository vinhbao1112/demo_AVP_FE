Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports AVP_Robot_Project.ConstantAndEnum
Public Class SL_TurboPump
#Region "Class Constants & Variables"
    Public Enum DisplayStyle
        [Left] = 0
        [Right] = 1
    End Enum

    Private m_intDisplayStyle As DisplayStyle
    Private m_blnButtonVisible As Boolean
    Private Const STRING_OFF As String = "Off"
    Private Const STRING_ON As String = "On"
#End Region

#Region "Public Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-26</date>
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
                If (value <> m_intDisplayStyle) Then
                    m_intDisplayStyle = value
                    ' Me.PositionControls()
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-08-28</date>
    ''' </author>    
    ''' <summary>
    ''' Get or set value to align all child controls inside this user control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ButtonVisible() As Boolean
        Get
            Return m_blnButtonVisible
        End Get
        Set(ByVal value As Boolean)
            Try
                If (value <> m_blnButtonVisible) Then
                    m_blnButtonVisible = value
                    'Me.PositionControls()
                    'btnOn.Visible = m_blnButtonVisible
                    'btnRegen.Visible = m_blnButtonVisible
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property
#End Region

#Region "Constructor & Destructor"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Initiate cryo control
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_intDisplayStyle = DisplayStyle.Left
    End Sub
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
            Dim stbT As New StatusTextBox(Me.txtT)
            Dim sbcWaterPumpStatus As New StatusIGCGButton(Header)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbT)
            m_stoStatusObject.AddChild(sbcWaterPumpStatus)

            txtT.ParentStatusObj = m_stoStatusObject
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

    Private Sub bicWaterPump_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PVDSupport.CommonButtonClick("Water Pump", sender, Me.Parent, m_stoStatusObject)
    End Sub
End Class
