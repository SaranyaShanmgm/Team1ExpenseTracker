using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Team1ExpenseTracker
{
    public partial class App : Application
    {
        public static string FileName { get; internal set; }
        public App()
        {
            InitializeComponent();
            FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Expensefile.txt");

            MainPage = new NavigationPage(new Expense());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
