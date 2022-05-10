using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace EasyMVVM
{
    public class MainWindowsVM : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;   //This event will be fired to notify any listeners of a change in a property value.
        private ObservableCollection<string> _backingProperty;

        public MainWindowsVM()
        {
            Model m = new Model();
            BoundProperty = m.GetData();
        }

        public ObservableCollection<string> BoundProperty
        {
            get { return _backingProperty; }
            set
            {
                _backingProperty = value;
                PropChanged("BoundProperty");
            }
        }

        public void PropChanged(string propertyName)    //Tell WPF Binding that this property value has changed
        {
            if (PropertyChanged != null)  //Did WPF registerd to listen to this event
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));  //Tell WPF that this property changed
            }
        }
    }
}
