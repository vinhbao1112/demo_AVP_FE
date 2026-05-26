''' <author>
'''    	<name> Tin Pham </name>
'''    	<date> 2016-01-15 </date>
''' </author>
''' <summary>
''' This class is used for action recipe.
''' </summary>
Public Class HRecipe

    Private m_baseConfigData As BaseConfigurationData
    Private m_baseRecipe As BaseRecipe
    Private m_factory As AbstractFactory
    Private m_MapConfigData As Hashtable

    Public Property BaseConfigurationDataProperty() As BaseConfigurationData
        Get
            Return m_baseConfigData
        End Get
        Set(ByVal value As BaseConfigurationData)
            m_baseConfigData = value
        End Set
    End Property

    Public Property MapConfigData() As Hashtable
        Get
            Return m_MapConfigData
        End Get
        Set(ByVal value As Hashtable)
            m_MapConfigData = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-15 </date>
    ''' </author>
    ''' <summary>
    ''' Contructor
    ''' </summary>
    Public Sub New(ByVal chamberType As String, ByVal mapConfigData As Hashtable)

        Select Case chamberType
            Case HConstants.AVPChamberTypes.PVD.ToString()
                m_factory = New PVDFactory()

            Case HConstants.AVPChamberTypes.IBE.ToString(), HConstants.AVPChamberTypes.VIBE.ToString()
                m_factory = New IBEFactory()

            Case HConstants.AVPChamberTypes.PVD6S.ToString
                m_factory = New PVDSFactory()

            Case HConstants.AVPChamberTypes.HRPVD.ToString()
                m_factory = New HRPVDFactory()

            Case HConstants.AVPChamberTypes.PVD2R4.ToString()
                m_factory = New PVD2R4Factory()

            Case HConstants.AVPChamberTypes.PVD4.ToString()
                m_factory = New PVD4Factory()

            Case HConstants.AVPChamberTypes.PVD6P.ToString()
                m_factory = New PVD6PFactory()

            Case HConstants.AVPChamberTypes.PVD6S.ToString()
                m_factory = New PVD6SFactory()

            Case HConstants.AVPChamberTypes.IBD.ToString(), HConstants.AVPChamberTypes.VIBD.ToString()
                m_factory = New IBDFactory()

            Case HConstants.AVPChamberTypes.PVDA.ToString(), "PVD_A" ' For compatible with other projects, will remove later.
                m_factory = New PVDAFactory()

            Case HConstants.AVPChamberTypes.RIE.ToString()
                m_factory = New RIEFactory()

            Case HConstants.AVPChamberTypes.PVD2T.ToString()
                m_factory = New PVD2TFactory()

            Case HConstants.AVPChamberTypes.PVDS.ToString()
                m_factory = New PVDSFactory()

            Case HConstants.AVPChamberTypes.PVD5T.ToString()
                m_factory = New PVD5TFactory()
            Case Else
                m_factory = New GeneralFactory()
        End Select
        m_MapConfigData = mapConfigData
        LoadRecipe(chamberType, m_factory, mapConfigData)
    End Sub

    ''' <author>
    '''    	<name> Dung Pham </name>
    '''    	<date> 2020-06-26 </date>
    ''' </author>
    ''' <summary>
    ''' Initialize for object recipe
    ''' </summary>
    Public Sub UpdateConfigurationData(ByVal mapConfigData As Hashtable)      
        m_baseConfigData.LoadConfigurationData(mapConfigData)
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-15 </date>
    ''' </author>
    ''' <summary>
    ''' Initialize for object recipe
    ''' </summary>
    Private Sub LoadRecipe(ByVal chamberType As String, ByVal factory As AbstractFactory, ByVal mapConfigData As Hashtable)
        m_baseConfigData = m_factory.CreateConfigurationData()
        m_baseConfigData.ChamberType = chamberType
        m_baseConfigData.LoadConfigurationData(mapConfigData)
        m_baseRecipe = m_factory.CreateRecipe()
    End Sub

    ''' <author>
    '''    	<name> Tin Pham </name>
    '''    	<date> 2016-01-15 </date>
    ''' </author>
    ''' <summary>
    ''' create DB recipe
    ''' </summary>
    Public Function CreateDBRecipe(ByVal recipeTemplatePath As String, Optional ByVal recipePath As String = "") As DBRecipe
        Return m_baseRecipe.CreateDBRecipe(recipeTemplatePath, recipePath, m_baseConfigData)
    End Function

End Class
