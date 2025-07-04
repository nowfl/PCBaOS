Imports System.Drawing.Printing

Public Class Textpad

    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        RichTextBox1.Clear()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFromKernel()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        RichTextBox1.Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        RichTextBox1.Redo()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        RichTextBox1.Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        RichTextBox1.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        RichTextBox1.Paste()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim pos As Integer
        pos = InStr(1, RichTextBox1.Text, RichTextBox1.Text)
        If pos > 0 Then 'If found test
            RichTextBox1.SelectionStart = pos - 1
            RichTextBox1.SelectionLength = Len(RichTextBox1.Text)
            RichTextBox1.Focus()  'Get Focus
        End If
    End Sub

    Private Sub TimeDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeDateToolStripMenuItem.Click
        RichTextBox1.Text += Date.Today
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        ' Create a new PrintDocument object
        Dim printDoc As New PrintDocument()

        ' Create a new PrintDialog object
        Dim printDlg As New PrintDialog()

        ' Set the PrintDocument object as the document to be printed by the PrintDialog
        printDlg.Document = printDoc

        ' Show the PrintDialog and wait for the user to select a printer
        If printDlg.ShowDialog() = DialogResult.OK Then
            ' Set the PrintDocument's default page settings
            printDoc.DefaultPageSettings = New Printing.PageSettings()

            ' Set the PrintDocument's default printer settings
            printDoc.PrinterSettings = printDlg.PrinterSettings

            ' Set the PrintDocument's document name
            printDoc.DocumentName = "Print Document"

            ' Add an event handler to the PrintDocument's PrintPage event
            AddHandler printDoc.PrintPage, AddressOf printDoc_PrintPage

            ' Start the printing process
            printDoc.Print()
        End If
    End Sub

    Private Sub FontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CloseToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Exit the application"
    End Sub

    Private Sub CloseToolStripMenuItem_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    ' Open handler for Textpad, using FileLoadDialog restricted to Kernel
    Private Sub OpenFromKernel()
        Dim kernelPath As String = IO.Path.Combine(Application.StartupPath, "Kernel")
        Dim dlg As New FileLoadDialog(kernelPath)
        dlg.AvailableFilters = New List(Of String)({"All Files", "Text Files (*.txt;*.xml)", "Rich Text Format (*.rtf)"})
        dlg.DefaultFilter = "Text Files (*.txt;*.xml)"
        If dlg.ShowDialog(Me) = DialogResult.OK Then
            Dim filePath As String = dlg.SelectedFile
            If IO.File.Exists(filePath) Then
                Try
                    Dim ext As String = IO.Path.GetExtension(filePath).ToLower()
                    If ext = ".rtf" Then
                        RichTextBox1.LoadFile(filePath, RichTextBoxStreamType.RichText)
                    ElseIf ext = ".txt" Or ext = ".xml" Then
                        RichTextBox1.LoadFile(filePath, RichTextBoxStreamType.PlainText)
                    Else
                        MessageBox.Show("Unsupported file type for Textpad.")
                        Return
                    End If
                    Me.Text = filePath & " - Textpad"
                    filePathVar = filePath
                Catch ex As Exception
                    MessageBox.Show("Could not load file: " & ex.Message)
                End Try
            End If
        End If
    End Sub

    ' Save As handler for Textpad, using FileSaveDialog restricted to Kernel
    Private Sub SaveAsToKernel()
        Dim kernelPath As String = IO.Path.Combine(Application.StartupPath, "Kernel")
        Dim dlg As New FileSaveDialog(kernelPath)
        dlg.AvailableFormats = New List(Of String)({"txt", "rtf", "xml"})
        ' Set default format based on current file or default to txt
        Dim ext As String = IO.Path.GetExtension(filePathVar).ToLower().TrimStart("."c)
        If ext = "rtf" Or ext = "txt" Or ext = "xml" Then
            dlg.SelectedFormat = ext
        Else
            dlg.SelectedFormat = "txt"
        End If
        If dlg.ShowDialog(Me) = DialogResult.OK Then
            Dim savePath As String = IO.Path.Combine(dlg.SelectedFolder, dlg.FileName)
            Dim format As String = dlg.SelectedFormat.ToLower()
            Try
                If format = "rtf" Then
                    RichTextBox1.SaveFile(savePath, RichTextBoxStreamType.RichText)
                ElseIf format = "txt" Or format = "xml" Then
                    RichTextBox1.SaveFile(savePath, RichTextBoxStreamType.PlainText)
                Else
                    MessageBox.Show("Unsupported format for Textpad.")
                    Return
                End If
                Me.Text = savePath & " - Textpad"
                filePathVar = savePath
                MessageBox.Show("File saved to: " & savePath, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Failed to save file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Save handler for Textpad, using FileSaveDialog if no filePathVar
    Private Sub SaveToKernel()
        If String.IsNullOrEmpty(filePathVar) Then
            SaveAsToKernel()
        Else
            Try
                Dim ext As String = IO.Path.GetExtension(filePathVar).ToLower()
                If ext = ".rtf" Then
                    RichTextBox1.SaveFile(filePathVar, RichTextBoxStreamType.RichText)
                ElseIf ext = ".txt" Or ext = ".xml" Then
                    RichTextBox1.SaveFile(filePathVar, RichTextBoxStreamType.PlainText)
                Else
                    RichTextBox1.SaveFile(filePathVar, RichTextBoxStreamType.PlainText)
                End If
                Me.Text = filePathVar & " - Textpad"
            Catch ex As Exception
                MessageBox.Show("Failed to save file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Store the current file path
    Private filePathVar As String = ""
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SaveToKernel()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        RichTextBox1.SelectAll()
    End Sub

    Private Sub ColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorToolStripMenuItem.Click
        Dim colorDlg As New ColorDialog()
        If colorDlg.ShowDialog() = DialogResult.OK Then
            RichTextBox1.SelectionColor = colorDlg.Color
        End If
    End Sub

    Private Sub FontToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripMenuItem.Click
        Dim fontDialog As New FontDialog()
        If fontDialog.ShowDialog() = DialogResult.OK Then
            RichTextBox1.Font = fontDialog.Font
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveAsToKernel()
    End Sub

    Private Sub DocumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentToolStripMenuItem.Click
        Dim pageSetupDialog As New PageSetupDialog()
        Dim printDocument As New Printing.PrintDocument()
        pageSetupDialog.Document = printDocument
        If pageSetupDialog.ShowDialog() = DialogResult.OK Then
            printDocument.DefaultPageSettings.Margins = pageSetupDialog.PageSettings.Margins
            printDocument.DefaultPageSettings.Landscape = pageSetupDialog.PageSettings.Landscape
            printDocument.DefaultPageSettings.PaperSize = pageSetupDialog.PageSettings.PaperSize

            RichTextBox1.Refresh()
        End If
    End Sub

    Private Sub printDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString(RichTextBox1.Text, RichTextBox1.Font, Brushes.Black, e.MarginBounds)
    End Sub

    Private Sub FindToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click
        Dim searchText As String = InputBox("Enter the text to search for:", "Search")

        If searchText <> "" Then
            Dim startPos As Integer = RichTextBox1.SelectionStart

            Dim index As Integer = RichTextBox1.Find(searchText, startPos, RichTextBoxFinds.None)

            If index >= 0 Then
                RichTextBox1.Select(index, searchText.Length)
                RichTextBox1.ScrollToCaret()
            Else
                MessageBox.Show("The text was not found.", "Search")
            End If
        End If
    End Sub

    Private Sub ReplaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceToolStripMenuItem.Click
        Dim searchText As String = InputBox("Enter the text to search for:", "Search")

        If searchText <> "" Then
            Dim startPos As Integer = RichTextBox1.SelectionStart

            Dim index As Integer = RichTextBox1.Find(searchText, startPos, RichTextBoxFinds.None)

            If index >= 0 Then
                Dim replaceText As String = InputBox("Enter the text to replace the selected text with:", "Replace")

                If replaceText <> "" Then
                    RichTextBox1.SelectedText = replaceText
                End If
            Else
                MessageBox.Show("The text was not found.", "Search")
            End If
        End If
    End Sub

    Private Sub FindNextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim searchText As String = InputBox("Enter the text to search for:", "Find Next")

        If searchText <> "" Then
            Dim startPos As Integer = RichTextBox1.SelectionStart + RichTextBox1.SelectionLength

            Dim index As Integer = RichTextBox1.Find(searchText, startPos, RichTextBoxFinds.None)

            If index >= 0 Then
                RichTextBox1.Select(index, searchText.Length)
            Else
                MessageBox.Show("The text was not found.", "Find Next")
            End If
        End If
    End Sub

    Private Sub RichTextBox1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.SelectionChanged
        Dim selectedText As String = RichTextBox1.SelectedText
        Dim selectedTextLength As Integer = selectedText.Length
        Dim caretPosition As Integer = RichTextBox1.SelectionStart
        Dim line As Integer = RichTextBox1.GetLineFromCharIndex(caretPosition) + 1
        Dim column As Integer = caretPosition - RichTextBox1.GetFirstCharIndexOfCurrentLine() + 1
        ToolStripStatusLabel1.Text = "Selected: " & selectedTextLength & " characters, Line: " & line & ", Column: " & column
    End Sub

    ' Universal startup parameters for future extensibility
    Public Property StartupParameters As New Dictionary(Of String, Object)()
    Private Sub Textpad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Populate font families
        ToolStripComboBox2.Items.Clear()
        For Each fontFamily As FontFamily In FontFamily.Families
            ToolStripComboBox2.Items.Add(fontFamily.Name)
        Next
        ToolStripComboBox2.Text = RichTextBox1.Font.FontFamily.Name

        ' Populate font sizes
        ToolStripComboBox1.Items.Clear()
        Dim sizes As Integer() = {8, 9, 10, 11, 12, 14, 16, 18, 20, 24, 28, 32, 48, 56, 64}
        For i As Integer = 0 To sizes.Length - 1
            ToolStripComboBox1.Items.Add(sizes(i).ToString())
        Next
        ToolStripComboBox1.Text = CInt(RichTextBox1.Font.Size).ToString()

        ' Universal startup: load file if provided
        If StartupParameters IsNot Nothing AndAlso StartupParameters.ContainsKey("FilePath") Then
            Dim filePath As String = CStr(StartupParameters("FilePath"))
            If IO.File.Exists(filePath) Then
                Try
                    Dim ext As String = IO.Path.GetExtension(filePath).ToLower()
                    If ext = ".rtf" Then
                        RichTextBox1.LoadFile(filePath, RichTextBoxStreamType.RichText)
                    ElseIf ext = ".txt" Or ext = ".xml" Then
                        RichTextBox1.LoadFile(filePath, RichTextBoxStreamType.PlainText)
                    End If
                    Me.Text = filePath & " - Textpad"
                Catch ex As Exception
                    MessageBox.Show("Could not load file: " & ex.Message)
                End Try
            End If
        End If

        ' Update status bar
        Dim selectedText As String = RichTextBox1.SelectedText
        Dim selectedTextLength As Integer = selectedText.Length
        Dim caretPosition As Integer = RichTextBox1.SelectionStart
        Dim line As Integer = RichTextBox1.GetLineFromCharIndex(caretPosition) + 1
        Dim column As Integer = caretPosition - RichTextBox1.GetFirstCharIndexOfCurrentLine() + 1
        ToolStripStatusLabel1.Text = "Selected: " & selectedTextLength & " characters, Line: " & line & ", Column: " & column
    End Sub

    Private Sub ToolStripComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox2.SelectedIndexChanged
        ChangeFont()
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        ChangeFont()
    End Sub

    Private Sub ChangeFont()
        Dim fontName As String = ToolStripComboBox2.Text
        Dim fontSize As Single = 12
        Single.TryParse(ToolStripComboBox1.Text, fontSize)
        Dim selStart As Integer = RichTextBox1.SelectionStart
        Dim selLength As Integer = RichTextBox1.SelectionLength
        If selLength = 0 Then
            ' No selection: change typing style
            Dim style As FontStyle = If(RichTextBox1.SelectionFont IsNot Nothing, RichTextBox1.SelectionFont.Style, FontStyle.Regular)
            RichTextBox1.SelectionFont = New Font(fontName, fontSize, style)
        Else
            ' Selection: apply font/size to each character
            Dim oldSelectionStart As Integer = selStart
            Dim oldSelectionLength As Integer = selLength
            For i As Integer = selStart To selStart + selLength - 1
                RichTextBox1.Select(i, 1)
                Dim charFont As Font = RichTextBox1.SelectionFont
                If charFont Is Nothing Then charFont = RichTextBox1.Font
                Dim style As FontStyle = charFont.Style
                RichTextBox1.SelectionFont = New Font(fontName, fontSize, style)
            Next
            ' Restore selection
            RichTextBox1.Select(oldSelectionStart, oldSelectionLength)
        End If
    End Sub

    Private Sub BoldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoldToolStripMenuItem.Click
        ToggleFontStyle(FontStyle.Bold)
    End Sub

    Private Sub ItalicToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItalicToolStripMenuItem.Click
        ToggleFontStyle(FontStyle.Italic)
    End Sub

    Private Sub UnderlineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnderlineToolStripMenuItem.Click
        ToggleFontStyle(FontStyle.Underline)
    End Sub

    Private Sub StrikethroughToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StrikethroughToolStripMenuItem.Click
        ToggleFontStyle(FontStyle.Strikeout)
    End Sub

    Private Sub ToggleFontStyle(style As FontStyle)
        Dim selStart As Integer = RichTextBox1.SelectionStart
        Dim selLength As Integer = RichTextBox1.SelectionLength
        If selLength = 0 Then
            ' No selection: change typing style
            Dim currentFont As Font = RichTextBox1.SelectionFont
            If currentFont Is Nothing Then currentFont = RichTextBox1.Font
            Dim newStyle As FontStyle = currentFont.Style Xor style
            RichTextBox1.SelectionFont = New Font(currentFont, newStyle)
        Else
            ' Selection: apply style to each character
            Dim oldSelectionStart As Integer = selStart
            Dim oldSelectionLength As Integer = selLength
            For i As Integer = selStart To selStart + selLength - 1
                RichTextBox1.Select(i, 1)
                Dim charFont As Font = RichTextBox1.SelectionFont
                If charFont Is Nothing Then charFont = RichTextBox1.Font
                Dim newStyle As FontStyle = charFont.Style Xor style
                RichTextBox1.SelectionFont = New Font(charFont, newStyle)
            Next
            ' Restore selection
            RichTextBox1.Select(oldSelectionStart, oldSelectionLength)
        End If
    End Sub
End Class