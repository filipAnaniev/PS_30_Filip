using System.Collections.Generic;

namespace StudentInfoSystem
{
    static class StudentData
    {
        private static List<Student> _testStudents = new List<Student>();

        public static List<Student> TestStudents
        {
            get
            {
                if (_testStudents.Count == 0)
                {
                    _testStudents.Add(new Student()
                    {
                        Name = "Ivan",
                        SecondName = "Petrov",
                        LastName = "Atanasov",
                        Specialty = "Electronics",
                        Faculty = "Faculty of Electronic Engineering and Technologies",
                        AcademicDegree = "Мaster",
                        AcademicStatus = "Certified",
                        FacultyNumber = 9374593239,
                        AcademicYear = 2,
                        Stream = 5,
                        Group = 24
                    });
                    _testStudents.Add(new Student()
                    {
                        Name = "Georgi",
                        SecondName = "Viktorov",
                        LastName = "Kamenov",
                        Specialty = "Cybersecurity",
                        Faculty = "Faculty of Computer Systems and Technologies",
                        AcademicDegree = "Bachelor",
                        AcademicStatus = "Dropped",
                        FacultyNumber = 9374593934,
                        AcademicYear = 1,
                        Stream = 10,
                        Group = 13
                    });
                    _testStudents.Add(new Student()
                    {
                        Name = "Petar",
                        SecondName = "Ivanov",
                        LastName = "Marianov",
                        Specialty = "Nuclear Power Engineering",
                        Faculty = "Faculty of Thermal and Nuclear Power Engineering",
                        AcademicDegree = "Master",
                        AcademicStatus = "Semester Graduate",
                        FacultyNumber = 937459002,
                        AcademicYear = 4,
                        Stream = 9,
                        Group = 4
                    });
                }
                return _testStudents;
            }
            private set { }
        }
    }
}
