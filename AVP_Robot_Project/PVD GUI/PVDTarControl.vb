Public Class PVDTarControl
#Region "Properties"
    Private m_blnTargetInstall As Boolean = True
    Private m_blnIsOnline As Boolean = False
    Public Property TargetInstalled() As Boolean
        Get
            Return m_blnTargetInstall
        End Get
        Set(ByVal value As Boolean)
            m_blnTargetInstall = value
            lblTar.Visible = value
            lblTargetMaterial.Visible = value

        End Set
    End Property
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            bicPlasmaIgniter.Enabled = Not m_blnIsOnline
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
            'Dim stbInformation As New StatusTextBox(Me.txtInfor)
            Dim sbcPlasma As New StatusIGCGButton(Me.bicPlasmaIgniter)

            m_stoStatusObject.Name = Me.Name
            'm_stoStatusObject.AddChild(stbInformation)
            m_stoStatusObject.AddChild(sbcPlasma)
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
    Private Sub CGControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub bicPlasmaIgniter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bicPlasmaIgniter.Click
        Dim strLogMessage As String = String.Empty
        strLogMessage = Replace(CType(sender, ButtonIGCGControl).Name, "bic", "")
        strLogMessage = Replace(strLogMessage, "btn", "")

        If CType(sender, ButtonIGCGControl).Status = DisplayStatus.Off Then
            strLogMessage = "Open " + strLogMessage
        Else
            strLogMessage = "Close " + strLogMessage
        End If
        PVDSupport.CommonButtonClick(strLogMessage, sender, Me.Parent, m_stoStatusObject)
    End Sub
#End Region

  
End Class
