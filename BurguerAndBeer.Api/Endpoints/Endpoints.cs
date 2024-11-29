using BurguerAndBeer.Api.Services;
using BurguerAndBeer.Shared.Dtos;
using System.Security.Claims;

namespace BurguerAndBeer.Api.Endpoints
{
    public static class Endpoints
    {
        private static Guid GetUserId(this ClaimsPrincipal principal) => Guid.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier)!);
        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("api/signup", async (SignupRequestDto dto, AuthService authService) =>
                                           TypedResults.Ok(await authService.SignupAsync(dto)));

            app.MapPost("api/signin", async (SigninRequestDto dto, AuthService authService)=>
                                            TypedResults.Ok(await authService.SigninAsync(dto)));

            app.MapGet("api/burguers", async (BurguerService burguerService) =>
                                            TypedResults.Ok(await burguerService.GetBurguersAsync()));

            app.MapGet("api/beers", async (BeerService beerService) =>
                                           TypedResults.Ok(await beerService.GetBeersAsync()));

            app.MapGet("api/chips", async (ChipsService chipsService) =>
                                          TypedResults.Ok(await chipsService.GetChipsAsync()));

            app.MapGet("api/desserts", async (DessertService dessertService) =>
                                         TypedResults.Ok(await dessertService.GetDessertsAsync()));

            app.MapGet("api/categories", async (CategoryService categoryService) =>
                                        TypedResults.Ok(await categoryService.GetCategoriesAsync()));

            var orderGroup = app.MapGroup("api/orders").RequireAuthorization();

            orderGroup.MapPost("/place_order", async (OrderPlaceDto dto, ClaimsPrincipal principal, OrderService orderService) =>
                await orderService.PlaceOrderAsync(dto, principal.GetUserId()));

            orderGroup.MapGet("", async (ClaimsPrincipal principal, OrderService orderService) =>
                                      TypedResults.Ok(await orderService.GetUserOrdersAsync(principal.GetUserId())));

            orderGroup.MapGet("/{orderId:long}/items", async (long orderId, ClaimsPrincipal principal, OrderService orderService) =>
                                     TypedResults.Ok(await orderService.GetUserOrderItemsAsync(orderId, principal.GetUserId())));

            return app;
        }
    }
}
