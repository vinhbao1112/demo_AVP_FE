Namespace Communication.TerminalDriver
    Public Class Transaction
#Region "Class Constants & Variables"
        Public Event ReconnectStatus As EventHandler(Of ReconnectEventArgs)
        Private m_intT3timeout As Integer
        'transaction time out count
        'reset when transaction send/receive success
        Private m_TransactionTimeoutCount As Int32 = 0

        'transaction timeout count > limit -> show alarm 
        Protected m_TransactionTimeoutLimit As Int32 = 5
#End Region

#Region "Properties"
        Public Property TransactionTimeoutCount() As Int32
            Get
                Return m_TransactionTimeoutCount
            End Get
            Set(ByVal value As Int32)
                m_TransactionTimeoutCount = value
            End Set
        End Property

        Public Function isOverTransactionTimeoutLimit() As Boolean
            Return (TransactionTimeoutCount >= m_TransactionTimeoutLimit)
        End Function
    
        Public Overridable Sub CalculateTransactionTimeOut()
            'If (m_TransactionTimeoutCount > m_TransactionTimeoutLimit) Then
            '    ResetTransactionTimeoutCount()
            'Else
            m_TransactionTimeoutCount += 1
            'End If
        End Sub

        Public Sub ResetTransactionTimeoutCount()
            TransactionTimeoutCount = 0
        End Sub

        ''' <author>
        '''    	<name> Tin Pham </name>
        '''    	<date> 2015-02-13</date>
        ''' </author>
        Public Sub InitializeWhenReconnected()
            TransactionTimeoutCount = m_TransactionTimeoutLimit + 1
        End Sub

        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-01</date>
        ''' </author>
        ''' <summary>
        ''' Get current T3timeout
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Timeout() As Integer
            Get
                Return m_intT3timeout
            End Get
            Set(ByVal value As Integer)
                m_intT3timeout = value
            End Set
        End Property

        Public Property TransactionTimeoutLimitProperty() As Int32
            Get
                Return m_TransactionTimeoutLimit
            End Get
            Set(ByVal value As Int32)
                m_TransactionTimeoutLimit = value
            End Set
        End Property
#End Region
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
        ''' Run Transaction
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Function Run(ByVal Message As String, ByVal bOverrideTimeOut As Boolean, ByVal newTimeOut As Integer) As Boolean
            Return True
        End Function

        Public Overridable Sub RaiseReconnectStatusEvent(ByVal e As ReconnectEventArgs)
            RaiseEvent ReconnectStatus(Me, e)
        End Sub
#End Region
    End Class

    Public Class ReconnectEventArgs
        Inherits EventArgs
        Private m_strEquipName As String

        Public Sub New(ByVal sEquipName As String)
            m_strEquipName = sEquipName
        End Sub

        Public Property EquipName() As String
            Get
                Return m_strEquipName
            End Get
            Set(ByVal value As String)
                m_strEquipName = value
            End Set
        End Property
    End Class
End Namespace

