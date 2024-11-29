using BurguerAndBeer.Mobile.MVVM.Models;
using BurguerAndBeer.Mobile.MVVM.Views;
using BurguerAndBeer.Mobile.Services;
using BurguerAndBeer.Shared.Dtos;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurguerAndBeer.Mobile.MVVM.ViewModels
{
    public partial class CartViewmodel : BaseViewModel
    {
        private readonly DatabaseService _databaseService;
        private readonly IOrderApi _orderApi;
        private readonly AuthService _authService;
        private readonly OrdersViewModel _ordersViewModel;

        [ObservableProperty]
        private double _priceTotalOrder;
        public ObservableCollection<CartItem> CartItems { get; set; } = new();
        public static int TotalCartCount { get; set; }
        public static event EventHandler<int>? TotalCartCountChanged;

        public CartViewmodel(DatabaseService databaseService, IOrderApi orderApi, AuthService authService, OrdersViewModel ordersViewModel)
        {
            _databaseService = databaseService;
            _orderApi = orderApi;
            _authService = authService;
            _ordersViewModel = ordersViewModel;
        }

        public async Task InitializeCartAsync()
        {
            var dbItems = await _databaseService.GetAllCartItemsAsync();
            foreach (var dbItem in dbItems)
            {
                CartItems.Add(dbItem.ToCartItemModel());
            }
            NotifyCartCountChange();
        }

        public async Task AddItemToCart(IItemDto itemDto)
        {
            var existingItem = CartItems.FirstOrDefault(i => i.ItemId == itemDto.Id && i.CategoryId == itemDto.CategoryId);

            if (existingItem is not null)
            {             
                await UpdateQuantityAsync(existingItem, option: true);

                await ShowToastAsync("Item quantity updated");            
            }
            else
            {
                var cartItem = new CartItem
                {
                    ItemId = itemDto.Id,
                    CategoryId = itemDto.CategoryId,
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    Quantity = 1
                };

                CartItems.Add(cartItem);

                var id = await _databaseService.AddCartItem(new Data.CartItemEntity(cartItem));

                cartItem.Id = id;

                await ShowToastAsync("Item added in the cart");

                NotifyCartCountChange();
            }           
        }

        private void NotifyCartCountChange()
        {
            TotalCartCount = CartItems.Sum(i => i.Quantity);
            TotalCartCountChanged?.Invoke(null, TotalCartCount);
            PriceTotalOrder = CartItems.Sum(i => i.PriceTotal);
        }

        [RelayCommand]
        private async Task ClearCartAsync()
        {
            if(CartItems.Count == 0)
            {
                await ShowAlertAsync("Empty Cart","There are no items in the cart");
                return;
            }

            if (await ConfirmAsync("Clear Cart?", "Do you really want to clear all items from the cart?"))
            {
                await _databaseService.ClearCartAsync();
                CartItems.Clear();
                await ShowToastAsync("Cart cleared!");
                NotifyCartCountChange();
            }
        }

        [RelayCommand]
        private async Task PlaceOrderAsync()
        {
            if (CartItems.Count == 0)
            {
                await ShowAlertAsync("Empty Cart", "Please add some items to cart before placing order");
                return;
            }

            IsBusy = true;

            try
            {
                var order = new OrderDto(0, DateTime.Now, PriceTotalOrder);
                var orderItems = CartItems.Select(i => new OrderItemDto(i.Id,i.ItemId, i.CategoryId, i.Name , i.Quantity, i.Price)).ToArray();
                var orderPlaceDto = new OrderPlaceDto(order, orderItems);

                var result = await _orderApi.PlaceOrderAsync(orderPlaceDto);

                if (!result.IsSuccess)
                {
                    await ShowErrorAlertAsync(result.ErrorMessage!);
                    return;
                }

                await _databaseService.ClearCartAsync();
                CartItems.Clear();
                _ordersViewModel.IsInitialized = false;
                await ShowToastAsync("Order sent!!!!");
                NotifyCartCountChange();
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

        private async Task UpdateQuantityAsync(CartItem cartItem, bool option)
        {
            var dbCartItem = await _databaseService.GetCartItemAsync(cartItem);

            dbCartItem.Quantity += option ? 1 : -1;           

            cartItem.Quantity = dbCartItem.Quantity;

            await _databaseService.UpdateCartItem(dbCartItem);

            NotifyCartCountChange();
        }

        [RelayCommand]
        private async Task IncreaseQuantityAsync(CartItem cartItem)
        {
            await UpdateQuantityAsync(cartItem, option: true);
        }

        [RelayCommand]
        private async Task DecreaseQuantityAsync(CartItem cartItem)
        {
            await (cartItem.Quantity <= 1
                ? CleartCartItemAsync(cartItem)
                : UpdateQuantityAsync(cartItem, option: false));
        }

        [RelayCommand]
        private async Task CleartCartItemAsync(CartItem cartItem)
        {
            if (await ConfirmAsync("Remove item?", "Do you really want to delete the selected item?"))
            {
                var existingItem = CartItems.FirstOrDefault(i => i.ItemId == cartItem.ItemId && i.CategoryId == cartItem.CategoryId);
                if (existingItem is null) return;

                CartItems.Remove(existingItem);

                var dbCartItem = await _databaseService.GetCartItemAsync(cartItem);
                if (dbCartItem is null) return;

                await _databaseService.DeleteCartItemAsync(dbCartItem);

                await ShowToastAsync("Item deleted from cart");
                NotifyCartCountChange();
            }
        }
    }
}
