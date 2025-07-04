Imports System.Drawing.Text

Public Class SuperText

    Private Sub SuperText_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Settings.supertexttotalopened += 1
        Dim fonts As New InstalledFontCollection()

        ' Get all the available font families and add them to the ToolStripComboBox
        For Each fontFamily As FontFamily In fonts.Families
            ToolStripComboBox2.Items.Add(fontFamily.Name)
        Next
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        MsgBox("SuperText" & vbNewLine & "Created by Abrahamz" & vbNewLine & "Total launched: " & My.Settings.supertexttotalopened & vbNewLine, MsgBoxStyle.OkOnly, "SuperText")
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Me.Close()
    End Sub

    Private Sub ToolStripComboBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox2.Click

    End Sub

    Private Sub ToolStripComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox2.SelectedIndexChanged
        Dim selectedFont As Font = New Font(ToolStripComboBox2.SelectedItem.ToString(), RichTextBox1.Font.Size)

        If RichTextBox1.SelectionFont IsNot Nothing AndAlso RichTextBox1.SelectionFont.FontFamily.Equals(selectedFont.FontFamily) Then
            ' The selected text already has the same font, so remove the font
            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
        Else
            ' Apply the selected font to the selected text
            RichTextBox1.Font = selectedFont
            RichTextBox1.SelectionFont = selectedFont
        End If
    End Sub

    Private Sub BoldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoldToolStripMenuItem.Click

    End Sub

    Private Sub ItalicToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItalicToolStripMenuItem.Click

    End Sub

    Private Sub UnderlineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnderlineToolStripMenuItem.Click

    End Sub

    Private Sub StrikethroughToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StrikethroughToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripComboBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.Click

    End Sub
End Class