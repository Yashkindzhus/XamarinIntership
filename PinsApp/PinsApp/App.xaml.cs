using System;
using PinsApp.ViewModels;
using PinsApp.Views;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using PinsApp.Repository;
using Prism.Plugin.Popups;

namespace PinsApp
{
    public partial class App : PrismApplication
    {

        public static App Instance { get; private set; }

        public static T Resolve<T>()
        {
            return (Application.Current as App).Container.Resolve<T>();
        }

        public App()
            : this(null)
        {
        }

        public App(Prism.IPlatformInitializer initializer = null)
            : base(initializer)
        {
            Instance = this;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<Prism.Navigation.INavigationService, Prism.Navigation.PageNavigationService>();
            containerRegistry.RegisterInstance<IRepositoryService>(Container.Resolve<RepositoryService>());
            containerRegistry.RegisterInstance<Services.IAuthorisationService>(Container.Resolve<Services.AuthorisationService>());


            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();
            containerRegistry.RegisterForNavigation<PinsView, PinsViewModel>();
            containerRegistry.RegisterForNavigation<RegisterView, RegisterViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MapPageView, MapPageViewModel>();
            containerRegistry.RegisterForNavigation<PinListView, PinListViewModel>();
			containerRegistry.RegisterForNavigation<AddPinView, AddPinViewModel>();

            //  containerRegistry.RegisterPopupNavigationService();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"{nameof(LoginView)}");
        }
    }
}
