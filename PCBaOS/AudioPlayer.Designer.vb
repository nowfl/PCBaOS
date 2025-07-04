<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AudioPlayer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AudioPlayer))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.AudioPlayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mediaPlayer = New AxWMPLib.AxWindowsMediaPlayer()
        Me.ShuffleButton = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MinimizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.mediaPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 89)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "-"
        '
        'TrackBar1
        '
        Me.TrackBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackBar1.Location = New System.Drawing.Point(19, 32)
        Me.TrackBar1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TrackBar1.Maximum = 1000
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(784, 56)
        Me.TrackBar1.TabIndex = 7
        Me.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "mp3"
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "Audio Files|*.mp3;*.wav;*.ogg|MP3 Files|*.mp3|Wave Audio File|*.wav|OGG File|*.og" & _
            "g|All files|*.*"
        '
        'AudioPlayerToolStripMenuItem
        '
        Me.AudioPlayerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.AudioPlayerToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AudioPlayerToolStripMenuItem.Name = "AudioPlayerToolStripMenuItem"
        Me.AudioPlayerToolStripMenuItem.Size = New System.Drawing.Size(110, 24)
        Me.AudioPlayerToolStripMenuItem.Text = "Audio Player"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AudioPlayerToolStripMenuItem, Me.OpenToolStripMenuItem, Me.MinimizeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(816, 28)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 113)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "-"
        '
        'mediaPlayer
        '
        Me.mediaPlayer.Enabled = True
        Me.mediaPlayer.Location = New System.Drawing.Point(271, 5)
        Me.mediaPlayer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.mediaPlayer.Name = "mediaPlayer"
        Me.mediaPlayer.OcxState = CType(resources.GetObject("mediaPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.mediaPlayer.Size = New System.Drawing.Size(10, 10)
        Me.mediaPlayer.TabIndex = 11
        Me.mediaPlayer.Visible = False
        '
        'ShuffleButton
        '
        Me.ShuffleButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ShuffleButton.Image = Global.PCBaOS.My.Resources.Resources.shuffleno
        Me.ShuffleButton.Location = New System.Drawing.Point(188, 101)
        Me.ShuffleButton.Margin = New System.Windows.Forms.Padding(4)
        Me.ShuffleButton.Name = "ShuffleButton"
        Me.ShuffleButton.Size = New System.Drawing.Size(43, 39)
        Me.ShuffleButton.TabIndex = 12
        Me.ShuffleButton.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button6.Image = Global.PCBaOS.My.Resources.Resources.controlleft
        Me.Button6.Location = New System.Drawing.Point(239, 89)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(64, 59)
        Me.Button6.TabIndex = 10
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button5.Image = Global.PCBaOS.My.Resources.Resources.controlright
        Me.Button5.Location = New System.Drawing.Point(527, 89)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(64, 59)
        Me.Button5.TabIndex = 9
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button4.Image = Global.PCBaOS.My.Resources.Resources.backno
        Me.Button4.Location = New System.Drawing.Point(599, 101)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(43, 39)
        Me.Button4.TabIndex = 8
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button3.Image = Global.PCBaOS.My.Resources.Resources.pause
        Me.Button3.Location = New System.Drawing.Point(383, 89)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(64, 59)
        Me.Button3.TabIndex = 6
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.Image = Global.PCBaOS.My.Resources.Resources.backward
        Me.Button2.Location = New System.Drawing.Point(311, 89)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 59)
        Me.Button2.TabIndex = 0
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = Global.PCBaOS.My.Resources.Resources.audioright
        Me.Button1.Location = New System.Drawing.Point(455, 89)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 59)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.close1
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(114, 24)
        Me.ExitToolStripMenuItem.Text = "Close"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.open
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(73, 24)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'MinimizeToolStripMenuItem
        '
        Me.MinimizeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.MinimizeToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.minimize
        Me.MinimizeToolStripMenuItem.Name = "MinimizeToolStripMenuItem"
        Me.MinimizeToolStripMenuItem.Size = New System.Drawing.Size(98, 24)
        Me.MinimizeToolStripMenuItem.Text = "Minimize"
        '
        'AudioPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 162)
        Me.Controls.Add(Me.ShuffleButton)
        Me.Controls.Add(Me.mediaPlayer)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AudioPlayer"
        Me.Text = "Audio Player"
        Me.TopMost = True
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.mediaPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents AudioPlayerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MinimizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents mediaPlayer As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents ShuffleButton As System.Windows.Forms.Button
End Class
