Imports AVPLib
Imports AVPLib.DataManagerment

Public Class ContainerDAO
#Region "Class Constants & Variables"

#Region "Xml Document"
    'Message Recipe
    Private Shared m_MessageDoc As System.Xml.XmlDocument

    'Robot Config
    Private Shared m_MessageTextDoc As System.Xml.XmlDocument
    Private Shared m_ComboItemDoc As System.Xml.XmlDocument

    Private Shared m_MessageGuiBusinessDoc As System.Xml.XmlDocument

    ''WaferFlow
    Private Shared m_WaferFlowDoc As System.Xml.XmlDocument
#End Region
#End Region

#Region "Property Document"
#Region "Message Gui Business"
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' MessageGuiBusinessDoc
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Property MessageGuiBusinessDoc() As System.Xml.XmlDocument
        Get
            If m_MessageGuiBusinessDoc Is Nothing Then
                m_MessageGuiBusinessDoc = New System.Xml.XmlDocument()
                Try
                    'm_MessageGuiBusinessDoc.Load(AVPLib.ContainerDAO.FPath_MessageGuiBusiness)
                    m_MessageGuiBusinessDoc = BinarySerialize.Open_DatFileConfig(AVPLib.ContainerDAO.FPath_MessageGuiBusiness)
                    If m_MessageGuiBusinessDoc Is Nothing Then
                        m_MessageGuiBusinessDoc = New System.Xml.XmlDocument()
                        m_MessageGuiBusinessDoc.LoadXml(AVPLib.XMLResources.ParseMessageGuiBusiness.XMLText)
                        'm_MessageGuiBusinessDoc.Save(AVPLib.ContainerDAO.FPath_MessageGuiBusiness)
                        BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_MessageGuiBusiness, m_MessageGuiBusinessDoc)
                    End If
                Catch ex As Exception
                    'try to load the local file
                    m_MessageGuiBusinessDoc.LoadXml(AVPLib.XMLResources.ParseMessageGuiBusiness.XMLText)
                    'm_MessageGuiBusinessDoc.Save(AVPLib.ContainerDAO.FPath_MessageGuiBusiness)
                    BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_MessageGuiBusiness, m_MessageGuiBusinessDoc)
                End Try
            End If
            Return m_MessageGuiBusinessDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_MessageGuiBusinessDoc = value
        End Set
    End Property
    ''' <author>
    '''    	<name>Le Hieu Truc</name>
    '''    	<date> 2009-07-10</date>
    ''' </author>
    ''' <summary>
    ''' SystemWaferFlowDoc
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Private Shared Property SystemWaferFlowDoc() As System.Xml.XmlDocument
    '    Get
    '        If m_WaferFlowDoc Is Nothing Then
    '            m_WaferFlowDoc = New System.Xml.XmlDocument()
    '            'm_WaferFlowDoc.Load(AVPLib.ContainerDAO.FPath_WaferFlow)
    '            m_WaferFlowDoc = BinarySerialize.Open_DatFileConfig(AVPLib.ContainerDAO.FPath_WaferFlow)
    '        End If
    '        Return m_WaferFlowDoc
    '    End Get
    '    Set(ByVal value As System.Xml.XmlDocument)
    '        m_MessageGuiBusinessDoc = value
    '    End Set
    'End Property
#End Region

#Region "Config Robot"

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Get Proerty Combo box Item Document Xml
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Property ComboItemDoc() As System.Xml.XmlDocument
        Get
            If m_ComboItemDoc Is Nothing Then
                m_ComboItemDoc = New System.Xml.XmlDocument()
                Try
                    'm_ComboItemDoc.Load()
                    m_ComboItemDoc = BinarySerialize.Open_DatFileConfig(AVPLib.ContainerDAO.FPath_SerialCommandEquipments)
                Catch ex As Exception
                    'try to load the local file
                    m_ComboItemDoc.LoadXml(AVPLib.XMLResources.SerialCommandEquipments.XMLText)
                    'm_ComboItemDoc.Save(AVPLib.ContainerDAO.FPath_SerialCommandEquipments)
                    BinarySerialize.SaveTo_DatFileConfig(AVPLib.ContainerDAO.FPath_SerialCommandEquipments, m_ComboItemDoc)
                End Try
            End If
            Return m_ComboItemDoc
        End Get
        Set(ByVal value As System.Xml.XmlDocument)
            m_ComboItemDoc = value
        End Set
    End Property
#End Region
#End Region

#Region "Function Dao"
#Region "Message Gui Business"
    ''' <author>
    '''    	<name>Cao Anh Kiet</name>
    '''    	<date> 2008-11-15</date>
    ''' </author>
    ''' <summary>
    ''' MessageGuiBusiness
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MessageGuiBusiness() As Hashtable
        Return MessageGuiBusinessLib.GetMessageConfig(MessageGuiBusinessDoc)
    End Function
#End Region

#Region "Config Robot"

    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-09-05</date>
    ''' </author>
    ''' <summary>
    ''' Get ComboItem
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetComboItem() As Hashtable
        Try
            Return RobotConfiguration.GetComboItems(ComboItemDoc)
        Catch ex As Exception
            AVPLib.Log.avpLogger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function
#End Region

#End Region
End Class
