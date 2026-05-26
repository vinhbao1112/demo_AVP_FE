Namespace Business
    Public Class TopologicalSorter
        ' Methods
        Public Sub New()
            m_size = NO_CHAMBERS_SUPPORTED
            m_vertices = New Integer(m_size - 1) {}
            m_matrix = New Integer(m_size - 1, m_size - 1) {}
            m_numVerts = 0
            m_sortedArray = New Integer(m_size - 1) {}
            m_verticesMap = New Dictionary(Of Integer, VertexData)(m_size)
        End Sub

        Public Sub Initialize()
            Dim UpperBound As Integer = m_size - 1
            Dim i As Integer
            For i = 0 To UpperBound
                Dim j As Integer
                For j = 0 To UpperBound
                    m_matrix(i, j) = 0
                Next j
            Next i
            For i = 0 To UpperBound
                m_sortedArray(i) = 0
            Next
            For Each vertexInfo As VertexData In m_verticesMap.Values
                vertexInfo.Dependencies.Clear()
            Next
            ' Support up to 6 Chambers.
            AddVertex(ChamberIndexMap.Item(ConstEnum.Equipments.Chamber1.ToString()))
            AddVertex(ChamberIndexMap.Item(ConstEnum.Equipments.Chamber2.ToString()))
            AddVertex(ChamberIndexMap.Item(ConstEnum.Equipments.Chamber3.ToString()))
        End Sub

        Public Sub AddEdge(ByVal srcChamber As String, ByVal destChamber As String)
            If (ChamberIndexMap.ContainsKey(srcChamber) And ChamberIndexMap.ContainsKey(destChamber)) Then
                Dim iStart As Integer = ChamberIndexMap(srcChamber)
                Dim iEnd As Integer = ChamberIndexMap(destChamber)
                AddEdge(iStart, iEnd)
            End If
        End Sub

        Public Sub AddEdge(ByVal start As Integer, ByVal [end] As Integer)
            m_matrix(start, [end]) = 1
            addDependency(start, [end])
        End Sub

        Public Function AddVertex(ByVal vertex As Integer) As Integer
            If Not m_verticesMap.ContainsKey(vertex) Then
                m_vertices(m_numVerts) = vertex
                m_numVerts = m_numVerts + 1
                m_verticesMap.Add(vertex, New VertexData(vertex))
            End If
            Return (m_numVerts - 1)
        End Function

        Public Function Sort(ByRef bHasCycle As Boolean) As Integer()
            bHasCycle = False
            Do While (m_numVerts > 0)
                Dim currentVertex As Integer = noSuccessors()
                If (currentVertex = -1) Then
                    bHasCycle = True
                    Return Nothing
                End If
                m_sortedArray((m_numVerts - 1)) = m_vertices(currentVertex)
                deleteVertex(currentVertex)
            Loop
            Return m_sortedArray
        End Function

        Public Function VerifyThereAreCyclesWithALengthOfOne() As Boolean
            Dim verTexInfo As VertexData
            For Each verTexInfo In m_verticesMap.Values
                Dim dependToVertex As Integer
                For Each dependToVertex In verTexInfo.Dependencies
                    Dim dependToVertexInfo As VertexData = m_verticesMap.Item(dependToVertex)
                    If dependToVertexInfo.IsDependentOn(verTexInfo.Id) Then
                        Return True
                    End If
                Next
            Next
            Return False
        End Function

        Private Sub addDependency(ByVal vertex As Integer, ByVal dependsToVertex As Integer)
            If m_verticesMap.ContainsKey(vertex) Then
                m_verticesMap.Item(vertex).AddDependency(dependsToVertex)
            End If
        End Sub

        Private Sub deleteVertex(ByVal delVert As Integer)
            If (delVert <> (m_numVerts - 1)) Then
                Dim j As Integer
                For j = delVert To (m_numVerts - 1) - 1
                    m_vertices(j) = m_vertices((j + 1))
                Next j
                Dim row As Integer
                For row = delVert To (m_numVerts - 1) - 1
                    moveRowUp(row, m_numVerts)
                Next row
                Dim col As Integer
                For col = delVert To (m_numVerts - 1) - 1
                    moveColLeft(col, (m_numVerts - 1))
                Next col
            End If
            m_numVerts -= 1
        End Sub

        Private Sub moveColLeft(ByVal col As Integer, ByVal length As Integer)
            Dim row As Integer
            For row = 0 To length - 1
                m_matrix(row, col) = m_matrix(row, (col + 1))
            Next row
        End Sub

        Private Sub moveRowUp(ByVal row As Integer, ByVal length As Integer)
            Dim col As Integer
            For col = 0 To length - 1
                m_matrix(row, col) = m_matrix((row + 1), col)
            Next col
        End Sub

        Private Function noSuccessors() As Integer
            Dim row As Integer
            For row = 0 To m_numVerts - 1
                Dim isEdge As Boolean = False
                Dim col As Integer
                For col = 0 To m_numVerts - 1
                    If (m_matrix(row, col) > 0) Then
                        isEdge = True
                        Exit For
                    End If
                Next col
                If Not isEdge Then
                    Return row
                End If
            Next row
            Return -1
        End Function

        ' Fields
        Private ReadOnly m_size As Integer
        Private ReadOnly m_matrix As Integer(,)
        Private m_numVerts As Integer
        Private ReadOnly m_sortedArray As Integer()
        Private ReadOnly m_vertices As Integer()
        Private m_verticesMap As Dictionary(Of Integer, VertexData)

        ' Nested Types
        Private Class VertexData
            ' Methods
            Friend Sub New(ByVal vertex As Integer)
                Id = vertex
                Dependencies = New List(Of Integer)
            End Sub

            Friend Sub AddDependency(ByVal dependencyToVertex As Integer)
                If Not Dependencies.Contains(dependencyToVertex) Then
                    Dependencies.Add(dependencyToVertex)
                End If
            End Sub

            Friend Function IsDependentOn(ByVal vertex As Integer) As Boolean
                Return Dependencies.Contains(vertex)
            End Function

            ' Fields
            Friend Dependencies As List(Of Integer)
            Friend Id As Integer
        End Class

        Public Shared ChamberIndexMap As Dictionary(Of String, Integer)

        Private Const NO_CHAMBERS_SUPPORTED As Integer = 6

        Shared Sub New()
            ChamberIndexMap = New Dictionary(Of String, Integer)
            ChamberIndexMap.Add(ConstEnum.Equipments.Chamber1.ToString(), 0)
            ChamberIndexMap.Add(ConstEnum.Equipments.Chamber2.ToString(), 1)
            ChamberIndexMap.Add(ConstEnum.Equipments.Chamber3.ToString(), 2)
        End Sub

    End Class
End Namespace
