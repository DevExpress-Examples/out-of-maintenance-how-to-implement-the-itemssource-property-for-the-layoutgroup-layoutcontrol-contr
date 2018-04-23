Imports System.Windows

Namespace LayoutControlItemsSource
    Partial Public Class MainWindow
        Inherits Window

        Private source As SampleSource
        Public Sub New()
            InitializeComponent()
            source = New SampleSource(10)
            DataContext = source
        End Sub
        Private Sub Button_Click_1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            source.Add()
        End Sub
        Private Sub Button_Click_2(ByVal sender As Object, ByVal e As RoutedEventArgs)
            source.RemoveRandom()
        End Sub
        Private Sub Button_Click_3(ByVal sender As Object, ByVal e As RoutedEventArgs)
            source.RemoveAt(3)
        End Sub
    End Class
End Namespace