Public Class PCApplicationStore
    ' Class-level variables
    Private InfoPanel As Boolean = False
    Private timer As Timer

    ' Dictionary to store application information for cleaner reference
    Private appInfo As New Dictionary(Of String, String())

#Region "Form Initialization"

    Private Sub PCApplicationStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Initialize application information dictionary
        InitializeAppInfo()

        ' Disable anti-aliasing for all PictureBoxes
        For Each pb As PictureBox In Me.Controls.OfType(Of PictureBox)()
            pb.Image = New Bitmap(pb.Width, pb.Height, Imaging.PixelFormat.Format32bppArgb)
            pb.Refresh()
        Next

        ' Initialize button states based on installed applications
        UpdateAllButtonStates()
    End Sub

    ''' <summary>
    ''' Initialize the application info dictionary with app data
    ''' </summary>
    Private Sub InitializeAppInfo()
        ' Format: [App Key, App Name, Author, Description]
        appInfo.Add("GeographyGame", New String() {"Geography Game", "jkloz",
            "Geography Game is a game that challenges players to name all the European countries within a given time limit of 600 seconds (10 minutes). Name all countries as fast as you can!"})

        appInfo.Add("JokeWeb", New String() {"JokeWeb", "jarry01",
            "JokeWeb is a parody website that pokes fun at various aspects of the internet and pop culture. On JokeWeb, visitors can find a variety of humorous content, such as Chuck Norris memes, funny GIFs and images, and other types of jokes and gags. The website is designed to be entertaining and engaging, with a colorful and playful design that adds to the overall humor of the content."})

        appInfo.Add("SnakeGame", New String() {"Snake Game", "cuziwanna",
            "The classic Snake game. In the game, the player controls a snake that moves around a grid or screen, eating food items and growing longer. The objective is to continue growing the snake as long as possible without hitting the walls or the snake's body."})

        appInfo.Add("TicTacToeGame", New String() {"Tic Tac Toe", "Beam",
            "Tic Tac Toe is a two-player game played on a 3x3 grid. The game is played by taking turns marking a square with either an X or an O. The player who succeeds in placing three of their marks in a horizontal, vertical, or diagonal row wins the game. If all squares are filled and no player has three in a row, the game is a draw."})

        appInfo.Add("PingPong", New String() {"Ping Pong", "cuziwanna",
            "Ping Pong is a classic video game that simulates the table tennis sport. The game is played on a two-dimensional court with a small rectangular paddle on each side. The objective is to use the paddle to hit a ball back and forth over the net without letting it fall on your side of the court. Each time a player misses the ball, the other player scores a point. The first player to reach a predetermined number of points wins the game."})

        appInfo.Add("FoodExpert", New String() {"FoodExpert", "PCBaOS Dev",
            "FoodExpert is a simple yet powerful recipe app that helps you discover and organize your favorite recipes. With a clean and intuitive interface. Whether you're a seasoned chef or a beginner in the kitchen, FoodExpert provides step-by-step instructions and helpful tips for each recipe."})

        appInfo.Add("Matrix", New String() {"Matrix", "Biz",
            "Matrix Digital Rain is a visual effect inspired by the Matrix movie franchise, in which falling green characters resembling a rainstorm appear on a black background. This effect has been popularized in various media and is often associated with futuristic or technological themes."})

        appInfo.Add("MusicComposer", New String() {"Music Composer", "IAComposer",
            "Music composer is a computer program or mobile app that allows users to create basic melodies and compositions using a simple interface."})
    End Sub

    ''' <summary>
    ''' Update all button states based on installed applications
    ''' </summary>
    Private Sub UpdateAllButtonStates()
        UpdateButtonState(Button1, My.Settings.GeographyGame)
        UpdateButtonState(Button2, My.Settings.SnakeGame)
        UpdateButtonState(Button3, My.Settings.JokeWeb)
        UpdateButtonState(Button4, My.Settings.TicTacToeGame)
        UpdateButtonState(Button5, My.Settings.PingPong)
        UpdateButtonState(Button6, My.Settings.FoodExpert)
        UpdateButtonState(Button7, My.Settings.Matrix)
        UpdateButtonState(Button8, My.Settings.MusicComposer)
    End Sub

    ''' <summary>
    ''' Update a button's appearance based on installation status
    ''' </summary>
    Private Sub UpdateButtonState(ByVal button As Button, ByVal isInstalled As Boolean)
        If isInstalled Then
            button.Text = "Uninstall"
            button.BackColor = Color.Red
        Else
            button.Text = "Install"
            button.BackColor = Color.Gainsboro
        End If
    End Sub
#End Region

#Region "Application Installation/Uninstallation"

    ''' <summary>
    ''' Generic method to handle app installation status changes
    ''' </summary>
    Private Sub ToggleAppInstallation(ByVal appKey As String, ByVal button As Button)
        Dim currentStatus As Boolean = CBool(My.Settings(appKey))
        Dim newStatus As Boolean = Not currentStatus

        ' Update the setting
        My.Settings(appKey) = newStatus

        ' Update button appearance
        UpdateButtonState(button, newStatus)

        ' Add notification
        Dim appName As String = appInfo(appKey)(0)
        Dim action As String = If(newStatus, "installed", "uninstalled")
        Notifications.ListBox1.Items.Add(String.Format("{0} is {1}.", appName, action))

        ' Process visual updates
        ProcessImage()
    End Sub

    ' Individual app install/uninstall handlers
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ToggleAppInstallation("GeographyGame", Button1)
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ToggleAppInstallation("SnakeGame", Button2)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ToggleAppInstallation("JokeWeb", Button3)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ToggleAppInstallation("TicTacToeGame", Button4)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ToggleAppInstallation("PingPong", Button5)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ToggleAppInstallation("FoodExpert", Button6)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        ToggleAppInstallation("Matrix", Button7)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        ToggleAppInstallation("MusicComposer", Button8)
    End Sub
#End Region

#Region "App Info Panel Management"

    ''' <summary>
    ''' Show app info panel with details for the specified app
    ''' </summary>
    Private Sub ShowAppInfo(ByVal appKey As String, ByVal pictureBox As PictureBox)
        ' Show the panel and adjust layout if needed
        Panel1.Visible = True
        If Not InfoPanel Then
            FlowLayoutPanel1.Width -= 193
            Panel10.Width -= 193
            InfoPanel = True
        End If

        ' Update app info display
        Dim info As String() = appInfo(appKey)
        PictureBox6.Image = pictureBox.Image
        AppName.Text = info(0)
        AppDev.Text = "Author: " & info(1)
        AppDesc.Text = info(2)

        ' Get the appropriate header image
        Dim headerImageName As String = appKey.ToLower() & "_header"
        If appKey = "GeographyGame" Then headerImageName = "geographic_game_header"
        If appKey = "TicTacToeGame" Then headerImageName = "tictactoe_game_header"

        ' Set the header image
        AppImg.Image = DirectCast(My.Resources.ResourceManager.GetObject(headerImageName), Image)
    End Sub

    ''' <summary>
    ''' Hide app info panel and adjust layout
    ''' </summary>
    Private Sub HideAppInfoPanel()
        Panel1.Visible = False
        If InfoPanel Then
            FlowLayoutPanel1.Width += 193
            Panel10.Width += 193
            InfoPanel = False
        End If
    End Sub

    ' App info click handlers
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        ShowAppInfo("GeographyGame", PictureBox3)
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        ShowAppInfo("SnakeGame", PictureBox4)
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        ShowAppInfo("JokeWeb", PictureBox5)
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        ShowAppInfo("TicTacToeGame", PictureBox7)
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        ShowAppInfo("PingPong", PictureBox8)
    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        ShowAppInfo("FoodExpert", PictureBox9)
    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        ShowAppInfo("Matrix", PictureBox10)
    End Sub

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        ShowAppInfo("MusicComposer", PictureBox11)
    End Sub

    ' Click handlers for various controls to hide the info panel
    Private Sub PCApplicationStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        HideAppInfoPanel()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        HideAppInfoPanel()
        RefreshStorePage()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        HideAppInfoPanel()
        RefreshStorePage()
    End Sub

    Private Sub FlowLayoutPanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlowLayoutPanel1.Click
        HideAppInfoPanel()
    End Sub

    Private Sub Panel10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel10.Click
        HideAppInfoPanel()
    End Sub
#End Region

#Region "UI Processing Methods"

    ''' <summary>
    ''' Process the Windows image animation
    ''' </summary>
    Public Sub ProcessImage()
        WorkSpace.Wait()
        WorkSpace.WindowsToolStripMenuItem.Image = My.Resources.checkmark
        WorkSpace.arelogged = False

        timer = New Timer()
        timer.Interval = 1500
        AddHandler timer.Tick, AddressOf TimerTick
        timer.Start()
    End Sub

    ''' <summary>
    ''' Timer tick handler for Windows image animation
    ''' </summary>
    Public Sub TimerTick(ByVal sender As Object, ByVal e As EventArgs)
        timer.Stop()
        WorkSpace.WindowsToolStripMenuItem.Image = My.Resources.windows
        WorkSpace.arelogged = True
    End Sub

    ''' <summary>
    ''' Refresh all PictureBoxes in the store
    ''' </summary>
    Private Sub RefreshStorePage()
        For Each panel As Panel In Me.Controls.OfType(Of Panel)()
            For Each control As Control In panel.Controls
                If TypeOf control Is PictureBox Then
                    control.Invalidate()
                End If
            Next
        Next
    End Sub

    ''' <summary>
    ''' Search functionality for the store
    ''' </summary>
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim searchString As String = TextBox1.Text.Trim()

        For Each ctrl As Control In FlowLayoutPanel1.Controls
            If TypeOf ctrl Is Panel AndAlso ctrl.Tag IsNot Nothing Then
                Dim tagString As String = ctrl.Tag.ToString()
                Dim isMatch As Boolean = tagString.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                Dim isNotExcluded As Boolean = Not tagString.EndsWith(", non-installed", StringComparison.OrdinalIgnoreCase)

                ctrl.Visible = isMatch AndAlso isNotExcluded
            Else
                ctrl.Visible = False
            End If
        Next
    End Sub

    Private Sub Panel10_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel10.Paint
        Dim rect As New Rectangle(0, 0, Panel10.Width, Panel10.Height)
        Dim brush As New System.Drawing.Drawing2D.LinearGradientBrush(rect, Color.LightGray, Color.DarkGray, 0.0F)
        e.Graphics.FillRectangle(brush, rect)
    End Sub

    Private Sub FlowLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles FlowLayoutPanel1.Paint
        ' Empty event handler but kept for possible future use
    End Sub
#End Region

#Region "Menu Handlers"

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Placeholder for future implementation
    ''' </summary>
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Empty handler - retained for possible future use
    End Sub
#End Region
End Class