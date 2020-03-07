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
       
        public BudgetEntryPage()
        {
            InitializeComponent();
           
          
        }


        private async void SaveBudget_Clicked(object sender, EventArgs e)
        {
            var budget = (Budget)BindingContext;           

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(App.BudgetFileName, false))
            {                
                file.WriteLine(budget.BudgetAmount);
            }
            await Navigation.PopAsync();
        }

        
    }
}