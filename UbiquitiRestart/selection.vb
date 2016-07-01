Imports RestSharp
Imports Newtonsoft.Json

Public Class selection

    Dim rndLogin As String = "64931191539306147856453901608822"
    Private Sub selection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'rndLogin = GetRandom(1000000, 9999999) & "0192341234567123456798312"

            If My.Settings.valid Then
                txtIP.Text = My.Settings.ip
                txtUsername.Text = My.Settings.username
                txtPassword.Text = My.Settings.password
                txtConfigureStatus.Text = My.Settings.pingAddress
                sensorStatus()
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Verify Login Details
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim cli As New RestClient("http://" & txtIP.Text & "/login.cgi")

            Dim req As New RestRequest()
            req.Method = Method.POST
            ' req.AddHeader("AIROS_SESSIONID", rndLogin)
            req.AddCookie("AIROS_SESSIONID", rndLogin)
            req.AddParameter("username", txtUsername.Text)
            req.AddParameter("password", txtPassword.Text)
            req.AddHeader("Content-Type", "multipart/form-data;")
            Dim result As IRestResponse = cli.Execute(req)




            If result.StatusCode = "200" Then

                cli = Nothing
                req = Nothing
                cli = New RestClient("http://" & txtIP.Text & "/sensors/")
                req = New RestRequest()
                req.Method = Method.GET
                'req.AddHeader("AIROS_SESSIONID", rndLogin)

                req.AddHeader("Accept", "*/*")
                req.AddCookie("AIROS_SESSIONID", rndLogin)
                'TextBox1.Text = cli.Execute(req).Content
                Dim sensors As sensorLibrary = JsonConvert.DeserializeObject(Of sensorLibrary)(cli.Execute(req).Content)

                Select Case sensors.sensors.Count

                    Case 8
                        chk1.Text = IIf(Len(sensors.sensors(0).label) > 0, sensors.sensors(0).label, "{NO LABEL}") & " - " & IIf(sensors.sensors(0).output = 1, "ON", "OFF")
                        chk2.Text = IIf(Len(sensors.sensors(1).label) > 0, sensors.sensors(1).label, "{NO LABEL}") & " - " & IIf(sensors.sensors(1).output = 1, "ON", "OFF")
                        chk3.Text = IIf(Len(sensors.sensors(2).label) > 0, sensors.sensors(2).label, "{NO LABEL}") & " - " & IIf(sensors.sensors(2).output = 1, "ON", "OFF")
                        chk4.Text = IIf(Len(sensors.sensors(3).label) > 0, sensors.sensors(3).label, "{NO LABEL}") & " - " & IIf(sensors.sensors(3).output = 1, "ON", "OFF")
                        chk5.Text = IIf(Len(sensors.sensors(4).label) > 0, sensors.sensors(4).label, "{NO LABEL}") & " - " & IIf(sensors.sensors(4).output = 1, "ON", "OFF")
                        chk6.Text = IIf(Len(sensors.sensors(5).label) > 0, sensors.sensors(5).label, "{NO LABEL}") & " - " & IIf(sensors.sensors(5).output = 1, "ON", "OFF")
                        chk7.Text = IIf(Len(sensors.sensors(6).label) > 0, sensors.sensors(6).label, "{NO LABEL}") & " - " & IIf(sensors.sensors(6).output = 1, "ON", "OFF")
                        chk8.Text = IIf(Len(sensors.sensors(7).label) > 0, sensors.sensors(7).label, "{NO LABEL}") & " - " & IIf(sensors.sensors(7).output = 1, "ON", "OFF")
                        chk1.Visible = True
                        chk2.Visible = True
                        chk3.Visible = True
                        chk4.Visible = True
                        chk5.Visible = True
                        chk6.Visible = True
                        chk7.Visible = True
                        chk8.Visible = True
                    Case Else
                End Select



                MsgBox(sensors.sensors.Count)

            Else
                MsgBox("FAILED")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function sensorStatus()
        Try
            Dim cli As New RestClient("http://" & txtIP.Text & "/login.cgi")

            Dim req As New RestRequest()
            req.Method = Method.POST
            ' req.AddHeader("AIROS_SESSIONID", rndLogin)
            req.AddCookie("AIROS_SESSIONID", rndLogin)
            req.AddParameter("username", txtUsername.Text)
            req.AddParameter("password", txtPassword.Text)
            req.AddHeader("Content-Type", "multipart/form-data;")
            Dim result As IRestResponse = cli.Execute(req)




            If result.StatusCode = "200" Then

                cli = Nothing
                req = Nothing
                cli = New RestClient("http://" & txtIP.Text & "/sensors/")
                req = New RestRequest()
                req.Method = Method.GET
                'req.AddHeader("AIROS_SESSIONID", rndLogin)

                req.AddHeader("Accept", "*/*")
                req.AddCookie("AIROS_SESSIONID", rndLogin)
                'TextBox1.Text = cli.Execute(req).Content
                Dim sensors As sensorLibrary = JsonConvert.DeserializeObject(Of sensorLibrary)(cli.Execute(req).Content)

                Select Case sensors.sensors.Count

                    Case 8
                        chk1.Text = IIf(Len(sensors.sensors(0).label) > 0, sensors.sensors(0).label, "{NO LABEL}") & " - " & IIf(sensors.sensors(0).output = 1, "ON", "OFF")
                        chk2.Text = IIf(Len(sensors.sensors(1).label) > 0, sensors.sensors(1).label, "{NO LABEL}") & " - " & IIf(sensors.sensors(1).output = 1, "ON", "OFF")
                        chk3.Text = IIf(Len(sensors.sensors(2).label) > 0, sensors.sensors(2).label, "{NO LABEL}") & " - " & IIf(sensors.sensors(2).output = 1, "ON", "OFF")
                        chk4.Text = IIf(Len(sensors.sensors(3).label) > 0, sensors.sensors(3).label, "{NO LABEL}") & " - " & IIf(sensors.sensors(3).output = 1, "ON", "OFF")
                        chk5.Text = IIf(Len(sensors.sensors(4).label) > 0, sensors.sensors(4).label, "{NO LABEL}") & " - " & IIf(sensors.sensors(4).output = 1, "ON", "OFF")
                        chk6.Text = IIf(Len(sensors.sensors(5).label) > 0, sensors.sensors(5).label, "{NO LABEL}") & " - " & IIf(sensors.sensors(5).output = 1, "ON", "OFF")
                        chk7.Text = IIf(Len(sensors.sensors(6).label) > 0, sensors.sensors(6).label, "{NO LABEL}") & " - " & IIf(sensors.sensors(6).output = 1, "ON", "OFF")
                        chk8.Text = IIf(Len(sensors.sensors(7).label) > 0, sensors.sensors(7).label, "{NO LABEL}") & " - " & IIf(sensors.sensors(7).output = 1, "ON", "OFF")
                        chk1.Visible = True
                        chk2.Visible = True
                        chk3.Visible = True
                        chk4.Visible = True
                        chk5.Visible = True
                        chk6.Visible = True
                        chk7.Visible = True
                        chk8.Visible = True
                    Case Else
                End Select

            Else
                MsgBox("FAILED")
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        My.Settings.ip = txtIP.Text
        My.Settings.username = txtUsername.Text
        My.Settings.password = txtPassword.Text
        My.Settings.pingAddress = txtConfigureStatus.Text


        Dim statusCheckers As String
        If chk1.Checked Then statusCheckers &= "1,"
        If chk2.Checked Then statusCheckers &= "2,"
        If chk3.Checked Then statusCheckers &= "3,"
        If chk4.Checked Then statusCheckers &= "4,"
        If chk5.Checked Then statusCheckers &= "5,"
        If chk6.Checked Then statusCheckers &= "6,"
        If chk7.Checked Then statusCheckers &= "7,"
        If chk8.Checked Then statusCheckers &= "8"

        If Len(statusCheckers) > 1 Then
            My.Settings.ports = Mid(statusCheckers, 1, Len(statusCheckers) - 1)
        End If
        My.Settings.valid = True
        My.Settings.Save()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class