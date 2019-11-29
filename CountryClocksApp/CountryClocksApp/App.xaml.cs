using Prism;
using Prism.Ioc;
using CountryClocksApp.ViewModels;
using CountryClocksApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CountryClocksApp
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var database = new Database("LoginPassword");
            database.CreateTable<User>();

            User logPass1 = new User();
            logPass1.Login = "Anastasiia";
            logPass1.Password = "c9taDf54";
            database.AddItem(logPass1);

            User logPass2 = new User();
            logPass2.Login = "Mark";
            logPass2.Password = "1234";
            database.AddItem(logPass2);

            User logPass3 = new User();
            logPass3.Login = "Alex";
            logPass3.Password = "23hgTe56";
            database.AddItem(logPass3);

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
