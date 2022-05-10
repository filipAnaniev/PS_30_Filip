using StudentInfoSystem.ViewModels;
using System.Windows;

namespace StudentInfoSystem.Views
{
    public partial class InsertingWindow : Window
    {
        public InsertingWindow()
        {
            this.DataContext = new InsertingStudViewModel();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel and erase all written data?", "Cancelling",
                                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}
