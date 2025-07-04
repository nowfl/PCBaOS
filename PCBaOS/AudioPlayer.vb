' --- Improved AudioPlayer.vb ---
Public Class AudioPlayer

    ' Playlist and playback state
    Public musicFiles As String() = {}
    Public currentFileIndex As Integer = 0
    Public repeatOn As Boolean = False
    Public isHide As Boolean = False
    ' Remove Private mediaName As String = "" and use a property instead
    Private shuffle As Boolean = False
    Private rand As New Random()

    ' Property to get the current media name
    Private ReadOnly Property MediaName As String
        Get
            If musicFiles Is Nothing OrElse musicFiles.Length = 0 Then
                Return ""
            End If
            Try
                If mediaPlayer.currentMedia IsNot Nothing AndAlso Not String.IsNullOrEmpty(mediaPlayer.currentMedia.name) Then
                    Return mediaPlayer.currentMedia.name
                End If
            Catch
                ' Ignore errors, fallback to file name
            End Try
            ' Fallback: get file name from path
            If currentFileIndex >= 0 AndAlso currentFileIndex < musicFiles.Length Then
                Return System.IO.Path.GetFileNameWithoutExtension(musicFiles(currentFileIndex))
            End If
            Return ""
        End Get
    End Property

    ' Load form
    Private Sub AudioPlayer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isHide = False
        musicFiles = {}
        currentFileIndex = 0
        repeatOn = False
        Label1.Text = "No file loaded"
        Label2.Text = "00:00:00"
        TrackBar1.Value = 0
        Me.Text = "Audio Player"
    End Sub

    ' Play
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If musicFiles.Length > 0 Then
            mediaPlayer.Ctlcontrols.play()
        End If
    End Sub

    ' Stop/Restart
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If musicFiles.Length > 0 Then
            mediaPlayer.Ctlcontrols.currentPosition = 0
            mediaPlayer.Ctlcontrols.play()
        End If
    End Sub

    ' Pause
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If musicFiles.Length > 0 Then
            mediaPlayer.Ctlcontrols.pause()
        End If
    End Sub

    ' Open files
    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Audio Files|*.mp3;*.wav;*.wma"
        openFileDialog.Multiselect = True
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' If multiple files selected, use them; else, load all in folder
            If openFileDialog.FileNames.Length > 1 Then
                musicFiles = openFileDialog.FileNames
            Else
                Dim fileDirectory As String = System.IO.Path.GetDirectoryName(openFileDialog.FileName)
                Dim mp3Files As String() = System.IO.Directory.GetFiles(fileDirectory, "*.mp3")
                Dim wavFiles As String() = System.IO.Directory.GetFiles(fileDirectory, "*.wav")
                Dim wmaFiles As String() = System.IO.Directory.GetFiles(fileDirectory, "*.wma")
                musicFiles = mp3Files.Concat(wavFiles).Concat(wmaFiles).OrderBy(Function(f) f).ToArray()
                ' Set currentFileIndex to the selected file
                currentFileIndex = Array.IndexOf(musicFiles, openFileDialog.FileName)
                If currentFileIndex < 0 Then currentFileIndex = 0
            End If
            If musicFiles.Length > 0 Then
                mediaPlayer.URL = musicFiles(currentFileIndex)
                mediaPlayer.Ctlcontrols.play()
            End If
        End If
    End Sub

    ' Next
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If musicFiles.Length = 0 Then Return
        If shuffle AndAlso musicFiles.Length > 1 Then
            Dim nextIndex As Integer = currentFileIndex
            While nextIndex = currentFileIndex
                nextIndex = rand.Next(0, musicFiles.Length)
            End While
            currentFileIndex = nextIndex
        Else
            currentFileIndex += 1
            If currentFileIndex >= musicFiles.Length Then
                currentFileIndex = 0
            End If
        End If
        PlayCurrentFile()
    End Sub

    ' Previous
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If musicFiles.Length = 0 Then Return
        If shuffle AndAlso musicFiles.Length > 1 Then
            Dim prevIndex As Integer = currentFileIndex
            While prevIndex = currentFileIndex
                prevIndex = rand.Next(0, musicFiles.Length)
            End While
            currentFileIndex = prevIndex
        Else
            currentFileIndex -= 1
            If currentFileIndex < 0 Then
                currentFileIndex = musicFiles.Length - 1
            End If
        End If
        PlayCurrentFile()
    End Sub

    ' Repeat toggle
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        repeatOn = Not repeatOn
        mediaPlayer.settings.setMode("loop", repeatOn)
        Button4.Image = If(repeatOn, My.Resources.back, My.Resources.backno)
    End Sub

    ' Minimize to tray
    Private Sub MinimizeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimizeToolStripMenuItem.Click
        Me.Hide()
        isHide = True
    End Sub

    ' Exit
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    ' Play state change: update UI
    Private Sub mediaPlayer_PlayStateChange(ByVal sender As System.Object, ByVal e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent)
        Try
            If mediaPlayer.playState = WMPLib.WMPPlayState.wmppsPlaying Then
                Dim mediaLength As Double = mediaPlayer.currentMedia.duration
                Dim mediaMinutes As Integer = CInt(Math.Floor(mediaLength / 60))
                Dim mediaSeconds As Integer = CInt(mediaLength Mod 60)
                ' Use MediaName property instead of mediaName variable
                Label1.Text = MediaName & " (" & mediaMinutes.ToString("00") & ":" & mediaSeconds.ToString("00") & ")"
                Me.Text = MediaName & " - Audio Player"
            ElseIf mediaPlayer.playState = WMPLib.WMPPlayState.wmppsStopped Then
                Label2.Text = "00:00:00"
                TrackBar1.Value = 0
            End If
        Catch ex As Exception
            Label1.Text = "Playback error"
        End Try
    End Sub

    ' Trackbar seek
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        If musicFiles.Length = 0 Then Return
        If mediaPlayer.playState = WMPLib.WMPPlayState.wmppsPlaying Or mediaPlayer.playState = WMPLib.WMPPlayState.wmppsPaused Then
            Dim newPosition As Double = CDbl(TrackBar1.Value) / CDbl(TrackBar1.Maximum) * mediaPlayer.currentMedia.duration
            mediaPlayer.Ctlcontrols.currentPosition = newPosition
        End If
    End Sub

    ' Timer: update progress
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If musicFiles.Length = 0 Then
            Label2.Text = "00:00:00"
            TrackBar1.Value = 0
            Return
        End If
        If mediaPlayer.playState = WMPLib.WMPPlayState.wmppsPlaying Or mediaPlayer.playState = WMPLib.WMPPlayState.wmppsPaused Then
            Dim currentPosition As Double = mediaPlayer.Ctlcontrols.currentPosition
            Dim currentMinutes As Integer = CInt(Math.Floor(currentPosition / 60))
            Dim currentSeconds As Integer = CInt(currentPosition Mod 60)
            Dim currentHours As Integer = CInt(Math.Floor(currentMinutes / 60))
            currentMinutes = currentMinutes Mod 60
            Label2.Text = currentHours.ToString("00") & ":" & currentMinutes.ToString("00") & ":" & currentSeconds.ToString("00")
            Dim mediaDuration As Double = mediaPlayer.currentMedia.duration
            If mediaDuration > 0 Then
                TrackBar1.Value = Math.Min(TrackBar1.Maximum, CInt((currentPosition / mediaDuration) * TrackBar1.Maximum))
            End If
            ' Use MediaName property instead of mediaName variable
            Me.Text = MediaName & " - Audio Player"
        End If
    End Sub

    ' Play current file helper
    Private Sub PlayCurrentFile()
        If musicFiles.Length = 0 Then Return
        If currentFileIndex < 0 Or currentFileIndex >= musicFiles.Length Then currentFileIndex = 0
        Try
            mediaPlayer.URL = musicFiles(currentFileIndex)
            mediaPlayer.Ctlcontrols.play()
        Catch ex As Exception
            MessageBox.Show("Cannot play file: " & musicFiles(currentFileIndex), "Playback Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Optional: Drag-and-drop support for files
    Private Sub AudioPlayer_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub AudioPlayer_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles Me.DragDrop
        Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
        If files IsNot Nothing AndAlso files.Length > 0 Then
            musicFiles = files.Where(Function(f) f.ToLower().EndsWith(".mp3") OrElse f.ToLower().EndsWith(".wav") OrElse f.ToLower().EndsWith(".wma")).ToArray()
            currentFileIndex = 0
            PlayCurrentFile()
        End If
    End Sub

    ' Shuffle toggle
    Private Sub ShuffleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShuffleButton.Click
        shuffle = Not shuffle
        ShuffleButton.Image = If(shuffle, My.Resources.shuffle, My.Resources.shuffleno)
    End Sub
End Class