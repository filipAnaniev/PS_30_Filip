using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using UserLogin;

namespace StudentInfoSystem.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Student> _studentsList;
        private int _count;
        private Student _currentStudent;
        private bool _isAdmin;
        public event PropertyChangedEventHandler PropertyChanged;
        private StudentInfoContext context = new StudentInfoContext();

        private PreviousStudentCommand _prevStudCommand = new PreviousStudentCommand();
        private NextStudentCommand _nxtStudCommand = new NextStudentCommand();
        private TestStudentsIfEmptyCommand _testStudentsIfEmptyCommand = new TestStudentsIfEmptyCommand();
        private TestUsersIfEmptyCommand _testUsersIfEmptyCommand = new TestUsersIfEmptyCommand();

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                _isAdmin = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsAdmin"));
            }
        }

        public ObservableCollection<Student> StudentsList
        {
            get
            {
                if (_studentsList == null || _studentsList.Count != context.Students.Count())
                {
                    _studentsList = new ObservableCollection<Student>(context.Students);
                }
                return _studentsList;
            }
            set
            {
                _studentsList = value;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                if (_count < 0)
                    _count = StudentsList.Count - 1;
                else if (_count >= StudentsList.Count)
                    _count = 0;
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
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentStudent"));
            }
        }
        public PreviousStudentCommand PrevStudCommand { get { return _prevStudCommand; } }
        public NextStudentCommand NxtStudCommand { get { return _nxtStudCommand; } }
        public TestStudentsIfEmptyCommand TestStudentsIfEmptyCommand { get { return _testStudentsIfEmptyCommand; } }
        public TestUsersIfEmptyCommand TestUsersIfEmptyCommand { get { return _testUsersIfEmptyCommand; } }


        public static bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            if (countStudents > 0)
                return false;
            return true;
        }

        public static void CopyTestStudents()  // execute once to import test data into DB
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudents)
                context.Students.Add(st);
            context.SaveChanges();
        }

        public static bool TestUsersIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<User> queryUsers = context.Users;
            int countStudents = queryUsers.Count();
            if (countStudents > 0)
                return false;
            return true;
        }

        public static void CopyTestUsers() // execute once to import test data into DB
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (User usr in UserData.TestUsers)
                context.Users.Add(usr);
            context.SaveChanges();
        }
    }
}
