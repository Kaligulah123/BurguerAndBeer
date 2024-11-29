using BurguerAndBeer.Shared.Dtos;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BurguerAndBeer.Mobile.MVVM.ViewModels
{
    [QueryProperty(nameof(Item), nameof(Item))]
    public partial class DetailsViewModel(HomeViewModel homeViewModel, CartViewmodel cartViewmodel) : BaseViewModel
    {
        private readonly HomeViewModel _homeViewModel = homeViewModel;
        private readonly CartViewmodel _cartViewmodel = cartViewmodel;

        [ObservableProperty]
        private string? _itemName;

        [ObservableProperty]
        private string? _itemImage;

        [ObservableProperty]
        private string? _itemDescription;

        [ObservableProperty]
        private double _itemPrice;       

        [ObservableProperty]
        private BurguerDto? _burguer;

        [ObservableProperty]
        private BeerDto? _beer;

        [ObservableProperty]
        private ChipsDto? _chips;

        [ObservableProperty]
        private DessertDto? _dessert;

        [ObservableProperty]
        public IItemDto? _itemDto;

        private string? _item;      
        public string? Item
        {
            get => _item;
            set
            {
                SetProperty(ref _item, value);
                ProcessItem();
            }
        }       

        private void ProcessItem()
        {
            if (string.IsNullOrEmpty(Item))
                return;

            // Intenta deserializar el objeto en diferentes tipos

            var category = _homeViewModel.CategoriesCollection.First(c =>c.IsSelected == true);

            switch (category.Id)
            {
                case 1:
                    if (JsonSerializer.Deserialize<BurguerDto>(Item) is BurguerDto burguer)
                    {
                        ItemDto = burguer;
                    };
                    break;

                case 2:
                    if (JsonSerializer.Deserialize<BeerDto>(Item) is BeerDto beer)
                    {
                        ItemDto = beer;
                    };
                    break;

                case 3:
                    if (JsonSerializer.Deserialize<ChipsDto>(Item) is ChipsDto chips)
                    {
                        ItemDto = chips;
                    };
                    break;

                case 4:
                    if (JsonSerializer.Deserialize<DessertDto>(Item) is DessertDto dessert)
                    {
                        ItemDto = dessert;
                    };
                    break;
            }
        }

        [RelayCommand]
        private async Task AddToCart()
        {
            if(IsBusy) return;

            IsBusy = true;

            await Task.Delay(10);

            await _cartViewmodel.AddItemToCart(ItemDto!);

            IsBusy = false;
        }   

        [RelayCommand]
        private async Task GoBackAsync() => await GoToAsync("..", animate: true);
       
    }
}
