using System.Windows;

namespace WpfExample
{
    public partial class MainWindow : Window
    {
        private InfoCommand _infoCommand = new InfoCommand();
        public InfoCommand InformationCommand
        {
            get
            {
                return _infoCommand;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
