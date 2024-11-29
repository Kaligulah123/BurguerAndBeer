using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurguerAndBeer.Shared.Dtos
{
    public record OrderDto(long Id, DateTime OrderAt, double TotalPrice, int ItemsCount = 0);
    public record OrderItemDto(long Id,int ItemId, int CategoryId, string Name, int Quantity, double Price)
    {
        public double TotalPrice => Quantity * Price;
    }  

    public record OrderPlaceDto(OrderDto Order, OrderItemDto[] Items);

}
