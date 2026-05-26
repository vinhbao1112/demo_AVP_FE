Public Class CreateGEMWaferIDPopUp
#Region "Const, variables "
    Const GEMWAFER_ID_HEIGHT As Integer = 30
    Const GEMWaferName As String = "GEMWaferID"
    Const MAX_WAFERS As Integer = 26
    Private m_intNumberOfWafer As Integer = MAX_WAFERS
    Private m_strLoadLockName As String = ConstantAndEnum.LOAD_LOCK_A
    Private m_listOfGEMWaferId As List(Of String) = Nothing
    Private m_objLLElevator As AVPLib.DataManagerment.LLElevator = Nothing

    Public Property NumberOfWafer() As Integer
        Get
            Return m_intNumberOfWafer
        End Get
        Set(ByVal value As Integer)
            m_intNumberOfWafer = value
        End Set
    End Property

    Public Property LoadLockName() As String
        Get
            Return m_strLoadLockName
        End Get
        Set(ByVal value As String)
            m_strLoadLockName = value
            If m_strLoadLockName = ConstantAndEnum.LOAD_LOCK_A Then
                m_objLLElevator = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLAElevator.ToString())
            End If
        End Set
    End Property

    Public Property ListOfGEMWaferID() As List(Of String)
        Get
            Return m_listOfGEMWaferId
        End Get
        Set(ByVal value As List(Of String))
            m_listOfGEMWaferId = value
        End Set
    End Property

    Private Sub CreateGEMWaferIDPopUp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            SaveLoadGEMWaferID(False)
           
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region
  
#Region "Initialize"
    Public Sub New(ByVal strLoadLockName As String, ByVal iNumberOfWafer As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        m_intNumberOfWafer = iNumberOfWafer
        m_strLoadLockName = strLoadLockName
        If NumberOfWafer <= 12 Then
            Me.Height += GEMWAFER_ID_HEIGHT * (NumberOfWafer)
        Else
            Me.Height += GEMWAFER_ID_HEIGHT * (NumberOfWafer / 2 + (NumberOfWafer Mod 2))
        End If

        m_listOfGEMWaferId = New List(Of String)

        If m_strLoadLockName = ConstantAndEnum.LOAD_LOCK_A Then
            m_objLLElevator = AVPLib.DataManagerment.EquipmentManager.GetEquipment(AVPLib.ConstEnum.Equipments.LLAElevator.ToString())
        End If

        For i As Integer = NumberOfWafer To 1 Step -1
            Dim objGEMWaferID As AVP_Robot_Project.GEMWaferID = New AVP_Robot_Project.GEMWaferID
            With objGEMWaferID
                .Dock = System.Windows.Forms.DockStyle.Top
                .Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                .GEMWaferID = ""
                .Name = GEMWaferName & i.ToString()
                .Size = New System.Drawing.Size(514, 30)
                .TabIndex = i
                
                .WaferID = IIf(m_strLoadLockName = ConstantAndEnum.LOAD_LOCK_A, "A", "B") & i.ToString("00")

                If m_objLLElevator.ListOfWaferInfo(i - 1) Is Nothing OrElse _
          m_objLLElevator.ListOfWaferInfo(i - 1).WaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferNone Then
                    .DisableDefine = True
                End If
                
            End With

            AddHandler objGEMWaferID.AutoWaferIDPress, AddressOf HandleKeyEnterPress

            If NumberOfWafer > 12 Then
                If i > NumberOfWafer / 2 Then
                    Me.pnlRight.Controls.Add(objGEMWaferID)
                Else
                    Me.pnlLeft.Controls.Add(objGEMWaferID)
                End If
            Else
                With Me.pnlSequence.Controls
                    .Remove(pnlRight)
                    .Remove(pnlLeft)
                    .Add(objGEMWaferID)
                End With
            End If


        Next

    End Sub
#End Region

#Region "Methods/Subs"
    '  ''' <author>
    '''    	<name> Truc Lee </name>
    '''    	<date>2014-05-15</date>
    ''' </author>
    ''' <summary>
    ''' Save/Load Gem wafer id
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SaveLoadGEMWaferID(ByVal blnSaveOption As Boolean)
        Try
            If m_objLLElevator Is Nothing Then
                Exit Sub
            End If
            '''''''
            For Each ctrl As Control In pnlSequence.Controls
                If ctrl.GetType().Name = "Panel" Then
                    For Each chilctrl As Control In CType(ctrl, System.Windows.Forms.Panel).Controls
                        If Not chilctrl.Name.Contains(GEMWaferName) Then
                            Continue For
                        End If
                        SaveToLLElevator(chilctrl, blnSaveOption)
                    Next

                Else
                    If Not ctrl.Name.Contains(GEMWaferName) Then
                        Continue For
                    End If
                    SaveToLLElevator(ctrl, blnSaveOption)
                End If
            Next
            m_objLLElevator.UpdateGEMWaferMapInfo()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub SaveToLLElevator(ByVal ctrl As Control, ByVal blnSaveOption As Boolean)
        Try
            Dim index As Integer = 0
            '''''''''''''''''''''''
            Dim strTemp As String = ctrl.Name.Replace(GEMWaferName, "")
            Integer.TryParse(strTemp, index)
            If index > 0 AndAlso index < MAX_WAFERS Then
                ''
                With CType(ctrl, GEMWaferID)
                    If blnSaveOption Then
                        'Save back to hash
                        m_objLLElevator.MappingGEMWaferID(.WaferID) = .GEMWaferID
                    Else
                        'Load GEM WaferID
                        If m_objLLElevator.MappingGEMWaferID.ContainsKey(.WaferID) Then
                            'if contain
                            .GEMWaferID = m_objLLElevator.MappingGEMWaferID(.WaferID)
                        Else
                            'if not ->add new one
                            m_objLLElevator.MappingGEMWaferID.Add(.WaferID, "")
                        End If
                    End If
                End With
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Events"
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            SaveLoadGEMWaferID(True)
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnOK_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnOK.KeyDown
        Me.Close()
    End Sub
    ''' <author>
    '''    	<name> Van Le </name>
    '''    	<date>2014-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Handle Key Enter Press
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub HandleKeyEnterPress(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim obj As AVP_Robot_Project.GEMWaferID = CType(sender, AVP_Robot_Project.GEMWaferID)
            Dim index As Integer = obj.TabIndex
            If index < NumberOfWafer Then
                Dim objNext As AVP_Robot_Project.GEMWaferID = GetObjGemIDControl(index + 1)
                objNext.txtGEMWaferID.Focus()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    ''' <author>
    '''    	<name> Van Le</name>
    '''    	<date>2014-09-12</date>
    ''' </author>
    ''' <summary>
    ''' Get Obj GemID Control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Function GetObjGemIDControl(ByVal index As Integer) As AVP_Robot_Project.GEMWaferID
        Dim objGEMID As AVP_Robot_Project.GEMWaferID = Nothing
        Try
            If NumberOfWafer > 12 Then
                If index > NumberOfWafer / 2 Then
                    For Each objCtrl As Control In Me.pnlRight.Controls
                        If objCtrl.Name.StartsWith(GEMWaferName & index.ToString()) Then
                            objGEMID = CType(objCtrl, AVP_Robot_Project.GEMWaferID)
                            Return objGEMID
                        End If
                    Next
                Else
                    For Each objCtrl As Control In Me.pnlLeft.Controls
                        If objCtrl.Name.StartsWith(GEMWaferName & index.ToString()) Then
                            objGEMID = CType(objCtrl, AVP_Robot_Project.GEMWaferID)
                            Return objGEMID
                        End If
                    Next
                End If
            Else
                For Each objCtrl As Control In Me.pnlSequence.Controls
                    If objCtrl.Name.StartsWith(GEMWaferName & index.ToString()) Then
                        objGEMID = CType(objCtrl, AVP_Robot_Project.GEMWaferID)
                        Return objGEMID
                    End If
                Next
            End If
            
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return objGEMID
    End Function
#End Region
End Class