Imports System.Runtime.InteropServices

Public Class PingPong
    Private Const PADDLE_SPEED As Integer = 10 'The speed of the paddles
    Private Const BALL_SPEED As Integer = 6 'The speed of the ball
    Private Const BALL_SIZE As Integer = 20 'The size of the ball
    Private Const PADDLE_WIDTH As Integer = 15 'The width of the paddles
    Private Const PADDLE_HEIGHT As Integer = 80 'The height of the paddles
    Private Const SCORE_TO_WIN As Integer = 20 'The score needed to win the game

    Private player1Score As Integer = 0 'Player 1 score
    Private player2Score As Integer = 0 'Player 2 score

    Private WithEvents gameTimer As New Timer() 'The timer for the game loop

    Private paddle1 As New Rectangle() 'The rectangle representing player 1's paddle
    Private paddle2 As New Rectangle() 'The rectangle representing player 2's paddle
    Private ball As New Rectangle() 'The rectangle representing the ball
    Private ballVelocity As New Point(BALL_SPEED, BALL_SPEED) 'The velocity of the ball



    Private Const VK_SPACE As Integer = &H20
    Private Const WM_KEYDOWN As Integer = &H100
    Private Const WM_KEYUP As Integer = &H101

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function GetKeyState(ByVal nVirtKey As Integer) As Short
    End Function



    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'Set up the initial game state
        InitializeGame()
        My.Settings.pingpongtotalopened += 1
    End Sub

    Private Sub InitializeGame()
        'Set up the paddles and ball in their initial positions
        paddle1.X = 20
        paddle1.Y = PictureBox1.Height \ 2 - PADDLE_HEIGHT \ 2
        paddle1.Width = PADDLE_WIDTH
        paddle1.Height = PADDLE_HEIGHT

        paddle2.X = PictureBox1.Width - PADDLE_WIDTH - 20
        paddle2.Y = PictureBox1.Height \ 2 - PADDLE_HEIGHT \ 2
        paddle2.Width = PADDLE_WIDTH
        paddle2.Height = PADDLE_HEIGHT

        ResetBall()

        'Reset the scores
        player1Score = 0
        player2Score = 0

        'Start the game timer
        gameTimer.Interval = 20 'Set the game update rate to 20 milliseconds
        gameTimer.Start()
    End Sub

    Private Sub ResetBall()
        'Set the ball to its initial position in the center of the playing field
        ball.X = PictureBox1.Width \ 2 - BALL_SIZE \ 2
        ball.Y = PictureBox1.Height \ 2 - BALL_SIZE \ 2
        ball.Width = BALL_SIZE
        ball.Height = BALL_SIZE

        'Randomize the ball's initial direction
        Dim random As New Random()
        ballVelocity.X = If(random.Next(2) = 0, BALL_SPEED, -BALL_SPEED)
        ballVelocity.Y = If(random.Next(2) = 0, BALL_SPEED, -BALL_SPEED)
    End Sub

    Private Sub UpdateGame()
        'Move the paddles
        If KeyIsPressed(Keys.W) AndAlso paddle1.Y > 0 Then
            paddle1.Y -= PADDLE_SPEED
        ElseIf KeyIsPressed(Keys.S) AndAlso paddle1.Bottom < PictureBox1.Height Then
            paddle1.Y += PADDLE_SPEED
        End If

        If KeyIsPressed(Keys.Up) AndAlso paddle2.Y > 0 Then
            paddle2.Y -= PADDLE_SPEED
        ElseIf KeyIsPressed(Keys.Down) AndAlso paddle2.Bottom < PictureBox1.Height Then
            paddle2.Y += PADDLE_SPEED
        End If

        'Move the ball
        ball.X += ballVelocity.X
        ball.Y += ballVelocity.Y
        'Bounce the ball off the top and bottom walls
        If ball.Y < 0 OrElse ball.Bottom > PictureBox1.Height Then
            ballVelocity.Y = -ballVelocity.Y
        End If

        'Check for collisions with the paddles
        If ball.IntersectsWith(paddle1) Then
            ballVelocity.X = Math.Abs(ballVelocity.X)
        End If

        If ball.IntersectsWith(paddle2) Then
            ballVelocity.X = -Math.Abs(ballVelocity.X)
        End If

        'Check for a goal scored
        If ball.Right < 0 Then
            player2Score += 1
            If player2Score = SCORE_TO_WIN Then
                GameOver("Player 2 Wins!")
            Else
                ResetBall()
            End If
        ElseIf ball.Left > PictureBox1.Width Then
            player1Score += 1
            If player1Score = SCORE_TO_WIN Then
                GameOver("Player 1 Wins!")
            Else
                ResetBall()
            End If
        End If

        'Redraw the playing field
        Dim g As Graphics = PictureBox1.CreateGraphics()
        g.Clear(Color.Black)

        'Draw the paddles
        g.FillRectangle(Brushes.White, paddle1)
        g.FillRectangle(Brushes.White, paddle2)

        'Draw the ball
        g.FillEllipse(Brushes.White, ball)

        'Draw the scores
        Dim scoreFont As New Font("Arial", 16)
        g.DrawString("Player 1: " & player1Score.ToString(), scoreFont, Brushes.White, 20, 20)
        g.DrawString("Player 2: " & player2Score.ToString(), scoreFont, Brushes.White, PictureBox1.Width - 150, 20)
    End Sub

    Private Sub GameOver(ByVal message As String)
        'Stop the game timer
        gameTimer.Stop()

        'Display the game over message
        MessageBox.Show(message, "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Reset the game state
        InitializeGame()
        My.Settings.PingPongGameCount += 1
    End Sub

    Private Function KeyIsPressed(ByVal key As Keys) As Boolean
        ' Convert the Keys enum value to its corresponding virtual key code
        Dim virtualKeyCode As Integer = key.GetHashCode()

        ' Get the state of the key
        Dim state As Short = GetKeyState(virtualKeyCode)

        ' Check if the high-order bit is set (indicating that the key is pressed)
        Return (state And &H8000) = &H8000
    End Function

    Private Sub gameTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles gameTimer.Tick
        'Update the game state
        UpdateGame()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Stop the game timer to prevent errors when closing the form
        gameTimer.Stop()
    End Sub

    Private Sub NewGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewGameToolStripMenuItem.Click
        InitializeGame()
        My.Settings.PingPongGameCount += 1
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Ping Pong" & vbNewLine & "Created by cuziwanna" & vbNewLine & "Total launched: " & My.Settings.pingpongtotalopened & vbNewLine & "Total games: " & My.Settings.PingPongGameCount, MsgBoxStyle.OkOnly, "PingPong")
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
