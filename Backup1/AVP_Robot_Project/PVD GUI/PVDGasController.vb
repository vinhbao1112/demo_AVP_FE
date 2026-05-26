Imports AVP_Robot_Project.ConstantAndEnum
Public Class PVDGasController
#Region "Variables"
    Private m_strGas1Name As String = String.Empty    Private m_strGas2Name As String = String.Empty    Private m_strGas3Name As String = String.Empty    Private m_strGas4Name As String = String.Empty    Private m_strGas5Name As String = String.Empty
    Private m_intTotalGasline As Integer = 1
    Const GAS_UNIT As String = "(sccm)"
    Private m_blnIsOnline As Boolean = False
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas5Name
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Gas1Name() As String        Get            Return m_strGas1Name        End Get        Set(ByVal value As String)            m_strGas1Name = value            Me.lblGas1.Text = m_strGas1Name & GAS_UNIT            If m_strGas1Name = "" Then                SetGas1Visible(False)
            Else
                SetGas1Visible(True)
            End If        End Set    End Property    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas5Name
    ''' </summary>
    ''' <remarks></remarks>    Public Property Gas2Name() As String        Get            Return m_strGas2Name        End Get        Set(ByVal value As String)            m_strGas2Name = value            Me.lblGas2.Text = m_strGas2Name & GAS_UNIT            If m_strGas2Name = "" Then                SetGas2Visible(False)
            Else
                SetGas2Visible(True)
            End If        End Set    End Property    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas5Name
    ''' </summary>
    ''' <remarks></remarks>    Public Property Gas3Name() As String        Get            Return m_strGas3Name        End Get        Set(ByVal value As String)            m_strGas3Name = value            Me.lblGas3.Text = m_strGas3Name & GAS_UNIT            If m_strGas3Name = "" Then                SetGas3Visible(False)
            Else
                SetGas3Visible(True)
            End If        End Set    End Property    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas5Name
    ''' </summary>
    ''' <remarks></remarks>    Public Property Gas4Name() As String        Get            Return m_strGas4Name        End Get        Set(ByVal value As String)            m_strGas4Name = value            Me.lblGas4.Text = m_strGas4Name & GAS_UNIT            If m_strGas4Name = "" Then                SetGas4Visible(False)
            Else
                SetGas4Visible(True)
            End If        End Set    End Property    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas5Name
    ''' </summary>
    ''' <remarks></remarks>    Public Property Gas5Name() As String        Get            Return m_strGas5Name        End Get        Set(ByVal value As String)            m_strGas5Name = value            Me.lblGas5.Text = m_strGas5Name & GAS_UNIT            If m_strGas5Name = "" Then                SetGas5Visible(False)
            Else
                SetGas5Visible(True)
            End If        End Set    End Property

    Public Property IsOnline() As Boolean
        Get
            Return m_blnIsOnline
        End Get
        Set(ByVal value As Boolean)
            m_blnIsOnline = value
            txtGas1Right.Enabled = Not m_blnIsOnline
            txtGas2Right.Enabled = Not m_blnIsOnline
            txtGas3Right.Enabled = Not m_blnIsOnline
            txtGas4Right.Enabled = Not m_blnIsOnline
            txtGas5Right.Enabled = Not m_blnIsOnline
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas5Name
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetGas1Visible(ByVal blnVisible As Boolean)
        Me.lblGas1.Visible = blnVisible
        Me.txtGas1Right.Visible = blnVisible
        Me.txtGas1.Visible = blnVisible
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas5Name
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetGas2Visible(ByVal blnVisible As Boolean)
        Me.lblGas2.Visible = blnVisible
        Me.txtGas2Right.Visible = blnVisible
        Me.txtGas2.Visible = blnVisible
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas5Name
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetGas3Visible(ByVal blnVisible As Boolean)
        Me.lblGas3.Visible = blnVisible
        Me.txtGas3Right.Visible = blnVisible
        Me.txtGas3.Visible = blnVisible
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas5Name
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetGas4Visible(ByVal blnVisible As Boolean)
        Me.lblGas4.Visible = blnVisible
        Me.txtGas4Right.Visible = blnVisible
        Me.txtGas4.Visible = blnVisible
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Gas5Name
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetGas5Visible(ByVal blnVisible As Boolean)
        Me.lblGas5.Visible = blnVisible
        Me.txtGas5Right.Visible = blnVisible
        Me.txtGas5.Visible = blnVisible
    End Sub
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
            Dim stbGas1 As New StatusTextBox(Me.txtGas1)
            Dim stbGas1Right As New StatusTextBox(Me.txtGas1Right)
            Dim stbGas2 As New StatusTextBox(Me.txtGas2)
            Dim stbGas2Right As New StatusTextBox(Me.txtGas2Right)
            Dim stbGas3 As New StatusTextBox(Me.txtGas3)
            Dim stbGas3Right As New StatusTextBox(Me.txtGas3Right)
            Dim stbGas4 As New StatusTextBox(Me.txtGas4)
            Dim stbGas4Right As New StatusTextBox(Me.txtGas4Right)
            Dim stbGas5 As New StatusTextBox(Me.txtGas5)
            Dim stbGas5Right As New StatusTextBox(Me.txtGas5Right)

            m_stoStatusObject.Name = Me.Name
            m_stoStatusObject.AddChild(stbgas1)
            m_stoStatusObject.AddChild(stbGas1Right)
            m_stoStatusObject.AddChild(stbGas2)
            m_stoStatusObject.AddChild(stbGas2Right)
            m_stoStatusObject.AddChild(stbGas3)
            m_stoStatusObject.AddChild(stbGas3Right)
            m_stoStatusObject.AddChild(stbGas4)
            m_stoStatusObject.AddChild(stbGas4Right)
            m_stoStatusObject.AddChild(stbGas5)
            m_stoStatusObject.AddChild(stbGas5Right)

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

    End Sub
#End Region

#Region "Events – Buttons – Forms…"
    Private Sub txtGas1Right_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGas1Right.Click, _
                         txtGas2Right.Click, txtGas3Right.Click, txtGas4Right.Click, txtGas5Right.Click
        PVDSupport.TextboxClick(sender, e, Me.Parent, m_stoStatusObject)
    End Sub
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub StartProcessing() ''reset editbox to empty
        Me.txtGas1Right.Text = String.Empty
        Me.txtGas2Right.Text = String.Empty
        Me.txtGas3Right.Text = String.Empty
        Me.txtGas4Right.Text = String.Empty
        Me.txtGas5Right.Text = String.Empty
    End Sub
#End Region

   
End Class
