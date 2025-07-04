Public Class JokeWeb

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("JokeWeb" & vbNewLine & "Created by jarry01" & vbNewLine & "Total launched: " & My.Settings.jokewebtotalopened, MsgBoxStyle.OkOnly, "JokeWeb")
    End Sub

    Private Sub JokeWeb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Settings.jokewebtotalopened += 1
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub
End Class