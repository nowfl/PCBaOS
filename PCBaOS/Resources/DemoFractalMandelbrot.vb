Imports System.Drawing
Public Class DemoFractalMandelbrot

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        DrawMandelbrot()
    End Sub

    Private Sub DrawMandelbrot()
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim maxIterations As Integer = 1000

        For x As Integer = 0 To PictureBox1.Width - 1
            For y As Integer = 0 To PictureBox1.Height - 1
                Dim a As Double = Map(x, 0, PictureBox1.Width, -2.5, 1)
                Dim b As Double = Map(y, 0, PictureBox1.Height, -1, 1)

                Dim ca As Double = a
                Dim cb As Double = b
                Dim n As Integer = 0

                Do While n < maxIterations
                    Dim aa As Double = a * a - b * b
                    Dim bb As Double = 2 * a * b

                    a = aa + ca
                    b = bb + cb

                    If (a * a + b * b) > 16 Then
                        Exit Do
                    End If

                    n += 1
                Loop

                Dim brightness As Integer = Map(n, 0, maxIterations, 0, 255)
                Dim color As Color = color.FromArgb(brightness, brightness, brightness)
                bmp.SetPixel(x, y, color)
            Next
        Next

        PictureBox1.Image = bmp
    End Sub

    Private Function Map(ByVal value As Double, ByVal fromMin As Double, ByVal fromMax As Double, ByVal toMin As Double, ByVal toMax As Double) As Double
        Return ((value - fromMin) / (fromMax - fromMin)) * (toMax - toMin) + toMin
    End Function

End Class