Public Class ImgView

    ' Class-level variables for cropping
    Private cropX As Integer
    Private cropY As Integer
    Private cropWidth As Integer
    Private cropHeight As Integer
    Private cropPen As Pen
    Private cropPenColor As Color = Color.Blue
    Private cropBitmap As Bitmap
    Private isCropping As Boolean = False

    ' Class-level variables for undo functionality
    Private originalImage As Image
    Private undoStack As New Stack(Of Image)

    ' Class-level variables for pan/zoom
    Private panStartPoint As Point
    Private imageOffset As Point = Point.Empty
    Private isPanning As Boolean = False
    Private zoomFactor As Double = 1.0
    Private Const ZOOM_STEP As Double = 1.1

    ' Universal startup parameters for future extensibility
    Public Property StartupParameters As New Dictionary(Of String, Object)()

    ' Public method to load an image file
    Public Sub LoadImage(ByVal filePath As String)
        If IO.File.Exists(filePath) Then
            Try
                originalImage = Image.FromFile(filePath)
                PictureBox1.Image = originalImage
                PictureBox1.SizeMode = PictureBoxSizeMode.Normal
                Me.Text = filePath & " - ImgView"
                undoStack.Clear()
                undoStack.Push(originalImage)
                zoomFactor = 1.0
                imageOffset = Point.Empty
                PictureBox1.Refresh()
            Catch ex As Exception
                MessageBox.Show("Could not load image: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub ImgView_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Initialize the cropPen
        cropPen = New Pen(cropPenColor, 1)
        cropPen.DashStyle = Drawing2D.DashStyle.DashDotDot
        AddHandler PictureBox1.MouseWheel, AddressOf PictureBox1_MouseWheel
        ' Universal startup: load file if provided
        If StartupParameters IsNot Nothing AndAlso StartupParameters.ContainsKey("FilePath") Then
            Dim filePath As String = CStr(StartupParameters("FilePath"))
            LoadImage(filePath)
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFromKernel()
    End Sub

    Private Sub CloseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem1.Click
        Me.Close()
    End Sub

    ' Rotate Right
    Private Sub ToolStripSplitButton1_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton1.ButtonClick
        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            PictureBox1.Refresh()
            undoStack.Push(CType(PictureBox1.Image.Clone(), Image))
            zoomFactor = 1.0
            imageOffset = Point.Empty
            PictureBox1.Refresh()
        End If
    End Sub

    ' Rotate Left
    Private Sub ToolStripSplitButton2_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton2.ButtonClick
        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            PictureBox1.Refresh()
            undoStack.Push(CType(PictureBox1.Image.Clone(), Image))
            zoomFactor = 1.0
            imageOffset = Point.Empty
            PictureBox1.Refresh()
        End If
    End Sub

    ' Zoom In
    Private Sub ToolStripSplitButton3_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton3.ButtonClick
        If PictureBox1.Image IsNot Nothing Then
            Dim oldZoom = zoomFactor
            zoomFactor *= ZOOM_STEP
            CenterImageOnZoom(oldZoom)
            PictureBox1.Refresh()
        End If
    End Sub

    ' Zoom Out
    Private Sub ToolStripSplitButton4_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton7.ButtonClick
        If PictureBox1.Image IsNot Nothing Then
            Dim oldZoom = zoomFactor
            zoomFactor /= ZOOM_STEP
            If zoomFactor < 0.1 Then zoomFactor = 0.1
            CenterImageOnZoom(oldZoom)
            PictureBox1.Refresh()
        End If
    End Sub

    ' Reset Zoom
    Private Sub ToolStripSplitButton5_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton5.ButtonClick
        If PictureBox1.Image IsNot Nothing Then
            zoomFactor = 1.0
            imageOffset = Point.Empty
            PictureBox1.Refresh()
        End If
    End Sub

    ' Start Cropping
    Private Sub CropButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CropButton.ButtonClick
        isCropping = True
    End Sub

    ' Reset Image
    Private Sub ResetButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ResetButton.Click, ResetButton.ButtonClick
        PictureBox1.Image = originalImage
        undoStack.Clear()
        undoStack.Push(originalImage)
        zoomFactor = 1.0
        imageOffset = Point.Empty
        PictureBox1.Refresh()
    End Sub

    ' Undo Action
    Private Sub UndoButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles UndoButton.Click, UndoButton.ButtonClick
        If undoStack.Count > 1 Then
            undoStack.Pop()
            PictureBox1.Image = undoStack.Peek()
            zoomFactor = 1.0
            imageOffset = Point.Empty
            PictureBox1.Refresh()
        End If
    End Sub

    ' Mouse Down Event for Cropping
    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseDown
        ' To import a cursor from My.Resources (assuming grab is a .cur or .ani file in resources):
        Dim grabbingCursor As Cursor = New Cursor(New System.IO.MemoryStream(CType(My.Resources.grab, Byte())))
        If isCropping Then
            cropX = e.X
            cropY = e.Y
            cropPen = New Pen(cropPenColor, 1)
            cropPen.DashStyle = Drawing2D.DashStyle.DashDotDot
            Cursor = Cursors.Cross
        ElseIf PictureBox1.Image IsNot Nothing AndAlso e.Button = MouseButtons.Left Then
            isPanning = True
            panStartPoint = e.Location
            Cursor = grabbingCursor
        End If
    End Sub

    ' Mouse Move Event for Cropping
    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseMove
        If isCropping Then
            PictureBox1.Refresh()
            cropWidth = e.X - cropX
            cropHeight = e.Y - cropY
            PictureBox1.CreateGraphics.DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight)
        ElseIf isPanning AndAlso PictureBox1.Image IsNot Nothing Then
            Dim dx = e.X - panStartPoint.X
            Dim dy = e.Y - panStartPoint.Y
            imageOffset.X += dx
            imageOffset.Y += dy
            panStartPoint = e.Location
            PictureBox1.Refresh()
        End If
    End Sub

    ' Mouse Up Event for Cropping
    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseUp
        If isCropping Then
            isCropping = False
            If cropWidth < 1 Then Return
            Dim rect As New Rectangle(CInt((cropX - imageOffset.X) / zoomFactor), CInt((cropY - imageOffset.Y) / zoomFactor), CInt(cropWidth / zoomFactor), CInt(cropHeight / zoomFactor))
            Dim bitMap As New Bitmap(PictureBox1.Image)
            cropBitmap = New Bitmap(rect.Width, rect.Height)
            Dim g As Graphics = Graphics.FromImage(cropBitmap)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(bitMap, 0, 0, rect, GraphicsUnit.Pixel)
            PictureBox1.Image = cropBitmap
            undoStack.Push(cropBitmap)
            Cursor = Cursors.Default
            zoomFactor = 1.0
            imageOffset = Point.Empty
            PictureBox1.Refresh()
        ElseIf isPanning Then
            isPanning = False
            Cursor = Cursors.Default
        End If
    End Sub

    ' Mouse Wheel for zooming
    Private Sub PictureBox1_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseWheel
        If PictureBox1.Image Is Nothing Then Return
        Dim oldZoom = zoomFactor
        If e.Delta > 0 Then
            zoomFactor *= ZOOM_STEP
        ElseIf e.Delta < 0 Then
            zoomFactor /= ZOOM_STEP
        End If
        If zoomFactor < 0.1 Then zoomFactor = 0.1
        ' Zoom at mouse position
        Dim mouseX = e.X - imageOffset.X
        Dim mouseY = e.Y - imageOffset.Y
        imageOffset.X = CInt(e.X - mouseX * (zoomFactor / oldZoom))
        imageOffset.Y = CInt(e.Y - mouseY * (zoomFactor / oldZoom))
        PictureBox1.Refresh()
    End Sub

    ' Override Paint to draw image with pan/zoom
    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles PictureBox1.Paint
        If PictureBox1.Image IsNot Nothing Then
            e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            e.Graphics.Clear(PictureBox1.BackColor)
            Dim imgW = CInt(PictureBox1.Image.Width * zoomFactor)
            Dim imgH = CInt(PictureBox1.Image.Height * zoomFactor)
            e.Graphics.DrawImage(PictureBox1.Image, imageOffset.X, imageOffset.Y, imgW, imgH)
        End If
    End Sub

    ' Helper to center image on zoom
    Private Sub CenterImageOnZoom(ByVal oldZoom As Double)
        If PictureBox1.Image Is Nothing Then Return
        Dim centerX = PictureBox1.Width \ 2
        Dim centerY = PictureBox1.Height \ 2
        Dim mouseX = centerX - imageOffset.X
        Dim mouseY = centerY - imageOffset.Y
        imageOffset.X = CInt(centerX - mouseX * (zoomFactor / oldZoom))
        imageOffset.Y = CInt(centerY - mouseY * (zoomFactor / oldZoom))
    End Sub

    Private Sub CropButton_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CloseToolStripMenuItem1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem1.MouseLeave

    End Sub
    Private Sub CloseToolStripMenuItem1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem1.MouseEnter

    End Sub
    Private Sub ToolStripSplitButton6_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton6.ButtonClick

    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    ' Open handler for ImgView, using FileLoadDialog restricted to Kernel
    Private Sub OpenFromKernel()
        Dim kernelPath As String = IO.Path.Combine(Application.StartupPath, "Kernel")
        Dim dlg As New FileLoadDialog(kernelPath)
        dlg.AvailableFilters = New List(Of String)({"All Files", "Images (*.png;*.jpg;*.jpeg)"})
        dlg.DefaultFilter = "Images (*.png;*.jpg;*.jpeg)"
        If dlg.ShowDialog(Me) = DialogResult.OK Then
            Dim filePath As String = dlg.SelectedFile
            If IO.File.Exists(filePath) Then
                Dim ext As String = IO.Path.GetExtension(filePath).ToLower()
                If ext = ".png" Or ext = ".jpg" Or ext = ".jpeg" Then
                    LoadImage(filePath)
                Else
                    MessageBox.Show("Unsupported file type for ImgView.")
                    Return
                End If
            Else
                MessageBox.Show("File does not exist.")
            End If
        End If
    End Sub

    ' Save As handler for ImgView, using FileSaveDialog restricted to Kernel
    Private Sub SaveAsToKernel()
        Dim kernelPath As String = IO.Path.Combine(Application.StartupPath, "Kernel")
        Dim dlg As New FileSaveDialog(kernelPath)
        dlg.AvailableFormats = New List(Of String)({"png", "jpg", "jpeg"})
        ' Set default format based on current file or default to png
        Dim ext As String = "png"
        If Me.Text.Contains(".") Then
            ext = IO.Path.GetExtension(Me.Text).ToLower().TrimStart("."c)
        End If
        If ext = "png" Or ext = "jpg" Or ext = "jpeg" Then
            dlg.SelectedFormat = ext
        Else
            dlg.SelectedFormat = "png"
        End If
        If dlg.ShowDialog(Me) = DialogResult.OK Then
            Dim savePath As String = IO.Path.Combine(dlg.SelectedFolder, dlg.FileName)
            Dim format As String = dlg.SelectedFormat.ToLower()
            Try
                If format = "png" Then
                    PictureBox1.Image.Save(savePath, Imaging.ImageFormat.Png)
                ElseIf format = "jpg" Or format = "jpeg" Then
                    ' Flatten to white for JPEG
                    Dim bmp As New Bitmap(PictureBox1.Image.Width, PictureBox1.Image.Height, Imaging.PixelFormat.Format24bppRgb)
                    Using g As Graphics = Graphics.FromImage(bmp)
                        g.Clear(Color.White)
                        g.DrawImage(PictureBox1.Image, 0, 0)
                    End Using
                    bmp.Save(savePath, Imaging.ImageFormat.Jpeg)
                    bmp.Dispose()
                Else
                    MessageBox.Show("Unsupported format for ImgView.")
                    Return
                End If
                MessageBox.Show("Image saved to: " & savePath, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Failed to save image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class
