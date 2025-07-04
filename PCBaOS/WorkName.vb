Public Class WorkName

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged, TextBox2.TextChanged
        If TextBox1.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Const MB_TOPMOST As Integer = &H40000
        Select Case MsgBox("Are you accept PCBaOS license agreement?", MsgBoxStyle.YesNo Or MB_TOPMOST, "PCBaOS System")
            Case MsgBoxResult.Yes
                My.Settings.UserName = TextBox1.Text
                My.Settings.UserPass = TextBox2.Text
                WorkSpace.Label1.Text = "Welcome, " & My.Settings.UserName
                Me.Close()
        End Select
    End Sub

    Private Sub WorkName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not My.Settings.UserName = "" Then
            Me.Close()
        End If
    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub RestartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem.Click
        Application.Restart()
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Const MB_TOPMOST As Integer = &H40000
            Select Case MsgBox("Are you accept PCBaOS license agreement?", MsgBoxStyle.YesNo Or MB_TOPMOST, "PCBaOS System")
                Case MsgBoxResult.Yes
                    My.Settings.UserName = TextBox1.Text
                    My.Settings.UserPass = TextBox2.Text
                    WorkSpace.Label1.Text = "Welcome, " & My.Settings.UserName
                    Me.Close()
            End Select
        End If
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            My.Settings.UserName = TextBox1.Text
            My.Settings.UserPass = TextBox2.Text
            WorkSpace.Label1.Text = "Welcome, " & My.Settings.UserName
            Clocks.Show()
            WorkSpace.PCBaOSToolStripMenuItem.Enabled = True
            Me.Close()
        End If
    End Sub

    Private Sub WorkName_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            My.Settings.UserName = TextBox1.Text
            My.Settings.UserPass = TextBox2.Text
            WorkSpace.Label1.Text = "Welcome, " & My.Settings.UserName
            Clocks.Show()
            WorkSpace.PCBaOSToolStripMenuItem.Enabled = True
            Me.Close()
        End If
    End Sub

    Private Sub ShutdownToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownToolStripMenuItem.MouseEnter
        StatusBarTooltipHelper.ShowTooltip(Me, "Shutdown your PC")
    End Sub

    Private Sub ShutdownToolStripMenuItem_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownToolStripMenuItem.MouseLeave
        StatusBarTooltipHelper.ClearTooltip(Me)
    End Sub

    Private Sub RestartToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem.MouseEnter
        StatusBarTooltipHelper.ShowTooltip(Me, "Restart your PC")
    End Sub

    Private Sub RestartToolStripMenuItem_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem.MouseLeave
        StatusBarTooltipHelper.ClearTooltip(Me)
    End Sub

    Private Sub Button1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseEnter
        StatusBarTooltipHelper.ShowTooltip(Me, "Finish setup and start using system")
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        StatusBarTooltipHelper.ClearTooltip(Me)
    End Sub

    Private Sub TextBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.MouseLeave, TextBox1.MouseLeave
        StatusBarTooltipHelper.ClearTooltip(Me)
    End Sub

    Private Sub TextBox1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.MouseEnter
        StatusBarTooltipHelper.ShowTooltip(Me, "Enter your username")
    End Sub

    Private Sub TextBox2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.MouseEnter
        StatusBarTooltipHelper.ShowTooltip(Me, "Enter your password")
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim frmLicenseAgreement As New Form

        ' Set form properties
        frmLicenseAgreement.Text = "License Agreement"
        frmLicenseAgreement.Size = New Size(500, 500)
        frmLicenseAgreement.TopMost = True
        frmLicenseAgreement.ShowIcon = False
        frmLicenseAgreement.MinimizeBox = False
        frmLicenseAgreement.MaximizeBox = False
        frmLicenseAgreement.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow

        ' Create textbox for agreement
        Dim txtAgreement As New TextBox
        txtAgreement.Multiline = True
        txtAgreement.ReadOnly = True
        txtAgreement.ScrollBars = ScrollBars.Vertical
        txtAgreement.Dock = DockStyle.Fill
        txtAgreement.Text = "LICENSE AGREEMENT" & vbCrLf & vbCrLf & _
                            "This License Agreement (the ""Agreement"") is entered into between kIus Computer Corporation (""Licensor"") and you (""Licensee"") for the use of kIus Personal Computer Basic Operating System (""PCBaOS"")." & vbCrLf & vbCrLf & _
                            "Grant of License. Subject to the terms and conditions of this Agreement, Licensor grants to Licensee a non-exclusive, non-transferable license to use PCBaOS for personal or business use on a single computer." & vbCrLf & vbCrLf & _
                            "Restrictions on Use. Licensee shall not:" & vbCrLf & _
                            "(a) make copies of PCBaOS except for backup purposes;" & vbCrLf & _
                            "(b) distribute, sell, sublicense, rent, lease, or transfer PCBaOS to any third party;" & vbCrLf & _
                            "(c) reverse engineer, decompile, or disassemble PCBaOS;" & vbCrLf & _
                            "(d) modify or create any derivative works of PCBaOS;" & vbCrLf & _
                            "(e) remove or alter any copyright, trademark, or other proprietary notices from PCBaOS." & vbCrLf & vbCrLf & _
                            "Ownership. PCBaOS and all intellectual property rights, including without limitation copyrights and trademarks, are and shall remain the property of Licensor." & vbCrLf & vbCrLf & _
                            "Termination. This Agreement shall terminate automatically upon any breach by Licensee of any of its terms and conditions. Upon termination, Licensee shall immediately cease all use of PCBaOS and destroy all copies of PCBaOS in its possession or control." & vbCrLf & vbCrLf & _
                            "Disclaimer of Warranties. PCBaOS is provided ""AS IS"" without warranty of any kind, either express or implied, including without limitation any warranty of merchantability, fitness for a particular purpose, or non-infringement." & vbCrLf & vbCrLf & _
                            "Limitation of Liability. In no event shall Licensor be liable for any damages arising out of the use or inability to use PCBaOS, including without limitation direct, indirect, incidental, special, or consequential damages." & vbCrLf & vbCrLf & _
                            "Governing Law. This Agreement shall be governed by and construed in accordance with the laws of the State of California." & vbCrLf & vbCrLf & _
                            "Entire Agreement. This Agreement constitutes the entire agreement between the parties and supersedes all prior or contemporaneous oral or written agreements or representations, if any, regarding PCBaOS."

        ' Add textbox to form
        frmLicenseAgreement.Controls.Add(txtAgreement)

        ' Show form as dialog
        frmLicenseAgreement.ShowDialog()
    End Sub
End Class