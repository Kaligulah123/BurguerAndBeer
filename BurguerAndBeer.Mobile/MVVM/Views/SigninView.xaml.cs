using BurguerAndBeer.Mobile.MVVM.ViewModels;

namespace BurguerAndBeer.Mobile.MVVM.Views;

public partial class SigninView : ContentPage
{
	public SigninView(AuthViewModel authViewModel)
	{
		InitializeComponent();

		BindingContext = authViewModel;
	}

    private async void SignupLabel_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignupView));
    }
}