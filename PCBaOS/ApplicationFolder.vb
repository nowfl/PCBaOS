Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Public Class ApplicationFolder

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            calc.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox1_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            table.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox2_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Paint99.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox3_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Calendar.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox4_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Try
            Textpad.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox5_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Notes.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox6_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            settings.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox7_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ImgView.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox8_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            FoodExpert.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox9_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            PowerTools.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox10_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Browser_.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox11_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Clocks.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox12_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label14.Text = TimeOfDay
        Label13.Text = Today
    End Sub

    Private Sub PictureBox13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            Clocks.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in Panel1_Paint: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            Textpad.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in Panel2_Paint: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            Browser.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in Panel3_Paint: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox12.Click
        Try
            Browser.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox12_Click_1: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click
        Try
            Browser_.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in Label16_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Panel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            calc.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in Panel4_Paint: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox11_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        Try
            calc.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox11_Click_1: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        Try
            calc.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in Label11_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Panel5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            Calendar.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in Panel5_Paint: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        Try
            Clocks.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in Label12_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click
        Try
            Clocks.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in Label13_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click
        Try
            Clocks.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in Label14_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox13_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox13.Click, txtDateDayCalendarWidget.Click, txtDateCalendarWidget.Click
        Try
            Calendar.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox13_Click_1: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click
        Try
            Calendar.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in Label17_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Panel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.Click
        Try
            Clocks.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in Panel1_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Try
            FoodExpert.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox1_Click_1: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ImageManip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Try
            Paint99.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in ImageManip_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        Try
            ImgView.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox9_Click_1: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Try
            Notes.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox3_Click_1: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        Try
            PowerTools.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox8_Click_1: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox14.Click
        Try
            settings.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox14_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.Click
        Try
            table.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox15_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Private Sub TextBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub QuickAccess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            QuickAccess.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in QuickAccess_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox12_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox12.MouseLeave
        ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub PictureBox11_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.MouseLeave, PictureBox8.MouseLeave, PictureBox5.MouseLeave, PictureBox4.MouseLeave, PictureBox3.MouseLeave, PictureBox15.MouseLeave, PictureBox14.MouseLeave, PictureBox13.MouseLeave, PictureBox11.MouseLeave, PictureBox1.MouseLeave, Panel1.MouseLeave, PictureBox6.MouseLeave, PictureBox7.MouseLeave, PictureBox10.MouseLeave, PictureBox16.MouseLeave, txtDateDayCalendarWidget.MouseLeave, txtDateCalendarWidget.MouseLeave
        ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub PictureBox11_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.MouseEnter
        ToolStripStatusLabel1.Text = "Calculate numbers"
    End Sub

    Private Sub PictureBox13_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox13.MouseEnter, txtDateDayCalendarWidget.MouseEnter, txtDateCalendarWidget.MouseEnter
        ToolStripStatusLabel1.Text = "Check today's year, month and day"
    End Sub

    Private Sub Panel1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.MouseEnter
        ToolStripStatusLabel1.Text = "Check hours, minutes and seconds of now"
    End Sub

    Private Sub PictureBox1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        ToolStripStatusLabel1.Text = "See your favorite food recipes"
    End Sub

    Private Sub PictureBox4_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseEnter
        ToolStripStatusLabel1.Text = "Draw whatever you want"
    End Sub

    Private Sub PictureBox3_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseEnter, PictureBox6.MouseEnter
        ToolStripStatusLabel1.Text = "Write something to not forgot"
    End Sub

    Private Sub PictureBox9_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.MouseEnter
        ToolStripStatusLabel1.Text = "View your photos"
    End Sub

    Private Sub PictureBox8_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.MouseEnter
        ToolStripStatusLabel1.Text = "Advanced tool to check new features"
    End Sub

    Private Sub PictureBox2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ToolStripStatusLabel1.Text = "Useful sidebar application to quickly set volume, check internet connection or write to-do list"
    End Sub

    Private Sub PictureBox14_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox14.MouseEnter
        ToolStripStatusLabel1.Text = "Change system options and perferences"
    End Sub

    Private Sub PictureBox15_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.MouseEnter
        ToolStripStatusLabel1.Text = "Make your own table"
    End Sub

    Private Sub PictureBox5_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseEnter, PictureBox10.MouseEnter, PictureBox16.MouseEnter
        ToolStripStatusLabel1.Text = "Write whatever you want"
    End Sub

    Private Sub PictureBox22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Try
            AudioPlayer.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PictureBox22_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PCAppStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        Try
            PCApplicationStore.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in PCAppStore_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplicationStore_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseEnter
        ToolStripStatusLabel1.Text = "Download applications"
    End Sub

    Dim fact As String
    Private Sub RndFact()
        Dim facts As String() = {
            "The tallest mountain in the solar system is Olympus Mons on Mars.",
            "A cockroach can live for several weeks without its head.",
            "A group of flamingos is called a flamboyance.",
            "The shortest war in history was between Zanzibar and Great Britain in 1896. Zanzibar surrendered after just 38 minutes.",
            "The world's oldest piece of chewing gum is over 9,000 years old.",
            "The longest word in the English language is 189,819 letters long.",
            "In ancient Greece, throwing an apple at someone was a declaration of love.",
            "The world's largest snowflake on record measured 15 inches wide and 8 inches thick.",
            "An ostrich's eye is bigger than its brain.",
            "Cats can make over 100 different sounds.",
            "In Japan, letting a sumo wrestler make your baby cry is considered good luck.",
            "The first video game was invented in 1958.",
            "The world's largest swimming pool is over 1,000 yards long.",
            "The world's largest desert is Antarctica.",
            "The shortest scheduled flight in the world is only 1.7 miles long.",
            "The world's largest snow maze can be found in Warren, Vermont.",
            "A cat has five toes on its front paws, but only four toes on its back paws.",
            "There are over 24 time zones in the world.",
            "A group of hedgehogs is called a prickle.",
            "The longest wedding veil on record was longer than 63 football fields.",
            "The smallest country in the world is Vatican City, which has a total area of 0.44 square kilometers.",
            "The largest living organism on Earth is a fungus in Oregon that covers over 2,200 acres.",
            "A hippopotamus can run faster than a human on land.",
            "The world's largest chocolate bar weighed over 12,000 pounds.",
            "A group of kangaroos is called a mob.",
            "The world's largest diamond was the size of a tennis ball.",
            "A rhinoceros's horn is made of compacted hair.",
            "The tallest tree in the world is a redwood in California that stands over 380 feet tall.",
            "A group of pugs is called a grumble.",
            "The world's largest rubber duck measures over 50 feet tall.",
            "The longest insect in the world is the stick insect, which can grow up to 21 inches long.",
            "A group of otters is called a romp.",
            "The largest volcano in the solar system is Olympus Mons on Mars.",
            "A goldfish's memory span is only about three seconds.",
            "The world's smallest bird is the bee hummingbird, which is about 2.25 inches long.",
            "A group of ferrets is called a business.",
            "The highest mountain in the solar system is Olympus Mons on Mars.",
            "The world's largest pizza measured over 130 feet in diameter.",
            "The oldest living thing on Earth is a bristlecone pine tree in California that is over 4,800 years old.",
            "A group of jellyfish is called a smack.",
            "The world's deepest postbox is in Susami Bay, Japan, and is over 10 meters underwater.",
            "The fastest animal on Earth is the peregrine falcon, which can dive at speeds of over 200 miles per hour.",
            "A group of crocodiles is called a bask.",
            "The world's largest pearl weighs over 14 pounds.",
            "A group of porcupines is called a prickle."
        }
        Dim rnd As New Random()
        Dim index As Integer = rnd.Next(facts.Length)
        fact = facts(index)
    End Sub

    <DllImport("gdi32.dll", EntryPoint:="CreateRoundRectRgn")> _
    Private Shared Function CreateRoundRectRgn(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal cx As Integer, ByVal cy As Integer) As IntPtr
    End Function

    Private Sub InitalizeCustomApps()
        If My.Settings.InstalledApplications Is Nothing Then
            My.Settings.InstalledApplications = New System.Collections.Specialized.StringCollection()
        End If
        If My.Settings.InstalledApplicationNames Is Nothing Then
            My.Settings.InstalledApplicationNames = New System.Collections.Specialized.StringCollection()
        End If
        If My.Settings.InstalledApplicationClassSettings Is Nothing Then
            My.Settings.InstalledApplicationClassSettings = New System.Collections.Specialized.StringCollection()
        End If
        If My.Settings.InstalledApplicationIconDir Is Nothing Then
            My.Settings.InstalledApplicationIconDir = New System.Collections.Specialized.StringCollection()
        End If
        If My.Settings.InstalledApplicationColor Is Nothing Then
            My.Settings.InstalledApplicationColor = New System.Collections.Specialized.StringCollection()
        End If
        My.Settings.Save()
    End Sub

    Dim InstalledApplications As Specialized.StringCollection = My.Settings.InstalledApplications
    Dim InstalledApplicationNames As Specialized.StringCollection = My.Settings.InstalledApplicationNames
    Dim InstalledApplicationClassSettings As Specialized.StringCollection = My.Settings.InstalledApplicationClassSettings
    Dim InstalledApplicationIconDir As Specialized.StringCollection = My.Settings.InstalledApplicationIconDir
    Dim InstalledApplicationColor As Specialized.StringCollection = My.Settings.InstalledApplicationColor
    Private Sub CustomApp()
        If My.Settings.InstalledApplications Is Nothing Then
            My.Settings.InstalledApplications = New System.Collections.Specialized.StringCollection()
        End If

        If My.Settings.InstalledApplications IsNot Nothing AndAlso My.Settings.InstalledApplications.Count > 0 Then
            ' Create a panel for each installed application
            For i As Integer = 0 To InstalledApplications.Count - 1
                ' Create a new panel with a random color
                Dim panel As New Panel
                Dim random As New Random
                panel.BackColor = ColorTranslator.FromHtml(InstalledApplicationColor(i))
                panel.BorderStyle = BorderStyle.None
                panel.Location = New Point(100, 100)
                panel.Width = 100
                panel.Height = 116
                panel.Tag = InstalledApplicationNames(i)
                FlowLayoutPanel1.Controls.Add(panel)

                Dim pb As New PictureBox
                If InstalledApplicationIconDir(i) = "no icons" Then
                    pb.BackColor = panel.BackColor
                Else
                    Dim iconFile As String = InstalledApplicationIconDir(i)
                    pb.Image = Image.FromFile(iconFile)
                End If
                pb.Width = 80
                pb.Height = 80
                pb.Location = New Point(12, 3)
                pb.SizeMode = PictureBoxSizeMode.StretchImage
                panel.Controls.Add(pb)
                pb.Tag = i
                AddHandler pb.Click, AddressOf OpenApplication

                ' Create a new label and set its text to the name of the installed application
                Dim lbl As New Label
                lbl.Tag = i
                lbl.Text = InstalledApplicationNames(i)
                lbl.Location = New Point(3, 96)
                lbl.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
                lbl.ForeColor = Color.White
                panel.Controls.Add(lbl)


            Next
        End If
    End Sub

    Private Sub OpenApplication(ByVal sender As Object, ByVal e As EventArgs)
        Dim pb As PictureBox = DirectCast(sender, PictureBox)
        Dim index As Integer = CInt(pb.Tag)
        Dim fileName As String = InstalledApplications(index)
        Dim assemblyFile As String = fileName
        Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(assemblyFile)
        Dim type As Type = assembly.GetType(InstalledApplicationClassSettings(index))
        If GetType(Form).IsAssignableFrom(type) Then
            Dim newForm As Form = CType(Activator.CreateInstance(type), Form)
            newForm.Show()
            newForm.TopMost = True
            Me.Close()
        End If
    End Sub

    Private Sub ApplicationFolder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim newSize As Point = New Point(Me.Width, Me.Height - 32)
        Me.WindowState = FormWindowState.Normal
        Me.Size = newSize
        Me.Location = New Point(0, 32)
        InitalizeCustomApps()
        CustomApp()
        If My.Settings.AFRandomFact = True Then
            RndFact()
        Else
            Panel13.Visible = False
        End If
        RunningTextTimer.Interval = My.Settings.AFRandomFactSpeed
        If My.Settings.AFRoundedIcons = True Then
            For Each panel As Panel In FlowLayoutPanel1.Controls.OfType(Of Panel)()
                panel.BorderStyle = BorderStyle.None
                panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 15, 15))
            Next
            UserPictureBox.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, UserPictureBox.Width, UserPictureBox.Height, 15, 15))
            TextBox1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, TextBox1.Width, TextBox1.Height, 2, 2))
        Else

        End If

        Dim today As DateTime = DateTime.Today
        Dim dayOfMonth As Integer = today.Day
        txtDateCalendarWidget.Text = dayOfMonth.ToString()
        txtDateDayCalendarWidget.Text = DateTime.Now.ToString("ddd", New System.Globalization.CultureInfo("en-US")).ToUpper()
        For Each pb As PictureBox In Me.Controls.OfType(Of PictureBox)()
            ' Disable anti-aliasing
            pb.Image = New Bitmap(pb.Width, pb.Height, Imaging.PixelFormat.Format32bppArgb)
            pb.Refresh()
        Next
        Me.DoubleBuffered = True
        Me.BackColor = My.Settings.ApplicationMenuColor
        If My.Settings.UserPicture = "0" Then
            UserPictureBox.Image = My.Resources.user1
        Else
            Try
                UserPictureBox.Image = Image.FromFile(My.Settings.UserPicture.ToString)
            Catch ex As Exception
            End Try
        End If
        UserAccName.Text = My.Settings.UserName
        If My.Settings.GeographyGame = True Then
            Panel16.Visible = True
            Panel16.Tag = "Geography Game"
        End If
        If My.Settings.JokeWeb = True Then
            Panel17.Visible = True
            Panel17.Tag = "JokeWeb"
        End If
        If My.Settings.SnakeGame = True Then
            Panel18.Visible = True
            Panel18.Tag = "Snake Game"
        End If
        If My.Settings.TicTacToeGame = True Then
            Panel3.Visible = True
            Panel3.Tag = "TicTacToe"
        End If
        If My.Settings.PingPong = True Then
            Panel19.Visible = True
            Panel19.Tag = "Ping Pong"
        End If
        If My.Settings.FoodExpert = True Then
            Panel6.Visible = True
            Panel6.Tag = "FoodExpert"
        End If
        If My.Settings.Matrix = True Then
            Panel22.Visible = True
            Panel22.Tag = "Matrix"
        End If
        If My.Settings.MusicComposer = True Then
            Panel23.Visible = True
            Panel23.Tag = "Music Composer"
        End If
    End Sub

    Private Sub Application01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        GeographyGame.Show()
        Me.Close()
    End Sub

    Private Sub Application02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox16.Click
        JokeWeb.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox17.Click
        SnakeGame.Show()
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        ' Get the search string from the TextBox
        Dim searchString As String = TextBox1.Text.Trim()

        ' Loop through the child controls of the FlowLayoutPanel
        For Each ctrl As Control In FlowLayoutPanel1.Controls
            ' Check if the child control is a Panel and if its Tag meets the search requirement
            If TypeOf ctrl Is Panel AndAlso ctrl.Tag IsNot Nothing AndAlso ctrl.Tag.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 AndAlso Not ctrl.Tag.ToString().EndsWith(", non-installed", StringComparison.OrdinalIgnoreCase) Then
                ' Show the Panel
                ctrl.Visible = True
            Else
                ' Hide the Panel
                ctrl.Visible = False
            End If
        Next
    End Sub

    Private Sub TextBox1_MouseDown_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseDown
        TextBox1.Text = ""
        TextBox1.ForeColor = Color.Black
    End Sub

    Private Sub FlowLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub PictureBox18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox18.Click
        TicTacToe.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox19.Click
        PingPong.Show()
        Me.Close()
    End Sub

    Private Sub CloseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ContextMenuStrip1.Show(MousePosition)
    End Sub

    Private Sub LogOffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOffToolStripMenuItem.Click
        Const MB_TOPMOST As Integer = &H40000
        Select Case MsgBox("Are you sure to log off you from system?", MsgBoxStyle.YesNo Or MB_TOPMOST, "Log Off")
            Case MsgBoxResult.Yes
                Dim formsToClose As New List(Of Form)

                For Each frm As Form In Application.OpenForms
                    If frm IsNot WorkSpace Then
                        formsToClose.Add(frm)
                    End If
                Next

                For Each frm As Form In formsToClose
                    frm.Close()
                Next
                WorkSpace.PCBaOSToolStripMenuItem.Enabled = False
                WorkSpace.StatusStrip1.Enabled = False
                WorkSpace.TaskbarPanel.Enabled = False
                Password.ShowDialog()
        End Select
    End Sub

    Private Sub RestartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartToolStripMenuItem.Click
        Const MB_TOPMOST As Integer = &H40000
        Select Case MsgBox("Are you sure to restart your system?", MsgBoxStyle.YesNo Or MB_TOPMOST, "Restart")
            Case MsgBoxResult.Yes
                Application.Restart()
        End Select
    End Sub

    Private Sub ShutdownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutdownToolStripMenuItem.Click
        Const MB_TOPMOST As Integer = &H40000
        Select Case MsgBox("Are you sure to shutdown your system?", MsgBoxStyle.YesNo Or MB_TOPMOST, "Shutdown")
            Case MsgBoxResult.Yes
                Application.Exit()
        End Select
    End Sub

    Private Sub SystemOptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemOptionsToolStripMenuItem.Click
        Try
            settings.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in SystemOptionsToolStripMenuItem_Click: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox20_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox20.MouseLeave
        ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub PictureBox20_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox20.MouseEnter
        ToolStripStatusLabel1.Text = "View desktop"
    End Sub

    Private Sub PictureBox17_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox17.MouseLeave
        ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub PictureBox17_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox17.MouseEnter
        ToolStripStatusLabel1.Text = "Classic snake game, eat and grow!"
    End Sub

    Private Sub PictureBox19_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox19.MouseLeave
        ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub PictureBox19_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox19.MouseEnter
        ToolStripStatusLabel1.Text = "Ping, Pong with your friend"
    End Sub

    Private Sub PictureBox18_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox18.MouseEnter
        ToolStripStatusLabel1.Text = "O vs. X, who's wins?"
    End Sub

    Private Sub TextBox2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ToolStripStatusLabel1.Text = "Search anything on web"
    End Sub

    Private Sub PictureBox18_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox18.MouseLeave
        ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub TextBox2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub Button5_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.MouseEnter
        ToolStripStatusLabel1.Text = "Shutdown, restart or log out?"
    End Sub

    Private Sub Button5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.MouseLeave
        ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub TextBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.MouseLeave
        ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub TextBox1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.MouseEnter
        ToolStripStatusLabel1.Text = "Search apps by name"
    End Sub

    Private Sub SystemOptionsToolStripMenuItem_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemOptionsToolStripMenuItem.MouseEnter
        ToolStripStatusLabel1.Text = "Setup your computer"
    End Sub

    Private Sub SystemOptionsToolStripMenuItem_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemOptionsToolStripMenuItem.MouseLeave
        ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub CloseToolStripMenuItem1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem1.MouseEnter
        ToolStripStatusLabel1.Text = "Close application menu"
    End Sub

    Private Sub CloseToolStripMenuItem1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem1.MouseLeave
        ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub PictureBox20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox20.Click
        Me.Close()
    End Sub

    Private Sub Panel21_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel21.Paint

    End Sub

    Private Sub Panel6_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub PictureBox22_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox22.Click
        Converter.Show()
        Me.Close()
    End Sub

    Private Sub Button5_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button5.MouseDown
        If e.Button = MouseButtons.Right Then
            Const MB_TOPMOST As Integer = &H40000
            Select Case MsgBox("Are you sure to shutdown your system?", MsgBoxStyle.YesNo Or MB_TOPMOST, "Shutdown")
                Case MsgBoxResult.Yes
                    Application.Exit()
            End Select
        End If
    End Sub

    Private Sub PictureBox21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox21.Click
        Matrix.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox23.Click
        MusicComposer.Show()
        Me.Close()
    End Sub

    Private Sub OpenedAppsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenedAppsToolStripMenuItem.Click
        TaskMgr.Show()
        Me.Close()
    End Sub

    Private Sub RunningTextTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunningTextTimer.Tick
        Dim text As String = "Random Fact: " & fact & " "
        Static pos As Integer = 0 ' static variable to track the text position
        pos += 1 ' increment the text position
        If pos > text.Length Then pos = 0 ' reset the position if it exceeds the text length
        dailyFactTxt.Text = text.Substring(pos) & text.Substring(0, pos) ' update the textbox text
        If dailyFactTxt.Text.Length > 53 Then
            dailyFactTxt.Text = dailyFactTxt.Text.Substring(0, 53) ' truncate the fact to 35 characters
        End If
    End Sub

    Private Sub ApplicationFolder_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub PictureBox24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox24.Click, Label6.Click, Panel24.Click
        Try
            FileManager.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error in opening File Manager: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
