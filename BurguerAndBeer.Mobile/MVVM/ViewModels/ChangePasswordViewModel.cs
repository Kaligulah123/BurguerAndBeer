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
    public partial class ChangePasswordViewModel : BaseViewModel
    {
        private readonly AuthService _authService;
        private readonly IAuthApi _authApi;

        [ObservableProperty,NotifyPropertyChangedFor(nameof(CanChangePassword))]
        private string? _oldPassword;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CanChangePassword))]
        private string? _newPassword;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(CanChangePassword))]
        private string? _confirmNewPassword;

        public bool CanChangePassword => 
            !string.IsNullOrWhiteSpace(_oldPassword) 
            && !string.IsNullOrWhiteSpace(_newPassword) 
            && !string.IsNullOrWhiteSpace(_confirmNewPassword);

        public ChangePasswordViewModel(AuthService authService, IAuthApi authApi)
        {
            _authService = authService;
            _authApi = authApi;
        }

        [RelayCommand]
        private async Task ChangePasswordAsync()
        {
            if(NewPassword != ConfirmNewPassword)
            {
                await ShowErrorAlertAsync("New password and confirm new password do not match");
                return;
            }
            IsBusy = true;
            try
            {
                var dto = new ChangePasswordDto(OldPassword!, NewPassword!);
                var result = await _authApi.ChangePasswordAsync(dto);
                if (!result.IsSuccess)
                {
                    await ShowErrorAlertAsync(result.ErrorMessage);
                    return;
                }

                await ShowAlertAsync("Success","Password changed succesfully!");
                OldPassword = NewPassword = ConfirmNewPassword = null;
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
