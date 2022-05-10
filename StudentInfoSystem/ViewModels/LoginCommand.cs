using System;
using System.Windows;
using System.Windows.Input;
using UserLogin;


namespace StudentInfoSystem.ViewModels
{
    public class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            User user = null;

            LoginValidation checkLogin = new LoginValidation((parameter as LoginViewModel).UsernameTxt,
                (parameter as LoginViewModel).PasswordTxt, LoginViewModel.onError);

            if (checkLogin.ValidateUserInput(ref user))
            {
                (parameter as LoginViewModel).UsernameTxt = "";
                (parameter as LoginViewModel).PasswordTxt = "";

                MainWindow info = new MainWindow();

                if (LoginValidation.CurrentUserRole.Equals(UserRoles.STUDENT))
                {
                    MessageBox.Show("Succesfull login!", "Login", MessageBoxButton.OK);
                    (parameter as LoginViewModel).CurrentStudent = StudentValidation.GetStudentDataByUser(user);
                    (info.DataContext as MainViewModel).IsAdmin = false;
                }
                else if (LoginValidation.CurrentUserRole.Equals(UserRoles.ADMIN))
                {
                    MessageBox.Show("Succesfull login as admin!", "Login", MessageBoxButton.OK);
                    (info.DataContext as MainViewModel).IsAdmin = true;
                }

                (info.DataContext as MainViewModel).CurrentStudent = (parameter as LoginViewModel).CurrentStudent;
                info.ShowDialog();

            }
        }
    }
}
