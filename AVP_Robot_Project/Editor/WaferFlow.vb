Imports AVPLib.DataManagerment
Public Class SelectWaferFlow
#Region "Member"
    Private m_wfFlow As AVPLib.DataManagerment.WaferFlow
    Private m_lstWfFlow As List(Of AVPLib.DataManagerment.WaferFlow) = Nothing
    Private m_SequenceName As String
    Private m_blnIsDeleteMode As Boolean = False
#End Region
#Region "Property"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-24</date>
    ''' </author>
    ''' <summary>
    ''' SequenceName
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SequenceName() As String
        Get
            Return m_SequenceName
        End Get
        Set(ByVal value As String)
            m_SequenceName = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-16</date>
    ''' </author>
    ''' <summary>
    ''' WaferFlowList: get and set a list of name of WaferFlow
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WaferFlowList() As ArrayList
        Get
            Return m_listData
        End Get
        Set(ByVal value As ArrayList)
            m_listData = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-08-16</date>
    ''' </author>
    ''' <summary>
    ''' SelectedFlow: get and set Selected WaferFlow when user click on Dialog
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SelectedFlow() As AVPLib.DataManagerment.WaferFlow
        Get
            Return m_wfFlow
        End Get
        Set(ByVal value As AVPLib.DataManagerment.WaferFlow)
            m_wfFlow = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-08-16</date>
    ''' </author>
    ''' <summary>
    ''' SelectedFlow: get and set Selected WaferFlow when user click on Dialog
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ListSelectedFlow() As List(Of AVPLib.DataManagerment.WaferFlow)
        Get
            Return m_lstWfFlow
        End Get
        Set(ByVal value As List(Of AVPLib.DataManagerment.WaferFlow))
            m_lstWfFlow = value
        End Set
    End Property


    Public Sub New(ByVal arrWaferFlow As ArrayList, ByVal blnIsDeleteMode As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        m_listData = arrWaferFlow
        m_blnIsDeleteMode = blnIsDeleteMode
        If blnIsDeleteMode Then
            lstItems.SelectionMode = SelectionMode.MultiExtended
            Me.Text = "Delete WaferFlows"
            m_lstWfFlow = New List(Of AVPLib.DataManagerment.WaferFlow)
        Else
            lstItems.SelectionMode = SelectionMode.One
            Me.Text = "Select WaferFlows"
        End If
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
#End Region

#Region "Buttons Event"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-24</date>
    ''' </author>
    ''' <summary>
    ''' btnOK_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AVPLib.Log.guiLogger.Info("Enter btnOK_Click")
        Try
            If Me.m_listData IsNot Nothing AndAlso m_blnIsDeleteMode Then
                For Each strflow As String In lstItems.SelectedItems
                    Me.ListSelectedFlow.Add(AVPLib.ContainerData.GetWaferFlowbyName(strflow))
                Next
            ElseIf Me.m_listData IsNot Nothing Then
                Dim strflow As String = lstItems.SelectedItem.ToString()
                Me.SelectedFlow = AVPLib.ContainerData.GetWaferFlowbyName(strflow)
                CheckStationExist(Me.SelectedFlow)
            Else
                SequenceName = lstItems.SelectedItem.ToString()
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave btnOK_Click")
    End Sub
#End Region
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2008-09-01</date>
    ''' </author>
    ''' <summary>
    ''' CheckStationExist
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub CheckStationExist(ByVal SelectedWaferFlow As AVPLib.DataManagerment.WaferFlow)
        AVPLib.Log.guiLogger.Info("Enter CheckStationExist")
        Dim strWarning As String = String.Empty
        Try
            Dim ArrStation As ArrayList = SelectedWaferFlow.StepList
            For Each item As AVPLib.DataManagerment.WaferflowStep In ArrStation
                Dim station As String = AVPLib.Utils.chamberID2ChamberName(item.StationList.Item(0).ToString())
                '''station not available and not aligner and not in list
                If Not (ContainerData.IsStationAvailable(station)) _
                And Not (strWarning.Contains(station)) Then
                    strWarning = strWarning & station & ","
                End If
            Next
            If Not strWarning = String.Empty Then
                strWarning = strWarning.Remove(strWarning.LastIndexOf(","), 1)
                'MessageBox.Show(strWarning & " don't exist, please check again!", "WaferFlow", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Utils.ShowAVPMessageBox(strWarning & " don't exist, please check again!", "WaferFlow", MessageBoxIcon.Warning, MessageBoxButtons.OK)
                AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, _
                                   AVPLib.ContainerData.LogSource.AVPMainScreen, _
                                   "[Main Screen] " + strWarning & " don't exist when check station.")
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave CheckStationExist")
    End Sub

End Class