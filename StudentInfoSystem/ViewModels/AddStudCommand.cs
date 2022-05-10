using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using UserLogin;

namespace StudentInfoSystem.ViewModels
{
    public class AddStudCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            InsertingStudViewModel data = (InsertingStudViewModel)parameter;

            checkInputs(data);
            StudentInfoContext context = new StudentInfoContext();

            Student st = new Student()
            {
                Name = data.FirstName,
                SecondName = data.MiddleName,
                LastName = data.LastName,
                Faculty = data.SelectedFaculty,
                AcademicDegree = data.SelectedDegree,
                Specialty = data.SelectedSpecialty,
                AcademicStatus = data.SelectedStatus,
                FacultyNumber = data.FacNum,
                AcademicYear = data.AcadYear,
                Stream = data.Stream,
                Group = data.Group
            };
            context.Students.Add(st);

            string generatedUsername = (data.FirstName.Remove(2, data.FirstName.Length - 2) + data.LastName.Remove(2, data.LastName.Length - 2)).ToLower()
                + getLastUser(context).UserID;
            User usr = new User
            {
                Username = generatedUsername,
                Password = data.FacNum.ToString(),
                FacultyNumber = data.FacNum,
                Role = (int)UserRoles.STUDENT,
                Created = DateTime.Now,
                ActiveUntil = DateTime.MaxValue
            };
            context.Users.Add(usr);

            context.SaveChanges();
            string msg = "Student and user added with creditentials:\nUsername:" + generatedUsername + "\nPassword:" + data.FacNum;
            MessageBox.Show(msg, "Success");
            Window wind = Application.Current.Windows.OfType<Window>().LastOrDefault();
            wind.Close();
        }
        private void checkInputs(InsertingStudViewModel data)
        {
            if (string.IsNullOrEmpty(data.FirstName) || data.FirstName.Any(char.IsDigit))
            {
                MessageBox.Show("First name is incorrect.");
                return;
            }
            if (string.IsNullOrEmpty(data.LastName) || data.LastName.Any(char.IsDigit))
            {
                MessageBox.Show("Last name is incorrect.");
                return;
            }
            if (string.IsNullOrEmpty(data.MiddleName) || data.MiddleName.Any(char.IsDigit))
            {
                MessageBox.Show("Middle name is incorrect.");
                return;
            }
            if (data.SelectedFaculty == null)
            {
                MessageBox.Show("Select faculty.");
                return;
            }
            if (data.SelectedDegree == null)
            {
                MessageBox.Show("Select degree.");
                return;
            }
            if (data.SelectedSpecialty == null)
            {
                MessageBox.Show("Select specialty.");
                return;
            }
            if (data.SelectedStatus == null)
            {
                MessageBox.Show("Select Status.");
                return;
            }
            if (data.FacNum <= 0)
            {
                MessageBox.Show("Faculty number is incorrect.");
                return;
            }
            if (data.AcadYear <= 0)
            {
                MessageBox.Show("Academic year is incorrect.");
                return;
            }
            if (data.Stream <= 0)
            {
                MessageBox.Show("Stream is incorrect.");
                return;
            }
            if (data.Group <= 0)
            {
                MessageBox.Show("Group is incorrect.");
                return;
            }
        }
        private User getLastUser(StudentInfoContext context)
        {
            return context.Users.OrderByDescending(x => x.UserID).FirstOrDefault();
        }
    }
}