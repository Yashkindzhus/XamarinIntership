using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using PinsApp.Views;
using System.Collections.ObjectModel;

namespace PinsApp.ViewModels
{
    public class PinsViewModel : BaseViewModel
    {
        public PinsViewModel(INavigationService navigationService) : base(navigationService)
        {


        }


    }
}