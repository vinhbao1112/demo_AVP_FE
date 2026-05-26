Imports System.IO
Imports System.Xml

''' <author>
'''    	<name> Tien Dat, Nguyen </name>
'''    	<date> 2009-07-06</date>
''' </author>
''' <summary>
''' This class represents an Aligner recipe.
''' </summary>
'--------------------Standard Sample Aligner Recipe ---------------------------------
'<Recipe>
'    <StepList>
'        <Step>
'            <SeqNo>1</SeqNo>
'            <StepName>0 Degree</StepName>
'            <StepDescription>Align</StepDescription>
'            <Angle>0</Angle>
'        </Step>
'    </StepList>
'</Recipe>---------------------------------------------------------------------------
Public Class AlignerRecipe

    Private m_xmlDocRecipe As Xml.XmlDocument = Nothing
    Private m_strRecipeFileName As String = String.Empty

    Public IsValid As Boolean = False

    ''' <author>
    '''    	<name> Tien Dat, Nguyen </name>
    '''    	<date> 2009-07-06</date>
    ''' </author>
    ''' <summary>
    ''' Return a xml document which loads data from xml file or a xml string.
    ''' </summary>
    ''' <remarks></remarks>
    Private Function OpenDataInNode(ByVal xmlinput As String, ByVal isFilename As Boolean) As XmlDocument
        AVPLib.Log.coreLogger.Info("Enter OpenDataInNode")
        Dim document As New XmlDocument
        If isFilename Then
            Try
                If Not File.Exists(xmlinput) Then
                    AVPLib.Log.coreLogger.Debug("File=" & xmlinput & " not found!")
                    AVPLib.Log.coreLogger.Info("Leave OpenDataInNode")
                    Return Nothing
                End If
                document.Load(xmlinput)
            Catch exception As Exception
                AVPLib.Log.coreLogger.Error(exception.Message)
                AVPLib.Log.coreLogger.Info("Leave OpenDataInNode")
                Return Nothing
            End Try
        Else
            document.LoadXml(xmlinput)
        End If
        AVPLib.Log.coreLogger.Info("Leave OpenDataInNode")
        Return document
    End Function

    ''' <author>
    '''    	<name> Tien Dat, Nguyen </name>
    '''    	<date> 2009-07-06</date>
    ''' </author>
    ''' <summary>
    ''' Load xml data into Aligner Recipe.
    ''' </summary>
    ''' <remarks></remarks>
    Private Function OpenInfo(ByVal xmlinput As String, ByVal isFilename As Boolean) As Boolean
        AVPLib.Log.coreLogger.Info("Enter OpenInfo")
        Try
            m_xmlDocRecipe = OpenDataInNode(xmlinput, isFilename)
            If (m_xmlDocRecipe Is Nothing) Then
                AVPLib.Log.coreLogger.Info("Leave OpenInfo")
                Return False
            End If
        Catch exception As Exception
            AVPLib.Log.coreLogger.Error(exception.Message)
            AVPLib.Log.coreLogger.Info("Leave OpenInfo")
            Return False
        End Try
        AVPLib.Log.coreLogger.Info("Leave OpenInfo")
        Return True
    End Function

    ''' <author>
    '''    	<name> Tien Dat, Nguyen </name>
    '''    	<date> 2009-07-06</date>
    ''' </author>
    ''' <summary>
    ''' Get a number of child belong to a xml node.
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetDataListCount(ByVal Keypath As String) As Long
        AVPLib.Log.coreLogger.Info("Enter GetDataListCount")

        Dim list As XmlNodeList = Nothing
        Try
            If (Keypath.Length <> 0) Then
                list = m_xmlDocRecipe.SelectNodes(Keypath)
            End If
            If (list Is Nothing) Then
                AVPLib.Log.coreLogger.Error("Node not found [" & Keypath & "]")
                AVPLib.Log.coreLogger.Info("Leave GetDataListCount")
                Return 0
            End If
            If (list.Count = 0) Then
                AVPLib.Log.coreLogger.Error("Node not found [" & Keypath & "]")
                AVPLib.Log.coreLogger.Info("Leave GetDataListCount")
                Return 0
            End If
            AVPLib.Log.coreLogger.Info("Leave GetDataListCount")
            Return list.Count
        Catch exception As Exception
            AVPLib.Log.coreLogger.Error(exception.Message)
            AVPLib.Log.coreLogger.Info("Leave GetDataListCount")
            Return 0
        End Try
    End Function

    ''' <author>
    '''    	<name> Tien Dat, Nguyen </name>
    '''    	<date> 2009-07-06</date>
    ''' </author>
    ''' <summary>
    ''' Get a number of steps of Aligner Recipe.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property NumberOfSteps() As Integer
        Get
            Return CInt(GetDataListCount("/Recipe/StepList/Step"))
        End Get
    End Property

    ''' <author>
    '''    	<name> Tien Dat, Nguyen </name>
    '''    	<date> 2009-07-06</date>
    ''' </author>
    ''' <summary>
    ''' Get data value of a xml node.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetData(ByVal Keypath As String, ByVal nodeIdx As Integer) As String
        AVPLib.Log.coreLogger.Info("Enter GetData")

        Dim innerText As String = String.Empty
        Dim node As XmlNode = Nothing
        Dim list As XmlNodeList = Nothing
        Try
            If (Keypath.Length <> 0) Then
                list = m_xmlDocRecipe.SelectNodes(Keypath)
            End If
            If (list Is Nothing) Then
                AVPLib.Log.coreLogger.Error("Node not found [" & Keypath & "]")
                AVPLib.Log.coreLogger.Info("Leave GetData")
                Return innerText
            End If
            If (list.Count <> 0) Then
                If ((list.Count = 1) OrElse (nodeIdx = -1)) Then
                    node = m_xmlDocRecipe.SelectSingleNode(Keypath)
                Else
                    node = list.Item(nodeIdx)
                End If
                If (node Is Nothing) Then
                    AVPLib.Log.coreLogger.Info("Leave GetData")
                    Return innerText
                End If
            Else
                node = m_xmlDocRecipe.SelectSingleNode(Keypath)
                If (node Is Nothing) Then
                    AVPLib.Log.coreLogger.Error("Node not found [" & Keypath & "]")
                    AVPLib.Log.coreLogger.Info("Leave GetData")
                    Return innerText
                End If
            End If
            innerText = node.Value
            If (innerText Is Nothing) Then
                innerText = node.InnerText
            End If
            AVPLib.Log.coreLogger.Info("Leave GetData")
            Return innerText
        Catch exception As Exception
            AVPLib.Log.coreLogger.Error(exception.Message)
        End Try
        AVPLib.Log.coreLogger.Info("Leave GetData")
        Return innerText
    End Function

    ''' <author>
    '''    	<name> Tien Dat, Nguyen </name>
    '''    	<date> 2009-07-06</date>
    ''' </author>
    ''' <summary>
    ''' Get data value of a xml root node.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetData(ByVal Keypath As String) As String
        Return GetData(Keypath, -1)
    End Function

    ''' <author>
    '''    	<name> Tien Dat, Nguyen </name>
    '''    	<date> 2009-07-06</date>
    ''' </author>
    ''' <summary>
    ''' Get step data of a step.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetStepData(ByVal stepNumber As Integer, ByVal paraName As String) As String
        Return GetData((String.Format("/Recipe/StepList/Step[SeqNo='{0}']/Parameters/", stepNumber.ToString) & paraName))
    End Function

    ''' <author>
    '''    	<name> Tien Dat, Nguyen </name>
    '''    	<date> 2009-07-06</date>
    ''' </author>
    ''' <summary>
    ''' Get step value of a step.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetStepValue(ByVal stepNumber As Integer, ByVal paraName As String) As String
        Return GetStepData(stepNumber, paraName)
    End Function

    ''' <author>
    '''    	<name> Tien Dat, Nguyen </name>
    '''    	<date> 2009-07-06</date>
    ''' </author>
    ''' <summary>
    ''' Convert string to long value.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetLongFromString(ByVal numStr As String, ByVal defVal As Long) As Long
        AVPLib.Log.coreLogger.Info("Enter GetLongFromString")

        If (numStr Is Nothing) Then
            AVPLib.Log.coreLogger.Info("Leave GetLongFromString")
            Return defVal
        End If
        Dim retVal As Long = defVal
        If Long.TryParse(numStr, retVal) Then
            AVPLib.Log.coreLogger.Info("Leave GetLongFromString")
            Return retVal
        End If
        AVPLib.Log.coreLogger.Info("Leave GetLongFromString")
        Return defVal
    End Function

    Public Function GetSingleFromString(ByVal numStr As String, ByVal defVal As Single) As Single
        AVPLib.Log.coreLogger.Info("Enter GetLongFromString")

        If (numStr Is Nothing OrElse numStr = String.Empty) Then
            AVPLib.Log.coreLogger.Info("Leave GetLongFromString")
            Return defVal
        End If
        Dim retVal As Single = defVal
        If Single.TryParse(numStr, retVal) Then
            AVPLib.Log.coreLogger.Info("Leave GetLongFromString")
            Return retVal
        End If
        AVPLib.Log.coreLogger.Info("Leave GetLongFromString")
        Return defVal
    End Function

    ''' <author>
    '''    	<name> Tien Dat, Nguyen </name>
    '''    	<date> 2009-07-06</date>
    ''' </author>
    ''' <summary>
    ''' Constructor.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal fileName As String)
        IsValid = False
        m_strRecipeFileName = fileName
        Me.IsValid = OpenInfo(fileName, True)
    End Sub

End Class
