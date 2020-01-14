using System;
using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace PinsApp.ViewModels
{
	public class AddPinViewModel : BaseViewModel
	{
		public AddPinViewModel(INavigationService navigationService)
			: base (navigationService)
		{
		}

		#region -- Public properties --

		private ICommand _cancelPressedCommand;
		public ICommand CancelPressedCommand
		{
			get => _cancelPressedCommand ?? (_cancelPressedCommand = new Command(OnCancelPressedCommand));
			set => SetProperty(ref _cancelPressedCommand, value);
		}

		#endregion

		#region -- Private helpers --

		private async void OnCancelPressedCommand()
		{
			await NavigationService.GoBackAsync();
		}

		#endregion
	}
}
