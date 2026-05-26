Imports AVP_Robot_Project.ConstantAndEnum
Public Class VatValveController
    Private m_blnIsOnline As Boolean = False
#Region "Properties"
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            txtPressure.Enabled = Not m_blnIsOnline
            txtPressure_Percent.Enabled = Not m_blnIsOnline
            btnTeach.Enabled = Not m_blnIsOnline
            btnAutoZero.Enabled = Not m_blnIsOnline
            btnSizeAdjust.Enabled = Not m_blnIsOnline
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
            'Dim stbTeach As New StatusTextBox(Me.txtTeach)
            Dim stbPressure As New StatusTextBox(Me.txtPressure)
            Dim stbPressure_Percent As New StatusTextBox(Me.txtPressure_Percent)
            Dim sbcStatus As New StatusIGCGButton(Me.Header)
            Dim sbcZeroVatValve As New StatusIGCGButton(Me.btnAutoZero)
            Dim sbcTeach As New StatusIGCGButton(Me.btnTeach)
            Dim sbcSizeAdjust As New StatusIGCGButton(Me.btnSizeAdjust )

            m_stoStatusObject.Name = Me.Name
            'm_stoStatusObject.AddChild(stbTeach)
            m_stoStatusObject.AddChild(stbPressure)
            m_stoStatusObject.AddChild(stbPressure_Percent)
            m_stoStatusObject.AddChild(sbcStatus)
            m_stoStatusObject.AddChild(sbcZeroVatValve)
            m_stoStatusObject.AddChild(sbcTeach)
            m_stoStatusObject.AddChild(sbcSizeAdjust)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    Private Sub txtTeach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPressure.Click, txtPressure_Percent.Click
        PVDSupport.TextboxClick(sender, e, Me.Parent, m_stoStatusObject)
    End Sub
    Private Sub btnAutoZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoZero.Click
        PVDSupport.CommonButtonClick("Auto Zero Button Clicked", sender, Me.Parent, m_stoStatusObject)
    End Sub

    Private Sub btnSizeAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSizeAdjust.Click
        PVDSupport.CommonButtonClick("Size Adjust Button Clicked", sender, Me.Parent, m_stoStatusObject)
    End Sub

    Private Sub btnTeach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTeach.Click
        PVDSupport.CommonButtonClick("Teach Button Clicked", sender, Me.Parent, m_stoStatusObject)
    End Sub

    Public Sub StartProcessing() ''reset editbox to empty
        Me.txtPressure.Text = String.Empty
    End Sub
   
#End Region

   
End Class
