using BurguerAndBeer.Mobile.MVVM.ViewModels;

namespace BurguerAndBeer.Mobile.MVVM.Views;

public partial class ProfileView : ContentPage
{
    private readonly ProfileViewModel _profileViewModel;

    public ProfileView(ProfileViewModel profileViewModel)
	{
		InitializeComponent();
        BindingContext = _profileViewModel = profileViewModel;
    }

    protected override void OnAppearing()
    {
        _profileViewModel.Initialize();
    }
}