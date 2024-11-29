using BurguerAndBeer.Shared.Dtos;
using Refit;

namespace BurguerAndBeer.Mobile.Services
{
    public interface IBeerApi
    {
        [Get("/api/beers")]
        Task<BeerDto[]> GetBeersAsync();
    }
}
