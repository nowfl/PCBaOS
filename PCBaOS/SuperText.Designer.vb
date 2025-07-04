<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SuperText
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripComboBox2 = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.BoldToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItalicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnderlineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StrikethroughToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox2, Me.ToolStripComboBox1, Me.BoldToolStripMenuItem, Me.ItalicToolStripMenuItem, Me.UnderlineToolStripMenuItem, Me.StrikethroughToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 28)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1123, 32)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
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
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip2.Size = New System.Drawing.Size(1123, 28)
        Me.MenuStrip2.TabIndex = 1
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripSeparator2, Me.ToolStripMenuItem3})
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(91, 24)
        Me.ToolStripMenuItem1.Text = "SuperText"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem2.Image = Global.PCBaOS.My.Resources.Resources.about
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(119, 24)
        Me.ToolStripMenuItem2.Text = "About"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(116, 6)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripMenuItem3.Image = Global.PCBaOS.My.Resources.Resources.close1
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(119, 24)
        Me.ToolStripMenuItem3.Text = "Close"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(44, 24)
        Me.ToolStripMenuItem4.Text = "File"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(47, 24)
        Me.ToolStripMenuItem5.Text = "Edit"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(53, 24)
        Me.ToolStripMenuItem6.Text = "View"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 60)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(1123, 397)
        Me.RichTextBox1.TabIndex = 2
        Me.RichTextBox1.Text = ""
        '
        'SuperText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1123, 457)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "SuperText"
        Me.Text = "SuperText"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripComboBox2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripComboBox1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents BoldToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItalicToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnderlineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StrikethroughToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
End Class
