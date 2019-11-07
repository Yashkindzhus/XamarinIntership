using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TitleChangerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeTitlePage : ContentPage
    {
        public ChangeTitlePage()
        {
            InitializeComponent();
            BindingContext = this;
        }


        async void OnSetButtonClicked(object sender, EventArgs e)
        {
            var main = new MainPage();
            main.StackAdd(titleEditor.Text);
            App.Current.MainPage = new NavigationPage(new MainPage { Title = titleEditor.Text }) ;
            

            await Navigation.PopAsync();
            
        }
    }
}