Imports Newtonsoft.Json.Linq
Imports System.Windows.Threading
Class Temperature
    Private Property webAddr As String = "http://10.42.0.126:5000"
    Dim Timer As DispatcherTimer = New DispatcherTimer()
    Private Sub updateTemperatureData()
        Dim result As String = ""
        Try
            Dim webClient As New Net.WebClient
            Dim response As String = webClient.DownloadString(webAddr)
            Dim parsed As JObject = JObject.Parse(response)
            result = $"Temperature: {parsed.Item("temp").ToString()}°C{vbCrLf}Moisture Level: {parsed.Item("moist").ToString()}%"
        Catch ex As Exception
            result = $"Error!{vbCrLf}{ex.ToString()}"
        End Try
        lbldata.Content = result
    End Sub

    Private Sub Temperature_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        updateTemperatureData()
        Timer.Interval = TimeSpan.FromSeconds(3)
        AddHandler Timer.Tick, AddressOf timer_Tick
        Timer.Start()
    End Sub
    Private Sub timer_Tick(sender As Object, e As EventArgs)
        updateTemperatureData()
    End Sub
    Public Sub closing()
        Timer.Stop()
    End Sub
End Class
