Public Class Desktop

    Private Sub Desktop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(2, 87)
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CloseToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Exit the application"
    End Sub

    Private Sub CloseToolStripMenuItem_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub Desktop_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.BackColor = My.Settings.DesktopColor
    End Sub
End Class