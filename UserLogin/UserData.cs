using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> _testUsers = new List<User>();
        public static List<User> TestUsers
        {
            get
            {
                _resetTestUserData();
                return _testUsers;
            }
        }
        private static void _resetTestUserData()
        {
            if (_testUsers.Count == 0)
            {
                _testUsers.Add(new User()
                {
                    Username = "administrator",
                    Password = "qwerty123",
                    FacultyNumber = 1,
                    Role = 1,
                    Created = DateTime.Now,
                    ActiveUntil = DateTime.MaxValue
                });
                _testUsers.Add(new User()
                {
                    Username = "student1",
                    Password = "student1",
                    FacultyNumber = 9374593239,
                    Role = 4,
                    Created = DateTime.Now,
                    ActiveUntil = DateTime.MaxValue
                });
                _testUsers.Add(new User()
                {
                    Username = "student2",
                    Password = "student2",
                    FacultyNumber = 9374593934,
                    Role = 4,
                    Created = DateTime.Now,
                    ActiveUntil = DateTime.MaxValue
                });
                _testUsers.Add(new User()
                {
                    Username = "student3",
                    Password = "student3",
                    FacultyNumber = 937459002,
                    Role = 4,
                    Created = DateTime.Now,
                    ActiveUntil = DateTime.MaxValue
                });
            }
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            UserContext context = new UserContext();
            User result =
                (from u in context.Users
                 where u.Username.Equals(username) && u.Password.Equals(password)
                 select u).FirstOrDefault();

            /*User result =
                (from u in TestUsers
                 where u.Username.Equals(username) && u.Password.Equals(password)
                 select u).FirstOrDefault();*/

            return result;
        }

        public static void SetUserActiveTo(string username, DateTime activeTo)
        {
            UserContext context = new UserContext();
            User usr =
                (from u in context.Users
                 where u.Username == username
                 select u).FirstOrDefault();
            if (usr != null)
            {
                usr.ActiveUntil = activeTo;
                context.SaveChanges();
                Console.WriteLine("Date until active of {0} changed to {1}!\n", username, activeTo.ToString());
                Logger.LogActivity("Changed active date of " + username);
                return;
            }
            Console.WriteLine("No such user found!\n");
        }

        public static void AssignUserRole(string username, UserRoles newRole)
        {
            UserContext context = new UserContext();
            User usr =
                (from u in context.Users
                 where u.Username == username
                 select u).FirstOrDefault();
            if (usr != null)
            {
                usr.Role = (int)newRole;
                context.SaveChanges();
                Console.WriteLine("Role of {0} changed to {1}!\n", username, newRole);
                Logger.LogActivity("Changed role of " + username);
                return;
            }
            Console.WriteLine("No such user found!\n");
        }
    }
}
