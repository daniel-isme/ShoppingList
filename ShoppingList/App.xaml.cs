using System;
using ShoppingList.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ShoppingListPage();
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
