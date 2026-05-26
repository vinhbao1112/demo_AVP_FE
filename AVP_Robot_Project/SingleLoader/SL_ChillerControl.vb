Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum

Public Class SL_ChillerControl
#Region "Class Constants & Variables"
    Private m_blnChillerModel As String = String.Empty
#End Region

#Region "Public Properties"
    Public Property ChillerModel() As String
        Get
            Return m_blnChillerModel
        End Get
        Set(ByVal value As String)
            m_blnChillerModel = value
            If m_blnChillerModel = "Prodeus4000" Then
                Me.Text = "Chiller (Prodeus 4000)"
                btnChillerOnOff.Visible = False
                txtChillerTempSP.Visible = False
                Label2.Location = New Point(5, 36)
                txtChillerTempRB.Location = New Point(61, 31)
                Label3.Location = New Point(137, 36)
                txtChillerFlowRateRB.Location = New Point(232, 31)
                Me.Size = New Size(308, 60)
            Else
                Me.Size = New Size(256, 60)
            End If
        End Set
    End Property
    'Private m_blnIsOnline As Boolean = False
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            btnChillerOnOff.Enabled = m_blnIsOnline
            txtChillerTempSP.Enabled = m_blnIsOnline
        End Set
    End Property
#End Region

#Region "Constructor & Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-17</date>
    ''' </author>
    ''' <summary>
    ''' Initiate cryo control
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

      
    End Sub
#End Region

#Region "Protected method"
    Protected Overrides Sub CreateStatusTree()
        Try
            Dim sbcStatus As New StatusIGCGButton(Me.Header)
            Dim stbChillerTempSP As New SL_StatusTextBox(txtChillerTempSP)
            Dim stbChillerTempRB As New SL_StatusTextBox(txtChillerTempRB)
            Dim sbtChillerOnOff As New SL_StatusButton(btnChillerOnOff)
            Dim sbtChillerFlowRate As New SL_StatusTextBox(txtChillerFlowRateRB)
            m_stoStatusObject.Name = Me.Name

            m_stoStatusObject.AddChild(sbcStatus)
            m_stoStatusObject.AddChild(stbChillerTempSP)
            m_stoStatusObject.AddChild(stbChillerTempRB)
            m_stoStatusObject.AddChild(sbtChillerOnOff)
            m_stoStatusObject.AddChild(sbtChillerFlowRate)

            txtChillerTempSP.ParentStatusObj = m_stoStatusObject
            txtChillerTempRB.ParentStatusObj = m_stoStatusObject
            btnChillerOnOff.ParentStatusObj = m_stoStatusObject
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

End Class
