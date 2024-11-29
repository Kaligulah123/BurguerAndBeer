using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Refit;
using BurguerAndBeer.Mobile.Services;
using BurguerAndBeer.Mobile.MVVM.ViewModels;
using BurguerAndBeer.Mobile.MVVM.Views;

#if ANDROID
using Xamarin.Android.Net;
using System.Net.Security;
#elif IOS
using Security;
#endif


namespace BurguerAndBeer.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
                    fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
                })
                .ConfigureMauiHandlers(h =>
                {
#if ANDROID
                    h.AddHandler<Shell, TabbarBadgeRenderer>();
#endif
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<DatabaseService>();

            builder.Services.AddTransient<AuthViewModel>();
            builder.Services.AddTransient<SignupView>();
            builder.Services.AddTransient<SigninView>();           

            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddTransient<OnboardingView>();

            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<HomeView>();

            builder.Services.AddTransient<DetailsViewModel>();
            builder.Services.AddTransient<DetailsView>();

            builder.Services.AddSingleton<CartViewmodel>();
            builder.Services.AddTransient<CartView>();

            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<ProfileView>();

            builder.Services.AddTransient<OrdersViewModel>();
            builder.Services.AddTransient<MyOrdersView>();

            builder.Services.AddTransient<OrderDetailsViewModel>();
            builder.Services.AddTransient<OrderDetailsView>();

            ConfigureRefit(builder.Services);

            // Aplicar la personalización del Entry
//            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyCustomEntry", (handler, view) =>
//            {
//#if ANDROID
//                var nativeEntry = handler.PlatformView;

//                // Cambiar el color de la línea inferior
//                if (nativeEntry != null)
//                {
//                    nativeEntry.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.ParseColor("#FFC71F")); // Color amarillo
//                    nativeEntry.Invalidate(); // Forzar redibujo
//                }
//#endif
//            });



            return builder.Build();
        }

        private static void ConfigureRefit(IServiceCollection services)
        {               
            services.AddRefitClient<IAuthApi>(GetRefitSettings)
                .ConfigureHttpClient(SetHttpClient);

            services.AddRefitClient<IBurguerApi>(GetRefitSettings)
                 .ConfigureHttpClient(SetHttpClient);

            services.AddRefitClient<IBeerApi>(GetRefitSettings)
                .ConfigureHttpClient(SetHttpClient);

            services.AddRefitClient<IChipsApi>(GetRefitSettings)
                .ConfigureHttpClient(SetHttpClient);

            services.AddRefitClient<IDessertApi>(GetRefitSettings)
                .ConfigureHttpClient(SetHttpClient);

            services.AddRefitClient<ICategoryApi>(GetRefitSettings)
              .ConfigureHttpClient(SetHttpClient);

            services.AddRefitClient<IOrderApi>(GetRefitSettings)
             .ConfigureHttpClient(SetHttpClient);

            static void SetHttpClient(HttpClient httpClient)
            {
                var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                                                            ? "https://10.0.2.2:7212"
                                                            : "https://localhost:7212";

                if(DeviceInfo.DeviceType == DeviceType.Physical)
                {
                    baseUrl = "https://pxkr2mn3-7212.uks1.devtunnels.ms";
                }

                httpClient.BaseAddress = new Uri(baseUrl);
            }

            static RefitSettings GetRefitSettings(IServiceProvider serviceProvider)
            {
                var authService = serviceProvider.GetRequiredService<AuthService>();

                var refitSettings = new RefitSettings
                {
                    HttpMessageHandlerFactory = () =>
                    {
                        //return HttpMessageHandler
#if ANDROID

                        return new AndroidMessageHandler
                        {
                            ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
                            {
                                return certificate?.Issuer == "CN=localhost" || sslPolicyErrors == SslPolicyErrors.None;
                            }
                        };
#elif IOS
                    return new NSUrlSessionHandler
                    {
                        TrustOverrideForUrl = (NSUrlSessionHandler sender, string url, SecTrust trust) => url.StartsWith("https://localhost")
                    };

#endif
                        return null;
                    },
                    AuthorizationHeaderValueGetter = (_, __) => Task.FromResult(authService.Token ?? string.Empty)

                };

                return refitSettings;
            }
        }
    }
}
