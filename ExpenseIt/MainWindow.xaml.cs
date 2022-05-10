using System.Windows;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ExpenseItHome homeWindow = new ExpenseItHome();

            homeWindow.Show();
            this.Close();

            homeWindow.Height = this.Height;
            homeWindow.Width = this.Width;
        }
    }
}
