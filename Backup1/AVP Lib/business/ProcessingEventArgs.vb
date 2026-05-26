Namespace Business
    Public Class ProcessingEventArgs
        Inherits EventArgs
#Region "Class Constants & Variables"
        Private m_intSlot As Integer
#End Region

#Region "Property"
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
#End Region
    End Class
End Namespace
