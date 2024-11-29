using BurguerAndBeer.Mobile.MVVM.ViewModels;
using BurguerAndBeer.Mobile.Services;

namespace BurguerAndBeer.Mobile
{
    public partial class App : Application
    {
        private readonly CartViewmodel _cartViewmodel;

        public App(AuthService authService, CartViewmodel cartViewmodel)
        {
            InitializeComponent();

            authService.Initialize();

            MainPage = new AppShell(authService);
            _cartViewmodel = cartViewmodel;
        }

        protected override async void OnStart()
        {
            await _cartViewmodel.InitializeCartAsync();
        }
    }
}
