using System.ComponentModel;
using System.Windows;

namespace StudentInfoSystem.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _usernameTxt;
        private string _passwordTxt;
        private Student _currentStudent;
        public event PropertyChangedEventHandler PropertyChanged;
        LoginCommand _loginCommand = new LoginCommand();
        public LoginCommand LoginCmd { get { return _loginCommand; } }
        public string UsernameTxt
        {
            get
            {
                return _usernameTxt;
            }
            set
            {
                _usernameTxt = value;
                PropChanged("UsernameTxt");
            }
        }
        public string PasswordTxt
        {
            get
            {
                return _passwordTxt;
            }
            set
            {
                _passwordTxt = value;
                PropChanged("PasswordTxt");
            }
        }
        public Student CurrentStudent
        {
            get
            {
                return _currentStudent;
            }
            set
            {
                _currentStudent = value;
                PropChanged("CurrentStudent");
            }
        }

        public static void onError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void PropChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
