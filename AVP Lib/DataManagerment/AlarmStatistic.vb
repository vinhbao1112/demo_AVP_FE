Public Class AlarmMsgItem
    Public Msg As String = String.Empty
    Public Count As Integer = 1
    Public Percentage As Single = 0

    Public Sub New(ByVal strMsg As String)
        Msg = strMsg
    End Sub
End Class

Public Class AlarmMsgItems
    Public Class AlarmMsgComparer
        Implements IComparer

        ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
           Implements IComparer.Compare
            If (x.count < y.count) Then
                Return -1
            ElseIf (x.count > y.count) Then
                Return 1
            Else
                Return 0
            End If
        End Function 'IComparer.Compare

    End Class 'AlarmMsgComparer

    Private m_TotalMsg As Integer = 0
    Public ReadOnly Property TotalMsg() As Integer
        Get
            Return m_TotalMsg
        End Get
    End Property

    Private m_AlarmItems As ArrayList = New ArrayList
    Public Sub Add(ByVal strMsg As String)
        m_TotalMsg += 1
        For Each msg As AlarmMsgItem In m_AlarmItems
            If strMsg = msg.Msg Then
                msg.Count += 1
                Exit Sub
            End If
        Next
        m_AlarmItems.Add(New AlarmMsgItem(strMsg))
    End Sub

    Public Sub Sort()
        Dim myComparer = New AlarmMsgComparer()
        m_AlarmItems.Sort(myComparer)
    End Sub

    Public Sub Clear()
        m_AlarmItems.Clear()
        m_TotalMsg = 0
    End Sub

    Public Function Values() As ArrayList
        Dim arrList As ArrayList = New ArrayList
        For Each msg As AlarmMsgItem In m_AlarmItems
            arrList.Add(msg.Count)
        Next
        Return arrList
    End Function

    Private Sub UpdatePercentage()
        For Each msg As AlarmMsgItem In m_AlarmItems
            msg.Percentage = msg.Count * 100.0F / m_TotalMsg
        Next
    End Sub

    Public Function GetInstance() As AlarmMsgItems
        Dim instance As AlarmMsgItems = New AlarmMsgItems
        Dim item As AlarmMsgItem
        'UpdatePercentage()
        Sort()
        instance.m_TotalMsg = m_TotalMsg
        For Each msg As AlarmMsgItem In m_AlarmItems
            item = New AlarmMsgItem(msg.Msg)
            item.Count = msg.Count
            item.Percentage = msg.Percentage
            instance.m_AlarmItems.Add(item)
        Next

        Return instance
    End Function

    Public Function Msg(ByVal index As Integer) As AlarmMsgItem
        Return m_AlarmItems(index)
    End Function
End Class

