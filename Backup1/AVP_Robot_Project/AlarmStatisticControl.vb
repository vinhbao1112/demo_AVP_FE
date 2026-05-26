Imports System
Imports ZedGraph
Imports AVPLib
Imports AVPLib.ConstEnum
Imports AVPControls

Public Class AlarmStatisticControl
    Const STATUS_TEXT As String = "Please wait while loading...."
    Const NUMBER_OF_BARS As Integer = 10
    Dim m_AlarmMsgs As AVPLib.AlarmMsgItems
    Dim m_iIndex As Single = NUMBER_OF_BARS
    Dim m_iNumberOfItems As Single = 0
    Private LoadDataGrid_Worker As ComponentModel.BackgroundWorker = Nothing
    Protected m_marshaller As DelegateMarshaler
    Private m_dt As DataTable = Nothing


    Private Sub AlarmStatisticControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            m_marshaller = DelegateMarshaler.Create()
            LoadDataGrid_Worker = New ComponentModel.BackgroundWorker()
            LoadDataGrid_Worker.WorkerReportsProgress = True
            LoadDataGrid_Worker.WorkerSupportsCancellation = True

            AddHandler LoadDataGrid_Worker.DoWork, New ComponentModel.DoWorkEventHandler(AddressOf OnWork)
            AddHandler LoadDataGrid_Worker.RunWorkerCompleted, _
                       New ComponentModel.RunWorkerCompletedEventHandler(AddressOf Worker_RunWorkerCompleted)

            dtFrom.Value = Date.Today
            dtTo.Value = Date.Now
            btnRefresh.PerformClick()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub UpdateGraph()
        Dim myPane As GraphPane = zgraph.GraphPane

        m_AlarmMsgs = AVPLib.ContainerData.AlarmMsgs.GetInstance

        Dim x As Double = 0
        Dim y As Double = 0

        Dim curItem As CurveItem = zgraph.GraphPane.CurveList("Alarm")
        If curItem Is Nothing Then
            Dim list As New PointPairList
            Dim myBar As BarItem = myPane.AddBar("Alarm", list, Color.Blue)
            myBar.Bar.Fill = New Fill(Color.Gold, Color.Gold, Color.Gold)
            curItem = zgraph.GraphPane.CurveList("Alarm")

            'myPane.BarSettings.Base = BarBase.Y
            myPane.BarSettings.Base = BarBase.Y
        Else
            CType(curItem.Points, ZedGraph.IPointListEdit).Clear()
        End If

        Dim labels(m_AlarmMsgs.Values.Count - 1) As String

        Dim percentageArray As ArrayList = m_AlarmMsgs.Values
        m_iNumberOfItems = percentageArray.Count
        m_iIndex = 0
        For Each percentage As Double In percentageArray
            Dim ip As ZedGraph.IPointListEdit = curItem.Points
            y = percentage
            ip.Add(y, x)
            labels(x) = m_AlarmMsgs.Msg(x).Msg
            x += 1
        Next

        ' Set the Titles
        myPane.Title.Text = "Alarm Pareto Chart " & PageCurrent(m_iNumberOfItems).ToString() & "/" & PagesTotal(m_iNumberOfItems).ToString()
        myPane.XAxis.Title.Text = "Number Of Alarm"
        myPane.YAxis.Title.Text = String.Empty

        'myPane.XAxis.Type = AxisType.Text
        'myPane.XAxis.Scale.TextLabels = labels
        myPane.YAxis.Type = AxisType.Text
        myPane.YAxis.Scale.TextLabels = labels
        myPane.YAxis.MajorGrid.IsZeroLine = False


        myPane.YAxis.Scale.FontSpec.Angle = 90
        myPane.YAxis.Scale.FontSpec.FontColor = Color.Black
        myPane.YAxis.Scale.FontSpec.Size = 9
        myPane.YAxis.Scale.FontSpec.IsBold = True

        myPane.YAxis.Scale.Align = AlignP.Inside
        myPane.YAxis.Scale.IsLabelsInside = True
        myPane.YAxis.Scale.MinAuto = False
        myPane.YAxis.Scale.Min = 0.5
        If NUMBER_OF_BARS < m_iNumberOfItems Then
            myPane.YAxis.Scale.MaxAuto = False
            UpdateView(m_iNumberOfItems)
        Else
            myPane.YAxis.Scale.MaxAuto = True
            btnPrevious.Enabled = False
            btnNext.Enabled = False
        End If
        zgraph.AxisChange()
        zgraph.Invalidate()
        zgraph.IsShowPointValues = True

    End Sub


    ''' <author>
    '''     <name> Hoai Ly </name>
    '''     <date> 2015-07-14 </date>
    ''' </author>
    ''' <summary>
    ''' Pages Total
    ''' </summary>
    Private Function PagesTotal(ByVal m_NumberOfItems As Single) As Integer
        Dim ipage As Integer = Math.Floor(m_NumberOfItems / NUMBER_OF_BARS)
        If m_NumberOfItems Mod NUMBER_OF_BARS > 0 Then
            Return ipage + 1
        End If
        Return ipage
    End Function

    ''' <author>
    '''     <name> Hoai Ly </name>
    '''     <date> 2015-07-14 </date>
    ''' </author>
    ''' <summary>
    ''' Page Current
    ''' </summary>
    Private Function PageCurrent(ByVal m_PageIndex As Integer) As Integer
        Dim m_currentPage As Integer = 1
        If m_iNumberOfItems = 0 Then
            Return 0
        ElseIf m_PageIndex = m_iNumberOfItems Then
            Return m_currentPage
        End If
        Return m_currentPage + Math.Floor((m_iNumberOfItems - m_PageIndex) / NUMBER_OF_BARS)
    End Function

    ''' <author>
    '''     <name> Hoai Ly </name>
    '''     <date> 2015-07-14 </date>
    ''' </author>
    ''' <summary>
    ''' Enable Disable btnPrevious, btnNext
    ''' </summary>
    Private Sub EnableDisableButton()
        Dim iIndex As Integer = IIf(m_iIndex = 0, m_iNumberOfItems, m_iIndex)
        If PageCurrent(iIndex) = 1 Then   'first page
            btnPrevious.Enabled = False
            btnPrevious.Cursor = Cursors.Default
        Else
            btnPrevious.Enabled = True
            btnPrevious.Cursor = Cursors.Hand
        End If

        If PageCurrent(iIndex) = PagesTotal(m_iNumberOfItems) Then    'latest page
            btnNext.Enabled = False
            btnNext.Cursor = Cursors.Default
        Else
            btnNext.Enabled = True
            btnNext.Cursor = Cursors.Hand
        End If
    End Sub

    Private Function zgraph_PointValueEvent(ByVal sender As ZedGraph.ZedGraphControl, ByVal pane As ZedGraph.GraphPane, ByVal curve As ZedGraph.CurveItem, ByVal iPt As System.Int32) As System.String Handles zgraph.PointValueEvent
        Dim alarmMsg As AlarmMsgItem = m_AlarmMsgs.Msg(iPt)
        Dim strMsg As String = String.Format("({0}/{1}) - {2}", alarmMsg.Count, m_AlarmMsgs.TotalMsg, alarmMsg.Msg)
        Return strMsg
    End Function

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        GetDataSource()
    End Sub
    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2015-08-07</date>
    ''' </author>
    ''' <summary>
    ''' Check Permission
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckPermission()
        '#03/07/2011 
        '#[Sl_Build 12_Feb 16, 2011]User account should be similar to avp/pvd request
        '#Begin fix:
        If AVPLib.ContainerData.Permission(PERMISSION_012) Then
            Enable_DisableControl(True)
        Else
            Enable_DisableControl(False)
        End If
        '#End fix.
    End Sub
    Private Sub Enable_DisableControl(ByVal blnEnable As Boolean)
        dtFrom.Enabled = blnEnable
        dtTo.Enabled = blnEnable
        btnRefresh.Enabled = blnEnable
        btnExport.Enabled = blnEnable
        btnPrevious.Enabled = blnEnable
        btnNext.Enabled = blnEnable
    End Sub

    Private Sub DateTime_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Enable_DisableControl(False)
            GetDataSource()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

#Region "Worker Load Data"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-06</date>
    ''' </author>
    ''' <summary>
    ''' Filter
    ''' </summary>
    ''' <param name="type"></param>
    ''' <param name="username"></param>
    ''' <remarks></remarks>
    Private Sub GetDataSource()
        Try
            If LoadDataGrid_Worker.IsBusy Then
                LoadDataGrid_Worker.CancelAsync()
            End If
            Dim filter As String = "LogTime >= #" + Me.dtFrom.Value.ToString("MM/dd/yyyy") + " 12:00:00 AM#" + " and LogTime <= #" + Me.dtTo.Value.ToString("MM/dd/yyyy") + " 11:59:59 PM#"
            filter = filter + " and Type='Alarm'"
            Dim sSort As String = " order by LogTime DESC"
            lblStatus.Text = STATUS_TEXT
            If Not LoadDataGrid_Worker.IsBusy Then
                Enable_DisableControl(False)
                LoadDataGrid_Worker.RunWorkerAsync(filter & sSort)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub OnWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        If Me.LoadDataGrid_Worker.CancellationPending AndAlso Not (String.IsNullOrEmpty(e.Argument.ToString())) Then
            e.Cancel = True
            Return
        End If
        ' Do not access the form's BackgroundWorker reference directly.
        ' Instead, use the reference provided by the sender parameter.
        m_dt = AVPLib.ContainerData.DataTable_Log(LoadDataGrid_Worker, e.Argument.ToString())
        If Me.LoadDataGrid_Worker.CancellationPending Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Try
            If e.Cancelled Then
                Return
            End If
            If m_dt IsNot Nothing Then
                m_marshaller.Invoke(Of DataTable)(New Threading.SendOrPostCallback(AddressOf UpdateDataGrid), m_dt)
                'Clear memory after update datagrid.
                GC.Collect()
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub UpdateDataGrid(ByVal stateObj As Object)
        Try
            If m_dt IsNot Nothing Then
                lblStatus.Text = String.Empty
                AVPLib.ContainerData.AlarmMsgs.Clear()
                For Each dr As DataRow In m_dt.Rows
                    AVPLib.ContainerData.AlarmMsgs.Add(String.Format("[{0}] {1}", dr("Source"), dr("Description")))
                Next
            End If
            UpdateGraph()
            Enable_DisableControl(True)
            EnableDisableButton()
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        UpdateView(m_iIndex + NUMBER_OF_BARS)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        UpdateView(m_iIndex - NUMBER_OF_BARS)
    End Sub

    Private Sub UpdateView(ByVal Index As Integer)
        If Index > m_iNumberOfItems Then
            m_iIndex = m_iNumberOfItems
        ElseIf Index > 0 Then
            m_iIndex = Index
        End If
        Dim myPane As GraphPane = zgraph.GraphPane
        myPane.Title.Text = "Alarm Pareto Chart " & PageCurrent(Index).ToString() & "/" & PagesTotal(m_iNumberOfItems).ToString()
        EnableDisableButton()

        zgraph.GraphPane.YAxis.Scale.Max = 0.5 + m_iIndex
        zgraph.GraphPane.YAxis.Scale.Min = zgraph.GraphPane.YAxis.Scale.Max - NUMBER_OF_BARS
        zgraph.Invalidate()
    End Sub

    ''' <author>
    '''     <name> Tu Nguyen </name>
    '''     <date> 2015-04-23 </date>
    ''' </author>
    ''' <summary>
    ''' Export data log
    ''' </summary>
    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            If m_AlarmMsgs Is Nothing OrElse m_AlarmMsgs.Values().Count = 0 Then
                Utils.ShowAVPMessageBox("No data to export.", "Pareto Chart", MessageBoxIcon.Information, AVPMessageBox.AVPMessageBoxButton.OK)
                Exit Sub
            End If

            Dim SaveFileDlg As New SaveFileDialog()
            SaveFileDlg.Filter = "CSV files (*.csv)|*.csv"
            SaveFileDlg.FilterIndex = 1
            SaveFileDlg.RestoreDirectory = True
            SaveFileDlg.Title = "Export Alarm Statistic to"

            If SaveFileDlg.ShowDialog(Me) = DialogResult.OK Then
                Dim fname As String = SaveFileDlg.FileName
                btnExport.Enabled = False
                Dim isSuccess As Boolean = SaveDataToCSVFile(fname)
                btnExport.Enabled = True
                If isSuccess Then
                    Utils.ShowAVPMessageBox("Export data successfully.", "Pareto Chart", MessageBoxIcon.Information, AVPMessageBox.AVPMessageBoxButton.OK)
                Else
                    Utils.ShowAVPMessageBox("An error occurs while save data. Please try again.", "Pareto Chart", MessageBoxIcon.Error, AVPMessageBox.AVPMessageBoxButton.OK)
                End If
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
            btnExport.Enabled = True
        End Try
    End Sub

    ''' <author>
    '''     <name> Tu Nguyen </name>
    '''     <date> 2015-04-23 </date>
    ''' </author>
    ''' <summary>
    ''' Save data log in Pareto Chart to CSV file
    ''' </summary>
    Private Function SaveDataToCSVFile(ByVal fName As String) As Boolean
        Try
            If Not fName.EndsWith(AVPLib.ConstEnum.STR_CSV_EXT) Then
                fName = fName & AVPLib.ConstEnum.STR_CSV_EXT
            End If
            Dim objWrite As IO.StreamWriter = New IO.StreamWriter(fName, False)
            If objWrite Is Nothing Then
                Return False
            End If

            objWrite.WriteLine(String.Format("Alarm Statistic from, {0}, to, {1}", dtFrom.Value.ToString("MM/dd/yyyy"), dtTo.Value.ToString("MM/dd/yyyy")))
            Dim alarmMsgs As AlarmMsgItems = m_AlarmMsgs.GetInstance()
            For i As Integer = 0 To alarmMsgs.Values().Count - 1
                objWrite.WriteLine(String.Format("{0},{1},{2}%", alarmMsgs.Msg(i).Msg, alarmMsgs.Msg(i).Count, alarmMsgs.Msg(i).Percentage))
            Next

            objWrite.Close()
            Return True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Function


End Class
