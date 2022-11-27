Class MainWindow
    Private Sub VoiceLight_Show(sender As Object, e As RoutedEventArgs)
        pageZone.Content = New VoiceLight()
    End Sub
    Private Sub Temp_Show(sender As Object, e As RoutedEventArgs)
        pageZone.Content = New Temperature()
    End Sub
    Private Sub Door_Show(sender As Object, e As RoutedEventArgs)
        pageZone.Content = New door()
    End Sub
    Private Sub Prev(sender As Object, e As RoutedEventArgs)
        If IsNothing(pageZone.Content) Then
            End
        Else
            pageZone.Content.closing()
            pageZone.Content = Nothing
        End If
    End Sub
End Class
