using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace ExpenseIt
{
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string MainCaptionText { get; set; }
        public List<Person> ExpenseDataSources { get; set; }
        public ObservableCollection<string> PersonsChecked { get; set; }

        private DateTime lastChecked;
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
            }
        }

        public ExpenseItHome()
        {
            InitializeComponent();
            this.DataContext = this;
            LastChecked = DateTime.Now;
            MainCaptionText = "View Expense Report";
            PersonsChecked = new ObservableCollection<string>();
            ExpenseDataSources = new List<Person>()
            {
                new Person()
                {
                    Name = "Mike",
                    Department ="Legal",
                    Expenses = new List<Expense>()
                    {
                        new Expense(){ ExpenseType="Lunch", ExpenseAmount = 50},
                        new Expense(){ ExpenseType="Transportation", ExpenseAmount = 50}
                    }
                },
                new Person()
                {
                    Name = "Lisa",
                    Department = "Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Document printing", ExpenseAmount=50 },
                        new Expense() { ExpenseType="Gift", ExpenseAmount=125 }
                    }
                },
                new Person()
                {
                     Name = "John",
                     Department = "Engineering",
                     Expenses = new List<Expense>()
                     {
                         new Expense() { ExpenseType = "Magazine subscription", ExpenseAmount = 50 },
                         new Expense() { ExpenseType = "New machine", ExpenseAmount = 600 },
                         new Expense() { ExpenseType = "Software", ExpenseAmount = 500 }
                     }
                },
                new Person()
                {
                    Name = "Mary",
                    Department = "Finance",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                    }
                },
                new Person()
                {
                    Name = "Theo",
                    Department = "Marketing",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount=100 }
                    }
                },
                new Person()
                {
                    Name = "James",
                    Department = "Finance",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount=90 }
                    }
                },
                new Person()
                {
                    Name = "David",
                    Department = "Engineering",
                    Expenses = new List<Expense>()
                    {
                        new Expense() { ExpenseType="Dinner", ExpenseAmount=100 },
                        new Expense() { ExpenseType = "New machine", ExpenseAmount = 500 }
                    }
                }
            };
        }

        private void btnViewReport_Click(object sender, RoutedEventArgs e)
        {
            ExpenseReport report = new ExpenseReport(peopleListBox.SelectedItem);
            report.Width = this.Width;
            report.Height = this.Height;
            report.ShowDialog();
        }

        private void peopleListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
            PersonsChecked.Add((peopleListBox.SelectedItem as Person).Name);
        }
    }
}
