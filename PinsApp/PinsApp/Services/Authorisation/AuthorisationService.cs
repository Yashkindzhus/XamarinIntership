using System;
using SQLite;
using Xamarin.Forms;
using Prism.Navigation;
using System.Windows.Input;
using System.Collections.Generic;
using PinsApp.Services.Repository;
using PinsApp.ViewModels;
using System.Text.RegularExpressions;
using Acr.UserDialogs;
using PinsApp.Resources.Strings;
using System.Threading.Tasks;
using PinsApp.Models;

namespace PinsApp.Services.Authorisation
{
    public class AuthorisationService : BaseViewModel, IAuthorisationService
    {

        private IRepositoryService _repositoryService;

        public AuthorisationService(INavigationService navigationService, IRepositoryService repositoryService)
            : base(navigationService)
        {
            _repositoryService = repositoryService;
        }


        public async Task RegisterAsync(string name, string email, string password, string passwordAgain)
        {
            email = email.Replace(" ", string.Empty);
            password = password.Replace(" ", string.Empty);
			List<UserModel> users = new List<UserModel>();
			users = await _repositoryService.GetItemsAsync<UserModel>();

			foreach (UserModel user in users)
			{
				if ((email == user.Email) && (password == user.Password))
				{
				    await UserDialogs.Instance.AlertAsync(Strings.UserExist, Strings.Error, Strings.TryAgain);
                    return;
				}
			}
         
            if (Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success && (password == passwordAgain))
            {
                UserModel user = new UserModel()
                {
                    Name = name,
                    Email = email,
                    Password = password
                };

                await _repositoryService.AddAsync(user);
                await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(Views.LoginView)}");
            }
            else
            {
                await UserDialogs.Instance.AlertAsync(Strings.YourEmailIsIncorrectOrPasswordsAreNotMatch, Strings.Error, Strings.TryAgain);
            }
        }

        public async Task LoginAsync(string email, string password)
        {
			email = email.Replace(" ", string.Empty);

            List<UserModel> users = new List<UserModel>();
			users = await _repositoryService.GetItemsAsync<UserModel>();

			foreach (UserModel user in users)
			{
				if ((email == user.Email) && (password == user.Password))
				{
				    await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(Views.PinsView)}");
					return;
				}
			}
         
            await UserDialogs.Instance.AlertAsync(Strings.LoginOrPasswordIsIncorrect, Strings.Error, Strings.TryAgain);                
        }
    }
}
