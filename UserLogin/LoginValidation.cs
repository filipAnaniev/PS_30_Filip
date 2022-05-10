namespace UserLogin
{
    public class LoginValidation
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        public static UserRoles CurrentUserRole { get; private set; }
        public static string CurrentUserUsername { get; private set; }

        public delegate void ActionOnErrorDelegate(string errorMsg);
        private ActionOnErrorDelegate _onError;

        public LoginValidation(string username, string password, ActionOnErrorDelegate onError)
        {
            _username = username;
            _password = password;
            _onError = new ActionOnErrorDelegate(onError);
        }

        public bool ValidateUserInput(ref User user)
        {
            bool emptyUserName;
            emptyUserName = string.IsNullOrEmpty(_username);
            if (emptyUserName)
            {
                _errorMessage = "No username specified!";
                _onError(_errorMessage);
                CurrentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            bool emptyPassword;
            emptyPassword = string.IsNullOrEmpty(_password);
            if (emptyPassword)
            {
                _errorMessage = "No password specified!";
                _onError(_errorMessage);
                CurrentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            bool shortUserName;
            shortUserName = _username.Length < 5;
            if (shortUserName)
            {
                _errorMessage = "Username must be at least 5 characters!";
                _onError(_errorMessage);
                CurrentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            bool shortPassowrd;
            shortPassowrd = _password.Length < 5;
            if (shortPassowrd)
            {
                _errorMessage = "Password must be at least 5 characters!";
                _onError(_errorMessage);
                CurrentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            user = UserData.IsUserPassCorrect(_username, _password);

            if (user != null)
            {
                CurrentUserRole = (UserRoles)user.Role;
                CurrentUserUsername = _username;
                Logger.LogActivity("Successful Login");
                return true;
            }
            else
            {
                _errorMessage = "No such user found!";
                _onError(_errorMessage);
                CurrentUserUsername = null;
                CurrentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
        }
    }
}
