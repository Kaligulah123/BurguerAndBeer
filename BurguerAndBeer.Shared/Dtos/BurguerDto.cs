using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurguerAndBeer.Shared.Dtos
{
    public record BurguerDto(int Id, string Name, string Image, string Description, double Price, int CategoryId) : IItemDto;
}
