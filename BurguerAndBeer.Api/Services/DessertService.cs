using BurguerAndBeer.Api.Data;
using BurguerAndBeer.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BurguerAndBeer.Api.Services
{
    public class DessertService(DataContext context)
    {
        private readonly DataContext _context = context;

        public async Task<DessertDto[]> GetDessertsAsync() =>
            await _context.Dessert.AsNoTracking()
            .Select(b =>
              new DessertDto(
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
