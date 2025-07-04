<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Notes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Notes))
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.italicTextButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.underlineTextButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.strikethroughTextButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewNoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.boldTextButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 27)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(295, 186)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = "Note"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewNoteToolStripMenuItem, Me.ToolStripComboBox1, Me.boldTextButton, Me.italicTextButton, Me.underlineTextButton, Me.strikethroughTextButton})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(295, 27)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.DropDownWidth = 75
        Me.ToolStripComboBox1.IntegralHeight = False
        Me.ToolStripComboBox1.Items.AddRange(New Object() {"Default", "Red", "Orange", "Yellow", "Lime", "Green", "Dark Green", "Cyan", "Light Blue", "Blue", "Dark Blue", "Purple", "Pink", "White"})
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(85, 23)
        Me.ToolStripComboBox1.Text = "Default"
        '
        'italicTextButton
        '
        Me.italicTextButton.Image = Global.PCBaOS.My.Resources.Resources.italic
        Me.italicTextButton.Name = "italicTextButton"
        Me.italicTextButton.Size = New System.Drawing.Size(28, 23)
        '
        'underlineTextButton
        '
        Me.underlineTextButton.Image = Global.PCBaOS.My.Resources.Resources.underline
        Me.underlineTextButton.Name = "underlineTextButton"
        Me.underlineTextButton.Size = New System.Drawing.Size(28, 23)
        '
        'strikethroughTextButton
        '
        Me.strikethroughTextButton.Image = Global.PCBaOS.My.Resources.Resources.strikethrough
        Me.strikethroughTextButton.Name = "strikethroughTextButton"
        Me.strikethroughTextButton.Size = New System.Drawing.Size(28, 23)
        '
        'NewNoteToolStripMenuItem
        '
        Me.NewNoteToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.newnote
        Me.NewNoteToolStripMenuItem.Name = "NewNoteToolStripMenuItem"
        Me.NewNoteToolStripMenuItem.Size = New System.Drawing.Size(88, 23)
        Me.NewNoteToolStripMenuItem.Text = "New Note"
        '
        'boldTextButton
        '
        Me.boldTextButton.Image = Global.PCBaOS.My.Resources.Resources.bold
        Me.boldTextButton.Name = "boldTextButton"
        Me.boldTextButton.Size = New System.Drawing.Size(28, 23)
        '
        'Notes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 213)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(200, 220)
        Me.Name = "Notes"
        Me.TopMost = True
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewNoteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripComboBox1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents boldTextButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents italicTextButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents underlineTextButton As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents strikethroughTextButton As System.Windows.Forms.ToolStripMenuItem
End Class
