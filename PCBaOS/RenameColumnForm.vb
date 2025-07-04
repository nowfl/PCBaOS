Imports System.Windows.Forms

Public Class RenameColumnForm
    Inherits Form

    Public Property NewColumnName As String

    Private textBox As TextBox
    Private okButton As Button
    Private renameCancelButton As Button

    Public Sub New(ByVal currentName As String)
        Me.Text = "Rename Column"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Width = 300
        Me.Height = 130
        Me.TopMost = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.NewColumnName = currentName

        textBox = New TextBox()
        textBox.Left = 15
        textBox.Top = 15
        textBox.Width = 250
        textBox.Text = currentName
        AddHandler textBox.KeyDown, AddressOf TextBox_KeyDown
        Me.Controls.Add(textBox)

        okButton = New Button()
        okButton.Text = "OK"
        okButton.Left = 110
        okButton.Top = 50
        okButton.Width = 70
        AddHandler okButton.Click, AddressOf OkButton_Click
        Me.Controls.Add(okButton)

        renameCancelButton = New Button()
        renameCancelButton.Text = "Cancel"
        renameCancelButton.Left = 190
        renameCancelButton.Top = 50
        renameCancelButton.Width = 70
        AddHandler renameCancelButton.Click, AddressOf CancelButton_Click
        Me.Controls.Add(renameCancelButton)
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs)
        Me.NewColumnName = textBox.Text.Trim()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            OkButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.Escape Then
            CancelButton_Click(sender, e)
        End If
    End Sub
End Class 