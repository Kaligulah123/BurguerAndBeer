using BurguerAndBeer.Mobile.MVVM.Views;
using BurguerAndBeer.Mobile.Services;

namespace BurguerAndBeer.Mobile
{
    public partial class AppShell : Shell
    {
        private readonly AuthService _authService;
        public AppShell(AuthService authService)
        {
            InitializeComponent();

            RegisterRoutes();

            _authService = authService;
        }

        private readonly static Type[] _routablePageTypes =
            [
                typeof(SigninView),
                typeof(SignupView),
                typeof(MyOrdersView),
                typeof(OrderDetailsView),
                typeof(DetailsView),
            ];
      

        private static void RegisterRoutes()
        {
            //Routing.RegisterRoute("SigninView", typeof(SigninView));
            //Routing.RegisterRoute(nameof(SigninView), typeof(SigninView));
            //Routing.RegisterRoute(nameof(SignupView), typeof(SignupView));

            foreach (var pageType in _routablePageTypes)
            {
                Routing.RegisterRoute(pageType.Name, pageType);
            }
        }

        private async void FlyoutFooter_Tapped(object sender, TappedEventArgs e)
        {
            await Launcher.OpenAsync("https://www.google.es/");
        }

        private async void SignoutMenuItem_Clicked(object sender, EventArgs e)
        {
            _authService.Signout();

            await Shell.Current.GoToAsync($"//{nameof(OnboardingView)}");          

        }
    }
}
