using System;
using System.Windows;
using System.Windows.Input;

namespace StudentInfoSystem.ViewModels
{
    public class TestUsersIfEmptyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (MainViewModel.TestUsersIfEmpty())
                MainViewModel.CopyTestUsers();
            else
                MessageBox.Show("There are already users records.");
        }
    }
}