using StudentInfoSystem.ViewModels;
using System;
using System.Windows;

namespace StudentInfoSystem
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e) //as PasswordBox doesn't allow binding the text,
                                                                                   //an event handler is created to get around it
        {
            (DataContext as LoginViewModel).PasswordTxt = txtPassword.Password;
        }

        private void Window_Deactivated(object sender, EventArgs e) //if the login window is backgroud it will clear the password,
                                                                    //downside is if user loses focus from window
                                                                    //while still writing passowrd
        {
            if (this.Topmost == false)
            {
                txtPassword.Clear();
            }
        }
    }
}
