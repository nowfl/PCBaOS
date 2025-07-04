<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Calendar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Calendar))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CalendarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WallpaperToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NONEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalendarPanel = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TransparentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoToTodayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetDateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CalculateDaysToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CalendarToolStripMenuItem, Me.WallpaperToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(505, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CalendarToolStripMenuItem
        '
        Me.CalendarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GoToTodayToolStripMenuItem, Me.SetDateToolStripMenuItem, Me.CalculateDaysToolStripMenuItem, Me.ToolStripSeparator2, Me.TransparentToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripSeparator1, Me.CloseToolStripMenuItem})
        Me.CalendarToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalendarToolStripMenuItem.Name = "CalendarToolStripMenuItem"
        Me.CalendarToolStripMenuItem.Size = New System.Drawing.Size(82, 24)
        Me.CalendarToolStripMenuItem.Text = "Calendar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem1.Image = Global.PCBaOS.My.Resources.Resources.maximize
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(203, 24)
        Me.ToolStripMenuItem1.Text = "Extended Calendar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(200, 6)
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.close
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(203, 24)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'WallpaperToolStripMenuItem
        '
        Me.WallpaperToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NONEToolStripMenuItem, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5})
        Me.WallpaperToolStripMenuItem.Name = "WallpaperToolStripMenuItem"
        Me.WallpaperToolStripMenuItem.Size = New System.Drawing.Size(89, 24)
        Me.WallpaperToolStripMenuItem.Text = "Wallpaper"
        '
        'NONEToolStripMenuItem
        '
        Me.NONEToolStripMenuItem.Name = "NONEToolStripMenuItem"
        Me.NONEToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.NONEToolStripMenuItem.Text = "None"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = Global.PCBaOS.My.Resources.Resources.blur
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(152, 24)
        Me.ToolStripMenuItem2.Text = "Blur"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = Global.PCBaOS.My.Resources.Resources.abstract
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(152, 24)
        Me.ToolStripMenuItem3.Text = "Abstract"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Image = Global.PCBaOS.My.Resources.Resources.lion
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(152, 24)
        Me.ToolStripMenuItem4.Text = "Lion"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Image = Global.PCBaOS.My.Resources.Resources.sunset
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(152, 24)
        Me.ToolStripMenuItem5.Text = "Sunset"
        '
        'CalendarPanel
        '
        Me.CalendarPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CalendarPanel.Location = New System.Drawing.Point(0, 31)
        Me.CalendarPanel.Name = "CalendarPanel"
        Me.CalendarPanel.Size = New System.Drawing.Size(505, 220)
        Me.CalendarPanel.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(36, 33)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(497, 218)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'TransparentToolStripMenuItem
        '
        Me.TransparentToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.TransparentToolStripMenuItem.Name = "TransparentToolStripMenuItem"
        Me.TransparentToolStripMenuItem.Size = New System.Drawing.Size(203, 24)
        Me.TransparentToolStripMenuItem.Text = "Transparent"
        '
        'GoToTodayToolStripMenuItem
        '
        Me.GoToTodayToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.GoToTodayToolStripMenuItem.Name = "GoToTodayToolStripMenuItem"
        Me.GoToTodayToolStripMenuItem.Size = New System.Drawing.Size(203, 24)
        Me.GoToTodayToolStripMenuItem.Text = "Go to today"
        '
        'SetDateToolStripMenuItem
        '
        Me.SetDateToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.SetDateToolStripMenuItem.Name = "SetDateToolStripMenuItem"
        Me.SetDateToolStripMenuItem.Size = New System.Drawing.Size(203, 24)
        Me.SetDateToolStripMenuItem.Text = "Set date"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(200, 6)
        '
        'CalculateDaysToolStripMenuItem
        '
        Me.CalculateDaysToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.CalculateDaysToolStripMenuItem.Name = "CalculateDaysToolStripMenuItem"
        Me.CalculateDaysToolStripMenuItem.Size = New System.Drawing.Size(203, 24)
        Me.CalculateDaysToolStripMenuItem.Text = "Calculate days"
        '
        'Calendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.PCBaOS.My.Resources.Resources.none
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(505, 250)
        Me.Controls.Add(Me.CalendarPanel)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Calendar"
        Me.Text = "Calendar"
        Me.TopMost = True
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents CalendarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WallpaperToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NONEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CalendarPanel As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TransparentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GoToTodayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetDateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CalculateDaysToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
