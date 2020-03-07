using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team1ExpenseTracker.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Team1ExpenseTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesPage : ContentPage
    {
        static Budget budget;
        static TotalExpense totalexpense;


        public ExpensesPage()
        {
            InitializeComponent();

            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            ReadBudget();

            ReadExpense();

            ReadTotalExpense();

            BalanceRemaining();

        }

      private void BalanceRemaining()
       {
            var remaininAmount = budget.BudgetAmount - App.total;

            totalexpense.RemainingBalance = 0;

            App.total = 0;

            totalexpense.RemainingBalance = remaininAmount;

            stacklayout3.BindingContext = totalexpense;

            Remaininglable.SetBinding(Label.TextProperty, "RemainingBalance");


        }

        private void ReadTotalExpense()
        {
            totalexpense = new TotalExpense();

            totalexpense.AllExpenseAdded = App.total;            
            
            stacklayout2.BindingContext = totalexpense;

            ExpenseLable.SetBinding(Label.TextProperty, "AllExpenseAdded");
        }
            
              

         
        private void ReadBudget()
        {
            string savedbudgetamount = File.ReadAllText(App.BudgetFileName);

            budget = new Budget();

            budget.BudgetAmount = float.Parse(savedbudgetamount);
                       
            stacklayout1.BindingContext = budget;



        }

        public void ReadExpense()
        {
           
            var expenses = new List<Expense>();
            try
            {
                
                string[] lines = File.ReadAllLines(App.FileName);
                foreach (var line in lines)
                {
                    string[] words = line.Split(' ');
                    var expense = new Expense();
                    if (words.Length > 0)
                    {
                        expense.Name = words[0];
                    }

                    if (words.Length > 1)
                    {
                        float f = float.Parse(words[1]);
                        expense.Amount = f;

                        App.total = App.total + f;

                        
                    }
                   
                    expenses.Add(expense);

                }
                Expenselistview.ItemsSource = expenses.ToList();
               
                
            }
            catch (FileNotFoundException)
            {

            }
        }

       

        async void OnExpenseAdded_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpenseEntryPage
            { BindingContext = new Expense() });
        }

        private async void Listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ExpenseEntryPage
            {
                BindingContext = e.SelectedItem as Expense
            });
        }

        private async void OnBudgetButton_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new BudgetEntryPage
            {
                BindingContext = new Budget()
            });
        }
    }
}