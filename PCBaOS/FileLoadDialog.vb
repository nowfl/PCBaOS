Public Class FileLoadDialog
    Public Property SelectedFile As String = ""
    Public Property SelectedFilter As String = "All Files"
    Public Property DefaultFilter As String = Nothing
    Public Property AvailableFilters As List(Of String) = Nothing

    Private tree As TreeView
    Private lstFiles As ListBox
    Private btnOK As Button
    Private btnCancel As Button
    Private lblFolder As Label
    Private lblFiles As Label
    Private cmbFilter As ComboBox
    Private folderContextMenu As ContextMenuStrip

    Private KernelPath As String

    Public Sub New(ByVal kernelRoot As String)
        Me.KernelPath = kernelRoot
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Width = 500
        Me.Height = 400
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.Text = "Open"
        Me.TopMost = True

        lblFolder = New Label()
        lblFolder.Text = "Folders:"
        lblFolder.Left = 10
        lblFolder.Top = 10
        lblFolder.Width = 120
        Me.Controls.Add(lblFolder)

        tree = New TreeView()
        tree.Left = 10
        tree.Top = 30
        tree.Width = 200
        tree.Height = 260
        tree.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Bottom
        AddHandler tree.AfterSelect, AddressOf Tree_AfterSelect
        AddHandler tree.NodeMouseClick, AddressOf Tree_NodeMouseClick
        Me.Controls.Add(tree)
        LoadFolders(KernelPath, tree)

        ' Setup context menu for folders
        folderContextMenu = New ContextMenuStrip()
        Dim menuOpenInFileManager As New ToolStripMenuItem("Open in File Manager", Nothing, AddressOf MenuOpenInFileManager_Click)
        folderContextMenu.Items.Add(menuOpenInFileManager)

        lblFiles = New Label()
        lblFiles.Text = "Files:"
        lblFiles.Left = 220
        lblFiles.Top = 10
        lblFiles.Width = 120
        Me.Controls.Add(lblFiles)

        lstFiles = New ListBox()
        lstFiles.Left = 220
        lstFiles.Top = 30
        lstFiles.Width = 250
        lstFiles.Height = 260
        lstFiles.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
        Me.Controls.Add(lstFiles)

        btnOK = New Button()
        btnOK.Text = "OK"
        btnOK.Left = 290
        btnOK.Top = 310
        btnOK.Width = 80
        AddHandler btnOK.Click, AddressOf BtnOK_Click
        Me.Controls.Add(btnOK)

        btnCancel = New Button()
        btnCancel.Text = "Cancel"
        btnCancel.Left = 390
        btnCancel.Top = 310
        btnCancel.Width = 80
        AddHandler btnCancel.Click, Sub()
                                        Me.DialogResult = DialogResult.Cancel
                                        Me.Close()
                                    End Sub
        Me.Controls.Add(btnCancel)

        ' ComboBox for file type filter
        cmbFilter = New ComboBox()
        cmbFilter.Left = 10
        cmbFilter.Top = 300
        cmbFilter.Width = 200
        cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList
        Dim filtersToUse As String()
        If AvailableFilters IsNot Nothing AndAlso AvailableFilters.Count > 0 Then
            filtersToUse = AvailableFilters.ToArray()
        Else
            filtersToUse = New String() {"All Files", "Text Files (*.txt;*.xml)", "Rich Text Format (*.rtf)", "Images (*.png;*.jpg;*.jpeg)", "Audio Files (*.mp3;*.wav;*.wma)"}
        End If
        cmbFilter.Items.AddRange(filtersToUse)
        AddHandler cmbFilter.SelectedIndexChanged, AddressOf cmbFilter_SelectedIndexChanged
        Me.Controls.Add(cmbFilter)

        AddHandler Me.Load, AddressOf FileLoadDialog_Load
    End Sub

    Private Sub LoadFolders(ByVal path As String, ByVal treeView As TreeView)
        treeView.Nodes.Clear()
        Dim rootNode As New TreeNode(IO.Path.GetFileName(path))
        rootNode.Tag = path
        AddSubFolders(path, rootNode)
        treeView.Nodes.Add(rootNode)
        rootNode.Expand()
        treeView.SelectedNode = rootNode
    End Sub

    Private Sub AddSubFolders(ByVal path As String, ByVal parentNode As TreeNode)
        For Each dir As String In IO.Directory.GetDirectories(path)
            Dim dirName As String = IO.Path.GetFileName(dir)
            Dim node As New TreeNode(dirName)
            node.Tag = dir
            AddSubFolders(dir, node)
            parentNode.Nodes.Add(node)
        Next
    End Sub

    Private Sub Tree_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs)
        UpdateFileList()
    End Sub

    Private Sub Tree_NodeMouseClick(ByVal sender As Object, ByVal e As TreeNodeMouseClickEventArgs)
        If e.Button = MouseButtons.Right Then
            tree.SelectedNode = e.Node
            folderContextMenu.Show(tree, e.Location)
        End If
    End Sub

    Private Sub MenuOpenInFileManager_Click(ByVal sender As Object, ByVal e As EventArgs)
        If tree.SelectedNode Is Nothing Then Return
        Dim folderPath As String = CStr(tree.SelectedNode.Tag)
        Try
            Dim fileManagerForm As New FileManager()
            fileManagerForm.StartupParameters("OpenFolder") = folderPath
            fileManagerForm.Show()
        Catch ex As Exception
            MessageBox.Show("Could not open folder in File Manager: " & ex.Message)
        End Try
    End Sub

    Private Sub cmbFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        SelectedFilter = CStr(cmbFilter.SelectedItem)
        UpdateFileList()
    End Sub

    Private Sub UpdateFileList()
        lstFiles.Items.Clear()
        If tree.SelectedNode Is Nothing Then Return
        Dim folderPath As String = CStr(tree.SelectedNode.Tag)
        Dim patterns As String() = {}
        Select Case SelectedFilter
            Case "Text Files (*.txt;*.xml)"
                patterns = New String() {"*.txt", "*.xml"}
            Case "Rich Text Format (*.rtf)"
                patterns = New String() {"*.rtf"}
            Case "Images (*.png;*.jpg;*.jpeg)"
                patterns = New String() {"*.png", "*.jpg", "*.jpeg"}
            Case "Audio Files (*.mp3;*.wav;*.wma)"
                patterns = New String() {"*.mp3", "*.wav", "*.wma"}
            Case Else
                patterns = New String() {"*.*"}
        End Select
        Dim files As New List(Of String)()
        For Each pattern In patterns
            files.AddRange(IO.Directory.GetFiles(folderPath, pattern))
        Next
        For Each file As String In files.Distinct()
            lstFiles.Items.Add(IO.Path.GetFileName(file))
        Next
    End Sub

    Private Sub BtnOK_Click(ByVal sender As Object, ByVal e As EventArgs)
        If tree.SelectedNode Is Nothing OrElse lstFiles.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a file to open.")
            Return
        End If
        Dim folderPath As String = CStr(tree.SelectedNode.Tag)
        SelectedFile = IO.Path.Combine(folderPath, lstFiles.SelectedItem.ToString())
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub FileLoadDialog_Load(ByVal sender As Object, ByVal e As EventArgs)
        cmbFilter.Items.Clear()
        Dim filtersToUse As String()
        If AvailableFilters IsNot Nothing AndAlso AvailableFilters.Count > 0 Then
            filtersToUse = AvailableFilters.ToArray()
        Else
            filtersToUse = New String() {"All Files", "Text Files (*.txt;*.xml)", "Rich Text Format (*.rtf)", "Images (*.png;*.jpg;*.jpeg)", "Audio Files (*.mp3;*.wav;*.wma)"}
        End If
        cmbFilter.Items.AddRange(filtersToUse)
        If Not String.IsNullOrEmpty(DefaultFilter) Then
            For i As Integer = 0 To cmbFilter.Items.Count - 1
                If cmbFilter.Items(i).ToString() = DefaultFilter Then
                    cmbFilter.SelectedIndex = i
                    Exit Sub
                End If
            Next
        End If
        If cmbFilter.Items.Count > 0 AndAlso cmbFilter.SelectedIndex = -1 Then cmbFilter.SelectedIndex = 0
    End Sub

    Private Sub FileLoadDialog_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Icon = System.Drawing.Icon.FromHandle(My.Resources.open.GetHicon())
        Catch ex As Exception
            ' If icon cannot be set, ignore or log as needed
        End Try
    End Sub
End Class