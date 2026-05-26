Namespace DataManagerment
    Public Class ConfigItem
#Region "Class Constants & Variables"
        Private m_strName As String
        Private m_strValue As String
        Private m_intValue As Integer
#End Region
#Region "Properties"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current name configItem
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Name() As String
            Get
                Return m_strName
            End Get
            Set(ByVal value As String)
                m_strName = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current value configItem
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IntegerValue() As String
            Get
                Return m_strValue
            End Get
            Set(ByVal value As String)
                m_strValue = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current value configItem
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property StringValue() As Integer
            Get
                Return m_intValue
            End Get
            Set(ByVal value As Integer)
                m_intValue = value
            End Set
        End Property

#End Region
    End Class
End Namespace

