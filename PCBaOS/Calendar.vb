Public Class Calendar

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NONEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NONEToolStripMenuItem.Click
        If My.Settings.CalendarType = "Standard" Then
            Me.CalendarPanel.BackgroundImage = My.Resources.none
            Me.PictureBox1.Image = Nothing
        Else
            Me.PictureBox1.Image = My.Resources.none
            Me.CalendarPanel.BackgroundImage = Nothing
        End If
        My.Settings.CalendarWallpaper = 0
        SetCalendarWallpaper()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        If My.Settings.CalendarType = "Standard" Then
            Me.CalendarPanel.BackgroundImage = My.Resources.blur
            Me.PictureBox1.Image = Nothing
        Else
            Me.PictureBox1.Image = My.Resources.blur
            Me.CalendarPanel.BackgroundImage = Nothing
        End If
        My.Settings.CalendarWallpaper = 1
        SetCalendarWallpaper()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        If My.Settings.CalendarType = "Standard" Then
            Me.CalendarPanel.BackgroundImage = My.Resources.abstract
            Me.PictureBox1.Image = Nothing
        Else
            Me.PictureBox1.Image = My.Resources.abstract
            Me.CalendarPanel.BackgroundImage = Nothing
        End If
        My.Settings.CalendarWallpaper = 2
        SetCalendarWallpaper()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        If My.Settings.CalendarType = "Standard" Then
            Me.CalendarPanel.BackgroundImage = My.Resources.lion
            Me.PictureBox1.Image = Nothing
        Else
            Me.PictureBox1.Image = My.Resources.lion
            Me.CalendarPanel.BackgroundImage = Nothing
        End If
        My.Settings.CalendarWallpaper = 3
        SetCalendarWallpaper()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        If My.Settings.CalendarType = "Standard" Then
            Me.CalendarPanel.BackgroundImage = My.Resources.sunset
            Me.PictureBox1.Image = Nothing
        Else
            Me.PictureBox1.Image = My.Resources.sunset
            Me.CalendarPanel.BackgroundImage = Nothing
        End If
        My.Settings.CalendarWallpaper = 4
        SetCalendarWallpaper()
    End Sub

    ' --- Custom Calendar Implementation ---
    Private currentDate As Date = Date.Today
    Private btnPrevYear As Button
    Private btnPrev As Button
    Private btnNext As Button
    Private btnNextYear As Button
    Private lblMonthYear As Label
    Private dayLabels(6) As Label
    Private dayCells(5, 6) As Label

    ' Reminders storage: Dictionary(Of String, String) where key is yyyy-MM-dd
    Private calendarReminders As New Dictionary(Of String, String)()

    ' Helper to serialize/deserialize reminders to a string for My.Settings
    Private Function SerializeReminders() As String
        Return String.Join("|", calendarReminders.Select(Function(kv) kv.Key & "=" & kv.Value.Replace("|", "\|").Replace("=", "\=")))
    End Function
    Private Sub DeserializeReminders(ByVal data As String)
        calendarReminders.Clear()
        If String.IsNullOrEmpty(data) Then Return
        For Each pair In data.Split("|"c)
            Dim idx = pair.IndexOf("=")
            If idx > 0 Then
                Dim key = pair.Substring(0, idx)
                Dim value = pair.Substring(idx + 1).Replace("\|", "|").Replace("\=", "=")
                calendarReminders(key) = value
            End If
        Next
    End Sub

    ' Reminder dialog
    Private Class ReminderForm
        Inherits Form
        Public Property ReminderText As String
        Private txt As TextBox
        Private btnOK As Button
        Private btnCancel As Button
        Public Sub New(ByVal dateStr As String, ByVal existingText As String)
            Me.Text = "Reminder for " & dateStr
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Width = 250
            Me.Height = 150
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.ShowInTaskbar = False
            Me.TopMost = True

            txt = New TextBox()
            txt.Multiline = True
            txt.Width = 200
            txt.Height = 50
            txt.Left = 15
            txt.Top = 10
            txt.Text = existingText
            Me.Controls.Add(txt)

            btnOK = New Button()
            btnOK.Text = "OK"
            btnOK.Left = 40
            btnOK.Top = 70
            btnOK.Width = 60
            AddHandler btnOK.Click, Sub()
                                        Me.ReminderText = txt.Text.Trim()
                                        Me.DialogResult = DialogResult.OK
                                        Me.Close()
                                    End Sub
            Me.Controls.Add(btnOK)

            btnCancel = New Button()
            btnCancel.Text = "Cancel"
            btnCancel.Left = 120
            btnCancel.Top = 70
            btnCancel.Width = 60
            AddHandler btnCancel.Click, Sub()
                                            Me.DialogResult = DialogResult.Cancel
                                            Me.Close()
                                        End Sub
            Me.Controls.Add(btnCancel)
        End Sub
    End Class

    Private Sub CalendarPanel_Init()
        ' Clear previous controls
        CalendarPanel.Controls.Clear()

        ' Header: Month/Year and navigation
        btnPrevYear = New Button()
        btnPrevYear.Text = "<<"
        btnPrevYear.Width = 28
        btnPrevYear.Height = 22
        btnPrevYear.Left = 10
        btnPrevYear.Top = 8
        AddHandler btnPrevYear.Click, AddressOf BtnPrevYear_Click
        CalendarPanel.Controls.Add(btnPrevYear)

        btnPrev = New Button()
        btnPrev.Text = "<"
        btnPrev.Width = 28
        btnPrev.Height = 22
        btnPrev.Left = btnPrevYear.Right + 4
        btnPrev.Top = 8
        AddHandler btnPrev.Click, AddressOf BtnPrev_Click
        CalendarPanel.Controls.Add(btnPrev)

        btnNext = New Button()
        btnNext.Text = ">"
        btnNext.Width = 28
        btnNext.Height = 22
        btnNext.Top = 8
        AddHandler btnNext.Click, AddressOf BtnNext_Click
        CalendarPanel.Controls.Add(btnNext)

        btnNextYear = New Button()
        btnNextYear.Text = ">>"
        btnNextYear.Width = 28
        btnNextYear.Height = 22
        btnNextYear.Top = 8
        AddHandler btnNextYear.Click, AddressOf BtnNextYear_Click
        CalendarPanel.Controls.Add(btnNextYear)

        ' Position next/prev year/month buttons and label
        btnNextYear.Left = CalendarPanel.Width - btnNextYear.Width - 10
        btnNext.Left = btnNextYear.Left - btnNext.Width - 4

        lblMonthYear = New Label()
        lblMonthYear.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblMonthYear.TextAlign = ContentAlignment.MiddleCenter
        lblMonthYear.AutoSize = False
        lblMonthYear.Top = 8
        lblMonthYear.Left = btnPrev.Right + 8
        lblMonthYear.Width = btnNext.Left - lblMonthYear.Left - 8
        lblMonthYear.Height = 22
        lblMonthYear.BackColor = Color.Transparent
        CalendarPanel.Controls.Add(lblMonthYear)

        ' Day names
        Dim dayNames() As String = {"Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"}
        Dim cellWidth As Integer = (CalendarPanel.Width - 20) \ 7
        For i As Integer = 0 To 6
            dayLabels(i) = New Label()
            dayLabels(i).Text = dayNames(i)
            dayLabels(i).TextAlign = ContentAlignment.MiddleCenter
            dayLabels(i).Font = New Font("Segoe UI", 8, FontStyle.Bold)
            dayLabels(i).Width = cellWidth
            dayLabels(i).Height = 18
            dayLabels(i).Left = 10 + i * cellWidth
            dayLabels(i).Top = 40
            dayLabels(i).BackColor = Color.Transparent
            CalendarPanel.Controls.Add(dayLabels(i))
        Next

        ' Day cells
        Dim cellHeight As Integer = (CalendarPanel.Height - 60) \ 6
        For row As Integer = 0 To 5
            For col As Integer = 0 To 6
                dayCells(row, col) = New Label()
                dayCells(row, col).Text = ""
                dayCells(row, col).TextAlign = ContentAlignment.MiddleCenter
                dayCells(row, col).Font = New Font("Segoe UI", 8, FontStyle.Regular)
                dayCells(row, col).Width = cellWidth
                dayCells(row, col).Height = cellHeight
                dayCells(row, col).Left = 10 + col * cellWidth
                dayCells(row, col).Top = 60 + row * cellHeight
                dayCells(row, col).BorderStyle = BorderStyle.FixedSingle
                dayCells(row, col).BackColor = Color.Transparent
                AddHandler dayCells(row, col).MouseEnter, AddressOf DayCell_MouseEnter
                AddHandler dayCells(row, col).MouseLeave, AddressOf DayCell_MouseLeave
                AddHandler dayCells(row, col).DoubleClick, AddressOf DayCell_DoubleClick
                CalendarPanel.Controls.Add(dayCells(row, col))
            Next
        Next

        UpdateCalendarGrid()
    End Sub

    Private Sub UpdateCalendarGrid()
        lblMonthYear.Text = currentDate.ToString("MMMM yyyy")
        Dim daysInMonth As Integer = Date.DaysInMonth(currentDate.Year, currentDate.Month)
        Dim firstDayOfMonth As New Date(currentDate.Year, currentDate.Month, 1)
        Dim startDayOfWeek As Integer = (CInt(firstDayOfMonth.DayOfWeek) + 6) Mod 7 ' Monday=0
        Dim day As Integer = 1
        For row As Integer = 0 To 5
            For col As Integer = 0 To 6
                dayCells(row, col).Text = ""
                dayCells(row, col).BackColor = Color.Transparent
                dayCells(row, col).Font = New Font("Segoe UI", 8, FontStyle.Regular)
                Dim cellIndex As Integer = row * 7 + col
                If cellIndex >= startDayOfWeek AndAlso day <= daysInMonth Then
                    dayCells(row, col).Text = day.ToString()
                    Dim dateStr As String = New Date(currentDate.Year, currentDate.Month, day).ToString("yyyy-MM-dd")
                    If calendarReminders.ContainsKey(dateStr) AndAlso Not String.IsNullOrWhiteSpace(calendarReminders(dateStr)) Then
                        ' Visual indicator for reminder (dot at bottom)
                        dayCells(row, col).Font = New Font("Segoe UI", 8, FontStyle.Bold)
                        dayCells(row, col).Text &= " ·"
                    End If
                    If currentDate.Year = Date.Today.Year AndAlso currentDate.Month = Date.Today.Month AndAlso day = Date.Today.Day Then
                        dayCells(row, col).BackColor = Color.LightSkyBlue
                        dayCells(row, col).Font = New Font("Segoe UI", 8, FontStyle.Bold)
                    End If
                    day += 1
                End If
            Next
        Next
    End Sub

    Private Sub BtnPrev_Click(ByVal sender As Object, ByVal e As EventArgs)
        currentDate = currentDate.AddMonths(-1)
        UpdateCalendarGrid()
        SetCalendarTransparency(My.Settings.CalendarTransparentBG)
    End Sub

    Private Sub BtnNext_Click(ByVal sender As Object, ByVal e As EventArgs)
        currentDate = currentDate.AddMonths(1)
        UpdateCalendarGrid()
        SetCalendarTransparency(My.Settings.CalendarTransparentBG)
    End Sub

    Private Sub BtnPrevYear_Click(ByVal sender As Object, ByVal e As EventArgs)
        currentDate = currentDate.AddYears(-1)
        UpdateCalendarGrid()
        SetCalendarTransparency(My.Settings.CalendarTransparentBG)
    End Sub

    Private Sub BtnNextYear_Click(ByVal sender As Object, ByVal e As EventArgs)
        currentDate = currentDate.AddYears(1)
        UpdateCalendarGrid()
        SetCalendarTransparency(My.Settings.CalendarTransparentBG)
    End Sub

    Private Sub Calendar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.CalendarType = "Standard" Then
            ToolStripMenuItem1.Text = "Extended Calendar"
            ToolStripMenuItem1.Image = My.Resources.maximize
        End If
        If My.Settings.CalendarType = "Extended" Then
            ToolStripMenuItem1.Text = "Standard Calendar"
            ToolStripMenuItem1.Image = My.Resources.minimize
        End If
        If My.Settings.CalendarType = "Standard" Then
            Me.Width = 379
            Me.Height = 232
            Me.CalendarPanel.BackgroundImageLayout = ImageLayout.Stretch
            Me.PictureBox1.Visible = False
        End If
        If My.Settings.CalendarType = "Extended" Then
            Me.Width = 379
            Me.Height = 415
            Me.CalendarPanel.BackgroundImage = Nothing
            Me.PictureBox1.Visible = True
            Me.PictureBox1.BringToFront()
        End If
        SetCalendarWallpaper()
        ' Load reminders from settings
        DeserializeReminders(CStr(My.Settings.CalendarReminders))
        CalendarPanel_Init()
        ' Set transparency from settings
        If My.Settings.CalendarTransparentBG Then
            TransparentToolStripMenuItem.Checked = True
            SetCalendarTransparency(True)
        Else
            TransparentToolStripMenuItem.Checked = False
            SetCalendarTransparency(False)
        End If
    End Sub

    Private Sub ExtendedCalendarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        If ToolStripMenuItem1.Text = "Extended Calendar" Then
            Me.Width = 379
            Me.Height = 415
            Me.CalendarPanel.BackgroundImage = Nothing
            Me.PictureBox1.Visible = True
            Me.PictureBox1.BringToFront()
            ToolStripMenuItem1.Text = "Standard Calendar"
            ToolStripMenuItem1.Image = My.Resources.minimize
            My.Settings.CalendarType = "Extended"
            SetCalendarWallpaper()
        ElseIf ToolStripMenuItem1.Text = "Standard Calendar" Then
            Me.Width = 379
            Me.Height = 232
            Me.CalendarPanel.BackgroundImageLayout = ImageLayout.Stretch
            Me.PictureBox1.Visible = False
            ToolStripMenuItem1.Text = "Extended Calendar"
            ToolStripMenuItem1.Image = My.Resources.maximize
            My.Settings.CalendarType = "Standard"
            SetCalendarWallpaper()
        End If

    End Sub

    Private Sub TransparentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransparentToolStripMenuItem.Click
        My.Settings.CalendarTransparentBG = Not My.Settings.CalendarTransparentBG
        My.Settings.Save()
        TransparentToolStripMenuItem.Checked = My.Settings.CalendarTransparentBG
        SetCalendarTransparency(My.Settings.CalendarTransparentBG)
    End Sub

    ' Helper to set all calendar label backgrounds based on transparency setting
    Private Sub SetCalendarTransparency(ByVal isTransparent As Boolean)
        Dim bgColor As Color = If(isTransparent, Color.Transparent, Color.White)
        For i As Integer = 0 To dayLabels.Length - 1
            If dayLabels(i) IsNot Nothing Then dayLabels(i).BackColor = bgColor
        Next
        For row As Integer = 0 To dayCells.GetLength(0) - 1
            For col As Integer = 0 To dayCells.GetLength(1) - 1
                If dayCells(row, col) IsNot Nothing Then
                    ' Only set to white if not today highlight
                    If dayCells(row, col).BackColor <> Color.LightSkyBlue Then
                        dayCells(row, col).BackColor = bgColor
                    End If
                End If
            Next
        Next
    End Sub

    ' Helper to set wallpaper based on settings
    Private Sub SetCalendarWallpaper()
        If My.Settings.CalendarType = "Standard" Then
            Select Case My.Settings.CalendarWallpaper
                Case 0 : Me.CalendarPanel.BackgroundImage = My.Resources.none
                Case 1 : Me.CalendarPanel.BackgroundImage = My.Resources.blur
                Case 2 : Me.CalendarPanel.BackgroundImage = My.Resources.abstract
                Case 3 : Me.CalendarPanel.BackgroundImage = My.Resources.lion
                Case 4 : Me.CalendarPanel.BackgroundImage = My.Resources.sunset
                Case 5 : Me.CalendarPanel.BackgroundImage = My.Resources.lines
            End Select
            Me.PictureBox1.Image = Nothing
        Else
            Select Case My.Settings.CalendarWallpaper
                Case 0 : Me.PictureBox1.Image = My.Resources.none
                Case 1 : Me.PictureBox1.Image = My.Resources.blur
                Case 2 : Me.PictureBox1.Image = My.Resources.abstract
                Case 3 : Me.PictureBox1.Image = My.Resources.lion
                Case 4 : Me.PictureBox1.Image = My.Resources.sunset
                Case 5 : Me.PictureBox1.Image = My.Resources.lines
            End Select
            Me.CalendarPanel.BackgroundImage = Nothing
        End If
    End Sub

    ' Custom date entry dialog for Set Date
    Private Class SetDateForm
        Inherits Form
        Public Property SelectedDate As Date
        Private datePicker As DateTimePicker
        Private btnOK As Button
        Private btnCancel As Button
        Public Sub New(ByVal currentDate As Date)
            Me.Text = "Set Date"
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Width = 250
            Me.Height = 120
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.ShowInTaskbar = False
            Me.TopMost = True

            datePicker = New DateTimePicker()
            datePicker.Format = DateTimePickerFormat.Short
            datePicker.Value = currentDate
            datePicker.Left = 20
            datePicker.Top = 10
            datePicker.Width = 200
            Me.Controls.Add(datePicker)

            btnOK = New Button()
            btnOK.Text = "OK"
            btnOK.Left = 40
            btnOK.Top = 45
            btnOK.Width = 60
            AddHandler btnOK.Click, Sub()
                                        Me.SelectedDate = datePicker.Value
                                        Me.DialogResult = DialogResult.OK
                                        Me.Close()
                                    End Sub
            Me.Controls.Add(btnOK)

            btnCancel = New Button()
            btnCancel.Text = "Cancel"
            btnCancel.Left = 120
            btnCancel.Top = 45
            btnCancel.Width = 60
            AddHandler btnCancel.Click, Sub()
                                            Me.DialogResult = DialogResult.Cancel
                                            Me.Close()
                                        End Sub
            Me.Controls.Add(btnCancel)
        End Sub
    End Class

    Private Sub GoToTodayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoToTodayToolStripMenuItem.Click
        currentDate = Date.Today
        UpdateCalendarGrid()
        SetCalendarTransparency(My.Settings.CalendarTransparentBG)
    End Sub

    Private Sub SetDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetDateToolStripMenuItem.Click
        Using dlg As New SetDateForm(currentDate)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                currentDate = dlg.SelectedDate
                UpdateCalendarGrid()
                SetCalendarTransparency(My.Settings.CalendarTransparentBG)
            End If
        End Using
    End Sub

    ' Mouse hover highlight for day cells
    Private Sub DayCell_MouseEnter(ByVal sender As Object, ByVal e As EventArgs)
        Dim lbl As Label = CType(sender, Label)
        If lbl.Text <> "" AndAlso lbl.BackColor <> Color.LightSkyBlue Then
            lbl.BackColor = Color.FromArgb(230, 240, 255) ' very light blue
        End If
    End Sub

    Private Sub DayCell_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
        Dim lbl As Label = CType(sender, Label)
        If lbl.Text <> "" AndAlso lbl.BackColor <> Color.LightSkyBlue Then
            If My.Settings.CalendarTransparentBG Then
                lbl.BackColor = Color.Transparent
            Else
                lbl.BackColor = Color.White
            End If
        End If
    End Sub

    ' Double-click to add/edit reminder
    Private Sub DayCell_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
        Dim lbl As Label = CType(sender, Label)
        If lbl.Text = "" Then Exit Sub
        Dim dayText As String = lbl.Text.Trim()
        Dim dayNumStr As String = ""
        For Each ch As Char In dayText
            If Char.IsDigit(ch) Then
                dayNumStr &= ch
            Else
                Exit For
            End If
        Next
        If String.IsNullOrEmpty(dayNumStr) Then Exit Sub
        Dim dayNum As Integer = Integer.Parse(dayNumStr)
        Dim dateStr As String = New Date(currentDate.Year, currentDate.Month, dayNum).ToString("yyyy-MM-dd")
        Dim existing As String = If(calendarReminders.ContainsKey(dateStr), calendarReminders(dateStr), "")
        Using dlg As New ReminderForm(dateStr, existing)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                If String.IsNullOrWhiteSpace(dlg.ReminderText) Then
                    If calendarReminders.ContainsKey(dateStr) Then calendarReminders.Remove(dateStr)
                Else
                    calendarReminders(dateStr) = dlg.ReminderText
                End If
                My.Settings.CalendarReminders = SerializeReminders()
                My.Settings.Save()
                UpdateCalendarGrid()
                SetCalendarTransparency(My.Settings.CalendarTransparentBG)
            End If
        End Using
    End Sub

    ' Dialog for calculating days between two dates
    Private Class CalculateDaysForm
        Inherits Form
        Private datePicker1 As DateTimePicker
        Private datePicker2 As DateTimePicker
        Private lblResult As Label
        Private btnOK As Button
        Private btnCancel As Button
        Public Sub New()
            Me.Text = "Calculate Days Between Dates"
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Width = 320
            Me.Height = 220
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.ShowInTaskbar = False
            Me.TopMost = True

            Dim lbl1 As New Label()
            lbl1.Text = "First Date:"
            lbl1.Left = 20
            lbl1.Top = 20
            lbl1.Width = 80
            Me.Controls.Add(lbl1)

            datePicker1 = New DateTimePicker()
            datePicker1.Format = DateTimePickerFormat.Short
            datePicker1.Left = 110
            datePicker1.Top = 16
            datePicker1.Width = 150
            Me.Controls.Add(datePicker1)

            Dim lbl2 As New Label()
            lbl2.Text = "Second Date:"
            lbl2.Left = 20
            lbl2.Top = 55
            lbl2.Width = 80
            Me.Controls.Add(lbl2)

            datePicker2 = New DateTimePicker()
            datePicker2.Format = DateTimePickerFormat.Short
            datePicker2.Left = 110
            datePicker2.Top = 51
            datePicker2.Width = 150
            Me.Controls.Add(datePicker2)

            lblResult = New Label()
            lblResult.Left = 20
            lblResult.Top = 90
            lblResult.Width = 260
            lblResult.Height = 50
            lblResult.Text = ""
            Me.Controls.Add(lblResult)

            btnOK = New Button()
            btnOK.Text = "Calculate"
            btnOK.Left = 40
            btnOK.Top = 150
            btnOK.Width = 80
            AddHandler btnOK.Click, AddressOf BtnOK_Click
            Me.Controls.Add(btnOK)

            btnCancel = New Button()
            btnCancel.Text = "Close"
            btnCancel.Left = 160
            btnCancel.Top = 150
            btnCancel.Width = 80
            AddHandler btnCancel.Click, Sub()
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            End Sub
            Me.Controls.Add(btnCancel)
        End Sub

        Private Sub BtnOK_Click(sender As Object, e As EventArgs)
            Dim d1 As Date = datePicker1.Value.Date
            Dim d2 As Date = datePicker2.Value.Date
            Dim startDate As Date = If(d1 < d2, d1, d2)
            Dim endDate As Date = If(d1 < d2, d2, d1)
            Dim days As Integer = (endDate - startDate).Days
            Dim weeks As Integer = days \ 7
            Dim months As Integer = ((endDate.Year - startDate.Year) * 12) + (endDate.Month - startDate.Month)
            If endDate.Day < startDate.Day Then months -= 1
            Dim years As Integer = endDate.Year - startDate.Year
            If (endDate.Month < startDate.Month) Or (endDate.Month = startDate.Month AndAlso endDate.Day < startDate.Day) Then years -= 1
            lblResult.Text = String.Format("Days: {0}{4}Weeks: {1}{4}Months: {2}{4}Years: {3}", days, weeks, months, years, vbCrLf)
        End Sub
    End Class

    Private Sub CalculateDaysToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculateDaysToolStripMenuItem.Click
        Using dlg As New CalculateDaysForm()
            dlg.ShowDialog(Me)
        End Using
    End Sub
End Class