using System;
using System.Windows;
using System.Windows.Input;

namespace StudentInfoSystem.ViewModels
{
    public class TestStudentsIfEmptyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (MainViewModel.TestStudentsIfEmpty())
                MainViewModel.CopyTestStudents();
            else
                MessageBox.Show("There are already students records.");
        }
    }
}
