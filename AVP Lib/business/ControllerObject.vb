Imports AVPLib.Communication.TerminalDriver
Namespace Business
    Public Class ControllerObject
#Region "Class Constants & Variables"
        Protected m_strEquipmentName As String
        Private m_blActionCMDSent As Boolean = False
        Private m_blManualAction As Boolean = False
        Private m_iSampleTime As Int32 = 1 ' default interval : 1 second.
        Private m_iWaitTime As Int32 = 1  ' default recording time : 1 minute.
        Private m_strDescription As String = String.Empty
        Protected m_htbChildController As Hashtable
        Private m_blIsDoingReconnect As Boolean = False
#End Region

#Region "Property"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Getc current ChildControllerf
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ChildController() As Hashtable
            Get
                Return m_htbChildController
            End Get
            Set(ByVal value As Hashtable)
                m_htbChildController = value
            End Set
        End Property


        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current EquipmentName
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Property EquipmentName() As String
            Get
                Return m_strEquipmentName
            End Get
            Set(ByVal value As String)
                m_strEquipmentName = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date>June 25,2009</date>
        ''' </author>
        ''' <summary>
        ''' ActionCMDSent
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ActionCMDSent() As Boolean
            Get
                Return m_blActionCMDSent
            End Get
            Set(ByVal value As Boolean)
                m_blActionCMDSent = value
            End Set
        End Property

        Public Property IsManualAction() As Boolean
            Get
                Return m_blManualAction
            End Get
            Set(ByVal value As Boolean)
                m_blManualAction = value
            End Set
        End Property

        Public Overridable Property PDC_ROR_SampleTime() As Integer
            Get
                Return m_iSampleTime
            End Get
            Set(ByVal value As Integer)
                m_iSampleTime = value
            End Set
        End Property

        Public Overridable Property PDC_ROR_WaitTime() As Integer
            Get
                Return m_iWaitTime
            End Get
            Set(ByVal value As Integer)
                m_iWaitTime = value
            End Set
        End Property

        Public Overridable Property PDC_ROR_Description() As String
            Get
                Return m_strDescription
            End Get
            Set(ByVal value As String)
                m_strDescription = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Hoa Nguyen </name>
        '''    	<date>June 8,2015</date>
        ''' </author>
        ''' <summary>
        ''' IsDoingReConnect
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsDoingReConnect() As Boolean
            Get
                Return m_blIsDoingReconnect
            End Get
            Set(ByVal value As Boolean)
                m_blIsDoingReconnect = value
            End Set
        End Property
#End Region

#Region "Constructors & Dispose"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Contructorl
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            m_htbChildController = New Hashtable()
        End Sub

        Public Overridable Sub Dispose()
        End Sub
#End Region

#Region "Public methods"
        Public Overridable Sub RecoverPressure()
            ''not implement here
        End Sub
        Public Overridable Sub StopRecoverPressure()
            ''not implement here
        End Sub
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Do task ControllerObject
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <remarks></remarks>
        Public Overridable Sub DoTask(ByVal Message As String)

        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <Modifiers>
        ''' <Modifier>
        '''   	<Name></Name>
        '''   	<Date></Date>
        '''		<Description></Description>
        ''' </Modifier>
        '''</Modifiers>
        ''' <summary>
        ''' Do Serial Command RobotController
        ''' </summary>
        ''' <param name="Command"></param>
        ''' <remarks></remarks>
        Public Overridable Sub DoSerialCommand(ByVal Command As String)

        End Sub

        Public Overridable Sub RaiseFinishOnline(ByVal Check As Boolean)
            AVPLib.Log.coreLogger.Info("Enter RaiseFinishOnline")
            Try
                Dim ReplyValues As ArrayList = New ArrayList()
                If Check Then
                    ReplyValues.Add(DataManagerment.Equipment.ControlStatuses.ONLINE)
                Else
                    ReplyValues.Add(DataManagerment.Equipment.ControlStatuses.OFFLINE)
                End If

                Dim PropertyNames As ArrayList = New ArrayList()
                PropertyNames.Add("ControlStatus")

                AVPLib.DataManagerment.EquipmentManager.ChangeStatus(Me.EquipmentName, PropertyNames, ReplyValues)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.coreLogger.Info("Leave RaiseFinishOnline")
        End Sub

        Public Overridable Sub ReconnectHandle(ByVal obj As Object, ByVal e As ReconnectEventArgs)

        End Sub
#End Region
    End Class
End Namespace

