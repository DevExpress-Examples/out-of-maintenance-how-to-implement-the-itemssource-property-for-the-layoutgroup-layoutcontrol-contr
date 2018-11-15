<!-- default file list -->
*Files to look at*:

* **[ItemsSourceHelper.cs](./CS/LayoutControlItemsSource/ItemsSourceHelper.cs) (VB: [ItemsSourceHelper.vb](./VB/LayoutControlItemsSource/ItemsSourceHelper.vb))**
* [MainWindow.xaml](./CS/LayoutControlItemsSource/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/LayoutControlItemsSource/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/LayoutControlItemsSource/MainWindow.xaml.cs) (VB: [MainWindow.xaml](./VB/LayoutControlItemsSource/MainWindow.xaml))
* [SampleSource.cs](./CS/LayoutControlItemsSource/SampleSource.cs) (VB: [SampleSource.vb](./VB/LayoutControlItemsSource/SampleSource.vb))
<!-- default file list end -->
# How to implement the ItemsSource property for the LayoutGroup/LayoutControl control


<p>LayoutGroup/LayoutControl doesn't have the built-in ItemsSource property. In this example, we demonstrated how to provide this functionality using a <a href="https://documentation.devexpress.com/WPF/17458/MVVM-Framework/Behaviors/How-to-Create-a-Custom-Behavior">custom behavior</a> class. This behavior generates LayoutItem controls when the associated collection is changed and adds them to the Children collection of the associated control.</p>

<br/>


