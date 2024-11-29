using BurguerAndBeer.Shared.Dtos;
using Refit;

namespace BurguerAndBeer.Mobile.Services
{
    public interface IDessertApi
    {
        [Get("/api/desserts")]
        Task<DessertDto[]> GetDessertsAsync();
    }
}
