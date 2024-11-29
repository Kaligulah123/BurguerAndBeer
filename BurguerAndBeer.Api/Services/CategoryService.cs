using BurguerAndBeer.Api.Data;
using BurguerAndBeer.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BurguerAndBeer.Api.Services
{
    public class CategoryService(DataContext context)
    {
        private readonly DataContext _context = context;

        public async Task<CategoryDto[]> GetCategoriesAsync() =>
            await _context.Category.AsNoTracking()
            .Select(b =>
              new CategoryDto(
                    b.Id,
                    b.Name                   
                  ))
            .ToArrayAsync();
    }
}
