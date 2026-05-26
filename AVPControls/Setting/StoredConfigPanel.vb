''' <author>
'''     <name>Hai Tran</name>
'''     <date>2015-10-27</date>
''' </author>
''' <summary>
''' Panel to show saved data.
''' </summary>
''' <remarks></remarks>
Public Class StoredConfigPanel

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-27</date>
    ''' </author>
    Public Overridable Overloads Sub SetData(ByVal configItem As StoredConfigData)
        Try
            Me.ClearData()
            If configItem Is Nothing OrElse configItem.Data Is Nothing Then
                Return
            End If
            For Each key As String In configItem.Data.Keys
                Dim ctrls() As Control = Me.Controls.Find(key, False)
                If ctrls IsNot Nothing AndAlso ctrls.Length > 0 Then
                    Dim ctrl As Control = ctrls(0)
                    ctrl.Text = configItem.Data(key)
                End If
            Next
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-27</date>
    ''' </author>
    Public Overridable Overloads Sub SetData(ByVal configData As Dictionary(Of String, String))
        Try
            Me.ClearData()
            If configData Is Nothing Then
                Return
            End If
            For Each key As String In configData.Keys
                Dim ctrls() As Control = Me.Controls.Find(key, False)
                If ctrls IsNot Nothing AndAlso ctrls.Length > 0 Then
                    Dim ctrl As Control = ctrls(0)
                    ctrl.Text = configData(key)
                End If
            Next
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Tinh Le</name>
    '''     <date> 2020-04-23 </date>
    ''' </author>
    ''' <summary>
    '''  set back color
    ''' </summary>
    Public Overridable Overloads Sub SetBackColor()
        Try
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is TextBox Then
                    If ctrl.Name.Contains("APPLIC") OrElse ctrl.Name.Contains("R_REV") Then

                    Else
                        ctrl.BackColor = Color.White
                    End If
                End If
            Next
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

     ''' <author>
    '''     <name>Tinh Le</name>
    '''     <date> 2020-04-23 </date>
    ''' </author>
    ''' <summary>
    '''  set fore color
    ''' </summary>
    Public Overridable Overloads Sub SetForeColor()
        Try
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is TextBox Then
                    If ctrl.Name.Contains("APPLIC") OrElse ctrl.Name.Contains("R_REV") Then

                    Else
                        ctrl.ForeColor = Color.Black
                    End If
                End If
            Next
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-28</date>
    ''' </author>
    Public Overridable Function GetData() As StoredConfigData
        Dim result As New StoredConfigData
        Try
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is TextBox Then
                    result.Data.Add(ctrl.Name, ctrl.Text)
                End If
            Next
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return result
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-10-27</date>
    ''' </author>
    Public Overridable Sub ClearData()
        Try
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.Text = String.Empty
                End If
            Next
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-02</date>
    ''' </author>
    ''' <summary>
    ''' Set text of control by specified name.
    ''' </summary>
    Public Function SetControlText(ByVal name As String, ByVal text As String) As Boolean
        Dim success As Boolean
        Try
            Dim ctrls() As Control = Me.Controls.Find(name, False)
            If ctrls IsNot Nothing AndAlso ctrls.Length > 0 Then
                Dim ctrl As Control = ctrls(0)
                ctrl.Text = text
                success = True
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return success
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-11-02</date>
    ''' </author>
    ''' <summary>
    ''' Get text of control by specified name.
    ''' </summary>
    Public Function GetControlText(ByVal name As String) As String
        Dim text As String = Nothing
        Try
            Dim ctrls() As Control = Me.Controls.Find(name, False)
            If ctrls IsNot Nothing AndAlso ctrls.Length > 0 Then
                Dim ctrl As Control = ctrls(0)
                text = ctrl.Text
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return text
    End Function

End Class
