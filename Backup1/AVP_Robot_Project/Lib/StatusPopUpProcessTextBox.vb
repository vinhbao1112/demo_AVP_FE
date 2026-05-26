Imports System.Windows.Forms
Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports AVPLib

Public Class StatusPopUpProcessTextBox
    Inherits AVPControls.StatusObject

#Region "Class Constants & Variables"
    Private m_txtTextBox As SL_Textbox
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
    Private Sub UpdateGUI(ByVal arg As Object)
        Try
            Dim value As String = arg.ToString()

            If (Me.Name = "txtBeamCurrentRB") OrElse _
                                  (Me.Name = "txtBeamCurrentSP") OrElse _
                                  (Me.Name = "txtSuppressorCurrentRB") OrElse _
                                  (Me.Name = "txtPBNBodyRB") Then

                value = Format(Double.Parse(value), "0.####")

                Dim temp As Double = 0
                Double.TryParse(value, temp)
                value = (temp * 1000).ToString()
            ElseIf Me.Name = "txtHivacRB" Then
                If arg = STR_ON Then
                    value = "Open"
                ElseIf arg = STR_OFF Then
                    value = "Close"
                Else
                    value = "Unknown"
                End If
            ElseIf Me.Name = "txtClampRB" Then
                If arg = STR_ON Then
                    value = "Clamp"
                Else
                    value = "UnClamp"
                End If
            ElseIf Me.Name = "txtRotatingModeRB" Then
                If value.Contains("Rev") Then
                    value = "Rev"
                End If
            Else
                If m_txtTextBox.UseDigitNumber = DigitsNumber.One_Digit AndAlso IsNumeric(value) Then
                    value = Format(Double.Parse(value), "0.#")
                ElseIf m_txtTextBox.UseDigitNumber = DigitsNumber.Two_Digits AndAlso IsNumeric(value) Then
                    value = Format(Double.Parse(value), "0.##")
                ElseIf m_txtTextBox.UseDigitNumber = DigitsNumber.Three_Digits AndAlso IsNumeric(value) Then
                    value = Format(Double.Parse(value), "0.###")
                ElseIf m_txtTextBox.UseDigitNumber = DigitsNumber.None_Digit AndAlso IsNumeric(value) Then
                    value = Format(Double.Parse(value), "0.")
                    ''else normal case -> we don't format, use original
                End If
            End If
            m_txtTextBox.Text = value
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
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        m_marshaller.Invoke(Of String)(New Threading.SendOrPostCallback(AddressOf UpdateGUI), Value)
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub
#End Region
End Class
