using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CountryClocksApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnOkButton_Clicked(object sender, EventArgs e)
        {
            var database = new Database("LoginPassword");
            string user = login.Text + "," + password.Text;
            bool isEqual = false;
            List<User> users = new List<User>(database.GetItems<User>());

            for (int i = 1; i <= users.Count; i++)
            {
                isEqual = user == Convert.ToString(users[i]) ? true : false;
                if (isEqual) break;
            }

            if (isEqual) await Navigation.PushAsync(new ClocksPage());
            else await DisplayAlert("Something wrong...", "Login or password isn't correct. Try again...", "OK");
        }
    }
}