Imports AVPLib.ConstEnum
Public Class usrEquipmentName
    Private m_Current As String
    Private m_header As String
    Private m_usrParent As usrWaferFlow
    Private m_indexID As Integer
    Private m_waferFlowName As String = String.Empty
    Private m_bLoadAllRecipe As Boolean = False
    ' to identify the objects in the left and the right
    ' True if it is the left control
    Private m_blIsProcessingStep = True

    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-07-06 </date>
    ''' </author>
    ''' <summary>
    ''' Property of m_usrParent
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WaferFlowForm() As usrWaferFlow
        Get
            Return m_usrParent
        End Get
        Set(ByVal value As usrWaferFlow)
            m_usrParent = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-07-06 </date>
    ''' </author>
    ''' <summary>
    ''' Property of m_blIsStep
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsProcessingStep() As Boolean
        Get
            Return m_blIsProcessingStep
        End Get
        Set(ByVal value As Boolean)
            m_blIsProcessingStep = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-06 </date>
    ''' </author>
    ''' <summary>
    ''' Property of Header
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Header() As String
        Get
            Return m_header
        End Get
        Set(ByVal value As String)
            m_header = value
            'Me.lblEquipment.Text = m_header
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-08-06 </date>
    ''' </author>
    ''' <summary>
    ''' Property of Index
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Index() As Integer
        Get
            Return m_indexID
        End Get
        Set(ByVal value As Integer)
            m_indexID = value
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-17</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates wafer flow name of this control.
    ''' </summary>
    Public Property WaferFlowName() As String
        Get
            Return m_waferFlowName
        End Get
        Set(ByVal value As String)
            m_waferFlowName = value
            Dim isFitted As Boolean
            txtWaferFlow.Text = AVPControls.AVPGraphicsLib.GetFittedText(m_waferFlowName, txtWaferFlow, isFitted)
            If Not isFitted Then
                recipeTooltip.SetToolTip(txtWaferFlow, m_waferFlowName)
            Else
                recipeTooltip.SetToolTip(txtWaferFlow, String.Empty)
            End If
        End Set
    End Property

    'Public Property LoadAllRecipe() As Boolean
    '    Get
    '        Return m_bLoadAllRecipe
    '    End Get
    '    Set(ByVal value As Boolean)
    '        m_bLoadAllRecipe = value
    '    End Set
    'End Property

    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-06 </date>
    ''' </author>
    ''' <summary>
    ''' btnWaferFlow_Click
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Sub btnWaferFlow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWaferFlow.Click
        AVPLib.Log.guiLogger.Info("Enter btnWaferFlow_Click")
        Try
            Dim frm As SelectRecipe = New SelectRecipe()
            frm.SelectedRecipe = Nothing
            frm.StationName = m_header
            ' The same as click on the object
            ' then got focus
            Me.usrEquipmentName_Click(sender, e)
            frm.ShowDialog()
            If frm.DialogResult = DialogResult.OK Then
                Me.WaferFlowName = frm.SelectedRecipe
            End If
            If Me.Parent.Name = "pnlEquipmentRight" Then
                m_usrParent.IsModifiedFlag = True
            End If

            frm.Dispose()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnWaferFlow_Click")
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-06 </date>
    ''' </author>
    ''' <summary>
    ''' txtWaferFlow_GotFocus
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub EquipmentGotFocus()
        Me.BackColor = System.Drawing.SystemColors.Highlight
        If m_usrParent IsNot Nothing Then
            If (Me.IsProcessingStep) Then
                For Each ctlChamber As usrEquipmentName In Me.m_usrParent.pnlEquipmentRight.Controls
                    If Not ctlChamber.Equals(Me) Then
                        ctlChamber.EquipmentLostFocus()
                    End If
                Next
            Else
                For Each ctlChamber As usrEquipmentName In Me.m_usrParent.pnlEquipmentLeft.Controls
                    If Not ctlChamber.Equals(Me) Then
                        ctlChamber.EquipmentLostFocus()
                    End If
                Next
            End If
        End If
    End Sub
    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-06 </date>
    ''' </author>
    ''' <summary>
    ''' txtWaferFlow_LostFocus
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Sub EquipmentLostFocus()
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
    End Sub

    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-07-06 </date>
    ''' </author>
    ''' <summary>
    ''' usrEquipmentName_Click
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Sub usrEquipmentName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click, _
                                       txtWaferFlow.Click
        Try
            ' If the step in the right pannel was selected
            If (Me.IsProcessingStep) Then
                m_usrParent.SelectedStep = Me
                If m_usrParent IsNot Nothing Then
                    m_usrParent.enableStartButton(True)
                    m_usrParent.Refresh()
                End If
            Else
                ' Just do nothing
                'Aigner
                If Me.Name.Contains(Equipments.IBE.ToString()) = True Then
                    If m_usrParent IsNot Nothing Then
                        m_usrParent.CurrentEquipmentID = Equipments.IBE
                    End If
                ElseIf Me.Name.Contains(Equipments.PVD.ToString()) = True Then
                    If m_usrParent IsNot Nothing Then
                        m_usrParent.CurrentEquipmentID = Equipments.PVD
                    End If
                ElseIf Me.Name.Contains(Equipments.Aligner.ToString()) = True Then
                    If m_usrParent IsNot Nothing Then
                        m_usrParent.CurrentEquipmentID = Equipments.Aligner
                    End If
                    'Chamber 1
                ElseIf Me.Name.Contains(Equipments.Chamber1.ToString()) = True Then
                    If m_usrParent IsNot Nothing Then
                        m_usrParent.CurrentEquipmentID = Equipments.Chamber1
                    End If
                    'Chamber 2
                ElseIf Me.Name.Contains(Equipments.Chamber2.ToString()) = True Then
                    If m_usrParent IsNot Nothing Then
                        m_usrParent.CurrentEquipmentID = Equipments.Chamber2
                    End If
                    'Chamber 3
                ElseIf Me.Name.Contains(Equipments.Chamber3.ToString()) = True Then
                    If m_usrParent IsNot Nothing Then
                        m_usrParent.CurrentEquipmentID = Equipments.Chamber3
                    End If
                End If
            End If
            
            EquipmentGotFocus()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.EquipmentLostFocus()

    End Sub
    Public Sub New(ByVal usrParent As usrWaferFlow)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_usrParent = usrParent
        ' Add any initialization after the InitializeComponent() call.
        Me.EquipmentLostFocus()

    End Sub

    
End Class
