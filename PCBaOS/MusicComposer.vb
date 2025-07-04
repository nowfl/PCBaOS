Imports System.Threading
Imports System.IO
Imports System.Media

Public Class MusicComposer
    ' Lists to store notes and durations
    Private notes As New List(Of String)
    Private durations As New List(Of Integer)

    ' Octave support
    Private currentOctave As Integer = 4

    ' For saving and loading compositions
    Private currentFilePath As String = ""

    ' To enable multi-threading for playback
    Private playbackThread As Threading.Thread
    Private isPlaying As Boolean = False

    ' Constructor
    Public Sub New()
        InitializeComponent()

        ' Initialize ListBox1 with note options
        ListBox1.Items.AddRange(New String() {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B", "R"})
        ListBox1.SelectedIndex = 0

        ' Set default values
        NumericUpDownOctave.Minimum = 1
        NumericUpDownOctave.Maximum = 20
        NumericUpDownOctave.Value = 5

        ' Initialize octave selector
        NumericUpDownOctave.Minimum = 2
        NumericUpDownOctave.Maximum = 8
        NumericUpDownOctave.Value = 4

        ' Set up the form title
        Me.Text = "Advanced Music Composer"
        UpdateStatusBar("Ready to compose!")
    End Sub

    Private Sub UpdateStatusBar(ByVal message As String)
        ' Update status strip with message
        StatusStrip1.Items.Clear()
        StatusStrip1.Items.Add(message)
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        AddNote()
    End Sub

    Private Sub AddNote()
        ' Add a note to the composition
        If ListBox1.SelectedItem IsNot Nothing AndAlso NumericUpDownOctave.Value > 0 Then
            Dim selectedNote As String = ListBox1.SelectedItem.ToString()

            ' Add octave information to the note (except for rests)
            If selectedNote <> "R" Then
                selectedNote = selectedNote & currentOctave.ToString()
            End If

            notes.Add(selectedNote)
            durations.Add(Convert.ToInt32(NumericUpDownOctave.Value))

            UpdateNoteLists()
            UpdateStatusBar("Note added: " & selectedNote)
        Else
            MessageBox.Show("Please select a note and set a duration greater than 0.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub UpdateNoteLists()
        ' Update the display of notes and durations
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()

        For i As Integer = 0 To notes.Count - 1
            ListBox2.Items.Add(notes(i))
            ListBox3.Items.Add(durations(i) & " units")
        Next

        ' Update total duration
        Dim totalDuration As Integer = 0
        For Each duration In durations
            totalDuration += duration
        Next

        LabelTotalDuration.Text = "Total Duration: " & totalDuration & " units (" & (totalDuration / 10) & " seconds)"
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        RemoveLastNote()
    End Sub

    Private Sub RemoveLastNote()
        ' Remove the last note from the list
        If notes.Count > 0 Then
            notes.RemoveAt(notes.Count - 1)
            durations.RemoveAt(durations.Count - 1)

            UpdateNoteLists()
            UpdateStatusBar("Last note removed")
        Else
            UpdateStatusBar("No notes to remove")
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        PlayComposition()
    End Sub

    Private Sub PlayComposition()
        ' Don't allow multiple playbacks simultaneously
        If isPlaying Then
            MessageBox.Show("Already playing a composition", "Playback in Progress", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Check if there are notes to play
        If notes.Count = 0 Then
            MessageBox.Show("No notes to play", "Empty Composition", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Create a new thread for playback to keep UI responsive
        playbackThread = New Threading.Thread(AddressOf PlayNotes)
        playbackThread.IsBackground = True
        isPlaying = True

        ' Update UI to show playback status
        Button3.Enabled = False
        Button5.Enabled = True
        UpdateStatusBar("Playing composition...")

        ' Start playback
        playbackThread.Start()
    End Sub

    Private Sub PlayNotes()
        Try
            For i As Integer = 0 To notes.Count - 1
                Dim currentIndex As Integer = i
                ' Check if playback was stopped
                If Not isPlaying Then
                    Exit For
                End If

                ' Highlight the current note being played
                Me.Invoke(Sub()
                              ListBox2.SelectedIndex = currentIndex
                              ListBox3.SelectedIndex = currentIndex
                          End Sub)

                Dim note As String = notes(i)
                Dim duration As Integer = durations(i) * 100

                If note = "R" Then ' This is a rest note
                    Thread.Sleep(duration) ' Pause for the duration of the rest
                Else
                    ' Extract the note letter and octave
                    Dim noteLetter As String = note.Substring(0, If(note.Length > 1 AndAlso (note(1) = "#" OrElse note(1) = "b"), 2, 1))
                    Dim noteOctave As Integer = Integer.Parse(note.Substring(noteLetter.Length))

                    ' Play the note
                    Dim frequency As Integer = NoteToFrequency(noteLetter, noteOctave)
                    Console.Beep(frequency, duration)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error during playback: " & ex.Message, "Playback Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Update UI when playback is complete
            Me.Invoke(Sub()
                          Button3.Enabled = True
                          Button5.Enabled = False
                          isPlaying = False
                          UpdateStatusBar("Playback complete")
                      End Sub)
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Stop playback
        isPlaying = False
        UpdateStatusBar("Playback stopped")
        Button3.Enabled = True
        Button5.Enabled = False
    End Sub

    Private Function NoteToFrequency(ByVal noteLetter As String, ByVal octave As Integer) As Integer
        ' Base frequencies for C4 octave
        Dim baseFrequencies As New Dictionary(Of String, Double) From {
            {"C", 261.63},
            {"C#", 277.18}, {"Db", 277.18},
            {"D", 293.66},
            {"D#", 311.13}, {"Eb", 311.13},
            {"E", 329.63},
            {"F", 349.23},
            {"F#", 369.99}, {"Gb", 369.99},
            {"G", 392.0},
            {"G#", 415.3}, {"Ab", 415.3},
            {"A", 440.0},
            {"A#", 466.16}, {"Bb", 466.16},
            {"B", 493.88}
        }

        ' Calculate frequency based on octave shift
        Dim baseFrequency As Double = baseFrequencies(noteLetter)
        Dim octaveShift As Integer = octave - 4 ' Relative to the 4th octave

        ' Formula: frequency = baseFrequency * 2^octaveShift
        Dim frequency As Double = baseFrequency * Math.Pow(2, octaveShift)

        Return CInt(frequency)
    End Function

    Private Sub NumericUpDownOctave_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        currentOctave = CInt(NumericUpDownOctave.Value)
        UpdateStatusBar("Current octave: " & currentOctave)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ' Clear all notes
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        notes.Clear()
        durations.Clear()
        UpdateStatusBar("Composition cleared")
        UpdateNoteLists()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveToolStripMenuItem.Click
        SaveComposition()
    End Sub

    Private Sub SaveComposition()
        ' Show save dialog
        Dim saveDialog As New SaveFileDialog()
        saveDialog.Filter = "Music Composition (*.mcomp)|*.mcomp"
        saveDialog.Title = "Save Composition"

        If saveDialog.ShowDialog() = DialogResult.OK Then
            currentFilePath = saveDialog.FileName

            Try
                Using writer As New StreamWriter(currentFilePath)
                    ' Write version info
                    writer.WriteLine("MusicComposer v1.0")

                    ' Write number of notes
                    writer.WriteLine(notes.Count)

                    ' Write each note and duration
                    For i As Integer = 0 To notes.Count - 1
                        writer.WriteLine(notes(i) & "," & durations(i))
                    Next
                End Using

                UpdateStatusBar("Composition saved to " & currentFilePath)
            Catch ex As Exception
                MessageBox.Show("Error saving file: " & ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click
        LoadComposition()
    End Sub

    Private Sub LoadComposition()
        ' Show open dialog
        Dim openDialog As New OpenFileDialog()
        openDialog.Filter = "Music Composition (*.mcomp)|*.mcomp"
        openDialog.Title = "Open Composition"

        If openDialog.ShowDialog() = DialogResult.OK Then
            currentFilePath = openDialog.FileName

            Try
                ' Clear current composition
                notes.Clear()
                durations.Clear()

                Using reader As New StreamReader(currentFilePath)
                    ' Read version info
                    Dim version As String = reader.ReadLine()

                    ' Read number of notes
                    Dim noteCount As Integer = Integer.Parse(reader.ReadLine())

                    ' Read each note and duration
                    For i As Integer = 0 To noteCount - 1
                        Dim line As String = reader.ReadLine()
                        Dim parts As String() = line.Split(","c)

                        If parts.Length = 2 Then
                            notes.Add(parts(0))
                            durations.Add(Integer.Parse(parts(1)))
                        End If
                    Next
                End Using

                UpdateNoteLists()
                UpdateStatusBar("Composition loaded from " & currentFilePath)
            Catch ex As Exception
                MessageBox.Show("Error loading file: " & ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click
        ' Create new composition
        If notes.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("Do you want to save the current composition first?",
                                                         "New Composition",
                                                         MessageBoxButtons.YesNoCancel,
                                                         MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                SaveComposition()
            ElseIf result = DialogResult.Cancel Then
                Return
            End If
        End If

        notes.Clear()
        durations.Clear()
        currentFilePath = ""
        UpdateNoteLists()
        UpdateStatusBar("New composition started")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click, ExitToolStripMenuItem1.Click
        ' Exit application
        If notes.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("Do you want to save before exiting?",
                                                         "Exit Application",
                                                         MessageBoxButtons.YesNoCancel,
                                                         MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                SaveComposition()
            ElseIf result = DialogResult.Cancel Then
                Return
            End If
        End If

        Me.Close()
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Synchronize selection between note and duration listboxes
        If ListBox2.SelectedIndex >= 0 Then
            ListBox3.SelectedIndex = ListBox2.SelectedIndex
        End If
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Synchronize selection between note and duration listboxes
        If ListBox3.SelectedIndex >= 0 Then
            ListBox2.SelectedIndex = ListBox3.SelectedIndex
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AboutToolStripMenuItem1.Click
        MessageBox.Show("Advanced Music Composer" & vbCrLf &
                       "Version 1.0" & vbCrLf &
                       "A simple application to compose and play music.",
                       "About Music Composer",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information)
    End Sub

    Private Sub MusicComposer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Initial setup when form loads
        UpdateStatusBar("Welcome to Advanced Music Composer!")
    End Sub

    Private Sub MusicComposer_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        ' Clean up resources, especially the playback thread
        If isPlaying Then
            isPlaying = False
            If playbackThread IsNot Nothing AndAlso playbackThread.IsAlive Then
                playbackThread.Join(1000) ' Wait for thread to finish
            End If
        End If
    End Sub



End Class