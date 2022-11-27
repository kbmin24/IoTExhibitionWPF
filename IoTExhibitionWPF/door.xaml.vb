Imports Newtonsoft.Json.Linq
Imports System.Windows.Threading
Class door
    Private Property webAddr As String = "http://10.42.0.126:6022"
    Dim Timer As DispatcherTimer = New DispatcherTimer()
    Private Sub updateDoorData()
        Dim result As String = ""
        Try
            Dim webClient As New Net.WebClient
            Dim response As String = webClient.DownloadString(webAddr)
            Dim parsed As JObject = JObject.Parse(response)
            If parsed.Item("isopen") Then
                lbldata.Content = "OPEN."
                lbldata.Foreground = New SolidColorBrush(Colors.Green)
            Else
                lbldata.Content = "CLOSED."
                lbldata.Foreground = New SolidColorBrush(Colors.Red)
            End If
        Catch ex As Exception
            result = $"Error!{vbCrLf}{ex.ToString()}"
        End Try
    End Sub
    Private Sub door_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        updateDoorData()
        Timer.Interval = TimeSpan.FromSeconds(0.5)
        AddHandler Timer.Tick, AddressOf timer_Tick
        Timer.Start()
    End Sub
    Private Sub timer_Tick(sender As Object, e As EventArgs)
        updateDoorData()
    End Sub

    Public Sub closing()
        Timer.Stop()
    End Sub
End Class
