Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Public Class AVPGraphicsLib

#Region "Constants"
    Public Shared ALPHA_VALUE_TRANSPARENT As Byte = 85
    Public Shared BACK_COLOR As Color = Color.FromArgb(100, 150, 200)
    Private Const BORDER_3D_DOWN_WIDTH As Integer = 4
    Private Const BORDER_3D_UP_WIDTH As Integer = 6
#End Region

#Region "Make Region Control"

    ''' <summary>
    ''' Set background image and create region of specified control by specified bitmap.
    ''' </summary>
    ''' <param name="control">The Control to create region.</param>
    ''' <param name="bitmap">The bitmap use for create region and background.</param>
    ''' <remarks></remarks>
    Public Shared Sub CreateControlRegion(ByVal control As Control, ByVal bitmap As Bitmap)
        ' Return if control and bitmap are null
        If control Is Nothing OrElse bitmap Is Nothing Then
            Return
        End If

        ' Set our control's size to be the same as the bitmap
        control.Width = bitmap.Width
        control.Height = bitmap.Height
        ' Set bitmap as the background image
        control.BackgroundImage = bitmap

        ' Calculate the graphics path based on the bitmap supplied
        Dim graphicsPath As Drawing2D.GraphicsPath = GetGraphicsPath(bitmap)
        ' Apply new region
        control.Region = New Region(graphicsPath)
    End Sub

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Calculate the graphics path that representing the figure in the bitmap.
    ''' </summary>
    ''' <param name="bitmap">The image for create graphics path.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetGraphicsPath(ByVal bitmap As Bitmap) As Drawing2D.GraphicsPath
        Return GetGraphicsPath(bitmap, ALPHA_VALUE_TRANSPARENT)
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Calculate the graphics path that representing the figure in the bitmap.
    ''' </summary>
    ''' <param name="bitmap">The image for create graphics path.</param>
    ''' <param name="alphaValue">The alpha component value of pixel for remove from graphics path.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetGraphicsPath(ByVal bitmap As Bitmap, ByVal alphaValue As Byte) As Drawing2D.GraphicsPath

        ' Create GraphicsPath for our bitmap calculation
        Dim graphicsPath As New Drawing2D.GraphicsPath()

        If bitmap Is Nothing Then
            Return graphicsPath
        End If

        ' Alpha value for transparent, value from 0 to 255
        ' 128 indicates 50% opaque pixel will be remove from region
        Dim alphaValueForTransparent As Byte = alphaValue

        ' This is to store the column value where an opaque pixel is first found.
        ' This value will determine where we start scanning for trailing 
        ' opaque pixels.
        Dim colOpaquePixel As Integer = 0

        ' Go through all rows (Y axis)
        For row As Integer = 0 To bitmap.Height - 1
            ' Reset value
            colOpaquePixel = 0

            ' Go through all columns (X axis)
            For col As Integer = 0 To bitmap.Width - 1
                ' If this is an opaque pixel, mark it and search 
                ' for anymore trailing behind
                If bitmap.GetPixel(col, row).A > alphaValueForTransparent Then
                    ' Opaque pixel found, mark current position
                    colOpaquePixel = col

                    ' Create another variable to set the current pixel position
                    Dim colNext As Integer = col

                    ' Starting from current found opaque pixel, search for 
                    ' anymore opaque pixels trailing behind, until a transparent
                    ' pixel is found or minimum width is reached
                    For colNext = colOpaquePixel To bitmap.Width - 1
                        If bitmap.GetPixel(colNext, row).A <= alphaValueForTransparent Then
                            Exit For
                        End If
                    Next

                    ' Form a rectangle for line of opaque pixels found and 
                    ' add it to our graphics path
                    graphicsPath.AddRectangle(New Rectangle(colOpaquePixel, row, colNext - colOpaquePixel, 1))

                    ' No need to scan the line of opaque pixels just found
                    col = colNext
                End If
            Next
        Next

        ' Return calculated graphics path
        Return graphicsPath
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-25</date>
    ''' </author>
    ''' <summary>
    ''' Calculate the graphics path that representing the figure in the bitmap.
    ''' </summary>
    ''' <param name="img"></param>
    ''' <param name="backgroundColor"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function QuickCalculateGraphicsPath(ByVal img As Bitmap, ByVal backgroundColor As Color) As GraphicsPath
        Dim graphicsPath As New GraphicsPath()
        Try
            If img Is Nothing OrElse img.Width <= 0 OrElse img.Height <= 0 Then
                Return graphicsPath
            End If
            Dim numberOfByte As Integer = 4
            Dim startRegionArea As Integer = -1
            Dim bmp As Bitmap = New Bitmap(img)
            Try
                Dim bmpData As BitmapData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
                Try
                    ' Set start point of Pointer at first pixel.
                    Dim scanL As IntPtr = bmpData.Scan0

                    Dim p(numberOfByte - 1) As Byte
                    Dim width As Integer = bmp.Width
                    Dim height As Integer = bmp.Height
                    For y As Integer = 0 To height - 1
                        For x As Integer = 0 To width - 1
                            ' Copy value at pointer to array.
                            System.Runtime.InteropServices.Marshal.Copy(scanL, p, 0, numberOfByte)

                            Dim A As Byte = p(3)
                            Dim R As Byte = p(2)
                            Dim G As Byte = p(1)
                            Dim B As Byte = p(0)
                            Dim pixelColor As Color = Color.FromArgb(A, R, G, B)

                            If pixelColor = backgroundColor AndAlso startRegionArea <> -1 Then
                                graphicsPath.AddRectangle(New Rectangle(startRegionArea, y, x - startRegionArea, 1))
                                startRegionArea = -1
                            End If
                            If pixelColor <> backgroundColor AndAlso startRegionArea = -1 Then
                                startRegionArea = x
                            End If

                            ' Move pointer to next pixel.
                            scanL = IntPtr.Add(scanL, numberOfByte)
                        Next

                        ' Add the final piece if necessary.
                        If startRegionArea <> -1 Then
                            graphicsPath.AddRectangle(New Rectangle(startRegionArea, y, bmp.Width - startRegionArea, 1))
                            startRegionArea = -1
                        End If
                    Next
                Finally
                    bmp.UnlockBits(bmpData)
                End Try
            Finally
                bmp.Dispose()
            End Try
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return graphicsPath
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-25</date>
    ''' </author>
    ''' <summary>
    ''' Calculate the graphics path that representing the figure in the bitmap.
    ''' </summary>
    ''' <param name="img"></param>
    ''' <param name="alphaValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function QuickCalculateGraphicsPath(ByVal img As Bitmap, ByVal alphaValue As Byte) As GraphicsPath
        Dim graphicsPath As New GraphicsPath()
        Try
            If img Is Nothing OrElse img.Width <= 0 OrElse img.Height <= 0 Then
                Return graphicsPath
            End If
            Dim numberOfByte As Integer = 4
            Dim startRegionArea As Integer = -1
            Dim bmp As Bitmap = New Bitmap(img)
            Try
                Dim bmpData As BitmapData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
                Try
                    ' Set start point of Pointer at first Alpha components of pixel.
                    Dim scanL As IntPtr = IntPtr.Add(bmpData.Scan0, numberOfByte - 1)

                    Dim p(0) As Byte
                    Dim width As Integer = bmp.Width
                    Dim height As Integer = bmp.Height
                    For y As Integer = 0 To height - 1
                        For x As Integer = 0 To width - 1
                            ' Copy value at pointer to array.
                            System.Runtime.InteropServices.Marshal.Copy(scanL, p, 0, 1)

                            Dim A As Byte = p(0)
                            If A <= alphaValue AndAlso startRegionArea <> -1 Then
                                graphicsPath.AddRectangle(New Rectangle(startRegionArea, y, x - startRegionArea, 1))
                                startRegionArea = -1
                            End If
                            If A > alphaValue AndAlso startRegionArea = -1 Then
                                startRegionArea = x
                            End If

                            ' Move pointer to next Alpha component.
                            scanL = IntPtr.Add(scanL, numberOfByte)
                        Next

                        ' Add the final piece if necessary.
                        If startRegionArea <> -1 Then
                            graphicsPath.AddRectangle(New Rectangle(startRegionArea, y, width - startRegionArea, 1))
                            startRegionArea = -1
                        End If
                    Next
                Finally
                    bmp.UnlockBits(bmpData)
                End Try
            Finally
                bmp.Dispose()
            End Try
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return graphicsPath
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Get region from specified image.
    ''' </summary>
    ''' <param name="img">The bitmap for getting region.</param>
    ''' <returns>Region which get from image.</returns>
    ''' <remarks>Use for create region of control to match with image.</remarks>
    Public Overloads Shared Function GetRegion(ByVal img As Bitmap) As Region
        Return GetRegion(img, ALPHA_VALUE_TRANSPARENT)
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Get region from specified image.
    ''' </summary>
    ''' <param name="img">The bitmap for getting region.</param>
    ''' <param name="alphaValue">The alpha component value of pixel for remove from region.</param>
    ''' <returns>Region which get from image.</returns>
    ''' <remarks>Use for create region of control to match with image.</remarks>
    Public Overloads Shared Function GetRegion(ByVal img As Bitmap, ByVal alphaValue As Byte) As Region
        If img Is Nothing Then
            Return New Region()
        End If

        Dim graphicsPath As GraphicsPath = QuickCalculateGraphicsPath(img, alphaValue)

        Dim reg As Region = New Region(graphicsPath)

        graphicsPath.Dispose()
        graphicsPath = Nothing

        Return reg
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-24</date>
    ''' </author>
    ''' <summary>
    ''' Get region from specified image.
    ''' </summary>
    ''' <param name="img">The bitmap for getting region.</param>
    ''' <param name="bgColor">The color of pixel for remove from region.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetRegion(ByVal img As Bitmap, ByVal bgColor As Color) As Region
        If img Is Nothing Then
            Return New Region()
        End If

        Dim graphicsPath As GraphicsPath = QuickCalculateGraphicsPath(img, bgColor)
        Dim reg As Region = New Region(graphicsPath)
        graphicsPath.Dispose()
        Return reg
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Tests whether the specified System.Drawing.Region is null or empty on specified drawing surface.
    ''' </summary>
    ''' <param name="region">The System.Drawing.Region to test.</param>
    ''' <param name="g">A System.Drawing.Graphics that represents a drawing surface.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsRegionNullOrEmpty(ByVal region As Region, ByVal g As Graphics) As Boolean
        Dim result As Boolean
        Try
            If region Is Nothing Then
                result = True
            Else
                result = region.IsEmpty(g)
            End If
        Catch ex As Exception
            Return True
        End Try
        Return result
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-09-11</date>
    ''' </author>
    ''' <summary>
    ''' Tests whether the two specified System.Drawing.Region(s) are equal on specified drawing surface.
    ''' </summary>
    ''' <param name="region1">The first System.Drawing.Region to test.</param>
    ''' <param name="region2">The second System.Drawing.Region to test.</param>
    ''' <param name="g">A System.Drawing.Graphics that represents a drawing surface.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsRegionsEquals(ByVal region1 As Region, ByVal region2 As Region, ByVal g As Graphics) As Boolean
        Dim result As Boolean
        Try
            If region1 Is Nothing OrElse region2 Is Nothing Then
                result = False
            Else
                result = region1.Equals(region2, g)
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return result
    End Function

#End Region

#Region "Drawing Image"
    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-11 </date>
    ''' </author>
    ''' <summary>
    ''' Rotate image at center point which don't change size of image.
    ''' </summary>
    ''' <param name="img">The System.Drawing.Bitmap to rotate.</param>
    ''' <param name="angle">The number that represents angle for rotating.</param>
    ''' <returns>The System.Drawing.Bitmap which is rotated.</returns>
    Public Overloads Shared Function RotateImage(ByVal img As Bitmap, ByVal angle As Single) As Bitmap
        If img Is Nothing Then
            Return Nothing
        End If

        Dim result As Bitmap = Nothing

        Try
            Dim width As Integer = img.Width
            Dim height As Integer = img.Height
            result = New Bitmap(width, height)
            result.SetResolution(img.HorizontalResolution, img.VerticalResolution)

            Dim centerPoint As PointF = New PointF(width / 2.0F, height / 2.0F)
            Dim rotateCenterMatrix As New Drawing2D.Matrix
            rotateCenterMatrix.RotateAt(angle, centerPoint)

            Dim g As Graphics = Graphics.FromImage(result)
            g.Transform = rotateCenterMatrix
            g.DrawImageUnscaled(img, 0, 0)

            centerPoint = Nothing
            rotateCenterMatrix.Dispose()
            g.Dispose()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try

        Return result
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-17 </date>
    ''' </author>
    ''' <summary>
    ''' Rotate image at center point with the specified value indicating whether the size of image is changed.
    ''' </summary>
    ''' <param name="img">The System.Drawing.Bitmap to rotate.</param>
    ''' <param name="angle">The number that represents angle for rotating.</param>
    ''' <param name="sizeIsFixed">The value indicating whether the size of image is changed.</param>
    ''' <returns>The System.Drawing.Bitmap which is rotated.</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function RotateImage(ByVal img As Bitmap, ByVal angle As Single, ByVal sizeIsFixed As Boolean) As Bitmap
        If sizeIsFixed Then
            Return RotateImage(img, angle)
        End If

        If img Is Nothing Then
            Return Nothing
        End If

        Dim result As Bitmap = Nothing

        Try
            Dim width As Integer = img.Width
            Dim height As Integer = img.Height
            Dim size As Integer = CInt(Math.Sqrt(width * width + height * height))
            result = New Bitmap(size, size)
            result.SetResolution(img.HorizontalResolution, img.VerticalResolution)

            Dim centerPoint As PointF = New PointF(size / 2.0F, size / 2.0F)
            Dim rotateCenterMatrix As New Drawing2D.Matrix
            rotateCenterMatrix.RotateAt(angle, centerPoint)

            Dim g As Graphics = Graphics.FromImage(result)
            g.Transform = rotateCenterMatrix
            g.DrawImageUnscaled(img, CInt((size - width) / 2.0F), CInt((size - height) / 2.0F))

            centerPoint = Nothing
            rotateCenterMatrix.Dispose()
            g.Dispose()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try

        Return result
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-11 </date>
    ''' </author>
    ''' <summary>
    ''' Cut-out specified image by the specified graphics path.
    ''' </summary>
    ''' <param name="img">The System.Drawing.Bitmap to cut-out.</param>
    ''' <param name="cutoutPath">The System.Drawing2D.GraphicsPath to cut-out from specified image.</param>
    ''' <returns>The System.Drawing.Bitmap which is cut-out.</returns>
    Public Overloads Shared Function CutoutImage(ByVal img As Bitmap, ByVal cutoutPath As Drawing2D.GraphicsPath) As Bitmap
        If img Is Nothing Then
            Return Nothing
        End If

        Dim result As Bitmap = Nothing

        Try
            result = New Bitmap(img.Width, img.Height)
            result.SetResolution(img.HorizontalResolution, img.VerticalResolution)

            Dim g As Graphics = Graphics.FromImage(result)
            g.SetClip(cutoutPath, Drawing2D.CombineMode.Exclude)
            g.DrawImageUnscaled(img, 0, 0)

            g.Dispose()
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try

        Return result
    End Function

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-17 </date>
    ''' </author>
    ''' <summary>
    ''' Draw border 3D style to specified bitmap with specified border width.
    ''' </summary>
    ''' <param name="img">The System.Drawing.Bitmap to draw border.</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub DrawBorder3D(ByRef img As Bitmap)
        Try
            If img IsNot Nothing Then
                Dim g As Graphics = Graphics.FromImage(img)
                AVPGraphicsLib.DrawBorder3D(g, img.Width, img.Height)
                g.Dispose()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-17 </date>
    ''' </author>
    ''' <summary>
    ''' Draw border 3D style to specified graphics with specified border width.
    ''' </summary>
    ''' <param name="g">The Graphics to draw border.</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub DrawBorder3D(ByRef g As Graphics)
        Try
            If g IsNot Nothing Then
                DrawBorder3D(g, CInt(g.VisibleClipBounds.Width), CInt(g.VisibleClipBounds.Height))
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-07 </date>
    ''' </author>
    ''' <summary>
    ''' Draw border 3D style to specified graphics with specified border width.
    ''' </summary>
    ''' <param name="g">The Graphics to draw border.</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub DrawBorder3D(ByRef g As Graphics, ByVal width As Integer, ByVal height As Integer)
        DrawBorder3D(g, 0, 0, width, height, Color.Black, Color.Transparent)
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-07 </date>
    ''' </author>
    ''' <summary>
    ''' Draw border 3D style to specified graphics with specified border width.
    ''' </summary>
    ''' <param name="g">The Graphics to draw border.</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub DrawBorder3D(ByRef g As Graphics, ByVal width As Integer, ByVal height As Integer, ByVal borderColor As Color)
        DrawBorder3D(g, 0, 0, width, height, borderColor, Color.Transparent)
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-07 </date>
    ''' </author>
    ''' <summary>
    ''' Draw border 3D style to specified graphics with specified border width.
    ''' </summary>
    ''' <param name="g">The Graphics to draw border.</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub DrawBorder3D(ByRef g As Graphics, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal borderColor As Color, ByVal backBorderColor As Color)
        Try
            If g IsNot Nothing Then
                Dim alphaValue As Byte = 128
                Dim color As Color
                Dim pen As Pen

                ' Draw back color of border.
                If backBorderColor <> Drawing.Color.Transparent Then
                    pen = New Pen(backBorderColor)
                    For index As Integer = 0 To BORDER_3D_UP_WIDTH - 1
                        g.DrawRectangle(pen, x + index, y + index, width - index * 2 - 1 - x, height - index * 2 - 1 - y)
                    Next
                    pen.Dispose()
                End If

                ' Draw border.
                For index As Integer = 0 To BORDER_3D_UP_WIDTH - 1
                    color = Drawing.Color.FromArgb(alphaValue, borderColor)
                    pen = New Pen(color)
                    g.DrawRectangle(pen, x + index, y + index, width - index * 2 - 1 - x, height - index * 2 - 1 - y)
                    alphaValue = CByte(alphaValue * 0.6)
                    pen.Dispose()
                Next

                color = Nothing
                pen = Nothing
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-07 </date>
    ''' </author>
    ''' <summary>
    ''' Draw border 3D style to specified graphics with specified border width.
    ''' </summary>
    ''' <param name="g">The Graphics to draw border.</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub DrawBorder3DDown(ByRef g As Graphics, ByVal width As Integer, ByVal height As Integer, ByVal borderColor As Color)
        DrawBorder3DDown(g, 0, 0, width, height, borderColor, Color.Transparent)
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-07 </date>
    ''' </author>
    ''' <summary>
    ''' Draw border 3D style to specified graphics with specified border width.
    ''' </summary>
    ''' <param name="g">The Graphics to draw border.</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub DrawBorder3DDown(ByRef g As Graphics, ByVal width As Integer, ByVal height As Integer, ByVal borderColor As Color, ByVal backBorderColor As Color)
        DrawBorder3DDown(g, 0, 0, width, height, borderColor, backBorderColor)
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-07 </date>
    ''' </author>
    ''' <summary>
    ''' Draw border 3D style to specified graphics with specified border width.
    ''' </summary>
    Public Overloads Shared Sub DrawBorder3DDown(ByRef g As Graphics, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal borderColor As Color, ByVal backBorderColor As Color)
        Try
            If g IsNot Nothing Then
                Dim alphaValue As Byte = 35
                Dim color As Color
                Dim pen As Pen
                Dim index As Integer

                ' Draw back color of border.
                If backBorderColor <> Drawing.Color.Transparent Then
                    pen = New Pen(backBorderColor)
                    For index = 0 To BORDER_3D_DOWN_WIDTH - 1
                        g.DrawRectangle(pen, x + index, y + index, width - index * 2 - 1 - x, height - index * 2 - 1 - y)
                    Next
                    pen.Dispose()
                End If

                ' Draw border.
                index = 0
                While index < BORDER_3D_DOWN_WIDTH
                    color = Drawing.Color.FromArgb(alphaValue, borderColor)
                    pen = New Pen(color)
                    g.DrawRectangle(pen, x + index, y + index, width - index * 2 - 1 - x, height - index * 2 - 1 - y)
                    alphaValue = CByte(alphaValue * 1.3)
                    index += 1
                    pen.Dispose()
                End While

                color = Drawing.Color.FromArgb(35, borderColor)
                pen = New Pen(color)
                g.DrawRectangle(pen, x + index, y + index, width - index * 2 - 1 - x, height - index * 2 - 1 - y)

                color = Nothing
                pen.Dispose()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-10-07 </date>
    ''' </author>
    ''' <summary>
    ''' Draw border 3D style to specified graphics with specified border width.
    ''' </summary>
    ''' <param name="g">The Graphics to draw border.</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub DrawBorder3DDown(ByRef g As Graphics, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal borderColor As Color)
        DrawBorder3DDown(g, x, y, width, height, borderColor, Color.Transparent)
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-17 </date>
    ''' </author>
    ''' <summary>
    ''' Draw border down direction to specified bitmap.
    ''' </summary>
    ''' <param name="img">The System.Drawing.Bitmap to draw border.</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub DrawBorderDown(ByRef img As Bitmap)
        Try
            If img IsNot Nothing Then
                Dim width As Integer = img.Width
                Dim height As Integer = img.Height
                Dim g As Graphics = Graphics.FromImage(img)
                Dim alphaValue As Byte = 128
                Dim index As Integer = 0
                Dim color As Color = Drawing.Color.FromArgb(alphaValue, 0, 0, 0)
                Dim pen As Pen = New Pen(color)
                g.DrawRectangle(pen, 0, 0, width - 1, height - 1)
                alphaValue = 30
                For index = 1 To 8
                    color = Drawing.Color.FromArgb(alphaValue, 0, 0, 0)
                    pen.Dispose()
                    pen = New Pen(color)
                    g.DrawRectangle(pen, index, index, width - index * 2 - 1, height - index * 2 - 1)
                    alphaValue = CByte(alphaValue * 0.8)
                Next
                color = Drawing.Color.FromArgb(alphaValue, 0, 0, 0)
                Dim brush As SolidBrush = New SolidBrush(color)
                g.FillRectangle(brush, index, index, width - index * 2, height - index * 2)

                pen.Dispose()
                brush.Dispose()
                color = Nothing
                g.Dispose()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-18 </date>
    ''' </author>
    ''' <summary>
    ''' Draw border down direction to specified Graphics.
    ''' </summary>
    ''' <param name="g">The Graphics to draw border.</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub DrawBorderDown(ByRef g As Graphics)
        Try
            If g IsNot Nothing Then
                Dim w As Integer = CInt(g.VisibleClipBounds.Width)
                Dim h As Integer = CInt(g.VisibleClipBounds.Height)
                Dim alphaValue As Byte = 128
                Dim index As Integer = 0
                Dim color As Color = Drawing.Color.FromArgb(alphaValue, 0, 0, 0)
                Dim pen As Pen = New Pen(color)
                g.DrawRectangle(pen, 0, 0, w - 1, h - 1)
                alphaValue = 30
                For index = 1 To 8
                    color = Drawing.Color.FromArgb(alphaValue, 0, 0, 0)
                    pen.Dispose()
                    pen = New Pen(color)
                    g.DrawRectangle(pen, index, index, w - index * 2 - 1, h - index * 2 - 1)
                    alphaValue = CByte(alphaValue * 0.8)
                Next
                color = Drawing.Color.FromArgb(alphaValue, 0, 0, 0)
                Dim brush As SolidBrush = New SolidBrush(color)
                g.FillRectangle(brush, index, index, w - index * 2, h - index * 2)

                pen.Dispose()
                brush.Dispose()
                color = Nothing
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-18 </date>
    ''' </author>
    ''' <summary>
    ''' Draw to specified Graphics with disable surface.
    ''' </summary>
    ''' <param name="g">The Graphics to draw disable surface.</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub DrawDisable(ByRef g As Graphics)
        Try
            If g IsNot Nothing Then
                Dim color As Color = Drawing.Color.FromArgb(50, 128, 128, 128)
                Dim brush As SolidBrush = New SolidBrush(color)
                g.FillRegion(brush, g.Clip)
                brush.Dispose()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>
    '''     <name> Hai Tran </name>
    '''     <date> 2015-09-18 </date>
    ''' </author>
    ''' <summary>
    ''' Draw to specified image with disable surface.
    ''' </summary>
    ''' <param name="img">The Bitmap to draw disable surface.</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub DrawDisable(ByRef img As Bitmap)
        Try
            If img IsNot Nothing Then
                Dim g As Graphics = Graphics.FromImage(img)
                AVPGraphicsLib.DrawDisable(g)
                g.Dispose()
            End If
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-06-13</date>
    ''' <summary>
    ''' Draw rounded rectangle.
    ''' </summary>
    ''' <param name="objGraphics"></param>
    ''' <param name="xAxis"></param>
    ''' <param name="yAxis"></param>
    ''' <param name="width"></param>
    ''' <param name="height"></param>
    ''' <param name="diameter"></param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub DrawRoundedRectangle(ByVal objGraphics As Graphics, _
                                    ByVal xAxis As Integer, _
                                    ByVal yAxis As Integer, _
                                    ByVal width As Integer, _
                                    ByVal height As Integer, _
                                    ByVal diameter As Integer, _
                                    ByVal pen As Pen)

        Dim mode As SmoothingMode = objGraphics.SmoothingMode
        objGraphics.SmoothingMode = SmoothingMode.AntiAlias

        'Dim g As Graphics
        Dim baseRect As New RectangleF(xAxis, yAxis, width, height)
        Dim arcRect As New RectangleF(baseRect.Location, New SizeF(diameter, diameter))

        'top left Arc
        objGraphics.DrawArc(pen, arcRect, 180, 90)
        objGraphics.DrawLine(pen, xAxis + diameter / 2.0F, yAxis, xAxis + width - diameter / 2.0F, yAxis)

        ' top right arc
        arcRect.X = baseRect.Right - diameter
        objGraphics.DrawArc(pen, arcRect, 270, 90)
        objGraphics.DrawLine(pen, xAxis + width, yAxis + diameter / 2.0F, xAxis + width, yAxis + height - diameter / 2.0F)

        ' bottom right arc
        arcRect.Y = baseRect.Bottom - diameter
        objGraphics.DrawArc(pen, arcRect, 0, 90)
        objGraphics.DrawLine(pen, xAxis + diameter / 2.0F, yAxis + height, xAxis + width - diameter / 2.0F, yAxis + height)

        ' bottom left arc
        arcRect.X = baseRect.Left
        objGraphics.DrawArc(pen, arcRect, 90, 90)
        objGraphics.DrawLine(pen, xAxis, yAxis + diameter / 2.0F, xAxis, yAxis + height - diameter / 2.0F)

        objGraphics.SmoothingMode = mode
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-06-13</date>
    ''' <summary>
    ''' Draw rounded rectangle.
    ''' </summary>
    ''' <param name="objGraphics"></param>
    ''' <param name="rect"></param>
    ''' <param name="diameter"></param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub DrawRoundedRectangle(ByVal objGraphics As Graphics, ByVal rect As Rectangle, ByVal diameter As Integer, ByVal pen As Pen)
        DrawRoundedRectangle(objGraphics, rect.X, rect.Y, rect.Width, rect.Height, diameter, pen)
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-06-13</date>
    ''' <summary>
    ''' Fill rounded rectangle.
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="rect"></param>
    ''' <param name="diameter"></param>
    ''' <param name="brush"></param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub FillRoundedRectangle(ByVal g As Drawing.Graphics, ByVal rect As Rectangle, ByVal diameter As Integer, ByVal brush As Brush)
        Dim mode As Drawing2D.SmoothingMode = g.SmoothingMode
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed

        g.FillPie(brush, rect.X, rect.Y, diameter, diameter, 180, 90)
        g.FillPie(brush, rect.X + rect.Width - diameter, rect.Y, diameter, diameter, 270, 90)
        g.FillPie(brush, rect.X, rect.Y + rect.Height - diameter, diameter, diameter, 90, 90)
        g.FillPie(brush, rect.X + rect.Width - diameter, rect.Y + rect.Height - diameter, diameter, diameter, 0, 90)

        g.FillRectangle(brush, rect.X + diameter / 2.0F, rect.Y, rect.Width - diameter, diameter / 2.0F)
        g.FillRectangle(brush, rect.X, rect.Y + diameter / 2.0F, rect.Width, rect.Height - diameter)
        g.FillRectangle(brush, rect.X + diameter / 2.0F, rect.Y + rect.Height - diameter / 2.0F, rect.Width - diameter, diameter / 2.0F)

        g.SmoothingMode = mode
    End Sub

    ''' <author>Hai Tran</author>
    ''' <date>2018-06-13</date>
    ''' <summary>
    ''' Fill rounded rectangle.
    ''' </summary>
    ''' <param name="g"></param>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="width"></param>
    ''' <param name="height"></param>
    ''' <param name="diameter"></param>
    ''' <param name="brush"></param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub FillRoundedRectangle(ByVal g As Graphics, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal diameter As Integer, ByVal brush As Brush)
        FillRoundedRectangle(g, New Rectangle(x, y, width, height), diameter, brush)
    End Sub

#End Region

#Region "Measure String"
    Public Overloads Shared Function GetFittedText(ByVal text As String, ByVal obj As Control) As String
        If String.IsNullOrEmpty(text) OrElse obj Is Nothing OrElse obj.IsDisposed Then
            Return text
        End If

        Dim result As String = String.Empty
        Try
            Dim strFormat As StringFormat = New StringFormat(StringFormatFlags.NoWrap)
            Dim charCount As Integer
            Dim lineCount As Integer

            ' Measure text.
            Dim g As Graphics = obj.CreateGraphics
            g.MeasureString(text, obj.Font, New SizeF(obj.Width, obj.Height), strFormat, charCount, lineCount)

            ' Get fitted text.
            If charCount < text.Length AndAlso charCount > 3 Then
                result = text.Substring(0, charCount - 3) & "..."
            Else
                result = text
            End If

            ' Release resources.
            strFormat.Dispose()
            g.Dispose()

        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return result
    End Function

    ''' <author>
    '''     <name>Hai Tran</name>
    '''     <date>2015-12-17</date>
    ''' </author>
    ''' <summary>
    ''' Gets text which fit to the specified control.
    ''' </summary>
    ''' <param name="text"></param>
    ''' <param name="obj"></param>
    ''' <param name="isFitted"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function GetFittedText(ByVal text As String, ByVal obj As Control, ByRef isFitted As Boolean) As String
        Try
            Dim result As String = AVPGraphicsLib.GetFittedText(text, obj)
            isFitted = (result = text)
            Return result
        Catch ex As Exception
            Logger.Error(ex.ToString())
        End Try
        Return text
    End Function

#End Region

End Class
