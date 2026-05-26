Namespace Communication.TerminalDriver
    Public Class TSDecoder
#Region "Public method"
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
        ''' Decode TSDecoder
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Function Decode(ByVal MessageValue As String) As ArrayList
            Return Nothing
        End Function

        Protected m_strEquipmentName As String = String.Empty
        Public Overridable Property EquipmentName() As String
            Get
                Return m_strEquipmentName
            End Get
            Set(ByVal value As String)
                m_strEquipmentName = value
            End Set
        End Property
#End Region
    End Class
End Namespace

