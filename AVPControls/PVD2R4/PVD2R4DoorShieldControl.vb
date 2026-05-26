Imports AVPControls.AVPDataLib

Public Class PVD2R4DoorShieldControl

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-18</date>
    ''' </author>
    ''' <summary>
    ''' Generate DoorShield image of PVD2R4 chamber.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function GenerateControlImage() As System.Drawing.Bitmap
        Try
            ' Get caching image.
            'Dim imageName As String = Me.Status.ToString()
            'If Me.IsImageCached(imageName) Then
            '    Return Me.GetCachingImage(imageName)
            'End If

            ' Create new image if not exists in cache.
            Dim imgDoorShield As Bitmap
            Select Case Me.Status
                Case DisplayStatus.Off
                    imgDoorShield = My.Resources.Resources.PVD2R4_DoorShield_Close
                Case DisplayStatus.On
                    imgDoorShield = My.Resources.Resources.PVD2R4_DoorShield_Open
                Case Else
                    imgDoorShield = My.Resources.Resources.PVD2R4_DoorShield_Unknown
            End Select

            ' Add new image to cache.
            'Me.AddCachingImage(imageName, imgDoorShield)

            Return imgDoorShield
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return Nothing
    End Function

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.UseCachingRegion = True

    End Sub
End Class
