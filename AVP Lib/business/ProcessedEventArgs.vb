Namespace Business
    Public Class ProcessedEventArgs
        Inherits EventArgs
#Region "Class Constants & Variables"
        Private m_waferInfo As AVPWaferInfo
        Private m_blResult As Boolean
        Private m_strErrorMessage As String
        Private m_strLoadlockName As String
        Private m_blAutoTransfer As Boolean
        Private m_blReturnFreeJob As Boolean
        Private m_blIsSelfAligner As Boolean = False
        Private m_blReturnForProcessCJ As Boolean
#End Region

#Region "Property"

        Public Sub New(ByVal blProcessingResult As Boolean, _
        ByVal waferInfo As AVPWaferInfo, _
        ByVal blAutoTransfer As Boolean, _
        ByVal blReturnFreeJob As Boolean, _
        ByVal blIsSelfAligner As Boolean, _
        ByVal blReturnForProcessCJ As Boolean)
            m_waferInfo = waferInfo
            m_blResult = blProcessingResult
            m_strErrorMessage = String.Empty
            m_strLoadlockName = String.Empty
            m_blAutoTransfer = blAutoTransfer
            m_blReturnFreeJob = blReturnFreeJob
            m_blIsSelfAligner = blIsSelfAligner
            m_blReturnForProcessCJ = blReturnForProcessCJ
        End Sub

        ''' <author>
        '''    	<name>Tin Pham</name>
        '''    	<date> 2015-05-08 </date>
        ''' </author>
        ''' <summary>
        ''' IsSelfAligner
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsSelfAligner() As Boolean
            Get
                Return m_blIsSelfAligner
            End Get
            Set(ByVal value As Boolean)
                m_blIsSelfAligner = value
            End Set
        End Property
        ''' <author>
        '''    	<name>Do Xuan Dat</name>
        '''    	<date> 2009-11-09</date>
        ''' </author>
        ''' <summary>
        ''' Processing Slot
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsReturnFreeJob() As Boolean
            Get
                Return m_blReturnFreeJob
            End Get
            Set(ByVal value As Boolean)
                m_blReturnFreeJob = value
            End Set
        End Property
        ''' <author>
        '''    	<name>Do Xuan Dat</name>
        '''    	<date> 2009-11-09</date>
        ''' </author>
        ''' <summary>
        ''' Processing Slot
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property IsAutoTransfer() As Boolean
            Get
                Return m_blAutoTransfer
            End Get
            Set(ByVal value As Boolean)
                m_blAutoTransfer = value
            End Set
        End Property
        ''' <author>
        '''    	<name>Do Xuan Dat</name>
        '''    	<date> 2009-11-09</date>
        ''' </author>
        ''' <summary>
        ''' Processing Slot
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Result() As Boolean
            Get
                Return m_blResult
            End Get
            Set(ByVal value As Boolean)
                m_blResult = value
            End Set
        End Property

        ''' <author>
        '''    	<name>Do Xuan Dat</name>
        '''    	<date> 2009-11-09</date>
        ''' </author>
        ''' <summary>
        ''' Get or set The LoadLock message
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LoadlockName() As String
            Get
                Return m_strLoadlockName
            End Get
            Set(ByVal value As String)
                m_strLoadlockName = value
            End Set
        End Property
        ''' <author>
        '''    	<name>Do Xuan Dat</name>
        '''    	<date> 2009-11-09</date>
        ''' </author>
        ''' <summary>
        ''' Get or set The error message
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property ErrorMessage() As String
            Get
                Return m_strErrorMessage
            End Get
            Set(ByVal value As String)
                m_strErrorMessage = value
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
        Public ReadOnly Property WaferInfo() As AVPWaferInfo
            Get
                Return m_waferInfo
            End Get

        End Property

        ''' <author> Dua Tran </author>
        ''' <date> 2021-11-26 </date>
        ''' <summary>
        ''' Gets or Sets IsReturnForProcessCJ
        ''' </summary>
        Public Property IsReturnForProcessCJ() As Boolean
            Get
                Return m_blReturnForProcessCJ
            End Get
            Set(ByVal value As Boolean)
                m_blReturnForProcessCJ = value
            End Set
        End Property
#End Region
    End Class
End Namespace
