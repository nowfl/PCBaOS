Imports System.Net.Sockets
Imports System.Text
Imports System.Threading.Tasks
Imports System.Net
Imports System.Net.NetworkInformation

Public Class ChatPerServer
    Private clients As List(Of TcpClient) = New List(Of TcpClient)()
    Private serverThread As Threading.Thread


    Private Sub btnStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStart.Click
        Dim port As Integer
        If Integer.TryParse(txtPort.Text, port) AndAlso Not String.IsNullOrEmpty(txtPort.Text) Then
            btnStart.Enabled = False
            ' Create a new thread to run the server code
            serverThread = New Threading.Thread(AddressOf StartServer)
            serverThread.Start()
            txtPort.ReadOnly = True
            Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            For Each adapter As NetworkInterface In adapters
                If adapter.NetworkInterfaceType = NetworkInterfaceType.Wireless80211 And adapter.OperationalStatus = OperationalStatus.Up Then
                    For Each address As UnicastIPAddressInformation In adapter.GetIPProperties().UnicastAddresses
                        If address.Address.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                            TextBox1.Text = address.Address.ToString()
                            Exit Sub
                        End If
                    Next
                End If
            Next
            ' If the wireless LAN adapter was not found or does not have an IPv4 address, display an error message
            MessageBox.Show("Could not find wireless LAN adapter or its IPv4 address.", "Error")
        Else
            MsgBox("Please enter correct port number", vbOKOnly, "ChatPer")
        End If

    End Sub

    Private Sub btnStop_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Disable the stop button and enable the start button
        btnStart.Enabled = True
        shouldRun = False
        serverThread.Join()
        txtPort.ReadOnly = False
    End Sub
    Private shouldRun As Boolean = True
    Dim listener As TcpListener
    Dim clientThread As Threading.Thread
    Private Sub StartServer()
        Dim listener As TcpListener = New TcpListener(System.Net.IPAddress.Any, Integer.Parse(txtPort.Text))
        listener.Start()

        While shouldRun
            Dim client As TcpClient = listener.AcceptTcpClient()

            ' Read the username from the client
            Dim stream As NetworkStream = client.GetStream()
            Dim usernameBuffer(1024) As Byte
            Dim usernameBytes As Integer = stream.Read(usernameBuffer, 0, usernameBuffer.Length)
            Dim username As String = Encoding.ASCII.GetString(usernameBuffer, 0, usernameBytes).Trim()

            ' Handle the client with the username
            Dim clientThread As Threading.Thread = New Threading.Thread(Sub() HandleClient(client, username))
            clientThread.Start()
        End While
        listener.Stop()
    End Sub


    Private Sub HandleClient(ByVal client As TcpClient, ByVal username As String)
        clients.Add(client)
        Dim stream As NetworkStream = client.GetStream()

        Dim buffer(1024) As Byte

        While (True)
            Dim data As String = ""
            Dim bytes As Integer = stream.Read(buffer, 0, buffer.Length)
            data += Encoding.ASCII.GetString(buffer, 0, bytes)
            If (data.IndexOf(vbLf) > -1) Then
                Dim message As String = username + ": " + data.Trim()

                ' Display the message in the chat log
                txtChatLog.Invoke(Sub() txtChatLog.AppendText(message + vbCrLf))

                Dim sendBytes As Byte() = Encoding.ASCII.GetBytes(message)

                ' Send the message to all clients
                For Each c As TcpClient In clients
                    If c IsNot client Then
                        c.GetStream().Write(sendBytes, 0, sendBytes.Length)
                    End If
                Next

                data = ""
            End If
        End While


        client.Close()
    End Sub


End Class