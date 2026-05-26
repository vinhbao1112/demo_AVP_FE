Imports AVPLib.ConstEnum
Imports System.Threading
Imports AVPControls

Public Class Robot
    Private m_strWaferID As String = String.Empty
#Region "Class Constants & Variables"
    Private m_strName As String
    ' Private m_robotHand As RobotHand = Nothing
    Private m_robotHandNew As RobotArmControl
    Private m_enmCurrentPostion As AVPLib.ConstEnum.Positions
    Private m_enmWaferStatus As AVPLib.ConstEnum.enumWaferStatus = AVPLib.ConstEnum.enumWaferStatus.eWaferNone

    Public Property WaferID() As String
        Get
            Return m_strWaferID
        End Get
        Set(ByVal value As String)
            If m_strWaferID <> value Then
                m_strWaferID = value
                m_robotHandNew.WaferID = value
            End If
        End Set
    End Property

    Public Property WaferStatus() As AVPLib.ConstEnum.enumWaferStatus
        Get
            Return m_enmWaferStatus
        End Get
        Set(ByVal value As AVPLib.ConstEnum.enumWaferStatus)
            If m_enmWaferStatus <> value Then
                m_robotHandNew.WaferStatus = value
                m_enmWaferStatus = value
            End If
        End Set
    End Property
#End Region

#Region "Public Properties"
    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-09-10</date>
    ''' </author>
    ''' <summary>
    ''' Get or set name of robot
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name()
        Get
            Return m_strName
        End Get
        Set(ByVal value)
            m_strName = value
        End Set
    End Property
    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-10-10</date>
    ''' </author>
    ''' <summary>
    ''' Get or set hand shape control
    ''' </summary>
    ''' <param name="enmPosistion"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Hands() As RobotArmControl
        Get
            Return m_robotHandNew
        End Get
        Set(ByVal value As RobotArmControl)
            Try
                m_robotHandNew = value
                m_robotHandNew.WaferID = Me.WaferID
                m_robotHandNew.WaferStatus = Me.WaferStatus
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Set
    End Property

#End Region

#Region "Constructor & Destructor"
    ''' <author>
    ''' <name> Ngo Cao Dinh </name>
    ''' <date> 2008-09-10</date>
    ''' </author>
    ''' <summary>
    ''' Initiate robot
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal strName As String)
        m_strName = strName
    End Sub
#End Region

#Region "Public Methods"
    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-10-10</date>
    ''' </author>
    ''' <summary>
    ''' Rotate robot hand to specific position
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RotateTo(ByVal enmPosition As Positions)
        AVPLib.Log.guiLogger.Info("Enter RotateTo")
        Try
            If Not m_enmCurrentPostion = enmPosition Then
                m_enmCurrentPostion = enmPosition
                With m_robotHandNew
                    .WaferID = Me.WaferID
                    '.WaferStatus = Me.WaferStatus
                    Select Case enmPosition
                        '
                        'Aligner, Aligner_DeltaPick
                        ' 
                        Case Positions.Aligner_Extract, Positions.Arm_At_Aligner_Wafer_Extract, _
                             Positions.Aligner_Extract_DeltaPick, Positions.Arm_At_Aligner_Wafer_Extract_DeltaPick
                            .ArmStation = AVPControls.AVPDataLib.RobotArmStations.Aligner
                            .ArmStatus = AVPControls.AVPDataLib.ArmStatuses.Extend

                        Case Positions.Arm_At_Aligner_Retract, Positions.Arm_At_Aligner_Retract_with_Wafer, _
                             Positions.Arm_At_Aligner_Retract_with_Wafer_DeltaPick, Positions.Arm_At_Aligner_Retract_DeltaPick
                            .ArmStation = AVPControls.AVPDataLib.RobotArmStations.Aligner
                            .ArmStatus = AVPControls.AVPDataLib.ArmStatuses.Retract

                            '
                            'Chamber1
                            '
                        Case Positions.Arm_At_Chamber1_Extract, Positions.Arm_At_Chamber1_Wafer_Extract
                            .ArmStation = AVPControls.AVPDataLib.RobotArmStations.PM1
                            .ArmStatus = AVPControls.AVPDataLib.ArmStatuses.Extend

                        Case Positions.Arm_At_Chamber1_Wafer, Positions.Chamber1
                            .ArmStation = AVPControls.AVPDataLib.RobotArmStations.PM1
                            .ArmStatus = AVPControls.AVPDataLib.ArmStatuses.Retract

                            '
                            'Chamber2
                            '
                        Case Positions.Arm_At_Chamber2_Extract, Positions.Arm_At_Chamber2_Wafer_Extract
                            .ArmStation = AVPControls.AVPDataLib.RobotArmStations.PM2
                            .ArmStatus = AVPControls.AVPDataLib.ArmStatuses.Extend

                        Case Positions.Arm_At_Chamber2_Wafer, Positions.Chamber2
                            .ArmStation = AVPControls.AVPDataLib.RobotArmStations.PM2
                            .ArmStatus = AVPControls.AVPDataLib.ArmStatuses.Retract

                            '
                            'Chamber3
                            '
                        Case Positions.Arm_At_Chamber3_Extract, Positions.Arm_At_Chamber3_Wafer_Extract
                            .ArmStation = AVPControls.AVPDataLib.RobotArmStations.PM3
                            .ArmStatus = AVPControls.AVPDataLib.ArmStatuses.Extend

                        Case Positions.Arm_At_Chamber3_Wafer, Positions.Chamber3
                            .ArmStation = AVPControls.AVPDataLib.RobotArmStations.PM3
                            .ArmStatus = AVPControls.AVPDataLib.ArmStatuses.Retract

                            '
                            'LLA
                            '
                        Case Positions.Arm_At_LLA_Extract, Positions.Arm_At_LLA_Wafer_Extract
                            .ArmStation = AVPControls.AVPDataLib.RobotArmStations.LLA
                            .ArmStatus = AVPControls.AVPDataLib.ArmStatuses.Extend

                        Case Positions.Arm_At_LLA_Wafer, Positions.LoadLockA
                            .ArmStation = AVPControls.AVPDataLib.RobotArmStations.LLA
                            .ArmStatus = AVPControls.AVPDataLib.ArmStatuses.Retract

                            '
                            'Original
                            '
                        Case Positions.Original, Positions.Unknown
                            .ArmStation = AVPControls.AVPDataLib.RobotArmStations.Original
                            .ArmStatus = AVPControls.AVPDataLib.ArmStatuses.Retract
                    End Select
                    AVPLib.Log.avpLogger.Error(enmPosition.ToString())
                End With
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave RotateTo")
    End Sub
    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-10-10</date>
    ''' </author>
    ''' <summary>
    ''' Initiate the positon of Robot at original position
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initiate()
        m_enmCurrentPostion = Positions.Original
    End Sub
#End Region

End Class
