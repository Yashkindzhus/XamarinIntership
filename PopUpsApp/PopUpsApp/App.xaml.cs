using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PopUpsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            MainPage.DisplayAlert("Start App", "OnStart()", "OK");
        }

        protected override void OnSleep()
        {
            MainPage.DisplayAlert("Sleep App", "OnSleep()", "OK");
        }

        protected override void OnResume()
        {
            MainPage.DisplayAlert("Resume App", "OnResume()", "OK");
        }

  
    }
}
