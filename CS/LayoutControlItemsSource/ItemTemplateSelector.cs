using System.Windows;
using System.Windows.Controls;

namespace DXSample {
    public class ItemTemplateSelector : DataTemplateSelector {
        public DataTemplate DefaultTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container) {
            return DefaultTemplate;
        }
    }
}