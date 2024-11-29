using BurguerAndBeer.Mobile.MVVM.ViewModels;

namespace BurguerAndBeer.Mobile.MVVM.Views;

public partial class SignupView : ContentPage
{
	public SignupView(AuthViewModel authViewModel)
	{
		InitializeComponent();

        BindingContext = authViewModel;
    }

    private async void SigninLabel_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SigninView));
    }
}