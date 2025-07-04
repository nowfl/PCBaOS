Module StatusBarTooltipHelper
    Public Sub ShowTooltip(form As Form, message As String)
        ' Try to find a StatusStrip with ToolStripStatusLabel1 in the form
        Dim statusStrip = form.Controls.OfType(Of StatusStrip)().FirstOrDefault()
        If statusStrip IsNot Nothing Then
            Dim statusLabel = statusStrip.Items.OfType(Of ToolStripStatusLabel)().FirstOrDefault(Function(lbl) lbl.Name = "ToolStripStatusLabel1")
            If statusLabel IsNot Nothing Then
                statusLabel.Text = message
            End If
        End If
    End Sub

    Public Sub ClearTooltip(form As Form)
        ShowTooltip(form, "")
    End Sub
End Module 