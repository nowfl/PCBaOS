<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Textpad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Textpad))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NotepadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimeDateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReplaceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FontToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripComboBox2 = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.BoldToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItalicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnderlineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StrikethroughToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NotepadToolStripMenuItem, Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.FormatToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(867, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NotepadToolStripMenuItem
        '
        Me.NotepadToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem})
        Me.NotepadToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NotepadToolStripMenuItem.Name = "NotepadToolStripMenuItem"
        Me.NotepadToolStripMenuItem.Size = New System.Drawing.Size(77, 24)
        Me.NotepadToolStripMenuItem.Text = "Textpad"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloseToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.close
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(114, 24)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ToolStripSeparator1, Me.DocumentToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.newdoc
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.open
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.OpenToolStripMenuItem.Text = "Open..."
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.save
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.saveas
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.SaveAsToolStripMenuItem.Text = "Save as..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'DocumentToolStripMenuItem
        '
        Me.DocumentToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.print
        Me.DocumentToolStripMenuItem.Name = "DocumentToolStripMenuItem"
        Me.DocumentToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.DocumentToolStripMenuItem.Text = "Page Setup"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.printing
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.PrintToolStripMenuItem.Text = "Print..."
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.RedoToolStripMenuItem, Me.ToolStripSeparator2, Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripSeparator3, Me.SelectAllToolStripMenuItem, Me.TimeDateToolStripMenuItem, Me.ToolStripSeparator4, Me.FindToolStripMenuItem, Me.ReplaceToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(47, 24)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.undo
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Z"
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(165, 24)
        Me.UndoToolStripMenuItem.Text = "Undo"
        '
        'RedoToolStripMenuItem
        '
        Me.RedoToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.redo
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        Me.RedoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Y"
        Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(165, 24)
        Me.RedoToolStripMenuItem.Text = "Redo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(162, 6)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.cut
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(165, 24)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.copy
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(165, 24)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.paste
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(165, 24)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(162, 6)
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.selectall
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(165, 24)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'TimeDateToolStripMenuItem
        '
        Me.TimeDateToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.time
        Me.TimeDateToolStripMenuItem.Name = "TimeDateToolStripMenuItem"
        Me.TimeDateToolStripMenuItem.Size = New System.Drawing.Size(165, 24)
        Me.TimeDateToolStripMenuItem.Text = "Time/Date"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(162, 6)
        '
        'FindToolStripMenuItem
        '
        Me.FindToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.find
        Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
        Me.FindToolStripMenuItem.Size = New System.Drawing.Size(165, 24)
        Me.FindToolStripMenuItem.Text = "Find"
        '
        'ReplaceToolStripMenuItem
        '
        Me.ReplaceToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.text
        Me.ReplaceToolStripMenuItem.Name = "ReplaceToolStripMenuItem"
        Me.ReplaceToolStripMenuItem.Size = New System.Drawing.Size(165, 24)
        Me.ReplaceToolStripMenuItem.Text = "Replace"
        '
        'FormatToolStripMenuItem
        '
        Me.FormatToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColorToolStripMenuItem, Me.FontToolStripMenuItem})
        Me.FormatToolStripMenuItem.Name = "FormatToolStripMenuItem"
        Me.FormatToolStripMenuItem.Size = New System.Drawing.Size(68, 24)
        Me.FormatToolStripMenuItem.Text = "Format"
        '
        'ColorToolStripMenuItem
        '
        Me.ColorToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.color
        Me.ColorToolStripMenuItem.Name = "ColorToolStripMenuItem"
        Me.ColorToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.ColorToolStripMenuItem.Text = "Color"
        '
        'FontToolStripMenuItem
        '
        Me.FontToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.font
        Me.FontToolStripMenuItem.Name = "FontToolStripMenuItem"
        Me.FontToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.FontToolStripMenuItem.Text = "Font"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 60)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(867, 345)
        Me.RichTextBox1.TabIndex = 2
        Me.RichTextBox1.Text = ""
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PrintDocument1
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 405)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(867, 25)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(36, 20)
        Me.ToolStripStatusLabel1.Text = "Text"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox2, Me.ToolStripComboBox1, Me.BoldToolStripMenuItem, Me.ItalicToolStripMenuItem, Me.UnderlineToolStripMenuItem, Me.StrikethroughToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 28)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip2.Size = New System.Drawing.Size(867, 32)
        Me.MenuStrip2.TabIndex = 4
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'ToolStripComboBox2
        '
        Me.ToolStripComboBox2.Name = "ToolStripComboBox2"
        Me.ToolStripComboBox2.Size = New System.Drawing.Size(160, 28)
        Me.ToolStripComboBox2.Text = "Arial"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.DropDownWidth = 45
        Me.ToolStripComboBox1.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "14", "16", "18", "20", "24", "28", "32", "48", "56", "64"})
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(99, 28)
        Me.ToolStripComboBox1.Text = "12"
        '
        'BoldToolStripMenuItem
        '
        Me.BoldToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.bold
        Me.BoldToolStripMenuItem.Name = "BoldToolStripMenuItem"
        Me.BoldToolStripMenuItem.Size = New System.Drawing.Size(28, 28)
        '
        'ItalicToolStripMenuItem
        '
        Me.ItalicToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.italic
        Me.ItalicToolStripMenuItem.Name = "ItalicToolStripMenuItem"
        Me.ItalicToolStripMenuItem.Size = New System.Drawing.Size(28, 28)
        '
        'UnderlineToolStripMenuItem
        '
        Me.UnderlineToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.underline
        Me.UnderlineToolStripMenuItem.Name = "UnderlineToolStripMenuItem"
        Me.UnderlineToolStripMenuItem.Size = New System.Drawing.Size(28, 28)
        '
        'StrikethroughToolStripMenuItem
        '
        Me.StrikethroughToolStripMenuItem.Image = Global.PCBaOS.My.Resources.Resources.strikethrough
        Me.StrikethroughToolStripMenuItem.Name = "StrikethroughToolStripMenuItem"
        Me.StrikethroughToolStripMenuItem.Size = New System.Drawing.Size(28, 28)
        '
        'Textpad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 430)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Textpad"
        Me.Text = "Textpad"
        Me.TopMost = True
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NotepadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DocumentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimeDateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents FontToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReplaceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripComboBox2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripComboBox1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents BoldToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItalicToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnderlineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StrikethroughToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
