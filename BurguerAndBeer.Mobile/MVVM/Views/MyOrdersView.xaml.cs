using BurguerAndBeer.Mobile.MVVM.ViewModels;

namespace BurguerAndBeer.Mobile.MVVM.Views;

public partial class MyOrdersView : ContentPage
{
    private readonly OrdersViewModel _ordersViewModel;

    public MyOrdersView(OrdersViewModel ordersViewModel)
	{
		InitializeComponent();
        BindingContext = _ordersViewModel = ordersViewModel;
    }

    protected override async void OnAppearing()
    {
        await _ordersViewModel.InitializeAsync();
    }
}