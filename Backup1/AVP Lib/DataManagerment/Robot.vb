Imports AVPLib.ConstEnum

Namespace DataManagerment
    Public Class Robot
        Inherits Equipment
#Region "Class Constants & Variables"
        ' Move this enum to the constEnum.vb file


        Private m_enmCurrentPosition As Positions
        Private m_blnIsCommunicating As Boolean
        Private m_strResponseMessage As String
        Private m_blnIsRetracted As Boolean
        Private m_enmCurrentRobotEXREStatus As RobotEXREStatus
        Private m_blnIsReallyRetracted As Boolean
        Private m_enmCurrentRobotArmStatus As RobotArmStatus
        ' Support Delta Pick
        ' ReqAlStn_R
        Private m_iReqAlStn_R As Integer = 0

        ' ReqAlStn_Traw
        Private m_iReqAlStn_Traw As Integer = 0

        ' ReqAlStn_Z
        Private m_iReqAlStn_Z As Integer = 0

        ' ReqLOWER
        Private m_iReqLOWER As Integer = 0

        ' ReqNSLOTS 
        Private m_iReqNSLOTS As Integer = 0

        ' ReqPITCH
        Private m_iReqPITCH As Integer = 0

        Private m_version As String
        Private m_firmwareRevision As String
        Private m_rAxis As Integer
        Private m_tAxis As Integer
        Private m_zAxis As Integer
        Private m_configValues As String
        Private m_robotConfigValues As New Dictionary(Of String, String)
        Private m_applicationNumber As String
#End Region

#Region "Properties"
        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set Stn_R of command RQ STN ... ALL
        ''' </summary>
        Public Property ReqAlStn_R() As Integer
            Get
                Return m_iReqAlStn_R
            End Get
            Set(ByVal value As Integer)
                m_iReqAlStn_R = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set Stn_T of command RQ STN ... ALL
        ''' </summary>
        Public Property ReqAlStn_Traw() As Integer
            Get
                Return m_iReqAlStn_Traw
            End Get
            Set(ByVal value As Integer)
                m_iReqAlStn_Traw = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set Stn_Z of command RQ STN ... ALL
        ''' </summary>
        Public Property ReqAlStn_Z() As Integer
            Get
                Return m_iReqAlStn_Z
            End Get
            Set(ByVal value As Integer)
                m_iReqAlStn_Z = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set LOWER of command RQ STN ... ALL
        ''' </summary>
        Public Property ReqLOWER() As Integer
            Get
                Return m_iReqLOWER
            End Get
            Set(ByVal value As Integer)
                m_iReqLOWER = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set NSLOTS of command RQ STN ... ALL
        ''' </summary>
        Public Property ReqNSLOTS() As Integer
            Get
                Return m_iReqNSLOTS
            End Get
            Set(ByVal value As Integer)
                m_iReqNSLOTS = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set PITCH of command RQ STN ... ALL
        ''' </summary>
        Public Property ReqPITCH() As Integer
            Get
                Return m_iReqPITCH
            End Get
            Set(ByVal value As Integer)
                m_iReqPITCH = value
            End Set
        End Property
        Private m_RevisionNoValues As String
        Public Property RevisionNoValues() As String
            Get
                Return m_RevisionNoValues
            End Get
            Set(ByVal value As String)
                m_RevisionNoValues = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates version of robot
        ''' </summary>
        Public Property Version() As String
            Get
                Return m_version
            End Get
            Set(ByVal value As String)
                m_version = value

                If m_robotConfigValues.ContainsKey("R_REV") Then
                    m_robotConfigValues("R_REV") = m_firmwareRevision & " - " & m_version
                Else
                    m_robotConfigValues.Add("R_REV", m_firmwareRevision & " - " & m_version)
                End If
                m_RevisionNoValues = m_firmwareRevision & " - " & m_version
            End Set
        End Property

        ''' <author>
        '''    	<name> Dung Pham </name>
        '''    	<date> 2018-11-26 </date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates firmware revision of robot
        ''' </summary>
        Public Property FirmwareRevision() As String
            Get
                Return m_firmwareRevision
            End Get
            Set(ByVal value As String)
                m_firmwareRevision = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-19 </date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates application number of robot
        ''' </summary>
        Public Property ApplicationNumber() As String
            Get
                Return m_applicationNumber
            End Get
            Set(ByVal value As String)
                m_applicationNumber = value

                If m_robotConfigValues.ContainsKey("APPLIC") Then
                    m_robotConfigValues("APPLIC") = m_applicationNumber
                Else
                    m_robotConfigValues.Add("APPLIC", m_applicationNumber)
                End If
            End Set
        End Property

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates R-axis of robot
        ''' </summary>
        Public Property R_Axis() As Integer
            Get
                Return m_rAxis
            End Get
            Set(ByVal value As Integer)
                m_rAxis = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates T-axis of robot
        ''' </summary>
        Public Property T_Axis() As Integer
            Get
                Return m_tAxis
            End Get
            Set(ByVal value As Integer)
                m_tAxis = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates Z-axis of robot
        ''' </summary>
        Public Property Z_Axis() As Integer
            Get
                Return m_zAxis
            End Get
            Set(ByVal value As Integer)
                m_zAxis = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates the set of configs.
        ''' </summary>
        Public Property ConfigValues() As String
            Get
                Return m_configValues
            End Get
            Set(ByVal value As String)
                m_configValues = value
                Me.UpdateConfig()
            End Set
        End Property

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates the set of configs.
        ''' </summary>
        Public Property RobotConfigValues() As Dictionary(Of String, String)
            Get
                Return m_robotConfigValues
            End Get
            Set(ByVal value As Dictionary(Of String, String))
                m_robotConfigValues = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        '''Get current position
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CurrentPosition() As Positions
            Get
                Return m_enmCurrentPosition
            End Get
            Set(ByVal value As Positions)
                m_enmCurrentPosition = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: RobotArmExtendRetractStatus
                If value.ToString.Contains("Extract") Then
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "RobotArmExtendRetractStatus", VALUELib.ValueType.U1, 1)
                Else
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "RobotArmExtendRetractStatus", VALUELib.ValueType.U1, 0)
                End If
                'CurrentArmPosition
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "CurrentArmPosition", VALUELib.ValueType.A, value.ToString())

            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        '''Get current position
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CurrentArmStatus() As RobotArmStatus
            Get
                Return m_enmCurrentRobotArmStatus
            End Get
            Set(ByVal value As RobotArmStatus)
                m_enmCurrentRobotArmStatus = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: RobotArmUpDownStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "RobotArmUpDownStatus", VALUELib.ValueType.U1, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current IsCommunicating
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsCommunicating() As Boolean
            Get
                Return m_blnIsCommunicating
            End Get
            Set(ByVal value As Boolean)
                m_blnIsCommunicating = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: CommunicationStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "CommunicationStatus", VALUELib.ValueType.U1, IIf(value, 1, 0))
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current m_strResponseMessage
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ResponseMessage() As String
            Get
                Return m_strResponseMessage
            End Get
            Set(ByVal value As String)
                m_strResponseMessage = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Dat Cao </name>
        '''    	<date> 2013-02-25</date>
        ''' </author>
        ''' <summary>
        ''' Current Robot arm Extern Retract status
        ''' </summary>
        ''' <value></value>
        Public Property ExternRetractStatus() As RobotEXREStatus
            Get
                Return m_enmCurrentRobotEXREStatus
            End Get
            Set(ByVal value As RobotEXREStatus)
                m_enmCurrentRobotEXREStatus = value
                If (m_enmCurrentRobotEXREStatus = RobotEXREStatus.RE) Then
                    m_blnIsRetracted = True
                Else
                    m_blnIsRetracted = False
                End If
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current IsRetracted
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsRetracted() As Boolean
            Get
                Return m_blnIsRetracted
            End Get
            Set(ByVal value As Boolean)
                m_blnIsRetracted = value
            End Set
        End Property
        Public Property IsReallyRetracted() As Boolean
            Get
                Return m_blnIsReallyRetracted
            End Get
            Set(ByVal value As Boolean)
                m_blnIsReallyRetracted = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2020-11-10 </date>
        ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates the set of robot configs.
        ''' </summary>
        Private m_RobotSystemSetup As New Dictionary(Of String, String)
        Public Property RobotSystemSetup() As Dictionary(Of String, String)
            Get
                Return m_RobotSystemSetup
            End Get
            Set(ByVal value As Dictionary(Of String, String))
                m_RobotSystemSetup = value
            End Set
        End Property
#End Region

#Region "properties robot config"
        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2020-05-25</date>
        ''' </author>
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Private m_HACCRobot As String
        Public Property HaveConfigHACC() As String
            Get
                Return m_HACCRobot
            End Get
            Set(ByVal value As String)
                m_HACCRobot = value
            End Set
        End Property

        Private m_RobotPACC As String
        Public Property HaveConfigPACC() As String
            Get
                Return m_RobotPACC
            End Get
            Set(ByVal value As String)
                m_RobotPACC = value
            End Set
        End Property

        Private m_WACCRobot As String
        Public Property HaveConfigWACC() As String
            Get
                Return m_WACCRobot
            End Get
            Set(ByVal value As String)
                m_WACCRobot = value
            End Set
        End Property

        Private m_HVELRobot As String
        Public Property HaveConfigHVEL() As String
            Get
                Return m_HVELRobot
            End Get
            Set(ByVal value As String)
                m_HVELRobot = value
            End Set
        End Property

        Private m_PVELRobot As String
        Public Property HaveConfigPVEL() As String
            Get
                Return m_PVELRobot
            End Get
            Set(ByVal value As String)
                m_PVELRobot = value
            End Set
        End Property

        Private m_WVELRobot As String
        Public Property HaveConfigWVEL() As String
            Get
                Return m_WVELRobot
            End Get
            Set(ByVal value As String)
                m_WVELRobot = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Tinh Le </name>
        '''    	<date> 2020-22-04</date>
        ''' </author>
        ''' <summary>
        ''' R_HACC
        ''' </summary>
        Private m_R_HACC As String
        Public Property R_HACC() As String
            Get
                Return m_R_HACC
            End Get
            Set(ByVal value As String)
                m_R_HACC = value
            End Set
        End Property
        ''T_HACC
        Private m_T_HACC As String
        Public Property T_HACC() As String
            Get
                Return m_T_HACC
            End Get
            Set(ByVal value As String)
                m_T_HACC = value
            End Set
        End Property
        ''Z_HACC
        Private m_Z_HACC As String
        Public Property Z_HACC() As String
            Get
                Return m_Z_HACC
            End Get
            Set(ByVal value As String)
                m_Z_HACC = value
            End Set
        End Property
        ''m_R_PACC
        Private m_R_PACC As String
        Public Property R_PACC() As String
            Get
                Return m_R_PACC
            End Get
            Set(ByVal value As String)
                m_R_PACC = value
            End Set
        End Property
        ''T_PACC
        Private m_T_PACC As String
        Public Property T_PACC() As String
            Get
                Return m_T_PACC
            End Get
            Set(ByVal value As String)
                m_T_PACC = value
            End Set
        End Property

        ''Z_PACC
        Private m_Z_PACC As String
        Public Property Z_PACC() As String
            Get
                Return m_Z_PACC
            End Get
            Set(ByVal value As String)
                m_Z_PACC = value
            End Set
        End Property

        ''m_R_WACC
        Private m_R_WACC As String
        Public Property R_WACC() As String
            Get
                Return m_R_WACC
            End Get
            Set(ByVal value As String)
                m_R_WACC = value
            End Set
        End Property

        ''m_T_WACC
        Private m_T_WACC As String
        Public Property T_WACC() As String
            Get
                Return m_T_WACC
            End Get
            Set(ByVal value As String)
                m_T_WACC = value
            End Set
        End Property

        ''Z_WACC
        Private m_Z_WACC As String
        Public Property Z_WACC() As String
            Get
                Return m_Z_WACC
            End Get
            Set(ByVal value As String)
                m_Z_WACC = value
            End Set
        End Property

        ''R_HVEL
        Private m_R_HVEL As String
        Public Property R_HVEL() As String
            Get
                Return m_R_HVEL
            End Get
            Set(ByVal value As String)
                m_R_HVEL = value
            End Set
        End Property

        ''m_T_HVEL
        Private m_T_HVEL As String
        Public Property T_HVEL() As String
            Get
                Return m_T_HVEL
            End Get
            Set(ByVal value As String)
                m_T_HVEL = value
            End Set
        End Property

        ''m_Z_HVEL
        Private m_Z_HVEL As String
        Public Property Z_HVEL() As String
            Get
                Return m_Z_HVEL
            End Get
            Set(ByVal value As String)
                m_Z_HVEL = value
            End Set
        End Property

        ''R_PVEL
        Private m_R_PVEL As String
        Public Property R_PVEL() As String
            Get
                Return m_R_PVEL
            End Get
            Set(ByVal value As String)
                m_R_PVEL = value
            End Set
        End Property

        ''m_T_PVEL
        Private m_T_PVEL As String
        Public Property T_PVEL() As String
            Get
                Return m_T_PVEL
            End Get
            Set(ByVal value As String)
                m_T_PVEL = value
            End Set
        End Property

        ''m_Z_PVEL
        Private m_Z_PVEL As String
        Public Property Z_PVEL() As String
            Get
                Return m_Z_PVEL
            End Get
            Set(ByVal value As String)
                m_Z_PVEL = value
            End Set
        End Property

        ''R_WVEL
        Private m_R_WVEL As String
        Public Property R_WVEL() As String
            Get
                Return m_R_WVEL
            End Get
            Set(ByVal value As String)
                m_R_WVEL = value
            End Set
        End Property

        ''m_T_WVEL
        Private m_T_WVEL As String
        Public Property T_WVEL() As String
            Get
                Return m_T_WVEL
            End Get
            Set(ByVal value As String)
                m_T_WVEL = value
            End Set
        End Property

        ''m_Z_WVEL
        Private m_Z_WVEL As String
        Public Property Z_WVEL() As String
            Get
                Return m_Z_WVEL
            End Get
            Set(ByVal value As String)
                m_Z_WVEL = value
            End Set
        End Property
#End Region

#Region "Public method"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Change status Robot
        ''' </summary>
        ''' <param name="PropertyNames"></param>
        ''' <param name="ReplyValues"></param>
        ''' <remarks></remarks>
        Public Overrides Sub ChangeStatus(ByVal PropertyNames As System.Collections.ArrayList, ByVal ReplyValues As System.Collections.ArrayList)
            AVPLib.Log.coreLogger.Info("Enter ChangeStatus")
            MyBase.ChangeStatus(PropertyNames, ReplyValues)
            AVPLib.Log.coreLogger.Info("Leave ChangeStatus")
        End Sub


        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date> 2011-08-10</date>
        ''' </author>
        ''' <summary>
        ''' Update Variables For Gem When Init
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overrides Sub UpdateVariableForGemWhenInit()
            Me.CurrentArmStatus = CurrentArmStatus
            Me.CurrentPosition = CurrentPosition
        End Sub

        ''' <author>
        '''    	<name> Hai Tran </name>
        '''    	<date> 2015-11-05 </date>
        ''' </author>
        ''' <summary>
        ''' Store config.
        ''' </summary>
        ''' <value></value>
        Private Sub UpdateConfig()
            Try
                If Not String.IsNullOrEmpty(m_configValues) Then
                    Dim arrValues As String() = m_configValues.Split(New Char() {";"c}, StringSplitOptions.RemoveEmptyEntries)
                    For index As Integer = 0 To arrValues.Length - 1
                        Dim values() As String = arrValues(index).Split(New Char() {"="c}, StringSplitOptions.RemoveEmptyEntries)
                        If values.Length = 2 Then
                            If Not m_robotConfigValues.ContainsKey(values(0)) Then
                                m_robotConfigValues.Add(values(0), values(1))
                            Else
                                Exit For
                            End If
                        End If
                    Next
                End If
                m_configValues = Nothing
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Sub

#End Region
    End Class
End Namespace

