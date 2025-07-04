Public Class Notes

    Private Sub NewNoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewNoteToolStripMenuItem.Click
        Dim frmNew As New Notes
        frmNew.Size = Me.Size
        frmNew.Show()
    End Sub

    Private Sub ToolStripComboBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.Click

    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.TextChanged
        If ToolStripComboBox1.Text = "Default" Then
            RichTextBox1.BackColor = Color.PaleGoldenrod
        End If
        If ToolStripComboBox1.Text = "Red" Then
            RichTextBox1.BackColor = Color.Red
        End If
        If ToolStripComboBox1.Text = "Orange" Then
            RichTextBox1.BackColor = Color.Orange
        End If
        If ToolStripComboBox1.Text = "Yellow" Then
            RichTextBox1.BackColor = Color.Yellow
        End If
        If ToolStripComboBox1.Text = "Lime" Then
            RichTextBox1.BackColor = Color.Lime
        End If
        If ToolStripComboBox1.Text = "Green" Then
            RichTextBox1.BackColor = Color.Green
        End If
        If ToolStripComboBox1.Text = "Dark Green" Then
            RichTextBox1.BackColor = Color.DarkGreen
        End If
        If ToolStripComboBox1.Text = "Cyan" Then
            RichTextBox1.BackColor = Color.Cyan
        End If
        If ToolStripComboBox1.Text = "Light Blue" Then
            RichTextBox1.BackColor = Color.LightBlue
        End If
        If ToolStripComboBox1.Text = "Blue" Then
            RichTextBox1.BackColor = Color.Blue
        End If
        If ToolStripComboBox1.Text = "Dark Blue" Then
            RichTextBox1.BackColor = Color.DarkBlue
        End If
        If ToolStripComboBox1.Text = "Purple" Then
            RichTextBox1.BackColor = Color.Purple
        End If
        If ToolStripComboBox1.Text = "Pink" Then
            RichTextBox1.BackColor = Color.Pink
        End If
        If ToolStripComboBox1.Text = "White" Then
            RichTextBox1.BackColor = Color.White
        End If

    End Sub

    Private Sub NewNoteToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewNoteToolStripMenuItem.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Create new note"
    End Sub

    Private Sub NewNoteToolStripMenuItem_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewNoteToolStripMenuItem.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub ToolStripComboBox1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Change color of note"
    End Sub

    Private Sub ToolStripComboBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub boldTextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boldTextButton.Click
        If RichTextBox1.SelectionLength > 0 Then
            Dim isBold As Boolean = (RichTextBox1.SelectionFont.Style And FontStyle.Bold) = FontStyle.Bold

            Dim newFont As New Font(RichTextBox1.SelectionFont, If(isBold, FontStyle.Regular, FontStyle.Bold))

            RichTextBox1.SelectionFont = newFont
        End If
    End Sub

    Private Sub italicTextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles italicTextButton.Click
        If RichTextBox1.SelectionLength > 0 Then
            Dim isItalic As Boolean = (RichTextBox1.SelectionFont.Style And FontStyle.Italic) = FontStyle.Italic

            Dim newFont As New Font(RichTextBox1.SelectionFont, If(isItalic, FontStyle.Regular, FontStyle.Italic))

            RichTextBox1.SelectionFont = newFont
        End If
    End Sub

    Private Sub underlineTextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles underlineTextButton.Click
        If RichTextBox1.SelectionLength > 0 Then
            Dim isUnderline As Boolean = (RichTextBox1.SelectionFont.Style And FontStyle.Underline) = FontStyle.Underline

            Dim newFont As New Font(RichTextBox1.SelectionFont, If(isUnderline, FontStyle.Regular, FontStyle.Underline))

            RichTextBox1.SelectionFont = newFont
        End If
    End Sub

    Private Sub strikethroughTextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles strikethroughTextButton.Click
        If RichTextBox1.SelectionLength > 0 Then
            Dim isStrikethrough As Boolean = (RichTextBox1.SelectionFont.Style And FontStyle.Strikeout) = FontStyle.Strikeout

            Dim newFont As New Font(RichTextBox1.SelectionFont, If(isStrikethrough, FontStyle.Regular, FontStyle.Strikeout))

            RichTextBox1.SelectionFont = newFont
        End If
    End Sub

    Private Sub Notes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class