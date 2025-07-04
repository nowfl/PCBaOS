Public Class ShutdownLog

    Private Sub ShutdownLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.ShutdownLog IsNot Nothing Then
            For Each item As String In My.Settings.ShutdownLog
                ListBox1.Items.Add(item)
            Next
        End If
        Try
            Me.Icon = System.Drawing.Icon.FromHandle(My.Resources.shutdown.GetHicon())
        Catch ex As Exception
            ' If icon cannot be set, ignore or log as needed
        End Try
    End Sub
End Class