Imports System.Windows
Imports System.Windows.Controls

Namespace DXSample
    Public Class ItemTemplateSelector
        Inherits DataTemplateSelector

        Public Property DefaultTemplate() As DataTemplate
        Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As System.Windows.DependencyObject) As DataTemplate
            Return DefaultTemplate
        End Function
    End Class
End Namespace