using System.Collections.Generic;

namespace ExpenseIt
{
    public class Person
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
