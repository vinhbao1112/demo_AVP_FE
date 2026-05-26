Namespace Business
    Public Class AVPObject
        Implements IDisposable

#Region "Avariables and Properties"
        Private m_bDisposed As Boolean

        Private m_strObjType As String = String.Empty
        Private m_strCurrentState As String = ConstEnum.STATE_MACHINE_NO_STATE
        Private m_strPreviousState As String = ConstEnum.STATE_MACHINE_NO_STATE
        Private m_avpCore As AVPLib.Business.AVPCore = Nothing
        Private m_strObjectID As String = String.Empty

        '0: Equipment object
        '1: Control job object
        '2: Process job onject
        Public Property ObjType() As String
            Get
                Return m_strObjType
            End Get
            Set(ByVal value As String)
                m_strObjType = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' Get current state of avpobject
        ''' </summary>
        ''' <remarks></remarks>
        Public Property CurrentState() As String
            Get
                Return m_strCurrentState
            End Get
            Set(ByVal value As String)
                m_strCurrentState = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' Get Object ID
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ObjectID() As String
            Get
                Return m_strObjectID
            End Get
            Set(ByVal value As String)
                m_strObjectID = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' Get previous state of avpobject
        ''' </summary>
        ''' <remarks></remarks>
        Public Property PreviousState() As String
            Get
                Return m_strPreviousState
            End Get
            Set(ByVal value As String)
                m_strPreviousState = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' Get avpcore
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly Property AVPCore() As AVPLib.Business.AVPCore
            Get
                Return AVPLib.Business.AVPCore.Instance()
            End Get
        End Property
#End Region
#Region "Public Method"

        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If (Not m_bDisposed AndAlso disposing) Then
                ' Dispose here.
            End If
            m_bDisposed = True
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class
End Namespace