Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPControls

Public Class SL_PowerPanel
    Public ParentStatusObj As StatusObject = Nothing
    'Private m_blnIsOnline As Boolean = False

    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            btnACPower.Enabled = Not m_blnIsOnline
            btnGrid.Enabled = Not m_blnIsOnline
            btnPBN.Enabled = Not m_blnIsOnline
            btnRFPower.Enabled = Not m_blnIsOnline
        End Set
    End Property
#Region "Protected method"
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-19</date>
        ''' </author>
        ''' <summary>
        ''' Create status tree to manage status of all objects inside
        ''' </summary>

    Protected Overrides Sub CreateStatusTree()
        Try
            Dim sbtACPower As New SL_StatusButton(btnACPower)
            Dim sbtGrid As New SL_StatusButton(btnGrid)
            Dim sbtPBN As New SL_StatusButton(btnPBN)
            Dim sbtRFPower As New SL_StatusButton(btnRFPower)
           
            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(sbtACPower)
            m_stoStatusObject.AddChild(sbtGrid)
            m_stoStatusObject.AddChild(sbtPBN)
            m_stoStatusObject.AddChild(sbtRFPower)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
   
#Region "Private methods"
    Private Sub SL_Power_Panel_Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles btnACPower.Click, btnGrid.Click, btnPBN.Click, btnRFPower.Click
        SL_Support.ButtonClick(sender, Me.Name, m_stoStatusObject)
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
        btnACPower.Status = SL_CustomButton.DisplayStatus.Off
        btnGrid.Status = SL_CustomButton.DisplayStatus.Off
        btnPBN.Status = SL_CustomButton.DisplayStatus.Off
        btnRFPower.Status = SL_CustomButton.DisplayStatus.Off
    End Sub
#End Region
End Class
