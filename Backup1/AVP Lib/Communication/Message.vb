Imports System.Threading
Imports System.Environment
Imports AVPLib.DataManagerment
Imports AVPLib.ConstEnum
Namespace Communication
    Public Class Message
        Private m_Time As Int64
        Private m_strText As String
        Private m_bytes() As Byte
#Region "Properties"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get or set time
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Time() As Int64
            Get
                Return m_Time
            End Get
            Set(ByVal value As Int64)
                m_Time = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get or set message text
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Text() As String
            Get
                Return m_strText
            End Get
            Set(ByVal value As String)
                m_strText = value
            End Set
        End Property

        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Get or set message text
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Bytes() As Byte()
            Get
                Return m_bytes
            End Get
            Set(ByVal value As Byte())
                m_bytes = value
            End Set
        End Property
#End Region

#Region "Constructor and destructor"
        ''' <author>
        '''    	<name> Ngo Cao Dinh </name>
        '''    	<date> 2008-12-03</date>
        ''' </author>
        ''' <summary>
        ''' Initialize message
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            m_Time = Environment.TickCount
            m_strText = ""
        End Sub
#End Region
    End Class
End Namespace