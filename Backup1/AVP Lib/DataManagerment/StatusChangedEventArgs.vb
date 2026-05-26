Namespace DataManagerment
    Public Class StatusChangedEventArgs
        Inherits EventArgs
#Region "Class Constants & Variables"
        Private m_strMessage As String
        Private m_strChamberName As String = String.Empty
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
        Public Property ChamberName()
            Get
                Return m_strChamberName
            End Get
            Set(ByVal value)
                Me.m_strChamberName = value
            End Set
        End Property

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
#End Region
       
    End Class
End Namespace

