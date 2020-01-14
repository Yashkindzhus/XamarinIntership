using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PinsApp.Controls;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Acr.UserDialogs;
using PinsApp.Resources.Strings;

namespace PinsApp.ViewModels
{
    public class MapPageViewModel : BaseViewModel
    {
        public MapPageViewModel(INavigationService navigationService) : base (navigationService)
        {
        }

        private ICommand _locationPressedCommand;
        public ICommand LocationPressedCommand
        {
            get => _locationPressedCommand ?? (_locationPressedCommand = new Command(RequestPermission));
            set => SetProperty(ref _locationPressedCommand, value);
        }

        private bool _locationEnabled;
        public bool LocationEnabled
        {
            get => _locationEnabled;
            set => SetProperty(ref _locationEnabled, value);
        }

        private async void RequestPermission()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    status = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location))[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    LocationEnabled = true;
                }
                else if (status != PermissionStatus.Unknown)
                {
                    LocationEnabled = false;
                }
            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(Strings.SomethingWrong, Strings.Error, Strings.Cancel);
            }
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            RequestPermission();
        }
    }
}
