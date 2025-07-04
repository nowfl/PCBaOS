Imports System.Runtime.InteropServices

Public Class Password

    Private Const MaxFailedAttempts As Integer = 5
    Private Const LockoutMinutes As Integer = 3

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        doSame()
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            TextBox2.UseSystemPasswordChar = False
        ElseIf CheckBox1.CheckState = CheckState.Unchecked Then
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub RestartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem.Click
        Application.Restart()
    End Sub

    <DllImport("gdi32.dll", EntryPoint:="CreateRoundRectRgn")> _
    Private Shared Function CreateRoundRectRgn(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal cx As Integer, ByVal cy As Integer) As IntPtr
    End Function
    Private Sub Password_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.AFRoundedIcons = True Then
            UserPictureBox.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, UserPictureBox.Width, UserPictureBox.Height, 15, 15))
        Else

        End If
        If Not My.Settings.UserHint = "" Then
            Label1.Text = "Hint: " & My.Settings.UserHint
        Else
            LinkLabel1.Visible = False
        End If
        My.Settings.AreLogin = False
        If My.Settings.UserPicture = "0" Then

        Else
            Try
                UserPictureBox.Image = Image.FromFile(My.Settings.UserPicture.ToString)
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub Password_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

    End Sub

    Private Sub Button1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyDown

    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            doSame()
        End If
    End Sub

    Private Function doSame()
        ' Check if account is locked
        If My.Settings.AccountLockedUntil > Now Then
            Dim minutesLeft As Integer = CInt(Math.Ceiling((My.Settings.AccountLockedUntil - Now).TotalMinutes))
            MsgBox("Account is locked. Try again in " & minutesLeft & " minute(s).", MsgBoxStyle.OkOnly, "Account Locked")
        End If
        If TextBox2.Text = My.Settings.UserPass Then
            ' Success: reset failed attempts and lockout
            My.Settings.FailedLoginAttempts = 0
            My.Settings.AccountLockedUntil = Date.MinValue
            My.Settings.Save()
            If My.Settings.ShowClock = True Then
                Clocks.Show()
            End If
            If My.Settings.ShowDesktop = True Then
                QuickAccess.Show()
            End If
            My.Settings.AreLogin = True
            WorkSpace.PCBaOSToolStripMenuItem.Enabled = True
            WorkSpace.StatusStrip1.Enabled = True
            WorkSpace.TaskbarPanel.Enabled = True
            WorkSpace.Vol100ToolStripMenuItem.Enabled = True
            If String.IsNullOrEmpty(My.Settings.idkey) Then
                Dim chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
                Dim rnd As New Random()
                Dim result As New String(Enumerable.Repeat(chars, 12).Select(Function(s) s(rnd.Next(s.Length))).ToArray())
                My.Settings.idkey = result
            End If
            If My.Settings.StartupSound = True Then
                My.Computer.Audio.Play(My.Resources.msg, AudioPlayMode.Background)
            End If
            Me.Close()
        Else
            ' Failure: increment failed attempts
            My.Settings.FailedLoginAttempts += 1
            If My.Settings.FailedLoginAttempts >= MaxFailedAttempts Then
                My.Settings.AccountLockedUntil = Now.AddMinutes(LockoutMinutes)
                MsgBox("Too many failed attempts. Account locked for " & LockoutMinutes & " minutes.", MsgBoxStyle.OkOnly, "Account Locked")
            Else
                MsgBox("Password isn't correct, please enter correct password.", MsgBoxStyle.OkOnly, "Password Incorrect")
            End If
            My.Settings.Save()
        End If
    End Function

    Private Sub Password_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Prevent closing with Alt+F4 or X unless logged in or system is exiting
        If Not My.Settings.AreLogin Then
            If e.CloseReason = CloseReason.UserClosing Then
                MsgBox("You must log in to use the system.", MsgBoxStyle.OkOnly, "Login Required")
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Button1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseEnter
        StatusBarTooltipHelper.ShowTooltip(Me, "Log in your system")
    End Sub

    Private Sub CheckBox1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.MouseEnter
        StatusBarTooltipHelper.ShowTooltip(Me, "Show hidden password you written")
    End Sub

    Private Sub ShutdownToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownToolStripMenuItem.MouseEnter
        StatusBarTooltipHelper.ShowTooltip(Me, "Shutdown your PC")
    End Sub

    Private Sub RestartToolStripMenuItem_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.MouseLeave, ShutdownToolStripMenuItem.MouseLeave, RestartToolStripMenuItem.MouseLeave, CheckBox1.MouseLeave, Button1.MouseLeave
        StatusBarTooltipHelper.ClearTooltip(Me)
    End Sub

    Private Sub TextBox2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.MouseEnter
        StatusBarTooltipHelper.ShowTooltip(Me, "Enter your password here")
    End Sub

    Private Sub RestartToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem.MouseEnter
        StatusBarTooltipHelper.ShowTooltip(Me, "Restart your PC")
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        LinkLabel1.Visible = False
        Label1.Visible = True
    End Sub

    Private Sub Password_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        If My.Settings.GlobalSecurityUse = False Then
            My.Settings.AreLogin = True
            WorkSpace.PCBaOSToolStripMenuItem.Enabled = True
            Me.Close()
        Else

        End If

    End Sub
End Class