Imports System.IO

Public Class CustomApplications

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If String.IsNullOrWhiteSpace(selectedfile) Then
                MessageBox.Show("Please select a valid file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                MessageBox.Show("Please enter a valid type name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim assembly As System.Reflection.Assembly = Nothing
            Try
                ' Check .NET version compatibility
                Dim fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(selectedfile)
                Dim clrVersion As String = fileVersionInfo.ProductVersion
                ' Optionally, parse the version string to check for minimum required version
                ' For example, require at least .NET 4.0
                Dim requiredMajor As Integer = 4
                Dim actualMajor As Integer = 0
                If clrVersion IsNot Nothing AndAlso clrVersion.Contains(".") Then
                    Dim parts = clrVersion.Split(".")
                    Integer.TryParse(parts(0), actualMajor)
                End If
                If actualMajor < requiredMajor Then
                    MessageBox.Show("This DLL was built for .NET version " & clrVersion & ". PCBaOS requires .NET 4.0 or higher.", "Incompatible .NET Version", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                assembly = System.Reflection.Assembly.LoadFile(selectedfile)
            Catch ex As System.IO.FileNotFoundException
                MessageBox.Show("File not found: " & selectedfile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Catch ex As System.BadImageFormatException
                MessageBox.Show("Invalid assembly file: " & selectedfile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Catch ex As Exception
                MessageBox.Show("Error loading assembly: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            ' Check for required API compatibility (example: must reference System.Windows.Forms)
            Dim referencedAssemblies = assembly.GetReferencedAssemblies()
            Dim hasWinForms As Boolean = referencedAssemblies.Any(Function(a) a.Name = "System.Windows.Forms")
            If Not hasWinForms Then
                MessageBox.Show("This DLL does not reference System.Windows.Forms and cannot be loaded as a form application.", "API Incompatibility", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Check for suspicious file extensions
            Dim allowedExtensions As String() = {".dll"}
            If Not allowedExtensions.Contains(Path.GetExtension(selectedfile).ToLower()) Then
                MessageBox.Show("Only DLL files are allowed.", "Invalid File Type", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Check file size (e.g., block files larger than 20MB)
            Dim fileInfo As New FileInfo(selectedfile)
            If fileInfo.Length > 20 * 1024 * 1024 Then
                MessageBox.Show("DLL file is too large (max 20MB).", "File Too Large", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Check for duplicate app name
            If ListBox1.Items.Contains(TextBox1.Text) Then
                MessageBox.Show("An application with this name is already installed.", "Duplicate App Name", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Check for exported forms
            Dim exportedTypes As Type() = {}
            Try
                exportedTypes = assembly.GetExportedTypes()
            Catch ex As Exception
                MessageBox.Show("Error reading types from DLL: " & ex.Message, "Reflection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
            Dim hasForm As Boolean = exportedTypes.Any(Function(t) GetType(Form).IsAssignableFrom(t))
            If Not hasForm Then
                MessageBox.Show("This DLL does not contain any exported Form types.", "No Forms Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim type As Type = Nothing
            Try
                type = assembly.GetType(TextBox1.Text, True, True)
            Catch ex As Exception
                MessageBox.Show("Could not find the specified type: " & TextBox1.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            If Not GetType(Form).IsAssignableFrom(type) Then
                MessageBox.Show("The specified type is not a Form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim newForm As Form = Nothing
            Try
                newForm = CType(Activator.CreateInstance(type), Form)
            Catch ex As Exception
                MessageBox.Show("Could not create form instance: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            Dim appDirectoryPath As String = Application.StartupPath
            Dim fileName As String = Path.GetFileName(selectedfile)
            Dim destinationFilePath As String = Path.Combine(appDirectoryPath, fileName)

            Dim rnd As New Random()
            Dim nextColor As Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256))
            Dim colorHtml As String = ColorTranslator.ToHtml(nextColor)

            Try
                File.Copy(selectedfile, destinationFilePath, True)
            Catch ex As Exception
                MessageBox.Show("Error copying file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            ListBox1.Items.Add(newForm.Text)
            ListBox2.Items.Add(destinationFilePath)
            ListBox3.Items.Add(type.FullName)

            If destinationIconPath IsNot Nothing Then
                ListBox4.Items.Add(destinationIconPath)
            Else
                ListBox4.Items.Add("no icons")
            End If

            ListBox5.Items.Add(colorHtml)

            SaveListBoxes()

            MessageBox.Show("Application successfully installed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Dim selectedfile As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim openFileDialog As New OpenFileDialog()
        Dim result As DialogResult = openFileDialog.ShowDialog()
        openFileDialog.Filter = "DLL Files|*.dll"
        If result = DialogResult.OK Then
            selectedfile = openFileDialog.FileName
            Button2.Enabled = True
            Button3.Enabled = True

        End If
    End Sub

    Private Sub SaveListBoxes()
        Dim appName As New System.Collections.Specialized.StringCollection()
        Dim appDir As New System.Collections.Specialized.StringCollection()
        Dim appSet As New System.Collections.Specialized.StringCollection()
        Dim appIcon As New System.Collections.Specialized.StringCollection()
        Dim appColor As New System.Collections.Specialized.StringCollection()

        For Each item As Object In ListBox1.Items
            appName.Add(item.ToString())
        Next

        For Each item As Object In ListBox2.Items
            appDir.Add(item.ToString())
        Next

        For Each item As Object In ListBox3.Items
            appSet.Add(item.ToString())
        Next

        For Each item As Object In ListBox4.Items
            appIcon.Add(item.ToString())
        Next

        For Each item As Object In ListBox5.Items
            appColor.Add(item.ToString())
        Next

        My.Settings.InstalledApplicationNames = appName
        My.Settings.InstalledApplications = appDir
        My.Settings.InstalledApplicationClassSettings = appSet
        My.Settings.InstalledApplicationIconDir = appIcon
        My.Settings.InstalledApplicationColor = appColor
        My.Settings.Save()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim listBoxItems As New System.Collections.Specialized.StringCollection()

        For Each item As Object In ListBox1.Items
            listBoxItems.Add(item.ToString())
        Next

        My.Settings.InstalledApplications = listBoxItems
        My.Settings.Save()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Dim selectedicon As String
    Dim destinationIconPath As String
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim openFileDialog As New OpenFileDialog()
        Dim result As DialogResult = openFileDialog.ShowDialog()
        openFileDialog.Filter = "PNG Files|*.png"
        If result = DialogResult.OK Then
            selectedicon = openFileDialog.FileName
            Button2.Enabled = True
            Dim appDirectoryPath As String = Application.StartupPath

            Dim fileName As String = Path.GetFileName(selectedicon)
            destinationIconPath = Path.Combine(appDirectoryPath, fileName)
            File.Copy(selectedicon, destinationIconPath, True)
        End If
    End Sub

    Private Sub CustomApplications_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If My.Settings.InstalledApplicationNames IsNot Nothing Then
            For Each item As String In My.Settings.InstalledApplicationNames
                ListBox1.Items.Add(item)
            Next
        End If

        If My.Settings.InstalledApplications IsNot Nothing Then
            For Each item As String In My.Settings.InstalledApplications
                ListBox2.Items.Add(item)
            Next
        End If

        If My.Settings.InstalledApplicationClassSettings IsNot Nothing Then
            For Each item As String In My.Settings.InstalledApplicationClassSettings
                ListBox3.Items.Add(item)
            Next
        End If

        If My.Settings.InstalledApplicationIconDir IsNot Nothing Then
            For Each item As String In My.Settings.InstalledApplicationIconDir
                ListBox4.Items.Add(item)
            Next
        End If

        If My.Settings.InstalledApplicationColor IsNot Nothing Then
            For Each item As String In My.Settings.InstalledApplicationColor
                ListBox5.Items.Add(item)
            Next
        End If


    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim selectedIndex As Integer = ListBox1.SelectedIndex

        ' Check if an item is actually selected
        If selectedIndex <> -1 Then
            ' Confirmation message box
            If MessageBox.Show("Do you really want to uninstall this app?", "Confirm Uninstall", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Try
                    ' Remove the corresponding item from other listboxes
                    ListBox1.Items.RemoveAt(selectedIndex)
                    ListBox2.Items.RemoveAt(selectedIndex)
                    ListBox3.Items.RemoveAt(selectedIndex)
                    ListBox4.Items.RemoveAt(selectedIndex)

                    ' Delete the files if they exist
                    If File.Exists(My.Settings.InstalledApplications(selectedIndex)) Then
                        File.Delete(My.Settings.InstalledApplications(selectedIndex))
                    End If

                    If File.Exists(My.Settings.InstalledApplicationIconDir(selectedIndex)) Then
                        File.Delete(My.Settings.InstalledApplicationIconDir(selectedIndex))
                    End If

                    ' Remove the corresponding item from application settings
                    My.Settings.InstalledApplications.RemoveAt(selectedIndex)
                    My.Settings.InstalledApplicationNames.RemoveAt(selectedIndex)
                    My.Settings.InstalledApplicationClassSettings.RemoveAt(selectedIndex)
                    My.Settings.InstalledApplicationIconDir.RemoveAt(selectedIndex)
                    My.Settings.Save()

                Catch ex As Exception
                    ' Error handling
                    MessageBox.Show("An error occurred: " & ex.Message)
                End Try
            End If
        End If
    End Sub


    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim assemblyFile As String = selectedfile
        Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(assemblyFile)

        ' Get the exported types from the assembly
        Dim exportedTypes As Type() = assembly.GetExportedTypes()

        ' Convert the exported types array to a string
        Dim typesString As String = String.Join(Environment.NewLine, exportedTypes.Select(Function(t) t.FullName))

        ' Display the string in the TextBox
        TextBox2.Text = typesString
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MsgBox("Welcome to PCBaOS Application Loader!" & vbCrLf & _
               "To integrate a Visual Basic class library into your PCBaOS environment:" & vbCrLf & _
               "1. Begin by uploading your DLL file, crafted with Visual Basic and containing at least one form." & vbCrLf & _
               "2. Click 'Check Lib' to enumerate the libraries housed within your DLL." & vbCrLf & _
               "3. Select your desired library, input its name in the textbox, and initiate installation with 'Install'." & vbCrLf & _
               "4. Upon successful installation, the application will manifest in the listboxes." & vbCrLf & _
               "5. You're all set! The application is now operational within your PCBaOS project." & vbCrLf & _
               "Remember:" & vbCrLf & _
               "- Verify DLL compatibility with PCBaOS's framework." & vbCrLf & _
               "- Ascertain that all necessary dependencies are present within PCBaOS." & vbCrLf & _
               "- To uninstall applications, simply select them from the listbox.", MsgBoxStyle.OkOnly, "Help")
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            ' Clear existing ListBox items
            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            ListBox3.Items.Clear()
            ListBox4.Items.Clear()
            ListBox5.Items.Clear()

            ' Reload items from saved settings
            If My.Settings.InstalledApplicationNames IsNot Nothing Then
                For Each item As String In My.Settings.InstalledApplicationNames
                    ListBox1.Items.Add(item)
                Next
            End If

            If My.Settings.InstalledApplications IsNot Nothing Then
                For Each item As String In My.Settings.InstalledApplications
                    ListBox2.Items.Add(item)
                Next
            End If

            If My.Settings.InstalledApplicationClassSettings IsNot Nothing Then
                For Each item As String In My.Settings.InstalledApplicationClassSettings
                    ListBox3.Items.Add(item)
                Next
            End If

            If My.Settings.InstalledApplicationIconDir IsNot Nothing Then
                For Each item As String In My.Settings.InstalledApplicationIconDir
                    ListBox4.Items.Add(item)
                Next
            End If

            If My.Settings.InstalledApplicationColor IsNot Nothing Then
                For Each item As String In My.Settings.InstalledApplicationColor
                    ListBox5.Items.Add(item)
                Next
            End If

            ' Optional: Show confirmation message
            MessageBox.Show("Lists have been refreshed from saved settings.", "Refresh Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            ' Error handling
            MessageBox.Show("An error occurred while refreshing: " & ex.Message, "Refresh Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class