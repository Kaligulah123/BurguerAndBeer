using BurguerAndBeer.Mobile.MVVM.ViewModels;
using CommunityToolkit.Maui.Views;

namespace BurguerAndBeer.Mobile.MVVM.Views.Popups;

public partial class ChangePasswordPopup : Popup
{
    private readonly ChangePasswordViewModel _changePasswordViewModel;

    public ChangePasswordPopup(ChangePasswordViewModel changePasswordViewModel)
	{
		InitializeComponent();
        BindingContext = _changePasswordViewModel = changePasswordViewModel;
    }

    private async void Cross_Clicked(object sender, EventArgs e)
    {
        await CloseAsync();
    }
}