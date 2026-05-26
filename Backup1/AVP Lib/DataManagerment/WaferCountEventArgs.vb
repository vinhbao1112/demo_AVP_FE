Namespace DataManagerment
    Public Class WaferCountEventArgs
        Inherits EventArgs
#Region "Class Constants & Variables"
        Private m_intCount As Integer
        Private m_blnForCycleWafer As Boolean = False
#End Region

#Region "Property"
        ''' <author>
        '''    	<name>Ngo Cao Dinh</name>
        '''    	<date> 2008-12-12</date>
        ''' </author>
        ''' <summary>
        ''' Processing result
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Count() As Integer
            Get
                Return m_intCount
            End Get
            Set(ByVal value As Integer)
                m_intCount = value
            End Set
        End Property
#End Region
    End Class
End Namespace