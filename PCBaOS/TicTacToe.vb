Public Class TicTacToe
    Private currentPlayer As String = "X"
    Public xvictories As Integer = 0
    Public ovictories As Integer = 0
    Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim button As Button = CType(sender, Button)
        If button.Text = "" Then
            button.Text = currentPlayer
            If CheckForWinner() Then
                MessageBox.Show(currentPlayer & " wins!")
                If currentPlayer = "X" Then
                    xvictories += 1
                End If
                If currentPlayer = "O" Then
                    ovictories += 1
                End If
                Label1.Text = "O: " & ovictories
                Label2.Text = "X: " & xvictories
                My.Settings.TicTacToeGameCount += 1
                ResetBoard()
            ElseIf CheckForTie() Then
                MessageBox.Show("Tie game!")
                My.Settings.TicTacToeGameCount += 1
                ResetBoard()
            Else
                SwitchPlayer()
            End If
        End If
    End Sub

    Private Function CheckForWinner() As Boolean
        ' Check rows
        If (Button1.Text = currentPlayer And Button2.Text = currentPlayer And Button3.Text = currentPlayer) _
            Or (Button4.Text = currentPlayer And Button5.Text = currentPlayer And Button6.Text = currentPlayer) _
            Or (Button7.Text = currentPlayer And Button8.Text = currentPlayer And Button9.Text = currentPlayer) Then
            Return True
        End If

        ' Check columns
        If (Button1.Text = currentPlayer And Button4.Text = currentPlayer And Button7.Text = currentPlayer) _
            Or (Button2.Text = currentPlayer And Button5.Text = currentPlayer And Button8.Text = currentPlayer) _
            Or (Button3.Text = currentPlayer And Button6.Text = currentPlayer And Button9.Text = currentPlayer) Then
            Return True
        End If

        ' Check diagonals
        If (Button1.Text = currentPlayer And Button5.Text = currentPlayer And Button9.Text = currentPlayer) _
            Or (Button3.Text = currentPlayer And Button5.Text = currentPlayer And Button7.Text = currentPlayer) Then
            Return True
        End If

        Return False
    End Function

    Private Function CheckForTie() As Boolean
        For Each control As Control In Controls
            If TypeOf control Is Button AndAlso control.Text = "" Then
                Return False
            End If
        Next

        Return True
    End Function

    Private Sub ResetBoard()
        For Each control As Control In Controls
            If TypeOf control Is Button Then
                control.Text = ""
            End If
        Next
    End Sub

    Private Sub SwitchPlayer()
        If currentPlayer = "X" Then
            currentPlayer = "O"
        Else
            currentPlayer = "X"
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Button_Click(sender, e)
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Button_Click(sender, e)
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Button_Click(sender, e)
    End Sub

    Private Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        Button_Click(sender, e)
    End Sub

    Private Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button5.Click
        Button_Click(sender, e)
    End Sub

    Private Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6.Click
        Button_Click(sender, e)
    End Sub

    Private Sub Button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button7.Click
        Button_Click(sender, e)
    End Sub

    Private Sub Button8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button8.Click
        Button_Click(sender, e)
    End Sub

    Private Sub Button9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button9.Click
        Button_Click(sender, e)
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Tic Tac Toe" & vbNewLine & "Created by Beam" & vbNewLine & "Total launched: " & My.Settings.tictactoegametotalopened & vbNewLine & "Total games: " & My.Settings.TicTacToeGameCount, MsgBoxStyle.OkOnly, "Tic Tac Toe")
    End Sub

    Private Sub NewGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewGameToolStripMenuItem.Click
        ResetBoard()
        My.Settings.TicTacToeGameCount += 1
        ovictories = 0
        xvictories = 0
        Label1.Text = "O: " & ovictories
        Label2.Text = "X: " & xvictories
    End Sub

    Private Sub TicTacToe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Settings.tictactoegametotalopened += 1
    End Sub
End Class