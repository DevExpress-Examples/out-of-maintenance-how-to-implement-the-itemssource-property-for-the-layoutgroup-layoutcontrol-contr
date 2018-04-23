Imports System.Collections
Imports System.Collections.Specialized
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports DevExpress.Xpf.LayoutControl
Imports DevExpress.Xpf.Mvvm.UI.Interactivity

Namespace LayoutControlItemsSource
    Public Class ItemsSourceHelper
        Inherits Behavior(Of LayoutGroup)

        Public Shared ReadOnly ItemTemplateSelectorProperty As DependencyProperty = DependencyProperty.Register("ItemTemplateSelector", GetType(DataTemplateSelector), GetType(ItemsSourceHelper), New PropertyMetadata())
        Public Shared ReadOnly ItemTemplateProperty As DependencyProperty = DependencyProperty.Register("ItemTemplate", GetType(DataTemplate), GetType(ItemsSourceHelper), New PropertyMetadata())
        Public Shared ReadOnly ItemsSourceProperty As DependencyProperty = DependencyProperty.Register("ItemsSource", GetType(IEnumerable), GetType(ItemsSourceHelper), New PropertyMetadata(Sub(d, e) CType(d, ItemsSourceHelper).OnItemsSourceChanged(e)))

        Public Property ItemTemplateSelector() As DataTemplateSelector
            Get
                Return CType(GetValue(ItemTemplateSelectorProperty), DataTemplateSelector)
            End Get
            Set(ByVal value As DataTemplateSelector)
                SetValue(ItemTemplateSelectorProperty, value)
            End Set
        End Property
        Public Property ItemTemplate() As DataTemplate
            Get
                Return CType(GetValue(ItemTemplateProperty), DataTemplate)
            End Get
            Set(ByVal value As DataTemplate)
                SetValue(ItemTemplateProperty, value)
            End Set
        End Property
        Public Property ItemsSource() As IEnumerable
            Get
                Return DirectCast(GetValue(ItemsSourceProperty), IEnumerable)
            End Get
            Set(ByVal value As IEnumerable)
                SetValue(ItemsSourceProperty, value)
            End Set
        End Property

        Protected ReadOnly Property Group() As LayoutGroup
            Get
                Return AssociatedObject
            End Get
        End Property
        Protected ReadOnly Property Children() As UIElementCollection
            Get
                Return Group.Children
            End Get
        End Property

        Protected Overrides Sub OnAttached()
            MyBase.OnAttached()
            RearrangeChildren()
        End Sub

        Protected Overridable Sub OnItemsSourceChanged(ByVal e As DependencyPropertyChangedEventArgs)
            If TypeOf e.OldValue Is INotifyCollectionChanged Then
                RemoveHandler DirectCast(e.NewValue, INotifyCollectionChanged).CollectionChanged, AddressOf OnItemsSourceCollectionChanged
            End If
            If TypeOf e.NewValue Is INotifyCollectionChanged Then
                AddHandler DirectCast(e.NewValue, INotifyCollectionChanged).CollectionChanged, AddressOf OnItemsSourceCollectionChanged
            End If
            If Group IsNot Nothing Then
                RearrangeChildren()
            End If
        End Sub
        Protected Overridable Sub OnItemsSourceCollectionChanged(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
            If Group Is Nothing Then
                Return
            End If
            If e.Action = NotifyCollectionChangedAction.Reset Then
                RearrangeChildren()
            End If
            If e.NewItems IsNot Nothing Then
                For Each item In e.NewItems
                    AddItem(item)
                Next item
            End If
            If e.OldItems IsNot Nothing Then
                For Each item In e.OldItems
                    RemoveItem(TryCast(item, SampleItem))
                Next item
            End If
        End Sub
        Protected Overridable Sub RearrangeChildren()
            Children.Clear()
            If ItemsSource IsNot Nothing Then
                For Each item In ItemsSource
                    AddItem(item)
                Next item
            End If
        End Sub
        Protected Overridable Sub RemoveItem(ByVal item As Object)
            Dim layoutItem = Children.OfType(Of LayoutItem)().FirstOrDefault(Function(x) x.DataContext.Equals(item))
            If layoutItem IsNot Nothing Then
                Children.Remove(layoutItem)
            End If
        End Sub
        Protected Overridable Sub AddItem(ByVal item As Object)
            Dim layoutItem = New LayoutItem With {.DataContext = item}
            If TypeOf item Is SampleItem Then
                LayoutControl.SetTabHeader(layoutItem, DirectCast(item, SampleItem).Name)
            End If
            Dim content = New ContentControl With {.Content = item}
            content.SetBinding(ContentControl.ContentTemplateProperty, New Binding("ItemTemplate") With { _
                .Mode = BindingMode.TwoWay, _
                .Source = Me _
            })
            content.SetBinding(ContentControl.ContentTemplateSelectorProperty, New Binding("ItemTemplateSelector") With { _
                .Mode = BindingMode.TwoWay, _
                .Source = Me _
            })
            layoutItem.Content = content
            Children.Add(layoutItem)
        End Sub
    End Class
End Namespace