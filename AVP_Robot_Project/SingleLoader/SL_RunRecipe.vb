Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Public Class SL_RunRecipe
#Region "Properties"
    Private m_RecipeName As String
    Private m_Chamber As String
    Private m_blnReal_Device_Enable As Boolean = False
    Private m_sf As StringFormat = Nothing
    Private m_RecipeNameGraphics As Graphics
#End Region


#Region "Protected method"
    Public Property Real_Device_Enable() As Boolean
        Get
            Return m_blnReal_Device_Enable
        End Get
        Set(ByVal value As Boolean)
            m_blnReal_Device_Enable = value
            If m_blnReal_Device_Enable Then
                btnPause.Visible = False
                btnStart.Left = 30
                btnAbort.Left = 160
            Else
                btnPause.Visible = True
                btnStart.Left = 3
                btnAbort.Left = 182
            End If
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Property of Chamber
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RecipeName() As String
        Get
            Return m_RecipeName
        End Get
        Set(ByVal value As String)
            m_RecipeName = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' Property of Chamber
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Chamber() As String
        Get
            Return m_Chamber
        End Get
        Set(ByVal value As String)
            m_Chamber = value
        End Set
    End Property
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
            Dim sbcStart As New StatusIGCGButton(Me.btnStart)
            Dim sbcPause As New StatusIGCGButton(Me.btnPause)
            Dim sbcStatus As New StatusIGCGButton(Me.Header)
            Dim sbcAbort As New StatusIGCGButton(Me.btnAbort)
            Dim stbRecipe As New SL_StatusTextBox(Me.txtProcessRecipe)
            m_stoStatusObject.Name = Me.Name

            m_stoStatusObject.AddChild(sbcStart)
            m_stoStatusObject.AddChild(sbcPause)
            m_stoStatusObject.AddChild(sbcStatus)
            m_stoStatusObject.AddChild(sbcAbort)
            m_stoStatusObject.AddChild(stbRecipe)

            ' For calculating the size of Recipe Name textbox
            m_sf = New StringFormat(StringFormatFlags.NoWrap)
            m_sf.LineAlignment = StringAlignment.Center
            m_sf.Alignment = StringAlignment.Near
            m_sf.Trimming = StringTrimming.EllipsisCharacter
            m_RecipeNameGraphics = txtProcessRecipe.CreateGraphics()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region


#Region "Events – Buttons – Forms…"

    Private Sub UpdateRecipeNameText()
        ' Calculate the fitted string
        Dim strLotIDCharFitted As Integer
        Dim linesFitted As Integer
        Dim f As Font = Me.txtProcessRecipe.Font
        Dim rect As Rectangle = txtProcessRecipe.ClientRectangle
        m_RecipeNameGraphics.MeasureString(txtProcessRecipe.Text, f, rect.Size, m_sf, strLotIDCharFitted, linesFitted)

        ' Use "..." for long string
        If strLotIDCharFitted < txtProcessRecipe.Text.Length Then
            txtProcessRecipe.Text = txtProcessRecipe.Text.Substring(0, strLotIDCharFitted) & "..."
            ValueToolTip.SetToolTip(txtProcessRecipe, Me.RecipeName)
        Else
            ValueToolTip.SetToolTip(txtProcessRecipe, "")
        End If

    End Sub

    Private Sub txtProcessRecipe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter txtRecipe_Click")
        Try
            Dim frm As SelectRecipe = New SelectRecipe()
            frm.StationName = Me.Parent.Name
            frm.ShowDialog()
            If frm.DialogResult = DialogResult.OK Then
                Me.Chamber = frm.StationName
                Me.RecipeName = frm.SelectedRecipe
                Me.txtProcessRecipe.Text = frm.SelectedRecipe '
                Me.UpdateRecipeNameText() ' "..." for long string
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.AVPMainScreen, "[" + frm.StationName + "]Select recipe " + Me.RecipeName)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave txtRecipe_Click")
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        AVPLib.Log.guiLogger.Info("Enter btnStart_Click")
        Try
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(PVD + "." + btnStart.Name + "." + btnStart.Text)

            If Me.btnStart.Text = "Stop" Then
                If Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Information) = DialogResult.OK Then
                    If Me.btnPause.Text = "Resume" Then btnPause.Text = "Pause"
                    m_stoStatusObject.RequestStatus(Me.btnPause.Name, "Stop")
                    Me.btnStart.Text = "Stoping"
                    Me.btnPause.Enabled = False
                    Me.btnAbort.Enabled = False
                    Me.btnStart.Enabled = False
                End If
            ElseIf Me.btnStart.Text = "Start" And Me.RecipeName.Length > 0 Then
                Dim chamberpnl As PVDPanel = ContainerForm.ChamberPanel(Me.Parent.Name)
                Dim IsPMIsoValveClose As Boolean = AVPLib.Utils.IsChamberSlitValveClose(Me.Parent.Name)
                If chamberpnl.ChuckControl.bicWaferInside.Visible AndAlso IsPMIsoValveClose Then
                    If Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Information) = DialogResult.OK Then
                        m_stoStatusObject.RequestStatus(Me.btnPause.Name, Me.RecipeName + "(" + AVPLib.Utils.chamberID2ChamberName(Me.Parent.Name) + ")")
                        Me.btnStart.Text = "Starting"
                        Me.btnPause.Enabled = False
                        Me.btnAbort.Enabled = False
                        Me.btnStart.Enabled = False
                        Dim ReplyValues As ArrayList = New ArrayList()
                        Dim strReplyValue As String = Me.RecipeName
                        ReplyValues.Add(strReplyValue)

                        Dim PropertyNames As ArrayList = New ArrayList()

                        PropertyNames.Add("Recipe")
                        AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.Parent.Name, PropertyNames, ReplyValues)
                    End If
                ElseIf (Not IsPMIsoValveClose) Then

                    Utils.ShowAVPMessageBox("Split Valve is not close", Me.Name, MessageBoxIcon.Stop)
                Else
                    strMessageText = AVPLib.ContainerData.GetMessageText(PVD + "." + btnStart.Name + "." + btnStart.Text + "." + "NoWafer")
                    Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Stop)
                End If
            ElseIf Me.btnStart.Text = "Starting" Or btnStart.Text = "Stoping" Then
                strMessageText = AVPLib.ContainerData.GetMessageText(PVD + "." + "Processing")
                'MessageBox.Show(strMessageText, Me.Name, MessageBoxButtons.OK)
                Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Information, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnStart_Click")
    End Sub

    Private Sub btnPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPause.Click
        AVPLib.Log.guiLogger.Info("Enter btnPause_Click")
        Try
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(PVD + "." + btnPause.Name + "." + btnPause.Text)

            If Me.btnPause.Text = "Resume" Then
                If Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Information) = DialogResult.OK Then
                    Me.btnPause.Text = "Resuming"
                    Me.btnPause.Enabled = False
                    Me.btnAbort.Enabled = False
                    Me.btnStart.Enabled = False
                    m_stoStatusObject.RequestStatus(Me.btnPause.Name, "Resume")
                End If
            ElseIf Me.btnPause.Text = "Pause" And Me.btnStart.Text = "Stop" Then
                If Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Information) = DialogResult.OK Then
                    Me.btnPause.Text = "Pausing"
                    Me.btnPause.Enabled = False
                    Me.btnAbort.Enabled = False
                    Me.btnStart.Enabled = False
                    m_stoStatusObject.RequestStatus(Me.btnPause.Name, "Pause")
                End If
            ElseIf Me.btnPause.Text = "Pausing" Or btnPause.Text = "Resuming" Then
                strMessageText = AVPLib.ContainerData.GetMessageText(PVD + "." + "Processing")
                'MessageBox.Show(strMessageText, Me.Name, MessageBoxButtons.OK)
                Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Information, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnPause_Click")
    End Sub

    Private Sub btnAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbort.Click
        AVPLib.Log.guiLogger.Info("Enter btnPause_Click")
        Try
            Dim strMessageText As String = AVPLib.ContainerData.GetMessageText(PVD + "." + btnAbort.Name)
            ''recipe is running
            If Me.btnPause.Text = "Pause" AndAlso btnStart.Text = "Stop" Then
                If Utils.ShowAVPMessageBox(strMessageText, Me.Name, MessageBoxIcon.Information) = DialogResult.OK Then
                    m_stoStatusObject.RequestStatus(Me.btnAbort.Name, "Abort")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnPause_Click")
    End Sub
#End Region

    Protected Overrides Sub Finalize()
        m_RecipeNameGraphics.Dispose()
        MyBase.Finalize()
    End Sub

    Private Sub txtProcessRecipe_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcessRecipe.MouseHover
        ValueToolTip.Active = False
        ValueToolTip.Active = True
    End Sub
End Class
