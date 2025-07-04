Public Class SnakeGame
    Private Const GridWidth As Integer = 20
    Private Const GridHeight As Integer = 20
    Private Const GridSize As Integer = 20
    Private Const TickInterval As Integer = 100

    Private random As New Random()
    Private snake As New List(Of Point)
    Private food As Point
    Private direction As Point = New Point(1, 0)
    Private isGameOver As Boolean = False
    Private score As Integer = 0

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        snake.Add(New Point(GridWidth \ 2, GridHeight \ 2))
        SpawnFood()
        Timer1.Interval = TickInterval
        Timer1.Enabled = False
        Label2.Text = "Your best score: " & My.Settings.SnakeGameBestScore
        My.Settings.snakegametotalopened += 1
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        Dim head As Point = snake.Last()
        Dim newHead As Point = head + direction

        If newHead.X < 0 OrElse newHead.X >= GridWidth OrElse newHead.Y < 0 OrElse newHead.Y >= GridHeight OrElse snake.Contains(newHead) Then
            isGameOver = True
            Timer1.Enabled = False
            If (My.Settings.SnakeGameBestScore <= score) Then
                My.Settings.SnakeGameBestScore = score
            End If
            My.Settings.SnakeGameGamesCount += 1
            MessageBox.Show("Game over!" & vbNewLine & "Your score has: " & score)
            ' Reset game state
            snake.Clear()
            snake.Add(New Point(GridWidth \ 2, GridHeight \ 2))
            SpawnFood()
            direction = New Point(1, 0)
            isGameOver = False
            score = 0
            Label1.Text = "Score: " & score
            Label2.Text = "Your best score: " & My.Settings.SnakeGameBestScore

            PictureBox1.Invalidate()
            Return
        End If

        snake.Add(newHead)

        If newHead = food Then
            SpawnFood()
            score += 1
            Label1.Text = "Score: " & score
        Else
            snake.RemoveAt(0)
        End If

        PictureBox1.Invalidate()
    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles PictureBox1.Paint
        For x As Integer = 0 To GridWidth - 1
            For y As Integer = 0 To GridHeight - 1
                Dim rect As New Rectangle(x * GridSize, y * GridSize, GridSize, GridSize)
                e.Graphics.DrawRectangle(Pens.Gray, rect)
            Next
        Next

        For Each p As Point In snake
            Dim rect As New Rectangle(p.X * GridSize, p.Y * GridSize, GridSize, GridSize)
            e.Graphics.FillRectangle(Brushes.Red, rect)
            e.Graphics.DrawRectangle(Pens.Gray, rect)
        Next

        Dim foodRect As New Rectangle(food.X * GridSize, food.Y * GridSize, GridSize, GridSize)
        e.Graphics.FillEllipse(Brushes.Red, foodRect)
    End Sub

    Private Sub SpawnFood()
        Do
            food = New Point(random.Next(GridWidth), random.Next(GridHeight))
        Loop Until Not snake.Contains(food)
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                If direction <> New Point(0, 1) Then
                    direction = New Point(0, -1)
                    Timer1.Enabled = True

                End If
            Case Keys.Down
                If direction <> New Point(0, -1) Then
                    direction = New Point(0, 1)
                    Timer1.Enabled = True
                End If
            Case Keys.Left
                If direction <> New Point(1, 0) Then
                    direction = New Point(-1, 0)
                    Timer1.Enabled = True
                End If
            Case Keys.Right
                If direction <> New Point(-1, 0) Then
                    direction = New Point(1, 0)
                    Timer1.Enabled = True
                End If
        End Select
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Snake" & vbNewLine & "Created by cuziwanna" & vbNewLine & "Total launched: " & My.Settings.snakegametotalopened & vbNewLine & "Total games: " & My.Settings.SnakeGameGamesCount, MsgBoxStyle.OkOnly, "SnakeGame")
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NewGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewGameToolStripMenuItem.Click
        ' Reset game state
        snake.Clear()
        snake.Add(New Point(GridWidth \ 2, GridHeight \ 2))
        SpawnFood()
        direction = New Point(1, 0)
        isGameOver = False
        score = 0
        Label1.Text = "Score: " & score
        Label2.Text = "Your best score: " & My.Settings.SnakeGameBestScore
        My.Settings.SnakeGameGamesCount += 1

        ' Redraw the game board
        PictureBox1.Invalidate()
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class