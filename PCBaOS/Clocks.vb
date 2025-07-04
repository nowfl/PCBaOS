Public Class Clocks

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim currentDate As Date = Now
        If (My.Settings.Use24ClockFormat = True) Then
            Label1.Text = Now.ToString("HH:mm:ss")
        Else
            Label1.Text = Now.ToString("hh:mm:ss tt")
        End If
        If My.Settings.DateFormat = "1" Then
            Label2.Text = currentDate.ToString("dd.MM.yyyy")
        ElseIf My.Settings.DateFormat = "2" Then
            Label2.Text = currentDate.ToString("MM.dd.yyyy")
        ElseIf My.Settings.DateFormat = "3" Then
            Label2.Text = currentDate.ToString("yyyy.MM.dd")
        End If
        Me.BackColor = My.Settings.ClockColor
    End Sub

    Private Sub Clocks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Width - 230, 40)
        If My.Settings.AreLogin = False Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Clocks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Calendar.Show()
    End Sub

    Private Sub ChangeColorToolStripMenuItem_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.MouseLeave, ChangeColorToolStripMenuItem.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub Button1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Quick open to calendar"
    End Sub

    Private Sub ChangeColorToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeColorToolStripMenuItem.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Change back color of clocks"
    End Sub

    Private Sub DefaultToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Set default (White) color to clocks"
    End Sub

    Private Sub RedToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Set red color to clocks"
    End Sub

    Private Sub OrangeToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Set orange color to clocks"
    End Sub

    Private Sub YellowToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Set yellow color to clocks"
    End Sub

    Private Sub LimeToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Set lime color to clocks"
    End Sub

    Private Sub GreenToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Set green color to clocks"
    End Sub

    Private Sub DarkGreenToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Set dark green color to clocks"
    End Sub

    Private Sub CyanToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Set cyan color to clocks"
    End Sub

    Private Sub LightBlueToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Set light blue color to clocks"
    End Sub

    Private Sub BlueToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Set blue color to clocks"
    End Sub

    Private Sub DarkBlueToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Set dark blue color to clocks"
    End Sub

    Private Sub PurpleToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Set purple color to clocks"
    End Sub

    Private Sub PinkToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Set pink color to clocks"
    End Sub

    Private Sub ExitToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Exit the application"
    End Sub

    Private Sub Clocks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

    End Sub

    Private Sub Clocks_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        
    End Sub

    Private Sub ChangeColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeColorToolStripMenuItem.Click
        Dim colorDialog As New ColorDialog()
        If colorDialog.ShowDialog() = DialogResult.OK Then
            My.Settings.ClockColor = colorDialog.Color
            My.Settings.Save()
        End If
    End Sub

    Private Sub AnalogClocksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnalogClocksToolStripMenuItem.Click
        AnalogClocks.Show()
        My.Settings.ClockType = "1"
        Me.Close()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Clocks_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        If My.Settings.ClockType = "1" Then
            AnalogClocks.Show()
            Me.Close()
        ElseIf My.Settings.ClockType = "0" Then

        End If
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class