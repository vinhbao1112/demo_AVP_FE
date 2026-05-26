Namespace DataManagerment
    Public Class Cryo
        Inherits Equipment
#Region "Class Constants & Variables"
        Private m_blnIsCommunicating As Boolean
        Private m_blnCryoON As WorkingStatuses
        Private m_blnCryoRoughON As WorkingStatuses
        Private m_blnCryoPurgeON As WorkingStatuses
        Private m_blnCryoTCON As WorkingStatuses
        Private m_dblT1 As Double
        Private m_dblT2 As Double
        Private m_enmPumpStatus As WorkingStatuses
        Private m_enmRegenStatus As WorkingStatuses
        Private m_strRegenStatusText As String = String.Empty
        Private m_enmPullingStatus As WorkingStatuses
        Private m_strRegenLifeTime As String = String.Empty
        Private m_strRegenHour As String = String.Empty
        Private m_strPumpRestartDelay As String = String.Empty
        Private m_strExtendedPurgeTime As String = String.Empty
        Private m_strRepurgeCycles As String = String.Empty
        Private m_strRoughToPressure As String = String.Empty
        Private m_strRateOfRise As String = String.Empty
        Private m_strStartUpTemp As String = String.Empty
#End Region

#Region "Properties"
        ''' <remarks></remarks>
        Public Property CryoOn() As WorkingStatuses
            Get
                Return m_blnCryoON
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCryoON = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Cryo.OnOff
                Dim strLLName As String = Utils.GetModuleName4Gem(Me.Name)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLLName, EMSERVICELib.VarType.SV, "Cryo.OnOff", VALUELib.ValueType.U1, value)
            End Set
        End Property

        Public Property CryoRoughOn() As WorkingStatuses
            Get
                Return m_blnCryoRoughON
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCryoRoughON = value
            End Set
        End Property

        Public Property CryoPurgeOn() As WorkingStatuses
            Get
                Return m_blnCryoPurgeON
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCryoPurgeON = value
            End Set
        End Property

        Public Property CryoTCOn() As WorkingStatuses
            Get
                Return m_blnCryoTCON
            End Get
            Set(ByVal value As WorkingStatuses)
                m_blnCryoTCON = value
            End Set
        End Property

        Public Property PullingStatus() As WorkingStatuses
            Get
                Return m_enmPullingStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmPullingStatus = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current T1 LLCryo
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T1() As Double
            Get
                Return m_dblT1
            End Get
            Set(ByVal value As Double)
                m_dblT1 = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Cryo.FirstTemperature
                Dim strLLName As String = Utils.GetModuleName4Gem(Me.Name)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLLName, EMSERVICELib.VarType.SV, "Cryo.FirstTemperature", VALUELib.ValueType.F4, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current T2 LLCryo
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T2() As Double
            Get
                Return m_dblT2
            End Get
            Set(ByVal value As Double)
                m_dblT2 = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Cryo.SecondTemperature
                Dim strLLName As String = Utils.GetModuleName4Gem(Me.Name)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLLName, EMSERVICELib.VarType.SV, "Cryo.SecondTemperature", VALUELib.ValueType.F4, value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get current Pump Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PumpStatus() As WorkingStatuses
            Get
                Return m_enmPumpStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmPumpStatus = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get current Pump Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RegenHour() As String
            Get
                Return m_strRegenHour
            End Get
            Set(ByVal value As String)
                m_strRegenHour = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Cryo.RegenHours
                Dim strLLName As String = Utils.GetModuleName4Gem(Me.Name)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLLName, EMSERVICELib.VarType.SV, "Cryo.RegenHours", VALUELib.ValueType.F4, value)
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get current Pump Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RegenLifeTime() As String
            Get
                Return m_strRegenLifeTime
            End Get
            Set(ByVal value As String)
                m_strRegenLifeTime = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Cryo.LifeTimeHours
                Dim strLLName As String = Utils.GetModuleName4Gem(Me.Name)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLLName, EMSERVICELib.VarType.SV, "Cryo.LifeTimeHours", VALUELib.ValueType.F4, value)
            End Set
        End Property

        Public Property PumpRestartDelay() As String
            Get
                Return m_strPumpRestartDelay
            End Get
            Set(ByVal value As String)
                m_strPumpRestartDelay = value
            End Set
        End Property

        Public Property ExtendedPurgeTime() As String
            Get
                Return m_strExtendedPurgeTime
            End Get
            Set(ByVal value As String)
                m_strExtendedPurgeTime = value
            End Set
        End Property

        Public Property RepurgeCycles() As String
            Get
                Return m_strRepurgeCycles
            End Get
            Set(ByVal value As String)
                m_strRepurgeCycles = value
            End Set
        End Property

        Public Property RoughToPressure() As String
            Get
                Return m_strRoughToPressure
            End Get
            Set(ByVal value As String)
                m_strRoughToPressure = value
            End Set
        End Property

        Public Property RateOfRise() As String
            Get
                Return m_strRateOfRise
            End Get
            Set(ByVal value As String)
                m_strRateOfRise = value
            End Set
        End Property

        Public Property StartUpTemp() As String
            Get
                Return m_strStartUpTemp
            End Get
            Set(ByVal value As String)
                m_strStartUpTemp = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-13</date>
        ''' </author>
        ''' <summary>
        ''' Get current Regen Status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RegenStatus() As WorkingStatuses
            Get
                Return m_enmRegenStatus
            End Get
            Set(ByVal value As WorkingStatuses)
                m_enmRegenStatus = value
                ' Update SECS/GEM variables by Truc Le
                ' Var Name: Cryo.RegenOnOff
                Dim strLLName As String = Utils.GetModuleName4Gem(Me.Name)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLLName, EMSERVICELib.VarType.SV, "Cryo.RegenOnOff", _
                    VALUELib.ValueType.U1, Utils.ConvertWorkingStatusValueForUpdateGEM(value))
            End Set
        End Property

        Public Property RegenStatusText() As String
            Get
                Return m_strRegenStatusText
            End Get
            Set(ByVal value As String)
                m_strRegenStatusText = value
                RaiseRoughPumpInUseByCryo(value)
            End Set
        End Property

        ''' <author>
        '''    	<name> Huy Nguyen </name>
        '''    	<date> 2015-06-29 </date>
        ''' </author>
        ''' <summary>
        ''' Get or Set Rough Pump
        ''' </summary>
        ''' <remarks></remarks>
        Private m_blnRoughPumpIsUseByCryo As Boolean = False
        Public Property RoughPumpIsUseByCryo() As Boolean
            Get
                Return m_blnRoughPumpIsUseByCryo
            End Get
            Set(ByVal value As Boolean)
                m_blnRoughPumpIsUseByCryo = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-06-09</date>
        ''' </author>
        ''' <summary>
        ''' Get/Set Communication
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
                ' Var Name: Cryo.CommunicationStatus
                Dim strLLName As String = Utils.GetModuleName4Gem(Me.Name)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLLName, EMSERVICELib.VarType.SV, "Cryo.CommunicationStatus", VALUELib.ValueType.U1, IIf(value, 1, 0))
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
        ''' Change status LLCryo
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
        '''    	<name> Huy Nguyen </name>
        '''    	<date> 2015-06-26 </date>
        ''' </author>
        ''' <summary>
        ''' raise roughpump is used by cryo when regen in status ROUGH_TO_BASE
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Sub RaiseRoughPumpInUseByCryo(ByVal status As String)
            Dim strEquipmentName As String = Utils.GetEquipmentOfPumpPackage(Me.Name)

            If String.IsNullOrEmpty(strEquipmentName) Then
                Return
            End If

            Dim objRough As RoughPumpMachine = EquipmentManager.GetRoughPumpMachine(strEquipmentName)

            If (objRough IsNot Nothing) Then
                Select Case status
                    '''ROUGH_TO_BASE
                    Case "I", "J", "K", "T", "a", "b", "j", "n"
                        If Not m_blnRoughPumpIsUseByCryo Then
                            ''UPDATE PUMP IN USE
                            m_blnRoughPumpIsUseByCryo = True
                            objRough.SetRoughLineInUse(strEquipmentName, m_blnRoughPumpIsUseByCryo)
                        End If
                    Case Else
                        If m_blnRoughPumpIsUseByCryo Then
                            m_blnRoughPumpIsUseByCryo = False
                            objRough.ReleaseRoughLineInUse(strEquipmentName)
                        End If
                End Select
            End If
        End Sub
#End Region

    End Class
End Namespace

