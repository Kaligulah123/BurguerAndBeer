using BurguerAndBeer.Mobile.MVVM.ViewModels;

namespace BurguerAndBeer.Mobile.MVVM.Views;

public partial class DetailsView : ContentPage
{
    private readonly DetailsViewModel _detailsViewModel;

    public DetailsView(DetailsViewModel detailsViewModel)
	{
		InitializeComponent();

        BindingContext = _detailsViewModel = detailsViewModel;
    }
}