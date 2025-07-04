Public Class Paint99
    Dim down As Boolean = False
    Dim mybrush As Brush = Brushes.Black
    Dim savedbrush As Brush = Brushes.Black
    Dim startPoint As Point
    Dim endPoint As Point
    Dim drawingBitmap As Bitmap
    Dim lastPoint As Point
    Dim previewRectangle As Rectangle
    Dim isDrawingRectangle As Boolean = False
    Dim tempBitmap As Bitmap
    Dim polygonPoints As New List(Of Point)()
    Dim isDrawingPolygon As Boolean = False
    Dim drawOutlineOnly As Boolean = False
    Dim isDrawingLine As Boolean = False
    Dim lineStartPoint As Point
    Dim lineEndPoint As Point
    Dim isTextMode As Boolean = False
    ' Advanced text tool controls
    Dim floatingTextBox As RichTextBox = Nothing
    Dim textWidgetPanel As Panel = Nothing
    Dim fontCombo As ComboBox = Nothing
    Dim sizeCombo As ComboBox = Nothing
    Dim boldButton As CheckBox = Nothing
    Dim italicButton As CheckBox = Nothing
    Dim underlineButton As CheckBox = Nothing
    Dim finishButton As Button = Nothing
    Dim textRect As Rectangle
    Dim isDraggingTextRect As Boolean = False
    Dim textStartPoint As Point
    ' Universal startup parameters for future extensibility
    Public Property StartupParameters As New Dictionary(Of String, Object)()

    Private Sub Paint99_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox1.BackColor = Color.White
        PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        Panel2.AutoScrollMinSize = PictureBox1.Size
        ' Universal startup: load file if provided
        If StartupParameters IsNot Nothing AndAlso StartupParameters.ContainsKey("FilePath") Then
            Dim filePath As String = CStr(StartupParameters("FilePath"))
            If IO.File.Exists(filePath) Then
                Try
                    Dim ext As String = IO.Path.GetExtension(filePath).ToLower()
                    If ext = ".png" OrElse ext = ".jpg" OrElse ext = ".jpeg" Then
                        Dim loadedImg As Image = Image.FromFile(filePath)
                        drawingBitmap = New Bitmap(loadedImg)
                        PictureBox1.Image = drawingBitmap
                        Me.Text = filePath & " - Paint99"
                    End If
                Catch ex As Exception
                    MessageBox.Show("Could not load image: " & ex.Message)
                    drawingBitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)
                    PictureBox1.Image = drawingBitmap
                End Try
            Else
                drawingBitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)
                PictureBox1.Image = drawingBitmap
            End If
        Else
            drawingBitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)
            PictureBox1.Image = drawingBitmap
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        down = True
        lastPoint = e.Location
        If ComboBox2.Text = "Text" AndAlso isTextMode Then
            isDraggingTextRect = True
            textStartPoint = e.Location
        ElseIf ComboBox2.Text = "Rectangle" Then
            isDrawingRectangle = True
            previewRectangle = New Rectangle(e.Location, New Size(0, 0))
            tempBitmap = CType(drawingBitmap.Clone(), Bitmap)
        ElseIf ComboBox2.Text = "Polygon" Then
            If Not isDrawingPolygon Then
                isDrawingPolygon = True
                polygonPoints.Clear()
            End If
            polygonPoints.Add(e.Location)
            If e.Button = MouseButtons.Right OrElse (polygonPoints.Count > 2 AndAlso e.Clicks = 2) Then
                If polygonPoints.Count > 2 Then
                    Using g As Graphics = Graphics.FromImage(drawingBitmap)
                        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                        If drawOutlineOnly Then
                            g.DrawPolygon(New Pen(mybrush, NumericUpDown1.Value), polygonPoints.ToArray())
                        Else
                            g.FillPolygon(mybrush, polygonPoints.ToArray())
                        End If
                    End Using
                    PictureBox1.Invalidate()
                End If
                isDrawingPolygon = False
                polygonPoints.Clear()
            End If
        ElseIf ComboBox2.Text = "Line" Then
            isDrawingLine = True
            lineStartPoint = e.Location
            lineEndPoint = e.Location
            tempBitmap = CType(drawingBitmap.Clone(), Bitmap)
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If ComboBox2.Text = "Text" AndAlso isTextMode AndAlso isDraggingTextRect Then
            ' Draw preview rectangle for text area
            Dim x = Math.Min(textStartPoint.X, e.X)
            Dim y = Math.Min(textStartPoint.Y, e.Y)
            Dim w = Math.Abs(textStartPoint.X - e.X)
            Dim h = Math.Abs(textStartPoint.Y - e.Y)
            textRect = New Rectangle(x, y, w, h)
            PictureBox1.Refresh()
            Using g As Graphics = PictureBox1.CreateGraphics()
                g.DrawRectangle(Pens.Black, textRect)
            End Using
            Return
        End If
        If down Then
            Using g As Graphics = Graphics.FromImage(drawingBitmap)
                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                Dim brushSize As Integer = NumericUpDown1.Value
                If ComboBox2.Text = "Brush" Then
                    Dim distance As Double = Math.Sqrt((e.X - lastPoint.X) ^ 2 + (e.Y - lastPoint.Y) ^ 2)
                    Dim steps As Integer = Math.Max(1, CInt(distance / (brushSize / 2)))
                    For i As Integer = 1 To steps
                        Dim t As Double = i / steps
                        Dim interpX As Integer = CInt(lastPoint.X + (e.X - lastPoint.X) * t)
                        Dim interpY As Integer = CInt(lastPoint.Y + (e.Y - lastPoint.Y) * t)
                        If ComboBox1.Text = "Default Brush" Then
                            g.FillEllipse(mybrush, interpX - brushSize \ 2, interpY - brushSize \ 2, brushSize, brushSize)
                        ElseIf ComboBox1.Text = "Rectangle Brush" Then
                            g.FillRectangle(mybrush, interpX - brushSize \ 2, interpY - brushSize \ 2, brushSize, brushSize)
                        Else
                            g.DrawLine(New Pen(mybrush, brushSize), lastPoint, e.Location)
                        End If
                    Next
                ElseIf ComboBox2.Text = "Rectangle" Then
                    If isDrawingRectangle AndAlso tempBitmap IsNot Nothing Then
                        drawingBitmap.Dispose()
                        drawingBitmap = CType(tempBitmap.Clone(), Bitmap)
                        PictureBox1.Image = drawingBitmap
                        Using gg As Graphics = Graphics.FromImage(drawingBitmap)
                            gg.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                            Dim rect = GetRectangle(lastPoint, e.Location)
                            previewRectangle = rect
                            If drawOutlineOnly Then
                                gg.DrawRectangle(New Pen(mybrush, brushSize), rect)
                            Else
                                gg.FillRectangle(mybrush, rect)
                            End If
                        End Using
                    End If
                ElseIf ComboBox2.Text = "Free" Then
                    Dim distance As Double = Math.Sqrt((e.X - lastPoint.X) ^ 2 + (e.Y - lastPoint.Y) ^ 2)
                    Dim steps As Integer = Math.Max(1, CInt(distance / (brushSize / 2)))
                    For i As Integer = 1 To steps
                        Dim t As Double = i / steps
                        Dim interpX As Integer = CInt(lastPoint.X + (e.X - lastPoint.X) * t)
                        Dim interpY As Integer = CInt(lastPoint.Y + (e.Y - lastPoint.Y) * t)
                        g.DrawLine(New Pen(mybrush, brushSize), lastPoint, New Point(interpX, interpY))
                        lastPoint = New Point(interpX, interpY)
                    Next
                ElseIf ComboBox2.Text = "Polygon" AndAlso isDrawingPolygon AndAlso polygonPoints.Count > 0 Then
                    drawingBitmap.Dispose()
                    drawingBitmap = CType(tempBitmap.Clone(), Bitmap)
                    PictureBox1.Image = drawingBitmap
                    Using gg As Graphics = Graphics.FromImage(drawingBitmap)
                        gg.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                        Dim previewPoints = polygonPoints.Concat({e.Location}).ToArray()
                        If drawOutlineOnly Then
                            gg.DrawPolygon(New Pen(mybrush, brushSize), previewPoints)
                        Else
                            g.FillPolygon(mybrush, previewPoints)
                        End If
                    End Using
                ElseIf ComboBox2.Text = "Line" Then
                    If isDrawingLine AndAlso tempBitmap IsNot Nothing Then
                        drawingBitmap.Dispose()
                        drawingBitmap = CType(tempBitmap.Clone(), Bitmap)
                        PictureBox1.Image = drawingBitmap
                        Using gg As Graphics = Graphics.FromImage(drawingBitmap)
                            gg.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                            gg.DrawLine(New Pen(mybrush, brushSize), lineStartPoint, e.Location)
                        End Using
                        lineEndPoint = e.Location
                    End If
                End If
            End Using
            PictureBox1.Invalidate()
            If ComboBox2.Text <> "Rectangle" AndAlso ComboBox2.Text <> "Polygon" AndAlso ComboBox2.Text <> "Line" Then
                lastPoint = e.Location
            End If
        End If
    End Sub

    Private Function GetRectangle(ByVal pt1 As Point, ByVal pt2 As Point) As Rectangle
        Dim x As Integer = Math.Min(pt1.X, pt2.X)
        Dim y As Integer = Math.Min(pt1.Y, pt2.Y)
        Dim width As Integer = Math.Abs(pt1.X - pt2.X)
        Dim height As Integer = Math.Abs(pt1.Y - pt2.Y)
        Return New Rectangle(x, y, width, height)
    End Function

    Private Sub PictureBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        down = False
        If ComboBox2.Text = "Text" AndAlso isTextMode AndAlso isDraggingTextRect Then
            isDraggingTextRect = False
            ShowFloatingTextBox()
            Return
        End If
        If ComboBox2.Text = "Rectangle" AndAlso isDrawingRectangle Then
            Using g As Graphics = Graphics.FromImage(drawingBitmap)
                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                If drawOutlineOnly Then
                    g.DrawRectangle(New Pen(mybrush, NumericUpDown1.Value), previewRectangle)
                Else
                    g.FillRectangle(mybrush, previewRectangle)
                End If
            End Using
            PictureBox1.Invalidate()
            isDrawingRectangle = False
            tempBitmap = Nothing
        ElseIf ComboBox2.Text = "Line" AndAlso isDrawingLine Then
            Using g As Graphics = Graphics.FromImage(drawingBitmap)
                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                g.DrawLine(New Pen(mybrush, NumericUpDown1.Value), lineStartPoint, lineEndPoint)
            End Using
            PictureBox1.Invalidate()
            isDrawingLine = False
            tempBitmap = Nothing
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PictureBox26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox26.Click
        mybrush = New SolidBrush(PictureBox26.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox49.Click
        mybrush = New SolidBrush(PictureBox49.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox33.Click
        mybrush = New SolidBrush(PictureBox33.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox25.Click
        mybrush = New SolidBrush(PictureBox25.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox17.Click
        mybrush = New SolidBrush(PictureBox17.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        mybrush = New SolidBrush(PictureBox3.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox16.Click
        mybrush = Brushes.Purple
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox32.Click
        mybrush = New SolidBrush(PictureBox32.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox27.Click
        mybrush = New SolidBrush(PictureBox27.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox19.Click
        mybrush = New SolidBrush(PictureBox19.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        mybrush = New SolidBrush(PictureBox11.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox28.Click
        mybrush = New SolidBrush(PictureBox28.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox29.Click
        mybrush = New SolidBrush(PictureBox29.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox13.Click
        mybrush = New SolidBrush(PictureBox13.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        mybrush = New SolidBrush(PictureBox6.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox14.Click
        mybrush = New SolidBrush(PictureBox14.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.Click
        mybrush = New SolidBrush(PictureBox15.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox30.Click
        mybrush = New SolidBrush(PictureBox30.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox38.Click
        mybrush = New SolidBrush(PictureBox38.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox22.Click
        mybrush = New SolidBrush(PictureBox22.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox46.Click
        mybrush = New SolidBrush(PictureBox46.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox36.Click
        mybrush = New SolidBrush(PictureBox36.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox20.Click
        mybrush = New SolidBrush(PictureBox20.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox44.Click
        mybrush = New SolidBrush(PictureBox44.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox41.Click
        mybrush = New SolidBrush(PictureBox41.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        mybrush = New SolidBrush(PictureBox2.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        mybrush = New SolidBrush(PictureBox10.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        mybrush = New SolidBrush(PictureBox7.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox23.Click
        mybrush = New SolidBrush(PictureBox23.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox48.Click
        mybrush = New SolidBrush(PictureBox48.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox40.Click
        mybrush = New SolidBrush(PictureBox40.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox47.Click
        mybrush = New SolidBrush(PictureBox47.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If PictureBox1.BackColor = Color.MintCream Then
            PictureBox1.BackColor = Color.White
        Else
            PictureBox1.BackColor = Color.MintCream
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Paint99_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        ComboBox2.Text = "Brush"
        mybrush = savedbrush
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim colorDialog As New ColorDialog()

        If colorDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedColor As Color = colorDialog.Color

            mybrush = New SolidBrush(selectedColor)

            savedbrush = mybrush
            Dim backColor As Color = CType(mybrush, SolidBrush).Color
            PictureBox50.BackColor = backColor

        End If
    End Sub

    Private Sub PictureBox42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox42.Click
        mybrush = New SolidBrush(PictureBox42.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox34.Click
        mybrush = New SolidBrush(PictureBox34.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox12.Click
        mybrush = New SolidBrush(PictureBox12.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox45.Click
        mybrush = New SolidBrush(PictureBox45.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        drawingBitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = drawingBitmap
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged, ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ComboBox1.Text = "Default Brush" Then
            ComboBox1.Text = "Rectangle Brush"
            Button2.Image = My.Resources.rectangle
        ElseIf ComboBox1.Text = "Rectangle Brush" Then
            ComboBox1.Text = "Rectangle Brush"
            ComboBox1.Text = "Default Brush"
            Button2.Image = My.Resources.circle2
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        savedbrush = mybrush
        mybrush = Brushes.White
        ComboBox2.Text = "Brush"
    End Sub

    Private Sub Button3_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Eraser"
    End Sub

    Private Sub Button3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.MouseLeave, Button3.MouseLeave, Button2.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub Button4_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Erase current painting and create new"
    End Sub

    Private Sub Button2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Change brush shape"
    End Sub

    Private Sub SaveToolStripMenuItem_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub SaveToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Load image"
    End Sub

    Private Sub Width333Height344ToolStripMenuItem_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Width333Height344ToolStripMenuItem.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub Height300ToolStripMenuItem_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Height300ToolStripMenuItem.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub Width333Height344ToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Width333Height344ToolStripMenuItem.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Width of canvas"
    End Sub

    Private Sub Height300ToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Height300ToolStripMenuItem.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Height of canvas"
    End Sub

    Private Sub PictureBox18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox18.Click
        mybrush = New SolidBrush(PictureBox18.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox21.Click
        mybrush = New SolidBrush(PictureBox21.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox24.Click
        mybrush = New SolidBrush(PictureBox24.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox43.Click
        mybrush = New SolidBrush(PictureBox43.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox35.Click
        mybrush = New SolidBrush(PictureBox35.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        mybrush = New SolidBrush(PictureBox4.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        mybrush = New SolidBrush(PictureBox5.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        mybrush = New SolidBrush(PictureBox8.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        mybrush = New SolidBrush(PictureBox9.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub PictureBox37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox37.Click
        mybrush = New SolidBrush(PictureBox37.BackColor)
        savedbrush = mybrush
        Dim backColor As Color = CType(mybrush, SolidBrush).Color
        PictureBox50.BackColor = backColor
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ComboBox2.Text = "Rectangle"
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ComboBox2.Text = "Free"
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        drawOutlineOnly = CheckBox1.Checked
    End Sub

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LineButton.Click
        ComboBox2.Text = "Line"
    End Sub

    ' Save As handler for Paint99, using FileSaveDialog restricted to Kernel
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
                    drawingBitmap.Save(savePath, Imaging.ImageFormat.Png)
                ElseIf format = "jpg" Or format = "jpeg" Then
                    Dim flatBmp As Bitmap = FlattenToWhite(drawingBitmap)
                    flatBmp.Save(savePath, Imaging.ImageFormat.Jpeg)
                    flatBmp.Dispose()
                Else
                    MessageBox.Show("Unsupported format for Paint99.")
                    Return
                End If
                MessageBox.Show("Image saved to: " & savePath, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Failed to save image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function FlattenToWhite(ByVal bmp As Bitmap) As Bitmap
        Dim newBmp As New Bitmap(bmp.Width, bmp.Height, Imaging.PixelFormat.Format24bppRgb)
        Using g As Graphics = Graphics.FromImage(newBmp)
            g.Clear(Color.White)
            g.DrawImage(bmp, 0, 0)
        End Using
        Return newBmp
    End Function

    Private Sub TextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextButton.Click
        ComboBox2.Text = "Text"
        isTextMode = True
    End Sub

    Private Sub ShowFloatingTextBox()
        ' Remove old controls if any
        If floatingTextBox IsNot Nothing Then
            Me.Controls.Remove(floatingTextBox)
            floatingTextBox.Dispose()
        End If
        If textWidgetPanel IsNot Nothing Then
            Me.Controls.Remove(textWidgetPanel)
            textWidgetPanel.Dispose()
        End If
        ' Create RichTextBox
        floatingTextBox = New RichTextBox()
        floatingTextBox.Multiline = True
        floatingTextBox.BorderStyle = BorderStyle.FixedSingle
        floatingTextBox.SetBounds(PictureBox1.Left + textRect.Left + 12, PictureBox1.Top + textRect.Top + 28, textRect.Width + 2, textRect.Height)
        floatingTextBox.Font = New Font("Arial", 16, FontStyle.Regular)
        floatingTextBox.ForeColor = CType(mybrush, SolidBrush).Color
        Me.Controls.Add(floatingTextBox)
        floatingTextBox.BringToFront()
        floatingTextBox.Focus()
        ' Create widget panel
        textWidgetPanel = New Panel()
        textWidgetPanel.SetBounds(floatingTextBox.Left, floatingTextBox.Top - 50, 400, 50)
        textWidgetPanel.BackColor = Color.LightGray
        ' Font family
        fontCombo = New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDownList, .Width = 120, .Left = 0}
        fontCombo.Items.AddRange(FontFamily.Families.Select(Function(f) f.Name).ToArray())
        fontCombo.SelectedItem = "Arial"
        AddHandler fontCombo.SelectedIndexChanged, AddressOf FontWidget_Changed
        textWidgetPanel.Controls.Add(fontCombo)
        ' Font size
        sizeCombo = New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDownList, .Width = 60, .Left = 130}
        For i = 8 To 72 Step 2
            sizeCombo.Items.Add(i.ToString())
        Next
        sizeCombo.SelectedItem = "16"
        AddHandler sizeCombo.SelectedIndexChanged, AddressOf FontWidget_Changed
        textWidgetPanel.Controls.Add(sizeCombo)
        ' Bold
        boldButton = New CheckBox() With {.Text = "B", .Font = New Font("Arial", 10, FontStyle.Bold), .Width = 35, .Left = 200}
        AddHandler boldButton.CheckedChanged, AddressOf FontWidget_Changed
        textWidgetPanel.Controls.Add(boldButton)
        ' Italic
        italicButton = New CheckBox() With {.Text = "I", .Font = New Font("Arial", 10, FontStyle.Italic), .Width = 35, .Left = 240}
        AddHandler italicButton.CheckedChanged, AddressOf FontWidget_Changed
        textWidgetPanel.Controls.Add(italicButton)
        ' Underline
        underlineButton = New CheckBox() With {.Text = "U", .Font = New Font("Arial", 10, FontStyle.Underline), .Width = 35, .Left = 280}
        AddHandler underlineButton.CheckedChanged, AddressOf FontWidget_Changed
        textWidgetPanel.Controls.Add(underlineButton)
        ' Finish
        finishButton = New Button() With {.Text = "Finish", .Width = 70, .Left = 320}
        AddHandler finishButton.Click, AddressOf FinishTextButton_Click
        textWidgetPanel.Controls.Add(finishButton)
        Me.Controls.Add(textWidgetPanel)
        textWidgetPanel.BringToFront()
    End Sub

    Private Sub FontWidget_Changed(ByVal sender As Object, ByVal e As EventArgs)
        If floatingTextBox Is Nothing Then Return
        Dim fontName As String = If(fontCombo.SelectedItem, "Arial")
        Dim fontSize As Single = 16
        Single.TryParse(If(sizeCombo.SelectedItem, "16"), fontSize)
        Dim style As FontStyle = FontStyle.Regular
        If boldButton.Checked Then style = style Or FontStyle.Bold
        If italicButton.Checked Then style = style Or FontStyle.Italic
        If underlineButton.Checked Then style = style Or FontStyle.Underline
        floatingTextBox.Font = New Font(fontName, fontSize, style)
    End Sub

    Private Sub FinishTextButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If floatingTextBox Is Nothing OrElse textRect.Width = 0 OrElse textRect.Height = 0 Then Return
        Using g As Graphics = Graphics.FromImage(drawingBitmap)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Dim r As RectangleF = New RectangleF(textRect.Left, textRect.Top, textRect.Width, textRect.Height)
            g.DrawString(floatingTextBox.Text, floatingTextBox.Font, New SolidBrush(floatingTextBox.ForeColor), r)
        End Using
        PictureBox1.Invalidate()
        Me.Controls.Remove(floatingTextBox)
        Me.Controls.Remove(textWidgetPanel)
        floatingTextBox.Dispose()
        textWidgetPanel.Dispose()
        floatingTextBox = Nothing
        textWidgetPanel = Nothing
        isTextMode = False
    End Sub

    Private Sub SaveToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem1.Click
        SaveAsToKernel()
    End Sub

    ' Open handler for Paint99, using FileLoadDialog restricted to Kernel
    Private Sub OpenFromKernel()
        Dim kernelPath As String = IO.Path.Combine(Application.StartupPath, "Kernel")
        Dim dlg As New FileLoadDialog(kernelPath)
        dlg.AvailableFilters = New List(Of String)({"All Files", "Images (*.png;*.jpg;*.jpeg)"})
        dlg.DefaultFilter = "Images (*.png;*.jpg;*.jpeg)"
        If dlg.ShowDialog(Me) = DialogResult.OK Then
            Dim filePath As String = dlg.SelectedFile
            If IO.File.Exists(filePath) Then
                Try
                    Dim ext As String = IO.Path.GetExtension(filePath).ToLower()
                    If ext = ".png" Or ext = ".jpg" Or ext = ".jpeg" Then
                        Dim loadedImg As Image = Image.FromFile(filePath)
                        drawingBitmap = New Bitmap(loadedImg)
                        PictureBox1.Image = drawingBitmap
                        Me.Text = filePath & " - Paint99"
                    Else
                        MessageBox.Show("Unsupported file type for Paint99.")
                        Return
                    End If
                Catch ex As Exception
                    MessageBox.Show("Could not load image: " & ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        OpenFromKernel()
    End Sub
End Class

Module ControlExtensions
    <System.Runtime.CompilerServices.Extension()>
    Public Sub DoubleBuffered(ByVal control As Control, ByVal enable As Boolean)
        Dim doubleBufferPropertyInfo As System.Reflection.PropertyInfo = control.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        doubleBufferPropertyInfo.SetValue(control, enable, Nothing)
    End Sub
End Module