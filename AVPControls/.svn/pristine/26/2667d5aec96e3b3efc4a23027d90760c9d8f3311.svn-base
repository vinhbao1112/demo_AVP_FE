Imports System.ComponentModel
Imports AVPControls
Imports AVPControls.AVPDataLib

Public Class DepChamberControl

#Region "Fields - Events"
    Protected Const DEFAULT_TARGET_INSTALLED As Boolean = True
    Protected Const STR_DEFAULT_TARGET_INSTALLED As String = "True"

    Protected m_chuckInstalled As Boolean = True
    Protected m_targetInstalled(0) As Boolean
    Protected m_biasPlasmaOn As Boolean
    Protected m_targetPlasmaOn(0) As Boolean
    Protected m_targetSwitchIndex As Integer
    Protected m_currentTargetPosition As Integer

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Occurs when chuck installed changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event ChuckInstalledChanged As EventHandler

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Occurs when target installed changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event TargetInstalledChanged As EventHandler

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Occurs when plasma changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event BiasPlasmaChanged As EventHandler

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Occurs when current target switch index changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event TargetSwitchIndexChanged As EventHandler

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-07</date>
    ''' </author>
    ''' <summary>
    ''' Occurs when current target position changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event TargetPositionChanged As EventHandler

#End Region

#Region "Properties"


    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicating whether the chuck of chamber is installed.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "True")> _
    Public Overridable Property ChuckInstalled() As Boolean
        Get
            Return m_chuckInstalled
        End Get
        Set(ByVal value As Boolean)
            If m_chuckInstalled <> value Then
                m_chuckInstalled = value
                OnChuckInstalledChanged(EventArgs.Empty)
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicating whether the target of chamber is installed.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), STR_DEFAULT_TARGET_INSTALLED)> _
    Public Overridable Property TargetInstalled(Optional ByVal index As Integer = 0) As Boolean
        Get
            If index < 0 OrElse index >= m_targetInstalled.Length Then
                Return False
            End If

            Return m_targetInstalled(index)
        End Get
        Set(ByVal value As Boolean)
            If index < 0 OrElse index >= m_targetInstalled.Length Then
                Exit Property
            End If

            If m_targetInstalled(index) <> value Then
                m_targetInstalled(index) = value
                OnTargetInstalledChanged(EventArgs.Empty)
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicating whether plasma is on.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False")> _
    Public Overridable Property BiasPlasmaOn() As Boolean
        Get
            Return m_biasPlasmaOn
        End Get
        Set(ByVal value As Boolean)
            If m_biasPlasmaOn <> value Then
                m_biasPlasmaOn = value
                OnBiasPlasmaChanged(EventArgs.Empty)
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicating whether target plasma is on.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False")> _
    Public Overridable Overloads Property TargetPlasmaOn(ByVal index As Integer) As Boolean
        Get
            If index < 0 OrElse index >= m_targetPlasmaOn.Length Then
                Return False
            End If

            Return m_targetPlasmaOn(index)
        End Get
        Set(ByVal value As Boolean)
            If index < 0 OrElse index >= m_targetPlasmaOn.Length Then
                Exit Property
            End If

            If m_targetPlasmaOn(index) <> value Then
                m_targetPlasmaOn(index) = value
                m_plasmaOn = m_targetPlasmaOn(m_targetSwitchIndex)
                UpdateView()
            End If

        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-15</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicating whether target plasma is on.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Boolean), "False")> _
    Public Overridable Overloads Property TargetPlasmaOn() As Boolean
        Get
            Return m_targetPlasmaOn(0)
        End Get
        Set(ByVal value As Boolean)
            If m_targetPlasmaOn(0) <> value Then
                m_targetPlasmaOn(0) = value
                m_plasmaOn = m_targetPlasmaOn(m_targetSwitchIndex)
                UpdateView()
            End If

        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates current selected target index.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Integer), "0")> _
    Public Property TargetSwitchIndex() As Integer
        Get
            Return m_targetSwitchIndex
        End Get
        Set(ByVal value As Integer)
            If value < 0 OrElse value >= m_targetInstalled.Length Then
                Exit Property
            End If

            If m_targetSwitchIndex <> value Then
                m_targetPlasmaOn(m_targetSwitchIndex) = False
                m_targetSwitchIndex = value
                m_plasmaOn = m_targetPlasmaOn(m_targetSwitchIndex)
                OnTargetSwitchIndexChanged(EventArgs.Empty)
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-07</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates current target position.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(Integer), "0")> _
    Public Overridable Property CurrentTargetPosition() As Integer
        Get
            Return m_currentTargetPosition
        End Get
        Set(ByVal value As Integer)
            If value < 0 OrElse value >= m_targetInstalled.Length Then
                Exit Property
            End If

            If m_currentTargetPosition <> value Then
                m_currentTargetPosition = value
                OnTargetPositionChanged(EventArgs.Empty)
                UpdateView()
            End If
        End Set
    End Property

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates number of targets of chamber.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Property NumberOfTargets() As Integer
        Get
            Return m_targetInstalled.Length
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Exit Property
            End If

            Dim changed As Boolean
            If m_targetInstalled.Length <> value Then
                ReDim Preserve m_targetInstalled(value - 1)
                For index As Integer = 1 To m_targetInstalled.Length - 1
                    m_targetInstalled(index) = DEFAULT_TARGET_INSTALLED
                Next
                changed = True
            End If

            If m_targetPlasmaOn.Length <> value Then
                ReDim Preserve m_targetPlasmaOn(value - 1)
                changed = True
            End If

            If changed Then
                UpdateView()
            End If
        End Set
    End Property
#End Region

#Region "Methods"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Raise event ChuckInstalledChanged.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnChuckInstalledChanged(ByVal e As EventArgs)
        RaiseEvent ChuckInstalledChanged(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Raise event TargetInstalledChanged.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnTargetInstalledChanged(ByVal e As EventArgs)
        RaiseEvent TargetInstalledChanged(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Raise event OnBiasPlasmaChanged.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnBiasPlasmaChanged(ByVal e As EventArgs)
        RaiseEvent BiasPlasmaChanged(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Raise event TargetIndexChanged.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnTargetSwitchIndexChanged(ByVal e As EventArgs)
        RaiseEvent TargetSwitchIndexChanged(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Raise event CurrentTargetPosition.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnTargetPositionChanged(ByVal e As EventArgs)
        RaiseEvent TargetPositionChanged(Me, e)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-18</date>
    ''' </author>
    ''' <summary>
    ''' Gets the total of targets which were installed.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetTotalTargetInstalled() As Integer
        Dim count As Integer
        Try
            For index As Integer = 0 To m_targetInstalled.Length - 1
                If m_targetInstalled(index) Then
                    count += 1
                End If
            Next
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return count
    End Function
#End Region

#Region "Events"
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_targetInstalled(0) = DEFAULT_TARGET_INSTALLED
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-04</date>
    ''' </author>
    ''' <summary>
    ''' Change plasma status for mutil target.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DeptChamberControl_PlasmaChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PlasmaChanged
        For index As Integer = 0 To m_targetPlasmaOn.Length - 1
            m_targetPlasmaOn(index) = False
        Next
        m_targetPlasmaOn(m_targetSwitchIndex) = Me.m_plasmaOn
    End Sub
#End Region

End Class
