Public Class SequenceInfor
#Region "Constant and variables"
    Private m_WaferInfo As AVPWaferInfo
    Private m_strLLName As String

    Private m_lstChamberName As List(Of String)
    Private m_WaferFlow As ArrayList  'List DBSeqStep
#End Region

#Region "Public property"
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-11-09</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get or set Load Lock Name
    ''' </summary>
    ''' <remarks></remarks>
    Public Property WaferInfo() As AVPWaferInfo
        Get
            Return m_WaferInfo
        End Get
        Set(ByVal value As AVPWaferInfo)
            m_WaferInfo = value
        End Set
    End Property

    ''' <author>
    '''    	<name> DoXuanDat </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get a list of chambers (inculding Aligner)
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ChamberNames() As List(Of String)
        Get
            Return m_lstChamberName
        End Get
        Set(ByVal value As List(Of String))
            m_lstChamberName = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-12-11</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get or set Load Lock Name
    ''' </summary>
    ''' <remarks></remarks>
    Public Property WaferFlow() As ArrayList
        Get
            If m_WaferFlow Is Nothing Then
                m_WaferFlow = New ArrayList()
            End If
            Return m_WaferFlow
        End Get
        Set(ByVal value As ArrayList)
            Me.m_WaferFlow = value
            m_lstChamberName = GetChamberNames()
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-7-21</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get or set wafer flow
    ''' </summary>
    ''' <remarks></remarks>
    Public Property LoadLockName() As String
        Get
            Return m_strLLName
        End Get
        Set(ByVal value As String)
            m_strLLName = value
        End Set
    End Property

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-12-11</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' The number of chamber names
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property ChamberCount() As Integer
        Get
            Return m_lstChamberName.Count
        End Get
    End Property
#End Region

#Region "Construtor and destructor"
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-12-11</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal waferInfo As AVPWaferInfo)
        m_strLLName = ""
        m_lstChamberName = New List(Of String)
        m_WaferFlow = New ArrayList
        m_WaferInfo = waferInfo
    End Sub
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-12-01</date>
    ''' </author>
    ''' <summary>
    ''' Copy Constructor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal objSegInfo As SequenceInfor)
        m_strLLName = objSegInfo.LoadLockName

        'copy chamber name list
        m_lstChamberName = New List(Of String)
        For Each Item As String In objSegInfo.ChamberNames
            m_lstChamberName.Add(Item)
        Next

        'copy wafer flow
        m_WaferFlow = New ArrayList
        For Each Item As Object In objSegInfo.WaferFlow
            Try
                Dim objDBSegStep As DBSeqStep = CType(Item, DBSeqStep)
                Dim objCopyDBSegStep As DBSeqStep = objDBSegStep.Clone()
                m_WaferFlow.Add(objCopyDBSegStep)
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.Message)
            End Try
        Next

        'copy wafer info
        m_WaferInfo = New AVPWaferInfo(objSegInfo.WaferInfo)
    End Sub

    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-12-01</date>
    ''' </author>
    ''' <summary>
    ''' Copy Constructor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        m_strLLName = ""

        'Clear chamber name list
        If (m_lstChamberName IsNot Nothing) Then
            m_lstChamberName.Clear()
        End If

        If (m_WaferFlow IsNot Nothing) Then
            m_WaferFlow.Clear()
        End If

        'clear wafer info
        m_WaferInfo = Nothing
    End Sub
    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-12-11</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Destructor
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub Finalize()
        AVPLib.Log.coreLogger.Info("Enter Finalize")
        m_strLLName = ""
        m_lstChamberName.Clear()
        m_WaferFlow.Clear()
        AVPLib.Log.coreLogger.Info("Leave Finalize")
    End Sub
#End Region

#Region "Public method"

    ''' <author>
    '''    	<name> Ngo Cao Dinh </name>
    '''    	<date> 2008-12-13</date>
    ''' </author>
    ''' <Modifiers>
    ''' <Modifier>
    '''   	<Name></Name>
    '''   	<Date></Date>
    '''		<Description></Description>
    ''' </Modifier>
    '''</Modifiers>
    ''' <summary>
    ''' Get array chamber and load lock name
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetChamberNames() As List(Of String)
        AVPLib.Log.coreLogger.Info("Enter GetChamberNames")
        ' if have some funciton to sort unique here, we should use it

        Dim lstRes As New List(Of String)

        ' Chamber name might dublicate with others
        For Each SequenceStep As DBSeqStep In WaferFlow
            For Each strStationName As String In SequenceStep.StationList
                If Not lstRes.Contains(strStationName) Then
                    lstRes.Add(strStationName)
                End If
            Next
        Next

        AVPLib.Log.coreLogger.Info(lstRes)
        AVPLib.Log.coreLogger.Info("Leave GetChamberNames")

        Return lstRes
    End Function

#End Region
End Class
