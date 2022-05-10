using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName, password;
            User user1 = null;

            Console.Write("Enter username: ");
            userName = Console.ReadLine();
            Console.Write("Enter password: ");
            password = Console.ReadLine();
            Console.WriteLine();

            LoginValidation validator = new LoginValidation(userName, password, ErrPrint);
            if (validator.ValidateUserInput(ref user1))
                Console.WriteLine(user1.ToString());

            Console.WriteLine();
            if (user1 != null)
            {
                switch (LoginValidation.CurrentUserRole)
                {
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("Current user has no role or is not logged in.");
                        break;
                    case UserRoles.ADMIN:
                        AdministratorMenu();
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("Current user is admin.");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("Current user is professor.");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("Current user is student.");
                        break;
                }
            }
        }

        static void ErrPrint(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        static void AdministratorMenu()
        {
            Console.WriteLine("\nChose option:");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Change user's role");
            Console.WriteLine("2: Change until when user is active");
            Console.WriteLine("3: List all users");
            Console.WriteLine("4: Read log of activity");
            Console.WriteLine("5: Read current activity");
            Console.WriteLine("6: Delete log activity older than yesterday");

            char choice = char.Parse(Console.ReadLine());

            switch (choice)
            {
                case '0':
                    Console.WriteLine("Exiting.");
                    break;
                case '1':
                    Console.WriteLine("Changing user's role: ");
                    ChangeDate();
                    break;
                case '2':
                    Console.WriteLine("Changing user's until aactive date: ");
                    ChangeRole();
                    break;
                case '3':
                    Console.WriteLine("All users: ");
                    PrintAllUsers();
                    break;
                case '4':
                    {
                        Console.WriteLine("Full log: ");
                        IEnumerable<string> fullLog = Logger.GetFullLog();
                        StringBuilder sb = new StringBuilder();

                        foreach (string line in fullLog)
                        {
                            Console.WriteLine(line);
                            sb.Append(line);
                        }
                        break;
                    }
                case '5':
                    {
                        Console.WriteLine("Enter filter (or leave empty for full log): ");
                        string filter = Console.ReadLine();
                        Console.WriteLine();

                        StringBuilder sb = new StringBuilder();
                        List<string> currentAct = (List<string>)Logger.GetCurrentSessionActivity(filter);
                        if (currentAct.Count == 0)
                        {
                            ErrPrint("Log is empty!");
                        }

                        foreach (string line in currentAct)
                        {
                            Console.WriteLine(line);
                            sb.Append(line);
                        }
                        break;
                    }
                case '6':
                    Console.WriteLine("Deleting log activity older than yesterday... ");
                    Logger.ClearLog();
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    return;

            }
        }

        static void ChangeRole()
        {
            string usernameToChange;
            int newRole;
            Console.Write("\nEnter username of the user: ");
            usernameToChange = Console.ReadLine();
            Console.Write("Enter the new role of the user (as an integer): ");
            newRole = int.Parse(Console.ReadLine());
            UserData.AssignUserRole(usernameToChange, (UserRoles)newRole);
        }

        static void ChangeDate()
        {
            string usernameToChange;
            string newActiveDate;
            Console.Write("\nEnter username of the user: ");
            usernameToChange = Console.ReadLine();
            Console.Write("Enter the new date until active: ");
            newActiveDate = Console.ReadLine();
            UserData.SetUserActiveTo(usernameToChange, Convert.ToDateTime(newActiveDate));
        }
        static void PrintAllUsers()
        {
            UserContext context = new UserContext();
            foreach (User var in context.Users)
            {
                Console.WriteLine(var + "");
            }
        }
    }
}