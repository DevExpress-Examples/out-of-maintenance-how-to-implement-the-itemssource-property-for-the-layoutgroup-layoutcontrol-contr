using System.Windows;

namespace LayoutControlItemsSource {
    public partial class MainWindow : Window {
        SampleSource source;
        public MainWindow() {
            InitializeComponent();
            source = new SampleSource(10);
            DataContext = source;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e) {
            source.Add();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e) {
            source.RemoveRandom();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e) {
            source.RemoveAt(3);
        }
    }
}