Public Class TaskMgr
    Private imageList As New ImageList()
    Private selectedFormName As String = ""
    Private userIsInteracting As Boolean = False
    Private lastInteractionTime As DateTime = DateTime.Now

    ' Add a reference to System.Diagnostics for memory usage tracking
    ' Add Imports System.Diagnostics at the top of your file

    Private Sub OpenedApps_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set up ListView with multiple columns
        ListView1.View = View.Details
        ListView1.FullRowSelect = True
        ListView1.HideSelection = False
        ListView1.SmallImageList = imageList
        ListView1.Columns.Add("Form Name", 150)
        ListView1.Columns.Add("Window Title", 200)
        ListView1.Columns.Add("Memory Usage", 100)

        ' Set up ImageList
        imageList.ColorDepth = ColorDepth.Depth32Bit
        imageList.ImageSize = New Size(16, 16)

        ' Initial population of ListView
        RefreshOpenForms()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Close selected application
        If ListView1.SelectedItems.Count > 0 Then
            Dim formName As String = ListView1.SelectedItems(0).Text
            Dim formToClose As Form = Application.OpenForms(formName)
            formToClose.Close()
            selectedFormName = "" ' Clear the selection after closing
            RefreshOpenForms()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' Manual refresh
        RefreshOpenForms()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ' Skip refresh if user is currently interacting with the ListView
        ' or if it's been less than 2 seconds since the last interaction
        If userIsInteracting OrElse (DateTime.Now - lastInteractionTime).TotalSeconds < 2 Then
            Return
        End If

        ' Save current selection before refresh
        If ListView1.SelectedItems.Count > 0 Then
            selectedFormName = ListView1.SelectedItems(0).Text
        End If

        RefreshOpenForms()
    End Sub

    Private Sub RefreshOpenForms()
        ' Store current forms information to compare later
        Dim currentForms As New Dictionary(Of String, Form)

        For Each frm As Form In Application.OpenForms
            If frm.Name <> "WorkSpace" And frm.Name <> "ApplicationFolder" And frm.Name <> "Notifications" Then
                currentForms.Add(frm.Name, frm)
            End If
        Next

        ' Check if there's any change in the form list
        Dim listChanged As Boolean = NeedsRefresh(currentForms)

        If listChanged Then
            ' Store the first visible item index to maintain scroll position
            Dim firstVisibleIndex As Integer = 0
            If ListView1.Items.Count > 0 AndAlso ListView1.TopItem IsNot Nothing Then
                firstVisibleIndex = ListView1.TopItem.Index
            End If

            ListView1.BeginUpdate()

            ' Clear but keep selection state
            Dim selectedIndices As New List(Of Integer)
            For i As Integer = 0 To ListView1.SelectedIndices.Count - 1
                selectedIndices.Add(ListView1.SelectedIndices(i))
            Next

            ListView1.Items.Clear()
            imageList.Images.Clear()

            Dim iconIndex As Integer = 0
            Dim selectedIndex As Integer = -1

            For Each kvp As KeyValuePair(Of String, Form) In currentForms
                Dim frm As Form = kvp.Value

                ' Get icon from form
                Dim icon As Icon = GetFormIcon(frm)
                imageList.Images.Add(icon)

                ' Get memory usage for the form's process
                Dim memoryUsage As String = GetFormMemoryUsage(frm)

                ' Add to ListView with icon and multiple columns
                Dim item As New ListViewItem(frm.Name, iconIndex)
                item.SubItems.Add(frm.Text) ' Window title
                item.SubItems.Add(memoryUsage) ' Memory usage
                ListView1.Items.Add(item)

                ' Check if this was the previously selected item
                If frm.Name = selectedFormName Then
                    selectedIndex = iconIndex
                End If

                iconIndex += 1
            Next

            ' Restore selection if possible
            If selectedIndex >= 0 AndAlso selectedIndex < ListView1.Items.Count Then
                ListView1.Items(selectedIndex).Selected = True
                ListView1.Items(selectedIndex).Focused = True
            End If

            ' Restore scroll position if possible
            If ListView1.Items.Count > firstVisibleIndex And firstVisibleIndex >= 0 Then
                ListView1.TopItem = ListView1.Items(firstVisibleIndex)
            End If

            ListView1.EndUpdate()
        End If
    End Sub

    Private Function NeedsRefresh(ByVal currentForms As Dictionary(Of String, Form)) As Boolean
        ' Check if the number of forms has changed
        If ListView1.Items.Count <> currentForms.Count Then
            Return True
        End If

        ' Check if any form names have changed
        For i As Integer = 0 To ListView1.Items.Count - 1
            Dim formName As String = ListView1.Items(i).Text

            ' If a form no longer exists
            If Not currentForms.ContainsKey(formName) Then
                Return True
            End If

            ' If a form's title has changed
            Dim currentTitle As String = currentForms(formName).Text
            If ListView1.Items(i).SubItems(1).Text <> currentTitle Then
                Return True
            End If
        Next

        ' No changes detected
        Return False
    End Function

    Private Function GetFormIcon(ByVal frm As Form) As Icon
        ' Try to get icon from form
        If frm.Icon IsNot Nothing Then
            Return frm.Icon
        Else
            ' Default icon if form doesn't have one
            Return SystemIcons.Application
        End If
    End Function
    Private Function GetFormMemoryUsage(ByVal frm As Form) As String
        Try
            ' Get memory usage before creating the form
            Dim beforeMemory As Long = GC.GetTotalMemory(True)

            ' Create a new instance of the same form type to measure its impact
            Dim tempForm As Form = Activator.CreateInstance(frm.GetType())

            ' Force the form to initialize all its components (but don't show it)
            tempForm.CreateControl()

            ' Get memory after creating form
            Dim afterMemory As Long = GC.GetTotalMemory(True)

            ' Calculate the difference
            Dim formMemory As Long = afterMemory - beforeMemory

            ' Properly dispose the temporary form
            tempForm.Dispose()

            ' Convert to MB for display
            Dim memoryInMB As Double = formMemory / (1024 * 1024)
            Return String.Format("{0:N2} MB", memoryInMB)
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function

    ' For tracking memory of currently displayed form
    Private Function GetCurrentFormMemoryUsage(ByVal frm As Form) As String
        Try
            ' Force garbage collection to get more accurate reading
            GC.Collect()
            GC.WaitForPendingFinalizers()

            ' Get the current process
            Dim currentProcess As Process = Process.GetCurrentProcess()
            Dim totalMemory As Long = currentProcess.PrivateMemorySize64

            ' Calculate an approximate percentage based on controls count relative to total
            Dim formControlsCount As Integer = GetAllControls(frm).Count
            Dim totalControlsCount As Integer = 0

            ' Count all controls in all open forms
            For Each openForm As Form In Application.OpenForms
                totalControlsCount += GetAllControls(openForm).Count
            Next

            ' Estimate form's memory based on its proportion of controls
            Dim formMemoryPercentage As Double = CDbl(formControlsCount) / Math.Max(1, totalControlsCount)
            Dim estimatedFormMemory As Long = CLng(totalMemory * formMemoryPercentage)

            ' Convert to MB for display
            Dim memoryInMB As Double = estimatedFormMemory / (1024 * 1024)
            Return String.Format("{0:N2} MB", memoryInMB)
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function

    ' Helper function to recursively get all controls including nested ones
    Private Function GetAllControls(ByVal container As Control) As List(Of Control)
        Dim allControls As New List(Of Control)
        allControls.Add(container)

        For Each ctrl As Control In container.Controls
            allControls.Add(ctrl)
            If ctrl.Controls.Count > 0 Then
                allControls.AddRange(GetAllControls(ctrl))
            End If
        Next

        Return allControls
    End Function

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        ' Save the currently selected form name
        If ListView1.SelectedItems.Count > 0 Then
            selectedFormName = ListView1.SelectedItems(0).Text
        Else
            selectedFormName = ""
        End If
    End Sub

    ' Track when user interacts with the list
    Private Sub ListView1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListView1.MouseDown
        userIsInteracting = True
        lastInteractionTime = DateTime.Now
    End Sub

    Private Sub ListView1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListView1.MouseUp
        userIsInteracting = False
        lastInteractionTime = DateTime.Now
    End Sub

    Private Sub ListView1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles ListView1.KeyDown
        userIsInteracting = True
        lastInteractionTime = DateTime.Now
    End Sub

    Private Sub ListView1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles ListView1.KeyUp
        userIsInteracting = False
        lastInteractionTime = DateTime.Now
    End Sub
End Class