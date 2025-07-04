<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImgView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImgView))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripSplitButton6 = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripSplitButton2 = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSplitButton3 = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripSplitButton5 = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripSplitButton7 = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CropButton = New System.Windows.Forms.ToolStripSplitButton()
        Me.UndoButton = New System.Windows.Forms.ToolStripSplitButton()
        Me.ResetButton = New System.Windows.Forms.ToolStripSplitButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem, Me.OpenToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1442, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem1})
        Me.CloseToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(83, 24)
        Me.CloseToolStripMenuItem.Text = "ImgView"
        '
        'CloseToolStripMenuItem1
        '
        Me.CloseToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseToolStripMenuItem1.Image = Global.PCBaOS.My.Resources.Resources.close
        Me.CloseToolStripMenuItem1.Name = "CloseToolStripMenuItem1"
        Me.CloseToolStripMenuItem1.Size = New System.Drawing.Size(114, 24)
        Me.CloseToolStripMenuItem1.Text = "Close"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.open
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(73, 24)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "All Files|*.*|PNG|*.png|JPEG|*.jpg; *.jpeg; *.jfif|BMP|*.bmp|TIFF|*.tiff; *.tif|G" & _
            "IF|*.gif"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSplitButton6, Me.ToolStripStatusLabel3, Me.ToolStripSplitButton1, Me.ToolStripSplitButton2, Me.ToolStripStatusLabel1, Me.ToolStripSplitButton3, Me.ToolStripSplitButton5, Me.ToolStripSplitButton7, Me.ToolStripStatusLabel2, Me.CropButton, Me.UndoButton, Me.ResetButton})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 638)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1442, 25)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripSplitButton6
        '
        Me.ToolStripSplitButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton6.DropDownButtonWidth = 0
        Me.ToolStripSplitButton6.Image = Global.PCBaOS.My.Resources.Resources.image16
        Me.ToolStripSplitButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton6.Name = "ToolStripSplitButton6"
        Me.ToolStripSplitButton6.Size = New System.Drawing.Size(21, 23)
        Me.ToolStripSplitButton6.Text = "ToolStripSplitButton6"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(21, 20)
        Me.ToolStripStatusLabel3.Text = " | "
        Me.ToolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownButtonWidth = 0
        Me.ToolStripSplitButton1.Image = Global.PCBaOS.My.Resources.Resources.leftrotate
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(21, 23)
        Me.ToolStripSplitButton1.Text = "ToolStripSplitButton1"
        '
        'ToolStripSplitButton2
        '
        Me.ToolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton2.DropDownButtonWidth = 0
        Me.ToolStripSplitButton2.Image = Global.PCBaOS.My.Resources.Resources.rightrotate
        Me.ToolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton2.Name = "ToolStripSplitButton2"
        Me.ToolStripSplitButton2.Size = New System.Drawing.Size(21, 23)
        Me.ToolStripSplitButton2.Text = "ToolStripSplitButton2"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(21, 20)
        Me.ToolStripStatusLabel1.Text = " | "
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ToolStripSplitButton3
        '
        Me.ToolStripSplitButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton3.DropDownButtonWidth = 0
        Me.ToolStripSplitButton3.Image = Global.PCBaOS.My.Resources.Resources.plus
        Me.ToolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton3.Name = "ToolStripSplitButton3"
        Me.ToolStripSplitButton3.Size = New System.Drawing.Size(21, 23)
        Me.ToolStripSplitButton3.Text = "ToolStripSplitButton3"
        '
        'ToolStripSplitButton5
        '
        Me.ToolStripSplitButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton5.DropDownButtonWidth = 0
        Me.ToolStripSplitButton5.Image = Global.PCBaOS.My.Resources.Resources.dot1
        Me.ToolStripSplitButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton5.Name = "ToolStripSplitButton5"
        Me.ToolStripSplitButton5.Size = New System.Drawing.Size(21, 23)
        Me.ToolStripSplitButton5.Text = "ToolStripSplitButton5"
        '
        'ToolStripSplitButton7
        '
        Me.ToolStripSplitButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton7.DropDownButtonWidth = 0
        Me.ToolStripSplitButton7.Image = Global.PCBaOS.My.Resources.Resources.minus
        Me.ToolStripSplitButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton7.Name = "ToolStripSplitButton7"
        Me.ToolStripSplitButton7.Size = New System.Drawing.Size(21, 23)
        Me.ToolStripSplitButton7.Text = "ToolStripSplitButton4"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(21, 20)
        Me.ToolStripStatusLabel2.Text = " | "
        Me.ToolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CropButton
        '
        Me.CropButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CropButton.DropDownButtonWidth = 0
        Me.CropButton.Image = Global.PCBaOS.My.Resources.Resources.ruler16
        Me.CropButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CropButton.Name = "CropButton"
        Me.CropButton.Size = New System.Drawing.Size(21, 23)
        Me.CropButton.Text = "ToolStripSplitButton4"
        '
        'UndoButton
        '
        Me.UndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UndoButton.DropDownButtonWidth = 0
        Me.UndoButton.Image = Global.PCBaOS.My.Resources.Resources.undo
        Me.UndoButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.UndoButton.Name = "UndoButton"
        Me.UndoButton.Size = New System.Drawing.Size(21, 23)
        Me.UndoButton.Text = "ToolStripSplitButton4"
        '
        'ResetButton
        '
        Me.ResetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ResetButton.DropDownButtonWidth = 0
        Me.ResetButton.Image = Global.PCBaOS.My.Resources.Resources.refresh16
        Me.ResetButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(21, 23)
        Me.ResetButton.Text = "ToolStripSplitButton4"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(17, 34)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1408, 598)
        Me.Panel1.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PictureBox1.Location = New System.Drawing.Point(4, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1400, 594)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'ImgView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1442, 663)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ImgView"
        Me.Text = "ImgView"
        Me.TopMost = True
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripSplitButton2 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripSplitButton3 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents CropButton As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripSplitButton5 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripSplitButton6 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripSplitButton7 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ResetButton As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents UndoButton As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
End Class
