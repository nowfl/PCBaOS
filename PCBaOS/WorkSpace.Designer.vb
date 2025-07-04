<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkSpace
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkSpace))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PCBaOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutPCBaOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommandPromptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LogOffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShutdownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InternetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotificToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimeData = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateData = New System.Windows.Forms.ToolStripMenuItem()
        Me.Vol100ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AudioPlayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreviousToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PlayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PauseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.RepeatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.VolumeContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MuteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TaskbarPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.TaskbarContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowTaskbarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.VolumeContextMenu.SuspendLayout()
        Me.TaskbarContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Tai Le", 24.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(16, 53)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(219, 51)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Welcome, "
        Me.Label1.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PCBaOSToolStripMenuItem, Me.WindowsToolStripMenuItem, Me.InternetToolStripMenuItem, Me.NotificToolStripMenuItem, Me.TimeData, Me.DateData, Me.Vol100ToolStripMenuItem, Me.AudioPlayerToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.ShowItemToolTips = True
        Me.MenuStrip1.Size = New System.Drawing.Size(1685, 39)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'PCBaOSToolStripMenuItem
        '
        Me.PCBaOSToolStripMenuItem.AutoToolTip = True
        Me.PCBaOSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutPCBaOSToolStripMenuItem, Me.CommandPromptToolStripMenuItem, Me.ChangeUserToolStripMenuItem, Me.ToolStripSeparator1, Me.LogOffToolStripMenuItem, Me.RestartToolStripMenuItem, Me.ShutdownToolStripMenuItem})
        Me.PCBaOSToolStripMenuItem.Enabled = False
        Me.PCBaOSToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.PCBaOSToolStripMenuItem.Name = "PCBaOSToolStripMenuItem"
        Me.PCBaOSToolStripMenuItem.Size = New System.Drawing.Size(86, 35)
        Me.PCBaOSToolStripMenuItem.Text = "PCBaOS"
        Me.PCBaOSToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PCBaOSToolStripMenuItem.ToolTipText = "Click to open menu"
        '
        'AboutPCBaOSToolStripMenuItem
        '
        Me.AboutPCBaOSToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.AboutPCBaOSToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.info16
        Me.AboutPCBaOSToolStripMenuItem.Name = "AboutPCBaOSToolStripMenuItem"
        Me.AboutPCBaOSToolStripMenuItem.Size = New System.Drawing.Size(201, 24)
        Me.AboutPCBaOSToolStripMenuItem.Text = "About PCBaOS"
        '
        'CommandPromptToolStripMenuItem
        '
        Me.CommandPromptToolStripMenuItem.AutoSize = False
        Me.CommandPromptToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CommandPromptToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.cmd
        Me.CommandPromptToolStripMenuItem.Name = "CommandPromptToolStripMenuItem"
        Me.CommandPromptToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.CommandPromptToolStripMenuItem.Text = "Command Prompt"
        Me.CommandPromptToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'ChangeUserToolStripMenuItem
        '
        Me.ChangeUserToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChangeUserToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.settings
        Me.ChangeUserToolStripMenuItem.Name = "ChangeUserToolStripMenuItem"
        Me.ChangeUserToolStripMenuItem.Size = New System.Drawing.Size(201, 24)
        Me.ChangeUserToolStripMenuItem.Text = "System Options"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(198, 6)
        '
        'LogOffToolStripMenuItem
        '
        Me.LogOffToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LogOffToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.logoff
        Me.LogOffToolStripMenuItem.Name = "LogOffToolStripMenuItem"
        Me.LogOffToolStripMenuItem.Size = New System.Drawing.Size(201, 24)
        Me.LogOffToolStripMenuItem.Text = "Log Off"
        '
        'RestartToolStripMenuItem
        '
        Me.RestartToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RestartToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RestartToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.restart
        Me.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem"
        Me.RestartToolStripMenuItem.Size = New System.Drawing.Size(201, 24)
        Me.RestartToolStripMenuItem.Text = "Restart"
        '
        'ShutdownToolStripMenuItem
        '
        Me.ShutdownToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ShutdownToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.shutdown
        Me.ShutdownToolStripMenuItem.Name = "ShutdownToolStripMenuItem"
        Me.ShutdownToolStripMenuItem.Size = New System.Drawing.Size(201, 24)
        Me.ShutdownToolStripMenuItem.Text = "Shutdown"
        '
        'WindowsToolStripMenuItem
        '
        Me.WindowsToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.WindowsToolStripMenuItem.AutoToolTip = True
        Me.WindowsToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.WindowsToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.windows
        Me.WindowsToolStripMenuItem.Name = "WindowsToolStripMenuItem"
        Me.WindowsToolStripMenuItem.Size = New System.Drawing.Size(28, 35)
        Me.WindowsToolStripMenuItem.ToolTipText = "Close all opened apps" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Right click to open Task Manager"
        '
        'InternetToolStripMenuItem
        '
        Me.InternetToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.InternetToolStripMenuItem.AutoToolTip = True
        Me.InternetToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.earth
        Me.InternetToolStripMenuItem.Name = "InternetToolStripMenuItem"
        Me.InternetToolStripMenuItem.Size = New System.Drawing.Size(28, 35)
        Me.InternetToolStripMenuItem.ToolTipText = "Internet Connection"
        '
        'NotificToolStripMenuItem
        '
        Me.NotificToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.NotificToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.arrows
        Me.NotificToolStripMenuItem.Name = "NotificToolStripMenuItem"
        Me.NotificToolStripMenuItem.Size = New System.Drawing.Size(28, 35)
        '
        'TimeData
        '
        Me.TimeData.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TimeData.AutoToolTip = True
        Me.TimeData.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TimeData.Name = "TimeData"
        Me.TimeData.Size = New System.Drawing.Size(84, 35)
        Me.TimeData.Text = "00:00:00"
        Me.TimeData.ToolTipText = "Time"
        '
        'DateData
        '
        Me.DateData.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.DateData.AutoToolTip = True
        Me.DateData.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.DateData.Name = "DateData"
        Me.DateData.Size = New System.Drawing.Size(131, 35)
        Me.DateData.Text = "Jan 01th, 2022"
        Me.DateData.ToolTipText = "Date"
        '
        'Vol100ToolStripMenuItem
        '
        Me.Vol100ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Vol100ToolStripMenuItem.AutoToolTip = True
        Me.Vol100ToolStripMenuItem.Enabled = False
        Me.Vol100ToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Vol100ToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.volume100
        Me.Vol100ToolStripMenuItem.Name = "Vol100ToolStripMenuItem"
        Me.Vol100ToolStripMenuItem.Size = New System.Drawing.Size(79, 35)
        Me.Vol100ToolStripMenuItem.Text = "100%"
        Me.Vol100ToolStripMenuItem.ToolTipText = "Volume"
        '
        'AudioPlayerToolStripMenuItem
        '
        Me.AudioPlayerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreviousToolStripMenuItem, Me.NextToolStripMenuItem, Me.ToolStripSeparator2, Me.PlayToolStripMenuItem, Me.PauseToolStripMenuItem, Me.StopToolStripMenuItem, Me.ToolStripSeparator3, Me.RepeatToolStripMenuItem})
        Me.AudioPlayerToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.AudioPlayerToolStripMenuItem.Name = "AudioPlayerToolStripMenuItem"
        Me.AudioPlayerToolStripMenuItem.Size = New System.Drawing.Size(118, 35)
        Me.AudioPlayerToolStripMenuItem.Text = "Audio Player"
        Me.AudioPlayerToolStripMenuItem.Visible = False
        '
        'PreviousToolStripMenuItem
        '
        Me.PreviousToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.controlleft
        Me.PreviousToolStripMenuItem.Name = "PreviousToolStripMenuItem"
        Me.PreviousToolStripMenuItem.Size = New System.Drawing.Size(144, 28)
        Me.PreviousToolStripMenuItem.Text = "Previous"
        '
        'NextToolStripMenuItem
        '
        Me.NextToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.controlright
        Me.NextToolStripMenuItem.Name = "NextToolStripMenuItem"
        Me.NextToolStripMenuItem.Size = New System.Drawing.Size(144, 28)
        Me.NextToolStripMenuItem.Text = "Next"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(141, 6)
        '
        'PlayToolStripMenuItem
        '
        Me.PlayToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.audioright
        Me.PlayToolStripMenuItem.Name = "PlayToolStripMenuItem"
        Me.PlayToolStripMenuItem.Size = New System.Drawing.Size(144, 28)
        Me.PlayToolStripMenuItem.Text = "Play"
        '
        'PauseToolStripMenuItem
        '
        Me.PauseToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.pause
        Me.PauseToolStripMenuItem.Name = "PauseToolStripMenuItem"
        Me.PauseToolStripMenuItem.Size = New System.Drawing.Size(144, 28)
        Me.PauseToolStripMenuItem.Text = "Pause"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.controlleft
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(144, 28)
        Me.StopToolStripMenuItem.Text = "Stop"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(141, 6)
        '
        'RepeatToolStripMenuItem
        '
        Me.RepeatToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.backinminimized
        Me.RepeatToolStripMenuItem.Name = "RepeatToolStripMenuItem"
        Me.RepeatToolStripMenuItem.Size = New System.Drawing.Size(144, 28)
        Me.RepeatToolStripMenuItem.Text = "Repeat"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.StatusStrip1.Enabled = False
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 813)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1685, 25)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        Me.StatusStrip1.Visible = False
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(15, 20)
        Me.ToolStripStatusLabel1.Text = "-"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Impact", 108.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label2.ForeColor = System.Drawing.Color.DarkCyan
        Me.Label2.Location = New System.Drawing.Point(951, 610)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(670, 220)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "PCBaOS"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 50
        '
        'VolumeContextMenu
        '
        Me.VolumeContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MuteToolStripMenuItem})
        Me.VolumeContextMenu.Name = "VolumeContextMenu"
        Me.VolumeContextMenu.Size = New System.Drawing.Size(113, 28)
        '
        'MuteToolStripMenuItem
        '
        Me.MuteToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.volume0
        Me.MuteToolStripMenuItem.Name = "MuteToolStripMenuItem"
        Me.MuteToolStripMenuItem.Size = New System.Drawing.Size(112, 24)
        Me.MuteToolStripMenuItem.Text = "Mute"
        '
        'TaskbarPanel
        '
        Me.TaskbarPanel.BackColor = System.Drawing.SystemColors.ControlDark
        Me.TaskbarPanel.ContextMenuStrip = Me.TaskbarContextMenu
        Me.TaskbarPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TaskbarPanel.Enabled = False
        Me.TaskbarPanel.Location = New System.Drawing.Point(0, 772)
        Me.TaskbarPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.TaskbarPanel.Name = "TaskbarPanel"
        Me.TaskbarPanel.Size = New System.Drawing.Size(1685, 66)
        Me.TaskbarPanel.TabIndex = 1
        Me.TaskbarPanel.Visible = False
        '
        'TaskbarContextMenu
        '
        Me.TaskbarContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowTaskbarToolStripMenuItem})
        Me.TaskbarContextMenu.Name = "TaskbarContextMenu"
        Me.TaskbarContextMenu.Size = New System.Drawing.Size(185, 28)
        '
        'ShowTaskbarToolStripMenuItem
        '
        Me.ShowTaskbarToolStripMenuItem.Name = "ShowTaskbarToolStripMenuItem"
        Me.ShowTaskbarToolStripMenuItem.Size = New System.Drawing.Size(184, 24)
        Me.ShowTaskbarToolStripMenuItem.Text = "Taskbar Settings"
        '
        'WorkSpace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CadetBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1685, 838)
        Me.Controls.Add(Me.TaskbarPanel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WorkSpace"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PCBaOS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.VolumeContextMenu.ResumeLayout(False)
        Me.TaskbarContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents PCBaOSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TimeData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents WindowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Vol100ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents VolumeContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MuteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InternetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutPCBaOSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CommandPromptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeUserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LogOffToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShutdownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AudioPlayerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreviousToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PlayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PauseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RepeatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotificToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TaskbarPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TaskbarContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowTaskbarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
