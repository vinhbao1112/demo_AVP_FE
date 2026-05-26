Imports System
Public Class DBWaferList
#Region "Class Constants & Variables"
    Private m_arrWaferList As ArrayList = Nothing 'List of Wafer
#End Region

#Region "Properties"

    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Property WaferList() As ArrayList
        Get
            If m_arrWaferList Is Nothing Then
                m_arrWaferList = New ArrayList
            End If
            Return m_arrWaferList
        End Get
        Set(ByVal value As ArrayList)
            m_arrWaferList = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub
    Public Sub New(ByVal arrWaferList As ArrayList)
        Me.m_arrWaferList = arrWaferList
    End Sub
#End Region

End Class

Public Class DBWaferSlot
#Region "Class Constants & Variables"
    Private m_strSlot As String = String.Empty
    Private m_WaferSequence As DBWaferSeq = Nothing
    Private m_strWaferID As String
    Private m_strCurrentStationID As String
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Property WaferSequence() As DBWaferSeq
        Get
            Return m_WaferSequence
        End Get
        Set(ByVal value As DBWaferSeq)
            m_WaferSequence = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Property Slot() As String
        Get
            Return m_strSlot
        End Get
        Set(ByVal value As String)
            m_strSlot = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub
    Public Sub New(ByVal WfSequence As DBWaferSeq, ByVal SlotInfo As String)
        Me.m_WaferSequence = WfSequence
        Me.m_strSlot = SlotInfo
    End Sub
#End Region
End Class

Public Class DBWaferSeq
#Region "Class Constants & Variables"
    Private m_strSeqName As String = String.Empty
    Private m_arrSeqStepList As ArrayList = Nothing
    Private m_arrStepList As List(Of String) = Nothing
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Property SeqName() As String
        Get
            Return m_strSeqName
        End Get
        Set(ByVal value As String)
            m_strSeqName = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Property SeqStepList() As ArrayList
        Get
            If m_arrSeqStepList Is Nothing Then
                m_arrSeqStepList = New ArrayList
            End If
            Return m_arrSeqStepList
        End Get
        Set(ByVal value As ArrayList)
            m_arrSeqStepList = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Property StepList() As List(Of String)
        Get
            If m_arrStepList Is Nothing Then
                m_arrStepList = New List(Of String)
            End If
            Return m_arrStepList
        End Get
        Set(ByVal value As List(Of String))
            m_arrStepList = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' Get the step that have step NO = strStepNo
    ''' </summary>
    ''' <remarks></remarks>
    Public Function SeqNo(ByVal strSeqNo As String) As DBSeqStep
        Dim res As DBSeqStep = Nothing

        For Each [step] As DBSeqStep In m_arrSeqStepList
            If [step].SeqNumber = strSeqNo Then
                res = [step]
                Exit For
            End If
        Next

        Return res
    End Function
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub
#End Region
End Class

Public Class DBSeqStep
#Region "Class Constants & Variables"
    Private m_strSeqNumber As String = String.Empty
    Private m_strRecipeName As String = String.Empty
    Private m_strDestSlot As String = String.Empty
    Private m_arrStationList As ArrayList = Nothing
    Private m_strLoadLockName As String = String.Empty
    Private m_iSlotID As Integer = 1
#End Region

#Region "Properties"
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2013-1-5</date>
    ''' </author>
    ''' <summary>
    ''' Support multi slot (corona chamber)
    ''' </summary>
    ''' <remarks></remarks>
    Public Property SlotID() As Integer
        Get
            Return m_iSlotID
        End Get
        Set(ByVal value As Integer)
            m_iSlotID = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Property RecipeName() As String
        Get
            Return m_strRecipeName
        End Get
        Set(ByVal value As String)
            m_strRecipeName = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-04-25</date>
    ''' </author>
    ''' <summary>
    ''' ONLY USED FOR RUNNING MODE
    ''' </summary>
    ''' <remarks></remarks>
    Public Property LoadLockName() As String
        Get
            Return m_strLoadLockName
        End Get
        Set(ByVal value As String)
            m_strLoadLockName = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-07-22</date>
    ''' </author>
    ''' <summary>
    ''' Recipe Path
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RecipePath() As String
        Get
            If (ContainerDAO.Enable_ANYIBE_Mode AndAlso m_arrStationList.Item(0) <> RobotConfigurationValues.ANY_IBE_CHAMBER) Then
                Dim serverConfig As Server = AVPLib.DataManagerment.ConfigurationManager.GetConfigItem(m_arrStationList.Item(0))
                If (serverConfig.Type = ConstEnum.IBEType.AVP_IBE.ToString()) Then
                    Return ContainerDAO.FPath_ChamberRecipe + "\" + RobotConfigurationValues.ANY_IBE_CHAMBER + "\" + RecipeName + ".xml"
                End If
            End If
            Return ContainerDAO.FPath_ChamberRecipe + "\" + m_arrStationList.Item(0) + "\" + RecipeName + ".xml"
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-07-22</date>
    ''' </author>
    ''' <summary>
    ''' Recipe Path
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RunningRecipePath() As String
        Get
            If m_arrStationList.Item(0) = AVPLib.ConstEnum.Equipments.Aligner.ToString() Then
                Return RecipePath
            End If
            If (Utils.IsIBEChamber_ANYIBE(m_arrStationList(0))) Then
                Return ContainerDAO.FPath_TempData + "\" + m_strLoadLockName + "\Recipes" + _
                            "\" + RobotConfigurationValues.ANY_IBE_CHAMBER + "\" + RecipeName + ".xml"
            Else
                Return ContainerDAO.FPath_TempData + "\" + m_strLoadLockName + "\Recipes" + _
                                            "\" + m_arrStationList.Item(0) + "\" + RecipeName + ".xml"
            End If

        End Get
        Set(ByVal value As String)
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Property SeqNumber() As String
        Get
            Return m_strSeqNumber
        End Get
        Set(ByVal value As String)
            m_strSeqNumber = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Property StationList() As ArrayList
        Get
            If m_arrStationList Is Nothing Then
                m_arrStationList = New ArrayList
            End If
            Return m_arrStationList
        End Get
        Set(ByVal value As ArrayList)
            m_arrStationList = value
        End Set
    End Property
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' Get the first station in the list. It should have only one station
    ''' </summary>
    ''' <remarks></remarks>
    Public Property StationName() As String
        Get
            If m_arrStationList IsNot Nothing And m_arrStationList.Count > 0 Then
                Return m_arrStationList.Item(0)
            End If
            Return String.Empty
        End Get
        Set(ByVal value As String)
        End Set
    End Property
    ''' <author>
    '''    	<name> Le Hieu Truc </name>
    '''    	<date> 2009-07-23</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Property DestSlot() As String
        Get
            Return m_strDestSlot
        End Get
        Set(ByVal value As String)
            m_strDestSlot = value
        End Set
    End Property
#End Region

#Region "Construtor and Destructor"
    ''' <author>
    '''    	<name> Cao Anh Kiet </name>
    '''    	<date> 2008-08-23</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

    End Sub

    ''' <author>
    '''    	<name> Dat Cao </name>
    '''    	<date> 2011-12-01</date>
    ''' </author>
    ''' <summary>
    ''' Copy object
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Clone() As DBSeqStep
        Dim objResult As DBSeqStep = New DBSeqStep()

        'copy array station list
        If (m_arrStationList IsNot Nothing) Then
            objResult.StationList = New ArrayList

            For Each Item As String In m_arrStationList
                objResult.StationList.Add(Item)
            Next

        Else
            objResult.StationList = Nothing
        End If

        'copy destination slot 
        objResult.DestSlot = m_strDestSlot

        'copy recipe name 
        objResult.RecipeName = m_strRecipeName

        'copy sequence number
        objResult.SeqNumber = m_strSeqNumber

        objResult.LoadLockName = m_strLoadLockName

        objResult.SlotID = m_iSlotID
        Return objResult
    End Function

    Public Sub New(ByVal arrStationList As ArrayList, _
                   ByVal DestinationSlot As String, _
                   ByVal Recipe_Name As String, _
                   ByVal SequenceNum As String)
        Me.m_arrStationList = arrStationList
        Me.m_strDestSlot = DestinationSlot
        Me.m_strRecipeName = Recipe_Name
        Me.m_strSeqNumber = SequenceNum
    End Sub
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-07-27</date>
    ''' </author>
    ''' <summary>
    ''' Construtor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal strStationName As String, ByVal SlotID As Integer, Optional ByVal strRecipeName As String = "")
        Me.m_arrStationList = New ArrayList
        Me.m_arrStationList.Add(strStationName)
        Me.m_strDestSlot = 0 ' don't care
        Me.m_strRecipeName = strRecipeName
        Me.m_strSeqNumber = 0 ' don't care
        Me.SlotID = SlotID
    End Sub
    
    ''' <author>
    '''    	<name> Do Xuan Dat </name>
    '''    	<date> 2009-07-22</date>
    ''' </author>
    ''' <summary>
    ''' override the to string
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Function ToString() As String
        Dim strFirstStationName As String = String.Empty
        If m_arrStationList.Count > 0 Then
            strFirstStationName = m_arrStationList.Item(0)
        End If
        Return String.Format("**m_SeqNumber:{0},m_StationName:{1},m_RecipeName:{2}**", _
                              m_strSeqNumber, _
                              strFirstStationName, _
                              m_strRecipeName)
    End Function
#End Region
End Class




