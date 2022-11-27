Imports System.IO
Imports System.Net.Http
Imports System.Speech.Recognition
Imports System.Windows.Threading
Imports Newtonsoft.Json.Linq

Class VoiceLight
    Dim ison As Boolean = True
    Const key As String = "LIFX API Key"
    Const sel As String = "label:bruh"

    Public Sub closing()

    End Sub
    Dim wordlist As String() = New String() {"on", "off", "purple", "red", "green", "blue", "white", "pulse", "effect"}
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Using recogniser As SpeechRecognitionEngine = New SpeechRecognitionEngine(New Globalization.CultureInfo("en-GB"))
            Dim words As New Choices(wordlist)
            Dim gram As Grammar = New Grammar(New GrammarBuilder(words))
            recogniser.LoadGrammar(gram)
            AddHandler recogniser.SpeechRecognized, AddressOf recognised
            recogniser.SetInputToDefaultAudioDevice()
            btnclick.Content = "I am listening..."
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, New Action(Function() 7))
            recogniser.Recognize()
            btnclick.Content = "Click me and speak!"
        End Using
    End Sub
    Private Function recognised(sender As Object, e As SpeechRecognizedEventArgs)
        MsgBox(e.Result.Text)
        If e.Result.Text = "off" Or e.Result.Text = "on" Then
            off()
        ElseIf e.Result.Text = "pulse" Or e.Result.Text = "effect" Then
            flame()
        ElseIf e.Result.Text = "blue" Then
            blue()
        ElseIf e.Result.Text = "red" Then
            red()
        ElseIf e.Result.Text = "purple" Then
            purple()
        ElseIf e.Result.Text = "green" Then
            green()
        ElseIf e.Result.Text = "white" Then
            white()
        Else
            MsgBox("Not Found")
        End If

    End Function
    Private Function off()
        Dim request As System.Net.HttpWebRequest
        Dim response As System.Net.HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim postdata As New JObject
        postdata.Add("duration", "1")
        'postdata contains data which will be posted with the request
        Dim finalString As String = postdata.ToString

        request = DirectCast(System.Net.WebRequest.Create("https://api.lifx.com/v1/lights/all/toggle"), System.Net.HttpWebRequest)
        request.Headers.Add("accept", "text/plain")
        request.Headers.Add("Authorization", "Bearer c5178fdffb2ab3d1a822bdd38e04a969722ec663b69cbfba05b1b28eb20c4d79")
        request.ContentType = "application/json"
        request.Method = "POST"
        response = DirectCast(request.GetResponse(), System.Net.HttpWebResponse)

        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()
        MsgBox(rawresp)
    End Function
    Private Function flame()
        Dim request As System.Net.HttpWebRequest
        Dim response As System.Net.HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim postdata As New JObject
        postdata.Add("color", "red")
        postdata.Add("period", 1)
        postdata.Add("cycles", 10)
        postdata.Add("persist", False)
        postdata.Add("power_on", True)
        postdata.Add("from_color", "orange")

        'postdata contains data which will be posted with the request
        Dim finalString As String = postdata.ToString()

        request = DirectCast(System.Net.WebRequest.Create("https://api.lifx.com/v1/lights/all/effects/pulse"), System.Net.HttpWebRequest)
        request.Headers.Add("accept", "application/json")
        request.Headers.Add("Authorization", "Bearer c5178fdffb2ab3d1a822bdd38e04a969722ec663b69cbfba05b1b28eb20c4d79")
        request.ContentType = "application/json"
        request.Method = "POST"

        Using streamWriter = New StreamWriter(request.GetRequestStream())
            streamWriter.Write(finalString)
        End Using

        response = DirectCast(request.GetResponse(), System.Net.HttpWebResponse)

        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()
        MsgBox(rawresp)
    End Function
    Private Function blue()
        Dim request As System.Net.HttpWebRequest
        Dim response As System.Net.HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim postdata As New JObject
        postdata.Add("color", "blue")
        postdata.Add("power", "on")

        'postdata contains data which will be posted with the request
        Dim finalString As String = postdata.ToString()

        request = DirectCast(System.Net.WebRequest.Create("https://api.lifx.com/v1/lights/all/state"), System.Net.HttpWebRequest)
        request.Headers.Add("accept", "application/json")
        request.Headers.Add("Authorization", "Bearer c5178fdffb2ab3d1a822bdd38e04a969722ec663b69cbfba05b1b28eb20c4d79")
        request.ContentType = "application/json"
        request.Method = "PUT"

        Using streamWriter = New StreamWriter(request.GetRequestStream())
            streamWriter.Write(finalString)
        End Using

        response = DirectCast(request.GetResponse(), System.Net.HttpWebResponse)

        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()
        MsgBox(rawresp)
    End Function
    Private Function red()
        Dim request As System.Net.HttpWebRequest
        Dim response As System.Net.HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim postdata As New JObject
        postdata.Add("color", "red")
        postdata.Add("power", "on")

        'postdata contains data which will be posted with the request
        Dim finalString As String = postdata.ToString()

        request = DirectCast(System.Net.WebRequest.Create("https://api.lifx.com/v1/lights/all/state"), System.Net.HttpWebRequest)
        request.Headers.Add("accept", "application/json")
        request.Headers.Add("Authorization", "Bearer c5178fdffb2ab3d1a822bdd38e04a969722ec663b69cbfba05b1b28eb20c4d79")
        request.ContentType = "application/json"
        request.Method = "PUT"

        Using streamWriter = New StreamWriter(request.GetRequestStream())
            streamWriter.Write(finalString)
        End Using

        response = DirectCast(request.GetResponse(), System.Net.HttpWebResponse)

        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()
        MsgBox(rawresp)
    End Function
    Private Function purple()
        Dim request As System.Net.HttpWebRequest
        Dim response As System.Net.HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim postdata As New JObject
        postdata.Add("color", "purple")
        postdata.Add("power", "on")

        'postdata contains data which will be posted with the request
        Dim finalString As String = postdata.ToString()

        request = DirectCast(System.Net.WebRequest.Create("https://api.lifx.com/v1/lights/all/state"), System.Net.HttpWebRequest)
        request.Headers.Add("accept", "application/json")
        request.Headers.Add("Authorization", "Bearer c5178fdffb2ab3d1a822bdd38e04a969722ec663b69cbfba05b1b28eb20c4d79")
        request.ContentType = "application/json"
        request.Method = "PUT"

        Using streamWriter = New StreamWriter(request.GetRequestStream())
            streamWriter.Write(finalString)
        End Using

        response = DirectCast(request.GetResponse(), System.Net.HttpWebResponse)

        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()
        MsgBox(rawresp)
    End Function
    Private Function white()
        Dim request As System.Net.HttpWebRequest
        Dim response As System.Net.HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim postdata As New JObject
        postdata.Add("color", "white")
        postdata.Add("power", "on")

        'postdata contains data which will be posted with the request
        Dim finalString As String = postdata.ToString()

        request = DirectCast(System.Net.WebRequest.Create("https://api.lifx.com/v1/lights/all/state"), System.Net.HttpWebRequest)
        request.Headers.Add("accept", "application/json")
        request.Headers.Add("Authorization", "Bearer c5178fdffb2ab3d1a822bdd38e04a969722ec663b69cbfba05b1b28eb20c4d79")
        request.ContentType = "application/json"
        request.Method = "PUT"

        Using streamWriter = New StreamWriter(request.GetRequestStream())
            streamWriter.Write(finalString)
        End Using

        response = DirectCast(request.GetResponse(), System.Net.HttpWebResponse)

        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()
        MsgBox(rawresp)
    End Function
    Private Function green()
        Dim request As System.Net.HttpWebRequest
        Dim response As System.Net.HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim postdata As New JObject
        postdata.Add("color", "green")
        postdata.Add("power", "on")

        'postdata contains data which will be posted with the request
        Dim finalString As String = postdata.ToString()

        request = DirectCast(System.Net.WebRequest.Create("https://api.lifx.com/v1/lights/all/state"), System.Net.HttpWebRequest)
        request.Headers.Add("accept", "application/json")
        request.Headers.Add("Authorization", "Bearer c5178fdffb2ab3d1a822bdd38e04a969722ec663b69cbfba05b1b28eb20c4d79")
        request.ContentType = "application/json"
        request.Method = "PUT"

        Using streamWriter = New StreamWriter(request.GetRequestStream())
            streamWriter.Write(finalString)
        End Using

        response = DirectCast(request.GetResponse(), System.Net.HttpWebResponse)

        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()
        MsgBox(rawresp)
    End Function
End Class
