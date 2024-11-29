using BurguerAndBeer.Shared.Dtos;
using Refit;

namespace BurguerAndBeer.Mobile.Services
{
    public interface IChipsApi
    {
        [Get("/api/chips")]
        Task<ChipsDto[]> GetChipsAsync();
    }
}
