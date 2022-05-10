using System.Windows;

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for NamesWindow.xaml
    /// </summary>
    public partial class NamesWindow : Window
    {
        public NamesWindow()
        {
            InitializeComponent();
            DataContext = new NamesList();
        }
    }
}
