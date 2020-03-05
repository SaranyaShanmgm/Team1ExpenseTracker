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
    public partial class BudgetEntryPage : ContentPage
    {
        public static string BudgetFileName { get; set; }
        public BudgetEntryPage()
        {
            InitializeComponent();
            BudgetFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BudgetFile.txt");
        }

        private async void SaveBudget_Clicked(object sender, EventArgs e)
        {
            var budget = (Budget)BindingContext;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(BudgetFileName, true))
            {
                file.WriteLine(budget.BudgetAmount);
            }
            await Navigation.PopAsync();
        }

        private void DeleteBudget_Clicked(object sender, EventArgs e)
        {

        }
    }
}