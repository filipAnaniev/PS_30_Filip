using System;

namespace UserLogin
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public long? FacultyNumber { get; set; }
        public int Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime? ActiveUntil { get; set; }

        public override string ToString()
        {
            return "Username: " + Username + "\nPassword: " + Password + "\nFaculty Number: " + FacultyNumber + "\nRole: " + Role +
                "\nCreated: " + Created + "\nActive Until: " + ActiveUntil;
        }
    }
}