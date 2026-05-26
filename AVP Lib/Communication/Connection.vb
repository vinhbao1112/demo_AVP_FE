Imports System.Net.Sockets
Namespace Communication

    Public Class Connection
#Region "Class Constants & Variables"
        Enum States
            [Disconnected] = 0
            [Connected] = 1
        End Enum
        Protected m_CurrentState As States = States.Disconnected
        Protected m_IPAddress As String
        Protected m_Port As Integer

        Protected Const CONNECT_TIME_OUT As Integer = 4000

#End Region

#Region "Constructors & Destructor"
#End Region

#Region "Properties"
        ''' <author>
        '''    	<name> Do Xuan Dat </name>
        '''    	<date> 2009-09-17</date>
        ''' </author>
        ''' <summary>
        ''' Get current connection status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function IsConnected(ByVal socket As Socket) As Boolean
            Try
                If States.Connected = m_CurrentState Then
                    Return Not (socket.Poll(1, SelectMode.SelectRead) And socket.Available = 0)
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function



        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Get current connection status
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property CurrentState() As States
            Get
                Return m_CurrentState
            End Get
        End Property

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-01</date>
        ''' </author>
        ''' <summary>
        ''' IP Address of a server to connect
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IPAddress() As String
            Get
                Return m_IPAddress
            End Get
            Set(ByVal value As String)
                m_IPAddress = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Cao Anh Kiet </name>
        '''    	<date> 2008-12-01</date>
        ''' </author>
        ''' <summary>
        ''' Port number of a server to connect
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Port() As Integer
            Get
                Return m_Port
            End Get
            Set(ByVal value As Integer)
                m_Port = value
            End Set
        End Property
#End Region

#Region "Public Method"
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
        ''' Send a message
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function SendMessage(ByVal Message As String) As Boolean
            Return True
        End Function
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
        ''' Send a message
        ''' </summary>
        ''' <param name="Message"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function SendBytes(ByVal msg As Byte()) As Boolean
            Return True
        End Function
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
        '''  Receive a message
        ''' </summary>
        ''' <param name="Timeout"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function ReceiveMessage(ByVal Timeout As Integer, ByVal Message As String) As String
            Return ""
        End Function

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
        '''  Receive a message
        ''' </summary>
        ''' <param name="Timeout"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function ReceiveBytes(ByVal Timeout As Integer) As Byte()
            Return Nothing
        End Function

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
        '''  Open a connection
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Function Open() As Boolean
            Return True
        End Function

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
        ''' Close a connection
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Function Close() As Boolean
            Return True
        End Function
#End Region

    End Class

End Namespace

