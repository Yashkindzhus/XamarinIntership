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
    public partial class AllTitlesPage : ContentPage
    {
       
        public AllTitlesPage(List<string> lbl)
        {
            InitializeComponent();
            var main = new MainPage();
            var newLabel = new Label();
            newLabel.SetBinding(Label.TextProperty, "ChangeLabel");
            
            foreach (string s in lbl)
                Content = new StackLayout
                {
                    Children = { new Label { Text = s }, newLabel }
                };
        }
    }
}