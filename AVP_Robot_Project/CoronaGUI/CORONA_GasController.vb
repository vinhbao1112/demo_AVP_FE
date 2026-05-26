Public Class CORONA_GasController
    Private m_blnIsOnline As Boolean = False
    Private m_Gas1Visible As Boolean
    Private m_Gas2Visible As Boolean
    Private m_Gas3Visible As Boolean
    Private m_Gas4Visible As Boolean
    Private m_Gas5Visible As Boolean

    Private m_strGas1Name As String = String.Empty
    Private m_strGas2Name As String = String.Empty
    Private m_strGas3Name As String = String.Empty
    Private m_strGas4Name As String = String.Empty
    Private m_strGas5Name As String = String.Empty

#Region "Properties"

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2018-04-06</date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas1Name
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas1Name() As String
        Get
            Return m_strGas1Name
        End Get
        Set(ByVal value As String)
            m_strGas1Name = value
            Me.lblGas1.Text = "Gas 1 (" & m_strGas1Name & ")"
        End Set
    End Property

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2018-04-06</date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas2Name
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas2Name() As String
        Get
            Return m_strGas2Name
        End Get
        Set(ByVal value As String)
            m_strGas2Name = value
            Me.lblGas2.Text = "Gas 2 (" & m_strGas2Name & ")"
        End Set
    End Property

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2018-04-06</date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas3Name
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas3Name() As String
        Get
            Return m_strGas3Name
        End Get
        Set(ByVal value As String)
            m_strGas3Name = value
            Me.lblGas3.Text = "Gas 3 (" & m_strGas3Name & ")"
        End Set
    End Property

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2018-04-06</date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas4Name
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas4Name() As String
        Get
            Return m_strGas4Name
        End Get
        Set(ByVal value As String)
            m_strGas4Name = value
            Me.lblGas4.Text = "Gas 4 (" & m_strGas4Name & ")"
        End Set
    End Property

    ''' <author>
    '''    	<name> Dy Do </name>
    '''    	<date> 2018-04-06</date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas5Name
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas5Name() As String
        Get
            Return m_strGas5Name
        End Get
        Set(ByVal value As String)
            m_strGas5Name = value
            Me.lblGas5.Text = "Gas 5 (" & m_strGas5Name & ")"
        End Set
    End Property

    Public Property Gas1Visible() As Boolean
        Get
            Return m_Gas1Visible
        End Get
        Set(ByVal value As Boolean)
            m_Gas1Visible = value
            txtGas1.Visible = value
            txtGas1Right.Visible = value
            lblGas1.Visible = value
        End Set
    End Property
    Public Property Gas2Visible() As Boolean
        Get
            Return m_Gas2Visible
        End Get
        Set(ByVal value As Boolean)
            m_Gas2Visible = value
            txtGas2.Visible = value
            txtGas2Right.Visible = value
            lblGas2.Visible = value
        End Set
    End Property
    Public Property Gas3Visible() As Boolean
        Get
            Return m_Gas3Visible
        End Get
        Set(ByVal value As Boolean)
            m_Gas3Visible = value
            txtGas3.Visible = value
            txtGas3Right.Visible = value
            lblGas3.Visible = value
        End Set
    End Property
    Public Property Gas4Visible() As Boolean
        Get
            Return m_Gas4Visible
        End Get
        Set(ByVal value As Boolean)
            m_Gas4Visible = value
            txtGas4.Visible = value
            txtGas4Right.Visible = value
            lblGas4.Visible = value
        End Set
    End Property
    Public Property Gas5Visible() As Boolean
        Get
            Return m_Gas5Visible
        End Get
        Set(ByVal value As Boolean)
            m_Gas5Visible = value
            txtGas5.Visible = value
            txtGas5Right.Visible = value
            lblGas5.Visible = value
        End Set
    End Property
    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            txtGas1Right.Enabled = Not (m_blnIsOnline)
            txtGas2Right.Enabled = Not (m_blnIsOnline)
            txtGas3Right.Enabled = Not (m_blnIsOnline)
            txtGas4Right.Enabled = Not (m_blnIsOnline)
            txtGas5Right.Enabled = Not (m_blnIsOnline)
        End Set
    End Property
#End Region

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-02-05 </date>
    ''' </author>
    ''' <summary>
    ''' event textchange of textbox gas
    ''' </summary>
    Private Sub txtGas1Status_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGas5Status.TextChanged, txtGas4Status.TextChanged, txtGas3Status.TextChanged, txtGas2Status.TextChanged, txtGas1Status.TextChanged
        Try
            UpdateGasMFCDeviceNetStatus()
        Catch ex As Exception
            AVPLib.Log.coreLogger.Error(ex.Message)
        End Try
    End Sub

    ''' <author>
    '''     <name> Dung Pham </name>
    '''     <date> 2020-02-05 </date>
    ''' </author>
    ''' <summary>
    ''' UpdateGasMFCDeviceNetStatus
    ''' </summary>
    Public Sub UpdateGasMFCDeviceNetStatus()
        Try
            Dim objChamber As AVPLib.DataManagerment.CoronaChamber = AVPLib.DataManagerment.EquipmentManager.GetEquipment(m_stoStatusObject.Parent.Name)
            If objChamber IsNot Nothing Then
                SetTextForGas(objChamber.Gas1MFCDevinetStatus, txtGas1, objChamber.Gas1_Flowrate_Readback)
                SetTextForGas(objChamber.Gas2MFCDevinetStatus, txtGas2, objChamber.Gas2_Flowrate_Readback)
                SetTextForGas(objChamber.Gas3MFCDevinetStatus, txtGas3, objChamber.Gas3_Flowrate_Readback)
                SetTextForGas(objChamber.Gas4MFCDevinetStatus, txtGas4, objChamber.Gas4_Flowrate_Readback)
                SetTextForGas(objChamber.Gas5MFCDevinetStatus, txtGas5, objChamber.Gas5_Flowrate_Readback)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Dung Pham </name>
    '''     <date> 2020-02-05 </date>
    ''' </author>
    ''' <summary>
    ''' SetTextForGas
    ''' </summary>
    Private Sub SetTextForGas(ByVal gasStatus As AVPLib.DataManagerment.Equipment.WorkingStatuses, ByVal textbox As SL_Textbox, _
                                ByVal gasReadback As Double)
        Try
            If gasStatus = AVPLib.DataManagerment.Equipment.WorkingStatuses.Off Then
                textbox.Text = "err"
                textbox.ForeColor = Color.Red
            Else
                textbox.ForeColor = Color.Black
                textbox.Text = Format(Double.Parse(gasReadback), "0.0")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
End Class
