using System;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;
using PinsApp.Services.Authorisation;

namespace PinsApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private IAuthorisationService _authorisationService;


        public RegisterViewModel(INavigationService navigationService, IAuthorisationService authorisationService) : base(navigationService)
        {
            _authorisationService = authorisationService;
        }

        #region _PublicProperties

        private ICommand _cancelPressedCommand;
        public ICommand CancelPressedCommand
        {
            get => _cancelPressedCommand ?? (_cancelPressedCommand = new Command(OnCancelPressedCommand));
            set => SetProperty(ref _cancelPressedCommand, value);
        }

        private ICommand _registerPressedCommand;
        public ICommand RegisterPressedCommand
        {
            get => _registerPressedCommand ?? (_registerPressedCommand = new Command(OnRegisterPressedCommand));
            set => SetProperty(ref _registerPressedCommand, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _passwordAgain;
        public string PasswordAgain
        {
            get => _passwordAgain;
            set => SetProperty(ref _passwordAgain, value);
        }
        #endregion

        #region _PrivateHelpers
        private async void OnCancelPressedCommand()
        {
            await NavigationService.GoBackAsync();
        }

        private void OnRegisterPressedCommand()
        {
            _authorisationService.RegisterAsync(Name, Email, Password, PasswordAgain);

        }
        #endregion
    }
}
