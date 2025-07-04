Public Class WorkBar

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Clocks.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ContextMenuStrip1.Show(MousePosition)
        
    End Sub

    Private Sub WorkBar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(4, 524)
        Me.BackColor = My.Settings.WBarColor
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        QuickAccess.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ApplicationFolder.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        settings.Show()
    End Sub

    Private Sub Button1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Open application menu to access to all your programs"
    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownToolStripMenuItem.Click
        Const MB_TOPMOST As Integer = &H40000
        Select Case MsgBox("Are you sure to shutdown your system?", MsgBoxStyle.YesNo Or MB_TOPMOST, "Shutdown")
            Case MsgBoxResult.Yes
                Application.Exit()
        End Select
    End Sub

    Private Sub RestartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem.Click
        Const MB_TOPMOST As Integer = &H40000
        Select Case MsgBox("Are you sure to restart your system?", MsgBoxStyle.YesNo Or MB_TOPMOST, "Restart")
            Case MsgBoxResult.Yes
                Application.Restart()
        End Select
    End Sub

    Private Sub LogOffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOffToolStripMenuItem.Click
        Const MB_TOPMOST As Integer = &H40000
        Select Case MsgBox("Are you sure to log off you from system?", MsgBoxStyle.YesNo Or MB_TOPMOST, "Log Off")
            Case MsgBoxResult.Yes
                My.Settings.AreLogin = False
                WorkSpace.PCBaOSToolStripMenuItem.Enabled = False
                Password.ShowDialog()
        End Select
    End Sub

    Private Sub LogOffToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOffToolStripMenuItem.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Log off you from system"
    End Sub

    Private Sub RestartToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Restart your PC"
    End Sub

    Private Sub ShutdownToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownToolStripMenuItem.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Shutdown your PC"
    End Sub

    Private Sub Button5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.MouseLeave, Button4.MouseLeave, Button3.MouseLeave, Button2.MouseLeave, Button1.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub Button2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Open clocks to see time"
    End Sub

    Private Sub Button3_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Useful sidebar application to quickly set volume, check internet connection or write to-do list"
    End Sub

    Private Sub Button4_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Main settings menu to control your PC"
    End Sub

    Private Sub Button5_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button5.MouseDown
        If e.Button = MouseButtons.Right Then
            Const MB_TOPMOST As Integer = &H40000
            Select Case MsgBox("Are you sure to shutdown your system?", MsgBoxStyle.YesNo Or MB_TOPMOST, "Shutdown")
                Case MsgBoxResult.Yes
                    Application.Exit()
            End Select
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class