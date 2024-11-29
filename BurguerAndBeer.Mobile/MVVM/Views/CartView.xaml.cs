using BurguerAndBeer.Mobile.MVVM.ViewModels;

namespace BurguerAndBeer.Mobile.MVVM.Views;

public partial class CartView : ContentPage
{
    private readonly CartViewmodel _cartViewmodel;

    public CartView(CartViewmodel cartViewmodel)
	{
		InitializeComponent();
        BindingContext = _cartViewmodel = cartViewmodel;
    }
}