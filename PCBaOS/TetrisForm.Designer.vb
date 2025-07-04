<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TetrisForm
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
        Me.txtGuess = New System.Windows.Forms.TextBox()
        Me.lblWord = New System.Windows.Forms.Label()
        Me.pbHangman = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.pbHangman, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtGuess
        '
        Me.txtGuess.Location = New System.Drawing.Point(218, 12)
        Me.txtGuess.Name = "txtGuess"
        Me.txtGuess.Size = New System.Drawing.Size(164, 20)
        Me.txtGuess.TabIndex = 1
        '
        'lblWord
        '
        Me.lblWord.AutoSize = True
        Me.lblWord.Location = New System.Drawing.Point(218, 70)
        Me.lblWord.Name = "lblWord"
        Me.lblWord.Size = New System.Drawing.Size(39, 13)
        Me.lblWord.TabIndex = 2
        Me.lblWord.Text = "Label1"
        '
        'pbHangman
        '
        Me.pbHangman.Location = New System.Drawing.Point(12, 12)
        Me.pbHangman.Name = "pbHangman"
        Me.pbHangman.Size = New System.Drawing.Size(200, 200)
        Me.pbHangman.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbHangman.TabIndex = 3
        Me.pbHangman.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(307, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Guess!"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TetrisForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 222)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pbHangman)
        Me.Controls.Add(Me.lblWord)
        Me.Controls.Add(Me.txtGuess)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TetrisForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hangman"
        Me.TopMost = True
        CType(Me.pbHangman, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtGuess As System.Windows.Forms.TextBox
    Friend WithEvents lblWord As System.Windows.Forms.Label
    Friend WithEvents pbHangman As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
