using BurguerAndBeer.Mobile.MVVM.Views;
using BurguerAndBeer.Mobile.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurguerAndBeer.Mobile.MVVM.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        private readonly AuthService _authService;

        public ProfileViewModel(AuthService authService)
        {
            _authService = authService;
        }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Initials))]
        private string _name = "";

        public string Initials
        {
            get
            {      
                //Hugo Vazquez -> parts[0] = Hugo   parts[1] = Vazquez
                var parts = Name.Split(' ',StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                if(parts.Length > 1)
                {
                    return $"{parts[0][0]}{parts[1][0]}".ToUpper(); // -> HV
                }
                //Hugo
                return Name.Length > 1 ? Name[..1].ToUpper() : Name.ToUpper();
            }
        }

        public void Initialize()
        {
            Name = _authService.User!.Name;
        }

        [RelayCommand]
        private async Task SignoutAsync()
        {
            _authService.Signout();
            await GoToAsync($"//{nameof(OnboardingView)}");
        }

        [RelayCommand]
        private async Task GoToMyOrdersAsync()
        {         
            await GoToAsync(nameof(MyOrdersView), animate: true);
        }
    }
}
