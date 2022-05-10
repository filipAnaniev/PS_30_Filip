using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem.ViewModels
{
    public class InsertingStudViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private AddStudCommand _addStudCommand = new AddStudCommand();

        private string _firstName;
        private string _middleName;
        private string _lastName;
        private List<string> _faculties;
        private string _selectedFaculty;
        private List<string> _academicDegrees;
        private string _selectedDegree;
        private List<string> _specialties;
        private string _selectedSpecialty;
        private List<string> _studStatusChoices;
        private string _selectedStatus;
        private long _facNum;
        private int _acadYear;
        private int _stream;
        private int _group;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                PropChanged("FirstName");
            }
        }
        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value;
                PropChanged("MiddleName");
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                PropChanged("LastName");
            }
        }
        public List<string> Faculties
        {
            get
            {
                if (_faculties == null)
                    FillFaculties();
                return _faculties;
            }
            set
            {
                _faculties = value;
                PropChanged("Faculties");
            }
        }
        public string SelectedFaculty
        {
            get { return _selectedFaculty; }
            set
            {
                _selectedFaculty = value;
                PropChanged("SelectedFaculty");
                FillSpecialties();
            }
        }
        public List<string> AcademicDegrees
        {
            get
            {
                if (_academicDegrees == null)
                    FillDegrees();
                return _academicDegrees;
            }
            set
            {
                _academicDegrees = value;
                PropChanged("AcademicDegrees");
            }
        }
        public string SelectedDegree
        {
            get { return _selectedDegree; }
            set
            {
                _selectedDegree = value;
                PropChanged("SelectedDegree");
                FillSpecialties();
            }
        }
        public List<string> Specialties
        {
            get
            {
                return _specialties;
            }
            set
            {
                _specialties = value;
                PropChanged("Specialties");
            }
        }
        public string SelectedSpecialty
        {
            get { return _selectedSpecialty; }
            set
            {
                _selectedSpecialty = value;
                PropChanged("SelectedSpecialty");
            }
        }
        public List<string> StudStatusChoices
        {
            get
            {
                if (_studStatusChoices == null)
                    FillStudStatusChoices();
                return _studStatusChoices;
            }
            set
            {
                _studStatusChoices = value;
                PropChanged("StudStatusChoices");
            }
        }
        public string SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                _selectedStatus = value;
                PropChanged("SelectedStatus");
            }
        }
        public long FacNum
        {
            get { return _facNum; }
            set
            {
                _facNum = value;
                PropChanged("FacNum");
            }
        }
        public int AcadYear
        {
            get { return _acadYear; }
            set
            {
                _acadYear = value;
                PropChanged("AcadYear");
            }
        }
        public int Stream
        {
            get { return _stream; }
            set
            {
                _stream = value;
                PropChanged("Stream");
            }
        }
        public int Group
        {
            get { return _group; }
            set
            {
                _group = value;
                PropChanged("Group");
            }
        }
        public AddStudCommand AddStudCmd { get { return _addStudCommand; } }


        private void FillFaculties()
        {
            _faculties = new List<string>();
            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT FacultyDescr
                                    FROM Faculty";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    _faculties.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        private void FillStudStatusChoices()
        {
            _studStatusChoices = new List<string>();
            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT StatusDescr 
                                    FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    _studStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        private void FillDegrees()
        {
            _academicDegrees = new List<string>();
            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT DegreeDescr
                                    FROM AcademicDegrees";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    _academicDegrees.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        private void FillSpecialties()
        {

            _specialties = new List<string>();
            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery = @"SELECT SpecialtyDescr FROM Specialties WHERE Faculty='" + SelectedFaculty.ToString()
                    + "' AND Degree='" + SelectedDegree.ToString() + "'";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    _specialties.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
            PropChanged("Specialties");
        }

        public void PropChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
