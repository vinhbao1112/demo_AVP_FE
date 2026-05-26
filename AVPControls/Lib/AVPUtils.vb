Public Class AVPUtils
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-16 </date>
    ''' </author>
    ''' <summary>
    ''' Get a value indicates the distance between two angle by clockwise from angle1 to angle2
    ''' </summary>
    Public Shared Function GetDistanceAngle(ByVal angle1 As Single, ByVal angle2 As Single) As Single
        Dim result As Single

        angle1 = angle1 Mod 360
        angle2 = angle2 Mod 360
        If angle1 < 0 Then
            angle1 = 360 + angle1
        End If

        If angle2 < 0 Then
            angle2 = 360 + angle2
        End If

        Dim distanceToZeroAngle1 As Single = 360 - angle1
        result = angle2 + distanceToZeroAngle1
        result = result Mod 360

        Return result
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-16 </date>
    ''' </author>
    ''' <summary>
    ''' Calculate minimum distance between two angle.
    ''' </summary>
    Public Shared Function GetMinimumDistanceAngle(ByVal angle1 As Single, ByVal angle2 As Single) As Single
        Dim result As Single

        Dim d1to2 As Single = GetDistanceAngle(angle1, angle2)
        Dim d2to1 As Single = GetDistanceAngle(angle2, angle1)
        If d1to2 < d2to1 Then
            result = d1to2
        Else
            result = d2to1
        End If

        Return result
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-20</date>
    ''' </author>
    ''' <summary>
    ''' Gets filter data from specifed list fo data.
    ''' </summary>
    ''' <param name="filter"></param>
    ''' <param name="listDataFilter"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFilter(ByVal filter As String, ByVal listDataFilter As ArrayList, ByVal isFilterMulti As Boolean) As ArrayList
        Dim result As New ArrayList
        Try
            If listDataFilter Is Nothing OrElse listDataFilter.Count = 0 Then
                Return result
            End If

            If String.IsNullOrEmpty(filter) Then
                result.AddRange(listDataFilter)
                Return result
            End If

            filter = filter.ToLower()
            For Each item As Object In listDataFilter
                If item IsNot Nothing Then
                    Dim strItem As String = item.ToString()
                    If Not String.IsNullOrEmpty(strItem) Then
                        If isFilterMulti Then
                            If strItem.ToLower().Contains(filter) Then
                                result.Add(item)
                            End If
                        Else
                            If strItem.ToLower() = filter Then
                                result.Add(item)
                            End If
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return result
    End Function
End Class
