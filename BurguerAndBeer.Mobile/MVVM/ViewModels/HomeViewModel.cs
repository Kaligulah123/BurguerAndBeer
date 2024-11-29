using BurguerAndBeer.Mobile.MVVM.Models;
using BurguerAndBeer.Mobile.MVVM.Views;
using BurguerAndBeer.Mobile.Services;
using BurguerAndBeer.Shared.Dtos;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BurguerAndBeer.Mobile.MVVM.ViewModels
{
    public partial class HomeViewModel(IBurguerApi burguerApi, IBeerApi beerApi, IChipsApi chipsApi, IDessertApi dessertApi, ICategoryApi categoryApi, AuthService authService) : BaseViewModel
    {
        private readonly IBurguerApi _burguerApi = burguerApi;
        private readonly IBeerApi _beerApi = beerApi;
        private readonly IChipsApi _chipsApi = chipsApi;
        private readonly IDessertApi _dessertApi = dessertApi;
        private readonly ICategoryApi _categoryApi = categoryApi;
        private readonly AuthService _authService = authService;

        [ObservableProperty]
        private BurguerDto[] _burguers = [];

        [ObservableProperty]
        private BeerDto[] _beers = [];

        [ObservableProperty]
        private ChipsDto[] _chips = [];

        [ObservableProperty]
        private DessertDto[] _desserts = [];      

        [ObservableProperty]
        private Categories[] _categoriesCollection = [];

        [ObservableProperty]
        private Categories _currentCategory = new();

        [ObservableProperty]
        private string _userName = string.Empty;

        [ObservableProperty]
        private bool _burguersIsVisible;

        [ObservableProperty]
        private bool _beersIsVisible;

        [ObservableProperty]
        private bool _chipsIsVisible;

        [ObservableProperty]
        private bool _dessertsIsVisible;

        private bool _isInitialized;      


        public async Task InitializeAsync()
        {
            UserName = _authService.User!.Name;

            if (_isInitialized) return;

            IsBusy = true;

            try
            {
                _isInitialized = true;
                CreateCategories();
                await GetDataAsync();

                BurguersIsVisible = true;
                BeersIsVisible = true;
                ChipsIsVisible = true;
                DessertsIsVisible = true;              
                await Task.Delay(200);
                BeersIsVisible = false;
                ChipsIsVisible = false;
                DessertsIsVisible = false;             
            }
            catch(Exception ex)
            {
                _isInitialized= false;
                await ShowErrorAlertAsync(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task GetDataAsync()
        {    
            var categoriesTask = _categoryApi.GetCategoriesAsync();
            var burguersTask = _burguerApi.GetBurguersAsync();
            var beersTask = _beerApi.GetBeersAsync();
            var chipsTask = _chipsApi.GetChipsAsync();
            var dessertsTask = _dessertApi.GetDessertsAsync();

            await Task.WhenAll(burguersTask, beersTask, chipsTask, dessertsTask);

            //CategoriesCollection = await categoriesTask;
            Burguers = await burguersTask;
            Beers = await beersTask;
            Chips = await chipsTask;
            Desserts = await dessertsTask;           
        }
        private void CreateCategories()
        {
            CategoriesCollection = new List<Categories>
            {
                new Categories {Id=1, Name="Burguers", Image = "hamburguesa", IsSelected = true },
                new Categories {Id=2, Name="Beers", Image = "chapa_cerveza" },
                new Categories {Id=3, Name="Chips", Image = "papas_fritas" },
                new Categories {Id=4, Name="Desserts", Image = "magdalena" }
            }.ToArray();

            CurrentCategory = CategoriesCollection[0];
        }


        [RelayCommand]
        private void CategoryChanged(Categories selectedCategory)
        {
            if (selectedCategory.Id == CurrentCategory.Id) return;

            CurrentCategory.IsSelected = !CurrentCategory.IsSelected;

            CurrentCategory = CategoriesCollection.First(c => c.Id == selectedCategory.Id);

            CurrentCategory!.IsSelected = !CurrentCategory.IsSelected;

            //var newIsSelected = !selectedCategory.IsSelected;

            //CategoriesCollection = [.. CategoriesCollection.Select(c => {c.IsSelected = false; return c; })];

            //selectedCategory.IsSelected = newIsSelected;

            BurguersIsVisible = false;
            BeersIsVisible = false;
            ChipsIsVisible = false;
            DessertsIsVisible = false;

            switch (selectedCategory.Id)
            {
                case 1:                                
                    BurguersIsVisible = true;
                    break;
                case 2:                                   
                    BeersIsVisible = true;
                    break;
                case 3:                                     
                    ChipsIsVisible = true;
                    break;
                case 4:                                   
                    DessertsIsVisible = true;
                    break;
            }
        }

        [RelayCommand]
        private async Task GoToDetailsAsync(object sentObject)
        {
            if (sentObject == null)
                return;

            string serializedObject = JsonSerializer.Serialize(sentObject);
            var parameters = new Dictionary<string, object>
            {
                { nameof(DetailsViewModel.Item), serializedObject }
            };   

            await GoToAsync(nameof(DetailsView), animate: true, parameters);   
        }
    }
}

