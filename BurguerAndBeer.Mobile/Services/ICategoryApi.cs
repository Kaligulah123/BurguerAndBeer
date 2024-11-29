using BurguerAndBeer.Shared.Dtos;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurguerAndBeer.Mobile.Services
{
    public interface ICategoryApi
    {
        [Get("/api/categories")]
        Task<CategoryDto[]> GetCategoriesAsync();
    }
}
