using StudentInfoSystem.ViewModels;
using StudentInfoSystem.Views;
using System.Windows;
using System.Windows.Controls;

namespace StudentInfoSystem
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void clearFields()
        {
            foreach (var item in gridPersonal.Children)
                if (item is TextBox)
                    (item as TextBox).Clear();

            foreach (var item in gridStudent.Children)
                if (item is TextBox)
                    (item as TextBox).Clear();
        }
        private void disableFields()
        {
            grbPersonal.IsEnabled = false;
            grbStudent.IsEnabled = false;
        }
        private void enableFields()
        {
            grbPersonal.IsEnabled = true;
            grbStudent.IsEnabled = true;
            btnPreviousStudent.IsEnabled = true;
        }
        private void hideControls()
        {
            grbPersonal.Visibility = Visibility.Hidden;
            grbStudent.Visibility = Visibility.Hidden;
            btnPreviousStudent.Visibility = Visibility.Hidden;
        }
        private void showControls()
        {
            grbPersonal.Visibility = Visibility.Visible;
            grbStudent.Visibility = Visibility.Visible;
            btnPreviousStudent.Visibility = Visibility.Visible;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult exitingResult = MessageBox.Show("Do you really want to exit?", "Exiting?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (exitingResult == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        private void addStudent_Click(object sender, RoutedEventArgs e)
        {
            InsertingWindow insert = new InsertingWindow();
            insert.ShowDialog();
        }
    }
}
