Imports System.Collections
Imports AVP_Robot_Project.ConstantAndEnum
Public Class StatusObject

#Region "Class Constants & Variables"
    Protected Shared m_blnIsAlarm As Boolean = False

    Protected m_htbChildStatusObjects As New Hashtable()
	Protected m_Parent As StatusObject
    Private m_Name As String
    Protected m_marshaller As DelegateMarshaler
#End Region

#Region "Public shared Properties"
    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Is system alarm flashing ?
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property IsAlarm() As Boolean
        Get
            Return m_blnIsAlarm
        End Get
        Set(ByVal value As Boolean)
            m_blnIsAlarm = value
        End Set
    End Property
#End Region

#Region "Public Properties"
	''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
	''' </author>
	''' <summary>
	''' Get or set name
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Name() As String
		Get
			Name = m_Name
		End Get
		Set(ByVal value As String)
			m_Name = value
		End Set
	End Property
	''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
	''' </author>
	''' <summary>
    ''' Get parent status object
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Property Parent() As StatusObject
		Get
			Parent = m_Parent
		End Get
		Set(ByVal value As StatusObject)
			m_Parent = value
		End Set
	End Property

#End Region

#Region "Constructors & Dispose"
    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Initiate new status object
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        m_marshaller = DelegateMarshaler.Create()
    End Sub
    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' Initiate new status object with name
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Name As String)
        Me.New()
        m_Name = Name
    End Sub

#End Region

    Protected Overridable Sub UpdateUI(ByVal arg As Object)
        ' Do nothing
    End Sub

#Region "Public Methods"
    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure is to add a child status object to this object
    ''' </summary>
    ''' <param name="ChildStatusObject"></param>
    ''' <remarks></remarks>
    Public Sub AddChild(ByVal ChildStatusObject As StatusObject)
		Try
			If m_htbChildStatusObjects.Contains(ChildStatusObject.Name) = False Then
				m_htbChildStatusObjects.Add(ChildStatusObject.Name, ChildStatusObject)
				ChildStatusObject.Parent = Me
			End If
		Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

    Public Sub RemoveChild(ByVal ChildStatusObjectName As String)
        Try
            If m_htbChildStatusObjects.Contains(ChildStatusObjectName) Then
                m_htbChildStatusObjects.Remove(ChildStatusObjectName)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
    End Sub

''' <author>
    '''     <name> Le Hieu Truc </name>
    '''     <date> 2009-03-19</date>
    ''' </author>
    ''' <summary>
    ''' This procedure will be got main context menu strip for each context menu item
    ''' </summary>
    ''' <param name="ChildName"></param>
       ''' <remarks></remarks>
    Public Function GetChild(ByVal ChildName As String) As StatusObject
        Try
            If m_htbChildStatusObjects.Contains(ChildName) Then
                Return m_htbChildStatusObjects.Item(ChildName)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure will be overrided to change satus of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overridable Sub ChangeStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter ChangeStatus")
        AVPLib.Log.guiLogger.Debug("Identification=" + Identification)
        Try
            If m_htbChildStatusObjects.Count Then
                Dim soChildStatusObject As StatusObject
                Dim sKey As String = Identification.Substring(0, Identification.IndexOf("."))
                soChildStatusObject = CType(m_htbChildStatusObjects.Item(sKey), StatusObject)
                If soChildStatusObject IsNot Nothing Then
                    Dim sChildIdentification As String = Identification.Substring(Identification.IndexOf(".") + 1, Identification.Length - sKey.Length - 1)
                    soChildStatusObject.ChangeStatus(sChildIdentification, Value)
                Else
                    AVPLib.Log.avpLogger.Warn(Identification + " Message is invalid")
                End If
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave ChangeStatus")
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-21</date>
    ''' </author>
    ''' <summary>
    ''' This procedure will be overrided to request status of an object
    ''' </summary>
    ''' <param name="Identification"></param>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Public Overridable Sub RequestStatus(ByVal Identification As String, ByVal Value As String)
        AVPLib.Log.guiLogger.Info("Enter RequestStatus")

        Try
            If ((m_Parent IsNot Nothing)) Then
                Dim sTemp = Me.Name + "." + Identification
                If Me.Name.Contains(AVPLib.ConstEnum.PVD) Then
                    sTemp = Me.Name.Replace(AVPLib.ConstEnum.PVD, "") + "." + Identification
                End If
                m_Parent.RequestStatus(sTemp, Value)
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        AVPLib.Log.guiLogger.Info("Leave RequestStatus")
    End Sub

    ''' <author>
    '''     <name> Ngo Cao Dinh </name>
    '''     <date> 2008-08-22</date>
    ''' </author>
    ''' <summary>
    ''' This function return the Identification or the path name of hierachy
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetIdentification() As String
        Dim sResult As String = ""
        Try
            If (m_Parent IsNot Nothing) Then
                sResult = Parent.Name + "." + Name
            Else
                sResult = Parent.Name
            End If
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try

        Return sResult
    End Function
#End Region
End Class
