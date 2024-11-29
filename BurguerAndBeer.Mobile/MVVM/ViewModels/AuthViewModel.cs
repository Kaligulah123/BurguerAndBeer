using BurguerAndBeer.Mobile.MVVM.Views;
using BurguerAndBeer.Mobile.Services;
using BurguerAndBeer.Shared.Dtos;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurguerAndBeer.Mobile.MVVM.ViewModels
{
    public partial class AuthViewModel(IAuthApi authApi, AuthService authService) : BaseViewModel
    {
        private readonly IAuthApi _authApi = authApi;

        private readonly AuthService _authService = authService;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignup))]
        private string? _name;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignin)), NotifyPropertyChangedFor(nameof(CanSignup))]
        private string? _email;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignin)), NotifyPropertyChangedFor(nameof(CanSignup))]
        private string? _password;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignup))]
        private string? _address;

        public bool CanSignin => !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        public bool CanSignup => CanSignin && !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Address);

        [RelayCommand]
        private async Task SignupAsync()
        {
            IsBusy = true;

            try
            {
                var signupDto = new SignupRequestDto(Name, Email, Password, Address);

                //Make Api Call
                var result = await _authApi.SignupAsync(signupDto);

                if (result.IsSuccess)
                {
                    _authService.Signin(result.Data);

                    //await ShowAlertAsync(result.Data.Token);
                    //Navigate to HomeView
                    await GoToAsync($"//{nameof(HomeView)}", animate: true);
                }
                else
                {
                    //Display Error Alert
                    await ShowErrorAlertAsync(result.ErrorMessage ?? "Unknow error in signin up");
                }
            }
            catch (Exception ex)
            {
                await ShowErrorAlertAsync(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task SigninAsync()
        {
            IsBusy = true;

            try
            {
                var signinDto = new SigninRequestDto(Email, Password);

                //Make Api Call
                var result = await _authApi.SigninAsync(signinDto);

                if (result.IsSuccess)
                {
                    _authService.Signin(result.Data);

                    //await ShowAlertAsync(result.Data.User.Name);
                    //Navigate to HomeView
                    await GoToAsync($"//{nameof(HomeView)}", animate: true);
                }
                else
                {
                    //Display Error Alert
                    await ShowErrorAlertAsync(result.ErrorMessage ?? "Unknow error in signin in");
                }
            }
            catch (Exception ex)
            {
                await ShowErrorAlertAsync(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
