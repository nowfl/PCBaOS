Public Class FileSaveDialog
    Public Property SelectedFolder As String = ""
    Public Property FileName As String = ""
    Public Property SelectedFormat As String = "txt"
    Public Property AvailableFormats As List(Of String) = Nothing

    Private tree As TreeView
    Private txtFileName As TextBox
    Private btnOK As Button
    Private btnCancel As Button
    Private lblFolder As Label
    Private lblFileName As Label
    Private cmbFormat As ComboBox
    Private folderContextMenu As ContextMenuStrip

    Private KernelPath As String

    Public Sub New(ByVal kernelRoot As String)
        Me.KernelPath = kernelRoot
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Width = 420
        Me.Height = 400
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.Text = "Save"
        Me.TopMost = True

        lblFolder = New Label()
        lblFolder.Text = "Save in folder:"
        lblFolder.Left = 10
        lblFolder.Top = 10
        lblFolder.Width = 120
        Me.Controls.Add(lblFolder)

        tree = New TreeView()
        tree.Left = 10
        tree.Top = 30
        tree.Width = 380
        tree.Height = 220
        tree.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        AddHandler tree.NodeMouseClick, AddressOf Tree_NodeMouseClick
        Me.Controls.Add(tree)
        LoadFolders(KernelPath, tree)

        ' Setup context menu for folders
        folderContextMenu = New ContextMenuStrip()
        Dim menuOpenInFileManager As New ToolStripMenuItem("Open in File Manager", Nothing, AddressOf MenuOpenInFileManager_Click)
        folderContextMenu.Items.Add(menuOpenInFileManager)

        lblFileName = New Label()
        lblFileName.Text = "File name:"
        lblFileName.Left = 10
        lblFileName.Top = 265
        lblFileName.Width = 120
        Me.Controls.Add(lblFileName)

        txtFileName = New TextBox()
        txtFileName.Left = 10
        txtFileName.Top = 285
        txtFileName.Width = 380
        Me.Controls.Add(txtFileName)

        btnOK = New Button()
        btnOK.Text = "OK"
        btnOK.Left = 210
        btnOK.Top = 320
        btnOK.Width = 80
        AddHandler btnOK.Click, AddressOf BtnOK_Click
        Me.Controls.Add(btnOK)

        btnCancel = New Button()
        btnCancel.Text = "Cancel"
        btnCancel.Left = 310
        btnCancel.Top = 320
        btnCancel.Width = 80
        AddHandler btnCancel.Click, Sub()
                                        Me.DialogResult = DialogResult.Cancel
                                        Me.Close()
                                    End Sub
        Me.Controls.Add(btnCancel)

        ' ComboBox for file type/format
        cmbFormat = New ComboBox()
        cmbFormat.Left = 10
        cmbFormat.Top = 320
        cmbFormat.Width = 120
        cmbFormat.DropDownStyle = ComboBoxStyle.DropDownList
        AddHandler cmbFormat.SelectedIndexChanged, AddressOf cmbFormat_SelectedIndexChanged
        Me.Controls.Add(cmbFormat)

        AddHandler Me.Load, AddressOf FileSaveDialog_Load
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

    Private Sub cmbFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        SelectedFormat = CStr(cmbFormat.SelectedItem)
        ' Optionally update filename extension if not set
        If Not txtFileName.Text.EndsWith("." & SelectedFormat) Then
            Dim baseName = IO.Path.GetFileNameWithoutExtension(txtFileName.Text)
            txtFileName.Text = baseName & "." & SelectedFormat
        End If
    End Sub

    Private Sub FileSaveDialog_Load(ByVal sender As Object, ByVal e As EventArgs)
        cmbFormat.Items.Clear()
        Dim formatsToUse As String()
        If AvailableFormats IsNot Nothing AndAlso AvailableFormats.Count > 0 Then
            formatsToUse = AvailableFormats.ToArray()
        Else
            formatsToUse = New String() {"txt", "rtf", "xml", "png", "jpg", "jpeg"}
        End If
        cmbFormat.Items.AddRange(formatsToUse)
        If cmbFormat.Items.Count > 0 Then cmbFormat.SelectedIndex = 0
    End Sub

    Private Sub BtnOK_Click(ByVal sender As Object, ByVal e As EventArgs)
        If tree.SelectedNode Is Nothing Then
            MessageBox.Show("Please select a folder to save in.")
            Return
        End If
        If String.IsNullOrWhiteSpace(txtFileName.Text) OrElse txtFileName.Text.IndexOfAny(IO.Path.GetInvalidFileNameChars()) >= 0 Then
            MessageBox.Show("Please enter a valid file name.")
            Return
        End If
        SelectedFolder = CStr(tree.SelectedNode.Tag)
        FileName = txtFileName.Text.Trim()
        SelectedFormat = CStr(cmbFormat.SelectedItem)
        ' Ensure file extension matches selected format
        If Not FileName.ToLower().EndsWith("." & SelectedFormat) Then
            FileName &= "." & SelectedFormat
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
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

    Private Sub FileSaveDialog_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Icon = System.Drawing.Icon.FromHandle(My.Resources.save.GetHicon())
        Catch ex As Exception
            ' If icon cannot be set, ignore or log as needed
        End Try
    End Sub
End Class