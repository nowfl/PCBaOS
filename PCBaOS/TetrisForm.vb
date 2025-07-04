Imports System.Text

Public Class TetrisForm
    Private word As String
    Private guessedLetters As New List(Of Char)
    Private remainingAttempts As Integer = 6

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        StartNewGame()
    End Sub

    Private Sub StartNewGame()
        Dim words As String() = {"APPLE", "CLOUDS", "DESK", "SUNSHINE", "FAMILY", "FRIENDS", "LAUGHTER", "OCEAN", "BREEZE", "BUTTERFLY",
                                "ADVENTURE", "BALANCE", "HARMONY", "HAPPINESS", "LOVE", "JOY", "SERENITY", "HOPE", "DREAMS", "GROWTH",
                                "PURPOSE", "CREATIVITY", "REFLECTION", "INSPIRATION", "GRATITUDE", "WISDOM", "PEACE", "HEALTH", "NATURE",
                                "KINDNESS", "COMPASSION", "COURAGE", "SUCCESS", "LEARNING", "FORGIVENESS", "PATIENCE", "MINDFULNESS",
                                "BEAUTY", "PASSION", "SPIRITUALITY", "EMBRACE", "CONNECTION", "PERSEVERANCE", "TRANSFORMATION", "ENERGY",
                                "CELEBRATION", "VITALITY", "ABUNDANCE", "POSITIVITY", "SELF-CARE", "RESILIENCE", "AWARENESS", "OPTIMISM",
                                "AUTHENTICITY", "ADVENTURE", "FRIENDSHIP", "SMILE", "LAUGHTER", "CURIOSITY", "GRACE", "KNOWLEDGE", "FREEDOM",
                                "INNOVATION", "PURPOSE", "HOPE", "DREAMS", "GROWTH", "COMPASSION", "HAPPINESS", "REFLECTION", "INSPIRATION",
                                "GRATITUDE", "WISDOM", "PEACE", "HEALTH", "NATURE", "KINDNESS", "COURAGE", "SUCCESS", "LEARNING", "FORGIVENESS",
                                "PATIENCE", "MINDFULNESS", "BEAUTY", "PASSION", "SPIRITUALITY", "EMBRACE", "CONNECTION", "PERSEVERANCE",
                                "TRANSFORMATION", "ENERGY", "CELEBRATION", "VITALITY", "ABUNDANCE", "POSITIVITY", "SELF-CARE", "RESILIENCE",
                                "AWARENESS", "OPTIMISM", "AUTHENTICITY"}
        Dim random As New Random()
        word = words(random.Next(0, words.Length)).ToUpper()
        guessedLetters.Clear()
        remainingAttempts = 6
        UpdateWordDisplay()
        UpdateHangmanImage()
        txtGuess.Text = ""
        txtGuess.Focus()
    End Sub

    Private Sub UpdateWordDisplay()
        Dim sb As New StringBuilder()

        For Each letter As Char In word
            If guessedLetters.Contains(letter) Then
                sb.Append(letter)
            Else
                sb.Append("_")
            End If
            sb.Append(" ")
        Next

        lblWord.Text = sb.ToString()
    End Sub

    Private Sub UpdateHangmanImage()
        Select Case remainingAttempts
            Case 0
                pbHangman.Image = My.Resources.about
            Case 1
                pbHangman.Image = My.Resources.abstract
            Case 2
                pbHangman.Image = My.Resources.appstore
            Case 3
                pbHangman.Image = My.Resources.arrows
            Case 4
                pbHangman.Image = My.Resources.backinminimized
            Case 5
                pbHangman.Image = My.Resources.circle
            Case 6
                pbHangman.Image = My.Resources.controlleft
            Case 7
                pbHangman.Image = My.Resources.musicplayer
        End Select
    End Sub

    Private Function HasPlayerWon() As Boolean
        For Each letter As Char In word
            If Not guessedLetters.Contains(letter) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub txtGuess_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGuess.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim guess As Char = txtGuess.Text.ToUpper()(0)

        If Not Char.IsLetter(guess) Then
            MessageBox.Show("Please enter a valid letter.")
            Return
        End If

        If guessedLetters.Contains(guess) Then
            MessageBox.Show("You already guessed that letter.")
            Return
        End If

        guessedLetters.Add(guess)
        UpdateWordDisplay()

        If word.Contains(guess) Then
            If HasPlayerWon() Then
                MessageBox.Show("Congratulations! You won!")
                StartNewGame()
            End If
        Else
            remainingAttempts -= 1
            UpdateHangmanImage()

            If remainingAttempts = 0 Then
                MessageBox.Show("Game over! The word was: " & word)
                StartNewGame()
            End If
        End If

        txtGuess.Text = ""
        txtGuess.Focus()
    End Sub

    Private Sub txtGuess_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGuess.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim guess As Char = txtGuess.Text.ToUpper()(0)

            If Not Char.IsLetter(guess) Then
                MessageBox.Show("Please enter a valid letter.")
                Return
            End If

            If guessedLetters.Contains(guess) Then
                MessageBox.Show("You already guessed that letter.")
                Return
            End If

            guessedLetters.Add(guess)
            UpdateWordDisplay()

            If word.Contains(guess) Then
                If HasPlayerWon() Then
                    MessageBox.Show("Congratulations! You won!")
                    StartNewGame()
                End If
            Else
                remainingAttempts -= 1
                UpdateHangmanImage()

                If remainingAttempts = 0 Then
                    MessageBox.Show("Game over! The word was: " & word)
                    StartNewGame()
                End If
            End If

            txtGuess.Text = ""
            txtGuess.Focus()
        End If
    End Sub
End Class