Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib
Public Class StatusStandardTextBox
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Protected m_txtTextBox As SL_Textbox
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Get or set the text box that will be manage by this object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New()
    End Sub
    Public Property ManagedTextBox() As SL_Textbox
        Get
            Return m_txtTextBox
        End Get
        Set(ByVal value As SL_Textbox)
            m_txtTextBox = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-09-03</date>
    ''' </author>
    ''' <summary>
    ''' Initalize with text box that will be managed by this object
    ''' </summary>
    ''' <param name="txtManagedTextBox"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal txtManagedTextBox As SL_Textbox)
        Try
            m_txtTextBox = txtManagedTextBox
            Me.Name = m_txtTextBox.Name
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub
#End Region

#Region "Public Methods"
    ''' <author>
    '''    	<name> Dat Do </name>
    '''     <date> 2009-04-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object and update UI
    ''' </summary>
    ''' <param name="arg"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub UpdateGUI(ByVal arg As Object)
        Try
            Dim Value As String = CType(arg, String)
            With m_txtTextBox
                If .UseScientificFormat Then
                    Value = Format(Double.Parse(Value), _
                                IIf(.UseDigitNumber = DigitsNumber.None_Digit, _
                                IGCG_INITVALUE, AVPLib.ConstEnum.SCIENTIFIC_FORMAT))
                Else
                    If .UseDigitNumber = DigitsNumber.One_Digit AndAlso IsNumeric(Value) Then
                        Value = Format(Double.Parse(Value), "0.0")
                    ElseIf .UseDigitNumber = DigitsNumber.Two_Digits AndAlso IsNumeric(Value) Then
                        Value = Format(Double.Parse(Value), "0.0#")
                    ElseIf .UseDigitNumber = DigitsNumber.Three_Digits AndAlso IsNumeric(Value) Then
                        Value = Format(Double.Parse(Value), "0.0##")
                    ElseIf .UseDigitNumber = DigitsNumber.None_Digit AndAlso IsNumeric(Value) Then
                        Value = Format(Double.Parse(Value), "0.0###")
                    ElseIf .UseDigitNumber = DigitsNumber.None_Digit AndAlso IsNumeric(Value) Then
                        Value = Format(Double.Parse(Value), "0.")
                    End If
                End If
                If .Name = "txtCGPress" Then
                    If Value = "-1.00E+00" Then
                        .Text = "Error"
                        .ForeColor = Color.Red
                    ElseIf IsNumeric(Value) Then
                        .Text = Value
                        .ForeColor = Color.Black
                    End If
                Else
                    .ForeColor = Color.Black
                    .Text = Value
                End If
                .Tag = Value

            End With
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub


    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure overrides to change satus of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overrides Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        'AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        'AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateGUI), Value)
        'AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
#End Region
End Class
