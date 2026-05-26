Imports AVPControls.AVPDataLib
Imports System.ComponentModel

''' <author>Hai Tran</author>
''' <date>2016-04-04</date>
''' <summary>
''' Represent load lock.
''' </summary>
''' <remarks></remarks>
Public Class LoadLockControl

#Region "Fields"

    Private _doorStatus As DisplayStatus = DisplayStatus.Off
    Private _cassettePresent As Boolean
    Private _waferPresent As Boolean
    Private _questionMarkVisible As Boolean
    Private _loadLockType As LoadLockName = LoadLockName.LoadLockA
    Private _checkWaferPresentHandler As CheckWaferPresentDelegate(Of String, Boolean)
    Private _pausedJobID As String = String.Empty

    ''' <author>Hai Tran</author>
    ''' <date>2016-04-04</date>
    ''' <summary>
    ''' Delegate function which is used to check wafer present in loadlock.
    ''' </summary>
    ''' <typeparam name="T">The name of loadlock.</typeparam>
    ''' <typeparam name="TResult">The value indicating whether the loadlock has present wafer.</typeparam>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Delegate Function CheckWaferPresentDelegate(Of T, TResult)(ByVal loadLockName As String) As Boolean

    ''' <author>Hai Tran</author>
    ''' <date>2016-04-04</date>
    ''' <summary>
    ''' Occurs when question mark is clicked.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event QuestionMarkClicked As EventHandler

    ''' <author>Hai Tran</author>
    ''' <date>2016-04-04</date>
    ''' <summary>
    ''' Occurs when cassette is present status changed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event CassettePresentChanged As EventHandler


#End Region

#Region "Properties"

    ''' <author>Hai Tran</author>
    ''' <date>2016-04-04</date>
    ''' <summary>
    ''' Gets or sets door status.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(DisplayStatus), "Off")> _
    Public Property DoorStatus() As DisplayStatus
        Get
            Return _doorStatus
        End Get
        Set(ByVal value As DisplayStatus)
            If _doorStatus <> value Then
                _doorStatus = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-04-04</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether the cassette is present in loadlock.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(False)> _
    Public Property CassettePresent() As Boolean
        Get
            Return _cassettePresent
        End Get
        Set(ByVal value As Boolean)
            If _cassettePresent <> value Then
                _cassettePresent = value

                ' Get wafer present from the assigned function when cassette is present.
                If _cassettePresent Then
                    _waferPresent = HasWaferPresent()
                End If

                UpdateView()

                RaiseEvent CassettePresentChanged(Me, EventArgs.Empty)
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-04-04</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether wafer is present in loadlock.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(False)> _
    Public Property WaferPresent() As Boolean
        Get
            Return (_waferPresent AndAlso _cassettePresent)
        End Get
        Set(ByVal value As Boolean)
            If _waferPresent <> value Then
                _waferPresent = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-04-04</date>
    ''' <summary>
    ''' Gets or sets a value indicating whether question mark is show on loadlock control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(False)> _
    Public Property QuestionMarkVisible() As Boolean
        Get
            Return _questionMarkVisible
        End Get
        Set(ByVal value As Boolean)
            If _questionMarkVisible <> value Then
                _questionMarkVisible = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-04-04</date>
    ''' <summary>
    ''' Gets or sets a value indicates type of loadlock.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(GetType(LoadLockName), "LoadLockA")> _
    Public Property LoadLockType() As LoadLockName
        Get
            Return _loadLockType
        End Get
        Set(ByVal value As LoadLockName)
            If _loadLockType <> value Then
                _loadLockType = value

                UpdateView()
            End If
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-04-04</date>
    ''' <summary>
    ''' Gets the rectangle that the question mark is shown in.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property QuestionMarkArea() As Rectangle
        Get
            If AVPStyle = AVPStyles.CX4 Then
                Return New Rectangle(64, 21, 19, 29)
            Else
                If LoadLockType = LoadLockName.LoadLockA Then
                    Return New Rectangle(7, 49, 19, 29)
                Else
                    Return New Rectangle(82, 49, 19, 29)
                End If
            End If
        End Get
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-04-04</date>
    ''' <summary>
    ''' Gets or sets the addredd of function which is used to check wafer present in loadlock.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CheckWaferPresentHandler() As CheckWaferPresentDelegate(Of String, Boolean)
        Get
            Return _checkWaferPresentHandler
        End Get
        Set(ByVal value As CheckWaferPresentDelegate(Of String, Boolean))
            _checkWaferPresentHandler = value
        End Set
    End Property

    ''' <author>Hai Tran</author>
    ''' <date>2016-04-04</date>
    ''' <summary>
    ''' Gets or sets JobID which is paused in loadlock.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PausedJobID() As String
        Get
            Return _pausedJobID
        End Get
        Set(ByVal value As String)
            _pausedJobID = value
        End Set
    End Property

#End Region

#Region "Methods"

    ''' <author>Hai Tran</author>
    ''' <date>2016-04-04</date>
    ''' <summary>
    ''' Create image of loadlock.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Try
            Dim loadLockImage As Bitmap = Nothing
            Dim cassetteImage As Bitmap = Nothing
            Dim cassetteWaferImage As Bitmap = Nothing
            Dim doorStatusImage As Bitmap = Nothing

            Dim cassetteLocation As Point
            Dim doorLocation As Point

            ' Gets loadlock images.
            If AVPStyle = AVPStyles.CX4 Then
                loadLockImage = My.Resources.LoadLock_CX4
                cassetteImage = My.Resources.LoadLock_CX4_Cassette
                cassetteWaferImage = My.Resources.LoadLock_CX4_Cassette_Wafer
                Select Case DoorStatus
                    Case DisplayStatus.Off
                        doorStatusImage = My.Resources.LoadLock_CX4_Door_Close
                    Case DisplayStatus.On
                        doorStatusImage = My.Resources.LoadLock_CX4_Door_Open
                    Case DisplayStatus.Error
                        doorStatusImage = My.Resources.LoadLock_CX4_Door_Error
                    Case Else
                        doorStatusImage = My.Resources.LoadLock_CX4_Door_Unknown
                End Select
                cassetteLocation = New Point(22, 3)
                doorLocation = New Point(1, 52)
            Else
                loadLockImage = My.Resources.LoadLock
                cassetteImage = My.Resources.Cassette
                cassetteWaferImage = My.Resources.Cassette_HasWafer
                Select Case DoorStatus
                    Case DisplayStatus.Off
                        doorStatusImage = My.Resources.LLDoor_Close
                    Case DisplayStatus.On
                        doorStatusImage = My.Resources.LLDoor_Open
                    Case DisplayStatus.Error
                        doorStatusImage = My.Resources.LLDoor_Error
                    Case Else
                        doorStatusImage = My.Resources.LLDoor_Unknown
                End Select
                cassetteLocation = New Point(29, 7)
                doorLocation = New Point(6, 80)
            End If

            ' Draw components to image.
            Using g As Graphics = Graphics.FromImage(loadLockImage)
                If WaferPresent Then
                    ' Draw cassette with wafer.
                    g.DrawImage(cassetteWaferImage, cassetteLocation)
                ElseIf CassettePresent Then
                    ' Draw cassette only.
                    g.DrawImage(cassetteImage, cassetteLocation)
                End If

                ' Draw door status.
                g.DrawImage(doorStatusImage, doorLocation)

                ' Flip image if loadlock B.
                If AVPStyle <> AVPStyles.CX4 AndAlso LoadLockType = LoadLockName.LoadLockB Then
                    'g.Flush()
                    loadLockImage.RotateFlip(RotateFlipType.RotateNoneFlipX)
                End If

                ' Draw question mark.
                If QuestionMarkVisible Then
                    Dim questionMarkImage As Bitmap = My.Resources.Question_Mark
                    g.DrawImage(questionMarkImage, QuestionMarkArea)
                    questionMarkImage.Dispose()
                End If

                ' Release resources.
                cassetteImage.Dispose()
                cassetteWaferImage.Dispose()
                doorStatusImage.Dispose()
            End Using

            Return loadLockImage
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    ''' <author>Hai Tran</author>
    ''' <date>2016-04-04</date>
    ''' <summary>
    ''' Check wafer present from the assigned function.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function HasWaferPresent() As Boolean
        Try
            If CheckWaferPresentHandler IsNot Nothing Then
                Return CheckWaferPresentHandler.Invoke(LoadLockType.ToString)
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return False
    End Function

#End Region

#Region "Events"

    ''' <author>Hai Tran</author>
    ''' <date>2016-04-04</date>
    ''' <summary>
    ''' Update cassette present when connection changed.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnConnectionChanged(ByVal e As System.EventArgs)
        Try
            Me.CassettePresent = Me.IsConnected
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try

        MyBase.OnConnectionChanged(e)
    End Sub

    '''' <author>Hai Tran</author>
    '''' <date>2016-04-04</date>
    '''' <summary>
    '''' Handler mouse click on question mark region for raise question mark clicked event.
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        Try
            Dim mouseEvent As MouseEventArgs = CType(e, MouseEventArgs)
            If QuestionMarkVisible AndAlso QuestionMarkArea.Contains(mouseEvent.Location) Then
                ' Raise Click event for QuestionMark and don't raise event for this control.
                RaiseEvent QuestionMarkClicked(Me, e)
                Exit Sub
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try

        MyBase.OnClick(e)
    End Sub

#End Region

End Class
