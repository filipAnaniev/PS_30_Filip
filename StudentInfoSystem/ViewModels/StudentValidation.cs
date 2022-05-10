using System.Linq;
using UserLogin;

namespace StudentInfoSystem.ViewModels
{
    internal class StudentValidation
    {
        public static Student GetStudentDataByUser(User user)
        {
            if (user.FacultyNumber == 0)
            {
                LoginViewModel.onError("Invalid Faculty Number");
                return null;
            }

            StudentInfoContext context = new StudentInfoContext();
            Student result =
                (from st in context.Students
                 where st.FacultyNumber == user.FacultyNumber
                 select st).FirstOrDefault();
            return result;
        }
    }
}
