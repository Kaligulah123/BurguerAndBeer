using BurguerAndBeer.Shared.Dtos;
using Refit;

namespace BurguerAndBeer.Mobile.Services
{
    public interface IBurguerApi
    {
        [Get("/api/burguers")]
        Task<BurguerDto[]> GetBurguersAsync();
    }
}
