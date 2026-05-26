Imports System.Reflection

Public Class PropertyObject
    Public Enum DataType
        Undefined = 0
        IOLib_Base_EquipmentStatus
        System_Single
        System_Double
        System_Boolean
        IOLib_Base_MatchMode
    End Enum

    Private m_strPropertyName As String = String.Empty
    Private m_obj As Object = Nothing
    Private m_prop As PropertyInfo = Nothing
    Private m_bIsOk As Boolean = False
    Private m_eDataType As DataType = DataType.Undefined
    Private m_RawValue As String = String.Empty

    Public ReadOnly Property PropDataType() As DataType
        Get
            Return m_eDataType
        End Get
    End Property

    Public ReadOnly Property IsOK() As Boolean
        Get
            Return m_bIsOk
        End Get
    End Property

    Public Property RawValue() As String
        Get
            Return m_RawValue
        End Get
        Set(ByVal value As String)
            m_RawValue = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Function Init(ByVal obj As DataManagerment.Equipment, ByVal name As String, ByVal ParamArray arrParams As Object()) As Boolean
        Dim prop As PropertyInfo = obj.GetType().GetProperty(name)


        If prop Is Nothing Then
            m_bIsOk = False
            Return False
        End If

        If Not prop.CanWrite Then
            m_bIsOk = False
            Return False
        End If

        m_strPropertyName = name
        m_prop = prop
        m_obj = obj
        m_bIsOk = True
        m_eDataType = GetDataType(m_prop.PropertyType.FullName)

        Return True
    End Function

    Public Sub SetValue(ByVal objValue As Object)
        Try

            If m_bIsOk Then
                'm_prop.SetValue(m_obj, objValue, Nothing)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Public Function GetValue() As Object
        Try
            If m_prop IsNot Nothing Then
                Return m_prop.GetValue(m_obj, Nothing)
            End If

        Catch ex As System.Exception
        End Try

        Return Nothing
    End Function

    Private Function GetDataType(ByVal strDataType As String) As DataType
        Dim eDataType As DataType = DataType.Undefined

        If strDataType = "IOLib.Base.EquipmentStatus" Then
            eDataType = DataType.IOLib_Base_EquipmentStatus
        ElseIf strDataType = "System.Single" Then
            eDataType = DataType.System_Single
        ElseIf strDataType = "System.Double" Then
            eDataType = DataType.System_Double
        ElseIf strDataType = "System.Boolean" Then
            eDataType = DataType.System_Boolean
        ElseIf strDataType = "IOLib.Base.MatchMode" Then
            eDataType = DataType.IOLib_Base_MatchMode
        Else
            eDataType = DataType.Undefined
        End If

        Return eDataType
    End Function
End Class

