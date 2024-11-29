using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurguerAndBeer.Shared.Dtos
{
    public interface IItemDto
    {
        int Id { get; init; }
        string Name { get; }
        string Image { get; }
        string Description { get; }
        double Price { get; }
        int CategoryId { get; }
        
    }
}
