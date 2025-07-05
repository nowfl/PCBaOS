Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Collections.Specialized
Imports System.Text.RegularExpressions
Imports System.IO

Public Class WorkSpace


    ' Constants
    Private Const MB_TOPMOST As Integer = &H40000
    Private Const LOG_FILE As String = "PCBaOS.log"
    Private Const MAX_LOG_SIZE As Integer = 1048576 ' 1MB

    ' DLL Imports with better XML documentation
    ''' <summary>
    ''' Sets the volume for the wave output device
    ''' </summary>
    <DllImport("winmm.dll")>
    Private Shared Function waveOutSetVolume(ByVal hwo As IntPtr, ByVal dwVolume As UInteger) As UInteger
    End Function

    ''' <summary>
    ''' Gets the current volume for the wave output device
    ''' </summary>
    <DllImport("winmm.dll")>
    Private Shared Function waveOutGetVolume(ByVal hwo As IntPtr, ByRef pdwVolume As UInteger) As UInteger
    End Function

    ' Private fields
    Private isLoaded As Boolean = False
    Public arelogged As Boolean = True

    ' New DLL import for SetForegroundWindow
    <DllImport("user32.dll")>
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
    End Function

    ' Add at the class level
    Private lastWindowStates As New Dictionary(Of Form, FormWindowState)()
    Private lastActiveAppForm As Form = Nothing

    ' Add at the class level with other DLL imports
    <DllImport("user32.dll")>
    Private Shared Function GetForegroundWindow() As IntPtr
    End Function

    ' Add at the class level
    Private taskbarOrder As New List(Of String)()
    Private draggingButton As Button = Nothing
    Private dragStartPoint As Point
    Private formInstanceCounter As New Dictionary(Of String, Integer)()
    Private formInstanceMap As New Dictionary(Of String, Form)()

    ' Add at the class level
    Private isDragging As Boolean = False
    Private Const DRAG_THRESHOLD As Integer = 5

    ' Add at class level
    Private lastBatteryPercent As Integer = -1
    Private lastBatteryCharging As Boolean = False

#Region "Volume Control Methods"
    ' Centralized logging method
    Private Sub LogError(ByVal message As String, Optional ByVal ex As Exception = Nothing)
        Try
            ' Check if log file exists and rotate if too large
            If File.Exists(LOG_FILE) AndAlso New FileInfo(LOG_FILE).Length > MAX_LOG_SIZE Then
                File.Move(LOG_FILE, String.Format("PCBaOS_{0:yyyyMMdd_HHmmss}.log", DateTime.Now))
            End If

            ' Format the log message
            Dim logMessage As String = String.Format("[{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message)
            If ex IsNot Nothing Then
                logMessage &= String.Format("{0}Exception: {1}{0}Stack Trace: {2}",
                                          Environment.NewLine, ex.Message, ex.StackTrace)
            End If

            ' Write to log file
            File.AppendAllText(LOG_FILE, logMessage & Environment.NewLine)

            ' Show error to user if needed
            If ex IsNot Nothing Then
                MessageBox.Show(String.Format("An error occurred: {0}{1}Details have been logged.",
                                            message, Environment.NewLine),
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch
            ' If logging fails, at least show the error
            MessageBox.Show(String.Format("An error occurred: {0}", message),
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Gets the application volume as a percentage (0-100)
    ''' </summary>
    Private Function GetApplicationVolume() As Integer
        Try
            Dim vol As UInteger = 0
            waveOutGetVolume(IntPtr.Zero, vol)
            Return CInt((vol And &HFFFF) / (UShort.MaxValue / 100))
        Catch ex As Exception
            LogError("Failed to get application volume", ex)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Sets the application volume to a percentage (0-100)
    ''' </summary>
    Private Sub SetApplicationVolume(ByVal volumePercent As Integer)
        Try
            Dim vol As UInteger = CUInt((UShort.MaxValue / 100) * volumePercent)
            waveOutSetVolume(IntPtr.Zero, CUInt((vol And &HFFFF) Or (vol << 16)))
        Catch ex As Exception
            LogError("Failed to set application volume", ex)
        End Try
    End Sub
#End Region

#Region "Form Lifecycle Events"
    ' Safe form loading
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ' Log system startup
            LogSystemStartup()

            ' Increment OS launch counter
            My.Settings.OSLaunched += 1

            ' Initialize status strip
            InitializeStatusStrip()

            ' Apply user settings
            ApplyUserSettings()

            ' Add timer for auto-updating taskbar
            Dim taskbarTimer As New System.Windows.Forms.Timer()
            taskbarTimer.Interval = 500
            AddHandler taskbarTimer.Tick, AddressOf TaskbarAutoUpdateTimer_Tick
            taskbarTimer.Start()

            ' Restore taskbar order
            RestoreTaskbarOrder()
        Catch ex As Exception
            LogError("Failed to initialize workspace", ex)
        End Try
    End Sub

    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        BootLoad.ShowDialog()
        If BootLoad.ProgressBar2.Value = 100 Then
            InitializeUserInterface()
            WorkName.ShowDialog()
            Password.ShowDialog()
        End If
    End Sub

    ' Safe form closing
    ' Prevent closing the workspace unless the system is actually shutting down (not just restarting)
    Private Sub WorkSpace_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            ' Only log shutdown if the application is really exiting, not restarting
            If e.CloseReason = CloseReason.ApplicationExitCall OrElse e.CloseReason = CloseReason.WindowsShutDown OrElse e.CloseReason = CloseReason.TaskManagerClosing OrElse e.CloseReason = CloseReason.FormOwnerClosing Then
                If My.Settings.ShutdownLog Is Nothing Then
                    My.Settings.ShutdownLog = New StringCollection()
                End If

                My.Settings.ShutdownLog.Add(DateTime.Now.ToString("F"))
                My.Settings.Save()
            End If
        Catch ex As Exception
            LogError("Failed to save shutdown log", ex)
        End Try
    End Sub
#End Region

#Region "UI Initialization Methods"
    ''' <summary>
    ''' Initializes the user interface based on current settings
    ''' </summary>
    Private Sub InitializeUserInterface()
        Label1.Text = "Welcome, " & My.Settings.UserName
        Me.BackColor = My.Settings.WorkColor
        isLoaded = True

        ' Apply visibility settings
        StatusStrip1.Visible = My.Settings.StatusBar
        MenuStrip1.Visible = True
        Label1.Visible = My.Settings.WelcomeText
        TaskbarPanel.Visible = My.Settings.TaskbarShow

        ' Try to load background image
        TryLoadBackgroundImage()
    End Sub

    ''' <summary>
    ''' Initialize the status strip with buttons and handlers
    ''' </summary>
    Private Sub InitializeStatusStrip()
        Dim statusLabel As New ToolStripStatusLabel()
        statusLabel.Spring = True
        StatusStrip1.Items.Add(statusLabel)

        ' Create buttons with proper names and icons
        Dim buttonSearch As New ToolStripButton("") With {.Image = My.Resources.search, .Name = "buttonSearch"}
        Dim buttonSystemOptions As New ToolStripButton("System Options") With {.Image = My.Resources.settings, .Name = "buttonSystemOptions"}
        Dim buttonBrowser As New ToolStripButton("Browser") With {.Image = My.Resources.interneticon, .Name = "buttonBrowser"}
        Dim buttonApplications As New ToolStripButton("Applications") With {.Image = My.Resources.appstore, .Name = "buttonApplications"}

        StatusStrip1.Items.Add(buttonSearch)
        StatusStrip1.Items.Add(buttonSystemOptions)
        StatusStrip1.Items.Add(buttonBrowser)
        StatusStrip1.Items.Add(buttonApplications)

        ' Add event handlers
        AddHandler buttonSearch.Click, AddressOf Button_Search_Click
        AddHandler buttonSystemOptions.Click, AddressOf Button_1_Click
        AddHandler buttonBrowser.Click, AddressOf Button_2_Click
        AddHandler buttonApplications.Click, AddressOf Button_3_Click
        ' Add tooltip handlers
        AddHandler buttonSearch.MouseEnter, Sub(sender, e) StatusBarTooltipHelper.ShowTooltip(Me, "Search your files and apps")
        AddHandler buttonSearch.MouseLeave, Sub(sender, e) StatusBarTooltipHelper.ClearTooltip(Me)
        AddHandler buttonSystemOptions.MouseEnter, Sub(sender, e) StatusBarTooltipHelper.ShowTooltip(Me, "Open system settings")
        AddHandler buttonSystemOptions.MouseLeave, Sub(sender, e) StatusBarTooltipHelper.ClearTooltip(Me)
        AddHandler buttonBrowser.MouseEnter, Sub(sender, e) StatusBarTooltipHelper.ShowTooltip(Me, "Open web browser")
        AddHandler buttonBrowser.MouseLeave, Sub(sender, e) StatusBarTooltipHelper.ClearTooltip(Me)
        AddHandler buttonApplications.MouseEnter, Sub(sender, e) StatusBarTooltipHelper.ShowTooltip(Me, "Open application store")
        AddHandler buttonApplications.MouseLeave, Sub(sender, e) StatusBarTooltipHelper.ClearTooltip(Me)
    End Sub

    ' Safe settings management
    Private Sub ApplyUserSettings()
        Try
            ' Admin settings
            CommandPromptToolStripMenuItem.Visible = My.Settings.IsAdmin

            ' Wallpaper settings
            Select Case My.Settings.WallpaperType
                Case "Stretch"
                    BackgroundImageLayout = ImageLayout.Stretch
                Case "Tile"
                    BackgroundImageLayout = ImageLayout.Tile
                Case "Center"
                    BackgroundImageLayout = ImageLayout.Center
                Case "Zoom"
                    BackgroundImageLayout = ImageLayout.Zoom
                Case Else
                    LogError(String.Format("Invalid wallpaper type: {0}", My.Settings.WallpaperType))
            End Select
        Catch ex As Exception
            LogError("Failed to apply user settings", ex)
        End Try
    End Sub

    ' Safe background image loading
    Private Sub TryLoadBackgroundImage()
        Try
            If Not String.IsNullOrEmpty(My.Settings.BGimage) Then
                If File.Exists(My.Settings.BGimage) Then
                    Using imgStream As New System.IO.FileStream(My.Settings.BGimage, IO.FileMode.Open, IO.FileAccess.Read)
                        Me.BackgroundImage = Image.FromStream(imgStream)
                    End Using
                Else
                    LogError(String.Format("Background image not found: {0}", My.Settings.BGimage))
                End If
            End If
        Catch ex As Exception
            LogError("Failed to load background image", ex)
        End Try
    End Sub
#End Region

#Region "System Operations"
    ''' <summary>
    ''' Logs the system startup in user settings
    ''' </summary>
    Private Sub LogSystemStartup()
        Dim myStringCollection As System.Collections.Specialized.StringCollection

        If My.Settings.LogInLog Is Nothing Then
            myStringCollection = New System.Collections.Specialized.StringCollection()
        Else
            myStringCollection = My.Settings.LogInLog
        End If

        myStringCollection.Add(DateTime.Now.ToString("F"))
        My.Settings.LogInLog = myStringCollection
        My.Settings.Save()
    End Sub

    ' Safe system operations
    Private Sub Shutdown()
        Try
            Select Case MsgBox("Are you sure to shutdown your system?", MsgBoxStyle.YesNo Or MB_TOPMOST, "Shutdown")
                Case MsgBoxResult.Yes
                    LogError("System shutdown initiated by user")
                    Application.Exit()
            End Select
        Catch ex As Exception
            LogError("Failed to shutdown system", ex)
        End Try
    End Sub

    Private Sub Restart()
        Try
            Select Case MsgBox("Are you sure to restart your system?", MsgBoxStyle.YesNo Or MB_TOPMOST, "Restart")
                Case MsgBoxResult.Yes
                    Application.Restart()
            End Select
        Catch ex As Exception
            LogError("Failed to restart system", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Prompt user to confirm log off and log off if confirmed
    ''' </summary>
    Private Sub LogOff()
        Try
            Select Case MsgBox("Are you sure to log off you from system?", MsgBoxStyle.YesNo Or MB_TOPMOST, "Log Off")
                Case MsgBoxResult.Yes
                    CloseAllFormsExcept(Me, "Notifications")
                    PCBaOSToolStripMenuItem.Enabled = False
                    StatusStrip1.Enabled = False
                    Vol100ToolStripMenuItem.Enabled = False
                    TaskbarPanel.Enabled = False
                    Password.ShowDialog()
            End Select
        Catch ex As Exception
            LogError("Failed to log off", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Close all application forms except specified ones
    ''' </summary>
    Private Sub CloseAllFormsExcept(ByVal ParamArray formsToKeep() As Object)
        Dim formsToClose As New List(Of Form)

        For Each frm As Form In Application.OpenForms
            Dim shouldKeep As Boolean = False

            For Each keepForm In formsToKeep
                If frm Is keepForm OrElse (TypeOf keepForm Is String AndAlso frm.Name = keepForm.ToString()) Then
                    shouldKeep = True
                    Exit For
                End If
            Next

            If Not shouldKeep Then
                formsToClose.Add(frm)
            End If
        Next

        For Each frm As Form In formsToClose
            frm.Close()
        Next
    End Sub

    ''' <summary>
    ''' Handle Windows button function based on login state
    ''' </summary>
    Private Sub WindowFunction()
        If My.Settings.AreLogin Then
            CloseAllFormsExcept(Me, "Notifications")
            ApplicationFolder.Close()
        Else
            Password.ShowDialog()
        End If
    End Sub

    ''' <summary>
    ''' Handle Windows function shortcut with confirmation dialog
    ''' </summary>
    Private Sub WindowFunctionShortcut()
        If My.Settings.AreLogin Then
            Select Case MsgBox("Are you sure to close all windows?", MsgBoxStyle.YesNo Or MB_TOPMOST, "Quick Close")
                Case MsgBoxResult.Yes
                    CloseAllFormsExcept(Me, "Notifications")
            End Select
        End If
    End Sub
#End Region

#Region "UI Update Methods"
    ' Add at class level
    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        UpdateTimeAndDate()
        UpdateVolumeDisplay()
        UpdateWindowsButton()
        UpdateAudioPlayerVisibility()
        UpdateBatteryStatus()

        If isLoaded Then
            Label1.Text = "Welcome, " & My.Settings.UserName
            Me.BackColor = My.Settings.WorkColor
        End If
    End Sub

    ' Battery status update
    Private Sub UpdateBatteryStatus()
        Try
            Dim powerStatus = SystemInformation.PowerStatus
            ' Check if battery is present
            If powerStatus.BatteryChargeStatus = BatteryChargeStatus.NoSystemBattery Then
                BatteryToolStripMenuItem.Visible = False
                lastBatteryPercent = -1
                lastBatteryCharging = False
                Return
            Else
                BatteryToolStripMenuItem.Visible = True
            End If
            Dim percent = CInt(powerStatus.BatteryLifePercent * 100)
            Dim charging = (powerStatus.PowerLineStatus = PowerLineStatus.Online)
            Dim iconName As String = ""
            ' Choose icon
            If percent >= 95 Then
                iconName = If(charging, "fullchargingbattery", "fullbattery")
            ElseIf percent >= 75 Then
                iconName = If(charging, "almostfullchargingbattery", "almostfullbattery")
            ElseIf percent >= 50 Then
                iconName = If(charging, "halfchargingbattery", "halfbattery")
            ElseIf percent >= 25 Then
                iconName = If(charging, "quarterchargingbattery", "quarterbattery")
            ElseIf percent > 5 Then
                iconName = If(charging, "quarterchargingbattery", "quarterbattery")
            Else
                iconName = "deadbattery"
            End If
            ' Set icon
            Select Case iconName
                Case "fullbattery"
                    BatteryToolStripMenuItem.Image = My.Resources.fullbattery
                Case "fullchargingbattery"
                    BatteryToolStripMenuItem.Image = My.Resources.fullchargingbattery
                Case "almostfullbattery"
                    BatteryToolStripMenuItem.Image = My.Resources.almostfullbattery
                Case "almostfullchargingbattery"
                    BatteryToolStripMenuItem.Image = My.Resources.almostfullchargingbattery
                Case "halfbattery"
                    BatteryToolStripMenuItem.Image = My.Resources.halfbattery
                Case "halfchargingbattery"
                    BatteryToolStripMenuItem.Image = My.Resources.halfchargingbattery
                Case "quarterbattery"
                    BatteryToolStripMenuItem.Image = My.Resources.quarterbattery
                Case "quarterchargingbattery"
                    BatteryToolStripMenuItem.Image = My.Resources.quarterchargingbattery
                Case "deadbattery"
                    BatteryToolStripMenuItem.Image = My.Resources.deadbattery
            End Select
            ' Set tooltip
            Dim tipText As String = String.Format("Battery: {0}%", percent)
            If charging Then tipText &= " (Charging)"
            If powerStatus.BatteryLifeRemaining > 0 AndAlso powerStatus.BatteryLifeRemaining < 100000 Then
                Dim mins = powerStatus.BatteryLifeRemaining \ 60
                tipText &= String.Format("{0}Estimated time left: {1} min", Environment.NewLine, mins)
            End If
            BatteryToolStripMenuItem.ToolTipText = tipText
            lastBatteryPercent = percent
            lastBatteryCharging = charging
        Catch ex As Exception
            BatteryToolStripMenuItem.ToolTipText = "Battery status unavailable"
        End Try
    End Sub

    ''' <summary>
    ''' Update time and date display based on user format settings
    ''' </summary>
    Private Sub UpdateTimeAndDate()
        ' Update time with format setting
        TimeData.Text = If(My.Settings.Use24ClockFormat,
                           Now.ToString("HH:mm"),
                           Now.ToString("hh:mm tt"))

        ' Update date with format setting
        Dim currentDate As Date = Now
        Select Case My.Settings.DateFormat
            Case "1"
                DateData.Text = currentDate.ToString("dd.MM.yyyy")
            Case "2"
                DateData.Text = currentDate.ToString("MM.dd.yyyy")
            Case "3"
                DateData.Text = currentDate.ToString("yyyy.MM.dd")
        End Select
    End Sub

    ''' <summary>
    ''' Update volume display and icon based on current volume
    ''' </summary>
    Private Sub UpdateVolumeDisplay()
        Dim currentVolume As Integer = GetApplicationVolume()
        Vol100ToolStripMenuItem.Text = currentVolume & "%"

        ' Set appropriate volume icon based on level
        If currentVolume <= 0 Then
            Vol100ToolStripMenuItem.Image = My.Resources.volume0
        ElseIf currentVolume <= 25 Then
            Vol100ToolStripMenuItem.Image = My.Resources.volume25
        ElseIf currentVolume <= 50 Then
            Vol100ToolStripMenuItem.Image = My.Resources.volume50
        Else
            Vol100ToolStripMenuItem.Image = My.Resources.volume100
        End If
    End Sub

    ''' <summary>
    ''' Update Windows button icon and tooltip based on login state
    ''' </summary>
    Private Sub UpdateWindowsButton()
        If arelogged Then
            If My.Settings.AreLogin Then
                WindowsToolStripMenuItem.Image = My.Resources.windows
                WindowsToolStripMenuItem.ToolTipText = "Close all opened apps" & vbNewLine & "Right click to open Task Manager"
            Else
                WindowsToolStripMenuItem.Image = My.Resources.lock
                WindowsToolStripMenuItem.ToolTipText = "Click to open login"
            End If
        End If
    End Sub

    ''' <summary>
    ''' Update audio player visibility
    ''' </summary>
    Private Sub UpdateAudioPlayerVisibility()
        AudioPlayerToolStripMenuItem.Visible = AudioPlayer.isHide
    End Sub
#End Region

#Region "Event Handlers"
    ' System menu event handlers
    Private Sub ShutdownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownToolStripMenuItem.Click
        Shutdown()
    End Sub

    Private Sub RestartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem.Click
        Restart()
    End Sub

    Private Sub LogOffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOffToolStripMenuItem.Click
        LogOff()
    End Sub

    Private Sub ChangeUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeUserToolStripMenuItem.Click
        settings.Show()
        ApplicationFolder.Close()
    End Sub

    Private Sub AboutPCBaOSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutPCBaOSToolStripMenuItem.Click
        version.Show()
    End Sub

    Private Sub CommandPromptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommandPromptToolStripMenuItem.Click
        commandepic.Show()
        ApplicationFolder.Close()
    End Sub

    ' Status bar button event handlers
    Private Sub Button_Search_Click(ByVal sender As Object, ByVal e As EventArgs)
        Search.Show()
    End Sub

    Private Sub Button_1_Click(ByVal sender As Object, ByVal e As EventArgs)
        settings.Show()
    End Sub

    Private Sub Button_2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Browser.Show()
    End Sub

    Private Sub Button_3_Click(ByVal sender As Object, ByVal e As EventArgs)
        ApplicationFolder.Show()
    End Sub

    ' Windows button event handlers
    Private Sub WindowsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WindowsToolStripMenuItem.Click
        WindowFunction()
    End Sub

    Private Sub WindowsToolStripMenuItem_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles WindowsToolStripMenuItem.MouseDown
        If My.Settings.AreLogin AndAlso e.Button = MouseButtons.Right Then
            TaskMgr.Show()
        End If
    End Sub

    ' Volume control event handlers
    Private Sub Vol100ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Vol100ToolStripMenuItem.Click
        QuickAccess.Show()
    End Sub

    Private Sub Vol100ToolStripMenuItem_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Vol100ToolStripMenuItem.MouseDown
        If e.Button = MouseButtons.Right Then
            VolumeContextMenu.Show(MousePosition)
        End If
    End Sub

    Private Sub MuteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MuteToolStripMenuItem.Click
        SetApplicationVolume(0)
    End Sub

    ' Clock and date event handlers
    Private Sub TimeData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeData.Click
        Clocks.Show()
        ApplicationFolder.Close()
    End Sub

    Private Sub DateData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateData.Click
        Calendar.Show()
        ApplicationFolder.Close()
    End Sub

    ' Audio player event handlers
    Private Sub PreviousToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviousToolStripMenuItem.Click
        AudioPlayer.currentFileIndex -= 1

        ' If we've reached the beginning of the list, loop back to the end
        If AudioPlayer.currentFileIndex < 0 Then
            AudioPlayer.currentFileIndex = AudioPlayer.musicFiles.Length - 1
        End If

        ' Load the previous music file
        AudioPlayer.mediaPlayer.URL = AudioPlayer.musicFiles(AudioPlayer.currentFileIndex)
    End Sub

    Private Sub NextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextToolStripMenuItem.Click
        AudioPlayer.currentFileIndex += 1

        ' If we've reached the end of the list, loop back to the beginning
        If AudioPlayer.currentFileIndex >= AudioPlayer.musicFiles.Length Then
            AudioPlayer.currentFileIndex = 0
        End If

        ' Load the next music file
        AudioPlayer.mediaPlayer.URL = AudioPlayer.musicFiles(AudioPlayer.currentFileIndex)
    End Sub

    Private Sub PlayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayToolStripMenuItem.Click
        AudioPlayer.mediaPlayer.Ctlcontrols.play()
    End Sub

    Private Sub PauseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PauseToolStripMenuItem.Click
        AudioPlayer.mediaPlayer.Ctlcontrols.pause()
    End Sub

    Private Sub StopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopToolStripMenuItem.Click
        AudioPlayer.mediaPlayer.Ctlcontrols.currentPosition = 0
        AudioPlayer.mediaPlayer.Ctlcontrols.play()
    End Sub

    Private Sub RepeatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepeatToolStripMenuItem.Click
        If AudioPlayer.repeatOn = False Then
            AudioPlayer.mediaPlayer.settings.setMode("loop", True)
            AudioPlayer.Button4.Image = My.Resources.back
            RepeatToolStripMenuItem.Image = My.Resources.back
            AudioPlayer.repeatOn = True
        Else
            AudioPlayer.mediaPlayer.settings.setMode("loop", False)
            AudioPlayer.Button4.Image = My.Resources.backno
            RepeatToolStripMenuItem.Image = My.Resources.backinminimized
            AudioPlayer.repeatOn = False
        End If
    End Sub

    ' Safe internet check
    ' A faster way to check for internet connectivity using NetworkInterface
    Private Function IsInternetAvailable() As Boolean
        Try
            For Each ni As Net.NetworkInformation.NetworkInterface In Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                If ni.OperationalStatus = Net.NetworkInformation.OperationalStatus.Up AndAlso
                   ni.NetworkInterfaceType <> Net.NetworkInformation.NetworkInterfaceType.Loopback AndAlso
                   ni.NetworkInterfaceType <> Net.NetworkInformation.NetworkInterfaceType.Tunnel Then
                    ' Check if any interface has a valid gateway (means likely connected)
                    Dim ipProps = ni.GetIPProperties()
                    If ipProps.GatewayAddresses.Any(Function(g) Not g.Address.Equals(Net.IPAddress.Any) AndAlso Not g.Address.Equals(Net.IPAddress.None)) Then
                        Return True
                    End If
                End If
            Next
            Return False
        Catch ex As Exception
            LogError("Failed to check internet connection", ex)
            Return False
        End Try
    End Function

    ' Call this when menu item is clicked
    Private Sub InternetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternetToolStripMenuItem.Click
        If My.Settings.AreLogin = False Then
            MsgBox("Please login to use this feature!", MsgBoxStyle.Information, "Authentification Error")
        Else
            Dim isConnected As Boolean = IsInternetAvailable()

            ' Display appropriate message
            Dim message As String = If(isConnected, "Connection Status: Connected", "Connection Status: Disconnected")
            Dim icon As MsgBoxStyle = If(isConnected, MsgBoxStyle.Information, MsgBoxStyle.Exclamation)

            ' Show message as topmost window
            Const MB_TOPMOST As Integer = &H40000
            MsgBox(message, icon Or MsgBoxStyle.OkOnly Or MB_TOPMOST, "Connection Status")
        End If
    End Sub

    ' Notifications
    Private Sub NotificToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotificToolStripMenuItem.Click
        If My.Settings.AreLogin = False Then
            MsgBox("Please login to use this feature!", MsgBoxStyle.Information, "Authentification Error")
        Else
            Notifications.Show()
        End If
    End Sub

    ' MenuItem tooltips (MenuStrip)
    Private Sub MenuItemMouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        AboutPCBaOSToolStripMenuItem.MouseEnter, ChangeUserToolStripMenuItem.MouseEnter, _
        LogOffToolStripMenuItem.MouseEnter, RestartToolStripMenuItem.MouseEnter, _
        ShutdownToolStripMenuItem.MouseEnter

        Dim menuItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)

        Select Case menuItem.Name
            Case "AboutPCBaOSToolStripMenuItem"
                StatusBarTooltipHelper.ShowTooltip(Me, "About the OS")
            Case "ChangeUserToolStripMenuItem"
                StatusBarTooltipHelper.ShowTooltip(Me, "Setup your system and computer")
            Case "LogOffToolStripMenuItem"
                StatusBarTooltipHelper.ShowTooltip(Me, "Log off you from system")
            Case "RestartToolStripMenuItem"
                StatusBarTooltipHelper.ShowTooltip(Me, "Restart your PC")
            Case "ShutdownToolStripMenuItem"
                StatusBarTooltipHelper.ShowTooltip(Me, "Shutdown your PC")
        End Select
    End Sub

    Private Sub MenuItemMouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        AboutPCBaOSToolStripMenuItem.MouseLeave, ChangeUserToolStripMenuItem.MouseLeave, _
        LogOffToolStripMenuItem.MouseLeave, RestartToolStripMenuItem.MouseLeave, _
        ShutdownToolStripMenuItem.MouseLeave

        StatusBarTooltipHelper.ClearTooltip(Me)
    End Sub

    ' Safe keyboard shortcuts
    Private Sub WorkSpace_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If My.Settings.AreLogin Then
                Select Case e.KeyCode
                    Case Keys.F1
                        version.Show()
                    Case Keys.F2
                        commandepic.Show()
                    Case Keys.F3
                        settings.Show()
                    Case Keys.F4
                        LogOff()
                    Case Keys.F5
                        Restart()
                    Case Keys.F6
                        Shutdown()
                    Case Keys.F7
                        QuickAccess.Show()
                    Case Keys.F8
                        Clocks.Show()
                    Case Keys.F9
                        WindowFunctionShortcut()
                    Case Keys.F10
                        TaskMgr.Show()
                    Case Keys.F11
                        Browser.Show()
                    Case Keys.F12
                        ApplicationFolder.Show()
                    Case Keys.Enter
                        Search.Show()
                End Select
            End If
        Catch ex As Exception
            LogError("Failed to handle keyboard shortcut", ex)
        End Try
    End Sub
#End Region

#Region "Unused Event Handlers - Consider Removing"
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Empty handler - consider removing if not needed
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkBar.Show()
    End Sub

    Private Sub WorkSpace_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        ' Empty handler - consider removing if not needed
    End Sub

    Private Sub WorkSpace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        ' Empty handler - consider removing if not needed
    End Sub

    Public Sub Wait()
        ' Warning: This blocks the UI thread
        Thread.Sleep(600)
        WindowsToolStripMenuItem.Image = My.Resources.checkmark
    End Sub
#End Region

    Private Sub AudioPlayerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AudioPlayerToolStripMenuItem.Click

    End Sub

    Private Sub StatusStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub TaskbarShowClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        UpdateTaskbar()
    End Sub

    ' Add a timer to poll for open forms changes
    Private lastTaskbarForms As String = ""
    Private Sub TaskbarAutoUpdateTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Dim formNames = String.Join("|", Application.OpenForms.Cast(Of Form)().Where(Function(f) f IsNot Me).Select(Function(f) f.Name & f.Text & f.WindowState.ToString()))
        If formNames <> lastTaskbarForms Then
            lastTaskbarForms = formNames
            UpdateTaskbar()
        End If
    End Sub

    ' UpdateTaskbar: Handle multiple instances of the same app
    Private Sub UpdateTaskbar()
        ' Clear instance tracking
        formInstanceMap.Clear()

        ' First pass: Map existing forms to their current instance IDs
        Dim existingFormToInstanceMap As New Dictionary(Of Form, String)()
        For Each instanceId In taskbarOrder
            ' Try to find the form that was previously mapped to this instance ID
            For Each frm As Form In Application.OpenForms
                If frm IsNot Me AndAlso frm.Name <> "Password" AndAlso frm.Name <> "QuickAccess" AndAlso frm.Name <> "ApplicationFolder" AndAlso frm.Name <> "WorkName" AndAlso frm.Name <> "BootLoad" AndAlso frm.Name <> "WorkSpace" AndAlso frm.Name <> "Notifications" Then
                    Dim baseName As String = frm.Name
                    If instanceId.StartsWith(baseName & "_") AndAlso Not existingFormToInstanceMap.ContainsKey(frm) Then
                        ' Additional check: make sure this form isn't already mapped to a different instance ID
                        Dim alreadyMapped As Boolean = False
                        For Each kvp In existingFormToInstanceMap
                            If kvp.Value = instanceId Then
                                alreadyMapped = True
                                Exit For
                            End If
                        Next

                        If Not alreadyMapped Then
                            existingFormToInstanceMap(frm) = instanceId
                            formInstanceMap(instanceId) = frm
                        End If
                        Exit For
                    End If
                End If
            Next
        Next

        ' Remove closed forms from order
        Dim formsToRemove As New List(Of String)()
        For Each instanceId In taskbarOrder
            If Not formInstanceMap.ContainsKey(instanceId) Then
                formsToRemove.Add(instanceId)
            End If
        Next
        For Each instanceId In formsToRemove
            taskbarOrder.Remove(instanceId)
        Next

        ' Process all open forms that don't have existing instance IDs
        For Each frm As Form In Application.OpenForms
            If frm IsNot Me AndAlso frm.Name <> "Password" AndAlso frm.Name <> "QuickAccess" AndAlso frm.Name <> "ApplicationFolder" AndAlso frm.Name <> "WorkName" AndAlso frm.Name <> "BootLoad" AndAlso frm.Name <> "WorkSpace" AndAlso frm.Name <> "Notifications" Then

                ' Skip if this form already has an instance ID
                If existingFormToInstanceMap.ContainsKey(frm) Then Continue For

                ' Generate unique instance ID for new forms
                Dim instanceId As String = GenerateInstanceId(frm)

                ' Track this instance
                formInstanceMap(instanceId) = frm

                ' Add to order if new
                If Not taskbarOrder.Contains(instanceId) Then
                    taskbarOrder.Add(instanceId)
                End If
            End If
        Next

        ' Rebuild buttons in order
        TaskbarPanel.Controls.Clear()
        For Each instanceId In taskbarOrder
            Dim frm = formInstanceMap(instanceId)
            If frm Is Nothing Then Continue For

            ' Remember last non-minimized state
            If frm.WindowState <> FormWindowState.Minimized Then
                lastWindowStates(frm) = frm.WindowState
            ElseIf Not lastWindowStates.ContainsKey(frm) Then
                lastWindowStates(frm) = FormWindowState.Normal
            End If

            RemoveHandler frm.Activated, AddressOf AppForm_Activated
            AddHandler frm.Activated, AddressOf AppForm_Activated

            Dim btn As New Button()
            btn.Width = 48
            btn.Height = 48
            btn.Tag = frm  ' Ensure Tag is set to the correct form
            btn.Name = "TaskbarBtn_" & instanceId

            ' Set icon
            If frm.Icon IsNot Nothing Then
                btn.Image = frm.Icon.ToBitmap()
            End If

            ' Set text to show instance number if multiple instances
            Dim instanceNumber As Integer = GetInstanceNumber(instanceId)
            If instanceNumber > 1 Then
                btn.Text = instanceNumber.ToString()
                btn.Font = New Font(btn.Font.FontFamily, 8, FontStyle.Bold)
            Else
                btn.Text = ""
            End If

            btn.TextImageRelation = TextImageRelation.ImageAboveText

            ' Create context menu
            Dim menu As New ContextMenuStrip()
            Dim titleItem As New ToolStripMenuItem(GetFormTitle(frm, instanceNumber))
            titleItem.Enabled = False
            menu.Items.Add(titleItem)
            menu.Items.Add(New ToolStripSeparator())
            menu.Items.Add("Minimize", Nothing, Sub() CType(btn.Tag, Form).WindowState = FormWindowState.Minimized)
            menu.Items.Add("Restore", Nothing, Sub()
                                                   Dim f = CType(btn.Tag, Form)
                                                   If lastWindowStates.ContainsKey(f) Then
                                                       f.WindowState = lastWindowStates(f)
                                                   Else
                                                       f.WindowState = FormWindowState.Normal
                                                   End If
                                               End Sub)
            menu.Items.Add("Close", Nothing, Sub() CType(btn.Tag, Form).Close())
            btn.ContextMenuStrip = menu

            ' Set tooltip
            Dim tip As New ToolTip()
            tip.SetToolTip(btn, GetFormTitle(frm, instanceNumber))

            ' Drag and drop handlers
            AddHandler btn.MouseDown, AddressOf TaskbarBtn_MouseDown
            AddHandler btn.MouseMove, AddressOf TaskbarBtn_MouseMove
            AddHandler btn.MouseUp, AddressOf TaskbarBtn_MouseUp
            TaskbarPanel.Controls.Add(btn)
        Next

        ' Save order to settings
        My.Settings.TaskbarOrder = String.Join("|", taskbarOrder)
        My.Settings.Save()
    End Sub

    ' Generate unique instance ID for a form
    Private Function GenerateInstanceId(ByVal frm As Form) As String
        Dim baseName As String = frm.Name
        Dim usedNumbers As New List(Of Integer)()

        ' Check what instance numbers are already in use in taskbarOrder
        For Each instanceId In taskbarOrder
            If instanceId.StartsWith(baseName & "_") Then
                Dim parts() As String = instanceId.Split("_"c)
                If parts.Length > 1 Then
                    Dim numberStr As String = parts(parts.Length - 1)
                    Dim number As Integer
                    If Integer.TryParse(numberStr, number) Then
                        usedNumbers.Add(number)
                    End If
                End If
            End If
        Next

        ' Find the first available number
        Dim instanceNumber As Integer = 1
        While usedNumbers.Contains(instanceNumber)
            instanceNumber += 1
        End While

        ' Generate unique ID
        Return baseName & "_" & instanceNumber.ToString()
    End Function

    ' Get the current instance ID for a form (if it exists in taskbar)
    Private Function GetFormInstanceId(ByVal frm As Form) As String
        For Each kvp In formInstanceMap
            If kvp.Value Is frm Then
                Return kvp.Key
            End If
        Next
        Return frm.Name
    End Function

    ' Get instance number from instance ID
    Private Function GetInstanceNumber(ByVal instanceId As String) As Integer
        Dim parts() As String = instanceId.Split("_"c)
        If parts.Length > 1 Then
            Dim numberStr As String = parts(parts.Length - 1)
            Dim number As Integer
            If Integer.TryParse(numberStr, number) Then
                Return number
            End If
        End If
        Return 1
    End Function

    ' Get form title with instance number if applicable
    Private Function GetFormTitle(ByVal frm As Form, ByVal instanceNumber As Integer) As String
        Dim baseTitle As String = frm.Text
        If instanceNumber > 1 Then
            Return baseTitle & " (" & instanceNumber.ToString() & ")"
        End If
        Return baseTitle
    End Function

    ' Drag and drop logic
    Private Sub TaskbarBtn_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            draggingButton = CType(sender, Button)
            dragStartPoint = e.Location
            isDragging = False
        End If
    End Sub

    Private Sub TaskbarBtn_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        If draggingButton IsNot Nothing AndAlso e.Button = MouseButtons.Left Then
            Dim btn = draggingButton
            If Not TaskbarPanel.Controls.Contains(btn) Then Return
            Dim dx = Math.Abs(e.X - dragStartPoint.X)
            Dim dy = Math.Abs(e.Y - dragStartPoint.Y)
            If Not isDragging AndAlso (dx > DRAG_THRESHOLD OrElse dy > DRAG_THRESHOLD) Then
                isDragging = True
            End If
            If isDragging Then
                Dim idx = TaskbarPanel.Controls.GetChildIndex(btn)
                Dim mousePos = TaskbarPanel.PointToClient(Control.MousePosition)
                For i = 0 To TaskbarPanel.Controls.Count - 1
                    Dim otherBtn = TaskbarPanel.Controls(i)
                    If otherBtn Is btn Then Continue For
                    If otherBtn.Bounds.Contains(mousePos) Then
                        TaskbarPanel.Controls.SetChildIndex(btn, i)
                        ' Get instance ID from button name
                        Dim instanceId As String = btn.Name.Replace("TaskbarBtn_", "")
                        taskbarOrder.Remove(instanceId)
                        taskbarOrder.Insert(i, instanceId)

                        ' Update button tags to match the new order
                        UpdateButtonTags()
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub TaskbarBtn_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim btn = TryCast(sender, Button)
        If btn Is Nothing Then Return
        If isDragging Then
            draggingButton = Nothing
            isDragging = False
            ' Update button tags to ensure they're correct
            UpdateButtonTags()
            My.Settings.TaskbarOrder = String.Join("|", taskbarOrder)
            My.Settings.Save()
        ElseIf draggingButton Is btn AndAlso e.Button = MouseButtons.Left Then
            ' Treat as click if not a drag
            Dim thisForm = CType(btn.Tag, Form)
            If thisForm Is Me Then GoTo ResetDrag
            If thisForm.WindowState = FormWindowState.Minimized Then
                If lastWindowStates.ContainsKey(thisForm) Then
                    thisForm.WindowState = lastWindowStates(thisForm)
                Else
                    thisForm.WindowState = FormWindowState.Normal
                End If
                thisForm.Activate()
                SetForegroundWindow(thisForm.Handle)
            ElseIf thisForm Is lastActiveAppForm Then
                lastWindowStates(thisForm) = thisForm.WindowState
                thisForm.WindowState = FormWindowState.Minimized
            Else
                thisForm.Activate()
                SetForegroundWindow(thisForm.Handle)
            End If
ResetDrag:
            draggingButton = Nothing
            isDragging = False
        End If
    End Sub

    ' Helper method to update button tags to match the current taskbarOrder
    Private Sub UpdateButtonTags()
        ' Rebuild formInstanceMap based on current taskbarOrder
        formInstanceMap.Clear()

        For Each instanceId In taskbarOrder
            ' Find the form that should be mapped to this instance ID
            For Each frm As Form In Application.OpenForms
                If frm IsNot Me AndAlso frm.Name <> "Password" AndAlso frm.Name <> "QuickAccess" AndAlso frm.Name <> "ApplicationFolder" AndAlso frm.Name <> "WorkName" AndAlso frm.Name <> "BootLoad" AndAlso frm.Name <> "WorkSpace" AndAlso frm.Name <> "Notifications" Then
                    Dim baseName As String = frm.Name
                    If instanceId.StartsWith(baseName & "_") AndAlso Not formInstanceMap.ContainsValue(frm) Then
                        formInstanceMap(instanceId) = frm
                        Exit For
                    End If
                End If
            Next
        Next

        ' Update button tags to match the new mapping
        For i As Integer = 0 To TaskbarPanel.Controls.Count - 1
            Dim btn As Button = TryCast(TaskbarPanel.Controls(i), Button)
            If btn IsNot Nothing Then
                Dim instanceId As String = btn.Name.Replace("TaskbarBtn_", "")
                If formInstanceMap.ContainsKey(instanceId) Then
                    btn.Tag = formInstanceMap(instanceId)
                End If
            End If
        Next
    End Sub

    ' On startup, restore order from settings
    Private Sub RestoreTaskbarOrder()
        If Not String.IsNullOrEmpty(My.Settings.TaskbarOrder) Then
            taskbarOrder = My.Settings.TaskbarOrder.Split("|"c).ToList()
            ' Clean up any invalid instance IDs
            CleanupInvalidInstanceIds()
        End If
    End Sub

    ' Clean up invalid instance IDs from saved order
    Private Sub CleanupInvalidInstanceIds()
        Dim validIds As New List(Of String)()
        For Each instanceId In taskbarOrder
            ' Check if this instance ID format is valid
            If instanceId.Contains("_") Then
                Dim parts() As String = instanceId.Split("_"c)
                If parts.Length > 1 Then
                    Dim numberStr As String = parts(parts.Length - 1)
                    Dim number As Integer
                    If Integer.TryParse(numberStr, number) AndAlso number > 0 Then
                        validIds.Add(instanceId)
                    End If
                End If
            Else
                ' Legacy format - keep for backward compatibility
                validIds.Add(instanceId)
            End If
        Next
        taskbarOrder = validIds
    End Sub

    ' Handler to track last active app form
    Private Sub AppForm_Activated(ByVal sender As Object, ByVal e As EventArgs)
        Dim frm = TryCast(sender, Form)
        If frm IsNot Nothing AndAlso frm IsNot Me Then
            lastActiveAppForm = frm
        End If
    End Sub

    Private Sub ShowTaskbarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowTaskbarToolStripMenuItem.Click
        Dim s As New settings()
        s.SetStartupTab("Theme")
        s.Show()
    End Sub

    ' Add Reminder for today (open Calendar and trigger reminder dialog)
    Private Sub AddReminderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddReminderToolStripMenuItem.Click, AddReminderItem.Click
        Try
            ' Open Calendar if not already open
            Dim calForm As Calendar = Nothing
            For Each frm As Form In Application.OpenForms
                If TypeOf frm Is Calendar Then
                    calForm = CType(frm, Calendar)
                    Exit For
                End If
            Next
            Dim calendarWasAlreadyOpen As Boolean = (calForm IsNot Nothing)
            If calForm Is Nothing Then
                calForm = New Calendar()
                calForm.Show()
            Else
                calForm.BringToFront()
            End If
            ' Use reflection to call DayCell_DoubleClick for today
            Dim today As Date = Date.Today
            Dim calPanel = calForm.Controls.Find("CalendarPanel", True).FirstOrDefault()
            Dim reminderAdded As Boolean = False
            If calPanel IsNot Nothing Then
                For Each ctrl In calPanel.Controls
                    If TypeOf ctrl Is Label Then
                        Dim lbl As Label = CType(ctrl, Label)
                        If lbl.Text IsNot Nothing AndAlso lbl.Text.Trim().Length > 0 Then
                            Dim dayNum As Integer
                            Dim txt = New String(lbl.Text.TakeWhile(Function(c) Char.IsDigit(c)).ToArray())
                            If Integer.TryParse(txt, dayNum) AndAlso dayNum = today.Day Then
                                Dim mi = calForm.GetType().GetMethod("DayCell_DoubleClick", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
                                If mi IsNot Nothing Then
                                    mi.Invoke(calForm, New Object() {lbl, EventArgs.Empty})
                                    reminderAdded = True
                                End If
                                Exit For
                            End If
                        End If
                    End If
                Next
            End If
            ' If we opened the calendar just for this, close it after adding reminder
            If Not calendarWasAlreadyOpen AndAlso reminderAdded Then
                calForm.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to add reminder: " & ex.Message)
        End Try
    End Sub

    ' Copy current time to clipboard
    Private Sub CopyTimeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyTimeToolStripMenuItem.Click
        Try
            Dim nowTime As String = DateTime.Now.ToString("HH:mm:ss")
            Clipboard.SetText(nowTime)
        Catch ex As Exception
            MessageBox.Show("Failed to copy time: " & ex.Message)
        End Try
    End Sub

    ' Open Time & Region settings tab in settings form
    Private Sub TimeRegionSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeRegionSettingsToolStripMenuItem.Click, TimeAndRegionSettingsDate.Click
        Try
            Dim s As New settings()
            s.SetStartupTab("time and region")
            s.Show()
        Catch ex As Exception
            MessageBox.Show("Failed to open Time & Region settings: " & ex.Message)
        End Try
    End Sub

    Private Sub TimeData_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TimeData.MouseDown
        If e.Button = MouseButtons.Right Then
            TimeContextMenu.Show(MousePosition)
        End If
    End Sub

    Private Sub DateData_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DateData.MouseDown
        If e.Button = MouseButtons.Right Then
            DateContextMenu.Show(MousePosition)
        End If
    End Sub

    Private Sub CopyDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyDate.Click
        Try
            Dim dateStr As String
            Select Case My.Settings.DateFormat
                Case "1"
                    dateStr = DateTime.Now.ToString("dd.MM.yyyy")
                Case "2"
                    dateStr = DateTime.Now.ToString("MM.dd.yyyy")
                Case "3"
                    dateStr = DateTime.Now.ToString("yyyy.MM.dd")
                Case Else
                    dateStr = DateTime.Now.ToShortDateString()
            End Select
            Clipboard.SetText(dateStr)
        Catch ex As Exception
            MessageBox.Show("Failed to copy date: " & ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BatteryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BatteryToolStripMenuItem.Click

    End Sub
End Class
Module StatusBarTooltipHelper
    Public Sub ShowTooltip(form As Form, message As String)
        ' Try to find a StatusStrip with ToolStripStatusLabel1 in the form
        Dim statusStrip = form.Controls.OfType(Of StatusStrip)().FirstOrDefault()
        If statusStrip IsNot Nothing Then
            Dim statusLabel = statusStrip.Items.OfType(Of ToolStripStatusLabel)().FirstOrDefault(Function(lbl) lbl.Name = "ToolStripStatusLabel1")
            If statusLabel IsNot Nothing Then
                statusLabel.Text = message
            End If
        End If
    End Sub

    Public Sub ClearTooltip(form As Form)
        ShowTooltip(form, "")
    End Sub
End Module
