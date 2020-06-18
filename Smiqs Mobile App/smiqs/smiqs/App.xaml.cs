using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using smiqs.View;
namespace smiqs
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SubscriptionsPage());
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
