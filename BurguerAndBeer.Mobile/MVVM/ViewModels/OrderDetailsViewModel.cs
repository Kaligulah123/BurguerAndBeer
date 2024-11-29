using BurguerAndBeer.Mobile.Services;
using BurguerAndBeer.Shared.Dtos;
using CommunityToolkit.Mvvm.ComponentModel;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurguerAndBeer.Mobile.MVVM.ViewModels
{
    [QueryProperty(nameof(OrderId), nameof(OrderId))]
    public partial class OrderDetailsViewModel : BaseViewModel
    {
        private readonly AuthService _authService;
        private readonly IOrderApi _orderApi;

        [ObservableProperty]
        private long _orderId;

        [ObservableProperty]
        private string _title = "Order Items";

        [ObservableProperty]
        private OrderItemDto[] orderItems = [];

        public OrderDetailsViewModel(AuthService authService, IOrderApi orderApi)
        {
            _authService = authService;
            _orderApi = orderApi;
        }

        partial void OnOrderIdChanged(long value)
        {
            Title = $"Order #{value}";
            LoadOrderItemsAsync(value);
        }

        private async Task LoadOrderItemsAsync(long orderId)
        {
            IsBusy = true;
            try
            {
                OrderItems = await _orderApi.GetOrderItemsAsync(orderId);
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
    }
}
