Imports System.Configuration

Public Class Notifications

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Notifications_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Icon = System.Drawing.Icon.FromHandle(My.Resources.arrows.GetHicon())
        Catch ex As Exception
            ' If icon cannot be set, ignore or log as needed
        End Try
    End Sub
End Class