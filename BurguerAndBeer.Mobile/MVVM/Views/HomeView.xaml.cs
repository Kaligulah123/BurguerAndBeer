using BurguerAndBeer.Mobile.MVVM.ViewModels;

namespace BurguerAndBeer.Mobile.MVVM.Views;

public partial class HomeView : ContentPage
{
    private readonly HomeViewModel _homeViewModel;   

    private const uint AnimationDuration = 500u;  

    public HomeView(HomeViewModel homeViewModel)
	{
		InitializeComponent();
        BindingContext = _homeViewModel = homeViewModel;        
    }

    protected override async void OnAppearing()
    {
        await _homeViewModel.InitializeAsync();
    }

    private void Profile_Tapped(object sender, TappedEventArgs e)
    {        
        _ = MainContentGrid.TranslateTo(this.Width * 0.5,0, AnimationDuration, Easing.CubicIn);
        _ = MainContentGrid.ScaleTo(0.8, AnimationDuration);      
        _ = MainContentGrid.RotateYTo(-45, 500, Easing.CubicIn);      
        _ = MainContentGrid.FadeTo(0.8, AnimationDuration);
    }
  
    private void CloseMenu()
    {
        //Close the menu and bring back back the main content
        _ = MainContentGrid.FadeTo(1, AnimationDuration);        
        _ = MainContentGrid.TranslateTo(0, 0, AnimationDuration, Easing.CubicIn);
        _ = MainContentGrid.ScaleTo(1, AnimationDuration);
        _ = MainContentGrid.RotateYTo(0, 500, Easing.CubicIn);
    }  

    private void Cross_Clicked(object sender, EventArgs e)
    {
        CloseMenu();
    }

    private async void ChangeProfileImage_Tapped(object sender, TappedEventArgs e)
    {
        var fileResult = await MediaPicker.PickPhotoAsync();

        if (fileResult != null)
        {
            //Upload/Save image
            var imageStream = await fileResult.OpenReadAsync();

            var localPath = Path.Combine(FileSystem.AppDataDirectory, fileResult.FileName);

            using var fs = new FileStream(localPath, FileMode.Create, FileAccess.Write);

            await imageStream.CopyToAsync(fs);

            //Update imageIcon on the UI         

            _homeViewModel.ImageProfile = localPath;
        }
    }    
}