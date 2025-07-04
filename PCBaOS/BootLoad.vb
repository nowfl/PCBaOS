Public Class BootLoad
    Dim random As New Random()

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        Label3.Text = ProgressBar1.Value & "%"

        Dim randomNumber1 As Integer = random.Next(10, 16)
        Dim randomNumber2 As Integer = random.Next(22, 26)
        Dim randomNumber3 As Integer = random.Next(30, 60)
        Dim randomNumber4 As Integer = random.Next(70, 85)

        If ProgressBar1.Value = randomNumber1 Then
            Label2.Text = "Loading system processes..."
        End If
        If ProgressBar1.Value = randomNumber2 Then
            Label2.Text = "Checking PC hardwares..."
        End If
        If ProgressBar1.Value = randomNumber3 Then
            Label2.Text = "Loading drivers..."
        End If
        If ProgressBar1.Value = randomNumber4 Then
            Label2.Text = "Loading applications..."
        End If
        If ProgressBar1.Value = 100 Then
            Label2.Text = "Loading user preferences..."
        End If


        If ProgressBar1.Value = 100 Then
            Timer2.Enabled = True
            ProgressBar1.Visible = False
            PictureBox1.Visible = True
        End If
        If ProgressBar2.Value = 100 Then
            WorkSpace.Label2.Visible = False
            Me.Close()
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        ProgressBar2.Increment(1)
    End Sub

    Private Sub BootLoad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class