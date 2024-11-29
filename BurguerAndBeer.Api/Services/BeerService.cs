using BurguerAndBeer.Api.Data;
using BurguerAndBeer.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BurguerAndBeer.Api.Services
{
    public class BeerService(DataContext context)
    {
        private readonly DataContext _context = context;

        public async Task<BeerDto[]> GetBeersAsync() =>
            await _context.Beer.AsNoTracking()
            .Select(b =>
              new BeerDto(
                    b.Id,
                    b.Name,
                    b.Image,
                    b.Description,
                    b.Price,
                    b.CategoryId
                  ))
            .ToArrayAsync();
    }
}
