Imports System.Configuration
Imports System.Reflection
Imports System.Drawing
Imports System.ComponentModel

Public Class ApplicationVariables
    ' List of protected setting names
    Private ReadOnly ProtectedSettings As New HashSet(Of String) From {"idkey", "IsAdmin", "GlobalSecurityUse"}

    Private Const MB_TOPMOST As Integer = &H40000

    ' Handles form load event
    Private Sub ApplicationVariables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListBox1.Items.Clear()
        ' Loop through all settings properties
        For Each prop As SettingsProperty In My.Settings.Properties
            ListBox1.Items.Add(prop.Name)
        Next
    End Sub

    ' Handles selection change in the list box
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedItem Is Nothing Then Exit Sub
        ' Get the selected setting name
        Dim selectedSettingName As String = ListBox1.SelectedItem.ToString()
        ' Get the selected setting value
        Dim selectedSettingValue As Object = My.Settings(selectedSettingName)

        If ProtectedSettings.Contains(selectedSettingName) Then
            MsgBox("You can't edit system-protected setting '" & selectedSettingName & "'", MsgBoxStyle.Exclamation Or MB_TOPMOST, "Protected Setting")
            Return
        End If

        ' Build prompt based on type
        Dim prompt As String = "Enter new value for setting '" & selectedSettingName & "'"
        If TypeOf selectedSettingValue Is Boolean Then
            prompt = prompt & " (True or False)"
        ElseIf TypeOf selectedSettingValue Is Color Then
            prompt = prompt & " (e.g. Red, #FF0000, 255,0,0)"
        ElseIf TypeOf selectedSettingValue Is String Then
            prompt = prompt & " (e.g. some text)"
        End If
        prompt = prompt & ":"

        ' Display input box
        Dim result As String = InputBox(prompt, "Edit Setting", selectedSettingValue.ToString(), -1, -1)
        If String.IsNullOrEmpty(result) Then Exit Sub

        Try
            If TypeOf selectedSettingValue Is Boolean Then
                Dim newBooleanValue As Boolean
                If Boolean.TryParse(result, newBooleanValue) Then
                    My.Settings(selectedSettingName) = newBooleanValue
                    My.Settings.Save()
                Else
                    Const MB_TOPMOST As Integer = &H40000
                    Select Case MsgBox("Invalid value for boolean setting '" & selectedSettingName & "'", MsgBoxStyle.Critical Or MB_TOPMOST, "Invalid Boolean")
                        Case MsgBoxResult.Yes
                            ' Do nothing
                    End Select
                End If
            ElseIf TypeOf selectedSettingValue Is Color Then
                Dim converter As New ColorConverter()
                Dim newColorValue As Color = CType(converter.ConvertFromString(result), Color)
                My.Settings(selectedSettingName) = newColorValue
                My.Settings.Save()
            Else
                My.Settings(selectedSettingName) = result
                My.Settings.Save()
            End If
        Catch ex As Exception
            MsgBox("Invalid value for setting '" & selectedSettingName & "': " & ex.Message, MsgBoxStyle.Critical Or MB_TOPMOST, "Invalid Value")
        End Try
    End Sub
End Class