Imports System.Drawing
Imports System.Windows.Forms

Public Class commandepic
    ' Constants for command types
    Private Const CMD_SYSTEM As String = "com.system."
    Private Const CMD_USER As String = "class user"
    Private Const CMD_STARTUP As String = "class startup"
    Private Const CMD_SECURITY As String = "class system globalsecurityuse"

    ' Helper method to update output
    Private Sub UpdateOutput(message As String)
        outputbox.Items.Add(message)
    End Sub

    ' Helper method to show error
    Private Sub ShowError(message As String)
        MessageBox.Show(message, "Command Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ' Helper method to launch application
    Private Sub LaunchApplication(appName As String, appForm As Form)
        Try
            appForm.Show()
            UpdateOutput(String.Format("Application {0} successfully launched", appName))
        Catch ex As Exception
            ShowError(String.Format("Error launching {0}: {1}", appName, ex.Message))
        End Try
    End Sub

    ' Helper method to handle system commands
    Private Sub HandleSystemCommand(command As String)
        Select Case command
            Case "applicationfolder"
                LaunchApplication("Application Folder", ApplicationFolder)
            Case "browser"
                LaunchApplication("Browser", Browser)
            Case "calc"
                LaunchApplication("Calculator", calc)
            Case "audioplayer"
                LaunchApplication("Audio Player", AudioPlayer)
            Case "calendar"
                LaunchApplication("Calendar", Calendar)
            Case "clocks"
                LaunchApplication("Clocks", Clocks)
            Case "food"
                LaunchApplication("Food Expert", FoodExpert)
            Case "imgview"
                LaunchApplication("Image Viewer", ImgView)
            Case "notes"
                LaunchApplication("Notes", Notes)
            Case "imgmanip"
                LaunchApplication("Image Manipulator", Paint99)
            Case "powertools"
                LaunchApplication("Power Tools", PowerTools)
            Case "settings"
                LaunchApplication("Settings", settings)
            Case "table"
                LaunchApplication("Table", table)
            Case "test"
                LaunchApplication("Test", teess)
            Case "textpad"
                LaunchApplication("Text Pad", Textpad)
            Case "version"
                LaunchApplication("Version", version)
            Case Else
                ShowError("Unknown system command")
        End Select
    End Sub

    ' Helper method to handle user commands
    Private Sub HandleUserCommand(command As String)
        Try
            Select Case command
                Case "username"
                    If My.Settings.UserPass = "" OrElse TextBox1.Text = "username " & My.Settings.UserPass Then
                        My.Settings.UserName = TextBox2.Text
                        UpdateOutput("Username successfully updated")
                    Else
                        ShowError("Incorrect current password. Please enter your current password in format: username <current password> and new username in second textbox")
                    End If
                Case "userpass"
                    ' Require current password in TextBox1 to change password
                    If My.Settings.UserPass = "" OrElse TextBox1.Text = "userpass " & My.Settings.UserPass Then
                        My.Settings.UserPass = TextBox2.Text
                        UpdateOutput("Password successfully updated")
                    Else
                        ShowError("Incorrect current password. Please enter your current password in format: userpass <current password> and new password in second textbox")
                    End If
                Case "userhint"
                    If My.Settings.UserPass = "" OrElse TextBox1.Text = "userhint " & My.Settings.UserPass Then
                        My.Settings.UserHint = TextBox2.Text
                        UpdateOutput("Password hint successfully updated")
                    Else
                        ShowError("Incorrect current password. Please enter your current password in format: userhint <current password> and new password hint in second textbox")
                    End If
                Case "statusbar"
                    My.Settings.StatusBar = TextBox2.Text
                    UpdateOutput("Status bar setting updated")
                Case "welcometext"
                    My.Settings.WelcomeText = TextBox2.Text
                    UpdateOutput("Welcome text setting updated")
                Case "calendarwallpaper"
                    My.Settings.CalendarWallpaper = TextBox2.Text
                    UpdateOutput("Calendar wallpaper updated")
                Case "bgimage"
                    My.Settings.BGimage = TextBox2.Text
                    UpdateOutput("Background image updated")
                Case "wallpapertype"
                    My.Settings.WallpaperType = TextBox2.Text
                    UpdateOutput("Wallpaper type updated")
                Case Else
                    ShowError("Unknown user command")
            End Select
            My.Settings.Save()
        Catch ex As Exception
            ShowError(String.Format("Error updating user settings: {0}", ex.Message))
        End Try
    End Sub

    ' Helper method to handle startup commands
    Private Sub HandleStartupCommand(command As String)
        Try
            Select Case command
                Case "showclock"
                    My.Settings.ShowClock = TextBox2.Text
                    UpdateOutput("Show clock setting updated")
                Case "showdesktop"
                    My.Settings.ShowDesktop = TextBox2.Text
                    UpdateOutput("Show desktop setting updated")
                Case Else
                    ShowError("Unknown startup command")
            End Select
            My.Settings.Save()
        Catch ex As Exception
            ShowError(String.Format("Error updating startup settings: {0}", ex.Message))
        End Try
    End Sub

    Public Sub doSame()
        Try
            Dim command As String = TextBox1.Text.Trim().ToLower()

            ' Handle special commands
            Select Case command
                Case "crash"
                    CrashScreen.Show()
                    Me.Close()
                    Return

                Case "resetapps"
                    If ShowConfirmationDialog("Are you sure you want to reset all applications?", "Reset Applications") = DialogResult.OK Then
                        My.Settings.InstalledApplicationClassSettings.Clear()
                        My.Settings.InstalledApplicationIconDir.Clear()
                        My.Settings.InstalledApplicationNames.Clear()
                        My.Settings.InstalledApplications.Clear()
                        My.Settings.InstalledApplicationColor.Clear()
                        UpdateOutput("All applications have been reset successfully")
                    End If
                    Return

                Case "kermit"
                    ShowKermit()
                    Return

                Case "idkey"
                    UpdateOutput(String.Format("Your IDKey is: {0}", My.Settings.idkey))
                    Return

                Case "ver"
                    UpdateOutput(String.Format("kIus Personal Computer Basic Operating System {0}", My.Settings.Version))
                    Return

                ' --- New action commands ---
                Case "restart", "kill"
                    UpdateOutput("System is restarting...")
                    Application.Restart()
                    Return

                Case "shutdown"
                    UpdateOutput("System is shutting down...")
                    Application.Exit()
                    Return

                Case "closeapp"
                    Dim appName As String = TextBox2.Text.Trim()
                    If appName = "" Then
                        ShowError("Please specify the app name to close in the second box.")
                        Return
                    End If
                    Dim closedAny As Boolean = False
                    For Each frm As Form In Application.OpenForms
                        If frm.Name.ToLower() = appName.ToLower() AndAlso frm IsNot Me Then
                            frm.Close()
                            closedAny = True
                        End If
                    Next
                    If closedAny Then
                        UpdateOutput(String.Format("Application '{0}' closed.", appName))
                    Else
                        ShowError(String.Format("No open application named '{0}' found.", appName))
                    End If
                    Return

                Case "closeall"
                    Dim mainFormName As String = "WorkSpace" ' Change if your main form is named differently
                    Dim formsToClose As New List(Of Form)()
                    For Each frm As Form In Application.OpenForms
                        If frm.Name <> mainFormName AndAlso frm IsNot Me Then
                            formsToClose.Add(frm)
                        End If
                    Next
                    For Each frm As Form In formsToClose
                        frm.Close()
                    Next
                    UpdateOutput("All applications closed.")
                    Return
            End Select

            ' Handle system commands
            If command.StartsWith(CMD_SYSTEM) Then
                HandleSystemCommand(command.Substring(CMD_SYSTEM.Length))
                Return
            End If

            ' Handle user commands
            If command.StartsWith(CMD_USER) Then
                HandleUserCommand(command.Substring(CMD_USER.Length + 1))
                Return
            End If

            ' Handle startup commands
            If command.StartsWith(CMD_STARTUP) Then
                HandleStartupCommand(command.Substring(CMD_STARTUP.Length + 1))
                Return
            End If

            ' Handle security commands
            If command = CMD_SECURITY Then
                HandleSecurityCommand()
                Return
            End If

            ' Handle geography game command
            If command = "com.jkloz.geographygame" Then
                If My.Settings.GeographyGame Then
                    LaunchApplication("Geography Game", GeographyGame)
                Else
                    ShowError("Geography Game is not installed")
                End If
                Return
            End If

            ShowError("Unknown command")

        Catch ex As Exception
            ShowError(String.Format("Error executing command: {0}", ex.Message))
        Finally
            TextBox1.Text = ""
            TextBox2.Text = ""
        End Try
    End Sub

    Private Sub ShowKermit()
        Try
            Dim frm As New Form()
            frm.TopMost = True
            frm.MaximizeBox = False
            frm.MinimizeBox = False
            frm.ShowIcon = False
            frm.Text = "kermit"

            Dim picBox As New PictureBox()
            picBox.Dock = DockStyle.Fill
            picBox.Image = My.Resources.kermit
            picBox.SizeMode = PictureBoxSizeMode.StretchImage
            frm.Controls.Add(picBox)

            frm.Show()
            UpdateOutput("kermit appears")
        Catch ex As Exception
            ShowError(String.Format("Error showing kermit: {0}", ex.Message))
        End Try
    End Sub

    Private Sub HandleSecurityCommand()
        Try
            My.Settings.GlobalSecurityUse = TextBox2.Text
            If TextBox2.Text = "False" Then
                MessageBox.Show("Warning: Global Security is turned off, your PC can be used by everyone.", 
                              "Global Security", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf TextBox2.Text = "True" Then
                MessageBox.Show("Global Security is turned on, your PC is protected", 
                              "Global Security", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            My.Settings.Save()
            UpdateOutput("Security settings updated successfully")
        Catch ex As Exception
            ShowError(String.Format("Error updating security settings: {0}", ex.Message))
        End Try
    End Sub

    Private Function ShowConfirmationDialog(message As String, title As String) As DialogResult
        Return MessageBox.Show(message, title, MessageBoxButtons.OKCancel, 
                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        doSame()
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown, TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            doSame()
        End If
    End Sub

    Private Sub commandepic_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Initialize any necessary components
    End Sub
End Class