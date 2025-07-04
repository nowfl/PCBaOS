Imports System.Threading
Imports System.Net.Sockets
Imports System.Net
Imports System.Text

Public Class ChatPer

    Private client As TcpClient

    Private Sub btnConnect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConnect.Click
        If txtUsername.Text = "" Then
            MsgBox("Enter username", vbOKOnly, "ChatPer")
        Else
            client = New TcpClient()
            client.Connect(txtServerIP.Text, Integer.Parse(txtPort.Text))
            MessageBox.Show("Connected to server")

            Dim stream As NetworkStream = client.GetStream()

            ' Send the username to the server
            Dim sendBytes As Byte() = Encoding.ASCII.GetBytes(txtUsername.Text + vbCrLf)
            stream.Write(sendBytes, 0, sendBytes.Length)

            ' Disable username, server IP, and port text boxes
            txtUsername.ReadOnly = True
            txtServerIP.ReadOnly = True
            txtPort.ReadOnly = True

            ' Begin an asynchronous read operation to receive chat messages from the server
            Dim buffer(1024) As Byte
            stream.BeginRead(buffer, 0, buffer.Length, AddressOf ReadCallback, buffer)

            ' Clear the chat log text box
            txtChatLog.Text = ""
        End If

    End Sub

    Private Sub btnSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSend.Click
         Dim stream As NetworkStream = client.GetStream()

        ' Split the message into lines
        Dim messages() As String = txtMessage.Text.Split(vbCrLf)

        For Each message As String In messages
            If message.Trim() <> "" Then
                Dim sendBytes As Byte() = Encoding.ASCII.GetBytes(message + vbCrLf)
                stream.Write(sendBytes, 0, sendBytes.Length)

                ' Append the user's message to the chat log
                chatLog.Append("You: " & message & vbCrLf)

                ' Update the chat log text box
                txtChatLog.Invoke(Sub() txtChatLog.Text = chatLog.ToString())
            End If
        Next

        ' Clear the text box for the next message
        txtMessage.Text = ""
    End Sub

    Private chatLog As New StringBuilder()
    Private Sub ReadCallback(ByVal ar As IAsyncResult)
        Dim buffer() As Byte = CType(ar.AsyncState, Byte())
        Dim stream As NetworkStream = client.GetStream()

        ' End the asynchronous read operation
        Dim bytesRead As Integer = stream.EndRead(ar)
        Dim data As String = Encoding.ASCII.GetString(buffer, 0, bytesRead)

        ' Check if the received data is a chat message or a chat log
        If data.StartsWith("[CHATLOG]") Then
            ' Append the chat log to the chat log text box
            chatLog.Append(data.Substring("[CHATLOG]".Length))
        ElseIf data.StartsWith("[MYMSG]") Then
            ' Append your own message to the chat log with a special identifier
            chatLog.Append("[You]: " & data.Substring("[MYMSG]".Length))
        Else
            ' Append the received data to the chat log
            chatLog.Append(data + vbCrLf)
        End If

        ' Update the chat log text box
        txtChatLog.Invoke(Sub() txtChatLog.Text = chatLog.ToString())

        ' Begin another asynchronous read operation
        stream.BeginRead(buffer, 0, buffer.Length, AddressOf ReadCallback, buffer)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ChatPerServer.Show()
    End Sub
End Class