Imports System.Runtime.InteropServices
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Management

Public Class settings
    ' Constants
    Private Const MB_TOPMOST As Integer = &H40000
    Private Const REGISTRY_CPU_PATH As String = "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0\ProcessorNameString"
    Private Const REGISTRY_GPU_PATH As String = "HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Control\Class\{4d36e968-e325-11ce-bfc1-08002be10318}\0000\AdapterDesc"

    Dim BGimage As Object

    ' Add at the class level
    Private startupTab As String = ""

    ' Add a public method to set the startup tab
    Public Sub SetStartupTab(ByVal tabName As String)
        startupTab = tabName
    End Sub

    ' Helper method to safely read registry values
    Private Function GetRegistryValue(ByVal path As String, ByVal defaultValue As String) As String
        Try
            Return CreateObject("WScript.Shell").RegRead(path)
        Catch ex As Exception
            Return defaultValue
        End Try
    End Function

    ' Helper method to update notification
    Private Sub UpdateNotification(ByVal message As String)
        Notifications.ListBox1.Items.Add(message)
    End Sub

    ' Helper method to show confirmation dialog
    Private Function ShowConfirmationDialog(ByVal message As String, ByVal title As String) As DialogResult
        Return MessageBox.Show(Nothing, message, title, MessageBoxButtons.OKCancel,
                            MessageBoxIcon.None, MessageBoxDefaultButton.Button2,
                            MessageBoxOptions.DefaultDesktopOnly)
    End Function

    Private Sub settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ' Load system information
            LoadSystemInformation()

            ' Load user settings
            LoadUserSettings()

            ' Load display settings
            LoadDisplaySettings()

            ' Load application settings
            LoadApplicationSettings()
        Catch ex As Exception
            MessageBox.Show("Error loading settings: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ' Select tab if startupTab is set
        If Not String.IsNullOrEmpty(startupTab) Then
            Select Case startupTab.ToLower()
                Case "computer info"
                    TabControl1.SelectedTab = TabPage1 ' Adjust to your actual tab names
                Case "system"
                    TabControl1.SelectedTab = TabPage4
                Case "theme"
                    TabControl1.SelectedTab = TabPage2
                Case "user account"
                    TabControl1.SelectedTab = TabPage3
                Case "time and region"
                    TabControl1.SelectedTab = TabPage5
            End Select
        End If
    End Sub

    Private Sub LoadSystemInformation()
        ' Cache CPU and GPU info in My.Settings
        If String.IsNullOrEmpty(My.Settings.CPUName) Then
            My.Settings.CPUName = GetCPUName()
            My.Settings.Save()
        End If
        If String.IsNullOrEmpty(My.Settings.GPUName) Then
            My.Settings.GPUName = GetGPUName()
            My.Settings.Save()
        End If
        Label4.Text = My.Settings.CPUName
        Label5.Text = My.Settings.GPUName
        Label6.Text = (CDbl(My.Computer.Info.TotalPhysicalMemory) / 1024 / 1024 / 1024).ToString("##.#GB")
        Label8.Text = (CDbl(My.Computer.Info.TotalVirtualMemory) / 1024 / 1024 / 1024).ToString("##.#GB")
        Label28.Text = "OS Launched: " & My.Settings.OSLaunched & " times"
    End Sub

    ' Helper function to get CPU name using WMI
    Private Function GetCPUName() As String
        Try
            Dim cpuName As String = "Unknown CPU"
            Dim searcher As New System.Management.ManagementObjectSearcher("select Name from Win32_Processor")
            For Each obj As System.Management.ManagementObject In searcher.Get()
                cpuName = obj("Name").ToString()
                Exit For
            Next
            Return cpuName
        Catch ex As Exception
            Return "Unknown CPU"
        End Try
    End Function

    ' Helper function to get GPU name using WMI
    Private Function GetGPUName() As String
        Try
            Dim gpuName As String = "Unknown GPU"
            Dim searcher As New System.Management.ManagementObjectSearcher("select Name from Win32_VideoController")
            For Each obj As System.Management.ManagementObject In searcher.Get()
                gpuName = obj("Name").ToString()
                Exit For
            Next
            Return gpuName
        Catch ex As Exception
            Return "Unknown GPU"
        End Try
    End Function

    Private Sub LoadUserSettings()
        Label10.Text = My.Settings.UserName
        Label14.Text = My.Settings.UserHint
        TextBox4.Text = My.Settings.AFRandomFactSpeed.ToString()
        Label18.Text = "kIus Personal Computer Basic Operating System " & My.Settings.Version

        ' Load user picture
        LoadUserPicture()

        ' Load password status
        Label13.Text = If(String.IsNullOrEmpty(My.Settings.UserPass), "(No Password)", "●●●●●●●●")
    End Sub

    Private Sub LoadUserPicture()
        If My.Settings.UserPicture = "0" Then
            PictureBox2.Image = My.Resources.user1
        Else
            Try
                PictureBox2.Image = Image.FromFile(My.Settings.UserPicture.ToString)
                PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
            Catch ex As Exception
                PictureBox2.Image = My.Resources.user1
            End Try
        End If
    End Sub

    Private Sub LoadDisplaySettings()
        ' Set wallpaper layout
        Select Case My.Settings.WallpaperType
            Case "Stretch"
                ComboBox3.Text = "Stretch"
                WorkSpace.BackgroundImageLayout = ImageLayout.Stretch
            Case "Tile"
                ComboBox3.Text = "Tile"
                WorkSpace.BackgroundImageLayout = ImageLayout.Tile
            Case "Center"
                ComboBox3.Text = "Center"
                WorkSpace.BackgroundImageLayout = ImageLayout.Center
            Case "Zoom"
                ComboBox3.Text = "Zoom"
                WorkSpace.BackgroundImageLayout = ImageLayout.Zoom
        End Select

        ' Set date format
        Select Case My.Settings.DateFormat
            Case "1"
                ComboBox1.Text = "dd/mm/yyyy"
            Case "2"
                ComboBox1.Text = "mm/dd/yyyy"
            Case "3"
                ComboBox1.Text = "yyyy/mm/dd"
        End Select
    End Sub

    Private Sub LoadApplicationSettings()
        ' Set toggle states
        RoundedIconsToggle.Checked = My.Settings.AFRoundedIcons
        RandomFactToggle.Checked = My.Settings.AFRandomFact
        ShowTaskbarToggle.Checked = My.Settings.TaskbarShow
        StartupClockToggle.Checked = My.Settings.ShowClock
        StartupSoundToggle.Checked = My.Settings.StartupSound
        ShowWelcomeToggle.Checked = My.Settings.WelcomeText
        ClockFormatToggle.Checked = My.Settings.Use24ClockFormat

        ' Set search engine
        Select Case My.Settings.SearchEngine
            Case "Google"
                ComboBox4.Text = "Google"
            Case "Bing"
                ComboBox4.Text = "Bing"
            Case "Yahoo"
                ComboBox4.Text = "Yahoo!"
            Case "Duck"
                ComboBox4.Text = "DuckDuckGo"
        End Select
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(CreateObject("WScript.Shell").RegRead("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0\ProcessorNameString"))
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not VerifyCurrentPassword() Then Return
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Username cannot be empty", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            My.Settings.UserName = TextBox1.Text.Trim()
            WorkSpace.Label1.Text = "Welcome, " & My.Settings.UserName
            Label10.Text = My.Settings.UserName
            My.Settings.Save()
            UpdateNotification("Username successfully updated")
        Catch ex As Exception
            MessageBox.Show("Error updating username: " & ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    ' Public function to show password verification dialog
    Public Function VerifyCurrentPassword() As Boolean
        Using verifyForm As New Form()
            verifyForm.Text = "Verify Current Password"
            verifyForm.FormBorderStyle = FormBorderStyle.FixedDialog
            verifyForm.StartPosition = FormStartPosition.CenterParent
            verifyForm.Width = 350
            verifyForm.Height = 180
            verifyForm.MaximizeBox = False
            verifyForm.MinimizeBox = False
            verifyForm.ShowIcon = True
            Try
                verifyForm.Icon = System.Drawing.Icon.FromHandle(My.Resources.logoff.GetHicon())
            Catch ex As Exception
                ' If icon cannot be set, ignore or log as needed
            End Try

            Dim lbl As New Label()
            lbl.Text = "Enter your current password:"
            lbl.AutoSize = True
            lbl.Top = 20
            lbl.Left = 20

            Dim txtCurrentPass As New TextBox()
            txtCurrentPass.UseSystemPasswordChar = True
            txtCurrentPass.Width = 200
            txtCurrentPass.Top = lbl.Bottom + 10
            txtCurrentPass.Left = 20

            Dim btnOK As New Button()
            btnOK.Text = "OK"
            btnOK.DialogResult = DialogResult.OK
            btnOK.Top = txtCurrentPass.Bottom + 20
            btnOK.Left = 20

            Dim btnCancel As New Button()
            btnCancel.Text = "Cancel"
            btnCancel.DialogResult = DialogResult.Cancel
            btnCancel.Top = txtCurrentPass.Bottom + 20
            btnCancel.Left = btnOK.Right + 10

            verifyForm.Controls.Add(lbl)
            verifyForm.Controls.Add(txtCurrentPass)
            verifyForm.Controls.Add(btnOK)
            verifyForm.Controls.Add(btnCancel)

            verifyForm.AcceptButton = btnOK
            verifyForm.CancelButton = btnCancel

            If verifyForm.ShowDialog(Me) = DialogResult.OK Then
                If txtCurrentPass.Text = My.Settings.UserPass Then
                    Return True
                Else
                    MessageBox.Show("Current password is incorrect.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            Else
                Return False
            End If
        End Using
    End Function

    ' Update Button2_Click to use the new function
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' Show a password verification form before allowing password change
        If Not VerifyCurrentPassword() Then Return
        Try
            My.Settings.UserPass = TextBox2.Text.Trim()
            My.Settings.Save()
            Label13.Text = If(String.IsNullOrEmpty(My.Settings.UserPass), "(No Password)", "●●●●●●●●")
            MessageBox.Show("Password successfully updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            UpdateNotification("Password successfully updated")
        Catch ex As Exception
            MessageBox.Show("Error updating password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Not VerifyCurrentPassword() Then Return
        Try
            My.Settings.UserHint = TextBox3.Text.Trim()
            My.Settings.Save()
            Label14.Text = My.Settings.UserHint
            UpdateNotification("Password hint successfully updated")
        Catch ex As Exception
            MessageBox.Show("Error updating password hint: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub CloseToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Exit the application"
    End Sub

    Private Sub CloseToolStripMenuItem_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub CheckBox1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Show Quick Access on Startup"
    End Sub

    Private Sub CheckBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub CheckBox2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Show Clocks on Startup"
    End Sub

    Private Sub CheckBox3_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Show WorkBar on Startup"
    End Sub

    Private Sub ComboBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.MouseLeave, Button5.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub ComboBox1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Change WorkForm Color"
    End Sub

    Private Sub ComboBox2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Change WorkBar Color"
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave, Button2.MouseLeave, Button1.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub Button1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Update Username"
    End Sub

    Private Sub Button2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Update Password"
    End Sub

    Private Sub Button3_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Update Hint"
    End Sub

    Private Sub CheckBox4_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Hide this panel"
    End Sub

    Private Sub CheckBox5_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Hide Welcome Text on WorkSpace"
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim result As DialogResult = OpenFileDialog1.ShowDialog()
            If result = DialogResult.OK AndAlso Not String.IsNullOrEmpty(OpenFileDialog1.FileName) Then
                Using newImage As Image = Image.FromFile(OpenFileDialog1.FileName)
                    WorkSpace.BackgroundImage = New Bitmap(newImage)
                    WorkSpace.BackgroundImageLayout = ImageLayout.Stretch
                    My.Settings.BGimage = OpenFileDialog1.FileName
                    My.Settings.Save()
                    UpdateNotification("Wallpaper successfully updated")
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating wallpaper: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.MouseEnter, Button5.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Browse file for background picture"
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub CheckBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Private Sub ComboBox4_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Search engine used in application menu"
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Try
            Select Case ComboBox4.Text
                Case "Google"
                    My.Settings.SearchEngine = "Google"
                Case "Bing"
                    My.Settings.SearchEngine = "Bing"
                Case "Yahoo!"
                    My.Settings.SearchEngine = "Yahoo"
                Case "DuckDuckGo"
                    My.Settings.SearchEngine = "Duck"
            End Select
            My.Settings.Save()
            UpdateNotification("Search engine successfully updated")
        Catch ex As Exception
            MessageBox.Show("Error updating search engine: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Try
            Select Case ComboBox3.Text
                Case "Stretch"
                    WorkSpace.BackgroundImageLayout = ImageLayout.Stretch
                    My.Settings.WallpaperType = "Stretch"
                Case "Tile"
                    WorkSpace.BackgroundImageLayout = ImageLayout.Tile
                    My.Settings.WallpaperType = "Tile"
                Case "Center"
                    WorkSpace.BackgroundImageLayout = ImageLayout.Center
                    My.Settings.WallpaperType = "Center"
                Case "Zoom"
                    WorkSpace.BackgroundImageLayout = ImageLayout.Zoom
                    My.Settings.WallpaperType = "Zoom"
            End Select
            My.Settings.Save()
            UpdateNotification("Wallpaper layout successfully updated")
        Catch ex As Exception
            MessageBox.Show("Error updating wallpaper layout: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            If WorkSpace.BackgroundImage IsNot Nothing Then
                WorkSpace.BackgroundImage.Dispose()
                WorkSpace.BackgroundImage = Nothing
            End If
            My.Settings.BGimage = ""
            My.Settings.Save()
            UpdateNotification("Wallpaper successfully removed")
        Catch ex As Exception
            MessageBox.Show("Error removing wallpaper: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Select Case MsgBox("Are you sure you want to reset all system data?",
                         MsgBoxStyle.YesNo Or MB_TOPMOST, "PCBaOS System")
            Case MsgBoxResult.Yes
                ResetSystemData()
        End Select
    End Sub

    Private Sub ResetSystemData()
        Dim userInput As String = Nothing

        Do
            userInput = InputBox("Please enter your password to process reset all system data",
                               "Input Required")
            If userInput = "" Then Exit Do
        Loop Until userInput IsNot Nothing

        If userInput = My.Settings.UserPass OrElse String.IsNullOrEmpty(My.Settings.UserPass) Then
            Try
                If ShowConfirmationDialog("Do you want to process reset all system data?" & vbNewLine &
                                        "!!! This process is irreversible. !!!", "Confirmation") = DialogResult.OK Then
                    My.Settings.Reset()
                    My.Settings.Save()
                    MessageBox.Show("System data has been successfully reset.", "Reset Successful",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Application.Restart()
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred during the reset process: " & ex.Message,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf userInput IsNot Nothing Then
            MessageBox.Show(Nothing, "Password isn't correct, please enter correct password.",
                          "Password Incorrect", MessageBoxButtons.OK, MessageBoxIcon.None,
                          MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Dim colorDialog As New ColorDialog()
            colorDialog.Color = My.Settings.ApplicationMenuColor
            If colorDialog.ShowDialog() = DialogResult.OK Then
                My.Settings.ApplicationMenuColor = colorDialog.Color
                My.Settings.Save()
                UpdateNotification("Application menu color successfully updated")
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating application menu color: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim colorDialog As New ColorDialog()
        If colorDialog.ShowDialog() = DialogResult.OK Then
            My.Settings.WorkColor = colorDialog.Color
            My.Settings.Save()
            Notifications.ListBox1.Items.Add("Successfully updated color for WorkSpace.")
        End If
    End Sub

    Private Sub QuickAccessToggle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub QuickAccessToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Toggle2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub StartupClockToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartupClockToggle.CheckedChanged
        If StartupClockToggle.Checked = True Then
            My.Settings.ShowClock = True
            Notifications.ListBox1.Items.Add("Successfully updated ShowClocks setting.")
        Else
            My.Settings.ShowClock = False
            Notifications.ListBox1.Items.Add("Successfully updated ShowClocks setting.")
        End If
    End Sub

    Private Sub ShowWelcomeToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowWelcomeToggle.CheckedChanged
        If ShowWelcomeToggle.Checked = True Then
            My.Settings.WelcomeText = True
            WorkSpace.Label1.Visible = True
            Notifications.ListBox1.Items.Add("Successfully updated ShowWelcome setting.")
        Else
            My.Settings.WelcomeText = False
            WorkSpace.Label1.Visible = False
            Notifications.ListBox1.Items.Add("Successfully updated ShowWelcome setting.")
        End If
    End Sub

    Private Sub Toggle1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartupSoundToggle.CheckedChanged
        If StartupSoundToggle.Checked = True Then
            My.Settings.StartupSound = True
            Notifications.ListBox1.Items.Add("Successfully updated StartupSound setting.")
        Else
            My.Settings.StartupSound = False
            Notifications.ListBox1.Items.Add("Successfully updated StartupSound setting.")
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog
        If result = Windows.Forms.DialogResult.OK Then
            If (OpenFileDialog1.FileName IsNot Nothing) Or (OpenFileDialog1.FileName <> String.Empty) Then

                ApplicationFolder.UserPictureBox.Image = Image.FromFile(OpenFileDialog1.FileName)
                ApplicationFolder.UserPictureBox.SizeMode = PictureBoxSizeMode.StretchImage

                PictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName)
                PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage

                Notifications.ListBox1.Items.Add("Successfully updated user profile picture.")

                My.Settings.UserPicture = OpenFileDialog1.FileName.ToString
            End If
        End If

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        My.Settings.UserPicture = "0"
        PictureBox2.Image = My.Resources.user1
        Notifications.ListBox1.Items.Add("Successfully updated user profile picture.")
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        ApplicationVariables.Show()
    End Sub

    Private Sub Toggle1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoundedIconsToggle.CheckedChanged
        If RoundedIconsToggle.Checked = True Then
            My.Settings.AFRoundedIcons = True
            Notifications.ListBox1.Items.Add("Successfully updated AFRoundedIcons setting.")
        Else
            My.Settings.AFRoundedIcons = False
            Notifications.ListBox1.Items.Add("Successfully updated AFRoundedIcons setting.")
        End If
    End Sub

    Private Sub Toggle2_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandomFactToggle.CheckedChanged
        If RandomFactToggle.Checked = True Then
            My.Settings.AFRandomFact = True
            Notifications.ListBox1.Items.Add("Successfully updated AFRandomFact setting.")
        Else
            My.Settings.AFRandomFact = False
            Notifications.ListBox1.Items.Add("Successfully updated AFRandomFact setting.")
        End If
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        My.Settings.AFRandomFactSpeed = TextBox4.Text
        Notifications.ListBox1.Items.Add("Successfully updated AFRandomFactSpeed setting.")
        My.Settings.Save()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        CustomApplications.Show()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Button8.Enabled = CheckBox1.Checked
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        LogInLog.Show()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        ShutdownLog.Show()
    End Sub

    Private Sub ClockFormatToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClockFormatToggle.CheckedChanged
        If ClockFormatToggle.Checked = True Then
            My.Settings.Use24ClockFormat = True
            Notifications.ListBox1.Items.Add("Successfully updated Use24ClockFormat setting.")
        Else
            My.Settings.Use24ClockFormat = False
            Notifications.ListBox1.Items.Add("Successfully updated Use24ClockFormat setting.")
        End If
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "dd/mm/yyyy" Then
            My.Settings.DateFormat = "1"
        End If
        If ComboBox1.Text = "mm/dd/yyyy" Then
            My.Settings.DateFormat = "2"
        End If
        If ComboBox1.Text = "yyyy/mm/dd" Then
            My.Settings.DateFormat = "3"
        End If
    End Sub

    Private Sub ShowTaskbarToggle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowTaskbarToggle.CheckedChanged
        If ShowTaskbarToggle.Checked = True Then
            My.Settings.TaskbarShow = True
            WorkSpace.TaskbarPanel.Visible = True
            WorkSpace.TaskbarPanel.Enabled = True
            Notifications.ListBox1.Items.Add("Successfully updated TaskbarShow setting.")
        Else
            My.Settings.TaskbarShow = False
            WorkSpace.TaskbarPanel.Visible = False
            WorkSpace.TaskbarPanel.Enabled = False
            Notifications.ListBox1.Items.Add("Successfully updated TaskbarShow setting.")
        End If
    End Sub
End Class