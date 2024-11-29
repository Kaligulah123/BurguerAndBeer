using BurguerAndBeer.Mobile.Services;

namespace BurguerAndBeer.Mobile.MVVM.Views;

public partial class OnboardingView : ContentPage
{
    private readonly AuthService _authService;

    public OnboardingView(AuthService authService)
	{
		InitializeComponent();

        _authService = authService;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        if(_authService.User is not null && _authService.User.Id != default(Guid) && !string.IsNullOrWhiteSpace(_authService.Token))
        {
            //User is already logged
            await Shell.Current.GoToAsync($"//{nameof(HomeView)}");
        }
    }

    private async void Signin_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SigninView));
    }

    private async void Signup_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignupView));
    }

    private async void Home_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(HomeView)}");
    }
}