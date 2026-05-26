Namespace DataManagerment
    Public Class WaferFlow
        Private m_strName As String = String.Empty
        Private m_strDescription As String = String.Empty
        Private m_arlStepList As ArrayList = Nothing
        Private m_arlLoopList As ArrayList = Nothing

        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-08-16</date>
        ''' </author>
        ''' <summary>
        ''' WaferFlowName: get and set WaferFlowName
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property WaferFlowName() As String
            Get
                Return m_strName
            End Get
            Set(ByVal value As String)
                m_strName = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-08-16</date>
        ''' </author>
        ''' <summary>
        ''' Description: get and set Description
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Description() As String
            Get
                Return m_strDescription
            End Get
            Set(ByVal value As String)
                m_strDescription = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-08-16</date>
        ''' </author>
        ''' <summary>
        ''' StepList: get and set StepList
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property StepList() As ArrayList
            Get
                Return m_arlStepList
            End Get
            Set(ByVal value As ArrayList)
                m_arlStepList = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-08-16</date>
        ''' </author>
        ''' <summary>
        ''' LoopList: get and set LoopList
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LoopList() As ArrayList
            Get
                Return m_arlLoopList
            End Get
            Set(ByVal value As ArrayList)
                m_arlLoopList = value
            End Set
        End Property

        'return false: don't exist
        Public Function CheckRecipeExist() As Boolean
            Try
                For Each wfStep As WaferflowStep In StepList
                    Dim strChamber As String = String.Empty

                    'Stationlist have only 1 Station
                    For Each station As String In wfStep.StationList
                        strChamber = station
                    Next
                    Dim lstStrRecipe As ArrayList = AVPLib.ContainerData.ListChamber(AVPLib.Utils.chamberName2ChamberID(strChamber))

                    If Not String.IsNullOrEmpty(wfStep.RecipeName) Then
                        If lstStrRecipe Is Nothing OrElse lstStrRecipe.Count <= 0 Then
                            Return False
                        End If

                        For Each recipeName As String In lstStrRecipe
                            If recipeName.ToUpper = wfStep.RecipeName.ToUpper Then
                                Return True
                            End If
                        Next
                    End If
                    Return False
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
        End Function
    End Class

    Public Class WaferflowStep
        Private m_intNumber As Integer = 0
        Private m_arlStationList As ArrayList = Nothing
        Private m_strRecipeName As String = String.Empty
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-08-16</date>
        ''' </author>
        ''' <summary>
        ''' LoopList: get and set LoopList
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Number() As Integer
            Get
                Return m_intNumber
            End Get
            Set(ByVal value As Integer)
                m_intNumber = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-08-16</date>
        ''' </author>
        ''' <summary>
        ''' StationList: get and set StationList
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property StationList() As ArrayList
            Get
                Return m_arlStationList
            End Get
            Set(ByVal value As ArrayList)
                m_arlStationList = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-08-16</date>
        ''' </author>
        ''' <summary>
        ''' RecipeName: get and set RecipeName
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RecipeName() As String
            Get
                Return m_strRecipeName
            End Get
            Set(ByVal value As String)
                m_strRecipeName = value
            End Set
        End Property
    End Class

    Public Class WaferflowLoop
        Private m_intNo As Integer = 0
        Private m_intStart As Integer = -1
        Private m_intEnd As Integer = -1
        Private m_intLoopCount As Integer = 0
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-08-16</date>
        ''' </author>
        ''' <summary>
        ''' LoopNo: get and set LoopNo
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LoopNo() As Integer
            Get
                Return m_intNo
            End Get
            Set(ByVal value As Integer)
                m_intNo = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-08-16</date>
        ''' </author>
        ''' <summary>
        ''' LoopStart: get and set LoopStart
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LoopStart() As Integer
            Get
                Return m_intStart
            End Get
            Set(ByVal value As Integer)
                m_intStart = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-08-16</date>
        ''' </author>
        ''' <summary>
        ''' LoopEnd: get and set LoopEnd
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LoopEnd() As Integer
            Get
                Return m_intEnd
            End Get
            Set(ByVal value As Integer)
                m_intEnd = value
            End Set
        End Property
        ''' <author>
        '''    	<name> Le Hieu Truc </name>
        '''    	<date> 2009-08-16</date>
        ''' </author>
        ''' <summary>
        ''' LoopCount: get and set LoopCount
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LoopCount() As Integer
            Get
                Return m_intLoopCount
            End Get
            Set(ByVal value As Integer)
                m_intLoopCount = value
            End Set
        End Property
    End Class


    ''' <author>
    '''    	<name> Tran Ngoc Khiet </name>
    '''    	<date> 2009-23-07</date>
    ''' </author>
    ''' <summary>
    ''' LoopPanel: get and set WaferFlowLoopInfo
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Class WaferFlowLoopInfo
        Private m_waferflowLoopInfo As List(Of AVPLib.DataManagerment.WaferflowLoop)
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-23-07</date>
        ''' </author>
        ''' <summary>
        ''' Get property ListLoop
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property LoopList() As List(Of WaferflowLoop)
            Get
                Return m_waferflowLoopInfo
            End Get
            Set(ByVal value As List(Of WaferflowLoop))
                m_waferflowLoopInfo = value
            End Set
        End Property
        'init 
        Public Sub New()
            m_waferflowLoopInfo = New List(Of WaferflowLoop)
        End Sub

        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-23-07</date>
        ''' </author>
        ''' <summary>
        '''  Add to loop
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Add(ByVal pitem As WaferflowLoop) As Boolean
            AVPLib.Log.coreLogger.Info("Enter Add")
            Try
                For Each item As WaferflowLoop In m_waferflowLoopInfo
                    If pitem.LoopStart < item.LoopStart And pitem.LoopEnd > item.LoopEnd Then
                        AVPLib.Log.guiLogger.Info("Leave Add")
                        Return False
                    End If
                Next

                m_waferflowLoopInfo.Add(pitem)

            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.guiLogger.Info("Leave Add")
            Return False
        End Function
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-23-07</date>
        ''' </author>
        ''' <summary>
        '''  Add a Index to a loop
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AddOneItemToOneLoop(ByVal pIndex As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter AddOneItemToOneLoop")
            Try
                For Each item As WaferflowLoop In m_waferflowLoopInfo
                    'contain in loop
                    If (FindLoopByIndex(pIndex) IsNot Nothing) Then
                        Return False
                    End If
                    'add to loop
                    If (item.LoopStart <= pIndex And item.LoopEnd >= pIndex - 1) Then
                        item.LoopEnd += 1
                        Continue For
                    Else
                        'add to loop
                        If (item.LoopStart >= pIndex - 1 And item.LoopEnd <= pIndex) Then
                            item.LoopEnd -= 1
                            Continue For
                        End If
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.guiLogger.Info("Leave AddOneItemToOneLoop")
            Return False
        End Function

        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-23-07</date>
        ''' </author>
        ''' <summary>
        '''  Remove loop ID: and not modify index start, index end
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Sub RemoveLoopInfo(ByVal index As Integer)
            Dim item As WaferflowLoop = FindLoopByIndex(index)
            AVPLib.Log.coreLogger.Info("Enter RemoveByLoop")
            Try
                If item IsNot Nothing Then
                    m_waferflowLoopInfo.Remove(item)
                End If
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.guiLogger.Info("Leave RemoveByLoop")
        End Sub
        ''' <author>
        '''    	<name> Tran Ngoc Khiet </name>
        '''    	<date> 2009-23-07</date>
        ''' </author>
        ''' <summary>
        '''  Find Looop By Index
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FindLoopByIndex(ByVal index As Integer) As WaferflowLoop
            AVPLib.Log.coreLogger.Info("Enter FindLoopByIndex")
            Try
                For Each item As WaferflowLoop In m_waferflowLoopInfo
                    If (item.LoopStart <= index And item.LoopEnd >= index) Then
                        Return item
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.guiLogger.Info("Leave FindLoopByIndex")
            Return Nothing
        End Function
        ''' <author>
        '''    	<name> DoXuanDat </name>
        '''    	<date> 2009-07-07</date>
        ''' </author>
        ''' <summary>
        '''  Find Looop By Index
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function isStartEndofLoop(ByVal index As Integer) As Boolean
            AVPLib.Log.coreLogger.Info("Enter FindLoopByIndex")
            Try
                For Each item As WaferflowLoop In m_waferflowLoopInfo
                    If (item.LoopStart = index Or item.LoopEnd = index) Then
                        Return True
                    End If
                Next
            Catch ex As Exception
                AVPLib.Log.avpLogger.Error(ex.ToString())
            End Try
            AVPLib.Log.guiLogger.Info("Leave FindLoopByIndex")
            Return False
        End Function
    End Class

End Namespace