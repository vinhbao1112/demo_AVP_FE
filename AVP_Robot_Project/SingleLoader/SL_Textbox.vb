Imports AVP_Robot_Project.ConstantAndEnum
Imports AVPLib.ConstEnum
Imports System
Imports System.Globalization
Imports System.ComponentModel
Imports AVPControls

Public Class SL_Textbox

#Region "Property"
    Private m_blnIsIntergerNumber As Boolean = False
    Private m_bUseScientificFormat As Boolean = False
    Private m_DisplayPressureFont As Boolean = False
    Private m_UseDigitNumber As DigitsNumber = DigitsNumber.Normal
    Private m_blnIsTurboPumpTxt As Boolean = False
    Private m_strGasName As String = String.Empty
    Private m_clickable As Boolean = True
    Private m_blnIsReadBack As Boolean = False
    Private m_blnIsNumericTxt As Boolean = False
    Private m_SelectNextControl As Control = Nothing
    Public ParentStatusObj As StatusObject = Nothing
    Private m_ShowUnitFormat As Boolean = False
    Private m_UnitTypeUsed As String = String.Empty
    Private m_blnAutoSendKeyTabWhenFinishInput As Boolean = False
    Private m_UseBackGroundWorkerToUpdateMinMax As Boolean = False
    Private m_strSourceOfMessageBox As String = String.Empty
    Private m_GetDefaultMinMax As Boolean = False
    Private m_DisplayProcessFont As Boolean = False
    'For Update Min Max Value To PM
    Dim UpdateMinMaxPM_worker As ComponentModel.BackgroundWorker = Nothing 'worker for Update Min Max to PM
    Private m_blnIsGasType_SynchronizeButNoUpdateMinMaxValueToPM As Boolean = False

    Private m_strPermissionCode As String = String.Empty
    Private m_blnUseClickEventInForm As Boolean = False
    Private m_TypeOfChamberSupport As TypeOfAVPChamber = TypeOfAVPChamber.IBE
    Private m_strLogSource As String = String.Empty
    Private m_blnAutoSendEnventHandler As Boolean = False
    Private m_blmIsHighlightedGreen As Boolean = False
    Private m_dMinimumValueHighlightedGreen As Double = 0

    Public Event AutoKeyEnterPress As EventHandler

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property UseClickEventInForm() As Boolean
        Get
            Return m_blnUseClickEventInForm
        End Get
        Set(ByVal value As Boolean)
            m_blnUseClickEventInForm = value
        End Set
    End Property

    <DefaultValue(GetType(String), "")> _
 Public Property LogSource() As String
        Get
            Return m_strLogSource
        End Get
        Set(ByVal value As String)
            m_strLogSource = value
        End Set
    End Property

    Public Property TypeOfChamberSupport() As TypeOfAVPChamber
        Get
            Return m_TypeOfChamberSupport
        End Get
        Set(ByVal value As TypeOfAVPChamber)
            m_TypeOfChamberSupport = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property GetDefaultMinMax() As Boolean
        Get
            Return m_GetDefaultMinMax
        End Get
        Set(ByVal value As Boolean)
            m_GetDefaultMinMax = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property DisplayProcessFont() As Boolean
        Get
            Return m_DisplayProcessFont
        End Get
        Set(ByVal value As Boolean)
            m_DisplayProcessFont = value
        End Set
    End Property


    <DefaultValue(GetType(String), "")> _
    Public Property PermissionCode() As String
        Get
            Return m_strPermissionCode
        End Get
        Set(ByVal value As String)
            m_strPermissionCode = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
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

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsGasType_SynchronizeButNoUpdateMinMaxValueToPM() As Boolean
        Get
            Return m_blnIsGasType_SynchronizeButNoUpdateMinMaxValueToPM
        End Get
        Set(ByVal value As Boolean)
            m_blnIsGasType_SynchronizeButNoUpdateMinMaxValueToPM = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property UseScientificFormat() As Boolean
        Get
            Return m_bUseScientificFormat
        End Get
        Set(ByVal value As Boolean)
            m_bUseScientificFormat = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property DisplayPressureFont() As Boolean
        Get
            Return m_DisplayPressureFont
        End Get
        Set(ByVal value As Boolean)
            If m_DisplayPressureFont = value Then
                Return
            End If

            m_DisplayPressureFont = value
            UpdateDisplayStyle()
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsIntergerNumber() As Boolean
        Get
            Return m_blnIsIntergerNumber
        End Get
        Set(ByVal value As Boolean)
            m_blnIsIntergerNumber = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Truc Le </name>
    '''    	<date> 2011-07-26</date>
    ''' </author>
    ''' <summary>
    ''' Use this property to customize format, some text can 0.01 or 0.001 or 0.1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(DigitsNumber), "Normal")> _
    Public Property UseDigitNumber() As DigitsNumber
        Get
            Return m_UseDigitNumber
        End Get
        Set(ByVal value As DigitsNumber)
            m_UseDigitNumber = value
        End Set
    End Property

    Private m_DefaultReabackFont As Font = New Font("Arial", 11, System.Drawing.FontStyle.Bold)
    Public WriteOnly Property DefaultReabackFont() As Font
        Set(ByVal value As Font)
            m_DefaultReabackFont = value
            Me.Font = m_DefaultReabackFont
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsReadBack() As Boolean
        Get
            Return m_blnIsReadBack
        End Get
        Set(ByVal value As Boolean)
            m_blnIsReadBack = value
            UpdateDisplayStyle()
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsNumericTextbox() As Boolean
        Get
            Return m_blnIsNumericTxt
        End Get
        Set(ByVal value As Boolean)
            m_blnIsNumericTxt = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property IsTurboPumpTextbox() As Boolean
        Get
            Return m_blnIsTurboPumpTxt
        End Get
        Set(ByVal value As Boolean)
            m_blnIsTurboPumpTxt = value
        End Set
    End Property

    <DefaultValue(GetType(String), "")> _
    Public Property GasName() As String
        Get
            Return m_strGasName
        End Get
        Set(ByVal value As String)
            m_strGasName = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True")> _
    Public Property Clickable() As Boolean
        Get
            Return m_clickable
        End Get
        Set(ByVal value As Boolean)
            m_clickable = value
            If value Then
                Me.Cursor = Cursors.Hand
            Else
                Me.Cursor = Cursors.Arrow
            End If
        End Set
    End Property

    <DefaultValue(GetType(String), "")> _
    Public Property SourceOfMessageBox() As String
        Get
            Return m_strSourceOfMessageBox
        End Get
        Set(ByVal value As String)
            m_strSourceOfMessageBox = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-02-23</date>
    ''' </author>
    ''' <summary>
    ''' Show unit of value in the text box or not.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False")> _
    Public Property ShowUnitFormat() As Boolean
        Get
            Return m_ShowUnitFormat
        End Get
        Set(ByVal value As Boolean)
            m_ShowUnitFormat = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-02-23</date>
    ''' </author>
    ''' <summary>
    ''' Unit string is showed if "ShowUnitFormat" = true
    ''' Unit is: K, A, sccm, mA, V....
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    <DefaultValue(GetType(String), "")> _
    Public Property UnitTypeUsed() As String
        Get
            Return m_UnitTypeUsed
        End Get
        Set(ByVal value As String)
            m_UnitTypeUsed = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-03-30</date>
    ''' </author>
    ''' <summary>
    ''' Auto send key tab when user finish input data.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False")> _
    Public Property AutoSendKeyTabWhenFinishInput() As Boolean
        Get
            Return m_blnAutoSendKeyTabWhenFinishInput
        End Get
        Set(ByVal value As Boolean)
            m_blnAutoSendKeyTabWhenFinishInput = value
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False")> _
    Public Property AutoSendEventHandler() As Boolean
        Get
            Return m_blnAutoSendEnventHandler
        End Get
        Set(ByVal value As Boolean)
            m_blnAutoSendEnventHandler = value
        End Set
    End Property


    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-01-17</date>
    ''' </author>
    ''' <summary>
    ''' Highlighted green pbn/gas channel that is flowing match the the plumbing. Example:PNBgas,Gas1,Gas2,Gas3,Gas4. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    <DefaultValue(False), Browsable(True)> _
    Public Property IsHighlightedGreen() As Boolean
        Get
            Return m_blmIsHighlightedGreen
        End Get
        Set(ByVal value As Boolean)
            m_blmIsHighlightedGreen = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Dua Tran </name>
    '''    	<date> 2017-02-08</date>
    ''' </author>
    ''' <summary>
    ''' Minimum value for Text Box Higlighted green when Textchanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    <DefaultValue(0), Browsable(True)> _
    Public Property MinimumValueHighlightedGreen() As Double
        Get
            Return m_dMinimumValueHighlightedGreen
        End Get
        Set(ByVal value As Double)
            m_dMinimumValueHighlightedGreen = value
        End Set
    End Property

#End Region

#Region "Private method"

    Private Sub SL_Textbox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        If m_blnUseClickEventInForm = True Or Clickable = False Or IsReadBack = True Then
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(PermissionCode) Then
            If AVPLib.ContainerData.Permission(PermissionCode) = False Then
                Exit Sub
            End If
        End If
        Try
            If IsNumericTextbox Then
                ShowNumPad()
            Else
                ShowKeyPad()
            End If
            If AutoSendKeyTabWhenFinishInput Then
                SendKeys.Send("{TAB}")
            End If

            If AutoSendEventHandler Then
                RaiseEvent AutoKeyEnterPress("", Nothing)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub ShowPad()
        If Clickable = False Or IsReadBack = True Then
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(PermissionCode) Then
            If AVPLib.ContainerData.Permission(PermissionCode) = False Then
                Exit Sub
            End If
        End If
        Try
            If IsNumericTextbox Then
                ShowNumPad()
            Else
                ShowKeyPad()
            End If
            If AutoSendKeyTabWhenFinishInput Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-12-19</date>
    ''' </author>
    ''' <summary>
    ''' txt_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub SL_Textbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        Try
            Dim textBox As TextBox = CType(sender, TextBox)
            If IsTurboPumpTextbox() Then
                If Not textBox.Text.Contains("K") Then
                    textBox.Text = Utils.SignificantFigures(textBox.Text)
                End If
            End If
            If ShowUnitFormat() Then
                If Not String.IsNullOrEmpty(UnitTypeUsed) AndAlso Not textBox.Text.Contains(UnitTypeUsed) Then
                    textBox.Text = textBox.Text & UnitTypeUsed
                End If
            End If

            If (IsIntergerNumber) Then
                If (IsNumeric(textBox.Text)) Then
                    Dim strRs As Integer = textBox.Text
                    textBox.Text = strRs
                Else
                    textBox.Text = ""
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub ShowNumPad()
        Dim chamberName As String = String.Empty
        Dim Source_Title As String = String.Empty
        Dim Source As String = GetSource()

        Dim chamberID As String = String.Empty
        Dim headSource As String = GetHeadSource()
        If Not String.IsNullOrEmpty(headSource) Then
            If headSource.Contains(".") Then
            chamberID = headSource.Substring(0, headSource.IndexOf("."))
            Else
                chamberID = headSource
            End If
            If Not String.IsNullOrEmpty(chamberID) Then
                chamberName = AVPLib.Utils.chamberID2ChamberName(chamberID)
                If chamberName = chamberID Then
                    If chamberID.Equals("CassettesPanel") Then
                        chamberName = "TM"
                    Else
                        chamberName = String.Empty
                    End If

                End If
            End If
        End If

        'Source_Title = TypeOfChamberSupport.ToString() & "." & Me.Name
        Source_Title = IIf(Me.AccessibleDescription <> String.Empty, TypeOfChamberSupport.ToString() & "." & Me.AccessibleDescription, TypeOfChamberSupport.ToString() & "." & Me.Name)

        Dim frm As New NumPad
        Dim Min As Double = MINDEFAULT
        Dim Max As Double = MAXDEFAULT

        If Me.Name = "txtShieldMin" OrElse Me.Name = "txtQuartzMin" Then
            Source = "SystemSetup.ShieldsQuartz."
        End If

        ''get Min/Max value from config file -> if failed, get default value
        If GetDefaultMinMax = False Then
            Double.TryParse(AVPLib.ContainerData.GetRobotConfig(Source + STRING_MIN).ToString(), Min)
            Double.TryParse(AVPLib.ContainerData.GetRobotConfig(Source + STRING_MAX).ToString(), Max)
        End If
        Dim Title As String = AVPLib.ContainerData.GetMessageText(Source_Title)
        Dim TitleBase As String = Title
        Dim strPreviousValue As String = Me.Text
        If String.IsNullOrEmpty(Title) Then
            Title = AVPLib.ContainerData.GetMessageText(Source)
            TitleBase = Title

            '2015-07-08: Hai Tran: If Title still empty, try to get last one
            If String.IsNullOrEmpty(Title) Then
                If Source.StartsWith("Chamber") Then
                    Title = AVPLib.ContainerData.GetMessageText(Source.Substring(Source.IndexOf(".") + 1))
                    TitleBase = Title
                End If
            End If

        End If

        Dim value As String = Me.Text
        If Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD2R4 _
           OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD4 _
           OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD5T _
           OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.IBD Then
            If String.IsNullOrEmpty(TitleBase) AndAlso Not String.IsNullOrEmpty(Me.AccessibleDescription) Then
                Title = String.Format("Would you like to change {0} value to?", Me.AccessibleDescription)
            Else
                Title = String.Format(TitleBase, Me.AccessibleName)
            End If
        End If
        If Me.Name.Contains("Gas") Then
            If (GetDefaultMinMax = False) And (Me.GasName <> String.Empty) Then
                Title = String.Format(TitleBase, GasName)
            End If
        End If
        ''finally if title is still null
        If String.IsNullOrEmpty(Title) Then
            'set default value instead!
            Title = "Would you like to change value?"
        End If

        Dim InputRes As MsgBoxResult = frm.GetUserInput(value, -1, -1, Min, Max, Title)

        Dim messageLog As String = String.Empty
        If frm.IsMaxMinModified Then
            UpdateMinMaxValue(Source, frm.NewMin.ToString(), frm.NewMax.ToString())

            If Source.Contains("IBE.txtTiltAngleRight") Then
                UpdateMinMaxValue(ParentStatusObj.Parent.Name + ".IBE.txtTiltSweepRight", frm.NewMin.ToString(), frm.NewMax.ToString())
                UpdateMinMaxValue(ParentStatusObj.Parent.Name + ".IBE.txtTiltEnd", frm.NewMin.ToString(), frm.NewMax.ToString())
            ElseIf Source.Contains("IBE.txtTiltSweepRight") Then
                UpdateMinMaxValue(ParentStatusObj.Parent.Name + ".IBE.txtTiltAngleRight", frm.NewMin.ToString(), frm.NewMax.ToString())
                UpdateMinMaxValue(ParentStatusObj.Parent.Name + ".IBE.txtTiltEnd", frm.NewMin.ToString(), frm.NewMax.ToString())
            ElseIf Source.Contains("IBE.txtTiltEnd") Then
                UpdateMinMaxValue(ParentStatusObj.Parent.Name + ".IBE.txtTiltAngleRight", frm.NewMin.ToString(), frm.NewMax.ToString())
                UpdateMinMaxValue(ParentStatusObj.Parent.Name + ".IBE.txtTiltSweepRight", frm.NewMin.ToString(), frm.NewMax.ToString())
            End If

            If Min <> frm.NewMin Then
                Utils.LogUserEvent(String.Format("Changed MIN of {0} from {1} to {2}", Utils.GetLogName(Me), Min, frm.NewMin), Utils.GetPMContainer(Me))
            End If

            If Max <> frm.NewMax Then
                Utils.LogUserEvent(String.Format("Changed MAX of {0} from {1} to {2}", Utils.GetLogName(Me), Max, frm.NewMax), Utils.GetPMContainer(Me))
            End If
        End If

        If InputRes = MsgBoxResult.Ok Then
            ' Log
            Utils.LogUserEvent(Me, "", "", "", Text, value)

            Text = value

            Try
                'change to scientific format
                Dim strRetValue As String = Text
                If Me.Name = "txtBeamCurrentRight" Then
                    'convert mA to A
                    strRetValue = Utils.Contvert_mA2A(Text)
                End If
                If UseScientificFormat Then
                    strRetValue = Format(Double.Parse(Text), AVPLib.ConstEnum.SCIENTIFIC_FORMAT)
                    Text = strRetValue
                End If

                Dim isOK As Boolean = True
                If TypeOfChamberSupport = TypeOfAVPChamber.IBE Then
                    isOK = OnlyUseWith_SLIBE(chamberName, strPreviousValue)
                End If

                If ParentStatusObj IsNot Nothing Then
                    If Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD2R4 _
                        OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD4 _
                        OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.PVD5T _
                        OrElse Me.TypeOfChamberSupport = TypeOfAVPChamber.IBD Then

                        Dim strname As String = Me.AccessibleName.Replace(" ", "")
                        ParentStatusObj.RequestStatus(strname, strRetValue)
                    Else
                        If isOK Then
                            ParentStatusObj.RequestStatus(Me.Name, strRetValue)
                        End If
                    End If
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End If
    End Sub

    Private Function OnlyUseWith_SLIBE(ByVal chamberName As String, ByVal strPreviousValue As String) As Boolean
        Dim blnResult As Boolean = True

        Try
            'Text = strRetValue
            If (Me.Name = "txtPBNGasRight_SourceTab") _
               OrElse (Me.Name = "txtGas1Right_SourceTab") _
               OrElse (Me.Name = "txtGas2Right_SourceTab") Then
                ''if this is AVP_IBE -> we do not send command to IBE, we send those command when click AutoBeam
                If ParentStatusObj IsNot Nothing AndAlso ParentStatusObj.Name.Contains(ConstantAndEnum.CHAMBER) Then
                    chamberName = ParentStatusObj.Name
                ElseIf ParentStatusObj IsNot Nothing AndAlso _
                            ParentStatusObj.Parent IsNot Nothing AndAlso _
                             ParentStatusObj.Parent.Name.Contains(ConstantAndEnum.CHAMBER) Then
                    chamberName = ParentStatusObj.Parent.Name
                End If

                Dim chamberConfig As AVPLib.SystemModule = AVPLib.ContainerData.GetRobotConfig(chamberName)
                '''If IBE is Veeco or AVP_IBE in Auto Beam On -> send new value
                If chamberConfig IsNot Nothing Then
                    Dim pnlIBE As IBEPanel = ContainerForm.ChamberPanel(chamberName)
                    ''VeecoIBE or AVP_IBE with AutoBeam On
                    If Not (chamberConfig.IBE_Type = AllChamberType.VEECO_IBE OrElse _
                                pnlIBE.btnAutoBeam.Status = SL_CustomButton.DisplayStatus.On) Then
                        blnResult = False
                        Exit Try
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return blnResult
    End Function

    Private Sub ShowKeyPad()
        Dim Source As String = TypeOfChamberSupport.ToString() & "." & Me.Name
        Dim Title As String = AVPLib.ContainerData.GetMessageText(Source)
        Dim pad As New KeyPad
        Dim Value As String = Text
        If Me.Name.Contains("Gas") Then
            Title = String.Format(Title, GasName)
        End If
        If String.IsNullOrEmpty(Title) Then
            Title = "Enter your " & Me.AccessibleDescription
        End If
        If pad.DisplayKeypad(Value, Title, False) = DialogResult.OK Then
            Text = Value
            If ParentStatusObj IsNot Nothing Then
                ParentStatusObj.RequestStatus(Name, Text)
            End If
        End If
    End Sub

    Private Sub SL_Textbox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.SL_Textbox_Click(sender, Nothing)
        End If
    End Sub

    Private Sub OnWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        If Me.UpdateMinMaxPM_worker.CancellationPending Then
            e.Cancel = True
            Return
        End If
        Dim params As List(Of String) = CType(e.Argument, List(Of String))
        AVPLib.ContainerDAO.UpdatePMMinMaxValue(params)
    End Sub

    ''' <author>
    '''    <name>Hai Tran</name>
    '''    <date>2016-01-13</date>
    ''' </author>
    ''' <summary>
    ''' Update display style of the text box.
    ''' </summary>
    Private Sub UpdateDisplayStyle()
        DefaultReabackFont = New Font("Arial", 11, System.Drawing.FontStyle.Bold)
        If Me.IsReadBack Then
            If DisplayProcessFont Then
                DefaultReabackFont = New Font("Arial", 8, System.Drawing.FontStyle.Bold)
            End If
            Me.Cursor = Cursors.Arrow
            If DisplayPressureFont Then
                Me.BackColor = Color.FromArgb(0, 0, 0)
                Me.ForeColor = Color.Lime
            Else
                Me.BackColor = Color.FromArgb(224, 221, 212)
            End If
        Else
            Me.Cursor = Cursors.Hand
            Me.BackColor = Color.White
            Me.Enabled = True
        End If
    End Sub
#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.Font = New Font("Times New Roman", 12, FontStyle.Regular)
        Me.ReadOnly = True
        GetSource()
    End Sub

#Region "Public methods"

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
            '#End fix

            If UpdateMinMaxPM_worker.IsBusy Then
                UpdateMinMaxPM_worker.CancelAsync()
                Exit Sub
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
    ''' Update MinMax Value
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateMinMaxValue(ByVal Source As String, ByVal NewMin As String, ByVal NewMax As String, Optional ByVal blnUpdateRecipeScreen As Boolean = True)
        Try
            AVPLib.ContainerData.SetRobotConfig(Source + STRING_MIN, NewMin)
            AVPLib.ContainerData.SetRobotConfig(Source + STRING_MAX, NewMax)
            If UseBackGroundWorkerToUpdateMinMax Then
                If blnUpdateRecipeScreen Then
                    Utils.SynchronizeMinMaxValueToRecipeScreen(Source, NewMin, NewMax)
                End If
                UpdateMinMaxValueToPM(Source, NewMin, NewMax)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error("Failed to update Min/Max value for " & Source & " detail:" & ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-08-18 </date>
    ''' </author>
    ''' <summary>
    ''' Get source of textbox to use to get message text and update min/max value
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetSource() As String
        Dim strSource As String = String.Empty
        Try
            If Not String.IsNullOrEmpty(SourceOfMessageBox) Then
                Return SourceOfMessageBox & "." & Me.Name
            End If
            If ParentStatusObj IsNot Nothing AndAlso ParentStatusObj.Name.Contains(ConstantAndEnum.CHAMBER) Then
                strSource = ParentStatusObj.Name & "." & TypeOfChamberSupport.ToString() & "." & Me.Name
            ElseIf ParentStatusObj IsNot Nothing AndAlso _
                        ParentStatusObj.Parent IsNot Nothing AndAlso _
                        ParentStatusObj.Parent.Name IsNot Nothing AndAlso _
                         ParentStatusObj.Parent.Name.Contains(ConstantAndEnum.CHAMBER) Then
                strSource = ParentStatusObj.Parent.Name & "." & TypeOfChamberSupport.ToString() & "." & Me.Name
            Else
                strSource = TypeOfChamberSupport.ToString() & "." & Me.Name
            End If

        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return strSource
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2015-07-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get top source of textbox to use to get chamber contains this textbox
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetHeadSource() As String
        Dim strSource As String = String.Empty
        Try
            strSource = Me.Name
            Dim statusObj As StatusObject = ParentStatusObj
            Dim maxLoopCount As Int32 = 10
            Dim loopCount As Int32 = 0
            While statusObj IsNot Nothing AndAlso loopCount < maxLoopCount
                If (Not String.IsNullOrEmpty(statusObj.Name)) Then
                    strSource = statusObj.Name & "." & strSource
                End If
                statusObj = statusObj.Parent
                loopCount = loopCount + 1
            End While
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return strSource
    End Function

    ''' <author>
    '''    	<name> Hai Tran </name>
    '''    	<date> 2016-11-11 </date>
    ''' </author>
    ''' <summary>
    ''' Get container chamber ID of textbox.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetContainerChamberID() As String
        Dim chamberID As String = String.Empty
        Try
            Dim headSource As String = GetHeadSource()
            If Not String.IsNullOrEmpty(headSource) Then
                If headSource.Contains(".") Then
                    chamberID = headSource.Substring(0, headSource.IndexOf("."))
                Else
                    chamberID = headSource
                End If
                If Not String.IsNullOrEmpty(chamberID) Then
                    Dim chamberName As String = AVPLib.Utils.chamberID2ChamberName(chamberID)
                    If chamberName = chamberID Then
                        If chamberID.Equals("CassettesPanel") Then
                            chamberID = "TM"
                        Else
                            chamberID = String.Empty
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return chamberID
    End Function

#End Region

End Class

