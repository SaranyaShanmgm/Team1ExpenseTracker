using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Team1ExpenseTracker.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Team1ExpenseTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Expense : ContentPage
    {
       

        public Expense()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ReadBudget();
            ReadExpense();


        }
        private void ReadBudget()
        {

        }

        private void ReadExpense()
        {
            var expenses = new List<Model.Expense>();
            try
            {
                string[] lines = File.ReadAllLines(App.FileName);
                foreach (var line in lines)
                {
                    string[] words = line.Split(' ');
                    var expense = new Model.Expense();
                    if (words.Length > 0)
                    {
                        expense.Name = words[0];
                    }

                    if (words.Length > 1)
                    {
                        var f = float.Parse(words[1]);
                        expense.Amount = f;
                        expense.CategoryList = (Category)Enum.Parse(typeof(Category), words[2]);
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
            { BindingContext = new Model.Expense() });
        }

        private async void Listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ExpenseEntryPage
            {
                BindingContext = e.SelectedItem as Model.Expense
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