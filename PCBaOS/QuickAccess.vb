Imports System.Runtime.InteropServices
Imports System.Management
Imports System.Threading

Public Class QuickAccess
    Private Sub QuickAccess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Width - 96, Screen.PrimaryScreen.Bounds.Height / 2 - 200)
        TrackBar1.Value = GetApplicationVolume()
        Label1.Text = TrackBar1.Value.ToString & "%"
        Timer1.Start()
    End Sub

    Private Sub Button2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub Button2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Delete the checked item from list"
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        Dim vol As UInteger = CUInt((UShort.MaxValue / 100) * TrackBar1.Value)
        waveOutSetVolume(IntPtr.Zero, CUInt((vol And &HFFFF) Or (vol << 16)))
        Label1.Text = TrackBar1.Value.ToString & "%"
    End Sub
    Private Function GetApplicationVolume() As Integer
        Dim vol As UInteger = 0
        waveOutGetVolume(IntPtr.Zero, vol)
        Return CInt((vol And &HFFFF) / (UShort.MaxValue / 100))
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim v As Integer = GetApplicationVolume()
        If TrackBar1.Value <> v Then
            TrackBar1.Value = v
            Label1.Text = TrackBar1.Value.ToString & "%"
        End If
    End Sub

    <DllImport("winmm.dll")> Private Shared Function waveOutSetVolume(ByVal hwo As IntPtr, ByVal dwVolume As UInteger) As UInteger
    End Function

    <DllImport("winmm.dll")> Private Shared Function waveOutGetVolume(ByVal hwo As IntPtr, ByRef pdwVolume As UInteger) As UInteger
    End Function

    Private Sub Button1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Add new to-do item"
    End Sub

    Private Sub Button3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub Button3_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WorkSpace.ToolStripStatusLabel1.Text = "Check internet connection"
    End Sub

    Private Sub QuickAccess_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Me.Close()
    End Sub
End Class