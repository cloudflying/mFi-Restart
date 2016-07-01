Imports System.Threading.Tasks
Imports System.Timers
Imports RestSharp
Imports Newtonsoft.Json
Public Class Form1
    Dim timer As New Timer(1000)
    Dim failureCount As Integer = 0
    Dim rndLogin As String = "64931191539306147856453901608822"
    Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        timer.Stop()
        failureCount = 0

        restartNetwork()

        timer.Start()


    End Sub

    Private Sub btnConfigure_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles btnConfigure.LinkClicked
        Dim conf As New selection

        timer.Stop()
        If conf.ShowDialog = DialogResult.OK Then
            timer.Start()
        Else
            If My.Settings.valid = True Then
                timer.Start()
            End If
        End If


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        MsgBox(My.Settings.ports)
        AddHandler timer.Elapsed, AddressOf HandleTimer
        If My.Settings.valid = False Then
            Dim conf As New selection
            If conf.ShowDialog = DialogResult.OK Then
                timer.Start()
            Else
                If My.Settings.valid = True Then
                    timer.Start()
                Else
                    MsgBox("Setup required! Click on the Configure button")
                End If
            End If
        Else
            timer.Start()

        End If


    End Sub

    Private Async Sub HandleTimer(sender As Object, e As EventArgs)
        Await Task.Run(Sub()
                           Try
                               timer.Stop()
                               timer.Interval = 150000
                               timer.Start()

                               If My.Computer.Network.Ping(My.Settings.pingAddress) Then
                                   failureCount = 0
                                   Invoke(Sub()
                                              Me.lblStatus.Text = "Status - Good Connection"
                                              Me.lblStatus.ForeColor = Color.DarkGreen
                                          End Sub)
                               Else
                                   failureCount += 1


                                   Invoke(Sub()
                                              Me.lblStatus.Text = "Status - [" & failureCount & "] Failed to Ping! (" & DateTime.Now.ToString & ")"
                                              Me.lblStatus.ForeColor = Color.Red
                                          End Sub)

                                   If failureCount > 10 Then
                                       Invoke(Sub()
                                                  Me.lblStatus.Text = "Status - Starting Restart Procedure! (" & DateTime.Now.ToString & ")"

                                              End Sub)
                                       timer.Stop()

                                       restartNetwork()
                                       failureCount = 0
                                       timer.Interval = 300000
                                       timer.Start()
                                   End If
                               End If
                           Catch ex As Exception
                               Try
                                   failureCount += 1
                                   timer.Interval = 10000

                                   Invoke(Sub()
                                              Me.lblStatus.Text = "Status - [" & failureCount & "] Failed to Ping! (" & DateTime.Now.ToString & ")"
                                              Me.lblStatus.ForeColor = Color.Red
                                          End Sub)

                                   If failureCount > 10 Then
                                       Invoke(Sub()
                                                  Me.lblStatus.Text = "Status - Starting Restart Procedure! (" & DateTime.Now.ToString & ")"

                                              End Sub)
                                       timer.Stop()

                                       restartNetwork()
                                       failureCount = 0
                                       timer.Interval = 300000
                                       timer.Start()
                                   End If
                               Catch er As Exception

                               End Try
                           End Try
                       End Sub)
    End Sub


    Function restartNetwork()
        Try
            Dim cli As New RestClient("http://" & My.Settings.ip & "/login.cgi")

            Dim req As New RestRequest()
            req.Method = Method.POST
            ' req.AddHeader("AIROS_SESSIONID", rndLogin)
            req.AddCookie("AIROS_SESSIONID", rndLogin)
            req.AddParameter("username", My.Settings.username)
            req.AddParameter("password", My.Settings.password)
            req.AddHeader("Content-Type", "multipart/form-data;")
            Dim result As IRestResponse = cli.Execute(req)




            If result.StatusCode = "200" Then

                Dim restartports As String() = Split(My.Settings.ports, ",")

                For Each str As String In restartports
                    cli = Nothing
                    req = Nothing
                    cli = New RestClient("http://" & My.Settings.ip & "/sensors/" & str)
                    req = New RestRequest()
                    req.Method = Method.PUT
                    'req.AddHeader("AIROS_SESSIONID", rndLogin)

                    req.AddHeader("Accept", "*/*")
                    req.AddCookie("AIROS_SESSIONID", rndLogin)
                    req.AddParameter("output", "0")
                    cli.Execute(req)

                    Invoke(Sub()
                               Me.lblStatus.Text = "Status - Restarting Port - " & str
                               Me.TextBox1.AppendText(DateTime.Now.ToString & " - shutdown port - " & str & vbNewLine)
                           End Sub)

                    System.Threading.Thread.Sleep(5000)

                    cli = Nothing
                    req = Nothing
                    cli = New RestClient("http://" & My.Settings.ip & "/sensors/" & str)
                    req = New RestRequest()
                    req.Method = Method.PUT
                    'req.AddHeader("AIROS_SESSIONID", rndLogin)

                    req.AddHeader("Accept", "*/*")
                    req.AddCookie("AIROS_SESSIONID", rndLogin)
                    req.AddParameter("output", "1")
                    cli.Execute(req)

                    Invoke(Sub()
                               Me.lblStatus.Text = "Status - Restarted Port - " & str
                               Me.lblLastRestart.Text = "Last Restarted: " & DateTime.Now.ToString
                               Me.TextBox1.AppendText(DateTime.Now.ToString & " - restarted port - " & str & vbNewLine)
                           End Sub)
                Next



            Else
                MsgBox("FAILED")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
End Class
