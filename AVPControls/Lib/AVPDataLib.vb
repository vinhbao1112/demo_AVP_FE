Public Class AVPDataLib

#Region "Contanst - Fields"
    Public Const DEG_TO_RAD_RATIO As Double = Math.PI / 180.0
    Public Const RAD_TO_DEG_RATIO As Double = 180.0 / Math.PI
    Public Shared STATUS_NONE_COLOR As Color = Color.FromArgb(100, 150, 200)
    Public Shared STATUS_OFF_COLOR As Color = Color.FromArgb(0, 0, 255)
    Public Shared STATUS_ON_COLOR As Color = Color.FromArgb(0, 255, 0)
    Public Shared STATUS_ERROR_COLOR As Color = Color.FromArgb(255, 0, 0)
    Public Shared STATUS_UNKNOWN_COLOR As Color = Color.FromArgb(255, 255, 0)
    Public Shared TEXT_NONE_COLOR As Color = Color.White
    Public Shared TEXT_OFF_COLOR As Color = Color.White
    Public Shared TEXT_ON_COLOR As Color = Color.Black
    Public Shared TEXT_ERROR_COLOR As Color = Color.White
    Public Shared TEXT_UNKNOWN_COLOR As Color = Color.Black

    Public Const InlinePropertyCategoryName As String = "Inline Properties"

#End Region

#Region "Style"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-01-04</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates color of text base on display status.
    ''' </summary>
    ''' <param name="status">The status of control.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetTextColor(ByVal status As DisplayStatus) As Color
        Dim textColor As Color = TEXT_NONE_COLOR
        Select Case status
            Case DisplayStatus.Off
                textColor = TEXT_OFF_COLOR
            Case DisplayStatus.On
                textColor = TEXT_ON_COLOR
            Case DisplayStatus.Error
                textColor = TEXT_ERROR_COLOR
            Case DisplayStatus.Unknow
                textColor = TEXT_UNKNOWN_COLOR
        End Select
        Return textColor
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-01-04</date>
    ''' </author>
    ''' <summary>
    ''' Gets or sets a value indicates color of text base on wafer status.
    ''' </summary>
    ''' <param name="waferStatus">The status of wafer.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetTextColor(ByVal waferStatus As WaferStatuses) As Color
        Dim textColor As Color = TEXT_NONE_COLOR
        Select Case waferStatus
            Case WaferStatuses.UNPROCESS
                textColor = TEXT_OFF_COLOR
            Case WaferStatuses.COMPLETE
                textColor = TEXT_ON_COLOR
            Case WaferStatuses.ERROR
                textColor = TEXT_ERROR_COLOR
            Case WaferStatuses.PARTIAL
                textColor = TEXT_UNKNOWN_COLOR
        End Select
        Return textColor
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-01-04</date>
    ''' </author>
    ''' <summary>
    ''' Parse another value to wafer status.
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseWaferStatus(ByVal value As String) As WaferStatuses
        If String.IsNullOrEmpty(value) Then
            Return WaferStatuses.NONE
        End If
        Try
            value = value.ToLower()
            Select Case value
                Case "unprocess", "on"
                    Return WaferStatuses.UNPROCESS
                Case "partial", "unknow", "unknown", "unk"
                    Return WaferStatuses.PARTIAL
                Case "error", "err"
                    Return WaferStatuses.ERROR
                Case "complete", "completed", "off"
                    Return WaferStatuses.COMPLETE
                Case Else
                    Return WaferStatuses.NONE
            End Select
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return WaferStatuses.NONE
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2016-01-04</date>
    ''' </author>
    ''' <summary>
    ''' Parse another value to display status.
    ''' </summary>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ParseDisplayStatus(ByVal value As String) As DisplayStatus
        If String.IsNullOrEmpty(value) Then
            Return DisplayStatus.None
        End If

        Try
            value = value.ToLower()
            Select Case value
                Case "off", "closed", "close", "false", "unprocess", "false"
                    Return DisplayStatus.Off
                Case "on", "opened", "open", "true", "complete", "completed", "true"
                    Return DisplayStatus.On
                Case "unknown", "unknow", "unk", "partial"
                    Return DisplayStatus.Unknow
                Case "error", "err"
                    Return DisplayStatus.Error
                Case Else
                    Return DisplayStatus.None
            End Select
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return DisplayStatus.None
    End Function
#End Region

#Region "Enums"
    Public Enum DisplayStatus
        [Off] = 0
        [On] = 1
        [Error] = 2
        [Unknow] = 3
        [None] = 4
    End Enum

    Public Enum AVPControlStyleModes
        None
        Inherit
        ControlOwner
        ControlOnly
    End Enum

    Public Enum AVPBorderStyles
        None
        AVP3D
        AVP3DDown
    End Enum

    Public Enum AVPAlignStyles
        Left
        Right
    End Enum

    Public Enum AVPDirections
        Left
        Right
        Up
        Down
        Unknown
    End Enum

    Public Enum MotorStatuses
        Off = 0
        Forward
        Reverse
    End Enum

    Public Enum PodPumpingStatus
        Available
        Waiting
        Pumping
        Venting
        PumpFailed
        VentFailed
    End Enum

    Public Enum PodTypes
        Type1
        Type2
    End Enum

#End Region

#Region "AVPs"
    Public Enum AVPStyles
        CX4
        CX5
        CX6
        CX7
        CX8
        SL
        ML
        Inline
        PodSystem
        StandAlone
    End Enum

    Public Enum AVPScreens
        MaintenanceScreen
        ProcessScreen
        AlignerScreen
        PM1Screen
        PM2Screen
        PM3Screen
        PM4Screen
        PM5Screen
        PM6Screen
        GEMScreen
    End Enum

    Public Enum AVPChamberTypes
        Undefined
        LoadLock
        IBE
        PVD
        PVD_A
        PVD2R4
        PVD6S
        PVD6P
        HRPVD
        IBD
        RIE
        Aligner
        MechanicalAligner
        PVD4
        VIBD
        VIBE
        InlinePM
        PodSystem
        PVDA_SA
        PVD2T
        PVDS
    End Enum

    Public Enum AVPDockPositions
        Undefined = -1
        LLA = 0
        PM1 = 1
        PM2 = 2
        PM3 = 3
        PM4 = 4
        PM5 = 5
        PM6 = 6
        LLB = 7
        HivacTM = 8
        HivacLLA = 9
        HivacLLB = 10
        HivacInlinePM = 11
        HivacLoader = 12
    End Enum

    Public Enum LoadLockName
        LoadLockA
        LoadLockB
    End Enum

    Public Enum InlineChamberTypes
        LoadLock
        PM
    End Enum

    Public Enum ShutterTypes
        EtchShutter
        DepShutter
        TargetShutter
    End Enum

#End Region

#Region "RobotArm"
    Public Enum ArmStatuses
        Retract = 0
        Extend = 1
    End Enum

    Public Enum RobotArmStations
        Original = 0
        LLA = 1
        PM1 = 2
        PM2 = 3
        PM3 = 4
        PM4 = 5
        PM5 = 6
        PM6 = 7
        LLB = 10
        Aligner = 9
        Aligner2 = 11
    End Enum

    ''' <author>Hai Tran</author>
    ''' <date>2017-02-26</date>
    ''' <summary>
    ''' Stations of RobotArm of MultiLoader.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum LoaderArmStations
        Home
        Cassette
        PM
        ToCheck
        Retract
    End Enum

#End Region

#Region "Wafers"
    Public Const WAFER_DIAMETER_CX4 As Integer = 35
    Public Const WAFER_DIAMETER_CXX As Integer = 38
    Public Const WAFER_DIAMETER_CX5 As Integer = 48
    Public Const WAFER_DIAMETER_SL As Integer = 62
    Public Const WAFER_DIAMETER_ML As Integer = 50
    Public Const WAFER_DIAMETER_ML_PVD4 As Integer = 47
    Public Const WAFERID_FONT_NAME As String = "Times New Roman"
    Public Const WAFERID_FONT_STYLE As FontStyle = FontStyle.Bold

    Public Enum WaferStatuses
        NONE = 0
        UNPROCESS = 1
        [PARTIAL] = 2
        COMPLETE = 3
        [ERROR] = 4
    End Enum

    ''' <author>Hai Tran</author>
    ''' <date>2015-09-10</date>
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure WaferInfo
        Private m_waferID As String
        Private m_waferStatus As WaferStatuses

        Public Sub New(ByVal waferID As String, ByVal waferStatus As WaferStatuses)
            m_waferID = waferID
            m_waferStatus = waferStatus
        End Sub

        Public Sub New(ByVal waferInfo As WaferInfo)
            m_waferID = waferInfo.m_waferID
            m_waferStatus = waferInfo.m_waferStatus
        End Sub

        ''' <summary>
        ''' Get or set the WaferID of this instance
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WaferID() As String
            Get
                Return m_waferID
            End Get
            Set(ByVal value As String)
                m_waferID = value
            End Set
        End Property

        ''' <author>Hai Tran</author>
        ''' <date>2015-09-10</date>
        ''' <summary>
        ''' Get or set the WaferStatus of this instance
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WaferStatus() As WaferStatuses
            Get
                Return m_waferStatus
            End Get
            Set(ByVal value As WaferStatuses)
                m_waferStatus = value
            End Set
        End Property

        ''' <author>Hai Tran</author>
        ''' <date>2015-09-10</date>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="left"></param>
        ''' <param name="right"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Operator <>(ByVal left As WaferInfo, ByVal right As WaferInfo) As Boolean
            Return (left.m_waferStatus <> right.m_waferStatus OrElse left.m_waferID <> right.m_waferID)
        End Operator

        ''' <author>Hai Tran</author>
        ''' <date>2015-09-10</date>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="left"></param>
        ''' <param name="right"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Operator =(ByVal left As WaferInfo, ByVal right As WaferInfo) As Boolean
            Return (left.m_waferStatus = right.m_waferStatus AndAlso left.m_waferID = right.m_waferID)
        End Operator

        ''' <author>Hai Tran</author>
        ''' <date>2015-09-10</date>
        ''' <summary>
        ''' Indicates whether the specified WaferInfo is empty
        ''' </summary>
        ''' <param name="value"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function IsEmpty(ByVal value As WaferInfo) As Boolean
            Return (value.m_waferStatus = WaferStatuses.NONE AndAlso String.IsNullOrEmpty(value.m_waferID))
        End Function

        ''' <author>Hai Tran</author>
        ''' <date>2015-09-10</date>
        ''' <summary>
        ''' Indicates whether the specified object is equal with this WaferInfo
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If TypeOf obj Is WaferInfo Then
                Dim value As WaferInfo = CType(obj, WaferInfo)
                Return (m_waferStatus = value.m_waferStatus AndAlso m_waferID = value.m_waferID)
            End If
            Return False
        End Function
    End Structure

    ''' <author>
    '''      <name>Hai Tran</name>
    '''      <date>2015-09-14</date>
    ''' </author>
    ''' <summary>
    ''' Get a value indicates the wafer diameter of wafer
    ''' </summary>
    ''' <param name="avpStyle"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property WAFER_DIAMETER(ByVal avpStyle As AVPStyles, Optional ByVal chamberType As AVPChamberTypes = AVPChamberTypes.Undefined) As Integer
        Get
            Select Case avpStyle
                Case AVPStyles.CX6, AVPStyles.CX7, AVPStyles.CX8
                    Return WAFER_DIAMETER_CXX
                Case AVPStyles.CX5
                    Return WAFER_DIAMETER_CX5
                Case AVPStyles.SL
                    Return WAFER_DIAMETER_SL
                Case AVPStyles.ML
                    If chamberType = AVPChamberTypes.PVD4 Then
                        Return WAFER_DIAMETER_ML_PVD4
                    End If
                    Return WAFER_DIAMETER_ML
                Case AVPStyles.CX4
                    Return WAFER_DIAMETER_CX4
                Case Else
                    Return WAFER_DIAMETER_CX5
            End Select
        End Get
    End Property
#End Region

#Region "Control Events"

#End Region

#Region "Get Random Numbers"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-15</date>
    ''' </author>
    ''' <summary>
    ''' Get a random-number in range from specified min value to max value.
    ''' </summary>
    ''' <param name="minValue"></param>
    ''' <param name="maxValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetRandom(ByVal minValue As Integer, ByVal maxValue As Integer) As Integer
        Static rd As New Random(Environment.TickCount)
        Return rd.Next(minValue, maxValue)
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-15</date>
    ''' </author>
    ''' <summary>
    ''' Get a random-number in range from 0 to specified value.
    ''' </summary>
    ''' <param name="maxValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetRandom(ByVal maxValue As Integer) As Integer
        Static rd As New Random
        Return rd.Next(maxValue)
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-15</date>
    ''' </author>
    ''' <summary>
    ''' Get a random-number in range from specified min value to max value.
    ''' </summary>
    ''' <param name="minValue"></param>
    ''' <param name="maxValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetRandom(ByVal minValue As Single, ByVal maxValue As Single) As Single
        Static rd As New Random
        Return minValue + CSng((maxValue - minValue) * rd.NextDouble())
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-15</date>
    ''' </author>
    ''' <summary>
    ''' Get a random-number in range from 0 to specified value.
    ''' </summary>
    ''' <param name="maxValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetRandom(ByVal maxValue As Single) As Single
        Static rd As New Random
        Return CSng(maxValue * rd.NextDouble())
    End Function
#End Region

#Region "Math"
    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-25</date>
    ''' </author>
    ''' <summary>
    ''' Convert specfied angle in degree to radian.
    ''' </summary>
    ''' <param name="angle">The value of angle in degree to be converted.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DegToRad(ByVal angle As Double) As Double
        Return angle * DEG_TO_RAD_RATIO
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-25</date>
    ''' </author>
    ''' <summary>
    ''' Convert specfied angle in radion to degree.
    ''' </summary>
    ''' <param name="rad">The value of angle in radian to be converted.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function RadToDeg(ByVal rad As Double) As Double
        Return rad * RAD_TO_DEG_RATIO
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-07 </date>
    ''' </author>
    ''' <summary>
    ''' Calculate distance between two angle by clockwise from angle1 to angle2
    ''' </summary>
    Public Shared Function CalculateDistanceAngle(ByVal angle1 As Single, ByVal angle2 As Single) As Single
        Dim result As Single = 0

        angle1 = angle1 Mod 360
        angle2 = angle2 Mod 360
        If angle1 < 0 Then
            angle1 = 360 + angle1
        End If

        If angle2 < 0 Then
            angle2 = 360 + angle2
        End If

        Dim distanceToZeroAngle1 As Single = 360 - angle1
        result = angle2 + distanceToZeroAngle1
        result = result Mod 360

        Return result
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-07 </date>
    ''' </author>
    ''' <summary>
    ''' Calculate minimum distance between two angle
    ''' </summary>
    Public Shared Function GetMinimumDistanceAngle(ByVal angle1 As Single, ByVal angle2 As Single) As Single
        Dim result As Single = 0

        Dim d1to2 As Single = CalculateDistanceAngle(angle1, angle2)
        Dim d2to1 As Single = CalculateDistanceAngle(angle2, angle1)
        If d1to2 < d2to1 Then
            result = d1to2
        Else
            result = d2to1
        End If

        Return result
    End Function
#End Region

End Class