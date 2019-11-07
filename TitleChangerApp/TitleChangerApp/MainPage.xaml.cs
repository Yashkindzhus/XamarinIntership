using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TitleChangerApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public List<string> Labels { get; set; } = new List<string>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
           
           
        }

        public void StackAdd(string labl)
        {
            Labels.Add(labl);
        }

        async void OnEditButtonClicked(object sender, EventArgs e)
        {
            Labels.Add(this.Title);
            await Navigation.PushAsync(new ChangeTitlePage());     
        }

        async void OnAllTitlesButtonClicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new AllTitlesPage(Labels));
        }
    }
}
