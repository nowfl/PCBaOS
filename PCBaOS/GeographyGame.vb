Public Class GeographyGame
    Dim number As Integer
    Dim countries As Integer
    Dim scores As Integer

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Start" Then
            Timer1.Start()
            TextBox1.Enabled = True
            Button2.Enabled = True
            Button1.Text = "Pause"
        ElseIf Button1.Text = "Pause" Then
            Timer1.Stop()
            TextBox1.Enabled = False
            Button2.Enabled = False
            Button1.Text = "Start"
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        number -= 1
        Label1.Text = number & " Seconds"
        If countries = 50 Then
            Timer1.Stop()
            MsgBox("Congulations! You win! You earned ", MsgBoxStyle.OkOnly, "You win!")
            Button1.Text = "Over"
            Button1.Enabled = False
            Button2.Enabled = False
            TextBox1.Enabled = False
            Label2.Text = "Restart application to start over"
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ListBox1.Items.Contains(TextBox1.Text) Then

        Else
            If TextBox1.Text = "Russia" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Ukraine" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "France" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Spain" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Sweden" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Norway" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Germany" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Finland" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Poland" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Italy" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "United Kingdom" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Romania" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Belarus" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Greece" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Kazakhstan" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Greece" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Bulgaria" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Iceland" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Hungary" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Portugal" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Serbia" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Austria" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Czech Republic" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Ireland" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Lithuania" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Latvia" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Croatia" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Bosnia and Herzegovina" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Slovakia" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Estonia" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Denmark" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Switzerland" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Netherlands" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Moldova" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Belgium" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Albania" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "North Macedonia" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Turkey" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Slovenia" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Montenegro" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Kosovo" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Azerbaijan" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Georgia" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Luxembourg" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Andorra" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Malta" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Liechtenstein" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "San Marino" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Monaco" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Vatican City" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Cyprus" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            If TextBox1.Text = "Armenia" Then
                countries += 1
                scores += 10
                Label3.Text = "You called: " & countries & "/50"
                Label4.Text = "Scores: " & scores
                ListBox1.Items.Add(TextBox1.Text)
            Else
                scores -= 10
                Label4.Text = "Scores: " & scores
            End If
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub GeographyGame_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        number = 600
        countries = 0
        scores = 0
        My.Settings.geographygametotalopened += 1
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ListBox1.Items.Contains(TextBox1.Text) Then

            Else
                If TextBox1.Text = "Russia" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Ukraine" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "France" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Spain" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Sweden" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Norway" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Germany" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Finland" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Poland" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Italy" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "United Kingdom" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Romania" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Belarus" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Greece" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Kazakhstan" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Greece" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Bulgaria" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Iceland" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Hungary" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Portugal" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Serbia" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Austria" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Czech Republic" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Ireland" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Lithuania" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Latvia" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Croatia" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Bosnia and Herzegovina" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Slovakia" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Estonia" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Denmark" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Switzerland" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Netherlands" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Moldova" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Belgium" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Albania" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "North Macedonia" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Turkey" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Slovenia" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Montenegro" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Kosovo" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Azerbaijan" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Georgia" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Luxembourg" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Andorra" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Malta" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Liechtenstein" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "San Marino" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Monaco" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Vatican City" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Cyprus" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
                If TextBox1.Text = "Armenia" Then
                    countries += 1
                    scores += 10
                    Label3.Text = "You called: " & countries & "/50"
                    Label4.Text = "Scores: " & scores
                    ListBox1.Items.Add(TextBox1.Text)
                Else
                    scores -= 10
                    Label4.Text = "Scores: " & scores
                End If
            End If
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Geography Game" & vbNewLine & "Created by jkloz" & vbNewLine & "Total launched: " & My.Settings.geographygametotalopened, MsgBoxStyle.OkOnly, "Geography Game")
    End Sub

    Private Sub GeGToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeGToolStripMenuItem.Click

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class