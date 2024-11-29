using BurguerAndBeer.Mobile.MVVM.Views;
using BurguerAndBeer.Mobile.Services;
using BurguerAndBeer.Shared.Dtos;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurguerAndBeer.Mobile.MVVM.ViewModels
{
    public partial class OrdersViewModel : BaseViewModel
    {
        private readonly AuthService _authService;
        private readonly IOrderApi _orderApi;

        [ObservableProperty]
        private OrderDto[] _orders = [];

        public OrdersViewModel(AuthService authService, IOrderApi orderApi)
        {
            _authService = authService;
            _orderApi = orderApi;
        }

        public async Task InitializeAsync() => await LoadOrdersAsync();      

        [RelayCommand]
        private async Task LoadOrdersAsync()
        {
            IsBusy = true;
            try
            {
                Orders = await _orderApi.GetMyOrdersAsync();
                if (Orders.Length == 0)
                {
                    await ShowToastAsync("No orders found");
                }
            }
            catch (ApiException ex)
            {
                await HandleApiExceptionAsync(ex, () => _authService.Signout());
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task GoToOrderDetailsViewAsync(long orderId)
        {
            var parameter = new Dictionary<string, object>
            {
                [nameof(OrderDetailsViewModel.OrderId)] = orderId,
            };
            await GoToAsync(nameof(OrderDetailsView), animate: true, parameter);
        }
    }
}
