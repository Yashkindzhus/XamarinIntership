using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PopUpsApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(30.0), ThirtySecondsLeft);
        }

        public bool ThirtySecondsLeft()
        {
            PopUp();
            return true;
        }

        public async void PopUp()
        {
            await DisplayAlert("Pop Up", DateTime.Now.ToString("T"), "OK");    
        }

        public async void OnSecondPageButton_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondPage());
        }
    }
}
