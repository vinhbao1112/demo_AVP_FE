Namespace Business
    Public Class LinkTestThread
#Region "Class Constants & Variables"
        Private m_intT6timeout As Integer
#End Region

#Region "Properties"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current  T6timeout 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property T6timeout() As Integer
            Get
                Return m_intT6timeout
            End Get
            Set(ByVal value As Integer)
                m_intT6timeout = value
            End Set
        End Property

#End Region

#Region "Public method"
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
        ''' Send link test
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SendLinkTest()

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
        ''' Start LinkTestThread
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Start()

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
        ''' Stop LinkTestThread
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub [Stop]()

        End Sub
#End Region
    End Class
End Namespace

