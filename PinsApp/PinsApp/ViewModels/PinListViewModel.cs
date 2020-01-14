using System;
using System.Windows.Input;
using PinsApp.Views;
using Prism.Navigation;
using Xamarin.Forms;

namespace PinsApp.ViewModels
{
	public class PinListViewModel : BaseViewModel
	{
		public PinListViewModel(INavigationService navigationService)
			: base(navigationService)
		{
		}

		#region -- Public properties --

		private ICommand _plusPressedCommand;
		public ICommand PlusPressedCommand
		{
			get => _plusPressedCommand ?? (_plusPressedCommand = new Command(OnPlusPressedCommand));
			set => SetProperty(ref _plusPressedCommand, value);
		}

		#endregion

		#region -- Private helpers --

		private async void OnPlusPressedCommand()
		{
			await NavigationService.NavigateAsync($"{nameof(AddPinView)}");
		}

		#endregion
	}
}
