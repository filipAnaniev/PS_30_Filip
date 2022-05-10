using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = new ListBoxItem() { Content = "James" };
            ListBoxItem david = new ListBoxItem() { Content = "David" };
            peopleListBox.Items.Add(james);
            peopleListBox.Items.Add(david);
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult exitingResult = MessageBox.Show("Do you really want to exit?", "Exiting?", MessageBoxButton.YesNo);
            if (exitingResult == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else if (exitingResult == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            string s = " ";
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    s += ((TextBox)item).Text;
                    s += "\n";
                }
            }


            if (txtName1.Text.Trim(' ').Length >= 2)
            {
                MessageBox.Show("Hello " + s + "!!!\nThis is your first application on Visual Studio 2022!");
            }
            else
            {
                MessageBox.Show("Please enter name with 2 characters at least.");
            }

        }

        private void btnNFactorialCalc_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse(txtNFactoriel.Text);
            if (number < 0)
            {
                MessageBox.Show("Please enter a positive number!");
            }
            else
            {
                double result = 1;
                for (int i = 1; i <= number; i++)
                    result = result * i;

                MessageBox.Show("N(" + number + ")! = " + result);
            }
        }

        private void btnCalculatePow_Click(object sender, RoutedEventArgs e)
        {
            double power = double.Parse(txtYPow.Text);
            double num = double.Parse(txtNPow.Text);
            double result = System.Math.Pow(num, power);
            MessageBox.Show(num + "^" + power + " = " + result);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("This is Windows Presentation Foundation!");
            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();
            textBlock1.Text = DateTime.Now.ToString();
        }

        private void btnShowSelected_Click(object sender, RoutedEventArgs e)
        {
            string msgGreeting;
            msgGreeting = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi, " + msgGreeting);
        }
    }
}
