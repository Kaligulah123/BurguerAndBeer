using BurguerAndBeer.Mobile.MVVM.ViewModels;

namespace BurguerAndBeer.Mobile.MVVM.Views;

public partial class OrderDetailsView : ContentPage
{
    private readonly OrderDetailsViewModel _orderDetailsViewModel;

    public OrderDetailsView(OrderDetailsViewModel orderDetailsViewModel)
	{
		InitializeComponent();
        BindingContext = _orderDetailsViewModel = orderDetailsViewModel;
    }
}