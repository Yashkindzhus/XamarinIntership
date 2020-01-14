using System;
using SQLite;
using Xamarin.Forms;
using Prism.Navigation;
using System.Windows.Input;
using System.Collections.Generic;
using PinsApp.Repository;
using PinsApp.ViewModels;
using System.Text.RegularExpressions;
using Acr.UserDialogs;
using PinsApp.Resources.Strings;

namespace PinsApp.Services
{
    public class AuthorisationService : BaseViewModel, IAuthorisationService
    {

        private IRepositoryService _repositoryService;

        public AuthorisationService(INavigationService navigationService, IRepositoryService repositoryService)
            : base(navigationService)
        {
            _repositoryService = repositoryService;
        }


        public async void Register(string _Name, string _Email, string _Password, string _PasswordAgain)
        {
            _Email = _Email.Replace(" ", string.Empty);
            _Password = _Password.Replace(" ", string.Empty);

            if (await _repositoryService.FindItem(_Email, _Password))
            {
                await UserDialogs.Instance.AlertAsync(Strings.UserExist, Strings.Error, Strings.TryAgain);
                return;
            }
            if (Regex.Match(_Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success && (_Password == _PasswordAgain))
            {
                User user = new User()
                {
                    Name = _Name,
                    Email = _Email,
                    Password = _Password
                };

                await _repositoryService.SaveItemAsync(user);
                await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(Views.LoginView)}");
            }
            else
            {
                await UserDialogs.Instance.AlertAsync(Strings.YourEmailIsIncorrectOrPasswordsAreNotMatch, Strings.Error, Strings.TryAgain);
            }
        }

        public async void Login(string _Email, string _Password)
        {
            if (await _repositoryService.FindItem(_Email, _Password))
            {
                await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(Views.PinsView)}");
                return;
            }

            await UserDialogs.Instance.AlertAsync(Strings.LoginOrPasswordIsIncorrect, Strings.Error, Strings.TryAgain);
        }
    }
}
