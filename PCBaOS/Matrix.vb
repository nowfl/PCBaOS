Public Class Matrix
    Dim rnd As New Random()
    Dim columns As Integer
    Dim rows As Integer
    Dim drops As Char()()
    Dim symbols As Char() = {"0"c, "1"c}

    Public Sub New()
        InitializeComponent()
        InitializeMatrix()
    End Sub

    Private Sub InitializeMatrix()
        DoubleBuffered = True
        columns = Me.Width \ 8
        rows = Me.Height \ 8
        ReDim drops(columns - 1)
        For i As Integer = 0 To columns - 1
            drops(i) = New Char(rows - 1) {}
        Next
        Timer1.Interval = 50
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        UpdateDrops()
        Me.Invalidate()
    End Sub

    Private Sub UpdateDrops()
        For i As Integer = 0 To columns - 1
            If rnd.NextDouble() > 0.95 Then
                drops(i)(0) = symbols(rnd.Next(symbols.Length))
            End If
            For j As Integer = rows - 1 To 1 Step -1
                drops(i)(j) = drops(i)(j - 1)
            Next
            drops(i)(0) = If(rnd.NextDouble() > 0.95, symbols(rnd.Next(symbols.Length)), " "c)
        Next
    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.Clear(Color.Black)
        DrawMatrix(e.Graphics)
    End Sub

    Private Sub DrawMatrix(ByVal g As Graphics)
        Using brush As New SolidBrush(Color.LimeGreen)
            For i As Integer = 0 To columns - 1
                For j As Integer = 0 To rows - 1
                    If drops(i)(j) <> " "c Then
                        g.DrawString(drops(i)(j).ToString(), Me.Font, brush, i * 8, j * 8)
                    End If
                Next
            Next
        End Using
    End Sub

    Private Sub Matrix_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        InitializeMatrix()
    End Sub
End Class