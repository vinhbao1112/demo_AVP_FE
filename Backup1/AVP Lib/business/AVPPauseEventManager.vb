Namespace Business
    Public Class AVPPauseEventManager
#Region "Available and properties"
        Private m_lstProcessJob As List(Of AVPProcessJob)
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-10-28</date>
        ''' </author>
        ''' <summary>
        ''' get list process job
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ListProcessJob() As List(Of AVPProcessJob)
            Get
                Return m_lstProcessJob
            End Get
            Set(ByVal value As List(Of AVPProcessJob))
                m_lstProcessJob = value
            End Set
        End Property
#End Region
    End Class
End Namespace
