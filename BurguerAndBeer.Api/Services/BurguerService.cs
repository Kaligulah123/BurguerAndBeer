using BurguerAndBeer.Api.Data;
using BurguerAndBeer.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BurguerAndBeer.Api.Services
{
    public class BurguerService(DataContext context)
    {
        private readonly DataContext _context = context;

        public async Task<BurguerDto[]> GetBurguersAsync() => 
            await _context.Burguer.AsNoTracking()
            .Select(b =>
              new BurguerDto(
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
