using System;
using System.Windows.Input;

namespace StudentInfoSystem.ViewModels
{
    public class NextStudentCommand : ICommand
    {
        StudentInfoContext context = new StudentInfoContext();

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ++(parameter as MainViewModel).Count;
            (parameter as MainViewModel).CurrentStudent = (parameter as MainViewModel).StudentsList[(parameter as MainViewModel).Count];
        }
    }
}
