Public Class AnalogClocks
    ' Private fields for reusable objects to avoid recreating them on each tick
    Private hourPen As New Pen(Color.Black, 5)
    Private minutePen As New Pen(Color.Black, 3)
    Private secondPen As New Pen(Color.Red, 1)
    Private clockBitmap As Bitmap

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ' Update window title with current time
        If (My.Settings.Use24ClockFormat = True) Then
            Me.Text = "Clocks " & Now.ToString("HH:mm")
        Else
            Me.Text = "Clocks " & Now.ToString("hh:mm tt")
        End If

        ' Create bitmap for double-buffering if it doesn't exist or if size changed
        If PictureBox1.Width > 0 AndAlso PictureBox1.Height > 0 Then
            If clockBitmap Is Nothing OrElse clockBitmap.Width <> PictureBox1.Width OrElse clockBitmap.Height <> PictureBox1.Height Then
                If clockBitmap IsNot Nothing Then
                    clockBitmap.Dispose() ' Dispose of the old bitmap to prevent memory leaks
                End If
                clockBitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)
            End If

            ' Get the graphics object for the bitmap
            Using g As Graphics = Graphics.FromImage(clockBitmap)
                ' Enable anti-aliasing for smoother lines
                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

                Dim centerX As Integer = PictureBox1.Width \ 2
                Dim centerY As Integer = PictureBox1.Height \ 2
                Dim radius As Integer = Math.Min(centerX, centerY) - 20 ' Use the smaller dimension to ensure clock fits

                ' Clear the background of the bitmap
                g.Clear(My.Settings.ClockColor)

                ' Draw the clock face
                g.DrawEllipse(hourPen, 10, 10, PictureBox1.Width - 20, PictureBox1.Height - 20)

                DrawHourMarkers(g, centerX, centerY, radius)
                DrawClockHands(g, centerX, centerY, radius)
            End Using

            ' Update the picture box with the new bitmap
            PictureBox1.Image = clockBitmap
            PictureBox1.BackColor = My.Settings.ClockColor
        End If
    End Sub

    ' Separate method for drawing hour markers
    Private Sub DrawHourMarkers(ByVal g As Graphics, ByVal centerX As Integer, ByVal centerY As Integer, ByVal radius As Integer)
        For i As Integer = 0 To 11
            Dim angle As Double = i * 30 * Math.PI / 180
            Dim x1 As Integer = centerX + CInt(radius * Math.Sin(angle))
            Dim y1 As Integer = centerY - CInt(radius * Math.Cos(angle))
            Dim x2 As Integer = centerX + CInt((radius - 15) * Math.Sin(angle))
            Dim y2 As Integer = centerY - CInt((radius - 15) * Math.Cos(angle))
            g.DrawLine(hourPen, x1, y1, x2, y2)
        Next
    End Sub

    ' Separate method for drawing clock hands
    Private Sub DrawClockHands(ByVal g As Graphics, ByVal centerX As Integer, ByVal centerY As Integer, ByVal radius As Integer)
        ' Get the current time
        Dim now As DateTime = DateTime.Now

        ' Draw the hour hand
        Dim hourAngle As Double = ((now.Hour Mod 12) + now.Minute / 60.0) * 30 * Math.PI / 180
        Dim hourX As Integer = centerX + CInt(radius * 0.5 * Math.Sin(hourAngle))
        Dim hourY As Integer = centerY - CInt(radius * 0.5 * Math.Cos(hourAngle))
        g.DrawLine(hourPen, centerX, centerY, hourX, hourY)

        ' Draw the minute hand
        Dim minuteAngle As Double = (now.Minute + now.Second / 60.0) * 6 * Math.PI / 180
        Dim minuteX As Integer = centerX + CInt(radius * 0.8 * Math.Sin(minuteAngle))
        Dim minuteY As Integer = centerY - CInt(radius * 0.8 * Math.Cos(minuteAngle))
        g.DrawLine(minutePen, centerX, centerY, minuteX, minuteY)

        ' Draw the second hand
        Dim secondAngle As Double = now.Second * 6 * Math.PI / 180
        Dim secondX As Integer = centerX + CInt(radius * 0.9 * Math.Sin(secondAngle))
        Dim secondY As Integer = centerY - CInt(radius * 0.9 * Math.Cos(secondAngle))
        g.DrawLine(secondPen, centerX, centerY, secondX, secondY)

        ' Draw center point
        g.FillEllipse(New SolidBrush(Color.Black), centerX - 4, centerY - 4, 8, 8)
    End Sub

    Private Sub AnalogClocks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Width - 200, 40)
        ' Set timer interval to 1000ms (1 second) if not already set
        If Timer1.Interval = 0 Then
            Timer1.Interval = 1000
        End If
        Timer1.Start() ' Ensure timer is started
        If My.Settings.AreLogin = False Then
            ContextMenuStrip1.Enabled = False
        Else
            ContextMenuStrip1.Enabled = True
        End If
    End Sub

    Private Sub AnalogClocksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnalogClocksToolStripMenuItem.Click
        Clocks.Show()
        My.Settings.ClockType = "0"
        My.Settings.Save() ' Save settings when changing clock type
        Me.Close()
    End Sub

    Private Sub ChangeColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeColorToolStripMenuItem.Click
        Using colorDialog As New ColorDialog()
            colorDialog.Color = My.Settings.ClockColor ' Set current color as default
            If colorDialog.ShowDialog() = DialogResult.OK Then
                My.Settings.ClockColor = colorDialog.Color
                My.Settings.Save()
            End If
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    ' Clean up resources on form closing
    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        If clockBitmap IsNot Nothing Then
            clockBitmap.Dispose()
        End If
        hourPen.Dispose()
        minutePen.Dispose()
        secondPen.Dispose()
        MyBase.OnFormClosing(e)
    End Sub
End Class