Imports System.Runtime.InteropServices

Public Class Search
    <DllImport("gdi32.dll", EntryPoint:="CreateRoundRectRgn")> _
    Private Shared Function CreateRoundRectRgn(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal cx As Integer, ByVal cy As Integer) As IntPtr
    End Function
    Private Sub Search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(15, 35)
        Me.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Me.Width, Me.Height, 15, 15))
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If My.Settings.SearchEngine = "Google" Then
                Browser.Show()
                Browser.WebBrowser1.Navigate("https://www.google.com/search?q=" & TextBox1.Text)
                Me.Close()
            End If
            If My.Settings.SearchEngine = "Bing" Then
                Browser.Show()
                Browser.WebBrowser1.Navigate("https://www.bing.com/search?q=" & TextBox1.Text)
                Me.Close()
            End If
            If My.Settings.SearchEngine = "Yahoo" Then
                Browser.Show()
                Browser.WebBrowser1.Navigate("https://search.yahoo.com/search?p=" & TextBox1.Text)
                Me.Close()
            End If
            If My.Settings.SearchEngine = "Duck" Then
                Browser.Show()
                Browser.WebBrowser1.Navigate("https://duckduckgo.com/?q=" & TextBox1.Text)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub TextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Enter
        TextBox1.Text = ""
        TextBox1.ForeColor = Color.Black
    End Sub

    Private Sub TextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        TextBox1.Text = "Write something..."
        TextBox1.ForeColor = Color.LightGray
    End Sub

    Private Sub Search_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Me.Close()
    End Sub
End Class