Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports AVPControls

Public Class PVDStatusPanel

#Region "Class Constants & Variables"
    Protected m_stoStatusObject As StatusObject
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Get status of this control
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property Status() As StatusObject
        Get
            If m_stoStatusObject.Name Is Nothing Then
                m_stoStatusObject.Name = Me.Name
                Me.CreateStatusTree()
            End If
            Return m_stoStatusObject
        End Get
    End Property
#End Region

#Region "Constructor and destructor"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Initilize this status board control
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_stoStatusObject = New StatusObject()
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
    Protected Overridable Sub CreateStatusTree()
        Try
            m_stoStatusObject.Name = Me.Name
            For Each ctrl As Control In Me.Controls
                Utils.CreateStatusTree_4Panel(ctrl, m_stoStatusObject)
            Next
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region
#Region "Events – Buttons – Forms…"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Handling control loading event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub StatusPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CreateStatusTree()
    End Sub
#End Region
End Class
