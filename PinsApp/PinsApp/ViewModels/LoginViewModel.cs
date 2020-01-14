using System;
using System.Windows.Input;
using Prism.Navigation;
using Prism.Commands;
using Xamarin.Forms;
using PinsApp.Services.Authorisation;

namespace PinsApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IAuthorisationService _authorisationService;

        public LoginViewModel(INavigationService navigationService, IAuthorisationService authorisationService) : base(navigationService)
        {
            _navigationService = navigationService;
            _authorisationService = authorisationService;
        }

        #region -- Private helpers --

        private async void OnLoginPressedCommand()
        {
            await _authorisationService.LoginAsync(Email, Password);
        }

        private async void OnRegisterPressedCommand()
        {
            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(Views.RegisterView)}");

        }

        #endregion

        #region -- Public properties --

        private ICommand _loginPressedCommand;
        public ICommand LoginPressedCommand { get => _loginPressedCommand ?? (_loginPressedCommand = new Command(OnLoginPressedCommand)); set => SetProperty(ref _loginPressedCommand, value); }

        private ICommand _registerPressedCommand;
        public ICommand RegisterPressedCommand { get => _registerPressedCommand ?? (_registerPressedCommand = new Command(OnRegisterPressedCommand)); set => SetProperty(ref _registerPressedCommand, value); }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        #endregion
    }

}
