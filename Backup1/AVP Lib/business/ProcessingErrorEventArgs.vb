Namespace Business
    Public Class ProcessingErrorEventArgs
        Inherits EventArgs
#Region "Class Constants & Variables"
        Private m_strMessage As String
        Private m_intSlot As Integer
        Private m_blnPause As Boolean
#End Region

#Region "Property"
        ''' <author>
        '''    	<name>Cao Anh Kiet</name>
        '''    	<date> 2008-11-12</date>
        ''' </author>
        ''' <summary>
        ''' Get current message
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Message()
            Get
                Return m_strMessage
            End Get
            Set(ByVal value)
                Me.m_strMessage = value
            End Set
        End Property
        ''' <author>
        '''    	<name>Cao Anh Kiet</name>
        '''    	<date> 2008-12-17</date>
        ''' </author>
        ''' <summary>
        ''' Processing Slot
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Slot() As Integer
            Get
                Return m_intSlot
            End Get
            Set(ByVal value As Integer)
                m_intSlot = value
            End Set
        End Property
        ''' <author>
        '''    	<name>Cao Anh Kiet</name>
        '''    	<date> 2009-01-07</date>
        ''' </author>
        ''' <summary>
        ''' Processing Pause
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Pause() As Boolean
            Get
                Return m_blnPause
            End Get
            Set(ByVal value As Boolean)
                m_blnPause = value
            End Set
        End Property
#End Region
    End Class
End Namespace
