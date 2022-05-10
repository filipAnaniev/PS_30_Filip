using System.Windows;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseReport.xaml
    /// </summary>
    public partial class ExpenseReport : Window
    {
        public ExpenseReport()
        {
            InitializeComponent();
        }
        public ExpenseReport(object data) : this()
        {
            this.DataContext = data;
        }
    }
}
