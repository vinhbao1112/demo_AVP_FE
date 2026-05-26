Imports System.ComponentModel

Public Class AppInfoPanel
    Private m_toolID As String = "ABC"
    Private m_releaseNo As String = "AVP Release No"

    ''' <summary>
    ''' Gets or sets the tool ID value.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), "ABC")> _
    Public Property ToolID() As String
        Get
            Return m_toolID
        End Get
        Set(ByVal value As String)
            If m_toolID <> value Then
                m_toolID = value

                Try
                    Dim iLength As Integer = m_toolID.Length
                    If iLength > txtAVPReleaseNo.MaxLength Then
                        iLength = txtAVPReleaseNo.MaxLength
                    End If
                    txtAVPReleaseNo.Text = m_toolID.ToUpper().Substring(0, iLength)
                Catch ex As Exception
                    Logger.Error(ex.ToString())
                    txtAVPReleaseNo.Text = m_toolID.ToUpper()
                End Try

                txtAVPReleaseNo.ForeColor = Color.Blue
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the release no value.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), "AVP Release No")> _
    Public Property ReleaseNo() As String
        Get
            Return m_releaseNo
        End Get
        Set(ByVal value As String)
            If m_releaseNo <> value Then
                m_releaseNo = value
                lblTitle.Text = m_releaseNo
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-04-13</date>
    ''' </author>
    ''' <summary>
    ''' Handle click txtAVPReleaseNO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtAVPReleaseNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim fullVersionInfoFrm As New FullVersionPopupForm()
            fullVersionInfoFrm.ToolID = m_toolID.ToUpper()
            fullVersionInfoFrm.ShowDialog()
            fullVersionInfoFrm.Dispose()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub
End Class
