Public Class FileManager

    ' --- FileManager Implementation ---
    Private Const KernelFolderName As String = "Kernel"
    Private KernelPath As String
    Private tree As TreeView
    Private btnCreateFolder As Button
    Private btnDeleteFolder As Button
    Private btnRename As Button
    Private btnMove As Button
    Private fileFolderContextMenu As ContextMenuStrip
    Private menuOpen As ToolStripMenuItem
    Private menuOpenWith As ToolStripMenuItem
    Private menuCreateFolder As ToolStripMenuItem
    Private menuRename As ToolStripMenuItem
    Private menuMove As ToolStripMenuItem
    Private menuDelete As ToolStripMenuItem
    Private lblPath As Label
    Private txtPathEdit As TextBox = Nothing
    Private lastValidPath As String = "/Kernel"
    ' For copy/paste
    Private clipboardPath As String = Nothing
    Private clipboardIsFile As Boolean = False
    ' Store menuCopy/menuPaste for enabling/disabling
    Private menuCopy As ToolStripMenuItem
    Private menuPaste As ToolStripMenuItem

    Private Sub FileManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set up Kernel path in application directory
        KernelPath = IO.Path.Combine(Application.StartupPath, KernelFolderName)
        EnsureKernelStructure()
        InitUI()
        LoadTree()
    End Sub

    ' Ensure Kernel and subfolders exist
    Private Sub EnsureKernelStructure()
        If Not IO.Directory.Exists(KernelPath) Then
            IO.Directory.CreateDirectory(KernelPath)
        End If
        ' Optionally, add default subfolders here if you want
        ' Example: Dim subfolders = {"System", "User", "Temp"}
        ' For Each subf In subfolders
        '     Dim subPath = IO.Path.Combine(KernelPath, subf)
        '     If Not IO.Directory.Exists(subPath) Then IO.Directory.CreateDirectory(subPath)
        ' Next
    End Sub

    ' Initialize UI controls
    Private Sub InitUI()
        ' Remove or update only the controls you add in code, not Me.Controls.Clear()
        ' Stylized path label (Android style)
        lblPath = New Label()
        lblPath.Left = 10
        lblPath.Top = 40 ' Leave space for MenuStrip
        lblPath.Width = Me.ClientSize.Width - 20
        lblPath.Height = 28
        lblPath.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblPath.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblPath.BackColor = Color.FromArgb(245, 245, 245)
        lblPath.ForeColor = Color.FromArgb(60, 60, 60)
        lblPath.BorderStyle = BorderStyle.FixedSingle
        lblPath.TextAlign = ContentAlignment.MiddleLeft
        lblPath.Padding = New Padding(8, 0, 0, 0)
        lblPath.Text = "/Kernel"
        AddHandler lblPath.Click, AddressOf lblPath_Click
        Me.Controls.Add(lblPath)

        tree = New TreeView()
        tree.Left = 10
        tree.Top = lblPath.Bottom + 2
        tree.Width = Me.ClientSize.Width - 20
        tree.Height = Me.ClientSize.Height - 70 - (lblPath.Bottom - 8)
        tree.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
        AddHandler tree.AfterSelect, AddressOf Tree_AfterSelect
        AddHandler tree.NodeMouseClick, AddressOf Tree_NodeMouseClick
        Me.Controls.Add(tree)

        ' Context menu
        fileFolderContextMenu = New ContextMenuStrip()
        menuOpen = New ToolStripMenuItem("Open", Nothing, AddressOf MenuOpen_Click)
        menuOpenWith = New ToolStripMenuItem("Open With")
        Dim menuCopy As New ToolStripMenuItem("Copy", Nothing, AddressOf MenuCopy_Click)
        Dim menuPaste As New ToolStripMenuItem("Paste", Nothing, AddressOf MenuPaste_Click)
        menuCreateFolder = New ToolStripMenuItem("Create Folder", Nothing, AddressOf BtnCreateFolder_Click)
        menuRename = New ToolStripMenuItem("Rename", Nothing, AddressOf BtnRename_Click)
        menuMove = New ToolStripMenuItem("Move", Nothing, AddressOf BtnMove_Click)
        menuDelete = New ToolStripMenuItem("Delete", Nothing, AddressOf BtnDeleteFolder_Click)
        Dim sepOpenWithRename As New ToolStripSeparator()
        fileFolderContextMenu.Items.AddRange(New ToolStripItem() {menuOpen, menuOpenWith, menuCopy, menuPaste, menuCreateFolder, sepOpenWithRename, menuRename, menuMove, menuDelete})
        ' Store for enabling/disabling
        Me.menuCopy = menuCopy
        Me.menuPaste = menuPaste

        btnCreateFolder = New Button()
        btnCreateFolder.Text = "Create Folder"
        btnCreateFolder.Left = 10
        btnCreateFolder.Top = Me.ClientSize.Height - 40
        btnCreateFolder.Width = 100
        btnCreateFolder.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom
        AddHandler btnCreateFolder.Click, AddressOf BtnCreateFolder_Click
        Me.Controls.Add(btnCreateFolder)

        btnDeleteFolder = New Button()
        btnDeleteFolder.Text = "Delete"
        btnDeleteFolder.Left = 120
        btnDeleteFolder.Top = Me.ClientSize.Height - 40
        btnDeleteFolder.Width = 100
        btnDeleteFolder.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom
        AddHandler btnDeleteFolder.Click, AddressOf BtnDeleteFolder_Click
        Me.Controls.Add(btnDeleteFolder)

        btnRename = New Button()
        btnRename.Text = "Rename"
        btnRename.Left = 230
        btnRename.Top = Me.ClientSize.Height - 40
        btnRename.Width = 100
        btnRename.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom
        AddHandler btnRename.Click, AddressOf BtnRename_Click
        Me.Controls.Add(btnRename)

        btnMove = New Button()
        btnMove.Text = "Move"
        btnMove.Left = 340
        btnMove.Top = Me.ClientSize.Height - 40
        btnMove.Width = 100
        btnMove.Anchor = AnchorStyles.Left Or AnchorStyles.Bottom
        AddHandler btnMove.Click, AddressOf BtnMove_Click
        Me.Controls.Add(btnMove)
    End Sub

    ' Load Kernel folder structure into TreeView
    Private Sub LoadTree()
        tree.Nodes.Clear()
        Dim rootNode As New TreeNode(KernelFolderName)
        rootNode.Tag = KernelPath
        LoadSubFolders(KernelPath, rootNode)
        tree.Nodes.Add(rootNode)
        rootNode.Expand()
    End Sub

    Private Sub LoadSubFolders(ByVal path As String, ByVal parentNode As TreeNode)
        ' Add subfolders
        For Each dir As String In IO.Directory.GetDirectories(path)
            Dim dirName As String = IO.Path.GetFileName(dir)
            Dim node As New TreeNode(dirName)
            node.Tag = dir
            LoadSubFolders(dir, node)
            parentNode.Nodes.Add(node)
        Next
        ' Add files
        For Each file As String In IO.Directory.GetFiles(path)
            Dim fileName As String = IO.Path.GetFileName(file)
            Dim fileNode As New TreeNode(fileName)
            fileNode.Tag = file
            fileNode.ForeColor = Color.DarkGreen
            parentNode.Nodes.Add(fileNode)
        Next
    End Sub

    Private Sub Tree_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs)
        UpdatePathLabel()
    End Sub

    Private Sub UpdatePathLabel()
        If tree.SelectedNode Is Nothing OrElse tree.SelectedNode.Tag Is Nothing Then
            lblPath.Text = "/Kernel"
            lastValidPath = "/Kernel"
            Return
        End If
        Dim absPath As String = CStr(tree.SelectedNode.Tag)
        Dim relPath As String = absPath.Replace(KernelPath, "")
        If relPath.StartsWith("\") Or relPath.StartsWith("/") Then relPath = relPath.Substring(1)
        relPath = relPath.Replace("\", "/")
        If relPath = "" Then
            lblPath.Text = "/Kernel"
            lastValidPath = "/Kernel"
        Else
            lblPath.Text = "/Kernel/" & relPath
            lastValidPath = "/Kernel/" & relPath
        End If
    End Sub

    ' Handle double-click on file nodes
    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)
        AddHandler tree.NodeMouseDoubleClick, AddressOf Tree_NodeMouseDoubleClick
    End Sub

    Private Sub Tree_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As TreeNodeMouseClickEventArgs)
        Dim node As TreeNode = e.Node
        If node Is Nothing OrElse node.Tag Is Nothing Then Return
        Dim path As String = CStr(node.Tag)
        If IO.File.Exists(path) Then
            Dim ext As String = IO.Path.GetExtension(path).ToLower()
            If ext = ".png" OrElse ext = ".jpg" OrElse ext = ".jpeg" Then
                Try
                    Dim imgViewForm As New ImgView()
                    imgViewForm.StartupParameters("FilePath") = path
                    imgViewForm.Show()
                Catch ex As Exception
                    MessageBox.Show("Could not open image: " & ex.Message)
                End Try
            ElseIf ext = ".rtf" OrElse ext = ".txt" OrElse ext = ".xml" Then
                Try
                    Dim textpadForm As New Textpad()
                    textpadForm.StartupParameters("FilePath") = path
                    textpadForm.Show()
                Catch ex As Exception
                    MessageBox.Show("Could not open file in Textpad: " & ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub BtnCreateFolder_Click(ByVal sender As Object, ByVal e As EventArgs)
        If tree.SelectedNode Is Nothing Then Return
        Dim parentPath As String = CStr(tree.SelectedNode.Tag)
        Dim dlg As New CreateFolderForm()
        If dlg.ShowDialog(Me) = DialogResult.OK Then
            Dim newFolderName As String = dlg.FolderName.Trim()
            If newFolderName = "" OrElse newFolderName.IndexOfAny(IO.Path.GetInvalidFileNameChars()) >= 0 Then
                MessageBox.Show("Invalid folder name.")
                Return
            End If
            Dim newFolderPath As String = IO.Path.Combine(parentPath, newFolderName)
            If IO.Directory.Exists(newFolderPath) Then
                MessageBox.Show("Folder already exists.")
                Return
            End If
            IO.Directory.CreateDirectory(newFolderPath)
            LoadTree()
        End If
    End Sub

    Private Sub BtnDeleteFolder_Click(ByVal sender As Object, ByVal e As EventArgs)
        If tree.SelectedNode Is Nothing Then Return
        Dim path As String = CStr(tree.SelectedNode.Tag)
        If path = KernelPath Then
            MessageBox.Show("Cannot delete the Kernel root folder.")
            Return
        End If
        If IO.Directory.Exists(path) Then
            If MessageBox.Show("Delete this folder and all its contents?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Try
                    IO.Directory.Delete(path, True)
                    LoadTree()
                Catch ex As Exception
                    MessageBox.Show("Error deleting folder: " & ex.Message)
                End Try
            End If
        ElseIf IO.File.Exists(path) Then
            If MessageBox.Show("Delete this file?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Try
                    IO.File.Delete(path)
                    LoadTree()
                Catch ex As Exception
                    MessageBox.Show("Error deleting file: " & ex.Message)
                End Try
            End If
        End If
    End Sub

    ' Rename selected file or folder
    Private Sub BtnRename_Click(ByVal sender As Object, ByVal e As EventArgs)
        If tree.SelectedNode Is Nothing Then Return
        Dim path As String = CStr(tree.SelectedNode.Tag)
        If path = KernelPath Then
            MessageBox.Show("Cannot rename the Kernel root folder.")
            Return
        End If
        Dim dlg As New RenameForm(IO.Path.GetFileName(path))
        If dlg.ShowDialog(Me) = DialogResult.OK Then
            Dim newName As String = dlg.NewName.Trim()
            If newName = "" OrElse newName.IndexOfAny(IO.Path.GetInvalidFileNameChars()) >= 0 Then
                MessageBox.Show("Invalid name.")
                Return
            End If
            Dim newPath As String = IO.Path.Combine(IO.Path.GetDirectoryName(path), newName)
            If IO.Directory.Exists(path) Then
                If IO.Directory.Exists(newPath) OrElse IO.File.Exists(newPath) Then
                    MessageBox.Show("A file or folder with that name already exists.")
                    Return
                End If
                IO.Directory.Move(path, newPath)
            ElseIf IO.File.Exists(path) Then
                If IO.File.Exists(newPath) OrElse IO.Directory.Exists(newPath) Then
                    MessageBox.Show("A file or folder with that name already exists.")
                    Return
                End If
                IO.File.Move(path, newPath)
            End If
            LoadTree()
        End If
    End Sub

    ' Move selected file or folder
    Private Sub BtnMove_Click(ByVal sender As Object, ByVal e As EventArgs)
        If tree.SelectedNode Is Nothing Then Return
        Dim sourcePath As String = CStr(tree.SelectedNode.Tag)
        If sourcePath = KernelPath Then
            MessageBox.Show("Cannot move the Kernel root folder.")
            Return
        End If
        ' Select destination folder
        Dim destPath As String = SelectFolderDialog(KernelPath, "Select destination folder:")
        If String.IsNullOrEmpty(destPath) OrElse destPath = sourcePath Then Return
        If Not IO.Directory.Exists(destPath) Then
            MessageBox.Show("Destination folder does not exist.")
            Return
        End If
        Dim newPath As String = IO.Path.Combine(destPath, IO.Path.GetFileName(sourcePath))
        If IO.Directory.Exists(sourcePath) Then
            If IO.Directory.Exists(newPath) OrElse IO.File.Exists(newPath) Then
                MessageBox.Show("A file or folder with that name already exists in the destination.")
                Return
            End If
            IO.Directory.Move(sourcePath, newPath)
        ElseIf IO.File.Exists(sourcePath) Then
            If IO.File.Exists(newPath) OrElse IO.Directory.Exists(newPath) Then
                MessageBox.Show("A file or folder with that name already exists in the destination.")
                Return
            End If
            Try
                IO.File.Move(sourcePath, newPath)
            Catch ex As IO.IOException
                MessageBox.Show("Cannot move file. It may be open in another program or in use.\n\n" & ex.Message, "Move Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
        End If
        LoadTree()
    End Sub

    ' Show context menu on right-click
    Private Sub Tree_NodeMouseClick(ByVal sender As Object, ByVal e As TreeNodeMouseClickEventArgs)
        If e.Button = MouseButtons.Right Then
            tree.SelectedNode = e.Node
            UpdatePathLabel()
            Dim path As String = CStr(e.Node.Tag)
            Dim isRoot As Boolean = (path = KernelPath)
            Dim isDir As Boolean = IO.Directory.Exists(path)
            Dim isFile As Boolean = IO.File.Exists(path)

            menuOpen.Visible = True
            menuOpenWith.Visible = True
            menuRename.Visible = True
            menuMove.Visible = True
            menuDelete.Visible = True

            menuOpen.Enabled = True
            menuOpenWith.Enabled = True
            menuRename.Enabled = Not isRoot
            menuMove.Enabled = Not isRoot
            menuDelete.Enabled = Not isRoot
            menuCopy.Enabled = Not isRoot
            menuPaste.Enabled = isDir AndAlso (clipboardPath IsNot Nothing)

            ' Only show Create Folder for folders (not files or root)
            If isDir AndAlso Not isRoot Then
                menuCreateFolder.Visible = True
                menuCreateFolder.Enabled = True
            Else
                menuCreateFolder.Visible = False
            End If

            ' Open/With logic
            If isDir Then
                menuOpen.Text = "Open"
                menuOpenWith.Visible = False
            ElseIf isFile Then
                menuOpen.Text = "Open"
                menuOpenWith.Visible = True
                ' Build Open With submenu
                menuOpenWith.DropDownItems.Clear()
                Dim ext As String = IO.Path.GetExtension(path).ToLower()
                If ext = ".png" OrElse ext = ".jpg" OrElse ext = ".jpeg" Then
                    menuOpenWith.DropDownItems.Add(New ToolStripMenuItem("ImgView", Nothing, Sub() OpenWithImgView(path)))
                    menuOpenWith.DropDownItems.Add(New ToolStripMenuItem("Paint99", Nothing, Sub() OpenWithPaint99(path)))
                ElseIf ext = ".txt" OrElse ext = ".rtf" OrElse ext = ".xml" Then
                    menuOpenWith.DropDownItems.Add(New ToolStripMenuItem("Textpad", Nothing, Sub() OpenWithTextpad(path)))
                End If
                ' Add more file type handlers here as needed
                If menuOpenWith.DropDownItems.Count = 0 Then
                    menuOpenWith.DropDownItems.Add("No available apps").Enabled = False
                End If
            Else
                menuOpen.Visible = False
                menuOpenWith.Visible = False
            End If

            fileFolderContextMenu.Show(tree, e.Location)
        End If
    End Sub

    ' Open logic for folders and files
    Private Sub MenuOpen_Click(ByVal sender As Object, ByVal e As EventArgs)
        If tree.SelectedNode Is Nothing Then Return
        Dim path As String = CStr(tree.SelectedNode.Tag)
        If IO.Directory.Exists(path) Then
            ' Expand/collapse folder
            If tree.SelectedNode.IsExpanded Then
                tree.SelectedNode.Collapse()
            Else
                tree.SelectedNode.Expand()
            End If
        ElseIf IO.File.Exists(path) Then
            Dim ext As String = IO.Path.GetExtension(path).ToLower()
            If ext = ".png" OrElse ext = ".jpg" OrElse ext = ".jpeg" Then
                OpenWithImgView(path)
            End If
            ' Add more file type handlers here as needed
        End If
    End Sub

    ' Open With handlers
    Private Sub OpenWithImgView(ByVal filePath As String)
        Try
            Dim imgViewForm As New ImgView()
            imgViewForm.StartupParameters("FilePath") = filePath
            imgViewForm.Show()
        Catch ex As Exception
            MessageBox.Show("Could not open image in ImgView: " & ex.Message)
        End Try
    End Sub

    Private Sub OpenWithPaint99(ByVal filePath As String)
        Try
            Dim paintForm As New Paint99()
            paintForm.StartupParameters("FilePath") = filePath
            paintForm.Show()
        Catch ex As Exception
            MessageBox.Show("Could not open image in Paint99: " & ex.Message)
        End Try
    End Sub

    Private Sub OpenWithTextpad(ByVal filePath As String)
        Try
            Dim textpadForm As New Textpad()
            textpadForm.StartupParameters("FilePath") = filePath
            textpadForm.Show()
        Catch ex As Exception
            MessageBox.Show("Could not open file in Textpad: " & ex.Message)
        End Try
    End Sub

    ' Dialog for entering new folder name
    Private Class CreateFolderForm
        Inherits Form
        Public Property FolderName As String
        Private txt As TextBox
        Private btnOK As Button
        Private btnCancel As Button
        Public Sub New()
            Me.Text = "Create Folder"
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Width = 250
            Me.Height = 120
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.ShowInTaskbar = False
            Me.TopMost = True

            txt = New TextBox()
            txt.Left = 20
            txt.Top = 10
            txt.Width = 200
            Me.Controls.Add(txt)

            btnOK = New Button()
            btnOK.Text = "OK"
            btnOK.Left = 40
            btnOK.Top = 45
            btnOK.Width = 60
            AddHandler btnOK.Click, Sub()
                                        Me.FolderName = txt.Text.Trim()
                                        Me.DialogResult = DialogResult.OK
                                        Me.Close()
                                    End Sub
            Me.Controls.Add(btnOK)

            btnCancel = New Button()
            btnCancel.Text = "Cancel"
            btnCancel.Left = 120
            btnCancel.Top = 45
            btnCancel.Width = 60
            AddHandler btnCancel.Click, Sub()
                                            Me.DialogResult = DialogResult.Cancel
                                            Me.Close()
                                        End Sub
            Me.Controls.Add(btnCancel)
        End Sub
    End Class

    ' Dialog for renaming
    Private Class RenameForm
        Inherits Form
        Public Property NewName As String
        Private txt As TextBox
        Private btnOK As Button
        Private btnCancel As Button
        Public Sub New(ByVal currentName As String)
            Me.Text = "Rename"
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Width = 250
            Me.Height = 120
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.ShowInTaskbar = False
            Me.TopMost = True

            txt = New TextBox()
            txt.Left = 20
            txt.Top = 10
            txt.Width = 200
            txt.Text = currentName
            Me.Controls.Add(txt)

            btnOK = New Button()
            btnOK.Text = "OK"
            btnOK.Left = 40
            btnOK.Top = 45
            btnOK.Width = 60
            AddHandler btnOK.Click, Sub()
                                        Me.NewName = txt.Text.Trim()
                                        Me.DialogResult = DialogResult.OK
                                        Me.Close()
                                    End Sub
            Me.Controls.Add(btnOK)

            btnCancel = New Button()
            btnCancel.Text = "Cancel"
            btnCancel.Left = 120
            btnCancel.Top = 45
            btnCancel.Width = 60
            AddHandler btnCancel.Click, Sub()
                                            Me.DialogResult = DialogResult.Cancel
                                            Me.Close()
                                        End Sub
            Me.Controls.Add(btnCancel)
        End Sub
    End Class

    ' Dialog for selecting a folder within Kernel
    Private Function SelectFolderDialog(ByVal rootPath As String, ByVal prompt As String) As String
        Dim dlg As New FolderSelectForm(rootPath, prompt)
        If dlg.ShowDialog(Me) = DialogResult.OK Then
            Return dlg.SelectedPath
        End If
        Return Nothing
    End Function

    Private Class FolderSelectForm
        Inherits Form
        Public Property SelectedPath As String
        Private tree As TreeView
        Private btnOK As Button
        Private btnCancel As Button
        Public Sub New(ByVal rootPath As String, ByVal prompt As String)
            Me.Text = prompt
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Width = 350
            Me.Height = 350
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.ShowInTaskbar = False
            Me.TopMost = True

            tree = New TreeView()
            tree.Left = 10
            tree.Top = 10
            tree.Width = 310
            tree.Height = 240
            tree.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
            Me.Controls.Add(tree)
            LoadFolders(rootPath, tree)

            btnOK = New Button()
            btnOK.Text = "OK"
            btnOK.Left = 60
            btnOK.Top = 270
            btnOK.Width = 80
            AddHandler btnOK.Click, Sub()
                                        If tree.SelectedNode IsNot Nothing Then
                                            Me.SelectedPath = CStr(tree.SelectedNode.Tag)
                                            Me.DialogResult = DialogResult.OK
                                            Me.Close()
                                        End If
                                    End Sub
            Me.Controls.Add(btnOK)

            btnCancel = New Button()
            btnCancel.Text = "Cancel"
            btnCancel.Left = 180
            btnCancel.Top = 270
            btnCancel.Width = 80
            AddHandler btnCancel.Click, Sub()
                                            Me.DialogResult = DialogResult.Cancel
                                            Me.Close()
                                        End Sub
            Me.Controls.Add(btnCancel)
        End Sub
        Private Sub LoadFolders(ByVal path As String, ByVal treeView As TreeView)
            treeView.Nodes.Clear()
            Dim rootNode As New TreeNode(IO.Path.GetFileName(path))
            rootNode.Tag = path
            AddSubFolders(path, rootNode)
            treeView.Nodes.Add(rootNode)
            rootNode.Expand()
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
    End Class

    Private Sub lblPath_Click(ByVal sender As Object, ByVal e As EventArgs)
        If txtPathEdit IsNot Nothing OrElse lblPath Is Nothing Then Return ' Already editing or label missing
        txtPathEdit = New TextBox()
        txtPathEdit.Left = lblPath.Left
        txtPathEdit.Top = lblPath.Top
        txtPathEdit.Width = lblPath.Width
        txtPathEdit.Height = lblPath.Height
        txtPathEdit.Font = lblPath.Font
        txtPathEdit.Text = lblPath.Text
        txtPathEdit.BorderStyle = BorderStyle.FixedSingle
        txtPathEdit.BackColor = Color.White
        txtPathEdit.ForeColor = Color.Black
        txtPathEdit.Padding = lblPath.Padding
        txtPathEdit.Anchor = lblPath.Anchor
        Me.Controls.Add(txtPathEdit)
        txtPathEdit.BringToFront()
        txtPathEdit.Focus()
        AddHandler txtPathEdit.KeyDown, AddressOf txtPathEdit_KeyDown
        AddHandler txtPathEdit.LostFocus, AddressOf txtPathEdit_LostFocus
        lblPath.Visible = False
    End Sub

    Private Sub txtPathEdit_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            TryNavigateToPath(txtPathEdit.Text)
        ElseIf e.KeyCode = Keys.Escape Then
            CancelPathEdit()
        End If
    End Sub

    Private Sub txtPathEdit_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        TryNavigateToPath(txtPathEdit.Text)
    End Sub

    Private Sub TryNavigateToPath(ByVal inputPath As String)
        Dim relPath As String = inputPath.Trim().Replace("\", "/")
        If relPath.StartsWith("/Kernel") Then
            relPath = relPath.Substring("/Kernel".Length)
        End If
        relPath = relPath.TrimStart("/"c)
        Dim absPath As String = IO.Path.Combine(KernelPath, relPath.Replace("/", IO.Path.DirectorySeparatorChar))
        If IO.Directory.Exists(absPath) Or IO.File.Exists(absPath) Then
            ' Find and select the node
            Dim foundNode As TreeNode = FindNodeByPath(tree.Nodes(0), absPath)
            If foundNode IsNot Nothing Then
                tree.SelectedNode = foundNode
                foundNode.EnsureVisible()
                lastValidPath = inputPath
                EndPathEdit()
                Return
            End If
        End If
        ' If not found, revert
        EndPathEdit()
    End Sub

    Private Sub CancelPathEdit()
        EndPathEdit()
    End Sub

    Private Sub EndPathEdit()
        If txtPathEdit IsNot Nothing Then
            Try
                If Me.Controls.Contains(txtPathEdit) Then Me.Controls.Remove(txtPathEdit)
                Dim tempTxt As TextBox = txtPathEdit
                txtPathEdit = Nothing ' Set to Nothing before Dispose to avoid reentrancy
                If tempTxt IsNot Nothing Then
                    Try
                        tempTxt.Dispose()
                    Catch
                        ' Ignore dispose errors
                    End Try
                End If
            Catch
                ' Ignore errors
            End Try
            If lblPath IsNot Nothing Then
                lblPath.Visible = True
                UpdatePathLabel()
            End If
        End If
    End Sub

    Private Function FindNodeByPath(ByVal node As TreeNode, ByVal absPath As String) As TreeNode
        If node Is Nothing Then Return Nothing
        If node.Tag IsNot Nothing AndAlso String.Equals(CStr(node.Tag), absPath, StringComparison.OrdinalIgnoreCase) Then
            Return node
        End If
        For Each child As TreeNode In node.Nodes
            Dim found As TreeNode = FindNodeByPath(child, absPath)
            If found IsNot Nothing Then Return found
        Next
        Return Nothing
    End Function

    Private Sub CloseToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub CloseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub OpenInExplorerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenInExplorerToolStripMenuItem.Click
        Dim pathToOpen As String = KernelPath
        If tree.SelectedNode IsNot Nothing AndAlso tree.SelectedNode.Tag IsNot Nothing Then
            Dim selectedPath As String = CStr(tree.SelectedNode.Tag)
            If IO.Directory.Exists(selectedPath) Then
                pathToOpen = selectedPath
            ElseIf IO.File.Exists(selectedPath) Then
                pathToOpen = IO.Path.GetDirectoryName(selectedPath)
            End If
        End If
        Try
            Process.Start("explorer.exe", """" & pathToOpen & """")
        Catch ex As Exception
            MessageBox.Show("Could not open folder in Explorer: " & ex.Message)
        End Try
    End Sub

    ' Copy selected file/folder
    Private Sub MenuCopy_Click(ByVal sender As Object, ByVal e As EventArgs)
        If tree.SelectedNode Is Nothing Then Return
        Dim path As String = CStr(tree.SelectedNode.Tag)
        If path = KernelPath Then Return
        clipboardPath = path
        clipboardIsFile = IO.File.Exists(path)
    End Sub

    ' Paste into selected folder
    Private Sub MenuPaste_Click(ByVal sender As Object, ByVal e As EventArgs)
        If tree.SelectedNode Is Nothing OrElse clipboardPath Is Nothing Then Return
        Dim destDir As String = CStr(tree.SelectedNode.Tag)
        If Not IO.Directory.Exists(destDir) Then Return
        Try
            If clipboardIsFile Then
                Dim fileName As String = IO.Path.GetFileName(clipboardPath)
                Dim destPath As String = IO.Path.Combine(destDir, fileName)
                Dim baseName As String = IO.Path.GetFileNameWithoutExtension(fileName)
                Dim ext As String = IO.Path.GetExtension(fileName)
                Dim i As Integer = 1
                While IO.File.Exists(destPath)
                    destPath = IO.Path.Combine(destDir, baseName & "_copy" & i & ext)
                    i += 1
                End While
                IO.File.Copy(clipboardPath, destPath)
            ElseIf IO.Directory.Exists(clipboardPath) Then
                Dim folderName As String = IO.Path.GetFileName(clipboardPath)
                Dim destPath As String = IO.Path.Combine(destDir, folderName)
                Dim i As Integer = 1
                While IO.Directory.Exists(destPath)
                    destPath = IO.Path.Combine(destDir, folderName & "_copy" & i)
                    i += 1
                End While
                CopyDirectoryRecursive(clipboardPath, destPath)
            End If
            LoadTree()
        Catch ex As Exception
            MessageBox.Show("Paste failed: " & ex.Message)
        End Try
    End Sub

    ' Recursive directory copy
    Private Sub CopyDirectoryRecursive(ByVal sourceDir As String, ByVal destDir As String)
        IO.Directory.CreateDirectory(destDir)
        For Each file As String In IO.Directory.GetFiles(sourceDir)
            Dim destFile As String = IO.Path.Combine(destDir, IO.Path.GetFileName(file))
            IO.File.Copy(file, destFile)
        Next
        For Each dir As String In IO.Directory.GetDirectories(sourceDir)
            Dim destSubDir As String = IO.Path.Combine(destDir, IO.Path.GetFileName(dir))
            CopyDirectoryRecursive(dir, destSubDir)
        Next
    End Sub
End Class