Namespace DataManagerment
    Public Class ConfigurationManager
#Region "Class Constants & Variables"
        Private Shared m_htbConfigItemList As Hashtable
#End Region
#Region "Properties"
        ''' <author>
        '''    	<name> Nguyen Bao Trieu </name>
        '''    	<date> 2008-11-03</date>
        ''' </author>
        ''' <summary>
        ''' Get current ConfigItemList 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Property ConfigItemList() As Hashtable
            Get
                If m_htbConfigItemList Is Nothing Then
                    m_htbConfigItemList = ContainerDAO.GetConfigurationServer()
                End If
                Return m_htbConfigItemList
            End Get
            Set(ByVal value As Hashtable)
                m_htbConfigItemList = value
            End Set
        End Property
#Region "Public methods"
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
        ''' Load Configuration Manager
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function Load() As Boolean
            Return True
        End Function
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
        ''' Unload Configuration Manager
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function Unload() As Boolean
            Return True
        End Function
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
        ''' Get configItem 
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <remarks></remarks>
        Public Shared Function GetConfigItem(ByVal Name As String) As Server
            AVPLib.Log.coreLogger.Info("Enter GetConfigItem")
            AVPLib.Log.coreLogger.Info("Leave GetConfigItem")
            Return ConfigItemList.Item(Name)
        End Function
#End Region
#End Region
    End Class
End Namespace

