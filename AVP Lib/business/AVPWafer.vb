Public Class AVPWaferInfo
    Private m_strwaferID As String = String.Empty
    Private m_iSlotID As Integer = 0
    Private m_enmWaferStatus As ConstEnum.enumWaferStatus = ConstEnum.enumWaferStatus.eWaferNone
    Private m_markForReturnEquipment As DataManagerment.Equipment = Nothing
    Private m_strWaferProcess As String = String.Empty
    Private m_enmWaferProcessing As ConstEnum.WaferProcessingState = ConstEnum.WaferProcessingState.NOT_IN_PROCESSING_SUB_STATE
    Private m_enmSL_WaferProcessing As ConstEnum.SL_WaferProcessingState = ConstEnum.SL_WaferProcessingState.NOT_IN_PROCESSING_SUB_STATE
    Private m_fWaferProcessTime As Double = 0
    Private m_fPreWaferProcessTime As Double = 0
    Private m_IsCountingWaferProcessTime As Boolean = True

    Public Sub New(ByVal strwaferID As String, ByVal iSlotID As Integer, ByVal enmWaferStatus As ConstEnum.enumWaferStatus)
        m_strwaferID = strwaferID
        m_iSlotID = iSlotID
        m_enmWaferStatus = enmWaferStatus
        m_markForReturnEquipment = Nothing
        UpdateWaferStatus_Variables(m_enmWaferStatus, ConstEnum.enumWaferStatus.eWaferNone)
    End Sub

    Public Sub New(ByVal strwaferID As String, ByVal enmWaferStatus As ConstEnum.enumWaferStatus)
        m_strwaferID = strwaferID
        m_enmWaferStatus = enmWaferStatus
        m_markForReturnEquipment = Nothing
        UpdateWaferStatus_Variables(m_enmWaferStatus, ConstEnum.enumWaferStatus.eWaferNone)
    End Sub
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-12-01 </date>
    ''' </author>
    ''' <summary>
    ''' Copy constructor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal objWaferInfo As AVPWaferInfo)
        m_strwaferID = objWaferInfo.WaferID
        m_enmWaferStatus = objWaferInfo.WaferStatus
        m_markForReturnEquipment = objWaferInfo.MarkForReturnEquipment
        m_iSlotID = objWaferInfo.SlotID
        m_strWaferProcess = objWaferInfo.m_strWaferProcess
        m_enmWaferProcessing = objWaferInfo.WaferProcessingStatus
        m_enmSL_WaferProcessing = objWaferInfo.SL_WaferProcessingStatus
    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-11-12</date>
    ''' </author>
    ''' <summary>
    ''' Mark For Return
    ''' </summary>
    ''' <remarks></remarks>
    Public Property MarkForReturnEquipment() As DataManagerment.Equipment
        Get
            Return m_markForReturnEquipment
        End Get
        Set(ByVal value As DataManagerment.Equipment)
            m_markForReturnEquipment = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set List of State Machine
    ''' </summary>
    ''' <remarks></remarks>
    Public Property WaferID() As String
        Get
            Return m_strwaferID
        End Get
        Set(ByVal value As String)
            m_strwaferID = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set List of State Machine
    ''' </summary>
    ''' <remarks></remarks>
    Public Property WaferStatus() As ConstEnum.enumWaferStatus
        Get
            Return m_enmWaferStatus
        End Get
        Set(ByVal value As ConstEnum.enumWaferStatus)
            If Not m_enmWaferStatus = value Then
                UpdateWaferStatus_Variables(value, m_enmWaferStatus)

                m_enmWaferStatus = value
            End If
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get Current Wafer Processing State: 
    ''' </summary>
    ''' <remarks></remarks>
    Public Property WaferProcessingStatus() As ConstEnum.WaferProcessingState
        Get
            Return m_enmWaferProcessing
        End Get
        Set(ByVal value As ConstEnum.WaferProcessingState)
            If m_enmWaferProcessing <> value Then
                UpdateProcessingState(value, m_enmWaferProcessing)
                m_enmWaferProcessing = value
            End If
        End Set
    End Property

    ''' <author>
    '''    	<name> Hoa Nguyen </name>
    '''    	<date> 2011-07-16 </date>
    ''' </author>
    ''' <summary>
    ''' Get Current SL Wafer Processing State: 
    ''' </summary>
    ''' <remarks></remarks>
    Public Property SL_WaferProcessingStatus() As ConstEnum.SL_WaferProcessingState
        Get
            Return m_enmSL_WaferProcessing
        End Get
        Set(ByVal value As ConstEnum.SL_WaferProcessingState)
            If m_enmSL_WaferProcessing <> value Then
                'UpdateSL_ProcessingState(value, m_enmSL_WaferProcessing)
                m_enmSL_WaferProcessing = value
            End If
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set List of State Machine
    ''' </summary>
    ''' <remarks></remarks>
    Public Property SlotID() As Integer
        Get
            Return m_iSlotID
        End Get
        Set(ByVal value As Integer)
            m_iSlotID = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-10-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Wafer Process Schedule
    ''' </summary>
    ''' <remarks></remarks>
    Public Property WaferProcessInfo() As String
        Get
            Return m_strWaferProcess
        End Get
        Set(ByVal value As String)
            m_strWaferProcess = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2013-11-28 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Wafer Process Time
    ''' </summary>
    ''' <remarks></remarks>
    Public Property WaferProcessTime() As Double
        Get
            Return m_fWaferProcessTime
        End Get
        Set(ByVal value As Double)
            m_fWaferProcessTime = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-08-07 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Pre Wafer Process Time
    ''' </summary>
    ''' <remarks></remarks>
    Public Property PreWaferProcessTime() As Double
        Get
            Return m_fPreWaferProcessTime
        End Get
        Set(ByVal value As Double)
            m_fPreWaferProcessTime = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-08-08 </date>
    ''' </author>
    ''' <summary>
    ''' Get or Set Reset Wafer Process Time
    ''' </summary>
    ''' <remarks></remarks>
    Public Property IsCountingWaferProcessTime() As Boolean
        Get
            Return m_IsCountingWaferProcessTime
        End Get
        Set(ByVal value As Boolean)
            m_IsCountingWaferProcessTime = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-08-12 </date>
    ''' </author>
    ''' <summary>
    ''' BeginCountingWaferProcessTime
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub BeginCountingWaferProcessTime()
        Try
            m_IsCountingWaferProcessTime = True
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2014-08-12 </date>
    ''' </author>
    ''' <summary>
    ''' EndCountingWaferProcessTime
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EndCountingWaferProcessTime()
        Try
            m_IsCountingWaferProcessTime = False
            m_fPreWaferProcessTime = m_fWaferProcessTime
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Sub UpdateProcessingState(ByVal CurrentState As ConstEnum.WaferProcessingState, ByVal PreviousState As ConstEnum.WaferProcessingState)
        Try
            Dim strVarName As String = "MaterialProcessingState"
            Dim strPreVarName As String = "PreviousMaterialProcessingState"
            Dim strEventName As String = "MaterialProcessingStateChanged"
            Dim strLL As String = String.Empty
            strLL = GetLLNameByWaferID(strVarName, strPreVarName, strEventName)
            If (strLL <> String.Empty) Then
                AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLL, EMSERVICELib.VarType.SV, strVarName, VALUELib.ValueType.U1, CurrentState)
                AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLL, EMSERVICELib.VarType.SV, strPreVarName, VALUELib.ValueType.U1, PreviousState)

                Business.AVPSecsGemLib.TriggerEvent(strLL, strEventName)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    'Private Sub UpdateSL_ProcessingState(ByVal CurrentState As ConstEnum.SL_WaferProcessingState, ByVal PreviousState As ConstEnum.SL_WaferProcessingState)
    '    Try
    '        Dim strVarName As String = "MaterialProcessingState01"
    '        Dim strPreVarName As String = "PreviousMaterialProcessingState01"
    '        Dim strEventName As String = "MaterialProcessingStateChanged01"

    '        AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.LOADER_STR, EMSERVICELib.VarType.SV, strVarName, VALUELib.ValueType.U1, CurrentState)
    '        AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(ConstEnum.LOADER_STR, EMSERVICELib.VarType.SV, strPreVarName, VALUELib.ValueType.U1, PreviousState)

    '        Business.AVPSecsGemLib.TriggerEvent(ConstEnum.LOADER_STR, strEventName)

    '    Catch ex As Exception
    '        AVPLib.Log.avpLogger.Error(ex.ToString())
    '    End Try
    'End Sub


    Private Sub UpdateWaferStatus_Variables(ByVal currentWaferStatus As ConstEnum.enumWaferStatus, ByVal previousWaferStatus As ConstEnum.enumWaferStatus)
        ' Update SECS/GEM variables by Truc Le
        ' Var Name: MaterialStatusState1->25
        Try
            Dim strVarName As String = "MaterialStatusState"
            Dim strPreVarName As String = "PreviousMaterialStatusState"
            Dim strLL As String = String.Empty '
            Dim strEventName As String = "MaterialStatusStateChanged"
            ''

            strLL = GetLLNameByWaferID(strVarName, strPreVarName, strEventName)

            If WaferID = String.Empty Then
                AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLL, EMSERVICELib.VarType.SV, _
                strVarName, VALUELib.ValueType.U1, 0)
                AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLL, EMSERVICELib.VarType.SV, _
                strPreVarName, VALUELib.ValueType.U1, 0)
            Else
                AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLL, EMSERVICELib.VarType.SV, _
                strVarName, VALUELib.ValueType.U1, currentWaferStatus)
                Business.AVPSecsGemLib.TriggerEvent(strLL, strEventName)

                AVPLib.Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLL, EMSERVICELib.VarType.SV, _
                strPreVarName, VALUELib.ValueType.U1, previousWaferStatus)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Private Function GetLLNameByWaferID(ByRef VarName As String, ByRef PreVarName As String, ByRef EventName As String) As String
        Dim iSlot As Integer = 0
        Dim strLL As String = String.Empty
        If Me.WaferID.Contains("A") Then
            Integer.TryParse(WaferID.Replace("A", ""), iSlot)
            strLL = ConstEnum.LoadLockA_STR
        End If
        VarName &= iSlot.ToString()
        PreVarName &= iSlot.ToString()
        EventName &= iSlot.ToString()
        Return strLL
    End Function

    'Private Function GetParamsForUpdateWaferStatusSLInGem(ByRef VarName As String, ByRef PreVarName As String, ByRef EventName As String) As String
    '    VarName &= "01"
    '    PreVarName &= "01"
    '    EventName &= "01"
    '    Return ConstEnum.LOADER_STR
    'End Function
End Class
