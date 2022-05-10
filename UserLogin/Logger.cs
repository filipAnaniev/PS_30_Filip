using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UserLogin
{
    public static class Logger
    {
        static string pathToFile = "C:\\Users\\Filip\\source\\repos\\PS_30_Filip\\log.txt";
        private static List<string> _currentSessionActivities = new List<string>();

        public static void LogActivity(string activity)
        {
            string actitivyLine = DateTime.Now + "; "
                + LoginValidation.CurrentUserUsername + "; "
                + activity;
            _currentSessionActivities.Add(actitivyLine);


            if (File.Exists(pathToFile))
            {
                File.AppendAllText(pathToFile, actitivyLine + "\n");
            }
        }
        public static IEnumerable<string> GetFullLog()
        {
            StreamReader reader = new StreamReader(pathToFile);
            List<string> log = new List<string>();
            while (!reader.EndOfStream)
            {
                log.Add(reader.ReadLine());
            }
            reader.Close();
            return log;
        }

        public static IEnumerable<string> GetCurrentSessionActivity(string filter)
        {
            List<string> filteredActivities = (from activity in _currentSessionActivities
                                               where activity.Contains(filter)
                                               select activity).ToList();
            return filteredActivities;
        }

        public static void ClearLog()
        {
            StreamReader fileRead = new StreamReader(pathToFile);
            StringBuilder newFileText = new StringBuilder();
            string line;
            string lineDateOnly;
            DateTime lineDTOnly;
            DateTime yesterday;


            while (!fileRead.EndOfStream)
            {
                line = fileRead.ReadLine();
                lineDateOnly = line.Substring(0, line.IndexOf(" "));
                lineDTOnly = DateTime.Parse(lineDateOnly).Date;
                yesterday = DateTime.Now.AddDays(-1).Date;

                if (lineDTOnly.CompareTo(yesterday) >= 0) //if the log activites is from after the day before yesterday (онзиден)
                {
                    newFileText.Append(line + "\n");
                }
            }
            fileRead.Close();
            File.WriteAllText(pathToFile, newFileText.ToString());
        }
    }
}
