using BurguerAndBeer.Api.Data;
using BurguerAndBeer.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BurguerAndBeer.Api.Services
{
    public class ChipsService(DataContext context)
    {
        private readonly DataContext _context = context;

        public async Task<ChipsDto[]> GetChipsAsync() =>
            await _context.Chips.AsNoTracking()
            .Select(b =>
              new ChipsDto(
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
