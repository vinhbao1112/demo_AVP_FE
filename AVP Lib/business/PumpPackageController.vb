Imports AVPLib.Driver
Namespace Business
    Public Class PumpPackageController
        Inherits ControllerObject

        Protected m_strDisplayName As String
#Region "Public properties"
        ''' <summary>
        ''' Get Display Name for use in alarm, log, etc...
        ''' </summary>
        Public Overridable Property DisplayName() As String
            Get
                Return m_strDisplayName
            End Get
            Set(ByVal value As String)
                m_strDisplayName = value
            End Set
        End Property
#End Region

#Region "Public method"

        ''' <summary>
        ''' Check whether communication is ok
        ''' </summary>
        Public Overridable Function IsCommunicationOK() As Boolean
            'Not implement
            Return False
        End Function

        ''' <summary>
        ''' Check whether Cryo T1, T2 is in range or Turbo upto speed
        ''' </summary>
        Public Overridable Function IsPumpPackageOK(ByRef strErrorMsg As String) As Boolean
            'Not implement
            Return False
        End Function

        ''' <summary>
        ''' Check whether Cryo T1, T2 is Not in range or Turbo upto Not speed
        ''' </summary>
        Public Overridable Function IsPumpPackageOff() As Boolean
            'Not implement
            Return False
        End Function

        Public Overridable Function StartPumpPackage(ByVal bStart As Boolean) As Boolean
            'Not implement. For turbo only. Will not implement in Cryo.
            Return False
        End Function

#End Region
    End Class
End Namespace
