using System;
using System.Collections.Generic;
using System.Text;

namespace Team1ExpenseTracker.Model
{
    public enum Category
    {
        Food,
        Transportation,
        Personal,
        Housing,
        Miscellaneous,
        Bill,
        Fuel
    }
    public class Expense
    {
        public string Name { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public Category CategoryList { get; set; }      
    }
}  

    



