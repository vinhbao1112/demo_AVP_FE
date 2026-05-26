Namespace DataManagerment
    Public Class Aligner
        Inherits Equipment
#Region "Class Constants & Variables"
        Private m_intWaferID As Integer
        Private m_RecipeName As String
        Private m_blnIsCommunicating As Boolean
        Private m_strResponseMessage As String
        Private m_ipickStation As Integer
        Private m_iplaceStation As Integer

        'DeltaPick, 9. If ECC_Rraw > 1250, ECC_Rraw=1250.")
        ' This value is should be read from configuration file.
        Public Shared DeltaPickMaxEccentricity As Integer = 1250

        ' Support Delta Pick.
        ' RSLTAngularLocation
        Private m_iRSLTAngularLocation As Integer = 0
        Private m_fRSLTAngularLocationDeg As Single = 0.0F

        ' RSLTEccentricityAngle ( or name it as ECC_Traw, it's ok)
        Private m_iRSLTEccentricityAngle As Integer = 0
        Private m_fRSLTEccentricityAngleDeg As Single = 0.0F

        ' RSLTMaxEccentricity ( or name it as ECC_Rraw, it's ok)
        Private m_iRSLTMaxEccentricity As Integer = 0
        Private m_fRSLTMaxEccentricityMils As Single = 0.0F

        ' RSLTAvgCCD
        Private m_iRSLTAvgCCD As Integer = 0

        ' RSLTReScanNeed
        Private m_blnRSLTReScanNeed As Boolean = False

        ' RSLTTypeCode
        Private m_iRSLTTypeCode As Integer = 0
        ' Float RSLTTypeCodeDeg = RSLTTypeCode / 10f

        ' Wafer_Rstation
        Private m_dblWafer_Rstation As Double = 0

        ' Wafer_Tstation
        Private m_dblWafer_Tstation As Double = 0

        ' Self_Align Wafer_Rstation
        Private m_dblSelf_Align_Wafer_Rstation As Double = 0

        ' Self_Align Wafer_Tstation
        Private m_dblSelf_Align_Wafer_Tstation As Double = 0

        Private m_ProcessControl_GetRunDataFileName As WorkingStatuses = WorkingStatuses.Unknown
#End Region

#Region "Properties"

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set AngularLocation of command RSLT
        ''' </summary>
        Public Property RSLTAngularLocation() As Integer
            Get
                Return m_iRSLTAngularLocation
            End Get
            Set(ByVal value As Integer)

                If (value <> m_iRSLTAngularLocation) Then
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner, _
                                                              "AngularLocation of command RSLT: " & value)
                End If

                m_iRSLTAngularLocation = value
            End Set
        End Property
    ''' <author>
    '''    	<name> Tinh Le </name>
    '''    	<date> 2024-01-24</date>
    ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates the set of configs.
        ''' </summary>
        Private m_RevisionNoValues As String
        Public Property RevisionNoValues() As String
            Get
                Return m_RevisionNoValues
            End Get
            Set(ByVal value As String)
                m_RevisionNoValues = value
            End Set
        End Property
        Private m_version As String
        Public Property Version() As String
            Get
                Return m_version
            End Get
            Set(ByVal value As String)
                m_version = value

                m_RevisionNoValues = m_firmwareRevision & " - " & m_version
            End Set
        End Property

    ''' <author>
    '''    	<name> Tinh Le </name>
    '''    	<date> 2024-01-24</date>
    ''' </author>
        ''' <summary>
        ''' Gets or sets a value indicates firmware revision of aligner
        ''' </summary>

        Private m_firmwareRevision As String
        Public Property FirmwareRevision() As String
            Get
                Return m_firmwareRevision
            End Get
            Set(ByVal value As String)
                m_firmwareRevision = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set AngularLocation of command RSLT in Unit Degree
        ''' </summary>
        Public Property RSLTAngularLocationDeg() As Single
            Get
                Return m_fRSLTAngularLocationDeg
            End Get
            Set(ByVal value As Single)

                If (value <> m_iRSLTEccentricityAngle) Then
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner, _
                                                              "AngularLocation of command RSLT: " & value)
                End If

                m_fRSLTAngularLocationDeg = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Aligner.FiducialAngle
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "Aligner.FiducialAngle", VALUELib.ValueType.F4, value)

                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Aligner.EccentricityMagnitude
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "Aligner.EccentricityMagnitude", VALUELib.ValueType.F4, value)

            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set EccentricityAngle of command RSLT
        ''' </summary>
        Public Property RSLTEccentricityAngle() As Integer
            Get
                Return m_iRSLTEccentricityAngle
            End Get
            Set(ByVal value As Integer)

                If (value <> m_iRSLTEccentricityAngle) Then
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner, _
                                                              "EccentricityAngle of command RSLT: " & value)
                End If

                m_iRSLTEccentricityAngle = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Aligner.EccentricityAngle
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "Aligner.EccentricityAngle", VALUELib.ValueType.F4, value)

            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set EccentricityAngle of command RSLT in Unit Degree
        ''' </summary>
        Public Property RSLTEccentricityAngleDeg() As Single
            Get
                Return m_fRSLTEccentricityAngleDeg
            End Get
            Set(ByVal value As Single)

                If (value <> m_fRSLTEccentricityAngleDeg) Then
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner, _
                                                              "EccentricityAngle of command RSLT: " & value)
                End If
                m_fRSLTEccentricityAngleDeg = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set MaxEccentricity of command RSLT
        ''' </summary>
        Public Property RSLTMaxEccentricity() As Integer
            Get
                Return m_iRSLTMaxEccentricity
            End Get
            Set(ByVal value As Integer)
                If (value <> m_iRSLTMaxEccentricity) Then
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner, _
                                                              "MaxEccentricity of command RSLT: " & value)
                End If
                m_iRSLTMaxEccentricity = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set MaxEccentricity of command RSLT in Unit Mils
        ''' </summary>
        Public Property RSLTMaxEccentricityMils() As Single
            Get
                Return m_fRSLTMaxEccentricityMils
            End Get
            Set(ByVal value As Single)

                If (value <> m_fRSLTMaxEccentricityMils) Then
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner, _
                                                              "MaxEccentricity of command RSLT: " & value)
                End If

                m_fRSLTMaxEccentricityMils = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Aligner.EccentricityMagnitude
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "Aligner.EccentricityMagnitude", VALUELib.ValueType.F4, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set AvgCCD of command RSLT
        ''' </summary>
        Public Property RSLTAvgCCD() As Integer
            Get
                Return m_iRSLTAvgCCD
            End Get
            Set(ByVal value As Integer)
                If (value <> m_iRSLTAvgCCD) Then
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner, _
                                                              "AvgCCD of command RSLT: " & value)
                End If
                m_iRSLTAvgCCD = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set ReScanNeed of command RSLT
        ''' </summary>
        Public Property RSLTReScanNeed() As Boolean
            Get
                Return m_blnRSLTReScanNeed
            End Get
            Set(ByVal value As Boolean)
                If (value <> m_blnRSLTReScanNeed) Then
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner, _
                                                              "ReScanNeed of command RSLT: " & value)
                End If
                m_blnRSLTReScanNeed = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set TypeCode of command RSLT
        ''' </summary>
        Public Property RSLTTypeCode() As Integer
            Get
                Return m_iRSLTTypeCode
            End Get
            Set(ByVal value As Integer)
                If (value <> m_iRSLTTypeCode) Then
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner, _
                                                              "TypeCode of command RSLT: " & value)
                End If
                m_iRSLTTypeCode = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set TypeCode of command RSLT in Unit Deg
        ''' </summary>
        Public ReadOnly Property RSLTTypeCodeDeg() As Single
            Get
                Return RSLTTypeCode / 10
            End Get
        End Property

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2015-05-07 </date>
        ''' </author>
        ''' <summary>
        ''' Get and Set Self-Align Wafer_R of command RSLT
        ''' </summary>
        Public Property SelfAlign_Wafer_Rstation() As Double
            Get
                Return m_dblSelf_Align_Wafer_Rstation
            End Get
            Set(ByVal value As Double)
                Dim objRobot As DataManagerment.Robot = EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim arrPropertyNames As New ArrayList()
                Dim arrDecodedValues As New ArrayList()

                If (value <> m_dblSelf_Align_Wafer_Rstation) Then
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner, _
                                                              "Wafer_R of command RSLT: " & value)
                End If

                ' Delta R = (Station 8 R - Station 9 R)
                m_dblSelf_Align_Wafer_Rstation = (value - objRobot.ReqAlStn_R)

                arrPropertyNames.Add("Wafer_Rstation")
                arrDecodedValues.Add(String.Format("{0:0.0000}", m_dblSelf_Align_Wafer_Rstation))
                Me.RaisePropertyChangedEvents(arrPropertyNames, arrDecodedValues)

            End Set
        End Property

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2015-05-07 </date>
        ''' </author>
        ''' <summary>
        ''' Get and Set Self-Align Wafer_T of command RSLT
        ''' </summary>
        Public Property SelfAlign_Wafer_Tstation() As Double
            Get
                Return m_dblSelf_Align_Wafer_Tstation
            End Get
            Set(ByVal value As Double)
                Dim objRobot As DataManagerment.Robot = EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim arrPropertyNames As New ArrayList()
                Dim arrDecodedValues As New ArrayList()

                If (value <> m_dblSelf_Align_Wafer_Tstation) Then
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner, _
                                                              "Wafer_Traw of command RSLT: " & value)
                End If

                ' Delta R = (Station 8 R - Station 9 R)
                m_dblSelf_Align_Wafer_Tstation = (value - objRobot.ReqAlStn_Traw)

                arrPropertyNames.Add("Wafer_Tstation")
                arrDecodedValues.Add(String.Format("{0:0.0000}", m_dblSelf_Align_Wafer_Tstation))
                Me.RaisePropertyChangedEvents(arrPropertyNames, arrDecodedValues)

            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set Wafer_R of command RSLT
        ''' </summary>
        Public Property Wafer_Rstation() As Double
            Get
                Return m_dblWafer_Rstation
            End Get
            Set(ByVal value As Double)

                If (value <> m_dblWafer_Rstation) Then
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner, _
                                                              "Wafer_R of command RSLT: " & value)
                End If

                m_dblWafer_Rstation = value
                Dim objRobot As DataManagerment.Robot = EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim arrPropertyNames As New ArrayList()
                arrPropertyNames.Add("Wafer_Rstation")
                Dim arrDecodedValues As New ArrayList()
                ' Delta R = ABS(Station 9 R - Station 8 R)
                arrDecodedValues.Add(String.Format("{0:0.0000}", Math.Abs(objRobot.ReqAlStn_R - m_dblWafer_Rstation)))
                Me.RaisePropertyChangedEvents(arrPropertyNames, arrDecodedValues)
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Aligner.DeltaR
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "Aligner.DeltaR", VALUELib.ValueType.F4, value)

            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Tien Dat </name>
        '''    	<date> 2009-07-30</date>
        ''' </author>
        ''' <summary>
        ''' Get and Set Wafer_T of command RSLT
        ''' </summary>
        Public Property Wafer_Tstation() As Double
            Get
                Return m_dblWafer_Tstation
            End Get
            Set(ByVal value As Double)

                If (value <> m_dblWafer_Tstation) Then
                    AVPLib.ContainerData.LogAlarmEvent(AVPLib.ContainerData.TypeUser, AVPLib.ContainerData.LogSource.Aligner, _
                                                              "Wafer_T of command RSLT: " & value)
                End If

                m_dblWafer_Tstation = value
                Dim objRobot As DataManagerment.Robot = EquipmentManager.GetEquipment(ConstEnum.Equipments.Robot.ToString())
                Dim arrPropertyNames As New ArrayList()
                arrPropertyNames.Add("Wafer_Tstation")
                Dim arrDecodedValues As New ArrayList()
                ' Delta T = ABS(Station 9 T - Station 8 T)
                arrDecodedValues.Add(String.Format("{0:0.0000}", Math.Abs(objRobot.ReqAlStn_Traw - m_dblWafer_Tstation)))
                Me.RaisePropertyChangedEvents(arrPropertyNames, arrDecodedValues)
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Aligner.DeltaT
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "Aligner.DeltaT", VALUELib.ValueType.F4, value)
            End Set
        End Property

        Private m_waferAlignAngle As Single
        ''' <author>
        '''     <name>Hai Tran</name>
        '''     <date>2016-01-29</date>
        ''' </author>
        ''' <summary>
        ''' Wafer align angle in recipe.
        ''' </summary>
        Public Property WaferAlignAngle() As Single
            Get
                Return m_waferAlignAngle
            End Get
            Set(ByVal value As Single)
                m_waferAlignAngle = value

                Dim arrPropertyNames As New ArrayList()
                arrPropertyNames.Add("WaferAlignAngle")
                Dim arrDecodedValues As New ArrayList()
                arrDecodedValues.Add(String.Format("{0:0.0}", m_waferAlignAngle))
                Me.RaisePropertyChangedEvents(arrPropertyNames, arrDecodedValues)

            End Set
        End Property

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-01-22 </date>
        ''' </author>
        ''' <summary>
        ''' Calculate the station for the action pick from Aligner
        ''' 0001467: There is sation 9, Station ID might be wrong 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Sub initialize()
            m_iplaceStation = ConstEnum.DEFAULT_STATION_NO_FOR_ALIGNER
            m_ipickStation = m_iplaceStation
            DeltaPickMaxEccentricity = ContainerData.GetIntegerFromKeyValueInRobotConfig(ConstEnum.DELTA_PICK_MAX_ECCENTRICITY, 1250)
            ContainerData.GetAlignerStationLocation(m_iplaceStation, m_ipickStation)
        End Sub

        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-01-22</date>
        ''' </author>
        ''' <summary>
        ''' The pick station for aligner
        ''' 0001467: There is sation 9, Station ID might be wrong 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PickStation() As Integer
            Get
                Return m_ipickStation
            End Get
            Set(ByVal value As Integer)
                m_ipickStation = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current WaferID
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WaferID() As Integer
            Get
                Return m_intWaferID
            End Get
            Set(ByVal value As Integer)
                m_intWaferID = value
                ' @Khiet, please take a look the code below.
                Dim arrPropertyNames As New ArrayList()
                arrPropertyNames.Add("WaferID")
                Dim arrDecodedValues As New ArrayList()
                arrDecodedValues.Add(m_intWaferID)
                Me.RaisePropertyChangedEvents(arrPropertyNames, arrDecodedValues)
            End Set
        End Property

        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-07-27</date>
        ''' </author>
        ''' <summary>
        ''' Get current RecipeNameWaferInfo
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RecipeNameWaferInfo() As String
            Get
                Return m_RecipeName
            End Get
            Set(ByVal value As String)
                m_RecipeName = value
                ' @Khiet, please take a look the code below.
                Dim arrPropertyNames As New ArrayList()
                arrPropertyNames.Add("RecipeNameWaferInfo")
                Dim arrDecodedValues As New ArrayList()
                arrDecodedValues.Add(m_RecipeName)
                Me.RaisePropertyChangedEvents(arrPropertyNames, arrDecodedValues)
                ' Update SECS/GEM variables by Truc Le
                ' Var Name:Aligner.Recipe
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "Aligner.Recipe", VALUELib.ValueType.A, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current isCommunicating aligner
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
                ' Var Name: AlignerCommunicationStatus
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.TM_STR, EMSERVICELib.VarType.SV, "AlignerCommunicationStatus", VALUELib.ValueType.U1, IIf(value, 1, 0))
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current response message aligner
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
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-12-11 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Valve
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ProcessControl_GetRunDataFileName() As WorkingStatuses
            Get
                Return m_ProcessControl_GetRunDataFileName
            End Get
            Set(ByVal value As WorkingStatuses)
                m_ProcessControl_GetRunDataFileName = value
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
        ''' Change status Aligner
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
            Me.RecipeNameWaferInfo = RecipeNameWaferInfo
            Me.RSLTEccentricityAngle = RSLTEccentricityAngle
            Me.RSLTAngularLocationDeg = RSLTAngularLocationDeg
            Me.Wafer_Rstation = Wafer_Rstation
            Me.Wafer_Tstation = Wafer_Tstation
        End Sub
#End Region
    End Class
End Namespace

