Imports System.Collections.Generic

Namespace DataManagerment
    Public Class Turbo
        Inherits Equipment
#Region "Variable and Property"
        ' Turbo status
        Private m_bTurboStatus As Boolean = False
        ' Is Turbo Up To Speed
        Private m_blIsTurboUpToSpeed As Boolean = False
        Private m_blnIsCommunicating As Boolean = False
        ' Is Turbo Error
        Private m_blIsError As Boolean = False
        ' Turbo Ramping Percentage
        Private m_fRampingPercent As Single = 0

        'Turbo Pump status
        Public Property TurboStatus() As Boolean
            Get
                Return m_bTurboStatus
            End Get
            Set(ByVal value As Boolean)

                If (m_bTurboStatus <> value) Then
                    ' Update SECS/GEM variables by Dat Cao
                    ' Var Name: Turbo.OnOff
                    Dim strLLName As String = Utils.GetModuleName4Gem(Me.Name)
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLLName, EMSERVICELib.VarType.SV, "Turbo.OnOff", VALUELib.ValueType.U1, IIf(value, 1, 0))
                End If

                m_bTurboStatus = value
            End Set
        End Property

        ' Up To Speed Relay
        Public Property TurboUptoSpeed() As Boolean
            Get
                Return m_blIsTurboUpToSpeed
            End Get
            Set(ByVal value As [Boolean])

                If (m_blIsTurboUpToSpeed <> value) Then
                    ' Update SECS/GEM variables by Dat Cao
                    ' Var Name: Turbo.CommunicationStatus
                    Dim strLLName As String = Utils.GetModuleName4Gem(Me.Name)
                    Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLLName, EMSERVICELib.VarType.SV, "Turbo.IsUpToSpeed", VALUELib.ValueType.Bo, value)
                End If

                m_blIsTurboUpToSpeed = value
            End Set
        End Property

        ' Is Turbo Error
        Public Property TurboError() As Boolean
            Get
                Return m_blIsError
            End Get
            Set(ByVal value As [Boolean])
                m_blIsError = value
            End Set
        End Property

        ' Is Turbo Commnicating
        Public Property IsTurboCommunicating() As Boolean
            Get
                Return m_blnIsCommunicating
            End Get
            Set(ByVal value As Boolean)
                m_blnIsCommunicating = value
                ' Update SECS/GEM variables by Dat Cao
                ' Var Name: Turbo.CommunicationStatus
                Dim strLLName As String = Utils.GetModuleName4Gem(Me.Name)
                Business.AVPSecsGemLib.UpdateSECSGEM_Variable(strLLName, EMSERVICELib.VarType.SV, "Turbo.CommunicationStatus", VALUELib.ValueType.U1, IIf(value, 1, 0))
            End Set
        End Property

        ' Turbo Ramping Percentage, used in serial turbo 
        Public Property RampingPercent() As Single
            Get
                Return m_fRampingPercent
            End Get
            Set(ByVal value As Single)
                m_fRampingPercent = value
            End Set
        End Property

#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
           MyBase.Dispose(disposing)
        End Sub

        Public Overrides Sub UpdateVariableForGemWhenInit()
            Me.TurboStatus = TurboStatus
            Me.TurboUptoSpeed = TurboUptoSpeed
            Me.IsTurboCommunicating = IsTurboCommunicating
        End Sub
    End Class
End Namespace
