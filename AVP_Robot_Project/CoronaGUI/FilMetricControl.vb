Public Class FilMetricControl
    Private m_blnIsOnline As Boolean = False
    Private m_listRecipe As ArrayList = New ArrayList

    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            btnGotoBaseLine.Enabled = Not (m_blnIsOnline)
            txtProcessRecipe.Enabled = Not (m_blnIsOnline)
            btnGotoThickness.Enabled = Not (m_blnIsOnline)
            btnMeasure.Enabled = Not (m_blnIsOnline)
            txtMeasure.Enabled = Not (m_blnIsOnline)


        End Set
    End Property

    Private Sub txtProcessRecipe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcessRecipe.Click
        AVPLib.Log.guiLogger.Info("Enter txtRecipe_Click")
        Try

            Dim frm As SelectRecipe = New SelectRecipe()
            frm.StationName = Me.Parent.Name
            frm.IsSetListRecipeFromPM = False
            LoadListRecipe()
            frm.ListData = m_listRecipe
            frm.ShowDialog()
            If frm.DialogResult = DialogResult.OK Then
                Me.txtProcessRecipe.Text = frm.SelectedRecipe
                If Me.txtProcessRecipe.ParentStatusObj IsNot Nothing Then
                    If Me.txtProcessRecipe.TypeOfChamberSupport = TypeOfAVPChamber.PVD4 Then
                        Dim strname As String = Me.txtProcessRecipe.AccessibleName.Replace(" ", "")
                        Me.txtProcessRecipe.ParentStatusObj.RequestStatus(strname, Me.txtProcessRecipe.Text)
                    Else
                        Me.txtProcessRecipe.ParentStatusObj.RequestStatus(Me.Name, Me.txtProcessRecipe.Text)
                    End If
                End If
            End If
            frm.Dispose()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txtRecipe_Click")
    End Sub

    Private Sub LoadListRecipe()
        m_listRecipe.Clear()
        If Me.txtProcessListRecipe.Tag <> String.Empty Then
            Dim lstRecipe() As String = Me.txtProcessListRecipe.Tag.Split(";")
            For i As Int16 = 0 To lstRecipe.Length - 1
                m_listRecipe.Add(lstRecipe(i))
            Next
        End If
    End Sub

    Public Property ListRecie() As ArrayList
        Get
            Return m_listRecipe
        End Get
        Set(ByVal value As ArrayList)
            m_listRecipe = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''     <date> 2017-05-26</date>
    ''' </author>
    ''' <summary>
    ''' Handler event text changed txtMeasure textbox.
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Private Sub txtMeasure_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMeasure.TextChanged
        Try
            If txtMeasure.Text <> String.Empty AndAlso Not txtMeasure.Text.Contains("A") Then
                txtMeasure.Text = txtMeasure.Text & "A"
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
