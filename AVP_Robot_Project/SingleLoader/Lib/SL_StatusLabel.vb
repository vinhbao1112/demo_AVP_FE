Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Public Class SL_StatusLabel
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_lblLabel As System.Windows.Forms.Label
    Private m_strNameOfSequenceIsRunning As String
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-07-27</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the label that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManagedLabel() As System.Windows.Forms.Label
        Get
            Return m_lblLabel
        End Get
        Set(ByVal value As System.Windows.Forms.Label)
            m_lblLabel = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-07-27</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with text box that will be managed by this object
    ''' </summary>
    ''' <param name="txtManagedTextBox"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal txtManagedLabel As System.Windows.Forms.Label)
        Try
            m_lblLabel = txtManagedLabel
            Me.Name = m_lblLabel.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-07-27</date>
    ''' </author>
    ''' <summary>
    ''' This procedure handle change GUI of label and its relevant
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Private Sub UpdateGUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            Dim arrValueItem As String() = Value.Split(New String() {"_"}, StringSplitOptions.RemoveEmptyEntries)
            Select Case arrValueItem(1)
                Case STR_ON
                    m_lblLabel.Visible = True
                    m_lblLabel.ForeColor = Color.Yellow
                    m_lblLabel.Text = ChangeEquipmentName(arrValueItem(0)) & " sequence is running..."
                    m_strNameOfSequenceIsRunning = arrValueItem(0)
                Case STR_OFF
                    'Only running sequence can clear this text.
                    If m_strNameOfSequenceIsRunning = arrValueItem(0) Then
                            m_lblLabel.Visible = False
                    End If
            End Select
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
    '''This function is used in case you want to change CatsettesModule -> TM - Fix issue 0001046
    Private Function ChangeEquipmentName(ByVal message As String) As String
        Dim str() As String = message.Split(":")
        If str.Length > 1 Then
            If str(0).Contains("Chamber") Then
            message = message.Replace(str(0) & ":", "") 'AVPLib.Utils.chamberID2ChamberName(str(0)))
            Else
                message = message.Replace(str(0), AVPLib.Utils.chamberID2ChamberName(str(0)))
            End If
        End If
        Return message
    End Function
    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-07-27</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateGUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
#End Region
End Class
