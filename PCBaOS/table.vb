Imports System.IO
Imports System.ComponentModel

Public Class table
    ' Empty event handlers that can be removed
    ' These aren't being used and just add clutter
    ' Private Sub CloseToolStripMenuItem_Click, Button1_Click, Button2_Click, Button3_Click

    ' Add form load initialization
    Private Sub table_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Initialize the DataGridView with default settings
        InitializeDataGridView()
        InitializeColumnContextMenu()
    End Sub

    ' Initialize DataGridView with default settings
    Private Sub InitializeDataGridView()
        DataGridView1.AllowUserToAddRows = True
        DataGridView1.AllowUserToDeleteRows = True
        DataGridView1.AllowUserToResizeColumns = True
        DataGridView1.MultiSelect = False
        DataGridView1.EditMode = DataGridViewEditMode.EditOnEnter
    End Sub

    ' Initialize context menu for DataGridView columns
    Private Sub InitializeColumnContextMenu()
        columnContextMenu.Items.Clear()
        columnContextMenu.Items.Add("Add Column Before", Nothing, AddressOf AddColumnBefore_Click)
        columnContextMenu.Items.Add("Add Column After", Nothing, AddressOf AddColumnAfter_Click)
        columnContextMenu.Items.Add(New ToolStripSeparator())
        columnContextMenu.Items.Add("Sort Ascending", Nothing, AddressOf SortAscending_Click)
        columnContextMenu.Items.Add("Sort Descending", Nothing, AddressOf SortDescending_Click)
        columnContextMenu.Items.Add(New ToolStripSeparator())
        columnContextMenu.Items.Add("Rename Column", Nothing, AddressOf RenameColumn_Click)
        columnContextMenu.Items.Add(New ToolStripSeparator())
        columnContextMenu.Items.Add("Delete Column", Nothing, AddressOf DeleteColumn_Click)
        AddHandler DataGridView1.ColumnHeaderMouseClick, AddressOf DataGridView1_ColumnHeaderMouseClick
    End Sub

    ' Show context menu on right-click of column header
    Private Sub DataGridView1_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs)
        If e.Button = MouseButtons.Right Then
            clickedColumnIndex = e.ColumnIndex
            columnContextMenu.Show(Cursor.Position)
        End If
    End Sub

    ' Generate a unique column name like "Column1", "Column2", etc.
    Private Function GetNextColumnName() As String
        Dim baseName As String = "Column"
        Dim idx As Integer = 1
        Dim exists As Boolean = True
        While exists
            exists = False
            For Each col As DataGridViewColumn In DataGridView1.Columns
                If col.HeaderText = baseName & idx.ToString() Then
                    exists = True
                    idx += 1
                    Exit For
                End If
            Next
        End While
        Return baseName & idx.ToString()
    End Function

    ' Add column before the clicked column
    Private Sub AddColumnBefore_Click(ByVal sender As Object, ByVal e As EventArgs)
        If clickedColumnIndex >= 0 Then
            Dim newCol As New DataGridViewTextBoxColumn()
            newCol.HeaderText = GetNextColumnName()
            newCol.Name = newCol.HeaderText
            DataGridView1.Columns.Insert(clickedColumnIndex, newCol)
        End If
    End Sub

    ' Add column after the clicked column
    Private Sub AddColumnAfter_Click(ByVal sender As Object, ByVal e As EventArgs)
        If clickedColumnIndex >= 0 Then
            Dim newCol As New DataGridViewTextBoxColumn()
            newCol.HeaderText = GetNextColumnName()
            newCol.Name = newCol.HeaderText
            DataGridView1.Columns.Insert(clickedColumnIndex + 1, newCol)
        End If
    End Sub

    ' Delete the clicked column
    Private Sub DeleteColumn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If clickedColumnIndex >= 0 AndAlso DataGridView1.Columns.Count > 0 Then
            DataGridView1.Columns.RemoveAt(clickedColumnIndex)
        End If
    End Sub

    ' Rename the clicked column
    Private Sub RenameColumn_Click(ByVal sender As Object, ByVal e As EventArgs)
        If clickedColumnIndex >= 0 Then
            Dim currentName As String = DataGridView1.Columns(clickedColumnIndex).HeaderText
            Using dlg As New RenameColumnForm(currentName)
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    Dim newName As String = dlg.NewColumnName
                    If Not String.IsNullOrWhiteSpace(newName) Then
                        DataGridView1.Columns(clickedColumnIndex).HeaderText = newName
                        DataGridView1.Columns(clickedColumnIndex).Name = newName
                    End If
                End If
            End Using
        End If
    End Sub

    ' Sort the clicked column ascending
    Private Sub SortAscending_Click(ByVal sender As Object, ByVal e As EventArgs)
        If clickedColumnIndex >= 0 Then
            Dim col As DataGridViewColumn = DataGridView1.Columns(clickedColumnIndex)
            DataGridView1.Sort(col, ListSortDirection.Ascending)
        End If
    End Sub

    ' Sort the clicked column descending
    Private Sub SortDescending_Click(ByVal sender As Object, ByVal e As EventArgs)
        If clickedColumnIndex >= 0 Then
            Dim col As DataGridViewColumn = DataGridView1.Columns(clickedColumnIndex)
            DataGridView1.Sort(col, ListSortDirection.Descending)
        End If
    End Sub

    ' Improved tooltip behavior
    Private Sub CloseToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.MouseEnter
        WorkSpace.ToolStripStatusLabel1.Text = "Exit the application"
    End Sub

    Private Sub CloseToolStripMenuItem_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.MouseLeave
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    ' Enhanced column management
    ' (Remove AddToolStripMenuItem_Click and RemoveToolStripMenuItem_Click handlers)

    Private Sub CloseToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        ' Check for unsaved changes
        If HasUnsavedChanges() Then
            Dim result As DialogResult = MessageBox.Show("Do you want to save changes before closing?", _
                                                       "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                SaveData()
            ElseIf result = DialogResult.Cancel Then
                Return
            End If
        End If
        Me.Close()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        Try
            ' Confirm before clearing
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to clear all data?", _
                                                       "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                DataGridView1.Rows.Clear()
                DataGridView1.Columns.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show("Error clearing data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Improved file operations
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SaveData()
    End Sub

    Private Sub SaveData()
        ' Check if there's data to save
        If DataGridView1.Columns.Count = 0 Then
            MessageBox.Show("No data to save.", "Empty Table", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        saveFileDialog.DefaultExt = "csv"
        saveFileDialog.Title = "Save Table Data"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                Using writer As New StreamWriter(saveFileDialog.FileName)
                    ' Write column headers
                    Dim headerLine As New System.Text.StringBuilder()
                    For i As Integer = 0 To DataGridView1.Columns.Count - 1
                        ' Properly escape and quote column headers
                        headerLine.Append("""" & DataGridView1.Columns(i).HeaderText.Replace("""", """""") & """")
                        If i < DataGridView1.Columns.Count - 1 Then
                            headerLine.Append(",")
                        End If
                    Next
                    writer.WriteLine(headerLine.ToString())

                    ' Write data rows
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        If Not row.IsNewRow Then
                            Dim dataLine As New System.Text.StringBuilder()
                            For i As Integer = 0 To DataGridView1.Columns.Count - 1
                                ' Handle null values and properly escape cell contents
                                Dim cellValue As String = ""
                                If row.Cells(i).Value IsNot Nothing Then
                                    cellValue = row.Cells(i).Value.ToString().Replace("""", """""")
                                End If
                                dataLine.Append("""" & cellValue & """")
                                If i < DataGridView1.Columns.Count - 1 Then
                                    dataLine.Append(",")
                                End If
                            Next
                            writer.WriteLine(dataLine.ToString())
                        End If
                    Next
                End Using
                MessageBox.Show("Data saved successfully.", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error saving file: " & ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub LoadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadToolStripMenuItem.Click
        LoadData()
    End Sub

    Private Sub LoadData()
        ' Check for unsaved changes before loading
        If HasUnsavedChanges() Then
            Dim result As DialogResult = MessageBox.Show("Loading a file will replace current data. Do you want to save changes first?", _
                                                       "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                SaveData()
            ElseIf result = DialogResult.Cancel Then
                Return
            End If
        End If

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
        openFileDialog.DefaultExt = "csv"
        openFileDialog.Title = "Open Table Data"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                DataGridView1.Rows.Clear()
                DataGridView1.Columns.Clear()

                ' Use TextFieldParser for proper CSV parsing
                Using parser As New Microsoft.VisualBasic.FileIO.TextFieldParser(openFileDialog.FileName)
                    parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
                    parser.SetDelimiters(",")
                    parser.HasFieldsEnclosedInQuotes = True

                    ' Read headers
                    If Not parser.EndOfData Then
                        Dim headers As String() = parser.ReadFields()
                        For i As Integer = 0 To headers.Length - 1
                            If Not String.IsNullOrEmpty(headers(i)) Then
                                Dim newColumn As New DataGridViewTextBoxColumn()
                                newColumn.HeaderText = headers(i)
                                newColumn.Name = headers(i)
                                DataGridView1.Columns.Add(newColumn)
                            End If
                        Next
                    End If

                    ' Read data
                    While Not parser.EndOfData
                        Try
                            Dim values As String() = parser.ReadFields()
                            ' Only add row if we have actual data
                            If values.Length > 0 AndAlso Not IsEmptyRow(values) Then
                                Dim rowIndex As Integer = DataGridView1.Rows.Add()
                                Dim row As DataGridViewRow = DataGridView1.Rows(rowIndex)
                                For i As Integer = 0 To Math.Min(values.Length - 1, row.Cells.Count - 1)
                                    row.Cells(i).Value = values(i)
                                Next
                            End If
                        Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                            ' Log the error but continue processing
                            Console.WriteLine("Line " & ex.Message & " is invalid and will be skipped.")
                        End Try
                    End While
                End Using

                MessageBox.Show("Data loaded successfully.", "Load Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error loading file: " & ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function IsEmptyRow(ByVal values As String()) As Boolean
        For Each value As String In values
            If Not String.IsNullOrEmpty(value.Trim()) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Try
            ' Check for unsaved changes
            If HasUnsavedChanges() Then
                Dim result As DialogResult = MessageBox.Show("Creating a new table will discard current data. Do you want to save changes first?", _
                                                          "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    SaveData()
                ElseIf result = DialogResult.Cancel Then
                    Return
                End If
            End If

            DataGridView1.Rows.Clear()
            DataGridView1.Columns.Clear()
            InitializeDataGridView()
        Catch ex As Exception
            MessageBox.Show("Error creating new table: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Track changes
    Private _hasChanges As Boolean = False

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        _hasChanges = True
    End Sub

    Private Sub DataGridView1_UserAddedRow(ByVal sender As Object, ByVal e As DataGridViewRowEventArgs) Handles DataGridView1.UserAddedRow
        _hasChanges = True
    End Sub

    Private Sub DataGridView1_UserDeletedRow(ByVal sender As Object, ByVal e As DataGridViewRowEventArgs) Handles DataGridView1.UserDeletedRow
        _hasChanges = True
    End Sub

    Private Sub DataGridView1_ColumnAdded(ByVal sender As Object, ByVal e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnAdded
        _hasChanges = True
    End Sub

    Private Sub DataGridView1_ColumnRemoved(ByVal sender As Object, ByVal e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnRemoved
        _hasChanges = True
    End Sub

    Private Function HasUnsavedChanges() As Boolean
        Return _hasChanges
    End Function

    Private clickedColumnIndex As Integer = -1
End Class