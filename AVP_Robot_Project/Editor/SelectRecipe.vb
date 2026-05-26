Imports AVP_Robot_Project.ConstantAndEnum
Imports AVP_Robot_Project
Public Class SelectRecipe
#Region "Member"
    Private m_strCurrentStationName As String
    Private m_strSelectedRecipe As String

#End Region
#Region "Property"
    Public Property SelectDefaultRecipe() As String
        Get
            Return Me.m_defaultSelectedValue
        End Get
        Set(ByVal value As String)
            Me.m_defaultSelectedValue = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-07-27</date>
    ''' </author>
    ''' <summary>
    ''' Stat
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StationName() As String
        Get
            Return m_strCurrentStationName
        End Get
        Set(ByVal value As String)
            m_strCurrentStationName = value
        End Set
    End Property
    ''' <author>
    '''    	<name> DoXuanDat </name>
    '''    	<date> 2009-07-27 </date>
    ''' </author>
    ''' <summary>
    ''' Stat
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SelectedRecipe() As String
        Get
            Return m_strSelectedRecipe
        End Get
        Set(ByVal value As String)
            m_strSelectedRecipe = value
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
#End Region

#Region "Load Form"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' SelectRecipe_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SelectRecipe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm()
    End Sub
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Load Form
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadForm()
        Try
            Dim Chamber As String = m_strCurrentStationName
            'remove the space
            ' Aligner -> Aligner
            ' Chamber 1 -> Chamber1
            If ContainerForm.Chamber1Visible AndAlso ContainerForm.Chamber1Panel.ContainsFocus Then
                Chamber = AVPLib.ConstEnum.Equipments.Chamber1.ToString()
                StationName = AVPLib.RobotConfigurationValues.CHAMBER1_NAME
            ElseIf ContainerForm.Chamber2Visible AndAlso ContainerForm.Chamber2Panel.ContainsFocus Then
                Chamber = AVPLib.ConstEnum.Equipments.Chamber2.ToString()
                StationName = AVPLib.RobotConfigurationValues.CHAMBER2_NAME
            ElseIf ContainerForm.Chamber3Visible AndAlso ContainerForm.Chamber3Panel.ContainsFocus Then
                Chamber = AVPLib.ConstEnum.Equipments.Chamber3.ToString()
                StationName = AVPLib.RobotConfigurationValues.CHAMBER3_NAME
            End If
            StationName = Chamber
            Me.SetTitle(StationName)
            If IsSetListRecipeFromPM Then
                Me.m_listData = AVPLib.ContainerData.ListChamber(Chamber)
            End If

            Me.UpdateList()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub LoadFormUseAnyChamber()
        Try
            Dim Chamber As String = m_strCurrentStationName
            'remove the space
            ' Aligner -> Aligner
            ' Chamber 1 -> Chamber1
            Dim ChamberType As AVPLib.SystemModule.ModuleType = AVPLib.SystemModule.ModuleType.IBE
            If m_strCurrentStationName.Contains("PVD") Then
                ChamberType = AVPLib.SystemModule.ModuleType.PVD
            End If
            StationName = m_strCurrentStationName
            Me.SetTitle(StationName)
            If IsSetListRecipeFromPM Then
                Me.m_listData = AVPLib.ContainerData.ListChamberUseAnyChamber(ChamberType)
            End If
            Me.UpdateList()

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Buttons Event"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' OK Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter btnOK_Click")
        Try
            Me.SelectedRecipe = lstItems.SelectedItem.ToString()
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnOK_Click")
    End Sub

#End Region

#Region "Function Support"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Set Title
    ''' </summary>
    ''' <param name="Title"></param>
    ''' <remarks></remarks>
    Private Sub SetTitle(ByVal Title As String)
        ' Convert the chamber name to a proper value
        Dim strStationname As String = Title
        'strStationname is "Chamber 1" or "Chamber 2" ...
        strStationname = AVPLib.Utils.chamberID2ChamberName(strStationname)

        Me.Text = "Select a Recipe for " + strStationname

    End Sub
    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-03-24</date>
    ''' </author>
    ''' <summary>
    ''' Is Set Recipe Fron Back End.
    ''' </summary>
    ''' <param></param>
    ''' <remarks></remarks>
    Private blIsSetListRecipeFromBackEnd As Boolean = True
    Public Property IsSetListRecipeFromPM() As Boolean
        Get
            Return blIsSetListRecipeFromBackEnd
        End Get
        Set(ByVal value As Boolean)
            blIsSetListRecipeFromBackEnd = value
        End Set
    End Property
#End Region

End Class