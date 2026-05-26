Imports System
Imports System.Globalization
Public Class PVDTextbox

    Private m_UseBackGroundWorkerToUpdateMinMax As Boolean = False
    'For Update Min Max Value To PM
    Dim UpdateMinMaxPM_worker As ComponentModel.BackgroundWorker = Nothing 'worker for Update Min Max to PM
    Private m_blnIsGasType_SynchronizeButNoUpdateMinMaxValueToPM As Boolean = False

    Public Property UseBackGroundWorkerToUpdateMinMax() As Boolean
        Get
            Return m_UseBackGroundWorkerToUpdateMinMax
        End Get
        Set(ByVal value As Boolean)
            m_UseBackGroundWorkerToUpdateMinMax = value
            If m_UseBackGroundWorkerToUpdateMinMax Then
                Me.UpdateMinMaxPM_worker = New ComponentModel.BackgroundWorker()
                Me.UpdateMinMaxPM_worker.WorkerSupportsCancellation = True
                AddHandler UpdateMinMaxPM_worker.DoWork, New ComponentModel.DoWorkEventHandler(AddressOf OnWork)
            End If
        End Set
    End Property

    Public Property IsGasType_SynchronizeButNoUpdateMinMaxValueToPM() As Boolean
        Get
            Return m_blnIsGasType_SynchronizeButNoUpdateMinMaxValueToPM
        End Get
        Set(ByVal value As Boolean)
            m_blnIsGasType_SynchronizeButNoUpdateMinMaxValueToPM = value
        End Set
    End Property


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-07-12 </date>
    ''' </author>
    ''' <summary>
    ''' Update MinMax Value To PM use BackgroundWorker.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateMinMaxValueToPM(ByVal strKey As String, ByVal strMinValue As String, ByVal strMaxValue As String)
        Try
            '#Fix bug: -AVP/PVD.  Gas min/max. When user change gasx max value, this max value need to store locally on AVP.   
            '#It is not suppose to change to configuration file on PVD
            If IsGasType_SynchronizeButNoUpdateMinMaxValueToPM Then
                Exit Sub
            End If
            '#End fix.

            If UpdateMinMaxPM_worker.IsBusy Then
                UpdateMinMaxPM_worker.CancelAsync()
            End If
            Dim lstOfParamMinMax As List(Of String) = Utils.GetParametersInFunctionUpdateMinMaxValueToPM(strKey, strMinValue, strMaxValue)
            UpdateMinMaxPM_worker.RunWorkerAsync(lstOfParamMinMax)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-07-12 </date>
    ''' </author>
    ''' <summary>
    ''' Update MinMax Value.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateMinMaxValue(ByVal strKey As String, ByVal strMinValue As String, ByVal strMaxValue As String)
        Try
            AVPLib.ContainerData.SetRobotConfig(strKey + ConstantAndEnum.STRING_MIN, strMinValue)
            AVPLib.ContainerData.SetRobotConfig(strKey + ConstantAndEnum.STRING_MAX, strMaxValue)
            UpdateMinMaxValueToPM(strKey, strMinValue, strMaxValue)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-07-12 </date>
    ''' </author>
    ''' <summary>
    ''' Get Source of Control to use to get message text and update min/max value.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetSource() As String
        Dim strSource As String = String.Empty
        strSource = Me.Parent.Parent.Name & "." & AVPLib.ConstEnum.PVD & "." & Me.Parent.Name & "." & Me.Name
        Return strSource
    End Function


    Private Sub OnWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        If Me.UpdateMinMaxPM_worker.CancellationPending Then
            e.Cancel = True
            Return
        End If
        Dim params As List(Of String) = CType(e.Argument, List(Of String))
        AVPLib.ContainerDAO.UpdatePMMinMaxValue(params)
    End Sub
End Class
