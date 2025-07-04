Public Class version

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub version_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = "Copyrights © 2023 kIus Computers Corporation" & vbNewLine & "Version " & My.Settings.Version & vbNewLine & "Based on Diceion's Core's branch PCphase" & vbNewLine & "Launched on PCBaOS Recover Project Emu " & My.Settings.EmuVer
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
        frmLicenseAgreement.Show()
    End Sub
End Class